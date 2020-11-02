// Decompiled with JetBrains decompiler
// Type: TheSite.MainContent
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Web.UI;
using TheSite.Classi;

namespace TheSite
{
  public class MainContent : Page
  {
    public bool VisibleMap = false;
    public string FunId = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack || !this.IsMap())
        return;
      this.VisibleMap = true;
    }

    public string ImageSrc()
    {
      string str = "";
      if (this.Context.User.IsInRole("MA") && !this.Context.User.IsInRole("PA"))
        str = "Images/PagInMartino.jpg";
      if (!this.Context.User.IsInRole("MA") && this.Context.User.IsInRole("PA"))
        str = "Images/PagInPapardo.jpg";
      if (this.Context.User.IsInRole("MA") && this.Context.User.IsInRole("PA"))
        str = "Images/cofatheclogo.jpg";
      if (this.Context.User.IsInRole("AMMINISTRATORI") || this.Context.User.IsInRole("callcenter"))
        str = "Images/cofatheclogo.jpg";
      return str;
    }

    private bool IsMap()
    {
      DataSet map = new Utente(this.Context.User.Identity.Name).GetMap();
      if (map.Tables[0].Rows.Count <= 0)
        return false;
      if (map.Tables[0].Rows[0]["FUNZIONE_ID"] != DBNull.Value)
        this.FunId = map.Tables[0].Rows[0]["FUNZIONE_ID"].ToString();
      return map.Tables[0].Rows[0]["LETTURA"] != DBNull.Value && int.Parse(map.Tables[0].Rows[0]["LETTURA"].ToString()) == -1;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
