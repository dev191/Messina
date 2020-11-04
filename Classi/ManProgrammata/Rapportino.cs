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
	/// Descrizione di riepilogo per Rapportino.
	/// Classe usata dalla Pagina Rapportino.aspx
	/// </summary>
	public class Rapportino:AbstractBase
	{
		#region Dichiarazioni

		private string s_Descrizione = string.Empty;
		private ApplicationDataLayer.OracleDataLayer _OraDl;
		#endregion
		
		public string UserName;

		public Rapportino()
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

		public DataTable GetMonth(int anno)
		{
			DataSet _Ds;

			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();
 
			S_Controls.Collections.S_Object s_p_anno = new S_Object();			
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.Integer;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Index = 0;
			s_p_anno.Value=anno; 
			CollezioneControlli.Add(s_p_anno);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;
			CollezioneControlli.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SCHEDULA.Rapportino_GetMesi";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds.Tables[0];			
		}

		public DataSet GetComuni(int anno,string MeseDa, string MeseA)
		{

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			DataSet _Ds;

			S_Controls.Collections.S_Object s_Anno = new S_Object();
			s_Anno.ParameterName = "p_Anno";
			s_Anno.DbType = CustomDBType.Integer;
			s_Anno.Direction = ParameterDirection.Input;
			s_Anno.Index = 0;
			s_Anno.Value = anno;
			CollezioneControlli.Add(s_Anno);

			S_Controls.Collections.S_Object s_Mese1 = new S_Object();
			s_Mese1.ParameterName = "Mese1";
			s_Mese1.DbType = CustomDBType.VarChar;
			s_Mese1.Direction = ParameterDirection.Input;
			s_Mese1.Index = 1;
			s_Mese1.Size=50;
			s_Mese1.Value = MeseDa;
			CollezioneControlli.Add(s_Mese1);

			S_Controls.Collections.S_Object s_Mese2 = new S_Object();
			s_Mese2.ParameterName = "Mese2";
			s_Mese2.DbType = CustomDBType.VarChar;
			s_Mese2.Direction = ParameterDirection.Input;
			s_Mese2.Index = 2;
			s_Mese2.Size=50;
			s_Mese2.Value = MeseA;
			CollezioneControlli.Add(s_Mese2);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 3;
			CollezioneControlli.Add(s_Cursor);
			
			string s_StrSql = "PACK_SCHEDULA.Rapportino_GetComuni";
	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}	

		public DataSet GetEdifici(int anno, int id_comune,string Mese1,string Mese2,string username)
		{

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			DataSet _Ds;

			S_Controls.Collections.S_Object s_Anno = new S_Object();
			s_Anno.ParameterName = "p_anno";
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

			S_Controls.Collections.S_Object s_Mese1 = new S_Object();
			s_Mese1.ParameterName = "Mese1";
			s_Mese1.DbType = CustomDBType.VarChar;
			s_Mese1.Direction = ParameterDirection.Input;
			s_Mese1.Index = 1;
			s_Mese1.Size=50;
			s_Mese1.Value = Mese1;
			CollezioneControlli.Add(s_Mese1);

			S_Controls.Collections.S_Object s_Mese2 = new S_Object();
			s_Mese2.ParameterName = "Mese2";
			s_Mese2.DbType = CustomDBType.VarChar;
			s_Mese2.Direction = ParameterDirection.Input;
			s_Mese2.Index = 2;
			s_Mese2.Size=50;
			s_Mese2.Value = Mese2;
			CollezioneControlli.Add(s_Mese2);

			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_username";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = CollezioneControlli.Count;
			p.Size=20;
			p.Value=username;						
			CollezioneControlli.Add(p);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 3;
			CollezioneControlli.Add(s_Cursor);
			
			string s_StrSql = "PACK_SCHEDULA.Rapportino_GetEdifici";
	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}	
	
		public DataSet GetServizi(int anno, int id_comune, int id_edificio,string Mese1,string Mese2)
		{

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			DataSet _Ds;

			S_Controls.Collections.S_Object s_Anno = new S_Object();
			s_Anno.ParameterName = "p_Anno";
			s_Anno.DbType = CustomDBType.Integer;
			s_Anno.Direction = ParameterDirection.Input;
			s_Anno.Index = 0;
			s_Anno.Size=50;
			s_Anno.Value = anno;
			CollezioneControlli.Add(s_Anno);

			S_Controls.Collections.S_Object s_idcomune = new S_Object();
			s_idcomune.ParameterName = "p_comune";
			s_idcomune.DbType = CustomDBType.Integer;
			s_idcomune.Direction = ParameterDirection.Input;
			s_idcomune.Index = 1;
			s_idcomune.Size=50;
			s_idcomune.Value = id_comune;
			CollezioneControlli.Add(s_idcomune);

			S_Controls.Collections.S_Object s_idedif = new S_Object();
			s_idedif.ParameterName = "p_edificio";
			s_idedif.DbType = CustomDBType.Integer;
			s_idedif.Direction = ParameterDirection.Input;
			s_idedif.Index = 2;
			s_idedif.Size=50;
			s_idedif.Value = id_edificio;
			CollezioneControlli.Add(s_idedif);

			S_Controls.Collections.S_Object s_Mese1 = new S_Object();
			s_Mese1.ParameterName = "Mese1";
			s_Mese1.DbType = CustomDBType.VarChar;
			s_Mese1.Direction = ParameterDirection.Input;
			s_Mese1.Index = 3;
			s_Mese1.Size=50;
			s_Mese1.Value = Mese1;
			CollezioneControlli.Add(s_Mese1);

			S_Controls.Collections.S_Object s_Mese2 = new S_Object();
			s_Mese2.ParameterName = "Mese2";
			s_Mese2.DbType = CustomDBType.VarChar;
			s_Mese2.Direction = ParameterDirection.Input;
			s_Mese2.Index =4;
			s_Mese2.Size=50;
			s_Mese2.Value = Mese2;
			CollezioneControlli.Add(s_Mese2);

			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index =4;
			s_p_username.Size=50;
			s_p_username.Value = System.Web.HttpContext.Current.User.Identity.Name;;
			CollezioneControlli.Add(s_p_username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 5;
			CollezioneControlli.Add(s_Cursor);
			

			string s_StrSql = "PACK_SCHEDULA.Rapportino_GetServizi";
	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}		

		public DataSet GetAddetti(int anno, int id_comune, int id_edificio,int id_servizio ,string Mese1,string Mese2)
		{

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			DataSet _Ds;

			S_Controls.Collections.S_Object s_Anno = new S_Object();
			s_Anno.ParameterName = "p_Anno";
			s_Anno.DbType = CustomDBType.Integer;
			s_Anno.Direction = ParameterDirection.Input;
			s_Anno.Index = 0;
			s_Anno.Value = anno;
			CollezioneControlli.Add(s_Anno);

			S_Controls.Collections.S_Object s_idcomune = new S_Object();
			s_idcomune.ParameterName = "p_comune";
			s_idcomune.DbType = CustomDBType.Integer;
			s_idcomune.Direction = ParameterDirection.Input;
			s_idcomune.Index = 1;
			s_idcomune.Value = id_comune;
			CollezioneControlli.Add(s_idcomune);

			S_Controls.Collections.S_Object s_idedif = new S_Object();
			s_idedif.ParameterName = "p_edificio";
			s_idedif.DbType = CustomDBType.Integer;
			s_idedif.Direction = ParameterDirection.Input;
			s_idedif.Index = 2;
			s_idedif.Value = id_edificio;
			CollezioneControlli.Add(s_idedif);

			S_Controls.Collections.S_Object s_p_servizio = new S_Object();
			s_p_servizio.ParameterName = "p_servizio";
			s_p_servizio.DbType = CustomDBType.Integer;
			s_p_servizio.Direction = ParameterDirection.Input;
			s_p_servizio.Index = 3;
			s_p_servizio.Value = id_servizio;
			CollezioneControlli.Add(s_p_servizio);

			S_Controls.Collections.S_Object s_Mese1 = new S_Object();
			s_Mese1.ParameterName = "Mese1";
			s_Mese1.DbType = CustomDBType.VarChar;
			s_Mese1.Direction = ParameterDirection.Input;
			s_Mese1.Index = 4;
			s_Mese1.Size=50;
			s_Mese1.Value = Mese1;
			CollezioneControlli.Add(s_Mese1);

			S_Controls.Collections.S_Object s_Mese2 = new S_Object();
			s_Mese2.ParameterName = "Mese2";
			s_Mese2.DbType = CustomDBType.VarChar;
			s_Mese2.Direction = ParameterDirection.Input;
			s_Mese2.Index =5;
			s_Mese2.Size=50;
			s_Mese2.Value = Mese2;
			CollezioneControlli.Add(s_Mese2);

			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index =4;
			s_p_username.Size=50;
			s_p_username.Value = System.Web.HttpContext.Current.User.Identity.Name;;
			CollezioneControlli.Add(s_p_username);


			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 5;
			CollezioneControlli.Add(s_Cursor);
			
			string s_StrSql = "PACK_SCHEDULA.Rapportino_GetAddetti";
	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
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
			string s_StrSql = "PACK_SCHEDULA.Rapportino_RicercaPaging";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	 
		}		

		public  DataSet GetDataSel(S_ControlsCollection CollezioneControlli)
		{
	
			DataSet _Ds;

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count+1;
			CollezioneControlli.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SCHEDULA.Rapportino_Ricerca";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	 
		}	

		// metodo che fa il count
		public int getCount(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count+1;
			CollezioneControlli.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SCHEDULA.Rapportino_RicercaCount";	

			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();		
	
			return  int.Parse(_Ds.Tables[0].Rows[0][0].ToString());
		}

		#endregion


		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			return 0;
		}

		#endregion
	}
}
