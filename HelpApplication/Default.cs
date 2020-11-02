// Decompiled with JetBrains decompiler
// Type: HelpApplication.Default
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;

namespace HelpApplication
{
  public class Default : Page
  {
    public string DefaultPage = "MainContent.aspx";
    public string LeftPage = "LeftFrame.aspx";

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.Request.QueryString["page"] != null)
      {
        Default @default = this;
        @default.LeftPage = @default.LeftPage + "?page=" + this.Request.QueryString["page"];
      }
      if (this.Request.QueryString["page"] == null)
        return;
      this.DefaultPage = "Help/" + this.Request.QueryString["page"].Replace("aspx", "htm");
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
