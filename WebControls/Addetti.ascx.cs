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
	///		Descrizione di riepilogo per Addetti.
	/// </summary>
	public class Addetti : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.LinkButton lnkChiudi;
		protected System.Web.UI.WebControls.TextBox txtAddetto;
		protected System.Web.UI.WebControls.TextBox TxtIdAddetto;
		protected System.Web.UI.WebControls.Panel AddettiShowInfo;
		protected System.Web.UI.WebControls.DataGrid DataGridAddetto;		
		protected System.Web.UI.WebControls.Button cmdAddetto;
		protected System.Web.UI.WebControls.TextBox hidBL_ID;
		protected System.Web.UI.WebControls.TextBox hidDITTA_ID;			
		public string IdTxtIdAddetto=string.Empty;
		public string idtxtAddetto=string.Empty;
		private string bl_id = "%";
		private int ditta_id = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			idtxtAddetto=txtAddetto.ClientID;
			IdTxtIdAddetto=TxtIdAddetto.ClientID;
			//hidDITTA_ID.Text="0";
		}

		void RicercaAddetti()
		{
						
			string s_TestataScript = "<script language=\"javascript\">\n";
			string s_CodaScript = "</script>\n";
			Classi.ManOrdinaria.Richiesta  _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
			this.AddettiShowInfo.Visible = true;	
			if(hidDITTA_ID.Text!="")
				DataGridAddetto.DataSource = _Richiesta.GetAddetti(this.NomeCompleto, hidBL_ID.Text,Int32.Parse(hidDITTA_ID.Text));
			else
				DataGridAddetto.DataSource = _Richiesta.GetAddetti(this.NomeCompleto, hidBL_ID.Text);

			DataGridAddetto.DataBind();
			

			string script_addetti =s_TestataScript + "AddettiSetVisible(true, '" + AddettiShowInfo.ClientID + "');"+s_CodaScript;
			this.Page.RegisterStartupScript("script_addetti",script_addetti);
		}

		public string Apici(Object s)
		{
			string val= s.ToString().Replace("'","`");
			return val;
		}

		public string NomePannello
		{
			get {return AddettiShowInfo.ClientID;}
		}

		public string NomeCompleto
		{
			get {return txtAddetto.Text;}			
			set	{txtAddetto.Text=value;}
		}

		public string IdAddetto
		{
			get{return TxtIdAddetto.Text;}
			set{TxtIdAddetto.Text=value;}
		}

		public TextBox TextIdAddetto
		{
			get{return TxtIdAddetto;}
			
		}
		public void Set_BL_ID (string p_bl_id)
		{
			bl_id = p_bl_id;
			if (bl_id == "") bl_id="%";
			hidBL_ID.Text=bl_id;
		}
		
		public System.Web.UI.WebControls.Button btnAddetto
		{
			get {return cmdAddetto;}						
		}
		
		

		public void Set_BL_ID_DITTA_ID (string p_bl_id,int p_ditta_id)
		{
			//Imposto il BL
			bl_id = p_bl_id;			
			if (bl_id == "") bl_id="%";						
			hidBL_ID.Text=bl_id;
			//Imposta la DITTA
			ditta_id=p_ditta_id;
			hidDITTA_ID.Text=ditta_id.ToString();
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
			this.cmdAddetto.Click += new System.EventHandler(this.cmdAddetto_Click);
			this.lnkChiudi.Click += new System.EventHandler(this.lnkChiudi_Click);
			this.DataGridAddetto.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridAddetto_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnkChiudi_Click(object sender, System.EventArgs e)
		{					
			DataGridAddetto.CurrentPageIndex = 0;
			this.AddettiShowInfo.Visible = false;
		}

		private void DataGridAddetto_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridAddetto.CurrentPageIndex = e.NewPageIndex;			
			RicercaAddetti();
		}

		private void cmdAddetto_Click(object sender, System.EventArgs e)
		{
			DataGridAddetto.CurrentPageIndex = 0;
			RicercaAddetti();
		}
	}
}
