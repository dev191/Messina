// Decompiled with JetBrains decompiler
// Type: TheSite.GestioneSpazi.RicercaSpazi
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using Microsoft.Web.UI.WebControls;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.WebControls;

namespace TheSite.GestioneSpazi
{
  public class RicercaSpazi : Page
  {
    protected HtmlForm Form1;
    protected S_ListBox S_ListEdifici;
    protected S_Button S_btMostra;
    protected HtmlInputHidden edifici;
    protected HtmlInputHidden edificidescription;
    protected DataPanel DataPanel1;
    protected PageTitle PageTitle1;
    protected TreeView TreeCtrl;
    protected Panel Panel1;
    protected S_Label lblComuneDescrizione;
    protected S_Label lblComune;
    protected S_TextBox S_txtnomefile;
    protected S_TextBox S_txtdescrizione;
    protected S_ComboBox S_CbCategoria;
    protected S_ComboBox S_CmbTipologia;
    protected S_Button S_btRicerca;
    protected RicercaModulo RicercaModulo1;
    protected DataGrid DataGrid1;
    protected S_Button btReset;
    protected UserStanze UserStanze1;
    public static string HelpLink = string.Empty;
    protected S_Label lblFrazione;
    protected S_Label lblFrazioneDescrizione;
    protected S_ComboBox S_ComboBox1;
    protected S_ComboBox cmbsPiano;
    protected S_ComboBox cmbsCategoria;
    public string descRep = "";
    public string id = string.Empty;
    public string descUso1 = "";
    public string Usoid1 = string.Empty;
    public string sql_select = string.Empty;
    public string sql_where = string.Empty;
    public string sql_group = string.Empty;
    public string sql = string.Empty;
    public string sqlCount = string.Empty;
    protected S_TextBox s_txtReparto;
    protected S_TextBox s_txtDestinazione;
    protected S_ComboBox cmbsConfronto;
    protected S_TextBox s_txtMq;
    protected DataGrid DtgRicercaSpazi;
    protected GridTitle GridTitle1;
    public static int FunId = 0;
    protected HtmlInputCheckBox chkReparto;
    protected HtmlInputCheckBox chkDestinazione;
    protected HtmlInputCheckBox chkCategoria;
    protected HtmlInputCheckBox chkPiano;
    protected HtmlInputCheckBox chkEdificio;
    protected HtmlInputCheckBox chkStanze;
    protected HtmlInputCheckBox chk_attiva;
    private int startIndex = 0;
    private double totale = 0.0;

    private void Page_Load(object sender, EventArgs e)
    {
      StringBuilder stringBuilder = new StringBuilder();
      ((WebControl) this.S_ListEdifici).Attributes.Add("title", "Premere il tasto canc per eliminare un elemento dalla lista.");
      this.SetProperty();
      if (!this.IsPostBack)
      {
        if (this.Request.QueryString["FunId"] != null)
          this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
        this.Panel1.Visible = false;
        this.BindTuttiPiani();
        this.BindTutteCategorie();
        ((Control) this.GridTitle1.hplsNuovo).Visible = false;
        if (this.Request.QueryString["idcomune"] != null)
          this.IdComune = int.Parse(this.Request.QueryString["idcomune"]);
        if (this.Request.QueryString["idfrazione"] != null)
          this.IdFrazione = int.Parse(this.Request.QueryString["idfrazione"]);
        this.LoadComune();
      }
      this.RicercaModulo1.multisele = "y&id_comune=" + this.IdComune.ToString() + "&id_frazione=" + this.IdFrazione.ToString();
      this.RicercaModulo1.visualizzadettagli = false;
      this.RicercaModulo1.ClasseTab = "tblSearch100DettaglioInv";
      this.UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.UserStanze1.NameComboPiano = "cmbsPiano";
      this.descRep = ((Control) this.s_txtReparto).ClientID;
      this.descUso1 = ((Control) this.s_txtDestinazione).ClientID;
    }

