// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditAnagrafica
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;

namespace TheSite.Gestione
{
  public class EditAnagrafica : Page
  {
    protected MessagePanel PanelMess;
    protected Panel PanelEdit;
    protected S_TextBox txtsNote;
    protected S_TextBox txtsCodice;
    protected S_TextBox txtsDescrizione;
    private int itemId = 0;
    protected RequiredFieldValidator rfvDescrizione;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected ValidationSummary vlsEdit;
    protected Label lblOperazione;
    private int FunId = 0;
    protected RequiredFieldValidator RvfCodice;
    protected string s_Pagina;
    private string strNomePagina;
    public static string Codice = string.Empty;

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["Pagina"] != null)
        this.s_Pagina = this.Request["Pagina"];
      if (this.Page.IsPostBack)
        return;
      PropertyInfo property = this.Context.Handler.GetType().GetProperty("_Contenitore");
      if (property != null)
        this.ViewState.Add("mioContenitore", property.GetValue((object) this.Context.Handler, (object[]) null));
      if (this.Context.Items[(object) "FunId"] != null)
        this.FunId = int.Parse(this.Context.Items[(object) "FunId"].ToString());
      if (this.Context.Items[(object) "ItemId"] != null)
      {
        this.itemId = int.Parse(this.Context.Items[(object) "ItemId"].ToString());
        this.ViewState["ItemId"] = (object) int.Parse(this.Context.Items[(object) "ItemId"].ToString());
      }
      else
        this.ViewState["ItemId"] = (object) 0;
      if (this.Context.Items[(object) "Pagina"] != null)
        this.s_Pagina = (string) this.Context.Items[(object) "Pagina"];
      this.ViewState["s_Pagina"] = (object) this.s_Pagina;
      switch (this.s_Pagina)
      {
        case "Servizi":
          this.strNomePagina = "Servizio";
          EditAnagrafica.Codice = "Codice Servizio";
          break;
        case "TipologiaDitta":
          this.strNomePagina = "Tipologia Ditta";
          EditAnagrafica.Codice = "Codice Tipologia Ditta";
          break;
        case "TipoManutenzione":
          this.strNomePagina = "Tipo Manutenzione";
          EditAnagrafica.Codice = "Codice Tipo Manutenzione";
          break;
      }
      if (this.itemId != 0)
      {
        DataSet dataSet = new DataSet();
        switch (this.s_Pagina)
        {
          case "Servizi":
            dataSet = new TheSite.Classi.ClassiDettaglio.Servizi().GetSingleData(this.itemId).Copy();
            break;
          case "TipologiaDitta":
            dataSet = new TheSite.Classi.ClassiAnagrafiche.TipologiaDitta().GetSingleData(this.itemId).Copy();
            break;
          case "TipoManutenzione":
            dataSet = new TheSite.Classi.ClassiAnagrafiche.TipoManutenzione().GetSingleData(this.itemId);
            break;
        }
        if (dataSet.Tables[0].Rows.Count == 1)
        {
          DataRow row = dataSet.Tables[0].Rows[0];
          ((TextBox) this.txtsDescrizione).Text = (string) row["DESCRIZIONE"];
          if (row["NOTE"] != DBNull.Value)
            ((TextBox) this.txtsNote).Text = (string) row["NOTE"];
          if (row["CODICE"] != DBNull.Value)
            ((TextBox) this.txtsCodice).Text = (string) row["CODICE"];
          this.lblOperazione.Text = "Modifica " + this.strNomePagina;
          this.lblFirstAndLast.Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          switch (this.s_Pagina)
          {
            case "Servizi":
              this.lblFirstAndLast.Text = new TheSite.Classi.ClassiDettaglio.Servizi().GetFirstAndLastUser(row);
              break;
            case "TipologiaDitta":
              this.lblFirstAndLast.Text = new TheSite.Classi.ClassiAnagrafiche.Ditte().GetFirstAndLastUser(row);
              break;
            case "TipoManutenzione":
              this.lblFirstAndLast.Text = new TheSite.Classi.ClassiAnagrafiche.TipoManutenzione().GetFirstAndLastUser(row);
              break;
          }
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento " + this.strNomePagina;
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      if (!((string) this.Context.Items[(object) "TipoOper"] == "read"))
        return;
      this.AbilitaControlli(false);
    }

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.txtsNote).Enabled = enabled;
      ((WebControl) this.txtsDescrizione).Enabled = enabled;
      ((WebControl) this.txtsCodice).Enabled = enabled;
      ((WebControl) this.btnsElimina).Enabled = enabled;
      ((WebControl) this.btnsSalva).Enabled = enabled;
      this.lblOperazione.Text = "Visualizzazione " + this.strNomePagina;
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
      this.txtsNote.set_DBDefaultValue((object) DBNull.Value);
      this.txtsDescrizione.set_DBDefaultValue((object) DBNull.Value);
      this.txtsCodice.set_DBDefaultValue((object) DBNull.Value);
      ((TextBox) this.txtsNote).Text = ((TextBox) this.txtsNote).Text.Trim();
      ((TextBox) this.txtsDescrizione).Text = ((TextBox) this.txtsDescrizione).Text.Trim();
      ((TextBox) this.txtsCodice).Text = ((TextBox) this.txtsCodice).Text.Trim();
      int num = 0;
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        int itemId = int.Parse(this.ViewState["ItemId"].ToString());
        string str = (string) this.ViewState["s_Pagina"];
        if (itemId == 0)
        {
          switch (this.s_Pagina)
          {
            case "Servizi":
              num = new TheSite.Classi.ClassiDettaglio.Servizi().Add(CollezioneControlli);
              break;
            case "TipologiaDitta":
              num = new TheSite.Classi.ClassiAnagrafiche.TipologiaDitta().Add(CollezioneControlli);
              break;
            case "TipoManutenzione":
              num = new TheSite.Classi.ClassiAnagrafiche.TipoManutenzione().Add(CollezioneControlli);
              break;
          }
        }
        else
        {
          switch (str)
          {
            case "Servizi":
              num = new TheSite.Classi.ClassiDettaglio.Servizi().Update(CollezioneControlli, itemId);
              break;
            case "TipologiaDitta":
              num = new TheSite.Classi.ClassiAnagrafiche.TipologiaDitta().Update(CollezioneControlli, itemId);
              break;
            case "TipoManutenzione":
              num = new TheSite.Classi.ClassiAnagrafiche.TipoManutenzione().Update(CollezioneControlli, itemId);
              break;
          }
        }
        if (num > 0 && num != -11)
          this.Server.Transfer(this.ViewState["s_Pagina"].ToString() + ".aspx");
        else
          SiteJavaScript.msgBox(this.Page, "La Descrizione é stata già inserita");
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
        this.txtsNote.set_DBDefaultValue((object) DBNull.Value);
        this.txtsDescrizione.set_DBDefaultValue((object) DBNull.Value);
        this.txtsCodice.set_DBDefaultValue((object) DBNull.Value);
        int itemId = int.Parse(this.ViewState["ItemId"].ToString());
        string str = (string) this.ViewState["s_Pagina"];
        int num = 0;
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
        switch (str)
        {
          case "Servizi":
            num = new TheSite.Classi.ClassiDettaglio.Servizi().Delete(CollezioneControlli, itemId);
            break;
          case "TipologiaDitta":
            num = new TheSite.Classi.ClassiAnagrafiche.TipologiaDitta().Delete(CollezioneControlli, itemId);
            break;
          case "TipoManutenzione":
            num = new TheSite.Classi.ClassiAnagrafiche.TipoManutenzione().Delete(CollezioneControlli, itemId);
            break;
        }
        if (num != -1)
          return;
        this.Server.Transfer(this.ViewState["s_Pagina"].ToString() + ".aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer(this.ViewState["s_Pagina"].ToString() + ".aspx");
  }
}
