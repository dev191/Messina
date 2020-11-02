// Decompiled with JetBrains decompiler
// Type: StampaRapportiPdf.Pagine.Ricerca_e_Stampa
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using CrystalDecisions.CrystalReports.Engine;
using Csy.WebControls;
using ICSharpCode.SharpZipLib.Zip;
using S_Controls;
using S_Controls.Collections;
using StampaRapportiPdf.Classi;
using StampaRapportiPdf.WebControls;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.StampaRapportiPDF.Reports;
using TheSite.StampaRapportiPDF.Schemixsd;

namespace StampaRapportiPdf.Pagine
{
  public class Ricerca_e_Stampa : Page
  {
    protected DataPanel DataPanelRicerca;
    protected CalendarPicker cldpkDaAssegnazione;
    protected CalendarPicker cldpkAAssegnazione;
    protected CalendarPicker cldpkDaCompletamento;
    protected CalendarPicker cldpkACompletamento;
    protected S_ComboBox S_ComboBox2;
    protected S_Label S_lblComune;
    protected S_Label S_lblEdificio;
    protected S_Label S_lblDitta;
    protected S_Label S_lblCategoria;
    protected S_ComboBox S_cmbComune;
    protected S_ComboBox S_cmbEdificio;
    protected S_ComboBox S_cmbDitta;
    protected S_ComboBox S_cmbCategoria;
    protected S_Label S_lblAddetto;
    protected S_ComboBox S_cmbAddetto;
    protected PageTitle PgTlStampaPdf;
    protected DataGrid DataGridRicerca;
    protected S_OptionButton S_optSolNonComp;
    protected S_OptionButton S_optSolComp;
    protected S_Label S_lblDataCompletamento;
    protected S_Button S_btnRicerca;
    protected S_Button S_btnDownLoad;
    protected S_Button S_btnReset;
    protected S_Label S_lblDataAssegnazione;
    protected S_Label S_lblDa1;
    protected S_Label S_lblA1;
    protected S_Label S_lblDa2;
    protected S_Label S_lblA2;
    protected S_OptionButton S_optRptCorto;
    protected S_OptionButton S_optLungo;
    protected GridTitle gridtleDataGridRicerca;
    protected S_Button S_btnStampa;
    protected Label lblMessaggio;
    protected CompareValidator cmpVldDaAssegnazione;
    protected CompareValidator cmpVldAAssegnazione;
    protected CompareValidator cmpVldDaCompletamento;
    protected CompareValidator cmpVldACompletamento;
    protected S_Button S_btnConfermaSel;
    protected S_Button S_btnSelezionaTutto;
    protected S_Button S_btnDeselezioneTutto;
    protected Label lblElementiSelezionati;
    protected S_OptionButton S_optDataComp;
    protected ValidationSummary ValidationSummary1;
    public static string HelpLink = string.Empty;

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.S_btnRicerca).Click += new EventHandler(this.S_btnRicerca_Click);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      ((Button) this.S_btnConfermaSel).Click += new EventHandler(this.S_btnConfermaSel_Click);
      ((Button) this.S_btnSelezionaTutto).Click += new EventHandler(this.S_btnSelezionaTutto_Click);
      ((Button) this.S_btnDeselezioneTutto).Click += new EventHandler(this.S_btnDeselezioneTutto_Click);
      ((Button) this.S_btnStampa).Click += new EventHandler(this.S_btnStampa_Click);
      ((Button) this.S_btnDownLoad).Click += new EventHandler(this.S_btnDownLoad_Click);
      ((Button) this.S_btnReset).Click += new EventHandler(this.S_btnReset_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void Page_Load(object sender, EventArgs e)
    {
      Ricerca_e_Stampa.HelpLink = ((SiteModule) HttpContext.Current.Items[(object) "SiteModule"]).HelpLink;
      this.PgTlStampaPdf.MainTitle = "Ricerca e Stampa Rapporti";
      ((WebControl) this.S_optDataComp).Attributes.Add("onclick", "AbilitaDataUlteriore();");
      ((WebControl) this.S_optSolComp).Attributes.Add("onclick", "DisabilitaDataUlteriore();");
      ((WebControl) this.S_optSolNonComp).Attributes.Add("onclick", "DisabilitaDataUlteriore();");
      ((Control) this.gridtleDataGridRicerca.hplsNuovo).Visible = false;
      this.cmpVldAAssegnazione.ControlToValidate = this.cldpkAAssegnazione.ID + ":" + ((Control) this.cldpkAAssegnazione.Datazione).ID;
      this.cmpVldAAssegnazione.ControlToCompare = this.cldpkDaAssegnazione.ID + ":" + ((Control) this.cldpkDaAssegnazione.Datazione).ID;
      this.cmpVldDaAssegnazione.ControlToValidate = this.cldpkDaAssegnazione.ID + ":" + ((Control) this.cldpkDaAssegnazione.Datazione).ID;
      this.cmpVldDaAssegnazione.ControlToCompare = this.cldpkAAssegnazione.ID + ":" + ((Control) this.cldpkAAssegnazione.Datazione).ID;
      this.cmpVldACompletamento.ControlToValidate = this.cldpkACompletamento.ID + ":" + ((Control) this.cldpkACompletamento.Datazione).ID;
      this.cmpVldACompletamento.ControlToCompare = this.cldpkDaCompletamento.ID + ":" + ((Control) this.cldpkDaCompletamento.Datazione).ID;
      this.cmpVldDaCompletamento.ControlToValidate = this.cldpkDaCompletamento.ID + ":" + ((Control) this.cldpkDaCompletamento.Datazione).ID;
      this.cmpVldDaCompletamento.ControlToCompare = this.cldpkACompletamento.ID + ":" + ((Control) this.cldpkACompletamento.Datazione).ID;
      if (this.IsPostBack)
        return;
      this.riempiCombo("RapportiPdf.bind_edifici", this.S_cmbEdificio, "System.String");
      this.riempiCombo("RapportiPdf.bind_comune", this.S_cmbComune, "System.Int32");
      this.riempiCombo("RapportiPdf.bind_Addetto", this.S_cmbAddetto, "System.Int32");
      this.riempiCombo("RapportiPdf.bind_ditta", this.S_cmbDitta, "System.Int32");
      this.riempiCombo("RapportiPdf.bind_categoria", this.S_cmbCategoria, "System.Int32");
      S_TextBox datazione1 = this.cldpkAAssegnazione.Datazione;
      DateTime today = DateTime.Today;
      string str1 = today.ToString().Substring(0, 10);
      ((TextBox) datazione1).Text = str1;
      S_TextBox datazione2 = this.cldpkDaAssegnazione.Datazione;
      today = DateTime.Today;
      string str2 = "01/01/" + today.ToString().Substring(6, 4);
      ((TextBox) datazione2).Text = str2;
    }

    private int tipologiaReport()
    {
      int num = 1001;
      if (((CheckBox) this.S_optRptCorto).Checked)
        num = 0;
      else if (((CheckBox) this.S_optLungo).Checked)
        num = 1;
      return num;
    }

    private int tipoComletamento()
    {
      if (((CheckBox) this.S_optSolNonComp).Checked)
        return 0;
      if (((CheckBox) this.S_optSolComp).Checked)
        return 1;
      if (((CheckBox) this.S_optDataComp).Checked)
        return 2;
      throw new Exception();
    }

    private void riempiCombo(string storedProcedure, S_ComboBox cbx, string tipo)
    {
      DataSet dataSet = this.BindCmb(storedProcedure);
      DataTable table = new DataTable();
      DataColumn column1 = this.colonna("testo", "System.String");
      DataColumn column2 = this.colonna("valore", tipo);
      table.Columns.Add(column1);
      table.Columns.Add(column2);
      DataRow row1 = table.NewRow();
      row1[0] = (object) "";
      switch (tipo)
      {
        case "System.String":
          row1[1] = (object) "";
          break;
        case "System.Int32":
          row1[1] = (object) 0;
          break;
        default:
          row1[1] = (object) "";
          break;
      }
      table.Rows.Add(row1);
      for (int index = 0; index <= dataSet.Tables[0].Rows.Count - 1; ++index)
      {
        DataRow row2 = table.NewRow();
        row2[0] = dataSet.Tables[0].Rows[index][0];
        row2[1] = dataSet.Tables[0].Rows[index][1];
        table.Rows.Add(row2);
      }
      DataView dataView = new DataView(table);
      ((ListControl) cbx).DataTextField = "Testo";
      ((ListControl) cbx).DataValueField = "Valore";
      ((BaseDataBoundControl) cbx).DataSource = (object) dataView;
      ((Control) cbx).DataBind();
    }

    private DataSet BindCmb(string StoredProcedure)
    {
      AgganciaDatalayer agganciaDatalayer = new AgganciaDatalayer();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("RSCursor");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject);
      agganciaDatalayer.NameProcedureDb = StoredProcedure;
      DataSet dataSet = new DataSet();
      return agganciaDatalayer.GetData(CollezioneControlli).Copy();
    }

