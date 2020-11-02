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
	/// Descrizione di riepilogo per AnagrafeDocDWF.
	/// </summary>
	public class AnagrafeDocDWF: AbstractBase
	{
		private string username;
		public AnagrafeDocDWF(string UserName)
		{
			username=UserName;
		}
		public override DataSet GetData()
		{
			return null;	
		}
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			return null;	
		}
		/// <summary>
		/// Recupera tutti i documenti legati ad un edificio
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public override DataSet GetSingleData(int itemId)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_bl = new S_Object();
			s_p_id_bl.ParameterName = "p_id_bl";
			s_p_id_bl.DbType = CustomDBType.Integer;
			s_p_id_bl.Direction = ParameterDirection.Input;
			s_p_id_bl.Index = CollezioneControlli.Count + 1;
            s_p_id_bl.Value =itemId;
            CollezioneControlli.Add(s_p_id_bl);

			S_Controls.Collections.S_Object s_p_id_doc = new S_Object();
			s_p_id_doc.ParameterName = "p_id_doc";
			s_p_id_doc.DbType = CustomDBType.Integer;
			s_p_id_doc.Direction = ParameterDirection.Input;
			s_p_id_doc.Index = CollezioneControlli.Count + 1;
			s_p_id_doc.Value =0;
			CollezioneControlli.Add(s_p_id_doc);

			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index = CollezioneControlli.Count + 1;
			s_p_username.Size =50;
			s_p_username.Value =this.username ;
			CollezioneControlli.Add(s_p_username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DWF.GETDODDWF";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}
		public  DataSet GetSingleData(int IdBl,int idDoc)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_bl = new S_Object();
			s_p_id_bl.ParameterName = "p_id_bl";
			s_p_id_bl.DbType = CustomDBType.Integer;
			s_p_id_bl.Direction = ParameterDirection.Input;
			s_p_id_bl.Index = CollezioneControlli.Count + 1;
			s_p_id_bl.Value =IdBl;
			CollezioneControlli.Add(s_p_id_bl);

			S_Controls.Collections.S_Object s_p_id_doc = new S_Object();
			s_p_id_doc.ParameterName = "p_id_doc";
			s_p_id_doc.DbType = CustomDBType.Integer;
			s_p_id_doc.Direction = ParameterDirection.Input;
			s_p_id_doc.Index = CollezioneControlli.Count + 1;
			s_p_id_doc.Value =idDoc;
			CollezioneControlli.Add(s_p_id_doc);

			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index = CollezioneControlli.Count + 1;
			s_p_username.Size =50;
			s_p_username.Value =this.username ;
			CollezioneControlli.Add(s_p_username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DWF.GETDODDWF";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;	
		}
		public  DataSet GetTipologiaFile()
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index = CollezioneControlli.Count + 1;
			s_p_username.Size =50;
			s_p_username.Value =this.username ;
			CollezioneControlli.Add(s_p_username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DWF.GETTIPOLOGIAFILE";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}
		public  DataSet GetCategoriaGenerali()
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index = CollezioneControlli.Count + 1;
			s_p_username.Size =50;
			s_p_username.Value =this.username ;
			CollezioneControlli.Add(s_p_username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DWF.GETCATEGORIEGENERALI";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}
		public  DataSet GetCategoria(int idCategoriaGenerale)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_bl = new S_Object();
			s_p_id_bl.ParameterName = "p_id_cat";
			s_p_id_bl.DbType = CustomDBType.Integer;
			s_p_id_bl.Direction = ParameterDirection.Input;
			s_p_id_bl.Index = CollezioneControlli.Count + 1;
			s_p_id_bl.Value =idCategoriaGenerale;
			CollezioneControlli.Add(s_p_id_bl);

			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index = CollezioneControlli.Count + 1;
			s_p_username.Size =50;
			s_p_username.Value =this.username ;
			CollezioneControlli.Add(s_p_username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DWF.GETCATEGORIE";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}

		public  DataSet GetTipologiaDoc(int idCategoria)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_bl = new S_Object();
			s_p_id_bl.ParameterName = "p_id_cat";
			s_p_id_bl.DbType = CustomDBType.Integer;
			s_p_id_bl.Direction = ParameterDirection.Input;
			s_p_id_bl.Index = CollezioneControlli.Count + 1;
			s_p_id_bl.Value =idCategoria;
			CollezioneControlli.Add(s_p_id_bl);

			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index = CollezioneControlli.Count + 1;
			s_p_username.Size =50;
			s_p_username.Value =this.username ;
			CollezioneControlli.Add(s_p_username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DWF.GETTIPOLOGIADOCUMENTO";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}

		public  DataSet GetDescrizione(int idTipoDoc)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_tip = new S_Object();
			s_p_id_tip.ParameterName = "p_id_tip";
			s_p_id_tip.DbType = CustomDBType.Integer;
			s_p_id_tip.Direction = ParameterDirection.Input;
			s_p_id_tip.Index = CollezioneControlli.Count + 1;
			s_p_id_tip.Value =idTipoDoc;
			CollezioneControlli.Add(s_p_id_tip);

			S_Controls.Collections.S_Object s_p_username = new S_Object();
			s_p_username.ParameterName = "p_username";
			s_p_username.DbType = CustomDBType.VarChar;
			s_p_username.Direction = ParameterDirection.Input;
			s_p_username.Index = CollezioneControlli.Count + 1;
			s_p_username.Size =50;
			s_p_username.Value =this.username ;
			CollezioneControlli.Add(s_p_username);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DWF.GETDESCRIZIONE";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}

		public  DataSet GetCountDocDwf(int idBl)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_bl = new S_Object();
			s_p_id_bl.ParameterName = "p_id_bl";
			s_p_id_bl.DbType = CustomDBType.Integer;
			s_p_id_bl.Direction = ParameterDirection.Input;
			s_p_id_bl.Index = CollezioneControlli.Count + 1;
			s_p_id_bl.Value =idBl;
			CollezioneControlli.Add(s_p_id_bl);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DWF.GETCOUNTDOCDWF";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}
		public  DataSet PathFileDoc(int idDOC)
		{
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id_doc_dwf = new S_Object();
			s_p_id_doc_dwf.ParameterName = "p_id_doc_dwf";
			s_p_id_doc_dwf.DbType = CustomDBType.Integer;
			s_p_id_doc_dwf.Direction = ParameterDirection.Input;
			s_p_id_doc_dwf.Index = CollezioneControlli.Count + 1;
			s_p_id_doc_dwf.Value =idDOC;
			CollezioneControlli.Add(s_p_id_doc_dwf);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_DWF.GETPATHFILEDOCDWF";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			
													
			return _Ds;		
		}

		#region Metodi Private

		public override int Update(S_ControlsCollection CollezioneControlli, int itemId)
		{
			return base.Update (CollezioneControlli, itemId);
		}
		public override int Delete(S_ControlsCollection CollezioneControlli, int itemId)
		{
			return base.Delete (CollezioneControlli, itemId);
		}
		public override int Add(S_ControlsCollection CollezioneControlli)
		{
			return base.Add (CollezioneControlli);
		}

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{

			S_Controls.Collections.S_Object s_p_operazione = new S_Controls.Collections.S_Object();
			s_p_operazione.ParameterName = "p_operazione";
			s_p_operazione.DbType = CustomDBType.VarChar;
			s_p_operazione.Direction = ParameterDirection.Input;
			s_p_operazione.Index = CollezioneControlli.Count + 1;
			s_p_operazione.Size =30;

			if (Operazione==ExecuteType.Update)
			{
				s_p_operazione.Value = "UPDATE";
			}
			else if (Operazione==ExecuteType.Insert)
			{
				s_p_operazione.Value = "INSERT";
			}
			else if (Operazione==ExecuteType.Delete)
			{
				s_p_operazione.Value = "DELETE";
			}
			CollezioneControlli.Add(s_p_operazione);

			S_Controls.Collections.S_Object s_p_CurrentUser = new S_Controls.Collections.S_Object();
			s_p_CurrentUser.ParameterName = "p_Username";
			s_p_CurrentUser.DbType = CustomDBType.VarChar;
			s_p_CurrentUser.Direction = ParameterDirection.Input;
			s_p_CurrentUser.Index = CollezioneControlli.Count + 1;
			s_p_CurrentUser.Value = this.username;			
			s_p_CurrentUser.Size = 50;
			CollezioneControlli.Add(s_p_CurrentUser);

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_IdOut);
			//_____________________________________________________________________________________
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			int i_Result=0;
            if (Operazione!=ExecuteType.Delete)
			 i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_DWF.DOCDWF");
			else
	         i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_DWF.DELETEDOCDWF");

			return i_Result;
			//_____________________________________________________________________________________
		}

		#endregion
	}
}
