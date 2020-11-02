// Decompiled with JetBrains decompiler
// Type: TheSite.SoddisfazioneCliente.IndiceSoddifazione
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
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiDettaglio;
using TheSite.WebControls;

namespace TheSite.SoddisfazioneCliente
{
  public class IndiceSoddifazione : Page
  {
    protected S_ComboBox cmbsServizio;
    protected Panel PanelServizio;
    protected S_Button btnsRicerca;
    protected S_Button btnReset;
    protected DataPanel PanelRicerca;
    protected S_ComboBox cmbsTipoGiudizio;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    protected RequiredFieldValidator rfvOraRichiesta;
    public static int FunId = 0;
    public int controllo = 0;
    private EditGiudizio _fp;
    protected RicercaModulo RicercaModulo1;
    public static string HelpLink = string.Empty;
    protected TextBox txtBL_ID;
    protected Button btsCodice;
    protected Panel PanelRichiedente;
    protected S_Button cmdExcel;
    protected DropDownList cmbsAnno;
    protected DropDownList cmbQuadrimestre;
    protected S_ComboBox cmbsIndice;
    private clMyCollection _myColl = new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = new SiteModule("./SoddisfazioneCliente/IndiceSoddifazione.aspx");
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.DataGridRicerca.Columns[1].Visible = true;
      this.DataGridRicerca.Columns[2].Visible = siteModule.IsEditable;
      IndiceSoddifazione.FunId = siteModule.ModuleId;
      IndiceSoddifazione.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindServizio);
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      stringBuilder2.Append("if (typeof(seledificio) == 'function') { ");
      stringBuilder2.Append("if (seledificio() == false) { return false; }} ");
      stringBuilder2.Append("document.getElementById('" + ((Control) this.cmbsServizio).ClientID + "').disabled = true;");
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
        }
      }
      this.BindAnno();
      this.BindServizio(string.Empty);
    }

    private void BindAnno()
    {
      int year = DateTime.Now.Year;
      short num = 0;
      for (int index = year - 10; index <= year; ++index)
      {
        this.cmbsAnno.Items.Add(index.ToString());
        if (year == index)
          this.cmbsAnno.Items[(int) num].Selected = true;
        ++num;
      }
    }

    private void Ricerca()
    {
      DataSet data = this.GetData();
      this.DataGridRicerca.DataSource = (object) data.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = data.Tables[0].Rows.Count.ToString();
      this.GridTitle1.Visible = true;
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
      ((ParameterObject) sObject2).set_ParameterName("p_anno");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) this.cmbsAnno.SelectedValue);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_quadrimestre");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) this.cmbQuadrimestre.SelectedValue);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_id_servizio");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) ((ListControl) this.cmbsServizio).SelectedValue);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_livello");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) ((ListControl) this.cmbsIndice).SelectedValue);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_tipogiudizio");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject6).set_Value((object) ((ListControl) this.cmbsTipoGiudizio).SelectedValue);
      CollezioneControlli.Add(sObject6);
      return giudizio.GetIndiceSoddisfazione(CollezioneControlli).Copy();
    }

    private void BindServizio(string CodEdificio)
    {
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      Servizi servizi = new Servizi(this.Context.User.Identity.Name);
      DataSet data;
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
        data = servizi.GetData(CollezioneControlli);
      }
      else
        data = servizi.GetData();
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

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      ((Button) this.cmdExcel).Click += new EventHandler(this.cmdExcel_Click);
      ((Button) this.btnReset).Click += new EventHandler(this.btnReset_Click);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnReset_Click(object sender, EventArgs e) => this.Response.Redirect("IndiceSoddifazione.aspx?FunId=" + (object) IndiceSoddifazione.FunId);

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.Ricerca();
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      double num = double.Parse(((DataRowView) e.Item.DataItem)["indicesoddisfazione"].ToString());
      if (num == 1.0)
        e.Item.Cells[5].BackColor = Color.FromName("#66D71C");
      else if (num < 1.0 && num >= 0.8)
        e.Item.Cells[5].BackColor = Color.FromName("#FCFC81");
      else if (num < 0.8 && num > 0.6)
      {
        e.Item.Cells[5].BackColor = Color.FromName("#FF3131");
      }
      else
      {
        if (num >= 0.6)
          return;
        e.Item.Cells[5].BackColor = Color.FromName("#BB0000");
      }
    }

    private void cmdExcel_Click(object sender, EventArgs e)
    {
      Export export = new Export();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = this.GetData().Tables[0].Copy();
      if (dataTable2.Rows.Count != 0)
      {
        export.ExportDetails(dataTable2, (Export.ExportFormat) 2, "exp.xls");
      }
      else
      {
        string script = "<script language=JavaScript>alert('Nessun elemento da esportare');" + "<" + "/" + "script>";
        if (this.IsClientScriptBlockRegistered("clientScriptexp"))
          return;
        this.RegisterStartupScript("clientScriptexp", script);
      }
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      try
      {
        this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
        this.Ricerca();
      }
      catch (HttpException ex)
      {
        Console.WriteLine(ex.Message);
        this.DataGridRicerca.CurrentPageIndex = 0;
        this.Ricerca();
      }
    }
  }
}
