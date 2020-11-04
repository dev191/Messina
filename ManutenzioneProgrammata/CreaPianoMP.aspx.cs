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
using ApplicationDataLayer.DBType;
using MyCollection;
using System.Reflection;


namespace TheSite.ManutenzioneProgrammata
{
	public enum resultSchedula
	{
		NO_PROCED_MAN = 0, GIA_SCHEDULATO = 1 ,NO_ADD_SPECIALIZZATO = 2, DATA_FUORI_INTERVALLO = 3,
		NO_STAGIONALE = 4 , SCHEDULAZIONE_OK = 5, NO_FREQ_FISSE = 6 };

	/// <summary>
	/// Descrizione di riepilogo per CreaPianoMP.
	/// </summary>
	public class CreaPianoMP : System.Web.UI.Page
	{
		
		protected S_Controls.S_ComboBox cmbsAnnoA;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_ComboBox cmbsDitta;
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.RicercaModulo RicercaModulo1;	
		protected WebControls.Addetti Addetti1;	

		public static string HelpLink = string.Empty;
		public static int FunId = 0;
		protected S_Controls.S_ComboBox cmbsAddettoCompl;
		protected S_Controls.S_Button btnsCompletaOdl;
		protected S_Controls.S_ComboBox cmbsAddettoMod;
		protected S_Controls.S_Button btnsModificaODL;
		protected S_Controls.S_Button btnSChiudi;
		protected Csy.WebControls.DataPanel DatapanelCompleta;
		protected S_Controls.S_Button btnsCrea;
		protected S_Controls.S_Button btnsSelezionaTutti;
		protected S_Controls.S_Button btnsDeSelezionaTutti;
		protected S_Controls.S_Button btnsConfermaSelezioni;
		protected System.Web.UI.WebControls.Label LblElementiSelezionati;
		protected System.Web.UI.WebControls.TextBox txtTotSelezionati;
		protected WebControls.PageTitle PageTitle1;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected System.Web.UI.WebControls.Panel PanelCrea;	
		resultSchedula   pippo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			RicercaModulo1.DelegateCodiceEdificio1 = new TheSite.WebControls.DelegateCodiceEdificio(this.BindServizi);
			
			//Imposto le funzioni client per non effettuare il PostBack
			this.btnsRicerca.Attributes.Add("onclick","Valorizza('0')");
			this.btnsConfermaSelezioni.Attributes.Add("onclick","Valorizza('0')");
			this.btnsSelezionaTutti.Attributes.Add("onclick","Valorizza('0')");
			this.btnsDeSelezionaTutti.Attributes.Add("onclick","Valorizza('0')");
			this.btnsCrea.Attributes.Add("onclick","Valorizza('1')");

