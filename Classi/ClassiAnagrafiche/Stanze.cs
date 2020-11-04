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
	/// Descrizione di riepilogo per Stanze.
	/// </summary>
	public class Stanze:AbstractBase
	{
		public Stanze()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}

		#region Dichiarazioni

		DataSet _Ds;
		private ApplicationDataLayer.OracleDataLayer _OraDl;
		S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

		#endregion


		
		#region Metodi Pubblici

		public override DataSet GetData()
		{	
			return null;
		}
		
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			return null;
		}
		public override DataSet GetSingleData(int itemId)
		{
			return null;
		}


		public DataSet GetAllDestinazioni(string descrizione)
		{
			

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_descrizione = new S_Object();
			s_p_descrizione.ParameterName = "p_descrizione";
			s_p_descrizione.DbType = CustomDBType.VarChar;
			s_p_descrizione.Size=225;
			s_p_descrizione.Direction = ParameterDirection.Input;
			s_p_descrizione.Index = 0;
			s_p_descrizione.Value = descrizione;	
			_SColl.Add(s_p_descrizione);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;
			_SColl.Add(s_Cursor);			
				
			 _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_RM.SP_GETALLDESTINAZIONEUSO";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			
			return _Ds;	
		}

		public DataSet GetDestinazioniMura(string descrizione)
		{	
			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_descrizione = new S_Object();
			s_p_descrizione.ParameterName = "p_descrizione";
			s_p_descrizione.DbType = CustomDBType.VarChar;
			s_p_descrizione.Size=225;
			s_p_descrizione.Direction = ParameterDirection.Input;
			s_p_descrizione.Index = 0;
			s_p_descrizione.Value = descrizione;	
			_SColl.Add(s_p_descrizione);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;
			_SColl.Add(s_Cursor);			
				
			_OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_RM.SP_GETDESTINAZIONEMURA";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			
			return _Ds;	
		}


		public DataSet GetAllCategoria()
		{
			
			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;
			_SColl.Add(s_Cursor);			
				
			 _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_RM.SP_GETALLCATEGORIA";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			
			return _Ds;	
		}
		public DataSet GetAllReparto(string descrizione)
		{
			
			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_descrizione = new S_Object();
			s_p_descrizione.ParameterName = "p_descrizione";
			s_p_descrizione.DbType = CustomDBType.VarChar;
			s_p_descrizione.Size=225;
			s_p_descrizione.Direction = ParameterDirection.Input;
			s_p_descrizione.Index = 0;
			s_p_descrizione.Value = descrizione;	
			_SColl.Add(s_p_descrizione);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;
			_SColl.Add(s_Cursor);			
				
			
			 _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_RM.SP_GETALLREPARTO";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			
			return _Ds;	
		}

		public DataSet GetRepartoMura(string descrizione)
		{
			
			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_descrizione = new S_Object();
			s_p_descrizione.ParameterName = "p_descrizione";
			s_p_descrizione.DbType = CustomDBType.VarChar;
			s_p_descrizione.Size=225;
			s_p_descrizione.Direction = ParameterDirection.Input;
			s_p_descrizione.Index = 0;
			s_p_descrizione.Value = descrizione;	
			_SColl.Add(s_p_descrizione);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;
			_SColl.Add(s_Cursor);			
				
			
			_OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_RM.SP_GETREPARTOMURA";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			
			return _Ds;	
		}
		#endregion

		#region Metodi privati

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			int i_result=0;
			return i_result;
		
		}

		public int AddStanze(S_ControlsCollection CollezioneControlli)
		{
			return this.ExecuteStanze(CollezioneControlli, ExecuteType.Insert, 0);
		}
		public int UpdateStanze(S_ControlsCollection CollezioneControlli, int itemID)
		{
			return this.ExecuteStanze(CollezioneControlli, ExecuteType.Update, itemID);
		}
		public int DeleteStanze(S_ControlsCollection CollezioneControlli, int itemID)
		{
			return this.ExecuteStanze(CollezioneControlli, ExecuteType.Delete, itemID);
		}

		protected int ExecuteStanze(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
					
			// Id
			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_ID";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count;
			s_IdIn.Value = itemId;

			CollezioneControlli.Add(s_IdIn);
			
			
			// TIPO OPERAZIONE
			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_Operazione";
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

			 _OraDl = new OracleDataLayer(s_ConnStr);
			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_RM.SP_EXECUTEPIANISTANZE");
				
			return i_Result;
		}


		#endregion

		
	}
}

