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
	public class EditDitte : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		protected System.Web.UI.WebControls.ListBox ListBoxLeft;
		protected System.Web.UI.WebControls.Button btnAssocia;
		protected System.Web.UI.WebControls.Button btnElimina;
		protected System.Web.UI.WebControls.ListBox ListBoxRight;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected S_Controls.S_TextBox txtsIndirizzo;			
		protected S_Controls.S_ComboBox cmbsProvincia;		
		protected S_Controls.S_ComboBox cmbsTipo;		
		protected S_Controls.S_Button btnsSalva;
		protected S_Controls.S_Button btnsElimina;
		protected S_Controls.S_ComboBox cmbsComune;
		protected S_Controls.S_TextBox txtsTelefono;
		protected S_Controls.S_TextBox txtsEmail;
		protected S_Controls.S_TextBox TxtsCAP;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected WebControls.PageTitle PageTitle1;
		public static string HelpLink = string.Empty;
		int itemId = 0;
		int FunId = 0;		
		private DataSet _DsListBox;
		private DataSet _DsListBoxD;
		protected S_Controls.S_TextBox txtsReferente;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvUserName;
		protected System.Web.UI.WebControls.ListBox ListBoxLeftF;
		protected System.Web.UI.WebControls.Button btnAssociaF;
		protected System.Web.UI.WebControls.Button btnEliminaF;
		protected System.Web.UI.WebControls.ListBox ListBoxRightF;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected S_Controls.S_TextBox txtsDescrizione;
		protected System.Web.UI.WebControls.RegularExpressionValidator REVtxtsemail;
		Ditte _fp;
			
	
		private void Page_Load(object sender, System.EventArgs e)
		{			
			FunId = Int32.Parse(Request["FunId"]);			

			if (Request["itemId"] != null) 
			{
				itemId = Int32.Parse(Request["itemId"]);				
			}
			
			//Disabilito le combo prima del postback
			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsComune.ClientID + "').disabled = true;");
			sbValid.Append("document.getElementById('" + this.cmbsTipo.ClientID + "').disabled = true;");
			this.cmbsProvincia.Attributes.Add("onchange", sbValid.ToString());

			sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsComune.ClientID + "').disabled = true;");
			sbValid.Append("document.getElementById('" + this.cmbsProvincia.ClientID + "').disabled = true;");
			this.cmbsTipo.Attributes.Add("onchange", sbValid.ToString());

			if (!Page.IsPostBack )
			{	
				InizializzaControlliClient();
				BindProvince();
				BindTipologiaDitta();
								
				if (itemId != 0) 
				{					
					Classi.ClassiAnagrafiche.Ditte _Ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
				
					DataSet _MyDs = _Ditte.GetSingleData(itemId).Copy();									
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						this.txtsDescrizione.Text= (string) _Dr["DESCRIZIONE"];
						if (_Dr["INDIRIZZO"] != DBNull.Value)
							this.txtsIndirizzo.Text = (string) _Dr["INDIRIZZO"];
						if (_Dr["CAP"] != DBNull.Value)
							this.TxtsCAP.Text = (string) _Dr["CAP"];						
						if (_Dr["EMAIL"] != DBNull.Value)
							this.txtsEmail.Text = (string) _Dr["EMAIL"];
						if (_Dr["TELEFONO"] != DBNull.Value)
							this.txtsTelefono.Text = (string) _Dr["TELEFONO"];
						if (_Dr["REFERENTE"] != DBNull.Value)
							this.txtsReferente.Text = (string) _Dr["REFERENTE"];
						if (_Dr["PROVINCIA_ID"] != DBNull.Value)
						this.cmbsProvincia.SelectedValue= _Dr["PROVINCIA_ID"].ToString();
						BindComuni();
						if (_Dr["COMUNE_ID"] != DBNull.Value)
							this.cmbsComune.SelectedValue= _Dr["COMUNE_ID"].ToString();
						if (_Dr["TIPOLOGIADITTA_ID"] != DBNull.Value)
							this.cmbsTipo.SelectedValue=_Dr["TIPOLOGIADITTA_ID"].ToString();
						
						lblFirstAndLast.Text=_Ditte.GetFirstAndLastUser(_Dr);

						this.lblOperazione.Text = "Modifica Ditta: " + this.txtsDescrizione.Text;
						this.lblFirstAndLast.Visible = true;
						this.ListBoxLeft.Enabled = true;
						this.ListBoxRight.Enabled = true;
						this.btnAssocia.Enabled = true;
						this.btnElimina.Enabled = true;
						this.btnsElimina.Visible = true;
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
						
						//controllo per le liste dei fornitori
						ControllaListeFornitori();
					}		
				}
				else
				{
					this.lblOperazione.Text = "Inserimento Ditta";
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;
					BindComuni();
					ImpostaProvinciaDefault("CT","CATANIA");
				}
				AggiornaListBox();
				if (Request["TipoOper"] == "read")	
				{
					AbilitaControlli(false);
					this.lblOperazione.Text = "Visualizzazione Ditta: " + this.txtsDescrizione.Text;
				}
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Ditte) 
				{
					_fp = (TheSite.Gestione.Ditte) Context.Handler;
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
		private void ControllaListeFornitori()
		{
			bool stato=false;
			if(cmbsTipo.SelectedValue=="1") stato=true;

			this.ListBoxLeftF.Enabled = stato;
			this.ListBoxRightF.Enabled = stato;
			this.btnAssociaF.Enabled=stato;
			this.btnEliminaF.Enabled=stato;
		}
					
		private void InizializzaControlliClient()
		{			
			TxtsCAP.Attributes.Add("onkeypress","SoloNumeri()");			
		}
		private void AbilitaControlli(bool enabled)
		{
			this.TxtsCAP.Enabled = enabled;
			this.txtsDescrizione.Enabled = enabled;
			this.txtsEmail.Enabled = enabled;
			this.txtsIndirizzo.Enabled = enabled;
			this.txtsReferente.Enabled = enabled;
			this.txtsTelefono.Enabled = enabled;
			this.cmbsProvincia.Enabled=enabled;
			this.cmbsComune.Enabled=enabled;
			this.cmbsTipo.Enabled=enabled;
			
			this.btnsElimina.Enabled=enabled;
			this.btnsSalva.Enabled=enabled;
			
			// Lista Servizi
			this.btnAssocia.Enabled=enabled;
			this.btnElimina.Enabled=enabled;
			this.ListBoxLeft.Enabled=enabled;
			this.ListBoxRight.Enabled=enabled;
			
			// Lista Fornitori
			this.btnAssociaF.Enabled=enabled;
			this.btnEliminaF.Enabled=enabled;
			this.ListBoxLeftF.Enabled=enabled;
			this.ListBoxRightF.Enabled=enabled;

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
		private void UpdateServizi_Ditta(DataTable UpdateDataTable)
		{
			foreach (DataRow dr in UpdateDataTable.Rows)
			{
				if (dr["Operazione"] != DBNull.Value)
				{
					Classi.ClassiAnagrafiche.Ditte _Ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
					try
					{
						S_Controls.Collections.S_ControlsCollection _SColl = new S_Controls.Collections.S_ControlsCollection();

						S_Controls.Collections.S_Object s_DittaId = new S_Controls.Collections.S_Object();
						s_DittaId.ParameterName = "p_Ditta_Id";
						s_DittaId.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
						s_DittaId.Direction = ParameterDirection.Input;
						s_DittaId.Index = 0;
						s_DittaId.Value = itemId;

						S_Controls.Collections.S_Object s_ServizioId = new S_Controls.Collections.S_Object();
						s_ServizioId.ParameterName = "p_Servizio_Id";
						s_ServizioId.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
						s_ServizioId.Direction = ParameterDirection.Input;
						s_ServizioId.Index = 1;
						s_ServizioId.Value = Convert.ToInt32(dr["Id"].ToString());		

						_SColl.Add(s_DittaId);
						_SColl.Add(s_ServizioId);


						Classi.ExecuteType Operazione;

						if (dr["Operazione"].ToString() == "I" )
							Operazione = Classi.ExecuteType.Insert;
						else 
							Operazione = Classi.ExecuteType.Delete;
						
						_Ditte.UpdateServizi_Ditta(_SColl, Operazione);

					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
			}
		}

		private void UpdateFornitori_Ditta(DataTable UpdateDataTable)
		{
			foreach (DataRow dr in UpdateDataTable.Rows)
			{
				if (dr["Operazione"] != DBNull.Value)
				{
					Classi.ClassiAnagrafiche.Ditte _Ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
					try
					{
						S_Controls.Collections.S_ControlsCollection _SColl = new S_Controls.Collections.S_ControlsCollection();

						S_Controls.Collections.S_Object s_DittaId = new S_Controls.Collections.S_Object();
						s_DittaId.ParameterName = "p_Ditta_Id";
						s_DittaId.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
						s_DittaId.Direction = ParameterDirection.Input;
						s_DittaId.Index = 0;
						s_DittaId.Value = itemId;

						S_Controls.Collections.S_Object s_Fornitore_Id = new S_Controls.Collections.S_Object();
						s_Fornitore_Id.ParameterName = "p_Fornitore_Id";
						s_Fornitore_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
						s_Fornitore_Id.Direction = ParameterDirection.Input;
						s_Fornitore_Id.Index = 1;
						s_Fornitore_Id.Value = Convert.ToInt32(dr["idD"].ToString());		

						_SColl.Add(s_DittaId);
						_SColl.Add(s_Fornitore_Id);
						Classi.ExecuteType Operazione;

						if (dr["Operazione"].ToString() == "I" )
							Operazione = Classi.ExecuteType.Insert;
						else 
							Operazione = Classi.ExecuteType.Delete;
						
						_Ditte.UpdateFornitori_Ditta(_SColl, Operazione);

					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
			}
		}

		private void BindProvince()
		{
			
			this.cmbsProvincia.Items.Clear();
		
			Classi.ProvinceComuni _ProvCom = new TheSite.Classi.ProvinceComuni();
				
			DataSet _MyDs = _ProvCom.GetData().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				//this.cmbsProvincia.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
				//_MyDs.Tables[0], "descrizione_breve", "provincia_id", "- Selezionare una Provincia -", "0");
				this.cmbsProvincia.DataSource=_MyDs;
				this.cmbsProvincia.DataTextField = "descrizione_breve";
				this.cmbsProvincia.DataValueField = "provincia_id";
				this.cmbsProvincia.DataBind();
			}			
		}

		private void BindComuni()
		{			
			this.cmbsComune.Items.Clear();

			Classi.ProvinceComuni _ProvCom = new TheSite.Classi.ProvinceComuni();
			S_ControlsCollection _SColl = new S_ControlsCollection();
			S_Controls.Collections.S_Object s_Provid = new S_Object();			
			s_Provid.ParameterName = "p_provincia_id";
			s_Provid.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer; 
			s_Provid.Direction = ParameterDirection.Input;			
			s_Provid.Index = 0;
			s_Provid.Value = cmbsProvincia.SelectedValue;
			
			_SColl.Add(s_Provid);
						
			DataSet _MyDs = _ProvCom.GetComune(_SColl).Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				//this.cmbsComune.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
				//	_MyDs.Tables[0], "descrizione", "comune_id", "- Selezionare un Comune -", "0");				
				this.cmbsComune.DataSource=_MyDs;
				this.cmbsComune.DataTextField = "descrizione";
				this.cmbsComune.DataValueField = "comune_id";
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

			
		
		private void BindTipologiaDitta()
		{
			
			this.cmbsTipo.Items.Clear();
		
			Classi.ClassiAnagrafiche.TipologiaDitta _TipoDitta = new TheSite.Classi.ClassiAnagrafiche.TipologiaDitta();
			
			DataSet _MyDs = _TipoDitta.GetData().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsTipo.DataSource = _MyDs.Tables[0];
				this.cmbsTipo.DataTextField = "descrizione";
				this.cmbsTipo.DataValueField = "tipologiaditta_id";
				this.cmbsTipo.DataBind();			
			}			
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
			Session.Add("ServiziDitta", _DsListBox.Tables["ServiziDitta"]);
			
			this.ListBoxRight.DataSource = _DsListBox.Tables["ServiziDitta"];
			this.ListBoxRight.DataValueField = "Id";
			this.ListBoxRight.DataTextField = "Servizio";
			this.ListBoxRight.DataBind();
			this.ListBoxRight.SelectedIndex = 0;
						
			Classi.ClassiDettaglio.Servizi _Servizi = new TheSite.Classi.ClassiDettaglio.Servizi(HttpContext.Current.User.Identity.Name); 	
			DataView o_DvServizi = new DataView(_Servizi.GetData().Tables[0]);
			if (o_DvServizi.Count > 0)
			{
				foreach (DataRowView o_DrvR in o_DvServizi)
				{
					if (ListBoxRight.Items.FindByValue(o_DrvR["IDSERVIZIO"].ToString()) == null)
					{
						DataRow o_DrR = _DsListBox.Tables["Servizi"].NewRow();
						o_DrR["Id"] = o_DrvR["IDSERVIZIO"].ToString();
						o_DrR["Servizio"] = o_DrvR["DESCRIZIONE"].ToString();
						_DsListBox.Tables["Servizi"].Rows.Add(o_DrR);
					}
				}
			}
			
			this.ListBoxLeft.DataSource = _DsListBox.Tables["Servizi"];
			this.ListBoxLeft.DataValueField = "Id";
			this.ListBoxLeft.DataTextField = "Servizio";
			this.ListBoxLeft.DataBind();
			this.ListBoxLeft.SelectedIndex = 0;

			// Carico le liste per i Fornitori
			if (itemId > 0)
			{				
				Classi.ClassiAnagrafiche.Ditte _DitteF = new TheSite.Classi.ClassiAnagrafiche.Ditte();
				DataView o_DvF = new DataView(_DitteF.GetFornitoriDitta(itemId).Tables[0]);				
				if (o_DvF.Count > 0)
				{
					foreach (DataRowView o_DrvF in o_DvF)
					{
						DataRow o_DrF = _DsListBoxD.Tables["DittaSubDitta"].NewRow();
						o_DrF["IdD"] = o_DrvF["idD"].ToString();
						o_DrF["DittaSubAss"] = o_DrvF["DESCRIZIONE"].ToString();
						o_DrF["IdUtente"] = "1"; // Non Serve
						_DsListBoxD.Tables["DittaSubDitta"].Rows.Add(o_DrF);
					}
				}
			}

			Session.Add("FornitoriDitta", _DsListBoxD.Tables["DittaSubDitta"]);
			
			this.ListBoxRightF.DataSource = _DsListBoxD.Tables["DittaSubDitta"];
			this.ListBoxRightF.DataValueField = "IdD";
			this.ListBoxRightF.DataTextField = "DittaSubAss";
			this.ListBoxRightF.DataBind();
			this.ListBoxRightF.SelectedIndex = 0;
						
			Classi.ClassiAnagrafiche.Ditte _DitteFor = new TheSite.Classi.ClassiAnagrafiche.Ditte();
			DataView o_DvFor = new DataView(_DitteFor.GetDitteSub().Tables[0]);
			if (o_DvFor.Count > 0)
			{
				foreach (DataRowView o_DrvRFor in o_DvFor)
				{
					if (ListBoxRightF.Items.FindByValue(o_DrvRFor["idD"].ToString()) == null)
					{
						DataRow o_DrRFor = _DsListBoxD.Tables["DitteSub"].NewRow();
						o_DrRFor["IdD"] = o_DrvRFor["IdD"].ToString();
						o_DrRFor["DittaSub"] = o_DrvRFor["DESCRIZIONE"].ToString();
						_DsListBoxD.Tables["DitteSub"].Rows.Add(o_DrRFor);
					}
				}
			}
			
			this.ListBoxLeftF.DataSource = _DsListBoxD.Tables["DitteSub"];
			this.ListBoxLeftF.DataValueField = "IdD";
			this.ListBoxLeftF.DataTextField = "DittaSub";
			this.ListBoxLeftF.DataBind();
			this.ListBoxLeftF.SelectedIndex = 0;
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
			this.cmbsTipo.SelectedIndexChanged += new System.EventHandler(this.cmbsTipo_SelectedIndexChanged);
			this.btnAssocia.Click += new System.EventHandler(this.btnAssocia_Click);
			this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
			this.btnAssociaF.Click += new System.EventHandler(this.btnAssociaF_Click);
			this.btnEliminaF.Click += new System.EventHandler(this.btnEliminaF_Click);
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
			
			Classi.ClassiAnagrafiche.Ditte _Ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
				
			this.TxtsCAP.DBDefaultValue = DBNull.Value;
			this.txtsDescrizione.DBDefaultValue = DBNull.Value;
			this.txtsEmail.DBDefaultValue = DBNull.Value;
			this.txtsIndirizzo.DBDefaultValue = DBNull.Value;
			this.txtsReferente.DBDefaultValue = DBNull.Value;
			this.txtsTelefono.DBDefaultValue = DBNull.Value;
			this.cmbsProvincia.DBDefaultValue=DBNull.Value;
			this.cmbsComune.DBDefaultValue=0;
			this.cmbsTipo.DBDefaultValue=DBNull.Value;

			this.TxtsCAP.Text=this.TxtsCAP.Text.Trim();
			this.txtsDescrizione.Text=this.txtsDescrizione.Text.Trim();
			this.txtsEmail.Text=this.txtsEmail.Text.Trim();
			this.txtsIndirizzo.Text=this.txtsIndirizzo.Text.Trim();
			this.txtsReferente.Text=this.txtsReferente.Text.Trim();
			this.txtsTelefono.Text=this.txtsTelefono.Text.Trim();
			
			int i_RowsAffected = 0;

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			_SCollection.AddItems(this.PanelEdit.Controls);

			try
			{
				if (itemId == 0)
					i_RowsAffected = _Ditte.Add(_SCollection);
				else
					i_RowsAffected = _Ditte.Update(_SCollection, itemId);
			
				if(i_RowsAffected==-11)
				{
					Classi.SiteJavaScript.msgBox(this.Page,"Ditta già inserita nel DataBase.");
				}

				if ( i_RowsAffected > 0 )
				{
					// Aggiorno i Serivizi
					if (this.ListBoxRight.Items.Count >= 0)
					{
						DataTable o_Dt = (DataTable) Session["ServiziDitta"];
						DataView o_Dv = new DataView(o_Dt);
                    					
						foreach(ListItem o_Litem in this.ListBoxRight.Items)
						{
							o_Dv.RowFilter = "Id = " + o_Litem.Value.ToString();
						
							if ( o_Dv.Count == 0 )
							{
								DataRow o_Dr = o_Dt.NewRow();
								o_Dr["Id"] = o_Litem.Value.ToString();
								o_Dr["Servizio"] = o_Litem.Text.ToString();
								o_Dr["IdUtente"] = i_RowsAffected;
								o_Dr["Operazione"] = "I";
								o_Dt.Rows.Add(o_Dr);
							}
							else if ( o_Dv.Count == 1)
							{
								o_Dv[0]["Operazione"] = DBNull.Value;
							}						
						}
						this.UpdateServizi_Ditta(o_Dt); 
						Session.Remove("ServiziDitta");
					}	
			
					// Aggiorno i Fornitori
					if (this.ListBoxRightF.Items.Count >= 0)
					{
						DataTable o_DtF = (DataTable) Session["FornitoriDitta"];
						DataView o_DvF = new DataView(o_DtF);
                    					
						foreach(ListItem o_LitemF in this.ListBoxRightF.Items)
						{
							o_DvF.RowFilter = "idD = " + o_LitemF.Value.ToString();
						
							if ( o_DvF.Count == 0 )
							{
								DataRow o_DrF = o_DtF.NewRow();
								o_DrF["idD"] = o_LitemF.Value.ToString();
								o_DrF["DittaSubAss"] = o_LitemF.Text.ToString();
								o_DrF["IdUtente"] = i_RowsAffected;
								o_DrF["Operazione"] = "I";
								o_DtF.Rows.Add(o_DrF);
							}
							else if ( o_DvF.Count == 1)
							{
								o_DvF[0]["Operazione"] = DBNull.Value;
							}						
						}
						this.UpdateFornitori_Ditta(o_DtF); 
						Session.Remove("FornitoriDitta");
					}	

					if (itemId==0)
						//Server.Transfer("Ditte.aspx?");
						Response.Redirect("EditDitte.aspx?ItemId=" + i_RowsAffected +"&FunId=" + FunId);
						
					else						
						Server.Transfer("Ditte.aspx");
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
			//Response.Redirect((String) ViewState["UrlReferrer"]);
//			Server.Transfer("Ditte.aspx?FunID="+FunId+"&Ricarica=yes");
			Server.Transfer("Ditte.aspx");
		}

		private void btnsElimina_Click(object sender, System.EventArgs e)
		{
			try
			{
				Classi.ClassiAnagrafiche.Ditte _Ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
				
				this.TxtsCAP.DBDefaultValue = DBNull.Value;
				this.txtsDescrizione.DBDefaultValue = DBNull.Value;
				this.txtsEmail.DBDefaultValue = DBNull.Value;
				this.txtsIndirizzo.DBDefaultValue = DBNull.Value;
				this.txtsReferente.DBDefaultValue = DBNull.Value;
				this.txtsTelefono.DBDefaultValue = DBNull.Value;
				this.cmbsProvincia.DBDefaultValue=DBNull.Value;
				this.cmbsComune.DBDefaultValue=DBNull.Value;
				this.cmbsTipo.DBDefaultValue=DBNull.Value;

				int i_RowsAffected = 0;

				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

				_SCollection.AddItems(this.PanelEdit.Controls);

				

					i_RowsAffected = _Ditte.Delete(_SCollection, itemId);

					if ( i_RowsAffected == -1 )
						//Response.Redirect((String) ViewState["UrlReferrer"]);
						//Response.Redirect("Ditte.aspx?FunID="+FunId+"&Ricarica=yes");
						Server.Transfer("Ditte.aspx?");
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}	
		}

		private void btnElimina_Click(object sender, System.EventArgs e)
		{
			string s_strSelection;
			string s_strSelectionValue;
			if (ListBoxRight.SelectedItem != null)
			{
				s_strSelection = ListBoxRight.SelectedItem.Text;
				s_strSelectionValue = ListBoxRight.SelectedItem.Value;
				if (ListBoxLeft.Items.FindByValue(s_strSelectionValue)== null )
				{
					ListItem o_Li = new ListItem(s_strSelection, s_strSelectionValue);
					ListBoxLeft.Items.Add(o_Li);
					ListBoxLeft.SelectedIndex = 0;
					ListBoxRight.Items.Remove(o_Li);
				}
			}
		}

		private void btnAssocia_Click(object sender, System.EventArgs e)
		{
			string s_strSelection;
			string s_strSelectionValue;
			if (ListBoxLeft.SelectedItem != null)
			{
				s_strSelection = ListBoxLeft.SelectedItem.Text;
				s_strSelectionValue = ListBoxLeft.SelectedItem.Value;
				if (ListBoxRight.Items.FindByValue(s_strSelectionValue)== null )
				{
					ListItem o_Li = new ListItem(s_strSelection, s_strSelectionValue);
					ListBoxRight.Items.Add(o_Li);
					ListBoxRight.SelectedIndex = 0;
					ListBoxLeft.Items.Remove(o_Li);
				}
			}
		}

		private void cmbsTipo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (itemId > 0)
			ControllaListeFornitori();
		}

		private void btnAssociaF_Click(object sender, System.EventArgs e)
		{
			string s_strSelection;
			string s_strSelectionValue;
			if (ListBoxLeftF.SelectedItem != null)
			{
				s_strSelection = ListBoxLeftF.SelectedItem.Text;
				s_strSelectionValue = ListBoxLeftF.SelectedItem.Value;
				if (ListBoxRightF.Items.FindByValue(s_strSelectionValue)== null )
				{
					ListItem o_Li = new ListItem(s_strSelection, s_strSelectionValue);
					ListBoxRightF.Items.Add(o_Li);
					ListBoxRightF.SelectedIndex = 0;
					ListBoxLeftF.Items.Remove(o_Li);
				}
			}
		}

		private void btnEliminaF_Click(object sender, System.EventArgs e)
		{
			string s_strSelection;
			string s_strSelectionValue;
			if (ListBoxRightF.SelectedItem != null)
			{
				s_strSelection = ListBoxRightF.SelectedItem.Text;
				s_strSelectionValue = ListBoxRightF.SelectedItem.Value;
				if (ListBoxLeftF.Items.FindByValue(s_strSelectionValue)== null )
				{
					ListItem o_Li = new ListItem(s_strSelection, s_strSelectionValue);
					ListBoxLeftF.Items.Add(o_Li);
					ListBoxLeftF.SelectedIndex = 0;
					ListBoxRightF.Items.Remove(o_Li);
				}
			}
		}
	}


	
}
