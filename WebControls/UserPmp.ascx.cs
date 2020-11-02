namespace TheSite.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	public delegate void DelegateCodicePMP(int Cod);

	/// <summary>
	///		Descrizione di riepilogo per UserPmp.
	/// </summary>
	public class UserPmp : System.Web.UI.UserControl
	{
		protected S_Controls.S_TextBox txtmatricola;
		public string idTextRicMat=string.Empty;
		protected S_Controls.S_TextBox txtdescrizione;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtid;
		public string idModuloMat=string.Empty;
		public string idEqStd=string.Empty;

		public DelegateCodicePMP DelegateCodicePMP1;


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.						
			idTextRicMat=txtmatricola.ClientID;
			idModuloMat=this.ClientID;			
			txtdescrizione.Attributes.Add("readonly","");
			Classi.SiteJavaScript.ShowFramePMP(Page,1);
		}

		public S_Controls.S_TextBox Codice
		{
			get {return txtmatricola;}
		}
	
		public S_Controls.S_TextBox Descrizione
		{
			get {return txtdescrizione;}
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
			this.txtmatricola.TextChanged += new System.EventHandler(this.txtmatricola_TextChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion		

		private void txtmatricola_TextChanged(object sender, System.EventArgs e)
		{
			if (txtmatricola.Text.Trim()=="")
			{
				txtid.Value="0";
				txtdescrizione.Text="";
				// Controllo che sia stata assegnata una funzione.
				if (DelegateCodicePMP1!=null) 
					DelegateCodicePMP1(Int32.Parse(txtid.Value));				
			}
			else
			{
				Execute();
			}
		}
	
		public S_Controls.S_TextBox Matricola
		{
			get {return txtmatricola;}
		}

		public System.Web.UI.HtmlControls.HtmlInputHidden CodiceNum
		{
			get {return txtid;}
		}

		private void Execute()
		{
			Classi.ManProgrammata.ProcAndSteps _PMP = new TheSite.Classi.ManProgrammata.ProcAndSteps();

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();			
			S_Controls.Collections.S_Object s_pmp_id = new S_Controls.Collections.S_Object();
			s_pmp_id.ParameterName = "p_Id";
			s_pmp_id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_pmp_id.Direction = ParameterDirection.Input;
			s_pmp_id.Size =8;
			s_pmp_id.Index = 0;
			s_pmp_id.Value = txtmatricola.Text;
			_SCollection.Add(s_pmp_id);
			
			S_Controls.Collections.S_Object s_eqstd_id = new S_Controls.Collections.S_Object();
			s_eqstd_id.ParameterName = "p_idEqst";
			s_eqstd_id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_eqstd_id.Direction = ParameterDirection.Input;
			s_eqstd_id.Size =8;
			s_eqstd_id.Index = 1;
			s_eqstd_id.Value = 0;
			_SCollection.Add(s_eqstd_id);

			S_Controls.Collections.S_Object s_servizio_id = new S_Controls.Collections.S_Object();
			s_servizio_id.ParameterName = "p_idServizio";
			s_servizio_id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_servizio_id.Direction = ParameterDirection.Input;
			s_servizio_id.Size =8;
			s_servizio_id.Index = 2;
			s_servizio_id.Value = 0;
			_SCollection.Add(s_servizio_id);

			DataSet _MyDs = _PMP.GetAllPMP(_SCollection).Copy();  
			
			if (_MyDs.Tables[0].Rows.Count==1)
			{
				DataRow _Dr = _MyDs.Tables[0].Rows[0];
				txtdescrizione.Text= _Dr["descrizione"].ToString();
				txtmatricola.Text=_Dr["id"].ToString();
				txtid.Value=_Dr["idnumerico"].ToString();
			}

			// Controllo che sia stata assegnata una funzione.
			if (DelegateCodicePMP1!=null) 
				DelegateCodicePMP1(Int32.Parse(txtid.Value));				
			}
	}
}
