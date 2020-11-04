using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Data;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;


namespace TheSite.Classi.ManProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per ProcAndSteps.
	/// </summary>
	public class CreaPiano : AbstractBase
	{
		#region Dichiarazioni

		private string s_Descrizione = string.Empty;
		private ApplicationDataLayer.OracleDataLayer _OraDl;
		#endregion
		
		public string UserName;
	
				
		public CreaPiano()
		{
			_OraDl = new OracleDataLayer(s_ConnStr);
		}

		#region Metodi Pubblici

		/// <summary>
		/// DataSet con tutti i record
		/// </summary>
		/// <returns></returns>
		

		/// <summary>
		/// 
		/// </summary>		
		/// 

		public void beginTransaction()
		{
			_OraDl.BeginTransaction();
		}

		public void commitTransaction()
		{
			_OraDl.CommitTransaction();			
		}

		public void rollbackTransaction()
		{
			_OraDl.RollbackTransaction();
		}

		public override DataSet GetData()
		{
			return null;
		}
		public override DataSet GetSingleData(int itemId)
		{
			return null;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count+1;
			CollezioneControlli.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_PROG.getCreaPiano";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}	
		public DataSet GetDataPaging(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count+1;
			CollezioneControlli.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_PROG.getCreaPianoPaging";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}	
		public int GetDataCount(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count+1;
			CollezioneControlli.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_PROG.getCreaPianoCount";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return int.Parse(_Ds.Tables[0].Rows[0][0].ToString());
		}		
		public int CreaPianoMP(S_ControlsCollection CollezioneControlli)
		{	
			// OUT
			S_Controls.Collections.S_Object s_p_esito = new S_Object();
			s_p_esito.ParameterName = "p_esito";
			s_p_esito.DbType = CustomDBType.Integer;
			s_p_esito.Direction = ParameterDirection.Output;
			s_p_esito.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_p_esito);			
			int i_Result = _OraDl.GetRowsAffectedTransaction(CollezioneControlli, "PACK_SCHEDULA.SP_MP_PmsInPmsd_Ater");				
			return i_Result;			
		}

		#endregion

		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			int i_Result = 0;				
			return i_Result;
		}

		#endregion
	}
}
