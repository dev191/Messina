// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorrettiva.CompletaRdl1
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
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManCorrettiva;
using TheSite.Classi.RptRtf;
using TheSite.WebControls;
using TheSite.XSLT;

namespace TheSite.ManutenzioneCorrettiva
{
  public class CompletaRdl1 : Page
  {
    public SiteModule _SiteModule;
    protected Label lblNote;
    protected Label lblTelefono;
    protected Label lblStanza;
    protected Label lblPiano;
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
    protected Button BtSalvaSGA;
    protected S_ComboBox cmbsServizio;
    protected S_ComboBox cmdsStdApparecchiatura;
    protected S_ComboBox cmbEQ;
    protected S_TextBox txtsDescrizione;
    protected S_TextBox txtCausa;
    protected S_TextBox txtEffettoGuasto;
    protected DataPanel PanelGeneral;
    protected S_ComboBox cmbsTipoManutenzione;
    protected S_TextBox txtImp1;
    protected S_TextBox txtImp1_1;
    protected S_TextBox txtPercentuale1;
    protected S_TextBox txtImp2_1;
    protected S_TextBox txtPercentuale2;
    protected S_TextBox txtModalitaPagamento;
    protected DataPanel Datapanel1;
    protected Label lblSeguito1;
    protected Label lblSeguito2;
    protected CalendarPicker CalendarPicker2;
    protected CalendarPicker CalendarPicker6;
    protected CalendarPicker CalendarPicker7;
    protected CalendarPicker CalendarPicker8;
    protected CalendarPicker CalendarPicker10;
    protected AggiungiSollecito AggiungiSollecito1;
    protected VisualizzaSolleciti VisualizzaSolleciti1;
    private bool IsEditable = false;
    private ClManCorrettiva _ClManCorrettiva;
    protected S_TextBox txtNoteSga;
    protected S_TextBox txtSoluzioneProposta;
    protected S_ComboBox cmbsTipoIntrevento;
    protected DataPanel Datapanel2;
    protected Repeater rpdc;
    protected Button BtUpload;
    protected HtmlInputFile UploadFile;
    protected DataPanel Datapanel3;
    protected Label LblOrdine;
    protected S_ComboBox cmbsDitta;
    protected S_ComboBox cmbsAddetto;
    protected S_ComboBox cmbsUrgenza;
    protected Label LblMessaggio;
    protected Button btRifiuta;
    protected Button btSospendi;
    protected Button btApprova;
    protected S_ComboBox cmbOra1;
    protected S_ComboBox cmbMin2;
    protected HtmlInputHidden hidBl_id;
    protected HtmlInputHidden HSga;
    protected Button btChiudi;
    protected DataPanel Datapanel4;
    protected DataPanel Datapanel5;
    protected S_ComboBox cmbsstatolavoro;
    protected TextBox txtOperazioneN;
    protected S_TextBox txtsAnnotazioni;
    protected S_ComboBox CmbMese;
    protected S_TextBox cmbDescrizioneIntervento;
    protected S_TextBox txtNoteCompletamento;
    protected DropDownList cmbStatoIntervento;
    protected Button BtDIE;
    protected Button BtSalva;
    protected Button btFoglioPdf;
    protected HtmlInputHidden HPageBack;
    protected HtmlInputHidden HPrj;
    protected HtmlInputHidden Hidden1;
    protected CheckBox CkDisser;
    protected HtmlInputFile FilePreventivo;
    protected Button BtInviaPreventivo;
    protected TextBox TxtNumPreventivo;
    protected S_TextBox txtImpPrev1;
    protected S_TextBox txtImpPrev2;
    protected HyperLink LkPrev;
    protected RadioButtonList RdListLivello;
    protected ImageButton btImgDelete;
    protected S_OptionButton OptAMisura;
    protected S_OptionButton OptAForfait;
    public int wr_id = 0;
    private double totale;
    private double tot;
    protected HyperLink LkCons;
    protected ImageButton btImgDeleteCons;
    protected Button BtInviaCons;
    protected HtmlInputFile FileConsuntivo;
    protected S_TextBox ImpCons1;
    protected S_TextBox ImpCons2;
    protected DropDownList CmbFondo;
    protected Label lblSGA;
    protected Label LblDataInvioSga;
    protected DropDownList CmbPeriodo;
    protected Label presidio;
    protected DropDownList cmbPeriodo;
    protected S_TextBox TxtAForfait;
    protected Label LblTotGenerale;
    protected Label LblTotPersonale;
    protected Label LblTotMateriali;
    protected Label LblTotale;
    protected Label lblCostiPersonale;
    protected Label lblCostoMateriali;
    protected S_TextBox txtCostiTotale2;
    protected S_TextBox txtCostiTotale1;
    protected S_TextBox txtCostiPersonale2;
    protected S_TextBox txtCostiPersonale1;
    protected S_TextBox txtCostiMateriali2;
    protected S_TextBox txtCostiMateriali1;
    protected S_ComboBox MinutiFine;
    protected S_ComboBox OraFine;
    protected S_ComboBox MinitiIni;
    protected S_ComboBox OraIni;
    protected Button btFoglio;
    protected S_TextBox txtImp2;
    protected S_ComboBox cmbminfinelav;
    protected S_ComboBox cmborafinelav;
    protected S_ComboBox S_COMBOBOX2;
    protected S_ComboBox S_COMBOBOX1;
    protected TextBox txtBuonoLavoroEster;
    private string chiamante;

    private void Page_Load(object sender, EventArgs e)
    {
      this._ClManCorrettiva = new ClManCorrettiva(this.Context.User.Identity.Name);
      this._SiteModule = new SiteModule("./ManutenzioneCorrettiva/CompletaRdl1.aspx");
      this.IsEditable = this._SiteModule.IsEditable;
      this.SetProperty();
      if (this.Request["wr_id"] != null)
        this.wr_id = int.Parse(this.Request["wr_id"]);
      if (this.Request["chiamante"] != null)
        this.chiamante = this.Request["chiamante"].ToString();
      ((Control) this.Datapanel5).Visible = true;
      DataSet dataSet = this._ClManCorrettiva.TotManodopera(this.wr_id);
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        DataRow row = dataSet.Tables[0].Rows[0];
        this.lblCostiPersonale.Text = row["totaddetto"].ToString();
        this.lblCostoMateriali.Text = row["totmateriale"].ToString();
        this.LblTotale.Text = (double.Parse(row["totaddetto"].ToString()) + double.Parse(row["totmateriale"].ToString())).ToString();
      }
      else
      {
        this.lblCostiPersonale.Text = "0";
        this.lblCostoMateriali.Text = "0";
        this.LblTotale.Text = "0";
      }
      if (!this.IsPostBack)
      {
        PropertyInfo property = this.Context.Handler.GetType().GetProperty("_Contenitore");
        if (property != null)
          this.ViewState.Add("mioContenitore", property.GetValue((object) this.Context.Handler, (object[]) null));
        if (this.chiamante == "SfogliaDoc")
        {
          string str = "SfogliaDoc.aspx";
          this.HPageBack.Value = str.Substring(str.LastIndexOf("/") + 1);
        }
        else
        {
          string filePath = this.Page.Request.FilePath;
          this.HPageBack.Value = filePath.Substring(filePath.LastIndexOf("/") + 1);
        }
        this.LoadDati();
      }
      this.SetVisible();
      this.AggiungiSollecito1.Progetto = this.HPrj.Value;
      this.AggiungiSollecito1.TxtID_WR = this.wr_id.ToString();
      this.VisualizzaSolleciti1.TxtID_WR = this.wr_id.ToString();
      this.Page.RegisterStartupScript("tipman", "<script language='javascript'>SetPreventivo(document.getElementById('" + ((Control) this.cmbsTipoManutenzione).ClientID + "').value);</script>");
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void CaricaFondi()
    {
      DataSet dataSet = new Fondi().GetFondiManutenzione(Convert.ToInt32(((ListControl) this.cmbsTipoIntrevento).SelectedValue)).Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      this.CmbFondo.DataSource = (object) dataSet.Tables[0];
      this.CmbFondo.DataTextField = "descrizione";
      this.CmbFondo.DataValueField = "id";
      this.CmbFondo.DataBind();
      DataRow row = dataSet.Tables[0].Rows[0];
    }

    private void CmbFondo_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private bool CreaPiano(int itemId)
    {
      string s1 = "";
      string s2 = "";
      string s3 = "";
      string s4 = "";
      string str = "";
      DataSet dataSet = new Fondi().GetSingleData(itemId).Copy();
      if (dataSet.Tables[0].Rows.Count == 1)
      {
        DataRow row = dataSet.Tables[0].Rows[0];
        if (row["meseini"] != DBNull.Value)
          s1 = row["meseini"].ToString();
        if (row["mesefine"] != DBNull.Value)
          s2 = row["mesefine"].ToString();
        if (row["annoini"] != DBNull.Value)
          s3 = row["annoini"].ToString();
        if (row["annofine"] != DBNull.Value)
          s4 = row["annofine"].ToString();
        if (row["periodicita"] != DBNull.Value)
          str = row["periodicita"].ToString();
        DateTime dt1 = new DateTime(int.Parse(s3), int.Parse(s1), 1);
        DateTime dt2 = new DateTime(int.Parse(s4), int.Parse(s2), 1);
        long num1 = (long) int.Parse(str);
        long num2 = CompletaRdl1.DateAndTime.DateDiff(CompletaRdl1.DateInterval.Month, dt1, dt2);
        this.cmbPeriodo.Items.Clear();
        string descri = this.GetDescri(str);
        long num3 = num2 / num1;
        for (int index = 1; (long) index <= num3; ++index)
          this.cmbPeriodo.Items.Add(new ListItem(index.ToString() + "° " + descri, index.ToString()));
      }
      return false;
    }

