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
using S_Controls.Collections;


namespace TheSite.Admin
{
	/// <summary>
	/// Descrizione di riepilogo per RuoliEdifici.
	/// </summary>
	public class RuoliEdifici : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected S_Controls.S_ComboBox cmbsProvincia;
		protected S_Controls.S_ComboBox cmbsComune;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		protected System.Web.UI.WebControls.Button btnAssociaF;
		protected System.Web.UI.WebControls.Button btnEliminaF;
		protected System.Web.UI.WebControls.ListBox ListBoxRightF;
		protected S_Controls.S_Button btnsSalva;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.CheckBoxList ListBoxLeftF;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
	
		public static string HelpLink = string.Empty;
	
		int itemId = 0;
		protected System.Web.UI.WebControls.Button BtnFiltra;
		protected S_Controls.S_ComboBox cmbsDitta;
		protected S_Controls.S_ComboBox cmbsServizi;
		protected S_Controls.S_TextBox txtsCampus;
		protected S_Controls.S_TextBox txtsCodice;
		protected System.Web.UI.WebControls.CheckBox ChkSelezionaLeft;
		protected System.Web.UI.WebControls.CheckBox ChkSelezionaTuttiRigth;
		protected System.Web.UI.WebControls.Label LblEdifici;
		protected System.Web.UI.WebControls.Label LblEdificiAssociati;
		protected System.Web.UI.WebControls.Label LblRuolo;
		int FunId = 0;
		protected System.Web.UI.WebControls.Label LblTitolo;
		protected System.Web.UI.WebControls.Button btnAssociaServizi;
		string descrizione = String.Empty;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			FunId = Int32.Parse(Request.Params["FunId"]);			

			if (Request.Params["ItemId"] != null) 
			{
				itemId = Int32.Parse(Request.Params["ItemId"]);				
			}
			if (Request.Params["descr"] != null) 
			{
				descrizione = Request.Params["descr"];				
			}

