using System;
using System.Collections;
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;

namespace TheSite.Classi.AnalisiStatistiche
{
	
	/// <summary>
	/// Descrizione di riepilogo per StoredProcedure.
	/// </summary>
	public class StoredProdRpt : NomiStr
	{
	
		private string _SRichiesta, _SAssegnazione, _SChiusura;
		private string _SDitta, _SDittaMesi,_SMese;
		private string _SServizio, _SServizioMesi, _SStato;
		private string _NameStoredProcedure;
		private enum TipoGrafico {Mese,Ditta,DittaMese,Servizio,ServizioMese,Stato};
		private Report.RptDitta _RptDitta ;
		private Report.RptDittaMesi _RptDittaMesi;
		private Report.RptMese _RptMese;
		private Report.RptServizio _RptServizio;
		private Report.RptServizioMesi _RptServizioMesi;
		private Report.RptStato _RptStato;
		private ReportClass _rptGeneric;

		public StoredProdRpt()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//

		}

		public string s_OptBtnDataRichiesta
		{
			get {return _SRichiesta;}
			set {_SRichiesta= value;}
		}

		public string  s_OptBtnDataAssegnazione
		{
			get {return _SAssegnazione;}
			set {_SAssegnazione = value;}
		}
		public string s_OptBtnDataChiusura
		{
			get{return _SChiusura;}
			set{_SChiusura = value;}
		}
		public string s_OptBtnRdlDitta
		{
			get{return _SDitta;}
			set{_SDitta=value;}
		}
		public string s_OptBtnRdlDittaMesi
		{
			get {return _SDittaMesi;}
			set {_SDittaMesi = value;}
		}
		public string s_OptBtnRdlMese
		{
			get {return _SMese;}
			set {_SMese = value;}
		}
		public string s_OptBtnRdlServizio
		{
			get {return _SServizio;}
			set{_SServizio=value;}
		}
		public string s_OptBtnRdlServizioMesi
		{
			get {return _SServizioMesi;}
			set {_SServizioMesi= value;}
		}
		public string s_OptBtnRdlStato
		{
			get {return _SStato;}
			set {_SStato = value;}
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
				case (int)TipoGrafico.Ditta:
					docRpt.Load(rptRepostory + "RptDitta.rpt");
					break;
				case (int)TipoGrafico.DittaMese:
					docRpt.Load(rptRepostory + "RptDittaMesi.rpt");
					break;
				case (int)TipoGrafico.Mese:
					docRpt.Load(rptRepostory + "RptMese.rpt");
					break;
				case (int)TipoGrafico.Servizio:
					docRpt.Load(rptRepostory + "RptServizio.rpt");
					break;
				case (int)TipoGrafico.ServizioMese:
					docRpt.Load(rptRepostory + "RptServizioMesi.rpt");
					break;
				case (int)TipoGrafico.Stato:
					docRpt.Load(rptRepostory + "RptStato.rpt");
					break;
//				case (int)TipoGrafico.DittaMeseIstgr:
//					docRpt.Load(rptRepostory + "RptDittaMesiIstgr.rpt");
//					break;
//				case (int) TipoGrafico.ServizioMeseIstgr:
//					docRpt.Load(rptRepostory + "RptServizioMesiIstgr.rpt");
//					break;
//				case (int) TipoGrafico.Stazioni:
//					docRpt.Load(rptRepostory + "RptStazione.rpt");
//					break;
//				case (int) TipoGrafico.StazioniMesi:
//					docRpt.Load(rptRepostory + "RptStazioneMesi.rpt");
//					break;
				default:
					break;
			}

		}
		private ReportClass getTipoReport()
		{
				switch (Grafico())
				{
					case (int)TipoGrafico.Ditta:
						_RptDitta=new TheSite.Report.RptDitta();
						_rptGeneric = _RptDitta;
						break;
					case (int)TipoGrafico.DittaMese:
						_RptDittaMesi= new TheSite.Report.RptDittaMesi();
						_rptGeneric = _RptDittaMesi;
						break;
					case (int)TipoGrafico.Mese:
						_RptMese = new TheSite.Report.RptMese();
						_rptGeneric = _RptMese;
						break;
					case (int)TipoGrafico.Servizio:
						_RptServizio = new TheSite.Report.RptServizio();
						_rptGeneric = _RptServizio;
						break;
					case (int)TipoGrafico.ServizioMese:
						_RptServizioMesi = new TheSite.Report.RptServizioMesi();
						_rptGeneric = _RptServizioMesi;
						break;
					case (int)TipoGrafico.Stato:
						_RptStato = new TheSite.Report.RptStato();
						_rptGeneric= _RptStato; 
						break;
					default:
						break;
				}
			return _rptGeneric;
		}


		private string getNameStoredProcedure()
		{
			if(_SRichiesta.ToUpper(new CultureInfo("it",false )) == "true".ToUpper(new CultureInfo("it",false )))
			{
				switch (Grafico())
				{
					case (int)TipoGrafico.Ditta:
						_NameStoredProcedure =  this.GET_RDL_DITTA_RICHIESTA;
						break;
					case (int)TipoGrafico.DittaMese:
						_NameStoredProcedure =  this.GET_RDL_DITTA_MESI_RICH;
						break;
					case (int)TipoGrafico.Mese:
						_NameStoredProcedure =  this.GET_RDL_MESE_RICHIESTA;
						break;
					case (int)TipoGrafico.Servizio:
						_NameStoredProcedure =  this.GET_RDL_SERVIZIO_RICHIESTA;
						break;
					case (int)TipoGrafico.ServizioMese:
						_NameStoredProcedure =  this.GET_RDL_SERVIZIO_MESI_RICH;
						break;
					case (int)TipoGrafico.Stato:
						_NameStoredProcedure =  this.GET_RDL_STATO_RICHIESTA;
						break;
					default:
						break;
				}

			}
			if (_SAssegnazione.ToUpper(new CultureInfo("it",false)) == "true".ToUpper(new CultureInfo("it",false )))
			{
				switch (Grafico())
				{
					case (int)TipoGrafico.Ditta:
						_NameStoredProcedure =  this.GET_RDL_DITTA_ASSEGNATA;
						break;
					case (int)TipoGrafico.DittaMese:
						_NameStoredProcedure =  this.GET_RDL_DITTA_MESI_ASSEGN;
						break;
					case (int)TipoGrafico.Mese:
						_NameStoredProcedure =  this.GET_RDL_MESE_ASSEGNATA;
						break;
					case (int)TipoGrafico.Servizio:
						_NameStoredProcedure =  this.GET_RDL_SERVIZIO_ASSEGNATA;
						break;
					case (int)TipoGrafico.ServizioMese:
						_NameStoredProcedure =  this.GET_RDL_SERVIZIO_MESI_ASSEGN;
						break;
					case (int)TipoGrafico.Stato:
						_NameStoredProcedure =  this.GET_RDL_STATO_ASSEGNATA;
						break;
					default:
						break;
				}
			}
			if(_SChiusura.ToUpper(new CultureInfo("it",false )) == "true".ToUpper(new CultureInfo("it",false )))
			{
				switch (Grafico())
				{
					case (int)TipoGrafico.Ditta:
						_NameStoredProcedure =  this.GET_RDL_DITTA_COMPLETATA;
						break;
					case (int)TipoGrafico.DittaMese:
						_NameStoredProcedure =  this.GET_RDL_DITTA_MESI_COMP;
						break;
					case (int) TipoGrafico.Mese:
						_NameStoredProcedure =  this.GET_RDL_MESE_COMPLETATA;
						break;
					case (int)TipoGrafico.Servizio:
						_NameStoredProcedure =  this.GET_RDL_SERVIZIO_COMPLETATA;
						break;
					case (int) TipoGrafico.ServizioMese:
						_NameStoredProcedure =  this.GET_RDL_SERVIZIO_MESI_COMP;
						break;
					case (int)TipoGrafico.Stato:
						_NameStoredProcedure =  this.GET_RDL_STATO_COMPLETATA;
						break;
					default:
						break;
				}
				
			}
					return _NameStoredProcedure;
		}
		private int Grafico()
		{
			int TipoTmp=100;
			if(_SMese.ToUpper(new CultureInfo("it",false )) == "true".ToUpper(new CultureInfo("it",false )))
			{
				TipoTmp = (int) TipoGrafico.Mese;
			}
			if(_SDitta.ToUpper(new CultureInfo("it",false )) == "true".ToUpper(new CultureInfo("it",false )))
			{
				TipoTmp = (int) TipoGrafico.Ditta;
			}
			if(_SDittaMesi.ToUpper(new CultureInfo("it",false )) == "true".ToUpper(new CultureInfo("it",false )))
			{
				TipoTmp =  (int) TipoGrafico.DittaMese;
			}
			if(_SServizio.ToUpper(new CultureInfo("it",false )) == "true".ToUpper(new CultureInfo("it",false )))
			{
				TipoTmp = (int) TipoGrafico.Servizio;
			}
			if(_SServizioMesi.ToUpper(new CultureInfo("it",false )) == "true".ToUpper(new CultureInfo("it",false )))
			{
				TipoTmp = (int) TipoGrafico.ServizioMese;
			}
			if(_SStato.ToUpper(new CultureInfo("it",false )) == "true".ToUpper(new CultureInfo("it",false )))
			{
				TipoTmp = (int) TipoGrafico.Stato;
			}
			return TipoTmp;
		}
	}
}
