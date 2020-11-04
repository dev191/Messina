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

namespace  TheSite.Classi.SoddCliente
{
	/// <summary>
	/// Descrizione di riepilogo per KPI.
	/// </summary>
	public class KPI
	{
		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
		public KPI()
		{
		}

		public int SaveReportVod(S_ControlsCollection CollezioneControlli)
		{

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = CollezioneControlli.Count;

			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_KPI_VODAFONE.SP_SAVEREPORT");

			return i_Result;
		}
		
		public DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;

			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_utente";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = CollezioneControlli.Count;
			p.Size=20;
			p.Value=System.Web.HttpContext.Current.User.Identity.Name;						
			CollezioneControlli.Add(p);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_KPI_VODAFONE.SP_GET_VOD_KPI_FILE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;
		}

		public DataSet GetEdifici(string username)
		{
			DataSet _Ds;
			S_Controls.Collections.S_ControlsCollection control = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_username";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = control.Count;
			p.Size=20;
			p.Value=username;						
			control.Add(p);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = control.Count;
			control.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_KPI_VODAFONE.sp_getedifici";	
			_Ds = _OraDl.GetRows(control, s_StrSql).Copy();			

			return _Ds;
		}


	}
}
