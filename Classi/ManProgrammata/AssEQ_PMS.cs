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

namespace TheSite.Classi.ManProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per AssEQ_PMS.
	/// </summary>
	public class AssEQ_PMS:AbstractBase
	{
		public AssEQ_PMS()
		{			
		}
		
		/// <summary>
		/// DataSet con tutti i record
		/// </summary>
		/// <returns></returns>
		public override DataSet GetData()
		{
			return null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			return null;
		}

		public override DataSet GetSingleData(int itemId)
		{
			return null;
		}

		public string[] GetValueParametri()
		{
						
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();			
			
			S_Controls.Collections.S_Object s_totEQ = new S_Object();
			s_totEQ.ParameterName = "p_totEQ";
			s_totEQ.DbType = CustomDBType.Integer;
			s_totEQ.Direction = ParameterDirection.Output;
			s_totEQ.Index = 0;				
			s_totEQ.Size = 50;
			
			S_Controls.Collections.S_Object s_totEQSTDinEQ = new S_Object();
			s_totEQSTDinEQ.ParameterName = "p_totEQSTDinEQ";
			s_totEQSTDinEQ.DbType = CustomDBType.Integer;
			s_totEQSTDinEQ.Direction = ParameterDirection.Output;
			s_totEQSTDinEQ.Index = 1;				
			s_totEQSTDinEQ.Size = 50;

			S_Controls.Collections.S_Object s_totEQinPMS = new S_Object();
			s_totEQinPMS.ParameterName = "p_totEQinPMS";
			s_totEQinPMS.DbType = CustomDBType.Integer;
			s_totEQinPMS.Direction = ParameterDirection.Output;
			s_totEQinPMS.Index = 2;				
			s_totEQinPMS.Size = 50;			

			S_Controls.Collections.S_Object s_totEQnoPMS = new S_Object();
			s_totEQnoPMS.ParameterName = "p_totEQnoPMS";
			s_totEQnoPMS.DbType = CustomDBType.Integer;
			s_totEQnoPMS.Direction = ParameterDirection.Output;
			s_totEQnoPMS.Index = 3;				
			s_totEQnoPMS.Size = 50;

			S_Controls.Collections.S_Object s_totEQSTDinPMP = new S_Object();
			s_totEQSTDinPMP.ParameterName = "p_totEQSTDinPMP";
			s_totEQSTDinPMP.DbType = CustomDBType.Integer;
			s_totEQSTDinPMP.Direction = ParameterDirection.Output;
			s_totEQSTDinPMP.Index = 4;				
			s_totEQSTDinPMP.Size = 50;

			S_Controls.Collections.S_Object s_totEQSTDEQinPMP = new S_Object();
			s_totEQSTDEQinPMP.ParameterName = "p_totEQSTDEQinPMP";
			s_totEQSTDEQinPMP.DbType = CustomDBType.Integer;
			s_totEQSTDEQinPMP.Direction = ParameterDirection.Output;
			s_totEQSTDEQinPMP.Index = 5;				
			s_totEQSTDEQinPMP.Size = 50;

			S_Controls.Collections.S_Object s_totEQSTD = new S_Object();
			s_totEQSTD.ParameterName = "p_totEQSTD";
			s_totEQSTD.DbType = CustomDBType.Integer;
			s_totEQSTD.Direction = ParameterDirection.Output;
			s_totEQSTD.Index = 6;				
			s_totEQSTD.Size = 50;

			CollezioneControlli.Add(s_totEQ);
			CollezioneControlli.Add(s_totEQSTDinEQ);
			CollezioneControlli.Add(s_totEQinPMS);
			CollezioneControlli.Add(s_totEQnoPMS);
			CollezioneControlli.Add(s_totEQSTDinPMP);
			CollezioneControlli.Add(s_totEQSTDEQinPMP);
			CollezioneControlli.Add(s_totEQSTD);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SCHEDULA.getConta_EQ_PMP";	
			System.Data.OracleClient.OracleParameterCollection Parametri = _OraDl.ParametersArray(CollezioneControlli, s_StrSql);			
 			
			string[] ParValues = new string[Parametri.Count];
			for(int Par = 0;Par<Parametri.Count;Par++)
			{
				//ParValues.SetValue(Parametri[Par].Value,Par);
				ParValues[Par] = Parametri[Par].Value.ToString();
			}
			return ParValues;		
		}

		public int Associa()
		{
					
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();			
			
			S_Controls.Collections.S_Object s_numPMS = new S_Object();
			s_numPMS.ParameterName = "p_numPMS";
			s_numPMS.DbType = CustomDBType.Integer;
			s_numPMS.Direction = ParameterDirection.Output;
			s_numPMS.Index = 0;				
			s_numPMS.Size = 50;
					
			CollezioneControlli.Add(s_numPMS);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_SCHEDULA.getAssociazione_EQ_PMS";	
			int Associate = _OraDl.GetRowsAffected(CollezioneControlli, s_StrSql);			
 						
			return Associate;		
		}
	

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			return 0;
		}


	}
}
