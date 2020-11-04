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
using GIC.Report.UserControl;

namespace GIC.Report
{
	
	/// <summary>
	/// Descrizione di riepilogo per DefaultReport.
	/// </summary>
	public class DefaultReport : System.Web.UI.Page
	{	
		protected VisSelCampi VisSelCampi1;
		protected SelezioneQuery SelezioneQuery1;
		public static string HelpLink = string.Empty;
		

		public bool VisCampiVisible
		{
			set{this.VisSelCampi1.Visible=value;}
		}

		public string VisSelCampi1SelectedItemsValue
		{
			set{VisSelCampi1.SelectedItemsValue=value;}
		}

		public int IdQuery
		{
			set
			{
				this.VisSelCampi1.IdQuery=value;
			}
		}

		public void RicaricaLista()
		{
			SelezioneQuery1.Ricarica();
		}

		public void RicaricaQuery()
		{
			VisSelCampi1.Ricarica();
		}


		private void Page_Load(object sender, System.EventArgs e)
		{
			if (VisSelCampi1.IdQuery==0)
			{
				VisSelCampi1.Visible=false;
			}

			TheSite.Classi.SiteModule _SiteModule = (TheSite.Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			HelpLink = _SiteModule.HelpLink;

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
