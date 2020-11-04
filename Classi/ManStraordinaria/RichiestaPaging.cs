


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


namespace TheSite.Classi.ManOrdinaria
{
	/// <summary>
	/// Descrizione di riepilogo per Richiesta.
	/// </summary>
	public class RichiestaPaging : AbstractBase
	{
		public RichiestaPaging()
		{
			
		}

		public RichiestaPaging(int Id) 
		{
			this.Id = Id;			
		}

		#region Metodi Pubblici

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
			string s_StrSql = "PACK_MAN_ORD.SP_GETALLRICHIESTE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
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
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GETRICHIESTE";	
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
			s_Id.ParameterName = "p_Wr_Id";
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
			string s_StrSql = "PACK_MAN_ORD.SP_GETSINGLERICHIESTA";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;				
		}

		
		public int Crea(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;

			int i_MaxParametri = CollezioneControlli.Count + 1;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

			i_MaxParametri ++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;

			CollezioneControlli.Add(s_CurrentUser);	
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_CREA";	
			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, s_StrSql);			

			return i_Result;		
		}

		public bool IsValidBlId(string BlId)
		{	
			string s_User = System.Web.HttpContext.Current.User.Identity.Name;

			Classi.ClassiDettaglio.Edificio _Edificio = new 
				TheSite.Classi.ClassiDettaglio.Edificio(s_User);

			S_Controls.Collections.S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_BlId = new S_Object();
			s_BlId.ParameterName = "p_Bl_Id";
			s_BlId.DbType = CustomDBType.VarChar;
			s_BlId.Direction = ParameterDirection.Input;
			s_BlId.Size = 8;
			s_BlId.Index = 0;
			s_BlId.Value = BlId;

			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Size = 50;
			s_UserName.Index = 1;
			s_UserName.Value = s_User;

			S_Controls.Collections.S_Object s_Campus = new S_Object();
			s_Campus.ParameterName = "p_Campus";
			s_Campus.DbType = CustomDBType.VarChar;
			s_Campus.Direction = ParameterDirection.Input;
			s_Campus.Index = 2;
			s_Campus.Size = 128;
			s_Campus.Value = "";
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 3;

			_SColl.Add(s_BlId);
			_SColl.Add(s_UserName);
			_SColl.Add(s_Campus);
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_EDIFICI.SP_GETEDIFICI";	
			if (_OraDl.GetRows(_SColl, s_StrSql).Tables[0].Rows.Count == 1)
				return true;
			else
				return false;

		}

		public  DataSet GetListaRDL(S_ControlsCollection CollezioneControlli,string utente)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_utente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = utente;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);
			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GetListaRDL";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}

		public  DataSet GetStatusRdl(int wr_id)
		{	
			DataSet _Ds;	

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_Wr_Id";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = wr_id;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GETSTATUSRDL";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}


		public DataSet GetAllTipoTrasmissione()
		{
			DataSet _Ds;
			
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_GETALLTIPOTRASMISSIONE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();
			return _Ds;		
		}

		public DataSet GetSingleRdl(int itemId)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_Wr_Id";
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
			string s_StrSql = "PACK_MAN_ORD.SP_GETSINGLERDL";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;				
		}

		public  DataSet GetRDLNonEmesse(string bl_id)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_bl_id = new S_Object();
			s_bl_id.ParameterName = "p_Bl_id";
			s_bl_id.DbType = CustomDBType.VarChar;
			s_bl_id.Direction = ParameterDirection.Input;
			s_bl_id.Index = 0;
			s_bl_id.Value = bl_id;

			_SColl.Add(s_bl_id);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 0;
			_SColl.Add(s_Cursor);
			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GetRDLNonEmesse";
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			return _Ds;	

		}
		public  DataSet GetRDLApprovate(string bl_id)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_bl_id = new S_Object();
			s_bl_id.ParameterName = "p_Bl_id";
			s_bl_id.DbType = CustomDBType.VarChar;
			s_bl_id.Direction = ParameterDirection.Input;
			s_bl_id.Index = 0;
			s_bl_id.Value = bl_id;

			_SColl.Add(s_bl_id);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 0;
			_SColl.Add(s_Cursor);
			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GetRDLApprovate";
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			return _Ds;	

		}

		public DataSet GetStatus()
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_sql = new S_Controls.Collections.S_Object();
			s_p_sql.ParameterName = "p_sql";
			s_p_sql.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_sql.Direction = ParameterDirection.Input;
			s_p_sql.Size =2000;
			s_p_sql.Index = 0;
			s_p_sql.Value = "Select id_status as ID, status_desc as DESCRIZIONE from wr_status where in_ord=1";
			_SCollection.Add(s_p_sql);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SCollection.Add(s_Cursor);

			
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_DYNAMIC_SELECT";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;		
		}

		public DataSet GetStatusAccorpa()
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_sql = new S_Controls.Collections.S_Object();
			s_p_sql.ParameterName = "p_sql";
			s_p_sql.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_sql.Direction = ParameterDirection.Input;
			s_p_sql.Size =2000;
			s_p_sql.Index = 0;
			s_p_sql.Value = "Select id_status as ID, status_desc as DESCRIZIONE from wr_status where in_gest=1";
			_SCollection.Add(s_p_sql);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SCollection.Add(s_Cursor);

			
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_DYNAMIC_SELECT";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;		
		}

		public DataSet GetStatusAnalisi()
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_sql = new S_Controls.Collections.S_Object();
			s_p_sql.ParameterName = "p_sql";
			s_p_sql.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_sql.Direction = ParameterDirection.Input;
			s_p_sql.Size =2000;
			s_p_sql.Index = 0;
			s_p_sql.Value = "Select id_status as ID, status_desc as DESCRIZIONE from wr_status where in_str=1";
			_SCollection.Add(s_p_sql);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SCollection.Add(s_Cursor);

			
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_DYNAMIC_SELECT";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;		
		}

		public DataSet GetAddetti(string NomeCompleto, string BL_ID)
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_NomeCompleto = new S_Controls.Collections.S_Object();
			s_p_NomeCompleto.ParameterName = "p_NomeCompleto";
			s_p_NomeCompleto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_NomeCompleto.Direction = ParameterDirection.Input;
			s_p_NomeCompleto.Size =50;
			s_p_NomeCompleto.Index = 0;
			s_p_NomeCompleto.Value = NomeCompleto;
			_SCollection.Add(s_p_NomeCompleto);			

			S_Controls.Collections.S_Object s_p_BL_ID = new S_Controls.Collections.S_Object();
			s_p_BL_ID.ParameterName = "p_bl_id";
			s_p_BL_ID.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_BL_ID.Direction = ParameterDirection.Input;
			s_p_BL_ID.Size =50;
			s_p_BL_ID.Index = 1;
			s_p_BL_ID.Value = BL_ID;
			_SCollection.Add(s_p_BL_ID);			

			S_Controls.Collections.S_Object s_p_UserName = new S_Controls.Collections.S_Object();
			s_p_UserName.ParameterName = "p_UserName";
			s_p_UserName.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_UserName.Direction = ParameterDirection.Input;
			s_p_UserName.Size =50;
			s_p_UserName.Index = 2;
			s_p_UserName.Value = System.Web.HttpContext.Current.User.Identity.Name;
			_SCollection.Add(s_p_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 3;

			_SCollection.Add(s_Cursor);
			
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GetAddetti";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;		
		}

		public DataSet GetAddetti(string NomeCompleto, string BL_ID,int ditta_id)
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_NomeCompleto = new S_Controls.Collections.S_Object();
			s_p_NomeCompleto.ParameterName = "p_NomeCompleto";
			s_p_NomeCompleto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_NomeCompleto.Direction = ParameterDirection.Input;
			s_p_NomeCompleto.Size =50;	
			s_p_NomeCompleto.Index = 0;
			s_p_NomeCompleto.Value = NomeCompleto;	
			_SCollection.Add(s_p_NomeCompleto);			

			S_Controls.Collections.S_Object s_p_BL_ID = new S_Controls.Collections.S_Object();
			s_p_BL_ID.ParameterName = "p_bl_id";
			s_p_BL_ID.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_BL_ID.Direction = ParameterDirection.Input;
			s_p_BL_ID.Size =50;
			s_p_BL_ID.Index = 1;
			s_p_BL_ID.Value = BL_ID;
			_SCollection.Add(s_p_BL_ID);			

			S_Controls.Collections.S_Object s_p_DITTA_ID = new S_Controls.Collections.S_Object();
			s_p_DITTA_ID.ParameterName = "p_ditta_id";
			s_p_DITTA_ID.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DITTA_ID.Direction = ParameterDirection.Input;
			s_p_DITTA_ID.Size =50;
			s_p_DITTA_ID.Index = 2;
			s_p_DITTA_ID.Value = ditta_id;
			_SCollection.Add(s_p_DITTA_ID);			

			S_Controls.Collections.S_Object s_p_UserName = new S_Controls.Collections.S_Object();
			s_p_UserName.ParameterName = "p_UserName";
			s_p_UserName.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_UserName.Direction = ParameterDirection.Input;
			s_p_UserName.Size =50;
			s_p_UserName.Index = 3;
			s_p_UserName.Value = System.Web.HttpContext.Current.User.Identity.Name;
			_SCollection.Add(s_p_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 4;

			_SCollection.Add(s_Cursor);
			
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			//string s_StrSql = "PACK_MAN_ORD.SP_GetAddetti";	
			string s_StrSql = "PACK_ADDETTI.SP_GETADDETTORUOLO";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;		
		}
		

		public DataSet GetRichiedenti(string NomeCompleto)
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_NomeCompleto = new S_Controls.Collections.S_Object();
			s_p_NomeCompleto.ParameterName = "p_NomeCompleto";
			s_p_NomeCompleto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_NomeCompleto.Direction = ParameterDirection.Input;
			s_p_NomeCompleto.Size =50;
			s_p_NomeCompleto.Index = 0;
			s_p_NomeCompleto.Value = NomeCompleto;
			_SCollection.Add(s_p_NomeCompleto);			

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SCollection.Add(s_Cursor);
			
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GetRichiedenti";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;		
		}

		public DataSet GetRichiedenti(string NomeCompleto, string CognomeCompleto)
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_NomeCompleto = new S_Controls.Collections.S_Object();
			s_p_NomeCompleto.ParameterName = "p_NomeCompleto";
			s_p_NomeCompleto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_NomeCompleto.Direction = ParameterDirection.Input;
			s_p_NomeCompleto.Size =50;
			s_p_NomeCompleto.Index = 0;
			s_p_NomeCompleto.Value = NomeCompleto;
			_SCollection.Add(s_p_NomeCompleto);			

			S_Controls.Collections.S_Object s_p_CognomeCompleto = new S_Controls.Collections.S_Object();
			s_p_CognomeCompleto.ParameterName = "p_CognomeCompleto";
			s_p_CognomeCompleto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_CognomeCompleto.Direction = ParameterDirection.Input;
			s_p_CognomeCompleto.Size =50;
			s_p_CognomeCompleto.Index = 1;
			s_p_CognomeCompleto.Value = CognomeCompleto;
			_SCollection.Add(s_p_CognomeCompleto);			

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 2;

			_SCollection.Add(s_Cursor);
			
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_RICHIEDENTI.SP_GetRichiedenti";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;		
		}


		public  DataSet GetSfogliaRDL(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;	
			if (CollezioneControlli.Count < 18)
			{
				S_Controls.Collections.S_Object s_IdIn = new S_Object();
				s_IdIn.ParameterName = "p_utente";
				s_IdIn.DbType = CustomDBType.VarChar;
				s_IdIn.Direction = ParameterDirection.Input;
				s_IdIn.Index = CollezioneControlli.Count + 1;
				s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;

				CollezioneControlli.Add(s_IdIn);
			
				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = CollezioneControlli.Count + 1;
				CollezioneControlli.Add(s_Cursor);
			
			}
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GetSfogliaRDLPaging";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}
		public int GetCount(S_ControlsCollection CollezioneControlli)
		{
//		    CollezioneControlli.RemoveAt(16);
//			CollezioneControlli.RemoveAt(15);
//				CollezioneControlli.RemoveAt(14);
//				CollezioneControlli.RemoveAt(15);

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_utente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count;
			s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GetSfogliaRDLCount";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();


			return	int.Parse(_Ds.Tables[0].Rows[0][0].ToString());
		}

		public int EmettiRdl(int wr_id,Classi.StateType status_id,string utente,int urgenza_id,string richiedente,string descrizione,string data_pianificata,int servizio_id, int stdApparecchiatura_id, int eq_id, int trasmissione_id,int tipo_mautenzione_id,int bl_id,int addetto_id,int id_ditta)
		{	
			
			S_ControlsCollection _SColl = new S_ControlsCollection();

			// WR_ID
			S_Controls.Collections.S_Object s_IdWR = new S_Object();
			s_IdWR.ParameterName = "p_Wr_Id";
			s_IdWR.DbType = CustomDBType.Integer;
			s_IdWR.Direction = ParameterDirection.Input;
			s_IdWR.Index = 0;
			s_IdWR.Value = wr_id;

			// STATUS_ID
			S_Controls.Collections.S_Object s_IdStatus = new S_Object();
			s_IdStatus.ParameterName = "p_stato";
			s_IdStatus.DbType = CustomDBType.Integer;
			s_IdStatus.Direction = ParameterDirection.Input;
			s_IdStatus.Index = 1;
			s_IdStatus.Value = (int)status_id;			
			
			// UTENTE

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = 2;
			s_CurrentUser.Value = utente;

			// URGENZA

			S_Controls.Collections.S_Object s_Urgenza = new S_Object();
			s_Urgenza.ParameterName = "p_urgenza";
			s_Urgenza.DbType = CustomDBType.Integer;
			s_Urgenza.Direction = ParameterDirection.Input;
			s_Urgenza.Index = 3;
			s_Urgenza.Value = urgenza_id;	

			// RICHIEDENTE

			S_Controls.Collections.S_Object s_Richiedente = new S_Object();
			s_Richiedente.ParameterName = "p_richiedente";
			s_Richiedente.DbType = CustomDBType.VarChar;
			s_Richiedente.Direction = ParameterDirection.Input;
			s_Richiedente.Index = 4;
			s_Richiedente.Value = richiedente;

			// DESCRIZIONE

			S_Controls.Collections.S_Object s_Descrizione = new S_Object();
			s_Descrizione.ParameterName = "p_descrizione";
			s_Descrizione.DbType = CustomDBType.VarChar;
			s_Descrizione.Direction = ParameterDirection.Input;
			s_Descrizione.Index = 5;
			s_Descrizione.Size=4000;
			s_Descrizione.Value = descrizione;

			// DATAPIANIFICATA

			S_Controls.Collections.S_Object s_DataP = new S_Object();
			s_DataP.ParameterName = "p_datapianificata";
			s_DataP.DbType = CustomDBType.VarChar;
			s_DataP.Direction = ParameterDirection.Input;
			s_DataP.Index = 6;			
			s_DataP.Size=30;
			s_DataP.Value = data_pianificata;

			// SERVIZIO

			S_Controls.Collections.S_Object s_Servizio = new S_Object();
			s_Servizio.ParameterName = "p_servizio_id";
			s_Servizio.DbType = CustomDBType.Integer;
			s_Servizio.Direction = ParameterDirection.Input;
			s_Servizio.Index = 7;
			s_Servizio.Value = servizio_id;

			// TRASMISSIONE

			S_Controls.Collections.S_Object s_Trasmissione = new S_Object();
			s_Trasmissione.ParameterName = "p_trasmissione_id";
			s_Trasmissione.DbType = CustomDBType.Integer;
			s_Trasmissione.Direction = ParameterDirection.Input;
			s_Trasmissione.Index = 8;
			s_Trasmissione.Value = trasmissione_id;

			// MANUTENZIONE

			S_Controls.Collections.S_Object s_Manutenzione = new S_Object();
			s_Manutenzione.ParameterName = "p_manutenzione_id";
			s_Manutenzione.DbType = CustomDBType.Integer;
			s_Manutenzione.Direction = ParameterDirection.Input;
			s_Manutenzione.Index = 9;
			s_Manutenzione.Value = tipo_mautenzione_id;

			// BL_ID

			S_Controls.Collections.S_Object s_BL = new S_Object();
			s_BL.ParameterName = "p_bl_id";
			s_BL.DbType = CustomDBType.Integer;
			s_BL.Direction = ParameterDirection.Input;
			s_BL.Index = 10;
			s_BL.Value = bl_id;

			// ADDETTO_ID

			S_Controls.Collections.S_Object s_Addetto = new S_Object();
			s_Addetto.ParameterName = "p_addetto_id";
			s_Addetto.DbType = CustomDBType.Integer;
			s_Addetto.Direction = ParameterDirection.Input;
			s_Addetto.Index = 11;
			s_Addetto.Value = addetto_id;
			
			// ID_DITTA
			S_Controls.Collections.S_Object p_id_ditta = new S_Object();
			p_id_ditta.ParameterName = "p_id_ditta";
			p_id_ditta.DbType = CustomDBType.Integer;
			p_id_ditta.Direction = ParameterDirection.Input;
			p_id_ditta.Index = 12;
			p_id_ditta.Value = id_ditta;

			// STD APPARECCHIATURA
			S_Controls.Collections.S_Object p_stdApparecchiatura_id = new S_Object();
			p_stdApparecchiatura_id.ParameterName = "p_stdApparecchiatura_id";
			p_stdApparecchiatura_id.DbType = CustomDBType.Integer;
			p_stdApparecchiatura_id.Direction = ParameterDirection.Input;
			p_stdApparecchiatura_id.Index = 13;
			p_stdApparecchiatura_id.Value = stdApparecchiatura_id;

			// APPARECCHIATURA
			S_Controls.Collections.S_Object p_eq_id = new S_Object();
			p_eq_id.ParameterName = "p_eq_id";
			p_eq_id.DbType = CustomDBType.Integer;
			p_eq_id.Direction = ParameterDirection.Input;
			p_eq_id.Index = 14;
			p_eq_id.Value = eq_id;

			// OUT

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = 15;
				
			_SColl.Add(s_IdWR);	
			_SColl.Add(s_IdStatus);	
			_SColl.Add(s_CurrentUser);
			_SColl.Add(s_Urgenza);
			_SColl.Add(s_Richiedente);
			_SColl.Add(s_Descrizione);
			_SColl.Add(s_DataP);
			_SColl.Add(s_Servizio);
			_SColl.Add(s_Trasmissione);
			_SColl.Add(s_Manutenzione);
			_SColl.Add(s_BL);			
			_SColl.Add(s_Addetto);
			_SColl.Add(p_id_ditta);
			_SColl.Add(p_stdApparecchiatura_id);
			_SColl.Add(p_eq_id);
			_SColl.Add(s_IdOut);			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			
			int i_Result=0;
			
			switch(status_id)
			{
				case Classi.StateType.EmessaInLavorazione:										
					i_Result = _OraDl.GetRowsAffected(_SColl, "PACK_EMETTI_RDL.SP_EMETTI");
					break;
				case Classi.StateType.RichiestaRifiutata:	
					i_Result = _OraDl.GetRowsAffected(_SColl, "PACK_EMETTI_RDL.SP_RIFIUTA");
					break;
				case Classi.StateType.RichiestaSospesa:
					i_Result = _OraDl.GetRowsAffected(_SColl, "PACK_EMETTI_RDL.SP_SOSPENDI");
					break;	
			}
				
			return i_Result;
		}




		public  DataSet GetAnalisiRDL(S_ControlsCollection CollezioneControlli,string utente)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_CurrentUser";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = utente;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);
			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GETANALISIRDL";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}

		
		public DataSet GetPiani(string idBl)
		{
					
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_bl = new S_Object();
			s_p_id_bl.ParameterName = "p_id_bl";
			s_p_id_bl.DbType = CustomDBType.VarChar;
			s_p_id_bl.Direction = ParameterDirection.Input;
			s_p_id_bl.Index = CollezioneControlli.Count + 1;
			s_p_id_bl.Value = idBl;		
			s_p_id_bl.Size=8;
			CollezioneControlli.Add(s_p_id_bl);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GETPIANI";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;
		}
		
		
		public DataSet GetStanze(int id_bl ,int id_piano)
		{
					
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_bl = new S_Object();
			s_p_id_bl.ParameterName = "p_id_bl";
			s_p_id_bl.DbType = CustomDBType.Integer;
			s_p_id_bl.Direction = ParameterDirection.Input;
			s_p_id_bl.Index = CollezioneControlli.Count + 1;
			s_p_id_bl.Value = id_bl;			
			CollezioneControlli.Add(s_p_id_bl);

			S_Controls.Collections.S_Object p_id_piano = new S_Object();
			p_id_piano.ParameterName = "p_id_piano";
			p_id_piano.DbType = CustomDBType.Integer;
			p_id_piano.Direction = ParameterDirection.Input;
			p_id_piano.Index = CollezioneControlli.Count + 1;
			p_id_piano.Value = id_piano;			
			CollezioneControlli.Add(p_id_piano);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GETSTANZE";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;
		}
		
		public  DataSet GetHWR(S_ControlsCollection CollezioneControlli,string utente)
		{
			DataSet _Ds;	
	
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);
			
			


			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GETHWR";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}	
	
		public int ModificaRDL(S_ControlsCollection CollezioneControlli,int wr_id)
		{
			int i_Result = 0;

			int i_MaxParametri = CollezioneControlli.Count;
			
			S_Controls.Collections.S_Object s_p_wr_id = new S_Object();
			s_p_wr_id.ParameterName = "p_wr_id";
			s_p_wr_id.DbType = CustomDBType.Integer;
			s_p_wr_id.Direction = ParameterDirection.Input;
			s_p_wr_id.Index = i_MaxParametri;
			s_p_wr_id.Value=wr_id;
			s_p_wr_id.Size=10;
			
			i_MaxParametri ++;
			
			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

			i_MaxParametri ++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;
			
			CollezioneControlli.Add(s_p_wr_id);	
			CollezioneControlli.Add(s_CurrentUser);	
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_UPDRDL";	
			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, s_StrSql);			

			return i_Result;		
		}






		#endregion
		#region Proprietà Private

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

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "FUNZIONI.SP_EXECUTEFUNZIONI");

			return i_Result;
		}

		#endregion
		
	
	}
}