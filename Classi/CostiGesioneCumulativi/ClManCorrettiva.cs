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
namespace TheSite.Classi.CostiGesioneCumulativi
{

	/// <summary>
	/// Descrizione di riepilogo per ClManCorrettiva.
	/// </summary>
	public class ClManCorrettiva:AbstractBase
	{
		ApplicationDataLayer.OracleDataLayer _OraDl;
		string username=string.Empty;
		public ClManCorrettiva()
		{
		 _OraDl = new OracleDataLayer(s_ConnStr);
		}
		public ClManCorrettiva(string UserName):this()
		{
			username=UserName;
		}
		public override DataSet GetData()
		{
		 return null;
		}
		public  DataSet GetDatiEdificio(int wr_id)
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

			string s_StrSql = "PACK_MANCORRETIVA.SP_GETDATIBL";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		/// <summary>
		/// ottiene il dataset con la lista dei materiali impiegati
		/// </summary>
		/// <param name="wrId"></param>
		/// <returns>dataset</returns>
		public DataSet GetListaMateriali(int wrId)
		{
			DataSet _Ds;	
			int cntParametri = 0;
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			S_Object pWrId = new S_Object();
			pWrId.ParameterName = "p_wrid";
			pWrId.DbType = CustomDBType.Integer;
			pWrId.Direction = ParameterDirection.Input;
			pWrId.Index = cntParametri++;
			pWrId.Value = wrId;
			CollezioneControlli.Add(pWrId);
			
			S_Object pCursor = new S_Object();
			pCursor.ParameterName = "IO_CURSOR";
			pCursor.DbType = CustomDBType.Cursor;
			pCursor.Direction = ParameterDirection.Output;
			pCursor.Index = cntParametri++;
			CollezioneControlli.Add(pCursor);			

			string s_StrSql = "Pack_CostiOperativiGestione.getMaterialiWr";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
			return _Ds;
		}
		/// <summary>
		/// Esegue l'aggiornamento e l'insert nella tabella wr_materiali
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <param name="Operazione"></param>
		/// <returns></returns>
		public int ExecuteMateriali(S_ControlsCollection CollezioneControlli, ExecuteType Operazione)
		{
			int i_MaxParametri = CollezioneControlli.Count + 1;			
			
			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_operazione";
			s_Operazione.DbType = CustomDBType.VarChar;
			s_Operazione.Direction = ParameterDirection.Input;
			s_Operazione.Index = i_MaxParametri++;
			s_Operazione.Value = Operazione.ToString();

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri++;

	
			CollezioneControlli.Add(s_Operazione);
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "Pack_CostiOperativiGestione.ExecuteMateriale");
			return i_Result;
		}
	/// <summary>
	///  ottien la lista dell'anagrafica materiali per riempire le combo
	/// </summary>
	/// <returns>dataset</returns>
		public DataSet getBindComboMateriali()
		{
			DataSet _Ds;	
			int cntParametri = 0;
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			S_Object pCursor = new S_Object();
			pCursor.ParameterName = "IO_CURSOR";
			pCursor.DbType = CustomDBType.Cursor;
			pCursor.Direction = ParameterDirection.Output;
			pCursor.Index = cntParametri++;
			CollezioneControlli.Add(pCursor);			

			string s_StrSql = "Pack_CostiOperativiGestione.BindMateriali";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
			return _Ds;
		}
		public DataSet getMateriali(string desc)
		{
			DataSet _Ds;	
			
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
		
			S_Object pDesc = new S_Object();
			pDesc.ParameterName = "p_descmat";
			pDesc.DbType = CustomDBType.VarChar;
			pDesc.Direction = ParameterDirection.Input;
			pDesc.Index = CollezioneControlli.Count;
			pDesc.Size=24;
			pDesc.Value=desc;
			CollezioneControlli.Add(pDesc);

			S_Object pCursor = new S_Object();
			pCursor.ParameterName = "IO_CURSOR";
			pCursor.DbType = CustomDBType.Cursor;
			pCursor.Direction = ParameterDirection.Output;
			pCursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(pCursor);			

			string s_StrSql = "Pack_CostiOperativiGestione.GetMateriali";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
			return _Ds;
		}
		public DataSet getMaterialiId(int id)
		{
			DataSet _Ds;	
			
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
		
			S_Object pidmat = new S_Object();
			pidmat.ParameterName = "p_idmat";
			pidmat.DbType = CustomDBType.Integer;
			pidmat.Direction = ParameterDirection.Input;
			pidmat.Index = CollezioneControlli.Count;
			pidmat.Size=24;
			pidmat.Value=id;
			CollezioneControlli.Add(pidmat);

			S_Object pCursor = new S_Object();
			pCursor.ParameterName = "IO_CURSOR";
			pCursor.DbType = CustomDBType.Cursor;
			pCursor.Direction = ParameterDirection.Output;
			pCursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(pCursor);			

			string s_StrSql = "Pack_CostiOperativiGestione.GetMaterialiId";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
			return _Ds;
		}
		public DataSet GetListaManodopera(int wrId)
		{
			DataSet _Ds;	
			int cntParametri = 0;
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			S_Object pWrId = new S_Object();
			pWrId.ParameterName = "p_wrid";
			pWrId.DbType = CustomDBType.Integer;
			pWrId.Direction = ParameterDirection.Input;
			pWrId.Index = cntParametri++;
			pWrId.Value = wrId;
			CollezioneControlli.Add(pWrId);
			
			S_Object pCursor = new S_Object();
			pCursor.ParameterName = "IO_CURSOR";
			pCursor.DbType = CustomDBType.Cursor;
			pCursor.Direction = ParameterDirection.Output;
			pCursor.Index = cntParametri++;
			CollezioneControlli.Add(pCursor);			

			string s_StrSql = "Pack_CostiOperativiGestione.getAddettiWr";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();		
	 


			return _Ds;
		}
		public DataSet TotManodopera(int wrId)
		{
			DataSet _Ds;	
			int cntParametri = 0;
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			S_Object pWrId = new S_Object();
			pWrId.ParameterName = "p_wrid";
			pWrId.DbType = CustomDBType.Integer;
			pWrId.Direction = ParameterDirection.Input;
			pWrId.Index = cntParametri++;
			pWrId.Value = wrId;
			CollezioneControlli.Add(pWrId);
			
			S_Object pCursor = new S_Object();
			pCursor.ParameterName = "IO_CURSOR";
			pCursor.DbType = CustomDBType.Cursor;
			pCursor.Direction = ParameterDirection.Output;
			pCursor.Index = cntParametri++;
			CollezioneControlli.Add(pCursor);			

			string s_StrSql = "Pack_CostiOperativiGestione.TotCostiOperativi";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();		
	 


			return _Ds;
		}
		/// <summary>
		/// Esegue l'aggiornamento e l'insert nella tabella wr_materiali
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <param name="Operazione"></param>
		/// <returns></returns>
		public int ExecuteManodopera(S_ControlsCollection CollezioneControlli, ExecuteType Operazione)
		{
			int i_MaxParametri = CollezioneControlli.Count + 1;			
			
			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_operazione";
			s_Operazione.DbType = CustomDBType.VarChar;
			s_Operazione.Direction = ParameterDirection.Input;
			s_Operazione.Index = i_MaxParametri++;
			s_Operazione.Value = Operazione.ToString();

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri++;

	
			CollezioneControlli.Add(s_Operazione);
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "Pack_CostiOperativiGestione.ExecuteAddetti");
			return i_Result;
		}
		/// <summary>
		///  ottien la lista dell'anagrafica materiali per riempire le combo
		/// </summary>
		/// <returns>dataset</returns>
		public DataSet getBindComboManodopera()
		{
			DataSet _Ds;	
			int cntParametri = 0;
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			S_Object pCursor = new S_Object();
			pCursor.ParameterName = "IO_CURSOR";
			pCursor.DbType = CustomDBType.Cursor;
			pCursor.Direction = ParameterDirection.Output;
			pCursor.Index = cntParametri++;
			CollezioneControlli.Add(pCursor);			

			string s_StrSql = "Pack_CostiOperativiGestione.BindAddetti";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
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

			string s_StrSql = "PACK_MAN_STRA.SP_GETCONTABILIZZAZIONE";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		/// <summary>
		/// Descrive lo stato della richiesta
		/// </summary>
		/// <param name="wr_id"></param>
		/// <returns></returns>
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

			string s_StrSql = "PACK_MAN_STRA.SP_GETSTATUSRDL";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}
		/// <summary>
		/// Restituisce l'elenco degli stati della richiesta
		/// </summary>
		/// <returns></returns>
		public  DataSet GetStatoLavoro()
		{
			
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			string s_StrSql = "PACK_MAN_ORD.SP_GETSTATOLAVORO";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		/// <summary>
		/// Restituisce l'elenco o il singolo addetto in base una ditta ed ad un edificio
		/// </summary>
		/// <param name="NomeCompleto"></param>
		/// <param name="BL_ID"></param>
		/// <returns></returns>
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

			string s_StrSql = "PACK_ADDETTI.SP_GETADDETTORUOLO";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;		
		}
		
		/// <summary>
		/// Restituisce una determinata apparecchiatura o più
		/// </summary>
		/// <param name="CollezioneControlli">I parametri che devono essere passati sono:
		/// p_Bl_Id di tipo varchar2,
		///p_campus di tipo  varchar2,
		///p_Servizio di tipo number,
		///p_eqstd di tipo varchar2,
		///p_eqid di tipo Varchar2
		/// </param>
		/// <returns></returns>
		public DataSet GetApparecchiatura(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = CollezioneControlli.Count + 1;
			s_UserName.Value = this.username;			
			s_UserName.Size = 50;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			string s_StrSql = "PACK_APPARECCHIATURE.SP_RICERCAAPPARECCHIATURA";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}


		public DataSet GetSingleRdL(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;
			CollezioneControlli.Add(s_Cursor);

			string s_StrSql = "PACK_GEST_RDL.SP_GETSINGLERDL";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}

		/// <summary>
		/// Ritorna l'elenco delle standard apparechiature associate ad un servizio e legate ad un edificio
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public  DataSet GetStandardApparechiature(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = CollezioneControlli.Count + 1;
			s_UserName.Value = this.username;			
			s_UserName.Size = 50;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			string s_StrSql = "PACK_APPARECCHIATURE.SP_GETSTDSERVIZIO";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}
        /// <summary>
        /// Ritorna la Ditta Master per un determinato edificio
        /// </summary>
        /// <param name="idbl"></param>
        /// <returns></returns>
		public DataSet GetDittaMasterBl(int bl_id)
		{
			DataSet _Ds;
			
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_id = new S_Object();
			s_id.ParameterName = "p_Bl_Id";
			s_id.DbType = CustomDBType.Integer;
			s_id.Direction = ParameterDirection.Input;
			s_id.Index = 0;
			s_id.Value = bl_id;						
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			CollezioneControlli.Add(s_id);
			CollezioneControlli.Add(s_Cursor);

			string s_StrSql = "PACK_DITTE.SP_GETDITTABL";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}
		/// <summary>
		/// Ritorna l'elenco delle ditte legate alla ditta master
		/// </summary>
		/// <param name="idditta"></param>
		/// <returns></returns>
		public DataSet GetDitteFornitoriRuoli(int idditta)
		{
			DataSet _Ds;
			
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_id = new S_Object();
			s_id.ParameterName = "p_Ditta_id";
			s_id.DbType = CustomDBType.Integer;
			s_id.Direction = ParameterDirection.Input;
			s_id.Index = 0;
			s_id.Value = idditta;
				
			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = 1;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 2;

			CollezioneControlli.Add(s_id);
			CollezioneControlli.Add(s_CurrentUser);
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DITTE.SP_GETGESTORI_FORNITORI_RUOLO";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}
		/// <summary>
		/// Ritornano i Dati di una singola Richiesta
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
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

			
			string s_StrSql = "PACK_MANCORRETIVA.SP_GETSINGLERDL";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;				
		}
		/// <summary>
		/// Ritorna la Lista delle Urgenze
		/// </summary>
		/// <returns></returns>
		public DataSet GetPriority()
		{
			DataSet _Ds;
			
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 0;

			CollezioneControlli.Add(s_Cursor);

			string s_StrSql = "PACK_PRIORITY.SP_GETALLPRIORITY";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql);			

			return _Ds;
		}
		/// <summary>
		/// Ritorna l'elenco del Tipo di trasmissione
		/// </summary>
		/// <returns></returns>
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

			string s_StrSql = "PACK_COMMON.SP_GETALLTIPOTRASMISSIONE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();
			return _Ds;		
		}

		public  DataSet GetTipointervento()
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
			string s_StrSql = "PACK_MS.SP_GETALLTIPOINTERVENTO";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;				
		}

        /// <summary>
        /// Ritorna la Lista del Tipo di Manutenzione
        /// </summary>
        /// <returns></returns>
		public  DataSet GetTipoManutenzione()
		{			
			DataSet _Ds;		
			
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;
			
			CollezioneControlli.Add(s_Cursor);

			string s_StrSql = "PACK_MANCORRETIVA.SP_GETALLMANUTENZIONE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}
		/// <summary>
		/// Ritorna la Lista dei servizi dedicati a un edificio
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public  DataSet GetServiceBulding(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = CollezioneControlli.Count + 1;
			s_UserName.Value = this.username ;			
			s_UserName.Size = 50;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 2;

			CollezioneControlli.Add(s_UserName);
			CollezioneControlli.Add(s_Cursor);

			string s_StrSql = "PACK_SERVIZI.SP_GETSERVIZI";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}
		/// <summary>
		/// Ricerca le Richieste della Manutenzione Correttiva
		/// Usata nella Pagian ApprovaRDL Manutenzione Correttiva
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public override DataSet GetData(S_Controls.Collections.S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_utente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = this.username;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);
			
			string s_StrSql = "PACK_MANCORRETIVA.SP_RICERCARDL";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		/// <summary>
		/// Ricerca le Richieste della Manutenzione Correttiva
		/// Usata nella Pagina Completamento Manutenzione Correttiva
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public  DataSet GetDataCompletamento(S_Controls.Collections.S_ControlsCollection CollezioneControlli)
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
			string s_StrSql = "PACK_MANCORRETIVA.SP_GETCOMPLETAMENTO";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}

		public int EmettiRdl(S_Controls.Collections.S_ControlsCollection CollezioneControlli,TheSite.Classi.StateType status_id)
		{	
			
			// UTENTE

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = CollezioneControlli.Count;
			s_CurrentUser.Value = this.username;
            CollezioneControlli.Add(s_CurrentUser);	
			// OUT
			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = CollezioneControlli.Count;		
			CollezioneControlli.Add(s_IdOut);			

			
			int i_Result=0;
			
			switch(status_id)
			{
				case TheSite.Classi.StateType.EmessaInLavorazione:										
					i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA.SP_EMETTI");
					break;
				case TheSite.Classi.StateType.RichiestaRifiutata:	
					i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA.SP_RIFIUTA");
					break;
				case TheSite.Classi.StateType.RichiestaSospesa:
					i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA.SP_SOSPENDI");
					break;	
			}
				
			return i_Result;
		}
		public override DataSet GetSingleData(int ItemID)
		{
			return null;
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
			string s_StrSql = "PACK_MANCORRETIVA.SP_GETANALISIRDL";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

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
			string s_StrSql = "PACK_MANCORRETIVA.SP_GetRDLNonEmesse";
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
			string s_StrSql = "PACK_MANCORRETIVA.SP_GetRDLApprovate";
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			return _Ds;	

		}


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

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "FUNZIONI.SP_EXECUTEFUNZIONI");

			return i_Result;
		}
		/// <summary>
		/// Aggiunge un Record a DCSIT se l'ultimo parametro e True, Altrimenti aggiunge un record a DL
		/// se l'ultimo parametro e False.
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <param name="DCSTIT"></param>
		/// <returns></returns>
		public int AddDCSTI_DL(S_ControlsCollection CollezioneControlli,bool DCSTIT)
		{
		  return ExecuteUpdateDCSIT_DL(CollezioneControlli,ExecuteType.Insert,0,DCSTIT);
		}
		/// <summary>
		/// Aggiorna il Record a DCSIT se l'ultimo parametro e True, Altrimenti aggiorna il record a DL
		/// se l'ultimo parametro e False.
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <param name="DCSTIT"></param>
		/// <returns></returns>
		public int UpdateDCSTI_DL(S_ControlsCollection CollezioneControlli, int itemId, bool DCSTIT)
		{
			return ExecuteUpdateDCSIT_DL(CollezioneControlli,ExecuteType.Update,itemId,DCSTIT);
		}
		/// <summary>
		/// Elimina il Record a DCSIT se l'ultimo parametro e True, Altrimenti elimina il record a DL
		/// se l'ultimo parametro e False.
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <param name="DCSTIT"></param>
		/// <returns></returns>
		public int DeleteDCSTI_DL(S_ControlsCollection CollezioneControlli, int itemId, bool DCSTIT)
		{
			return ExecuteUpdateDCSIT_DL(CollezioneControlli,ExecuteType.Delete,itemId,DCSTIT);
		}
		protected  int ExecuteUpdateDCSIT_DL(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId,bool DCSTIT)
		{
			int i_Result=0;
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
    
			 i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA.SP_VALIDA");

			return i_Result;
			
		}
	
		public int ExecuteUpdateCompletamento(S_ControlsCollection CollezioneControlli, int itemId)
		{
			

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_IdOut);
			//_____________________________________________________________________________________
			
			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA.SP_UPDATECOMPLETAMENTO");
				
			return i_Result;
			//_____________________________________________________________________________________
			
		}
		#endregion
	}
}
