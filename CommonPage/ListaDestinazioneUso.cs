// Decompiled with JetBrains decompiler
// Type: TheSite.CommonPage.ListaDestinazioneUso
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
  public class ListaDestinazioneUso : Page
  {
    protected HyperLink HyperLink1;
    protected DataGrid DataGrid1;
    protected HyperLink Hyperlink2;
    private string Desc = "";
    public string NomeTxtDesc = "";
    public string NomeTxtIdMat = "";
    private int id;
    public string chiamante = "";
    private Stanze ioDati = new Stanze();
    public int j = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      string script1 = "<script language='JavaScript'>\n" + "var a = new Array(" + (object) this.DataGrid1.PageSize + ");\n" + "var b = new Array(" + (object) this.DataGrid1.PageSize + ");\n" + "var c = new Array(" + (object) this.DataGrid1.PageSize + ");\n" + "<" + "/" + "script>";
      if (!this.Page.IsClientScriptBlockRegistered("arrayDest"))
        this.Page.RegisterClientScriptBlock("arrayDest", script1);
      this.NomeTxtDesc = this.Request.QueryString["IdTxt"] == null ? string.Empty : this.Request.QueryString["IdTxt"];
      this.NomeTxtIdMat = this.Request.QueryString["IdMat"] == null ? string.Empty : this.Request.QueryString["IdMat"];
      this.chiamante = this.Request.QueryString["chiamante"] == null ? string.Empty : this.Request.QueryString["chiamante"];
      if (!this.Page.IsPostBack)
      {
        this.Desc = this.Request.QueryString["desc"] == null ? string.Empty : this.Request.QueryString["desc"];
        this.Cerca(this.Desc);
      }
      string script2 = "<script language=JavaScript> var idmodulodest='" + this.idmodulo + "'" + "<" + "/" + "script>";
      if (this.IsClientScriptBlockRegistered("clientScriptDest"))
        return;
      this.RegisterClientScriptBlock("clientScriptDest", script2);
    }

    private string idmodulo
    {
      get => (string) this.ViewState["s_idmodulo"];
      set => this.ViewState["s_idmodulo"] = (object) value;
    }

    private void Cerca(string Descr)
    {
      this.DataGrid1.DataSource = !(this.chiamante == "Spazi") ? (object) this.ioDati.GetAllDestinazioni(Descr).Copy() : (object) this.ioDati.GetDestinazioniMura(Descr).Copy();
      this.DataGrid1.DataBind();
    }

    private void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      "PopolaDest('" + e.Item.Cells[2].Text + "','" + e.Item.Cells[1].Text + "');";
      ((HtmlAnchor) e.Item.FindControl("hrefset")).HRef = "javascript:PopolaDest('" + e.Item.Cells[2].Text + "','" + e.Item.Cells[1].Text + "');";
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
