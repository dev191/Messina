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
	/// Descrizione di riepilogo per CompletaOrdine.
	/// </summary>
	public class CompletaOrdine:AbstractBase
	{
		string username=null;
		private ApplicationDataLayer.OracleDataLayer _OraDl;
		public CompletaOrdine()
		{
				_OraDl = new OracleDataLayer(s_ConnStr);
		}
		public CompletaOrdine(string UserName):this()
		{
		  this.username =UserName; 
		}
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
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			return null;
		}
		public override DataSet GetSingleData(int itemId)
		{
			return null;
		}
		public DataSet CompletaWO(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count+1;
			CollezioneControlli.Add(s_Cursor);
			
			string s_StrSql = "PACK_MAN_PROG.CompletaWO";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}
		public DataSet AggiornaWO(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count+1;
			CollezioneControlli.Add(s_Cursor);
			
			string s_StrSql = "PACK_MAN_PROG.AggiornaWO";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}
		public DataSet AggiornaWr(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count +1;
			CollezioneControlli.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_PROG.AggiornaWR";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}
		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			int i_Result = 0;				
			return i_Result;
		}

		#endregion

	}
}
