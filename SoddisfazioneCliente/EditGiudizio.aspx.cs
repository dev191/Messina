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


namespace TheSite.SoddisfazioneCliente
{
	/// <summary>
	/// Descrizione di riepilogo per EditGiudizio.
	/// </summary>
	public class EditGiudizio : System.Web.UI.Page
	{
			int itemId = 0;
			string CodEdificio="";

		//
			protected Csy.WebControls.MessagePanel PanelMess;
			protected System.Web.UI.WebControls.Label lblDenominazione;
			protected System.Web.UI.WebControls.Label lblIndirizzo;
			protected System.Web.UI.WebControls.Label lblComune;
			protected System.Web.UI.WebControls.Label lblTelefono;
			protected S_Controls.S_Label lblCodEdificio;
		//
			protected S_Controls.S_Button btnsSalva;
			protected S_Controls.S_Button btnsElimina;
			protected System.Web.UI.WebControls.Button btnAnnulla;
			protected System.Web.UI.WebControls.Label lblFirstAndLast;
			protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
			
			int FunId = 0;

			protected S_Controls.S_ComboBox cmbsServizio;
			protected S_Controls.S_ComboBox cmbsPiano;
			protected S_Controls.S_ComboBox cmbsGiudizio;
			protected WebControls.CalendarPicker dataIspezione;
			protected S_Controls.S_TextBox txtNumero;
			protected S_Controls.S_TextBox txtAttivitaIsp;
			protected S_Controls.S_TextBox txtAnnotazioni;
			protected System.Web.UI.WebControls.RegularExpressionValidator regtxtNumero;
			protected System.Web.UI.WebControls.RequiredFieldValidator rfvGiudizio;
			protected WebControls.RicercaModulo RicercaModulo1;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenblid;
			protected System.Web.UI.WebControls.RequiredFieldValidator rfvEdificio;
			protected System.Web.UI.WebControls.Label lblOperazione;
			protected System.Web.UI.WebControls.TextBox blid_scelto;
			
			TheSite.SoddisfazioneCliente.Giudizio _fp;

		protected WebControls.UserStanze UserStanze1;


			private void Page_Load(object sender, System.EventArgs e)
			{	
	
				this.txtNumero.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
				this.txtNumero.Attributes.Add("onpaste","return nonpaste();");
			
	
				FunId = Int32.Parse(Request["FunId"]);			
		
				if (Request["ItemId"] != null) 
				{
					itemId = Int32.Parse(Request["ItemId"]);
				}
				if (Request["CodEdificio"] != null) 
				{
					CodEdificio = Request["CodEdificio"];	
					
				}
				this.RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);
				this.RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindPiano);
				UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
				UserStanze1.NameComboPiano="cmbsPiano";

				if(this.RicercaModulo1.Idbl!="")
				{
					hiddenblid.Value=this.RicercaModulo1.TxtCodice.Text;
				}
				else
				{
					hiddenblid.Value=this.CodEdificio;
				}
		
					
				this.btnsSalva.Attributes.Add("onclick", "javascript:return seledificio();");
				
