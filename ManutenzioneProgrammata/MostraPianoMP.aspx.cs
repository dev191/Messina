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
using CrystalDecisions.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;
using TheSite.SchemiXSD;
using System.Data.OracleClient;

namespace TheSite.ManutenzioneProgrammata
{
	/// <summary>
	/// Summary description for MostraPianoMP.
	/// </summary>
	public class MostraPianoMP : System.Web.UI.Page
	{
		protected CrystalReportViewer crlRptPianoMp;
		protected ReportDocument  crReportDocument;
		private ExportOptions crExportOptions;
		private DiskFileDestinationOptions crDiskFileDestinationOptions;
		private void Page_Load(object sender, System.EventArgs e)
		{
			InpostaReport();
		}
		private void InpostaReport()
		{
			DsPianoMp ds = new DsPianoMp();
			
			OracleConnection cn = new OracleConnection(CnStr);
			OracleCommand cmd = new OracleCommand("PACK_RPT_PIANO_MAN_PROG.GetMainData", cn);
			cmd.CommandType = CommandType.StoredProcedure;

			OracleParameter pAnno = new OracleParameter("pAnno",OracleType.Int32);
			pAnno.Direction = ParameterDirection.Input;
			pAnno.Size = 32;
			pAnno.Value =Anno;
			cmd.Parameters.Add(pAnno);
		
			OracleParameter pMese = new OracleParameter("pMese",OracleType.Int32);
			pMese.Direction = ParameterDirection.Input;
			pMese.Size = 32;
			pMese.Value = Mese;
			cmd.Parameters.Add(pMese);

			OracleParameter pIdBl = new OracleParameter("pIdBl",OracleType.Int32);
			pIdBl.Direction = ParameterDirection.Input;
			pIdBl.Size = 32;
			pIdBl.Value = IdEdificio;
			cmd.Parameters.Add(pIdBl);

			OracleParameter pIdServizio = new OracleParameter("pIdServizio",OracleType.Int32);
			pIdServizio.Direction = ParameterDirection.Input;
			pIdServizio.Size = 32;
			pIdServizio.Value = IdServizio;
			cmd.Parameters.Add(pIdServizio);

			OracleParameter IdClasseElemento = new OracleParameter("IdClasseElemento",OracleType.Int32);
			IdClasseElemento.Direction = ParameterDirection.Input;
			IdClasseElemento.Size = 32;
			IdClasseElemento.Value = IdEqstd;
			cmd.Parameters.Add(IdClasseElemento);

			OracleParameter pCursor = new OracleParameter("pCursor",OracleType.Cursor);
			pCursor.Direction = ParameterDirection.Output;
			cmd.Parameters.Add(pCursor);

			OracleDataAdapter da = new OracleDataAdapter(cmd);
			//DataSet d  = new DataSet();
			da.Fill(ds,"TblMain");

			if (ds.TblMain.Rows.Count <= 0 )
			{
				string QryStr = "?Anno=" + Anno + "&Mese=" + Mese 
					+ "&ID_EDIFICIO=" + IdEdificio 
					+ "&ID_SERVIZIO=" + IdServizio 
					+ "&ID_EQSTD=" + IdEqstd ;
				Server.Transfer("MostraMessaggi.aspx" + QryStr );
			}
			cmd.Parameters.Remove(pAnno);
			cmd.Parameters.Remove(pMese);
			cmd.Parameters.Remove(pIdBl);
			cmd.Parameters.Remove(pIdServizio);
			cmd.Parameters.Remove(IdClasseElemento);
			cmd.CommandText = "PACK_RPT_PIANO_MAN_PROG.GetPassi";
			da.Fill(ds,"TblPassi");

			string pathRptSource = Server.MapPath(Request.ApplicationPath + ConfigurationSettings.AppSettings["SourceReports"]);
			crReportDocument.Load(pathRptSource + "RptPianoMp.rpt");
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

		#region Proprietà interne
		internal int Anno
		{
			get
			{ return Convert.ToInt32(Request["Anno"]);}
		}
		internal int Mese
		{
			get{return Convert.ToInt32(Request["Mese"]);}
		}
		internal int IdEdificio 
		{
		 get {return Convert.ToInt32( Request["ID_EDIFICIO"]);}
		}
		internal int IdServizio
		{
			get
			{ return Convert.ToInt32( Request["ID_SERVIZIO"]); }
		}
		internal int IdEqstd
		{
			get{return Convert.ToInt32( Request["ID_EQSTD"]);}
		}
		internal string CnStr
		{
		 get { return System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];}
		}
		#endregion
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.crReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			// 
			// crReportDocument
			// 
			this.crReportDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;
			this.crReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
			this.crReportDocument.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper;
			this.crReportDocument.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Default;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
	}
}
