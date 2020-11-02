// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.CollapseDiv
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TheSite.WebControls
{
  public class CollapseDiv : UserControl
  {
    protected ImageButton imgSu;
    protected ImageButton imgGiu;
    protected Button Button1;
    protected HtmlGenericControl divCollapse;

    private void Page_Load(object sender, EventArgs e)
    {
      string script = "<script language=JavaScript> function EspandiRitrai() {" + "var ctrl=document.getElementById(\"" + this.divCollapse.ClientID + "\").style;\n" + "ctrl.display = (ctrl.display == 'none')?'block':'none';\n" + "}<" + "/" + "script>";
      if (!this.Page.IsStartupScriptRegistered("Startup"))
        this.Page.RegisterStartupScript("Startup", script);
      if (this.Page.IsPostBack)
        return;
      this.imgSu.Attributes.Add("onClick", "EspandiRitrai");
      this.imgGiu.Attributes.Add("onClick", "EspandiRitrai");
      this.imgGiu.Visible = false;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.imgSu.Click += new ImageClickEventHandler(this.imgSu_Click);
      this.imgGiu.Click += new ImageClickEventHandler(this.imgGiu_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void imgSu_Click(object sender, ImageClickEventArgs e)
    {
      this.Page.FindControl("divCollapse");
      this.divCollapse.Style.Add("display", "block");
      this.imgGiu.Visible = true;
      this.imgSu.Visible = false;
    }

    private void imgGiu_Click(object sender, ImageClickEventArgs e)
    {
      this.Page.FindControl("divCollapse");
      this.divCollapse.Style.Add("display", "none");
      this.imgSu.Visible = true;
      this.imgGiu.Visible = false;
    }
  }
}
