namespace TheSite.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descrizione di riepilogo per UserOption.
	/// </summary>
	public class UserOption : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox TxtSospesa;
		protected System.Web.UI.WebControls.RadioButtonList RadioButtonList1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
		}

		public RadioButtonList OptChiusaSospesa
		{
			get {return RadioButtonList1;}
		}
	
		public TextBox TxtMotivoSospensione
		{
			get {return TxtSospesa;}
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
