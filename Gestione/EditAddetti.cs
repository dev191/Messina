// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditAddetti
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
  public class EditAddetti : Page
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
    protected S_TextBox txtscognome;
    protected S_TextBox txtsnome;
    protected S_TextBox txtsindirizzo;
    protected S_TextBox txtstelefono;
    protected S_ComboBox cmbsprov_nasc;
    protected S_ComboBox cmbscom_nasc;
    protected S_ComboBox cmbsprov_res;
    protected S_ComboBox cmbscom_res;
    protected S_ComboBox cmbsditta_id;
    protected RequiredFieldValidator rfvcognome;
    protected RequiredFieldValidator rfvnome;
    protected CalendarPicker CalendarPicker1;
    protected ListBox ListBoxLeft;
    protected Button btnAssocia;
    protected Button btnElimina;
    protected ListBox ListBoxRight;
    private DataSet _DsListboxL;
    private DataSet _DsListboxR;
    protected S_TextBox txtscellulare;
    protected S_ComboBox cmbspriorita;
    protected S_TextBox txtszona;
    protected RangeValidator RVcmbsditta;
    protected S_ComboBox cmbsLivello;
    protected S_ComboBox CmbProgetto;
    private Addetti _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      this.CalendarPicker1.Datazione.set_DBParameterName("p_data_nascita");
      this.CalendarPicker1.Datazione.set_DBDirection(ParameterDirection.Input);
      this.CalendarPicker1.Datazione.set_DBDataType((CustomDBType) 2);
      this.CalendarPicker1.Datazione.set_DBIndex(2);
      this.CalendarPicker1.Datazione.set_DBSize(8);
      this.CalendarPicker1.Datazione.set_DBDefaultValue((object) "");
      this.check_caselle_testo();
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      this.BindProgetti();
      this.BindPriorita();
      this.BindProvince();
      this.BindProvince1();
      this.BindDitte();
      this.BindLivello();
      if (this.itemId != 0)
      {
        DataSet dataSet = new DataSet();
        TheSite.Classi.ClassiAnagrafiche.Addetti addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
        DataSet singleData = addetti.GetSingleData(this.itemId);
        if (singleData.Tables[0].Rows.Count == 1)
        {
          DataRow row = singleData.Tables[0].Rows[0];
          ((TextBox) this.txtscognome).Text = (string) row["COGNOME"];
          if (row["NOME"] != DBNull.Value)
            ((TextBox) this.txtsnome).Text = (string) row["NOME"];
          if (row["DATA_NASCITA"] != DBNull.Value)
            ((TextBox) this.CalendarPicker1.Datazione).Text = DateTime.Parse(row["DATA_NASCITA"].ToString()).ToShortDateString();
          if (row["PROV_NASC_ID"] != DBNull.Value)
            ((ListControl) this.cmbsprov_nasc).SelectedValue = row["PROV_NASC_ID"].ToString();
          this.BindComuni();
          if (row["PROV_RES_ID"] != DBNull.Value)
            ((ListControl) this.cmbsprov_res).SelectedValue = row["PROV_RES_ID"].ToString();
          this.BindComuni1();
          if (row["COM_NASC_ID"] != DBNull.Value)
            ((ListControl) this.cmbscom_nasc).SelectedValue = row["COM_NASC_ID"].ToString();
          if (row["COM_RES_ID"] != DBNull.Value)
            ((ListControl) this.cmbscom_res).SelectedValue = row["COM_RES_ID"].ToString();
          if (row["INDIRIZZO"] != DBNull.Value)
            ((TextBox) this.txtsindirizzo).Text = row["INDIRIZZO"].ToString();
          if (row["TELEFONO"] != DBNull.Value)
            ((TextBox) this.txtstelefono).Text = row["TELEFONO"].ToString();
          if (row["CELLULARE"] != DBNull.Value)
            ((TextBox) this.txtscellulare).Text = row["CELLULARE"].ToString();
          if (row["DITTA_ID"] != DBNull.Value)
            ((ListControl) this.cmbsditta_id).SelectedValue = row["DITTA_ID"].ToString();
          if (row["PRIORITA"] != DBNull.Value)
            ((ListControl) this.cmbspriorita).SelectedValue = row["PRIORITA"].ToString();
          if (row["ZONA"] != DBNull.Value)
            ((TextBox) this.txtszona).Text = row["ZONA"].ToString();
          if (row["livello"] != DBNull.Value)
            ((ListControl) this.cmbsLivello).SelectedValue = row["livello"].ToString();
          if (row["progetto"] != DBNull.Value)
            ((ListControl) this.CmbProgetto).SelectedValue = row["progetto"].ToString();
          this.lblOperazione.Text = "Modifica Addetto: " + ((TextBox) this.txtscognome).Text + " " + ((TextBox) this.txtsnome).Text;
          this.lblFirstAndLast.Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          this.lblFirstAndLast.Text = addetti.GetFirstAndLastUser(row);
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Addetto";
        this.BindComuni();
        this.BindComuni1();
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      this.AggiornaListbox();
      if (this.Request["TipoOper"] == "read")
      {
        this.AbilitaControlli(false);
        this.lblOperazione.Text = "Visualizzazione Addetto: " + ((TextBox) this.txtscognome).Text + " " + ((TextBox) this.txtsnome).Text;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Addetti))
        return;
      this._fp = (Addetti) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void BindProgetti()
    {
      ((ListControl) this.CmbProgetto).Items.Clear();
      DataSet data = new Progetti().GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.CmbProgetto).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "descrizione", "id_progetto", "- Selezionare un Progetto -", "");
        ((ListControl) this.CmbProgetto).DataTextField = "descrizione";
        ((ListControl) this.CmbProgetto).DataValueField = "id_progetto";
        ((Control) this.CmbProgetto).DataBind();
      }
      else
        ((ListControl) this.CmbProgetto).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Progetto  -", "-1"));
    }

    private void check_caselle_testo()
    {
      ((WebControl) this.txtscognome).Attributes.Add("onkeypress", "Verifica(this.value,50)");
      ((WebControl) this.txtsnome).Attributes.Add("onkeypress", "Verifica(this.value,50)");
      ((WebControl) this.txtszona).Attributes.Add("onkeypress", "Verifica(this.value,50)");
    }

    private void BindPriorita()
    {
      int index = 0;
      string str = "1";
      while (index < 4)
      {
        ((ListControl) this.cmbspriorita).Items.Insert(index, str);
        ++index;
        str = (index + 1).ToString();
      }
    }

    private void BindProvince()
    {
      ((ListControl) this.cmbsprov_nasc).Items.Clear();
      DataSet dataSet = new ProvinceComuni().GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsprov_nasc).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione_breve", "provincia_id", "- Selezionare una Provincia -", "-1");
      ((ListControl) this.cmbsprov_nasc).DataTextField = "descrizione_breve";
      ((ListControl) this.cmbsprov_nasc).DataValueField = "provincia_id";
      ((Control) this.cmbsprov_nasc).DataBind();
    }

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

    private void BindComuni()
    {
      ((ListControl) this.cmbscom_nasc).Items.Clear();
      ProvinceComuni provinceComuni = new ProvinceComuni();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_provincia_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) ((ListControl) this.cmbsprov_nasc).SelectedValue);
      CollezioneControlli.Add(sObject);
      DataSet dataSet = provinceComuni.GetComune(CollezioneControlli).Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbscom_nasc).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "comune_id", "- Selezionare un Comune -", "-1");
        ((ListControl) this.cmbscom_nasc).DataTextField = "descrizione";
        ((ListControl) this.cmbscom_nasc).DataValueField = "comune_id";
        ((Control) this.cmbscom_nasc).DataBind();
      }
      else
        ((ListControl) this.cmbscom_nasc).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Comune  -", "-1"));
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

    private void BindDitte()
    {
      ((ListControl) this.cmbsditta_id).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Ditte().GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsditta_id).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "id", "- Selezionare una Ditta -", "-1");
      ((ListControl) this.cmbsditta_id).DataTextField = "descrizione";
      ((ListControl) this.cmbsditta_id).DataValueField = "id";
      ((Control) this.cmbsditta_id).DataBind();
    }

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.CmbProgetto).Enabled = enabled;
      ((WebControl) this.txtscognome).Enabled = enabled;
      ((WebControl) this.txtsnome).Enabled = enabled;
      ((WebControl) this.CalendarPicker1.Datazione).Enabled = enabled;
      ((WebControl) this.txtsindirizzo).Enabled = enabled;
      ((WebControl) this.txtstelefono).Enabled = enabled;
      ((WebControl) this.txtscellulare).Enabled = enabled;
      ((WebControl) this.txtszona).Enabled = enabled;
      ((WebControl) this.cmbsprov_nasc).Enabled = enabled;
      ((WebControl) this.cmbscom_nasc).Enabled = enabled;
      ((WebControl) this.cmbsprov_res).Enabled = enabled;
      ((WebControl) this.cmbscom_res).Enabled = enabled;
      ((WebControl) this.cmbsditta_id).Enabled = enabled;
      ((WebControl) this.cmbspriorita).Enabled = enabled;
      ((WebControl) this.cmbsLivello).Enabled = enabled;
      ((WebControl) this.btnsSalva).Enabled = enabled;
      this.ListBoxLeft.Enabled = enabled;
      this.ListBoxRight.Enabled = enabled;
      ((WebControl) this.btnsElimina).Enabled = enabled;
      this.btnAssocia.Enabled = enabled;
      this.btnElimina.Enabled = enabled;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsprov_nasc).SelectedIndexChanged += new EventHandler(this.cmbsprov_nasc_SelectedIndexChanged);
      ((ListControl) this.cmbsprov_res).SelectedIndexChanged += new EventHandler(this.cmbsprov_res_SelectedIndexChanged);
      this.btnAssocia.Click += new EventHandler(this.btnAssocia_Click);
      this.btnElimina.Click += new EventHandler(this.btnElimina_Click);
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      ((Button) this.btnsElimina).Click += new EventHandler(this.btnsElimina_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void BindLivello()
    {
      TheSite.Classi.ClassiAnagrafiche.Livelli livelli = new TheSite.Classi.ClassiAnagrafiche.Livelli();
      ((ListControl) this.cmbsLivello).Items.Clear();
      DataSet dataSet = livelli.GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsLivello).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "codicelivello", "id", "- Selezionare un Livello -", "-1");
      ((ListControl) this.cmbsLivello).DataTextField = "codicelivello";
      ((ListControl) this.cmbsLivello).DataValueField = "id";
      ((Control) this.cmbsLivello).DataBind();
    }

    private void AggiornaListbox()
    {
      this._DsListboxL = new DataSet();
      this._DsListboxR = new DataSet();
      this.CreaTabelle();
      TheSite.Classi.ClassiAnagrafiche.Addetti addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
      DataView dataView1 = new DataView(addetti.GetTRADD(this.itemId).Tables[0]);
      if (dataView1.Count > 0)
      {
        foreach (DataRowView dataRowView in dataView1)
        {
          DataRow row = this._DsListboxL.Tables["Specializzazioni"].NewRow();
          row["Id"] = (object) dataRowView["Id"].ToString();
          row["descrizione"] = (object) dataRowView["descrizione"].ToString();
          this._DsListboxL.Tables["Specializzazioni"].Rows.Add(row);
        }
      }
      this.Session.Add("Spec", (object) this._DsListboxL.Tables[0]);
      this.ListBoxLeft.DataSource = (object) this._DsListboxL.Tables["Specializzazioni"];
      this.ListBoxLeft.DataValueField = "Id";
      this.ListBoxLeft.DataTextField = "Descrizione";
      this.ListBoxLeft.DataBind();
      this.ListBoxLeft.SelectedIndex = 0;
      if (this.itemId > 0)
        this.ListBoxLeft.Enabled = true;
      else
        this.ListBoxLeft.Enabled = false;
      if (this.itemId > 0)
      {
        DataView dataView2 = new DataView(addetti.GetTRAddetto(this.itemId).Tables[0]);
        if (dataView2.Count > 0)
        {
          foreach (DataRowView dataRowView in dataView2)
          {
            DataRow row = this._DsListboxR.Tables["SpecAddetto"].NewRow();
            row["descrizione"] = (object) dataRowView["description"].ToString();
            row["id_tr"] = (object) dataRowView["id_tr"].ToString();
            this._DsListboxR.Tables["SpecAddetto"].Rows.Add(row);
          }
        }
      }
      this.Session.Add("SpecAdd", (object) this._DsListboxR.Tables[0]);
      this.ListBoxRight.DataSource = (object) this._DsListboxR.Tables["SpecAddetto"];
      this.ListBoxRight.DataValueField = "id_tr";
      this.ListBoxRight.DataTextField = "descrizione";
      this.ListBoxRight.DataBind();
      this.ListBoxRight.SelectedIndex = 0;
    }

    private void CreaTabelle()
    {
      DataTable table1 = new DataTable("Specializzazioni");
      table1.Columns.Add(new DataColumn("Id")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = true,
        AllowDBNull = false
      });
      table1.Columns.Add(new DataColumn("descrizione")
      {
        DataType = Type.GetType("System.String"),
        Unique = false,
        AllowDBNull = false
      });
      DataTable table2 = new DataTable("SpecAddetto");
      table2.Columns.Add(new DataColumn("id_tr")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = false,
        AllowDBNull = false
      });
      table2.Columns.Add(new DataColumn("descrizione")
      {
        DataType = Type.GetType("System.String"),
        Unique = false,
        AllowDBNull = false
      });
      table2.Columns.Add(new DataColumn("Operazione")
      {
        DataType = Type.GetType("System.String"),
        Unique = false,
        AllowDBNull = true,
        DefaultValue = (object) "D"
      });
      this._DsListboxL.Tables.Add(table1);
      this._DsListboxR.Tables.Add(table2);
    }

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      try
      {
        this.EliminaTRAddetto();
        TheSite.Classi.ClassiAnagrafiche.Addetti addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
        this.txtscognome.set_DBDefaultValue((object) DBNull.Value);
        this.txtsnome.set_DBDefaultValue((object) DBNull.Value);
        this.txtsindirizzo.set_DBDefaultValue((object) DBNull.Value);
        this.txtstelefono.set_DBDefaultValue((object) DBNull.Value);
        this.txtscellulare.set_DBDefaultValue((object) DBNull.Value);
        this.txtszona.set_DBDefaultValue((object) DBNull.Value);
        this.CalendarPicker1.Datazione.set_DBDefaultValue((object) DBNull.Value);
        this.cmbsprov_nasc.set_DBDefaultValue((object) "-1");
        this.cmbscom_nasc.set_DBDefaultValue((object) "-1");
        this.cmbsprov_res.set_DBDefaultValue((object) "-1");
        this.cmbscom_res.set_DBDefaultValue((object) "-1");
        this.cmbspriorita.set_DBDefaultValue((object) "1");
        this.cmbsLivello.set_DBDefaultValue((object) "-1");
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
        if (addetti.Delete(CollezioneControlli, this.itemId) != -1)
          return;
        this.Server.Transfer("Addetti.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      this.CmbProgetto.set_DBDefaultValue((object) DBNull.Value);
      this.txtscognome.set_DBDefaultValue((object) DBNull.Value);
      this.txtsnome.set_DBDefaultValue((object) DBNull.Value);
      this.txtsindirizzo.set_DBDefaultValue((object) DBNull.Value);
      this.txtstelefono.set_DBDefaultValue((object) DBNull.Value);
      this.txtscellulare.set_DBDefaultValue((object) DBNull.Value);
      this.txtszona.set_DBDefaultValue((object) DBNull.Value);
      this.CalendarPicker1.Datazione.set_DBDefaultValue((object) DBNull.Value);
      this.cmbsprov_nasc.set_DBDefaultValue((object) DBNull.Value);
      this.cmbscom_nasc.set_DBDefaultValue((object) "-1");
      this.cmbsprov_res.set_DBDefaultValue((object) DBNull.Value);
      this.cmbscom_res.set_DBDefaultValue((object) "-1");
      this.cmbsditta_id.set_DBDefaultValue((object) DBNull.Value);
      this.cmbspriorita.set_DBDefaultValue((object) 1);
      this.cmbsLivello.set_DBDefaultValue((object) "-1");
      ((TextBox) this.txtscognome).Text = ((TextBox) this.txtscognome).Text.Trim();
      ((TextBox) this.txtsnome).Text = ((TextBox) this.txtsnome).Text.Trim();
      ((TextBox) this.txtstelefono).Text = ((TextBox) this.txtstelefono).Text.Trim();
      ((TextBox) this.txtscellulare).Text = ((TextBox) this.txtscellulare).Text.Trim();
      ((TextBox) this.txtsindirizzo).Text = ((TextBox) this.txtsindirizzo).Text.Trim();
      ((TextBox) this.txtszona).Text = ((TextBox) this.txtszona).Text.Trim();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        int num = this.itemId != 0 ? new TheSite.Classi.ClassiAnagrafiche.Addetti().Update(CollezioneControlli, this.itemId) : new TheSite.Classi.ClassiAnagrafiche.Addetti().Add(CollezioneControlli);
        if (num <= 0)
          return;
        if (this.ListBoxRight.Items.Count >= 0)
        {
          DataTable dataTable = (DataTable) this.Session["SpecAdd"];
          DataView dataView = new DataView(dataTable);
          foreach (ListItem listItem in this.ListBoxRight.Items)
          {
            dataView.RowFilter = "id_tr = " + listItem.Value.ToString();
            if (dataView.Count == 0)
            {
              DataRow row = dataTable.NewRow();
              row["id_tr"] = (object) listItem.Value.ToString();
              row["descrizione"] = (object) listItem.Text.ToString();
              row["Operazione"] = (object) "I";
              dataTable.Rows.Add(row);
            }
            else if (dataView.Count == 1)
              dataView[0]["Operazione"] = (object) DBNull.Value;
          }
          this.UpdateTR_Addetti(dataTable);
          this.Session.Remove("SpecAdd");
        }
        if (this.itemId == 0)
          this.Response.Redirect("EditAddetti.aspx?ItemId=" + (object) num + "&FunId=" + (object) this.FunId);
        else
          this.Server.Transfer("Addetti.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Addetti.aspx");

    private void cmbsprov_nasc_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (((ListControl) this.cmbsprov_nasc).SelectedIndex > 0)
        this.BindComuni();
      else
        ((ListControl) this.cmbscom_nasc).Items.Clear();
    }

    private void cmbsprov_res_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (((ListControl) this.cmbsprov_res).SelectedIndex > 0)
        this.BindComuni1();
      else
        ((ListControl) this.cmbscom_res).Items.Clear();
    }

    private void btnAssocia_Click(object sender, EventArgs e) => this.Addiziona();

    private void btnElimina_Click(object sender, EventArgs e) => this.Sottrai();

    private void Addiziona()
    {
      if (this.ListBoxLeft.SelectedItem == null)
        return;
      string text = this.ListBoxLeft.SelectedItem.Text;
      string str = this.ListBoxLeft.SelectedItem.Value;
      if (this.ListBoxRight.Items.FindByValue(str) != null)
        return;
      ListItem listItem = new ListItem(text, str);
      this.ListBoxRight.Items.Add(listItem);
      this.ListBoxRight.SelectedIndex = 0;
      this.ListBoxLeft.Items.Remove(listItem);
    }

    private void Sottrai()
    {
      if (this.ListBoxRight.SelectedItem == null)
        return;
      string text = this.ListBoxRight.SelectedItem.Text;
      string str = this.ListBoxRight.SelectedItem.Value;
      if (this.ListBoxLeft.Items.FindByValue(str) != null)
        return;
      ListItem listItem = new ListItem(text, str);
      this.ListBoxLeft.Items.Add(listItem);
      this.ListBoxLeft.SelectedIndex = 0;
      this.ListBoxRight.Items.Remove(listItem);
    }

    private void EliminaTRAddetto()
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id_tr");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) 0);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_addetto_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) this.itemId);
      string Operazione = "Delall";
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.Add(sObject1);
      CollezioneControlli.Add(sObject2);
      new TheSite.Classi.ClassiAnagrafiche.Addetti().ExecuteUpdatePMPAdd_TR(CollezioneControlli, Operazione);
    }

    private void UpdateTR_Addetti(DataTable UpdateDataTable)
    {
      foreach (DataRow row in (InternalDataCollectionBase) UpdateDataTable.Rows)
      {
        if (row["Operazione"] != DBNull.Value)
        {
          TheSite.Classi.ClassiAnagrafiche.Addetti addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
          try
          {
            S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
            S_Object sObject1 = new S_Object();
            ((ParameterObject) sObject1).set_ParameterName("p_Id_tr");
            ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject1).set_Index(0);
            ((ParameterObject) sObject1).set_Value((object) Convert.ToInt32(row["id_tr"].ToString()));
            S_Object sObject2 = new S_Object();
            ((ParameterObject) sObject2).set_ParameterName("p_addetto_Id");
            ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject2).set_Index(1);
            ((ParameterObject) sObject2).set_Value((object) this.itemId);
            CollezioneControlli.Add(sObject1);
            CollezioneControlli.Add(sObject2);
            if (row["Operazione"].ToString() == "I")
              addetti.ExecuteUpdatePMPAdd_TR(CollezioneControlli, "Insert");
            else
              addetti.ExecuteUpdatePMPAdd_TR(CollezioneControlli, "Delete");
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }
      }
    }
  }
}
