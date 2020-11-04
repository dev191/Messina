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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using TheSite.Classi.SchedeEq;
using TheSite.SchemiXSD;
using System.IO;
using System.Configuration;

namespace TheSite.ShedeEq
{
	/// <summary>
	/// Descrizione di riepilogo per VisulizzaSchedaEqPdf.
	/// </summary>
	public class VisulizzaSchedaEqPdf : System.Web.UI.Page
	{
		protected ReportDocument  crReportDocument;
		private ExportOptions crExportOptions;
		private DiskFileDestinationOptions crDiskFileDestinationOptions;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			GeneraRptPdf();
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
		private void GeneraRptPdf()
		{
			DatiShcedeEq myDati = new DatiShcedeEq(recuperaEqId());
			NewDataSet ds = myDati.GetDsTipizzato();
			foreach(DataRow dr in ds.Tables["TblGenerale"].Rows)
			{
				if(dr["EQ_IMAGE_EQ_ASSY"] != DBNull.Value)
				{
					if(ControllaFoto(dr["EQ_IMAGE_EQ_ASSY"].ToString()))
					{
						dr["EQ_IMMAGINI_IMMAGINE"] = GetPhoto(dr["EQ_IMAGE_EQ_ASSY"].ToString());
					}
					else
					{
						dr["EQ_IMMAGINI_IMMAGINE"] = GetPhoto("ImmagineNonDisponibile.jpg");
					}
				}
				else
				{
					dr["EQ_IMMAGINI_IMMAGINE"] = GetPhoto("ImmagineNonDisponibile.jpg");
				}
			}
			
			//	ds.WriteXmlSchema(@"c:/tmp/ScmReport.xsd");
			//
			string pathRptSource = Server.MapPath(Request.ApplicationPath + ConfigurationSettings.AppSettings["SourceReports"]);
			crReportDocument.Load(pathRptSource + "RptChedeEq_V9.rpt");
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
		private bool ControllaFoto(string NomePhoto)
		{
			bool ret;
			if(File.Exists(Server.MapPath("../EQImages/" + NomePhoto)))
				ret= true;
			else
				ret= false;
			return ret;
		}
		private  byte[] GetPhoto(string fileName)
		{

			string filePath = Server.MapPath(Request.ApplicationPath + ConfigurationSettings.AppSettings["ImmaginiEq"] + fileName );
			if(File.Exists(filePath))
			{
				FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
				BinaryReader br = new BinaryReader(fs);

				byte[] photo = br.ReadBytes((int)fs.Length);
				br.Close();
				fs.Close();
				return photo;
			}
			else
			{
				byte[] b = new byte[1];
				return b;
			}
		}

		private string recuperaEqId()
		{
			string strEqId=String.Empty;
			if(Session["DatiList"]!=null)
			{
				Hashtable _HS = (Hashtable)Session["DatiList"];
				IDictionaryEnumerator myEnumerator = _HS.GetEnumerator();								
				while (myEnumerator.MoveNext())	
				{
					strEqId += myEnumerator.Value + ",";
				}
					
				strEqId = strEqId.Remove(strEqId.Length-1,1);
				//Session.Remove("DatiList");
			}
			else
			{
				Response.Write("Sessione Vuota");
				Response.End();
			}
			return strEqId;
		}
	}
}
