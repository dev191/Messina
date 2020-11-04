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

namespace TheSite.Classi.ManCorrettiva
{
	/// <summary>
	/// Descrizione di riepilogo per AnalisiCostiMateriali.
	/// </summary>
	public class AnalisiCostiMateriali:AbstractBase
	{
		public AnalisiCostiMateriali()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
/// <summary>
/// Ricerca
/// </summary>
/// <param name="CollezioneControlli"></param>
/// <returns></returns>
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;
					
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "io_cursor";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 0;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "Pack_WrMateriali.getMateriali";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;				
		
		}
/// <summary>
/// Carica Materiali
/// </summary>
/// <returns></returns>
		public override DataSet GetData()
		{
			DataSet _Ds;
					
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "io_cursor";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 0;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "Pack_WrMateriali.getAllMateriali";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;				
		
		}

		public override DataSet GetSingleData(int itemId)
		{
			DataSet _Ds;	
			int cntParametri = 0;
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			S_Object p_id = new S_Object();
			p_id.ParameterName = "p_id";
			p_id.DbType = CustomDBType.Integer;
			p_id.Direction = ParameterDirection.Input;
			p_id.Index = cntParametri++;
			p_id.Value = itemId;
			CollezioneControlli.Add(p_id);
			
			S_Object pCursor = new S_Object();
			pCursor.ParameterName = "IO_CURSOR";
			pCursor.DbType = CustomDBType.Cursor;
			pCursor.Direction = ParameterDirection.Output;
			pCursor.Index = cntParametri++;
			CollezioneControlli.Add(pCursor);			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "Pack_WrMateriali.getSingleMateriale";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
			return _Ds;
		}



		#region Proprietà Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{

			int i_MaxParametri = CollezioneControlli.Count + 1;			
			
			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_operazione";
			s_Operazione.DbType = CustomDBType.VarChar;
			s_Operazione.Direction = ParameterDirection.Input;
			s_Operazione.Index = i_MaxParametri++;
			s_Operazione.Value = Operazione.ToString();

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri++;

	
			CollezioneControlli.Add(s_Operazione);
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "Pack_WrMateriali.ExecuteGestioneMateriale");
			return i_Result;
			
		}
		

		#endregion
	}
}
