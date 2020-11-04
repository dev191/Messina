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
   
namespace TheSite.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per NavigazioneApparechiature.
	/// </summary>
	public class NavigazioneApparecchiature : System.Web.UI.Page
	{
		protected  System.Web.UI.WebControls.DataGrid MyDataGrid1;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_ComboBox cmbsApparecchiatura;
		protected S_Controls.S_Button S_btMostra;
		protected WebControls.GridTitle GridTitle1; 
		protected WebControls.CodiceApparecchiature CodiceApparecchiature1;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected WebControls.PageTitle PageTitle1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenblid;
		protected WebControls.UserStanzeRic UserStanze1;
		public static int FunId = 0;
		protected S_Controls.S_Button btReset;				
		public static string HelpLink = string.Empty;
		
		MyCollection.clMyCollection _myColl = new MyCollection.clMyCollection();
		protected Microsoft.Web.UI.WebControls.TabStrip TabStrip1;
		protected S_Controls.S_ComboBox cmbsPiano;
		protected S_Controls.S_Button S_Button1;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvEdificio;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;

		
		RichiesteApparecchiatura  _fp=null;

		public MyCollection.clMyCollection _Contenitore
		{
			get {return _myColl;}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];

			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;				
			
			// Inserire qui il codice utente necessario per inizializzare la pagina.
//			RicercaModulo1.DelegateIDBLEdificio1  +=new  WebControls.DelegateIDBLEdificio(this.BindBl);
    		RicercaModulo1.DelegateIDBLEdificio1  +=new  WebControls.DelegateIDBLEdificio(this.BindPiano);	
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			// Le seguenti due istruzioni compiono la stessa funzione, ossia recuperare del controllo il codice
			//dell'edificio la seconda fa uso del delegante che è Piu Performante
			//Console.WriteLine( ((S_Controls.S_TextBox)RicercaModulo1.FindControl("txtsCodEdificio")).Text);
			RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);
		    RicercaModulo1.DelegateCodiceServizio1 +=new WebControls.DelegateCodiceServizio(this.BindStanza);
			///TODO: Impostare tali parametri per impostare l'user control Codice apparecchiature
			///Ogni qualvolta lo si deve implementare in una pagina.
			///Tali parametri verranno utilizzati dal controllo per passare i valori in query string
			/// Imposto il nome della combo Apparecchiature
			CodiceApparecchiature1.NameComboApparecchiature ="cmbsApparecchiatura";
			/// Imposto il nome della combo Servizio
			CodiceApparecchiature1.NameComboServizio ="cmbsServizio";
			/// Imposto il nome dell'user control RicercaModulo
			CodiceApparecchiature1.NameUserControlRicercaModulo  ="RicercaModulo1";

			UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
			UserStanze1.NameComboPiano="cmbsPiano";

			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsApparecchiatura.ClientID + "').disabled = true;");
			this.cmbsServizio.Attributes.Add("onchange", sbValid.ToString());

			if (!IsPostBack) 
			{
				rfvEdificio.ControlToValidate= RicercaModulo1.ID + ":" + RicercaModulo1.TxtCodice.ID;

				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];

				BindServizio("0");
				BindApparecchiatura();
				BindTuttiPiani();
		//		BindStanza();
				setvisiblecontrol(false);
				GridTitle1.Visible = false;
				
				//Valorizzo i Parametri Immessi
