using System;
using System.Data;
using System.Data.OracleClient; 
using System.Web.UI.WebControls;

namespace TheSite.AslMobile.Class
{
	/// <summary>
	/// Descrizione di riepilogo per ClassDitta.
	/// </summary>
	public class ClassDitta: Abstract
	{
		private string userName;

		public ClassDitta(string user)
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
			this.userName=user;
		}
		public DataSet GetDittaBl(int idbl)
		{
			OracleParameterCollection Coll= new OracleParameterCollection();
			
			OracleParameter s_id = new OracleParameter();
			s_id.ParameterName = "p_Bl_Id";
			s_id.OracleType = OracleType.Int32;
			s_id.Direction = ParameterDirection.Input;
			s_id.Value = idbl;						
			Coll.Add(s_id);

			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);

			DataSet _MyDs= base.GetData(Coll,"PACK_DITTE.SP_GETDITTABL");
			return _MyDs;		
		}

		public DataSet GetDitteFornitoriRuoli(int idditta)
		{
		
			OracleParameterCollection Coll= new OracleParameterCollection();
			
			OracleParameter s_id = new OracleParameter();
			s_id.ParameterName = "p_Ditta_id";
			s_id.OracleType = OracleType.Int32;
			s_id.Direction = ParameterDirection.Input;
			s_id.Value = idditta;
			Coll.Add(s_id);
				
			OracleParameter s_CurrentUser = new OracleParameter();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.OracleType = OracleType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Value = this.userName;
			Coll.Add(s_CurrentUser);
			
			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);

			DataSet _MyDs= base.GetData(Coll,"PACK_DITTE.SP_GETGESTORI_FORNITORI_RUOLO");
			return _MyDs;		
		}


	}
}
