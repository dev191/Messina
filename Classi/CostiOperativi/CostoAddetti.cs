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

namespace TheSite.Classi.CostiOperativi 
{
	/// <summary>
	/// Descrizione di riepilogo per CostoAddetti.
	/// </summary>
	public class CostoAddetti: AbstractBase
	{
		#region Dichiarazioni

		private ApplicationDataLayer.OracleDataLayer _OraDl;
			
		#endregion

		public CostoAddetti()
		{
			_OraDl = new OracleDataLayer(s_ConnStr);
		}


		#region Metodi Pubblici

		public override DataSet GetData()
		{			
			DataSet _Ds;
			
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COSTI_ADDETTI.SP_GETSINGLEADDETT0_WR";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;				
					
		}

		/// <summary>
		/// DataSet con i record selezionati in base alla collection
		/// </summary>
		/// <param name="CollezioneCOntrolli"></param>
		/// <param name="NomeProcedura"></param>
		/// <returns></returns>
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;
			
			S_ControlsCollection CollezioneControlli2 = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COSTI_ADDETTI.SP_GETSINGLEADDETT0_WR";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;				
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public override DataSet GetSingleData(int wr_id)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_wr_id = new S_Object();
			s_wr_id.ParameterName = "p_wr_id";
			s_wr_id.DbType = CustomDBType.Integer;
			s_wr_id.Direction = ParameterDirection.Input;
			s_wr_id.Index = 0;
			s_wr_id.Value = wr_id;	
		
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SColl.Add(s_Cursor);

			_SColl.Add(s_wr_id);
				
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COSTI_ADDETTI.SP_GETSINGLEADDETTI_WR";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			
			return _Ds;	
			
		}
		#endregion


		#region Metodi Privati
		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_wr_id = new S_Object();
			s_wr_id.ParameterName = "p_wr_id";
			s_wr_id.DbType = CustomDBType.Integer;
			s_wr_id.Direction = ParameterDirection.Input;
			s_wr_id.Index = 0;
			s_wr_id.Value = itemId;	
		
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SColl.Add(s_Cursor);

			_SColl.Add(s_wr_id);
				
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COSTI_ADDETTI.SP_GETSINGLEADDETTI_WR";	
		
			
			int i_Result = _OraDl.GetRowsAffected(_SColl, s_StrSql);
				
			return i_Result;
			
		}

		#endregion

		public DataSet GetAddetti()
			{
				DataSet _Ds;

				S_ControlsCollection _SColl = new S_ControlsCollection();
				
				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 1;
				
				
				_SColl.Add(s_Cursor);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_COSTI_ADDETTI.SP_GETALLADDETTI";	
				_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			
				
				return _Ds;		
			}

		
	}
}
