// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditDitte
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
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class EditDitte : Page
  {
    protected Label lblOperazione;
    protected Panel PanelEdit;
    protected ListBox ListBoxLeft;
    protected Button btnAssocia;
    protected Button btnElimina;
    protected ListBox ListBoxRight;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected S_TextBox txtsIndirizzo;
    protected S_ComboBox cmbsProvincia;
    protected S_ComboBox cmbsTipo;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected S_ComboBox cmbsComune;
    protected S_TextBox txtsTelefono;
    protected S_TextBox txtsEmail;
    protected S_TextBox TxtsCAP;
    protected ValidationSummary vlsEdit;
    protected PageTitle PageTitle1;
    public static string HelpLink = string.Empty;
    private int itemId = 0;
    private int FunId = 0;
    private DataSet _DsListBox;
    private DataSet _DsListBoxD;
    protected S_TextBox txtsReferente;
    protected RegularExpressionValidator RegularExpressionValidator1;
    protected RequiredFieldValidator rfvUserName;
    protected ListBox ListBoxLeftF;
    protected Button btnAssociaF;
    protected Button btnEliminaF;
    protected ListBox ListBoxRightF;
    protected MessagePanel PanelMess;
    protected S_TextBox txtsDescrizione;
    protected RegularExpressionValidator REVtxtsemail;
    private Ditte _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["itemId"] != null)
        this.itemId = int.Parse(this.Request["itemId"]);
      StringBuilder stringBuilder1 = new StringBuilder();
      stringBuilder1.Append("document.getElementById('" + ((Control) this.cmbsComune).ClientID + "').disabled = true;");
      stringBuilder1.Append("document.getElementById('" + ((Control) this.cmbsTipo).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsProvincia).Attributes.Add("onchange", stringBuilder1.ToString());
      StringBuilder stringBuilder2 = new StringBuilder();
      stringBuilder2.Append("document.getElementById('" + ((Control) this.cmbsComune).ClientID + "').disabled = true;");
      stringBuilder2.Append("document.getElementById('" + ((Control) this.cmbsProvincia).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsTipo).Attributes.Add("onchange", stringBuilder2.ToString());
      if (this.Page.IsPostBack)
        return;
      this.InizializzaControlliClient();
      this.BindProvince();
      this.BindTipologiaDitta();
      if (this.itemId != 0)
      {
        TheSite.Classi.ClassiAnagrafiche.Ditte ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
        DataSet dataSet = ditte.GetSingleData(this.itemId).Copy();
        if (dataSet.Tables[0].Rows.Count == 1)
        {
          DataRow row = dataSet.Tables[0].Rows[0];
          ((TextBox) this.txtsDescrizione).Text = (string) row["DESCRIZIONE"];
          if (row["INDIRIZZO"] != DBNull.Value)
            ((TextBox) this.txtsIndirizzo).Text = (string) row["INDIRIZZO"];
          if (row["CAP"] != DBNull.Value)
            ((TextBox) this.TxtsCAP).Text = (string) row["CAP"];
          if (row["EMAIL"] != DBNull.Value)
            ((TextBox) this.txtsEmail).Text = (string) row["EMAIL"];
          if (row["TELEFONO"] != DBNull.Value)
            ((TextBox) this.txtsTelefono).Text = (string) row["TELEFONO"];
          if (row["REFERENTE"] != DBNull.Value)
            ((TextBox) this.txtsReferente).Text = (string) row["REFERENTE"];
          if (row["PROVINCIA_ID"] != DBNull.Value)
            ((ListControl) this.cmbsProvincia).SelectedValue = row["PROVINCIA_ID"].ToString();
          this.BindComuni();
          if (row["COMUNE_ID"] != DBNull.Value)
            ((ListControl) this.cmbsComune).SelectedValue = row["COMUNE_ID"].ToString();
          if (row["TIPOLOGIADITTA_ID"] != DBNull.Value)
            ((ListControl) this.cmbsTipo).SelectedValue = row["TIPOLOGIADITTA_ID"].ToString();
          this.lblFirstAndLast.Text = ditte.GetFirstAndLastUser(row);
          this.lblOperazione.Text = "Modifica Ditta: " + ((TextBox) this.txtsDescrizione).Text;
          this.lblFirstAndLast.Visible = true;
          this.ListBoxLeft.Enabled = true;
          this.ListBoxRight.Enabled = true;
          this.btnAssocia.Enabled = true;
          this.btnElimina.Enabled = true;
          ((Control) this.btnsElimina).Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          this.ControllaListeFornitori();
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Ditta";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
        this.BindComuni();
        this.ImpostaProvinciaDefault("CT", "CATANIA");
      }
      this.AggiornaListBox();
      if (this.Request["TipoOper"] == "read")
      {
        this.AbilitaControlli(false);
        this.lblOperazione.Text = "Visualizzazione Ditta: " + ((TextBox) this.txtsDescrizione).Text;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Ditte))
        return;
      this._fp = (Ditte) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void ControllaListeFornitori()
    {
      bool flag = false;
      if (((ListControl) this.cmbsTipo).SelectedValue == "1")
        flag = true;
      this.ListBoxLeftF.Enabled = flag;
      this.ListBoxRightF.Enabled = flag;
      this.btnAssociaF.Enabled = flag;
      this.btnEliminaF.Enabled = flag;
    }

    private void InizializzaControlliClient() => ((WebControl) this.TxtsCAP).Attributes.Add("onkeypress", "SoloNumeri()");

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.TxtsCAP).Enabled = enabled;
      ((WebControl) this.txtsDescrizione).Enabled = enabled;
      ((WebControl) this.txtsEmail).Enabled = enabled;
      ((WebControl) this.txtsIndirizzo).Enabled = enabled;
      ((WebControl) this.txtsReferente).Enabled = enabled;
      ((WebControl) this.txtsTelefono).Enabled = enabled;
      ((WebControl) this.cmbsProvincia).Enabled = enabled;
      ((WebControl) this.cmbsComune).Enabled = enabled;
      ((WebControl) this.cmbsTipo).Enabled = enabled;
      ((WebControl) this.btnsElimina).Enabled = enabled;
      ((WebControl) this.btnsSalva).Enabled = enabled;
      this.btnAssocia.Enabled = enabled;
      this.btnElimina.Enabled = enabled;
      this.ListBoxLeft.Enabled = enabled;
      this.ListBoxRight.Enabled = enabled;
      this.btnAssociaF.Enabled = enabled;
      this.btnEliminaF.Enabled = enabled;
      this.ListBoxLeftF.Enabled = enabled;
      this.ListBoxRightF.Enabled = enabled;
    }

    private bool IsDup()
    {
      DataSet dataSet = new TheSite.Classi.Function().ControllaDuplicato("Ditta", "Descrizione", "'" + ((TextBox) this.txtsDescrizione).Text.Trim().Replace("'", "''") + "'", "Ditta_ID");
      if (dataSet.Tables[0].Rows.Count == 0)
        return false;
      DataRow row = dataSet.Tables[0].Rows[0];
      return this.itemId <= 0 || int.Parse(row[0].ToString()) != this.itemId;
    }

    private void UpdateServizi_Ditta(DataTable UpdateDataTable)
    {
      foreach (DataRow row in (InternalDataCollectionBase) UpdateDataTable.Rows)
      {
        if (row["Operazione"] != DBNull.Value)
        {
          TheSite.Classi.ClassiAnagrafiche.Ditte ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
          try
          {
            S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
            S_Object sObject1 = new S_Object();
            ((ParameterObject) sObject1).set_ParameterName("p_Ditta_Id");
            ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject1).set_Index(0);
            ((ParameterObject) sObject1).set_Value((object) this.itemId);
            S_Object sObject2 = new S_Object();
            ((ParameterObject) sObject2).set_ParameterName("p_Servizio_Id");
            ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject2).set_Index(1);
            ((ParameterObject) sObject2).set_Value((object) Convert.ToInt32(row["Id"].ToString()));
            CollezioneControlli.Add(sObject1);
            CollezioneControlli.Add(sObject2);
            ExecuteType Operazione = !(row["Operazione"].ToString() == "I") ? ExecuteType.Delete : ExecuteType.Insert;
            ditte.UpdateServizi_Ditta(CollezioneControlli, Operazione);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }
      }
    }

    private void UpdateFornitori_Ditta(DataTable UpdateDataTable)
    {
      foreach (DataRow row in (InternalDataCollectionBase) UpdateDataTable.Rows)
      {
        if (row["Operazione"] != DBNull.Value)
        {
          TheSite.Classi.ClassiAnagrafiche.Ditte ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
          try
          {
            S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
            S_Object sObject1 = new S_Object();
            ((ParameterObject) sObject1).set_ParameterName("p_Ditta_Id");
            ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject1).set_Index(0);
            ((ParameterObject) sObject1).set_Value((object) this.itemId);
            S_Object sObject2 = new S_Object();
            ((ParameterObject) sObject2).set_ParameterName("p_Fornitore_Id");
            ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject2).set_Index(1);
            ((ParameterObject) sObject2).set_Value((object) Convert.ToInt32(row["idD"].ToString()));
            CollezioneControlli.Add(sObject1);
            CollezioneControlli.Add(sObject2);
            ExecuteType Operazione = !(row["Operazione"].ToString() == "I") ? ExecuteType.Delete : ExecuteType.Insert;
            ditte.UpdateFornitori_Ditta(CollezioneControlli, Operazione);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }
      }
    }

    private void BindProvince()
    {
      ((ListControl) this.cmbsProvincia).Items.Clear();
      DataSet dataSet = new ProvinceComuni().GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsProvincia).DataSource = (object) dataSet;
      ((ListControl) this.cmbsProvincia).DataTextField = "descrizione_breve";
      ((ListControl) this.cmbsProvincia).DataValueField = "provincia_id";
      ((Control) this.cmbsProvincia).DataBind();
    }

    private void BindComuni()
    {
      ((ListControl) this.cmbsComune).Items.Clear();
      ProvinceComuni provinceComuni = new ProvinceComuni();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_provincia_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) ((ListControl) this.cmbsProvincia).SelectedValue);
      CollezioneControlli.Add(sObject);
      DataSet dataSet = provinceComuni.GetComune(CollezioneControlli).Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsComune).DataSource = (object) dataSet;
        ((ListControl) this.cmbsComune).DataTextField = "descrizione";
        ((ListControl) this.cmbsComune).DataValueField = "comune_id";
        ((Control) this.cmbsComune).DataBind();
      }
      else
        ((ListControl) this.cmbsComune).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Comune  -", "-1"));
    }

    private void ImpostaProvinciaDefault(string provincia, string comune)
    {
      ((ListControl) this.cmbsProvincia).SelectedValue = ((ListControl) this.cmbsProvincia).Items.FindByText(provincia).Value;
      this.BindComuni();
      ((ListControl) this.cmbsComune).SelectedValue = ((ListControl) this.cmbsComune).Items.FindByText(comune).Value;
    }

    private void BindTipologiaDitta()
    {
      ((ListControl) this.cmbsTipo).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.TipologiaDitta().GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsTipo).DataSource = (object) dataSet.Tables[0];
      ((ListControl) this.cmbsTipo).DataTextField = "descrizione";
      ((ListControl) this.cmbsTipo).DataValueField = "tipologiaditta_id";
      ((Control) this.cmbsTipo).DataBind();
    }

    private void AggiornaListBox()
    {
      this._DsListBox = new DataSet();
      this._DsListBoxD = new DataSet();
      this.CreaTabelle();
      if (this.itemId > 0)
      {
        DataView dataView = new DataView(new TheSite.Classi.ClassiAnagrafiche.Ditte().GetServiziDitta(this.itemId).Tables[0]);
        if (dataView.Count > 0)
        {
          foreach (DataRowView dataRowView in dataView)
          {
            DataRow row = this._DsListBox.Tables["ServiziDitta"].NewRow();
            row["Id"] = (object) dataRowView["IDSERVIZIO"].ToString();
            row["Servizio"] = (object) dataRowView["DESCRIZIONE"].ToString();
            row["IdUtente"] = (object) "1";
            this._DsListBox.Tables["ServiziDitta"].Rows.Add(row);
          }
        }
      }
      this.Session.Add("ServiziDitta", (object) this._DsListBox.Tables["ServiziDitta"]);
      this.ListBoxRight.DataSource = (object) this._DsListBox.Tables["ServiziDitta"];
      this.ListBoxRight.DataValueField = "Id";
      this.ListBoxRight.DataTextField = "Servizio";
      this.ListBoxRight.DataBind();
      this.ListBoxRight.SelectedIndex = 0;
      DataView dataView1 = new DataView(new TheSite.Classi.ClassiDettaglio.Servizi(HttpContext.Current.User.Identity.Name).GetData().Tables[0]);
      if (dataView1.Count > 0)
      {
        foreach (DataRowView dataRowView in dataView1)
        {
          if (this.ListBoxRight.Items.FindByValue(dataRowView["IDSERVIZIO"].ToString()) == null)
          {
            DataRow row = this._DsListBox.Tables["Servizi"].NewRow();
            row["Id"] = (object) dataRowView["IDSERVIZIO"].ToString();
            row["Servizio"] = (object) dataRowView["DESCRIZIONE"].ToString();
            this._DsListBox.Tables["Servizi"].Rows.Add(row);
          }
        }
      }
      this.ListBoxLeft.DataSource = (object) this._DsListBox.Tables["Servizi"];
      this.ListBoxLeft.DataValueField = "Id";
      this.ListBoxLeft.DataTextField = "Servizio";
      this.ListBoxLeft.DataBind();
      this.ListBoxLeft.SelectedIndex = 0;
      if (this.itemId > 0)
      {
        DataView dataView2 = new DataView(new TheSite.Classi.ClassiAnagrafiche.Ditte().GetFornitoriDitta(this.itemId).Tables[0]);
        if (dataView2.Count > 0)
        {
          foreach (DataRowView dataRowView in dataView2)
          {
            DataRow row = this._DsListBoxD.Tables["DittaSubDitta"].NewRow();
            row["IdD"] = (object) dataRowView["idD"].ToString();
            row["DittaSubAss"] = (object) dataRowView["DESCRIZIONE"].ToString();
            row["IdUtente"] = (object) "1";
            this._DsListBoxD.Tables["DittaSubDitta"].Rows.Add(row);
          }
        }
      }
      this.Session.Add("FornitoriDitta", (object) this._DsListBoxD.Tables["DittaSubDitta"]);
      this.ListBoxRightF.DataSource = (object) this._DsListBoxD.Tables["DittaSubDitta"];
      this.ListBoxRightF.DataValueField = "IdD";
      this.ListBoxRightF.DataTextField = "DittaSubAss";
      this.ListBoxRightF.DataBind();
      this.ListBoxRightF.SelectedIndex = 0;
      DataView dataView3 = new DataView(new TheSite.Classi.ClassiAnagrafiche.Ditte().GetDitteSub().Tables[0]);
      if (dataView3.Count > 0)
      {
        foreach (DataRowView dataRowView in dataView3)
        {
          if (this.ListBoxRightF.Items.FindByValue(dataRowView["idD"].ToString()) == null)
          {
            DataRow row = this._DsListBoxD.Tables["DitteSub"].NewRow();
            row["IdD"] = (object) dataRowView["IdD"].ToString();
            row["DittaSub"] = (object) dataRowView["DESCRIZIONE"].ToString();
            this._DsListBoxD.Tables["DitteSub"].Rows.Add(row);
          }
        }
      }
      this.ListBoxLeftF.DataSource = (object) this._DsListBoxD.Tables["DitteSub"];
      this.ListBoxLeftF.DataValueField = "IdD";
      this.ListBoxLeftF.DataTextField = "DittaSub";
      this.ListBoxLeftF.DataBind();
      this.ListBoxLeftF.SelectedIndex = 0;
    }

    private void CreaTabelle()
    {
      DataTable table1 = new DataTable("Servizi");
      table1.Columns.Add(new DataColumn("Id")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = true,
        AllowDBNull = false
      });
      table1.Columns.Add(new DataColumn("Servizio")
      {
        DataType = Type.GetType("System.String"),
        Unique = false,
        AllowDBNull = false
      });
      DataTable table2 = new DataTable("ServiziDitta");
      table2.Columns.Add(new DataColumn("Id")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = true,
        AllowDBNull = false
      });
      table2.Columns.Add(new DataColumn("IdUtente")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = false,
        AllowDBNull = false
      });
      table2.Columns.Add(new DataColumn("Servizio")
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
      this._DsListBox.Tables.Add(table1);
      this._DsListBox.Tables.Add(table2);
      DataTable table3 = new DataTable("DitteSub");
      table3.Columns.Add(new DataColumn("IdD")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = true,
        AllowDBNull = false
      });
      table3.Columns.Add(new DataColumn("DittaSub")
      {
        DataType = Type.GetType("System.String"),
        Unique = false,
        AllowDBNull = false
      });
      DataTable table4 = new DataTable("DittaSubDitta");
      table4.Columns.Add(new DataColumn("IdD")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = true,
        AllowDBNull = false
      });
      table4.Columns.Add(new DataColumn("IdUtente")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = false,
        AllowDBNull = false
      });
      table4.Columns.Add(new DataColumn("DittaSubAss")
      {
        DataType = Type.GetType("System.String"),
        Unique = false,
        AllowDBNull = false
      });
      table4.Columns.Add(new DataColumn("Operazione")
      {
        DataType = Type.GetType("System.String"),
        Unique = false,
        AllowDBNull = true,
        DefaultValue = (object) "D"
      });
      this._DsListBoxD.Tables.Add(table3);
      this._DsListBoxD.Tables.Add(table4);
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsProvincia).SelectedIndexChanged += new EventHandler(this.cmbsProvincia_SelectedIndexChanged);
      ((ListControl) this.cmbsTipo).SelectedIndexChanged += new EventHandler(this.cmbsTipo_SelectedIndexChanged);
      this.btnAssocia.Click += new EventHandler(this.btnAssocia_Click);
      this.btnElimina.Click += new EventHandler(this.btnElimina_Click);
      this.btnAssociaF.Click += new EventHandler(this.btnAssociaF_Click);
      this.btnEliminaF.Click += new EventHandler(this.btnEliminaF_Click);
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      ((Button) this.btnsElimina).Click += new EventHandler(this.btnsElimina_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void cmbsProvincia_SelectedIndexChanged(object sender, EventArgs e) => this.BindComuni();

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      TheSite.Classi.ClassiAnagrafiche.Ditte ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
      this.TxtsCAP.set_DBDefaultValue((object) DBNull.Value);
      this.txtsDescrizione.set_DBDefaultValue((object) DBNull.Value);
      this.txtsEmail.set_DBDefaultValue((object) DBNull.Value);
      this.txtsIndirizzo.set_DBDefaultValue((object) DBNull.Value);
      this.txtsReferente.set_DBDefaultValue((object) DBNull.Value);
      this.txtsTelefono.set_DBDefaultValue((object) DBNull.Value);
      this.cmbsProvincia.set_DBDefaultValue((object) DBNull.Value);
      this.cmbsComune.set_DBDefaultValue((object) 0);
      this.cmbsTipo.set_DBDefaultValue((object) DBNull.Value);
      ((TextBox) this.TxtsCAP).Text = ((TextBox) this.TxtsCAP).Text.Trim();
      ((TextBox) this.txtsDescrizione).Text = ((TextBox) this.txtsDescrizione).Text.Trim();
      ((TextBox) this.txtsEmail).Text = ((TextBox) this.txtsEmail).Text.Trim();
      ((TextBox) this.txtsIndirizzo).Text = ((TextBox) this.txtsIndirizzo).Text.Trim();
      ((TextBox) this.txtsReferente).Text = ((TextBox) this.txtsReferente).Text.Trim();
      ((TextBox) this.txtsTelefono).Text = ((TextBox) this.txtsTelefono).Text.Trim();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        int num = this.itemId != 0 ? ditte.Update(CollezioneControlli, this.itemId) : ditte.Add(CollezioneControlli);
        if (num == -11)
          SiteJavaScript.msgBox(this.Page, "Ditta già inserita nel DataBase.");
        if (num <= 0)
          return;
        if (this.ListBoxRight.Items.Count >= 0)
        {
          DataTable dataTable = (DataTable) this.Session["ServiziDitta"];
          DataView dataView = new DataView(dataTable);
          foreach (ListItem listItem in this.ListBoxRight.Items)
          {
            dataView.RowFilter = "Id = " + listItem.Value.ToString();
            if (dataView.Count == 0)
            {
              DataRow row = dataTable.NewRow();
              row["Id"] = (object) listItem.Value.ToString();
              row["Servizio"] = (object) listItem.Text.ToString();
              row["IdUtente"] = (object) num;
              row["Operazione"] = (object) "I";
              dataTable.Rows.Add(row);
            }
            else if (dataView.Count == 1)
              dataView[0]["Operazione"] = (object) DBNull.Value;
          }
          this.UpdateServizi_Ditta(dataTable);
          this.Session.Remove("ServiziDitta");
        }
        if (this.ListBoxRightF.Items.Count >= 0)
        {
          DataTable dataTable = (DataTable) this.Session["FornitoriDitta"];
          DataView dataView = new DataView(dataTable);
          foreach (ListItem listItem in this.ListBoxRightF.Items)
          {
            dataView.RowFilter = "idD = " + listItem.Value.ToString();
            if (dataView.Count == 0)
            {
              DataRow row = dataTable.NewRow();
              row["idD"] = (object) listItem.Value.ToString();
              row["DittaSubAss"] = (object) listItem.Text.ToString();
              row["IdUtente"] = (object) num;
              row["Operazione"] = (object) "I";
              dataTable.Rows.Add(row);
            }
            else if (dataView.Count == 1)
              dataView[0]["Operazione"] = (object) DBNull.Value;
          }
          this.UpdateFornitori_Ditta(dataTable);
          this.Session.Remove("FornitoriDitta");
        }
        if (this.itemId == 0)
          this.Response.Redirect("EditDitte.aspx?ItemId=" + (object) num + "&FunId=" + (object) this.FunId);
        else
          this.Server.Transfer("Ditte.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Ditte.aspx");

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      try
      {
        TheSite.Classi.ClassiAnagrafiche.Ditte ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
        this.TxtsCAP.set_DBDefaultValue((object) DBNull.Value);
        this.txtsDescrizione.set_DBDefaultValue((object) DBNull.Value);
        this.txtsEmail.set_DBDefaultValue((object) DBNull.Value);
        this.txtsIndirizzo.set_DBDefaultValue((object) DBNull.Value);
        this.txtsReferente.set_DBDefaultValue((object) DBNull.Value);
        this.txtsTelefono.set_DBDefaultValue((object) DBNull.Value);
        this.cmbsProvincia.set_DBDefaultValue((object) DBNull.Value);
        this.cmbsComune.set_DBDefaultValue((object) DBNull.Value);
        this.cmbsTipo.set_DBDefaultValue((object) DBNull.Value);
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
        if (ditte.Delete(CollezioneControlli, this.itemId) != -1)
          return;
        this.Server.Transfer("Ditte.aspx?");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnElimina_Click(object sender, EventArgs e)
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

    private void btnAssocia_Click(object sender, EventArgs e)
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

    private void cmbsTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.itemId <= 0)
        return;
      this.ControllaListeFornitori();
    }

    private void btnAssociaF_Click(object sender, EventArgs e)
    {
      if (this.ListBoxLeftF.SelectedItem == null)
        return;
      string text = this.ListBoxLeftF.SelectedItem.Text;
      string str = this.ListBoxLeftF.SelectedItem.Value;
      if (this.ListBoxRightF.Items.FindByValue(str) != null)
        return;
      ListItem listItem = new ListItem(text, str);
      this.ListBoxRightF.Items.Add(listItem);
      this.ListBoxRightF.SelectedIndex = 0;
      this.ListBoxLeftF.Items.Remove(listItem);
    }

    private void btnEliminaF_Click(object sender, EventArgs e)
    {
      if (this.ListBoxRightF.SelectedItem == null)
        return;
      string text = this.ListBoxRightF.SelectedItem.Text;
      string str = this.ListBoxRightF.SelectedItem.Value;
      if (this.ListBoxLeftF.Items.FindByValue(str) != null)
        return;
      ListItem listItem = new ListItem(text, str);
      this.ListBoxLeftF.Items.Add(listItem);
      this.ListBoxLeftF.SelectedIndex = 0;
      this.ListBoxRightF.Items.Remove(listItem);
    }
  }
}
