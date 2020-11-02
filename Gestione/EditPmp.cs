// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditPmp
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
  public class EditPmp : Page
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
    protected RequiredFieldValidator rfvcognome;
    protected S_TextBox txtsdescrizione;
    protected S_TextBox txtsunitshour;
    protected S_ComboBox cmbseq_std;
    protected S_ComboBox cmbspmp;
    protected S_ComboBox cmbstr;
    protected S_TextBox txtspmp_id;
    protected string s_Pmp_id = "";
    protected string s_Pmp_id1 = "";
    protected RangeValidator RangeValidator1;
    protected RangeValidator RFVeqstd;
    protected RangeValidator RfvPmpFreq;
    protected RangeValidator Rfvtr;
    protected RangeValidator Rangevalidator1;
    protected RangeValidator RfvServ;
    protected DropDownList cmbsServ;
    private Pmp _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      this.check_caselle_testo();
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      StringBuilder stringBuilder1 = new StringBuilder();
      stringBuilder1.Append("document.getElementById('" + ((Control) this.cmbspmp).ClientID + "').disabled = true;");
      stringBuilder1.Append("document.getElementById('" + ((Control) this.cmbseq_std).ClientID + "').disabled = true;");
      this.cmbsServ.Attributes.Add("onchange", stringBuilder1.ToString());
      StringBuilder stringBuilder2 = new StringBuilder();
      stringBuilder2.Append("document.getElementById('" + ((Control) this.cmbspmp).ClientID + "').disabled = true;");
      stringBuilder2.Append("document.getElementById('" + this.cmbsServ.ClientID + "').disabled = true;");
      ((WebControl) this.cmbseq_std).Attributes.Add("onchange", stringBuilder2.ToString());
      StringBuilder stringBuilder3 = new StringBuilder();
      stringBuilder3.Append("document.getElementById('" + this.cmbsServ.ClientID + "').disabled = true;");
      stringBuilder3.Append("document.getElementById('" + ((Control) this.cmbseq_std).ClientID + "').disabled = true;");
      ((WebControl) this.cmbspmp).Attributes.Add("onchange", stringBuilder3.ToString());
      if (this.Page.IsPostBack)
        return;
      this.BindServizio();
      this.BindPmPFrequenza();
      if (this.itemId != 0)
      {
        DataSet dataSet = new DataSet();
        TheSite.Classi.ClassiAnagrafiche.Pmp pmp = new TheSite.Classi.ClassiAnagrafiche.Pmp();
        DataSet singleData = pmp.GetSingleData(this.itemId);
        if (singleData.Tables[0].Rows.Count == 1)
        {
          DataRow row = singleData.Tables[0].Rows[0];
          ((TextBox) this.txtsdescrizione).Text = row["DES"].ToString();
          if (row["UH"] != DBNull.Value)
            ((TextBox) this.txtsunitshour).Text = row["UH"].ToString();
          if (row["servizi_id"] != DBNull.Value)
            this.cmbsServ.SelectedValue = row["servizi_id"].ToString();
          this.BindEqstd(int.Parse(this.cmbsServ.SelectedValue));
          if (row["eq_std"] != DBNull.Value)
            ((ListControl) this.cmbseq_std).SelectedValue = row["eq_std"].ToString();
          this.BindSpecStd(int.Parse(this.cmbsServ.SelectedValue));
          if (row["freq"] != DBNull.Value)
            ((ListControl) this.cmbspmp).SelectedValue = row["freq"].ToString();
          if (row["tr"] != DBNull.Value)
          {
            this.BindSpecStd();
            ((ListControl) this.cmbstr).SelectedValue = row["tr"].ToString();
          }
          if (row["pmp_id"] != DBNull.Value)
            ((TextBox) this.txtspmp_id).Text = row["pmp_id"].ToString();
          this.lblOperazione.Text = "Modifica Procedura di Manutenzione: " + row["pmp_id"].ToString();
          this.lblFirstAndLast.Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          this.lblFirstAndLast.Text = pmp.GetFirstAndLastUser(row);
        }
      }
      else
      {
        this.lblOperazione.Text = "Inserimento Procedura di Manutenzione";
        this.BindEqstd(0);
        this.BindSpecStd();
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
      }
      if (this.Request["TipoOper"] == "read")
      {
        this.AbilitaControlli(false);
        this.lblOperazione.Text = "Visualizzazione Procedura di Manutenzione: " + ((TextBox) this.txtspmp_id).Text;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Pmp))
        return;
      this._fp = (Pmp) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void check_caselle_testo()
    {
      ((WebControl) this.txtsdescrizione).Attributes.Add("onkeypress", "Verifica(this.value,250)");
      ((WebControl) this.txtsunitshour).Attributes.Add("onkeypress", "Verifica1(this.value,10)");
      ((WebControl) this.txtsunitshour).Attributes.Add("onpaste", "return false;");
    }

    private void AbilitaControlli(bool enabled)
    {
      ((WebControl) this.txtsdescrizione).Enabled = enabled;
      ((WebControl) this.txtsunitshour).Enabled = enabled;
      ((WebControl) this.txtspmp_id).Enabled = enabled;
      ((WebControl) this.cmbstr).Enabled = enabled;
      ((WebControl) this.cmbseq_std).Enabled = enabled;
      ((WebControl) this.cmbspmp).Enabled = enabled;
      this.cmbsServ.Enabled = enabled;
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
      this.cmbsServ.SelectedIndexChanged += new EventHandler(this.cmbsServ_SelectedIndexChanged);
      ((ListControl) this.cmbseq_std).SelectedIndexChanged += new EventHandler(this.cmbseq_std_SelectedIndexChanged);
      ((ListControl) this.cmbspmp).SelectedIndexChanged += new EventHandler(this.cmbspmp_SelectedIndexChanged);
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      ((Button) this.btnsElimina).Click += new EventHandler(this.btnsElimina_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      try
      {
        TheSite.Classi.ClassiAnagrafiche.Pmp pmp = new TheSite.Classi.ClassiAnagrafiche.Pmp();
        this.txtsdescrizione.set_DBDefaultValue((object) DBNull.Value);
        this.txtsunitshour.set_DBDefaultValue((object) "0");
        this.txtspmp_id.set_DBDefaultValue((object) DBNull.Value);
        this.cmbseq_std.set_DBDefaultValue((object) "-1");
        this.cmbspmp.set_DBDefaultValue((object) -1);
        this.cmbstr.set_DBDefaultValue((object) "-1");
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
        if (pmp.Delete(CollezioneControlli, this.itemId) != -1)
          return;
        this.Server.Transfer("Pmp.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      this.txtsdescrizione.set_DBDefaultValue((object) DBNull.Value);
      this.txtsunitshour.set_DBDefaultValue((object) "0");
      this.txtspmp_id.set_DBDefaultValue((object) DBNull.Value);
      this.cmbseq_std.set_DBDefaultValue((object) "-1");
      this.cmbspmp.set_DBDefaultValue((object) "-1");
      this.cmbstr.set_DBDefaultValue((object) "-1");
      ((TextBox) this.txtsdescrizione).Text = ((TextBox) this.txtsdescrizione).Text.Trim();
      ((TextBox) this.txtsunitshour).Text = ((TextBox) this.txtsunitshour).Text.Trim();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        if ((this.itemId != 0 ? new TheSite.Classi.ClassiAnagrafiche.Pmp().Update(CollezioneControlli, this.itemId) : new TheSite.Classi.ClassiAnagrafiche.Pmp().Add(CollezioneControlli)) == -11)
          SiteJavaScript.msgBox(this.Page, "Attenzione il Piano di Manutenzione Programmata creato è già presente.");
        else
          this.Server.Transfer("Pmp.aspx");
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Pmp.aspx");

    private void BindSpecStd()
    {
      ((ListControl) this.cmbstr).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Pmp().GetAllTr().Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbstr).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "id", "- Selezionare una Specializzazione -", "0");
        ((ListControl) this.cmbstr).DataTextField = "descrizione";
        ((ListControl) this.cmbstr).DataValueField = "id";
        ((Control) this.cmbstr).DataBind();
      }
      else
        ((ListControl) this.cmbstr).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Specializzazione  -", "-1"));
    }

    private void BindSpecStd(int id_serv)
    {
      ((ListControl) this.cmbstr).Items.Clear();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_servizio_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) id_serv);
      CollezioneControlli.Add(sObject);
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Pmp().GetSpecData(CollezioneControlli).Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbstr).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "id", "- Selezionare una Specializzazione -", "0");
        ((ListControl) this.cmbstr).DataTextField = "descrizione";
        ((ListControl) this.cmbstr).DataValueField = "id";
        ((Control) this.cmbstr).DataBind();
      }
      else
        ((ListControl) this.cmbstr).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Specializzazione  -", "-1"));
    }

    private void BindServizio()
    {
      this.cmbsServ.Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiDettaglio.Servizi().GetServizi().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      this.cmbsServ.DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "serv", "id", "- Selezionare un Servizio -", "0");
      this.cmbsServ.DataTextField = "serv";
      this.cmbsServ.DataValueField = "id";
      this.cmbsServ.DataBind();
    }

    private void BindEqstd(int id_serv)
    {
      ((ListControl) this.cmbseq_std).Items.Clear();
      S_ControlsCollection _SColl = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_servizio_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) id_serv);
      _SColl.Add(sObject);
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Eqstd().GetSingleServ(_SColl).Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbseq_std).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "eq_std", "id", "- Selezionare uno Standard -", "0");
        ((ListControl) this.cmbseq_std).DataTextField = "eq_std";
        ((ListControl) this.cmbseq_std).DataValueField = "id";
        ((Control) this.cmbseq_std).DataBind();
      }
      else
        ((ListControl) this.cmbseq_std).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Standard  -", "-1"));
    }

    private void BindPmPFrequenza()
    {
      ((ListControl) this.cmbspmp).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza().GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbspmp).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "fqdes", "id", "- Selezionare una Frequenza -", "0");
      ((ListControl) this.cmbspmp).DataTextField = "fqdes";
      ((ListControl) this.cmbspmp).DataValueField = "id";
      ((Control) this.cmbspmp).DataBind();
    }

    private void cmbseq_std_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cmbsServ.SelectedIndex == 0)
        this.BindSpecStd(int.Parse(new TheSite.Classi.ClassiAnagrafiche.Pmp().GetStdData(int.Parse(((ListControl) this.cmbseq_std).SelectedValue)).Tables[0].Rows[0]["id"].ToString()));
      if (!(((ListControl) this.cmbseq_std).SelectedValue != "0"))
        return;
      ((TextBox) this.txtspmp_id).Text = this.generacodice(int.Parse(((ListControl) this.cmbseq_std).SelectedValue), int.Parse(((ListControl) this.cmbspmp).SelectedValue));
    }

    private void cmbspmp_SelectedIndexChanged(object sender, EventArgs e) => ((TextBox) this.txtspmp_id).Text = this.generacodice(int.Parse(((ListControl) this.cmbseq_std).SelectedValue), int.Parse(((ListControl) this.cmbspmp).SelectedValue));

    private void cmbsServ_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.BindEqstd(int.Parse(this.cmbsServ.SelectedValue));
      this.BindSpecStd(int.Parse(this.cmbsServ.SelectedValue));
    }

    private string generacodice(int id_eqstd, int id_freq)
    {
      S_ControlsCollection _SColl = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id_eqstd");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Value((object) id_eqstd);
      ((ParameterObject) sObject1).set_Size(10);
      ((ParameterObject) sObject1).set_Index(0);
      _SColl.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_id_freq");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Value((object) id_freq);
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Index(1);
      _SColl.Add(sObject2);
      return new TheSite.Classi.ClassiAnagrafiche.Pmp().GetCodicepmp(_SColl);
    }
  }
}
