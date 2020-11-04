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
	/// Descrizione di riepilogo per PmpFrequenza.
	/// </summary>
	public class PmpFrequenza : AbstractBase
	{
		#region Dichiarazioni

		#endregion
		public PmpFrequenza()
		{
		}
		

		#region Metodi Pubblici
		public override DataSet GetData()
		{
			DataSet _Ds;
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection(); 

			S_Controls.Collections.S_Object S_Cursor=new S_Object();
			S_Cursor.ParameterName ="IO_CURSOR";
			S_Cursor.DbType=CustomDBType.Cursor;
			S_Cursor.Direction=ParameterDirection.Output;
			S_Cursor.Index = 0;
		
			CollezioneControlli.Add(S_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDL=new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_PMPFREQUENZA.SP_GETALLPMPFREQUENZA";
			_Ds=_OraDL.GetRows(CollezioneControlli,s_StrSql).Copy();
			return _Ds;
		}
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
		DataSet _Ds;


		S_Controls.Collections.S_Object S_Cursor=new S_Object();
		S_Cursor.ParameterName ="IO_CURSOR";
        S_Cursor.DbType=CustomDBType.Cursor;
		S_Cursor.Direction=ParameterDirection.Output;
		S_Cursor.Index = CollezioneControlli.Count + 1;
		
		CollezioneControlli.Add(S_Cursor);

		ApplicationDataLayer.OracleDataLayer _OraDL=new OracleDataLayer(s_ConnStr);
		string s_StrSql = "PACK_PMPFREQUENZA.SP_GETPMPFREQUENZA";
		_Ds=_OraDL.GetRows(CollezioneControlli,s_StrSql).Copy();
		return _Ds;
		}
		public DataTable GetDatiXsl( string CodiceFrequenza, string DescrizioneFreequenza, string SSql)
		{
			int cnt= 0;
			DataSet _Ds;
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			S_Object pFrequenza = new S_Object();
			pFrequenza.ParameterName = "pFrequenza";
			pFrequenza.DbType = CustomDBType.VarChar;
			pFrequenza.Direction = ParameterDirection.Input;
			pFrequenza.Size = 256;
			pFrequenza.Index = cnt++;
			pFrequenza.Value =  CodiceFrequenza;
			CollezioneControlli.Add(pFrequenza);

			S_Object pFrequenzaDes = new S_Object();
			pFrequenzaDes.ParameterName = "pFrequenzaDes";
			pFrequenzaDes.DbType = CustomDBType.VarChar;
			pFrequenzaDes.Direction = ParameterDirection.Input;
			pFrequenzaDes.Size =256;
			pFrequenzaDes.Index = cnt++;
			pFrequenzaDes.Value =  DescrizioneFreequenza;
			CollezioneControlli.Add(pFrequenzaDes);

			S_Controls.Collections.S_Object S_Cursor=new S_Object();
			S_Cursor.ParameterName ="PCursor";
			S_Cursor.DbType=CustomDBType.Cursor;
			S_Cursor.Direction=ParameterDirection.Output;
			S_Cursor.Index = cnt++;
		
			CollezioneControlli.Add(S_Cursor);
			ApplicationDataLayer.OracleDataLayer _OraDL=new OracleDataLayer(s_ConnStr);
			_Ds=_OraDL.GetRows(CollezioneControlli,SSql).Copy();
			return _Ds.Tables[0];
		}
		public DataSet GetDataStag(string Frequenza)
		{
			DataSet _Ds;


			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_frequenza";
			s_Id.DbType = CustomDBType.VarChar;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = 0;
			s_Id.Value = Frequenza;
			_SColl.Add(s_Id);

			S_Controls.Collections.S_Object S_Cursor=new S_Object();
			S_Cursor.ParameterName ="IO_CURSOR";
			S_Cursor.DbType=CustomDBType.Cursor;
			S_Cursor.Direction=ParameterDirection.Output;
			S_Cursor.Index = _SColl.Count + 1;
			_SColl.Add(S_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDL=new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_PMPFREQUENZA.SP_GETFREQSTAG";
			_Ds=_OraDL.GetRows(_SColl,s_StrSql).Copy();
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
			string s_StrSql = "PACK_PMPFREQUENZA.SP_GETSINGLEPMPFREQUENZA";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;	
		}



        #endregion

		#region Proprietà Pubbliche
		#endregion
		
		public void DeleteFreqStag(int frequenza)
		{

			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();
			S_Controls.Collections.S_Object s_freq = new S_Object();
			s_freq.ParameterName = "fk_frequenza";
			s_freq.DbType = CustomDBType.Integer;
			s_freq.Direction = ParameterDirection.Input;
			s_freq.Index = 0;
			s_freq.Value = frequenza;
			CollezioneControlli.Add(s_freq);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			_OraDl.GetRowsAffected(CollezioneControlli, "PACK_PMPFREQUENZA.SP_DeletePMPFREQUENZAStag");
				
		}
		public void InsertFreqStag(int frequenza,string strfrequenza,int Mese, int servizio )
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();
			S_Controls.Collections.S_Object s_freq = new S_Object();
			s_freq.ParameterName = "p_frequenza";
			s_freq.DbType = CustomDBType.VarChar;
			s_freq.Direction = ParameterDirection.Input;
			s_freq.Index = CollezioneControlli.Count;
			s_freq.Value = strfrequenza;
			CollezioneControlli.Add(s_freq);


			s_freq = new S_Object();
			s_freq.ParameterName = "fk_frequenza";
			s_freq.DbType = CustomDBType.Integer;
			s_freq.Direction = ParameterDirection.Input;
			s_freq.Index = CollezioneControlli.Count;
			s_freq.Value = frequenza;
			CollezioneControlli.Add(s_freq);

			s_freq = new S_Object();
			s_freq.ParameterName = "P_mese_std";
			s_freq.DbType = CustomDBType.Integer;
			s_freq.Direction = ParameterDirection.Input;
			s_freq.Index = CollezioneControlli.Count;
			s_freq.Value = Mese;
			CollezioneControlli.Add(s_freq);

			s_freq = new S_Object();
			s_freq.ParameterName = "p_servizio";
			s_freq.DbType = CustomDBType.Integer;
			s_freq.Direction = ParameterDirection.Input;
			s_freq.Index = CollezioneControlli.Count;
			s_freq.Value = servizio;
			CollezioneControlli.Add(s_freq);


			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			_OraDl.GetRowsAffected(CollezioneControlli, "PACK_PMPFREQUENZA.SP_INSERTPMPFREQUENZAStag");
		}

		#region Metodi privati
		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			int i_MaxParametri = CollezioneControlli.Count + 1;			

			// Id
			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_Id";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = i_MaxParametri;
			s_IdIn.Value = itemId;
						
//			// UTENTE

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

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_PMPFREQUENZA.SP_EXECUTEPMPFREQUENZA");
				
			return i_Result;
		
		}


		#endregion



	}
}
