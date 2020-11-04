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
	/// Descrizione di riepilogo per ReportGiudizioCliente.
	/// </summary>
	public class ReportGiudizioCliente : System.Web.UI.Page
	{
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_ComboBox cmbsGiudizio;
		protected System.Web.UI.WebControls.Panel PanelServizio;
		protected S_Controls.S_Button btnsRicerca;
		protected S_Controls.S_Button btnReset;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_ComboBox cmbsTipoGiudizio;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.CalendarPicker CPDataDa;
		protected WebControls.CalendarPicker CPDataA;
		protected WebControls.CodiceApparecchiature CodiceApparecchiature1; 
		protected WebControls.PageTitle PageTitle1; 
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvOraRichiesta;
		public static int FunId = 0;
		public int  controllo = 0;
		TheSite.SoddisfazioneCliente.EditGiudizio _fp;
		protected WebControls.RicercaModulo RicercaModulo1;
		public static string HelpLink = string.Empty;
		protected System.Web.UI.WebControls.TextBox txtBL_ID;
		protected System.Web.UI.WebControls.Button btsCodice;
		protected System.Web.UI.WebControls.Panel PanelRichiedente;
		protected S_Controls.S_Button cmdExcel;
		MyCollection.clMyCollection _myColl = new clMyCollection();



		private void Page_Load(object sender, System.EventArgs e)
		{
			
			// ***********************  MODIFICA PER I PERMESSI SULLA PAGINA CORRENTE **********************
			//Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];			
			string _mypage="./SoddisfazioneCliente/ReportGiudizioCliente.aspx";			
			Classi.SiteModule _SiteModule = new TheSite.Classi.SiteModule(_mypage);
			// ***********************  MODIFICA PER I PERMESSI SULLA PAGINA CORRENTE **********************
			this.GridTitle1.hplsNuovo.NavigateUrl = "../SoddisfazioneCliente/EditGiudizio.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
			this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;
			this.DataGridRicerca.Columns[1].Visible = true;
			this.DataGridRicerca.Columns[2].Visible = _SiteModule.IsEditable;	

			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			
			this.RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);
			/// Imposto il nome della combo Servizio
			this.CodiceApparecchiature1.NameComboServizio ="cmbsServizio";
			/// Imposto il nome dell'user control RicercaModulo
			this.CodiceApparecchiature1.NameUserControlRicercaModulo  ="RicercaModulo1";
			/// Imposto il nome della cobmbo del piano
			this.CodiceApparecchiature1.NameComboPiano  ="cmbsPiano";
			/// Imposto il nome della combo della stanza
			this.CodiceApparecchiature1.NameComboStanza  ="cmbsStanza";

			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();

			sbValid = new System.Text.StringBuilder();
				
			sbValid.Append("if (typeof(seledificio) == 'function') { ");
			sbValid.Append("if (seledificio() == false) { return false; }} ");
			sbValid.Append("document.getElementById('" + this.cmbsServizio.ClientID + "').disabled = true;");
				
									
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
						//Ricerca();
					}
				}

				this.BindServizio(string.Empty);	
				this.BindGiudizio();				
				this.CodiceApparecchiature1.Visible = false;		
				this.CodiceApparecchiature1.s_CodiceApparecchiatura.ReadOnly =  true;
				
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


		private void Ricerca()
		{
			DataSet _MyDs=GetData();
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();		
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();
			

		}

		private DataSet GetData()
		{
			
			string data_da=CPDataDa.Datazione.Text;
			if (data_da=="")
				data_da= "0";
			string data_a=CPDataA.Datazione.Text;
			if (data_a=="")
				data_a="0";
			Classi.GiudizioCliente.Giudizio _ReportGiudizio = new Classi.GiudizioCliente.Giudizio();
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			S_Controls.Collections.S_Object s_p_Bl_cod = new S_Controls.Collections.S_Object();
			s_p_Bl_cod.ParameterName = "p_Bl_id";
			s_p_Bl_cod.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Bl_cod.Direction = ParameterDirection.Input;
			s_p_Bl_cod.Index = 0;
			s_p_Bl_cod.Value = (RicercaModulo1.Idbl=="")?0:int.Parse(RicercaModulo1.Idbl);
			CollezioneControlli.Add(s_p_Bl_cod);

	
			S_Controls.Collections.S_Object s_p_datada = new S_Controls.Collections.S_Object();
			s_p_datada.ParameterName = "p_data_da";
			s_p_datada.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_datada.Direction = ParameterDirection.Input;
			s_p_datada.Index = 1;
			s_p_datada.Value =data_da;		
			CollezioneControlli.Add(s_p_datada);
		

			S_Controls.Collections.S_Object s_p_dataa = new S_Controls.Collections.S_Object();
			s_p_dataa.ParameterName = "p_data_a";
			s_p_dataa.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_dataa.Direction = ParameterDirection.Input;
			s_p_dataa.Index = 2;
			s_p_dataa.Value =data_a;					
			CollezioneControlli.Add(s_p_dataa);

			S_Controls.Collections.S_Object s_p_id_servizio = new S_Controls.Collections.S_Object();
			s_p_id_servizio.ParameterName = "p_id_servizio";
			s_p_id_servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_id_servizio.Direction = ParameterDirection.Input;
			s_p_id_servizio.Index =3;
			s_p_id_servizio.Value =  (this.cmbsServizio.SelectedValue.ToString()=="")?0:Int32.Parse(this.cmbsServizio.SelectedValue.ToString());					
			CollezioneControlli.Add(s_p_id_servizio);

			S_Controls.Collections.S_Object s_p_id_soddisfazione = new S_Controls.Collections.S_Object();
			s_p_id_soddisfazione.ParameterName = "p_id_soddisfazione";
			s_p_id_soddisfazione.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_id_soddisfazione.Direction = ParameterDirection.Input;
			s_p_id_soddisfazione.Index = 4;
			s_p_id_soddisfazione.Value =  (this.cmbsGiudizio.SelectedValue.ToString()=="")?0:Int32.Parse(this.cmbsGiudizio.SelectedValue.ToString());					
			CollezioneControlli.Add(s_p_id_soddisfazione);

			S_Controls.Collections.S_Object s_p_tipogiudizio = new S_Controls.Collections.S_Object();
			s_p_tipogiudizio.ParameterName = "p_tipogiudizio";
			s_p_tipogiudizio.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_tipogiudizio.Direction = ParameterDirection.Input;
			s_p_tipogiudizio.Index = 5;
			s_p_tipogiudizio.Value =  cmbsTipoGiudizio.SelectedValue;					
			CollezioneControlli.Add(s_p_tipogiudizio);

			DataSet _MyDs = _ReportGiudizio.ReportGiudizio(CollezioneControlli).Copy();
			return _MyDs;
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
			}
			else
			{
				_MyDs = _Servizio.GetData();
			}

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
			this.cmdExcel.Click += new System.EventHandler(this.cmdExcel_Click);
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ReportGiudizioCliente.aspx?FunId=" + FunId);
		}

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			this.DataGridRicerca.CurrentPageIndex=0;
			Ricerca();
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
//			if (e.Item.Cells[0].Text=="C")
//				e.Item.Cells[0].Text="Giudizio a caldo";
//			else if (e.Item.Cells[0].Text=="F")
//				e.Item.Cells[0].Text="Giudizio a freddo";

		}

		private void cmdExcel_Click(object sender, System.EventArgs e)
		{
			Csy.WebControls.Export 	_objExport = new Csy.WebControls.Export();
			DataTable _dt = new DataTable();			
			
				_dt = GetData().Tables[0].Copy();	
			if (_dt.Rows.Count != 0)
			{
				_objExport.ExportDetails(_dt, Csy.WebControls.Export.ExportFormat.Excel, "exp.xls" ); 		
			}
			else
			{
				String scriptString = "<script language=JavaScript>alert('Nessun elemento da esportare');";
				scriptString += "<";
				scriptString += "/";
				scriptString += "script>";

				if(!this.IsClientScriptBlockRegistered("clientScriptexp"))
					this.RegisterStartupScript ("clientScriptexp", scriptString);
			}
			
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.DataGridRicerca.CurrentPageIndex=e.NewPageIndex;
			Ricerca();
		}
	}
}
