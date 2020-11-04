using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Data;
using System;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;

namespace TheSite.Classi.CostiGesioneCumulativi
{
	/// <summary>
	/// Descrizione di riepilogo per AgganciaDatalayer.
	/// </summary>
	public class AgganciaDatalayer : AbstractBase
	{
		private string _NameProcedure_Db;
		public AgganciaDatalayer()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}

		/// <summary>
		/// usa il campo bl_id, di fatto chiave primaria della tabella bl
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public DataSet GetEdificio(string itemId)
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
			string s_StrSql = "pack_CostiGestioneCumulativi.SP_GETSINGLEBL_FROM_BL_ID";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			//this.Id = itemId;
			return _Ds;		
		}

		public override System.Data.DataSet GetData()
		{
			return null;
		}
		public override System.Data.DataSet GetData(S_Controls.Collections.S_ControlsCollection CollezioneControlli)
		{
			System.Data.DataSet _DSet;
             ApplicationDataLayer.OracleDataLayer _OraDl = new ApplicationDataLayer.OracleDataLayer(s_ConnStr);	
			//	_DSet =  _OraDl.GetRows(CollezioneControlli, "PACK_ANALISI_STATISTICHE.GET_RDL_MESE_COMPLETATA").Copy();
			_DSet =  _OraDl.GetRows(CollezioneControlli,_NameProcedure_Db).Copy();
			return _DSet;
		}


		public override System.Data.DataSet GetSingleData(int itemId)
		{
			return null;
		}

		public int Delete() 
		{
			int i_Result=0;

			S_ControlsCollection clDatiUpDb = new S_ControlsCollection();

			S_Object pOp = new S_Object();
			pOp.ParameterName = "POperazione";
			pOp.DbType = CustomDBType.VarChar;
			pOp.Direction = ParameterDirection.Input;
			//pFinto.Size = 16;
			pOp.Index = 0;
			pOp.Value = "DELETE";
			clDatiUpDb.Add(pOp);

			S_Object pFinto = new S_Object();
			pFinto.ParameterName = "POut";
			pFinto.DbType = CustomDBType.Integer;
			pFinto.Direction = ParameterDirection.Output;
			//pFinto.Size = 16;
			pFinto.Index = 1;
			pFinto.Value = DBNull.Value;
			clDatiUpDb.Add(pFinto);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			i_Result = _OraDl.GetRowsAffected(clDatiUpDb, "pack_CostiGestioneCumulativi.del_Download_Reports_An_Co_Op");//  "RapportiPdf.inserisciTabellaDwn");

			return i_Result;
		}

		protected override int ExecuteUpdate(S_Controls.Collections.S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			
			S_Object  P_id = new S_Object();
			P_id.ParameterName = "P_id";
			P_id.DbType = CustomDBType.Integer;
			P_id.Direction = ParameterDirection.Input;
			P_id.Index = CollezioneControlli.Count + 1;
			P_id.Value =itemId;
			CollezioneControlli.Add(P_id);

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

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_IdOut);
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			int i_Result=0;

				i_Result = _OraDl.GetRowsAffected(CollezioneControlli, _NameProcedure_Db);//  "RapportiPdf.inserisciTabellaDwn");

			return i_Result;
		}

		public string NameProcedureDb
		{
			set
			{
				 _NameProcedure_Db = value;
			}
		}
	}
}
