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
	public class GraficiGiudizio : System.Web.UI.Page	
	{
		protected TheSite.WebControls.PageTitle PageTitleReport;
		protected Csy.WebControls.DataPanel DataPanelRicerca;
		protected S_Controls.S_Button S_BtnSubmit;
		protected string VarDataInit,VarDataEnd,urlRpt;
		protected int status; 
		private enum ValidateDate {notPostBack,PostBack};		


		protected WebControls.CalendarPicker  DataPkEnd;
		protected WebControls.CalendarPicker DataPkInit;
		protected System.Web.UI.WebControls.CompareValidator ValidatorDataInit;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;

		protected System.Web.UI.WebControls.Label lblServizio;
		protected System.Web.UI.WebControls.DropDownList cmbServizio;
		protected S_Controls.S_OptionButton S_optbtnGiudizio;
		protected S_Controls.S_OptionButton S_optbtnGiudizioTipologia;
		protected S_Controls.S_OptionButton S_optbtnGiudizioMesi;
		protected System.Web.UI.WebControls.Button btnReportPdf;		
		protected System.Web.UI.WebControls.CompareValidator ValidatorDataEnd;
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
			
			PageTitleReport.Title="Reports Giudizio Cliente";
			
			if(!IsPostBack)
			{
				bindCombo bndCmd = new bindCombo("PACK_ANALISI_STATISTICHE.bind_servizi",cmbServizio,"System.Int32");
				bndCmd.testoItemZero ="Tutti i Servizi";
				bndCmd.getComboBox();
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
			_obj_QueryStr.Add(S_optbtnGiudizio.Checked,"S_optbtnGiudizio");
			_obj_QueryStr.Add(S_optbtnGiudizioTipologia.Checked,"S_optbtnGiudizioTipologia");			
			_obj_QueryStr.Add(S_optbtnGiudizioMesi.Checked,"S_optbtnGiudizioMesi");
			_obj_QueryStr.Add(cmbServizio.SelectedValue,"cmbServizio");						
			return _obj_QueryStr.TotQueryString().ToString();
		}
		private void DisplayReport()
		{	
			DataPanelRicerca.Collapsed=true;
			urlRpt = "DisplayReportGiudizio.aspx" + queryString() + "tipoDocumento=HTML";;
		}

		private void btnReportPdf_Click(object sender, System.EventArgs e)
		{
			string qryStr = queryString();
			Server.Transfer( "DisplayReportGiudizio.aspx" + qryStr + "tipoDocumento=PDF");
		}
	}

}
