// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.ManProgrammata.CreaPiano
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System.Collections;
using System.Data;

namespace TheSite.Classi.ManProgrammata
{
  public class CreaPiano : AbstractBase
  {
    private string s_Descrizione = string.Empty;
    private OracleDataLayer _OraDl;
    public string UserName;

    public CreaPiano() => this._OraDl = new OracleDataLayer(this.s_ConnStr);

    public void beginTransaction() => this._OraDl.BeginTransaction();

    public void commitTransaction() => this._OraDl.CommitTransaction();

    public void rollbackTransaction() => this._OraDl.RollbackTransaction();

    public override DataSet GetData() => (DataSet) null;

    public override DataSet GetSingleData(int itemId) => (DataSet) null;

    public override DataSet GetData(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MAN_PROG.getCreaPiano";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public DataSet GetDataPaging(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MAN_PROG.getCreaPianoPaging";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public int GetDataCount(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MAN_PROG.getCreaPianoCount";
      return int.Parse(oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy().Tables[0].Rows[0][0].ToString());
    }

    public int CreaPianoMP(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_esito");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count);
      CollezioneControlli.Add(sObject);
      return this._OraDl.GetRowsAffectedTransaction((object) CollezioneControlli, "PACK_SCHEDULA.SP_MP_PmsInPmsd_Ater");
    }

    protected override int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      return 0;
    }
  }
}
