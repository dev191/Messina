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


namespace TheSite.Classi.ManProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per RecuperoDocPmp.
	/// </summary>
	public class RecuperoDocPmp
	{
		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];

		public RecuperoDocPmp()
		{
		}
		public DataSet GetAllStato()
		{
			DataSet _Ds;
			S_Controls.Collections.S_ControlsCollection control = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = control.Count;
			control.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_PIANI_APPROVATI.SP_GETALLSTATOPIANI";	
			_Ds = _OraDl.GetRows(control, s_StrSql).Copy();			

			return _Ds;
		}

		public  DataSet GetPiani(S_ControlsCollection CollezioneControlli,string TipoDoc)
		{
			DataSet _Ds;	
				
			//S_Controls.Collections.S_ControlsCollection control = new S_Controls.Collections.S_ControlsCollection();
			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index = CollezioneControlli.Count + 1;
			s_p_username.Size =50;
			s_p_username.Value = System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneControlli.Add(s_p_username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();			
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql="";
			switch (TipoDoc)
			{
				case "0":
					 s_StrSql = "PACK_PIANI_APPROVATI.SP_GETALLPIANI";
				break;
				case "1":
					 s_StrSql = "PACK_PIANI_APPROVATI.SP_GETPIANIANNI";
			    break;
				case "2":
					 s_StrSql = "PACK_PIANI_APPROVATI.SP_GETPIANIMESI";
				break;
			}
			
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;

		}


	}
}
