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
using System.Web.Security;

namespace TheSite
{
	/// <summary>
	/// Descrizione di riepilogo per Logoff.
	/// </summary>
	public class Logoff : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Log User Off from Cookie Authentication System
			FormsAuthentication.SignOut();
      
			// Invalidate roles token
			Response.Cookies[FormsAuthentication.FormsCookieName].Value = null;
			Response.Cookies[FormsAuthentication.FormsCookieName].Expires = new System.DateTime(1999, 10, 12);
			Response.Cookies[FormsAuthentication.FormsCookieName].Path = "/";
        
			// Redirect user back to the Portal Home Page
			Response.Redirect("Default.aspx");
			
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
