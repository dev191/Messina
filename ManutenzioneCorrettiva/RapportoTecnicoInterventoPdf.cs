// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorrettiva.RapportoTecnicoInterventoPdf
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI;
using TheSite.Classi.ManCorrettiva;
using TheSite.Classi.ManOrdinaria;
using TheSite.SchemiXSD;

namespace TheSite.ManutenzioneCorrettiva
{
  public class RapportoTecnicoInterventoPdf : Page
  {
    private string pathRptSource;
    private ReportDocument crReportDocument;
    private ExportOptions crExportOptions;
    protected CrystalReportViewer CrystalReportViewer1;
    private DiskFileDestinationOptions crDiskFileDestinationOptions;

    private void Page_Load(object sender, EventArgs e) => this.IpostaRpt();

    private void IpostaRpt()
    {
      DataSet singleData = new RichiestaIntervento(this.Context.User.Identity.Name).GetSingleData(int.Parse(this.Request.QueryString["wo_id"]));
      int wrId = 0;
      foreach (DataRow row in (InternalDataCollectionBase) singleData.Tables[0].Rows)
        wrId = Convert.ToInt32(row["VAR_WR_WR_ID"]);
      ClManCorrettiva clManCorrettiva = new ClManCorrettiva();
      DataTable table1 = clManCorrettiva.GetListaManodopera(wrId).Tables[0].Copy();
      table1.TableName = "tableCostoPersonale";
      singleData.Tables.Add(table1);
      DataTable table2 = clManCorrettiva.GetListaMateriali(wrId).Tables[0].Copy();
      table2.TableName = "tableCostoMateriali";
      singleData.Tables.Add(table2);
      int count = table2.Rows.Count;
      this.Execute(singleData);
    }

    private void Execute(DataSet _dsRpt)
    {
      bool flag = false;
      dsRapportino dsRapportino = new dsRapportino();
      int num1 = 0;
      int index1;
      for (index1 = 0; index1 <= _dsRpt.Tables[0].Rows.Count - 1; ++index1)
        dsRapportino.Tables["rapportoTecnicoIntervento"].ImportRow(_dsRpt.Tables[0].Rows[index1]);
      if (index1 == 0)
        throw new Exception("* DATI PER IL DOCUMENTO NON PRESENTI");
      string str1 = string.Empty;
      foreach (DataRow row in (InternalDataCollectionBase) dsRapportino.Tables["rapportoTecnicoIntervento"].Rows)
      {
        if (Convert.ToInt32(row["ID_PROGETTO"]) == 1)
        {
          string fileName = this.Server.MapPath("../" + ConfigurationSettings.AppSettings["LogoME"]);
          row["IMMAGINE_LOGO"] = (object) this.GetPhoto(fileName);
        }
        else
        {
          str1 = this.Server.MapPath("../" + ConfigurationSettings.AppSettings["LogoPapardo"]);
          row["IMMAGINE_LOGO"] = (object) DBNull.Value;
        }
      }
      num1 = 0;
      int index2;
      for (index2 = 0; index2 <= _dsRpt.Tables[1].Rows.Count - 1; ++index2)
        dsRapportino.Tables["ListaManodopera"].ImportRow(_dsRpt.Tables[1].Rows[index2]);
      if (index2 == 0)
      {
        DataRow row = dsRapportino.Tables["ListaManodopera"].NewRow();
        row["ID"] = (object) "-1";
        row["IdAddetto"] = (object) 0;
        row["IdAddettoWR"] = (object) 0;
        row["CognomeNome"] = (object) DBNull.Value;
        row["Livello"] = (object) "<b>TOTALE</b>";
        row["PrezzoUnitario"] = (object) DBNull.Value;
        row["OreLavorate"] = (object) DBNull.Value;
        row["Totale"] = (object) 0;
        row["DescrizioneIntervento"] = (object) DBNull.Value;
        dsRapportino.Tables["ListaManodopera"].Rows.Add(row);
      }
      else
        flag = true;
      num1 = 0;
      int index3;
      for (index3 = 0; index3 <= _dsRpt.Tables[2].Rows.Count - 1; ++index3)
        dsRapportino.Tables["ListaMateriali"].ImportRow(_dsRpt.Tables[2].Rows[index3]);
      if (index3 == 0)
      {
        DataRow row = dsRapportino.Tables["ListaMateriali"].NewRow();
        row["ID"] = (object) "-1";
        row["MATERIALE"] = (object) DBNull.Value;
        row["PREZZO_UNITARIO"] = (object) DBNull.Value;
        row["UNITAMISURA"] = (object) "";
        row["QUANTITA"] = (object) 0;
        row["PREZZOTOTALE"] = (object) 0;
        row["ID_MATERIALI"] = (object) -1;
        dsRapportino.Tables["ListaMateriali"].Rows.Add(row);
      }
      else
        flag = true;
      float num2 = 0.0f;
      float num3 = 0.0f;
      if (flag)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dsRapportino.Tables["ListaManodopera"].Rows)
          num2 += float.Parse(Convert.ToString(row["TOTALE"]));
        foreach (DataRow row in (InternalDataCollectionBase) dsRapportino.Tables["ListaMateriali"].Rows)
          num3 += float.Parse(Convert.ToString(row["PREZZOTOTALE"]));
        DataRow row1 = dsRapportino.Tables["TOTALI"].NewRow();
        row1["TotaleManodopera"] = (object) num2;
        row1["TotaleMateriali"] = (object) num3;
        dsRapportino.Tables["TOTALI"].Rows.Add(row1);
      }
      this.pathRptSource = this.Server.MapPath("../Report/RptTecnicoIntervento2.rpt");
      this.crReportDocument.Load(this.pathRptSource);
      this.crReportDocument.SetDataSource((object) dsRapportino);
      string str2 = this.Server.MapPath("../Report/" + this.Session.SessionID.ToString() + ".pdf");
      DiskFileDestinationOptions destinationOptions = new DiskFileDestinationOptions();
      PdfRtfWordFormatOptions wordFormatOptions = new PdfRtfWordFormatOptions();
      ExportOptions exportOptions = this.crReportDocument.get_ExportOptions();
      exportOptions.set_ExportFormatType((ExportFormatType) 5);
      exportOptions.set_FormatOptions((object) wordFormatOptions);
      exportOptions.set_ExportDestinationType((ExportDestinationType) 1);
      destinationOptions.set_DiskFileName(str2);
      exportOptions.set_DestinationOptions((object) destinationOptions);
      this.crReportDocument.Export();
      this.Response.ClearContent();
      this.Response.ClearHeaders();
      this.Response.ContentType = "application/pdf";
      this.Response.WriteFile(str2);
      this.Response.Flush();
      this.Response.Close();
      File.Delete(str2);
    }

    private byte[] GetPhoto(string fileName)
    {
      string path = fileName;
      if (!File.Exists(path))
        return (byte[]) null;
      FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
      BinaryReader binaryReader = new BinaryReader((Stream) fileStream);
      byte[] numArray = binaryReader.ReadBytes((int) binaryReader.BaseStream.Length);
      binaryReader.Close();
      fileStream.Close();
      return numArray;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      this.crReportDocument = new ReportDocument();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
