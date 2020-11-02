// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.PianoFerie
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
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

namespace TheSite.Gestione
{
  public class PianoFerie : Page
  {
    protected S_TextBox txtsNome;
    protected S_TextBox txtsCognome;
    protected S_Button btnsRicerca;
    protected DataPanel PanelRicerca;
    protected CompareValidator CompareValidator1;
    protected DataGrid DataGridRicerca;
    protected CalendarPicker InizioFerie;
    protected CalendarPicker FineFerie;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    protected S_ComboBox TipoPermesso;
    protected S_Button btreset;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      PianoFerie.FunId = siteModule.ModuleId;
      PianoFerie.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["FunId"] != null)
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      this.GridTitle1.Visible = false;
      this.CompareValidator1.ControlToValidate = this.FineFerie.ID + ":" + ((Control) this.FineFerie.Datazione).ID;
      this.CompareValidator1.ControlToCompare = this.InizioFerie.ID + ":" + ((Control) this.InizioFerie.Datazione).ID;
      this.BindControls();
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
    }

    public DataSet loadMotivoAssenza() => new Motivo_assenza().GetAllData().Copy();

    private void BindControls()
    {
      DataSet dataSet = this.loadMotivoAssenza();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.TipoPermesso).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "id", "- Selezionare il Permesso -", "0");
      ((ListControl) this.TipoPermesso).DataTextField = "descrizione";
      ((ListControl) this.TipoPermesso).DataValueField = "id";
      ((Control) this.TipoPermesso).DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      ((Button) this.btreset).Click += new EventHandler(this.btreset_Click);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void Ricerca()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_nome");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.txtsNome).Text);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_cognome");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.txtsCognome).Text);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_dataInizio");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Value(((TextBox) this.InizioFerie.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.InizioFerie.Datazione).Text);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_dataFine");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Value(((TextBox) this.FineFerie.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.FineFerie.Datazione).Text);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_idMotivo");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) int.Parse(((ListControl) this.TipoPermesso).SelectedValue));
      CollezioneControlli.Add(sObject5);
      DataSet data = new TheSite.Classi.ClassiAnagrafiche.PianoFerie().GetData(CollezioneControlli);
      this.DataGridRicerca.DataSource = (object) data.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.Visible = true;
      this.GridTitle1.NumeroRecords = data.Tables[0].Rows.Count.ToString();
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.Ricerca();
    }

    private void btreset_Click(object sender, EventArgs e) => this.Response.Redirect("PianoFerie.aspx?FunId=" + this.ViewState["FunId"].ToString());

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }
  }
}
