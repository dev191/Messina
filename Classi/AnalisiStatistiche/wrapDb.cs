// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.AnalisiStatistiche.wrapDb
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using S_Controls.Collections;
using System.Data;

namespace TheSite.Classi.AnalisiStatistiche
{
  public class wrapDb : AbstractBase
  {
    private string _s_storedProcedureName;

    public override int Add(S_ControlsCollection CollezioneControlli) => base.Add(CollezioneControlli);

    public override bool Equals(object obj) => base.Equals(obj);

    public override DataSet GetData() => (DataSet) null;

    public override DataSet GetData(S_ControlsCollection CollezioneControlli) => new OracleDataLayer(this.s_ConnStr).GetRows((object) CollezioneControlli, this._s_storedProcedureName).Copy();

    public override int Delete(S_ControlsCollection CollezioneControlli, int itemId) => base.Delete(CollezioneControlli, itemId);

    protected override int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId)
    {
      return 0;
    }

    public override string GetFirstAndLastUser(DataRow Data) => base.GetFirstAndLastUser(Data);

    public override int GetHashCode() => base.GetHashCode();

    public override DataSet GetSingleData(int itemId) => (DataSet) null;

    public override string ToString() => base.ToString();

    public override int Update(S_ControlsCollection CollezioneControlli, int itemId) => base.Update(CollezioneControlli, itemId);

    public string s_storedProcedureName
    {
      get => (string) null;
      set => this._s_storedProcedureName = value;
    }
  }
}
