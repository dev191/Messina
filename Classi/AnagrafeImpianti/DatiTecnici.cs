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

namespace TheSite.Classi.ClassiDettaglio
{
	/// <summary>
	/// Descrizione di riepilogo per DatiTecnici.
	/// Usata nella form ServiziEdifici.aspx
	/// </summary>
	public class DatiTecnici: AbstractBase  
	{
		private string s_username;
	
		public DatiTecnici(string Username)
		{
			this.s_username=Username;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override DataSet GetData()
		{
			return null;	
		}
		/// <summary>
		/// Recupera una determinata descrizione tecnica in base al parametro
		/// </summary>
		/// <param name="CollezioneControlli">il Parametro deve essere eq.eq_id</param>
		/// <returns></returns>
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DATITECNICIAPP.SP_GETDATITECNICI";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}
		public  DataSet GetDataApp(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DATITECNICIAPP.SP_GETDATITECNICIAPP";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}

		public  DataSet RecStd(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_EQ_DATITECNICI.SP_GET_EQSTDID";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}
		/// <summary>
		/// Recupera le apparecchiature
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public override DataSet GetSingleData(int itemId)
		{
			DataSet _Ds;		
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_eq = new S_Controls.Collections.S_Object();
			s_p_id_eq.ParameterName = "p_id_eq";
			s_p_id_eq.DbType = CustomDBType.Integer;
			s_p_id_eq.Direction = ParameterDirection.Input;
			s_p_id_eq.Index = CollezioneControlli.Count + 1;
			s_p_id_eq.Value = 0;			
			CollezioneControlli.Add(s_p_id_eq);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DATITECNICIAPP.SP_GETDATIAPPARECCHIATURA";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}
		
		#region Metodi Private

		public override int Update(S_ControlsCollection CollezioneControlli, int itemId)
		{
			return base.Update (CollezioneControlli, itemId);
		}
		public override int Delete(S_ControlsCollection CollezioneControlli, int itemId)
		{
			return base.Delete (CollezioneControlli, itemId);
		}
		public override int Add(S_ControlsCollection CollezioneControlli)
		{
			return base.Add (CollezioneControlli);
		}

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			S_Controls.Collections.S_Object s_p_operazione = new S_Controls.Collections.S_Object();
			s_p_operazione.ParameterName = "p_operazione";
			s_p_operazione.DbType = CustomDBType.VarChar;
			s_p_operazione.Direction = ParameterDirection.Input;
			s_p_operazione.Index = CollezioneControlli.Count + 1;
			
			if (Operazione==ExecuteType.Update)
			{
	           s_p_operazione.Value = "Update";
			}
			else if (Operazione==ExecuteType.Insert)
			{
                s_p_operazione.Value = "Insert";
			}
			else if (Operazione==ExecuteType.Delete)
			{
              s_p_operazione.Value = "Delete";
			}
			s_p_operazione.Size = 50;
			CollezioneControlli.Add(s_p_operazione);

			S_Controls.Collections.S_Object s_p_CurrentUser = new S_Controls.Collections.S_Object();
			s_p_CurrentUser.ParameterName = "p_CurrentUser";
			s_p_CurrentUser.DbType = CustomDBType.VarChar;
			s_p_CurrentUser.Direction = ParameterDirection.Input;
			s_p_CurrentUser.Index = CollezioneControlli.Count + 1;
			s_p_CurrentUser.Value = this.s_username;			
			s_p_CurrentUser.Size = 50;
			CollezioneControlli.Add(s_p_CurrentUser);

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_IdOut);
			//_____________________________________________________________________________________
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_DATITECNICIAPP.SP_DATITECNICI");
				
			return i_Result;
			//_____________________________________________________________________________________
		}

		#endregion
	}
}
