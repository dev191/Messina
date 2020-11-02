// Decompiled with JetBrains decompiler
// Type: GIC.Report.UserControl.SelezioneQuery
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using GIC.App_Code;
using GIC.App_Code.Businnes;
using GIC.App_Code.Datagrid;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.GIC.App_Code.DataSetDef;

namespace GIC.Report.UserControl
{
  public class SelezioneQuery : BaseControl
  {
    protected S_TextBox TextBox1;
    protected Button TxtSuchen;
    protected Button BtnNeu;
    protected DataSetReport dataSetReport1;
    protected DataGrid DataGridQuery;
    protected HtmlTable TableQuery;
    protected new Label LabelMessage;
    protected S_TextBox TextBox2;
    protected int IdVista;
    protected Button BtnIndietro;
    protected string NomeVista;

    private void Page_Load(object sender, EventArgs e)
    {
      this.ControlloDatagrid = (DatagridControl) new QueryDTControl(this.DataGridQuery);
      base.LabelMessage = this.LabelMessage;
      if (this.IsPostBack)
        return;
      this.BindDataGrid();
    }

    public void Ricarica() => this.BindDataGrid();

    protected override void BindDataGrid()
    {
      this.SetParamQuery();
      this.DataGridDati = this.DataGridQuery;
      if (!this.IsPostBack)
        this.ControlloDatagrid.InitDataGrid();
      this.DataGridDati.CurrentPageIndex = this.numeroPagina;
      foreach (DataRow row in (InternalDataCollectionBase) this.GetData().Rows)
        this.dataSetReport1.Query.ImportRow(row);
      this.DataGridDati.DataBind();
    }

    private void SetParamQuery()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pIdQuery");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Value((object) DBNull.Value);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pDenominazione");
      ((ParameterObject) sObject2).set_Size(100);
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.TextBox1).Text);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pDescrizione");
      ((ParameterObject) sObject3).set_Size(500);
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Value((object) ((TextBox) this.TextBox2).Text);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("pSortExpression");
      ((ParameterObject) sObject4).set_Size(100);
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Value(Convert.ToString(this.ViewState["campoDiOrdinamento"]) == "" ? (object) "NULL" : (object) Convert.ToString(this.ViewState["campoDiOrdinamento"]));
      controlsCollection.Add(sObject4);
      this.IdVista = Convert.ToInt32(((Hashtable) this.Session["ParametriSelectSchema"])[(object) "IdVista"]);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("pIdVista");
      ((ParameterObject) sObject5).set_Size(32);
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Value((object) this.IdVista);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("putente");
      ((ParameterObject) sObject6).set_Size(100);
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Value((object) HttpContext.Current.User.Identity.Name);
      controlsCollection.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("io_cursor");
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject7).set_Value((object) DBNull.Value);
      controlsCollection.Add(sObject7);
      this.paramFederico = controlsCollection;
      this.CurrentProcedure = "IL_PACK_INTERROGAZIONI.IL_SpSelectQuery";
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.dataSetReport1 = new DataSetReport();
      this.dataSetReport1.BeginInit();
      this.TxtSuchen.Click += new EventHandler(this.TxtSuchen_Click);
      this.BtnNeu.Click += new EventHandler(this.BtnNeu_Click);
      this.BtnIndietro.Click += new EventHandler(this.BtnIndietro_Click);
      this.DataGridQuery.ItemCommand += new DataGridCommandEventHandler(this.DataGridUtenti_ItemCommand);
      this.DataGridQuery.ItemDataBound += new DataGridItemEventHandler(this.DataGridUtenti_ItemDataBound);
      this.dataSetReport1.DataSetName = "DataSetReport";
      this.dataSetReport1.Locale = new CultureInfo("en-US");
      this.Load += new EventHandler(this.Page_Load);
      this.dataSetReport1.EndInit();
    }

    private void TxtSuchen_Click(object sender, EventArgs e)
    {
      ((DefaultReport) this.Page).VisCampiVisible = false;
      ((DefaultReport) this.Page).IdQuery = 0;
      this.BindDataGrid();
    }

    private void DataGridUtenti_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (e.CommandName == "Delete")
      {
        string[] ControlParamName = (string[]) null;
        this.ControlloDatagrid.ItemCommand(source, e, ControlParamName, "@IdSchema", "SpDeleteSchema", e.CommandName, (DataManager) new Query());
        this.BindDataGrid();
        ((DefaultReport) this.Page).VisCampiVisible = false;
        ((DefaultReport) this.Page).IdQuery = 0;
      }
      if (!(e.CommandName == "Edit"))
        return;
      string[] strArray = e.CommandArgument.ToString().Split(Convert.ToChar(","));
      string str1 = strArray[0];
      string str2 = strArray[1];
      this.Response.Redirect("AssociaUtenti.aspx?id=" + (object) Convert.ToInt32(str1) + "&schema=" + str2);
    }

    private void DataGridUtenti_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ImageButton control1 = (ImageButton) e.Item.FindControl("ImageDelete");
      ImageButton control2 = (ImageButton) e.Item.FindControl("ImageUpdate");
      Label control3 = (Label) e.Item.FindControl("LabelUsername");
      control2.Visible = this.Context.User.IsInRole("amministratori");
      if (this.Context.User.Identity.Name.ToUpper() == control3.Text.ToUpper() || this.Context.User.IsInRole("amministratori"))
      {
        control1.Visible = true;
        control1.Attributes.Add("onclick", "return ConfermaEliminazione('selezionato')");
      }
      else
        control1.Visible = false;
    }

    protected void lbt_Click(object sender, EventArgs e)
    {
      ((DefaultReport) this.Page).VisCampiVisible = true;
      ((DefaultReport) this.Page).IdQuery = Convert.ToInt32(((LinkButton) sender).CommandArgument);
    }

    private void BtnNeu_Click(object sender, EventArgs e)
    {
      ((DefaultReport) this.Page).VisCampiVisible = true;
      ((DefaultReport) this.Page).IdQuery = 0;
    }

    private void BtnIndietro_Click(object sender, EventArgs e) => this.Server.Transfer("SelectSchema.aspx");
  }
}
