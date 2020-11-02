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

namespace WebCad.CAD
{
	/// <summary>
	/// Descrizione di riepilogo per CadViewer.
	/// </summary>
	public class CadViewer : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtVettoreStanzeSelezionate;
		protected string UrlDwf;
		protected string RelativPath;
		protected string EseguiScriptApriPlanimetria,Planimetria;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtFirstTime;
		protected System.Web.UI.HtmlControls.HtmlInputText txtUrlDwf;
	
		private void Page_Load(object sender, System.EventArgs e)
		{

			//UrlDwf= Page.Request.Url.GetLeftPart(System.UriPartial.Authority) + Request.ApplicationPath + System.Configuration.ConfigurationSettings.AppSettings["DirectoryCad"];
			txtUrlDwf.Value = @"../.." + System.Configuration.ConfigurationSettings.AppSettings["DirectoryCad"];
			if(!Page.IsPostBack)
			{

				if(Request["FromPaginaApprovaEmettiRdl"]!=null)
				{
					Planimetria = Request["Planimetria"];
					EseguiScriptApriPlanimetria = "openFileView \"" + Planimetria +".dwf\",\"true\"";

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
