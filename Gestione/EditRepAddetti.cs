// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditRepAddetti
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
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;

namespace TheSite.Gestione
{
  public class EditRepAddetti : Page
  {
    protected MessagePanel PanelMess;
    protected Panel PanelEdit;
    private int itemId = 0;
    protected S_Button btnsSalva;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected ValidationSummary vlsEdit;
    protected Label lblOperazione;
    private int FunId = 0;
    protected S_ComboBox cmbsadd;
    protected S_ComboBox cmbsgiorno;
    protected TextBox txtsorain;
    protected TextBox txtsorainmin;
    protected TextBox txtsoraout;
    protected TextBox txtsoraoutmin;
    protected RangeValidator RVraddetto;
    protected RangeValidator RVrgiorno;
    private RepAddetti _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      ((WebControl) this.btnsSalva).Attributes.Add("onclick", "Valorizza('1');");
      this.btnAnnulla.Attributes.Add("onclick", "Valorizza('0');");
      this.txtsorain.Attributes.Add("onkeypress", "SoloNumeri();");
      this.txtsorain.Attributes.Add("onpaste", "return false;");
      this.txtsorain.Attributes.Add("onblur", "Formatta('" + this.txtsorain.ClientID + "');");
      this.txtsorain.Attributes.Add("maxlength", "2");
      this.txtsorainmin.Attributes.Add("onkeypress", "SoloNumeri();");
      this.txtsorainmin.Attributes.Add("onpaste", "return false;");
      this.txtsorainmin.Attributes.Add("onblur", "Formatta('" + this.txtsorainmin.ClientID + "');");
      this.txtsorainmin.Attributes.Add("maxlength", "2");
      this.txtsoraout.Attributes.Add("onkeypress", "SoloNumeri();");
      this.txtsoraout.Attributes.Add("onpaste", "return false;");
      this.txtsoraout.Attributes.Add("onblur", "Formatta('" + this.txtsoraout.ClientID + "');");
      this.txtsoraout.Attributes.Add("maxlength", "2");
      this.txtsoraoutmin.Attributes.Add("onkeypress", "SoloNumeri();");
      this.txtsoraoutmin.Attributes.Add("onpaste", "return false;");
      this.txtsoraoutmin.Attributes.Add("onblur", "Formatta('" + this.txtsoraoutmin.ClientID + "');");
      this.txtsoraoutmin.Attributes.Add("maxlength", "2");
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (!this.Page.IsPostBack)
      {
        this.BindAddetti();
        this.BindGiorni();
        if (this.itemId == 0)
        {
          this.lblOperazione.Text = "Inserimento Reperibilita' Addetto";
          this.txtsorain.Text = "00";
          this.txtsorainmin.Text = "00";
          this.txtsoraout.Text = "00";
          this.txtsoraoutmin.Text = "00";
          this.lblFirstAndLast.Visible = false;
        }
        else
        {
          DataSet dataSet = new DataSet();
          DataSet singleAddrep = new TheSite.Classi.ClassiAnagrafiche.Addetti().GetSingleAddrep(this.itemId);
          if (singleAddrep.Tables[0].Rows.Count == 1)
          {
            DataRow row = singleAddrep.Tables[0].Rows[0];
            if (row["addettoid"] != DBNull.Value)
              ((ListControl) this.cmbsadd).SelectedValue = row["addettoid"].ToString();
            if (row["giornoid"] != DBNull.Value)
              ((ListControl) this.cmbsgiorno).SelectedValue = row["giornoid"].ToString();
            if (row["orain"] != DBNull.Value)
              this.txtsorain.Text = row["orain"].ToString().Split(Convert.ToChar(":"))[0];
            this.txtsorainmin.Text = row["orain"].ToString().Split(Convert.ToChar(":"))[1];
            if (row["oraout"] != DBNull.Value)
              this.txtsoraout.Text = row["oraout"].ToString().Split(Convert.ToChar(":"))[0];
            this.txtsoraoutmin.Text = row["oraout"].ToString().Split(Convert.ToChar(":"))[1];
            this.lblFirstAndLast.Visible = true;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Creato da ");
            if (row["FIRST"] != DBNull.Value)
              stringBuilder.Append(row["FIRST"].ToString());
            stringBuilder.Append(" il ");
            if (row["FIRSTMODIFIED"] != DBNull.Value)
              stringBuilder.Append(row["FIRSTMODIFIED"].ToString());
            this.lblFirstAndLast.Text = stringBuilder.ToString();
          }
          if (this.Request["TipoOper"] == "read")
          {
            this.AbilitaControlli(false);
            this.lblOperazione.Text = "Visualizzazione Reperibilita' Addetto: " + (object) ((ListControl) this.cmbsadd).SelectedItem;
          }
        }
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is RepAddetti))
        return;
      this._fp = (RepAddetti) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void BindGiorni()
    {
      ((ListControl) this.cmbsgiorno).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Addetti().GetDays().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsgiorno).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "giorno", "id", "- Selezionare un Giorno -", "-1");
      ((ListControl) this.cmbsgiorno).DataTextField = "giorno";
      ((ListControl) this.cmbsgiorno).DataValueField = "id";
      ((Control) this.cmbsgiorno).DataBind();
    }

    private void BindAddetti()
    {
      ((ListControl) this.cmbsadd).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Addetti().GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsadd).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "nominativo", "id", "- Selezionare un Addetto -", "-1");
      ((ListControl) this.cmbsadd).DataTextField = "nominativo";
      ((ListControl) this.cmbsadd).DataValueField = "id";
      ((Control) this.cmbsadd).DataBind();
    }

    private void AbilitaControlli(bool enabled)
    {
      this.txtsorain.Enabled = enabled;
      this.txtsoraout.Enabled = enabled;
      ((WebControl) this.cmbsadd).Enabled = enabled;
      ((WebControl) this.cmbsgiorno).Enabled = enabled;
      this.txtsorainmin.Enabled = enabled;
      this.txtsoraoutmin.Enabled = enabled;
      ((WebControl) this.btnsSalva).Enabled = enabled;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      this.cmbsadd.set_DBDefaultValue((object) "-1");
      this.cmbsgiorno.set_DBDefaultValue((object) "-1");
      this.txtsoraout.Text = this.txtsoraout.Text.Trim();
      this.txtsorain.Text = this.txtsorain.Text.Trim();
      if (!this.checkdate(this.itemId))
      {
        SiteJavaScript.msgBox(this.Page, "Gli orari di inizio o fine turno del giorno prescelto coincidono con orari già esistenti");
      }
      else
      {
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_orain");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Index(2);
        ((ParameterObject) sObject1).set_Value((object) (this.txtsorain.Text + ":" + this.txtsorainmin.Text));
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_oraout");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(3);
        ((ParameterObject) sObject2).set_Value((object) (this.txtsoraout.Text + ":" + this.txtsoraoutmin.Text));
        CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
        CollezioneControlli.Add(sObject1);
        CollezioneControlli.Add(sObject2);
        try
        {
          int num;
          if (this.itemId == 0)
          {
            string Operazione = "Insert";
            num = new TheSite.Classi.ClassiAnagrafiche.Addetti().ExecuteUpdateAddRep(CollezioneControlli, Operazione, this.itemId);
          }
          else
          {
            string Operazione = "Update";
            num = new TheSite.Classi.ClassiAnagrafiche.Addetti().ExecuteUpdateAddRep(CollezioneControlli, Operazione, this.itemId);
          }
          if (num <= 0)
            return;
          this.Server.Transfer("RepAddetti.aspx");
        }
        catch (Exception ex)
        {
          this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
        }
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("RepAddetti.aspx");

    private bool checkdate(int itemId)
    {
      bool flag = true;
      int num1 = (int) short.Parse(this.txtsorain.Text + this.txtsorainmin.Text);
      int num2 = (int) short.Parse(this.txtsoraout.Text + this.txtsoraoutmin.Text);
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_addetto_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) ((ListControl) this.cmbsadd).SelectedValue);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_giorno_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) ((ListControl) this.cmbsgiorno).SelectedValue);
      CollezioneControlli.Add(sObject1);
      CollezioneControlli.Add(sObject2);
      foreach (DataRow row in (InternalDataCollectionBase) new TheSite.Classi.ClassiAnagrafiche.Addetti().GetDateRep(CollezioneControlli).Tables[0].Rows)
      {
        if (num1 >= (int) short.Parse(row["datain"].ToString()) && num1 <= (int) short.Parse(row["dataout"].ToString()))
        {
          flag = false;
          break;
        }
        if (num2 >= (int) short.Parse(row["datain"].ToString()) && num2 <= (int) short.Parse(row["dataout"].ToString()))
        {
          flag = false;
          break;
        }
      }
      return flag;
    }
  }
}
