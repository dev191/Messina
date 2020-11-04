using System;
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

namespace TheSite.Classi.ClassiAnagrafiche
{
	/// <summary>
	/// Descrizione di riepilogo per Ditte.
	/// </summary>
	
		public class Ditte : AbstractBase
		{
			#region Dichiarazioni

			private string s_Name = string.Empty;

			#endregion
			public Ditte()	{}

			public Ditte(int Id)	: this(Id, string.Empty) {}

			public Ditte(int Id, string Name) 
			{
				this.Id = Id;
				this.Name = Name;
			}

			#region Metodi Pubblici

			
			
			/// <summary>
			/// DataSet con tutti i record
			/// </summary>
			/// <returns></returns>
			public override DataSet GetData()
			{			
				DataSet _Ds;
			
				S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = CollezioneControlli.Count + 1;

				CollezioneControlli.Add(s_Cursor);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_DITTE.SP_GETALLDITTE";	
				_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

				return _Ds;				
			}

			/// <summary>
			/// DataSet con i record selezionati in base alla collection
			/// </summary>
			/// <param name="CollezioneCOntrolli"></param>
			/// <param name="NomeProcedura"></param>
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
				string s_StrSql = "PACK_DITTE.SP_GETDITTE";	
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
				DataSet _Ds;

				S_ControlsCollection _SColl = new S_ControlsCollection();

				S_Controls.Collections.S_Object s_Id = new S_Object();
				s_Id.ParameterName = "p_Ditta_Id";
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
				string s_StrSql = "PACK_DITTE.SP_GETSINGLEDITTE";	
				_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

				this.Id = itemId;
				return _Ds;		
			}

			
			public DataSet GetServiziDitta(int idditta)
			{
				DataSet _Ds;
			
				S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
				S_Controls.Collections.S_Object s_id = new S_Object();
				s_id.ParameterName = "p_Ditta_id";
				s_id.DbType = CustomDBType.Integer;
				s_id.Direction = ParameterDirection.Input;
				s_id.Index = 0;
				s_id.Value = idditta;						
			
				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 1;

				CollezioneControlli.Add(s_id);
				CollezioneControlli.Add(s_Cursor);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_DITTE.SP_GETSERVIZI_DITTA";	
				_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

				return _Ds;		
			}

			
			public int UpdateServizi_Ditta(S_ControlsCollection CollezioneControlli, ExecuteType Operazione)
			{
				int i_MaxParametri = CollezioneControlli.Count + 1;			
			
				i_MaxParametri ++;
			
				S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
				s_CurrentUser.ParameterName = "p_CurrentUser";
				s_CurrentUser.DbType = CustomDBType.VarChar;
				s_CurrentUser.Direction = ParameterDirection.Input;
				s_CurrentUser.Index = i_MaxParametri;
				s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

				i_MaxParametri ++;
			
				S_Controls.Collections.S_Object s_Operazione = new S_Object();
				s_Operazione.ParameterName = "p_Operazione";
				s_Operazione.DbType = CustomDBType.VarChar;
				s_Operazione.Direction = ParameterDirection.Input;
				s_Operazione.Index = i_MaxParametri;
				s_Operazione.Value = Operazione.ToString();

				i_MaxParametri ++;

				S_Controls.Collections.S_Object s_IdOut = new S_Object();
				s_IdOut.ParameterName = "p_IdOut";
				s_IdOut.DbType = CustomDBType.Integer;
				s_IdOut.Direction = ParameterDirection.Output;
				s_IdOut.Index = i_MaxParametri;

				CollezioneControlli.Add(s_CurrentUser);	
				CollezioneControlli.Add(s_Operazione);
				CollezioneControlli.Add(s_IdOut);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

				int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_DITTE.SP_EXECUTESERVIZIDITTA");
			
				return i_Result;
			}			

			public DataSet GetDitteMaster()
			{
				DataSet _Ds;

				S_ControlsCollection _SColl = new S_ControlsCollection();
				
				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 1;
				
				_SColl.Add(s_Cursor);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_DITTE.SP_GETDITTEMASTER";	
				_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			
				
				return _Ds;		
			}
			
			public DataSet GetDitteSub()
			{
				DataSet _Ds;

				S_ControlsCollection _SColl = new S_ControlsCollection();
				
				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 1;
				
				_SColl.Add(s_Cursor);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_DITTE.SP_GETDITTESUB";	
				_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			
				
				return _Ds;		
			}

			public DataSet GetFornitoriDitta(int idditta)
			{
				DataSet _Ds;
			
				S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
				S_Controls.Collections.S_Object s_id = new S_Object();
				s_id.ParameterName = "p_Ditta_id";
				s_id.DbType = CustomDBType.Integer;
				s_id.Direction = ParameterDirection.Input;
				s_id.Index = 0;
				s_id.Value = idditta;						
			
				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 1;

				CollezioneControlli.Add(s_id);
				CollezioneControlli.Add(s_Cursor);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_DITTE.SP_GETFORNITORI_DITTA";	
				_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

				return _Ds;		
			}

