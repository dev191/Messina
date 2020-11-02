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
using System.Web.Security;

namespace WebCad.Classi
{
	/// <summary>
	/// Descrizione di riepilogo per Utente.
	/// </summary>
	public class Utente : AbstractBase
	{
		#region Dichiarazioni

		private string s_Name = string.Empty;
        private string username=string.Empty;
		#endregion

		public Utente()	{}

		public Utente(int Id)	: this(Id, string.Empty) {}

		public Utente(int Id, string Name) 
		{
			this.Id = Id;
			this.Name = Name;
		}
		public Utente(string UserName)
		{
		 username=UserName;
		}
		#region Metodi Pubblici
		/// <summary>
		/// Restituisce un DataSet contenete un recordset che descrive se può leggere Navigazione Servizi
		/// </summary>
		/// <returns></returns>
		public DataSet GetMap()
		{
			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Value = this.username;
			s_UserName.Index =0;
						
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SColl.Add(s_UserName);
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			DataSet _MyDs = _OraDl.GetRows(_SColl, "PACK_UTENTI.SP_GETVISIBLEMAP").Copy();

			return _MyDs;
		}

		/// <summary>
		/// Ritorna l'esito della procedura di autenticazione passando la pagina
		/// </summary>
		/// <returns></returns>
		public int Login(Page LoginPage)
		{
			S_ControlsCollection _SColl = new S_ControlsCollection();
			_SColl.AddItems(LoginPage.Controls);

            return Login(_SColl);

//			S_Controls.Collections.S_Object s_Cursor = new S_Object();
//			s_Cursor.ParameterName = "IO_CURSOR";
//			s_Cursor.DbType = CustomDBType.Cursor;
//			s_Cursor.Direction = ParameterDirection.Output;
//			s_Cursor.Index = 2;
//			_SColl.Add(s_Cursor);
//
//			_SColl.SortByDBIndex();
//			
//			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
//
//			DataSet _MyDs = _OraDl.GetRows(_SColl, "PACK_UTENTI.SP_AUTENTICA_UTENTI").Copy();
//
//			if (_MyDs.Tables[0].Rows.Count > 0)
//				return Convert.ToInt32(_MyDs.Tables[0].Rows[0]["UTENTE_ID"].ToString());
//			else
//				return 0;
		}
		/// <summary>
		/// Ritorna l'esito della procedura di autenticazione passando i Parametri
		/// </summary>
		/// <returns></returns> 
		public int Login(S_ControlsCollection _SColl)
		{
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 2;
			_SColl.Add(s_Cursor);

			_SColl.SortByDBIndex();
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			DataSet _MyDs = _OraDl.GetRows(_SColl, "PACK_UTENTI.SP_AUTENTICA_UTENTI").Copy();

			if (_MyDs.Tables[0].Rows.Count > 0)
				return Convert.ToInt32(_MyDs.Tables[0].Rows[0]["UTENTE_ID"].ToString());
			else
				return 0;
		}
		/// <summary>
		/// Cambio della Password
		/// </summary>
		/// <param name="_SColl"></param>
		/// <returns></returns>
		public int ChangePassword(S_ControlsCollection _SColl)
		{

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = 2;
			_SColl.Add(s_IdOut);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(_SColl, "PACK_UTENTI.SP_EXECUTECHANGEPASSWORD");
			
			return i_Result;

		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="UserName"></param>
		/// <returns></returns>
		public string[] GetRuoli(string UserName)
		{
			// crea un String array da stored data
			ArrayList a_userRoles = new ArrayList();

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_UserId = new S_Object();
			s_UserId.ParameterName = "p_utente_id";
			s_UserId.DbType = CustomDBType.Integer;
			s_UserId.Direction = ParameterDirection.Input;
			s_UserId.Value = 0;
			s_UserId.Index = 0;

			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Value = UserName;
			s_UserName.Index = 1;
						
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 2;

			_SColl.Add(s_UserId);
			_SColl.Add(s_UserName);
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			DataSet _MyDs = _OraDl.GetRows(_SColl, "PACK_UTENTI.SP_RUOLI_UTENTI").Copy();

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				foreach (DataRow _Dr in _MyDs.Tables[0].Rows )
				{
					a_userRoles.Add(_Dr["DESCRIZIONE"].ToString());
				}
			}

			return (String[]) a_userRoles.ToArray(typeof(String));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="UserName"></param>
		/// <returns></returns>
		public DataSet GetRuoli(int itemId)
		{
			
			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_UserId = new S_Object();
			s_UserId.ParameterName = "p_utente_id";
			s_UserId.DbType = CustomDBType.Integer;
			s_UserId.Direction = ParameterDirection.Input;
			s_UserId.Value = itemId;
			s_UserId.Index = 0;

			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Value = " ";
			s_UserName.Index = 1;
						
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 2;

			_SColl.Add(s_UserId);
			_SColl.Add(s_UserName);
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			DataSet _MyDs = _OraDl.GetRows(_SColl, "PACK_UTENTI.SP_RUOLI_UTENTI").Copy();

			return _MyDs;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string GetUserRolesFromTicket()
		{
			System.Web.HttpContext context = System.Web.HttpContext.Current;
			System.Web.Security.FormsAuthenticationTicket ticket = System.Web.Security.FormsAuthentication.Decrypt(context.Request.Cookies[FormsAuthentication.FormsCookieName].Value);

			string userRoles = string.Empty;

			foreach (String role in ticket.UserData.Split( new char[] {';'} )) 
			{
				if (role.Length > 0)
					userRoles += "'" + role + "',";
			}

			return userRoles.Substring(0, (userRoles.Length - 1));
		}

		/// <summary>
		/// DataSet con tutti i record
		/// </summary>
		/// <returns></returns>
		public override DataSet GetData()
		{			
			DataSet _Ds;
			
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 0;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_UTENTI.SP_GETALLUTENTI";	
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
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_UTENTI.SP_GETUTENTI";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public override DataSet GetSingleData(int itemId)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_Utente_Id";
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
			string s_StrSql = "PACK_UTENTI.SP_GETSINGLEUTENTE";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;		
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public int UpdateRuoli(S_ControlsCollection CollezioneControlli, ExecuteType Operazione)
		{
			int i_MaxParametri = CollezioneControlli.Count + 1;			
			
			i_MaxParametri ++;
			
			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

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

			CollezioneControlli.Add(s_CurrentUser);	
			CollezioneControlli.Add(s_Operazione);
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_UTENTI.SP_EXECUTEUTENTIRUOLI");
			
			return i_Result;
		}

		#endregion

		#region Proprietà Pubbliche


		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get {return s_Name;}
			set {s_Name = value;}
		}

		#endregion
	
		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			int i_MaxParametri = CollezioneControlli.Count + 1;			

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_Id";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = i_MaxParametri;
			s_IdIn.Value = itemId;		
			
			i_MaxParametri ++;
			
			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

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

			CollezioneControlli.Add(s_IdIn);	
			CollezioneControlli.Add(s_CurrentUser);	
			CollezioneControlli.Add(s_Operazione);
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_UTENTI.SP_EXECUTEUTENTI");

//			if (_MyDs.Tables[0].Rows.Count > 0)
//				return Convert.ToInt32(_MyDs.Tables[0].Rows[0]["UTENTE_ID"].ToString());
//			else
//				return 0;

			return i_Result;
		}

		#endregion
	}
}
