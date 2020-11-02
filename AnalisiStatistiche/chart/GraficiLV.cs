// Decompiled with JetBrains decompiler
// Type: TheSite.AnalisiStatistiche.chart.GraficiLV
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using S_Controls;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnalisiStatistiche;
using TheSite.WebControls;

namespace TheSite.AnalisiStatistiche.chart
{
  public class GraficiLV : Page
  {
    protected PageTitle PageTitleReport;
    protected DataPanel DataPanelRicerca;
    protected S_Button S_BtnSubmit;
    protected string urlRpt;
    protected int status;
    protected S_OptionButton S_optBtnRdlDispersioneRA;
    protected S_OptionButton S_optBtnRdlDispersioneAC;
    protected Label lblTipologiaLavori;
    protected DropDownList cmbTipologiaInitervento;
    protected S_OptionButton S_optBtnRdlDispersioneRC;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      GraficiLV.HelpLink = ((SiteModule) HttpContext.Current.Items[(object) "SiteModule"]).HelpLink;
      this.PageTitleReport.Title = "Grafici dei Livelli di Servizio";
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.S_BtnSubmit).Click += new EventHandler(this.S_BtnSubmit_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void S_BtnSubmit_Click(object sender, EventArgs e) => this.DysplayChart();

    private void DysplayChart()
    {
      GenetoreQryStr genetoreQryStr = new GenetoreQryStr();
      genetoreQryStr.Add((object) ((CheckBox) this.S_optBtnRdlDispersioneAC).Checked, "S_optBtnRdlDispersioneAC");
      genetoreQryStr.Add((object) ((CheckBox) this.S_optBtnRdlDispersioneRA).Checked, "S_optBtnRdlDispersioneRA");
      genetoreQryStr.Add((object) ((CheckBox) this.S_optBtnRdlDispersioneRC).Checked, "S_optBtnRdlDispersioneRC");
      genetoreQryStr.Add((object) this.cmbTipologiaInitervento.SelectedValue, "tipologia");
      if (this.Request["VarApp"] != null)
        this.Session["VarApp"] = (object) this.Request["VarApp"];
      this.urlRpt = "./Chart.aspx" + genetoreQryStr.TotQueryString();
    }

    private enum ValidateDate
    {
      notPostBack,
      PostBack,
    }
  }
}
