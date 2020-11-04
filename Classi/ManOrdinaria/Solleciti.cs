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
	public class Solleciti : AbstractBase
	{
		public Solleciti()
		{
			
		}

		public Solleciti(int Id) 
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
			DataSet _Ds = new DataSet();
			

			return _Ds;		
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds = new DataSet();

			return _Ds;		
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public override DataSet GetSingleData(int itemId)
		{
			DataSet _Ds = new DataSet();

			return _Ds;				
		}

		public DataSet GetDataWR(string WR_id)
		{

			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();


			S_Controls.Collections.S_Object s_wr_id = new S_Object();
			s_wr_id.ParameterName = "p_ID_WR";
			s_wr_id.DbType = CustomDBType.Integer;
			s_wr_id.Direction = ParameterDirection.Input;
			s_wr_id.Index = CollezioneControlli.Count + 1;
			s_wr_id.Value = WR_id;
			s_wr_id.Size=50; 
			CollezioneControlli.Add(s_wr_id);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SOLLECITO.SP_GETALLSOLLECITI_WR";
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}

		public int ExecuteAddSollecito(S_ControlsCollection CollezioneControlli, int itemId)
		{			
		
			int i_MaxParametri = CollezioneControlli.Count;			
			
			// Id
			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_WR_ID";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = i_MaxParametri;
			s_IdIn.Value = itemId;
			
			i_MaxParametri ++;

			// UTENTE
			i_MaxParametri ++;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;
			
			i_MaxParametri ++;

			// OUT
			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;
			
			CollezioneControlli.Add(s_IdIn);	
			CollezioneControlli.Add(s_CurrentUser);	
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_SOLLECITO.SP_ADDSOLLECITO");
				
			return i_Result;
		
		}


		#endregion

		#region Proprietà Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
				int i_Result = 0;
				
				return i_Result;
		
		}

		#endregion
		
	
	}
}
