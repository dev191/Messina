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
	/// Descrizione di riepilogo per DocDWF usata dalla Pagina VisualDWF.aspx.
	/// e dalla pagina DocImageGalery.aspx
	/// </summary>
	public class DocDWF : AbstractBase
	{
		public DocDWF()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
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
			string s_StrSql = "PACK_DOCUMENTI.SP_GETDOCUMENTO";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}

		public override DataSet GetSingleData(int itemId)
		{
			return null;
		}

		public DataSet GetDocImage(S_ControlsCollection CollezioneControlli)
		{
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DOCUMENTI.SP_GETDOCUMENTOIMAGE";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}
		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			return 0;
		}

		#endregion
	}
}
