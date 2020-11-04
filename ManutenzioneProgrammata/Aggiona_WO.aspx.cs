using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using S_Controls.Collections;
using ApplicationDataLayer.DBType;

namespace TheSite.ManutenzioneProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per Aggiona_WO.
	/// </summary>
	public class Aggiona_WO : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Repeater RepeaterMaster;
		protected WebControls.PageTitle PageTitle1;
		int addetto_id=0;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			PageTitle1.VisibleLogut=false; 
			if(!IsPostBack)
			{
				if(Request.QueryString["addetto"]!=null)
				{
					addetto_id=Convert.ToInt32(  Request.QueryString["addetto"]);
					BindingMaster();
				}
			}

		}

		private void BindingMaster()
		{
			if(Session["CheckedListMP"]!=null)
			{
				Hashtable _HS = (Hashtable)Session["CheckedListMP"];
				_HS=RemoveHash(_HS);
				RepeaterMaster.DataSource =_HS;
				RepeaterMaster.DataBind(); 
				string mes = "<script language=\"javascript\">\n";			
				mes += "opener.refreshgriglia();";
				mes += "</script>\n";

				this.Page.RegisterStartupScript("agg",mes);
			}
		}
		/// <summary>
		/// Rimuove gli item con valore a false
		/// che indica quelli che non sono stati ceccati
		/// </summary>
		/// <param name="myList"></param>
		private  Hashtable RemoveHash(Hashtable myList )  
		{
			Hashtable _HS=new Hashtable();
			IDictionaryEnumerator myEnumerator = myList.GetEnumerator();
			while ( myEnumerator.MoveNext() )
				if((bool)myEnumerator.Value==true)
					_HS.Add(myEnumerator.Key,myEnumerator.Value);

			return _HS;
	
		}
		private DataSet UpdateWo(int itemId)
		{
			Classi.ManProgrammata.CompletaOrdine  _Completa = new TheSite.Classi.ManProgrammata.CompletaOrdine();
			
			int wo_id =  itemId;	
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();
						
			S_Controls.Collections.S_Object p_wo_id = new S_Object();
			p_wo_id.ParameterName = "p_wo_id";
			p_wo_id.DbType = CustomDBType.Integer;
			p_wo_id.Direction = ParameterDirection.Input;
			p_wo_id.Index = 0;					
			p_wo_id.Value = wo_id;																	
			CollezioneControlli.Add(p_wo_id);

			S_Controls.Collections.S_Object p_addetto_id = new S_Object();
			p_addetto_id.ParameterName = "p_addetto_id";
			p_addetto_id.DbType = CustomDBType.Integer;
			p_addetto_id.Direction = ParameterDirection.Input;
			p_addetto_id.Index = 1;					
			p_addetto_id.Value = addetto_id;																	
			CollezioneControlli.Add(p_addetto_id);
				
			DataSet Ds=_Completa.AggiornaWO(CollezioneControlli);	
									
			return Ds;			
		}
		#region Codice generato da Progettazione Web Form
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: questa chiamata è richiesta da Progettazione Web Form ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{    
			this.RepeaterMaster.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.RepeaterMaster_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void RepeaterMaster_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || 
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				Repeater RepeaterDett= (Repeater)e.Item.FindControl("RepeaterDettail");
				int item=Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Key").ToString());
				DataSet Ds=UpdateWo(item);
				RepeaterDett.DataSource =Ds.Tables[0];
				RepeaterDett.DataBind(); 				

			}
		}
	}
}
