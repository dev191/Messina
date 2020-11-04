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
using TheSite.Classi.AnalisiStatistiche;
using TheSite.WebControls;


namespace TheSite.AnalisiStatistiche.chart
{
	/// <summary>
	/// Descrizione di riepilogo per GraficiMop.
	/// </summary>
	public class GraficiLV : System.Web.UI.Page	
	{
		protected TheSite.WebControls.PageTitle PageTitleReport;
		protected Csy.WebControls.DataPanel DataPanelRicerca;
		protected S_Controls.S_Button S_BtnSubmit;
		protected string urlRpt;
		protected int status; 
		private enum ValidateDate {notPostBack,PostBack};
		protected S_Controls.S_OptionButton S_optBtnRdlDispersioneRA;
		protected S_Controls.S_OptionButton S_optBtnRdlDispersioneAC;
		protected System.Web.UI.WebControls.Label lblTipologiaLavori;
		protected System.Web.UI.WebControls.DropDownList cmbTipologiaInitervento;
		protected S_Controls.S_OptionButton S_optBtnRdlDispersioneRC;
        public static string HelpLink = string.Empty;
		
	
		private void Page_Load(object sender, System.EventArgs e)
		{	
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			HelpLink = _SiteModule.HelpLink;
			PageTitleReport.Title="Grafici dei Livelli di Servizio";
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
			this.S_BtnSubmit.Click += new System.EventHandler(this.S_BtnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void S_BtnSubmit_Click(object sender, System.EventArgs e)
		{
			DysplayChart();
		}

		private void DysplayChart()
		{

			//DataPanelRicerca.Collapsed=true;
			GenetoreQryStr _obj_QueryStr = new GenetoreQryStr();
			_obj_QueryStr.Add(S_optBtnRdlDispersioneAC.Checked,"S_optBtnRdlDispersioneAC");
			_obj_QueryStr.Add(S_optBtnRdlDispersioneRA.Checked,"S_optBtnRdlDispersioneRA");
			_obj_QueryStr.Add(S_optBtnRdlDispersioneRC.Checked,"S_optBtnRdlDispersioneRC");
			_obj_QueryStr.Add(cmbTipologiaInitervento.SelectedValue,"tipologia");

			string Progetto="";
			if(Request["VarApp"]!=null)
			{
				Progetto = Request["VarApp"];
				Session["VarApp"] = Progetto ;
			}
				//Progetto = "&VarApp=" + Request["VarApp"];
			urlRpt = "./Chart.aspx" + _obj_QueryStr.TotQueryString() ;

		}


	}

}
