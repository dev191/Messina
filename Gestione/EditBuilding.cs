// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditBuilding
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using Microsoft.Web.UI.WebControls;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class EditBuilding : Page
  {
    protected S_TextBox S_TextBox1;
    protected S_TextBox S_TEXTBOX2;
    private Buildings _fp;
    private int itemId = 0;
    private string TipoOper = "";
    public static int FunId = 0;
    public static int TabId = 0;
    private DataSet _DsListBox;
    private DataSet _DsListBoxD;
    protected Panel PanelEditServizi;
    protected RequiredFieldValidator rfvCAP;
    protected DataGrid DataGridServizi;
    protected Label lblOperazione;
    protected MessagePanel PanelMess;
    protected TabStrip TabStrip1;
    protected RequiredFieldValidator rfvBL_ID;
    protected S_TextBox txtsBL_ID;
    protected RequiredFieldValidator rfvName;
    protected S_TextBox txtsNome;
    protected RequiredFieldValidator rfvIndirizzo;
    protected S_TextBox txtsIndirizzo;
    protected S_TextBox txtsIndirizzo2;
    protected RangeValidator rvProvincia;
    protected S_ComboBox cmbsProvincia;
    protected RangeValidator rvComune;
    protected S_ComboBox cmbsComune;
    protected RegularExpressionValidator revZIP;
    protected S_TextBox TxtsCAP;
    protected RangeValidator rvDitta;
    protected S_ComboBox cmbsDitta;
    protected S_TextBox txtsCommenti;
    protected Panel PanelEditAnag;
    protected TextBox txtsLeftMail;
    protected Button btnAssociaE;
    protected Button btnEliminaE;
    protected ListBox ListboxRightE;
    protected Panel PanelEditMail;
    protected RequiredFieldValidator rfvPiani;
    protected Button btnAssociaP;
    protected Button btnEliminaP;
    protected Panel PanelEditPiani;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected ValidationSummary vlsEdit;
    protected RegularExpressionValidator REVEmail;
    protected DataGrid DataGridEsegui;
    protected Label lblRecord;
    protected LinkButton lkbNuovo;
    protected Panel PanelEditStanze;
    protected S_ComboBox cmbsUso;
    protected RangeValidator rvUso;
    protected LinkButton nuovoPiano;
    protected Label LabelPiano;
    protected DataGrid DataGridPiani;
    protected HtmlInputHidden Hidden1;
    protected HtmlInputHidden HiddenPianiStanze;
    public string descRep = "";
    public string descRep1 = "";
    public string id = "";
    public string id1 = "";
    public string descUso = "";
    public string descUso1 = "";
    public string Usoid = "";
    public string Usoid1 = "";
    protected Button ButtonRefreshMq;
    protected ListBox ListBoxLeftP;
    protected ListBox ListBoxRightP;
    protected S_ComboBox CmbProgetto;
    protected RangeValidator RANGProg;
    protected S_ComboBox cmbsLocalizzazione;
    private Stanze _RM = new Stanze();

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      ((WebControl) this.TabStrip1).Attributes.Add("onclick", "Abilita(this.selectedIndex);");
      ((WebControl) this.txtsBL_ID).Attributes.Add("onpaste", "return false;");
      EditBuilding.TabId = this.TabStrip1.get_SelectedIndex();
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"].ToString());
      if (this.Request["FunId"] != null)
        EditBuilding.FunId = int.Parse(this.Request["FunId"].ToString());
      if (this.Request["TipoOper"] != null)
        this.TipoOper = this.Request["TipoOper"].ToString();
      if (!this.Page.IsPostBack)
      {
        this.DataGridEsegui.Columns[1].Visible = true;
        this.DataGridEsegui.Columns[2].Visible = false;
        this.DataGridEsegui.Columns[3].Visible = false;
        this.BindGrid();
        this.DataGridPiani.Columns[1].Visible = true;
        this.DataGridPiani.Columns[2].Visible = false;
        this.DataGridPiani.Columns[3].Visible = false;
        this.BindGridPiani();
        this.BindProvince();
        this.ImpostaProvinciaDefault("CT", "CATANIA");
        this.BindUsi();
        this.BindDitte();
        this.BindLocalizzazione();
        if (this.itemId != 0)
        {
          TheSite.Classi.ClassiAnagrafiche.Buildings buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
          DataSet dataSet = buildings.GetSingleData(this.itemId).Copy();
          if (dataSet.Tables[0].Rows.Count == 1)
          {
            DataRow row = dataSet.Tables[0].Rows[0];
            if (row["BL_ID"] != DBNull.Value)
              ((TextBox) this.txtsBL_ID).Text = (string) row["BL_ID"];
            if (row["NAME"] != DBNull.Value)
              ((TextBox) this.txtsNome).Text = (string) row["NAME"];
            if (row["INDIRIZZO1"] != DBNull.Value)
              ((TextBox) this.txtsIndirizzo).Text = (string) row["INDIRIZZO1"];
            if (row["INDIRIZZO2"] != DBNull.Value)
              ((TextBox) this.txtsIndirizzo2).Text = (string) row["INDIRIZZO2"];
            if (row["PROVINCIA_ID"] != DBNull.Value)
              ((ListControl) this.cmbsProvincia).SelectedValue = row["PROVINCIA_ID"].ToString();
            this.BindComuni();
            if (row["COMUNE_ID"] != DBNull.Value)
              ((ListControl) this.cmbsComune).SelectedValue = row["COMUNE_ID"].ToString();
            if (row["id_bl_localizzazione"] != DBNull.Value)
              ((ListControl) this.cmbsLocalizzazione).SelectedValue = row["id_bl_localizzazione"].ToString();
            if (row["ZIP"] != DBNull.Value)
              ((TextBox) this.TxtsCAP).Text = (string) row["ZIP"];
            if (row["BL_USE_ID"] != DBNull.Value)
              ((ListControl) this.cmbsUso).SelectedValue = row["BL_USE_ID"].ToString();
            if (row["DITTA_ID"] != DBNull.Value)
              ((ListControl) this.cmbsDitta).SelectedValue = row["DITTA_ID"].ToString();
            if (row["COMMENTS"] != DBNull.Value)
              ((TextBox) this.txtsCommenti).Text = (string) row["COMMENTS"];
            if (row["id_progetto"] != DBNull.Value)
              this.BindProgetti(int.Parse(row["id_progetto"].ToString()));
            else
              this.BindProgetti(0);
            this.ListboxRightE.Items.Clear();
            if (row["OPTION2"] != DBNull.Value)
            {
              string[] strArray = row["OPTION2"].ToString().Split(";".ToCharArray());
              for (int index = 0; index < strArray.Length; ++index)
              {
                if (strArray[index] != "")
                  this.ListboxRightE.Items.Add(strArray[index]);
              }
            }
            this.lblFirstAndLast.Text = buildings.GetFirstAndLastUser(row);
            ((WebControl) this.txtsBL_ID).Enabled = false;
            this.lblOperazione.Text = "Modifica Edificio: " + ((TextBox) this.txtsBL_ID).Text;
            this.lblFirstAndLast.Visible = true;
            ((Control) this.btnsElimina).Visible = true;
            ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          }
        }
        else
        {
          ((WebControl) this.txtsBL_ID).Enabled = true;
          this.lblOperazione.Text = "Inserimento Edificio";
          this.lblFirstAndLast.Visible = false;
          ((Control) this.btnsElimina).Visible = false;
          this.BindProgetti(0);
        }
        this.AggiornaListBox();
        if (this.TipoOper == "read")
        {
          this.AbilitaControlli(false);
          this.lblOperazione.Text = "Visualizzazione Edificio: " + ((TextBox) this.txtsBL_ID).Text;
        }
        this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
        if (this.Context.Handler is Buildings)
        {
          this._fp = (Buildings) this.Context.Handler;
          this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
        }
        this.TabStrip1.get_Items().get_Item(4).set_Enabled(true);
      }
      ((WebControl) this.btnsSalva).Enabled = true;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsProvincia).SelectedIndexChanged += new EventHandler(this.cmbsProvincia_SelectedIndexChanged);
      this.DataGridServizi.ItemDataBound += new DataGridItemEventHandler(this.DataGridServizi_ItemDataBound);
      this.btnAssociaE.Click += new EventHandler(this.btnAssociaE_Click);
      this.btnEliminaE.Click += new EventHandler(this.btnEliminaE_Click);
      this.nuovoPiano.Click += new EventHandler(this.nuovoPiano_Click);
      this.DataGridPiani.ItemCommand += new DataGridCommandEventHandler(this.DataGridPiani_ItemCommand);
      this.DataGridPiani.CancelCommand += new DataGridCommandEventHandler(this.DataGridPiani_CancelCommand);
      this.DataGridPiani.EditCommand += new DataGridCommandEventHandler(this.DataGridPiani_EditCommand);
      this.DataGridPiani.UpdateCommand += new DataGridCommandEventHandler(this.DataGridPiani_UpdateCommand_1);
      this.DataGridPiani.ItemDataBound += new DataGridItemEventHandler(this.DataGridPiani_ItemDataBound);
      this.ButtonRefreshMq.Click += new EventHandler(this.ButtonRefreshMq_Click);
      this.lkbNuovo.Click += new EventHandler(this.lkbNuovo_Click);
      this.DataGridEsegui.ItemCommand += new DataGridCommandEventHandler(this.DataGridEsegui_ItemCommand);
      this.DataGridEsegui.CancelCommand += new DataGridCommandEventHandler(this.DataGridEsegui_CancelCommand);
      this.DataGridEsegui.EditCommand += new DataGridCommandEventHandler(this.DataGridEsegui_EditCommand);
      this.DataGridEsegui.UpdateCommand += new DataGridCommandEventHandler(this.DataGridEsegui_UpdateCommand_1);
      this.DataGridEsegui.ItemDataBound += new DataGridItemEventHandler(this.DataGridEsegui_ItemDataBound);
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      ((Button) this.btnsElimina).Click += new EventHandler(this.btnsElimina_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void AggiornaListBox()
    {
      this._DsListBox = new DataSet();
      this._DsListBoxD = new DataSet();
      this.CreaTabelle();
      DataView dataView1 = new DataView(new TheSite.Classi.ClassiAnagrafiche.Buildings().GetServiziBuilding(this.itemId).Tables[0]);
      this.DataGridServizi.DataSource = (object) dataView1;
      this.DataGridServizi.DataBind();
      int count = dataView1.Count;
      if (this.itemId > 0)
      {
        DataView dataView2 = new DataView(new TheSite.Classi.ClassiAnagrafiche.Buildings().GetPianiBuilding(this.itemId).Tables[0]);
        if (dataView2.Count > 0)
        {
          foreach (DataRowView dataRowView in dataView2)
          {
            DataRow row = this._DsListBoxD.Tables["PianiBuildings"].NewRow();
            row["ID"] = (object) dataRowView["ID"].ToString();
            row["DESCRIZIONE"] = (object) dataRowView["DESCRIZIONE"].ToString();
            this._DsListBoxD.Tables["PianiBuildings"].Rows.Add(row);
          }
        }
      }
      this.Session.Add("PianiBuildings", (object) this._DsListBoxD.Tables["PianiBuildings"]);
      DataView dataView3 = new DataView(new TheSite.Classi.ClassiAnagrafiche.Buildings().GetAllPiani().Tables[0]);
    }

    private void CreaTabelle()
    {
      DataTable table1 = new DataTable("DitteMaster");
      table1.Columns.Add(new DataColumn("IdD")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = true,
        AllowDBNull = false
      });
      table1.Columns.Add(new DataColumn("DittaMaster")
      {
        DataType = Type.GetType("System.String"),
        Unique = false,
        AllowDBNull = false
      });
      DataTable table2 = new DataTable("DitteBuildings");
      table2.Columns.Add(new DataColumn("IdD")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = true,
        AllowDBNull = false
      });
      table2.Columns.Add(new DataColumn("DESCRIZIONE")
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
      this._DsListBoxD.Tables.Add(table1);
      this._DsListBoxD.Tables.Add(table2);
      DataTable table3 = new DataTable("Piani");
      table3.Columns.Add(new DataColumn("ID")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = true,
        AllowDBNull = false
      });
      table3.Columns.Add(new DataColumn("Descrizione")
      {
        DataType = Type.GetType("System.String"),
        Unique = false,
        AllowDBNull = false
      });
      DataTable table4 = new DataTable("PianiBuildings");
      table4.Columns.Add(new DataColumn("ID")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = true,
        AllowDBNull = false
      });
      table4.Columns.Add(new DataColumn("DESCRIZIONE")
      {
        DataType = Type.GetType("System.String"),
        Unique = false,
        AllowDBNull = false
      });
      this._DsListBoxD.Tables.Add(table3);
      this._DsListBoxD.Tables.Add(table4);
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

    private void BindDitte()
    {
      ((ListControl) this.cmbsDitta).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Ditte().GetDitteMaster().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsDitta).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "idD", "- Selezionare una Ditta -", "0");
      ((ListControl) this.cmbsDitta).DataTextField = "descrizione";
      ((ListControl) this.cmbsDitta).DataValueField = "idD";
      ((Control) this.cmbsDitta).DataBind();
    }

    private void BindUsi()
    {
      ((ListControl) this.cmbsUso).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Buildings().GetAllUsi().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsUso).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "BL_USE_ID", "- Selezionare un Uso -", "0");
      ((ListControl) this.cmbsUso).DataTextField = "descrizione";
      ((ListControl) this.cmbsUso).DataValueField = "BL_USE_ID";
      ((Control) this.cmbsUso).DataBind();
    }

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.txtsBL_ID).Enabled = enabled;
      ((WebControl) this.txtsNome).Enabled = enabled;
      ((WebControl) this.txtsIndirizzo).Enabled = enabled;
      ((WebControl) this.txtsIndirizzo2).Enabled = enabled;
      ((WebControl) this.cmbsProvincia).Enabled = enabled;
      ((WebControl) this.cmbsComune).Enabled = enabled;
      ((WebControl) this.cmbsUso).Enabled = enabled;
      ((WebControl) this.CmbProgetto).Enabled = enabled;
      ((WebControl) this.cmbsDitta).Enabled = enabled;
      ((WebControl) this.TxtsCAP).Enabled = enabled;
      ((WebControl) this.txtsCommenti).Enabled = enabled;
      ((WebControl) this.btnsElimina).Enabled = enabled;
      ((WebControl) this.btnsSalva).Enabled = enabled;
      this.DataGridServizi.Enabled = enabled;
      this.btnAssociaE.Enabled = enabled;
      this.btnEliminaE.Enabled = enabled;
      this.txtsLeftMail.Enabled = enabled;
      this.ListboxRightE.Enabled = enabled;
      this.DataGridPiani.Enabled = enabled;
      this.ButtonRefreshMq.Enabled = enabled;
      this.DataGridEsegui.Enabled = enabled;
    }

    private void BindProgetti(int progetto)
    {
      ((ListControl) this.CmbProgetto).Items.Clear();
      DataSet data = new Progetti().GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.CmbProgetto).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "descrizione", "id_progetto", "- Selezionare un Progetto -", "0");
        ((ListControl) this.CmbProgetto).DataTextField = "descrizione";
        ((ListControl) this.CmbProgetto).DataValueField = "id_progetto";
        ((Control) this.CmbProgetto).DataBind();
        ((ListControl) this.CmbProgetto).SelectedValue = progetto.ToString();
      }
      else
        ((ListControl) this.CmbProgetto).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Progetto  -", "-1"));
    }

    private void BindLocalizzazione()
    {
      ((ListControl) this.cmbsLocalizzazione).Items.Clear();
      DataSet dataSet = new ProvinceComuni().GetLocalizzazione(new S_ControlsCollection()).Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsLocalizzazione).DataSource = (object) dataSet;
        ((ListControl) this.cmbsLocalizzazione).DataTextField = "descrizione";
        ((ListControl) this.cmbsLocalizzazione).DataValueField = "id";
        ((Control) this.cmbsLocalizzazione).DataBind();
      }
      else
        ((ListControl) this.cmbsLocalizzazione).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Comune  -", "-1"));
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

    private void cmbsProvincia_SelectedIndexChanged(object sender, EventArgs e) => this.BindComuni();

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Buildings.aspx");

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      try
      {
        this.txtsBL_ID.set_DBDefaultValue((object) DBNull.Value);
        this.txtsNome.set_DBDefaultValue((object) DBNull.Value);
        this.txtsIndirizzo.set_DBDefaultValue((object) DBNull.Value);
        this.txtsIndirizzo2.set_DBDefaultValue((object) DBNull.Value);
        this.cmbsProvincia.set_DBDefaultValue((object) 0);
        this.cmbsComune.set_DBDefaultValue((object) 0);
        this.TxtsCAP.set_DBDefaultValue((object) DBNull.Value);
        this.cmbsUso.set_DBDefaultValue((object) 0);
        this.cmbsDitta.set_DBDefaultValue((object) 0);
        this.txtsCommenti.set_DBDefaultValue((object) DBNull.Value);
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        CollezioneControlli.AddItems((object) this.PanelEditAnag.Controls);
        TheSite.Classi.ClassiAnagrafiche.Buildings buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_Arr_Piani");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
        ((ParameterObject) sObject1).set_Value((object) DBNull.Value);
        CollezioneControlli.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_MAIL");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
        ((ParameterObject) sObject2).set_Value((object) DBNull.Value);
        CollezioneControlli.Add(sObject2);
        if (buildings.Delete(CollezioneControlli, this.itemId) != -1)
          return;
        this.Server.Transfer("Buildings.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAssociaE_Click(object sender, EventArgs e)
    {
      if (!(this.txtsLeftMail.Text.Trim() != ""))
        return;
      string text = this.txtsLeftMail.Text.Trim();
      if (this.ListboxRightE.Items.FindByValue(text) != null)
        return;
      this.ListboxRightE.Items.Add(new ListItem(text));
      this.ListboxRightE.SelectedIndex = 0;
      this.txtsLeftMail.Text = "";
    }

    private void btnEliminaE_Click(object sender, EventArgs e)
    {
      if (this.ListboxRightE.SelectedItem == null)
        return;
      this.ListboxRightE.Items.Remove(new ListItem(this.ListboxRightE.SelectedItem.Text, this.ListboxRightE.SelectedItem.Value));
    }

    private void btnAssociaP_Click(object sender, EventArgs e)
    {
    }

    private void btnEliminaP_Click(object sender, EventArgs e)
    {
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      string msg = "";
      if (this.ControllaDate(ref msg))
      {
        string str = "";
        TheSite.Classi.ClassiAnagrafiche.Buildings buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
        this.txtsBL_ID.set_DBDefaultValue((object) DBNull.Value);
        this.txtsNome.set_DBDefaultValue((object) DBNull.Value);
        this.txtsIndirizzo.set_DBDefaultValue((object) DBNull.Value);
        this.txtsIndirizzo2.set_DBDefaultValue((object) DBNull.Value);
        this.cmbsProvincia.set_DBDefaultValue((object) 0);
        this.cmbsComune.set_DBDefaultValue((object) 0);
        this.CmbProgetto.set_DBDefaultValue((object) 0);
        this.TxtsCAP.set_DBDefaultValue((object) DBNull.Value);
        this.cmbsUso.set_DBDefaultValue((object) 0);
        this.cmbsDitta.set_DBDefaultValue((object) 0);
        this.txtsCommenti.set_DBDefaultValue((object) DBNull.Value);
        this.txtsBL_ID.set_DBDefaultValue((object) ((TextBox) this.txtsBL_ID).Text.Trim());
        this.txtsNome.set_DBDefaultValue((object) ((TextBox) this.txtsNome).Text.Trim());
        this.txtsIndirizzo.set_DBDefaultValue((object) ((TextBox) this.txtsIndirizzo).Text.Trim());
        this.txtsIndirizzo2.set_DBDefaultValue((object) ((TextBox) this.txtsIndirizzo2).Text.Trim());
        this.TxtsCAP.set_DBDefaultValue((object) ((TextBox) this.TxtsCAP).Text.Trim());
        this.txtsCommenti.set_DBDefaultValue((object) ((TextBox) this.txtsCommenti).Text.Trim());
        S_ControlsCollection CollezioneControlli1 = new S_ControlsCollection();
        CollezioneControlli1.AddItems((object) this.PanelEditAnag.Controls);
        if (this.ListboxRightE.Items.Count >= 0)
        {
          foreach (ListItem listItem in this.ListboxRightE.Items)
            str = str + listItem.Text.ToString() + ";";
          if (str.Length != 0)
            str = str.Substring(0, str.Length - 1);
        }
        S_Object sObject = new S_Object();
        ((ParameterObject) sObject).set_ParameterName("p_MAIL");
        ((ParameterObject) sObject).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject).set_Index(11);
        ((ParameterObject) sObject).set_Size((int) byte.MaxValue);
        ((ParameterObject) sObject).set_Value((object) str);
        CollezioneControlli1.Add(sObject);
        try
        {
          buildings.beginTransaction();
          int itemID;
          if (this.itemId == 0)
          {
            itemID = buildings.Add(CollezioneControlli1);
            this.itemId = itemID;
          }
          else
            itemID = buildings.Update(CollezioneControlli1, this.itemId);
          if (itemID > 0 && itemID != -11)
          {
            S_ControlsCollection CollezioneControlli2 = new S_ControlsCollection();
            buildings.DeleteServizi(CollezioneControlli2, this.itemId);
            for (int index = 0; index <= this.DataGridServizi.Items.Count - 1; ++index)
            {
              if (((CheckBox) this.DataGridServizi.Items[index].Cells[0].FindControl("chks_Associato")).Checked)
              {
                S_ControlsCollection CollezioneControlli3 = this.ControlsServizi(((TextBox) ((CalendarPicker) this.DataGridServizi.Items[index].Cells[3].FindControl("CalPckDataDa")).Datazione).Text, ((TextBox) ((CalendarPicker) this.DataGridServizi.Items[index].Cells[4].FindControl("CalPckDataA")).Datazione).Text, int.Parse(this.DataGridServizi.Items[index].Cells[0].Text));
                buildings.AddServizi(CollezioneControlli3, itemID);
              }
            }
            buildings.commitTransaction();
            this.Server.Transfer("EditBuilding.aspx?FunId=" + EditBuilding.FunId.ToString() + "&itemId=" + this.itemId.ToString() + "&TipoOper=write");
          }
          else
          {
            buildings.rollbackTransaction();
            SiteJavaScript.msgBox(this.Page, "L'edificio é stato già inserito.");
          }
        }
        catch (Exception ex)
        {
          buildings.rollbackTransaction();
          this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
        }
        finally
        {
          ((WebControl) this.btnsSalva).Enabled = true;
        }
      }
      else
        this.PanelMess.ShowError(msg, true);
    }

    private bool ControllaDate(ref string msg)
    {
      int num = 0;
      for (int index = 0; index <= this.DataGridServizi.Items.Count - 1; ++index)
      {
        if (((CheckBox) this.DataGridServizi.Items[index].Cells[0].FindControl("chks_Associato")).Checked)
        {
          CalendarPicker control1 = (CalendarPicker) this.DataGridServizi.Items[index].Cells[3].FindControl("CalPckDataDa");
          CalendarPicker control2 = (CalendarPicker) this.DataGridServizi.Items[index].Cells[3].FindControl("CalPckDataA");
          if (((TextBox) control1.Datazione).Text.Trim() != "" && ((TextBox) control2.Datazione).Text.Trim() != "")
          {
            if (DateTime.Parse(((TextBox) control1.Datazione).Text) > DateTime.Parse(((TextBox) control2.Datazione).Text))
            {
              msg = "La data inizio servizio non può essere maggiore della data di fine servizio.";
              return false;
            }
            ++num;
          }
          else
          {
            msg = "Valorizzare le date di inizio e fine servizio per i servizi associati.";
            return false;
          }
        }
      }
      if (num == 0)
      {
        msg = "Occorre selezionare almeno un servizio.";
        return false;
      }
      msg = "";
      return true;
    }

    private S_ControlsCollection ControlsServizi(
      string DataDa,
      string DataA,
      int id_Servizio)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      int num1 = 0;
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_ID_Servizio");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(10);
      ((ParameterObject) sObject1).set_Index(num1);
      ((ParameterObject) sObject1).set_Value((object) id_Servizio);
      int num2 = num1 + 1;
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_dataDa");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 5);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Index(num2);
      ((ParameterObject) sObject2).set_Value((object) DataDa);
      int num3 = num2 + 1;
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_dataA");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 5);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Index(num3);
      ((ParameterObject) sObject3).set_Value((object) DataA);
      controlsCollection.Add(sObject1);
      controlsCollection.Add(sObject2);
      controlsCollection.Add(sObject3);
      return controlsCollection;
    }

    private void DataGridServizi_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      CalendarPicker control1 = (CalendarPicker) e.Item.Cells[3].FindControl("CalPckDataDa");
      CalendarPicker control2 = (CalendarPicker) e.Item.Cells[4].FindControl("CalPckDataA");
      if (control1 != null)
        ((TextBox) control1.Datazione).Text = DataBinder.Eval(e.Item.DataItem, "date_start").ToString();
      if (control2 == null)
        return;
      ((TextBox) control2.Datazione).Text = DataBinder.Eval(e.Item.DataItem, "date_end").ToString();
    }

    public DataTable GetPianiEdificio() => new TheSite.Classi.ClassiAnagrafiche.Buildings().GetPianiBuilding(this.itemId).Tables[0];

    protected int GetIndex(string item) => item.Length > 0 ? int.Parse(item) : 0;

    protected string Decimale(string item, string tipo) => tipo == "Int" ? TheSite.Classi.Function.GetTypeNumber((object) item, NumberType.Intero) : TheSite.Classi.Function.GetTypeNumber((object) item, NumberType.Decimale);

    private void lkbNuovo_Click(object sender, EventArgs e)
    {
      this.BindGrid();
      this.DataGridEsegui.ShowFooter = true;
      this.DataGridEsegui.Columns[1].Visible = false;
      this.DataGridEsegui.Columns[2].Visible = false;
      this.DataGridEsegui.Columns[3].Visible = true;
    }

    private S_ControlsCollection ControlsStanze(
      int Piano,
      string Stanza,
      string DescrizioneStanza,
      double Mq,
      int id_rm_cat,
      int id_rm_reparto,
      int id_rm_dest_uso)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_BL_ID");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(10);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject1).set_Value((object) this.itemId);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_piani");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject2).set_Value((object) Piano);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject3).set_Value((object) Stanza);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_descstanza");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject4).set_Value((object) DescrizioneStanza);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_id_rm_cat");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size(10);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject5).set_Value((object) id_rm_cat);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_id_rm_reparto");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Size(10);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject6).set_Value((object) id_rm_reparto);
      controlsCollection.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_id_rm_dest_uso");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(10);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject7).set_Value((object) id_rm_dest_uso);
      controlsCollection.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_mq");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Size(10);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject8).set_Value((object) Mq);
      controlsCollection.Add(sObject8);
      return controlsCollection;
    }

    private void BindGridPiani()
    {
      this.HiddenPianiStanze.Value = "";
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Buildings().GetPianiBuilding(this.itemId).Copy();
      this.DataGridPiani.DataSource = (object) dataSet.Tables[0];
      this.DataGridPiani.DataBind();
      this.LabelPiano.Text = dataSet.Tables[0].Rows.Count.ToString();
      this.DataGridPiani.ShowFooter = false;
    }

    protected DataTable GetAllPiani()
    {
      this.HiddenPianiStanze.Value = "";
      return new TheSite.Classi.ClassiAnagrafiche.Buildings().GetAllPiani().Tables[0];
    }

    protected DataTable GetAllPianiNonAssociati()
    {
      this.HiddenPianiStanze.Value = "";
      return new TheSite.Classi.ClassiAnagrafiche.Buildings().GetAllPianiNonAssociati(this.itemId).Tables[0];
    }

    private void BindGrid()
    {
      this.HiddenPianiStanze.Value = "";
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Buildings().GetStanzeBuilding(this.itemId).Copy();
      this.DataGridEsegui.DataSource = (object) dataSet.Tables[0];
      this.DataGridEsegui.DataBind();
      this.lblRecord.Text = dataSet.Tables[0].Rows.Count.ToString();
      this.DataGridEsegui.ShowFooter = false;
    }

    private void DataGridEsegui_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      TheSite.Classi.ClassiAnagrafiche.Buildings buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
      int num = 0;
      switch (((ImageButton) e.CommandSource).CommandName)
      {
        case "Insert":
          S_ComboBox control1 = (S_ComboBox) e.Item.FindControl("ddlpianoNew");
          S_TextBox control2 = (S_TextBox) e.Item.FindControl("ddlstanzaNew");
          S_TextBox control3 = (S_TextBox) e.Item.FindControl("ddldescrizionenew");
          S_TextBox control4 = (S_TextBox) e.Item.FindControl("TxtMqNew");
          S_TextBox control5 = (S_TextBox) e.Item.FindControl("TxtMqNewDec");
          S_ComboBox control6 = (S_ComboBox) e.Item.FindControl("CmbCatNew");
          TextBox control7 = (TextBox) e.Item.FindControl("IdRepartoNew");
          TextBox control8 = (TextBox) e.Item.FindControl("IdUsoNew");
          string str = ((TextBox) control4).Text + "," + ((TextBox) control5).Text;
          ((WebControl) control4).Attributes.Add("onKeyPress", "SoloNumeri();");
          ((WebControl) control5).Attributes.Add("onKeyPress", "SoloNumeri();");
          if (((TextBox) control2).Text != string.Empty)
            num = this._RM.AddStanze(this.ControlsStanze(int.Parse(((ListControl) control1).SelectedValue), ((TextBox) control2).Text, ((TextBox) control3).Text, Convert.ToDouble(str), int.Parse(((ListControl) control6).SelectedValue), int.Parse(control7.Text), int.Parse(control8.Text)));
          else
            this.PanelMess.ShowError("Inserire una stanza");
          try
          {
            if (num > 0)
            {
              this.DataGridEsegui.EditItemIndex = -1;
              this.BindGrid();
              this.DataGridEsegui.Columns[1].Visible = true;
              this.DataGridEsegui.Columns[2].Visible = false;
              this.DataGridEsegui.Columns[3].Visible = false;
              break;
            }
            this.DataGridEsegui.Columns[1].Visible = false;
            this.DataGridEsegui.Columns[2].Visible = false;
            this.DataGridEsegui.Columns[3].Visible = true;
            break;
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
            this.PanelMess.ShowError("Errore: Inserimento della stanza non riuscita", true);
            break;
          }
        case "Delete":
          S_ComboBox control9 = (S_ComboBox) e.Item.FindControl("ddlpianoNew");
          S_TextBox control10 = (S_TextBox) e.Item.FindControl("ddlstanzaNew");
          S_TextBox control11 = (S_TextBox) e.Item.FindControl("ddldescrizionenew");
          int itemID = int.Parse(this.DataGridEsegui.DataKeys[e.Item.ItemIndex].ToString());
          try
          {
            if (this._RM.DeleteStanze(this.ControlsStanze(0, DBNull.Value.ToString(), DBNull.Value.ToString(), 0.0, 0, 0, 0), itemID) > 0)
            {
              this.DataGridEsegui.EditItemIndex = -1;
              this.BindGrid();
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
            this.PanelMess.ShowError("Errore: Cancellazione della stanza non riuscita " + ex.ToString(), true);
          }
          this.DataGridEsegui.Columns[1].Visible = true;
          this.DataGridEsegui.Columns[2].Visible = false;
          this.DataGridEsegui.Columns[3].Visible = false;
          break;
      }
    }

    private void DataGridPiani_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      TheSite.Classi.ClassiAnagrafiche.Buildings buildings1 = new TheSite.Classi.ClassiAnagrafiche.Buildings();
      int num = 0;
      TheSite.Classi.ClassiAnagrafiche.Buildings buildings2 = new TheSite.Classi.ClassiAnagrafiche.Buildings();
      switch (((ImageButton) e.CommandSource).CommandName)
      {
        case "Insert":
          S_ComboBox control1 = (S_ComboBox) e.Item.FindControl("cmbPianiAdd");
          S_TextBox control2 = (S_TextBox) e.Item.FindControl("pianoMqNettiAdd");
          S_TextBox control3 = (S_TextBox) e.Item.FindControl("pianoMqLordiAdd");
          S_TextBox control4 = (S_TextBox) e.Item.FindControl("pianoMqMuraAdd");
          if (((TextBox) control3).Text == "")
            ((TextBox) control3).Text = "0";
          ((WebControl) control3).Attributes.Add("onKeyPress", "SoloNumeriVirgola();");
          ((TextBox) control4).Text = Convert.ToString(Convert.ToDecimal(((TextBox) control3).Text) - Convert.ToDecimal(((TextBox) control2).Text));
          string selectedValue = ((ListControl) control1).SelectedValue;
          if (((ListControl) control1).SelectedValue != string.Empty)
            num = buildings2.ExecutePianiBuilding("insert", Convert.ToInt64(this.itemId), Convert.ToInt64(selectedValue), Convert.ToDecimal(((TextBox) control3).Text), Convert.ToDecimal(((TextBox) control2).Text), Convert.ToDecimal(((TextBox) control4).Text));
          else
            this.PanelMess.ShowError("Inserire un Piano");
          try
          {
            if (num > 0)
            {
              this.DataGridPiani.EditItemIndex = -1;
              this.BindGridPiani();
              this.DataGridPiani.Columns[1].Visible = true;
              this.DataGridPiani.Columns[2].Visible = false;
              this.DataGridPiani.Columns[3].Visible = false;
              break;
            }
            this.DataGridPiani.Columns[1].Visible = false;
            this.DataGridPiani.Columns[2].Visible = false;
            this.DataGridPiani.Columns[3].Visible = true;
            break;
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
            this.PanelMess.ShowError("Errore: Inserimento del piano non riuscita", true);
            break;
          }
          finally
          {
            ((WebControl) this.btnsSalva).Enabled = true;
          }
        case "Delete":
          string text = e.Item.Cells[0].Text;
          try
          {
            if (buildings1.DeletePianiBuilding(Convert.ToInt64(this.itemId), Convert.ToInt64(text)) > 0)
            {
              this.DataGridPiani.EditItemIndex = -1;
              this.BindGridPiani();
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
            this.PanelMess.ShowError("Errore: Cancellazione del piano non riuscita", true);
          }
          this.DataGridPiani.Columns[1].Visible = true;
          this.DataGridPiani.Columns[2].Visible = false;
          this.DataGridPiani.Columns[3].Visible = false;
          break;
      }
    }

    private void DataGridEsegui_CancelCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.EditItemIndex = -1;
      this.BindGrid();
      this.DataGridEsegui.Columns[1].Visible = true;
      this.DataGridEsegui.Columns[2].Visible = false;
      this.DataGridEsegui.Columns[3].Visible = false;
    }

    private void DataGridPiani_CancelCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridPiani.EditItemIndex = -1;
      this.BindGridPiani();
      this.DataGridPiani.Columns[1].Visible = true;
      this.DataGridPiani.Columns[2].Visible = false;
      this.DataGridPiani.Columns[3].Visible = false;
    }

    private void DataGridEsegui_EditCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.EditItemIndex = e.Item.ItemIndex;
      this.BindGrid();
      this.DataGridEsegui.Columns[1].Visible = false;
      this.DataGridEsegui.Columns[2].Visible = true;
      this.DataGridEsegui.Columns[3].Visible = false;
    }

    private void DataGridPiani_EditCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridPiani.EditItemIndex = e.Item.ItemIndex;
      this.BindGridPiani();
      this.DataGridPiani.Columns[1].Visible = false;
      this.DataGridPiani.Columns[2].Visible = true;
      this.DataGridPiani.Columns[3].Visible = false;
    }

    private void DataGridEsegui_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Footer)
      {
        TextBox control1 = (TextBox) e.Item.FindControl("TxtRepNew");
        TextBox control2 = (TextBox) e.Item.FindControl("IdRepartoNew");
        this.descRep = control1.ClientID;
        this.id = control2.ClientID;
        TextBox control3 = (TextBox) e.Item.FindControl("TxtUsoNew");
        TextBox control4 = (TextBox) e.Item.FindControl("IdUsoNew");
        this.descUso = control3.ClientID;
        this.Usoid = control4.ClientID;
        ((WebControl) e.Item.FindControl("Imagebutton1")).Attributes.Add("onclick", "return ControllaDati('" + e.Item.FindControl("CmbCatNew").ClientID + "','" + control1.ClientID + "','" + control3.ClientID + "');");
      }
      if (e.Item.ItemType == ListItemType.EditItem)
      {
        TextBox control1 = (TextBox) e.Item.FindControl("TxtRep");
        TextBox control2 = (TextBox) e.Item.FindControl("IdReparto");
        this.descRep1 = control1.ClientID;
        this.id1 = control2.ClientID;
        TextBox control3 = (TextBox) e.Item.FindControl("TxtUso");
        TextBox control4 = (TextBox) e.Item.FindControl("IdUso");
        this.descUso1 = control3.ClientID;
        this.Usoid1 = control4.ClientID;
        ((WebControl) e.Item.FindControl("imbUpdate")).Attributes.Add("onclick", "return ControllaDati('" + e.Item.FindControl("CmbCat").ClientID + "','" + control1.ClientID + "','" + control3.ClientID + "');");
      }
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.EditItem)
        return;
      DataRowView dataItem = (DataRowView) e.Item.DataItem;
      string str = dataItem["Piani"].ToString();
      if (this.HiddenPianiStanze.Value == "")
      {
        this.HiddenPianiStanze.Value = str;
      }
      else
      {
        HtmlInputHidden hiddenPianiStanze = this.HiddenPianiStanze;
        hiddenPianiStanze.Value = hiddenPianiStanze.Value + "," + str;
      }
      int num = new TheSite.Classi.ClassiAnagrafiche.Buildings().StanzaApparecchiatura(int.Parse(dataItem["id"].ToString()), this.itemId);
      ImageButton control = (ImageButton) e.Item.Controls[1].Controls[3];
      control.CausesValidation = false;
      if (num == 0)
      {
        control.Attributes.Add("onclick", "return confirm(\"Eliminare la Stanza: " + dataItem["descrizione"].ToString() + " nel Piano: " + dataItem["DescrizionePiano"].ToString() + "?\")");
      }
      else
      {
        control.Attributes.Add("onclick", "alert(\"La Stanza: " + dataItem["descrizione"].ToString() + " nel Piano: " + dataItem["DescrizionePiano"].ToString() + " non può essere eliminata perchè associata ad una apparecchiatura.\");return false;");
        if (!(e.Item.Controls[4].Controls[1] is S_ComboBox))
          return;
        ((WebControl) e.Item.Controls[4].Controls[1]).Enabled = false;
      }
    }

    private void DataGridPiani_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      ((WebControl) this.btnsSalva).Enabled = true;
      if ((e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) && e.Item.Controls[7].Controls[1] is Label)
      {
        string text = ((Label) e.Item.Controls[7].Controls[1]).Text;
        if (Convert.ToDecimal(((Label) e.Item.Controls[7].Controls[1]).Text) < 0M)
          ((WebControl) e.Item.Controls[7].Controls[1]).ForeColor = Color.Red;
      }
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
      {
        if (e.Item.Controls[4].Controls[1] is S_ComboBox)
          ((WebControl) e.Item.Controls[4].Controls[1]).Enabled = false;
        if (e.Item.Controls[6].Controls[1] is S_TextBox)
          ((WebControl) e.Item.Controls[6].Controls[1]).Enabled = false;
        if (e.Item.Controls[7].Controls[1] is S_TextBox)
          ((WebControl) e.Item.Controls[7].Controls[1]).Enabled = false;
        DataRowView dataItem = (DataRowView) e.Item.DataItem;
        string str = dataItem["DESCRIZIONE"].ToString();
        if (this.HiddenPianiStanze.Value == "")
        {
          this.HiddenPianiStanze.Value = str;
        }
        else
        {
          HtmlInputHidden hiddenPianiStanze = this.HiddenPianiStanze;
          hiddenPianiStanze.Value = hiddenPianiStanze.Value + "," + str;
        }
        int num = new TheSite.Classi.ClassiAnagrafiche.Buildings().PianiStanze(int.Parse(dataItem["ID"].ToString()), this.itemId);
        ImageButton control = (ImageButton) e.Item.Controls[1].Controls[3];
        control.CausesValidation = false;
        if (num == 0)
        {
          control.Attributes.Add("onclick", "return confirm(\"Eliminare il Piano: " + dataItem["DESCRIZIONE"].ToString() + "?\")");
        }
        else
        {
          control.Attributes.Add("onclick", "alert(\"Il piano: " + dataItem["DESCRIZIONE"].ToString() + " non può essere eliminato perchè associato a uno o più stanze.\");return false;");
          if (e.Item.Controls[4].Controls[1] is S_ComboBox)
            ((WebControl) e.Item.Controls[4].Controls[1]).Enabled = false;
        }
      }
      if (e.Item.ItemType != ListItemType.Footer && e.Item.ItemType != ListItemType.EditItem)
        return;
      if (e.Item.Controls[6].Controls[1] is S_TextBox)
      {
        ((WebControl) e.Item.Controls[6].Controls[1]).Enabled = false;
        if (((TextBox) e.Item.Controls[6].Controls[1]).Text == "")
          ((TextBox) e.Item.Controls[6].Controls[1]).Text = "0";
      }
      if (!(e.Item.Controls[7].Controls[1] is S_TextBox))
        return;
      ((WebControl) e.Item.Controls[7].Controls[1]).Enabled = false;
      if (!(((TextBox) e.Item.Controls[7].Controls[1]).Text == ""))
        return;
      ((TextBox) e.Item.Controls[7].Controls[1]).Text = "0";
    }

    private void DataGridEsegui_UpdateCommand_1(object source, DataGridCommandEventArgs e)
    {
      int itemID = int.Parse(this.DataGridEsegui.DataKeys[e.Item.ItemIndex].ToString());
      S_TextBox control1 = (S_TextBox) e.Item.FindControl("TxtMq");
      S_TextBox control2 = (S_TextBox) e.Item.FindControl("TxtMqDec");
      S_ComboBox control3 = (S_ComboBox) e.Item.FindControl("CmbCat");
      TextBox control4 = (TextBox) e.Item.FindControl("IdReparto");
      TextBox control5 = (TextBox) e.Item.FindControl("IdUso");
      S_ComboBox control6 = (S_ComboBox) e.Item.FindControl("ddlpiano");
      S_TextBox control7 = (S_TextBox) e.Item.FindControl("ddlstanza");
      S_TextBox control8 = (S_TextBox) e.Item.FindControl("ddldescrizione");
      string str = ((TextBox) control1).Text + "," + ((TextBox) control2).Text;
      ((WebControl) control1).Attributes.Add("onKeyPress", "SoloNumeri();");
      ((WebControl) control2).Attributes.Add("onKeyPress", "SoloNumeri();");
      try
      {
        if (this._RM.UpdateStanze(this.ControlsStanze(int.Parse(((ListControl) control6).SelectedValue), ((TextBox) control7).Text, ((TextBox) control8).Text, Convert.ToDouble(str), int.Parse(((ListControl) control3).SelectedValue), int.Parse(control4.Text), int.Parse(control5.Text)), itemID) > 0)
        {
          this.DataGridEsegui.EditItemIndex = -1;
          this.BindGrid();
          this.DataGridEsegui.Columns[1].Visible = true;
          this.DataGridEsegui.Columns[2].Visible = false;
          this.DataGridEsegui.Columns[3].Visible = false;
        }
        else
        {
          this.DataGridEsegui.Columns[1].Visible = false;
          this.DataGridEsegui.Columns[2].Visible = true;
          this.DataGridEsegui.Columns[3].Visible = false;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private void DataGridPiani_UpdateCommand_1(object source, DataGridCommandEventArgs e)
    {
      int.Parse(this.DataGridPiani.DataKeys[e.Item.ItemIndex].ToString());
      TheSite.Classi.ClassiAnagrafiche.Buildings buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
      try
      {
        S_ComboBox control1 = (S_ComboBox) e.Item.FindControl("cmbPianiMod");
        S_TextBox control2 = (S_TextBox) e.Item.FindControl("pianoMqNettiMod");
        S_TextBox control3 = (S_TextBox) e.Item.FindControl("pianoMqLordiMod");
        S_TextBox control4 = (S_TextBox) e.Item.FindControl("pianoMqMuraMod");
        if (((TextBox) control3).Text == "")
          ((TextBox) control3).Text = "0";
        ((WebControl) control3).Attributes.Add("onKeyPress", "SoloNumeriVirgola();");
        ((TextBox) control4).Text = Convert.ToString(Convert.ToDecimal(((TextBox) control3).Text) - Convert.ToDecimal(((TextBox) control2).Text));
        string selectedValue = ((ListControl) control1).SelectedValue;
        if (buildings.ExecutePianiBuilding("update", Convert.ToInt64(this.itemId), Convert.ToInt64(selectedValue), Convert.ToDecimal(((TextBox) control3).Text), Convert.ToDecimal(((TextBox) control2).Text), Convert.ToDecimal(((TextBox) control4).Text)) > 0)
        {
          this.DataGridPiani.EditItemIndex = -1;
          this.BindGridPiani();
          this.DataGridPiani.Columns[1].Visible = true;
          this.DataGridPiani.Columns[2].Visible = false;
          this.DataGridPiani.Columns[3].Visible = false;
        }
        else
        {
          this.DataGridPiani.Columns[1].Visible = false;
          this.DataGridPiani.Columns[2].Visible = true;
          this.DataGridPiani.Columns[3].Visible = false;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        ((WebControl) this.btnsSalva).Enabled = true;
      }
    }

    private void nuovoPiano_Click(object sender, EventArgs e)
    {
      this.DataGridPiani.ShowFooter = true;
      this.DataGridPiani.Columns[1].Visible = false;
      this.DataGridPiani.Columns[2].Visible = false;
      this.DataGridPiani.Columns[3].Visible = true;
    }

    private void ButtonRefreshMq_Click(object sender, EventArgs e)
    {
      new TheSite.Classi.ClassiAnagrafiche.Buildings().UpdateFl(this.itemId);
      this.DataGridPiani.EditItemIndex = -1;
      this.BindGridPiani();
      this.DataGridPiani.Columns[1].Visible = true;
      this.DataGridPiani.Columns[2].Visible = false;
      this.DataGridPiani.Columns[3].Visible = false;
    }

    public DataTable BindRmCat()
    {
      DataTable table = this._RM.GetAllCategoria().Tables[0];
      DataRow row = table.NewRow();
      row["Id"] = (object) 0;
      row["DESCRIZIONE"] = (object) "-- Scegliere una Categoria--";
      table.Rows.InsertAt(row, 0);
      return table;
    }
  }
}
