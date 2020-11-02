// Decompiled with JetBrains decompiler
// Type: TheSite.Admin.Utenti1
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.Admin
{
  public class Utenti1 : Page
  {
    protected S_TextBox txtsUserName;
    protected S_TextBox txtsCognome;
    protected S_Button btnsRicerca;
    protected DataPanel PanelRicerca;
    protected DataGrid DataGridRicerca;
    protected HtmlTable tblSearch75;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    protected S_ComboBox CmbProgetto;
    protected S_ComboBox CmbRuolo;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Admin/EditUtenti.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId;
      ((Control) this.GridTitle1.hplsNuovo).Visible = siteModule.IsEditable;
      this.DataGridRicerca.Columns[1].Visible = siteModule.IsEditable;
      Utenti1.FunId = siteModule.ModuleId;
      Utenti1.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      if (this.IsPostBack)
        return;
      this.BindProgetti1();
      this.BindRuolo();
    }

    private void BindProgetti1()
    {
      ((ListControl) this.CmbProgetto).Items.Clear();
      DataSet data = new Progetti().GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.CmbProgetto).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "descrizione", "id_progetto", "Selezionare un Progetto", "0");
        ((ListControl) this.CmbProgetto).DataTextField = "descrizione";
        ((ListControl) this.CmbProgetto).DataValueField = "id_progetto";
        ((Control) this.CmbProgetto).DataBind();
      }
      else
        ((ListControl) this.CmbProgetto).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Progetto  -", "0"));
    }

    private void BindRuolo()
    {
      ((ListControl) this.CmbRuolo).Items.Clear();
      DataSet data = new Ruolo().GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.CmbRuolo).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "descrizione", "id", "Selezionare Ruolo", "0");
        ((ListControl) this.CmbRuolo).DataTextField = "descrizione";
        ((ListControl) this.CmbRuolo).DataValueField = "id";
        ((Control) this.CmbRuolo).DataBind();
      }
      else
        ((ListControl) this.CmbRuolo).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Ruolo  -", "0"));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      Utente utente = new Utente();
      this.txtsUserName.set_DBDefaultValue((object) "");
      this.txtsCognome.set_DBDefaultValue((object) "");
      this.CmbProgetto.set_DBDefaultValue((object) 0);
      this.CmbRuolo.set_DBDefaultValue((object) 0);
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) ((Control) this.PanelRicerca).Controls);
      DataSet dataSet = utente.GetData1(CollezioneControlli).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
    }
  }
}
