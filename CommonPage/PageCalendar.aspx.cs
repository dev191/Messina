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

namespace TheSite.CommonPage
{
	/// <summary>
	/// Descrizione di riepilogo per PageCalendar.
	/// </summary>
	public class PageCalendar : System.Web.UI.Page
	{
		public DateTime d1 = DateTime.Now;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		public string namediv=string.Empty;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
            if(!IsPostBack)
               this.idmodulo =Request.QueryString["idmodulocal"];
  

			this.namediv=Request.QueryString["namediv"];

			String scriptString = "<script language=JavaScript>dateField= parent.document.getElementById('" + this.idmodulo  + "_" + "S_TxtDatecalendar');";
			scriptString += "<";
			scriptString += "/";
			scriptString += "script>";

			if(!this.IsClientScriptBlockRegistered("clientScriptcalendario"))
				this.RegisterClientScriptBlock ("clientScriptcalendario", scriptString);


	          
		}
		private string idmodulo
		{
			get {return (String) ViewState["s_idmodulo"];}
			set {ViewState["s_idmodulo"] = value;}
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
