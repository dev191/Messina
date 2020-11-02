namespace WebCad.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	public delegate void DelegateCodiceEdificio(string Cod);
	public delegate void DelegateIDBLEdificio(string Cod);
	public delegate void DelegateCodiceServizio();

	/// <summary>
	///		Descrizione di riepilogo per RicercaModulo.
	/// </summary>
	public class RicercaModulo : System.Web.UI.UserControl
	{
		protected S_Controls.S_TextBox txtsCodEdificio;
		protected System.Web.UI.WebControls.Label lblDenominazione;
		protected System.Web.UI.WebControls.Label lblComune;
		protected System.Web.UI.WebControls.Label lblDitta;
		protected System.Web.UI.HtmlControls.HtmlInputHidden lblEmail;
		protected System.Web.UI.WebControls.Label lblIndirizzo;
		protected System.Web.UI.WebControls.Label lblTelefono;
		protected System.Web.UI.WebControls.Label lblCdC;
		protected System.Web.UI.WebControls.Label lblBlId;
		protected System.Web.UI.HtmlControls.HtmlInputHidden  hiddenidbl;
		protected System.Web.UI.HtmlControls.HtmlTable tbla;
		private Classi.ClassiDettaglio.Edificio _Edificio = new WebCad.Classi.ClassiDettaglio.Edificio("");
		
		public string idTextCod;
		public string idTextRic;
		public string idModulo;
		public string multisele;
		protected System.Web.UI.WebControls.Panel PanelDettagli;
		protected S_Controls.S_TextBox txtRicerca;

		public DelegateCodiceEdificio DelegateCodiceEdificio1;
		public DelegateIDBLEdificio DelegateIDBLEdificio1;
		protected System.Web.UI.HtmlControls.HtmlTable tblModulo;
		public DelegateCodiceServizio DelegateCodiceServizio1;

		private void Page_Load(object sender, System.EventArgs e)
		{
            
			Classi.SiteJavaScript.ShowFrame(Page,1);   
			idTextCod=txtsCodEdificio.ClientID;
			idTextRic=txtRicerca.ClientID;
			idModulo=this.ClientID;
			
			//txtsCodEdificio.Attributes.Add("onchange","Verifica(this);");
		}

		#region Proprietà

		// Indica che il controlle effettua la multiselezione
		public string multiselect
		{
			get {return multisele;}
			set	{multisele=value;}
		}

		//Visualizza e imposta la visualizzazione dei dettagli
		public bool visualizzadettagli
		{
			get {return PanelDettagli.Visible;}
			set	{PanelDettagli.Visible=value;}
		}

		public  S_Controls.S_TextBox TxtCodice
		{
			get {return txtsCodEdificio;}
			set	{txtsCodEdificio=value;}
		}
		public  S_Controls.S_TextBox TxtRicerca
		{
			get {return  txtRicerca;}
		}

		public string BlId
		{
			get 
			{
				if (lblBlId.Text.Length > 0)
					return lblBlId.Text;
				else
					return string.Empty;
			}
		}
		public string Idbl
		{
			get 
			{
				if (hiddenidbl.Value.Length > 0)
					return hiddenidbl.Value;
				else
					return string.Empty;
			}
		}
		public string Nome
		{
			get 
			{
				if (lblDenominazione.Text.Length > 0)
					return lblDenominazione.Text;
				else
					return string.Empty;
			}
		}

		public  Label LbLIdBL
		{
			get {return lblBlId;}
			set	{lblBlId=value;}
		}
		
		public   System.Web.UI.HtmlControls.HtmlInputHidden _txthidbl
		{
			get {return hiddenidbl;}
			set	{hiddenidbl=value;}
		}

		public string Indirizzo
		{
			get 
			{
				if (lblIndirizzo.Text.Length > 0)
					return lblIndirizzo.Text;
				else
					return string.Empty;
			}
		}

		public string Comune
		{
			get 
			{
				if (lblComune.Text.Length > 0)
					return lblComune.Text;
				else
					return string.Empty;
			}
		}

		public string Ditta
		{
			get 
			{
				if (lblDitta.Text.Length > 0)
					return lblDitta.Text;
				else
					return string.Empty;
			}
		}

		public string Telefono
		{
			get 
			{
				if (lblTelefono.Text.Length > 0)
					return lblTelefono.Text;
				else
					return string.Empty;
			}
		}


		public string Email
		{
			get 
			{
				if (lblEmail.Value.Length > 0)
					return lblEmail.Value;
				else
					return string.Empty;
			}
		}
		public string Campus
		{
			get 
			{
				if (txtRicerca.Text.Length > 0)
					return txtRicerca.Text;
				else
					return string.Empty;
			}
		}
		public string ClasseTab
		{
			
			get {return ClasseTab;}
			set {tblModulo.Attributes.Add("class",value);}				
		}
		#endregion

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
			this.txtsCodEdificio.TextChanged += new System.EventHandler(this.txtsCodEdificio_TextChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		private void txtsCodEdificio_TextChanged(object sender, EventArgs e)
		{
			Ricarica();
		}

		public void Ricarica()
		{
			int LengthCod=int.Parse(System.Configuration.ConfigurationSettings.AppSettings["edi_cod"]);
			//if (txtsCodEdificio.Text.Trim().Length<LengthCod && txtsCodEdificio.Text.Trim().Length>0) return;
			
			if (txtsCodEdificio.Text.Trim().Length==0)
			{
				ClearCampi();
				// Controllo che sia stata assegnata una funzione.
				if (DelegateCodiceEdificio1!=null && txtsCodEdificio.Text!="") 
				{
					DelegateCodiceServizio1();
					DelegateCodiceEdificio1(txtsCodEdificio.Text);
				}

				if (DelegateIDBLEdificio1!=null) 
					DelegateIDBLEdificio1("");

				return;
			}

			// Controllo che sia stata assegnata una funzione.
			if (DelegateCodiceEdificio1!=null) 
				DelegateCodiceEdificio1(txtsCodEdificio.Text);

			Classi.ClassiDettaglio.Edificio _MyEdificio = new WebCad.Classi.ClassiDettaglio.Edificio(Context.User.Identity.Name);

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			///creo i parametri
			///			
			S_Controls.Collections.S_Object s_bl_id = new S_Controls.Collections.S_Object();
			s_bl_id.ParameterName = "p_Bl_Id";
			s_bl_id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_bl_id.Direction = ParameterDirection.Input;
			s_bl_id.Size =8;
			s_bl_id.Index = 0;
			s_bl_id.Value = txtsCodEdificio.Text;
			_SCollection.Add(s_bl_id);

			S_Controls.Collections.S_Object s_Campus = new S_Controls.Collections.S_Object();
			s_Campus.ParameterName = "p_Campus";
			s_Campus.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_Campus.Direction = ParameterDirection.Input;
			s_Campus.Size=50; 
			s_Campus.Index = 2;
			s_Campus.Value = "";
			_SCollection.Add(s_Campus);

			DataSet _MyDs = _MyEdificio.GetData(_SCollection).Copy();  
		
			if (_MyDs.Tables[0].Rows.Count == 1)
			{
				DataRow _Dr = _MyDs.Tables[0].Rows[0];

				if (DelegateIDBLEdificio1!=null) 
					DelegateIDBLEdificio1(_Dr["ID"].ToString());

				this.hiddenidbl.Value=_Dr["ID"].ToString();

				this._Edificio.BlId = (string) _Dr["BL_ID"];
				this.lblBlId.Text = this._Edificio.BlId;

				if (_Dr["DENOMINAZIONE"] != DBNull.Value)
				{
					this._Edificio.Name = (string) _Dr["DENOMINAZIONE"];
					this.lblDenominazione.Text = this._Edificio.Name;
				}
				
				if (_Dr["INDIRIZZO"] != DBNull.Value)
				{
					this._Edificio.Address1 = (string) _Dr["INDIRIZZO"];
					this.lblIndirizzo.Text = this._Edificio.Address1;
				}
				if (_Dr["CAMPUS"] != DBNull.Value)
				{
					this._Edificio.Campus = (string) _Dr["CAMPUS"];
					this.txtRicerca.Text = this._Edificio.Campus;	
				}
				if (_Dr["COMUNE"] != DBNull.Value)
				{
					this._Edificio.City_Id = (string) _Dr["COMUNE"];
					this.lblComune.Text = this._Edificio.City_Id;	
				}
				if (_Dr["REFERENTE"] != DBNull.Value)
				{
					this._Edificio.Contact_Name = (string) _Dr["REFERENTE"];
					this.lblDitta.Text = this._Edificio.Contact_Name;	
				}
				if (_Dr["TELEFONO_REFERENTE"] != DBNull.Value)
				{
					this._Edificio.Contact_Phone = (string) _Dr["TELEFONO_REFERENTE"];
					this.lblTelefono.Text = this._Edificio.Contact_Phone;
				}
				if (_Dr["CENTRODICOSTO"] != DBNull.Value)
				{
					this._Edificio.Centro_Costo = (string) _Dr["CENTRODICOSTO"];
					this.lblCdC.Text = this._Edificio.Centro_Costo;
				}
				if (_Dr["EMAIL"] != DBNull.Value)
				{
					this._Edificio.Option2 = (string) _Dr["EMAIL"];
					this.lblEmail.Value  = this._Edificio.Option2;
				}
				
			}
			else
			{
				ClearCampi();
				
			}
		
		}
		private void ClearCampi()
		{
			

			this.hiddenidbl.Value= string.Empty;

			this.lblBlId.Text = string.Empty;

			this.lblDenominazione.Text =  string.Empty;
			
			this.lblIndirizzo.Text =  string.Empty;

			this.txtRicerca.Text =  string.Empty;	
		
			this.lblComune.Text =  string.Empty;	
		
			this.lblDitta.Text =  string.Empty;	
	
			this.lblTelefono.Text =  string.Empty;
			
			this.lblCdC.Text = string.Empty;

			this.lblEmail.Value=string.Empty;
		}


		
	}
}
