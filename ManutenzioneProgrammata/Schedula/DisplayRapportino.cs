// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.Schedula.DisplayRapportino
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using S_Controls.Collections;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi.ManProgrammata;
using TheSite.Report;
using TheSite.SchemiXSD;

namespace TheSite.ManutenzioneProgrammata.Schedula
{
  public class DisplayRapportino : Page
  {
    protected CrystalReportViewer CRView;
    protected string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];
    protected TextBox txtHid;
    protected TextBox txtTipo;
    private ReportDocument crReportDocument;
    protected DataGrid DataGrid1;
    protected DataGrid DataGrid2;
    protected DataGrid DataGrid3;
    protected DataGrid DataGrid4;
    protected DataGrid DataGrid5;
    protected string Ordini;

    private void Page_Load(object sender, EventArgs e)
    {
      if (!this.Page.IsPostBack)
      {
        this.txtHid.Text = this.Request.QueryString["ODL"];
        this.txtTipo.Text = this.Request.QueryString["Display"];
      }
      this.DisplayReport();
    }

    private void DisplayReport()
    {
      if (this.txtTipo.Text == "DL" || this.txtTipo.Text == "DC" || this.txtTipo.Text == "DL2P")
        this.GeneraReport(this.txtHid.Text, this.txtTipo.Text);
      else
        this.Visualizza();
    }

    private void Visualizza()
    {
      this.Ordini = this.txtHid.Text;
      string str1 = "select * from mp_report_long where WO_ID in (" + this.Ordini + ")";
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_sql");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(2000);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) str1);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str2 = "PACK_COMMON.SP_DYNAMIC_SELECT";
      DataSet dataSet = oracleDataLayer.GetRows((object) controlsCollection, str2).Copy();
      if (this.txtTipo.Text == "S")
      {
        Report_Short reportShort = new Report_Short();
        ((ReportDocument) reportShort).SetDataSource((object) dataSet);
        ((CrystalReportViewerBase) this.CRView).set_ReportSource((object) reportShort);
      }
      else
      {
        Report_Long reportLong = new Report_Long();
        ((ReportDocument) reportLong).SetDataSource((object) dataSet);
        ((CrystalReportViewerBase) this.CRView).set_ReportSource((object) reportLong);
      }
    }

    private void GeneraReport(string StringaOdl, string TipoReport)
    {
      RptMpDataDinamic rptMpDataDinamic = new RptMpDataDinamic();
      DsRptMpLocali dsRptMpLocali = new DsRptMpLocali();
      DsRptMpLocali dataRpt = rptMpDataDinamic.GetDataRpt(StringaOdl);
      string str = this.Server.MapPath(this.Request.ApplicationPath + ConfigurationSettings.AppSettings["SourceReports"]);
      switch (TipoReport)
      {
        case "DL":
          this.crReportDocument.Load(str + "RptMpDettagliLocaliLungoDinamico.rpt");
          break;
        case "DC":
          this.crReportDocument.Load(str + "RptMpDettagliLocaliCortoDinamico.rpt");
          break;
        case "DL2P":
          this.crReportDocument.Load(str + "RptMpDettagliLocaliLungo2P.rpt");
          break;
        default:
          throw new Exception();
      }
      this.crReportDocument.SetDataSource((object) dataRpt);
      ((CrystalReportViewerBase) this.CRView).set_ReportSource((object) this.crReportDocument);
      ((Control) this.CRView).DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      this.crReportDocument = new ReportDocument();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    private void DataGrid3_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
  }
}
