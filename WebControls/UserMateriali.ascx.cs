namespace TheSite.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using S_Controls.Collections;
	using ApplicationDataLayer.DBType;
	using TheSite.Classi.ManCorrettiva;
	using System.Globalization;

	
	/// <summary>
	///		Descrizione di riepilogo per UserMateriali.
	/// </summary>
	public class UserMateriali : System.Web.UI.UserControl
	{
		
		protected S_Controls.S_TextBox txtMateriale;
		protected HtmlInputHidden hidDettMat;
	
		public string TextRicMat;
		public string idTextRicMat;
		public string idModuloMat=string.Empty;
		protected S_Controls.S_TextBox txtquantita;
		protected S_Controls.S_TextBox txttotale;
		protected System.Web.UI.WebControls.Label lblunita;
		protected System.Web.UI.WebControls.Label lblprezzounitario;
		protected System.Web.UI.WebControls.ImageButton imbCancel;
		protected System.Web.UI.WebControls.ImageButton imbUpdate;
		protected S_Controls.S_TextBox txtid;
		protected S_Controls.S_TextBox lbldes;
		int idMateriale=0;
		protected S_Controls.S_TextBox txtwrdIn;
		protected S_Controls.S_TextBox txtwrid;
	
	
		public HtmlInputHidden HidDettMat
		{
			get {return hidDettMat;}
		}
		public S_Controls.S_TextBox TxtMateriali
		{
			get {return txtMateriale;}
			set	{txtMateriale=value;}
		}

		public S_Controls.S_TextBox Lbldes
		{
			get {return lbldes;}
			
		}
		public string DescrizioneMateriali
		{
			get {return txtMateriale.Text;}
			set	{txtMateriale.Text=value;}
		}
		public string UnitMisura
		{
			get {return lblunita.Text;}
			set	{lblunita.Text=value;}
		}

		public string DettaglioMat
		{
			get{return lbldes.Text;}
			set{lbldes.Text=value;}
		}
		public string idMat
		{
			get{return txtid.Text;}
			set{txtid.Text=value;}
		}
		
		public string wrId
		{
			get{return txtwrid.Text;}
			set{txtwrid.Text=value;}
		}

		public string wrIdIn
		{
			get{return txtwrdIn.Text;}
			set{txtwrdIn.Text=value;}
		}

		public string PrezzoUnitario
		{
			get{return lblprezzounitario.Text;}
			set{lblprezzounitario.Text=value;}
		}
		
		public string Quantita
		{
			get{return txtquantita.Text;}
			set{txtquantita.Text=value;}
		}

		public string Totale
		{
			get{return txttotale.Text;}
			set{txttotale.Text=value;}
		}

		public string Materiale
		{
			get{return lbldes.Text;}
			set{lbldes.Text=value;}
		}


		private void Page_Load(object sender, System.EventArgs e)
		{
							
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			TextRicMat=txtMateriale.ClientID;
			idModuloMat=this.ClientID;		
			txtquantita.Attributes.Add("onkeypress","SoloNumeri();");
				Classi.SiteJavaScript.ShowFrameMateriale(Page,1);
			
				if(lbldes.Text!="")
				{
					lblprezzounitario.Text=Convert.ToString(lbldes.Text.Split(';')[2]);
					lblunita.Text=Convert.ToString(lbldes.Text.Split(';')[1]);	
					idMateriale=Convert.ToInt32(lbldes.Text.Split(';')[0]);
				}

//				if(txtid.Text!="")				
//				{
//					ClManCorrettiva ioDati =new ClManCorrettiva();
//					DataSet DsMateriali = ioDati.getMaterialiId(Convert.ToInt32(txtid.Text)).Copy();
//					lbldes.Text=DsMateriali.Tables[0].Rows[0]["materiale"].ToString();
//					lblprezzounitario.Text=DsMateriali.Tables[0].Rows[0]["prezzo_unitario"].ToString();
//					lblunita.Text=DsMateriali.Tables[0].Rows[0]["unita"].ToString();
//					txtquantita.Text=DsMateriali.Tables[0].Rows[0]["quantita"].ToString();
//					txttotale.Text=DsMateriali.Tables[0].Rows[0]["totale"].ToString();
//					txtMateriale.Text=DsMateriali.Tables[0].Rows[0]["descr"].ToString();
//				
//				}
			
				string funzioneJsCalcolaTotale = "calcolaPrezzoTotale('"
					+ lblprezzounitario.ClientID + "','"
					+ txtquantita.ClientID + "','"
					+ txttotale.ClientID  + "');";
				txtquantita.Attributes.Add("onkeyup",funzioneJsCalcolaTotale);
				
			

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
			this.txtMateriale.TextChanged += new System.EventHandler(this.txtMateriale_TextChanged);
			this.imbUpdate.Click += new System.Web.UI.ImageClickEventHandler(this.imbUpdate_Click);
			this.imbCancel.Click += new System.Web.UI.ImageClickEventHandler(this.imbCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void txtMateriale_TextChanged(object sender, System.EventArgs e)
		{
		}

		private void imbCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}

		private void imbUpdate_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
            int id;
			Double prezzoUnitario=Convert.ToDouble(lblprezzounitario.Text);
			int quantita=Convert.ToInt32(txtquantita.Text);
			Double prezzoTotale=Convert.ToDouble(txttotale.Text);
			if (idMat=="")
			{
				id=0;
				int i_Result = EseguiDataBaseMateriale(id, Classi.ExecuteType.Insert,
					idMateriale, prezzoUnitario, quantita, prezzoTotale);
			}
			else
			{
				id=Convert.ToInt32(idMat);
				int i_Result = EseguiDataBaseMateriale(id, Classi.ExecuteType.Update,
					idMateriale, prezzoUnitario, quantita, prezzoTotale);
			}
		}

		private int  EseguiDataBaseMateriale(int id, Classi.ExecuteType Operazione, 
			int idMateriale, double  prezzoUnitario, int quantita, double prezzoTotale)
		{
			int idwr=0;
			if (Operazione.ToString()=="Insert")
				idwr=Convert.ToInt32(txtwrdIn.Text);
			else
				idwr=Convert.ToInt32(txtwrid.Text);
			int i_Result = 0;
			ClManCorrettiva ioDati = new ClManCorrettiva();
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			int cntParametro = 0;

			S_Object pId = new S_Object(); 
			pId.ParameterName = "p_ID";
			pId.DbType = CustomDBType.Integer;
			pId.Direction = ParameterDirection.Input;
			pId.Index = cntParametro++;
			pId.Value = id;
			_SCollection.Add(pId);

			S_Object pIdwr = new S_Object();
			pIdwr.ParameterName = "p_WrId";
			pIdwr.DbType = CustomDBType.Integer;
			pIdwr.Direction = ParameterDirection.Input;
			pIdwr.Index = cntParametro++;
			pIdwr.Value =idwr;
			_SCollection.Add(pIdwr);

			S_Object pIdMateriale = new S_Object();
			pIdMateriale.ParameterName = "p_IdMateriale";
			pIdMateriale.DbType = CustomDBType.Integer;
			pIdMateriale.Direction = ParameterDirection.Input;
			pIdMateriale.Index = cntParametro++;
			pIdMateriale.Value = idMateriale;
			_SCollection.Add(pIdMateriale);

			S_Object pPrezzoUnitario = new S_Object();
			pPrezzoUnitario.ParameterName = "p_PrezzoUnitario";
			pPrezzoUnitario.DbType = CustomDBType.Double;
			pPrezzoUnitario.Direction = ParameterDirection.Input;
			pPrezzoUnitario.Index = cntParametro++;
			pPrezzoUnitario.Value = prezzoUnitario;
			_SCollection.Add(pPrezzoUnitario);

			S_Object pQuantita = new S_Object();
			pQuantita.ParameterName = "p_Quantita";
			pQuantita.DbType = CustomDBType.Integer;
			pQuantita.Direction = ParameterDirection.Input;
			pQuantita.Index = cntParametro++;
			pQuantita.Value = quantita;
			_SCollection.Add(pQuantita);
			
			S_Object pTotale = new S_Object();
			pTotale.ParameterName = "p_Totale";
			pTotale.DbType = CustomDBType.Double;
			pTotale.Direction = ParameterDirection.Input;
			pTotale.Index = cntParametro++;
			pTotale.Value = prezzoTotale;
			_SCollection.Add(pTotale);

			i_Result = ioDati.ExecuteMateriali(_SCollection, Operazione);				
			return i_Result;
		}
	}
}
