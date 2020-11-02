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

namespace WebCad
{
	/// <summary>
	/// Descrizione di riepilogo per _Default.
	/// </summary>
	public class _Default : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected string UrlParams;
		protected string FromPaginaCreazioneRdl = String.Empty;
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Request["FromPaginaApprovaEmettiRdl"]!=null)
			{
				string FromPaginaApprovaEmettiRdl = Request["FromPaginaApprovaEmettiRdl"];
				string BlId = Request["BlId"];
				string IdPiano = Request["IdPiano"];
				string IdServizio = Request["IdServizio"];
				string Planimetria = Request["Planimetria"];
				UrlParams = "?BlId=" + BlId +"&IdPiano=" + IdPiano + "&IdServizio=" + IdServizio + "&Planimetria=" + Planimetria + "&FromPaginaApprovaEmettiRdl=" + FromPaginaApprovaEmettiRdl;

			}
			if(Request["FromPaginaCreazioneRdl"]!= null)
			{
				string FromPaginaCreazioneRdl = Request["FromPaginaCreazioneRdl"];
				string BlId = Request["BlId"];
				string IdPiano = Request["IdPiano"];
				string IdServizio = Request["IdServizio"];
				UrlParams = "?BlId=" + BlId +"&IdPiano=" + IdPiano + "&IdServizio=" + IdServizio + "&FromPaginaCreazioneRdl=" + FromPaginaCreazioneRdl;
			}
			Session["parametri"]=null;
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
