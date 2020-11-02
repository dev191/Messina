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

namespace WebCad
{
	/// <summary>
	/// Descrizione di riepilogo per TopFrame.
	/// </summary>
	public class TopFrame : System.Web.UI.Page    // System.Web.UI.Page
	{
		public string idbl=string.Empty;
		public string idpiano=string.Empty;

		protected string lblBlClinetId;
		protected string lblFlClinetId;
		protected string tbxBlClinetId;
		protected System.Web.UI.WebControls.Label lblEdificio;
		protected System.Web.UI.WebControls.TextBox id_bl;
		protected System.Web.UI.WebControls.Label lblPiano;
		protected System.Web.UI.WebControls.TextBox id_fl;
		protected System.Web.UI.WebControls.Label lblPlanD;
		protected System.Web.UI.WebControls.Label lblPlan;
		protected System.Web.UI.WebControls.Label lblServizio;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TxtFromCreazioneRdl;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TxtIdServizio;
		protected string tbxFlClinetId;


		private void Page_Load(object sender, System.EventArgs e)
		{
			this.idbl=Request.QueryString["idbl"];
			this.idpiano=Request.QueryString["idpiano"];
			lblBlClinetId="";
			lblFlClinetId="";
//			id_bl.Visible=false;
//			id_fl.Visible=false;
			tbxBlClinetId=id_bl.ClientID;
			tbxFlClinetId=id_fl.ClientID;
			if(Request["FromPaginaCreazioneRdl"]!=null)
			{
				ImpostaLabelFromCreazioneRdl();
				
				
				return;
			}
			if(Request["FromPaginaApprovaEmettiRdl"]!=null)
			{
				ImpostaLabelFromApprovaEmettiRdl();
			}

		}
		/// <summary>
		/// Recupero le Informazioni dell'Edificio e del Piano
		/// </summary>
	
		private void GetInfoPage()
		{
			DataTable dt=this.GetInfoPage(this.idbl,this.idpiano);
			if(dt.Rows.Count>0)
			{
				DataRow dr=dt.Rows[0];
				lblEdificio.Text= dr["Edificio"].ToString();
				lblPiano.Text= dr["Piano"].ToString();
			}
		}
		/// <summary>
		/// Ritorna un DataTable con le informazioni dell'edificio
		/// </summary>
		/// <param name="idbl">id dell'edifico</param>
		/// <param name="idpaino">id del piano</param>
		/// <returns></returns>
		private DataTable GetInfoPage(string idbl, string idpaino)
		{
		 return new DataTable();
		}
		private void  ImpostaLabelFromCreazioneRdl()
		{
			string BlId = Request["BlId"];
			int IdPiano = Convert.ToInt32(Request["IdPiano"]);
			int IdServizio =0;
			if(Request["IdServizio"] != String.Empty)
			{
				IdServizio = Convert.ToInt32(Request["IdServizio"]);
			}
			string DescrizionePiano = IdPiano_To_DescPiano(IdPiano);
			lblEdificio.Text = BlId;
			lblPiano.Text = DescrizionePiano;
			if(IdServizio !=0 )
			{
				string DescrizioneServizio = Idservizio_To_DecServizio(IdServizio);
				lblServizio.Text = DescrizioneServizio;
			}
			TxtFromCreazioneRdl.Value = Request["FromPaginaCreazioneRdl"];
			TxtIdServizio.Value = IdServizio.ToString();
			
		}
		private void ImpostaLabelFromApprovaEmettiRdl()
		{
			string BlId = Request["BlId"];
			int IdPiano = Convert.ToInt32(Request["IdPiano"]);
			int IdServizio =0;
			if(Request["IdServizio"] != String.Empty)
			{
				IdServizio = Convert.ToInt32(Request["IdServizio"]);
			}
			string DescrizionePiano = IdPiano_To_DescPiano(IdPiano);
			lblEdificio.Text = BlId;
			lblPiano.Text = DescrizionePiano;
			if(IdServizio !=0 )
			{
				string DescrizioneServizio = Idservizio_To_DecServizio(IdServizio);
				lblServizio.Text = DescrizioneServizio;
			}
			TxtIdServizio.Value = IdServizio.ToString();
			lblPlan.Text = Request["Planimetria"];
		}
		private string Idservizio_To_DecServizio(int IdServizio)
		{
				WebCad.Classi.ClassiDettaglio.Servizi srv = new WebCad.Classi.ClassiDettaglio.Servizi();
				return srv.GetDecServizioById(IdServizio);
		 }
		private string IdPiano_To_DescPiano(int IdPiano)
		{
			
			WebCad.Classi.ClassiAnagrafiche.Buildings IdBlFromBlId = new WebCad.Classi.ClassiAnagrafiche.Buildings();
			return IdBlFromBlId.GetDescrizionePiano(IdPiano);
		
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
