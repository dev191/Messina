// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.Specializzazioni
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
  public class Specializzazioni : Page
  {
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    protected S_Button btnsRicerca;
    protected DataPanel PanelRicerca;
    protected DataGrid DataGridRicerca;
    protected S_TextBox txtsDescrizione;
    private EditSpecializzazioni _fp;
    protected S_TextBox S_TextBox1;
    protected S_TextBox txtsServizio;
    protected S_Button BtnReset;
    private clMyCollection _myColl = new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Gestione/EditSpecializzazioni.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId;
      ((Control) this.GridTitle1.hplsNuovo).Visible = siteModule.IsEditable;
      this.DataGridRicerca.Columns[1].Visible = siteModule.IsEditable;
      Specializzazioni.FunId = siteModule.ModuleId;
      Specializzazioni.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      if (this.Page.IsPostBack || !(this.Context.Handler is EditSpecializzazioni))
        return;
      this._fp = (EditSpecializzazioni) this.Context.Handler;
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
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      ((Button) this.BtnReset).Click += new EventHandler(this.BtnReset_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    public clMyCollection _Contenitore => this._myColl;

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Response.Redirect((string) this.ViewState["UrlReferrer"]);

    private void btnsRicerca_Click(object sender, EventArgs e) => this.Ricerca();

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString());
    }

    private void Ricerca()
    {
      TheSite.Classi.ClassiAnagrafiche.Addetti addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
      this.txtsDescrizione.set_DBDefaultValue((object) "%");
      this.txtsServizio.set_DBDefaultValue((object) "%");
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) ((Control) this.PanelRicerca).Controls);
      DataSet dataSet = addetti.GetDataTR(CollezioneControlli).Copy();
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

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton3")).Attributes.Add("title", "Visualizza");
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton1")).Attributes.Add("title", "Modifica");
    }

    private void BtnReset_Click(object sender, EventArgs e) => this.Response.Redirect("Specializzazioni.aspx?FunId=" + (object) Specializzazioni.FunId);
  }
}
