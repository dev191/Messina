// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditCategorie
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
  public class EditCategorie : Page
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
    private Categorie _fp;
    private DataSet _MyDs = new DataSet();
    private S_ControlsCollection _SCollection = new S_ControlsCollection();
    private TheSite.Classi.ClassiAnagrafiche.Categorie _Categorie = new TheSite.Classi.ClassiAnagrafiche.Categorie();

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      if (this.itemId != 0)
      {
        this._MyDs = this._Categorie.GetSingleData(this.itemId);
        if (this._MyDs.Tables[0].Rows.Count == 1)
        {
          DataRow row = this._MyDs.Tables[0].Rows[0];
          if (row["codice_categoria"] != DBNull.Value)
            ((TextBox) this.txtsCodice).Text = (string) row["codice_categoria"];
          if (row["descrizione"] != DBNull.Value)
            ((TextBox) this.txtsDescrizione).Text = row["descrizione"].ToString();
          if (row["note"] != DBNull.Value)
            ((TextBox) this.txtsNote).Text = row["note"].ToString();
          this.lblOperazione.Text = "Modifica Categoria: " + ((TextBox) this.txtsCodice).Text;
          this.lblFirstAndLast.Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          this.lblFirstAndLast.Text = this._Categorie.GetFirstAndLastUser(row);
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Categoria";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      if (this.Request["TipoOper"] == "read")
      {
        this.AbilitaControlli(false);
        this.lblOperazione.Text = "Visualizzazione Categoria: " + ((TextBox) this.txtsCodice).Text;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Categorie))
        return;
      this._fp = (Categorie) this.Context.Handler;
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
        int num = this.itemId != 0 ? this._Categorie.Update(this._SCollection, this.itemId) : this._Categorie.Add(this._SCollection);
        if (num > 0 && num != -11)
          this.Server.Transfer("Categorie.aspx");
        else
          SiteJavaScript.msgBox(this.Page, "Il Settore  é stato già inserito");
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
        switch (this._Categorie.Delete(this._SCollection, this.itemId))
        {
          case -5:
            this.PanelMess.ShowError("Impossibile eliminare in quanto ci sono Servizi assocciati", true);
            break;
          case -1:
            this.Server.Transfer("Categorie.aspx");
            break;
        }
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Categorie.aspx");
  }
}
