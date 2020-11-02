// Decompiled with JetBrains decompiler
// Type: TheSite.ReportGestioneSpazi.DisplayReportSpazi
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using S_Controls.Collections;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi.AnalisiStatistiche;
using TheSite.Eccezioni;
using TheSite.SchemiXSD;

namespace TheSite.ReportGestioneSpazi
{
  public class DisplayReportSpazi : Page
  {
    protected bool S_Categorie;
    protected bool S_Destinazione;
    protected bool S_Reparti;
    protected bool S_Misure;
    protected string tipoDocumento;
    private ReportDocument crReportDocument;
    private ExportOptions crExportOptions;
    protected CrystalReportViewer rptEngineOra;
    private DiskFileDestinationOptions crDiskFileDestinationOptions;
    private string stringaEdifici = "";
    private string stringaPiano = "";
    private string stringaReparto = "";
    private string stringaDestinazione = "";
    private string stringaCategoria = "";
    private string idCategoria = "";
    private string stringaStanza = "";
    protected Label LabelMessaggio;
    private string piano = "";
    private string stanza = "";
    private string operatoreMq = "";
    protected Button Button1;
    private string valoreMq = "";

    private void Page_Load(object sender, EventArgs e)
    {
      this.tipoDocumento = this.Request["tipoDocumento"];
      this.S_Categorie = Convert.ToBoolean(this.Request["S_Categorie"]);
      this.S_Destinazione = Convert.ToBoolean(this.Request["S_Destinazione"]);
      this.S_Reparti = Convert.ToBoolean(this.Request["S_Reparti"]);
      this.S_Misure = Convert.ToBoolean(this.Request["S_Misure"]);
      this.stringaEdifici = this.Request["stringaEdifici"];
      this.stringaReparto = this.Request["stringaReparto"];
      this.stringaPiano = this.Request["lblpiano"];
      this.stringaDestinazione = this.Request["stringaDestinazione"];
      this.stringaCategoria = this.Request["stringaCategoria"];
      this.idCategoria = this.Request["idCategoria"];
      this.stringaStanza = this.Request["stringaStanza"];
      this.piano = this.Request["piano"];
      this.stanza = this.Request["stanza"];
      this.operatoreMq = this.Request["operatoreMq"];
      this.valoreMq = this.Request["valoreMq"];
      this.IpostaRpt();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      this.crReportDocument = new ReportDocument();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.Button1.Click += new EventHandler(this.Button1_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void IpostaRpt() => this.bindReport(this.recuperaDataSet(new DsGestioneSpazi()));

    private void bindReport(DsGestioneSpazi dsRpt)
    {
      string str1 = this.Server.MapPath(this.Request.ApplicationPath + ConfigurationSettings.AppSettings["SourceReports"]);
      this.crReportDocument.Load(this.Server.MapPath("../report/" + this.GetReportSource()));
      this.crReportDocument.SetDataSource((object) dsRpt);
      this.crReportDocument.SetParameterValue("tipo", (object) this.tipoDocumento);
      switch (this.tipoDocumento)
      {
        case "PDF":
          string str2 = str1 + this.Session.SessionID.ToString() + ".pdf";
          this.crDiskFileDestinationOptions = new DiskFileDestinationOptions();
          this.crDiskFileDestinationOptions.set_DiskFileName(str2);
          this.crExportOptions = this.crReportDocument.get_ExportOptions();
          this.crExportOptions.set_DestinationOptions((object) this.crDiskFileDestinationOptions);
          this.crExportOptions.set_ExportDestinationType((ExportDestinationType) 1);
          this.crExportOptions.set_ExportFormatType((ExportFormatType) 5);
          this.crReportDocument.Export();
          this.Response.ClearContent();
          this.Response.ClearHeaders();
          this.Response.ContentType = "application/pdf";
          this.Response.WriteFile(str2);
          this.Response.Flush();
          this.Response.Close();
          File.Delete(str2);
          break;
        case "HTML":
          this.rptEngineOra.set_DisplayGroupTree(false);
          this.rptEngineOra.set_DisplayToolbar(true);
          this.rptEngineOra.set_SeparatePages(false);
          ((CrystalReportViewerBase) this.rptEngineOra).set_ReportSource((object) this.crReportDocument);
          break;
      }
    }

    private DsGestioneSpazi recuperaDataSet(DsGestioneSpazi ds)
    {
      try
      {
        int num1 = 0;
        wrapDb wrapDb = new wrapDb();
        S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_Id_Edificio");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Size(300);
        S_Object sObject2 = sObject1;
        int num2 = num1;
        int num3 = num2 + 1;
        ((ParameterObject) sObject2).set_Index(num2);
        ((ParameterObject) sObject1).set_Value((object) this.stringaEdifici);
        CollezioneControlli.Add(sObject1);
        S_Object sObject3 = new S_Object();
        ((ParameterObject) sObject3).set_ParameterName("p_Id_Piano");
        ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
        S_Object sObject4 = sObject3;
        int num4 = num3;
        int num5 = num4 + 1;
        ((ParameterObject) sObject4).set_Index(num4);
        if (this.piano == "")
          ((ParameterObject) sObject3).set_Value((object) 0);
        else
          ((ParameterObject) sObject3).set_Value((object) Convert.ToInt32(this.piano));
        CollezioneControlli.Add(sObject3);
        S_Object sObject5 = new S_Object();
        ((ParameterObject) sObject5).set_ParameterName("p_Id_Stanza");
        ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject5).set_Size((int) byte.MaxValue);
        S_Object sObject6 = sObject5;
        int num6 = num5;
        int num7 = num6 + 1;
        ((ParameterObject) sObject6).set_Index(num6);
        ((ParameterObject) sObject5).set_Value((object) this.stanza);
        CollezioneControlli.Add(sObject5);
        S_Object sObject7 = new S_Object();
        ((ParameterObject) sObject7).set_ParameterName("p_Str_Dest_Uso");
        ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject7).set_Size(256);
        S_Object sObject8 = sObject7;
        int num8 = num7;
        int num9 = num8 + 1;
        ((ParameterObject) sObject8).set_Index(num8);
        ((ParameterObject) sObject7).set_Value((object) this.stringaDestinazione);
        CollezioneControlli.Add(sObject7);
        S_Object sObject9 = new S_Object();
        ((ParameterObject) sObject9).set_ParameterName("p_Str_Reparto");
        ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject9).set_Size((int) byte.MaxValue);
        S_Object sObject10 = sObject9;
        int num10 = num9;
        int num11 = num10 + 1;
        ((ParameterObject) sObject10).set_Index(num10);
        ((ParameterObject) sObject9).set_Value((object) this.stringaReparto);
        CollezioneControlli.Add(sObject9);
        S_Object sObject11 = new S_Object();
        ((ParameterObject) sObject11).set_ParameterName("p_Str_Cat");
        ((ParameterObject) sObject11).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject11).set_Size((int) byte.MaxValue);
        S_Object sObject12 = sObject11;
        int num12 = num11;
        int num13 = num12 + 1;
        ((ParameterObject) sObject12).set_Index(num12);
        ((ParameterObject) sObject11).set_Value((object) this.idCategoria);
        CollezioneControlli.Add(sObject11);
        S_Object sObject13 = new S_Object();
        ((ParameterObject) sObject13).set_ParameterName("p_Operatore_Area");
        ((ParameterObject) sObject13).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject13).set_Size((int) byte.MaxValue);
        S_Object sObject14 = sObject13;
        int num14 = num13;
        int num15 = num14 + 1;
        ((ParameterObject) sObject14).set_Index(num14);
        ((ParameterObject) sObject13).set_Value((object) this.operatoreMq);
        CollezioneControlli.Add(sObject13);
        S_Object sObject15 = new S_Object();
        ((ParameterObject) sObject15).set_ParameterName("p_Int_MQ2");
        ((ParameterObject) sObject15).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject15).set_Direction(ParameterDirection.Input);
        S_Object sObject16 = sObject15;
        int num16 = num15;
        int num17 = num16 + 1;
        ((ParameterObject) sObject16).set_Index(num16);
        if (this.valoreMq == "")
          ((ParameterObject) sObject15).set_Value((object) 0);
        else
          ((ParameterObject) sObject15).set_Value((object) Convert.ToInt32(this.valoreMq));
        CollezioneControlli.Add(sObject15);
        S_Object sObject17 = new S_Object();
        ((ParameterObject) sObject17).set_ParameterName("IO_CURSOR");
        ((ParameterObject) sObject17).set_DbType((CustomDBType) 8);
        ((ParameterObject) sObject17).set_Direction(ParameterDirection.Output);
        S_Object sObject18 = sObject17;
        int num18 = num17;
        int num19 = num18 + 1;
        ((ParameterObject) sObject18).set_Index(num18);
        CollezioneControlli.Add(sObject17);
        wrapDb.s_storedProcedureName = "PACK_RPT_GESTIONE_SPAZI." + this.GetNomeStrPrd();
        DataSet dataSet = wrapDb.GetData(CollezioneControlli).Copy();
        DsGestioneSpazi.parametriRow parametriRow = (DsGestioneSpazi.parametriRow) ds.parametri.NewRow();
        parametriRow.edifici = this.stringaEdifici.Replace("','", " ");
        parametriRow.piano = this.stringaPiano;
        parametriRow.stanza = this.stringaStanza;
        parametriRow.categoria = this.stringaCategoria;
        parametriRow.destUso = this.stringaDestinazione;
        parametriRow.reparto = this.stringaReparto;
        parametriRow.opMq = this.operatoreMq;
        parametriRow.Mq = this.valoreMq;
        ds.Tables["parametri"].Rows.Add((DataRow) parametriRow);
        int index;
        for (index = 0; index <= dataSet.Tables[0].Rows.Count - 1; ++index)
        {
          if (!Convert.ToBoolean(this.S_Misure))
            ds.Tables["tabellina"].ImportRow(dataSet.Tables[0].Rows[index]);
          else
            ds.Tables["tabellina2"].ImportRow(dataSet.Tables[0].Rows[index]);
        }
        if (index == 0)
          throw new NoDataForReportFoundException();
        ds.GetXml();
        return ds;
      }
      catch (NoDataForReportFoundException ex)
      {
        this.LabelMessaggio.Text = "Nono sono presenti dati per i criteri di ricerca selezionati";
        ((Control) this.rptEngineOra).Visible = false;
        return (DsGestioneSpazi) null;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private string GetNomeStrPrd()
    {
      if (this.S_Categorie)
        return DisplayReportSpazi.nomiProcedure.SP_GET_DISTR_CAT.ToString();
      if (this.S_Destinazione)
        return DisplayReportSpazi.nomiProcedure.SP_GET_DISTR_DEST_USO.ToString();
      if (this.S_Misure)
        return DisplayReportSpazi.nomiProcedure.SP_GET_DISTR_MISURE.ToString();
      return this.S_Reparti ? DisplayReportSpazi.nomiProcedure.SP_GET_DISTR_REPARTI.ToString() : "";
    }

    private string GetReportSource()
    {
      if (this.S_Categorie)
        return DisplayReportSpazi.nomiReport.RptSpaziDistrCategorie_V9.ToString() + ".rpt";
      if (this.S_Destinazione)
        return DisplayReportSpazi.nomiReport.RptSpaziDistrDestUso_V9.ToString() + ".rpt";
      if (this.S_Misure)
        return DisplayReportSpazi.nomiReport.RptSpaziDistrMusure_V9.ToString() + ".rpt";
      return this.S_Reparti ? DisplayReportSpazi.nomiReport.RptSpaziDistrReparti_V9.ToString() + ".rpt" : "";
    }

    private void Button1_Click(object sender, EventArgs e) => this.Response.Redirect("ReportGestioneSpazi.aspx");

    private enum nomiProcedure
    {
      SP_GET_DISTR_REPARTI,
      SP_GET_DISTR_DEST_USO,
      SP_GET_DISTR_CAT,
      SP_GET_DISTR_MISURE,
    }

    private enum nomiReport
    {
      RptSpaziDistrReparti_V9,
      RptSpaziDistrDestUso_V9,
      RptSpaziDistrCategorie_V9,
      RptSpaziDistrMusure_V9,
    }
  }
}
