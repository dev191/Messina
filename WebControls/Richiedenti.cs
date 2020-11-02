// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.Richiedenti
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi.ManOrdinaria;

namespace TheSite.WebControls
{
  public class Richiedenti : UserControl
  {
    protected LinkButton lnkChiudi;
    protected S_TextBox txtRichiedente;
    protected Panel RichiedenteShowInfo;
    protected DataGrid DataGridRichiedente;
    protected Button cmdRichiedente;
    public string idtxtRichiedente = string.Empty;

    private void Page_Load(object sender, EventArgs e) => this.idtxtRichiedente = ((Control) this.txtRichiedente).ClientID;

    public S_TextBox s_Richiedente => this.txtRichiedente;

    public string NomeCompleto => ((TextBox) this.txtRichiedente).Text;

    public string NomePannello => this.RichiedenteShowInfo.ClientID;

    public string Apici(object s) => s.ToString().Replace("'", "`");

    private void lnkChiudi_Click(object sender, EventArgs e)
    {
      this.DataGridRichiedente.CurrentPageIndex = 0;
      this.RichiedenteShowInfo.Visible = false;
    }

    private void DataGridRichiedente_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRichiedente.CurrentPageIndex = e.NewPageIndex;
      this.RicercaRichiedenti();
    }

    private void cmdRichiedente_Click(object sender, EventArgs e)
    {
      this.DataGridRichiedente.CurrentPageIndex = 0;
      this.RicercaRichiedenti();
    }

    private void RicercaRichiedenti()
    {
      string Progetto = "";
      if (this.Request.QueryString["VarApp"] != null)
        Progetto = this.Request.QueryString["VarApp"];
      string str1 = "<script language=\"javascript\">\n";
      string str2 = "</script>\n";
      Richiesta richiesta = new Richiesta();
      this.RichiedenteShowInfo.Visible = true;
      this.DataGridRichiedente.DataSource = (object) richiesta.GetRichiedenti(this.NomeCompleto, "", Progetto, "");
      this.DataGridRichiedente.DataBind();
      this.Page.RegisterStartupScript("script_richiedente", str1 + "RichiedentiSetVisible(true, '" + this.RichiedenteShowInfo.ClientID + "');" + str2);
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.cmdRichiedente.Click += new EventHandler(this.cmdRichiedente_Click);
      this.lnkChiudi.Click += new EventHandler(this.lnkChiudi_Click);
      this.DataGridRichiedente.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRichiedente_PageIndexChanged);
      this.Load += new EventHandler(this.Page_Load);
    }
  }
}
