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
	/// Descrizione di riepilogo per _Default.
	/// </summary>
	public class _Default : System.Web.UI.Page
	{
		public string url="MainContent.aspx";
		public string url1="LeftFrame.aspx";	
			
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Request.QueryString["VarApp"]!=null)
			{
				url="ManutenzioneCorrettiva/CreazioneSGA.aspx?FunId=7&VarApp=" + Request.QueryString["VarApp"];

				url1="LeftFrame.aspx?VarApp=" + Request.QueryString["VarApp"];
			}
			else
			{
				if(HttpContext.Current.User.IsInRole("MA") && !HttpContext.Current.User.IsInRole("PA"))
				{
					url+="?VarApp=1";
					url1="LeftFrame.aspx?VarApp=1";
				}
				if(!HttpContext.Current.User.IsInRole("MA") && HttpContext.Current.User.IsInRole("PA"))
				{
					url+="?VarApp=2";
					url1="LeftFrame.aspx?VarApp=2";
				}
			
			}
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if (AslMobile.Class.ClassGlobal.IsMobileDevice  == true ) 
				Response.Redirect("AslMobile/Default.aspx"); 
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
