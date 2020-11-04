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
	/// Descrizione di riepilogo per SfogliaRdlOdlPaging.
	/// </summary>
	public class SfogliaRdlOdlPaging: AbstractBase
	{
		string username=string.Empty; 
		public SfogliaRdlOdlPaging(string UserName)
		{
			username=UserName;
		}
		public override DataSet GetSingleData(int itemId)
		{
			return null;
		}
		public override DataSet GetData()
		{
			return null;
		}
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ORDINARIA_SFOGLIA.SP_GETRDLODL3";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		public  DataSet GetStatoLavoro()
		{
			
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ORDINARIA_SFOGLIA.SP_GETSTATOLAVORO";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		public DataSet GetSingleRdl(int wo_id)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_wo_id = new S_Object();
			s_p_wo_id.ParameterName = "p_wo_id";
			s_p_wo_id.DbType = CustomDBType.Integer;
			s_p_wo_id.Direction = ParameterDirection.Input;
			s_p_wo_id.Index = CollezioneControlli.Count + 1;
			s_p_wo_id.Value=wo_id;
			CollezioneControlli.Add(s_p_wo_id);


			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ORDINARIA_SFOGLIA.SP_GETSINGLERDL";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		public DataSet GetDettailSingleRdl(int wo_id)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_wo_id = new S_Object();
			s_p_wo_id.ParameterName = "p_wo_id";
			s_p_wo_id.DbType = CustomDBType.Integer;
			s_p_wo_id.Direction = ParameterDirection.Input;
			s_p_wo_id.Index = CollezioneControlli.Count + 1;
			s_p_wo_id.Value=wo_id;
			CollezioneControlli.Add(s_p_wo_id);


			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ORDINARIA_SFOGLIA.SP_PASSIWR";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		
		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			CollezioneControlli.RemoveAt(16);
			CollezioneControlli.RemoveAt(15);
            CollezioneControlli.RemoveAt(14);
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ORDINARIA_SFOGLIA.SP_GETRDLODL3Count";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();
		    return	int.Parse(_Ds.Tables[0].Rows[0][0].ToString());
	
		}

		#endregion
	}
}

