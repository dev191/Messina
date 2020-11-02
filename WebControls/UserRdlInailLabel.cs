// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.UserRdlInailLabel
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
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ManCorrettiva;
using TheSite.Classi.ManStraordinaria;

namespace TheSite.WebControls
{
  public class UserRdlInailLabel : UserControl
  {
    protected Label lblNote;
    protected Label lblTelefono;
    protected TextBox txtHidBl;
    protected Label lblfabbricato;
    protected Label lblstanzaric;
    protected Label lblemailric;
    protected Label lblOraRichiesta;
    protected Label lblGruppo;
    protected Label lblDataRichiesta;
    protected Label lbltelefonoric;
    protected Label lblOperatore;
    protected Label lblRichiedente;
    protected Label LblRdl;
    protected Label lblOperazione;
    protected MessagePanel PanelMess;
    protected S_Label lbldatavalidDCSIT;
    protected S_Label lblOraValidDCSIT;
    protected S_Label lblUtenteDCSIT;
    protected S_Label lblStatoDCSIT;
    protected S_Label lblDataValidDL;
    protected S_Label lblOraValidDL;
    protected S_Label lblUtenteDL;
    protected S_Label lblStatoDL;
    protected DataPanel Datapanel4;
    protected HtmlTable Tableordine;
    protected HtmlTableRow preventivo1;
    protected HtmlTableRow preventivo2;
    protected S_HyperLink LinkConsuntivo;
    protected Label lblconsuntivo;
    protected S_ComboBox cmbsstatolavoro;
    protected HtmlTableRow trnote;
    protected HtmlTable Tablecompletamento;
    protected HtmlTableRow trconsuntivo1;
    protected HtmlTableRow trconsuntivo2;
    protected HtmlTableRow trannocontab;
    protected HtmlTableRow trconsuntivo3;
    protected HtmlTableRow trsoddisfazione;
    protected HtmlTableRow trannotazione;
    protected DataPanel PanelGeneral;
    protected DataPanel PanelDCSIT;
    protected DataPanel PanelDL;
    protected DataPanel PanelCofatec;
    protected DataPanel PanelCompleta;
    protected Label lblPiano;
    protected Label lblStanza;
    private ClManCorrettiva _ClManCorrettiva;
    private Richiesta _Richiesta;
    protected Button btnHelp;
    protected HtmlTable TableCompleta;
    protected S_Button btnfoglioprestazioni;
    protected HtmlTableRow tipointervento0;
    protected HtmlTableRow tipointervento1;
    protected HtmlTableRow tipointervento2;
    protected S_Label lblPreventivo;
    protected S_HyperLink LinkPreventivo;
    protected Label LblMessaggio;
    protected HtmlTableRow preventivo3;
    protected S_CheckBox checkQuantifica;
    protected RadioButton RadioButton1;
    protected RadioButton RadioButton2;
    protected RadioButton RadioButton3;
    protected RadioButton RadioButton4;
    protected RadioButtonList RadioButtonList1;
    private int wr_id = 0;
    protected VisualizzaSolleciti VisualizzaSolleciti1;
    protected S_TextBox txtsAnnotazioni;
    protected Label lblServizio;
    protected Label lblStandardApp;
    protected Label lblApparecchiatura;
    protected Label lblTipoManutenzione;
    protected Label lblUrgenza;
    protected Label lblTrasmissione;
    protected Label lblDitta;
    protected Label lblDataPrevistaInizio;
    protected S_Button btnChiudicompleta;
    protected Label lblDataPrevistaFine;
    protected Label lblOrdineLavoroFSL;
    protected Label lblTipoIntervento;
    protected Label lblSpesaPresunta;
    protected Label lblOrdineLavoro;
    protected Label lblAddetto;
    protected Label lblDataPianificata;
    protected Label lblOreMinuti;
    protected Label lblNumPreventivo;
    protected Label lblStatoLavoro;
    protected Label lblSospesa;
    protected Label lblDataInizio;
    protected Label lblOreMinutiInizio;
    protected Label lblDataFine;
    protected Label lblOreMinutiFine;
    protected Label lblImpCons;
    protected Label lblContabilizzazione;
    protected Label lblAnno;
    protected Label lblImportoPreventivo;
    protected Label lblAnnotazioni;
    protected Label lblDescrizione;
    protected S_Button BtnElimina;
    public SiteModule _SiteModule;
    protected PageTitle PageTitle1;
    private Type myType;
    public static string HelpLink = string.Empty;
    public static int FunId = 0;
    private clMyCollection _myColl = new clMyCollection();

