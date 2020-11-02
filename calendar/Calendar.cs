// Decompiled with JetBrains decompiler
// Type: TheSite.calendar.Calendar
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheSite.calendar
{
  public class Calendar : UserControl
  {
    protected TextBox txtDate;

    private void Page_Load(object sender, EventArgs e)
    {
      string script1 = "<link rel=\"stylesheet\" href=\"../calendar/dhtmlgoodies_calendar.css\" media=\"screen\" />";
      string script2 = "<script type=\"text/javascript\" src=\"../calendar/dhtmlgoodies_calendar.js\"></script>";
      if (!this.Page.IsStartupScriptRegistered("pcalen"))
        this.Page.RegisterStartupScript("pcalen", script1);
      if (this.Page.IsStartupScriptRegistered("pjcalen"))
        return;
      this.Page.RegisterStartupScript("pjcalen", script2);
    }

    public TextBox Date => this.txtDate;

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
