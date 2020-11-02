// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.CostiGesioneCumulativi.StampaSuDisco
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace TheSite.Classi.CostiGesioneCumulativi
{
  public class StampaSuDisco
  {
    private string _s_DirectoryStampa;

    public StampaSuDisco(string DirectoryStampa) => this._s_DirectoryStampa = DirectoryStampa;

    public void StampaPdf(ReportClass ReportDaStampare, string NomeFile)
    {
      NomeFile = this._s_DirectoryStampa + NomeFile + ".pdf";
      DiskFileDestinationOptions destinationOptions = new DiskFileDestinationOptions();
      PdfRtfWordFormatOptions wordFormatOptions = new PdfRtfWordFormatOptions();
      ExportOptions exportOptions = ((ReportDocument) ReportDaStampare).get_ExportOptions();
      exportOptions.set_ExportFormatType((ExportFormatType) 5);
      exportOptions.set_FormatOptions((object) wordFormatOptions);
      exportOptions.set_ExportDestinationType((ExportDestinationType) 1);
      destinationOptions.set_DiskFileName(NomeFile);
      exportOptions.set_DestinationOptions((object) destinationOptions);
      ((ReportDocument) ReportDaStampare).Export();
    }

    public void StampaPdf(ReportDocument ReportDaStampare, string NomeFile)
    {
      NomeFile = this._s_DirectoryStampa + NomeFile + ".pdf";
      DiskFileDestinationOptions destinationOptions = new DiskFileDestinationOptions();
      PdfRtfWordFormatOptions wordFormatOptions = new PdfRtfWordFormatOptions();
      ExportOptions exportOptions = ReportDaStampare.get_ExportOptions();
      exportOptions.set_ExportFormatType((ExportFormatType) 5);
      exportOptions.set_FormatOptions((object) wordFormatOptions);
      exportOptions.set_ExportDestinationType((ExportDestinationType) 1);
      destinationOptions.set_DiskFileName(NomeFile);
      exportOptions.set_DestinationOptions((object) destinationOptions);
      ReportDaStampare.Export();
    }
  }
}
