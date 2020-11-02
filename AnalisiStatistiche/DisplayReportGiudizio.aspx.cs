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
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using TheSite.Classi.AnalisiStatistiche;
using TheSite.Report;
using System.Configuration;
namespace TheSite.AnalisiStatistiche
{
	
	/// <summary>
	/// Descrizione di riepilogo per DysplayReport.
	/// </summary>
	/// 		
	public class DysplayReportGiudizio : System.Web.UI.Page    // System.Web.UI.Page
	{			
		protected CrystalReportViewer rptEngineOra;
		private ReportDocument crReportDocument;
		private ExportOptions crExportOptions;
		private DiskFileDestinationOptions crDiskFileDestinationOptions;
		private string s_DataPkInit, s_DataPkEnd, s_optbtnGiudizio, s_optbtnGiudizioTipologia;
		private string  s_optbtnGiudizioMesi, s_cmbServizio, tipoDocumento;
		private Recupera_SPRpt_ReportGiudizio _stdRpt = new Recupera_SPRpt_ReportGiudizio();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			 
			s_DataPkInit               = Request["DataPkInit"];
			s_DataPkEnd                = Request["DataPkEnd"];
			s_optbtnGiudizio           = Request["S_optbtnGiudizio"];
			s_optbtnGiudizioTipologia  = Request["S_optbtnGiudizioTipologia"];
			s_optbtnGiudizioMesi       = Request["S_optbtnGiudizioMesi"];
			s_cmbServizio              = Request["cmbServizio"];
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
			Classi.AnalisiStatistiche.wrapDb _IODB = new TheSite.Classi.AnalisiStatistiche.wrapDb();
			S_ControlsCollection _Scollection = new S_ControlsCollection();
			int cntParametri=0;
		try{
				S_Object pDataInit  = new S_Object();
				pDataInit.ParameterName = "p_date_init";
				pDataInit.DbType = CustomDBType.VarChar;
				pDataInit.Direction = ParameterDirection.Input;
				pDataInit.Size =10;
				pDataInit.Index = cntParametri++;
				pDataInit.Value = s_DataPkInit;
				_Scollection.Add(pDataInit);

				S_Object pDataEnd  = new S_Object();
				pDataEnd.ParameterName = "p_date_out";
				pDataEnd.DbType = CustomDBType.VarChar;
				pDataEnd.Direction = ParameterDirection.Input;
				pDataEnd.Size =10;
				pDataEnd.Index = cntParametri++;
				pDataEnd.Value = s_DataPkEnd;
				_Scollection.Add(pDataEnd);

				S_Object pServizio  = new S_Object();
				pServizio.ParameterName = "p_idservizio";
				pServizio.DbType = CustomDBType.Integer;
				pServizio.Direction = ParameterDirection.Input;
				pServizio.Size =10;
				pServizio.Index = cntParametri++;
				pServizio.Value =  Convert.ToInt32(s_cmbServizio);
				_Scollection.Add(pServizio);

				S_Object pCursor = new S_Object();
				pCursor.ParameterName = "io_cursor";
				pCursor.DbType = CustomDBType.Cursor;
				pCursor.Direction = ParameterDirection.Output;
				pCursor.Index = cntParametri++;
				_Scollection.Add(pCursor);

			}
			catch(Exception ex)
			{
			Server.Transfer("Error.aspx?msgErr="+ex.Message + " *Andrea: Nella sezione dell passagio degli S_control al datalayer");
			}

		try
			{
				_IODB.s_storedProcedureName=  GetNomeStrPrd();//"PACK_ANALISI_STATISTICHE.get_giudizio_servizio";//GetNomeStrPrd();
				DataSet _MyDataset = _IODB.GetData(_Scollection).Copy();
				bindReport(_MyDataset);
			}
			catch(Exception ex)
			{
				Server.Transfer("Error.aspx?msgErr="+ex.Message + " *Andrea: Durante ilrecupero del dataset dal datalayer");
			}
		}	
		private void bindReport(DataSet _dsRpt)
		{			
			try
			{
				DsAnalisiStatistiche dsP = new  DsAnalisiStatistiche();
				int i = 0;
				for(i=0; i<=_dsRpt.Tables[0].Rows.Count-1;i++)
				{ 
					dsP.Tables["tblgiudizio"].ImportRow(_dsRpt.Tables[0].Rows[i]);
				}
				if(i==0)
				{
					throw new Exception("* Non ci sono Rdl nell'intervallo temporale che hai selezionato, cambia intervallo e riprova.");
				}
//				ReportClass _Report;
//				_Report = _stdRpt.getReport;				
//				_Report.SetDataSource(dsP);
				//rptEngineOra.DisplayGroupTree=false;
				//rptEngineOra.DisplayToolbar=true;
				
				//rptEngineOra.ReportSource=_Report;
				string pathRptSource = Server.MapPath(Request.ApplicationPath + ConfigurationSettings.AppSettings["SourceReports"]);
				  _stdRpt.ImpostaSourceReport(crReportDocument,pathRptSource);
				crReportDocument.SetDataSource(dsP);
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
			catch(Exception ex) 
			{
				Server.Transfer("Error.aspx?msgErr=" + ex.Message);			
			}
				
		}
		private string GetNomeStrPrd()
		{
			try
			{
				_stdRpt.s_optbtnGiudizio = s_optbtnGiudizio;
				_stdRpt.s_optbtnGiudizioMesi = s_optbtnGiudizioMesi;
				_stdRpt.s_optbtnGiudizioTipologia = s_optbtnGiudizioTipologia;
				return _stdRpt.NameStoredProcedure;
			}
			catch(Exception ex)
			{
				Server.Transfer("Error.aspx?msgErr=" + ex.Message + " *Andrea: Durante la fase di recupero del nome della procedura");
				return null;
			}
		}
	}
		
}

		
