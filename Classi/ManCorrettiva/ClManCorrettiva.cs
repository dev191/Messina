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

namespace TheSite.Classi.ManCorrettiva
{

	/// <summary>
	/// Descrizione di riepilogo per ClManCorrettiva.
	/// </summary>
	public class ClManCorrettiva : AbstractBase
	{
		ApplicationDataLayer.OracleDataLayer _OraDl;
		string username = string.Empty;
		public ClManCorrettiva()
		{
			_OraDl = new OracleDataLayer(s_ConnStr);
		}
		public ClManCorrettiva(string UserName) : this()
		{
			username = UserName;
		}
		public override DataSet GetData()
		{
			return null;
		}
		public DataSet GetDatiEdificio(int wr_id)
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
		///  ottien la lista dell'anagrafica materiali per riempire le combo
		/// </summary>
		/// <returns>dataset</returns>
		public DataSet getBindComboManodopera(int _wrId)
		{
			DataSet _Ds;
			int cntParametri = 0;
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_Wr_Id = new S_Controls.Collections.S_Object();
			s_p_Wr_Id.ParameterName = "p_Wr_Id";
			s_p_Wr_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wr_Id.Direction = ParameterDirection.Input;
			s_p_Wr_Id.Index = 2;
			s_p_Wr_Id.Size = 50;
			s_p_Wr_Id.Value = _wrId;
			CollezioneControlli.Add(s_p_Wr_Id);

			S_Object pCursor = new S_Object();
			pCursor.ParameterName = "IO_CURSOR";
			pCursor.DbType = CustomDBType.Cursor;
			pCursor.Direction = ParameterDirection.Output;
			pCursor.Index = cntParametri++;
			CollezioneControlli.Add(pCursor);

			string s_StrSql = "Pack_CostiOperativiGestione.BindAddettiwr";
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



		public DataSet getMateriali(string desc)
		{
			DataSet _Ds;

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Object pDesc = new S_Object();
			pDesc.ParameterName = "p_descmat";
			pDesc.DbType = CustomDBType.VarChar;
			pDesc.Direction = ParameterDirection.Input;
			pDesc.Index = CollezioneControlli.Count;
			pDesc.Size = 24;
			pDesc.Value = desc;
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
			pidmat.Size = 24;
			pidmat.Value = id;
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

		public DataSet GetMacroArea()
		{

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;

			CollezioneControlli.Add(s_Cursor);

			string s_StrSql = "PACK_MAN_ORD.SP_GETMACROAREA";
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return _Ds;
		}

		public DataSet GetContabilizzazione()
		{

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

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

		public DataSet GetAddetti_NODITTA(int servizi_id)
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_servizi_ID = new S_Controls.Collections.S_Object();
			s_p_servizi_ID.ParameterName = "p_servizi_id";
			s_p_servizi_ID.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_servizi_ID.Direction = ParameterDirection.Input;
			s_p_servizi_ID.Size = 50;
			s_p_servizi_ID.Index = 0;
			s_p_servizi_ID.Value = servizi_id;
			_SCollection.Add(s_p_servizi_ID);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SCollection.Add(s_Cursor);

			DataSet _Ds;

			string s_StrSql = "PACK_ADDETTI.SP_GETADDETTORUOLOCORR_NODITTA";
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();

			return _Ds;
		}





		public DataSet GetStatusRdl(int wr_id)
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
		public DataSet GetStatoLavoro()
		{

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

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
		public DataSet GetAddetti(string NomeCompleto, string BL_ID, int ditta_id, int servizi_id)
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_NomeCompleto = new S_Controls.Collections.S_Object();
			s_p_NomeCompleto.ParameterName = "p_NomeCompleto";
			s_p_NomeCompleto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_NomeCompleto.Direction = ParameterDirection.Input;
			s_p_NomeCompleto.Size = 50;
			s_p_NomeCompleto.Index = 0;
			s_p_NomeCompleto.Value = NomeCompleto;
			_SCollection.Add(s_p_NomeCompleto);

			S_Controls.Collections.S_Object s_p_BL_ID = new S_Controls.Collections.S_Object();
			s_p_BL_ID.ParameterName = "p_bl_id";
			s_p_BL_ID.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_BL_ID.Direction = ParameterDirection.Input;
			s_p_BL_ID.Size = 50;
			s_p_BL_ID.Index = 1;
			s_p_BL_ID.Value = BL_ID;
			_SCollection.Add(s_p_BL_ID);

			S_Controls.Collections.S_Object s_p_DITTA_ID = new S_Controls.Collections.S_Object();
			s_p_DITTA_ID.ParameterName = "p_ditta_id";
			s_p_DITTA_ID.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DITTA_ID.Direction = ParameterDirection.Input;
			s_p_DITTA_ID.Size = 50;
			s_p_DITTA_ID.Index = 2;
			s_p_DITTA_ID.Value = ditta_id;
			_SCollection.Add(s_p_DITTA_ID);

			S_Controls.Collections.S_Object s_p_servizi_ID = new S_Controls.Collections.S_Object();
			s_p_servizi_ID.ParameterName = "p_servizi_id";
			s_p_servizi_ID.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_servizi_ID.Direction = ParameterDirection.Input;
			s_p_servizi_ID.Size = 50;
			s_p_servizi_ID.Index = 3;
			s_p_servizi_ID.Value = servizi_id;
			_SCollection.Add(s_p_servizi_ID);



			S_Controls.Collections.S_Object s_p_UserName = new S_Controls.Collections.S_Object();
			s_p_UserName.ParameterName = "p_UserName";
			s_p_UserName.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_UserName.Direction = ParameterDirection.Input;
			s_p_UserName.Size = 50;
			s_p_UserName.Index = 4;
			s_p_UserName.Value = System.Web.HttpContext.Current.User.Identity.Name;
			_SCollection.Add(s_p_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 5;

			_SCollection.Add(s_Cursor);

			DataSet _Ds;

			string s_StrSql = "PACK_ADDETTI.SP_GETADDETTORUOLOCORR";
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();

			return _Ds;
		}

		public DataSet GetAddetti_data(string NomeCompleto, string BL_ID, int servizi_id, int wr_id)
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_NomeCompleto = new S_Controls.Collections.S_Object();
			s_p_NomeCompleto.ParameterName = "p_NomeCompleto";
			s_p_NomeCompleto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_NomeCompleto.Direction = ParameterDirection.Input;
			s_p_NomeCompleto.Size = 50;
			s_p_NomeCompleto.Index = 0;
			s_p_NomeCompleto.Value = NomeCompleto;
			_SCollection.Add(s_p_NomeCompleto);

			S_Controls.Collections.S_Object s_p_BL_ID = new S_Controls.Collections.S_Object();
			s_p_BL_ID.ParameterName = "p_bl_id";
			s_p_BL_ID.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_BL_ID.Direction = ParameterDirection.Input;
			s_p_BL_ID.Size = 50;
			s_p_BL_ID.Index = 1;
			s_p_BL_ID.Value = BL_ID;
			_SCollection.Add(s_p_BL_ID);

			S_Controls.Collections.S_Object s_p_wr_id = new S_Controls.Collections.S_Object();
			s_p_wr_id.ParameterName = "p_wr_id";
			s_p_wr_id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_wr_id.Direction = ParameterDirection.Input;
			s_p_wr_id.Size = 50;
			s_p_wr_id.Index = 2;
			s_p_wr_id.Value = wr_id;
			_SCollection.Add(s_p_wr_id);



			S_Controls.Collections.S_Object s_p_servizi_ID = new S_Controls.Collections.S_Object();
			s_p_servizi_ID.ParameterName = "p_servizi_id";
			s_p_servizi_ID.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_servizi_ID.Direction = ParameterDirection.Input;
			s_p_servizi_ID.Size = 50;
			s_p_servizi_ID.Index = 4;
			s_p_servizi_ID.Value = servizi_id;
			_SCollection.Add(s_p_servizi_ID);

			S_Controls.Collections.S_Object s_p_UserName = new S_Controls.Collections.S_Object();
			s_p_UserName.ParameterName = "p_UserName";
			s_p_UserName.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_UserName.Direction = ParameterDirection.Input;
			s_p_UserName.Size = 50;
			s_p_UserName.Index = 5;
			s_p_UserName.Value = System.Web.HttpContext.Current.User.Identity.Name;
			_SCollection.Add(s_p_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 6;

			_SCollection.Add(s_Cursor);

			DataSet _Ds;

			string s_StrSql = "PACK_ADDETTI.SP_GETADDETTORUOLOCORR_WR1";
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

		public DataSet GetListaApparrati(S_ControlsCollection CollezioneControlli)
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

			string s_StrSql = "PACK_APPARECCHIATURE.SP_GET_LISTA_APP";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return _Ds;
		}

		public DataSet GetListaEQ(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;


			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);

			string s_StrSql = "PACK_APPARECCHIATURE.SP_GET_LISTA_EQ";
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
		public DataSet GetStandardApparechiature(S_ControlsCollection CollezioneControlli)
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

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

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

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

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

		public DataSet GetSingleRdlNew(int itemId)
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


			string s_StrSql = "PACK_MANCORRETIVA.SP_GETSINGLERDLNEW";
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();

			this.Id = itemId;
			return _Ds;
		}

		public DataSet GetSingleRdl_DEMO(int itemId)
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


			string s_StrSql = "PACK_MANCORRETIVA.SP_GETSINGLERDLNEW_DEMO";
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();

			this.Id = itemId;
			return _Ds;
		}

		public DataSet GetSingleRdlNew1(int itemId)
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


			string s_StrSql = "PACK_MANCORRETIVA_NUOVA.SP_GETSINGLERDLNEW";
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

		public DataSet GetTipointervento()
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
		public DataSet GetPiani()
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
			string s_StrSql = "PACK_MAN_ORD.SP_GetPiani";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return _Ds;
		}


