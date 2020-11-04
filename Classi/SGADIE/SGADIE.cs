using System;
using System.Data;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;



namespace TheSite.Classi.SGA_DIE
{
	/// <summary>
	/// Descrizione di riepilogo per SGADIE.
	/// </summary>
	public class SGADIE
	{
		public SGADIE()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
	
		public  DataSet  GetSGA(int WrId)
		{
			DataSet _Ds;

			S_Controls.Collections.S_ControlsCollection CollezioneControlli= new S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_p_wr_id = new S_Object();
			s_p_wr_id.ParameterName = "p_wr_id";
			s_p_wr_id.DbType = CustomDBType.Integer;
			s_p_wr_id.Direction = ParameterDirection.Input;
			s_p_wr_id.Index = 0;
			s_p_wr_id.Value = WrId;
			CollezioneControlli.Add(s_p_wr_id);

			S_Controls.Collections.S_Object pCursor = new S_Object();
			pCursor.ParameterName = "pCursor";
			pCursor.DbType = CustomDBType.Cursor;
			pCursor.Direction = ParameterDirection.Output;
			pCursor.Index =  1;
			CollezioneControlli.Add(pCursor);
		

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
			string s_StrSql = "PACK_SGA_DIE.SP_GETSGA";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();	
			return _Ds;	
		}
		
	}
	}

