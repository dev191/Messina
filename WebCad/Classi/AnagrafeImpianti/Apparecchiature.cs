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
	/// Descrizione di riepilogo per Apparecchiature.
	/// Autore Fabio Civerchia
	/// </summary>
	public class Apparecchiature: AbstractBase  
	{
		private string s_username;
		public Apparecchiature(string Username)
		{
		 this.s_username=Username;
		}
		public Apparecchiature()
		{
			
		}

		/// <summary>
		/// Metodo che recupera tutte le apparecchiature legate ad l'utente loggato
		/// Viene eseguita all'ingresso di ogni pagina la prima volta
		/// </summary>
		/// <returns></returns>
		public override DataSet GetData()
		{
			DataSet _Ds;
			
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = 0;
			s_UserName.Value = this.s_username;			
			s_UserName.Size = 50;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			CollezioneControlli.Add(s_UserName);
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_APPARECCHIATURE.SP_GETSTDALLAPPARECCHIATURA";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;		
		}
		public DataSet RicercaStanze(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_APPARECCHIATURE.SP_GETALLSTANZE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}

		/// <summary>
		/// Metodo che recupera tutte le apparecchiature legate ad l'utente loggato
		/// 
		/// Viene eseguita all'ingresso di ogni pagina la prima volta
		/// </summary>
		/// <param name="CollezioneControlli"> Accetta due parametri in ingressi che sono p_Servizio di tipo number
		/// che indica il servizio e  p_Bl_Id di tipo varchar2 che indica l'edificio
		///  </param>
		/// <returns></returns>
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = CollezioneControlli.Count + 1;
			s_UserName.Value = this.s_username;			
			s_UserName.Size = 50;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_APPARECCHIATURE.SP_GETSTDAPPARECCHIATURE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}

		public  DataSet GetDataServizi(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = CollezioneControlli.Count + 1;
			s_UserName.Value = this.s_username;			
			s_UserName.Size = 50;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_APPARECCHIATURE.SP_GETSTDSERVIZIO";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}

		/// <summary>
		/// Ricerca una determinata apparecchiatura
		/// </summary>
		/// <param name="CollezioneControlli">I parametri che devono essere passati sono:
		/// p_Bl_Id di tipo varchar2,
		///p_campus di tipo  varchar2,
		///p_Servizio di tipo number,
		///p_eqstd di tipo varchar2,
		///p_eqid di tipo Varchar2
		/// </param>
		/// <returns></returns>
		public DataSet RicercaApparecchiatura(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = CollezioneControlli.Count + 1;
			s_UserName.Value = this.s_username;			
			s_UserName.Size = 50;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_APPARECCHIATURE.SP_RICERCAAPPARECCHIATURA";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		/// <summary>
		/// Ricerca una determinata apparecchiatura con Piano e Stanza
		/// </summary>
		/// <param name="CollezioneControlli">I parametri che devono essere passati sono:
		/// p_Bl_Id di tipo varchar2,
		///p_campus di tipo  varchar2,
		///p_Servizio di tipo number,
		///p_eqstd di tipo varchar2,
		///p_eqid di tipo Varchar2
		///p_piano integer
		///p_stanza integer
		/// </param>
		/// <returns></returns>
		public DataSet RicercaApparecchiaturaPS(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = CollezioneControlli.Count;
			s_UserName.Value = this.s_username;			
			s_UserName.Size = 50;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_APPARECCHIATURE.SP_RICERCAAPPARECCHIATURAPS";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}
		public  DataSet GetSfogliaRDLEQ(S_ControlsCollection CollezioneControlli,int pageIndex,int pageSize)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_utente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;

			CollezioneControlli.Add(s_IdIn);

//			S_Controls.Collections.S_Object s_pageindex = new S_Object();
//			s_pageindex.ParameterName = "p_pageindex";
//			s_pageindex.DbType = CustomDBType.Integer;
//			s_pageindex.Direction = ParameterDirection.Input;
//			s_pageindex.Index = CollezioneControlli.Count + 1;
//			s_pageindex.Value = pageIndex;
//
//			CollezioneControlli.Add(s_pageindex);
//
//			S_Controls.Collections.S_Object s_pagesize = new S_Object();
//			s_pagesize.ParameterName = "p_pagesize";
//			s_pagesize.DbType = CustomDBType.Integer;
//			s_pagesize.Direction = ParameterDirection.Input;
//			s_pagesize.Index = CollezioneControlli.Count + 1;
//			s_pagesize.Value = pageSize;
//
//			CollezioneControlli.Add(s_pagesize);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql;			
			s_StrSql = "PACK_APPARECCHIATURE.SP_GetSfogliaRDLEQ";			
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}

		public  DataSet GetTotRDLEQ(S_ControlsCollection CollezioneControlli,int pageIndex,int pageSize)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_utente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;

			CollezioneControlli.Add(s_IdIn);

			S_Controls.Collections.S_Object s_pageindex = new S_Object();
			s_pageindex.ParameterName = "p_pageindex";
			s_pageindex.DbType = CustomDBType.Integer;
			s_pageindex.Direction = ParameterDirection.Input;
			s_pageindex.Index = CollezioneControlli.Count + 1;
			s_pageindex.Value = pageIndex;

			CollezioneControlli.Add(s_pageindex);

			S_Controls.Collections.S_Object s_pagesize = new S_Object();
			s_pagesize.ParameterName = "p_pagesize";
			s_pagesize.DbType = CustomDBType.Integer;
			s_pagesize.Direction = ParameterDirection.Input;
			s_pagesize.Index = CollezioneControlli.Count + 1;
			s_pagesize.Value = pageSize;

			CollezioneControlli.Add(s_pagesize);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql;			
			s_StrSql = "PACK_APPARECCHIATURE.SP_GetTOTRDLEQ";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}

		public  DataSet GetSfogliaRDLEQ(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_utente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_APPARECCHIATURE.SP_GetSfogliaRDLEQ";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}

		public override DataSet GetSingleData(int itemId)
		{
			return null;
		}

		#region Metodi Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			return 0;
		}

		#endregion

		public DataSet RicercaStd(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;		
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = CollezioneControlli.Count;
			s_UserName.Value = this.s_username;			
			s_UserName.Size = 50;
			CollezioneControlli.Add(s_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_APPARECCHIATURE.SP_RICERCASTD";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	
		}


		

	}
}
