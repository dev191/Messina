namespace TheSite.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descrizione di riepilogo per Matricole.
	/// </summary>
	public class Matricole : System.Web.UI.UserControl
	{
		protected S_Controls.S_TextBox txtmatricola;
		protected S_Controls.S_Button S_btricerca;
        public string idTextRicMat=string.Empty;
		public string idModuloMat=string.Empty;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			
			Classi.SiteJavaScript.ShowFrameMatricole(Page,1);
			idTextRicMat=txtmatricola.ClientID;
			idModuloMat=this.ClientID;

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
		public S_Controls.S_TextBox Matricola
		{
			get {return txtmatricola;}
	    }

		
	}
}
