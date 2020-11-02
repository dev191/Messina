// Decompiled with JetBrains decompiler
// Type: TheSite.CommonPage.RiepilogoSolleciti
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
using TheSite.Classi.ManOrdinaria;

namespace TheSite.CommonPage
{
  public class RiepilogoSolleciti : Page
  {
    protected DataGrid MyDataGrid1;
    public static int FunId = 0;
    protected HyperLink HyperLink1;
    protected HyperLink HyperLinkChiudi2;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      RiepilogoSolleciti.FunId = ((SiteModule) HttpContext.Current.Items[(object) "SiteModule"]).ModuleId;
      if (this.Request.QueryString["FunId"] != null)
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      this.idric = this.Request.QueryString["idric"] == null ? "" : this.Request.QueryString["idric"].ToString();
      if (!(this.idric != ""))
        return;
      this.Execute(this.idric);
    }

    private string idric
    {
      get => this.ViewState[nameof (idric)].ToString();
      set => this.ViewState[nameof (idric)] = (object) value;
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
      this.Load += new EventHandler(this.Page_Load);
    }

    private void Execute(string idric)
    {
      this.MyDataGrid1.DataSource = (object) new Solleciti().GetDataWR(idric);
      this.MyDataGrid1.DataBind();
    }

    private void MyDataGrid1_PageIndexChanged_1(object source, DataGridPageChangedEventArgs e)
    {
      this.MyDataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.Execute(this.idric);
    }
  }
}
