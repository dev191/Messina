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
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using TheSite.Classi.ClassiDettaglio;
   
namespace TheSite.CommonPage
{
	/// <summary>
	/// Descrizione di riepilogo per NavigazioneApparechiature.
	/// </summary>
	public class RiepilogoReperibilita : System.Web.UI.Page
	{
		protected  System.Web.UI.WebControls.DataGrid MyDataGrid1;

		public static int FunId = 0;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.HyperLink HyperLinkChiudi2;				
		public static string HelpLink = string.Empty;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];

			FunId = _SiteModule.ModuleId;

//			if (!IsPostBack) 
//			{
				/// Recupero i Valori dalla Query string passati per la ricerca
				/// Imposto le Porprietà

				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];

				if(Request.QueryString["bl_id"]!=null)
				{
					this.bl_id = Request.QueryString["bl_id"].ToString();
				}
				else
				{
					this.bl_id = "";
				}

				if (this.bl_id == "")
				{
					Execute();
				}
				else
				{
					Execute(this.bl_id);
				}
//			}
		}

		#region Proprietà Private
		
			private string bl_id
			{
				get	{return ViewState["bl_id"].ToString();}
				set {ViewState["bl_id"] = value;}
			}

		# endregion

		public DataSet fasce(int addettoid, int giorno)
		{
			Classi.ClassiAnagrafiche.Reperibilita  _Reperibilita = new TheSite.Classi.ClassiAnagrafiche.Reperibilita();
			
			return _Reperibilita.GetReperibilita(addettoid, giorno).Copy();
			
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
			this.MyDataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged_1);
			this.MyDataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.MyDataGrid1_ItemDataBound);
			this.MyDataGrid1.SelectedIndexChanged += new System.EventHandler(this.MyDataGrid1_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Ottiene imposta la visibilità della griglia e dell'ogetto title
		/// </summary>
		/// <param name="Visibile"> indica true di renderli visibili</param>

		private void Execute()
		{

			///Istanzio la Classe per eseguire la Strore Procedure
			Classi.ClassiAnagrafiche.Reperibilita  _Reperibilita = new TheSite.Classi.ClassiAnagrafiche.Reperibilita();
			
			///Eseguo il Binding sulla Griglia.
			DataSet Ds=_Reperibilita.GetAllAddetti();

			MyDataGrid1.DataSource= Ds.Tables[0];
			MyDataGrid1.DataBind();

		}
		private void Execute(string bl_id)
		{


			///Istanzio la Classe per eseguire la Strore Procedure
			Classi.ClassiAnagrafiche.Reperibilita  _Reperibilita = new TheSite.Classi.ClassiAnagrafiche.Reperibilita();

			///Eseguo il Binding sulla Griglia.
			DataSet Ds =_Reperibilita.GetAddettiDistinct(bl_id);
			
			MyDataGrid1.DataSource= Ds;
			MyDataGrid1.DataBind();

		}


		private void btReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("RiepilogoReperibilita.aspx?FunId=" + ViewState["FunId"]); 
		}

		private void MyDataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void MyDataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

//			if (e.Item.ItemIndex != -1)
//			{
//				Classi.ClassiAnagrafiche.Reperibilita  _Reperibilita = new TheSite.Classi.ClassiAnagrafiche.Reperibilita();
//				DataSet _ds = _Reperibilita.GetSpecializzazioni(int.Parse(MyDataGrid1.DataKeys[e.Item.ItemIndex].ToString())).Copy();
//
//				if (_ds.Tables[0].Rows.Count != 0)
//				{
//					for (int i=0;i<_ds.Tables[0].Rows.Count;i++)
//						e.Item.Cells[1].ToolTip = e.Item.Cells[1].ToolTip  + _ds.Tables[0].Rows[i]["spec"].ToString() + "\n" ;
//				}
//			}
//
//			if((e.Item.ItemType == ListItemType.Item) ||
//				(e.Item.ItemType == ListItemType.AlternatingItem))
//			{ 
//				string descrizione="";
//				
//				if (e.Item.Cells[4].Text.Trim().Length > 10) 
//				{
//					descrizione=e.Item.Cells[4].Text.Trim().Substring(0,7) + "..."; 
//					e.Item.Cells[4].ToolTip=e.Item.Cells[4].Text;
//					e.Item.Cells[4].Text=descrizione;
//				} 
//			}
		}

		private void MyDataGrid1_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			MyDataGrid1.CurrentPageIndex=e.NewPageIndex;
			if(Request.QueryString["bl_id"]!=null)
			{
				this.bl_id = Request.QueryString["bl_id"].ToString();
			}
			else
			{
				this.bl_id = "";
			}

			if (this.bl_id == "")
			{
				Execute();
			}
			else
			{
				Execute(this.bl_id);
			}

		}

	}
}
