// Decompiled with JetBrains decompiler
// Type: StampaRapportiPdf.Pagine.Pagina_Download
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls;
using S_Controls.Collections;
using StampaRapportiPdf.Classi;
using StampaRapportiPdf.WebControls;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.StampaRapportiPDF.Schemixsd;

namespace StampaRapportiPdf.Pagine
{
  public class Pagina_Download : Page
  {
    protected DataGrid DataGridRicerca;
    protected S_Button S_btnRicerca;
    protected PageTitle pgtlDownoloadStampe;
    protected Label lblId;
    protected LinkButton lnkChiudi;
    protected Panel pnlShowInfo;
    protected Label LABEL18;
    protected Label LABEL19;
    protected Label LABEL20;
    protected Label LABEL21;
    protected Label LABEL22;
    protected Label LABEL23;
    protected Label LABEL24;
    protected Label LABEL25;
    protected Label LABEL26;
    protected Label LABEL27;
    protected Label LABEL28;
    protected Label LABEL29;
    protected Label LABEL30;
    protected Label LABEL31;
    protected Label LABEL32;
    protected Label lblIntestazione;
    protected Label lblDataDiCreazione;
    protected Label lblTipologiaReport;
    protected Label lblEdificio;
    protected Label lblComune;
    protected Label lblIntervalloOdl;
    protected Label lblDitta;
    protected Label lblCategoria;
    protected Label lblAddetto;
    protected Label lblDimensioneFilePdf;
    protected Label lblDataAssegnazioneIniziale;
    protected Label lblDataAssegnazioneFinale;
    protected Label lblDataCompletamentoIniziale;
    protected Label lblDataCompletamentoFinale;
    protected Label lblC11;
    protected Label lblSoloNonCompletate;
    protected Label lblSoloCompletate;
    protected Label lblDimensioneFileZip;
    protected Label Label1;
    protected Label lblSoloCompletateConFiltro;
    protected S_Button S_btnEliminaTiitiFile;
    protected GridTitle GridTitleDownLoad;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      Pagina_Download.HelpLink = ((SiteModule) HttpContext.Current.Items[(object) "SiteModule"]).HelpLink;
      this.pgtlDownoloadStampe.MainTitle = "Download Stampe Rapporti";
      ((Control) this.GridTitleDownLoad.hplsNuovo).Visible = false;
      this.caricaDataGridRicerca();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      ((Button) this.S_btnRicerca).Click += new EventHandler(this.S_btnRicerca_Click);
      ((Button) this.S_btnEliminaTiitiFile).Click += new EventHandler(this.S_btnEliminaTiitiFile_Click);
      this.lnkChiudi.Click += new EventHandler(this.lnkChiudi_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void caricaDataGridRicerca()
    {
      if (this.DataGridRicerca.Items.Count == 1 && this.DataGridRicerca.CurrentPageIndex != 0)
        --this.DataGridRicerca.CurrentPageIndex;
      else if (this.DataGridRicerca.Items.Count == 1)
        this.DataGridRicerca.CurrentPageIndex = 0;
      this.ricerca();
    }

    private void ricerca()
    {
      DatasetReport datasetReport = this.riempiDatasetDownload();
      this.GridTitleDownLoad.NumeroRecords = Convert.ToString(datasetReport.Tables["DownloadFile"].Rows.Count);
      this.DataGridRicerca.DataSource = (object) datasetReport.Tables["DownloadFile"];
      this.DataGridRicerca.DataBind();
    }

    private DatasetReport riempiDatasetDownload()
    {
      AgganciaDatalayer agganciaDatalayer = new AgganciaDatalayer();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("RSCursor");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(0);
      CollezioneControlli.Add(sObject);
      agganciaDatalayer.NameProcedureDb = "rapportipdf.get_Download_Reports";
      DataSet dataSet = agganciaDatalayer.GetData(CollezioneControlli).Copy();
      DatasetReport datasetReport = new DatasetReport();
      for (int index = 0; index <= dataSet.Tables[0].Rows.Count - 1; ++index)
        datasetReport.Tables["DownloadFile"].ImportRow(dataSet.Tables[0].Rows[index]);
      return datasetReport;
    }

    private void S_btnRicerca_Click(object sender, EventArgs e) => this.Response.Redirect("Ricerca_e_stampa.aspx");

    private void DataGridRicerca_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.ricerca();
    }

