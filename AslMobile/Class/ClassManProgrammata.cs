using System;
using System.Data;
using System.Data.OracleClient; 
using System.Web.UI.WebControls;

namespace TheSite.AslMobile.Class
{
	/// <summary>
	/// Descrizione di riepilogo per ClassManProgrammata.
	/// </summary>
	public class ClassManProgrammata: Abstract
	{
		string UserName=string.Empty;
		public ClassManProgrammata(string username)
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
			UserName=username;
		}
		public DataSet Ricerca(OracleParameterCollection Coll)
		{
			OracleParameter  p_Username=new OracleParameter();
			p_Username.ParameterName="p_Username";
			p_Username.Size=50;
			p_Username.Direction=ParameterDirection.Input;
			p_Username.OracleType=OracleType.VarChar;
			p_Username.Value =this.UserName;
			Coll.Add(p_Username);

			//Creazione del Parametro Del Cursore
			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);
			
			DataSet _MyDs= base.GetData(Coll,"PACK_MAN_PROG.GetCompletamento");

			return _MyDs;
		}
		public DataSet GetDatiWO(OracleParameterCollection Coll)
		{

			//Creazione del Parametro Del Cursore
			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);
			
			DataSet _MyDs= base.GetData(Coll,"PACK_MAN_PROG.GetDatiWO");
			Coll.Remove(PaCursor);

			return _MyDs;
		}
		public DataSet GetDatiWR(OracleParameterCollection Coll)
		{
			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);

			DataSet _MyDs= base.GetData(Coll,"PACK_MAN_PROG.GetDatiWR");

			return _MyDs;
		}
	}
}
