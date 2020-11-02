// Decompiled with JetBrains decompiler
// Type: TheSite.SoddisfazioneCliente.ReportGiudizioCliente
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiDettaglio;
using TheSite.WebControls;

namespace TheSite.SoddisfazioneCliente
{
  public class ReportGiudizioCliente : Page
  {
    protected S_ComboBox cmbsServizio;
    protected S_ComboBox cmbsGiudizio;
    protected Panel PanelServizio;
    protected S_Button btnsRicerca;
    protected S_Button btnReset;
    protected DataPanel PanelRicerca;
    protected S_ComboBox cmbsTipoGiudizio;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected CalendarPicker CPDataDa;
    protected CalendarPicker CPDataA;
    protected CodiceApparecchiature CodiceApparecchiature1;
    protected PageTitle PageTitle1;
    protected RequiredFieldValidator rfvOraRichiesta;
    public static int FunId = 0;
    public int controllo = 0;
    private EditGiudizio _fp;
    protected RicercaModulo RicercaModulo1;
    public static string HelpLink = string.Empty;
    protected TextBox txtBL_ID;
    protected Button btsCodice;
    protected Panel PanelRichiedente;
    protected S_Button cmdExcel;
    private clMyCollection _myColl = new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = new SiteModule("./SoddisfazioneCliente/ReportGiudizioCliente.aspx");
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../SoddisfazioneCliente/EditGiudizio.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId;
      ((Control) this.GridTitle1.hplsNuovo).Visible = siteModule.IsEditable;
      this.DataGridRicerca.Columns[1].Visible = true;
      this.DataGridRicerca.Columns[2].Visible = siteModule.IsEditable;
      ReportGiudizioCliente.FunId = siteModule.ModuleId;
      ReportGiudizioCliente.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindServizio);
      this.CodiceApparecchiature1.NameComboServizio = "cmbsServizio";
      this.CodiceApparecchiature1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.CodiceApparecchiature1.NameComboPiano = "cmbsPiano";
      this.CodiceApparecchiature1.NameComboStanza = "cmbsStanza";
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      stringBuilder2.Append("if (typeof(seledificio) == 'function') { ");
      stringBuilder2.Append("if (seledificio() == false) { return false; }} ");
      stringBuilder2.Append("document.getElementById('" + ((Control) this.cmbsServizio).ClientID + "').disabled = true;");
      if (this.Page.IsPostBack)
        return;
      if (this.Request.QueryString["FunId"] != null)
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      if (this.Context.Handler is EditGiudizio)
      {
        this._fp = (EditGiudizio) this.Context.Handler;
        if (this._fp != null)
        {
          this._myColl = this._fp._Contenitore;
          this._myColl.SetValues(this.Page.Controls);
        }
      }
      this.BindServizio(string.Empty);
      this.BindGiudizio();
      this.CodiceApparecchiature1.Visible = false;
      ((TextBox) this.CodiceApparecchiature1.s_CodiceApparecchiatura).ReadOnly = true;
    }

    private void BindGiudizio()
    {
      ((ListControl) this.cmbsGiudizio).Items.Clear();
      DataSet dataSet = new TheSite.Classi.GiudizioCliente.Giudizio(HttpContext.Current.User.Identity.Name).GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsGiudizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "SDESCRIZIONE", "SID", "- Selezionare Giudizio -", "0");
      ((ListControl) this.cmbsGiudizio).DataTextField = "SDESCRIZIONE";
      ((ListControl) this.cmbsGiudizio).DataValueField = "SID";
      ((Control) this.cmbsGiudizio).DataBind();
    }

    private void Ricerca()
    {
      DataSet data = this.GetData();
      this.DataGridRicerca.DataSource = (object) data.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = data.Tables[0].Rows.Count.ToString();
    }

    private DataSet GetData()
    {
      string str1 = ((TextBox) this.CPDataDa.Datazione).Text;
      if (str1 == "")
        str1 = "0";
      string str2 = ((TextBox) this.CPDataA.Datazione).Text;
      if (str2 == "")
        str2 = "0";
      TheSite.Classi.GiudizioCliente.Giudizio giudizio = new TheSite.Classi.GiudizioCliente.Giudizio();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) (this.RicercaModulo1.Idbl == "" ? 0 : int.Parse(this.RicercaModulo1.Idbl)));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_data_da");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) str1);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_data_a");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) str2);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_id_servizio");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue.ToString() == "" ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue.ToString())));
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_id_soddisfazione");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) (((ListControl) this.cmbsGiudizio).SelectedValue.ToString() == "" ? 0 : int.Parse(((ListControl) this.cmbsGiudizio).SelectedValue.ToString())));
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_tipogiudizio");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Value((object) ((ListControl) this.cmbsTipoGiudizio).SelectedValue);
      CollezioneControlli.Add(sObject6);
      return giudizio.ReportGiudizio(CollezioneControlli).Copy();
    }

    private void BindServizio(string CodEdificio)
    {
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      Servizi servizi = new Servizi(this.Context.User.Identity.Name);
      DataSet data;
      if (CodEdificio != string.Empty)
      {
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Index(0);
        ((ParameterObject) sObject1).set_Value((object) CodEdificio);
        ((ParameterObject) sObject1).set_Size(8);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_ID_Servizio");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(1);
        ((ParameterObject) sObject2).set_Value((object) 0);
        CollezioneControlli.Add(sObject1);
        CollezioneControlli.Add(sObject2);
        data = servizi.GetData(CollezioneControlli);
      }
      else
        data = servizi.GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "Non Definito", "0");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("Non Definito", "0"));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      ((Button) this.cmdExcel).Click += new EventHandler(this.cmdExcel_Click);
      ((Button) this.btnReset).Click += new EventHandler(this.btnReset_Click);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnReset_Click(object sender, EventArgs e) => this.Response.Redirect("ReportGiudizioCliente.aspx?FunId=" + (object) ReportGiudizioCliente.FunId);

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.Ricerca();
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
    }

    private void cmdExcel_Click(object sender, EventArgs e)
    {
      Export export = new Export();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = this.GetData().Tables[0].Copy();
      if (dataTable2.Rows.Count != 0)
      {
        export.ExportDetails(dataTable2, (Export.ExportFormat) 2, "exp.xls");
      }
      else
      {
        string script = "<script language=JavaScript>alert('Nessun elemento da esportare');" + "<" + "/" + "script>";
        if (this.IsClientScriptBlockRegistered("clientScriptexp"))
          return;
        this.RegisterStartupScript("clientScriptexp", script);
      }
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }
  }
}