    private int bl_id
    {
      get => this.ViewState[nameof (bl_id)] != null ? Convert.ToInt32(this.ViewState[nameof (bl_id)]) : 0;
      set => this.ViewState[nameof (bl_id)] = (object) value;
    }

    private int dcsit_id
    {
      get => this.ViewState[nameof (dcsit_id)] != null ? Convert.ToInt32(this.ViewState[nameof (dcsit_id)]) : 0;
      set => this.ViewState[nameof (dcsit_id)] = (object) value;
    }

    private int dl_id
    {
      get => this.ViewState[nameof (dl_id)] != null ? Convert.ToInt32(this.ViewState[nameof (dl_id)]) : 0;
      set => this.ViewState[nameof (dl_id)] = (object) value;
    }

    private bool IsCompleta => this.Request["c"] != null;

    private void Page_Load(object sender, EventArgs e)
    {
      ((WebControl) this.BtnElimina).Attributes.Add("onclick", "return confirm('Sei sicuro di voler eliminare la RdL n° " + this.Request["wr_id"].ToString().Trim() + " ?');");
      this.myType = this.Page.GetType();
      this.myType.GetField("_SiteModule");
      this._SiteModule = new SiteModule("./ManutenzioneCorrettiva/SfogliaRdlPaging.aspx");
      UserRdlInailLabel.FunId = this._SiteModule.ModuleId;
      UserRdlInailLabel.HelpLink = this._SiteModule.HelpLink;
      this.PageTitle1.Title = this._SiteModule.ModuleTitle;
      this.PageTitle1.Title = "VISUALIZA RDL DA ELIMINARE";
      if (this.Request["wr_id"] != null)
        this.wr_id = int.Parse(this.Request["wr_id"]);
      this._ClManCorrettiva = new ClManCorrettiva(this.Context.User.Identity.Name);
      this._Richiesta = new Richiesta();
      if (this.IsPostBack)
        return;
      this.LoadDatiCreazione();
    }

