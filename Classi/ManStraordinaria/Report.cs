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

namespace TheSite.Classi.ManStraordinaria
{
	/// <summary>
	/// Descrizione di riepilogo per AggiornamentoRdl.
	/// </summary>
	public class Report :AbstractBase
	{
		private string username=string.Empty;
		public Report()
		{
			
		}
		public Report(string Username)
		{
			username=Username;
		}
		#region Metodi Pubblici

		public override DataSet GetData()
		{
			return null;	
		}
	
		/// <summary>
		/// Recupero i Livelli di Urgenza
		/// </summary>
		/// <returns></returns>
		
		public  DataSet GetDatiFondo(int anno)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_anno = new S_Object();
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.Integer;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Value =anno;
			s_p_anno.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_p_anno);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MS.SP_GETREPORTFONDI";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}

		public  DataSet GetDatiSpeso(int TipoInterventoId,int anno)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_anno = new S_Object();
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.Integer;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Value =anno;
			s_p_anno.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_p_anno);

			S_Controls.Collections.S_Object s_p_tipointervento = new S_Object();
			s_p_tipointervento.ParameterName = "p_tipointervento";
			s_p_tipointervento.DbType = CustomDBType.Integer;
			s_p_tipointervento.Direction = ParameterDirection.Input;
			s_p_tipointervento.Value =TipoInterventoId;
			s_p_tipointervento.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_p_tipointervento);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MS.SP_GETREPORTSPESO";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}

		public  DataSet GetDatiPresunto(int TipoInterventoId,int anno)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_anno = new S_Object();
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.Integer;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Value =anno;
			s_p_anno.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_p_anno);

			S_Controls.Collections.S_Object s_p_tipointervento = new S_Object();
			s_p_tipointervento.ParameterName = "p_tipointervento";
			s_p_tipointervento.DbType = CustomDBType.Integer;
			s_p_tipointervento.Direction = ParameterDirection.Input;
			s_p_tipointervento.Value =TipoInterventoId;
			s_p_tipointervento.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_p_tipointervento);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MS.SP_GETREPORTPRESUNTO";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		public  DataSet GetDatiSaldo(int TipoInterventoId,int anno)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_anno = new S_Object();
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.Integer;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Value =anno;
			s_p_anno.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_p_anno);		
	
			S_Controls.Collections.S_Object s_p_tipointervento = new S_Object();
			s_p_tipointervento.ParameterName = "p_tipointervento";
			s_p_tipointervento.DbType = CustomDBType.Integer;
			s_p_tipointervento.Direction = ParameterDirection.Input;
			s_p_tipointervento.Value =TipoInterventoId;
			s_p_tipointervento.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_p_tipointervento);


			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MS.SP_GETREPORTSALDO";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}

		public  DataSet GetDatiDettaglio(int TipoInterventoId,int anno,string tipo)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_anno = new S_Object();
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.Integer;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Value =anno;
			s_p_anno.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_p_anno);		
	
			S_Controls.Collections.S_Object s_p_tipointervento = new S_Object();
			s_p_tipointervento.ParameterName = "p_tipointervento";
			s_p_tipointervento.DbType = CustomDBType.Integer;
			s_p_tipointervento.Direction = ParameterDirection.Input;
			s_p_tipointervento.Value =TipoInterventoId;
			s_p_tipointervento.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_p_tipointervento);


			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			
			string s_StrSql = "PACK_MS.SP_GETREPORTDETTAGLIO";	
			if(tipo=="Presunto")
				s_StrSql = "PACK_MS.SP_GETREPORTDETTAGLIOPRES";	
			
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}

		public  DataSet GetDatiDettaglioSaldo(int TipoInterventoId,int anno)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_anno = new S_Object();
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.Integer;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Value =anno;
			s_p_anno.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_p_anno);		
	
			S_Controls.Collections.S_Object s_p_tipointervento = new S_Object();
			s_p_tipointervento.ParameterName = "p_tipointervento";
			s_p_tipointervento.DbType = CustomDBType.Integer;
			s_p_tipointervento.Direction = ParameterDirection.Input;
			s_p_tipointervento.Value =TipoInterventoId;
			s_p_tipointervento.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_p_tipointervento);


			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			
			string s_StrSql = "PACK_MS.SP_GETREPORTDETTAGLIOSALDO";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}

		public  DataSet GetDatiTotaliDettaglio(int TipoInterventoId,int anno,string tipo)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_anno = new S_Object();
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.Integer;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Value =anno;
			s_p_anno.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_p_anno);		
	
			S_Controls.Collections.S_Object s_p_tipointervento = new S_Object();
			s_p_tipointervento.ParameterName = "p_tipointervento";
			s_p_tipointervento.DbType = CustomDBType.Integer;
			s_p_tipointervento.Direction = ParameterDirection.Input;
			s_p_tipointervento.Value =TipoInterventoId;
			s_p_tipointervento.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_p_tipointervento);


			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MS.SP_GETREPORTTOTDETTAGLIO";	
			if(tipo=="Presunto")
				s_StrSql = "PACK_MS.SP_GETREPORTTOTDETTAGLIOPRES";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}

		public override DataSet GetSingleData(int itemId)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_Fondo_Id";
			s_Id.DbType = CustomDBType.Integer;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = 0;
			s_Id.Value = itemId;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SColl.Add(s_Id);
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MS.SP_GETREPORTFONDO";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;		
		}	



		public  override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			return null;	
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

