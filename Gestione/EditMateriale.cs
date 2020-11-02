// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditMateriale
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;

namespace TheSite.Gestione
{
  public class EditMateriale : Page
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
    protected S_TextBox txtCodMateriale;
    protected S_TextBox txtDescMateriale;
    protected TextBox txtPrezzoIntero;
    protected TextBox txtPrezzoDecimale;
    protected S_ComboBox cmbUnita;
    protected RequiredFieldValidator rfvCodMat;
    protected RequiredFieldValidator rfvDescrizione;
    protected RequiredFieldValidator rfvUnita;
    protected RegularExpressionValidator regIntero;
    protected RegularExpressionValidator regDecimale;
    private ListaMateriali _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      this.BindUnita();
      if (this.itemId != 0)
      {
        DataSet dataSet = new DataSet();
        TheSite.Classi.ClassiAnagrafiche.ListaMateriali listaMateriali = new TheSite.Classi.ClassiAnagrafiche.ListaMateriali();
        DataSet singleData = listaMateriali.GetSingleData(this.itemId);
        if (singleData.Tables[0].Rows.Count == 1)
        {
          DataRow row = singleData.Tables[0].Rows[0];
          ((TextBox) this.txtCodMateriale).Text = (string) row["mcodice"];
          if (row["mdescrizione"] != DBNull.Value)
            ((TextBox) this.txtDescMateriale).Text = row["mdescrizione"].ToString();
          if (row["unitaid"] != DBNull.Value)
            ((ListControl) this.cmbUnita).SelectedValue = row["unitaid"].ToString();
          if (row["mprezzo"] != DBNull.Value)
          {
            this.txtPrezzoIntero.Text = TheSite.Classi.Function.GetTypeNumber(row["mprezzo"], NumberType.Intero).ToString();
            this.txtPrezzoDecimale.Text = TheSite.Classi.Function.GetTypeNumber(row["mprezzo"], NumberType.Decimale).ToString();
          }
          this.lblOperazione.Text = "Modifica Materiale: " + ((TextBox) this.txtCodMateriale).Text;
          this.lblFirstAndLast.Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          this.lblFirstAndLast.Text = listaMateriali.GetFirstAndLastUser(row);
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Materiale";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      if (this.Request["TipoOper"] == "read")
      {
        this.AbilitaControlli(false);
        this.lblOperazione.Text = "Visualizzazione Materiale: " + ((TextBox) this.txtCodMateriale).Text;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is ListaMateriali))
        return;
      this._fp = (ListaMateriali) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void BindUnita()
    {
      ((ListControl) this.cmbUnita).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiDettaglio.UnitaMisura(HttpContext.Current.User.Identity.Name).GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbUnita).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE_COD", "IDUNITA", "- Selezionare Unità di Misura -", "0");
      ((ListControl) this.cmbUnita).DataTextField = "DESCRIZIONE_COD";
      ((ListControl) this.cmbUnita).DataValueField = "IDUNITA";
      ((Control) this.cmbUnita).DataBind();
    }

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.txtCodMateriale).Enabled = enabled;
      ((WebControl) this.txtDescMateriale).Enabled = enabled;
      this.txtPrezzoIntero.Enabled = enabled;
      this.txtPrezzoDecimale.Enabled = enabled;
      ((WebControl) this.cmbUnita).Enabled = enabled;
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
        TheSite.Classi.ClassiAnagrafiche.ListaMateriali listaMateriali = new TheSite.Classi.ClassiAnagrafiche.ListaMateriali();
        this.txtCodMateriale.set_DBDefaultValue((object) DBNull.Value);
        this.txtDescMateriale.set_DBDefaultValue((object) DBNull.Value);
        this.cmbUnita.set_DBDefaultValue((object) "-1");
        ((TextBox) this.txtCodMateriale).Text = ((TextBox) this.txtCodMateriale).Text.Trim();
        ((TextBox) this.txtDescMateriale).Text = ((TextBox) this.txtDescMateriale).Text.Trim();
        this.cmbUnita.set_DBDefaultValue((object) "-1");
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject = new S_Object();
        ((ParameterObject) sObject).set_ParameterName("p_prezzo");
        ((ParameterObject) sObject).set_DbType((CustomDBType) 4);
        ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject).set_Index(3);
        ((ParameterObject) sObject).set_Value((object) double.Parse(this.txtPrezzoIntero.Text.Trim() + "," + this.txtPrezzoDecimale.Text.Trim()));
        CollezioneControlli.Add(sObject);
        CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
        if (listaMateriali.Delete(CollezioneControlli, this.itemId) != -1)
          return;
        this.Server.Transfer("ListaMateriali.aspx?FunId =" + (object) this.FunId);
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      this.txtCodMateriale.set_DBDefaultValue((object) DBNull.Value);
      this.txtDescMateriale.set_DBDefaultValue((object) DBNull.Value);
      this.cmbUnita.set_DBDefaultValue((object) "-1");
      ((TextBox) this.txtCodMateriale).Text = ((TextBox) this.txtCodMateriale).Text.Trim();
      ((TextBox) this.txtDescMateriale).Text = ((TextBox) this.txtDescMateriale).Text.Trim();
      this.cmbUnita.set_DBDefaultValue((object) "-1");
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_prezzo");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(3);
      ((ParameterObject) sObject).set_Value((object) double.Parse(this.txtPrezzoIntero.Text.Trim() + "," + this.txtPrezzoDecimale.Text.Trim()));
      CollezioneControlli.Add(sObject);
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        if ((this.itemId != 0 ? new TheSite.Classi.ClassiAnagrafiche.ListaMateriali().Update(CollezioneControlli, this.itemId) : new TheSite.Classi.ClassiAnagrafiche.ListaMateriali().Add(CollezioneControlli)) == -11)
          SiteJavaScript.msgBox(this.Page, "Materiale con stesso codice é stato già inserito");
        else
          this.Server.Transfer("ListaMateriali.aspx?FunId =" + (object) this.FunId);
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("ListaMateriali.aspx");
  }
}
