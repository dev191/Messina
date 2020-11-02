// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.PianoManutenzioneProgrammata
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnalisiStatistiche;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class PianoManutenzioneProgrammata : Page
  {
    protected Label lblAnno;
    protected Label lblmese;
    protected TextBox txtAnno;
    protected DropDownList drpMese;
    protected DataPanel DataPanelRicerca;
    protected Label lblEdificio;
    protected DropDownList drpEdificio;
    protected DropDownList drpCategoriaTecnologica;
    protected Label lblClasseElemento;
    protected DropDownList drpClasseElemento;
    protected Label lnlCategoriaTecnologica;
    protected Button btnGenera;
    protected RequiredFieldValidator RequiredFieldValidator1;
    protected RegularExpressionValidator RegularExpressionValidator1;
    protected ValidationSummary ValidationSummary1;
    protected PageTitle PageTitle1;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      this.PageTitle1.Title = "Stampa Piano Manutenzione Programmata";
      if (this.IsPostBack)
        return;
      this.InizializzaControlli();
    }

    private void InizializzaControlli()
    {
      this.InitdrpMese();
      this.InitTxtAnno();
      this.InitDrp();
    }

    private void InitdrpMese() => this.drpMese.SelectedIndex = DateTime.Today.Month - 1;

    private void InitTxtAnno() => this.txtAnno.Text = DateTime.Today.Year.ToString();

    private void InitDrp()
    {
      bindCombo bindCombo = new bindCombo("PACK_RPT_PIANO_MAN_PROG.GetEdifici", this.drpEdificio, "System.String");
      bindCombo.getComboBox();
      this.drpEdificio.Items.Remove("");
      bindCombo.nomeSoredProcedure = "PACK_RPT_PIANO_MAN_PROG.GetServizi";
      bindCombo.testoItemZero = "Tutte le unità tecnologiche";
      bindCombo.tipoValue = "System.Int32";
      bindCombo.cmb = this.drpCategoriaTecnologica;
      bindCombo.getComboBox();
      bindCombo.nomeSoredProcedure = "PACK_RPT_PIANO_MAN_PROG.GetEqstd";
      bindCombo.testoItemZero = "Tutte le classi elemento";
      bindCombo.tipoValue = "System.Int32";
      bindCombo.cmb = this.drpClasseElemento;
      bindCombo.getComboBox();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.btnGenera.Click += new EventHandler(this.btnGenera_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnGenera_Click(object sender, EventArgs e)
    {
      string str = "?Anno=" + this.txtAnno.Text + "&Mese=" + this.drpMese.SelectedValue + "&ID_EDIFICIO=" + this.drpEdificio.SelectedValue + "&ID_SERVIZIO=" + this.drpCategoriaTecnologica.SelectedValue + "&ID_EQSTD=" + this.drpClasseElemento.SelectedValue;
      Hashtable hashtable = new Hashtable();
      hashtable.Clear();
      hashtable.Add((object) "Anno", (object) this.txtAnno.Text);
      hashtable.Add((object) "MeseEsteso", (object) this.drpMese.SelectedItem.Text);
      hashtable.Add((object) "Eedificio", (object) this.drpEdificio.SelectedItem.Text);
      hashtable.Add((object) "Servizio", (object) this.drpCategoriaTecnologica.SelectedItem.Text);
      hashtable.Add((object) "ClasseElemento", (object) this.drpClasseElemento.SelectedItem.Text);
      if (this.Session["DataERRmp"] != null)
        this.Session.Remove("DataERRmp");
      this.Session.Add("DataERRmp", (object) hashtable);
      this.Server.Transfer("MostraPianoMP.aspx" + str);
    }
  }
}
