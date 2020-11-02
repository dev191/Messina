// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorretiva.AnalisiRdlStorico
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using MyCollection;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ManOrdinaria;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorretiva
{
  public class AnalisiRdlStorico : Page
  {
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    private clMyCollection _myColl = new clMyCollection();
    protected Button btnsExcel;
    private AnalisiRdl _fp;

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      this.DataGridRicerca.Columns[1].Visible = siteModule.IsEditable;
      AnalisiRdlStorico.FunId = siteModule.ModuleId;
      AnalisiRdlStorico.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.carica_record();
      if (this.Page.IsPostBack || !(this.Context.Handler is AnalisiRdl))
        return;
      this._fp = (AnalisiRdl) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.btnsExcel.Click += new EventHandler(this.btnsExcel_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void carica_record()
    {
      PageTitle pageTitle1 = this.PageTitle1;
      pageTitle1.Title = pageTitle1.Title + ": " + this.Request.QueryString["wr_id"];
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_wr_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(1);
      ((ParameterObject) sObject).set_Size(10);
      ((ParameterObject) sObject).set_Value((object) this.Request.QueryString["wr_id"]);
      CollezioneControlli.Add(sObject);
      DataSet dataSet = new Richiesta().GetHWR(CollezioneControlli, this.Context.User.Identity.Name).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      if (dataSet.Tables[0].Rows.Count == 0)
      {
        this.DataGridRicerca.CurrentPageIndex = 0;
      }
      else
      {
        int num = 0;
        if (dataSet.Tables[0].Rows.Count % this.DataGridRicerca.PageSize > 0)
          ++num;
        if (this.DataGridRicerca.PageCount != (int) Convert.ToInt16(dataSet.Tables[0].Rows.Count / this.DataGridRicerca.PageSize + num))
          this.DataGridRicerca.CurrentPageIndex = 0;
      }
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.carica_record();
    }

    private void DataGridRicerca_PageIndexChanged_1(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.carica_record();
    }

    private void btnsExcel_Click(object sender, EventArgs e)
    {
      Export export = new Export();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = this.GetWordExcel().Tables[0].Copy();
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

    public DataSet GetWordExcel()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_wr_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(1);
      ((ParameterObject) sObject).set_Size(10);
      ((ParameterObject) sObject).set_Value((object) this.Request.QueryString["wr_id"]);
      CollezioneControlli.Add(sObject);
      return new Richiesta().GetHWR(CollezioneControlli, this.Context.User.Identity.Name).Copy();
    }
  }
}
