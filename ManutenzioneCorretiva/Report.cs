// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorretiva.Report
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using S_Controls;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;

namespace TheSite.ManutenzioneCorretiva
{
  public class Report : Page
  {
    protected S_ComboBox cmbsAnno;
    protected Button BtnRicerca;
    protected S_Label lblAterFondo;
    protected S_Label lblInSqlFondo;
    protected S_Label lblRicqFondo;
    protected S_Label lblServenFondo;
    protected S_Label lblAterSpeso;
    protected S_Label lblInSqlSpeso;
    protected S_Label lblRicqSpeso;
    protected S_Label lblServenlSpeso;
    protected S_Label lblAterSaldo;
    protected S_Label lblInSqlSaldo;
    protected S_Label lblRicqSaldo;
    protected S_Label lblServenlSaldo;
    protected S_Label lblAterPresunto;
    protected S_Label lblInsqlPresunto;
    protected S_Label lblRiicqresunto;
    protected S_Label lblServenPresunto;
    protected DataPanel DataPanel3;
    protected CheckBox CheckExcel;
    protected HtmlTableCell tdfondi;
    protected CheckBox CheckDescrizione;
    protected CheckBox CheckServizio;
    protected HtmlTable TblExcel;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      Report.HelpLink = ((SiteModule) HttpContext.Current.Items[(object) "SiteModule"]).HelpLink;
      if (this.IsPostBack)
        return;
      this.CaricaAnno();
      this.TblExcel.Visible = false;
    }

    private void CaricaAnno()
    {
      DateTime.Now.Year.ToString();
      for (int index = 2000; index <= 2010; ++index)
      {
        ListItem listItem1 = new ListItem();
        ListItem listItem2 = new ListItem();
        listItem1.Text = index.ToString();
        listItem1.Value = index.ToString();
        listItem2.Text = index.ToString();
        listItem2.Value = index.ToString();
        ((ListControl) this.cmbsAnno).Items.Add(listItem2);
      }
      ((ListControl) this.cmbsAnno).SelectedValue = DateTime.Now.Year.ToString();
    }

