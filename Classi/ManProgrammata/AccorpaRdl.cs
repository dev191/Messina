// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.ManProgrammata.AccorpaRdl
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
  public class AccorpaRdl : AbstractBase
  {
    private string username = string.Empty;
    private OracleDataLayer _OraDl;

    public AccorpaRdl(string UserName)
    {
      this.username = UserName;
      this._OraDl = new OracleDataLayer(this.s_ConnStr);
    }

    public override DataSet GetData() => (DataSet) null;

    public override DataSet GetData(S_ControlsCollection CollezioneControlli) => (DataSet) null;

    public override DataSet GetSingleData(int itemId) => (DataSet) null;

    public void beginTransaction() => this._OraDl.BeginTransaction();

    public void commitTransaction() => this._OraDl.CommitTransaction();

    public void rollbackTransaction() => this._OraDl.RollbackTransaction();

    public DataSet Accorpante(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_utente");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) this.username);
      ((ParameterObject) sObject1).set_Size(50);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject2);
      string str = "PACK_MAN_ORD.SP_GetAccorpante";
      return this._OraDl.GetRows((object) CollezioneControlli, str).Copy();
    }

    public DataSet Accorpate(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_utente");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) this.username);
      ((ParameterObject) sObject1).set_Size(50);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject2);
      string str = "PACK_MAN_ORD.SP_Get_Da_Accorpare";
      return this._OraDl.GetRows((object) CollezioneControlli, str).Copy();
    }

    public DataSet VisualizzaAccorpate(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_utente");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) this.username);
      ((ParameterObject) sObject1).set_Size(50);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject2);
      string str = "PACK_MAN_ORD.SP_GetAccorpate";
      return this._OraDl.GetRows((object) CollezioneControlli, str).Copy();
    }

    protected override int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count);
      CollezioneControlli.Add(sObject);
      return this._OraDl.GetRowsAffectedTransaction((object) CollezioneControlli, "PACK_MAN_ORD.SP_Accorpa");
    }
  }
}
