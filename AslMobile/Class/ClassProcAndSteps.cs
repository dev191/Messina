using System;
using System.Data;
using System.Data.OracleClient; 
using System.Web.UI.WebControls;

namespace TheSite.AslMobile.Class
{
	/// <summary>
	/// Descrizione di riepilogo per ClassProcAndSteps.
	/// </summary>
	public class ClassProcAndSteps: Abstract
	{
		public ClassProcAndSteps()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
		public  DataSet GetDataDett(OracleParameterCollection Coll)
		{
			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);
			

			DataSet _MyDs= base.GetData(Coll,"PACK_MAN_PROG.getProcStepsDett");

			return _MyDs;
		}
	}
}
