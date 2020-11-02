// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditFornitori
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

namespace TheSite.Gestione
{
  public class EditFornitori : Page
  {
    protected MessagePanel PanelMess;
    protected Panel PanelEdit;
    private int itemId = 0;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected ValidationSummary vlsEdit;
    protected Label lblOperazione;
    private int FunId = 0;
    protected S_TextBox txtsindirizzo;
    protected S_TextBox txtstelefono;
    protected S_ComboBox cmbsprov_res;
    protected S_ComboBox cmbscom_res;
    protected S_TextBox txtsFornitore;
    protected S_TextBox txtsfax;
    protected S_TextBox txtsemail;
    protected S_TextBox txtspiva;
    protected S_TextBox txtscap;
    protected RequiredFieldValidator rfvFornitore;
    protected RegularExpressionValidator REVtxtsemail;
    private Fornitori _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      this.BindProvince1();
      if (this.itemId != 0)
      {
        DataSet dataSet = new DataSet();
        TheSite.Classi.ClassiAnagrafiche.Fornitori fornitori = new TheSite.Classi.ClassiAnagrafiche.Fornitori();
        DataSet singleData = fornitori.GetSingleData(this.itemId);
        if (singleData.Tables[0].Rows.Count == 1)
        {
          DataRow row = singleData.Tables[0].Rows[0];
          ((TextBox) this.txtsFornitore).Text = (string) row["FORNITORE"];
          if (row["PROVINCIA_ID"] != DBNull.Value)
            ((ListControl) this.cmbsprov_res).SelectedValue = row["PROVINCIA_ID"].ToString();
          this.BindComuni1();
          if (row["COMUNE_ID"] != DBNull.Value)
            ((ListControl) this.cmbscom_res).SelectedValue = row["COMUNE_ID"].ToString();
          if (row["INDIRIZZO"] != DBNull.Value)
            ((TextBox) this.txtsindirizzo).Text = row["INDIRIZZO"].ToString();
          if (row["TELEFONO"] != DBNull.Value)
            ((TextBox) this.txtstelefono).Text = row["TELEFONO"].ToString();
          if (row["FAX"] != DBNull.Value)
            ((TextBox) this.txtsfax).Text = row["FAX"].ToString();
          if (row["CAP"] != DBNull.Value)
            ((TextBox) this.txtscap).Text = row["CAP"].ToString();
          if (row["IVA"] != DBNull.Value)
            ((TextBox) this.txtspiva).Text = row["IVA"].ToString();
          if (row["EMAIL"] != DBNull.Value)
            ((TextBox) this.txtsemail).Text = row["EMAIL"].ToString();
          this.lblOperazione.Text = "Modifica Fornitore: " + ((TextBox) this.txtsFornitore).Text;
          this.lblFirstAndLast.Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          this.lblFirstAndLast.Text = fornitori.GetFirstAndLastUser(row);
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Fornitore";
        this.BindComuni1();
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      if (this.Request["TipoOper"] == "read")
      {
        this.AbilitaControlli(false);
        this.lblOperazione.Text = "Visualizzazione Fornitore: " + ((TextBox) this.txtsFornitore).Text;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Fornitori))
        return;
      this._fp = (Fornitori) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void BindProvince1()
    {
      ((ListControl) this.cmbsprov_res).Items.Clear();
      DataSet dataSet = new ProvinceComuni().GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsprov_res).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione_breve", "provincia_id", "- Selezionare una Provincia -", "-1");
      ((ListControl) this.cmbsprov_res).DataTextField = "descrizione_breve";
      ((ListControl) this.cmbsprov_res).DataValueField = "provincia_id";
      ((Control) this.cmbsprov_res).DataBind();
    }

