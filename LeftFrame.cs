// Decompiled with JetBrains decompiler
// Type: TheSite.LeftFrame
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using arTreeMenu;
using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using TheSite.Classi;

namespace TheSite
{
  public class LeftFrame : Page
  {
    protected TreeMenu TreeMenu1;
    protected Label Label5;
    protected TextBox TxtOraServer;
    protected Label Label6;
    protected TextBox TxtMinutiServer;
    protected Label Label7;
    protected TextBox TxtSecondiServer;
    protected Label Label8;
    protected TextBox TxtMSecondiServer;
    protected Label Label1;
    protected TextBox TxtOra2;
    protected Label Label2;
    protected TextBox TxtMinuti2;
    protected Label Label3;
    protected TextBox TxtSecondi2;
    protected Label Label4;
    protected TextBox TxtMSecondi2;
    private SiteMenu _Menu;

    private void Page_Load(object sender, EventArgs e)
    {
      XmlDocument xmlDocument = new XmlDocument();
      this._Menu = new SiteMenu();
      string url = "";
      if (this.Request.QueryString["VarApp"] != null)
        url = "&VarApp=" + this.Request.QueryString["VarApp"];
      StringWriter menu = this._Menu.GetMenu(url);
      xmlDocument.LoadXml(menu.ToString());
      this.TreeMenu1.set_DataSource((object) xmlDocument);
      ((Control) this.TreeMenu1).DataBind();
      if (this.Request.QueryString["VarApp"] == null)
        return;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<script language=\"javascript\">\n");
      if (this.Context.User.IsInRole("callcenter"))
        stringBuilder.Append("change('_ctl0Item000')");
      else
        stringBuilder.Append("change('_ctl0Item001')");
      stringBuilder.Append("</script>");
      this.Page.RegisterStartupScript("loc", stringBuilder.ToString());
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
