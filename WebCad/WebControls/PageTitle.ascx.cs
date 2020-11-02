namespace WebCad.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descrizione di riepilogo per PageTitle.
	/// </summary>
	public class PageTitle : System.Web.UI.UserControl
	{
		private string _Title = string.Empty;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanMainTitle;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanTitle;
		protected System.Web.UI.WebControls.HyperLink   lblHome;
		protected System.Web.UI.WebControls.Label lblOperatore;
		protected System.Web.UI.HtmlControls.HtmlAnchor logoutlinnk;
		protected System.Web.UI.WebControls.PlaceHolder PlaceHolder1;
		private string _MainTitle = System.Configuration.ConfigurationSettings.AppSettings["ApplicationName"];
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.spanMainTitle.InnerText = this.MainTitle;
			this.spanTitle.InnerText = this.Title;
			if (HttpContext.Current.User.Identity.Name != null)
				this.lblOperatore.Text = "Operatore <b>" + HttpContext.Current.User.Identity.Name + "</b>";

			    this.lblHome.Text="<b> Home Page </b>";  
				this.lblHome.NavigateUrl="..\\MainContent.aspx";
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

		public string MainTitle
		{
			get {return _MainTitle;}
			set {_MainTitle = value;}
		}

		public string Title
		{
			get {return _Title;}
			set {_Title = value;}
		}

		/// <summary>
		/// Property per visualizzare il logout e il nome dell'utente loggato
		/// </summary>
		public bool VisibleLogut
		{
		
			get {
				return PlaceHolder1.Visible;
				
				}
			set {
				PlaceHolder1.Visible = value;
				}
		}
	}
}
