﻿// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.ClassiAnagrafiche.Enti
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
  public class Enti : AbstractBase
  {
    private string s_Name = string.Empty;

    public override DataSet GetData()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("io_cursor");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(0);
      controlsCollection.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_ENTI.BindDescrizioni";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public override DataSet GetData(S_ControlsCollection CollezioneControlli)
    {
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_ENTI.GETENTI";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    public override DataSet GetSingleData(int itemId)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pIdEnti");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) itemId);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("io_cursor");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_ENTI.GetEntiById";
      DataSet dataSet = oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
      this.Id = itemId;
      return dataSet;
    }

    public DataSet GetProvince()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(1);
      controlsCollection.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_ENTI.BindProvincie";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetComuni(S_ControlsCollection CollezioneControlli)
    {
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("io_cursor");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(1);
      CollezioneControlli.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_ENTI.BindComuni";
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }

    protected override int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      int num1 = ((CollectionBase) CollezioneControlli).Count + 1;
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      int num2 = 0;
      S_Object sObject1 = new S_Object();
      S_Object sObject2 = new S_Object();
      S_Object sObject3 = new S_Object();
      switch (Operazione.ToString().ToUpper())
      {
        case "UPDATE":
          ((ParameterObject) sObject1).set_ParameterName("pId");
          ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject1).set_Index(num1);
          ((ParameterObject) sObject1).set_Value((object) itemId);
          CollezioneControlli.Add(sObject1);
          ((ParameterObject) sObject2).set_ParameterName("pcurrentuser");
          ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
          ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject2).set_Index(num1);
          ((ParameterObject) sObject2).set_Value((object) HttpContext.Current.User.Identity.Name);
          int num3 = num1 + 1;
          CollezioneControlli.Add(sObject2);
          ((ParameterObject) sObject3).set_ParameterName("pOut");
          ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
          ((ParameterObject) sObject3).set_Index(num3);
          CollezioneControlli.Add(sObject3);
          num2 = oracleDataLayer.GetRowsAffected((object) CollezioneControlli, "pack_enti.UpdateEnti");
          break;
        case "DELETE":
          ((ParameterObject) sObject1).set_ParameterName("pId");
          ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject1).set_Index(num1);
          ((ParameterObject) sObject1).set_Value((object) itemId);
          CollezioneControlli.Add(sObject1);
          ((ParameterObject) sObject3).set_ParameterName("pOut");
          ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
          ((ParameterObject) sObject3).set_Index(num1);
          CollezioneControlli.Add(sObject3);
          num2 = oracleDataLayer.GetRowsAffected((object) CollezioneControlli, "pack_enti.DeleteEnti");
          break;
        case "INSERT":
          ((ParameterObject) sObject2).set_ParameterName("pcurrentuser");
          ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
          ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject2).set_Index(num1);
          ((ParameterObject) sObject2).set_Value((object) HttpContext.Current.User.Identity.Name);
          int num4 = num1 + 1;
          CollezioneControlli.Add(sObject2);
          ((ParameterObject) sObject3).set_ParameterName("pOut");
          ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
          ((ParameterObject) sObject3).set_Index(num4);
          CollezioneControlli.Add(sObject3);
          num2 = oracleDataLayer.GetRowsAffected((object) CollezioneControlli, "pack_enti.InsertEnti");
          break;
      }
      return num2;
    }
  }
}
