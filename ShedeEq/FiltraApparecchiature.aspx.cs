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
using TheSite.Classi;
using StampaRapportiPdf.Classi;

namespace TheSite.ShedeEq
{
	/// <summary>
	/// Descrizione di riepilogo per NavigazioneApparechiature.
	/// </summary>
	public class FiltraApparecchiature : System.Web.UI.Page    // System.Web.UI.Page
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

		public static int FunId = 0;				
		public static string HelpLink = string.Empty;
		
		clMyCollection _myColl = new clMyCollection();
		protected Microsoft.Web.UI.WebControls.TabStrip TabStrip1;
		protected S_Controls.S_ComboBox cmbsPiano;
		protected System.Web.UI.WebControls.Button btnSelezionaTutto;
		protected System.Web.UI.WebControls.Button btnDeselezionaTutto;
		protected System.Web.UI.WebControls.Button btnGeneraReportHtml;
		protected System.Web.UI.WebControls.Button btnGeneraReportPdf;
		protected System.Web.UI.WebControls.Button btnReset;
		protected System.Web.UI.WebControls.Button btnConfermaSelezione;
		protected System.Web.UI.WebControls.Label lblElementiSelezionati;
		protected System.Web.UI.WebControls.Label LblRangeException;
		public TheSite.ShedeEq.VisualizzaSchedaHtml fp;
	
		private int MaxRecord=500;
		protected WebControls.UserStanze UserStanze1;


		TheSite.ShedeEq.VisualizzaSchedaHtml  _fp=null;

