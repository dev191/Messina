namespace TheSite.AslMobile
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.Mobile;
	using System.Web.UI.MobileControls;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descrizione di riepilogo per calendarioUserControl.
	/// </summary>
	public abstract class CalendarioUserControl : System.Web.UI.MobileControls.MobileUserControl
	{
		protected System.Web.UI.MobileControls.Panel Panel1;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific1;

		public System.Web.UI.MobileControls.Label strData;
		private void Page_Load(object sender, System.EventArgs e)
		{
			System.Web.UI.MobileControls.Calendar cal = (System.Web.UI.MobileControls.Calendar)Panel1.Controls[0].FindControl("Calendar1");
			cal.SelectedDates.Clear();

			// Inserire qui il codice utente necessario per inizializzare la pagina.
		}
		protected void Calendar_SelectionChangedDataStart(Object sender, EventArgs e)
		{
			Panel1.Visible = false;
			this.strData.Text = ((System.Web.UI.MobileControls.Calendar)(sender)).SelectedDate.ToShortDateString();
			//			((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblData")).Text = ((System.Web.UI.MobileControls.Calendar)(sender)).SelectedDate.ToShortDateString();
//			Panel1.Visible=true;
//			Panel2.Visible=false;
			
		}

		public void setLabel(System.Web.UI.MobileControls.Label lbl)
		{
			this.strData = lbl;
		}
		public void EnbledCal()
		{
			Panel1.Visible = true;
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

		///		Metodo necessario per il supporto della finestra di progettazione. Non modificare
		///		il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
			Panel1.Visible=false;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