			//FunId = _SiteModule.ModuleId;
			HelpLink = ""; //_SiteModule.HelpLink;
			this.PageTitle1.Title = "Crea Piano di Manutenzione Programmata"; //_SiteModule.ModuleTitle;
			this.GridTitle1.hplsNuovo.Visible = false;

//			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
//			//sbValid.Append("if (typeof(seledificio) == 'function') { ");
//			//sbValid.Append("if (seledificio() == false) { return false; }} ");
//			sbValid.Append("this.value = 'Attendere ...';");
//			sbValid.Append("this.disabled = true;");
//			sbValid.Append("document.getElementById('" + btnsRicerca.ClientID + "').disabled = true;");
//			sbValid.Append(this.Page.GetPostBackEventReference(this.btnsRicerca));
//			sbValid.Append(";");
//			this.btnsRicerca.Attributes.Add("onclick", sbValid.ToString());
//
//			new System.Text.StringBuilder();			
//			sbValid.Append("this.value = 'Attendere ...';");
//			sbValid.Append("this.disabled = true;");
//			sbValid.Append("document.getElementById('" + btnsCrea.ClientID + "').disabled = true;");
//			sbValid.Append(this.Page.GetPostBackEventReference(this.btnsCrea));
//			sbValid.Append(";");
//			this.btnsCrea.Attributes.Add("onclick", sbValid.ToString());
//
//			new System.Text.StringBuilder();			
//			sbValid.Append("this.value = 'Attendere ...';");
//			sbValid.Append("this.disabled = true;");
//			sbValid.Append("document.getElementById('" + btnsConfermaSelezioni.ClientID + "').disabled = true;");
//			sbValid.Append(this.Page.GetPostBackEventReference(this.btnsConfermaSelezioni));
//			sbValid.Append(";");
//			this.btnsConfermaSelezioni.Attributes.Add("onclick", sbValid.ToString());
//
//			new System.Text.StringBuilder();			
//			sbValid.Append("this.value = 'Attendere ...';");
//			sbValid.Append("this.disabled = true;");
//			sbValid.Append("document.getElementById('" + btnsSelezionaTutti.ClientID + "').disabled = true;");
//			sbValid.Append(this.Page.GetPostBackEventReference(this.btnsSelezionaTutti));
//			sbValid.Append(";");
//			this.btnsSelezionaTutti.Attributes.Add("onclick", sbValid.ToString());
//
//			new System.Text.StringBuilder();			
//			sbValid.Append("this.value = 'Attendere ...';");
//			sbValid.Append("this.disabled = true;");
//			sbValid.Append("document.getElementById('" + btnsDeSelezionaTutti.ClientID + "').disabled = true;");
//			sbValid.Append(this.Page.GetPostBackEventReference(this.btnsDeSelezionaTutti));
//			sbValid.Append(";");
//			this.btnsDeSelezionaTutti.Attributes.Add("onclick", sbValid.ToString());

			if (!Page.IsPostBack)
			{	
				
				BindControls();														
				LblElementiSelezionati.Text="Elementi Selezionati - 0 -";
				txtTotSelezionati.Text="0";				
				BindControls();		
				Session.Remove("CheckedList");
				Session.Remove("DatiList");
				Session.Remove("DataSet");			
			}		
		}

		#region Funzioni Private
		private void CaricaCombiAnni()
		{
			string anno_corrente = DateTime.Now.Year.ToString();
			for (int i = 1999; i <= 2099; i++)
			{ 	
				ListItem _L1 = new ListItem();
				ListItem _L2 = new ListItem();
				_L1.Text=i.ToString();
				_L1.Value=i.ToString();
				_L2.Text=i.ToString();
				_L2.Value=i.ToString();
				cmbsAnnoA.Items.Add(_L1);				
			}
		
			cmbsAnnoA.SelectedValue=anno_corrente;
		}
		
		private void BindControls()
		{
			CaricaCombiAnni();
			BindServizi("");
		}
	
		private void BindAddetti(string idbl)
		{
			int id_ditta=0;
			if (cmbsDitta.SelectedValue!="")
			{
				id_ditta=Int32.Parse(cmbsDitta.SelectedValue);
			}			
			// Carico Gli Addetti			
			Addetti1.Set_BL_ID_DITTA_ID(idbl,id_ditta);
		}

		private void CaricaDitte()
		{	
			int id_bl=0;
			string bl_id= RicercaModulo1.TxtCodice.Text;
			// Carico Le Ditte
			if (bl_id !="")
			{				
				// Mi recupero l'idbl
				DataSet _MyDsDittaBl;
				Classi.Function _Fun = new TheSite.Classi.Function();
				_MyDsDittaBl= _Fun.GetIdBL(bl_id);								
				DataRow _DrBl = _MyDsDittaBl.Tables[0].Rows[0];
				id_bl= Int32.Parse(_DrBl[0].ToString());			
				BindDitte(id_bl);
			}
			else
			{
				id_bl=0;
				BindDitte(id_bl);
			}
		}

