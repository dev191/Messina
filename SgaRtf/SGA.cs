// Decompiled with JetBrains decompiler
// Type: TheSite.SgaRtf.SGA
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi.RptRtf;

namespace TheSite.SgaRtf
{
  public class SGA : Page
  {
    protected Button btnGenera;
    protected TextBox TextBox1;
    protected TextBox txtWrId;
    protected Label lblWrID;
    public string Str1;

    private void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.btnGenera.Click += new EventHandler(this.btnGenera_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnGenera_Click(object sender, EventArgs e)
    {
      string DataCreate = DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
      string str = this.Server.MapPath(this.Request.ApplicationPath + ConfigurationSettings.AppSettings["FileXlstRtfSga"]);
      new SGARTF() { FileXlst = str }.GeneraRtf(Convert.ToInt32(this.txtWrId.Text), DataCreate);
    }
  }
}
