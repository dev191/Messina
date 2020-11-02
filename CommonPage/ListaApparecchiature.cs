// Decompiled with JetBrains decompiler
// Type: TheSite.CommonPage.ListaApparecchiature
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
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.WebControls;

namespace TheSite.CommonPage
{
  public class ListaApparecchiature : Page
  {
    protected HyperLink HyperLinkChiudi2;
    protected DataGrid MyDataGrid1;
    protected HyperLink HyperLink1;
    protected GridTitle GridTitle1;

    private void Page_Load(object sender, EventArgs e)
    {
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      if (!this.IsPostBack)
      {
        this.idUsercontrol = this.Request.QueryString["idUsercontrol"] == null ? string.Empty : this.Request.QueryString["idUsercontrol"];
        this.codapp = this.Request.QueryString["codapp"] == null ? string.Empty : this.Request.QueryString["codapp"];
        this.blid = this.Request.QueryString["blid"] == null ? string.Empty : this.Request.QueryString["blid"];
        this.lettura = this.Request.QueryString["lettura"] == null ? string.Empty : this.Request.QueryString["lettura"];
        this.campus = this.Request.QueryString["campus"] == null ? string.Empty : this.Request.QueryString["campus"];
        this.servizioid = this.Request.QueryString["servizioid"] == null ? string.Empty : this.Request.QueryString["servizioid"];
        this.appaid = this.Request.QueryString["appaid"] == null ? string.Empty : this.Request.QueryString["appaid"];
        this.piano = this.Request.QueryString["piano"] == null ? string.Empty : this.Request.QueryString["piano"];
        this.stanza = this.Request.QueryString["stanza"] == null ? string.Empty : this.Request.QueryString["stanza"];
        this.dismissione = this.Request.QueryString["dismissione"];
        this.Execute(true);
      }
      string script = "<script language=JavaScript> var idUsercontrol='" + this.idUsercontrol + "'" + "<" + "/" + "script>";
      if (this.IsClientScriptBlockRegistered("clientScript"))
        return;
      this.RegisterClientScriptBlock("clientScript", script);
    }

    private string idUsercontrol
    {
      get => (string) this.ViewState["s_idUsercontrol"];
      set => this.ViewState["s_idUsercontrol"] = (object) value;
    }

    private string codapp
    {
      get => (string) this.ViewState["s_codapp"];
      set => this.ViewState["s_codapp"] = (object) value;
    }

    private string blid
    {
      get => (string) this.ViewState["s_blid"];
      set => this.ViewState["s_blid"] = (object) value;
    }

    private string lettura
    {
      get => (string) this.ViewState[nameof (lettura)];
      set => this.ViewState[nameof (lettura)] = (object) value;
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

    private string appaid
    {
      get => (string) this.ViewState["s_appaid"];
      set => this.ViewState["s_appaid"] = (object) value;
    }

    private string dismissione
    {
      get => (string) this.ViewState["s_dismissione"];
      set => this.ViewState["s_dismissione"] = (object) value;
    }

    private string piano
    {
      get => (string) this.ViewState["s_piano"];
      set => this.ViewState["s_piano"] = (object) value;
    }

    private string stanza
    {
      get => (string) this.ViewState["s_stanza"];
      set => this.ViewState["s_stanza"] = (object) value;
    }

    private S_ControlsCollection GetControl()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject1).set_Value((object) this.blid);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_campus");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) this.campus);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_Servizio");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject3).set_Value((object) (this.servizioid == string.Empty ? 0 : int.Parse(this.servizioid)));
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_eqstdid");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(8);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject4).set_Value((object) (this.appaid == string.Empty ? 0 : int.Parse(this.appaid)));
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_eq_id");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject5).set_Size(50);
      ((ParameterObject) sObject5).set_Value((object) this.codapp);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_piano");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject6).set_Value((object) (this.piano == "" ? 0 : int.Parse(this.piano)));
      controlsCollection.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_stanza");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject7).set_Value((object) (this.stanza == "" ? 0 : int.Parse(this.stanza)));
      controlsCollection.Add(sObject7);
      return controlsCollection;
    }

    private void Execute(bool reset)
    {
      S_ControlsCollection control1 = this.GetControl();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pageindex");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) control1).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) (this.MyDataGrid1.CurrentPageIndex + 1));
      control1.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pagesize");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) control1).Count + 1);
      ((ParameterObject) sObject2).set_Value((object) this.MyDataGrid1.PageSize);
      control1.Add(sObject2);
      DataSet dataSet;
      if (this.lettura == "")
      {
        Apparecchiature apparecchiature = new Apparecchiature(this.Context.User.Identity.Name);
        dataSet = apparecchiature.RicercaApparecchiaturaPS(control1);
        if (reset)
        {
          S_ControlsCollection control2 = this.GetControl();
          this.GridTitle1.NumeroRecords = apparecchiature.RicercaApparecchiaturaPSCount(control2).ToString();
        }
      }
      else
      {
        LetturaContatori letturaContatori = new LetturaContatori(this.Context.User.Identity.Name);
        dataSet = letturaContatori.RicercaApparecchiaturaPSPaging(control1);
        if (reset)
        {
          S_ControlsCollection control2 = this.GetControl();
          this.GridTitle1.NumeroRecords = letturaContatori.RicercaApparecchiaturaPSCount(control2).ToString();
        }
      }
      this.MyDataGrid1.DataSource = (object) dataSet.Tables[0];
      this.MyDataGrid1.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
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
      this.Execute(false);
    }

    private void MyDataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((HtmlAnchor) e.Item.FindControl("hrefset")).HRef = "javascript:Popola('" + HttpUtility.HtmlDecode(e.Item.Cells[1].Text).Replace("\"", "\\\"") + "','" + e.Item.Cells[4].Text + "','" + e.Item.Cells[3].Text + "');";
    }
  }
}
