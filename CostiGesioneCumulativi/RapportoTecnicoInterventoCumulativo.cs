// Decompiled with JetBrains decompiler
// Type: TheSite.CostiGesioneCumulativi.RapportoTecnicoInterventoCumulativo
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheSite.CostiGesioneCumulativi
{
  public class RapportoTecnicoInterventoCumulativo : Page
  {
    protected Literal ltlVisualizza;
    protected DataPanel DataPanelRicerca;
    protected LinkButton lnkBtnDownload;
    protected LinkButton lnkBtnRicerca;
    private string _filname;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.Request.QueryString["nome_file"] != null)
        this.filname = this.Request.QueryString["nome_file"];
      if (this.Context.Items[(object) "nome_file"] != null)
        this.filname = (string) this.Context.Items[(object) "nome_file"];
      string appSetting = ConfigurationSettings.AppSettings["DirectoryStampaCostoGestione"];
      this.Response.ClearContent();
      this.Response.ClearHeaders();
      this.Response.ContentType = "application/pdf";
      this.Response.WriteFile(this.GetFile(appSetting, this.filname.ToString()));
      this.Response.Flush();
      this.Response.Close();
    }

    private string GetFile(string PathRoot, string nomeFile) => PathRoot + nomeFile + ".pdf";

    private string filname
    {
      get => this._filname;
      set => this._filname = value;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
