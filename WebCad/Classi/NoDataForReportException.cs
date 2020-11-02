using System;

namespace WebCad.Eccezioni
{
	/// <summary>
	/// Descrizione di riepilogo per NoDataForReportException.
	/// </summary>
	public class NoDataForReportFoundException : Exception
	{
		public new string Message;
		public NoDataForReportFoundException()
		{
			this.Message="La ricerca effettuata non ha prodotto dati";
		}
	}
}
