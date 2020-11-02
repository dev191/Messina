// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.ManProgrammata.Impostazioni
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System.Collections;
using System.Data;
using System.Web;

namespace TheSite.Classi.ManProgrammata
{
  public class Impostazioni : AbstractBase
  {
    private string s_Descrizione = string.Empty;
    private OracleDataLayer _OraDl;
    public string UserName;

    public Impostazioni() => this._OraDl = new OracleDataLayer(this.s_ConnStr);

    public void beginTransaction() => this._OraDl.BeginTransaction();

    public void commitTransaction() => this._OraDl.CommitTransaction();

    public void rollbackTransaction() => this._OraDl.RollbackTransaction();

    public override DataSet GetData() => (DataSet) null;

    public override DataSet GetSingleData(int itemId) => (DataSet) null;

    public override DataSet GetData(S_ControlsCollection CollezioneControlli) => (DataSet) null;

    public DataSet GetImpostazioniDefault(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_UserName");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(4);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) HttpContext.Current.User.Identity.Name);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(5);
      CollezioneControlli.Add(sObject2);
      string str = "PACK_MAN_PROG.getImpostazioniDeafult";
      return this._OraDl.GetRows((object) CollezioneControlli, str).Copy();
    }

    public DataSet GetImpostazioniDefaultPaging(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_UserName");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(4);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) HttpContext.Current.User.Identity.Name);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(5);
      CollezioneControlli.Add(sObject2);
      string str = "PACK_MAN_PROG.getImpostazioniDeafultPaging";
      return this._OraDl.GetRows((object) CollezioneControlli, str).Copy();
    }

    public int GetImpostazioniDefaultCount(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_UserName");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(4);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) HttpContext.Current.User.Identity.Name);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(5);
      CollezioneControlli.Add(sObject2);
      string str = "PACK_MAN_PROG.getImpostazioniDeafultCount";
      return int.Parse(this._OraDl.GetRows((object) CollezioneControlli, str).Copy().Tables[0].Rows[0][0].ToString());
    }

    protected override int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      int count = ((CollectionBase) CollezioneControlli).Count;
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Operazione");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(count);
      ((ParameterObject) sObject1).set_Value((object) Operazione.ToString());
      CollezioneControlli.Add(sObject1);
      int num = count + 1;
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(num);
      CollezioneControlli.Add(sObject2);
      return this._OraDl.GetRowsAffectedTransaction((object) CollezioneControlli, "PACK_MAN_PROG.SP_EXECUTEIMPOSTAZIONI");
    }
  }
}
