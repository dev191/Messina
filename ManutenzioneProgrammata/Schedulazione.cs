// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.Schedulazione
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;

namespace TheSite.ManutenzioneProgrammata
{
  public class Schedulazione : Page
  {
    protected Panel PanelEdit;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e) => Schedulazione.HelpLink = ((SiteModule) HttpContext.Current.Items[(object) "SiteModule"]).HelpLink;

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
