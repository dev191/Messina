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
using StampaRapportiPdf.Classi;

namespace TheSite.ManutenzioneCorrettiva
{
	/// <summary>
	/// Descrizione di riepilogo per ApprovaRDL.
	/// </summary>
	public class ApprovaRDL : System.Web.UI.Page    // System.Web.UI.Page
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
    
		clMyCollection _myColl = new clMyCollection();
	    EditApprovaEmetti _fp = null;

        public Classi.SiteModule _SiteModule;

		public clMyCollection _Contenitore
		{
			get {return _myColl;}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			txtsRichiesta.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtsRichiesta.Attributes.Add("onpaste","return nonpaste();");

			// ***********************  MODIFICA PER I PERMESSI SULLA PAGINA CORRENTE **********************
			//Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];			
			string _mypage="./ManutenzioneCorrettiva/ApprovaRdl.aspx";			
			_SiteModule = new TheSite.Classi.SiteModule(_mypage);
			// *********************************************************************************************

			this.DataGridRicerca.Columns[1].Visible = _SiteModule.IsEditable;				
						
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			this.GridTitle1.hplsNuovo.Visible = false;
			
			RicercaModulo1.DelegateCodiceEdificio1 = new TheSite.WebControls.DelegateCodiceEdificio(this.LoadServizi);
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{
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
						Ricerca();
					}
				}
			}
		}
		private void LoadServizi(string CodEdificio)
		{
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
				string s_Messagggio = "Non Definito";
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
			}
		}
		private void BindControls()
		{
			Classi.ClassiDettaglio.Urgenza _Urgenza = new TheSite.Classi.ClassiDettaglio.Urgenza();
			Classi.ClassiDettaglio.RichiedentiTipo _RichiedentiTipo = new TheSite.Classi.ClassiDettaglio.RichiedentiTipo();

			//Carico il combo del Gruppo
			this.cmbsGruppo.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
				_RichiedentiTipo.GetData().Tables[0], "DESCRIZIONE", "ID", "Selezionare un Gruppo", "0");
			this.cmbsGruppo.DataTextField = "DESCRIZIONE";
			this.cmbsGruppo.DataValueField = "ID";
			this.cmbsGruppo.DataBind();
			
			//Carico il combo delle Urgenze			
			this.cmbsUrgenza.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource( _Urgenza.GetData().Tables[0], "PRIORITY","ID","Selezionare una Urgenza","0");
			this.cmbsUrgenza.DataTextField = "PRIORITY";
			this.cmbsUrgenza.DataValueField = "ID";
			this.cmbsUrgenza.DataBind();		

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
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
		 DataGridRicerca.CurrentPageIndex=0;
		 Ricerca();
		}
		private void Ricerca()
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
			
			DataSet _MyDs = _ClManCorrettiva.GetData(_SCollection);
			
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];

			DataGridRicerca.Visible = true;

			GridTitle1.Visible = true;
			GridTitle1.DescriptionTitle = "";
			if (_MyDs.Tables[0].Rows.Count == 0 )		
				GridTitle1.DescriptionTitle = "Nessun elemento trovato";
			
			this.DataGridRicerca.DataBind();
			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();	
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex=e.NewPageIndex;
			Ricerca();
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
			if (e.CommandName=="Dettaglio")
			{	
				_myColl.AddControl(this.Page.Controls, ParentType.Page);
				string s_url = e.CommandArgument.ToString();							
				Server.Transfer(s_url);				
			}
		}

	

	}
}