			public DataSet GetDitteFornitoriRuoli(int idditta)
			{
				DataSet _Ds;
			
				S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
				S_Controls.Collections.S_Object s_id = new S_Object();
				s_id.ParameterName = "p_Ditta_id";
				s_id.DbType = CustomDBType.Integer;
				s_id.Direction = ParameterDirection.Input;
				s_id.Index = 0;
				s_id.Value = idditta;
				
				S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
				s_CurrentUser.ParameterName = "p_CurrentUser";
				s_CurrentUser.DbType = CustomDBType.VarChar;
				s_CurrentUser.Direction = ParameterDirection.Input;
				s_CurrentUser.Index = 1;
				s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;
			
				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 2;

				CollezioneControlli.Add(s_id);
				CollezioneControlli.Add(s_CurrentUser);
				CollezioneControlli.Add(s_Cursor);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_DITTE.SP_GETGESTORI_FORNITORI_RUOLO";	
				_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

				return _Ds;		
			}

			public DataSet GetDittaBl(int idbl)
			{
				DataSet _Ds;
			
				S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
				S_Controls.Collections.S_Object s_id = new S_Object();
				s_id.ParameterName = "p_Bl_Id";
				s_id.DbType = CustomDBType.Integer;
				s_id.Direction = ParameterDirection.Input;
				s_id.Index = 0;
				s_id.Value = idbl;						
			
				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 1;

				CollezioneControlli.Add(s_id);
				CollezioneControlli.Add(s_Cursor);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_DITTE.SP_GETDITTABL";	
				_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

				return _Ds;		
			}

			public int UpdateFornitori_Ditta(S_ControlsCollection CollezioneControlli, ExecuteType Operazione)
			{
				int i_MaxParametri = CollezioneControlli.Count + 1;			
			
				i_MaxParametri ++;
			
				S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
				s_CurrentUser.ParameterName = "p_CurrentUser";
				s_CurrentUser.DbType = CustomDBType.VarChar;
				s_CurrentUser.Direction = ParameterDirection.Input;
				s_CurrentUser.Index = i_MaxParametri;
				s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

				i_MaxParametri ++;
			
				S_Controls.Collections.S_Object s_Operazione = new S_Object();
				s_Operazione.ParameterName = "p_Operazione";
				s_Operazione.DbType = CustomDBType.VarChar;
				s_Operazione.Direction = ParameterDirection.Input;
				s_Operazione.Index = i_MaxParametri;
				s_Operazione.Value = Operazione.ToString();

				i_MaxParametri ++;

				S_Controls.Collections.S_Object s_IdOut = new S_Object();
				s_IdOut.ParameterName = "p_IdOut";
				s_IdOut.DbType = CustomDBType.Integer;
				s_IdOut.Direction = ParameterDirection.Output;
				s_IdOut.Index = i_MaxParametri;

				CollezioneControlli.Add(s_CurrentUser);	
				CollezioneControlli.Add(s_Operazione);
				CollezioneControlli.Add(s_IdOut);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

				int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_DITTE.SP_EXECUTEFORNITORIDITTA");
			
				return i_Result;
			}

			




			/// <summary>
			/// 
			/// </summary>
			/// <param name="CollezioneControlli"></param>
			/// <returns></returns>
			
			#endregion

			#region Proprietà Pubbliche


			/// <summary>
			/// 
			/// </summary>
			public string Name
			{
				get {return s_Name;}
				set {s_Name = value;}
			}

			#endregion
	
			#region Metodi Private

			protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
			{
				int i_MaxParametri = CollezioneControlli.Count + 1;			

				// Id
				S_Controls.Collections.S_Object s_IdIn = new S_Object();
				s_IdIn.ParameterName = "p_Id";
				s_IdIn.DbType = CustomDBType.Integer;
				s_IdIn.Direction = ParameterDirection.Input;
				s_IdIn.Index = i_MaxParametri;
				s_IdIn.Value = itemId;
						
				// UTENTE

				S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
				s_CurrentUser.ParameterName = "p_CurrentUser";
				s_CurrentUser.DbType = CustomDBType.VarChar;
				s_CurrentUser.Direction = ParameterDirection.Input;
				s_CurrentUser.Index = i_MaxParametri;
				s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

				i_MaxParametri ++;
			
				// TIPO OPERAZIONE

				S_Controls.Collections.S_Object s_Operazione = new S_Object();
				s_Operazione.ParameterName = "p_Operazione";
				s_Operazione.DbType = CustomDBType.VarChar;
				s_Operazione.Direction = ParameterDirection.Input;
				s_Operazione.Index = i_MaxParametri;
				s_Operazione.Value = Operazione.ToString();

				i_MaxParametri ++;

				// OUT

				S_Controls.Collections.S_Object s_IdOut = new S_Object();
				s_IdOut.ParameterName = "p_IdOut";
				s_IdOut.DbType = CustomDBType.Integer;
				s_IdOut.Direction = ParameterDirection.Output;
				s_IdOut.Index = i_MaxParametri;
				
				CollezioneControlli.Add(s_IdIn);	
				CollezioneControlli.Add(s_CurrentUser);	
				CollezioneControlli.Add(s_Operazione);
				CollezioneControlli.Add(s_IdOut);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

				int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_DITTE.SP_EXECUTEDITTA");
				
				return i_Result;
			}

			#endregion
		}
	}

	