    protected void imgBtnVisualizza_Click(object sender, CommandEventArgs e)
    {
      this.Context.Items.Add((object) "nome_file", (object) (string) e.CommandArgument);
      this.Server.Transfer("VisualDWF.aspx");
    }

    protected void imgBtnElimina_Click(object sender, CommandEventArgs e)
    {
      string[] strArray = Convert.ToString(e.CommandArgument).Split(Convert.ToChar(","));
      int int32 = Convert.ToInt32(strArray[0].ToString());
      string nomefile = strArray[1].ToString();
      int num = this.deleteDb(int32);
      this.deleteTblNorm(int32);
      if (int32 != num)
        throw new Exception();
      this.elininaFile(nomefile);
      this.caricaDataGridRicerca();
    }

    private void deleteTblNorm(int idFile)
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
      ((ParameterObject) sObject3).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject3);
      agganciaDatalayer.NameProcedureDb = "RapportiPdf.inserisciTblNorm";
      agganciaDatalayer.Delete(CollezioneControlli, 0);
    }

    private int deleteDb(int idFile)
    {
      int num1 = 0;
      AgganciaDatalayer agganciaDatalayer = new AgganciaDatalayer();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
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
      ((ParameterObject) sObject2).set_Value((object) DBNull.Value);
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
      ((ParameterObject) sObject4).set_Value((object) DBNull.Value);
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
      ((ParameterObject) sObject6).set_Value((object) DBNull.Value);
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
      ((ParameterObject) sObject8).set_Value((object) DBNull.Value);
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
      ((ParameterObject) sObject10).set_Value((object) DBNull.Value);
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
      ((ParameterObject) sObject12).set_Value((object) DBNull.Value);
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
      ((ParameterObject) sObject14).set_Value((object) DBNull.Value);
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
      ((ParameterObject) sObject16).set_Value((object) DBNull.Value);
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
      ((ParameterObject) sObject18).set_Value((object) DBNull.Value);
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
      ((ParameterObject) sObject20).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject20);
      S_Object sObject22 = new S_Object();
      ((ParameterObject) sObject22).set_ParameterName("P_SOLO_COMPLETATE");
      ((ParameterObject) sObject22).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject22).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject22).set_Size(8);
      S_Object sObject23 = sObject22;
      int num22 = num21;
      int num23 = num22 + 1;
      ((ParameterObject) sObject23).set_Index(num22);
      ((ParameterObject) sObject22).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject22);
      S_Object sObject24 = new S_Object();
      ((ParameterObject) sObject24).set_ParameterName("P_DATA_DI_COMPLETAMENTO");
      ((ParameterObject) sObject24).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject24).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject24).set_Size(8);
      S_Object sObject25 = sObject24;
      int num24 = num23;
      int num25 = num24 + 1;
      ((ParameterObject) sObject25).set_Index(num24);
      ((ParameterObject) sObject24).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject24);
      S_Object sObject26 = new S_Object();
      ((ParameterObject) sObject26).set_ParameterName("P_DIMENSIONE_FILE");
      ((ParameterObject) sObject26).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject26).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject26).set_Size(32);
      S_Object sObject27 = sObject26;
      int num26 = num25;
      int num27 = num26 + 1;
      ((ParameterObject) sObject27).set_Index(num26);
      ((ParameterObject) sObject26).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject26);
      S_Object sObject28 = new S_Object();
      ((ParameterObject) sObject28).set_ParameterName("P_DIMENSIONE_FILE_ZIP");
      ((ParameterObject) sObject28).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject28).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject28).set_Size(32);
      S_Object sObject29 = sObject28;
      int num28 = num27;
      int num29 = num28 + 1;
      ((ParameterObject) sObject29).set_Index(num28);
      ((ParameterObject) sObject28).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject28);
      S_Object sObject30 = new S_Object();
      ((ParameterObject) sObject30).set_ParameterName("P_INTERVALLO_ODL_SELEZIONATI");
      ((ParameterObject) sObject30).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject30).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject30).set_Size(256);
      S_Object sObject31 = sObject30;
      int num30 = num29;
      int num31 = num30 + 1;
      ((ParameterObject) sObject31).set_Index(num30);
      ((ParameterObject) sObject30).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject30);
      S_Object sObject32 = new S_Object();
      ((ParameterObject) sObject32).set_ParameterName("P_TIPOLOGIA_REPORT");
      ((ParameterObject) sObject32).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject32).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject32).set_Size(16);
      S_Object sObject33 = sObject32;
      int num32 = num31;
      int num33 = num32 + 1;
      ((ParameterObject) sObject33).set_Index(num32);
      ((ParameterObject) sObject32).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject32);
      S_Object sObject34 = new S_Object();
      ((ParameterObject) sObject34).set_ParameterName("p_DIMENSIONEFILE_PDF_ZIP");
      ((ParameterObject) sObject34).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject34).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject34).set_Size(128);
      S_Object sObject35 = sObject34;
      int num34 = num33;
      int num35 = num34 + 1;
      ((ParameterObject) sObject35).set_Index(num34);
      ((ParameterObject) sObject34).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject34);
      S_Object sObject36 = new S_Object();
      ((ParameterObject) sObject36).set_ParameterName("p_COMPLETATE");
      ((ParameterObject) sObject36).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject36).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject36).set_Size(128);
      S_Object sObject37 = sObject36;
      int num36 = num35;
      int num37 = num36 + 1;
      ((ParameterObject) sObject37).set_Index(num36);
      ((ParameterObject) sObject36).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject36);
      S_Object sObject38 = new S_Object();
      ((ParameterObject) sObject38).set_ParameterName("P_Data_ass_in_out");
      ((ParameterObject) sObject38).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject38).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject38).set_Size(30);
      S_Object sObject39 = sObject38;
      int num38 = num37;
      int num39 = num38 + 1;
      ((ParameterObject) sObject39).set_Index(num38);
      ((ParameterObject) sObject38).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject38);
      agganciaDatalayer.NameProcedureDb = "RapportiPdf.inserisciTabellaDwn";
      return agganciaDatalayer.Delete(CollezioneControlli, idFile);
    }

    private void elininaFile(string nomefile)
    {
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string[] values = ConfigurationSettings.AppSettings.GetValues("DirectoryStampa");
      string fileName1 = this.Server.MapPath(values[0]) + nomefile + ".pdf";
      string fileName2 = this.Server.MapPath(values[0]) + nomefile + ".zip";
      FileInfo fileInfo1 = new FileInfo(fileName1);
      FileInfo fileInfo2 = new FileInfo(fileName2);
      if (!fileInfo1.Exists)
        throw new IOException();
      fileInfo1.Delete();
      if (!fileInfo2.Exists)
        throw new IOException();
      fileInfo2.Delete();
    }

    protected void imgBtnDownLoad_Click(object sender, CommandEventArgs e) => this.Response.Redirect("../stampe/" + (string) e.CommandArgument + ".zip");

    protected void lnkDett_Click(object sender, CommandEventArgs e)
    {
      string commandArgument = (string) e.CommandArgument;
      this.riempiSchedaDettaglio(this.riempiDatasetDettaglio(commandArgument));
      this.riempiSchedaDettaglioOdl(this.riempiDatasetDettaglioOdl(commandArgument));
      this.pnlShowInfo.Visible = true;
    }

    private DataSet riempiDatasetDettaglioOdl(string id)
    {
      AgganciaDatalayer agganciaDatalayer = new AgganciaDatalayer();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      int num1 = 0;
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("Pid");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      S_Object sObject2 = sObject1;
      int num2 = num1;
      int num3 = num2 + 1;
      ((ParameterObject) sObject2).set_Index(num2);
      ((ParameterObject) sObject1).set_Value((object) Convert.ToInt32(id));
      CollezioneControlli.Add(sObject1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("RSCursor");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      S_Object sObject4 = sObject3;
      int num4 = num3;
      int num5 = num4 + 1;
      ((ParameterObject) sObject4).set_Index(num4);
      CollezioneControlli.Add(sObject3);
      agganciaDatalayer.NameProcedureDb = "rapportipdf.RecuperaOdl";
      return agganciaDatalayer.GetData(CollezioneControlli).Copy();
    }

    private void riempiSchedaDettaglioOdl(DataSet dsOdl)
    {
      string empty = string.Empty;
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index <= dsOdl.Tables[0].Rows.Count - 1; ++index)
      {
        stringBuilder.Append(dsOdl.Tables[0].Rows[index][0].ToString());
        stringBuilder.Append("-");
      }
      string str = stringBuilder.ToString();
      this.lblIntervalloOdl.Text = str.Remove(str.Length - 1, 1);
    }

    private DatasetReport riempiDatasetDettaglio(string id)
    {
      AgganciaDatalayer agganciaDatalayer = new AgganciaDatalayer();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      int num1 = 0;
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("Pid");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      S_Object sObject2 = sObject1;
      int num2 = num1;
      int num3 = num2 + 1;
      ((ParameterObject) sObject2).set_Index(num2);
      ((ParameterObject) sObject1).set_Value((object) Convert.ToInt32(id));
      CollezioneControlli.Add(sObject1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("RSCursor");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      S_Object sObject4 = sObject3;
      int num4 = num3;
      int num5 = num4 + 1;
      ((ParameterObject) sObject4).set_Index(num4);
      CollezioneControlli.Add(sObject3);
      agganciaDatalayer.NameProcedureDb = "rapportipdf.RecuperaDettagli";
      DataSet dataSet = agganciaDatalayer.GetData(CollezioneControlli).Copy();
      DatasetReport datasetReport = new DatasetReport();
      for (int index = 0; index <= dataSet.Tables[0].Rows.Count - 1; ++index)
        datasetReport.Tables["DownloadFile"].ImportRow(dataSet.Tables[0].Rows[index]);
      return datasetReport;
    }

    private void riempiSchedaDettaglio(DatasetReport ds)
    {
      this.lblDataDiCreazione.Text = ds.Tables["DownloadFile"].Rows[0]["data_created"].ToString();
      this.lblTipologiaReport.Text = ds.Tables["DownloadFile"].Rows[0]["tipologia_report"].ToString();
      this.lblEdificio.Text = ds.Tables["DownloadFile"].Rows[0]["edificio"].ToString();
      this.lblComune.Text = ds.Tables["DownloadFile"].Rows[0]["comune"].ToString();
      this.lblDitta.Text = ds.Tables["DownloadFile"].Rows[0]["ditta"].ToString();
      this.lblCategoria.Text = ds.Tables["DownloadFile"].Rows[0]["categoria"].ToString();
      this.lblAddetto.Text = ds.Tables["DownloadFile"].Rows[0]["addetto"].ToString();
      this.lblSoloNonCompletate.Text = ds.Tables["DownloadFile"].Rows[0]["solo_non_completate"].ToString();
      this.lblSoloCompletate.Text = ds.Tables["DownloadFile"].Rows[0]["solo_completate"].ToString();
      this.lblSoloCompletateConFiltro.Text = ds.Tables["DownloadFile"].Rows[0]["data_di_completamento"].ToString();
      this.lblDimensioneFilePdf.Text = ds.Tables["DownloadFile"].Rows[0]["dimensione_file"].ToString();
      this.lblDimensioneFileZip.Text = ds.Tables["DownloadFile"].Rows[0]["dimensione_file_zip"].ToString();
      this.lblDataAssegnazioneIniziale.Text = ds.Tables["DownloadFile"].Rows[0]["data_assegnazione_init"].ToString();
      this.lblDataAssegnazioneFinale.Text = ds.Tables["DownloadFile"].Rows[0]["data_assegnazione_end"].ToString();
      this.lblDataCompletamentoIniziale.Text = ds.Tables["DownloadFile"].Rows[0]["data_completamento_init"].ToString();
      this.lblDataCompletamentoFinale.Text = ds.Tables["DownloadFile"].Rows[0]["data_completamento_end"].ToString();
    }

    private void lnkChiudi_Click(object sender, EventArgs e) => this.pnlShowInfo.Visible = false;

    private void S_btnEliminaTiitiFile_Click(object sender, EventArgs e)
    {
      this.eliminaTuutiFile();
      this.eliminaRecordDb();
      this.Response.Redirect("Ricerca_e_Stampa.aspx");
    }

    private void eliminaTuutiFile()
    {
      foreach (FileInfo file in new DirectoryInfo(this.Server.MapPath(ConfigurationSettings.AppSettings.GetValues("DirectoryStampa")[0])).GetFiles())
      {
        file.Attributes = FileAttributes.Normal;
        file.Delete();
      }
    }

    private void eliminaRecordDb()
    {
      AgganciaDatalayer agganciaDatalayer = new AgganciaDatalayer();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_finto");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Size(16);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject);
      agganciaDatalayer.NameProcedureDb = "RapportiPdf.svutaTbelleAppoggio";
      agganciaDatalayer.Delete(CollezioneControlli, 0);
    }
  }
}
