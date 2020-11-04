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

namespace TheSite.ManutenzioneCorretiva
{
	/// <summary>
	/// Descrizione di riepilogo per CreazioneRdl.
	/// </summary>
	public class CreazioneRdl : System.Web.UI.Page
	{
		protected S_Controls.S_Button btnsSalva;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected S_Controls.S_ComboBox cmbsUrgenza;		
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_TextBox txtsTelefonoRichiedente;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected S_Controls.S_TextBox txtsNote;
	//	protected S_Controls.S_TextBox txtsOraRichiesta;
		protected System.Web.UI.WebControls.TextBox txtsMittente;
		protected WebControls.PageTitle PageTitle1;
		protected WebControls.CodiceApparecchiature CodiceApparecchiature1; 
		protected S_Controls.S_ComboBox cmbsApparecchiatura;
		protected S_Controls.S_TextBox txtsNota;
		protected S_Controls.S_TextBox txtsProblema;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvOraRichiesta;
		protected System.Web.UI.WebControls.Panel PanelRichiedente;
		protected System.Web.UI.WebControls.Panel PanelServizio;
		protected System.Web.UI.WebControls.CheckBox chksSendMail;
		protected System.Web.UI.WebControls.Panel PanelProblema;

		public static int FunId = 0;	
		public static IDictionaryEnumerator myEnumerator=null;
		protected System.Web.UI.WebControls.Panel pnlShowInfo;
		protected System.Web.UI.WebControls.LinkButton lkbNonEmesse;
		protected System.Web.UI.WebControls.LinkButton lnkChiudi;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected System.Web.UI.WebControls.LinkButton LinkApprovate;
		protected System.Web.UI.WebControls.LinkButton LinkChiudi2;
		protected System.Web.UI.WebControls.DataGrid DatagridEmesse;
		protected System.Web.UI.WebControls.Panel PanelEmesse;				
		public static string HelpLink = string.Empty;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvEdificio;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected System.Web.UI.WebControls.TextBox txtBL_ID;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvRichiedenteNome;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvRichiedenteCognome;
		protected System.Web.UI.WebControls.Button btsCodice;
		protected S_Controls.S_TextBox txtsstanza;
		protected System.Web.UI.WebControls.RequiredFieldValidator RqFVstanza;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected S_Controls.S_ComboBox cmbsPiano;
		protected S_Controls.S_ComboBox cmbsSettore;
		protected WebControls.CalendarPicker CalendarPicker1;

		//*****************
		
		protected WebControls.RichiedentiSollecito RichiedentiSollecito1;
		protected System.Web.UI.WebControls.TextBox txtsorain;
		protected System.Web.UI.WebControls.TextBox txtsorainmin;
		protected System.Web.UI.WebControls.DropDownList CmbProgetto;
		protected System.Web.UI.WebControls.Label lblProgetto;		
		protected WebControls.UserStanze UserStanze1;
		//aggiunta SGA
		protected S_Controls.S_ComboBox cmbsTipoIntrevento;
		protected S_Controls.S_ComboBox CmbASeguito;
		protected System.Web.UI.WebControls.Label lblAseguito1;
		protected System.Web.UI.WebControls.TextBox TxtOraAseguito;
		protected System.Web.UI.WebControls.TextBox TxtMinAseguito;
		protected S_Controls.S_TextBox TxtASeguito1;
		protected System.Web.UI.WebControls.Label lblAseguito2;
		protected S_Controls.S_TextBox TxtASeguito2;
		protected S_Controls.S_TextBox TxtASeguito4;
		Classi.ManCorrettiva.ClManCorrettiva _ClManCorrettiva;
		protected WebControls.CalendarPicker CalendarPickerASeguito3;
		protected WebControls.CalendarPicker CalendarPickerASeguito2;
		protected S_Controls.S_TextBox TxtCausa;
		protected S_Controls.S_TextBox TxtGuasto;
		protected WebControls.CalendarPicker CalendarPickerASeguito1;		
		//
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			// ***********************  MODIFICA PER I PERMESSI SULLA PAGINA CORRENTE **********************
			//Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];			
			string _mypage="./ManutenzioneCorrettiva/CreazioneRdl.aspx";			
			Classi.SiteModule _SiteModule = new TheSite.Classi.SiteModule(_mypage);
			// ***********************  MODIFICA PER I PERMESSI SULLA PAGINA CORRENTE **********************

			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			this.btnsSalva.Visible = _SiteModule.IsEditable;	
			
