using System;
using System.Collections;
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;


namespace TheSite.Classi.AnalisiStatistiche
{
	/// <summary>
	/// Descrizione di riepilogo per Recupera_SPRpt_ReportGiudizio.
	/// </summary>
	public class Recupera_SPRpt_ReportGiudizio : NomiStr
	{
		public Recupera_SPRpt_ReportGiudizio()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}


		private string  _Giudizio,_GiudizioTipologia,_GiudizioMesi;
		private string _NameStoredProcedure;
		private enum TipoGrafico {Giudizio,GiudizioTipologia,GiudizioMesi};
		private Report.RptGiudizioServizio _RptGiudizioServizio ;
		private Report.RptGiudizioServizioTipologia _RptGiudizioServizioTipologia;
		private Report.RptGiudizioServizioMesi _RptGiudizioServizioMesi;
		private ReportClass _rptGeneric;

		public string s_optbtnGiudizio
		{
			get {return _Giudizio;}
			set {_Giudizio = value;}
		}

		public string  s_optbtnGiudizioTipologia
		{
			get {return _GiudizioTipologia;}
			set {_GiudizioTipologia = value;}
		}
		public string s_optbtnGiudizioMesi
		{
			get{return _GiudizioMesi;}
			set{_GiudizioMesi = value;}
		}
		
		public string NameStoredProcedure
		{
			get{return getNameStoredProcedure();}
			set{_NameStoredProcedure = value;}
		}
		public ReportClass getReport
		{
			get{return getTipoReport();}
		}
		public void ImpostaSourceReport(ReportDocument docRpt,string rptRepostory)
		{
			ImpostaFileRpt(docRpt,rptRepostory);
		}
		private void ImpostaFileRpt(ReportDocument docRpt,string rptRepostory)
		{
			switch (Grafico())
			{
				case (int)TipoGrafico.Giudizio:
					docRpt.Load(rptRepostory + "RptGiudizioServizio.rpt");
					break;
				case (int)TipoGrafico.GiudizioTipologia:
					docRpt.Load(rptRepostory + "RptGiudizioServizioTipologia.rpt");
					break;
				case (int)TipoGrafico.GiudizioMesi:
					docRpt.Load(rptRepostory + "RptGiudizioServizioMesi.rpt");
					break;
				default:
					break;
			}
			
		}
		private ReportClass getTipoReport()
		{
			switch (Grafico())
			{
				case (int)TipoGrafico.Giudizio:
					_RptGiudizioServizio = new Report.RptGiudizioServizio();
					_rptGeneric = _RptGiudizioServizio;
					break;
				case (int)TipoGrafico.GiudizioTipologia:
					_RptGiudizioServizioTipologia= new Report.RptGiudizioServizioTipologia();
					_rptGeneric = _RptGiudizioServizioTipologia;
					break;
				case (int)TipoGrafico.GiudizioMesi:
					_RptGiudizioServizioMesi = new Report.RptGiudizioServizioMesi();
					_rptGeneric = _RptGiudizioServizioMesi;
					break;
				default:
					break;
			}
			return _rptGeneric;
		}


		private string getNameStoredProcedure()
		{
			
			switch (Grafico())
			{
				case (int)TipoGrafico.Giudizio:
					_NameStoredProcedure =  this.get_giudizio_servizio;
					break;
				case (int)TipoGrafico.GiudizioMesi:
					_NameStoredProcedure =  this.get_giud_serv_mesi;
					break;
				case (int)TipoGrafico.GiudizioTipologia:
					_NameStoredProcedure =  this.get_giud_ser_tip;
					break;
				default:
					break;
			}
			return _NameStoredProcedure;;
		}
		private int Grafico()
		{
			int TipoTmp=100;
			if(_Giudizio.ToUpper(new CultureInfo("it",false )) == "true".ToUpper(new CultureInfo("it",false )))
			{
				TipoTmp = (int) TipoGrafico.Giudizio;
			}
			if(_GiudizioTipologia.ToUpper(new CultureInfo("it",false )) == "true".ToUpper(new CultureInfo("it",false )))
			{
				TipoTmp = (int) TipoGrafico.GiudizioTipologia;
			}
			if(_GiudizioMesi.ToUpper(new CultureInfo("it",false )) == "true".ToUpper(new CultureInfo("it",false )))
			{
				TipoTmp =  (int) TipoGrafico.GiudizioMesi;
			}
			
			return TipoTmp;
		}
	}
}
