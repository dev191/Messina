using System;
using System.Data;
using System.Data.OracleClient; 
using System.Web.UI.WebControls;

namespace TheSite.AslMobile.Class
{
	/// <summary>
	/// Summary description for ClassRicerca.
	/// </summary>
	public class ClassRicerca: Abstract
	{
		private string userName;

		public ClassRicerca(string user)
		{
			//
			// TODO: Add constructor logic here
			//
			this.userName=user;
		}
		public DataSet Ricerca(OracleParameterCollection Coll)
		{
			OracleParameter  p_Username=new OracleParameter();
			p_Username.ParameterName="p_Username";
			p_Username.Size=50;
			p_Username.Direction=ParameterDirection.Input;
			p_Username.OracleType=OracleType.VarChar;
			p_Username.Value =this.userName;
			Coll.Add(p_Username);
			
			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);
			

			DataSet _MyDs= base.GetData(Coll,"PACK_GEST_RDL.SP_GETCOMPLETAMENTO");

			return _MyDs;
		}
	}
}