    public int IdComune
    {
      get => this.ViewState[nameof (IdComune)] != null ? (int) this.ViewState[nameof (IdComune)] : 0;
      set => this.ViewState.Add(nameof (IdComune), (object) value);
    }

    public int IdFrazione
    {
      get => this.ViewState[nameof (IdFrazione)] != null ? (int) this.ViewState[nameof (IdFrazione)] : 0;
      set => this.ViewState.Add(nameof (IdFrazione), (object) value);
    }

    private void LoadComune()
    {
      if (this.IdComune == 0)
        return;
      DataSet comuneFrazione = new ServiziEdifici(this.Context.User.Identity.Name).GetComuneFrazione(this.IdComune, this.IdFrazione);
      if (comuneFrazione.Tables[0].Rows.Count > 0)
      {
        ((Control) this.lblComuneDescrizione).Visible = true;
        ((Control) this.lblComune).Visible = true;
        ((Label) this.lblComune).Text = comuneFrazione.Tables[0].Rows[0]["descrizionec"].ToString();
        if (comuneFrazione.Tables[0].Rows[0]["descrizionef"] == DBNull.Value || this.IdFrazione <= 0)
          return;
        ((Control) this.lblFrazioneDescrizione).Visible = true;
        ((Control) this.lblFrazione).Visible = true;
        ((Label) this.lblFrazione).Text = comuneFrazione.Tables[0].Rows[0]["descrizionef"].ToString();
      }
      else
      {
        ((Control) this.lblComuneDescrizione).Visible = false;
        ((Control) this.lblComune).Visible = false;
        ((Label) this.lblComune).Text = "";
        ((Control) this.lblFrazioneDescrizione).Visible = false;
        ((Control) this.lblFrazione).Visible = false;
        ((Label) this.lblFrazione).Text = "";
      }
    }

