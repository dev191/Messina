// Decompiled with JetBrains decompiler
// Type: TheSite.AslMobile.CreazioneRichiesta1
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Web.UI.MobileControls;

namespace TheSite.AslMobile
{
  public abstract class CreazioneRichiesta1 : MobileUserControl
  {
    protected Label LblRdl;
    protected Label lblTrasmissione;
    protected Label lblRichiedente;
    protected Label lblOperatore;
    protected Label lblTelefono;
    protected Label lblDataRichiesta;
    protected Label lblOraRichiesta;
    protected Label lblGruppo;
    protected Label lblFabriccato;
    protected Label lblNote;
    protected Label lblServizio;
    protected Label lblStandApp;
    protected Label lblApp;
    protected Label lblDescrizione;

    private void Page_Load(object sender, EventArgs e)
    {
    }

    public void SetData(DataRow _Dr)
    {
      if (_Dr["id"] != DBNull.Value)
        this.LblRdl.Text = _Dr["ID"].ToString();
      else
        this.LblRdl.Text = "";
      if (_Dr["descrizionetrasmissione"] != DBNull.Value)
        this.lblTrasmissione.Text = _Dr["descrizionetrasmissione"].ToString();
      else
        this.lblTrasmissione.Text = "";
      if (_Dr["richiedente"] != DBNull.Value)
        this.lblRichiedente.Text = _Dr["richiedente"].ToString();
      else
        this.lblRichiedente.Text = "";
      if (_Dr["operatore"] != DBNull.Value)
        this.lblOperatore.Text = _Dr["operatore"].ToString();
      else
        this.lblOperatore.Text = "";
      if (_Dr["telefono"] != DBNull.Value)
        this.lblTelefono.Text = _Dr["telefono"].ToString();
      else
        this.lblTelefono.Text = "";
      string empty = string.Empty;
      if (_Dr["dataRichiesta"] != DBNull.Value)
        this.lblDataRichiesta.Text = DateTime.Parse(_Dr["dataRichiesta"].ToString()).ToShortDateString();
      else
        this.lblDataRichiesta.Text = "";
      if (_Dr["dataRichiesta"] != DBNull.Value)
        this.lblOraRichiesta.Text = DateTime.Parse(_Dr["dataRichiesta"].ToString()).ToShortTimeString();
      else
        this.lblOraRichiesta.Text = "";
      if (_Dr["gruppo"] != DBNull.Value)
        this.lblGruppo.Text = _Dr["gruppo"].ToString();
      else
        this.lblGruppo.Text = "";
      if (_Dr["fabbricato"] != DBNull.Value)
        this.lblFabriccato.Text = _Dr["fabbricato"].ToString();
      else
        this.lblFabriccato.Text = "";
      if (_Dr["nota"] != DBNull.Value)
        this.lblNote.Text = _Dr["nota"].ToString();
      else
        this.lblNote.Text = "";
      if (_Dr["servizio_descrizione"] != DBNull.Value)
        this.lblServizio.Text = _Dr["servizio_descrizione"].ToString();
      else
        this.lblServizio.Text = "";
      if (_Dr["standardapp"] != DBNull.Value)
        this.lblStandApp.Text = _Dr["standardapp"].ToString();
      else
        this.lblStandApp.Text = "";
      if (_Dr["eq_id"] != DBNull.Value)
        this.lblApp.Text = _Dr["eq_id"].ToString();
      else
        this.lblApp.Text = "";
      if (_Dr["descrizione"] != DBNull.Value)
        this.lblDescrizione.Text = _Dr["descrizione"].ToString();
      else
        this.lblDescrizione.Text = "";
    }

    public string Rdl => this.LblRdl.Text;

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
