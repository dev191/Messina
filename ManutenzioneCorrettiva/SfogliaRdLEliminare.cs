// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorrettiva.SfogliaRdLEliminare
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
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManCorrettiva;
using TheSite.Classi.ManStraordinaria;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorrettiva
{
  public class SfogliaRdLEliminare : Page
  {
    public SiteModule _SiteModule;
    protected S_TextBox txtsRichiesta;
    protected CompareValidator CompareValidator1;
    protected S_TextBox txtsOrdine;
    protected S_ComboBox cmbsStatus;
    protected S_ComboBox cmbsServizio;
    protected S_ComboBox cmbsGruppo;
    protected S_ComboBox cmbsUrgenza;
    protected S_TextBox txtDescrizione;
    protected S_ComboBox cmbsTipoManutenzione;
    protected S_ComboBox cmbsTipoIntervento;
    protected S_Button btnsRicerca;
    protected Button cmdReset;
    protected ValidationSummary ValidationSummary1;
    protected DataGrid DataGridRicerca2;
    protected DataPanel PanelRicerca;
    protected GridTitle Gridtitle2;
    protected PageTitle PageTitle1;
    protected RicercaModulo RicercaModulo1;
    protected CalendarPicker CalendarPicker1;
    protected CalendarPicker CalendarPicker2;
    protected CalendarPicker CalendarPicker3;
    protected CalendarPicker CalendarPicker4;
    protected TheSite.WebControls.Addetti Addetti1;
    protected TheSite.WebControls.Richiedenti Richiedenti1;
    public VisualizzaRdlEliminare _fp = (VisualizzaRdlEliminare) null;
    public static string HelpLink = string.Empty;
    public static int FunId = 0;
    private clMyCollection _myColl = new clMyCollection();

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      this._SiteModule = new SiteModule("./ManutenzioneCorrettiva/SfogliaRdlEliminare.aspx");
      SfogliaRdLEliminare.FunId = this._SiteModule.ModuleId;
      SfogliaRdLEliminare.HelpLink = this._SiteModule.HelpLink;
      this.PageTitle1.Title = "SFOGLIA RDL DA ELIMINARE";
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindServizio);
      if (!this.Page.IsPostBack)
      {
        if (this.Request.QueryString["FunId"] != null)
          this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
        this.CompareValidator1.ControlToValidate = this.CalendarPicker2.ID + ":" + ((Control) this.CalendarPicker2.Datazione).ID;
        this.CompareValidator1.ControlToCompare = this.CalendarPicker1.ID + ":" + ((Control) this.CalendarPicker1.Datazione).ID;
        this.DataGridRicerca2.Visible = false;
        ((Control) this.Gridtitle2.hplsNuovo).Visible = false;
        this.Gridtitle2.Visible = false;
        this.BindServizio("");
        this.BindGruppo();
        this.BindUrgenza();
        this.BindStatus();
        this.BindTipoInterventoAter();
        this.BinTipoManutenzione();
        this.DataGridRicerca2.Visible = true;
        this.Gridtitle2.Visible = true;
        if (this.Context.Handler is VisualizzaRdlEliminare)
        {
          this._fp = (VisualizzaRdlEliminare) this.Context.Handler;
          if (this._fp != null)
          {
            this._myColl = this._fp._Contenitore;
            this._myColl.SetValues(this.Page.Controls);
            this.Ricerca(true);
          }
        }
      }
      ((Control) this.Gridtitle2.hplsNuovo).Visible = false;
    }

    private void BindServizio(string CodEdificio)
    {
      this.Gridtitle2.DescriptionTitle = "";
      this.Addetti1.Set_BL_ID(CodEdificio);
      this.DataGridRicerca2.Visible = false;
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
      DataSet guppo = new GestioneRdl(this.Context.User.Identity.Name).GetGuppo();
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
      DataSet urgenza = new GestioneRdl(this.Context.User.Identity.Name).GetUrgenza();
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
      DataSet status = new Richiesta().GetStatus();
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

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.cmdReset.Click += new EventHandler(this.cmdReset_Click);
      this.DataGridRicerca2.ItemCreated += new DataGridItemEventHandler(this.DataGridRicerca2_ItemCreated);
      this.DataGridRicerca2.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca2_ItemCommand);
      this.DataGridRicerca2.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca2_PageIndexChanged);
      this.DataGridRicerca2.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca2_ItemDataBaund);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void Ricerca(bool reset)
    {
      this.DataGridRicerca2.Visible = true;
      this.Gridtitle2.Visible = true;
      this.DataGridRicerca2.DataSource = (object) this.GetRdlDaEliminare().Tables[0];
      if (reset)
      {
        int daEliminareCount = this.GetRdlDaEliminareCount();
        this.Gridtitle2.NumeroRecords = daEliminareCount.ToString();
        if (daEliminareCount % this.DataGridRicerca2.PageSize == 0)
        {
          int num1 = daEliminareCount / this.DataGridRicerca2.PageSize;
        }
        else
        {
          int num2 = daEliminareCount / this.DataGridRicerca2.PageSize;
        }
      }
      else
        double.Parse(this.Gridtitle2.NumeroRecords);
      this.DataGridRicerca2.VirtualItemCount = int.Parse(this.Gridtitle2.NumeroRecords);
      this.DataGridRicerca2.DataBind();
    }

    private void cmdReset_Click(object sender, EventArgs e) => this.Response.Redirect("SfogliaRdlEliminare.aspx?FunID=" + this.ViewState["FunId"]);

    private DataSet GetRdlDaEliminare()
    {
      Richiesta richiesta = new Richiesta();
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
      S_Object sObject17 = new S_Object();
      ((ParameterObject) sObject17).set_ParameterName("pageindex");
      ((ParameterObject) sObject17).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject17).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject17).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject17).set_Value((object) (this.DataGridRicerca2.CurrentPageIndex + 1));
      CollezioneControlli.Add(sObject17);
      S_Object sObject18 = new S_Object();
      ((ParameterObject) sObject18).set_ParameterName("pagesize");
      ((ParameterObject) sObject18).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject18).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject18).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject18).set_Value((object) this.DataGridRicerca2.PageSize);
      CollezioneControlli.Add(sObject18);
      return richiesta.GetSfogliaRDLDaEliminare(CollezioneControlli).Copy();
    }

    private int GetRdlDaEliminareCount()
    {
      Richiesta richiesta = new Richiesta();
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
      return int.Parse(richiesta.GetSfogliaRDLDaEliminareCount(CollezioneControlli).Copy().Tables[0].Rows[0][0].ToString());
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca2.CurrentPageIndex = 0;
      this.Ricerca(true);
    }

    private void DataGridRicerca2_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca2.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca(false);
    }

    private void DataGridRicerca2_ItemCreated(object sender, DataGridItemEventArgs e)
    {
      ImageButton control = (ImageButton) e.Item.FindControl("Imagebutton3");
      if (control == null)
        return;
      e.Item.Cells[7].Text.ToString().Trim();
      control.Attributes.Add("onclick", "return confirm('Sei sicuro di voler eliminare la RdL n°?');");
    }

    private void DataGridRicerca2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Pager || e.Item.ItemType == ListItemType.Header)
        return;
      if (e.CommandName == "Dettaglio")
      {
        this._myColl.AddControl(this.Page.Controls, ParentType.Page);
        this.Server.Transfer(e.CommandArgument.ToString());
      }
      ImageButton commandSource = (ImageButton) e.CommandSource;
      if (!(commandSource.CommandName == "Delete"))
        return;
      this.DeleteItem(commandSource.CommandArgument);
    }

    private void DeleteItem(string id)
    {
      Console.WriteLine(id);
      if (id == "")
        return;
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_Wr_Id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) int.Parse(id));
      CollezioneControlli.Add(sObject);
      try
      {
        new Richiesta().DeleteRdL(CollezioneControlli);
        this.DataGridRicerca2.CurrentPageIndex = 0;
        this.Ricerca(true);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        this.Page.RegisterStartupScript("messaggio", "<script language'javascript'>alert(\"Impossibile cancellare l'apparecchiatura perchè è utilizzata in altre tabelle\");</script>");
      }
    }

    private void DataGridRicerca2_ItemDataBaund(object sender, DataGridItemEventArgs e)
    {
      ImageButton control = (ImageButton) e.Item.FindControl("Imagebutton3");
      if (control != null)
      {
        string str = "return confirm('Sei sicuro di voler eliminare la RdL n° " + e.Item.Cells[7].Text.ToString().Trim() + " ?');";
        control.Attributes.Add("onclick", str);
      }
      string str1 = e.Item.Cells[13].Text;
      e.Item.Cells[13].Attributes.Add("title", str1);
      if (str1.Length > 20)
        str1 = str1.Substring(1, 20) + "...";
      e.Item.Cells[13].Text = str1;
    }
  }
}
