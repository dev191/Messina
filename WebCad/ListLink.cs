// Decompiled with JetBrains decompiler
// Type: WebCad.ListLink
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebCad
{
  public class ListLink : Page
  {
    protected Repeater RepeaterLink;
    private string idLink = string.Empty;
    private Servizi _Servizi = new Servizi();

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.Request.QueryString["bl"] != null && this.Request.QueryString["corpo"] != null && (this.Request.QueryString["stanza"] != null && this.Request.QueryString["eq"] != null))
        this.BindLinkEq();
      if (this.Request.QueryString["bl"] != null && this.Request.QueryString["corpo"] != null && (this.Request.QueryString["stanza"] != null && this.Request.QueryString["eq"] == null))
        this.BindLinkStanza();
      if (this.Request.QueryString["bl"] != null && this.Request.QueryString["corpo"] != null && (this.Request.QueryString["stanza"] == null && this.Request.QueryString["eq"] == null))
        this.BindLinkCorpo();
      if (this.Request.QueryString["bl"] == null || this.Request.QueryString["corpo"] != null || (this.Request.QueryString["stanza"] != null || this.Request.QueryString["eq"] != null))
        return;
      this.BindLinkBl();
    }

    private void BindLinkEq()
    {
      this.RepeaterLink.DataSource = (object) this._Servizi.GetEQ(int.Parse(this.Request.QueryString["bl"]), 1, int.Parse(this.Request.QueryString["stanza"]), int.Parse(this.Request.QueryString["eq"])).Tables[0];
      this.RepeaterLink.DataBind();
    }

    private void BindLinkStanza()
    {
      this.RepeaterLink.DataSource = (object) this._Servizi.GetRM(int.Parse(this.Request.QueryString["bl"]), 1, int.Parse(this.Request.QueryString["stanza"])).Tables[0];
      this.RepeaterLink.DataBind();
    }

    private void BindLinkCorpo()
    {
    }

    private void BindLinkBl()
    {
      this.RepeaterLink.DataSource = (object) this._Servizi.GetBL(int.Parse(this.Request.QueryString["bl"])).Tables[0];
      this.RepeaterLink.DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.Load += new EventHandler(this.Page_Load);
      this.RepeaterLink.ItemDataBound += new RepeaterItemEventHandler(this.RepeaterLink_ItemDataBound);
    }

    private void RepeaterLink_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      DataRowView dataItem = (DataRowView) e.Item.DataItem;
      HtmlAnchor control = e.Item.FindControl("link") as HtmlAnchor;
      control.HRef = "#";
      control.Attributes.Add("onclick", "ApriEq('" + dataItem["link"].ToString() + "');");
      control.InnerText = dataItem["descrizione"].ToString();
    }
  }
}