				this.cmbsPiano.Attributes.Add("onchange","clearRoom();");
				if (!Page.IsPostBack )
				{	
					

					if (itemId != 0) 
					{
						
						BindPiano(CodEdificio);
						this.BindServizio(CodEdificio);	
						this.BindGiudizio();
						DataSet _MyDs = new DataSet();
						Classi.GiudizioCliente.Giudizio _Giudizio = new TheSite.Classi.GiudizioCliente.Giudizio();
						_MyDs = _Giudizio.GetSingleData(itemId);
					
						if (_MyDs.Tables[0].Rows.Count == 1)
						{					
							DataRow _Dr = _MyDs.Tables[0].Rows[0];
						
							this.lblCodEdificio.Text = (string) _Dr["codbl"];	
							this.lblDenominazione.Text= (string) _Dr["edificioDen"];
							this.lblIndirizzo.Text= (string) _Dr["edificioInd"];
							this.lblComune.Text= (string) _Dr["edificioCom"];
						
							
							if (_Dr["blid"] != DBNull.Value)
								blid_scelto.Text = _Dr["blid"].ToString();
							

							if (_Dr["pianoid"] != DBNull.Value){
								if (_Dr["pianoid"].ToString()!= "0")
								{
									this.cmbsPiano.SelectedValue= _Dr["pianoid"].ToString();}
								}

							

							if (_Dr["stanzaid"] != DBNull.Value){
								if (_Dr["stanzaid"].ToString()!= "0"){
										this.UserStanze1.IdStanza= _Dr["stanzaid"].ToString();}
									}

							if (_Dr["descstanza"] != DBNull.Value || _Dr["descstanza"].ToString()!= "-")
							{
								this.UserStanze1.DescStanza= _Dr["descstanza"].ToString();
							}		

							if (_Dr["servizioid"] != DBNull.Value){
								if (_Dr["servizioid"].ToString()!= "0")
								{
									this.cmbsServizio.SelectedValue= _Dr["servizioid"].ToString();}
								}
								

							if (_Dr["sotid"] != DBNull.Value)
								this.cmbsGiudizio.SelectedValue= _Dr["sotid"].ToString();

							if (_Dr["numerocont"] != DBNull.Value)
								this.txtNumero.Text = (string) _Dr["numerocont"].ToString();

							if (_Dr["attivitaisp"] != DBNull.Value)
								this.txtAttivitaIsp.Text = (string) _Dr["attivitaisp"].ToString();

							if (_Dr["annotazioni"] != DBNull.Value)
								this.txtAnnotazioni.Text = (string) _Dr["annotazioni"].ToString();
							
							

							if (_Dr["datainsert"]!=DBNull.Value)
								dataIspezione.Datazione.Text =System.DateTime.Parse(_Dr["datainsert"].ToString()).ToShortDateString();

						
							this.lblOperazione.Text = "Modifica Giudizio a Freddo per Edificio: " + this.lblCodEdificio.Text;
							this.lblFirstAndLast.Visible = false;						
							this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");	
							lblFirstAndLast.Text = _Giudizio.GetFirstAndLastUser(_Dr);
						
					

						}
					
					}
					else
					{
						this.BindPiano("");
						this.BindServizio(RicercaModulo1.TxtCodice.Text);	
						this.BindGiudizio();
						this.lblOperazione.Text = "Inserimento Giudizio";
						this.lblFirstAndLast.Visible = false;
						this.btnsElimina.Visible = false;
						
						
				
					}	
			

					if (Request["TipoOper"] == "read")	
					{
						AbilitaControlli(false);
						this.lblOperazione.Text = "Visualizzazione Giudizio: " + this.lblCodEdificio.Text;
					}
					ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
					if(Context.Handler is TheSite.SoddisfazioneCliente.Giudizio) 
					{
						_fp = (TheSite.SoddisfazioneCliente.Giudizio) Context.Handler;
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
		private string IDBL
		{
			get{return hiddenblid.Value;}
			set{hiddenblid.Value =value;}
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
				this.cmbsPiano.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
			}
		}

		private void BindGiudizio()
		{
			
			this.cmbsGiudizio.Items.Clear();
			Classi.GiudizioCliente.Giudizio _Giudizio = new TheSite.Classi.GiudizioCliente.Giudizio(HttpContext.Current.User.Identity.Name);
			DataSet _MyDs = _Giudizio.GetData().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{				
				this.cmbsGiudizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "SDESCRIZIONE","SID", "- Selezionare Giudizio -", "0");
				this.cmbsGiudizio.DataTextField = "SDESCRIZIONE";
				this.cmbsGiudizio.DataValueField = "SID";
				this.cmbsGiudizio.DataBind();
			}			
	
		}


		

//		private void BindStanza(string blid_scelto)
//		{
//		  	
//			this.cmbsStanza.Items.Clear();
//			int bl_id = 0;
//			TheSite.Classi.ManOrdinaria.Richiesta  _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
//			if(blid_scelto.ToString()!="")
//			{
//				bl_id = Convert.ToInt32(blid_scelto.ToString());
//			}
//			else
//			{
//				bl_id = (RicercaModulo1.Idbl=="")?0:int.Parse(RicercaModulo1.Idbl);
//			}
//			int Piano=(cmbsPiano.SelectedValue=="")?0:int.Parse(cmbsPiano.SelectedValue); 
//			
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
//				string s_Messagggio = "- Nessua Stanza -";
//				this.cmbsStanza.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
//			}
//			cmbsStanza.Attributes.Add("OnChange","");
//		}

	
		private void BindServizio(string CodEdificio)
		{
				
			this.cmbsServizio.Items.Clear();
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
			}
			else
			{
				string s_Messagggio = "Non Definito";
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0"));
			}		
		}


		
			private void AbilitaControlli(bool enabled)
			{
				this.cmbsServizio.Enabled = enabled;
				this.cmbsPiano.Enabled = enabled;
				this.cmbsGiudizio.Enabled = enabled;
				this.txtNumero.Enabled = enabled;
				this.txtAnnotazioni.Enabled = enabled;
				this.txtAttivitaIsp.Enabled = enabled;
				this.dataIspezione.Datazione.Enabled = enabled;
				this.btnsSalva.Enabled=enabled;
				this.btnsElimina.Enabled = enabled;
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
			private void btnsElimina_Click(object sender, System.EventArgs e)
			{
				try
				{
					
					TheSite.Classi.GiudizioCliente.Giudizio _Giudizio = new TheSite.Classi.GiudizioCliente.Giudizio();
					
					int i_RowsAffected = 0;

					S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
					S_Controls.Collections.S_Object s_p_id_piani  = new S_Object();
					s_p_id_piani.ParameterName = "p_id_piani";
					s_p_id_piani.DbType = CustomDBType.Integer;
					s_p_id_piani.Direction = ParameterDirection.Input;
					s_p_id_piani.Index = _SCollection.Count ;
					s_p_id_piani.Value = (this.cmbsPiano.SelectedValue.ToString()=="")?0:Int32.Parse(this.cmbsPiano.SelectedValue.ToString());
					_SCollection.Add(s_p_id_piani);

					S_Controls.Collections.S_Object s_p_id_stanza   = new S_Object();
					s_p_id_stanza.ParameterName = "p_id_stanza";
					s_p_id_stanza.DbType = CustomDBType.Integer;
					s_p_id_stanza.Direction = ParameterDirection.Input;
					s_p_id_stanza.Index = _SCollection.Count ;
					s_p_id_stanza.Value =UserStanze1.IdStanza;// (this.cmbsStanza.SelectedValue.ToString()=="")?0:Int32.Parse(this.cmbsStanza.SelectedValue.ToString());					
					_SCollection.Add(s_p_id_stanza);

					S_Controls.Collections.S_Object s_p_Servizio_Id = new S_Object();
					s_p_Servizio_Id.ParameterName = "p_Servizio_Id";
					s_p_Servizio_Id.DbType = CustomDBType.Integer;
					s_p_Servizio_Id.Direction = ParameterDirection.Input;
					s_p_Servizio_Id.Index = _SCollection.Count ;
					s_p_Servizio_Id.Value = (this.cmbsServizio.SelectedValue.ToString()=="")?0:Int32.Parse(this.cmbsServizio.SelectedValue.ToString());
					_SCollection.Add(s_p_Servizio_Id);

					S_Controls.Collections.S_Object s_p_Giudizio_Id= new S_Object();
					s_p_Giudizio_Id.ParameterName = "p_Giudizio_Id";
					s_p_Giudizio_Id.DbType = CustomDBType.Integer;
					s_p_Giudizio_Id.Direction = ParameterDirection.Input;
					s_p_Giudizio_Id.Index = _SCollection.Count ;
					//s_p_Giudizio_Id.Value = this.cmbsGiudizio.SelectedValue;
					s_p_Giudizio_Id.Value = (this.cmbsGiudizio.SelectedValue ==string.Empty)? 0:Int32.Parse(this.cmbsGiudizio.SelectedValue);	
					_SCollection.Add(s_p_Giudizio_Id);

					S_Controls.Collections.S_Object s_p_numero = new S_Object();
					s_p_numero.ParameterName = "p_numero";
					s_p_numero.DbType = CustomDBType.Integer;
					s_p_numero.Direction = ParameterDirection.Input;
					s_p_numero.Index = _SCollection.Count ;
					s_p_numero.Value = (this.txtNumero.Text.Trim()=="")?1:Int32.Parse(this.txtNumero.Text.Trim());
					_SCollection.Add(s_p_numero);

					S_Controls.Collections.S_Object s_p_attivita = new S_Object();
					s_p_attivita.ParameterName = "p_attivita";
					s_p_attivita.DbType = CustomDBType.VarChar;
					s_p_attivita.Direction = ParameterDirection.Input;
					s_p_attivita.Index = _SCollection.Count ;
					s_p_attivita.Size=500;
					s_p_attivita.Value = this.txtAttivitaIsp.Text.Trim();
					_SCollection.Add(s_p_attivita);
				
					S_Controls.Collections.S_Object s_p_annotazioni = new S_Object();
					s_p_annotazioni.ParameterName = "p_annotazioni";
					s_p_annotazioni.DbType = CustomDBType.VarChar;
					s_p_annotazioni.Direction = ParameterDirection.Input;
					s_p_annotazioni.Index = _SCollection.Count ;
					s_p_annotazioni.Size=4000;
					s_p_annotazioni.Value = this.txtAnnotazioni.Text.Trim();
					_SCollection.Add(s_p_annotazioni);
				
				
					S_Controls.Collections.S_Object s_p_blid = new S_Object();
					s_p_blid .ParameterName = "p_blid";
					s_p_blid.DbType = CustomDBType.Integer;
					s_p_blid.Direction = ParameterDirection.Input;
					s_p_blid.Index = _SCollection.Count ;
					if(blid_scelto.Text.ToString()=="")
					{
						s_p_blid.Value = (RicercaModulo1.Idbl=="")?0:int.Parse(RicercaModulo1.Idbl);
					}
					else
					{
						s_p_blid.Value = Convert.ToInt32(blid_scelto.Text.Trim());
					}
					_SCollection.Add(s_p_blid);

					S_Controls.Collections.S_Object s_p_dataIspezione = new S_Object();
					s_p_dataIspezione.ParameterName = "p_dataIspezione";
					s_p_dataIspezione.DbType = CustomDBType.VarChar;
					s_p_dataIspezione.Direction = ParameterDirection.Input;
					s_p_dataIspezione.Index = _SCollection.Count ;
					s_p_dataIspezione.Size = 10;
					s_p_dataIspezione.Value = this.dataIspezione.Datazione.Text;
					_SCollection.Add(s_p_dataIspezione);


					i_RowsAffected = _Giudizio.Delete(_SCollection, itemId);

					if ( i_RowsAffected == -1 )					
						Server.Transfer("Giudizio.aspx?FunId =" + FunId);
				}
				catch (Exception ex)
				{				
					string s_Err =  ex.Message.ToString().ToUpper();
					PanelMess.ShowError(s_Err, true);
				}	
			}

			private void btnsSalva_Click(object sender, System.EventArgs e)
			{


				
				if(cmbsGiudizio.SelectedIndex ==0) 
				{
					rfvGiudizio.Visible =true;
					return;
				}

				int i_RowsAffected = 0;
				
				
				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();				
				S_Controls.Collections.S_Object s_p_id_piani  = new S_Object();
				s_p_id_piani.ParameterName = "p_id_piani";
				s_p_id_piani.DbType = CustomDBType.Integer;
				s_p_id_piani.Direction = ParameterDirection.Input;
				s_p_id_piani.Index = _SCollection.Count ;
				s_p_id_piani.Value = (this.cmbsPiano.SelectedValue.ToString()=="")?0:Int32.Parse(this.cmbsPiano.SelectedValue.ToString());
				_SCollection.Add(s_p_id_piani);

				S_Controls.Collections.S_Object s_p_id_stanza   = new S_Object();
				s_p_id_stanza.ParameterName = "p_id_stanza";
				s_p_id_stanza.DbType = CustomDBType.Integer;
				s_p_id_stanza.Direction = ParameterDirection.Input;
				s_p_id_stanza.Index = _SCollection.Count ;
				s_p_id_stanza.Value =UserStanze1.IdStanza;// (this.cmbsStanza.SelectedValue.ToString()=="")?0:Int32.Parse(this.cmbsStanza.SelectedValue.ToString());					
				_SCollection.Add(s_p_id_stanza);

				S_Controls.Collections.S_Object s_p_Servizio_Id = new S_Object();
				s_p_Servizio_Id.ParameterName = "p_Servizio_Id";
				s_p_Servizio_Id.DbType = CustomDBType.Integer;
				s_p_Servizio_Id.Direction = ParameterDirection.Input;
				s_p_Servizio_Id.Index = _SCollection.Count ;
				s_p_Servizio_Id.Value = (this.cmbsServizio.SelectedValue.ToString()=="")?0:Int32.Parse(this.cmbsServizio.SelectedValue.ToString());
				_SCollection.Add(s_p_Servizio_Id);

				S_Controls.Collections.S_Object s_p_Giudizio_Id= new S_Object();
				s_p_Giudizio_Id.ParameterName = "p_Giudizio_Id";
				s_p_Giudizio_Id.DbType = CustomDBType.Integer;
				s_p_Giudizio_Id.Direction = ParameterDirection.Input;
				s_p_Giudizio_Id.Index = _SCollection.Count ;
				s_p_Giudizio_Id.Value = (this.cmbsGiudizio.SelectedValue =="0")? 5:Int32.Parse(this.cmbsGiudizio.SelectedValue);	
				_SCollection.Add(s_p_Giudizio_Id);

				S_Controls.Collections.S_Object s_p_numero = new S_Object();
				s_p_numero.ParameterName = "p_numero";
				s_p_numero.DbType = CustomDBType.Integer;
				s_p_numero.Direction = ParameterDirection.Input;
				s_p_numero.Index = _SCollection.Count ;
				s_p_numero.Value = (this.txtNumero.Text.Trim()=="" || this.txtNumero.Text=="0")?1:Int32.Parse(this.txtNumero.Text.Trim());
				_SCollection.Add(s_p_numero);

				S_Controls.Collections.S_Object s_p_attivita = new S_Object();
				s_p_attivita.ParameterName = "p_attivita";
				s_p_attivita.DbType = CustomDBType.VarChar;
				s_p_attivita.Direction = ParameterDirection.Input;
				s_p_attivita.Index = _SCollection.Count ;
				s_p_attivita.Size=500;
				s_p_attivita.Value = this.txtAttivitaIsp.Text.Trim();
				_SCollection.Add(s_p_attivita);
				
				S_Controls.Collections.S_Object s_p_annotazioni = new S_Object();
				s_p_annotazioni.ParameterName = "p_annotazioni";
				s_p_annotazioni.DbType = CustomDBType.VarChar;
				s_p_annotazioni.Direction = ParameterDirection.Input;
				s_p_annotazioni.Index = _SCollection.Count ;
				s_p_annotazioni.Size=4000;
				s_p_annotazioni.Value = this.txtAnnotazioni.Text.Trim();
				_SCollection.Add(s_p_annotazioni);
				
				
				S_Controls.Collections.S_Object s_p_blid = new S_Object();
				s_p_blid .ParameterName = "p_blid";
				s_p_blid.DbType = CustomDBType.Integer;
				s_p_blid.Direction = ParameterDirection.Input;
				s_p_blid.Index = _SCollection.Count ;
				if(blid_scelto.Text.ToString()=="")
				{
					s_p_blid.Value = (RicercaModulo1.Idbl=="")?0:int.Parse(RicercaModulo1.Idbl);
				}
				else
				{
					s_p_blid.Value = Convert.ToInt32(blid_scelto.Text.Trim());
				}
				_SCollection.Add(s_p_blid);

				S_Controls.Collections.S_Object s_p_dataIspezione = new S_Object();
				s_p_dataIspezione.ParameterName = "p_dataIspezione";
				s_p_dataIspezione.DbType = CustomDBType.VarChar;
				s_p_dataIspezione.Direction = ParameterDirection.Input;
				s_p_dataIspezione.Index = _SCollection.Count ;
				s_p_dataIspezione.Size = 10;
				s_p_dataIspezione.Value = this.dataIspezione.Datazione.Text;
				_SCollection.Add(s_p_dataIspezione);


				try
				{
					if (itemId == 0)
					{
						
						TheSite.Classi.GiudizioCliente.Giudizio _Giudizio = new TheSite.Classi.GiudizioCliente.Giudizio();
						i_RowsAffected =  _Giudizio.Add(_SCollection);
					}
					else
					{
						TheSite.Classi.GiudizioCliente.Giudizio _Giudizio = new TheSite.Classi.GiudizioCliente.Giudizio();
						i_RowsAffected =  _Giudizio.Update(_SCollection,itemId);
					}

					if (i_RowsAffected==-11)
					{
						
					
					}
					else
					{
						Server.Transfer("Giudizio.aspx?FunId =" + FunId);					
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
				Server.Transfer("Giudizio.aspx?FunId =" + FunId);	
			}
	
		}
	
	}
	
		


		

		

	