		private void BindServizi(string CodEdificio)
		{	
			CaricaDitte();
			BindAddetti(CodEdificio);

			this.cmbsServizio.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ClassiDettaglio.Servizi  _Servizio = new TheSite.Classi.ClassiDettaglio.Servizi(Context.User.Identity.Name);

			DataSet _MyDs;

			if (CodEdificio!="")
			{
				S_Controls.Collections.S_Object s_Bl_Id = new S_Object();
				s_Bl_Id.ParameterName = "p_Bl_Id";
				s_Bl_Id.DbType = CustomDBType.VarChar;
				s_Bl_Id.Direction = ParameterDirection.Input;
				s_Bl_Id.Index = 0;
				s_Bl_Id.Value =	CodEdificio;
				s_Bl_Id.Size = 8;

				
				S_Controls.Collections.S_Object s_ID_Servizio = new S_Object();
				s_ID_Servizio.ParameterName = "p_ID_Servizio";
				s_ID_Servizio.DbType = CustomDBType.Integer;
				s_ID_Servizio.Direction = ParameterDirection.Input;
				s_ID_Servizio.Index = 1;
				s_ID_Servizio.Value = 0;

				CollezioneControlli.Add(s_Bl_Id);				
				CollezioneControlli.Add(s_ID_Servizio);

				_MyDs = _Servizio.GetData(CollezioneControlli);
			}
			else
			{
				_MyDs = _Servizio.GetData();
			}

			if (_MyDs.Tables[0].Rows.Count > 0)
			{	
				this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "-- Tutti i Servizi --", "0");
				this.cmbsServizio.DataTextField = "DESCRIZIONE";
				this.cmbsServizio.DataValueField = "IDSERVIZIO";
				this.cmbsServizio.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Servizio -";
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		
		}

		private void BindDitte(int idbl)
		{	
			cmbsDitta.Items.Clear();			
			
			Classi.ClassiAnagrafiche.Ditte _Ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
			// Attraverso l'IDBL mi ricavo l'ID della Ditta
			int idditta=0;  
			if(idbl>0)
			{
				DataSet _MyDsDittaBl;
				_MyDsDittaBl=_Ditte.GetDittaBl(idbl);			
				DataRow _DrBl = _MyDsDittaBl.Tables[0].Rows[0];
				idditta= Int32.Parse(_DrBl["id_ditta"].ToString());			
			}
			else
			{
				idditta=0;
			}			
		
			DataSet _MyDs;
			_MyDs = _Ditte.GetDitteFornitoriRuoli(idditta);

			if (_MyDs.Tables[0].Rows.Count > 0)
			{	
				this.cmbsDitta.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "id", "-- Tutte Le Ditte --", "0");
				this.cmbsDitta.DataTextField = "DESCRIZIONE";
				this.cmbsDitta.DataValueField = "id";
				this.cmbsDitta.DataBind();
			}
			
			else
			{
				string s_Messagggio = "- Nessuna Ditta -";
				this.cmbsDitta.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}
		private S_Controls.Collections.S_ControlsCollection GetControl()
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();
			
			cmbsDitta.DBDefaultValue="0";
			cmbsServizio.DBDefaultValue="0";			
			
			// Ditta						
			int id_ditta=0;
			if(cmbsDitta.SelectedValue!="")
				id_ditta=Int32.Parse(cmbsDitta.SelectedValue);
			
			S_Controls.Collections.S_Object s_Ditta = new S_Object();

			s_Ditta.ParameterName = "p_id_ditta";
			s_Ditta.DbType = CustomDBType.Integer;
			s_Ditta.Direction = ParameterDirection.Input;
			s_Ditta.Index = 0;
			s_Ditta.Size=4;
			s_Ditta.Value=id_ditta;
			CollezioneControlli.Add(s_Ditta);				

			// Servizio						
			int id_servizio=0;
			if(cmbsServizio.SelectedValue!="")
				id_servizio=Int32.Parse(cmbsServizio.SelectedValue);
			
			S_Controls.Collections.S_Object s_Servizio = new S_Object();

			s_Servizio.ParameterName = "p_id_servizio";
			s_Servizio.DbType = CustomDBType.Integer;
			s_Servizio.Direction = ParameterDirection.Input;
			s_Servizio.Index = 1;
			s_Servizio.Size=4;
			s_Servizio.Value=id_servizio;
			CollezioneControlli.Add(s_Servizio);
			
			// BL_ID						
			
