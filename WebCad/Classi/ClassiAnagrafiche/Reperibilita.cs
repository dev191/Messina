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
	public class Reperibilita : AbstractBase
	{
		#region Dichiarazioni

		#endregion
		public Reperibilita()
		{
		}
		

		#region Metodi Pubblici
		
		public override DataSet GetData()
		{			
			DataSet _Ds = new DataSet();
			
			return _Ds;				
		}

		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds = new DataSet();
			
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

		public DataSet GetAddettiDistinct(string bl_id)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			//creo i parametri
			S_Controls.Collections.S_Object s_p_Bl_Id = new S_Controls.Collections.S_Object();
			s_p_Bl_Id.ParameterName = "p_Bl_Id";
			s_p_Bl_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Bl_Id.Direction = ParameterDirection.Input;
			s_p_Bl_Id.Size =50;
			s_p_Bl_Id.Index = 0;
			s_p_Bl_Id.Value = bl_id;
			_SColl.Add(s_p_Bl_Id);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			
			string s_StrSql = "PACK_ADDETTI_REPERIBILI.SP_GETADDETTODISTINCT";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			return _Ds;	
		}

		public DataSet GetAllAddetti()
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			
			string s_StrSql = "PACK_ADDETTI_REPERIBILI.SP_GETALLADDETTI";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			return _Ds;	
		}

		public DataSet GetReperibilita(int addettoid, int giorno)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Day = new S_Object();
			s_Day.ParameterName = "p_giorno";
			s_Day.DbType = CustomDBType.Integer;
			s_Day.Direction = ParameterDirection.Input;
			s_Day.Index = 0;
			s_Day.Value = giorno;

			
			S_Controls.Collections.S_Object s_addetto = new S_Object();
			s_addetto.ParameterName = "p_addetto";
			s_addetto.DbType = CustomDBType.Integer;
			s_addetto.Direction = ParameterDirection.Input;
			s_addetto.Index = 0;
			s_addetto.Value = addettoid;

			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SColl.Add(s_Day);
			_SColl.Add(s_addetto);
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ADDETTI_REPERIBILI.SP_GETREPERIBILITA";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			return _Ds;	
		
		}

		public DataSet GetSpecializzazioni(int addettoid)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			
			S_Controls.Collections.S_Object s_addetto = new S_Object();
			s_addetto.ParameterName = "p_addetto_id";
			s_addetto.DbType = CustomDBType.Integer;
			s_addetto.Direction = ParameterDirection.Input;
			s_addetto.Index = 0;
			s_addetto.Value = addettoid;

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SColl.Add(s_addetto);
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ADDETTI_REPERIBILI.SP_GETSPECADDETTO";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			return _Ds;	
		
		}

        #endregion

		#region Proprietà Pubbliche
		#endregion

		#region Metodi privati

		//TODO *******************
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
