namespace TheSite.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using S_Controls;
	using S_Controls.Collections;

	public delegate void DelegateCodiceRDL(string Cod);
	public delegate void DelegateIDRDL(string Cod);
	//public delegate void DelegateIDBLEdificio1(string Cod);

	/// <summary>
	///		Descrizione di riepilogo per RicercaModulo.
	/// </summary>
	public class RicercaRDL : System.Web.UI.UserControl
	{
		//private Classi.ClassiDettaglio.Edificio _Edificio = new TheSite.Classi.ClassiDettaglio.Edificio("");
		
		public string idTextCod;
		public string idTextRic;
		public string idTextRicA;
		public string idModulo;
		//MDI
		public string operazione;

		//
		public string multisele;
		protected System.Web.UI.WebControls.Panel PanelDettagli;
		protected S_Controls.S_TextBox txtsRDL;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenidRDL;
		public DelegateCodiceRDL DelegateCodiceRDL1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		public DelegateIDRDL DelegateIDRDL1;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;		
		private void Page_Load(object sender, System.EventArgs e)
		{
            
			Classi.SiteJavaScript.ShowFrameRDL(Page,1);   
			idTextCod=txtsRDL.ClientID;
			idTextRic=CalendarPicker1.Datazione.ClientID;
			idTextRicA=CalendarPicker2.Datazione.ClientID;
			idModulo=this.ClientID;	
			
	
			//MODIFICA
			if (!IsPostBack)
			{
				Ricarica();
				CompareValidator1.ControlToValidate = CalendarPicker2.ID + ":" + CalendarPicker2.Datazione.ID;
				CompareValidator1.ControlToCompare =  CalendarPicker1.ID + ":" + CalendarPicker1.Datazione.ID;
		
			}
			//txtsRDL.Attributes.Add("onchange","Verifica(this);");
		}

		#region Proprietà
		//modifica marianna per distinguere inserimento da ricerca fattura
		public string opera
		{
			get {return operazione;}
			set	{operazione=value;}
		}
		/// Ottiene imposta il Nome della combo tipo manutenzione
		/// </summary>
		public string NameComboMan
		{
			get 
			{
				if( ViewState["cmbsServizio"]==null)
					return string.Empty;
				else
					return (string)ViewState["cmbsServizio"];
			}
			set 
			{
				ViewState["cmbsServizio"] = value;
			}
		}
		//fine

		public string TipoMan
		{
			get 
		{
			if( ViewState["TipoMan"]==null)
			return string.Empty;
			else
			return (string)ViewState["TipoMan"];
		}
			set 
		{
			ViewState["TipoMan"] = value;
		}
			
		}

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

		
		public  S_Controls.S_TextBox TxtRicerca
		{
			get {return  CalendarPicker1.Datazione;}
		}

		
		public string IdRDL
		{
			get 
			{
				if (hiddenidRDL.Value.Length > 0)
					return hiddenidRDL.Value;
				else
					return string.Empty;
			}
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
			this.txtsRDL.TextChanged += new System.EventHandler(this.txtsRDL_TextChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		

		

		public void Ricarica()
		{
			int LengthCod=int.Parse(System.Configuration.ConfigurationSettings.AppSettings["edi_cod"]);
			if (txtsRDL.Text.Trim().Length!=LengthCod && txtsRDL.Text.Trim().Length>0) return;
			if (txtsRDL.Text.Trim().Length==0)
			{
				ClearCampi();
				// Controllo che sia stata assegnata una funzione.
				if (DelegateCodiceRDL1!=null) 
					DelegateCodiceRDL1(txtsRDL.Text);

				if (DelegateIDRDL1!=null) 
					DelegateIDRDL1("");

				return;
			}

			// Controllo che sia stata assegnata una funzione.
			if (DelegateCodiceRDL1!=null) 
				DelegateCodiceRDL1(txtsRDL.Text);

			Classi.ManOrdinaria.GestioneRdl _GestioneRdl = new Classi.ManOrdinaria.GestioneRdl(HttpContext.Current.User.Identity.Name);

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			///creo i parametri
			///			
			S_Controls.Collections.S_Object s_wr_id = new S_Controls.Collections.S_Object();
			s_wr_id.ParameterName = "p_wr_id";
			s_wr_id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_wr_id.Direction = ParameterDirection.Input;
			s_wr_id.Size =50;
			s_wr_id.Index = 0;
			s_wr_id.Value = txtsRDL.Text;
			_SCollection.Add(s_wr_id);

			

			DataSet _MyDs = _GestioneRdl.GetRDL1(_SCollection).Copy();  
		
			if (_MyDs.Tables[0].Rows.Count == 1)
			{
				DataRow _Dr = _MyDs.Tables[0].Rows[0];

				if (DelegateIDRDL1!=null) 
					DelegateIDRDL1(_Dr["ID"].ToString());

				this.hiddenidRDL.Value=_Dr["ID"].ToString();

			
				if (_Dr["descrizione"] != DBNull.Value)
				{
					CalendarPicker1.Datazione.Text = (string) _Dr["descrizione"];				
				}
			
											
			}
			else
			{
				ClearCampi();
				
			}
		
		}
		private void ClearCampi()
		{
			

			this.hiddenidRDL.Value= string.Empty;				
			CalendarPicker1.Datazione.Text =  string.Empty;	
			CalendarPicker2.Datazione.Text =  string.Empty;	
		
	
		}

		private void txtsRDL_TextChanged(object sender, System.EventArgs e)
		{
		Ricarica();
		}

		


		
	}
}
