// Decompiled with JetBrains decompiler
// Type: TheSite.SoddisfazioneCliente.Giudizio
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
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManOrdinaria;
using TheSite.WebControls;

namespace TheSite.SoddisfazioneCliente
{
  public class Giudizio : Page
  {
    protected GridTitle GridTitle1;
    protected CodiceApparecchiature CodiceApparecchiature1;
    protected UserStanze UserStanze1;
    protected PageTitle PageTitle1;
    protected RequiredFieldValidator rfvOraRichiesta;
    protected DataPanel PanelRicerca;
    public static int FunId = 0;
    public int controllo = 0;
    private EditGiudizio _fp;
    protected RicercaModulo RicercaModulo1;
    protected DataGrid DataGridRicerca;
    public static string HelpLink = string.Empty;
    protected TextBox txtBL_ID;
    protected Button btsCodice;
    protected S_TextBox txtsstanza;
    protected S_ComboBox cmbsPiano;
    protected Panel PanelServizio;
    protected S_Button btnsRicerca;
    protected S_Button btnReset;
    protected S_ComboBox cmbsServizio;
    protected S_ComboBox cmbsGiudizio;
    protected Panel PanelRichiedente;
    private clMyCollection _myColl = new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = new SiteModule("./SoddisfazioneCliente/Giudizio.aspx");
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../SoddisfazioneCliente/EditGiudizio.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId;
      ((Control) this.GridTitle1.hplsNuovo).Visible = siteModule.IsEditable;
      this.DataGridRicerca.Columns[1].Visible = true;
      this.DataGridRicerca.Columns[2].Visible = siteModule.IsEditable;
      Giudizio.FunId = siteModule.ModuleId;
      Giudizio.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      this.UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.UserStanze1.NameComboPiano = "cmbsPiano";
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindServizio);
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindPiano);
      this.CodiceApparecchiature1.NameComboServizio = "cmbsServizio";
      this.CodiceApparecchiature1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.CodiceApparecchiature1.NameComboPiano = "cmbsPiano";
      this.CodiceApparecchiature1.NameComboStanza = "cmbsStanza";
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      stringBuilder2.Append("if (typeof(seledificio) == 'function') { ");
      stringBuilder2.Append("if (seledificio() == false) { return false; }} ");
      stringBuilder2.Append("document.getElementById('" + ((Control) this.cmbsServizio).ClientID + "').disabled = true;");
      stringBuilder2.Append("document.getElementById('" + ((Control) this.cmbsPiano).ClientID + "').disabled = true;");
      if (this.Page.IsPostBack)
        return;
      if (this.Request.QueryString["FunId"] != null)
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      if (this.Context.Handler is EditGiudizio)
      {
        this._fp = (EditGiudizio) this.Context.Handler;
        if (this._fp != null)
        {
          this._myColl = this._fp._Contenitore;
          this._myColl.SetValues(this.Page.Controls);
          this.Ricerca();
        }
      }
      this.BindPiano("");
      this.BindServizio(string.Empty);
      this.BindGiudizio();
      this.CodiceApparecchiature1.Visible = false;
      ((TextBox) this.CodiceApparecchiature1.s_CodiceApparecchiatura).ReadOnly = true;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      ((Button) this.btnReset).Click += new EventHandler(this.btnReset_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
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
        ((ListControl) this.cmbsPiano).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", string.Empty));
      ((WebControl) this.cmbsPiano).Attributes.Add("OnChange", "");
    }

    private void Ricerca()
    {
      DataSet data = this.GetData();
      this.DataGridRicerca.DataSource = (object) data.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = data.Tables[0].Rows.Count.ToString();
    }

    private DataSet GetData()
    {
      TheSite.Classi.GiudizioCliente.Giudizio giudizio = new TheSite.Classi.GiudizioCliente.Giudizio();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) (this.RicercaModulo1.Idbl == "" ? 0 : int.Parse(this.RicercaModulo1.Idbl)));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_id_piani");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(2);
      ((ParameterObject) sObject2).set_Value((object) (((ListControl) this.cmbsPiano).SelectedValue.ToString() == "" ? 0 : int.Parse(((ListControl) this.cmbsPiano).SelectedValue.ToString())));
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_id_stanza");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(3);
      ((ParameterObject) sObject3).set_Size(25);
      if (this.UserStanze1.DescStanza == "")
        this.UserStanze1.IdStanza = "";
      ((ParameterObject) sObject3).set_Value((object) this.UserStanze1.IdStanza);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_id_servizio");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(4);
      ((ParameterObject) sObject4).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue.ToString() == "" ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue.ToString())));
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_id_soddisfazione");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(5);
      ((ParameterObject) sObject5).set_Value((object) (((ListControl) this.cmbsGiudizio).SelectedValue.ToString() == "" ? 0 : int.Parse(((ListControl) this.cmbsGiudizio).SelectedValue.ToString())));
      CollezioneControlli.Add(sObject5);
      return giudizio.GetData(CollezioneControlli).Copy();
    }

    private void btnsRicerca_Click(object sender, EventArgs e) => this.Ricerca();

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

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString());
    }

    public clMyCollection _Contenitore => this._myColl;

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[1].FindControl("imgVisualizza")).Attributes.Add("title", "Visualizza");
      ((WebControl) e.Item.Cells[1].FindControl("imgModifica")).Attributes.Add("title", "Modifica");
    }

    private void btnReset_Click(object sender, EventArgs e) => this.Response.Redirect("Giudizio.aspx?FunId=" + (object) Giudizio.FunId);
  }
}
