using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;

namespace TheSite.ManutenzioneProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per DettProcedurePassi.
	/// </summary>
	public class DettProcedurePassi : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;
		public static int FunId = 0;
		public static string HelpLink = string.Empty;
		protected System.Web.UI.WebControls.Label lblpmp;		
		protected string PMP = "";
		string descserv="";
		string std="";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];

			if(!Page.IsPostBack)
			{
				_SiteModule.GetSetting();							
				FunId = _SiteModule.ModuleId;
				HelpLink = _SiteModule.HelpLink;	
				GridTitle1.hplsNuovo.Visible = false;
				
				PMP = Request.Params["pmp"];
				descserv= Request.Params["descserv"];
				std=Request.Params["std"];
				lblpmp.Text= "Passi per procedura: " + Request.Params["pmp_id"]+ "   servizio:  "+ descserv +"         Std. Apparecchiatura:  "+std;
				GetDataGrid();
			}
		}
		private void GetDataGrid()
		{
			Classi.ManProgrammata.ProcAndSteps _ProcAndSteps = new TheSite.Classi.ManProgrammata.ProcAndSteps();						
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_ID = new S_Object();
			s_ID.ParameterName = "p_ID_pmp";
			s_ID.DbType = CustomDBType.Integer;
			s_ID.Direction = ParameterDirection.Input;
			s_ID.Index = 0;
			s_ID.Value = PMP ;			
			s_ID.Size = 50;

			_SCollection.Add(s_ID);

			DataSet _MyDs = _ProcAndSteps.GetDataDett(_SCollection).Copy();

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();
			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();	
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
