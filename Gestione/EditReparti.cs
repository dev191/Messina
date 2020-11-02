// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditReparti
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
  public class EditReparti : Page
  {
    protected Label lblOperazione;
    protected MessagePanel PanelMess;
    protected RequiredFieldValidator rfvCodice;
    protected S_TextBox txtsCodice;
    protected S_TextBox txtsDescrizione;
    protected Panel PanelEdit;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected ValidationSummary vlsEdit;
    protected S_TextBox txtsNote;
    protected RequiredFieldValidator rfvDescrizione;
    private int itemId = 0;
    private int FunId = 0;
    private Reparti _fp;
    private DataSet _MyDs = new DataSet();
    private S_ControlsCollection _SCollection = new S_ControlsCollection();
    private TheSite.Classi.ClassiAnagrafiche.Reparti _Reparti = new TheSite.Classi.ClassiAnagrafiche.Reparti();

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      if (this.itemId != 0)
      {
        this._MyDs = this._Reparti.GetSingleData(this.itemId);
        if (this._MyDs.Tables[0].Rows.Count == 1)
        {
          DataRow row = this._MyDs.Tables[0].Rows[0];
          if (row["codice_reparto"] != DBNull.Value)
            ((TextBox) this.txtsCodice).Text = (string) row["codice_reparto"];
          if (row["descrizione"] != DBNull.Value)
            ((TextBox) this.txtsDescrizione).Text = row["descrizione"].ToString();
          if (row["note"] != DBNull.Value)
            ((TextBox) this.txtsNote).Text = row["note"].ToString();
          this.lblOperazione.Text = "Modifica Reparto: " + ((TextBox) this.txtsCodice).Text;
          this.lblFirstAndLast.Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          this.lblFirstAndLast.Text = this._Reparti.GetFirstAndLastUser(row);
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Reparto";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      if (this.Request["TipoOper"] == "read")
      {
        this.AbilitaControlli(false);
        this.lblOperazione.Text = "Visualizzazione Reparto: " + ((TextBox) this.txtsCodice).Text;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Reparti))
        return;
      this._fp = (Reparti) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.txtsCodice).Enabled = enabled;
      ((WebControl) this.txtsDescrizione).Enabled = enabled;
      ((WebControl) this.txtsNote).Enabled = enabled;
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

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      this.txtsCodice.set_DBDefaultValue((object) DBNull.Value);
      this.txtsDescrizione.set_DBDefaultValue((object) DBNull.Value);
      this.txtsNote.set_DBDefaultValue((object) DBNull.Value);
      ((TextBox) this.txtsCodice).Text = ((TextBox) this.txtsCodice).Text.Trim();
      ((TextBox) this.txtsDescrizione).Text = ((TextBox) this.txtsDescrizione).Text.Trim();
      ((TextBox) this.txtsNote).Text = ((TextBox) this.txtsNote).Text.Trim();
      this._SCollection.AddItems((object) this.PanelEdit.Controls);
      try
      {
        int num = this.itemId != 0 ? this._Reparti.Update(this._SCollection, this.itemId) : this._Reparti.Add(this._SCollection);
        if (num > 0 && num != -11)
          this.Server.Transfer("Reparti.aspx");
        else
          SiteJavaScript.msgBox(this.Page, "Il Reparto  é stato già inserito");
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
        this.txtsCodice.set_DBDefaultValue((object) DBNull.Value);
        this.txtsDescrizione.set_DBDefaultValue((object) DBNull.Value);
        this.txtsNote.set_DBDefaultValue((object) DBNull.Value);
        this._SCollection.AddItems((object) this.PanelEdit.Controls);
        switch (this._Reparti.Delete(this._SCollection, this.itemId))
        {
          case -5:
            this.PanelMess.ShowError("Impossibile eliminare il reparto in quanto associato ad una stanza", true);
            break;
          case -1:
            this.Server.Transfer("Reparti.aspx");
            break;
        }
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Reparti.aspx");
  }
}
