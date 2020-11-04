using TheSite.SchemiXSD;
using System.Data;
using System.Data.OracleClient;

namespace TheSite.Classi.ManProgrammata
{
	/// <summary>
	/// Summary description for RptMpDataDinamic.
	/// </summary>
	public class RptMpDataDinamic
	{
		public RptMpDataDinamic()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public  DsRptMpLocali GetDataRpt(string SOdl)
		{
			DsRptMpLocali ds =  new DsRptMpLocali();
			string SqlRptMain = " SELECT t.wo_id ,t.desc_bl_estesa " 
				+ ",t.nomecognome ,t.data_scadenza ,t.servizio ,t.ditta"
				+ ",t.cod_procedura, t.cod_freq  ,t.desc_procedura ,t.id_pmp "
				+ " FROM "
				+ " VIEW_rapportino_rpt_main t WHERE  t.wo_id in(" + SOdl + ") "   
				+ " GROUP BY "
				+ "  t.wo_id ,t.desc_bl_estesa ,t.nomecognome ,t.data_scadenza "
				+ " ,t.servizio ,t.ditta ,t.cod_procedura ,t.cod_freq ,t.desc_procedura ,t.id_pmp "
                + " ORDER BY  t.wo_id,t.id_pmp ";
	

		string 	SqlRptPassi = " SELECT t.wo_id ,t.id_pmp  ,t.passo ,t.istruzione "
				+ " FROM VIEW_rapportino_rpt_sub_passi t " 
				+ " WHERE  t.wo_id in(" + SOdl + ") " 
				+ " GROUP BY "
				+ " t.wo_id ,t.id_pmp, t.passo , t.istruzione "
				+ " ORDER BY t.wo_id, t.id_pmp,t.passo ";  

		string SqlRptDettaglioRdl = " SELECT t.wo_id ,t.id_pmp ,t.desc_eqstd " 
			+ " ,t.wr_id ,t.fl_id ,t.eq_id,t.rm_id,t.status " 
			+ " FROM " 
			+ " VIEW_rapportino_rpt_sub_rdl t WHERE t.wo_id in(" + SOdl + ") " 
			+ " GROUP BY "
			+ " t.wo_id ,t.id_pmp ,t.desc_eqstd ,t.wr_id " 
			+ " ,t.fl_id ,t.eq_id ,t.rm_id ,t.status "
			+ " ORDER BY t.wo_id , t.id_pmp,t.wr_id ";

			OracleConnection cn = new OracleConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);		
			OracleCommand cmd = new OracleCommand("PACK_RTP_PROG.GetDatiInitDin",cn);
			cmd.CommandType = CommandType.StoredProcedure;
			OracleParameter PDinSql = new OracleParameter("PDinSql",OracleType.VarChar);
			PDinSql.Direction = ParameterDirection.Input;
			PDinSql.Size = 2048;
			PDinSql.Value =  SqlRptMain;
			cmd.Parameters.Add(PDinSql);

			OracleParameter pCursor = new OracleParameter("pCursor",OracleType.Cursor);
			pCursor.Direction = ParameterDirection.Output;
			cmd.Parameters.Add(pCursor);
			OracleDataAdapter da = new OracleDataAdapter(cmd);
			da.Fill(ds,"tblMain");

		//	cmd.Parameters.Remove(PDinSql);
		//	cmd.Parameters.Remove(pCursor);
			//cmd.CommandText = "PACK_RTP_PROG.GetDatiInitDin";
			PDinSql.Value = SqlRptPassi;
		//	cmd.Parameters.Add(PDinSql);
		//  cmd.Parameters.Add(pCursor);
			da.Fill(ds,"tblPassi");

		//	cmd.Parameters.Remove(PDinSql);
		//	cmd.Parameters.Remove(pCursor);
			PDinSql.Value = SqlRptDettaglioRdl;
		//	cmd.Parameters.Add(PDinSql);
		//	cmd.Parameters.Add(pCursor);
			da.Fill(ds,"TblDetRdl");

			cmd.Parameters.Remove(PDinSql);
			//cmd.Parameters.Remove(pCursor);
			cmd.CommandText = "PACK_RTP_PROG.GetLeggendaPassi";
			//cmd.Parameters.Add(pCursor);
			da.Fill(ds,"TblLeggendaPassi");

			//cmd.Parameters.Remove(pCursor);
			cmd.CommandText = "PACK_RTP_PROG.GetLeggendaStatus";
			//cmd.Parameters.Add(pCursor);
			da.Fill(ds,"tblLeggendaStatus");

			return ds;
		}
	}
}
