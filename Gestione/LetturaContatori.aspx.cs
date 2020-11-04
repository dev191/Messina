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
using TheSite.Classi.ClassiDettaglio;
using MyCollection;
using TheSite.Classi; 

namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per LetturaContatori.
	/// </summary>
	public class LetturaContatori : System.Web.UI.Page
	{
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_ComboBox cmbsApparecchiatura;
		protected S_Controls.S_Button S_btMostra;
		protected WebControls.GridTitle GridTitle1; 
		protected WebControls.CodiceApparecchiature CodiceApparecchiature1;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected WebControls.PageTitle PageTitle1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenblid;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;
		public static int FunId = 0;				
		public static string HelpLink = string.Empty;
		protected Microsoft.Web.UI.WebControls.TabStrip TabStrip1;
		protected S_Controls.S_ComboBox cmbsPiano;
		protected System.Web.UI.WebControls.Button btnReset;
		MyCollection.clMyCollection _myColl = new clMyCollection();

		EditLetturaContatori _fp;	
	
		protected System.Web.UI.WebControls.DataGrid DataGridLettura;
		protected WebControls.UserStanze UserStanze1;

	
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
			this.cmbsServizio.SelectedIndexChanged += new System.EventHandler(this.cmbsServizio_SelectedIndexChanged);
			this.S_btMostra.Click += new System.EventHandler(this.S_btMostra_Click);
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			this.DataGridLettura.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridLettura_ItemCreated);
			this.DataGridLettura.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridLettura_ItemCommand);
			this.DataGridLettura.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridLettura_PageIndexChanged);
			this.DataGridLettura.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridLettura_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.GridTitle1.hplsNuovo.NavigateUrl = "../Gestione/EditLetturaContatori.aspx?FunId=" + _SiteModule.ModuleId;

			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;				
		
			if (RicercaModulo1.TxtCodice.Text!="")
			{
				RicercaModulo1.DelegateIDBLEdificio1  +=new  WebControls.DelegateIDBLEdificio(this.BindPiano);	
				RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);
			}
			CodiceApparecchiature1.NameComboApparecchiature ="cmbsApparecchiatura";
			CodiceApparecchiature1.NameComboServizio ="cmbsServizio";
			CodiceApparecchiature1.NameUserControlRicercaModulo  ="RicercaModulo1";
			CodiceApparecchiature1.s_RichiestaLettura="si";

			UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
			UserStanze1.NameComboPiano="cmbsPiano";

			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsApparecchiatura.ClientID + "').disabled = true;");
			this.cmbsServizio.Attributes.Add("onchange", sbValid.ToString());

			if (!IsPostBack) 
			{
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];				
			
				BindApparecchiatura();
				BindPiano("");				
				BindServizio("");
				if(Context.Handler is TheSite.Gestione.EditLetturaContatori) 
				{									
					_fp = (TheSite.Gestione.EditLetturaContatori) Context.Handler;
					if (_fp!=null)
					{
						BindApparecchiatura();
						BindTuttiPiani();				
						BindServizio("");
						//BindStanza();
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);
						
						Execute();
					}					
				}		
			}
		}

		public MyCollection.clMyCollection _Contenitore
		{
			get {return _myColl;}
		}

		private void BindServizio(string CodEdificio)
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
				
				//			}
				//			else
				//			{
				//				_MyDs = _Servizio.GetData();
				//			}

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
			}

			else
			{
				string s_Messagggio = "- Nessun Servizio -";
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}


		
		private void BindApparecchiatura()
		{
			
			this.cmbsApparecchiatura.Items.Clear();
		
			Classi.AnagrafeImpianti.Apparecchiature  _Apparecchiature = new TheSite.Classi.AnagrafeImpianti.Apparecchiature(Context.User.Identity.Name);
			
			DataSet _MyDs;

			//			if (!IsPostBack)
			//			{
			//				_MyDs = _Apparecchiature.GetData().Copy();
			//			}
			if (RicercaModulo1.TxtCodice.Text!="")
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
              
			
  
				if (_MyDs.Tables[0].Rows.Count > 0)
				{
					this.cmbsApparecchiatura.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
						_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Standard -", "");
					this.cmbsApparecchiatura.DataTextField = "DESCRIZIONE";
					this.cmbsApparecchiatura.DataValueField = "ID";
					this.cmbsApparecchiatura.DataBind();
				}
				else
				{
					string s_Messagggio = "- Nessun Standard -";
					this.cmbsApparecchiatura.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
				}
			}
			else
			{
				string s_Messagggio = "- Nessun Standard -";
				this.cmbsApparecchiatura.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}


		private void cmbsServizio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindApparecchiatura();
		}

		/// <summary>
		/// Ottiene imposta la visibilità della griglia e dell'ogetto title
		/// </summary>
		/// <param name="Visibile"> indica true di renderli visibili</param>
		

		private void S_btMostra_Click(object sender, System.EventArgs e)
		{
		//	DataGridLettura.CurrentPageIndex = 0;
			Execute();
		
		}
		
		private void Execute()
		{
			if (RicercaModulo1.TxtCodice.Text=="")
			{
				BindServizio("");
				BindApparecchiatura();
				BindPiano("");
			}
			///Istanzio un nuovo oggetto Collection per aggiungere i parametri
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			///creo i parametri
		
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
			///Aggiungo i parametri alla collection
			_SCollection.Add(s_p_campus);

			S_Controls.Collections.S_Object s_p_Servizio = new S_Controls.Collections.S_Object();
			s_p_Servizio.ParameterName = "p_Servizio";
			s_p_Servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Servizio.Direction = ParameterDirection.Input;
			s_p_Servizio.Index = 2;
			s_p_Servizio.Value = (cmbsServizio.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsServizio.SelectedValue);
			///Aggiungo i parametri alla collection
			_SCollection.Add(s_p_Servizio);

			S_Controls.Collections.S_Object s_p_eqstdid = new S_Controls.Collections.S_Object();
			s_p_eqstdid.ParameterName = "p_eqstdid";
			s_p_eqstdid.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_eqstdid.Direction = ParameterDirection.Input;
			s_p_eqstdid.Size =8;
			s_p_eqstdid.Index = 3;
			s_p_eqstdid.Value = (cmbsApparecchiatura.SelectedValue==string.Empty)? 0:Int32.Parse(cmbsApparecchiatura.SelectedValue);
			_SCollection.Add(s_p_eqstdid);

			S_Controls.Collections.S_Object s_p_eq_id = new S_Controls.Collections.S_Object();
			s_p_eq_id.ParameterName = "p_eq_id";
			s_p_eq_id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_eq_id.Direction = ParameterDirection.Input;
			s_p_eq_id.Size =8;
			s_p_eq_id.Index = 4;
			s_p_eq_id.Size =50;
			s_p_eq_id.Value = CodiceApparecchiature1.CodiceApparecchiatura;
			///Aggiungo i parametri alla collection
			_SCollection.Add(s_p_eq_id);
			
			S_Controls.Collections.S_Object s_p_dimesso = new S_Controls.Collections.S_Object();
			s_p_dimesso.ParameterName = "p_dismesso";
			s_p_dimesso.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_dimesso.Direction = ParameterDirection.Input;			
			s_p_dimesso.Index = 5;
			s_p_dimesso.Size =8;					
			s_p_dimesso.Value =Classi.DismissioneType.NO;
			_SCollection.Add(s_p_dimesso);		
			
			S_Controls.Collections.S_Object s_p_idpiano = new S_Controls.Collections.S_Object();
			s_p_idpiano.ParameterName = "p_idpiano";
			s_p_idpiano.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_idpiano.Direction = ParameterDirection.Input;
			s_p_idpiano.Size =10;
			s_p_idpiano.Index = 6;
			s_p_idpiano.Value = (cmbsPiano.SelectedValue==string.Empty)? 0:Int32.Parse(cmbsPiano.SelectedValue);
			_SCollection.Add(s_p_idpiano);

			S_Controls.Collections.S_Object s_p_idstanza = new S_Controls.Collections.S_Object();
			s_p_idstanza.ParameterName = "p_idstanza";
			s_p_idstanza.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_idstanza.Direction = ParameterDirection.Input;
			s_p_idstanza.Size =30;
			s_p_idstanza.Index = 7;
			s_p_idstanza.Value = UserStanze1.DescStanza;//(cmbsStanza.SelectedValue==string.Empty)? 0:Int32.Parse(cmbsStanza.SelectedValue);
			_SCollection.Add(s_p_idstanza);

			S_Controls.Collections.S_Object s_p_dataDa = new S_Controls.Collections.S_Object();
			s_p_dataDa.ParameterName = "p_dataDa";
			s_p_dataDa.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_dataDa.Direction = ParameterDirection.Input;
			s_p_dataDa.Size =10;
			s_p_dataDa.Index = 8;
			s_p_dataDa.Value = CalendarPicker1.Datazione.Text;
			_SCollection.Add(s_p_dataDa);

			S_Controls.Collections.S_Object s_p_dataA = new S_Controls.Collections.S_Object();
			s_p_dataA.ParameterName = "p_dataA";
			s_p_dataA.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_dataA.Direction = ParameterDirection.Input;
			s_p_dataA.Size =10;
			s_p_dataA.Index = 9;
			s_p_dataA.Value = CalendarPicker2.Datazione.Text;
			_SCollection.Add(s_p_dataA);
			///Istanzio la Classe per eseguire la Strore Procedure
			Classi.ClassiAnagrafiche.LetturaContatori   _Apparecchiature =new TheSite.Classi.ClassiAnagrafiche.LetturaContatori(Context.User.Identity.Name);
			
			///Eseguo il Binding sulla Griglia.
			DataSet Ds=_Apparecchiature.RicercaApparecchiatura(_SCollection);

			GridTitle1.Visible = true;
			
			if (Ds.Tables[0].Rows.Count > 0) 
			{
				DataGridLettura.Visible=true;
				
				GridTitle1.DescriptionTitle="";
				DataGridLettura.DataSource= Ds.Tables[0].Copy();
				GridTitle1.NumeroRecords=(Ds.Tables[0].Rows.Count)==0? "0":Ds.Tables[0].Rows.Count.ToString();
				DataGridLettura.DataBind(); 

			}
			else
			{
				GridTitle1.DescriptionTitle="Nessun dato trovato.";
					DataGridLettura.Visible=false;
				
			}
		}

		private void DataGridLettura_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			
			DataGridLettura.CurrentPageIndex=e.NewPageIndex;
			Execute();
			GetControlli();
		}

		private void BindPiano(string CodEdificio)
		{	
			
			this.cmbsPiano.Items.Clear();
		
			if (CodEdificio=="")
			{
				CodEdificio="0";
			}
			if (CodEdificio!="0")
			{
				Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
			
				DataSet	_MyDs = _Buildings.GetPianiBuilding(int.Parse(CodEdificio));

				if (_MyDs.Tables[0].Rows.Count > 0)
				{
					this.cmbsPiano.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
						_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "");
					this.cmbsPiano.DataTextField = "DESCRIZIONE";
					this.cmbsPiano.DataValueField = "ID";
					this.cmbsPiano.DataBind();
				}
				else
				{
					string s_Messagggio = "- Nessun Piano -";
					this.cmbsPiano.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
				}
				this.cmbsPiano.Enabled=true;
			
		//		this.cmbsStanza.Enabled=true;
			}
			else
			{
				string s_Messagggio = "- Nessun Piano -";
				this.cmbsPiano.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}
		private void BindStanza()
		{
		  
//			this.cmbsStanza.Items.Clear();
//		
//			TheSite.Classi.ManOrdinaria.Richiesta  _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
//			int bl_id=(RicercaModulo1.Idbl=="")?0:int.Parse(RicercaModulo1.Idbl);
//			int Piano=(cmbsPiano.SelectedValue=="")?0:int.Parse(cmbsPiano.SelectedValue); 
//			DataSet	_MyDs = _Richiesta.GetStanze(bl_id,Piano);
//
//			if (_MyDs.Tables[0].Rows.Count > 0)
//			{
//				this.cmbsStanza.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
//					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare la Stanza -", "");
//				this.cmbsStanza.DataTextField = "DESCRIZIONE";
//				this.cmbsStanza.DataValueField = "ID";
//				this.cmbsStanza.DataBind();
//			}
//			else
//			{
//				string s_Messagggio = "- Nessuna Stanza -";
//				this.cmbsStanza.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
//			}
//			
//			cmbsStanza.Attributes.Add("OnChange","ClearApparechiature();");
		}
		private void BindTuttiPiani()
		{
			this.cmbsPiano.Items.Clear();
		
			TheSite.Classi.ClassiAnagrafiche.Buildings  _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
			
			DataSet	_MyDs = _Buildings.GetAllPiani();

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsPiano.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "");
				this.cmbsPiano.DataTextField = "DESCRIZIONE";
				this.cmbsPiano.DataValueField = "ID";
				this.cmbsPiano.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Piano -";
				this.cmbsPiano.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		
        private void btnReset_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("LetturaContatori.aspx");
		}

		
		private string IDBL
		{
			get{return hiddenblid.Value;}
			set{hiddenblid.Value =value;}
		}
		
		private void GetControlli()
		{	
			clMyDataGridCollection _cl = new clMyDataGridCollection();
			if(Session["CheckedList"]!=null)
			{	
				_cl.GetControl(DataGridLettura,(Hashtable) Session["CheckedList"],DataGridLettura.CurrentPageIndex);
			}
		}

		
	
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridLettura.CurrentPageIndex=e.NewPageIndex;
			Execute();
		}

		private void DataGridLettura_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton1");
				_img1.Attributes.Add("title","Visualizza Apparecchiatura");		
				ImageButton _img2 = (ImageButton) e.Item.Cells[2].FindControl("Imagebutton2");
				_img2.Attributes.Add("title","Visualizza Le Richieste di Lavoro");		

				
								
			}
		}
		public void imageButton_Click(Object sender , CommandEventArgs e)
		{
//			Context.Items.Add("id_lettura",(string)e.CommandArgument);
//			Server.Transfer("EditLetturaContatori.aspx"); 
		}

		

		private void DataGridLettura_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType== ListItemType.Item) || (e.Item.ItemType==ListItemType.AlternatingItem) ||
				(e.Item.ItemType==ListItemType.EditItem))
			{
				TableCell myTableCell;
				myTableCell = e.Item.Cells[1];
				ImageButton myDeleteButton=(ImageButton)myTableCell.Controls[1];
				myDeleteButton.Attributes.Add("onclick","return confirm(\"Sei sicuro di Cancellare l'apparecchiatura?\");");
			}
		}

		private void DataGridLettura_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Dettaglio")
			{			
				_myColl.AddControl(this.Page.Controls, ParentType.Page);
				string s_url = e.CommandArgument.ToString();							
				Server.Transfer(s_url);				
			}
		}

		private void DeleteItem(string id)
		{
		}
	}
}

		