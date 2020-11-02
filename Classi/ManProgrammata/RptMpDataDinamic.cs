// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.ManProgrammata.RptMpDataDinamic
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using TheSite.SchemiXSD;

namespace TheSite.Classi.ManProgrammata
{
  public class RptMpDataDinamic
  {
    public DsRptMpLocali GetDataRpt(string SOdl)
    {
      DsRptMpLocali dsRptMpLocali = new DsRptMpLocali();
      string str1 = " SELECT t.wo_id ,t.desc_bl_estesa ,t.nomecognome ,t.data_scadenza ,t.servizio ,t.ditta,t.cod_procedura, t.cod_freq  ,t.desc_procedura ,t.id_pmp  FROM  VIEW_rapportino_rpt_main t WHERE  t.wo_id in(" + SOdl + ")  GROUP BY   t.wo_id ,t.desc_bl_estesa ,t.nomecognome ,t.data_scadenza  ,t.servizio ,t.ditta ,t.cod_procedura ,t.cod_freq ,t.desc_procedura ,t.id_pmp  ORDER BY  t.wo_id,t.id_pmp ";
      string str2 = " SELECT t.wo_id ,t.id_pmp  ,t.passo ,t.istruzione  FROM VIEW_rapportino_rpt_sub_passi t  WHERE  t.wo_id in(" + SOdl + ")  GROUP BY  t.wo_id ,t.id_pmp, t.passo , t.istruzione  ORDER BY t.wo_id, t.id_pmp,t.passo ";
      string str3 = " SELECT t.wo_id ,t.id_pmp ,t.desc_eqstd  ,t.wr_id ,t.fl_id ,t.eq_id,t.rm_id,t.status  FROM  VIEW_rapportino_rpt_sub_rdl t WHERE t.wo_id in(" + SOdl + ")  GROUP BY  t.wo_id ,t.id_pmp ,t.desc_eqstd ,t.wr_id  ,t.fl_id ,t.eq_id ,t.rm_id ,t.status  ORDER BY t.wo_id , t.id_pmp,t.wr_id ";
      OracleCommand selectCommand = new OracleCommand("PACK_RTP_PROG.GetDatiInitDin", new OracleConnection(ConfigurationSettings.AppSettings["ConnectionString"]));
      selectCommand.CommandType = CommandType.StoredProcedure;
      OracleParameter oracleParameter = new OracleParameter("PDinSql", OracleType.VarChar);
      oracleParameter.Direction = ParameterDirection.Input;
      oracleParameter.Size = 2048;
      oracleParameter.Value = (object) str1;
      selectCommand.Parameters.Add(oracleParameter);
      selectCommand.Parameters.Add(new OracleParameter("pCursor", OracleType.Cursor)
      {
        Direction = ParameterDirection.Output
      });
      OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(selectCommand);
      oracleDataAdapter.Fill((DataSet) dsRptMpLocali, "tblMain");
      oracleParameter.Value = (object) str2;
      oracleDataAdapter.Fill((DataSet) dsRptMpLocali, "tblPassi");
      oracleParameter.Value = (object) str3;
      oracleDataAdapter.Fill((DataSet) dsRptMpLocali, "TblDetRdl");
      selectCommand.Parameters.Remove((object) oracleParameter);
      selectCommand.CommandText = "PACK_RTP_PROG.GetLeggendaPassi";
      oracleDataAdapter.Fill((DataSet) dsRptMpLocali, "TblLeggendaPassi");
      selectCommand.CommandText = "PACK_RTP_PROG.GetLeggendaStatus";
      oracleDataAdapter.Fill((DataSet) dsRptMpLocali, "tblLeggendaStatus");
      return dsRptMpLocali;
    }
  }
}
