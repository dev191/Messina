// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.CreaPianoMP
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
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManProgrammata;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class CreaPianoMP : Page
  {
    protected S_ComboBox cmbsAnnoA;
    protected S_ComboBox cmbsServizio;
    protected S_ComboBox cmbsDitta;
    protected S_Button btnsRicerca;
    protected DataPanel PanelRicerca;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected RicercaModulo RicercaModulo1;
    protected TheSite.WebControls.Addetti Addetti1;
    public static string HelpLink = string.Empty;
    public static int FunId = 0;
    protected S_ComboBox cmbsAddettoCompl;
    protected S_Button btnsCompletaOdl;
    protected S_ComboBox cmbsAddettoMod;
    protected S_Button btnsModificaODL;
    protected S_Button btnSChiudi;
    protected DataPanel DatapanelCompleta;
    protected S_Button btnsCrea;
    protected S_Button btnsSelezionaTutti;
    protected S_Button btnsDeSelezionaTutti;
    protected S_Button btnsConfermaSelezioni;
    protected Label LblElementiSelezionati;
    protected TextBox txtTotSelezionati;
    protected PageTitle PageTitle1;
    protected Button cmdReset;
    protected Panel PanelCrea;
    private resultSchedula pippo;

    private void Page_Load(object sender, EventArgs e)
    {
      this.RicercaModulo1.DelegateCodiceEdificio1 = new DelegateCodiceEdificio(this.BindServizi);
      ((WebControl) this.btnsRicerca).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsConfermaSelezioni).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsSelezionaTutti).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsDeSelezionaTutti).Attributes.Add("onclick", "Valorizza('0')");
      ((WebControl) this.btnsCrea).Attributes.Add("onclick", "Valorizza('1')");
      CreaPianoMP.HelpLink = "";
      this.PageTitle1.Title = "Crea Piano di Manutenzione Programmata";
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      if (this.Page.IsPostBack)
        return;
      this.BindControls();
      this.LblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
      this.txtTotSelezionati.Text = "0";
      this.BindControls();
      this.Session.Remove("CheckedList");
      this.Session.Remove("DatiList");
      this.Session.Remove("DataSet");
    }

    private void CaricaCombiAnni()
    {
      string str = DateTime.Now.Year.ToString();
      for (int index = 1999; index <= 2099; ++index)
      {
        ListItem listItem1 = new ListItem();
        ListItem listItem2 = new ListItem();
        listItem1.Text = index.ToString();
        listItem1.Value = index.ToString();
        listItem2.Text = index.ToString();
        listItem2.Value = index.ToString();
        ((ListControl) this.cmbsAnnoA).Items.Add(listItem1);
      }
      ((ListControl) this.cmbsAnnoA).SelectedValue = str;
    }

    private void BindControls()
    {
      this.CaricaCombiAnni();
      this.BindServizi("");
    }

    private void BindAddetti(string idbl)
    {
      int p_ditta_id = 0;
      if (((ListControl) this.cmbsDitta).SelectedValue != "")
        p_ditta_id = int.Parse(((ListControl) this.cmbsDitta).SelectedValue);
      this.Addetti1.Set_BL_ID_DITTA_ID(idbl, p_ditta_id);
    }

    private void CaricaDitte()
    {
      string text = ((TextBox) this.RicercaModulo1.TxtCodice).Text;
      if (text != "")
        this.BindDitte(int.Parse(new TheSite.Classi.Function().GetIdBL(text).Tables[0].Rows[0][0].ToString()));
      else
        this.BindDitte(0);
    }

    private void BindServizi(string CodEdificio)
    {
      this.CaricaDitte();
      this.BindAddetti(CodEdificio);
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
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "-- Tutti i Servizi --", "0");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", string.Empty));
    }

    private void BindDitte(int idbl)
    {
      ((ListControl) this.cmbsDitta).Items.Clear();
      Ditte ditte = new Ditte();
      int idditta = idbl <= 0 ? 0 : int.Parse(ditte.GetDittaBl(idbl).Tables[0].Rows[0]["id_ditta"].ToString());
      DataSet ditteFornitoriRuoli = ditte.GetDitteFornitoriRuoli(idditta);
      if (ditteFornitoriRuoli.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsDitta).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(ditteFornitoriRuoli.Tables[0], "DESCRIZIONE", "id", "-- Tutte Le Ditte --", "0");
        ((ListControl) this.cmbsDitta).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsDitta).DataValueField = "id";
        ((Control) this.cmbsDitta).DataBind();
      }
      else
        ((ListControl) this.cmbsDitta).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Ditta -", string.Empty));
    }

    private S_ControlsCollection GetControl()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      this.cmbsDitta.set_DBDefaultValue((object) "0");
      this.cmbsServizio.set_DBDefaultValue((object) "0");
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
      ((ParameterObject) sObject4).set_ParameterName("p_addetto");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size(4);
      ((ParameterObject) sObject4).set_Value((object) this.Addetti1.NomeCompleto);
      controlsCollection.Add(sObject4);
      int num3 = (int) short.Parse(((ListControl) this.cmbsAnnoA).SelectedValue);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_anno");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Size(10);
      ((ParameterObject) sObject5).set_Value((object) num3);
      controlsCollection.Add(sObject5);
      return controlsCollection;
    }

    private void Ricerca(bool reset)
    {
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
      CreaPiano creaPiano = new CreaPiano();
      DataSet dataSet = creaPiano.GetDataPaging(control1).Copy();
      if (reset)
      {
        S_ControlsCollection control2 = this.GetControl();
        this.GridTitle1.NumeroRecords = creaPiano.GetDataCount(control2).ToString();
      }
      this.DataGridRicerca.Visible = true;
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.DataGridRicerca.DataBind();
      if (int.Parse(this.GridTitle1.NumeroRecords) > 0)
        this.PanelCrea.Visible = true;
      else
        this.PanelCrea.Visible = false;
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
        DataGridField dataGridField = new DataGridField();
        dataGridField.idbl = int.Parse(dataGridItem.Cells[0].Text);
        CheckBox control = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
        if (hashtable.ContainsKey((object) dataGridField.idbl))
          hashtable.Remove((object) dataGridField.idbl);
        if (control.Checked)
        {
          dataGridField.idditta = int.Parse(dataGridItem.Cells[2].Text);
          dataGridField.idservizio = int.Parse(dataGridItem.Cells[3].Text);
          dataGridField.mesegiorno = dataGridItem.Cells[11].Text;
          dataGridField.idaddetto = int.Parse(dataGridItem.Cells[4].Text);
          hashtable.Add((object) dataGridField.idbl, (object) dataGridField);
        }
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
        dataGridField.idbl = int.Parse(dataGridItem.Cells[0].Text);
        CheckBox control = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
        control.Checked = val;
        if (hashtable.ContainsKey((object) dataGridField.idbl))
          hashtable.Remove((object) dataGridField.idbl);
        if (control.Checked)
        {
          dataGridField.idditta = int.Parse(dataGridItem.Cells[2].Text);
          dataGridField.idservizio = int.Parse(dataGridItem.Cells[3].Text);
          dataGridField.mesegiorno = dataGridItem.Cells[11].Text;
          dataGridField.idaddetto = int.Parse(dataGridItem.Cells[4].Text);
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
      DataSet dataSet = new CreaPiano().GetData(this.GetControl()).Copy();
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

    private void Resetta()
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.LblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
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
      ((ListControl) this.cmbsDitta).SelectedIndexChanged += new EventHandler(this.cmbsDitta_SelectedIndexChanged);
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.cmdReset.Click += new EventHandler(this.cmdReset_Click);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      ((Button) this.btnsCrea).Click += new EventHandler(this.btnsCrea_Click);
      ((Button) this.btnsSelezionaTutti).Click += new EventHandler(this.btnsSelezionaTutti_Click);
      ((Button) this.btnsDeSelezionaTutti).Click += new EventHandler(this.btnsDeSelezionaTutti_Click);
      ((Button) this.btnsConfermaSelezioni).Click += new EventHandler(this.btnsConfermaSelezioni_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void cmbsDitta_SelectedIndexChanged(object sender, EventArgs e) => this.BindAddetti(((TextBox) this.RicercaModulo1.TxtCodice).Text);

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
      CreaPiano creaPiano = new CreaPiano();
      if (this.Session["DatiList"] != null)
      {
        creaPiano.beginTransaction();
        try
        {
          IDictionaryEnumerator enumerator = ((Hashtable) this.Session["DatiList"]).GetEnumerator();
          string empty = string.Empty;
          string messaggio = string.Empty;
          while (enumerator.MoveNext())
          {
            S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
            DataGridField dataGridField = (DataGridField) enumerator.Value;
            S_Object sObject1 = new S_Object();
            ((ParameterObject) sObject1).set_ParameterName("i_DataFine");
            ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject1).set_Index(0);
            ((ParameterObject) sObject1).set_Value((object) short.Parse(((ListControl) this.cmbsAnnoA).SelectedValue));
            CollezioneControlli.Add(sObject1);
            S_Object sObject2 = new S_Object();
            ((ParameterObject) sObject2).set_ParameterName("i_Edificio");
            ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject2).set_Index(1);
            ((ParameterObject) sObject2).set_Value((object) dataGridField.idbl);
            CollezioneControlli.Add(sObject2);
            S_Object sObject3 = new S_Object();
            ((ParameterObject) sObject3).set_ParameterName("i_Category");
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
            ((ParameterObject) sObject5).set_ParameterName("p_datastart");
            ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
            ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject5).set_Index(4);
            ((ParameterObject) sObject5).set_Value((object) dataGridField.mesegiorno);
            CollezioneControlli.Add(sObject5);
            S_Object sObject6 = new S_Object();
            ((ParameterObject) sObject6).set_ParameterName("p_idditta");
            ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject6).set_Index(5);
            ((ParameterObject) sObject6).set_Value((object) dataGridField.idditta);
            CollezioneControlli.Add(sObject6);
            this.pippo = (resultSchedula) creaPiano.CreaPianoMP(CollezioneControlli);
          }
          creaPiano.commitTransaction();
          switch (this.pippo)
          {
            case resultSchedula.NO_PROCED_MAN:
              messaggio = "Nessuna procedura per l'edificio e il servizio selezionati!";
              break;
            case resultSchedula.GIA_SCHEDULATO:
              messaggio = "Procedura già schedulata per l'anno selezionato.!";
              break;
            case resultSchedula.NO_ADD_SPECIALIZZATO:
              messaggio = "Nessun addetto per la specializzazione corrente!";
              break;
            case resultSchedula.DATA_FUORI_INTERVALLO:
              messaggio = "La data selezionata è fuori dell'intervallo di validità!";
              break;
            case resultSchedula.NO_STAGIONALE:
              messaggio = "Non è stata trovata una corrispondenza stagionale!";
              break;
            case resultSchedula.SCHEDULAZIONE_OK:
              string text = this.txtTotSelezionati.Text;
              messaggio = short.Parse(text) <= (short) 1 ? "E` stato Pianificato " + text + " Edificio nel Piano di Manutenzione" : "Sono stati Pianificati " + text + " Edifici nel Piano di Manutenzione";
              break;
            case resultSchedula.NO_FREQ_FISSE:
              messaggio = "Non sono previste frequenze di tipo fisso per il seguente servizio!";
              break;
          }
          this.Resetta();
          this.DataGridRicerca.CurrentPageIndex = 0;
          this.Ricerca(true);
          SiteJavaScript.msgBox(this.Page, messaggio);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          creaPiano.rollbackTransaction();
          string empty = string.Empty;
          SiteJavaScript.msgBox(this.Page, "Si è verificato un errore durante la creazione del Piano.");
        }
      }
      else
        SiteJavaScript.msgBox(this.Page, "Nessun Edificio selezionato.");
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

    private void cmdReset_Click(object sender, EventArgs e) => this.Response.Redirect("CreaPianoMP.aspx?FunId=" + (object) CreaPianoMP.FunId);
  }
}
