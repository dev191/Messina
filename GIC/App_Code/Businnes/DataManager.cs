// Decompiled with JetBrains decompiler
// Type: GIC.App_Code.Businnes.DataManager
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls.Collections;
using System.Data;

namespace GIC.App_Code.Businnes
{
  public interface DataManager
  {
    DataSet GetAllData();

    DataRow GetSingleData(int id);

    int InsertData(S_ControlsCollection param);

    int UpdateData(S_ControlsCollection param);

    int DeleteData(S_ControlsCollection param);

    int Execute(S_ControlsCollection param, string StoredProcedure);
  }
}
