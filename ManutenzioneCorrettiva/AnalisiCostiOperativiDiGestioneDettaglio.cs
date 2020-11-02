// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorrettiva.AnalisiCostiOperativiDiGestioneDettaglio
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using MyCollection;
using S_Controls.Collections;
using System;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ManCorrettiva;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorrettiva
{
  public class AnalisiCostiOperativiDiGestioneDettaglio : Page
  {
    private string wrId;
    protected materiali mtImpegnati;
    protected DataPanel DataPanelRicerca;
    protected CostiManodopera cstAddetti;
    protected Button btnChiudi;
    protected DataPanel DataPanelRicerca1;
    protected Button BntIndietro;
    protected PageTitle PgTitleCostiGestioneDettaglio;
    public SiteModule _SiteModule;
    protected Label LblOdL;
    protected Label LblRdL;
    protected Label LblRichiedente;
    protected Label LblTelefono;
    protected Label LblDataRichiesta;
    protected Label LblFabbricato;
    protected Label LblServizi;
    protected Label LblDescIntervento;
    protected Label LblDataPianificata;
    protected Label LblDataInizio;
    protected Label LblDataFine;
    protected Label LblStatoRic;
    protected Label LblAddetto;
    protected Label LblTipoIntervento;
    protected Label LblSpesaPresunta;
    protected Label LblOdLCommit;
    protected Label LblAnnMatUtil;
    protected HtmlTableRow TrMs;
    protected Label LblUrgenza;
    private bool IsEditable = false;
    private EditCompletamento _fp;
    private string chiamante = "";
    protected Literal LblTotale;
    private double tot;

    private void Page_Load(object sender, EventArgs e)
    {
      this.wrId = this.Request["WR_ID"];
      this.PgTitleCostiGestioneDettaglio.Title = "DETTAGLIO COSTI OPERATIVI DI GESTIONE RDL " + this.wrId;
      this.LblRdL.Text = this.wrId;
      this.CaricaIntestazione();
      this.cstAddetti.wrId = Convert.ToInt32(this.wrId);
      this.mtImpegnati.wrId = Convert.ToInt32(this.wrId);
      this._SiteModule = new SiteModule("AnalisiCostiOperativiDiGestioneDettaglio.aspx");
      this.IsEditable = this._SiteModule.IsEditable;
      if (!this.Page.IsPostBack)
      {
        DataSet dataSet = new ClManCorrettiva().TotManodopera(Convert.ToInt32(this.wrId));
        if (dataSet.Tables[0].Rows.Count > 0)
          this.tot = Convert.ToDouble(dataSet.Tables[0].Rows[0]["totaddetto"]) + Convert.ToDouble(dataSet.Tables[0].Rows[0]["totmateriale"]);
        this.LblTotale.Text = this.FormattaDecimali((object) this.tot, (object) 2);
      }
      Type type = this.Context.Handler.GetType();
      if (this.Request.QueryString["chiamante"] != null)
        this.chiamante = this.Request.QueryString["chiamante"].ToString();
      PropertyInfo property = type.GetProperty("_Contenitore");
      if (property == null)
        return;
      this.ViewState.Add("mioContenitore", property.GetValue((object) this.Context.Handler, (object[]) null));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.btnChiudi.Click += new EventHandler(this.btnChiudi_Click);
      this.BntIndietro.Click += new EventHandler(this.BntIndietro_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnChiudi_Click(object sender, EventArgs e) => this.Server.Transfer("AnalisiCostiOperativiDiGestione.aspx");

    protected string FormattaDecimali(object numero, object cifre)
    {
      NumberFormatInfo numberFormat = new CultureInfo("it-IT", false).NumberFormat;
      numberFormat.NumberDecimalDigits = Convert.ToInt32(cifre);
      return numero != DBNull.Value ? Convert.ToDecimal(numero).ToString("N", (IFormatProvider) numberFormat) : string.Empty;
    }

    private void CaricaIntestazione()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      ClManCorrettiva clManCorrettiva = new ClManCorrettiva();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_wr_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) this.wrId);
      CollezioneControlli.Add(sObject);
      DataSet singleRdL = clManCorrettiva.GetSingleRdL(CollezioneControlli);
      if (singleRdL.Tables[0].Rows.Count <= 0)
        return;
      if (singleRdL.Tables[0].Rows[0]["addetto"] != DBNull.Value)
        this.LblAddetto.Text = singleRdL.Tables[0].Rows[0]["addetto"].ToString();
      if (singleRdL.Tables[0].Rows[0]["annotazionimateriale"] != DBNull.Value)
        this.LblAnnMatUtil.Text = singleRdL.Tables[0].Rows[0]["annotazionimateriale"].ToString();
      if (singleRdL.Tables[0].Rows[0]["datafine"] != DBNull.Value)
        this.LblDataFine.Text = Convert.ToDateTime(singleRdL.Tables[0].Rows[0]["datafine"]).ToString("g");
      if (singleRdL.Tables[0].Rows[0]["datainizio"] != DBNull.Value)
        this.LblDataInizio.Text = Convert.ToDateTime(singleRdL.Tables[0].Rows[0]["datainizio"]).ToString("g");
      if (singleRdL.Tables[0].Rows[0]["datapianificata"] != DBNull.Value)
        this.LblDataPianificata.Text = Convert.ToDateTime(singleRdL.Tables[0].Rows[0]["datapianificata"]).ToString("g");
      if (singleRdL.Tables[0].Rows[0]["datarichiesta"] != DBNull.Value)
        this.LblDataRichiesta.Text = Convert.ToDateTime(singleRdL.Tables[0].Rows[0]["datarichiesta"]).ToString("g");
      if (singleRdL.Tables[0].Rows[0]["descintervento"] != DBNull.Value)
        this.LblDescIntervento.Text = singleRdL.Tables[0].Rows[0]["descintervento"].ToString();
      if (singleRdL.Tables[0].Rows[0]["fabbricato"] != DBNull.Value)
        this.LblFabbricato.Text = singleRdL.Tables[0].Rows[0]["fabbricato"].ToString();
      if (singleRdL.Tables[0].Rows[0]["odl"] != DBNull.Value)
      {
        this.LblOdL.Text = singleRdL.Tables[0].Rows[0]["odl"].ToString();
        this.PgTitleCostiGestioneDettaglio.Title = "DETTAGLIO COSTI OPERATIVI DI GESTIONE RDL  " + this.wrId + " OdL  " + this.LblOdL.Text;
      }
      if (singleRdL.Tables[0].Rows[0]["ordinedilavorocommittente"] != DBNull.Value)
        this.LblOdLCommit.Text = singleRdL.Tables[0].Rows[0]["ordinedilavorocommittente"].ToString();
      if (singleRdL.Tables[0].Rows[0]["richiedente"] != DBNull.Value)
        this.LblRichiedente.Text = singleRdL.Tables[0].Rows[0]["richiedente"].ToString();
      if (singleRdL.Tables[0].Rows[0]["servizi"] != DBNull.Value)
        this.LblServizi.Text = singleRdL.Tables[0].Rows[0]["servizi"].ToString();
      if (singleRdL.Tables[0].Rows[0]["spesapresunta"] != DBNull.Value)
        this.LblSpesaPresunta.Text = singleRdL.Tables[0].Rows[0]["spesapresunta"].ToString();
      if (singleRdL.Tables[0].Rows[0]["statorichiesta"] != DBNull.Value)
        this.LblStatoRic.Text = singleRdL.Tables[0].Rows[0]["statorichiesta"].ToString();
      if (singleRdL.Tables[0].Rows[0]["telefono"] != DBNull.Value)
        this.LblTelefono.Text = singleRdL.Tables[0].Rows[0]["telefono"].ToString();
      if (singleRdL.Tables[0].Rows[0]["tipointerveto"] != DBNull.Value)
        this.LblTipoIntervento.Text = singleRdL.Tables[0].Rows[0]["tipointerveto"].ToString();
      if (singleRdL.Tables[0].Rows[0]["urgenza"] != DBNull.Value)
        this.LblUrgenza.Text = singleRdL.Tables[0].Rows[0]["urgenza"].ToString();
      if (singleRdL.Tables[0].Rows[0]["tipomanutenzione"] == DBNull.Value || !(singleRdL.Tables[0].Rows[0]["tipomanutenzione"].ToString() != "3"))
        return;
      this.TrMs.Attributes.Add("style", "DISPLAY:none");
    }

    private void BntIndietro_Click(object sender, EventArgs e)
    {
      if (this.chiamante == "")
        this.Server.Transfer("AnalisiCostiOperativiDiGestione.aspx");
      else
        this.Server.Transfer(this.chiamante.Split('.')[1].ToString().Split('_')[0].ToString() + ".aspx?wr_id=" + this.wrId + "&c=c");
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();
  }
}
