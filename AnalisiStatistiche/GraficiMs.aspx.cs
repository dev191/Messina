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
	public class GraficiMs : System.Web.UI.Page	
	{
		protected TheSite.WebControls.PageTitle PageTitleReport;
		protected Csy.WebControls.DataPanel DataPanelRicerca;
		protected WebControls.CalendarPicker DataPkInit;
		protected WebControls.CalendarPicker DataPkEnd;
		protected S_Controls.S_OptionButton S_OptBtnDataRichiesta;
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
		protected System.Web.UI.WebControls.CompareValidator ValidatorDataInit;
		protected System.Web.UI.WebControls.CompareValidator ValidatorDataEnd;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected string urlRpt;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			ValidatorDataInit.ControlToValidate =DataPkInit.ID +":"+ DataPkInit.Datazione.ID;
			ValidatorDataInit.ControlToCompare = DataPkEnd.ID + ":" + DataPkEnd.Datazione.ID;
			ValidatorDataEnd.ControlToValidate = DataPkEnd.ID + ":" + DataPkEnd.Datazione.ID;
			ValidatorDataEnd.ControlToCompare = DataPkInit.ID + ":" + DataPkInit.Datazione.ID;

			if( IsPostBack)
			{
				status = (int)ValidateDate.PostBack;
			}
			
			PageTitleReport.Title="Reports Manutenzione Straordinaria";
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void S_BtnSubmit_Click(object sender, System.EventArgs e)
		{
			DisplayReport();
		}

		private void DisplayReport()
		{	
			DataPanelRicerca.Collapsed=true;
			GenetoreQryStr _obj_QueryStr = new GenetoreQryStr();
			_obj_QueryStr.Add(DataPkInit.Datazione.Text,"DataPkInit");
			_obj_QueryStr.Add(DataPkEnd.Datazione.Text,"DataPkEnd");
			_obj_QueryStr.Add(S_OptBtnDataAssegnazione.Checked,"S_OptBtnDataAssegnazione");
			_obj_QueryStr.Add(S_OptBtnDataChiusura.Checked,"S_OptBtnDataChiusura");
			_obj_QueryStr.Add(S_OptBtnDataRichiesta.Checked,"S_OptBtnDataRichiesta");
			_obj_QueryStr.Add(S_OptBtnRdlDitta.Checked,"S_OptBtnRdlDitta");
			_obj_QueryStr.Add(S_OptBtnRdlDittaMesi.Checked,"S_OptBtnRdlDittaMesi");
			_obj_QueryStr.Add(S_OptBtnRdlMese.Checked,"S_OptBtnRdlMese");
			_obj_QueryStr.Add(S_OptBtnRdlServizio.Checked,"S_OptBtnRdlServizio");
			_obj_QueryStr.Add(S_OptBtnRdlServizioMesi.Checked,"S_OptBtnRdlServizioMesi");
			_obj_QueryStr.Add(S_OptBtnRdlStato.Checked,"S_OptBtnRdlStato");
			urlRpt = "DisplayReport.aspx" + _obj_QueryStr.TotQueryString() +"tipologia=" + "3";

		}
	}

}

