// Decompiled with JetBrains decompiler
// Type: TheSite.CommonPage.ListaStdApparecchiature
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.WebControls;

namespace TheSite.CommonPage
{
  public class ListaStdApparecchiature : Page
  {
    protected HyperLink HyperLink1;
    protected DataGrid MyDataGrid1;
    protected HyperLink HyperLinkChiudi2;
    protected GridTitle GridTitle1;

    private string idUsercontrol
    {
      get => (string) this.ViewState["s_idUsercontrol"];
      set => this.ViewState["s_idUsercontrol"] = (object) value;
    }

    private string codStd
    {
      get => (string) this.ViewState["s_codStd"];
      set => this.ViewState["s_codStd"] = (object) value;
    }

    private string blid
    {
      get => (string) this.ViewState["s_blid"];
      set => this.ViewState["s_blid"] = (object) value;
    }

    private string campus
    {
      get => (string) this.ViewState["s_campus"];
      set => this.ViewState["s_campus"] = (object) value;
    }

    private string servizioid
    {
      get => (string) this.ViewState["s_servizioid"];
      set => this.ViewState["s_servizioid"] = (object) value;
    }

    private void Page_Load(object sender, EventArgs e)
    {
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      if (!this.IsPostBack)
      {
        this.idUsercontrol = this.Request.QueryString["idUsercontrol"] == null ? string.Empty : this.Request.QueryString["idUsercontrol"];
        this.codStd = this.Request.QueryString["codstd"] == null ? string.Empty : this.Request.QueryString["codstd"];
        this.blid = this.Request.QueryString["blid"] == null ? string.Empty : this.Request.QueryString["blid"];
        this.campus = this.Request.QueryString["campus"] == null ? string.Empty : this.Request.QueryString["campus"];
        this.servizioid = this.Request.QueryString["servizioid"] == null ? string.Empty : this.Request.QueryString["servizioid"];
        this.Execute();
      }
      string script = "<script language=JavaScript> var idUsercontrol='" + this.idUsercontrol + "'" + "<" + "/" + "script>";
      if (this.IsClientScriptBlockRegistered("clientScript"))
        return;
      this.RegisterClientScriptBlock("clientScript", script);
    }

    private void Execute()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (this.blid == null || this.blid == string.Empty)
        ((ParameterObject) sObject1).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject1).set_Value((object) this.blid);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_campus");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Size(50);
      if (this.campus == null || this.campus == string.Empty)
        ((ParameterObject) sObject2).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject2).set_Value((object) this.campus);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_Servizio");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) -1);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_eqstdid");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(8);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (this.codStd == null || this.codStd == string.Empty)
        ((ParameterObject) sObject4).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject4).set_Value((object) this.codStd);
      CollezioneControlli.Add(sObject4);
      DataSet dataSet = new Apparecchiature(this.Context.User.Identity.Name).RicercaStd(CollezioneControlli);
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count == 0 ? "0" : dataSet.Tables[0].Rows.Count.ToString();
      this.MyDataGrid1.DataSource = (object) dataSet;
      this.MyDataGrid1.DataBind();
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

    private void MyDataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.MyDataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.Execute();
    }

    private void MyDataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((HtmlAnchor) e.Item.FindControl("hrefset")).HRef = "javascript:Popola('" + HttpUtility.HtmlDecode(e.Item.Cells[1].Text).Replace("\"", "\\\"") + "','" + e.Item.Cells[3].Text + "');";
    }
  }
}
