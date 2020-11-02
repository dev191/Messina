// Decompiled with JetBrains decompiler
// Type: TheSite.AslMobile.CreazioneRichiesta3
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Web.UI.MobileControls;

namespace TheSite.AslMobile
{
  public abstract class CreazioneRichiesta3 : MobileUserControl
  {
    protected Label lblsospesa;
    protected Label lblDataInizio;
    protected Label lblDataFine;
    protected Label lblAnnotazioni;
    protected Label lblstato;

    private void Page_Load(object sender, EventArgs e)
    {
    }

    public void SetData(DataRow _Dr)
    {
      if (_Dr["stato_descrizione_estesa"] != DBNull.Value)
        this.lblstato.Text = _Dr["stato_descrizione_estesa"].ToString();
      else
        this.lblstato.Text = "";
      if (_Dr["notesospesa"] != DBNull.Value)
        this.lblsospesa.Text = _Dr["notesospesa"].ToString();
      else
        this.lblsospesa.Text = "";
      if (_Dr["comments"] != DBNull.Value)
        this.lblAnnotazioni.Text = _Dr["comments"].ToString();
      else
        this.lblAnnotazioni.Text = "";
      if (_Dr["date_start"] != DBNull.Value)
        this.lblDataInizio.Text = DateTime.Parse(_Dr["date_start"].ToString()).ToLongDateString();
      else
        this.lblDataInizio.Text = "";
      if (_Dr["date_end"] != DBNull.Value)
        this.lblDataFine.Text = DateTime.Parse(_Dr["date_end"].ToString()).ToLongDateString();
      else
        this.lblDataFine.Text = "";
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
