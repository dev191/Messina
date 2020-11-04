using System;
using System.Data;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;

namespace TheSite.Classi.RptRtf
{
	/// <summary>
	/// Descrizione di riepilogo per DatiRtf.
	/// </summary>
	public class DatiRtf : AbstractBase
	{
		public DatiRtf()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			return 0;
		}
		public override DataSet GetData()
		{
			return null;
		}
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			return null;
		}

		public override DataSet GetSingleData(int itemId)
		{
			return null;
		}


		public  DataTable  GetDatiRtfSgaRtf(int WrId)
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli= new S_ControlsCollection();
			DataSet _Ds;	
			S_Controls.Collections.S_Object pWoId = new S_Object();
			pWoId.ParameterName = "pIdWr";
			pWoId.DbType = CustomDBType.Integer;
			pWoId.Direction = ParameterDirection.Input;
			pWoId.Index = 0;
			pWoId.Value = WrId;
			CollezioneControlli.Add(pWoId);

			S_Controls.Collections.S_Object pCursor = new S_Object();
			pCursor.ParameterName = "pCursor";
			pCursor.DbType = CustomDBType.Cursor;
			pCursor.Direction = ParameterDirection.Output;
			pCursor.Index =  1;
			CollezioneControlli.Add(pCursor);

		

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_RPT_RTF.GET_SGA_H3G";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();	
			return _Ds.Tables[0];	
		}
		
	}
}
