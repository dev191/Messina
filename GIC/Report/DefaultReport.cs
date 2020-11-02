// Decompiled with JetBrains decompiler
// Type: GIC.Report.DefaultReport
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using GIC.Report.UserControl;
using System;
using System.Web;
using System.Web.UI;
using TheSite.Classi;

namespace GIC.Report
{
  public class DefaultReport : Page
  {
    protected VisSelCampi VisSelCampi1;
    protected SelezioneQuery SelezioneQuery1;
    public static string HelpLink = string.Empty;

    public bool VisCampiVisible
    {
      set => this.VisSelCampi1.Visible = value;
    }

    public string VisSelCampi1SelectedItemsValue
    {
      set => this.VisSelCampi1.SelectedItemsValue = value;
    }

    public int IdQuery
    {
      set => this.VisSelCampi1.IdQuery = value;
    }

    public void RicaricaLista() => this.SelezioneQuery1.Ricarica();

    public void RicaricaQuery() => this.VisSelCampi1.Ricarica();

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.VisSelCampi1.IdQuery == 0)
        this.VisSelCampi1.Visible = false;
      DefaultReport.HelpLink = ((SiteModule) HttpContext.Current.Items[(object) "SiteModule"]).HelpLink;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
