// Decompiled with JetBrains decompiler
// Type: TheSite.StampaRapportiPdf.logoff
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.Security;
using System.Web.UI;

namespace TheSite.StampaRapportiPdf
{
  public class logoff : Page
  {
    private void Page_Load(object sender, EventArgs e)
    {
      FormsAuthentication.SignOut();
      this.Response.Cookies["InailRuoli"].Value = (string) null;
      this.Response.Cookies["InailRuoli"].Expires = new DateTime(1999, 10, 12);
      this.Response.Cookies["InailRuoli"].Path = "/";
      this.Response.Redirect("../Default.aspx");
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
