// Decompiled with JetBrains decompiler
// Type: TheSite.SoddisfazioneCliente.EditGiudizio
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
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManOrdinaria;
using TheSite.WebControls;

namespace TheSite.SoddisfazioneCliente
{
  public class EditGiudizio : Page
  {
    private int itemId = 0;
    private string CodEdificio = "";
    protected MessagePanel PanelMess;
    protected Label lblDenominazione;
    protected Label lblIndirizzo;
    protected Label lblComune;
    protected Label lblTelefono;
    protected S_Label lblCodEdificio;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected ValidationSummary vlsEdit;
    private int FunId = 0;
    protected S_ComboBox cmbsServizio;
    protected S_ComboBox cmbsPiano;
    protected S_ComboBox cmbsGiudizio;
    protected CalendarPicker dataIspezione;
    protected S_TextBox txtNumero;
    protected S_TextBox txtAttivitaIsp;
    protected S_TextBox txtAnnotazioni;
    protected RegularExpressionValidator regtxtNumero;
    protected RequiredFieldValidator rfvGiudizio;
    protected RicercaModulo RicercaModulo1;
    protected HtmlInputHidden hiddenblid;
    protected RequiredFieldValidator rfvEdificio;
    protected Label lblOperazione;
    protected TextBox blid_scelto;
    private Giudizio _fp;
    protected UserStanze UserStanze1;

