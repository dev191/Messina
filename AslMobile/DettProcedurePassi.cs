// Decompiled with JetBrains decompiler
// Type: TheSite.AslMobile.DettProcedurePassi
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Data.OracleClient;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using TheSite.AslMobile.Class;

namespace TheSite.AslMobile
{
  public class DettProcedurePassi : MobilePage
  {
    protected System.Web.UI.MobileControls.Panel Panel1;
    protected DeviceSpecific DeviceSpecific1;
    protected Form Form1;
    protected string PMP = "";
    private DataGrid DataGridRicerca;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.Page.IsPostBack)
        return;
      this.PMP = this.Request.Params["pmp"];
      this.GetDataGrid();
    }

    protected void OnIndietro(object sender, EventArgs e)
    {
    }

    private void GetDataGrid()
    {
      this.DataGridRicerca.DataSource = (object) new ClassProcAndSteps().GetDataDett(new OracleParameterCollection()
      {
        new OracleParameter()
        {
          ParameterName = "p_ID_pmp",
          OracleType = OracleType.Int32,
          Direction = ParameterDirection.Input,
          Value = (object) this.PMP,
          Size = 50
        }
      }).Tables[0];
      this.DataGridRicerca.DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.DataGridRicerca = (DataGrid) this.Panel1.Controls[0].FindControl("Datagrid2");
      this.Load += new EventHandler(this.Page_Load);
    }
  }
}
