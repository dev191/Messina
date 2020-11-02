// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.AnalisiStatistiche.Recupera_SPRpt_ReportGiudizio
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using CrystalDecisions.CrystalReports.Engine;
using TheSite.Report;
using System.Globalization;
using TheSite.Report;

namespace TheSite.Classi.AnalisiStatistiche
{
  public class Recupera_SPRpt_ReportGiudizio : NomiStr
  {
    private string _Giudizio;
    private string _GiudizioTipologia;
    private string _GiudizioMesi;
    private string _NameStoredProcedure;
    private RptGiudizioServizio _RptGiudizioServizio;
    private RptGiudizioServizioTipologia _RptGiudizioServizioTipologia;
    private RptGiudizioServizioMesi _RptGiudizioServizioMesi;
    private ReportClass _rptGeneric;

    public string s_optbtnGiudizio
    {
      get => this._Giudizio;
      set => this._Giudizio = value;
    }

    public string s_optbtnGiudizioTipologia
    {
      get => this._GiudizioTipologia;
      set => this._GiudizioTipologia = value;
    }

    public string s_optbtnGiudizioMesi
    {
      get => this._GiudizioMesi;
      set => this._GiudizioMesi = value;
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
          docRpt.Load(rptRepostory + "RptGiudizioServizio.rpt");
          break;
        case 1:
          docRpt.Load(rptRepostory + "RptGiudizioServizioTipologia.rpt");
          break;
        case 2:
          docRpt.Load(rptRepostory + "RptGiudizioServizioMesi.rpt");
          break;
      }
    }

    private ReportClass getTipoReport()
    {
      switch (this.Grafico())
      {
        case 0:
          this._RptGiudizioServizio = new RptGiudizioServizio();
          this._rptGeneric = (ReportClass) this._RptGiudizioServizio;
          break;
        case 1:
          this._RptGiudizioServizioTipologia = new RptGiudizioServizioTipologia();
          this._rptGeneric = (ReportClass) this._RptGiudizioServizioTipologia;
          break;
        case 2:
          this._RptGiudizioServizioMesi = new RptGiudizioServizioMesi();
          this._rptGeneric = (ReportClass) this._RptGiudizioServizioMesi;
          break;
      }
      return this._rptGeneric;
    }

    private string getNameStoredProcedure()
    {
      switch (this.Grafico())
      {
        case 0:
          this._NameStoredProcedure = this.get_giudizio_servizio;
          break;
        case 1:
          this._NameStoredProcedure = this.get_giud_ser_tip;
          break;
        case 2:
          this._NameStoredProcedure = this.get_giud_serv_mesi;
          break;
      }
      return this._NameStoredProcedure;
    }

    private int Grafico()
    {
      int num = 100;
      if (this._Giudizio.ToUpper(new CultureInfo("it", false)) == "true".ToUpper(new CultureInfo("it", false)))
        num = 0;
      if (this._GiudizioTipologia.ToUpper(new CultureInfo("it", false)) == "true".ToUpper(new CultureInfo("it", false)))
        num = 1;
      if (this._GiudizioMesi.ToUpper(new CultureInfo("it", false)) == "true".ToUpper(new CultureInfo("it", false)))
        num = 2;
      return num;
    }

    private enum TipoGrafico
    {
      Giudizio,
      GiudizioTipologia,
      GiudizioMesi,
    }
  }
}
