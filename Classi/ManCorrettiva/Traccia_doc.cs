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
using ApplicationDataLayer.Collections;

namespace TheSite.Classi.ManCorrettiva
{
	/// <summary>
	/// Descrizione di riepilogo per Traccia_doc.
	/// </summary>
	public class Traccia_doc:AbstractBase
	{
		public Traccia_doc()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}

		public int GetCount(S_ControlsCollection CollezioneControlli)
		{
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);					
		
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_TRACCIA_DOC.SP_GETCountLOG";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();


			return	int.Parse(_Ds.Tables[0].Rows[0][0].ToString());
		}

		public  DataSet GetSfoglia(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;	
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_TRACCIA_DOC.SP_GETLOG";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}
		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			int i=0;
			return i;
		}
		public override DataSet GetData()
		{
			return null;
		}
		public override DataSet GetData(S_Controls.Collections.S_ControlsCollection CollezioneControlli)
		{
			return null;
		}
		public override DataSet GetSingleData(int ItemID)
		{
			return null;
		}
		public  DataSet GetDestinatariInvio(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_TRACCIA_DOC.SP_Destinatari";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}
		public DataSet GetDestinatari(int bl_id,int servizio_id,string TipoDoc)
		{
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			S_ControlsCollection _SColl = new S_ControlsCollection();
		
			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_bl_id";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Value = bl_id;
			_SColl.Add(p);

			p = new S_Object();
			p.ParameterName = "p_servizio_id";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Value = servizio_id;
			_SColl.Add(p);

			p = new S_Object();
			p.ParameterName = "p_tipo_doc";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Value = TipoDoc.ToString();
			p.Size=250;
			_SColl.Add(p);

			p = new S_Object();
			p.ParameterName = "IO_CURSOR";
			p.DbType = CustomDBType.Cursor;
			p.Direction = ParameterDirection.Output;
			p.Index = _SColl.Count;
			_SColl.Add(p);

			string s_StrSql = "PACK_TRACCIA_DOC.SP_GETDESTINATARI";
			 
			DataSet _Ds =  _OraDl.GetRows(_SColl, s_StrSql);

			return _Ds;
		}
	
	}
}
