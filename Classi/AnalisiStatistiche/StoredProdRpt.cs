// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.AnalisiStatistiche.StoredProdRpt
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using CrystalDecisions.CrystalReports.Engine;
using TheSite.Report;
using System.Globalization;
using TheSite.Report;

namespace TheSite.Classi.AnalisiStatistiche
{
  public class StoredProdRpt : NomiStr
  {
    private string _SRichiesta;
    private string _SAssegnazione;
    private string _SChiusura;
    private string _SDitta;
    private string _SDittaMesi;
    private string _SMese;
    private string _SServizio;
    private string _SServizioMesi;
    private string _SStato;
    private string _NameStoredProcedure;
    private RptDitta _RptDitta;
    private Report.RptDittaMesi _RptDittaMesi;
    private RptMese _RptMese;
    private RptServizio _RptServizio;
    private RptServizioMesi _RptServizioMesi;
    private RptStato _RptStato;
    private ReportClass _rptGeneric;

    public string s_OptBtnDataRichiesta
    {
      get => this._SRichiesta;
      set => this._SRichiesta = value;
    }

    public string s_OptBtnDataAssegnazione
    {
      get => this._SAssegnazione;
      set => this._SAssegnazione = value;
    }

    public string s_OptBtnDataChiusura
    {
      get => this._SChiusura;
      set => this._SChiusura = value;
    }

    public string s_OptBtnRdlDitta
    {
      get => this._SDitta;
      set => this._SDitta = value;
    }

    public string s_OptBtnRdlDittaMesi
    {
      get => this._SDittaMesi;
      set => this._SDittaMesi = value;
    }

    public string s_OptBtnRdlMese
    {
      get => this._SMese;
      set => this._SMese = value;
    }

    public string s_OptBtnRdlServizio
    {
      get => this._SServizio;
      set => this._SServizio = value;
    }

    public string s_OptBtnRdlServizioMesi
    {
      get => this._SServizioMesi;
      set => this._SServizioMesi = value;
    }

    public string s_OptBtnRdlStato
    {
      get => this._SStato;
      set => this._SStato = value;
    }

    public string NameStoredProcedure
    {
      get => this.getNameStoredProcedure();
      set => this._NameStoredProcedure = value;
    }

    public ReportClass getReport => this.getTipoReport();

    public void ImpostaSourceReport(ReportDocument docRpt, string rptRepostory) => this.ImpostaFileRpt(docRpt, rptRepostory);

    private void ImpostaFileRpt(ReportDocument docRpt, string rptRepostory)
    {
      switch (this.Grafico())
      {
        case 0:
          docRpt.Load(rptRepostory + "RptMese.rpt");
          break;
        case 1:
          docRpt.Load(rptRepostory + "RptDitta.rpt");
          break;
        case 2:
          docRpt.Load(rptRepostory + "RptDittaMesi.rpt");
          break;
        case 3:
          docRpt.Load(rptRepostory + "RptServizio.rpt");
          break;
        case 4:
          docRpt.Load(rptRepostory + "RptServizioMesi.rpt");
          break;
        case 5:
          docRpt.Load(rptRepostory + "RptStato.rpt");
          break;
      }
    }

    private ReportClass getTipoReport()
    {
      switch (this.Grafico())
      {
        case 0:
          this._RptMese = new RptMese();
          this._rptGeneric = (ReportClass) this._RptMese;
          break;
        case 1:
          this._RptDitta = new RptDitta();
          this._rptGeneric = (ReportClass) this._RptDitta;
          break;
        case 2:
          this._RptDittaMesi = new RptDittaMesi();
          this._rptGeneric = (ReportClass) this._RptDittaMesi;
          break;
        case 3:
          this._RptServizio = new RptServizio();
          this._rptGeneric = (ReportClass) this._RptServizio;
          break;
        case 4:
          this._RptServizioMesi = new RptServizioMesi();
          this._rptGeneric = (ReportClass) this._RptServizioMesi;
          break;
        case 5:
          this._RptStato = new RptStato();
          this._rptGeneric = (ReportClass) this._RptStato;
          break;
      }
      return this._rptGeneric;
    }

