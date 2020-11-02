// Decompiled with JetBrains decompiler
// Type: TheSite.AnalisiStatistiche.Error
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace TheSite.AnalisiStatistiche
{
  public class Error : Page
  {
    protected HtmlGenericControl lblError;

    private void Page_Load(object sender, EventArgs e) => this.lblError.InnerText = this.Request["msgErr"].ToString();

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
