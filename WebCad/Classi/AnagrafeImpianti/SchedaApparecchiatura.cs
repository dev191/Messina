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
	/// Descrizione di riepilogo per SchedaApparecchiatura.
	/// </summary>
	public class SchedaApparecchiatura: AbstractBase  
	{
		private string s_username;
	
		public SchedaApparecchiatura(string Username)
		{
			this.s_username=Username;
		}

		public override DataSet GetData()
		{
			DataSet _Ds;
			
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_p_eq_std = new S_Object();
			s_p_eq_std.ParameterName = "p_eq_std";
			s_p_eq_std.DbType = CustomDBType.VarChar;
			s_p_eq_std.Direction = ParameterDirection.Input;
			s_p_eq_std.Index = 0;
			s_p_eq_std.Value = "";			
			s_p_eq_std.Size = 50;
			CollezioneControlli.Add(s_p_eq_std);

//			S_Controls.Collections.S_Object s_UserName = new S_Object();
//			s_UserName.ParameterName = "p_UserName";
//			s_UserName.DbType = CustomDBType.VarChar;
//			s_UserName.Direction = ParameterDirection.Input;
//			s_UserName.Index = 0;
//			s_UserName.Value = this.s_username;			
//			s_UserName.Size = 50;
//			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SCHEDAAPPARECCHIATURE.SP_GETSCHEDAAPPARECCHIATURE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}

		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
//			S_Controls.Collections.S_Object s_UserName = new S_Object();
//			s_UserName.ParameterName = "p_UserName";
//			s_UserName.DbType = CustomDBType.VarChar;
//			s_UserName.Direction = ParameterDirection.Input;
//			s_UserName.Index = CollezioneControlli.Count + 1;
//			s_UserName.Value = this.s_username;			
//			s_UserName.Size = 50;
//			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SCHEDAAPPARECCHIATURE.SP_GETSCHEDAAPPARECCHIATURE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}

		public override DataSet GetSingleData(int itemId)
		{
			return null;
		}

		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			return 0;
		}

		#endregion
	}
}
