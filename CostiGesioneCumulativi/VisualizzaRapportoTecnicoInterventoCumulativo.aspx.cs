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

namespace TheSite.CostiGesioneCumulativi
{
	/// <summary>
	/// Descrizione di riepilogo per RapportoTecnicoInterventoCumulativo.
	/// </summary>
	public class RapportoTecnicoInterventoCumulativo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal ltlVisualizza;

		protected Csy.WebControls.DataPanel DataPanelRicerca;
		protected System.Web.UI.WebControls.LinkButton lnkBtnDownload;
		protected System.Web.UI.WebControls.LinkButton lnkBtnRicerca;
		private string  _filname; 
		private void Page_Load(object sender, System.EventArgs e)
		{
//			if(!IsPostBack)
//			{
				if (Request.QueryString["nome_file"]!=null)
				{
					this.filname =(string)Request.QueryString["nome_file"];
				
				}
				if (Context.Items["nome_file"]!=null)
				{
					this.filname =(string)Context.Items["nome_file"];
				}
			
				string DirectoryName = System.Configuration.ConfigurationSettings.AppSettings["DirectoryStampaCostoGestione"];
			


			Response.ClearContent();
			Response.ClearHeaders();
			Response.ContentType = "application/pdf";
			Response.WriteFile(GetFile(DirectoryName,this.filname.ToString()));
			Response.Flush();
			Response.Close();

//			}
		}
		private string GetFile(string PathRoot,string nomeFile)
		{

			
			return PathRoot + nomeFile + ".pdf" ; 
			
			
		}
		private string filname
		{
			get {return _filname;}
			set {_filname=value;}
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
//			this.lnkBtnDownload.Click += new System.EventHandler(this.lnkBtnDownload_Click);
//			this.lnkBtnRicerca.Click += new System.EventHandler(this.lnkBtnRicerca_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

//		private void lnkBtnDownload_Click(object sender, System.EventArgs e)
//		{
//			Response.Redirect("Pagina_Download_Cumulativi.aspx");
//		}
//
//		private void lnkBtnRicerca_Click(object sender, System.EventArgs e)
//		{
//			Response.Redirect("AnalisiCostiOperativiDiGestioneCumulativo.aspx");
//		}
	}
}
