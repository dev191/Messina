namespace WebCad.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descrizione di riepilogo per GridTitle.
	/// </summary>
	public class GridTitle : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblRecord;
		public S_Controls.S_HyperLink hplsNuovo;
		private string s_NumRecords;
		protected S_Controls.S_Label lblDescrRecord;
		protected S_Controls.S_Label lblTitleDescription;
		private string s_NuovoUrl;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
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

		public string NumeroRecords
		{
			get {return s_NumRecords;}
			set 
			{
				s_NumRecords = value;
				lblRecord.Text = s_NumRecords;
			}
		}
		/// <summary>
		/// Ottiene imposta il testo della Label Centrale per eventuali descrizioni
		/// nella Title.
		/// </summary>
		public string DescriptionTitle
		{
			get
			{return lblTitleDescription.Text;
			}
			set
			{lblTitleDescription.Text=value;
			}
		}
		public string NuovoUrl
		{
			get {return s_NuovoUrl;}
			set 
			{
				s_NuovoUrl = value;
				hplsNuovo.NavigateUrl = s_NuovoUrl;
			}
		}
		/// <summary>
		/// Ottiene Imposta la visibilità delle label con 
		/// la scritta "Record" e la la bel che continiene il Count dei record
		/// </summary>
		public bool VisibleRecord
		{
			get
			{return lblRecord.Visible;
			}
			set
			{
				lblDescrRecord.Visible =value;
				lblRecord.Visible =value;
			}
		}
	}
}
