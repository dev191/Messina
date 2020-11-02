// Decompiled with JetBrains decompiler
// Type: TheSite.Admin.EditFunzioni
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

namespace TheSite.Admin
{
  public class EditFunzioni : Page
  {
    protected Label lblOperazione;
    protected Panel PanelEdit;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected S_TextBox txtsCodice;
    protected S_TextBox txtsDescrizione;
    protected Label lblFirstAndLast;
    private int FunId = 0;
    protected ValidationSummary vlsEdit;
    protected RequiredFieldValidator rfvDescrizione;
    protected S_TextBox txtsLink;
    protected S_TextBox txtsLinkHelp;
    protected MessagePanel PanelMess;
    private int itemId = 0;
    private Funzioni _fp;
    private clMyCollection _myColl = new clMyCollection();

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request.Params["FunId"]);
      if (this.Request.Params["ItemId"] != null)
        this.itemId = int.Parse(this.Request.Params["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      if (this.Context.Handler is Funzioni)
      {
        this._fp = (Funzioni) this.Context.Handler;
        this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
      }
      if (this.itemId != 0)
      {
        Funzione funzione = new Funzione();
        DataSet dataSet = funzione.GetSingleData(this.itemId).Copy();
        if (dataSet.Tables[0].Rows.Count == 1)
        {
          DataRow row = dataSet.Tables[0].Rows[0];
          ((TextBox) this.txtsDescrizione).Text = (string) row["DESCRIZIONE"];
          if (row["CODICE"] != DBNull.Value)
            ((TextBox) this.txtsCodice).Text = (string) row["CODICE"];
          if (row["LINK"] != DBNull.Value)
            ((TextBox) this.txtsLink).Text = (string) row["LINK"];
          if (row["LINK_HELP"] != DBNull.Value)
            ((TextBox) this.txtsLinkHelp).Text = (string) row["LINK_HELP"];
          this.lblFirstAndLast.Text = funzione.GetFirstAndLastUser(row);
          this.lblOperazione.Text = "Modifica";
          this.lblFirstAndLast.Visible = true;
          ((Control) this.btnsElimina).Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
        }
      }
      else
      {
        this.lblOperazione.Text = "Nuovo";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
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

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Funzioni.aspx?FunId=" + (object) this.FunId);

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      this.txtsCodice.set_DBDefaultValue((object) DBNull.Value);
      this.txtsLink.set_DBDefaultValue((object) DBNull.Value);
      this.txtsLinkHelp.set_DBDefaultValue((object) DBNull.Value);
      Funzione funzione = new Funzione();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        if ((this.itemId != 0 ? funzione.Update(CollezioneControlli, this.itemId) : funzione.Add(CollezioneControlli)) <= 0)
          return;
        this.Response.Redirect((string) this.ViewState["UrlReferrer"]);
      }
      catch
      {
        this.PanelMess.ShowError("Errore: aggiornamento non riuscito", true);
      }
    }

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      this.txtsDescrizione.set_DBDefaultValue((object) DBNull.Value);
      this.txtsCodice.set_DBDefaultValue((object) DBNull.Value);
      this.txtsLinkHelp.set_DBDefaultValue((object) DBNull.Value);
      this.txtsLink.set_DBDefaultValue((object) DBNull.Value);
      Funzione funzione = new Funzione();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        if (funzione.Delete(CollezioneControlli, this.itemId) != -1)
          return;
        this.Response.Redirect((string) this.ViewState["UrlReferrer"]);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        this.PanelMess.ShowError("Errore: cancellazione non riuscita", true);
      }
    }
  }
}
