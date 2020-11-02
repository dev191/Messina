// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorrettiva.AnalisiCostiOperativiDiGestione
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
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManCorrettiva;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorrettiva
{
  public class AnalisiCostiOperativiDiGestione : Page
  {
    protected S_TextBox txtsRichiesta;
    protected S_ComboBox cmbsUrgenza;
    protected S_ComboBox cmbsServizio;
    protected S_Button btnsRicerca;
    protected DataPanel PanelRicerca;
    protected S_TextBox txtsOrdine;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected GridTitle Gridtitle2;
    protected PageTitle PageTitle1;
    protected RicercaModulo RicercaModulo1;
    protected CalendarPicker CalendarPicker1;
    protected CalendarPicker CalendarPicker2;
    protected CalendarPicker CalendarPicker3;
    protected CalendarPicker CalendarPicker4;
    protected TheSite.WebControls.Addetti Addetti1;
    protected TheSite.WebControls.Richiedenti Richiedenti1;
    protected S_TextBox txtDescrizione;
    protected S_Button cmdExcel;
    protected CompareValidator CompareValidator1;
    protected Button cmdReset;
    protected S_ComboBox cmbsGruppo;
    protected S_ComboBox cmbsTipoIntervento;
    protected S_ComboBox cmbsStatus;
    protected S_ComboBox cmbsTipoManutenzione;
    protected DataGrid DataGridRicerca2;
    protected ValidationSummary ValidationSummary1;
    public static string HelpLink = string.Empty;
    private CreazioneSGA _fp1 = (CreazioneSGA) null;
    private EditSfoglia _fp = (EditSfoglia) null;
    private AnalisiCostiOperativiDiGestioneDettaglio _fp2 = (AnalisiCostiOperativiDiGestioneDettaglio) null;
    public static int FunId = 0;
    private clMyCollection _myColl = new clMyCollection();
    private double totpreventivo = 0.0;
    private double totconsuntivo = 0.0;

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      ((WebControl) this.txtsRichiesta).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtsRichiesta).Attributes.Add("onpaste", "return nonpaste();");
      ((WebControl) this.txtsOrdine).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtsOrdine).Attributes.Add("onpaste", "return nonpaste();");
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      AnalisiCostiOperativiDiGestione.FunId = siteModule.ModuleId;
      AnalisiCostiOperativiDiGestione.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = "ANALISI COSTI OPERATIVI DI GESTIONE";
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindServizio);
      if (!this.Page.IsPostBack)
      {
        if (this.Request.QueryString["FunId"] != null)
          this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
        this.CompareValidator1.ControlToValidate = this.CalendarPicker2.ID + ":" + ((Control) this.CalendarPicker2.Datazione).ID;
        this.CompareValidator1.ControlToCompare = this.CalendarPicker1.ID + ":" + ((Control) this.CalendarPicker1.Datazione).ID;
        this.DataGridRicerca.Visible = false;
        ((Control) this.GridTitle1.hplsNuovo).Visible = false;
        this.GridTitle1.Visible = false;
        this.BindServizio("");
        this.BindGruppo();
        this.BindUrgenza();
        this.BindStatus();
        this.BindTipoInterventoAter();
        this.BinTipoManutenzione();
        this.DataGridRicerca.Visible = false;
        this.GridTitle1.Visible = false;
        this.DataGridRicerca2.Visible = true;
        this.Gridtitle2.Visible = true;
        if (this.Context.Handler is CreazioneSGA)
        {
          this._fp1 = (CreazioneSGA) this.Context.Handler;
          if (this._fp1 != null)
          {
            this._myColl = this._fp1._Contenitore;
            this._myColl.SetValues(this.Page.Controls);
            if (((ListControl) this.cmbsTipoManutenzione).SelectedValue == "3")
              this.Ricerca(true);
            else
              this.RicercaManRichiesta(true);
          }
        }
        if (this.Context.Handler is EditSfoglia)
        {
          this._fp = (EditSfoglia) this.Context.Handler;
          if (this._fp != null)
          {
            this._myColl = this._fp._Contenitore;
            this._myColl.SetValues(this.Page.Controls);
            if (((ListControl) this.cmbsTipoManutenzione).SelectedValue == "3")
              this.Ricerca(true);
            else
              this.RicercaManRichiesta(true);
          }
        }
        if (this.Context.Handler is AnalisiCostiOperativiDiGestioneDettaglio)
        {
          this._fp2 = (AnalisiCostiOperativiDiGestioneDettaglio) this.Context.Handler;
          if (this._fp2 != null)
          {
            this._myColl = this._fp2._Contenitore;
            this._myColl.SetValues(this.Page.Controls);
            if (((ListControl) this.cmbsTipoManutenzione).SelectedValue == "3")
              this.Ricerca(true);
            else
              this.RicercaManRichiesta(true);
          }
        }
      }
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      ((Control) this.Gridtitle2.hplsNuovo).Visible = false;
    }

    private void BinTipoManutenzione()
    {
      DataSet tipoManutenzione = new ClManCorrettiva().GetTipoManutenzione();
      if (tipoManutenzione.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsTipoManutenzione).DataSource = (object) tipoManutenzione;
      ((ListControl) this.cmbsTipoManutenzione).DataTextField = "descrizione";
      ((ListControl) this.cmbsTipoManutenzione).DataValueField = "id";
      ((Control) this.cmbsTipoManutenzione).DataBind();
      ((WebControl) this.cmbsTipoManutenzione).Attributes.Add("OnChange", "Visualizza(this.value);");
    }

    private void BindServizio(string CodEdificio)
    {
      this.GridTitle1.DescriptionTitle = "";
      this.Addetti1.Set_BL_ID(CodEdificio);
      this.DataGridRicerca.Visible = false;
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      Servizi servizi = new Servizi(this.Context.User.Identity.Name);
      DataSet data;
      if (CodEdificio != "")
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
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "0");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("Non Definito", "-1"));
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("Non Definito", "-1"));
    }

    private void BindGruppo()
    {
      ((ListControl) this.cmbsGruppo).Items.Clear();
      DataSet guppo = new TheSite.Classi.ManStraordinaria.GestioneRdl(this.Context.User.Identity.Name).GetGuppo();
      if (guppo.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsGruppo).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(guppo.Tables[0], "descrizione", "richiedenti_tipo_id", "- Selezionare un Gruppo -", "");
        ((ListControl) this.cmbsGruppo).DataTextField = "descrizione";
        ((ListControl) this.cmbsGruppo).DataValueField = "richiedenti_tipo_id";
        ((Control) this.cmbsGruppo).DataBind();
      }
      else
        ((ListControl) this.cmbsGruppo).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Gruppo -", string.Empty));
    }

    private void BindUrgenza()
    {
      ((ListControl) this.cmbsUrgenza).Items.Clear();
      DataSet urgenza = new TheSite.Classi.ManStraordinaria.GestioneRdl(this.Context.User.Identity.Name).GetUrgenza();
      if (urgenza.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsUrgenza).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(urgenza.Tables[0], "descrizione", "id_priority", "- Selezionare una Urgenza -", "");
        ((ListControl) this.cmbsUrgenza).DataTextField = "descrizione";
        ((ListControl) this.cmbsUrgenza).DataValueField = "id_priority";
        ((Control) this.cmbsUrgenza).DataBind();
      }
      else
        ((ListControl) this.cmbsUrgenza).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Urgenza -", string.Empty));
    }

    private void BindStatus()
    {
      ((ListControl) this.cmbsStatus).Items.Clear();
      ((ListControl) this.cmbsStatus).Items.Add(new ListItem("Attività Completata", "4"));
    }

    private void BindTipoInterventoAter()
    {
      ((ListControl) this.cmbsTipoIntervento).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet data = new TipoIntervento().GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsTipoIntervento).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "descrizione_breve", "ID", "- Selezionare il Tipo Intervento -", "");
        ((ListControl) this.cmbsTipoIntervento).DataTextField = "descrizione_breve";
        ((ListControl) this.cmbsTipoIntervento).DataValueField = "id";
        ((Control) this.cmbsTipoIntervento).DataBind();
      }
      else
        ((ListControl) this.cmbsTipoIntervento).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Tipo Intervento -", string.Empty));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.cmdReset.Click += new EventHandler(this.cmdReset_Click);
      ((Button) this.cmdExcel).Click += new EventHandler(this.cmdExcel_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.DataGridRicerca2.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca2_ItemCommand);
      this.DataGridRicerca2.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca2_PageIndexChanged);
      this.DataGridRicerca2.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca2_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.DataGridRicerca2.CurrentPageIndex = 0;
      if (((ListControl) this.cmbsTipoManutenzione).SelectedValue == "3")
        this.Ricerca(true);
      else
        this.RicercaManRichiesta(true);
    }

    private void Ricerca(bool reset)
    {
      this.DataGridRicerca.Visible = true;
      this.GridTitle1.Visible = true;
      this.DataGridRicerca2.Visible = false;
      this.Gridtitle2.Visible = false;
      DataSet data = this.GetData(false);
      this.DataGridRicerca.DataSource = (object) data.Tables[0];
      if (reset)
      {
        int num1 = int.Parse(this.GetData(true).Tables[0].Rows[0][0].ToString());
        this.GridTitle1.NumeroRecords = num1.ToString();
        if (num1 % this.DataGridRicerca.PageSize == 0)
        {
          int num2 = num1 / this.DataGridRicerca.PageSize;
        }
        else
        {
          int num3 = num1 / this.DataGridRicerca.PageSize;
        }
      }
      else
        double.Parse(this.GridTitle1.NumeroRecords);
      this.DataGridRicerca.Visible = true;
      this.GridTitle1.Visible = true;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      if (int.Parse(this.GridTitle1.NumeroRecords) == 0)
      {
        this.DataGridRicerca.CurrentPageIndex = 0;
        this.GridTitle1.DescriptionTitle = "Nessun dato trovato.";
      }
      else
      {
        this.CalcolaTotali(data.Tables[0]);
        this.GridTitle1.DescriptionTitle = "";
      }
      this.DataGridRicerca.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.DataGridRicerca.DataBind();
    }

    private void CalcolaTotali(DataTable dt)
    {
      foreach (DataRow row in (InternalDataCollectionBase) dt.Rows)
      {
        if (row["importostimato"] != DBNull.Value)
          this.totpreventivo += double.Parse(row["importostimato"].ToString());
        if (row["importoconsuntivo"] != DBNull.Value)
          this.totconsuntivo += double.Parse(row["importoconsuntivo"].ToString());
      }
    }

    private DataSet GetData(bool Count)
    {
      TheSite.Classi.ManStraordinaria.Richiesta richiesta = new TheSite.Classi.ManStraordinaria.Richiesta();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_campus");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.RicercaModulo1.TxtRicerca).Text);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_Wr_Id");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Value((object) (((TextBox) this.txtsRichiesta).Text == "" ? 0 : int.Parse(((TextBox) this.txtsRichiesta).Text)));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_Addetto");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Value((object) this.Addetti1.NomeCompleto);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_DataDa");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Size(10);
      ((ParameterObject) sObject5).set_Value(((TextBox) this.CalendarPicker1.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_DataA");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Size(10);
      ((ParameterObject) sObject6).set_Value(((TextBox) this.CalendarPicker2.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_Wo_Id");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Size(50);
      ((ParameterObject) sObject7).set_Value((object) (((TextBox) this.txtsOrdine).Text == "" ? 0 : int.Parse(((TextBox) this.txtsOrdine).Text)));
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_ID_Servizio");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(7);
      ((ParameterObject) sObject8).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_Status");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(8);
      ((ParameterObject) sObject9).set_Value((object) (((ListControl) this.cmbsStatus).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsStatus).SelectedValue)));
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_Richiedente");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(9);
      ((ParameterObject) sObject10).set_Size(50);
      ((ParameterObject) sObject10).set_Value((object) this.Richiedenti1.NomeCompleto);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_Priority");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(10);
      ((ParameterObject) sObject11).set_Value((object) (((ListControl) this.cmbsUrgenza).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsUrgenza).SelectedValue)));
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_Descrizione");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(11);
      ((ParameterObject) sObject12).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject12).set_Value((object) ((TextBox) this.txtDescrizione).Text);
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_Gruppo");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(12);
      ((ParameterObject) sObject13).set_Value((object) (((ListControl) this.cmbsGruppo).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsGruppo).SelectedValue)));
      CollezioneControlli.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("p_tipointerventoater");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(13);
      ((ParameterObject) sObject14).set_Value((object) (((ListControl) this.cmbsTipoIntervento).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsTipoIntervento).SelectedValue)));
      CollezioneControlli.Add(sObject14);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("p_datainizio");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Index(14);
      ((ParameterObject) sObject15).set_Size(10);
      ((ParameterObject) sObject15).set_Value(((TextBox) this.CalendarPicker3.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker3.Datazione).Text);
      CollezioneControlli.Add(sObject15);
      S_Object sObject16 = new S_Object();
      ((ParameterObject) sObject16).set_ParameterName("p_datafine");
      ((ParameterObject) sObject16).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject16).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject16).set_Index(15);
      ((ParameterObject) sObject16).set_Size(10);
      ((ParameterObject) sObject16).set_Value(((TextBox) this.CalendarPicker4.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker4.Datazione).Text);
      CollezioneControlli.Add(sObject16);
      DataSet dataSet;
      if (!Count)
      {
        S_Object sObject17 = new S_Object();
        ((ParameterObject) sObject17).set_ParameterName("pageindex");
        ((ParameterObject) sObject17).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject17).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject17).set_Index(16);
        ((ParameterObject) sObject17).set_Value((object) (this.DataGridRicerca.CurrentPageIndex + 1));
        CollezioneControlli.Add(sObject17);
        S_Object sObject18 = new S_Object();
        ((ParameterObject) sObject18).set_ParameterName("pagesize");
        ((ParameterObject) sObject18).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject18).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject18).set_Index(17);
        ((ParameterObject) sObject18).set_Value((object) this.DataGridRicerca.PageSize);
        CollezioneControlli.Add(sObject18);
        dataSet = richiesta.GetSfogliaRDL(CollezioneControlli).Copy();
      }
      else
        dataSet = richiesta.GetSfogliaRDLCount(CollezioneControlli).Copy();
      return dataSet;
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca(false);
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        ImageButton control1 = (ImageButton) e.Item.Cells[2].FindControl("Imagebutton2");
        string str = "1";
        if (e.Item.Cells[14].Text != str)
          control1.Visible = false;
        ((WebControl) e.Item.Cells[1].FindControl("lnkDett")).Attributes.Add("title", "Emetti o Completa Richiesta di Lavoro");
        HtmlImage htmlImage1 = new HtmlImage();
        HtmlImage htmlImage2 = new HtmlImage();
        HtmlAnchor control2 = (HtmlAnchor) e.Item.Cells[3].Controls[1];
        HtmlAnchor control3 = (HtmlAnchor) e.Item.Cells[4].Controls[1];
        DataRowView dataItem = (DataRowView) e.Item.DataItem;
        if (dataItem["pdfpreventivo"] == DBNull.Value || dataItem["pdfpreventivo"].ToString() == "")
        {
          control2.HRef = "#";
          htmlImage1.Src = "../Images/no pdf_logo.gif";
          htmlImage1.Attributes.Add("title", "Nessun Pdf Preventivo");
        }
        else
        {
          control2.HRef = "javascript:openpdf('" + dataItem["WR_ID"].ToString() + "','Preventivo','" + dataItem["pdfpreventivo"].ToString().Replace("'", "`") + "');";
          htmlImage1.Src = "../Images/pdf_logo.gif";
          htmlImage1.Attributes.Add("title", "Pdf Preventivo");
        }
        htmlImage1.Style.Add("Width", "22px");
        htmlImage1.Style.Add("Height", "26px");
        htmlImage1.Style.Add("Border", "0");
        control2.Controls.Add((Control) htmlImage1);
        if (dataItem["pdfconsuntivo"] == DBNull.Value || dataItem["pdfconsuntivo"].ToString() == "")
        {
          control3.HRef = "#";
          htmlImage2.Src = "../Images/no pdf_logo.gif";
          htmlImage2.Attributes.Add("title", "Nessun Pdf Consuntivo");
        }
        else
        {
          control3.HRef = "javascript:openpdf('" + dataItem["WR_ID"].ToString() + "','Consuntivo','" + dataItem["pdfconsuntivo"].ToString().Replace("'", "`") + "');";
          htmlImage2.Src = "../Images/pdf_logo.gif";
          htmlImage2.Attributes.Add("title", "Pdf Consuntivo");
        }
        htmlImage2.Style.Add("Width", "22px");
        htmlImage2.Style.Add("Height", "26px");
        htmlImage2.Style.Add("Border", "0");
        control3.Controls.Add((Control) htmlImage2);
      }
      if (e.Item.ItemType != ListItemType.Footer)
        return;
      e.Item.Cells[1].ColumnSpan = 3;
      e.Item.Cells[1].Text = "<b>TOTALE GENERALE</b>";
      e.Item.Cells[10].HorizontalAlign = HorizontalAlign.Right;
      e.Item.Cells[10].Text = "<b>" + this.totpreventivo.ToString("C") + "</b>";
      e.Item.Cells[11].HorizontalAlign = HorizontalAlign.Right;
      e.Item.Cells[11].Text = "<b>" + this.totconsuntivo.ToString("C") + "</b>";
      e.Item.Cells[12].Visible = false;
      e.Item.Cells[13].Visible = false;
    }

    private void cmdExcel_Click(object sender, EventArgs e)
    {
      Export export = new Export();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = !(((ListControl) this.cmbsTipoManutenzione).SelectedValue == "3") ? this.GetWordExcel().Tables[0].Copy() : this.GetData(false).Tables[0].Copy();
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

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (e.CommandName == "Dettaglio")
      {
        this._myColl.AddControl(this.Page.Controls, ParentType.Page);
        string path1 = e.CommandArgument.ToString();
        switch (e.Item.Cells[14].Text.Trim())
        {
          case "1":
          case "7":
          case "15":
            this._myColl.AddControl(this.Page.Controls, ParentType.Page);
            this.Server.Transfer(path1);
            break;
          default:
            string path2 = path1 + "&c=true";
            this._myColl.AddControl(this.Page.Controls, ParentType.Page);
            this.Server.Transfer(path2);
            break;
        }
      }
      if (!(e.CommandName == "Modifica"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString());
    }

    private void cmdReset_Click(object sender, EventArgs e) => this.Response.Redirect("SfogliaRdlPaging.aspx?FunID=" + this.ViewState["FunId"]);

    private void RicercaManRichiesta(bool reset)
    {
      this.DataGridRicerca.Visible = false;
      this.GridTitle1.Visible = false;
      this.DataGridRicerca2.Visible = true;
      this.Gridtitle2.Visible = true;
      TheSite.Classi.ManOrdinaria.Richiesta richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_campus");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.RicercaModulo1.TxtRicerca).Text);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_Wr_Id");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Value((object) (((TextBox) this.txtsRichiesta).Text == "" ? 0 : int.Parse(((TextBox) this.txtsRichiesta).Text)));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_Addetto");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Value((object) this.Addetti1.NomeCompleto);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_DataDa");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Size(10);
      ((ParameterObject) sObject5).set_Value(((TextBox) this.CalendarPicker1.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_DataA");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Size(10);
      ((ParameterObject) sObject6).set_Value(((TextBox) this.CalendarPicker2.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_Wo_Id");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Size(50);
      ((ParameterObject) sObject7).set_Value((object) (((TextBox) this.txtsOrdine).Text == "" ? 0 : int.Parse(((TextBox) this.txtsOrdine).Text)));
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_ID_Servizio");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(7);
      ((ParameterObject) sObject8).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_Status");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(8);
      ((ParameterObject) sObject9).set_Value((object) (((ListControl) this.cmbsStatus).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsStatus).SelectedValue)));
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_Richiedente");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(9);
      ((ParameterObject) sObject10).set_Size(50);
      ((ParameterObject) sObject10).set_Value((object) this.Richiedenti1.NomeCompleto);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_Priority");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(10);
      ((ParameterObject) sObject11).set_Value((object) (((ListControl) this.cmbsUrgenza).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsUrgenza).SelectedValue)));
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_Descrizione");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(11);
      ((ParameterObject) sObject12).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject12).set_Value((object) ((TextBox) this.txtDescrizione).Text);
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_Gruppo");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(12);
      ((ParameterObject) sObject13).set_Value((object) (((ListControl) this.cmbsGruppo).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsGruppo).SelectedValue)));
      CollezioneControlli.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("pageindex");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(16);
      ((ParameterObject) sObject14).set_Value((object) (this.DataGridRicerca2.CurrentPageIndex + 1));
      CollezioneControlli.Add(sObject14);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("pagesize");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Index(17);
      ((ParameterObject) sObject15).set_Value((object) this.DataGridRicerca2.PageSize);
      CollezioneControlli.Add(sObject15);
      this.DataGridRicerca2.DataSource = (object) richiesta.GetSfogliaRDL(CollezioneControlli).Copy().Tables[0];
      if (reset)
      {
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        int sfogliaRdlCount = richiesta.GetSfogliaRDLCount(CollezioneControlli);
        this.Gridtitle2.NumeroRecords = sfogliaRdlCount.ToString();
        if (sfogliaRdlCount % this.DataGridRicerca2.PageSize == 0)
        {
          int num1 = sfogliaRdlCount / this.DataGridRicerca2.PageSize;
        }
        else
        {
          int num2 = sfogliaRdlCount / this.DataGridRicerca2.PageSize;
        }
      }
      else
        double.Parse(this.Gridtitle2.NumeroRecords);
      this.DataGridRicerca2.Visible = true;
      this.Gridtitle2.Visible = true;
      ((Control) this.Gridtitle2.hplsNuovo).Visible = false;
      if (int.Parse(this.Gridtitle2.NumeroRecords) == 0)
      {
        this.DataGridRicerca2.CurrentPageIndex = 0;
        this.Gridtitle2.DescriptionTitle = "Nessun dato trovato.";
      }
      else
        this.Gridtitle2.DescriptionTitle = "";
      this.DataGridRicerca2.VirtualItemCount = int.Parse(this.Gridtitle2.NumeroRecords);
      this.DataGridRicerca2.DataBind();
    }

    public DataSet GetWordExcel()
    {
      TheSite.Classi.ManOrdinaria.Richiesta richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_campus");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.RicercaModulo1.TxtRicerca).Text);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_Wr_Id");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Value((object) (((TextBox) this.txtsRichiesta).Text == "" ? 0 : int.Parse(((TextBox) this.txtsRichiesta).Text)));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_Addetto");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Value((object) this.Addetti1.NomeCompleto);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_DataDa");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Size(10);
      ((ParameterObject) sObject5).set_Value(((TextBox) this.CalendarPicker1.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_DataA");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Size(10);
      ((ParameterObject) sObject6).set_Value(((TextBox) this.CalendarPicker2.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_Wo_Id");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Size(50);
      ((ParameterObject) sObject7).set_Value((object) (((TextBox) this.txtsOrdine).Text == "" ? 0 : int.Parse(((TextBox) this.txtsOrdine).Text)));
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_ID_Servizio");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(7);
      ((ParameterObject) sObject8).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_Status");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(8);
      ((ParameterObject) sObject9).set_Value((object) (((ListControl) this.cmbsStatus).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsStatus).SelectedValue)));
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_Richiedente");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(9);
      ((ParameterObject) sObject10).set_Size(50);
      ((ParameterObject) sObject10).set_Value((object) this.Richiedenti1.NomeCompleto);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_Priority");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(10);
      ((ParameterObject) sObject11).set_Value((object) (((ListControl) this.cmbsUrgenza).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsUrgenza).SelectedValue)));
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_Descrizione");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(11);
      ((ParameterObject) sObject12).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject12).set_Value((object) ((TextBox) this.txtDescrizione).Text);
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_Gruppo");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(12);
      ((ParameterObject) sObject13).set_Value((object) (((ListControl) this.cmbsGruppo).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsGruppo).SelectedValue)));
      CollezioneControlli.Add(sObject13);
      int num = !this.DataGridRicerca2.Visible ? this.DataGridRicerca.CurrentPageIndex + 1 : this.DataGridRicerca2.CurrentPageIndex + 1;
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("pageindex");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(16);
      ((ParameterObject) sObject14).set_Value((object) num);
      CollezioneControlli.Add(sObject14);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("pagesize");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Index(17);
      ((ParameterObject) sObject15).set_Value((object) this.DataGridRicerca2.PageSize);
      CollezioneControlli.Add(sObject15);
      return richiesta.GetSfogliaRDL(CollezioneControlli).Copy();
    }

    private void DataGridRicerca2_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca2.CurrentPageIndex = e.NewPageIndex;
      this.RicercaManRichiesta(false);
    }

    private void DataGridRicerca2_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ImageButton control = (ImageButton) e.Item.Cells[2].FindControl("Imagebutton3");
      string str1 = "1";
      if (e.Item.Cells[14].Text != str1)
        control.Visible = false;
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton1")).Attributes.Add("title", "Emetti o Completa Richiesta di Lavoro");
      if (e.Item.Cells[2].Text.Trim().Length > 20)
      {
        string str2 = e.Item.Cells[2].Text.Trim().Substring(0, 18) + "...";
        e.Item.Cells[2].ToolTip = e.Item.Cells[2].Text;
        e.Item.Cells[2].Text = str2;
      }
      if (e.Item.Cells[12].Text.Trim().Length > 20)
      {
        string str2 = e.Item.Cells[12].Text.Trim().Substring(0, 18) + "...";
        e.Item.Cells[12].ToolTip = e.Item.Cells[12].Text;
        e.Item.Cells[12].Text = str2;
      }
      if (e.Item.Cells[5].Text.Trim().Length <= 12)
        return;
      string str3 = e.Item.Cells[5].Text.Trim().Substring(0, 10) + "...";
      e.Item.Cells[5].ToolTip = e.Item.Cells[5].Text;
      e.Item.Cells[5].Text = str3;
    }

    private void DataGridRicerca2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (e.CommandName == "Modifica")
      {
        this._myColl.AddControl(this.Page.Controls, ParentType.Page);
        this.Server.Transfer(e.CommandArgument.ToString());
      }
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      string path1 = e.CommandArgument.ToString();
      switch (e.Item.Cells[14].Text.Trim())
      {
        case "1":
        case "7":
        case "15":
          this._myColl.AddControl(this.Page.Controls, ParentType.Page);
          this.Server.Transfer(path1);
          break;
        default:
          string path2 = path1 + "&c=true";
          this._myColl.AddControl(this.Page.Controls, ParentType.Page);
          this.Server.Transfer(path2);
          break;
      }
    }
  }
}
