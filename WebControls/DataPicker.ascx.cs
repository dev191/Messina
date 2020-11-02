namespace TheSite.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descrizione di riepilogo per DataPicker.
	/// </summary>
	public class DataPicker : System.Web.UI.UserControl
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl PopupDiv;//div
		protected System.Web.UI.HtmlControls.HtmlGenericControl DivShim;//iframe
		protected System.Web.UI.WebControls.Calendar Calendar1;
		protected S_Controls.S_TextBox txtDataPicker;
		public string namecontrol=string.Empty;
		private void Page_Load(object sender, System.EventArgs e)
		{
			namecontrol=this.ClientID;
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
			this.Calendar1.VisibleMonthChanged += new System.Web.UI.WebControls.MonthChangedEventHandler(this.Calendar1_VisibleMonthChanged);
			this.Calendar1.SelectionChanged += new System.EventHandler(this.Calendar1_SelectionChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Calendar1_SelectionChanged(object sender, System.EventArgs e)
		{
			txtDataPicker.Text = Calendar1.SelectedDate.ToShortDateString();
			
		}

		private void Calendar1_VisibleMonthChanged(object sender, System.Web.UI.WebControls.MonthChangedEventArgs e)
		{
//			PopupDiv.Style.Add("display" ,"block");
//			string offsetWidth=PopupDiv.Style["offsetWidth"];
//			DivShim.Style.Add("width",offsetWidth);
//			string offsetHeight=PopupDiv.Style["offsetHeight"];
//			DivShim.Style.Add("height",offsetHeight);
//			string top=PopupDiv.Style["top"];
//			DivShim.Style.Add("top",top);
//			string left=PopupDiv.Style["left"];
//			DivShim.Style.Add("left" ,left);
//			int zIndex=Convert.ToInt32(PopupDiv.Style["zIndex"])-1;
//			DivShim.Style.Add("zIndex" ,zIndex.ToString());
//			DivShim.Style.Add("display" ,"block");
			this.Page.RegisterStartupScript("showcalendario","ShowCalendar2(true);" );
		}


	}
}
