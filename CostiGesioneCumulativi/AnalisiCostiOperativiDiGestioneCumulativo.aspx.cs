using System;
using System.IO;
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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using TheSite.SchemiXSD;
using ICSharpCode.SharpZipLib.Zip;
using TheSite.ManutenzioneCorrettiva;
using TheSite.Classi.CostiGesioneCumulativi;

namespace TheSite.CostiGesioneCumulativi
{
	/// <summary>
	/// Descrizione di riepilogo per AnalisiCostiOperativiDiGestioneCumulativo.
	/// </summary>
	public class AnalisiCostiOperativiDiGestioneCumulativo : System.Web.UI.Page
	{
		protected S_Controls.S_TextBox txtsRichiesta;
		protected S_Controls.S_ComboBox cmbsUrgenza;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_TextBox txtsOrdine;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;	
		protected WebControls.GridTitle Gridtitle2;			
		protected WebControls.PageTitle PageTitle1;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;
		protected WebControls.CalendarPicker CalendarPicker3;
		protected WebControls.CalendarPicker CalendarPicker4;
		protected WebControls.Addetti Addetti1;
		protected WebControls.Richiedenti Richiedenti1;		
		protected S_Controls.S_TextBox txtDescrizione;
		protected S_Controls.S_Button cmdExcel;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected S_Controls.S_ComboBox cmbsGruppo;
		protected S_Controls.S_ComboBox cmbsTipoIntervento;
		protected S_Controls.S_ComboBox cmbsStatus;
		protected S_Controls.S_ComboBox cmbsTipoManutenzione;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca2;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTable tableComandi;
		
		#region variabili
		private int checkTipoMan = 0;
		public static string HelpLink = string.Empty;	

		//EditSfoglia  _fp=null;
		//AnalisiCostiOperativiDiGestioneDettaglio _fp2 = null;
		public static int FunId = 0;
		private int maxOdl = 400;
		protected S_Controls.S_Button S_btnConfermaSel;
		protected S_Controls.S_Button S_btnStampa;
		protected S_Controls.S_Button S_btnSelezionaTutto;
		protected System.Web.UI.WebControls.Label lblElementiSelezionati;
		protected System.Web.UI.WebControls.Label lblMessaggio;
		protected S_Controls.S_Button S_btnDownLoad;
		protected S_Controls.S_Button S_btnDeselezioneTutto;
		protected S_Controls.S_Button S_btnReset;
		protected System.Web.UI.HtmlControls.HtmlTable TableLabel;	
		clMyCollection _myColl = new clMyCollection();
		#endregion
		protected System.Web.UI.HtmlControls.HtmlTable Table1;
		protected string comboTipoManutenzioneCliendiId; 

		TheSite.CostiGesioneCumulativi.Pagina_Download_Cumulativi  _fp=null;

		public clMyCollection _Contenitore
		{
			get {return _myColl;}
		}

	

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			txtsRichiesta.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtsRichiesta.Attributes.Add("onpaste","return nonpaste();");
			txtsOrdine.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtsOrdine.Attributes.Add("onpaste","return nonpaste();");

			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			//this.PageTitle1.Title = _SiteModule.ModuleTitle;
			this.PageTitle1.Title = "Rapporto Interventi Cumulativo".ToUpper();
						
			RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);

			if(!Page.IsPostBack)
			{
				Session["CheckedList"]=null;
				Session["DatiList"]=null;

				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];
			
				CompareValidator1.ControlToValidate = CalendarPicker2.ID + ":" + CalendarPicker2.Datazione.ID;
				CompareValidator1.ControlToCompare =  CalendarPicker1.ID + ":" + CalendarPicker1.Datazione.ID;
				DataGridRicerca.Visible = false;				
				GridTitle1.hplsNuovo.Visible = false;
				GridTitle1.Visible =false;
				BindServizio("");
				BindGruppo();
				BindUrgenza();
				BindStatus();	
				BindTipoInterventoAter();
				BinTipoManutenzione();
				
				// Imposto visibile il DataGrid di Manutenzione su Richiesta
				if (Convert.ToString(Session["tipoRicerca"])=="3") 																		 
				{
					DataGridRicerca.Visible=true;
					GridTitle1.Visible=true;
					DataGridRicerca2.Visible=false;
					Gridtitle2.Visible=false;
					if (DataGridRicerca.Items.Count==0) tableComandi.Visible=false;
					else tableComandi.Visible=true;
				}
				else
				{
					DataGridRicerca.Visible=false;
					GridTitle1.Visible=false;
					DataGridRicerca2.Visible=true;
					Gridtitle2.Visible=true;
					if (DataGridRicerca2.Items.Count==0) tableComandi.Visible=false;
					else tableComandi.Visible=true;
				}
				
				

