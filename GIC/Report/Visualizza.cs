// Decompiled with JetBrains decompiler
// Type: GIC.Report.Visualizza
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using GIC.Report.UserControl;
using System;
using System.Web.UI;

namespace GIC.Report
{
  public class Visualizza : Page
  {
    protected ConsultazioniDataGrid ConsultazioniDataGrid1;

    private void Page_Load(object sender, EventArgs e)
    {
      this.ConsultazioniDataGrid1.IdQuery = Convert.ToInt32(this.Request.QueryString["idquery"]);
      this.ConsultazioniDataGrid1.DysplayGrid();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
