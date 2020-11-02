namespace TheSite.WebControls
{



	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using ApplicationDataLayer;
	using ApplicationDataLayer.DBType;
	using S_Controls.Collections;
	using System.Reflection;
	using System.IO;

	public enum TipoPostFile
	{
		Preventivo=0,
		Consuntivo=1
	}
	/// <summary>
	///		Descrizione di riepilogo per UserRdlInail.
	/// </summary>
	public class UserRdlInail : System.Web.UI.UserControl
	{
		protected S_Controls.S_TextBox txtsDescrizione;
		protected S_Controls.S_ComboBox cmbEQ;
		protected S_Controls.S_ComboBox cmdsStdApparecchiatura;
		protected S_Controls.S_ComboBox cmbsServizio;
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
		protected S_Controls.S_ComboBox cmbsTrasmissione;
		protected System.Web.UI.WebControls.Label LblRdl;
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected S_Controls.S_Button btsApprovaDCSIT;
		protected S_Controls.S_Button btsRifiutaDCSIT;
		protected S_Controls.S_Label lbldatavalidDCSIT;
		protected S_Controls.S_Label lblOraValidDCSIT;
		protected S_Controls.S_Label lblUtenteDCSIT;
		protected S_Controls.S_Label lblStatoDCSIT;
		protected S_Controls.S_Button btsApprovaDL;
		protected S_Controls.S_Button btsRifiutaDL;
		protected S_Controls.S_Label lblDataValidDL;
		protected S_Controls.S_Label lblOraValidDL;
		protected S_Controls.S_Label lblUtenteDL;
		protected S_Controls.S_Label lblStatoDL;
		protected S_Controls.S_TextBox txtSpesa2;
		protected S_Controls.S_TextBox txtSpesa1;
		protected S_Controls.S_TextBox txtNumeroPreventivo;
		protected S_Controls.S_ComboBox cmbsUrgenza;
		protected S_Controls.S_ComboBox cmbsAddetto;
		protected S_Controls.S_ComboBox cmbsDitta;
		protected S_Controls.S_Label S_Lblordinelavoro;
		protected Csy.WebControls.DataPanel Datapanel4;
		protected System.Web.UI.HtmlControls.HtmlTable Tableordine;
		protected System.Web.UI.HtmlControls.HtmlInputFile UploadFilePreventivo;
		protected S_Controls.S_HyperLink LinkConsuntivo;
		protected System.Web.UI.WebControls.Label lblconsuntivo;
		protected S_Controls.S_ComboBox cmbsAnnoContab;
		protected S_Controls.S_ComboBox cmbContabilizzazione;
		protected S_Controls.S_TextBox txtSpesa4;
		protected S_Controls.S_TextBox txtSpesa3;
		protected S_Controls.S_TextBox txtsSospesa;
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
		protected System.Web.UI.HtmlControls.HtmlInputFile UploadFileCosto;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;
		protected WebControls.CalendarPicker CalendarPicker3;
		protected WebControls.CalendarPicker CalendarPicker4;
		protected WebControls.CalendarPicker CalendarPicker5;
        bool IsEditable=false;
		Classi.ManCorrettiva.ClManCorrettiva _ClManCorrettiva;
		protected System.Web.UI.WebControls.Button btnHelp;
		protected System.Web.UI.WebControls.Button btnApprova;
		protected System.Web.UI.WebControls.Button btnSospendi;
		protected System.Web.UI.WebControls.Button btnRifiuta;
		protected System.Web.UI.HtmlControls.HtmlTable TableEmetti;
		protected System.Web.UI.HtmlControls.HtmlTable TableCompleta;
		protected S_Controls.S_Button btnCompleta;
		protected S_Controls.S_Button btnfoglioprestazioni;
		protected S_Controls.S_Button btnChiudicompleta;
		protected System.Web.UI.HtmlControls.HtmlTableRow tipointervento0;
		protected System.Web.UI.HtmlControls.HtmlTableRow tipointervento1;
		protected System.Web.UI.HtmlControls.HtmlTableRow tipointervento2;
		protected S_Controls.S_ComboBox cmbsTipoIntrevento;
		protected S_Controls.S_TextBox txtspesaPresunta1;
		protected S_Controls.S_TextBox txtspesaPresunta2;
		protected S_Controls.S_TextBox txtOrdineLavoro;
		protected System.Web.UI.WebControls.Label LblMessaggio;
		protected S_Controls.S_ComboBox cmbsTipoManutenzione;
		protected S_Controls.S_CheckBox checkQuantifica;
		protected System.Web.UI.WebControls.RadioButton RadioButton1;
		protected System.Web.UI.WebControls.RadioButton RadioButton2;
		protected System.Web.UI.WebControls.RadioButton RadioButton3;
		protected System.Web.UI.WebControls.RadioButton RadioButton4;
		protected System.Web.UI.WebControls.RadioButtonList RadioButtonList1;
		int wr_id=0;
		protected TheSite.WebControls.VisualizzaSolleciti VisualizzaSolleciti1;
		protected S_Controls.S_TextBox txtsAnnotazioni;
		protected S_Controls.S_ComboBox cmbsOre;
		protected S_Controls.S_ComboBox cmbsMinuti;
		protected S_Controls.S_ComboBox cmbsOraInizio;
		protected S_Controls.S_ComboBox cmbsMinutiInizio;
		protected S_Controls.S_ComboBox cmbsOraFine;
		protected S_Controls.S_ComboBox cmbsMinutiFine;
		protected S_Controls.S_Button BtnCostiOpera;
		protected S_Controls.S_HyperLink LinkPreventivo;
		protected System.Web.UI.HtmlControls.HtmlTableRow preventivo1;
		protected System.Web.UI.HtmlControls.HtmlTableRow preventivo2;
		protected System.Web.UI.HtmlControls.HtmlTableRow preventivo3;
		protected TheSite.WebControls.AggiungiSollecito AggiungiSollecito1;
		protected S_Controls.S_Button btnfoglioprestazioniPdf;
		Type myType;
		

		private int bl_id
		{
				get{if(ViewState["bl_id"]!=null)
					 return Convert.ToInt32(ViewState["bl_id"]);
					else
				     return 0;
					}
			set	{ViewState["bl_id"]=value;}
		  
		}
		/// <summary>
		/// ID del DCSIT
		/// </summary>
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
		/// <summary>
		/// ID del Direttore dei lavori
		/// </summary>
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
		/// <summary>
		/// Indica se si sta in modalita di completamento o di approvazione
		/// </summary>
		/// <returns>Ritorna True se è la fase di completamento false in caso di approvazione</returns>
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
			myType=Page.GetType();     
  
			// recupero il PropertyInfo object passando il nome della proprietà da recuperare.
			FieldInfo myFiledInfo = myType.GetField("_SiteModule");
			
			// verifico che questa proprietà esista.
			if(myFiledInfo!=null)
				this.IsEditable=((Classi.SiteModule)myFiledInfo.GetValue(Page)).IsEditable;

			//Recupero l'id della richiesta
			if(Request["wr_id"]!=null)
				wr_id=int.Parse(Request["wr_id"]);

			
            //Istanzio la classe 
			_ClManCorrettiva=new TheSite.Classi.ManCorrettiva.ClManCorrettiva(Context.User.Identity.Name);
			
		
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{

				//Imposto alcune proprietà ai controlli
				SetProperty();
				//Imposto la visibilità di alcuni controlli in base all'utenza
				SetReadOnlyControl();
				//Imposto la visibilitò dei bottony in base al ruolo
				ReadOnlyPanel();
				//Imposto la visibilità dei panel
				SetVisiblePanel();
				//Valorizzazione dei dati inseriti nei controlli
				LoadDatiCreazione();
			}
			if(this.IsCompleta)
			{
				string script="<script language='javascript'>SetWorkType('" + this.cmbsstatolavoro.SelectedValue + "');</script>";
				Page.RegisterStartupScript("settacombo",script);
			}
		}

		#region Settaggi per le proprietà
		/// <summary>
		/// Imposta le proprietà e funzioni ai controlli
		/// </summary>	
		private void SetProperty()
		{
			cmbsOre.Attributes.Add("readonly","");
			cmbsMinuti.Attributes.Add("readonly","");
			cmbsOraInizio.Attributes.Add("readonly","");
			cmbsMinutiInizio.Attributes.Add("readonly","");
			cmbsOraFine.Attributes.Add("readonly","");
			cmbsMinutiFine.Attributes.Add("readonly","");

			txtSpesa2.Attributes.Add("onblur","imposta_dec(this.id);");
			txtSpesa2.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtSpesa2.Attributes.Add("onpaste","return false;");

			txtSpesa1.Attributes.Add("onblur","imposta_int(this.id);");
			txtSpesa1.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtSpesa1.Attributes.Add("onpaste","return false;");

//			txtSpesa4.Attributes.Add("onblur","imposta_dec(this.id);");
//			txtSpesa4.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
//			txtSpesa4.Attributes.Add("onpaste","return false;");
//
//			txtSpesa3.Attributes.Add("onblur","imposta_int(this.id);");
//			txtSpesa3.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
//			txtSpesa3.Attributes.Add("onpaste","return false;");
           
			txtspesaPresunta1.Attributes.Add("onblur","imposta_int(this.id);");
			txtspesaPresunta1.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtspesaPresunta1.Attributes.Add("onpaste","return false;");
			
			txtspesaPresunta2.Attributes.Add("onblur","imposta_int(this.id);");
			txtspesaPresunta2.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtspesaPresunta2.Attributes.Add("onpaste","return false;");

			txtOrdineLavoro.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtOrdineLavoro.Attributes.Add("onpaste","return false;");

			
//			sbValid.Append("if (typeof(validateDate) == 'function') { ");
//			sbValid.Append("if (validateDate() == false) { Ripristina(this,'Invia');  return false; }} ");
//			//sbValid.Append(this.Page.GetPostBackEventReference(this.btnCompleta));
//			sbValid.Append(";");
//			this.btnCompleta.Attributes.Add("onclick", sbValid.ToString());
			//Script da aggiungere per ogni submit
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("if (typeof(validateDate) == 'function') { ");
			sb.Append("if (validateDate() == false) { return false; }} ");
			sb.Append("this.value = 'Attendere...';");
			sb.Append("this.disabled = true;");
			sb.Append(this.Page.GetPostBackEventReference(this.btnCompleta));
			sb.Append(";");
			this.btnCompleta.Attributes.Add("onclick", sb.ToString());
       
			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("this.disabled = true;if (typeof(ControllaData) == 'function') { ");
			sbValid.Append("if (ControllaData() == false) {this.disabled = false; return false; }}");
			//sbValid.Append(this.Page.GetPostBackEventReference(this.btnApprova));
			sbValid.Append(";this.disabled = false;");
			this.btnApprova.Attributes.Add("onclick", sbValid.ToString());


			//Controlli per il DL Direttore dei lavori
			sbValid = new System.Text.StringBuilder();
			sbValid.Append("if (typeof(ControllaDateSpesaPresunta) == 'function') { ");
			sbValid.Append("if (ControllaDateSpesaPresunta() == false) { return false; }} ");
			this.btsApprovaDL.Attributes.Add("onclick", sbValid.ToString());
			//this.btsRifiutaDL.Attributes.Add("onclick", sbValid.ToString());

			//Blocco le combo durante il postback
			sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsServizio.ClientID + "').disabled = true;");
			this.cmdsStdApparecchiatura.Attributes.Add("onchange", sbValid.ToString());

			sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmdsStdApparecchiatura.ClientID + "').disabled = true;");
			this.cmbsServizio.Attributes.Add("onchange", sbValid.ToString());
		}


		private void ReadOnlyPanel()
		{
			if(Context.User.IsInRole("amministratori"))
			{
				return;
			}
			else if(Context.User.IsInRole("collaboratore"))
			{
				btsApprovaDL.Enabled=false;
				btsRifiutaDL.Enabled=false;
				TableEmetti.Visible =false;//Bottoni per l'emissione della richiesta di lavoro
				TableCompleta.Visible=false;//Bottoni per il completamento della richiesta di lavoro
				DisableControl(PanelDL,true);
				// MODIFICA PER DOPPIO RUOLO CON COFATHEC
				if(Context.User.IsInRole("cofathec"))
				{	
					//DA VEDERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
				}
				else
				{
					DisableControl(PanelCofatec,true);
				}

			}
			else if(Context.User.IsInRole("dl"))
			{
				btsApprovaDCSIT.Enabled=false;
				btsRifiutaDCSIT.Enabled=false;
				TableEmetti.Visible =false;//Bottoni per l'emissione della richiesta di lavoro
				TableCompleta.Visible=false;//Bottoni per il completamento della richiesta di lavoro
			//	DisableControl(PanelDCSIT,true);				
				// MODIFICA PER DOPPIO RUOLO CON COFATHEC
				if(Context.User.IsInRole("cofathec"))
				{	
					//DA VEDERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
				}
				else
				{
					DisableControl(PanelCofatec,true);
				}

			}			
			else
			{
				btsApprovaDCSIT.Enabled=false;
				btsRifiutaDCSIT.Enabled=false;
				btsApprovaDL.Enabled=false;
				btsRifiutaDL.Enabled=false;
				//DisableControl(PanelDCSIT,true);
				DisableControl(PanelDL,true);
			}
			
			
		}
		/// <summary>
		/// Imposta a read only alcuni controlli in base all'utenza
		/// </summary>
		private void SetReadOnlyControl()
		{
			btsApprovaDL.Visible=this.IsEditable;
			btsRifiutaDL.Visible=this.IsEditable;
			btsApprovaDCSIT.Visible=this.IsEditable;
			btsRifiutaDCSIT.Visible=this.IsEditable;
			TableEmetti.Visible =this.IsEditable;
            TableCompleta.Visible =this.IsEditable;
		}
		/// <summary>
		/// Imposta la visibilità del Panel in Base da quale pagina si provviene
		/// </summary>
		private void SetVisiblePanel()
		{
		  if(!this.IsCompleta)
			  PanelCompleta.Visible =false;
          else
			  PanelCompleta.Visible =true;

			if(this.IsCompleta==true)//completamento
			{
				cmbsTrasmissione.Attributes.Add("disabled","");
				cmbsServizio.Attributes.Add("disabled","");
				cmdsStdApparecchiatura.Attributes.Add("disabled","");
				cmbEQ.Attributes.Add("disabled","");
				cmbsTipoManutenzione.Enabled =false;
				CalendarPicker2.CreateValidator("Inserire la Data di Inizio Comletamento",ValidatorDisplay.None);
				CalendarPicker3.CreateValidator("Inserire la Data di Fine Comletamento",ValidatorDisplay.None);
				lblOperazione.Text="Gestione e Completamento Ordini di Lavoro"; 
				lblOperazione.CssClass= "Title";

//				btsApprovaDL.Visible=false;
//				btsRifiutaDL.Visible=false;
				btsApprovaDCSIT.Visible=false;
				btsRifiutaDCSIT.Visible=false;
			//	DisableControl(PanelDCSIT,false);
				DisableControl(PanelDL,false);
				TableEmetti.Visible =false;//Bottoni per l'emissione della richiesta di lavoro


			}
			else//Approvazione
			{
				Tableordine.Visible =false;
				lblOperazione.Text="Approva ed Emetti Richieste di Lavoro"; 
				lblOperazione.CssClass= "Title";
			}

		}
		#endregion

		/// <summary>
		/// Carica i dati iniziali della creazione della richiesta di lavoro
		/// </summary>
		private void LoadDatiCreazione()
		{
			BindCombo();
			//Recupero i dati della singola richiesta
			
				DataSet _Ds=  _ClManCorrettiva.GetSingleRdl(this.wr_id);
				if (_Ds.Tables[0].Rows.Count>0)
				{
					DataRow _Dr = _Ds.Tables[0].Rows[0];
					// valorizzo la property del BL_ID
					this.bl_id=Int32.Parse(_Dr["id_bl"].ToString());				
				
					//Carico il combo delle ditte con quelle relative al BL_ID selezionato				
				
					LoadDitte(this.bl_id);

					//ID RDL
					if (_Dr["id"] != DBNull.Value)
						this.LblRdl.Text=_Dr["ID"].ToString();
				
					AggiungiSollecito1.TxtID_WR=_Dr["id"].ToString();
					VisualizzaSolleciti1.TxtID_WR =_Dr["id"].ToString();
			
					//WO RDL
					if (_Dr["wo_id"] != DBNull.Value)
						S_Lblordinelavoro.Text=_Dr["wo_id"].ToString();					
				
					//Imposto i Servizi di competenza del BL in esame
					LoadService(_Dr["codicebl"].ToString());
					txtHidBl.Text=_Dr["codicebl"].ToString();
				
					if (_Dr["tipotrasmissione"] != DBNull.Value)
						this.cmbsTrasmissione.SelectedValue=_Dr["tipotrasmissione"].ToString();	
							
					//RICHIEDENTE
					if (_Dr["richiedente"] != DBNull.Value)
						this.lblRichiedente.Text=_Dr["richiedente"].ToString();
					//OPERATORE
					if (_Dr["operatore"] != DBNull.Value)
						this.lblOperatore.Text=_Dr["operatore"].ToString();
					//TELEFONORICHIEDENTE
					if (_Dr["telefonoric"] != DBNull.Value)
						this.lbltelefonoric.Text=_Dr["telefonoric"].ToString();
					//EMAILRICHIEDENTE
					if (_Dr["emailric"] != DBNull.Value)
						this.lblemailric.Text=_Dr["emailric"].ToString();
					//STANZARICHIEDENTE
					if (_Dr["stanzaric"] != DBNull.Value)
						this.lblstanzaric.Text=_Dr["stanzaric"].ToString();
					//TELEFONO
					if (_Dr["telefono"] != DBNull.Value)
						this.lblTelefono.Text=_Dr["telefono"].ToString();
					//DATARICHIESTA				
					if (_Dr["dataRichiesta"] != DBNull.Value)
						this.lblDataRichiesta.Text= System.DateTime.Parse(_Dr["dataRichiesta"].ToString()).ToShortDateString();
					//ORARICHIESTA				
					if (_Dr["dataRichiesta"] != DBNull.Value)
						this.lblOraRichiesta.Text= System.DateTime.Parse(_Dr["dataRichiesta"].ToString()).ToShortTimeString();				
					//GRUPPO
					if (_Dr["gruppo"] != DBNull.Value)
						this.lblGruppo.Text=_Dr["gruppo"].ToString();
					//FABBRICATO
					if (_Dr["fabbricato"] != DBNull.Value)
						this.lblfabbricato.Text=_Dr["fabbricato"].ToString();
					//Stanza
					if (_Dr["stanza"] != DBNull.Value)
						this.lblStanza.Text=_Dr["stanza"].ToString();
					//Piano
					if (_Dr["piano"] != DBNull.Value)
						this.lblPiano.Text=_Dr["piano"].ToString();
					//NOTA
					if (_Dr["nota"] != DBNull.Value)
						this.lblNote.Text=_Dr["nota"].ToString();				
					//Servizio				
					if (_Dr["servizio_id"] != DBNull.Value)
						this.cmbsServizio.SelectedValue=_Dr["servizio_id"].ToString();					
					//Carico lo Standard apparechiature
					LoadStandardApparechiature();
					//Standard Apparecchiatura
					if (_Dr["eqstd_id"] != DBNull.Value)
						this.cmdsStdApparecchiatura.SelectedValue=_Dr["eqstd_id"].ToString();

					LoadApparechiature();
					if (_Dr["id_eq"] != DBNull.Value)
						this.cmbEQ.SelectedValue=_Dr["id_eq"].ToString();				

					//Descrizione Intervento
					if (_Dr["descrizione"] != DBNull.Value)
						this.txtsDescrizione.Text=_Dr["descrizione"].ToString();				
				
					//Ditta Esecutrice (Controllo se ho nella WR il campo ditta valorizzato)				
					if (_Dr["ditta_id"] != DBNull.Value)
					{
						this.cmbsDitta.SelectedValue=_Dr["ditta_id"].ToString();
						LoadAddettiDitta(_Dr["codicebl"].ToString(),Int32.Parse(this.cmbsDitta.SelectedValue));
					}
					else
						LoadAddettiDitta("",1);
					//LoadAddettiDitta("-1",0);
					//Addetto
					if (_Dr["addetto_id"] != DBNull.Value)
						this.cmbsAddetto.SelectedValue=_Dr["addetto_id"].ToString();	

					//DATAPIANIFICATA
					if (_Dr["datapianificata"] != DBNull.Value)
						CalendarPicker1.Datazione.Text= System.DateTime.Parse(_Dr["datapianificata"].ToString()).ToShortDateString();
			
					//ORARIO PIANIFICATO
					string minuti="00";
					string ora="00";
					if (_Dr["datapianificata"] != DBNull.Value)
					{
						System.DateTime orarich= System.DateTime.Parse(_Dr["datapianificata"].ToString());
						ora=orarich.Hour.ToString();
						minuti=orarich.Minute.ToString();
						cmbsOre.SelectedValue=ora.PadLeft(2,Convert.ToChar("0"));
						cmbsMinuti.SelectedValue=minuti.PadLeft(2,Convert.ToChar("0"));
					
					}

					if (_Dr["numeropreventivo"] != DBNull.Value)
						txtNumeroPreventivo.Text=_Dr["numeropreventivo"].ToString();
               
				
				
					if (_Dr["importopreventivo"] != DBNull.Value && _Dr["importopreventivo"].ToString()!="0")
					{
						txtSpesa1.Text=Classi.Function.GetTypeNumber(_Dr["importopreventivo"], TheSite.Classi.NumberType.Intero);  
						txtSpesa2.Text =Classi.Function.GetTypeNumber(_Dr["importopreventivo"], TheSite.Classi.NumberType.Decimale);  
					}
					else
					{
						txtSpesa1.Text="0";
						txtSpesa2.Text="00";
					}

					if (_Dr["pdfpreventivo"] != DBNull.Value)
					{
						LinkPreventivo.Text=_Dr["pdfpreventivo"].ToString();
						LinkPreventivo.NavigateUrl ="javascript:openpdf('" +  this.wr_id.ToString() + "','Preventivo','" + _Dr["pdfpreventivo"].ToString().Replace("'","`")  + "');"; 
					}

					if (_Dr["tipointervento"] != DBNull.Value)
					{
						cmbsTipoManutenzione.SelectedValue= _Dr["tipointervento"].ToString();
						if(_Dr["tipointervento"].ToString()=="3")//diverso dalla straodinaria
						{
							tipointervento0.Style.Add("display","block");
							tipointervento1.Style.Add("display","block");
							tipointervento2.Style.Add("display","block");						
						}
						else
						{
							tipointervento1.Style.Add("display","none");
							tipointervento2.Style.Add("display","none");
							tipointervento0.Style.Add("display","none");
						}
					}
					else
					{
						tipointervento1.Style.Add("display","none");
						tipointervento2.Style.Add("display","none");
						tipointervento0.Style.Add("display","none");
						
					}
				

					if (_Dr["priorita"] != DBNull.Value)
						cmbsUrgenza.SelectedValue=_Dr["priorita"].ToString();
			
					//STATO DELLA RDL
				
					DataSet _MyDsStato= _ClManCorrettiva.GetStatusRdl(this.wr_id);
					if (_MyDsStato.Tables[0].Rows.Count>0)
					{
						DataRow _DrStato = _MyDsStato.Tables[0].Rows[0];
						string descrizionestato = _DrStato["descrizione"].ToString();
						LblMessaggio.Text="Stato della Richiesta di Lavoro : " + descrizionestato + " in data: " + _DrStato["data"]  ;
					}

					//Sezione dedicata alla Parte del direttore dei lavori(DL) e collaboratore
					if (_Dr["id_dl"] != DBNull.Value)
						this.dl_id=Convert.ToInt32( _Dr["id_dl"]);

					if (_Dr["utente_dl"] != DBNull.Value)
						this.lblUtenteDL.Text= _Dr["utente_dl"].ToString();

					if (_Dr["data_validazione_dl"] != DBNull.Value)
					{
						System.DateTime dtvalidazione=System.DateTime.Parse(_Dr["data_validazione_dl"].ToString());

						lblDataValidDL.Text= dtvalidazione.ToShortDateString();
						lblOraValidDL.Text=dtvalidazione.Hour.ToString().PadLeft(2,'0') + ":" +  dtvalidazione.Minute.ToString().PadLeft(2,'0');
					}

					if (_Dr["lavori_urgenti_dl"] != DBNull.Value)
						this.checkQuantifica.Checked=(Convert.ToInt32(_Dr["lavori_urgenti_dl"])==0)?false:true;

			
					if (_Dr["stato_dl"] != DBNull.Value)
						this.lblStatoDL.Text=_Dr["stato_dl"].ToString();

					if (_Dr["stato_dl_id"] != DBNull.Value)//se entra collaboratore e la richiesta è validata dal dl disabilito i tasti del collaboratore
						if (_Dr["stato_dl_id"].ToString() =="3" || _Dr["stato_dl_id"].ToString() =="4")
							if(Context.User.IsInRole("collaboratore"))
								DisableControl(PanelDCSIT,false);				    

					//*************  MDG COFATHEC non può approvare finchè non ha approvato il DL ********
					if(!Context.User.IsInRole("amministratori"))
					{
						if (_Dr["stato_dl_id"].ToString() == "2" || _Dr["stato_dl_id"].ToString() == "4")//Non è stata Approvata dal DL
						{
						
							TableEmetti.Visible=false;//Bottoni per l'emissione della richiesta di lavoro
						}					
					}
					//*************  MDG COFATHEC non può approvare finchè non ha approvato il DL ********

					this.cmbsTipoIntrevento.SelectedIndex=-1;

					if (_Dr["TIPO_INTERVENTO"] != DBNull.Value)
						this.cmbsTipoIntrevento.SelectedValue=_Dr["TIPO_INTERVENTO"].ToString();

					this.txtspesaPresunta1.Text="0";
					this.txtspesaPresunta2.Text="00";
					if (_Dr["SPESA_PRESUNTA"] != DBNull.Value)
					{
						this.txtspesaPresunta1.Text=Classi.Function.GetTypeNumber(_Dr["SPESA_PRESUNTA"],Classi.NumberType.Intero).ToString(); 
						this.txtspesaPresunta2.Text=Classi.Function.GetTypeNumber(_Dr["SPESA_PRESUNTA"],Classi.NumberType.Decimale).ToString(); 
					}

					if (_Dr["datainizio"] != DBNull.Value)
						this.CalendarPicker4.Datazione.Text=DateTime.Parse( _Dr["datainizio"].ToString()).ToShortDateString();
					else
						this.CalendarPicker4.Datazione.Text="";

					if (_Dr["datafine"] != DBNull.Value)
						this.CalendarPicker5.Datazione.Text=DateTime.Parse( _Dr["datafine"].ToString()).ToShortDateString();
					else
						this.CalendarPicker5.Datazione.Text="";

					if (_Dr["ordine_lavoro"] != DBNull.Value)
						this.txtOrdineLavoro.Text=_Dr["ordine_lavoro"].ToString();
					else
						this.txtOrdineLavoro.Text="";



					//Sezione dedicata al collaboratore
					if (_Dr["id_dcsit"] != DBNull.Value)
						this.dcsit_id=Convert.ToInt32( _Dr["id_dcsit"]);

					if (_Dr["utente_dcsit"] != DBNull.Value)
						this.lblUtenteDCSIT.Text= _Dr["utente_dcsit"].ToString();

					if (_Dr["data_validazione_dcsit"] != DBNull.Value)
					{
						System.DateTime dtvalidazionedcsit=System.DateTime.Parse(_Dr["data_validazione_dcsit"].ToString());

						lbldatavalidDCSIT.Text= dtvalidazionedcsit.ToShortDateString();
						lblOraValidDCSIT.Text=dtvalidazionedcsit.Hour.ToString().PadLeft(2,'0') + ":" + dtvalidazionedcsit.Minute.ToString().PadLeft(2,'0');
					}
					if (_Dr["stato_dcsit"] != DBNull.Value)
						this.lblStatoDCSIT.Text=_Dr["stato_dcsit"].ToString();

					//Se è la fase di completamento carico il resto dei dati
					if(this.IsCompleta)
					{
						
						if(_Dr["tipointervento"].ToString()=="1")//Manutenzione su Richiesta
						{
							trsoddisfazione.Style.Add("display","none");
							trannotazione.Style.Add("display","none");
						}

						//in base allo status visualizzo la riga html
						if (_Dr["idstatus"] != DBNull.Value)
						{
							if  (int.Parse( _Dr["idstatus"].ToString())==8 || int.Parse( _Dr["idstatus"].ToString())==11 || int.Parse( _Dr["idstatus"].ToString())==12
								|| int.Parse( _Dr["idstatus"].ToString())==13 || int.Parse( _Dr["idstatus"].ToString())==14)
								this.trnote.Attributes.Add("style","display:block");
							else
								this.trnote.Attributes.Add("style","display:none");
							//Carico la combo
							LoadStatoLavoro(_Dr["idstatus"].ToString());
						}
						else
						{
							//Carico la combo 
							LoadStatoLavoro("");
							this.trnote.Attributes.Add("style","display:none");
						}

						//nota Sospesa
						if (_Dr["notesospesa"] != DBNull.Value)
							txtsSospesa.Text = _Dr["notesospesa"].ToString();


						if (_Dr["date_start"]!=DBNull.Value)
							CalendarPicker2.Datazione.Text= System.DateTime.Parse(_Dr["date_start"].ToString()).ToShortDateString();

						if (_Dr["date_end"]!=DBNull.Value)
							CalendarPicker3.Datazione.Text= System.DateTime.Parse(_Dr["date_end"].ToString()).ToShortDateString();

						if (_Dr["date_start"]!=DBNull.Value)
						{
							System.DateTime OraIni= System.DateTime.Parse(_Dr["date_start"].ToString());
							cmbsOraInizio.SelectedValue =OraIni.Hour.ToString().PadLeft(2,Convert.ToChar("0"))  ;
							cmbsMinutiInizio.SelectedValue =OraIni.Minute.ToString().PadLeft(2,Convert.ToChar("0")) ;
						}
						if (_Dr["date_end"]!=DBNull.Value)
						{
							System.DateTime OraFine= System.DateTime.Parse(_Dr["date_end"].ToString());      
							cmbsOraFine.SelectedValue =OraFine.Hour.ToString().PadLeft(2,Convert.ToChar("0")) ;
							cmbsMinutiFine.SelectedValue =OraFine.Minute.ToString().PadLeft(2,Convert.ToChar("0"));
						}

						if (_Dr["comments"] != DBNull.Value)
							txtsAnnotazioni.Text = _Dr["comments"].ToString();

						if (_Dr["satisfaction_id"] != DBNull.Value)
							RadioButtonList1.SelectedValue = _Dr["satisfaction_id"].ToString();

	
						if (_Dr["pdfconsuntivo"] != DBNull.Value)
						{
							lblconsuntivo.Text="File Consuntivo: "; 
							LinkConsuntivo.Visible =true;
							LinkConsuntivo.Text=_Dr["pdfconsuntivo"].ToString();
							LinkConsuntivo.NavigateUrl ="javascript:openpdf('" +  this.wr_id.ToString() + "','Consuntivo','" + _Dr["pdfconsuntivo"].ToString().Replace("'","`")  + "');"; 
						}
						else
							lblconsuntivo.Text="Importa Consuntivo(PDF): "; 

						if (_Dr["contabilizzazione"] != DBNull.Value)
							cmbContabilizzazione.SelectedValue = _Dr["contabilizzazione"].ToString();

						if (_Dr["idstatus"] != DBNull.Value)
							if (_Dr["idstatus"].ToString()=="4")//Attività completata.
								btnCompleta.Enabled=false;//Disabilito il bottone del completamento
						
 
					}
				}
			
		}


		#region Caricamento dei dati nelle combo
        /// <summary>
        /// Carcica le combo con i valori di default
        /// </summary>
		private void BindCombo()
		{
		 LoadUrgenze();
		 LoadTipoManutenzione();
		 LoadTipoTrasimissione();
		 LoadTipoIntervento();
	
		}

			
		
        /// <summary>
        /// Carica gli stati di lavoro di una richiesta
        /// </summary>
        /// <param name="stato_id"></param>
		private void LoadStatoLavoro(string stato_id)
		{
			this.cmbsstatolavoro.Items.Clear();		
		    

			DataSet _MyDs = _ClManCorrettiva.GetStatoLavoro();

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsstatolavoro.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "id", "- Selezionare lo Stato di Lavoro  -", "");
				this.cmbsstatolavoro.DataTextField = "descrizione";
				this.cmbsstatolavoro.DataValueField = "id";
				this.cmbsstatolavoro.DataBind();

				if(stato_id!="")
			
						if(stato_id!="3")
							foreach (ListItem ite in this.cmbsstatolavoro.Items)
							{
								if(ite.Value=="3")
									this.cmbsstatolavoro.Items.Remove(ite);
							}
                             
                        
						if(stato_id=="3" || stato_id=="4")//accorpata e completata
						{
							UploadFileCosto.Visible=false;
							this.btnApprova.Enabled =false;
							cmbsstatolavoro.Enabled =false;
						}
						else
							lblconsuntivo.Text="";

						this.cmbsstatolavoro.SelectedValue =stato_id;

			        this.cmbsstatolavoro.Attributes.Add("OnChange","SetWorkType(this.value);");

			}
			else
			{
				string s_Messagggio = "- Nessuno Stato di Lavoro  -";
				this.cmbsstatolavoro.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}

			if (cmbsstatolavoro.SelectedValue=="4")
				BtnCostiOpera.Visible=false;

		}
		/// <summary>
		/// carica gli addetti in base ad una ditta ed ad un edificio
		/// </summary>
		/// <param name="bl_id"></param>
		/// <param name="ditta_id"></param>
		private void LoadAddettiDitta(string bl_id,int ditta_id)
		{	
			this.cmbsAddetto.Items.Clear();				
			

			DataSet _MyDs;

			_MyDs = _ClManCorrettiva.GetAddetti("",bl_id,ditta_id);
			

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsAddetto.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "NOMINATIVO", "ID", "- Selezionare un Addetto -", "");
				this.cmbsAddetto.DataTextField = "NOMINATIVO";
				this.cmbsAddetto.DataValueField = "ID";
				this.cmbsAddetto.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Addetto  -";
				this.cmbsAddetto.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, ""));
			}
		
		}
		/// <summary>
		/// Carico le apparechiature
		/// </summary>
		private void LoadApparechiature()
		{
			if (this.cmbsServizio.SelectedIndex==0)
			{
				cmbEQ.Items.Clear();
				string s_Messagggio = "- Nessuna Apparecchiatura -";
				this.cmbEQ.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
			else
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
				s_p_Bl_Id.Value = "";
				_SCollection.Add(s_p_Bl_Id);

				S_Controls.Collections.S_Object s_p_campus = new S_Controls.Collections.S_Object();
				s_p_campus.ParameterName = "p_campus";
				s_p_campus.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				s_p_campus.Direction = ParameterDirection.Input;
				s_p_campus.Index = 1;
				s_p_campus.Size=50;
				s_p_campus.Value = lblfabbricato.Text;
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
				s_p_eqstdid.Value = (cmdsStdApparecchiatura.SelectedValue==string.Empty)? 0:Int32.Parse(cmdsStdApparecchiatura.SelectedValue);
				_SCollection.Add(s_p_eqstdid);

				S_Controls.Collections.S_Object s_p_eq_id = new S_Controls.Collections.S_Object();
				s_p_eq_id.ParameterName = "p_eq_id";
				s_p_eq_id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				s_p_eq_id.Direction = ParameterDirection.Input;
				s_p_eq_id.Size =8;
				s_p_eq_id.Index = 4;
				s_p_eq_id.Size =50;
				s_p_eq_id.Value = (cmbEQ.SelectedValue==string.Empty)? "":cmbEQ.Items[cmbEQ.SelectedIndex].Text;
				_SCollection.Add(s_p_eq_id);

				S_Controls.Collections.S_Object p_dismesso = new S_Controls.Collections.S_Object();
				p_dismesso.ParameterName = "p_dismesso";
				p_dismesso.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
				p_dismesso.Direction = ParameterDirection.Input;
				p_dismesso.Size =8;
				p_dismesso.Index = 4;
				p_dismesso.Size =50;
				p_dismesso.Value = 1;
				_SCollection.Add(p_dismesso);

				//Piano
				S_Controls.Collections.S_Object s_p_idpiano = new S_Controls.Collections.S_Object();
				s_p_idpiano.ParameterName = "p_idpiano";
				s_p_idpiano.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
				s_p_idpiano.Direction = ParameterDirection.Input;
				s_p_idpiano.Size =8;
				s_p_idpiano.Index = 5;
				s_p_idpiano.Value = 0;
				_SCollection.Add(s_p_idpiano);

				//stanza
				S_Controls.Collections.S_Object s_p_idstanza = new S_Controls.Collections.S_Object();
				s_p_idstanza.ParameterName = "p_idstanza";
				s_p_idstanza.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
				s_p_idstanza.Direction = ParameterDirection.Input;
				s_p_idstanza.Size =8;
				s_p_idstanza.Index = 6;
				s_p_idstanza.Value = 0;
				_SCollection.Add(s_p_idstanza);
				///Aggiungo i parametri alla collection
				
				DataSet _MyDs=_ClManCorrettiva.GetApparecchiatura(_SCollection);

				if (_MyDs.Tables[0].Rows.Count > 0)
				{
					this.cmbEQ.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
						_MyDs.Tables[0], "ID", "id_eq", "- Selezionare un' Apparecchiatura -", "");
					this.cmbEQ.DataTextField = "ID";
					this.cmbEQ.DataValueField = "id_eq";
					this.cmbEQ.DataBind();
				}
				else
				{
					cmbEQ.Items.Clear();
					string s_Messagggio = "- Nessuna Apparecchiatura -";
					this.cmbEQ.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
				}	
			}
		}

        /// <summary>
        /// Carico gli standard apparechiature
        /// </summary>
		private void LoadStandardApparechiature()
		{
			
			if (this.cmbsServizio.SelectedIndex==0)
			{
				cmdsStdApparecchiatura.Items.Clear();
				string s_Messagggio = "- Nessuno Standard -";
				this.cmdsStdApparecchiatura.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
			else
			{
				this.cmdsStdApparecchiatura.Items.Clear();
			
				DataSet _MyDs;

				S_ControlsCollection _SColl = new S_ControlsCollection();

				S_Controls.Collections.S_Object s_BlId = new S_Object();
				s_BlId.ParameterName = "p_Bl_Id";
				s_BlId.DbType = CustomDBType.VarChar;
				s_BlId.Direction = ParameterDirection.Input;
				s_BlId.Size =50;
				s_BlId.Index = 0;
				s_BlId.Value = txtHidBl.Text;
				_SColl.Add(s_BlId);
		
				S_Controls.Collections.S_Object s_Servizio = new S_Object();
				s_Servizio.ParameterName = "p_Servizio";
				s_Servizio.DbType = CustomDBType.Integer;
				s_Servizio.Direction = ParameterDirection.Input;
				s_Servizio.Index = 1;
				s_Servizio.Value = (cmbsServizio.SelectedValue=="")? 0:Int32.Parse(cmbsServizio.SelectedValue);
				_SColl.Add(s_Servizio);

				_MyDs = _ClManCorrettiva.GetStandardApparechiature(_SColl);
           
  
				if (_MyDs.Tables[0].Rows.Count > 0)
				{
					this.cmdsStdApparecchiatura.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
						_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Standard -", "");
					this.cmdsStdApparecchiatura.DataTextField = "DESCRIZIONE";
					this.cmdsStdApparecchiatura.DataValueField = "ID";
					this.cmdsStdApparecchiatura.DataBind();
				}
				else
				{
					cmdsStdApparecchiatura.Items.Clear();
					string s_Messagggio = "- Nessuno Standard -";
					this.cmdsStdApparecchiatura.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
				}
			}
		}
		/// <summary>
		/// Carica le ditte addette alla manutenzione per un edificio
		/// </summary>
		/// <param name="idbl"></param>
		private void LoadDitte(int bl_id)
		{	
			cmbsDitta.Items.Clear();			
						// Attraverso l'IDBL mi ricavo l'ID della Ditta
			int idditta=0;
		
			DataSet _MyDsDittaBl;
			_MyDsDittaBl=_ClManCorrettiva.GetDittaMasterBl(bl_id);			
			DataRow _DrBl = _MyDsDittaBl.Tables[0].Rows[0];
			idditta= Int32.Parse(_DrBl["id_ditta"].ToString());			
			
			DataSet _MyDs = _ClManCorrettiva.GetDitteFornitoriRuoli(idditta);

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
//				this.cmbsDitta.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
//					_MyDs.Tables[0], "DESCRIZIONE", "id", "- Selezionare una Ditta -", "");
				this.cmbsDitta.DataSource=_MyDs.Tables[0];
				this.cmbsDitta.DataTextField = "DESCRIZIONE";
				this.cmbsDitta.DataValueField = "id";
				this.cmbsDitta.DataBind();
				//Sezione aggiunta su richiesta
				this.cmbsDitta.SelectedValue="1";
				LoadAddettiDitta("",1);
			}
			
			else
			{
				string s_Messagggio = "- Nessuna Ditta  -";
				this.cmbsDitta.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}
		/// <summary>
		/// Carica l'elenco delle modalità di trasmissione
		/// </summary>
		private void LoadTipoTrasimissione()
		{
			this.cmbsTrasmissione.Items.Clear();		
	
			DataSet _MyDs = _ClManCorrettiva.GetAllTipoTrasmissione();

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsTrasmissione.DataSource = _MyDs.Tables[0];
				this.cmbsTrasmissione.DataTextField = "descrizione";
				this.cmbsTrasmissione.DataValueField = "ID";
				this.cmbsTrasmissione.DataBind();
				this.cmbsTrasmissione.SelectedIndex=1;
			}
			else
			{
				string s_Messagggio = "- Nessuna Trasmissione  -";
				this.cmbsTrasmissione.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}

		}
		/// <summary>
		/// Carica il Tipo di manutenzione
		/// </summary>
		private void LoadTipoManutenzione()
		{
		
			DataSet _MyDs =  _ClManCorrettiva.GetTipoManutenzione();

			if (_MyDs.Tables[0].Rows.Count>0)
			{
				cmbsTipoManutenzione.DataSource = _MyDs;
				this.cmbsTipoManutenzione.DataTextField = "descrizione";
				this.cmbsTipoManutenzione.DataValueField = "id";
				this.cmbsTipoManutenzione.DataBind();
				//cmbsTipoIntervento.SelectedIndex=2;
                this.cmbsTipoManutenzione.Attributes.Add("OnChange","SetPreventivo(this.value);"); 

				//mbsTipoInterventoDl.SelectedIndex=2;
			}	
		}
		/// <summary>
		/// Carica i Servizi di un detereminato edificio
		/// </summary>
		/// <param name="CodiceEdificio"></param>
		private void LoadService(string CodiceEdificio)
		{
			this.cmbsServizio.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			DataSet _MyDs;

		
				S_Controls.Collections.S_Object s_Bl_Id = new S_Object();
				s_Bl_Id.ParameterName = "p_Bl_Id";
				s_Bl_Id.DbType = CustomDBType.VarChar;
				s_Bl_Id.Direction = ParameterDirection.Input;
				s_Bl_Id.Index = 0;
				s_Bl_Id.Value =	CodiceEdificio;
				s_Bl_Id.Size = 8;

				
				S_Controls.Collections.S_Object s_ID_Servizio = new S_Object();
				s_ID_Servizio.ParameterName = "p_ID_Servizio";
				s_ID_Servizio.DbType = CustomDBType.Integer;
				s_ID_Servizio.Direction = ParameterDirection.Input;
				s_ID_Servizio.Index = 1;
				s_ID_Servizio.Value = 0;

				CollezioneControlli.Add(s_Bl_Id);				
				CollezioneControlli.Add(s_ID_Servizio);

				_MyDs = _ClManCorrettiva.GetServiceBulding(CollezioneControlli);

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "Non Definito", "");
				this.cmbsServizio.DataTextField = "DESCRIZIONE";
				this.cmbsServizio.DataValueField = "IDSERVIZIO";
				this.cmbsServizio.DataBind();
			}
			else
			{
				string s_Messagggio = "Non Definito";
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, ""));
			}
		}
		/// <summary>
		/// Carico la lista del livello di urgenza dell'intervento
		/// </summary>
		private void LoadUrgenze()
		{
			//Carico il combo delle Urgenze	
			DataSet _MyDs=_ClManCorrettiva.GetPriority();
			if (_MyDs.Tables[0].Rows.Count>0)
			{
				this.cmbsUrgenza.DataSource = _MyDs;
				this.cmbsUrgenza.DataTextField = "PRIORITY";
				this.cmbsUrgenza.DataValueField = "IDP";
				this.cmbsUrgenza.DataBind();
				this.cmbsUrgenza.SelectedIndex=5;

			}
		}
		private void LoadTipoIntervento()
		{
		
			//Caricol il combo Del Tipo Intervento
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
		#endregion

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
			this.cmdsStdApparecchiatura.SelectedIndexChanged += new System.EventHandler(this.cmdsStdApparecchiatura_SelectedIndexChanged);
			this.btsApprovaDCSIT.Click += new System.EventHandler(this.btsApprovaDCSIT_Click);
			this.btsRifiutaDCSIT.Click += new System.EventHandler(this.btsRifiutaDCSIT_Click);
			this.btsApprovaDL.Click += new System.EventHandler(this.btsApprovaDL_Click);
			this.btsRifiutaDL.Click += new System.EventHandler(this.btsRifiutaDL_Click);
			this.cmbsDitta.SelectedIndexChanged += new System.EventHandler(this.cmbsDitta_SelectedIndexChanged);
			this.btnRifiuta.Click += new System.EventHandler(this.btnRifiuta_Click);
			this.btnSospendi.Click += new System.EventHandler(this.btnSospendi_Click);
			this.btnApprova.Click += new System.EventHandler(this.btnApprova_Click);
			this.btnCompleta.Click += new System.EventHandler(this.btnCompleta_Click);
			this.btnfoglioprestazioni.Click += new System.EventHandler(this.btnfoglioprestazioni_Click);
			this.btnfoglioprestazioniPdf.Click += new System.EventHandler(this.btnfoglioprestazioniPdf_Click);
			this.BtnCostiOpera.Click += new System.EventHandler(this.BtnCostiOpera_Click);
			this.btnChiudicompleta.Click += new System.EventHandler(this.btnChiudicompleta_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmbsServizio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LoadStandardApparechiature();
			LoadApparechiature();
		}

		private void cmdsStdApparecchiatura_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		 LoadApparechiature();
		}


		private void btnApprova_Click(object sender, System.EventArgs e)
		{
			// 6 (Emessa) è la Stato che vado ad impostare alla RDL
			//Imposto il controllo di validazione sulla Data
			AggiornaRdl(TheSite.Classi.StateType.EmessaInLavorazione);
		}
		private void ScriptRapportoTecnico(int wo_id)
		{
			string pagina="RapportoTecnicoIntervento.aspx?WO_Id=" + wo_id.ToString();
			string s_TestataScript = "<script language=\"javascript\">\n";
			string funz="ApriPopUp('"+ pagina +"')";
			string s_CodaScript = "</script>\n";
			string funzione=s_TestataScript + funz + s_CodaScript;
			this.Page.RegisterStartupScript("funz",funzione);
			
		}
		#region Gestione della Richiesta Approva Sospendi Emetti
		private void AggiornaRdl(TheSite.Classi.StateType status_id)
		{			
	
			S_ControlsCollection _SColl = new S_ControlsCollection();

			// WR_ID
			S_Controls.Collections.S_Object s_IdWR = new S_Object();
			s_IdWR.ParameterName = "p_Wr_Id";
			s_IdWR.DbType = CustomDBType.Integer;
			s_IdWR.Direction = ParameterDirection.Input;
			s_IdWR.Index = _SColl.Count;
			s_IdWR.Value = this.wr_id;
			_SColl.Add(s_IdWR);	
			
			// STATUS_ID
			S_Controls.Collections.S_Object s_IdStatus = new S_Object();
			s_IdStatus.ParameterName = "p_stato";
			s_IdStatus.DbType = CustomDBType.Integer;
			s_IdStatus.Direction = ParameterDirection.Input;
			s_IdStatus.Index = _SColl.Count;
			s_IdStatus.Value = (int)status_id;			
			_SColl.Add(s_IdStatus);	
			
			// URGENZA
			S_Controls.Collections.S_Object s_Urgenza = new S_Object();
			s_Urgenza.ParameterName = "p_urgenza";
			s_Urgenza.DbType = CustomDBType.Integer;
			s_Urgenza.Direction = ParameterDirection.Input;
			s_Urgenza.Index = _SColl.Count;
			s_Urgenza.Value = Int32.Parse(cmbsUrgenza.SelectedValue.Split(Convert.ToChar(","))[0]);;	
			_SColl.Add(s_Urgenza);
			 
			// RICHIEDENTE

			S_Controls.Collections.S_Object s_Richiedente = new S_Object();
			s_Richiedente.ParameterName = "p_richiedente";
			s_Richiedente.DbType = CustomDBType.VarChar;
			s_Richiedente.Direction = ParameterDirection.Input;
			s_Richiedente.Index = _SColl.Count;
			s_Richiedente.Size=35;
			s_Richiedente.Value = lblRichiedente.Text;
			_SColl.Add(s_Richiedente);
			
			// DESCRIZIONE

			S_Controls.Collections.S_Object s_Descrizione = new S_Object();
			s_Descrizione.ParameterName = "p_descrizione";
			s_Descrizione.DbType = CustomDBType.VarChar;
			s_Descrizione.Direction = ParameterDirection.Input;
			s_Descrizione.Index = _SColl.Count;
			s_Descrizione.Size=4000;
			s_Descrizione.Value = txtsDescrizione.Text;
			_SColl.Add(s_Descrizione);
			
			// DATAPIANIFICATA

			S_Controls.Collections.S_Object s_DataP = new S_Object();
			s_DataP.ParameterName = "p_datapianificata";
			s_DataP.DbType = CustomDBType.VarChar;
			s_DataP.Direction = ParameterDirection.Input;
			s_DataP.Index = _SColl.Count;			
			s_DataP.Size=30;
			//Data Pianificata	
			string data_pianificata="";
			string data_p=CalendarPicker1.Datazione.Text;
			if(data_p!="")
			{ 
				string ora_p= ((cmbsOre.SelectedValue=="")?"00":cmbsOre.SelectedValue) + ":" + ((cmbsMinuti.SelectedValue=="")?"00":cmbsMinuti.SelectedValue) + ":00";
				data_pianificata = data_p + " " + ora_p;  
			}
			s_DataP.Value = data_pianificata;
			_SColl.Add(s_DataP);
			
			// SERVIZIO

			S_Controls.Collections.S_Object s_Servizio = new S_Object();
			s_Servizio.ParameterName = "p_servizio_id";
			s_Servizio.DbType = CustomDBType.Integer;
			s_Servizio.Direction = ParameterDirection.Input;
			s_Servizio.Index = _SColl.Count;
			s_Servizio.Value = (cmbsServizio.SelectedValue=="")?0:Int32.Parse(cmbsServizio.SelectedValue);
			_SColl.Add(s_Servizio);
			
			// TRASMISSIONE

			S_Controls.Collections.S_Object s_Trasmissione = new S_Object();
			s_Trasmissione.ParameterName = "p_trasmissione_id";
			s_Trasmissione.DbType = CustomDBType.Integer;
			s_Trasmissione.Direction = ParameterDirection.Input;
			s_Trasmissione.Index = _SColl.Count;
			s_Trasmissione.Value = Int32.Parse(cmbsTrasmissione.SelectedValue);
			_SColl.Add(s_Trasmissione);
			
			// MANUTENZIONE

			S_Controls.Collections.S_Object s_Manutenzione = new S_Object();
			s_Manutenzione.ParameterName = "p_manutenzione_id";
			s_Manutenzione.DbType = CustomDBType.Integer;
			s_Manutenzione.Direction = ParameterDirection.Input;
			s_Manutenzione.Index = _SColl.Count;
			s_Manutenzione.Value = Int32.Parse(cmbsTipoManutenzione.SelectedValue);
			_SColl.Add(s_Manutenzione);
			
			// BL_ID

			S_Controls.Collections.S_Object s_BL = new S_Object();
			s_BL.ParameterName = "p_bl_id";
			s_BL.DbType = CustomDBType.Integer;
			s_BL.Direction = ParameterDirection.Input;
			s_BL.Index = _SColl.Count;
			s_BL.Value = this.bl_id;
			_SColl.Add(s_BL);			
			
			// ADDETTO_ID

			S_Controls.Collections.S_Object s_Addetto = new S_Object();
			s_Addetto.ParameterName = "p_addetto_id";
			s_Addetto.DbType = CustomDBType.Integer;
			s_Addetto.Direction = ParameterDirection.Input;
			s_Addetto.Index = _SColl.Count;
			s_Addetto.Value = (cmbsAddetto.SelectedValue=="")?0:int.Parse(cmbsAddetto.SelectedValue);
			_SColl.Add(s_Addetto);
			
			// ID_DITTA
			S_Controls.Collections.S_Object p_id_ditta = new S_Object();
			p_id_ditta.ParameterName = "p_id_ditta";
			p_id_ditta.DbType = CustomDBType.Integer;
			p_id_ditta.Direction = ParameterDirection.Input;
			p_id_ditta.Index = _SColl.Count;
			p_id_ditta.Value = (cmbsDitta.SelectedValue=="")?0:int.Parse(cmbsDitta.SelectedValue);
			_SColl.Add(p_id_ditta);
			
			// STD APPARECCHIATURA
			S_Controls.Collections.S_Object p_stdApparecchiatura_id = new S_Object();
			p_stdApparecchiatura_id.ParameterName = "p_stdApparecchiatura_id";
			p_stdApparecchiatura_id.DbType = CustomDBType.Integer;
			p_stdApparecchiatura_id.Direction = ParameterDirection.Input;
			p_stdApparecchiatura_id.Index = _SColl.Count;
			p_stdApparecchiatura_id.Value = (cmdsStdApparecchiatura.SelectedValue=="")?0:int.Parse(cmdsStdApparecchiatura.SelectedValue);
			_SColl.Add(p_stdApparecchiatura_id);
	
			// APPARECCHIATURA
			S_Controls.Collections.S_Object p_eq_id = new S_Object();
			p_eq_id.ParameterName = "p_eq_id";
			p_eq_id.DbType = CustomDBType.Integer;
			p_eq_id.Direction = ParameterDirection.Input;
			p_eq_id.Index = _SColl.Count;
			p_eq_id.Value = (cmbEQ.SelectedValue=="")?0:int.Parse(cmbEQ.SelectedValue);
			_SColl.Add(p_eq_id);
			 
			
			
			try
			{										
				int wo_id = _ClManCorrettiva.EmettiRdl(_SColl,status_id);	
				if (wo_id!=0)
				{
					//string Result= UploadFile(UploadFilePreventivo,TipoPostFile.Preventivo);
					if (status_id==TheSite.Classi.StateType.EmessaInLavorazione)
						ScriptRapportoTecnico(wo_id);

					btnRifiuta.Enabled=false;
					btnSospendi.Enabled=false;
					btnApprova.Enabled=false;
				}
			
									
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
				
			}
	
		}
		#endregion

		private void btnRifiuta_Click(object sender, System.EventArgs e)
		{
			AggiornaRdl(Classi.StateType.RichiestaRifiutata);
			
		}

		private void btnSospendi_Click(object sender, System.EventArgs e)
		{
			AggiornaRdl(Classi.StateType.RichiestaSospesa);
			
		}


		private void Chiudi()
		{
			if(this.Page is TheSite.ManutenzioneCorrettiva.EditApprovaEmetti)
				Server.Transfer("ApprovaRdl.aspx?FunID=" + ViewState["FunId"]);
			else if(this.Page is TheSite.ManutenzioneCorrettiva.EditCompletamento)
				Server.Transfer("GestioneCompleta.aspx?FunId=" + ViewState["FunId"]);
			else if(this.Page is TheSite.ManutenzioneCorrettiva.EditCreazione)
				Server.Transfer("CreazioneRdl.aspx?FunId=" + ViewState["FunId"]);
			else if(this.Page is TheSite.ManutenzioneCorrettiva.EditSfoglia)
				Server.Transfer("SfogliaRdl.aspx?FunId=" + ViewState["FunId"]);
		}
		/// <summary>
		/// Aggiorna lo stato della richiesta da parte del DL o del DCSIT
		/// False indica Direttore dei lavori. True indica che si tratta del DCSIT
		/// </summary>
		/// <param name="DCSIT"></param>
		private void AggiornaStatoDCSIT_DL(bool DCSIT,bool Stato)
		{
	
			
			S_ControlsCollection _SColl = new S_ControlsCollection();
            int result=0;
		
			S_Controls.Collections.S_Object p_wr_id = new S_Object();
			p_wr_id.ParameterName = "p_wr_id";
			p_wr_id.DbType = CustomDBType.Integer;
			p_wr_id.Direction = ParameterDirection.Input;
			p_wr_id.Index = _SColl.Count;
			p_wr_id.Value = this.wr_id;
			_SColl.Add(p_wr_id);	

			S_Controls.Collections.S_Object p_ruolo_id = new S_Object();
			p_ruolo_id.ParameterName = "p_ruolo_id";
			p_ruolo_id.DbType = CustomDBType.VarChar;
			p_ruolo_id.Direction = ParameterDirection.Input;
			p_ruolo_id.Index = _SColl.Count;
            if(Context.User.IsInRole("collaboratore"))
			  p_ruolo_id.Value = "collaboratore";
			else 
             p_ruolo_id.Value = "dl";
        
			_SColl.Add(p_ruolo_id);	

			
			S_Controls.Collections.S_Object p_lavori_urgenti = new S_Object();
			p_lavori_urgenti.ParameterName = "p_lavori_urgenti";
			p_lavori_urgenti.DbType = CustomDBType.Integer;
			p_lavori_urgenti.Direction = ParameterDirection.Input;
			p_lavori_urgenti.Index = _SColl.Count;
			if(DCSIT==false)
				p_lavori_urgenti.Value = (checkQuantifica.Checked==true)?1:0;
			else
              p_lavori_urgenti.Value =DBNull.Value;
			_SColl.Add(p_lavori_urgenti);

			S_Controls.Collections.S_Object stato = new S_Object();
			stato.ParameterName = "p_stato";
			stato.DbType = CustomDBType.Integer;
			stato.Direction = ParameterDirection.Input;
			stato.Index = _SColl.Count;
			if(DCSIT==false)
			  stato.Value =(Stato==true)?3:4;
			else
               stato.Value =(Stato==true)?1:2;
 
			_SColl.Add(stato);

			S_Controls.Collections.S_Object tipo_manutenzione = new S_Object();
			tipo_manutenzione.ParameterName = "p_tipo_manutenzione";
			tipo_manutenzione.DbType = CustomDBType.Integer;
			tipo_manutenzione.Direction = ParameterDirection.Input;
			tipo_manutenzione.Index = _SColl.Count;
			if(DCSIT==false)
			  tipo_manutenzione.Value =int.Parse(cmbsTipoManutenzione.SelectedValue);
			else
			  tipo_manutenzione.Value = DBNull.Value;
			
			_SColl.Add(tipo_manutenzione);	


			S_Controls.Collections.S_Object p_tipo_intervento  = new S_Object();
			p_tipo_intervento.ParameterName = "p_tipo_intervento";
			p_tipo_intervento.DbType = CustomDBType.Integer;
			p_tipo_intervento.Direction = ParameterDirection.Input;
			p_tipo_intervento.Index = _SColl.Count;
			if(DCSIT==false)
				if (cmbsTipoIntrevento.SelectedValue=="")
				  p_tipo_intervento.Value =DBNull.Value;
			    else
				  p_tipo_intervento.Value =int.Parse(cmbsTipoIntrevento.SelectedValue);
			else
				p_tipo_intervento.Value = DBNull.Value;
			
			_SColl.Add(p_tipo_intervento);


			S_Controls.Collections.S_Object p_importo_presunto   = new S_Object();
			p_importo_presunto.ParameterName = "p_importo_presunto";
			p_importo_presunto.DbType = CustomDBType.Double;
			p_importo_presunto.Direction = ParameterDirection.Input;
			p_importo_presunto.Index = _SColl.Count;
			if(DCSIT==false)
				p_importo_presunto .Value = double.Parse(txtspesaPresunta1.Text + "," + txtspesaPresunta2.Text);
			else
				p_importo_presunto .Value = DBNull.Value;
			
			_SColl.Add(p_importo_presunto);

			S_Controls.Collections.S_Object p_data_presunta_inizio   = new S_Object();
			p_data_presunta_inizio.ParameterName = "p_data_presunta_inizio";
			p_data_presunta_inizio.DbType = CustomDBType.Date;
			p_data_presunta_inizio.Direction = ParameterDirection.Input;
			p_data_presunta_inizio.Index = _SColl.Count;
			if(DCSIT==false)
				if(CalendarPicker4.Datazione.Text=="")
				 p_data_presunta_inizio.Value =DBNull.Value;
				else
                 p_data_presunta_inizio.Value=DateTime.Parse(CalendarPicker4.Datazione.Text);
			else
				p_data_presunta_inizio.Value = DBNull.Value;
			
			_SColl.Add(p_data_presunta_inizio);

			S_Controls.Collections.S_Object p_data_presunta_fine   = new S_Object();
			p_data_presunta_fine.ParameterName = "p_data_presunta_fine";
			p_data_presunta_fine.DbType = CustomDBType.Date;
			p_data_presunta_fine.Direction = ParameterDirection.Input;
			p_data_presunta_fine.Index = _SColl.Count;
			if(DCSIT==false)
				if(CalendarPicker5.Datazione.Text=="")
					p_data_presunta_fine.Value =DBNull.Value;
				else
					p_data_presunta_fine.Value=DateTime.Parse(CalendarPicker5.Datazione.Text);
			else
				p_data_presunta_fine.Value = DBNull.Value;
			
			_SColl.Add(p_data_presunta_fine);

			S_Controls.Collections.S_Object p_ordine_lavoro   = new S_Object();
			p_ordine_lavoro.ParameterName = "p_ordine_lavoro";
			p_ordine_lavoro.DbType = CustomDBType.Integer;
			p_ordine_lavoro.Direction = ParameterDirection.Input;
			p_ordine_lavoro.Index = _SColl.Count;
			if(DCSIT==false)
				if(txtOrdineLavoro.Text=="")
				  p_ordine_lavoro .Value = DBNull.Value;
				else
				  p_ordine_lavoro .Value =int.Parse(txtOrdineLavoro.Text);
			else
				p_ordine_lavoro .Value = DBNull.Value;
			
			_SColl.Add(p_ordine_lavoro);

			// SERVIZIO

			S_Controls.Collections.S_Object s_Servizio = new S_Object();
			s_Servizio.ParameterName = "p_servizio_id";
			s_Servizio.DbType = CustomDBType.Integer;
			s_Servizio.Direction = ParameterDirection.Input;
			s_Servizio.Index = _SColl.Count;

			s_Servizio.Value = (cmbsServizio.SelectedValue=="")?0:Int32.Parse(cmbsServizio.SelectedValue);
			_SColl.Add(s_Servizio);			
			
			// TRASMISSIONE

			S_Controls.Collections.S_Object s_Trasmissione = new S_Object();
			s_Trasmissione.ParameterName = "p_trasmissione_id";
			s_Trasmissione.DbType = CustomDBType.Integer;
			s_Trasmissione.Direction = ParameterDirection.Input;
			s_Trasmissione.Index = _SColl.Count;
			s_Trasmissione.Value = Int32.Parse(cmbsTrasmissione.SelectedValue);
			_SColl.Add(s_Trasmissione);

			// STD APPARECCHIATURA
			S_Controls.Collections.S_Object p_stdApparecchiatura_id = new S_Object();
			p_stdApparecchiatura_id.ParameterName = "p_stdApparecchiatura_id";
			p_stdApparecchiatura_id.DbType = CustomDBType.Integer;
			p_stdApparecchiatura_id.Direction = ParameterDirection.Input;
			p_stdApparecchiatura_id.Index = _SColl.Count;
			p_stdApparecchiatura_id.Value = (cmdsStdApparecchiatura.SelectedValue=="")?0:int.Parse(cmdsStdApparecchiatura.SelectedValue);
			_SColl.Add(p_stdApparecchiatura_id);
	
			// APPARECCHIATURA
			S_Controls.Collections.S_Object p_eq_id = new S_Object();
			p_eq_id.ParameterName = "p_eq_id";
			p_eq_id.DbType = CustomDBType.Integer;
			p_eq_id.Direction = ParameterDirection.Input;
			p_eq_id.Index = _SColl.Count;
			p_eq_id.Value = (cmbEQ.SelectedValue=="")?0:int.Parse(cmbEQ.SelectedValue);
			_SColl.Add(p_eq_id);

			//marianna
			//Numero preventivo
			S_Controls.Collections.S_Object p_numeropreventivo = new S_Object();
			p_numeropreventivo.ParameterName = "p_numeropreventivo";
			p_numeropreventivo.DbType = CustomDBType.VarChar;
			p_numeropreventivo.Direction = ParameterDirection.Input;
			p_numeropreventivo.Index = 16;
			p_numeropreventivo.Size =_SColl.Count;
			p_numeropreventivo.Value = txtNumeroPreventivo.Text;
			_SColl.Add(p_numeropreventivo);
			
			//importo preventivo
			S_Controls.Collections.S_Object p_importopreventivo = new S_Object();
			p_importopreventivo.ParameterName = "p_importopreventivo";
			p_importopreventivo.DbType = CustomDBType.Double;
			p_importopreventivo.Direction = ParameterDirection.Input;
			p_importopreventivo.Index = _SColl.Count;
			if(txtSpesa1.Text=="")
				p_importopreventivo.Value =DBNull.Value;
			else
				p_importopreventivo.Value =double.Parse(txtSpesa1.Text + "," + txtSpesa2.Text); 
			_SColl.Add(p_importopreventivo);
			
			//Nome del file pdf
			S_Controls.Collections.S_Object p_pdfpreventivo = new S_Object();
			p_pdfpreventivo.ParameterName = "p_pdfpreventivo";
			p_pdfpreventivo.DbType = CustomDBType.VarChar;
			p_pdfpreventivo.Direction = ParameterDirection.Input;
			p_pdfpreventivo.Index =_SColl.Count;
			p_pdfpreventivo.Size =250;
			p_pdfpreventivo.Value = GetNameFileUpload(UploadFilePreventivo);
			_SColl.Add(p_pdfpreventivo);
//marianna


			// DESCRIZIONE

			S_Controls.Collections.S_Object s_Descrizione = new S_Object();
			s_Descrizione.ParameterName = "p_descrizione";
			s_Descrizione.DbType = CustomDBType.VarChar;
			s_Descrizione.Direction = ParameterDirection.Input;
			s_Descrizione.Index = _SColl.Count;
			s_Descrizione.Size=4000;
			s_Descrizione.Value = txtsDescrizione.Text;
			_SColl.Add(s_Descrizione);

			if(DCSIT==false)
				if(this.dl_id==0)
//				{
					this.dl_id= _ClManCorrettiva.AddDCSTI_DL(_SColl,DCSIT);
//					result=this.dl_id;
//				}
				else
					result= _ClManCorrettiva.UpdateDCSTI_DL(_SColl,this.dl_id,DCSIT);
			else
				if(this.dcsit_id==0)
				  this.dcsit_id= _ClManCorrettiva.AddDCSTI_DL(_SColl,DCSIT);
			    else
				 result= _ClManCorrettiva.UpdateDCSTI_DL(_SColl,this.dcsit_id,DCSIT);
			
//			if (result!=0)
//			{
				string Result= UploadFile(UploadFilePreventivo,TipoPostFile.Preventivo);
//			}
			if(lblemailric.Text.Trim()!="" && !(DCSIT==true && Stato==true))
			{
				///Recupero la via dell'edificio
				DataSet _DsinfoBl= _ClManCorrettiva.GetDatiEdificio(this.wr_id);
				string Via=_DsinfoBl.Tables[0].Rows[0]["Via"].ToString();

				System.Web.Mail.MailMessage _messaggio=new System.Web.Mail.MailMessage();
				_messaggio.From =System.Configuration.ConfigurationSettings.AppSettings["MailFrom"];
				_messaggio.Subject="Avviso di cambio di stato di una richiesta di lavoro."; 
				_messaggio.To =lblemailric.Text.Trim();
							    
				Classi.ClassMail _Mail=new TheSite.Classi.ClassMail();
				_messaggio.BodyFormat =System.Web.Mail.MailFormat.Html; 
				_Mail.Messaggio =_messaggio;
				_Mail.CodiceEdificio=Via;
				_Mail.Idrichiesta=this.wr_id.ToString();
				_Mail.Name=lblRichiedente.Text.Trim();
				// _Mail.Surname=(Stato==true)?"approvata":"rifiutata";
				_Mail.Surname=(Stato==true)?"emessa in lavorazione":"rifiutata";
				_Mail.Responsabile =(DCSIT==true)?"dal collaboratore":"del direttore dei lavori";
				_Mail.Decription=txtsDescrizione.Text.Trim();
				_Mail.SendMail(Classi.ClassMail.TipoMail.MailEmissioneRichiesta);
			}

			
			LoadDatiCreazione();
		}

		private void btsApprovaDCSIT_Click(object sender, System.EventArgs e)
		{
		
			AggiornaStatoDCSIT_DL(true,true);
		}

		private void btsRifiutaDCSIT_Click(object sender, System.EventArgs e)
		{
			AggiornaStatoDCSIT_DL(true,false);
		}

		private void btsApprovaDL_Click(object sender, System.EventArgs e)
		{
			AggiornaStatoDCSIT_DL(false,true);
		}

		private void btsRifiutaDL_Click(object sender, System.EventArgs e)
		{
			AggiornaStatoDCSIT_DL(false,false);
		}

		private void cmbsDitta_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbsDitta.SelectedIndex>0)
			{
				LoadAddettiDitta("",Int32.Parse(cmbsDitta.SelectedValue.ToString()));
			}
			else
			{
				LoadAddettiDitta("-1",-1);
			}

		}

		/// <summary>
		/// Ritorna il nome del file che verrà postato al server
		/// </summary>
		/// <param name="FileUpload"></param>
		/// <returns></returns>
		private string GetNameFileUpload(System.Web.UI.HtmlControls.HtmlInputFile FileUpload)
		{
			if (FileUpload.PostedFile!=null && FileUpload.PostedFile.FileName!="") 
				return  System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);	
			else
				return "";
		}

		/// <summary>
		/// Upload del file sul server
		/// </summary>
		/// <param name="FileUpload"></param>
		/// <returns></returns>
		private string UploadFile(System.Web.UI.HtmlControls.HtmlInputFile FileUpload,TipoPostFile Tipologia)
		{
			if (FileUpload.PostedFile!=null && FileUpload.PostedFile.FileName!="") 
			{
				try
				{
					string fileName= System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);

					string destDir =Server.MapPath("../Doc_DB");
					//Creazione del percorso dove il file va inserito
					string folderParent="Correttiva";
					string folderChild=this.wr_id.ToString();
					//Creo la directory della Straordinaria	
					folderParent=System.IO.Path.Combine(destDir, folderParent);
					if (!Directory.Exists(folderParent))
						Directory.CreateDirectory(folderParent);
					//Creo la directory in base al WRID	
					folderChild=System.IO.Path.Combine(folderParent, folderChild);
					if (!Directory.Exists(folderChild))
						Directory.CreateDirectory(folderChild);	

					folderChild=System.IO.Path.Combine(folderChild, (Tipologia==TipoPostFile.Preventivo)?"Preventivo":"Consuntivo");
					if (!Directory.Exists(folderChild))
						Directory.CreateDirectory(folderChild);	

					string destPath  = System.IO.Path.Combine(folderChild, fileName);

					FileUpload.PostedFile.SaveAs(destPath);				
					return fileName;
				}
				catch (Exception ex)
				{
					
					Console.WriteLine(ex.Message);
					return "";
				}
			}
			else 
				return "";
		}
		/// <summary>
		/// Routine per disabilitare tutti i controlli in un controllo Padre
		/// </summary>
		/// <param name="c">Controllo Padre</param>
		private void DisableControl(System.Web.UI.Control  c,bool stato)
		{
			foreach(System.Web.UI.Control ctr in c.Controls)
			{
			  if(ctr is WebControl)
                  ((WebControl)ctr).Enabled=false;

				if(ctr is System.Web.UI.HtmlControls.HtmlControl)
				{
					if(stato)
						((HtmlControl)ctr).Attributes.Add("disabled","");
					else
						((HtmlControl)ctr).Attributes.Add("enabled","");
				}

				if(ctr.Controls.Count>0)
					DisableControl(ctr,stato);
			}
		}

		private void btnCompleta_Click(object sender, System.EventArgs e)
		{
		 Completa();
//			if (cmbsstatolavoro.SelectedValue=="4")
//				BtnCostiOpera.Visible=true;
         btnCompleta.Enabled=false;
		}

		#region Gestione della Richiesta Completamento della Richiesta

		private void Completa()
		{
			
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			//ok
			S_Controls.Collections.S_Object s_p_wr_id = new S_Object();
			s_p_wr_id.ParameterName = "p_wr_id";
			s_p_wr_id.DbType = CustomDBType.Integer;
			s_p_wr_id.Direction = ParameterDirection.Input;
			s_p_wr_id.Index = 0;
			s_p_wr_id.Value =this.wr_id;
			CollezioneControlli.Add(s_p_wr_id);
           
			//ok
			S_Controls.Collections.S_Object s_p_urgenza = new S_Object();
			s_p_urgenza.ParameterName = "p_urgenza";
			s_p_urgenza.DbType = CustomDBType.Integer;
			s_p_urgenza.Direction = ParameterDirection.Input;
			s_p_urgenza.Index = 1;
			s_p_urgenza.Value =cmbsUrgenza.SelectedValue.Split(Convert.ToChar(","))[0];
			CollezioneControlli.Add(s_p_urgenza);

			//ok
			S_Controls.Collections.S_Object s_p_descrizione = new S_Object();
			s_p_descrizione.ParameterName = "p_descrizione";
			s_p_descrizione.DbType = CustomDBType.VarChar;
			s_p_descrizione.Direction = ParameterDirection.Input;
			s_p_descrizione.Size=4000; 
			s_p_descrizione.Index = 2;
			s_p_descrizione.Value =txtsDescrizione.Text;
			CollezioneControlli.Add(s_p_descrizione);


			//ok
			S_Controls.Collections.S_Object s_p_id_ditta = new S_Object();
			s_p_id_ditta.ParameterName = "p_id_ditta";
			s_p_id_ditta.DbType = CustomDBType.Integer;
			s_p_id_ditta.Direction = ParameterDirection.Input;
			s_p_id_ditta.Index = 3;
			s_p_id_ditta.Value =cmbsDitta.SelectedValue;
			CollezioneControlli.Add(s_p_id_ditta);

			//ok
			S_Controls.Collections.S_Object s_p_intervento = new S_Object();
			s_p_intervento.ParameterName = "p_intervento";
			s_p_intervento.DbType = CustomDBType.Integer;
			s_p_intervento.Direction = ParameterDirection.Input;
			s_p_intervento.Index = 4;
			s_p_intervento.Value =cmbsTipoManutenzione.SelectedValue;
			CollezioneControlli.Add(s_p_intervento);

			//ok
			S_Controls.Collections.S_Object s_p_addetto = new S_Object();
			s_p_addetto.ParameterName = "p_addetto";
			s_p_addetto.DbType = CustomDBType.Integer;
			s_p_addetto.Direction = ParameterDirection.Input;
			s_p_addetto.Index = 5;
			s_p_addetto.Value =cmbsAddetto.SelectedValue;
			CollezioneControlli.Add(s_p_addetto);

			//ok
			S_Controls.Collections.S_Object s_p_datapianificata = new S_Object();
			s_p_datapianificata.ParameterName = "p_datapianificata";
			s_p_datapianificata.DbType = CustomDBType.VarChar;
			s_p_datapianificata.Direction = ParameterDirection.Input;
			s_p_datapianificata.Index = 6;
			s_p_datapianificata.Size =30;
			//Data Pianificata	
			string data_pianificata=string.Empty; 
			string data_p=CalendarPicker1.Datazione.Text;
			if(data_p!="")
			{ 
				string ora_p=((cmbsOre.SelectedValue=="")?"00":cmbsOre.SelectedValue) + ":" + ((cmbsMinuti.SelectedValue=="")?"00":cmbsMinuti.SelectedValue) + ":00";
				data_pianificata = data_p + " " + ora_p;  
			}

			s_p_datapianificata.Value =data_pianificata;
			CollezioneControlli.Add(s_p_datapianificata);

			//ok
			S_Controls.Collections.S_Object s_p_id_status = new S_Object();
			s_p_id_status.ParameterName = "p_id_status";
			s_p_id_status.DbType = CustomDBType.Integer;
			s_p_id_status.Direction = ParameterDirection.Input;
			s_p_id_status.Index = 7;
			s_p_id_status.Value =cmbsstatolavoro.SelectedValue;
			CollezioneControlli.Add(s_p_id_status);

			//ok
			S_Controls.Collections.S_Object s_p_date_start = new S_Object();
			s_p_date_start.ParameterName = "p_date_start";
			s_p_date_start.DbType = CustomDBType.VarChar;
			s_p_date_start.Direction = ParameterDirection.Input;
			s_p_date_start.Index = 8;
			s_p_date_start.Size =30;
			//Data Inizio	
			string data_inizio=string.Empty; 
			string date_start=CalendarPicker2.Datazione.Text;
			if(date_start!="")
			{ 
				string ora_Inizio=((cmbsOraInizio.SelectedValue=="")?"00":cmbsOraInizio.SelectedValue) + ":" + ((cmbsMinutiInizio.SelectedValue=="")?"00":cmbsMinutiInizio.SelectedValue) + ":00";
				data_inizio = date_start + " " + ora_Inizio;  
			}

			s_p_date_start.Value =data_inizio;
			CollezioneControlli.Add(s_p_date_start);


			//ok
			S_Controls.Collections.S_Object s_p_date_end = new S_Object();
			s_p_date_end.ParameterName = "p_date_end";
			s_p_date_end.DbType = CustomDBType.VarChar;
			s_p_date_end.Direction = ParameterDirection.Input;
			s_p_date_end.Index = 9;
			s_p_date_end.Size =30;
			//Data Inizio	
			string data_fine=string.Empty; 
			string date_end=CalendarPicker3.Datazione.Text;
			if(date_end!="")
			{ 
				string ora_fine=((cmbsOraFine.SelectedValue=="")?"00":cmbsOraFine.SelectedValue) + ":" + ((cmbsMinutiFine.SelectedValue=="")?"00":cmbsMinutiFine.SelectedValue) + ":00";
				data_fine = date_end + " " + ora_fine;  
			}

			s_p_date_end.Value =data_fine;
			CollezioneControlli.Add(s_p_date_end);


			//Annotazioni Materiale Utilizzato
			S_Controls.Collections.S_Object s_p_comments = new S_Object();
			s_p_comments.ParameterName = "p_comments";
			s_p_comments.DbType = CustomDBType.VarChar;
			s_p_comments.Direction = ParameterDirection.Input;
			s_p_comments.Index = 10;
			s_p_comments.Size =4000;
			s_p_comments.Value =txtsAnnotazioni.Text;
			CollezioneControlli.Add(s_p_comments);


			S_Controls.Collections.S_Object p_satisfaction_id = new S_Object();
			p_satisfaction_id.ParameterName = "p_satisfaction_id";
			p_satisfaction_id.DbType = CustomDBType.Integer;
			p_satisfaction_id.Direction = ParameterDirection.Input;
			p_satisfaction_id.Index = 11;
			p_satisfaction_id.Size =10;
			p_satisfaction_id.Value =RadioButtonList1.SelectedValue;
			CollezioneControlli.Add(p_satisfaction_id);
		

			S_Controls.Collections.S_Object s_p_sospesa = new S_Object();
			s_p_sospesa.ParameterName = "p_sospesa";
			s_p_sospesa.DbType = CustomDBType.VarChar;
			s_p_sospesa.Direction = ParameterDirection.Input;
			s_p_sospesa.Index = 12;
			s_p_sospesa.Size =2000;
			s_p_sospesa.Value =txtsSospesa.Text;
			CollezioneControlli.Add(s_p_sospesa);
			//TODO:Nuovi campi
			S_Controls.Collections.S_Object p_tipointerventoater = new S_Object();
			p_tipointerventoater.ParameterName = "p_tipointerventoater";
			p_tipointerventoater.DbType = CustomDBType.Integer;
			p_tipointerventoater.Direction = ParameterDirection.Input;
			p_tipointerventoater.Index = 13;
			if(cmbsTipoIntrevento.SelectedValue=="" || cmbsTipoIntrevento.SelectedValue=="0")
			  p_tipointerventoater.Value =DBNull.Value;
			else
			  p_tipointerventoater.Value =int.Parse(cmbsTipoIntrevento.SelectedValue);
			CollezioneControlli.Add(p_tipointerventoater);
			//ok
			S_Controls.Collections.S_Object p_importoconsuntivo = new S_Object();
			p_importoconsuntivo.ParameterName = "p_importoconsuntivo";
			p_importoconsuntivo.DbType = CustomDBType.Double;
			p_importoconsuntivo.Direction = ParameterDirection.Input;
			p_importoconsuntivo.Index = 14;
			p_importoconsuntivo.Value =double.Parse(txtSpesa1.Text + "," + txtSpesa2.Text);
			CollezioneControlli.Add(p_importoconsuntivo);
			//ok
			S_Controls.Collections.S_Object p_contabilizzazione = new S_Object();
			p_contabilizzazione.ParameterName = "p_contabilizzazione";
			p_contabilizzazione.DbType = CustomDBType.Integer;
			p_contabilizzazione.Direction = ParameterDirection.Input;
			p_contabilizzazione.Index = 15;
			p_contabilizzazione.Value =1; // SAL1 di default
			CollezioneControlli.Add(p_contabilizzazione);
			//ok
			S_Controls.Collections.S_Object p_pdfconsuntivo = new S_Object();
			p_pdfconsuntivo.ParameterName = "p_pdfconsuntivo";
			p_pdfconsuntivo.DbType = CustomDBType.VarChar;
			p_pdfconsuntivo.Direction = ParameterDirection.Input;
			p_pdfconsuntivo.Index = 16;
			p_pdfconsuntivo.Value ="";
			p_pdfconsuntivo.Size=250; 
			CollezioneControlli.Add(p_pdfconsuntivo);
			//ok
			S_Controls.Collections.S_Object p_annocontabilizzazione = new S_Object();
			p_annocontabilizzazione.ParameterName = "p_annocontabilizzazione";
			p_annocontabilizzazione.DbType = CustomDBType.Integer;
			p_annocontabilizzazione.Direction = ParameterDirection.Input;
			p_annocontabilizzazione.Index = 17;
			string anno= DateTime.Now.Year.ToString();
			p_annocontabilizzazione.Value =Int16.Parse(anno);			
			CollezioneControlli.Add(p_annocontabilizzazione);
			try
			{										
				Int32 result =_ClManCorrettiva.ExecuteUpdateCompletamento(CollezioneControlli,this.wr_id);
				string Result= UploadFile(UploadFileCosto,TipoPostFile.Consuntivo);
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);				
			}
		}
		#endregion

		private void btnChiudicompleta_Click(object sender, System.EventArgs e)
		{
			 Chiudi();
		}

		private void btnfoglioprestazioni_Click(object sender, System.EventArgs e)
		{
			ScriptRapportoTecnico(int.Parse(S_Lblordinelavoro.Text.Trim()));
		}

		private void BtnCostiOpera_Click(object sender, System.EventArgs e)
		{
			string url="../ManutenzioneCorrettiva/AnalisiCostiOperativiDiGestioneDettaglio.aspx?WR_ID="+wr_id+"&chiamante="+myType.ToString();
			Response.Redirect(url);
		}

		private void btnfoglioprestazioniPdf_Click(object sender, System.EventArgs e)
		{
			ScriptRapportoTecnicoPdf(int.Parse(S_Lblordinelavoro.Text.Trim()));
		}

		private void ScriptRapportoTecnicoPdf(int wo_id)
		{
			string pagina="RapportoTecnicoInterventoPdf.aspx?WO_Id=" + wo_id.ToString();
			string s_TestataScript = "<script language=\"javascript\">\n";
			string funz="ApriPopUp('"+ pagina +"')";
			string s_CodaScript = "</script>\n";
			string funzione=s_TestataScript + funz + s_CodaScript;
			this.Page.RegisterStartupScript("funz",funzione);
			
		}

		

		
	}
}
