using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Security;
using System.Security.Principal;
using System.Web.Security;
using TheSite.Classi;
using System.Web.Mail;
using System.Text;
using System.IO;

namespace TheSite 
{
	/// <summary>
	/// Descrizione di riepilogo per Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Variabile di progettazione necessaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{

		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
			
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			
			int FunzioneId = 0;
        
			// Ottiene l'id della funzione dalla querystring
        
			if (Request.Params["FunId"] != null && Request.Params["FunId"]!="") 
			{  
				try
				{
					FunzioneId = Convert.ToInt32(Request.Params["FunId"]);
				}
				catch (System.Exception ex)
				{
					throw ex;
				}
			}
			Context.Items.Add("SiteModule", new SiteModule(FunzioneId));
			
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
			
			if (Request.IsAuthenticated == true) 
			{
				String[] a_roles;

				if ((Request.Cookies[FormsAuthentication.FormsCookieName] == null) || (Request.Cookies[FormsAuthentication.FormsCookieName].Value == ""))
				{	
					
					TheSite.Classi.Utente  _Utente = new TheSite.Classi.Utente();
					
					a_roles = _Utente.GetRuoli(Context.User.Identity.Name);
					
					string roleStr = "";
					foreach (String role in a_roles) 
					{
						roleStr += role;
						roleStr += ";";
					}

					// Create a cookie authentication ticket.
					FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
						1,                              // version
						Context.User.Identity.Name,     // user name
						DateTime.Now,                   // issue time
						DateTime.Now.AddHours(1),       // expires every hour
						false,                          // don't persist cookie
						roleStr                         // roles
						);

					// Encrypt the ticket
					String cookieStr = FormsAuthentication.Encrypt(ticket);

					// Send the cookie to the client
					Response.Cookies[FormsAuthentication.FormsCookieName].Value = cookieStr;
					Response.Cookies[FormsAuthentication.FormsCookieName].Path = "/";
					Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddMinutes(60);

				}
				else
				{
					// Get roles from roles cookie
					FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Context.Request.Cookies[FormsAuthentication.FormsCookieName].Value);

					//convert the string representation of the role data into a string array
					ArrayList userRoles = new ArrayList();

					foreach (String role in ticket.UserData.Split( new char[] {';'} )) 
					{
						userRoles.Add(role);
					}

