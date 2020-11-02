// Decompiled with JetBrains decompiler
// Type: TheSite.AslMobile.CalendarioUserControl
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI.MobileControls;

namespace TheSite.AslMobile
{
  public abstract class CalendarioUserControl : MobileUserControl
  {
    protected Panel Panel1;
    protected DeviceSpecific DeviceSpecific1;
    public Label strData;

    private void Page_Load(object sender, EventArgs e) => ((Calendar) this.Panel1.Controls[0].FindControl("Calendar1")).SelectedDates.Clear();

    protected void Calendar_SelectionChangedDataStart(object sender, EventArgs e)
    {
      this.Panel1.Visible = false;
      this.strData.Text = ((Calendar) sender).SelectedDate.ToShortDateString();
    }

    public void setLabel(Label lbl) => this.strData = lbl;

    public void EnbledCal() => this.Panel1.Visible = true;

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.Panel1.Visible = false;
      this.Load += new EventHandler(this.Page_Load);
    }
  }
}
