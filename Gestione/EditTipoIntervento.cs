// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditTipoIntervento
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

namespace TheSite.Gestione
{
  public class EditTipoIntervento : Page
  {
    protected Label lblOperazione;
    protected MessagePanel PanelMess;
    protected Panel PanelEdit;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected RequiredFieldValidator rfvEqstd;
    protected S_TextBox txtsdescrizionebreve;
    protected S_TextBox txtsdescrizione;
    protected ValidationSummary vlsEdit;
    private int itemId = 0;
    private int FunId = 0;
    private TipoIntervento _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["itemId"] != null)
        this.itemId = int.Parse(this.Request["itemId"]);
      if (this.Page.IsPostBack)
        return;
      if (this.itemId != 0)
      {
        TheSite.Classi.ClassiAnagrafiche.TipoIntervento tipoIntervento = new TheSite.Classi.ClassiAnagrafiche.TipoIntervento();
        DataSet dataSet = tipoIntervento.GetSingleData(this.itemId).Copy();
        if (dataSet.Tables[0].Rows.Count == 1)
        {
          DataRow row = dataSet.Tables[0].Rows[0];
          ((TextBox) this.txtsdescrizionebreve).Text = (string) row["descrizione_breve"];
          if (row["Descrizione"] != DBNull.Value)
            ((TextBox) this.txtsdescrizione).Text = (string) row["descrizione"];
          this.lblFirstAndLast.Text = tipoIntervento.GetFirstAndLastUser(row);
          this.lblOperazione.Text = "Modifica Tipo Intervento: " + ((TextBox) this.txtsdescrizionebreve).Text;
          this.lblFirstAndLast.Visible = true;
          ((Control) this.btnsElimina).Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Tipo Intervento";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (this.Context.Handler is TipoIntervento)
      {
        this._fp = (TipoIntervento) this.Context.Handler;
        this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
      }
      if (this.Request["TipoOper"] == "read")
      {
        ((WebControl) this.txtsdescrizione).Enabled = false;
        ((WebControl) this.txtsdescrizionebreve).Enabled = false;
        ((WebControl) this.btnsElimina).Enabled = false;
        ((WebControl) this.btnsSalva).Enabled = false;
      }
      else
      {
        ((WebControl) this.txtsdescrizione).Enabled = true;
        ((WebControl) this.txtsdescrizionebreve).Enabled = true;
        ((WebControl) this.btnsElimina).Enabled = true;
        ((WebControl) this.btnsSalva).Enabled = true;
      }
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
      TheSite.Classi.ClassiAnagrafiche.TipoIntervento tipoIntervento = new TheSite.Classi.ClassiAnagrafiche.TipoIntervento();
      this.txtsdescrizionebreve.set_DBDefaultValue((object) DBNull.Value);
      ((TextBox) this.txtsdescrizionebreve).Text = ((TextBox) this.txtsdescrizionebreve).Text.Trim().Replace("'", "`");
      this.txtsdescrizione.set_DBDefaultValue((object) DBNull.Value);
      ((TextBox) this.txtsdescrizione).Text = ((TextBox) this.txtsdescrizione).Text.Trim().Replace("'", "`");
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        if ((this.itemId != 0 ? tipoIntervento.Update(CollezioneControlli, this.itemId) : tipoIntervento.Add(CollezioneControlli)) == -11)
          SiteJavaScript.msgBox(this.Page, "Il tipo Intervento immesso é stato già inserito");
        else
          this.Server.Transfer("TipoIntervento.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("TipoIntervento.aspx");

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      TheSite.Classi.ClassiAnagrafiche.TipoIntervento tipoIntervento = new TheSite.Classi.ClassiAnagrafiche.TipoIntervento();
      this.txtsdescrizionebreve.set_DBDefaultValue((object) DBNull.Value);
      ((TextBox) this.txtsdescrizionebreve).Text = ((TextBox) this.txtsdescrizionebreve).Text.Trim();
      this.txtsdescrizione.set_DBDefaultValue((object) DBNull.Value);
      ((TextBox) this.txtsdescrizione).Text = ((TextBox) this.txtsdescrizione).Text.Trim();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        tipoIntervento.Delete(CollezioneControlli, this.itemId);
        this.Server.Transfer("TipoIntervento.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();
  }
}