					a_roles = (String[]) userRoles.ToArray(typeof(String));
				}

				Context.User = new GenericPrincipal(Context.User.Identity, a_roles);
			}
			else
			{
			
				bool cookieFound = false;

				HttpCookie authCookie = null;
				HttpCookie cookie;

				for(int i=0; i < Request.Cookies.Count; i++)
				{
					cookie = Request.Cookies[i];

					if (cookie.Name == FormsAuthentication.FormsCookieName)
					{
						cookieFound = true;
						authCookie = cookie;
						break;
					}
				}

				// If the cookie has been found, it means it has been issued from either
				// the windows authorisation site, is this forms auth site.
				if (cookieFound)
				{
					// Extract the roles from the cookie, and assign to our current principal, which is attached to the
					// HttpContext.
					FormsAuthenticationTicket winAuthTicket = FormsAuthentication.Decrypt(authCookie.Value);
					string[] roles = winAuthTicket.UserData.Split(';');
					FormsIdentity formsId = new FormsIdentity(winAuthTicket);
					GenericPrincipal princ = new GenericPrincipal(formsId,roles);
					HttpContext.Current.User = princ;
				}
				else
				{
					// No cookie found, we can redirect to the Windows auth site if we want, or let it pass through so
					// that the forms auth system redirects to the logon page for us.
				}

			}
		
		}

		protected void Application_Error(Object sender, EventArgs e)
		{
			try
			{
				//				MailMessage msg1 =new  MailMessage();
				//				msg1.From = "acascia@csy.it;";//acascia@csy.it
				//				msg1.To = "acascia@csy.it";
				//				msg1.Subject = "Page Error";
				//				msg1.Body = BuildMessage();
				//				msg1.BodyFormat = MailFormat.Html;
				//				msg1.Priority = MailPriority.Normal;
				//				SmtpMail.SmtpServer = "www.csy.it.compsys";
				//				SmtpMail.Send(msg1);
				string Namefile= System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString().PadLeft(2,Convert.ToChar("0")) +
					System.DateTime.Now.Day.ToString().PadLeft(2,Convert.ToChar("0")) +System.DateTime.Now.Second.ToString()  + System.DateTime.Now.Minute.ToString() +
					System.DateTime.Now.Hour.ToString(); 
				string path=Server.MapPath("/Inail/Log");
				path=System.IO.Path.Combine(path,Namefile.ToString() + ".html");  
				using (StreamWriter sw = new StreamWriter(path)) 
				{
					sw.Write(BuildMessage());
				}

				string appRoot =Request.ApplicationPath	;
				//				if (this.Request.Path.ToUpper() == appRoot.ToUpper() + "DEFAULT.ASPX") 
				//				{
				//					this.Response.Redirect(appRoot + "ErrorPage.aspx");
				//				} // 
				
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message); 
			}
		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
		public string BuildMessage()
		{
			StringBuilder strMessage =new StringBuilder();

			strMessage.Append("<style type=\"text/css\">");
			strMessage.Append("<!--");
			strMessage.Append(".basix {");
			strMessage.Append("font-family: Verdana, Arial, Helvetica, sans-serif;");
			strMessage.Append("font-size: 12px;");
			strMessage.Append("}");
			strMessage.Append(".header1 {");
			strMessage.Append("font-family: Verdana, Arial, Helvetica, sans-serif;");
			strMessage.Append("font-size: 12px;");
			strMessage.Append("font-weight: bold;");
			strMessage.Append("color: #000099;");
			strMessage.Append("}");
			strMessage.Append(".tlbbkground1 {");
			strMessage.Append("background-color: #000099;");
			strMessage.Append("}");
			strMessage.Append("-->");
			strMessage.Append("</style>");

			strMessage.Append("<table width=\"85%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"1\" class=\"tlbbkground1\">");
			strMessage.Append("<tr bgcolor=\"#eeeeee\">");
			strMessage.Append("<td colspan=\"2\" class=\"header1\">Page Error</td>");
			strMessage.Append("</tr>");
			strMessage.Append("<tr>");
			strMessage.Append("<td width=\"100\" align=\"right\" bgcolor=\"#eeeeee\" class=\"header1\" nowrap>IP Address</td>");
			strMessage.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" +  Request.ServerVariables["REMOTE_ADDR"].ToString()  + "</td>");
			strMessage.Append("</tr>");
			strMessage.Append("<tr>");
			strMessage.Append("<td width=\"100\" align=\"right\" bgcolor=\"#eeeeee\" class=\"header1\" nowrap>User Agent</td>");
			strMessage.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + Request.ServerVariables["HTTP_USER_AGENT"].ToString() + "</td>");
			strMessage.Append("</tr>");
			strMessage.Append("<tr>");
			strMessage.Append("<td width=\"100\" align=\"right\" bgcolor=\"#eeeeee\" class=\"header1\" nowrap>Page</td>");
			strMessage.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + Request.Url.AbsoluteUri + "</td>");
			strMessage.Append("</tr>");
			strMessage.Append("<tr>");
			strMessage.Append("<td width=\"100\" align=\"right\" bgcolor=\"#eeeeee\" class=\"header1\" nowrap>Time</td>");
			strMessage.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + System.DateTime.Now + " EST</td>");
			strMessage.Append("</tr>");
			strMessage.Append("<tr>");
			strMessage.Append("<td width=\"100\" align=\"right\" bgcolor=\"#eeeeee\" class=\"header1\" nowrap>Details</td>");
			strMessage.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + Server.GetLastError().InnerException.ToString() + "</td>");
			strMessage.Append("</tr>");
			strMessage.Append("</table>");
			return strMessage.ToString();
		}

		#region Codice generato da Progettazione Web Form
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

