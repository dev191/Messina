// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditRichiedenti
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
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class EditRichiedenti : Page
  {
    protected S_TextBox txtsFrequenza_des;
    protected S_TextBox txtsFrequenza;
    protected DataPanel PanelRicerca;
    protected S_Button btnsRicerca;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    private int itemId = 0;
    public static int FunId = 0;
    protected Label lblOperazione;
    protected MessagePanel PanelMess;
    protected Panel PanelEdit;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected ValidationSummary vlsEdit;
    protected RequiredFieldValidator rvfdescrizione;
    public static string HelpLink = string.Empty;
    protected S_TextBox txtsNome;
    protected S_TextBox txtsCognome;
    protected S_ComboBox cmbsGruppo;
    protected RequiredFieldValidator RequiredFieldValidator1;
    protected S_TextBox txtstelefono;
    protected S_TextBox txtsemail;
    protected S_TextBox txtsstanza;
    protected RegularExpressionValidator REVtxtsemail;
    protected RequiredFieldValidator rvfnome;
    protected RequiredFieldValidator rfvcognome;
    protected S_ComboBox CmbProgetto;
    private Richiedenti _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      EditRichiedenti.FunId = int.Parse(this.Request["FunId"]);
      string id_tipo = "";
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      this.BindProgetti();
      if (this.itemId != 0)
      {
        DataSet dataSet = new DataSet();
        DataSet singleData = new TheSite.Classi.ClassiAnagrafiche.Richiedenti().GetSingleData(this.itemId);
        if (singleData.Tables[0].Rows.Count == 1)
        {
          DataRow row = singleData.Tables[0].Rows[0];
          if (row["cognome"] != DBNull.Value)
            ((TextBox) this.txtsCognome).Text = (string) row["cognome"];
          if (row["nome"] != DBNull.Value)
            ((TextBox) this.txtsNome).Text = row["nome"].ToString();
          if (row["phone"] != DBNull.Value)
            ((TextBox) this.txtstelefono).Text = row["phone"].ToString();
          if (row["email"] != DBNull.Value)
            ((TextBox) this.txtsemail).Text = row["email"].ToString();
          if (row["stanza"] != DBNull.Value)
            ((TextBox) this.txtsstanza).Text = row["stanza"].ToString();
          if (row["progetto"] != DBNull.Value)
            ((ListControl) this.CmbProgetto).SelectedValue = row["progetto"].ToString();
          this.lblOperazione.Text = "Modifica Richiedente";
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?');");
          id_tipo = row["id_tipo"].ToString();
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Richiedente";
        ((Control) this.btnsElimina).Visible = false;
      }
      if (this.Request["TipoOper"] == "read")
        this.AbilitaControlli(false);
      this.getAllGruppo(id_tipo);
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Richiedenti))
        return;
      this._fp = (Richiedenti) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    private void getAllGruppo(string id_tipo)
    {
      ((ListControl) this.cmbsGruppo).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo().GetAllData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsGruppo).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "id", "- Selezionare una Gruppo -", "");
      ((ListControl) this.cmbsGruppo).DataTextField = "descrizione";
      ((ListControl) this.cmbsGruppo).DataValueField = "id";
      if (id_tipo != "")
        ((ListControl) this.cmbsGruppo).SelectedValue = id_tipo;
      ((Control) this.cmbsGruppo).DataBind();
    }

    private void BindProgetti()
    {
      ((ListControl) this.CmbProgetto).Items.Clear();
      DataSet data = new Progetti().GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.CmbProgetto).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "descrizione", "id_progetto", "- Selezionare un Progetto -", "0");
        ((ListControl) this.CmbProgetto).DataTextField = "descrizione";
        ((ListControl) this.CmbProgetto).DataValueField = "id_progetto";
        ((Control) this.CmbProgetto).DataBind();
      }
      else
        ((ListControl) this.CmbProgetto).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Progetto  -", "-1"));
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.CmbProgetto).Enabled = enabled;
      ((WebControl) this.txtsCognome).Enabled = enabled;
      ((WebControl) this.txtsNome).Enabled = enabled;
      ((WebControl) this.btnsSalva).Enabled = enabled;
      ((WebControl) this.btnsElimina).Enabled = enabled;
      ((WebControl) this.cmbsGruppo).Enabled = enabled;
      ((WebControl) this.txtstelefono).Enabled = enabled;
      ((WebControl) this.txtsemail).Enabled = enabled;
      ((WebControl) this.txtsstanza).Enabled = enabled;
      this.lblOperazione.Text = "Visualizzazione Richiedente";
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

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      TheSite.Classi.ClassiAnagrafiche.Richiedenti richiedenti = new TheSite.Classi.ClassiAnagrafiche.Richiedenti();
      this.txtsNome.set_DBDefaultValue((object) "%");
      this.txtsCognome.set_DBDefaultValue((object) "%");
      this.CmbProgetto.set_DBDefaultValue((object) DBNull.Value);
      S_ControlsCollection CollezioneControlli1 = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_nome");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.txtsNome).Text);
      CollezioneControlli1.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_cognome");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.txtsCognome).Text);
      CollezioneControlli1.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_idGruppo");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) ((ListControl) this.cmbsGruppo).SelectedValue);
      CollezioneControlli1.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_progetto");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) ((ListControl) this.CmbProgetto).SelectedValue);
      CollezioneControlli1.Add(sObject4);
      if (richiedenti.CheckData(CollezioneControlli1).Copy().Tables[0].Rows.Count == 0 || this.itemId != 0)
      {
        this.txtsCognome.set_DBDefaultValue((object) DBNull.Value);
        this.txtsNome.set_DBDefaultValue((object) DBNull.Value);
        if (((ListControl) this.CmbProgetto).SelectedValue == "0")
          this.cmbsGruppo.set_DBDefaultValue((object) DBNull.Value);
        this.txtstelefono.set_DBDefaultValue((object) DBNull.Value);
        this.txtsemail.set_DBDefaultValue((object) DBNull.Value);
        this.txtsstanza.set_DBDefaultValue((object) DBNull.Value);
        S_ControlsCollection CollezioneControlli2 = new S_ControlsCollection();
        CollezioneControlli2.AddItems((object) this.PanelEdit.Controls);
        S_Object sObject5 = new S_Object();
        ((ParameterObject) sObject5).set_ParameterName("p_progetto");
        ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject5).set_Index(3);
        if (((ListControl) this.CmbProgetto).SelectedValue == "0")
          ((ParameterObject) sObject5).set_Value((object) DBNull.Value);
        else
          ((ParameterObject) sObject5).set_Value((object) ((ListControl) this.CmbProgetto).SelectedValue);
        CollezioneControlli2.Add(sObject5);
        try
        {
          if ((this.itemId != 0 ? new TheSite.Classi.ClassiAnagrafiche.Richiedenti().Update(CollezioneControlli2, this.itemId) : new TheSite.Classi.ClassiAnagrafiche.Richiedenti().Add(CollezioneControlli2)) <= 0)
            return;
          this.Server.Transfer("Richiedenti.aspx");
        }
        catch (Exception ex)
        {
          this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
        }
      }
      else
        this.PanelMess.ShowError("Richiedente esistente", true);
    }

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      try
      {
        this.txtsCognome.set_DBDefaultValue((object) DBNull.Value);
        this.txtsNome.set_DBDefaultValue((object) DBNull.Value);
        this.txtstelefono.set_DBDefaultValue((object) DBNull.Value);
        this.txtsemail.set_DBDefaultValue((object) DBNull.Value);
        this.txtsstanza.set_DBDefaultValue((object) DBNull.Value);
        this.cmbsGruppo.set_DBDefaultValue((object) DBNull.Value);
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
        S_Object sObject = new S_Object();
        ((ParameterObject) sObject).set_ParameterName("p_progetto");
        ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject).set_Index(3);
        if (((ListControl) this.CmbProgetto).SelectedValue == "0")
          ((ParameterObject) sObject).set_Value((object) DBNull.Value);
        else
          ((ParameterObject) sObject).set_Value((object) ((ListControl) this.CmbProgetto).SelectedValue);
        CollezioneControlli.Add(sObject);
        if (new TheSite.Classi.ClassiAnagrafiche.Richiedenti().Delete(CollezioneControlli, this.itemId) != -1)
          return;
        this.Server.Transfer("Richiedenti.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Richiedenti.aspx");
  }
}
