using System;
using System.Data;
using System.Data.OracleClient;

namespace TheSite.AslMobile.Class
{
	/// <summary>
	/// Descrizione di riepilogo per ClassRichiesta.
	/// </summary>
	public class ClassRichiesta : Abstract
	{
		string UserName=string.Empty;
		public ClassRichiesta(string username)
		{
		  UserName=username;
		}
		public int Crea(OracleParameterCollection Coll)
		{
			int i_Result = 0;

			OracleParameter s_CurrentUser = new OracleParameter();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.OracleType=OracleType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

			OracleParameter s_IdOut = new OracleParameter();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.OracleType =OracleType.Int32;
			s_IdOut.Direction = ParameterDirection.Output;

			Coll.Add(s_CurrentUser);	
			Coll.Add(s_IdOut);

			i_Result = base.Add(Coll,"PACK_MAN_ORD.SP_CREA");
			return i_Result;		
		}
		public DataSet GetSingleData(int itemId)
		{
			OracleParameterCollection _SColl= new OracleParameterCollection();

			OracleParameter s_Id = new OracleParameter();
			s_Id.ParameterName = "p_Wr_Id";
			s_Id.OracleType = OracleType.Int32;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Value = itemId;
			
			OracleParameter s_Cursor = new OracleParameter();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.OracleType = OracleType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;

			_SColl.Add(s_Id);
			_SColl.Add(s_Cursor);

			DataSet _MyDs= base.GetData(_SColl,"PACK_MAN_ORD.SP_GETSINGLERICHIESTA");

			return _MyDs;
		}
		public DataSet GetAddetti(string NomeCompleto, string codEdificio,string ditta_id)
		{
			OracleParameterCollection _SColl= new OracleParameterCollection();
		
			OracleParameter s_p_NomeCompleto = new OracleParameter();
			s_p_NomeCompleto.ParameterName = "p_NomeCompleto";
			s_p_NomeCompleto.OracleType = OracleType.VarChar;
			s_p_NomeCompleto.Direction = ParameterDirection.Input;
			s_p_NomeCompleto.Size =50;
			s_p_NomeCompleto.Value = NomeCompleto;
			_SColl.Add(s_p_NomeCompleto);			

			OracleParameter s_p_BL_ID = new OracleParameter();
			s_p_BL_ID.ParameterName = "p_bl_id";
			s_p_BL_ID.OracleType = OracleType.VarChar;
			s_p_BL_ID.Direction = ParameterDirection.Input;
			s_p_BL_ID.Size =50;
			s_p_BL_ID.Value = codEdificio;
			_SColl.Add(s_p_BL_ID);			

			OracleParameter s_p_DITTA_ID = new OracleParameter();
			s_p_DITTA_ID.ParameterName = "p_ditta_id";
			s_p_DITTA_ID.OracleType = OracleType.VarChar;
			s_p_DITTA_ID.Direction = ParameterDirection.Input;
			s_p_DITTA_ID.Size =50;
			s_p_DITTA_ID.Value = ditta_id;
			_SColl.Add(s_p_DITTA_ID);			

			OracleParameter s_p_UserName = new OracleParameter();
			s_p_UserName.ParameterName = "p_UserName";
			s_p_UserName.OracleType = OracleType.VarChar;
			s_p_UserName.Direction = ParameterDirection.Input;
			s_p_UserName.Size =50;
			s_p_UserName.Value = this.UserName;
			_SColl.Add(s_p_UserName);

			OracleParameter s_Cursor = new OracleParameter();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.OracleType = OracleType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;

			_SColl.Add(s_Cursor);
			
			DataSet _MyDs= base.GetData(_SColl,"PACK_ADDETTI.SP_GETADDETTORUOLO");

			return _MyDs;

		}

		public  DataSet GetRDLNonEmesse(string codEdificio)
		{
			OracleParameterCollection _SColl= new OracleParameterCollection();

			OracleParameter s_p_BL_ID = new OracleParameter();
			s_p_BL_ID.ParameterName = "p_bl_id";
			s_p_BL_ID.OracleType = OracleType.VarChar;
			s_p_BL_ID.Direction = ParameterDirection.Input;
			s_p_BL_ID.Size =50;
			s_p_BL_ID.Value = codEdificio;
			_SColl.Add(s_p_BL_ID);			

			OracleParameter s_Cursor = new OracleParameter();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.OracleType = OracleType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;

			_SColl.Add(s_Cursor);
			
			DataSet _MyDs= base.GetData(_SColl,"PACK_MAN_ORD.SP_GetRDLNonEmesse");

			return _MyDs;
		}
		public  DataSet GetRDLApprovate(string codEdificio)
		{
			OracleParameterCollection _SColl= new OracleParameterCollection();

			OracleParameter s_p_BL_ID = new OracleParameter();
			s_p_BL_ID.ParameterName = "p_bl_id";
			s_p_BL_ID.OracleType = OracleType.VarChar;
			s_p_BL_ID.Direction = ParameterDirection.Input;
			s_p_BL_ID.Size =50;
			s_p_BL_ID.Value = codEdificio;
			_SColl.Add(s_p_BL_ID);			

			OracleParameter s_Cursor = new OracleParameter();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.OracleType = OracleType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;

			_SColl.Add(s_Cursor);
			
			DataSet _MyDs= base.GetData(_SColl,"PACK_MAN_ORD.SP_GetRDLApprovate");

			return _MyDs;
		}
		public string GetNumeroNonEmesse(string _bl_id)
		{
			OracleParameterCollection _SColl= new OracleParameterCollection();

			OracleParameter s_p_sql = new OracleParameter();
			s_p_sql.ParameterName = "p_sql";
			s_p_sql.OracleType = OracleType.VarChar;
			s_p_sql.Direction = ParameterDirection.Input;
			s_p_sql.Size =2000;
			s_p_sql.Value = " Select count(wr.wr_id) from wr where wr.bl_id = '" + _bl_id + "' and wr.id_wr_status in (1,15) and wr.tipomanutenzione_id = 1";;
			_SColl.Add(s_p_sql);			

			OracleParameter s_Cursor = new OracleParameter();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.OracleType = OracleType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;

			_SColl.Add(s_Cursor);
			
			DataSet _MyDs= base.GetData(_SColl,"PACK_COMMON.SP_DYNAMIC_SELECT");

			return _MyDs.Tables[0].Rows[0][0].ToString();		
		}

		public string GetNumeroApprovate(string _bl_id)
		{
			OracleParameterCollection _SColl= new OracleParameterCollection();

			OracleParameter s_p_sql = new OracleParameter();
			s_p_sql.ParameterName = "p_sql";
			s_p_sql.OracleType = OracleType.VarChar;
			s_p_sql.Direction = ParameterDirection.Input;
			s_p_sql.Size =2000;
			s_p_sql.Value = " Select count(wr.wr_id) from wr where wr.bl_id = '" + _bl_id + "' and wr.id_wr_status not in (1,15) and wr.tipomanutenzione_id = 1";
			_SColl.Add(s_p_sql);			

			OracleParameter s_Cursor = new OracleParameter();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.OracleType = OracleType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;

			_SColl.Add(s_Cursor);
			
			DataSet _MyDs= base.GetData(_SColl,"PACK_COMMON.SP_DYNAMIC_SELECT");

			return _MyDs.Tables[0].Rows[0][0].ToString();		
		}

	}
}
