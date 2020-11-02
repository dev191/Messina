// Decompiled with JetBrains decompiler
// Type: TheSite.Global
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Security;
using TheSite.Classi;

namespace TheSite
{
  public class Global : HttpApplication
  {
    private IContainer components = (IContainer) null;

    public Global() => this.InitializeComponent();

    protected void Application_Start(object sender, EventArgs e)
    {
    }

    protected void Session_Start(object sender, EventArgs e)
    {
    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {
      int ModuleId = 0;
      if (this.Request.Params["FunId"] != null)
      {
        if (this.Request.Params["FunId"] != "")
        {
          try
          {
            ModuleId = Convert.ToInt32(this.Request.Params["FunId"]);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }
      }
      this.Context.Items.Add((object) "SiteModule", (object) new SiteModule(ModuleId));
    }

    protected void Application_EndRequest(object sender, EventArgs e)
    {
    }

    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
      if (this.Request.IsAuthenticated)
      {
        string[] roles;
        if (this.Request.Cookies[FormsAuthentication.FormsCookieName] == null || this.Request.Cookies[FormsAuthentication.FormsCookieName].Value == "")
        {
          roles = new Utente().GetRuoli(this.Context.User.Identity.Name);
          string str1 = "";
          foreach (string str2 in roles)
            str1 = str1 + str2 + ";";
          string name = this.Context.User.Identity.Name;
          DateTime now1 = DateTime.Now;
          DateTime now2 = DateTime.Now;
          DateTime expiration = now2.AddHours(1.0);
          string userData = str1;
          this.Response.Cookies[FormsAuthentication.FormsCookieName].Value = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(1, name, now1, expiration, false, userData));
          this.Response.Cookies[FormsAuthentication.FormsCookieName].Path = "/";
          HttpCookie cookie = this.Response.Cookies[FormsAuthentication.FormsCookieName];
          now2 = DateTime.Now;
          DateTime dateTime = now2.AddMinutes(60.0);
          cookie.Expires = dateTime;
        }
        else
        {
          FormsAuthenticationTicket authenticationTicket = FormsAuthentication.Decrypt(this.Context.Request.Cookies[FormsAuthentication.FormsCookieName].Value);
          ArrayList arrayList = new ArrayList();
          string userData = authenticationTicket.UserData;
          char[] chArray = new char[1]{ ';' };
          foreach (string str in userData.Split(chArray))
            arrayList.Add((object) str);
          roles = (string[]) arrayList.ToArray(typeof (string));
        }
        this.Context.User = (IPrincipal) new GenericPrincipal(this.Context.User.Identity, roles);
      }
      else
      {
        bool flag = false;
        HttpCookie httpCookie = (HttpCookie) null;
        for (int index = 0; index < this.Request.Cookies.Count; ++index)
        {
          HttpCookie cookie = this.Request.Cookies[index];
          if (cookie.Name == FormsAuthentication.FormsCookieName)
          {
            flag = true;
            httpCookie = cookie;
            break;
          }
        }
        if (!flag)
          return;
        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(httpCookie.Value);
        string[] roles = ticket.UserData.Split(';');
        HttpContext.Current.User = (IPrincipal) new GenericPrincipal((IIdentity) new FormsIdentity(ticket), roles);
      }
    }

    protected void Application_Error(object sender, EventArgs e)
    {
      try
      {
        string str = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, Convert.ToChar("0")) + DateTime.Now.Day.ToString().PadLeft(2, Convert.ToChar("0")) + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString();
        using (StreamWriter streamWriter = new StreamWriter(Path.Combine(this.Server.MapPath("/Inail/Log"), str.ToString() + ".html")))
          streamWriter.Write(this.BuildMessage());
        string applicationPath = this.Request.ApplicationPath;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    protected void Session_End(object sender, EventArgs e)
    {
    }

    protected void Application_End(object sender, EventArgs e)
    {
    }

    public string BuildMessage()
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
      stringBuilder.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + this.Request.ServerVariables["REMOTE_ADDR"].ToString() + "</td>");
      stringBuilder.Append("</tr>");
      stringBuilder.Append("<tr>");
      stringBuilder.Append("<td width=\"100\" align=\"right\" bgcolor=\"#eeeeee\" class=\"header1\" nowrap>User Agent</td>");
      stringBuilder.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + this.Request.ServerVariables["HTTP_USER_AGENT"].ToString() + "</td>");
      stringBuilder.Append("</tr>");
      stringBuilder.Append("<tr>");
      stringBuilder.Append("<td width=\"100\" align=\"right\" bgcolor=\"#eeeeee\" class=\"header1\" nowrap>Page</td>");
      stringBuilder.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + this.Request.Url.AbsoluteUri + "</td>");
      stringBuilder.Append("</tr>");
      stringBuilder.Append("<tr>");
      stringBuilder.Append("<td width=\"100\" align=\"right\" bgcolor=\"#eeeeee\" class=\"header1\" nowrap>Time</td>");
      stringBuilder.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + (object) DateTime.Now + " EST</td>");
      stringBuilder.Append("</tr>");
      stringBuilder.Append("<tr>");
      stringBuilder.Append("<td width=\"100\" align=\"right\" bgcolor=\"#eeeeee\" class=\"header1\" nowrap>Details</td>");
      stringBuilder.Append("<td bgcolor=\"#FFFFFF\" class=\"basix\">" + this.Server.GetLastError().InnerException.ToString() + "</td>");
      stringBuilder.Append("</tr>");
      stringBuilder.Append("</table>");
      return stringBuilder.ToString();
    }

    private void InitializeComponent() => this.components = (IContainer) new Container();
  }
}
