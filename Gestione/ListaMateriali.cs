// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.ListaMateriali
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class ListaMateriali : Page
  {
    protected DataPanel PanelRicerca;
    protected S_Button btnsRicerca;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    private EditMateriale _fp;
    protected S_TextBox txtCodMateriale;
    protected S_TextBox txtDescMateriale;
    protected S_ComboBox cmbUnita;
    protected S_Button btnReset;
    private clMyCollection _myColl = new clMyCollection();

    private void Ricerca()
    {
      TheSite.Classi.ClassiAnagrafiche.ListaMateriali listaMateriali = new TheSite.Classi.ClassiAnagrafiche.ListaMateriali();
      this.txtCodMateriale.set_DBDefaultValue((object) "");
      this.txtDescMateriale.set_DBDefaultValue((object) "");
      this.cmbUnita.set_DBDefaultValue((object) "0");
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) ((Control) this.PanelRicerca).Controls);
      DataSet dataSet = listaMateriali.GetData(CollezioneControlli).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
    }

    private void btnsRicerca_Click(object sender, EventArgs e) => this.Ricerca();

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString());
    }

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Gestione/EditMateriale.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId;
      ((Control) this.GridTitle1.hplsNuovo).Visible = siteModule.IsEditable;
      this.DataGridRicerca.Columns[1].Visible = true;
      this.DataGridRicerca.Columns[2].Visible = siteModule.IsEditable;
      ListaMateriali.FunId = this.Request.QueryString["FunId"] == null ? siteModule.ModuleId : Convert.ToInt32(this.Request.QueryString["FunId"]);
      ListaMateriali.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      ListaMateriali.FunId = siteModule.ModuleId;
      ListaMateriali.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      if (this.Page.IsPostBack)
        return;
      this.BindUnita();
      if (!(this.Context.Handler is EditMateriale))
        return;
      this._fp = (EditMateriale) this.Context.Handler;
      if (this._fp == null)
        return;
      this._myColl = this._fp._Contenitore;
      this._myColl.SetValues(this.Page.Controls);
      this.Ricerca();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      ((Button) this.btnReset).Click += new EventHandler(this.btnReset_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.DataGridRicerca.SelectedIndexChanged += new EventHandler(this.DataGridRicerca_SelectedIndexChanged);
      this.Load += new EventHandler(this.Page_Load);
    }

    public clMyCollection _Contenitore => this._myColl;

    private void BindUnita()
    {
      ((ListControl) this.cmbUnita).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiDettaglio.UnitaMisura(HttpContext.Current.User.Identity.Name).GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbUnita).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE_COD", "IDUNITA", "- Selezionare Unità di Misura -", "0");
      ((ListControl) this.cmbUnita).DataTextField = "DESCRIZIONE_COD";
      ((ListControl) this.cmbUnita).DataValueField = "IDUNITA";
      ((Control) this.cmbUnita).DataBind();
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[1].FindControl("imgVisualizza")).Attributes.Add("title", "Visualizza");
      ((WebControl) e.Item.Cells[1].FindControl("imgModifica")).Attributes.Add("title", "Modifica");
    }

    private void btnReset_Click(object sender, EventArgs e) => this.Response.Redirect("ListaMateriali.aspx?FunId=" + (object) ListaMateriali.FunId);

    private void DataGridRicerca_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
  }
}
