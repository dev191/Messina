// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.Fascicolo
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Web.UI;
using TheSite.Classi;

namespace TheSite.WebControls
{
  public class Fascicolo : UserControl
  {
    protected S_TextBox txtfascicolo;
    public string idTextRicFas = string.Empty;
    public string idModuloFas = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteJavaScript.ShowFrameFascicolo(this.Page, 1);
      this.idTextRicFas = ((Control) this.txtfascicolo).ClientID;
      this.idModuloFas = this.ClientID;
    }

    public S_TextBox TxtFascicolo => this.txtfascicolo;

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
