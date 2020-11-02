// Decompiled with JetBrains decompiler
// Type: TheSite.AnagrafeImpianti.NavigazioneDocumenti
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.WebControls;

namespace TheSite.AnagrafeImpianti
{
  public class NavigazioneDocumenti : Page
  {
    protected DataPanel DataPanel1;
    protected DataGrid DataGrid1;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    protected S_ComboBox cmbsPiano;
    protected S_TextBox S_txtnomefile;
    protected S_TextBox S_txtdescrizione;
    protected S_ComboBox S_CbCategoria;
    protected S_ComboBox S_CmbTipologia;
    protected S_Button S_btRicerca;
    protected S_Button S_btReset;
    protected RicercaModulo RicercaModulo1;
    protected RequiredFieldValidator rfvEdificio;
    protected ValidationSummary vlsEdit;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      NavigazioneDocumenti.FunId = siteModule.ModuleId;
      NavigazioneDocumenti.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      this.RicercaModulo1.DelegateIDBLEdificio1 += new DelegateIDBLEdificio(this.BindPiano);
      if (!this.IsPostBack)
      {
        this.rfvEdificio.ControlToValidate = this.RicercaModulo1.ID + ":" + ((Control) this.RicercaModulo1.TxtCodice).ID;
        if (this.Request.QueryString["FunId"] != null)
          this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
        this.BindPiano(string.Empty);
        this.LoadTipo();
        this.LoadCategoria();
        this.GridTitle1.Visible = false;
      }
      this.RicercaModulo1.TxtCodice.set_DBParameterName("p_bl_id");
      this.RicercaModulo1.TxtCodice.set_DBIndex(0);
      this.RicercaModulo1.TxtCodice.set_DBDataType((CustomDBType) 2);
      this.RicercaModulo1.TxtCodice.set_DBDirection(ParameterDirection.Input);
      this.RicercaModulo1.TxtCodice.set_DBSize(8);
      this.RicercaModulo1.TxtCodice.set_DBDefaultValue((object) "");
      this.RicercaModulo1.TxtRicerca.set_DBParameterName("p_campus");
      this.RicercaModulo1.TxtRicerca.set_DBIndex(1);
      this.RicercaModulo1.TxtRicerca.set_DBDirection(ParameterDirection.Input);
      this.RicercaModulo1.TxtRicerca.set_DBDataType((CustomDBType) 2);
      this.RicercaModulo1.TxtRicerca.set_DBSize(128);
      this.RicercaModulo1.TxtRicerca.set_DBDefaultValue((object) "");
    }