    private void Page_Load(object sender, EventArgs e)
    {
      ((WebControl) this.txtNumero).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtNumero).Attributes.Add("onpaste", "return nonpaste();");
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Request["CodEdificio"] != null)
        this.CodEdificio = this.Request["CodEdificio"];
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindServizio);
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindPiano);
      this.UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.UserStanze1.NameComboPiano = "cmbsPiano";
      if (this.RicercaModulo1.Idbl != "")
        this.hiddenblid.Value = ((TextBox) this.RicercaModulo1.TxtCodice).Text;
      else
        this.hiddenblid.Value = this.CodEdificio;
      ((WebControl) this.btnsSalva).Attributes.Add("onclick", "javascript:return seledificio();");
      ((WebControl) this.cmbsPiano).Attributes.Add("onchange", "clearRoom();");
      if (this.Page.IsPostBack)
        return;
      if (this.itemId != 0)
      {
        this.BindPiano(this.CodEdificio);
        this.BindServizio(this.CodEdificio);
        this.BindGiudizio();
        DataSet dataSet = new DataSet();
        TheSite.Classi.GiudizioCliente.Giudizio giudizio = new TheSite.Classi.GiudizioCliente.Giudizio();
        DataSet singleData = giudizio.GetSingleData(this.itemId);
        if (singleData.Tables[0].Rows.Count == 1)
        {
          DataRow row = singleData.Tables[0].Rows[0];
          ((Label) this.lblCodEdificio).Text = (string) row["codbl"];
          this.lblDenominazione.Text = (string) row["edificioDen"];
          this.lblIndirizzo.Text = (string) row["edificioInd"];
          this.lblComune.Text = (string) row["edificioCom"];
          if (row["blid"] != DBNull.Value)
            this.blid_scelto.Text = row["blid"].ToString();
          if (row["pianoid"] != DBNull.Value && row["pianoid"].ToString() != "0")
            ((ListControl) this.cmbsPiano).SelectedValue = row["pianoid"].ToString();
          if (row["stanzaid"] != DBNull.Value && row["stanzaid"].ToString() != "0")
            this.UserStanze1.IdStanza = row["stanzaid"].ToString();
          if (row["descstanza"] != DBNull.Value || row["descstanza"].ToString() != "-")
            this.UserStanze1.DescStanza = row["descstanza"].ToString();
          if (row["servizioid"] != DBNull.Value && row["servizioid"].ToString() != "0")
            ((ListControl) this.cmbsServizio).SelectedValue = row["servizioid"].ToString();
          if (row["sotid"] != DBNull.Value)
            ((ListControl) this.cmbsGiudizio).SelectedValue = row["sotid"].ToString();
          if (row["numerocont"] != DBNull.Value)
            ((TextBox) this.txtNumero).Text = row["numerocont"].ToString();
          if (row["attivitaisp"] != DBNull.Value)
            ((TextBox) this.txtAttivitaIsp).Text = row["attivitaisp"].ToString();
          if (row["annotazioni"] != DBNull.Value)
            ((TextBox) this.txtAnnotazioni).Text = row["annotazioni"].ToString();
          if (row["datainsert"] != DBNull.Value)
            ((TextBox) this.dataIspezione.Datazione).Text = DateTime.Parse(row["datainsert"].ToString()).ToShortDateString();
          this.lblOperazione.Text = "Modifica Giudizio a Freddo per Edificio: " + ((Label) this.lblCodEdificio).Text;
          this.lblFirstAndLast.Visible = false;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          this.lblFirstAndLast.Text = giudizio.GetFirstAndLastUser(row);
        }
      }
      else
      {
        this.BindPiano("");
        this.BindServizio(((TextBox) this.RicercaModulo1.TxtCodice).Text);
        this.BindGiudizio();
        this.lblOperazione.Text = "Inserimento Giudizio";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      if (this.Request["TipoOper"] == "read")
      {
        this.AbilitaControlli(false);
        this.lblOperazione.Text = "Visualizzazione Giudizio: " + ((Label) this.lblCodEdificio).Text;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Giudizio))
        return;
      this._fp = (Giudizio) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private string IDBL
    {
      get => this.hiddenblid.Value;
      set => this.hiddenblid.Value = value;
    }

    private void BindPiano(string CodEdificio)
    {
      ((ListControl) this.cmbsPiano).Items.Clear();
      DataSet piani = new Richiesta().GetPiani(CodEdificio);
      if (piani.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsPiano).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(piani.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "");
        ((ListControl) this.cmbsPiano).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsPiano).DataValueField = "ID";
        ((Control) this.cmbsPiano).DataBind();
      }
      else
        ((ListControl) this.cmbsPiano).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", "-1"));
    }

    private void BindGiudizio()
    {
      ((ListControl) this.cmbsGiudizio).Items.Clear();
      DataSet dataSet = new TheSite.Classi.GiudizioCliente.Giudizio(HttpContext.Current.User.Identity.Name).GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsGiudizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "SDESCRIZIONE", "SID", "- Selezionare Giudizio -", "0");
      ((ListControl) this.cmbsGiudizio).DataTextField = "SDESCRIZIONE";
      ((ListControl) this.cmbsGiudizio).DataValueField = "SID";
      ((Control) this.cmbsGiudizio).DataBind();
    }

    private void BindServizio(string CodEdificio)
    {
      ((ListControl) this.cmbsServizio).Items.Clear();
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
          ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "Non Definito", "0");
          ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
          ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
          ((Control) this.cmbsServizio).DataBind();
        }
        else
          ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("Non Definito", "0"));
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("Non Definito", "0"));
    }

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.cmbsServizio).Enabled = enabled;
      ((WebControl) this.cmbsPiano).Enabled = enabled;
      ((WebControl) this.cmbsGiudizio).Enabled = enabled;
      ((WebControl) this.txtNumero).Enabled = enabled;
      ((WebControl) this.txtAnnotazioni).Enabled = enabled;
      ((WebControl) this.txtAttivitaIsp).Enabled = enabled;
      ((WebControl) this.dataIspezione.Datazione).Enabled = enabled;
      ((WebControl) this.btnsSalva).Enabled = enabled;
      ((WebControl) this.btnsElimina).Enabled = enabled;
    }

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

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      try
      {
        TheSite.Classi.GiudizioCliente.Giudizio giudizio = new TheSite.Classi.GiudizioCliente.Giudizio();
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_id_piani");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject1).set_Value((object) (((ListControl) this.cmbsPiano).SelectedValue.ToString() == "" ? 0 : int.Parse(((ListControl) this.cmbsPiano).SelectedValue.ToString())));
        CollezioneControlli.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_id_stanza");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject2).set_Value((object) this.UserStanze1.IdStanza);
        CollezioneControlli.Add(sObject2);
        S_Object sObject3 = new S_Object();
        ((ParameterObject) sObject3).set_ParameterName("p_Servizio_Id");
        ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject3).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue.ToString() == "" ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue.ToString())));
        CollezioneControlli.Add(sObject3);
        S_Object sObject4 = new S_Object();
        ((ParameterObject) sObject4).set_ParameterName("p_Giudizio_Id");
        ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject4).set_Value((object) (((ListControl) this.cmbsGiudizio).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsGiudizio).SelectedValue)));
        CollezioneControlli.Add(sObject4);
        S_Object sObject5 = new S_Object();
        ((ParameterObject) sObject5).set_ParameterName("p_numero");
        ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject5).set_Value((object) (((TextBox) this.txtNumero).Text.Trim() == "" ? 1 : int.Parse(((TextBox) this.txtNumero).Text.Trim())));
        CollezioneControlli.Add(sObject5);
        S_Object sObject6 = new S_Object();
        ((ParameterObject) sObject6).set_ParameterName("p_attivita");
        ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject6).set_Size(500);
        ((ParameterObject) sObject6).set_Value((object) ((TextBox) this.txtAttivitaIsp).Text.Trim());
        CollezioneControlli.Add(sObject6);
        S_Object sObject7 = new S_Object();
        ((ParameterObject) sObject7).set_ParameterName("p_annotazioni");
        ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject7).set_Size(4000);
        ((ParameterObject) sObject7).set_Value((object) ((TextBox) this.txtAnnotazioni).Text.Trim());
        CollezioneControlli.Add(sObject7);
        S_Object sObject8 = new S_Object();
        ((ParameterObject) sObject8).set_ParameterName("p_blid");
        ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count);
        if (this.blid_scelto.Text.ToString() == "")
          ((ParameterObject) sObject8).set_Value((object) (this.RicercaModulo1.Idbl == "" ? 0 : int.Parse(this.RicercaModulo1.Idbl)));
        else
          ((ParameterObject) sObject8).set_Value((object) Convert.ToInt32(this.blid_scelto.Text.Trim()));
        CollezioneControlli.Add(sObject8);
        S_Object sObject9 = new S_Object();
        ((ParameterObject) sObject9).set_ParameterName("p_dataIspezione");
        ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject9).set_Size(10);
        ((ParameterObject) sObject9).set_Value((object) ((TextBox) this.dataIspezione.Datazione).Text);
        CollezioneControlli.Add(sObject9);
        if (giudizio.Delete(CollezioneControlli, this.itemId) != -1)
          return;
        this.Server.Transfer("Giudizio.aspx?FunId =" + (object) this.FunId);
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      if (((ListControl) this.cmbsGiudizio).SelectedIndex == 0)
      {
        this.rfvGiudizio.Visible = true;
      }
      else
      {
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_id_piani");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject1).set_Value((object) (((ListControl) this.cmbsPiano).SelectedValue.ToString() == "" ? 0 : int.Parse(((ListControl) this.cmbsPiano).SelectedValue.ToString())));
        CollezioneControlli.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_id_stanza");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject2).set_Value((object) this.UserStanze1.IdStanza);
        CollezioneControlli.Add(sObject2);
        S_Object sObject3 = new S_Object();
        ((ParameterObject) sObject3).set_ParameterName("p_Servizio_Id");
        ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject3).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue.ToString() == "" ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue.ToString())));
        CollezioneControlli.Add(sObject3);
        S_Object sObject4 = new S_Object();
        ((ParameterObject) sObject4).set_ParameterName("p_Giudizio_Id");
        ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject4).set_Value((object) (((ListControl) this.cmbsGiudizio).SelectedValue == "0" ? 5 : int.Parse(((ListControl) this.cmbsGiudizio).SelectedValue)));
        CollezioneControlli.Add(sObject4);
        S_Object sObject5 = new S_Object();
        ((ParameterObject) sObject5).set_ParameterName("p_numero");
        ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject5).set_Value((object) (((TextBox) this.txtNumero).Text.Trim() == "" || ((TextBox) this.txtNumero).Text == "0" ? 1 : int.Parse(((TextBox) this.txtNumero).Text.Trim())));
        CollezioneControlli.Add(sObject5);
        S_Object sObject6 = new S_Object();
        ((ParameterObject) sObject6).set_ParameterName("p_attivita");
        ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject6).set_Size(500);
        ((ParameterObject) sObject6).set_Value((object) ((TextBox) this.txtAttivitaIsp).Text.Trim());
        CollezioneControlli.Add(sObject6);
        S_Object sObject7 = new S_Object();
        ((ParameterObject) sObject7).set_ParameterName("p_annotazioni");
        ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject7).set_Size(4000);
        ((ParameterObject) sObject7).set_Value((object) ((TextBox) this.txtAnnotazioni).Text.Trim());
        CollezioneControlli.Add(sObject7);
        S_Object sObject8 = new S_Object();
        ((ParameterObject) sObject8).set_ParameterName("p_blid");
        ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count);
        if (this.blid_scelto.Text.ToString() == "")
          ((ParameterObject) sObject8).set_Value((object) (this.RicercaModulo1.Idbl == "" ? 0 : int.Parse(this.RicercaModulo1.Idbl)));
        else
          ((ParameterObject) sObject8).set_Value((object) Convert.ToInt32(this.blid_scelto.Text.Trim()));
        CollezioneControlli.Add(sObject8);
        S_Object sObject9 = new S_Object();
        ((ParameterObject) sObject9).set_ParameterName("p_dataIspezione");
        ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject9).set_Size(10);
        ((ParameterObject) sObject9).set_Value((object) ((TextBox) this.dataIspezione.Datazione).Text);
        CollezioneControlli.Add(sObject9);
        try
        {
          if ((this.itemId != 0 ? new TheSite.Classi.GiudizioCliente.Giudizio().Update(CollezioneControlli, this.itemId) : new TheSite.Classi.GiudizioCliente.Giudizio().Add(CollezioneControlli)) == -11)
            return;
          this.Server.Transfer("Giudizio.aspx?FunId =" + (object) this.FunId);
        }
        catch (Exception ex)
        {
          this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
        }
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Giudizio.aspx?FunId =" + (object) this.FunId);
  }
}
