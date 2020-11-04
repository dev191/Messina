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
	/// Descrizione di riepilogo per AccorpaRdl.
	/// </summary>
	public class AccorpaRdl: AbstractBase
	{
		private string username=string.Empty;
		private ApplicationDataLayer.OracleDataLayer _OraDl;

		public AccorpaRdl(string UserName)
		{
			username=UserName;
			_OraDl = new OracleDataLayer(s_ConnStr);
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


		/// <summary>
		/// Ricerca le richieste Accorpante
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public DataSet Accorpante(S_ControlsCollection CollezioneControlli)
		{
			
			S_Controls.Collections.S_Object s_p_utente = new S_Object();
			s_p_utente.ParameterName = "p_utente";
			s_p_utente.DbType = CustomDBType.VarChar;
			s_p_utente.Direction = ParameterDirection.Input;
			s_p_utente.Index = CollezioneControlli.Count + 1;
            s_p_utente.Value =this.username;
			s_p_utente.Size =50;
			CollezioneControlli.Add(s_p_utente);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

//			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GetAccorpante";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
			return _Ds;	
		}

		public DataSet Accorpate(S_ControlsCollection CollezioneControlli)
		{
			S_Controls.Collections.S_Object s_p_utente = new S_Object();
			s_p_utente.ParameterName = "p_utente";
			s_p_utente.DbType = CustomDBType.VarChar;
			s_p_utente.Direction = ParameterDirection.Input;
			s_p_utente.Index = CollezioneControlli.Count + 1;
			s_p_utente.Value =this.username;
			s_p_utente.Size =50;
			CollezioneControlli.Add(s_p_utente);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

//			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_Get_Da_Accorpare";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
			return _Ds;	
		}
		public DataSet VisualizzaAccorpate(S_ControlsCollection CollezioneControlli)
		{
			S_Controls.Collections.S_Object s_p_utente = new S_Object();
			s_p_utente.ParameterName = "p_utente";
			s_p_utente.DbType = CustomDBType.VarChar;
			s_p_utente.Direction = ParameterDirection.Input;
			s_p_utente.Index = CollezioneControlli.Count + 1;
			s_p_utente.Value =this.username;
			s_p_utente.Size =50;
			CollezioneControlli.Add(s_p_utente);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			//			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GetAccorpate";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
			return _Ds;	
		}
		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			
			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_IdOut);

			int i_Result = _OraDl.GetRowsAffectedTransaction(CollezioneControlli, "PACK_MAN_ORD.SP_Accorpa");

			return i_Result;
		}

		#endregion
	}
}
