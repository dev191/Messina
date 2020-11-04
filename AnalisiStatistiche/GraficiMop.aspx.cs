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
using TheSite.AnalisiStatistiche;
using TheSite.Classi.AnalisiStatistiche;

namespace TheSite.AnalisiStatistiche
{
	/// <summary>
	/// Descrizione di riepilogo per GraficiMop.
	/// </summary>
	public class GraficiMop : System.Web.UI.Page	
	{
		protected TheSite.WebControls.PageTitle PageTitleReport;
		protected Csy.WebControls.DataPanel DataPanelRicerca;
		protected WebControls.CalendarPicker DataPkInit;
		protected WebControls.CalendarPicker DataPkEnd;
		protected S_Controls.S_OptionButton S_OptBtnDataAssegnazione;
		protected S_Controls.S_OptionButton S_OptBtnDataChiusura;
		protected S_Controls.S_OptionButton S_OptBtnRdlMese;
		protected S_Controls.S_OptionButton S_OptBtnRdlServizioMesi;
		protected S_Controls.S_OptionButton S_OptBtnRdlStato;
		protected S_Controls.S_OptionButton S_OptBtnRdlDitta;
		protected S_Controls.S_OptionButton S_OptBtnRdlDittaMesi;
		protected S_Controls.S_OptionButton S_OptBtnRdlServizio;
		protected S_Controls.S_Button S_BtnSubmit;
		protected string VarDataInit,VarDataEnd;
		protected int status; 
		private enum ValidateDate {notPostBack,PostBack};
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.CompareValidator ValidatorDataInit;
		protected System.Web.UI.WebControls.CompareValidator ValidatorDataEnd;
		protected System.Web.UI.WebControls.Button btnReportPdf;
		protected string urlRpt;
		public static string HelpLink = string.Empty;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			HelpLink = _SiteModule.HelpLink;
			ValidatorDataInit.ControlToValidate =DataPkInit.ID +":"+ DataPkInit.Datazione.ID;
			ValidatorDataInit.ControlToCompare = DataPkEnd.ID + ":" + DataPkEnd.Datazione.ID;
			ValidatorDataEnd.ControlToValidate = DataPkEnd.ID + ":" + DataPkEnd.Datazione.ID;
			ValidatorDataEnd.ControlToCompare = DataPkInit.ID + ":" + DataPkInit.Datazione.ID;

			if( IsPostBack)
			{
				status = (int)ValidateDate.PostBack;
			}
			PageTitleReport.Title="Reports Manutenzione Programmata";
			if(!IsPostBack)
			{
				urlRpt="about:blank";
				status=(int)ValidateDate.notPostBack;
				VarDataInit="01/01/" + System.DateTime.Today.ToString().Substring(6,4);
				VarDataEnd=System.DateTime.Today.ToString().Substring(0,10);
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
			this.S_BtnSubmit.Click += new System.EventHandler(this.S_BtnSubmit_Click);
			this.btnReportPdf.Click += new System.EventHandler(this.btnReportPdf_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		

		private void S_BtnSubmit_Click(object sender, System.EventArgs e)
		{
			DisplayReport();
		}
		private string queryString()
		{
			GenetoreQryStr _obj_QueryStr = new GenetoreQryStr();
			_obj_QueryStr.Add(DataPkInit.Datazione.Text,"DataPkInit");
			_obj_QueryStr.Add(DataPkEnd.Datazione.Text,"DataPkEnd");
			_obj_QueryStr.Add(S_OptBtnDataAssegnazione.Checked,"S_OptBtnDataAssegnazione");
			_obj_QueryStr.Add(S_OptBtnDataChiusura.Checked,"S_OptBtnDataChiusura");
			_obj_QueryStr.Add(S_OptBtnRdlDitta.Checked,"S_OptBtnRdlDitta");
			_obj_QueryStr.Add(S_OptBtnRdlDittaMesi.Checked,"S_OptBtnRdlDittaMesi");
			_obj_QueryStr.Add(S_OptBtnRdlMese.Checked,"S_OptBtnRdlMese");
			_obj_QueryStr.Add(S_OptBtnRdlServizio.Checked,"S_OptBtnRdlServizio");
			_obj_QueryStr.Add(S_OptBtnRdlServizioMesi.Checked,"S_OptBtnRdlServizioMesi");
			_obj_QueryStr.Add(S_OptBtnRdlStato.Checked,"S_OptBtnRdlStato");
			_obj_QueryStr.Add("2","tipologia");
			return _obj_QueryStr.TotQueryString().ToString();
		}
		private void DisplayReport()
		{	
			DataPanelRicerca.Collapsed=true;
			string Progetto="";
			if(Request["VarApp"]!=null)
				Progetto = "&VarApp=" + Request["VarApp"];
			urlRpt = "DisplayReport.aspx" + queryString()+ "tipoDocumento=HTML" +Progetto ;
		}

		private void btnReportPdf_Click(object sender, System.EventArgs e)
		{
			string qryStr = queryString();
			string Progetto="";
			if(Request["VarApp"]!=null)
				Progetto = "&VarApp=" + Request["VarApp"];
			Server.Transfer( "DisplayReport.aspx" + qryStr + "tipoDocumento=PDF" + Progetto);
		}
	}
}
