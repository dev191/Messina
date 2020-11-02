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
using WebCad.Classi.ClassiDettaglio;
using WebCad.MyCollection; 
using WebCad.Apparecchiature;

namespace WebCad.Edifici
{
	/// <summary>
	/// Descrizione di riepilogo per DataRoom.
	/// </summary>
	public class DataRoom : System.Web.UI.Page    // System.Web.UI.Page
	{

		#region Dichiarazioni Oggetti

		protected S_Controls.S_Button S_btMostra;
		protected S_Controls.S_Button btReset;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_ComboBox cmbsPiano;
		protected System.Web.UI.WebControls.DataGrid MyDataGrid1;
		protected WebControls.GridTitle GridTitle1; 
		protected WebControls.PageTitle PageTitle1;
		protected WebControls.CodiceStdApparecchiatura CodiceStdApparecchiatura1;
		protected WebControls.CodiceApparecchiature CodiceApparecchiature1;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected WebControls.UserStanze UserStanze1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenblid;
		

		#endregion

		#region Dichiarazioni Variabili e Classi

		public static int FunId = 0;
		public static string HelpLink = string.Empty;
		WebCad.Classi.AnagrafeImpianti.DataRoom _DataRoom = new WebCad.Classi.AnagrafeImpianti.DataRoom();
		S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
		DataSet Ds;		
		MyCollection.clMyCollection _myColl = new MyCollection.clMyCollection();
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_ComboBox cmbsApparecchiatura;
		NavigazioneAppDEMO _fp;

		#endregion

		public MyCollection.clMyCollection _Contenitore
		{
			get {return _myColl;}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{

			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
/*COMMENTATO DA TOGLIERE POI
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
*/				
			 
//			RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindPiano);
//			RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);
//			RicercaModulo1.DelegateCodiceServizio1 +=new  WebControls.DelegateCodiceServizio(this.BindStanza);
		   
			UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
			UserStanze1.NameComboPiano="cmbsPiano";

			CodiceApparecchiature1.NameComboApparecchiature ="cmbsApparecchiatura";
			/// Imposto il nome della combo Servizio
			CodiceApparecchiature1.NameComboServizio ="cmbsServizio";
			CodiceStdApparecchiatura1.NameUserControlRicercaModulo  ="RicercaModulo1";
			CodiceApparecchiature1.NameUserControlRicercaModulo = "RicercaModulo1";

           
			if (!IsPostBack) 
			{
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];

				
				setvisiblecontrol(false);
				GridTitle1.Visible = false;
				if(Context.Handler is WebCad.Edifici.NavigazioneAppDEMO)
				{
					_fp = (WebCad.Edifici.NavigazioneAppDEMO)Context.Handler;

					BindTuttiPiani();
					//BindStanza();
					BindServizio("");
					BindApparecchiatura();
					
					if (_fp!=null) 
					{						
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);		

						Execute();
					}
				}
				else
				{
					BindTuttiPiani();
			//		BindStanza();
					BindServizio("");
					BindApparecchiatura();
					
				}
				
			}		
			GridTitle1.hplsNuovo.Visible=false;
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
			this.cmbsServizio.SelectedIndexChanged += new System.EventHandler(this.cmbsServizio_SelectedIndexChanged);
			this.S_btMostra.Click += new System.EventHandler(this.S_btMostra_Click);
			this.btReset.Click += new System.EventHandler(this.btReset_Click);
			this.MyDataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		private void setvisiblecontrol(bool Visibile)
		{
			GridTitle1.VisibleRecord=Visibile;
			GridTitle1.hplsNuovo.Visible =false;
			MyDataGrid1.Visible = Visibile;
		}
		private void S_btMostra_Click(object sender, System.EventArgs e)
		{
			MyDataGrid1.CurrentPageIndex = 0;
			Execute();
		}


