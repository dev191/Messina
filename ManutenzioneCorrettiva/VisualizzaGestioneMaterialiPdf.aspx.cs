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
using TheSite.Classi.ManCorrettiva;
using TheSite.SchemiXSD;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;
namespace TheSite.ManutenzioneCorrettiva
{
	/// <summary>
	/// Summary description for VisualizzaGestioneMaterialiPdf.
	/// </summary>
	public class VisualizzaGestioneMaterialiPdf : System.Web.UI.Page
	{
		protected ReportDocument  crReportDocument;
		private ExportOptions crExportOptions;
		private DiskFileDestinationOptions crDiskFileDestinationOptions;
		private void Page_Load(object sender, System.EventArgs e)
		{
			int WrId=0;
			int IdMateriale=0;
			string DataIniziale="";
			string DataFinale="";
			int Stato=0;
			
			if(Request.QueryString["RDL"].ToString()!="")
				WrId=Convert.ToInt32(Request.QueryString["RDL"].ToString());

		//	if(Request.QueryString["idMat"].ToString()!=null)
				IdMateriale=Convert.ToInt32(Request.QueryString["idMat"].ToString());

			if(Request.QueryString["DataDA"].ToString()!="")
				DataIniziale=Request.QueryString["DataDA"].ToString();

			if(Request.QueryString["DataA"].ToString()!="")
				DataFinale=Request.QueryString["DataA"].ToString();

		//	if(Request.QueryString["Stato"].ToString()!=null)
				Stato=Convert.ToInt32(Request.QueryString["Stato"].ToString());

			GeneraRptPdf(WrId,IdMateriale,DataIniziale,DataFinale,Stato);
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			crReportDocument = new ReportDocument();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void GeneraRptPdf(int WrId,int IdMateriale,string DataIniziale,string DataFinale,int Stato)
		{
			MaterialiWrDb DatiRpt = new MaterialiWrDb(WrId,IdMateriale,Stato,DataIniziale,DataFinale);
			GestioneMateriali ds = DatiRpt.GetTipizzato();

			string pathRptSource = Server.MapPath(Request.ApplicationPath + ConfigurationSettings.AppSettings["SourceReports"]);
			crReportDocument.Load(pathRptSource + "RptGestioneMateriali_V9.rpt");
			crReportDocument.SetDataSource(ds);
			string	Fname = pathRptSource  + Session.SessionID.ToString() + ".pdf" ;
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
		}
	}
}
