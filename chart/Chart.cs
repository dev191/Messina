// Decompiled with JetBrains decompiler
// Type: chart.Chart
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace chart
{
  public class Chart : Page
  {
    protected int latoFrame;
    protected int Npx;
    protected int Nhh;
    protected int Rdisco;
    protected int ScalaLinare;
    protected int ScalaLogaritmica;
    protected int i_Tipologia;
    protected int Anno;
    protected string urlChart;
    protected string S_optBtnRdlDispersioneAC;
    protected string S_optBtnRdlDispersioneRA;
    protected string S_optBtnRdlDispersioneRC;
    protected float zoom;
    protected float esponente;
    protected TextBox TxtNore;
    protected DropDownList drpzoom;
    protected RadioButton RbtLineare;
    protected RadioButton RbtLogaritmica;
    protected TextBox TxtEsponente;
    protected TextBox txtRaggioLabel;
    protected RangeValidator RangeValidator1;
    protected ValidationSummary ValidationSummary1;
    protected RangeValidator RangeValidator2;
    protected RangeValidator RangeValidator3;
    protected Button sbtSubmit;
    protected RangeValidator RangeValidatorRaggioLabel;
    protected TextBox TxtAnno;

    private void Page_Load(object sender, EventArgs e)
    {
      if (!this.IsPostBack)
        this.TxtAnno.Text = DateTime.Now.Year.ToString();
      this.RecuperoParametri();
      this.ImpostaChart();
      this.DysplayChart();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.sbtSubmit.Click += new EventHandler(this.Submit_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void ImpostaChart()
    {
      this.RbtLineare.Attributes.Add("onclick", "enableLiniare();");
      this.RbtLogaritmica.Attributes.Add("onclick", "enableLogaritmica();");
      if (this.RbtLineare.Checked)
      {
        this.TxtEsponente.Enabled = false;
        this.drpzoom.Enabled = true;
        this.ScalaLinare = 1;
      }
      else
      {
        this.ScalaLinare = 0;
        this.TxtEsponente.Enabled = true;
        this.drpzoom.SelectedIndex = 4;
        this.drpzoom.Enabled = false;
      }
      this.ScalaLogaritmica = !this.RbtLogaritmica.Checked ? 0 : 1;
      this.Anno = Convert.ToInt32(this.TxtAnno.Text.ToString());
      this.esponente = Convert.ToSingle(this.TxtEsponente.Text.ToString());
      this.Rdisco = Convert.ToInt32(this.txtRaggioLabel.Text.ToString());
      this.Npx = 3;
      this.Nhh = Convert.ToInt32(Convert.ToInt32(this.TxtNore.Text));
      if (!this.IsPostBack)
        this.impostaZoom();
      this.zoom = Convert.ToSingle(this.drpzoom.SelectedValue);
    }

    private void impostaZoom()
    {
      this.drpzoom.Items.Add(new ListItem("20%", "0,20"));
      this.drpzoom.Items.Add(new ListItem("25%", "0,25"));
      this.drpzoom.Items.Add(new ListItem("50%", "0,50"));
      this.drpzoom.Items.Add(new ListItem("75%", "0,75"));
      this.drpzoom.Items.Add(new ListItem("100%", "1,0"));
      this.drpzoom.Items.Add(new ListItem("125%", "1,2"));
      this.drpzoom.Items.Add(new ListItem("150%", "1,5"));
      this.drpzoom.Items.Add(new ListItem("200%", "2,0"));
      this.drpzoom.Items.Add(new ListItem("500%", "5,0"));
      this.drpzoom.SelectedIndex = 4;
    }

    private void Submit_Click(object sender, EventArgs e) => this.DysplayChart();

    private void RecuperoParametri()
    {
      switch (this.Request["tipologia"])
      {
        case "1":
          this.i_Tipologia = 1;
          break;
        case "2":
          this.i_Tipologia = 2;
          break;
        case "3":
          this.i_Tipologia = 3;
          break;
        case "4":
          this.i_Tipologia = 4;
          break;
        default:
          this.i_Tipologia = 0;
          break;
      }
      this.S_optBtnRdlDispersioneAC = this.Request["S_optBtnRdlDispersioneAC"];
      this.S_optBtnRdlDispersioneRA = this.Request["S_optBtnRdlDispersioneRA"];
      this.S_optBtnRdlDispersioneRC = this.Request["S_optBtnRdlDispersioneRC"];
    }

    private void DysplayChart()
    {
      if (this.RbtLineare.Checked)
        this.latoFrame = Convert.ToInt32((float) ((double) this.zoom * (double) this.Npx * 2.0) * (float) this.Nhh) + 2 * this.Rdisco + Convert.ToInt32((float) ((double) (20 * this.Npx) * (double) this.zoom + 50.0));
      if (this.RbtLogaritmica.Checked)
        this.latoFrame = Convert.ToInt32((float) (2.0 * (double) Convert.ToSingle(Math.Log((double) this.zoom * (double) this.Npx * (double) this.Nhh) * Math.Exp((double) this.esponente) + (double) this.Rdisco + 25.0) + 50.0));
      this.urlChart = "./pagine/demo.aspx?Npx=" + (object) this.Npx + "&Nhh=" + (object) this.Nhh + "&zoom=" + (object) this.zoom + "&Rdisco=" + (object) this.Rdisco + "&ScalaLinare=" + (object) this.ScalaLinare + "&ScalaLogaritmica=" + (object) this.ScalaLogaritmica + "&esponente=" + (object) this.esponente + "&Anno=" + (object) this.Anno + "&S_optBtnRdlDispersioneAC=" + this.S_optBtnRdlDispersioneAC + "&S_optBtnRdlDispersioneRA=" + this.S_optBtnRdlDispersioneRA + "&S_optBtnRdlDispersioneRC=" + this.S_optBtnRdlDispersioneRC + "&i_Tipologia=" + (object) this.i_Tipologia;
    }

    private enum TipoM
    {
      Richiesta = 1,
      Programmata = 2,
      Straordinaria = 3,
      Entrambe = 4,
    }
  }
}
