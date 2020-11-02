// Decompiled with JetBrains decompiler
// Type: TheSite.MobileWebForm1
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Data.OracleClient;
using System.Web.Mobile;
using System.Web.UI.MobileControls;
using TheSite.AslMobile.Class;

namespace TheSite
{
  public class MobileWebForm1 : MobilePage
  {
    protected DeviceSpecific DeviceSpecific1;
    protected Panel Panel1;
    protected Form frmLogin;

    private void Page_Load(object sender, EventArgs e)
    {
      if (!ClassGlobal.IsMobileDevice)
        this.Response.Redirect("Default.aspx");
      if (!this.Request.IsAuthenticated)
        return;
      this.Response.Redirect("Default.aspx");
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    protected void OnLogin(object sender, EventArgs e)
    {
      TextBox control1 = (TextBox) this.Panel1.Controls[0].FindControl("txtUserID");
      TextBox control2 = (TextBox) this.Panel1.Controls[0].FindControl("txtPassword");
      Label control3 = (Label) this.Panel1.Controls[0].FindControl("lblInvalidLogin");
      if (this.IsAuthenticated(control1.Text, control2.Text))
      {
        MobileFormsAuthentication.RedirectFromLoginPage(control2.Text, true);
      }
      else
      {
        control3.Visible = true;
        control3.Text = "*-Credenziali non Valide";
      }
    }

    private bool IsAuthenticated(string user, string password)
    {
      ClassUser classUser = new ClassUser();
      OracleParameterCollection CollezioneControlli = new OracleParameterCollection();
      CollezioneControlli.Add(new OracleParameter()
      {
        ParameterName = "p_Password",
        Size = 50,
        Direction = ParameterDirection.Input,
        OracleType = OracleType.VarChar,
        Value = (object) classUser.EncryptMD5(password)
      });
      CollezioneControlli.Add(new OracleParameter()
      {
        ParameterName = "IO_CURSOR",
        Direction = ParameterDirection.Output,
        OracleType = OracleType.Cursor
      });
      CollezioneControlli.Add(new OracleParameter()
      {
        ParameterName = "p_UserName",
        OracleType = OracleType.VarChar,
        Size = 50,
        Direction = ParameterDirection.Input,
        Value = (object) user
      });
      try
      {
        return classUser.Autentica(CollezioneControlli) > 0;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }
    }
  }
}
