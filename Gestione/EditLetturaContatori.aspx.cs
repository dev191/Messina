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
using MyCollection;
using TheSite.Classi;
using StampaRapportiPdf.Classi;

namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per EditLetturaContatori.
	/// </summary>
	public class EditLetturaContatori : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected S_Controls.S_ComboBox cmbsPiano;
		protected S_Controls.S_ComboBox cmbsStanza;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_ComboBox cmbsApparecchiatura;
		protected S_Controls.S_ComboBox CmbsEnergia;
		protected S_Controls.S_TextBox TxtValoreLetturaInt;
		protected S_Controls.S_TextBox TxtValoreLetturaDec;
		protected S_Controls.S_TextBox TxtNota;
		protected Csy.WebControls.DataPanel Datapanel1;
		protected Csy.WebControls.DataPanel PanelRicerca;
		public static int FunId = 0;				
		public static string HelpLink = string.Empty;
		protected WebControls.CodiceApparecchiature CodiceApparecchiature1;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.Addetti Addetti1;
		protected S_Controls.S_Button BtnSalva;
		protected S_Controls.S_Button BtnAnnulla;
		protected WebControls.PageTitle PageTitle1;
		string id_lettura;
		protected S_Controls.S_Button BtnElimina;
		protected System.Web.UI.WebControls.TextBox txtsorainmin;
		protected S_Controls.S_TextBox itemId;
		protected System.Web.UI.WebControls.TextBox txtsorain;
		protected System.Web.UI.WebControls.RequiredFieldValidator RfvEnergia;
		
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RfvData;
		protected System.Web.UI.WebControls.RequiredFieldValidator RFVAddetto;
		LetturaContatori _fp;

		
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			RfvData.ControlToValidate = CalendarPicker1.ID + ":" + CalendarPicker1.Datazione.ID;
			RFVAddetto.ControlToValidate= Addetti1.ID +":"+ Addetti1.TextIdAddetto.ID;


			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];

			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;	
			
			#region Delegati
			RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);
			RicercaModulo1.DelegateIDBLEdificio1  +=new  WebControls.DelegateIDBLEdificio(this.BindPiano);	
			CodiceApparecchiature1.NameComboApparecchiature ="cmbsApparecchiatura";
			CodiceApparecchiature1.NameComboServizio ="cmbsServizio";
			CodiceApparecchiature1.NameUserControlRicercaModulo  ="RicercaModulo1";
			CodiceApparecchiature1.s_RichiestaLettura="si";
			#endregion

			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsApparecchiatura.ClientID + "').disabled = true;");
		
			#region AggiuntaProprietà
			this.cmbsServizio.Attributes.Add("onchange", sbValid.ToString());
			txtsorain.Attributes.Add("onkeypress","SoloNumeri();");
			txtsorain.Attributes.Add("onpaste","return false;");
			txtsorain.Attributes.Add("maxlength","2");			
			txtsorain.Attributes.Add("onblur","return ControllaOra();");
			txtsorain.Attributes.Add("onblur","formatNum(this.id);");

			txtsorainmin.Attributes.Add("onkeypress","SoloNumeri();");
			txtsorainmin.Attributes.Add("onpaste","return false;");
			txtsorainmin.Attributes.Add("onblur","return ControllaMin();");
			txtsorainmin.Attributes.Add("maxlength","2");
			txtsorainmin.Attributes.Add("onblur","formatNum(this.id);");

			TxtValoreLetturaDec.Attributes.Add("onkeypress","SoloNumeri();");
			TxtValoreLetturaDec.Attributes.Add("onpaste","return false;");
			TxtValoreLetturaDec.Attributes.Add("onblur","formatNum(this.id);");

			TxtValoreLetturaInt.Attributes.Add("onkeypress","SoloNumeri();");
			TxtValoreLetturaInt.Attributes.Add("onpaste","return false;");
			TxtValoreLetturaInt.Attributes.Add("onblur","formatNum(this.id);");
			#endregion
			


			if (!IsPostBack) 
			{
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];
			
				if (Request.QueryString["id_lettura"]!=null)
				{
					this.id_lettura =(string)Request.QueryString["id_lettura"];
					itemId.Text=id_lettura;
				}
				

				
				#region RecuperoDatiPerModifica
				if(id_lettura!=null)
				{
					//PanelRicerca.Visible=false;
					DataSet _MyDs = new DataSet();
					Classi.ClassiAnagrafiche.LetturaContatori _AllLetturaContatori = new Classi.ClassiAnagrafiche.LetturaContatori();
					_MyDs = _AllLetturaContatori.GetSingleData(Convert.ToInt32(id_lettura)); 
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];

						if (_Dr["nota"] != DBNull.Value)
							this.TxtNota.Text= (string) _Dr["nota"];
					
						if (_Dr["valorelettura"] != DBNull.Value)
						{
							string val= (Convert.ToDouble(_Dr["valorelettura"].ToString())).ToString();
							TxtValoreLetturaInt.Text =  Classi.Function.GetTypeNumber(val,Classi.NumberType.Intero).ToString();				
							TxtValoreLetturaDec.Text =  Classi.Function.GetTypeNumber(val,Classi.NumberType.Decimale).ToString();
							
						}

						if (_Dr["datalettura"] != DBNull.Value)
						{
							CalendarPicker1.Datazione.Text=Convert.ToDateTime(_Dr["datalettura"]).ToShortDateString();
							int appo =Convert.ToDateTime(_Dr["datalettura"]).Hour;
							txtsorain.Text= Convert.ToString(appo).PadLeft(2,'0');
							int appo1 =Convert.ToDateTime(_Dr["datalettura"]).Minute;
							txtsorainmin.Text= Convert.ToString(appo1).PadLeft(2,'0');
						}
						
						if (_Dr["energia"] != DBNull.Value)
							CmbsEnergia.SelectedValue= (string) _Dr["energia"];						
					
						CodiceApparecchiature1.IdApparecchiatura=_Dr["id_eq"].ToString();
						CodiceApparecchiature1.CodiceApparecchiatura=_Dr["eq_id"].ToString();
						CodiceApparecchiature1.s_CodiceApparecchiatura.Enabled=false;

						Addetti1.IdAddetto=_Dr["id_addetto"].ToString();
						Addetti1.NomeCompleto=_Dr["NominativoAddetto"].ToString();

						RicercaModulo1.TxtCodice.Text=_Dr["bl_id"].ToString();
						RicercaModulo1.TxtCodice.Enabled=false;
						RicercaModulo1.TxtRicerca.Enabled=false;
						RicercaModulo1.Ricarica();

						BindApparecchiatura();	
						cmbsApparecchiatura.SelectedValue=_Dr["id_eqstd"].ToString() ;
						cmbsApparecchiatura.Enabled=false;
						
						BindTuttiPiani();
						cmbsPiano.SelectedValue=_Dr["piano"].ToString();
						cmbsPiano.Enabled=false;
						
						BindStanza();
						cmbsStanza.SelectedValue=_Dr["stanza"].ToString();
						cmbsStanza.Enabled=false;

						BindServizio("");
						cmbsServizio.SelectedValue=_Dr["servizio"].ToString();
						cmbsServizio.Enabled=false;
						
					}
					
				}				
				else
					BtnElimina.Enabled=false;

				Addetti1.Set_BL_ID("%");
				#endregion

				
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.LetturaContatori) 
				{
					_fp = (TheSite.Gestione.LetturaContatori) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
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
			this.cmbsPiano.SelectedIndexChanged += new System.EventHandler(this.cmbsPiano_SelectedIndexChanged);
			this.cmbsServizio.SelectedIndexChanged += new System.EventHandler(this.cmbsServizio_SelectedIndexChanged);
			this.BtnSalva.Click += new System.EventHandler(this.BtnSalva_Click);
			this.BtnElimina.Click += new System.EventHandler(this.BtnElimina_Click);
			this.BtnAnnulla.Click += new System.EventHandler(this.BtnAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Carica Combo
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
				s_BlId.Value = RicercaModulo1.TxtCodice.Text;
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


		private void BindPiano(string CodEdificio)
		{	
			
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
			
			this.cmbsStanza.Enabled=true;
			
		}
		private void BindStanza()
		{
		  
			this.cmbsStanza.Items.Clear();
		
			TheSite.Classi.ManOrdinaria.Richiesta  _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
			int bl_id=(RicercaModulo1.Idbl=="")?0:int.Parse(RicercaModulo1.Idbl);
			int Piano=(cmbsPiano.SelectedValue=="")?0:int.Parse(cmbsPiano.SelectedValue); 
			DataSet	_MyDs = _Richiesta.GetStanze(bl_id,Piano);

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsStanza.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare la Stanza -", "");
				this.cmbsStanza.DataTextField = "DESCRIZIONE";
				this.cmbsStanza.DataValueField = "ID";
				this.cmbsStanza.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Stanza -";
				this.cmbsStanza.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
			
			cmbsStanza.Attributes.Add("OnChange","ClearApparechiature();");
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


		#endregion

		#region Eventi SelectedIndexChanged

		private void cmbsServizio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindApparecchiatura();
		}

		private void cmbsPiano_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindStanza();
		}
		#endregion

		#region Salva Lettura
		private void BtnSalva_Click(object sender, System.EventArgs e)
		{
			
			if(itemId.Text=="")
			{
				itemId.Text="0";
				Salva("I");
			}
			else
				Salva("U");
		}


		private void Salva(string operazione)
		{
						
			int i_RowsAffected = 0;

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			//Id Lettura
			S_Controls.Collections.S_Object s_p_id_letture_contatori = new S_Object();
			s_p_id_letture_contatori.ParameterName = "p_id_letture_contatori";
			s_p_id_letture_contatori.DbType = CustomDBType.Integer;
			s_p_id_letture_contatori.Direction = ParameterDirection.Input;
			s_p_id_letture_contatori.Index = 0 ;
			s_p_id_letture_contatori.Value = Convert.ToInt32(itemId.Text);
			_SCollection.Add(s_p_id_letture_contatori);

			//p_id_eq
			S_Controls.Collections.S_Object s_p_id_eq = new S_Object();
			s_p_id_eq.ParameterName = "p_id_eq";
			s_p_id_eq.DbType = CustomDBType.Integer;
			s_p_id_eq.Direction = ParameterDirection.Input;
			s_p_id_eq.Index = 1 ;
			s_p_id_eq.Value = CodiceApparecchiature1.IdApparecchiatura;
			_SCollection.Add(s_p_id_eq);

			//p_id_addetto
			S_Controls.Collections.S_Object s_p_id_addetto = new S_Object();
			s_p_id_addetto.ParameterName = "p_id_addetto";
			s_p_id_addetto.DbType = CustomDBType.Integer;
			s_p_id_addetto.Direction = ParameterDirection.Input;
			s_p_id_addetto.Index = 2 ;
			s_p_id_addetto.Value =Convert.ToInt32(Addetti1.IdAddetto);
			_SCollection.Add(s_p_id_addetto);

			//Valore Lettura
			S_Controls.Collections.S_Object s_p_valorelettura = new S_Object();
			s_p_valorelettura.ParameterName = "p_valorelettura";
			s_p_valorelettura.DbType = CustomDBType.VarChar;
			s_p_valorelettura.Direction = ParameterDirection.Input;
			s_p_valorelettura.Index = 3 ;
			s_p_valorelettura.Value =TxtValoreLetturaInt.Text.Trim() + "," + TxtValoreLetturaDec.Text.Trim();
			_SCollection.Add(s_p_valorelettura);		

			//nota
			S_Controls.Collections.S_Object s_p_nota = new S_Object();
			s_p_nota.ParameterName = "p_nota";
			s_p_nota.DbType = CustomDBType.VarChar;
			s_p_nota.Direction = ParameterDirection.Input;
			s_p_nota.Size=255;
			s_p_nota.Index = 4 ;
			s_p_nota.Value =TxtNota.Text;
			_SCollection.Add(s_p_nota);

			//energia
			S_Controls.Collections.S_Object s_p_energia = new S_Object();
			s_p_energia.ParameterName = "p_energia";
			s_p_energia.DbType = CustomDBType.VarChar;
			s_p_energia.Direction = ParameterDirection.Input;
			s_p_energia.Index = 5;
			s_p_nota.Size=255;
			s_p_energia.Value =CmbsEnergia.SelectedValue;
			_SCollection.Add(s_p_energia);

			
			//Data Ora Lettura
			S_Controls.Collections.S_Object s_p_datalettura = new S_Object();
			s_p_datalettura.ParameterName = "p_datalettura";
			s_p_datalettura.DbType = CustomDBType.VarChar;
			s_p_datalettura.Direction = ParameterDirection.Input;
			s_p_datalettura.Index = 6 ;
			s_p_nota.Size=15;
			s_p_datalettura.Value =CalendarPicker1.Datazione.Text+" "+ txtsorain.Text+ ":" + txtsorainmin.Text+ ":00" ;
			_SCollection.Add(s_p_datalettura);				
		
			try
			{
				if (operazione == "I")
				{			
					Classi.ClassiAnagrafiche.LetturaContatori _Lettura = new TheSite.Classi.ClassiAnagrafiche.LetturaContatori();
					i_RowsAffected = _Lettura.Add(_SCollection);
				}
				else if(operazione == "U")
				{
					Classi.ClassiAnagrafiche.LetturaContatori _Lettura = new TheSite.Classi.ClassiAnagrafiche.LetturaContatori();
					i_RowsAffected =  _Lettura.Update(_SCollection,Convert.ToInt32(itemId.Text));
				}

				else
				{
					Classi.ClassiAnagrafiche.LetturaContatori _Lettura = new TheSite.Classi.ClassiAnagrafiche.LetturaContatori();
					i_RowsAffected =  _Lettura.Delete(_SCollection,Convert.ToInt32(itemId.Text));			
		
				}
								
				
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				return;
				//	PanelMess.ShowError(s_Err, true);
			}	
			
			Server.Transfer("LetturaContatori.aspx?FunId =" + FunId);
		}

		#endregion

		

		private void BtnAnnulla_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("LetturaContatori.aspx");
		}

		private void BtnElimina_Click(object sender, System.EventArgs e)
		{
			Salva("D");
		}

		public clMyCollection _Contenitore
		{ 
			get 
			{
				if(this.ViewState["mioContenitore"]!=null)
					return (clMyCollection)this.ViewState["mioContenitore"];
				else
					return new clMyCollection();
			}
		}
	}
}