		public clMyCollection _Contenitore
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
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];
				//BindApparecchiatura();
				BindServizio("");
				BindTuttiPiani();
				BindStanza();
				BindApparecchiatura();
				setvisiblecontrol(false);
				GridTitle1.Visible = false;
					//Valorizzo i Parametri Immessi
				if(Context.Handler is TheSite.ShedeEq.VisualizzaSchedaHtml)
				{
					_fp = (TheSite.ShedeEq.VisualizzaSchedaHtml)Context.Handler;
					if (_fp!=null) 
					{						
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);		
						//Execute();
						bool enable = Execute();
						EnableBottoniConferma(enable);

					}
				}
				
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


		
		private void BindApparecchiatura()
		{
			
			this.cmbsApparecchiatura.Items.Clear();
		
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
				s_BlId.Value = RicercaModulo1.TxtCodice.Text==""; 
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
			this.MyDataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged);
			this.MyDataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.MyDataGrid1_ItemDataBound);
			this.btnConfermaSelezione.Click += new System.EventHandler(this.btnConfermaSelezione_Click);
			this.btnSelezionaTutto.Click += new System.EventHandler(this.btnSelezionaTutto_Click);
			this.btnDeselezionaTutto.Click += new System.EventHandler(this.btnDeselezionaTutto_Click);
			this.btnGeneraReportHtml.Click += new System.EventHandler(this.btnGeneraReportHtml_Click);
			this.btnGeneraReportPdf.Click += new System.EventHandler(this.btnGeneraReportPdf_Click);
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
			//MyDataGrid1.Visible = Visibile;
		}

		private void S_btMostra_Click(object sender, System.EventArgs e)
		{
			
			MyDataGrid1.CurrentPageIndex = 0;
			bool enable = Execute();
			EnableControl(false);
			Session.Remove("CheckedList");
			Session.Remove("DatiList");
			lblElementiSelezionati.Text ="";
			EnableBottoniConferma(enable);
		
		}
		private void EnableBottoniConferma(bool enable)
		{
//			int i = MyDataGrid1.Items.Count;
//			if(i>0)
//			{
				btnConfermaSelezione.Enabled = enable;//true;
				btnDeselezionaTutto.Enabled = enable;//true;
				btnSelezionaTutto.Enabled = enable;//true;
			if(enable == false)
				if(MyDataGrid1.Items.Count>0)
					LblRangeException.Text = "Sono permessi solo "+MaxRecord.ToString()+" record alla volta. Ti consigliamo di aumentare i filtri di selezione come ad sempio scegliendo un edificio, un piano, una stanza, un servizio dalla maschera di selezione";
				else
					LblRangeException.Text ="";
			else
				LblRangeException.Text="";
//			}
//			else
//			{
//				btnConfermaSelezione.Enabled = false;
//				btnDeselezionaTutto.Enabled = false;
//				btnSelezionaTutto.Enabled = false;
//			}
		}
		private bool Execute()
		{
			bool chech=true;
			DataSet Ds;
			Ds = riempiDatasetRicerca();
			GridTitle1.Visible = true;
			if (Ds.Tables[0].Rows.Count > 0 && Ds.Tables[0].Rows.Count< MaxRecord +1) 
			{
				setvisiblecontrol(true);
				GridTitle1.DescriptionTitle="";
				//				GridTitle1.NumeroRecords =Ds.Tables[0].Rows.Count.ToString();
				//				MyDataGrid1.DataSource= Ds;
				MyDataGrid1.DataBind();
				chech = true;
			}
			else if(Ds.Tables[0].Rows.Count > MaxRecord)
			{
				//				GridTitle1.DescriptionTitle="Nessun dato trovato.";
				//				MyDataGrid1.DataSource= Ds;
				MyDataGrid1.DataBind();
				setvisiblecontrol(true);
				chech = false;
			}
			else
			{
				MyDataGrid1.DataBind();
				setvisiblecontrol(false);
				chech = false;
			}
				
			MyDataGrid1.DataSource= Ds;
			MyDataGrid1.DataBind();
			GridTitle1.NumeroRecords = Ds.Tables[0].Rows.Count.ToString();
			return chech;
		}
		private DataSet riempiDatasetRicerca()
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
			s_p_idstanza.Value =UserStanze1.DescStanza;// (cmbsStanza.SelectedValue==string.Empty)? 0:Int32.Parse(cmbsStanza.SelectedValue);
			_SCollection.Add(s_p_idstanza);
			///Istanzio la Classe per eseguire la Strore Procedure
			Classi.AnagrafeImpianti.Apparecchiature  _Apparecchiature =new TheSite.Classi.AnagrafeImpianti.Apparecchiature(Context.User.Identity.Name);
			
			///Eseguo il Binding sulla Griglia.
			DataSet Ds=_Apparecchiature.RicercaApparecchiatura(_SCollection);
			return Ds;
		}
		private void MyDataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			MyDataGrid1.CurrentPageIndex=e.NewPageIndex;
		    Execute();
			GetControlli();
		}

		
		private void MyDataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{

				if(e.Item.Cells[6].Text.Trim().ToUpper()=="DISMESSA")
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
			
		//	this.cmbsStanza.Enabled=true;
			
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
//			//this.cmbsStanza.Enabled=true;
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
			Server.Transfer("FiltraApparecchiature.aspx");
		}

		private void btnConfermaSelezione_Click(object sender, System.EventArgs e)
		{
			//lblMessaggio.Text = "";
			SetDati();
			SetControlli();	
		}
		private void SetDati()
		{			
			
			Hashtable _HS = new Hashtable();
			int indice = 0;
			
			if(Session["DatiList"]!=null)
			{
				_HS=(Hashtable) Session["DatiList"];				
			}			
			foreach(DataGridItem o_Litem in MyDataGrid1.Items)
			{
								
				indice = Int32.Parse(o_Litem.Cells[1].Text);									
				System.Web.UI.WebControls.CheckBox cb = 
					(System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel")
					;																									
			
				if(_HS.ContainsKey(indice))
					_HS.Remove(indice);												
							
				if(cb.Checked)
				{
					_HS.Add(indice, indice);		
				}
			}			
			
			Session.Remove("DatiList");
			Session.Add("DatiList",_HS);			
			lblElementiSelezionati.Text="Elementi Selezionati - " + _HS.Count.ToString() + " -";
			if(_HS.Count>0)
			{
				EnableControl(true);
			}
			else
			{
				Session.Remove("DatiList");
				EnableControl(false);
			}

			//			txtTotSelezionati.Text=_HS.Count.ToString();
		}
		private void EnableControl(bool enable)
		{
			//S_btnStampa.Enabled =enable;
			//			S_optLungo.Enabled = enable;
			//			S_optRptCorto.Enabled = enable;
			btnGeneraReportHtml.Enabled = enable;
			btnGeneraReportPdf.Enabled = enable;
			
		}
		private void SetControlli()
		{			
			clMyDataGridCollection _cl = new clMyDataGridCollection();
			
			Hashtable _HS = new Hashtable();
			if(Session["CheckedList"]!=null)
			{
				_HS=(Hashtable) Session["CheckedList"];				
			}
			_HS=_cl.SetControl(MyDataGrid1,_HS,MyDataGrid1.CurrentPageIndex);
			Session.Remove("CheckedList");
			Session.Add("CheckedList",_HS);	
		}
		private string IDBL
		{
			get{return hiddenblid.Value;}
			set{hiddenblid.Value =value;}
		}
		private void SelezionaTutti(bool val)
		{	
			DataSet ds;
			ds = riempiDatasetRicerca();
			if(!val)
			{
				Session.Remove("CheckedList");
				Session.Remove("DatiList");
				lblElementiSelezionati.Text="Elementi Selezionati - 0 -";
				EnableControl(false);
				//txtTotSelezionati.Text="0";
			}
			else
			{				
				SetControlli();										
			}
			
			for(int Pagine = 0;Pagine<=MyDataGrid1.PageCount;Pagine++)
			{
	
		
				MyDataGrid1.DataSource= ds.Tables[0];//Session["DataSet"];
				MyDataGrid1.DataBind();
				MyDataGrid1.CurrentPageIndex=Pagine;									
							
				SetDati(val);
				
				if(val)
				{	
					SetControlli();				
				}
			}

			MyDataGrid1.CurrentPageIndex=0;
			MyDataGrid1.DataSource= ds.Tables[0];;
			MyDataGrid1.DataBind();			
			GetControlli();						
		}
		private void SetDati(bool val)
		{	
			Hashtable _HS = new Hashtable();
			int indice = 0;
		
			if(Session["DatiList"]!=null)
			{
				_HS=(Hashtable) Session["DatiList"];				
			}

					
			foreach(DataGridItem o_Litem in MyDataGrid1.Items)
			{								
				indice = Int32.Parse(o_Litem.Cells[1].Text);									
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel");																									
				cb.Checked=val;
				if(_HS.ContainsKey(indice))
					_HS.Remove(indice);												
							
				if(cb.Checked)
				{
					_HS.Add(indice, indice);		
				}
			}			
			
			Session.Remove("DatiList");
			Session.Add("DatiList",_HS);			
			lblElementiSelezionati.Text="Elementi Selezionati - " + _HS.Count.ToString() + " -";
			if(_HS.Count>0)
			{
				EnableControl(true);
			}
			else
			{
				Session.Remove("DatiList");
				EnableControl(false);
			}
				

			//txtTotSelezionati.Text=_HS.Count.ToString();			
		}
		private void GetControlli()
		{	
			clMyDataGridCollection _cl = new clMyDataGridCollection();
			if(Session["CheckedList"]!=null)
			{	
				_cl.GetControl(MyDataGrid1,(Hashtable) Session["CheckedList"],MyDataGrid1.CurrentPageIndex);
			}
		}

		private void btnSelezionaTutto_Click(object sender, System.EventArgs e)
		{
			SelezionaTutti(true);
		}

		private void btnDeselezionaTutto_Click(object sender, System.EventArgs e)
		{
			SelezionaTutti(false);
		}

		private void btnGeneraReportHtml_Click(object sender, System.EventArgs e)
		{

			_myColl.AddControl(this.Page.Controls,ParentType.Page);
			Server.Transfer("VisualizzaSchedaHtml.aspx");
		}

		private void btnGeneraReportPdf_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("VisulizzaSchedaEqPdf.aspx");
		}
		

	}
}
