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
	public class RichiedentiSollecito : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Panel RichiedenteShowInfo;
		protected System.Web.UI.WebControls.DataGrid DataGridRichiedente;
		public string idtxtRichNome=string.Empty;
		public string idtxtRichCognome=string.Empty;
		public string idtxtRichID=string.Empty;
		protected S_Controls.S_TextBox txtRichID;
		protected S_Controls.S_TextBox txtRichNome;
		protected S_Controls.S_TextBox txtRichCognome;
		protected S_Controls.S_TextBox txtstelefono;
		protected S_Controls.S_TextBox txtsemail;
		protected S_Controls.S_TextBox txtstanza;
		protected S_Controls.S_ComboBox cmbsGruppo;
		protected System.Web.UI.WebControls.Button cmdRichiedente;
		protected System.Web.UI.WebControls.LinkButton lnkVisContatti;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.LinkButton Linkbutton1;
		protected System.Web.UI.WebControls.DataGrid DataGridEsegui;
		protected System.Web.UI.WebControls.Panel PanelContatti;
		protected System.Web.UI.WebControls.LinkButton lnkChiudi;
		protected System.Web.UI.WebControls.CheckBox CkSendMail;
		public System.Web.UI.HtmlControls.HtmlInputHidden idProg;
		public string idtxtRichGruppo= "";

		public void SendMail()
		{
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			idtxtRichNome=txtRichNome.ClientID;
			idtxtRichCognome=txtRichCognome.ClientID;
			idtxtRichID=txtRichID.ClientID;
			idtxtRichGruppo=cmbsGruppo.ClientID;
			
			//string funzionePanel = "javascript:document.getElementById('" + this.PanelContatti.ClientID  + "').style.display='none';";
			//Linkbutton1.Attributes.Add("onclick",funzionePanel);
			
			txtRichNome.Attributes.Add("onkeydown","SvuotaID()");
			txtRichCognome.Attributes.Add("onkeydown","SvuotaID()"); 
			cmbsGruppo.Attributes.Add("onchange","SvuotaIDCmb()"); 
			//ImageButton1.Attributes.Add("onclick","ControllaId('" + ImageButton1.ClientID + "')");
			if (!IsPostBack)
			{
				BindGruppo(cmbsGruppo.SelectedValue);
				if(Request.QueryString["VarApp"]!=null)
					Progetto=Request.QueryString["VarApp"];
			}
			

		}
		public  S_Controls.S_TextBox s_RichNome
		{
			get {return txtRichNome;}
		}

		public  S_Controls.S_TextBox s_RichID
		{
			get {return txtRichID;}
		}

		public  S_Controls.S_TextBox s_RichCognome
		{
			get {return txtRichCognome;}
		}
		public  S_Controls.S_TextBox s_telefono
		{
			get {return txtstelefono;}
		}
		public  S_Controls.S_TextBox s_email
		{
			get {return txtsemail;}
		}
		
		public  S_Controls.S_TextBox s_stanza
		{
			get {return txtstanza;}
		}

		public  S_Controls.S_ComboBox s_RichGruppo
		{
			get {return cmbsGruppo;}
		}

		public int IdGruppo
		{
			get {return  Convert.ToInt32(cmbsGruppo.SelectedValue);}
		}
		public string NomeCompleto
		{
			get {return  txtRichNome.Text;}
		}

		public string CognomeCompleto
		{
			get {return txtRichCognome.Text;}
		}
		public bool IsSendMail
		{
			get {return CkSendMail.Checked;}
		}
		public string telefono
		{
			get {return txtstelefono.Text;}
		}
		public string email
		{
			get {return txtsemail.Text;}
		}
		public string stanza
		{
			get {return txtstanza.Text;}
		}
		
		public string NomePannello
		{
			get {return RichiedenteShowInfo.ClientID;}
		}
		public string Progetto
		{
			get {return idProg.Value;}
			set {idProg.Value=value;}
		}
		public string Apici(Object s)
		{
			string val= s.ToString().Replace("'","`");
			return val;
		}

		public void BindGruppo(string id_tipo)
		{
			this.cmbsGruppo.Items.Clear();
			Classi.ClassiAnagrafiche.Richiedenti_tipo _Richiedenti = new TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo();
				
			DataSet _MyDs = _Richiedenti.GetAllAddProg(Progetto).Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{				
				this.cmbsGruppo.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione","id", "- - - - - - -", "0");
				this.cmbsGruppo.DataTextField = "descrizione";
				this.cmbsGruppo.DataValueField = "id";
//				if(id_tipo!="")
//					this.cmbsGruppo.SelectedValue=id_tipo;
				this.cmbsGruppo.DataBind();
			}			
			else
			{
				string s_Messagggio = "- Nessun Gruppo -";
				this.cmbsGruppo.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
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
						
			string s_TestataScript = "<script language=\"javascript\">\n";
			string s_CodaScript = "</script>\n";
			Classi.ManOrdinaria.Richiesta  _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
			this.RichiedenteShowInfo.Visible = true;
			DataSet _MYDs = _Richiesta.GetRichiedenti(this.NomeCompleto, this.CognomeCompleto,this.Progetto,this.cmbsGruppo.SelectedValue);
			DataGridRichiedente.DataSource = _MYDs;
			DataGridRichiedente.DataBind();
			//lnkVisContatti.Text+="(" + TotContatti +")";
			//lnkVisContatti.Attributes.Add("totContatti",TotContatti);			
			
			string script_richiedente =s_TestataScript + "RichiedentiSetVisible(true, '" + RichiedenteShowInfo.ClientID + "');" + s_CodaScript;
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
			this.lnkVisContatti.Click += new System.EventHandler(this.lnkVisContatti_Click);
			this.Load += new System.EventHandler(this.Page_Load);			
			this.DataGridRichiedente.PageIndexChanged+= new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRichiedente_PageIndexChanged);
		}
		#endregion


		private void lnkVisContatti_Click(object sender, System.EventArgs e)
		{
			if (int.Parse(this.txtRichID.Text) != 0)
			{
				string s_TestataScript = "<script language=\"javascript\">\n";
				string s_CodaScript = "</script>\n";
				Classi.ClassiAnagrafiche.Contatti _Contatti = new TheSite.Classi.ClassiAnagrafiche.Contatti();
				this.PanelContatti.Visible = true;
				DataSet _ds = _Contatti.GetData(int.Parse(this.txtRichID.Text));
				if (_ds.Tables[0].Rows.Count > 0) 
				{
					this.DataGridEsegui.DataSource =  _ds;
					this.DataGridEsegui.DataBind();
					string script_richiedente =s_TestataScript + "RichiedentiSetVisible(true, '" + PanelContatti.ClientID + "');" + s_CodaScript;
					this.Page.RegisterStartupScript("script_contatto",script_richiedente);
				}
				else
				{
					String scriptString = "<script language=JavaScript>alert(\"Nessun contatto per il richiedente selezionato.\");";
					scriptString += "<";
					scriptString += "/";
					scriptString += "script>";

					if(!this.Page.IsClientScriptBlockRegistered("clientScriptcontatti"))
						this.Page.RegisterStartupScript ("clientScriptcontatti", scriptString);				
				
				}
			}
			else
			{
				String scriptString = "<script language=JavaScript>alert(\"Nessun contatto per il richiedente selezionato.\");";
				scriptString += "<";
				scriptString += "/";
				scriptString += "script>";

				if(!this.Page.IsClientScriptBlockRegistered("clientScriptcontatti"))
					this.Page.RegisterStartupScript ("clientScriptcontatti", scriptString);				
			}		
		}



	}
}
