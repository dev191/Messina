// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.ClassiAnagrafiche.Contab
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

namespace TheSite.Classi.ClassiAnagrafiche
{
  public class Contab : AbstractBase
  {
    private string s_Name = string.Empty;

    public Contab()
    {
    }

    public Contab(int Id)
      : this(Id, string.Empty)
    {
    }

    public Contab(int Id, string Name)
    {
      this.Id = Id;
      this.Name = Name;
    }

    public override DataSet GetData()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) controlsCollection).Count + 1);
      controlsCollection.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MS.SP_GETALLCONTAB";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public override DataSet GetData(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_MS.SP_GETCONTAB";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public override DataSet GetSingleData(int itemId)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_TipoIntervento_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
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
      string str = "PACK_MS.SP_GETSINGLECONTAB";
      DataSet dataSet = oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
      this.Id = itemId;
      return dataSet;
    }

    public string Name
    {
      get => this.s_Name;
      set => this.s_Name = value;
    }

    protected override int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) itemId);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_CurrentUser");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(3);
      ((ParameterObject) sObject2).set_Value((object) HttpContext.Current.User.Identity.Name);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_Operazione");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(4);
      ((ParameterObject) sObject3).set_Value((object) Operazione.ToString());
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject4).set_Index(5);
      CollezioneControlli.Add(sObject1);
      CollezioneControlli.Add(sObject2);
      CollezioneControlli.Add(sObject3);
      CollezioneControlli.Add(sObject4);
      return new OracleDataLayer(this.s_ConnStr).GetRowsAffected((object) CollezioneControlli, "PACK_MS.SP_EXECUTECONTAB");
    }
  }
}
