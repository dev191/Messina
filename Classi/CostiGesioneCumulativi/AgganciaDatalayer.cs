// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.CostiGesioneCumulativi.AgganciaDatalayer
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;

namespace TheSite.Classi.CostiGesioneCumulativi
{
  public class AgganciaDatalayer : AbstractBase
  {
    private string _NameProcedure_Db;

    public DataSet GetEdificio(string itemId)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_BL_ID");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) itemId);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "pack_CostiGestioneCumulativi.SP_GETSINGLEBL_FROM_BL_ID";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public override DataSet GetData() => (DataSet) null;

    public override DataSet GetData(S_ControlsCollection CollezioneControlli) => new OracleDataLayer(this.s_ConnStr).GetRows((object) CollezioneControlli, this._NameProcedure_Db).Copy();

    public override DataSet GetSingleData(int itemId) => (DataSet) null;

    public int Delete()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("POperazione");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) "DELETE");
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("POut");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) DBNull.Value);
      controlsCollection.Add(sObject2);
      return new OracleDataLayer(this.s_ConnStr).GetRowsAffected((object) controlsCollection, "pack_CostiGestioneCumulativi.del_Download_Reports_An_Co_Op");
    }

    protected override int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("P_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) itemId);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_operazione");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject2).set_Size(30);
      switch (Operazione)
      {
        case ExecuteType.Insert:
          ((ParameterObject) sObject2).set_Value((object) "INSERT");
          break;
        case ExecuteType.Update:
          ((ParameterObject) sObject2).set_Value((object) "UPDATE");
          break;
        case ExecuteType.Delete:
          ((ParameterObject) sObject2).set_Value((object) "DELETE");
          break;
      }
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject3);
      return new OracleDataLayer(this.s_ConnStr).GetRowsAffected((object) CollezioneControlli, this._NameProcedure_Db);
    }

    public string NameProcedureDb
    {
      set => this._NameProcedure_Db = value;
    }
  }
}
