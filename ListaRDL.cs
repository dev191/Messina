// Decompiled with JetBrains decompiler
// Type: TheSite.ListaRDL
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi.ManOrdinaria;
using TheSite.WebControls;

namespace TheSite
{
  public class ListaRDL : Page
  {
    protected HyperLink HyperLink1;
    protected HyperLink HyperLinkChiudi2;
    protected DataGrid MyDataGrid1;
    protected GridTitle GridTitle1;
    public int j = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      string script1 = "<script language='JavaScript'>\n" + "var a = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var b = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var c = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var d = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var e = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var f = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var g = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var h = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var i = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var l = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "<" + "/" + "script>";
      if (!this.Page.IsClientScriptBlockRegistered("array1"))
        this.Page.RegisterClientScriptBlock("array1", script1);
      if (!this.Page.IsPostBack)
      {
        this.idcod = this.Request.QueryString["idcod"] == null ? string.Empty : this.Request.QueryString["idcod"];
        this.pulsante = this.Request.QueryString["pulsante"] == null ? string.Empty : this.Request.QueryString["pulsante"];
        this.idric = this.Request.QueryString["idric"] == null ? string.Empty : this.Request.QueryString["idric"];
        this.idricA = this.Request.QueryString["idricA"] == null ? string.Empty : this.Request.QueryString["idricA"];
        this.idmodulo = this.Request.QueryString["idmodulo"] == null ? string.Empty : this.Request.QueryString["idmodulo"];
        this.multiselect = this.Request.QueryString["ms"] == null ? string.Empty : this.Request.QueryString["ms"];
        this.opera = this.Request.QueryString["oper"] == null ? string.Empty : this.Request.QueryString["oper"];
        this.Execute(true);
      }
      string script2 = "<script language=JavaScript> var idmodulo='" + this.idmodulo + "'" + "<" + "/" + "script>";
      if (this.IsClientScriptBlockRegistered("clientScript"))
        return;
      this.RegisterClientScriptBlock("clientScript", script2);
    }

    private string idmodulo
    {
      get => (string) this.ViewState["s_idmodulo"];
      set => this.ViewState["s_idmodulo"] = (object) value;
    }

    private string pulsante
    {
      get => (string) this.ViewState[nameof (pulsante)];
      set => this.ViewState[nameof (pulsante)] = (object) value;
    }

    private string idcod
    {
      get => (string) this.ViewState["s_Idcod"];
      set => this.ViewState["s_Idcod"] = (object) value;
    }

    private string idric
    {
      get => (string) this.ViewState["s_Idric"];
      set => this.ViewState["s_Idric"] = (object) value;
    }

    private string idricA
    {
      get => (string) this.ViewState["s_IdricA"];
      set => this.ViewState["s_IdricA"] = (object) value;
    }

    private string opera
    {
      get => (string) this.ViewState["s_opera"];
      set => this.ViewState["s_opera"] = (object) value;
    }

    private string multiselect
    {
      get => (string) this.ViewState["s_multiselect"];
      set => this.ViewState["s_multiselect"] = (object) value;
    }

    private string id_comune
    {
      get => (string) this.ViewState["s_id_comune"];
      set => this.ViewState["s_id_comune"] = (object) value;
    }

    private string id_frazione
    {
      get => (string) this.ViewState["s_id_frazione"];
      set => this.ViewState["s_id_frazione"] = (object) value;
    }

    private string TipoMan
    {
      get => (string) this.ViewState[nameof (TipoMan)];
      set => this.ViewState[nameof (TipoMan)] = (object) value;
    }

    private void Execute(bool reset)
    {
      GestioneRdl gestioneRdl = new GestioneRdl(HttpContext.Current.User.Identity.Name);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet dataSet;
      if (this.pulsante == "idric")
      {
        S_ControlsCollection data1_1 = this.GetData1();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("pageindex");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Index(16);
        ((ParameterObject) sObject1).set_Value((object) (this.MyDataGrid1.CurrentPageIndex + 1));
        data1_1.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("pagesize");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(17);
        ((ParameterObject) sObject2).set_Value((object) this.MyDataGrid1.PageSize);
        data1_1.Add(sObject2);
        dataSet = gestioneRdl.GetRDL2(data1_1);
        if (reset)
        {
          ((CollectionBase) data1_1).Clear();
          S_ControlsCollection data1_2 = this.GetData1();
          this.GridTitle1.NumeroRecords = gestioneRdl.GetRDL2Count(data1_2).ToString();
        }
      }
      else
      {
        S_ControlsCollection data1 = this.GetData();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("pageindex");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Index(16);
        ((ParameterObject) sObject1).set_Value((object) (this.MyDataGrid1.CurrentPageIndex + 1));
        data1.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("pagesize");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(17);
        ((ParameterObject) sObject2).set_Value((object) this.MyDataGrid1.PageSize);
        data1.Add(sObject2);
        dataSet = gestioneRdl.GetRDL1(data1);
        if (reset)
        {
          ((CollectionBase) data1).Clear();
          S_ControlsCollection data2 = this.GetData();
          this.GridTitle1.NumeroRecords = gestioneRdl.GetRDL1Count(data2).ToString();
        }
      }
      this.MyDataGrid1.DataSource = (object) dataSet;
      this.MyDataGrid1.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.MyDataGrid1.DataBind();
      this.GridTitle1.DescriptionTitle = "Lista delle RDL";
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.MyDataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged_1);
      this.MyDataGrid1.ItemDataBound += new DataGridItemEventHandler(this.MyDataGrid1_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private S_ControlsCollection GetData()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_wr_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Size(8);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) this.idcod);
      controlsCollection.Add(sObject);
      return controlsCollection;
    }

    private S_ControlsCollection GetData1()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_wr_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(8);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) this.idcod);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_datain");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) this.idric);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_dataout");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) this.idricA);
      controlsCollection.Add(sObject3);
      return controlsCollection;
    }

    private void MyDataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      string script = "<script language='JavaScript'>\n" + "a[" + this.j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[1].Text).Replace("\"", "\\\"") + "\";\n" + "<" + "/" + "script>";
      this.RegisterStartupScript("scriptarray" + this.j.ToString(), script);
      if (this.multiselect == "y")
      {
        if (this.opera != "Cerca")
        {
          if (e.Item.Cells[2].Text == "0")
          {
            e.Item.FindControl("hrefset").Visible = true;
            e.Item.FindControl("hrefset1").Visible = false;
            e.Item.Cells[0].ToolTip = "";
            ((HtmlAnchor) e.Item.FindControl("hrefset")).HRef = "javascript:Popola1(" + (object) this.j + ");";
          }
          else
          {
            e.Item.FindControl("hrefset1").Visible = true;
            e.Item.Cells[0].ToolTip = "RdL già fatturata";
            e.Item.FindControl("hrefset").Visible = false;
          }
        }
        else
        {
          e.Item.FindControl("hrefset1").Visible = false;
          ((HtmlAnchor) e.Item.FindControl("hrefset")).HRef = "javascript:Popola1(" + (object) this.j + ");";
        }
      }
      else
        ((HtmlAnchor) e.Item.FindControl("hrefset")).HRef = "javascript:Popola2(" + (object) this.j + ");";
      ++this.j;
    }

    private void MyDataGrid1_PageIndexChanged_1(object source, DataGridPageChangedEventArgs e)
    {
      this.MyDataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.Execute(false);
    }
  }
}
