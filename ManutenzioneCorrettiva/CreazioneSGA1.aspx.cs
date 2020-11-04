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
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer.DBType;
using System.Web.Mail;

namespace TheSite.ManutenzioneCorrettiva
{
	/// <summary>
	/// Descrizione di riepilogo per CreazioneSGA1.
	/// </summary>
	public class CreazioneSGA1 : System.Web.UI.Page
	{
		#region dichiarazioni
		protected System.Web.UI.WebControls.Label lblProgetto;
		protected System.Web.UI.WebControls.DropDownList CmbProgetto;
		protected System.Web.UI.WebControls.Panel PanelRichiedente;
		protected System.Web.UI.WebControls.Panel PanelServizio;
		protected System.Web.UI.WebControls.Panel PanelProblema;
		protected WebControls.PageTitle PageTitle1;
		Classi.ManCorrettiva.ClManCorrettiva _ClManCorrettiva;
		public static int FunId = 0;	
		public static IDictionaryEnumerator myEnumerator=null;
		public static string HelpLink = string.Empty;
		TheSite.ManutenzioneCorrettiva.SfogliaRdlPaging _fp;
		public int ItemId=0;
		protected WebControls.CalendarPicker CalendarPiker4;
		protected WebControls.CalendarPicker CalendarPiker3;
		public string url="";
		protected System.Web.UI.WebControls.Panel Conduzione;
		protected System.Web.UI.WebControls.Panel Sopralluogo;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvRichiedenteNome;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvRichiedenteCognome;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvEdificio;
		protected System.Web.UI.WebControls.TextBox txtsTelefonoRichiedente;
		protected System.Web.UI.WebControls.TextBox txtsNota;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.DropDownList cmbsPiano;
		protected System.Web.UI.HtmlControls.HtmlGenericControl PanelEmesse;
		protected System.Web.UI.WebControls.Button btsCodice;
		protected System.Web.UI.WebControls.TextBox txtBL_ID;
		protected System.Web.UI.WebControls.DropDownList cmbsServizio;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorServ;
		protected System.Web.UI.WebControls.DropDownList cmbsApparecchiatura;
		protected System.Web.UI.WebControls.DropDownList cmbsUrgenza;
		protected System.Web.UI.WebControls.TextBox txtsProblema;
		protected System.Web.UI.WebControls.DropDownList cmbsTipoManutenzione;
		protected System.Web.UI.WebControls.DropDownList cmbsTipoIntrevento;
		protected System.Web.UI.WebControls.TextBox TxtCausa;
		protected System.Web.UI.WebControls.TextBox TxtGuasto;
		protected System.Web.UI.WebControls.CheckBox chksSendMail;
		protected System.Web.UI.WebControls.TextBox txtsMittente;
		protected System.Web.UI.WebControls.TextBox txtsorain;
		protected System.Web.UI.WebControls.TextBox txtsorainmin;
		protected S_Controls.S_Button btnsSalva;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected S_Controls.S_Button btnsChiudi;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected System.Web.UI.WebControls.LinkButton lkbNonEmesse;
		protected System.Web.UI.WebControls.LinkButton lnkChiudi;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected System.Web.UI.WebControls.LinkButton LinkApprovate;
		protected System.Web.UI.WebControls.LinkButton LinkChiudi2;
		protected System.Web.UI.WebControls.DataGrid DatagridEmesse;
		protected System.Web.UI.HtmlControls.HtmlGenericControl pnlShowInfo;
		protected System.Web.UI.WebControls.RequiredFieldValidator RqStd;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected WebControls.CodiceApparecchiature CodiceApparecchiature1;
		protected WebControls.RichiedentiSollecito RichiedentiSollecito1;	
		protected WebControls.UserStanze UserStanze1;
		protected WebControls.CalendarPicker CalendarPicker1;


		public MyCollection.clMyCollection _Contenitore
		{
			get 
			{
				if(this.ViewState["mioContenitore"]!=null)
					return (MyCollection.clMyCollection)this.ViewState["mioContenitore"];
				else
					return new MyCollection.clMyCollection();
			}
		}

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			// ***********************  MODIFICA PER I PERMESSI SULLA PAGINA CORRENTE **********************
			string _mypage="./ManutenzioneCorrettiva/CreazioneSGA1.aspx";			
			Classi.SiteModule _SiteModule = new TheSite.Classi.SiteModule(_mypage);
			// ***********************  MODIFICA PER I PERMESSI SULLA PAGINA CORRENTE **********************

			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;

			if(Request.QueryString["ItemId"]!=null)
			{
				ItemId=Int32.Parse(Request["ItemId"]);
				this.PageTitle1.Title = "Modifica Rdl n°: "+ItemId.ToString();
			}
			else
				this.PageTitle1.Title = _SiteModule.ModuleTitle;