		public void imagebutton1_Click(Object sender , CommandEventArgs e)
		{
			string[] a_appoggio1;
			string[] a_appoggio =e.CommandArgument.ToString().Split(Convert.ToChar("="));
			string s_bl_id=a_appoggio[1];
			a_appoggio1=a_appoggio[0].ToString().Split(Convert.ToChar("&"));
			string s_stanza=a_appoggio1[0];

			string[] appo= a_appoggio[2].Split('&');
			string s_piano =appo[0];
			string TitoloStanza= a_appoggio[3];
                		

			_myColl.AddControl(this.Page.Controls, ParentType.Page);
			Server.Transfer("NavigazioneAppDEMO.aspx?var_stanza="+s_stanza+"&var_bl_id="+s_bl_id+ "&var_piani="+s_piano+"&TitoloStanza=" + TitoloStanza+ "&FunId=" + FunId); 
		}

		public void imagebutton2_Click(Object sender , CommandEventArgs e)
		{
			string[] a_appoggio1;
			string[] a_appoggio =e.CommandArgument.ToString().Split(Convert.ToChar("="));
			string s_bl_id=a_appoggio[1];
			a_appoggio1=a_appoggio[0].ToString().Split(Convert.ToChar("&"));
			string s_piani=a_appoggio1[0];
			string TitoloPiano= a_appoggio[2];
			_myColl.AddControl(this.Page.Controls, ParentType.Page);
			string url ="NavigazioneAppDEMO.aspx?var_piani="+s_piani+"&var_bl_id="+s_bl_id+"&TitoloPiano="+TitoloPiano;
			Server.Transfer(url); 
		}


		#region Caricamento Combo

