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

namespace WebCad.Classi.ClassiAnagrafiche
{
	/// <summary>
	/// Descrizione di riepilogo per Ditte.
	/// </summary>
	
		public class Buildings : AbstractBase
		{
			#region Dichiarazioni

			private string s_Name = string.Empty;
			private ApplicationDataLayer.OracleDataLayer _OraDl;
			
			#endregion

			public Buildings()	
			{
				_OraDl = new OracleDataLayer(s_ConnStr);
			}

//			public Buildings(int Id)	: this(Id, string.Empty) {}
//
//			public Buildings(int Id, string Name) 
//			{
//				this.Id = Id;
//				this.Name = Name;
//			}

			#region Metodi Pubblici

			public void beginTransaction()
			{
				_OraDl.BeginTransaction();
			}

			public void commitTransaction()
			{
				_OraDl.CommitTransaction();
			}

			public void rollbackTransaction()
			{
				_OraDl.RollbackTransaction();
			}
			
			public int AddServizi(S_ControlsCollection CollezioneControlli, int itemID)
			{
				return this.ExecuteServizi(CollezioneControlli, ExecuteType.Insert, itemID);
			}

			public int DeleteServizi(S_ControlsCollection CollezioneControlli, int itemID)
			{
				return this.ExecuteServizi(CollezioneControlli, ExecuteType.Delete, itemID);
			}

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
				string s_StrSql = "PACK_BUILDINGS.SP_GETALLBUILDINGS";	
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
				string s_StrSql = "PACK_BUILDINGS.SP_GETBUILDINGS";	
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
				s_Id.ParameterName = "p_BL_ID";
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
				string s_StrSql = "PACK_BUILDINGS.SP_GETSINGLEBUILDINGS";	
				_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

				this.Id = itemId;
				return _Ds;		
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="itemId"></param>
			/// <returns></returns>
			public DataSet GetPiano(int edificioId, int pianoId)
			{
				DataSet _Ds;

				S_ControlsCollection _SColl = new S_ControlsCollection();

				S_Controls.Collections.S_Object s_Id = new S_Object();
				s_Id.ParameterName = "p_BL_ID";
				s_Id.DbType = CustomDBType.Integer;
				s_Id.Direction = ParameterDirection.Input;
				s_Id.Index = 0;
				s_Id.Value = edificioId;

				S_Controls.Collections.S_Object s2_Id = new S_Object();
				s2_Id.ParameterName = "p_FL_ID";
				s2_Id.DbType = CustomDBType.Integer;
				s2_Id.Direction = ParameterDirection.Input;
				s2_Id.Index = 0;
				s2_Id.Value = pianoId;
			
			
				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 1;

				_SColl.Add(s_Id);
				_SColl.Add(s2_Id);
				_SColl.Add(s_Cursor);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_CAD.SP_GETDATIPIANO";	
				_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();	
				string xml = _Ds.GetXml();
				this.Id = edificioId;
				return _Ds;		
			}
			public int GetIdBl(string BlId)
			{
				S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
				int cntParametri =0;
				S_Object pBlId = new S_Object();
				pBlId.ParameterName = "pBlId";
				pBlId.DbType = CustomDBType.VarChar;
				pBlId.Direction = ParameterDirection.Input;
				pBlId.Size=8;
				pBlId.Value=BlId;
				pBlId.Index = cntParametri++;
				CollezioneControlli.Add(pBlId);

				S_Object pIdBl = new S_Object();
				pIdBl.ParameterName = "pIdBl";
				pIdBl.DbType = CustomDBType.Integer;
				pIdBl.Direction = ParameterDirection.Output;
				pIdBl.Size=32;
				pIdBl.Index = cntParametri++;
				CollezioneControlli.Add(pIdBl);
				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_CAD.Sp_BlId_To_IdBl";
				//_OraDl.ExecuteProcedure(CollezioneControlli,s_StrSql);
				
				System.Data.OracleClient.OracleParameterCollection pc = _OraDl.ParametersArray(CollezioneControlli,s_StrSql);
				return Convert.ToInt32(pc[1].Value);
			}
			public string GetDescrizionePiano(int IdPiano)
			{
				S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
				int cntParametri =0;
				S_Object pIdPiano = new S_Object();
				pIdPiano.ParameterName = "pIdPiano";
				pIdPiano.DbType = CustomDBType.Integer;
				pIdPiano.Direction = ParameterDirection.Input;
				pIdPiano.Size=32;
				pIdPiano.Value=IdPiano;
				pIdPiano.Index = cntParametri++;
				CollezioneControlli.Add(pIdPiano);

				S_Object pDescrizionePiano = new S_Object();
				pDescrizionePiano.ParameterName = "pDescrizionePiano";
				pDescrizionePiano.DbType = CustomDBType.VarChar;
				pDescrizionePiano.Direction = ParameterDirection.Output;
				pDescrizionePiano.Size=250;
				pDescrizionePiano.Index = cntParametri++;
				CollezioneControlli.Add(pDescrizionePiano);
				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_CAD.Sp_IdPiano_to_decPiano";
				//_OraDl.ExecuteProcedure(CollezioneControlli,s_StrSql);
				
				System.Data.OracleClient.OracleParameterCollection pc = _OraDl.ParametersArray(CollezioneControlli,s_StrSql);
				return Convert.ToString(pc[1].Value);
			}
			/// <summary>
			/// usa il campo bl_id, di fatto chiave primaria della tabella bl
			/// </summary>
			/// <param name="itemId"></param>
			/// <returns></returns>
			public DataSet GetSingleData(string itemId)
			{
				DataSet _Ds;

				S_ControlsCollection _SColl = new S_ControlsCollection();

				S_Controls.Collections.S_Object s_Id = new S_Object();
				s_Id.ParameterName = "p_BL_ID";
				s_Id.DbType = CustomDBType.VarChar;
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
				string s_StrSql = "PACK_BUILDINGS.SP_GETSINGLEBL_FROM_BL_ID";	
				_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

				//this.Id = itemId;
				return _Ds;		
			}

