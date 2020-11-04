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

namespace TheSite.ManutenzioneProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per SfogliaRdlOdlPaging.
	/// </summary>
	public class SfogliaRdlOdlPaging : System.Web.UI.Page
	{
		protected S_Controls.S_ComboBox cmbsAnnoDa;
		protected S_Controls.S_ComboBox cmbsAnnoA;
		protected S_Controls.S_ComboBox cmbsMeseA;
		protected S_Controls.S_ComboBox cmbsDitta;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_TextBox txtDescrizione;
		protected S_Controls.S_TextBox txtRichiestaLavoro;
		protected S_Controls.S_TextBox txtOrdineLavoro;
		protected S_Controls.S_ComboBox cmbsStdApparecchiature;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected S_Controls.S_ComboBox cmbsMeseDa;
		protected WebControls.RicercaModulo RicercaModulo1; 
		protected WebControls.Addetti Addetti1;
		protected WebControls.PageTitle	PageTitle1;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.CodiceApparecchiature CodiceApparecchiature1;
		public static int FunId = 0;
		protected Csy.WebControls.DataPanel DataPanel1;
		protected S_Controls.S_Button btRicerca;
		protected S_Controls.S_Button btUltimo;
		protected S_Controls.S_Button btReset;
		protected S_Controls.S_ComboBox cmbsstatolavoro;
		public static string HelpLink = string.Empty;			
	
		MyCollection.clMyCollection _myColl = new MyCollection.clMyCollection();
		SfogliaRdlOdl_MP  _fp=null;
		protected System.Web.UI.WebControls.Label CurrentPage;
		protected System.Web.UI.WebControls.Label TotalPages;
		protected System.Web.UI.WebControls.LinkButton FirstPage;
		protected System.Web.UI.WebControls.LinkButton PreviousPage;
		protected System.Web.UI.WebControls.LinkButton NextPage;
		protected System.Web.UI.WebControls.LinkButton LastPage;

		protected System.Web.UI.HtmlControls.HtmlGenericControl   PagingLink;
		CompletamentoMP  _fp2=null;

		//public delegate void xx(object sender, CommandEventArgs e);
		//public event xx xx2;

		public MyCollection.clMyCollection _Contenitore
		{
			get {return _myColl;}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
					
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];

			//			this.DataGrid1.Columns[1].Visible = _SiteModule.IsEditable;												
		

			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			this.GridTitle1.hplsNuovo.Visible = false;
			

			txtRichiestaLavoro.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtRichiestaLavoro.Attributes.Add("onpaste","return nonpaste();");
			txtOrdineLavoro.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtOrdineLavoro.Attributes.Add("onpaste","return nonpaste();");
			RicercaModulo1.DelegateCodiceEdificio1 = new TheSite.WebControls.DelegateCodiceEdificio(this.BindServizi);

			///TODO: Impostare tali parametri per impostare l'user control Codice apparecchiature
			///Ogni qualvolta lo si deve implementare in una pagina.
			///Tali parametri verranno utilizzati dal controllo per passare i valori in query string
			/// Imposto il nome della combo Apparecchiature
			CodiceApparecchiature1.NameComboApparecchiature ="cmbsStdApparecchiature";
			/// Imposto il nome della combo Servizio
			CodiceApparecchiature1.NameComboServizio ="cmbsServizio";
			/// Imposto il nome dell'user control RicercaModulo
			CodiceApparecchiature1.NameUserControlRicercaModulo  ="RicercaModulo1";

			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("this.value = 'Attendere ...';");
			sbValid.Append("this.disabled = true;");
			sbValid.Append("document.getElementById('" + btRicerca.ClientID + "').disabled = true;");
			sbValid.Append(this.Page.GetPostBackEventReference(this.btRicerca));
			sbValid.Append(";");
			this.btRicerca.Attributes.Add("onclick", sbValid.ToString());
			
			if(!IsPostBack)
			{
				
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];

				this.GridTitle1.Visible= false;
				PagingLink.Visible =false;
				BindControls();

				if(Context.Handler is TheSite.ManutenzioneProgrammata.SfogliaRdlOdl_MP)
				{
					_fp = (TheSite.ManutenzioneProgrammata.SfogliaRdlOdl_MP)Context.Handler;
					if (_fp!=null) 
					{						
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);		
						Ricerca(true);
					}
				}
				if(Context.Handler is TheSite.ManutenzioneProgrammata.CompletamentoMP)
				{
					_fp2 = (TheSite.ManutenzioneProgrammata.CompletamentoMP)Context.Handler;
					if (_fp2!=null) 
					{						
						_myColl=_fp2._ContenitoreSfoglia;
						_myColl.SetValues(this.Page.Controls);		
						Ricerca(true);
					}
				}
			}

		}
		private void BindControls()
		{ 
			CaricaCombiAnni();
			BindServizi("");
			BindApparecchiatura();
			BindStatoLavoro("");
		}
		private void CaricaCombiAnni()
		{
			string anno_corrente = DateTime.Now.Year.ToString();
			for (int i = 1950; i <= 2051; i++)
			{ 
				cmbsAnnoA.Items.Add(i.ToString());
				cmbsAnnoDa.Items.Add(i.ToString());
			}

			cmbsAnnoA.SelectedValue=anno_corrente;
			cmbsAnnoDa.SelectedValue=anno_corrente;
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
				this.cmbsServizio.DataSource =_MyDs.Tables[0];
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
				this.cmbsDitta.DataSource = _MyDs.Tables[0];
				this.cmbsDitta.DataTextField = "DESCRIZIONE";
				this.cmbsDitta.DataValueField = "id";
				this.cmbsDitta.DataBind();
			}
			
			else
			{
				string s_Messagggio = "- Nessuna Ditta  -";
				this.cmbsDitta.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}
		private void BindStatoLavoro(string idstato)
		{
			this.cmbsstatolavoro.Items.Clear();		
		
			TheSite.Classi.ManProgrammata.SfogliaRdlOdlPaging  _SfogliaRdlOdlPaging =new TheSite.Classi.ManProgrammata.SfogliaRdlOdlPaging("");

			DataSet _MyDs = _SfogliaRdlOdlPaging.GetStatoLavoro();
            
			if (_MyDs.Tables[0].Rows.Count > 0)
			{

				this.cmbsstatolavoro.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "id", "- Selezionare lo Stato di Lavoro  -", "");
				this.cmbsstatolavoro.DataTextField = "descrizione";
				this.cmbsstatolavoro.DataValueField = "id";
				this.cmbsstatolavoro.DataBind();

				if(idstato!="")
					try  //TODO: questo try cach non dovrebbe esistere in quanto la funzione non dovrebbe andare in errore
					{
						this.cmbsstatolavoro.SelectedValue =idstato;
					}
					catch (Exception ex)
					{
						Console.WriteLine (ex.Message);   
					}

			}
			else
			{
				string s_Messagggio = "- Nessuno Stato di Lavoro  -";
				this.cmbsstatolavoro.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}

		}
		private void BindApparecchiatura()
		{
			
			this.cmbsStdApparecchiature.Items.Clear();
		
			Classi.AnagrafeImpianti.Apparecchiature  _Apparecchiature = new TheSite.Classi.AnagrafeImpianti.Apparecchiature(Context.User.Identity.Name);
			
			DataSet _MyDs;

			if (!IsPostBack)
			{
				_MyDs = _Apparecchiature.GetData().Copy();
			}
			else
			{
				S_ControlsCollection _SColl = new S_ControlsCollection();

				S_Controls.Collections.S_Object s_BlId = new S_Object();
				s_BlId.ParameterName = "p_Bl_Id";
				s_BlId.DbType = CustomDBType.VarChar;
				s_BlId.Direction = ParameterDirection.Input;
				s_BlId.Size =50;
				s_BlId.Index = 0;
				s_BlId.Value = RicercaModulo1.TxtCodice.Text;
				_SColl.Add(s_BlId);
			
				S_Controls.Collections.S_Object s_Servizio = new S_Object();
				s_Servizio.ParameterName = "p_Servizio";
				s_Servizio.DbType = CustomDBType.Integer;
				s_Servizio.Direction = ParameterDirection.Input;
				s_Servizio.Index = 1;
				s_Servizio.Value = (cmbsServizio.SelectedValue=="")? 0:Int32.Parse(cmbsServizio.SelectedValue);
				_SColl.Add(s_Servizio);

				_MyDs = _Apparecchiature.GetData(_SColl).Copy();
                 
			}
  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsStdApparecchiature.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare una Apparecchiatura -", "");
				this.cmbsStdApparecchiature.DataTextField = "DESCRIZIONE";
				this.cmbsStdApparecchiature.DataValueField = "ID";
				this.cmbsStdApparecchiature.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Apparecchiatura -";
				this.cmbsStdApparecchiature.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
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
			this.btRicerca.Click += new System.EventHandler(this.btRicerca_Click);
			this.btUltimo.Click += new System.EventHandler(this.btUltimo_Click);
			this.btReset.Click += new System.EventHandler(this.btReset_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btReset_Click(object sender, System.EventArgs e)
		{			
			Response.Redirect("SfogliaOdlRdl.aspx?FunID=" + ViewState["FunId"]);
		}

		private void cmbsServizio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindApparecchiatura();
		}

		private void cmbsDitta_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindAddetti(RicercaModulo1.TxtCodice.Text);	
		}
		protected Int32 _currentPageNumber = 1;
		private void Ricerca(bool reset)
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();
			
			// Data Da						
			string giornoDA = "01";
			string meseDA = cmbsMeseDa.SelectedValue;			
			string annoDA = cmbsAnnoDa.SelectedValue;			
			string dataDA = giornoDA + "/" + meseDA + "/" + annoDA;
			S_Controls.Collections.S_Object s_P_DaData = new S_Object();
			s_P_DaData.ParameterName = "P_DaData";
			s_P_DaData.DbType = CustomDBType.VarChar;
			s_P_DaData.Direction = ParameterDirection.Input;
			s_P_DaData.Index = 0;
			s_P_DaData.Size=10;
			s_P_DaData.Value=dataDA;			
			CollezioneControlli.Add(s_P_DaData);		
		
			// Data a									
			string giornoA = DateTime.DaysInMonth(Int16.Parse(cmbsAnnoA.SelectedValue),Int16.Parse(cmbsMeseA.SelectedValue)).ToString();			
			string meseA = cmbsMeseA.SelectedValue;			
			string annoA = cmbsAnnoA.SelectedValue;			
			string dataA = giornoA + "/" + meseA + "/" + annoA;
			S_Controls.Collections.S_Object s_P_AData = new S_Object();
			s_P_AData.ParameterName = "P_AData";
			s_P_AData.DbType = CustomDBType.VarChar;
			s_P_AData.Direction = ParameterDirection.Input;
			s_P_AData.Index = 1;
			s_P_AData.Size=10;
			s_P_AData.Value=dataA;			
			CollezioneControlli.Add(s_P_AData);

			// Servizio					
			S_Controls.Collections.S_Object s_P_servizio = new S_Object();
			s_P_servizio.ParameterName = "P_servizio";
			s_P_servizio.DbType = CustomDBType.Integer;
			s_P_servizio.Direction = ParameterDirection.Input;
			s_P_servizio.Index = 2;
			s_P_servizio.Value=(cmbsServizio.SelectedValue=="0")?0:int.Parse(cmbsServizio.SelectedValue);			
			CollezioneControlli.Add(s_P_servizio);

			// DITTA					
			S_Controls.Collections.S_Object s_P_ditta = new S_Object();
			s_P_ditta.ParameterName = "P_ditta";
			s_P_ditta.DbType = CustomDBType.Integer;
			s_P_ditta.Direction = ParameterDirection.Input;
			s_P_ditta.Index = 3;
			s_P_ditta.Value=(cmbsDitta.SelectedValue=="0")?0:int.Parse(cmbsDitta.SelectedValue);			
			CollezioneControlli.Add(s_P_ditta);

			// Ordine di Lavoro					
			S_Controls.Collections.S_Object s_P_odl = new S_Object();
			s_P_odl.ParameterName = "P_odl";
			s_P_odl.DbType = CustomDBType.Integer;
			s_P_odl.Direction = ParameterDirection.Input;
			s_P_odl.Index = 4;
			s_P_odl.Value=(txtOrdineLavoro.Text=="")?0:int.Parse(txtOrdineLavoro.Text);			
			CollezioneControlli.Add(s_P_odl);

			// Bl codice dell'edificio					
			S_Controls.Collections.S_Object s_P_bl_id = new S_Object();
			s_P_bl_id.ParameterName = "P_bl_id";
			s_P_bl_id.DbType = CustomDBType.VarChar;
			s_P_bl_id.Direction = ParameterDirection.Input;
			s_P_bl_id.Index = 5;
			s_P_bl_id.Size=50; 
			s_P_bl_id.Value=RicercaModulo1.TxtCodice.Text;			
			CollezioneControlli.Add(s_P_bl_id);

			// Bl Descrizione dell'edificio					
			S_Controls.Collections.S_Object s_P_campus = new S_Object();
			s_P_campus.ParameterName = "P_campus";
			s_P_campus.DbType = CustomDBType.VarChar;
			s_P_campus.Direction = ParameterDirection.Input;
			s_P_campus.Index = 6;
			s_P_campus.Size=50; 
			s_P_campus.Value=RicercaModulo1.Campus;			
			CollezioneControlli.Add(s_P_campus);

			// Cognome e nome dell'addetto				
			S_Controls.Collections.S_Object s_P_addetto_id = new S_Object();
			s_P_addetto_id.ParameterName = "P_addetto_id";
			s_P_addetto_id.DbType = CustomDBType.VarChar;
			s_P_addetto_id.Direction = ParameterDirection.Input;
			s_P_addetto_id.Index = 7;
			s_P_addetto_id.Size=250; 
			s_P_addetto_id.Value=Addetti1.NomeCompleto;			
			CollezioneControlli.Add(s_P_addetto_id);

			// Richiesta di Lavoro					
			S_Controls.Collections.S_Object s_P_rdl = new S_Object();
			s_P_rdl.ParameterName = "P_rdl";
			s_P_rdl.DbType = CustomDBType.Integer;
			s_P_rdl.Direction = ParameterDirection.Input;
			s_P_rdl.Index = 8;
			s_P_rdl.Value=(txtRichiestaLavoro.Text=="")?0:int.Parse(txtRichiestaLavoro.Text);			
			CollezioneControlli.Add(s_P_rdl);

			// Descrizione					
			S_Controls.Collections.S_Object s_P_descrizione = new S_Object();
			s_P_descrizione.ParameterName = "P_descrizione";
			s_P_descrizione.DbType = CustomDBType.VarChar;
			s_P_descrizione.Direction = ParameterDirection.Input;
			s_P_descrizione.Index = 9;
			s_P_descrizione.Size=250; 
			s_P_descrizione.Value=txtDescrizione.Text;			
			CollezioneControlli.Add(s_P_descrizione);

			// Stato della richiesta				
			S_Controls.Collections.S_Object s_P_statoric = new S_Object();
			s_P_statoric.ParameterName = "P_statoric";
			s_P_statoric.DbType = CustomDBType.Integer;
			s_P_statoric.Direction = ParameterDirection.Input;
			s_P_statoric.Index =10;
			s_P_statoric.Value=(cmbsstatolavoro.SelectedValue=="")?0:int.Parse(cmbsstatolavoro.SelectedValue);			
			CollezioneControlli.Add(s_P_statoric);

			// Standard delle apparecchiature				
			S_Controls.Collections.S_Object s_P_standard = new S_Object();
			s_P_standard.ParameterName = "P_standard";
			s_P_standard.DbType = CustomDBType.Integer;
			s_P_standard.Direction = ParameterDirection.Input;
			s_P_standard.Index = 11;
			s_P_standard.Value=(cmbsStdApparecchiature.SelectedValue=="")?0:int.Parse(cmbsStdApparecchiature.SelectedValue);			
			CollezioneControlli.Add(s_P_standard);

			// Apparecchiature				
			S_Controls.Collections.S_Object s_P_apparecchiatura = new S_Object();
			s_P_apparecchiatura.ParameterName = "P_apparecchiatura";
			s_P_apparecchiatura.DbType = CustomDBType.VarChar;
			s_P_apparecchiatura.Direction = ParameterDirection.Input;
			s_P_apparecchiatura.Size = 50;
			s_P_apparecchiatura.Index = 12;
			s_P_apparecchiatura.Value=CodiceApparecchiature1.CodiceApparecchiatura;			
			CollezioneControlli.Add(s_P_apparecchiatura);

			S_Controls.Collections.S_Object s_p_TipoManutenzione = new S_Object();
			s_p_TipoManutenzione.ParameterName = "p_TipoManutenzione";
			s_p_TipoManutenzione.DbType = CustomDBType.Integer;
			s_p_TipoManutenzione.Direction = ParameterDirection.Input;
			s_p_TipoManutenzione.Index = 13;
			s_p_TipoManutenzione.Value=Classi.TipoManutenzioneType.ManutenzioneProgrammata;			
			CollezioneControlli.Add(s_p_TipoManutenzione);

			S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
			s_p_pageindex.ParameterName = "pageindex";
			s_p_pageindex.DbType = CustomDBType.Integer;
			s_p_pageindex.Direction = ParameterDirection.Input;
			s_p_pageindex.Index = 14;
			s_p_pageindex.Value=1;			
			CollezioneControlli.Add(s_p_pageindex);

			S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
			s_p_pagesize.ParameterName = "pagesize";
			s_p_pagesize.DbType = CustomDBType.Integer;
			s_p_pagesize.Direction = ParameterDirection.Input;
			s_p_pagesize.Index = 15;
			s_p_pagesize.Value= DataGrid1.PageSize;			
			CollezioneControlli.Add(s_p_pagesize);

			TheSite.Classi.ManProgrammata.SfogliaRdlOdlPaging _SfogliaRdlOdlPaging=new TheSite.Classi.ManProgrammata.SfogliaRdlOdlPaging(Context.User.Identity.Name);
			DataSet _Ds= _SfogliaRdlOdlPaging.GetData(CollezioneControlli);


			CurrentPage.Text = _currentPageNumber.ToString();

			Double _totalPages = 1;
			if (reset==true)
			{
				
				int _totalRecords = _SfogliaRdlOdlPaging.Update(CollezioneControlli,0);
				this.GridTitle1.NumeroRecords=_totalRecords.ToString();
				_totalPages = _totalRecords / DataGrid1.PageSize;
				TotalPages.Text = ( System.Math.Ceiling ( _totalPages ) ).ToString();
			}
			else
			{
				_totalPages = Double.Parse ( TotalPages.Text );
			}

			if ( _currentPageNumber == 1 )
			{
				PreviousPage.Enabled = false;

				if ( _totalPages > 1 )
				{
					NextPage.Enabled = true;
				}
				else
				{
					NextPage.Enabled = false;
				}
			}
			else
			{
				PreviousPage.Enabled = true;

				if ( _currentPageNumber == _totalPages )
				{
					NextPage.Enabled = false;
				}
				else
				{
					NextPage.Enabled = true; 
				}
			}


			if (int.Parse(TotalPages.Text) >0) 
			{
				this.GridTitle1.Visible= true;
				DataGrid1.Visible =true;
			    PagingLink.Visible =true;
				DataGrid1.DataSource =_Ds.Tables[0];
				DataGrid1.DataBind(); 
			}
			else
			{
				PagingLink.Visible =false;
				DataGrid1.Visible =false;
				this.GridTitle1.Visible= false;
			}
		}
		protected void NavigationLink_Click( Object sender, CommandEventArgs e )
		{
			switch ( e.CommandName )
			{
				case "First":
					_currentPageNumber = 1;
					break;
				case "Last":
					_currentPageNumber = Int32.Parse ( TotalPages.Text );
					break;
				case "Next":
					_currentPageNumber = Int32.Parse ( CurrentPage.Text ) + 1;
					break;
				case "Prev":
					_currentPageNumber = Int32.Parse ( CurrentPage.Text ) - 1;
					break;
			}

			Ricerca(false);
		}
		public bool completare=false;
		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if( e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem )
			{
				//Label lbl=new Label();
				System.Web.UI.WebControls.Label lbl = (Label) e.Item.Cells[11].FindControl("lblComp");
				System.Web.UI.WebControls.LinkButton lk  = (LinkButton)  e.Item.Cells[11].FindControl("Linkbutton2");
				if (DataBinder.Eval(e.Item.DataItem, "WO_DATA")!=System.DBNull.Value) 
				{					
					lbl.Visible = true;
					lk.Visible = false;
				}
				else
				{
					completare=true;				
					//LinkButton lk = new LinkButton();			
					lk.CommandArgument=DataBinder.Eval(e.Item.DataItem, "wo_id").ToString();
					lk.Text ="Completa";
					lk.CommandName="lkin"; 
					//lk.Command +=new CommandEventHandler(this.pluto);	
					lbl.Visible = false;
					lk.Visible = true;
					//lk.Click +=new EventHandler(lk_Click);
					//CommandEventArgs cma = new CommandEventArgs(lk.CommandName, lk.CommandArgument);
					//xx2+=new xx(lk_Command);						
					//e.Item.Cells[11].Controls.Add(lk);																
					//xx2(lk, cma);							
					
				}
					
			}

		}

	
		private void btRicerca_Click(object sender, System.EventArgs e)
		{
			Ricerca(true);
		}

		public void LinkButton1_Click(Object sender, CommandEventArgs e) 
		{
			_myColl.AddControl(this.Page.Controls, ParentType.Page);
			Context.Items.Add("wo_id",e.CommandArgument);			
			Server.Transfer("SfogliaRdlOdl_MP.aspx?FunId=" + FunId); 
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			DataGrid1.CurrentPageIndex=e.NewPageIndex;
			Ricerca(false);
		}

	
		public void LinkButton2_Click(object sender, CommandEventArgs e)
		{
			_myColl.AddControl(this.Page.Controls, ParentType.Page);
			Server.Transfer("CompletamentoMP.aspx?id_wo=" + e.CommandArgument+"&FunId="+FunId); 
		}

	
		private void btUltimo_Click(object sender, System.EventArgs e)
		{

			cmbsMeseDa.SelectedValue=System.DateTime.Now.Month.ToString().PadLeft(2,Convert.ToChar("0")) ;			
			cmbsAnnoDa.SelectedValue=System.DateTime.Now.Year.ToString();
			cmbsMeseA.SelectedValue=System.DateTime.Now.Month.ToString().PadLeft(2,Convert.ToChar("0"));			
			cmbsAnnoA.SelectedValue=System.DateTime.Now.Year.ToString();
			Ricerca(false);
		}
	}
}
