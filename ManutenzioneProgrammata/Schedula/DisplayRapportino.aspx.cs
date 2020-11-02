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

namespace TheSite.ManutenzioneProgrammata.Schedula
{
	/// <summary>
	/// Descrizione di riepilogo per DisplayRapportino.
	/// </summary>
	public class DisplayRapportino : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected CrystalDecisions.Web.CrystalReportViewer CRView;
		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
		protected System.Web.UI.WebControls.TextBox txtHid;
		protected System.Web.UI.WebControls.TextBox txtTipo;
		protected string Ordini;
	
		private void Page_Load(object sender, System.EventArgs e)
		{		
			if(!Page.IsPostBack)
			{
				txtHid.Text= Request.QueryString["ODL"];
				txtTipo.Text = Request.QueryString["Display"];
			}
			Visualizza();
		}

		private void Visualizza()
		{
			Ordini = txtHid.Text;
			CRView.DisplayGroupTree = false;
			CRView.DisplayToolbar = true;
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

		#region Codice generato da Progettazione Web Form
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: questa chiamata è richiesta da Progettazione Web Form ASP.NET.
			//
			InitializeComponent();
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
	}
}
