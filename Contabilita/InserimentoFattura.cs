// Decompiled with JetBrains decompiler
// Type: TheSite.Contabilita.InserimentoFattura
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
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Gestione;
using TheSite.WebControls;

namespace TheSite.Contabilita
{
  public class InserimentoFattura : Page
  {
    protected Label lblOperazione;
    protected MessagePanel PanelMess;
    protected Panel PanelEdit;
    private int itemId = 0;
    private int FunId = 0;
    private InserimentoFattura _fp;
    private DataSet _MyDs = new DataSet();
    private S_ControlsCollection _SCollection = new S_ControlsCollection();
    protected DropDownList cmbDaMese;
    protected S_TextBox S_TxtPercentuale;
    protected S_ComboBox cmbsServizio;
    protected DropDownList cmbAMese;
    protected CalendarPicker CalendarPicker1;
    protected CalendarPicker CalendarPicker2;
    protected CalendarPicker CalendarPicker3;
    protected CalendarPicker CalendarPicker4;
    protected Panel CampiModifica;
    protected S_TextBox S_TxtImponibile;
    protected S_TextBox S_TxtImponibileDec;
    protected S_TextBox S_TxtTot;
    protected S_TextBox S_TxtTotDec;
    protected S_TextBox S_TxtIntestatario;
    protected S_TextBox S_TxtDestinatario;
    protected S_TextBox S_TxtNumFattura;
    protected S_TextBox S_TxtDescrizione;
    protected DropDownList cmbAnnoDa;
    protected DropDownList cmbAnnoA;
    private TheSite.Classi.Fatturazione.Contabilita _Contabilita = new TheSite.Classi.Fatturazione.Contabilita();
    private string s_PeriodoDa = "";
    private string s_PeriodoA = "";
    private int i_idintestatario;
    protected HtmlTable TableOrdinaria;
    protected HtmlTable TableStrardinaria;
    private int i_iddestinatario;
    private string s_Imponibile;
    private string s_Totfattura;
    private string strArrRdl;
    private string s_dataApprovazione = (string) null;
    protected S_ListBox S_ListRDL;
    private string s_dataPagamento = (string) null;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected HtmlInputHidden rdl;
    protected ValidationSummary ValidationSummary1;
    protected RequiredFieldValidator RFVNumFattura;
    protected RequiredFieldValidator RFVTipoServizio;
    protected RicercaRDL RicercaRDL1;
    public static string HelpLink = string.Empty;

    private void visualizzatab()
    {
      if (((ListControl) this.cmbsServizio).SelectedValue == "1")
      {
        this.TableOrdinaria.Attributes.Add("Style", "DISPLAY:block");
        this.TableStrardinaria.Attributes.Add("Style", "DISPLAY:none");
      }
      if (((ListControl) this.cmbsServizio).SelectedValue == "3")
      {
        this.TableOrdinaria.Attributes.Add("Style", "DISPLAY:none");
        this.TableStrardinaria.Attributes.Add("Style", "DISPLAY:block");
      }
      if (!(((ListControl) this.cmbsServizio).SelectedValue == ""))
        return;
      this.TableOrdinaria.Attributes.Add("Style", "DISPLAY:none");
      this.TableStrardinaria.Attributes.Add("Style", "DISPLAY:none");
    }

