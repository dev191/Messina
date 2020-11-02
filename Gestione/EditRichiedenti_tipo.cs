// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditRichiedenti_tipo
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class EditRichiedenti_tipo : Page
  {
    protected S_TextBox txtsFrequenza_des;
    protected S_TextBox txtsFrequenza;
    protected DataPanel PanelRicerca;
    protected S_Button btnsRicerca;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    private int itemId = 0;
    public static int FunId = 0;
    protected Label lblOperazione;
    protected MessagePanel PanelMess;
    protected Panel PanelEdit;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected ValidationSummary vlsEdit;
    protected S_TextBox txtsdescrizione;
    protected S_TextBox txtsnote;
    protected RequiredFieldValidator rvfdescrizione;
    public static string HelpLink = string.Empty;
    private Richiedenti_tipo _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      EditRichiedenti_tipo.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      if (this.itemId != 0)
      {
        DataSet dataSet = new DataSet();
        TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo richiedentiTipo = new TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo();
        DataSet singleData = richiedentiTipo.GetSingleData(this.itemId);
        if (singleData.Tables[0].Rows.Count == 1)
        {
          DataRow row = singleData.Tables[0].Rows[0];
          if (row["DESCRIZIONE"] != DBNull.Value)
            ((TextBox) this.txtsdescrizione).Text = (string) row["DESCRIZIONE"];
          if (row["NOTE"] != DBNull.Value)
            ((TextBox) this.txtsnote).Text = row["NOTE"].ToString();
          this.lblOperazione.Text = "Modifica Tipo Richiedente";
          this.lblFirstAndLast.Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?');");
          this.lblFirstAndLast.Text = richiedentiTipo.GetFirstAndLastUser(row);
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Tipo Richiedente";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      if (this.Request["TipoOper"] == "read")
        this.AbilitaControlli(false);
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Richiedenti_tipo))
        return;
      this._fp = (Richiedenti_tipo) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.txtsdescrizione).Enabled = enabled;
      ((WebControl) this.txtsnote).Enabled = enabled;
      ((WebControl) this.btnsSalva).Enabled = enabled;
      ((WebControl) this.btnsElimina).Enabled = enabled;
      this.lblOperazione.Text = "Visualizzazione Tipo Richiedente";
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      ((Button) this.btnsElimina).Click += new EventHandler(this.btnsElimina_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      this.txtsdescrizione.set_DBDefaultValue((object) DBNull.Value);
      this.txtsnote.set_DBDefaultValue((object) DBNull.Value);
      ((TextBox) this.txtsdescrizione).Text = ((TextBox) this.txtsdescrizione).Text.Trim();
      ((TextBox) this.txtsnote).Text = ((TextBox) this.txtsnote).Text.Trim();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        int num = this.itemId != 0 ? new TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo().Update(CollezioneControlli, this.itemId) : new TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo().Add(CollezioneControlli);
        if (num == -11)
          SiteJavaScript.msgBox(this.Page, "Tipo Richiedente già inserito nel DataBase.");
        if (num <= 0)
          return;
        this.Server.Transfer("Richiedenti_tipo.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      try
      {
        this.txtsdescrizione.set_DBDefaultValue((object) DBNull.Value);
        this.txtsnote.set_DBDefaultValue((object) DBNull.Value);
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
        if (new TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo().Delete(CollezioneControlli, this.itemId) != -1)
          return;
        this.Server.Transfer("Richiedenti_tipo.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Richiedenti_tipo.aspx");
  }
}
