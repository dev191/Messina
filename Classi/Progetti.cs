// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.Progetti
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System.Configuration;
using System.Data;

namespace TheSite.Classi
{
  public class Progetti
  {
    private string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];
    private DataSet _Ds;

    public DataSet GetData()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(0);
      controlsCollection.Add(sObject);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      string str = "PACK_PROGETTI.SP_GETALLPROGETTI";
      this._Ds = oracleDataLayer.GetRows((object) controlsCollection, str).Copy();
      return this._Ds;
    }
  }
}
