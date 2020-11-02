// Decompiled with JetBrains decompiler
// Type: TheSite._Default
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web;
using System.Web.UI;
using TheSite.AslMobile.Class;

namespace TheSite
{
  public class _Default : Page
  {
    public string url = "MainContent.aspx";
    public string url1 = "LeftFrame.aspx";

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.Request.QueryString["VarApp"] != null)
      {
        this.url = "ManutenzioneCorrettiva/CreazioneSGA.aspx?FunId=7&VarApp=" + this.Request.QueryString["VarApp"];
        this.url1 = "LeftFrame.aspx?VarApp=" + this.Request.QueryString["VarApp"];
      }
      else
      {
        if (HttpContext.Current.User.IsInRole("MA") && !HttpContext.Current.User.IsInRole("PA"))
        {
          this.url += "?VarApp=1";
          this.url1 = "LeftFrame.aspx?VarApp=1";
        }
        if (!HttpContext.Current.User.IsInRole("MA") && HttpContext.Current.User.IsInRole("PA"))
        {
          this.url += "?VarApp=2";
          this.url1 = "LeftFrame.aspx?VarApp=2";
        }
      }
      if (!ClassGlobal.IsMobileDevice)
        return;
      this.Response.Redirect("AslMobile/Default.aspx");
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
