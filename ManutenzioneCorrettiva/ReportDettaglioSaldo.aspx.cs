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
	public class ReportDettaglioSaldo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Repeater repeater1;
		protected WebControls.PageTitle PageTitle1;
		protected S_Controls.S_Label lblsAnno;
		protected S_Controls.S_Label lblsTipoIntervento; 		
		
		public string anno=string.Empty;
		public string tipointervento_id=string.Empty;
		public string TipoInterventoDesc=string.Empty;		
		
		public string Saldo=string.Empty;
		public string SaldoIcrementale=string.Empty;
		
		public string stileServizio=string.Empty;
		public string stileDescrizione=string.Empty;

		private double appoSaldo=0;

		protected System.Web.UI.HtmlControls.HtmlTable TblMessaggio;
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			PageTitle1.VisibleLogut =false;
			if(!IsPostBack)
			{				
				this.anno =Request.QueryString["anno"].ToString();					
				this.tipointervento_id =Request.QueryString["tipointervento"].ToString();										
				this.TipoInterventoDesc =Request.QueryString["TipoInterventoDesc"].ToString();														
				appoSaldo=Double.Parse(Request.QueryString["Saldo"].ToString().Replace("€",""));			
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
			DataSet Ds=_Report.GetDatiDettaglioSaldo(Int16.Parse(tipointervento_id),Int16.Parse(anno));
			if (Ds.Tables[0].Rows.Count>0)
			{
				TblMessaggio.Visible=false;			
				repeater1.DataSource= Ds;
				repeater1.DataBind(); 				
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
			this.repeater1.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.repeater1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
			{
				DataRowView  _DR = e.Item.DataItem as DataRowView;				
				appoSaldo=appoSaldo-Double.Parse(_DR["Speso"].ToString());     								
				((Label) e.Item.FindControl("lblSaldo")).Text=Formatta(appoSaldo.ToString());				
			}			
		}
	}
}


