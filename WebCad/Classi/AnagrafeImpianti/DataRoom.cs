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

namespace WebCad.Classi.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per DataRoom.
	/// </summary>
	public class DataRoom
	{
		public DataRoom(){}

		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];						
		/// <summary>
		/// Metodo Utilizzato nella funzione Data Room
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		
		public DataSet RicercaDataRoom(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_APPARECCHIATURE.SP_DATAROOM";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		public DataSet RicercaDataRoomSTD(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_APPARECCHIATURE.SP_DATAROOMSTD";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();		
	
			string xml=_Ds.GetXml();

			return _Ds;	
		}

		public DataSet RicercaApparecchiaturaPerStanza(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_APPARECCHIATURE.SP_GETAPPARECCHIATUREPERSTANZA";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		
	}
}
