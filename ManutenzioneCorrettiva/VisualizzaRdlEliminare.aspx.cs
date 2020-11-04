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

namespace TheSite.ManutenzioneCorrettiva
{
	/// <summary>
	/// Descrizione di riepilogo per VisualizzaRdlEliminare.
	/// </summary>
	
	public class VisualizzaRdlEliminare : System.Web.UI.Page
	{
		public TheSite.ManutenzioneCorrettiva.SfogliaRdLEliminare _fp;
		//TheSite.WebControls.UserRdlInailLabel UserRdlInailLabel;
		private void Page_Load(object sender, System.EventArgs e)
		{
			ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
			if(Context.Handler is TheSite.ManutenzioneCorrettiva.SfogliaRdLEliminare) 
			{
				_fp = (TheSite.ManutenzioneCorrettiva.SfogliaRdLEliminare) Context.Handler;
				this.ViewState.Add("mioContenitore",_fp._Contenitore); 
			}	
		}
		public MyCollection.clMyCollection _Contenitore
		{ 
			get 
			{
				if(this.ViewState["mioContenitore"]!=null)
					return (MyCollection.clMyCollection)this.ViewState["mioContenitore"];
				else
					return new MyCollection.clMyCollection();
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

