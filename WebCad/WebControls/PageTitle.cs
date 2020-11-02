// Decompiled with JetBrains decompiler
// Type: WebCad.WebControls.PageTitle
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;

namespace WebCad.WebControls
{
  public class PageTitle : UserControl
  {
    private string _Title = string.Empty;
    protected HtmlGenericControl spanMainTitle;
    protected HtmlGenericControl spanTitle;
    protected HyperLink lblHome;
    protected Label lblOperatore;
    protected HtmlAnchor logoutlinnk;
    protected PlaceHolder PlaceHolder1;
    private string _MainTitle = Helper.GetApplicationName();

    private void Page_Load(object sender, EventArgs e)
    {
      this.spanMainTitle.InnerText = this.MainTitle;
      this.spanTitle.InnerText = this.Title;
      if (HttpContext.Current.User.Identity.Name != null)
        this.lblOperatore.Text = "Operatore <b>" + HttpContext.Current.User.Identity.Name + "</b>";
      this.lblHome.Text = "<b> Home Page </b>";
      this.lblHome.NavigateUrl = "..\\MainContent.aspx";
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    public string MainTitle
    {
      get => this._MainTitle;
      set => this._MainTitle = value;
    }

    public string Title
    {
      get => this._Title;
      set => this._Title = value;
    }

    public bool VisibleLogut
    {
      get => this.PlaceHolder1.Visible;
      set => this.PlaceHolder1.Visible = value;
    }
  }
}
