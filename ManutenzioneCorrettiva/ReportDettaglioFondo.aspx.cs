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
	/// Descrizione di riepilogo per RapportoTecnicoIntervento.
	/// </summary>
	public class ReportDettaglioFondo : System.Web.UI.Page
	{
		
		protected WebControls.PageTitle PageTitle1;
		protected S_Controls.S_Label lblsAnno;
		protected S_Controls.S_Label lblsTipoIntervento; 		
		public string anno=string.Empty;
		public string tipointervento_id=string.Empty;
		public string TipoInterventoDesc=string.Empty;	

		public string ImportoNetto=string.Empty;
		public string ImportoLordo=string.Empty;
		public string Descrizione=string.Empty;
		public string Note=string.Empty;		

		protected System.Web.UI.HtmlControls.HtmlTable TblMessaggio;
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			PageTitle1.VisibleLogut =false;
			TblMessaggio.Visible=false;
			if(!IsPostBack)
			{	
				if(Request.QueryString["excel"].ToString()=="true")					
				{
					HttpContext.Current.Response.Clear();
					HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
					HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Dettaglio.xls");
					HttpContext.Current.Response.Charset = "UTF-8";
				}
				Execute(Request.QueryString["id"].ToString());				
				
			}
		}
		/// <summary>
		/// Eseguo la store procedure e recupero i campi
		/// Eseguo il Binding sul Repeater
		/// </summary>
		private void Execute(string itemId)
		{			
			
			Classi.ManStraordinaria.Report _Rpt= new TheSite.Classi.ManStraordinaria.Report();
			DataSet _MyDs = _Rpt.GetSingleData(Int16.Parse(itemId)).Copy();
			if (_MyDs.Tables[0].Rows.Count == 1)
			{					
				DataRow _Dr = _MyDs.Tables[0].Rows[0];

				if (_Dr["Descrizione"] != DBNull.Value)
					Descrizione = (string) _Dr["descrizione"];

				if (_Dr["Note"] != DBNull.Value)
					Note = (string) _Dr["Note"];	
						
				if (_Dr["importo_netto"] != DBNull.Value)											
					ImportoNetto =  _Dr["importo_netto"].ToString();													

				if (_Dr["importo_lordo"] != DBNull.Value)					
					ImportoLordo =  _Dr["importo_lordo"].ToString();								

				if (_Dr["anno"] != DBNull.Value)					
					anno =  _Dr["anno"].ToString();												

				if (_Dr["descrizione_breve"] != DBNull.Value)					
					TipoInterventoDesc =  _Dr["descrizione_breve"].ToString();								
											
			}
			else
				TblMessaggio.Visible=true;
		}	
	
		public string Formatta(string importo)
		{			
			if(importo == String.Empty)
			{
				importo="0";				
			}			
							
			importo=Double.Parse(importo.ToString()).ToString("C");
				
			return importo.Replace("€","&euro;");
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