//				if(Context.Handler is TheSite.AnagrafeImpianti.RichiesteApparecchiatura)
//				{
//					_fp = (TheSite.AnagrafeImpianti.RichiesteApparecchiatura)Context.Handler;
//					
//					BindServizio("0");
//					BindTuttiPiani();
//		//			BindStanza();
//					BindApparecchiatura();
//					if (_fp!=null) 
//					{						
//						_myColl=_fp._Contenitore;
//						_myColl.SetValues(this.Page.Controls);		
//						Execute(true);
//					}
//				}

			}
			else
			{
				//				if(RicercaModulo1.BlId=="" && RicercaModulo1.Campus!="") BindServizio("");
				//				BindApparecchiatura();
			}
			GridTitle1.hplsNuovo.Visible=false;
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
				
			}
			else
			{
				_MyDs = _Servizio.GetData();
			}

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
//				this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
//					_MyDs.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "");
				this.cmbsServizio.DataSource = _MyDs.Tables[0];
				this.cmbsServizio.DataTextField = "DESCRIZIONE";
				this.cmbsServizio.DataValueField = "IDSERVIZIO";
				this.cmbsServizio.DataBind();
				BindApparecchiatura();
			}
			else
			{
				string s_Messagggio = "- Nessun Servizio -";
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		
		}


		
		private void BindApparecchiatura()
		{
			if (cmbsServizio.SelectedValue!="" || RicercaModulo1.TxtCodice.Text!="")
			{
				this.cmbsApparecchiatura.Items.Clear();
		
				Classi.AnagrafeImpianti.Apparecchiature  _Apparecchiature = new TheSite.Classi.AnagrafeImpianti.Apparecchiature(Context.User.Identity.Name);
			
				DataSet _MyDs;

				if (RicercaModulo1.TxtCodice.Text=="" && cmbsServizio.SelectedIndex==-1)
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
					this.cmbsApparecchiatura.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
						_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Standard -", "");
					this.cmbsApparecchiatura.DataTextField = "DESCRIZIONE";
					this.cmbsApparecchiatura.DataValueField = "ID";
					this.cmbsApparecchiatura.DataBind();
				}
				else
				{
					string s_Messagggio = "- Nessun Standard -";
					this.cmbsApparecchiatura.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio,  String.Empty));
				}
			}
			else
			{
				string s_Messagggio = "- Nessun Standard -";
				this.cmbsApparecchiatura.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
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
			this.cmbsServizio.SelectedIndexChanged += new System.EventHandler(this.cmbsServizio_SelectedIndexChanged);
			this.S_btMostra.Click += new System.EventHandler(this.S_btMostra_Click);
			this.btReset.Click += new System.EventHandler(this.btReset_Click);
			this.S_Button1.Click += new System.EventHandler(this.S_Button1_Click);
			this.MyDataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged);
			this.MyDataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.MyDataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmbsServizio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindApparecchiatura();
		}

		/// <summary>
		/// Ottiene imposta la visibilità della griglia e dell'ogetto title
		/// </summary>
		/// <param name="Visibile"> indica true di renderli visibili</param>
		private void setvisiblecontrol(bool Visibile)
		{
			GridTitle1.VisibleRecord=Visibile;
			GridTitle1.hplsNuovo.Visible =false;
			MyDataGrid1.Visible = Visibile;
		}

		private void S_btMostra_Click(object sender, System.EventArgs e)
		{
			MyDataGrid1.CurrentPageIndex = 0;
			Execute(true);
		}



		public void imageButton_Click(Object sender , CommandEventArgs e)
		{
			Context.Items.Add("eq_id",(string)e.CommandArgument);
			Server.Transfer("SchedaApparecchiatura.aspx"); 
		}

		public void Richieste_Click(Object sender , CommandEventArgs e)
		{
			_myColl.AddControl(this.Page.Controls, ParentType.Page);
			string[] splitarg = e.CommandArgument.ToString().Split(Convert.ToChar(","));
			Context.Items.Add("eq_id",(string)splitarg[0]);
			Context.Items.Add("eq_id_char",(string)splitarg[1]);
			Server.Transfer("RichiesteApparecchiatura.aspx"); 			
		}
		
		public void Documenti_Click(Object sender , CommandEventArgs e)
		{			 
			_myColl.AddControl(this.Page.Controls, ParentType.Page);
			string[] splitarg = e.CommandArgument.ToString().Split(Convert.ToChar(","));
			string id_eq= (string)splitarg[0];
			string eq_id=(string)splitarg[1];
			Server.Transfer("Eq_DocumentiAllegati.aspx?id_eq="+ id_eq+ "&eq_id=" +eq_id); 	
		}

		private S_Controls.Collections.S_ControlsCollection GetDatiAprrarecchiature()
		{
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
			s_p_idstanza.Size =10;
			s_p_idstanza.Index = 7;
			s_p_idstanza.Value =UserStanze1.DescStanza;
			_SCollection.Add(s_p_idstanza);


			return _SCollection;
		}

		private void Execute(bool reset)
		{
			///Istanzio la Classe per eseguire la Strore Procedure
			Classi.AnagrafeImpianti.Apparecchiature  _Apparecchiature =new TheSite.Classi.AnagrafeImpianti.Apparecchiature(Context.User.Identity.Name);
			S_Controls.Collections.S_ControlsCollection _SCollection =GetDatiAprrarecchiature();

			
			S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
			s_p_pageindex.ParameterName = "pageindex";
			s_p_pageindex.DbType = CustomDBType.Integer;
			s_p_pageindex.Direction = ParameterDirection.Input;
			s_p_pageindex.Index = _SCollection.Count +1;
			s_p_pageindex.Value=MyDataGrid1.CurrentPageIndex+1;			
			_SCollection.Add(s_p_pageindex);

			S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
			s_p_pagesize.ParameterName = "pagesize";
			s_p_pagesize.DbType = CustomDBType.Integer;
			s_p_pagesize.Direction = ParameterDirection.Input;
			s_p_pagesize.Index = _SCollection.Count +1;
			s_p_pagesize.Value= MyDataGrid1.PageSize;			
			_SCollection.Add(s_p_pagesize);

			DataSet Ds = _Apparecchiature.RicercaApparecchiatura(_SCollection).Copy();

		
			GridTitle1.Visible = true;

			if (reset==true)
			{
				_SCollection =GetDatiAprrarecchiature();
				int _totalRecords = _Apparecchiature.RicercaApparecchiaturaCount(_SCollection);
				this.GridTitle1.NumeroRecords=_totalRecords.ToString();
			}
			MyDataGrid1.DataSource =Ds.Tables[0];
			this.MyDataGrid1.VirtualItemCount =int.Parse(this.GridTitle1.NumeroRecords);
			this.MyDataGrid1.DataBind();

			if (int.Parse(this.GridTitle1.NumeroRecords) > 0) 
			{
				setvisiblecontrol(true);
				GridTitle1.DescriptionTitle="";
			}
			else
			{
				GridTitle1.DescriptionTitle="Nessun dato trovato.";
				setvisiblecontrol(false);
			}
		}

		private void MyDataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			MyDataGrid1.CurrentPageIndex=e.NewPageIndex;
			Execute(false);
		}

		private void btReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("NavigazioneApparecchiature.aspx?FunId=" + ViewState["FunId"]); 
		}

		private void MyDataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton1");
				_img1.Attributes.Add("title","Visualizza Apparecchiatura");		
				ImageButton _img2 = (ImageButton) e.Item.Cells[2].FindControl("Imagebutton2");
				_img2.Attributes.Add("title","Visualizza Le Richieste di Lavoro");		

				if(e.Item.Cells[7].Text.Trim().ToUpper()=="DISMESSA")
				{
					e.Item.ForeColor=System.Drawing.Color.Tomato;			
					e.Item.ToolTip="Apparecchiatura Dismessa";					
				}
								
			}
		}
		private void BindPiano(string CodEdificio)
		{	
			//this.cmbsStanza.Enabled=false;

			this.cmbsPiano.Items.Clear();
		
			if (CodEdificio=="")
			{
				CodEdificio="0";
			}
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
		private void BindStanza()
		{
			//		  
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
			//			//this.cmbsStanza.Enabled=true;
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

		private void S_Button1_Click(object sender, System.EventArgs e)
		{
			//esporta in excel
			Csy.WebControls.Export 	_objExport = new Csy.WebControls.Export();
			DataTable _dt = new DataTable();	
		
			Classi.AnagrafeImpianti.Apparecchiature  _Apparecchiature =new TheSite.Classi.AnagrafeImpianti.Apparecchiature(Context.User.Identity.Name);
			S_Controls.Collections.S_ControlsCollection _SCollection =GetDatiAprrarecchiature();


			DataSet Ds = _Apparecchiature.RicercaApparecchiaturaExcel(_SCollection).Copy();
			
			_dt =Ds.Tables[0].Copy();
				
			if (_dt.Rows.Count > 65536)
			{
				String scriptString = "<script language=JavaScript>alert('I record trovati sono in numero maggiore di 65536 e non possono entrare in un solo foglio excel. Impostare filtri più restrittivi');";
				scriptString += "<";
				scriptString += "/";
				scriptString += "script>";

				if(!this.IsClientScriptBlockRegistered("clientScriptexp"))
					this.RegisterStartupScript ("clientScriptexp", scriptString);
			} 
			else 
			{
			
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
		}

		private string IDBL
		{
			get{return hiddenblid.Value;}
			set{hiddenblid.Value =value;}
		}

	}
}