			public DataSet GetServiziBuilding(int idditta)
			{
				DataSet _Ds;
			
				S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
				S_Controls.Collections.S_Object s_id = new S_Object();
				s_id.ParameterName = "p_ID_BL";
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
				string s_StrSql = "PACK_BUILDINGS.SP_GETSERVIZI_BUILDING";	
				_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

				return _Ds;		
			}

			public DataSet GetPianiBuilding(int id_bl)
			{
				DataSet _Ds;

				S_ControlsCollection _SColl = new S_ControlsCollection();
				
				S_Controls.Collections.S_Object s_id = new S_Object();
				s_id.ParameterName = "p_ID_BL";
				s_id.DbType = CustomDBType.Integer;
				s_id.Direction = ParameterDirection.Input;
				s_id.Index = 0;
				s_id.Value = id_bl;	

				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 1;
				
				_SColl.Add(s_id);
				_SColl.Add(s_Cursor);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_BUILDINGS.SP_GETPIANIBUILDING";	
				_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			
				
				return _Ds;		
			}

			public DataSet GetPianiBuilding(string id_bl)
			{
				DataSet _Ds;

				S_ControlsCollection _SColl = new S_ControlsCollection();
				
				S_Controls.Collections.S_Object s_id = new S_Object();
				s_id.ParameterName = "p_ID_BL";
				s_id.DbType = CustomDBType.VarChar;
				s_id.Direction = ParameterDirection.Input;
				s_id.Index = 0;
				s_id.Value = id_bl;	

				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 1;
				
				_SColl.Add(s_id);
				_SColl.Add(s_Cursor);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_CAD.SP_GETPIANIBUILDING";	
				_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			
				
				return _Ds;		
			}

