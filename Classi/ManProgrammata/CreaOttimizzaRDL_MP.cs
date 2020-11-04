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
	public class CreaOttimizzaRDL_MP : AbstractBase
	{
		#region Dichiarazioni

		private string s_Descrizione = string.Empty;
		private ApplicationDataLayer.OracleDataLayer _OraDl;
		#endregion
		
		public string UserName;
	
				
		public CreaOttimizzaRDL_MP()
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
			string s_StrSql = "PACK_SCHEDULA.Crea_WR_Ricerca";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}		
		public  DataSet GetDataPaging(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count+1;
			CollezioneControlli.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SCHEDULA.Crea_WR_RicercaPaging";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}		
		 public int  GetDataCount(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count+1;
			CollezioneControlli.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SCHEDULA.Crea_WR_RicercaCount";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return int.Parse(_Ds.Tables[0].Rows[0][0].ToString());		
		}		

		public DataSet GetComuni(int anno)
		{

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			DataSet _Ds;

			S_Controls.Collections.S_Object s_Anno = new S_Object();
			s_Anno.ParameterName = "p_Anno";
			s_Anno.DbType = CustomDBType.Integer;
			s_Anno.Direction = ParameterDirection.Input;
			s_Anno.Index = 1;
			s_Anno.Size=50;
			s_Anno.Value = anno;
			CollezioneControlli.Add(s_Anno);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 2;
			CollezioneControlli.Add(s_Cursor);
			
			string s_StrSql = "PACK_SCHEDULA.Crea_WR_GetComuni";
	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}		

		public DataSet GetEdifici(int anno, int id_comune)
		{

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			DataSet _Ds;

			S_Controls.Collections.S_Object s_Anno = new S_Object();
			s_Anno.ParameterName = "p_anno";
			s_Anno.DbType = CustomDBType.Integer;
			s_Anno.Direction = ParameterDirection.Input;
			s_Anno.Index = CollezioneControlli.Count;
			s_Anno.Size=50;
			s_Anno.Value = anno;
			CollezioneControlli.Add(s_Anno);

			S_Controls.Collections.S_Object s_idcomune = new S_Object();
			s_idcomune.ParameterName = "p_comune";
			s_idcomune.DbType = CustomDBType.Integer;
			s_idcomune.Direction = ParameterDirection.Input;
			s_idcomune.Index = CollezioneControlli.Count;
			s_idcomune.Size=50;
			s_idcomune.Value = id_comune;
			CollezioneControlli.Add(s_idcomune);

			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index =CollezioneControlli.Count;
			s_p_username.Size=50;
			s_p_username.Value = System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_p_username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index =CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);
			
			string s_StrSql = "PACK_SCHEDULA.Crea_WR_GetEdifici";
	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}		

		public DataSet GetServizi(int anno, int id_comune, int id_edificio)
		{

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			DataSet _Ds;

			S_Controls.Collections.S_Object s_Anno = new S_Object();
			s_Anno.ParameterName = "p_Anno";
			s_Anno.DbType = CustomDBType.Integer;
			s_Anno.Direction = ParameterDirection.Input;
			s_Anno.Index = 1;
			s_Anno.Size=50;
			s_Anno.Value = anno;
			CollezioneControlli.Add(s_Anno);

			S_Controls.Collections.S_Object s_idcomune = new S_Object();
			s_idcomune.ParameterName = "p_comune";
			s_idcomune.DbType = CustomDBType.Integer;
			s_idcomune.Direction = ParameterDirection.Input;
			s_idcomune.Index = 2;
			s_idcomune.Size=50;
			s_idcomune.Value = id_comune;
			CollezioneControlli.Add(s_idcomune);

			S_Controls.Collections.S_Object s_idedif = new S_Object();
			s_idedif.ParameterName = "p_edificio";
			s_idedif.DbType = CustomDBType.Integer;
			s_idedif.Direction = ParameterDirection.Input;
			s_idedif.Index = 3;
			s_idedif.Size=50;
			s_idedif.Value = id_edificio;
			CollezioneControlli.Add(s_idedif);

			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index =CollezioneControlli.Count;
			s_p_username.Size=50;
			s_p_username.Value = System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_p_username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 4;
			CollezioneControlli.Add(s_Cursor);
			
			string s_StrSql = "PACK_SCHEDULA.Crea_WR_GetServizi";
	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}		


		#endregion

		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			if (Operazione==ExecuteType.Insert) 
			{

				S_Controls.Collections.S_Object s_MsgDB = new S_Object();
				s_MsgDB.ParameterName = "f_MsgDB";
				s_MsgDB.DbType = CustomDBType.VarChar;
				s_MsgDB.Direction = ParameterDirection.Output;
				s_MsgDB.Index = CollezioneControlli.Count + 1;												
				s_MsgDB.Size = 500;									
				CollezioneControlli.Add(s_MsgDB);	

				S_Controls.Collections.S_Object s_tot_RdL = new S_Object();
				s_tot_RdL.ParameterName = "f_tot_RdL";
				s_tot_RdL.DbType = CustomDBType.Integer;
				s_tot_RdL.Direction = ParameterDirection.Output;
				s_tot_RdL.Index = CollezioneControlli.Count + 1;																										
				CollezioneControlli.Add(s_tot_RdL);		

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

				int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_SCHEDULA.Crea_WR");
				
				return i_Result;
			}

			else if (Operazione==ExecuteType.Update) 
			{				

				S_Controls.Collections.S_Object s_esito = new S_Object();
				s_esito.ParameterName = "p_esito";
				s_esito.DbType = CustomDBType.Integer;
				s_esito.Direction = ParameterDirection.Output;
				s_esito.Index = CollezioneControlli.Count + 1;																										
				CollezioneControlli.Add(s_esito);		

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

				int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_SCHEDULA.Ottimizza");
				
				return i_Result;
			}

			else
				return 0;

		}

		#endregion
	}
}
