namespace TheSite.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using S_Controls.Collections;
	using ApplicationDataLayer;
	using ApplicationDataLayer.DBType;
	using MyCollection;

	/// <summary>
	///		Descrizione di riepilogo per Richiedenti.
	/// </summary>
	public class Richiedenti : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.LinkButton lnkChiudi;
		protected S_Controls.S_TextBox txtRichiedente;
		protected System.Web.UI.WebControls.Panel RichiedenteShowInfo;
		protected System.Web.UI.WebControls.DataGrid DataGridRichiedente;		
		protected System.Web.UI.WebControls.Button cmdRichiedente;		
		public string idtxtRichiedente=string.Empty;

		private void Page_Load(object sender, System.EventArgs e)
		{
			idtxtRichiedente=txtRichiedente.ClientID;
		}
		public  S_Controls.S_TextBox s_Richiedente
		{
			get {return txtRichiedente;}
		}

		public string NomeCompleto
		{
			get {return txtRichiedente.Text;}
		}

		public string NomePannello
		{
			get {return RichiedenteShowInfo.ClientID;}
		}
		public string Apici(Object s)
		{
			string val= s.ToString().Replace("'","`");
			return val;
		}

		private void lnkChiudi_Click(object sender, System.EventArgs e)
		{					
			DataGridRichiedente.CurrentPageIndex = 0;
			this.RichiedenteShowInfo.Visible = false;
		}

		private void DataGridRichiedente_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRichiedente.CurrentPageIndex = e.NewPageIndex;			
			RicercaRichiedenti();
		}

		private void cmdRichiedente_Click(object sender, System.EventArgs e)
		{
			DataGridRichiedente.CurrentPageIndex = 0;
			RicercaRichiedenti();
		}

		void RicercaRichiedenti()
		{
			string Progetto="";
			if(Request.QueryString["VarApp"]!=null)
				Progetto=Request.QueryString["VarApp"];
			
			string s_TestataScript = "<script language=\"javascript\">\n";
			string s_CodaScript = "</script>\n";
			Classi.ManOrdinaria.Richiesta  _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
			this.RichiedenteShowInfo.Visible = true;
			DataGridRichiedente.DataSource = _Richiesta.GetRichiedenti(this.NomeCompleto, "",Progetto,"");
			//DataGridRichiedente.DataSource = _Richiesta.GetRichiedenti(this.NomeCompleto);
			DataGridRichiedente.DataBind();
			

			string script_richiedente =s_TestataScript + "RichiedentiSetVisible(true, '" + RichiedenteShowInfo.ClientID + "');"+s_CodaScript;
			this.Page.RegisterStartupScript("script_richiedente",script_richiedente);
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
			this.cmdRichiedente.Click += new System.EventHandler(this.cmdRichiedente_Click);
			this.lnkChiudi.Click += new System.EventHandler(this.lnkChiudi_Click);
			this.DataGridRichiedente.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRichiedente_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
