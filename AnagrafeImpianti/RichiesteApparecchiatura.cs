// Decompiled with JetBrains decompiler
// Type: TheSite.AnagrafeImpianti.RichiesteApparecchiatura
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
using System.Data;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManOrdinaria;
using TheSite.WebControls;

namespace TheSite.AnagrafeImpianti
{
  public class RichiesteApparecchiatura : Page
  {
    protected S_TextBox txtsRichiesta;
    protected S_Button btnsRicerca;
    protected DataPanel PanelRicerca;
    protected S_TextBox txtsOrdine;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    protected CalendarPicker CalendarPicker1;
    protected CalendarPicker CalendarPicker2;
    protected Addetti Addetti1;
    public static int FunId = 0;
    protected S_ComboBox cmbsStatus;
    protected S_Button cmdExcel;
    protected CompareValidator CompareValidator1;
    public static string HelpLink = string.Empty;
    private clMyCollection _myColl = new clMyCollection();
    protected S_Label S_lblcodicecomponente;
    protected S_Label S_lblstdapparecchiature;
    protected S_Label S_lblcodiceedificio;
    protected Button cmdReset;
    protected TabStrip TabStrip1;
    protected S_Label S_lbledificio;

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      ((WebControl) this.txtsRichiesta).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtsRichiesta).Attributes.Add("onpaste", "return nonpaste();");
      ((WebControl) this.txtsOrdine).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtsOrdine).Attributes.Add("onpaste", "return nonpaste();");
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      RichiesteApparecchiatura.FunId = siteModule.ModuleId;
      RichiesteApparecchiatura.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      if (this.Page.IsPostBack)
        return;
      PropertyInfo property = this.Context.Handler.GetType().GetProperty("_Contenitore");
      if (property != null)
        this.ViewState.Add("mioContenitore", property.GetValue((object) this.Context.Handler, (object[]) null));
      if (this.Context.Items[(object) "eq_id"] != null)
        this.eq_id = (string) this.Context.Items[(object) "eq_id"];
      if (this.Context.Items[(object) "eq_id_char"] != null)
        this.eq_id_char = (string) this.Context.Items[(object) "eq_id_char"];
      if (this.Request.QueryString["eq_id"] != null)
        this.eq_id = this.Request.QueryString["eq_id"];
      this.CaricaScheda();
      this.Addetti1.Set_BL_ID(((Label) this.S_lblcodiceedificio).Text);
      if (this.Request.QueryString["FunId"] != null)
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      this.CompareValidator1.ControlToValidate = this.CalendarPicker2.ID + ":" + ((Control) this.CalendarPicker2.Datazione).ID;
      this.CompareValidator1.ControlToCompare = this.CalendarPicker1.ID + ":" + ((Control) this.CalendarPicker1.Datazione).ID;
      this.DataGridRicerca.Visible = false;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.GridTitle1.Visible = false;
      this.BindStatus();
      this.Ricerca((TipoManutenzioneType) 0);
    }

    private void BindStatus()
    {
      ((ListControl) this.cmbsStatus).Items.Clear();
      DataSet status = new Richiesta().GetStatus();
      if (status.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsStatus).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(status.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Stato -", "");
        ((ListControl) this.cmbsStatus).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsStatus).DataValueField = "ID";
        ((Control) this.cmbsStatus).DataBind();
      }
      else
        ((ListControl) this.cmbsStatus).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Stato -", string.Empty));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      ((Button) this.cmdExcel).Click += new EventHandler(this.cmdExcel_Click);
      this.cmdReset.Click += new EventHandler(this.cmdReset_Click);
      this.TabStrip1.add_SelectedIndexChange(new EventHandler(this.TabStrip1_SelectedIndexChange));
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private string eq_id
    {
      get => this.ViewState["s_eq_id"] == null ? string.Empty : (string) this.ViewState["s_eq_id"];
      set
      {
        if (value == null)
          this.ViewState["s_eq_id"] = (object) string.Empty;
        else
          this.ViewState["s_eq_id"] = (object) value;
      }
    }

    private string eq_id_char
    {
      get => this.ViewState["s_eq_id_char"] == null ? string.Empty : (string) this.ViewState["s_eq_id_char"];
      set
      {
        if (value == null)
          this.ViewState["s_eq_id_char"] = (object) string.Empty;
        else
          this.ViewState["s_eq_id_char"] = (object) value;
      }
    }

    private void btnsRicerca_Click(object sender, EventArgs e) => this.Query();

    private void Query()
    {
      if (this.TabStrip1.get_SelectedIndex() == 0)
        this.Ricerca((TipoManutenzioneType) 0);
      if (this.TabStrip1.get_SelectedIndex() == 1)
        this.Ricerca(TipoManutenzioneType.ManutenzionesuRichiesta);
      if (this.TabStrip1.get_SelectedIndex() == 2)
        this.Ricerca(TipoManutenzioneType.ManutenzioneProgrammata);
      if (this.TabStrip1.get_SelectedIndex() != 3)
        return;
      this.Ricerca(TipoManutenzioneType.ManutenzioneStraordinaria);
    }

    private void Ricerca(TipoManutenzioneType t)
    {
      Apparecchiature apparecchiature = new Apparecchiature();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Wr_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(2);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) (((TextBox) this.txtsRichiesta).Text == "" ? 0 : int.Parse(((TextBox) this.txtsRichiesta).Text)));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Addetto");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(3);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) this.Addetti1.NomeCompleto);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_DataDa");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(4);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Value(((TextBox) this.CalendarPicker1.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_DataA");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(5);
      ((ParameterObject) sObject4).set_Size(10);
      ((ParameterObject) sObject4).set_Value(((TextBox) this.CalendarPicker2.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_Wo_Id");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(6);
      ((ParameterObject) sObject5).set_Size(50);
      ((ParameterObject) sObject5).set_Value((object) (((TextBox) this.txtsOrdine).Text == "" ? 0 : int.Parse(((TextBox) this.txtsOrdine).Text)));
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_Status");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(8);
      ((ParameterObject) sObject6).set_Value((object) (((ListControl) this.cmbsStatus).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsStatus).SelectedValue)));
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_eq");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(9);
      ((ParameterObject) sObject7).set_Value((object) this.eq_id);
      ((ParameterObject) sObject7).set_Size(50);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_TipoManutenzione");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(10);
      ((ParameterObject) sObject8).set_Size(4);
      ((ParameterObject) sObject8).set_Value((object) t);
      CollezioneControlli.Add(sObject8);
      DataSet dataSet = apparecchiature.GetSfogliaRDLEQ(CollezioneControlli, this.DataGridRicerca.PageSize, this.DataGridRicerca.CurrentPageIndex).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.Visible = true;
      this.GridTitle1.Visible = true;
      if (dataSet.Tables[0].Rows.Count == 0)
      {
        this.DataGridRicerca.CurrentPageIndex = 0;
        this.GridTitle1.DescriptionTitle = "Nessun dato trovato.";
      }
      else
      {
        this.GridTitle1.DescriptionTitle = "";
        int num = 0;
        if (dataSet.Tables[0].Rows.Count % this.DataGridRicerca.PageSize > 0)
          ++num;
        if (this.DataGridRicerca.PageCount != (int) Convert.ToInt16(dataSet.Tables[0].Rows.Count / this.DataGridRicerca.PageSize + num))
          this.DataGridRicerca.CurrentPageIndex = 0;
      }
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
    }

    private long CalcolaTot()
    {
      Apparecchiature apparecchiature = new Apparecchiature();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Wr_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(2);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) (((TextBox) this.txtsRichiesta).Text == "" ? 0 : int.Parse(((TextBox) this.txtsRichiesta).Text)));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Addetto");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(3);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) this.Addetti1.NomeCompleto);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_DataDa");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(4);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Value(((TextBox) this.CalendarPicker1.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_DataA");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(5);
      ((ParameterObject) sObject4).set_Size(10);
      ((ParameterObject) sObject4).set_Value(((TextBox) this.CalendarPicker2.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_Wo_Id");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(6);
      ((ParameterObject) sObject5).set_Size(50);
      ((ParameterObject) sObject5).set_Value((object) (((TextBox) this.txtsOrdine).Text == "" ? 0 : int.Parse(((TextBox) this.txtsOrdine).Text)));
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_Status");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(8);
      ((ParameterObject) sObject6).set_Value((object) (((ListControl) this.cmbsStatus).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsStatus).SelectedValue)));
      CollezioneControlli.Add(sObject6);
      return long.Parse(apparecchiature.GetTotRDLEQ(CollezioneControlli, this.DataGridRicerca.PageSize, this.DataGridRicerca.CurrentPageIndex).Copy().Tables[0].Rows[0][0].ToString());
    }

    private void cmdExcel_Click(object sender, EventArgs e)
    {
      Export export = new Export();
      DataTable dataTable = new DataTable();
      if (this.TabStrip1.get_SelectedIndex() == 0)
        dataTable = this.GetWordExcel((TipoManutenzioneType) 0).Tables[0].Copy();
      if (this.TabStrip1.get_SelectedIndex() == 1)
        dataTable = this.GetWordExcel(TipoManutenzioneType.ManutenzionesuRichiesta).Tables[0].Copy();
      if (this.TabStrip1.get_SelectedIndex() == 2)
        dataTable = this.GetWordExcel(TipoManutenzioneType.ManutenzioneProgrammata).Tables[0].Copy();
      if (this.TabStrip1.get_SelectedIndex() == 3)
        dataTable = this.GetWordExcel(TipoManutenzioneType.ManutenzioneStraordinaria).Tables[0].Copy();
      if (dataTable.Rows.Count != 0)
      {
        export.ExportDetails(dataTable, (Export.ExportFormat) 2, "exp.xls");
      }
      else
      {
        string script = "<script language=JavaScript>alert('Nessun elemento da esportare');" + "<" + "/" + "script>";
        if (this.IsClientScriptBlockRegistered("clientScriptexp"))
          return;
        this.RegisterStartupScript("clientScriptexp", script);
      }
    }

    public DataSet GetWordExcel(TipoManutenzioneType t)
    {
      Apparecchiature apparecchiature = new Apparecchiature();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Wr_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(2);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) (((TextBox) this.txtsRichiesta).Text == "" ? 0 : int.Parse(((TextBox) this.txtsRichiesta).Text)));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Addetto");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(3);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) this.Addetti1.NomeCompleto);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_DataDa");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(4);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Value(((TextBox) this.CalendarPicker1.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_DataA");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(5);
      ((ParameterObject) sObject4).set_Size(10);
      ((ParameterObject) sObject4).set_Value(((TextBox) this.CalendarPicker2.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_Wo_Id");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(6);
      ((ParameterObject) sObject5).set_Size(50);
      ((ParameterObject) sObject5).set_Value((object) (((TextBox) this.txtsOrdine).Text == "" ? 0 : int.Parse(((TextBox) this.txtsOrdine).Text)));
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_Status");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(8);
      ((ParameterObject) sObject6).set_Value((object) (((ListControl) this.cmbsStatus).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsStatus).SelectedValue)));
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_eq");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(9);
      ((ParameterObject) sObject7).set_Value((object) this.eq_id);
      ((ParameterObject) sObject7).set_Size(50);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_TipoManutenzione");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(10);
      ((ParameterObject) sObject8).set_Size(4);
      ((ParameterObject) sObject8).set_Value((object) t);
      CollezioneControlli.Add(sObject8);
      return apparecchiature.GetSfogliaRDLEQ(CollezioneControlli).Copy();
    }

    private void CaricaScheda()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_eq_std");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) this.eq_id_char);
      ((ParameterObject) sObject).set_Size(50);
      CollezioneControlli.Add(sObject);
      DataSet data = new SchedaApparecchiatura("").GetData(CollezioneControlli);
      if (data.Tables[0].Rows.Count > 0)
      {
        ((Label) this.S_lblcodicecomponente).Text = data.Tables[0].Rows[0]["var_eq_eq_id"].ToString();
        ((Label) this.S_lblstdapparecchiature).Text = data.Tables[0].Rows[0]["var_eqstd_description"].ToString();
        ((Label) this.S_lblcodiceedificio).Text = data.Tables[0].Rows[0]["var_eq_bl_id"].ToString();
        ((Label) this.S_lbledificio).Text = data.Tables[0].Rows[0]["var_bl_name"].ToString();
      }
      else
      {
        ((Label) this.S_lblcodicecomponente).Text = "";
        ((Label) this.S_lblstdapparecchiature).Text = "";
        ((Label) this.S_lblcodiceedificio).Text = "";
        ((Label) this.S_lbledificio).Text = "";
      }
    }

    private void ImpostaPagine(long totRecord)
    {
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Query();
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      string str1 = e.Item.Cells[7].Text.Trim();
      if (e.Item.Cells[7].Text.Trim().Length <= 20)
        return;
      string str2 = e.Item.Cells[7].Text.Trim().Substring(0, 17) + "...";
      e.Item.Cells[7].Text = str2;
      e.Item.Cells[7].ToolTip = str1;
    }

    private void cmdReset_Click(object sender, EventArgs e) => this.Server.Transfer("NavigazioneApparecchiature.aspx");

    private void TabStrip1_SelectedIndexChange(object sender, EventArgs e) => this.Query();
  }
}
