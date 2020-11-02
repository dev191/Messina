// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditServizi
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
  public class EditServizi : Page
  {
    protected Label lblOperazione;
    protected MessagePanel PanelMess;
    protected RequiredFieldValidator rfvSettore;
    protected S_ComboBox cmbsSettore;
    protected RequiredFieldValidator rfvCodice;
    protected S_TextBox txtsCodice;
    protected S_TextBox txtsDescrizione;
    protected RequiredFieldValidator rfvPercentuale;
    protected Panel PanelEdit;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected ValidationSummary vlsEdit;
    protected S_TextBox txtsNote;
    private int itemId = 0;
    private int FunId = 0;
    private Servizi _fp;
    private DataSet _MyDs = new DataSet();
    private S_ControlsCollection _SCollection = new S_ControlsCollection();
    private TheSite.Classi.ClassiDettaglio.Servizi _Servizi = new TheSite.Classi.ClassiDettaglio.Servizi();

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      this.BindSettore();
      if (this.itemId != 0)
      {
        this._MyDs = this._Servizi.GetSingleData(this.itemId);
        if (this._MyDs.Tables[0].Rows.Count == 1)
        {
          DataRow row = this._MyDs.Tables[0].Rows[0];
          if (row["descrizione"] != DBNull.Value)
            ((TextBox) this.txtsDescrizione).Text = (string) row["descrizione"];
          if (row["note"] != DBNull.Value)
            ((TextBox) this.txtsNote).Text = row["note"].ToString();
          if (row["codice"] != DBNull.Value)
            ((TextBox) this.txtsCodice).Text = row["codice"].ToString();
          if (row["settore_id"] != DBNull.Value)
            ((ListControl) this.cmbsSettore).SelectedValue = row["settore_id"].ToString();
          this.lblOperazione.Text = "Modifica Servizio: " + ((TextBox) this.txtsCodice).Text;
          this.lblFirstAndLast.Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          this.lblFirstAndLast.Text = this._Servizi.GetFirstAndLastUser(row);
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Servizi";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      if (this.Request["TipoOper"] == "read")
      {
        this.AbilitaControlli(false);
        this.lblOperazione.Text = "Visualizzazione Servizio: " + ((TextBox) this.txtsCodice).Text;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Servizi))
        return;
      this._fp = (Servizi) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    private void BindSettore()
    {
      TheSite.Classi.ClassiAnagrafiche.Settori settori = new TheSite.Classi.ClassiAnagrafiche.Settori();
      ((ListControl) this.cmbsSettore).Items.Clear();
      DataSet dataSet = settori.GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsSettore).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "settore", "idsettore", "- Selezionare un Settore -", "-1");
      ((ListControl) this.cmbsSettore).DataTextField = "settore";
      ((ListControl) this.cmbsSettore).DataValueField = "idsettore";
      ((Control) this.cmbsSettore).DataBind();
    }

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.txtsCodice).Enabled = enabled;
      ((WebControl) this.txtsDescrizione).Enabled = enabled;
      ((WebControl) this.txtsNote).Enabled = enabled;
      ((WebControl) this.cmbsSettore).Enabled = enabled;
      ((WebControl) this.btnsSalva).Enabled = enabled;
      ((WebControl) this.btnsElimina).Enabled = enabled;
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

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
      this.cmbsSettore.set_DBDefaultValue((object) -1);
      ((TextBox) this.txtsCodice).Text = ((TextBox) this.txtsCodice).Text.Trim();
      ((TextBox) this.txtsDescrizione).Text = ((TextBox) this.txtsDescrizione).Text.Trim();
      ((TextBox) this.txtsNote).Text = ((TextBox) this.txtsNote).Text.Trim();
      this._SCollection.AddItems((object) this.PanelEdit.Controls);
      try
      {
        int num = this.itemId != 0 ? this._Servizi.Update(this._SCollection, this.itemId) : this._Servizi.Add(this._SCollection);
        if (num > 0 && num != -11)
          this.Server.Transfer("Servizi.aspx");
        else
          SiteJavaScript.msgBox(this.Page, "Il servizio  é stato già inserita");
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
        this.cmbsSettore.set_DBDefaultValue((object) -1);
        this._SCollection.AddItems((object) this.PanelEdit.Controls);
        if (this._Servizi.Delete(this._SCollection, this.itemId) != -1)
          return;
        this.Server.Transfer("Servizi.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Servizi.aspx");
  }
}
