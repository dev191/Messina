// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorrettiva.VisualizzaGestioneMaterialiPdf
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Configuration;
using System.IO;
using System.Web.UI;
using TheSite.Classi.ManCorrettiva;
using TheSite.SchemiXSD;

namespace TheSite.ManutenzioneCorrettiva
{
  public class VisualizzaGestioneMaterialiPdf : Page
  {
    protected ReportDocument crReportDocument;
    private ExportOptions crExportOptions;
    private DiskFileDestinationOptions crDiskFileDestinationOptions;

    private void Page_Load(object sender, EventArgs e)
    {
      int WrId = 0;
      string DataIniziale = "";
      string DataFinale = "";
      if (this.Request.QueryString["RDL"].ToString() != "")
        WrId = Convert.ToInt32(this.Request.QueryString["RDL"].ToString());
      int int32_1 = Convert.ToInt32(this.Request.QueryString["idMat"].ToString());
      if (this.Request.QueryString["DataDA"].ToString() != "")
        DataIniziale = this.Request.QueryString["DataDA"].ToString();
      if (this.Request.QueryString["DataA"].ToString() != "")
        DataFinale = this.Request.QueryString["DataA"].ToString();
      int int32_2 = Convert.ToInt32(this.Request.QueryString["Stato"].ToString());
      this.GeneraRptPdf(WrId, int32_1, DataIniziale, DataFinale, int32_2);
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      this.crReportDocument = new ReportDocument();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    private void GeneraRptPdf(
      int WrId,
      int IdMateriale,
      string DataIniziale,
      string DataFinale,
      int Stato)
    {
      GestioneMateriali tipizzato = new MaterialiWrDb(WrId, IdMateriale, Stato, DataIniziale, DataFinale).GetTipizzato();
      string str1 = this.Server.MapPath(this.Request.ApplicationPath + ConfigurationSettings.AppSettings["SourceReports"]);
      this.crReportDocument.Load(str1 + "RptGestioneMateriali_V9.rpt");
      this.crReportDocument.SetDataSource((object) tipizzato);
      string str2 = str1 + this.Session.SessionID.ToString() + ".pdf";
      this.crDiskFileDestinationOptions = new DiskFileDestinationOptions();
      this.crDiskFileDestinationOptions.set_DiskFileName(str2);
      this.crExportOptions = this.crReportDocument.get_ExportOptions();
      this.crExportOptions.set_DestinationOptions((object) this.crDiskFileDestinationOptions);
      this.crExportOptions.set_ExportDestinationType((ExportDestinationType) 1);
      this.crExportOptions.set_ExportFormatType((ExportFormatType) 5);
      this.crReportDocument.Export();
      this.Response.ClearContent();
      this.Response.ClearHeaders();
      this.Response.ContentType = "application/pdf";
      this.Response.WriteFile(str2);
      this.Response.Flush();
      this.Response.Close();
      File.Delete(str2);
    }
  }
}
