// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditPercentualeStraordinari
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
  public class EditPercentualeStraordinari : Page
  {
    protected Label lblOperazione;
    protected MessagePanel PanelMess;
    protected S_TextBox txtsCodice;
    protected S_TextBox txtsPercentuale;
    protected Panel PanelEdit;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected ValidationSummary vlsEdit;
    protected RequiredFieldValidator RFVLivello;
    protected S_ComboBox cmbsLivello;
    private int itemId = 0;
    private int FunId = 0;
    private PercentualiStraordinari _fp;
    private DataSet _MyDs = new DataSet();
    private S_ControlsCollection _SCollection = new S_ControlsCollection();
    protected RequiredFieldValidator rfvCodice;
    protected CompareValidator CVPercentuale;
    protected RangeValidator RVPercentuale;
    protected RequiredFieldValidator rfvPercentuale;
    private TheSite.Classi.ClassiAnagrafiche.PercentualiStraordinari _PercentualiStraordinari = new TheSite.Classi.ClassiAnagrafiche.PercentualiStraordinari();

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      this.BindLivello();
      if (this.itemId != 0)
      {
        this._MyDs = this._PercentualiStraordinari.GetSingleData(this.itemId);
        if (this._MyDs.Tables[0].Rows.Count == 1)
        {
          DataRow row = this._MyDs.Tables[0].Rows[0];
          if (row["codicestraordinario"] != DBNull.Value)
            ((TextBox) this.txtsCodice).Text = (string) row["codicestraordinario"];
          if (row["percentuale"] != DBNull.Value)
            ((TextBox) this.txtsPercentuale).Text = row["percentuale"].ToString();
          if (row["livelli_id"] != DBNull.Value)
            ((ListControl) this.cmbsLivello).SelectedValue = row["livelli_id"].ToString();
          this.lblOperazione.Text = "Modifica Percentuale Straordinari: " + ((TextBox) this.txtsCodice).Text;
          this.lblFirstAndLast.Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          this.lblFirstAndLast.Text = this._PercentualiStraordinari.GetFirstAndLastUser(row);
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Percentuale Straordinari";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      if (this.Request["TipoOper"] == "read")
      {
        this.AbilitaControlli(false);
        this.lblOperazione.Text = "Visualizzazione Percentuale Straordinari: " + ((TextBox) this.txtsCodice).Text;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is PercentualiStraordinari))
        return;
      this._fp = (PercentualiStraordinari) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    private void BindLivello()
    {
      TheSite.Classi.ClassiAnagrafiche.Livelli livelli = new TheSite.Classi.ClassiAnagrafiche.Livelli();
      ((ListControl) this.cmbsLivello).Items.Clear();
      this._MyDs = livelli.GetData().Copy();
      if (this._MyDs.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsLivello).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(this._MyDs.Tables[0], "codicelivello", "id", "- Selezionare un Livello -", "-1");
      ((ListControl) this.cmbsLivello).DataTextField = "codicelivello";
      ((ListControl) this.cmbsLivello).DataValueField = "id";
      ((Control) this.cmbsLivello).DataBind();
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

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.txtsCodice).Enabled = enabled;
      ((WebControl) this.txtsPercentuale).Enabled = enabled;
      ((WebControl) this.cmbsLivello).Enabled = enabled;
      ((WebControl) this.btnsSalva).Enabled = enabled;
      ((WebControl) this.btnsElimina).Enabled = enabled;
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      this.txtsCodice.set_DBDefaultValue((object) DBNull.Value);
      this.txtsPercentuale.set_DBDefaultValue((object) 0);
      ((TextBox) this.txtsCodice).Text = ((TextBox) this.txtsCodice).Text.Trim();
      ((TextBox) this.txtsPercentuale).Text = ((TextBox) this.txtsPercentuale).Text.Trim();
      this._SCollection.AddItems((object) this.PanelEdit.Controls);
      try
      {
        int num = this.itemId != 0 ? this._PercentualiStraordinari.Update(this._SCollection, this.itemId) : this._PercentualiStraordinari.Add(this._SCollection);
        if (num > 0 && num != -11)
          this.Server.Transfer("PercentualiStraordinari.aspx");
        else
          SiteJavaScript.msgBox(this.Page, "La _Percentuale  é stato già inserita");
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
        this.txtsPercentuale.set_DBDefaultValue((object) DBNull.Value);
        this.cmbsLivello.set_DBDefaultValue((object) 0);
        this._SCollection.AddItems((object) this.PanelEdit.Controls);
        if (this._PercentualiStraordinari.Delete(this._SCollection, this.itemId) != -1)
          return;
        this.Server.Transfer("PercentualiStraordinari.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("PercentualiStraordinari.aspx");
  }
}