			public int ExecutePianiBuilding(string operazione, long idBl, long idPiano, decimal mQLordi, decimal mQNetti, decimal mQMura)
			{
				int result = 0;

				S_ControlsCollection _SColl = new S_ControlsCollection();
				
				S_Controls.Collections.S_Object s_id = new S_Object();
				s_id.ParameterName = "p_ID_BL";
				s_id.DbType = CustomDBType.Integer;
				s_id.Direction = ParameterDirection.Input;
				s_id.Index = 0;
				s_id.Value = idBl;	

				S_Controls.Collections.S_Object s_idPiano = new S_Object();
				s_idPiano.ParameterName = "p_ID_PIANO";
				s_idPiano.DbType = CustomDBType.Integer;
				s_idPiano.Direction = ParameterDirection.Input;
				s_idPiano.Index = 1;
				s_idPiano.Value = idPiano;	

				S_Controls.Collections.S_Object s_lordi = new S_Object();
				s_lordi.ParameterName = "p_MQLORDI";
				s_lordi.DbType = CustomDBType.Float;
				s_lordi.Direction = ParameterDirection.Input;
				s_lordi.Index = 2;
				s_lordi.Value = mQLordi;	

				S_Controls.Collections.S_Object s_netti = new S_Object();
				s_netti.ParameterName = "p_MQNETTI";
				s_netti.DbType = CustomDBType.Float;
				s_netti.Direction = ParameterDirection.Input;
				s_netti.Index = 3;
				s_netti.Value = mQNetti;	

				S_Controls.Collections.S_Object s_mura = new S_Object();
				s_mura.ParameterName = "p_MQMURA";
				s_mura.DbType = CustomDBType.Float;
				s_mura.Direction = ParameterDirection.Input;
				s_mura.Index = 4;
				s_mura.Value = mQMura;	


				S_Controls.Collections.S_Object s_Output = new S_Object();
				s_Output.ParameterName = "p_IdOut";
				s_Output.DbType = CustomDBType.Integer;
				s_Output.Direction = ParameterDirection.Output;
				s_Output.Index = 5;
				
				_SColl.Add(s_id);
				_SColl.Add(s_idPiano);
				_SColl.Add(s_lordi);
				_SColl.Add(s_netti);
				_SColl.Add(s_mura);
				_SColl.Add(s_Output);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

				if (operazione=="update")
				{
					string s_StrSql = "PACK_BUILDINGS.SP_UPDATEPIANIBUILDING";	
					return result = _OraDl.GetRowsAffected(_SColl, s_StrSql);
				}

				if (operazione=="insert")
				{
					string s_StrSql = "PACK_BUILDINGS.SP_NEWPIANIBUILDING";	
					result = _OraDl.GetRowsAffected(_SColl, s_StrSql);
					return result;
				}

				if (operazione=="delete")
				{
					//string s_StrSql = "PACK_BUILDINGS.SP_NEWPIANIBUILDING";	
					//return result = _OraDl.GetRowsAffected(_SColl, s_StrSql);
				}
				
				return result;		
			}


			public int DeletePianiBuilding(long idBl, long idPiano)
			{
				int result = 0;

				S_ControlsCollection _SColl = new S_ControlsCollection();
				
				S_Controls.Collections.S_Object s_id = new S_Object();
				s_id.ParameterName = "p_ID_BL";
				s_id.DbType = CustomDBType.Integer;
				s_id.Direction = ParameterDirection.Input;
				s_id.Index = 0;
				s_id.Value = idBl;	

				S_Controls.Collections.S_Object s_idPiano = new S_Object();
				s_idPiano.ParameterName = "p_ID_PIANO";
				s_idPiano.DbType = CustomDBType.Integer;
				s_idPiano.Direction = ParameterDirection.Input;
				s_idPiano.Index = 1;
				s_idPiano.Value = idPiano;	


				S_Controls.Collections.S_Object s_Output = new S_Object();
				s_Output.ParameterName = "p_IdOut";
				s_Output.DbType = CustomDBType.Integer;
				s_Output.Direction = ParameterDirection.Output;
				s_Output.Index = 5;
				
				_SColl.Add(s_id);
				_SColl.Add(s_idPiano);
				_SColl.Add(s_Output);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

				string s_StrSql = "PACK_BUILDINGS.SP_DELETEPIANIBUILDING";	
				return result = _OraDl.GetRowsAffected(_SColl, s_StrSql);
		
			}