    private void CaricaTabella()
    {
      DataSet dataSet = new TheSite.Classi.ManStraordinaria.Report().GetDatiFondo((int) short.Parse(((ListControl) this.cmbsAnno).SelectedValue)).Copy();
      if (dataSet.Tables[0].Rows.Count != 0)
      {
        this.TblExcel.Visible = true;
        Table table = new Table();
        TableRow row1 = new TableRow();
        row1.Cells.Add(new TableCell() { Text = "&nbsp;" });
        foreach (DataRow row2 in (InternalDataCollectionBase) dataSet.Tables[0].Rows)
          row1.Cells.Add(new TableCell()
          {
            Text = "<b>" + row2["descrizione_breve"].ToString() + "</b>"
          });
        TableRow row3 = new TableRow();
        TableCell cell1 = new TableCell();
        cell1.Text = "<b>Importo netto Fondo</b>";
        cell1.Attributes.Add("align", "left");
        row3.Cells.Add(cell1);
        foreach (DataRow row2 in (InternalDataCollectionBase) dataSet.Tables[0].Rows)
        {
          TableCell cell2 = new TableCell();
          cell2.Text = double.Parse(row2["IMPORTO_NETTO"].ToString()).ToString("C");
          cell2.Attributes.Add("onclick", "ApriReportFondo('" + row2["id"].ToString() + "')");
          cell2.Attributes.Add("style", "cursor:hand");
          cell2.ToolTip = "Visualizza il Report per Tipo Intervento: " + row2["descrizione_breve"].ToString();
          row3.Cells.Add(cell2);
        }
        row3.Attributes.Add("align", "right");
        TableRow row4 = new TableRow();
        TableCell cell3 = new TableCell();
        cell3.Text = "<b>Importo netto Speso</b>";
        cell3.Attributes.Add("align", "left");
        row4.Cells.Add(cell3);
        foreach (DataRow row2 in (InternalDataCollectionBase) dataSet.Tables[0].Rows)
        {
          TableCell cell2 = new TableCell();
          cell2.Text = this.CalcolaSpeso(row2["tipointervento_id"].ToString(), ((ListControl) this.cmbsAnno).SelectedValue);
          cell2.Attributes.Add("onclick", "ApriReport(cmbsAnno.value," + row2["tipointervento_id"].ToString() + ",'" + row2["descrizione_breve"].ToString() + "');");
          cell2.Attributes.Add("style", "cursor:hand");
          cell2.ToolTip = "Visualizza il Report per Tipo Intervento: " + row2["descrizione_breve"].ToString();
          row4.Cells.Add(cell2);
        }
        row4.Attributes.Add("align", "right");
        TableRow row5 = new TableRow();
        TableCell cell4 = new TableCell();
        cell4.Text = "<b>Saldo</b>";
        cell4.Attributes.Add("align", "left");
        row5.Cells.Add(cell4);
        foreach (DataRow row2 in (InternalDataCollectionBase) dataSet.Tables[0].Rows)
        {
          TableCell cell2 = new TableCell();
          Conti conti = this.CalcolaSaldo(row2["tipointervento_id"].ToString(), ((ListControl) this.cmbsAnno).SelectedValue);
          cell2.Text = conti.Saldo;
          cell2.Attributes.Add("onclick", "ApriReportSaldo(cmbsAnno.value," + row2["tipointervento_id"].ToString() + ",'" + row2["descrizione_breve"].ToString() + "','" + conti.Fondo + "');");
          cell2.Attributes.Add("style", "cursor:hand");
          cell2.ToolTip = "Visualizza il Report per Tipo Intervento: " + row2["descrizione_breve"].ToString();
          row5.Cells.Add(cell2);
        }
        row5.Attributes.Add("align", "right");
        TableRow row6 = new TableRow();
        TableCell cell5 = new TableCell();
        cell5.Text = "<b>Presunto</b>";
        cell5.Attributes.Add("align", "left");
        row6.Cells.Add(cell5);
        foreach (DataRow row2 in (InternalDataCollectionBase) dataSet.Tables[0].Rows)
        {
          TableCell cell2 = new TableCell();
          cell2.Text = this.CalcolaPresunto(row2["tipointervento_id"].ToString(), ((ListControl) this.cmbsAnno).SelectedValue);
          cell2.Attributes.Add("onclick", "ApriReportPresunto(cmbsAnno.value," + row2["tipointervento_id"].ToString() + ",'" + row2["descrizione_breve"].ToString() + "');");
          cell2.Attributes.Add("style", "cursor:hand");
          cell2.ToolTip = "Visualizza il Report per Tipo Intervento: " + row2["descrizione_breve"].ToString();
          row6.Cells.Add(cell2);
        }
        row6.Attributes.Add("align", "right");
        table.Rows.Add(row1);
        table.Rows.Add(row3);
        table.Rows.Add(row4);
        table.Rows.Add(row5);
        table.Rows.Add(row6);
        table.Attributes.Add("border", "1");
        this.tdfondi.Controls.Add((Control) table);
      }
      else
        this.TblExcel.Visible = false;
    }

    private string CalcolaSpeso(string idTipoIntervento, string anno)
    {
      DataSet datiSpeso = new TheSite.Classi.ManStraordinaria.Report().GetDatiSpeso((int) short.Parse(idTipoIntervento), (int) short.Parse(anno));
      string str = "€ 0,00";
      if (datiSpeso.Tables[0].Rows.Count != 0)
      {
        DataRow row = datiSpeso.Tables[0].Rows[0];
        if (row[0] != DBNull.Value)
          str = double.Parse(row[0].ToString()).ToString("C");
      }
      return str;
    }

    private string CalcolaPresunto(string idTipoIntervento, string anno)
    {
      DataSet datiPresunto = new TheSite.Classi.ManStraordinaria.Report().GetDatiPresunto((int) short.Parse(idTipoIntervento), (int) short.Parse(anno));
      string str = "€ 0,00";
      if (datiPresunto.Tables[0].Rows.Count != 0)
      {
        DataRow row = datiPresunto.Tables[0].Rows[0];
        if (row[0] != DBNull.Value)
          str = double.Parse(row[0].ToString()).ToString("C");
      }
      return str;
    }

    private Conti CalcolaSaldo(string idTipoIntervento, string anno)
    {
      DataSet datiSaldo = new TheSite.Classi.ManStraordinaria.Report().GetDatiSaldo((int) short.Parse(idTipoIntervento), (int) short.Parse(anno));
      Conti conti = new Conti();
      if (datiSaldo.Tables[0].Rows.Count != 0)
      {
        DataRow row = datiSaldo.Tables[0].Rows[0];
        if (row["Saldo"] != DBNull.Value)
          conti.Saldo = double.Parse(row["Saldo"].ToString()).ToString("C");
        if (row["Fondo"] != DBNull.Value)
          conti.Fondo = double.Parse(row["Fondo"].ToString()).ToString("C");
      }
      return conti;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.BtnRicerca.Click += new EventHandler(this.BtnRicerca_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void BtnRicerca_Click(object sender, EventArgs e) => this.CaricaTabella();
  }
}
