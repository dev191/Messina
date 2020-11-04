using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace TheSite
{
	/// <summary>
	/// Descrizione di riepilogo per CreazioneTemp.
	/// </summary>
	public class CreazioneTemp : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblProgetto;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvRichiedenteNome;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvRichiedenteCognome;
		protected System.Web.UI.WebControls.Panel PanelRichiedente;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvEdificio;
		protected S_Controls.S_TextBox txtsTelefonoRichiedente;
		protected S_Controls.S_TextBox txtsNota;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected S_Controls.S_ComboBox cmbsPiano;
		protected System.Web.UI.WebControls.LinkButton lkbNonEmesse;
		protected System.Web.UI.WebControls.LinkButton lnkChiudi;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected System.Web.UI.WebControls.Panel pnlShowInfo;
		protected System.Web.UI.WebControls.LinkButton LinkApprovate;
		protected System.Web.UI.WebControls.LinkButton LinkChiudi2;
		protected System.Web.UI.WebControls.DataGrid DatagridEmesse;
		protected System.Web.UI.WebControls.Panel PanelEmesse;
		protected System.Web.UI.WebControls.Button btsCodice;
		protected System.Web.UI.WebControls.TextBox txtBL_ID;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorServ;
		protected S_Controls.S_ComboBox cmbsApparecchiatura;
		protected System.Web.UI.WebControls.Panel PanelServizio;
		protected S_Controls.S_ComboBox cmbsUrgenza;
		protected S_Controls.S_TextBox txtsProblema;
		protected System.Web.UI.WebControls.Panel PanelProblema;
		protected S_Controls.S_ComboBox cmbsTipoIntrevento;
		protected System.Web.UI.WebControls.CheckBox ChkConduzione;
		protected S_Controls.S_ComboBox OraConduzione;
		protected S_Controls.S_ComboBox MinutiConduzione;
		protected S_Controls.S_ComboBox CmbASeguito;
		protected S_Controls.S_TextBox TxtASeguito1;
		protected System.Web.UI.WebControls.CheckBox ChkSopralluogo;
		protected S_Controls.S_TextBox TxtSopralluogo;
		protected S_Controls.S_TextBox TxtASeguito4;
		protected S_Controls.S_TextBox TxtCausa;
		protected S_Controls.S_TextBox TxtGuasto;
		protected System.Web.UI.WebControls.TextBox txtsorain;
		protected System.Web.UI.WebControls.TextBox txtsorainmin;
		protected S_Controls.S_Button btnsSalva;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected S_Controls.S_Button btnsChiudi;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected System.Web.UI.WebControls.DropDownList CmbProgetto;
	
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
	}
}
