// Decompiled with JetBrains decompiler
// Type: StampaRapportiPdf.WebControls.GridTitle
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StampaRapportiPdf.WebControls
{
  public class GridTitle : UserControl
  {
    protected Label lblRecord;
    public S_HyperLink hplsNuovo;
    private string s_NumRecords;
    protected S_Label lblDescrRecord;
    protected S_Label lblTitleDescription;
    private string s_NuovoUrl;

    private void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    public string NumeroRecords
    {
      get => this.s_NumRecords;
      set
      {
        this.s_NumRecords = value;
        this.lblRecord.Text = this.s_NumRecords;
      }
    }

    public string DescriptionTitle
    {
      get => ((Label) this.lblTitleDescription).Text;
      set => ((Label) this.lblTitleDescription).Text = value;
    }

    public string NuovoUrl
    {
      get => this.s_NuovoUrl;
      set
      {
        this.s_NuovoUrl = value;
        ((HyperLink) this.hplsNuovo).NavigateUrl = this.s_NuovoUrl;
      }
    }

    public bool VisibleRecord
    {
      get => this.lblRecord.Visible;
      set
      {
        ((Control) this.lblDescrRecord).Visible = value;
        this.lblRecord.Visible = value;
      }
    }
  }
}
