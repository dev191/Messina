// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorrettiva.CostoMateriali
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorrettiva
{
  public class CostoMateriali : Page
  {
    private string wrId;
    protected materiali mtImpegnati1;

    private void Page_Load(object sender, EventArgs e)
    {
      this.wrId = this.Request["WR_ID"];
      this.mtImpegnati1.wrId = Convert.ToInt32(this.wrId);
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
