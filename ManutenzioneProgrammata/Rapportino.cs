// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.Rapportino
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class Rapportino : Page
  {
    protected S_ComboBox cmbsAnno;
    protected S_ComboBox cmbMeseDa;
    protected S_ComboBox cmbMeseA;
    protected S_ComboBox cmbsComune;
    protected S_ComboBox cmbsEdificio;
    protected S_ComboBox cmbsServizio;
    protected S_ComboBox cmbsAddetti;
    protected S_Button btnsRicerca;
    protected TextBox txtTotSelezionati;
    protected DataPanel PanelRicerca;
    protected DataGrid DataGridRicerca;
    protected S_Button btnsSelezionaTutti;
    protected S_Button btnsDeSelezionaTutti;
    protected S_Button btnsConfermaSelezioni;
    protected Label LblElementiSelezionati;
    protected Panel PanelCrea;
    protected GridTitle GridTitle1;
    public static string HelpLink = string.Empty;
    protected S_TextBox txtsOrdine;
    protected S_Button btnsStampa;
    protected RadioButton StampaCorta;
    protected RadioButton StampaLunga;
    protected Button cmdReset;
    protected PageTitle PageTitle1;
    protected RadioButton StampaDettaglioLocaliCorta;
    protected RadioButton StampaDetaglioLocali;
    protected RadioButton StampaDetaglioLocaliLung2Pa;
    protected BottomMenu BottomMenu1;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((WebControl) this.txtsOrdine).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.txtsOrdine).Attributes.Add("onpaste", "return nonpaste();");
      ((WebControl) this.btnsRicerca).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsConfermaSelezioni).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsSelezionaTutti).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsDeSelezionaTutti).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsStampa).Attributes.Add("onclick", "Valorizza('1')");
      Rapportino.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = "Stampa Rapportino Tecnico di Intervento";
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      StringBuilder stringBuilder1 = new StringBuilder();
      stringBuilder1.Append("this.value = 'Attendere ...';");
      stringBuilder1.Append("this.disabled = true;");
      stringBuilder1.Append("document.getElementById('" + ((Control) this.btnsRicerca).ClientID + "').disabled = true;");
      stringBuilder1.Append(this.Page.GetPostBackEventReference((Control) this.btnsRicerca));
      stringBuilder1.Append(";");
      ((WebControl) this.btnsRicerca).Attributes.Add("onclick", stringBuilder1.ToString());
      StringBuilder stringBuilder2 = new StringBuilder();
      stringBuilder2.Append("document.getElementById('" + ((Control) this.cmbsComune).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsAnno).Attributes.Add("onchange", stringBuilder2.ToString());
      StringBuilder stringBuilder3 = new StringBuilder();
      stringBuilder3.Append("document.getElementById('" + ((Control) this.cmbsEdificio).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsComune).Attributes.Add("onchange", stringBuilder3.ToString());
      StringBuilder stringBuilder4 = new StringBuilder();
      stringBuilder4.Append("document.getElementById('" + ((Control) this.cmbsServizio).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsEdificio).Attributes.Add("onchange", stringBuilder4.ToString());
      StringBuilder stringBuilder5 = new StringBuilder();
      stringBuilder4.Append("this.value = 'Attendere ...';");
      stringBuilder4.Append("this.disabled = true;");
      stringBuilder4.Append("document.getElementById('" + ((Control) this.btnsStampa).ClientID + "').disabled = true;");
      stringBuilder4.Append(this.Page.GetPostBackEventReference((Control) this.btnsStampa));
      stringBuilder4.Append(";");
      ((WebControl) this.btnsStampa).Attributes.Add("onclick", stringBuilder4.ToString());
      StringBuilder stringBuilder6 = new StringBuilder();
      stringBuilder4.Append("this.value = 'Attendere ...';");
      stringBuilder4.Append("this.disabled = true;");
      stringBuilder4.Append("document.getElementById('" + ((Control) this.btnsConfermaSelezioni).ClientID + "').disabled = true;");
      stringBuilder4.Append(this.Page.GetPostBackEventReference((Control) this.btnsConfermaSelezioni));
      stringBuilder4.Append(";");
      ((WebControl) this.btnsConfermaSelezioni).Attributes.Add("onclick", stringBuilder4.ToString());
      StringBuilder stringBuilder7 = new StringBuilder();
      stringBuilder4.Append("this.value = 'Attendere ...';");
      stringBuilder4.Append("this.disabled = true;");
      stringBuilder4.Append("document.getElementById('" + ((Control) this.btnsSelezionaTutti).ClientID + "').disabled = true;");
      stringBuilder4.Append(this.Page.GetPostBackEventReference((Control) this.btnsSelezionaTutti));
      stringBuilder4.Append(";");
      ((WebControl) this.btnsSelezionaTutti).Attributes.Add("onclick", stringBuilder4.ToString());
      StringBuilder stringBuilder8 = new StringBuilder();
      stringBuilder4.Append("this.value = 'Attendere ...';");
      stringBuilder4.Append("this.disabled = true;");
      stringBuilder4.Append("document.getElementById('" + ((Control) this.btnsDeSelezionaTutti).ClientID + "').disabled = true;");
      stringBuilder4.Append(this.Page.GetPostBackEventReference((Control) this.btnsDeSelezionaTutti));
      stringBuilder4.Append(";");
      ((WebControl) this.btnsDeSelezionaTutti).Attributes.Add("onclick", stringBuilder4.ToString());
      if (this.Page.IsPostBack)
        return;
      if (this.Request.QueryString["FunId"] != null)
      {
        this.BottomMenu1.Visible = false;
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      }
      this.CaricaCombiAnni();
      this.CaricaComboMesi();
      this.BindControls();
      this.LblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
      this.EnableControl(false);
      this.txtTotSelezionati.Text = "0";
      this.Session.Remove("CheckedList");
      this.Session.Remove("DatiList");
      this.Session.Remove("DataSet");
    }

    private void CaricaCombiAnni() => ((ListControl) this.cmbsAnno).SelectedValue = DateTime.Now.Year.ToString();

    private void CaricaComboMesi()
    {
      DataTable month = new TheSite.Classi.ManProgrammata.Rapportino().GetMonth(Convert.ToInt32(((ListControl) this.cmbsAnno).SelectedValue));
      ((BaseDataBoundControl) this.cmbMeseDa).DataSource = (object) month;
      ((ListControl) this.cmbMeseDa).DataTextField = "mesedes";
      ((ListControl) this.cmbMeseDa).DataValueField = "mesenum";
      ((Control) this.cmbMeseDa).DataBind();
      if (((ListControl) this.cmbMeseDa).Items.Count > 0)
        ((ListControl) this.cmbMeseDa).SelectedIndex = 0;
      else
        ((ListControl) this.cmbMeseDa).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Mese -", "0"));
      ((BaseDataBoundControl) this.cmbMeseA).DataSource = (object) month;
      ((ListControl) this.cmbMeseA).DataTextField = "mesedes";
      ((ListControl) this.cmbMeseA).DataValueField = "mesenum";
      ((Control) this.cmbMeseA).DataBind();
      if (((ListControl) this.cmbMeseA).Items.Count > 0)
        ((ListControl) this.cmbMeseA).SelectedIndex = ((ListControl) this.cmbMeseA).Items.Count - 1;
      else
        ((ListControl) this.cmbMeseA).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Mese -", "0"));
    }

    private void BindControls()
    {
      this.BindComuni();
      this.BindEdifici();
      this.BindServizi();
      this.BindAddetti();
    }

    private void BindComuni()
    {
      ((ListControl) this.cmbsComune).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet comuni = new TheSite.Classi.ManProgrammata.Rapportino().GetComuni(Convert.ToInt32(((ListControl) this.cmbsAnno).SelectedValue), ((ListControl) this.cmbMeseDa).SelectedValue, ((ListControl) this.cmbMeseA).SelectedValue);
      if (comuni.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsComune).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(comuni.Tables[0], "COMUNE", "IDCOMUNE", "-- Selezionare un Comune --", "0");
        ((ListControl) this.cmbsComune).DataTextField = "COMUNE";
        ((ListControl) this.cmbsComune).DataValueField = "IDCOMUNE";
        ((Control) this.cmbsComune).DataBind();
      }
      else
        ((ListControl) this.cmbsComune).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Comune -", "0"));
    }

    private void BindEdifici()
    {
      ((ListControl) this.cmbsEdificio).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet edifici = new TheSite.Classi.ManProgrammata.Rapportino().GetEdifici(Convert.ToInt32(((ListControl) this.cmbsAnno).SelectedValue), Convert.ToInt32(((ListControl) this.cmbsComune).SelectedValue), ((ListControl) this.cmbMeseDa).SelectedValue, ((ListControl) this.cmbMeseA).SelectedValue, this.Context.User.Identity.Name);
      if (edifici.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsEdificio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(edifici.Tables[0], "EDIFICIO", "IDCOMPOSITO", "-- Selezionare un Edificio --", "0;0");
        ((ListControl) this.cmbsEdificio).DataTextField = "EDIFICIO";
        ((ListControl) this.cmbsEdificio).DataValueField = "IDCOMPOSITO";
        ((Control) this.cmbsEdificio).DataBind();
      }
      else
        ((ListControl) this.cmbsEdificio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Edificio -", "0;0"));
    }

    private void BindServizi()
    {
      string[] strArray = ((ListControl) this.cmbsEdificio).SelectedValue.Split(Convert.ToChar(";"));
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      TheSite.Classi.ManProgrammata.Rapportino rapportino = new TheSite.Classi.ManProgrammata.Rapportino();
      int.Parse(strArray[0]);
      DataSet servizi = rapportino.GetServizi(Convert.ToInt32(((ListControl) this.cmbsAnno).SelectedValue), Convert.ToInt32(((ListControl) this.cmbsComune).SelectedValue), Convert.ToInt32(strArray[0]), ((ListControl) this.cmbMeseDa).SelectedValue, ((ListControl) this.cmbMeseA).SelectedValue);
      if (servizi.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(servizi.Tables[0], "SERVIZIO", "IDSERVIZIO", "-- Selezionare un Servizio --", "0");
        ((ListControl) this.cmbsServizio).DataTextField = "SERVIZIO";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", "0"));
    }

    private void BindAddetti()
    {
      string[] strArray = ((ListControl) this.cmbsEdificio).SelectedValue.Split(Convert.ToChar(";"));
      ((ListControl) this.cmbsAddetti).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      TheSite.Classi.ManProgrammata.Rapportino rapportino = new TheSite.Classi.ManProgrammata.Rapportino();
      int.Parse(strArray[0]);
      DataSet addetti = rapportino.GetAddetti(Convert.ToInt32(((ListControl) this.cmbsAnno).SelectedValue), Convert.ToInt32(((ListControl) this.cmbsComune).SelectedValue), Convert.ToInt32(strArray[0]), Convert.ToInt32(((ListControl) this.cmbsServizio).SelectedValue), ((ListControl) this.cmbMeseDa).SelectedValue, ((ListControl) this.cmbMeseA).SelectedValue);
      if (addetti.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsAddetti).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(addetti.Tables[0], "Addetto", "IDAddetto", "-- Selezionare un Addetto --", "0");
        ((ListControl) this.cmbsAddetti).DataTextField = "Addetto";
        ((ListControl) this.cmbsAddetti).DataValueField = "IDAddetto";
        ((Control) this.cmbsAddetti).DataBind();
      }
      else
        ((ListControl) this.cmbsAddetti).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Addetto -", "0"));
    }

    private void Ricerca(bool reset)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      this.cmbsComune.set_DBDefaultValue((object) "0");
      this.cmbsEdificio.set_DBDefaultValue((object) "0");
      this.cmbsServizio.set_DBDefaultValue((object) "0");
      S_ControlsCollection data1 = this.GetData();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pageindex");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(16);
      ((ParameterObject) sObject1).set_Value((object) (this.DataGridRicerca.CurrentPageIndex + 1));
      data1.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pagesize");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(17);
      ((ParameterObject) sObject2).set_Value((object) this.DataGridRicerca.PageSize);
      data1.Add(sObject2);
      TheSite.Classi.ManProgrammata.Rapportino rapportino = new TheSite.Classi.ManProgrammata.Rapportino();
      DataSet dataSet = rapportino.GetData(data1).Copy();
      if (reset)
      {
        ((CollectionBase) data1).Clear();
        S_ControlsCollection data2 = this.GetData();
        this.GridTitle1.NumeroRecords = rapportino.getCount(data2).ToString();
      }
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.DataGridRicerca.DataBind();
    }

    private S_ControlsCollection GetData()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      int num1 = 0;
      if (((TextBox) this.txtsOrdine).Text != "")
        num1 = (int) short.Parse(((TextBox) this.txtsOrdine).Text);
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_wo_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(1);
      ((ParameterObject) sObject1).set_Value((object) num1);
      controlsCollection.Add(sObject1);
      int num2 = (int) short.Parse(((ListControl) this.cmbsAnno).SelectedValue);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_anno");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) num2);
      controlsCollection.Add(sObject2);
      int num3 = 0;
      if (((ListControl) this.cmbsComune).SelectedValue != "0")
        num3 = int.Parse(((ListControl) this.cmbsComune).SelectedValue);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_comune");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) num3);
      controlsCollection.Add(sObject3);
      int int32 = Convert.ToInt32(((ListControl) this.cmbsEdificio).SelectedValue.Split(Convert.ToChar(";"))[0]);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_edificio");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) int32);
      controlsCollection.Add(sObject4);
      int num4 = 0;
      if (((ListControl) this.cmbsServizio).SelectedValue != "0")
        num4 = int.Parse(((ListControl) this.cmbsServizio).SelectedValue);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_servizio");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) num4);
      controlsCollection.Add(sObject5);
      int num5 = 0;
      if (((ListControl) this.cmbsAddetti).SelectedValue != "0")
        num5 = int.Parse(((ListControl) this.cmbsAddetti).SelectedValue);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_addetto");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Size(10);
      ((ParameterObject) sObject6).set_Value((object) num5);
      controlsCollection.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("Mese1");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Size(10);
      ((ParameterObject) sObject7).set_Value((object) Convert.ToInt32(((ListControl) this.cmbMeseDa).SelectedValue));
      controlsCollection.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("Mese2");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(7);
      ((ParameterObject) sObject8).set_Size(10);
      ((ParameterObject) sObject8).set_Value((object) Convert.ToInt32(((ListControl) this.cmbMeseA).SelectedValue));
      controlsCollection.Add(sObject8);
      return controlsCollection;
    }

    private void GetControlli()
    {
      clMyDataGridCollection dataGridCollection = new clMyDataGridCollection();
      if (this.Session["CheckedList"] == null)
        return;
      dataGridCollection.GetControl(this.DataGridRicerca, (Hashtable) this.Session["CheckedList"], this.DataGridRicerca.CurrentPageIndex);
    }

    private void SetControlli()
    {
      clMyDataGridCollection dataGridCollection = new clMyDataGridCollection();
      Hashtable _HS = new Hashtable();
      if (this.Session["CheckedList"] != null)
        _HS = (Hashtable) this.Session["CheckedList"];
      Hashtable hashtable = dataGridCollection.SetControl(this.DataGridRicerca, _HS, this.DataGridRicerca.CurrentPageIndex);
      this.Session.Remove("CheckedList");
      this.Session.Add("CheckedList", (object) hashtable);
    }

    private void SetDati()
    {
      Hashtable hashtable = new Hashtable();
      if (this.Session["DatiList"] != null)
        hashtable = (Hashtable) this.Session["DatiList"];
      foreach (DataGridItem dataGridItem in this.DataGridRicerca.Items)
      {
        int num = int.Parse(dataGridItem.Cells[0].Text);
        CheckBox control = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
        if (hashtable.ContainsKey((object) num))
          hashtable.Remove((object) num);
        if (control.Checked)
          hashtable.Add((object) num, (object) num);
      }
      this.Session.Remove("DatiList");
      this.Session.Add("DatiList", (object) hashtable);
      this.LblElementiSelezionati.Text = "Elementi Selezionati - " + hashtable.Count.ToString() + " -";
      if (hashtable.Count > 0)
        this.EnableControl(true);
      else
        this.EnableControl(false);
      this.txtTotSelezionati.Text = hashtable.Count.ToString();
    }

    private void SetDati(bool val)
    {
      Hashtable hashtable = new Hashtable();
      if (this.Session["DatiList"] != null)
        hashtable = (Hashtable) this.Session["DatiList"];
      foreach (DataGridItem dataGridItem in this.DataGridRicerca.Items)
      {
        int num = int.Parse(dataGridItem.Cells[0].Text);
        CheckBox control = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
        control.Checked = val;
        if (hashtable.ContainsKey((object) num))
          hashtable.Remove((object) num);
        if (control.Checked)
          hashtable.Add((object) num, (object) num);
      }
      this.Session.Remove("DatiList");
      this.Session.Add("DatiList", (object) hashtable);
      this.LblElementiSelezionati.Text = "Elementi Selezionati - " + hashtable.Count.ToString() + " -";
      if (hashtable.Count > 0)
        this.EnableControl(true);
      else
        this.EnableControl(false);
      this.txtTotSelezionati.Text = hashtable.Count.ToString();
    }

    private void SelezionaTutti(bool val)
    {
      if (!val)
      {
        this.Session.Remove("CheckedList");
        this.Session.Remove("DatiList");
        this.LblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
        this.EnableControl(false);
        this.txtTotSelezionati.Text = "0";
      }
      else
        this.SetControlli();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      this.cmbsComune.set_DBDefaultValue((object) "0");
      this.cmbsEdificio.set_DBDefaultValue((object) "0");
      this.cmbsServizio.set_DBDefaultValue((object) "0");
      DataSet dataSel = new TheSite.Classi.ManProgrammata.Rapportino().GetDataSel(this.GetData());
      this.DataGridRicerca.AllowCustomPaging = false;
      this.DataGridRicerca.CurrentPageIndex = 0;
      for (int index = 0; index <= this.DataGridRicerca.PageCount; ++index)
      {
        this.DataGridRicerca.DataSource = (object) dataSel.Tables[0];
        this.DataGridRicerca.DataBind();
        this.DataGridRicerca.CurrentPageIndex = index;
        this.SetDati(val);
        if (val)
          this.SetControlli();
      }
      this.DataGridRicerca.AllowCustomPaging = true;
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.Ricerca(true);
      this.GetControlli();
    }

    private void Resetta()
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.LblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
      this.EnableControl(false);
      this.txtTotSelezionati.Text = "0";
      this.Session.Remove("CheckedList");
      this.Session.Remove("DatiList");
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsAnno).SelectedIndexChanged += new EventHandler(this.cmbsAnno_SelectedIndexChanged);
      ((ListControl) this.cmbsComune).SelectedIndexChanged += new EventHandler(this.cmbsComune_SelectedIndexChanged);
      ((ListControl) this.cmbsEdificio).SelectedIndexChanged += new EventHandler(this.cmbsEdificio_SelectedIndexChanged);
      ((ListControl) this.cmbsServizio).SelectedIndexChanged += new EventHandler(this.cmbsServizio_SelectedIndexChanged);
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.cmdReset.Click += new EventHandler(this.cmdReset_Click);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      ((Button) this.btnsStampa).Click += new EventHandler(this.btnsCrea_Click);
      ((Button) this.btnsSelezionaTutti).Click += new EventHandler(this.btnsSelezionaTutti_Click);
      ((Button) this.btnsDeSelezionaTutti).Click += new EventHandler(this.btnsDeSelezionaTutti_Click);
      ((Button) this.btnsConfermaSelezioni).Click += new EventHandler(this.btnsConfermaSelezioni_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.Resetta();
      this.Ricerca(true);
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca(false);
      this.GetControlli();
    }

    private void btnsConfermaSelezioni_Click(object sender, EventArgs e)
    {
      this.SetDati();
      this.SetControlli();
    }

    private void btnsSelezionaTutti_Click(object sender, EventArgs e) => this.SelezionaTutti(true);

    private void btnsDeSelezionaTutti_Click(object sender, EventArgs e) => this.SelezionaTutti(false);

    private void btnsCrea_Click(object sender, EventArgs e)
    {
      // ISSUE: unable to decompile the method.
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      string str1 = e.Item.Cells[10].Text.Trim();
      if (str1.Length <= 0)
        return;
      string str2 = str1.Substring(2, 2);
      int mese = (int) short.Parse(str1.Substring(0, 2));
      string str3 = TheSite.Classi.Function.ImpostaMese(mese, false);
      e.Item.Cells[10].Text = str2 + " - " + str3;
      e.Item.Cells[10].ToolTip = str2 + " - " + TheSite.Classi.Function.ImpostaMese(mese, true);
    }

    private void cmbsComune_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.BindEdifici();
      this.BindServizi();
      this.BindAddetti();
    }

    private void cmbsAnno_SelectedIndexChanged(object sender, EventArgs e) => this.BindControls();

    private void cmbsEdificio_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.BindServizi();
      this.BindAddetti();
    }

    private void cmbsServizio_SelectedIndexChanged(object sender, EventArgs e) => this.BindAddetti();

    private void EnableControl(bool enable)
    {
      ((WebControl) this.btnsStampa).Enabled = enable;
      this.StampaCorta.Enabled = enable;
      this.StampaLunga.Enabled = enable;
      this.StampaDetaglioLocali.Enabled = enable;
      this.StampaDettaglioLocaliCorta.Enabled = enable;
      this.StampaDetaglioLocaliLung2Pa.Enabled = enable;
    }

    private void cmdReset_Click(object sender, EventArgs e)
    {
      if (this.ViewState["FunId"] != null)
        this.Response.Redirect("Rapportino.aspx?FunID=" + this.ViewState["FunId"]);
      else
        this.Response.Redirect("Rapportino.aspx");
    }
  }
}
