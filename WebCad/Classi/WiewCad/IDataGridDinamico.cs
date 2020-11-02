using System;
using WebCad;
using System.Data;

namespace WebCad.WiewCad
{
	/// <summary>
	/// Descrizione di riepilogo per IDataGridDinamico.
	/// </summary>
	public interface IDataGridDinamico
	{
		DataSet Popola(ParametriRicerca parametri);
	}
}
