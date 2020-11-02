using System;
using System.Data;
using System.Data.OracleClient;

namespace TheSite.AslMobile.Class
{
	/// <summary>
	/// Descrizione di riepilogo per ClassCompletaOrdine.
	/// </summary>
	public class ClassCompletaOrdine: Abstract
	{
		public ClassCompletaOrdine()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
		public DataSet CompletaWO (OracleParameterCollection Coll)
		{
			//Creazione del Parametro Del Cursore
			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);

			DataSet _MyDs= base.GetData(Coll,"PACK_MAN_PROG.CompletaWO");

			return _MyDs;
		}
		public DataSet AggiornaWO(OracleParameterCollection Coll)
		{
			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);

			DataSet _MyDs= base.GetData(Coll,"PACK_MAN_PROG.AggiornaWO");

			return _MyDs;
		}
		public DataSet AggiornaWr(OracleParameterCollection Coll)
		{
			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);

			DataSet _MyDs= base.GetData(Coll,"PACK_MAN_PROG.AggiornaWR");

			return _MyDs;
		}


	}
}
