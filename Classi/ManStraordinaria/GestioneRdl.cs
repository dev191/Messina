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

namespace TheSite.Classi.ManStraordinaria
{
	/// <summary>
	/// Descrizione di riepilogo per GestioneRdl.
	/// Usata dalla form GestioneRdl.aspx
	/// </summary>
	public class GestioneRdl : AbstractBase 
	{
		public GestioneRdl(string Username)
		{
			username=Username;
		}
		private string username=string.Empty;
		
		#region Metodi Pubblici
		/// <summary>
		/// Usata per caricare le ditte in base all'utente loggato.
		/// Tornare le ditte
		/// </summary>
		/// <returns></returns>
		public override DataSet GetData()
		{
			
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index = CollezioneControlli.Count + 1;
			s_p_username.Value =this.username;
			s_p_username.Size=50; 
			CollezioneControlli.Add(s_p_username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_GEST_RDL.SP_GETDITTA";
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
        /// <summary>
        /// Recupero i Gruppi
        /// </summary>
        /// <returns></returns>
		public  DataSet GetGuppo()
		{
			
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_GEST_RDL.SP_GETGRUPPO";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
        /// <summary>
        /// Recupero i Livelli di Urgenza
        /// </summary>
        /// <returns></returns>
		public  DataSet GetUrgenza()
		{
			
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_GEST_RDL.SP_GETURGENZA";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
        /// <summary>
        /// Ricerca le ricchieste con status:
        /// 6	I	Emessa in Lavorazione
		/// 11	HA	Emessa ma Sospesa per Inaccessibilità	
		/// 12	HP	Emessa ma Sospesa per Approvviggionamento 
		/// 13	HL	Emessa ma Sospesa per Intervento Specialistico
        /// </summary>
        /// <param name="CollezioneControlli"></param>
        /// <returns></returns>
		public  override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
						

			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index = CollezioneControlli.Count + 1;
			s_p_username.Value =this.username;
			s_p_username.Size=50; 
			CollezioneControlli.Add(s_p_username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GETCOMPLETAMENTO";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		/// <summary>
		/// Ottine la lista delle contabilizzazioni
		/// </summary>
		/// <returns></returns>
		public  DataSet GetContabilizzazione()
		{
			
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GETCONTABILIZZAZIONE";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		public override DataSet GetSingleData(int itemId)
		{
	      return null;
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
