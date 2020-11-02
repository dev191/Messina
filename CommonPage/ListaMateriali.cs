// Decompiled with JetBrains decompiler
// Type: TheSite.CommonPage.ListaMateriali
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi.ManCorrettiva;

namespace TheSite.CommonPage
{
  public class ListaMateriali : Page
  {
    protected HyperLink HyperLink1;
    protected DataGrid DataGrid1;
    protected HyperLink Hyperlink2;
    private string Desc = "";
    private int id;
    public int j = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      string script1 = "<script language='JavaScript'>\n" + "var a = new Array(" + (object) this.DataGrid1.PageSize + ");\n" + "var b = new Array(" + (object) this.DataGrid1.PageSize + ");\n" + "var c = new Array(" + (object) this.DataGrid1.PageSize + ");\n" + "<" + "/" + "script>";
      if (!this.Page.IsClientScriptBlockRegistered("array1"))
        this.Page.RegisterClientScriptBlock("array1", script1);
      if (!this.Page.IsPostBack)
      {
        this.idmodulo = this.Request.QueryString["idmodulo"] == null ? string.Empty : this.Request.QueryString["idmodulo"];
        if (this.Request.QueryString["idric"] != null)
          this.Desc = this.Request.QueryString["idric"].ToString();
        this.Cerca(this.Desc);
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

    private void Cerca(string Descr)
    {
      this.DataGrid1.DataSource = (object) new ClManCorrettiva().getMateriali(Descr).Copy();
      this.DataGrid1.DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
      this.DataGrid1.ItemDataBound += new DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      string script = "<script language='JavaScript'>\n" + "a[" + this.j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[3].Text).Replace("\"", "\\\"") + "\";\n" + "b[" + this.j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[1].Text).Replace("\"", "\\\"") + "\";\n" + "c[" + this.j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[2].Text).Replace("\"", "\\\"") + "\";\n" + "<" + "/" + "script>";
      this.RegisterStartupScript("scriptarray" + this.j.ToString(), script);
      ((HtmlAnchor) e.Item.FindControl("hrefset")).HRef = "javascript:Popola2(" + (object) this.j + ");";
      ++this.j;
      e.Item.Cells[4].Text = e.Item.Cells[2].Text.Split(';')[1] + " / " + e.Item.Cells[2].Text.Split(';')[2] + " €";
    }

    private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.Cerca(this.Desc);
    }
  }
}
