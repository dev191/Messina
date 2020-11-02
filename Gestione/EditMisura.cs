// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditMisura
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
  public class EditMisura : Page
  {
    protected MessagePanel PanelMess;
    protected Panel PanelEdit;
    private int itemId = 0;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected ValidationSummary vlsEdit;
    protected Label lblOperazione;
    private int FunId = 0;
    protected S_TextBox txtCodMisura;
    protected S_TextBox txtDescMisura;
    protected RequiredFieldValidator rfvCodMisura;
    protected RequiredFieldValidator rfvDescMisura;
    private UnitaMisura _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      if (this.itemId != 0)
      {
        DataSet dataSet = new DataSet();
        TheSite.Classi.ClassiAnagrafiche.UnitaMisura unitaMisura = new TheSite.Classi.ClassiAnagrafiche.UnitaMisura();
        DataSet singleData = unitaMisura.GetSingleData(this.itemId);
        if (singleData.Tables[0].Rows.Count == 1)
        {
          DataRow row = singleData.Tables[0].Rows[0];
          ((TextBox) this.txtCodMisura).Text = (string) row["ucodice"];
          if (row["udescrizione"] != DBNull.Value)
            ((TextBox) this.txtDescMisura).Text = row["udescrizione"].ToString();
          this.lblOperazione.Text = "Modifica Unità di Misura: " + ((TextBox) this.txtCodMisura).Text;
          this.lblFirstAndLast.Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          this.lblFirstAndLast.Text = unitaMisura.GetFirstAndLastUser(row);
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Unità di Misura";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      if (this.Request["TipoOper"] == "read")
      {
        this.AbilitaControlli(false);
        this.lblOperazione.Text = "Visualizzazione Unità di Misura: " + ((TextBox) this.txtCodMisura).Text;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is UnitaMisura))
        return;
      this._fp = (UnitaMisura) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.txtCodMisura).Enabled = enabled;
      ((WebControl) this.txtDescMisura).Enabled = enabled;
      ((WebControl) this.btnsSalva).Enabled = enabled;
      ((WebControl) this.btnsElimina).Enabled = enabled;
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

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      try
      {
        TheSite.Classi.ClassiAnagrafiche.UnitaMisura unitaMisura = new TheSite.Classi.ClassiAnagrafiche.UnitaMisura();
        this.txtCodMisura.set_DBDefaultValue((object) DBNull.Value);
        this.txtDescMisura.set_DBDefaultValue((object) DBNull.Value);
        ((TextBox) this.txtCodMisura).Text = ((TextBox) this.txtCodMisura).Text.Trim();
        ((TextBox) this.txtDescMisura).Text = ((TextBox) this.txtDescMisura).Text.Trim();
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
        switch (unitaMisura.Delete(CollezioneControlli, this.itemId))
        {
          case -5:
            this.PanelMess.ShowMessage("Impossibile eliminare l'unita di misura in quanto legata ad un materiale");
            break;
          case -1:
            this.Server.Transfer("UnitaMisura.aspx?FunId =" + (object) this.FunId);
            break;
          default:
            this.PanelMess.ShowMessage("Impossibile eliminare");
            break;
        }
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      this.txtCodMisura.set_DBDefaultValue((object) DBNull.Value);
      this.txtDescMisura.set_DBDefaultValue((object) DBNull.Value);
      ((TextBox) this.txtCodMisura).Text = ((TextBox) this.txtCodMisura).Text.Trim();
      ((TextBox) this.txtDescMisura).Text = ((TextBox) this.txtDescMisura).Text.Trim();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        if ((this.itemId != 0 ? new TheSite.Classi.ClassiAnagrafiche.UnitaMisura().Update(CollezioneControlli, this.itemId) : new TheSite.Classi.ClassiAnagrafiche.UnitaMisura().Add(CollezioneControlli)) == -11)
          SiteJavaScript.msgBox(this.Page, "L'unità di misura con stesso codice é già stata inserita");
        else
          this.Server.Transfer("UnitaMisura.aspx?FunId =" + (object) this.FunId);
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("UnitaMisura.aspx");
  }
}
