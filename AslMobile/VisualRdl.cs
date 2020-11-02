// Decompiled with JetBrains decompiler
// Type: TheSite.AslMobile.VisualRdl
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Web.UI.MobileControls;
using TheSite.AslMobile.Class;

namespace TheSite.AslMobile
{
  public class VisualRdl : MobilePage
  {
    protected Panel Panel1;
    protected DeviceSpecific DeviceSpecific1;
    protected Form Form1;
    private int itemId = 0;
    private Label p_lblOperatore;
    private Label p_lblData;
    private Label p_lblOra;
    private Label p_lblRichiedente;
    private Label p_lblGruppo;
    private Label p_lblTelefono;
    private Label p_lblNota;
    private Label p_lblCodiceEdificio;
    private Label p_lblDenominazione;
    private Label p_lblDescrizione;
    private Label p_lblUrgenza;
    private Label p_lblServizio;
    private Label p_lblEqStd;
    private Label p_lblEqId;
    private Label p_lblRDL;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.Request.Params["ItemId"] == null)
        return;
      this.p_lblOperatore = (Label) this.Panel1.Controls[0].FindControl("lblOperatore");
      this.p_lblData = (Label) this.Panel1.Controls[0].FindControl("lblData");
      this.p_lblOra = (Label) this.Panel1.Controls[0].FindControl("lblOra");
      this.p_lblRichiedente = (Label) this.Panel1.Controls[0].FindControl("lblRichedente");
      this.p_lblGruppo = (Label) this.Panel1.Controls[0].FindControl("lblGruppo");
      this.p_lblTelefono = (Label) this.Panel1.Controls[0].FindControl("lblTelefono");
      this.p_lblNota = (Label) this.Panel1.Controls[0].FindControl("lblNota");
      this.p_lblCodiceEdificio = (Label) this.Panel1.Controls[0].FindControl("lblCodEdificio");
      this.p_lblDenominazione = (Label) this.Panel1.Controls[0].FindControl("lblDenominazione");
      this.p_lblDescrizione = (Label) this.Panel1.Controls[0].FindControl("lblDescrizione");
      this.p_lblUrgenza = (Label) this.Panel1.Controls[0].FindControl("lblUrgenza");
      this.p_lblServizio = (Label) this.Panel1.Controls[0].FindControl("lblServizio");
      this.p_lblEqStd = (Label) this.Panel1.Controls[0].FindControl("lblStdApparacchiatura");
      this.p_lblEqId = (Label) this.Panel1.Controls[0].FindControl("lblApparacchiatura");
      this.p_lblRDL = (Label) this.Panel1.Controls[0].FindControl("lblRDL");
      this.p_lblRDL.Text = this.Request.Params["ItemId"];
      this.itemId = int.Parse(this.Request.Params["ItemId"]);
      DataSet dataSet = new ClassRichiesta(this.Context.User.Identity.Name).GetSingleData(this.itemId).Copy();
      if (dataSet.Tables[0].Rows.Count != 1)
        return;
      DataRow row = dataSet.Tables[0].Rows[0];
      this.p_lblData.Text = ((DateTime) row["DATE_REQUESTED"]).ToShortDateString();
      this.p_lblOra.Text = ((DateTime) row["TIME_REQUESTED"]).ToShortTimeString();
      this.p_lblCodiceEdificio.Text = (string) row["BL_ID"];
      if (row["DENOMINAZIONE"] != DBNull.Value)
        this.p_lblDenominazione.Text = (string) row["DENOMINAZIONE"];
      if (row["USERNAME"] != DBNull.Value)
        this.p_lblOperatore.Text = (string) row["USERNAME"];
      if (row["REQUESTOR"] != DBNull.Value)
        this.p_lblRichiedente.Text = (string) row["REQUESTOR"];
      if (row["PHONE"] != DBNull.Value)
        this.p_lblTelefono.Text = (string) row["PHONE"];
      if (row["DESCRIZIONERICHIEDENTI"] != DBNull.Value)
        this.p_lblGruppo.Text = (string) row["DESCRIZIONERICHIEDENTI"];
      string empty1 = string.Empty;
      if (row["NOTA_RIC"] != DBNull.Value)
        empty1 = (string) row["NOTA_RIC"];
      this.p_lblNota.Text = empty1.Replace("\n", "<br>");
      string empty2 = string.Empty;
      if (row["DESCRIPTION"] != DBNull.Value)
        empty2 = (string) row["DESCRIPTION"];
      this.p_lblDescrizione.Text = empty2.Replace("\n", "<br>");
      if (row["PRIORITY"] != DBNull.Value)
        this.p_lblUrgenza.Text = (string) row["PRIORITY"];
      if (row["DESCRIZIONESERVIZI"] != DBNull.Value)
        this.p_lblServizio.Text = (string) row["DESCRIZIONESERVIZI"];
      string str = string.Empty;
      if (row["EQ_STD"] != DBNull.Value)
        str = (string) row["EQ_STD"];
      if (row["DESCRIZIONEEQSTD"] != DBNull.Value)
        str = str + " " + (string) row["DESCRIZIONEEQSTD"];
      this.p_lblEqStd.Text = str;
      if (row["EQ_ID"] == DBNull.Value)
        return;
      this.p_lblEqId.Text = (string) row["EQ_ID"];
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
