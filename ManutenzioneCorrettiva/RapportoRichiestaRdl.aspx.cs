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
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer.DBType;

namespace TheSite.ManutenzioneCorretiva
{
	/// <summary>
	/// Descrizione di riepilogo per RapportoRichiestaRdl.
	/// </summary>
	public class RapportoRichiestaRdl : System.Web.UI.Page
	{
		protected WebControls.PageTitle PageTitle1;
		protected S_Controls.S_Label lblRdl;
		int FunId = 0;
		protected System.Web.UI.WebControls.TextBox txtWrHidden;
		protected S_Controls.S_Button btApprova;
		protected S_Controls.S_Button btCrea;
		int itemId = 0;

		#region property pubbliche per il binding dei dati
		 public string Ordine;
		 public string DataIni;
		 public string DataEnd;
		 public string Bl_id;
		 public string Comune;
		 public string Indirizzo;
		 public string Ditta;
		 public string NomeEdificio;
		 public string DescrizioneIntervento;
		 public string SpesaPresunta;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(Request.Params["FunId"]!=null)
			  ViewState.Add("FunId", Int32.Parse(Request.Params["FunId"]));

			if(!IsPostBack)
				BindingData();
		}
		
		private void BindingData()
		{
			if(Request.Params["ItemId"]==null)
				return;
			itemId = Int32.Parse(Request.Params["ItemId"]);
	
			txtWrHidden.Text= itemId.ToString();
			PageTitle1.Title = "Inserimento Richiesta di Lavoro N° " + itemId.ToString();
			lblRdl.Text =string.Format("RDL n° {0} del {1}" ,itemId,DateTime.Now.ToShortDateString());
			Classi.ManStraordinaria.Richiesta _Richiesta=new TheSite.Classi.ManStraordinaria.Richiesta();
            DataSet ds=	_Richiesta.GetRapportino(this.itemId);  
			if(ds.Tables[0].Rows.Count >0)
			{
			  DataRow dr=ds.Tables[0].Rows[0];
			  if(dr["ordine_lavoro"]!=DBNull.Value)
			   this.Ordine=dr["ordine_lavoro"].ToString();
			  if(dr["datainizio"]!=DBNull.Value)
				this.DataIni =Convert.ToDateTime(dr["datainizio"]).ToShortDateString(); 
			  if(dr["datafine"]!=DBNull.Value)
			    this.DataEnd =Convert.ToDateTime(dr["datafine"]).ToShortDateString(); 
			  if(dr["bl_id"]!=DBNull.Value)
				this.Bl_id =dr["bl_id"].ToString(); 
			  if(dr["comune"]!=DBNull.Value)
				this.Comune =dr["comune"].ToString(); 
			  if(dr["indirizzo"]!=DBNull.Value)
				this.Indirizzo =dr["indirizzo"].ToString(); 
			  if(dr["descrizione_ditta"]!=DBNull.Value)
				this.Ditta =dr["descrizione_ditta"].ToString(); 
			  if(dr["nome_edificio"]!=DBNull.Value)
				this.NomeEdificio =dr["nome_edificio"].ToString(); 
			  if(dr["spesa_presunta"]!=DBNull.Value)
				this.SpesaPresunta =Double.Parse( dr["spesa_presunta"].ToString()).ToString("C"); 
			  if(dr["descrizione_intervento"]!=DBNull.Value)
				this.DescrizioneIntervento =dr["descrizione_intervento"].ToString(); 
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
			this.btApprova.Click += new System.EventHandler(this.btApprova_Click);
			this.btCrea.Click += new System.EventHandler(this.btCrea_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btApprova_Click(object sender, System.EventArgs e)
		{
			if(ViewState["FunId"]!=null)
				this.FunId =Convert.ToInt32(ViewState ["FunId"]);
			Server.Transfer("AggiornamentoRdl.aspx?ItemID=" + txtWrHidden.Text + "&e=y&butt=1&FunId=" + FunId);
		}

		private void btCrea_Click(object sender, System.EventArgs e)
		{
			if(ViewState["FunId"]!=null)
			 this.FunId =Convert.ToInt32(ViewState ["FunId"]);
			Response.Redirect("CreazioneSGA.aspx?FunId=" + FunId.ToString());
		}
	}
}
