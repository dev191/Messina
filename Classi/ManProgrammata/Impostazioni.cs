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
	public class Impostazioni : AbstractBase
	{
		#region Dichiarazioni

		private string s_Descrizione = string.Empty;
		private ApplicationDataLayer.OracleDataLayer _OraDl;
		#endregion
		
		public string UserName;
	
				
		public Impostazioni()
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
			return null;
		}
		
		public DataSet GetImpostazioniDefault(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = 4;
			s_UserName.Size=50;
			s_UserName.Value=System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 5;
			CollezioneControlli.Add(s_Cursor);
			
			string s_StrSql = "PACK_MAN_PROG.getImpostazioniDeafult";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}		
		public DataSet GetImpostazioniDefaultPaging(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = 4;
			s_UserName.Size=50;
			s_UserName.Value=System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 5;
			CollezioneControlli.Add(s_Cursor);
			
			string s_StrSql = "PACK_MAN_PROG.getImpostazioniDeafultPaging";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}		
		public int GetImpostazioniDefaultCount(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = 4;
			s_UserName.Size=50;
			s_UserName.Value=System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 5;
			CollezioneControlli.Add(s_Cursor);
			
			string s_StrSql = "PACK_MAN_PROG.getImpostazioniDeafultCount";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return int.Parse(_Ds.Tables[0].Rows[0][0].ToString());	
		}		
		#endregion

		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			int i_MaxParametri = CollezioneControlli.Count;			
			
			// TIPO OPERAZIONE

			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_Operazione";
			s_Operazione.DbType = CustomDBType.VarChar;
			s_Operazione.Direction = ParameterDirection.Input;
			s_Operazione.Index = i_MaxParametri;
			s_Operazione.Value = Operazione.ToString();
			CollezioneControlli.Add(s_Operazione);

			i_MaxParametri ++;

			// OUT

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;
			CollezioneControlli.Add(s_IdOut);

			int i_Result = _OraDl.GetRowsAffectedTransaction(CollezioneControlli, "PACK_MAN_PROG.SP_EXECUTEIMPOSTAZIONI");
				
			return i_Result;
		}

		#endregion
	}
}

