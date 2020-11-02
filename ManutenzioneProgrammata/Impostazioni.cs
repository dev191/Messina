// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.Impostazioni
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManOrdinaria;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class Impostazioni : Page
  {
    protected S_ComboBox cmbsMeseA;
    protected S_ComboBox cmbsAnnoA;
    protected S_ComboBox cmbsServizio;
    protected S_ComboBox cmbsDitta;
    protected S_Button btnsRicerca;
    protected DataPanel PanelRicerca;
    protected DataGrid DataGridRicerca;
    protected RicercaModulo RicercaModulo1;
    protected UserMeseGiorno UserMeseGiorno1;
    protected UserMeseGiorno UserMeseGiorno2;
    protected GridTitle GridTitle1;
    public static string HelpLink = string.Empty;
    protected PageTitle PageTitle1;
    protected S_ComboBox cmbsAddettoMod;
    protected S_Button btnsSalva;
    protected Panel PanelAddetto;
    protected S_ComboBox cmbsTutti;
    protected S_Button btnsSelezionaTutti;
    protected S_Button btnsConfermaSelezioni;
    protected CheckBox chkAbilitaData;
    protected Label LblElementiSelezionati;
    protected TextBox txtTotSelezionati;
    protected S_Button btnsDeSelezionaTutti;
    protected Button cmdReset;
    public static int FunId = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      Impostazioni.HelpLink = "";
      this.PageTitle1.Title = "Impostazioni Iniziali";
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      ((WebControl) this.UserMeseGiorno2.cmbMesi).Attributes.Add("onchange", "ImpostaGiorni(this.value,'" + ((Control) this.UserMeseGiorno2.cmbGiorni).ClientID + "')");
      this.chkAbilitaData.Attributes.Add("onclick", "AbilitaData(this.name,'" + ((Control) this.UserMeseGiorno2.cmbMesi).ClientID + "','" + ((Control) this.UserMeseGiorno2.cmbGiorni).ClientID + "')");
      this.RicercaModulo1.DelegateCodiceEdificio1 = new DelegateCodiceEdificio(this.BindServizi);
      ((WebControl) this.UserMeseGiorno2.cmbMesi).Enabled = this.chkAbilitaData.Checked;
      ((WebControl) this.UserMeseGiorno2.cmbGiorni).Enabled = this.chkAbilitaData.Checked;
      ((WebControl) this.btnsRicerca).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsConfermaSelezioni).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsSelezionaTutti).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsDeSelezionaTutti).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsSalva).Attributes.Add("onclick", "Valorizza('1')");
      if (this.Page.IsPostBack)
        return;
      this.ImpostaGiorni(((ListControl) this.UserMeseGiorno2.cmbMesi).SelectedValue, this.UserMeseGiorno2.cmbGiorni);
      this.LblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
      this.txtTotSelezionati.Text = "0";
      this.BindControls();
      this.Session.Remove("CheckedList");
      this.Session.Remove("DatiList");
      this.Session.Remove("DataSet");
    }

    private void ImpostaGiorni(string mese, S_ComboBox Giorni)
    {
      int num;
      switch (mese)
      {
        case "4":
        case "6":
        case "9":
        case "11":
          num = 30;
          break;
        case "2":
          num = 28;
          break;
        default:
          num = 31;
          break;
      }
      ((ListControl) Giorni).Items.Clear();
      for (int index = 1; index <= num; ++index)
      {
        ListItem listItem = new ListItem(index.ToString(), index.ToString());
        ((ListControl) Giorni).Items.Add(listItem);
      }
    }

    private void BindControls() => this.BindServizi("");

    private void BindServizi(string CodEdificio)
    {
      this.CaricaDitte();
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      Servizi servizi = new Servizi(this.Context.User.Identity.Name);
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
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) data.Tables[0];
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", string.Empty));
    }

    private void CaricaDitte()
    {
      string text = ((TextBox) this.RicercaModulo1.TxtCodice).Text;
      if (text != "")
      {
        DataSet idBl = new TheSite.Classi.Function().GetIdBL(text);
        if (idBl.Tables[0].Rows.Count <= 0)
          return;
        this.BindDitte(int.Parse(idBl.Tables[0].Rows[0][0].ToString()));
      }
      else
        this.BindDitte(0);
    }

    private S_ControlsCollection GetControl()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      int num1 = 0;
      if (((ListControl) this.cmbsDitta).SelectedValue != "")
        num1 = int.Parse(((ListControl) this.cmbsDitta).SelectedValue);
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id_ditta");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Size(4);
      ((ParameterObject) sObject1).set_Value((object) num1);
      controlsCollection.Add(sObject1);
      int num2 = 0;
      if (((ListControl) this.cmbsServizio).SelectedValue != "")
        num2 = int.Parse(((ListControl) this.cmbsServizio).SelectedValue);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_id_servizio");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(4);
      ((ParameterObject) sObject2).set_Value((object) num2);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_cod_edificio");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size(20);
      ((ParameterObject) sObject3).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text.Trim());
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_Tipologia");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size(20);
      ((ParameterObject) sObject4).set_Value((object) ((ListControl) this.cmbsTutti).SelectedValue);
      controlsCollection.Add(sObject4);
      return controlsCollection;
    }

    private void Ricerca(bool reset)
    {
      this.cmbsDitta.set_DBDefaultValue((object) "0");
      this.cmbsServizio.set_DBDefaultValue((object) "0");
      S_ControlsCollection control1 = this.GetControl();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pageindex");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(16);
      ((ParameterObject) sObject1).set_Value((object) (this.DataGridRicerca.CurrentPageIndex + 1));
      control1.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pagesize");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(17);
      ((ParameterObject) sObject2).set_Value((object) this.DataGridRicerca.PageSize);
      control1.Add(sObject2);
      TheSite.Classi.ManProgrammata.Impostazioni impostazioni = new TheSite.Classi.ManProgrammata.Impostazioni();
      DataSet dataSet = impostazioni.GetImpostazioniDefaultPaging(control1).Copy();
      if (reset)
      {
        S_ControlsCollection control2 = this.GetControl();
        this.GridTitle1.NumeroRecords = impostazioni.GetImpostazioniDefaultCount(control2).ToString();
      }
      this.DataGridRicerca.Visible = true;
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.DataGridRicerca.DataBind();
      if (int.Parse(this.GridTitle1.NumeroRecords) > 0)
        this.PanelAddetto.Visible = true;
      else
        this.PanelAddetto.Visible = false;
    }

    private void BindDitte(int idbl)
    {
      ((ListControl) this.cmbsDitta).Items.Clear();
      Ditte ditte = new Ditte();
      int idditta = idbl <= 0 ? 0 : int.Parse(ditte.GetDittaBl(idbl).Tables[0].Rows[0]["id_ditta"].ToString());
      DataSet ditteFornitoriRuoli = ditte.GetDitteFornitoriRuoli(idditta);
      if (ditteFornitoriRuoli.Tables[0].Rows.Count > 0)
      {
        this.DataGridRicerca.CurrentPageIndex = 0;
        ((BaseDataBoundControl) this.cmbsDitta).DataSource = (object) ditteFornitoriRuoli.Tables[0];
        ((ListControl) this.cmbsDitta).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsDitta).DataValueField = "id";
        ((Control) this.cmbsDitta).DataBind();
      }
      else
        ((ListControl) this.cmbsDitta).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Ditta  -", string.Empty));
    }

    private void BindAddettiDitta(string bl_id, int ditta_id)
    {
      ((ListControl) this.cmbsAddettoMod).Items.Clear();
      DataSet addetti = new Richiesta().GetAddetti("", bl_id, ditta_id);
      if (addetti.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsAddettoMod).DataSource = (object) addetti.Tables[0];
        ((ListControl) this.cmbsAddettoMod).DataTextField = "NOMINATIVO";
        ((ListControl) this.cmbsAddettoMod).DataValueField = "ID";
        ((Control) this.cmbsAddettoMod).DataBind();
      }
      else
        ((ListControl) this.cmbsAddettoMod).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Addetto  -", ""));
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

    private void GetControlli()
    {
      clMyDataGridCollection dataGridCollection = new clMyDataGridCollection();
      if (this.Session["CheckedList"] == null)
        return;
      dataGridCollection.GetControl(this.DataGridRicerca, (Hashtable) this.Session["CheckedList"], this.DataGridRicerca.CurrentPageIndex);
    }

    private void SetDati()
    {
      Hashtable hashtable = new Hashtable();
      if (this.Session["DatiList"] != null)
        hashtable = (Hashtable) this.Session["DatiList"];
      foreach (DataGridItem dataGridItem in this.DataGridRicerca.Items)
      {
        DataGridField dataGridField = new DataGridField();
        dataGridField.idbl = int.Parse(dataGridItem.Cells[2].Text);
        CheckBox control1 = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
        if (hashtable.ContainsKey((object) dataGridField.idbl))
          hashtable.Remove((object) dataGridField.idbl);
        Label control2 = (Label) dataGridItem.Cells[7].FindControl("LblAddetto");
        if (control1.Checked)
        {
          dataGridField.idditta = int.Parse(dataGridItem.Cells[3].Text);
          dataGridField.idservizio = int.Parse(dataGridItem.Cells[5].Text);
          UserMeseGiorno control3 = (UserMeseGiorno) dataGridItem.Cells[9].FindControl("UserMeseGiorno1");
          if (this.chkAbilitaData.Checked)
          {
            ((ListControl) control3.cmbMesi).SelectedValue = ((ListControl) this.UserMeseGiorno2.cmbMesi).SelectedValue;
            this.ImpostaGiorni(((ListControl) control3.cmbMesi).SelectedValue, control3.cmbGiorni);
            ((ListControl) control3.cmbGiorni).SelectedValue = ((ListControl) this.UserMeseGiorno2.cmbGiorni).SelectedValue;
          }
          control2.Text = ((ListControl) this.cmbsAddettoMod).SelectedItem.Text;
          dataGridField.mesegiorno = ((ListControl) control3.cmbMesi).SelectedValue.PadLeft(2, Convert.ToChar("0")) + ((ListControl) control3.cmbGiorni).SelectedValue.PadLeft(2, Convert.ToChar("0"));
          dataGridField.idaddetto = int.Parse(((ListControl) this.cmbsAddettoMod).SelectedValue);
          hashtable.Add((object) dataGridField.idbl, (object) dataGridField);
        }
        else
          control2.Text = dataGridItem.Cells[10].Text;
      }
      this.Session.Remove("DatiList");
      this.Session.Add("DatiList", (object) hashtable);
      this.LblElementiSelezionati.Text = "Elementi Selezionati - " + hashtable.Count.ToString() + " -";
      this.txtTotSelezionati.Text = hashtable.Count.ToString();
    }

    private void SetDati(bool val)
    {
      Hashtable hashtable = new Hashtable();
      if (this.Session["DatiList"] != null)
        hashtable = (Hashtable) this.Session["DatiList"];
      foreach (DataGridItem dataGridItem in this.DataGridRicerca.Items)
      {
        DataGridField dataGridField = new DataGridField();
        dataGridField.idbl = int.Parse(dataGridItem.Cells[2].Text);
        CheckBox control1 = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
        control1.Checked = val;
        if (hashtable.ContainsKey((object) dataGridField.idbl))
          hashtable.Remove((object) dataGridField.idbl);
        if (control1.Checked)
        {
          dataGridField.idditta = int.Parse(dataGridItem.Cells[3].Text);
          dataGridField.idservizio = int.Parse(dataGridItem.Cells[5].Text);
          UserMeseGiorno control2 = (UserMeseGiorno) dataGridItem.Cells[9].FindControl("UserMeseGiorno1");
          if (this.chkAbilitaData.Checked)
          {
            ((ListControl) control2.cmbMesi).SelectedValue = ((ListControl) this.UserMeseGiorno2.cmbMesi).SelectedValue;
            this.ImpostaGiorni(((ListControl) control2.cmbMesi).SelectedValue, control2.cmbGiorni);
            ((ListControl) control2.cmbGiorni).SelectedValue = ((ListControl) this.UserMeseGiorno2.cmbGiorni).SelectedValue;
          }
          ((Label) dataGridItem.Cells[7].FindControl("LblAddetto")).Text = ((ListControl) this.cmbsAddettoMod).SelectedItem.Text;
          dataGridField.mesegiorno = ((ListControl) control2.cmbMesi).SelectedValue.PadLeft(2, Convert.ToChar("0")) + ((ListControl) control2.cmbGiorni).SelectedValue.PadLeft(2, Convert.ToChar("0"));
          dataGridField.idaddetto = int.Parse(((ListControl) this.cmbsAddettoMod).SelectedValue);
          hashtable.Add((object) dataGridField.idbl, (object) dataGridField);
        }
      }
      this.Session.Remove("DatiList");
      this.Session.Add("DatiList", (object) hashtable);
      this.LblElementiSelezionati.Text = "Elementi Selezionati - " + hashtable.Count.ToString() + " -";
      this.txtTotSelezionati.Text = hashtable.Count.ToString();
    }

    private void SelezionaTutti(bool val)
    {
      if (!val)
      {
        this.Session.Remove("CheckedList");
        this.Session.Remove("DatiList");
        this.LblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
        this.txtTotSelezionati.Text = "0";
      }
      else
        this.SetControlli();
      DataSet dataSet = new TheSite.Classi.ManProgrammata.Impostazioni().GetImpostazioniDefault(this.GetControl()).Copy();
      for (int index = 0; index <= this.DataGridRicerca.PageCount; ++index)
      {
        this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
        this.DataGridRicerca.DataBind();
        this.DataGridRicerca.CurrentPageIndex = index;
        this.SetDati(val);
        if (val)
          this.SetControlli();
      }
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.Ricerca(true);
      this.GetControlli();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.cmdReset.Click += new EventHandler(this.cmdReset_Click);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      ((Button) this.btnsConfermaSelezioni).Click += new EventHandler(this.btnsConfermaSelezioni_Click);
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      ((Button) this.btnsSelezionaTutti).Click += new EventHandler(this.btnsSelezionaTutti_Click);
      ((Button) this.btnsDeSelezionaTutti).Click += new EventHandler(this.btnsDeSelezionaTutti_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.BindAddettiDitta("", int.Parse(((ListControl) this.cmbsDitta).SelectedValue));
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

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      UserMeseGiorno control = (UserMeseGiorno) e.Item.Cells[9].FindControl("UserMeseGiorno1");
      string str1 = "ImpostaGiorni(this.value,'" + ((Control) control.cmbGiorni).ClientID + "')";
      ((WebControl) control.cmbMesi).Attributes.Add("onchange", str1);
      string text1 = e.Item.Cells[8].Text;
      if (HttpUtility.HtmlDecode(text1).Trim() != "")
      {
        string s1 = text1.Substring(0, 2);
        string s2 = text1.Substring(2, 2);
        string mese = short.Parse(s1).ToString();
        string str2 = short.Parse(s2).ToString();
        ((ListControl) control.cmbMesi).SelectedValue = mese;
        this.ImpostaGiorni(mese, control.cmbGiorni);
        ((ListControl) control.cmbGiorni).SelectedValue = str2;
      }
      else
        this.ImpostaGiorni(((ListControl) control.cmbMesi).SelectedValue, control.cmbGiorni);
      string text2 = e.Item.Cells[10].Text;
      if (!(HttpUtility.HtmlDecode(text2).Trim() != ""))
        return;
      ((Label) e.Item.Cells[7].FindControl("LblAddetto")).Text = text2;
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      TheSite.Classi.ManProgrammata.Impostazioni impostazioni = new TheSite.Classi.ManProgrammata.Impostazioni();
      if (this.Session["DatiList"] == null)
        return;
      impostazioni.beginTransaction();
      try
      {
        IDictionaryEnumerator enumerator = ((Hashtable) this.Session["DatiList"]).GetEnumerator();
        string empty = string.Empty;
        if (this.chkAbilitaData.Checked)
        {
          string str = ((ListControl) this.UserMeseGiorno2.cmbMesi).SelectedValue.PadLeft(2, Convert.ToChar("0")) + ((ListControl) this.UserMeseGiorno2.cmbGiorni).SelectedValue.PadLeft(2, Convert.ToChar("0"));
        }
        while (enumerator.MoveNext())
        {
          S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
          DataGridField dataGridField = (DataGridField) enumerator.Value;
          S_Object sObject1 = new S_Object();
          ((ParameterObject) sObject1).set_ParameterName("p_idbl");
          ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject1).set_Index(0);
          ((ParameterObject) sObject1).set_Value((object) dataGridField.idbl);
          CollezioneControlli.Add(sObject1);
          S_Object sObject2 = new S_Object();
          ((ParameterObject) sObject2).set_ParameterName("p_idditta");
          ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject2).set_Index(1);
          ((ParameterObject) sObject2).set_Value((object) dataGridField.idditta);
          CollezioneControlli.Add(sObject2);
          S_Object sObject3 = new S_Object();
          ((ParameterObject) sObject3).set_ParameterName("p_idservizio");
          ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject3).set_Index(2);
          ((ParameterObject) sObject3).set_Value((object) dataGridField.idservizio);
          CollezioneControlli.Add(sObject3);
          S_Object sObject4 = new S_Object();
          ((ParameterObject) sObject4).set_ParameterName("p_idaddetto");
          ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject4).set_Index(3);
          ((ParameterObject) sObject4).set_Value((object) dataGridField.idaddetto);
          CollezioneControlli.Add(sObject4);
          S_Object sObject5 = new S_Object();
          ((ParameterObject) sObject5).set_ParameterName("p_data");
          ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
          ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject5).set_Index(4);
          ((ParameterObject) sObject5).set_Value((object) dataGridField.mesegiorno);
          CollezioneControlli.Add(sObject5);
          if (((ListControl) this.cmbsTutti).SelectedValue == "1")
            impostazioni.Add(CollezioneControlli);
          else
            impostazioni.Update(CollezioneControlli, dataGridField.idbl);
        }
        impostazioni.commitTransaction();
        string text = this.txtTotSelezionati.Text;
        string messaggio = !(((ListControl) this.cmbsTutti).SelectedValue == "2") ? "Sono stati inseriti " + text + " Edifici nel Piano di Manutenzione" : "Sono stati modificati " + text + " Edifici nel Piano di Manutenzione";
        this.Resetta();
        this.Ricerca(true);
        SiteJavaScript.msgBox(this.Page, messaggio);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        impostazioni.rollbackTransaction();
      }
    }

    private void btnsConfermaSelezioni_Click(object sender, EventArgs e)
    {
      this.SetDati();
      this.SetControlli();
    }

    private void Resetta()
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.LblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
      this.txtTotSelezionati.Text = "0";
      this.Session.Remove("CheckedList");
      this.Session.Remove("DatiList");
      this.chkAbilitaData.Checked = false;
      ((ListControl) this.UserMeseGiorno2.cmbGiorni).SelectedValue = "1";
      ((ListControl) this.UserMeseGiorno2.cmbMesi).SelectedValue = "1";
      ((WebControl) this.UserMeseGiorno2.cmbGiorni).Enabled = false;
      ((WebControl) this.UserMeseGiorno2.cmbMesi).Enabled = false;
    }

    private void btnsSelezionaTutti_Click(object sender, EventArgs e) => this.SelezionaTutti(true);

    private void btnsDeSelezionaTutti_Click(object sender, EventArgs e) => this.SelezionaTutti(false);

    private void cmdReset_Click(object sender, EventArgs e) => this.Response.Redirect("Impostazioni.aspx?FunId=" + (object) Impostazioni.FunId);
  }
}
