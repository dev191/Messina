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
	public class CreazioneRdl : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected S_Controls.S_Button btnsSalva;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected S_Controls.S_ComboBox cmbsUrgenza;		
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_TextBox txtsTelefonoRichiedente;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected S_Controls.S_TextBox txtsNote;
		protected S_Controls.S_TextBox txtsDataRichiesta;
		protected S_Controls.S_TextBox txtsOraRichiesta;
		protected System.Web.UI.WebControls.TextBox txtsMittente;
		protected WebControls.PageTitle PageTitle1;
		protected WebControls.CodiceApparecchiature CodiceApparecchiature1; 
		protected S_Controls.S_ComboBox cmbsApparecchiatura;
		protected S_Controls.S_TextBox txtsNota;
		protected S_Controls.S_TextBox txtsProblema;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDataRichiesta;
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
		//*****************
		
		protected WebControls.RichiedentiSollecito RichiedentiSollecito1;		
		protected WebControls.UserStanze UserStanze1;


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


			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsApparecchiatura.ClientID + "').disabled = true;");
			this.cmbsServizio.Attributes.Add("onchange", sbValid.ToString());

			sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsServizio.ClientID + "').disabled = true;");
			this.cmbsApparecchiatura.Attributes.Add("onchange", sbValid.ToString());

            
			chksSendMail.Attributes.Add("onclick","visibletextmail('" + chksSendMail.ClientID + "','" + txtsMittente.ClientID  + "')");  
			
			txtsMittente.Enabled =chksSendMail.Checked;
			

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
				//this.RicercaModulo1.Ricarica();
				BindPiano("");
				cmbsPiano.SelectedValue="";
				//Modifidica Momentanea per CallCenter poi eliminare le righe soprastanti

				cmbsPiano.Attributes.Add("onchange","clearRoom();");
				//this.BindStanza();	
				this.txtsDataRichiesta.Text = DateTime.Now.ToShortDateString();
				this.txtsOraRichiesta.Text = DateTime.Now.ToShortTimeString();
				this.CodiceApparecchiature1.Visible = false;		
				this.CodiceApparecchiature1.s_CodiceApparecchiatura.ReadOnly =  true;

				/*cmbsPiano.Enabled=false;
				cmbsStanza.Enabled=false;
				cmbsServizio.Enabled=false;
				cmbsApparecchiatura.Enabled=false;
				*/
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
				
					#region invio email
