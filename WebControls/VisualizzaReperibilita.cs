// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.VisualizzaReperibilita
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
  public class VisualizzaReperibilita : UserControl
  {
    public string idTextCod;
    protected HtmlInputButton btsCodice;
    protected TextBox txtBL_ID;

    private void Page_Load(object sender, EventArgs e)
    {
      this.idTextCod = this.txtBL_ID.ClientID;
      this.btsCodice.Attributes.Add("onclick", "ShowFrameRep('" + this.idTextCod + "','bl_id',event);");
      SiteJavaScript.ShowFrameReperibili(this.Page, 1);
      this.btsCodice.CausesValidation = false;
      int num = this.Page.IsPostBack ? 1 : 0;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    public string TxtID_BL
    {
      set => this.txtBL_ID.Text = value;
    }
  }
}
