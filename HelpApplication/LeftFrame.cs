// Decompiled with JetBrains decompiler
// Type: HelpApplication.LeftFrame
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using arTreeMenu;
using System;
using System.Web.UI;

namespace HelpApplication
{
  public class LeftFrame : Page
  {
    protected TreeMenu TreeMenu1;
    private SiteMenu _Menu;

    private void Page_Load(object sender, EventArgs e)
    {
      string empty = string.Empty;
      if (this.Request.QueryString["page"] != null)
        empty = this.Request.QueryString["page"];
      this._Menu = new SiteMenu(empty, this.Context);
      this.TreeMenu1.set_DataSource((object) this._Menu.GetMenu(""));
      ((Control) this.TreeMenu1).DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
