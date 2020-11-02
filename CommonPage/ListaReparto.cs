// Decompiled with JetBrains decompiler
// Type: TheSite.CommonPage.ListaReparto
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi.ClassiAnagrafiche;

namespace TheSite.CommonPage
{
  public class ListaReparto : Page
  {
    protected HyperLink HyperLink1;
    protected DataGrid DataGrid1;
    protected HyperLink Hyperlink2;
    private string Desc = "";
    public string NomeTxtDesc = "";
    public string NomeTxtIdMat = "";
    public string chiamante = "";
    private Stanze ioDati = new Stanze();
    public int j = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      string script1 = "<script language='JavaScript'>\n" + "var a = new Array(" + (object) this.DataGrid1.PageSize + ");\n" + "var b = new Array(" + (object) this.DataGrid1.PageSize + ");\n" + "var c = new Array(" + (object) this.DataGrid1.PageSize + ");\n" + "<" + "/" + "script>";
      if (!this.Page.IsClientScriptBlockRegistered("arrayRep"))
        this.Page.RegisterClientScriptBlock("arrayRep", script1);
      this.NomeTxtDesc = this.Request.QueryString["IdTxt"] == null ? string.Empty : this.Request.QueryString["IdTxt"];
      this.NomeTxtIdMat = this.Request.QueryString["IdMat"] == null ? string.Empty : this.Request.QueryString["IdMat"];
      this.Desc = this.Request.QueryString["desc"] == null ? string.Empty : this.Request.QueryString["desc"];
      this.chiamante = this.Request.QueryString["chiamante"] == null ? string.Empty : this.Request.QueryString["chiamante"];
      if (!this.Page.IsPostBack)
        this.Cerca(this.Desc);
      string script2 = "<script language=JavaScript> var idmoduloRep='" + this.idmodulo + "'" + "<" + "/" + "script>";
      if (this.IsClientScriptBlockRegistered("clientScriptRep"))
        return;
      this.RegisterClientScriptBlock("clientScriptRep", script2);
    }

    private string idmodulo
    {
      get => (string) this.ViewState["s_idmodulo"];
      set => this.ViewState["s_idmodulo"] = (object) value;
    }

    private void Cerca(string Descr)
    {
      this.DataGrid1.DataSource = !(this.chiamante == "Spazi") ? (object) this.ioDati.GetAllReparto(Descr).Copy() : (object) this.ioDati.GetRepartoMura(Descr).Copy();
      this.DataGrid1.DataBind();
    }

    private void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      "PopolaRep('" + e.Item.Cells[1].Text + "','" + e.Item.Cells[2].Text + "');";
      ((HtmlAnchor) e.Item.FindControl("hrefset")).HRef = "javascript:PopolaRep('" + e.Item.Cells[1].Text + "','" + e.Item.Cells[2].Text + "');";
    }

    private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.Cerca(this.Desc);
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
  }
}
