// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorrettiva.VisualizzaRdlEliminare
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using MyCollection;
using System;
using System.Web.UI;

namespace TheSite.ManutenzioneCorrettiva
{
  public class VisualizzaRdlEliminare : Page
  {
    public SfogliaRdLEliminare _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is SfogliaRdLEliminare))
        return;
      this._fp = (SfogliaRdLEliminare) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
