namespace TheSite.WebControls
{
	using System;
	using System.Collections;
	using System.Data;
	using System.Drawing;
	using System.ComponentModel;
	using System.Web.SessionState;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using ApplicationDataLayer;
	using ApplicationDataLayer.DBType;
	using S_Controls.Collections;
	using System.Reflection;
	using System.IO;
	using MyCollection;


	public class UserRdlInailLabel : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblNote;
		protected System.Web.UI.WebControls.Label lblTelefono;
		protected System.Web.UI.WebControls.TextBox txtHidBl;
		protected System.Web.UI.WebControls.Label lblfabbricato;
		protected System.Web.UI.WebControls.Label lblstanzaric;
		protected System.Web.UI.WebControls.Label lblemailric;
		protected System.Web.UI.WebControls.Label lblOraRichiesta;
		protected System.Web.UI.WebControls.Label lblGruppo;
		protected System.Web.UI.WebControls.Label lblDataRichiesta;
		protected System.Web.UI.WebControls.Label lbltelefonoric;
		protected System.Web.UI.WebControls.Label lblOperatore;
		protected System.Web.UI.WebControls.Label lblRichiedente;
		protected System.Web.UI.WebControls.Label LblRdl;
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected S_Controls.S_Label lbldatavalidDCSIT;
		protected S_Controls.S_Label lblOraValidDCSIT;
		protected S_Controls.S_Label lblUtenteDCSIT;
		protected S_Controls.S_Label lblStatoDCSIT;
		protected S_Controls.S_Label lblDataValidDL;
		protected S_Controls.S_Label lblOraValidDL;
		protected S_Controls.S_Label lblUtenteDL;
		protected S_Controls.S_Label lblStatoDL;
		protected Csy.WebControls.DataPanel Datapanel4;
		protected System.Web.UI.HtmlControls.HtmlTable Tableordine;
		protected System.Web.UI.HtmlControls.HtmlTableRow preventivo1;
		protected System.Web.UI.HtmlControls.HtmlTableRow preventivo2;
			
		protected S_Controls.S_HyperLink LinkConsuntivo;
		protected System.Web.UI.WebControls.Label lblconsuntivo;
		protected S_Controls.S_ComboBox cmbsstatolavoro;
		protected System.Web.UI.HtmlControls.HtmlTableRow trnote;
		protected System.Web.UI.HtmlControls.HtmlTable Tablecompletamento;
		protected System.Web.UI.HtmlControls.HtmlTableRow trconsuntivo1;
		protected System.Web.UI.HtmlControls.HtmlTableRow trconsuntivo2;
		protected System.Web.UI.HtmlControls.HtmlTableRow trannocontab;
		protected System.Web.UI.HtmlControls.HtmlTableRow trconsuntivo3;
		protected System.Web.UI.HtmlControls.HtmlTableRow trsoddisfazione;
		protected System.Web.UI.HtmlControls.HtmlTableRow trannotazione;
		protected Csy.WebControls.DataPanel PanelGeneral;
		protected Csy.WebControls.DataPanel PanelDCSIT;
		protected Csy.WebControls.DataPanel PanelDL;
		protected Csy.WebControls.DataPanel PanelCofatec;
		protected Csy.WebControls.DataPanel PanelCompleta;
		protected System.Web.UI.WebControls.Label lblPiano;
		protected System.Web.UI.WebControls.Label lblStanza;

		Classi.ManCorrettiva.ClManCorrettiva _ClManCorrettiva;
		Classi.ManStraordinaria.Richiesta _Richiesta;
		protected System.Web.UI.WebControls.Button btnHelp;
		protected System.Web.UI.HtmlControls.HtmlTable TableCompleta;

		protected S_Controls.S_Button btnfoglioprestazioni;

		protected System.Web.UI.HtmlControls.HtmlTableRow tipointervento0;
		protected System.Web.UI.HtmlControls.HtmlTableRow tipointervento1;
		protected System.Web.UI.HtmlControls.HtmlTableRow tipointervento2;

		protected S_Controls.S_Label lblPreventivo;

