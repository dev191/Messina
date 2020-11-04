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
	public class AggiungiSollecito : System.Web.UI.UserControl
	{
	
		public string idTextCod;
		protected System.Web.UI.WebControls.TextBox txtWR_ID;
		protected System.Web.UI.HtmlControls.HtmlInputButton btsCodice;

		private void Page_Load(object sender, System.EventArgs e)
		{
			idTextCod= txtWR_ID.ClientID;
			string q="'prj=" + Progetto + "&idric'";
			btsCodice.Attributes.Add("onclick","ShowFrameAddSoll('" + idTextCod + "'," + q + ",event);");  
			Classi.SiteJavaScript.ShowFrameSollecito(Page,1);   
			btsCodice.CausesValidation = false;
			if (!Page.IsPostBack)
			{
			}
		}
		string _Progetto="";
		public string Progetto
		{
			get {return _Progetto;}
			set {_Progetto=value;}
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

		public string TxtID_WR
		{
			set{txtWR_ID.Text = value;}
		}
		

	}
}