    private void Page_Load(object sender, EventArgs e)
    {
      this.visualizzatab();
      InserimentoFattura.HelpLink = ((SiteModule) HttpContext.Current.Items[(object) "SiteModule"]).HelpLink;
      this.FunId = int.Parse(this.Request["FunId"]);
      ((WebControl) this.S_ListRDL).Attributes.Add("onkeydown", "deleteitem(this,event);");
      this.RicercaRDL1.multisele = "y";
      this.RicercaRDL1.operazione = "Insert";
      this.RicercaRDL1.NameComboMan = "cmbsServizio";
      this.RicercaRDL1.TipoMan = Convert.ToString(((ListControl) this.cmbsServizio).SelectedIndex);
      if (this.Request["ItemId"] != null)
      {
        this.itemId = int.Parse(this.Request["ItemId"]);
        if (this.itemId != 0)
          this.CampiModifica.Visible = true;
      }
      if (this.Page.IsPostBack)
        return;
      this.CaricaIntestatario();
      this.CaricaDestinatario();
      this.CaricaTipoServizio();
      ((WebControl) this.S_TxtImponibile).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.S_TxtImponibile).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.S_TxtImponibile).Attributes.Add("onblur", "imposta_dec(this.id);");
      ((WebControl) this.S_TxtImponibileDec).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.S_TxtImponibileDec).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.S_TxtImponibileDec).Attributes.Add("onblur", "imposta_dec(this.id);");
      ((WebControl) this.S_TxtTot).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.S_TxtTot).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.S_TxtTot).Attributes.Add("onblur", "imposta_dec(this.id);");
      ((WebControl) this.S_TxtTotDec).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.S_TxtTotDec).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.S_TxtTotDec).Attributes.Add("onblur", "imposta_dec(this.id);");
      ((WebControl) this.S_TxtPercentuale).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.S_TxtPercentuale).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.S_TxtPercentuale).Attributes.Add("onblur", "imposta_dec(this.id);");
      ((WebControl) this.btnsSalva).Attributes.Add("onclick", "if (typeof(controllodata) == 'function') {if (controllodata() == false) { return false; }}");
      if (this.itemId != 0)
      {
        this._MyDs = this._Contabilita.GetSingleData(this.itemId);
        if (this._MyDs.Tables[0].Rows.Count == 1)
        {
          DataRow row = this._MyDs.Tables[0].Rows[0];
          if (row["descrizione_fattura"] != DBNull.Value)
            ((TextBox) this.S_TxtDescrizione).Text = (string) row["descrizione_fattura"];
          if (row["intestatario"] != DBNull.Value)
            ((TextBox) this.S_TxtIntestatario).Text = (string) row["intestatario"];
          if (row["destinatario"] != DBNull.Value)
            ((TextBox) this.S_TxtDestinatario).Text = (string) row["destinatario"];
          if (row["numero_fattura"] != DBNull.Value)
            ((TextBox) this.S_TxtNumFattura).Text = (string) row["numero_fattura"];
          if (row["data_fattura"] != DBNull.Value)
            ((TextBox) this.CalendarPicker1.Datazione).Text = DateTime.Parse(row["data_fattura"].ToString()).ToShortDateString();
          if (row["data_scadenza_pagamento"] != DBNull.Value)
            ((TextBox) this.CalendarPicker2.Datazione).Text = DateTime.Parse(row["data_scadenza_pagamento"].ToString()).ToShortDateString();
          if (row["tipomanutenzione_id"] != DBNull.Value)
          {
            ((ListControl) this.cmbsServizio).SelectedValue = row["tipomanutenzione_id"].ToString();
            this.visualizzatab();
          }
          if (((ListControl) this.cmbsServizio).SelectedValue == "1")
          {
            string str1 = row["PERIODO_INIZIO_FATTURA"].ToString();
            this.cmbAnnoDa.SelectedValue = str1.Substring(0, 4);
            this.cmbDaMese.SelectedValue = str1.Substring(4, 2);
            string str2 = row["PERIODO_FINE_FATTURA"].ToString();
            this.cmbAnnoA.SelectedValue = str2.Substring(0, 4);
            this.cmbAMese.SelectedValue = str2.Substring(4, 2);
          }
          if (((ListControl) this.cmbsServizio).SelectedValue == "3")
          {
            this._MyDs = this._Contabilita.GetSingleRdlFatt(this.itemId);
            if (this._MyDs.Tables[0].Rows.Count > 0)
            {
              ((BaseDataBoundControl) this.S_ListRDL).DataSource = (object) this._MyDs.Tables[0];
              ((ListControl) this.S_ListRDL).DataTextField = "wr_id";
              ((ListControl) this.S_ListRDL).DataValueField = "wr_id";
              ((Control) this.S_ListRDL).DataBind();
            }
            if (((ListControl) this.S_ListRDL).Items.Count >= 0)
            {
              foreach (ListItem listItem in ((ListControl) this.S_ListRDL).Items)
                this.rdl.Value = this.rdl.Value + listItem.Value.ToString() + ",";
            }
          }
          if (row["data_approvazione"] != DBNull.Value)
            ((TextBox) this.CalendarPicker3.Datazione).Text = DateTime.Parse(row["data_approvazione"].ToString()).ToShortDateString();
          if (row["data_pagamento"] != DBNull.Value)
            ((TextBox) this.CalendarPicker4.Datazione).Text = DateTime.Parse(row["data_pagamento"].ToString()).ToShortDateString();
          if (row["imponibile"] != DBNull.Value)
          {
            ((TextBox) this.S_TxtImponibile).Text = TheSite.Classi.Function.GetTypeNumber(row["imponibile"], NumberType.Intero).ToString();
            ((TextBox) this.S_TxtImponibileDec).Text = TheSite.Classi.Function.GetTypeNumber(row["imponibile"], NumberType.Decimale).ToString();
          }
          if (row["iva"] != DBNull.Value)
            ((TextBox) this.S_TxtPercentuale).Text = TheSite.Classi.Function.GetTypeNumber(row["iva"], NumberType.Intero).ToString();
          if (row["totale_fattura"] != DBNull.Value)
          {
            ((TextBox) this.S_TxtTot).Text = TheSite.Classi.Function.GetTypeNumber(row["totale_fattura"], NumberType.Intero).ToString();
            ((TextBox) this.S_TxtTotDec).Text = TheSite.Classi.Function.GetTypeNumber(row["totale_fattura"], NumberType.Decimale).ToString();
          }
          this.lblOperazione.Text = "Modifica Fattura: " + ((TextBox) this.S_TxtNumFattura).Text;
          this.lblFirstAndLast.Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          this.lblFirstAndLast.Text = this._Contabilita.GetFirstAndLastUser(row);
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Fattura";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      if (this.Request["TipoOper"] == "read")
      {
        this.AbilitaControlli(false);
        this.lblOperazione.Text = "Visualizzazione Fattura: " + ((TextBox) this.S_TxtNumFattura).Text;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Servizi))
        return;
      this._fp = (InserimentoFattura) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    private void AbilitaControlli(bool enabled)
    {
      this.PanelEdit.Enabled = enabled;
      ((WebControl) this.btnsSalva).Enabled = enabled;
      ((WebControl) this.btnsElimina).Enabled = enabled;
      ((WebControl) this.S_ListRDL).Enabled = enabled;
      ((WebControl) this.cmbsServizio).Enabled = enabled;
      this.cmbAMese.Enabled = enabled;
      this.cmbDaMese.Enabled = enabled;
      this.cmbAnnoDa.Enabled = enabled;
      this.cmbAnnoA.Enabled = enabled;
    }

    private void CaricaIntestatario()
    {
      DataSet dataSet = this._Contabilita.GetIntestatario().Copy();
      ((TextBox) this.S_TxtIntestatario).Text = dataSet.Tables[0].Rows[0]["SOCIETA"].ToString();
      this.i_idintestatario = Convert.ToInt32(dataSet.Tables[0].Rows[0]["INTESTATARIO_ID"]);
    }

    private void CaricaDestinatario()
    {
      DataSet dataSet = this._Contabilita.GetDestinatario().Copy();
      ((TextBox) this.S_TxtDestinatario).Text = dataSet.Tables[0].Rows[0]["SOCIETA"].ToString();
      this.i_iddestinatario = Convert.ToInt32(dataSet.Tables[0].Rows[0]["DESTINATARIO_ID"]);
    }

    private void CaricaTipoServizio()
    {
      ((ListControl) this.cmbsServizio).Items.Clear();
      DataSet dataSet = this._Contabilita.GetTipoServizio().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "tipomanutenzione_id", "- Selezionare un Servizio -", "-1");
      ((ListControl) this.cmbsServizio).DataTextField = "descrizione";
      ((ListControl) this.cmbsServizio).DataValueField = "tipomanutenzione_id";
      ((Control) this.cmbsServizio).DataBind();
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      ((Button) this.btnsElimina).Click += new EventHandler(this.btnsElimina_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private bool IsDupNumFattura()
    {
      DataSet dataSet = new TheSite.Classi.Function().ControllaDuplicato("Fattura", "NUMERO_FATTURA", "'" + ((TextBox) this.S_TxtNumFattura).Text.Trim().Replace("'", "''") + "'", "Fattura_ID");
      if (dataSet.Tables[0].Rows.Count == 0)
        return false;
      DataRow row = dataSet.Tables[0].Rows[0];
      return this.itemId <= 0 || int.Parse(row[0].ToString()) != this.itemId;
    }

    private bool IsDupRdl()
    {
      TheSite.Classi.Function function = new TheSite.Classi.Function();
      string tabella = "Fattura_wr";
      string campo_input = "WR_ID";
      string valore = this.rdl.Value.Substring(0, this.rdl.Value.Length - 1);
      string valore2 = Convert.ToString(this.itemId);
      string operazione = this.itemId != 0 ? "Update" : "Insert";
      string campo_output = "Fattura_ID";
      return function.ControllaDuplicatoRDL(tabella, campo_input, valore, valore2, campo_output, operazione).Tables[0].Rows.Count != 0;
    }

    private bool IsDupPeriodoFAttura()
    {
      DataSet dataSet = new TheSite.Classi.Function().ControllaDuplicatoPeriodo("Fattura", "PERIODO_INIZIO_FATTURA", "PERIODO_FINE_FATTURA", "'" + this.cmbAnnoDa.SelectedValue + this.cmbDaMese.SelectedValue + "'", "'" + this.cmbAnnoA.SelectedValue + this.cmbAMese.SelectedValue + "'", "Fattura_ID");
      if (dataSet.Tables[0].Rows.Count == 0)
        return false;
      DataRow row = dataSet.Tables[0].Rows[0];
      return this.itemId <= 0 || int.Parse(row[0].ToString()) != this.itemId;
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      if (!this.IsDupNumFattura())
      {
        if (((ListControl) this.cmbsServizio).SelectedValue == "1")
        {
          if (!this.IsDupPeriodoFAttura())
            this.Aggiorna(true);
          else
            SiteJavaScript.msgBox(this.Page, "Periodo di fatturazione già inserita");
        }
        if (!(((ListControl) this.cmbsServizio).SelectedValue == "3"))
          return;
        this.Aggiorna(true);
      }
      else
        SiteJavaScript.msgBox(this.Page, "La fattura é stata già inserita");
    }

    private void SalvaRdlAssociate()
    {
    }

    private void Aggiorna(bool ins)
    {
      this.S_TxtDescrizione.set_DBDefaultValue((object) DBNull.Value);
      this.S_TxtDestinatario.set_DBDefaultValue((object) DBNull.Value);
      this.S_TxtImponibile.set_DBDefaultValue((object) DBNull.Value);
      this.S_TxtImponibileDec.set_DBDefaultValue((object) DBNull.Value);
      this.S_TxtIntestatario.set_DBDefaultValue((object) DBNull.Value);
      this.S_TxtNumFattura.set_DBDefaultValue((object) DBNull.Value);
      this.S_TxtPercentuale.set_DBDefaultValue((object) DBNull.Value);
      this.S_TxtTot.set_DBDefaultValue((object) DBNull.Value);
      this.S_TxtTotDec.set_DBDefaultValue((object) DBNull.Value);
      this.CalendarPicker1.Datazione.set_DBDefaultValue((object) DBNull.Value);
      this.CalendarPicker2.Datazione.set_DBDefaultValue((object) DBNull.Value);
      this.CalendarPicker3.Datazione.set_DBDefaultValue((object) DBNull.Value);
      this.CalendarPicker4.Datazione.set_DBDefaultValue((object) DBNull.Value);
      this.s_Imponibile = ((TextBox) this.S_TxtImponibile).Text + "," + ((TextBox) this.S_TxtImponibileDec).Text;
      this.s_Totfattura = ((TextBox) this.S_TxtTot).Text + "," + ((TextBox) this.S_TxtTotDec).Text;
      if (((TextBox) this.CalendarPicker4.Datazione).Text != "")
        this.s_dataPagamento = ((TextBox) this.CalendarPicker3.Datazione).Text;
      if (((TextBox) this.CalendarPicker3.Datazione).Text != "")
        this.s_dataApprovazione = ((TextBox) this.CalendarPicker4.Datazione).Text;
      if (((ListControl) this.cmbsServizio).SelectedValue == "1")
      {
        this.s_PeriodoDa = this.cmbAnnoDa.SelectedValue + this.cmbDaMese.SelectedValue;
        this.s_PeriodoA = this.cmbAnnoA.SelectedValue + this.cmbAMese.SelectedValue;
        this.strArrRdl = "";
      }
      else
      {
        this.s_PeriodoA = "0";
        this.s_PeriodoDa = "0";
      }
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Value((object) this.itemId);
      ((ParameterObject) sObject1).set_ParameterName("p_FATTURA_ID");
      ((ParameterObject) sObject1).set_Index(0);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Value((object) 1);
      ((ParameterObject) sObject2).set_ParameterName("p_INTESTATARIO_ID");
      ((ParameterObject) sObject2).set_Index(1);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Value((object) 1);
      ((ParameterObject) sObject3).set_ParameterName("p_DESTINATARIO_ID");
      ((ParameterObject) sObject3).set_Index(2);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Value((object) ((TextBox) this.S_TxtNumFattura).Text);
      ((ParameterObject) sObject4).set_ParameterName("p_NUMEROFATTURA");
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Index(3);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Value((object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      ((ParameterObject) sObject5).set_ParameterName("p_DATA_FATTURA");
      ((ParameterObject) sObject5).set_Size(10);
      ((ParameterObject) sObject5).set_Index(4);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Value((object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      ((ParameterObject) sObject6).set_ParameterName("p_DATA_SCADENZA_PAGAMENTO");
      ((ParameterObject) sObject6).set_Size(10);
      ((ParameterObject) sObject6).set_Index(5);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Value((object) ((TextBox) this.CalendarPicker4.Datazione).Text);
      ((ParameterObject) sObject7).set_Size(10);
      ((ParameterObject) sObject7).set_ParameterName("p_DATA_PAGAMENTO");
      ((ParameterObject) sObject7).set_Index(6);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Value((object) ((TextBox) this.CalendarPicker3.Datazione).Text);
      ((ParameterObject) sObject8).set_ParameterName("p_DATA_APPROVAZIONE");
      ((ParameterObject) sObject8).set_Size(10);
      ((ParameterObject) sObject8).set_Index(7);
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Value((object) int.Parse(((ListControl) this.cmbsServizio).SelectedValue));
      ((ParameterObject) sObject9).set_ParameterName("p_TIPOMANUTENZIONE_ID");
      ((ParameterObject) sObject9).set_Index(8);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Value((object) ((TextBox) this.S_TxtDescrizione).Text);
      ((ParameterObject) sObject10).set_ParameterName("p_DESCRIZIONE_FATTURA");
      ((ParameterObject) sObject10).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject10).set_Index(9);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Value((object) double.Parse(this.s_Imponibile));
      ((ParameterObject) sObject11).set_ParameterName("p_IMPONIBILE");
      ((ParameterObject) sObject11).set_Index(10);
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Value((object) short.Parse(((TextBox) this.S_TxtPercentuale).Text));
      ((ParameterObject) sObject12).set_ParameterName("p_IVA");
      ((ParameterObject) sObject12).set_Index(11);
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Value((object) double.Parse(this.s_Totfattura));
      ((ParameterObject) sObject13).set_ParameterName("p_TOTALE_FATTURA");
      ((ParameterObject) sObject13).set_Index(12);
      CollezioneControlli.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Value((object) this.s_PeriodoDa);
      ((ParameterObject) sObject14).set_ParameterName("p_PERIODO_INIZIO_FATTURA");
      ((ParameterObject) sObject14).set_Index(13);
      CollezioneControlli.Add(sObject14);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Value((object) this.s_PeriodoA);
      ((ParameterObject) sObject15).set_ParameterName("p_PERIODO_FINE_FATTURA");
      ((ParameterObject) sObject15).set_Index(14);
      CollezioneControlli.Add(sObject15);
      this.strArrRdl = this.rdl.Value;
      if (this.strArrRdl == "" || ((ListControl) this.cmbsServizio).SelectedValue == "1")
        this.strArrRdl = "0";
      S_Object sObject16 = new S_Object();
      ((ParameterObject) sObject16).set_ParameterName("p_Arr_RDL");
      ((ParameterObject) sObject16).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject16).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject16).set_Index(15);
      ((ParameterObject) sObject16).set_Value((object) this.strArrRdl);
      CollezioneControlli.Add(sObject16);
      S_Object sObject17 = new S_Object();
      ((ParameterObject) sObject17).set_ParameterName("p_FATTURA_WR_ID");
      ((ParameterObject) sObject17).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject17).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject17).set_Index(16);
      ((ParameterObject) sObject17).set_Value((object) 0);
      CollezioneControlli.Add(sObject17);
      if (ins)
      {
        try
        {
          int num = this.itemId != 0 ? this._Contabilita.Update(CollezioneControlli, this.itemId) : this._Contabilita.Add(CollezioneControlli);
          if (num <= 0 || num == -11)
            return;
          this.Server.Transfer("SfogliaFatture.aspx");
        }
        catch (Exception ex)
        {
          this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
        }
      }
      else
      {
        try
        {
          if (this._Contabilita.Delete(CollezioneControlli, this.itemId) != -1)
            return;
          this.Server.Transfer("SfogliaFatture.aspx");
        }
        catch (Exception ex)
        {
          this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
        }
      }
    }

    private void btnsElimina_Click(object sender, EventArgs e) => this.Aggiorna(false);

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("SfogliaFatture.aspx");
  }
}
