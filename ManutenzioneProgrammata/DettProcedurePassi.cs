// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.DettProcedurePassi
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ManProgrammata;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class DettProcedurePassi : Page
  {
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    protected Label lblpmp;
    protected string PMP = "";
    private string descserv = "";
    private string std = "";

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      if (this.Page.IsPostBack)
        return;
      siteModule.GetSetting();
      DettProcedurePassi.FunId = siteModule.ModuleId;
      DettProcedurePassi.HelpLink = siteModule.HelpLink;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.PMP = this.Request.Params["pmp"];
      this.descserv = this.Request.Params["descserv"];
      this.std = this.Request.Params["std"];
      this.lblpmp.Text = "Passi per procedura: " + this.Request.Params["pmp_id"] + "   servizio:  " + this.descserv + "         Std. Apparecchiatura:  " + this.std;
      this.GetDataGrid();
    }

    private void GetDataGrid()
    {
      ProcAndSteps procAndSteps = new ProcAndSteps();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_ID_pmp");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) this.PMP);
      ((ParameterObject) sObject).set_Size(50);
      CollezioneControlli.Add(sObject);
      DataSet dataSet = procAndSteps.GetDataDett(CollezioneControlli).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
