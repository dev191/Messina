namespace TheSite.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descrizione di riepilogo per VisualizzaReperibilita.
	/// </summary>
	public class VisualizzaReperibilita : System.Web.UI.UserControl
	{
	
		public string idTextCod;
		protected System.Web.UI.HtmlControls.HtmlInputButton btsCodice;
		//public string idTextRic;
		//public string idModulo;
		protected System.Web.UI.WebControls.TextBox txtBL_ID;
		//public string multisele;

		private void Page_Load(object sender, System.EventArgs e)
		{
			idTextCod= txtBL_ID.ClientID;
			btsCodice.Attributes.Add("onclick","ShowFrameRep('" + idTextCod + "','bl_id',event);");  
			Classi.SiteJavaScript.ShowFrameReperibili(Page,1);   
			btsCodice.CausesValidation = false;
			if (!Page.IsPostBack)
			{
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

//		private void btsCodice_ServerClick(object sender, System.EventArgs e)
//		{
//
//			String scriptString = "<script language=JavaScript>alert(\"Nessuna richiesta per l'edificio selezionato\");";
//			scriptString += "<";
//			scriptString += "/";
//			scriptString += "script>";
//
//			if(!this.Parent.Page.IsClientScriptBlockRegistered("clientScriptcalendario"))
//				this.Parent.Page.RegisterClientScriptBlock ("clientScriptcalendario", scriptString);
//
//		
//		}

		public string TxtID_BL
		{
			set{txtBL_ID.Text = value;}
		}
		

	}
}