    private void BindComuni1()
    {
      ((ListControl) this.cmbscom_res).Items.Clear();
      ProvinceComuni provinceComuni = new ProvinceComuni();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_provincia_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) ((ListControl) this.cmbsprov_res).SelectedValue);
      CollezioneControlli.Add(sObject);
      DataSet dataSet = provinceComuni.GetComune(CollezioneControlli).Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbscom_res).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "comune_id", "- Selezionare un Comune -", "-1");
        ((ListControl) this.cmbscom_res).DataTextField = "descrizione";
        ((ListControl) this.cmbscom_res).DataValueField = "comune_id";
        ((Control) this.cmbscom_res).DataBind();
      }
      else
        ((ListControl) this.cmbscom_res).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Comune  -", "-1"));
    }

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.txtsFornitore).Enabled = enabled;
      ((WebControl) this.txtsindirizzo).Enabled = enabled;
      ((WebControl) this.txtstelefono).Enabled = enabled;
      ((WebControl) this.cmbsprov_res).Enabled = enabled;
      ((WebControl) this.cmbscom_res).Enabled = enabled;
      ((WebControl) this.txtspiva).Enabled = enabled;
      ((WebControl) this.txtsfax).Enabled = enabled;
      ((WebControl) this.txtsemail).Enabled = enabled;
      ((WebControl) this.txtscap).Enabled = enabled;
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
      ((ListControl) this.cmbsprov_res).SelectedIndexChanged += new EventHandler(this.cmbsprov_res_SelectedIndexChanged);
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      ((Button) this.btnsElimina).Click += new EventHandler(this.btnsElimina_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      try
      {
        TheSite.Classi.ClassiAnagrafiche.Fornitori fornitori = new TheSite.Classi.ClassiAnagrafiche.Fornitori();
        this.txtsFornitore.set_DBDefaultValue((object) DBNull.Value);
        this.txtsindirizzo.set_DBDefaultValue((object) DBNull.Value);
        this.txtstelefono.set_DBDefaultValue((object) DBNull.Value);
        this.txtspiva.set_DBDefaultValue((object) DBNull.Value);
        this.txtsfax.set_DBDefaultValue((object) DBNull.Value);
        this.txtscap.set_DBDefaultValue((object) DBNull.Value);
        this.txtsemail.set_DBDefaultValue((object) DBNull.Value);
        this.cmbsprov_res.set_DBDefaultValue((object) "-1");
        this.cmbscom_res.set_DBDefaultValue((object) "-1");
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
        string text = ((ListControl) this.cmbscom_res).SelectedItem.Text;
        S_Object sObject = new S_Object();
        ((ParameterObject) sObject).set_ParameterName("p_city");
        ((ParameterObject) sObject).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject).set_Index(9);
        ((ParameterObject) sObject).set_Size(30);
        ((ParameterObject) sObject).set_Value((object) text);
        CollezioneControlli.Add(sObject);
        if (fornitori.Delete(CollezioneControlli, this.itemId) != -1)
          return;
        this.Server.Transfer("Fornitori.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      this.txtsFornitore.set_DBDefaultValue((object) DBNull.Value);
      this.txtsindirizzo.set_DBDefaultValue((object) DBNull.Value);
      this.txtstelefono.set_DBDefaultValue((object) DBNull.Value);
      this.txtspiva.set_DBDefaultValue((object) DBNull.Value);
      this.txtsfax.set_DBDefaultValue((object) DBNull.Value);
      this.txtscap.set_DBDefaultValue((object) DBNull.Value);
      this.txtsemail.set_DBDefaultValue((object) DBNull.Value);
      this.cmbsprov_res.set_DBDefaultValue((object) "-1");
      this.cmbscom_res.set_DBDefaultValue((object) "-1");
      ((TextBox) this.txtsFornitore).Text = ((TextBox) this.txtsFornitore).Text.Trim();
      ((TextBox) this.txtstelefono).Text = ((TextBox) this.txtstelefono).Text.Trim();
      ((TextBox) this.txtsindirizzo).Text = ((TextBox) this.txtsindirizzo).Text.Trim();
      ((TextBox) this.txtspiva).Text = ((TextBox) this.txtspiva).Text.Trim();
      ((TextBox) this.txtsfax).Text = ((TextBox) this.txtsfax).Text.Trim();
      ((TextBox) this.txtscap).Text = ((TextBox) this.txtscap).Text.Trim();
      ((TextBox) this.txtsemail).Text = ((TextBox) this.txtsemail).Text.Trim();
      string text = ((ListControl) this.cmbscom_res).SelectedItem.Text;
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_city");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(9);
      ((ParameterObject) sObject).set_Size(30);
      ((ParameterObject) sObject).set_Value((object) text);
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      CollezioneControlli.Add(sObject);
      try
      {
        int num = this.itemId != 0 ? new TheSite.Classi.ClassiAnagrafiche.Fornitori().Update(CollezioneControlli, this.itemId) : new TheSite.Classi.ClassiAnagrafiche.Fornitori().Add(CollezioneControlli);
        if (num > 0 && num != -11)
          this.Server.Transfer("Fornitori.aspx");
        else
          SiteJavaScript.msgBox(this.Page, "Il Fornitore é stato già inserito");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Fornitori.aspx");

    private void cmbsprov_res_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (((ListControl) this.cmbsprov_res).SelectedIndex > 0)
        this.BindComuni1();
      else
        ((ListControl) this.cmbscom_res).Items.Clear();
    }
  }
}
