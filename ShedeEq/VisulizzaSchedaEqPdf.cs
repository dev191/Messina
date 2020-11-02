// Decompiled with JetBrains decompiler
// Type: TheSite.ShedeEq.VisulizzaSchedaEqPdf
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI;
using TheSite.Classi.SchedeEq;
using TheSite.SchemiXSD;

namespace TheSite.ShedeEq
{
  public class VisulizzaSchedaEqPdf : Page
  {
    protected ReportDocument crReportDocument;
    private ExportOptions crExportOptions;
    private DiskFileDestinationOptions crDiskFileDestinationOptions;

    private void Page_Load(object sender, EventArgs e) => this.GeneraRptPdf();

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      this.crReportDocument = new ReportDocument();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    private void GeneraRptPdf()
    {
      NewDataSet dsTipizzato = new DatiShcedeEq(this.recuperaEqId()).GetDsTipizzato();
      foreach (DataRow row in (InternalDataCollectionBase) dsTipizzato.Tables["TblGenerale"].Rows)
        row["EQ_IMMAGINI_IMMAGINE"] = row["EQ_IMAGE_EQ_ASSY"] == DBNull.Value ? (object) this.GetPhoto("ImmagineNonDisponibile.jpg") : (!this.ControllaFoto(row["EQ_IMAGE_EQ_ASSY"].ToString()) ? (object) this.GetPhoto("ImmagineNonDisponibile.jpg") : (object) this.GetPhoto(row["EQ_IMAGE_EQ_ASSY"].ToString()));
      string str1 = this.Server.MapPath(this.Request.ApplicationPath + ConfigurationSettings.AppSettings["SourceReports"]);
      this.crReportDocument.Load(str1 + "RptChedeEq_V9.rpt");
      this.crReportDocument.SetDataSource((object) dsTipizzato);
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

    private bool ControllaFoto(string NomePhoto) => File.Exists(this.Server.MapPath("../EQImages/" + NomePhoto));

    private byte[] GetPhoto(string fileName)
    {
      string path = this.Server.MapPath(this.Request.ApplicationPath + ConfigurationSettings.AppSettings["ImmaginiEq"] + fileName);
      if (!File.Exists(path))
        return new byte[1];
      FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
      BinaryReader binaryReader = new BinaryReader((Stream) fileStream);
      byte[] numArray = binaryReader.ReadBytes((int) fileStream.Length);
      binaryReader.Close();
      fileStream.Close();
      return numArray;
    }

    private string recuperaEqId()
    {
      string str = string.Empty;
      if (this.Session["DatiList"] != null)
      {
        IDictionaryEnumerator enumerator = ((Hashtable) this.Session["DatiList"]).GetEnumerator();
        while (enumerator.MoveNext())
          str = str + enumerator.Value + ",";
        str = str.Remove(str.Length - 1, 1);
      }
      else
      {
        this.Response.Write("Sessione Vuota");
        this.Response.End();
      }
      return str;
    }
  }
}
