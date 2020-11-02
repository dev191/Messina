// Decompiled with JetBrains decompiler
// Type: GIC.Report.ModificaCampo
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using GIC.App_Code;
using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GIC.Report
{
  public class ModificaCampo : BasePage
  {
    protected ListBox ListBox1;
    protected HtmlSelect operatore;
    protected HtmlInputText valore1;
    protected HtmlInputText valore2;
    protected HtmlSelect LstCampi;
    protected string IdQuery;
    protected string IdCampo;

    private void Page_Load(object sender, EventArgs e)
    {
      this.IdQuery = this.Request.QueryString["idquery"];
      this.IdCampo = this.Request.QueryString["idcampo"];
      this.ListBox1.Attributes.Add("ondblclick", "eliminaFiltro(this);");
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
