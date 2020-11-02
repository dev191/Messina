// Decompiled with JetBrains decompiler
// Type: TheSite.Admin.Ruoli
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.WebControls;

namespace TheSite.Admin
{
  public class Ruoli : Page
  {
    protected DataPanel PanelRicerca;
    protected S_Button btnsRicerca;
    protected S_TextBox txtsDescrizione;
    protected S_TextBox txtsNote;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    protected S_ComboBox cmbsDitta;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Admin/EditRuoli.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId;
      ((Control) this.GridTitle1.hplsNuovo).Visible = siteModule.IsEditable;
      this.DataGridRicerca.Columns[1].Visible = siteModule.IsEditable;
      this.DataGridRicerca.Columns[2].Visible = siteModule.IsEditable;
      Ruoli.FunId = siteModule.ModuleId;
      Ruoli.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      if (this.Page.IsPostBack)
        return;
      this.BindControls();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      Ruolo ruolo = new Ruolo();
      this.txtsDescrizione.set_DBDefaultValue((object) "%");
      this.txtsNote.set_DBDefaultValue((object) "%");
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) ((Control) this.PanelRicerca).Controls);
      DataSet dataSet = ruolo.GetData(CollezioneControlli).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
    }

    private void BindControls()
    {
      ((BaseDataBoundControl) this.cmbsDitta).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(new Ditte().GetData().Tables[0], "DESCRIZIONE", "ID", "", "0");
      ((ListControl) this.cmbsDitta).DataTextField = "DESCRIZIONE";
      ((ListControl) this.cmbsDitta).DataValueField = "ID";
      ((Control) this.cmbsDitta).DataBind();
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[2].FindControl("Hyperlink1")).Attributes.Add("title", "Modifica Ruolo");
      ((WebControl) e.Item.Cells[1].FindControl("Hyperlink2")).Attributes.Add("title", "Associazione Ruolo Edifici");
    }
  }
}
