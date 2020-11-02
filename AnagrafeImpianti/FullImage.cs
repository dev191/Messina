// Decompiled with JetBrains decompiler
// Type: TheSite.AnagrafeImpianti.FullImage
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using TheSite.WebControls;

namespace TheSite.AnagrafeImpianti
{
  public class FullImage : Page
  {
    protected HtmlImage imgdoc;
    protected PageTitle PageTitle1;

    private void Page_Load(object sender, EventArgs e)
    {
      this.PageTitle1.VisibleLogut = false;
      if (this.IsPostBack)
        return;
      this.imgdoc.Src = "PageImage.aspx?eq_image=" + this.Request.QueryString["eq_image"] + "&urlimage=" + this.Request.QueryString["urlimage"];
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