    private string getNameStoredProcedure()
    {
      if (this._SRichiesta.ToUpper(new CultureInfo("it", false)) == "true".ToUpper(new CultureInfo("it", false)))
      {
        switch (this.Grafico())
        {
          case 0:
            this._NameStoredProcedure = this.GET_RDL_MESE_RICHIESTA;
            break;
          case 1:
            this._NameStoredProcedure = this.GET_RDL_DITTA_RICHIESTA;
            break;
          case 2:
            this._NameStoredProcedure = this.GET_RDL_DITTA_MESI_RICH;
            break;
          case 3:
            this._NameStoredProcedure = this.GET_RDL_SERVIZIO_RICHIESTA;
            break;
          case 4:
            this._NameStoredProcedure = this.GET_RDL_SERVIZIO_MESI_RICH;
            break;
          case 5:
            this._NameStoredProcedure = this.GET_RDL_STATO_RICHIESTA;
            break;
        }
      }
      if (this._SAssegnazione.ToUpper(new CultureInfo("it", false)) == "true".ToUpper(new CultureInfo("it", false)))
      {
        switch (this.Grafico())
        {
          case 0:
            this._NameStoredProcedure = this.GET_RDL_MESE_ASSEGNATA;
            break;
          case 1:
            this._NameStoredProcedure = this.GET_RDL_DITTA_ASSEGNATA;
            break;
          case 2:
            this._NameStoredProcedure = this.GET_RDL_DITTA_MESI_ASSEGN;
            break;
          case 3:
            this._NameStoredProcedure = this.GET_RDL_SERVIZIO_ASSEGNATA;
            break;
          case 4:
            this._NameStoredProcedure = this.GET_RDL_SERVIZIO_MESI_ASSEGN;
            break;
          case 5:
            this._NameStoredProcedure = this.GET_RDL_STATO_ASSEGNATA;
            break;
        }
      }
      if (this._SChiusura.ToUpper(new CultureInfo("it", false)) == "true".ToUpper(new CultureInfo("it", false)))
      {
        switch (this.Grafico())
        {
          case 0:
            this._NameStoredProcedure = this.GET_RDL_MESE_COMPLETATA;
            break;
          case 1:
            this._NameStoredProcedure = this.GET_RDL_DITTA_COMPLETATA;
            break;
          case 2:
            this._NameStoredProcedure = this.GET_RDL_DITTA_MESI_COMP;
            break;
          case 3:
            this._NameStoredProcedure = this.GET_RDL_SERVIZIO_COMPLETATA;
            break;
          case 4:
            this._NameStoredProcedure = this.GET_RDL_SERVIZIO_MESI_COMP;
            break;
          case 5:
            this._NameStoredProcedure = this.GET_RDL_STATO_COMPLETATA;
            break;
        }
      }
      return this._NameStoredProcedure;
    }

    private int Grafico()
    {
      int num = 100;
      if (this._SMese.ToUpper(new CultureInfo("it", false)) == "true".ToUpper(new CultureInfo("it", false)))
        num = 0;
      if (this._SDitta.ToUpper(new CultureInfo("it", false)) == "true".ToUpper(new CultureInfo("it", false)))
        num = 1;
      if (this._SDittaMesi.ToUpper(new CultureInfo("it", false)) == "true".ToUpper(new CultureInfo("it", false)))
        num = 2;
      if (this._SServizio.ToUpper(new CultureInfo("it", false)) == "true".ToUpper(new CultureInfo("it", false)))
        num = 3;
      if (this._SServizioMesi.ToUpper(new CultureInfo("it", false)) == "true".ToUpper(new CultureInfo("it", false)))
        num = 4;
      if (this._SStato.ToUpper(new CultureInfo("it", false)) == "true".ToUpper(new CultureInfo("it", false)))
        num = 5;
      return num;
    }

    private enum TipoGrafico
    {
      Mese,
      Ditta,
      DittaMese,
      Servizio,
      ServizioMese,
      Stato,
    }
  }
}
