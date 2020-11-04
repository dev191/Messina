using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;



namespace TheSite.Classi.CostiGesioneCumulativi
{
	/// <summary>
	/// Descrizione di riepilogo per Stampa.
	/// </summary>
	public class StampaSuDisco
	{
		string _s_DirectoryStampa;
		public StampaSuDisco(string DirectoryStampa)
		{
			_s_DirectoryStampa = DirectoryStampa;
		}

		/// <summary>
		/// Stampa il report che gli viene passato con il nome specificato
		/// </summary>
		public void StampaPdf( ReportClass ReportDaStampare, string NomeFile)
		{
//			try
//			{
				NomeFile =  _s_DirectoryStampa + NomeFile  + ".pdf";
				ExportOptions optExp;
				DiskFileDestinationOptions optDsk  = new DiskFileDestinationOptions();
				PdfRtfWordFormatOptions optPdfRtf = new PdfRtfWordFormatOptions();
				optExp = ReportDaStampare.ExportOptions;
				optExp.ExportFormatType = ExportFormatType.PortableDocFormat;
				optExp.FormatOptions = optPdfRtf;
				optExp.ExportDestinationType = ExportDestinationType.DiskFile;
				optDsk.DiskFileName = NomeFile;
				optExp.DestinationOptions = optDsk;
				ReportDaStampare.Export();
//			}
//			catch(Exception ex)
//			{
//				throw ex;
//			}

		}

		/// <summary>
		/// Stampa il report che gli viene passato con il nome specificato
		/// overloading: viene passato un ReporDocument
		/// </summary>
		public void StampaPdf( ReportDocument ReportDaStampare, string NomeFile)
		{
			NomeFile =  _s_DirectoryStampa + NomeFile  + ".pdf";
			ExportOptions optExp;
			DiskFileDestinationOptions optDsk  = new DiskFileDestinationOptions();
			PdfRtfWordFormatOptions optPdfRtf = new PdfRtfWordFormatOptions();
			optExp = ReportDaStampare.ExportOptions;
			optExp.ExportFormatType = ExportFormatType.PortableDocFormat;
			optExp.FormatOptions = optPdfRtf;
			optExp.ExportDestinationType = ExportDestinationType.DiskFile;
			optDsk.DiskFileName = NomeFile;
			optExp.DestinationOptions = optDsk;
			ReportDaStampare.Export();
		}
	}
}
