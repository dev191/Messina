// Decompiled with JetBrains decompiler
// Type: WebCad._Default
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;

namespace WebCad
{
  public class _Default : Page
  {
    protected string UrlParams;
    protected string FromPaginaCreazioneRdl = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.Request["FromPaginaApprovaEmettiRdl"] != null)
        this.UrlParams = "?BlId=" + this.Request["BlId"] + "&IdPiano=" + this.Request["IdPiano"] + "&IdServizio=" + this.Request["IdServizio"] + "&Planimetria=" + this.Request["Planimetria"] + "&FromPaginaApprovaEmettiRdl=" + this.Request["FromPaginaApprovaEmettiRdl"];
      if (this.Request["FromPaginaCreazioneRdl"] != null)
        this.UrlParams = "?BlId=" + this.Request["BlId"] + "&IdPiano=" + this.Request["IdPiano"] + "&IdServizio=" + this.Request["IdServizio"] + "&FromPaginaCreazioneRdl=" + this.Request["FromPaginaCreazioneRdl"];
      this.Session["parametri"] = (object) null;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
