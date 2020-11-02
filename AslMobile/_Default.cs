// Decompiled with JetBrains decompiler
// Type: TheSite.AslMobile._Default
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI.MobileControls;
using TheSite.AslMobile.Class;

namespace TheSite.AslMobile
{
  public class _Default : MobilePage
  {
    protected Panel Panel1;
    protected DeviceSpecific DeviceSpecific1;
    protected StyleSheet StyleSheet1;
    protected Form Form1;

    private void Page_Load(object sender, EventArgs e)
    {
      if (!ClassGlobal.IsMobileDevice)
        this.Response.Redirect("../Default.aspx");
      ((TextControl) this.Panel1.Controls[0].FindControl("lblUtente")).Text = "Utente " + this.Context.User.Identity.Name;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
