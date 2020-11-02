using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using TheSite.SchemiXSD;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using TheSite.Classi.AnalisiStatistiche;
using System.Configuration;


namespace TheSite.AnalisiStatistiche
{
	
	/// <summary>
	/// Descrizione di riepilogo per DysplayReport.
	/// </summary>
	/// 		
	public class DysplayReport : System.Web.UI.Page    // System.Web.UI.Page
	{
		private string sDataPkInit,sDataPkEnd;
		private string s_OptBtnDataRichiesta, s_OptBtnDataAssegnazione, s_OptBtnDataChiusura;
		private string s_OptBtnRdlDitta, s_OptBtnRdlDittaMesi,s_OptBtnRdlMese;
		private string s_OptBtnRdlServizio, s_OptBtnRdlServizioMesi, s_OptBtnRdlStato;
		private enum TipoM {Richiesta=1 ,Programmata,Straordinaria,Entrambe};
		private int  i_Tipologia;
		protected  CrystalReportViewer rptEngineOra;
		private StoredProdRpt _get_NPrcd_Rpt = new StoredProdRpt();
		private string s_AspPgReq, tipoDocumento;
		private ReportDocument crReportDocument;
		private ExportOptions crExportOptions;
		private DiskFileDestinationOptions crDiskFileDestinationOptions;

		private void Page_Load(object sender, System.EventArgs e)
		{
		
				s_AspPgReq = Request["tipologia"].ToString();
				if(s_AspPgReq == Convert.ToString((int) TipoM.Richiesta))
				{	
					i_Tipologia = (int)TipoM.Richiesta;
				}
				else if(s_AspPgReq == Convert.ToString((int) TipoM.Programmata)) 
				{	
					i_Tipologia=(int)TipoM.Programmata;
				}
				else if(s_AspPgReq == Convert.ToString((int) TipoM.Straordinaria))
				{
					i_Tipologia = (int)TipoM.Straordinaria;
				}
				else if(s_AspPgReq == Convert.ToString((int) TipoM.Entrambe))
				{
					i_Tipologia = (int) TipoM.Entrambe;
				}
				else
				{
					throw new Exception("*Andrea: Pagina di dichiesta non riconosciuta");
				}
		

				if(i_Tipologia == (int)TipoM.Richiesta ||i_Tipologia == (int) TipoM.Straordinaria || i_Tipologia == (int)TipoM.Entrambe)
				{
					s_OptBtnDataRichiesta= Request["S_OptBtnDataRichiesta"];
				}
				else if (i_Tipologia == (int)TipoM.Programmata)
				{
					s_OptBtnDataRichiesta="False";
				}
				else
				{
					Exception ex = new Exception("*Andrea: La pagina di richiesta non può essere impostata");
					throw  ex;
				}
		

			sDataPkInit				 = Request["DataPkInit"];
			sDataPkEnd               = Request["DataPkEnd"]; 
			s_OptBtnDataAssegnazione = Request["S_OptBtnDataAssegnazione"];
			s_OptBtnDataChiusura	 = Request["S_OptBtnDataChiusura"];
			s_OptBtnRdlDitta		 = Request["S_OptBtnRdlDitta"];
			s_OptBtnRdlDittaMesi	 = Request["S_OptBtnRdlDittaMesi"];
			s_OptBtnRdlMese			 = Request["S_OptBtnRdlMese"];
			s_OptBtnRdlServizio		 = Request["S_OptBtnRdlServizio"];
			s_OptBtnRdlServizioMesi  = Request["S_OptBtnRdlServizioMesi"];
			s_OptBtnRdlStato		 = Request["S_OptBtnRdlStato"];
			tipoDocumento                = Request["tipoDocumento"];
			IpostaRpt();
		}

