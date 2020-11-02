// Decompiled with JetBrains decompiler
// Type: TheSite.CommonPage.ListaStanze
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
  public class ListaStanze : Page
  {
    protected HyperLink HyperLink1;
    protected DataGrid MyDataGrid1;
    protected HyperLink HyperLinkChiudi2;
    protected GridTitle GridTitle1;

    private void Page_Load(object sender, EventArgs e)
    {
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      if (!this.IsPostBack)
      {
        this.idUsercontrol1 = this.Request.QueryString["idUsercontrol1"] == null ? string.Empty : this.Request.QueryString["idUsercontrol1"];
        this.blid = this.Request.QueryString["blid"] == null ? string.Empty : this.Request.QueryString["blid"];
        this.codstanza = this.Request.QueryString["codstanza"] == null ? string.Empty : this.Request.QueryString["codstanza"];
        if (this.Request.QueryString["piano"] != null)
        {
          if (this.Request.QueryString["piano"].IndexOf(' ') == -1)
            this.piano = this.Request.QueryString["piano"];
          else
            this.piano = this.Request.QueryString["piano"].Split(Convert.ToChar(" "))[0];
        }
        else
          this.piano = string.Empty;
        this.Execute(true);
      }
      string script = "<script language=JavaScript> var idUsercontrol1='" + this.idUsercontrol1 + "'" + "<" + "/" + "script>";
      if (!this.IsClientScriptBlockRegistered("clientScriptst"))
        this.RegisterClientScriptBlock("clientScriptst", script);
      this.GridTitle1.DescriptionTitle = "Lista Stanza/Reparto";
    }

    private void Execute(bool reset)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_ControlsCollection CollezioneControlli1 = this.getParam();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pageindex");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(16);
      ((ParameterObject) sObject1).set_Value((object) (this.MyDataGrid1.CurrentPageIndex + 1));
      CollezioneControlli1.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pagesize");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(17);
      ((ParameterObject) sObject2).set_Value((object) this.MyDataGrid1.PageSize);
      CollezioneControlli1.Add(sObject2);
      Apparecchiature apparecchiature = new Apparecchiature(this.Context.User.Identity.Name);
      this.MyDataGrid1.DataSource = (object) apparecchiature.RicercaStanze(CollezioneControlli1);
      if (reset)
      {
        ((CollectionBase) CollezioneControlli1).Clear();
        S_ControlsCollection CollezioneControlli2 = this.getParam();
        this.GridTitle1.NumeroRecords = apparecchiature.RicercaStanzeCount(CollezioneControlli2).ToString();
      }
      this.MyDataGrid1.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.MyDataGrid1.DataBind();
    }

    public S_ControlsCollection getParam()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Id_bl");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject1).set_Value((object) this.blid);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_piani");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject2).set_Value((object) (this.piano == "" ? 0 : int.Parse(this.piano)));
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_stanza");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject3).set_Value((object) this.codstanza);
      controlsCollection.Add(sObject3);
      return controlsCollection;
    }

    private string idUsercontrol1
    {
      get => (string) this.ViewState["s_idUsercontrol"];
      set => this.ViewState["s_idUsercontrol"] = (object) value;
    }

    private string codstanza
    {
      get => (string) this.ViewState["s_codstanza"];
      set => this.ViewState["s_codstanza"] = (object) value;
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

    private string piano
    {
      get => (string) this.ViewState["s_piano"];
      set => this.ViewState["s_piano"] = (object) value;
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
      ((HtmlAnchor) e.Item.FindControl("hrefset")).HRef = "javascript:Popolast('" + HttpUtility.HtmlDecode(e.Item.Cells[1].Text).Replace("\"", "\\\"") + "','" + e.Item.Cells[4].Text + "');";
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
