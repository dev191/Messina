using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Security.Principal;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace TheSite
{
	/// <summary>
	/// Descrizione di riepilogo per Login.
	/// </summary>
	public class Login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button BttConferma;
		protected S_Controls.S_TextBox txtsUserName;
		protected S_Controls.S_TextBox txtsPasword;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvUserName;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPassword;
		protected Csy.WebControls.MessagePanel PanelMess;
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			

			System.Text.StringBuilder sb = new System.Text.StringBuilder("");

			sb.Append("<script language='JavaScript'>");
			sb.Append("document.getElementById('" + txtsUserName.ClientID +
				"').focus();<");
			sb.Append("/");
			sb.Append("script>");

			if (!IsStartupScriptRegistered("Focus"))
			{
				this.RegisterStartupScript("Focus", sb.ToString());
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
			this.BttConferma.Click += new System.EventHandler(this.BttConferma_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BttConferma_Click(object sender, System.EventArgs e)
		{
			Classi.Sicurezza _Sic = new Classi.Sicurezza();
			Classi.Utente _Utente = new TheSite.Classi.Utente();

			txtsPasword.Text = _Sic.EncryptMD5(txtsPasword.Text);
			//txtsPasword.Text = _Sic.EncryptSHA1(txtsPasword.Text);
			try
			{
				
				int i_IdUtente = _Utente.Login(this);
			
				if (i_IdUtente > 0)
				{
					string url =  FormsAuthentication.GetRedirectUrl(txtsUserName.Text,false);
					//					FormsAuthentication.SetAuthCookie(txtsUserName.Text,false);
					//			
					//					Response.Redirect(url);
					string[] a_roles = _Utente.GetRuoli(txtsUserName.Text);
					
					string roleStr = "";
					double ore=8;
					foreach (String role in a_roles) 
					{
						//if(role.ToUpper()=="CALLCENTER")
						//	ore=8;
						roleStr += role;
						roleStr += ";";
					}

					FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
						1,
						txtsUserName.Text,
						DateTime.Now,                   // issue time
						DateTime.Now.AddHours(ore),       // expires every hour
						false,                          // don't persist cookie
						roleStr,                        // roles
						FormsAuthentication.FormsCookiePath);

					// Encrypt the ticket.
					string encTicket = FormsAuthentication.Encrypt(ticket);
                   
					// Create the cookie.
					Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

					// Redirect back to original URL.
					Response.Redirect(url);

				}
				else
				{
					PanelMess.ShowError("Utenza o Password errati", true);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);  
				//PanelMess.ShowError("Errore interno al Data Base.", true);
				PanelMess.ShowError(ex.Message.ToString(), true);

			}
		}

	}
}
