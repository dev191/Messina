// Decompiled with JetBrains decompiler
// Type: TheSite.AslMobile.CreazioneRichiesta2
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Web.UI.MobileControls;

namespace TheSite.AslMobile
{
  public abstract class CreazioneRichiesta2 : MobileUserControl
  {
    protected Label S_Lblordinelavoro;
    protected Label lblditta;
    protected Label lbladdetto;
    protected Label lbltipointervento;
    protected Label lblurgenza;
    protected Label ldldatap;
    protected Label lblorap;
    protected Label LblMessaggio;

    private void Page_Load(object sender, EventArgs e)
    {
    }

    public void SetData(DataRow _Dr, DataRow _DrStato)
    {
      if (_Dr["wo_id"] != DBNull.Value)
        this.S_Lblordinelavoro.Text = _Dr["wo_id"].ToString();
      else
        this.S_Lblordinelavoro.Text = "";
      if (_Dr["descrizioneditta"] != DBNull.Value)
        this.lblditta.Text = _Dr["descrizioneditta"].ToString();
      else
        this.lblditta.Text = "";
      if (_Dr["addetto"] != DBNull.Value)
        this.lbladdetto.Text = _Dr["addetto"].ToString();
      else
        this.lbladdetto.Text = "";
      if (_Dr["datapianificata"] != DBNull.Value)
        this.ldldatap.Text = DateTime.Parse(_Dr["datapianificata"].ToString()).ToShortDateString();
      else
        this.ldldatap.Text = "";
      if (_Dr["datapianificata"] != DBNull.Value)
      {
        DateTime dateTime = DateTime.Parse(_Dr["datapianificata"].ToString());
        this.lblorap.Text = dateTime.Hour.ToString() + ":" + dateTime.Minute.ToString();
      }
      else
        this.lblorap.Text = "";
      if (_Dr["manutenzione"] != DBNull.Value)
        this.lbltipointervento.Text = _Dr["manutenzione"].ToString();
      else
        this.lbltipointervento.Text = "";
      if (_Dr["urgenza"] != DBNull.Value)
        this.lblurgenza.Text = _Dr["urgenza"].ToString();
      else
        this.lblurgenza.Text = "";
      if (_DrStato != null)
        this.LblMessaggio.Text = "Stato della Richiesta di Lavoro : " + _DrStato["descrizione"].ToString() + " in data: " + _DrStato["data"];
      else
        this.LblMessaggio.Text = "";
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
