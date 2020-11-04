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
	/// Descrizione di riepilogo per ManutenzioneRichiestaIntervento.
	/// Usata dalla Pagina RapportoTecnicoIntervento.aspx
	/// </summary>
	public class RichiestaIntervento : AbstractBase 
	{
		private string username=string.Empty;
		public RichiestaIntervento(string Username)
		{
			username=Username;
		}
		
		#region Metodi Pubblici

		public override DataSet GetData()
		{
			return null;
		}

		public  override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			return null;
		}

		public override DataSet GetSingleData(int itemId)
		{

			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_Wr_Id = new S_Object();
			s_p_Wr_Id.ParameterName = "p_WO_Id";
			s_p_Wr_Id.DbType = CustomDBType.Integer;
			s_p_Wr_Id.Direction = ParameterDirection.Input;
			s_p_Wr_Id.Index = CollezioneControlli.Count + 1;
			s_p_Wr_Id.Value =itemId;
			CollezioneControlli.Add(s_p_Wr_Id);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_ORD.SP_GETRAPPORTOTECNICO";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
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
