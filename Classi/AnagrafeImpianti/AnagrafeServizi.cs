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

namespace TheSite.Classi.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per AnagrafeServizi.
	/// </summary>
	public class AnagrafeServizi :AbstractBase
	{
		private string userame=string.Empty;
		public AnagrafeServizi(string Username)
		{
			userame=Username;
		}
		#region Metodi Pubblici

		
		public DataSet GetCategorie()
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();
			S_Controls.Collections.S_Object s_p_Username = new S_Object();
			s_p_Username.ParameterName = "p_Username";
			s_p_Username.DbType = CustomDBType.VarChar;
			s_p_Username.Direction = ParameterDirection.Input;
			s_p_Username.Index = CollezioneControlli.Count + 1;
			s_p_Username.Value =this.userame;
			s_p_Username.Size=250;
			CollezioneControlli.Add(s_p_Username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CERTIFICATI.GETCATEGORIE";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}

		public DataSet GetTipologie()
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();
			S_Controls.Collections.S_Object s_p_Username = new S_Object();
			s_p_Username.ParameterName = "p_Username";
			s_p_Username.DbType = CustomDBType.VarChar;
			s_p_Username.Direction = ParameterDirection.Input;
			s_p_Username.Index = CollezioneControlli.Count + 1;
			s_p_Username.Value =this.userame;
            s_p_Username.Size=250;
			CollezioneControlli.Add(s_p_Username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CERTIFICATI.GETTIPOLOGIE";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}

		public override DataSet GetData()
		{
			return null;
		}

		public  override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{

			S_Controls.Collections.S_Object s_p_Username = new S_Object();
			s_p_Username.ParameterName = "p_Username";
			s_p_Username.DbType = CustomDBType.VarChar;
			s_p_Username.Direction = ParameterDirection.Input;
			s_p_Username.Index = CollezioneControlli.Count + 1;
			s_p_Username.Value =this.userame;
			s_p_Username.Size=250;
			CollezioneControlli.Add(s_p_Username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CERTIFICATI.GETDOCUMENTIPaging";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}

		// Paolo
		
		public   int GetDataCount(S_ControlsCollection CollezioneControlli)
		{

			S_Controls.Collections.S_Object s_p_Username = new S_Object();
			s_p_Username.ParameterName = "p_Username";
			s_p_Username.DbType = CustomDBType.VarChar;
			s_p_Username.Direction = ParameterDirection.Input;
			s_p_Username.Index = CollezioneControlli.Count + 1;
			s_p_Username.Value =this.userame;
			s_p_Username.Size=250;
			CollezioneControlli.Add(s_p_Username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CERTIFICATI.GETDOCUMENTICount";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return	int.Parse(_Ds.Tables[0].Rows[0][0].ToString());
		}



		public override DataSet GetSingleData(int itemId)
		{
			return null;
		}

		#endregion

		
		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			return 0;
		}

		#endregion
	}
}
