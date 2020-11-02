// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorretiva.ReportDettaglioPresunto
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorretiva
{
  public class ReportDettaglioPresunto : Page
  {
    protected Repeater repeater1;
    protected Repeater repeater2;
    protected PageTitle PageTitle1;
    protected S_Label lblsAnno;
    protected S_Label lblsTipoIntervento;
    public string anno = string.Empty;
    public string tipointervento_id = string.Empty;
    public string TipoInterventoDesc = string.Empty;
    protected HtmlTable TblMessaggio;
    public int colspan = 5;

    private void Page_Load(object sender, EventArgs e)
    {
      this.PageTitle1.VisibleLogut = false;
      if (this.IsPostBack)
        return;
      this.anno = this.Request.QueryString["anno"].ToString();
      this.tipointervento_id = this.Request.QueryString["tipointervento"].ToString();
      this.TipoInterventoDesc = this.Request.QueryString["TipoInterventoDesc"].ToString();
      if (this.Request.QueryString["excel"].ToString() == "true")
      {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Dettaglio.xls");
        HttpContext.Current.Response.Charset = "UTF-8";
      }
      if (this.Request.QueryString["descrizione"].ToString() == "false")
        --this.colspan;
      if (this.Request.QueryString["servizio"].ToString() == "false")
        --this.colspan;
      this.Execute();
    }

    private void Execute()
    {
      TheSite.Classi.ManStraordinaria.Report report = new TheSite.Classi.ManStraordinaria.Report();
      DataSet datiDettaglio = report.GetDatiDettaglio((int) short.Parse(this.tipointervento_id), (int) short.Parse(this.anno), "Presunto");
      if (datiDettaglio.Tables[0].Rows.Count > 0)
      {
        this.TblMessaggio.Visible = false;
        this.repeater1.DataSource = (object) datiDettaglio;
        this.repeater1.DataBind();
        this.repeater2.DataSource = (object) report.GetDatiTotaliDettaglio((int) short.Parse(this.tipointervento_id), (int) short.Parse(this.anno), "Presunto");
        this.repeater2.DataBind();
      }
      else
        this.TblMessaggio.Visible = true;
    }

    public string Formatta(string importo)
    {
      if (importo == string.Empty)
        importo = "0";
      importo = double.Parse(importo.ToString()).ToString("C");
      return importo.Replace("€", "&euro;");
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
