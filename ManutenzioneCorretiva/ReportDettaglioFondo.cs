// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorretiva.ReportDettaglioFondo
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorretiva
{
  public class ReportDettaglioFondo : Page
  {
    protected PageTitle PageTitle1;
    protected S_Label lblsAnno;
    protected S_Label lblsTipoIntervento;
    public string anno = string.Empty;
    public string tipointervento_id = string.Empty;
    public string TipoInterventoDesc = string.Empty;
    public string ImportoNetto = string.Empty;
    public string ImportoLordo = string.Empty;
    public string Descrizione = string.Empty;
    public string Note = string.Empty;
    protected HtmlTable TblMessaggio;

    private void Page_Load(object sender, EventArgs e)
    {
      this.PageTitle1.VisibleLogut = false;
      this.TblMessaggio.Visible = false;
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["excel"].ToString() == "true")
      {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Dettaglio.xls");
        HttpContext.Current.Response.Charset = "UTF-8";
      }
      this.Execute(this.Request.QueryString["id"].ToString());
    }

    private void Execute(string itemId)
    {
      DataSet dataSet = new TheSite.Classi.ManStraordinaria.Report().GetSingleData((int) short.Parse(itemId)).Copy();
      if (dataSet.Tables[0].Rows.Count == 1)
      {
        DataRow row = dataSet.Tables[0].Rows[0];
        if (row["Descrizione"] != DBNull.Value)
          this.Descrizione = (string) row["descrizione"];
        if (row["Note"] != DBNull.Value)
          this.Note = (string) row["Note"];
        if (row["importo_netto"] != DBNull.Value)
          this.ImportoNetto = row["importo_netto"].ToString();
        if (row["importo_lordo"] != DBNull.Value)
          this.ImportoLordo = row["importo_lordo"].ToString();
        if (row["anno"] != DBNull.Value)
          this.anno = row["anno"].ToString();
        if (row["descrizione_breve"] == DBNull.Value)
          return;
        this.TipoInterventoDesc = row["descrizione_breve"].ToString();
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
