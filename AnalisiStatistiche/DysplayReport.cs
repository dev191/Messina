// Decompiled with JetBrains decompiler
// Type: TheSite.AnalisiStatistiche.DysplayReport
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI;
using TheSite.Classi.AnalisiStatistiche;
using TheSite.SchemiXSD;

namespace TheSite.AnalisiStatistiche
{
  public class DysplayReport : Page
  {
    private string sDataPkInit;
    private string sDataPkEnd;
    private string s_OptBtnDataRichiesta;
    private string s_OptBtnDataAssegnazione;
    private string s_OptBtnDataChiusura;
    private string s_OptBtnRdlDitta;
    private string s_OptBtnRdlDittaMesi;
    private string s_OptBtnRdlMese;
    private string s_OptBtnRdlServizio;
    private string s_OptBtnRdlServizioMesi;
    private string s_OptBtnRdlStato;
    private int i_Tipologia;
    protected CrystalReportViewer rptEngineOra;
    private StoredProdRpt _get_NPrcd_Rpt = new StoredProdRpt();
    private string s_AspPgReq;
    private string tipoDocumento;
    private ReportDocument crReportDocument;
    private ExportOptions crExportOptions;
    private DiskFileDestinationOptions crDiskFileDestinationOptions;

    private void Page_Load(object sender, EventArgs e)
    {
      this.s_AspPgReq = this.Request["tipologia"].ToString();
      if (this.s_AspPgReq == Convert.ToString(1))
        this.i_Tipologia = 1;
      else if (this.s_AspPgReq == Convert.ToString(2))
        this.i_Tipologia = 2;
      else if (this.s_AspPgReq == Convert.ToString(3))
      {
        this.i_Tipologia = 3;
      }
      else
      {
        if (!(this.s_AspPgReq == Convert.ToString(4)))
          throw new Exception("*Andrea: Pagina di richiesta non riconosciuta");
        this.i_Tipologia = 4;
      }
      if (this.i_Tipologia == 1 || this.i_Tipologia == 3 || this.i_Tipologia == 4)
      {
        this.s_OptBtnDataRichiesta = this.Request["S_OptBtnDataRichiesta"];
      }
      else
      {
        if (this.i_Tipologia != 2)
          throw new Exception("*Andrea: La pagina di richiesta non può essere impostata");
        this.s_OptBtnDataRichiesta = "False";
      }
      this.sDataPkInit = this.Request["DataPkInit"];
      this.sDataPkEnd = this.Request["DataPkEnd"];
      this.s_OptBtnDataAssegnazione = this.Request["S_OptBtnDataAssegnazione"];
      this.s_OptBtnDataChiusura = this.Request["S_OptBtnDataChiusura"];
      this.s_OptBtnRdlDitta = this.Request["S_OptBtnRdlDitta"];
      this.s_OptBtnRdlDittaMesi = this.Request["S_OptBtnRdlDittaMesi"];
      this.s_OptBtnRdlMese = this.Request["S_OptBtnRdlMese"];
      this.s_OptBtnRdlServizio = this.Request["S_OptBtnRdlServizio"];
      this.s_OptBtnRdlServizioMesi = this.Request["S_OptBtnRdlServizioMesi"];
      this.s_OptBtnRdlStato = this.Request["S_OptBtnRdlStato"];
      this.tipoDocumento = this.Request["tipoDocumento"];
      this.ImpostaRpt();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      this.crReportDocument = new ReportDocument();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    private void ImpostaRpt()
    {
      DsAnalisiStatistiche ds = new DsAnalisiStatistiche();
      this.bindReport(this.i_Tipologia != 4 ? (DataSet) this.recuperaDataSet(ds, this.i_Tipologia) : (DataSet) this.recuperaDataSet(ds, 4));
    }

    private void bindReport(DataSet dsRpt)
    {
      string rptRepostory = this.Server.MapPath(this.Request.ApplicationPath + ConfigurationSettings.AppSettings["SourceReports"]);
      this._get_NPrcd_Rpt.ImpostaSourceReport(this.crReportDocument, rptRepostory);
      this.crReportDocument.SetDataSource((object) dsRpt);
      switch (this.tipoDocumento)
      {
        case "PDF":
          string str = rptRepostory + this.Session.SessionID.ToString() + ".pdf";
          this.crDiskFileDestinationOptions = new DiskFileDestinationOptions();
          this.crDiskFileDestinationOptions.set_DiskFileName(str);
          this.crExportOptions = this.crReportDocument.get_ExportOptions();
          this.crExportOptions.set_DestinationOptions((object) this.crDiskFileDestinationOptions);
          this.crExportOptions.set_ExportDestinationType((ExportDestinationType) 1);
          this.crExportOptions.set_ExportFormatType((ExportFormatType) 5);
          this.crReportDocument.Export();
          this.Response.ClearContent();
          this.Response.ClearHeaders();
          this.Response.ContentType = "application/pdf";
          this.Response.WriteFile(str);
          this.Response.Flush();
          this.Response.Close();
          File.Delete(str);
          break;
        case "HTML":
          ((CrystalReportViewerBase) this.rptEngineOra).set_ReportSource((object) this.crReportDocument);
          break;
      }
    }

    private DsAnalisiStatistiche recuperaDataSet(
      DsAnalisiStatistiche ds,
      int tipologiaManutenzione)
    {
      try
      {
        wrapDb wrapDb = new wrapDb();
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("S_DATA_INIT");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Size(10);
        ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject1).set_Value((object) this.sDataPkInit);
        CollezioneControlli.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("S_DATA_END");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Size(10);
        ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject2).set_Value((object) this.sDataPkEnd);
        CollezioneControlli.Add(sObject2);
        S_Object sObject3 = new S_Object();
        ((ParameterObject) sObject3).set_ParameterName("S_TIPOLOGIA");
        ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject3).set_Size(10);
        ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject3).set_Value((object) tipologiaManutenzione);
        CollezioneControlli.Add(sObject3);
        S_Object sObject4 = new S_Object();
        ((ParameterObject) sObject4).set_ParameterName("S_PROGETTO");
        ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
        string s = "";
        if (this.Request["VarApp"] != null)
          s = this.Request["VarApp"];
        if (s == "")
          ((ParameterObject) sObject4).set_Value((object) 0);
        else
          ((ParameterObject) sObject4).set_Value((object) int.Parse(s));
        CollezioneControlli.Add(sObject4);
        S_Object sObject5 = new S_Object();
        ((ParameterObject) sObject5).set_ParameterName("IO_CURSOR");
        ((ParameterObject) sObject5).set_DbType((CustomDBType) 8);
        ((ParameterObject) sObject5).set_Direction(ParameterDirection.Output);
        ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count + 2);
        CollezioneControlli.Add(sObject5);
        wrapDb.s_storedProcedureName = this.GetNomeStrPrd();
        DataSet dataSet = wrapDb.GetData(CollezioneControlli).Copy();
        int index;
        for (index = 0; index <= dataSet.Tables[0].Rows.Count - 1; ++index)
          ds.Tables[0].ImportRow(dataSet.Tables[0].Rows[index]);
        if (index == 0)
          throw new Exception("* Non ci sono Rdl nell'intervallo temporale che hai selezionato, cambia intervallo e riprova.");
        return ds;
      }
      catch (Exception ex)
      {
        this.Server.Transfer("Error.aspx?msgErr=" + ex.Message);
        return (DsAnalisiStatistiche) null;
      }
    }

    private string GetNomeStrPrd()
    {
      try
      {
        this._get_NPrcd_Rpt.s_OptBtnDataRichiesta = this.s_OptBtnDataRichiesta;
        this._get_NPrcd_Rpt.s_OptBtnDataAssegnazione = this.s_OptBtnDataAssegnazione;
        this._get_NPrcd_Rpt.s_OptBtnDataChiusura = this.s_OptBtnDataChiusura;
        this._get_NPrcd_Rpt.s_OptBtnRdlMese = this.s_OptBtnRdlMese;
        this._get_NPrcd_Rpt.s_OptBtnRdlServizioMesi = this.s_OptBtnRdlServizioMesi;
        this._get_NPrcd_Rpt.s_OptBtnRdlStato = this.s_OptBtnRdlStato;
        this._get_NPrcd_Rpt.s_OptBtnRdlDitta = this.s_OptBtnRdlDitta;
        this._get_NPrcd_Rpt.s_OptBtnRdlDittaMesi = this.s_OptBtnRdlDittaMesi;
        this._get_NPrcd_Rpt.s_OptBtnRdlServizio = this.s_OptBtnRdlServizio;
        return this._get_NPrcd_Rpt.NameStoredProcedure;
      }
      catch (Exception ex)
      {
        this.Server.Transfer("Error.aspx?msgErr=" + ex.Message + " *Andrea: Durante la fase di recupero del nome della procedura");
        return (string) null;
      }
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
