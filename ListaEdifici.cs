// Decompiled with JetBrains decompiler
// Type: TheSite.ListaEdifici
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
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite
{
  public class ListaEdifici : Page
  {
    protected HyperLink HyperLink1;
    protected HyperLink HyperLinkChiudi2;
    protected DataGrid MyDataGrid1;
    protected GridTitle GridTitle1;
    public int j = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      string script1 = "<script language='JavaScript'>\n" + "var a = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var b = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var c = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var d = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var e = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var f = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var g = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var h = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var i = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var l = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "var m = new Array(" + (object) this.MyDataGrid1.PageSize + ");\n" + "<" + "/" + "script>";
      if (!this.Page.IsClientScriptBlockRegistered("array1"))
        this.Page.RegisterClientScriptBlock("array1", script1);
      if (!this.Page.IsPostBack)
      {
        this.idcod = this.Request.QueryString["idcod"] == null ? string.Empty : this.Request.QueryString["idcod"];
        this.idric = this.Request.QueryString["idric"] == null ? string.Empty : this.Request.QueryString["idric"];
        this.prj = this.Request.QueryString["VarApp"] == null ? string.Empty : this.Request.QueryString["VarApp"];
        this.idmodulo = this.Request.QueryString["idmodulo"] == null ? string.Empty : this.Request.QueryString["idmodulo"];
        this.multiselect = this.Request.QueryString["ms"] == null ? string.Empty : this.Request.QueryString["ms"];
        this.id_comune = this.Request.QueryString["id_comune"] == null ? string.Empty : this.Request.QueryString["id_comune"];
        this.id_frazione = this.Request.QueryString["id_comune"] == null ? string.Empty : this.Request.QueryString["id_frazione"];
        this.Execute(true);
      }
      string script2 = "<script language=JavaScript> var idmodulo='" + this.idmodulo + "'" + "<" + "/" + "script>";
      if (!this.IsClientScriptBlockRegistered("clientScript"))
        this.RegisterClientScriptBlock("clientScript", script2);
      this.GridTitle1.DescriptionTitle = "Lista Edifici";
    }

    private string idmodulo
    {
      get => (string) this.ViewState["s_idmodulo"];
      set => this.ViewState["s_idmodulo"] = (object) value;
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

    private string prj
    {
      get => (string) this.ViewState["VarApp"];
      set => this.ViewState["VarApp"] = (object) value;
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

    private void Execute(bool reset)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Size(10);
      ((ParameterObject) sObject1).set_Value((object) this.idcod);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_id_comune");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) (this.id_comune == "" ? 0 : int.Parse(this.id_comune)));
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_id_frazione");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) (this.id_frazione == "" ? 0 : int.Parse(this.id_frazione)));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_Username");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Value((object) this.Context.User.Identity.Name);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_campus");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size(128);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Value((object) this.idric);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_progetto");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject6).set_Value((object) (this.prj == "" ? 0 : int.Parse(this.prj)));
      CollezioneControlli.Add(sObject6);
      Navigazione navigazione = new Navigazione();
      if (reset)
      {
        int count = navigazione.GetCount(CollezioneControlli);
        this.GridTitle1.NumeroRecords = count.ToString();
        if (count % this.MyDataGrid1.PageSize == 0)
        {
          int num1 = count / this.MyDataGrid1.PageSize;
        }
        else
        {
          int num2 = count / this.MyDataGrid1.PageSize;
        }
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
      }
      else
        double.Parse(this.GridTitle1.NumeroRecords);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("pageindex");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject7).set_Value((object) (this.MyDataGrid1.CurrentPageIndex + 1));
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("pagesize");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject8).set_Value((object) this.MyDataGrid1.PageSize);
      CollezioneControlli.Add(sObject8);
      this.MyDataGrid1.DataSource = (object) navigazione.GetData(CollezioneControlli);
      this.MyDataGrid1.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.MyDataGrid1.DataBind();
      this.GridTitle1.DescriptionTitle = "Lista degli Edifici";
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

    private void MyDataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      string script = "<script language='JavaScript'>\n" + "a[" + this.j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[1].Text).Replace("\"", "\\\"") + "\";\n" + "b[" + this.j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[2].Text).Replace("\"", "\\\"") + "\";\n" + "c[" + this.j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[3].Text).Replace("\"", "\\\"") + "\";\n" + "d[" + this.j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[4].Text).Replace("\"", "\\\"") + "\";\n" + "e[" + this.j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[5].Text).Replace("\"", "\\\"") + "\";\n" + "f[" + this.j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[6].Text).Replace("\"", "\\\"") + "\";\n" + "g[" + this.j.ToString() + "] =\"" + e.Item.Cells[7].Text.Replace("&nsp;", " ") + "\";\n" + "h[" + this.j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[8].Text.Replace("&nsp;", " ")) + "\";\n" + "i[" + this.j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[9].Text).Replace("\"", "\\\"") + "\";\n" + "l[" + this.j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[10].Text).Replace("\"", "\\\"") + "\";\n" + "m[" + this.j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[11].Text).Replace("\"", "\\\"") + "\";\n" + "<" + "/" + "script>";
      this.RegisterStartupScript("scriptarray" + this.j.ToString(), script);
      if (this.multiselect == "y")
        ((HtmlAnchor) e.Item.FindControl("hrefset")).HRef = "javascript:Popola1(" + (object) this.j + ");";
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
