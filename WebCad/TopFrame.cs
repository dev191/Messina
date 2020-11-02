// Decompiled with JetBrains decompiler
// Type: WebCad.TopFrame
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebCad.Classi.ClassiAnagrafiche;

namespace WebCad
{
  public class TopFrame : Page
  {
    public string idbl = string.Empty;
    public string idpiano = string.Empty;
    protected string lblBlClinetId;
    protected string lblFlClinetId;
    protected string tbxBlClinetId;
    protected Label lblEdificio;
    protected TextBox id_bl;
    protected Label lblPiano;
    protected TextBox id_fl;
    protected Label lblPlanD;
    protected Label lblPlan;
    protected Label lblServizio;
    protected HtmlInputHidden TxtFromCreazioneRdl;
    protected HtmlInputHidden TxtIdServizio;
    protected string tbxFlClinetId;

    private void Page_Load(object sender, EventArgs e)
    {
      this.idbl = this.Request.QueryString["idbl"];
      this.idpiano = this.Request.QueryString["idpiano"];
      this.lblBlClinetId = "";
      this.lblFlClinetId = "";
      this.tbxBlClinetId = this.id_bl.ClientID;
      this.tbxFlClinetId = this.id_fl.ClientID;
      if (this.Request["FromPaginaCreazioneRdl"] != null)
      {
        this.ImpostaLabelFromCreazioneRdl();
      }
      else
      {
        if (this.Request["FromPaginaApprovaEmettiRdl"] == null)
          return;
        this.ImpostaLabelFromApprovaEmettiRdl();
      }
    }

    private void GetInfoPage()
    {
      DataTable infoPage = this.GetInfoPage(this.idbl, this.idpiano);
      if (infoPage.Rows.Count <= 0)
        return;
      DataRow row = infoPage.Rows[0];
      this.lblEdificio.Text = row["Edificio"].ToString();
      this.lblPiano.Text = row["Piano"].ToString();
    }

    private DataTable GetInfoPage(string idbl, string idpaino) => new DataTable();

    private void ImpostaLabelFromCreazioneRdl()
    {
      string str = this.Request["BlId"];
      int int32 = Convert.ToInt32(this.Request["IdPiano"]);
      int IdServizio = 0;
      if (this.Request["IdServizio"] != string.Empty)
        IdServizio = Convert.ToInt32(this.Request["IdServizio"]);
      string descPiano = this.IdPiano_To_DescPiano(int32);
      this.lblEdificio.Text = str;
      this.lblPiano.Text = descPiano;
      if (IdServizio != 0)
        this.lblServizio.Text = this.Idservizio_To_DecServizio(IdServizio);
      this.TxtFromCreazioneRdl.Value = this.Request["FromPaginaCreazioneRdl"];
      this.TxtIdServizio.Value = IdServizio.ToString();
    }

    private void ImpostaLabelFromApprovaEmettiRdl()
    {
      string str = this.Request["BlId"];
      int int32 = Convert.ToInt32(this.Request["IdPiano"]);
      int IdServizio = 0;
      if (this.Request["IdServizio"] != string.Empty)
        IdServizio = Convert.ToInt32(this.Request["IdServizio"]);
      string descPiano = this.IdPiano_To_DescPiano(int32);
      this.lblEdificio.Text = str;
      this.lblPiano.Text = descPiano;
      if (IdServizio != 0)
        this.lblServizio.Text = this.Idservizio_To_DecServizio(IdServizio);
      this.TxtIdServizio.Value = IdServizio.ToString();
      this.lblPlan.Text = this.Request["Planimetria"];
    }

    private string Idservizio_To_DecServizio(int IdServizio) => new WebCad.Classi.ClassiDettaglio.Servizi().GetDecServizioById(IdServizio);

    private string IdPiano_To_DescPiano(int IdPiano) => new Buildings().GetDescrizionePiano(IdPiano);

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
