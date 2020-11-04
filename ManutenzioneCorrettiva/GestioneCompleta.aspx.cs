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
	/// Descrizione di riepilogo per GestioneCompleta.
	/// </summary>
	public class GestioneCompleta : System.Web.UI.Page
	{
		public Classi.SiteModule _SiteModule;
		protected S_Controls.S_TextBox S_Txtrichiesta;
		protected S_Controls.S_TextBox S_Txtoperatore;
		protected S_Controls.S_TextBox S_Ttxtordinelavoro;
		protected S_Controls.S_ComboBox S_cbditta;
		protected S_Controls.S_ComboBox S_cbgruppo;
		protected S_Controls.S_TextBox S_Txtdescrizione;
		protected S_Controls.S_ComboBox S_Cburgenza;
		protected Csy.WebControls.DataPanel DataPanel1;
		protected WebControls.PageTitle PageTitle1;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;
		protected WebControls.RicercaModulo RicercaModulo1;
	
		public static int FunId = 0;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_Button S_Btreset;
		protected S_Controls.S_Button S_btMostra;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;	
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.Addetti Addetti1;
		protected WebControls.Richiedenti Richiedenti1;
		bool IsEditable=false;
		public static string HelpLink = string.Empty;

		MyCollection.clMyCollection _myColl = new MyCollection.clMyCollection();
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected S_Controls.S_Button cmdExcel;
		protected S_Controls.S_ComboBox cmbTipoManutenzione;

		EditCompletamento  _fp=null;

		public MyCollection.clMyCollection _Contenitore
		{
			get {return _myColl;}
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			// ***********************  MODIFICA PER I PERMESSI SULLA PAGINA CORRENTE **********************
			string _mypage="./ManutenzioneCorrettiva/GestioneCompleta.aspx";			
			_SiteModule = new TheSite.Classi.SiteModule(_mypage);
			// *********************************************************************************************
			this.IsEditable=_SiteModule.IsEditable;
			this.DataGrid1.Columns[0].Visible = IsEditable;	

			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			//Associazione del delegato a una funzione quando viene selezionato un edificio
			RicercaModulo1.DelegateIDBLEdificio1 +=new  WebControls.DelegateIDBLEdificio(this.BindServizio);
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{ 
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"]; 

				CompareValidator1.ControlToValidate = CalendarPicker2.ID + ":" + CalendarPicker2.Datazione.ID;
				CompareValidator1.ControlToCompare =  CalendarPicker1.ID + ":" + CalendarPicker1.Datazione.ID;
				LoadDitte();
				LoadGruppo();
				
				BindServizio("");				
				Setvisible(false);
				//Valorizzo i Parametri Immessi
				if(Context.Handler is EditCompletamento)
				{
					_fp = (EditCompletamento)Context.Handler;
					if (_fp!=null) 
					{						
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);		
						Execute(true);
					}
				}
			}
			
			
			S_Txtrichiesta.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			S_Txtrichiesta.Attributes.Add("onpaste","return nonpaste();");
			S_Ttxtordinelavoro.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			S_Ttxtordinelavoro.Attributes.Add("onpaste","return nonpaste();");
			



			//Script da aggiungere per ogni submit
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("if (typeof(Page_ClientValidate) == 'function') { ");
			sb.Append("if (Page_ClientValidate() == false) { return false; }} ");
			sb.Append("this.value = 'Attendere...';");
			sb.Append("this.disabled = true;");
			sb.Append(this.Page.GetPostBackEventReference(this.S_btMostra));
			sb.Append(";");
			this.S_btMostra.Attributes.Add("onclick", sb.ToString());
			
		}
	


		/// <summary>
		/// Funzione associata al delegato che viene scatenato quando viene selezionato un edificio
		/// </summary>
		/// <param name="CodEdificio"></param>
		private void BindServizio(string CodEdificio)
		{
			LoadUrgenza(CodEdificio);

			int idprog = 0;
			if(Request.QueryString["VarApp"]!=null)
				idprog = Convert.ToInt32(Request.QueryString["VarApp"].ToString());
	
			this.cmbsServizio.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ClassiDettaglio.Servizi  _Servizio = new TheSite.Classi.ClassiDettaglio.Servizi(Context.User.Identity.Name);
			DataSet _MyDs;
			if (CodEdificio!="")
				_MyDs = _Servizio.GetServiziPerProg(idprog,int.Parse(CodEdificio));
			else
				_MyDs = _Servizio.GetServiziPerProg(idprog,0);
		

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "");
				this.cmbsServizio.DataTextField = "DESCRIZIONE";
				this.cmbsServizio.DataValueField = "IDSERVIZIO";
				this.cmbsServizio.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Servizio -";
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}

			Addetti1.Set_BL_ID(CodEdificio);
