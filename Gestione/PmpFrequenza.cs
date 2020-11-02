// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.PmpFrequenza
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
  public class PmpFrequenza : Page
  {
    protected S_TextBox txtsFrequenza_des;
    protected S_TextBox txtsFrequenza;
    protected DataPanel PanelRicerca;
    protected S_Button btnsRicerca;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    private clMyCollection _myColl = new clMyCollection();
    protected S_Button BtnReset;
    protected S_ComboBox CmbCadenza;
    protected S_Button btnEsportaXsl;
    private EditPmpFrequenza _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Gestione/EditPmpFrequenza.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId;
      ((Control) this.GridTitle1.hplsNuovo).Visible = siteModule.IsEditable;
      this.DataGridRicerca.Columns[1].Visible = siteModule.IsEditable;
      PmpFrequenza.FunId = siteModule.ModuleId;
      PmpFrequenza.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      if (this.Page.IsPostBack || !(this.Context.Handler is EditPmpFrequenza))
        return;
      this._fp = (EditPmpFrequenza) this.Context.Handler;
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
      ((Button) this.BtnReset).Click += new EventHandler(this.BtnReset_Click);
      ((Button) this.btnEsportaXsl).Click += new EventHandler(this.btnEsportaXsl_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    public clMyCollection _Contenitore => this._myColl;

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.Ricerca();
    }

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString());
    }

    private void Ricerca()
    {
      if (((ListControl) this.CmbCadenza).SelectedValue == "-1")
      {
        this.DataGridRicerca.Columns[5].Visible = false;
        this.DataGridRicerca.Columns[6].Visible = false;
        this.DataGridRicerca.Columns[7].Visible = false;
        this.DataGridRicerca.Columns[8].Visible = false;
      }
      if (((ListControl) this.CmbCadenza).SelectedValue == "0")
      {
        this.DataGridRicerca.Columns[5].Visible = true;
        this.DataGridRicerca.Columns[6].Visible = true;
        this.DataGridRicerca.Columns[7].Visible = true;
        this.DataGridRicerca.Columns[8].Visible = false;
      }
      if (((ListControl) this.CmbCadenza).SelectedValue == "1")
      {
        this.DataGridRicerca.Columns[5].Visible = false;
        this.DataGridRicerca.Columns[6].Visible = false;
        this.DataGridRicerca.Columns[7].Visible = false;
        this.DataGridRicerca.Columns[8].Visible = true;
      }
      TheSite.Classi.ClassiAnagrafiche.PmpFrequenza pmpFrequenza = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza();
      this.txtsFrequenza.set_DBDefaultValue((object) "%");
      this.txtsFrequenza_des.set_DBDefaultValue((object) "%");
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) ((Control) this.PanelRicerca).Controls);
      DataSet dataSet = pmpFrequenza.GetData(CollezioneControlli).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      if (dataSet.Tables[0].Rows.Count == 0)
      {
        this.DataGridRicerca.CurrentPageIndex = 0;
      }
      else
      {
        int num = 0;
        if (dataSet.Tables[0].Rows.Count % this.DataGridRicerca.PageSize > 0)
          ++num;
        if (this.DataGridRicerca.PageCount != (int) Convert.ToInt16(dataSet.Tables[0].Rows.Count / this.DataGridRicerca.PageSize + num))
          this.DataGridRicerca.CurrentPageIndex = 0;
      }
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton3")).Attributes.Add("title", "Visualizza");
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton1")).Attributes.Add("title", "Modifica");
      if (e.Item.Cells[4].Text == "1")
      {
        DataSet dataStag = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza().GetDataStag(e.Item.Cells[2].Text);
        Repeater control = (Repeater) e.Item.Cells[8].FindControl("rp");
        control.DataSource = (object) dataStag.Tables[0];
        control.DataBind();
      }
      if (e.Item.Cells[4].Text == "0")
        e.Item.Cells[4].Text = "Periodico";
      else
        e.Item.Cells[4].Text = "Fisso";
      if (e.Item.Cells[9].Text == "0")
        e.Item.Cells[9].Text = "NO";
      else
        e.Item.Cells[9].Text = "SI";
    }

    private void BtnReset_Click(object sender, EventArgs e) => this.Response.Redirect("PmpFrequenza.aspx?FunId=" + (object) PmpFrequenza.FunId);

    private void btnEsportaXsl_Click(object sender, EventArgs e)
    {
      TheSite.Classi.ClassiAnagrafiche.PmpFrequenza pmpFrequenza = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza();
      Export export = new Export();
      DataTable dataTable = new DataTable();
      string SSql = string.Empty;
      switch (Convert.ToInt32(((ListControl) this.CmbCadenza).SelectedValue))
      {
        case -1:
          SSql = "PACK_PMPFREQUENZA.SP_GRTPMPFREQ_XLS_SINT";
          break;
        case 0:
          SSql = "PACK_PMPFREQUENZA.SP_GRTPMPFREQ_XLS_PER";
          break;
        case 1:
          SSql = "PACK_PMPFREQUENZA.SP_GRTPMPFREQ_XLS_FIS";
          break;
      }
      DataTable datiXsl = pmpFrequenza.GetDatiXsl(((TextBox) this.txtsFrequenza).Text, ((TextBox) this.txtsFrequenza_des).Text, SSql);
      if (datiXsl.Rows.Count != 0)
      {
        export.ExportDetails(datiXsl, (Export.ExportFormat) 2, "exp.xls");
      }
      else
      {
        string script = "<script language=JavaScript>alert('Nessun elemento da esportare');" + "<" + "/" + "script>";
        if (this.IsClientScriptBlockRegistered("clientScriptexp"))
          return;
        this.RegisterStartupScript("clientScriptexp", script);
      }
    }
  }
}