				//Valorizzo i Parametri Immessi
				if(Context.Handler is CostiGesioneCumulativi.Pagina_Download_Cumulativi)
				{
					_fp = (TheSite.CostiGesioneCumulativi.Pagina_Download_Cumulativi)Context.Handler;
					if (_fp!=null) 
					{
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);		
						Execute();
					}
				}

				
			
			}
			GridTitle1.hplsNuovo.Visible = false;
			Gridtitle2.hplsNuovo.Visible = false;
			comboTipoManutenzioneCliendiId=cmbsTipoManutenzione.SelectedValue;
		}

		private bool Execute()
		{
			DataGridRicerca.AllowCustomPaging=false;
			DataGridRicerca2.AllowCustomPaging=false;
			
	
				
			bool chech=true;
			if (Convert.ToString(Session["tipoRicerca"])=="3")
			{
				// Manutenzione Straordinaria
				//				GetControlli();
				//				Ricerca();		
			
			
				DataSet Ds=RicercaSelTutti();
				//Ds = GetData();
				GridTitle1.Visible = true;


				if (Ds.Tables[0].Rows.Count > 0 && Ds.Tables[0].Rows.Count< maxOdl +1) 
				{
					setvisiblecontrol(true);
					GridTitle1.DescriptionTitle="";
					//				GridTitle1.NumeroRecords =Ds.Tables[0].Rows.Count.ToString();
					//				MyDataGrid1.DataSource= Ds;
					DataGridRicerca.DataBind();
					chech = true;
				}
				else if(Ds.Tables[0].Rows.Count > maxOdl)
				{
					//				GridTitle1.DescriptionTitle="Nessun dato trovato.";
					//				MyDataGrid1.DataSource= Ds;
					DataGridRicerca.DataBind();
					setvisiblecontrol(true);
					chech = false;
				}
				else
				{
					DataGridRicerca.DataBind();
					setvisiblecontrol(false);
					chech = false;
				}
					
				DataGridRicerca.DataSource= Ds;
				DataGridRicerca.DataBind();
				GridTitle1.NumeroRecords = Ds.Tables[0].Rows.Count.ToString();
				DataGridRicerca.AllowCustomPaging=true;
				DataGridRicerca2.AllowCustomPaging=true;
				return chech;
			}
			else			
			{	// Manutenzione Richiesta	
				//					GetControlli();
				//				Ricerca();		
			
			
				DataSet Ds;
				Ds = RicercaManRichiestaSelTutti();
				Gridtitle2.Visible = true;
				if (Ds.Tables[0].Rows.Count > 0 && Ds.Tables[0].Rows.Count< maxOdl +1) 
				{
					setvisiblecontrol2(true);
					Gridtitle2.DescriptionTitle="";
					//				GridTitle1.NumeroRecords =Ds.Tables[0].Rows.Count.ToString();
					//				MyDataGrid1.DataSource= Ds;
					DataGridRicerca2.DataBind();
					chech = true;
				}
				else if(Ds.Tables[0].Rows.Count > maxOdl)
				{
					//				GridTitle1.DescriptionTitle="Nessun dato trovato.";
					//				MyDataGrid1.DataSource= Ds;
					DataGridRicerca2.DataBind();
					setvisiblecontrol2(true);
					chech = false;
				}
				else
				{
					DataGridRicerca2.DataBind();
					setvisiblecontrol2(false);
					chech = false;
				}
					
				DataGridRicerca2.DataSource= Ds;
				DataGridRicerca2.DataBind();
				Gridtitle2.NumeroRecords = Ds.Tables[0].Rows.Count.ToString();
				DataGridRicerca.AllowCustomPaging=true;
				DataGridRicerca2.AllowCustomPaging=true;
				return chech;
			}

			
		}

		private void setvisiblecontrol(bool Visibile)
		{
			DataGridRicerca.Visible=true;
			tableComandi.Visible=true;
		}

		private void setvisiblecontrol2(bool Visibile)
		{
			DataGridRicerca2.Visible=true;
			tableComandi.Visible=true;
		}

		private void BinTipoManutenzione()
		{
		
			
			Classi.ManCorrettiva.ClManCorrettiva _ClManCorrettiva = new TheSite.Classi.ManCorrettiva.ClManCorrettiva();
			DataSet _MyDs =  _ClManCorrettiva.GetTipoManutenzione();

			if (_MyDs.Tables[0].Rows.Count>0)
			{
				cmbsTipoManutenzione.DataSource = _MyDs;
				this.cmbsTipoManutenzione.DataTextField = "descrizione";
				this.cmbsTipoManutenzione.DataValueField = "id";
				this.cmbsTipoManutenzione.DataBind();				
				this.cmbsTipoManutenzione.Attributes.Add("OnChange","Visualizza(this.value);"); 				
			}	
		}

		private void BindServizio(string CodEdificio)
		{
			GridTitle1.DescriptionTitle="";
			Addetti1.Set_BL_ID(CodEdificio);

			DataGridRicerca.Visible = false;
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
					_MyDs.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "0");
				this.cmbsServizio.DataTextField = "DESCRIZIONE";
				this.cmbsServizio.DataValueField = "IDSERVIZIO";
				this.cmbsServizio.DataBind();
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio("Non Definito", "-1"));
			}
			else
			{
				string s_Messaggio = "Non Definito";
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messaggio, "-1"));
			}
		
		}

		private void BindGruppo()
		{
			this.cmbsGruppo.Items.Clear();
		
			Classi.ManStraordinaria.GestioneRdl _GestioneRdl= new Classi.ManStraordinaria.GestioneRdl(Context.User.Identity.Name);
			
			
			DataSet Ds = _GestioneRdl.GetGuppo();
		
			if (Ds.Tables[0].Rows.Count > 0)
			{
				this.cmbsGruppo.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					Ds.Tables[0], "descrizione", "richiedenti_tipo_id", "- Selezionare un Gruppo -", "");
				this.cmbsGruppo.DataTextField = "descrizione";
				this.cmbsGruppo.DataValueField = "richiedenti_tipo_id";
				this.cmbsGruppo.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Gruppo -";
				this.cmbsGruppo.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		private void BindUrgenza()
		{
			this.cmbsUrgenza.Items.Clear();
		
			Classi.ManStraordinaria.GestioneRdl _GestioneRdl= new Classi.ManStraordinaria.GestioneRdl(Context.User.Identity.Name);
			
			
			DataSet Ds = _GestioneRdl.GetUrgenza();
		
			if (Ds.Tables[0].Rows.Count > 0)
			{
				this.cmbsUrgenza.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					Ds.Tables[0], "descrizione", "id_priority", "- Selezionare una Urgenza -", "");
				this.cmbsUrgenza.DataTextField = "descrizione";
				this.cmbsUrgenza.DataValueField = "id_priority";
				this.cmbsUrgenza.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Urgenza -";
				this.cmbsUrgenza.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		private void BindStatus()
		{
			this.cmbsStatus.Items.Clear();
		
			Classi.ManStraordinaria.Richiesta  _Richiesta= new Classi.ManStraordinaria.Richiesta();
						
			DataSet Ds = _Richiesta.GetStatus();
		
			if (Ds.Tables[0].Rows.Count > 0)
			{
				this.cmbsStatus.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					Ds.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Stato -", "");
				this.cmbsStatus.DataTextField = "DESCRIZIONE";
				this.cmbsStatus.DataValueField = "ID";
				this.cmbsStatus.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Stato -";
				this.cmbsStatus.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}		
		}
		private void BindTipoInterventoAter()
		{
			//Caricol il combo Del Tipo Intervento
			cmbsTipoIntervento.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ClassiAnagrafiche.TipoIntervento  _TipoIntervento = new TheSite.Classi.ClassiAnagrafiche.TipoIntervento();

			DataSet _MyDs;
			_MyDs = _TipoIntervento.GetData();
			

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsTipoIntervento.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione_breve", "ID", "- Selezionare il Tipo Intervento -", "");
				this.cmbsTipoIntervento.DataTextField = "descrizione_breve";
				this.cmbsTipoIntervento.DataValueField = "id";
				this.cmbsTipoIntervento.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Tipo Intervento -";
				this.cmbsTipoIntervento.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
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
			this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.DataGridRicerca2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca2_ItemCommand);
			this.DataGridRicerca2.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca2_PageIndexChanged);
			this.DataGridRicerca2.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca2_ItemDataBound);
			this.S_btnConfermaSel.Click += new System.EventHandler(this.S_btnConfermaSel_Click);
			this.S_btnStampa.Click += new System.EventHandler(this.S_btnStampa_Click);
			this.S_btnSelezionaTutto.Click += new System.EventHandler(this.S_btnSelezionaTutto_Click);
			this.S_btnDeselezioneTutto.Click += new System.EventHandler(this.S_btnDeselezioneTutto_Click);
			this.S_btnReset.Click += new System.EventHandler(this.S_btnReset_Click);
			this.S_btnDownLoad.Click += new System.EventHandler(this.S_btnDownLoad_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			
			Session["tipoRicerca"]=cmbsTipoManutenzione.SelectedValue;
			if (cmbsTipoManutenzione.SelectedValue=="3")
			{
				// Manutenzione Straordinaria
				GetControlli();
				Ricerca(true);		
			}
			else			
			{	// Manutenzione Richiesta	
				GetControlli2();
				RicercaManRichiesta(true);
			}

		}

		private void Ricerca(bool reset)
		{
			
			// Manutenzione Straordinaria
			DataGridRicerca.Visible=true;
			GridTitle1.Visible=true;
			DataGridRicerca2.Visible=false;
			Gridtitle2.Visible=false;
						
			S_ControlsCollection _SCollection=GetData();

			S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
			s_p_pageindex.ParameterName = "pageindex";
			s_p_pageindex.DbType = CustomDBType.Integer;
			s_p_pageindex.Direction = ParameterDirection.Input;
			s_p_pageindex.Index = _SCollection.Count +1;
			s_p_pageindex.Value=DataGridRicerca.CurrentPageIndex +1;			
			_SCollection.Add(s_p_pageindex);

			S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
			s_p_pagesize.ParameterName = "pagesize";
			s_p_pagesize.DbType = CustomDBType.Integer;
			s_p_pagesize.Direction = ParameterDirection.Input;
			s_p_pagesize.Index = _SCollection.Count +1;
			s_p_pagesize.Value= DataGridRicerca.PageSize;			
			_SCollection.Add(s_p_pagesize);
            TheSite.Classi.CostiGesioneCumulativi.Richiesta _Richiesta=new Richiesta();
			DataSet _MyDs = _Richiesta.GetSfogliaRDLperStaordinaraPaging(_SCollection).Copy();	
	

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];

			DataGridRicerca.Visible = true;
			GridTitle1.Visible =true;
			GridTitle1.hplsNuovo.Visible=false;


			if (reset==true)
			{
				_SCollection=GetData();
				DataSet ds =_Richiesta.GetSfogliaRDLperStaordinaraCount(_SCollection).Copy();
				int _totalRecords = int.Parse(ds.Tables[0].Rows[0][0].ToString());
				this.GridTitle1.NumeroRecords=_totalRecords.ToString();
			}

			if (int.Parse(GridTitle1.NumeroRecords) == 0 )
			{
				DataGridRicerca.CurrentPageIndex=0;
				GridTitle1.DescriptionTitle="Nessun dato trovato."; 
			}
			else
			{
				if (int.Parse(GridTitle1.NumeroRecords) > maxOdl )
				{
					tableComandi.Visible=false;
					lblMessaggio.ForeColor=Color.Red;
					lblMessaggio.Font.Size=20;
					lblMessaggio.Text="La ricerca ha fornito più di " + Convert.ToString(maxOdl) + " risultati. Occorre restringere i criteri di ricerca selezionando un intervallo di date più corto o ad esempio in addetto";
				} 
				else 
				{
					lblMessaggio.Text="";
					lblMessaggio.Font.Size=10;
					lblMessaggio.ForeColor=Color.Black;

					tableComandi.Visible=true;
					CalcolaTotali(_MyDs.Tables[0]);

					GridTitle1.DescriptionTitle=""; 
				}
			}
			
			this.DataGridRicerca.VirtualItemCount =int.Parse(this.GridTitle1.NumeroRecords);
			this.DataGridRicerca.DataBind();	
		}



		private DataSet RicercaSelTutti()
		{
			
			// Manutenzione Straordinaria
			DataGridRicerca.Visible=true;
			GridTitle1.Visible=true;
			DataGridRicerca2.Visible=false;
			Gridtitle2.Visible=false;
			S_ControlsCollection _SCollection=GetData();
             TheSite.Classi.CostiGesioneCumulativi.Richiesta _Richiesta=new Richiesta();
			DataSet _MyDs = _Richiesta.GetSfogliaRDLperStaordinara(_SCollection).Copy();	

			return _MyDs;

			
		}

		/// <summary>
		/// 
		/// </summary>
		private void CalcolaTotali(DataTable dt)
		{
			foreach(DataRow dr in dt.Rows)
			{
				if (dr["importostimato"]!=DBNull.Value)
					totpreventivo+=double.Parse(dr["importostimato"].ToString());
				if (dr["importoconsuntivo"]!=DBNull.Value)
					totconsuntivo+=double.Parse(dr["importoconsuntivo"].ToString());
			}
		}
