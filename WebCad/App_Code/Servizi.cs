using System;
using System.Data;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;

namespace WebCad
{
	/// <summary>
	/// Descrizione di riepilogo per Servizi.
	/// </summary>
	public class Servizi
	{
		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
		public Servizi()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
		public  DataSet GetServiziEdifici(int bl_id)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_id_bl";
			s_Id.DbType = CustomDBType.Integer;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = 0;
			s_Id.Value = bl_id;

			S_Controls.Collections.S_Object s_Servizio_id = new S_Object();
			s_Servizio_id.ParameterName = "p_id_servizio";
			s_Servizio_id.DbType = CustomDBType.Integer;
			s_Servizio_id.Direction = ParameterDirection.Input;
			s_Servizio_id.Index = 1;
			s_Servizio_id.Value = 0;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 2;

			_SColl.Add(s_Id);
			_SColl.Add(s_Servizio_id);
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CAD.SP_GETSERVIZIEDIFICI";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql);
			return _Ds;		
		}

		public DataSet GetStanzeBuilding(int id_bl,int id_piano, string descrizione)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();
				
			S_Controls.Collections.S_Object s_id = new S_Object();
			s_id.ParameterName = "p_Bl_Id";
			s_id.DbType = CustomDBType.Integer;
			s_id.Direction = ParameterDirection.Input;
			s_id.Index = 0;
			s_id.Value = id_bl;	
			_SColl.Add(s_id);

			S_Controls.Collections.S_Object s_piano = new S_Object();
			s_piano.ParameterName = "p_piano";
			s_piano.DbType = CustomDBType.Integer;
			s_piano.Direction = ParameterDirection.Input;
			s_piano.Index = 1;
			s_piano.Value = id_piano;	
			_SColl.Add(s_piano);

			S_Controls.Collections.S_Object pDescrizione = new S_Object();
			pDescrizione.ParameterName = "descr";
			pDescrizione.DbType = CustomDBType.VarChar;
			pDescrizione.Direction = ParameterDirection.Input;
			pDescrizione.Size=200;
			pDescrizione.Index = 2;
			pDescrizione.Value = descrizione;	
			_SColl.Add(pDescrizione);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 3;
				
		
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CAD.SP_STANZE_EDIFICIO";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql);			
				
