using System;
using System.Text;
using System.Web;

 
namespace TheSite
{
	/// <summary>
	/// Descrizione di riepilogo per ClassError.
	/// Genera una Script Html da utilizare come Report per visualizzare l'errore.
	/// </summary>
	public class ClassError
	{
		public ClassError()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
		/// <summary>
		/// Genera l'html con delle info sull'errore
		/// </summary>
		/// <param name="Request"></param>
		/// <param name="Server"></param>
		/// <param name="ex"></param>
		/// <returns></returns>
		public static string GererateReport(System.Web.HttpRequest Request,System.Web.HttpServerUtility Server,Exception ex)
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
			if( Server.GetLastError()==null)
				strMessage.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + ex.Message  + "</td>");
			else
				strMessage.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + Server.GetLastError().InnerException.ToString() + "</td>");
			
			strMessage.Append("</tr>");
			strMessage.Append("</table>");
			return strMessage.ToString();
		}
		/// <summary>
		/// Genera l'html con delle info sull'errore
		/// </summary>
		/// <param name="Request"></param>
		/// <param name="Server"></param>
		/// <returns></returns>
		public static string GererateReport(System.Web.HttpRequest Request,System.Web.HttpServerUtility Server)
		{
		 return GererateReport(Request,Server,null);
		}
	}
}
