// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.CostiGesioneCumulativi.GestoreDropDownList
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System.Data;
using System.Web.UI.WebControls;

namespace TheSite.Classi.CostiGesioneCumulativi
{
  public class GestoreDropDownList
  {
    public static ListItem ItemMessaggio(string Text, string Value) => new ListItem(Text, Value);

    public static DataTable ItemBlankDataSource(
      DataTable DataTableOrigine,
      string DataTextField,
      string DataValueFiled,
      string BlankText,
      string BlankValue)
    {
      DataTable dataTable = DataTableOrigine.Clone();
      dataTable.Columns[DataValueFiled].AllowDBNull = true;
      DataRow row1 = dataTable.NewRow();
      if (BlankValue != string.Empty)
        row1[DataValueFiled] = (object) BlankValue;
      row1[DataTextField] = (object) BlankText;
      dataTable.Rows.Add(row1);
      foreach (DataRow row2 in (InternalDataCollectionBase) DataTableOrigine.Rows)
      {
        DataRow row3 = dataTable.NewRow();
        row3[DataValueFiled] = row2[DataValueFiled];
        row3[DataTextField] = row2[DataTextField];
        dataTable.Rows.Add(row3);
      }
      return dataTable;
    }

    public static DataTable ItemBlankDataSource(
      DataView DataViewOrigine,
      string DataTextField,
      string DataValueFiled,
      string BlankText,
      string BlankValue)
    {
      DataTable dataTable = DataViewOrigine.Table.Clone();
      dataTable.Columns[DataValueFiled].AllowDBNull = true;
      DataRow row1 = dataTable.NewRow();
      if (BlankValue != string.Empty)
        row1[DataValueFiled] = (object) BlankValue;
      row1[DataTextField] = (object) BlankText;
      dataTable.Rows.Add(row1);
      for (int recordIndex = 0; recordIndex <= DataViewOrigine.Count - 1; ++recordIndex)
      {
        DataRow row2 = dataTable.NewRow();
        row2[DataValueFiled] = DataViewOrigine[recordIndex][DataValueFiled];
        row2[DataTextField] = DataViewOrigine[recordIndex][DataTextField];
        dataTable.Rows.Add(row2);
      }
      return dataTable;
    }
  }
}
