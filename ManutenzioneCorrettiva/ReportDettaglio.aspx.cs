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
	public class ReportDettaglio : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Repeater repeater1;
		protected System.Web.UI.WebControls.Repeater repeater2;
		protected WebControls.PageTitle PageTitle1;
		protected S_Controls.S_Label lblsAnno;
		protected S_Controls.S_Label lblsTipoIntervento; 		
		public string anno=string.Empty;
		public string tipointervento_id=string.Empty;
		public string TipoInterventoDesc=string.Empty;			
		
		public int colspan=6;
		
		protected System.Web.UI.HtmlControls.HtmlTable TblMessaggio;
		
		protected System.Web.UI.HtmlControls.HtmlTableCell tdDetServizio;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdIntServizio;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdDetDescrizione;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdIntDescrizione;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdTotale;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			PageTitle1.VisibleLogut =false;
			if(!IsPostBack)
			{				
				this.anno =Request.QueryString["anno"].ToString();					
				this.tipointervento_id =Request.QueryString["tipointervento"].ToString();										
				this.TipoInterventoDesc =Request.QueryString["TipoInterventoDesc"].ToString();										
				
				//Inizializzazione per le Colonne Dinamiche											
				if(Request.QueryString["descrizione"].ToString()=="false")
					colspan--;
								
				if(Request.QueryString["servizio"].ToString()=="false")	
					colspan--;								
				
				if(Request.QueryString["excel"].ToString()=="true")					
				{
					HttpContext.Current.Response.Clear();
					HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
					HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Dettaglio.xls");
					HttpContext.Current.Response.Charset = "UTF-8";
				}
				
				Execute();				
				
			}
		}
		/// <summary>
		/// Eseguo la store procedure e recupero i campi
		/// Eseguo il Binding sul Repeater
		/// </summary>
		private void Execute()
		{			
			Classi.ManStraordinaria.Report _Report = new TheSite.Classi.ManStraordinaria.Report(); 			
		
			//Carico il Dettaglio
			DataSet Ds=_Report.GetDatiDettaglio(Int16.Parse(tipointervento_id),Int16.Parse(anno),"Consuntivo");
			if (Ds.Tables[0].Rows.Count>0)
			{
				TblMessaggio.Visible=false;
			
				repeater1.DataSource= Ds;
				repeater1.DataBind(); 
				//Carico i Totali
				DataSet DsTot=_Report.GetDatiTotaliDettaglio(Int16.Parse(tipointervento_id),Int16.Parse(anno),"Consuntivo");
				repeater2.DataSource= DsTot;			
				repeater2.DataBind(); 
			}
			else
			{
				TblMessaggio.Visible=true;
				
			}
		}
		public string Formatta(string importo)
		{			
			if(importo == String.Empty)
			{
				importo="0";				
			}			
							
			importo=Double.Parse(importo.ToString()).ToString("C");
				
			return importo.Replace("�","&euro;");
		}		
		#region Codice generato da Progettazione Web Form
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: questa chiamata � richiesta da Progettazione Web Form ASP.NET.
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

