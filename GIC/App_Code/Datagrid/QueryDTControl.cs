// Decompiled with JetBrains decompiler
// Type: GIC.App_Code.Datagrid.QueryDTControl
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using GIC.App_Code.Businnes;
using S_Controls.Collections;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GIC.App_Code.Datagrid
{
  public class QueryDTControl : DatagridControl
  {
    private DataGrid CurrDt;
    private StateBag ViewState;
    protected string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];

    public StateBag ViewStatePar
    {
      set => this.ViewState = value;
    }

    public QueryDTControl(DataGrid Dt) => this.Dt = Dt;

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
    }

    public void SetColums()
    {
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
      this.Dt.EditItemIndex = -1;
      this.SetColums();
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
      switch (e.CommandName)
      {
        case "Delete":
          int num = int.Parse(this.Dt.DataKeys[e.Item.ItemIndex].ToString());
          OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
          S_ControlsCollection controlsCollection = new S_ControlsCollection();
          S_Object sObject1 = new S_Object();
          ((ParameterObject) sObject1).set_ParameterName("pIdSchema");
          ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject1).set_Value((object) num);
          ((ParameterObject) sObject1).set_Index(0);
          controlsCollection.Add(sObject1);
          S_Object sObject2 = new S_Object();
          ((ParameterObject) sObject2).set_ParameterName("pId");
          ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
          ((ParameterObject) sObject2).set_Value((object) DBNull.Value);
          ((ParameterObject) sObject2).set_Index(1);
          controlsCollection.Add(sObject2);
          oracleDataLayer.ExecuteProcedure((object) controlsCollection, "IL_PACK_INTERROGAZIONI.IL_SpDeleteSchema");
          break;
      }
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