		private void BindTuttiPiani()
		{
		  	this.cmbsPiano.Items.Clear();
		
			WebCad.Classi.ClassiAnagrafiche.Buildings  _Buildings = new WebCad.Classi.ClassiAnagrafiche.Buildings();
			
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

		private void BindPiano(string CodEdificio)
		{
		  	
			this.cmbsPiano.Items.Clear();
		
			WebCad.Classi.ManOrdinaria.Richiesta  _Richiesta = new WebCad.Classi.ManOrdinaria.Richiesta();
			
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
		}

//		private void BindStanza()
//		{
//			this.cmbsStanza.Items.Clear();
//
//			TheSite.Classi.ManOrdinaria.Richiesta  _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
//			int bl_id=(RicercaModulo1.Idbl=="")?0:int.Parse(RicercaModulo1.Idbl);
//			int Piano=(cmbsPiano.SelectedValue=="")?0:int.Parse(cmbsPiano.SelectedValue); 
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
//			
//		}
		#endregion



		#region Sezione dedicata al riempimento del DataGrid

		private void Execute()
		{		
			S_Controls.Collections.S_Object s_p_bl_id = new S_Controls.Collections.S_Object();
			s_p_bl_id.ParameterName = "p_Bl_Id";
			s_p_bl_id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_bl_id.Direction = ParameterDirection.Input;
			s_p_bl_id.Size =50;
			s_p_bl_id.Index = 1;
			if (RicercaModulo1.TxtCodice.Text == string.Empty)
				s_p_bl_id.Value = DBNull.Value;
			else
                s_p_bl_id.Value = RicercaModulo1.TxtCodice.Text;
			_SCollection.Add(s_p_bl_id);

	
			S_Controls.Collections.S_Object s_p_id_piani = new S_Controls.Collections.S_Object();
			s_p_id_piani.ParameterName = "p_piani";
			s_p_id_piani.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_id_piani.Direction = ParameterDirection.Input;
			s_p_id_piani.Size=10;
			s_p_id_piani.Index = 2;
			if (cmbsPiano.SelectedValue=="")
				s_p_id_piani.Value=-1;
			else
				s_p_id_piani.Value = Int32.Parse(cmbsPiano.SelectedValue);
			_SCollection.Add(s_p_id_piani);

			S_Controls.Collections.S_Object s_p_id_room = new S_Controls.Collections.S_Object();
			s_p_id_room.ParameterName = "p_rm";
			s_p_id_room.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_id_room.Direction = ParameterDirection.Input;
			s_p_id_room.Size=10;
			s_p_id_room.Index =3;
			s_p_id_room.Value = UserStanze1.DescStanza;
			_SCollection.Add(s_p_id_room);	

			S_Controls.Collections.S_Object s_p_id_servizio = new S_Controls.Collections.S_Object();
			s_p_id_servizio.ParameterName = "p_idservizio";
			s_p_id_servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_id_servizio.Direction = ParameterDirection.Input;
			s_p_id_servizio.Size=10;
			s_p_id_servizio.Index =4;
			if (cmbsServizio.SelectedValue=="")
				s_p_id_servizio.Value=-1;
			else
				s_p_id_servizio.Value = Int32.Parse(cmbsServizio.SelectedValue);
			_SCollection.Add(s_p_id_servizio);	

			S_Controls.Collections.S_Object s_p_id_codappar = new S_Controls.Collections.S_Object();
			s_p_id_codappar.ParameterName = "p_idcodappar";
			s_p_id_codappar.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_id_codappar.Direction = ParameterDirection.Input;
			s_p_id_codappar.Size=10;
			s_p_id_codappar.Index =5;
			if (CodiceApparecchiature1.CodiceHidden.Value=="")
				s_p_id_codappar.Value=-1;
			else
				s_p_id_codappar.Value = Int32.Parse(CodiceApparecchiature1.CodiceHidden.Value);
			_SCollection.Add(s_p_id_codappar);	
			
			///La stored procedure cambia in base alla scelta del Standard Apparecchiatura
			//if (cmbsApparecchiatura.SelectedValue==""||cmbsApparecchiatura.SelectedValue==string.Empty)			
			//					Ds=_DataRoom.RicercaDataRoom(_SCollection);
			//				else
		    //					{
								S_Controls.Collections.S_Object s_eqstd = new S_Controls.Collections.S_Object();
								s_eqstd.ParameterName = "p_eqstd";
								s_eqstd.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
								s_eqstd.Direction = ParameterDirection.Input;
								s_eqstd.Size=255;
								s_eqstd.Index =6;
			                    if (cmbsApparecchiatura.SelectedValue=="")
				                    s_eqstd.Value=-1;
			                    else
				                    s_eqstd.Value = Int32.Parse(cmbsApparecchiatura.SelectedValue);
								_SCollection.Add(s_eqstd);
								Ds=_DataRoom.RicercaDataRoomSTD(_SCollection);
			//				}
//			if (CodiceStdApparecchiatura1.CodiceStd==""||CodiceStdApparecchiatura1.CodiceStd==string.Empty)			
//				Ds=_DataRoom.RicercaDataRoom(_SCollection);
//			else
//			{
//				S_Controls.Collections.S_Object s_eqstd = new S_Controls.Collections.S_Object();
//				s_eqstd.ParameterName = "p_eqstd";
//				s_eqstd.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
//				s_eqstd.Direction = ParameterDirection.Input;
//				s_eqstd.Size=255;
//				s_eqstd.Index =4;
//				s_eqstd.Value = (CodiceStdApparecchiatura1.CodiceHidden.Value);
//				_SCollection.Add(s_eqstd);
//				Ds=_DataRoom.RicercaDataRoomSTD(_SCollection);
//			}
			GridTitle1.Visible = true;
			if (Ds.Tables[0].Rows.Count > 0) 
			{
				setvisiblecontrol(true);
				GridTitle1.DescriptionTitle="";
				GridTitle1.NumeroRecords =Ds.Tables[0].Rows.Count.ToString();
				MyDataGrid1.DataSource= Ds;
				MyDataGrid1.DataBind();
			}
			else
			{
				GridTitle1.DescriptionTitle="Nessun dato trovato.";
				setvisiblecontrol(false);
			}
		}

		#endregion

		private void btReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("DataRoom.aspx?FunId=" + FunId); 
		}

		
		private void MyDataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			MyDataGrid1.CurrentPageIndex=e.NewPageIndex;
			Execute();
		}
		private void BindServizio(string CodEdificio)
		{
			
			this.cmbsServizio.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			WebCad.Classi.ClassiDettaglio.Servizi  _Servizio = new WebCad.Classi.ClassiDettaglio.Servizi(Context.User.Identity.Name);

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
		
			Classi.AnagrafeImpianti.Apparecchiature  _Apparecchiature = new WebCad.Classi.AnagrafeImpianti.Apparecchiature(Context.User.Identity.Name);
			
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

		private void cmbsServizio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//BindApparecchiatura();
		}
		private string IDBL
		{
			get{return hiddenblid.Value;}
			set{hiddenblid.Value =value;}
		}

	}
}
