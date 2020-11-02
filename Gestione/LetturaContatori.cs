// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.LetturaContatori
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
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class LetturaContatori : Page
  {
    protected S_ComboBox cmbsServizio;
    protected S_ComboBox cmbsApparecchiatura;
    protected S_Button S_btMostra;
    protected GridTitle GridTitle1;
    protected CodiceApparecchiature CodiceApparecchiature1;
    protected RicercaModulo RicercaModulo1;
    protected DataPanel PanelRicerca;
    protected PageTitle PageTitle1;
    protected HtmlInputHidden hiddenblid;
    protected CalendarPicker CalendarPicker1;
    protected CalendarPicker CalendarPicker2;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    protected TabStrip TabStrip1;
    protected S_ComboBox cmbsPiano;
    protected Button btnReset;
    private clMyCollection _myColl = new clMyCollection();
    private EditLetturaContatori _fp;
    protected DataGrid DataGridLettura;
    protected UserStanze UserStanze1;

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsServizio).SelectedIndexChanged += new EventHandler(this.cmbsServizio_SelectedIndexChanged);
      ((Button) this.S_btMostra).Click += new EventHandler(this.S_btMostra_Click);
      this.btnReset.Click += new EventHandler(this.btnReset_Click);
      this.DataGridLettura.ItemCreated += new DataGridItemEventHandler(this.DataGridLettura_ItemCreated);
      this.DataGridLettura.ItemCommand += new DataGridCommandEventHandler(this.DataGridLettura_ItemCommand);
      this.DataGridLettura.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridLettura_PageIndexChanged);
      this.DataGridLettura.ItemDataBound += new DataGridItemEventHandler(this.DataGridLettura_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Gestione/EditLetturaContatori.aspx?FunId=" + (object) siteModule.ModuleId;
      LetturaContatori.FunId = siteModule.ModuleId;
      LetturaContatori.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      if (((TextBox) this.RicercaModulo1.TxtCodice).Text != "")
      {
        this.RicercaModulo1.DelegateIDBLEdificio1 += new DelegateIDBLEdificio(this.BindPiano);
        this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindServizio);
      }
      this.CodiceApparecchiature1.NameComboApparecchiature = "cmbsApparecchiatura";
      this.CodiceApparecchiature1.NameComboServizio = "cmbsServizio";
      this.CodiceApparecchiature1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.CodiceApparecchiature1.s_RichiestaLettura = "si";
      this.UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.UserStanze1.NameComboPiano = "cmbsPiano";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("document.getElementById('" + ((Control) this.cmbsApparecchiatura).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsServizio).Attributes.Add("onchange", stringBuilder.ToString());
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["FunId"] != null)
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      this.BindApparecchiatura();
      this.BindPiano("");
      this.BindServizio("");
      if (!(this.Context.Handler is EditLetturaContatori))
        return;
      this._fp = (EditLetturaContatori) this.Context.Handler;
      if (this._fp == null)
        return;
      this.BindApparecchiatura();
      this.BindTuttiPiani();
      this.BindServizio("");
      this._myColl = this._fp._Contenitore;
      this._myColl.SetValues(this.Page.Controls);
      this.Execute();
    }

    public clMyCollection _Contenitore => this._myColl;

    private void BindServizio(string CodEdificio)
    {
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      TheSite.Classi.ClassiDettaglio.Servizi servizi = new TheSite.Classi.ClassiDettaglio.Servizi(this.Context.User.Identity.Name);
      if (CodEdificio != "")
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
          ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "");
          ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
          ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
          ((Control) this.cmbsServizio).DataBind();
        }
        else
          ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", string.Empty));
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", string.Empty));
    }

    private void BindApparecchiatura()
    {
      ((ListControl) this.cmbsApparecchiatura).Items.Clear();
      Apparecchiature apparecchiature = new Apparecchiature(this.Context.User.Identity.Name);
      if (((TextBox) this.RicercaModulo1.TxtCodice).Text != "")
      {
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Size(50);
        ((ParameterObject) sObject1).set_Index(0);
        ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
        CollezioneControlli.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_Servizio");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(1);
        ((ParameterObject) sObject2).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
        CollezioneControlli.Add(sObject2);
        DataSet dataSet = apparecchiature.GetData(CollezioneControlli).Copy();
        if (dataSet.Tables[0].Rows.Count > 0)
        {
          ((BaseDataBoundControl) this.cmbsApparecchiatura).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Standard -", "");
          ((ListControl) this.cmbsApparecchiatura).DataTextField = "DESCRIZIONE";
          ((ListControl) this.cmbsApparecchiatura).DataValueField = "ID";
          ((Control) this.cmbsApparecchiatura).DataBind();
        }
        else
          ((ListControl) this.cmbsApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Standard -", string.Empty));
      }
      else
        ((ListControl) this.cmbsApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Standard -", string.Empty));
    }

    private void cmbsServizio_SelectedIndexChanged(object sender, EventArgs e) => this.BindApparecchiatura();

    private void S_btMostra_Click(object sender, EventArgs e) => this.Execute();

    private void Execute()
    {
      if (((TextBox) this.RicercaModulo1.TxtCodice).Text == "")
      {
        this.BindServizio("");
        this.BindApparecchiatura();
        this.BindPiano("");
      }
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
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
      ((ParameterObject) sObject3).set_ParameterName("p_Servizio");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_eqstdid");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(8);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) (((ListControl) this.cmbsApparecchiatura).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsApparecchiatura).SelectedValue)));
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_eq_id");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size(8);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Size(50);
      ((ParameterObject) sObject5).set_Value((object) this.CodiceApparecchiature1.CodiceApparecchiatura);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_dismesso");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Size(8);
      ((ParameterObject) sObject6).set_Value((object) DismissioneType.NO);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_idpiano");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(10);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Value((object) (((ListControl) this.cmbsPiano).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsPiano).SelectedValue)));
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_idstanza");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Size(30);
      ((ParameterObject) sObject8).set_Index(7);
      ((ParameterObject) sObject8).set_Value((object) this.UserStanze1.DescStanza);
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_dataDa");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Size(10);
      ((ParameterObject) sObject9).set_Index(8);
      ((ParameterObject) sObject9).set_Value((object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_dataA");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Size(10);
      ((ParameterObject) sObject10).set_Index(9);
      ((ParameterObject) sObject10).set_Value((object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      CollezioneControlli.Add(sObject10);
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.LetturaContatori(this.Context.User.Identity.Name).RicercaApparecchiatura(CollezioneControlli);
      this.GridTitle1.Visible = true;
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        this.DataGridLettura.Visible = true;
        this.GridTitle1.DescriptionTitle = "";
        this.DataGridLettura.DataSource = (object) dataSet.Tables[0].Copy();
        this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count == 0 ? "0" : dataSet.Tables[0].Rows.Count.ToString();
        this.DataGridLettura.DataBind();
      }
      else
      {
        this.GridTitle1.DescriptionTitle = "Nessun dato trovato.";
        this.DataGridLettura.Visible = false;
      }
    }

    private void DataGridLettura_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridLettura.CurrentPageIndex = e.NewPageIndex;
      this.Execute();
      this.GetControlli();
    }

    private void BindPiano(string CodEdificio)
    {
      ((ListControl) this.cmbsPiano).Items.Clear();
      if (CodEdificio == "")
        CodEdificio = "0";
      if (CodEdificio != "0")
      {
        DataSet pianiBuilding = new TheSite.Classi.ClassiAnagrafiche.Buildings().GetPianiBuilding(int.Parse(CodEdificio));
        if (pianiBuilding.Tables[0].Rows.Count > 0)
        {
          ((BaseDataBoundControl) this.cmbsPiano).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(pianiBuilding.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "");
          ((ListControl) this.cmbsPiano).DataTextField = "DESCRIZIONE";
          ((ListControl) this.cmbsPiano).DataValueField = "ID";
          ((Control) this.cmbsPiano).DataBind();
        }
        else
          ((ListControl) this.cmbsPiano).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", string.Empty));
        ((WebControl) this.cmbsPiano).Enabled = true;
      }
      else
        ((ListControl) this.cmbsPiano).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", string.Empty));
    }

    private void BindStanza()
    {
    }

    private void BindTuttiPiani()
    {
      ((ListControl) this.cmbsPiano).Items.Clear();
      DataSet allPiani = new TheSite.Classi.ClassiAnagrafiche.Buildings().GetAllPiani();
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

    private void btnReset_Click(object sender, EventArgs e) => this.Server.Transfer("LetturaContatori.aspx");

    private string IDBL
    {
      get => this.hiddenblid.Value;
      set => this.hiddenblid.Value = value;
    }

    private void GetControlli()
    {
      clMyDataGridCollection dataGridCollection = new clMyDataGridCollection();
      if (this.Session["CheckedList"] == null)
        return;
      dataGridCollection.GetControl(this.DataGridLettura, (Hashtable) this.Session["CheckedList"], this.DataGridLettura.CurrentPageIndex);
    }

    private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridLettura.CurrentPageIndex = e.NewPageIndex;
      this.Execute();
    }

    private void DataGridLettura_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton1")).Attributes.Add("title", "Visualizza Apparecchiatura");
      ((WebControl) e.Item.Cells[2].FindControl("Imagebutton2")).Attributes.Add("title", "Visualizza Le Richieste di Lavoro");
    }

    public void imageButton_Click(object sender, CommandEventArgs e)
    {
    }

    private void DataGridLettura_ItemCreated(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.EditItem)
        return;
      ((WebControl) e.Item.Cells[1].Controls[1]).Attributes.Add("onclick", "return confirm(\"Sei sicuro di Cancellare l'apparecchiatura?\");");
    }

    private void DataGridLettura_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString());
    }

    private void DeleteItem(string id)
    {
    }
  }
}
