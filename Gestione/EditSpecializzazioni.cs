// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditSpecializzazioni
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
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
  public class EditSpecializzazioni : Page
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
    protected RequiredFieldValidator rvfdescrizione;
    public static string HelpLink = string.Empty;
    protected RequiredFieldValidator rfvServizio;
    protected S_ComboBox cmbsServizio;
    private Specializzazioni _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      EditSpecializzazioni.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      this.BindServizi();
      if (this.itemId != 0)
      {
        DataSet dataSet = new DataSet();
        TheSite.Classi.ClassiAnagrafiche.Addetti addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
        DataSet singleDataTr = addetti.GetSingleDataTR(this.itemId);
        if (singleDataTr.Tables[0].Rows.Count == 1)
        {
          DataRow row = singleDataTr.Tables[0].Rows[0];
          ((TextBox) this.txtsdescrizione).Text = (string) row["DESCRIZIONE"];
          if (row["servizi_id"] != DBNull.Value)
            ((ListControl) this.cmbsServizio).SelectedValue = row["servizi_id"].ToString();
          this.lblOperazione.Text = "Modifica Specializzazione";
          this.lblFirstAndLast.Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?');");
          this.lblFirstAndLast.Text = addetti.GetFirstAndLastUser(row);
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Specializzazione";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      if (this.Request["TipoOper"] == "read")
        this.AbilitaControlli(false);
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Specializzazioni))
        return;
      this._fp = (Specializzazioni) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.txtsdescrizione).Enabled = enabled;
      ((WebControl) this.cmbsServizio).Enabled = enabled;
      ((WebControl) this.btnsSalva).Enabled = enabled;
      ((WebControl) this.btnsElimina).Enabled = enabled;
      this.lblOperazione.Text = "Visualizzazione Specializzazione";
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
      this.cmbsServizio.set_DBDefaultValue((object) 0);
      ((TextBox) this.txtsdescrizione).Text = ((TextBox) this.txtsdescrizione).Text.Trim();
      string text = ((TextBox) this.txtsdescrizione).Text;
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_tr_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(1);
      ((ParameterObject) sObject).set_Size(50);
      ((ParameterObject) sObject).set_Value((object) text);
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      CollezioneControlli.Add(sObject);
      try
      {
        int num = this.itemId != 0 ? new TheSite.Classi.ClassiAnagrafiche.Addetti().ExecuteUpdateTR(CollezioneControlli, "Update", this.itemId) : new TheSite.Classi.ClassiAnagrafiche.Addetti().ExecuteUpdateTR(CollezioneControlli, "Insert", this.itemId);
        if (num > 0 && num != -11)
          this.Server.Transfer("Specializzazioni.aspx");
        else
          SiteJavaScript.msgBox(this.Page, "La Specializzazione é stata già inserita");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void BindServizi()
    {
      ((ListControl) this.cmbsServizio).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiDettaglio.Servizi().GetServizi().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "id", "- Selezionare un Servizio -", "");
      ((ListControl) this.cmbsServizio).DataTextField = "descrizione";
      ((ListControl) this.cmbsServizio).DataValueField = "id";
      ((Control) this.cmbsServizio).DataBind();
    }

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      try
      {
        this.txtsdescrizione.set_DBDefaultValue((object) DBNull.Value);
        string text = ((TextBox) this.txtsdescrizione).Text;
        S_Object sObject = new S_Object();
        ((ParameterObject) sObject).set_ParameterName("p_tr_id");
        ((ParameterObject) sObject).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject).set_Index(1);
        ((ParameterObject) sObject).set_Size(50);
        ((ParameterObject) sObject).set_Value((object) text);
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
        CollezioneControlli.Add(sObject);
        switch (new TheSite.Classi.ClassiAnagrafiche.Addetti().ExecuteUpdateTR(CollezioneControlli, "Delete", this.itemId))
        {
          case -6:
            this.PanelMess.ShowMessage("Impossibile eliminare in quanto legata ad una Procedure di Manutenzione Programmata");
            break;
          case -5:
            this.PanelMess.ShowMessage("Impossibile eliminare in quanto legata ad un addetto");
            break;
          case -1:
            this.Server.Transfer("Specializzazioni.aspx");
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

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Specializzazioni.aspx");
  }
}
