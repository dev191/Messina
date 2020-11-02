// Decompiled with JetBrains decompiler
// Type: GIC.App_Code.Datagrid.StandardDTControl
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using GIC.App_Code.Businnes;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GIC.App_Code.Datagrid
{
  public class StandardDTControl : DatagridControl
  {
    private DataGrid CurrDt;
    private StateBag ViewState;

    public StateBag ViewStatePar
    {
      set => this.ViewState = value;
    }

    public StandardDTControl(DataGrid Dt) => this.Dt = Dt;

    public int numeroPagina => Convert.ToInt32(this.ViewState[nameof (numeroPagina)]);

    public string campoDiOrdinamento => Convert.ToString(this.ViewState[nameof (campoDiOrdinamento)]);

    public int recordPerPagina => Convert.ToInt32(this.ViewState[nameof (recordPerPagina)]);

    public DataGrid Dt
    {
      get => this.CurrDt;
      set => this.CurrDt = value;
    }

    public void InitDataGrid()
    {
      this.Dt.Columns[2].Visible = false;
      this.Dt.Columns[3].Visible = false;
    }

    public void SetColums()
    {
      if (this.Dt.Columns[0].Visible)
      {
        this.Dt.Columns[0].Visible = false;
        this.Dt.Columns[1].Visible = false;
        this.Dt.Columns[2].Visible = true;
        this.Dt.Columns[3].Visible = true;
      }
      else
      {
        this.Dt.Columns[0].Visible = true;
        this.Dt.Columns[1].Visible = true;
        this.Dt.Columns[2].Visible = false;
        this.Dt.Columns[3].Visible = false;
      }
    }

    public void EditCommand(object source, DataGridCommandEventArgs e)
    {
      this.Dt.EditItemIndex = e.Item.ItemIndex;
      this.SetColums();
    }

    public void UpdateCommand(
      object source,
      DataGridCommandEventArgs e,
      string[] ControlParamName,
      string ControlForIdName,
      string StoredProcedure,
      DataManager dataManager)
    {
    }

    public void CancelCommand(object source, DataGridCommandEventArgs e)
    {
      this.Dt.EditItemIndex = -1;
      this.SetColums();
    }

    public void DataBound()
    {
    }

    public void ItemCommand(
      object source,
      DataGridCommandEventArgs e,
      string[] ControlParamName,
      string ControlForIdName,
      string StoredProcedure,
      string command,
      DataManager dataManager)
    {
    }

    public void CambiaPaginaDataGrid(object source, DataGridPageChangedEventArgs e) => this.ViewState["numeroPagina"] = (object) e.NewPageIndex;

    public void OrdinaDataGrid(object source, DataGridSortCommandEventArgs e)
    {
      string str = "";
      if (Convert.ToString(this.ViewState["verso"]) == "" || Convert.ToString(this.ViewState["verso"]) == "DESC")
      {
        str = "ASC";
        this.ViewState["verso"] = (object) str;
      }
      else if (Convert.ToString(this.ViewState["verso"]) == "ASC")
      {
        str = "DESC";
        this.ViewState["verso"] = (object) str;
      }
      this.ViewState["campoDiOrdinamento"] = (object) (e.SortExpression + " " + str);
    }

    public void DropDownList1_SelectedIndexChanged(object sender, EventArgs e, string valore) => this.ViewState["recordPerPagina"] = (object) Convert.ToInt32(valore);
  }
}
