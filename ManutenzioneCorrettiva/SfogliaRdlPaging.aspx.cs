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
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using MyCollection;

namespace TheSite.ManutenzioneCorrettiva
{
	/// <summary>
	/// Descrizione di riepilogo per SfogliaRdlPaging.
	/// </summary>
	public class SfogliaRdlPaging :  System.Web.UI.Page
	{
		public Classi.SiteModule _SiteModule;
		protected S_Controls.S_TextBox txtsRichiesta;
		protected S_Controls.S_ComboBox cmbsUrgenza;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_TextBox txtsOrdine;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;	
		protected WebControls.GridTitle Gridtitle2;			
		protected WebControls.PageTitle PageTitle1;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;
		protected WebControls.CalendarPicker CalendarPicker3;
		protected WebControls.CalendarPicker CalendarPicker4;
		protected WebControls.Addetti Addetti1;
		protected WebControls.Richiedenti Richiedenti1;		
		protected S_Controls.S_TextBox txtDescrizione;
		protected S_Controls.S_Button cmdExcel;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected S_Controls.S_ComboBox cmbsGruppo;
		protected S_Controls.S_ComboBox cmbsTipoIntervento;
		protected S_Controls.S_ComboBox cmbsStatus;
		protected S_Controls.S_ComboBox cmbsTipoManutenzione;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca2;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;

		#region variabili
		public static string HelpLink = string.Empty;		
		object _fp1=null;
		EditSfoglia  _fp=null;
		CostiOperativi.CostiOperativi _fp2=null;
		public static int FunId = 0;


	
	
		MyCollection.clMyCollection _myColl = new MyCollection.clMyCollection();
		#endregion


		public MyCollection.clMyCollection _Contenitore
		{
			get {return _myColl;}
		}
	

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			txtsRichiesta.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtsRichiesta.Attributes.Add("onpaste","return nonpaste();");
			txtsOrdine.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtsOrdine.Attributes.Add("onpaste","return nonpaste();");

			string _mypage="./ManutenzioneCorrettiva/SfogliaRdlPaging.aspx";			
			_SiteModule = new TheSite.Classi.SiteModule(_mypage);
			FunId = _SiteModule.ModuleId;

			HelpLink = _SiteModule.HelpLink;
			//this.PageTitle1.Title = _SiteModule.ModuleTitle;
			this.PageTitle1.Title = "SFOGLIA RDL CORRETTIVA";

			this.RicercaModulo1.DelegatePresidio1 +=new  WebControls.DelegatePresidio(this.BindUrgenza);			
			RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);

			if(!Page.IsPostBack)
			{	
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];
			
				CompareValidator1.ControlToValidate = CalendarPicker2.ID + ":" + CalendarPicker2.Datazione.ID;
				CompareValidator1.ControlToCompare =  CalendarPicker1.ID + ":" + CalendarPicker1.Datazione.ID;
				CalendarPicker1.Datazione.Text=DateTime.Now.ToShortDateString();
				CalendarPicker2.Datazione.Text=DateTime.Now.ToShortDateString();
				DataGridRicerca.Visible = false;				
				GridTitle1.hplsNuovo.Visible = false;
				GridTitle1.Visible =false;


				BindServizio("");
				BindGruppo();
				BindUrgenza("");
				BindStatus();	
				BindTipoInterventoAter();
				BinTipoManutenzione();

				// Imposto visibile il DataGrid di Manutenzione su Richiesta
				DataGridRicerca.Visible=false;
				GridTitle1.Visible=false;
				DataGridRicerca2.Visible=true;
				Gridtitle2.Visible=true;

				//Valorizzo i Parametri Immessi
				
