// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.UserRdlInail
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ManCorrettiva;

namespace TheSite.WebControls
{
  public class UserRdlInail : UserControl
  {
    protected S_TextBox txtsDescrizione;
    protected S_ComboBox cmbEQ;
    protected S_ComboBox cmdsStdApparecchiatura;
    protected S_ComboBox cmbsServizio;
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
    protected S_ComboBox cmbsTrasmissione;
    protected Label LblRdl;
    protected Label lblOperazione;
    protected MessagePanel PanelMess;
    protected S_Button btsApprovaDCSIT;
    protected S_Button btsRifiutaDCSIT;
    protected S_Label lbldatavalidDCSIT;
    protected S_Label lblOraValidDCSIT;
    protected S_Label lblUtenteDCSIT;
    protected S_Label lblStatoDCSIT;
    protected S_Button btsApprovaDL;
    protected S_Button btsRifiutaDL;
    protected S_Label lblDataValidDL;
    protected S_Label lblOraValidDL;
    protected S_Label lblUtenteDL;
    protected S_Label lblStatoDL;
    protected S_TextBox txtSpesa2;
    protected S_TextBox txtSpesa1;
    protected S_TextBox txtNumeroPreventivo;
    protected S_ComboBox cmbsUrgenza;
    protected S_ComboBox cmbsAddetto;
    protected S_ComboBox cmbsDitta;
    protected S_Label S_Lblordinelavoro;
    protected DataPanel Datapanel4;
    protected HtmlTable Tableordine;
    protected HtmlInputFile UploadFilePreventivo;
    protected S_HyperLink LinkConsuntivo;
    protected Label lblconsuntivo;
    protected S_ComboBox cmbsAnnoContab;
    protected S_ComboBox cmbContabilizzazione;
    protected S_TextBox txtSpesa4;
    protected S_TextBox txtSpesa3;
    protected S_TextBox txtsSospesa;
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
    protected HtmlInputFile UploadFileCosto;
    protected CalendarPicker CalendarPicker1;
    protected CalendarPicker CalendarPicker2;
    protected CalendarPicker CalendarPicker3;
    protected CalendarPicker CalendarPicker4;
    protected CalendarPicker CalendarPicker5;
    private bool IsEditable = false;
    private ClManCorrettiva _ClManCorrettiva;
    protected Button btnHelp;
    protected Button btnApprova;
    protected Button btnSospendi;
    protected Button btnRifiuta;
    protected HtmlTable TableEmetti;
    protected HtmlTable TableCompleta;
    protected S_Button btnCompleta;
    protected S_Button btnfoglioprestazioni;
    protected S_Button btnChiudicompleta;
    protected HtmlTableRow tipointervento0;
    protected HtmlTableRow tipointervento1;
    protected HtmlTableRow tipointervento2;
    protected S_ComboBox cmbsTipoIntrevento;
    protected S_TextBox txtspesaPresunta1;
    protected S_TextBox txtspesaPresunta2;
    protected S_TextBox txtOrdineLavoro;
    protected Label LblMessaggio;
    protected S_ComboBox cmbsTipoManutenzione;
    protected S_CheckBox checkQuantifica;
    protected RadioButton RadioButton1;
    protected RadioButton RadioButton2;
    protected RadioButton RadioButton3;
    protected RadioButton RadioButton4;
    protected RadioButtonList RadioButtonList1;
    private int wr_id = 0;
    protected VisualizzaSolleciti VisualizzaSolleciti1;
    protected S_TextBox txtsAnnotazioni;
    protected S_ComboBox cmbsOre;
    protected S_ComboBox cmbsMinuti;
    protected S_ComboBox cmbsOraInizio;
    protected S_ComboBox cmbsMinutiInizio;
    protected S_ComboBox cmbsOraFine;
    protected S_ComboBox cmbsMinutiFine;
    protected S_Button BtnCostiOpera;
    protected S_HyperLink LinkPreventivo;
    protected HtmlTableRow preventivo1;
    protected HtmlTableRow preventivo2;
    protected HtmlTableRow preventivo3;
    protected AggiungiSollecito AggiungiSollecito1;
    protected S_Button btnfoglioprestazioniPdf;
    protected HtmlTableRow Tr1;
    protected S_TextBox txt_BLavoroEsterno;
    protected S_Button BtnModifica;
    protected HtmlInputHidden HPageBack;
    private Type myType;

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
      this.myType = this.Page.GetType();
      FieldInfo field = this.myType.GetField("_SiteModule");
      if (field != null)
        this.IsEditable = ((SiteModule) field.GetValue((object) this.Page)).IsEditable;
      if (this.Request["wr_id"] != null)
        this.wr_id = int.Parse(this.Request["wr_id"]);
      this._ClManCorrettiva = new ClManCorrettiva(this.Context.User.Identity.Name);
      if (!this.IsPostBack)
      {
        string filePath = this.Page.Request.FilePath;
        this.HPageBack.Value = filePath.Substring(filePath.LastIndexOf("/") + 1);
        this.SetProperty();
        this.SetReadOnlyControl();
        this.ReadOnlyPanel();
        this.SetVisiblePanel();
        this.LoadDatiCreazione();
      }
      if (!this.IsCompleta)
        return;
      this.Page.RegisterStartupScript("settacombo", "<script language='javascript'>SetWorkType('" + ((ListControl) this.cmbsstatolavoro).SelectedValue + "');</script>");
      if (this.Context.User.IsInRole("amministratori") && ((ListControl) this.cmbsstatolavoro).SelectedValue == "4" && !this.btnApprova.Enabled)
      {
        ((Control) this.BtnModifica).Visible = true;
        ((WebControl) this.cmbsAddetto).Enabled = false;
        ((WebControl) this.cmbsDitta).Enabled = false;
        ((WebControl) this.cmbsstatolavoro).Enabled = false;
        ((WebControl) this.cmbsTipoManutenzione).Enabled = false;
        ((WebControl) this.checkQuantifica).Enabled = false;
        ((WebControl) this.txtNumeroPreventivo).Enabled = false;
        ((WebControl) this.txtSpesa1).Enabled = false;
        ((WebControl) this.txtSpesa2).Enabled = false;
        this.UploadFilePreventivo.Disabled = true;
        ((WebControl) this.btsApprovaDL).Enabled = false;
        ((WebControl) this.btsRifiutaDL).Enabled = false;
      }
      else
        ((Control) this.BtnModifica).Visible = false;
    }

