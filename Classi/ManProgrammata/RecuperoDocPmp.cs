// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.ManProgrammata.RecuperoDocPmp
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;

namespace TheSite.Classi.ManProgrammata
{
  public class RecuperoDocPmp
  {
    protected string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];

    public DataSet GetAllStato()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) controlsCollection).Count);
      controlsCollection.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_PIANI_APPROVATI.SP_GETALLSTATOPIANI";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
    }

    public DataSet GetPiani(S_ControlsCollection CollezioneControlli, string TipoDoc)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_username");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) HttpContext.Current.User.Identity.Name);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      CollezioneControlli.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "";
      switch (TipoDoc)
      {
        case "0":
          str = "PACK_PIANI_APPROVATI.SP_GETALLPIANI";
          break;
        case "1":
          str = "PACK_PIANI_APPROVATI.SP_GETPIANIANNI";
          break;
        case "2":
          str = "PACK_PIANI_APPROVATI.SP_GETPIANIMESI";
          break;
      }
      return oracleDataLayer.GetRows((object) CollezioneControlli, str).Copy();
    }
  }
}
