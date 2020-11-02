// Decompiled with JetBrains decompiler
// Type: TheSite.CostiOperativi.CostiOperativi
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using MyCollection;
using System;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;

namespace TheSite.CostiOperativi
{
  public class CostiOperativi : Page
  {
    protected Button BntIndietro;
    public SiteModule _SiteModule;
    private bool IsEditable = false;

    private void Page_Load(object sender, EventArgs e)
    {
      this._SiteModule = new SiteModule("../CostiOperativi/CostiOperativi.aspx");
      this.IsEditable = this._SiteModule.IsEditable;
      if (this.Page.IsPostBack)
        return;
      PropertyInfo property = this.Context.Handler.GetType().GetProperty("_Contenitore");
      if (property == null)
        return;
      this.ViewState.Add("mioContenitore", property.GetValue((object) this.Context.Handler, (object[]) null));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.BntIndietro.Click += new EventHandler(this.BntIndietro_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void BntIndietro_Click(object sender, EventArgs e) => this.Server.Transfer("../ManutenzioneCorrettiva/SfogliaRdlPaging.aspx");

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();
  }
}