    private string GetDescri(string val)
    {
      if (val == "1")
        return "Mese";
      if (val == "2")
        return "Bimestre";
      if (val == "3")
        return "Trimestre";
      if (val == "4")
        return "Quadrimestre";
      if (val == "6")
        return "Semestre";
      return val == "12" ? "Anno" : "";
    }

    protected string FormattaDecimali(object numero, object cifre)
    {
      NumberFormatInfo numberFormat = new CultureInfo("it-IT", false).NumberFormat;
      numberFormat.NumberDecimalDigits = Convert.ToInt32(cifre);
      return Convert.ToDecimal(numero).ToString("N", (IFormatProvider) numberFormat);
    }

    private bool IsCompleta
    {
      get => this.ViewState[nameof (IsCompleta)] != null && (bool) this.ViewState[nameof (IsCompleta)];
      set => this.ViewState.Add(nameof (IsCompleta), (object) value);
    }

    private bool IsCompletata
    {
      get => this.ViewState[nameof (IsCompletata)] != null && (bool) this.ViewState[nameof (IsCompletata)];
      set => this.ViewState.Add("IsCompleta", (object) value);
    }

    private void SetProperty()
    {
      this.FileConsuntivo.Attributes.Add("onchange", "return checkFileExtension(this);");
      this.FilePreventivo.Attributes.Add("onchange", "return checkFileExtension(this);");
      ((WebControl) this.txtImpPrev1).Attributes.Add("onkeypress", "return caratteriok(event,'0123456789');");
      ((WebControl) this.txtImpPrev2).Attributes.Add("onkeypress", "return caratteriok(event,'0123456789');");
      ((WebControl) this.txtImp1).Attributes.Add("onkeypress", "return caratteriok(event,'0123456789');");
      ((WebControl) this.txtImp1_1).Attributes.Add("onkeypress", "return caratteriok(event,'0123456789');");
      ((WebControl) this.txtImp2).Attributes.Add("onkeypress", "return caratteriok(event,'0123456789');");
      ((WebControl) this.txtImp2_1).Attributes.Add("onkeypress", "return caratteriok(event,'0123456789');");
      ((WebControl) this.txtCostiTotale1).Attributes.Add("onkeypress", "return caratteriok(event,'0123456789');");
      ((WebControl) this.txtCostiMateriali1).Attributes.Add("onkeypress", "return caratteriok(event,'0123456789');");
      ((WebControl) this.txtCostiPersonale1).Attributes.Add("onkeypress", "return caratteriok(event,'0123456789');");
      ((WebControl) this.txtCostiMateriali1).Attributes.Add("onkeyup", "somma();");
      ((WebControl) this.txtCostiPersonale1).Attributes.Add("onkeyup", "somma()");
      ((WebControl) this.txtCostiMateriali2).Attributes.Add("onkeyup", "somma();");
      ((WebControl) this.txtCostiPersonale2).Attributes.Add("onkeyup", "somma()");
      ((WebControl) this.txtCostiTotale1).Attributes.Add("onkeyup", "somma()");
      ((WebControl) this.txtCostiTotale2).Attributes.Add("onkeyup", "somma()");
      ((WebControl) this.txtCostiTotale2).Attributes.Add("onkeypress", "return caratteriok(event,'0123456789');");
      ((WebControl) this.txtCostiMateriali2).Attributes.Add("onkeypress", "return caratteriok(event,'0123456789');");
      ((WebControl) this.txtCostiPersonale2).Attributes.Add("onkeypress", "return caratteriok(event,'0123456789');");
      ((WebControl) this.txtImpPrev1).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtImpPrev2).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtImp1).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtImp1_1).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtImp2).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtImp2_1).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtCostiTotale1).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtCostiMateriali1).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtCostiPersonale1).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtCostiTotale2).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtCostiMateriali2).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.txtCostiPersonale2).Attributes.Add("onpaste", "return false;");
      this.TxtNumPreventivo.Attributes.Add("onpaste", "return false;");
      this.TxtNumPreventivo.Attributes.Add("onkeypress", "return caratteriok(event,'0123456789');");
      ((WebControl) this.ImpCons1).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.ImpCons1).Attributes.Add("onkeypress", "return caratteriok(event,'0123456789');");
      ((WebControl) this.ImpCons2).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.ImpCons2).Attributes.Add("onkeypress", "return caratteriok(event,'0123456789');");
      this.BtSalvaSGA.Attributes.Add("onclick", "return IsValidDateWork();");
      this.btApprova.Attributes.Add("onclick", "return IsEmissione();");
      this.BtSalva.Attributes.Add("onclick", "return IsCompleta();");
      this.BtDIE.Attributes.Add("onclick", "return IsCompleta();");
      this.btImgDelete.Attributes.Add("onclick", "return deletedoc();");
      ((WebControl) this.OptAMisura).Attributes.Add("onclick", "VisualizzaNote('" + ((Control) this.OptAForfait).ClientID + "' );");
      ((WebControl) this.OptAForfait).Attributes.Add("onclick", "VisualizzaNote('" + ((Control) this.OptAForfait).ClientID + "' );");
      this.btImgDelete.Attributes.Add("onclick", "return confirm('Eliminare il documento del Preventivo allegato?');");
      this.btImgDeleteCons.Attributes.Add("onclick", "return confirm('Eliminare il documento del Consuntivo allegato?');");
    }

    private void SetVisisbleCompletata()
    {
      this.btImgDelete.Visible = false;
      ((WebControl) this.cmbEQ).Enabled = false;
      ((WebControl) this.cmbsServizio).Enabled = false;
      ((WebControl) this.cmdsStdApparecchiatura).Enabled = false;
      this.BtInviaPreventivo.Enabled = false;
      ((Control) this.Datapanel4).Visible = true;
    }

    private void DisableControl(Control ctrl)
    {
      foreach (Control control in ctrl.Controls)
      {
        switch (control)
        {
          case TextBox _:
          case DropDownList _:
          case RadioButton _:
          case CheckBox _:
            if (control is TextBox)
              ((WebControl) control).Enabled = false;
            if (control is DropDownList)
              ((WebControl) control).Enabled = false;
            if (control is RadioButton)
              ((WebControl) control).Enabled = false;
            if (control is CheckBox)
            {
              ((WebControl) control).Enabled = false;
              continue;
            }
            continue;
          default:
            continue;
        }
      }
    }

    private void SetVisible()
    {
      if (this.IsCompleta)
      {
        this.btApprova.Visible = false;
        this.btSospendi.Visible = false;
        this.btRifiuta.Visible = false;
        ((Control) this.Datapanel4).Visible = true;
        ((Control) this.Datapanel5).Visible = true;
        this.Datapanel3.set_Collapsed(true);
        this.Datapanel2.set_Collapsed(true);
        this.Datapanel1.set_Collapsed(true);
        this.BtSalva.Visible = true;
        if (!this.Context.User.IsInRole("callcenter"))
          this.Page.RegisterStartupScript("sr", "<script language='javascript'>SetStato(document.getElementById('" + ((Control) this.cmbsstatolavoro).ClientID + "').value);</script>");
      }
      else
      {
        ((Control) this.Datapanel4).Visible = false;
        ((Control) this.Datapanel5).Visible = false;
      }
      if (this.Context.User.IsInRole("TecnicoPapardo"))
      {
        ((Control) this.Datapanel2).Visible = false;
        this.btApprova.Visible = false;
        this.btSospendi.Visible = false;
        this.btRifiuta.Visible = false;
        this.BtDIE.Visible = false;
        this.BtSalva.Visible = false;
        this.btFoglio.Visible = false;
        this.btFoglioPdf.Visible = false;
        this.BtDIE.Visible = false;
      }
      if (!this.Context.User.IsInRole("callcenter"))
        return;
      ((Control) this.Datapanel2).Visible = false;
      this.btApprova.Visible = false;
      this.btSospendi.Visible = false;
      this.btRifiuta.Visible = false;
      ((Control) this.Datapanel4).Visible = false;
      ((Control) this.Datapanel5).Visible = false;
    }

    private void LoadDati()
    {
      this.LoadTipoManutenzione();
      this.LoadTipoIntervento();
      DataSet singleRdlNew = this._ClManCorrettiva.GetSingleRdlNew(this.wr_id);
      if (singleRdlNew.Tables[0].Rows.Count == 0)
        return;
      DataRow row1 = singleRdlNew.Tables[0].Rows[0];
      this.LoadDitte(int.Parse(row1["id_bl"].ToString()));
      this.hidBl_id.Value = row1["id_bl"].ToString();
      this.txtHidBl.Text = row1["bl_id"].ToString();
      this.LoadDocument();
      this.LoadDocumentCons();
      this.HPrj.Value = row1["id_progetto"].ToString();
      this.LblRdl.Text = row1["id"].ToString();
      if (row1["id_wr_status"] != DBNull.Value && row1["id_wr_status"].ToString() == "6")
      {
        this.btApprova.Visible = false;
        this.btSospendi.Visible = false;
        this.btRifiuta.Visible = false;
        ((Control) this.Datapanel4).Visible = true;
      }
      if (row1["id_wr_status"].ToString() == "1" || row1["id_wr_status"].ToString() == "7" || row1["id_wr_status"].ToString() == "15")
        this.IsCompleta = false;
      if (row1["id_wr_status"].ToString() != "1" && row1["id_wr_status"].ToString() != "7" && row1["id_wr_status"].ToString() != "15")
        this.IsCompleta = true;
      this.SetVisible();
      if (row1["id_wr_status"].ToString() == "4")
      {
        ((WebControl) this.cmbsstatolavoro).Enabled = false;
        this.BtSalva.Attributes.Add("onclick", "return SgaSalvata();");
        this.BtDIE.Attributes.Add("onclick", "return SgaSalvata();");
      }
      if (row1["wo_id"] != DBNull.Value)
        this.LblOrdine.Text = row1["wo_id"].ToString();
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
      if (row1["dataRichiesta"] != DBNull.Value)
        this.lblDataRichiesta.Text = DateTime.Parse(row1["dataRichiesta"].ToString()).ToShortDateString();
      if (row1["dataRichiesta"] != DBNull.Value)
        this.lblOraRichiesta.Text = DateTime.Parse(row1["dataRichiesta"].ToString()).ToShortTimeString();
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
      this.LoadServizio(row1["id_bl"].ToString());
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
      DateTime dateTime1;
      if (row1["datafine"] != DBNull.Value)
      {
        S_TextBox datazione = this.CalendarPicker2.Datazione;
        dateTime1 = DateTime.Parse(row1["datafine"].ToString());
        string shortDateString = dateTime1.ToShortDateString();
        ((TextBox) datazione).Text = shortDateString;
      }
      else
        ((TextBox) this.CalendarPicker2.Datazione).Text = "";
      if (row1["datafine"] != DBNull.Value)
      {
        DateTime dateTime2 = DateTime.Parse(row1["datafine"].ToString());
        ((ListControl) this.cmborafinelav).SelectedValue = dateTime2.Hour.ToString().PadLeft(2, Convert.ToChar("0"));
        ((ListControl) this.cmbminfinelav).SelectedValue = dateTime2.Minute.ToString().PadLeft(2, Convert.ToChar("0"));
      }
      if (row1["date_est_completion"] != DBNull.Value)
      {
        S_TextBox datazione = this.CalendarPicker10.Datazione;
        dateTime1 = DateTime.Parse(row1["date_est_completion"].ToString());
        string shortDateString = dateTime1.ToShortDateString();
        ((TextBox) datazione).Text = shortDateString;
      }
      else
        ((TextBox) this.CalendarPicker10.Datazione).Text = "";
      if (row1["datafine"] != DBNull.Value)
      {
        DateTime dateTime2 = DateTime.Parse(row1["datafine"].ToString());
        ((ListControl) this.cmborafinelav).SelectedValue = dateTime2.Hour.ToString().PadLeft(2, Convert.ToChar("0"));
        ((ListControl) this.cmbminfinelav).SelectedValue = dateTime2.Minute.ToString().PadLeft(2, Convert.ToChar("0"));
      }
      if (row1["tipomanutenzione_id"] != DBNull.Value)
        ((ListControl) this.cmbsTipoManutenzione).SelectedValue = row1["tipomanutenzione_id"].ToString();
      if (row1["tipointervento_id"] != DBNull.Value)
        ((ListControl) this.cmbsTipoIntrevento).SelectedValue = row1["tipointervento_id"].ToString();
      if (row1["SGA_IMPORTO_PRESUNTO"] != DBNull.Value && row1["SGA_IMPORTO_PRESUNTO"].ToString() != "0")
      {
        ((TextBox) this.txtImp1).Text = TheSite.Classi.Function.GetTypeNumber(row1["SGA_IMPORTO_PRESUNTO"], NumberType.Intero);
        ((TextBox) this.txtImp1_1).Text = TheSite.Classi.Function.GetTypeNumber(row1["SGA_IMPORTO_PRESUNTO"], NumberType.Decimale);
      }
      else
      {
        ((TextBox) this.txtImp1).Text = "0";
        ((TextBox) this.txtImp1_1).Text = "00";
      }
      if (row1["SGA_IMPORTO_FORFE"] != DBNull.Value && row1["SGA_IMPORTO_FORFE"].ToString() != "0")
      {
        ((TextBox) this.txtImp2).Text = TheSite.Classi.Function.GetTypeNumber(row1["SGA_IMPORTO_FORFE"], NumberType.Intero);
        ((TextBox) this.txtImp2_1).Text = TheSite.Classi.Function.GetTypeNumber(row1["SGA_IMPORTO_FORFE"], NumberType.Decimale);
      }
      else
      {
        ((TextBox) this.txtImp2).Text = "0";
        ((TextBox) this.txtImp2_1).Text = "00";
      }
      if (row1["SGA"] != DBNull.Value)
        this.HSga.Value = row1["SGA"].ToString();
      if (row1["SGA"] != DBNull.Value)
        this.lblSGA.Text = row1["SGA"].ToString();
      this.LoadDataInvioSGA();
      if (row1["SGA_PRESUNTO_IVA"] != DBNull.Value)
        ((TextBox) this.txtPercentuale1).Text = row1["SGA_PRESUNTO_IVA"].ToString();
      if (row1["SGA_FORFE_IVA"] != DBNull.Value)
        ((TextBox) this.txtPercentuale2).Text = row1["SGA_FORFE_IVA"].ToString();
      if (row1["SGA_MODALITA_PAGAMENTO"] != DBNull.Value)
        ((TextBox) this.txtModalitaPagamento).Text = row1["SGA_MODALITA_PAGAMENTO"].ToString();
      if (row1["SGA_NOTE"] != DBNull.Value)
        ((TextBox) this.txtNoteSga).Text = row1["SGA_NOTE"].ToString();
      if (row1["SGA_SOLUZIONE_PROP"] != DBNull.Value)
        ((TextBox) this.txtSoluzioneProposta).Text = row1["SGA_SOLUZIONE_PROP"].ToString();
      if (row1["sga_anomalia"] != DBNull.Value)
        ((TextBox) this.txtCausa).Text = row1["sga_anomalia"].ToString();
      if (row1["sga_effetto"] != DBNull.Value)
        ((TextBox) this.txtEffettoGuasto).Text = row1["sga_effetto"].ToString();
      if (row1["ditta_id"] != DBNull.Value)
      {
        ((ListControl) this.cmbsDitta).SelectedValue = row1["ditta_id"].ToString();
        this.LoadAddettiDitta(row1["bl_id"].ToString(), int.Parse(((ListControl) this.cmbsDitta).SelectedValue));
      }
      if (row1["addetto_id"] != DBNull.Value)
        ((ListControl) this.cmbsAddetto).SelectedValue = row1["addetto_id"].ToString();
      this.LoadUrgenze(row1["id_bl"].ToString());
      if (row1["priorita"] != DBNull.Value)
        ((ListControl) this.cmbsUrgenza).SelectedValue = row1["priorita"].ToString();
      if (row1["order_estimate_id"] != DBNull.Value)
        this.TxtNumPreventivo.Text = row1["order_estimate_id"].ToString();
      if (row1["cost_est_other"] != DBNull.Value)
      {
        ((TextBox) this.txtImpPrev1).Text = TheSite.Classi.Function.GetTypeNumber(row1["cost_est_other"], NumberType.Intero);
        ((TextBox) this.txtImpPrev2).Text = TheSite.Classi.Function.GetTypeNumber(row1["cost_est_other"], NumberType.Decimale);
      }
      else
      {
        ((TextBox) this.txtImpPrev1).Text = "0";
        ((TextBox) this.txtImpPrev2).Text = "00";
      }
      if (row1["fpath_estimate"] != DBNull.Value)
      {
        this.btImgDelete.Visible = true;
        this.LkPrev.Visible = true;
      }
      else
      {
        this.btImgDelete.Visible = false;
        this.LkPrev.Visible = false;
      }
      DataSet statusRdl = this._ClManCorrettiva.GetStatusRdl(this.wr_id);
      if (statusRdl.Tables[0].Rows.Count > 0)
      {
        DataRow row2 = statusRdl.Tables[0].Rows[0];
        this.LblMessaggio.Text = "Stato della Richiesta di Lavoro : " + row2["descrizione"].ToString() + " in data: " + row2["data"];
      }
      if (row1["datapianificata"] != DBNull.Value)
      {
        S_TextBox datazione = this.CalendarPicker6.Datazione;
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
        ((ListControl) this.cmbOra1).SelectedValue = str1.PadLeft(2, Convert.ToChar("0"));
        ((ListControl) this.cmbMin2).SelectedValue = str2.PadLeft(2, Convert.ToChar("0"));
      }
      if (!this.IsCompleta)
        return;
      this.SetVisisbleCompletata();
      this.LoadStatoLavoro();
      this.LoadStatoIntervento();
      ((ListControl) this.cmbsTipoIntrevento).SelectedIndexChanged += new EventHandler(this.cmbsTipoIntrevento_SelectedIndexChanged);
      ((ListControl) this.cmbsTipoIntrevento).AutoPostBack = true;
      ((ListControl) this.cmbsstatolavoro).SelectedValue = row1["idstatus"].ToString();
      if (row1["cost_total"] != DBNull.Value)
      {
        ((TextBox) this.ImpCons1).Text = TheSite.Classi.Function.GetTypeNumber(row1["cost_total"], NumberType.Intero);
        ((TextBox) this.ImpCons2).Text = TheSite.Classi.Function.GetTypeNumber(row1["cost_total"], NumberType.Decimale);
      }
      else
      {
        ((TextBox) this.ImpCons1).Text = "0";
        ((TextBox) this.ImpCons2).Text = "00";
      }
      if (row1["fpath_consumptive"] != DBNull.Value)
      {
        this.btImgDeleteCons.Visible = true;
        this.LkCons.Visible = true;
      }
      else
      {
        this.btImgDeleteCons.Visible = false;
        this.LkCons.Visible = false;
      }
      if (row1["notesospesa"] != DBNull.Value)
        ((TextBox) this.txtsAnnotazioni).Text = row1["notesospesa"].ToString();
      if (row1["forfait_note"] != DBNull.Value)
        ((TextBox) this.TxtAForfait).Text = row1["forfait_note"].ToString();
      if (row1["forfait"] != DBNull.Value)
      {
        ((CheckBox) this.OptAForfait).Checked = !(row1["forfait"].ToString() == "0");
        if (row1["forfait"].ToString() == "0")
          ((WebControl) this.TxtAForfait).Enabled = false;
        else
          ((WebControl) this.TxtAForfait).Enabled = true;
      }
      else
        ((CheckBox) this.OptAMisura).Checked = true;
      if (row1["date_start"] != DBNull.Value)
      {
        S_TextBox datazione = this.CalendarPicker7.Datazione;
        dateTime1 = DateTime.Parse(row1["date_start"].ToString());
        string shortDateString = dateTime1.ToShortDateString();
        ((TextBox) datazione).Text = shortDateString;
      }
      if (row1["date_end"] != DBNull.Value)
      {
        S_TextBox datazione = this.CalendarPicker8.Datazione;
        dateTime1 = DateTime.Parse(row1["date_end"].ToString());
        string shortDateString = dateTime1.ToShortDateString();
        ((TextBox) datazione).Text = shortDateString;
      }
      if (row1["date_start"] != DBNull.Value)
      {
        DateTime dateTime2 = DateTime.Parse(row1["date_start"].ToString());
        S_ComboBox oraIni = this.OraIni;
        num = dateTime2.Hour;
        string str1 = num.ToString().PadLeft(2, Convert.ToChar("0"));
        ((ListControl) oraIni).SelectedValue = str1;
        S_ComboBox minitiIni = this.MinitiIni;
        num = dateTime2.Minute;
        string str2 = num.ToString().PadLeft(2, Convert.ToChar("0"));
        ((ListControl) minitiIni).SelectedValue = str2;
      }
      if (row1["date_end"] != DBNull.Value)
      {
        DateTime dateTime2 = DateTime.Parse(row1["date_end"].ToString());
        S_ComboBox oraFine = this.OraFine;
        num = dateTime2.Hour;
        string str1 = num.ToString().PadLeft(2, Convert.ToChar("0"));
        ((ListControl) oraFine).SelectedValue = str1;
        S_ComboBox minutiFine = this.MinutiFine;
        num = dateTime2.Minute;
        string str2 = num.ToString().PadLeft(2, Convert.ToChar("0"));
        ((ListControl) minutiFine).SelectedValue = str2;
      }
      if (row1["date_est_completion"] != DBNull.Value)
      {
        S_TextBox datazione = this.CalendarPicker10.Datazione;
        dateTime1 = DateTime.Parse(row1["date_est_completion"].ToString());
        string shortDateString = dateTime1.ToShortDateString();
        ((TextBox) datazione).Text = shortDateString;
      }
      if (row1["date_est_completion"] != DBNull.Value)
      {
        DateTime dateTime2 = DateTime.Parse(row1["date_est_completion"].ToString());
        S_ComboBox comboboX2 = this.S_COMBOBOX2;
        num = dateTime2.Hour;
        string str1 = num.ToString().PadLeft(2, Convert.ToChar("0"));
        ((ListControl) comboboX2).SelectedValue = str1;
        S_ComboBox comboboX1 = this.S_COMBOBOX1;
        num = dateTime2.Minute;
        string str2 = num.ToString().PadLeft(2, Convert.ToChar("0"));
        ((ListControl) comboboX1).SelectedValue = str2;
      }
      if (row1["comments"] != DBNull.Value)
        ((TextBox) this.cmbDescrizioneIntervento).Text = row1["comments"].ToString();
      if (row1["AC_ID"] != DBNull.Value)
        this.txtBuonoLavoroEster.Text = row1["AC_ID"].ToString();
      if (row1["DISSERVIZIO"] != DBNull.Value)
        this.CkDisser.Checked = int.Parse(row1["DISSERVIZIO"].ToString()) == 1;
      if (row1["DIE_TIPO_INTERVENTO"] != DBNull.Value)
        this.cmbStatoIntervento.SelectedValue = row1["DIE_TIPO_INTERVENTO"].ToString();
      if (row1["DIE_REGISTRO"] != DBNull.Value)
        this.txtOperazioneN.Text = row1["DIE_REGISTRO"].ToString();
      if (row1["DIE_MESE"] != DBNull.Value)
        ((ListControl) this.CmbMese).SelectedValue = row1["DIE_MESE"].ToString();
      if (row1["DIE_COSTO_MATERIALE"] != DBNull.Value)
      {
        ((TextBox) this.txtCostiMateriali1).Text = TheSite.Classi.Function.GetTypeNumber(row1["DIE_COSTO_MATERIALE"], NumberType.Intero);
        ((TextBox) this.txtCostiMateriali2).Text = TheSite.Classi.Function.GetTypeNumber(row1["DIE_COSTO_MATERIALE"], NumberType.Decimale);
      }
      else
      {
        ((TextBox) this.txtCostiMateriali1).Text = "0";
        ((TextBox) this.txtCostiMateriali2).Text = "00";
      }
      if (row1["DIE_COSTO_PERSONALE"] != DBNull.Value)
      {
        ((TextBox) this.txtCostiPersonale1).Text = TheSite.Classi.Function.GetTypeNumber(row1["DIE_COSTO_PERSONALE"], NumberType.Intero);
        ((TextBox) this.txtCostiPersonale2).Text = TheSite.Classi.Function.GetTypeNumber(row1["DIE_COSTO_PERSONALE"], NumberType.Decimale);
      }
      else
      {
        ((TextBox) this.txtCostiPersonale1).Text = "0";
        ((TextBox) this.txtCostiPersonale2).Text = "00";
      }
      if (row1["DIE_COSTO_TOTALE"] != DBNull.Value)
      {
        ((TextBox) this.txtCostiTotale1).Text = TheSite.Classi.Function.GetTypeNumber(row1["DIE_COSTO_TOTALE"], NumberType.Intero);
        ((TextBox) this.txtCostiTotale2).Text = TheSite.Classi.Function.GetTypeNumber(row1["DIE_COSTO_TOTALE"], NumberType.Decimale);
      }
      else
      {
        ((TextBox) this.txtCostiTotale1).Text = "0";
        ((TextBox) this.txtCostiTotale2).Text = "00";
      }
      if (row1["DIE_NOTE"] != DBNull.Value)
        ((TextBox) this.txtNoteCompletamento).Text = row1["DIE_NOTE"].ToString();
      if (row1["satisfaction_id"] == DBNull.Value)
        return;
      this.RdListLivello.SelectedValue = row1["satisfaction_id"].ToString();
    }

    private void LoadDocument()
    {
      DataSet documentazione = this._ClManCorrettiva.GetDocumentazione(this.wr_id, "DOC");
      if (documentazione.Tables[0].Rows.Count == 0)
      {
        this.rpdc.Visible = false;
      }
      else
      {
        this.rpdc.Visible = true;
        this.rpdc.DataSource = (object) documentazione.Tables[0];
        this.rpdc.DataBind();
      }
    }

    private void LoadDataInvioSGA()
    {
      DataSet dataInvioSga = this._ClManCorrettiva.GetDataInvioSga(this.wr_id, DocType.SGA);
      if (dataInvioSga.Tables[0].Rows.Count != 1)
        return;
      this.LblDataInvioSga.Text = "Data invio: " + dataInvioSga.Tables[0].Rows[0]["data_invio"].ToString();
    }

    private void LoadTipoManutenzione()
    {
      DataSet tipoManutenzione = this._ClManCorrettiva.GetTipoManutenzione();
      if (tipoManutenzione.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsTipoManutenzione).DataSource = (object) tipoManutenzione.Tables[0];
      ((ListControl) this.cmbsTipoManutenzione).DataTextField = "descrizione";
      ((ListControl) this.cmbsTipoManutenzione).DataValueField = "id";
      ((Control) this.cmbsTipoManutenzione).DataBind();
      ((WebControl) this.cmbsTipoManutenzione).Attributes.Add("onchange", "SetPreventivo(this.value);");
    }

    private void LoadStatoIntervento()
    {
      DataSet statoInetervento = this._ClManCorrettiva.GetStatoInetervento();
      if (statoInetervento.Tables[0].Rows.Count <= 0)
        return;
      this.cmbStatoIntervento.Items.Clear();
      this.cmbStatoIntervento.DataSource = (object) statoInetervento.Tables[0];
      this.cmbStatoIntervento.DataTextField = "descrizione";
      this.cmbStatoIntervento.DataValueField = "id";
      this.cmbStatoIntervento.DataBind();
    }

    private void LoadStatoLavoro()
    {
      ((ListControl) this.cmbsstatolavoro).Items.Clear();
      DataSet statoLavoro = this._ClManCorrettiva.GetStatoLavoro();
      if (statoLavoro.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsstatolavoro).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(statoLavoro.Tables[0], "descrizione", "id", "- Selezionare lo Stato di Lavoro  -", "");
        ((ListControl) this.cmbsstatolavoro).DataTextField = "descrizione";
        ((ListControl) this.cmbsstatolavoro).DataValueField = "id";
        ((Control) this.cmbsstatolavoro).DataBind();
        ((WebControl) this.cmbsstatolavoro).Attributes.Add("onchange", "SetStato(this.value);");
      }
      else
        ((ListControl) this.cmbsstatolavoro).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuno Stato di Lavoro  -", string.Empty));
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

    private void LoadServizio(string CodiceEdificio)
    {
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) CodiceEdificio);
      CollezioneControlli.Add(sObject);
      DataSet serviceBulding2 = this._ClManCorrettiva.GetServiceBulding2(CollezioneControlli);
      if (serviceBulding2.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(serviceBulding2.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "Non Definito", "");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("Non Definito", ""));
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
        ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject1).set_Value((object) "");
        CollezioneControlli.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_Servizio");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject2).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
        CollezioneControlli.Add(sObject2);
        S_Object sObject3 = new S_Object();
        ((ParameterObject) sObject3).set_ParameterName("p_eqstdid");
        ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject3).set_Size(8);
        ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject3).set_Value((object) (((ListControl) this.cmdsStdApparecchiatura).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmdsStdApparecchiatura).SelectedValue)));
        CollezioneControlli.Add(sObject3);
        DataSet listaEq = this._ClManCorrettiva.GetListaEQ(CollezioneControlli);
        if (listaEq.Tables[0].Rows.Count > 0)
        {
          ((BaseDataBoundControl) this.cmbEQ).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(listaEq.Tables[0], "ID", "id_eq", "- Selezionare un' Apparecchiatura -", "");
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
        this.LoadAddettiDitta("", Convert.ToInt32(((ListControl) this.cmbsDitta).SelectedValue));
      }
      else
        ((ListControl) this.cmbsDitta).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Ditta  -", "0"));
    }

    private void LoadUrgenze(string Codice)
    {
      if (Codice != "")
      {
        int int32 = Convert.ToInt32(Codice);
        Urgenza urgenza = new Urgenza();
        ((ListControl) this.cmbsUrgenza).Items.Clear();
        ((BaseDataBoundControl) this.cmbsUrgenza).DataSource = (object) urgenza.GetPriorita(int32);
        ((ListControl) this.cmbsUrgenza).DataTextField = "DESCRIPTION";
        ((ListControl) this.cmbsUrgenza).DataValueField = "ID";
        ((Control) this.cmbsUrgenza).DataBind();
      }
      else
        ((ListControl) this.cmbsUrgenza).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna urgenza -", string.Empty));
    }

    private void LoadAddettiDitta(string bl_id, int ditta_id)
    {
      ((ListControl) this.cmbsAddetto).Items.Clear();
      DataSet addetti = this._ClManCorrettiva.GetAddetti("", bl_id, ditta_id);
      if (addetti.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsAddetto).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(addetti.Tables[0], "NOMINATIVO", "ID", "- Selezionare un Addetto -", "0");
        ((ListControl) this.cmbsAddetto).DataTextField = "NOMINATIVO";
        ((ListControl) this.cmbsAddetto).DataValueField = "ID";
        ((Control) this.cmbsAddetto).DataBind();
      }
      else
        ((ListControl) this.cmbsAddetto).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Addetto  -", "0"));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsTipoIntrevento).SelectedIndexChanged += new EventHandler(this.cmbsTipoIntrevento_SelectedIndexChanged);
      this.BtSalvaSGA.Click += new EventHandler(this.BtSalvaSGA_Click);
      this.BtUpload.Click += new EventHandler(this.BtUpload_Click);
      this.rpdc.ItemDataBound += new RepeaterItemEventHandler(this.rpdc_ItemDataBound);
      this.rpdc.ItemCommand += new RepeaterCommandEventHandler(this.rpdc_ItemCommand);
      ((ListControl) this.cmbsDitta).SelectedIndexChanged += new EventHandler(this.cmbsDitta_SelectedIndexChanged);
      this.BtInviaPreventivo.Click += new EventHandler(this.BtInviaPreventivo_Click);
      this.btImgDelete.Click += new ImageClickEventHandler(this.btImgDelete_Click);
      this.btRifiuta.Click += new EventHandler(this.btRifiuta_Click);
      this.btSospendi.Click += new EventHandler(this.btSospendi_Click);
      this.btApprova.Click += new EventHandler(this.btApprova_Click);
      this.BtSalva.Click += new EventHandler(this.BtSalva_Click);
      this.btFoglioPdf.Click += new EventHandler(this.btFoglioPdf_Click);
      this.btFoglio.Click += new EventHandler(this.btFoglio_Click);
      this.BtDIE.Click += new EventHandler(this.BtDIE_Click);
      this.btChiudi.Click += new EventHandler(this.btChiudi_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void BtSalvaSGA_Click(object sender, EventArgs e)
    {
      this.SaveSGA();
      this.SendSGA();
      this.LoadDati();
    }

    private void SendSGA()
    {
      string DataCreate = DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
      string str = this.Server.MapPath(this.Request.ApplicationPath + (!(this.HPrj.Value == "2") ? "\\XSLT\\XSLsgaRpt04.xslt" : "\\XSLT\\XSLsgaRptVod04.xslt"));
      string[] strArray = new SGARTF() { FileXlst = str }.GeneraRtf(this.wr_id, DataCreate);
      MailSend mailSend = new MailSend();
      this.SaveInvio(strArray[1], DocType.SGA);
      mailSend.SendMail(strArray[0], this.wr_id, DocType.SGA);
    }

    private S_ControlsCollection GetSgaParameter()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_wr_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject1).set_Value((object) this.wr_id);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_servizio");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count);
      if (((ListControl) this.cmbsServizio).SelectedValue == "" || ((ListControl) this.cmbsServizio).SelectedValue == "0")
        ((ParameterObject) sObject2).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject2).set_Value((object) int.Parse(((ListControl) this.cmbsServizio).SelectedValue));
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_stdapparechhiatura");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) controlsCollection).Count);
      if (((ListControl) this.cmdsStdApparecchiatura).SelectedValue == "" || ((ListControl) this.cmdsStdApparecchiatura).SelectedValue == "0")
        ((ParameterObject) sObject3).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject3).set_Value((object) int.Parse(((ListControl) this.cmdsStdApparecchiatura).SelectedValue));
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_eq");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) controlsCollection).Count);
      if (((ListControl) this.cmbEQ).SelectedValue == "" || ((ListControl) this.cmbEQ).SelectedValue == "0")
        ((ParameterObject) sObject4).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject4).set_Value((object) int.Parse(((ListControl) this.cmbEQ).SelectedValue));
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size(4000);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject5).set_Value((object) ((TextBox) this.txtsDescrizione).Text);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_anomalia");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Size(408);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject6).set_Value((object) ((TextBox) this.txtCausa).Text);
      controlsCollection.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_effetto");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(408);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject7).set_Value((object) ((TextBox) this.txtEffettoGuasto).Text);
      controlsCollection.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_soluzione");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Size(408);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject8).set_Value((object) ((TextBox) this.txtSoluzioneProposta).Text);
      controlsCollection.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_datefine");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 5);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) controlsCollection).Count);
      if (((TextBox) this.CalendarPicker2.Datazione).Text == "")
      {
        ((ParameterObject) sObject9).set_Value((object) DBNull.Value);
      }
      else
      {
        string empty = string.Empty;
        string str1 = ((TextBox) this.CalendarPicker2.Datazione).Text;
        if (str1 != "")
        {
          string str2 = (((ListControl) this.cmborafinelav).SelectedValue == "" ? "00" : ((ListControl) this.cmborafinelav).SelectedValue) + ":" + (((ListControl) this.cmbminfinelav).SelectedValue == "" ? "00" : ((ListControl) this.cmbminfinelav).SelectedValue) + ":00";
          str1 = str1 + " " + str2;
        }
        if (str1 != "")
          ((ParameterObject) sObject9).set_Value((object) str1);
        else
          ((ParameterObject) sObject9).set_Value((object) DBNull.Value);
      }
      controlsCollection.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_tipomanutenzione");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject10).set_Value((object) int.Parse(((ListControl) this.cmbsTipoManutenzione).SelectedValue));
      controlsCollection.Add(sObject10);
      if (((ListControl) this.cmbsTipoManutenzione).SelectedValue != "3")
      {
        ((TextBox) this.txtImp1).Text = "";
        ((TextBox) this.txtImp1_1).Text = "";
        ((TextBox) this.txtImp2).Text = "";
        ((TextBox) this.txtImp2_1).Text = "";
        ((TextBox) this.txtPercentuale1).Text = "";
        ((TextBox) this.txtPercentuale2).Text = "";
      }
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_tipointervento");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject11).set_Value((object) int.Parse(((ListControl) this.cmbsTipoIntrevento).SelectedValue));
      controlsCollection.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_presunto");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(((CollectionBase) controlsCollection).Count);
      if (((TextBox) this.txtImp1).Text == "")
        ((ParameterObject) sObject12).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject12).set_Value((object) double.Parse(((TextBox) this.txtImp1).Text + "," + ((TextBox) this.txtImp1_1).Text));
      controlsCollection.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_presunto_iva");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(((CollectionBase) controlsCollection).Count);
      if (((TextBox) this.txtPercentuale1).Text == "")
        ((ParameterObject) sObject13).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject13).set_Value((object) int.Parse(((TextBox) this.txtPercentuale1).Text));
      controlsCollection.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("p_forfe");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(((CollectionBase) controlsCollection).Count);
      if (((TextBox) this.txtImp2).Text == "")
        ((ParameterObject) sObject14).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject14).set_Value((object) double.Parse(((TextBox) this.txtImp2).Text + "," + ((TextBox) this.txtImp2_1).Text));
      controlsCollection.Add(sObject14);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("p_forfe_iva");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Index(((CollectionBase) controlsCollection).Count);
      if (((TextBox) this.txtPercentuale2).Text == "")
        ((ParameterObject) sObject15).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject15).set_Value((object) int.Parse(((TextBox) this.txtPercentuale2).Text));
      controlsCollection.Add(sObject15);
      S_Object sObject16 = new S_Object();
      ((ParameterObject) sObject16).set_ParameterName("p_modalita");
      ((ParameterObject) sObject16).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject16).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject16).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject16).set_Size(112);
      ((ParameterObject) sObject16).set_Value((object) ((TextBox) this.txtModalitaPagamento).Text);
      controlsCollection.Add(sObject16);
      S_Object sObject17 = new S_Object();
      ((ParameterObject) sObject17).set_ParameterName("p_note");
      ((ParameterObject) sObject17).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject17).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject17).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject17).set_Size(408);
      ((ParameterObject) sObject17).set_Value((object) ((TextBox) this.txtNoteSga).Text);
      controlsCollection.Add(sObject17);
      return controlsCollection;
    }

    private int SaveSGA()
    {
      S_ControlsCollection sgaParameter = this.GetSgaParameter();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_stato");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(((CollectionBase) sgaParameter).Count);
      ((ParameterObject) sObject).set_Value((object) -1);
      sgaParameter.Add(sObject);
      return this._ClManCorrettiva.ExecuteUpdateSGA(sgaParameter);
    }

    private void BtUpload_Click(object sender, EventArgs e)
    {
      if (this.UploadFile.PostedFile == null || !(this.UploadFile.PostedFile.FileName != ""))
        return;
      string fileName = Path.GetFileName(this.UploadFile.PostedFile.FileName);
      string str1 = Path.Combine(this.Server.MapPath("../Doc_DB"), this.txtHidBl.Text);
      if (!Directory.Exists(str1))
        Directory.CreateDirectory(str1);
      string str2 = Path.Combine(str1, this.wr_id.ToString());
      if (!Directory.Exists(str2))
        Directory.CreateDirectory(str2);
      this.UploadFile.PostedFile.SaveAs(Path.Combine(str2, fileName));
      this.SaveDocument(fileName, this.UploadFile.PostedFile.ContentLength.ToString(), "DOC");
      this.LoadDocument();
    }

    private void SaveDocument(string filename, string dimesione, string tipodoc)
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
      ((ParameterObject) sObject2).set_ParameterName("p_nomedoc");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) filename);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_estenzione");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(25);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) Path.GetExtension(filename));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_dimensione");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Value((object) dimesione.ToString());
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_tipo");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Value((object) tipodoc);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_operazione");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject6).set_Value((object) 1);
      CollezioneControlli.Add(sObject6);
      this._ClManCorrettiva.ExecuteUpdateDOC(CollezioneControlli);
    }

    private void rpdc_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      string str1 = ((DataRowView) e.Item.DataItem)["NOME_DOC"].ToString();
      string str2 = "../Doc_DB/" + this.txtHidBl.Text + "/" + this.wr_id.ToString() + "/" + str1;
      (e.Item.FindControl("lbln") as Label).Text = "<a href=\"" + str2 + "\" target=\"_blank\">" + str1 + "</a>";
      (e.Item.FindControl("delete") as ImageButton).Attributes.Add("onclick", "return deletedoc();");
    }

    private void rpdc_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      if (!e.CommandName.ToLower().Equals("delete") || this.IsCompletata)
        return;
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      string[] strArray = e.CommandArgument.ToString().Split(',');
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id_file");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) strArray[0]);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_operazione");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) 2);
      CollezioneControlli.Add(sObject2);
      this._ClManCorrettiva.ExecuteUpdateDOC(CollezioneControlli);
      File.Delete(Path.Combine(Path.Combine(Path.Combine(this.Server.MapPath("../Doc_DB"), this.txtHidBl.Text), this.wr_id.ToString()), strArray[1]));
      this.LoadDocument();
    }

    private void cmbsDitta_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (int.Parse(((ListControl) this.cmbsDitta).SelectedValue.ToString()) > 0)
        this.LoadAddettiDitta("", int.Parse(((ListControl) this.cmbsDitta).SelectedValue.ToString()));
      else
        this.LoadAddettiDitta("-1", -1);
    }

    private S_ControlsCollection GetParamEmissione(S_ControlsCollection _SColl)
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_urgenza");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) _SColl).Count);
      ((ParameterObject) sObject1).set_Value((object) ((ListControl) this.cmbsUrgenza).SelectedValue);
      _SColl.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_addetto_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) _SColl).Count);
      if (((ListControl) this.cmbsAddetto).SelectedValue == "0")
        ((ParameterObject) sObject2).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject2).set_Value((object) int.Parse(((ListControl) this.cmbsAddetto).SelectedValue));
      _SColl.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_datapianificata");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) _SColl).Count);
      ((ParameterObject) sObject3).set_Size(30);
      string str1 = "";
      string text = ((TextBox) this.CalendarPicker6.Datazione).Text;
      if (text != "")
      {
        string str2 = (((ListControl) this.cmbOra1).SelectedValue == "" ? "00" : ((ListControl) this.cmbOra1).SelectedValue) + ":" + (((ListControl) this.cmbMin2).SelectedValue == "" ? "00" : ((ListControl) this.cmbMin2).SelectedValue) + ":00";
        str1 = text + " " + str2;
      }
      ((ParameterObject) sObject3).set_Value((object) str1);
      _SColl.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_id_ditta");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) _SColl).Count);
      ((ParameterObject) sObject4).set_Value((object) (((ListControl) this.cmbsDitta).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsDitta).SelectedValue)));
      _SColl.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) _SColl).Count);
      ((ParameterObject) sObject5).set_Value((object) int.Parse(this.hidBl_id.Value));
      _SColl.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_richiedente");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) _SColl).Count);
      ((ParameterObject) sObject6).set_Size(35);
      ((ParameterObject) sObject6).set_Value((object) this.lblRichiedente.Text);
      _SColl.Add(sObject6);
      return _SColl;
    }

    private void btApprova_Click(object sender, EventArgs e)
    {
      S_ControlsCollection paramEmissione = this.GetParamEmissione(this.GetSgaParameter());
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_stato");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(((CollectionBase) paramEmissione).Count);
      ((ParameterObject) sObject).set_Value((object) 6);
      paramEmissione.Add(sObject);
      this._ClManCorrettiva.ExecuteUpdateSGA(paramEmissione);
      this.LoadDati();
    }

    private void btSospendi_Click(object sender, EventArgs e)
    {
      S_ControlsCollection paramEmissione = this.GetParamEmissione(this.GetSgaParameter());
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_stato");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(((CollectionBase) paramEmissione).Count);
      ((ParameterObject) sObject).set_Value((object) 15);
      paramEmissione.Add(sObject);
      this._ClManCorrettiva.ExecuteUpdateSGA(paramEmissione);
      this.LoadDati();
    }

    private void btRifiuta_Click(object sender, EventArgs e)
    {
      S_ControlsCollection paramEmissione = this.GetParamEmissione(this.GetSgaParameter());
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_stato");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(((CollectionBase) paramEmissione).Count);
      ((ParameterObject) sObject).set_Value((object) 7);
      paramEmissione.Add(sObject);
      this._ClManCorrettiva.ExecuteUpdateSGA(paramEmissione);
      this.LoadDati();
    }

    private void btChiudi_Click(object sender, EventArgs e) => this.Chiudi();

    private void Chiudi()
    {
      string str = "";
      if (this.Request["VarApp"] != null)
        str = "&VarApp=" + this.Request["VarApp"];
      this.Server.Transfer(this.HPageBack.Value + "?FunId=" + this.ViewState["FunId"] + str);
    }

    private void btFoglioPdf_Click(object sender, EventArgs e) => this.ScriptRapportoTecnicoPdf(int.Parse(this.LblOrdine.Text.Trim()));

    private void ScriptRapportoTecnicoPdf(int wo_id) => this.Page.RegisterStartupScript("funz", "<script language=\"javascript\">\n" + ("ApriPopUp('" + ("RapportoTecnicoInterventoPdf.aspx?WO_Id=" + wo_id.ToString()) + "')") + "</script>\n");

    private void ScriptRapportoTecnico(int wo_id) => this.Page.RegisterStartupScript("funz", "<script language=\"javascript\">\n" + ("ApriPopUp('" + ("RapportoTecnicoIntervento.aspx?WO_Id=" + wo_id.ToString()) + "')") + "</script>\n");

    private void btFoglio_Click(object sender, EventArgs e) => this.ScriptRapportoTecnico(int.Parse(this.LblOrdine.Text.Trim()));

    private void BtDIE_Click(object sender, EventArgs e)
    {
      this.SaveCompletamento();
      this.SendDIE();
      this.LoadDati();
    }

    private void SendDIE()
    {
      string[] die = new DIE(this.wr_id, DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString()).GenerateDIE();
      new MailSend().SendMail(die[0], this.wr_id, DocType.DIE);
      this.SaveInvio(die[1], DocType.DIE);
    }

    private void BtSalva_Click(object sender, EventArgs e)
    {
      this.SaveCompletamento();
      this.LoadDati();
    }

    private void SaveCompletamento()
    {
      S_ControlsCollection paramEmissione = this.GetParamEmissione(this.GetSgaParameter());
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_date_start");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) paramEmissione).Count);
      string empty1 = string.Empty;
      string str1 = ((TextBox) this.CalendarPicker7.Datazione).Text;
      if (str1 != "")
      {
        string str2 = (((ListControl) this.OraIni).SelectedValue == "" ? "00" : ((ListControl) this.OraIni).SelectedValue) + ":" + (((ListControl) this.MinitiIni).SelectedValue == "" ? "00" : ((ListControl) this.MinitiIni).SelectedValue) + ":00";
        str1 = str1 + " " + str2;
      }
      if (str1 != "")
        ((ParameterObject) sObject1).set_Value((object) str1);
      else
        ((ParameterObject) sObject1).set_Value((object) DBNull.Value);
      paramEmissione.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_date_end");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) paramEmissione).Count);
      string empty2 = string.Empty;
      string str3 = ((TextBox) this.CalendarPicker8.Datazione).Text;
      if (str3 != "")
      {
        string str2 = (((ListControl) this.OraFine).SelectedValue == "" ? "00" : ((ListControl) this.OraFine).SelectedValue) + ":" + (((ListControl) this.MinutiFine).SelectedValue == "" ? "00" : ((ListControl) this.MinutiFine).SelectedValue) + ":00";
        str3 = str3 + " " + str2;
      }
      if (str3 != "")
        ((ParameterObject) sObject2).set_Value((object) str3);
      else
        ((ParameterObject) sObject2).set_Value((object) DBNull.Value);
      paramEmissione.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_date_est_completion");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) paramEmissione).Count);
      string empty3 = string.Empty;
      string str4 = ((TextBox) this.CalendarPicker10.Datazione).Text;
      if (str4 != "")
      {
        string str2 = (((ListControl) this.S_COMBOBOX2).SelectedValue == "" ? "00" : ((ListControl) this.S_COMBOBOX2).SelectedValue) + ":" + (((ListControl) this.S_COMBOBOX1).SelectedValue == "" ? "00" : ((ListControl) this.S_COMBOBOX1).SelectedValue) + ":00";
        str4 = str4 + " " + str2;
      }
      if (str4 != "")
        ((ParameterObject) sObject3).set_Value((object) str4);
      else
        ((ParameterObject) sObject3).set_Value((object) DBNull.Value);
      paramEmissione.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_comments");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) paramEmissione).Count);
      ((ParameterObject) sObject4).set_Size(4000);
      ((ParameterObject) sObject4).set_Value((object) ((TextBox) this.cmbDescrizioneIntervento).Text);
      paramEmissione.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_ca_id");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) paramEmissione).Count);
      ((ParameterObject) sObject5).set_Size(32);
      ((ParameterObject) sObject5).set_Value((object) this.txtBuonoLavoroEster.Text);
      paramEmissione.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_satisfaction_id");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) paramEmissione).Count);
      ((ParameterObject) sObject6).set_Size(32);
      ((ParameterObject) sObject6).set_Value((object) this.RdListLivello.SelectedValue);
      paramEmissione.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_sospesa");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) paramEmissione).Count);
      ((ParameterObject) sObject7).set_Size(2000);
      ((ParameterObject) sObject7).set_Value((object) ((TextBox) this.txtsAnnotazioni).Text);
      paramEmissione.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("P_DISSERVIZIO");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) paramEmissione).Count);
      ((ParameterObject) sObject8).set_Value((object) (this.CkDisser.Checked ? 1 : 0));
      paramEmissione.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("P_DIE_TIPO_INTERVENTO");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) paramEmissione).Count);
      ((ParameterObject) sObject9).set_Value((object) this.cmbStatoIntervento.SelectedValue);
      paramEmissione.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("P_DIE_DICHIARA1");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(((CollectionBase) paramEmissione).Count);
      ((ParameterObject) sObject10).set_Value((object) 1);
      paramEmissione.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("P_DIE_DICHIARA2");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(((CollectionBase) paramEmissione).Count);
      ((ParameterObject) sObject11).set_Value((object) 1);
      paramEmissione.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("P_DIE_COSTO_MATERIALE");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(((CollectionBase) paramEmissione).Count);
      if (((TextBox) this.txtCostiMateriali1).Text == "")
        ((ParameterObject) sObject12).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject12).set_Value((object) double.Parse(((TextBox) this.txtCostiMateriali1).Text + "," + ((TextBox) this.txtCostiMateriali2).Text));
      paramEmissione.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("P_DIE_COSTO_PERSONALE");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(((CollectionBase) paramEmissione).Count);
      if (((TextBox) this.txtCostiPersonale1).Text == "")
        ((ParameterObject) sObject13).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject13).set_Value((object) double.Parse(((TextBox) this.txtCostiPersonale1).Text + "," + ((TextBox) this.txtCostiPersonale2).Text));
      paramEmissione.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("P_DIE_COSTO_TOTALE");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(((CollectionBase) paramEmissione).Count);
      if (((TextBox) this.txtCostiTotale1).Text == "")
        ((ParameterObject) sObject14).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject14).set_Value((object) double.Parse(((TextBox) this.txtCostiTotale1).Text + "," + ((TextBox) this.txtCostiTotale2).Text));
      paramEmissione.Add(sObject14);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("P_DIE_IMP_CONSUNTIVO");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Index(((CollectionBase) paramEmissione).Count);
      string str5 = !(((TextBox) this.ImpCons1).Text != string.Empty) ? "0" : ((TextBox) this.ImpCons1).Text;
      string str6 = !(((TextBox) this.ImpCons2).Text != string.Empty) ? str5 + ",0" : str5 + "," + ((TextBox) this.ImpCons2).Text;
      ((ParameterObject) sObject15).set_Value((object) Convert.ToDouble(str6));
      paramEmissione.Add(sObject15);
      S_Object sObject16 = new S_Object();
      ((ParameterObject) sObject16).set_ParameterName("P_DIE_NOTE");
      ((ParameterObject) sObject16).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject16).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject16).set_Index(((CollectionBase) paramEmissione).Count);
      ((ParameterObject) sObject16).set_Size(250);
      ((ParameterObject) sObject16).set_Value((object) ((TextBox) this.txtNoteCompletamento).Text);
      paramEmissione.Add(sObject16);
      S_Object sObject17 = new S_Object();
      ((ParameterObject) sObject17).set_ParameterName("P_DIE_REGISTRO");
      ((ParameterObject) sObject17).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject17).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject17).set_Index(((CollectionBase) paramEmissione).Count);
      ((ParameterObject) sObject17).set_Size(9);
      ((ParameterObject) sObject17).set_Value((object) this.txtOperazioneN.Text);
      paramEmissione.Add(sObject17);
      S_Object sObject18 = new S_Object();
      ((ParameterObject) sObject18).set_ParameterName("P_DIE_MESE");
      ((ParameterObject) sObject18).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject18).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject18).set_Index(((CollectionBase) paramEmissione).Count);
      if (((ListControl) this.CmbMese).SelectedValue == "")
        ((ParameterObject) sObject18).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject18).set_Value((object) ((ListControl) this.CmbMese).SelectedValue);
      paramEmissione.Add(sObject18);
      S_Object sObject19 = new S_Object();
      ((ParameterObject) sObject19).set_ParameterName("P_FORFAIT");
      ((ParameterObject) sObject19).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject19).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject19).set_Index(((CollectionBase) paramEmissione).Count);
      if (((CheckBox) this.OptAForfait).Checked)
        ((ParameterObject) sObject19).set_Value((object) 1);
      else
        ((ParameterObject) sObject19).set_Value((object) 0);
      paramEmissione.Add(sObject19);
      S_Object sObject20 = new S_Object();
      ((ParameterObject) sObject20).set_ParameterName("P_FORFAIT_NOTE");
      ((ParameterObject) sObject20).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject20).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject20).set_Index(((CollectionBase) paramEmissione).Count);
      ((ParameterObject) sObject20).set_Size(250);
      if (((CheckBox) this.OptAForfait).Checked)
        ((ParameterObject) sObject20).set_Value((object) ((TextBox) this.TxtAForfait).Text);
      else
        ((ParameterObject) sObject20).set_Value((object) DBNull.Value);
      paramEmissione.Add(sObject20);
      S_Object sObject21 = new S_Object();
      ((ParameterObject) sObject21).set_ParameterName("p_stato");
      ((ParameterObject) sObject21).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject21).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject21).set_Index(((CollectionBase) paramEmissione).Count);
      ((ParameterObject) sObject21).set_Value((object) ((ListControl) this.cmbsstatolavoro).SelectedValue);
      paramEmissione.Add(sObject21);
      S_Object sObject22 = new S_Object();
      ((ParameterObject) sObject22).set_ParameterName("p_FONDO_ID");
      ((ParameterObject) sObject22).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject22).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject22).set_Index(((CollectionBase) paramEmissione).Count);
      if (this.CmbFondo.SelectedValue == "")
        ((ParameterObject) sObject22).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject22).set_Value((object) this.CmbFondo.SelectedValue);
      paramEmissione.Add(sObject22);
      S_Object sObject23 = new S_Object();
      ((ParameterObject) sObject23).set_ParameterName("p_PERIODO_ID");
      ((ParameterObject) sObject23).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject23).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject23).set_Index(((CollectionBase) paramEmissione).Count);
      if (this.CmbFondo.SelectedValue == "")
        ((ParameterObject) sObject23).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject23).set_Value((object) this.cmbPeriodo.SelectedValue);
      paramEmissione.Add(sObject23);
      S_Object sObject24 = new S_Object();
      ((ParameterObject) sObject24).set_ParameterName("p_DESCRIZIONE_PERIODO");
      ((ParameterObject) sObject24).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject24).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject24).set_Index(((CollectionBase) paramEmissione).Count);
      if (this.CmbFondo.SelectedValue == "")
        ((ParameterObject) sObject24).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject24).set_Value((object) this.cmbPeriodo.Items[this.cmbPeriodo.SelectedIndex].Text);
      paramEmissione.Add(sObject24);
      this._ClManCorrettiva.ExecuteUpdateCompletamentoNew(paramEmissione);
    }

    private void BtInviaPreventivo_Click(object sender, EventArgs e) => this.SaveDocumentPreventivo();

    private void SaveDocumentPreventivo()
    {
      string empty = string.Empty;
      string str1;
      if (this.FilePreventivo.PostedFile != null && this.FilePreventivo.PostedFile.FileName != "")
      {
        str1 = Path.GetFileName(this.FilePreventivo.PostedFile.FileName);
        string str2 = Path.Combine(this.Server.MapPath("../Doc_DB"), this.txtHidBl.Text);
        if (!Directory.Exists(str2))
          Directory.CreateDirectory(str2);
        string str3 = Path.Combine(str2, this.wr_id.ToString() + "/PREV");
        if (!Directory.Exists(str3))
          Directory.CreateDirectory(str3);
        this.FilePreventivo.PostedFile.SaveAs(Path.Combine(str3, str1));
      }
      else
        str1 = this.LkPrev.Text;
      this.SaveDocumentPreventivo(str1);
      this.LoadDocumentPrev();
    }

    private void SaveDocumentPreventivo(string filename)
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
      ((ParameterObject) sObject2).set_ParameterName("p_numeropreventivo");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (this.TxtNumPreventivo.Text == "")
        ((ParameterObject) sObject2).set_Value((object) 0);
      else
        ((ParameterObject) sObject2).set_Value((object) this.TxtNumPreventivo.Text);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_importopreventivo");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (((TextBox) this.txtImpPrev1).Text == "")
        ((ParameterObject) sObject3).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject3).set_Value((object) double.Parse(((TextBox) this.txtImpPrev1).Text + "," + ((TextBox) this.txtImpPrev2).Text));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_pdfpreventivo");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(250);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Value((object) filename);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_operazione");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Value((object) 1);
      CollezioneControlli.Add(sObject5);
      this._ClManCorrettiva.ExecuteUpdatePreventivo(CollezioneControlli);
    }

    private void LoadDocumentPrev()
    {
      DataSet documentazionePrev = this._ClManCorrettiva.GetDocumentazionePrev(this.wr_id);
      if (documentazionePrev.Tables[0].Rows.Count == 0)
      {
        this.LkPrev.Visible = false;
        this.btImgDelete.Visible = false;
      }
      else
      {
        this.LkPrev.Visible = true;
        this.btImgDelete.Visible = true;
        this.LkPrev.Text = documentazionePrev.Tables[0].Rows[0]["nome_doc"].ToString();
        this.btImgDelete.CommandArgument = documentazionePrev.Tables[0].Rows[0]["id_file"].ToString();
        this.LkPrev.NavigateUrl = "../Doc_DB/" + this.txtHidBl.Text + "/" + this.wr_id.ToString() + "/PREV/" + documentazionePrev.Tables[0].Rows[0]["nome_doc"].ToString();
      }
    }

    private void btImgDelete_Click(object sender, ImageClickEventArgs e)
    {
      if (this.LkPrev.Text == "")
      {
        this.LkPrev.Visible = false;
        this.btImgDelete.Visible = false;
      }
      else
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
        ((ParameterObject) sObject2).set_ParameterName("p_operazione");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject2).set_Value((object) -1);
        CollezioneControlli.Add(sObject2);
        this._ClManCorrettiva.ExecuteUpdatePreventivo(CollezioneControlli);
        File.Delete(Path.Combine(Path.Combine(Path.Combine(this.Server.MapPath("../Doc_DB"), this.txtHidBl.Text), this.wr_id.ToString()), "PREV/" + this.LkPrev.Text));
        this.LkPrev.Visible = false;
        this.btImgDelete.Visible = false;
      }
    }

    private void SaveDocumentConsuntivo()
    {
      string str1 = string.Empty;
      if (this.FileConsuntivo.PostedFile != null && this.FileConsuntivo.PostedFile.FileName != "")
      {
        string fileName = Path.GetFileName(this.FileConsuntivo.PostedFile.FileName);
        string str2 = Path.Combine(this.Server.MapPath("../Doc_DB"), this.txtHidBl.Text);
        if (!Directory.Exists(str2))
          Directory.CreateDirectory(str2);
        string str3 = Path.Combine(str2, this.wr_id.ToString() + "/CONS");
        if (!Directory.Exists(str3))
          Directory.CreateDirectory(str3);
        this.FileConsuntivo.PostedFile.SaveAs(Path.Combine(str3, fileName));
        this.SaveDocumentConsuntivo(fileName);
      }
      else
        str1 = this.LkCons.Text;
      this.LoadDocumentCons();
    }

    private void SaveDocumentConsuntivo(string filename)
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
      ((ParameterObject) sObject2).set_ParameterName("p_importoconsuntivo");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (((TextBox) this.ImpCons1).Text == "")
        ((ParameterObject) sObject2).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject2).set_Value((object) double.Parse(((TextBox) this.ImpCons1).Text + "," + ((TextBox) this.ImpCons2).Text));
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_pdfconsuntivo");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(250);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) filename);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_operazione");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Value((object) 1);
      CollezioneControlli.Add(sObject4);
      this._ClManCorrettiva.ExecuteUpdateConsuntivo(CollezioneControlli);
    }

    private void LoadDocumentCons()
    {
      DataSet documentazioneCons = this._ClManCorrettiva.GetDocumentazioneCons(this.wr_id);
      if (documentazioneCons.Tables[0].Rows.Count == 0)
      {
        this.LkCons.Visible = false;
        this.btImgDeleteCons.Visible = false;
      }
      else
      {
        this.LkCons.Visible = true;
        this.btImgDeleteCons.Visible = true;
        this.LkCons.Text = documentazioneCons.Tables[0].Rows[0]["nome_doc"].ToString();
        this.btImgDeleteCons.CommandArgument = documentazioneCons.Tables[0].Rows[0]["id_file"].ToString();
        this.LkCons.NavigateUrl = "../Doc_DB/" + this.txtHidBl.Text + "/" + this.wr_id.ToString() + "/CONS/" + documentazioneCons.Tables[0].Rows[0]["nome_doc"].ToString();
      }
    }

    private void btImgDeleteCons_Click(object sender, ImageClickEventArgs e)
    {
      if (this.LkCons.Text == "")
      {
        this.LkCons.Visible = false;
        this.btImgDeleteCons.Visible = false;
      }
      else
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
        ((ParameterObject) sObject2).set_ParameterName("p_operazione");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject2).set_Value((object) -1);
        CollezioneControlli.Add(sObject2);
        this._ClManCorrettiva.ExecuteUpdateConsuntivo(CollezioneControlli);
        File.Delete(Path.Combine(Path.Combine(Path.Combine(this.Server.MapPath("../Doc_DB"), this.txtHidBl.Text), this.wr_id.ToString()), "CONS/" + this.LkCons.Text));
        this.LkCons.Visible = false;
        this.btImgDeleteCons.Visible = false;
      }
    }

    private void SaveInvio(string FileName, DocType TipoDoc)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) 0);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_NOME_DOC");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject2).set_Value((object) Path.GetFileName(FileName));
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_DATA_INVIO");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 5);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Size(15);
      ((ParameterObject) sObject3).set_Value((object) DateTime.Now);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_USERS");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject4).set_Value((object) this.Context.User.Identity.Name);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_TIPO_DOC");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Size(32);
      ((ParameterObject) sObject5).set_Value((object) TipoDoc.ToString());
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_CODICE");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject6).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject6).set_Value((object) this.HSga.Value);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_ID_WR");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject7).set_Value((object) this.wr_id);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_ID_BL");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject8).set_Value((object) this.hidBl_id.Value);
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_CODICE_BL");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject9).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject9).set_Value((object) this.txtHidBl.Text);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_Operazione");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject10).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject10).set_Value((object) "Insert");
      CollezioneControlli.Add(sObject10);
      this._ClManCorrettiva.ExecuteTracciaDoc(CollezioneControlli);
    }

    private void cmbsTipoIntrevento_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    public enum DateInterval
    {
      Day,
      DayOfYear,
      Hour,
      Minute,
      Month,
      Quarter,
      Second,
      Weekday,
      WeekOfYear,
      Year,
    }

    public class DateAndTime
    {
      public static long DateDiff(CompletaRdl1.DateInterval interval, DateTime dt1, DateTime dt2) => CompletaRdl1.DateAndTime.DateDiff(interval, dt1, dt2, DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek);

      private static int GetQuarter(int nMonth)
      {
        if (nMonth <= 3)
          return 1;
        if (nMonth <= 6)
          return 2;
        return nMonth <= 9 ? 3 : 4;
      }

      public static long DateDiff(
        CompletaRdl1.DateInterval interval,
        DateTime dt1,
        DateTime dt2,
        DayOfWeek eFirstDayOfWeek)
      {
        if (interval == CompletaRdl1.DateInterval.Year)
          return (long) (dt2.Year - dt1.Year);
        if (interval == CompletaRdl1.DateInterval.Month)
          return (long) Math.Abs(12 * (dt1.Year - dt2.Year) + dt1.Month - dt2.Month);
        TimeSpan timeSpan = dt2 - dt1;
        if (interval == CompletaRdl1.DateInterval.Day || interval == CompletaRdl1.DateInterval.DayOfYear)
          return CompletaRdl1.DateAndTime.Round(timeSpan.TotalDays);
        switch (interval)
        {
          case CompletaRdl1.DateInterval.Hour:
            return CompletaRdl1.DateAndTime.Round(timeSpan.TotalHours);
          case CompletaRdl1.DateInterval.Minute:
            return CompletaRdl1.DateAndTime.Round(timeSpan.TotalMinutes);
          case CompletaRdl1.DateInterval.Quarter:
            double quarter = (double) CompletaRdl1.DateAndTime.GetQuarter(dt1.Month);
            return CompletaRdl1.DateAndTime.Round((double) CompletaRdl1.DateAndTime.GetQuarter(dt2.Month) - quarter + (double) (4 * (dt2.Year - dt1.Year)));
          case CompletaRdl1.DateInterval.Second:
            return CompletaRdl1.DateAndTime.Round(timeSpan.TotalSeconds);
          case CompletaRdl1.DateInterval.Weekday:
            return CompletaRdl1.DateAndTime.Round(timeSpan.TotalDays / 7.0);
          case CompletaRdl1.DateInterval.WeekOfYear:
            while (dt2.DayOfWeek != eFirstDayOfWeek)
              dt2 = dt2.AddDays(-1.0);
            while (dt1.DayOfWeek != eFirstDayOfWeek)
              dt1 = dt1.AddDays(-1.0);
            return CompletaRdl1.DateAndTime.Round((dt2 - dt1).TotalDays / 7.0);
          default:
            return 0;
        }
      }

      private static long Round(double dVal) => dVal >= 0.0 ? (long) Math.Floor(dVal) : (long) Math.Ceiling(dVal);
    }
  }
}
