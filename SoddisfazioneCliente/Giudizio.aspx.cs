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
using MyCollection;
using ApplicationDataLayer.DBType;


namespace TheSite.SoddisfazioneCliente
{
	/// <summary>
	/// Descrizione di riepilogo per Giudizio.
	/// </summary>
	public class Giudizio : System.Web.UI.Page
		{
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.CodiceApparecchiature CodiceApparecchiature1;
		protected WebControls.UserStanze UserStanze1;
		protected WebControls.PageTitle PageTitle1; 
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvOraRichiesta;
		protected Csy.WebControls.DataPanel PanelRicerca;
		public static int FunId = 0;
		public int  controllo = 0;
		TheSite.SoddisfazioneCliente.EditGiudizio _fp;

		protected WebControls.RicercaModulo RicercaModulo1;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;				
		public static string HelpLink = string.Empty;
		protected System.Web.UI.WebControls.TextBox txtBL_ID;
		protected System.Web.UI.WebControls.Button btsCodice;
		protected S_Controls.S_TextBox txtsstanza;
		protected S_Controls.S_ComboBox cmbsPiano;
		protected System.Web.UI.WebControls.Panel PanelServizio;
		protected S_Controls.S_Button btnsRicerca;
		protected S_Controls.S_Button btnReset;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_ComboBox cmbsGiudizio;
		protected System.Web.UI.WebControls.Panel PanelRichiedente;
		MyCollection.clMyCollection _myColl = new clMyCollection();
			private void Page_Load(object sender, System.EventArgs e)
			{
				// ***********************  MODIFICA PER I PERMESSI SULLA PAGINA CORRENTE **********************
				//Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];			
				string _mypage="./SoddisfazioneCliente/Giudizio.aspx";			
				Classi.SiteModule _SiteModule = new TheSite.Classi.SiteModule(_mypage);
				// ***********************  MODIFICA PER I PERMESSI SULLA PAGINA CORRENTE **********************
				this.GridTitle1.hplsNuovo.NavigateUrl = "../SoddisfazioneCliente/EditGiudizio.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
				this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;
				this.DataGridRicerca.Columns[1].Visible = true;
				this.DataGridRicerca.Columns[2].Visible = _SiteModule.IsEditable;	

				FunId = _SiteModule.ModuleId;
				HelpLink = _SiteModule.HelpLink;
				this.PageTitle1.Title = _SiteModule.ModuleTitle;
			
				UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
				UserStanze1.NameComboPiano="cmbsPiano";

				this.RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);
				this.RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindPiano);
				/// Imposto il nome della combo Servizio
				this.CodiceApparecchiature1.NameComboServizio ="cmbsServizio";
				/// Imposto il nome dell'user control RicercaModulo
				this.CodiceApparecchiature1.NameUserControlRicercaModulo  ="RicercaModulo1";
				/// Imposto il nome della cobmbo del piano
				this.CodiceApparecchiature1.NameComboPiano  ="cmbsPiano";
				/// Imposto il nome della combo della stanza
				this.CodiceApparecchiature1.NameComboStanza  ="cmbsStanza";

				System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
//				this.cmbsServizio.Attributes.Add("onchange", sbValid.ToString());
//				this.cmbsPiano.Attributes.Add("onchange", sbValid.ToString());

				sbValid = new System.Text.StringBuilder();
				
				sbValid.Append("if (typeof(seledificio) == 'function') { ");
				sbValid.Append("if (seledificio() == false) { return false; }} ");
				sbValid.Append("document.getElementById('" + this.cmbsServizio.ClientID + "').disabled = true;");
				sbValid.Append("document.getElementById('" + this.cmbsPiano.ClientID + "').disabled = true;");
				
									
				if (!Page.IsPostBack)
				{	
				
					if(Request.QueryString["FunId"]!=null)
						ViewState["FunId"]=Request.QueryString["FunId"];

					if(Context.Handler is TheSite.SoddisfazioneCliente.EditGiudizio) 
					{	
						_fp = (TheSite.SoddisfazioneCliente.EditGiudizio) Context.Handler;
						if (_fp!=null)
						{
							_myColl=_fp._Contenitore;
							_myColl.SetValues(this.Page.Controls);
							Ricerca();
						}
					}


				
					this.BindPiano("");
					//this.BindStanza();
					this.BindServizio(string.Empty);	
					this.BindGiudizio();				
					this.CodiceApparecchiature1.Visible = false;		
					this.CodiceApparecchiature1.s_CodiceApparecchiatura.ReadOnly =  true;
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
			this.btnsRicerca.Click += new System.EventHandler(this.btnsRicerca_Click);
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
			#endregion


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
				cmbsPiano.Attributes.Add("OnChange","");
			}
//			private void BindStanza()
//			{
//		  	
//				this.cmbsStanza.Items.Clear();
//		
//				TheSite.Classi.ManOrdinaria.Richiesta  _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
//				
//				int bl_id=(RicercaModulo1.Idbl=="")?0:int.Parse(RicercaModulo1.Idbl);
//				int Piano=(cmbsPiano.SelectedValue=="")?0:int.Parse(cmbsPiano.SelectedValue); 
//				DataSet	_MyDs = _Richiesta.GetStanze(bl_id,Piano);
//
//				if (_MyDs.Tables[0].Rows.Count > 0)
//				{
//					this.cmbsStanza.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
//						_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare la Stanza -", "");
//					this.cmbsStanza.DataTextField = "DESCRIZIONE";
//					this.cmbsStanza.DataValueField = "ID";
//					this.cmbsStanza.DataBind();
//				}
//				else
//				{
//					string s_Messagggio = "- Nessua Stanza -";
//					this.cmbsStanza.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
//				}
//				cmbsStanza.Attributes.Add("OnChange","");
//			}



