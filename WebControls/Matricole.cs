// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.Matricole
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Web.UI;
using TheSite.Classi;

namespace TheSite.WebControls
{
  public class Matricole : UserControl
  {
    protected S_TextBox txtmatricola;
    protected S_Button S_btricerca;
    public string idTextRicMat = string.Empty;
    public string idModuloMat = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteJavaScript.ShowFrameMatricole(this.Page, 1);
      this.idTextRicMat = ((Control) this.txtmatricola).ClientID;
      this.idModuloMat = this.ClientID;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    public S_TextBox Matricola => this.txtmatricola;
  }
}