				if(Context.Handler is TheSite.ManutenzioneCorrettiva.CompletaRdl || Context.Handler is TheSite.ManutenzioneCorrettiva.EditApprovaEmetti)
				{
					_fp1= Context.Handler as ManutenzioneCorrettiva.CompletaRdl;
					if (_fp1!=null)
					{
						_myColl= ((ManutenzioneCorrettiva.CompletaRdl)_fp1)._Contenitore;
						_myColl.SetValues(this.Page.Controls);
					}	
					_fp1= Context.Handler as ManutenzioneCorrettiva.EditApprovaEmetti;
					if (_fp1!=null)
					{
						_myColl= ((ManutenzioneCorrettiva.EditApprovaEmetti)_fp1)._Contenitore;
						_myColl.SetValues(this.Page.Controls);
					}	

						if (cmbsTipoManutenzione.SelectedValue=="3")
						{
							// Manutenzione Straordinaria				
							Ricerca(true);		
						}
						else			
						{	// Manutenzione Richiesta				
							RicercaManRichiesta(true);
						}
	
					
				}
				
				
				if(Context.Handler is TheSite.ManutenzioneCorrettiva.EditSfoglia)
				{
					_fp = (TheSite.ManutenzioneCorrettiva.EditSfoglia)Context.Handler;
					if (_fp!=null) 
					{						
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);		
						
						if (cmbsTipoManutenzione.SelectedValue=="3")
						{
							// Manutenzione Straordinaria				
							Ricerca(true);		
						}
						else			
						{	// Manutenzione Richiesta				
							RicercaManRichiesta(true);
						}

					}
				}
				//*****************
				if(Context.Handler is TheSite.CostiOperativi.CostiOperativi)
				{
					_fp2 = (TheSite.CostiOperativi.CostiOperativi)Context.Handler;
					if (_fp2!=null) 
					{						
						_myColl=_fp2._Contenitore;
						_myColl.SetValues(this.Page.Controls);		
						
						if (cmbsTipoManutenzione.SelectedValue=="3")
						{
							// Manutenzione Straordinaria				
							Ricerca(true);		
						}
						else			
						{	// Manutenzione Richiesta				
							RicercaManRichiesta(true);
						}

					}
				}	

				//**********
			
			}
			GridTitle1.hplsNuovo.Visible = false;
			Gridtitle2.hplsNuovo.Visible = false;

			
		}

		private void BinTipoManutenzione()
		{
		
			
			Classi.ManCorrettiva.ClManCorrettiva _ClManCorrettiva = new TheSite.Classi.ManCorrettiva.ClManCorrettiva();
			DataSet _MyDs =  _ClManCorrettiva.GetTipoManutenzione();

			if (_MyDs.Tables[0].Rows.Count>0)
			{
				cmbsTipoManutenzione.DataSource = _MyDs;
				this.cmbsTipoManutenzione.DataTextField = "descrizione";
				this.cmbsTipoManutenzione.DataValueField = "id";
				this.cmbsTipoManutenzione.DataBind();				
				this.cmbsTipoManutenzione.Attributes.Add("OnChange","Visualizza(this.value);"); 				
			}	
		}

		private void BindServizio(string CodEdificio)
		{
			GridTitle1.DescriptionTitle="";
			Addetti1.Set_BL_ID(CodEdificio);

			DataGridRicerca.Visible = false;
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
					_MyDs.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "0");
				this.cmbsServizio.DataTextField = "DESCRIZIONE";
				this.cmbsServizio.DataValueField = "IDSERVIZIO";
				this.cmbsServizio.DataBind();
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio("Non Definito", "-1"));
			}
			else
			{
				string s_Messaggio = "Non Definito";
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messaggio, "-1"));
			}
		
		}

		private void BindGruppo()
		{
			this.cmbsGruppo.Items.Clear();
		    string Progetto="";
			if(Request.QueryString["VarApp"]!=null)
				Progetto=Request.QueryString["VarApp"];
			Classi.ClassiAnagrafiche.Richiedenti_tipo _Richiedenti = new TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo();	
			DataSet Ds = _Richiedenti.GetAllAddProg(Progetto).Copy();

//			Classi.ManStraordinaria.GestioneRdl _GestioneRdl= new Classi.ManStraordinaria.GestioneRdl(Context.User.Identity.Name);	
//			DataSet Ds = _GestioneRdl.GetGuppo();
		
			if (Ds.Tables[0].Rows.Count > 0)
			{
				this.cmbsGruppo.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					Ds.Tables[0], "descrizione", "id", "- Selezionare un Gruppo -", "");
				this.cmbsGruppo.DataTextField = "descrizione";
				this.cmbsGruppo.DataValueField = "id";
//				this.cmbsGruppo.DataValueField = "richiedenti_tipo_id";
				this.cmbsGruppo.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Gruppo -";
				this.cmbsGruppo.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		private void BindUrgenza(string Codice)
		{
			string Progetto="";
			if(Request.QueryString["VarApp"]!=null)
				Progetto=Request.QueryString["VarApp"];


			if(Codice!="")
			{
				int cod= Convert.ToInt32(Codice);
				Classi.ClassiDettaglio.Urgenza _Urgenza = new TheSite.Classi.ClassiDettaglio.Urgenza();
				DataSet ds = _Urgenza.GetPriorita(cod,Progetto);
				this.cmbsUrgenza.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					ds.Tables[0], "DESCRIPTION", "id", "- Selezionare una Urgenza -", "0");

				this.cmbsUrgenza.DataTextField = "DESCRIPTION";
				this.cmbsUrgenza.DataValueField = "ID";
				this.cmbsUrgenza.DataBind();
				//this.cmbsUrgenza.SelectedValue = "7";
			}
			else
			{
				Classi.ClassiDettaglio.Urgenza _Urgenza = new TheSite.Classi.ClassiDettaglio.Urgenza();
				DataSet ds =  _Urgenza.GetPriorita(0,Progetto);
				this.cmbsUrgenza.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					ds.Tables[0], "DESCRIPTION", "id", "- Selezionare una Urgenza -", "0");
				this.cmbsUrgenza.DataTextField = "DESCRIPTION";
				this.cmbsUrgenza.DataValueField = "ID";
				this.cmbsUrgenza.DataBind();
			}
		}

		private void BindStatus()
		{
			this.cmbsStatus.Items.Clear();
		
			Classi.ManStraordinaria.ManCorrettivaPaging  _Richiesta= new Classi.ManStraordinaria.ManCorrettivaPaging();
						
			DataSet Ds = _Richiesta.GetStatus();
		
			if (Ds.Tables[0].Rows.Count > 0)
			{
				this.cmbsStatus.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					Ds.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Stato -", "");
				this.cmbsStatus.DataTextField = "DESCRIZIONE";
				this.cmbsStatus.DataValueField = "ID";
				this.cmbsStatus.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Stato -";
				this.cmbsStatus.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}
		private void BindTipoInterventoAter()
		{
			//Caricol il combo Del Tipo Intervento
			cmbsTipoIntervento.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ClassiAnagrafiche.TipoIntervento  _TipoIntervento = new TheSite.Classi.ClassiAnagrafiche.TipoIntervento();

			DataSet _MyDs;
			_MyDs = _TipoIntervento.GetData();
			

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsTipoIntervento.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione_breve", "ID", "- Selezionare il Tipo Intervento -", "");
				this.cmbsTipoIntervento.DataTextField = "descrizione_breve";
				this.cmbsTipoIntervento.DataValueField = "id";
				this.cmbsTipoIntervento.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Tipo Intervento -";
				this.cmbsTipoIntervento.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
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
			this.btnsRicerca.Click += new System.EventHandler(this.btnsRicerca_Click);
			this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
			this.cmdExcel.Click += new System.EventHandler(this.cmdExcel_Click);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.DataGridRicerca2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca2_ItemCommand);
			this.DataGridRicerca2.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca2_PageIndexChanged);
			this.DataGridRicerca2.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca2_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			DataGridRicerca.CurrentPageIndex =0;
			DataGridRicerca2.CurrentPageIndex =0;
			if (cmbsTipoManutenzione.SelectedValue=="3")
			{
				// Manutenzione Straordinaria				
				Ricerca(true);		
			}
			else			
			{	// Manutenzione Richiesta				
				RicercaManRichiesta(true);
			}
		}

		protected Int32 _currentPageNumber = 1;
		private void Ricerca(bool reset)
		{
			
			// Manutenzione Straordinaria
			DataGridRicerca.Visible=true;
			GridTitle1.Visible=true;
			DataGridRicerca2.Visible=false;
			Gridtitle2.Visible=false;

			Classi.ManStraordinaria.ManCorrettivaPaging  _Richiesta = new TheSite.Classi.ManStraordinaria.ManCorrettivaPaging();						
			S_ControlsCollection _SCollection=GetData();			

			S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
			s_p_pageindex.ParameterName = "pageindex";
			s_p_pageindex.DbType = CustomDBType.Integer;
			s_p_pageindex.Direction = ParameterDirection.Input;
			s_p_pageindex.Index = 17;
			s_p_pageindex.Value=DataGridRicerca.CurrentPageIndex +1;			
			_SCollection.Add(s_p_pageindex);

			S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
			s_p_pagesize.ParameterName = "pagesize";
			s_p_pagesize.DbType = CustomDBType.Integer;
			s_p_pagesize.Direction = ParameterDirection.Input;
			s_p_pagesize.Index = 18;
			s_p_pagesize.Value= DataGridRicerca.PageSize;			
			_SCollection.Add(s_p_pagesize);
             
			DataSet _MyDs = _Richiesta.GetSfogliaRDLPaging(_SCollection).Copy();	

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];


			if (reset==true)
			{
				 _SCollection.Clear();
				 _SCollection=GetData();
				int _totalRecords = _Richiesta.GetCount(_SCollection);
				this.GridTitle1.NumeroRecords=_totalRecords.ToString();
			}

		

			DataGridRicerca.Visible = true;
			GridTitle1.Visible =true;
			GridTitle1.hplsNuovo.Visible=false;

			if (int.Parse(this.GridTitle1.NumeroRecords) ==0) 
			{
				DataGridRicerca.CurrentPageIndex=0;
				GridTitle1.DescriptionTitle="Nessun dato trovato."; 
			}
			else
			{
				CalcolaTotali(_MyDs.Tables[0]);
				GridTitle1.DescriptionTitle=""; 
			}
			this.DataGridRicerca.VirtualItemCount =int.Parse(this.GridTitle1.NumeroRecords);
			this.DataGridRicerca.DataBind();
			
		
		}

		/// <summary>
		/// 
		/// </summary>
		private void CalcolaTotali(DataTable dt)
		{
			foreach(DataRow dr in dt.Rows)
			{
				if (dr["importostimato"]!=DBNull.Value)
					totpreventivo+=double.Parse(dr["importostimato"].ToString());
				if (dr["importoconsuntivo"]!=DBNull.Value)
					totconsuntivo+=double.Parse(dr["importoconsuntivo"].ToString());
			}
		}
		/// <summary>
		/// Recupera i data per la ricerca
		/// </summary>
		/// <returns></returns>
		private S_ControlsCollection GetData()
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_Bl_Id = new S_Controls.Collections.S_Object();
			s_p_Bl_Id.ParameterName = "p_Bl_Id";
			s_p_Bl_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Bl_Id.Direction = ParameterDirection.Input;
			s_p_Bl_Id.Size =50;
			s_p_Bl_Id.Index = 0;
			s_p_Bl_Id.Value = RicercaModulo1.TxtCodice.Text;
			_SCollection.Add(s_p_Bl_Id);

			S_Controls.Collections.S_Object s_p_campus = new S_Controls.Collections.S_Object();
			s_p_campus.ParameterName = "p_campus";
			s_p_campus.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_campus.Direction = ParameterDirection.Input;
			s_p_campus.Index = 1;
			s_p_campus.Size=50;
			s_p_campus.Value = RicercaModulo1.TxtRicerca.Text;			
			_SCollection.Add(s_p_campus);

			S_Controls.Collections.S_Object s_p_Wr_Id = new S_Controls.Collections.S_Object();
			s_p_Wr_Id.ParameterName = "p_Wr_Id";
			s_p_Wr_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wr_Id.Direction = ParameterDirection.Input;
			s_p_Wr_Id.Index = 2;
			s_p_Wr_Id.Size=50;
			s_p_Wr_Id.Value = (this.txtsRichiesta.Text=="")?0:Int32.Parse(this.txtsRichiesta.Text);		
			_SCollection.Add(s_p_Wr_Id);

			S_Controls.Collections.S_Object s_p_Addetto = new S_Controls.Collections.S_Object();
			s_p_Addetto.ParameterName = "p_Addetto";
			s_p_Addetto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Addetto.Direction = ParameterDirection.Input;
			s_p_Addetto.Index = 3;
			s_p_Addetto.Size=50;
			s_p_Addetto.Value = this.Addetti1.NomeCompleto;			
			_SCollection.Add(s_p_Addetto);

			S_Controls.Collections.S_Object s_p_DataDa = new S_Controls.Collections.S_Object();
			s_p_DataDa.ParameterName = "p_DataDa";
			s_p_DataDa.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataDa.Direction = ParameterDirection.Input;
			s_p_DataDa.Index = 4;
			s_p_DataDa.Size= 10;
			s_p_DataDa.Value = (CalendarPicker1.Datazione.Text =="")? "":CalendarPicker1.Datazione.Text;  			
			_SCollection.Add(s_p_DataDa);

			S_Controls.Collections.S_Object s_p_DataA = new S_Controls.Collections.S_Object();
			s_p_DataA.ParameterName = "p_DataA";
			s_p_DataA.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataA.Direction = ParameterDirection.Input;
			s_p_DataA.Index = 5;
			s_p_DataA.Size= 10;
			s_p_DataA.Value = (CalendarPicker2.Datazione.Text =="")? "":CalendarPicker2.Datazione.Text;  			
			_SCollection.Add(s_p_DataA);

			S_Controls.Collections.S_Object s_p_Wo_Id = new S_Controls.Collections.S_Object();
			s_p_Wo_Id.ParameterName = "p_Wo_Id";
			s_p_Wo_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wo_Id.Direction = ParameterDirection.Input;
			s_p_Wo_Id.Index = 6;
			s_p_Wo_Id.Size=50;
			s_p_Wo_Id.Value = (this.txtsOrdine.Text=="")?0:Int32.Parse(this.txtsOrdine.Text);		
			_SCollection.Add(s_p_Wo_Id);
			
			S_Controls.Collections.S_Object s_p_Servizio = new S_Controls.Collections.S_Object();
			s_p_Servizio.ParameterName = "p_ID_Servizio";
			s_p_Servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Servizio.Direction = ParameterDirection.Input;
			s_p_Servizio.Index = 7;
			s_p_Servizio.Value = (cmbsServizio.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsServizio.SelectedValue);			
			_SCollection.Add(s_p_Servizio);

			S_Controls.Collections.S_Object s_p_Status = new S_Controls.Collections.S_Object();
			s_p_Status.ParameterName = "p_Status";
			s_p_Status.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Status.Direction = ParameterDirection.Input;
			s_p_Status.Index = 8;
			s_p_Status.Value = (cmbsStatus.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsStatus.SelectedValue);			
			_SCollection.Add(s_p_Status);

			S_Controls.Collections.S_Object s_p_Richiedente = new S_Controls.Collections.S_Object();
			s_p_Richiedente.ParameterName = "p_Richiedente";
			s_p_Richiedente.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Richiedente.Direction = ParameterDirection.Input;
			s_p_Richiedente.Index = 9;
			s_p_Richiedente.Size=50;
			s_p_Richiedente.Value = this.Richiedenti1.NomeCompleto;			
			_SCollection.Add(s_p_Richiedente);

			S_Controls.Collections.S_Object s_p_Priority = new S_Controls.Collections.S_Object();
			s_p_Priority.ParameterName = "p_Priority";
			s_p_Priority.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Priority.Direction = ParameterDirection.Input;
			s_p_Priority.Index = 10;
			s_p_Priority.Value = (cmbsUrgenza.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsUrgenza.SelectedValue);			
			_SCollection.Add(s_p_Priority);

			S_Controls.Collections.S_Object s_p_Descrizione = new S_Controls.Collections.S_Object();
			s_p_Descrizione.ParameterName = "p_Descrizione";
			s_p_Descrizione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Descrizione.Direction = ParameterDirection.Input;
			s_p_Descrizione.Index = 11;
			s_p_Descrizione.Size= 255;
			s_p_Descrizione.Value = txtDescrizione.Text;			
			_SCollection.Add(s_p_Descrizione);

			S_Controls.Collections.S_Object s_p_Gruppo = new S_Controls.Collections.S_Object();
			s_p_Gruppo.ParameterName = "p_Gruppo";
			s_p_Gruppo.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Gruppo.Direction = ParameterDirection.Input;
			s_p_Gruppo.Index = 12;
			s_p_Gruppo.Value = (cmbsGruppo.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsGruppo.SelectedValue);			
			_SCollection.Add(s_p_Gruppo);
		
			S_Controls.Collections.S_Object p_tipointerventoater = new S_Controls.Collections.S_Object();
			p_tipointerventoater.ParameterName = "p_tipointerventoater";
			p_tipointerventoater.DbType = CustomDBType.Integer;
			p_tipointerventoater.Direction = ParameterDirection.Input;
			p_tipointerventoater.Index = 13;
			p_tipointerventoater.Value = (cmbsTipoIntervento.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsTipoIntervento.SelectedValue);			
			_SCollection.Add(p_tipointerventoater);

			S_Controls.Collections.S_Object p_datainizio = new S_Controls.Collections.S_Object();
			p_datainizio.ParameterName = "p_datainizio";
			p_datainizio.DbType = CustomDBType.VarChar;
			p_datainizio.Direction = ParameterDirection.Input;
			p_datainizio.Index = 14;
			p_datainizio.Size= 10;
			p_datainizio.Value = (CalendarPicker3.Datazione.Text =="")? "":CalendarPicker3.Datazione.Text;  			
			_SCollection.Add(p_datainizio);

			S_Controls.Collections.S_Object p_datafine = new S_Controls.Collections.S_Object();
			p_datafine.ParameterName = "p_datafine";
			p_datafine.DbType =CustomDBType.VarChar;
			p_datafine.Direction = ParameterDirection.Input;
			p_datafine.Index = 15;
			p_datafine.Size= 10;
			p_datafine.Value = (CalendarPicker4.Datazione.Text =="")? "":CalendarPicker4.Datazione.Text;  			
			_SCollection.Add(p_datafine);

			S_Controls.Collections.S_Object p_prog = new S_Controls.Collections.S_Object();
			p_prog.ParameterName = "p_progetto";
			p_prog.DbType =CustomDBType.VarChar;
			p_prog.Direction = ParameterDirection.Input;
			p_prog.Index = 16;
			p_prog.Size= 10;
			if (RicercaModulo1.idProg.Value=="")
				p_prog.Value="";
			else
			p_prog.Value = RicercaModulo1.idProg.Value;  			
			_SCollection.Add(p_prog);


			return _SCollection;
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			Ricerca(false);
		}
		double totpreventivo=0;
		double totconsuntivo=0;
		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string varapp="";
			if(Request["VarApp"]!=null)
				varapp="&VarApp=" + Request["VarApp"];
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{ 
				
				ImageButton _img2 = (ImageButton) e.Item.Cells[2].FindControl("Imagebutton2");
				ImageButton _imgCOS = (ImageButton) e.Item.Cells[14].FindControl("imgCostiStra");
				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("lnkDett");
				string appo2 ="CompletaRdl.aspx?wr_id=' + DataBinder.Eval(Container.DataItem,'WR_ID')" + varapp;
				string appo="CompletaRdl.ascx?wr_id=' + DataBinder.Eval(Container.DataItem,'WR_ID')" + varapp;

				switch(e.Item.Cells[16].Text)
				{
					case"1":
						_img1.Attributes.Add("CommandArgument",appo);
						_img1.ToolTip="Martino";
						break;
					case"2":
						_img1.Attributes.Add("CommandArgument",appo2);
						_img1.ToolTip="Papardo";
						break;
				}
			
				string s_id_stato="1";
				if(e.Item.Cells[15].Text!= s_id_stato)
				{
					_img2.Visible=false;
					//_imgCOS.Visible = true;
				}
				if(e.Item.Cells[15].Text == "4")
				{
					_imgCOS.Visible = true;
				}
				_img1.Attributes.Add("title","Emetti o Completa Richiesta di Lavoro");	
				_img2.Attributes.Add("title", "Visualizza/Modifica Richiesta di Lavoro");
				_imgCOS.Attributes.Add("title", "Costi Operativi");
               
				System.Web.UI.HtmlControls.HtmlImage _imagepre=new System.Web.UI.HtmlControls.HtmlImage();
				System.Web.UI.HtmlControls.HtmlImage _imagecon=new System.Web.UI.HtmlControls.HtmlImage();
				System.Web.UI.HtmlControls.HtmlAnchor  _linkPre = (System.Web.UI.HtmlControls.HtmlAnchor) e.Item.Cells[3].Controls[1];
				System.Web.UI.HtmlControls.HtmlAnchor  _linkCon = (System.Web.UI.HtmlControls.HtmlAnchor) e.Item.Cells[4].Controls[1];

				DataRowView dr=(DataRowView)(e.Item.DataItem);

				//				if (dr["importostimato"]!=DBNull.Value)
				//				  totpreventivo+=double.Parse(dr["importostimato"].ToString());
				//				if (dr["importoconsuntivo"]!=DBNull.Value)
				//                  totconsuntivo+=double.Parse(dr["importoconsuntivo"].ToString());

				if(dr["pdfpreventivo"]==DBNull.Value || dr["pdfpreventivo"].ToString()=="")
				{
					_linkPre.HRef="#"; 
					_imagepre.Src="../Images/no pdf_logo.gif";
					_imagepre.Attributes.Add("title","Nessun Pdf Preventivo");
				}
				else
				{
					_linkPre.HRef="javascript:openpdf('" + dr["WR_ID"].ToString() + "','PREV','" + dr["pdfpreventivo"].ToString().Replace("'","`")  + "');"; 
					_imagepre.Src="../Images/pdf_logo.gif";
					_imagepre.Attributes.Add("title","Pdf Preventivo");
				}
				_imagepre.Style.Add("Width","22px");
				_imagepre.Style.Add("Height","26px");
				_imagepre.Style.Add("Border","0");
				_linkPre.Controls.Add( _imagepre);

				if(dr["pdfconsuntivo"]==DBNull.Value || dr["pdfconsuntivo"].ToString()=="")
				{
					_linkCon.HRef="#"; 
					_imagecon.Src="../Images/no pdf_logo.gif";
					_imagecon.Attributes.Add("title","Nessun Pdf Consuntivo");
				}
				else
				{
					_linkCon.HRef="javascript:openpdf('" + dr["WR_ID"].ToString() + "','CONS','" + dr["pdfconsuntivo"].ToString().Replace("'","`")  + "');"; 
					_imagecon.Src="../Images/pdf_logo.gif";
					_imagecon.Attributes.Add("title","Pdf Consuntivo");
				}
				_imagecon.Style.Add("Width","22px");
				_imagecon.Style.Add("Height","26px");
				_imagecon.Style.Add("Border","0"); 
				_linkCon.Controls.Add( _imagecon);
 
			
			}

			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[1].ColumnSpan=3; 
				e.Item.Cells[1].Text ="<b>TOTALE GENERALE</b>";
				e.Item.Cells[9].HorizontalAlign =HorizontalAlign.Right; 
				e.Item.Cells[9].Text ="<b>" + totpreventivo.ToString("C") +"</b>";
				e.Item.Cells[10].HorizontalAlign =HorizontalAlign.Right; 
				e.Item.Cells[10].Text ="<b>" + totconsuntivo.ToString("C")+"</b>";
				e.Item.Cells[12].Visible=false;
				e.Item.Cells[13].Visible=false;

			}

			
			
			//			ImageButton _img2 = (ImageButton) e.Item.Cells[2].FindControl("Imagebutton2");
			//			_img2.ToolTip="Visualizza RdL";
			//				
			//			string codsavvion=e.Item.Cells[6].Text.Trim();
			//
			//			int vion=e.Item.Cells[6].Text.Trim().Length;
			//				
			//			if (codsavvion.ToString()=="&nbsp;")
			//			{					
			//				_img2.Visible=false;
			//			}



			



		}

		private void cmdExcel_Click(object sender, System.EventArgs e)
		{
			Csy.WebControls.Export 	_objExport = new Csy.WebControls.Export();
			DataTable _dt = new DataTable();			
			
			if (cmbsTipoManutenzione.SelectedValue=="3")
			{
				Classi.ManStraordinaria.ManCorrettivaPaging  _Richiesta = new TheSite.Classi.ManStraordinaria.ManCorrettivaPaging();						
				S_ControlsCollection _SCollection=GetData();			

				DataSet _MyDs = _Richiesta.GetSfogliaRDLExcel(_SCollection).Copy();	

				_dt = _MyDs.Tables[0].Copy();		// MS
			}
			else
				_dt = GetWordExcel().Tables[0].Copy();	// MOR	

			if (_dt.Rows.Count != 0)
			{
				_objExport.ExportDetails(_dt, Csy.WebControls.Export.ExportFormat.Excel, "exp.xls" ); 		
			}
			else
			{
				String scriptString = "<script language=JavaScript>alert('Nessun elemento da esportare');";
				scriptString += "<";
				scriptString += "/";
				scriptString += "script>";

				if(!this.IsClientScriptBlockRegistered("clientScriptexp"))
					this.RegisterStartupScript ("clientScriptexp", scriptString);
			}
			
		}
		

	

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string varapp="";
			if(Request["VarApp"]!=null)
				varapp="&VarApp=" + Request["VarApp"];

			if (e.CommandName=="Dettaglio")
			{	
				string appo2 ="CompletaRdl.aspx?wr_id=" +(e.Item.Cells[0].Text) +varapp ;
				string appo="CompletaRdl.aspx?wr_id=" +(e.Item.Cells[0].Text) + varapp ;
				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("lnkDett");

				

				_myColl.AddControl(this.Page.Controls,ParentType.Page );
				string s_url = e.CommandArgument.ToString();
						
				string IdStato = e.Item.Cells[15].Text.Trim();					
				switch (IdStato)
				{
					case "1":
					case "7":
					case "15":	
					switch(e.Item.Cells[16].Text)
					{
						case"1":
						
							_myColl.AddControl(this.Page.Controls, ParentType.Page);
							Server.Transfer(appo);	
							break;
						case"2":
							_myColl.AddControl(this.Page.Controls, ParentType.Page);
							Server.Transfer(appo2);
							break;
					}				
//						_myColl.AddControl(this.Page.Controls, ParentType.Page);
//						Server.Transfer(s_url);	
						break;
					default:
					switch(e.Item.Cells[16].Text)
					{
						case"1":
						
							_myColl.AddControl(this.Page.Controls, ParentType.Page);
							appo += "&c=true";
							Server.Transfer(appo);	
							break;
						case"2":
							//_myColl.AddControl(this.Page.Controls, ParentType.Page);
							appo2 += "&c=true";
							Server.Transfer(appo2);
							break;
					}			
//						s_url += "&c=true";
//						_myColl.AddControl(this.Page.Controls, ParentType.Page);
//						Server.Transfer(s_url);	
						break;
				}							
									
			}
			if (e.CommandName=="Modifica")
			{
				_myColl.AddControl(this.Page.Controls,ParentType.Page );
				string s_url = e.CommandArgument.ToString() + varapp;
	
				Server.Transfer(s_url);
			
			}

		}

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("SfogliaRdlPaging.aspx?FunID=" + ViewState["FunId"]);
		}

		#region ManRichiesta
		private void RicercaManRichiesta(bool reset)
		{
			
			// Manutenzione Richiesta
			DataGridRicerca.Visible=false;
			GridTitle1.Visible=false;
			DataGridRicerca2.Visible=true;
			Gridtitle2.Visible=true;

//			Classi.ManStraordinaria.ManCorrettivaPaging			
			Classi.ManOrdinaria.RichiestaPaging   _Richiesta = new TheSite.Classi.ManOrdinaria.RichiestaPaging();						
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_Bl_Id = new S_Controls.Collections.S_Object();
			s_p_Bl_Id.ParameterName = "p_Bl_Id";
			s_p_Bl_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Bl_Id.Direction = ParameterDirection.Input;
			s_p_Bl_Id.Size =50;
			s_p_Bl_Id.Index = _SCollection.Count;
			s_p_Bl_Id.Value = RicercaModulo1.TxtCodice.Text;
			_SCollection.Add(s_p_Bl_Id);

			S_Controls.Collections.S_Object s_p_campus = new S_Controls.Collections.S_Object();
			s_p_campus.ParameterName = "p_campus";
			s_p_campus.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_campus.Direction = ParameterDirection.Input;
			s_p_campus.Index = _SCollection.Count;
			s_p_campus.Size=50;
			s_p_campus.Value = RicercaModulo1.TxtRicerca.Text;			
			_SCollection.Add(s_p_campus);

			S_Controls.Collections.S_Object s_p_Wr_Id = new S_Controls.Collections.S_Object();
			s_p_Wr_Id.ParameterName = "p_Wr_Id";
			s_p_Wr_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wr_Id.Direction = ParameterDirection.Input;
			s_p_Wr_Id.Index = _SCollection.Count;
			s_p_Wr_Id.Size=50;
			s_p_Wr_Id.Value = (this.txtsRichiesta.Text=="")?0:Int32.Parse(this.txtsRichiesta.Text);		
			_SCollection.Add(s_p_Wr_Id);

			S_Controls.Collections.S_Object s_p_Addetto = new S_Controls.Collections.S_Object();
			s_p_Addetto.ParameterName = "p_Addetto";
			s_p_Addetto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Addetto.Direction = ParameterDirection.Input;
			s_p_Addetto.Index = _SCollection.Count;
			s_p_Addetto.Size=50;
			s_p_Addetto.Value = this.Addetti1.NomeCompleto;			
			_SCollection.Add(s_p_Addetto);

			S_Controls.Collections.S_Object s_p_DataDa = new S_Controls.Collections.S_Object();
			s_p_DataDa.ParameterName = "p_DataDa";
			s_p_DataDa.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataDa.Direction = ParameterDirection.Input;
			s_p_DataDa.Index = _SCollection.Count;
			s_p_DataDa.Size= 10;
			s_p_DataDa.Value = (CalendarPicker1.Datazione.Text =="")? "":CalendarPicker1.Datazione.Text;  			
			_SCollection.Add(s_p_DataDa);

			S_Controls.Collections.S_Object s_p_DataA = new S_Controls.Collections.S_Object();
			s_p_DataA.ParameterName = "p_DataA";
			s_p_DataA.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataA.Direction = ParameterDirection.Input;
			s_p_DataA.Index = _SCollection.Count;
			s_p_DataA.Size= 10;
			s_p_DataA.Value = (CalendarPicker2.Datazione.Text =="")? "":CalendarPicker2.Datazione.Text;  			
			_SCollection.Add(s_p_DataA);

			S_Controls.Collections.S_Object s_p_Wo_Id = new S_Controls.Collections.S_Object();
			s_p_Wo_Id.ParameterName = "p_Wo_Id";
			s_p_Wo_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wo_Id.Direction = ParameterDirection.Input;
			s_p_Wo_Id.Index = _SCollection.Count;
			s_p_Wo_Id.Size=50;
			s_p_Wo_Id.Value = (this.txtsOrdine.Text=="")?0:Int32.Parse(this.txtsOrdine.Text);		
			_SCollection.Add(s_p_Wo_Id);
			
			S_Controls.Collections.S_Object s_p_Servizio = new S_Controls.Collections.S_Object();
			s_p_Servizio.ParameterName = "p_ID_Servizio";
			s_p_Servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Servizio.Direction = ParameterDirection.Input;
			s_p_Servizio.Index = _SCollection.Count;
			s_p_Servizio.Value = (cmbsServizio.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsServizio.SelectedValue);			
			_SCollection.Add(s_p_Servizio);

			S_Controls.Collections.S_Object s_p_Status = new S_Controls.Collections.S_Object();
			s_p_Status.ParameterName = "p_Status";
			s_p_Status.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Status.Direction = ParameterDirection.Input;
			s_p_Status.Index = _SCollection.Count;
			s_p_Status.Value = (cmbsStatus.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsStatus.SelectedValue);			
			_SCollection.Add(s_p_Status);

			S_Controls.Collections.S_Object s_p_Richiedente = new S_Controls.Collections.S_Object();
			s_p_Richiedente.ParameterName = "p_Richiedente";
			s_p_Richiedente.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Richiedente.Direction = ParameterDirection.Input;
			s_p_Richiedente.Index = _SCollection.Count;
			s_p_Richiedente.Size=50;
			s_p_Richiedente.Value = this.Richiedenti1.NomeCompleto;			
			_SCollection.Add(s_p_Richiedente);

			S_Controls.Collections.S_Object s_p_Priority = new S_Controls.Collections.S_Object();
			s_p_Priority.ParameterName = "p_Priority";
			s_p_Priority.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Priority.Direction = ParameterDirection.Input;
			s_p_Priority.Index = _SCollection.Count;
			s_p_Priority.Value = (cmbsUrgenza.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsUrgenza.SelectedValue);			
			_SCollection.Add(s_p_Priority);

			S_Controls.Collections.S_Object s_p_Descrizione = new S_Controls.Collections.S_Object();
			s_p_Descrizione.ParameterName = "p_Descrizione";
			s_p_Descrizione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Descrizione.Direction = ParameterDirection.Input;
			s_p_Descrizione.Index = _SCollection.Count;
			s_p_Descrizione.Size= 255;
			s_p_Descrizione.Value = txtDescrizione.Text;			
			_SCollection.Add(s_p_Descrizione);

			S_Controls.Collections.S_Object s_p_Gruppo = new S_Controls.Collections.S_Object();
			s_p_Gruppo.ParameterName = "p_Gruppo";
			s_p_Gruppo.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Gruppo.Direction = ParameterDirection.Input;
			s_p_Gruppo.Index = _SCollection.Count;
			s_p_Gruppo.Value = (cmbsGruppo.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsGruppo.SelectedValue);			
			_SCollection.Add(s_p_Gruppo);
		    
			S_Controls.Collections.S_Object p_prog = new S_Controls.Collections.S_Object();
			p_prog.ParameterName = "p_progetto";
			p_prog.DbType =CustomDBType.VarChar;
			p_prog.Direction = ParameterDirection.Input;
			p_prog.Index = _SCollection.Count;
			p_prog.Size= 10;
			if (RicercaModulo1.idProg.Value=="")
				p_prog.Value=0;
			else
				p_prog.Value = RicercaModulo1.idProg.Value;  			
			_SCollection.Add(p_prog);

			Double _totalPages = 1;
			if (reset==true)
			{
	
				int _totalRecords = _Richiesta.GetCount(_SCollection);
				this.Gridtitle2.NumeroRecords=_totalRecords.ToString();
				if ((_totalRecords % DataGridRicerca2.PageSize) == 0)
					_totalPages = _totalRecords / DataGridRicerca2.PageSize;
				else
					_totalPages = (_totalRecords / DataGridRicerca2.PageSize)+1;
				//DataGridRicerca.VirtualItemCount =_totalRecords;
				//				TotalPages2.Text = ( System.Math.Ceiling ( _totalPages ) ).ToString();
			}
			else
			{
				_totalPages = Double.Parse (this.Gridtitle2.NumeroRecords);
			}

			S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
			s_p_pageindex.ParameterName = "pageindex";
			s_p_pageindex.DbType = CustomDBType.Integer;
			s_p_pageindex.Direction = ParameterDirection.Input;
			s_p_pageindex.Index = _SCollection.Count;
			s_p_pageindex.Value=DataGridRicerca2.CurrentPageIndex+1;			
			_SCollection.Add(s_p_pageindex);

			S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
			s_p_pagesize.ParameterName = "pagesize";
			s_p_pagesize.DbType = CustomDBType.Integer;
			s_p_pagesize.Direction = ParameterDirection.Input;
			s_p_pagesize.Index = _SCollection.Count;
			s_p_pagesize.Value= DataGridRicerca.PageSize;			
			_SCollection.Add(s_p_pagesize);

			DataSet _MyDs = _Richiesta.GetSfogliaRDL(_SCollection).Copy();		

		
			
			
			

			this.DataGridRicerca2.VirtualItemCount =int.Parse(this.Gridtitle2.NumeroRecords);
			this.DataGridRicerca2.DataSource = _MyDs.Tables[0];

			DataGridRicerca2.Visible = true;
			Gridtitle2.Visible =true;
			Gridtitle2.hplsNuovo.Visible=false;

			if (int.Parse(this.Gridtitle2.NumeroRecords) ==0) 
			{
				DataGridRicerca2.CurrentPageIndex=0;
				Gridtitle2.DescriptionTitle="Nessun dato trovato."; 
			}
			else
			{
				Gridtitle2.DescriptionTitle=""; 
			}
			
			this.DataGridRicerca2.DataBind();
			
			

		}

		public DataSet GetWordExcel()
		{
			Classi.ManOrdinaria.Richiesta  _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();						
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_Bl_Id = new S_Controls.Collections.S_Object();
			s_p_Bl_Id.ParameterName = "p_Bl_Id";
			s_p_Bl_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Bl_Id.Direction = ParameterDirection.Input;
			s_p_Bl_Id.Size =50;
			s_p_Bl_Id.Index = 0;
			s_p_Bl_Id.Value = RicercaModulo1.TxtCodice.Text;
			_SCollection.Add(s_p_Bl_Id);

			S_Controls.Collections.S_Object s_p_campus = new S_Controls.Collections.S_Object();
			s_p_campus.ParameterName = "p_campus";
			s_p_campus.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_campus.Direction = ParameterDirection.Input;
			s_p_campus.Index = 1;
			s_p_campus.Size=50;
			s_p_campus.Value = RicercaModulo1.TxtRicerca.Text;			
			_SCollection.Add(s_p_campus);

			S_Controls.Collections.S_Object s_p_Wr_Id = new S_Controls.Collections.S_Object();
			s_p_Wr_Id.ParameterName = "p_Wr_Id";
			s_p_Wr_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wr_Id.Direction = ParameterDirection.Input;
			s_p_Wr_Id.Index = 2;
			s_p_Wr_Id.Size=50;
			s_p_Wr_Id.Value = (this.txtsRichiesta.Text=="")?0:Int32.Parse(this.txtsRichiesta.Text);		
			_SCollection.Add(s_p_Wr_Id);

			S_Controls.Collections.S_Object s_p_Addetto = new S_Controls.Collections.S_Object();
			s_p_Addetto.ParameterName = "p_Addetto";
			s_p_Addetto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Addetto.Direction = ParameterDirection.Input;
			s_p_Addetto.Index = 3;
			s_p_Addetto.Size=50;
			s_p_Addetto.Value = this.Addetti1.NomeCompleto;			
			_SCollection.Add(s_p_Addetto);

			S_Controls.Collections.S_Object s_p_DataDa = new S_Controls.Collections.S_Object();
			s_p_DataDa.ParameterName = "p_DataDa";
			s_p_DataDa.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataDa.Direction = ParameterDirection.Input;
			s_p_DataDa.Index = 4;
			s_p_DataDa.Size= 10;
			s_p_DataDa.Value = (CalendarPicker1.Datazione.Text =="")? "":CalendarPicker1.Datazione.Text;  			
			_SCollection.Add(s_p_DataDa);

			S_Controls.Collections.S_Object s_p_DataA = new S_Controls.Collections.S_Object();
			s_p_DataA.ParameterName = "p_DataA";
			s_p_DataA.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataA.Direction = ParameterDirection.Input;
			s_p_DataA.Index = 5;
			s_p_DataA.Size= 10;
			s_p_DataA.Value = (CalendarPicker2.Datazione.Text =="")? "":CalendarPicker2.Datazione.Text;  			
			_SCollection.Add(s_p_DataA);

			S_Controls.Collections.S_Object s_p_Wo_Id = new S_Controls.Collections.S_Object();
			s_p_Wo_Id.ParameterName = "p_Wo_Id";
			s_p_Wo_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wo_Id.Direction = ParameterDirection.Input;
			s_p_Wo_Id.Index = 6;
			s_p_Wo_Id.Size=50;
			s_p_Wo_Id.Value = (this.txtsOrdine.Text=="")?0:Int32.Parse(this.txtsOrdine.Text);		
			_SCollection.Add(s_p_Wo_Id);
			
			S_Controls.Collections.S_Object s_p_Servizio = new S_Controls.Collections.S_Object();
			s_p_Servizio.ParameterName = "p_ID_Servizio";
			s_p_Servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Servizio.Direction = ParameterDirection.Input;
			s_p_Servizio.Index = 7;
			s_p_Servizio.Value = (cmbsServizio.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsServizio.SelectedValue);			
			_SCollection.Add(s_p_Servizio);

			S_Controls.Collections.S_Object s_p_Status = new S_Controls.Collections.S_Object();
			s_p_Status.ParameterName = "p_Status";
			s_p_Status.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Status.Direction = ParameterDirection.Input;
			s_p_Status.Index = 8;
			s_p_Status.Value = (cmbsStatus.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsStatus.SelectedValue);			
			_SCollection.Add(s_p_Status);

			S_Controls.Collections.S_Object s_p_Richiedente = new S_Controls.Collections.S_Object();
			s_p_Richiedente.ParameterName = "p_Richiedente";
			s_p_Richiedente.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Richiedente.Direction = ParameterDirection.Input;
			s_p_Richiedente.Index = 9;
			s_p_Richiedente.Size=50;
			s_p_Richiedente.Value = this.Richiedenti1.NomeCompleto;			
			_SCollection.Add(s_p_Richiedente);

			S_Controls.Collections.S_Object s_p_Priority = new S_Controls.Collections.S_Object();
			s_p_Priority.ParameterName = "p_Priority";
			s_p_Priority.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Priority.Direction = ParameterDirection.Input;
			s_p_Priority.Index = 10;
			s_p_Priority.Value = (cmbsUrgenza.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsUrgenza.SelectedValue);			
			_SCollection.Add(s_p_Priority);

			S_Controls.Collections.S_Object s_p_Descrizione = new S_Controls.Collections.S_Object();
			s_p_Descrizione.ParameterName = "p_Descrizione";
			s_p_Descrizione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Descrizione.Direction = ParameterDirection.Input;
			s_p_Descrizione.Index = 11;
			s_p_Descrizione.Size= 255;
			s_p_Descrizione.Value = txtDescrizione.Text;			
			_SCollection.Add(s_p_Descrizione);

			S_Controls.Collections.S_Object s_p_Gruppo = new S_Controls.Collections.S_Object();
			s_p_Gruppo.ParameterName = "p_Gruppo";
			s_p_Gruppo.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Gruppo.Direction = ParameterDirection.Input;
			s_p_Gruppo.Index = 12;
			s_p_Gruppo.Value = (cmbsGruppo.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsGruppo.SelectedValue);			
			_SCollection.Add(s_p_Gruppo);
		
			return  _Richiesta.GetSfogliaRDLExcel(_SCollection).Copy();		
		}

		#endregion

		private void DataGridRicerca2_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca2.CurrentPageIndex = e.NewPageIndex;			
			RicercaManRichiesta(false);
		
		}

		private void DataGridRicerca2_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string varapp="";
			if(Request["VarApp"]!=null)
				varapp="&VarApp=" + Request["VarApp"];

			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{ 
				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton1");
				ImageButton _img3 = (ImageButton) e.Item.Cells[2].FindControl("Imagebutton3");
				ImageButton _imgCOR = (ImageButton) e.Item.Cells[14].FindControl("imgCostiRich");

				string appo2 ="CompletaRdl.aspx?wr_id=' + DataBinder.Eval(Container.DataItem,'WR_ID')" + varapp;
				string appo="CompletaRdl.aspx?wr_id=' + DataBinder.Eval(Container.DataItem,'WR_ID')" + varapp;
				
				switch(e.Item.Cells[16].Text)
				{
					case"1":
						_img1.Attributes.Add("CommandArgument",appo);
						_img1.ToolTip="Martino";
						break;
					case"2":
						_img1.Attributes.Add("CommandArgument",appo2);
						_img1.ToolTip="Papardo";
						break;
				}


				string s_id_stato="1";
				if(e.Item.Cells[15].Text!= s_id_stato)
				{
					_img3.Visible = false;
					//_imgCOR.Visible = true;
			
				}
				if(e.Item.Cells[15].Text == "4")
				{
					_imgCOR.Visible = true;			
				}
				
				string descrizione="";
				string indirizzo="";
				string ditta="";
				
			
				_img1.Attributes.Add("title","Emetti o Completa Richiesta di Lavoro");	
				_img3.Attributes.Add("title", "Visualizza/Modifica Richiesta di Lavoro");
				_imgCOR.Attributes.Add("title", "Costi Operativi");


				if (e.Item.Cells[2].Text.Trim().Length > 20) 
				{
					indirizzo=e.Item.Cells[2].Text.Trim().Substring(0,18) + "..."; 
					e.Item.Cells[2].ToolTip=e.Item.Cells[2].Text;
					e.Item.Cells[2].Text=indirizzo;
				} 
				
				if (e.Item.Cells[12].Text.Trim().Length >20) 
				{
					descrizione=e.Item.Cells[12].Text.Trim().Substring(0,18) + "..."; 
					e.Item.Cells[12].ToolTip=e.Item.Cells[12].Text;
					e.Item.Cells[12].Text=descrizione;
				} 

				if (e.Item.Cells[5].Text.Trim().Length >12) 
				{
					ditta=e.Item.Cells[5].Text.Trim().Substring(0,10) + "..."; 
					e.Item.Cells[5].ToolTip=e.Item.Cells[5].Text;
					e.Item.Cells[5].Text=ditta;
				} 
							
			}
		
		}

		private void DataGridRicerca2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string varapp="";
			if(Request["VarApp"]!=null)
				varapp="&VarApp=" + Request["VarApp"];

			if (e.CommandName=="Modifica")
			{
				_myColl.AddControl(this.Page.Controls,ParentType.Page );
				string s_url = e.CommandArgument.ToString() + varapp;
	
				Server.Transfer(s_url);
			
			}
			
			if (e.CommandName=="Dettaglio")
			{				
				_myColl.AddControl(this.Page.Controls,ParentType.Page );
				string s_url = e.CommandArgument.ToString();		
				string IdStato = e.Item.Cells[15].Text.Trim();	
				string appo2 ="CompletaRdl.aspx?wr_id=" +(e.Item.Cells[0].Text) + varapp;
				string appo="CompletaRdl.aspx?wr_id=" +(e.Item.Cells[0].Text) + varapp;
				switch (IdStato)
				{
					case "1":
					case "7":
					case "15":											
					switch(e.Item.Cells[16].Text)
					{
						case"1":
						
							_myColl.AddControl(this.Page.Controls, ParentType.Page);
							Server.Transfer(appo);	
							break;
						case"2":
							_myColl.AddControl(this.Page.Controls, ParentType.Page);
							Server.Transfer(appo2);
							break;
					}				
						break;
					default:
					switch(e.Item.Cells[16].Text)
					{
						case"1":
						
							_myColl.AddControl(this.Page.Controls, ParentType.Page);
							appo += "&c=true";
							Server.Transfer(appo);	
							break;
						case"2":
							//_myColl.AddControl(this.Page.Controls, ParentType.Page);
							appo2 += "&c=true";
							Server.Transfer(appo2);
							break;
					}			
						break;
				}							
									
			}
		}

		


	}
}

