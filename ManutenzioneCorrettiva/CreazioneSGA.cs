// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorrettiva.CreazioneSGA
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.AslMobile.Class;
using TheSite.Classi;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManCorrettiva;
using TheSite.Classi.ManOrdinaria;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorrettiva
{
  public class CreazioneSGA : Page
  {
    protected Label lblProgetto;
    protected DropDownList CmbProgetto;
    protected RequiredFieldValidator rfvRichiedenteNome;
    protected RequiredFieldValidator rfvRichiedenteCognome;
    protected Panel PanelRichiedente;
    protected RequiredFieldValidator rfvEdificio;
    protected TextBox txtsTelefonoRichiedente;
    protected TextBox txtsNota;
    protected RequiredFieldValidator RequiredFieldValidator1;
    protected DropDownList cmbsPiano;
    protected LinkButton lkbNonEmesse;
    protected LinkButton lnkChiudi;
    protected HtmlGenericControl pnlShowInfo;
    protected LinkButton LinkApprovate;
    protected LinkButton LinkChiudi2;
    protected HtmlGenericControl PanelEmesse;
    protected Button btsCodice;
    protected TextBox txtBL_ID;
    protected DropDownList cmbsServizio;
    protected DropDownList cmbsApparecchiatura;
    protected Panel PanelServizio;
    protected DropDownList cmbsUrgenza;
    protected TextBox txtsProblema;
    protected Panel PanelProblema;
    protected DropDownList cmbsTipoIntrevento;
    protected TextBox TxtCausa;
    protected TextBox TxtGuasto;
    protected CheckBox chksSendMail;
    protected TextBox txtsMittente;
    protected TextBox txtsorain;
    protected TextBox txtsorainmin;
    protected S_Button btnsSalva;
    protected Button cmdReset;
    protected Label lblFirstAndLast;
    protected MessagePanel PanelMess;
    protected ValidationSummary vlsEdit;
    protected RicercaModulo RicercaModulo1;
    protected PageTitle PageTitle1;
    protected CodiceApparecchiature CodiceApparecchiature1;
    protected RichiedentiSollecito RichiedentiSollecito1;
    protected UserStanze UserStanze1;
    private ClManCorrettiva _ClManCorrettiva;
    public static int FunId = 0;
    public static IDictionaryEnumerator myEnumerator = (IDictionaryEnumerator) null;
    public static string HelpLink = string.Empty;
    private SfogliaRdlPaging _fp;
    public int ItemId = 0;
    protected S_Button btnsChiudi;
    protected DataGrid DataGridRicerca;
    protected DataGrid DatagridEmesse;
    protected CalendarPicker CalendarPiker4;
    protected CalendarPicker CalendarPiker3;
    public string url = "";
    protected Panel Conduzione;
    protected Panel Sopralluogo;
    protected RequiredFieldValidator RequiredfieldvalidatorServ;
    protected RequiredFieldValidator RqStd;
    protected DropDownList cmbsTipoManutenzione;
    protected CalendarPicker CalendarPicker1;

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = new SiteModule("./ManutenzioneCorrettiva/CreazioneSGA.aspx");
      CreazioneSGA.FunId = siteModule.ModuleId;
      CreazioneSGA.HelpLink = siteModule.HelpLink;
      if (this.Request.QueryString["ItemId"] != null)
      {
        this.ItemId = int.Parse(this.Request["ItemId"]);
        this.PageTitle1.Title = "Modifica Rdl n°: " + this.ItemId.ToString();
      }
      else
        this.PageTitle1.Title = siteModule.ModuleTitle;
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindServizio);
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindApparecchiatura);
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.ValorizzaReperibilita);
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindMail);
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindPiano);
      this.RicercaModulo1.DelegatePresidio1 += new DelegatePresidio(this.BindControls);
      this.CodiceApparecchiature1.NameComboApparecchiature = "cmbsApparecchiatura";
      this.CodiceApparecchiature1.NameComboServizio = "cmbsServizio";
      this.CodiceApparecchiature1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.CodiceApparecchiature1.NameComboPiano = "cmbsPiano";
      this.UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.UserStanze1.NameComboPiano = "cmbsPiano";
      this.txtsorain.Attributes.Add("onkeypress", "SoloNumeri();");
      this.txtsorain.Attributes.Add("onpaste", "return false;");
      this.txtsorain.Attributes.Add("maxlength", "2");
      this.txtsorain.Attributes.Add("onblur", "return ControllaOra('" + this.txtsorain.ClientID + "' );");
      this.txtsorainmin.Attributes.Add("onkeypress", "SoloNumeri();");
      this.txtsorainmin.Attributes.Add("onpaste", "return false;");
      this.txtsorainmin.Attributes.Add("onblur", "return ControllaMin('" + this.txtsorainmin.ClientID + "' );");
      this.txtsorainmin.Attributes.Add("maxlength", "2");
      StringBuilder stringBuilder1 = new StringBuilder();
      stringBuilder1.Append("document.getElementById('" + this.cmbsApparecchiatura.ClientID + "').disabled = true;");
      this.cmbsServizio.Attributes.Add("onchange", stringBuilder1.ToString());
      StringBuilder stringBuilder2 = new StringBuilder();
      stringBuilder2.Append("document.getElementById('" + this.cmbsServizio.ClientID + "').disabled = true;");
      this.cmbsApparecchiatura.Attributes.Add("onchange", stringBuilder2.ToString());
      this.CmbProgetto.Attributes.Add("onchange", "setProg();");
      string script = "<script language=\"javascript\">\n" + "setProg();\n" + "</script>\n";
      if (!this.IsStartupScriptRegistered("clientScript3"))
        this.RegisterStartupScript("clientScript3", script);
      this.chksSendMail.Attributes.Add("onclick", "visibletextmail('" + this.chksSendMail.ClientID + "','" + this.txtsMittente.ClientID + "')");
      this.txtsMittente.Enabled = this.chksSendMail.Checked;
      if (!this.Page.IsPostBack)
      {
        this.BindProgetti();
        this.LoadTipoIntervento();
        this.LoadTipoManutenzione();
        if (this.Request["VarApp"] != null)
        {
          if (this.Request["VarApp"] == "1")
            this.CmbProgetto.SelectedValue = "1";
          if (this.Request["VarApp"] == "2")
            this.CmbProgetto.SelectedValue = "2";
        }
        if (this.Request.QueryString["FunId"] != null)
          this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
        this.LinkApprovate.Attributes.Add("onclick", "return ControllaBL('" + ((Control) this.RicercaModulo1.TxtCodice).ClientID + "')");
        this.lkbNonEmesse.Attributes.Add("onclick", "return ControllaBL('" + ((Control) this.RicercaModulo1.TxtCodice).ClientID + "')");
        this.btsCodice.CausesValidation = false;
        this.btsCodice.Attributes.Add("onclick", "return ControllaBL('" + ((Control) this.RicercaModulo1.TxtCodice).ClientID + "');");
        this.rfvRichiedenteNome.ControlToValidate = this.RichiedentiSollecito1.ID + ":" + ((Control) this.RichiedentiSollecito1.s_RichNome).ID;
        this.rfvRichiedenteCognome.ControlToValidate = this.RichiedentiSollecito1.ID + ":" + ((Control) this.RichiedentiSollecito1.s_RichCognome).ID;
        this.rfvEdificio.ControlToValidate = this.RicercaModulo1.ID + ":" + ((Control) this.RicercaModulo1.TxtCodice).ID;
        ((TextBox) this.RicercaModulo1.TxtCodice).Text = "";
        this.cmbsPiano.SelectedValue = "";
        this.cmbsPiano.Attributes.Add("onchange", "clearRoom();");
        ((TextBox) this.CalendarPicker1.Datazione).Text = DateTime.Now.ToShortDateString();
        this.txtsorain.Text = Convert.ToString(DateTime.Now.Hour).PadLeft(2, '0');
        this.txtsorainmin.Text = Convert.ToString(DateTime.Now.Minute).PadLeft(2, '0');
        this.CodiceApparecchiature1.Visible = false;
        ((TextBox) this.CodiceApparecchiature1.s_CodiceApparecchiatura).ReadOnly = true;
        if (this.ItemId != 0)
        {
          this.BindPiano("");
          this.BindApparecchiatura(string.Empty);
          this.BindServizio("");
          this.BindControls("");
          this.LoadDatiCreazione(this.ItemId);
          ((Control) this.btnsChiudi).Visible = true;
          if (this.Context.Handler is SfogliaRdlPaging)
          {
            this._fp = (SfogliaRdlPaging) this.Context.Handler;
            this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
            this.ViewState.Add("url", (object) this.Request.UrlReferrer.ToString());
            this.ViewState.Add("PAG", (object) "SF");
          }
          else
          {
            this.ViewState.Add("url", (object) this.Request.UrlReferrer.ToString());
            this.ViewState.Add("PAG", (object) "N");
          }
        }
        else
          ((Control) this.btnsChiudi).Visible = false;
      }
      this.SetProject();
    }

    private void SetProject()
    {
      if (this.Context.User.IsInRole("MA") && this.Context.User.IsInRole("PA"))
      {
        this.CmbProgetto.Visible = true;
        this.lblProgetto.Visible = true;
      }
      else
      {
        this.CmbProgetto.Visible = false;
        this.lblProgetto.Visible = false;
        if (this.Context.User.IsInRole("MA") && !this.Context.User.IsInRole("PA"))
        {
          this.CmbProgetto.SelectedValue = "1";
          this.RichiedentiSollecito1.Progetto = "1";
          this.RicercaModulo1.idProg.Value = "1";
        }
        if (!this.Context.User.IsInRole("MA") && this.Context.User.IsInRole("PA"))
        {
          this.CmbProgetto.SelectedValue = "2";
          this.RichiedentiSollecito1.Progetto = "2";
          this.RicercaModulo1.idProg.Value = "2";
        }
        if (this.Context.User.IsInRole("AMMINISTRATORI"))
        {
          this.CmbProgetto.Visible = true;
          this.lblProgetto.Visible = true;
        }
        if (!this.Context.User.IsInRole("callcenter"))
          return;
        this.CmbProgetto.Visible = true;
        this.lblProgetto.Visible = true;
      }
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.lkbNonEmesse.Click += new EventHandler(this.lkbNonEmesse_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.LinkApprovate.Click += new EventHandler(this.LinkApprovate_Click);
      this.LinkChiudi2.Click += new EventHandler(this.LinkChiudi2_Click);
      this.DatagridEmesse.ItemCommand += new DataGridCommandEventHandler(this.DatagridEmesse_ItemCommand);
      this.DatagridEmesse.PageIndexChanged += new DataGridPageChangedEventHandler(this.DatagridEmesse_PageIndexChanged);
      this.btsCodice.Click += new EventHandler(this.btsCodice_Click);
      this.cmbsServizio.SelectedIndexChanged += new EventHandler(this.cmbsServizio_SelectedIndexChanged);
      this.cmbsApparecchiatura.SelectedIndexChanged += new EventHandler(this.cmbsApparecchiatura_SelectedIndexChanged);
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      this.cmdReset.Click += new EventHandler(this.cmdReset_Click);
      ((Button) this.btnsChiudi).Click += new EventHandler(this.btnsChiudi_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void LoadTipoManutenzione()
    {
      this._ClManCorrettiva = new ClManCorrettiva();
      DataSet tipoManutenzione = this._ClManCorrettiva.GetTipoManutenzione();
      if (tipoManutenzione.Tables[0].Rows.Count <= 0)
        return;
      this.cmbsTipoManutenzione.DataSource = (object) tipoManutenzione.Tables[0];
      this.cmbsTipoManutenzione.DataTextField = "descrizione";
      this.cmbsTipoManutenzione.DataValueField = "id";
      this.cmbsTipoManutenzione.DataBind();
    }

    private void ValorizzaReperibilita(string CodEdificio)
    {
      if (!this.GetVerificaAddetti(CodEdificio))
        return;
      this.txtBL_ID.Text = CodEdificio;
    }

    private void LoadTipoIntervento()
    {
      this._ClManCorrettiva = new ClManCorrettiva(this.Context.User.Identity.Name);
      this.cmbsTipoIntrevento.Items.Clear();
      DataSet tipointervento = this._ClManCorrettiva.GetTipointervento();
      if (tipointervento.Tables[0].Rows.Count > 0)
      {
        this.cmbsTipoIntrevento.DataSource = (object) tipointervento.Tables[0];
        this.cmbsTipoIntrevento.DataTextField = "descrizione_breve";
        this.cmbsTipoIntrevento.DataValueField = "id";
        this.cmbsTipoIntrevento.DataBind();
      }
      else
        this.cmbsTipoIntrevento.Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Tipo Intervento -", string.Empty));
    }

    private void BindProgetti()
    {
      this.CmbProgetto.Items.Clear();
      DataSet data = new Progetti().GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        this.CmbProgetto.DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "descrizione", "id_progetto", "- Selezionare un Progetto -", "");
        this.CmbProgetto.DataTextField = "descrizione";
        this.CmbProgetto.DataValueField = "id_progetto";
        this.CmbProgetto.DataBind();
      }
      else
        this.CmbProgetto.Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Progetto  -", "-1"));
    }

    private void BindPiano(string CodEdificio)
    {
      this.cmbsPiano.Items.Clear();
      DataSet piani = new Richiesta().GetPiani(CodEdificio);
      if (piani.Tables[0].Rows.Count > 0)
      {
        this.cmbsPiano.DataSource = (object) GestoreDropDownList.ItemBlankDataSource(piani.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "");
        this.cmbsPiano.DataTextField = "DESCRIZIONE";
        this.cmbsPiano.DataValueField = "ID";
        this.cmbsPiano.DataBind();
      }
      else
        this.cmbsPiano.Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", string.Empty));
      this.cmbsPiano.Enabled = true;
      this.cmbsPiano.Attributes.Add("OnChange", "ClearApparechiature();");
    }

    private void BindControls() => this.BindControls(this.RicercaModulo1.Idbl);

    private void BindControls(string Codice)
    {
      if (Codice != "")
      {
        this.cmbsUrgenza.DataSource = (object) new Urgenza().GetPriorita(Convert.ToInt32(Codice));
        this.cmbsUrgenza.DataTextField = "DESCRIPTION";
        this.cmbsUrgenza.DataValueField = "ID";
        this.cmbsUrgenza.DataBind();
      }
      else
        this.cmbsUrgenza.Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna urgenza -", string.Empty));
    }

    private void BindMail(string Codice) => this.txtsMittente.Text = this.RicercaModulo1.Email;

    private void BindServizio(string CodEdificio)
    {
      if (this.GetVerificaBL(CodEdificio) != "0")
      {
        this.lkbNonEmesse.Text = "Richieste non Emesse per Edificio " + CodEdificio + " : " + this.GetNumeroNonEmesse(CodEdificio);
        this.LinkApprovate.Text = "Richieste Approvate per Edificio " + CodEdificio + " : " + this.GetNumeroApprovate(CodEdificio);
      }
      else
      {
        this.lkbNonEmesse.Text = "Richieste non Emesse";
        this.LinkApprovate.Text = "Richieste Approvate";
      }
      this.cmbsServizio.Items.Clear();
      this.CodiceApparecchiature1.Visible = false;
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      Servizi servizi = new Servizi(this.Context.User.Identity.Name);
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
        DataSet data = servizi.GetData(CollezioneControlli);
        if (data.Tables[0].Rows.Count > 0)
        {
          this.cmbsServizio.DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "Non Definito", "0");
          this.cmbsServizio.DataTextField = "DESCRIZIONE";
          this.cmbsServizio.DataValueField = "IDSERVIZIO";
          this.cmbsServizio.DataBind();
        }
        else
          this.cmbsServizio.Items.Add(GestoreDropDownList.ItemMessaggio("Non Definito", "0"));
        Hashtable hashtable = new Hashtable();
        for (int index = 0; index < data.Tables[0].Rows.Count; ++index)
        {
          string str1 = data.Tables[0].Rows[index]["DESCRIZIONE"].ToString();
          string str2 = data.Tables[0].Rows[index]["IDSERVIZIO"].ToString();
          hashtable.Add((object) str2, (object) str1);
        }
        CreazioneSGA.myEnumerator = hashtable.GetEnumerator();
        this.ViewState.Add("ArrServizi", (object) hashtable);
      }
      else
        this.cmbsServizio.Items.Add(GestoreDropDownList.ItemMessaggio("Non Definito", "0"));
    }

    private void BindApparecchiatura(string CodEdificio)
    {
      this.cmbsApparecchiatura.Items.Clear();
      Apparecchiature apparecchiature = new Apparecchiature(this.Context.User.Identity.Name);
      if (CodEdificio != string.Empty && this.cmbsServizio.SelectedValue != "0")
      {
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
        ((ParameterObject) sObject2).set_ParameterName("p_Servizio");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(1);
        ((ParameterObject) sObject2).set_Value((object) (this.cmbsServizio.SelectedValue == "" ? 0 : int.Parse(this.cmbsServizio.SelectedValue)));
        CollezioneControlli.Add(sObject2);
        DataSet dataSet = apparecchiature.GetDataServizi(CollezioneControlli).Copy();
        if (dataSet.Tables[0].Rows.Count > 0)
        {
          this.cmbsApparecchiatura.DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Standard -", "0");
          this.cmbsApparecchiatura.DataTextField = "DESCRIZIONE";
          this.cmbsApparecchiatura.DataValueField = "ID";
          this.cmbsApparecchiatura.DataBind();
        }
        else
          this.cmbsApparecchiatura.Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuno Standard -", "0"));
        this.cmbsApparecchiatura.Enabled = true;
      }
      else
        this.cmbsApparecchiatura.Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuno Standard -", "0"));
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      if (new Richiesta().IsValidBlId(this.RicercaModulo1.BlId))
      {
        int num = this.NuovaRichiesta();
        if (num <= 0)
          return;
        if (this.txtsMittente.Text != "" && this.chksSendMail.Checked)
        {
          string[] strArray = this.txtsMittente.Text.Split(Convert.ToChar(";"));
          ClassMail classMail = new ClassMail();
          try
          {
            foreach (string str in strArray)
            {
              classMail.Messaggio = new MailMessage()
              {
                From = ConfigurationSettings.AppSettings["MailFrom"],
                Subject = "Avviso di creazione di una richiesta di lavoro.",
                To = str.Trim(),
                BodyFormat = MailFormat.Html
              };
              classMail.Idrichiesta = num.ToString();
              classMail.Name = str.Trim();
              classMail.Decription = this.txtsProblema.Text;
              classMail.CodiceEdificio = this.RicercaModulo1.BlId + " " + this.RicercaModulo1.Nome + " Comune: " + this.RicercaModulo1.Comune;
              classMail.SendMail(ClassMail.TipoMail.MailCreazioneRichiesta);
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
        if (this.ItemId == 0)
        {
          string str = "";
          if (this.Request["VarApp"] != null)
            str = "&VarApp=" + this.Request["VarApp"];
          this.Response.Redirect("VisualizzaRdl.aspx?FunId=" + (object) CreazioneSGA.FunId + "&ItemId=" + num.ToString() + str);
        }
        else if (this.ViewState["PAG"].ToString() == "SF")
          this.Server.Transfer("SfogliaRdlPaging.aspx");
        else
          this.Response.Redirect(this.ViewState["url"].ToString());
      }
      else
        this.PanelMess.ShowError("Impossibile inserire una richiesta per l'edificio indicato", true);
    }

    private int NuovaRichiesta()
    {
      int num1 = 0;
      Richiesta richiesta = new Richiesta();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(8);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) this.RicercaModulo1.BlId);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_NomeRich");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) this.RichiedentiSollecito1.NomeCompleto);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_CognomeRich");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Value((object) this.RichiedentiSollecito1.CognomeCompleto);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_Em_Id");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Value((object) (this.RichiedentiSollecito1.NomeCompleto + (object) ' ' + this.RichiedentiSollecito1.CognomeCompleto));
      CollezioneControlli.Add(sObject4);
      int num2 = !(((ListControl) this.RichiedentiSollecito1.s_RichGruppo).SelectedValue == "") ? (int) short.Parse(((ListControl) this.RichiedentiSollecito1.s_RichGruppo).SelectedValue) : 0;
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_Gruppo");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Value((object) num2);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_phone_em");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject6).set_Size(50);
      ((ParameterObject) sObject6).set_Value((object) this.RichiedentiSollecito1.telefono);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_email_em");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject7).set_Size(50);
      ((ParameterObject) sObject7).set_Value((object) this.RichiedentiSollecito1.email);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_stanza");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject8).set_Size(50);
      ((ParameterObject) sObject8).set_Value((object) this.RichiedentiSollecito1.stanza);
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_Phone");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject9).set_Size(50);
      ((ParameterObject) sObject9).set_Value((object) this.txtsTelefonoRichiedente.Text);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_Nota_Ric");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject10).set_Size(2000);
      ((ParameterObject) sObject10).set_Value((object) this.txtsNota.Text);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_Servizio_Id");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Size(10);
      ((ParameterObject) sObject11).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject11).set_Value((object) Convert.ToInt32(this.cmbsServizio.SelectedValue));
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_Eqstd_Id");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Size(10);
      ((ParameterObject) sObject12).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject12).set_Value((object) Convert.ToInt32(this.cmbsApparecchiatura.SelectedValue));
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_Priority");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Size(10);
      ((ParameterObject) sObject13).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject13).set_Value((object) Convert.ToInt32(this.cmbsUrgenza.SelectedValue));
      CollezioneControlli.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("p_Description");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Size(2000);
      ((ParameterObject) sObject14).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject14).set_Value((object) this.txtsProblema.Text);
      CollezioneControlli.Add(sObject14);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("p_Date_Requested");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Size(10);
      ((ParameterObject) sObject15).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject15).set_Value((object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject15);
      S_Object sObject16 = new S_Object();
      ((ParameterObject) sObject16).set_ParameterName("p_Time_Requested");
      ((ParameterObject) sObject16).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject16).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject16).set_Size(11);
      ((ParameterObject) sObject16).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject16).set_Value((object) (this.txtsorain.Text + ":" + this.txtsorainmin.Text + ":00"));
      CollezioneControlli.Add(sObject16);
      S_Object sObject17 = new S_Object();
      ((ParameterObject) sObject17).set_ParameterName("p_Eq_Id");
      ((ParameterObject) sObject17).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject17).set_Direction(ParameterDirection.InputOutput);
      ((ParameterObject) sObject17).set_Size(10);
      ((ParameterObject) sObject17).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject17).set_Value((object) (this.CodiceApparecchiature1.CodiceHidden.Value == string.Empty ? 0 : Convert.ToInt32(this.CodiceApparecchiature1.CodiceHidden.Value)));
      CollezioneControlli.Add(sObject17);
      S_Object sObject18 = new S_Object();
      ((ParameterObject) sObject18).set_ParameterName("p_id_piani");
      ((ParameterObject) sObject18).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject18).set_Direction(ParameterDirection.InputOutput);
      ((ParameterObject) sObject18).set_Size(10);
      ((ParameterObject) sObject18).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject18).set_Value((object) this.cmbsPiano.SelectedValue);
      CollezioneControlli.Add(sObject18);
      S_Object sObject19 = new S_Object();
      ((ParameterObject) sObject19).set_ParameterName("p_id_stanza");
      ((ParameterObject) sObject19).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject19).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject19).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (this.UserStanze1.IdStanza != "")
        ((ParameterObject) sObject19).set_Value((object) Convert.ToInt32(this.UserStanze1.IdStanza));
      else
        ((ParameterObject) sObject19).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject19);
      S_Object sObject20 = new S_Object();
      ((ParameterObject) sObject20).set_ParameterName("p_causa");
      ((ParameterObject) sObject20).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject20).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject20).set_Size(408);
      ((ParameterObject) sObject20).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject20).set_Value((object) this.TxtCausa.Text);
      CollezioneControlli.Add(sObject20);
      S_Object sObject21 = new S_Object();
      ((ParameterObject) sObject21).set_ParameterName("p_guasto");
      ((ParameterObject) sObject21).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject21).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject21).set_Size(408);
      ((ParameterObject) sObject21).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject21).set_Value((object) this.TxtGuasto.Text);
      CollezioneControlli.Add(sObject21);
      S_Object sObject22 = new S_Object();
      ((ParameterObject) sObject22).set_ParameterName("p_tipointervento");
      ((ParameterObject) sObject22).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject22).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject22).set_Size(10);
      ((ParameterObject) sObject22).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject22).set_Value((object) Convert.ToInt32(this.cmbsTipoIntrevento.SelectedValue));
      CollezioneControlli.Add(sObject22);
      if (this.CmbProgetto.SelectedValue != "")
      {
        S_Object sObject23 = new S_Object();
        ((ParameterObject) sObject23).set_ParameterName("p_progetto");
        ((ParameterObject) sObject23).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject23).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject23).set_Size(10);
        ((ParameterObject) sObject23).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject23).set_Value((object) Convert.ToInt32(this.CmbProgetto.SelectedValue));
        CollezioneControlli.Add(sObject23);
      }
      S_Object sObject24 = new S_Object();
      ((ParameterObject) sObject24).set_ParameterName("p_tipomanutenzione");
      ((ParameterObject) sObject24).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject24).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject24).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject24).set_Value((object) int.Parse(this.cmbsTipoManutenzione.SelectedValue));
      CollezioneControlli.Add(sObject24);
      try
      {
        num1 = this.ItemId == 0 ? richiesta.Crea(CollezioneControlli) : richiesta.ModificaRDL(CollezioneControlli, this.ItemId);
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError("Errore: " + ex.Message, true);
      }
      return num1;
    }

    private void cmbsServizio_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.CodiceApparecchiature1.Visible = false;
      this.BindApparecchiatura(this.RicercaModulo1.BlId);
    }

    private void cmbsApparecchiatura_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cmbsApparecchiatura.SelectedIndex == 0)
        this.CodiceApparecchiature1.Visible = false;
      else
        this.CodiceApparecchiature1.Visible = true;
      this.CodiceApparecchiature1.CodiceApparecchiatura = "";
    }

    private void btnsChiudi_Click(object sender, EventArgs e)
    {
      if (this.ViewState["PAG"].ToString() == "SF")
        this.Server.Transfer("SfogliaRdlPaging.aspx");
      else
        this.Response.Redirect(this.ViewState["url"].ToString());
    }

    private void btsCodice_Click(object sender, EventArgs e)
    {
      if (!this.GetVerificaAddetti(((TextBox) this.RicercaModulo1.TxtCodice).Text))
      {
        ((TextBox) this.RicercaModulo1.TxtRicerca).Text = "";
        SiteJavaScript.msgBox(this.Page, "Nessun addetto per l'edificio selezionato");
      }
      else
      {
        SiteJavaScript.ShowFrameReperibiliBL(this.Page, 1);
        if (this.txtBL_ID.Text == "")
          this.txtBL_ID.Text = ((TextBox) this.RicercaModulo1.TxtCodice).Text;
        string script = "<script language=\"javascript\">\n" + "ShowFrameRep('" + this.txtBL_ID.ClientID + "','bl_id',event);" + "</script>\n";
        if (this.IsStartupScriptRegistered("clientScriptReper"))
          return;
        this.RegisterStartupScript("clientScriptReper", script);
      }
    }

    private void cmdReset_Click(object sender, EventArgs e) => this.Response.Redirect("CreazioneSGA.aspx?FunId=" + this.ViewState["FunId"]);

    private void lkbNonEmesse_Click(object sender, EventArgs e)
    {
      if (this.GetVerificaBL(((TextBox) this.RicercaModulo1.TxtCodice).Text) == "0")
      {
        this.lkbNonEmesse.Text = "Richieste non Emesse";
        this.LinkApprovate.Text = "Richieste Approvate";
        ((TextBox) this.RicercaModulo1.TxtRicerca).Text = "";
        string script = "<script language=JavaScript>alert(\"Nessuna richiesta per l'edificio selezionato\");" + "<" + "/" + "script>";
        if (this.IsClientScriptBlockRegistered("clientScriptcalendario"))
          return;
        this.RegisterStartupScript("clientScriptcalendario", script);
      }
      else
        this.RicercaNonEmesse();
    }

    private void lnkChiudi_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.pnlShowInfo.Visible = false;
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.RicercaNonEmesse();
    }

    private void RicercaNonEmesse()
    {
      string str1 = "<script language=\"javascript\">\n";
      string str2 = "</script>\n";
      ClManCorrettiva clManCorrettiva = new ClManCorrettiva();
      this.pnlShowInfo.Visible = true;
      DataSet rdlNonEmesse = clManCorrettiva.GetRDLNonEmesse(((TextBox) this.RicercaModulo1.TxtCodice).Text);
      this.DataGridRicerca.DataSource = (object) rdlNonEmesse.Tables[0];
      if (rdlNonEmesse.Tables[0].Rows.Count == 0)
      {
        this.DataGridRicerca.CurrentPageIndex = 0;
      }
      else
      {
        int num = 0;
        if (rdlNonEmesse.Tables[0].Rows.Count % this.DataGridRicerca.PageSize > 0)
          ++num;
        if (this.DataGridRicerca.PageCount != (int) Convert.ToInt16(rdlNonEmesse.Tables[0].Rows.Count / this.DataGridRicerca.PageSize + num))
          this.DataGridRicerca.CurrentPageIndex = 0;
      }
      this.DataGridRicerca.DataBind();
      this.Page.RegisterStartupScript("ss", str1 + "DivSetVisible(true);" + str2);
    }

    private void LinkApprovate_Click(object sender, EventArgs e)
    {
      if (this.GetVerificaBL(((TextBox) this.RicercaModulo1.TxtCodice).Text) == "0")
      {
        this.lkbNonEmesse.Text = "Richieste non Emesse";
        this.LinkApprovate.Text = "Richieste Approvate";
        ((TextBox) this.RicercaModulo1.TxtRicerca).Text = "";
        string script = "<script language=JavaScript>alert(\"Nessuna richiesta per l'edificio selezionato\");" + "<" + "/" + "script>";
        if (this.IsClientScriptBlockRegistered("clientScriptcalendario"))
          return;
        this.RegisterStartupScript("clientScriptcalendario", script);
      }
      else
        this.RicercaApprovate();
    }

    private void LinkChiudi2_Click(object sender, EventArgs e)
    {
      this.DatagridEmesse.CurrentPageIndex = 0;
      this.PanelEmesse.Visible = false;
    }

    private void RicercaApprovate()
    {
      string str1 = "<script language=\"javascript\">\n";
      string str2 = "</script>\n";
      ClManCorrettiva clManCorrettiva = new ClManCorrettiva();
      this.PanelEmesse.Visible = true;
      DataSet rdlApprovate = clManCorrettiva.GetRDLApprovate(((TextBox) this.RicercaModulo1.TxtCodice).Text);
      this.DatagridEmesse.DataSource = (object) rdlApprovate.Tables[0];
      if (rdlApprovate.Tables[0].Rows.Count == 0)
      {
        this.DatagridEmesse.CurrentPageIndex = 0;
      }
      else
      {
        int num = 0;
        if (rdlApprovate.Tables[0].Rows.Count % this.DatagridEmesse.PageSize > 0)
          ++num;
        if (this.DatagridEmesse.PageCount != (int) Convert.ToInt16(rdlApprovate.Tables[0].Rows.Count / this.DatagridEmesse.PageSize + num))
          this.DatagridEmesse.CurrentPageIndex = 0;
      }
      this.DatagridEmesse.DataBind();
      this.Page.RegisterStartupScript("ss", str1 + "EmesseSetVisible(true);" + str2);
    }

    private void DatagridEmesse_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DatagridEmesse.CurrentPageIndex = e.NewPageIndex;
      this.RicercaApprovate();
    }

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "NonEmesse"))
        return;
      this.Server.Transfer(e.CommandArgument.ToString());
    }

    private void DatagridEmesse_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Emesse"))
        return;
      this.Server.Transfer(e.CommandArgument.ToString());
    }

    private string GetNumeroNonEmesse(string _bl_id)
    {
      string appSetting = ConfigurationSettings.AppSettings["ConnectionString"];
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_sql");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(2000);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) (" Select count(wr.wr_id) from  wr where wr.bl_id = '" + _bl_id + "' and wr.id_wr_status in (1,15) and (wr.tipomanutenzione_id = 1 or wr.tipomanutenzione_id = 3)"));
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(appSetting);
      string str = "PACK_COMMON.SP_DYNAMIC_SELECT";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy().Tables[0].Rows[0][0].ToString();
    }

    private string GetNumeroApprovate(string _bl_id)
    {
      string appSetting = ConfigurationSettings.AppSettings["ConnectionString"];
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_sql");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(2000);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) (" Select count(wr.wr_id) from  wr where wr.bl_id = '" + _bl_id + "' and wr.id_wr_status not in (1,15) and (wr.tipomanutenzione_id = 1 or wr.tipomanutenzione_id = 3) "));
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(appSetting);
      string str = "PACK_COMMON.SP_DYNAMIC_SELECT";
      return oracleDataLayer.GetRows((object) controlsCollection, str).Copy().Tables[0].Rows[0][0].ToString();
    }

    private string GetVerificaBL(string _bl_id)
    {
      string appSetting = ConfigurationSettings.AppSettings["ConnectionString"];
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_sql");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(2000);
      ((ParameterObject) sObject1).set_Index(0);
      string str1 = "select count(wr.bl_id) from  wr where wr.bl_id = '" + _bl_id + "'";
      ((ParameterObject) sObject1).set_Value((object) str1);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      OracleDataLayer oracleDataLayer = new OracleDataLayer(appSetting);
      string str2 = "PACK_COMMON.SP_DYNAMIC_SELECT";
      return oracleDataLayer.GetRows((object) controlsCollection, str2).Copy().Tables[0].Rows[0][0].ToString();
    }

    private bool GetVerificaAddetti(string _bl_id) => new Reperibilita().GetAddettiDistinct(_bl_id).Tables[0].Rows.Count != 0;

    private void LoadDatiCreazione(int ItemId)
    {
      DataSet singleRdl = new ClassRDL(HttpContext.Current.User.ToString()).GetSingleRdl(ItemId);
      if (singleRdl.Tables[0].Rows.Count <= 0)
        return;
      DataRow row = singleRdl.Tables[0].Rows[0];
      SiteJavaScript.ShowFrameReperibiliBL(this.Page, 1);
      if (row["id_progetto"] != DBNull.Value)
        this.CmbProgetto.SelectedValue = row["id_progetto"].ToString();
      if (row["tipomanutenzione_id"] != DBNull.Value)
      {
        this.LoadTipoManutenzione();
        this.cmbsTipoManutenzione.SelectedValue = row["tipomanutenzione_id"].ToString();
      }
      if (row["sga_anomalia"].ToString().Trim() != "")
        this.TxtCausa.Text = row["sga_anomalia"].ToString();
      if (row["sga_effetto"].ToString().Trim() != "")
        this.TxtGuasto.Text = row["sga_effetto"].ToString();
      if (row["tipointervento"].ToString() != "")
      {
        this.LoadTipoIntervento();
        this.cmbsTipoIntrevento.SelectedValue = row["tipointervento"].ToString();
      }
      if (row["date_requested"].ToString().Trim() != "")
      {
        DateTime dateTime = DateTime.Parse(row["date_requested"].ToString());
        this.txtsorain.Text = dateTime.Hour.ToString().PadLeft(2, Convert.ToChar("0"));
        this.txtsorainmin.Text = dateTime.Minute.ToString().PadLeft(2, Convert.ToChar("0"));
        ((TextBox) this.CalendarPicker1.Datazione).Text = dateTime.ToShortDateString();
      }
      this.txtsNota.Text = !(row["nota"].ToString().Trim() != "") ? string.Empty : row["nota"].ToString();
      if (row["id_bl"].ToString().Trim() != "")
      {
        ((TextBox) this.RicercaModulo1.TxtCodice).Text = row["bl_id"].ToString();
        ((TextBox) this.RicercaModulo1.TxtRicerca).Text = row["fabbricato"].ToString();
        this.RicercaModulo1.LbLIdBL.Text = row["bl_id"].ToString();
        this.RicercaModulo1._txthidbl.Value = row["id_bl"].ToString();
      }
      if (row["id_piani"].ToString().Trim() != "")
        this.cmbsPiano.SelectedValue = row["id_piani"].ToString();
      else
        this.cmbsPiano.SelectedValue = "";
      this.txtsTelefonoRichiedente.Text = !(row["telefono"].ToString().Trim() != "") ? string.Empty : row["telefono"].ToString();
      this.UserStanze1.IdStanza = !(row["idstanza"].ToString().Trim() != "") ? "" : row["idstanza"].ToString();
      this.UserStanze1.DescStanza = !(row["descstanza"].ToString().Trim() != "") || !(row["descstanza"].ToString().Trim() != "-") ? "" : row["descstanza"].ToString();
      if (row["name_first"].ToString().Trim() != "")
        ((TextBox) this.RichiedentiSollecito1.s_RichNome).Text = row["name_first"].ToString();
      if (row["name_last"].ToString().Trim() != "")
        ((TextBox) this.RichiedentiSollecito1.s_RichCognome).Text = row["name_last"].ToString();
      if (row["em_phone"].ToString().Trim() != "")
        ((TextBox) this.RichiedentiSollecito1.s_telefono).Text = row["em_phone"].ToString();
      if (row["em_email"].ToString().Trim() != "")
        ((TextBox) this.RichiedentiSollecito1.s_email).Text = row["em_email"].ToString();
      if (row["em_stanza"].ToString().Trim() != "")
        ((TextBox) this.RichiedentiSollecito1.s_stanza).Text = row["em_stanza"].ToString();
      if (row["em_idgruppo"].ToString().Trim() != "")
        ((ListControl) this.RichiedentiSollecito1.s_RichGruppo).SelectedValue = row["em_idgruppo"].ToString();
      this.BindServizio(((TextBox) this.RicercaModulo1.TxtCodice).Text);
      if (row["servizio_id"].ToString().Trim() != "")
        this.cmbsServizio.SelectedValue = row["servizio_id"].ToString();
      else
        this.cmbsServizio.SelectedValue = "0";
      this.BindApparecchiatura(((TextBox) this.RicercaModulo1.TxtCodice).Text);
      if (row["eqstd_id"].ToString().Trim() != "")
      {
        this.cmbsApparecchiatura.SelectedValue = row["eqstd_id"].ToString();
        if (row["desceq"].ToString().Trim() != "")
        {
          this.CodiceApparecchiature1.Visible = true;
          ((TextBox) this.CodiceApparecchiature1.s_CodiceApparecchiatura).Text = row["desceq"].ToString();
          this.CodiceApparecchiature1.CodiceHidden.Value = row["ideq"].ToString();
        }
      }
      else
        this.cmbsApparecchiatura.SelectedValue = "0";
      this.BindControls(row["id_bl"].ToString());
      if (row["urgenza_id"].ToString().Trim() != "")
        this.cmbsUrgenza.SelectedValue = row["urgenza_id"].ToString();
      else
        this.cmbsUrgenza.SelectedValue = "";
      if (row["descrizione"].ToString().Trim() != "")
        this.txtsProblema.Text = row["descrizione"].ToString();
      else
        this.txtsProblema.Text = string.Empty;
    }
  }
}
