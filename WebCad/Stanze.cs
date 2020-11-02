// Decompiled with JetBrains decompiler
// Type: WebCad.Stanze
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebCad
{
  public class Stanze : Page
  {
    protected DataGrid MyDataGrid1;
    public string idbl = string.Empty;
    public string idpiano = string.Empty;
    protected string elementiTrovati = "0";

    private void Page_Load(object sender, EventArgs e)
    {
      this.idbl = this.Request.QueryString["idbl"];
      this.idpiano = this.Request.QueryString["idpiano"];
      if (this.IsPostBack)
        return;
      this.BindStanze();
    }

    private void BindStanze()
    {
      if (this.Request.QueryString["idbl"] == null)
        return;
      Servizi servizi = new Servizi();
      string s1 = this.Request.QueryString["idpiano"];
      string s2 = this.Request.QueryString["idbl"];
      string descrizione = this.Request.QueryString["descrizione"].Trim();
      DataSet stanzeBuilding = servizi.GetStanzeBuilding(int.Parse(s2), int.Parse(s1), descrizione);
      this.MyDataGrid1.DataSource = (object) stanzeBuilding;
      this.elementiTrovati = Convert.ToString(stanzeBuilding.Tables[0].Rows.Count);
      this.MyDataGrid1.DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.MyDataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged);
      this.MyDataGrid1.ItemDataBound += new DataGridItemEventHandler(this.MyDataGrid1_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void MyDataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      HtmlAnchor control = (HtmlAnchor) e.Item.FindControl("hrefset");
      DataRowView dataItem = (DataRowView) e.Item.DataItem;
      control.Attributes.Add("onclick", "Valorizza('" + dataItem["id"] + "','" + dataItem["descrizione"] + "')");
    }

    private void MyDataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.MyDataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.BindStanze();
    }
  }
}
