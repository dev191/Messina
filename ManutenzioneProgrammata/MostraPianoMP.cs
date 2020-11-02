// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.MostraPianoMP
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.Web.UI;
using TheSite.SchemiXSD;

namespace TheSite.ManutenzioneProgrammata
{
  public class MostraPianoMP : Page
  {
    protected CrystalReportViewer crlRptPianoMp;
    protected ReportDocument crReportDocument;
    private ExportOptions crExportOptions;
    private DiskFileDestinationOptions crDiskFileDestinationOptions;

    private void Page_Load(object sender, EventArgs e) => this.InpostaReport();

    private void InpostaReport()
    {
      DsPianoMp dsPianoMp = new DsPianoMp();
      OracleCommand selectCommand = new OracleCommand("PACK_RPT_PIANO_MAN_PROG.GetMainData", new OracleConnection(this.CnStr));
      selectCommand.CommandType = CommandType.StoredProcedure;
      OracleParameter oracleParameter1 = new OracleParameter("pAnno", OracleType.Int32);
      oracleParameter1.Direction = ParameterDirection.Input;
      oracleParameter1.Size = 32;
      oracleParameter1.Value = (object) this.Anno;
      selectCommand.Parameters.Add(oracleParameter1);
      OracleParameter oracleParameter2 = new OracleParameter("pMese", OracleType.Int32);
      oracleParameter2.Direction = ParameterDirection.Input;
      oracleParameter2.Size = 32;
      oracleParameter2.Value = (object) this.Mese;
      selectCommand.Parameters.Add(oracleParameter2);
      OracleParameter oracleParameter3 = new OracleParameter("pIdBl", OracleType.Int32);
      oracleParameter3.Direction = ParameterDirection.Input;
      oracleParameter3.Size = 32;
      oracleParameter3.Value = (object) this.IdEdificio;
      selectCommand.Parameters.Add(oracleParameter3);
      OracleParameter oracleParameter4 = new OracleParameter("pIdServizio", OracleType.Int32);
      oracleParameter4.Direction = ParameterDirection.Input;
      oracleParameter4.Size = 32;
      oracleParameter4.Value = (object) this.IdServizio;
      selectCommand.Parameters.Add(oracleParameter4);
      OracleParameter oracleParameter5 = new OracleParameter("IdClasseElemento", OracleType.Int32);
      oracleParameter5.Direction = ParameterDirection.Input;
      oracleParameter5.Size = 32;
      oracleParameter5.Value = (object) this.IdEqstd;
      selectCommand.Parameters.Add(oracleParameter5);
      selectCommand.Parameters.Add(new OracleParameter("pCursor", OracleType.Cursor)
      {
        Direction = ParameterDirection.Output
      });
      OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(selectCommand);
      oracleDataAdapter.Fill((DataSet) dsPianoMp, "TblMain");
      if (dsPianoMp.TblMain.Rows.Count <= 0)
        this.Server.Transfer("MostraMessaggi.aspx" + ("?Anno=" + (object) this.Anno + "&Mese=" + (object) this.Mese + "&ID_EDIFICIO=" + (object) this.IdEdificio + "&ID_SERVIZIO=" + (object) this.IdServizio + "&ID_EQSTD=" + (object) this.IdEqstd));
      selectCommand.Parameters.Remove((object) oracleParameter1);
      selectCommand.Parameters.Remove((object) oracleParameter2);
      selectCommand.Parameters.Remove((object) oracleParameter3);
      selectCommand.Parameters.Remove((object) oracleParameter4);
      selectCommand.Parameters.Remove((object) oracleParameter5);
      selectCommand.CommandText = "PACK_RPT_PIANO_MAN_PROG.GetPassi";
      oracleDataAdapter.Fill((DataSet) dsPianoMp, "TblPassi");
      string str1 = this.Server.MapPath(this.Request.ApplicationPath + ConfigurationSettings.AppSettings["SourceReports"]);
      this.crReportDocument.Load(str1 + "RptPianoMp.rpt");
      this.crReportDocument.SetDataSource((object) dsPianoMp);
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

    internal int Anno => Convert.ToInt32(this.Request[nameof (Anno)]);

    internal int Mese => Convert.ToInt32(this.Request[nameof (Mese)]);

    internal int IdEdificio => Convert.ToInt32(this.Request["ID_EDIFICIO"]);

    internal int IdServizio => Convert.ToInt32(this.Request["ID_SERVIZIO"]);

    internal int IdEqstd => Convert.ToInt32(this.Request["ID_EQSTD"]);

    internal string CnStr => ConfigurationSettings.AppSettings["ConnectionString"];

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.crReportDocument = new ReportDocument();
      this.crReportDocument.get_PrintOptions().set_PaperOrientation((PaperOrientation) 0);
      this.crReportDocument.get_PrintOptions().set_PaperSize((PaperSize) 0);
      this.crReportDocument.get_PrintOptions().set_PaperSource((PaperSource) 1);
      this.crReportDocument.get_PrintOptions().set_PrinterDuplex((PrinterDuplex) 0);
      this.Load += new EventHandler(this.Page_Load);
    }
  }
}
