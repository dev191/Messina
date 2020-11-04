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
	/// Descrizione di riepilogo per SfogliaRdLEliminare.
	/// </summary>
	public class SfogliaRdLEliminare : System.Web.UI.Page
	{
		public Classi.SiteModule _SiteModule;
		protected S_Controls.S_TextBox txtsRichiesta;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected S_Controls.S_TextBox txtsOrdine;
		protected S_Controls.S_ComboBox cmbsStatus;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_ComboBox cmbsGruppo;
		protected S_Controls.S_ComboBox cmbsUrgenza;
		protected S_Controls.S_TextBox txtDescrizione;
		protected S_Controls.S_ComboBox cmbsTipoManutenzione;
		protected S_Controls.S_ComboBox cmbsTipoIntervento;
		protected S_Controls.S_Button btnsRicerca;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca2;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected WebControls.GridTitle Gridtitle2;
		protected WebControls.PageTitle PageTitle1;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;
		protected WebControls.CalendarPicker CalendarPicker3;
		protected WebControls.CalendarPicker CalendarPicker4;
		protected WebControls.Addetti Addetti1;
		protected WebControls.Richiedenti Richiedenti1;	
		public TheSite.ManutenzioneCorrettiva.VisualizzaRdlEliminare _fp = null;

	
		#region variabili
		public static string HelpLink = string.Empty;		
		
		public static int FunId = 0;	
		MyCollection.clMyCollection _myColl = new MyCollection.clMyCollection();
		#endregion


		public MyCollection.clMyCollection _Contenitore
		{
			get {return _myColl;}
		}

	
		private void Page_Load(object sender, System.EventArgs e)
		{

			string _mypage="./ManutenzioneCorrettiva/SfogliaRdlEliminare.aspx";			
			_SiteModule = new TheSite.Classi.SiteModule(_mypage);
			FunId = _SiteModule.ModuleId;

			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = "SFOGLIA RDL DA ELIMINARE";
						
			RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);

			if(!Page.IsPostBack)
			{	
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];
			
				CompareValidator1.ControlToValidate = CalendarPicker2.ID + ":" + CalendarPicker2.Datazione.ID;
				CompareValidator1.ControlToCompare =  CalendarPicker1.ID + ":" + CalendarPicker1.Datazione.ID;
				DataGridRicerca2.Visible = false;				
				Gridtitle2.hplsNuovo.Visible = false;
				Gridtitle2.Visible =false;
				BindServizio("");
				BindGruppo();
				BindUrgenza();
				BindStatus();	
				BindTipoInterventoAter();
				BinTipoManutenzione();

				DataGridRicerca2.Visible=true;
				Gridtitle2.Visible=true;
					
				
				if(Context.Handler is TheSite.ManutenzioneCorrettiva.VisualizzaRdlEliminare)
				{
					_fp = (TheSite.ManutenzioneCorrettiva.VisualizzaRdlEliminare)Context.Handler;
					if (_fp!=null) 
					{				
					
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);		
						Ricerca(true);	
					}
				}
	
			
			}
	
			Gridtitle2.hplsNuovo.Visible = false;
		}

		private void BindServizio(string CodEdificio)
		{
			Gridtitle2.DescriptionTitle="";
			Addetti1.Set_BL_ID(CodEdificio);

			DataGridRicerca2.Visible = false;
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
		
			Classi.ManStraordinaria.GestioneRdl _GestioneRdl= new Classi.ManStraordinaria.GestioneRdl(Context.User.Identity.Name);
			
			
			DataSet Ds = _GestioneRdl.GetGuppo();
		
			if (Ds.Tables[0].Rows.Count > 0)
			{
				this.cmbsGruppo.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					Ds.Tables[0], "descrizione", "richiedenti_tipo_id", "- Selezionare un Gruppo -", "");
				this.cmbsGruppo.DataTextField = "descrizione";
				this.cmbsGruppo.DataValueField = "richiedenti_tipo_id";
				this.cmbsGruppo.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Gruppo -";
				this.cmbsGruppo.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		private void BindUrgenza()
		{
			this.cmbsUrgenza.Items.Clear();
		
			Classi.ManStraordinaria.GestioneRdl _GestioneRdl= new Classi.ManStraordinaria.GestioneRdl(Context.User.Identity.Name);
			
			
			DataSet Ds = _GestioneRdl.GetUrgenza();
		
			if (Ds.Tables[0].Rows.Count > 0)
			{
				this.cmbsUrgenza.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					Ds.Tables[0], "descrizione", "id_priority", "- Selezionare una Urgenza -", "");
				this.cmbsUrgenza.DataTextField = "descrizione";
				this.cmbsUrgenza.DataValueField = "id_priority";
				this.cmbsUrgenza.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Urgenza -";
				this.cmbsUrgenza.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		private void BindStatus()
		{
			this.cmbsStatus.Items.Clear();
		
			Classi.ManStraordinaria.Richiesta  _Richiesta= new Classi.ManStraordinaria.Richiesta();
						
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
			this.DataGridRicerca2.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca2_ItemCreated);
			this.DataGridRicerca2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca2_ItemCommand);
			this.DataGridRicerca2.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca2_PageIndexChanged);
			this.DataGridRicerca2.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca2_ItemDataBaund);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Ricerca(bool reset)
		{
			
			
			DataGridRicerca2.Visible=true;
			Gridtitle2.Visible=true;
		
			DataSet _MyDs=GetRdlDaEliminare();

			this.DataGridRicerca2.DataSource = _MyDs.Tables[0];

			Double _totalPages = 1;
			if (reset==true)
			{
				int _totalRecords = GetRdlDaEliminareCount();
				this.Gridtitle2.NumeroRecords=_totalRecords.ToString();
				if ((_totalRecords % DataGridRicerca2.PageSize) == 0)
					_totalPages = _totalRecords / DataGridRicerca2.PageSize;
				else
					_totalPages = (_totalRecords / DataGridRicerca2.PageSize)+1;
			}
			else
			{
				_totalPages = Double.Parse (this.Gridtitle2.NumeroRecords);
			}
			
			this.DataGridRicerca2.VirtualItemCount =int.Parse(this.Gridtitle2.NumeroRecords);
			this.DataGridRicerca2.DataBind();
			
		}
		
		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("SfogliaRdlEliminare.aspx?FunID=" + ViewState["FunId"]);	
		}

		private DataSet GetRdlDaEliminare()
		{
			Classi.ManStraordinaria.Richiesta  _Richiesta = new TheSite.Classi.ManStraordinaria.Richiesta();						
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

				// Paolo: nuovi campi per la paginazione (03/09/07)

				S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
				s_p_pageindex.ParameterName = "pageindex";
				s_p_pageindex.DbType = CustomDBType.Integer;
				s_p_pageindex.Direction = ParameterDirection.Input;
				s_p_pageindex.Index =  _SCollection.Count + 1;  
				s_p_pageindex.Value=DataGridRicerca2.CurrentPageIndex +1;			
				_SCollection.Add(s_p_pageindex);

				S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
				s_p_pagesize.ParameterName = "pagesize";
				s_p_pagesize.DbType = CustomDBType.Integer;
				s_p_pagesize.Direction = ParameterDirection.Input;
				s_p_pagesize.Index = _SCollection.Count + 1; 
				s_p_pagesize.Value= DataGridRicerca2.PageSize;			
				_SCollection.Add(s_p_pagesize);

				DataSet _MyDs = _Richiesta.GetSfogliaRDLDaEliminare(_SCollection).Copy();	

			return _MyDs;
		}

		// Nuova

		private int GetRdlDaEliminareCount()
		{
			Classi.ManStraordinaria.Richiesta  _Richiesta = new TheSite.Classi.ManStraordinaria.Richiesta();						
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


			DataSet _MyDs = _Richiesta.GetSfogliaRDLDaEliminareCount(_SCollection).Copy();	

			return int.Parse(_MyDs.Tables[0].Rows[0][0].ToString());
		}

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
		//	DataGridRicerca.CurrentPageIndex =0;
			DataGridRicerca2.CurrentPageIndex =0;
			Ricerca(true);
		}

		

		private void DataGridRicerca2_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca2.CurrentPageIndex = e.NewPageIndex;			
			Ricerca(false);
		}
		//		private void DataGridRicerca2_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		//		{
		//			if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.EditItem) ||(e.Item.ItemType == ListItemType.AlternatingItem))
		//				{
		//					TableCell myTableCell;
		//					myTableCell = e.Item.Cells[1];
		//					ImageButton myIButton = (ImageButton)myTableCell.Controls[1];
		//					//myIButton.Attributes.Add("onclick","return confirm(\"Sei sicuro di Cancellare l'apparecchiatura?\");");
		//					myIButton.Attributes.Add("onclick","alert(\"Sei sicuro di Cancellare l'apparecchiatura?\");");
		//				}
		//			
		//		}

		private void DataGridRicerca2_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			System.Web.UI.WebControls.ImageButton  _img = (System.Web.UI.WebControls.ImageButton) (e.Item.FindControl("Imagebutton3"));								
			if(_img!=null)
			{
				string numeroRdlC = e.Item.Cells[7].Text.ToString().Trim();
				//_img.Attributes.Add("onclick", "return confirm('Sei sicuro di voler eliminare la RdL n°' + numeroRdl + '?');");	
				_img.Attributes.Add("onclick", "return confirm('Sei sicuro di voler eliminare la RdL n°?');");	
				
				 
				
			}
		}

		private void DataGridRicerca2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if ((e.Item.ItemType == ListItemType.Pager) ||
				(e.Item.ItemType == ListItemType.Header)) return;

			if (e.CommandName=="Dettaglio")
			{				
				_myColl.AddControl(this.Page.Controls,ParentType.Page );
				string s_url = e.CommandArgument.ToString();
				Server.Transfer(s_url);						
			}

			ImageButton btn  = (ImageButton)e.CommandSource;

			if (btn.CommandName  == "Delete")
			{
				
				DeleteItem(btn.CommandArgument);
				
			}

		}
		

		private void DeleteItem(string id)
		{
			Console.WriteLine(id); 
			if (id=="") return;
			
			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_wr_id = new S_Object();
			s_p_wr_id.ParameterName = "p_Wr_Id";
			s_p_wr_id.DbType = CustomDBType.Integer ;
			s_p_wr_id.Direction = ParameterDirection.Input;
			s_p_wr_id.Index =0;
			s_p_wr_id.Value = int.Parse(id);
			_SColl.Add(s_p_wr_id);
			try
			{
				TheSite.Classi.ManStraordinaria.Richiesta _RichiestaElimina= new TheSite.Classi.ManStraordinaria.Richiesta();
				_RichiestaElimina.DeleteRdL(_SColl);

	//			DataGridRicerca.CurrentPageIndex =0;
				DataGridRicerca2.CurrentPageIndex =0;
				Ricerca(true);
				//				TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura  _DatiApparecchiatura = new TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura(Context.User.Identity.Name);
				//				DataSet Ds=_DatiApparecchiatura.GetApparecchiatura(int.Parse(id));
				//				if (Ds.Tables[0].Rows.Count>0)
				//					deleteFile(Ds.Tables[0].Rows[0]);
				//
				//				_DatiApparecchiatura.Delete(_SColl, 0);
				//				DataGrid1.CurrentPageIndex=0;

				//				Ricerca();
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);  
				this.Page.RegisterStartupScript("messaggio","<script language'javascript'>alert(\"Impossibile cancellare l'apparecchiatura perchè è utilizzata in altre tabelle\");</script>"); 
			}
		}

		private void DataGridRicerca2_ItemDataBaund(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			System.Web.UI.WebControls.ImageButton  _img = (System.Web.UI.WebControls.ImageButton) (e.Item.FindControl("Imagebutton3"));								
			if(_img!=null)
			{
				//string numeroRdl = e.Item.Cells[7].Text.ToString().Trim();
				string confirmMessaggio = "return confirm('Sei sicuro di voler eliminare la RdL n° " + e.Item.Cells[7].Text.ToString().Trim() + " ?');";

				_img.Attributes.Add("onclick", confirmMessaggio);	
			
			}
			string Dettagglio = e.Item.Cells[13].Text;
			e.Item.Cells[13].Attributes.Add("title",Dettagglio);
			if(Dettagglio.Length > 20)
			{
				string det = Dettagglio.Substring(1,20) + "...";
				Dettagglio = det;
			}
			e.Item.Cells[13].Text = Dettagglio;
		}
	}
}