		#region Codice generato da Progettazione Web Form
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: questa chiamata è richiesta da Progettazione Web Form ASP.NET.
			//
			InitializeComponent();
			crReportDocument = new ReportDocument();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{   
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void IpostaRpt()
		{
			DsAnalisiStatistiche ds = new DsAnalisiStatistiche();
			if(i_Tipologia == (int)TipoM.Entrambe)
			{
				ds = recuperaDataSet(ds,(int)TipoM.Richiesta);
				ds = recuperaDataSet(ds,(int)TipoM.Straordinaria);
			}
			else
			{
				ds = recuperaDataSet(ds,i_Tipologia);
			}
			bindReport(ds);
		}	
		private void bindReport(DataSet dsRpt)
		{			
				
			string pathRptSource = Server.MapPath(Request.ApplicationPath + ConfigurationSettings.AppSettings["SourceReports"]);
			_get_NPrcd_Rpt.ImpostaSourceReport(crReportDocument,pathRptSource);
			crReportDocument.SetDataSource(dsRpt);
			switch(tipoDocumento)
			{
				case  "PDF" :
					string Fname = pathRptSource  + Session.SessionID.ToString() + ".pdf" ;
					crDiskFileDestinationOptions = new DiskFileDestinationOptions();
					crDiskFileDestinationOptions.DiskFileName = Fname;
					crExportOptions = crReportDocument.ExportOptions;
					crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
					crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
					crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
					crReportDocument.Export();
					Response.ClearContent();
					Response.ClearHeaders();
					Response.ContentType = "application/pdf";
					Response.WriteFile(Fname);
					Response.Flush();
					Response.Close();
					System.IO.File.Delete(Fname);
					break;
				case "HTML" :
					rptEngineOra.ReportSource = crReportDocument;
					break;
				default:
					// non fai nulla
					break;
			}
				

		}
		private DsAnalisiStatistiche recuperaDataSet(DsAnalisiStatistiche ds,int tipologiaManutenzione)
		{
			try
			{
				Classi.AnalisiStatistiche.wrapDb _IODB = new TheSite.Classi.AnalisiStatistiche.wrapDb();
				S_Controls.Collections.S_ControlsCollection _Scollection = new S_Controls.Collections.S_ControlsCollection();

				S_Controls.Collections.S_Object s_data_init  = new S_Controls.Collections.S_Object();
				s_data_init.ParameterName = "S_DATA_INIT";
				s_data_init.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				s_data_init.Direction = ParameterDirection.Input;
				s_data_init.Size =10;
				s_data_init.Index = 0;
				s_data_init.Value = sDataPkInit;
				_Scollection.Add(s_data_init);


				S_Controls.Collections.S_Object s_data_end  = new S_Controls.Collections.S_Object();
				s_data_end.ParameterName = "S_DATA_END";
				s_data_end.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				s_data_end.Direction = ParameterDirection.Input;
				s_data_end.Size =10;
				s_data_end.Index = 2;
				s_data_end.Value = sDataPkEnd;
				_Scollection.Add(s_data_end);

				S_Controls.Collections.S_Object i_tip  = new S_Controls.Collections.S_Object();
				i_tip.ParameterName = "S_TIPOLOGIA";
				i_tip.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
				i_tip.Direction = ParameterDirection.Input;
				i_tip.Size =10;
				i_tip.Index = 3;
				i_tip.Value =  tipologiaManutenzione;
				_Scollection.Add(i_tip);

				S_Controls.Collections.S_Object s_Cursor = new S_Object();
				s_Cursor.ParameterName = "IO_CURSOR";
				s_Cursor.DbType = CustomDBType.Cursor;
				s_Cursor.Direction = ParameterDirection.Output;
				s_Cursor.Index = _Scollection .Count + 2;
				_Scollection.Add(s_Cursor);

	
				_IODB.s_storedProcedureName=GetNomeStrPrd();
				DataSet _MyDataset = _IODB.GetData(_Scollection).Copy();
		
		

				int i = 0;
				for(i=0; i<= _MyDataset.Tables[0].Rows.Count-1;i++)
				{ 
					ds.Tables[0].ImportRow(_MyDataset.Tables[0].Rows[i]);
				}
				if(i==0)
				{
					throw new Exception("* Non ci sono Rdl nell'intervallo temporale che hai selezionato, cambia intervallo e riprova.");
				}
				return ds;
			}
			catch(Exception ex)
			{
				Server.Transfer("Error.aspx?msgErr=" + ex.Message);
				return null;
			}

		}
		private string GetNomeStrPrd()
		{
			try
			{
				_get_NPrcd_Rpt.s_OptBtnDataRichiesta=s_OptBtnDataRichiesta;
				_get_NPrcd_Rpt.s_OptBtnDataAssegnazione=s_OptBtnDataAssegnazione;
				_get_NPrcd_Rpt.s_OptBtnDataChiusura=s_OptBtnDataChiusura;
			
				_get_NPrcd_Rpt.s_OptBtnRdlMese= s_OptBtnRdlMese;
				_get_NPrcd_Rpt.s_OptBtnRdlServizioMesi=s_OptBtnRdlServizioMesi;
				_get_NPrcd_Rpt.s_OptBtnRdlStato=s_OptBtnRdlStato;

				_get_NPrcd_Rpt.s_OptBtnRdlDitta=s_OptBtnRdlDitta;
				_get_NPrcd_Rpt.s_OptBtnRdlDittaMesi = s_OptBtnRdlDittaMesi;
				_get_NPrcd_Rpt.s_OptBtnRdlServizio=s_OptBtnRdlServizio;

				return _get_NPrcd_Rpt.NameStoredProcedure;
			}
			catch(Exception ex)
			{
				Server.Transfer("Error.aspx?msgErr=" + ex.Message + " *Andrea: Durante la fase di recupero del nome della procedura");
				return null;
			}
		}
	}
		
}

		
