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
	/// Descrizione di riepilogo per Certificati.
	/// </summary>
	public class Certificati : AbstractBase
	{
		private string username=string.Empty;
		public Certificati(string Username)
		{
			this.username=Username;
		}
		public override DataSet GetData()
		{
			return null;
		}
		
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		

			S_Controls.Collections.S_Object s_User = new S_Controls.Collections.S_Object();
			s_User.ParameterName = "p_Username";
			s_User.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_User.Direction = ParameterDirection.Input;
			s_User.Size=50; 
			s_User.Index = CollezioneControlli.Count + 1;
			s_User.Value = this.username;
			CollezioneControlli.Add(s_User);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			string s_StrSql = "PACK_CERTIFICATI.GETCERTIFICATIPaging";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}
		//  conta il numero di record restituiti
		public int  GetDataCount(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		

//			S_Controls.Collections.S_Object s_User = new S_Controls.Collections.S_Object();
//			s_User.ParameterName = "p_Username";
//			s_User.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
//			s_User.Direction = ParameterDirection.Input;
//			s_User.Size=50; 
//			s_User.Index = CollezioneControlli.Count + 1;
//			s_User.Value = this.username;
//			CollezioneControlli.Add(s_User);
//
//			S_Controls.Collections.S_Object s_Cursor = new S_Object();
//			s_Cursor.ParameterName = "IO_CURSOR";
//			s_Cursor.DbType = CustomDBType.Cursor;
//			s_Cursor.Direction = ParameterDirection.Output;
//			s_Cursor.Index = CollezioneControlli.Count + 1;
//
//			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CERTIFICATI.GETCERTIFICATICount";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();		
	

			return	int.Parse(_Ds.Tables[0].Rows[0][0].ToString());
													

		}

		public  DataSet GetDataMatricolole(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		

			S_Controls.Collections.S_Object s_User = new S_Controls.Collections.S_Object();
			s_User.ParameterName = "p_Username";
			s_User.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_User.Direction = ParameterDirection.Input;
			s_User.Size=50; 
			s_User.Index = CollezioneControlli.Count + 1;
			s_User.Value = this.username;
			CollezioneControlli.Add(s_User);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CERTIFICATI.GETMATRICOLAISPESL";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}
		public  DataSet GetDataFascicoli(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		

			S_Controls.Collections.S_Object s_User = new S_Controls.Collections.S_Object();
			s_User.ParameterName = "p_Username";
			s_User.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_User.Direction = ParameterDirection.Input;
			s_User.Size=50; 
			s_User.Index = CollezioneControlli.Count + 1;
			s_User.Value = this.username;
			CollezioneControlli.Add(s_User);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CERTIFICATI.GETFASCICOLIVVF";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}
		public override DataSet GetSingleData(int itemId)
		{
			return null;
		}

		#region Metodi Private

		public override int Update(S_ControlsCollection CollezioneControlli, int itemId)
		{
			return base.Update (CollezioneControlli, itemId);
		}
		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			return 0;
		}

		#endregion
	}
}
