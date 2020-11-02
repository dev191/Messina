// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.PercentualiStraordinari
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
  public class PercentualiStraordinari : Page
  {
    protected S_TextBox txtsCodice;
    protected S_Button btnsRicerca;
    protected Button BtnReset;
    protected DataPanel PanelRicerca;
    protected S_ComboBox cmbsLivello;
    protected DataGrid DataGridRicerca;
    private EditPercentualeStraordinari _fp;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    private clMyCollection _myColl = new clMyCollection();
    protected GridTitle GridTitle1;
    protected S_TextBox txtsPercentuale;
    protected PageTitle PageTitle1;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Gestione/EditPercentualeStraordinari.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId;
      ((Control) this.GridTitle1.hplsNuovo).Visible = siteModule.IsEditable;
      this.DataGridRicerca.Columns[1].Visible = true;
      this.DataGridRicerca.Columns[2].Visible = siteModule.IsEditable;
      PercentualiStraordinari.FunId = siteModule.ModuleId;
      PercentualiStraordinari.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      if (this.Page.IsPostBack)
        return;
      this.BindLivello();
      if (!(this.Context.Handler is EditPercentualeStraordinari))
        return;
      this._fp = (EditPercentualeStraordinari) this.Context.Handler;
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
      this.BtnReset.Click += new EventHandler(this.BtnReset_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void BindLivello()
    {
      TheSite.Classi.ClassiAnagrafiche.Livelli livelli = new TheSite.Classi.ClassiAnagrafiche.Livelli();
      ((ListControl) this.cmbsLivello).Items.Clear();
      DataSet dataSet = livelli.GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsLivello).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "codicelivello", "id", "- Selezionare un Livello -", "-1");
      ((ListControl) this.cmbsLivello).DataTextField = "codicelivello";
      ((ListControl) this.cmbsLivello).DataValueField = "id";
      ((Control) this.cmbsLivello).DataBind();
    }

    public clMyCollection _Contenitore => this._myColl;

    private void Ricerca()
    {
      TheSite.Classi.ClassiAnagrafiche.PercentualiStraordinari percentualiStraordinari = new TheSite.Classi.ClassiAnagrafiche.PercentualiStraordinari();
      this.txtsCodice.set_DBDefaultValue((object) DBNull.Value);
      this.txtsPercentuale.set_DBDefaultValue((object) 0);
      this.cmbsLivello.set_DBDefaultValue((object) 0);
      ((TextBox) this.txtsCodice).Text = ((TextBox) this.txtsCodice).Text.Trim();
      ((TextBox) this.txtsPercentuale).Text = ((TextBox) this.txtsPercentuale).Text.Trim();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) ((Control) this.PanelRicerca).Controls);
      DataSet dataSet = percentualiStraordinari.GetData(CollezioneControlli).Copy();
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

    private void btnsRicerca_Click(object sender, EventArgs e) => this.Ricerca();

    private void BtnReset_Click(object sender, EventArgs e) => this.Response.Redirect("PercentualiStraordinari.aspx?FunId=" + (object) PercentualiStraordinari.FunId);

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString());
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton3")).Attributes.Add("title", "Visualizza");
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton2")).Attributes.Add("title", "Modifica");
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }
  }
}