			public int UpdateFl(int idEdifizio)
			{
				S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
				S_Controls.Collections.S_Object p_bl_id = new S_Object();
				p_bl_id.ParameterName = "p_bl_id";
				p_bl_id.DbType = CustomDBType.Integer;
				p_bl_id.Direction = ParameterDirection.Input;
				p_bl_id.Index = 0;
				p_bl_id.Value = idEdifizio;						
				CollezioneControlli.Add(p_bl_id);

				string s_StrSql = "PACK_RM.SP_UPDATEMQ";	
				try
				{
					_OraDl.GetRowsAffected(CollezioneControlli, s_StrSql);
					return 1;
				}
				catch 
				{ 
					return 0;
				}		 
			}

			public int UpdateAllFl()
			{
				S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
				S_Controls.Collections.S_Object resul = new S_Object();
				resul.ParameterName = "resul";
				resul.DbType = CustomDBType.Integer;
				resul.Direction = ParameterDirection.Output;
				resul.Index = 0;					
				CollezioneControlli.Add(resul);

				string s_StrSql = "PACK_RM.SP_UPDATEMQ2";	
				try
				{
					return _OraDl.GetRowsAffected(CollezioneControlli, s_StrSql);
				}
				catch 
				{ 
					return 0;
				}		 
			}

			public DataSet GetAllPiani()
			{
				DataSet _Ds;
			
				S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 1;

				CollezioneControlli.Add(s_Cursor);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_BUILDINGS.SP_GETPIANI";	
				_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

				return _Ds;		
			}

			public DataSet GetAllPianiNonAssociati(int blId)
			{
				DataSet _Ds;
			
				S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

				S_Controls.Collections.S_Object s_BlId = new S_Object();
				s_BlId.ParameterName = "p_ID_BL";
				s_BlId.DbType = CustomDBType.Integer;
				s_BlId.Value=blId;
				s_BlId.Direction = ParameterDirection.Input;
				s_BlId.Index = 0;
			
				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 1;

				CollezioneControlli.Add(s_BlId);
				CollezioneControlli.Add(s_Cursor);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_BUILDINGS.SP_GETPIANIBUILDING_NASS";	
				_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

				return _Ds;		
			}

			public DataSet GetDistretto()
			{
				DataSet _Ds;
			
				S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 1;

				CollezioneControlli.Add(s_Cursor);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_BUILDINGS.SP_DISTRETTO";	
				_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

				return _Ds;		
			}

