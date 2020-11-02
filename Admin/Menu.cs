// Decompiled with JetBrains decompiler
// Type: TheSite.Admin.Menu
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
using TheSite.WebControls;

namespace TheSite.Admin
{
  public class Menu : Page
  {
    protected S_TextBox txtsDescrizione;
    protected S_Button btnsRicerca;
    protected DataPanel PanelRicerca;
    protected DataGrid DataGridRicerca;
    protected S_TextBox txtsCssClass;
    protected GridTitle GridTitle1;
    protected S_ComboBox cmbsMenuPadre;
    protected S_ComboBox cmbsFunzione;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    private DataGridItem _PrevItem = (DataGridItem) null;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Admin/EditMenu.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId;
      ((Control) this.GridTitle1.hplsNuovo).Visible = siteModule.IsEditable;
      this.DataGridRicerca.Columns[1].Visible = siteModule.IsEditable;
      Menu.FunId = siteModule.ModuleId;
      Menu.HelpLink = siteModule.HelpLink;
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
      TheSite.Classi.Menu menu = new TheSite.Classi.Menu();
      this.txtsDescrizione.set_DBDefaultValue((object) "%");
      this.txtsCssClass.set_DBDefaultValue((object) "%");
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) ((Control) this.PanelRicerca).Controls);
      DataSet dataSet = menu.GetData(CollezioneControlli).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
    }

    private void BindControls()
    {
      ((BaseDataBoundControl) this.cmbsFunzione).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(new Funzione().GetData().Tables[0], "DESCRIZIONE", "ID", "", "0");
      ((ListControl) this.cmbsFunzione).DataTextField = "DESCRIZIONE";
      ((ListControl) this.cmbsFunzione).DataValueField = "ID";
      ((Control) this.cmbsFunzione).DataBind();
      ((BaseDataBoundControl) this.cmbsMenuPadre).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(new TheSite.Classi.Menu().GetDataMenuPadre().Tables[0], "DESCRIZIONE", "ID", "", "-1");
      ((ListControl) this.cmbsMenuPadre).DataTextField = "DESCRIZIONE";
      ((ListControl) this.cmbsMenuPadre).DataValueField = "ID";
      ((Control) this.cmbsMenuPadre).DataBind();
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      DataGridItem dataGridItem = e.Item;
      if (dataGridItem.ItemType != ListItemType.Item && dataGridItem.ItemType != ListItemType.AlternatingItem)
        return;
      if (this._PrevItem != null)
      {
        if (this._PrevItem.Cells[2].Text == dataGridItem.Cells[4].Text)
        {
          dataGridItem.Font.Italic = true;
          dataGridItem.Font.Size = FontUnit.Smaller;
          dataGridItem.Cells[2].Text = "<font color=#ff6600><LI type=square>&nbsp;</LI></font>" + dataGridItem.Cells[2].Text;
        }
        else
          this._PrevItem = dataGridItem;
      }
      else
        this._PrevItem = dataGridItem;
    }
  }
}
