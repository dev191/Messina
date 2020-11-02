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

namespace WebCad.Classi.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per DatiApparecchiatura.
	/// </summary>
	public class DatiApparecchiatura : AbstractBase
	{
		string s_username=string.Empty; 
		public DatiApparecchiatura(string UserName)
		{
			s_username=UserName;
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
		/// 
		/// </summary>
		/// <returns></returns>
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			return null;	
		}

		public override DataSet GetSingleData(int itemId)
		{
			return null;	
		}
		/// <summary>
		/// Recupera le apparecchiature legate ad un edificio
		/// </summary>
		/// <param name="itemId">è il ID BL dell'edificio</param>
		/// <returns></returns>
		public  DataSet GetApparecchiature(int itemId,int id_servizio,int id_piano,int id_stanza,int id_stapp,int id_codapp)
		{
			DataSet _Ds;		
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id = new S_Controls.Collections.S_Object();
			s_p_id.ParameterName = "p_id";
			s_p_id.DbType = CustomDBType.Integer;
			s_p_id.Direction = ParameterDirection.Input;
			s_p_id.Index = CollezioneControlli.Count + 1 ;
			s_p_id.Value = itemId;			
			CollezioneControlli.Add(s_p_id);

			S_Controls.Collections.S_Object s_p_id_servizio = new S_Controls.Collections.S_Object();
			s_p_id_servizio.ParameterName = "p_id_servizio";
			s_p_id_servizio.DbType = CustomDBType.Integer;
			s_p_id_servizio.Direction = ParameterDirection.Input;
			s_p_id_servizio.Index = CollezioneControlli.Count + 1;
			s_p_id_servizio.Value = id_servizio;			
			CollezioneControlli.Add(s_p_id_servizio);

			S_Controls.Collections.S_Object s_p_id_piano = new S_Controls.Collections.S_Object();
			s_p_id_piano.ParameterName = "p_id_piano";
			s_p_id_piano.DbType = CustomDBType.Integer;
			s_p_id_piano.Direction = ParameterDirection.Input;
			s_p_id_piano.Index = CollezioneControlli.Count + 1;
			s_p_id_piano.Value = id_piano;			
			CollezioneControlli.Add(s_p_id_piano);

			S_Controls.Collections.S_Object s_p_id_stanza = new S_Controls.Collections.S_Object();
			s_p_id_stanza.ParameterName = "p_id_stanza";
			s_p_id_stanza.DbType = CustomDBType.Integer;
			s_p_id_stanza.Direction = ParameterDirection.Input;
			s_p_id_stanza.Index = CollezioneControlli.Count + 1;
			s_p_id_stanza.Value = id_stanza;			
			CollezioneControlli.Add(s_p_id_stanza);

			S_Controls.Collections.S_Object s_p_id_stapp = new S_Controls.Collections.S_Object();
			s_p_id_stapp.ParameterName = "p_id_stappar";
			s_p_id_stapp.DbType = CustomDBType.Integer;
			s_p_id_stapp.Direction = ParameterDirection.Input;
			s_p_id_stapp.Index = CollezioneControlli.Count + 1;
			s_p_id_stapp.Value = id_stapp;			
			CollezioneControlli.Add(s_p_id_stapp);

			S_Controls.Collections.S_Object s_p_id_codapp = new S_Controls.Collections.S_Object();
			s_p_id_codapp.ParameterName = "p_id_codapp";
			s_p_id_codapp.DbType = CustomDBType.Integer;
			s_p_id_codapp.Direction = ParameterDirection.Input;
			s_p_id_codapp.Index = CollezioneControlli.Count + 1;
			s_p_id_codapp.Value = id_codapp;			
			CollezioneControlli.Add(s_p_id_codapp);


			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DATITECNICIAPP.SP_GETAPPARECCHIATURE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}
		/// <summary>
		/// Recupera l'apparecchiatura dall'id della apparecchiatura
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public  DataSet GetApparecchiatura(int itemId)
		{
			DataSet _Ds;		
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id = new S_Controls.Collections.S_Object();
			s_p_id.ParameterName = "p_id";
			s_p_id.DbType = CustomDBType.Integer;
			s_p_id.Direction = ParameterDirection.Input;
			s_p_id.Index = CollezioneControlli.Count + 1;
			s_p_id.Value = itemId;			
			CollezioneControlli.Add(s_p_id);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DATITECNICIAPP.SP_GETAPPARECCHIATURA";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}
		public DataSet GetStdApparechiature(S_ControlsCollection CollezioneControlli)
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
			string s_StrSql = "PACK_DATITECNICIAPP.SP_GETSTDAPPARECCHIATURE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}
		/// <summary>
		/// Ritorna la Lista dei Macro Componenti
		/// </summary>
		/// <returns></returns>
		public DataSet GetMacroComponenti()
		{
			S_ControlsCollection CollezioneControlli= new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DATITECNICIAPP.SP_GETMACROCOMPONENTI";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}
        /// <summary>
        /// Ritorna il totale delle apparechiature
        /// </summary>
        /// <param name="id_bl"></param>
        /// <returns></returns>
		public DataSet GetCountApparecchiature(int id_bl,int eq_std, string piano)
		{
			DataSet _Ds;		
			S_ControlsCollection CollezioneControlli= new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_bl = new S_Object();
			s_p_id_bl.ParameterName = "p_id_bl";
			s_p_id_bl.DbType = CustomDBType.Integer;
			s_p_id_bl.Direction = ParameterDirection.Input;
			s_p_id_bl.Index = CollezioneControlli.Count + 1;
			s_p_id_bl.Value = id_bl;			
			CollezioneControlli.Add(s_p_id_bl);

			S_Controls.Collections.S_Object s_p_eq_std = new S_Object();
			s_p_eq_std.ParameterName = "p_eq_std";
			s_p_eq_std.DbType = CustomDBType.Integer;
			s_p_eq_std.Direction = ParameterDirection.Input;
			s_p_eq_std.Index = CollezioneControlli.Count + 1;
			s_p_eq_std.Value = eq_std;			
			CollezioneControlli.Add(s_p_eq_std);
			
			S_Controls.Collections.S_Object s_p_piano = new S_Object();
			s_p_piano.ParameterName = "p_piano";
			s_p_piano.DbType = CustomDBType.VarChar;
			s_p_piano.Direction = ParameterDirection.Input;
			s_p_piano.Index = CollezioneControlli.Count + 1;
			s_p_piano.Value = piano;			
			CollezioneControlli.Add(s_p_piano);




			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DATITECNICIAPP.SP_GETCOUNTAPPARECCHIATURE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}
		
		/// <summary>
		/// Recupera i servizi legati all'edificio in base all'id dell'edificio
		/// </summary>
		/// <param name="idbl"></param>
		/// <returns></returns>
		public DataSet GetServiziEdifici(int idbl)
		{
					
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_bl = new S_Object();
			s_p_id_bl.ParameterName = "p_id_bl";
			s_p_id_bl.DbType = CustomDBType.Integer;
			s_p_id_bl.Direction = ParameterDirection.Input;
			s_p_id_bl.Index = CollezioneControlli.Count + 1;
			s_p_id_bl.Value = idbl;			
			CollezioneControlli.Add(s_p_id_bl);

			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_ruolo";
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
			string s_StrSql = "PACK_DATITECNICIAPP.SP_GETSERVIZIEDIFICI";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;
		}
		public DataSet GetAllServiziEdifici(int idbl)
		{
					
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_bl = new S_Object();
			s_p_id_bl.ParameterName = "p_id_bl";
			s_p_id_bl.DbType = CustomDBType.Integer;
			s_p_id_bl.Direction = ParameterDirection.Input;
			s_p_id_bl.Index = CollezioneControlli.Count + 1;
			s_p_id_bl.Value = idbl;			
			CollezioneControlli.Add(s_p_id_bl);

			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_ruolo";
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
			string s_StrSql = "PACK_DATITECNICIAPP.SP_GETALLSERVIZIEDIFICI";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;
		}


		public DataSet GetDateServiziEdifici(S_ControlsCollection CollezioneControlli)
		{
			
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DATITECNICIAPP.SP_GETDATESERVIZIEDIFICI";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;
		}


		public DataSet GetCondizione(int idcondizione)
		{
					
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id = new S_Object();
			s_p_id.ParameterName = "p_id";
			s_p_id.DbType = CustomDBType.Integer;
			s_p_id.Direction = ParameterDirection.Input;
			s_p_id.Index = CollezioneControlli.Count + 1;
			s_p_id.Value = idcondizione;			
			CollezioneControlli.Add(s_p_id);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DATITECNICIAPP.SP_GETCONDIZIONE";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;
		}

		public DataSet GetPiani(int idBl)
		{
					
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_bl = new S_Object();
			s_p_id_bl.ParameterName = "p_id_bl";
			s_p_id_bl.DbType = CustomDBType.Integer;
			s_p_id_bl.Direction = ParameterDirection.Input;
			s_p_id_bl.Index = CollezioneControlli.Count + 1;
			s_p_id_bl.Value = idBl;			
			CollezioneControlli.Add(s_p_id_bl);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DATITECNICIAPP.SP_GETPIANI";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;
		}
		public DataSet GetStanze(int idBl,int idPiani)
		{
					
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_bl = new S_Object();
			s_p_id_bl.ParameterName = "p_id_bl";
			s_p_id_bl.DbType = CustomDBType.Integer;
			s_p_id_bl.Direction = ParameterDirection.Input;
			s_p_id_bl.Index = CollezioneControlli.Count + 1;
			s_p_id_bl.Value = idBl;			
			CollezioneControlli.Add(s_p_id_bl);

			S_Controls.Collections.S_Object s_p_id_piani = new S_Object();
			s_p_id_piani.ParameterName = "p_id_piani";
			s_p_id_piani.DbType = CustomDBType.Integer;
			s_p_id_piani.Direction = ParameterDirection.Input;
			s_p_id_piani.Index = CollezioneControlli.Count + 1;
			s_p_id_piani.Value = idPiani;			
			CollezioneControlli.Add(s_p_id_piani);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DATITECNICIAPP.SP_GETSTANZE";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;
		}

		public DataSet GetVenditore(int idvenditore)
		{
					
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id = new S_Object();
			s_p_id.ParameterName = "p_id";
			s_p_id.DbType = CustomDBType.Integer;
			s_p_id.Direction = ParameterDirection.Input;
			s_p_id.Index = CollezioneControlli.Count + 1;
			s_p_id.Value = idvenditore;			
			CollezioneControlli.Add(s_p_id);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DATITECNICIAPP.SP_GETVENDITORE";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

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
			s_p_operazione.DbType = CustomDBType.Integer;
			s_p_operazione.Direction = ParameterDirection.Input;
			s_p_operazione.Index = CollezioneControlli.Count + 1;
			
			if (Operazione==ExecuteType.Update)
			{
				s_p_operazione.Value = 2;
			}
			else if (Operazione==ExecuteType.Insert)
			{
				s_p_operazione.Value = 1;
			}
			else if (Operazione==ExecuteType.Delete)
			{
				s_p_operazione.Value = 3;
			}
			CollezioneControlli.Add(s_p_operazione);

			S_Controls.Collections.S_Object s_p_CurrentUser = new S_Controls.Collections.S_Object();
			s_p_CurrentUser.ParameterName = "p_username";
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
			int i_Result=0;
            if (Operazione!=ExecuteType.Delete)
			 i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_DATITECNICIAPP.SP_EXECUTEAPPARECCHIATURA");
            else
			 i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_DATITECNICIAPP.SP_DELETEAPPARECCHIATURA");
				
			return i_Result;
			//_____________________________________________________________________________________
		}

		#endregion
	}
}