    private void SetProperty()
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      RicercaSpazi.FunId = siteModule.ModuleId;
      RicercaSpazi.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      ((WebControl) this.S_ListEdifici).Attributes.Add("onkeydown", "deleteitem(this,event);");
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("this.disabled = true;");
      stringBuilder.Append("document.getElementById('" + ((Control) this.S_btMostra).ClientID + "').disabled = true;");
      stringBuilder.Append(this.Page.GetPostBackEventReference((Control) this.S_btMostra));
      stringBuilder.Append(";");
      ((WebControl) this.S_btMostra).Attributes.Add("onclick", stringBuilder.ToString());
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsPiano).SelectedIndexChanged += new EventHandler(this.cmbsServizio_SelectedIndexChanged);
      ((Button) this.S_btMostra).Click += new EventHandler(this.S_btMostra_Click);
      ((Button) this.btReset).Click += new EventHandler(this.btReset_Click);
      this.DtgRicercaSpazi.PageIndexChanged += new DataGridPageChangedEventHandler(this.DtgRicercaSpazi_PageIndexChanged);
      this.DtgRicercaSpazi.ItemDataBound += new DataGridItemEventHandler(this.DtgRicercaSpazi_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void S_btMostra_Click(object sender, EventArgs e)
    {
      this.DtgRicercaSpazi.CurrentPageIndex = 0;
      this.LoadList();
      this.BindingEdifici(this.edifici.Value, true);
    }

    private void LoadList()
    {
      Console.WriteLine(this.edifici.Value);
      string[] strArray1 = this.edificidescription.Value.Split('$');
      string[] strArray2 = this.edifici.Value.Split(',');
      ((ListControl) this.S_ListEdifici).Items.Clear();
      int index = 0;
      if (!(strArray2[0].ToString() != ""))
        return;
      foreach (string str in strArray2)
      {
        ((ListControl) this.S_ListEdifici).Items.Add(new ListItem(strArray1[index], str));
        ++index;
      }
    }

    private void BindingEdifici(string BlId, bool reset)
    {
      if (BlId != "")
        BlId = "'" + BlId.Replace(",", "','") + "'";
      if (this.chkEdificio.Checked)
      {
        this.sql_select += " BL.BL_ID || ' - '  ||  BL.ADDRESS1 as EDIFICIO";
        this.sql_group += " BL.BL_ID || ' - '  ||  BL.ADDRESS1";
      }
      if (this.chkPiano.Checked)
      {
        if (this.sql_select != "")
          this.sql_select += ",";
        if (this.sql_group != "")
          this.sql_group += ",";
        this.sql_select += " PIANI.DESCRIZIONE as PIANO ";
        this.sql_group += " PIANI.DESCRIZIONE ";
      }
      if (this.chkStanze.Checked)
      {
        if (this.sql_select != "")
          this.sql_select += ",";
        if (this.sql_group != "")
          this.sql_group += ",";
        this.sql_select += "RM.RM_ID || '-'  || RM.DESCRIZIONE as STANZA ";
        this.sql_group += " RM.RM_ID,RM.DESCRIZIONE ";
      }
      if (this.chkCategoria.Checked)
      {
        if (this.sql_select != "")
          this.sql_select += ",";
        if (this.sql_group != "")
          this.sql_group += ",";
        this.sql_select += "RM_CAT.CODICE_CATEGORIA || '-'  || RM_CAT.DESCRIZIONE  as CATEGORIA ";
        this.sql_group += " RM_CAT.CODICE_CATEGORIA, RM_CAT.DESCRIZIONE ";
      }
      if (this.chkDestinazione.Checked)
      {
        if (this.sql_select != "")
          this.sql_select += ",";
        if (this.sql_group != "")
          this.sql_group += ",";
        this.sql_select += " RM_DEST_USO.DESCRIZIONE as DESTINAZIONE ";
        this.sql_group += " RM_DEST_USO.DESCRIZIONE ";
      }
      if (this.chkReparto.Checked)
      {
        if (this.sql_select != "")
          this.sql_select += ",";
        if (this.sql_group != "")
          this.sql_group += ",";
        this.sql_select += " RM_REPARTO.DESCRIZIONE as REPARTO ";
        this.sql_group += " RM_REPARTO.DESCRIZIONE ";
      }
      if (BlId != "")
      {
        if (this.sql_where != "")
          this.sql_where += " AND";
        RicercaSpazi ricercaSpazi = this;
        ricercaSpazi.sql_where = ricercaSpazi.sql_where + " UPPER(BL.BL_ID) in (" + BlId.ToUpper() + ") ";
      }
      if (((ListControl) this.cmbsPiano).SelectedValue != string.Empty)
      {
        if (this.sql_where != "")
          this.sql_where += " AND";
        RicercaSpazi ricercaSpazi = this;
        ricercaSpazi.sql_where = ricercaSpazi.sql_where + " ID_PIANI =" + ((ListControl) this.cmbsPiano).SelectedValue.ToString();
      }
      if (this.UserStanze1.DescStanza.ToString() != "")
      {
        if (this.sql_where != "")
          this.sql_where += " AND";
        RicercaSpazi ricercaSpazi = this;
        ricercaSpazi.sql_where = ricercaSpazi.sql_where + " UPPER(RM.RM_ID ||'-'|| RM.DESCRIZIONE) like '%" + this.UserStanze1.DescStanza.ToUpper() + "%'";
      }
      if (((ListControl) this.cmbsCategoria).SelectedValue != string.Empty)
      {
        if (this.sql_where != "")
          this.sql_where += " AND";
        RicercaSpazi ricercaSpazi = this;
        ricercaSpazi.sql_where = ricercaSpazi.sql_where + " RM_CAT.ID_RM_CAT=" + ((ListControl) this.cmbsCategoria).SelectedValue.ToString();
      }
      if (((TextBox) this.s_txtReparto).Text != string.Empty)
      {
        if (this.sql_where != "")
          this.sql_where += " AND";
        RicercaSpazi ricercaSpazi = this;
        ricercaSpazi.sql_where = ricercaSpazi.sql_where + " UPPER(RM_REPARTO.DESCRIZIONE) like '%" + ((TextBox) this.s_txtReparto).Text.ToUpper() + "%'";
      }
      if (((TextBox) this.s_txtDestinazione).Text != string.Empty)
      {
        if (this.sql_where != "")
          this.sql_where += " AND";
        RicercaSpazi ricercaSpazi = this;
        ricercaSpazi.sql_where = ricercaSpazi.sql_where + " UPPER(RM_DEST_USO.DESCRIZIONE) like '%" + ((TextBox) this.s_txtDestinazione).Text.ToUpper() + "%'";
      }
      if (((ListControl) this.cmbsConfronto).SelectedValue != string.Empty & ((TextBox) this.s_txtMq).Text != string.Empty)
      {
        if (this.sql_where != "")
          this.sql_where += " AND";
        RicercaSpazi ricercaSpazi = this;
        ricercaSpazi.sql_where = ricercaSpazi.sql_where + " RM.AREA " + ((ListControl) this.cmbsConfronto).SelectedValue + " " + ((TextBox) this.s_txtMq).Text.Replace(",", ".");
      }
      if (this.sql_where != "")
        this.sql_where = " WHERE " + this.sql_where;
      if (this.sql_select != "")
        this.sql_select += ", ";
      this.sql = "SELECT " + this.sql_select + " SUM(RM.AREA) as VALORE_INT FROM BL JOIN FL ON (FL.Id_Bl = BL.Id) JOIN RM USING (id_piani, id_bl) JOIN PIANI ON (id_piani = PIANI.id) left JOIN RM_REPARTO ON (RM.ID_RM_REPARTO = RM_REPARTO.ID_RM_REPARTO) left JOIN RM_DEST_USO ON (RM.ID_RM_DEST_USO = RM_DEST_USO.ID_RM_DEST_USO)  left JOIN RM_CAT ON (RM.ID_RM_CAT = RM_CAT.ID_RM_CAT) " + this.sql_where;
      if (this.sql_group != "")
      {
        RicercaSpazi ricercaSpazi = this;
        ricercaSpazi.sql = ricercaSpazi.sql + " GROUP BY " + this.sql_group;
      }
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_sql");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(4000);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) this.sql);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pageindex");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(16);
      ((ParameterObject) sObject2).set_Value((object) (this.DtgRicercaSpazi.CurrentPageIndex + 1));
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pagesize");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(17);
      ((ParameterObject) sObject3).set_Value((object) this.DtgRicercaSpazi.PageSize);
      CollezioneControlli.Add(sObject3);
      ServiziEdifici serviziEdifici = new ServiziEdifici(this.Context.User.Identity.Name);
      DataSet ricerca = serviziEdifici.GetRicerca(CollezioneControlli);
      if (reset)
      {
        ((CollectionBase) CollezioneControlli).Clear();
        S_Object sObject4 = new S_Object();
        ((ParameterObject) sObject4).set_ParameterName("p_sql");
        ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject4).set_Size(4000);
        ((ParameterObject) sObject4).set_Index(0);
        ((ParameterObject) sObject4).set_Value((object) this.sql);
        CollezioneControlli.Add(sObject4);
        this.GridTitle1.NumeroRecords = serviziEdifici.GetRicercaCount(CollezioneControlli).ToString();
      }
      this.DtgRicercaSpazi.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      if (ricerca.Tables[0].Rows.Count == 0)
        this.Panel1.Visible = false;
      this.Panel1.Visible = true;
      this.DtgRicercaSpazi.Visible = true;
      int num = 0;
      if (!this.chkEdificio.Checked)
      {
        this.DtgRicercaSpazi.Columns.RemoveAt(0);
        ++num;
      }
      if (!this.chkPiano.Checked)
      {
        this.DtgRicercaSpazi.Columns.RemoveAt(1 - num);
        ++num;
      }
      if (!this.chkStanze.Checked)
      {
        this.DtgRicercaSpazi.Columns.RemoveAt(2 - num);
        ++num;
      }
      if (!this.chkCategoria.Checked)
      {
        this.DtgRicercaSpazi.Columns.RemoveAt(3 - num);
        ++num;
      }
      if (!this.chkDestinazione.Checked)
      {
        this.DtgRicercaSpazi.Columns.RemoveAt(4 - num);
        ++num;
      }
      if (!this.chkReparto.Checked)
      {
        this.DtgRicercaSpazi.Columns.RemoveAt(5 - num);
        ++num;
      }
      if (!this.chkEdificio.Checked && !this.chkPiano.Checked && (!this.chkStanze.Checked && !this.chkCategoria.Checked) && (!this.chkDestinazione.Checked && !this.chkReparto.Checked))
      {
        this.DtgRicercaSpazi.Columns.RemoveAt(6 - num);
        BoundColumn boundColumn = new BoundColumn();
        boundColumn.DataField = "";
        boundColumn.HeaderText = "";
        this.DtgRicercaSpazi.Columns.Add((DataGridColumn) boundColumn);
      }
      this.CalcolaTotali(ricerca.Tables[0]);
      this.DtgRicercaSpazi.DataSource = (object) ricerca.Tables[0];
      this.DtgRicercaSpazi.DataBind();
      this.GridTitle1.DescriptionTitle = "";
    }

    private DataRowCollection DatiEdificio(int bl_id)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      return new ServiziEdifici(this.Context.User.Identity.Name).GetSingleData(bl_id).Tables[0].Rows;
    }

    private void cmbsServizio_SelectedIndexChanged(object sender, EventArgs e) => this.LoadList();

    private void btReset_Click(object sender, EventArgs e) => this.Response.Redirect("RicercaSpazi.aspx?FunId=" + this.ViewState["FunId"]);

    private void BindTuttiPiani()
    {
      ((ListControl) this.cmbsPiano).Items.Clear();
      DataSet allPiani = new Buildings().GetAllPiani();
      if (allPiani.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsPiano).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(allPiani.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "");
        ((ListControl) this.cmbsPiano).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsPiano).DataValueField = "ID";
        ((Control) this.cmbsPiano).DataBind();
      }
      else
        ((ListControl) this.cmbsPiano).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", string.Empty));
    }

    private void BindTutteCategorie()
    {
      ((ListControl) this.cmbsCategoria).Items.Clear();
      DataSet data = new Categorie().GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsCategoria).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "CATEGORIA", "ID", "- Selezionare la Categoria -", "");
        ((ListControl) this.cmbsCategoria).DataTextField = "CATEGORIA";
        ((ListControl) this.cmbsCategoria).DataValueField = "ID";
        ((Control) this.cmbsCategoria).DataBind();
      }
      else
        ((ListControl) this.cmbsCategoria).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Categoria -", string.Empty));
    }

    private void DtgRicercaSpazi_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item)
      {
        int itemType = (int) e.Item.ItemType;
      }
      if (e.Item.ItemType != ListItemType.Footer)
        return;
      int count = this.DtgRicercaSpazi.Columns.Count;
      if (count == 1)
      {
        e.Item.Cells[count - 1].Text = "<b>TOTALE GENERALE</b><b>&nbsp;&nbsp;&nbsp;" + this.totale.ToString("#,##0.00") + "</b>";
      }
      else
      {
        e.Item.Cells[0].Text = "<b>TOTALE GENERALE</b>";
        e.Item.Cells[count - 1].HorizontalAlign = HorizontalAlign.Right;
        e.Item.Cells[count - 1].Text = "<b>" + this.totale.ToString("#,##0.00") + "</b>";
      }
    }

    private void CalcolaTotali(DataTable dt)
    {
      foreach (DataRow row in (InternalDataCollectionBase) dt.Rows)
      {
        if (row["VALORE_INT"] != DBNull.Value)
          this.totale += double.Parse(row["VALORE_INT"].ToString());
      }
    }

    public void DtgRicercaSpazi_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DtgRicercaSpazi.CurrentPageIndex = e.NewPageIndex;
      this.startIndex = this.DtgRicercaSpazi.CurrentPageIndex * this.DtgRicercaSpazi.PageSize;
      this.LoadList();
      this.BindingEdifici(this.edifici.Value, false);
    }
  }
}