		protected S_Controls.S_HyperLink LinkPreventivo;
		protected System.Web.UI.WebControls.Label LblMessaggio;
		protected System.Web.UI.HtmlControls.HtmlTableRow preventivo3;

		protected S_Controls.S_CheckBox checkQuantifica;
		protected System.Web.UI.WebControls.RadioButton RadioButton1;
		protected System.Web.UI.WebControls.RadioButton RadioButton2;
		protected System.Web.UI.WebControls.RadioButton RadioButton3;
		protected System.Web.UI.WebControls.RadioButton RadioButton4;
		protected System.Web.UI.WebControls.RadioButtonList RadioButtonList1;
		int wr_id=0;
		protected TheSite.WebControls.VisualizzaSolleciti VisualizzaSolleciti1;
		//protected TheSite.WebControls.AggiungiSollecito AggiungiSollecito1;
		protected S_Controls.S_TextBox txtsAnnotazioni;

			
		protected System.Web.UI.WebControls.Label lblServizio;
		protected System.Web.UI.WebControls.Label lblStandardApp;
		protected System.Web.UI.WebControls.Label lblApparecchiatura;
		protected System.Web.UI.WebControls.Label lblTipoManutenzione;
		protected System.Web.UI.WebControls.Label lblUrgenza;
		protected System.Web.UI.WebControls.Label lblTrasmissione;
		protected System.Web.UI.WebControls.Label lblDitta;
		protected System.Web.UI.WebControls.Label lblDataPrevistaInizio;
		protected S_Controls.S_Button btnChiudicompleta;
		protected System.Web.UI.WebControls.Label lblDataPrevistaFine;
		protected System.Web.UI.WebControls.Label lblOrdineLavoroFSL;
		protected System.Web.UI.WebControls.Label lblTipoIntervento;
		protected System.Web.UI.WebControls.Label lblSpesaPresunta;
		protected System.Web.UI.WebControls.Label lblOrdineLavoro;
		protected System.Web.UI.WebControls.Label lblAddetto;
		protected System.Web.UI.WebControls.Label lblDataPianificata;
		protected System.Web.UI.WebControls.Label lblOreMinuti;
		protected System.Web.UI.WebControls.Label lblNumPreventivo;
		protected System.Web.UI.WebControls.Label lblStatoLavoro;
		protected System.Web.UI.WebControls.Label lblSospesa;
		protected System.Web.UI.WebControls.Label lblDataInizio;
		protected System.Web.UI.WebControls.Label lblOreMinutiInizio;
		protected System.Web.UI.WebControls.Label lblDataFine;
		protected System.Web.UI.WebControls.Label lblOreMinutiFine;
		protected System.Web.UI.WebControls.Label lblImpCons;
		protected System.Web.UI.WebControls.Label lblContabilizzazione;
		protected System.Web.UI.WebControls.Label lblAnno;
		protected System.Web.UI.WebControls.Label lblImportoPreventivo;
		protected System.Web.UI.WebControls.Label lblAnnotazioni;
		protected System.Web.UI.WebControls.Label lblDescrizione;
		protected S_Controls.S_Button BtnElimina;
		public Classi.SiteModule _SiteModule;
		protected WebControls.PageTitle PageTitle1;
			
		Type myType;
		

		#region variabili
		public static string HelpLink = string.Empty;		
			
			
		public static int FunId = 0;	
		MyCollection.clMyCollection _myColl = new MyCollection.clMyCollection();
		#endregion
			
		private int bl_id
		{
			get
			{
				if(ViewState["bl_id"]!=null)
					return Convert.ToInt32(ViewState["bl_id"]);
				else
					return 0;
			}
			set	{ViewState["bl_id"]=value;}
		  
		}
	
		private int dcsit_id
		{
			get
			{
				if(ViewState["dcsit_id"]!=null)
					return Convert.ToInt32(ViewState["dcsit_id"]);
				else
					return 0;
			}
			set	{ViewState["dcsit_id"]=value;}
		  
		}

