// Decompiled with JetBrains decompiler
// Type: TheSite.AnalisiStatistiche.GraficiMor
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
  public class GraficiMor : Page
  {
    protected CalendarPicker DataPkEnd;
    protected PageTitle PageTitleReport;
    protected DataPanel DataPanelRicerca;
    protected CalendarPicker DataPkInit;
    protected S_OptionButton S_OptBtnDataRichiesta;
    protected S_OptionButton S_OptBtnDataAssegnazione;
    protected S_OptionButton S_OptBtnDataChiusura;
    protected S_OptionButton S_OptBtnRdlMese;
    protected S_OptionButton S_OptBtnRdlServizioMesi;
    protected S_OptionButton S_OptBtnRdlStato;
    protected S_OptionButton S_OptBtnRdlDitta;
    protected S_OptionButton S_OptBtnRdlDittaMesi;
    protected S_OptionButton S_OptBtnRdlServizio;
    protected S_Button S_BtnSubmit;
    protected string VarDataInit;
    protected string VarDataEnd;
    protected string urlRpt;
    protected int status;
    protected CompareValidator ValidatorDataInit;
    protected ValidationSummary ValidationSummary1;
    protected S_OptionButton S_optBtnRdlDispersioneRA;
    protected S_OptionButton S_optBtnRdlDispersioneAC;
    protected S_OptionButton S_optBtnRdlDispersioneRC;
    protected Label lblTipologiaIntervento;
    protected DropDownList cmbTipologiaIntervento;
    protected Button btnReportPdf;
    protected CompareValidator ValidatorDataEnd;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      GraficiMor.HelpLink = ((SiteModule) HttpContext.Current.Items[(object) "SiteModule"]).HelpLink;
      this.ValidatorDataInit.ControlToValidate = this.DataPkInit.ID + ":" + ((Control) this.DataPkInit.Datazione).ID;
      this.ValidatorDataInit.ControlToCompare = this.DataPkEnd.ID + ":" + ((Control) this.DataPkEnd.Datazione).ID;
      this.ValidatorDataEnd.ControlToValidate = this.DataPkEnd.ID + ":" + ((Control) this.DataPkEnd.Datazione).ID;
      this.ValidatorDataEnd.ControlToCompare = this.DataPkInit.ID + ":" + ((Control) this.DataPkInit.Datazione).ID;
      if (this.IsPostBack)
        this.status = 1;
      this.PageTitleReport.Title = "Reports Manutenzione Correttiva";
      if (this.IsPostBack)
        return;
      this.caricaComboTipoServizio();
      this.urlRpt = "about:blank";
      this.status = 0;
      this.VarDataInit = "01/01/" + DateTime.Today.ToString().Substring(6, 4);
      this.VarDataEnd = DateTime.Today.ToString().Substring(0, 10);
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

    private void caricaComboTipoServizio()
    {
      ListItem listItem1 = new ListItem("Manutenzione a Canone", Convert.ToString(1));
      ListItem listItem2 = new ListItem("Manutenzione Straordinaria", Convert.ToString(3));
      ListItem listItem3 = new ListItem("Entrambe le Tipologie", Convert.ToString(4));
      this.cmbTipologiaIntervento.Items.Add(listItem1);
      this.cmbTipologiaIntervento.Items.Add(listItem2);
      this.cmbTipologiaIntervento.Items.Add(listItem3);
    }

    private void S_BtnSubmit_Click(object sender, EventArgs e) => this.DisplayReport();

    private string queryString()
    {
      GenetoreQryStr genetoreQryStr = new GenetoreQryStr();
      genetoreQryStr.Add((object) ((TextBox) this.DataPkInit.Datazione).Text, "DataPkInit");
      genetoreQryStr.Add((object) ((TextBox) this.DataPkEnd.Datazione).Text, "DataPkEnd");
      genetoreQryStr.Add((object) ((CheckBox) this.S_OptBtnDataAssegnazione).Checked, "S_OptBtnDataAssegnazione");
      genetoreQryStr.Add((object) ((CheckBox) this.S_OptBtnDataChiusura).Checked, "S_OptBtnDataChiusura");
      genetoreQryStr.Add((object) ((CheckBox) this.S_OptBtnDataRichiesta).Checked, "S_OptBtnDataRichiesta");
      genetoreQryStr.Add((object) ((CheckBox) this.S_OptBtnRdlDitta).Checked, "S_OptBtnRdlDitta");
      genetoreQryStr.Add((object) ((CheckBox) this.S_OptBtnRdlDittaMesi).Checked, "S_OptBtnRdlDittaMesi");
      genetoreQryStr.Add((object) ((CheckBox) this.S_OptBtnRdlMese).Checked, "S_OptBtnRdlMese");
      genetoreQryStr.Add((object) ((CheckBox) this.S_OptBtnRdlServizio).Checked, "S_OptBtnRdlServizio");
      genetoreQryStr.Add((object) ((CheckBox) this.S_OptBtnRdlServizioMesi).Checked, "S_OptBtnRdlServizioMesi");
      genetoreQryStr.Add((object) ((CheckBox) this.S_OptBtnRdlStato).Checked, "S_OptBtnRdlStato");
      genetoreQryStr.Add((object) this.cmbTipologiaIntervento.SelectedItem.Value, "tipologia");
      return genetoreQryStr.TotQueryString().ToString();
    }

    private void DisplayReport()
    {
      this.DataPanelRicerca.set_Collapsed(true);
      string str = "";
      if (this.Request["VarApp"] != null)
        str = "&VarApp=" + this.Request["VarApp"];
      this.urlRpt = "DisplayReport.aspx" + this.queryString() + "tipoDocumento=HTML" + str;
    }

    private void btnReportPdf_Click(object sender, EventArgs e)
    {
      string str1 = this.queryString();
      string str2 = "";
      if (this.Request["VarApp"] != null)
        str2 = "&VarApp=" + this.Request["VarApp"];
      this.Server.Transfer("DisplayReport.aspx" + str1 + "tipoDocumento=PDF" + str2);
    }

    private enum ValidateDate
    {
      notPostBack,
      PostBack,
    }

    private enum TipoM
    {
      Richiesta = 1,
      Programmata = 2,
      Straordinaria = 3,
      Entrambe = 4,
    }
  }
}
