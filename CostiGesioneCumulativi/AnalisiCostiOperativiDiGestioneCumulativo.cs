// Decompiled with JetBrains decompiler
// Type: TheSite.CostiGesioneCumulativi.AnalisiCostiOperativiDiGestioneCumulativo
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using CrystalDecisions.CrystalReports.Engine;
using Csy.WebControls;
using ICSharpCode.SharpZipLib.Zip;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.CostiGesioneCumulativi;
using TheSite.SchemiXSD;
using TheSite.WebControls;

namespace TheSite.CostiGesioneCumulativi
{
  public class AnalisiCostiOperativiDiGestioneCumulativo : Page
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
    protected HtmlTable tableComandi;
    private int checkTipoMan = 0;
    public static string HelpLink = string.Empty;
    public static int FunId = 0;
    private int maxOdl = 400;
    protected S_Button S_btnConfermaSel;
    protected S_Button S_btnStampa;
    protected S_Button S_btnSelezionaTutto;
    protected Label lblElementiSelezionati;
    protected Label lblMessaggio;
    protected S_Button S_btnDownLoad;
    protected S_Button S_btnDeselezioneTutto;
    protected S_Button S_btnReset;
    protected HtmlTable TableLabel;
    private clMyCollection _myColl = new clMyCollection();
    protected HtmlTable Table1;
    protected string comboTipoManutenzioneCliendiId;
    private Pagina_Download_Cumulativi _fp = (Pagina_Download_Cumulativi) null;
    private double totpreventivo = 0.0;
    private double totconsuntivo = 0.0;
    private ReportDocument crReportDocument;

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      ((WebControl) this.txtsRichiesta).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtsRichiesta).Attributes.Add("onpaste", "return nonpaste();");
      ((WebControl) this.txtsOrdine).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtsOrdine).Attributes.Add("onpaste", "return nonpaste();");
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      AnalisiCostiOperativiDiGestioneCumulativo.FunId = siteModule.ModuleId;
      AnalisiCostiOperativiDiGestioneCumulativo.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = "Rapporto Interventi Cumulativo".ToUpper();
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindServizio);
      if (!this.Page.IsPostBack)
      {
        this.Session["CheckedList"] = (object) null;
        this.Session["DatiList"] = (object) null;
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
        if (Convert.ToString(this.Session["tipoRicerca"]) == "3")
        {
          this.DataGridRicerca.Visible = true;
          this.GridTitle1.Visible = true;
          this.DataGridRicerca2.Visible = false;
          this.Gridtitle2.Visible = false;
          if (this.DataGridRicerca.Items.Count == 0)
            this.tableComandi.Visible = false;
          else
            this.tableComandi.Visible = true;
        }
        else
        {
          this.DataGridRicerca.Visible = false;
          this.GridTitle1.Visible = false;
          this.DataGridRicerca2.Visible = true;
          this.Gridtitle2.Visible = true;
          if (this.DataGridRicerca2.Items.Count == 0)
            this.tableComandi.Visible = false;
          else
            this.tableComandi.Visible = true;
        }
        if (this.Context.Handler is Pagina_Download_Cumulativi)
        {
          this._fp = (Pagina_Download_Cumulativi) this.Context.Handler;
          if (this._fp != null)
          {
            this._myColl = this._fp._Contenitore;
            this._myColl.SetValues(this.Page.Controls);
            this.Execute();
          }
        }
      }
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      ((Control) this.Gridtitle2.hplsNuovo).Visible = false;
      this.comboTipoManutenzioneCliendiId = ((ListControl) this.cmbsTipoManutenzione).SelectedValue;
    }

    private bool Execute()
    {
      this.DataGridRicerca.AllowCustomPaging = false;
      this.DataGridRicerca2.AllowCustomPaging = false;
      if (Convert.ToString(this.Session["tipoRicerca"]) == "3")
      {
        DataSet dataSet = this.RicercaSelTutti();
        this.GridTitle1.Visible = true;
        bool flag;
        if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows.Count < this.maxOdl + 1)
        {
          this.setvisiblecontrol(true);
          this.GridTitle1.DescriptionTitle = "";
          this.DataGridRicerca.DataBind();
          flag = true;
        }
        else if (dataSet.Tables[0].Rows.Count > this.maxOdl)
        {
          this.DataGridRicerca.DataBind();
          this.setvisiblecontrol(true);
          flag = false;
        }
        else
        {
          this.DataGridRicerca.DataBind();
          this.setvisiblecontrol(false);
          flag = false;
        }
        this.DataGridRicerca.DataSource = (object) dataSet;
        this.DataGridRicerca.DataBind();
        this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
        this.DataGridRicerca.AllowCustomPaging = true;
        this.DataGridRicerca2.AllowCustomPaging = true;
        return flag;
      }
      DataSet dataSet1 = this.RicercaManRichiestaSelTutti();
      this.Gridtitle2.Visible = true;
      bool flag1;
      if (dataSet1.Tables[0].Rows.Count > 0 && dataSet1.Tables[0].Rows.Count < this.maxOdl + 1)
      {
        this.setvisiblecontrol2(true);
        this.Gridtitle2.DescriptionTitle = "";
        this.DataGridRicerca2.DataBind();
        flag1 = true;
      }
      else if (dataSet1.Tables[0].Rows.Count > this.maxOdl)
      {
        this.DataGridRicerca2.DataBind();
        this.setvisiblecontrol2(true);
        flag1 = false;
      }
      else
      {
        this.DataGridRicerca2.DataBind();
        this.setvisiblecontrol2(false);
        flag1 = false;
      }
      this.DataGridRicerca2.DataSource = (object) dataSet1;
      this.DataGridRicerca2.DataBind();
      this.Gridtitle2.NumeroRecords = dataSet1.Tables[0].Rows.Count.ToString();
      this.DataGridRicerca.AllowCustomPaging = true;
      this.DataGridRicerca2.AllowCustomPaging = true;
      return flag1;
    }

    private void setvisiblecontrol(bool Visibile)
    {
      this.DataGridRicerca.Visible = true;
      this.tableComandi.Visible = true;
    }

    private void setvisiblecontrol2(bool Visibile)
    {
      this.DataGridRicerca2.Visible = true;
      this.tableComandi.Visible = true;
    }

    private void BinTipoManutenzione()
    {
      DataSet tipoManutenzione = new TheSite.Classi.ManCorrettiva.ClManCorrettiva().GetTipoManutenzione();
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
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) TheSite.Classi.GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "0");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
        ((ListControl) this.cmbsServizio).Items.Add(TheSite.Classi.GestoreDropDownList.ItemMessaggio("Non Definito", "-1"));
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(TheSite.Classi.GestoreDropDownList.ItemMessaggio("Non Definito", "-1"));
    }

    private void BindGruppo()
    {
      ((ListControl) this.cmbsGruppo).Items.Clear();
      DataSet guppo = new TheSite.Classi.ManStraordinaria.GestioneRdl(this.Context.User.Identity.Name).GetGuppo();
      if (guppo.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsGruppo).DataSource = (object) TheSite.Classi.GestoreDropDownList.ItemBlankDataSource(guppo.Tables[0], "descrizione", "richiedenti_tipo_id", "- Selezionare un Gruppo -", "");
        ((ListControl) this.cmbsGruppo).DataTextField = "descrizione";
        ((ListControl) this.cmbsGruppo).DataValueField = "richiedenti_tipo_id";
        ((Control) this.cmbsGruppo).DataBind();
      }
      else
        ((ListControl) this.cmbsGruppo).Items.Add(TheSite.Classi.GestoreDropDownList.ItemMessaggio("- Nessuna Gruppo -", string.Empty));
    }

    private void BindUrgenza()
    {
      ((ListControl) this.cmbsUrgenza).Items.Clear();
      DataSet urgenza = new TheSite.Classi.ManStraordinaria.GestioneRdl(this.Context.User.Identity.Name).GetUrgenza();
      if (urgenza.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsUrgenza).DataSource = (object) TheSite.Classi.GestoreDropDownList.ItemBlankDataSource(urgenza.Tables[0], "descrizione", "id_priority", "- Selezionare una Urgenza -", "");
        ((ListControl) this.cmbsUrgenza).DataTextField = "descrizione";
        ((ListControl) this.cmbsUrgenza).DataValueField = "id_priority";
        ((Control) this.cmbsUrgenza).DataBind();
      }
      else
        ((ListControl) this.cmbsUrgenza).Items.Add(TheSite.Classi.GestoreDropDownList.ItemMessaggio("- Nessuna Urgenza -", string.Empty));
    }

    private void BindStatus()
    {
      ((ListControl) this.cmbsStatus).Items.Clear();
      DataSet status = new TheSite.Classi.ManStraordinaria.Richiesta().GetStatus();
      if (status.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsStatus).DataSource = (object) TheSite.Classi.GestoreDropDownList.ItemBlankDataSource(status.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Stato -", "");
        ((ListControl) this.cmbsStatus).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsStatus).DataValueField = "ID";
        ((Control) this.cmbsStatus).DataBind();
      }
      else
        ((ListControl) this.cmbsStatus).Items.Add(TheSite.Classi.GestoreDropDownList.ItemMessaggio("- Nessun Stato -", string.Empty));
    }

    private void BindTipoInterventoAter()
    {
      ((ListControl) this.cmbsTipoIntervento).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet data = new TipoIntervento().GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsTipoIntervento).DataSource = (object) TheSite.Classi.GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "descrizione_breve", "ID", "- Selezionare il Tipo Intervento -", "");
        ((ListControl) this.cmbsTipoIntervento).DataTextField = "descrizione_breve";
        ((ListControl) this.cmbsTipoIntervento).DataValueField = "id";
        ((Control) this.cmbsTipoIntervento).DataBind();
      }
      else
        ((ListControl) this.cmbsTipoIntervento).Items.Add(TheSite.Classi.GestoreDropDownList.ItemMessaggio("- Nessun Tipo Intervento -", string.Empty));
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
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.DataGridRicerca2.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca2_ItemCommand);
      this.DataGridRicerca2.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca2_PageIndexChanged);
      this.DataGridRicerca2.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca2_ItemDataBound);
      ((Button) this.S_btnConfermaSel).Click += new EventHandler(this.S_btnConfermaSel_Click);
      ((Button) this.S_btnStampa).Click += new EventHandler(this.S_btnStampa_Click);
      ((Button) this.S_btnSelezionaTutto).Click += new EventHandler(this.S_btnSelezionaTutto_Click);
      ((Button) this.S_btnDeselezioneTutto).Click += new EventHandler(this.S_btnDeselezioneTutto_Click);
      ((Button) this.S_btnReset).Click += new EventHandler(this.S_btnReset_Click);
      ((Button) this.S_btnDownLoad).Click += new EventHandler(this.S_btnDownLoad_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.Session["tipoRicerca"] = (object) ((ListControl) this.cmbsTipoManutenzione).SelectedValue;
      if (((ListControl) this.cmbsTipoManutenzione).SelectedValue == "3")
      {
        this.GetControlli();
        this.Ricerca(true);
      }
      else
      {
        this.GetControlli2();
        this.RicercaManRichiesta(true);
      }
    }

    private void Ricerca(bool reset)
    {
      this.DataGridRicerca.Visible = true;
      this.GridTitle1.Visible = true;
      this.DataGridRicerca2.Visible = false;
      this.Gridtitle2.Visible = false;
      S_ControlsCollection data1 = this.GetData();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pageindex");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) data1).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) (this.DataGridRicerca.CurrentPageIndex + 1));
      data1.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pagesize");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) data1).Count + 1);
      ((ParameterObject) sObject2).set_Value((object) this.DataGridRicerca.PageSize);
      data1.Add(sObject2);
      TheSite.Classi.CostiGesioneCumulativi.Richiesta richiesta = new TheSite.Classi.CostiGesioneCumulativi.Richiesta();
      DataSet dataSet = richiesta.GetSfogliaRDLperStaordinaraPaging(data1).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.Visible = true;
      this.GridTitle1.Visible = true;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      if (reset)
      {
        S_ControlsCollection data2 = this.GetData();
        this.GridTitle1.NumeroRecords = int.Parse(richiesta.GetSfogliaRDLperStaordinaraCount(data2).Copy().Tables[0].Rows[0][0].ToString()).ToString();
      }
      if (int.Parse(this.GridTitle1.NumeroRecords) == 0)
      {
        this.DataGridRicerca.CurrentPageIndex = 0;
        this.GridTitle1.DescriptionTitle = "Nessun dato trovato.";
      }
      else if (int.Parse(this.GridTitle1.NumeroRecords) > this.maxOdl)
      {
        this.tableComandi.Visible = false;
        this.lblMessaggio.ForeColor = Color.Red;
        this.lblMessaggio.Font.Size = (FontUnit) 20;
        this.lblMessaggio.Text = "La ricerca ha fornito più di " + Convert.ToString(this.maxOdl) + " risultati. Occorre restringere i criteri di ricerca selezionando un intervallo di date più corto o ad esempio in addetto";
      }
      else
      {
        this.lblMessaggio.Text = "";
        this.lblMessaggio.Font.Size = (FontUnit) 10;
        this.lblMessaggio.ForeColor = Color.Black;
        this.tableComandi.Visible = true;
        this.CalcolaTotali(dataSet.Tables[0]);
        this.GridTitle1.DescriptionTitle = "";
      }
      this.DataGridRicerca.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.DataGridRicerca.DataBind();
    }

    private DataSet RicercaSelTutti()
    {
      this.DataGridRicerca.Visible = true;
      this.GridTitle1.Visible = true;
      this.DataGridRicerca2.Visible = false;
      this.Gridtitle2.Visible = false;
      return new TheSite.Classi.CostiGesioneCumulativi.Richiesta().GetSfogliaRDLperStaordinara(this.GetData()).Copy();
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

    private S_ControlsCollection GetData()
    {
      TheSite.Classi.CostiGesioneCumulativi.Richiesta richiesta = new TheSite.Classi.CostiGesioneCumulativi.Richiesta();
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
      ((ParameterObject) sObject10).set_Value((object) this.Richiedenti1.NomeCompleto);
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
      return controlsCollection;
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca(false);
      this.GetControlli();
    }

    private void DataGridRicerca2_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca2.CurrentPageIndex = e.NewPageIndex;
      this.RicercaManRichiesta(false);
      this.GetControlli2();
    }

    private void GetControlli()
    {
      TheSite.Classi.CostiGesioneCumulativi.clMyDataGridCollection dataGridCollection = new TheSite.Classi.CostiGesioneCumulativi.clMyDataGridCollection();
      if (this.Session["CheckedList"] == null)
        return;
      dataGridCollection.GetControl(this.DataGridRicerca, (Hashtable) this.Session["CheckedList"], this.DataGridRicerca.CurrentPageIndex);
    }

    private void GetControlli2()
    {
      TheSite.Classi.CostiGesioneCumulativi.clMyDataGridCollection dataGridCollection = new TheSite.Classi.CostiGesioneCumulativi.clMyDataGridCollection();
      if (this.Session["CheckedList"] == null)
        return;
      dataGridCollection.GetControl(this.DataGridRicerca2, (Hashtable) this.Session["CheckedList"], this.DataGridRicerca2.CurrentPageIndex);
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
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

    private void cmdReset_Click(object sender, EventArgs e) => this.Response.Redirect("AnalisiCostiOperativiDiGestioneCumulativo.aspx?FunID=" + this.ViewState["FunId"]);

    private S_ControlsCollection GetOrdinaria()
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
      ((ParameterObject) sObject10).set_Value((object) this.Richiedenti1.NomeCompleto);
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
      return controlsCollection;
    }

    private void RicercaManRichiesta(bool reset)
    {
      this.DataGridRicerca.Visible = false;
      this.GridTitle1.Visible = false;
      this.DataGridRicerca2.Visible = true;
      this.Gridtitle2.Visible = true;
      TheSite.Classi.CostiGesioneCumulativi.Richiesta richiesta = new TheSite.Classi.CostiGesioneCumulativi.Richiesta();
      S_ControlsCollection ordinaria1 = this.GetOrdinaria();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pageindex");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) ordinaria1).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) (this.DataGridRicerca2.CurrentPageIndex + 1));
      ordinaria1.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pagesize");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) ordinaria1).Count + 1);
      ((ParameterObject) sObject2).set_Value((object) this.DataGridRicerca2.PageSize);
      ordinaria1.Add(sObject2);
      this.DataGridRicerca2.DataSource = (object) richiesta.GetSfogliaRDLperOrdinariaPaging(ordinaria1).Copy().Tables[0];
      this.DataGridRicerca2.Visible = true;
      this.Gridtitle2.Visible = true;
      ((Control) this.Gridtitle2.hplsNuovo).Visible = false;
      if (reset)
      {
        S_ControlsCollection ordinaria2 = this.GetOrdinaria();
        this.Gridtitle2.NumeroRecords = richiesta.GetSfogliaRDLperOrdinariaCount(ordinaria2).ToString();
      }
      if (int.Parse(this.Gridtitle2.NumeroRecords) == 0)
      {
        this.DataGridRicerca2.CurrentPageIndex = 0;
        this.Gridtitle2.DescriptionTitle = "Nessun dato trovato.";
      }
      else if (int.Parse(this.Gridtitle2.NumeroRecords) > this.maxOdl)
      {
        this.tableComandi.Visible = false;
        this.lblMessaggio.ForeColor = Color.Red;
        this.lblMessaggio.Font.Size = (FontUnit) 20;
        this.lblMessaggio.Text = "La ricerca ha fornito più di " + Convert.ToString(this.maxOdl) + " risultati. Occorre restringere i criteri di ricerca selezionando un intervallo di date più corto o ad esempio in addetto";
      }
      else
      {
        this.lblMessaggio.Text = "";
        this.lblMessaggio.Font.Size = (FontUnit) 10;
        this.lblMessaggio.ForeColor = Color.Black;
        this.tableComandi.Visible = true;
        this.Gridtitle2.DescriptionTitle = "";
      }
      this.DataGridRicerca2.VirtualItemCount = int.Parse(this.Gridtitle2.NumeroRecords);
      this.DataGridRicerca2.DataBind();
    }

    private DataSet RicercaManRichiestaSelTutti()
    {
      this.DataGridRicerca.Visible = false;
      this.GridTitle1.Visible = false;
      this.DataGridRicerca2.Visible = true;
      this.Gridtitle2.Visible = true;
      return new TheSite.Classi.CostiGesioneCumulativi.Richiesta().GetSfogliaRDLperOrdinaria(this.GetOrdinaria()).Copy();
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
      return richiesta.GetSfogliaRDL(CollezioneControlli).Copy();
    }

    private void DataGridRicerca2_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ImageButton control = (ImageButton) e.Item.Cells[2].FindControl("Imagebutton3");
      string str1 = "1";
      if (e.Item.Cells[14].Text != str1)
        control.Visible = false;
      string str2 = "";
      string str3 = "";
      ArrayList itmTooltip = new ArrayList();
      itmTooltip.Add((object) str3);
      itmTooltip.Add((object) str2);
      if (e.Item.Cells[13].Text.Trim().Length != 0)
      {
        TheSite.Classi.Function.Tronca(e.Item.Cells[13].Text, 75, itmTooltip, 0);
        e.Item.Cells[13].ToolTip = itmTooltip[0].ToString();
        e.Item.Cells[13].Text = itmTooltip[1].ToString();
      }
      if (e.Item.Cells[2].Text.Trim().Length > 20)
      {
        string str4 = e.Item.Cells[2].Text.Trim().Substring(0, 18) + "...";
        e.Item.Cells[2].ToolTip = e.Item.Cells[2].Text;
        e.Item.Cells[2].Text = str4;
      }
      if (e.Item.Cells[12].Text.Trim().Length > 20)
      {
        string str4 = e.Item.Cells[12].Text.Trim().Substring(0, 18) + "...";
        e.Item.Cells[12].ToolTip = e.Item.Cells[12].Text;
        e.Item.Cells[12].Text = str4;
      }
      if (e.Item.Cells[5].Text.Trim().Length <= 12)
        return;
      string str5 = e.Item.Cells[5].Text.Trim().Substring(0, 10) + "...";
      e.Item.Cells[5].ToolTip = e.Item.Cells[5].Text;
      e.Item.Cells[5].Text = str5;
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

    private void S_btnConfermaSel_Click(object sender, EventArgs e)
    {
      this.lblMessaggio.Text = "";
      this.SetDati();
      this.SetControlli();
    }

    private void SetDati()
    {
      if (((ListControl) this.cmbsTipoManutenzione).SelectedValue == "3")
        this.checkTipoMan = 3;
      Hashtable hashtable = new Hashtable();
      if (this.Session["DatiList"] != null)
        hashtable = (Hashtable) this.Session["DatiList"];
      if (this.checkTipoMan == 3)
      {
        foreach (DataGridItem dataGridItem in this.DataGridRicerca.Items)
        {
          int num = int.Parse(dataGridItem.Cells[0].Text);
          CheckBox control = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
          if (hashtable.ContainsKey((object) num))
            hashtable.Remove((object) num);
          if (control.Checked)
            hashtable.Add((object) num, (object) num);
        }
      }
      else
      {
        foreach (DataGridItem dataGridItem in this.DataGridRicerca2.Items)
        {
          int num = int.Parse(dataGridItem.Cells[0].Text);
          CheckBox control = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel2");
          if (hashtable.ContainsKey((object) num))
            hashtable.Remove((object) num);
          if (control.Checked)
            hashtable.Add((object) num, (object) num);
        }
      }
      this.Session.Remove("DatiList");
      this.Session.Add("DatiList", (object) hashtable);
      this.lblElementiSelezionati.Text = "Elementi Selezionati - " + hashtable.Count.ToString() + " -";
      if (hashtable.Count > 0)
        this.EnableControl(true);
      else
        this.EnableControl(false);
    }

    private void SetDati(bool val)
    {
      Hashtable hashtable = new Hashtable();
      if (this.Session["DatiList"] != null)
        hashtable = (Hashtable) this.Session["DatiList"];
      foreach (DataGridItem dataGridItem in this.DataGridRicerca.Items)
      {
        int num = int.Parse(dataGridItem.Cells[0].Text);
        CheckBox control = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
        control.Checked = val;
        if (hashtable.ContainsKey((object) num))
          hashtable.Remove((object) num);
        if (control.Checked)
          hashtable.Add((object) num, (object) num);
      }
      this.Session.Remove("DatiList");
      this.Session.Add("DatiList", (object) hashtable);
      this.lblElementiSelezionati.Text = "Elementi Selezionati - " + hashtable.Count.ToString() + " -";
      if (hashtable.Count > 0)
        this.EnableControl(true);
      else
        this.EnableControl(false);
    }

    private void SetDati2(bool val)
    {
      Hashtable hashtable = new Hashtable();
      if (this.Session["DatiList"] != null)
        hashtable = (Hashtable) this.Session["DatiList"];
      foreach (DataGridItem dataGridItem in this.DataGridRicerca2.Items)
      {
        string text = dataGridItem.Cells[1].Text;
        int num = int.Parse(dataGridItem.Cells[0].Text);
        CheckBox control = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel2");
        control.Checked = val;
        if (hashtable.ContainsKey((object) num))
          hashtable.Remove((object) num);
        if (control.Checked)
          hashtable.Add((object) num, (object) num);
      }
      this.Session.Remove("DatiList");
      this.Session.Add("DatiList", (object) hashtable);
      this.lblElementiSelezionati.Text = "Elementi Selezionati - " + hashtable.Count.ToString() + " -";
      if (hashtable.Count > 0)
        this.EnableControl(true);
      else
        this.EnableControl(false);
    }

    private void EnableControl(bool enable) => ((WebControl) this.S_btnStampa).Enabled = enable;

    private void SetControlli()
    {
      TheSite.Classi.CostiGesioneCumulativi.clMyDataGridCollection dataGridCollection = new TheSite.Classi.CostiGesioneCumulativi.clMyDataGridCollection();
      Hashtable _HS = new Hashtable();
      if (this.Session["CheckedList"] != null)
        _HS = (Hashtable) this.Session["CheckedList"];
      if (((ListControl) this.cmbsTipoManutenzione).SelectedValue == "3")
      {
        Hashtable hashtable = dataGridCollection.SetControl(this.DataGridRicerca, _HS, this.DataGridRicerca.CurrentPageIndex);
        this.Session.Remove("CheckedList");
        this.Session.Add("CheckedList", (object) hashtable);
      }
      else
      {
        Hashtable hashtable = dataGridCollection.SetControl(this.DataGridRicerca2, _HS, this.DataGridRicerca2.CurrentPageIndex);
        this.Session.Remove("CheckedList");
        this.Session.Add("CheckedList", (object) hashtable);
      }
    }

    private void S_btnDownLoad_Click(object sender, EventArgs e)
    {
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer("Pagina_Download_Cumulativi.aspx");
    }

    private void S_btnStampa_Click(object sender, EventArgs e)
    {
      this.EnableControl(false);
      string strOdl = this.recuperaSesOdl();
      int length = strOdl.Split(',').Length;
      if (length >= 400)
      {
        this.lblMessaggio.ForeColor = Color.Red;
        this.lblMessaggio.Text = "Non possono essere selezionate più di 400 richieste di lavoro.<br>Prova ad inserire dei filtri più restrittivi.";
      }
      else
      {
        int idFile = this.insertDb(length, strOdl);
        this.lblMessaggio.ForeColor = Color.Black;
        this.lblMessaggio.Text = "Il file " + this.creaNomeFile(length, idFile) + ".pdf e' stato  creato correttamente";
      }
    }

    private string creaNomeFile(int nOdl, int idFile) => "reportRDLcomulativo" + DateTime.Now.ToString().Replace("/", "").Replace(".", "").Replace(" ", "");

    private string recuperaSesOdl()
    {
      string str1 = string.Empty;
      IDictionaryEnumerator enumerator = ((Hashtable) this.Session["DatiList"]).GetEnumerator();
      while (enumerator.MoveNext())
        str1 = str1 + enumerator.Value + ",";
      string str2 = str1.Remove(str1.Length - 1, 1);
      this.Session.Remove("DatiList");
      return str2;
    }

    private int insertDb(int nOdl, string strOdl)
    {
      string nomeFile = this.creaNomeFile(nOdl, 0);
      long num1 = this.stampaPdf(nomeFile, strOdl.Split(','));
      long num2 = this.creaZip(nomeFile);
      AgganciaDatalayer agganciaDatalayer = new AgganciaDatalayer();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      int num3 = 0;
      string str1 = !(((ListControl) this.cmbsServizio).SelectedItem.Text == "- Selezionare un Servizio -") ? ((ListControl) this.cmbsServizio).SelectedItem.Text : "tutti";
      string str2 = !(((ListControl) this.cmbsGruppo).SelectedItem.Text == "- Selezionare un Gruppo -") ? ((ListControl) this.cmbsGruppo).SelectedItem.Text : "tutti";
      string str3 = !(((ListControl) this.cmbsUrgenza).SelectedItem.Text == "- Selezionare una Urgenza -") ? ((ListControl) this.cmbsUrgenza).SelectedItem.Text : "tutte";
      string str4 = !(((ListControl) this.cmbsStatus).SelectedItem.Text == "- Selezionare uno Stato -") ? ((ListControl) this.cmbsStatus).SelectedItem.Text : "tutti";
      string str5 = "N. " + nOdl.ToString() + " Odl";
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_NOME_FILE");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      S_Object sObject2 = sObject1;
      int num4 = num3;
      int num5 = num4 + 1;
      ((ParameterObject) sObject2).set_Index(num4);
      ((ParameterObject) sObject1).set_Value((object) nomeFile);
      CollezioneControlli.Add(sObject1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("P_STRINGARDL");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      S_Object sObject4 = sObject3;
      int num6 = num5;
      int num7 = num6 + 1;
      ((ParameterObject) sObject4).set_Index(num6);
      ((ParameterObject) sObject3).set_Value((object) nOdl);
      CollezioneControlli.Add(sObject3);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("P_DATA_CREATED");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      S_Object sObject6 = sObject5;
      int num8 = num7;
      int num9 = num8 + 1;
      ((ParameterObject) sObject6).set_Index(num8);
      ((ParameterObject) sObject5).set_Value((object) DateTime.Now);
      CollezioneControlli.Add(sObject5);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("P_DATA_ASSEGNAZIONE_INIT");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(64);
      S_Object sObject8 = sObject7;
      int num10 = num9;
      int num11 = num10 + 1;
      ((ParameterObject) sObject8).set_Index(num10);
      string str6 = ((TextBox) this.CalendarPicker3.Datazione).Text == "" || ((TextBox) this.CalendarPicker3.Datazione).Text == null ? "non specificata" : ((TextBox) this.CalendarPicker3.Datazione).Text;
      ((ParameterObject) sObject7).set_Value((object) str6);
      CollezioneControlli.Add(sObject7);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("P_DATA_ASSEGNAZIONE_END");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Size(64);
      S_Object sObject10 = sObject9;
      int num12 = num11;
      int num13 = num12 + 1;
      ((ParameterObject) sObject10).set_Index(num12);
      string str7 = ((TextBox) this.CalendarPicker4.Datazione).Text == "" || ((TextBox) this.CalendarPicker4.Datazione).Text == null ? "non specificata" : ((TextBox) this.CalendarPicker4.Datazione).Text;
      ((ParameterObject) sObject9).set_Value((object) str7);
      CollezioneControlli.Add(sObject9);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("P_DATA_COMPLETAMENTO_INIT");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      S_Object sObject12 = sObject11;
      int num14 = num13;
      int num15 = num14 + 1;
      ((ParameterObject) sObject12).set_Index(num14);
      ((ParameterObject) sObject11).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject11);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("P_DATA_COMPLETAMENTO_END");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      S_Object sObject14 = sObject13;
      int num16 = num15;
      int num17 = num16 + 1;
      ((ParameterObject) sObject14).set_Index(num16);
      ((ParameterObject) sObject13).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject13);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("P_EDIFICIO");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Size(8);
      S_Object sObject16 = sObject15;
      int num18 = num17;
      int num19 = num18 + 1;
      ((ParameterObject) sObject16).set_Index(num18);
      string str8 = ((TextBox) this.RicercaModulo1.TxtCodice).Text == "" || ((TextBox) this.RicercaModulo1.TxtCodice).Text == null ? "tutti" : ((TextBox) this.RicercaModulo1.TxtCodice).Text;
      ((ParameterObject) sObject15).set_Value((object) str8);
      CollezioneControlli.Add(sObject15);
      S_Object sObject17 = new S_Object();
      ((ParameterObject) sObject17).set_ParameterName("P_RICHIESTA_DI_LAVORO");
      ((ParameterObject) sObject17).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject17).set_Direction(ParameterDirection.Input);
      S_Object sObject18 = sObject17;
      int num20 = num19;
      int num21 = num20 + 1;
      ((ParameterObject) sObject18).set_Index(num20);
      ((ParameterObject) sObject17).set_Size(256);
      string str9 = ((TextBox) this.txtsRichiesta).Text == "" || ((TextBox) this.txtsRichiesta).Text == null ? "tutte" : ((TextBox) this.txtsRichiesta).Text;
      ((ParameterObject) sObject17).set_Value((object) str9);
      CollezioneControlli.Add(sObject17);
      S_Object sObject19 = new S_Object();
      ((ParameterObject) sObject19).set_ParameterName("P_ADDETTO");
      ((ParameterObject) sObject19).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject19).set_Size(64);
      ((ParameterObject) sObject19).set_Direction(ParameterDirection.Input);
      S_Object sObject20 = sObject19;
      int num22 = num21;
      int num23 = num22 + 1;
      ((ParameterObject) sObject20).set_Index(num22);
      string str10 = this.Addetti1.NomeCompleto == "" || this.Addetti1.NomeCompleto == null ? "tutti" : this.Addetti1.NomeCompleto;
      ((ParameterObject) sObject19).set_Value((object) str10);
      CollezioneControlli.Add(sObject19);
      S_Object sObject21 = new S_Object();
      ((ParameterObject) sObject21).set_ParameterName("P_DATA_DA");
      ((ParameterObject) sObject21).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject21).set_Size(64);
      ((ParameterObject) sObject21).set_Direction(ParameterDirection.Input);
      S_Object sObject22 = sObject21;
      int num24 = num23;
      int num25 = num24 + 1;
      ((ParameterObject) sObject22).set_Index(num24);
      string str11 = ((TextBox) this.CalendarPicker1.Datazione).Text == "" || ((TextBox) this.CalendarPicker1.Datazione).Text == null ? "non specificata" : ((TextBox) this.CalendarPicker1.Datazione).Text;
      ((ParameterObject) sObject21).set_Value((object) str11);
      CollezioneControlli.Add(sObject21);
      S_Object sObject23 = new S_Object();
      ((ParameterObject) sObject23).set_ParameterName("P_DATA_A");
      ((ParameterObject) sObject23).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject23).set_Size(64);
      ((ParameterObject) sObject23).set_Direction(ParameterDirection.Input);
      S_Object sObject24 = sObject23;
      int num26 = num25;
      int num27 = num26 + 1;
      ((ParameterObject) sObject24).set_Index(num26);
      string str12 = ((TextBox) this.CalendarPicker2.Datazione).Text == "" || ((TextBox) this.CalendarPicker2.Datazione).Text == null ? "non specificata" : ((TextBox) this.CalendarPicker2.Datazione).Text;
      ((ParameterObject) sObject23).set_Value((object) str12);
      CollezioneControlli.Add(sObject23);
      S_Object sObject25 = new S_Object();
      ((ParameterObject) sObject25).set_ParameterName("P_ORDINE_LAVORO");
      ((ParameterObject) sObject25).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject25).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject25).set_Size(256);
      S_Object sObject26 = sObject25;
      int num28 = num27;
      int num29 = num28 + 1;
      ((ParameterObject) sObject26).set_Index(num28);
      string str13 = ((TextBox) this.txtsOrdine).Text == "" || ((TextBox) this.txtsOrdine).Text == null ? "tutti" : ((TextBox) this.txtsOrdine).Text;
      ((ParameterObject) sObject25).set_Value((object) str13);
      CollezioneControlli.Add(sObject25);
      S_Object sObject27 = new S_Object();
      ((ParameterObject) sObject27).set_ParameterName("P_STATO_RICHIESTA");
      ((ParameterObject) sObject27).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject27).set_Size(256);
      ((ParameterObject) sObject27).set_Direction(ParameterDirection.Input);
      S_Object sObject28 = sObject27;
      int num30 = num29;
      int num31 = num30 + 1;
      ((ParameterObject) sObject28).set_Index(num30);
      ((ParameterObject) sObject27).set_Value((object) str4);
      CollezioneControlli.Add(sObject27);
      S_Object sObject29 = new S_Object();
      ((ParameterObject) sObject29).set_ParameterName("P_SERVIZIO_ID");
      ((ParameterObject) sObject29).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject29).set_Size(256);
      ((ParameterObject) sObject29).set_Direction(ParameterDirection.Input);
      S_Object sObject30 = sObject29;
      int num32 = num31;
      int num33 = num32 + 1;
      ((ParameterObject) sObject30).set_Index(num32);
      ((ParameterObject) sObject29).set_Value((object) str1);
      CollezioneControlli.Add(sObject29);
      S_Object sObject31 = new S_Object();
      ((ParameterObject) sObject31).set_ParameterName("P_RICHIEDENTI_TIPO_ID");
      ((ParameterObject) sObject31).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject31).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject31).set_Size(256);
      S_Object sObject32 = sObject31;
      int num34 = num33;
      int num35 = num34 + 1;
      ((ParameterObject) sObject32).set_Index(num34);
      ((ParameterObject) sObject31).set_Value((object) str2);
      CollezioneControlli.Add(sObject31);
      S_Object sObject33 = new S_Object();
      ((ParameterObject) sObject33).set_ParameterName("P_EM_ID");
      ((ParameterObject) sObject33).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject33).set_Size(256);
      ((ParameterObject) sObject33).set_Direction(ParameterDirection.Input);
      S_Object sObject34 = sObject33;
      int num36 = num35;
      int num37 = num36 + 1;
      ((ParameterObject) sObject34).set_Index(num36);
      string str14 = this.Richiedenti1.NomeCompleto == "" || this.Richiedenti1.NomeCompleto == null ? "tutti" : this.Richiedenti1.NomeCompleto;
      ((ParameterObject) sObject33).set_Value((object) str14);
      CollezioneControlli.Add(sObject33);
      S_Object sObject35 = new S_Object();
      ((ParameterObject) sObject35).set_ParameterName("P_ID_PRIORITY");
      ((ParameterObject) sObject35).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject35).set_Size(256);
      ((ParameterObject) sObject35).set_Direction(ParameterDirection.Input);
      S_Object sObject36 = sObject35;
      int num38 = num37;
      int num39 = num38 + 1;
      ((ParameterObject) sObject36).set_Index(num38);
      ((ParameterObject) sObject35).set_Value((object) str3);
      CollezioneControlli.Add(sObject35);
      S_Object sObject37 = new S_Object();
      ((ParameterObject) sObject37).set_ParameterName("P_DESCRIZIONE");
      ((ParameterObject) sObject37).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject37).set_Size(256);
      ((ParameterObject) sObject37).set_Direction(ParameterDirection.Input);
      S_Object sObject38 = sObject37;
      int num40 = num39;
      int num41 = num40 + 1;
      ((ParameterObject) sObject38).set_Index(num40);
      ((ParameterObject) sObject37).set_Value((object) ((TextBox) this.txtDescrizione).Text);
      CollezioneControlli.Add(sObject37);
      S_Object sObject39 = new S_Object();
      ((ParameterObject) sObject39).set_ParameterName("P_TIPOMANUTENZIONE_ID");
      ((ParameterObject) sObject39).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject37).set_Size(256);
      ((ParameterObject) sObject39).set_Direction(ParameterDirection.Input);
      S_Object sObject40 = sObject39;
      int num42 = num41;
      int num43 = num42 + 1;
      ((ParameterObject) sObject40).set_Index(num42);
      ((ParameterObject) sObject39).set_Value((object) ((ListControl) this.cmbsTipoManutenzione).SelectedItem.Text);
      CollezioneControlli.Add(sObject39);
      S_Object sObject41 = new S_Object();
      ((ParameterObject) sObject41).set_ParameterName("P_DIMENSIONE_FILE");
      ((ParameterObject) sObject41).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject41).set_Direction(ParameterDirection.Input);
      S_Object sObject42 = sObject41;
      int num44 = num43;
      int num45 = num44 + 1;
      ((ParameterObject) sObject42).set_Index(num44);
      ((ParameterObject) sObject41).set_Value((object) num1);
      CollezioneControlli.Add(sObject41);
      S_Object sObject43 = new S_Object();
      ((ParameterObject) sObject43).set_ParameterName("P_DIMENSIONE_FILE_ZIP");
      ((ParameterObject) sObject43).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject43).set_Direction(ParameterDirection.Input);
      S_Object sObject44 = sObject43;
      int num46 = num45;
      int num47 = num46 + 1;
      ((ParameterObject) sObject44).set_Index(num46);
      ((ParameterObject) sObject43).set_Value((object) num2);
      CollezioneControlli.Add(sObject43);
      S_Object sObject45 = new S_Object();
      ((ParameterObject) sObject45).set_ParameterName("P_TIPOLOGIA_REPORT");
      ((ParameterObject) sObject45).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject45).set_Direction(ParameterDirection.Input);
      S_Object sObject46 = sObject45;
      int num48 = num47;
      int num49 = num48 + 1;
      ((ParameterObject) sObject46).set_Index(num48);
      ((ParameterObject) sObject45).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject45);
      S_Object sObject47 = new S_Object();
      ((ParameterObject) sObject47).set_ParameterName("p_DIMENSIONEFILE_PDF_ZIP");
      ((ParameterObject) sObject47).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject47).set_Direction(ParameterDirection.Input);
      S_Object sObject48 = sObject47;
      int num50 = num49;
      int num51 = num50 + 1;
      ((ParameterObject) sObject48).set_Index(num50);
      ((ParameterObject) sObject47).set_Value((object) 0);
      CollezioneControlli.Add(sObject47);
      agganciaDatalayer.NameProcedureDb = "pack_CostiGestioneCumulativi.UpdAnalisiCostiOperativi";
      return agganciaDatalayer.Add(CollezioneControlli);
    }

    private long stampaPdf(string nomeFile, string[] arOdl)
    {
      CostiOperativiCumulativo operativiCumulativo = new CostiOperativiCumulativo("");
      this.crReportDocument = new ReportDocument();
      this.crReportDocument.Load(this.Server.MapPath("../Report/RptTecnicoIntervento2Cumulativo.rpt"));
      dsRapportino dsRapportino = operativiCumulativo.ImpostaRpt(arOdl);
      dsRapportino.GetXml();
      this.crReportDocument.SetDataSource((object) dsRapportino);
      string appSetting = ConfigurationSettings.AppSettings["DirectoryStampaCostoGestione"];
      new StampaSuDisco(this.Server.MapPath(appSetting)).StampaPdf(this.crReportDocument, nomeFile);
      return new FileInfo(this.Server.MapPath(appSetting) + nomeFile + ".pdf").Length;
    }

    private long creaZip(string nomeFile)
    {
      string appSetting = ConfigurationSettings.AppSettings["DirectoryStampaCostoGestione"];
      string str = nomeFile + ".pdf";
      string fileName = this.Server.MapPath(appSetting) + nomeFile + ".zip";
      new FastZip().CreateZip(fileName, this.Server.MapPath(appSetting), true, str);
      return new FileInfo(fileName).Length;
    }

    private void S_btnSelezionaTutto_Click(object sender, EventArgs e) => this.SelezionaTutti(true);

    private void S_btnDeselezioneTutto_Click(object sender, EventArgs e) => this.SelezionaTutti(false);

    private void S_btnReset_Click(object sender, EventArgs e) => this.Response.Redirect("AnalisiCostiOperativiDiGestioneCumulativo.aspx");

    private void SelezionaTutti(bool val)
    {
      this.DataGridRicerca.AllowCustomPaging = false;
      this.DataGridRicerca2.AllowCustomPaging = false;
      if (((ListControl) this.cmbsTipoManutenzione).SelectedValue == "3")
      {
        DataSet dataSet = this.RicercaSelTutti();
        if (!val)
        {
          this.Session.Remove("CheckedList");
          this.Session.Remove("DatiList");
          this.lblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
          this.EnableControl(false);
        }
        else
          this.SetControlli();
        for (int index = 0; index <= this.DataGridRicerca.PageCount; ++index)
        {
          int count = dataSet.Tables[0].Rows.Count;
          this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
          this.DataGridRicerca.DataBind();
          this.DataGridRicerca.CurrentPageIndex = index;
          this.SetDati(val);
          if (val)
            this.SetControlli();
        }
        this.DataGridRicerca.CurrentPageIndex = 0;
        this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
        this.DataGridRicerca.DataBind();
        this.GetControlli();
      }
      else
      {
        DataSet dataSet = this.RicercaManRichiestaSelTutti();
        if (!val)
        {
          this.Session.Remove("CheckedList");
          this.Session.Remove("DatiList");
          this.lblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
          this.EnableControl(false);
        }
        else
          this.SetControlli();
        for (int index = 0; index <= this.DataGridRicerca2.PageCount; ++index)
        {
          int count = dataSet.Tables[0].Rows.Count;
          this.DataGridRicerca2.DataSource = (object) dataSet.Tables[0];
          this.DataGridRicerca2.DataBind();
          this.DataGridRicerca2.CurrentPageIndex = index;
          this.SetDati2(val);
          if (val)
            this.SetControlli();
        }
        this.DataGridRicerca2.CurrentPageIndex = 0;
        this.DataGridRicerca2.DataSource = (object) dataSet.Tables[0];
        this.DataGridRicerca2.DataBind();
        this.GetControlli2();
      }
      this.DataGridRicerca.AllowCustomPaging = true;
      this.DataGridRicerca2.AllowCustomPaging = true;
    }
  }
}
