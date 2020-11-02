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
	///		Descrizione di riepilogo per CreazioneRichiesta3.
	/// </summary>
	public abstract class CreazioneRichiesta3 : System.Web.UI.MobileControls.MobileUserControl
	{
		protected System.Web.UI.MobileControls.Label lblsospesa;
		protected System.Web.UI.MobileControls.Label lblDataInizio;
		protected System.Web.UI.MobileControls.Label lblDataFine;
		protected System.Web.UI.MobileControls.Label lblAnnotazioni;
		protected System.Web.UI.MobileControls.Label lblstato;

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
			//in base allo status visualizzo la riga html
			if (_Dr["stato_descrizione_estesa"] != DBNull.Value)
		       lblstato.Text=_Dr["stato_descrizione_estesa"].ToString(); 
			else
			    lblstato.Text=""; 

			//nota Sospesa
			if (_Dr["notesospesa"] != DBNull.Value)
				lblsospesa.Text = _Dr["notesospesa"].ToString();
			else
				lblsospesa.Text ="";
		
			if (_Dr["comments"] != DBNull.Value)
				lblAnnotazioni.Text= _Dr["comments"].ToString();
			else
				lblAnnotazioni.Text="";

			if (_Dr["date_start"]!=DBNull.Value)
				 lblDataInizio.Text = System.DateTime.Parse(_Dr["date_start"].ToString()).ToLongDateString();
			else
				lblDataInizio.Text ="";
	
			if (_Dr["date_end"]!=DBNull.Value)
				lblDataFine.Text = System.DateTime.Parse(_Dr["date_end"].ToString()).ToLongDateString();
			else
				lblDataFine.Text ="";
				

//			if (_Dr["date_start"]!=DBNull.Value)
//			{
//				System.DateTime OraIni= System.DateTime.Parse(_Dr["date_start"].ToString());
//				SetValue(Panel4,"txtOraStart",OraIni.Hour.ToString().PadLeft(2,Convert.ToChar("0")));
//				SetValue(Panel4,"txtMinutiStart",OraIni.Minute.ToString().PadLeft(2,Convert.ToChar("0")));
//			}
//			if (_Dr["date_end"]!=DBNull.Value)
//			{
//				System.DateTime OraFine= System.DateTime.Parse(_Dr["date_end"].ToString());      
//				SetValue(Panel4,"txtOraEnd",OraFine.Hour.ToString().PadLeft(2,Convert.ToChar("0"))) ;
//				SetValue(Panel4,"txtMinutiEnd",OraFine.Minute.ToString().PadLeft(2,Convert.ToChar("0")));
//			}
			
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
