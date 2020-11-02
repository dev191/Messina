using System;
using System.Data;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using WebCad.Classi;

namespace WebCad.WiewCad
{
	/// <summary>
	/// Descrizione di riepilogo per RiferimentiCad.
	/// </summary>
	public class RiferimentiCad : AbstractBase
	{
		public RiferimentiCad()
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
			DataSet _Ds = null;		

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
			string s_StrSql = "PACK_CAD.SP_GETRIFERIMENTICAD";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public DataSet GetIDEQfromCodice(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CAD.SP_GETID_EQ";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public DataSet GetIDRMfromCodice(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CAD.SP_GETID_RM";	
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


		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public DataSet GetDataPerDwf(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CAD.SP_GETPLANIMETRIA";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}

		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public DataSet GetDataPerDwfApp(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CAD.SP_GETPLANIMETRIAEQ";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			return 0;
		}
	}
}
