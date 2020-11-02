// Decompiled with JetBrains decompiler
// Type: TheSite.SoddisfazioneCliente.IndicePrestazione
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
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.SoddisfazioneCliente
{
  public class IndicePrestazione : Page
  {
    protected DropDownList cmbsAnno;
    protected DropDownList cmbQuadrimestre;
    protected S_ComboBox cmbsIndice;
    protected Panel PanelServizio;
    protected S_Button btnsRicerca;
    protected S_Button cmdExcel;
    protected S_Button btnReset;
    protected DataPanel PanelRicerca;
    protected S_ComboBox cmbsPriorita;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      SiteModule siteModule = new SiteModule("./SoddisfazioneCliente/IndicePrestazione.aspx");
      IndicePrestazione.FunId = siteModule.ModuleId;
      IndicePrestazione.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["FunId"] != null)
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      this.BindAnno();
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

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.BindData();
    }

    private void BindData()
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
      ((ParameterObject) sObject1).set_ParameterName("p_anno");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(1);
      ((ParameterObject) sObject1).set_Value((object) this.cmbsAnno.SelectedValue);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_quadrimestre");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(2);
      ((ParameterObject) sObject2).set_Value((object) this.cmbQuadrimestre.SelectedValue);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_priorita");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(4);
      ((ParameterObject) sObject3).set_Value((object) 0);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_indice");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      ((ParameterObject) sObject4).set_Value((object) ((ListControl) this.cmbsIndice).SelectedValue);
      CollezioneControlli.Add(sObject4);
      return giudizio.GetIndicePriorita(CollezioneControlli).Copy();
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      double num = double.Parse(((DataRowView) e.Item.DataItem)["ip"].ToString());
      if (num == 1.0)
        e.Item.Cells[4].BackColor = Color.FromName("#66D71C");
      else if (num < 1.0 && num >= 0.8)
        e.Item.Cells[4].BackColor = Color.FromName("#FCFC81");
      else if (num < 0.8 && num > 0.6)
        e.Item.Cells[4].BackColor = Color.FromName("#FF3131");
      else if (num < 0.6)
        e.Item.Cells[4].BackColor = Color.FromName("#BB0000");
      e.Item.Cells[1].Text += "° Quadrimestre";
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
        this.BindData();
      }
      catch (HttpException ex)
      {
        Console.WriteLine(ex.Message);
        this.DataGridRicerca.CurrentPageIndex = 0;
        this.BindData();
      }
    }

    private void btnReset_Click(object sender, EventArgs e) => this.Response.Redirect("IndicePrestazione.aspx?FunId=" + (object) IndicePrestazione.FunId);
  }
}
