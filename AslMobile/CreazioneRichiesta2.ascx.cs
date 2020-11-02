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
	///		Descrizione di riepilogo per CreazioneRichiesta2.
	/// </summary>
	public abstract class CreazioneRichiesta2 : System.Web.UI.MobileControls.MobileUserControl
	{
		protected System.Web.UI.MobileControls.Label S_Lblordinelavoro;
		protected System.Web.UI.MobileControls.Label lblditta;
		protected System.Web.UI.MobileControls.Label lbladdetto;
		protected System.Web.UI.MobileControls.Label lbltipointervento;
		protected System.Web.UI.MobileControls.Label lblurgenza;
		protected System.Web.UI.MobileControls.Label ldldatap;
		protected System.Web.UI.MobileControls.Label lblorap;
		protected System.Web.UI.MobileControls.Label LblMessaggio;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
		}
		/// <summary>
		/// Imposta i dati di visualizzazione alle label
		/// </summary>
		/// <param name="Dr"></param>
		public void SetData(DataRow _Dr,DataRow _DrStato)
		{
			//WO RDL
			if (_Dr["wo_id"] != DBNull.Value)
				S_Lblordinelavoro.Text =_Dr["wo_id"].ToString();
			else
				S_Lblordinelavoro.Text ="";

			//Ditta Esecutrice (Controllo se ho nella WR il campo ditta valorizzato)
			//descrizione della ditta.	
				
			if (_Dr["descrizioneditta"] != DBNull.Value)
				lblditta.Text =_Dr["descrizioneditta"].ToString();
			else
				lblditta.Text ="";
				
			if (_Dr["addetto"] != DBNull.Value)
				lbladdetto.Text =_Dr["addetto"].ToString();
			else
				lbladdetto.Text ="";
					
			//DATAPIANIFICATA
			string datarich=null;
			if (_Dr["datapianificata"] != DBNull.Value)
			{
				datarich= System.DateTime.Parse(_Dr["datapianificata"].ToString()).ToShortDateString();
				ldldatap.Text =datarich;
			}
			else
				ldldatap.Text ="";
			//ORARIO PIANIFICATO
			string minuti="00";
			string ora="00";
			System.DateTime orarich;
			if (_Dr["datapianificata"] != DBNull.Value)
			{
				orarich= System.DateTime.Parse(_Dr["datapianificata"].ToString());
					
				ora=orarich.Hour.ToString();
				minuti=orarich.Minute.ToString();
				lblorap.Text =ora + ":" + minuti;
			}
			else
				lblorap.Text ="";

			//TIPO INTERVENTO
			if (_Dr["manutenzione"] != DBNull.Value)
				lbltipointervento.Text =_Dr["manutenzione"].ToString();
			else
				lbltipointervento.Text ="";
				
			//PRIORITA'
			if (_Dr["urgenza"] != DBNull.Value)
				lblurgenza.Text =_Dr["urgenza"].ToString();
			else
				lblurgenza.Text ="";

			//STATO DELLA RDL
			if (_DrStato!=null)
			{
				string descrizionestato = _DrStato["descrizione"].ToString();
				LblMessaggio.Text ="Stato della Richiesta di Lavoro : " + descrizionestato + " in data: " + _DrStato["data"];
			}
			else
				LblMessaggio.Text ="";
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
