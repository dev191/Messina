namespace TheSite.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descrizione di riepilogo per Fascicolo.
	/// </summary>
	public class Fascicolo : System.Web.UI.UserControl
	{
		protected S_Controls.S_TextBox txtfascicolo;
		public string idTextRicFas=string.Empty;
		public string idModuloFas=string.Empty;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			Classi.SiteJavaScript.ShowFrameFascicolo(Page,1);
			idTextRicFas=txtfascicolo.ClientID;
			idModuloFas=this.ClientID;
		}
		public S_Controls.S_TextBox TxtFascicolo
		{
			get {return txtfascicolo;}
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