    private void SetProperty()
    {
      ((WebControl) this.cmbsOre).Attributes.Add("readonly", "");
      ((WebControl) this.cmbsMinuti).Attributes.Add("readonly", "");
      ((WebControl) this.cmbsOraInizio).Attributes.Add("readonly", "");
      ((WebControl) this.cmbsMinutiInizio).Attributes.Add("readonly", "");
      ((WebControl) this.cmbsOraFine).Attributes.Add("readonly", "");
      ((WebControl) this.cmbsMinutiFine).Attributes.Add("readonly", "");
      ((WebControl) this.txtSpesa2).Attributes.Add("onblur", "imposta_dec(this.id);");
      ((WebControl) this.txtSpesa2).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtSpesa2).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtSpesa1).Attributes.Add("onblur", "imposta_int(this.id);");
      ((WebControl) this.txtSpesa1).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtSpesa1).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtspesaPresunta1).Attributes.Add("onblur", "imposta_int(this.id);");
      ((WebControl) this.txtspesaPresunta1).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtspesaPresunta1).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtspesaPresunta2).Attributes.Add("onblur", "imposta_int(this.id);");
      ((WebControl) this.txtspesaPresunta2).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtspesaPresunta2).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtOrdineLavoro).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtOrdineLavoro).Attributes.Add("onpaste", "return false;");
      StringBuilder stringBuilder1 = new StringBuilder();
      stringBuilder1.Append("if (typeof(validateDate) == 'function') { ");
      stringBuilder1.Append("if (validateDate() == false) { return false; }} ");
      stringBuilder1.Append("this.value = 'Attendere...';");
      stringBuilder1.Append("this.disabled = true;");
      stringBuilder1.Append(this.Page.GetPostBackEventReference((Control) this.btnCompleta));
      stringBuilder1.Append(";");
      ((WebControl) this.btnCompleta).Attributes.Add("onclick", stringBuilder1.ToString());
      StringBuilder stringBuilder2 = new StringBuilder();
      stringBuilder2.Append("this.disabled = true;if (typeof(ControllaData) == 'function') { ");
      stringBuilder2.Append("if (ControllaData() == false) {this.disabled = false; return false; }}");
      stringBuilder2.Append(";this.disabled = false;");
      this.btnApprova.Attributes.Add("onclick", stringBuilder2.ToString());
      StringBuilder stringBuilder3 = new StringBuilder();
      stringBuilder3.Append("if (typeof(ControllaDateSpesaPresunta) == 'function') { ");
      stringBuilder3.Append("if (ControllaDateSpesaPresunta() == false) { return false; }} ");
      ((WebControl) this.btsApprovaDL).Attributes.Add("onclick", stringBuilder3.ToString());
      StringBuilder stringBuilder4 = new StringBuilder();
      stringBuilder4.Append("document.getElementById('" + ((Control) this.cmbsServizio).ClientID + "').disabled = true;");
      ((WebControl) this.cmdsStdApparecchiatura).Attributes.Add("onchange", stringBuilder4.ToString());
      StringBuilder stringBuilder5 = new StringBuilder();
      stringBuilder5.Append("document.getElementById('" + ((Control) this.cmdsStdApparecchiatura).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsServizio).Attributes.Add("onchange", stringBuilder5.ToString());
    }

    private void ReadOnlyPanel()
    {
      if (this.Context.User.IsInRole("amministratori") || !this.Context.User.IsInRole("callcenter") || !(this.Request.QueryString["avvisi"] == "true"))
        return;
      ((Control) this.PanelCompleta).Visible = false;
    }

    private void SetReadOnlyControl()
    {
      ((Control) this.btsApprovaDL).Visible = this.IsEditable;
      ((Control) this.btsRifiutaDL).Visible = this.IsEditable;
      ((Control) this.btsApprovaDCSIT).Visible = this.IsEditable;
      ((Control) this.btsRifiutaDCSIT).Visible = this.IsEditable;
      this.TableEmetti.Visible = this.IsEditable;
      this.TableCompleta.Visible = this.IsEditable;
    }

    private void SetVisiblePanel()
    {
      if (!this.IsCompleta)
        ((Control) this.PanelCompleta).Visible = false;
      else
        ((Control) this.PanelCompleta).Visible = true;
      if (this.IsCompleta)
      {
        ((WebControl) this.cmbsTrasmissione).Attributes.Add("disabled", "");
        ((WebControl) this.cmbsServizio).Attributes.Add("disabled", "");
        ((WebControl) this.cmdsStdApparecchiatura).Attributes.Add("disabled", "");
        ((WebControl) this.cmbEQ).Attributes.Add("disabled", "");
        this.CalendarPicker2.CreateValidator("Inserire la Data di Inizio Comletamento", ValidatorDisplay.None);
        this.CalendarPicker3.CreateValidator("Inserire la Data di Fine Comletamento", ValidatorDisplay.None);
        this.lblOperazione.Text = "Gestione e Completamento Ordini di Lavoro";
        this.lblOperazione.CssClass = "Title";
        this.TableEmetti.Visible = false;
      }
      else
      {
        this.Tableordine.Visible = false;
        this.lblOperazione.Text = "Approva ed Emetti Richieste di Lavoro";
        this.lblOperazione.CssClass = "Title";
      }
    }

    private void LoadDatiCreazione()
    {
      this.BindCombo();
      DataSet singleRdl = this._ClManCorrettiva.GetSingleRdl(this.wr_id);
      if (singleRdl.Tables[0].Rows.Count <= 0)
        return;
      DataRow row1 = singleRdl.Tables[0].Rows[0];
      this.bl_id = int.Parse(row1["id_bl"].ToString());
      this.LoadDitte(this.bl_id);
      if (row1["id"] != DBNull.Value)
        this.LblRdl.Text = row1["ID"].ToString();
      this.AggiungiSollecito1.TxtID_WR = row1["id"].ToString();
      this.VisualizzaSolleciti1.TxtID_WR = row1["id"].ToString();
      if (row1["wo_id"] != DBNull.Value)
        ((Label) this.S_Lblordinelavoro).Text = row1["wo_id"].ToString();
      this.LoadService(row1["codicebl"].ToString());
      this.txtHidBl.Text = row1["codicebl"].ToString();
      if (row1["tipotrasmissione"] != DBNull.Value)
        ((ListControl) this.cmbsTrasmissione).SelectedValue = row1["tipotrasmissione"].ToString();
      if (row1["richiedente"] != DBNull.Value)
        this.lblRichiedente.Text = row1["richiedente"].ToString();
      if (row1["operatore"] != DBNull.Value)
        this.lblOperatore.Text = row1["operatore"].ToString();
      if (row1["telefonoric"] != DBNull.Value)
        this.lbltelefonoric.Text = row1["telefonoric"].ToString();
      if (row1["emailric"] != DBNull.Value)
        this.lblemailric.Text = row1["emailric"].ToString();
      if (row1["stanzaric"] != DBNull.Value)
        this.lblstanzaric.Text = row1["stanzaric"].ToString();
      if (row1["telefono"] != DBNull.Value)
        this.lblTelefono.Text = row1["telefono"].ToString();
      DateTime dateTime1;
      if (row1["dataRichiesta"] != DBNull.Value)
      {
        Label lblDataRichiesta = this.lblDataRichiesta;
        dateTime1 = DateTime.Parse(row1["dataRichiesta"].ToString());
        string shortDateString = dateTime1.ToShortDateString();
        lblDataRichiesta.Text = shortDateString;
      }
      if (row1["dataRichiesta"] != DBNull.Value)
      {
        Label lblOraRichiesta = this.lblOraRichiesta;
        dateTime1 = DateTime.Parse(row1["dataRichiesta"].ToString());
        string shortTimeString = dateTime1.ToShortTimeString();
        lblOraRichiesta.Text = shortTimeString;
      }
      if (row1["gruppo"] != DBNull.Value)
        this.lblGruppo.Text = row1["gruppo"].ToString();
      if (row1["fabbricato"] != DBNull.Value)
        this.lblfabbricato.Text = row1["fabbricato"].ToString();
      if (row1["stanza"] != DBNull.Value)
        this.lblStanza.Text = row1["stanza"].ToString();
      if (row1["piano"] != DBNull.Value)
        this.lblPiano.Text = row1["piano"].ToString();
      if (row1["nota"] != DBNull.Value)
        this.lblNote.Text = row1["nota"].ToString();
      if (row1["servizio_id"] != DBNull.Value)
        ((ListControl) this.cmbsServizio).SelectedValue = row1["servizio_id"].ToString();
      this.LoadStandardApparechiature();
      if (row1["eqstd_id"] != DBNull.Value)
        ((ListControl) this.cmdsStdApparecchiatura).SelectedValue = row1["eqstd_id"].ToString();
      this.LoadApparechiature();
      if (row1["id_eq"] != DBNull.Value)
        ((ListControl) this.cmbEQ).SelectedValue = row1["id_eq"].ToString();
      if (row1["descrizione"] != DBNull.Value)
        ((TextBox) this.txtsDescrizione).Text = row1["descrizione"].ToString();
      if (row1["ditta_id"] != DBNull.Value)
      {
        ((ListControl) this.cmbsDitta).SelectedValue = row1["ditta_id"].ToString();
        this.LoadAddettiDitta(row1["codicebl"].ToString(), int.Parse(((ListControl) this.cmbsDitta).SelectedValue));
      }
      else
        this.LoadAddettiDitta("", 1);
      if (row1["addetto_id"] != DBNull.Value)
        ((ListControl) this.cmbsAddetto).SelectedValue = row1["addetto_id"].ToString();
      if (row1["datapianificata"] != DBNull.Value)
      {
        S_TextBox datazione = this.CalendarPicker1.Datazione;
        dateTime1 = DateTime.Parse(row1["datapianificata"].ToString());
        string shortDateString = dateTime1.ToShortDateString();
        ((TextBox) datazione).Text = shortDateString;
      }
      int num;
      if (row1["datapianificata"] != DBNull.Value)
      {
        DateTime dateTime2 = DateTime.Parse(row1["datapianificata"].ToString());
        num = dateTime2.Hour;
        string str1 = num.ToString();
        num = dateTime2.Minute;
        string str2 = num.ToString();
        ((ListControl) this.cmbsOre).SelectedValue = str1.PadLeft(2, Convert.ToChar("0"));
        ((ListControl) this.cmbsMinuti).SelectedValue = str2.PadLeft(2, Convert.ToChar("0"));
      }
      if (row1["numeropreventivo"] != DBNull.Value)
        ((TextBox) this.txtNumeroPreventivo).Text = row1["numeropreventivo"].ToString();
      if (row1["importopreventivo"] != DBNull.Value && row1["importopreventivo"].ToString() != "0")
      {
        ((TextBox) this.txtSpesa1).Text = TheSite.Classi.Function.GetTypeNumber(row1["importopreventivo"], NumberType.Intero);
        ((TextBox) this.txtSpesa2).Text = TheSite.Classi.Function.GetTypeNumber(row1["importopreventivo"], NumberType.Decimale);
      }
      else
      {
        ((TextBox) this.txtSpesa1).Text = "0";
        ((TextBox) this.txtSpesa2).Text = "00";
      }
      if (row1["pdfpreventivo"] != DBNull.Value)
      {
        ((HyperLink) this.LinkPreventivo).Text = row1["pdfpreventivo"].ToString();
        ((HyperLink) this.LinkPreventivo).NavigateUrl = "javascript:openpdf('" + this.wr_id.ToString() + "','Preventivo','" + row1["pdfpreventivo"].ToString().Replace("'", "`") + "');";
      }
      if (row1["tipointervento"] != DBNull.Value)
      {
        ((ListControl) this.cmbsTipoManutenzione).SelectedValue = row1["tipointervento"].ToString();
        if (row1["tipointervento"].ToString() == "3")
        {
          this.tipointervento0.Style.Add("display", "block");
          this.tipointervento1.Style.Add("display", "block");
          this.tipointervento2.Style.Add("display", "block");
        }
        else
        {
          this.tipointervento1.Style.Add("display", "none");
          this.tipointervento2.Style.Add("display", "none");
          this.tipointervento0.Style.Add("display", "none");
        }
      }
      else
      {
        this.tipointervento1.Style.Add("display", "none");
        this.tipointervento2.Style.Add("display", "none");
        this.tipointervento0.Style.Add("display", "none");
      }
      if (row1["priorita"] != DBNull.Value)
        ((ListControl) this.cmbsUrgenza).SelectedValue = row1["priorita"].ToString();
      DataSet statusRdl = this._ClManCorrettiva.GetStatusRdl(this.wr_id);
      if (statusRdl.Tables[0].Rows.Count > 0)
      {
        DataRow row2 = statusRdl.Tables[0].Rows[0];
        this.LblMessaggio.Text = "Stato della Richiesta di Lavoro : " + row2["descrizione"].ToString() + " in data: " + row2["data"];
      }
      if (row1["id_dl"] != DBNull.Value)
        this.dl_id = Convert.ToInt32(row1["id_dl"]);
      if (row1["utente_dl"] != DBNull.Value)
        ((Label) this.lblUtenteDL).Text = row1["utente_dl"].ToString();
      if (row1["data_validazione_dl"] != DBNull.Value)
      {
        DateTime dateTime2 = DateTime.Parse(row1["data_validazione_dl"].ToString());
        ((Label) this.lblDataValidDL).Text = dateTime2.ToShortDateString();
        S_Label lblOraValidDl = this.lblOraValidDL;
        num = dateTime2.Hour;
        string str1 = num.ToString().PadLeft(2, '0');
        num = dateTime2.Minute;
        string str2 = num.ToString().PadLeft(2, '0');
        string str3 = str1 + ":" + str2;
        ((Label) lblOraValidDl).Text = str3;
      }
      if (row1["lavori_urgenti_dl"] != DBNull.Value)
        ((CheckBox) this.checkQuantifica).Checked = Convert.ToInt32(row1["lavori_urgenti_dl"]) != 0;
      if (row1["stato_dl"] != DBNull.Value)
      {
        ((Label) this.lblStatoDL).Text = row1["stato_dl"].ToString();
        if (row1["stato_dl"].ToString() == "Rifiutato DL")
        {
          ((WebControl) this.lblStatoDL).Attributes.Add("style", "color:red;");
          ((WebControl) this.lblUtenteDL).Attributes.Add("style", "color:red;");
        }
        else if (row1["stato_dl"].ToString() == "Approvato DL")
        {
          ((WebControl) this.lblStatoDL).Attributes.Add("style", "color:green;");
          ((WebControl) this.lblUtenteDL).Attributes.Add("style", "color:green;");
        }
      }
      if (row1["stato_dl_id"] != DBNull.Value && (row1["stato_dl_id"].ToString() == "3" || row1["stato_dl_id"].ToString() == "4") && this.Context.User.IsInRole("collaboratore"))
        this.DisableControl((Control) this.PanelDCSIT, false);
      if (!this.Context.User.IsInRole("amministratori") && (row1["stato_dl_id"].ToString() == "2" || row1["stato_dl_id"].ToString() == "4"))
        this.TableEmetti.Visible = false;
      ((ListControl) this.cmbsTipoIntrevento).SelectedIndex = -1;
      if (row1["TIPO_INTERVENTO"] != DBNull.Value)
        ((ListControl) this.cmbsTipoIntrevento).SelectedValue = row1["TIPO_INTERVENTO"].ToString();
      ((TextBox) this.txtspesaPresunta1).Text = "0";
      ((TextBox) this.txtspesaPresunta2).Text = "00";
      if (row1["SPESA_PRESUNTA"] != DBNull.Value)
      {
        ((TextBox) this.txtspesaPresunta1).Text = TheSite.Classi.Function.GetTypeNumber(row1["SPESA_PRESUNTA"], NumberType.Intero).ToString();
        ((TextBox) this.txtspesaPresunta2).Text = TheSite.Classi.Function.GetTypeNumber(row1["SPESA_PRESUNTA"], NumberType.Decimale).ToString();
      }
      if (row1["datainizio"] != DBNull.Value)
      {
        S_TextBox datazione = this.CalendarPicker4.Datazione;
        dateTime1 = DateTime.Parse(row1["datainizio"].ToString());
        string shortDateString = dateTime1.ToShortDateString();
        ((TextBox) datazione).Text = shortDateString;
      }
      else
        ((TextBox) this.CalendarPicker4.Datazione).Text = "";
      if (row1["datafine"] != DBNull.Value)
      {
        S_TextBox datazione = this.CalendarPicker5.Datazione;
        dateTime1 = DateTime.Parse(row1["datafine"].ToString());
        string shortDateString = dateTime1.ToShortDateString();
        ((TextBox) datazione).Text = shortDateString;
      }
      else
        ((TextBox) this.CalendarPicker5.Datazione).Text = "";
      if (row1["ordine_lavoro"] != DBNull.Value)
        ((TextBox) this.txtOrdineLavoro).Text = row1["ordine_lavoro"].ToString();
      else
        ((TextBox) this.txtOrdineLavoro).Text = "";
      if (row1["id_dcsit"] != DBNull.Value)
        this.dcsit_id = Convert.ToInt32(row1["id_dcsit"]);
      if (row1["utente_dcsit"] != DBNull.Value)
        ((Label) this.lblUtenteDCSIT).Text = row1["utente_dcsit"].ToString();
      if (row1["data_validazione_dcsit"] != DBNull.Value)
      {
        DateTime dateTime2 = DateTime.Parse(row1["data_validazione_dcsit"].ToString());
        ((Label) this.lbldatavalidDCSIT).Text = dateTime2.ToShortDateString();
        S_Label lblOraValidDcsit = this.lblOraValidDCSIT;
        num = dateTime2.Hour;
        string str1 = num.ToString().PadLeft(2, '0');
        num = dateTime2.Minute;
        string str2 = num.ToString().PadLeft(2, '0');
        string str3 = str1 + ":" + str2;
        ((Label) lblOraValidDcsit).Text = str3;
      }
      if (row1["stato_dcsit"] != DBNull.Value)
        ((Label) this.lblStatoDCSIT).Text = row1["stato_dcsit"].ToString();
      if (!this.IsCompleta)
        return;
      if (row1["tipointervento"].ToString() == "1")
      {
        this.trsoddisfazione.Style.Add("display", "none");
        this.trannotazione.Style.Add("display", "none");
      }
      if (row1["idstatus"] != DBNull.Value)
      {
        if (int.Parse(row1["idstatus"].ToString()) == 8 || int.Parse(row1["idstatus"].ToString()) == 11 || (int.Parse(row1["idstatus"].ToString()) == 12 || int.Parse(row1["idstatus"].ToString()) == 13) || int.Parse(row1["idstatus"].ToString()) == 14)
          this.trnote.Attributes.Add("style", "display:block");
        else
          this.trnote.Attributes.Add("style", "display:none");
        this.LoadStatoLavoro(row1["idstatus"].ToString());
      }
      else
      {
        this.LoadStatoLavoro("");
        this.trnote.Attributes.Add("style", "display:none");
      }
      if (row1["notesospesa"] != DBNull.Value)
        ((TextBox) this.txtsSospesa).Text = row1["notesospesa"].ToString();
      if (row1["date_start"] != DBNull.Value)
      {
        S_TextBox datazione = this.CalendarPicker2.Datazione;
        dateTime1 = DateTime.Parse(row1["date_start"].ToString());
        string shortDateString = dateTime1.ToShortDateString();
        ((TextBox) datazione).Text = shortDateString;
      }
      if (row1["date_end"] != DBNull.Value)
      {
        S_TextBox datazione = this.CalendarPicker3.Datazione;
        dateTime1 = DateTime.Parse(row1["date_end"].ToString());
        string shortDateString = dateTime1.ToShortDateString();
        ((TextBox) datazione).Text = shortDateString;
      }
      if (row1["date_start"] != DBNull.Value)
      {
        DateTime dateTime2 = DateTime.Parse(row1["date_start"].ToString());
        S_ComboBox cmbsOraInizio = this.cmbsOraInizio;
        num = dateTime2.Hour;
        string str1 = num.ToString().PadLeft(2, Convert.ToChar("0"));
        ((ListControl) cmbsOraInizio).SelectedValue = str1;
        S_ComboBox cmbsMinutiInizio = this.cmbsMinutiInizio;
        num = dateTime2.Minute;
        string str2 = num.ToString().PadLeft(2, Convert.ToChar("0"));
        ((ListControl) cmbsMinutiInizio).SelectedValue = str2;
      }
      if (row1["date_end"] != DBNull.Value)
      {
        DateTime dateTime2 = DateTime.Parse(row1["date_end"].ToString());
        S_ComboBox cmbsOraFine = this.cmbsOraFine;
        num = dateTime2.Hour;
        string str1 = num.ToString().PadLeft(2, Convert.ToChar("0"));
        ((ListControl) cmbsOraFine).SelectedValue = str1;
        S_ComboBox cmbsMinutiFine = this.cmbsMinutiFine;
        num = dateTime2.Minute;
        string str2 = num.ToString().PadLeft(2, Convert.ToChar("0"));
        ((ListControl) cmbsMinutiFine).SelectedValue = str2;
      }
      if (row1["comments"] != DBNull.Value)
        ((TextBox) this.txtsAnnotazioni).Text = row1["comments"].ToString();
      if (row1["AC_ID"] != DBNull.Value)
        ((TextBox) this.txt_BLavoroEsterno).Text = row1["AC_ID"].ToString();
      if (row1["satisfaction_id"] != DBNull.Value)
        this.RadioButtonList1.SelectedValue = row1["satisfaction_id"].ToString();
      if (row1["pdfconsuntivo"] != DBNull.Value)
      {
        this.lblconsuntivo.Text = "File Consuntivo: ";
        ((Control) this.LinkConsuntivo).Visible = true;
        ((HyperLink) this.LinkConsuntivo).Text = row1["pdfconsuntivo"].ToString();
        ((HyperLink) this.LinkConsuntivo).NavigateUrl = "javascript:openpdf('" + this.wr_id.ToString() + "','Consuntivo','" + row1["pdfconsuntivo"].ToString().Replace("'", "`") + "');";
      }
      else
        this.lblconsuntivo.Text = "Importa Consuntivo(PDF): ";
      if (row1["contabilizzazione"] != DBNull.Value)
        ((ListControl) this.cmbContabilizzazione).SelectedValue = row1["contabilizzazione"].ToString();
      if (row1["idstatus"] == DBNull.Value || !(row1["idstatus"].ToString() == "4"))
        return;
      ((WebControl) this.btnCompleta).Enabled = false;
      if (!this.Context.User.IsInRole("amministratori"))
        return;
      ((Control) this.BtnModifica).Visible = true;
    }

    private void BindCombo()
    {
      this.LoadUrgenze();
      this.LoadTipoManutenzione();
      this.LoadTipoTrasimissione();
      this.LoadTipoIntervento();
    }

    private void LoadStatoLavoro(string stato_id)
    {
      ((ListControl) this.cmbsstatolavoro).Items.Clear();
      DataSet statoLavoro = this._ClManCorrettiva.GetStatoLavoro();
      if (statoLavoro.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsstatolavoro).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(statoLavoro.Tables[0], "descrizione", "id", "- Selezionare lo Stato di Lavoro  -", "");
        ((ListControl) this.cmbsstatolavoro).DataTextField = "descrizione";
        ((ListControl) this.cmbsstatolavoro).DataValueField = "id";
        ((Control) this.cmbsstatolavoro).DataBind();
        if (stato_id != "" && stato_id != "3")
        {
          foreach (ListItem listItem in ((ListControl) this.cmbsstatolavoro).Items)
          {
            if (listItem.Value == "3")
              ((ListControl) this.cmbsstatolavoro).Items.Remove(listItem);
          }
        }
        if (stato_id == "3" || stato_id == "4")
        {
          this.UploadFileCosto.Visible = false;
          this.btnApprova.Enabled = false;
          ((WebControl) this.cmbsstatolavoro).Enabled = false;
          if (this.Context.User.IsInRole("amministratori") && stato_id == "4")
            ((WebControl) this.cmbsstatolavoro).Enabled = true;
        }
        else
          this.lblconsuntivo.Text = "";
        ((ListControl) this.cmbsstatolavoro).SelectedValue = stato_id;
        ((WebControl) this.cmbsstatolavoro).Attributes.Add("OnChange", "SetWorkType(this.value);");
      }
      else
        ((ListControl) this.cmbsstatolavoro).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuno Stato di Lavoro  -", string.Empty));
      if (!(((ListControl) this.cmbsstatolavoro).SelectedValue == "4"))
        return;
      ((Control) this.BtnCostiOpera).Visible = true;
    }

    private void LoadAddettiDitta(string bl_id, int ditta_id)
    {
      ((ListControl) this.cmbsAddetto).Items.Clear();
      DataSet addetti = this._ClManCorrettiva.GetAddetti("", bl_id, ditta_id);
      if (addetti.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsAddetto).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(addetti.Tables[0], "NOMINATIVO", "ID", "- Selezionare un Addetto -", "");
        ((ListControl) this.cmbsAddetto).DataTextField = "NOMINATIVO";
        ((ListControl) this.cmbsAddetto).DataValueField = "ID";
        ((Control) this.cmbsAddetto).DataBind();
      }
      else
        ((ListControl) this.cmbsAddetto).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Addetto  -", ""));
    }

    private void LoadApparechiature()
    {
      if (((ListControl) this.cmbsServizio).SelectedIndex == 0)
      {
        ((ListControl) this.cmbEQ).Items.Clear();
        ((ListControl) this.cmbEQ).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Apparecchiatura -", string.Empty));
      }
      else
      {
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Size(50);
        ((ParameterObject) sObject1).set_Index(0);
        ((ParameterObject) sObject1).set_Value((object) "");
        CollezioneControlli.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_campus");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(1);
        ((ParameterObject) sObject2).set_Size(50);
        ((ParameterObject) sObject2).set_Value((object) this.lblfabbricato.Text);
        CollezioneControlli.Add(sObject2);
        S_Object sObject3 = new S_Object();
        ((ParameterObject) sObject3).set_ParameterName("p_Servizio");
        ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject3).set_Index(2);
        ((ParameterObject) sObject3).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
        CollezioneControlli.Add(sObject3);
        S_Object sObject4 = new S_Object();
        ((ParameterObject) sObject4).set_ParameterName("p_eqstdid");
        ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject4).set_Size(8);
        ((ParameterObject) sObject4).set_Index(3);
        ((ParameterObject) sObject4).set_Value((object) (((ListControl) this.cmdsStdApparecchiatura).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmdsStdApparecchiatura).SelectedValue)));
        CollezioneControlli.Add(sObject4);
        S_Object sObject5 = new S_Object();
        ((ParameterObject) sObject5).set_ParameterName("p_eq_id");
        ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject5).set_Size(8);
        ((ParameterObject) sObject5).set_Index(4);
        ((ParameterObject) sObject5).set_Size(50);
        ((ParameterObject) sObject5).set_Value(((ListControl) this.cmbEQ).SelectedValue == string.Empty ? (object) "" : (object) ((ListControl) this.cmbEQ).Items[((ListControl) this.cmbEQ).SelectedIndex].Text);
        CollezioneControlli.Add(sObject5);
        S_Object sObject6 = new S_Object();
        ((ParameterObject) sObject6).set_ParameterName("p_dismesso");
        ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject6).set_Size(8);
        ((ParameterObject) sObject6).set_Index(4);
        ((ParameterObject) sObject6).set_Size(50);
        ((ParameterObject) sObject6).set_Value((object) 1);
        CollezioneControlli.Add(sObject6);
        DataSet listaApparrati = this._ClManCorrettiva.GetListaApparrati(CollezioneControlli);
        if (listaApparrati.Tables[0].Rows.Count > 0)
        {
          ((BaseDataBoundControl) this.cmbEQ).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(listaApparrati.Tables[0], "ID", "id_eq", "- Selezionare un' Apparecchiatura -", "");
          ((ListControl) this.cmbEQ).DataTextField = "ID";
          ((ListControl) this.cmbEQ).DataValueField = "id_eq";
          ((Control) this.cmbEQ).DataBind();
        }
        else
        {
          ((ListControl) this.cmbEQ).Items.Clear();
          ((ListControl) this.cmbEQ).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Apparecchiatura -", string.Empty));
        }
      }
    }

    private void LoadStandardApparechiature()
    {
      if (((ListControl) this.cmbsServizio).SelectedIndex == 0)
      {
        ((ListControl) this.cmdsStdApparecchiatura).Items.Clear();
        ((ListControl) this.cmdsStdApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuno Standard -", string.Empty));
      }
      else
      {
        ((ListControl) this.cmdsStdApparecchiatura).Items.Clear();
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Size(50);
        ((ParameterObject) sObject1).set_Index(0);
        ((ParameterObject) sObject1).set_Value((object) this.txtHidBl.Text);
        CollezioneControlli.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_Servizio");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(1);
        ((ParameterObject) sObject2).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
        CollezioneControlli.Add(sObject2);
        DataSet standardApparechiature = this._ClManCorrettiva.GetStandardApparechiature(CollezioneControlli);
        if (standardApparechiature.Tables[0].Rows.Count > 0)
        {
          ((BaseDataBoundControl) this.cmdsStdApparecchiatura).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(standardApparechiature.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Standard -", "");
          ((ListControl) this.cmdsStdApparecchiatura).DataTextField = "DESCRIZIONE";
          ((ListControl) this.cmdsStdApparecchiatura).DataValueField = "ID";
          ((Control) this.cmdsStdApparecchiatura).DataBind();
        }
        else
        {
          ((ListControl) this.cmdsStdApparecchiatura).Items.Clear();
          ((ListControl) this.cmdsStdApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuno Standard -", string.Empty));
        }
      }
    }

    private void LoadDitte(int bl_id)
    {
      ((ListControl) this.cmbsDitta).Items.Clear();
      DataSet ditteFornitoriRuoli = this._ClManCorrettiva.GetDitteFornitoriRuoli(int.Parse(this._ClManCorrettiva.GetDittaMasterBl(bl_id).Tables[0].Rows[0]["id_ditta"].ToString()));
      if (ditteFornitoriRuoli.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsDitta).DataSource = (object) ditteFornitoriRuoli.Tables[0];
        ((ListControl) this.cmbsDitta).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsDitta).DataValueField = "id";
        ((Control) this.cmbsDitta).DataBind();
        ((ListControl) this.cmbsDitta).SelectedValue = "1";
        this.LoadAddettiDitta("", 1);
      }
      else
        ((ListControl) this.cmbsDitta).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Ditta  -", string.Empty));
    }

    private void LoadTipoTrasimissione()
    {
      ((ListControl) this.cmbsTrasmissione).Items.Clear();
      DataSet tipoTrasmissione = this._ClManCorrettiva.GetAllTipoTrasmissione();
      if (tipoTrasmissione.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsTrasmissione).DataSource = (object) tipoTrasmissione.Tables[0];
        ((ListControl) this.cmbsTrasmissione).DataTextField = "descrizione";
        ((ListControl) this.cmbsTrasmissione).DataValueField = "ID";
        ((Control) this.cmbsTrasmissione).DataBind();
        ((ListControl) this.cmbsTrasmissione).SelectedIndex = 1;
      }
      else
        ((ListControl) this.cmbsTrasmissione).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Trasmissione  -", string.Empty));
    }

    private void LoadTipoManutenzione()
    {
      DataSet tipoManutenzione = this._ClManCorrettiva.GetTipoManutenzione();
      if (tipoManutenzione.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsTipoManutenzione).DataSource = (object) tipoManutenzione;
      ((ListControl) this.cmbsTipoManutenzione).DataTextField = "descrizione";
      ((ListControl) this.cmbsTipoManutenzione).DataValueField = "id";
      ((Control) this.cmbsTipoManutenzione).DataBind();
      ((WebControl) this.cmbsTipoManutenzione).Attributes.Add("OnChange", "SetPreventivo(this.value);");
    }

    private void LoadService(string CodiceEdificio)
    {
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) CodiceEdificio);
      ((ParameterObject) sObject1).set_Size(8);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_ID_Servizio");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) 0);
      CollezioneControlli.Add(sObject1);
      CollezioneControlli.Add(sObject2);
      DataSet serviceBulding = this._ClManCorrettiva.GetServiceBulding(CollezioneControlli);
      if (serviceBulding.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(serviceBulding.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "Non Definito", "");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("Non Definito", ""));
    }

    private void LoadUrgenze()
    {
      DataSet priority = this._ClManCorrettiva.GetPriority();
      if (priority.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsUrgenza).DataSource = (object) priority;
      ((ListControl) this.cmbsUrgenza).DataTextField = "PRIORITY";
      ((ListControl) this.cmbsUrgenza).DataValueField = "IDP";
      ((Control) this.cmbsUrgenza).DataBind();
      ((ListControl) this.cmbsUrgenza).SelectedIndex = 5;
    }

    private void LoadTipoIntervento()
    {
      ((ListControl) this.cmbsTipoIntrevento).Items.Clear();
      DataSet tipointervento = this._ClManCorrettiva.GetTipointervento();
      if (tipointervento.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsTipoIntrevento).DataSource = (object) tipointervento.Tables[0];
        ((ListControl) this.cmbsTipoIntrevento).DataTextField = "descrizione_breve";
        ((ListControl) this.cmbsTipoIntrevento).DataValueField = "id";
        ((Control) this.cmbsTipoIntrevento).DataBind();
      }
      else
        ((ListControl) this.cmbsTipoIntrevento).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Tipo Intervento -", string.Empty));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsServizio).SelectedIndexChanged += new EventHandler(this.cmbsServizio_SelectedIndexChanged);
      ((ListControl) this.cmdsStdApparecchiatura).SelectedIndexChanged += new EventHandler(this.cmdsStdApparecchiatura_SelectedIndexChanged);
      ((Button) this.btsApprovaDCSIT).Click += new EventHandler(this.btsApprovaDCSIT_Click);
      ((Button) this.btsRifiutaDCSIT).Click += new EventHandler(this.btsRifiutaDCSIT_Click);
      ((Button) this.btsApprovaDL).Click += new EventHandler(this.btsApprovaDL_Click);
      ((Button) this.btsRifiutaDL).Click += new EventHandler(this.btsRifiutaDL_Click);
      ((ListControl) this.cmbsDitta).SelectedIndexChanged += new EventHandler(this.cmbsDitta_SelectedIndexChanged);
      this.btnRifiuta.Click += new EventHandler(this.btnRifiuta_Click);
      this.btnSospendi.Click += new EventHandler(this.btnSospendi_Click);
      this.btnApprova.Click += new EventHandler(this.btnApprova_Click);
      ((Button) this.btnCompleta).Click += new EventHandler(this.btnCompleta_Click);
      ((Button) this.btnfoglioprestazioni).Click += new EventHandler(this.btnfoglioprestazioni_Click);
      ((Button) this.btnfoglioprestazioniPdf).Click += new EventHandler(this.btnfoglioprestazioniPdf_Click);
      ((Button) this.BtnCostiOpera).Click += new EventHandler(this.BtnCostiOpera_Click);
      ((Button) this.btnChiudicompleta).Click += new EventHandler(this.btnChiudicompleta_Click);
      ((Button) this.BtnModifica).Click += new EventHandler(this.BtnModifica_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void cmbsServizio_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.LoadStandardApparechiature();
      this.LoadApparechiature();
    }

    private void cmdsStdApparecchiatura_SelectedIndexChanged(object sender, EventArgs e) => this.LoadApparechiature();

    private void btnApprova_Click(object sender, EventArgs e) => this.AggiornaRdl(StateType.EmessaInLavorazione);

    private void ScriptRapportoTecnico(int wo_id) => this.Page.RegisterStartupScript("funz", "<script language=\"javascript\">\n" + ("ApriPopUp('" + ("RapportoTecnicoIntervento.aspx?WO_Id=" + wo_id.ToString()) + "')") + "</script>\n");

    private void AggiornaRdl(StateType status_id)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Wr_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) this.wr_id);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_stato");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) (int) status_id);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_urgenza");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) int.Parse(((ListControl) this.cmbsUrgenza).SelectedValue.Split(Convert.ToChar(","))[0]));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_richiedente");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Size(35);
      ((ParameterObject) sObject4).set_Value((object) this.lblRichiedente.Text);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Size(4000);
      ((ParameterObject) sObject5).set_Value((object) ((TextBox) this.txtsDescrizione).Text);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_datapianificata");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject6).set_Size(30);
      string str1 = "";
      string text = ((TextBox) this.CalendarPicker1.Datazione).Text;
      if (text != "")
      {
        string str2 = (((ListControl) this.cmbsOre).SelectedValue == "" ? "00" : ((ListControl) this.cmbsOre).SelectedValue) + ":" + (((ListControl) this.cmbsMinuti).SelectedValue == "" ? "00" : ((ListControl) this.cmbsMinuti).SelectedValue) + ":00";
        str1 = text + " " + str2;
      }
      ((ParameterObject) sObject6).set_Value((object) str1);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_servizio_id");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject7).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_trasmissione_id");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject8).set_Value((object) int.Parse(((ListControl) this.cmbsTrasmissione).SelectedValue));
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_manutenzione_id");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject9).set_Value((object) int.Parse(((ListControl) this.cmbsTipoManutenzione).SelectedValue));
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject10).set_Value((object) this.bl_id);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_addetto_id");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject11).set_Value((object) (((ListControl) this.cmbsAddetto).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsAddetto).SelectedValue)));
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_id_ditta");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject12).set_Value((object) (((ListControl) this.cmbsDitta).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsDitta).SelectedValue)));
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_stdApparecchiatura_id");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject13).set_Value((object) (((ListControl) this.cmdsStdApparecchiatura).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmdsStdApparecchiatura).SelectedValue)));
      CollezioneControlli.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("p_eq_id");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject14).set_Value((object) (((ListControl) this.cmbEQ).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbEQ).SelectedValue)));
      CollezioneControlli.Add(sObject14);
      try
      {
        int wo_id = this._ClManCorrettiva.EmettiRdl(CollezioneControlli, status_id);
        if (wo_id == 0)
          return;
        if (status_id == StateType.EmessaInLavorazione)
          this.ScriptRapportoTecnico(wo_id);
        this.btnRifiuta.Enabled = false;
        this.btnSospendi.Enabled = false;
        this.btnApprova.Enabled = false;
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnRifiuta_Click(object sender, EventArgs e) => this.AggiornaRdl(StateType.RichiestaRifiutata);

    private void btnSospendi_Click(object sender, EventArgs e) => this.AggiornaRdl(StateType.RichiestaSospesa);

    private void Chiudi() => this.Server.Transfer(this.HPageBack.Value + "?FunId=" + this.ViewState["FunId"]);

    private void AggiornaStatoDCSIT_DL(bool DCSIT, bool Stato)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_wr_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) this.wr_id);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_ruolo_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (this.Context.User.IsInRole("collaboratore"))
        ((ParameterObject) sObject2).set_Value((object) "collaboratore");
      else
        ((ParameterObject) sObject2).set_Value((object) "dl");
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_lavori_urgenti");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (!DCSIT)
        ((ParameterObject) sObject3).set_Value((object) (((CheckBox) this.checkQuantifica).Checked ? 1 : 0));
      else
        ((ParameterObject) sObject3).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_stato");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (!DCSIT)
        ((ParameterObject) sObject4).set_Value((object) (Stato ? 3 : 4));
      else
        ((ParameterObject) sObject4).set_Value((object) (Stato ? 1 : 2));
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_tipo_manutenzione");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (!DCSIT)
        ((ParameterObject) sObject5).set_Value((object) int.Parse(((ListControl) this.cmbsTipoManutenzione).SelectedValue));
      else
        ((ParameterObject) sObject5).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_tipo_intervento");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (!DCSIT)
      {
        if (((ListControl) this.cmbsTipoIntrevento).SelectedValue == "")
          ((ParameterObject) sObject6).set_Value((object) DBNull.Value);
        else
          ((ParameterObject) sObject6).set_Value((object) int.Parse(((ListControl) this.cmbsTipoIntrevento).SelectedValue));
      }
      else
        ((ParameterObject) sObject6).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_importo_presunto");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (!DCSIT)
        ((ParameterObject) sObject7).set_Value((object) double.Parse(((TextBox) this.txtspesaPresunta1).Text + "," + ((TextBox) this.txtspesaPresunta2).Text));
      else
        ((ParameterObject) sObject7).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_data_presunta_inizio");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 5);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (!DCSIT)
      {
        if (((TextBox) this.CalendarPicker4.Datazione).Text == "")
          ((ParameterObject) sObject8).set_Value((object) DBNull.Value);
        else
          ((ParameterObject) sObject8).set_Value((object) DateTime.Parse(((TextBox) this.CalendarPicker4.Datazione).Text));
      }
      else
        ((ParameterObject) sObject8).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_data_presunta_fine");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 5);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (!DCSIT)
      {
        if (((TextBox) this.CalendarPicker5.Datazione).Text == "")
          ((ParameterObject) sObject9).set_Value((object) DBNull.Value);
        else
          ((ParameterObject) sObject9).set_Value((object) DateTime.Parse(((TextBox) this.CalendarPicker5.Datazione).Text));
      }
      else
        ((ParameterObject) sObject9).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_ordine_lavoro");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (!DCSIT)
      {
        if (((TextBox) this.txtOrdineLavoro).Text == "")
          ((ParameterObject) sObject10).set_Value((object) DBNull.Value);
        else
          ((ParameterObject) sObject10).set_Value((object) int.Parse(((TextBox) this.txtOrdineLavoro).Text));
      }
      else
        ((ParameterObject) sObject10).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_servizio_id");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject11).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_trasmissione_id");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject12).set_Value((object) int.Parse(((ListControl) this.cmbsTrasmissione).SelectedValue));
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_stdApparecchiatura_id");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject13).set_Value((object) (((ListControl) this.cmdsStdApparecchiatura).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmdsStdApparecchiatura).SelectedValue)));
      CollezioneControlli.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("p_eq_id");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject14).set_Value((object) (((ListControl) this.cmbEQ).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbEQ).SelectedValue)));
      CollezioneControlli.Add(sObject14);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("p_numeropreventivo");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Index(16);
      ((ParameterObject) sObject15).set_Size(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject15).set_Value((object) ((TextBox) this.txtNumeroPreventivo).Text);
      CollezioneControlli.Add(sObject15);
      S_Object sObject16 = new S_Object();
      ((ParameterObject) sObject16).set_ParameterName("p_importopreventivo");
      ((ParameterObject) sObject16).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject16).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject16).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (((TextBox) this.txtSpesa1).Text == "")
        ((ParameterObject) sObject16).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject16).set_Value((object) double.Parse(((TextBox) this.txtSpesa1).Text + "," + ((TextBox) this.txtSpesa2).Text));
      CollezioneControlli.Add(sObject16);
      S_Object sObject17 = new S_Object();
      ((ParameterObject) sObject17).set_ParameterName("p_pdfpreventivo");
      ((ParameterObject) sObject17).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject17).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject17).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject17).set_Size(250);
      ((ParameterObject) sObject17).set_Value((object) this.GetNameFileUpload(this.UploadFilePreventivo));
      CollezioneControlli.Add(sObject17);
      S_Object sObject18 = new S_Object();
      ((ParameterObject) sObject18).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject18).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject18).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject18).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject18).set_Size(4000);
      ((ParameterObject) sObject18).set_Value((object) ((TextBox) this.txtsDescrizione).Text);
      CollezioneControlli.Add(sObject18);
      if (!DCSIT)
      {
        if (this.dl_id == 0)
          this.dl_id = this._ClManCorrettiva.AddDCSTI_DL(CollezioneControlli, DCSIT);
        else
          this._ClManCorrettiva.UpdateDCSTI_DL(CollezioneControlli, this.dl_id, DCSIT);
      }
      else if (this.dcsit_id == 0)
        this.dcsit_id = this._ClManCorrettiva.AddDCSTI_DL(CollezioneControlli, DCSIT);
      else
        this._ClManCorrettiva.UpdateDCSTI_DL(CollezioneControlli, this.dcsit_id, DCSIT);
      this.UploadFile(this.UploadFilePreventivo, TipoPostFile.Preventivo);
      if (this.lblemailric.Text.Trim() != "" && (!DCSIT || !Stato))
      {
        string str = this._ClManCorrettiva.GetDatiEdificio(this.wr_id).Tables[0].Rows[0]["Via"].ToString();
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = ConfigurationSettings.AppSettings["MailFrom"];
        mailMessage.Subject = "Avviso di cambio di stato di una richiesta di lavoro.";
        mailMessage.To = this.lblemailric.Text.Trim();
        ClassMail classMail = new ClassMail();
        mailMessage.BodyFormat = MailFormat.Html;
        classMail.Messaggio = mailMessage;
        classMail.CodiceEdificio = str;
        classMail.Idrichiesta = this.wr_id.ToString();
        classMail.Name = this.lblRichiedente.Text.Trim();
        classMail.Surname = Stato ? "emessa in lavorazione" : "rifiutata";
        classMail.Responsabile = DCSIT ? "dal collaboratore" : "del direttore dei lavori";
        classMail.Decription = ((TextBox) this.txtsDescrizione).Text.Trim();
        classMail.SendMail(ClassMail.TipoMail.MailEmissioneRichiesta);
      }
      this.LoadDatiCreazione();
    }

    private void btsApprovaDCSIT_Click(object sender, EventArgs e) => this.AggiornaStatoDCSIT_DL(true, true);

    private void btsRifiutaDCSIT_Click(object sender, EventArgs e) => this.AggiornaStatoDCSIT_DL(true, false);

    private void btsApprovaDL_Click(object sender, EventArgs e) => this.AggiornaStatoDCSIT_DL(false, true);

    private void btsRifiutaDL_Click(object sender, EventArgs e) => this.AggiornaStatoDCSIT_DL(false, false);

    private void cmbsDitta_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (int.Parse(((ListControl) this.cmbsDitta).SelectedValue.ToString()) > 0)
        this.LoadAddettiDitta("", int.Parse(((ListControl) this.cmbsDitta).SelectedValue.ToString()));
      else
        this.LoadAddettiDitta("-1", -1);
    }

    private string GetNameFileUpload(HtmlInputFile FileUpload) => FileUpload.PostedFile != null && FileUpload.PostedFile.FileName != "" ? Path.GetFileName(FileUpload.PostedFile.FileName) : "";

    private string UploadFile(HtmlInputFile FileUpload, TipoPostFile Tipologia)
    {
      if (FileUpload.PostedFile != null)
      {
        if (FileUpload.PostedFile.FileName != "")
        {
          try
          {
            string fileName = Path.GetFileName(FileUpload.PostedFile.FileName);
            string path1 = this.Server.MapPath("../Doc_DB");
            string path2_1 = "Correttiva";
            string path2_2 = this.wr_id.ToString();
            string str1 = Path.Combine(path1, path2_1);
            if (!Directory.Exists(str1))
              Directory.CreateDirectory(str1);
            string str2 = Path.Combine(str1, path2_2);
            if (!Directory.Exists(str2))
              Directory.CreateDirectory(str2);
            string str3 = Path.Combine(str2, Tipologia == TipoPostFile.Preventivo ? "Preventivo" : "Consuntivo");
            if (!Directory.Exists(str3))
              Directory.CreateDirectory(str3);
            string filename = Path.Combine(str3, fileName);
            FileUpload.PostedFile.SaveAs(filename);
            return fileName;
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
            return "";
          }
        }
      }
      return "";
    }

    private void DisableControl(Control c, bool stato)
    {
      foreach (Control control in c.Controls)
      {
        if (control is WebControl)
          ((WebControl) control).Enabled = false;
        if (control is HtmlControl)
        {
          if (stato)
            ((HtmlControl) control).Attributes.Add("disabled", "");
          else
            ((HtmlControl) control).Attributes.Add("enabled", "");
        }
        if (control.Controls.Count > 0)
          this.DisableControl(control, stato);
      }
    }

    private void btnCompleta_Click(object sender, EventArgs e)
    {
      this.Completa();
      if (((ListControl) this.cmbsstatolavoro).SelectedValue == "4")
        ((Control) this.BtnCostiOpera).Visible = true;
      ((WebControl) this.btnCompleta).Enabled = false;
      if (!this.Context.User.IsInRole("amministratori"))
        return;
      ((Control) this.BtnModifica).Visible = true;
    }

    private void Completa()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_wr_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) this.wr_id);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_urgenza");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) ((ListControl) this.cmbsUrgenza).SelectedValue.Split(Convert.ToChar(","))[0]);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(4000);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) ((TextBox) this.txtsDescrizione).Text);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_id_ditta");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) ((ListControl) this.cmbsDitta).SelectedValue);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_intervento");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) ((ListControl) this.cmbsTipoManutenzione).SelectedValue);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_addetto");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Value((object) ((ListControl) this.cmbsAddetto).SelectedValue);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_datapianificata");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Size(30);
      string str1 = string.Empty;
      string text1 = ((TextBox) this.CalendarPicker1.Datazione).Text;
      if (text1 != "")
      {
        string str2 = (((ListControl) this.cmbsOre).SelectedValue == "" ? "00" : ((ListControl) this.cmbsOre).SelectedValue) + ":" + (((ListControl) this.cmbsMinuti).SelectedValue == "" ? "00" : ((ListControl) this.cmbsMinuti).SelectedValue) + ":00";
        str1 = text1 + " " + str2;
      }
      ((ParameterObject) sObject7).set_Value((object) str1);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_id_status");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(7);
      ((ParameterObject) sObject8).set_Value((object) ((ListControl) this.cmbsstatolavoro).SelectedValue);
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_date_start");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(8);
      ((ParameterObject) sObject9).set_Size(30);
      string str3 = string.Empty;
      string text2 = ((TextBox) this.CalendarPicker2.Datazione).Text;
      if (text2 != "")
      {
        string str2 = (((ListControl) this.cmbsOraInizio).SelectedValue == "" ? "00" : ((ListControl) this.cmbsOraInizio).SelectedValue) + ":" + (((ListControl) this.cmbsMinutiInizio).SelectedValue == "" ? "00" : ((ListControl) this.cmbsMinutiInizio).SelectedValue) + ":00";
        str3 = text2 + " " + str2;
      }
      ((ParameterObject) sObject9).set_Value((object) str3);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_date_end");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(9);
      ((ParameterObject) sObject10).set_Size(30);
      string str4 = string.Empty;
      string text3 = ((TextBox) this.CalendarPicker3.Datazione).Text;
      if (text3 != "")
      {
        string str2 = (((ListControl) this.cmbsOraFine).SelectedValue == "" ? "00" : ((ListControl) this.cmbsOraFine).SelectedValue) + ":" + (((ListControl) this.cmbsMinutiFine).SelectedValue == "" ? "00" : ((ListControl) this.cmbsMinutiFine).SelectedValue) + ":00";
        str4 = text3 + " " + str2;
      }
      ((ParameterObject) sObject10).set_Value((object) str4);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_comments");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(10);
      ((ParameterObject) sObject11).set_Size(4000);
      ((ParameterObject) sObject11).set_Value((object) ((TextBox) this.txtsAnnotazioni).Text);
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_ac_id");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(11);
      ((ParameterObject) sObject12).set_Size(10);
      ((ParameterObject) sObject12).set_Value((object) ((TextBox) this.txt_BLavoroEsterno).Text);
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_satisfaction_id");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(12);
      ((ParameterObject) sObject13).set_Size(10);
      ((ParameterObject) sObject13).set_Value((object) this.RadioButtonList1.SelectedValue);
      CollezioneControlli.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("p_sospesa");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(13);
      ((ParameterObject) sObject14).set_Size(2000);
      ((ParameterObject) sObject14).set_Value((object) ((TextBox) this.txtsSospesa).Text);
      CollezioneControlli.Add(sObject14);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("p_tipointerventoater");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Index(14);
      if (((ListControl) this.cmbsTipoIntrevento).SelectedValue == "" || ((ListControl) this.cmbsTipoIntrevento).SelectedValue == "0")
        ((ParameterObject) sObject15).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject15).set_Value((object) int.Parse(((ListControl) this.cmbsTipoIntrevento).SelectedValue));
      CollezioneControlli.Add(sObject15);
      S_Object sObject16 = new S_Object();
      ((ParameterObject) sObject16).set_ParameterName("p_importoconsuntivo");
      ((ParameterObject) sObject16).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject16).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject16).set_Index(15);
      ((ParameterObject) sObject16).set_Value((object) double.Parse(((TextBox) this.txtSpesa1).Text + "," + ((TextBox) this.txtSpesa2).Text));
      CollezioneControlli.Add(sObject16);
      S_Object sObject17 = new S_Object();
      ((ParameterObject) sObject17).set_ParameterName("p_contabilizzazione");
      ((ParameterObject) sObject17).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject17).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject17).set_Index(16);
      ((ParameterObject) sObject17).set_Value((object) 1);
      CollezioneControlli.Add(sObject17);
      S_Object sObject18 = new S_Object();
      ((ParameterObject) sObject18).set_ParameterName("p_pdfconsuntivo");
      ((ParameterObject) sObject18).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject18).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject18).set_Index(17);
      ((ParameterObject) sObject18).set_Value((object) "");
      ((ParameterObject) sObject18).set_Size(250);
      CollezioneControlli.Add(sObject18);
      S_Object sObject19 = new S_Object();
      ((ParameterObject) sObject19).set_ParameterName("p_annocontabilizzazione");
      ((ParameterObject) sObject19).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject19).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject19).set_Index(18);
      string s = DateTime.Now.Year.ToString();
      ((ParameterObject) sObject19).set_Value((object) short.Parse(s));
      CollezioneControlli.Add(sObject19);
      try
      {
        this._ClManCorrettiva.ExecuteUpdateCompletamento(CollezioneControlli, this.wr_id);
        this.UploadFile(this.UploadFileCosto, TipoPostFile.Consuntivo);
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnChiudicompleta_Click(object sender, EventArgs e) => this.Chiudi();

    private void btnfoglioprestazioni_Click(object sender, EventArgs e) => this.ScriptRapportoTecnico(int.Parse(((Label) this.S_Lblordinelavoro).Text.Trim()));

    private void BtnCostiOpera_Click(object sender, EventArgs e) => this.Response.Redirect("../ManutenzioneCorrettiva/AnalisiCostiOperativiDiGestioneDettaglio.aspx?WR_ID=" + (object) this.wr_id + "&chiamante=" + this.myType.ToString());

    private void btnfoglioprestazioniPdf_Click(object sender, EventArgs e) => this.ScriptRapportoTecnicoPdf(int.Parse(((Label) this.S_Lblordinelavoro).Text.Trim()));

    private void ScriptRapportoTecnicoPdf(int wo_id) => this.Page.RegisterStartupScript("funz", "<script language=\"javascript\">\n" + ("ApriPopUp('" + ("RapportoTecnicoInterventoPdf.aspx?WO_Id=" + wo_id.ToString()) + "')") + "</script>\n");

    private void BtnModifica_Click(object sender, EventArgs e)
    {
      this.UpdCompletamento();
      if (((ListControl) this.cmbsstatolavoro).SelectedValue == "4")
        ((Control) this.BtnCostiOpera).Visible = true;
      ((WebControl) this.btnCompleta).Enabled = false;
      ((Control) this.BtnModifica).Visible = true;
    }

    private void UpdCompletamento()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_wr_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) this.wr_id);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_urgenza");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) ((ListControl) this.cmbsUrgenza).SelectedValue.Split(Convert.ToChar(","))[0]);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(4000);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) ((TextBox) this.txtsDescrizione).Text);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_datapianificata");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Size(30);
      string str1 = string.Empty;
      string text1 = ((TextBox) this.CalendarPicker1.Datazione).Text;
      if (text1 != "")
      {
        string str2 = (((ListControl) this.cmbsOre).SelectedValue == "" ? "00" : ((ListControl) this.cmbsOre).SelectedValue) + ":" + (((ListControl) this.cmbsMinuti).SelectedValue == "" ? "00" : ((ListControl) this.cmbsMinuti).SelectedValue) + ":00";
        str1 = text1 + " " + str2;
      }
      ((ParameterObject) sObject4).set_Value((object) str1);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_id_status");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Value((object) ((ListControl) this.cmbsstatolavoro).SelectedValue);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_date_start");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject6).set_Size(30);
      string str3 = string.Empty;
      string text2 = ((TextBox) this.CalendarPicker2.Datazione).Text;
      if (text2 != "")
      {
        string str2 = (((ListControl) this.cmbsOraInizio).SelectedValue == "" ? "00" : ((ListControl) this.cmbsOraInizio).SelectedValue) + ":" + (((ListControl) this.cmbsMinutiInizio).SelectedValue == "" ? "00" : ((ListControl) this.cmbsMinutiInizio).SelectedValue) + ":00";
        str3 = text2 + " " + str2;
      }
      ((ParameterObject) sObject6).set_Value((object) str3);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_date_end");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject7).set_Size(30);
      string str4 = string.Empty;
      string text3 = ((TextBox) this.CalendarPicker3.Datazione).Text;
      if (text3 != "")
      {
        string str2 = (((ListControl) this.cmbsOraFine).SelectedValue == "" ? "00" : ((ListControl) this.cmbsOraFine).SelectedValue) + ":" + (((ListControl) this.cmbsMinutiFine).SelectedValue == "" ? "00" : ((ListControl) this.cmbsMinutiFine).SelectedValue) + ":00";
        str4 = text3 + " " + str2;
      }
      ((ParameterObject) sObject7).set_Value((object) str4);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_comments");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject8).set_Size(4000);
      ((ParameterObject) sObject8).set_Value((object) ((TextBox) this.txtsAnnotazioni).Text);
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_ac_id");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject9).set_Size(10);
      ((ParameterObject) sObject9).set_Value((object) ((TextBox) this.txt_BLavoroEsterno).Text);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_satisfaction_id");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject10).set_Size(10);
      ((ParameterObject) sObject10).set_Value((object) this.RadioButtonList1.SelectedValue);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_sospesa");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject11).set_Size(2000);
      ((ParameterObject) sObject11).set_Value((object) ((TextBox) this.txtsSospesa).Text);
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_tipointerventoater");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (((ListControl) this.cmbsTipoIntrevento).SelectedValue == "" || ((ListControl) this.cmbsTipoIntrevento).SelectedValue == "0")
        ((ParameterObject) sObject12).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject12).set_Value((object) int.Parse(((ListControl) this.cmbsTipoIntrevento).SelectedValue));
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_contabilizzazione");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject13).set_Value((object) 1);
      CollezioneControlli.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("p_pdfconsuntivo");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject14).set_Value((object) "");
      ((ParameterObject) sObject14).set_Size(250);
      CollezioneControlli.Add(sObject14);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("p_annocontabilizzazione");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Index(((CollectionBase) CollezioneControlli).Count);
      string s = DateTime.Now.Year.ToString();
      ((ParameterObject) sObject15).set_Value((object) short.Parse(s));
      CollezioneControlli.Add(sObject15);
      try
      {
        this._ClManCorrettiva.ExecuteUpdCompletamento(CollezioneControlli, this.wr_id);
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }
  }
}
