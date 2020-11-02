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

namespace StampaRapportiPdf.Classi
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
