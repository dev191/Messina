namespace TheSite.calendar
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descrizione di riepilogo per Calendar.
	/// </summary>
	public class Calendar : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox txtDate;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			string style="<link rel=\"stylesheet\" href=\"../calendar/dhtmlgoodies_calendar.css\" media=\"screen\" />";			string js="<script type=\"text/javascript\" src=\"../calendar/dhtmlgoodies_calendar.js\"></script>";
			if(!this.Page.IsStartupScriptRegistered("pcalen"))
				this.Page.RegisterStartupScript("pcalen", style);
			if(!this.Page.IsStartupScriptRegistered("pjcalen"))
				this.Page.RegisterStartupScript("pjcalen", js);
		}
		public TextBox  Date
		{ 
			get{return txtDate;}
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
