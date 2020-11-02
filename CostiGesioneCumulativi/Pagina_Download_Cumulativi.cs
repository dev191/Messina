// Decompiled with JetBrains decompiler
// Type: TheSite.CostiGesioneCumulativi.Pagina_Download_Cumulativi
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.CostiGesioneCumulativi;
using TheSite.WebControls;

namespace TheSite.CostiGesioneCumulativi
{
  public class Pagina_Download_Cumulativi : Page
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
    protected Label LABEL24;
    protected Label LABEL25;
    protected Label LABEL26;
    protected Label LABEL27;
    protected Label LABEL28;
    protected Label lblIntestazione;
    protected Label lblDataDiCreazione;
    protected Label lblEdificio;
    protected Label lblComune;
    protected Label lblAddetto;
    protected Label lblDimensioneFilePdf;
    protected Label lblC11;
    protected Label lblDimensioneFileZip;
    protected Label Label1;
    protected S_Button S_btnEliminaTiitiFile;
    protected GridTitle GridTitleDownLoad;
    protected Label LABEL22;
    protected Label lblDitta;
    protected Label lblRichiestaLavoro;
    protected Label lblIntervalloRdl;
    protected Label lblOdl;
    protected Label lblUrgenza;
    protected Label lblStatoRichiesta;
    protected Label LABEL23;
    protected Label lblDataDa;
    protected Label LABEL2;
    protected Label lblDataA;
    protected Label LABEL3;
    protected Label LABEL4;
    protected Label LABEL5;
    protected Label lblRichiedenti;
    protected Label lblGruppo;
    protected Label lblServizio;
    protected Label LABEL6;
    protected Label lblTipoManutenzione;
    protected Label Label7;
    protected Label Label8;
    protected Label lblDataPrevistaInizio;
    protected Label lblDataPrevistaFine;
    public static string HelpLink = string.Empty;
    private AnalisiCostiOperativiDiGestioneCumulativo _fp;

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      if (!this.IsPostBack && this.Context.Handler is AnalisiCostiOperativiDiGestioneCumulativo)
      {
        this._fp = (AnalisiCostiOperativiDiGestioneCumulativo) this.Context.Handler;
        this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
      }
      Pagina_Download_Cumulativi.HelpLink = ((SiteModule) HttpContext.Current.Items[(object) "SiteModule"]).HelpLink;
      this.pgtlDownoloadStampe.MainTitle = "Download Rapporto Interventi Cumulativo".ToUpper();
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
      DataSet dataSet = this.riempiDatasetDownload();
      this.GridTitleDownLoad.NumeroRecords = Convert.ToString(dataSet.Tables[0].Rows.Count);
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.DataBind();
    }

    private DataSet riempiDatasetDownload()
    {
      AgganciaDatalayer agganciaDatalayer = new AgganciaDatalayer();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("RSCursor");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_Index(0);
      CollezioneControlli.Add(sObject);
      agganciaDatalayer.NameProcedureDb = "pack_CostiGestioneCumulativi.get_Download_Reports_An_Co_Op";
      return agganciaDatalayer.GetData(CollezioneControlli).Copy();
    }

    private void S_btnRicerca_Click(object sender, EventArgs e) => this.Server.Transfer("AnalisiCostiOperativiDiGestioneCumulativo.aspx");

    private void DataGridRicerca_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.ricerca();
    }

    protected void imgBtnVisualizza_Click(object sender, CommandEventArgs e)
    {
      this.Context.Items.Add((object) "nome_file", (object) (string) e.CommandArgument);
      this.Server.Transfer("VisualizzaRapportoTecnicoInterventoCumulativo.aspx");
    }

    protected void imgBtnElimina_Click(object sender, CommandEventArgs e)
    {
      string[] strArray = Convert.ToString(e.CommandArgument).Split(Convert.ToChar(","));
      int int32 = Convert.ToInt32(strArray[0].ToString());
      string nomefile = strArray[1].ToString();
      int num = this.deleteDb(int32);
      if (int32 != num)
        throw new Exception();
      this.elininaFile(nomefile);
      this.caricaDataGridRicerca();
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
      S_Object sObject2 = sObject1;
      int num2 = num1;
      int num3 = num2 + 1;
      ((ParameterObject) sObject2).set_Index(num2);
      ((ParameterObject) sObject1).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("P_STRINGARDL");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      S_Object sObject4 = sObject3;
      int num4 = num3;
      int num5 = num4 + 1;
      ((ParameterObject) sObject4).set_Index(num4);
      ((ParameterObject) sObject3).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject3);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("P_DATA_CREATED");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      S_Object sObject6 = sObject5;
      int num6 = num5;
      int num7 = num6 + 1;
      ((ParameterObject) sObject6).set_Index(num6);
      ((ParameterObject) sObject5).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject5);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("P_DATA_ASSEGNAZIONE_INIT");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      S_Object sObject8 = sObject7;
      int num8 = num7;
      int num9 = num8 + 1;
      ((ParameterObject) sObject8).set_Index(num8);
      ((ParameterObject) sObject7).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject7);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("P_DATA_ASSEGNAZIONE_END");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      S_Object sObject10 = sObject9;
      int num10 = num9;
      int num11 = num10 + 1;
      ((ParameterObject) sObject10).set_Index(num10);
      ((ParameterObject) sObject9).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject9);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("P_DATA_COMPLETAMENTO_INIT");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      S_Object sObject12 = sObject11;
      int num12 = num11;
      int num13 = num12 + 1;
      ((ParameterObject) sObject12).set_Index(num12);
      ((ParameterObject) sObject11).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject11);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("P_DATA_COMPLETAMENTO_END");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      S_Object sObject14 = sObject13;
      int num14 = num13;
      int num15 = num14 + 1;
      ((ParameterObject) sObject14).set_Index(num14);
      ((ParameterObject) sObject13).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject13);
      S_Object sObject15 = new S_Object();
      ((ParameterObject) sObject15).set_ParameterName("P_EDIFICIO");
      ((ParameterObject) sObject15).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject15).set_Size(8);
      S_Object sObject16 = sObject15;
      int num16 = num15;
      int num17 = num16 + 1;
      ((ParameterObject) sObject16).set_Index(num16);
      ((ParameterObject) sObject15).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject15);
      S_Object sObject17 = new S_Object();
      ((ParameterObject) sObject17).set_ParameterName("P_RICHIESTA_DI_LAVORO");
      ((ParameterObject) sObject17).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject17).set_Direction(ParameterDirection.Input);
      S_Object sObject18 = sObject17;
      int num18 = num17;
      int num19 = num18 + 1;
      ((ParameterObject) sObject18).set_Index(num18);
      ((ParameterObject) sObject17).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject17);
      S_Object sObject19 = new S_Object();
      ((ParameterObject) sObject19).set_ParameterName("P_ADDETTO");
      ((ParameterObject) sObject19).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject19).set_Direction(ParameterDirection.Input);
      S_Object sObject20 = sObject19;
      int num20 = num19;
      int num21 = num20 + 1;
      ((ParameterObject) sObject20).set_Index(num20);
      ((ParameterObject) sObject19).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject19);
      S_Object sObject21 = new S_Object();
      ((ParameterObject) sObject21).set_ParameterName("P_DATA_DA");
      ((ParameterObject) sObject21).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject21).set_Size(64);
      ((ParameterObject) sObject21).set_Direction(ParameterDirection.Input);
      S_Object sObject22 = sObject21;
      int num22 = num21;
      int num23 = num22 + 1;
      ((ParameterObject) sObject22).set_Index(num22);
      ((ParameterObject) sObject21).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject21);
      S_Object sObject23 = new S_Object();
      ((ParameterObject) sObject23).set_ParameterName("P_DATA_A");
      ((ParameterObject) sObject23).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject23).set_Size(64);
      ((ParameterObject) sObject23).set_Direction(ParameterDirection.Input);
      S_Object sObject24 = sObject23;
      int num24 = num23;
      int num25 = num24 + 1;
      ((ParameterObject) sObject24).set_Index(num24);
      ((ParameterObject) sObject23).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject23);
      S_Object sObject25 = new S_Object();
      ((ParameterObject) sObject25).set_ParameterName("P_ORDINE_LAVORO");
      ((ParameterObject) sObject25).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject25).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject25).set_Size(256);
      S_Object sObject26 = sObject25;
      int num26 = num25;
      int num27 = num26 + 1;
      ((ParameterObject) sObject26).set_Index(num26);
      ((ParameterObject) sObject25).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject25);
      S_Object sObject27 = new S_Object();
      ((ParameterObject) sObject27).set_ParameterName("P_STATO_RICHIESTA");
      ((ParameterObject) sObject27).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject27).set_Size(256);
      ((ParameterObject) sObject27).set_Direction(ParameterDirection.Input);
      S_Object sObject28 = sObject27;
      int num28 = num27;
      int num29 = num28 + 1;
      ((ParameterObject) sObject28).set_Index(num28);
      ((ParameterObject) sObject27).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject27);
      S_Object sObject29 = new S_Object();
      ((ParameterObject) sObject29).set_ParameterName("P_SERVIZIO_ID");
      ((ParameterObject) sObject29).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject29).set_Size(256);
      ((ParameterObject) sObject29).set_Direction(ParameterDirection.Input);
      S_Object sObject30 = sObject29;
      int num30 = num29;
      int num31 = num30 + 1;
      ((ParameterObject) sObject30).set_Index(num30);
      ((ParameterObject) sObject29).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject29);
      S_Object sObject31 = new S_Object();
      ((ParameterObject) sObject31).set_ParameterName("P_RICHIEDENTI_TIPO_ID");
      ((ParameterObject) sObject31).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject31).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject31).set_Size(256);
      S_Object sObject32 = sObject31;
      int num32 = num31;
      int num33 = num32 + 1;
      ((ParameterObject) sObject32).set_Index(num32);
      ((ParameterObject) sObject31).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject31);
      S_Object sObject33 = new S_Object();
      ((ParameterObject) sObject33).set_ParameterName("P_EM_ID");
      ((ParameterObject) sObject33).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject33).set_Size(256);
      ((ParameterObject) sObject33).set_Direction(ParameterDirection.Input);
      S_Object sObject34 = sObject33;
      int num34 = num33;
      int num35 = num34 + 1;
      ((ParameterObject) sObject34).set_Index(num34);
      ((ParameterObject) sObject33).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject33);
      S_Object sObject35 = new S_Object();
      ((ParameterObject) sObject35).set_ParameterName("P_ID_PRIORITY");
      ((ParameterObject) sObject35).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject35).set_Size(256);
      ((ParameterObject) sObject35).set_Direction(ParameterDirection.Input);
      S_Object sObject36 = sObject35;
      int num36 = num35;
      int num37 = num36 + 1;
      ((ParameterObject) sObject36).set_Index(num36);
      ((ParameterObject) sObject35).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject35);
      S_Object sObject37 = new S_Object();
      ((ParameterObject) sObject37).set_ParameterName("P_DESCRIZIONE");
      ((ParameterObject) sObject37).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject37).set_Size(256);
      ((ParameterObject) sObject37).set_Direction(ParameterDirection.Input);
      S_Object sObject38 = sObject37;
      int num38 = num37;
      int num39 = num38 + 1;
      ((ParameterObject) sObject38).set_Index(num38);
      ((ParameterObject) sObject37).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject37);
      S_Object sObject39 = new S_Object();
      ((ParameterObject) sObject39).set_ParameterName("P_TIPOMANUTENZIONE_ID");
      ((ParameterObject) sObject39).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject37).set_Size(256);
      ((ParameterObject) sObject39).set_Direction(ParameterDirection.Input);
      S_Object sObject40 = sObject39;
      int num40 = num39;
      int num41 = num40 + 1;
      ((ParameterObject) sObject40).set_Index(num40);
      ((ParameterObject) sObject39).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject39);
      S_Object sObject41 = new S_Object();
      ((ParameterObject) sObject41).set_ParameterName("P_DIMENSIONE_FILE");
      ((ParameterObject) sObject41).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject41).set_Direction(ParameterDirection.Input);
      S_Object sObject42 = sObject41;
      int num42 = num41;
      int num43 = num42 + 1;
      ((ParameterObject) sObject42).set_Index(num42);
      ((ParameterObject) sObject41).set_Value((object) 0);
      CollezioneControlli.Add(sObject41);
      S_Object sObject43 = new S_Object();
      ((ParameterObject) sObject43).set_ParameterName("P_DIMENSIONE_FILE_ZIP");
      ((ParameterObject) sObject43).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject43).set_Direction(ParameterDirection.Input);
      S_Object sObject44 = sObject43;
      int num44 = num43;
      int num45 = num44 + 1;
      ((ParameterObject) sObject44).set_Index(num44);
      ((ParameterObject) sObject43).set_Value((object) 0);
      CollezioneControlli.Add(sObject43);
      S_Object sObject45 = new S_Object();
      ((ParameterObject) sObject45).set_ParameterName("P_TIPOLOGIA_REPORT");
      ((ParameterObject) sObject45).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject45).set_Direction(ParameterDirection.Input);
      S_Object sObject46 = sObject45;
      int num46 = num45;
      int num47 = num46 + 1;
      ((ParameterObject) sObject46).set_Index(num46);
      ((ParameterObject) sObject45).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject45);
      S_Object sObject47 = new S_Object();
      ((ParameterObject) sObject47).set_ParameterName("p_DIMENSIONEFILE_PDF_ZIP");
      ((ParameterObject) sObject47).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject47).set_Direction(ParameterDirection.Input);
      S_Object sObject48 = sObject47;
      int num48 = num47;
      int num49 = num48 + 1;
      ((ParameterObject) sObject48).set_Index(num48);
      ((ParameterObject) sObject47).set_Value((object) 0);
      CollezioneControlli.Add(sObject47);
      agganciaDatalayer.NameProcedureDb = "pack_CostiGestioneCumulativi.UpdAnalisiCostiOperativi";
      return agganciaDatalayer.Delete(CollezioneControlli, idFile);
    }

    private void elininaFile(string nomefile)
    {
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string appSetting = ConfigurationSettings.AppSettings["DirectoryStampaCostoGestione"];
      string fileName1 = this.Server.MapPath(appSetting) + nomefile + ".pdf";
      string fileName2 = this.Server.MapPath(appSetting) + nomefile + ".zip";
      FileInfo fileInfo1 = new FileInfo(fileName1);
      FileInfo fileInfo2 = new FileInfo(fileName2);
      if (!fileInfo1.Exists)
        throw new IOException();
      fileInfo1.Delete();
      if (!fileInfo2.Exists)
        throw new IOException();
      fileInfo2.Delete();
    }

    protected void imgBtnDownLoad_Click(object sender, CommandEventArgs e) => this.Response.Redirect(ConfigurationSettings.AppSettings["DirectoryStampaCostoGestione"] + (string) e.CommandArgument + ".zip");

    protected void lnkDett_Click(object sender, CommandEventArgs e)
    {
      this.riempiSchedaDettaglio(this.riempiDatasetDettaglio((string) e.CommandArgument));
      this.pnlShowInfo.Visible = true;
    }

    private DataSet riempiDatasetDettaglio(string id)
    {
      AgganciaDatalayer agganciaDatalayer = new AgganciaDatalayer();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      int num1 = 0;
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("P_id");
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
      agganciaDatalayer.NameProcedureDb = "pack_CostiGestioneCumulativi.get_Dettaglio_Report_An_Co_Op";
      return agganciaDatalayer.GetData(CollezioneControlli).Copy();
    }

    private void riempiSchedaDettaglio(DataSet ds)
    {
      AgganciaDatalayer agganciaDatalayer = new AgganciaDatalayer();
      this.lblDataDiCreazione.Text = ds.Tables[0].Rows[0]["data_created"].ToString();
      this.lblRichiestaLavoro.Text = ds.Tables[0].Rows[0]["RICHIESTA_DI_LAVORO"].ToString();
      this.lblEdificio.Text = ds.Tables[0].Rows[0]["CODICE_EDIFICIO"].ToString();
      if (this.lblEdificio.Text != "tutti")
      {
        DataSet edificio = agganciaDatalayer.GetEdificio(this.lblEdificio.Text);
        this.lblComune.Text = edificio.Tables[0].Rows[0]["desccomune"].ToString();
        this.lblDitta.Text = edificio.Tables[0].Rows[0]["referente"].ToString();
      }
      else
      {
        agganciaDatalayer.GetEdificio(this.lblEdificio.Text);
        this.lblComune.Text = "tutti";
        this.lblDitta.Text = "tutte";
      }
      this.lblOdl.Text = ds.Tables[0].Rows[0]["ORDINE_LAVORO"].ToString();
      this.lblIntervalloRdl.Text = ds.Tables[0].Rows[0]["STRINGARDL"].ToString();
      this.lblGruppo.Text = ds.Tables[0].Rows[0]["richidenti_tipo_id"].ToString();
      this.lblRichiedenti.Text = ds.Tables[0].Rows[0]["EM_ID"].ToString();
      this.lblServizio.Text = ds.Tables[0].Rows[0]["SERVIZIO_ID"].ToString();
      this.lblTipoManutenzione.Text = ds.Tables[0].Rows[0]["TIPOMANUTENZIONE_ID"].ToString();
      this.lblAddetto.Text = ds.Tables[0].Rows[0]["ADDETTO_ID"].ToString();
      this.lblUrgenza.Text = ds.Tables[0].Rows[0]["ID_PRIORITY"].ToString();
      this.lblStatoRichiesta.Text = ds.Tables[0].Rows[0]["STATO_RICHIESTA"].ToString();
      this.lblDataDa.Text = ds.Tables[0].Rows[0]["DATA_DA"].ToString();
      this.lblDataA.Text = ds.Tables[0].Rows[0]["DATA_A"].ToString();
      this.lblDimensioneFilePdf.Text = ds.Tables[0].Rows[0]["dimensione_file"].ToString();
      this.lblDimensioneFileZip.Text = ds.Tables[0].Rows[0]["dimensione_file_zip"].ToString();
      this.lblDataPrevistaInizio.Text = ds.Tables[0].Rows[0]["data_assegnazione_init"].ToString();
      this.lblDataPrevistaFine.Text = ds.Tables[0].Rows[0]["data_assegnazione_end"].ToString();
    }

    private void lnkChiudi_Click(object sender, EventArgs e) => this.pnlShowInfo.Visible = false;

    private void S_btnEliminaTiitiFile_Click(object sender, EventArgs e)
    {
      this.eliminaTuutiFile();
      this.eliminaRecordDb();
      this.Server.Transfer("AnalisiCostiOperativiDiGestioneCumulativo.aspx");
    }

    private void eliminaTuutiFile()
    {
      foreach (FileInfo file in new DirectoryInfo(this.Server.MapPath(ConfigurationSettings.AppSettings["DirectoryStampaCostoGestione"])).GetFiles())
      {
        file.Attributes = FileAttributes.Normal;
        file.Delete();
      }
    }

    private void eliminaRecordDb() => new AgganciaDatalayer()
    {
      NameProcedureDb = "pack_CostiGestioneCumulativi.del_Download_Reports_An_Co_Op"
    }.Delete();
  }
}
