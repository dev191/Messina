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
using MyCollection;
using System.Reflection; 

namespace TheSite.ManutenzioneProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per SfogliaRdlOdl_MP.
	/// </summary>
	public class SfogliaRdlOdl_MP : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Button btIndietro;
	    protected WebControls.GridTitle GridTitle1;
		public MyCollection.clMyCollection _Contenitore
		{
			get 
			{
				if(this.ViewState["mioContenitore"]!=null)
					return (MyCollection.clMyCollection)this.ViewState["mioContenitore"];
				else
					return new MyCollection.clMyCollection();
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{
				#region Recupero la proprieta di ricerca
				// Recupero il tipo dall'oggetto context.
				Type myType=Context.Handler.GetType();       
				// recupero il PropertyInfo object passando il nome della proprietà da recuperare.
				PropertyInfo myPropInfo = myType.GetProperty("_Contenitore");
			
				// verifico che questa proprietà esista.
				if(myPropInfo!=null)
					this.ViewState.Add("mioContenitore",myPropInfo.GetValue(Context.Handler,null));

				#endregion

				if (Context.Items["wo_id"]!=null)
				{
				    this.wo_id=(string)Context.Items["wo_id"];
					executeDatiGenerali();
					execute();
				}
			}
		}
		private string  wo_id
		{
				get { 
						if(this.ViewState["wo_id"]!=null)
						  return (string)ViewState["wo_id"];
						else 
						  return string.Empty;
					}
			set{ViewState.Add("wo_id",value);}
		}
		
		private void executeDatiGenerali()
		{
			TheSite.Classi.ManProgrammata.SfogliaRdlOdl _SfogliaRdlOdl=new TheSite.Classi.ManProgrammata.SfogliaRdlOdl(Context.User.Identity.Name);
									
			// WO_ID
			DataSet _Ds = _SfogliaRdlOdl.GetSingleRdl(int.Parse(wo_id));			
												
			if (_Ds.Tables[0].Rows.Count>0)
			{
				this.DataGrid1.DataSource = _Ds.Tables[0];
				this.DataGrid1.DataBind();
				DataGrid1.Visible=true;
			}
			else
			{
				DataGrid1.Visible=false;
			}
		}
		private void execute()
		{

			TheSite.Classi.ManProgrammata.SfogliaRdlOdl _SfogliaRdlOdl=new TheSite.Classi.ManProgrammata.SfogliaRdlOdl(Context.User.Identity.Name);
									
			// WO_ID
			DataSet _Ds = _SfogliaRdlOdl.GetDettailSingleRdl(int.Parse(wo_id));			
												
			if (_Ds.Tables[0].Rows.Count>0)
			{
				GridTitle1.Visible =true;
				GridTitle1.hplsNuovo.Visible=false;
                GridTitle1.NumeroRecords= _Ds.Tables[0].Rows.Count.ToString();  
				this.DataGrid2.DataSource = _Ds.Tables[0];
				this.DataGrid2.DataBind();
				DataGrid2.Visible=true;
			}
			else
			{
				GridTitle1.Visible =false;
				DataGrid2.Visible=false;
			}

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
			this.DataGrid2.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid2_PageIndexChanged);
			this.btIndietro.Click += new System.EventHandler(this.btIndietro_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid2_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			DataGrid2.CurrentPageIndex=e.NewPageIndex;
			execute();
		}


		private void btIndietro_Click(object sender, System.EventArgs e)
		{
		 Server.Transfer("SfogliaOdlRdl.aspx");  
		}
		public void lk_Command(object sender, CommandEventArgs e)
		{
			Context.Items.Add("wo_id",e.CommandArgument);
			Server.Transfer("Completamento_MP_WRList.aspx"); 
		}
	}
}
