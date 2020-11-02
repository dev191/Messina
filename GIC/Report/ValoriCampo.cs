// Decompiled with JetBrains decompiler
// Type: GIC.Report.ValoriCampo
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using GIC.App_Code;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GIC.Report
{
  public class ValoriCampo : BasePage
  {
    private string NomeTabella;
    protected DataGrid MyDataGrid1;
    private string NomeCampo;
    private string Valore;
    private string Tipo;
    protected int elementiTrovati;

    private void Page_Load(object sender, EventArgs e)
    {
      this.NomeTabella = this.Request.QueryString["tabella"];
      this.NomeCampo = this.Request.QueryString["campo"];
      this.Valore = this.Request.QueryString["valore"];
      this.Tipo = this.Request.QueryString["tipo"];
      this.BindDt();
    }

    private void BindDt()
    {
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pCampo");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(100);
      ((ParameterObject) sObject1).set_Value((object) this.NomeCampo);
      ((ParameterObject) sObject1).set_Index(1);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pVal");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(100);
      ((ParameterObject) sObject2).set_Value((object) this.Valore);
      ((ParameterObject) sObject2).set_Index(2);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pTipo");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(100);
      ((ParameterObject) sObject3).set_Value((object) this.Tipo);
      ((ParameterObject) sObject3).set_Index(3);
      controlsCollection.Add(sObject3);
      string str = Convert.ToString(((Hashtable) this.Session["ParametriSelectSchema"])[(object) "NomeVista"]);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("pNomeVista");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(100);
      ((ParameterObject) sObject4).set_Value((object) str);
      ((ParameterObject) sObject4).set_Index(4);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("putente");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(5);
      ((ParameterObject) sObject5).set_Value((object) HttpContext.Current.User.Identity.Name);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("io_cursor");
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject6).set_Index(6);
      controlsCollection.Add(sObject6);
      DataTable dataTable = new DataTable();
      DataTable table = oracleDataLayer.GetRows((object) controlsCollection, "IL_PACK_INTERROGAZIONI.IL_SpSelectValCampo").Copy().Tables[0];
      this.MyDataGrid1.DataSource = (object) table;
      this.MyDataGrid1.DataBind();
      this.elementiTrovati = table.Rows.Count;
    }

    private void MyDataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((HtmlControl) e.Item.FindControl("hrefset")).Attributes.Add("onclick", "Valorizza('" + ((DataRowView) e.Item.DataItem)["valore"] + "')");
    }

    private void MyDataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.MyDataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.BindDt();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.MyDataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged);
      this.MyDataGrid1.ItemDataBound += new DataGridItemEventHandler(this.MyDataGrid1_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }
  }
}
