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
using TheSite.Classi.ClassiAnagrafiche;
   
namespace TheSite.CommonPage
{
	/// <summary>
	/// Descrizione di riepilogo per NavigazioneApparechiature.
	/// </summary>
	public class RiepilogoSolleciti : System.Web.UI.Page
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

				if(Request.QueryString["idric"]!=null)
				{
					this.idric = Request.QueryString["idric"].ToString();
				}
				else
				{
					this.idric = "";
				}

				if (this.idric != "")
				{
					Execute(this.idric);
				}
			//				else
			//				{
			//					Execute();
			//				}

//			}
		}

		#region Proprietà Private
		
			private string idric
			{
				get	{return ViewState["idric"].ToString();}
				set {ViewState["idric"] = value;}
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Ottiene imposta la visibilità della griglia e dell'ogetto title
		/// </summary>
		/// <param name="Visibile"> indica true di renderli visibili</param>


		private void Execute(string idric)
		{

			///Istanzio la Classe per eseguire la Strore Procedure
			Classi.ManOrdinaria.Solleciti   _Solleciti = new TheSite.Classi.ManOrdinaria.Solleciti();
			
			///Eseguo il Binding sulla Griglia.
			DataSet Ds = _Solleciti.GetDataWR(idric); //TODO MAU 31/05/2005

			MyDataGrid1.DataSource= Ds;
			MyDataGrid1.DataBind();
		}

		private void MyDataGrid1_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			MyDataGrid1.CurrentPageIndex=e.NewPageIndex;
			Execute(this.idric);

		}

	}
}
