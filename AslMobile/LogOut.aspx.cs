using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Mobile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace TheSite.AslMobile
{
	/// <summary>
	/// Descrizione di riepilogo per LogOut.
	/// </summary>
	public class LogOut : System.Web.UI.MobileControls.MobilePage
	{
	
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific1;
		protected System.Web.UI.MobileControls.Panel Panel1;
		protected System.Web.UI.MobileControls.Form Form1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
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

		protected void OnDisconnetti(object sender, System.EventArgs e)
		{
			MobileFormsAuthentication.SignOut();
      
			// Redirect user back to the Portal Home Page
		   this.RedirectToMobilePage("Default.aspx");
		}
	}
}
