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

namespace TheSite.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per FullImage.
	/// </summary>
	public class FullImage : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlImage imgdoc;
		protected WebControls.PageTitle PageTitle1;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			PageTitle1.VisibleLogut =false;
			if(!IsPostBack)
			{				 
				//PageImage.aspx?<%=Imagename%>&amp;p=y
				imgdoc.Src="PageImage.aspx?eq_image=" + Request.QueryString["eq_image"] + "&urlimage=" + Request.QueryString["urlimage"];
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
	}
}