			if (!Page.IsPostBack )
			{	
				//InizializzaControlliClient();
				
				LblRuolo.Text=descrizione;
				CaricaListaRight();
				BindProvince();	
				BindDitte();	
				BindServizi();
				ImpostaCheck();
				if (cmbsProvincia.SelectedIndex >= 1)
					BindComuni();
			
				this.lblOperazione.Text = "Associazione Ruoli Edifici";
				
				this.lblFirstAndLast.Visible = false;					
				//ImpostaProvinciaDefault("CT","- Selezionare un Comune -");
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
			}
		}		

		#region FunzioniPrivate

		private void InserisciAssociazioni()
		{
			DataTable o_Dt = (DataTable) Session["Edifici"];			
			
			try
			{
			
				foreach(DataRow riga in o_Dt.Rows)
				{	
					bool esegui=false;
					string funzione = "";
					int valore=0;
				
					if (riga.RowState==DataRowState.Deleted)
					{
						funzione = "Delete";		
						esegui=true;
						valore=Convert.ToInt32(riga["id",DataRowVersion.Original].ToString());
					}
				
					if (riga.RowState==DataRowState.Added)
					{
						funzione = "Insert";	
						esegui=true;
						valore=Convert.ToInt32(riga["id",DataRowVersion.Default].ToString());
					}
				
					if (esegui)
					{
						Classi.ClassiDettaglio.Edificio _Edificio = new TheSite.Classi.ClassiDettaglio.Edificio(Context.User.Identity.Name);
					
						S_Controls.Collections.S_ControlsCollection _SColl = new S_Controls.Collections.S_ControlsCollection();

						S_Controls.Collections.S_Object s_Ruolo = new S_Controls.Collections.S_Object();
						s_Ruolo.ParameterName = "p_Ruolo_Id";
						s_Ruolo.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
						s_Ruolo.Direction = ParameterDirection.Input;
						s_Ruolo.Index = 0;
						s_Ruolo.Value = itemId;

						S_Controls.Collections.S_Object s_Edificio_Id = new S_Controls.Collections.S_Object();
						s_Edificio_Id.ParameterName = "p_Edificio_Id";
						s_Edificio_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
						s_Edificio_Id.Direction = ParameterDirection.Input;
						s_Edificio_Id.Index = 1;
						s_Edificio_Id.Value = valore;		
					
						S_Controls.Collections.S_Object s_Operazione = new S_Object();
						s_Operazione.ParameterName = "p_Operazione";
						s_Operazione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
						s_Operazione.Direction = ParameterDirection.Input;
						s_Operazione.Index=2;
						s_Operazione.Value = funzione;		

						S_Controls.Collections.S_Object s_IdOut = new S_Object();
						s_IdOut.ParameterName = "p_IdOut";
						s_IdOut.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
						s_IdOut.Direction = ParameterDirection.Output;
						s_IdOut.Index = 3;

						_SColl.Add(s_Ruolo);
						_SColl.Add(s_Edificio_Id);
						_SColl.Add(s_Operazione);
						_SColl.Add(s_IdOut);			
						_Edificio.UpdateRuoliEdifici(_SColl);
					}			
				}
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);								
			}	
		}
		private void CaricaListaRight()
		{
			Classi.ClassiDettaglio.Edificio _Edificio = new TheSite.Classi.ClassiDettaglio.Edificio(Context.User.Identity.Name);
			DataSet _MyDs = _Edificio.GetRuoliEdifici(itemId);
			
			// Imposto la chiave primaria
			_MyDs.Tables[0].Columns[ "id" ].Unique = true;
			_MyDs.Tables[0].PrimaryKey = new DataColumn[] { _MyDs.Tables[0].Columns["id"] };

			Session.Add("Edifici", _MyDs.Tables[0]);
			
			if (_MyDs.Tables[0].Rows.Count > 0) 
			{
				DataView o_DvEdifici = new DataView(_MyDs.Tables[0]);			
				this.ListBoxRightF.DataTextField="descrizione";
				this.ListBoxRightF.DataValueField="id";
				this.ListBoxRightF.DataSource=o_DvEdifici;
				this.ListBoxRightF.DataBind();				
			}


			string totrecord = _MyDs.Tables[0].Rows.Count.ToString();
			LblEdificiAssociati.Text=totrecord;
		}
		private void CaricaListaLeft()
		{
			this.txtsCampus.DBDefaultValue = "%";
			this.txtsCodice.DBDefaultValue = "%";
			
			this.cmbsProvincia.DBDefaultValue="0";
			this.cmbsComune.DBDefaultValue="0";
			this.cmbsServizi.DBDefaultValue="0";
			this.cmbsDitta.DBDefaultValue="0";
			
			this.txtsCampus.Text=this.txtsCampus.Text.Trim();
			this.txtsCodice.Text=this.txtsCodice.Text.Trim();

			S_ControlsCollection _SCollection = new S_ControlsCollection();		
			_SCollection.AddItems(this.PanelEdit.Controls);
			
			Classi.ClassiDettaglio.Edificio _Edificio = new TheSite.Classi.ClassiDettaglio.Edificio(Context.User.Identity.Name);			
			DataSet _MyDs = _Edificio.GetListaEdifici(_SCollection,itemId).Copy();
			
			if (_MyDs.Tables[0].Rows.Count>0)
			{
				if (_MyDs.Tables[0].Rows.Count > 0) 
				{
					DataView o_DvEdifici = new DataView(_MyDs.Tables[0]);			
					this.ListBoxLeftF.DataTextField="descrizione";
					this.ListBoxLeftF.DataValueField="id";
					this.ListBoxLeftF.DataSource=o_DvEdifici;
					this.ListBoxLeftF.DataBind();				
				}
			}			
			
			ImpostaEventoCheckClient();			

			string totrecord = _MyDs.Tables[0].Rows.Count.ToString();
			LblEdifici.Text=totrecord;
			ImpostaCheck();
		}
		private void BindServizi()
		{
			Classi.ClassiDettaglio.Servizi _Servizi = new TheSite.Classi.ClassiDettaglio.Servizi(HttpContext.Current.User.Identity.Name);
			
			DataSet _MyDs = _Servizi.GetData().Copy();									
				
			this.cmbsServizi.Items.Clear();
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsServizi.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "idservizio", "- Selezionare un Servizio -", "");
				this.cmbsServizi.DataTextField = "descrizione";
				this.cmbsServizi.DataValueField = "idservizio";
				this.cmbsServizi.DataBind();
			}
		}
		private void BindDitte()
		{
		Classi.ClassiAnagrafiche.Ditte _Ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
			
		DataSet _MyDs = _Ditte.GetData().Copy();									
				
		this.cmbsDitta.Items.Clear();
			
		if (_MyDs.Tables[0].Rows.Count > 0)
		{
			this.cmbsDitta.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
				_MyDs.Tables[0], "descrizione", "id", "- Selezionare una Ditta -", "");
			this.cmbsDitta.DataTextField = "descrizione";
			this.cmbsDitta.DataValueField = "id";
			this.cmbsDitta.DataBind();
		}			

		}	
		private void ImpostaProvinciaDefault(string provincia,string comune)
		{
			ListItem crItemp = cmbsProvincia.Items.FindByText(provincia);			
			cmbsProvincia.SelectedValue= crItemp.Value;			
			BindComuni();
			ListItem crItemc = cmbsComune.Items.FindByText(comune);			
			cmbsComune.SelectedValue=crItemc.Value;
		}
		private void BindProvince()
		{
			
			this.cmbsProvincia.Items.Clear();
		
			Classi.ProvinceComuni _ProvCom = new TheSite.Classi.ProvinceComuni();
				
			DataSet _MyDs = _ProvCom.GetData().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsProvincia.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione_breve", "provincia_id", "- Selezionare una Provincia -", "");
				this.cmbsProvincia.DataTextField = "descrizione_breve";
				this.cmbsProvincia.DataValueField = "provincia_id";
				this.cmbsProvincia.DataBind();
			}			
		}

		private void Disassocia()
		{
			DataTable myTableEdifici = new DataTable("Edifici");
			DataColumn IdItem = new DataColumn("id",Type.GetType("System.String"));
			DataColumn DescrItem = new DataColumn("descrizione",Type.GetType("System.String"));
			myTableEdifici.Columns.Add(IdItem);
			myTableEdifici.Columns.Add(DescrItem);
			DataTable o_Dt = (DataTable) Session["Edifici"];			
			//Aggiungo Alla DataTable tutti gli elementi della lista di destra 
			foreach (ListItem lista in ListBoxRightF.Items)
			{
				if (lista.Selected==true) 
				{	
					DataRow Riga = myTableEdifici.NewRow();
					Riga["id"]=lista.Value;
					Riga["descrizione"]=lista.Text;
					myTableEdifici.Rows.Add(Riga);
					myTableEdifici.AcceptChanges();

					// Memorizzo gli elementi selezionati nel DataTable				
					string filtro = "id=" + lista.Value;
					DataRow[] _Dr =  o_Dt.Select(filtro);										
					_Dr[0].Delete();
				}
			}

			Session.Remove("Edifici");
			Session.Add("Edifici", o_Dt);
			
			// Elimino dalla lista di destra tutte le righe
			foreach (DataRow Riga in myTableEdifici.Rows) 
			{				
				string id =Riga["id"].ToString();
				string descr = Riga["descrizione"].ToString();
				ListItem el = new ListItem(descr,id);
				ListBoxRightF.Items.Remove(el);				
			}

			//Aggiungo Alla DataTable tutti gli elementi della lista di sinistra 
			
			foreach (ListItem lista in ListBoxLeftF.Items)
			{											
				DataRow Riga = myTableEdifici.NewRow();
				Riga["id"]=lista.Value;
				Riga["descrizione"]=lista.Text;
				myTableEdifici.Rows.Add(Riga);
				myTableEdifici.AcceptChanges();
			}
			
			DataView o_DvEdifici = new DataView(myTableEdifici);
			
			o_DvEdifici.Sort="descrizione ASC";
			
			this.ListBoxLeftF.DataTextField="descrizione";
			this.ListBoxLeftF.DataValueField="id";
			this.ListBoxLeftF.DataSource=o_DvEdifici;
			this.ListBoxLeftF.DataBind();		
		}

		private void Associa()
		{	
			int tot = ListBoxLeftF.Items.Count;
			
			ArrayList Arr_Elementi = new ArrayList(); 
			
			DataTable o_Dt = (DataTable) Session["Edifici"];

			// Sposto gli elementi selezionati nella lista di destra
			foreach (ListItem lista in ListBoxLeftF.Items) 
			{				
				if (lista.Selected)
				{
					string s_strSelection = lista.Text;
					string s_strSelectionValue = lista.Value;
				
					ListItem o_Li = new ListItem(s_strSelection, s_strSelectionValue);
					ListBoxRightF.Items.Add(o_Li);
					ListBoxRightF.SelectedIndex = 0;
					lista.Selected=false;
					// Memorizzo gli elementi selezionati in un Array
					Arr_Elementi.Add(o_Li);		
					
					// Memorizzo gli elementi selezionati nel DataTable					
					DataRow _Dr = o_Dt.NewRow();
					_Dr["Id"]=s_strSelectionValue;
					_Dr["Descrizione"]=s_strSelection;
					o_Dt.Rows.Add(_Dr);					
				}
				Session.Remove("Edifici");
				Session.Add("Edifici", o_Dt);
			}			

			//Elimino gli selezionati dalla lista di sinistra
			for (int i=0;i<Arr_Elementi.Count;i++)
			{				
				ListItem el = (ListItem)Arr_Elementi[i];
				ListBoxLeftF.Items.Remove(el);						
			}

		}	
		private void ImpostaCheck()
		{
			ChkSelezionaLeft.Checked=false;
			ChkSelezionaLeft.Text="Seleziona Tutti";
			ChkSelezionaTuttiRigth.Checked=false;
			ChkSelezionaTuttiRigth.Text="Seleziona Tutti";
			
			if (ListBoxLeftF.Items.Count>0)
			{
				ChkSelezionaLeft.Visible=true;
			}
			else
			{
				ChkSelezionaLeft.Visible=false;
			}

			if (ListBoxRightF.Items.Count>0)
			{
				ChkSelezionaTuttiRigth.Visible=true;
			}
			else
			{
				ChkSelezionaTuttiRigth.Visible=false;
			}
			LblEdifici.Text=ListBoxLeftF.Items.Count.ToString();
			LblEdificiAssociati.Text=ListBoxRightF.Items.Count.ToString();
	
		}
		private void BindComuni()
		{
			
			this.cmbsComune.Items.Clear();
		
			Classi.ProvinceComuni _ProvCom = new TheSite.Classi.ProvinceComuni();
			
			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Provid = new S_Object();			
			s_Provid.ParameterName = "p_provincia_id";
			s_Provid.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer; 
			s_Provid.Direction = ParameterDirection.Input;			
			s_Provid.Index = 0;
			s_Provid.Value = cmbsProvincia.SelectedValue;
			
			_SColl.Add(s_Provid);
						
			DataSet _MyDs = _ProvCom.GetComune(_SColl).Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsComune.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "comune_id", "- Selezionare un Comune -", "");
				this.cmbsComune.DataTextField = "descrizione";
				this.cmbsComune.DataValueField = "comune_id";
				this.cmbsComune.DataBind();
			}	
		}	
		private void ImpostaEventoCheckClient()
		{
			foreach (ListItem lista in ListBoxLeftF.Items)
			{	
				lista.Attributes.Add("onclick","javascript:alert('ciao')");												
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
			this.cmbsProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbsProvincia_SelectedIndexChanged);
			this.BtnFiltra.Click += new System.EventHandler(this.BtnFiltra_Click);
			this.btnAssociaF.Click += new System.EventHandler(this.btnAssociaF_Click);
			this.btnEliminaF.Click += new System.EventHandler(this.btnEliminaF_Click);
			this.ChkSelezionaLeft.CheckedChanged += new System.EventHandler(this.ChkSelezionaLeft_CheckedChanged);
			this.ChkSelezionaTuttiRigth.CheckedChanged += new System.EventHandler(this.ChkSelezionaTuttiRigth_CheckedChanged);
			this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			this.btnAssociaServizi.Click += new System.EventHandler(this.btnAssociaServizi_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		

		private void cmbsProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbsProvincia.SelectedIndex>0)
				BindComuni();
			else
				this.cmbsComune.Items.Clear();
		}

		private void BtnFiltra_Click(object sender, System.EventArgs e)
		{
			ListBoxLeftF.Items.Clear();
			//ListBoxRightF.Items.Clear();
			CaricaListaLeft();
		}

		private void btnAssociaF_Click(object sender, System.EventArgs e)
		{
			Associa();
			ImpostaCheck();
		}
		

		private void btnEliminaF_Click(object sender, System.EventArgs e)
		{
			Disassocia();
			ImpostaCheck();
		}		

		private void ChkSelezionaLeft_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ChkSelezionaLeft.Checked==false)
			{
				foreach (ListItem lista in ListBoxLeftF.Items) 
				{		
					lista.Selected=false;											
				}
				ChkSelezionaLeft.Text="Seleziona Tutti";				
			}
			else
			{
				foreach (ListItem lista in ListBoxLeftF.Items) 
				{		
					lista.Selected=true;											
					ChkSelezionaLeft.Text="Deseleziona Tutti";
				}	
			}
		}

		private void ChkSelezionaTuttiRigth_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ChkSelezionaTuttiRigth.Checked==false)
			{
				foreach (ListItem lista in ListBoxRightF.Items) 
				{		
					lista.Selected=false;											
				}
				ChkSelezionaTuttiRigth.Text="Seleziona Tutti";				
			}
			else
			{
				foreach (ListItem lista in ListBoxRightF.Items) 
				{		
					lista.Selected=true;											
					ChkSelezionaTuttiRigth.Text="Deseleziona Tutti";
				}		

			}
		}

		private void btnsSalva_Click(object sender, System.EventArgs e)
		{			
			InserisciAssociazioni();
			Session.Remove("Edifici");
			CaricaListaLeft();
			CaricaListaRight();	        
		}

		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			//Response.Redirect((String) ViewState["UrlReferrer"]);
			Response.Redirect("Ruoli.aspx?FunId="+FunId);
		}

		private void btnAssociaServizi_Click(object sender, System.EventArgs e)
		{
			string _urlpage = "RuoliEdificiServizi.aspx?itemId="+itemId+"&descr="+LblRuolo.Text;
			Response.Redirect(_urlpage);
		}

								
	}
}
