// Decompiled with JetBrains decompiler
// Type: TheSite.CommonPage.ListaMatricole
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
using TheSite.Classi.AnagrafeImpianti;
using TheSite.WebControls;

namespace TheSite.CommonPage
{
  public class ListaMatricole : Page
  {
    protected HyperLink HyperLink1;
    protected HyperLink Hyperlink2;
    protected DataGrid DataGrid1;
    protected GridTitle GridTitle1;

    private void Page_Load(object sender, EventArgs e)
    {
      if (!this.IsPostBack)
      {
        this.idric = this.Request.QueryString["idric"] == null ? string.Empty : this.Request.QueryString["idric"];
        this.idmodulo = this.Request.QueryString["idmodulo"] == null ? string.Empty : this.Request.QueryString["idmodulo"];
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

    private void Execute()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      Certificati certificati = new Certificati(this.Context.User.Identity.Name);
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("P_matricola");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Size(250);
      ((ParameterObject) sObject).set_Value((object) this.idric);
      CollezioneControlli.Add(sObject);
      DataSet dataMatricolole = certificati.GetDataMatricolole(CollezioneControlli);
      this.DataGrid1.DataSource = (object) dataMatricolole;
      this.GridTitle1.NumeroRecords = dataMatricolole.Tables[0].Rows.Count == 0 ? "0" : dataMatricolole.Tables[0].Rows.Count.ToString();
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