			S_Controls.Collections.S_Object s_BL = new S_Object();

			s_BL.ParameterName = "p_cod_edificio";
			s_BL.DbType = CustomDBType.VarChar;
			s_BL.Direction = ParameterDirection.Input;
			s_BL.Index = 2;
			s_BL.Size=20;
			s_BL.Value=RicercaModulo1.TxtCodice.Text.Trim();
			CollezioneControlli.Add(s_BL);

			// Addetto

			S_Controls.Collections.S_Object s_Addetto = new S_Object();

			s_Addetto.ParameterName = "p_addetto";
			s_Addetto.DbType = CustomDBType.VarChar;
			s_Addetto.Direction = ParameterDirection.Input;
			s_Addetto.Index = 3;
			s_Addetto.Size=4;
			s_Addetto.Value=Addetti1.NomeCompleto;
			CollezioneControlli.Add(s_Addetto);
				
			// Data A											
			int annoA = Int16.Parse(cmbsAnnoA.SelectedValue);	
			S_Controls.Collections.S_Object s_AnnoA = new S_Object();

			s_AnnoA.ParameterName = "p_anno";
			s_AnnoA.DbType = CustomDBType.Integer;
			s_AnnoA.Direction = ParameterDirection.Input;
			s_AnnoA.Index = 4;
			s_AnnoA.Size=10;
			s_AnnoA.Value=annoA;
			CollezioneControlli.Add(s_AnnoA);
	
