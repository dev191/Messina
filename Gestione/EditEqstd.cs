// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditEqstd
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;

namespace TheSite.Gestione
{
  public class EditEqstd : Page
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
    protected S_TextBox txtseq_std;
    protected S_TextBox txtsdescrizione;
    protected S_ComboBox cmbservizio;
    protected RequiredFieldValidator rfvEqstd;
    protected RequiredFieldValidator RequiredFieldValidator1;
    private Eqstd _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      this.BindServizi();
      if (this.itemId != 0)
      {
        DataSet dataSet = new DataSet();
        TheSite.Classi.ClassiAnagrafiche.Eqstd eqstd = new TheSite.Classi.ClassiAnagrafiche.Eqstd();
        DataSet singleData = eqstd.GetSingleData(this.itemId);
        if (singleData.Tables[0].Rows.Count == 1)
        {
          DataRow row = singleData.Tables[0].Rows[0];
          ((TextBox) this.txtseq_std).Text = (string) row["EQ_STD"];
          if (row["DESCRIZIONE"] != DBNull.Value)
            ((TextBox) this.txtsdescrizione).Text = row["DESCRIZIONE"].ToString();
          if (row["SERVIZIO_ID"] != DBNull.Value)
            ((ListControl) this.cmbservizio).SelectedValue = row["SERVIZIO_ID"].ToString();
          this.lblOperazione.Text = "Modifica Standard Apparecchiatura: " + ((TextBox) this.txtsdescrizione).Text;
          this.lblFirstAndLast.Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          this.lblFirstAndLast.Text = eqstd.GetFirstAndLastUser(row);
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Standard Apparecchiatura";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      if (this.Request["TipoOper"] == "read")
      {
        this.AbilitaControlli(false);
        this.lblOperazione.Text = "Visualizzazione Standard Apparecchiatura: " + ((TextBox) this.txtsdescrizione).Text;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Eqstd))
        return;
      this._fp = (Eqstd) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void BindServizi()
    {
      ((ListControl) this.cmbservizio).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiDettaglio.Servizi(HttpContext.Current.User.Identity.Name).GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbservizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "0");
      ((ListControl) this.cmbservizio).DataTextField = "DESCRIZIONE";
      ((ListControl) this.cmbservizio).DataValueField = "IDSERVIZIO";
      ((Control) this.cmbservizio).DataBind();
    }

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.txtseq_std).Enabled = enabled;
      ((WebControl) this.txtsdescrizione).Enabled = enabled;
      ((WebControl) this.cmbservizio).Enabled = enabled;
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
        TheSite.Classi.ClassiAnagrafiche.Eqstd eqstd = new TheSite.Classi.ClassiAnagrafiche.Eqstd();
        this.txtseq_std.set_DBDefaultValue((object) DBNull.Value);
        this.txtsdescrizione.set_DBDefaultValue((object) DBNull.Value);
        this.cmbservizio.set_DBDefaultValue((object) "-1");
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
        if (eqstd.Delete(CollezioneControlli, this.itemId) != -1)
          return;
        this.Server.Transfer("Eqstd.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      this.txtseq_std.set_DBDefaultValue((object) DBNull.Value);
      this.txtsdescrizione.set_DBDefaultValue((object) DBNull.Value);
      this.cmbservizio.set_DBDefaultValue((object) "-1");
      ((TextBox) this.txtseq_std).Text = ((TextBox) this.txtseq_std).Text.Trim();
      ((TextBox) this.txtsdescrizione).Text = ((TextBox) this.txtsdescrizione).Text.Trim();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        if ((this.itemId != 0 ? new TheSite.Classi.ClassiAnagrafiche.Eqstd().Update(CollezioneControlli, this.itemId) : new TheSite.Classi.ClassiAnagrafiche.Eqstd().Add(CollezioneControlli)) == -11)
          SiteJavaScript.msgBox(this.Page, "Lo Standard Apparecchiatura é stato già inserito");
        else
          this.Server.Transfer("Eqstd.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Eqstd.aspx");
  }
}
