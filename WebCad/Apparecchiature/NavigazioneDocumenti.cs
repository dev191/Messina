// Decompiled with JetBrains decompiler
// Type: WebCad.Apparecchiature.NavigazioneDocumenti
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebCad.Classi;
using WebCad.Classi.AnagrafeImpianti;
using WebCad.Classi.ClassiAnagrafiche;
using WebCad.WebControls;

namespace WebCad.Apparecchiature
{
  public class NavigazioneDocumenti : Page
  {
    protected S_Button S_btRicerca;
    protected S_Button S_btReset;
    protected DataPanel DataPanel1;
    protected S_ComboBox S_CmbTipologia;
    protected S_ComboBox S_CbCategoria;
    protected S_TextBox S_txtnomefile;
    protected S_TextBox S_txtdescrizione;
    protected DataGrid DataGrid1;
    protected RicercaModulo RicercaModulo1;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    protected S_ComboBox cmbsPiano;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      this.RicercaModulo1.DelegateIDBLEdificio1 += new DelegateIDBLEdificio(this.BindPiano);
      if (!this.IsPostBack)
      {
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
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("this.value = 'Attendere ...';");
      stringBuilder.Append("this.disabled = true;");
      stringBuilder.Append("document.getElementById('" + ((Control) this.S_btRicerca).ClientID + "').disabled = true;");
      stringBuilder.Append(this.Page.GetPostBackEventReference((Control) this.S_btRicerca));
      stringBuilder.Append(";");
      ((WebControl) this.S_btRicerca).Attributes.Add("onclick", stringBuilder.ToString());
      if (this.Request.QueryString["bl_id"] == null)
        return;
      this.BindPianoStr(this.Request.QueryString["bl_id"]);
      ((ListControl) this.cmbsPiano).SelectedValue = this.Request.QueryString["fl_id"];
      ((TextBox) this.RicercaModulo1.TxtCodice).Text = this.Request.QueryString["bl_id"];
      this.DataPanel1.set_Collapsed(true);
      this.S_btRicerca_Click((object) this, new EventArgs());
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

    private void BindPianoStr(string CodEdificio)
    {
      ((ListControl) this.cmbsPiano).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      Buildings buildings = new Buildings();
      if (CodEdificio != string.Empty)
      {
        DataSet pianiBuilding = buildings.GetPianiBuilding(CodEdificio);
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
      ((ListControl) this.cmbsPiano).SelectedIndexChanged += new EventHandler(this.cmbsPiano_SelectedIndexChanged);
      ((Button) this.S_btRicerca).Click += new EventHandler(this.S_btRicerca_Click);
      ((Button) this.S_btReset).Click += new EventHandler(this.S_btReset_Click);
      this.DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
      this.DataGrid1.ItemDataBound += new DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void S_btReset_Click(object sender, EventArgs e) => this.Response.Redirect("NavigazioneDocumenti.aspx?FunId=" + this.ViewState["FunId"]);

    private void S_btRicerca_Click(object sender, EventArgs e)
    {
      this.DataGrid1.CurrentPageIndex = 0;
      this.Execute();
    }

    private void Execute()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(8);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_campus");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.RicercaModulo1.TxtRicerca).Text);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_piano_id");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(8);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) (((ListControl) this.cmbsPiano).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsPiano).SelectedValue)));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_nomefile");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Value((object) ((TextBox) this.S_txtnomefile).Text);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_desc_file");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) ((TextBox) this.S_txtdescrizione).Text);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_categoria");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Size(8);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Value((object) (((ListControl) this.S_CbCategoria).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.S_CbCategoria).SelectedValue)));
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_tipo");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(8);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Value((object) (((ListControl) this.S_CmbTipologia).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.S_CmbTipologia).SelectedValue)));
      CollezioneControlli.Add(sObject7);
      DataSet data = new AnagrafeServizi(this.Context.User.Identity.Name).GetData(CollezioneControlli);
      this.GridTitle1.Visible = true;
      this.DataGrid1.DataSource = (object) data;
      if (data.Tables[0].Rows.Count > 0)
      {
        int num = 0;
        if (data.Tables[0].Rows.Count % this.DataGrid1.PageSize > 0)
          ++num;
        if (this.DataGrid1.PageCount != (int) Convert.ToInt16(data.Tables[0].Rows.Count / this.DataGrid1.PageSize + num))
          this.DataGrid1.CurrentPageIndex = 0;
      }
      else
      {
        this.DataGrid1.CurrentPageIndex = 0;
        this.GridTitle1.DescriptionTitle = "Nessun dato trovato.";
        this.setvisible(false);
      }
      this.DataGrid1.DataBind();
      this.setvisible(true);
      this.GridTitle1.DescriptionTitle = "";
      this.GridTitle1.NumeroRecords = data.Tables[0].Rows.Count.ToString();
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
      this.Execute();
    }

    private void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton1")).Attributes.Add("title", "Visualizza Documento");
    }

    private void cmbsPiano_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
  }
}
