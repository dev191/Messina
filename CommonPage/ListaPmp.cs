// Decompiled with JetBrains decompiler
// Type: TheSite.CommonPage.ListaPmp
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi.ManProgrammata;
using TheSite.WebControls;

namespace TheSite.CommonPage
{
  public class ListaPmp : Page
  {
    protected HyperLink HyperLink1;
    protected DataGrid DataGrid1;
    protected HyperLink Hyperlink2;
    protected GridTitle GridTitle1;

    private void Page_Load(object sender, EventArgs e)
    {
      if (!this.IsPostBack)
      {
        this.idric = this.Request.QueryString["idric"] == null ? string.Empty : this.Request.QueryString["idric"];
        this.idmodulo = this.Request.QueryString["idmodulo"] == null ? string.Empty : this.Request.QueryString["idmodulo"];
        this.idEqStd = this.Request.QueryString["ideqstd"] == null || !(this.Request.QueryString["ideqstd"].Trim() != "") ? 0 : int.Parse(this.Request.QueryString["ideqstd"]);
        this.idServizio = this.Request.QueryString["idservizio"] == null || !(this.Request.QueryString["idservizio"].Trim() != "") ? 0 : int.Parse(this.Request.QueryString["idservizio"]);
        this.Execute();
      }
      string script = "<script language=JavaScript> var idmodulo='" + this.idmodulo + "'" + "<" + "/" + "script>";
      if (!this.IsClientScriptBlockRegistered("clientScriptmatricola"))
        this.RegisterClientScriptBlock("clientScriptmatricola", script);
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
    }

    private string idmodulo
    {
      get => (string) this.ViewState["s_idmodulo"];
      set => this.ViewState["s_idmodulo"] = (object) value;
    }

    private string idric
    {
      get => (string) this.ViewState["s_Idric"];
      set => this.ViewState["s_Idric"] = (object) value;
    }

    private int idEqStd
    {
      get => (int) this.ViewState["s_idEqStd"];
      set => this.ViewState["s_idEqStd"] = (object) value;
    }

    private int idServizio
    {
      get => (int) this.ViewState["s_idServizio"];
      set => this.ViewState["s_idServizio"] = (object) value;
    }

    private void Execute()
    {
      ProcAndSteps procAndSteps = new ProcAndSteps();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(8);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) this.idric);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_idEqst");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(8);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) this.idEqStd);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_idServizio");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(8);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) this.idServizio);
      CollezioneControlli.Add(sObject3);
      DataSet dataSet = procAndSteps.GetAllPMP(CollezioneControlli).Copy();
      this.DataGrid1.DataSource = (object) dataSet;
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count == 0 ? "0" : dataSet.Tables[0].Rows.Count.ToString();
      this.DataGrid1.DataBind();
    }

    private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.Execute();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.Load += new EventHandler(this.Page_Load);
      this.DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
    }
  }
}
