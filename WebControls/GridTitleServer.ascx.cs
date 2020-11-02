namespace TheSite.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	public delegate void NuovoRec(string Cod);

	/// <summary>
	///		Descrizione di riepilogo per GridTitleServer.
	/// </summary>
	public class GridTitleServer : System.Web.UI.UserControl
	{
		public System.Web.UI.WebControls.LinkButton hplsNuovo;
		public System.Web.UI.WebControls.Label lblRecord;
		private string s_NumRecords;
	

        public NuovoRec NuovoRec1;

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
			this.hplsNuovo.Click += new System.EventHandler(this.hplsNuovo_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void hplsNuovo_Click(object sender, System.EventArgs e)
		{
			// Controllo che sia stata assegnata una funzione.
			if (NuovoRec1!=null) 
				NuovoRec1("");
		}
	
		public string NumeroRecords
		{
			get {return s_NumRecords;}
			set 
			{
				s_NumRecords = value;
				lblRecord.Text = s_NumRecords;
			}
		}

	
	}
}
