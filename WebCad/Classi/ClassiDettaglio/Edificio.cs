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

namespace WebCad.Classi.ClassiDettaglio
{
	/// <summary>
	/// Descrizione di riepilogo per Edificio.
	/// </summary>
	public class Edificio : AbstractBase
	{
		#region Dichiarazioni

		private string s_BL_ID = string.Empty;
		private string s_Name = string.Empty;
		private string s_Campus = string.Empty;
		private string s_City_Id = string.Empty;
		private string s_Address1 = string.Empty;
		private string s_Option2 = string.Empty;
		private string s_Contact_Name = string.Empty;
		private string s_Contact_Phone = string.Empty;
		private string s_Centro_Costo = string.Empty;

		#endregion


		private string Username;

		public Edificio(string username) 
		{
			this.Username=username;
		}
		public Edificio(int Id, string BlId, string username) 
		{
			this.Id = Id;
			this.BlId = BlId;
			this.Username=username;
		}

		#region Metodi Pubblici

		/// <summary>
		/// DataSet con tutti i record
		/// </summary>
		/// <returns></returns>
		public override DataSet GetData()
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

			S_Controls.Collections.S_Object s_User = new S_Controls.Collections.S_Object();
			s_User.ParameterName = "p_Username";
			s_User.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_User.Direction = ParameterDirection.Input;
			s_User.Size=50; 
			s_User.Index = 1;
			s_User.Value = this.Username;
			CollezioneControlli.Add(s_User);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_EDIFICI.SP_GETEDIFICI";
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
			return null;	
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public DataSet GetSingleData(string itemId)
		{
			DataSet _Ds;
			///Istanzio un nuovo oggetto Collection per aggiungere i parametri
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object s_bl_id = new S_Controls.Collections.S_Object();
			s_bl_id.ParameterName = "p_Bl_Id";
			s_bl_id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_bl_id.Direction = ParameterDirection.Input;
			s_bl_id.Size =8;
			s_bl_id.Index = 0;
			s_bl_id.Value = itemId;
			_SCollection.Add (s_bl_id);

			S_Controls.Collections.S_Object s_User = new S_Controls.Collections.S_Object();
			s_User.ParameterName = "p_Username";
			s_User.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_User.Direction = ParameterDirection.Input;
			s_User.Size=50; 
			s_User.Index = 1;
			s_User.Value = this.Username;
			_SCollection.Add(s_User);

			S_Controls.Collections.S_Object s_Campus = new S_Controls.Collections.S_Object();
			s_Campus.ParameterName = "p_Campus";
			s_Campus.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_Campus.Direction = ParameterDirection.Input;
			s_Campus.Size=50; 
			s_Campus.Index = 2;
			s_Campus.Value = "";
			_SCollection.Add(s_Campus);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = _SCollection.Count + 1;

			_SCollection.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_EDIFICI.SP_GETEDIFICI";
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;	
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="BlId"></param>
		/// <returns></returns>
		public DataSet GetApparecchiature(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = 2;
			s_UserName.Value = this.Username;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_APPARECCHIATURE.SP_GETAPPARECCHIATURE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			this.BlId = BlId;
			return _Ds;		
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="BlId"></param>
		/// <returns></returns>
		public DataSet GetApparecchiature(string BlId, int Servizioid)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_BlId = new S_Object();
			s_BlId.ParameterName = "p_Bl_Id";
			s_BlId.DbType = CustomDBType.VarChar;
			s_BlId.Direction = ParameterDirection.Input;
			s_BlId.Index = 0;
			s_BlId.Value = BlId;
			_SColl.Add(s_BlId);

			S_Controls.Collections.S_Object s_Servizio = new S_Object();
			s_Servizio.ParameterName = "p_Servizio";
			s_Servizio.DbType = CustomDBType.Integer;
			s_Servizio.Direction = ParameterDirection.Input;
			s_Servizio.Index = 1;
			s_Servizio.Value = Servizioid;
			_SColl.Add(s_Servizio);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = _SColl.Count +1;
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_APPARECCHIATURE.SP_GETAPPARECCHIATURE";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.BlId = BlId;
			return _Ds;		
		}

		/// <summary>
		/// Ritornano le singole apparecchiature
		/// </summary>
		/// <param name="CollezioneControlli"> Viene passata la collezione dei parametri</param>
		/// <returns>Ritorna un DataSet</returns>
		public DataSet GetSingleApparecchiature(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = CollezioneControlli.Count + 1;;
			s_UserName.Value = this.Username;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_APPARECCHIATURE.SP_GETSINGLEAPPARECCHIATURA";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			this.BlId = BlId;
			return _Ds;		
		}
		#endregion
		public  DataSet GetListaEdifici(S_ControlsCollection CollezioneControlli,int itemId)
		{

			DataSet _Ds;	

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			int i_MaxParametri = CollezioneControlli.Count + 1;			

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_ruolo_id";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = i_MaxParametri;
			s_IdIn.Value = itemId;

			CollezioneControlli.Add(s_IdIn);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_EDIFICI.SP_GETLISTAEDIFICI";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}

		public DataSet GetRuoliEdifici(int idRuolo)
		{
			DataSet _Ds;
			
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_id = new S_Object();
			s_id.ParameterName = "p_Ruolo_id";
			s_id.DbType = CustomDBType.Integer;
			s_id.Direction = ParameterDirection.Input;
			s_id.Index = 0;
			s_id.Value = idRuolo;						
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			CollezioneControlli.Add(s_id);
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_EDIFICI.SP_GETRUOLIEDIFICI";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}

		public DataSet GetRuoliEdifici(S_ControlsCollection CollezioneControlli,int itemId,string tipo)
		{
			DataSet _Ds=null;	

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			int i_MaxParametri = CollezioneControlli.Count + 1;			

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_ruolo_id";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = i_MaxParametri;
			s_IdIn.Value = itemId;

			CollezioneControlli.Add(s_IdIn);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			
			string s_StrSql="";
			
			if (tipo=="Tutti")
			{
				s_StrSql = "PACK_EDIFICI.SP_GETRUOLIEDIFICIFILTRER";
			}
			if (tipo=="Associati")
			{
				s_StrSql = "PACK_EDIFICI.SP_GETRUOLIBLSERVIZIASSOCIATI";
			}
			if (tipo=="NonAssociati")
			{
				s_StrSql = "PACK_EDIFICI.SP_GETRUOLIBLSERVIZINASSOCIATI";
			}
			
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}

		public int UpdateRuoliEdifici(S_ControlsCollection CollezioneControlli)
		{	
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_EDIFICI.SP_EXECUTERUOLIEDIFICI");

			return i_Result;		
		}
		public int UpdateRuoliEdificiServizi(S_ControlsCollection CollezioneControlli)
		{	
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_EDIFICI.SP_EXECUTERUOLIEDIFICISERVIZI");

			return i_Result;		
		}

		public bool ControllaRuoloBlServizi(int ruolo_id,int bl_id,int servizio_id)
		{
			DataSet _Ds;
			
			S_Controls.Collections.S_ControlsCollection _SColl = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object s_Ruolo = new S_Controls.Collections.S_Object();
			s_Ruolo.ParameterName = "p_Ruolo_Id";
			s_Ruolo.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_Ruolo.Direction = ParameterDirection.Input;
			s_Ruolo.Index = 0;
			s_Ruolo.Value = ruolo_id;

			S_Controls.Collections.S_Object s_Edificio_Id = new S_Controls.Collections.S_Object();
			s_Edificio_Id.ParameterName = "p_Bl_Id";
			s_Edificio_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_Edificio_Id.Direction = ParameterDirection.Input;
			s_Edificio_Id.Index = 1;
			s_Edificio_Id.Value = bl_id;		
				
			S_Controls.Collections.S_Object s_Servizio_Id = new S_Controls.Collections.S_Object();
			s_Servizio_Id.ParameterName = "p_Servizio_Id";
			s_Servizio_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_Servizio_Id.Direction = ParameterDirection.Input;
			s_Servizio_Id.Index = 2;
			s_Servizio_Id.Value = servizio_id;		

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 3;
			

			_SColl.Add(s_Ruolo);
			_SColl.Add(s_Edificio_Id);
			_SColl.Add(s_Servizio_Id);			
			_SColl.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_EDIFICI.SP_CONTROLLARUOLOBLSERVIZIO";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			
			
			if (_Ds.Tables[0].Rows.Count>0)			
				return true;
			else
				return false;
		}

		#region Proprietà Pubbliche

		/// <summary>
		/// 
		/// </summary>
		public string BlId
		{
			get {return s_BL_ID;}
			set {s_BL_ID = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get {return s_Name;}
			set {s_Name = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Campus
		{
			get {return s_Campus;}
			set {s_Campus = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string City_Id
		{
			get {return s_City_Id;}
			set {s_City_Id = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Address1
		{
			get {return s_Address1;}
			set {s_Address1 = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Option2
		{
			get {return s_Option2;}
			set {s_Option2 = value;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string Contact_Name
		{
			get {return s_Contact_Name;}
			set {s_Contact_Name = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Contact_Phone
		{
			get {return s_Contact_Phone;}
			set {s_Contact_Phone = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Centro_Costo
		{
			get {return s_Centro_Costo;}
			set {s_Centro_Costo = value;}
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

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_EDIFICI.SP_EXECUTEEDIFICI");

			return i_Result;
		}

		#endregion
	}
}
