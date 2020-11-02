// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorretiva.RapportoRichiestaRdl
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi.ManStraordinaria;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorretiva
{
  public class RapportoRichiestaRdl : Page
  {
    protected PageTitle PageTitle1;
    protected S_Label lblRdl;
    private int FunId = 0;
    protected TextBox txtWrHidden;
    protected S_Button btApprova;
    protected S_Button btCrea;
    private int itemId = 0;
    public string Ordine;
    public string DataIni;
    public string DataEnd;
    public string Bl_id;
    public string Comune;
    public string Indirizzo;
    public string Ditta;
    public string NomeEdificio;
    public string DescrizioneIntervento;
    public string SpesaPresunta;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.Request.Params["FunId"] != null)
        this.ViewState.Add("FunId", (object) int.Parse(this.Request.Params["FunId"]));
      if (this.IsPostBack)
        return;
      this.BindingData();
    }

    private void BindingData()
    {
      if (this.Request.Params["ItemId"] == null)
        return;
      this.itemId = int.Parse(this.Request.Params["ItemId"]);
      this.txtWrHidden.Text = this.itemId.ToString();
      this.PageTitle1.Title = "Inserimento Richiesta di Lavoro N° " + this.itemId.ToString();
      ((Label) this.lblRdl).Text = string.Format("RDL n° {0} del {1}", (object) this.itemId, (object) DateTime.Now.ToShortDateString());
      DataSet rapportino = new Richiesta().GetRapportino(this.itemId);
      if (rapportino.Tables[0].Rows.Count <= 0)
        return;
      DataRow row = rapportino.Tables[0].Rows[0];
      if (row["ordine_lavoro"] != DBNull.Value)
        this.Ordine = row["ordine_lavoro"].ToString();
      DateTime dateTime;
      if (row["datainizio"] != DBNull.Value)
      {
        dateTime = Convert.ToDateTime(row["datainizio"]);
        this.DataIni = dateTime.ToShortDateString();
      }
      if (row["datafine"] != DBNull.Value)
      {
        dateTime = Convert.ToDateTime(row["datafine"]);
        this.DataEnd = dateTime.ToShortDateString();
      }
      if (row["bl_id"] != DBNull.Value)
        this.Bl_id = row["bl_id"].ToString();
      if (row["comune"] != DBNull.Value)
        this.Comune = row["comune"].ToString();
      if (row["indirizzo"] != DBNull.Value)
        this.Indirizzo = row["indirizzo"].ToString();
      if (row["descrizione_ditta"] != DBNull.Value)
        this.Ditta = row["descrizione_ditta"].ToString();
      if (row["nome_edificio"] != DBNull.Value)
        this.NomeEdificio = row["nome_edificio"].ToString();
      if (row["spesa_presunta"] != DBNull.Value)
        this.SpesaPresunta = double.Parse(row["spesa_presunta"].ToString()).ToString("C");
      if (row["descrizione_intervento"] == DBNull.Value)
        return;
      this.DescrizioneIntervento = row["descrizione_intervento"].ToString();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btApprova).Click += new EventHandler(this.btApprova_Click);
      ((Button) this.btCrea).Click += new EventHandler(this.btCrea_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btApprova_Click(object sender, EventArgs e)
    {
      if (this.ViewState["FunId"] != null)
        this.FunId = Convert.ToInt32(this.ViewState["FunId"]);
      this.Server.Transfer("AggiornamentoRdl.aspx?ItemID=" + this.txtWrHidden.Text + "&e=y&butt=1&FunId=" + (object) this.FunId);
    }

    private void btCrea_Click(object sender, EventArgs e)
    {
      if (this.ViewState["FunId"] != null)
        this.FunId = Convert.ToInt32(this.ViewState["FunId"]);
      this.Response.Redirect("CreazioneSGA.aspx?FunId=" + this.FunId.ToString());
    }
  }
}
