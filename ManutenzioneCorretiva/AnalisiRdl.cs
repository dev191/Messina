// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorretiva.AnalisiRdl
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
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ManCorrettiva;
using TheSite.Classi.ManOrdinaria;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorretiva
{
  public class AnalisiRdl : Page
  {
    protected S_Button btnsRicerca;
    protected DataPanel PanelRicerca;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    protected RicercaModulo RicercaModulo1;
    protected CalendarPicker CalendarPicker1;
    protected CalendarPicker CalendarPicker2;
    public static string HelpLink = string.Empty;
    private clMyCollection _myColl = new clMyCollection();
    protected S_ComboBox cmbsid_status;
    protected S_TextBox txtswo_id;
    protected S_TextBox txtswr_id;
    protected CompareValidator CompareValidator1;
    protected S_Button btnExcel;
    protected S_Button btReset;
    private AnalisiRdlStorico _fp;

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      ((Button) this.btReset).Click += new EventHandler(this.btReset_Click);
      ((Button) this.btnExcel).Click += new EventHandler(this.btnExcel_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged_1);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      AnalisiRdl.FunId = siteModule.ModuleId;
      AnalisiRdl.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.check_caselle_testo();
      this.RicercaModulo1.TxtCodice.set_DBParameterName("p_bl_id");
      this.RicercaModulo1.TxtCodice.set_DBIndex(5);
      this.RicercaModulo1.TxtCodice.set_DBDataType((CustomDBType) 2);
      this.RicercaModulo1.TxtCodice.set_DBDirection(ParameterDirection.Input);
      this.RicercaModulo1.TxtCodice.set_DBSize(50);
      this.RicercaModulo1.TxtCodice.set_DBDefaultValue((object) "");
      this.RicercaModulo1.TxtRicerca.set_DBParameterName("p_campus");
      this.RicercaModulo1.TxtRicerca.set_DBIndex(6);
      this.RicercaModulo1.TxtRicerca.set_DBDataType((CustomDBType) 2);
      this.RicercaModulo1.TxtRicerca.set_DBDirection(ParameterDirection.Input);
      this.RicercaModulo1.TxtRicerca.set_DBSize((int) byte.MaxValue);
      this.RicercaModulo1.TxtRicerca.set_DBDefaultValue((object) "");
      this.CalendarPicker1.Datazione.set_DBParameterName("p_init");
      this.CalendarPicker1.Datazione.set_DBIndex(0);
      this.CalendarPicker1.Datazione.set_DBDataType((CustomDBType) 2);
      this.CalendarPicker1.Datazione.set_DBDirection(ParameterDirection.Input);
      this.CalendarPicker1.Datazione.set_DBSize(10);
      this.CalendarPicker1.Datazione.set_DBDefaultValue((object) "");
      this.CalendarPicker2.Datazione.set_DBParameterName("p_fine");
      this.CalendarPicker2.Datazione.set_DBIndex(1);
      this.CalendarPicker2.Datazione.set_DBDataType((CustomDBType) 2);
      this.CalendarPicker2.Datazione.set_DBDirection(ParameterDirection.Input);
      this.CalendarPicker2.Datazione.set_DBSize(10);
      this.CalendarPicker2.Datazione.set_DBDefaultValue((object) "");
      this.CompareValidator1.ControlToValidate = this.CalendarPicker2.ID + ":" + ((Control) this.CalendarPicker2.Datazione).ID;
      this.CompareValidator1.ControlToCompare = this.CalendarPicker1.ID + ":" + ((Control) this.CalendarPicker1.Datazione).ID;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("this.value = 'Attendere ...';");
      stringBuilder.Append("this.disabled = true;");
      stringBuilder.Append("document.getElementById('" + ((Control) this.btnsRicerca).ClientID + "').disabled = true;");
      stringBuilder.Append(this.Page.GetPostBackEventReference((Control) this.btnsRicerca));
      stringBuilder.Append(";");
      ((WebControl) this.btnsRicerca).Attributes.Add("onclick", stringBuilder.ToString());
      if (this.Page.IsPostBack)
        return;
      this.GridTitle1.Visible = false;
      if (this.Request.QueryString["FunId"] != null)
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      this.BindWR_status();
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is AnalisiRdlStorico))
        return;
      this._fp = (AnalisiRdlStorico) this.Context.Handler;
      if (this._fp == null)
        return;
      this._myColl = this._fp._Contenitore;
      this._myColl.SetValues(this.Page.Controls);
      this.Ricerca(true);
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.Ricerca(true);
    }

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString());
    }

    private void DataGridRicerca_PageIndexChanged_1(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca(false);
    }

    private void BindWR_status()
    {
      ((BaseDataBoundControl) this.cmbsid_status).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(new Richiesta().GetStatusAnalisi().Tables[0], "DESCRIZIONE", "ID", "-Selezionare uno Stato-", "0");
      ((ListControl) this.cmbsid_status).DataTextField = "DESCRIZIONE";
      ((ListControl) this.cmbsid_status).DataValueField = "ID";
      ((Control) this.cmbsid_status).DataBind();
    }

    private void Ricerca(bool reset)
    {
      ClManCorrettiva clManCorrettiva = new ClManCorrettiva();
      this.txtswo_id.set_DBDefaultValue((object) 0);
      this.txtswr_id.set_DBDefaultValue((object) 0);
      this.cmbsid_status.set_DBDefaultValue((object) 0);
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) ((Control) this.PanelRicerca).Controls);
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pageindex");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(16);
      ((ParameterObject) sObject1).set_Value((object) (this.DataGridRicerca.CurrentPageIndex + 1));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pagesize");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(17);
      ((ParameterObject) sObject2).set_Value((object) this.DataGridRicerca.PageSize);
      CollezioneControlli.Add(sObject2);
      this.DataGridRicerca.DataSource = (object) clManCorrettiva.GetAnalisiRDL(CollezioneControlli, this.Context.User.Identity.Name).Copy().Tables[0];
      if (reset)
      {
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        int analisiRdlCount = clManCorrettiva.GetAnalisiRDLCount(CollezioneControlli, this.Context.User.Identity.Name);
        this.GridTitle1.NumeroRecords = analisiRdlCount.ToString();
        if (analisiRdlCount % this.DataGridRicerca.PageSize == 0)
        {
          int num1 = analisiRdlCount / this.DataGridRicerca.PageSize;
        }
        else
        {
          int num2 = analisiRdlCount / this.DataGridRicerca.PageSize;
        }
      }
      else
        double.Parse(this.GridTitle1.NumeroRecords);
      this.DataGridRicerca.Visible = true;
      this.GridTitle1.Visible = true;
      if (int.Parse(this.GridTitle1.NumeroRecords) == 0)
      {
        this.DataGridRicerca.CurrentPageIndex = 0;
        this.GridTitle1.DescriptionTitle = "Nessun dato trovato.";
      }
      else
        this.GridTitle1.DescriptionTitle = "";
      this.DataGridRicerca.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.DataGridRicerca.DataBind();
    }

    private void check_caselle_testo()
    {
      ((WebControl) this.txtswr_id).Attributes.Add("onkeypress", "Verifica(this.value)");
      ((WebControl) this.txtswo_id).Attributes.Add("onkeypress", "Verifica(this.value)");
      ((WebControl) this.txtswr_id).Attributes.Add("onpaste", "return nonpaste();");
      ((WebControl) this.txtswo_id).Attributes.Add("onpaste", "return nonpaste();");
    }

    private void btnExcel_Click(object sender, EventArgs e)
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

    private void btReset_Click(object sender, EventArgs e) => this.Response.Redirect("AnalisiRdl.aspx?FunId=" + this.ViewState["FunId"]);

    public DataSet GetWordExcel()
    {
      ClManCorrettiva clManCorrettiva = new ClManCorrettiva();
      this.txtswo_id.set_DBDefaultValue((object) 0);
      this.txtswr_id.set_DBDefaultValue((object) 0);
      this.cmbsid_status.set_DBDefaultValue((object) 0);
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) ((Control) this.PanelRicerca).Controls);
      return clManCorrettiva.GetAnalisiRDLExcel(CollezioneControlli, this.Context.User.Identity.Name).Copy();
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[1].FindControl("lnkDett")).Attributes.Add("title", "Visualizza Storico Richiesta di Lavoro");
    }
  }
}
