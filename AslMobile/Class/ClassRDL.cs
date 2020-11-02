using System;
using System.Data;
using System.Data.OracleClient; 

namespace TheSite.AslMobile.Class
{
	/// <summary>
	/// Descrizione di riepilogo per ClassRDL.
	/// </summary>
	public class ClassRDL :Abstract
	{
		string UserName=string.Empty ;
		public ClassRDL(string username)
		{
		  UserName=username;
		}
		public DataSet GetSingleRdl(int itemId)
		{
	
			OracleParameterCollection _SColl= new OracleParameterCollection();		

			OracleParameter s_Id = new OracleParameter();
			s_Id.ParameterName = "p_Wr_Id";
			s_Id.OracleType=OracleType.Int32;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Value = itemId;
			
			OracleParameter s_Cursor = new OracleParameter();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.OracleType = OracleType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;

			_SColl.Add(s_Id);
			_SColl.Add(s_Cursor);

			DataSet _Ds= base.GetData(_SColl,"PACK_MOBILE.SP_GETSINGLERDL");
			return _Ds;
		}

		public  DataSet GetStatusRdl(int wr_id)
		{	
			
			OracleParameterCollection CollezioneControlli = new OracleParameterCollection();
			
			OracleParameter s_IdIn = new OracleParameter();
			s_IdIn.ParameterName = "p_Wr_Id";
			s_IdIn.OracleType = OracleType.Int32;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Value = wr_id;

			CollezioneControlli.Add(s_IdIn);
			
			OracleParameter s_Cursor = new OracleParameter();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.OracleType = OracleType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			CollezioneControlli.Add(s_Cursor);	
		
			DataSet _Ds= base.GetData(CollezioneControlli,"PACK_MAN_ORD.SP_GETSTATUSRDL");
			
			return _Ds;	

		}
		public  DataSet GetStatoLavoro()
		{
			
			OracleParameterCollection _SColl= new OracleParameterCollection();		

			OracleParameter s_Cursor = new OracleParameter();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.OracleType = OracleType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;

			_SColl.Add(s_Cursor);

			DataSet _Ds= base.GetData(_SColl,"PACK_MAN_ORD.SP_GETSTATOLAVORO");

			return _Ds;	
		}

		public int Update(OracleParameterCollection CollezioneControlli ,int itemId)
		{
			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="p_IdOut";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Int32;
			CollezioneControlli.Add(PaCursor);

			return base.Update(CollezioneControlli, "p_wr_id" ,itemId, "PACK_MOBILE.SP_UPDATECOMPLETAMENTO");
		}
	}
		
}