			this.RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);
			this.RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindApparecchiatura);
			this.RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.ValorizzaReperibilita);
			this.RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindMail);
			this.RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindPiano);			

			this.CodiceApparecchiature1.NameComboApparecchiature ="cmbsApparecchiatura";
			/// Imposto il nome della combo Servizio
			this.CodiceApparecchiature1.NameComboServizio ="cmbsServizio";
			/// Imposto il nome dell'user control RicercaModulo
			this.CodiceApparecchiature1.NameUserControlRicercaModulo  ="RicercaModulo1";
			/// Imposto il nome della cobmbo del piano
			this.CodiceApparecchiature1.NameComboPiano  ="cmbsPiano";
			/// Imposto il nome della combo della stanza
	//		this.CodiceApparecchiature1.NameComboStanza  ="cmbsStanza";

			UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
			UserStanze1.NameComboPiano="cmbsPiano";

			//Aggiunta controlli all'ora
			txtsorain.Attributes.Add("onkeypress","SoloNumeri();");
			txtsorain.Attributes.Add("onpaste","return false;");
			txtsorain.Attributes.Add("maxlength","2");			
			txtsorain.Attributes.Add("onblur","return ControllaOra();");

			txtsorainmin.Attributes.Add("onkeypress","SoloNumeri();");
			txtsorainmin.Attributes.Add("onpaste","return false;");
			txtsorainmin.Attributes.Add("onblur","return ControllaMin();");
			txtsorainmin.Attributes.Add("maxlength","2");
			//

			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsApparecchiatura.ClientID + "').disabled = true;");
			this.cmbsServizio.Attributes.Add("onchange", sbValid.ToString());

			sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsServizio.ClientID + "').disabled = true;");
			this.cmbsApparecchiatura.Attributes.Add("onchange", sbValid.ToString());
			CmbProgetto.Attributes.Add("onchange","setProg();"); 
            
			chksSendMail.Attributes.Add("onclick","visibletextmail('" + chksSendMail.ClientID + "','" + txtsMittente.ClientID  + "')");  
			txtsMittente.Enabled =chksSendMail.Checked;

			//aggiunta SGA mdi
		
			TxtOraAseguito.Attributes.Add("onkeypress","SoloNumeri();");
			TxtOraAseguito.Attributes.Add("onpaste","return false;");
			TxtOraAseguito.Attributes.Add("maxlength","2");			
			TxtOraAseguito.Attributes.Add("onblur","return ControllaOra();");

			TxtMinAseguito.Attributes.Add("onkeypress","SoloNumeri();");
			TxtMinAseguito.Attributes.Add("onpaste","return false;");
			TxtMinAseguito.Attributes.Add("onblur","return ControllaMin();");
			TxtMinAseguito.Attributes.Add("maxlength","2");

			//fine aggiunta

			if (!Page.IsPostBack)
			{				
			
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];

				this.LinkApprovate.Attributes.Add("onclick","return ControllaBL('" + RicercaModulo1.TxtCodice.ClientID + "')");
				this.lkbNonEmesse.Attributes.Add("onclick","return ControllaBL('" + RicercaModulo1.TxtCodice.ClientID + "')");

				//mau
				this.btsCodice.CausesValidation = false;
				this.btsCodice.Attributes.Add("onclick","return ControllaBL('" + RicercaModulo1.TxtCodice.ClientID + "');");
												
				rfvRichiedenteNome.ControlToValidate= RichiedentiSollecito1.ID + ":" +RichiedentiSollecito1.s_RichNome.ID;
				rfvRichiedenteCognome.ControlToValidate= RichiedentiSollecito1.ID + ":" + RichiedentiSollecito1.s_RichCognome.ID;
				rfvEdificio.ControlToValidate= RicercaModulo1.ID + ":" + RicercaModulo1.TxtCodice.ID;
		
				this.BindPiano("");							
				this.BindApparecchiatura(string.Empty);				
				this.BindServizio(RicercaModulo1.TxtCodice.Text);						
				this.BindControls();	

				//Modifidica Momentanea per CallCenter poi eliminare le righe sottostanti
				this.RicercaModulo1.TxtCodice.Text="";
				BindPiano("");
				cmbsPiano.SelectedValue="";
				//Modifidica Momentanea per CallCenter poi eliminare le righe soprastanti

				cmbsPiano.Attributes.Add("onchange","clearRoom();");

				//Imposto data e ora correnti
				CalendarPicker1.Datazione.Text = DateTime.Now.ToShortDateString();
				txtsorain.Text= Convert.ToString(DateTime.Now.Hour).PadLeft(2,'0');
                txtsorainmin.Text= Convert.ToString(DateTime.Now.Minute).PadLeft(2,'0');

				this.CodiceApparecchiature1.Visible = false;		
				this.CodiceApparecchiature1.s_CodiceApparecchiatura.ReadOnly =  true;
				BindProgetti();

				//aggiunta SGA MDI
				LoadTipoIntervento();
				LoadASeguito();
				//fine aggiunta

     
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
			this.lkbNonEmesse.Click += new System.EventHandler(this.lkbNonEmesse_Click);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.LinkApprovate.Click += new System.EventHandler(this.LinkApprovate_Click);
			this.LinkChiudi2.Click += new System.EventHandler(this.LinkChiudi2_Click);
			this.DatagridEmesse.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatagridEmesse_ItemCommand);
			this.DatagridEmesse.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatagridEmesse_PageIndexChanged);
			this.btsCodice.Click += new System.EventHandler(this.btsCodice_Click);
			this.cmbsServizio.SelectedIndexChanged += new System.EventHandler(this.cmbsServizio_SelectedIndexChanged);
			this.cmbsApparecchiatura.SelectedIndexChanged += new System.EventHandler(this.cmbsApparecchiatura_SelectedIndexChanged);
			this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
			this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//aggiunta SGA MDI

		private void LoadASeguito()
		{
			_ClManCorrettiva=new TheSite.Classi.ManCorrettiva.ClManCorrettiva(Context.User.Identity.Name);

			CmbASeguito.Items.Clear();

			DataSet _MyDs;
			_MyDs = _ClManCorrettiva.GetAseguito();
			

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.CmbASeguito.DataSource =Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0],"descrizione","id","-Selezionare un valore-","0");
				this.CmbASeguito.DataTextField = "descrizione";
				this.CmbASeguito.DataValueField = "id";
				this.CmbASeguito.DataBind();
			    this.CmbASeguito.Attributes.Add("OnChange","VisualizzaASeguito(this.value);");

			}
			else
			{
				string s_Messagggio = "- Nessun dato -";
				this.CmbASeguito.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
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

		//fine aggiunta
	
		private void BindProgetti()
		{
			
			this.CmbProgetto.Items.Clear();
		
			TheSite.Classi.Progetti _Prog = new TheSite.Classi.Progetti();
						
			DataSet _MyDs = _Prog.GetData();			
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.CmbProgetto.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "id_progetto", "- Selezionare un Progetto -", "0");				
				this.CmbProgetto.DataTextField ="descrizione";
				this.CmbProgetto.DataValueField  ="id_progetto";
				this.CmbProgetto.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Progetto  -";
				this.CmbProgetto.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
						
			}			

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
				}
				if (!Context.User.IsInRole("MA") && Context.User.IsInRole("PA"))
				{
					CmbProgetto.SelectedValue="2";
					RichiedentiSollecito1.Progetto="2"; 
				}
				if (Context.User.IsInRole("AMMINISTRATORI") )
				{
					CmbProgetto.Visible =true;
					lblProgetto.Visible =true;
				}

			}

		}
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
					
					Response.Redirect("VisualizzaRdl.aspx?FunId=" + FunId + "&ItemId=" + i_Wr_Id.ToString());
				}
			}
			else
			{
				this.PanelMess.ShowError("Impossibile inserire una richiesta per l'edificio indicato", true);
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
	
		private int NuovaRichiesta()
		{
			int i_WrId = 0;

			this.txtsProblema.DBDefaultValue = DBNull.Value;
			this.txtsNota.DBDefaultValue = DBNull.Value;
			this.txtsTelefonoRichiedente.DBDefaultValue = DBNull.Value;
			
		
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

			_SColl.AddItems(this.PanelServizio.Controls);
			_SColl.AddItems(this.PanelProblema.Controls);

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

			S_Controls.Collections.S_Object s_p_aseguito1 = new S_Object();
			s_p_aseguito1.ParameterName = "p_aseguito1";
			s_p_aseguito1.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_aseguito1.Direction = ParameterDirection.Input;
			s_p_aseguito1.Size = 100;
			s_p_aseguito1.Index = _SColl.Count;
			if(CmbASeguito.SelectedValue=="1")
				s_p_aseguito1.Value=CalendarPickerASeguito1.Datazione.Text;	
			else
				s_p_aseguito1.Value=TxtASeguito1.Text;

			_SColl.Add(s_p_aseguito1);

			S_Controls.Collections.S_Object s_p_aseguito2 = new S_Object();
			s_p_aseguito2.ParameterName = "p_aseguito2";
			s_p_aseguito2.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_aseguito2.Direction = ParameterDirection.Input;
			s_p_aseguito2.Size = 100;
			s_p_aseguito2.Index = _SColl.Count;
			if(CmbASeguito.SelectedValue=="1")
				s_p_aseguito2.Value=TxtOraAseguito.Text+ ":" +TxtMinAseguito.Text+ ":00" ;	
			else
				s_p_aseguito2.Value=CalendarPickerASeguito2.Datazione.Text;	

			_SColl.Add(s_p_aseguito2);

			S_Controls.Collections.S_Object s_p_aseguito3 = new S_Object();
			s_p_aseguito3.ParameterName = "p_aseguito3";
			s_p_aseguito3.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_aseguito3.Direction = ParameterDirection.Input;
			s_p_aseguito3.Size = 100;
			s_p_aseguito3.Index = _SColl.Count;
			if(CmbASeguito.SelectedValue!="5")
				s_p_aseguito3.Value="";	
			else
				s_p_aseguito3.Value=CalendarPickerASeguito3.Datazione.Text;	

			_SColl.Add(s_p_aseguito3);

			S_Controls.Collections.S_Object s_p_aseguito4 = new S_Object();
			s_p_aseguito4.ParameterName = "p_aseguito4";
			s_p_aseguito4.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_aseguito4.Direction = ParameterDirection.Input;
			s_p_aseguito4.Size = 100;
			s_p_aseguito4.Index = _SColl.Count;
			if(CmbASeguito.SelectedValue!="5")
				s_p_aseguito4.Value="";	
			else
				s_p_aseguito4.Value=TxtASeguito4.Text;	

			_SColl.Add(s_p_aseguito4);

			S_Controls.Collections.S_Object s_p_causa = new S_Object();
			s_p_causa.ParameterName = "p_causa";
			s_p_causa.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_causa.Direction = ParameterDirection.Input;
			s_p_causa.Size = 100;
			s_p_causa.Index = _SColl.Count;
			s_p_causa.Value=TxtCausa.Text;
			_SColl.Add(s_p_causa);

			S_Controls.Collections.S_Object s_p_guasto = new S_Object();
			s_p_guasto.ParameterName = "p_guasto";
			s_p_guasto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_guasto.Direction = ParameterDirection.Input;
			s_p_guasto.Size = 100;
			s_p_guasto.Index = _SColl.Count;
			s_p_guasto.Value=TxtGuasto.Text;	
			_SColl.Add(s_p_guasto);

			S_Controls.Collections.S_Object s_p_id_sga_seguito = new S_Object();
			s_p_id_sga_seguito.ParameterName = "p_id_sga_seguito";
			s_p_id_sga_seguito.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_id_sga_seguito.Direction = ParameterDirection.Input;
			s_p_id_sga_seguito.Size = 10;
			s_p_id_sga_seguito.Index = _SColl.Count;
			s_p_id_sga_seguito.Value=Convert.ToInt32(CmbASeguito.SelectedValue);	
			_SColl.Add(s_p_id_sga_seguito);

			S_Controls.Collections.S_Object s_p_tipointervento = new S_Object();
			s_p_tipointervento.ParameterName = "p_tipointervento";
			s_p_tipointervento.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_tipointervento.Direction = ParameterDirection.Input;
			s_p_tipointervento.Size = 10;
			s_p_tipointervento.Index = _SColl.Count;
			s_p_tipointervento.Value=Convert.ToInt32(cmbsTipoIntrevento.SelectedValue);	
			_SColl.Add(s_p_tipointervento);
			
			try
			{
				i_WrId = _Richiesta.Crea(_SColl);
			}
			catch (Exception ex)
			{
				this.PanelMess.ShowError("Errore: " + ex.Message, true);
			}
			return i_WrId;
		}




	

		private void ValorizzaReperibilita(string CodEdificio)
		{
			if (GetVerificaAddetti(CodEdificio))
			
				txtBL_ID.Text = CodEdificio;
		}

		private void BindControls()
		{
			Classi.ClassiDettaglio.Urgenza _Urgenza = new TheSite.Classi.ClassiDettaglio.Urgenza();
			Classi.ClassiDettaglio.RichiedentiTipo _RichiedentiTipo = new TheSite.Classi.ClassiDettaglio.RichiedentiTipo();
			this.cmbsUrgenza.DataSource = _Urgenza.GetData();
			this.cmbsUrgenza.DataTextField = "PRIORITY";
			this.cmbsUrgenza.DataValueField = "ID";
			this.cmbsUrgenza.DataBind();
			this.cmbsUrgenza.SelectedValue = "4";

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
					
				string lancio = "";
				lancio =  "<script language=\"javascript\">\n";
				lancio += "ShowFrameRep('" + txtBL_ID.ClientID + "','bl_id',event);";
				lancio += "</script>\n";
	
				if(!this.IsStartupScriptRegistered("clientScriptReper"))
					this.RegisterStartupScript("clientScriptReper", lancio);
			}
		}

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

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("CreazioneRdl.aspx?FunId=" + ViewState["FunId"]);
			 
		}

	
	}
}