		private void Ricerca()
		{
	
			DataSet _MyDs=GetData();
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();		
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();
			
		}

/// <summary>
/// //////////////
	private DataSet GetData()
	{
		Classi.GiudizioCliente.Giudizio _Giudizio = new Classi.GiudizioCliente.Giudizio();
		S_ControlsCollection _SCollection = new S_ControlsCollection();
		S_Controls.Collections.S_Object s_p_Bl_cod = new S_Controls.Collections.S_Object();
		s_p_Bl_cod.ParameterName = "p_Bl_id";
		s_p_Bl_cod.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
		s_p_Bl_cod.Direction = ParameterDirection.Input;
		s_p_Bl_cod.Index = 0;
		s_p_Bl_cod.Value = (RicercaModulo1.Idbl=="")?0:int.Parse(RicercaModulo1.Idbl);
		_SCollection.Add(s_p_Bl_cod);

	
		S_Controls.Collections.S_Object s_p_id_piani = new S_Controls.Collections.S_Object();
		s_p_id_piani.ParameterName = "p_id_piani";
		s_p_id_piani.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
		s_p_id_piani.Direction = ParameterDirection.Input;
		s_p_id_piani.Index = 2;
		s_p_id_piani.Value = (this.cmbsPiano.SelectedValue.ToString()=="")?0:Int32.Parse(this.cmbsPiano.SelectedValue.ToString());		
		_SCollection.Add(s_p_id_piani);
		

		S_Controls.Collections.S_Object s_p_id_stanza = new S_Controls.Collections.S_Object();
		s_p_id_stanza.ParameterName = "p_id_stanza";
		s_p_id_stanza.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
		s_p_id_stanza.Direction = ParameterDirection.Input;
		s_p_id_stanza.Index = 3;
		s_p_id_stanza.Size=25;
		if(UserStanze1.DescStanza =="")
			UserStanze1.IdStanza="";
		s_p_id_stanza.Value =UserStanze1.IdStanza; //  (this.cmbsStanza.SelectedValue.ToString()=="")?0:Int32.Parse(this.cmbsStanza.SelectedValue.ToString());					
		_SCollection.Add(s_p_id_stanza);

		S_Controls.Collections.S_Object s_p_id_servizio = new S_Controls.Collections.S_Object();
		s_p_id_servizio.ParameterName = "p_id_servizio";
		s_p_id_servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
		s_p_id_servizio.Direction = ParameterDirection.Input;
		s_p_id_servizio.Index =4;
		s_p_id_servizio.Value =  (this.cmbsServizio.SelectedValue.ToString()=="")?0:Int32.Parse(this.cmbsServizio.SelectedValue.ToString());					
		_SCollection.Add(s_p_id_servizio);

		S_Controls.Collections.S_Object s_p_id_soddisfazione = new S_Controls.Collections.S_Object();
		s_p_id_soddisfazione.ParameterName = "p_id_soddisfazione";
		s_p_id_soddisfazione.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
		s_p_id_soddisfazione.Direction = ParameterDirection.Input;
		s_p_id_soddisfazione.Index = 5;
		s_p_id_soddisfazione.Value =  (this.cmbsGiudizio.SelectedValue.ToString()=="")?0:Int32.Parse(this.cmbsGiudizio.SelectedValue.ToString());					
		_SCollection.Add(s_p_id_soddisfazione);

		DataSet _MyDs = _Giudizio.GetData(_SCollection).Copy();
		return _MyDs;
	}
/// 
/// 
/// 
/// 
/// ////////////////
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>


		
		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			Ricerca();		
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




			private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
			{
				DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
				Ricerca();
			}

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Dettaglio")
			{	
				_myColl.AddControl(this.Page.Controls, ParentType.Page);
				string s_url = e.CommandArgument.ToString();							
				Server.Transfer(s_url);		
			}
		}



		public MyCollection.clMyCollection _Contenitore
		{
			get 
			{
				return _myColl;
			}
		}




//		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
//		{
//			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
//			
//		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{					
				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("imgVisualizza");
				_img1.Attributes.Add("title","Visualizza");

				ImageButton _img2 = (ImageButton) e.Item.Cells[1].FindControl("imgModifica");
				_img2.Attributes.Add("title","Modifica");

			}
		}


		

			private void btnReset_Click(object sender, System.EventArgs e)
			{
				Response.Redirect("Giudizio.aspx?FunId=" + FunId);
			}

			
		}
	}