//					if (txtsMittente.Text!="" && chksSendMail.Checked==true )
//					{
//						string[] indirizzi= txtsMittente.Text.Split(Convert.ToChar(";"));   
//						Classi.ClassMail _mail=new TheSite.Classi.ClassMail();
//						try
//						{
//							foreach(string indirizzo in indirizzi)
//							{
//								System.Web.Mail.MailMessage _messaggio=new System.Web.Mail.MailMessage();
//								_messaggio.From =System.Configuration.ConfigurationSettings.AppSettings["MailFrom"];
//								_messaggio.Subject="Avviso di creazione di una richiesta di lavoro."; 
//								_messaggio.To =indirizzo.Trim();
//							    
//								_messaggio.BodyFormat =MailFormat.Html; 
//								_mail.Messaggio =_messaggio;
//								_mail.Idrichiesta =i_Wr_Id.ToString();
//								_mail.Name =indirizzo.Trim();
//								_mail.Decription=txtsProblema.Text;
//								_mail.CodiceEdificio =RicercaModulo1.BlId + " " + RicercaModulo1.Nome
//									+ " Comune: " + RicercaModulo1.Comune;
//								//_mail.Surname =indirizzo;
//								_mail.SendMail(Classi.ClassMail.TipoMail.MailCreazioneRichiesta); 
//							} 
//						}
//						catch (Exception ex)
//						{
//							Console.WriteLine(ex.Message);
//						}
//					}
					#endregion
					if (txtsMittente.Text!="")
					{
						string[] indirizzi1= txtsMittente.Text.Split(Convert.ToChar(";"));					
						Classi.ClassMail _mail1=new TheSite.Classi.ClassMail();
						try
						{
							foreach(string indirizzo1 in indirizzi1)
							{
								if(indirizzo1=="") continue;
								try
								{
									System.Web.Mail.MailMessage _messaggio1=new System.Web.Mail.MailMessage();
									_messaggio1.From =System.Configuration.ConfigurationSettings.AppSettings["MailFrom"];
									_messaggio1.Subject="Avviso di creazione di una richiesta di lavoro N° " +i_Wr_Id.ToString() + " Edificio: " + RicercaModulo1.BlId; 
									_messaggio1.To =indirizzo1.Trim();
							    
									_messaggio1.BodyFormat =MailFormat.Html; 
									_mail1.Messaggio =_messaggio1;
									_mail1.Idrichiesta =i_Wr_Id.ToString();
									_mail1.Name =indirizzo1.Trim();
									_mail1.Decription=txtsProblema.Text;							
									
									_mail1.CodiceEdificio =RicercaModulo1.BlId + " Nome " + RicercaModulo1.Nome + " Comune:  "+ RicercaModulo1.Comune ;
									_mail1.Richiedente=RichiedentiSollecito1.CognomeCompleto+ " " +													RichiedentiSollecito1.NomeCompleto;
									//_mail1.Surname =indirizzo;
									_mail1.SendMail(Classi.ClassMail.TipoMail.MailCreazioneRichiesta); 
																	
								
								}
								catch(Exception ex)
								{
									Console.WriteLine(ex.Message);
								}
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
			//this.cmbsStanza.Enabled=false;

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
//			cmbsStanza.Attributes.Add("OnChange","ClearApparechiature();");
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
			
			this.txtsDataRichiesta.Text = DateTime.Now.ToShortDateString();
			this.txtsOraRichiesta.Text = DateTime.Now.ToShortTimeString();
			
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
			//s_p_Gruppo.Value = (cmbsGruppo.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsGruppo.SelectedValue);			
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

//			S_Controls.Collections.S_Object p_rm_id = new S_Object();
//			p_rm_id.ParameterName = "p_rm_id";
//			p_rm_id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
//			p_rm_id.Direction = ParameterDirection.InputOutput;
//			p_rm_id.Size = 8;
//			p_rm_id.Index = _SColl.Count;
//			p_rm_id.Value=txtsstanza.Text;
//			
//			_SColl.Add(p_rm_id);

			
			S_Controls.Collections.S_Object p_id_stanza = new S_Object();
			p_id_stanza.ParameterName = "p_id_stanza";
			p_id_stanza.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			p_id_stanza.Direction = ParameterDirection.Input;
			p_id_stanza.Index = _SColl.Count;
			if(UserStanze1.IdStanza!="")
				p_id_stanza.Value=Convert.ToInt32(UserStanze1.IdStanza);//cmbsStanza.SelectedValue;
			else
				p_id_stanza.Value=System.DBNull.Value;
			
			_SColl.Add(p_id_stanza);

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
			{

				txtBL_ID.Text = CodEdificio;//this.RicercaModulo1.Idbl;//BlId;
				//btsCodice.Attributes.Add("onclick","return ControllaBL('" + RicercaModulo1.TxtCodice.ClientID + "');");
				//btsCodice.Attributes.Add("onclick","ShowFrameRep('" + txtBL_ID.ClientID + "','bl_id',event);");  
				//Classi.SiteJavaScript.ShowFrameReperibili(Page,1);   
				//				btsCodice.CausesValidation = false;

				//				btsCodice.Attributes.Remove("disabled");
			}
			else
			{
				//btsCodice.Attributes.Add("onclick","return ControllaBL('" + RicercaModulo1.TxtCodice.ClientID + "');");
				//btsCodice.Attributes.Add("onclick","ShowFrameRep('" + txtBL_ID.ClientID + "','bl_id',event);");  
				//				Classi.SiteJavaScript.ShowFrameReperibili(Page,1);   
				//				this.RicercaModulo1.TxtRicerca.Text = "";
				//				String scriptString = "<script language=JavaScript>alert(\"Nessun addetto per l'edificio selezionato\");";
				//				scriptString += "<";
				//				scriptString += "/";
				//				scriptString += "script>";
				//
				//				if(!this.IsClientScriptBlockRegistered("clientScriptcalendario"))
				//					this.RegisterClientScriptBlock ("clientScriptcalendario", scriptString);
			}
		}

		private void BindControls()
		{
			Classi.ClassiDettaglio.Urgenza _Urgenza = new TheSite.Classi.ClassiDettaglio.Urgenza();
			Classi.ClassiDettaglio.RichiedentiTipo _RichiedentiTipo = new TheSite.Classi.ClassiDettaglio.RichiedentiTipo();

			//			this.cmbsGruppo.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
			//				_RichiedentiTipo.GetData().Tables[0], "DESCRIZIONE", "ID", "", "0");
			//			this.cmbsGruppo.DataTextField = "DESCRIZIONE";
			//			this.cmbsGruppo.DataValueField = "ID";
			//			this.cmbsGruppo.DataBind();

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
			//cmbsApparecchiatura.Enabled=false;

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

				//cmbsServizio.Enabled=true;

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
			
			//if (this.RicercaModulo1.BlId == "") return;
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
			
			//if (this.RicercaModulo1.BlId == "") return;
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
			s_p_sql.Value = " Select count(wr.wr_id) from wr where wr.bl_id = '" + _bl_id + "' and wr.id_wr_status in (1,15) and (wr.tipomanutenzione_id = 1 or wr.tipomanutenzione_id = 3)";
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
			s_p_sql.Value = " Select count(wr.wr_id) from wr where wr.bl_id = '" + _bl_id + "' and wr.id_wr_status not in (1,15) and (wr.tipomanutenzione_id = 1 or wr.tipomanutenzione_id = 3) ";
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
			//string sql="select count(wr.bl_id) from wr where wr.bl_id = '" + _bl_id + "' and wr.tipomanutenzione_id = 1";
			string sql="select count(wr.bl_id) from wr where wr.bl_id = '" + _bl_id + "'";
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
