// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditLetturaContatori
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.Classi.ManOrdinaria;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class EditLetturaContatori : Page
  {
    protected S_ComboBox cmbsPiano;
    protected S_ComboBox cmbsStanza;
    protected S_ComboBox cmbsServizio;
    protected S_ComboBox cmbsApparecchiatura;
    protected S_ComboBox CmbsEnergia;
    protected S_TextBox TxtValoreLetturaInt;
    protected S_TextBox TxtValoreLetturaDec;
    protected S_TextBox TxtNota;
    protected DataPanel Datapanel1;
    protected DataPanel PanelRicerca;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    protected CodiceApparecchiature CodiceApparecchiature1;
    protected RicercaModulo RicercaModulo1;
    protected CalendarPicker CalendarPicker1;
    protected TheSite.WebControls.Addetti Addetti1;
    protected S_Button BtnSalva;
    protected S_Button BtnAnnulla;
    protected PageTitle PageTitle1;
    private string id_lettura;
    protected S_Button BtnElimina;
    protected TextBox txtsorainmin;
    protected S_TextBox itemId;
    protected TextBox txtsorain;
    protected RequiredFieldValidator RfvEnergia;
    protected ValidationSummary ValidationSummary1;
    protected RequiredFieldValidator RfvData;
    protected RequiredFieldValidator RFVAddetto;
    private LetturaContatori _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      this.RfvData.ControlToValidate = this.CalendarPicker1.ID + ":" + ((Control) this.CalendarPicker1.Datazione).ID;
      this.RFVAddetto.ControlToValidate = this.Addetti1.ID + ":" + this.Addetti1.TextIdAddetto.ID;
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      EditLetturaContatori.FunId = siteModule.ModuleId;
      EditLetturaContatori.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindServizio);
      this.RicercaModulo1.DelegateIDBLEdificio1 += new DelegateIDBLEdificio(this.BindPiano);
      this.CodiceApparecchiature1.NameComboApparecchiature = "cmbsApparecchiatura";
      this.CodiceApparecchiature1.NameComboServizio = "cmbsServizio";
      this.CodiceApparecchiature1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.CodiceApparecchiature1.s_RichiestaLettura = "si";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("document.getElementById('" + ((Control) this.cmbsApparecchiatura).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsServizio).Attributes.Add("onchange", stringBuilder.ToString());
      this.txtsorain.Attributes.Add("onkeypress", "SoloNumeri();");
      this.txtsorain.Attributes.Add("onpaste", "return false;");
      this.txtsorain.Attributes.Add("maxlength", "2");
      this.txtsorain.Attributes.Add("onblur", "return ControllaOra();");
      this.txtsorain.Attributes.Add("onblur", "formatNum(this.id);");
      this.txtsorainmin.Attributes.Add("onkeypress", "SoloNumeri();");
      this.txtsorainmin.Attributes.Add("onpaste", "return false;");
      this.txtsorainmin.Attributes.Add("onblur", "return ControllaMin();");
      this.txtsorainmin.Attributes.Add("maxlength", "2");
      this.txtsorainmin.Attributes.Add("onblur", "formatNum(this.id);");
      ((WebControl) this.TxtValoreLetturaDec).Attributes.Add("onkeypress", "SoloNumeri();");
      ((WebControl) this.TxtValoreLetturaDec).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.TxtValoreLetturaDec).Attributes.Add("onblur", "formatNum(this.id);");
      ((WebControl) this.TxtValoreLetturaInt).Attributes.Add("onkeypress", "SoloNumeri();");
      ((WebControl) this.TxtValoreLetturaInt).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.TxtValoreLetturaInt).Attributes.Add("onblur", "formatNum(this.id);");
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["FunId"] != null)
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      if (this.Request.QueryString["id_lettura"] != null)
      {
        this.id_lettura = this.Request.QueryString["id_lettura"];
        ((TextBox) this.itemId).Text = this.id_lettura;
      }
      if (this.id_lettura != null)
      {
        DataSet dataSet = new DataSet();
        DataSet singleData = new TheSite.Classi.ClassiAnagrafiche.LetturaContatori().GetSingleData(Convert.ToInt32(this.id_lettura));
        if (singleData.Tables[0].Rows.Count == 1)
        {
          DataRow row = singleData.Tables[0].Rows[0];
          if (row["nota"] != DBNull.Value)
            ((TextBox) this.TxtNota).Text = (string) row["nota"];
          if (row["valorelettura"] != DBNull.Value)
          {
            string str = Convert.ToDouble(row["valorelettura"].ToString()).ToString();
            ((TextBox) this.TxtValoreLetturaInt).Text = TheSite.Classi.Function.GetTypeNumber((object) str, NumberType.Intero).ToString();
            ((TextBox) this.TxtValoreLetturaDec).Text = TheSite.Classi.Function.GetTypeNumber((object) str, NumberType.Decimale).ToString();
          }
          if (row["datalettura"] != DBNull.Value)
          {
            ((TextBox) this.CalendarPicker1.Datazione).Text = Convert.ToDateTime(row["datalettura"]).ToShortDateString();
            this.txtsorain.Text = Convert.ToString(Convert.ToDateTime(row["datalettura"]).Hour).PadLeft(2, '0');
            this.txtsorainmin.Text = Convert.ToString(Convert.ToDateTime(row["datalettura"]).Minute).PadLeft(2, '0');
          }
          if (row["energia"] != DBNull.Value)
            ((ListControl) this.CmbsEnergia).SelectedValue = (string) row["energia"];
          this.CodiceApparecchiature1.IdApparecchiatura = row["id_eq"].ToString();
          this.CodiceApparecchiature1.CodiceApparecchiatura = row["eq_id"].ToString();
          ((WebControl) this.CodiceApparecchiature1.s_CodiceApparecchiatura).Enabled = false;
          this.Addetti1.IdAddetto = row["id_addetto"].ToString();
          this.Addetti1.NomeCompleto = row["NominativoAddetto"].ToString();
          ((TextBox) this.RicercaModulo1.TxtCodice).Text = row["bl_id"].ToString();
          ((WebControl) this.RicercaModulo1.TxtCodice).Enabled = false;
          ((WebControl) this.RicercaModulo1.TxtRicerca).Enabled = false;
          this.RicercaModulo1.Ricarica();
          this.BindApparecchiatura();
          ((ListControl) this.cmbsApparecchiatura).SelectedValue = row["id_eqstd"].ToString();
          ((WebControl) this.cmbsApparecchiatura).Enabled = false;
          this.BindTuttiPiani();
          ((ListControl) this.cmbsPiano).SelectedValue = row["piano"].ToString();
          ((WebControl) this.cmbsPiano).Enabled = false;
          this.BindStanza();
          ((ListControl) this.cmbsStanza).SelectedValue = row["stanza"].ToString();
          ((WebControl) this.cmbsStanza).Enabled = false;
          this.BindServizio("");
          ((ListControl) this.cmbsServizio).SelectedValue = row["servizio"].ToString();
          ((WebControl) this.cmbsServizio).Enabled = false;
        }
      }
      else
        ((WebControl) this.BtnElimina).Enabled = false;
      this.Addetti1.Set_BL_ID("%");
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is LetturaContatori))
        return;
      this._fp = (LetturaContatori) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsPiano).SelectedIndexChanged += new EventHandler(this.cmbsPiano_SelectedIndexChanged);
      ((ListControl) this.cmbsServizio).SelectedIndexChanged += new EventHandler(this.cmbsServizio_SelectedIndexChanged);
      ((Button) this.BtnSalva).Click += new EventHandler(this.BtnSalva_Click);
      ((Button) this.BtnElimina).Click += new EventHandler(this.BtnElimina_Click);
      ((Button) this.BtnAnnulla).Click += new EventHandler(this.BtnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void BindServizio(string CodEdificio)
    {
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      TheSite.Classi.ClassiDettaglio.Servizi servizi = new TheSite.Classi.ClassiDettaglio.Servizi(this.Context.User.Identity.Name);
      DataSet data;
      if (CodEdificio != "")
      {
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Index(0);
        ((ParameterObject) sObject1).set_Value((object) CodEdificio);
        ((ParameterObject) sObject1).set_Size(8);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_ID_Servizio");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(1);
        ((ParameterObject) sObject2).set_Value((object) 0);
        CollezioneControlli.Add(sObject1);
        CollezioneControlli.Add(sObject2);
        data = servizi.GetData(CollezioneControlli);
      }
      else
        data = servizi.GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", string.Empty));
    }

    private void BindApparecchiatura()
    {
      ((ListControl) this.cmbsApparecchiatura).Items.Clear();
      Apparecchiature apparecchiature = new Apparecchiature(this.Context.User.Identity.Name);
      DataSet dataSet;
      if (!this.IsPostBack)
      {
        dataSet = apparecchiature.GetData().Copy();
      }
      else
      {
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Size(50);
        ((ParameterObject) sObject1).set_Index(0);
        ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
        CollezioneControlli.Add(sObject1);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_Servizio");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(1);
        ((ParameterObject) sObject2).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
        CollezioneControlli.Add(sObject2);
        dataSet = apparecchiature.GetData(CollezioneControlli).Copy();
      }
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsApparecchiatura).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Standard -", "");
        ((ListControl) this.cmbsApparecchiatura).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsApparecchiatura).DataValueField = "ID";
        ((Control) this.cmbsApparecchiatura).DataBind();
      }
      else
        ((ListControl) this.cmbsApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Standard -", string.Empty));
    }

    private void BindPiano(string CodEdificio)
    {
      ((ListControl) this.cmbsPiano).Items.Clear();
      if (CodEdificio == "")
        CodEdificio = "0";
      DataSet pianiBuilding = new TheSite.Classi.ClassiAnagrafiche.Buildings().GetPianiBuilding(int.Parse(CodEdificio));
      if (pianiBuilding.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsPiano).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(pianiBuilding.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "");
        ((ListControl) this.cmbsPiano).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsPiano).DataValueField = "ID";
        ((Control) this.cmbsPiano).DataBind();
      }
      else
        ((ListControl) this.cmbsPiano).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", string.Empty));
      ((WebControl) this.cmbsPiano).Enabled = true;
      ((WebControl) this.cmbsStanza).Enabled = true;
    }

    private void BindStanza()
    {
      ((ListControl) this.cmbsStanza).Items.Clear();
      DataSet stanze = new Richiesta().GetStanze(this.RicercaModulo1.Idbl == "" ? 0 : int.Parse(this.RicercaModulo1.Idbl), ((ListControl) this.cmbsPiano).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsPiano).SelectedValue));
      if (stanze.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsStanza).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(stanze.Tables[0], "DESCRIZIONE", "ID", "- Selezionare la Stanza -", "");
        ((ListControl) this.cmbsStanza).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsStanza).DataValueField = "ID";
        ((Control) this.cmbsStanza).DataBind();
      }
      else
        ((ListControl) this.cmbsStanza).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Stanza -", string.Empty));
      ((WebControl) this.cmbsStanza).Attributes.Add("OnChange", "ClearApparechiature();");
    }

    private void BindTuttiPiani()
    {
      ((ListControl) this.cmbsPiano).Items.Clear();
      DataSet allPiani = new TheSite.Classi.ClassiAnagrafiche.Buildings().GetAllPiani();
      if (allPiani.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsPiano).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(allPiani.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "");
        ((ListControl) this.cmbsPiano).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsPiano).DataValueField = "ID";
        ((Control) this.cmbsPiano).DataBind();
      }
      else
        ((ListControl) this.cmbsPiano).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", string.Empty));
    }

    private void cmbsServizio_SelectedIndexChanged(object sender, EventArgs e) => this.BindApparecchiatura();

    private void cmbsPiano_SelectedIndexChanged(object sender, EventArgs e) => this.BindStanza();

    private void BtnSalva_Click(object sender, EventArgs e)
    {
      if (((TextBox) this.itemId).Text == "")
      {
        ((TextBox) this.itemId).Text = "0";
        this.Salva("I");
      }
      else
        this.Salva("U");
    }

    private void Salva(string operazione)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id_letture_contatori");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) Convert.ToInt32(((TextBox) this.itemId).Text));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_id_eq");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) this.CodiceApparecchiature1.IdApparecchiatura);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_id_addetto");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) Convert.ToInt32(this.Addetti1.IdAddetto));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_valorelettura");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) (((TextBox) this.TxtValoreLetturaInt).Text.Trim() + "," + ((TextBox) this.TxtValoreLetturaDec).Text.Trim()));
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_nota");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) ((TextBox) this.TxtNota).Text);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_energia");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject5).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject6).set_Value((object) ((ListControl) this.CmbsEnergia).SelectedValue);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_datalettura");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject5).set_Size(15);
      ((ParameterObject) sObject7).set_Value((object) (((TextBox) this.CalendarPicker1.Datazione).Text + " " + this.txtsorain.Text + ":" + this.txtsorainmin.Text + ":00"));
      CollezioneControlli.Add(sObject7);
      try
      {
        if (operazione == "I")
          new TheSite.Classi.ClassiAnagrafiche.LetturaContatori().Add(CollezioneControlli);
        else if (operazione == "U")
          new TheSite.Classi.ClassiAnagrafiche.LetturaContatori().Update(CollezioneControlli, Convert.ToInt32(((TextBox) this.itemId).Text));
        else
          new TheSite.Classi.ClassiAnagrafiche.LetturaContatori().Delete(CollezioneControlli, Convert.ToInt32(((TextBox) this.itemId).Text));
      }
      catch (Exception ex)
      {
        ex.Message.ToString().ToUpper();
        return;
      }
      this.Server.Transfer("LetturaContatori.aspx?FunId =" + (object) EditLetturaContatori.FunId);
    }

    private void BtnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("LetturaContatori.aspx");

    private void BtnElimina_Click(object sender, EventArgs e) => this.Salva("D");

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();
  }
}
