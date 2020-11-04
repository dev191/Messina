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

namespace TheSite.Classi.ClassiAnagrafiche
{
	/// <summary>
	/// Descrizione di riepilogo per LetturaContatori.
	/// </summary>
	public class LetturaContatori: AbstractBase
	{
		private string s_username;
		public LetturaContatori(string Username)
		{
			this.s_username=Username;
		}
		public LetturaContatori()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
		public override DataSet GetData()
		{
			return null;
		}

		public override DataSet GetSingleData(int id)
		{
			DataSet _Ds;		
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();
		
			S_Controls.Collections.S_Object s_p_id_letture_contatori = new S_Object();
			s_p_id_letture_contatori.ParameterName = "p_id_letture_contatori";
			s_p_id_letture_contatori.DbType = CustomDBType.VarChar;
			s_p_id_letture_contatori.Direction = ParameterDirection.Input;
			s_p_id_letture_contatori.Index = CollezioneControlli.Count + 1;
			s_p_id_letture_contatori.Value = id;			
			s_p_id_letture_contatori.Size = 50;
			CollezioneControlli.Add(s_p_id_letture_contatori);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_LETTURACONTATORI.GETALLLETTURE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
			
		}

		/// <summary>
		/// Metodo che recupera tutte le apparecchiature legate ad l'utente loggato
		/// 
		/// Viene eseguita all'ingresso di ogni pagina la prima volta
		/// </summary>
		/// <param name="CollezioneControlli"> Accetta due parametri in ingressi che sono p_Servizio di tipo number
		/// che indica il servizio e  p_Bl_Id di tipo varchar2 che indica l'edificio
		///  </param>
		/// <returns></returns>
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			//Andrea
//			DataSet _Ds;		
//			
//			S_Controls.Collections.S_Object s_UserName = new S_Object();
//			s_UserName.ParameterName = "p_UserName";
//			s_UserName.DbType = CustomDBType.VarChar;
//			s_UserName.Direction = ParameterDirection.Input;
//			s_UserName.Index = CollezioneControlli.Count + 1;
//			s_UserName.Value = this.s_username;			
//			s_UserName.Size = 50;
//			CollezioneControlli.Add(s_UserName);
//
//			S_Controls.Collections.S_Object s_Cursor = new S_Object();
//			s_Cursor.ParameterName = "IO_CURSOR";
//			s_Cursor.DbType = CustomDBType.Cursor;
//			s_Cursor.Direction = ParameterDirection.Output;
//			s_Cursor.Index = CollezioneControlli.Count + 1;
//
//			CollezioneControlli.Add(s_Cursor);

		//	ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			//string s_StrSql = "PACK_APPARECCHIATURE.SP_GETSTDAPPARECCHIATURE";	
		//	_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
		//	return _Ds;	// Andrea	
			return null;
		}

		public DataSet RicercaApparecchiaturaPS(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = CollezioneControlli.Count;
			s_UserName.Value = this.s_username;			
			s_UserName.Size = 50;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_LETTURACONTATORI.SP_RICERCAAPPARECCHIATURAPS";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		public DataSet RicercaApparecchiaturaPSPaging(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = CollezioneControlli.Count;
			s_UserName.Value = this.s_username;			
			s_UserName.Size = 50;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_LETTURACONTATORI.SP_RICERCAAPPAPaging";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		public int RicercaApparecchiaturaPSCount(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = CollezioneControlli.Count;
			s_UserName.Value = this.s_username;			
			s_UserName.Size = 50;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_LETTURACONTATORI.SP_RICERCAAPPACount";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return int.Parse(_Ds.Tables[0].Rows[0][0].ToString());
		}
		public DataSet RicercaApparecchiatura(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = CollezioneControlli.Count + 1;
			s_UserName.Value = this.s_username;			
			s_UserName.Size = 50;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_LETTURACONTATORI.SP_RICERCAAPPARECCHIATURA";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		
		

		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			// UTENTE

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_username";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = CollezioneControlli.Count;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;
			
			CollezioneControlli.Add(s_CurrentUser);	
	
			
			// TIPO OPERAZIONE

			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_operazione";
			s_Operazione.DbType = CustomDBType.VarChar;
			s_Operazione.Direction = ParameterDirection.Input;
			s_Operazione.Index = CollezioneControlli.Count;
			s_Operazione.Value = Operazione.ToString();

			CollezioneControlli.Add(s_Operazione);

			// OUT

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = CollezioneControlli.Count;		
			
			CollezioneControlli.Add(s_IdOut);


			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			object i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_LETTURACONTATORI.SP_EXECUTELETTURA");
				
			return System.Convert.ToInt32(i_Result);
		}

		#endregion

			

	}
}