			public DataSet GetAllUsi()
			{
				DataSet _Ds;
			
				S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 1;

				CollezioneControlli.Add(s_Cursor);

				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_BUILDINGS.SP_GETALLUSI";	
				_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

				return _Ds;		
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

			protected int ExecuteServizi(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
			{

				int i_MaxParametri = CollezioneControlli.Count + 1;
				int i_Result=0;

				S_Controls.Collections.S_Object s_Idpmp = new S_Object();
				s_Idpmp.ParameterName = "p_ID";
				s_Idpmp.DbType = CustomDBType.Integer;
				s_Idpmp.Direction = ParameterDirection.Input;
				s_Idpmp.Index = i_MaxParametri;
				s_Idpmp.Value = itemId;

				i_MaxParametri ++;

//				S_Controls.Collections.S_Object s_Operazione = new S_Object();
//				s_Operazione.ParameterName = "p_Operazione";
//				s_Operazione.DbType = CustomDBType.VarChar;
//				s_Operazione.Direction = ParameterDirection.Input;
//				s_Operazione.Index = i_MaxParametri;
//				s_Operazione.Value = Operazione.ToString();
//
//				i_MaxParametri ++;

				S_Controls.Collections.S_Object s_IdOut = new S_Object();
				s_IdOut.ParameterName = "p_IdOut";
				s_IdOut.DbType = CustomDBType.Integer;
				s_IdOut.Direction = ParameterDirection.Output;
				s_IdOut.Index = i_MaxParametri;

				CollezioneControlli.Add(s_Idpmp);	
				//CollezioneControlli.Add(s_Operazione);
				CollezioneControlli.Add(s_IdOut);

				if (Operazione == ExecuteType.Insert)
					i_Result = _OraDl.GetRowsAffectedTransaction(CollezioneControlli, "PACK_BUILDINGS.SP_EXECUTE_BLSERVIZI");
				else if	(Operazione == ExecuteType.Delete)
					i_Result = _OraDl.GetRowsAffectedTransaction(CollezioneControlli, "PACK_BUILDINGS.SP_DELETE_BLSERVIZI");
				
				return i_Result;
			
			}

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
				
				i_MaxParametri ++;

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

				int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_BUILDINGS.SP_EXECUTEBUILDING");
				
				return i_Result;
			}

			#endregion

			public int AddStanze(S_ControlsCollection CollezioneControlli)
			{
				return this.ExecuteStanze(CollezioneControlli, ExecuteType.Insert, 0);
			}
			public int UpdateStanze(S_ControlsCollection CollezioneControlli, int itemID)
			{
				return this.ExecuteStanze(CollezioneControlli, ExecuteType.Update, itemID);
			}
			public int DeleteStanze(S_ControlsCollection CollezioneControlli, int itemID)
			{
				return this.ExecuteStanze(CollezioneControlli, ExecuteType.Delete, itemID);
			}

			protected int ExecuteStanze(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
			{
				int i_MaxParametri = CollezioneControlli.Count + 1;			

				// Id
				S_Controls.Collections.S_Object s_IdIn = new S_Object();
				s_IdIn.ParameterName = "p_ID";
				s_IdIn.DbType = CustomDBType.Integer;
				s_IdIn.Direction = ParameterDirection.Input;
				s_IdIn.Index = i_MaxParametri;
				s_IdIn.Value = itemId;
				
				i_MaxParametri ++;

//				// UTENTE
//				S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
//				s_CurrentUser.ParameterName = "@p_CurrentUser";
//				s_CurrentUser.DbType = CustomDBType.VarChar;
//				s_CurrentUser.Direction = ParameterDirection.Input;
//				s_CurrentUser.Index = i_MaxParametri;
//				s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

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
//				CollezioneControlli.Add(s_CurrentUser);	
				CollezioneControlli.Add(s_Operazione);
				CollezioneControlli.Add(s_IdOut);

			

				int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_BUILDINGS.SP_EXECUTEPIANISTANZE");
				
				return i_Result;
			}
			public DataSet GetStanzeBuilding(int idedificio)
			{
				DataSet _Ds;

				S_ControlsCollection _SColl = new S_ControlsCollection();

				S_Controls.Collections.S_Object s_IdEdificio = new S_Object();
				s_IdEdificio.ParameterName = "p_Bl_Id";
				s_IdEdificio.DbType = CustomDBType.Integer;
				s_IdEdificio.Direction = ParameterDirection.Input;
				s_IdEdificio.Index = 0;
				s_IdEdificio.Value = idedificio;	
		
				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 1;

				_SColl.Add(s_Cursor);

				_SColl.Add(s_IdEdificio);
				
				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_BUILDINGS.SP_STANZE_EDIFICIO";	
				_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			
				return _Ds;	
			}

			public int GetNumeroStanzeBuilding(int idedificio)
			{
				DataSet _Ds;

				S_ControlsCollection _SColl = new S_ControlsCollection();

				S_Controls.Collections.S_Object s_IdEdificio = new S_Object();
				s_IdEdificio.ParameterName = "p_Bl_Id";
				s_IdEdificio.DbType = CustomDBType.Integer;
				s_IdEdificio.Direction = ParameterDirection.Input;
				s_IdEdificio.Index = 0;
				s_IdEdificio.Value = idedificio;	
		
				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = 1;

				_SColl.Add(s_Cursor);

				_SColl.Add(s_IdEdificio);
				
				ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
				string s_StrSql = "PACK_BUILDINGS.SP_STANZE_EDIFICIO";	
				_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			
				return _Ds.Tables[0].Rows.Count;	
			}

			public int StanzaApparecchiatura(int idstanza, int idedificio)
			{
				S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
				S_Controls.Collections.S_Object p_stanza = new S_Object();
				p_stanza.ParameterName = "p_Rm_Id";
				p_stanza.DbType = CustomDBType.Integer;
				p_stanza.Direction = ParameterDirection.Input;
				p_stanza.Index = CollezioneControlli.Count;
				p_stanza.Value = idstanza;						
				CollezioneControlli.Add(p_stanza);

				S_Controls.Collections.S_Object p_company = new S_Object();
				p_company.ParameterName = "p_Bl_Id";
				p_company.DbType = CustomDBType.Integer;
				p_company.Direction = ParameterDirection.Input;
				p_company.Index = CollezioneControlli.Count+1;
				p_company.Value = idedificio;						
				CollezioneControlli.Add(p_company);

				S_Controls.Collections.S_Object s_IdOut = new S_Object();
				s_IdOut.ParameterName = "p_IdOut";
				s_IdOut.DbType = CustomDBType.Integer;
				s_IdOut.Direction = ParameterDirection.Output;
				s_IdOut.Index = CollezioneControlli.Count+1;

                CollezioneControlli.Add(s_IdOut);

				string s_StrSql = "PACK_BUILDINGS.SP_STANZE_APPARECCHIATURE";	
				int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, s_StrSql);
				return i_Result;
		 
			}

			public int PianiApparecchiatura(int idpiani, int idedificio)
			{
				S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
				S_Controls.Collections.S_Object p_piani = new S_Object();
				p_piani.ParameterName = "p_Piani_Id";
				p_piani.DbType = CustomDBType.Integer;
				p_piani.Direction = ParameterDirection.Input;
				p_piani.Index = CollezioneControlli.Count;
				p_piani.Value = idpiani;						
				CollezioneControlli.Add(p_piani);

				S_Controls.Collections.S_Object p_company = new S_Object();
				p_company.ParameterName = "p_Bl_Id";
				p_company.DbType = CustomDBType.Integer;
				p_company.Direction = ParameterDirection.Input;
				p_company.Index = CollezioneControlli.Count+1;
				p_company.Value = idedificio;						
				CollezioneControlli.Add(p_company);

				S_Controls.Collections.S_Object s_IdOut = new S_Object();
				s_IdOut.ParameterName = "p_IdOut";
				s_IdOut.DbType = CustomDBType.Integer;
				s_IdOut.Direction = ParameterDirection.Output;
				s_IdOut.Index = CollezioneControlli.Count+1;

				CollezioneControlli.Add(s_IdOut);

				string s_StrSql = "PACK_BUILDINGS.SP_PIANI_APPARECCHIATURE";	
				int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, s_StrSql);
				return i_Result;
		 
			}

