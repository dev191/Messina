using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Mobile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace TheSite.AslMobile
{
	/// <summary>
	/// Descrizione di riepilogo per VisualRdl.
	/// </summary>
	public class VisualRdl : System.Web.UI.MobileControls.MobilePage
	{
		protected System.Web.UI.MobileControls.Panel Panel1;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific1;
		protected System.Web.UI.MobileControls.Form Form1;

		private		int itemId = 0;
//		private		WebControls.PageTitle PageTitle1;
//		private		System.Web.UI.WebControls.TextBox txtWrHidden;

		private System.Web.UI.MobileControls.Label p_lblOperatore;
		private System.Web.UI.MobileControls.Label p_lblData;
		private System.Web.UI.MobileControls.Label p_lblOra;
		private System.Web.UI.MobileControls.Label p_lblRichiedente;
		private System.Web.UI.MobileControls.Label p_lblGruppo;
		private System.Web.UI.MobileControls.Label p_lblTelefono;
		private System.Web.UI.MobileControls.Label p_lblNota;
		private System.Web.UI.MobileControls.Label p_lblCodiceEdificio;
		private System.Web.UI.MobileControls.Label p_lblDenominazione;
		private System.Web.UI.MobileControls.Label p_lblDescrizione;
		private System.Web.UI.MobileControls.Label p_lblUrgenza;
		private System.Web.UI.MobileControls.Label p_lblServizio;
		private System.Web.UI.MobileControls.Label p_lblEqStd;
		private System.Web.UI.MobileControls.Label p_lblEqId;
		private System.Web.UI.MobileControls.Label p_lblRDL;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if (Request.Params["ItemId"] != null)
			{
				this.p_lblOperatore = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblOperatore"));
				this.p_lblData = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblData")); 
				this.p_lblOra = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblOra"));
				this.p_lblRichiedente = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblRichedente"));  
				this.p_lblGruppo = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblGruppo"));
				this.p_lblTelefono = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblTelefono")); 
				this.p_lblNota = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblNota"));
				this.p_lblCodiceEdificio = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblCodEdificio")); 
				this.p_lblDenominazione = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblDenominazione"));
				this.p_lblDescrizione = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblDescrizione")); 
				this.p_lblUrgenza = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblUrgenza"));
				this.p_lblServizio = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblServizio")); 
				this.p_lblEqStd = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblStdApparacchiatura"));
				this.p_lblEqId = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblApparacchiatura"));
				this.p_lblRDL = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblRDL"));
				
				this.p_lblRDL.Text= Request.Params["ItemId"];


				itemId = Int32.Parse(Request.Params["ItemId"]);
				//itemId = 202;//Int32.Parse("162");
				//				PageTitle1.Title = "Inserimento Richiesta di Lavoro N° " + itemId ;
				//				txtWrHidden.Text= itemId.ToString();

				Class.ClassRichiesta _Richiesta = new Class.ClassRichiesta(Context.User.Identity.Name);

				DataSet _MyDs = _Richiesta.GetSingleData(itemId).Copy();
					
				if (_MyDs.Tables[0].Rows.Count == 1)
				{
					DataRow _Dr = _MyDs.Tables[0].Rows[0];
					DateTime d_DateRequested = (DateTime) _Dr["DATE_REQUESTED"];
					this.p_lblData.Text = d_DateRequested.ToShortDateString();
					DateTime d_TimeRequested = (DateTime) _Dr["TIME_REQUESTED"];
					this.p_lblOra.Text = d_TimeRequested.ToShortTimeString();
					this.p_lblCodiceEdificio.Text = (string)_Dr["BL_ID"];
					if (_Dr["DENOMINAZIONE"] != DBNull.Value)
						this.p_lblDenominazione.Text = (string) _Dr["DENOMINAZIONE"];

					if (_Dr["USERNAME"] != DBNull.Value)
						this.p_lblOperatore.Text = (string) _Dr["USERNAME"];
					if (_Dr["REQUESTOR"] != DBNull.Value)
						this.p_lblRichiedente.Text = (string) _Dr["REQUESTOR"];
					if (_Dr["PHONE"] != DBNull.Value)
						this.p_lblTelefono.Text = (string) _Dr["PHONE"];
					if (_Dr["DESCRIZIONERICHIEDENTI"] != DBNull.Value)
						this.p_lblGruppo.Text = (string) _Dr["DESCRIZIONERICHIEDENTI"];
					
					string s_Nota = string.Empty;
					if (_Dr["NOTA_RIC"] != DBNull.Value)
						s_Nota = (string) _Dr["NOTA_RIC"];

					this.p_lblNota.Text = s_Nota.Replace("\n", "<br>");
					
					string s_Descrizione = string.Empty;
					if (_Dr["DESCRIPTION"] != DBNull.Value)
						s_Descrizione = (string) _Dr["DESCRIPTION"];

					this.p_lblDescrizione.Text = s_Descrizione.Replace("\n", "<br>");
					
					if (_Dr["PRIORITY"] != DBNull.Value)
						this.p_lblUrgenza.Text = (string) _Dr["PRIORITY"];
					if (_Dr["DESCRIZIONESERVIZI"] != DBNull.Value)
						this.p_lblServizio.Text = (string) _Dr["DESCRIZIONESERVIZI"];	
				
					string s_Eqstd = string.Empty;
					if (_Dr["EQ_STD"] != DBNull.Value)
						s_Eqstd = (string) _Dr["EQ_STD"];
					if (_Dr["DESCRIZIONEEQSTD"] != DBNull.Value)
						s_Eqstd += " " + (string) _Dr["DESCRIZIONEEQSTD"];
					this.p_lblEqStd.Text = s_Eqstd;
					
					if (_Dr["EQ_ID"] != DBNull.Value)
						this.p_lblEqId.Text = (string) _Dr["EQ_ID"];

				}					
			}
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
