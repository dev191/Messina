// Decompiled with JetBrains decompiler
// Type: TheSite.AslMobile.WebForm1
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheSite.AslMobile
{
  public class WebForm1 : Page
  {
    protected DropDownList DropDownList1;
    protected DropDownList DropDownList2;
    protected DataGrid MyDataGrid1;
    protected DropDownList DropDownList3;

    private void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