    private void LoadDatiCreazione()
    {
      DataSet singleRdlLabel = this._Richiesta.GetSingleRdlLabel(this.wr_id);
      if (singleRdlLabel.Tables[0].Rows.Count <= 0)
        return;
      DataRow row1 = singleRdlLabel.Tables[0].Rows[0];
      this.bl_id = int.Parse(row1["id_bl"].ToString());
      if (row1["id"] != DBNull.Value)
        this.LblRdl.Text = row1["ID"].ToString();
      this.VisualizzaSolleciti1.TxtID_WR = row1["id"].ToString();
      this.lblOrdineLavoro.Text = row1["wo_id"] == DBNull.Value ? " - - - " : row1["wo_id"].ToString().Trim();
      this.txtHidBl.Text = row1["codicebl"].ToString();
      this.lblTrasmissione.Text = row1["trasmissionedesc"] == DBNull.Value ? " - - - " : row1["trasmissionedesc"].ToString().Trim();
      this.lblRichiedente.Text = row1["richiedente"] == DBNull.Value ? " - - - " : row1["richiedente"].ToString().Trim();
      this.lblOperatore.Text = row1["operatore"] == DBNull.Value ? " - - - " : row1["operatore"].ToString().Trim();
      this.lbltelefonoric.Text = row1["telefonoric"] == DBNull.Value ? " - - - " : row1["telefonoric"].ToString().Trim();
      this.lblemailric.Text = row1["emailric"] == DBNull.Value ? " - - - " : row1["emailric"].ToString().Trim();
      this.lblstanzaric.Text = row1["stanzaric"] == DBNull.Value ? " - - - " : row1["stanzaric"].ToString().Trim();
      this.lblTelefono.Text = row1["telefono"] == DBNull.Value ? " - - - " : row1["telefono"].ToString().Trim();
      if (row1["dataRichiesta"] != DBNull.Value)
        this.lblDataRichiesta.Text = DateTime.Parse(row1["dataRichiesta"].ToString()).ToShortDateString();
      if (row1["dataRichiesta"] != DBNull.Value)
        this.lblOraRichiesta.Text = DateTime.Parse(row1["dataRichiesta"].ToString()).ToShortTimeString();
      this.lblGruppo.Text = row1["gruppo"] == DBNull.Value ? " - - - " : row1["gruppo"].ToString().Trim();
      this.lblfabbricato.Text = row1["fabbricato"] == DBNull.Value ? " - - - " : row1["fabbricato"].ToString().Trim();
      this.lblStanza.Text = !(row1["stanza"].ToString().Trim() != string.Empty) ? " - - - " : row1["stanza"].ToString().Trim();
      this.lblPiano.Text = row1["piano"] == DBNull.Value ? " - - - " : row1["piano"].ToString().Trim();
      this.lblNote.Text = row1["nota"] == DBNull.Value ? " - - - " : row1["nota"].ToString().Trim();
      this.lblServizio.Text = row1["servizioDesc"].ToString().Trim() != string.Empty || row1["servizioDesc"] != DBNull.Value ? (!(row1["servizioDesc"].ToString().Trim() != "-") ? " - - - " : row1["servizioDesc"].ToString().Trim()) : " - - - ";
      this.lblStandardApp.Text = row1["standardApp"] == DBNull.Value ? " - - - " : row1["standardApp"].ToString().Trim();
      this.lblApparecchiatura.Text = row1["id_eq"] == DBNull.Value ? " - - - " : row1["id_eq"].ToString().Trim();
      this.lblDescrizione.Text = row1["descrizione"] == DBNull.Value ? " - - - " : row1["descrizione"].ToString().Trim();
      this.lblDitta.Text = row1["dittaDesc"] == DBNull.Value ? " - - - " : row1["dittaDesc"].ToString().Trim();
      this.lblAddetto.Text = row1["adettoNominativo"] == DBNull.Value ? " - - - " : (!(row1["adettoNominativo"].ToString().Trim() != string.Empty) ? " - - - " : row1["adettoNominativo"].ToString().Trim());
      this.lblDataPianificata.Text = row1["datapianificata"] == DBNull.Value ? " - - - " : DateTime.Parse(row1["datapianificata"].ToString()).ToShortDateString().Trim();
      this.lblOreMinuti.Text = "00:00";
      if (row1["datapianificata"] != DBNull.Value)
      {
        DateTime dateTime = DateTime.Parse(row1["datapianificata"].ToString());
        string str1 = dateTime.Hour.ToString();
        string str2 = dateTime.Minute.ToString();
        if (str1.Length == 1)
          str1 = "0" + str1;
        if (str2.Length == 1)
          str2 = "0" + str2;
        this.lblOreMinuti.Text = str1 + ":" + str2;
      }
      this.lblNumPreventivo.Text = row1["numeropreventivo"] == DBNull.Value ? " - - - " : row1["numeropreventivo"].ToString();
      this.lblTipoManutenzione.Text = row1["tipointervento"] == DBNull.Value ? " - - - " : (!(row1["tipointervento"].ToString() == "3") ? "Manutenzione richiesta" : "Manutenzione Straordinaria");
      this.lblUrgenza.Text = row1["prioritaDesc"] == DBNull.Value ? " - - - " : row1["prioritaDesc"].ToString().Trim();
      DataSet statusRdl = this._ClManCorrettiva.GetStatusRdl(this.wr_id);
      if (statusRdl.Tables[0].Rows.Count > 0)
      {
        DataRow row2 = statusRdl.Tables[0].Rows[0];
        this.LblMessaggio.Text = "Stato della Richiesta di Lavoro : " + row2["descrizione"].ToString() + " in data: " + row2["data"];
      }
      if (row1["id_dl"] != DBNull.Value)
        this.dl_id = Convert.ToInt32(row1["id_dl"]);
      if (row1["utente_dl"] != DBNull.Value)
        ((Label) this.lblUtenteDL).Text = row1["utente_dl"].ToString().Trim();
      else
        ((Label) this.lblUtenteDL).Text = " - - - ";
      if (row1["data_validazione_dl"] != DBNull.Value)
      {
        DateTime dateTime = DateTime.Parse(row1["data_validazione_dl"].ToString());
        ((Label) this.lblDataValidDL).Text = dateTime.ToShortDateString();
        ((Label) this.lblOraValidDL).Text = dateTime.Hour.ToString().PadLeft(2, '0') + ":" + dateTime.Minute.ToString().PadLeft(2, '0');
      }
      else
        ((Label) this.lblOraValidDL).Text = " - - - ";
      if (row1["lavori_urgenti_dl"] != DBNull.Value)
        ((CheckBox) this.checkQuantifica).Checked = Convert.ToInt32(row1["lavori_urgenti_dl"]) != 0;
      if (row1["stato_dl"] != DBNull.Value)
        ((Label) this.lblStatoDL).Text = row1["stato_dl"].ToString().Trim();
      else
        ((Label) this.lblStatoDL).Text = " - - - ";
      this.lblTipoIntervento.Text = row1["tipointerventoDesc"] == DBNull.Value ? " - - - " : row1["tipointerventoDesc"].ToString().Trim();
      this.lblSpesaPresunta.Text = "0,00";
      if (row1["SPESA_PRESUNTA"] != DBNull.Value)
        this.lblSpesaPresunta.Text = TheSite.Classi.Function.GetTypeNumber(row1["SPESA_PRESUNTA"], NumberType.Intero).ToString() + TheSite.Classi.Function.GetTypeNumber(row1["SPESA_PRESUNTA"], NumberType.Decimale).ToString();
      this.lblDataPrevistaInizio.Text = row1["datainizio"] == DBNull.Value ? " - - - " : DateTime.Parse(row1["datainizio"].ToString()).ToShortDateString().Trim();
      this.lblDataPrevistaFine.Text = row1["datafine"] == DBNull.Value ? " - - - " : DateTime.Parse(row1["datafine"].ToString()).ToShortDateString().Trim();
      this.lblOrdineLavoroFSL.Text = row1["ordine_lavoro"] == DBNull.Value ? " - - - " : row1["ordine_lavoro"].ToString().Trim();
      if (row1["id_dcsit"] != DBNull.Value)
        this.dcsit_id = Convert.ToInt32(row1["id_dcsit"]);
      if (row1["utente_dcsit"] != DBNull.Value)
        ((Label) this.lblUtenteDCSIT).Text = row1["utente_dcsit"].ToString();
      else
        ((Label) this.lblUtenteDCSIT).Text = " - - - ";
      if (row1["data_validazione_dcsit"] != DBNull.Value)
      {
        DateTime dateTime = DateTime.Parse(row1["data_validazione_dcsit"].ToString());
        ((Label) this.lbldatavalidDCSIT).Text = dateTime.ToShortDateString();
        ((Label) this.lblOraValidDCSIT).Text = dateTime.Hour.ToString().PadLeft(2, '0') + ":" + dateTime.Minute.ToString().PadLeft(2, '0');
      }
      else
      {
        ((Label) this.lbldatavalidDCSIT).Text = " - - - ";
        ((Label) this.lblOraValidDCSIT).Text = " - - - ";
      }
      if (row1["stato_dcsit"] != DBNull.Value)
        ((Label) this.lblStatoDCSIT).Text = row1["stato_dcsit"].ToString().Trim();
      else
        ((Label) this.lblStatoDCSIT).Text = " - - - ";
      this.lblStatoLavoro.Text = row1["stato_descrizione_estesa"] == DBNull.Value ? " - - - " : row1["stato_descrizione_estesa"].ToString().Trim();
      this.lblSospesa.Text = row1["notesospesa"] == DBNull.Value ? " - - - " : row1["notesospesa"].ToString().Trim();
      this.lblDataInizio.Text = row1["date_start"] == DBNull.Value ? " - - - " : DateTime.Parse(row1["date_start"].ToString()).ToShortDateString().Trim();
      this.lblDataFine.Text = row1["date_end"] == DBNull.Value ? " - - - " : DateTime.Parse(row1["date_end"].ToString()).ToShortDateString().Trim();
      this.lblOreMinutiInizio.Text = "00:00";
      if (row1["date_start"] != DBNull.Value)
      {
        DateTime dateTime = DateTime.Parse(row1["date_start"].ToString());
        string str1 = dateTime.Hour.ToString();
        string str2 = dateTime.Minute.ToString();
        if (str1.Length == 1)
          str1 = "0" + str1;
        if (str2.Length == 1)
          str2 = "0" + str2;
        this.lblOreMinutiInizio.Text = str1 + ":" + str2;
      }
      this.lblOreMinutiFine.Text = "00:00";
      if (row1["date_end"] != DBNull.Value)
      {
        DateTime dateTime = DateTime.Parse(row1["date_end"].ToString());
        this.lblOreMinutiFine.Text = dateTime.ToString() + " : " + dateTime.Minute.ToString().PadLeft(2, Convert.ToChar("0")).Trim();
        string str1 = dateTime.Hour.ToString();
        string str2 = dateTime.Minute.ToString();
        if (str1.Length == 1)
          str1 = "0" + str1;
        if (str2.Length == 1)
          str2 = "0" + str2;
        this.lblOreMinutiFine.Text = str1 + ":" + str2;
      }
      this.lblAnnotazioni.Text = row1["comments"] == DBNull.Value ? " - - - " : row1["comments"].ToString().Trim();
      if (row1["satisfaction_id"] != DBNull.Value)
        this.RadioButtonList1.SelectedValue = row1["satisfaction_id"].ToString();
      this.lblImportoPreventivo.Text = row1["impPreventivo"] == DBNull.Value ? "€ 0,00" : row1["impPreventivo"].ToString().Trim();
      this.lblContabilizzazione.Text = row1["contabilizzazione"] == DBNull.Value ? " - - - " : row1["contabilizzazione"].ToString().Trim();
      this.lblImpCons.Text = row1["importoconsuntivo"] == DBNull.Value ? " - - - " : TheSite.Classi.Function.GetTypeNumber(row1["importoconsuntivo"], NumberType.Intero) + "," + TheSite.Classi.Function.GetTypeNumber(row1["importoconsuntivo"], NumberType.Decimale);
      this.lblAnno.Text = DateTime.Now.Year.ToString();
      if (row1["idstatus"] != DBNull.Value)
      {
        if (row1["idstatus"].ToString().Trim() == "4")
          ((Control) this.PanelCompleta).Visible = true;
        else
          ((Control) this.PanelCompleta).Visible = false;
      }
      else
        ((Control) this.PanelCompleta).Visible = false;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.BtnElimina).Click += new EventHandler(this.BtnElimina_Click);
      ((Button) this.btnChiudicompleta).Click += new EventHandler(this.btnChiudicompleta_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnChiudicompleta_Click(object sender, EventArgs e) => this.Server.Transfer("SfogliaRdlEliminare.aspx?FunId=" + this.ViewState["FunId"]);

    private void BtnElimina_Click(object sender, EventArgs e)
    {
      try
      {
        Richiesta richiesta = new Richiesta();
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject = new S_Object();
        ((ParameterObject) sObject).set_ParameterName("p_Wr_Id");
        ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject).set_Index(0);
        ((ParameterObject) sObject).set_Value((object) this.wr_id);
        CollezioneControlli.Add(sObject);
        if (richiesta.DeleteRdL(CollezioneControlli) != -1)
          return;
        this.Server.Transfer("SfogliaRdlEliminare.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void DeleteItem(string id)
    {
      Console.WriteLine(id);
      if (id == "")
        return;
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) int.Parse(id));
      controlsCollection.Add(sObject);
    }
  }
}