			return _Ds;		
		}

		public  DataSet GetAllEQSTD(int idBl, int idFl,int IdServio, string descrizione)
		{
			DataSet _Ds;
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection(); 

			S_Controls.Collections.S_Object s_id = new S_Object();
			s_id.ParameterName = "p_Bl_Id";
			s_id.DbType = CustomDBType.Integer;
			s_id.Direction = ParameterDirection.Input;
			s_id.Index = 0;
			s_id.Value = idBl;	
			CollezioneControlli.Add(s_id);

			S_Controls.Collections.S_Object s_piano = new S_Object();
			s_piano.ParameterName = "p_fl_id";
			s_piano.DbType = CustomDBType.Integer;
			s_piano.Direction = ParameterDirection.Input;
			s_piano.Index = 1;
			s_piano.Value = idFl;	
			CollezioneControlli.Add(s_piano);

			S_Controls.Collections.S_Object pServizioId = new S_Object();
			pServizioId.ParameterName = "pServizioId";
			pServizioId.DbType = CustomDBType.Integer;
			pServizioId.Direction = ParameterDirection.Input;
			pServizioId.Index = 2;
			pServizioId.Value = IdServio;	
			CollezioneControlli.Add(pServizioId);

			S_Controls.Collections.S_Object pDescrizione = new S_Object();
			pDescrizione.ParameterName = "p_descr";
			pDescrizione.DbType = CustomDBType.VarChar;
			pDescrizione.Direction = ParameterDirection.Input;
			pDescrizione.Size=200;
			pDescrizione.Index = 3;
			pDescrizione.Value = descrizione;	
			CollezioneControlli.Add(pDescrizione);

			S_Controls.Collections.S_Object S_Cursor=new S_Object();
			S_Cursor.ParameterName ="IO_CURSOR";
			S_Cursor.DbType=CustomDBType.Cursor;
			S_Cursor.Direction=ParameterDirection.Output;
			S_Cursor.Index = 4;
		
			CollezioneControlli.Add(S_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDL=new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CAD.SP_GETALLEQSTD";
			_Ds=_OraDL.GetRows(CollezioneControlli,s_StrSql).Copy();
			return _Ds;
		}


		/// <summary>
		/// Recupera l'apparechiatura
		/// </summary>
		/// <param name="id_bl"></param>
		/// <param name="id_corpo"></param>
		/// <param name="id_piano"></param>
		/// <param name="id_eq"></param>
		/// <returns></returns>
		public DataSet GetEQ(int id_bl,int id_corpo,int id_stanza,int id_eq)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();
				
			S_Controls.Collections.S_Object s_id = new S_Object();
			s_id.ParameterName = "p_bl_id";
			s_id.DbType = CustomDBType.Integer;
			s_id.Direction = ParameterDirection.Input;
			s_id.Index = 0;
			s_id.Value = id_bl;	
			_SColl.Add(s_id);

			S_Controls.Collections.S_Object s_stanza = new S_Object();
			s_stanza.ParameterName = "p_stanza";
			s_stanza.DbType = CustomDBType.Integer;
			s_stanza.Direction = ParameterDirection.Input;
			s_stanza.Index = 1;
			s_stanza.Value = id_stanza;	
			_SColl.Add(s_stanza);

			S_Controls.Collections.S_Object s_corpo = new S_Object();
			s_corpo.ParameterName = "p_corpo";
			s_corpo.DbType = CustomDBType.Integer;
			s_corpo.Direction = ParameterDirection.Input;
			s_corpo.Index = 2;
			s_corpo.Value = id_corpo;	
			_SColl.Add(s_corpo);

			S_Controls.Collections.S_Object s_eq = new S_Object();
			s_eq.ParameterName = "p_eq_id";
			s_eq.DbType = CustomDBType.Integer;
			s_eq.Direction = ParameterDirection.Input;
			s_eq.Index = 3;
			s_eq.Value = id_eq;	
			_SColl.Add(s_eq);


			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 4;
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CAD.SP_GETEQ";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql);			
				
			return _Ds;		
		}
		/// <summary>
		/// Recupera le Stanze
		/// </summary>
		/// <param name="id_bl"></param>
		/// <param name="id_corpo"></param>
		/// <param name="id_piano"></param>
		/// <param name="id_eq"></param>
		/// <returns></returns>
		public DataSet GetRM(int id_bl,int id_corpo,int id_stanza)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();
				
			S_Controls.Collections.S_Object s_id = new S_Object();
			s_id.ParameterName = "p_bl_id";
			s_id.DbType = CustomDBType.Integer;
			s_id.Direction = ParameterDirection.Input;
			s_id.Index = _SColl.Count;
			s_id.Value = id_bl;	
			_SColl.Add(s_id);

			S_Controls.Collections.S_Object s_stanza = new S_Object();
			s_stanza.ParameterName = "p_stanza";
			s_stanza.DbType = CustomDBType.Integer;
			s_stanza.Direction = ParameterDirection.Input;
			s_stanza.Index = _SColl.Count;
			s_stanza.Value = id_stanza;	
			_SColl.Add(s_stanza);

			S_Controls.Collections.S_Object s_corpo = new S_Object();
			s_corpo.ParameterName = "p_corpo";
			s_corpo.DbType = CustomDBType.Integer;
			s_corpo.Direction = ParameterDirection.Input;
			s_corpo.Index = _SColl.Count;
			s_corpo.Value = id_corpo;	
			_SColl.Add(s_corpo);



			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = _SColl.Count;
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CAD.SP_GETRM";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql);			
				
			return _Ds;		
		}
		public DataSet GetBL(int id_bl)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();
				
			S_Controls.Collections.S_Object s_id = new S_Object();
			s_id.ParameterName = "p_bl_id";
			s_id.DbType = CustomDBType.Integer;
			s_id.Direction = ParameterDirection.Input;
			s_id.Index = _SColl.Count;
			s_id.Value = id_bl;	
			_SColl.Add(s_id);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = _SColl.Count;
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CAD.SP_GETBL";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql);			
				
			return _Ds;		
		}
	}
}
