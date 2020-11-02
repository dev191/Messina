// Decompiled with JetBrains decompiler
// Type: StampaRapportiPdf.Pagine.VisualDWF
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StampaRapportiPdf.Pagine
{
  public class VisualDWF : Page
  {
    protected Literal ltlVisualizza;
    protected DataPanel DataPanelRicerca;
    protected LinkButton lnkBtnDownload;
    protected LinkButton lnkBtnRicerca;
    private string _filname;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["nome_file"] != null)
        this.filname = this.Request.QueryString["nome_file"];
      if (this.Context.Items[(object) "nome_file"] != null)
        this.filname = (string) this.Context.Items[(object) "nome_file"];
      this.GetFile(ConfigurationSettings.AppSettings.GetValues("DirectoryStampa")[0].ToString(), this.filname.ToString());
    }

    private void GetFile(string PathRoot, string nomeFile)
    {
      string empty = string.Empty;
      this.ltlVisualizza.Text = "<embed src=\"" + (PathRoot + nomeFile + ".pdf") + "\" height=\"100%\" width=\"100%\" " + "type=\"application/pdf\"" + "></embed>";
    }

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

    private void InitializeComponent()
    {
      this.lnkBtnDownload.Click += new EventHandler(this.lnkBtnDownload_Click);
      this.lnkBtnRicerca.Click += new EventHandler(this.lnkBtnRicerca_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void lnkBtnDownload_Click(object sender, EventArgs e) => this.Response.Redirect("Pagina_Download.aspx");

    private void lnkBtnRicerca_Click(object sender, EventArgs e) => this.Response.Redirect("Ricerca_e_Stampa.aspx");
  }
}
