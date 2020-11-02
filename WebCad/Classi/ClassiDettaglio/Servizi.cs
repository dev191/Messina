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
	/// Descrizione di riepilogo per Servizi.
	/// </summary>
	public class Servizi : AbstractBase
	{
		#region Dichiarazioni

		private string s_Servizio = string.Empty;
		private string s_Descrizione = string.Empty;
		public string UserName;

		#endregion
		public Servizi(string UserName)
		{
			this.UserName= UserName ;
		}

		public Servizi()
		{
		
		}

		public Servizi(int Id) : this(Id, string.Empty, string.Empty ) {}

		public Servizi(int Id, string Servizio, string UserName) 
		{
			this.Id = Id;
			this.Servizio = Servizio;
			this.UserName= UserName ;
		}
		#region Proprietà Pubbliche

		/// <summary>
		/// 
		/// </summary>
		public string Servizio
		{
			get {return s_Servizio;}
			set {s_Servizio = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Descrizione
		{
			get {return s_Descrizione;}
			set {s_Descrizione = value;}
		}

		#endregion
		#region Metodi Pubblici

		/// <summary>
		/// DataSet con tutti i record
		/// </summary>
		/// <returns></returns>
		public override DataSet GetData()
		{
			DataSet _Ds;
			
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = 0;
			s_UserName.Value = this.UserName ;			
			s_UserName.Size = 50;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			CollezioneControlli.Add(s_UserName);
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SERVIZI.SP_GETALLSERVIZI";	
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
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = CollezioneControlli.Count + 1;
			s_UserName.Value = this.UserName ;			
			s_UserName.Size = 50;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 2;

			CollezioneControlli.Add(s_UserName);
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SERVIZI.SP_GETSERVIZI";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}

		public DataSet GetServiziAnagrafica(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 2;

			
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SERVIZI.SP_GETSERVIZIANAGRAFICA";	
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
			string s_StrSql = "PACK_SERVIZI.SP_GETSINGLESERVIZIANAGRAFICA";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;		
		}		

		#endregion

		public  DataSet GetServiziEdifici(int bl_id,int servizio_id)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_id_bl";
			s_Id.DbType = CustomDBType.Integer;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = 0;
			s_Id.Value = bl_id;

			S_Controls.Collections.S_Object s_Servizio_id = new S_Object();
			s_Servizio_id.ParameterName = "p_id_servizio";
			s_Servizio_id.DbType = CustomDBType.Integer;
			s_Servizio_id.Direction = ParameterDirection.Input;
			s_Servizio_id.Index = 1;
			s_Servizio_id.Value = servizio_id;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 2;

			_SColl.Add(s_Id);
			_SColl.Add(s_Servizio_id);
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SERVIZI.SP_GETSERVIZIEDIFICI";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();
			this.Id = bl_id;
			return _Ds;		
		}
		public  DataSet GetServizi()
		{
			DataSet _Ds;
			
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
						
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 0;

			
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SERVIZI.SP_SERVIZI";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}
		
		public string GetDecServizioById(int IdServizio)
		{
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			int cntParametri =0;
			S_Object pIdServizio = new S_Object();
			pIdServizio.ParameterName = "pIdServizio";
			pIdServizio.DbType = CustomDBType.Integer;
			pIdServizio.Direction = ParameterDirection.Input;
			pIdServizio.Size=32;
			pIdServizio.Value=IdServizio;
			pIdServizio.Index = cntParametri++;
			CollezioneControlli.Add(pIdServizio);

			S_Object pDescServizio = new S_Object();
			pDescServizio.ParameterName = "pDescServizio";
			pDescServizio.DbType = CustomDBType.VarChar;
			pDescServizio.Direction = ParameterDirection.Output;
			pDescServizio.Size=255;
			pDescServizio.Index = cntParametri++;
			CollezioneControlli.Add(pDescServizio);
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SERVIZI.GetDecServizioById";
				
			System.Data.OracleClient.OracleParameterCollection pc = _OraDl.ParametersArray(CollezioneControlli,s_StrSql);
			return pc[1].Value.ToString();
		}
		public  DataSet GetServiziPerSettore(int IdSettore)
		{
			DataSet _Ds;
			
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_IdSettore = new S_Object();
			s_IdSettore.ParameterName = "p_SettoreId";
			s_IdSettore.DbType = CustomDBType.Integer;
			s_IdSettore.Direction = ParameterDirection.Input;
			s_IdSettore.Index = 1;	
			s_IdSettore.Value= IdSettore;
			CollezioneControlli.Add(s_IdSettore);
						
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 0;			
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SERVIZI.SP_GETSERVIZIPERSETTORE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}




		#region Metodi Private

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
						
			// UTENTE

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

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_SERVIZI.SP_EXECUTESERVIZI");
				
			return i_Result;
		}

		#endregion
		
	}
}
