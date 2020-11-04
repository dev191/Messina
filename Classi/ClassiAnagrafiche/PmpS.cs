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

namespace TheSite.Classi
{
	/// <summary>
	/// Descrizione di riepilogo per Ruolo.
	/// </summary>
	public class PmpS : AbstractBase
	{
		#region Dichiarazioni

		private string s_Descrizione = string.Empty;
		private ApplicationDataLayer.OracleDataLayer _OraDl;
		#endregion

		public PmpS()
		{
			_OraDl = new OracleDataLayer(s_ConnStr);
		}


		#region Metodi Pubblici

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
		/// 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		/// 

		public override DataSet GetData()
		{
			DataSet _Ds = new DataSet();
			return  _Ds;
		}

		//public override DataSet GetData(int itemId){}

		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds = new DataSet();
			return  _Ds;
			
		}

		public override DataSet GetSingleData(int itemId)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_ID_pmp";
			s_Id.DbType = CustomDBType.Integer;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = 0;
			s_Id.Value = itemId;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SColl.Add(s_Id);
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_PROG.getProcStepsDett";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;		
		}

		#endregion

		#region Proprietà Pubbliche

		/// <summary>
		/// 
		/// </summary>
		public string Descrizione
		{
			get {return s_Descrizione;}
			set {s_Descrizione = value;}
		}

		#endregion

		#region Metodi Protetti
		
		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{

//			if (TabellaStep.Rows.Count > 0)
//			{
//				foreach (DataRow riga in TabellaStep)
//				{

			int i_MaxParametri = CollezioneControlli.Count + 1;			

			S_Controls.Collections.S_Object s_Idpmp = new S_Object();
			s_Idpmp.ParameterName = "p_id_pmp";
			s_Idpmp.DbType = CustomDBType.Integer;
			s_Idpmp.Direction = ParameterDirection.Input;
			s_Idpmp.Index = i_MaxParametri;
			s_Idpmp.Value = itemId;		
	
			i_MaxParametri ++;
	
			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_Operazione";
			s_Operazione.DbType = CustomDBType.VarChar;
			s_Operazione.Direction = ParameterDirection.Input;
			s_Operazione.Index = i_MaxParametri;
			s_Operazione.Value = Operazione.ToString();

			i_MaxParametri ++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;

			CollezioneControlli.Add(s_Idpmp);	
//					CollezioneControlli.Add(s_CurrentUser);	
			CollezioneControlli.Add(s_Operazione);
			CollezioneControlli.Add(s_IdOut);

			int i_Result = _OraDl.GetRowsAffectedTransaction(CollezioneControlli, "PACK_PMP.SP_EXECUTEPMP_Step");
			
//				}
//			}

			return i_Result;
		}

		#endregion
	}
}
