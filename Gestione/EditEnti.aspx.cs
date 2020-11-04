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
using MyCollection;

namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per EditDitte.
	/// </summary>
	public class EditEnti : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected S_Controls.S_TextBox txtsIndirizzo;			
		protected S_Controls.S_ComboBox cmbsProvincia;		
		protected S_Controls.S_Button btnsSalva;
		protected S_Controls.S_Button btnsElimina;
		protected S_Controls.S_ComboBox cmbsComune;
		protected S_Controls.S_TextBox txtsTelefono;
		protected S_Controls.S_TextBox txtsEmail;
		protected S_Controls.S_TextBox txtsCap;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected WebControls.PageTitle PageTitle1;
		public static string HelpLink = string.Empty;
		int itemId = 0;
		int FunId = 0;		
		private DataSet _DsListBox;
		private DataSet _DsListBoxD;
		protected S_Controls.S_TextBox txtsReferente;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;
		protected S_Controls.S_TextBox txtsRagioneSociale;
		protected S_Controls.S_TextBox txtsPartitaIva;
		protected S_Controls.S_TextBox txtsTelefonoRef;
		protected S_Controls.S_TextBox txtsDescrizione;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvEnte;
		Enti _fp;
			
	
		private void Page_Load(object sender, System.EventArgs e)
		{			
			FunId = Int32.Parse(Request["FunId"]);			

			if (Request["ItemID"] != null) 
			{
				itemId = Int32.Parse(Request["ItemID"]);				
			}
			
			//Disabilito le combo prima del postback
			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsComune.ClientID + "').disabled = true;");
			this.cmbsProvincia.Attributes.Add("onchange", sbValid.ToString());

			sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsComune.ClientID + "').disabled = true;");
			sbValid.Append("document.getElementById('" + this.cmbsProvincia.ClientID + "').disabled = true;");

			if (!Page.IsPostBack )
			{	
				InizializzaControlliClient();
				BindProvince();
								
				if (itemId != 0) 
				{					
					//Classi.ClassiAnagrafiche.Ditte _Ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();

					Classi.ClassiAnagrafiche.Enti _Enti = new TheSite.Classi.ClassiAnagrafiche.Enti();
		
					DataSet _MyDs = _Enti.GetSingleData(itemId).Copy();	
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						//ente descrizione
						this.txtsDescrizione.Text= (string) _Dr["Descrizione"];
						//provincia
						if (_Dr["IdProvincia"] != DBNull.Value)
							this.cmbsProvincia.SelectedValue= _Dr["IdProvincia"].ToString();
						BindComuni();
						//comune
						if (_Dr["IdComune"] != DBNull.Value)
							this.cmbsComune.SelectedValue= _Dr["IdComune"].ToString();
						//indirizzo
						if (_Dr["Indirizzo"] != DBNull.Value)
							this.txtsIndirizzo.Text = (string) _Dr["Indirizzo"];
						//Ragione Sociale
						if(_Dr["RAGIONESOCIALE"] !=DBNull.Value)
							this.txtsRagioneSociale.Text = (string) _Dr["RAGIONESOCIALE"];
						//Partita Iva
						if(_Dr["PARTITAIVA"] != DBNull.Value)
							this.txtsPartitaIva.Text = (string) _Dr["PARTITAIVA"];
						//Telefono
						if (_Dr["Telefono"] != DBNull.Value)
							this.txtsTelefono.Text = (string) _Dr["Telefono"];
						//Mail
						if (_Dr["Mail"] != DBNull.Value)
							this.txtsEmail.Text = (string) _Dr["Mail"];
						//Referente
						if(_Dr["REFERENTE"] != DBNull.Value)
							this.txtsReferente.Text = (string) _Dr["REFERENTE"];
						// Telefono Referente
						if(_Dr["TELEFONOREFERENTE"] != DBNull.Value)
							this.txtsTelefonoRef.Text = (string) _Dr["TELEFONOREFERENTE"];
						//Data Inizio Contratto
						if(_Dr["DATAINIZIOCONTRATTO"] != DBNull.Value)
							CalendarPicker1.Datazione.Text =  _Dr["DATAINIZIOCONTRATTO"].ToString().Substring(0,10);
						//Data Fine Contratto
						if(_Dr["DATAFINECONTRATTO"] != DBNull.Value)
							CalendarPicker2.Datazione.Text =  _Dr["DATAFINECONTRATTO"].ToString().Substring(0,10);
						//CAP
						if (_Dr["Cap"] != DBNull.Value)
							this.txtsCap.Text = (string) _Dr["Cap"];
						lblFirstAndLast.Text=_Enti.GetFirstAndLastUser(_Dr);

						this.lblOperazione.Text = "Modifica Ente: " + this.txtsDescrizione.Text;
						this.lblFirstAndLast.Visible = true;
						
						this.btnsElimina.Visible = true;
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
						
						//controllo per le liste dei fornitori
						//ControllaListeFornitori();
					}		
				}
				else
				{
					this.lblOperazione.Text = "Inserimento Ente";
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;
					BindComuni();
					ImpostaProvinciaDefault("CT","CATANIA");
				}
				AggiornaListBox();
				if (Request["TipoOper"] == "read")	
				{
					AbilitaControlli(false);
					this.lblOperazione.Text = "Visualizzazione Ente: " + this.txtsDescrizione.Text;
				}
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Enti) 
				{
					_fp = (TheSite.Gestione.Enti) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
				}	

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

		#region FunzioniInterne
		
					
		private void InizializzaControlliClient()
		{			
			txtsCap.Attributes.Add("onkeypress","SoloNumeri()");
//			txtsTelefono.Attributes.Add("onkeypress","SoloNumeri()");
//			txtsTelefonoRef.Attributes.Add("onkeypress","SoloNumeri()");
		}
		private void AbilitaControlli(bool enabled)
		{
			this.txtsCap.Enabled = enabled;
			this.txtsDescrizione.Enabled = enabled;
			this.txtsEmail.Enabled = enabled;
			this.txtsIndirizzo.Enabled = enabled;
			this.txtsReferente.Enabled = enabled;
			this.txtsTelefono.Enabled = enabled;
			this.cmbsProvincia.Enabled=enabled;
			this.cmbsComune.Enabled=enabled;
			this.txtsRagioneSociale.Enabled = enabled;
			this.txtsPartitaIva.Enabled = enabled;
			this.txtsTelefonoRef.Enabled = enabled;
			CalendarPicker1.Datazione.Enabled = enabled;
			CalendarPicker2.Datazione.Enabled = enabled;

			this.btnsElimina.Enabled=enabled;
			this.btnsSalva.Enabled=enabled;
			
			
		}
		private bool IsDup()
		{
			Classi.Function _Function = new TheSite.Classi.Function();
			// Nome della tabella 
			string tabella = "Ditta";
			// Nome del campo sui cui effettuare la ricerca (WHERE)
			string campo_input = "Descrizione";
			// Il campo valore è relativo alla stringa
			string valore = "'" + txtsDescrizione.Text.Trim().Replace("'","''") + "'";
			//valore = valore.Replace("'","''");
			// Nome del Campo restituito in Output
			string campo_output = "Ditta_ID";
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
		

		

		private void BindProvince()
		{
			
			this.cmbsProvincia.Items.Clear();
			TheSite.Classi.ClassiAnagrafiche.Enti _Enti = new TheSite.Classi.ClassiAnagrafiche.Enti();
				
			DataSet _MyDs = _Enti.GetProvince().Copy();
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsProvincia.DataSource=_MyDs;
				this.cmbsProvincia.DataTextField = "Testo";
				this.cmbsProvincia.DataValueField = "Valore";
				this.cmbsProvincia.DataBind();
			}			
		}

		private void BindComuni()
		{	
			this.cmbsComune.Enabled = true;
			this.cmbsComune.Items.Clear();
			TheSite.Classi.ClassiAnagrafiche.Enti _Enti = new TheSite.Classi.ClassiAnagrafiche.Enti();

			S_ControlsCollection _SColl = new S_ControlsCollection();
			S_Controls.Collections.S_Object s_Provid = new S_Object();			
			s_Provid.ParameterName = "pIdProvincia";
			s_Provid.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer; 
			s_Provid.Direction = ParameterDirection.Input;			
			s_Provid.Index = 0;
			s_Provid.Value = cmbsProvincia.SelectedValue;
			
			_SColl.Add(s_Provid);
						
			DataSet _MyDs = _Enti.GetComuni(_SColl).Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{			
				this.cmbsComune.DataSource=_MyDs;
				this.cmbsComune.DataTextField = "Testo";
				this.cmbsComune.DataValueField = "Valore";
				this.cmbsComune.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Comune  -";
				this.cmbsComune.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
						
			}
		}

		private void ImpostaProvinciaDefault(string provincia,string comune)
		{
			ListItem crItemp = cmbsProvincia.Items.FindByText(provincia);			
			cmbsProvincia.SelectedValue= crItemp.Value;			
			BindComuni();
			ListItem crItemc = cmbsComune.Items.FindByText(comune);			
			cmbsComune.SelectedValue=crItemc.Value;
		}

			
		
		
		private void AggiornaListBox()
		{
			_DsListBox = new DataSet();
			_DsListBoxD = new DataSet();

			this.CreaTabelle();				

			// Carico le liste per i Servizi

			if (itemId > 0)
			{				
				Classi.ClassiAnagrafiche.Ditte _Ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
				DataView o_Dv = new DataView(_Ditte.GetServiziDitta(itemId).Tables[0]);				
				if (o_Dv.Count > 0)
				{
					foreach (DataRowView o_Drv in o_Dv)
					{
						DataRow o_Dr = _DsListBox.Tables["ServiziDitta"].NewRow();
						o_Dr["Id"] = o_Drv["IDSERVIZIO"].ToString();
						o_Dr["Servizio"] = o_Drv["DESCRIZIONE"].ToString();
						o_Dr["IdUtente"] = "1"; // Non Serve
						_DsListBox.Tables["ServiziDitta"].Rows.Add(o_Dr);
					}
				}

			}
			
		}	

		private void CreaTabelle()
		{
			//Associazione Ditte Servizi
			
			DataTable o_DtServizi = new DataTable("Servizi");
			
			DataColumn o_DcIdServizio = new DataColumn("Id");
			o_DcIdServizio.DataType = System.Type.GetType("System.Int32");
			o_DcIdServizio.Unique = true;
			o_DcIdServizio.AllowDBNull = false;
			o_DtServizi.Columns.Add(o_DcIdServizio);

			DataColumn o_DcServizio = new DataColumn("Servizio");
			o_DcServizio.DataType = System.Type.GetType("System.String");
			o_DcServizio.Unique = false;
			o_DcServizio.AllowDBNull = false;
			o_DtServizi.Columns.Add(o_DcServizio);

			DataTable o_DtServiziDitta = new DataTable("ServiziDitta");
			
			DataColumn o_DcIdServizioAss = new DataColumn("Id");
			o_DcIdServizioAss.DataType = System.Type.GetType("System.Int32");
			o_DcIdServizioAss.Unique = true;
			o_DcIdServizioAss.AllowDBNull = false;
			o_DtServiziDitta.Columns.Add(o_DcIdServizioAss);

			DataColumn o_DcIdUtente = new DataColumn("IdUtente");
			o_DcIdUtente.DataType = System.Type.GetType("System.Int32");
			o_DcIdUtente.Unique = false;
			o_DcIdUtente.AllowDBNull = false;
			o_DtServiziDitta.Columns.Add(o_DcIdUtente);

			DataColumn o_DcDescrServizio = new DataColumn("Servizio");
			o_DcDescrServizio.DataType = System.Type.GetType("System.String");
			o_DcDescrServizio.Unique = false;
			o_DcDescrServizio.AllowDBNull = false;
			o_DtServiziDitta.Columns.Add(o_DcDescrServizio);

			DataColumn o_DcOperazione = new DataColumn("Operazione");
			o_DcOperazione.DataType = System.Type.GetType("System.String");
			o_DcOperazione.Unique = false;
			o_DcOperazione.AllowDBNull = true;
			o_DcOperazione.DefaultValue = "D";
			o_DtServiziDitta.Columns.Add(o_DcOperazione);

			_DsListBox.Tables.Add(o_DtServizi);
			_DsListBox.Tables.Add(o_DtServiziDitta);

			// Associazione Ditte Ditte SubAppaltatrici

			// -- Elenco DitteSub
			DataTable o_DtDitteSub = new DataTable("DitteSub");
			
			// - ID
			DataColumn o_DcIdDittaSub = new DataColumn("IdD");
			o_DcIdDittaSub.DataType = System.Type.GetType("System.Int32");
			o_DcIdDittaSub.Unique = true;
			o_DcIdDittaSub.AllowDBNull = false;
			o_DtDitteSub.Columns.Add(o_DcIdDittaSub);

			// Descrizione 

			DataColumn o_DcDittaSub = new DataColumn("DittaSub");
			o_DcDittaSub.DataType = System.Type.GetType("System.String");
			o_DcDittaSub.Unique = false;
			o_DcDittaSub.AllowDBNull = false;
			o_DtDitteSub.Columns.Add(o_DcDittaSub);
			
			// -- Elenco DitteSubAssociate

			DataTable o_DtDittaSubDitte = new DataTable("DittaSubDitta");
			
			// - ID

			DataColumn o_DcIdDittaSubAss = new DataColumn("IdD");
			o_DcIdDittaSubAss.DataType = System.Type.GetType("System.Int32");
			o_DcIdDittaSubAss.Unique = true;
			o_DcIdDittaSubAss.AllowDBNull = false;
			o_DtDittaSubDitte.Columns.Add(o_DcIdDittaSubAss);

			DataColumn o_DcIdUtenteD = new DataColumn("IdUtente");
			o_DcIdUtenteD.DataType = System.Type.GetType("System.Int32");
			o_DcIdUtenteD.Unique = false;
			o_DcIdUtenteD.AllowDBNull = false;
			o_DtDittaSubDitte.Columns.Add(o_DcIdUtenteD);
			
			// - Descrizione

			DataColumn o_DcDittaSubAss = new DataColumn("DittaSubAss");
			o_DcDittaSubAss.DataType = System.Type.GetType("System.String");
			o_DcDittaSubAss.Unique = false;
			o_DcDittaSubAss.AllowDBNull = false;
			o_DtDittaSubDitte.Columns.Add(o_DcDittaSubAss);

			// - Operazione

			DataColumn o_DcOperazioneD = new DataColumn("Operazione");
			o_DcOperazioneD.DataType = System.Type.GetType("System.String");
			o_DcOperazioneD.Unique = false;
			o_DcOperazioneD.AllowDBNull = true;
			o_DcOperazioneD.DefaultValue = "D";
			o_DtDittaSubDitte.Columns.Add(o_DcOperazioneD);

			_DsListBoxD.Tables.Add(o_DtDitteSub);
			_DsListBoxD.Tables.Add(o_DtDittaSubDitte);
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
			this.cmbsProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbsProvincia_SelectedIndexChanged);
			this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
			this.btnsElimina.Click += new System.EventHandler(this.btnsElimina_Click);
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmbsProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
		{		
			BindComuni();
		}

		private void btnsSalva_Click(object sender, System.EventArgs e)
		{			
			
			Classi.ClassiAnagrafiche.Enti _Enti = new TheSite.Classi.ClassiAnagrafiche.Enti();
			int i_RowsAffected = 0;
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			//_SCollection.AddItems(this.PanelEdit.Controls);
			int cntParametri =0;
			S_Object pDescrizione = new S_Object();
			pDescrizione.ParameterName = "pDescrizione";
			pDescrizione.DbType = CustomDBType.VarChar;
			pDescrizione.Direction = ParameterDirection.Input;
			pDescrizione.Index = cntParametri++;
			pDescrizione.Size = 255;
			pDescrizione.Value = txtsDescrizione.Text;
			_SCollection.Add(pDescrizione);

			S_Object pIdProvincia = new S_Object();
			pIdProvincia.ParameterName = "pIdProvincia";
			pIdProvincia.DbType = CustomDBType.Integer;
			pIdProvincia.Direction = ParameterDirection.Input;
			pIdProvincia.Index = cntParametri++;
			pIdProvincia.Size = 32;
			pIdProvincia.Value = Convert.ToInt32(cmbsProvincia.SelectedValue);
			_SCollection.Add(pIdProvincia);

			S_Object pIdComune = new S_Object();
			pIdComune.ParameterName = "pIdComune";
			pIdComune.DbType = CustomDBType.Integer;
			pIdComune.Direction = ParameterDirection.Input;
			pIdComune.Index = cntParametri++;
			pIdComune.Size = 32;
			pIdComune.Value = Convert.ToInt32(cmbsComune.SelectedValue);
			_SCollection.Add(pIdComune);

			S_Object pIndirizzo = new S_Object();
			pIndirizzo.ParameterName = "pIndirizzo";
			pIndirizzo.DbType = CustomDBType.VarChar;
			pIndirizzo.Direction = ParameterDirection.Input;
			pIndirizzo.Index = cntParametri++;
			pIndirizzo.Size = 255;
			pIndirizzo.Value = txtsIndirizzo.Text;
			_SCollection.Add(pIndirizzo);

			S_Object pRagioneSociale = new S_Object();
			pRagioneSociale.ParameterName = "pRagioneSociale";
			pRagioneSociale.DbType = CustomDBType.VarChar;
			pRagioneSociale.Direction = ParameterDirection.Input;
			pRagioneSociale.Index = cntParametri++;
			pRagioneSociale.Size = 255;
			pRagioneSociale.Value = txtsRagioneSociale.Text;
			_SCollection.Add(pRagioneSociale);

			S_Object pPiva = new S_Object();
			pPiva.ParameterName = "pPiva";
			pPiva.DbType = CustomDBType.VarChar;
			pPiva.Direction = ParameterDirection.Input;
			pPiva.Index = cntParametri++;
			pPiva.Size = 255;
			pPiva.Value = txtsPartitaIva.Text;
			_SCollection.Add(pPiva);

			S_Object pTelefono = new S_Object();
			pTelefono.ParameterName = "pTelefono";
			pTelefono.DbType = CustomDBType.VarChar;
			pTelefono.Direction = ParameterDirection.Input;
			pTelefono.Index = cntParametri++;
			pTelefono.Size = 255;
			pTelefono.Value = txtsTelefono.Text;
			_SCollection.Add(pTelefono);

			S_Object pEmail = new S_Object();
			pEmail.ParameterName = "pEmail";
			pEmail.DbType = CustomDBType.VarChar;
			pEmail.Direction = ParameterDirection.Input;
			pEmail.Index = cntParametri++;
			pEmail.Size=255;
			pEmail.Value = txtsEmail.Text;
			_SCollection.Add(pEmail);

			S_Object pReferente = new S_Object();
			pReferente.ParameterName= "pReferente";
			pReferente.DbType = CustomDBType.VarChar;
			pReferente.Direction = ParameterDirection.Input;
			pReferente.Index = cntParametri++;
			pReferente.Size= 255;
			pReferente.Value = txtsReferente.Text;
			_SCollection.Add(pReferente);

			S_Object pTelefonoReferente = new S_Object();
			pTelefonoReferente.ParameterName="pTelefonoReferente";
			pTelefonoReferente.DbType = CustomDBType.VarChar;
			pTelefonoReferente.Direction = ParameterDirection.Input;
			pTelefonoReferente.Index = cntParametri++;
			pTelefonoReferente.Size=255;
			pTelefonoReferente.Value = txtsTelefonoRef.Text;
			_SCollection.Add(pTelefonoReferente);

			S_Object PDataInizioContratto = new S_Object();
			PDataInizioContratto.ParameterName = "PDataInizioContratto";
			PDataInizioContratto.DbType = CustomDBType.VarChar;
			PDataInizioContratto.Direction = ParameterDirection.Input;
			PDataInizioContratto.Index = cntParametri++;
			PDataInizioContratto.Size=255;
			PDataInizioContratto.Value = CalendarPicker1.Datazione.Text;
			_SCollection.Add(PDataInizioContratto);

			S_Object pDataFineContratto = new S_Object();
			pDataFineContratto.ParameterName = "pDataFineContratto";
			pDataFineContratto.DbType = CustomDBType.VarChar;
			pDataFineContratto.Direction = ParameterDirection.Input;
			pDataFineContratto.Index = cntParametri++;
			pDataFineContratto.Size=255;
			pDataFineContratto.Value = CalendarPicker2.Datazione.Text;
			_SCollection.Add(pDataFineContratto);

			S_Object pCap = new S_Object();
			pCap.ParameterName = "pCap";
			pCap.DbType = CustomDBType.VarChar;
			pCap.Direction = ParameterDirection.Input;
			pCap.Index = cntParametri++;
			pCap.Size=255;
			pCap.Value = txtsCap.Text;
			_SCollection.Add(pCap);
			
			try
			{
				if (itemId == 0)
					i_RowsAffected = _Enti.Add(_SCollection);
				else
					i_RowsAffected = _Enti.Update(_SCollection, itemId);
			
				if(i_RowsAffected==-11)
				{
					Classi.SiteJavaScript.msgBox(this.Page,"Ditta già inserita nel DataBase.");
				}

				if ( i_RowsAffected > 0 )
				{
					//if (itemId==0)
						//Server.Transfer("Ditte.aspx?");
						//Response.Redirect("EditEnti.aspx?ItemId=" + i_RowsAffected +"&FunId=" + FunId);
						
					//else						
						Server.Transfer("Enti.aspx");
				}
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}			
		}

		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{

			Server.Transfer("Enti.aspx");
		}

		private void btnsElimina_Click(object sender, System.EventArgs e)
		{
			try
			{
				Classi.ClassiAnagrafiche.Enti _Enti = new TheSite.Classi.ClassiAnagrafiche.Enti();
				int i_RowsAffected = 0;

				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
				i_RowsAffected = _Enti.Delete(_SCollection, itemId);
				//if ( i_RowsAffected == 1 )
					//Response.Redirect((String) ViewState["UrlReferrer"]);
					//Response.Redirect("Ditte.aspx?FunID="+FunId+"&Ricarica=yes");

					Server.Transfer("Enti.aspx");
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}	
		}

		


	}


	
}