			this.RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);
			this.RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindApparecchiatura);
			this.RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.ValorizzaReperibilita);
			//this.RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindMail);
			this.RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindPiano);	
			this.RicercaModulo1.DelegatePresidio1 +=new  WebControls.DelegatePresidio(this.BindControls);

			this.CodiceApparecchiature1.NameComboApparecchiature ="cmbsApparecchiatura";
			/// Imposto il nome della combo Servizio
			this.CodiceApparecchiature1.NameComboServizio ="cmbsServizio";
			/// Imposto il nome dell'user control RicercaModulo
			this.CodiceApparecchiature1.NameUserControlRicercaModulo  ="RicercaModulo1";
			/// Imposto il nome della cobmbo del piano
			this.CodiceApparecchiature1.NameComboPiano  ="cmbsPiano";
			//chksSendMail.Checked=true;
			//txtsMittente.Text="mariangela.centorrino@cofathec.it";
			//txtsMittente.ReadOnly=false;
			
			#region AggiuntaControlli
			UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
			UserStanze1.NameComboPiano="cmbsPiano";

			//Aggiunta controlli all'ora
			txtsorain.Attributes.Add("onkeypress","SoloNumeri();");
			txtsorain.Attributes.Add("onpaste","return false;");
			txtsorain.Attributes.Add("maxlength","2");			
			txtsorain.Attributes.Add("onblur","return ControllaOra('"+ txtsorain.ClientID +"' );");

			txtsorainmin.Attributes.Add("onkeypress","SoloNumeri();");
			txtsorainmin.Attributes.Add("onpaste","return false;");
			txtsorainmin.Attributes.Add("onblur","return ControllaMin('"+ txtsorainmin.ClientID +"' );");
			txtsorainmin.Attributes.Add("maxlength","2");

			//			TxtOraAseguito.Attributes.Add("onkeypress","SoloNumeri();");
			//			TxtOraAseguito.Attributes.Add("onpaste","return false;");
			//			TxtOraAseguito.Attributes.Add("maxlength","2");			
			//			TxtOraAseguito.Attributes.Add("onblur","return ControllaOra('"+ TxtOraAseguito.ClientID +"' );");
			//
			//			TxtMinAseguito.Attributes.Add("onkeypress","SoloNumeri();");
			//			TxtMinAseguito.Attributes.Add("onpaste","return false;");
			//			TxtMinAseguito.Attributes.Add("onblur","return ControllaMin('"+ TxtMinAseguito.ClientID +"' );");
			//			TxtMinAseguito.Attributes.Add("maxlength","2");
			//			//
			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsApparecchiatura.ClientID + "').disabled = true;");
			this.cmbsServizio.Attributes.Add("onchange", sbValid.ToString());

			sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsServizio.ClientID + "').disabled = true;");
			this.cmbsApparecchiatura.Attributes.Add("onchange", sbValid.ToString());
		
			CmbProgetto.Attributes.Add("onchange","setProg();"); 
			string Prog = "";
			Prog =  "<script language=\"javascript\">\n";
			Prog += "setProg();\n";
			Prog += "</script>\n";
			if(!this.IsStartupScriptRegistered("clientScript3"))
				this.RegisterStartupScript("clientScript3", Prog);


	

			            
			chksSendMail.Attributes.Add("onclick","visibletextmail('" + chksSendMail.ClientID + "','" + txtsMittente.ClientID  + "')");  
			txtsMittente.Enabled =chksSendMail.Checked;
			
			#endregion
			
			if (!Page.IsPostBack)
			{		
			
				this.BindProgetti();
				this.LoadTipoIntervento();
				LoadTipoManutenzione();
//				chksSendMail.Checked=true;
//				txtsMittente.Text="anovelli@protecsrl.biz";
//				txtsMittente.ReadOnly=false;
				
				if (Request["VarApp"]!=null)
				{
					if(Request["VarApp"]=="1")	
					{
						CmbProgetto.SelectedValue ="1";
					}
					if(Request["VarApp"]=="2")	
					{
						CmbProgetto.SelectedValue ="2";
					}
				}
				
				
			
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];

				this.LinkApprovate.Attributes.Add("onclick","return ControllaBL('" + RicercaModulo1.TxtCodice.ClientID + "')");
				this.lkbNonEmesse.Attributes.Add("onclick","return ControllaBL('" + RicercaModulo1.TxtCodice.ClientID + "')");

				this.btsCodice.CausesValidation = false;
				this.btsCodice.Attributes.Add("onclick","return ControllaBL('" + RicercaModulo1.TxtCodice.ClientID + "');");
												
				rfvRichiedenteNome.ControlToValidate= RichiedentiSollecito1.ID + ":" +RichiedentiSollecito1.s_RichNome.ID;
				rfvRichiedenteCognome.ControlToValidate= RichiedentiSollecito1.ID + ":" + RichiedentiSollecito1.s_RichCognome.ID;
				rfvEdificio.ControlToValidate= RicercaModulo1.ID + ":" + RicercaModulo1.TxtCodice.ID;
				
				
				//Modifidica Momentanea per CallCenter poi eliminare le righe sottostanti
				this.RicercaModulo1.TxtCodice.Text="";
				cmbsPiano.SelectedValue="";
				//Modifidica Momentanea per CallCenter poi eliminare le righe soprastanti
				cmbsPiano.Attributes.Add("onchange","clearRoom();");
				//Imposto data e ora correnti
				CalendarPicker1.Datazione.Text = DateTime.Now.ToShortDateString();
				txtsorain.Text= Convert.ToString(DateTime.Now.Hour).PadLeft(2,'0');
				txtsorainmin.Text= Convert.ToString(DateTime.Now.Minute).PadLeft(2,'0');
				this.CodiceApparecchiature1.Visible = false;		
				this.CodiceApparecchiature1.s_CodiceApparecchiatura.ReadOnly =  true;

			
				if(ItemId!=0)
				{
					this.BindPiano("");							
					this.BindApparecchiatura(string.Empty);				
					BindServizio("");
					BindControls("");

					LoadDatiCreazione(ItemId);
					btnsChiudi.Visible=true;
					if(Context.Handler is TheSite.ManutenzioneCorrettiva.SfogliaRdlPaging) 
					{
						_fp = (TheSite.ManutenzioneCorrettiva.SfogliaRdlPaging) Context.Handler;
						this.ViewState.Add("mioContenitore",_fp._Contenitore);
						this.ViewState.Add("url",Request.UrlReferrer.ToString());
						this.ViewState.Add("PAG","SF");
					}
					else
					{
						this.ViewState.Add("url",Request.UrlReferrer.ToString());
						this.ViewState.Add("PAG","N");
					}
				}
				else
					btnsChiudi.Visible=false;
			}		
			SetProject();
		}
		private void SetProject()
		{
			if (Context.User.IsInRole("MA") && Context.User.IsInRole("PA"))
			{
				CmbProgetto.Visible =true;
				lblProgetto.Visible =true;
			}
			else
			{
				CmbProgetto.Visible =false;
				lblProgetto.Visible =false;
				if (Context.User.IsInRole("MA") && !Context.User.IsInRole("PA"))
				{
					CmbProgetto.SelectedValue="1";
					RichiedentiSollecito1.Progetto="1"; 
					RicercaModulo1.idProg.Value="1";

				}
				if (!Context.User.IsInRole("MA") && Context.User.IsInRole("PA"))
				{
					CmbProgetto.SelectedValue="2";
					RichiedentiSollecito1.Progetto="2"; 
					RicercaModulo1.idProg.Value="2";
					//					if (!Page.IsStartupScriptRegistered("nasc"))
					//						Page.RegisterStartupScript("nasc","<script language='javascript'>NascondiASeguito('2')</script>"); 
				}
				if (Context.User.IsInRole("AMMINISTRATORI") )
				{
					CmbProgetto.Visible =true;
					lblProgetto.Visible =true;
					//CmbProgetto.Attributes.Add("onchange","NascondiASeguito(this.value);");
				}
				if (Context.User.IsInRole("callcenter") )
				{
					CmbProgetto.Visible =true;
					lblProgetto.Visible =true;
					//CmbProgetto.Attributes.Add("onchange","NascondiASeguito(this.value);");
				}
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
			this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region carica controlli
		private void LoadTipoManutenzione()
		{
			_ClManCorrettiva=new TheSite.Classi.ManCorrettiva.ClManCorrettiva();

			DataSet _MyDs =  _ClManCorrettiva.GetTipoManutenzione();

			if (_MyDs.Tables[0].Rows.Count>0)
			{
				cmbsTipoManutenzione.DataSource = _MyDs.Tables[0];
				this.cmbsTipoManutenzione.DataTextField = "descrizione";
				this.cmbsTipoManutenzione.DataValueField = "id";
				this.cmbsTipoManutenzione.DataBind();
				if (Request["VarApp"]!=null)
				{
					if(Request["VarApp"]=="1")	
					{
						cmbsTipoManutenzione.SelectedValue ="3";//Straordinaria
					}
				}
			
			}	
		}
		private void ValorizzaReperibilita(string CodEdificio)
		{
			if (GetVerificaAddetti(CodEdificio))
			
				txtBL_ID.Text = CodEdificio;
		}

		


		private void LoadTipoIntervento()
		{
			_ClManCorrettiva=new TheSite.Classi.ManCorrettiva.ClManCorrettiva(Context.User.Identity.Name);

			cmbsTipoIntrevento.Items.Clear();

			DataSet _MyDs;
			_MyDs = _ClManCorrettiva.GetTipointervento();
			

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsTipoIntrevento.DataSource =_MyDs.Tables[0];
				this.cmbsTipoIntrevento.DataTextField = "descrizione_breve";
				this.cmbsTipoIntrevento.DataValueField = "id";
				this.cmbsTipoIntrevento.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Tipo Intervento -";
				this.cmbsTipoIntrevento.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		
	
		private void BindProgetti()
		{

			this.CmbProgetto.Items.Clear();
		
			TheSite.Classi.Progetti _Prog = new TheSite.Classi.Progetti();
						
			DataSet _MyDs = _Prog.GetData();			
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.CmbProgetto.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "id_progetto", "- Selezionare un Progetto -", "");				
				this.CmbProgetto.DataTextField ="descrizione";
				this.CmbProgetto.DataValueField  ="id_progetto";
				this.CmbProgetto.DataBind();
				

			}
			else
			{
				string s_Messagggio = "- Nessun Progetto  -";
				this.CmbProgetto.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
						
			}			

			

		}

		private void BindPiano(string CodEdificio)
		{	
			this.cmbsPiano.Items.Clear();
		
			TheSite.Classi.ManOrdinaria.Richiesta  _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
			
			DataSet	_MyDs = _Richiesta.GetPiani(CodEdificio);

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
			cmbsPiano.Attributes.Add("OnChange","ClearApparechiature();");
		}

		private void BindControls()
		{
			BindControls(RicercaModulo1.Idbl);
		}
		private void BindControls(string Codice)
		{
			
			if(Codice!="")
			{
				int cod= Convert.ToInt32(Codice);
				Classi.ClassiDettaglio.Urgenza _Urgenza = new TheSite.Classi.ClassiDettaglio.Urgenza();
				this.cmbsUrgenza.DataSource = _Urgenza.GetPriorita(cod);
				this.cmbsUrgenza.DataTextField = "DESCRIPTION";
				this.cmbsUrgenza.DataValueField = "ID";
				this.cmbsUrgenza.DataBind();
				//this.cmbsUrgenza.SelectedValue = "7";
			}
			else
			{
				string s_Messagggio = "- Nessuna urgenza -";
				this.cmbsUrgenza.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
			
		}
		//Recupera la mail dell'edificio selezionato
		private void BindMail(string Codice)
		{
			this.txtsMittente.Text =RicercaModulo1.Email;
		} 

		private void BindServizio(string CodEdificio)
		{

			if (GetVerificaBL(CodEdificio)!= "0")
			{
				this.lkbNonEmesse.Text = "Richieste non Emesse per Edificio " + CodEdificio + " : " + GetNumeroNonEmesse(CodEdificio) ;
				this.LinkApprovate.Text = "Richieste Approvate per Edificio " + CodEdificio + " : " + GetNumeroApprovate(CodEdificio) ;
			}
			else
			{
				this.lkbNonEmesse.Text = "Richieste non Emesse";
				this.LinkApprovate.Text = "Richieste Approvate";
			}
			this.cmbsServizio.Items.Clear();
			this.CodiceApparecchiature1.Visible = false;
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
			Classi.ClassiDettaglio.Servizi  _Servizio = new TheSite.Classi.ClassiDettaglio.Servizi(Context.User.Identity.Name);

			DataSet _MyDs;

			if (CodEdificio!= string.Empty)
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
								
				if (_MyDs.Tables[0].Rows.Count > 0)
				{
					this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
						_MyDs.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "Non Definito", "0");
					this.cmbsServizio.DataTextField = "DESCRIZIONE";
					this.cmbsServizio.DataValueField = "IDSERVIZIO";
					this.cmbsServizio.DataBind();
				}
				else
				{
					string s_Messagggio = "Non Definito";
					this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0"));
				}
				
				Hashtable ArrServizi = new Hashtable();

				for (int i=0;i<_MyDs.Tables[0].Rows.Count;i++)
				{					
					string des= _MyDs.Tables[0].Rows[i]["DESCRIZIONE"].ToString();
					string cod= _MyDs.Tables[0].Rows[i]["IDSERVIZIO"].ToString();					
					ArrServizi.Add(cod,des);
				}				

				myEnumerator = ArrServizi.GetEnumerator();
				ViewState.Add("ArrServizi",ArrServizi);

			}
			else
			{
				string s_Messagggio = "Non Definito";
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0"));
			}		
		}

		private void BindApparecchiatura(string CodEdificio)
		{
			
			this.cmbsApparecchiatura.Items.Clear();		
			Classi.AnagrafeImpianti.Apparecchiature  _Apparecchiature = new TheSite.Classi.AnagrafeImpianti.Apparecchiature(Context.User.Identity.Name);
			
			DataSet _MyDs;

			if (CodEdificio != string.Empty && cmbsServizio.SelectedValue != "0")
			{
				S_ControlsCollection _SColl = new S_ControlsCollection();

				S_Controls.Collections.S_Object s_BlId = new S_Object();
				s_BlId.ParameterName = "p_Bl_Id";
				s_BlId.DbType = CustomDBType.VarChar;
				s_BlId.Direction = ParameterDirection.Input;
				s_BlId.Size = 50;
				s_BlId.Index = 0;
				s_BlId.Value = RicercaModulo1.TxtCodice.Text;
				_SColl.Add(s_BlId);
			
				S_Controls.Collections.S_Object s_Servizio = new S_Object();
				s_Servizio.ParameterName = "p_Servizio";
				s_Servizio.DbType = CustomDBType.Integer;
				s_Servizio.Direction = ParameterDirection.Input;
				s_Servizio.Index = 1;
				s_Servizio.Value = (cmbsServizio.SelectedValue == "")? 0:Int32.Parse(cmbsServizio.SelectedValue);
				_SColl.Add(s_Servizio);

				_MyDs = _Apparecchiature.GetDataServizi(_SColl).Copy(); 
			
  
				if (_MyDs.Tables[0].Rows.Count > 0)
				{
					this.cmbsApparecchiatura.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
						_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Standard -", "0");
					this.cmbsApparecchiatura.DataTextField = "DESCRIZIONE";
					this.cmbsApparecchiatura.DataValueField = "ID";
					this.cmbsApparecchiatura.DataBind();
				}
				else
				{
					string s_Messagggio = "- Nessuno Standard -";
					this.cmbsApparecchiatura.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0"));
				}
				
				cmbsApparecchiatura.Enabled=true;
			}
			else
			{
				string s_Messagggio = "- Nessuno Standard -";
				this.cmbsApparecchiatura.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0"));

			}
		}

		#endregion

		#region BtnSalva
		private void btnsSalva_Click(object sender, System.EventArgs e)
		{
	
			//Server.Transfer("VisualizzaRdl.aspx?FunId=" + FunId + "&WrId=1");			
			Classi.ManOrdinaria.Richiesta _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
			if (_Richiesta.IsValidBlId(this.RicercaModulo1.BlId))
			{
				int i_Wr_Id = this.NuovaRichiesta();
				if (i_Wr_Id > 0)
				{	
					//Invio le eventuali mail legate all'edificio
					if (txtsMittente.Text!="" && chksSendMail.Checked==true )
					{
						string[] indirizzi= txtsMittente.Text.Split(Convert.ToChar(";"));   
						Classi.ClassMail _mail=new TheSite.Classi.ClassMail();
						try
						{
							foreach(string indirizzo in indirizzi)
							{
								System.Web.Mail.MailMessage _messaggio=new System.Web.Mail.MailMessage();
								_messaggio.From =System.Configuration.ConfigurationSettings.AppSettings["MailFrom"];
								_messaggio.Subject="Avviso di creazione di una richiesta di lavoro."; 
								_messaggio.To =indirizzo.Trim();
							    
								_messaggio.BodyFormat =MailFormat.Html; 
								_mail.Messaggio =_messaggio;
								_mail.Idrichiesta =i_Wr_Id.ToString();
								_mail.Name =indirizzo.Trim();
								_mail.Decription=txtsProblema.Text;
								_mail.CodiceEdificio =RicercaModulo1.BlId + " " + RicercaModulo1.Nome
									+ " Comune: " + RicercaModulo1.Comune;
								//_mail.Surname =indirizzo;
								_mail.SendMail(Classi.ClassMail.TipoMail.MailCreazioneRichiesta); 
							} 
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
					if (ItemId== 0)
					{
						string VarApp="";
						if (Request["VarApp"]!=null)
						{
							VarApp="&VarApp=" + Request["VarApp"];
						}
						Response.Redirect("VisualizzaRdl1.aspx?FunId=" + FunId + "&ItemId=" + i_Wr_Id.ToString()+ VarApp);
					}
					else
					{
						if (ViewState["PAG"].ToString()=="SF")			
						{
					
							Server.Transfer("SfogliaRdlPaging.aspx");
						}
						else
						{
							Response.Redirect(ViewState["url"].ToString());
			
						}
					}
				}
			}
			else
			{
				this.PanelMess.ShowError("Impossibile inserire una richiesta per l'edificio indicato", true);
			}
			
		}
		#endregion
		
		#region Richiesta passaggio parametri 
		private int NuovaRichiesta()
		{
			int i_WrId = 0;

			//			this.txtsProblema.DBDefaultValue = DBNull.Value;
			//			this.txtsNota.DBDefaultValue = DBNull.Value;
			//			this.txtsTelefonoRichiedente.DBDefaultValue = DBNull.Value;
			//CmbASeguito.DBDefaultValue=DBNull.Value;
		
			Classi.ManOrdinaria.Richiesta _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
			
			S_Controls.Collections.S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_BlId = new S_Object();
			s_BlId.ParameterName = "p_Bl_Id";
			s_BlId.DbType = CustomDBType.VarChar;
			s_BlId.Direction = ParameterDirection.Input;
			s_BlId.Size = 8;
			s_BlId.Index = _SColl.Count;
			s_BlId.Value = this.RicercaModulo1.BlId;
			_SColl.Add(s_BlId);
			
			S_Controls.Collections.S_Object s_p_NomeRichiedente = new S_Controls.Collections.S_Object();
			s_p_NomeRichiedente.ParameterName = "p_NomeRich";
			s_p_NomeRichiedente.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_NomeRichiedente.Direction = ParameterDirection.Input;
			s_p_NomeRichiedente.Index = _SColl.Count;
			s_p_NomeRichiedente.Size=50;
			s_p_NomeRichiedente.Value = this.RichiedentiSollecito1.NomeCompleto;			
			_SColl.Add(s_p_NomeRichiedente);
			
			
			S_Controls.Collections.S_Object s_p_Richiedente = new S_Controls.Collections.S_Object();
			s_p_Richiedente.ParameterName = "p_CognomeRich";
			s_p_Richiedente.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Richiedente.Direction = ParameterDirection.Input;
			s_p_Richiedente.Index = _SColl.Count;
			s_p_Richiedente.Size=50;
			s_p_Richiedente.Value = this.RichiedentiSollecito1.CognomeCompleto;			
			_SColl.Add(s_p_Richiedente);

			S_Controls.Collections.S_Object p_Em_Id = new S_Controls.Collections.S_Object();
			p_Em_Id.ParameterName = "p_Em_Id";
			p_Em_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			p_Em_Id.Direction = ParameterDirection.Input;
			p_Em_Id.Index = _SColl.Count;
			p_Em_Id.Size=50;
			p_Em_Id.Value = this.RichiedentiSollecito1.NomeCompleto + ' ' + this.RichiedentiSollecito1.CognomeCompleto;			
			_SColl.Add(p_Em_Id);

			int Gruppo;
			
			if(this.RichiedentiSollecito1.s_RichGruppo.SelectedValue=="")			
				Gruppo=0;			
			else			
				Gruppo=Int16.Parse(this.RichiedentiSollecito1.s_RichGruppo.SelectedValue);
			
			
			S_Controls.Collections.S_Object s_p_Gruppo = new S_Controls.Collections.S_Object();
			s_p_Gruppo.ParameterName = "p_Gruppo";
			s_p_Gruppo.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Gruppo.Direction = ParameterDirection.Input;
			s_p_Gruppo.Index = _SColl.Count;
			s_p_Gruppo.Value = Gruppo;
			_SColl.Add(s_p_Gruppo);

			S_Controls.Collections.S_Object s_p_Phone_em = new S_Controls.Collections.S_Object();
			s_p_Phone_em.ParameterName = "p_phone_em";
			s_p_Phone_em.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Phone_em.Direction = ParameterDirection.Input;
			s_p_Phone_em.Index = _SColl.Count;
			s_p_Phone_em.Size= 50;
			s_p_Phone_em.Value = RichiedentiSollecito1.telefono ;			
			_SColl.Add(s_p_Phone_em);

			S_Controls.Collections.S_Object s_p_email_em = new S_Controls.Collections.S_Object();
			s_p_email_em.ParameterName = "p_email_em";
			s_p_email_em.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_email_em.Direction = ParameterDirection.Input;
			s_p_email_em.Index = _SColl.Count;
			s_p_email_em.Size= 50;
			s_p_email_em.Value = RichiedentiSollecito1.email;			
			_SColl.Add(s_p_email_em);

			S_Controls.Collections.S_Object s_p_stanza = new S_Controls.Collections.S_Object();
			s_p_stanza.ParameterName = "p_stanza";
			s_p_stanza.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_stanza.Direction = ParameterDirection.Input;
			s_p_stanza.Index = _SColl.Count;
			s_p_stanza.Size= 50;
			s_p_stanza.Value = RichiedentiSollecito1.stanza ;			
			_SColl.Add(s_p_stanza);
	
			

			S_Controls.Collections.S_Object s_p_Phone = new S_Controls.Collections.S_Object();
			s_p_Phone.ParameterName = "p_Phone";
			s_p_Phone.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Phone.Direction = ParameterDirection.Input;
			s_p_Phone.Index = _SColl.Count;
			s_p_Phone.Size= 50;
			s_p_Phone.Value = txtsTelefonoRichiedente.Text ;			
			_SColl.Add(s_p_Phone);

			S_Controls.Collections.S_Object s_p_Nota_Ric = new S_Controls.Collections.S_Object();
			s_p_Nota_Ric.ParameterName = "p_Nota_Ric";
			s_p_Nota_Ric.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Nota_Ric.Direction = ParameterDirection.Input;
			s_p_Nota_Ric.Index = _SColl.Count;
			s_p_Nota_Ric.Size= 2000;
			s_p_Nota_Ric.Value = txtsNota.Text ;			
			_SColl.Add(s_p_Nota_Ric);

			//vecchio panel servizio
			S_Controls.Collections.S_Object s_p_Servizio_Id = new S_Object();
			s_p_Servizio_Id.ParameterName = "p_Servizio_Id";
			s_p_Servizio_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Servizio_Id.Direction = ParameterDirection.Input;
			s_p_Servizio_Id.Size = 10;
			s_p_Servizio_Id.Index = _SColl.Count;
			s_p_Servizio_Id.Value=Convert.ToInt32(cmbsServizio.SelectedValue);	
			_SColl.Add(s_p_Servizio_Id);

			S_Controls.Collections.S_Object s_p_Eqstd_Id = new S_Object();
			s_p_Eqstd_Id.ParameterName = "p_Eqstd_Id";
			s_p_Eqstd_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Eqstd_Id.Direction = ParameterDirection.Input;
			s_p_Eqstd_Id.Size = 10;
			s_p_Eqstd_Id.Index = _SColl.Count;
			s_p_Eqstd_Id.Value=Convert.ToInt32(cmbsApparecchiatura.SelectedValue);	
			_SColl.Add(s_p_Eqstd_Id);
	
			//	_SColl.AddItems(this.PanelServizio.Controls);
			//	_SColl.AddItems(this.PanelProblema.Controls);
			//ex panel Problema

			S_Controls.Collections.S_Object s_p_Priority = new S_Object();
			s_p_Priority.ParameterName = "p_Priority";
			s_p_Priority.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Priority.Direction = ParameterDirection.Input;
			s_p_Priority.Size = 10;
			s_p_Priority.Index = _SColl.Count;
			s_p_Priority.Value=Convert.ToInt32(cmbsUrgenza.SelectedValue);	
			_SColl.Add(s_p_Priority);
			
			S_Controls.Collections.S_Object s_p_Description = new S_Object();
			s_p_Description.ParameterName = "p_Description";
			s_p_Description.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Description.Direction = ParameterDirection.Input;
			s_p_Description.Size = 2000;
			s_p_Description.Index = _SColl.Count;
			s_p_Description.Value=txtsProblema.Text;			
			_SColl.Add(s_p_Description);

			////

	
			S_Controls.Collections.S_Object s_p_Date_Requested = new S_Object();
			s_p_Date_Requested.ParameterName = "p_Date_Requested";
			s_p_Date_Requested.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Date_Requested.Direction = ParameterDirection.Input;
			s_p_Date_Requested.Size = 10;
			s_p_Date_Requested.Index = _SColl.Count;
			s_p_Date_Requested.Value=CalendarPicker1.Datazione.Text;			
			_SColl.Add(s_p_Date_Requested);

			S_Controls.Collections.S_Object s_p_Time_Requested = new S_Object();
			s_p_Time_Requested.ParameterName = "p_Time_Requested";
			s_p_Time_Requested.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Time_Requested.Direction = ParameterDirection.Input;
			s_p_Time_Requested.Size = 11;
			s_p_Time_Requested.Index = _SColl.Count;
			s_p_Time_Requested.Value= txtsorain.Text+ ":" + txtsorainmin.Text+ ":00" ;			
			_SColl.Add(s_p_Time_Requested);


			S_Controls.Collections.S_Object s_EqId = new S_Object();
			s_EqId.ParameterName = "p_Eq_Id";
			s_EqId.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_EqId.Direction = ParameterDirection.InputOutput;
			s_EqId.Size = 10;
			s_EqId.Index = _SColl.Count;
						
			s_EqId.Value = (this.CodiceApparecchiature1.CodiceHidden.Value ==string.Empty)? 0: Convert.ToInt32(this.CodiceApparecchiature1.CodiceHidden.Value);
			
			_SColl.Add(s_EqId);

			S_Controls.Collections.S_Object s_p_id_piani = new S_Object();
			s_p_id_piani.ParameterName = "p_id_piani";
			s_p_id_piani.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_id_piani.Direction = ParameterDirection.InputOutput;
			s_p_id_piani.Size = 10;
			s_p_id_piani.Index = _SColl.Count;
			s_p_id_piani.Value=cmbsPiano.SelectedValue;
			
			_SColl.Add(s_p_id_piani);

		
			S_Controls.Collections.S_Object p_id_stanza = new S_Object();
			p_id_stanza.ParameterName = "p_id_stanza";
			p_id_stanza.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			p_id_stanza.Direction = ParameterDirection.Input;
			p_id_stanza.Index = _SColl.Count;
			if(UserStanze1.IdStanza!="")
				p_id_stanza.Value=Convert.ToInt32(UserStanze1.IdStanza);
			else
				p_id_stanza.Value=System.DBNull.Value;
			
			_SColl.Add(p_id_stanza);

			//			if(CmbProgetto.SelectedValue=="1")
			//			{
			S_Controls.Collections.S_Object s_p_causa = new S_Object();
			s_p_causa.ParameterName = "p_causa";
			s_p_causa.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_causa.Direction = ParameterDirection.Input;
			s_p_causa.Size = 408;
			s_p_causa.Index = _SColl.Count;
			s_p_causa.Value=TxtCausa.Text;
			_SColl.Add(s_p_causa);

			S_Controls.Collections.S_Object s_p_guasto = new S_Object();
			s_p_guasto.ParameterName = "p_guasto";
			s_p_guasto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_guasto.Direction = ParameterDirection.Input;
			s_p_guasto.Size = 408;
			s_p_guasto.Index = _SColl.Count;
			s_p_guasto.Value=TxtGuasto.Text;	
			_SColl.Add(s_p_guasto);

			S_Controls.Collections.S_Object s_p_tipointervento = new S_Object();
			s_p_tipointervento.ParameterName = "p_tipointervento";
			s_p_tipointervento.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_tipointervento.Direction = ParameterDirection.Input;
			s_p_tipointervento.Size = 10;
			s_p_tipointervento.Index = _SColl.Count;
			s_p_tipointervento.Value=Convert.ToInt32(cmbsTipoIntrevento.SelectedValue);	
			_SColl.Add(s_p_tipointervento);

			if (CmbProgetto.SelectedValue!="")
			{
				S_Controls.Collections.S_Object s_p_progetto = new S_Object();
				s_p_progetto.ParameterName = "p_progetto";
				s_p_progetto.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
				s_p_progetto.Direction = ParameterDirection.Input;
				s_p_progetto.Size = 10;
				s_p_progetto.Index = _SColl.Count;
				s_p_progetto.Value=Convert.ToInt32(CmbProgetto.SelectedValue);	
				_SColl.Add(s_p_progetto);
			}	
			

		
			S_Controls.Collections.S_Object s_p_tipomanutenzione = new S_Controls.Collections.S_Object();
			s_p_tipomanutenzione.ParameterName = "p_tipomanutenzione";
			s_p_tipomanutenzione.DbType = CustomDBType.Integer;
			s_p_tipomanutenzione.Direction = ParameterDirection.Input;
			s_p_tipomanutenzione.Index = _SColl.Count;
			s_p_tipomanutenzione.Value =int.Parse(cmbsTipoManutenzione.SelectedValue);  
			_SColl.Add(s_p_tipomanutenzione);
			//	}
			try
			{
				if (ItemId != 0)
					i_WrId = _Richiesta.ModificaRDL(_SColl,ItemId);
				else
					i_WrId = _Richiesta.Crea(_SColl);
			}
			catch (Exception ex)
			{
				this.PanelMess.ShowError("Errore: " + ex.Message, true);
			}
			return i_WrId;
		}
		#endregion

		#region eventiClickEChenged

		private void cmbsServizio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.CodiceApparecchiature1.Visible = false;
			this.BindApparecchiatura(this.RicercaModulo1.BlId);
		}

		private void cmbsApparecchiatura_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbsApparecchiatura.SelectedIndex== 0)
			{
				this.CodiceApparecchiature1.Visible = false;
			}
			else
			{
				this.CodiceApparecchiature1.Visible = true;
			}
			this.CodiceApparecchiature1.CodiceApparecchiatura="";
		}

		private void btnsChiudi_Click(object sender, System.EventArgs e)
		{
			if (ViewState["PAG"].ToString()=="SF")			
			{
		
				Server.Transfer("SfogliaRdlPaging.aspx");
			}
			else
			{
				Response.Redirect(ViewState["url"].ToString());
			
			}
		}

		private void btsCodice_Click(object sender, System.EventArgs e)
		{
			if (!GetVerificaAddetti(RicercaModulo1.TxtCodice.Text))
			{
				this.RicercaModulo1.TxtRicerca.Text = "";
				Classi.SiteJavaScript.msgBox(this.Page,"Nessun addetto per l'edificio selezionato");								
				return;
			} 
			else
			{
				  
				Classi.SiteJavaScript.ShowFrameReperibiliBL(Page,1);   
				if(txtBL_ID.Text =="")
					txtBL_ID.Text = RicercaModulo1.TxtCodice.Text;	
				string lancio = "";
				lancio =  "<script language=\"javascript\">\n";
				lancio += "ShowFrameRep('" + txtBL_ID.ClientID + "','bl_id',event);";
				lancio += "</script>\n";
	
				if(!this.IsStartupScriptRegistered("clientScriptReper"))
					this.RegisterStartupScript("clientScriptReper", lancio);
			}
		}

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("CreazioneSGA1.aspx?FunId=" + ViewState["FunId"]);
			 
		}

		#endregion
	
		#region CaricaRichiesteEsistenti
		private void lkbNonEmesse_Click(object sender, System.EventArgs e)
		{						 
			if (GetVerificaBL(RicercaModulo1.TxtCodice.Text)== "0")
			{
				this.lkbNonEmesse.Text = "Richieste non Emesse";
				this.LinkApprovate.Text = "Richieste Approvate";
				this.RicercaModulo1.TxtRicerca.Text = "";
				String scriptString = "<script language=JavaScript>alert(\"Nessuna richiesta per l'edificio selezionato\");";
				scriptString += "<";
				scriptString += "/";
				scriptString += "script>";

				if(!this.IsClientScriptBlockRegistered("clientScriptcalendario"))
					this.RegisterStartupScript ("clientScriptcalendario", scriptString);
				return;
			} 
			RicercaNonEmesse();
		}

		private void lnkChiudi_Click(object sender, System.EventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = 0;
			this.pnlShowInfo.Visible = false;
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			RicercaNonEmesse();
		}

		void RicercaNonEmesse()
		{
			string s_TestataScript = "<script language=\"javascript\">\n";
			string s_CodaScript = "</script>\n";
			Classi.ManCorrettiva.ClManCorrettiva  _Richiesta = new TheSite.Classi.ManCorrettiva.ClManCorrettiva(); 
			this.pnlShowInfo.Visible = true;

			DataSet _MyDs = _Richiesta.GetRDLNonEmesse(this.RicercaModulo1.TxtCodice.Text );
			DataGridRicerca.DataSource =  _MyDs.Tables[0];

			if (_MyDs.Tables[0].Rows.Count == 0 )
			{
				DataGridRicerca.CurrentPageIndex=0;
			}
			else
			{
				int Pagina = 0;
				if ((_MyDs.Tables[0].Rows.Count % DataGridRicerca.PageSize) >0)
				{
					Pagina ++;
				}
				if (DataGridRicerca.PageCount != Convert.ToInt16((_MyDs.Tables[0].Rows.Count / DataGridRicerca.PageSize) + Pagina))
				{					
					DataGridRicerca.CurrentPageIndex=0;					
				}
			}

			DataGridRicerca.DataBind();
			

			string xx =s_TestataScript + "DivSetVisible(true);"+s_CodaScript;
			this.Page.RegisterStartupScript("ss",xx);
		}

		private void LinkApprovate_Click(object sender, System.EventArgs e)
		{
			if (GetVerificaBL(RicercaModulo1.TxtCodice.Text)== "0")
			{
				this.lkbNonEmesse.Text = "Richieste non Emesse";
				this.LinkApprovate.Text = "Richieste Approvate";
				this.RicercaModulo1.TxtRicerca.Text = "";
				String scriptString = "<script language=JavaScript>alert(\"Nessuna richiesta per l'edificio selezionato\");";
				scriptString += "<";
				scriptString += "/";
				scriptString += "script>";

				if(!this.IsClientScriptBlockRegistered("clientScriptcalendario"))
					this.RegisterStartupScript ("clientScriptcalendario", scriptString);
				return;
			} 
			RicercaApprovate();
		}

		private void LinkChiudi2_Click(object sender, System.EventArgs e)
		{
			DatagridEmesse.CurrentPageIndex = 0;
			this.PanelEmesse.Visible = false;
		}
		void RicercaApprovate()
		{
			
			string s_TestataScript = "<script language=\"javascript\">\n";
			string s_CodaScript = "</script>\n";
			Classi.ManCorrettiva.ClManCorrettiva  _Richiesta = new TheSite.Classi.ManCorrettiva.ClManCorrettiva(); 
			this.PanelEmesse.Visible = true;

			DataSet _MyDs = _Richiesta.GetRDLApprovate(this.RicercaModulo1.TxtCodice.Text);
			DatagridEmesse.DataSource =  _MyDs.Tables[0];

			if (_MyDs.Tables[0].Rows.Count == 0 )
			{
				DatagridEmesse.CurrentPageIndex=0;
			}
			else
			{
				int Pagina = 0;
				if ((_MyDs.Tables[0].Rows.Count % DatagridEmesse.PageSize) >0)
				{
					Pagina ++;
				}
				if (DatagridEmesse.PageCount != Convert.ToInt16((_MyDs.Tables[0].Rows.Count / DatagridEmesse.PageSize) + Pagina))
				{					
					DatagridEmesse.CurrentPageIndex=0;					
				}
			}
			DatagridEmesse.DataBind();
			

			string xx =s_TestataScript + "EmesseSetVisible(true);"+s_CodaScript;
			this.Page.RegisterStartupScript("ss",xx);
		}

		private void DatagridEmesse_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatagridEmesse.CurrentPageIndex = e.NewPageIndex;			
			RicercaApprovate();
		}

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="NonEmesse")
			{								
				string s_url = e.CommandArgument.ToString();		
				Server.Transfer(s_url);	
							
			}
		}

		private void DatagridEmesse_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Emesse")
			{								
				string s_url = e.CommandArgument.ToString();		
				Server.Transfer(s_url);	
							
			}
		}

		string GetNumeroNonEmesse(string _bl_id)
		{
			string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];

			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_sql = new S_Controls.Collections.S_Object();
			s_p_sql.ParameterName = "p_sql";
			s_p_sql.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_sql.Direction = ParameterDirection.Input;
			s_p_sql.Size =2000;
			s_p_sql.Index = 0;
			s_p_sql.Value = " Select count(wr.wr_id) from  wr where wr.bl_id = '" + _bl_id + "' and wr.id_wr_status in (1,15) and (wr.tipomanutenzione_id = 1 or wr.tipomanutenzione_id = 3)";
			_SCollection.Add(s_p_sql);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SCollection.Add(s_Cursor);

				
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new ApplicationDataLayer.OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_DYNAMIC_SELECT";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds.Tables[0].Rows[0][0].ToString();		
		}

		string GetNumeroApprovate(string _bl_id)
		{
			string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];

			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_sql = new S_Controls.Collections.S_Object();
			s_p_sql.ParameterName = "p_sql";
			s_p_sql.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_sql.Direction = ParameterDirection.Input;
			s_p_sql.Size =2000;
			s_p_sql.Index = 0;
			s_p_sql.Value = " Select count(wr.wr_id) from  wr where wr.bl_id = '" + _bl_id + "' and wr.id_wr_status not in (1,15) and (wr.tipomanutenzione_id = 1 or wr.tipomanutenzione_id = 3) ";
			_SCollection.Add(s_p_sql);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SCollection.Add(s_Cursor);

				
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new ApplicationDataLayer.OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_DYNAMIC_SELECT";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds.Tables[0].Rows[0][0].ToString();		
		}
		#endregion

		#region VerificaEsistenzaBL
		string GetVerificaBL(string _bl_id)
		{
			string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];

			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_sql = new S_Controls.Collections.S_Object();
			s_p_sql.ParameterName = "p_sql";
			s_p_sql.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_sql.Direction = ParameterDirection.Input;
			s_p_sql.Size =2000;
			s_p_sql.Index = 0;
			string sql="select count(wr.bl_id) from  wr where wr.bl_id = '" + _bl_id + "'";
			s_p_sql.Value =sql; 
			_SCollection.Add(s_p_sql);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SCollection.Add(s_Cursor);

				
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new ApplicationDataLayer.OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_DYNAMIC_SELECT";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds.Tables[0].Rows[0][0].ToString();		
		}

		#endregion

		#region VerificaAddetti
		bool GetVerificaAddetti(string _bl_id)
		{
			///Istanzio la Classe per eseguire la Strore Procedure
			Classi.ClassiAnagrafiche.Reperibilita  _Reperibilita = new TheSite.Classi.ClassiAnagrafiche.Reperibilita();

			///Eseguo il Binding sulla Griglia.
			DataSet _Ds =_Reperibilita.GetAddettiDistinct(_bl_id);

			if (_Ds.Tables[0].Rows.Count == 0)
				return false;		
			else
				return true;
		}
		
		#endregion

		#region CaricaDatiCreazione
		private void LoadDatiCreazione(int ItemId)
		{
			AslMobile.Class.ClassRDL _Richiesta = new AslMobile.Class.ClassRDL(HttpContext.Current.User.ToString());
			DataSet _Ds= _Richiesta.GetSingleRdl(ItemId);
			if (_Ds.Tables[0].Rows.Count>0)
			{	
				DataRow _Dr = _Ds.Tables[0].Rows[0];
			
					
				Classi.SiteJavaScript.ShowFrameReperibiliBL(Page,1);   

				
				if (_Dr["id_progetto"] != DBNull.Value)
					CmbProgetto.SelectedValue=_Dr["id_progetto"].ToString();

				//				string Aseguito = "";
				//				Aseguito =  "<script language=\"javascript\">\n";
				//				Aseguito += "NascondiASeguito('" + _Dr["id_progetto"].ToString() + "');";
				//				Aseguito += "</script>\n";


				if (_Dr["tipomanutenzione_id"] != DBNull.Value)
				{
					LoadTipoManutenzione();
					cmbsTipoManutenzione.SelectedValue=_Dr["tipomanutenzione_id"].ToString();
				}
				if(_Dr["sga_anomalia"].ToString().Trim()!="")
				{
					TxtCausa.Text =_Dr["sga_anomalia"].ToString();
				}

				if(_Dr["sga_effetto"].ToString().Trim()!="")
				{
					TxtGuasto.Text =_Dr["sga_effetto"].ToString();
				}

				if(_Dr["tipointervento"].ToString()!="")
				{
					LoadTipoIntervento();
					cmbsTipoIntrevento.SelectedValue =_Dr["tipointervento"].ToString();
				}

				if(_Dr["date_requested"].ToString().Trim()!="")
				{
					System.DateTime OraIni= System.DateTime.Parse(_Dr["date_requested"].ToString());
					txtsorain.Text =OraIni.Hour.ToString().PadLeft(2,Convert.ToChar("0"))  ;
					txtsorainmin.Text =OraIni.Minute.ToString().PadLeft(2,Convert.ToChar("0")) ;
					CalendarPicker1.Datazione.Text = OraIni.ToShortDateString();
				}

				if (_Dr["nota"].ToString().Trim()!="")
				{
					txtsNota.Text=_Dr["nota"].ToString();
				}
				else
				{ txtsNota.Text=string.Empty;}
				
				///Dati Edificio//
				if(_Dr["id_bl"].ToString().Trim()!="")
				{
					RicercaModulo1.TxtCodice.Text=_Dr["bl_id"].ToString();
					RicercaModulo1.TxtRicerca.Text= _Dr["fabbricato"].ToString();
					RicercaModulo1.LbLIdBL.Text=_Dr["bl_id"].ToString();
					RicercaModulo1._txthidbl.Value=_Dr["id_bl"].ToString();	
					//BindPiano(_Dr["id_bl"].ToString().Trim());
				}
				///////////////////////////////////
				///				

				if (_Dr["id_piani"].ToString().Trim()!="")
				{
					cmbsPiano.SelectedValue=_Dr["id_piani"].ToString();
				}
				else
				{
					cmbsPiano.SelectedValue="";
				}						

				 
				if (_Dr["telefono"].ToString().Trim()!="")
				{
					txtsTelefonoRichiedente.Text=_Dr["telefono"].ToString();
				}
				else
				{ txtsTelefonoRichiedente.Text=string.Empty;}

				if (_Dr["idstanza"].ToString().Trim()!="")
				{
					UserStanze1.IdStanza=_Dr["idstanza"].ToString();
				}
				else
				{
					UserStanze1.IdStanza="";
				}

				if (_Dr["descstanza"].ToString().Trim()!="" && _Dr["descstanza"].ToString().Trim()!="-")
				{
					UserStanze1.DescStanza=_Dr["descstanza"].ToString();
				}
				else
				{
					UserStanze1.DescStanza="";
				}
				
			
				///Dati Richiedente///
					
				if(_Dr["name_first"].ToString().Trim()!="")
				{						
					RichiedentiSollecito1.s_RichNome.Text=_Dr["name_first"].ToString();					
				}

				if(_Dr["name_last"].ToString().Trim()!="")
				{						
					RichiedentiSollecito1.s_RichCognome.Text=_Dr["name_last"].ToString();					
				}

				if(_Dr["em_phone"].ToString().Trim()!="")
				{						
					RichiedentiSollecito1.s_telefono.Text=_Dr["em_phone"].ToString();
				}
					
				if(_Dr["em_email"].ToString().Trim()!="")
				{						
					RichiedentiSollecito1.s_email.Text=_Dr["em_email"].ToString();
				}
				
				if(_Dr["em_stanza"].ToString().Trim()!="")
				{						
					RichiedentiSollecito1.s_stanza.Text=_Dr["em_stanza"].ToString();
				}
				if(_Dr["em_idgruppo"].ToString().Trim()!="")
				{						
					RichiedentiSollecito1.s_RichGruppo.SelectedValue=_Dr["em_idgruppo"].ToString();
				}
				//////////////////////////////////
				this.BindServizio(RicercaModulo1.TxtCodice.Text);						
				if(_Dr["servizio_id"].ToString().Trim()!="")
				{						
					cmbsServizio.SelectedValue=_Dr["servizio_id"].ToString();
				}
				else
				{
					cmbsServizio.SelectedValue="0";
				}
				this.BindApparecchiatura(RicercaModulo1.TxtCodice.Text);	
			
				if (_Dr["eqstd_id"].ToString().Trim()!="")
				{
					cmbsApparecchiatura.SelectedValue=_Dr["eqstd_id"].ToString();
					//recupero il code apparecchiatura
					if (_Dr["desceq"].ToString().Trim()!="")
					{
						CodiceApparecchiature1.Visible=true;
						CodiceApparecchiature1.s_CodiceApparecchiatura.Text=_Dr["desceq"].ToString();
						CodiceApparecchiature1.CodiceHidden.Value=_Dr["ideq"].ToString();
					}
				}
				else
				{
					cmbsApparecchiatura.SelectedValue="0";
				}
								
				BindControls(_Dr["id_bl"].ToString());
				if (_Dr["urgenza_id"].ToString().Trim()!="")
				{
					cmbsUrgenza.SelectedValue=_Dr["urgenza_id"].ToString();
				}
				else
				{
					cmbsUrgenza.SelectedValue="";
				}

				if (_Dr["descrizione"].ToString().Trim()!="")
				{
					txtsProblema.Text=_Dr["descrizione"].ToString();
				}
				else
					txtsProblema.Text=string.Empty;
			}
		}
		#endregion
		
	}
		
}

