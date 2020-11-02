// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorretiva.VisualizzaRdl
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ManCorrettiva;
using TheSite.Classi.ManOrdinaria;
using TheSite.Classi.RptRtf;
using TheSite.WebControls;
using TheSite.XSLT;

namespace TheSite.ManutenzioneCorretiva
{
  public class VisualizzaRdl : Page
  {
    protected PageTitle PageTitle1;
    private int FunId = 0;
    protected Label lblOperatore;
    protected Label lblData;
    protected Label lblOra;
    protected Label lblRichiedente;
    protected Label lblGruppo;
    protected Label lblTelefono;
    protected Label lblNota;
    protected Label lblCodiceEdificio;
    protected Label lblIndirizzo;
    protected Label lblComune;
    protected Label lblDenominazione;
    protected Label lblDitta;
    protected Label lblServizio;
    protected Label lblUrgenza;
    protected Label lblDescrizione;
    protected Label lblEqStd;
    protected Label lblEqId;
    protected S_Button btnsNuova;
    protected S_Button cmdApprova;
    protected TextBox txtWrHidden;
    protected Label lblteleric;
    protected Label lblemailric;
    protected Label lblstanzaric;
    protected Label lblpianoed;
    protected Label lblstanzaed;
    protected Label lblTelefonoDitta;
    protected S_Button btnModificaRDL;
    protected Label LblEffetto;
    protected Label LblAnomalia;
    protected Label LblIdASeguito;
    protected Label lblAseguito1;
    protected Label lblAseguito2;
    protected Label lblAseguito3;
    protected Label lblAseguito4;
    protected CheckBox ChkConduzione;
    protected Label TxtOraAseguito;
    protected Panel Conduzione;
    protected Label CmbASeguito;
    protected Label TxtASeguito1;
    protected CheckBox ChkSopralluogo;
    protected Label TxtSopralluogo;
    protected Panel Sopralluogo;
    protected Label TxtASeguito4;
    protected Label CPConduzioneData;
    protected Label CPAseguito;
    protected Label CPSopralluogoDie;
    protected Label CPSopralluogoData;
    protected Button BtSalvaSGA;
    private int itemId = 0;
    private ClManCorrettiva _ClManCorrettiva;
    private string HSga;
    protected Label LblSga;
    protected Label LblInvioSga;
    protected HtmlInputHidden hidprog;
    protected Label lblTipoIntervento;
    protected HtmlInputHidden HidTipInter;
    private int id_bl = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      this._ClManCorrettiva = new ClManCorrettiva(this.Context.User.Identity.Name);
      this.FunId = int.Parse(this.Request.Params["FunId"]);
      if (this.Request.QueryString["chiamante"] == "Materiali")
      {
        ((Control) this.btnModificaRDL).Visible = false;
        ((Control) this.btnsNuova).Visible = false;
        ((Control) this.cmdApprova).Visible = false;
        this.PageTitle1.VisibleLogut = false;
      }
      if (this.Request.Params["ItemId"] != null)
      {
        this.itemId = int.Parse(this.Request.Params["ItemId"]);
        this.PageTitle1.Title = "Richiesta di Lavoro N° " + (object) this.itemId;
        this.txtWrHidden.Text = this.itemId.ToString();
        DataSet dataSet = new Richiesta().GetSingleData(this.itemId).Copy();
        if (dataSet.Tables[0].Rows.Count != 1)
          return;
        DataRow row = dataSet.Tables[0].Rows[0];
        this.lblData.Text = ((DateTime) row["DATE_REQUESTED"]).ToShortDateString();
        this.lblOra.Text = ((DateTime) row["TIME_REQUESTED"]).ToShortTimeString();
        this.lblCodiceEdificio.Text = row["BL_ID"].ToString();
        if (row["sga"] != DBNull.Value)
          this.LblSga.Text = row["sga"].ToString();
        DataSet dataInvioSga = this._ClManCorrettiva.GetDataInvioSga(this.itemId, DocType.SGA);
        if (dataInvioSga.Tables[0].Rows.Count == 1)
          this.LblInvioSga.Text = dataInvioSga.Tables[0].Rows[0]["data_invio"].ToString();
        if (row["id_bl"] != DBNull.Value)
          this.id_bl = Convert.ToInt32(row["id_bl"].ToString());
        if (row["id_progetto"] != DBNull.Value)
          this.hidprog.Value = row["id_progetto"].ToString();
        if (row["DENOMINAZIONE"] != DBNull.Value)
          this.lblDenominazione.Text = row["DENOMINAZIONE"].ToString();
        if (row["PIANO"] != DBNull.Value)
          this.lblpianoed.Text = row["PIANO"].ToString();
        if (row["STANZA"] != DBNull.Value)
          this.lblstanzaed.Text = row["STANZA"].ToString();
        if (row["INDIRIZZO"] != DBNull.Value)
          this.lblIndirizzo.Text = row["INDIRIZZO"].ToString();
        if (row["COMUNE"] != DBNull.Value)
          this.lblComune.Text = row["COMUNE"].ToString();
        if (row["descrizione_ditta"] != DBNull.Value)
          this.lblDitta.Text = row["descrizione_ditta"].ToString();
        if (row["TELEFONO_DITTA"] != DBNull.Value)
          this.lblTelefonoDitta.Text = row["TELEFONO_DITTA"].ToString();
        if (row["USERNAME"] != DBNull.Value)
          this.lblOperatore.Text = row["USERNAME"].ToString();
        if (row["REQUESTOR"] != DBNull.Value)
          this.lblRichiedente.Text = row["REQUESTOR"].ToString();
        if (row["telefonoric"] != DBNull.Value)
          this.lblteleric.Text = row["telefonoric"].ToString();
        if (row["emailric"] != DBNull.Value)
          this.lblemailric.Text = row["emailric"].ToString();
        if (row["stanzaric"] != DBNull.Value)
          this.lblstanzaric.Text = row["stanzaric"].ToString();
        if (row["PHONE"] != DBNull.Value)
          this.lblTelefono.Text = row["PHONE"].ToString();
        if (row["DESCRIZIONERICHIEDENTI"] != DBNull.Value)
          this.lblGruppo.Text = row["DESCRIZIONERICHIEDENTI"].ToString();
        string empty1 = string.Empty;
        if (row["NOTA_RIC"] != DBNull.Value)
          empty1 = row["NOTA_RIC"].ToString();
        this.lblNota.Text = empty1.Replace("\n", "<br>");
        string empty2 = string.Empty;
        if (row["DESCRIPTION"] != DBNull.Value)
          empty2 = row["DESCRIPTION"].ToString();
        this.lblDescrizione.Text = empty2.Replace("\n", "<br>");
        if (row["PRIORITY"] != DBNull.Value)
          this.lblUrgenza.Text = row["PRIORITY"].ToString();
        if (row["DESCRIZIONESERVIZI"] != DBNull.Value)
          this.lblServizio.Text = row["DESCRIZIONESERVIZI"].ToString();
        string str = string.Empty;
        if (row["EQ_STD"] != DBNull.Value)
          str = row["EQ_STD"].ToString();
        if (row["DESCRIZIONEEQSTD"] != DBNull.Value)
          str = str + " " + row["DESCRIZIONEEQSTD"].ToString();
        this.lblEqStd.Text = str;
        if (row["EQ_ID"] != DBNull.Value)
          this.lblEqId.Text = row["EQ_ID"].ToString();
        if (row["sga_anomalia"] != DBNull.Value)
          this.LblAnomalia.Text = row["sga_anomalia"].ToString();
        if (row["sga_effetto"] != DBNull.Value)
          this.LblEffetto.Text = row["sga_effetto"].ToString();
        if (row["conduzione"] != DBNull.Value)
          this.ChkConduzione.Checked = row["conduzione"].ToString() == "1";
        if (row["data_conduzione"] != DBNull.Value)
          this.CPConduzioneData.Text = row["data_conduzione"].ToString();
        if (row["ora_conduzione"] != DBNull.Value)
          this.TxtOraAseguito.Text = row["ora_conduzione"].ToString();
        if (row["sga_seguito"] != DBNull.Value)
          this.CmbASeguito.Text = row["sga_seguito"].ToString();
        if (row["DescTipoIntervento"] != DBNull.Value)
          this.lblTipoIntervento.Text = row["DescTipoIntervento"].ToString();
        this.HidTipInter.Value = row["tipointervento_id"].ToString();
        if (row["tipointervento_id"].ToString() == "83")
          this.BtSalvaSGA.Text = "Salva/Invia DIE";
        if (row["die_numero"] != DBNull.Value)
          this.TxtASeguito1.Text = row["die_numero"].ToString();
        if (row["die_del"] != DBNull.Value)
          this.CPAseguito.Text = row["die_del"].ToString();
        if (row["sopralluogo"] != DBNull.Value)
          this.ChkSopralluogo.Checked = row["sopralluogo"].ToString() == "1";
        if (row["sopralluogo_n"] != DBNull.Value)
          this.TxtSopralluogo.Text = row["sopralluogo_n"].ToString();
        if (row["sopralluogo_del"] != DBNull.Value)
          this.CPSopralluogoDie.Text = row["sopralluogo_del"].ToString();
        if (row["sopralluogo_data"] != DBNull.Value)
          this.CPSopralluogoData.Text = row["sopralluogo_data"].ToString();
        if (row["sopralluogo_da"] == DBNull.Value)
          return;
        this.TxtASeguito4.Text = row["sopralluogo_da"].ToString();
      }
      else
        this.PageTitle1.Title = "Inserimento Richiesta di Lavoro - Impossibile visualizzare la Richiesta";
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsNuova).Click += new EventHandler(this.btnsNuova_Click);
      ((Button) this.cmdApprova).Click += new EventHandler(this.cmdApprova_Click);
      ((Button) this.btnModificaRDL).Click += new EventHandler(this.btnModificaRDL_Click);
      this.BtSalvaSGA.Click += new EventHandler(this.BtSalvaSGA_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsNuova_Click(object sender, EventArgs e)
    {
      string str = "";
      if (this.Request["VarApp"] != null)
        str = "&VarApp=" + this.Request["VarApp"];
      this.Response.Redirect("CreazioneSGA.aspx?FunId=" + (object) this.FunId + str);
    }

    private void cmdApprova_Click(object sender, EventArgs e) => this.Response.Redirect("CompletaRdl.aspx?wr_id=" + this.txtWrHidden.Text);

    private void btnModificaRDL_Click(object sender, EventArgs e)
    {
      string str = "";
      if (this.Request["VarApp"] != null)
        str = "&VarApp=" + this.Request["VarApp"];
      this.Response.Redirect("CreazioneSGA.aspx?ItemId=" + this.txtWrHidden.Text + str);
    }

    private void BtSalvaSGA_Click(object sender, EventArgs e)
    {
      if (this.HidTipInter.Value == "83")
        this.inviaDie();
      else
        this.inviaSGA();
    }

    private void CreaCodSGA()
    {
      this.HSga = this.lblCodiceEdificio.Text + "_" + (object) this._ClManCorrettiva.CreaNumeroSGA(Convert.ToInt32(this.txtWrHidden.Text)) + "_" + DateTime.Parse(this.lblData.Text).ToString("yy");
      this.LblSga.Text = this.HSga.ToString();
    }

    private void inviaSGA()
    {
      this.HSga = this.LblSga.Text;
      string DataCreate = DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
      string str = this.Server.MapPath(this.Request.ApplicationPath + (!(this.hidprog.Value == "2") ? "\\XSLT\\XSLsgaRpt04.xslt" : "\\XSLT\\XSLsgaRptVod04.xslt"));
      SGARTF sgartf = new SGARTF();
      sgartf.FileXlst = str;
      int int32 = Convert.ToInt32(this.txtWrHidden.Text);
      string[] strArray = sgartf.GeneraRtf(int32, DataCreate);
      MailSend mailSend = new MailSend();
      this.SaveInvio(strArray[1], DocType.SGA);
      mailSend.SendMail(strArray[0], int32, DocType.SGA);
      DataSet dataInvioSga = this._ClManCorrettiva.GetDataInvioSga(this.itemId, DocType.SGA);
      if (dataInvioSga.Tables[0].Rows.Count != 1)
        return;
      this.LblInvioSga.Text = dataInvioSga.Tables[0].Rows[0]["data_invio"].ToString();
    }

    private void inviaDie()
    {
      this.HSga = this.LblSga.Text;
      int int32 = Convert.ToInt32(this.txtWrHidden.Text);
      string DataCreate = DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
      string[] die = new DIE(int32, DataCreate).GenerateDIE();
      new MailSend().SendMail(die[0], int32, DocType.DIE);
      this.SaveInvio(die[1], DocType.DIE);
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
      ((ParameterObject) sObject6).set_Value((object) this.HSga.ToString());
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_ID_WR");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject7).set_Value((object) this.txtWrHidden.Text);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_ID_BL");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject8).set_Value((object) this.id_bl);
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_CODICE_BL");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject9).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject9).set_Value((object) this.lblCodiceEdificio.Text);
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
  }
}
