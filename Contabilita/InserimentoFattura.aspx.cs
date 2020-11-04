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
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using S_Controls;

namespace TheSite.Contabilita
{
	/// <summary>
	/// Descrizione di riepilogo per EditServizi.
	/// </summary>
	public class InserimentoFattura : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected System.Web.UI.WebControls.Panel PanelEdit;

		int itemId = 0;
		int FunId = 0;
		TheSite.Contabilita.InserimentoFattura _fp;
		DataSet _MyDs = new DataSet();
		S_Controls.Collections.S_ControlsCollection  _SCollection = new S_Controls.Collections.S_ControlsCollection();
		protected System.Web.UI.WebControls.DropDownList cmbDaMese;
		protected S_Controls.S_TextBox S_TxtPercentuale;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected System.Web.UI.WebControls.DropDownList cmbAMese;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;
		protected WebControls.CalendarPicker CalendarPicker3;
		protected WebControls.CalendarPicker CalendarPicker4;
		protected System.Web.UI.WebControls.Panel CampiModifica;
		protected S_Controls.S_TextBox S_TxtImponibile;
		protected S_Controls.S_TextBox S_TxtImponibileDec;
		protected S_Controls.S_TextBox S_TxtTot;
		protected S_Controls.S_TextBox S_TxtTotDec;
		protected S_Controls.S_TextBox S_TxtIntestatario;
		protected S_Controls.S_TextBox S_TxtDestinatario;
		protected S_Controls.S_TextBox S_TxtNumFattura;
		protected S_Controls.S_TextBox S_TxtDescrizione;
		protected System.Web.UI.WebControls.DropDownList cmbAnnoDa;
		protected System.Web.UI.WebControls.DropDownList cmbAnnoA;
		Classi.Fatturazione.Contabilita _Contabilita = new TheSite.Classi.Fatturazione.Contabilita();
		string s_PeriodoDa="";
		string s_PeriodoA="";
		int i_idintestatario;
		protected System.Web.UI.HtmlControls.HtmlTable TableOrdinaria;
		protected System.Web.UI.HtmlControls.HtmlTable TableStrardinaria;
		int i_iddestinatario;
		string s_Imponibile;
		string s_Totfattura;
		string strArrRdl;
		string s_dataApprovazione=null;
		protected S_Controls.S_ListBox S_ListRDL;
		string s_dataPagamento=null;
		protected S_Controls.S_Button btnsSalva;
		protected S_Controls.S_Button btnsElimina;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.HtmlControls.HtmlInputHidden rdl;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RFVNumFattura;
		protected System.Web.UI.WebControls.RequiredFieldValidator RFVTipoServizio;		
		protected WebControls.RicercaRDL RicercaRDL1;
		public static string HelpLink = string.Empty;
		private void visualizzatab()
		{		
			 if (cmbsServizio.SelectedValue=="1")
			 {
				 TableOrdinaria.Attributes.Add("Style","DISPLAY:block");
				 TableStrardinaria.Attributes.Add("Style","DISPLAY:none");
			 }

			 if (cmbsServizio.SelectedValue=="3")
			 {
				 TableOrdinaria.Attributes.Add("Style","DISPLAY:none");
				 TableStrardinaria.Attributes.Add("Style","DISPLAY:block");
			 }
			 if (cmbsServizio.SelectedValue=="")
			 {
				 TableOrdinaria.Attributes.Add("Style","DISPLAY:none");
				 TableStrardinaria.Attributes.Add("Style","DISPLAY:none");
			 }
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			visualizzatab();
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			HelpLink = _SiteModule.HelpLink;
			FunId = Int32.Parse(Request["FunId"]);
			S_ListRDL.Attributes.Add("onkeydown","deleteitem(this,event);"); 
			RicercaRDL1.multisele="y";
			RicercaRDL1.operazione="Insert";
			RicercaRDL1.NameComboMan="cmbsServizio";
			RicercaRDL1.TipoMan=Convert.ToString(cmbsServizio.SelectedIndex);
		

					if (Request["ItemId"] != null) 
					{		
						itemId = Int32.Parse(Request["ItemId"]);
						if (itemId!=0)
							CampiModifica.Visible=true;
					}
			
			if (!Page.IsPostBack )
			{	

				CaricaIntestatario();
				CaricaDestinatario();
				CaricaTipoServizio();

				//validator per la data
				//CompareValidator1.ControlToValidate = CalendarPicker2.ID + ":" + CalendarPicker2.Datazione.ID;
				//CompareValidator1.ControlToCompare =  CalendarPicker1.ID + ":" + CalendarPicker1.Datazione.ID;
				
				// validazione numeri inserimento 0 blocco paste
				S_TxtImponibile.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
				S_TxtImponibile.Attributes.Add("onpaste","return false;");
				S_TxtImponibile.Attributes.Add("onblur","imposta_dec(this.id);");

				S_TxtImponibileDec.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
				S_TxtImponibileDec.Attributes.Add("onpaste","return false;");
				S_TxtImponibileDec.Attributes.Add("onblur","imposta_dec(this.id);");


				S_TxtTot.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
				S_TxtTot.Attributes.Add("onpaste","return false;");
				S_TxtTot.Attributes.Add("onblur","imposta_dec(this.id);");

				
				S_TxtTotDec.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
				S_TxtTotDec.Attributes.Add("onpaste","return false;");
				S_TxtTotDec.Attributes.Add("onblur","imposta_dec(this.id);");
				

				S_TxtPercentuale.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
				S_TxtPercentuale.Attributes.Add("onpaste","return false;");
				S_TxtPercentuale.Attributes.Add("onblur","imposta_dec(this.id);");

				//Fine

				
				btnsSalva.Attributes.Add("onclick","if (typeof(controllodata) == 'function') {if (controllodata() == false) { return false; }}");
			
				if (itemId != 0) 
				{
					_MyDs = _Contabilita.GetSingleData(itemId); 
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						
						if (_Dr["descrizione_fattura"] != DBNull.Value)
							this.S_TxtDescrizione.Text= (string) _Dr["descrizione_fattura"];					
							
						if (_Dr["intestatario"] != DBNull.Value)
							this.S_TxtIntestatario.Text= (string) _Dr["intestatario"];

						if (_Dr["destinatario"] != DBNull.Value)
							this.S_TxtDestinatario.Text= (string) _Dr["destinatario"];
											
						if (_Dr["numero_fattura"] != DBNull.Value)
							this.S_TxtNumFattura.Text= (string) _Dr["numero_fattura"];
							
						if (_Dr["data_fattura"] != DBNull.Value)
							this.CalendarPicker1.Datazione.Text=DateTime.Parse( _Dr["data_fattura"].ToString()).ToShortDateString();

						if (_Dr["data_scadenza_pagamento"] != DBNull.Value)
							this.CalendarPicker2.Datazione.Text=DateTime.Parse( _Dr["data_scadenza_pagamento"].ToString()).ToShortDateString();
							
						if (_Dr["tipomanutenzione_id"] != DBNull.Value)
						{
							this.cmbsServizio.SelectedValue= _Dr["tipomanutenzione_id"].ToString();
							visualizzatab();
						}
							if(this.cmbsServizio.SelectedValue=="1")
							{	
								string str=_Dr["PERIODO_INIZIO_FATTURA"].ToString();
								cmbAnnoDa.SelectedValue =str.Substring(0,4);
								cmbDaMese.SelectedValue= str.Substring(4,2);
								string str1=_Dr["PERIODO_FINE_FATTURA"].ToString();
								cmbAnnoA.SelectedValue = str1.Substring(0,4);
								cmbAMese.SelectedValue= str1.Substring(4,2);
								
							}

						if (this.cmbsServizio.SelectedValue=="3")
						{

							_MyDs = _Contabilita.GetSingleRdlFatt(itemId); 
							if (_MyDs.Tables[0].Rows.Count > 0)
							{
								this.S_ListRDL.DataSource= _MyDs.Tables[0];
								this.S_ListRDL.DataTextField = "wr_id";
								this.S_ListRDL.DataValueField = "wr_id";
								this.S_ListRDL.DataBind();

								
							}			
							if(S_ListRDL.Items.Count>=0)			
							{								
								foreach(ListItem o_Litem in this.S_ListRDL.Items)
								{
									rdl.Value = rdl.Value + o_Litem.Value.ToString() + ",";
								}			
								
							}
							
						
						}


						if (_Dr["data_approvazione"] != DBNull.Value)
							this.CalendarPicker3.Datazione.Text= DateTime.Parse( _Dr["data_approvazione"].ToString()).ToShortDateString();

						if (_Dr["data_pagamento"] != DBNull.Value)
							this.CalendarPicker4.Datazione.Text=DateTime.Parse( _Dr["data_pagamento"].ToString()).ToShortDateString();
						
						if (_Dr["imponibile"] != DBNull.Value)
						{
							this.S_TxtImponibile.Text=Classi.Function.GetTypeNumber(_Dr["imponibile"],Classi.NumberType.Intero).ToString(); 
							this.S_TxtImponibileDec.Text=Classi.Function.GetTypeNumber(_Dr["imponibile"],Classi.NumberType.Decimale).ToString(); 
						}
						
						if (_Dr["iva"] != DBNull.Value)
						{
							this.S_TxtPercentuale.Text=Classi.Function.GetTypeNumber(_Dr["iva"],Classi.NumberType.Intero).ToString(); 
						}

						if (_Dr["totale_fattura"] != DBNull.Value)
						{
							this.S_TxtTot.Text=Classi.Function.GetTypeNumber(_Dr["totale_fattura"],Classi.NumberType.Intero).ToString(); 
							this.S_TxtTotDec.Text=Classi.Function.GetTypeNumber(_Dr["totale_fattura"],Classi.NumberType.Decimale).ToString(); 
						}
						

						this.lblOperazione.Text = "Modifica Fattura: " + this.S_TxtNumFattura.Text;
						this.lblFirstAndLast.Visible = true;			
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");	
						lblFirstAndLast.Text = _Contabilita.GetFirstAndLastUser(_Dr);
					}
				}
				else
				{
					this.lblOperazione.Text = "Inserimento Fattura";
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;
				}				
				if (Request["TipoOper"] == "read")	
				{
					AbilitaControlli(false);
					this.lblOperazione.Text = "Visualizzazione Fattura: " + this.S_TxtNumFattura.Text;
				}

				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Servizi) 
				{
					_fp = (TheSite.Contabilita.InserimentoFattura) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
				}	
			}
		}
		
		private void AbilitaControlli(bool enabled)
		{
			this.PanelEdit.Enabled=enabled;
			this.btnsSalva.Enabled=enabled;
			this.btnsElimina.Enabled=enabled;
			this.S_ListRDL.Enabled=enabled;
			this.cmbsServizio.Enabled=enabled;
			this.cmbAMese.Enabled=enabled;
			this.cmbDaMese.Enabled=enabled;
			this.cmbAnnoDa.Enabled=enabled;
			this.cmbAnnoA.Enabled=enabled;
		}

		private void CaricaIntestatario()
		{
			DataSet _MyDs = _Contabilita.GetIntestatario().Copy();
			S_TxtIntestatario.Text= _MyDs.Tables[0].Rows[0]["SOCIETA"].ToString();		
			i_idintestatario=Convert.ToInt32( _MyDs.Tables[0].Rows[0]["INTESTATARIO_ID"]);
			
		
		}

		private void CaricaDestinatario()
		{
			DataSet _MyDs = _Contabilita.GetDestinatario().Copy();
			S_TxtDestinatario.Text= _MyDs.Tables[0].Rows[0]["SOCIETA"].ToString();		
			i_iddestinatario=Convert.ToInt32( _MyDs.Tables[0].Rows[0]["DESTINATARIO_ID"]);
		}

		private void CaricaTipoServizio()
		{
			this.cmbsServizio .Items.Clear();
			DataSet  _MyDs =_Contabilita.GetTipoServizio().Copy();
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "tipomanutenzione_id", "- Selezionare un Servizio -","-1");
				this.cmbsServizio.DataTextField = "descrizione";
				this.cmbsServizio.DataValueField = "tipomanutenzione_id";
				this.cmbsServizio.DataBind();
			}
		
		}
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
			this.btnsElimina.Click += new System.EventHandler(this.btnsElimina_Click);
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private bool IsDupNumFattura()
		{
			Classi.Function _Function = new TheSite.Classi.Function();
			// Nome della tabella 
			string tabella = "Fattura";
			// Nome del campo sui cui effettuare la ricerca (WHERE)
			string campo_input = "NUMERO_FATTURA";
			// Il campo valore è relativo alla stringa
			string valore = "'" + S_TxtNumFattura.Text.Trim().Replace("'","''") + "'";
			//valore = valore.Replace("'","''");
			// Nome del Campo restituito in Output
			string campo_output = "Fattura_ID";
			DataSet _MyDs =_Function.ControllaDuplicato(tabella,campo_input,valore,campo_output);										
			// Controllo se ho trovato qualcosa con la descrizione passata in input
			if (_MyDs.Tables[0].Rows.Count == 0) // se non trovo niente retistuisco false
			{
				return false;	
			}
			else
			{				
				DataRow _Dr = _MyDs.Tables[0].Rows[0];
				// Controllo Se sono in modifica
				if (itemId > 0)
				{
					//Controllo se sto modificando me stesso
					if (Int32.Parse(_Dr[0].ToString()) != itemId)
					{
						return true; // se non sto modificando me stesso restituisco true
					}
					else
					{
						return false; // se non sto modificando me stesso restituisco false
					}
				}
				else
				{
					return true; // se sto inserendo e ho trovato qualcosa restituisco true
				}
			}

		}

		private bool IsDupRdl()
		{
			Classi.Function _Function = new TheSite.Classi.Function();
		
			string tabella = "Fattura_wr";
		
			string campo_input = "WR_ID";
			
			string valore = rdl.Value.Substring(0,rdl.Value.Length - 1) ;

			string valore2 = Convert.ToString(itemId) ;

			string operazione="";
			if (itemId == 0)
			 operazione="Insert";
			else
			 operazione="Update";
			
			string campo_output = "Fattura_ID";
			DataSet _MyDs =_Function.ControllaDuplicatoRDL(tabella,campo_input,valore, valore2,campo_output,operazione);										
			
			if (_MyDs.Tables[0].Rows.Count == 0)
			{
				
				return false;	 
				
			}
			else
			{			
				return true;
//				DataRow _Dr = _MyDs.Tables[0].Rows[0];
				
//				if (itemId > 0)
//				{				
//					if (Int32.Parse(_Dr[0].ToString()) != itemId)
//					{
//						return true; 
//					}
//					else
//					{
//						return false;
//					}
//				}
//				else
//				{
//					return true;
//				}
			}

		}

		private bool IsDupPeriodoFAttura()
		{
			Classi.Function _Function = new TheSite.Classi.Function();
			string tabella = "Fattura";
			string campo_input = "PERIODO_INIZIO_FATTURA";
			string campo_input1 = "PERIODO_FINE_FATTURA";
			string valore = "'" + cmbAnnoDa.SelectedValue +cmbDaMese.SelectedValue+ "'";
			string valore1 = "'" + cmbAnnoA.SelectedValue +cmbAMese.SelectedValue+ "'";
			string campo_output = "Fattura_ID";
			DataSet _MyDs =_Function.ControllaDuplicatoPeriodo(tabella,campo_input,campo_input1,valore,valore1,campo_output);										
			
			if (_MyDs.Tables[0].Rows.Count == 0) 
			{
				return false;	
			}
			else
			{				
				DataRow _Dr = _MyDs.Tables[0].Rows[0];
				
				if (itemId > 0)
				{
					if (Int32.Parse(_Dr[0].ToString()) != itemId)
					{
						return true; // se non sto modificando me stesso restituisco true
					}
					else
					{
						return false; // se non sto modificando me stesso restituisco false
					}
				}
				else
				{
					return true; // se sto inserendo e ho trovato qualcosa restituisco true
				}
			}

		}
		private void btnsSalva_Click(object sender, System.EventArgs e)
		{
			 
		//	if(cmbsServizio.SelectedValue=="-1")
		//		Classi.SiteJavaScript.msgBox(this.Page,"Selezionare un tipo servizio");

			if (IsDupNumFattura()==false)
			{
				if(cmbsServizio.SelectedValue=="1")
				{
						if (IsDupPeriodoFAttura()==false)
							Aggiorna(true);
						else 
							Classi.SiteJavaScript.msgBox(this.Page,"Periodo di fatturazione già inserita");
				}
				 if(cmbsServizio.SelectedValue=="3")
				{
					 //if (IsDupRdl()==false)
						 Aggiorna(true);
//					 else 
//					 {
//						// rdl.Value="";
//						 Classi.SiteJavaScript.msgBox(this.Page,"Rdl Gia Fatturata");
//					 }
					 }
				
			}
			else
				Classi.SiteJavaScript.msgBox(this.Page,"La fattura é stata già inserita");

			
		}


		private void SalvaRdlAssociate()
		{
			
		}

		private void Aggiorna(bool ins)
		{
			this.S_TxtDescrizione.DBDefaultValue = DBNull.Value;
			this.S_TxtDestinatario.DBDefaultValue = DBNull.Value;
			this.S_TxtImponibile.DBDefaultValue = DBNull.Value;
			this.S_TxtImponibileDec.DBDefaultValue = DBNull.Value;
			this.S_TxtIntestatario.DBDefaultValue = DBNull.Value;
			this.S_TxtNumFattura.DBDefaultValue = DBNull.Value;
			this.S_TxtPercentuale.DBDefaultValue = DBNull.Value;
			this.S_TxtTot.DBDefaultValue = DBNull.Value;
			this.S_TxtTotDec.DBDefaultValue = DBNull.Value;
			this.CalendarPicker1.Datazione.DBDefaultValue = DBNull.Value;
			this.CalendarPicker2.Datazione.DBDefaultValue = DBNull.Value;
			this.CalendarPicker3.Datazione.DBDefaultValue = DBNull.Value;
			this.CalendarPicker4.Datazione.DBDefaultValue = DBNull.Value;

			s_Imponibile= S_TxtImponibile.Text +","+ S_TxtImponibileDec.Text;
			s_Totfattura = S_TxtTot.Text+","+S_TxtTotDec.Text;
			if (CalendarPicker4.Datazione.Text!="")
				s_dataPagamento=CalendarPicker3.Datazione.Text;

			if (CalendarPicker3.Datazione.Text!="")
				s_dataApprovazione= CalendarPicker4.Datazione.Text;
				
			if (cmbsServizio.SelectedValue=="1")
			{
				s_PeriodoDa=cmbAnnoDa.SelectedValue + cmbDaMese.SelectedValue;
				s_PeriodoA=cmbAnnoA.SelectedValue + cmbAMese.SelectedValue;
				strArrRdl="";
			}
			else
			{
				s_PeriodoA="0";
				s_PeriodoDa="0";
			}

			
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();	

			S_Controls.Collections.S_Object Fattura_id = new S_Object();
			Fattura_id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			Fattura_id.Direction = ParameterDirection.Input;
			Fattura_id.Value = itemId;
			Fattura_id.ParameterName = "p_FATTURA_ID";
			Fattura_id.Index= 0;
			CollezioneControlli.Add(Fattura_id);

			S_Controls.Collections.S_Object  Intestatario_id= new S_Object();
			Intestatario_id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			Intestatario_id.Direction = ParameterDirection.Input;
			Intestatario_id.Value = 1;
			Intestatario_id.ParameterName = "p_INTESTATARIO_ID";
			Intestatario_id.Index= 1;
			CollezioneControlli.Add(Intestatario_id);

			S_Controls.Collections.S_Object  Destinatario_id= new S_Object();
			Destinatario_id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			Destinatario_id.Direction = ParameterDirection.Input;
			Destinatario_id.Value = 1;
			Destinatario_id.ParameterName = "p_DESTINATARIO_ID";
			Destinatario_id.Index= 2;
			CollezioneControlli.Add(Destinatario_id);

			S_Controls.Collections.S_Object  NumFattura= new S_Object();
			NumFattura.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			NumFattura.Direction = ParameterDirection.Input;
			NumFattura.Value = S_TxtNumFattura.Text;
			NumFattura.ParameterName = "p_NUMEROFATTURA";
			NumFattura.Size=50;
			NumFattura.Index= 3;
			CollezioneControlli.Add(NumFattura);

			S_Controls.Collections.S_Object  DataFattura= new S_Object();
			DataFattura.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DataFattura.Direction = ParameterDirection.Input;
			DataFattura.Value = CalendarPicker1.Datazione.Text;
			DataFattura.ParameterName = "p_DATA_FATTURA";
			DataFattura.Size=10;
			DataFattura.Index= 4;
			CollezioneControlli.Add(DataFattura);

			S_Controls.Collections.S_Object  DataScadPagam= new S_Object();
			DataScadPagam.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DataScadPagam.Direction = ParameterDirection.Input;
			DataScadPagam.Value =CalendarPicker2.Datazione.Text;
			DataScadPagam.ParameterName = "p_DATA_SCADENZA_PAGAMENTO";
			DataScadPagam.Size=10;
			DataScadPagam.Index= 5;
			CollezioneControlli.Add(DataScadPagam);

			S_Controls.Collections.S_Object  DataPagam= new S_Object();
			DataPagam.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DataPagam.Direction = ParameterDirection.Input;
			DataPagam.Value = CalendarPicker4.Datazione.Text;
			DataPagam.Size=10;
			DataPagam.ParameterName = "p_DATA_PAGAMENTO";
			DataPagam.Index= 6;
			CollezioneControlli.Add(DataPagam);

			S_Controls.Collections.S_Object  DataApprovazione= new S_Object();
			DataApprovazione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DataApprovazione.Direction = ParameterDirection.Input;
			DataApprovazione.Value =CalendarPicker3.Datazione.Text;
			DataApprovazione.ParameterName = "p_DATA_APPROVAZIONE";
			DataApprovazione.Size=10;
			DataApprovazione.Index= 7;
			CollezioneControlli.Add(DataApprovazione);


			S_Controls.Collections.S_Object  TipoManutenzione_id= new S_Object();
			TipoManutenzione_id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			TipoManutenzione_id.Direction = ParameterDirection.Input;
			TipoManutenzione_id.Value = Int32.Parse(cmbsServizio.SelectedValue);
			TipoManutenzione_id.ParameterName = "p_TIPOMANUTENZIONE_ID";
			TipoManutenzione_id.Index= 8;
			CollezioneControlli.Add(TipoManutenzione_id);

			S_Controls.Collections.S_Object  DescrFattura= new S_Object();
			DescrFattura.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DescrFattura.Direction = ParameterDirection.Input;
			DescrFattura.Value = S_TxtDescrizione.Text;
			DescrFattura.ParameterName = "p_DESCRIZIONE_FATTURA";
			DescrFattura.Size= 255;
			DescrFattura.Index= 9;
			CollezioneControlli.Add(DescrFattura);
			
			S_Controls.Collections.S_Object  Imponibile= new S_Object();
			Imponibile.DbType = ApplicationDataLayer.DBType.CustomDBType.Double;
			Imponibile.Direction = ParameterDirection.Input;
			Imponibile.Value = Double.Parse(s_Imponibile);
			Imponibile.ParameterName = "p_IMPONIBILE";
			Imponibile.Index= 10;
			CollezioneControlli.Add(Imponibile);

			S_Controls.Collections.S_Object  Iva= new S_Object();
			Iva.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			Iva.Direction = ParameterDirection.Input;
			Iva.Value = Int16.Parse(S_TxtPercentuale.Text);
			Iva.ParameterName = "p_IVA";
			Iva.Index= 11;
			CollezioneControlli.Add(Iva);

			S_Controls.Collections.S_Object  TotFAttura= new S_Object();
			TotFAttura.DbType = ApplicationDataLayer.DBType.CustomDBType.Double;
			TotFAttura.Direction = ParameterDirection.Input;
			TotFAttura.Value = Double.Parse(s_Totfattura);
			TotFAttura.ParameterName = "p_TOTALE_FATTURA";
			TotFAttura.Index= 12;
			CollezioneControlli.Add(TotFAttura);

			S_Controls.Collections.S_Object  PeriodoInizio= new S_Object();
			PeriodoInizio.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			PeriodoInizio.Direction = ParameterDirection.Input;
			PeriodoInizio.Value = s_PeriodoDa;
			PeriodoInizio.ParameterName = "p_PERIODO_INIZIO_FATTURA";
			PeriodoInizio.Index= 13;
			CollezioneControlli.Add(PeriodoInizio);

			S_Controls.Collections.S_Object  PeriodoFine= new S_Object();
			PeriodoFine.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			PeriodoFine.Direction = ParameterDirection.Input;
			PeriodoFine.Value = s_PeriodoA;
			PeriodoFine.ParameterName = "p_PERIODO_FINE_FATTURA";
			PeriodoFine.Index= 14;
			CollezioneControlli.Add(PeriodoFine);

			/*int ciao = S_ListRDL.Items.Count;
			if(S_ListRDL.Items.Count>=0)
			
			{
				foreach(ListItem o_Litem in this.S_ListRDL.Items)
				{
					strArrRdl = strArrRdl + o_Litem.Value.ToString() + ";";
				}
			}
			*/	

			strArrRdl = rdl.Value;
			if (strArrRdl=="" || cmbsServizio.SelectedValue=="1")
				strArrRdl="0";
			
						
			S_Controls.Collections.S_Object s_ArrRDL = new S_Object();
			s_ArrRDL.ParameterName = "p_Arr_RDL";
			s_ArrRDL.DbType = CustomDBType.VarChar;
			s_ArrRDL.Direction = ParameterDirection.Input;
			s_ArrRDL.Index = 15;
			s_ArrRDL.Value = strArrRdl;					
			CollezioneControlli.Add(s_ArrRDL);

			
			S_Controls.Collections.S_Object FatturaWrId = new S_Object();
			FatturaWrId.ParameterName = "p_FATTURA_WR_ID";
			FatturaWrId.DbType = CustomDBType.VarChar;
			FatturaWrId.Direction = ParameterDirection.Input;
			FatturaWrId.Index =16;
			FatturaWrId.Value = 0;					
			CollezioneControlli.Add(FatturaWrId);


			int i_RowsAffected = 0;
			if (ins == true)
			{
				try
				{
					if (itemId == 0)
						i_RowsAffected = _Contabilita.Add(CollezioneControlli);  
					else
						i_RowsAffected =  _Contabilita.Update(CollezioneControlli,itemId);
				
					if ( i_RowsAffected > 0 && i_RowsAffected!=-11)
						Server.Transfer("SfogliaFatture.aspx");					
//					else
//						Classi.SiteJavaScript.msgBox(this.Page,"La fattura é stata già inserita");
				}
				catch (Exception ex)
				{				
					string s_Err =  ex.Message.ToString().ToUpper();
					PanelMess.ShowError(s_Err, true);
				}	
			}
			else 
			{
				try
				{
					i_RowsAffected = _Contabilita.Delete(CollezioneControlli,itemId);

					if ( i_RowsAffected == -1 )					
						Server.Transfer("SfogliaFatture.aspx");
				}
				catch (Exception ex)
				{				
					string s_Err =  ex.Message.ToString().ToUpper();
					PanelMess.ShowError(s_Err, true);
				}
			}

		}

		private void btnsElimina_Click(object sender, System.EventArgs e)
		{
			Aggiorna(false);	
		}

		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("SfogliaFatture.aspx");
		}

		

		
		
	}
}
