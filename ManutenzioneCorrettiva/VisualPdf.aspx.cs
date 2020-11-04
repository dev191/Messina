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
using System.IO;
namespace TheSite.ManutenzioneCorretiva
{
	/// <summary>
	/// Descrizione di riepilogo per VisualPdf.
	/// </summary>
	public class VisualPdf : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal Literal1;
	    protected WebControls.PageTitle PageTitle1; 
		private void Page_Load(object sender, System.EventArgs e)
		{
			PageTitle1.VisibleLogut=false; 
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{
				if (Request.QueryString["mittente"]==null)
					BindPdf();
				else
					BindAllegati();
			}
		}

		private void BindPdf()
		{
			if(Request.QueryString["wr_id"]==null || Request.QueryString["path"]==null || Request.QueryString["name"]==null)
               return;

			string tipo=string.Empty;
			string testo="";
            string destDir ="../Doc_DB/Correttiva/";
			string PathFileName=destDir + Request.QueryString["wr_id"] + "/";
            PathFileName+=Request.QueryString["path"] + "/" ;
            PathFileName+=Request.QueryString["name"]  ;
			
			FileInfo _FileInfo = new FileInfo(PathFileName);
			if (_FileInfo.Extension.ToUpper() ==".PDF")
			{
				tipo="type=\"application/pdf\"";
				Literal1.Text=testo="<embed src=\"" + PathFileName + "\" height=\"100%\" width=\"100%\" " + tipo + "></embed>";
			}
			if (_FileInfo.Extension.ToUpper() ==".DOC")
			{
				testo="<script language=\"JavaScript\">location.href=\"" + PathFileName + "\";</script>";
				Literal1.Text=testo;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindAllegati()
		{
			string destDir ="../EQAllegati/";
            string PathFileName=destDir +  Request.QueryString["name"]  ;
			string tipo=string.Empty;
			string testo="";
			FileInfo _FileInfo = new FileInfo(PathFileName);
			if (_FileInfo.Extension.ToUpper() ==".PDF")
			{
				tipo="type=\"application/pdf\"";
				Literal1.Text=testo="<embed src=\"" + PathFileName + "\" height=\"100%\" width=\"100%\" " + tipo + "></embed>";
			}
			if (_FileInfo.Extension.ToUpper() ==".JPG" || _FileInfo.Extension ==".JPEG" || _FileInfo.Extension ==".GIF")
			{
				tipo="type=\"image/jpg\"";
				Literal1.Text=testo="<img src='" + PathFileName + "'>";
			}

		}
	}
}
