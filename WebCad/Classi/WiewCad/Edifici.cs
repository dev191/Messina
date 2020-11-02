using System;
using System.Data;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using WebCad;
using WebCad.Classi;

namespace WebCad.WiewCad
{
	/// <summary>
	/// Descrizione di riepilogo per Edifici.
	/// </summary>
	public class Edifici : AbstractBase
	{
		public Edifici()
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
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			DataSet _Ds;		

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CAD.SP_GETEDIFICI";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}

		public  DataSet GetDataByCampus(string Capus)
		{
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object pCampus = new S_Object();
			pCampus.ParameterName = "pCampus";
			pCampus.DbType = CustomDBType.VarChar;
			pCampus.Direction = ParameterDirection.Input;
			pCampus.Size = 64;
			pCampus.Index = 1;
			pCampus.Value = Capus;
			
			CollezioneControlli.Add(pCampus);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 2;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CAD.SP_GETEDIFICIBYCAMPUS";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CAD.SP_GETEDIFICI";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public override DataSet GetSingleData(int itemId)
		{
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			DataSet _Ds;	
	
			S_Controls.Collections.S_Object id_bl = new S_Object();
			id_bl.ParameterName = "id_bl";
			id_bl.DbType = CustomDBType.Integer;
			id_bl.Direction = ParameterDirection.Input;
			id_bl.Value = itemId;
			id_bl.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(id_bl);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CAD.SP_GETEDIFICIPIANI";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			return 0;
		}
	}
}
