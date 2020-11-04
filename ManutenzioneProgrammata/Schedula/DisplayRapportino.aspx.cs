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
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using System.Configuration;
using TheSite.Classi.ManProgrammata;

namespace TheSite.ManutenzioneProgrammata.Schedula
{
	/// <summary>
	/// Descrizione di riepilogo per DisplayRapportino.
	/// </summary>
	public class DisplayRapportino : System.Web.UI.Page
	{
		protected CrystalDecisions.Web.CrystalReportViewer CRView;
		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
		protected System.Web.UI.WebControls.TextBox txtHid;
		protected System.Web.UI.WebControls.TextBox txtTipo;
		private ReportDocument crReportDocument;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.DataGrid DataGrid3;
		protected System.Web.UI.WebControls.DataGrid DataGrid4;
		protected System.Web.UI.WebControls.DataGrid DataGrid5;
		protected string Ordini;
		private void Page_Load(object sender, System.EventArgs e)
		{		
			if(!Page.IsPostBack)
			{
				txtHid.Text= Request.QueryString["ODL"];
				txtTipo.Text = Request.QueryString["Display"];
			}
			DisplayReport();
			
		}

		private void DisplayReport()
		{
			if(txtTipo.Text == "DL" || txtTipo.Text == "DC" || txtTipo.Text=="DL2P")
			{
				GeneraReport(txtHid.Text,txtTipo.Text);
			}
			else
			{
				Visualizza();
			}
		}
		private void Visualizza()
		{
			Ordini = txtHid.Text;
			
			string sql = "select * from mp_report_long where WO_ID in (" + Ordini + ")";
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_sql = new S_Controls.Collections.S_Object();
			s_p_sql.ParameterName = "p_sql";
			s_p_sql.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_sql.Direction = ParameterDirection.Input;
			s_p_sql.Size =2000;
			s_p_sql.Index = 0;
			s_p_sql.Value = sql;
			_SCollection.Add(s_p_sql);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SCollection.Add(s_Cursor);

			
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_DYNAMIC_SELECT";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();		
		
			if (txtTipo.Text == "S")
			{
				Report.Report_Short MyReport = new Report.Report_Short();
				MyReport.SetDataSource(_Ds);
				CRView.ReportSource = MyReport;
			}
			else 
			{
				Report.Report_Long MyReport = new Report.Report_Long();
				MyReport.SetDataSource(_Ds);
				CRView.ReportSource = MyReport;
			}
			
		}
		private void GeneraReport(string StringaOdl, string TipoReport)
		{ 
			RptMpDataDinamic DtRpt = new RptMpDataDinamic();
			TheSite.SchemiXSD.DsRptMpLocali ds = new TheSite.SchemiXSD.DsRptMpLocali();
			ds = DtRpt.GetDataRpt(StringaOdl);

			string pathRptSource = Server.MapPath(Request.ApplicationPath + ConfigurationSettings.AppSettings["SourceReports"]);

			switch(TipoReport)
			{
				case "DL":
				{
					crReportDocument.Load(pathRptSource + "RptMpDettagliLocaliLungoDinamico.rpt");
					break;
				}
				case "DC":
				{
					crReportDocument.Load(pathRptSource + "RptMpDettagliLocaliCortoDinamico.rpt");
					break;

				}
				case "DL2P":
				{
					crReportDocument.Load(pathRptSource + "RptMpDettagliLocaliLungo2P.rpt");
					break;
				}
				default:
					throw new Exception();
					
			}
			crReportDocument.SetDataSource(ds);
			CRView.ReportSource = crReportDocument;
			CRView.DataBind();
		

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

		private void DataGrid3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
