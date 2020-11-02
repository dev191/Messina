// Decompiled with JetBrains decompiler
// Type: TheSite.CreazioneTemp
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using S_Controls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheSite
{
  public class CreazioneTemp : Page
  {
    protected Label lblProgetto;
    protected RequiredFieldValidator rfvRichiedenteNome;
    protected RequiredFieldValidator rfvRichiedenteCognome;
    protected Panel PanelRichiedente;
    protected RequiredFieldValidator rfvEdificio;
    protected S_TextBox txtsTelefonoRichiedente;
    protected S_TextBox txtsNota;
    protected RequiredFieldValidator RequiredFieldValidator1;
    protected S_ComboBox cmbsPiano;
    protected LinkButton lkbNonEmesse;
    protected LinkButton lnkChiudi;
    protected DataGrid DataGridRicerca;
    protected Panel pnlShowInfo;
    protected LinkButton LinkApprovate;
    protected LinkButton LinkChiudi2;
    protected DataGrid DatagridEmesse;
    protected Panel PanelEmesse;
    protected Button btsCodice;
    protected TextBox txtBL_ID;
    protected S_ComboBox cmbsServizio;
    protected RequiredFieldValidator RequiredfieldvalidatorServ;
    protected S_ComboBox cmbsApparecchiatura;
    protected Panel PanelServizio;
    protected S_ComboBox cmbsUrgenza;
    protected S_TextBox txtsProblema;
    protected Panel PanelProblema;
    protected S_ComboBox cmbsTipoIntrevento;
    protected CheckBox ChkConduzione;
    protected S_ComboBox OraConduzione;
    protected S_ComboBox MinutiConduzione;
    protected S_ComboBox CmbASeguito;
    protected S_TextBox TxtASeguito1;
    protected CheckBox ChkSopralluogo;
    protected S_TextBox TxtSopralluogo;
    protected S_TextBox TxtASeguito4;
    protected S_TextBox TxtCausa;
    protected S_TextBox TxtGuasto;
    protected TextBox txtsorain;
    protected TextBox txtsorainmin;
    protected S_Button btnsSalva;
    protected Button cmdReset;
    protected S_Button btnsChiudi;
    protected Label lblFirstAndLast;
    protected MessagePanel PanelMess;
    protected ValidationSummary vlsEdit;
    protected DropDownList CmbProgetto;

    private void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
