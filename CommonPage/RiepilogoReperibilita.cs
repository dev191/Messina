// Decompiled with JetBrains decompiler
// Type: TheSite.CommonPage.RiepilogoReperibilita
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;

namespace TheSite.CommonPage
{
  public class RiepilogoReperibilita : Page
  {
    protected DataGrid MyDataGrid1;
    public static int FunId = 0;
    protected HyperLink HyperLink1;
    protected HyperLink HyperLinkChiudi2;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      RiepilogoReperibilita.FunId = ((SiteModule) HttpContext.Current.Items[(object) "SiteModule"]).ModuleId;
      if (this.Request.QueryString["FunId"] != null)
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      this.bl_id = this.Request.QueryString["bl_id"] == null ? "" : this.Request.QueryString["bl_id"].ToString();
      if (this.bl_id == "")
        this.Execute();
      else
        this.Execute(this.bl_id);
    }

    private string bl_id
    {
      get => this.ViewState[nameof (bl_id)].ToString();
      set => this.ViewState[nameof (bl_id)] = (object) value;
    }

    public DataSet fasce(int addettoid, int giorno) => new Reperibilita().GetReperibilita(addettoid, giorno).Copy();

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.MyDataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged_1);
      this.MyDataGrid1.ItemDataBound += new DataGridItemEventHandler(this.MyDataGrid1_ItemDataBound);
      this.MyDataGrid1.SelectedIndexChanged += new EventHandler(this.MyDataGrid1_SelectedIndexChanged);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void Execute()
    {
      this.MyDataGrid1.DataSource = (object) new Reperibilita().GetAllAddetti().Tables[0];
      this.MyDataGrid1.DataBind();
    }

    private void Execute(string bl_id)
    {
      this.MyDataGrid1.DataSource = (object) new Reperibilita().GetAddettiDistinct(bl_id);
      this.MyDataGrid1.DataBind();
    }

    private void btReset_Click(object sender, EventArgs e) => this.Response.Redirect("RiepilogoReperibilita.aspx?FunId=" + this.ViewState["FunId"]);

    private void MyDataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void MyDataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
    }

    private void MyDataGrid1_PageIndexChanged_1(object source, DataGridPageChangedEventArgs e)
    {
      this.MyDataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.bl_id = this.Request.QueryString["bl_id"] == null ? "" : this.Request.QueryString["bl_id"].ToString();
      if (this.bl_id == "")
        this.Execute();
      else
        this.Execute(this.bl_id);
    }
  }
}
