// Decompiled with JetBrains decompiler
// Type: WebCad.CAD.CadViewer
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebCad.CAD
{
  public class CadViewer : Page
  {
    protected TextBox txtVettoreStanzeSelezionate;
    protected string UrlDwf;
    protected string RelativPath;
    protected string EseguiScriptApriPlanimetria;
    protected string Planimetria;
    protected HtmlInputHidden txtFirstTime;
    protected HtmlInputText txtUrlDwf;

    private void Page_Load(object sender, EventArgs e)
    {
      this.txtUrlDwf.Value = "../.." + ConfigurationSettings.AppSettings["DirectoryCad"];
      if (this.Page.IsPostBack || this.Request["FromPaginaApprovaEmettiRdl"] == null)
        return;
      this.Planimetria = this.Request["Planimetria"];
      this.EseguiScriptApriPlanimetria = "openFileView \"" + this.Planimetria + ".dwf\",\"true\"";
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
