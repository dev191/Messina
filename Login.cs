// Decompiled with JetBrains decompiler
// Type: TheSite.Login
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using S_Controls;
using System;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;

namespace TheSite
{
  public class Login : Page
  {
    protected Button BttConferma;
    protected S_TextBox txtsUserName;
    protected S_TextBox txtsPasword;
    protected RequiredFieldValidator rfvUserName;
    protected RequiredFieldValidator rfvPassword;
    protected MessagePanel PanelMess;

    private void Page_Load(object sender, EventArgs e)
    {
      StringBuilder stringBuilder = new StringBuilder("");
      stringBuilder.Append("<script language='JavaScript'>");
      stringBuilder.Append("document.getElementById('" + ((Control) this.txtsUserName).ClientID + "').focus();<");
      stringBuilder.Append("/");
      stringBuilder.Append("script>");
      if (this.IsStartupScriptRegistered("Focus"))
        return;
      this.RegisterStartupScript("Focus", stringBuilder.ToString());
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.BttConferma.Click += new EventHandler(this.BttConferma_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void BttConferma_Click(object sender, EventArgs e)
    {
      Sicurezza sicurezza = new Sicurezza();
      Utente utente = new Utente();
      ((TextBox) this.txtsPasword).Text = sicurezza.EncryptMD5(((TextBox) this.txtsPasword).Text);
      try
      {
        if (utente.Login((Page) this) > 0)
        {
          string redirectUrl = FormsAuthentication.GetRedirectUrl(((TextBox) this.txtsUserName).Text, false);
          string[] ruoli = utente.GetRuoli(((TextBox) this.txtsUserName).Text);
          string userData = "";
          double num = 8.0;
          foreach (string str in ruoli)
            userData = userData + str + ";";
          this.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(new FormsAuthenticationTicket(1, ((TextBox) this.txtsUserName).Text, DateTime.Now, DateTime.Now.AddHours(num), false, userData, FormsAuthentication.FormsCookiePath))));
          this.Response.Redirect(redirectUrl);
        }
        else
          this.PanelMess.ShowError("Utenza o Password errati", true);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        this.PanelMess.ShowError(ex.Message.ToString(), true);
      }
    }
  }
}
