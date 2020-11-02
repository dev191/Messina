// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorrettiva.ApprovaRDL
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
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManCorrettiva;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorrettiva
{
  public class ApprovaRDL : Page
  {
    protected S_TextBox txtsRichiesta;
    protected S_TextBox txtsOperatore;
    protected CompareValidator CompareValidator1;
    protected S_ComboBox cmbsGruppo;
    protected S_TextBox txtsDescrizione;
    protected S_ComboBox cmbsUrgenza;
    protected S_ComboBox cmbsServizio;
    protected S_Button btnsRicerca;
    protected Button cmdReset;
    protected DataPanel PanelRicerca;
    protected S_ComboBox cmbsvalidazione;
    protected DataGrid DataGridRicerca;
    protected PageTitle PageTitle1;
    protected GridTitle GridTitle1;
    protected RicercaModulo RicercaModulo1;
    protected CalendarPicker CalendarPicker1;
    protected CalendarPicker CalendarPicker2;
    protected TheSite.WebControls.Richiedenti Richiedenti1;
    public string HelpLink = string.Empty;
    public int FunId = 0;
    private clMyCollection _myColl = new clMyCollection();
    private EditApprovaEmetti _fp = (EditApprovaEmetti) null;
    public SiteModule _SiteModule;

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      ((WebControl) this.txtsRichiesta).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtsRichiesta).Attributes.Add("onpaste", "return nonpaste();");
      this._SiteModule = new SiteModule("./ManutenzioneCorrettiva/ApprovaRdl.aspx");
      this.DataGridRicerca.Columns[1].Visible = this._SiteModule.IsEditable;
      this.FunId = this._SiteModule.ModuleId;
      this.HelpLink = this._SiteModule.HelpLink;
      this.PageTitle1.Title = this._SiteModule.ModuleTitle;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.RicercaModulo1.DelegatePresidio1 += new DelegatePresidio(this.BindUrgenza);
      this.RicercaModulo1.DelegateIDBLEdificio1 = new DelegateIDBLEdificio(this.LoadServizi);
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["FunId"] != null)
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      this.CompareValidator1.ControlToValidate = this.CalendarPicker2.ID + ":" + ((Control) this.CalendarPicker2.Datazione).ID;
      this.CompareValidator1.ControlToCompare = this.CalendarPicker1.ID + ":" + ((Control) this.CalendarPicker1.Datazione).ID;
      this.BindControls();
      if (!(this.Context.Handler is EditApprovaEmetti))
        return;
      this._fp = (EditApprovaEmetti) this.Context.Handler;
      if (this._fp == null)
        return;
      this._myColl = this._fp._Contenitore;
      this._myColl.SetValues(this.Page.Controls);
      this.Ricerca(true);
    }

    private void LoadServizi(string CodEdificio)
    {
      int idprog = 0;
      if (this.Request.QueryString["VarApp"] != null)
        idprog = Convert.ToInt32(this.Request.QueryString["VarApp"].ToString());
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      Servizi servizi = new Servizi(this.Context.User.Identity.Name);
      DataSet dataSet = !(CodEdificio != "") ? servizi.GetServiziPerProg(idprog, 0) : servizi.GetServiziPerProg(idprog, int.Parse(CodEdificio));
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", string.Empty));
    }

    private void BindUrgenza(string Codice)
    {
      string progetto = "";
      if (this.Request.QueryString["VarApp"] != null)
        progetto = this.Request.QueryString["VarApp"];
      if (Codice != "")
      {
        ((BaseDataBoundControl) this.cmbsUrgenza).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(new Urgenza().GetPriorita(Convert.ToInt32(Codice), progetto).Tables[0], "DESCRIPTION", "ID", "Selezionare una Priorità", "0");
        ((ListControl) this.cmbsUrgenza).DataTextField = "DESCRIPTION";
        ((ListControl) this.cmbsUrgenza).DataValueField = "ID";
        ((Control) this.cmbsUrgenza).DataBind();
      }
      else
      {
        ((BaseDataBoundControl) this.cmbsUrgenza).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(new Urgenza().GetPriorita(0, progetto).Tables[0], "DESCRIPTION", "ID", "Selezionare una Priorità", "0");
        ((ListControl) this.cmbsUrgenza).DataTextField = "DESCRIPTION";
        ((ListControl) this.cmbsUrgenza).DataValueField = "ID";
        ((Control) this.cmbsUrgenza).DataBind();
      }
    }

    private void BindControls()
    {
      this.BindUrgenza("");
      string id_prog = "";
      if (this.Request.QueryString["VarApp"] != null)
        id_prog = this.Request.QueryString["VarApp"];
      ((BaseDataBoundControl) this.cmbsGruppo).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(new Richiedenti_tipo().GetAllAddProg(id_prog).Copy().Tables[0], "descrizione", "id", "Selezionare un Gruppo", "0");
      ((ListControl) this.cmbsGruppo).DataTextField = "descrizione";
      ((ListControl) this.cmbsGruppo).DataValueField = "id";
      ((Control) this.cmbsGruppo).DataBind();
      this.LoadServizi("");
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.cmdReset.Click += new EventHandler(this.cmdReset_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.Ricerca(true);
    }

    private void Ricerca(bool reset)
    {
      ClManCorrettiva clManCorrettiva = new ClManCorrettiva(this.Context.User.Identity.Name);
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Wr_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) (((TextBox) this.txtsRichiesta).Text == "" ? 0 : int.Parse(((TextBox) this.txtsRichiesta).Text)));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_DataDa");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Value(((TextBox) this.CalendarPicker1.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_DataA");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Value(((TextBox) this.CalendarPicker2.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_Richiedente");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Value((object) this.Richiedenti1.NomeCompleto);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_Gruppo");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) (((ListControl) this.cmbsGruppo).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsGruppo).SelectedValue)));
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_Descrizione");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject6).set_Value((object) ((TextBox) this.txtsDescrizione).Text);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_Urgenza");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Value((object) (((ListControl) this.cmbsUrgenza).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsUrgenza).SelectedValue)));
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_Servizio");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(7);
      ((ParameterObject) sObject8).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_Operatore");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(8);
      ((ParameterObject) sObject9).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject9).set_Value((object) ((TextBox) this.txtsOperatore).Text);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Size(50);
      ((ParameterObject) sObject10).set_Index(9);
      ((ParameterObject) sObject10).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_campus");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(10);
      ((ParameterObject) sObject11).set_Size(50);
      ((ParameterObject) sObject11).set_Value((object) ((TextBox) this.RicercaModulo1.TxtRicerca).Text);
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_validazione");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(11);
      ((ParameterObject) sObject12).set_Value((object) int.Parse(((ListControl) this.cmbsvalidazione).SelectedValue));
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("pageindex");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject13).set_Value((object) (this.DataGridRicerca.CurrentPageIndex + 1));
      CollezioneControlli.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("pagesize");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject14).set_Value((object) this.DataGridRicerca.PageSize);
      CollezioneControlli.Add(sObject14);
      this.DataGridRicerca.DataSource = (object) clManCorrettiva.GetData(CollezioneControlli).Tables[0];
      this.DataGridRicerca.Visible = true;
      if (reset)
      {
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        int dataCount = clManCorrettiva.GetDataCount(CollezioneControlli);
        this.GridTitle1.NumeroRecords = dataCount.ToString();
        if (dataCount % this.DataGridRicerca.PageSize == 0)
        {
          int num1 = dataCount / this.DataGridRicerca.PageSize;
        }
        else
        {
          int num2 = dataCount / this.DataGridRicerca.PageSize;
        }
      }
      else
        double.Parse(this.GridTitle1.NumeroRecords);
      this.GridTitle1.Visible = true;
      this.DataGridRicerca.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.DataGridRicerca.DataBind();
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca(false);
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[2].FindControl("lnkDett")).Attributes.Add("title", "Approva Richiesta di Lavoro");
    }

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      string str = "";
      if (this.Request["VarApp"] != null)
        str = "&VarApp=" + this.Request["VarApp"];
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString() + str);
    }

    private void cmdReset_Click(object sender, EventArgs e)
    {
      string str = "";
      if (this.Request["VarApp"] != null)
        str = "&VarApp=" + this.Request["VarApp"];
      this.Response.Redirect("ApprovaRDL.aspx?Fun=" + this.ViewState["FunId"] + str);
    }
  }
}