    private DataColumn colonna(string nome, string tipo) => new DataColumn(nome)
    {
      DataType = Type.GetType(tipo)
    };

    private void S_btnRicerca_Click(object sender, EventArgs e) => this.avvioRicerca();

    private void abilitaControlli(bool abilitato) => ((WebControl) this.S_btnStampa).Enabled = abilitato;

    private void avvioRicerca()
    {
      this.Session.Remove("DatiList");
      this.EnableControl(false);
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.lblMessaggio.Text = "";
      this.lblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
      this.ricerca();
    }

    private void ricerca()
    {
      DatasetReport datasetReport = this.riempiDatasetRicerca();
      this.gridtleDataGridRicerca.NumeroRecords = Convert.ToString(datasetReport.Tables["Data_Report_Ricerca"].Rows.Count);
      this.DataGridRicerca.DataSource = (object) datasetReport.Tables["Data_Report_Ricerca"];
      this.DataGridRicerca.DataBind();
    }

    private DatasetReport riempiDatasetRicerca()
    {
      AgganciaDatalayer agganciaDatalayer = new AgganciaDatalayer();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("Pedificio");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(8);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) ((ListControl) this.S_cmbEdificio).SelectedItem.Value);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("Paddetto");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) ((ListControl) this.S_cmbAddetto).SelectedItem.Value);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("Pcomune");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(128);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) ((ListControl) this.S_cmbComune).SelectedItem.Value);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("Pditta");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(64);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) ((ListControl) this.S_cmbDitta).SelectedItem.Value);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("Pcategoria");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size(128);
      ((ParameterObject) sObject2).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) ((ListControl) this.S_cmbCategoria).SelectedItem.Value);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("Paa");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Size(10);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Value((object) ((TextBox) this.cldpkDaAssegnazione.Datazione).Text);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("Pbb");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(10);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Value((object) ((TextBox) this.cldpkAAssegnazione.Datazione).Text);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("PtipoCompletamento");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Size(10);
      ((ParameterObject) sObject8).set_Index(7);
      ((ParameterObject) sObject8).set_Value((object) this.tipoComletamento());
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("PdataCompletamentoInit");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Size(10);
      ((ParameterObject) sObject9).set_Index(8);
      ((ParameterObject) sObject9).set_Value((object) ((TextBox) this.cldpkDaCompletamento.Datazione).Text);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("PdataCompletamentoEnd");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Size(10);
      ((ParameterObject) sObject10).set_Index(8);
      ((ParameterObject) sObject10).set_Value((object) ((TextBox) this.cldpkACompletamento.Datazione).Text);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("RSCursor");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject11).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject11);
      agganciaDatalayer.NameProcedureDb = "rapportipdf.get_data_ricerca_report";
      DataSet dataSet = agganciaDatalayer.GetData(CollezioneControlli).Copy();
      DatasetReport datasetReport = new DatasetReport();
      for (int index = 0; index <= dataSet.Tables[0].Rows.Count - 1; ++index)
        datasetReport.Tables["Data_Report_Ricerca"].ImportRow(dataSet.Tables[0].Rows[index]);
      return datasetReport;
    }

    private void DataGridRicerca_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.ricerca();
      this.GetControlli();
    }

    private void S_btnReset_Click(object sender, EventArgs e) => this.Response.Redirect("Ricerca_e_Stampa.aspx");

    private void S_btnDownLoad_Click(object sender, EventArgs e) => this.Response.Redirect("Pagina_Download.aspx");

    private void S_btnConfermaSel_Click(object sender, EventArgs e)
    {
      this.lblMessaggio.Text = "";
      this.SetDati();
      this.SetControlli();
    }

    private void SetDati()
    {
      Hashtable hashtable = new Hashtable();
      if (this.Session["DatiList"] != null)
        hashtable = (Hashtable) this.Session["DatiList"];
      foreach (DataGridItem dataGridItem in this.DataGridRicerca.Items)
      {
        int num = int.Parse(dataGridItem.Cells[1].Text);
        CheckBox control = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
        if (hashtable.ContainsKey((object) num))
          hashtable.Remove((object) num);
        if (control.Checked)
          hashtable.Add((object) num, (object) num);
      }
      this.Session.Remove("DatiList");
      this.Session.Add("DatiList", (object) hashtable);
      this.lblElementiSelezionati.Text = "Elementi Selezionati - " + hashtable.Count.ToString() + " -";
      if (hashtable.Count > 0)
        this.EnableControl(true);
      else
        this.EnableControl(false);
    }

    private void EnableControl(bool enable) => ((WebControl) this.S_btnStampa).Enabled = enable;

    private void SetControlli()
    {
      StampaRapportiPdf.Classi.clMyDataGridCollection dataGridCollection = new StampaRapportiPdf.Classi.clMyDataGridCollection();
      Hashtable _HS = new Hashtable();
      if (this.Session["CheckedList"] != null)
        _HS = (Hashtable) this.Session["CheckedList"];
      Hashtable hashtable = dataGridCollection.SetControl(this.DataGridRicerca, _HS, this.DataGridRicerca.CurrentPageIndex);
      this.Session.Remove("CheckedList");
      this.Session.Add("CheckedList", (object) hashtable);
    }

    private void GetControlli()
    {
      StampaRapportiPdf.Classi.clMyDataGridCollection dataGridCollection = new StampaRapportiPdf.Classi.clMyDataGridCollection();
      if (this.Session["CheckedList"] == null)
        return;
      dataGridCollection.GetControl(this.DataGridRicerca, (Hashtable) this.Session["CheckedList"], this.DataGridRicerca.CurrentPageIndex);
    }

    private void S_btnStampa_Click(object sender, EventArgs e)
    {
      string[] arOdl = this.recuperaSesOdl().Split(',');
      int length = arOdl.Length;
      int idFile = this.insertDb(length);
      this.insertNormTblDb(arOdl, idFile);
      this.stampaRpt(length, idFile);
      if (this.updateDb(length, idFile) != idFile)
        throw new Exception();
      this.avvioRicerca();
      this.lblMessaggio.Text = "Il file " + this.creaNomeFile(length, idFile) + ".pdf e' stato  creato correttamente";
    }

    private string recuperaSesOdl()
    {
      string str1 = string.Empty;
      IDictionaryEnumerator enumerator = ((Hashtable) this.Session["DatiList"]).GetEnumerator();
      while (enumerator.MoveNext())
        str1 = str1 + enumerator.Value + ",";
      string str2 = str1.Remove(str1.Length - 1, 1);
      this.Session.Remove("DatiList");
      return str2;
    }

    private int insertDb(int nOdl)
    {
      AgganciaDatalayer agganciaDatalayer = new AgganciaDatalayer();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      int num1 = 0;
      string str1;
      switch (this.tipologiaReport())
      {
        case 0:
          str1 = "Report corto";
          break;
        case 1:
          str1 = "Report lungo";
          break;
        default:
          throw new Exception();
      }
      string str2 = ((ListControl) this.S_cmbComune).SelectedItem.Text;
      string str3 = ((ListControl) this.S_cmbEdificio).SelectedItem.Text;
      string str4 = ((ListControl) this.S_cmbDitta).SelectedItem.Text;
      string str5 = ((ListControl) this.S_cmbCategoria).SelectedItem.Text;
      string str6 = ((ListControl) this.S_cmbAddetto).SelectedItem.Text;
      string str7 = "N. " + nOdl.ToString() + " Odl";
      if (str2 == string.Empty)
        str2 = "Tutti";
      if (str3 == string.Empty)
        str3 = "Tutti";
      if (str4 == string.Empty)
        str4 = "Tutte";
      if (str5 == string.Empty)
        str5 = "Tutte";
      if (str6 == string.Empty)
        str6 = "Tutti";
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_NOME_FILE");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(128);
      ((ParameterObject) sObject1).set_Index(num1);
      ((ParameterObject) sObject1).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("P_DATA_ASSEGNAZIONE_INIT");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(10);
      S_Object sObject3 = sObject2;
      int num2 = num1;
      int num3 = num2 + 1;
      ((ParameterObject) sObject3).set_Index(num2);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.cldpkDaAssegnazione.Datazione).Text);
      CollezioneControlli.Add(sObject2);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("P_DATA_ASSEGNAZIONE_END");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(10);
      S_Object sObject5 = sObject4;
      int num4 = num3;
      int num5 = num4 + 1;
      ((ParameterObject) sObject5).set_Index(num4);
      ((ParameterObject) sObject4).set_Value((object) ((TextBox) this.cldpkAAssegnazione.Datazione).Text);
      CollezioneControlli.Add(sObject4);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("P_DATA_COMPLETAMENTO_INIT");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Size(10);
      S_Object sObject7 = sObject6;
      int num6 = num5;
      int num7 = num6 + 1;
      ((ParameterObject) sObject7).set_Index(num6);
      ((ParameterObject) sObject6).set_Value((object) ((TextBox) this.cldpkDaCompletamento.Datazione).Text);
      CollezioneControlli.Add(sObject6);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("P_DATA_COMPLETAMENTO_END");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Size(10);
      S_Object sObject9 = sObject8;
      int num8 = num7;
      int num9 = num8 + 1;
      ((ParameterObject) sObject9).set_Index(num8);
      ((ParameterObject) sObject8).set_Value((object) ((TextBox) this.cldpkACompletamento.Datazione).Text);
      CollezioneControlli.Add(sObject8);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("P_COMUNE");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Size(64);
      S_Object sObject11 = sObject10;
      int num10 = num9;
      int num11 = num10 + 1;
      ((ParameterObject) sObject11).set_Index(num10);
      ((ParameterObject) sObject10).set_Value((object) str2);
      CollezioneControlli.Add(sObject10);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("P_EDIFICIO");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Size((int) byte.MaxValue);
      S_Object sObject13 = sObject12;
      int num12 = num11;
      int num13 = num12 + 1;
      ((ParameterObject) sObject13).set_Index(num12);
      ((ParameterObject) sObject12).set_Value((object) str3);
      CollezioneControlli.Add(sObject12);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("P_DITTA");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Size(32);
      S_Object sObject15 = sObject14;
      int num14 = num13;
      int num15 = num14 + 1;
      ((ParameterObject) sObject15).set_Index(num14);
      ((ParameterObject) sObject14).set_Value((object) str4);
      CollezioneControlli.Add(sObject14);
      S_Object sObject16 = new S_Object();
      ((ParameterObject) sObject16).set_ParameterName("P_CATEGORIA");
      ((ParameterObject) sObject16).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject16).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject16).set_Size(32);
      S_Object sObject17 = sObject16;
      int num16 = num15;
      int num17 = num16 + 1;
      ((ParameterObject) sObject17).set_Index(num16);
      ((ParameterObject) sObject16).set_Value((object) str5);
      CollezioneControlli.Add(sObject16);
      S_Object sObject18 = new S_Object();
      ((ParameterObject) sObject18).set_ParameterName("P_ADDETTO");
      ((ParameterObject) sObject18).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject18).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject18).set_Size(128);
      S_Object sObject19 = sObject18;
      int num18 = num17;
      int num19 = num18 + 1;
      ((ParameterObject) sObject19).set_Index(num18);
      ((ParameterObject) sObject18).set_Value((object) str6);
      CollezioneControlli.Add(sObject18);
      S_Object sObject20 = new S_Object();
      ((ParameterObject) sObject20).set_ParameterName("P_SOLO_NON_COMPLETATE");
      ((ParameterObject) sObject20).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject20).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject20).set_Size(8);
      S_Object sObject21 = sObject20;
      int num20 = num19;
      int num21 = num20 + 1;
      ((ParameterObject) sObject21).set_Index(num20);
      S_Object sObject22 = sObject20;
      bool flag = ((CheckBox) this.S_optSolNonComp).Checked;
      string str8 = flag.ToString();
      ((ParameterObject) sObject22).set_Value((object) str8);
      CollezioneControlli.Add(sObject20);
      S_Object sObject23 = new S_Object();
      ((ParameterObject) sObject23).set_ParameterName("P_SOLO_COMPLETATE");
      ((ParameterObject) sObject23).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject23).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject23).set_Size(8);
      S_Object sObject24 = sObject23;
      int num22 = num21;
      int num23 = num22 + 1;
      ((ParameterObject) sObject24).set_Index(num22);
      S_Object sObject25 = sObject23;
      flag = ((CheckBox) this.S_optSolComp).Checked;
      string str9 = flag.ToString();
      ((ParameterObject) sObject25).set_Value((object) str9);
      CollezioneControlli.Add(sObject23);
      S_Object sObject26 = new S_Object();
      ((ParameterObject) sObject26).set_ParameterName("P_DATA_DI_COMPLETAMENTO");
      ((ParameterObject) sObject26).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject26).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject26).set_Size(8);
      S_Object sObject27 = sObject26;
      int num24 = num23;
      int num25 = num24 + 1;
      ((ParameterObject) sObject27).set_Index(num24);
      S_Object sObject28 = sObject26;
      flag = ((CheckBox) this.S_optDataComp).Checked;
      string str10 = flag.ToString();
      ((ParameterObject) sObject28).set_Value((object) str10);
      CollezioneControlli.Add(sObject26);
      S_Object sObject29 = new S_Object();
      ((ParameterObject) sObject29).set_ParameterName("P_DIMENSIONE_FILE");
      ((ParameterObject) sObject29).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject29).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject29).set_Size(32);
      S_Object sObject30 = sObject29;
      int num26 = num25;
      int num27 = num26 + 1;
      ((ParameterObject) sObject30).set_Index(num26);
      ((ParameterObject) sObject29).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject29);
      S_Object sObject31 = new S_Object();
      ((ParameterObject) sObject31).set_ParameterName("P_DIMENSIONE_FILE_ZIP");
      ((ParameterObject) sObject31).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject31).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject31).set_Size(32);
      S_Object sObject32 = sObject31;
      int num28 = num27;
      int num29 = num28 + 1;
      ((ParameterObject) sObject32).set_Index(num28);
      ((ParameterObject) sObject31).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject31);
      S_Object sObject33 = new S_Object();
      ((ParameterObject) sObject33).set_ParameterName("P_INTERVALLO_ODL_SELEZIONATI");
      ((ParameterObject) sObject33).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject33).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject33).set_Size(256);
      S_Object sObject34 = sObject33;
      int num30 = num29;
      int num31 = num30 + 1;
      ((ParameterObject) sObject34).set_Index(num30);
      ((ParameterObject) sObject33).set_Value((object) str7);
      CollezioneControlli.Add(sObject33);
      S_Object sObject35 = new S_Object();
      ((ParameterObject) sObject35).set_ParameterName("P_TIPOLOGIA_REPORT");
      ((ParameterObject) sObject35).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject35).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject35).set_Size(16);
      S_Object sObject36 = sObject35;
      int num32 = num31;
      int num33 = num32 + 1;
      ((ParameterObject) sObject36).set_Index(num32);
      ((ParameterObject) sObject35).set_Value((object) str1);
      CollezioneControlli.Add(sObject35);
      S_Object sObject37 = new S_Object();
      ((ParameterObject) sObject37).set_ParameterName("p_DIMENSIONEFILE_PDF_ZIP");
      ((ParameterObject) sObject37).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject37).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject37).set_Size(128);
      S_Object sObject38 = sObject37;
      int num34 = num33;
      int num35 = num34 + 1;
      ((ParameterObject) sObject38).set_Index(num34);
      ((ParameterObject) sObject37).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject37);
      S_Object sObject39 = new S_Object();
      ((ParameterObject) sObject39).set_ParameterName("p_COMPLETATE");
      ((ParameterObject) sObject39).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject39).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject39).set_Size(128);
      S_Object sObject40 = sObject39;
      int num36 = num35;
      int num37 = num36 + 1;
      ((ParameterObject) sObject40).set_Index(num36);
      ((ParameterObject) sObject39).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject39);
      S_Object sObject41 = new S_Object();
      ((ParameterObject) sObject41).set_ParameterName("P_Data_ass_in_out");
      ((ParameterObject) sObject41).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject41).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject41).set_Size(30);
      S_Object sObject42 = sObject41;
      int num38 = num37;
      int num39 = num38 + 1;
      ((ParameterObject) sObject42).set_Index(num38);
      ((ParameterObject) sObject41).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject41);
      agganciaDatalayer.NameProcedureDb = "RapportiPdf.inserisciTabellaDwn";
      return agganciaDatalayer.Add(CollezioneControlli);
    }

    private int[] insertNormTblDb(string[] arOdl, int idFile)
    {
      int[] numArray = new int[arOdl.Length];
      numArray.Initialize();
      for (int index = 0; index < arOdl.Length; ++index)
      {
        AgganciaDatalayer agganciaDatalayer = new AgganciaDatalayer();
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        int num1 = 0;
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_idFile");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Size(16);
        S_Object sObject2 = sObject1;
        int num2 = num1;
        int num3 = num2 + 1;
        ((ParameterObject) sObject2).set_Index(num2);
        ((ParameterObject) sObject1).set_Value((object) idFile);
        CollezioneControlli.Add(sObject1);
        S_Object sObject3 = new S_Object();
        ((ParameterObject) sObject3).set_ParameterName("p_Odl");
        ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject3).set_Size(16);
        S_Object sObject4 = sObject3;
        int num4 = num3;
        int num5 = num4 + 1;
        ((ParameterObject) sObject4).set_Index(num4);
        ((ParameterObject) sObject3).set_Value((object) arOdl[index]);
        CollezioneControlli.Add(sObject3);
        agganciaDatalayer.NameProcedureDb = "RapportiPdf.inserisciTblNorm";
        int num6 = agganciaDatalayer.Add(CollezioneControlli);
        numArray[index] = num6;
      }
      return numArray;
    }

    private int updateDb(int nOdl, int idFile)
    {
      long num1 = this.dimensioneFile(nOdl, idFile, ".pdf");
      string str1 = num1.ToString();
      num1 = this.dimensioneFile(nOdl, idFile, ".zip");
      string str2 = num1.ToString();
      string str3 = str1 + "/" + str2;
      string str4 = string.Empty;
      if (((CheckBox) this.S_optDataComp).Checked)
        str4 = "Si con date";
      if (((CheckBox) this.S_optSolComp).Checked)
        str4 = "Si";
      if (((CheckBox) this.S_optSolNonComp).Checked)
        str4 = "No";
      string str5 = ((TextBox) this.cldpkDaAssegnazione.Datazione).Text + " - " + ((TextBox) this.cldpkAAssegnazione.Datazione).Text;
      int num2 = 0;
      AgganciaDatalayer agganciaDatalayer = new AgganciaDatalayer();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_NOME_FILE");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(128);
      ((ParameterObject) sObject1).set_Index(num2);
      ((ParameterObject) sObject1).set_Value((object) this.creaNomeFile(nOdl, idFile));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("P_DATA_ASSEGNAZIONE_INIT");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(10);
      S_Object sObject3 = sObject2;
      int num3 = num2;
      int num4 = num3 + 1;
      ((ParameterObject) sObject3).set_Index(num3);
      ((ParameterObject) sObject2).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject2);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("P_DATA_ASSEGNAZIONE_END");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(10);
      S_Object sObject5 = sObject4;
      int num5 = num4;
      int num6 = num5 + 1;
      ((ParameterObject) sObject5).set_Index(num5);
      ((ParameterObject) sObject4).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject4);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("P_DATA_COMPLETAMENTO_INIT");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Size(10);
      S_Object sObject7 = sObject6;
      int num7 = num6;
      int num8 = num7 + 1;
      ((ParameterObject) sObject7).set_Index(num7);
      ((ParameterObject) sObject6).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject6);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("P_DATA_COMPLETAMENTO_END");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Size(10);
      S_Object sObject9 = sObject8;
      int num9 = num8;
      int num10 = num9 + 1;
      ((ParameterObject) sObject9).set_Index(num9);
      ((ParameterObject) sObject8).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject8);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("P_COMUNE");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Size(64);
      S_Object sObject11 = sObject10;
      int num11 = num10;
      int num12 = num11 + 1;
      ((ParameterObject) sObject11).set_Index(num11);
      ((ParameterObject) sObject10).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject10);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("P_EDIFICIO");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Size((int) byte.MaxValue);
      S_Object sObject13 = sObject12;
      int num13 = num12;
      int num14 = num13 + 1;
      ((ParameterObject) sObject13).set_Index(num13);
      ((ParameterObject) sObject12).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject12);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("P_DITTA");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject14).set_Size(32);
      S_Object sObject15 = sObject14;
      int num15 = num14;
      int num16 = num15 + 1;
      ((ParameterObject) sObject15).set_Index(num15);
      ((ParameterObject) sObject14).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject14);
      S_Object sObject16 = new S_Object();
      ((ParameterObject) sObject16).set_ParameterName("P_CATEGORIA");
      ((ParameterObject) sObject16).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject16).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject16).set_Size(32);
      S_Object sObject17 = sObject16;
      int num17 = num16;
      int num18 = num17 + 1;
      ((ParameterObject) sObject17).set_Index(num17);
      ((ParameterObject) sObject16).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject16);
      S_Object sObject18 = new S_Object();
      ((ParameterObject) sObject18).set_ParameterName("P_ADDETTO");
      ((ParameterObject) sObject18).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject18).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject18).set_Size(128);
      S_Object sObject19 = sObject18;
      int num19 = num18;
      int num20 = num19 + 1;
      ((ParameterObject) sObject19).set_Index(num19);
      ((ParameterObject) sObject18).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject18);
      S_Object sObject20 = new S_Object();
      ((ParameterObject) sObject20).set_ParameterName("P_SOLO_NON_COMPLETATE");
      ((ParameterObject) sObject20).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject20).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject20).set_Size(8);
      S_Object sObject21 = sObject20;
      int num21 = num20;
      int num22 = num21 + 1;
      ((ParameterObject) sObject21).set_Index(num21);
      ((ParameterObject) sObject20).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject20);
      S_Object sObject22 = new S_Object();
      ((ParameterObject) sObject22).set_ParameterName("P_SOLO_COMPLETATE");
      ((ParameterObject) sObject22).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject22).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject22).set_Size(8);
      S_Object sObject23 = sObject22;
      int num23 = num22;
      int num24 = num23 + 1;
      ((ParameterObject) sObject23).set_Index(num23);
      ((ParameterObject) sObject22).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject22);
      S_Object sObject24 = new S_Object();
      ((ParameterObject) sObject24).set_ParameterName("P_DATA_DI_COMPLETAMENTO");
      ((ParameterObject) sObject24).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject24).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject24).set_Size(8);
      S_Object sObject25 = sObject24;
      int num25 = num24;
      int num26 = num25 + 1;
      ((ParameterObject) sObject25).set_Index(num25);
      ((ParameterObject) sObject24).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject24);
      S_Object sObject26 = new S_Object();
      ((ParameterObject) sObject26).set_ParameterName("P_DIMENSIONE_FILE");
      ((ParameterObject) sObject26).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject26).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject26).set_Size(32);
      S_Object sObject27 = sObject26;
      int num27 = num26;
      int num28 = num27 + 1;
      ((ParameterObject) sObject27).set_Index(num27);
      ((ParameterObject) sObject26).set_Value((object) this.dimensioneFile(nOdl, idFile, ".pdf"));
      CollezioneControlli.Add(sObject26);
      S_Object sObject28 = new S_Object();
      ((ParameterObject) sObject28).set_ParameterName("P_DIMENSIONE_FILE_ZIP");
      ((ParameterObject) sObject28).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject28).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject28).set_Size(32);
      S_Object sObject29 = sObject28;
      int num29 = num28;
      int num30 = num29 + 1;
      ((ParameterObject) sObject29).set_Index(num29);
      ((ParameterObject) sObject28).set_Value((object) this.dimensioneFile(nOdl, idFile, ".zip"));
      CollezioneControlli.Add(sObject28);
      S_Object sObject30 = new S_Object();
      ((ParameterObject) sObject30).set_ParameterName("P_INTERVALLO_ODL_SELEZIONATI");
      ((ParameterObject) sObject30).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject30).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject30).set_Size(256);
      S_Object sObject31 = sObject30;
      int num31 = num30;
      int num32 = num31 + 1;
      ((ParameterObject) sObject31).set_Index(num31);
      ((ParameterObject) sObject30).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject30);
      S_Object sObject32 = new S_Object();
      ((ParameterObject) sObject32).set_ParameterName("P_TIPOLOGIA_REPORT");
      ((ParameterObject) sObject32).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject32).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject32).set_Size(16);
      S_Object sObject33 = sObject32;
      int num33 = num32;
      int num34 = num33 + 1;
      ((ParameterObject) sObject33).set_Index(num33);
      ((ParameterObject) sObject32).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject32);
      S_Object sObject34 = new S_Object();
      ((ParameterObject) sObject34).set_ParameterName("p_DIMENSIONEFILE_PDF_ZIP");
      ((ParameterObject) sObject34).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject34).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject34).set_Size(128);
      S_Object sObject35 = sObject34;
      int num35 = num34;
      int num36 = num35 + 1;
      ((ParameterObject) sObject35).set_Index(num35);
      ((ParameterObject) sObject34).set_Value((object) str3);
      CollezioneControlli.Add(sObject34);
      S_Object sObject36 = new S_Object();
      ((ParameterObject) sObject36).set_ParameterName("p_COMPLETATE");
      ((ParameterObject) sObject36).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject36).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject36).set_Size(128);
      S_Object sObject37 = sObject36;
      int num37 = num36;
      int num38 = num37 + 1;
      ((ParameterObject) sObject37).set_Index(num37);
      ((ParameterObject) sObject36).set_Value((object) str4);
      CollezioneControlli.Add(sObject36);
      S_Object sObject38 = new S_Object();
      ((ParameterObject) sObject38).set_ParameterName("P_Data_ass_in_out");
      ((ParameterObject) sObject38).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject38).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject38).set_Size(30);
      S_Object sObject39 = sObject38;
      int num39 = num38;
      int num40 = num39 + 1;
      ((ParameterObject) sObject39).set_Index(num39);
      ((ParameterObject) sObject38).set_Value((object) str5);
      CollezioneControlli.Add(sObject38);
      agganciaDatalayer.NameProcedureDb = "RapportiPdf.inserisciTabellaDwn";
      return agganciaDatalayer.Update(CollezioneControlli, idFile);
    }

    private long dimensioneFile(int nOdl, int idFile, string estensioneFile) => new FileInfo(this.Server.MapPath(ConfigurationSettings.AppSettings.GetValues("DirectoryStampa")[0]) + this.creaNomeFile(nOdl, idFile) + estensioneFile).Length;

    private void stampaRpt(int nOdl, int idFile)
    {
      this.stampaPdf(this.riempiDatasetStampa(idFile), nOdl, idFile);
      this.creaZip(nOdl, idFile);
    }

    private void stampaPdf(DatasetReport ds, int nOdl, int idFile)
    {
      MP_Rapporti_C_MP_long_r6 rapportiCMpLongR6 = new MP_Rapporti_C_MP_long_r6();
      MP_Rapporti_C_MP_r6 mpRapportiCMpR6 = new MP_Rapporti_C_MP_r6();
      StampaSuDisco stampaSuDisco = new StampaSuDisco(this.Server.MapPath(ConfigurationSettings.AppSettings.GetValues("DirectoryStampa")[0]));
      string NomeFile = this.creaNomeFile(nOdl, idFile);
      switch (this.tipologiaReport())
      {
        case 0:
          ((ReportDocument) mpRapportiCMpR6).SetDataSource((object) ds);
          stampaSuDisco.StampaPdf((ReportClass) mpRapportiCMpR6, NomeFile);
          break;
        case 1:
          ((ReportDocument) rapportiCMpLongR6).SetDataSource((object) ds);
          stampaSuDisco.StampaPdf((ReportClass) rapportiCMpLongR6, NomeFile);
          break;
        default:
          throw new Exception();
      }
    }

    private void creaZip(int nOdl, int idFile)
    {
      string[] values = ConfigurationSettings.AppSettings.GetValues("DirectoryStampa");
      string str1 = this.creaNomeFile(nOdl, idFile);
      string str2 = str1 + ".pdf";
      new FastZip().CreateZip(this.Server.MapPath(values[0]) + str1 + ".zip", this.Server.MapPath(values[0]), true, str2);
    }

    private string creaNomeFile(int nOdl, int idFile)
    {
      string str1 = "id_" + idFile.ToString() + "-nOdl_" + nOdl.ToString();
      if (((ListControl) this.S_cmbEdificio).SelectedItem.Text != "")
        str1 = str1 + "-" + ((ListControl) this.S_cmbEdificio).SelectedItem.Value.ToString().Trim().Replace(" ", "_");
      string str2;
      if (((CheckBox) this.S_optDataComp).Checked)
        str2 = str1 + "-con_data_cmp_assgn";
      else if (((CheckBox) this.S_optSolComp).Checked)
      {
        str2 = str1 + "-Solo_Cmplt";
      }
      else
      {
        if (!((CheckBox) this.S_optSolNonComp).Checked)
          throw new Exception();
        str2 = str1 + "-Solo_non_cmplt";
      }
      if (((CheckBox) this.S_optLungo).Checked)
        return str2 + "-rpt_lng";
      if (((CheckBox) this.S_optRptCorto).Checked)
        return str2 + "-rpt_crt";
      throw new Exception();
    }

    private DatasetReport riempiDatasetStampa(int idFile)
    {
      AgganciaDatalayer agganciaDatalayer = new AgganciaDatalayer();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("PNormId");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) idFile);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("RSCursor");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject2);
      agganciaDatalayer.NameProcedureDb = "RapportiPdf.get_data_reports";
      DataSet dataSet = agganciaDatalayer.GetData(CollezioneControlli).Copy();
      DatasetReport datasetReport = new DatasetReport();
      int index;
      for (index = 0; index <= dataSet.Tables[0].Rows.Count - 1; ++index)
        datasetReport.Tables["MP_REPORT_LONG"].ImportRow(dataSet.Tables[0].Rows[index]);
      if (index == 0)
        throw new Exception("* Non ci sono Rdl nell'intervallo temporale che hai selezionato, cambia intervallo e riprova.");
      return datasetReport;
    }

    private void S_btnSelezionaTutto_Click(object sender, EventArgs e) => this.SelezionaTutti(true);

    private void S_btnDeselezioneTutto_Click(object sender, EventArgs e) => this.SelezionaTutti(false);

    private void SelezionaTutti(bool val)
    {
      DatasetReport datasetReport = this.riempiDatasetRicerca();
      if (!val)
      {
        this.Session.Remove("CheckedList");
        this.Session.Remove("DatiList");
        this.lblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
        this.EnableControl(false);
      }
      else
        this.SetControlli();
      for (int index = 0; index <= this.DataGridRicerca.PageCount; ++index)
      {
        this.DataGridRicerca.DataSource = (object) datasetReport.Tables["Data_Report_Ricerca"];
        this.DataGridRicerca.DataBind();
        this.DataGridRicerca.CurrentPageIndex = index;
        this.SetDati(val);
        if (val)
          this.SetControlli();
      }
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.DataGridRicerca.DataSource = (object) datasetReport.Tables["Data_Report_Ricerca"];
      this.DataGridRicerca.DataBind();
      this.GetControlli();
    }

    private void SetDati(bool val)
    {
      Hashtable hashtable = new Hashtable();
      if (this.Session["DatiList"] != null)
        hashtable = (Hashtable) this.Session["DatiList"];
      foreach (DataGridItem dataGridItem in this.DataGridRicerca.Items)
      {
        int num = int.Parse(dataGridItem.Cells[1].Text);
        CheckBox control = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
        control.Checked = val;
        if (hashtable.ContainsKey((object) num))
          hashtable.Remove((object) num);
        if (control.Checked)
          hashtable.Add((object) num, (object) num);
      }
      this.Session.Remove("DatiList");
      this.Session.Add("DatiList", (object) hashtable);
      this.lblElementiSelezionati.Text = "Elementi Selezionati - " + hashtable.Count.ToString() + " -";
      if (hashtable.Count > 0)
        this.EnableControl(true);
      else
        this.EnableControl(false);
    }
  }
}
