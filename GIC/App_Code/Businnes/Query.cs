// Decompiled with JetBrains decompiler
// Type: GIC.App_Code.Businnes.Query
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using S_Controls.Collections;
using System.Configuration;
using System.Data;

namespace GIC.App_Code.Businnes
{
  public class Query : DataManager
  {
    protected string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];
    private OracleDataLayer _OraDl;

    public Query() => this._OraDl = new OracleDataLayer(this.s_ConnStr);

    public DataSet GetAllData() => (DataSet) null;

    public DataRow GetSingleData(int id) => (DataRow) null;

    public int InsertData(S_ControlsCollection param) => 0;

    public int UpdateData(S_ControlsCollection param) => 0;

    public int DeleteData(S_ControlsCollection param) => 0;

    public int Execute(S_ControlsCollection param, string StoredProcedure) => 0;
  }
}