			return CollezioneControlli;
		}
		private void Ricerca(bool reset)
		{	
			
			//Session.Remove("DataSet");

				
			S_Controls.Collections.S_ControlsCollection CollezioneControlli =GetControl();				

			S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
			s_p_pageindex.ParameterName = "pageindex";
			s_p_pageindex.DbType = CustomDBType.Integer;
			s_p_pageindex.Direction = ParameterDirection.Input;
			s_p_pageindex.Index = 16;
			s_p_pageindex.Value=DataGridRicerca.CurrentPageIndex +1;			
			CollezioneControlli.Add(s_p_pageindex);

			S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
			s_p_pagesize.ParameterName = "pagesize";
			s_p_pagesize.DbType = CustomDBType.Integer;
			s_p_pagesize.Direction = ParameterDirection.Input;
			s_p_pagesize.Index = 17;
			s_p_pagesize.Value= DataGridRicerca.PageSize;			
			CollezioneControlli.Add(s_p_pagesize);


			Classi.ManProgrammata.CreaPiano _CP = new TheSite.Classi.ManProgrammata.CreaPiano();					

			DataSet _MyDs = _CP.GetDataPaging(CollezioneControlli).Copy();

			if (reset==true)
			{

				CollezioneControlli =GetControl();	
				int _totalRecords = _CP.GetDataCount(CollezioneControlli);
				this.GridTitle1.NumeroRecords=_totalRecords.ToString();
			}

			DataGridRicerca.Visible =true;
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.VirtualItemCount =int.Parse(this.GridTitle1.NumeroRecords);
			this.DataGridRicerca.DataBind();
			
			if (int.Parse(this.GridTitle1.NumeroRecords)>0)		
				PanelCrea.Visible=true;											
			else
				PanelCrea.Visible=false;
		}

		private void GetControlli()
		{	
			Classi.clMyDataGridCollection _cl = new TheSite.Classi.clMyDataGridCollection();
			if(Session["CheckedList"]!=null)
			{	
				_cl.GetControl(DataGridRicerca,(Hashtable) Session["CheckedList"],DataGridRicerca.CurrentPageIndex);
			}
		}

		private void SetControlli()
		{			
			Classi.clMyDataGridCollection _cl = new TheSite.Classi.clMyDataGridCollection();
			
			Hashtable _HS = new Hashtable();
			if(Session["CheckedList"]!=null)
			{
				_HS=(Hashtable) Session["CheckedList"];				
			}
			_HS=_cl.SetControl(DataGridRicerca,_HS,DataGridRicerca.CurrentPageIndex);
			Session.Remove("CheckedList");
			Session.Add("CheckedList",_HS);	
		}

		private void SetDati()
		{			
			
			Hashtable _HS = new Hashtable();
			
			if(Session["DatiList"]!=null)
			{
				_HS=(Hashtable) Session["DatiList"];				
			}

						
			foreach(DataGridItem o_Litem in DataGridRicerca.Items)
			{
				DataGridField _campi = new DataGridField();
		
				_campi.idbl=Int32.Parse(o_Litem.Cells[0].Text);									
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel");																									
			
				if(_HS.ContainsKey(_campi.idbl))
					_HS.Remove(_campi.idbl);												
							
				if(cb.Checked)
				{
					_campi.idditta=Int32.Parse(o_Litem.Cells[2].Text);
					_campi.idservizio=Int32.Parse(o_Litem.Cells[3].Text);
					_campi.mesegiorno=o_Litem.Cells[11].Text;
					_campi.idaddetto=Int32.Parse(o_Litem.Cells[4].Text);	
					_HS.Add(_campi.idbl,_campi);		
				}
			}			
			
			Session.Remove("DatiList");
			Session.Add("DatiList",_HS);			
			LblElementiSelezionati.Text="Elementi Selezionati - " + _HS.Count.ToString() + " -";
			txtTotSelezionati.Text=_HS.Count.ToString();
		}

		private void SetDati(bool val)
		{	
			Hashtable _HS = new Hashtable();
		
			if(Session["DatiList"]!=null)
			{
				_HS=(Hashtable) Session["DatiList"];				
			}

					
			foreach(DataGridItem o_Litem in DataGridRicerca.Items)
			{
				DataGridField _campi = new DataGridField();
		
				_campi.idbl=Int32.Parse(o_Litem.Cells[0].Text);									
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel");																									
				cb.Checked=val;
				if(_HS.ContainsKey(_campi.idbl))
					_HS.Remove(_campi.idbl);												
							
				if(cb.Checked)
				{
					_campi.idditta=Int32.Parse(o_Litem.Cells[2].Text);
					_campi.idservizio=Int32.Parse(o_Litem.Cells[3].Text);
					_campi.mesegiorno=o_Litem.Cells[11].Text;
					_campi.idaddetto=Int32.Parse(o_Litem.Cells[4].Text);	
					_HS.Add(_campi.idbl,_campi);		
				}
			}			
			
			Session.Remove("DatiList");
			Session.Add("DatiList",_HS);			
			LblElementiSelezionati.Text="Elementi Selezionati - " + _HS.Count.ToString() + " -";
			txtTotSelezionati.Text=_HS.Count.ToString();			
		}

		private void SelezionaTutti(bool val)
		{	
			if(!val)
			{
				Session.Remove("CheckedList");
				Session.Remove("DatiList");
				LblElementiSelezionati.Text="Elementi Selezionati - 0 -";
				txtTotSelezionati.Text="0";
			}
			else
			{				
				SetControlli();										
			}
			
			Classi.ManProgrammata.CreaPiano _CP = new TheSite.Classi.ManProgrammata.CreaPiano();					
			
			S_Controls.Collections.S_ControlsCollection CollezioneControlli =GetControl();
			DataSet _MyDs = _CP.GetData(CollezioneControlli).Copy();

			for(int Pagine = 0;Pagine<=DataGridRicerca.PageCount;Pagine++)
			{
	
				DataGridRicerca.DataSource=_MyDs.Tables[0];
				DataGridRicerca.DataBind();
				DataGridRicerca.CurrentPageIndex=Pagine;									
							
				SetDati(val);
				
				if(val)
				{	
					SetControlli();				
				}
			}

			DataGridRicerca.CurrentPageIndex=0;
			Ricerca(true);			
			GetControlli();						
		}

		private void Resetta()
		{
			// Resetto tutti i valori ed entro nella Modifica
			DataGridRicerca.CurrentPageIndex=0;			
			LblElementiSelezionati.Text="Elementi Selezionati - 0 -";
			txtTotSelezionati.Text="0";
			Session.Remove("CheckedList");
			Session.Remove("DatiList");			
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
			this.cmbsDitta.SelectedIndexChanged += new System.EventHandler(this.cmbsDitta_SelectedIndexChanged);
			this.btnsRicerca.Click += new System.EventHandler(this.btnsRicerca_Click);
			this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.btnsCrea.Click += new System.EventHandler(this.btnsCrea_Click);
			this.btnsSelezionaTutti.Click += new System.EventHandler(this.btnsSelezionaTutti_Click);
			this.btnsDeSelezionaTutti.Click += new System.EventHandler(this.btnsDeSelezionaTutti_Click);
			this.btnsConfermaSelezioni.Click += new System.EventHandler(this.btnsConfermaSelezioni_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmbsDitta_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindAddetti(RicercaModulo1.TxtCodice.Text);
		}

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			DataGridRicerca.CurrentPageIndex=0;						
			Resetta();
			Ricerca(true);
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;	
			Ricerca(false);
			GetControlli();			
		}

		private void btnsConfermaSelezioni_Click(object sender, System.EventArgs e)
		{
			SetDati();
			SetControlli();		
		}		

		private void btnsSelezionaTutti_Click(object sender, System.EventArgs e)
		{
			SelezionaTutti(true);
		}

		private void btnsDeSelezionaTutti_Click(object sender, System.EventArgs e)
		{
			SelezionaTutti(false);
		}

		private void btnsCrea_Click(object sender, System.EventArgs e)
		{
			Classi.ManProgrammata.CreaPiano _CP = new TheSite.Classi.ManProgrammata.CreaPiano();
			if(Session["DatiList"]!=null)
			{
				_CP.beginTransaction();
				
				try
				{					
					Hashtable _HS = (Hashtable)Session["DatiList"];
					IDictionaryEnumerator myEnumerator = _HS.GetEnumerator();								
					string mesegiorno=String.Empty;
					
					string mes=String.Empty;

					while (myEnumerator.MoveNext())
					{
												
						S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();
						
						DataGridField _campi = (DataGridField) myEnumerator.Value;					
						
						// DATA
						S_Controls.Collections.S_Object s_Data = new S_Object();
						s_Data.ParameterName = "i_DataFine";
						s_Data.DbType = CustomDBType.Integer;
						s_Data.Direction = ParameterDirection.Input;
						s_Data.Index = 0;					
						s_Data.Value = Int16.Parse(cmbsAnnoA.SelectedValue);																	
						CollezioneControlli.Add(s_Data);						
						// IDBL
						S_Controls.Collections.S_Object s_Idbl = new S_Object();
						s_Idbl.ParameterName = "i_Edificio";
						s_Idbl.DbType = CustomDBType.Integer;
						s_Idbl.Direction = ParameterDirection.Input;
						s_Idbl.Index = 1;
						s_Idbl.Value = _campi.idbl;
						CollezioneControlli.Add(s_Idbl);						
						// IDSERVIZIO
						S_Controls.Collections.S_Object s_IdServizio = new S_Object();
						s_IdServizio.ParameterName = "i_Category";
						s_IdServizio.DbType = CustomDBType.Integer;
						s_IdServizio.Direction = ParameterDirection.Input;
						s_IdServizio.Index = 2;
						s_IdServizio.Value = _campi.idservizio;
						CollezioneControlli.Add(s_IdServizio);
						// IDADDETTO
						S_Controls.Collections.S_Object s_IdAddetto = new S_Object();
						s_IdAddetto.ParameterName = "p_idaddetto";
						s_IdAddetto.DbType = CustomDBType.Integer;
						s_IdAddetto.Direction = ParameterDirection.Input;
						s_IdAddetto.Index = 3;						
						s_IdAddetto.Value = _campi.idaddetto;
						CollezioneControlli.Add(s_IdAddetto);
						//DATASTART
						S_Controls.Collections.S_Object s_DataStart = new S_Object();
						s_DataStart.ParameterName = "p_datastart";
						s_DataStart.DbType = CustomDBType.VarChar;
						s_DataStart.Direction = ParameterDirection.Input;
						s_DataStart.Index = 4;					
						s_DataStart.Value = _campi.mesegiorno;																	
						CollezioneControlli.Add(s_DataStart);						
						//IDDITTA
						S_Controls.Collections.S_Object s_Ditta = new S_Object();
						s_Ditta.ParameterName = "p_idditta";
						s_Ditta.DbType = CustomDBType.Integer;
						s_Ditta.Direction = ParameterDirection.Input;
						s_Ditta.Index = 5;					
						s_Ditta.Value = _campi.idditta;																	
						CollezioneControlli.Add(s_Ditta);		
				
						// PAOLO: 24/02/06
						pippo = (resultSchedula)  _CP.CreaPianoMP(CollezioneControlli);

						// OLD:
						// 	_result = _CP.CreaPianoMP(CollezioneControlli);
						
					}
					_CP.commitTransaction();

					// PAOLO

					switch (pippo)
					{
						case  resultSchedula.NO_PROCED_MAN:
							mes="Nessuna procedura per l'edificio e il servizio selezionati!";
							break;

						case  resultSchedula.GIA_SCHEDULATO:
							mes="Procedura già schedulata per l'anno selezionato.!";
							break;
						case resultSchedula.NO_ADD_SPECIALIZZATO :
							mes="Nessun addetto per la specializzazione corrente!";
							break;
						case resultSchedula.DATA_FUORI_INTERVALLO :
							mes="La data selezionata è fuori dell'intervallo di validità!";
							break;
						case resultSchedula.NO_STAGIONALE :
							mes="Non è stata trovata una corrispondenza stagionale!";
							break;
						case resultSchedula.NO_FREQ_FISSE :
							mes="Non sono previste frequenze di tipo fisso per il seguente servizio!";
							break;
						case resultSchedula.SCHEDULAZIONE_OK :

							// Visualizzo la stringa del messaggio di conferma AGGIORNAMENTO nel DB						
							string tot=txtTotSelezionati.Text;
							if(Int16.Parse(tot)>1)
								mes="Sono stati Pianificati " + tot + " Edifici nel Piano di Manutenzione";	
							else
								mes="E` stato Pianificato " + tot + " Edificio nel Piano di Manutenzione";	
							break;

					}

					//  FINE

					
					/* if (_result==1)
					{

						// Visualizzo la stringa del messaggio di conferma AGGIORNAMENTO nel DB						
						string tot=txtTotSelezionati.Text;
						if(Int16.Parse(tot)>1)
							mes="Sono stati Pianificati " + tot + " Edifici nel Piano di Manutenzione";	
						else
							mes="E` stato Pianificato " + tot + " Edificio nel Piano di Manutenzione";											
					}
					else
					{
						mes="Non Tutte le attività sono state inserite nel piano";	
					} */


					Resetta();	
					DataGridRicerca.CurrentPageIndex =0;  
					Ricerca(true);										
					
					//Visualizzo il messaggio
					Classi.SiteJavaScript.msgBox(this.Page,mes);

				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message); 
					_CP.rollbackTransaction(); 
					string mes=String.Empty;
					//mes = ex.Message.ToString();
					mes = "Si è verificato un errore durante la creazione del Piano.";	
					Classi.SiteJavaScript.msgBox(this.Page,mes);
				}
			}
			else
			{
				Classi.SiteJavaScript.msgBox(this.Page,"Nessun Edificio selezionato.");
			}
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{	
				//Formatto il Campo DATE START (DATA INI)
				string _CampoData = e.Item.Cells[10].Text.Trim();
				if (_CampoData.Length > 0) 
				{					
					string gg = _CampoData.Substring(2,2); 
					int mm = Int16.Parse(_CampoData.Substring(0,2));					
					string mese =  Classi.Function.ImpostaMese(mm,false);					
					e.Item.Cells[10].Text= gg + " - " + mese ;
					e.Item.Cells[10].ToolTip= gg + " - " + Classi.Function.ImpostaMese(mm,true);
				}
			}
		}

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("CreaPianoMP.aspx?FunId="+FunId);
		}

	}
}