// 
//			this.cmbsServizio.Items.Clear();		
//			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
//
//			Classi.ClassiDettaglio.Servizi  _Servizio = new TheSite.Classi.ClassiDettaglio.Servizi(Context.User.Identity.Name);
//
//			DataSet _MyDs;
//
//			if (CodEdificio!="")
//			{
//				S_Controls.Collections.S_Object s_Bl_Id = new S_Object();
//				s_Bl_Id.ParameterName = "p_Bl_Id";
//				s_Bl_Id.DbType = CustomDBType.VarChar;
//				s_Bl_Id.Direction = ParameterDirection.Input;
//				s_Bl_Id.Index = 0;
//				s_Bl_Id.Value =	CodEdificio;
//				s_Bl_Id.Size = 8;
//
//				
//				S_Controls.Collections.S_Object s_ID_Servizio = new S_Object();
//				s_ID_Servizio.ParameterName = "p_ID_Servizio";
//				s_ID_Servizio.DbType = CustomDBType.Integer;
//				s_ID_Servizio.Direction = ParameterDirection.Input;
//				s_ID_Servizio.Index = 1;
//				s_ID_Servizio.Value = 0;
//
//				CollezioneControlli.Add(s_Bl_Id);				
//				CollezioneControlli.Add(s_ID_Servizio);
//
//				_MyDs = _Servizio.GetData(CollezioneControlli);
//				
//			}
//			else
//			{
//				_MyDs = _Servizio.GetData();
//			}
//
//			if (_MyDs.Tables[0].Rows.Count > 0)
//			{
//				this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
//					_MyDs.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "");
//				this.cmbsServizio.DataTextField = "DESCRIZIONE";
//				this.cmbsServizio.DataValueField = "IDSERVIZIO";
//				this.cmbsServizio.DataBind();				
//			}
//			else
//			{
//				string s_Messagggio = "- Selezionare un Servizio -";
//				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, ""));
//			}
		}

		/// <summary>
		/// Carico i  Livelli di urgenza
		/// </summary>
		private void LoadUrgenza(string Codice)
		{

			string Progetto="";
			if(Request.QueryString["VarApp"]!=null)
				Progetto=Request.QueryString["VarApp"];
			DataSet ds;
			if(Codice!="")
			{
				int cod= Convert.ToInt32(Codice);
				Classi.ClassiDettaglio.Urgenza _Urgenza = new TheSite.Classi.ClassiDettaglio.Urgenza();
				ds = _Urgenza.GetPriorita(cod,Progetto);

				this.S_Cburgenza.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					ds.Tables[0], "DESCRIPTION", "ID", "Selezionare una Priorità", "0");

				this.S_Cburgenza.DataTextField = "DESCRIPTION";
				this.S_Cburgenza.DataValueField = "ID";
				this.S_Cburgenza.DataBind();

			}
			else
			{
				Classi.ClassiDettaglio.Urgenza _Urgenza = new TheSite.Classi.ClassiDettaglio.Urgenza();
				ds = _Urgenza.GetPriorita(0,Progetto);
				this.S_Cburgenza.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					ds.Tables[0], "DESCRIPTION", "ID", "Selezionare una Priorità", "0");
				this.S_Cburgenza.DataTextField = "DESCRIPTION";
				this.S_Cburgenza.DataValueField = "ID";
				this.S_Cburgenza.DataBind();
			}
			
		}

		/// <summary>
		/// Carico i gruppi nella Combo
		/// </summary>
		private void LoadGruppo()
		{
			string Progetto="";
			if(Request.QueryString["VarApp"]!=null)
				Progetto=Request.QueryString["VarApp"];

			Classi.ClassiAnagrafiche.Richiedenti_tipo _Richiedenti = new TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo();	
			DataSet Ds = _Richiedenti.GetAllAddProg(Progetto).Copy();

			//Carico il combo del Gruppo
			this.S_cbgruppo.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
				Ds.Tables[0], "descrizione", "id", "Selezionare un Gruppo", "0");
			this.S_cbgruppo.DataTextField = "descrizione";
			this.S_cbgruppo.DataValueField = "id";
			this.S_cbgruppo.DataBind();
		}
		/// <summary>
		/// Carico le ditte nella Combo
		/// </summary>
		private void LoadDitte()	
		{
			this.S_cbditta.Items.Clear();
		
			Classi.ManOrdinaria.GestioneRdl _GestioneRdl= new Classi.ManOrdinaria.GestioneRdl(Context.User.Identity.Name);
			
			
			DataSet Ds = _GestioneRdl.GetData();
		
			if (Ds.Tables[0].Rows.Count > 0)
			{
				this.S_cbditta.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					Ds.Tables[0], "descrizione", "ditta_id", "- Selezionare una Ditta -", "");
				this.S_cbditta.DataTextField = "descrizione";
				this.S_cbditta.DataValueField = "ditta_id";
				this.S_cbditta.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Ditta -";
				this.S_cbditta.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}


		#region Esecuzione della Query di Ricerca
		/// <summary>
		/// Esegue la ricerca
		/// </summary>
		private void Execute(bool reset)
		{
			//Creazione dei parametri
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_operatore = new S_Object();
			s_p_operatore.ParameterName = "p_operatore";
			s_p_operatore.DbType = CustomDBType.VarChar;
			s_p_operatore.Direction = ParameterDirection.Input;
			s_p_operatore.Index = CollezioneControlli.Count;
			s_p_operatore.Value =this.S_Txtoperatore.Text;
			s_p_operatore.Size=250; 
			CollezioneControlli.Add(s_p_operatore);

			S_Controls.Collections.S_Object s_p_servizio_id = new S_Object();
			s_p_servizio_id.ParameterName = "p_servizio_id";
			s_p_servizio_id.DbType = CustomDBType.Integer;
			s_p_servizio_id.Direction = ParameterDirection.Input;
			s_p_servizio_id.Index = CollezioneControlli.Count;
			s_p_servizio_id.Value =(cmbsServizio.SelectedValue=="")? 0:Int32.Parse(cmbsServizio.SelectedValue);
			CollezioneControlli.Add(s_p_servizio_id);
            
			S_Controls.Collections.S_Object s_p_campus = new S_Object();
			s_p_campus.ParameterName = "p_campus";
			s_p_campus.DbType = CustomDBType.VarChar;
			s_p_campus.Direction = ParameterDirection.Input;
			s_p_campus.Index = CollezioneControlli.Count;
			s_p_campus.Value =this.RicercaModulo1.Campus;
			s_p_campus.Size=250; 
			CollezioneControlli.Add(s_p_campus);

			S_Controls.Collections.S_Object s_p_bl_id = new S_Object();
			s_p_bl_id.ParameterName = "p_bl_id";
			s_p_bl_id.DbType = CustomDBType.VarChar;
			s_p_bl_id.Direction = ParameterDirection.Input;
			s_p_bl_id.Index = CollezioneControlli.Count ;
			s_p_bl_id.Value =this.RicercaModulo1.BlId;
			s_p_bl_id.Size=250; 
			CollezioneControlli.Add(s_p_bl_id);

			S_Controls.Collections.S_Object s_p_wr_id = new S_Object();
			s_p_wr_id.ParameterName = "p_wr_id";
			s_p_wr_id.DbType = CustomDBType.Integer;
			s_p_wr_id.Direction = ParameterDirection.Input;
			s_p_wr_id.Index = CollezioneControlli.Count;
			s_p_wr_id.Value = (this.S_Txtrichiesta.Text=="")?0:Int32.Parse(this.S_Txtrichiesta.Text);
			CollezioneControlli.Add(s_p_wr_id);

			S_Controls.Collections.S_Object s_p_wo_id = new S_Object();
			s_p_wo_id.ParameterName = "p_wo_id";
			s_p_wo_id.DbType = CustomDBType.Integer;
			s_p_wo_id.Direction = ParameterDirection.Input;
			s_p_wo_id.Index = CollezioneControlli.Count;
			s_p_wo_id.Value =(this.S_Ttxtordinelavoro.Text=="")?0:Int32.Parse(this.S_Ttxtordinelavoro.Text);
			CollezioneControlli.Add(s_p_wo_id);

			S_Controls.Collections.S_Object s_p_gruppo = new S_Object();
			s_p_gruppo.ParameterName = "p_gruppo";
			s_p_gruppo.DbType = CustomDBType.Integer;
			s_p_gruppo.Direction = ParameterDirection.Input;
			s_p_gruppo.Index = CollezioneControlli.Count;
			s_p_gruppo.Value =(this.S_cbgruppo.SelectedValue=="")?0:Int32.Parse(this.S_cbgruppo.SelectedValue);
			CollezioneControlli.Add(s_p_gruppo);

			S_Controls.Collections.S_Object s_p_richiedente = new S_Object();
			s_p_richiedente.ParameterName = "p_richiedente";
			s_p_richiedente.DbType = CustomDBType.VarChar;
			s_p_richiedente.Direction = ParameterDirection.Input;
			s_p_richiedente.Index = CollezioneControlli.Count;
			s_p_richiedente.Size=35;
			s_p_richiedente.Value =this.Richiedenti1.NomeCompleto;  
			CollezioneControlli.Add(s_p_richiedente);

			S_Controls.Collections.S_Object s_p_descrizione = new S_Object();
			s_p_descrizione.ParameterName = "p_descrizione";
			s_p_descrizione.DbType = CustomDBType.VarChar;
			s_p_descrizione.Direction = ParameterDirection.Input;
			s_p_descrizione.Index = CollezioneControlli.Count;
			s_p_descrizione.Size=2000;
			s_p_descrizione.Value =this.S_Txtdescrizione.Text;  
			CollezioneControlli.Add(s_p_descrizione);

			S_Controls.Collections.S_Object s_p_urgenza = new S_Object();
			s_p_urgenza.ParameterName = "p_urgenza";
			s_p_urgenza.DbType = CustomDBType.Integer ;
			s_p_urgenza.Direction = ParameterDirection.Input;
			s_p_urgenza.Index = CollezioneControlli.Count;
			s_p_urgenza.Value =(S_Cburgenza.SelectedValue=="")? 0:Int32.Parse(S_Cburgenza.SelectedValue);  
			CollezioneControlli.Add(s_p_urgenza);

			S_Controls.Collections.S_Object s_p_ditta = new S_Object();
			s_p_ditta.ParameterName = "p_ditta";
			s_p_ditta.DbType = CustomDBType.Integer;
			s_p_ditta.Direction = ParameterDirection.Input;
			s_p_ditta.Index = CollezioneControlli.Count;
			s_p_ditta.Value =(S_cbditta.SelectedValue=="")? 0:int.Parse(S_cbditta.SelectedValue);  
			CollezioneControlli.Add(s_p_ditta);

			S_Controls.Collections.S_Object s_p_dates = new S_Object();
			s_p_dates.ParameterName = "p_dates";
			s_p_dates.DbType = CustomDBType.VarChar;
			s_p_dates.Direction = ParameterDirection.Input;
			s_p_dates.Index = CollezioneControlli.Count;
			s_p_dates.Size=10;
			s_p_dates.Value =(CalendarPicker1.Datazione.Text =="")? "":CalendarPicker1.Datazione.Text;  
			CollezioneControlli.Add(s_p_dates);
			
			S_Controls.Collections.S_Object s_p_datee = new S_Object();
			s_p_datee.ParameterName = "p_datee";
			s_p_datee.DbType = CustomDBType.VarChar;
			s_p_datee.Direction = ParameterDirection.Input;
			s_p_datee.Index = CollezioneControlli.Count;
			s_p_datee.Size=10;
			s_p_datee.Value =(CalendarPicker2.Datazione.Text =="")?"": CalendarPicker2.Datazione.Text;  
			CollezioneControlli.Add(s_p_datee);

			S_Controls.Collections.S_Object s_p_addetto = new S_Object();
			s_p_addetto.ParameterName = "p_addetto";
			s_p_addetto.DbType = CustomDBType.VarChar;
			s_p_addetto.Direction = ParameterDirection.Input;
			s_p_addetto.Index = CollezioneControlli.Count;
			s_p_addetto.Size=250;
			s_p_addetto.Value =this.Addetti1.NomeCompleto;  
			CollezioneControlli.Add(s_p_addetto);

			S_Controls.Collections.S_Object s_p_tipomanutenzione = new S_Object();
			s_p_tipomanutenzione.ParameterName = "p_tipomanutenzione";
			s_p_tipomanutenzione.DbType = CustomDBType.Integer;
			s_p_tipomanutenzione.Direction = ParameterDirection.Input;
			s_p_tipomanutenzione.Index = CollezioneControlli.Count;
			s_p_tipomanutenzione.Value =Int32.Parse(cmbTipoManutenzione.SelectedValue);  
			CollezioneControlli.Add(s_p_tipomanutenzione);

			S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
			s_p_pageindex.ParameterName = "pageindex";
			s_p_pageindex.DbType = CustomDBType.Integer;
			s_p_pageindex.Direction = ParameterDirection.Input;
			s_p_pageindex.Index = CollezioneControlli.Count +1;
			s_p_pageindex.Value=DataGrid1.CurrentPageIndex +1;			
			CollezioneControlli.Add(s_p_pageindex);

			S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
			s_p_pagesize.ParameterName = "pagesize";
			s_p_pagesize.DbType = CustomDBType.Integer;
			s_p_pagesize.Direction = ParameterDirection.Input;
			s_p_pagesize.Index = CollezioneControlli.Count +1;
			s_p_pagesize.Value= DataGrid1.PageSize;			
			CollezioneControlli.Add(s_p_pagesize);

			Classi.ManCorrettiva.ClManCorrettiva _ClManCorrettiva=new TheSite.Classi.ManCorrettiva.ClManCorrettiva(Context.User.Identity.Name);
			DataSet Ds=_ClManCorrettiva.GetDataCompletamento(CollezioneControlli);
            this.DataGrid1.DataSource =Ds.Tables[0];
			Double _totalPages = 1;
			if (reset==true)
			{
				CollezioneControlli.RemoveAt(CollezioneControlli.Count-1);
				CollezioneControlli.RemoveAt(CollezioneControlli.Count-1);
				CollezioneControlli.RemoveAt(CollezioneControlli.Count-1);
				CollezioneControlli.RemoveAt(CollezioneControlli.Count-1);
				int _totalRecords = _ClManCorrettiva.GetDataCompletamentoCount(CollezioneControlli);;
				this.GridTitle1.NumeroRecords=_totalRecords.ToString();
				if ((_totalRecords % DataGrid1.PageSize) == 0)
					_totalPages = _totalRecords / DataGrid1.PageSize;
				else
					_totalPages = (_totalRecords / DataGrid1.PageSize)+1;
			}
			else
			{
				_totalPages = Double.Parse (this.GridTitle1.NumeroRecords);
			}


			if (int.Parse(this.GridTitle1.NumeroRecords)>0)
			{
				Setvisible(true);
				DataGrid1.Visible=true;
				GridTitle1.DescriptionTitle=""; 			
			}
			else
			{
				GridTitle1.DescriptionTitle="Nessun dato trovato."; 
				Setvisible(false);
			}
			this.DataGrid1.VirtualItemCount =int.Parse(this.GridTitle1.NumeroRecords);
			this.DataGrid1.DataBind();
		}
		#endregion

		/// <summary>
		/// Imposta la visualizzazione di alcuni controlli
		/// </summary>
		/// <param name="visible"></param>
		private void Setvisible(bool visible)
		{
		
			this.DataGrid1.Visible = visible;
			this.GridTitle1.hplsNuovo.Visible=false;   
			this.GridTitle1.Visible= visible;
		}

		/// <summary>
		/// Funzione per valutare la lunghezza della stringa passata
		/// </summary>
		/// <param name="sender"></param>
		/// <returns></returns>
		public string evalLenght(Object sender)
		{
			if ((sender == null) || (sender == DBNull.Value))
			{
				return "";
			}
			else
			{
				if (sender.ToString().Length   < 31) 
					return sender.ToString();
				else
					return	sender.ToString().Substring(0,30); 
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
			this.S_btMostra.Click += new System.EventHandler(this.S_btMostra_Click);
			this.S_Btreset.Click += new System.EventHandler(this.S_Btreset_Click);
			this.cmdExcel.Click += new System.EventHandler(this.cmdExcel_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Svuota i campi di ricerca
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void S_Btreset_Click(object sender, System.EventArgs e)
		{
			string varapp="";
			if(Request["VarApp"]!=null)
				varapp="&VarApp=" + Request["VarApp"];

			Response.Redirect("GestioneCompleta.aspx?FunId=" + ViewState["FunId"] + varapp);
		}
		/// <summary>
		/// Esegue la Paginazione
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			DataGrid1.CurrentPageIndex=e.NewPageIndex;
			Execute(false);
		}
		/// <summary>
		/// Esegue la ricerca
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void S_btMostra_Click(object sender, System.EventArgs e)
		{
			DataGrid1.CurrentPageIndex=0;
			Execute(true);
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{ 
				
				ImageButton _img1 = (ImageButton) e.Item.Cells[0].FindControl("lnkDett");
				_img1.Attributes.Add("title","Completa Ordine di Lavoro");	

				string descrizione="";
				string indirizzo="";
				string ditta="";
				string stato="";
				
				if (e.Item.Cells[2].Text.Trim().Length > 20) 
				{
					indirizzo=e.Item.Cells[2].Text.Trim().Substring(0,18) + "..."; 
					e.Item.Cells[2].ToolTip=e.Item.Cells[2].Text;
					e.Item.Cells[2].Text=indirizzo;
				} 
				
				if (e.Item.Cells[11].Text.Trim().Length >20) 
				{
					descrizione=e.Item.Cells[11].Text.Trim().Substring(0,18) + "..."; 
					e.Item.Cells[11].ToolTip=e.Item.Cells[11].Text;
					e.Item.Cells[11].Text=descrizione;
				} 

				if (e.Item.Cells[5].Text.Trim().Length >12) 
				{
					ditta=e.Item.Cells[5].Text.Trim().Substring(0,10) + "..."; 
					e.Item.Cells[5].ToolTip=e.Item.Cells[5].Text;
					e.Item.Cells[5].Text=ditta;
				} 
				if (e.Item.Cells[8].Text.Trim().Length >12) 
				{
					stato=e.Item.Cells[8].Text.Trim().Substring(0,10) + "..."; 
					e.Item.Cells[8].ToolTip=e.Item.Cells[8].Text;
					e.Item.Cells[8].Text=stato;
				} 
							
			}
		}

		private void cmdExcel_Click(object sender, System.EventArgs e)
		{
			Csy.WebControls.Export 	_objExport = new Csy.WebControls.Export();
			DataTable _dt = new DataTable();
			DataSet Ds= GetWordExcel();
			_dt =Ds.Tables[0];	
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

		public DataSet GetWordExcel()
		{
			//Creazione dei parametri
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_operatore = new S_Object();
			s_p_operatore.ParameterName = "p_operatore";
			s_p_operatore.DbType = CustomDBType.VarChar;
			s_p_operatore.Direction = ParameterDirection.Input;
			s_p_operatore.Index = CollezioneControlli.Count;
			s_p_operatore.Value =this.S_Txtoperatore.Text;
			s_p_operatore.Size=250; 
			CollezioneControlli.Add(s_p_operatore);

			S_Controls.Collections.S_Object s_p_servizio_id = new S_Object();
			s_p_servizio_id.ParameterName = "p_servizio_id";
			s_p_servizio_id.DbType = CustomDBType.Integer;
			s_p_servizio_id.Direction = ParameterDirection.Input;
			s_p_servizio_id.Index = CollezioneControlli.Count;
			s_p_servizio_id.Value =(cmbsServizio.SelectedValue=="")? 0:Int32.Parse(cmbsServizio.SelectedValue);
			CollezioneControlli.Add(s_p_servizio_id);
            
			S_Controls.Collections.S_Object s_p_campus = new S_Object();
			s_p_campus.ParameterName = "p_campus";
			s_p_campus.DbType = CustomDBType.VarChar;
			s_p_campus.Direction = ParameterDirection.Input;
			s_p_campus.Index = CollezioneControlli.Count;
			s_p_campus.Value =this.RicercaModulo1.Campus;
			s_p_campus.Size=250; 
			CollezioneControlli.Add(s_p_campus);

			S_Controls.Collections.S_Object s_p_bl_id = new S_Object();
			s_p_bl_id.ParameterName = "p_bl_id";
			s_p_bl_id.DbType = CustomDBType.VarChar;
			s_p_bl_id.Direction = ParameterDirection.Input;
			s_p_bl_id.Index = CollezioneControlli.Count ;
			s_p_bl_id.Value =this.RicercaModulo1.BlId;
			s_p_bl_id.Size=250; 
			CollezioneControlli.Add(s_p_bl_id);

			S_Controls.Collections.S_Object s_p_wr_id = new S_Object();
			s_p_wr_id.ParameterName = "p_wr_id";
			s_p_wr_id.DbType = CustomDBType.Integer;
			s_p_wr_id.Direction = ParameterDirection.Input;
			s_p_wr_id.Index = CollezioneControlli.Count;
			s_p_wr_id.Value = (this.S_Txtrichiesta.Text=="")?0:Int32.Parse(this.S_Txtrichiesta.Text);
			CollezioneControlli.Add(s_p_wr_id);

			S_Controls.Collections.S_Object s_p_wo_id = new S_Object();
			s_p_wo_id.ParameterName = "p_wo_id";
			s_p_wo_id.DbType = CustomDBType.Integer;
			s_p_wo_id.Direction = ParameterDirection.Input;
			s_p_wo_id.Index = CollezioneControlli.Count;
			s_p_wo_id.Value =(this.S_Ttxtordinelavoro.Text=="")?0:Int32.Parse(this.S_Ttxtordinelavoro.Text);
			CollezioneControlli.Add(s_p_wo_id);

			S_Controls.Collections.S_Object s_p_gruppo = new S_Object();
			s_p_gruppo.ParameterName = "p_gruppo";
			s_p_gruppo.DbType = CustomDBType.Integer;
			s_p_gruppo.Direction = ParameterDirection.Input;
			s_p_gruppo.Index = CollezioneControlli.Count;
			s_p_gruppo.Value =(this.S_cbgruppo.SelectedValue=="")?0:Int32.Parse(this.S_cbgruppo.SelectedValue);
			CollezioneControlli.Add(s_p_gruppo);

			S_Controls.Collections.S_Object s_p_richiedente = new S_Object();
			s_p_richiedente.ParameterName = "p_richiedente";
			s_p_richiedente.DbType = CustomDBType.VarChar;
			s_p_richiedente.Direction = ParameterDirection.Input;
			s_p_richiedente.Index = CollezioneControlli.Count;
			s_p_richiedente.Size=35;
			s_p_richiedente.Value =this.Richiedenti1.NomeCompleto;  
			CollezioneControlli.Add(s_p_richiedente);

			S_Controls.Collections.S_Object s_p_descrizione = new S_Object();
			s_p_descrizione.ParameterName = "p_descrizione";
			s_p_descrizione.DbType = CustomDBType.VarChar;
			s_p_descrizione.Direction = ParameterDirection.Input;
			s_p_descrizione.Index = CollezioneControlli.Count;
			s_p_descrizione.Size=2000;
			s_p_descrizione.Value =this.S_Txtdescrizione.Text;  
			CollezioneControlli.Add(s_p_descrizione);

			S_Controls.Collections.S_Object s_p_urgenza = new S_Object();
			s_p_urgenza.ParameterName = "p_urgenza";
			s_p_urgenza.DbType = CustomDBType.Integer ;
			s_p_urgenza.Direction = ParameterDirection.Input;
			s_p_urgenza.Index = CollezioneControlli.Count;
			s_p_urgenza.Value =(S_Cburgenza.SelectedValue=="")? 0:Int32.Parse(S_Cburgenza.SelectedValue);  
			CollezioneControlli.Add(s_p_urgenza);

			S_Controls.Collections.S_Object s_p_ditta = new S_Object();
			s_p_ditta.ParameterName = "p_ditta";
			s_p_ditta.DbType = CustomDBType.Integer;
			s_p_ditta.Direction = ParameterDirection.Input;
			s_p_ditta.Index = CollezioneControlli.Count;
			s_p_ditta.Value =(S_cbditta.SelectedValue=="")? 0:int.Parse(S_cbditta.SelectedValue);  
			CollezioneControlli.Add(s_p_ditta);

			S_Controls.Collections.S_Object s_p_dates = new S_Object();
			s_p_dates.ParameterName = "p_dates";
			s_p_dates.DbType = CustomDBType.VarChar;
			s_p_dates.Direction = ParameterDirection.Input;
			s_p_dates.Index = CollezioneControlli.Count;
			s_p_dates.Size=10;
			s_p_dates.Value =(CalendarPicker1.Datazione.Text =="")? "":CalendarPicker1.Datazione.Text;  
			CollezioneControlli.Add(s_p_dates);
			
			S_Controls.Collections.S_Object s_p_datee = new S_Object();
			s_p_datee.ParameterName = "p_datee";
			s_p_datee.DbType = CustomDBType.VarChar;
			s_p_datee.Direction = ParameterDirection.Input;
			s_p_datee.Index = CollezioneControlli.Count;
			s_p_datee.Size=10;
			s_p_datee.Value =(CalendarPicker2.Datazione.Text =="")?"": CalendarPicker2.Datazione.Text;  
			CollezioneControlli.Add(s_p_datee);

			S_Controls.Collections.S_Object s_p_addetto = new S_Object();
			s_p_addetto.ParameterName = "p_addetto";
			s_p_addetto.DbType = CustomDBType.VarChar;
			s_p_addetto.Direction = ParameterDirection.Input;
			s_p_addetto.Index = CollezioneControlli.Count;
			s_p_addetto.Size=250;
			s_p_addetto.Value =this.Addetti1.NomeCompleto;  
			CollezioneControlli.Add(s_p_addetto);

			S_Controls.Collections.S_Object s_p_tipomanutenzione = new S_Object();
			s_p_tipomanutenzione.ParameterName = "p_tipomanutenzione";
			s_p_tipomanutenzione.DbType = CustomDBType.Integer;
			s_p_tipomanutenzione.Direction = ParameterDirection.Input;
			s_p_tipomanutenzione.Index = CollezioneControlli.Count;
			s_p_tipomanutenzione.Value =Int32.Parse(cmbTipoManutenzione.SelectedValue);  
			CollezioneControlli.Add(s_p_tipomanutenzione);

			
			Classi.ManCorrettiva.ClManCorrettiva _ClManCorrettiva=new TheSite.Classi.ManCorrettiva.ClManCorrettiva(Context.User.Identity.Name);
			DataSet Ds=_ClManCorrettiva.GetDataCompletamentoExcel(CollezioneControlli);
			return Ds;
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string varapp="";
			if(Request["VarApp"]!=null)
				varapp="&VarApp=" + Request["VarApp"];
			if (e.CommandName=="Dettaglio")
			{	
				_myColl.AddControl(this.Page.Controls, ParentType.Page);
				string s_url = e.CommandArgument.ToString() + varapp;							
				Server.Transfer(s_url);				
			}
		}

		
	}
}
