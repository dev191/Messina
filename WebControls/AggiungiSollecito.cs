// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.AggiungiSollecito
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;

namespace TheSite.WebControls
{
  public class AggiungiSollecito : UserControl
  {
    public string idTextCod;
    protected TextBox txtWR_ID;
    protected HtmlInputButton btsCodice;
    private string _Progetto = "";

    private void Page_Load(object sender, EventArgs e)
    {
      this.idTextCod = this.txtWR_ID.ClientID;
      this.btsCodice.Attributes.Add("onclick", "ShowFrameAddSoll('" + this.idTextCod + "'," + ("'prj=" + this.Progetto + "&idric'") + ",event);");
      SiteJavaScript.ShowFrameSollecito(this.Page, 1);
      this.btsCodice.CausesValidation = false;
      int num = this.Page.IsPostBack ? 1 : 0;
    }

    public string Progetto
    {
      get => this._Progetto;
      set => this._Progetto = value;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    public string TxtID_WR
    {
      set => this.txtWR_ID.Text = value;
    }
  }
}
