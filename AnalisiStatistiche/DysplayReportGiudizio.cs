// Decompiled with JetBrains decompiler
// Type: TheSite.AnalisiStatistiche.DysplayReportGiudizio
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
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI;
using TheSite.Classi.AnalisiStatistiche;
using TheSite.SchemiXSD;

namespace TheSite.AnalisiStatistiche
{
  public class DysplayReportGiudizio : Page
  {
    protected CrystalReportViewer rptEngineOra;
    private ReportDocument crReportDocument;
    private ExportOptions crExportOptions;
    private DiskFileDestinationOptions crDiskFileDestinationOptions;
    private string s_DataPkInit;
    private string s_DataPkEnd;
    private string s_optbtnGiudizio;
    private string s_optbtnGiudizioTipologia;
    private string s_optbtnGiudizioMesi;
    private string s_cmbServizio;
    private string tipoDocumento;
    private Recupera_SPRpt_ReportGiudizio _stdRpt = new Recupera_SPRpt_ReportGiudizio();

    private void Page_Load(object sender, EventArgs e)
    {
      this.s_DataPkInit = this.Request["DataPkInit"];
      this.s_DataPkEnd = this.Request["DataPkEnd"];
      this.s_optbtnGiudizio = this.Request["S_optbtnGiudizio"];
      this.s_optbtnGiudizioTipologia = this.Request["S_optbtnGiudizioTipologia"];
      this.s_optbtnGiudizioMesi = this.Request["S_optbtnGiudizioMesi"];
      this.s_cmbServizio = this.Request["cmbServizio"];
      this.tipoDocumento = this.Request["tipoDocumento"];
      this.IpostaRpt();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      this.crReportDocument = new ReportDocument();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    private void IpostaRpt()
    {
      wrapDb wrapDb = new wrapDb();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      int num1 = 0;
      try
      {
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_date_init");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Size(10);
        S_Object sObject2 = sObject1;
        int num2 = num1;
        int num3 = num2 + 1;
        ((ParameterObject) sObject2).set_Index(num2);
        ((ParameterObject) sObject1).set_Value((object) this.s_DataPkInit);
        CollezioneControlli.Add(sObject1);
        S_Object sObject3 = new S_Object();
        ((ParameterObject) sObject3).set_ParameterName("p_date_out");
        ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject3).set_Size(10);
        S_Object sObject4 = sObject3;
        int num4 = num3;
        int num5 = num4 + 1;
        ((ParameterObject) sObject4).set_Index(num4);
        ((ParameterObject) sObject3).set_Value((object) this.s_DataPkEnd);
        CollezioneControlli.Add(sObject3);
        S_Object sObject5 = new S_Object();
        ((ParameterObject) sObject5).set_ParameterName("p_idservizio");
        ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject5).set_Size(10);
        S_Object sObject6 = sObject5;
        int num6 = num5;
        int num7 = num6 + 1;
        ((ParameterObject) sObject6).set_Index(num6);
        ((ParameterObject) sObject5).set_Value((object) Convert.ToInt32(this.s_cmbServizio));
        CollezioneControlli.Add(sObject5);
        S_Object sObject7 = new S_Object();
        ((ParameterObject) sObject7).set_ParameterName("io_cursor");
        ((ParameterObject) sObject7).set_DbType((CustomDBType) 8);
        ((ParameterObject) sObject7).set_Direction(ParameterDirection.Output);
        S_Object sObject8 = sObject7;
        int num8 = num7;
        int num9 = num8 + 1;
        ((ParameterObject) sObject8).set_Index(num8);
        CollezioneControlli.Add(sObject7);
      }
      catch (Exception ex)
      {
        this.Server.Transfer("Error.aspx?msgErr=" + ex.Message + " *Andrea: Nella sezione dell passagio degli S_control al datalayer");
      }
      try
      {
        wrapDb.s_storedProcedureName = this.GetNomeStrPrd();
        this.bindReport(wrapDb.GetData(CollezioneControlli).Copy());
      }
      catch (Exception ex)
      {
        this.Server.Transfer("Error.aspx?msgErr=" + ex.Message + " *Andrea: Durante ilrecupero del dataset dal datalayer");
      }
    }

    private void bindReport(DataSet _dsRpt)
    {
      try
      {
        DsAnalisiStatistiche analisiStatistiche = new DsAnalisiStatistiche();
        int index;
        for (index = 0; index <= _dsRpt.Tables[0].Rows.Count - 1; ++index)
          analisiStatistiche.Tables["tblgiudizio"].ImportRow(_dsRpt.Tables[0].Rows[index]);
        if (index == 0)
          throw new Exception("* Non ci sono Rdl nell'intervallo temporale che hai selezionato, cambia intervallo e riprova.");
        string rptRepostory = this.Server.MapPath(this.Request.ApplicationPath + ConfigurationSettings.AppSettings["SourceReports"]);
        this._stdRpt.ImpostaSourceReport(this.crReportDocument, rptRepostory);
        this.crReportDocument.SetDataSource((object) analisiStatistiche);
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
      catch (Exception ex)
      {
        this.Server.Transfer("Error.aspx?msgErr=" + ex.Message);
      }
    }

    private string GetNomeStrPrd()
    {
      try
      {
        this._stdRpt.s_optbtnGiudizio = this.s_optbtnGiudizio;
        this._stdRpt.s_optbtnGiudizioMesi = this.s_optbtnGiudizioMesi;
        this._stdRpt.s_optbtnGiudizioTipologia = this.s_optbtnGiudizioTipologia;
        return this._stdRpt.NameStoredProcedure;
      }
      catch (Exception ex)
      {
        this.Server.Transfer("Error.aspx?msgErr=" + ex.Message + " *Andrea: Durante la fase di recupero del nome della procedura");
        return (string) null;
      }
    }
  }
}
