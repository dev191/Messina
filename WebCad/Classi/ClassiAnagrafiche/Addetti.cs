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

namespace WebCad.Classi.ClassiAnagrafiche
{
	/// <summary>
	/// Descrizione di riepilogo per PmpFrequenza.
	/// </summary>
	public class Addetti : AbstractBase
	{
		#region Dichiarazioni

		#endregion
		public Addetti()
		{
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
			string s_StrSql = "PACK_ADDETTI.SP_GETALLADDETTI";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;				
		}

		
		
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
		DataSet _Ds;

//		S_ControlsCollections CollezioneControlli=new S_ControlsCollection(); 

		S_Controls.Collections.S_Object S_Cursor=new S_Object();
		S_Cursor.ParameterName ="IO_CURSOR";
        S_Cursor.DbType=CustomDBType.Cursor;
		S_Cursor.Direction=ParameterDirection.Output;
		S_Cursor.Index = CollezioneControlli.Count ;
		
		CollezioneControlli.Add(S_Cursor);

		ApplicationDataLayer.OracleDataLayer _OraDL=new OracleDataLayer(s_ConnStr);
		string s_StrSql = "PACK_ADDETTI.SP_GETADDETTO";
		_Ds=_OraDL.GetRows(CollezioneControlli,s_StrSql).Copy();
		return _Ds;
		}
		public override DataSet GetSingleData(int itemId)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_id";
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
			string s_StrSql = "PACK_ADDETTI.SP_GETSINGLEADDETTO";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;	
		}

		public DataSet GetAddettoDitta(int itemId)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_ditta_id";
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
			string s_StrSql = "PACK_ADDETTI.SP_GETADDETTODITTA";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;	
		}

		public  DataSet GetAllSpecializzazioni()
		{
			DataSet _Ds;
			
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = 0;
			s_UserName.Size=50;
			s_UserName.Value=System.Web.HttpContext.Current.User.Identity.Name;

			CollezioneControlli.Add(s_UserName);


			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ADDETTI.SP_GETALLSPECIALIZZAZIONI";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}

		public  DataSet GetSpecializzazionePMP(int PMP_id,int eqstd_id,int servizio_id)
		{
			DataSet _Ds;
			
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			//BL_ID Lo passo sempre vuoto
			S_Controls.Collections.S_Object s_BL_id = new S_Object();
			s_BL_id.ParameterName = "p_Bl_Id";
			s_BL_id.DbType = CustomDBType.VarChar;
			s_BL_id.Value="";
			s_BL_id.Direction = ParameterDirection.Input;
			s_BL_id.Index = 0;
			s_BL_id.Size=20;
			
			CollezioneControlli.Add(s_BL_id);

			//Servizio ID
			S_Controls.Collections.S_Object s_Servizio_id = new S_Object();
			s_Servizio_id.ParameterName = "p_ID_Servizio";
			s_Servizio_id.DbType = CustomDBType.Integer;
			s_Servizio_id.Value=servizio_id;
			s_Servizio_id.Direction = ParameterDirection.Input;
			s_Servizio_id.Index = 1;
			
			CollezioneControlli.Add(s_Servizio_id);

			//Eqstd ID
			S_Controls.Collections.S_Object s_Eqstd_id = new S_Object();
			s_Eqstd_id.ParameterName = "p_eqstd_id";
			s_Eqstd_id.DbType = CustomDBType.Integer;
			s_Eqstd_id.Value=eqstd_id;
			s_Eqstd_id.Direction = ParameterDirection.Input;
			s_Eqstd_id.Index = 2;
			
			CollezioneControlli.Add(s_Eqstd_id);

			//Eq ID
			S_Controls.Collections.S_Object s_Eq_id = new S_Object();
			s_Eq_id.ParameterName = "p_eq_id";
			s_Eq_id.DbType = CustomDBType.VarChar;
			s_Eq_id.Value="";
			s_Eq_id.Direction = ParameterDirection.Input;
			s_Eq_id.Index = 3;
			s_Eq_id.Size=50;
			
			CollezioneControlli.Add(s_Eq_id);
			
			S_Controls.Collections.S_Object s_PMP_id = new S_Object();
			s_PMP_id.ParameterName = "p_PMP_id";
			s_PMP_id.DbType = CustomDBType.Integer;
			s_PMP_id.Value=PMP_id;
			s_PMP_id.Direction = ParameterDirection.Input;
			s_PMP_id.Index = 4;
			
			CollezioneControlli.Add(s_PMP_id);
						
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = 5;
			s_UserName.Size=50;
			s_UserName.Value=System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_UserName);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 6;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ADDETTI.SP_GETSPECIALIZZAZIONI";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

				return _Ds;		
		}

		public DataSet GetDataTR()
		{			
			DataSet _Ds;
			
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ADDETTI.SP_GETALLTR";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;				
		}
	
		public DataSet GetDataTR(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			//		S_ControlsCollections CollezioneControlli=new S_ControlsCollection(); 

			S_Controls.Collections.S_Object S_Cursor=new S_Object();
			S_Cursor.ParameterName ="IO_CURSOR";
			S_Cursor.DbType=CustomDBType.Cursor;
			S_Cursor.Direction=ParameterDirection.Output;
			S_Cursor.Index = CollezioneControlli.Count ;
		
			CollezioneControlli.Add(S_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDL=new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ADDETTI.SP_GETTR";
			_Ds=_OraDL.GetRows(CollezioneControlli,s_StrSql).Copy();
			return _Ds;
		}
		public DataSet GetSingleDataTR(int itemId)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_id";
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
			string s_StrSql = "PACK_ADDETTI.SP_GETSINGLETR";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;	
		}

		public int ExecuteUpdateTR(S_ControlsCollection CollezioneControlli, string Operazione, int itemId)
		{			
		
			int i_MaxParametri = CollezioneControlli.Count;			

			// Id
			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_Id";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = i_MaxParametri;
			s_IdIn.Value = itemId;
						
			//			// UTENTE
			i_MaxParametri ++;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

			i_MaxParametri ++;
			
			// TIPO OPERAZIONE

			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_Operazione";
			s_Operazione.DbType = CustomDBType.VarChar;
			s_Operazione.Direction = ParameterDirection.Input;
			s_Operazione.Index = i_MaxParametri;
			s_Operazione.Value = Operazione.ToString();

			i_MaxParametri ++;

			// OUT

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

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_ADDETTI.SP_EXECUTETR");
				
			return i_Result;
		
		}
        
		public DataSet GetTRAddetto(int itemId)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_id";
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
			string s_StrSql = "PACK_ADDETTI.SP_GETTRADDETTO";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;	
		
		
		
		}
		public int ExecuteUpdatePMPAdd_TR(S_ControlsCollection CollezioneControlli, string Operazione)
		{
			int i_MaxParametri = CollezioneControlli.Count;			

		
			// TIPO OPERAZIONE

			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_Operazione";
			s_Operazione.DbType = CustomDBType.VarChar;
			s_Operazione.Direction = ParameterDirection.Input;
			s_Operazione.Index = i_MaxParametri;
			s_Operazione.Value = Operazione.ToString();

			i_MaxParametri ++;

			// OUT

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;
				
			
			CollezioneControlli.Add(s_Operazione);
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_ADDETTI.SP_EXECUTEPMPADDTR");
				
			return i_Result;
		
		
		}
		public DataSet GetTRADD(int itemId)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_addetto_id";
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
			string s_StrSql = "PACK_ADDETTI.SP_TRADD";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;	
		
		}



		public DataSet GetSingleAddrep(int itemId)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_id";
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
			string s_StrSql = "PACK_ADDETTI_REPERIBILI.SP_GETSINGLEADDREP";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;	
		
		}

		public DataSet GetDataAddRep(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			//		S_ControlsCollections CollezioneControlli=new S_ControlsCollection(); 

			S_Controls.Collections.S_Object S_Cursor=new S_Object();
			S_Cursor.ParameterName ="IO_CURSOR";
			S_Cursor.DbType=CustomDBType.Cursor;
			S_Cursor.Direction=ParameterDirection.Output;
			S_Cursor.Index = CollezioneControlli.Count ;
		
			CollezioneControlli.Add(S_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDL=new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ADDETTI_REPERIBILI.SP_GETADDREP";
			_Ds=_OraDL.GetRows(CollezioneControlli,s_StrSql).Copy();
			return _Ds;
		}

		public int ExecuteUpdateAddRep(S_ControlsCollection CollezioneControlli, string Operazione, int itemId)
		{			
		
			int i_MaxParametri = CollezioneControlli.Count;			

			
			// TIPO OPERAZIONE

			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_operazione";
			s_Operazione.DbType = CustomDBType.VarChar;
			s_Operazione.Direction = ParameterDirection.Input;
			s_Operazione.Index = i_MaxParametri;
			s_Operazione.Value = Operazione.ToString();
			
			
			// UTENTE
			i_MaxParametri ++;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

						
			
			i_MaxParametri ++;

			// Id
			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_Id";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = i_MaxParametri;
			s_IdIn.Value = itemId;
			
			i_MaxParametri ++;

			// OUT

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

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_ADDETTI_REPERIBILI.SP_EXECUTEADDREP");
				
			return i_Result;
		
		}
		
		public DataSet GetDays()
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
			string s_StrSql = "PACK_ADDETTI_REPERIBILI.SP_GETDAYS";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;				
		}
		public DataSet GetDateRep(S_ControlsCollection CollezioneControlli)
		{			
			DataSet _Ds;
						
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ADDETTI_REPERIBILI.SP_GETDATEADD";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;				
		}






        #endregion

		#region Proprietà Pubbliche
		#endregion

		#region Metodi privati
		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			int i_MaxParametri = CollezioneControlli.Count;			

			// Id
			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_Id";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = i_MaxParametri;
			s_IdIn.Value = itemId;
						
//			// UTENTE
			i_MaxParametri ++;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

			i_MaxParametri ++;
			
			// TIPO OPERAZIONE

			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_Operazione";
			s_Operazione.DbType = CustomDBType.VarChar;
			s_Operazione.Direction = ParameterDirection.Input;
			s_Operazione.Index = i_MaxParametri;
			s_Operazione.Value = Operazione.ToString();

			i_MaxParametri ++;

			// OUT

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

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_ADDETTI.SP_EXECUTEADDETTO");
				
			return i_Result;
		
		}


		#endregion



	}
}