/// <summary>
/// 
/// </summary>
/// <param name="count"> indica se True che deve fare il count dei record altrimenti recupera i record secondo la paginazione corrente</param>
/// <returns></returns>
		private S_ControlsCollection GetData()
		{
			Richiesta  _Richiesta = new Richiesta();						
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_Bl_Id = new S_Controls.Collections.S_Object();
			s_p_Bl_Id.ParameterName = "p_Bl_Id";
			s_p_Bl_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Bl_Id.Direction = ParameterDirection.Input;
			s_p_Bl_Id.Size =50;
			s_p_Bl_Id.Index = 0;
			s_p_Bl_Id.Value = RicercaModulo1.TxtCodice.Text;
			_SCollection.Add(s_p_Bl_Id);

			S_Controls.Collections.S_Object s_p_campus = new S_Controls.Collections.S_Object();
			s_p_campus.ParameterName = "p_campus";
			s_p_campus.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_campus.Direction = ParameterDirection.Input;
			s_p_campus.Index = 1;
			s_p_campus.Size=50;
			s_p_campus.Value = RicercaModulo1.TxtRicerca.Text;			
			_SCollection.Add(s_p_campus);

			S_Controls.Collections.S_Object s_p_Wr_Id = new S_Controls.Collections.S_Object();
			s_p_Wr_Id.ParameterName = "p_Wr_Id";
			s_p_Wr_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wr_Id.Direction = ParameterDirection.Input;
			s_p_Wr_Id.Index = 2;
			s_p_Wr_Id.Size=50;
			s_p_Wr_Id.Value = (this.txtsRichiesta.Text=="")?0:Int32.Parse(this.txtsRichiesta.Text);		
			_SCollection.Add(s_p_Wr_Id);

			S_Controls.Collections.S_Object s_p_Addetto = new S_Controls.Collections.S_Object();
			s_p_Addetto.ParameterName = "p_Addetto";
			s_p_Addetto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Addetto.Direction = ParameterDirection.Input;
			s_p_Addetto.Index = 3;
			s_p_Addetto.Size=50;
			s_p_Addetto.Value = this.Addetti1.NomeCompleto;			
			_SCollection.Add(s_p_Addetto);

			S_Controls.Collections.S_Object s_p_DataDa = new S_Controls.Collections.S_Object();
			s_p_DataDa.ParameterName = "p_DataDa";
			s_p_DataDa.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataDa.Direction = ParameterDirection.Input;
			s_p_DataDa.Index = 4;
			s_p_DataDa.Size= 10;
			s_p_DataDa.Value = (CalendarPicker1.Datazione.Text =="")? "":CalendarPicker1.Datazione.Text;  			
			_SCollection.Add(s_p_DataDa);

			S_Controls.Collections.S_Object s_p_DataA = new S_Controls.Collections.S_Object();
			s_p_DataA.ParameterName = "p_DataA";
			s_p_DataA.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataA.Direction = ParameterDirection.Input;
			s_p_DataA.Index = 5;
			s_p_DataA.Size= 10;
			s_p_DataA.Value = (CalendarPicker2.Datazione.Text =="")? "":CalendarPicker2.Datazione.Text;  			
			_SCollection.Add(s_p_DataA);

			S_Controls.Collections.S_Object s_p_Wo_Id = new S_Controls.Collections.S_Object();
			s_p_Wo_Id.ParameterName = "p_Wo_Id";
			s_p_Wo_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wo_Id.Direction = ParameterDirection.Input;
			s_p_Wo_Id.Index = 6;
			s_p_Wo_Id.Size=50;
			s_p_Wo_Id.Value = (this.txtsOrdine.Text=="")?0:Int32.Parse(this.txtsOrdine.Text);		
			_SCollection.Add(s_p_Wo_Id);
			
			S_Controls.Collections.S_Object s_p_Servizio = new S_Controls.Collections.S_Object();
			s_p_Servizio.ParameterName = "p_ID_Servizio";
			s_p_Servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Servizio.Direction = ParameterDirection.Input;
			s_p_Servizio.Index = 7;
			s_p_Servizio.Value = (cmbsServizio.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsServizio.SelectedValue);			
			_SCollection.Add(s_p_Servizio);

			S_Controls.Collections.S_Object s_p_Status = new S_Controls.Collections.S_Object();
			s_p_Status.ParameterName = "p_Status";
			s_p_Status.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Status.Direction = ParameterDirection.Input;
			s_p_Status.Index = 8;
			s_p_Status.Value = (cmbsStatus.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsStatus.SelectedValue);			
			_SCollection.Add(s_p_Status);

			S_Controls.Collections.S_Object s_p_Richiedente = new S_Controls.Collections.S_Object();
			s_p_Richiedente.ParameterName = "p_Richiedente";
			s_p_Richiedente.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Richiedente.Direction = ParameterDirection.Input;
			s_p_Richiedente.Index = 9;
			s_p_Richiedente.Size=50;
			s_p_Richiedente.Value = this.Richiedenti1.NomeCompleto;			
			_SCollection.Add(s_p_Richiedente);

			S_Controls.Collections.S_Object s_p_Priority = new S_Controls.Collections.S_Object();
			s_p_Priority.ParameterName = "p_Priority";
			s_p_Priority.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Priority.Direction = ParameterDirection.Input;
			s_p_Priority.Index = 10;
			s_p_Priority.Value = (cmbsUrgenza.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsUrgenza.SelectedValue);			
			_SCollection.Add(s_p_Priority);

			S_Controls.Collections.S_Object s_p_Descrizione = new S_Controls.Collections.S_Object();
			s_p_Descrizione.ParameterName = "p_Descrizione";
			s_p_Descrizione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Descrizione.Direction = ParameterDirection.Input;
			s_p_Descrizione.Index = 11;
			s_p_Descrizione.Size= 255;
			s_p_Descrizione.Value = txtDescrizione.Text;			
			_SCollection.Add(s_p_Descrizione);

			S_Controls.Collections.S_Object s_p_Gruppo = new S_Controls.Collections.S_Object();
			s_p_Gruppo.ParameterName = "p_Gruppo";
			s_p_Gruppo.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Gruppo.Direction = ParameterDirection.Input;
			s_p_Gruppo.Index = 12;
			s_p_Gruppo.Value = (cmbsGruppo.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsGruppo.SelectedValue);			
			_SCollection.Add(s_p_Gruppo);
		
			S_Controls.Collections.S_Object p_tipointerventoater = new S_Controls.Collections.S_Object();
			p_tipointerventoater.ParameterName = "p_tipointerventoater";
			p_tipointerventoater.DbType = CustomDBType.Integer;
			p_tipointerventoater.Direction = ParameterDirection.Input;
			p_tipointerventoater.Index = 13;
			p_tipointerventoater.Value = (cmbsTipoIntervento.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsTipoIntervento.SelectedValue);			
			_SCollection.Add(p_tipointerventoater);

			S_Controls.Collections.S_Object p_datainizio = new S_Controls.Collections.S_Object();
			p_datainizio.ParameterName = "p_datainizio";
			p_datainizio.DbType = CustomDBType.VarChar;
			p_datainizio.Direction = ParameterDirection.Input;
			p_datainizio.Index = 14;
			p_datainizio.Size= 10;
			p_datainizio.Value = (CalendarPicker3.Datazione.Text =="")? "":CalendarPicker3.Datazione.Text;  			
			_SCollection.Add(p_datainizio);

			S_Controls.Collections.S_Object p_datafine = new S_Controls.Collections.S_Object();
			p_datafine.ParameterName = "p_datafine";
			p_datafine.DbType =CustomDBType.VarChar;
			p_datafine.Direction = ParameterDirection.Input;
			p_datafine.Index = 15;
			p_datafine.Size= 10;
			p_datafine.Value = (CalendarPicker4.Datazione.Text =="")? "":CalendarPicker4.Datazione.Text;  			
			_SCollection.Add(p_datafine);

			return _SCollection;
			
		}
		
		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			Ricerca(false);
			GetControlli();	
		}

		private void DataGridRicerca2_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca2.CurrentPageIndex = e.NewPageIndex;			
			RicercaManRichiesta(false);
			GetControlli2();	
		}

		private void GetControlli()
		{	
			clMyDataGridCollection _cl = new clMyDataGridCollection();
			if(Session["CheckedList"]!=null)
			{	
				_cl.GetControl(DataGridRicerca,(Hashtable) Session["CheckedList"],DataGridRicerca.CurrentPageIndex);
			}
		}

		private void GetControlli2()
		{	
			clMyDataGridCollection _cl = new clMyDataGridCollection();
			if(Session["CheckedList"]!=null)
			{	
				_cl.GetControl(DataGridRicerca2,(Hashtable) Session["CheckedList"],DataGridRicerca2.CurrentPageIndex);
			}
		}

		//		private void DataGridRicerca2_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		//		{
		//			DataGridRicerca2.CurrentPageIndex = e.NewPageIndex;			
		//			RicercaManRichiesta();
		//		
		//		}
		double totpreventivo=0;
		double totconsuntivo=0;
		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{


		}
	

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Dettaglio")
			{				
				_myColl.AddControl(this.Page.Controls,ParentType.Page );
				string s_url = e.CommandArgument.ToString();
						
				string IdStato = e.Item.Cells[14].Text.Trim();					
				switch (IdStato)
				{
					case "1":
					case "7":
					case "15":											
						_myColl.AddControl(this.Page.Controls, ParentType.Page);
						Server.Transfer(s_url);	
						break;
					default:
						s_url += "&c=true";
						_myColl.AddControl(this.Page.Controls, ParentType.Page);
						Server.Transfer(s_url);	
						break;
				}							
									
			}
			if (e.CommandName=="Modifica")
			{
				_myColl.AddControl(this.Page.Controls,ParentType.Page );
				string s_url = e.CommandArgument.ToString();
	
				Server.Transfer(s_url);
			
			}

		}

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AnalisiCostiOperativiDiGestioneCumulativo.aspx?FunID=" + ViewState["FunId"]);
		}

		#region ManRichiesta
		private S_ControlsCollection GetOrdinaria()
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_Bl_Id = new S_Controls.Collections.S_Object();
			s_p_Bl_Id.ParameterName = "p_Bl_Id";
			s_p_Bl_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Bl_Id.Direction = ParameterDirection.Input;
			s_p_Bl_Id.Size =50;
			s_p_Bl_Id.Index = 0;
			s_p_Bl_Id.Value = RicercaModulo1.TxtCodice.Text;
			_SCollection.Add(s_p_Bl_Id);

			S_Controls.Collections.S_Object s_p_campus = new S_Controls.Collections.S_Object();
			s_p_campus.ParameterName = "p_campus";
			s_p_campus.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_campus.Direction = ParameterDirection.Input;
			s_p_campus.Index = 1;
			s_p_campus.Size=50;
			s_p_campus.Value = RicercaModulo1.TxtRicerca.Text;			
			_SCollection.Add(s_p_campus);

			S_Controls.Collections.S_Object s_p_Wr_Id = new S_Controls.Collections.S_Object();
			s_p_Wr_Id.ParameterName = "p_Wr_Id";
			s_p_Wr_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wr_Id.Direction = ParameterDirection.Input;
			s_p_Wr_Id.Index = 2;
			s_p_Wr_Id.Size=50;
			s_p_Wr_Id.Value = (this.txtsRichiesta.Text=="")?0:Int32.Parse(this.txtsRichiesta.Text);		
			_SCollection.Add(s_p_Wr_Id);

			S_Controls.Collections.S_Object s_p_Addetto = new S_Controls.Collections.S_Object();
			s_p_Addetto.ParameterName = "p_Addetto";
			s_p_Addetto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Addetto.Direction = ParameterDirection.Input;
			s_p_Addetto.Index = 3;
			s_p_Addetto.Size=50;
			s_p_Addetto.Value = this.Addetti1.NomeCompleto;			
			_SCollection.Add(s_p_Addetto);

			S_Controls.Collections.S_Object s_p_DataDa = new S_Controls.Collections.S_Object();
			s_p_DataDa.ParameterName = "p_DataDa";
			s_p_DataDa.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataDa.Direction = ParameterDirection.Input;
			s_p_DataDa.Index = 4;
			s_p_DataDa.Size= 10;
			s_p_DataDa.Value = (CalendarPicker1.Datazione.Text =="")? "":CalendarPicker1.Datazione.Text;  			
			_SCollection.Add(s_p_DataDa);

			S_Controls.Collections.S_Object s_p_DataA = new S_Controls.Collections.S_Object();
			s_p_DataA.ParameterName = "p_DataA";
			s_p_DataA.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataA.Direction = ParameterDirection.Input;
			s_p_DataA.Index = 5;
			s_p_DataA.Size= 10;
			s_p_DataA.Value = (CalendarPicker2.Datazione.Text =="")? "":CalendarPicker2.Datazione.Text;  			
			_SCollection.Add(s_p_DataA);

			S_Controls.Collections.S_Object s_p_Wo_Id = new S_Controls.Collections.S_Object();
			s_p_Wo_Id.ParameterName = "p_Wo_Id";
			s_p_Wo_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wo_Id.Direction = ParameterDirection.Input;
			s_p_Wo_Id.Index = 6;
			s_p_Wo_Id.Size=50;
			s_p_Wo_Id.Value = (this.txtsOrdine.Text=="")?0:Int32.Parse(this.txtsOrdine.Text);		
			_SCollection.Add(s_p_Wo_Id);
			
			S_Controls.Collections.S_Object s_p_Servizio = new S_Controls.Collections.S_Object();
			s_p_Servizio.ParameterName = "p_ID_Servizio";
			s_p_Servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Servizio.Direction = ParameterDirection.Input;
			s_p_Servizio.Index = 7;
			s_p_Servizio.Value = (cmbsServizio.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsServizio.SelectedValue);			
			_SCollection.Add(s_p_Servizio);

			S_Controls.Collections.S_Object s_p_Status = new S_Controls.Collections.S_Object();
			s_p_Status.ParameterName = "p_Status";
			s_p_Status.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Status.Direction = ParameterDirection.Input;
			s_p_Status.Index = 8;
			s_p_Status.Value = (cmbsStatus.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsStatus.SelectedValue);			
			_SCollection.Add(s_p_Status);

			S_Controls.Collections.S_Object s_p_Richiedente = new S_Controls.Collections.S_Object();
			s_p_Richiedente.ParameterName = "p_Richiedente";
			s_p_Richiedente.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Richiedente.Direction = ParameterDirection.Input;
			s_p_Richiedente.Index = 9;
			s_p_Richiedente.Size=50;
			s_p_Richiedente.Value = this.Richiedenti1.NomeCompleto;			
			_SCollection.Add(s_p_Richiedente);

			S_Controls.Collections.S_Object s_p_Priority = new S_Controls.Collections.S_Object();
			s_p_Priority.ParameterName = "p_Priority";
			s_p_Priority.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Priority.Direction = ParameterDirection.Input;
			s_p_Priority.Index = 10;
			s_p_Priority.Value = (cmbsUrgenza.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsUrgenza.SelectedValue);			
			_SCollection.Add(s_p_Priority);

			S_Controls.Collections.S_Object s_p_Descrizione = new S_Controls.Collections.S_Object();
			s_p_Descrizione.ParameterName = "p_Descrizione";
			s_p_Descrizione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Descrizione.Direction = ParameterDirection.Input;
			s_p_Descrizione.Index = 11;
			s_p_Descrizione.Size= 255;
			s_p_Descrizione.Value = txtDescrizione.Text;			
			_SCollection.Add(s_p_Descrizione);

			S_Controls.Collections.S_Object s_p_Gruppo = new S_Controls.Collections.S_Object();
			s_p_Gruppo.ParameterName = "p_Gruppo";
			s_p_Gruppo.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Gruppo.Direction = ParameterDirection.Input;
			s_p_Gruppo.Index = 12;
			s_p_Gruppo.Value = (cmbsGruppo.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsGruppo.SelectedValue);			
			_SCollection.Add(s_p_Gruppo);
		

			return _SCollection;
		}
		private void RicercaManRichiesta(bool reset)
		{
			
			// Manutenzione Richiesta
			DataGridRicerca.Visible=false;
			GridTitle1.Visible=false;
			DataGridRicerca2.Visible=true;
			Gridtitle2.Visible=true;
						
			Richiesta  _Richiesta = new Richiesta();						
			
			S_ControlsCollection _SCollection =GetOrdinaria();

			S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
			s_p_pageindex.ParameterName = "pageindex";
			s_p_pageindex.DbType = CustomDBType.Integer;
			s_p_pageindex.Direction = ParameterDirection.Input;
			s_p_pageindex.Index = _SCollection.Count +1;
			s_p_pageindex.Value=DataGridRicerca2.CurrentPageIndex +1;			
			_SCollection.Add(s_p_pageindex);

			S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
			s_p_pagesize.ParameterName = "pagesize";
			s_p_pagesize.DbType = CustomDBType.Integer;
			s_p_pagesize.Direction = ParameterDirection.Input;
			s_p_pagesize.Index = _SCollection.Count +1;
			s_p_pagesize.Value= DataGridRicerca2.PageSize;			
			_SCollection.Add(s_p_pagesize);

			DataSet _MyDs = _Richiesta.GetSfogliaRDLperOrdinariaPaging(_SCollection).Copy();		

			this.DataGridRicerca2.DataSource = _MyDs.Tables[0];

			DataGridRicerca2.Visible = true;
			Gridtitle2.Visible =true;
			Gridtitle2.hplsNuovo.Visible=false;

			if (reset==true)
			{
				_SCollection =GetOrdinaria();
				int _totalRecords = _Richiesta.GetSfogliaRDLperOrdinariaCount(_SCollection);;
				this.Gridtitle2.NumeroRecords=_totalRecords.ToString();
			}

			if (int.Parse(Gridtitle2.NumeroRecords) == 0 )
			{
				DataGridRicerca2.CurrentPageIndex=0;
				Gridtitle2.DescriptionTitle="Nessun dato trovato."; 
			}
			else
			{
				if (int.Parse(Gridtitle2.NumeroRecords) > maxOdl )
				{
					tableComandi.Visible=false;
					lblMessaggio.ForeColor=Color.Red;
					lblMessaggio.Font.Size=20;
					lblMessaggio.Text="La ricerca ha fornito più di " + Convert.ToString(maxOdl) + " risultati. Occorre restringere i criteri di ricerca selezionando un intervallo di date più corto o ad esempio in addetto";
				} 
				else 
				{
					lblMessaggio.Text="";
					lblMessaggio.Font.Size=10;
					lblMessaggio.ForeColor=Color.Black;
				
					tableComandi.Visible=true;
					Gridtitle2.DescriptionTitle=""; 
				}
			}
			
			this.DataGridRicerca2.VirtualItemCount =int.Parse(Gridtitle2.NumeroRecords);
			this.DataGridRicerca2.DataBind();	
		}

		private DataSet RicercaManRichiestaSelTutti()
		{
			
			// Manutenzione Richiesta
			DataGridRicerca.Visible=false;
			GridTitle1.Visible=false;
			DataGridRicerca2.Visible=true;
			Gridtitle2.Visible=true;
						
			Richiesta  _Richiesta = new Richiesta();							
			S_ControlsCollection _SCollection =GetOrdinaria();
		
			DataSet _MyDs = _Richiesta.GetSfogliaRDLperOrdinaria(_SCollection).Copy();

			return _MyDs;
		}

		public DataSet GetWordExcel()
		{
			Classi.ManOrdinaria.Richiesta  _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();						
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_Bl_Id = new S_Controls.Collections.S_Object();
			s_p_Bl_Id.ParameterName = "p_Bl_Id";
			s_p_Bl_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Bl_Id.Direction = ParameterDirection.Input;
			s_p_Bl_Id.Size =50;
			s_p_Bl_Id.Index = 0;
			s_p_Bl_Id.Value = RicercaModulo1.TxtCodice.Text;
			_SCollection.Add(s_p_Bl_Id);

			S_Controls.Collections.S_Object s_p_campus = new S_Controls.Collections.S_Object();
			s_p_campus.ParameterName = "p_campus";
			s_p_campus.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_campus.Direction = ParameterDirection.Input;
			s_p_campus.Index = 1;
			s_p_campus.Size=50;
			s_p_campus.Value = RicercaModulo1.TxtRicerca.Text;			
			_SCollection.Add(s_p_campus);

			S_Controls.Collections.S_Object s_p_Wr_Id = new S_Controls.Collections.S_Object();
			s_p_Wr_Id.ParameterName = "p_Wr_Id";
			s_p_Wr_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wr_Id.Direction = ParameterDirection.Input;
			s_p_Wr_Id.Index = 2;
			s_p_Wr_Id.Size=50;
			s_p_Wr_Id.Value = (this.txtsRichiesta.Text=="")?0:Int32.Parse(this.txtsRichiesta.Text);		
			_SCollection.Add(s_p_Wr_Id);

			S_Controls.Collections.S_Object s_p_Addetto = new S_Controls.Collections.S_Object();
			s_p_Addetto.ParameterName = "p_Addetto";
			s_p_Addetto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Addetto.Direction = ParameterDirection.Input;
			s_p_Addetto.Index = 3;
			s_p_Addetto.Size=50;
			s_p_Addetto.Value = this.Addetti1.NomeCompleto;			
			_SCollection.Add(s_p_Addetto);

			S_Controls.Collections.S_Object s_p_DataDa = new S_Controls.Collections.S_Object();
			s_p_DataDa.ParameterName = "p_DataDa";
			s_p_DataDa.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataDa.Direction = ParameterDirection.Input;
			s_p_DataDa.Index = 4;
			s_p_DataDa.Size= 10;
			s_p_DataDa.Value = (CalendarPicker1.Datazione.Text =="")? "":CalendarPicker1.Datazione.Text;  			
			_SCollection.Add(s_p_DataDa);

			S_Controls.Collections.S_Object s_p_DataA = new S_Controls.Collections.S_Object();
			s_p_DataA.ParameterName = "p_DataA";
			s_p_DataA.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataA.Direction = ParameterDirection.Input;
			s_p_DataA.Index = 5;
			s_p_DataA.Size= 10;
			s_p_DataA.Value = (CalendarPicker2.Datazione.Text =="")? "":CalendarPicker2.Datazione.Text;  			
			_SCollection.Add(s_p_DataA);

			S_Controls.Collections.S_Object s_p_Wo_Id = new S_Controls.Collections.S_Object();
			s_p_Wo_Id.ParameterName = "p_Wo_Id";
			s_p_Wo_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wo_Id.Direction = ParameterDirection.Input;
			s_p_Wo_Id.Index = 6;
			s_p_Wo_Id.Size=50;
			s_p_Wo_Id.Value = (this.txtsOrdine.Text=="")?0:Int32.Parse(this.txtsOrdine.Text);		
			_SCollection.Add(s_p_Wo_Id);
			
			S_Controls.Collections.S_Object s_p_Servizio = new S_Controls.Collections.S_Object();
			s_p_Servizio.ParameterName = "p_ID_Servizio";
			s_p_Servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Servizio.Direction = ParameterDirection.Input;
			s_p_Servizio.Index = 7;
			s_p_Servizio.Value = (cmbsServizio.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsServizio.SelectedValue);			
			_SCollection.Add(s_p_Servizio);

			S_Controls.Collections.S_Object s_p_Status = new S_Controls.Collections.S_Object();
			s_p_Status.ParameterName = "p_Status";
			s_p_Status.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Status.Direction = ParameterDirection.Input;
			s_p_Status.Index = 8;
			s_p_Status.Value = (cmbsStatus.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsStatus.SelectedValue);			
			_SCollection.Add(s_p_Status);

			S_Controls.Collections.S_Object s_p_Richiedente = new S_Controls.Collections.S_Object();
			s_p_Richiedente.ParameterName = "p_Richiedente";
			s_p_Richiedente.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Richiedente.Direction = ParameterDirection.Input;
			s_p_Richiedente.Index = 9;
			s_p_Richiedente.Size=50;
			s_p_Richiedente.Value = this.Richiedenti1.NomeCompleto;			
			_SCollection.Add(s_p_Richiedente);

			S_Controls.Collections.S_Object s_p_Priority = new S_Controls.Collections.S_Object();
			s_p_Priority.ParameterName = "p_Priority";
			s_p_Priority.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Priority.Direction = ParameterDirection.Input;
			s_p_Priority.Index = 10;
			s_p_Priority.Value = (cmbsUrgenza.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsUrgenza.SelectedValue);			
			_SCollection.Add(s_p_Priority);

			S_Controls.Collections.S_Object s_p_Descrizione = new S_Controls.Collections.S_Object();
			s_p_Descrizione.ParameterName = "p_Descrizione";
			s_p_Descrizione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Descrizione.Direction = ParameterDirection.Input;
			s_p_Descrizione.Index = 11;
			s_p_Descrizione.Size= 255;
			s_p_Descrizione.Value = txtDescrizione.Text;			
			_SCollection.Add(s_p_Descrizione);

			S_Controls.Collections.S_Object s_p_Gruppo = new S_Controls.Collections.S_Object();
			s_p_Gruppo.ParameterName = "p_Gruppo";
			s_p_Gruppo.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Gruppo.Direction = ParameterDirection.Input;
			s_p_Gruppo.Index = 12;
			s_p_Gruppo.Value = (cmbsGruppo.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsGruppo.SelectedValue);			
			_SCollection.Add(s_p_Gruppo);
		
			return  _Richiesta.GetSfogliaRDL(_SCollection).Copy();		
		}

		#endregion

		

		private void DataGridRicerca2_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{ 
				ImageButton _img3 = (ImageButton) e.Item.Cells[2].FindControl("Imagebutton3");
				string s_id_stato="1";
				if(e.Item.Cells[14].Text!= s_id_stato)
				{
					_img3.Visible=false;
			
				}
				
				string descrizione="";
				string indirizzo="";
				string ditta="";
				
					
				string tooltip = "";
				System.Collections.ArrayList itmTooltip = new ArrayList();
				itmTooltip.Add(tooltip);
				itmTooltip.Add(descrizione);
				
				if (e.Item.Cells[13].Text.Trim().Length !=0) 
				{
					Classi.Function.Tronca(e.Item.Cells[13].Text,75,itmTooltip,0);
					e.Item.Cells[13].ToolTip=itmTooltip[0].ToString();
					e.Item.Cells[13].Text=itmTooltip[1].ToString();						
				} 
				
				//				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton1");
				//				_img1.Attributes.Add("title","Emetti o Completa Richiesta di Lavoro");	

				if (e.Item.Cells[2].Text.Trim().Length > 20) 
				{
					indirizzo=e.Item.Cells[2].Text.Trim().Substring(0,18) + "..."; 
					e.Item.Cells[2].ToolTip=e.Item.Cells[2].Text;
					e.Item.Cells[2].Text=indirizzo;
				} 
				
				if (e.Item.Cells[12].Text.Trim().Length >20) 
				{
					descrizione=e.Item.Cells[12].Text.Trim().Substring(0,18) + "..."; 
					e.Item.Cells[12].ToolTip=e.Item.Cells[12].Text;
					e.Item.Cells[12].Text=descrizione;
				} 

				if (e.Item.Cells[5].Text.Trim().Length >12) 
				{
					ditta=e.Item.Cells[5].Text.Trim().Substring(0,10) + "..."; 
					e.Item.Cells[5].ToolTip=e.Item.Cells[5].Text;
					e.Item.Cells[5].Text=ditta;
				} 
							
			}
		
		}

		private void DataGridRicerca2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Modifica")
			{
				_myColl.AddControl(this.Page.Controls,ParentType.Page );
				string s_url = e.CommandArgument.ToString();
	
				Server.Transfer(s_url);
			
			}
			
			if (e.CommandName=="Dettaglio")
			{				
				_myColl.AddControl(this.Page.Controls,ParentType.Page );
				string s_url = e.CommandArgument.ToString();		
				string IdStato = e.Item.Cells[14].Text.Trim();	
				switch (IdStato)
				{
					case "1":
					case "7":
					case "15":											
						_myColl.AddControl(this.Page.Controls, ParentType.Page);
						Server.Transfer(s_url);	
						break;
					default:
						s_url += "&c=true";
						_myColl.AddControl(this.Page.Controls, ParentType.Page);
						Server.Transfer(s_url);	
						break;
				}							
									
			}
		}

		/*
		 * Quetsti metodi effettuano il settaggio dei dati necessari per la generazione
		 * del report comulativo
		 * controllando  qualvi checkbox del datagrid sono stati selezionati
		 * */
		private void S_btnConfermaSel_Click(object sender, System.EventArgs e)
		{
			lblMessaggio.Text = "";
			SetDati();
			SetControlli();	
		}
		private void SetDati()
		{			
			if (cmbsTipoManutenzione.SelectedValue=="3")
			{
				// Manutenzione Straordinaria
				checkTipoMan=3;
			}
			Hashtable _HS = new Hashtable();
			int indice = 0;
			
			if(Session["DatiList"]!=null)
			{
				_HS=(Hashtable) Session["DatiList"];				
			}

			if (checkTipoMan==3)
			{
				foreach(DataGridItem o_Litem in DataGridRicerca.Items)
				{
								
					indice = Int32.Parse(o_Litem.Cells[0].Text);									
					System.Web.UI.WebControls.CheckBox cb = 
						(System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel")
						;																									
			
					if(_HS.ContainsKey(indice))
						_HS.Remove(indice);												
							
					if(cb.Checked)
					{
						_HS.Add(indice, indice);		
					}
				}			
			} 
			else 
			{
				foreach(DataGridItem o_Litem in DataGridRicerca2.Items)
				{
								
					indice = Int32.Parse(o_Litem.Cells[0].Text);									
					System.Web.UI.WebControls.CheckBox cb = 
						(System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel2")
						;																									
			
					if(_HS.ContainsKey(indice))
						_HS.Remove(indice);												
							
					if(cb.Checked)
					{
						_HS.Add(indice, indice);		
					}
				}			
			}
			
			Session.Remove("DatiList");
			Session.Add("DatiList",_HS);			
			lblElementiSelezionati.Text="Elementi Selezionati - " + _HS.Count.ToString() + " -";
			if(_HS.Count>0)
				EnableControl(true);
			else
				EnableControl(false);

			//			txtTotSelezionati.Text=_HS.Count.ToString();
		}


		private void SetDati(bool val)
		{	
			Hashtable _HS = new Hashtable();
			int indice = 0;
		
			if(Session["DatiList"]!=null)
			{
				_HS=(Hashtable) Session["DatiList"];				
			}

					
			foreach(DataGridItem o_Litem in DataGridRicerca.Items)
			{								
				indice = Int32.Parse(o_Litem.Cells[0].Text);									
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel");																									
				cb.Checked=val;
				if(_HS.ContainsKey(indice))
					_HS.Remove(indice);												
							
				if(cb.Checked)
				{
					_HS.Add(indice, indice);		
				}
			}			
			
			Session.Remove("DatiList");
			Session.Add("DatiList",_HS);			
			lblElementiSelezionati.Text="Elementi Selezionati - " + _HS.Count.ToString() + " -";
			if(_HS.Count>0)
				EnableControl(true);
			else
				EnableControl(false);

			//txtTotSelezionati.Text=_HS.Count.ToString();			
		}

		private void SetDati2(bool val)
		{	
			Hashtable _HS = new Hashtable();
			int indice = 0;
		
			if(Session["DatiList"]!=null)
			{
				_HS=(Hashtable) Session["DatiList"];				
			}

					
			foreach(DataGridItem o_Litem in DataGridRicerca2.Items)
			{
				string dbg = o_Litem.Cells[1].Text;
				indice = Int32.Parse(o_Litem.Cells[0].Text);									
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel2");																									
				cb.Checked=val;
				if(_HS.ContainsKey(indice))
					_HS.Remove(indice);												
							
				if(cb.Checked)
				{
					_HS.Add(indice, indice);		
				}
			}			
			
			Session.Remove("DatiList");
			Session.Add("DatiList",_HS);			
			lblElementiSelezionati.Text="Elementi Selezionati - " + _HS.Count.ToString() + " -";
			if(_HS.Count>0)
				EnableControl(true);
			else
				EnableControl(false);

			//txtTotSelezionati.Text=_HS.Count.ToString();			
		}

		private void EnableControl(bool enable)
		{
			S_btnStampa.Enabled =enable;
		}

		private void SetControlli()
		{	
			clMyDataGridCollection _cl = new clMyDataGridCollection();
			Hashtable _HS = new Hashtable();
			if(Session["CheckedList"]!=null)
			{
				_HS=(Hashtable) Session["CheckedList"];				
			}
			if (cmbsTipoManutenzione.SelectedValue=="3")
			{				
				_HS=_cl.SetControl(DataGridRicerca,_HS,DataGridRicerca.CurrentPageIndex);
				Session.Remove("CheckedList");
				Session.Add("CheckedList",_HS);		
			}
			else			
			{	
				_HS=_cl.SetControl(DataGridRicerca2,_HS,DataGridRicerca2.CurrentPageIndex);
				Session.Remove("CheckedList");
				Session.Add("CheckedList",_HS);	
			}				
		}

		/*effettua il sedirect alla pagina di download*/
		private void S_btnDownLoad_Click(object sender, System.EventArgs e)
		{
			_myColl.AddControl(this.Page.Controls,ParentType.Page);
			Server.Transfer("Pagina_Download_Cumulativi.aspx");
		}

		/*I metodi a seguire 
		 * creano il report e 
		 * scrivono nel database
		 * i dati del report*/


		ReportDocument crReportDocument;
		private void S_btnStampa_Click(object sender, System.EventArgs e)
		{
			EnableControl(false);
			string strOdl = recuperaSesOdl();
			string [] arOdl = strOdl.Split(',');
			int nOdl = arOdl.Length;

			if (nOdl>=400)
			{
				lblMessaggio.ForeColor=Color.Red;
				lblMessaggio.Text = "Non possono essere selezionate più di 400 richieste di lavoro.<br>Prova ad inserire dei filtri più restrittivi.";
			} 
			else 
			{

				//insert db chiama il metodo per la crezion e del file pdf
				//try 
				//{
				int idFile= insertDb(nOdl,strOdl);
				lblMessaggio.ForeColor=Color.Black;
				lblMessaggio.Text = "Il file " + creaNomeFile(nOdl,idFile) + ".pdf"+ " e' stato  creato correttamente";
				//} 
				//catch (Exception exc)
				//{
				//	lblMessaggio.ForeColor=Color.Red;
				//	lblMessaggio.Text = "Errore nella generazione del file pdf.<br>";

				//}
			}

			


		}

		private string creaNomeFile(int nOdl, int idFile)
		{
			return "reportRDLcomulativo"+DateTime.Now.ToString().Replace("/","").Replace(".","").Replace(" ","");
		}

		private string recuperaSesOdl()
		{
			string strOdl=String.Empty;
			Hashtable _HS = (Hashtable)Session["DatiList"];
			IDictionaryEnumerator myEnumerator = _HS.GetEnumerator();								
			while (myEnumerator.MoveNext())	
			{
				strOdl += myEnumerator.Value + ",";
			}
					
			strOdl = strOdl.Remove(strOdl.Length-1,1);
			Session.Remove("DatiList");
			return strOdl;
		}


		#region Passaggio dati al DataLayer	e creazione file pdf e zip	
		private int insertDb(int nOdl, string strOdl)
		{

			string nomeFile=this.creaNomeFile(nOdl,0);

			long dimensionefilePdf = 0;
			long dimensionefileZip = 0;
			dimensionefilePdf=stampaPdf(nomeFile,strOdl.Split(','));
			dimensionefileZip=creaZip(nomeFile);

			AgganciaDatalayer io_db  = new AgganciaDatalayer();
			S_ControlsCollection clDatiUpDb = new S_ControlsCollection();
			int pIndex=0;


			//setto il campo dei servizi
			string tservizio="";
			if ( cmbsServizio.SelectedItem.Text=="- Selezionare un Servizio -")
			{
				tservizio="tutti";
			}
			else
			{
				tservizio=cmbsServizio.SelectedItem.Text;
			}

			//setto i richiedenti
			string trichiedenti="";
			if(cmbsGruppo.SelectedItem.Text=="- Selezionare un Gruppo -")
			{
				trichiedenti="tutti";
			}
			else
			{
				trichiedenti=cmbsGruppo.SelectedItem.Text;
			}

			//setto l'urgenza
			string turgenza="";
			if(cmbsUrgenza.SelectedItem.Text=="- Selezionare una Urgenza -")
			{
				turgenza="tutte";
			}
			else
			{
				turgenza=cmbsUrgenza.SelectedItem.Text;
			}
			string statoRichiesta;
			if(cmbsStatus.SelectedItem.Text=="- Selezionare uno Stato -")
			{
				statoRichiesta="tutti";
			}
			else
			{
				statoRichiesta=cmbsStatus.SelectedItem.Text;
			}
			

			string quantitaOdl = "N. " + nOdl.ToString() + " Odl";

			S_Object pNomeFile = new S_Object();
			pNomeFile.ParameterName = "p_NOME_FILE";
			pNomeFile.DbType = CustomDBType.VarChar;
			pNomeFile.Direction = ParameterDirection.Input;
			pNomeFile.Index = pIndex++;
			pNomeFile.Value =nomeFile;
			clDatiUpDb.Add(pNomeFile);

			S_Object pStringaRdl = new S_Object();
			pStringaRdl.ParameterName = "P_STRINGARDL";
			pStringaRdl.DbType = CustomDBType.VarChar;
			pStringaRdl.Direction = ParameterDirection.Input;
			pStringaRdl.Index = pIndex++;
			pStringaRdl.Value = nOdl;
			clDatiUpDb.Add(pStringaRdl);
		

			S_Object pDataCreated = new S_Object();
			pDataCreated.ParameterName = "P_DATA_CREATED";
			pDataCreated.DbType = CustomDBType.VarChar;
			pDataCreated.Direction = ParameterDirection.Input;
			pDataCreated.Index = pIndex++;
			pDataCreated.Value =DateTime.Now;
			clDatiUpDb.Add(pDataCreated);

			S_Object pDataAssegnazioneIn = new S_Object();
			pDataAssegnazioneIn.ParameterName = "P_DATA_ASSEGNAZIONE_INIT";
			pDataAssegnazioneIn.DbType = CustomDBType.VarChar;
			pDataAssegnazioneIn.Direction = ParameterDirection.Input;
			pDataAssegnazioneIn.Size=64;
			pDataAssegnazioneIn.Index =  pIndex++;
			string dataDAV1="";
			if (CalendarPicker3.Datazione.Text=="" || CalendarPicker3.Datazione.Text==null)
				dataDAV1="non specificata";
			else
				dataDAV1=CalendarPicker3.Datazione.Text;
			pDataAssegnazioneIn.Value = dataDAV1;
			clDatiUpDb.Add(pDataAssegnazioneIn);

			S_Object pDataAssegnazioneEnd = new S_Object();
			pDataAssegnazioneEnd.ParameterName = "P_DATA_ASSEGNAZIONE_END";
			pDataAssegnazioneEnd.DbType = CustomDBType.VarChar;
			pDataAssegnazioneEnd.Direction = ParameterDirection.Input;
			pDataAssegnazioneEnd.Size=64;
			pDataAssegnazioneEnd.Index = pIndex++;
			string dataAV1="";
			if (CalendarPicker4.Datazione.Text=="" || CalendarPicker4.Datazione.Text==null)
				dataAV1="non specificata";
			else
				dataAV1=CalendarPicker4.Datazione.Text;
			pDataAssegnazioneEnd.Value =  dataAV1;
			clDatiUpDb.Add(pDataAssegnazioneEnd);
			
			S_Object pDataCompletamentoIn = new S_Object();
			pDataCompletamentoIn.ParameterName = "P_DATA_COMPLETAMENTO_INIT";
			pDataCompletamentoIn.DbType = CustomDBType.VarChar;
			pDataCompletamentoIn.Direction = ParameterDirection.Input;
			pDataCompletamentoIn.Index = pIndex++;
			pDataCompletamentoIn.Value =  DBNull.Value;////DBNull.Value;
			clDatiUpDb.Add(pDataCompletamentoIn);

			S_Object pDataCompletamentoEnd = new S_Object();
			pDataCompletamentoEnd.ParameterName = "P_DATA_COMPLETAMENTO_END";
			pDataCompletamentoEnd.DbType = CustomDBType.VarChar;
			pDataCompletamentoEnd.Direction = ParameterDirection.Input;
			pDataCompletamentoEnd.Index = pIndex++;
			pDataCompletamentoEnd.Value =  DBNull.Value;////DBNull.Value;
			clDatiUpDb.Add(pDataCompletamentoEnd);

			S_Object pEdificio = new S_Object();
			pEdificio.ParameterName = "P_EDIFICIO";
			pEdificio.DbType = CustomDBType.VarChar;
			pEdificio.Direction = ParameterDirection.Input;
			pEdificio.Size=8;
			pEdificio.Index = pIndex++;
			string edificio="";
			if (RicercaModulo1.TxtCodice.Text=="" || RicercaModulo1.TxtCodice.Text==null)
				edificio="tutti";
			else
				edificio=RicercaModulo1.TxtCodice.Text;
			pEdificio.Value =  edificio;//S_cmbComune.SelectedItem.Text;
			clDatiUpDb.Add(pEdificio);

			S_Object pRichiestaLavoro = new S_Object();
			pRichiestaLavoro.ParameterName = "P_RICHIESTA_DI_LAVORO";
			pRichiestaLavoro.DbType = CustomDBType.VarChar;
			pRichiestaLavoro.Direction = ParameterDirection.Input;
			pRichiestaLavoro.Index = pIndex++;
			pRichiestaLavoro.Size=256;
			string richiesta;
			richiesta=(txtsRichiesta.Text=="" || txtsRichiesta.Text==null) ? "tutte" : txtsRichiesta.Text;
			pRichiestaLavoro.Value = richiesta;
			clDatiUpDb.Add(pRichiestaLavoro);

			S_Object  pAddetto = new S_Object();
			pAddetto.ParameterName = "P_ADDETTO";
			pAddetto.DbType = CustomDBType.VarChar;
			pAddetto.Size=64;
			pAddetto.Direction = ParameterDirection.Input;
			pAddetto.Index = pIndex++;
			string addetto="";
			if (Addetti1.NomeCompleto=="" || Addetti1.NomeCompleto==null)
				addetto="tutti";
			else
				addetto=Addetti1.NomeCompleto;
			pAddetto.Value =  addetto;//S_cmbComune.SelectedItem.Text;
			//pAddetto.Value =  Addetti1.NomeCompleto; //S_cmbDitta.SelectedItem.Text;
			clDatiUpDb.Add(pAddetto);

			S_Object pDataDa = new S_Object();
			pDataDa.ParameterName = "P_DATA_DA";
			pDataDa.DbType = CustomDBType.VarChar;
			pDataDa.Size=64;
			pDataDa.Direction = ParameterDirection.Input;
			pDataDa.Index = pIndex++;
			string dataDaV="";
			if (CalendarPicker1.Datazione.Text=="" || CalendarPicker1.Datazione.Text==null)
				dataDaV="non specificata";
			else
				dataDaV=CalendarPicker1.Datazione.Text;
			pDataDa.Value = dataDaV;//S_cmbCategoria.SelectedItem.Text;
			clDatiUpDb.Add(pDataDa);

			S_Object pDataA = new S_Object();
			pDataA.ParameterName = "P_DATA_A";
			pDataA.DbType = CustomDBType.VarChar;
			pDataA.Size=64;
			pDataA.Direction = ParameterDirection.Input;
			pDataA.Index = pIndex++;
			string dataAV="";
			if (CalendarPicker2.Datazione.Text=="" || CalendarPicker2.Datazione.Text==null)
				dataAV="non specificata";
			else
				dataAV=CalendarPicker2.Datazione.Text;
			pDataA.Value =  dataAV; //S_cmbAddetto.SelectedItem.Text;
			clDatiUpDb.Add(pDataA);

			S_Object pOrdineDiLavoro = new S_Object();
			pOrdineDiLavoro.ParameterName = "P_ORDINE_LAVORO";
			pOrdineDiLavoro.DbType = CustomDBType.VarChar;
			pOrdineDiLavoro.Direction = ParameterDirection.Input;
			pOrdineDiLavoro.Size=256;
			pOrdineDiLavoro.Index = pIndex++;
			string ordineLavoro="";
			if (txtsOrdine.Text=="" || txtsOrdine.Text==null)
				ordineLavoro="tutti";
			else
				ordineLavoro= txtsOrdine.Text;
			pOrdineDiLavoro.Value = ordineLavoro;
			clDatiUpDb.Add(pOrdineDiLavoro);

			S_Object pStatoRichiesta = new S_Object();
			pStatoRichiesta.ParameterName = "P_STATO_RICHIESTA";
			pStatoRichiesta.DbType = CustomDBType.VarChar;
			pStatoRichiesta.Size=256;
			pStatoRichiesta.Direction = ParameterDirection.Input;
			pStatoRichiesta.Index = pIndex++;
			pStatoRichiesta.Value =  statoRichiesta;
			clDatiUpDb.Add(pStatoRichiesta);

			S_Object pServizioId = new S_Object();
			pServizioId.ParameterName ="P_SERVIZIO_ID";
			pServizioId.DbType = CustomDBType.VarChar;
			pServizioId.Size=256;
			pServizioId.Direction = ParameterDirection.Input;
			pServizioId.Index = pIndex++;
			pServizioId.Value =  tservizio;
			clDatiUpDb.Add(pServizioId);

			S_Object pRichiedentiTipoId = new S_Object();
			pRichiedentiTipoId.ParameterName = "P_RICHIEDENTI_TIPO_ID";
			pRichiedentiTipoId.DbType = CustomDBType.VarChar;
			pRichiedentiTipoId.Direction = ParameterDirection.Input;
			pRichiedentiTipoId.Size=256;
			pRichiedentiTipoId.Index = pIndex++;
			pRichiedentiTipoId.Value = trichiedenti;
			clDatiUpDb.Add(pRichiedentiTipoId);

			S_Object pEm_Id = new S_Object();
			pEm_Id.ParameterName = "P_EM_ID";
			pEm_Id.DbType = CustomDBType.VarChar;
			pEm_Id.Size=256;
			pEm_Id.Direction = ParameterDirection.Input;
			pEm_Id.Index = pIndex++;
			string em="";
			if (Richiedenti1.NomeCompleto=="" || Richiedenti1.NomeCompleto==null)
				em="tutti";
			else
				em=Richiedenti1.NomeCompleto;
			pEm_Id.Value = em;//Richiedenti1.txtRichiedente;
			clDatiUpDb.Add(pEm_Id);

			S_Object pIdPriority = new S_Object();
			pIdPriority.ParameterName = "P_ID_PRIORITY";
			pIdPriority.DbType = CustomDBType.VarChar;
			pIdPriority.Size=256;
			pIdPriority.Direction = ParameterDirection.Input;
			pIdPriority.Index = pIndex++;
			pIdPriority.Value =  turgenza; // strOdl.Replace(",","-");
			clDatiUpDb.Add(pIdPriority);

			S_Object pDescrizione = new S_Object();
			pDescrizione.ParameterName = "P_DESCRIZIONE";
			pDescrizione.DbType = CustomDBType.VarChar;
			pDescrizione.Size=256;
			pDescrizione.Direction = ParameterDirection.Input;
			pDescrizione.Index = pIndex++;
			pDescrizione.Value =  txtDescrizione.Text;
			clDatiUpDb.Add(pDescrizione);

			S_Object pTipoManutenzioneId = new S_Object();
			pTipoManutenzioneId.ParameterName = "P_TIPOMANUTENZIONE_ID";
			pTipoManutenzioneId.DbType = CustomDBType.VarChar;
			pDescrizione.Size=256;
			pTipoManutenzioneId.Direction = ParameterDirection.Input;
			pTipoManutenzioneId.Index = pIndex++;
			pTipoManutenzioneId.Value = cmbsTipoManutenzione.SelectedItem.Text;
			clDatiUpDb.Add(pTipoManutenzioneId);
			
			S_Object pDimensioneFile  = new S_Object();
			pDimensioneFile.ParameterName = "P_DIMENSIONE_FILE";
			pDimensioneFile.DbType = CustomDBType.Integer;
			pDimensioneFile.Direction = ParameterDirection.Input;
			pDimensioneFile.Index = pIndex++;
			pDimensioneFile.Value = dimensionefilePdf;
			clDatiUpDb.Add(pDimensioneFile);

			
			S_Object pDimensioneZip  = new S_Object();
			pDimensioneZip.ParameterName = "P_DIMENSIONE_FILE_ZIP";
			pDimensioneZip.DbType = CustomDBType.Integer;
			pDimensioneZip.Direction = ParameterDirection.Input;
			pDimensioneZip.Index = pIndex++;
			pDimensioneZip.Value = dimensionefileZip;
			clDatiUpDb.Add(pDimensioneZip);

			S_Object pTipologiaReport  = new S_Object();
			pTipologiaReport.ParameterName = "P_TIPOLOGIA_REPORT";
			pTipologiaReport.DbType = CustomDBType.VarChar;
			pTipologiaReport.Direction = ParameterDirection.Input;
			pTipologiaReport.Index = pIndex++;
			pTipologiaReport.Value = DBNull.Value;
			clDatiUpDb.Add(pTipologiaReport);

			S_Object pDimensionePdfZip  = new S_Object();
			pDimensionePdfZip.ParameterName = "p_DIMENSIONEFILE_PDF_ZIP";
			pDimensionePdfZip.DbType = CustomDBType.Integer;
			pDimensionePdfZip.Direction = ParameterDirection.Input;
			pDimensionePdfZip.Index = pIndex++;
			pDimensionePdfZip.Value = 0;
			clDatiUpDb.Add(pDimensionePdfZip);

			
			
			io_db.NameProcedureDb = "pack_CostiGestioneCumulativi.UpdAnalisiCostiOperativi";
			int result = io_db.Add(clDatiUpDb);

			
			return result;
		
		}



		private long stampaPdf(string nomeFile, string [] arOdl)
		{

			string pathRptSource="";
			CostiOperativiCumulativo rptMan = new CostiOperativiCumulativo("");
			crReportDocument=new ReportDocument();
			pathRptSource=Server.MapPath("../Report/RptTecnicoIntervento2Cumulativo.rpt");
			crReportDocument.Load(pathRptSource);
			dsRapportino dsp = rptMan.ImpostaRpt(arOdl);
			string xml = dsp.GetXml();
			crReportDocument.SetDataSource(dsp);

			string DirectoryName =  System.Configuration.ConfigurationSettings.AppSettings["DirectoryStampaCostoGestione"];
			StampaSuDisco StampaPdf = new StampaSuDisco(Server.MapPath(DirectoryName));

			StampaPdf.StampaPdf(crReportDocument,nomeFile);		
			string assolutoFilePdf = Server.MapPath(DirectoryName) + nomeFile + ".pdf";
			FileInfo dettagliFile = new FileInfo(assolutoFilePdf);
			return dettagliFile.Length;
			
		}

		private long creaZip(string nomeFile)
		{
			string DirectoryName = System.Configuration.ConfigurationSettings.AppSettings["DirectoryStampaCostoGestione"];
			string filePdf = nomeFile + ".pdf";
			string assolutoFileZip = Server.MapPath(DirectoryName) + nomeFile + ".zip";
			FastZip makeZipFile = new FastZip();
			makeZipFile.CreateZip(assolutoFileZip,Server.MapPath(DirectoryName),true,filePdf);
			FileInfo dettagliFile = new FileInfo(assolutoFileZip);
			return dettagliFile.Length;
		}
		#endregion

		private void S_btnSelezionaTutto_Click(object sender, System.EventArgs e)
		{
			SelezionaTutti(true);
		}

		private void S_btnDeselezioneTutto_Click(object sender, System.EventArgs e)
		{
			SelezionaTutti(false);
		}

		private void S_btnReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AnalisiCostiOperativiDiGestioneCumulativo.aspx");
		}

		private void SelezionaTutti(bool val)
		{	
			DataGridRicerca.AllowCustomPaging=false;
			DataGridRicerca2.AllowCustomPaging=false;
			
			DataSet ds;
			if (cmbsTipoManutenzione.SelectedValue=="3")
			{
				
				ds = RicercaSelTutti();
				if(!val)
				{
					Session.Remove("CheckedList");
					Session.Remove("DatiList");
					lblElementiSelezionati.Text="Elementi Selezionati - 0 -";
					EnableControl(false);
					//txtTotSelezionati.Text="0";
				}
				else
				{				
					SetControlli();										
				}
			    //DataGridRicerca.AllowCustomPaging=true;
				for(int Pagine = 0;Pagine<=DataGridRicerca.PageCount;Pagine++)
				{
		
					int dbg =ds.Tables[0].Rows.Count;
					DataGridRicerca.DataSource= ds.Tables[0];//Session["DataSet"];
					DataGridRicerca.DataBind();
					DataGridRicerca.CurrentPageIndex=Pagine;									
								
					SetDati(val);
					
					if(val)
					{	
						SetControlli();				
					}
				}

				DataGridRicerca.CurrentPageIndex=0;
				DataGridRicerca.DataSource= ds.Tables[0];;
				DataGridRicerca.DataBind();			
				GetControlli();	
					
			}
			else			
			{	// Manutenzione Richiesta				
				ds = RicercaManRichiestaSelTutti();
				if(!val)
				{
					Session.Remove("CheckedList");
					Session.Remove("DatiList");
					lblElementiSelezionati.Text="Elementi Selezionati - 0 -";
					EnableControl(false);
					//txtTotSelezionati.Text="0";
				}
				else
				{				
					SetControlli();										
				}
			
				for(int Pagine = 0;Pagine<=DataGridRicerca2.PageCount;Pagine++)
				{
	
					int dbg =ds.Tables[0].Rows.Count;
					DataGridRicerca2.DataSource= ds.Tables[0];//Session["DataSet"];
					DataGridRicerca2.DataBind();
					DataGridRicerca2.CurrentPageIndex=Pagine;									
							
					SetDati2(val);
				
					if(val)
					{	
						SetControlli();				
					}
				}

				DataGridRicerca2.CurrentPageIndex=0;
				DataGridRicerca2.DataSource= ds.Tables[0];;
				DataGridRicerca2.DataBind();
				
				GetControlli2();
			
	
			}	
			DataGridRicerca.AllowCustomPaging=true;
			DataGridRicerca2.AllowCustomPaging=true;	
		}
		
	}

}
