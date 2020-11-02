// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.GridTitleServer
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheSite.WebControls
{
  public class GridTitleServer : UserControl
  {
    public LinkButton hplsNuovo;
    public Label lblRecord;
    private string s_NumRecords;
    public NuovoRec NuovoRec1;

    private void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.hplsNuovo.Click += new EventHandler(this.hplsNuovo_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void hplsNuovo_Click(object sender, EventArgs e)
    {
      if (this.NuovoRec1 == null)
        return;
      this.NuovoRec1("");
    }

    public string NumeroRecords
    {
      get => this.s_NumRecords;
      set
      {
        this.s_NumRecords = value;
        this.lblRecord.Text = this.s_NumRecords;
      }
    }
  }
}
