// Decompiled with JetBrains decompiler
// Type: TheSite.CommonPage.PageCalendar
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheSite.CommonPage
{
  public class PageCalendar : Page
  {
    public DateTime d1 = DateTime.Now;
    protected HyperLink HyperLink1;
    public string namediv = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      if (!this.IsPostBack)
        this.idmodulo = this.Request.QueryString["idmodulocal"];
      this.namediv = this.Request.QueryString["namediv"];
      string script = "<script language=JavaScript>dateField= parent.document.getElementById('" + this.idmodulo + "_S_TxtDatecalendar');" + "<" + "/" + "script>";
      if (this.IsClientScriptBlockRegistered("clientScriptcalendario"))
        return;
      this.RegisterClientScriptBlock("clientScriptcalendario", script);
    }

    private string idmodulo
    {
      get => (string) this.ViewState["s_idmodulo"];
      set => this.ViewState["s_idmodulo"] = (object) value;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
