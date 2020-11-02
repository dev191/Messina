// Decompiled with JetBrains decompiler
// Type: GIC.App_Code.Datagrid.DatagridControl
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using GIC.App_Code.Businnes;
using System;
using System.Web.UI.WebControls;

namespace GIC.App_Code.Datagrid
{
  public interface DatagridControl
  {
    DataGrid Dt { get; set; }

    int numeroPagina { get; }

    string campoDiOrdinamento { get; }

    int recordPerPagina { get; }

    void InitDataGrid();

    void SetColums();

    void EditCommand(object source, DataGridCommandEventArgs e);

    void UpdateCommand(
      object source,
      DataGridCommandEventArgs e,
      string[] ControlParamNamel,
      string COntrolForIdName,
      string StoredProcedure,
      DataManager dataManager);

    void CancelCommand(object source, DataGridCommandEventArgs e);

    void ItemCommand(
      object source,
      DataGridCommandEventArgs e,
      string[] ControlParamName,
      string ControlForIdName,
      string StoredProcedure,
      string command,
      DataManager dataManager);

    void DataBound();

    void CambiaPaginaDataGrid(object source, DataGridPageChangedEventArgs e);

    void OrdinaDataGrid(object source, DataGridSortCommandEventArgs e);

    void DropDownList1_SelectedIndexChanged(object sender, EventArgs e, string valore);
  }
}
