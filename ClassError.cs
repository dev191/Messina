// Decompiled with JetBrains decompiler
// Type: TheSite.ClassError
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Text;
using System.Web;

namespace TheSite
{
  public class ClassError
  {
    public static string GererateReport(
      HttpRequest Request,
      HttpServerUtility Server,
      Exception ex)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<style type=\"text/css\">");
      stringBuilder.Append("<!--");
      stringBuilder.Append(".basix {");
      stringBuilder.Append("font-family: Verdana, Arial, Helvetica, sans-serif;");
      stringBuilder.Append("font-size: 12px;");
      stringBuilder.Append("}");
      stringBuilder.Append(".header1 {");
      stringBuilder.Append("font-family: Verdana, Arial, Helvetica, sans-serif;");
      stringBuilder.Append("font-size: 12px;");
      stringBuilder.Append("font-weight: bold;");
      stringBuilder.Append("color: #000099;");
      stringBuilder.Append("}");
      stringBuilder.Append(".tlbbkground1 {");
      stringBuilder.Append("background-color: #000099;");
      stringBuilder.Append("}");
      stringBuilder.Append("-->");
      stringBuilder.Append("</style>");
      stringBuilder.Append("<table width=\"85%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"1\" class=\"tlbbkground1\">");
      stringBuilder.Append("<tr bgcolor=\"#eeeeee\">");
      stringBuilder.Append("<td colspan=\"2\" class=\"header1\">Page Error</td>");
      stringBuilder.Append("</tr>");
      stringBuilder.Append("<tr>");
      stringBuilder.Append("<td width=\"100\" align=\"right\" bgcolor=\"#eeeeee\" class=\"header1\" nowrap>IP Address</td>");
      stringBuilder.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + Request.ServerVariables["REMOTE_ADDR"].ToString() + "</td>");
      stringBuilder.Append("</tr>");
      stringBuilder.Append("<tr>");
      stringBuilder.Append("<td width=\"100\" align=\"right\" bgcolor=\"#eeeeee\" class=\"header1\" nowrap>User Agent</td>");
      stringBuilder.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + Request.ServerVariables["HTTP_USER_AGENT"].ToString() + "</td>");
      stringBuilder.Append("</tr>");
      stringBuilder.Append("<tr>");
      stringBuilder.Append("<td width=\"100\" align=\"right\" bgcolor=\"#eeeeee\" class=\"header1\" nowrap>Page</td>");
      stringBuilder.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + Request.Url.AbsoluteUri + "</td>");
      stringBuilder.Append("</tr>");
      stringBuilder.Append("<tr>");
      stringBuilder.Append("<td width=\"100\" align=\"right\" bgcolor=\"#eeeeee\" class=\"header1\" nowrap>Time</td>");
      stringBuilder.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + (object) DateTime.Now + " EST</td>");
      stringBuilder.Append("</tr>");
      stringBuilder.Append("<tr>");
      stringBuilder.Append("<td width=\"100\" align=\"right\" bgcolor=\"#eeeeee\" class=\"header1\" nowrap>Details</td>");
      if (Server.GetLastError() == null)
        stringBuilder.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + ex.Message + "</td>");
      else
        stringBuilder.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + Server.GetLastError().InnerException.ToString() + "</td>");
      stringBuilder.Append("</tr>");
      stringBuilder.Append("</table>");
      return stringBuilder.ToString();
    }

    public static string GererateReport(HttpRequest Request, HttpServerUtility Server) => ClassError.GererateReport(Request, Server, (Exception) null);
  }
}
