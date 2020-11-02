// Decompiled with JetBrains decompiler
// Type: WebCad.RedirectPages.RedirectSchedaEq
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Collections;
using System.Web.UI;

namespace WebCad.RedirectPages
{
  public class RedirectSchedaEq : Page
  {
    private void Page_Load(object sender, EventArgs e)
    {
      string str = this.Request["id_eq"];
      Hashtable hashtable = new Hashtable();
      if (this.Session["DatiList"] != null)
        this.Session.Remove("DatiList");
      hashtable.Add((object) str, (object) str);
      this.Session.Add("DatiList", (object) hashtable);
      this.Response.Redirect("../../ShedeEq/VisualizzaSchedaHtml.aspx?FromWebCad=true");
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
