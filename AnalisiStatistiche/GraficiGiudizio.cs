// Decompiled with JetBrains decompiler
// Type: TheSite.AnalisiStatistiche.GraficiGiudizio
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

namespace TheSite.AnalisiStatistiche
{
  public class GraficiGiudizio : Page
  {
    protected PageTitle PageTitleReport;
    protected DataPanel DataPanelRicerca;
    protected S_Button S_BtnSubmit;
    protected string VarDataInit;
    protected string VarDataEnd;
    protected string urlRpt;
    protected int status;
    protected CalendarPicker DataPkEnd;
    protected CalendarPicker DataPkInit;
    protected CompareValidator ValidatorDataInit;
    protected ValidationSummary ValidationSummary1;
    protected Label lblServizio;
    protected DropDownList cmbServizio;
    protected S_OptionButton S_optbtnGiudizio;
    protected S_OptionButton S_optbtnGiudizioTipologia;
    protected S_OptionButton S_optbtnGiudizioMesi;
    protected Button btnReportPdf;
    protected CompareValidator ValidatorDataEnd;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      GraficiGiudizio.HelpLink = ((SiteModule) HttpContext.Current.Items[(object) "SiteModule"]).HelpLink;
      this.ValidatorDataInit.ControlToValidate = this.DataPkInit.ID + ":" + ((Control) this.DataPkInit.Datazione).ID;
      this.ValidatorDataInit.ControlToCompare = this.DataPkEnd.ID + ":" + ((Control) this.DataPkEnd.Datazione).ID;
      this.ValidatorDataEnd.ControlToValidate = this.DataPkEnd.ID + ":" + ((Control) this.DataPkEnd.Datazione).ID;
      this.ValidatorDataEnd.ControlToCompare = this.DataPkInit.ID + ":" + ((Control) this.DataPkInit.Datazione).ID;
      if (this.IsPostBack)
        this.status = 1;
      this.PageTitleReport.Title = "Reports Giudizio Cliente";
      if (this.IsPostBack)
        return;
      new bindCombo("PACK_ANALISI_STATISTICHE.bind_servizi", this.cmbServizio, "System.Int32")
      {
        testoItemZero = "Tutti i Servizi"
      }.getComboBox();
      this.urlRpt = "about:blank";
      this.status = 0;
      DateTime today = DateTime.Today;
      this.VarDataInit = "01/01/" + today.ToString().Substring(6, 4);
      today = DateTime.Today;
      this.VarDataEnd = today.ToString().Substring(0, 10);
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.S_BtnSubmit).Click += new EventHandler(this.S_BtnSubmit_Click);
      this.btnReportPdf.Click += new EventHandler(this.btnReportPdf_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void S_BtnSubmit_Click(object sender, EventArgs e) => this.DisplayReport();

    private string queryString()
    {
      GenetoreQryStr genetoreQryStr = new GenetoreQryStr();
      genetoreQryStr.Add((object) ((TextBox) this.DataPkInit.Datazione).Text, "DataPkInit");
      genetoreQryStr.Add((object) ((TextBox) this.DataPkEnd.Datazione).Text, "DataPkEnd");
      genetoreQryStr.Add((object) ((CheckBox) this.S_optbtnGiudizio).Checked, "S_optbtnGiudizio");
      genetoreQryStr.Add((object) ((CheckBox) this.S_optbtnGiudizioTipologia).Checked, "S_optbtnGiudizioTipologia");
      genetoreQryStr.Add((object) ((CheckBox) this.S_optbtnGiudizioMesi).Checked, "S_optbtnGiudizioMesi");
      genetoreQryStr.Add((object) this.cmbServizio.SelectedValue, "cmbServizio");
      return genetoreQryStr.TotQueryString().ToString();
    }

    private void DisplayReport()
    {
      this.DataPanelRicerca.set_Collapsed(true);
      this.urlRpt = "DisplayReportGiudizio.aspx" + this.queryString() + "tipoDocumento=HTML";
    }

    private void btnReportPdf_Click(object sender, EventArgs e) => this.Server.Transfer("DisplayReportGiudizio.aspx" + this.queryString() + "tipoDocumento=PDF");

    private enum ValidateDate
    {
      notPostBack,
      PostBack,
    }
  }
}
