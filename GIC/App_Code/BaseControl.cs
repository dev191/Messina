// Decompiled with JetBrains decompiler
// Type: GIC.App_Code.BaseControl
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using GIC.App_Code.Datagrid;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GIC.App_Code
{
  public class BaseControl : UserControl
  {
    protected Label LabelMessage;
    public int numeroPagina = 0;
    protected string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];
    protected DatagridControl ControlloDatagrid;
    protected DropDownList DropDownListNR;
    protected DataGrid DataGridDati;

    protected string ListaControlli
    {
      get
      {
        string str = string.Empty;
        foreach (object control in this.Controls)
        {
          if (control is S_TextBox)
          {
            S_TextBox sTextBox = (S_TextBox) control;
            str = !(str == string.Empty) ? str + ";" + ((Control) sTextBox).ClientID : str + ((Control) sTextBox).ClientID;
          }
          if (control is S_ListBox)
          {
            S_ListBox sListBox = (S_ListBox) control;
            str = !(str == string.Empty) ? str + ";" + ((Control) sListBox).ClientID : str + ((Control) sListBox).ClientID;
          }
          if (control is Button)
          {
            Button button = (Button) control;
            str = !(str == string.Empty) ? str + ";" + button.ClientID : str + button.ClientID;
          }
          if (control is HtmlInputButton)
          {
            HtmlInputButton htmlInputButton = (HtmlInputButton) control;
            str = !(str == string.Empty) ? str + ";" + htmlInputButton.ClientID : str + htmlInputButton.ClientID;
          }
        }
        return str;
      }
    }

    public object GetViewState(string key) => this.ViewState[key];

    protected void MessageDuplicate() => this.Page.RegisterStartupScript("duplicata", "<script language='javascript'>alert('" + "Attenzione! Impossibile inserire la chiave è duplicata." + "');</script>");

    protected void MessageBox(string message) => this.Page.RegisterStartupScript("existRecord", "<script language='javascript'>alert(\"" + message + "\");</script>");

    protected void CreateLink(TableCell cella, string IndexColumn, string Title)
    {
      string text = cella.Text;
      HtmlAnchor htmlAnchor = new HtmlAnchor();
      htmlAnchor.HRef = "#";
      htmlAnchor.Attributes.Add("onclick", this.Page.GetPostBackClientHyperlink((Control) this.Page, "sort:" + IndexColumn + ""));
      htmlAnchor.InnerText = text;
      htmlAnchor.Title = Title;
      cella.Controls.Add((Control) htmlAnchor);
    }

    protected void CreateLink(TableCell cella, string IndexColumn) => this.CreateLink(cella, IndexColumn, "");

    protected string SortColumn
    {
      get => Convert.ToString(this.ViewState["campoDiOrdinamento"]);
      set
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
        this.ViewState["campoDiOrdinamento"] = (object) (value + " " + str);
      }
    }

    public BaseControl GetMe() => this;

    protected void AddDefaultItem(WebControl ctrl, string text, string Value)
    {
      if (ctrl is S_ComboBox || ctrl is DropDownList)
        ((ListControl) ctrl).Items.Insert(0, new ListItem(text, Value));
      if (!(ctrl is S_ListBox) && !(ctrl is ListBox))
        return;
      ((ListControl) ctrl).Items.Insert(0, new ListItem(text, Value));
    }

    protected int recordPerPagina
    {
      get => Convert.ToInt32(this.ViewState[nameof (recordPerPagina)]);
      set => this.ViewState[nameof (recordPerPagina)] = (object) value;
    }

    protected S_ControlsCollection paramFederico
    {
      get => (S_ControlsCollection) this.Session["ParamFederico"];
      set => this.Session["ParamFederico"] = (object) value;
    }

    protected string CurrentProcedure
    {
      get => Convert.ToString(this.ViewState[nameof (CurrentProcedure)]);
      set => this.ViewState[nameof (CurrentProcedure)] = (object) value;
    }

    protected virtual void BindDataGrid()
    {
      this.DataGridDati.CurrentPageIndex = this.numeroPagina;
      this.DataGridDati.PageSize = Convert.ToInt32(this.DropDownListNR.SelectedValue);
      this.DataGridDati.DataSource = (object) this.GetData();
      this.DataGridDati.DataBind();
    }

    protected DataTable GetData()
    {
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      DataSet dataSet = new DataSet();
      try
      {
        return oracleDataLayer.GetRows((object) this.paramFederico, this.CurrentProcedure).Copy().Tables[0];
      }
      catch (Exception ex)
      {
        if (this.LabelMessage == null)
          throw ex;
        this.LabelMessage.Text = ex.Message;
        return new DataTable();
      }
    }

    protected void CambiaPaginaDataGrid(object source, DataGridPageChangedEventArgs e)
    {
      this.numeroPagina = e.NewPageIndex;
      this.BindDataGrid();
    }

    protected void OrdinaDataGrid(object source, DataGridSortCommandEventArgs e)
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
      foreach (S_Object sObject in (CollectionBase) this.paramFederico)
      {
        if (((ParameterObject) sObject).get_ParameterName() == "@SortExpression")
        {
          ((ParameterObject) sObject).set_Value(Convert.ToString(this.ViewState["campoDiOrdinamento"]) == "" ? (object) "NULL" : (object) Convert.ToString(this.ViewState["campoDiOrdinamento"]));
          break;
        }
      }
      this.BindDataGrid();
    }

    protected void DropDownListNR_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.recordPerPagina = Convert.ToInt32(this.DropDownListNR.SelectedValue);
      this.BindDataGrid();
    }
  }
}