		private int dl_id
		{
			get
			{
				if(ViewState["dl_id"]!=null)
					return Convert.ToInt32(ViewState["dl_id"]);
				else
					return 0;
			}
			set	{ViewState["dl_id"]=value;}
		  
		}
		private bool IsCompleta
		{
			get
			{
				if( Request["c"]==null)
					return false;
				else
					return true;
			}
		}
			

		
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			;
			string confirmMessaggio = "return confirm('Sei sicuro di voler eliminare la RdL n° " + Request["wr_id"].ToString().Trim() + " ?');";
			//domanda = "Sei sicuro di voler eliminare la RdL n°" + Request["wr_id"].ToString() + " ?";
			this.BtnElimina.Attributes.Add("onclick",confirmMessaggio);
				
			myType=Page.GetType();       
			FieldInfo myFiledInfo = myType.GetField("_SiteModule");

			string _mypage="./ManutenzioneCorrettiva/SfogliaRdlPaging.aspx";			
			_SiteModule = new TheSite.Classi.SiteModule(_mypage);
			FunId = _SiteModule.ModuleId;

			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			this.PageTitle1.Title = "VISUALIZA RDL DA ELIMINARE";

			if(Request["wr_id"]!=null)
				wr_id=int.Parse(Request["wr_id"]);
			_ClManCorrettiva=new TheSite.Classi.ManCorrettiva.ClManCorrettiva(Context.User.Identity.Name);
			_Richiesta = new TheSite.Classi.ManStraordinaria.Richiesta();

					
			if(!IsPostBack)
			{

				LoadDatiCreazione();
			}
				
		}

			
	

		private void LoadDatiCreazione()
		{
			DataSet _Ds = _Richiesta.GetSingleRdlLabel(this.wr_id);
			if (_Ds.Tables[0].Rows.Count>0)
			{
				DataRow _Dr = _Ds.Tables[0].Rows[0];

				this.bl_id=Int32.Parse(_Dr["id_bl"].ToString());			

				if (_Dr["id"] != DBNull.Value)
					this.LblRdl.Text=_Dr["ID"].ToString();

				VisualizzaSolleciti1.TxtID_WR =_Dr["id"].ToString();


				if (_Dr["wo_id"] != DBNull.Value)
				{
					this.lblOrdineLavoro.Text=_Dr["wo_id"].ToString().Trim();
				}
				else
				{
					this.lblOrdineLavoro.Text = " - - - ";
				}
					
				txtHidBl.Text=_Dr["codicebl"].ToString();
					
				if (_Dr["trasmissionedesc"] != DBNull.Value)
				{
					this.lblTrasmissione.Text = _Dr["trasmissionedesc"].ToString().Trim();
				}
				else
				{
					this.lblTrasmissione.Text = " - - - ";
				}
						
				//RICHIEDENTE
				if (_Dr["richiedente"] != DBNull.Value)
				{
					this.lblRichiedente.Text=_Dr["richiedente"].ToString().Trim();
				}
				else
				{
					this.lblRichiedente.Text = " - - - ";
				}

				//OPERATORE
				if (_Dr["operatore"] != DBNull.Value)
				{
					this.lblOperatore.Text = _Dr["operatore"].ToString().Trim();
				}
				else
				{
					this.lblOperatore.Text = " - - - ";
				}
				//TELEFONORICHIEDENTE
				if (_Dr["telefonoric"] != DBNull.Value)
				{
					this.lbltelefonoric.Text = _Dr["telefonoric"].ToString().Trim();
				}
				else
				{
					this.lbltelefonoric.Text = " - - - ";
				}
				//EMAILRICHIEDENTE
				if (_Dr["emailric"] != DBNull.Value)
				{
					this.lblemailric.Text = _Dr["emailric"].ToString().Trim();
				}
				else
				{
					this.lblemailric.Text = " - - - ";
				}
				//STANZARICHIEDENTE
				if (_Dr["stanzaric"] != DBNull.Value)
				{
					this.lblstanzaric.Text=_Dr["stanzaric"].ToString().Trim();
				}
				else
				{
					this.lblstanzaric.Text = " - - - ";
				}
				//TELEFONO
				if (_Dr["telefono"] != DBNull.Value)
				{
					this.lblTelefono.Text=_Dr["telefono"].ToString().Trim();
				}
				else
				{
					this.lblTelefono.Text = " - - - ";
				}
				//DATARICHIESTA				
				if (_Dr["dataRichiesta"] != DBNull.Value)
					this.lblDataRichiesta.Text= System.DateTime.Parse(_Dr["dataRichiesta"].ToString()).ToShortDateString();
				//ORARICHIESTA				
				if (_Dr["dataRichiesta"] != DBNull.Value)
					this.lblOraRichiesta.Text= System.DateTime.Parse(_Dr["dataRichiesta"].ToString()).ToShortTimeString();				
				//GRUPPO
				if (_Dr["gruppo"] != DBNull.Value)
				{
					this.lblGruppo.Text = _Dr["gruppo"].ToString().Trim();
				}
				else
				{
					this.lblGruppo.Text = " - - - ";
				}
				//FABBRICATO
				if (_Dr["fabbricato"] != DBNull.Value)
				{
					this.lblfabbricato.Text = _Dr["fabbricato"].ToString().Trim();
				}
				else
				{
					this.lblfabbricato.Text = " - - - ";
				}

				if (_Dr["stanza"].ToString().Trim() != String.Empty)
				{
					this.lblStanza.Text = _Dr["stanza"].ToString().Trim();
				}
				else
				{
					this.lblStanza.Text = " - - - ";
				}
				if (_Dr["piano"] != DBNull.Value)
				{
					this.lblPiano.Text=_Dr["piano"].ToString().Trim();
				}
				else
				{
					this.lblPiano.Text = " - - - ";
				}
				if (_Dr["nota"] != DBNull.Value)
				{
					this.lblNote.Text=_Dr["nota"].ToString().Trim();
				}	
				else
				{
					this.lblNote.Text = " - - - ";
				}
					
				if (_Dr["servizioDesc"].ToString().Trim() != String.Empty || _Dr["servizioDesc"]!= DBNull.Value)
				{
					if( _Dr["servizioDesc"].ToString().Trim()!= "-")
					{
						this.lblServizio.Text = _Dr["servizioDesc"].ToString().Trim();
					}
					else
					{
						this.lblServizio.Text = " - - - ";
					}
				}
				else
				{
					this.lblServizio.Text = " - - - ";
				}
					
				if (_Dr["standardApp"] != DBNull.Value)
				{
					this.lblStandardApp.Text = _Dr["standardApp"].ToString().Trim();
				}
				else
				{
					this.lblStandardApp.Text = " - - - ";
				}

				if (_Dr["id_eq"] != DBNull.Value)
				{
					this.lblApparecchiatura.Text = _Dr["id_eq"].ToString().Trim();	
				}
				else
				{
					this.lblApparecchiatura.Text = " - - - ";
				}
								
					
				if (_Dr["descrizione"] != DBNull.Value)
				{
					this.lblDescrizione.Text=_Dr["descrizione"].ToString().Trim();	
				}
				else
				{
					this.lblDescrizione.Text = " - - - ";
				}



				if (_Dr["dittaDesc"] != DBNull.Value)
				{
					this.lblDitta.Text =_Dr["dittaDesc"].ToString().Trim();
				}
				else
				{
					this.lblDitta.Text = " - - - ";
				}

				if (_Dr["adettoNominativo"] != DBNull.Value)
				{
					if(_Dr["adettoNominativo"].ToString().Trim() != String.Empty)
					{
						this.lblAddetto.Text = _Dr["adettoNominativo"].ToString().Trim();	
					}
					else
					{
						this.lblAddetto.Text = " - - - ";
					}
				}
				else
				{
					this.lblAddetto.Text = " - - - ";
				}

				//DATAPIANIFICATA
				if (_Dr["datapianificata"] != DBNull.Value)
				{
					this.lblDataPianificata.Text = System.DateTime.Parse(_Dr["datapianificata"].ToString()).ToShortDateString().Trim();
				}
				else
				{
					this.lblDataPianificata.Text = " - - - ";
				}
				//ORARIO PIANIFICATO
				string minuti="00";
				string ora="00";
				this.lblOreMinuti.Text = "00:00";
				if (_Dr["datapianificata"] != DBNull.Value)
				{
					System.DateTime orarich= System.DateTime.Parse(_Dr["datapianificata"].ToString());
					ora=orarich.Hour.ToString();
					minuti=orarich.Minute.ToString();
					if(ora.Length==1)
						ora = "0" + ora ;
					if(minuti.Length==1)
						minuti = "0" + minuti ;
					this.lblOreMinuti.Text = ora + ":" + minuti;
				}

				if (_Dr["numeropreventivo"] != DBNull.Value)
				{
					this.lblNumPreventivo.Text = _Dr["numeropreventivo"].ToString();
				}
				else
				{
					this.lblNumPreventivo.Text = " - - - ";
				}



				if (_Dr["tipointervento"] != DBNull.Value)
				{
						
						
					if(_Dr["tipointervento"].ToString()=="3")
					{
						lblTipoManutenzione.Text = "Manutenzione Straordinaria";

					}
					else
					{
						lblTipoManutenzione.Text = "Manutenzione richiesta";

					}
				}
				else
				{
					lblTipoManutenzione.Text = " - - - ";
				}
				
				// Urgenza
					
				if (_Dr["prioritaDesc"] != DBNull.Value)
				{
					lblUrgenza.Text = _Dr["prioritaDesc"].ToString().Trim();
				}
				else
				{
					lblUrgenza.Text = " - - - ";
				}
				//STATO DELLA RDL
				
				DataSet _MyDsStato= _ClManCorrettiva.GetStatusRdl(this.wr_id);
				if (_MyDsStato.Tables[0].Rows.Count>0)
				{
					DataRow _DrStato = _MyDsStato.Tables[0].Rows[0];
					string descrizionestato = _DrStato["descrizione"].ToString();
					LblMessaggio.Text="Stato della Richiesta di Lavoro : " + descrizionestato + " in data: " + _DrStato["data"]  ;
				}


				if (_Dr["id_dl"] != DBNull.Value)
					this.dl_id=Convert.ToInt32( _Dr["id_dl"]);

				if (_Dr["utente_dl"] != DBNull.Value)
				{
					this.lblUtenteDL.Text= _Dr["utente_dl"].ToString().Trim();
				}
				else
				{
					this.lblUtenteDL.Text = " - - - ";
				}

				if (_Dr["data_validazione_dl"] != DBNull.Value)
				{
					System.DateTime dtvalidazione=System.DateTime.Parse(_Dr["data_validazione_dl"].ToString());

					lblDataValidDL.Text= dtvalidazione.ToShortDateString();
					lblOraValidDL.Text=dtvalidazione.Hour.ToString().PadLeft(2,'0') + ":" +  dtvalidazione.Minute.ToString().PadLeft(2,'0');
				}
				else
				{
					lblOraValidDL.Text = " - - - ";
				}

				if (_Dr["lavori_urgenti_dl"] != DBNull.Value)
					this.checkQuantifica.Checked=(Convert.ToInt32(_Dr["lavori_urgenti_dl"])==0)?false:true;

			
				if (_Dr["stato_dl"] != DBNull.Value)
				{
					this.lblStatoDL.Text=_Dr["stato_dl"].ToString().Trim();
				}
				else
				{
					this.lblStatoDL.Text = " - - - ";
				}
		    
	
				if (_Dr["tipointerventoDesc"] != DBNull.Value)
				{
					this.lblTipoIntervento.Text = _Dr["tipointerventoDesc"].ToString().Trim();
				}
				else
				{
					this.lblTipoIntervento.Text = " - - - ";
				}

				this.lblSpesaPresunta.Text = "0,00";
				if (_Dr["SPESA_PRESUNTA"] != DBNull.Value)
				{
					this.lblSpesaPresunta.Text = Classi.Function.GetTypeNumber(_Dr["SPESA_PRESUNTA"],Classi.NumberType.Intero).ToString() + Classi.Function.GetTypeNumber(_Dr["SPESA_PRESUNTA"],Classi.NumberType.Decimale).ToString(); 
				}
				


				if (_Dr["datainizio"] != DBNull.Value)
				{
					this.lblDataPrevistaInizio.Text = DateTime.Parse( _Dr["datainizio"].ToString()).ToShortDateString().Trim();
				}
				else
				{
					this.lblDataPrevistaInizio.Text = " - - - ";
				}


				if (_Dr["datafine"] != DBNull.Value)
				{
					this.lblDataPrevistaFine.Text = DateTime.Parse( _Dr["datafine"].ToString()).ToShortDateString().Trim();
				}
				else
				{
					this.lblDataPrevistaFine.Text = " - - - ";
				}

				if (_Dr["ordine_lavoro"] != DBNull.Value)
				{
					this.lblOrdineLavoroFSL.Text=_Dr["ordine_lavoro"].ToString().Trim();
				}
				else
				{
					this.lblOrdineLavoroFSL.Text=" - - - ";
				}

				if (_Dr["id_dcsit"] != DBNull.Value)
					this.dcsit_id=Convert.ToInt32( _Dr["id_dcsit"]);

				if (_Dr["utente_dcsit"] != DBNull.Value)
				{
					this.lblUtenteDCSIT.Text= _Dr["utente_dcsit"].ToString();
				}
				else
				{
					this.lblUtenteDCSIT.Text = " - - - ";
				}

				if (_Dr["data_validazione_dcsit"] != DBNull.Value)
				{
					System.DateTime dtvalidazionedcsit=System.DateTime.Parse(_Dr["data_validazione_dcsit"].ToString());

					lbldatavalidDCSIT.Text= dtvalidazionedcsit.ToShortDateString();
					lblOraValidDCSIT.Text=dtvalidazionedcsit.Hour.ToString().PadLeft(2,'0') + ":" + dtvalidazionedcsit.Minute.ToString().PadLeft(2,'0');
				}
				else
				{
					lbldatavalidDCSIT.Text = " - - - ";
					lblOraValidDCSIT.Text = " - - - ";
				}


				if (_Dr["stato_dcsit"] != DBNull.Value)
				{
					this.lblStatoDCSIT.Text=_Dr["stato_dcsit"].ToString().Trim();
				}
				else
				{
					this.lblStatoDCSIT.Text = " - - - ";
				}

				if (_Dr["stato_descrizione_estesa"] != DBNull.Value)
				{
					this.lblStatoLavoro.Text = _Dr["stato_descrizione_estesa"].ToString().Trim();
				}
				else
				{
					this.lblStatoLavoro.Text = " - - - ";
				}

				if (_Dr["notesospesa"] != DBNull.Value)
				{
					this.lblSospesa.Text = _Dr["notesospesa"].ToString().Trim();
				}
				else
				{
					this.lblSospesa.Text = " - - - ";
				}

				if (_Dr["date_start"]!=DBNull.Value)
				{
					this.lblDataInizio.Text = System.DateTime.Parse(_Dr["date_start"].ToString()).ToShortDateString().Trim();
				}
				else
				{
					this.lblDataInizio.Text = " - - - ";
				}
						
				if (_Dr["date_end"]!=DBNull.Value)
				{
					this.lblDataFine.Text = System.DateTime.Parse(_Dr["date_end"].ToString()).ToShortDateString().Trim();
				}
				else
				{
					this.lblDataFine.Text = " - - - ";
				}
												
						
				string minutiInizio = "00";
				string oraInizio = "00";
				this.lblOreMinutiInizio.Text = "00:00";
						
				if (_Dr["date_start"]!=DBNull.Value)
				{
					System.DateTime OraIni= System.DateTime.Parse(_Dr["date_start"].ToString());
					oraInizio = OraIni.Hour.ToString();
					minutiInizio = OraIni.Minute.ToString();
					if(oraInizio.Length==1)
						oraInizio = "0" + oraInizio ;
					if(minutiInizio.Length==1)
						minutiInizio = "0" + minutiInizio ;
					this.lblOreMinutiInizio.Text = oraInizio + ":" + minutiInizio;
				}

					

				string minutiFine = "00";
				string oraFine = "00";
				this.lblOreMinutiFine.Text = "00:00";

				if (_Dr["date_end"]!=DBNull.Value)
				{
					System.DateTime OraFine= System.DateTime.Parse(_Dr["date_end"].ToString());      
					this.lblOreMinutiFine.Text = OraFine + " : " + OraFine.Minute.ToString().PadLeft(2,Convert.ToChar("0")).Trim();
					oraFine = OraFine.Hour.ToString();
					minutiFine = OraFine.Minute.ToString();
					if(oraFine.Length==1)
						oraFine = "0" + oraFine ;
					if(minutiFine.Length==1)
						minutiFine = "0" + minutiFine ;
					this.lblOreMinutiFine.Text = oraFine + ":" + minutiFine;
				}

				if (_Dr["comments"] != DBNull.Value)
				{
					lblAnnotazioni.Text =  _Dr["comments"].ToString().Trim();
				}
				else
				{
					lblAnnotazioni.Text = " - - - ";
				}
				if (_Dr["satisfaction_id"] != DBNull.Value)
					RadioButtonList1.SelectedValue = _Dr["satisfaction_id"].ToString();

				if (_Dr["impPreventivo"] != DBNull.Value)
					this.lblImportoPreventivo.Text = _Dr["impPreventivo"].ToString().Trim();
				else
					this.lblImportoPreventivo.Text = "€ 0,00";

				if (_Dr["contabilizzazione"] != DBNull.Value)
				{
					this.lblContabilizzazione.Text = _Dr["contabilizzazione"].ToString().Trim();
				}
				else
				{
					this.lblContabilizzazione.Text = " - - - ";
				}
						

				if (_Dr["importoconsuntivo"] != DBNull.Value)
				{
					string txtSpesa3 =Classi.Function.GetTypeNumber(_Dr["importoconsuntivo"], TheSite.Classi.NumberType.Intero);  
					string txtSpesa4 =Classi.Function.GetTypeNumber(_Dr["importoconsuntivo"], TheSite.Classi.NumberType.Decimale);  
					this.lblImpCons.Text = txtSpesa3 + "," + txtSpesa4;
				}
				else
				{
					this.lblImpCons.Text = " - - - ";
				}

				lblAnno.Text = DateTime.Now.Year.ToString();

				if (_Dr["idstatus"] != DBNull.Value)
				{
					if (_Dr["idstatus"].ToString().Trim()=="4")
					{
						this.PanelCompleta.Visible = true;
					}
					else
					{
						this.PanelCompleta.Visible = false;
					}
				}
				else
				{
					this.PanelCompleta.Visible = false;
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
			this.BtnElimina.Click += new System.EventHandler(this.BtnElimina_Click);
			this.btnChiudicompleta.Click += new System.EventHandler(this.btnChiudicompleta_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void btnChiudicompleta_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("SfogliaRdlEliminare.aspx?FunId=" + ViewState["FunId"]);
		}

		private void BtnElimina_Click(object sender, System.EventArgs e)
		{
			
			try
			{
					
				Classi.ManStraordinaria.Richiesta _Richiesta = new TheSite.Classi.ManStraordinaria.Richiesta();
				int i_RowsAffected = 0;
					
					
				S_ControlsCollection _SColl = new S_ControlsCollection();

				S_Controls.Collections.S_Object s_p_id = new S_Object();
				s_p_id.ParameterName = "p_Wr_Id";
				s_p_id.DbType = CustomDBType.Integer ;
				s_p_id.Direction = ParameterDirection.Input;
				s_p_id.Index =0;
				s_p_id.Value = wr_id;
				_SColl.Add(s_p_id);

				i_RowsAffected = _Richiesta.DeleteRdL(_SColl);	

				if ( i_RowsAffected == -1 )					
					Server.Transfer("SfogliaRdlEliminare.aspx");
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}	

		}

		private void DeleteItem(string id)
		{
			Console.WriteLine(id); 
			if (id=="") return;
			
			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id = new S_Object();
			s_p_id.ParameterName = "p_id";
			s_p_id.DbType = CustomDBType.Integer ;
			s_p_id.Direction = ParameterDirection.Input;
			s_p_id.Index =0;
			s_p_id.Value = int.Parse(id);
			_SColl.Add(s_p_id);
			try
			{
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);  
				this.Page.RegisterStartupScript("messaggio","<script language'javascript'>alert(\"Impossibile cancellare l'apparecchiatura perchè è utilizzata in altre tabelle\");</script>"); 
			}
		}


	}
}

