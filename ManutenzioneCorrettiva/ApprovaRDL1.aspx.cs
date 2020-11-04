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

namespace TheSite.ManutenzioneCorrettiva
{
	/// <summary>
	/// Descrizione di riepilogo per ApprovaRDL1.
	/// </summary>
	public class ApprovaRDL1 : System.Web.UI.Page
	{
		protected S_Controls.S_TextBox txtsRichiesta;
		protected S_Controls.S_TextBox txtsOperatore;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected S_Controls.S_ComboBox cmbsGruppo;
		protected S_Controls.S_TextBox txtsDescrizione;
		protected S_Controls.S_ComboBox cmbsUrgenza;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_Button btnsRicerca;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_ComboBox cmbsvalidazione;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.PageTitle PageTitle1;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;
		protected WebControls.Richiedenti Richiedenti1;
 
		public string HelpLink =string.Empty;
		public int FunId=0;
    
		MyCollection.clMyCollection _myColl = new clMyCollection();
		EditApprovaEmetti _fp = null;

		public Classi.SiteModule _SiteModule;

		public MyCollection.clMyCollection _Contenitore
		{
			get {return _myColl;}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			txtsRichiesta.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtsRichiesta.Attributes.Add("onpaste","return nonpaste();");

			// ***********************  MODIFICA PER I PERMESSI SULLA PAGINA CORRENTE **********************
			//Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];			
			string _mypage="./ManutenzioneCorrettiva/ApprovaRdl1.aspx";			
			_SiteModule = new TheSite.Classi.SiteModule(_mypage);
			// *********************************************************************************************

			this.DataGridRicerca.Columns[1].Visible = _SiteModule.IsEditable;				
						
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			this.GridTitle1.hplsNuovo.Visible = false;
			
			this.RicercaModulo1.DelegatePresidio1 +=new  WebControls.DelegatePresidio(this.BindUrgenza);
			RicercaModulo1.DelegateIDBLEdificio1 = new TheSite.WebControls.DelegateIDBLEdificio(this.LoadServizi);
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"]; 

				CompareValidator1.ControlToValidate = CalendarPicker2.ID + ":" + CalendarPicker2.Datazione.ID;
				CompareValidator1.ControlToCompare =  CalendarPicker1.ID + ":" + CalendarPicker1.Datazione.ID;
				BindControls();

				if(Context.Handler is TheSite.ManutenzioneCorrettiva.EditApprovaEmetti)
				{
					_fp = (TheSite.ManutenzioneCorrettiva.EditApprovaEmetti)Context.Handler;
					if (_fp!=null) 
					{						
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);		
						Ricerca(true);
					}
				}
			}
		}
		private void LoadServizi(string CodEdificio)
		{
			//			this.cmbsServizio.Items.Clear();		
			//			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			//
			//			Classi.ClassiDettaglio.Servizi  _Servizio = new TheSite.Classi.ClassiDettaglio.Servizi(Context.User.Identity.Name);


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



			//			DataSet _MyDs;
			//
			//			if (CodEdificio!="")
			//			{
			//				S_Controls.Collections.S_Object s_Bl_Id = new S_Object();
			//				s_Bl_Id.ParameterName = "p_Bl_Id";
			//				s_Bl_Id.DbType = CustomDBType.VarChar;
			//				s_Bl_Id.Direction = ParameterDirection.Input;
			//				s_Bl_Id.Index = CollezioneControlli.Count;
			//				s_Bl_Id.Value =	CodEdificio;
			//				s_Bl_Id.Size = 8;
			//                CollezioneControlli.Add(s_Bl_Id);		
			//				
			//				S_Controls.Collections.S_Object s_ID_Servizio = new S_Object();
			//				s_ID_Servizio.ParameterName = "p_ID_Servizio";
			//				s_ID_Servizio.DbType = CustomDBType.Integer;
			//				s_ID_Servizio.Direction = ParameterDirection.Input;
			//				s_ID_Servizio.Index = CollezioneControlli.Count;
			//				s_ID_Servizio.Value = 0;
			//				CollezioneControlli.Add(s_ID_Servizio);
			//
			//				_MyDs = _Servizio.GetData(CollezioneControlli);
			//			}
			//			else
			//			{
			//				_MyDs = _Servizio.GetData();
			//			}
			//
			//			if (_MyDs.Tables[0].Rows.Count > 0)
			//			{
			//				this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
			//					_MyDs.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "0");
			//				
			//				this.cmbsServizio.DataTextField = "DESCRIZIONE";
			//				this.cmbsServizio.DataValueField = "IDSERVIZIO";
			//				this.cmbsServizio.DataBind();
			//				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio("Non Definito", "-1"));
			//			}
			//			else
			//			{
			//				string s_Messagggio = "Non Definito";
			//				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
			//			}
		}
		private void BindUrgenza(string Codice)
		{
			string Progetto="";
			if(Request.QueryString["VarApp"]!=null)
				Progetto=Request.QueryString["VarApp"];
			DataSet ds;
			if(Codice!="")
			{
				int cod= Convert.ToInt32(Codice);
				Classi.ClassiDettaglio.Urgenza _Urgenza = new TheSite.Classi.ClassiDettaglio.Urgenza();

				ds=_Urgenza.GetPriorita(cod,Progetto);
				this.cmbsUrgenza.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					ds.Tables[0], "DESCRIPTION", "ID", "Selezionare una Priorità", "0");

				this.cmbsUrgenza.DataTextField = "DESCRIPTION";
				this.cmbsUrgenza.DataValueField = "ID";
				this.cmbsUrgenza.DataBind();

			}
			else
			{
				Classi.ClassiDettaglio.Urgenza _Urgenza = new TheSite.Classi.ClassiDettaglio.Urgenza();
				ds=_Urgenza.GetPriorita(0,Progetto);
				this.cmbsUrgenza.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					ds.Tables[0], "DESCRIPTION", "ID", "Selezionare una Priorità", "0");
				this.cmbsUrgenza.DataTextField = "DESCRIPTION";
				this.cmbsUrgenza.DataValueField = "ID";
				this.cmbsUrgenza.DataBind();
			}
			
		}
		private void BindControls()
		{//urgenza
		

			BindUrgenza("");


			string Progetto="";
			if(Request.QueryString["VarApp"]!=null)
				Progetto=Request.QueryString["VarApp"];
			Classi.ClassiAnagrafiche.Richiedenti_tipo _Richiedenti = new TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo();	
			DataSet Ds = _Richiedenti.GetAllAddProg(Progetto).Copy();


			//Carico il combo del Gruppo
			this.cmbsGruppo.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
				Ds.Tables[0], "descrizione", "id", "Selezionare un Gruppo", "0");
			this.cmbsGruppo.DataTextField = "descrizione";
			this.cmbsGruppo.DataValueField = "id";
			this.cmbsGruppo.DataBind();
			
			LoadServizi("");
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
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			DataGridRicerca.CurrentPageIndex=0;
			Ricerca(true);
		}
		private void Ricerca(bool reset)
		{
			Classi.ManCorrettiva.ClManCorrettiva _ClManCorrettiva =new TheSite.Classi.ManCorrettiva.ClManCorrettiva(Context.User.Identity.Name);
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_Wr_Id = new S_Controls.Collections.S_Object();
			s_p_Wr_Id.ParameterName = "p_Wr_Id";
			s_p_Wr_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wr_Id.Direction = ParameterDirection.Input;
			s_p_Wr_Id.Index = 0;
			s_p_Wr_Id.Size=50;
			s_p_Wr_Id.Value = (this.txtsRichiesta.Text=="")?0:Int32.Parse(this.txtsRichiesta.Text);		
			_SCollection.Add(s_p_Wr_Id);

			S_Controls.Collections.S_Object s_p_DataDa = new S_Controls.Collections.S_Object();
			s_p_DataDa.ParameterName = "p_DataDa";
			s_p_DataDa.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataDa.Direction = ParameterDirection.Input;
			s_p_DataDa.Index = 1;
			s_p_DataDa.Size= 10;
			s_p_DataDa.Value = (CalendarPicker1.Datazione.Text =="")? "":CalendarPicker1.Datazione.Text;  			
			_SCollection.Add(s_p_DataDa);

			S_Controls.Collections.S_Object s_p_DataA = new S_Controls.Collections.S_Object();
			s_p_DataA.ParameterName = "p_DataA";
			s_p_DataA.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataA.Direction = ParameterDirection.Input;
			s_p_DataA.Index = 2;
			s_p_DataA.Size= 10;
			s_p_DataA.Value = (CalendarPicker2.Datazione.Text =="")? "":CalendarPicker2.Datazione.Text;  			
			_SCollection.Add(s_p_DataA);

			S_Controls.Collections.S_Object s_p_Richiedente = new S_Controls.Collections.S_Object();
			s_p_Richiedente.ParameterName = "p_Richiedente";
			s_p_Richiedente.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Richiedente.Direction = ParameterDirection.Input;
			s_p_Richiedente.Index = 3;
			s_p_Richiedente.Size=50;
			s_p_Richiedente.Value = this.Richiedenti1.NomeCompleto;			
			_SCollection.Add(s_p_Richiedente);

			S_Controls.Collections.S_Object s_p_Gruppo = new S_Controls.Collections.S_Object();
			s_p_Gruppo.ParameterName = "p_Gruppo";
			s_p_Gruppo.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Gruppo.Direction = ParameterDirection.Input;
			s_p_Gruppo.Index = 4;
			s_p_Gruppo.Value = (cmbsGruppo.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsGruppo.SelectedValue);			
			_SCollection.Add(s_p_Gruppo);

			S_Controls.Collections.S_Object s_p_Descrizione = new S_Controls.Collections.S_Object();
			s_p_Descrizione.ParameterName = "p_Descrizione";
			s_p_Descrizione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Descrizione.Direction = ParameterDirection.Input;
			s_p_Descrizione.Index = 5;
			s_p_Descrizione.Size= 255;
			s_p_Descrizione.Value = txtsDescrizione .Text ;			
			_SCollection.Add(s_p_Descrizione);

			S_Controls.Collections.S_Object s_p_Priority = new S_Controls.Collections.S_Object();
			s_p_Priority.ParameterName = "p_Urgenza";
			s_p_Priority.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Priority.Direction = ParameterDirection.Input;
			s_p_Priority.Index = 6;
			s_p_Priority.Value = (cmbsUrgenza.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsUrgenza.SelectedValue);			
			_SCollection.Add(s_p_Priority);

			S_Controls.Collections.S_Object s_p_Servizio = new S_Controls.Collections.S_Object();
			s_p_Servizio.ParameterName = "p_Servizio";
			s_p_Servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Servizio.Direction = ParameterDirection.Input;
			s_p_Servizio.Index = 7;
			s_p_Servizio.Value = (cmbsServizio.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsServizio.SelectedValue);			
			_SCollection.Add(s_p_Servizio);

			S_Controls.Collections.S_Object s_p_Operatore = new S_Controls.Collections.S_Object();
			s_p_Operatore.ParameterName = "p_Operatore";
			s_p_Operatore.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Operatore.Direction = ParameterDirection.Input;
			s_p_Operatore.Index = 8;
			s_p_Operatore.Size = 255;
			s_p_Operatore.Value = this.txtsOperatore.Text;			
			_SCollection.Add(s_p_Operatore);

			
			S_Controls.Collections.S_Object s_p_Bl_Id = new S_Controls.Collections.S_Object();
			s_p_Bl_Id.ParameterName = "p_Bl_Id";
			s_p_Bl_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Bl_Id.Direction = ParameterDirection.Input;
			s_p_Bl_Id.Size =50;
			s_p_Bl_Id.Index = 9;
			s_p_Bl_Id.Value = RicercaModulo1.TxtCodice.Text;
			_SCollection.Add(s_p_Bl_Id);

			S_Controls.Collections.S_Object s_p_campus = new S_Controls.Collections.S_Object();
			s_p_campus.ParameterName = "p_campus";
			s_p_campus.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_campus.Direction = ParameterDirection.Input;
			s_p_campus.Index = 10;
			s_p_campus.Size=50;
			s_p_campus.Value = RicercaModulo1.TxtRicerca.Text;			
			_SCollection.Add(s_p_campus);

			S_Controls.Collections.S_Object s_p_validazione = new S_Controls.Collections.S_Object();
			s_p_validazione.ParameterName = "p_validazione";
			s_p_validazione.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_validazione.Direction = ParameterDirection.Input;
			s_p_validazione.Index = 11;
			s_p_validazione.Value = int.Parse( cmbsvalidazione.SelectedValue);			
			_SCollection.Add(s_p_validazione);
			
			S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
			s_p_pageindex.ParameterName = "pageindex";
			s_p_pageindex.DbType = CustomDBType.Integer;
			s_p_pageindex.Direction = ParameterDirection.Input;
			s_p_pageindex.Index = _SCollection.Count +1;
			s_p_pageindex.Value=DataGridRicerca.CurrentPageIndex +1;			
			_SCollection.Add(s_p_pageindex);

			S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
			s_p_pagesize.ParameterName = "pagesize";
			s_p_pagesize.DbType = CustomDBType.Integer;
			s_p_pagesize.Direction = ParameterDirection.Input;
			s_p_pagesize.Index = _SCollection.Count +1;
			s_p_pagesize.Value= DataGridRicerca.PageSize;			
			_SCollection.Add(s_p_pagesize);

			DataSet _MyDs = _ClManCorrettiva.GetData(_SCollection);
			
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];

			DataGridRicerca.Visible = true;

			Double _totalPages = 1;
			if (reset==true)
			{
				_SCollection.RemoveAt(_SCollection.Count-1);
				_SCollection.RemoveAt(_SCollection.Count-1);
				_SCollection.RemoveAt(_SCollection.Count-1);
				_SCollection.RemoveAt(_SCollection.Count-1);
				int _totalRecords = _ClManCorrettiva.GetDataCount(_SCollection);;
				this.GridTitle1.NumeroRecords=_totalRecords.ToString();
				if ((_totalRecords % DataGridRicerca.PageSize) == 0)
					_totalPages = _totalRecords / DataGridRicerca.PageSize;
				else
					_totalPages = (_totalRecords / DataGridRicerca.PageSize)+1;
			}
			else
			{
				_totalPages = Double.Parse (this.GridTitle1.NumeroRecords);
			}


			GridTitle1.Visible = true;
			
			this.DataGridRicerca.VirtualItemCount =int.Parse(this.GridTitle1.NumeroRecords);
			this.DataGridRicerca.DataBind();
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex=e.NewPageIndex;
			Ricerca(false);
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				ImageButton _img1 = (ImageButton) e.Item.Cells[2].FindControl("lnkDett");
				_img1.Attributes.Add("title","Approva Richiesta di Lavoro");		
								
			}
		}

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
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

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			string varapp="";
			if(Request["VarApp"]!=null)
				varapp="&VarApp=" + Request["VarApp"];
			Response.Redirect("ApprovaRDL1.aspx?Fun=" + ViewState["FunId"] + varapp);

		}

	

	}
}

