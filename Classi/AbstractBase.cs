// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.AbstractBase
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls.Collections;
using System;
using System.Configuration;
using System.Data;
using System.Text;

namespace TheSite.Classi
{
  public abstract class AbstractBase
  {
    protected int i_Id = 0;
    protected string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];

    public abstract DataSet GetData();

    public abstract DataSet GetData(S_ControlsCollection CollezioneControlli);

    public abstract DataSet GetSingleData(int itemId);

    public virtual int Add(S_ControlsCollection CollezioneControlli) => this.ExecuteUpdate(CollezioneControlli, ExecuteType.Insert, 0);

    public virtual int Update(S_ControlsCollection CollezioneControlli, int itemId) => this.ExecuteUpdate(CollezioneControlli, ExecuteType.Update, itemId);

    public virtual int Delete(S_ControlsCollection CollezioneControlli, int itemId) => this.ExecuteUpdate(CollezioneControlli, ExecuteType.Delete, itemId);

    public virtual string GetFirstAndLastUser(DataRow Data)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        stringBuilder.Append("Creato da ");
        if (Data["FIRST"] != DBNull.Value)
          stringBuilder.Append(Data["FIRST"].ToString());
        stringBuilder.Append(" il ");
        if (Data["FIRSTMODIFIED"] != DBNull.Value)
          stringBuilder.Append(Data["FIRSTMODIFIED"].ToString());
        stringBuilder.Append(" ");
        stringBuilder.Append("Modificato da ");
        if (Data["LAST"] != DBNull.Value)
          stringBuilder.Append(Data["LAST"].ToString());
        stringBuilder.Append(" il ");
        if (Data["LASTMODIFIED"] != DBNull.Value)
          stringBuilder.Append(Data["LASTMODIFIED"].ToString());
      }
      catch
      {
        stringBuilder.Append("");
      }
      return stringBuilder.ToString();
    }

    protected abstract int ExecuteUpdate(
      S_ControlsCollection CollezioneControlli,
      ExecuteType Operazione,
      int itemId);

    public int Id
    {
      get => this.i_Id;
      set => this.i_Id = value;
    }
  }
}
