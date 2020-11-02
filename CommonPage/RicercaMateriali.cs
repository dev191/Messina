// Decompiled with JetBrains decompiler
// Type: TheSite.CommonPage.RicercaMateriali
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi.ManCorrettiva;

namespace TheSite.CommonPage
{
  public class RicercaMateriali : Page
  {
    protected HyperLink HyperLink1;
    protected DataGrid DataGrid1;
    protected HyperLink Hyperlink2;
    private string Desc = "";
    public string NomeTxtDesc = "";
    public string NomeTxtPrezzo = "";
    public string NomeTxtIdMat = "";
    public int j = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.Page.IsPostBack)
        return;
      this.NomeTxtDesc = this.Request.QueryString["IdTxt"] == null ? string.Empty : this.Request.QueryString["IdTxt"];
      this.NomeTxtPrezzo = this.Request.QueryString["IdPrezzo"] == null ? string.Empty : this.Request.QueryString["IdPrezzo"];
      this.NomeTxtIdMat = this.Request.QueryString["IdMat"] == null ? string.Empty : this.Request.QueryString["IdMat"];
      this.Desc = this.Request.QueryString["desc"] == null ? string.Empty : this.Request.QueryString["desc"];
      this.Cerca(this.Desc);
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

    private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.Cerca(this.Desc);
    }

    private void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      "Popola2('" + e.Item.Cells[1].Text + "','" + e.Item.Cells[2].Text.Split(';')[2] + "','" + e.Item.Cells[3].Text + "');";
      ((HtmlAnchor) e.Item.FindControl("hrefset")).HRef = "javascript:Popola2('" + e.Item.Cells[1].Text + "','" + e.Item.Cells[2].Text.Split(';')[2] + "','" + e.Item.Cells[3].Text + "');";
      e.Item.Cells[4].Text = e.Item.Cells[2].Text.Split(';')[1] + " / " + e.Item.Cells[2].Text.Split(';')[2] + " €";
    }
  }
}