			public int PianiStanze(int idpiani, int idedificio)
			{
				S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
				S_Controls.Collections.S_Object p_piani = new S_Object();
				p_piani.ParameterName = "p_Piani_Id";
				p_piani.DbType = CustomDBType.Integer;
				p_piani.Direction = ParameterDirection.Input;
				p_piani.Index = CollezioneControlli.Count;
				p_piani.Value = idpiani;						
				CollezioneControlli.Add(p_piani);

				S_Controls.Collections.S_Object p_company = new S_Object();
				p_company.ParameterName = "p_Bl_Id";
				p_company.DbType = CustomDBType.Integer;
				p_company.Direction = ParameterDirection.Input;
				p_company.Index = CollezioneControlli.Count+1;
				p_company.Value = idedificio;						
				CollezioneControlli.Add(p_company);

				S_Controls.Collections.S_Object s_IdOut = new S_Object();
				s_IdOut.ParameterName = "p_IdOut";
				s_IdOut.DbType = CustomDBType.Integer;
				s_IdOut.Direction = ParameterDirection.Output;
				s_IdOut.Index = CollezioneControlli.Count+1;

				CollezioneControlli.Add(s_IdOut);

				string s_StrSql = "PACK_BUILDINGS.SP_PIANI_STANZE";	
				int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, s_StrSql);
				return i_Result;
		 
			}
		}
	}

	