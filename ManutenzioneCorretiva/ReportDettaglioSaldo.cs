// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorretiva.ReportDettaglioSaldo
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
  public class ReportDettaglioSaldo : Page
  {
    protected Repeater repeater1;
    protected PageTitle PageTitle1;
    protected S_Label lblsAnno;
    protected S_Label lblsTipoIntervento;
    public string anno = string.Empty;
    public string tipointervento_id = string.Empty;
    public string TipoInterventoDesc = string.Empty;
    public string Saldo = string.Empty;
    public string SaldoIcrementale = string.Empty;
    public string stileServizio = string.Empty;
    public string stileDescrizione = string.Empty;
    private double appoSaldo = 0.0;
    protected HtmlTable TblMessaggio;

    private void Page_Load(object sender, EventArgs e)
    {
      this.PageTitle1.VisibleLogut = false;
      if (this.IsPostBack)
        return;
      this.anno = this.Request.QueryString["anno"].ToString();
      this.tipointervento_id = this.Request.QueryString["tipointervento"].ToString();
      this.TipoInterventoDesc = this.Request.QueryString["TipoInterventoDesc"].ToString();
      this.appoSaldo = double.Parse(this.Request.QueryString["Saldo"].ToString().Replace("€", ""));
      if (this.Request.QueryString["excel"].ToString() == "true")
      {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Dettaglio.xls");
        HttpContext.Current.Response.Charset = "UTF-8";
      }
      this.Execute();
    }

    private void Execute()
    {
      DataSet datiDettaglioSaldo = new TheSite.Classi.ManStraordinaria.Report().GetDatiDettaglioSaldo((int) short.Parse(this.tipointervento_id), (int) short.Parse(this.anno));
      if (datiDettaglioSaldo.Tables[0].Rows.Count > 0)
      {
        this.TblMessaggio.Visible = false;
        this.repeater1.DataSource = (object) datiDettaglioSaldo;
        this.repeater1.DataBind();
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

    private void InitializeComponent()
    {
      this.repeater1.ItemDataBound += new RepeaterItemEventHandler(this.repeater1_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      this.appoSaldo -= double.Parse((e.Item.DataItem as DataRowView)["Speso"].ToString());
      ((Label) e.Item.FindControl("lblSaldo")).Text = this.Formatta(this.appoSaldo.ToString());
    }
  }
}
