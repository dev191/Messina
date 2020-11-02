using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Mobile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient; 

namespace TheSite.AslMobile
{
	/// <summary>
	/// Descrizione di riepilogo per DettProcedurePassi.
	/// </summary>
	public class DettProcedurePassi : System.Web.UI.MobileControls.MobilePage
	{
		protected System.Web.UI.MobileControls.Panel Panel1;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific1;
		protected System.Web.UI.MobileControls.Form Form1;
		protected string PMP = "";
		private		DataGrid	 DataGridRicerca;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!Page.IsPostBack)
			{
			//	_SiteModule.GetSetting();							
			//	FunId = _SiteModule.ModuleId;
			//	HelpLink = _SiteModule.HelpLink;	
			//	GridTitle1.hplsNuovo.Visible = false;
				PMP = Request.Params["pmp"];
			//	lblpmp.Text= "Passi per procedura: " + Request.Params["pmp_id"];
				GetDataGrid();
			}
		}
		protected void OnIndietro(object sender, System.EventArgs e)
		{

		}
		private void GetDataGrid()
		{
			TheSite.AslMobile.Class.ClassProcAndSteps _ProcAndSteps = new TheSite.AslMobile.Class.ClassProcAndSteps();

			OracleParameterCollection Coll= new OracleParameterCollection();

			OracleParameter s_ID = new OracleParameter();
			s_ID.ParameterName = "p_ID_pmp";
			s_ID.OracleType = OracleType.Int32;
			s_ID.Direction = ParameterDirection.Input;
			s_ID.Value = PMP ;			
			s_ID.Size = 50;

			Coll.Add(s_ID);

			DataSet _MyDs = _ProcAndSteps.GetDataDett(Coll);

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();
			
			//this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();	
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
			this.DataGridRicerca = (DataGrid)Panel1.Controls[0].FindControl("Datagrid2");

			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