		public DataSet GetPianibl(string id_bl)
		{
			DataSet _Ds;

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_bl = new S_Object();
			s_p_id_bl.ParameterName = "p_id_bl";
			s_p_id_bl.DbType = CustomDBType.VarChar;
			s_p_id_bl.Direction = ParameterDirection.Input;
			s_p_id_bl.Value = id_bl;
			s_p_id_bl.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_p_id_bl);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GETPIANIBL";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return _Ds;
		}



		public DataSet GetAseguito()
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
			string s_StrSql = "PACK_SGA_SEGUITO.SP_GETALLSGASEGUITO";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return _Ds;
		}

		/// <summary>
		/// Ritorna la Lista del Tipo di Manutenzione
		/// </summary>
		/// <returns></returns>
		public DataSet GetTipoManutenzione()
		{
			DataSet _Ds;

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

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
		public DataSet GetStAutorizz()
		{
			DataSet _Ds;

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			CollezioneControlli.Add(s_Cursor);

			string s_StrSql = "PACK_MANCORRETIVA.SP_GETALLSTAUTORIZZ";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return _Ds;
		}
		public DataSet GetStatoInetervento()
		{
			DataSet _Ds;

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;

			CollezioneControlli.Add(s_Cursor);

			string s_StrSql = "PACK_MANCORRETIVA.SP_GETALLSTATOINTERVENTO";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return _Ds;
		}

		public DataSet GetDocumentazionePrev(int id)
		{
			DataSet _Ds;

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_wr_id";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Value = id;
			p.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(p);


			p = new S_Object();
			p.ParameterName = "IO_CURSOR";
			p.DbType = CustomDBType.Cursor;
			p.Direction = ParameterDirection.Output;
			p.Index = 2;
			CollezioneControlli.Add(p);

			string s_StrSql = "PACK_MANCORRETIVA.SP_GETDOCUMENTAZIONEPREV";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return _Ds;
		}
		public DataSet GetDocumentazionePrev1(int id)
		{
			DataSet _Ds;

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_wr_id";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Value = id;
			p.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(p);


			p = new S_Object();
			p.ParameterName = "IO_CURSOR";
			p.DbType = CustomDBType.Cursor;
			p.Direction = ParameterDirection.Output;
			p.Index = 2;
			CollezioneControlli.Add(p);

			string s_StrSql = "PACK_MANCORRETIVA_NUOVA.SP_GETDOCUMENTAZIONEPREV";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return _Ds;
		}

		public DataSet GetDocumentazioneCons(int id)
		{
			DataSet _Ds;

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_wr_id";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Value = id;
			p.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(p);


			p = new S_Object();
			p.ParameterName = "IO_CURSOR";
			p.DbType = CustomDBType.Cursor;
			p.Direction = ParameterDirection.Output;
			p.Index = 2;
			CollezioneControlli.Add(p);

			string s_StrSql = "PACK_MANCORRETIVA.SP_GETDOCUMENTAZIONECONS";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return _Ds;
		}

		public DataSet GetDocumentazioneCons1(int id)
		{
			DataSet _Ds;

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_wr_id";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Value = id;
			p.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(p);


			p = new S_Object();
			p.ParameterName = "IO_CURSOR";
			p.DbType = CustomDBType.Cursor;
			p.Direction = ParameterDirection.Output;
			p.Index = 2;
			CollezioneControlli.Add(p);

			string s_StrSql = "PACK_MANCORRETIVA_nuova.SP_GETDOCUMENTAZIONECONS";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return _Ds;
		}


		public DataSet GetDocumentazione(int id, string TipoDoc)
		{
			DataSet _Ds;

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_wr_id";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Value = id;
			p.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(p);


			p = new S_Object();
			p.ParameterName = "p_tipo_doc";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Size = 250;
			p.Value = TipoDoc;
			p.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(p);


			p = new S_Object();
			p.ParameterName = "IO_CURSOR";
			p.DbType = CustomDBType.Cursor;
			p.Direction = ParameterDirection.Output;
			p.Index = 2;
			CollezioneControlli.Add(p);

			string s_StrSql = "PACK_MANCORRETIVA.SP_GETDOCUMENTAZIONE";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return _Ds;
		}


		public DataSet GetDocumentazionewo(string wo)
		{
			DataSet _Ds;

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_wo_id";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Value = wo;
			p.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(p);

			p = new S_Object();
			p.ParameterName = "IO_CURSOR";
			p.DbType = CustomDBType.Cursor;
			p.Direction = ParameterDirection.Output;
			p.Index = 2;
			CollezioneControlli.Add(p);

			string s_StrSql = "PACK_MANCORRETIVA_NUOVA.SP_GETDOCUMENTAZIONEWO";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return _Ds;
		}


		/// <summary>
		/// Ritorna la Lista dei servizi dedicati a un edificio
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public DataSet GetServiceBulding(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = CollezioneControlli.Count + 1;
			s_UserName.Value = this.username;
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

		public DataSet GetServiceBulding2(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = CollezioneControlli.Count + 1;
			s_UserName.Value = this.username;
			s_UserName.Size = 50;

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 2;

			CollezioneControlli.Add(s_UserName);
			CollezioneControlli.Add(s_Cursor);

			string s_StrSql = "PACK_SERVIZI.SP_GETSERVIZIRIC";
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

		public int GetDataCount(S_Controls.Collections.S_ControlsCollection CollezioneControlli)
		{

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

			string s_StrSql = "PACK_MANCORRETIVA.SP_RICERCARDLCount";
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return int.Parse(_Ds.Tables[0].Rows[0][0].ToString());
		}
		/// <summary>
		/// Ricerca le Richieste della Manutenzione Correttiva
		/// Usata nella Pagina Completamento Manutenzione Correttiva
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public DataSet GetDataCompletamento(S_Controls.Collections.S_ControlsCollection CollezioneControlli)
		{

			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index = CollezioneControlli.Count + 1;
			s_p_username.Value = this.username;
			s_p_username.Size = 50;
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

		public DataSet GetDataCompletamentoExcel(S_Controls.Collections.S_ControlsCollection CollezioneControlli)
		{

			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index = CollezioneControlli.Count + 1;
			s_p_username.Value = this.username;
			s_p_username.Size = 50;
			CollezioneControlli.Add(s_p_username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MANCORRETIVA.SP_GETCOMPLETAMENTOExcel";
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return _Ds;
		}

		public int GetDataCompletamentoCount(S_Controls.Collections.S_ControlsCollection CollezioneControlli)
		{

			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index = CollezioneControlli.Count + 1;
			s_p_username.Value = this.username;
			s_p_username.Size = 50;
			CollezioneControlli.Add(s_p_username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MANCORRETIVA.SP_GETCOMPLETAMENTOCount";
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return int.Parse(_Ds.Tables[0].Rows[0][0].ToString());
		}

		public int EmettiRdl1(S_Controls.Collections.S_ControlsCollection CollezioneControlli, TheSite.Classi.StateType status_id)
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


			int i_Result = 0;

			switch (status_id)
			{
				case TheSite.Classi.StateType.EmessaInLavorazione:
					i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA_NUOVA.SP_EMETTI");
					break;
				case TheSite.Classi.StateType.RichiestaRifiutata:
					i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA_NUOVA.SP_RIFIUTA");
					break;
				case TheSite.Classi.StateType.RichiestaSospesa:
					i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA_NUOVA.SP_SOSPENDI");
					break;
			}

			return i_Result;
		}
		public int EmettiRdl(S_Controls.Collections.S_ControlsCollection CollezioneControlli, TheSite.Classi.StateType status_id)
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


			int i_Result = 0;

			switch (status_id)
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

		public DataSet GetAnalisiRDLExcel(S_ControlsCollection CollezioneControlli, string utente)
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
			string s_StrSql = "PACK_MANCORRETIVA.SP_GETANALISIRDLExcel";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return _Ds;

		}

		public DataSet GetAnalisiRDL(S_ControlsCollection CollezioneControlli, string utente)
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
		public int GetAnalisiRDLCount(S_ControlsCollection CollezioneControlli, string utente)
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
			string s_StrSql = "PACK_MANCORRETIVA.SP_GETANALISIRDLCount";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();

			return int.Parse(_Ds.Tables[0].Rows[0][0].ToString()); ;

		}
		public DataSet GetRDLNonEmesse(string bl_id)
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
		public DataSet GetRDLApprovate(string bl_id)
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

		public int NumeroSGA(int wr_id)
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_wr = new S_Object();
			s_p_id_wr.ParameterName = "p_id_wr";
			s_p_id_wr.DbType = CustomDBType.VarChar;
			s_p_id_wr.Direction = ParameterDirection.Input;
			s_p_id_wr.Index = CollezioneControlli.Count;
			s_p_id_wr.Value = wr_id;
			CollezioneControlli.Add(s_p_id_wr);

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_TRACCIA_DOC.SP_GETNUMSGA");
			return i_Result;
		}

		public int CreaNumeroSGA(int wr_id)
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_wr = new S_Object();
			s_p_id_wr.ParameterName = "p_wr_id";
			s_p_id_wr.DbType = CustomDBType.Integer;
			s_p_id_wr.Direction = ParameterDirection.Input;
			s_p_id_wr.Index = 0;
			s_p_id_wr.Value = wr_id;
			CollezioneControlli.Add(s_p_id_wr);

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = 1;
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA.SP_CREASGACODICE");
			return i_Result;
		}

		public DataSet GetDataInvioSga(int itemId, DocType TipoDoc)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_Wr_Id";
			s_Id.DbType = CustomDBType.Integer;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = _SColl.Count;
			s_Id.Value = itemId;
			_SColl.Add(s_Id);

			s_Id = new S_Object();
			s_Id.ParameterName = "p_doc";
			s_Id.DbType = CustomDBType.VarChar;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = _SColl.Count;
			s_Id.Value = TipoDoc.ToString();
			_SColl.Add(s_Id);


			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = _SColl.Count;


			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MANCORRETIVA.SP_DATAPRIMOINVIO";
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();

			this.Id = itemId;
			return _Ds;
		}

		public int ExecuteTracciaDoc(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_TRACCIA_DOC.SP_EXECUTETRACCIADOC");

			return i_Result;

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

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_Operazione";
			s_Operazione.DbType = CustomDBType.VarChar;
			s_Operazione.Direction = ParameterDirection.Input;
			s_Operazione.Index = i_MaxParametri;
			s_Operazione.Value = Operazione.ToString();

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;

			CollezioneControlli.Add(s_IdIn);
			CollezioneControlli.Add(s_CurrentUser);
			CollezioneControlli.Add(s_Operazione);
			CollezioneControlli.Add(s_IdOut);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_FUNZIONI.SP_EXECUTEFUNZIONI");

			return i_Result;
		}

		/// <summary>
		/// Aggiunge un Record a DCSIT se l'ultimo parametro e True, Altrimenti aggiunge un record a DL
		/// se l'ultimo parametro e False.
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <param name="DCSTIT"></param>
		/// <returns></returns>
		public int AddDCSTI_DL(S_ControlsCollection CollezioneControlli, bool DCSTIT)
		{
			return ExecuteUpdateDCSIT_DL(CollezioneControlli, ExecuteType.Insert, 0, DCSTIT);
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
			return ExecuteUpdateDCSIT_DL(CollezioneControlli, ExecuteType.Update, itemId, DCSTIT);
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
			return ExecuteUpdateDCSIT_DL(CollezioneControlli, ExecuteType.Delete, itemId, DCSTIT);
		}
		protected int ExecuteUpdateDCSIT_DL(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId, bool DCSTIT)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count + 1;

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_Id";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = i_MaxParametri;
			s_IdIn.Value = itemId;

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_Operazione";
			s_Operazione.DbType = CustomDBType.VarChar;
			s_Operazione.Direction = ParameterDirection.Input;
			s_Operazione.Index = i_MaxParametri;
			s_Operazione.Value = Operazione.ToString();

			i_MaxParametri++;

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

		public int ExecuteUpdCompletamento(S_ControlsCollection CollezioneControlli, int itemId)
		{


			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_IdOut);
			//_____________________________________________________________________________________

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA.SP_UPDCOMPLETAMENTO");

			return i_Result;
			//_____________________________________________________________________________________

		}


		public int ExecuteUpdateSGA(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count + 1;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_CurrentUser);

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;


			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA.sp_updateSga");

			return i_Result;

		}

		public int ExecuteUpdateSGA1(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count + 1;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_CurrentUser);

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;


			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA_NUOVA.sp_updateSga");

			return i_Result;

		}

		public int ExecuteUpdateSGARIFSOSP(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count + 1;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_CurrentUser);

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;


			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA_NUOVA.sp_updateSgarifsos");

			return i_Result;

		}


		public int ExecuteUpdateSGA2(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count + 1;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_CurrentUser);

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;


			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA_NUOVA.sp_updateSga_rev");

			return i_Result;

		}


		public int ExecuteUpdateCompletamentoNew(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count + 1;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_CurrentUser);

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;


			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA.sp_Completamnetonew");

			return i_Result;

		}


		public int ExecuteUpdateCompletamentoNew1(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count + 1;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_CurrentUser);

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;


			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA_NUOVA.sp_Completamnetonew");

			return i_Result;

		}
		public int Completamentonew_rev(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_CurrentUser);

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;


			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA_NUOVA.sp_Completamento_new_rev");

			return i_Result;

		}

		public int Completamentonew_rev1(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_CurrentUser);

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;


			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA_NUOVA.sp_Completamento_new_rev1");

			return i_Result;

		}

		public int Completamentonew_rev2(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_CurrentUser);

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;


			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA_NUOVA.sp_Completamento_new_rev2");

			return i_Result;

		}


		public int ExecuteUpdateDOC(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count + 1;

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;


			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA.SP_EXDOCUMENTAZIONE");

			return i_Result;

		}

		public int ExecuteUpdateDOC1(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count + 1;

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;


			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA_NUOVA.SP_EXDOCUMENTAZIONE");

			return i_Result;

		}


		public int ExecuteUpdateDOCWO(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count + 1;

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;


			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA_NUOVA.SP_EXDOCUMENTAZIONEWO");

			return i_Result;

		}


		public int ExecuteUpdatePreventivo(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count + 1;

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;


			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA.SP_UPDATEPREVENTIVO");

			return i_Result;

		}
		public int ExecuteUpdatePreventivo1(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count + 1;

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;


			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA_NUOVA.SP_UPDATEPREVENTIVO");

			return i_Result;

		}
		public int ExecuteUpdateConsuntivo(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count + 1;

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;


			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA.SP_UPDATECONSUTIVO");

			return i_Result;

		}
		public int ExecuteUpdateConsuntivo1(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;
			int i_MaxParametri = CollezioneControlli.Count + 1;

			i_MaxParametri++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;


			CollezioneControlli.Add(s_IdOut);

			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_MANCORRETIVA_NUOVA.SP_UPDATECONSUTIVO");

			return i_Result;

		}
		#endregion
	}
}
