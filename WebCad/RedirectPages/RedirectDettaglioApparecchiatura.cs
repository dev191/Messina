﻿// Decompiled with JetBrains decompiler
// Type: WebCad.RedirectPages.RedirectDettaglioApparecchiatura
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;

namespace WebCad.RedirectPages
{
  public class RedirectDettaglioApparecchiatura : Page
  {
    private void Page_Load(object sender, EventArgs e) => this.Response.Redirect("../../AnagrafeImpianti/SchedaApparecchiatura.aspx?eq_id=" + this.Request["eq_id"]);

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
