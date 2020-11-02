// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.DescrizioneApparecchiatura
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using Microsoft.Web.UI.WebControls;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class DescrizioneApparecchiatura : Page
  {
    protected S_ComboBox cmbsCondizione;
    protected S_ComboBox cmbsUDM;
    protected CheckBox Contatore;
    protected S_TextBox S_Txtmodello;
    protected S_TextBox S_Txttipo;
    protected S_TextBox S_Txtqta;
    protected S_TextBox S_TxtRif;
    protected S_TextBox S_TxtqtaMatInt;
    protected S_TextBox S_TxtqtaMatDec;
    protected S_ComboBox cmbsvenditore;
    protected S_ComboBox cmbEnteErogante;
    protected S_ComboBox cmbsApparecchiatura;
    protected S_Button S_BtInvia;
    protected S_Button S_btannulla;
    protected S_Button BtnNuovo;
    protected ValidationSummary ValidationSummary1;
    protected RequiredFieldValidator RQApparecchiatura;
    protected RequiredFieldValidator RQCondizione;
    protected S_ComboBox cmbsPiano;
    protected HtmlInputFile Uploader;
    protected HtmlInputFile Upload;
    protected S_Label S_Lblerror;
    protected HtmlInputButton S_BtDatiTecnici;
    protected S_Label S_Lblcodedificio;
    protected S_Label lblCodApparecchiatura;
    protected HtmlInputHidden Hidden_codiceservizio;
    protected HtmlInputHidden Hidden_idservizio;
    protected S_Label lblServizioDescription;
    protected S_ComboBox cmbsMacro;
    protected PageTitle PageTitle1;
    protected CalendarPicker CalendarPicker1;
    protected S_Label lblFirstAndLast;
    protected CalendarPicker CalendarPicker2;
    public string Imagename = string.Empty;
    public static int FunId = 0;
    protected S_CheckBox ChekDismesso;
    protected S_ComboBox cmbsUnita;
    public static string HelpLink = string.Empty;
    protected RegularExpressionValidator RegularExpressionValidator1;
    protected Panel PanelEditAnag;
    protected TabStrip TabStrip1;
    protected LinkButton lkbNuovo;
    protected Label lblRecord;
    protected DataGrid DataGridEsegui;
    protected HtmlInputHidden HiddenEq;
    protected Panel PanelEditDocumenti;
    protected string[] appo;
    protected MessagePanel PanelMess;
    public static int TabId = 0;
    protected UserStanze UserStanze1;
    protected TextBox txtApparechiatura;
    protected RadioButtonList RBLInserimento;
    protected HtmlInputRadioButton Radio1;
    protected HtmlInputRadioButton opt1;

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      ((WebControl) this.TabStrip1).Attributes.Add("onclick", "Abilita(this.selectedIndex);");
      DescrizioneApparecchiatura.TabId = this.TabStrip1.get_SelectedIndex();
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      DescrizioneApparecchiatura.FunId = siteModule.ModuleId;
      DescrizioneApparecchiatura.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      ((Label) this.S_Lblerror).Text = "";
      this.S_BtDatiTecnici.Disabled = true;
      this.Uploader.Accept = "image/*";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("if (typeof(ControllaData) == 'function' && typeof(Page_ClientValidate) == 'function') { ");
      stringBuilder.Append("if (ControllaData() == false || Page_ClientValidate() == false) { return false; }} ");
      stringBuilder.Append(this.Page.GetPostBackEventReference((Control) this.S_BtInvia));
      stringBuilder.Append(";");
      ((WebControl) this.S_BtInvia).Attributes.Add("onclick", "tipoInserimento(); " + stringBuilder.ToString());
      this.Contatore.Attributes.Add("onclick", "AbilitaCmbsUM();");
      ((WebControl) this.S_TxtqtaMatInt).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.S_TxtqtaMatInt).Attributes.Add("onpaste", "return false;");
      this.UserStanze1.NameLblId = "S_Lblcodedificio";
      this.UserStanze1.NameComboPiano = "cmbsPiano";
      ((WebControl) this.S_TxtqtaMatDec).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.S_TxtqtaMatDec).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.cmbsPiano).Attributes.Add("onchange", "clearRoom();");
      if (this.IsPostBack)
        return;
      PropertyInfo property = this.Context.Handler.GetType().GetProperty("_Contenitore");
      if (property != null)
        this.ViewState.Add("mioContenitore", property.GetValue((object) this.Context.Handler, (object[]) null));
      if (this.Context.Items[(object) "CODEDI"] != null)
        ((Label) this.S_Lblcodedificio).Text = (string) this.Context.Items[(object) "CODEDI"];
      if (this.Context.Items[(object) "IDBL"] != null)
        this.BL_ID = (string) this.Context.Items[(object) "IDBL"];
      if (this.Context.Items[(object) "IDEQ"] != null && this.Context.Items[(object) "IDEQ"].ToString() != "")
      {
        this.IDEQ = (string) this.Context.Items[(object) "IDEQ"];
        this.BindGrid();
        if (this.Context.Items[(object) "DISMESSO"].ToString() == "DISMESSA")
          ((CheckBox) this.ChekDismesso).Checked = true;
      }
      else
        this.TabStrip1.get_Items().get_Item(1).set_Enabled(false);
      if (this.Context.Items[(object) "SDESCRIZIONE"] != null && this.Context.Items[(object) "SDESCRIZIONE"].ToString() != "")
        ((Label) this.lblServizioDescription).Text = (string) this.Context.Items[(object) "SDESCRIZIONE"];
      if (this.Context.Items[(object) "SID"] != null && this.Context.Items[(object) "SID"].ToString() != "")
        this.Hidden_idservizio.Value = (string) this.Context.Items[(object) "SID"];
      if (((TextBox) this.S_Txtqta).Text == "")
        ((TextBox) this.S_Txtqta).Text = "1";
      if (((TextBox) this.S_TxtqtaMatInt).Text == "")
        ((TextBox) this.S_TxtqtaMatInt).Text = "0";
      if (((TextBox) this.S_TxtqtaMatDec).Text == "")
        ((TextBox) this.S_TxtqtaMatDec).Text = "00";
      this.BindCondition(0);
      this.BindVenditore(0);
      this.BindUnitaMisura();
      this.BindApparecchiatura();
      this.BindPiano(int.Parse(this.BL_ID));
      this.BindMacroComponente();
      this.BindUM();
      this.BindEnteErogante();
      this.GetData();
    }

    private void GetData()
    {
      if (this.IDEQ == "")
      {
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_Servizio");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Index(0);
        ((ParameterObject) sObject1).set_Value((object) this.Hidden_idservizio.Value);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_id_bl");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(1);
        ((ParameterObject) sObject2).set_Value((object) this.BL_ID);
        CollezioneControlli.Add(sObject1);
        CollezioneControlli.Add(sObject2);
        DataSet dateServiziEdifici = new DatiApparecchiatura(this.Context.User.Identity.Name).GetDateServiziEdifici(CollezioneControlli);
        if (dateServiziEdifici.Tables[0].Rows.Count <= 0)
          return;
        DataRow row = dateServiziEdifici.Tables[0].Rows[0];
        if (row["date_start"] != DBNull.Value)
          ((TextBox) this.CalendarPicker1.Datazione).Text = DateTime.Parse(row["date_start"].ToString()).ToShortDateString();
        if (row["date_end"] == DBNull.Value)
          return;
        ((TextBox) this.CalendarPicker2.Datazione).Text = DateTime.Parse(row["date_end"].ToString()).ToShortDateString();
      }
      else
      {
        this.BindGrid();
        this.TabStrip1.get_Items().get_Item(1).set_Enabled(true);
        DatiApparecchiatura datiApparecchiatura = new DatiApparecchiatura(this.Context.User.Identity.Name);
        DataSet apparecchiatura = datiApparecchiatura.GetApparecchiatura(int.Parse(this.IDEQ));
        if (apparecchiatura.Tables[0].Rows.Count <= 0)
          return;
        this.S_BtDatiTecnici.Disabled = false;
        DataRow row = apparecchiatura.Tables[0].Rows[0];
        if (row["IDSERVIZIO"] != DBNull.Value)
        {
          this.Hidden_codiceservizio.Value = row["IDSERVIZIO"].ToString().Split(Convert.ToChar(" "))[1];
          this.Hidden_idservizio.Value = row["IDSERVIZIO"].ToString().Split(Convert.ToChar(" "))[0];
        }
        if (row["DESCRIZIONESERVIZIO"] != DBNull.Value)
          ((Label) this.lblServizioDescription).Text = row["DESCRIZIONESERVIZIO"].ToString();
        this.BindApparecchiatura();
        if (row["eq_stdid"] != DBNull.Value)
          ((ListControl) this.cmbsApparecchiatura).SelectedValue = row["eq_stdid"].ToString();
        if (row["IDP"] != DBNull.Value)
          ((ListControl) this.cmbsPiano).SelectedValue = row["IDP"].ToString();
        this.appo = ((ListControl) this.cmbsPiano).SelectedValue.Split(' ');
        int.Parse(this.appo[0]);
        if (row["stanza"] != DBNull.Value)
          this.UserStanze1.DescStanza = row["stanza"].ToString();
        if (row["IDS"] != DBNull.Value)
          this.UserStanze1.IdStanza = row["IDS"].ToString();
        if (row["quantita"] != DBNull.Value)
          ((TextBox) this.S_Txtqta).Text = row["quantita"].ToString();
        if (row["IDUNITAMISURA"] != DBNull.Value)
          ((ListControl) this.cmbsUnita).SelectedValue = row["IDUNITAMISURA"].ToString();
        if (row["NUMEROUNITA"] != DBNull.Value)
        {
          ((TextBox) this.S_TxtqtaMatInt).Text = TheSite.Classi.Function.GetTypeNumber(row["NUMEROUNITA"], NumberType.Intero).ToString();
          ((TextBox) this.S_TxtqtaMatDec).Text = TheSite.Classi.Function.GetTypeNumber(row["NUMEROUNITA"], NumberType.Decimale).ToString();
        }
        if (row["id_condition"] != DBNull.Value && row["id_condition"].ToString() != "0")
          ((ListControl) this.cmbsCondizione).SelectedValue = row["id_condition"].ToString();
        if (row["id_vn"] != DBNull.Value && row["id_vn"].ToString() != "0")
          ((ListControl) this.cmbsvenditore).SelectedValue = row["id_vn"].ToString();
        if (row["subcomponent_of"] != DBNull.Value)
          ((ListControl) this.cmbsMacro).SelectedValue = row["subcomponent_of"].ToString();
        if (row["date_start_validate"] != DBNull.Value)
          ((TextBox) this.CalendarPicker1.Datazione).Text = DateTime.Parse(row["date_start_validate"].ToString()).ToShortDateString();
        if (row["date_end_validate"] != DBNull.Value)
          ((TextBox) this.CalendarPicker2.Datazione).Text = DateTime.Parse(row["date_end_validate"].ToString()).ToShortDateString();
        if (row["modello"] != DBNull.Value)
          ((TextBox) this.S_Txtmodello).Text = row["modello"].ToString();
        if (row["tipo"] != DBNull.Value)
          ((TextBox) this.S_Txttipo).Text = row["tipo"].ToString();
        if (row["rifPlanimetria"] != DBNull.Value)
          ((TextBox) this.S_TxtRif).Text = row["rifPlanimetria"].ToString();
        if (row["EQ_ID"] != DBNull.Value)
          this.EQ_ID = row["EQ_ID"].ToString();
        if (row["contatore"] != DBNull.Value)
        {
          if (row["contatore"].ToString() == "1")
          {
            this.Contatore.Checked = true;
            ((WebControl) this.cmbsUDM).Enabled = true;
            if (row["UMD"] != DBNull.Value)
              ((ListControl) this.cmbsUDM).SelectedValue = row["UMD"].ToString();
          }
          else
          {
            this.Contatore.Checked = false;
            ((WebControl) this.cmbsUDM).Enabled = false;
          }
        }
        if (row["EnteErogante"] != DBNull.Value)
          ((ListControl) this.cmbEnteErogante).SelectedValue = row["EnteErogante"].ToString();
        this.S_BtDatiTecnici.Attributes.Add("onclick", "opendoc('" + ("IDEQ=" + this.IDEQ + "&EQ_ID=" + this.EQ_ID) + "');");
        if (row["image_eq_assy"] != DBNull.Value)
        {
          this.ImageName = row["image_eq_assy"].ToString();
          this.Imagename = "eq_image=" + row["image_eq_assy"].ToString();
        }
        ((Label) this.lblFirstAndLast).Text = datiApparecchiatura.GetFirstAndLastUser(row);
        ((Label) this.lblCodApparecchiatura).Text = string.Format(" Codice Apparecchatura: {0}", row["EQ_ID"]);
        this.txtApparechiatura.Text = row["EQ_ID"].ToString();
        this.txtApparechiatura.Enabled = false;
      }
    }

    private string BL_ID
    {
      get => this.ViewState[nameof (BL_ID)] != null ? (string) this.ViewState[nameof (BL_ID)] : string.Empty;
      set => this.ViewState.Add(nameof (BL_ID), (object) value);
    }

    private string EQ_ID
    {
      get => this.ViewState[nameof (EQ_ID)] != null ? (string) this.ViewState[nameof (EQ_ID)] : string.Empty;
      set => this.ViewState.Add(nameof (EQ_ID), (object) value);
    }

    private string IDEQ
    {
      get => this.ViewState[nameof (IDEQ)] != null ? (string) this.ViewState[nameof (IDEQ)] : string.Empty;
      set => this.ViewState.Add(nameof (IDEQ), (object) value);
    }

    private string ImageName
    {
      get => this.ViewState[nameof (ImageName)] != null ? (string) this.ViewState[nameof (ImageName)] : string.Empty;
      set => this.ViewState.Add(nameof (ImageName), (object) value);
    }

    private void BindMacroComponente()
    {
      ((ListControl) this.cmbsMacro).Items.Clear();
      ((BaseDataBoundControl) this.cmbsMacro).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(new DatiApparecchiatura(this.Context.User.Identity.Name).GetMacroComponenti().Tables[0], "macrocomponente", "macrocomponente", "- Selezionare il Macrocomponente -", "");
      ((ListControl) this.cmbsMacro).DataTextField = "macrocomponente";
      ((ListControl) this.cmbsMacro).DataValueField = "macrocomponente";
      ((Control) this.cmbsMacro).DataBind();
    }

    private void BindApparecchiatura()
    {
      ((ListControl) this.cmbsApparecchiatura).Items.Clear();
      DatiApparecchiatura datiApparecchiatura = new DatiApparecchiatura(this.Context.User.Identity.Name);
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) int.Parse(this.BL_ID));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Servizio");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      int num = 0;
      if (this.Hidden_idservizio.Value != "")
        num = int.Parse(this.Hidden_idservizio.Value);
      ((ParameterObject) sObject2).set_Value((object) num);
      CollezioneControlli.Add(sObject2);
      DataSet dataSet = datiApparecchiatura.GetStdApparechiature(CollezioneControlli).Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsApparecchiatura).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "COD", "ID", "- Selezionare uno Standard -", "");
        ((ListControl) this.cmbsApparecchiatura).DataTextField = "COD";
        ((ListControl) this.cmbsApparecchiatura).DataValueField = "ID";
        ((Control) this.cmbsApparecchiatura).DataBind();
      }
      else
        ((ListControl) this.cmbsApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Standard -", string.Empty));
    }

    private void BindUnitaMisura()
    {
      ((ListControl) this.cmbsUnita).Items.Clear();
      DataSet unita = new TheSite.Classi.ClassiAnagrafiche.UnitaMisura().GetUnita();
      if (unita.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsUnita).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(unita.Tables[0], "ucodice", "idunita", "- Selezionare Unità di Misura -", "0");
        ((ListControl) this.cmbsUnita).DataTextField = "ucodice";
        ((ListControl) this.cmbsUnita).DataValueField = "idunita";
        ((Control) this.cmbsUnita).DataBind();
      }
      else
        ((ListControl) this.cmbsUnita).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Unità di Misura -", string.Empty));
    }

    private void BindUM()
    {
      ((ListControl) this.cmbsUDM).Items.Clear();
      DataSet unita = new TheSite.Classi.ClassiAnagrafiche.UnitaMisura().GetUnita();
      if (unita.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsUDM).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(unita.Tables[0], "ucodice", "idunita", "- Selezionare Unità di Misura -", "0");
        ((ListControl) this.cmbsUDM).DataTextField = "ucodice";
        ((ListControl) this.cmbsUDM).DataValueField = "idunita";
        ((Control) this.cmbsUDM).DataBind();
      }
      else
        ((ListControl) this.cmbsUDM).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Unità di Misura -", string.Empty));
    }

    private void BindCondition(int condition)
    {
      ((ListControl) this.cmbsCondizione).Items.Clear();
      DataSet condizione = new DatiApparecchiatura(this.Context.User.Identity.Name).GetCondizione(condition);
      if (condizione.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsCondizione).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(condizione.Tables[0], "DESCRIZIONE", "ID", "- Selezionare lo Stato -", "");
        ((ListControl) this.cmbsCondizione).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsCondizione).DataValueField = "ID";
        ((Control) this.cmbsCondizione).DataBind();
      }
      else
        ((ListControl) this.cmbsCondizione).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Stato-", string.Empty));
    }

    private void BindPiano(int idpiano)
    {
      ((ListControl) this.cmbsPiano).Items.Clear();
      DataSet piani = new DatiApparecchiatura(this.Context.User.Identity.Name).GetPiani(idpiano);
      if (piani.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsPiano).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(piani.Tables[0], "DESCRIZIONE", "IDP", "- Selezionare il Piano -", "");
        ((ListControl) this.cmbsPiano).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsPiano).DataValueField = "IDP";
        ((Control) this.cmbsPiano).DataBind();
      }
      else
        ((ListControl) this.cmbsPiano).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", string.Empty));
    }

    private void BindVenditore(int venditoreid)
    {
      ((ListControl) this.cmbsvenditore).Items.Clear();
      DataSet venditore = new DatiApparecchiatura(this.Context.User.Identity.Name).GetVenditore(venditoreid);
      if (venditore.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsvenditore).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(venditore.Tables[0], "DESCRIZIONE", "ID", "- Selezionare un Venditore -", "");
        ((ListControl) this.cmbsvenditore).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsvenditore).DataValueField = "ID";
        ((Control) this.cmbsvenditore).DataBind();
      }
      else
        ((ListControl) this.cmbsvenditore).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Venditore -", string.Empty));
    }

    private void BindEnteErogante()
    {
      TheSite.Classi.ClassiAnagrafiche.Enti enti = new TheSite.Classi.ClassiAnagrafiche.Enti();
      ((ListControl) this.cmbEnteErogante).Items.Clear();
      DataSet dataSet = enti.GetData().Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbEnteErogante).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "testo", "id", "- Selezionare Ente -", "0");
        ((ListControl) this.cmbEnteErogante).DataTextField = "testo";
        ((ListControl) this.cmbEnteErogante).DataValueField = "id";
        ((Control) this.cmbEnteErogante).DataBind();
      }
      else
        ((ListControl) this.cmbEnteErogante).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Ente Erogante-", string.Empty));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.lkbNuovo.Click += new EventHandler(this.lkbNuovo_Click);
      ((Button) this.S_BtInvia).Click += new EventHandler(this.S_BtInvia_Click);
      ((Button) this.S_btannulla).Click += new EventHandler(this.S_btannulla_Click);
      ((Button) this.BtnNuovo).Click += new EventHandler(this.BtnNuovo_Click);
      this.DataGridEsegui.ItemCommand += new DataGridCommandEventHandler(this.DataGridEsegui_ItemCommand);
      this.DataGridEsegui.CancelCommand += new DataGridCommandEventHandler(this.DataGridEsegui_CancelCommand);
      this.DataGridEsegui.EditCommand += new DataGridCommandEventHandler(this.DataGridEsegui_EditCommand);
      this.DataGridEsegui.UpdateCommand += new DataGridCommandEventHandler(this.DataGridEsegui_UpdateCommand);
      this.DataGridEsegui.ItemDataBound += new DataGridItemEventHandler(this.DataGridEsegui_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void cmbsServizio_SelectedIndexChanged(object sender, EventArgs e) => this.BindApparecchiatura();

    private void S_btannulla_Click(object sender, EventArgs e) => this.Server.Transfer("ListaApparecchiature.aspx");

    private void S_BtInvia_Click(object sender, EventArgs e)
    {
      DatiApparecchiatura datiApparecchiatura = new DatiApparecchiatura(this.Context.User.Identity.Name);
      int num1 = 0;
      if (this.IDEQ == "")
      {
        string str = ((ListControl) this.cmbsPiano).SelectedValue.Split(Convert.ToChar(" "))[1];
        DataSet countApparecchiature = datiApparecchiatura.GetCountApparecchiature(int.Parse(this.BL_ID), int.Parse(((ListControl) this.cmbsApparecchiatura).SelectedValue.Split(Convert.ToChar(" "))[0]), ((ListControl) this.cmbsPiano).SelectedValue.Split(Convert.ToChar(" "))[1]);
        if (countApparecchiature.Tables[0].Rows.Count > 0 && countApparecchiature.Tables[0].Rows[0][0] != DBNull.Value)
          num1 = int.Parse(countApparecchiature.Tables[0].Rows[0][0].ToString());
        ++num1;
      }
      else if (this.EQ_ID.IndexOf('_') != -1)
        num1 = int.Parse(this.EQ_ID.Substring(this.EQ_ID.LastIndexOf("_") + 1));
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) (this.IDEQ == "" ? 0 : int.Parse(this.IDEQ)));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_eq_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Size(50);
      string str1;
      if (this.Radio1.Checked)
        str1 = this.txtApparechiatura.Text;
      else
        str1 = ((Label) this.S_Lblcodedificio).Text.Replace(".", "_") + "_" + ((ListControl) this.cmbsPiano).SelectedValue.Split(Convert.ToChar(" "))[1] + "_" + ((ListControl) this.cmbsApparecchiatura).SelectedValue.Split(Convert.ToChar(" "))[1] + "_" + num1.ToString().PadLeft(2, Convert.ToChar("0"));
      ((ParameterObject) sObject2).set_Value((object) str1);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Size(8);
      ((ParameterObject) sObject3).set_Value((object) ((Label) this.S_Lblcodedificio).Text);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_qta");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Size(32);
      ((ParameterObject) sObject4).set_Value((object) (((TextBox) this.S_Txtqta).Text == "" ? 1 : Convert.ToInt32(((TextBox) this.S_Txtqta).Text)));
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_condition");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Size(12);
      ((ParameterObject) sObject5).set_Value(((ListControl) this.cmbsCondizione).SelectedIndex == 0 ? (object) "" : (object) ((ListControl) this.cmbsCondizione).Items[((ListControl) this.cmbsCondizione).SelectedIndex].Text);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_eqstd");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject6).set_Size(16);
      ((ParameterObject) sObject6).set_Value((object) ((ListControl) this.cmbsApparecchiatura).SelectedValue.Split(Convert.ToChar(" "))[1]);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_fl_id");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject7).set_Size(4);
      ((ParameterObject) sObject7).set_Value((object) ((ListControl) this.cmbsPiano).SelectedValue.Split(Convert.ToChar(" "))[1]);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_rm_id");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject8).set_Size(4);
      if (this.UserStanze1.IdStanza == "")
        ((ParameterObject) sObject8).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject8).set_Value((object) int.Parse(this.UserStanze1.IdStanza));
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_image_eq_assy");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject9).set_Size(64);
      ((ParameterObject) sObject9).set_Value((object) this.valutafile(str1));
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_option1");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject10).set_Size(32);
      ((ParameterObject) sObject10).set_Value((object) ((TextBox) this.S_Txtmodello).Text);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_option2");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject11).set_Size(50);
      ((ParameterObject) sObject11).set_Value((object) ((TextBox) this.S_Txttipo).Text);
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_vn_id");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject12).set_Size(30);
      ((ParameterObject) sObject12).set_Value(((ListControl) this.cmbsvenditore).SelectedIndex == 0 ? (object) "" : (object) ((ListControl) this.cmbsvenditore).Items[((ListControl) this.cmbsvenditore).SelectedIndex].Text);
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_eqstd_id");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject13).set_Value((object) int.Parse(((ListControl) this.cmbsApparecchiatura).SelectedValue.Split(Convert.ToChar(" "))[0]));
      CollezioneControlli.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("p_id_bl");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject14).set_Value((object) int.Parse(this.BL_ID));
      CollezioneControlli.Add(sObject14);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("p_id_fl");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject15).set_Value((object) int.Parse(((ListControl) this.cmbsPiano).SelectedValue.Split(Convert.ToChar(" "))[0]));
      CollezioneControlli.Add(sObject15);
      S_Object sObject16 = new S_Object();
      ((ParameterObject) sObject16).set_ParameterName("p_id_condition");
      ((ParameterObject) sObject16).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject16).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject16).set_Size(200);
      ((ParameterObject) sObject16).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject16).set_Value(((ListControl) this.cmbsCondizione).SelectedValue == "" ? (object) "" : (object) ((ListControl) this.cmbsCondizione).SelectedValue);
      CollezioneControlli.Add(sObject16);
      S_Object sObject17 = new S_Object();
      ((ParameterObject) sObject17).set_ParameterName("p_id_vn");
      ((ParameterObject) sObject17).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject17).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject17).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject17).set_Value((object) (((ListControl) this.cmbsvenditore).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsvenditore).SelectedValue)));
      CollezioneControlli.Add(sObject17);
      S_Object sObject18 = new S_Object();
      ((ParameterObject) sObject18).set_ParameterName("p_max");
      ((ParameterObject) sObject18).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject18).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject18).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject18).set_Value((object) num1);
      CollezioneControlli.Add(sObject18);
      S_Object sObject19 = new S_Object();
      ((ParameterObject) sObject19).set_ParameterName("p_subcomponent_of");
      ((ParameterObject) sObject19).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject19).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject19).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject19).set_Size(12);
      ((ParameterObject) sObject19).set_Value(((ListControl) this.cmbsMacro).SelectedIndex == 0 ? (object) "" : (object) ((ListControl) this.cmbsMacro).SelectedValue);
      CollezioneControlli.Add(sObject19);
      S_Object sObject20 = new S_Object();
      ((ParameterObject) sObject20).set_ParameterName("p_date_start_validate");
      ((ParameterObject) sObject20).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject20).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject20).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject20).set_Size(15);
      ((ParameterObject) sObject20).set_Value((object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject20);
      S_Object sObject21 = new S_Object();
      ((ParameterObject) sObject21).set_ParameterName("p_date_end_validate");
      ((ParameterObject) sObject21).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject21).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject21).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject21).set_Size(15);
      ((ParameterObject) sObject21).set_Value((object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      CollezioneControlli.Add(sObject21);
      S_Object sObject22 = new S_Object();
      ((ParameterObject) sObject22).set_ParameterName("p_dismesso");
      ((ParameterObject) sObject22).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject22).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject22).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject22).set_Value(((CheckBox) this.ChekDismesso).Checked ? (object) "1" : (object) "0");
      CollezioneControlli.Add(sObject22);
      S_Object sObject23 = new S_Object();
      ((ParameterObject) sObject23).set_ParameterName("p_rif");
      ((ParameterObject) sObject23).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject23).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject23).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject23).set_Size(16);
      ((ParameterObject) sObject23).set_Value((object) ((TextBox) this.S_TxtRif).Text);
      CollezioneControlli.Add(sObject23);
      S_Object sObject24 = new S_Object();
      ((ParameterObject) sObject24).set_ParameterName("p_idunita");
      ((ParameterObject) sObject24).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject24).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject24).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject24).set_Size(23);
      ((ParameterObject) sObject24).set_Value((object) Convert.ToInt32(((ListControl) this.cmbsUnita).SelectedValue));
      CollezioneControlli.Add(sObject24);
      string str2 = (((TextBox) this.S_TxtqtaMatInt).Text == "" ? "0" : ((TextBox) this.S_TxtqtaMatInt).Text) + "," + (((TextBox) this.S_TxtqtaMatDec).Text == "" ? "00" : ((TextBox) this.S_TxtqtaMatDec).Text);
      S_Object sObject25 = new S_Object();
      ((ParameterObject) sObject25).set_ParameterName("p_numerounita");
      ((ParameterObject) sObject25).set_DbType((CustomDBType) 3);
      ((ParameterObject) sObject25).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject25).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject25).set_Size(23);
      ((ParameterObject) sObject25).set_Value((object) Convert.ToDecimal(str2));
      CollezioneControlli.Add(sObject25);
      int num2 = 0;
      if (this.Contatore.Checked)
        num2 = 1;
      S_Object sObject26 = new S_Object();
      ((ParameterObject) sObject26).set_ParameterName("p_contatore");
      ((ParameterObject) sObject26).set_DbType((CustomDBType) 3);
      ((ParameterObject) sObject26).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject26).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject26).set_Size(23);
      ((ParameterObject) sObject26).set_Value((object) num2);
      CollezioneControlli.Add(sObject26);
      S_Object sObject27 = new S_Object();
      ((ParameterObject) sObject27).set_ParameterName("p_um_id");
      ((ParameterObject) sObject27).set_DbType((CustomDBType) 3);
      ((ParameterObject) sObject27).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject27).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject27).set_Size(23);
      ((ParameterObject) sObject27).set_Value((object) Convert.ToInt32(((ListControl) this.cmbsUDM).SelectedValue));
      CollezioneControlli.Add(sObject27);
      S_Object sObject28 = new S_Object();
      ((ParameterObject) sObject28).set_ParameterName("p_id_ente_erogante");
      ((ParameterObject) sObject28).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject28).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject28).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject28).set_Size(23);
      ((ParameterObject) sObject28).set_Value((object) Convert.ToInt32(((ListControl) this.cmbEnteErogante).SelectedValue));
      CollezioneControlli.Add(sObject28);
      try
      {
        this.IDEQ = (!(this.IDEQ == "") ? datiApparecchiatura.Update(CollezioneControlli, int.Parse(this.IDEQ)) : datiApparecchiatura.Add(CollezioneControlli)).ToString();
        this.PostFile(str1);
        this.S_BtDatiTecnici.Disabled = false;
        this.GetData();
      }
      catch (Exception ex)
      {
        ((Label) this.S_Lblerror).Text = ex.Message;
      }
    }

    private string valutafile(string filename)
    {
      if (this.Uploader.PostedFile == null || !(this.Uploader.PostedFile.FileName != "") || !(this.Uploader.PostedFile.ContentType == "image/pjpeg") && !(this.Uploader.PostedFile.ContentType == "image/bmp") && !(this.Uploader.PostedFile.ContentType == "image/gif"))
        return this.ImageName;
      string extension = Path.GetExtension(this.Uploader.PostedFile.FileName);
      return filename + extension;
    }

    private void PostFile(string fileName)
    {
      if (this.Uploader.PostedFile == null)
        return;
      if (!(this.Uploader.PostedFile.FileName != ""))
        return;
      try
      {
        if (this.Uploader.PostedFile.ContentType == "image/pjpeg" || this.Uploader.PostedFile.ContentType == "image/bmp" || this.Uploader.PostedFile.ContentType == "image/gif")
        {
          string path1 = this.Server.MapPath("../EQImages");
          string extension = Path.GetExtension(this.Uploader.PostedFile.FileName);
          this.Uploader.PostedFile.SaveAs(Path.Combine(path1, fileName + extension));
        }
        else
          ((Label) this.S_Lblerror).Text = "File selezionato non valido!";
      }
      catch (Exception ex)
      {
        ((Label) this.S_Lblerror).Text = string.Format("Errore nell'invio dell'immagine: {0}", (object) ex.Message);
        Console.WriteLine(ex.Message);
      }
    }

    private void DataGridEsegui_CancelCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.EditItemIndex = -1;
      this.BindGrid();
      this.DataGridEsegui.Columns[1].Visible = true;
      this.DataGridEsegui.Columns[2].Visible = false;
      this.DataGridEsegui.Columns[3].Visible = false;
    }

    private void DataGridEsegui_EditCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.EditItemIndex = e.Item.ItemIndex;
      this.BindGrid();
      this.DataGridEsegui.Columns[1].Visible = false;
      this.DataGridEsegui.Columns[2].Visible = true;
      this.DataGridEsegui.Columns[3].Visible = false;
    }

    private void DataGridEsegui_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      AllegatiEQ allegatiEq = new AllegatiEQ();
      int num = 0;
      S_TextBox control1 = (S_TextBox) e.Item.FindControl("ddldescrizioneNew");
      HtmlInputFile control2 = (HtmlInputFile) e.Item.FindControl("Upload");
      switch (((ImageButton) e.CommandSource).CommandName)
      {
        case "Insert":
          if (((TextBox) control1).Text != string.Empty && control2.PostedFile != null && control2.PostedFile.FileName != "")
          {
            if (control2.PostedFile.ContentType == "image/pjpeg" || control2.PostedFile.ContentType == "image/jpg" || control2.PostedFile.ContentType == "application/pdf")
            {
              FileInfo fileInfo = new FileInfo(control2.PostedFile.FileName);
              try
              {
                string path1 = this.Server.MapPath("../EQAllegati");
                Path.GetExtension(control2.PostedFile.FileName);
                string filename = Path.Combine(path1, fileInfo.Name);
                control2.PostedFile.SaveAs(filename);
              }
              catch (Exception ex)
              {
                ((Label) this.S_Lblerror).Text = string.Format("Errore nell'invio del file: {0}", (object) ex.Message);
                Console.WriteLine(ex.Message);
              }
              num = allegatiEq.Add(this.ControlsAllegati(((TextBox) control1).Text, fileInfo.Name));
            }
            else
              this.PanelMess.ShowError("Scelta del formato di file non valido");
          }
          else
            this.PanelMess.ShowError("Obbligatori descrizione e scelta del file");
          try
          {
            if (num > 0)
            {
              this.DataGridEsegui.EditItemIndex = -1;
              this.BindGrid();
              this.DataGridEsegui.Columns[1].Visible = true;
              this.DataGridEsegui.Columns[2].Visible = false;
              this.DataGridEsegui.Columns[3].Visible = false;
              break;
            }
            this.DataGridEsegui.Columns[1].Visible = false;
            this.DataGridEsegui.Columns[2].Visible = false;
            this.DataGridEsegui.Columns[3].Visible = true;
            break;
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
            this.PanelMess.ShowError("Errore: Inserimento dell'allegato non riuscita", true);
            break;
          }
        case "Delete":
          int itemId = int.Parse(this.DataGridEsegui.DataKeys[e.Item.ItemIndex].ToString());
          string path = ConfigurationSettings.AppSettings["PathDocAllegatiEQ"] + "/" + ((HyperLink) e.Item.FindControl("hlink")).Text;
          if (File.Exists(this.Server.MapPath(path)))
          {
            File.Delete(this.Server.MapPath(path));
            try
            {
              if (allegatiEq.Delete(this.ControlsAllegati(DBNull.Value.ToString(), DBNull.Value.ToString()), itemId) == -1)
              {
                this.DataGridEsegui.EditItemIndex = -1;
                this.BindGrid();
              }
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
              this.PanelMess.ShowError("Errore: Cancellazione dell'allegato non riuscito", true);
            }
          }
          else
            this.PanelMess.ShowMessage("Nessun file presente nel server");
          this.DataGridEsegui.Columns[1].Visible = true;
          this.DataGridEsegui.Columns[2].Visible = false;
          this.DataGridEsegui.Columns[3].Visible = false;
          break;
      }
    }

    private void DataGridEsegui_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
      int itemId = int.Parse(this.DataGridEsegui.DataKeys[e.Item.ItemIndex].ToString());
      AllegatiEQ allegatiEq = new AllegatiEQ();
      S_TextBox control = (S_TextBox) e.Item.FindControl("ddldescrizione");
      this.Upload = (HtmlInputFile) e.Item.FindControl("Upload");
      try
      {
        if (allegatiEq.Update(this.ControlsAllegati(((TextBox) control).Text, DBNull.Value.ToString()), itemId) > 0)
        {
          this.DataGridEsegui.EditItemIndex = -1;
          this.BindGrid();
          this.DataGridEsegui.Columns[1].Visible = true;
          this.DataGridEsegui.Columns[2].Visible = false;
          this.DataGridEsegui.Columns[3].Visible = false;
        }
        else
        {
          this.DataGridEsegui.Columns[1].Visible = false;
          this.DataGridEsegui.Columns[2].Visible = true;
          this.DataGridEsegui.Columns[3].Visible = false;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private void DataGridEsegui_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.EditItem)
        return;
      DataRowView dataItem = (DataRowView) e.Item.DataItem;
      ImageButton control = (ImageButton) e.Item.Controls[1].Controls[3];
      control.CausesValidation = false;
      control.Attributes.Add("onclick", "return confirm(\"Eliminare il documento: " + dataItem["descrizione"].ToString() + " dell'apparecchiatura : " + dataItem[nameof (DescrizioneApparecchiatura)].ToString() + "?\")");
    }

    private S_ControlsCollection ControlsAllegati(
      string Descrizione,
      string nomefile)
    {
      int num1 = 0;
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      int num2 = 0;
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(num2);
      ((ParameterObject) sObject1).set_Value((object) Descrizione);
      controlsCollection.Add(sObject1);
      int num3 = num2 + 1;
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_nomefile");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Index(num3);
      ((ParameterObject) sObject2).set_Value((object) nomefile);
      controlsCollection.Add(sObject2);
      int num4 = num3 + 1;
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_eq");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Index(num4);
      ((ParameterObject) sObject3).set_Value((object) int.Parse(this.IDEQ));
      controlsCollection.Add(sObject3);
      num1 = num4 + 1;
      return controlsCollection;
    }

    private void BindGrid()
    {
      AllegatiEQ allegatiEq = new AllegatiEQ();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_eq");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Size(10);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) int.Parse(this.IDEQ));
      CollezioneControlli.Add(sObject);
      DataSet dataSet = allegatiEq.GetData(CollezioneControlli).Copy();
      this.DataGridEsegui.DataSource = (object) dataSet.Tables[0];
      this.DataGridEsegui.DataBind();
      this.lblRecord.Text = dataSet.Tables[0].Rows.Count.ToString();
      this.DataGridEsegui.ShowFooter = false;
    }

    private void lkbNuovo_Click(object sender, EventArgs e)
    {
      this.DataGridEsegui.ShowFooter = true;
      this.DataGridEsegui.Columns[1].Visible = false;
      this.DataGridEsegui.Columns[2].Visible = false;
      this.DataGridEsegui.Columns[3].Visible = true;
    }

    private void BtnNuovo_Click(object sender, EventArgs e)
    {
      ((ListControl) this.cmbsApparecchiatura).SelectedValue = "";
      ((ListControl) this.cmbsCondizione).SelectedValue = "";
      ((ListControl) this.cmbsPiano).SelectedValue = "";
      ((ListControl) this.cmbsMacro).SelectedValue = "- Selezionare il Macrocomponente -";
      ((ListControl) this.cmbsUnita).SelectedValue = "0";
      ((CheckBox) this.ChekDismesso).Checked = false;
      ((ListControl) this.cmbsvenditore).SelectedValue = "";
      ((TextBox) this.S_Txtmodello).Text = "";
      ((TextBox) this.S_Txtqta).Text = "";
      ((TextBox) this.S_TxtqtaMatDec).Text = "00";
      ((TextBox) this.S_TxtqtaMatInt).Text = "0";
      ((TextBox) this.S_TxtRif).Text = "";
      ((TextBox) this.S_Txttipo).Text = "";
      this.IDEQ = "";
      this.Context.Items.Add((object) "CODEDI", (object) ((Label) this.S_Lblcodedificio).Text);
      this.Context.Items.Add((object) "IDBL", (object) this.BL_ID);
      this.Context.Items.Add((object) "IDEQ", (object) this.IDEQ);
      this.Context.Items.Add((object) "SDESCRIZIONE", (object) ((Label) this.lblServizioDescription).Text);
      this.Context.Items.Add((object) "SID", (object) this.Hidden_idservizio.Value);
      this.Context.Items.Add((object) "DISMESSO", (object) "");
      this.Server.Transfer("DescrizioneApparecchiatura.aspx?FunId=" + (object) DescrizioneApparecchiatura.FunId);
    }
  }
}
