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
	///		Descrizione di riepilogo per CreazioneRichiesta1.
	/// </summary>
	public abstract class CreazioneRichiesta1 : System.Web.UI.MobileControls.MobileUserControl
	{
		protected System.Web.UI.MobileControls.Label LblRdl;
		protected System.Web.UI.MobileControls.Label lblTrasmissione;
		protected System.Web.UI.MobileControls.Label lblRichiedente;
		protected System.Web.UI.MobileControls.Label lblOperatore;
		protected System.Web.UI.MobileControls.Label lblTelefono;
		protected System.Web.UI.MobileControls.Label lblDataRichiesta;
		protected System.Web.UI.MobileControls.Label lblOraRichiesta;
		protected System.Web.UI.MobileControls.Label lblGruppo;
		protected System.Web.UI.MobileControls.Label lblFabriccato;
		protected System.Web.UI.MobileControls.Label lblNote;
		protected System.Web.UI.MobileControls.Label lblServizio;
		protected System.Web.UI.MobileControls.Label lblStandApp;
		protected System.Web.UI.MobileControls.Label lblApp;
		protected System.Web.UI.MobileControls.Label lblDescrizione;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
		}
		/// <summary>
		/// Imposta i dati di visualizzazione alle label
		/// </summary>
		/// <param name="Dr"></param>
		public void SetData(DataRow _Dr)
		{
			//ID RDL
			if (_Dr["id"] != DBNull.Value)
				LblRdl.Text = _Dr["ID"].ToString();				
			else
				LblRdl.Text ="";
			
			if (_Dr["descrizionetrasmissione"] != DBNull.Value)
				lblTrasmissione.Text=_Dr["descrizionetrasmissione"].ToString();
			else
				lblTrasmissione.Text="";

			//RICHIEDENTE
			if (_Dr["richiedente"] != DBNull.Value)
				lblRichiedente.Text = _Dr["richiedente"].ToString();
			else
				lblRichiedente.Text ="";
				
			//OPERATORE
			if (_Dr["operatore"] != DBNull.Value)
				lblOperatore.Text =_Dr["operatore"].ToString();
			else
				lblOperatore.Text ="";

			//TELEFONO
			if (_Dr["telefono"] != DBNull.Value)
				lblTelefono.Text= _Dr["telefono"].ToString();
			else
				lblTelefono.Text="";

			//DATARICHIESTA	
			string datarich=string.Empty;
			if (_Dr["dataRichiesta"] != DBNull.Value)
			{
				datarich= System.DateTime.Parse(_Dr["dataRichiesta"].ToString()).ToShortDateString();
				lblDataRichiesta.Text= datarich;
			}
			else
				lblDataRichiesta.Text="";
			//ORARICHIESTA				
			if (_Dr["dataRichiesta"] != DBNull.Value)
				lblOraRichiesta.Text = System.DateTime.Parse(_Dr["dataRichiesta"].ToString()).ToShortTimeString();
			else
				lblOraRichiesta.Text ="";
			//GRUPPO
			if (_Dr["gruppo"] != DBNull.Value)
				lblGruppo.Text= _Dr["gruppo"].ToString();
			else
				lblGruppo.Text="";
			//FABBRICATO
			if (_Dr["fabbricato"] != DBNull.Value)
				lblFabriccato.Text =_Dr["fabbricato"].ToString();
			else
				lblFabriccato.Text="";
			//NOTA
			if (_Dr["nota"] != DBNull.Value)
				lblNote.Text = _Dr["nota"].ToString();
			else
				lblNote.Text ="";
			//Servizio				
			if (_Dr["servizio_descrizione"] != DBNull.Value)
				lblServizio.Text = _Dr["servizio_descrizione"].ToString();
			else
				lblServizio.Text ="";
				
			if (_Dr["standardapp"] != DBNull.Value)
				lblStandApp.Text =_Dr["standardapp"].ToString();
			else
				lblStandApp.Text ="";
			
			if (_Dr["eq_id"] != DBNull.Value)
				lblApp.Text =_Dr["eq_id"].ToString();
			else
				lblApp.Text ="";
					
			//Descrizione Intervento
			if (_Dr["descrizione"] != DBNull.Value)
				lblDescrizione.Text =_Dr["descrizione"].ToString();
			else
				lblDescrizione.Text ="";

		}
		/// <summary>
		/// Property ritorna il valore dell'RDL nella Label Rdl
		/// </summary>
		public string Rdl
		{
			get{return LblRdl.Text;}
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
