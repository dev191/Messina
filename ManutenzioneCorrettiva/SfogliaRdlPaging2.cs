// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorrettiva.SfogliaRdlPaging2
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
using TheSite.Classi.ManOrdinaria;
using TheSite.Classi.ManStraordinaria;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorrettiva
{
  public class SfogliaRdlPaging2 : Page
  {
    public SiteModule _SiteModule;
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
    protected string operatore;
    public static string HelpLink = string.Empty;
    private object _fp1 = (object) null;
    private EditSfoglia _fp = (EditSfoglia) null;
    private TheSite.CostiOperativi.CostiOperativi _fp2 = (TheSite.CostiOperativi.CostiOperativi) null;
    public static int FunId = 0;
    private clMyCollection _myColl = new clMyCollection();
    protected int _currentPageNumber = 1;
    private double totpreventivo = 0.0;
    private double totconsuntivo = 0.0;

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      this.operatore = HttpContext.Current.User.Identity.Name;
      ((WebControl) this.txtsRichiesta).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtsRichiesta).Attributes.Add("onpaste", "return nonpaste();");
      ((WebControl) this.txtsOrdine).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtsOrdine).Attributes.Add("onpaste", "return nonpaste();");
      this._SiteModule = new SiteModule("./ManutenzioneCorrettiva/SfogliaRdlPaging1.aspx");
      SfogliaRdlPaging2.FunId = this._SiteModule.ModuleId;
      SfogliaRdlPaging2.HelpLink = this._SiteModule.HelpLink;
      this.PageTitle1.Title = "SFOGLIA RDL CORRETTIVA";
      this.RicercaModulo1.DelegatePresidio1 += new DelegatePresidio(this.BindUrgenza);
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindServizio);
      if (!this.Page.IsPostBack)
      {
        if (this.Request.QueryString["FunId"] != null)
          this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
        this.CompareValidator1.ControlToValidate = this.CalendarPicker2.ID + ":" + ((Control) this.CalendarPicker2.Datazione).ID;
        this.CompareValidator1.ControlToCompare = this.CalendarPicker1.ID + ":" + ((Control) this.CalendarPicker1.Datazione).ID;
        S_TextBox datazione1 = this.CalendarPicker1.Datazione;
        DateTime now = DateTime.Now;
        string shortDateString1 = now.ToShortDateString();
        ((TextBox) datazione1).Text = shortDateString1;
        S_TextBox datazione2 = this.CalendarPicker2.Datazione;
        now = DateTime.Now;
        string shortDateString2 = now.ToShortDateString();
        ((TextBox) datazione2).Text = shortDateString2;
        this.DataGridRicerca.Visible = false;
        ((Control) this.GridTitle1.hplsNuovo).Visible = false;
        this.GridTitle1.Visible = false;
        this.BindServizio("");
        this.BindGruppo();
        this.BindUrgenza("");
        this.BindStatus();
        this.BindTipoInterventoAter();
        this.BinTipoManutenzione();
        this.DataGridRicerca.Visible = false;
        this.GridTitle1.Visible = false;
        this.DataGridRicerca2.Visible = true;
        this.Gridtitle2.Visible = true;
        if (this.Context.Handler is CompletaRdl || this.Context.Handler is EditApprovaEmetti)
        {
          this._fp1 = (object) (this.Context.Handler as CompletaRdl);
          if (this._fp1 != null)
          {
            this._myColl = ((CompletaRdl) this._fp1)._Contenitore;
            this._myColl.SetValues(this.Page.Controls);
          }
          this._fp1 = (object) (this.Context.Handler as EditApprovaEmetti);
          if (this._fp1 != null)
          {
            this._myColl = ((EditApprovaEmetti) this._fp1)._Contenitore;
            this._myColl.SetValues(this.Page.Controls);
          }
          if (((ListControl) this.cmbsTipoManutenzione).SelectedValue == "3")
            this.Ricerca(true);
          else
            this.RicercaManRichiesta(true);
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
        if (this.Context.Handler is TheSite.CostiOperativi.CostiOperativi)
        {
          this._fp2 = (TheSite.CostiOperativi.CostiOperativi) this.Context.Handler;
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
      DataSet dataSet;
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
        dataSet = servizi.GetData(CollezioneControlli);
      }
      else
        dataSet = servizi.GetData2();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "0");
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
      string id_prog = "";
      if (this.Request.QueryString["VarApp"] != null)
        id_prog = this.Request.QueryString["VarApp"];
      DataSet dataSet = new Richiedenti_tipo().GetAllAddProg(id_prog).Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsGruppo).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "id", "- Selezionare un Gruppo -", "");
        ((ListControl) this.cmbsGruppo).DataTextField = "descrizione";
        ((ListControl) this.cmbsGruppo).DataValueField = "id";
        ((Control) this.cmbsGruppo).DataBind();
      }
      else
        ((ListControl) this.cmbsGruppo).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Gruppo -", string.Empty));
    }

    private void BindUrgenza(string Codice)
    {
      string progetto = "";
      if (this.Request.QueryString["VarApp"] != null)
        progetto = this.Request.QueryString["VarApp"];
      if (Codice != "")
      {
        ((BaseDataBoundControl) this.cmbsUrgenza).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(new Urgenza().GetPriorita(Convert.ToInt32(Codice), progetto).Tables[0], "DESCRIPTION", "id", "- Selezionare una Priorità -", "0");
        ((ListControl) this.cmbsUrgenza).DataTextField = "DESCRIPTION";
        ((ListControl) this.cmbsUrgenza).DataValueField = "ID";
        ((Control) this.cmbsUrgenza).DataBind();
      }
      else
      {
        ((BaseDataBoundControl) this.cmbsUrgenza).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(new Urgenza().GetPriorita(0, progetto).Tables[0], "DESCRIPTION", "id", "- Selezionare una Priorità -", "0");
        ((ListControl) this.cmbsUrgenza).DataTextField = "DESCRIPTION";
        ((ListControl) this.cmbsUrgenza).DataValueField = "ID";
        ((Control) this.cmbsUrgenza).DataBind();
      }
    }

    private void BindStatus()
    {
      ((ListControl) this.cmbsStatus).Items.Clear();
      DataSet status = new ManCorrettivaPaging().GetStatus();
      if (status.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsStatus).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(status.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Stato -", "");
        ((ListControl) this.cmbsStatus).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsStatus).DataValueField = "ID";
        ((Control) this.cmbsStatus).DataBind();
      }
      else
        ((ListControl) this.cmbsStatus).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Stato -", string.Empty));
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
      ManCorrettivaPaging correttivaPaging = new ManCorrettivaPaging();
      S_ControlsCollection data1 = this.GetData();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pageindex");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(17);
      ((ParameterObject) sObject1).set_Value((object) (this.DataGridRicerca.CurrentPageIndex + 1));
      data1.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pagesize");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(18);
      ((ParameterObject) sObject2).set_Value((object) this.DataGridRicerca.PageSize);
      data1.Add(sObject2);
      DataSet dataSet = correttivaPaging.GetSfogliaRDLPaging(data1).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      if (reset)
      {
        ((CollectionBase) data1).Clear();
        S_ControlsCollection data2 = this.GetData();
        this.GridTitle1.NumeroRecords = correttivaPaging.GetCount(data2).ToString();
      }
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
        this.CalcolaTotali(dataSet.Tables[0]);
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

    private string operatore1()
    {
      int length = this.operatore.Length;
      if (length == 3)
        this.operatore = !(this.operatore == "urp") ? "UTENTE DIPARTIMENTO" : "UTENTE URP";
      if (length == 4)
        this.operatore = "UTENTE DIPARTIMENTO" + this.operatore.Substring(3, 1);
      if (length == 5)
        this.operatore = "UTENTE DIPARTIMENTO" + this.operatore.Substring(3, 2);
      return this.operatore;
    }

    private S_ControlsCollection GetData()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_campus");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.RicercaModulo1.TxtRicerca).Text);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_Wr_Id");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Value((object) (((TextBox) this.txtsRichiesta).Text == "" ? 0 : int.Parse(((TextBox) this.txtsRichiesta).Text)));
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_Addetto");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Value((object) this.Addetti1.NomeCompleto);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_DataDa");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Size(10);
      ((ParameterObject) sObject5).set_Value(((TextBox) this.CalendarPicker1.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_DataA");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Size(10);
      ((ParameterObject) sObject6).set_Value(((TextBox) this.CalendarPicker2.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      controlsCollection.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_Wo_Id");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Size(50);
      ((ParameterObject) sObject7).set_Value((object) (((TextBox) this.txtsOrdine).Text == "" ? 0 : int.Parse(((TextBox) this.txtsOrdine).Text)));
      controlsCollection.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_ID_Servizio");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(7);
      ((ParameterObject) sObject8).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      controlsCollection.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_Status");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(8);
      ((ParameterObject) sObject9).set_Value((object) (((ListControl) this.cmbsStatus).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsStatus).SelectedValue)));
      controlsCollection.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_Richiedente");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(9);
      ((ParameterObject) sObject10).set_Size(50);
      ((ParameterObject) sObject10).set_Value((object) this.operatore1().ToString());
      controlsCollection.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_Priority");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(10);
      ((ParameterObject) sObject11).set_Value((object) (((ListControl) this.cmbsUrgenza).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsUrgenza).SelectedValue)));
      controlsCollection.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_Descrizione");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(11);
      ((ParameterObject) sObject12).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject12).set_Value((object) ((TextBox) this.txtDescrizione).Text);
      controlsCollection.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_Gruppo");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(12);
      ((ParameterObject) sObject13).set_Value((object) (((ListControl) this.cmbsGruppo).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsGruppo).SelectedValue)));
      controlsCollection.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("p_tipointerventoater");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(13);
      ((ParameterObject) sObject14).set_Value((object) (((ListControl) this.cmbsTipoIntervento).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsTipoIntervento).SelectedValue)));
      controlsCollection.Add(sObject14);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("p_datainizio");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Index(14);
      ((ParameterObject) sObject15).set_Size(10);
      ((ParameterObject) sObject15).set_Value(((TextBox) this.CalendarPicker3.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker3.Datazione).Text);
      controlsCollection.Add(sObject15);
      S_Object sObject16 = new S_Object();
      ((ParameterObject) sObject16).set_ParameterName("p_datafine");
      ((ParameterObject) sObject16).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject16).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject16).set_Index(15);
      ((ParameterObject) sObject16).set_Size(10);
      ((ParameterObject) sObject16).set_Value(((TextBox) this.CalendarPicker4.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker4.Datazione).Text);
      controlsCollection.Add(sObject16);
      S_Object sObject17 = new S_Object();
      ((ParameterObject) sObject17).set_ParameterName("p_progetto");
      ((ParameterObject) sObject17).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject17).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject17).set_Index(16);
      ((ParameterObject) sObject17).set_Size(10);
      if (this.RicercaModulo1.idProg.Value == "")
        ((ParameterObject) sObject17).set_Value((object) "");
      else
        ((ParameterObject) sObject17).set_Value((object) this.RicercaModulo1.idProg.Value);
      controlsCollection.Add(sObject17);
      return controlsCollection;
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca(false);
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      string str1 = "";
      if (this.Request["VarApp"] != null)
        str1 = "&VarApp=" + this.Request["VarApp"];
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        ImageButton control1 = (ImageButton) e.Item.Cells[2].FindControl("Imagebutton2");
        ImageButton control2 = (ImageButton) e.Item.Cells[14].FindControl("imgCostiStra");
        ImageButton control3 = (ImageButton) e.Item.Cells[1].FindControl("lnkDett");
        string str2 = "CompletaRdl.aspx?wr_id=' + DataBinder.Eval(Container.DataItem,'WR_ID')" + str1;
        string str3 = "CompletaRdl.ascx?wr_id=' + DataBinder.Eval(Container.DataItem,'WR_ID')" + str1;
        switch (e.Item.Cells[17].Text)
        {
          case "1":
            control3.Attributes.Add("CommandArgument", str3);
            control3.ToolTip = "Martino";
            break;
          case "2":
            control3.Attributes.Add("CommandArgument", str2);
            control3.ToolTip = "Papardo";
            break;
        }
        string str4 = "1";
        if (e.Item.Cells[15].Text != str4)
          control1.Visible = false;
        if (e.Item.Cells[15].Text == "4")
          control2.Visible = true;
        control3.Attributes.Add("title", "Emetti o Completa Richiesta di Lavoro");
        control1.Attributes.Add("title", "Visualizza/Modifica Richiesta di Lavoro");
        control2.Attributes.Add("title", "Costi Operativi");
        HtmlImage htmlImage1 = new HtmlImage();
        HtmlImage htmlImage2 = new HtmlImage();
        HtmlAnchor control4 = (HtmlAnchor) e.Item.Cells[3].Controls[1];
        HtmlAnchor control5 = (HtmlAnchor) e.Item.Cells[4].Controls[1];
        DataRowView dataItem = (DataRowView) e.Item.DataItem;
        if (dataItem["pdfpreventivo"] == DBNull.Value || dataItem["pdfpreventivo"].ToString() == "")
        {
          control4.HRef = "#";
          htmlImage1.Src = "../Images/no pdf_logo.gif";
          htmlImage1.Attributes.Add("title", "Nessun Pdf Preventivo");
        }
        else
        {
          control4.HRef = "javascript:openpdf('" + dataItem["WR_ID"].ToString() + "','Preventivo','" + dataItem["pdfpreventivo"].ToString().Replace("'", "`") + "');";
          htmlImage1.Src = "../Images/pdf_logo.gif";
          htmlImage1.Attributes.Add("title", "Pdf Preventivo");
        }
        htmlImage1.Style.Add("Width", "22px");
        htmlImage1.Style.Add("Height", "26px");
        htmlImage1.Style.Add("Border", "0");
        control4.Controls.Add((Control) htmlImage1);
        if (dataItem["pdfconsuntivo"] == DBNull.Value || dataItem["pdfconsuntivo"].ToString() == "")
        {
          control5.HRef = "#";
          htmlImage2.Src = "../Images/no pdf_logo.gif";
          htmlImage2.Attributes.Add("title", "Nessun Pdf Consuntivo");
        }
        else
        {
          control5.HRef = "javascript:openpdf('" + dataItem["WR_ID"].ToString() + "','Consuntivo','" + dataItem["pdfconsuntivo"].ToString().Replace("'", "`") + "');";
          htmlImage2.Src = "../Images/pdf_logo.gif";
          htmlImage2.Attributes.Add("title", "Pdf Consuntivo");
        }
        htmlImage2.Style.Add("Width", "22px");
        htmlImage2.Style.Add("Height", "26px");
        htmlImage2.Style.Add("Border", "0");
        control5.Controls.Add((Control) htmlImage2);
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
      DataTable dataTable2 = !(((ListControl) this.cmbsTipoManutenzione).SelectedValue == "3") ? this.GetWordExcel().Tables[0].Copy() : new ManCorrettivaPaging().GetSfogliaRDLExcel(this.GetData()).Copy().Tables[0].Copy();
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
      string str = "";
      if (this.Request["VarApp"] != null)
        str = "&VarApp=" + this.Request["VarApp"];
      if (e.CommandName == "Dettaglio")
      {
        string path1 = "CompletaRdl.aspx?wr_id=" + e.Item.Cells[0].Text + str;
        string path2 = "CompletaRdl.aspx?wr_id=" + e.Item.Cells[0].Text + str;
        ImageButton control = (ImageButton) e.Item.Cells[1].FindControl("lnkDett");
        this._myColl.AddControl(this.Page.Controls, ParentType.Page);
        e.CommandArgument.ToString();
        switch (e.Item.Cells[15].Text.Trim())
        {
          case "1":
          case "7":
          case "15":
            switch (e.Item.Cells[17].Text)
            {
              case "1":
                this._myColl.AddControl(this.Page.Controls, ParentType.Page);
                this.Server.Transfer(path2);
                break;
              case "2":
                this._myColl.AddControl(this.Page.Controls, ParentType.Page);
                this.Server.Transfer(path1);
                break;
            }
            break;
          default:
            switch (e.Item.Cells[17].Text)
            {
              case "1":
                this._myColl.AddControl(this.Page.Controls, ParentType.Page);
                this.Server.Transfer(path2 + "&c=true");
                break;
              case "2":
                this.Server.Transfer(path1 + "&c=true");
                break;
            }
            break;
        }
      }
      if (!(e.CommandName == "Modifica"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString() + str);
    }

    private void cmdReset_Click(object sender, EventArgs e) => this.Response.Redirect("SfogliaRdlPaging.aspx?FunID=" + this.ViewState["FunId"]);

    private void RicercaManRichiesta(bool reset)
    {
      this.DataGridRicerca.Visible = false;
      this.GridTitle1.Visible = false;
      this.DataGridRicerca2.Visible = true;
      this.Gridtitle2.Visible = true;
      RichiestaPaging richiestaPaging = new RichiestaPaging();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_campus");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.RicercaModulo1.TxtRicerca).Text);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_Wr_Id");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Value((object) (((TextBox) this.txtsRichiesta).Text == "" ? 0 : int.Parse(((TextBox) this.txtsRichiesta).Text)));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_Addetto");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Value((object) this.Addetti1.NomeCompleto);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_DataDa");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Size(10);
      ((ParameterObject) sObject5).set_Value(((TextBox) this.CalendarPicker1.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_DataA");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject6).set_Size(10);
      ((ParameterObject) sObject6).set_Value(((TextBox) this.CalendarPicker2.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_Wo_Id");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject7).set_Size(50);
      ((ParameterObject) sObject7).set_Value((object) (((TextBox) this.txtsOrdine).Text == "" ? 0 : int.Parse(((TextBox) this.txtsOrdine).Text)));
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_ID_Servizio");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject8).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_Status");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject9).set_Value((object) (((ListControl) this.cmbsStatus).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsStatus).SelectedValue)));
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_Richiedente");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject10).set_Size(50);
      ((ParameterObject) sObject10).set_Value((object) this.operatore1().ToString());
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_Priority");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject11).set_Value((object) (((ListControl) this.cmbsUrgenza).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsUrgenza).SelectedValue)));
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_Descrizione");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject12).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject12).set_Value((object) ((TextBox) this.txtDescrizione).Text);
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_Gruppo");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject13).set_Value((object) (((ListControl) this.cmbsGruppo).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsGruppo).SelectedValue)));
      CollezioneControlli.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("p_progetto");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject14).set_Size(10);
      if (this.RicercaModulo1.idProg.Value == "")
        ((ParameterObject) sObject14).set_Value((object) 0);
      else
        ((ParameterObject) sObject14).set_Value((object) this.RicercaModulo1.idProg.Value);
      CollezioneControlli.Add(sObject14);
      if (reset)
      {
        int count = richiestaPaging.GetCount(CollezioneControlli);
        this.Gridtitle2.NumeroRecords = count.ToString();
        if (count % this.DataGridRicerca2.PageSize == 0)
        {
          int num1 = count / this.DataGridRicerca2.PageSize;
        }
        else
        {
          int num2 = count / this.DataGridRicerca2.PageSize;
        }
      }
      else
        double.Parse(this.Gridtitle2.NumeroRecords);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("pageindex");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject15).set_Value((object) (this.DataGridRicerca2.CurrentPageIndex + 1));
      CollezioneControlli.Add(sObject15);
      S_Object sObject16 = new S_Object();
      ((ParameterObject) sObject16).set_ParameterName("pagesize");
      ((ParameterObject) sObject16).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject16).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject16).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject16).set_Value((object) this.DataGridRicerca.PageSize);
      CollezioneControlli.Add(sObject16);
      DataSet dataSet = richiestaPaging.GetSfogliaRDL(CollezioneControlli).Copy();
      this.DataGridRicerca2.VirtualItemCount = int.Parse(this.Gridtitle2.NumeroRecords);
      this.DataGridRicerca2.DataSource = (object) dataSet.Tables[0];
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
      ((ParameterObject) sObject10).set_Value((object) this.operatore1().ToString());
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
      return richiesta.GetSfogliaRDLExcel(CollezioneControlli).Copy();
    }

    private void DataGridRicerca2_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca2.CurrentPageIndex = e.NewPageIndex;
      this.RicercaManRichiesta(false);
    }

    private void DataGridRicerca2_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      string str1 = "";
      if (this.Request["VarApp"] != null)
        str1 = "&VarApp=" + this.Request["VarApp"];
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ImageButton control1 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton1");
      ImageButton control2 = (ImageButton) e.Item.Cells[2].FindControl("Imagebutton3");
      ImageButton control3 = (ImageButton) e.Item.Cells[14].FindControl("imgCostiRich");
      string str2 = "CompletaRdl.aspx?wr_id=' + DataBinder.Eval(Container.DataItem,'WR_ID')" + str1;
      string str3 = "CompletaRdl.aspx?wr_id=' + DataBinder.Eval(Container.DataItem,'WR_ID')" + str1;
      switch (e.Item.Cells[17].Text)
      {
        case "1":
          control1.Attributes.Add("CommandArgument", str3);
          control1.ToolTip = "Martino";
          break;
        case "2":
          control1.Attributes.Add("CommandArgument", str2);
          control1.ToolTip = "Papardo";
          break;
      }
      string str4 = "1";
      if (e.Item.Cells[15].Text != str4)
        control2.Visible = false;
      if (e.Item.Cells[15].Text == "4")
        control3.Visible = true;
      control1.Attributes.Add("title", "Emetti o Completa Richiesta di Lavoro");
      control2.Attributes.Add("title", "Visualizza/Modifica Richiesta di Lavoro");
      control3.Attributes.Add("title", "Costi Operativi");
      if (e.Item.Cells[2].Text.Trim().Length > 20)
      {
        string str5 = e.Item.Cells[2].Text.Trim().Substring(0, 18) + "...";
        e.Item.Cells[2].ToolTip = e.Item.Cells[2].Text;
        e.Item.Cells[2].Text = str5;
      }
      if (e.Item.Cells[12].Text.Trim().Length > 20)
      {
        string str5 = e.Item.Cells[12].Text.Trim().Substring(0, 18) + "...";
        e.Item.Cells[12].ToolTip = e.Item.Cells[12].Text;
        e.Item.Cells[12].Text = str5;
      }
      if (e.Item.Cells[5].Text.Trim().Length <= 12)
        return;
      string str6 = e.Item.Cells[5].Text.Trim().Substring(0, 10) + "...";
      e.Item.Cells[5].ToolTip = e.Item.Cells[5].Text;
      e.Item.Cells[5].Text = str6;
    }

    private void DataGridRicerca2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      string str1 = "";
      if (this.Request["VarApp"] != null)
        str1 = "&VarApp=" + this.Request["VarApp"];
      if (e.CommandName == "Modifica")
      {
        this._myColl.AddControl(this.Page.Controls, ParentType.Page);
        this.Server.Transfer(e.CommandArgument.ToString() + str1);
      }
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      e.CommandArgument.ToString();
      string str2 = e.Item.Cells[15].Text.Trim();
      string path1 = "CompletaRdl1.aspx?wr_id=" + e.Item.Cells[0].Text + str1;
      string path2 = "CompletaRdl1.aspx?wr_id=" + e.Item.Cells[0].Text + str1;
      switch (str2)
      {
        case "1":
        case "7":
        case "15":
          switch (e.Item.Cells[17].Text)
          {
            case "1":
              this._myColl.AddControl(this.Page.Controls, ParentType.Page);
              this.Server.Transfer(path2);
              return;
            case "2":
              this._myColl.AddControl(this.Page.Controls, ParentType.Page);
              this.Server.Transfer(path1);
              return;
            case null:
              return;
            default:
              return;
          }
        default:
          switch (e.Item.Cells[17].Text)
          {
            case "1":
              this._myColl.AddControl(this.Page.Controls, ParentType.Page);
              this.Server.Transfer(path2 + "&c=true");
              return;
            case "2":
              this.Server.Transfer(path1 + "&c=true");
              return;
            case null:
              return;
            default:
              return;
          }
      }
    }
  }
}