    private void LoadTipo()
    {
      DataSet tipologie = new AnagrafeServizi(this.Context.User.Identity.Name).GetTipologie();
      if (tipologie.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.S_CmbTipologia).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(tipologie.Tables[0], "valTipo", "documento_id", "- Selezionare una Tipologia -", "");
        ((ListControl) this.S_CmbTipologia).DataTextField = "valTipo";
        ((ListControl) this.S_CmbTipologia).DataValueField = "documento_id";
        ((Control) this.S_CmbTipologia).DataBind();
      }
      else
        ((ListControl) this.S_CmbTipologia).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Tipologia -", string.Empty));
    }

    private void BindPiano(string CodEdificio)
    {
      ((ListControl) this.cmbsPiano).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      Buildings buildings = new Buildings();
      if (CodEdificio != string.Empty)
      {
        DataSet pianiBuilding = buildings.GetPianiBuilding(Convert.ToInt32(CodEdificio));
        if (pianiBuilding.Tables[0].Rows.Count > 0)
        {
          ((BaseDataBoundControl) this.cmbsPiano).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(pianiBuilding.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "0");
          ((ListControl) this.cmbsPiano).DataTextField = "DESCRIZIONE";
          ((ListControl) this.cmbsPiano).DataValueField = "ID";
          ((Control) this.cmbsPiano).DataBind();
        }
        else
          ((ListControl) this.cmbsPiano).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", string.Empty));
      }
      else
        ((ListControl) this.cmbsPiano).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", string.Empty));
    }

    private void LoadCategoria()
    {
      DataSet categorie = new AnagrafeServizi(this.Context.User.Identity.Name).GetCategorie();
      if (categorie.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.S_CbCategoria).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(categorie.Tables[0], "valTipo", "id_categoria", "- Selezionare una Categoria -", "");
        ((ListControl) this.S_CbCategoria).DataTextField = "valTipo";
        ((ListControl) this.S_CbCategoria).DataValueField = "id_categoria";
        ((Control) this.S_CbCategoria).DataBind();
      }
      else
        ((ListControl) this.S_CbCategoria).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Categoria -", string.Empty));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.S_btRicerca).Click += new EventHandler(this.S_btRicerca_Click);
      this.DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
      this.DataGrid1.ItemDataBound += new DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void S_btReset_Click(object sender, EventArgs e) => this.Response.Redirect("NavigazioneDocumenti.aspx?FunId=" + this.ViewState["FunId"]);

    private void S_btRicerca_Click(object sender, EventArgs e)
    {
      this.DataGrid1.CurrentPageIndex = 0;
      this.Execute(true);
    }

    private void Execute(bool reset)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_ControlsCollection CollezioneControlli1 = this.creaParam();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pageindex");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(16);
      ((ParameterObject) sObject1).set_Value((object) (this.DataGrid1.CurrentPageIndex + 1));
      CollezioneControlli1.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pagesize");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(17);
      ((ParameterObject) sObject2).set_Value((object) this.DataGrid1.PageSize);
      CollezioneControlli1.Add(sObject2);
      AnagrafeServizi anagrafeServizi = new AnagrafeServizi(this.Context.User.Identity.Name);
      DataSet data = anagrafeServizi.GetData(CollezioneControlli1);
      this.GridTitle1.Visible = true;
      this.DataGrid1.DataSource = (object) data;
      if (reset)
      {
        ((CollectionBase) CollezioneControlli1).Clear();
        S_ControlsCollection CollezioneControlli2 = this.creaParam();
        this.GridTitle1.NumeroRecords = anagrafeServizi.GetDataCount(CollezioneControlli2).ToString();
      }
      this.DataGrid1.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.DataGrid1.DataBind();
      this.setvisible(true);
      this.GridTitle1.DescriptionTitle = "Lista documenti";
    }

    public S_ControlsCollection creaParam()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(8);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_campus");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.RicercaModulo1.TxtRicerca).Text);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_piano_id");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(8);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) (((ListControl) this.cmbsPiano).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsPiano).SelectedValue)));
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_nomefile");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Value((object) ((TextBox) this.S_txtnomefile).Text);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_desc_file");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) ((TextBox) this.S_txtdescrizione).Text);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_categoria");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Size(8);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Value((object) (((ListControl) this.S_CbCategoria).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.S_CbCategoria).SelectedValue)));
      controlsCollection.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_tipo");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(8);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Value((object) (((ListControl) this.S_CmbTipologia).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.S_CmbTipologia).SelectedValue)));
      controlsCollection.Add(sObject7);
      return controlsCollection;
    }

    private void setvisible(bool visible)
    {
      this.GridTitle1.VisibleRecord = visible;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.DataGrid1.Visible = visible;
    }

    private void SetDefaultValueControl(Control Ctrls)
    {
      this.S_txtnomefile.set_DBDefaultValue((object) "");
      this.S_txtdescrizione.set_DBDefaultValue((object) "");
      this.S_CbCategoria.set_DBDefaultValue((object) 0);
      this.S_CmbTipologia.set_DBDefaultValue((object) 0);
    }

    public void imageButton_Click(object sender, CommandEventArgs e)
    {
      this.Context.Items.Add((object) "var_afm_dwgs_dwg_name", (object) (string) e.CommandArgument);
      this.Server.Transfer("VisualDWF.aspx");
    }

    private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.Execute(false);
    }

    private void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton1")).Attributes.Add("title", "Visualizza Documento");
    }
  }
}
