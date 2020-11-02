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

namespace TheSite.ManutenzioneCorretiva
{
	/// <summary>
	/// Descrizione di riepilogo per VisualizzaRdl.
	/// </summary>
	public class VisualizzaRdl : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected WebControls.PageTitle PageTitle1;

		int FunId = 0;
		protected System.Web.UI.WebControls.Label lblOperatore;
		protected System.Web.UI.WebControls.Label lblData;
		protected System.Web.UI.WebControls.Label lblOra;
		protected System.Web.UI.WebControls.Label lblRichiedente;
		protected System.Web.UI.WebControls.Label lblGruppo;
		protected System.Web.UI.WebControls.Label lblTelefono;
		protected System.Web.UI.WebControls.Label lblNota;
		protected System.Web.UI.WebControls.Label lblCodiceEdificio;
		protected System.Web.UI.WebControls.Label lblIndirizzo;
		protected System.Web.UI.WebControls.Label lblComune;
		protected System.Web.UI.WebControls.Label lblDenominazione;
		protected System.Web.UI.WebControls.Label lblDitta;
		protected System.Web.UI.WebControls.Label lblServizio;
		protected System.Web.UI.WebControls.Label lblUrgenza;
		protected System.Web.UI.WebControls.Label lblDescrizione;
		protected System.Web.UI.WebControls.Label lblEqStd;
		protected System.Web.UI.WebControls.Label lblEqId;
		protected S_Controls.S_Button btnsNuova;
		protected S_Controls.S_Button cmdApprova;
		protected System.Web.UI.WebControls.TextBox txtWrHidden;
		protected System.Web.UI.WebControls.Label lblteleric;
		protected System.Web.UI.WebControls.Label lblemailric;
		protected System.Web.UI.WebControls.Label lblstanzaric;
		protected System.Web.UI.WebControls.Label lblpianoed;
		protected System.Web.UI.WebControls.Label lblstanzaed;
		protected System.Web.UI.WebControls.Label lblTelefonoDitta;
		protected S_Controls.S_Button btnModificaRDL;
		int itemId = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			FunId = Int32.Parse(Request.Params["FunId"]);
			if (Request.QueryString["chiamante"]=="Materiali")
			{
				btnModificaRDL.Visible=false;
				btnsNuova.Visible=false;
				cmdApprova.Visible=false;
				PageTitle1.VisibleLogut=false;
			}
			if (Request.Params["ItemId"] != null)
			{
				itemId = Int32.Parse(Request.Params["ItemId"]);
				PageTitle1.Title = "Inserimento Richiesta di Lavoro N° " + itemId ;
				txtWrHidden.Text= itemId.ToString();

				Classi.ManOrdinaria.Richiesta _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();					

				DataSet _MyDs = _Richiesta.GetSingleData(itemId).Copy();
					
				if (_MyDs.Tables[0].Rows.Count == 1)
				{
					DataRow _Dr = _MyDs.Tables[0].Rows[0];
					DateTime d_DateRequested = (DateTime) _Dr["DATE_REQUESTED"];
					this.lblData.Text = d_DateRequested.ToShortDateString();
					DateTime d_TimeRequested = (DateTime) _Dr["TIME_REQUESTED"];
					this.lblOra.Text = d_TimeRequested.ToShortTimeString();
					this.lblCodiceEdificio.Text = _Dr["BL_ID"].ToString();
					
					if (_Dr["DENOMINAZIONE"] != DBNull.Value)
						this.lblDenominazione.Text = _Dr["DENOMINAZIONE"].ToString();
					if (_Dr["PIANO"] != DBNull.Value)
						this.lblpianoed.Text =  _Dr["PIANO"].ToString();
					if (_Dr["STANZA"] != DBNull.Value)
						this.lblstanzaed.Text = _Dr["STANZA"].ToString();
					
					if (_Dr["INDIRIZZO"] != DBNull.Value)
						this.lblIndirizzo.Text = _Dr["INDIRIZZO"].ToString();
					if (_Dr["COMUNE"] != DBNull.Value)
						this.lblComune.Text = _Dr["COMUNE"].ToString();
					if (_Dr["descrizione_ditta"] != DBNull.Value)
						this.lblDitta.Text =  _Dr["descrizione_ditta"].ToString();
					if (_Dr["TELEFONO_DITTA"] != DBNull.Value)
						this.lblTelefonoDitta.Text =  _Dr["TELEFONO_DITTA"].ToString();

					if (_Dr["USERNAME"] != DBNull.Value)
						this.lblOperatore.Text = _Dr["USERNAME"].ToString();
					if (_Dr["REQUESTOR"] != DBNull.Value)
						this.lblRichiedente.Text =  _Dr["REQUESTOR"].ToString();
				
					if (_Dr["telefonoric"] != DBNull.Value)
						this.lblteleric.Text = _Dr["telefonoric"].ToString();
					if (_Dr["emailric"] != DBNull.Value)
						this.lblemailric.Text = _Dr["emailric"].ToString();
					if (_Dr["stanzaric"] != DBNull.Value)
						this.lblstanzaric.Text = _Dr["stanzaric"].ToString();
					
					if (_Dr["PHONE"] != DBNull.Value)
						this.lblTelefono.Text =  _Dr["PHONE"].ToString();
					if (_Dr["DESCRIZIONERICHIEDENTI"] != DBNull.Value)
						this.lblGruppo.Text = _Dr["DESCRIZIONERICHIEDENTI"].ToString();
				
					string s_Nota = string.Empty;
					if (_Dr["NOTA_RIC"] != DBNull.Value)
						s_Nota = _Dr["NOTA_RIC"].ToString();

					this.lblNota.Text = s_Nota.Replace("\n", "<br>");
					
					string s_Descrizione = string.Empty;
					if (_Dr["DESCRIPTION"] != DBNull.Value)
						s_Descrizione =  _Dr["DESCRIPTION"].ToString();

					this.lblDescrizione.Text = s_Descrizione.Replace("\n", "<br>");
					
					if (_Dr["PRIORITY"] != DBNull.Value)
						this.lblUrgenza.Text =  _Dr["PRIORITY"].ToString();
					if (_Dr["DESCRIZIONESERVIZI"] != DBNull.Value)
						this.lblServizio.Text = _Dr["DESCRIZIONESERVIZI"].ToString();	
				
					string s_Eqstd = string.Empty;
					if (_Dr["EQ_STD"] != DBNull.Value)
						s_Eqstd =  _Dr["EQ_STD"].ToString();
					if (_Dr["DESCRIZIONEEQSTD"] != DBNull.Value)
						s_Eqstd += " " + _Dr["DESCRIZIONEEQSTD"].ToString();
					this.lblEqStd.Text = s_Eqstd;
					
					if (_Dr["EQ_ID"] != DBNull.Value)
						this.lblEqId.Text = _Dr["EQ_ID"].ToString();

				}					
			}
			else
				PageTitle1.Title = "Inserimento Richiesta di Lavoro - Impossibile visualizzare la Richiesta";
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
			this.btnsNuova.Click += new System.EventHandler(this.btnsNuova_Click);
			this.cmdApprova.Click += new System.EventHandler(this.cmdApprova_Click);
			this.btnModificaRDL.Click += new System.EventHandler(this.btnModificaRDL_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsNuova_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("CreazioneRdl.aspx?FunId=" + FunId);
		}

		private void cmdApprova_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("EditApprovaEmetti.aspx?wr_id=" + txtWrHidden.Text);			
		}

		private void btnModificaRDL_Click(object sender, System.EventArgs e)
		{
		Response.Redirect("ModificaRdl.aspx?ItemId=" + txtWrHidden.Text);			
		}		
	}
}
