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
using ApplicationDataLayer.DBType;
using MyCollection;
using System.Reflection;
 
namespace TheSite.ManutenzioneProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per CompletamentoMP.
	/// </summary>
	public class CompletamentoMP : System.Web.UI.Page
	{
		protected S_Controls.S_TextBox txtsRichiesta;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_ComboBox cmbsMeseDa;
		protected S_Controls.S_ComboBox cmbsAnnoDa;
		protected S_Controls.S_ComboBox cmbsAnnoA;
		protected S_Controls.S_ComboBox cmbsDitta;
		protected S_Controls.S_ComboBox cmbsMeseA;
		
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;
		public static int FunId = 0;		
		protected WebControls.RicercaModulo RicercaModulo1;		
		protected WebControls.CalendarPicker CalendarPicker1;		
		protected WebControls.Addetti Addetti1;
		protected S_Controls.S_Button btnsCompletaOdl;
		protected S_Controls.S_Button btnsModificaODL;
		protected Csy.WebControls.DataPanel DatapanelCompleta;
		protected S_Controls.S_ComboBox cmbsAddettoCompl;
		protected S_Controls.S_ComboBox cmbsAddettoMod;		
		public static string HelpLink = string.Empty;

		MyCollection.clMyCollection _myColl = new clMyCollection();
		protected S_Controls.S_Button btnSChiudi;
		protected System.Web.UI.WebControls.Button cmdReset;		
		Completamento_MP_WRList _fp;

		public MyCollection.clMyCollection _Contenitore
		{
			get 
			{
				return _myColl;
			}
		}
		public MyCollection.clMyCollection _ContenitoreSfoglia
		{
			get 
			{
				if(this.ViewState["mioContenitore"]!=null)
					return (MyCollection.clMyCollection)this.ViewState["mioContenitore"];
				else
					return new MyCollection.clMyCollection();
			}
		}

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			
			this.btnsModificaODL.Visible = _SiteModule.IsEditable;												
			this.btnsCompletaOdl.Visible = _SiteModule.IsEditable;															

			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			this.GridTitle1.hplsNuovo.Visible = false;
			
			this.txtsRichiesta.Attributes.Add("onkeypress","ControllaCaratteri();");
			this.btnsRicerca.Attributes.Add("onclick","Valorizza('0')");
			this.btnsCompletaOdl.Attributes.Add("onclick","Valorizza('1')");
			this.btnsModificaODL.Attributes.Add("onclick","Valorizza('2')");
			this.Addetti1.btnAddetto.Attributes.Add("onclick","Valorizza('2')");


//			string FunzCompl = "ControllaAddetto('" + this.cmbsAddettoCompl.ClientID+"','" + btnsCompletaOdl.ClientID+ "');";
//			string FunzMod = "ControllaAddetto('" + this.cmbsAddettoMod.ClientID+"','" + btnsModificaODL.ClientID+ "');";
//			
//			this.cmbsAddettoCompl.Attributes.Add("onchange",FunzCompl);
//			this.cmbsAddettoMod.Attributes.Add("onchange",FunzMod);
//ControllaData()
//			System.Text.StringBuilder sbValidApprova = new System.Text.StringBuilder();
//			sbValidApprova.Append("this.disabled = true;");
//			sbValidApprova.Append("if (typeof(ControllaData) == 'function') { ");
//			sbValidApprova.Append("if (ControllaData() == false) { return false; }} ");
//			sbValidApprova.Append("document.getElementById('" + btnsCompletaOdl.ClientID + "').disabled = true;");
//			sbValidApprova.Append(this.Page.GetPostBackEventReference(this.btnsCompletaOdl));
//			this.sbValidApprova.Append(";");
//			this.btnsCompletaOdl.Attributes.Add("onclick",sbValidApprova.ToString());

			String scriptString = "<script language=JavaScript>var dettaglio;\n";
			scriptString += "function chiudi() {\n";			
			scriptString += "if (dettaglio!=null)";
			scriptString += "if (document.Form1.hidRicerca.value=='0'){";
			scriptString += " dettaglio.close();}";
			scriptString += " else{";
			scriptString += "document.Form1.hidRicerca.value='1';}}<";
			scriptString += "/";
			scriptString += "script>";

			if(!this.IsClientScriptBlockRegistered("clientScript"))
				this.RegisterClientScriptBlock("clientScript", scriptString);

			RicercaModulo1.DelegateCodiceEdificio1 = new TheSite.WebControls.DelegateCodiceEdificio(this.BindServizi);
						
			if (!Page.IsPostBack)
			{
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];
				BindControls();				
				if(Context.Handler is TheSite.ManutenzioneProgrammata.Completamento_MP_WRList)
				{
					_fp = (TheSite.ManutenzioneProgrammata.Completamento_MP_WRList)Context.Handler;
					if (_fp!=null) 
					{
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);		
						Ricerca();
					}
				}	
				
				
				if(Request.QueryString["id_wo"]!=null)
				{
					btnSChiudi.Visible=true;
					Ricerca(Int32.Parse(Request.QueryString["id_wo"]));	
					#region Recupero la proprieta di ricerca
					// Recupero il tipo dall'oggetto context.
					Type myType=Context.Handler.GetType();       
					// recupero il PropertyInfo object passando il nome della proprietà da recuperare.
					PropertyInfo myPropInfo = myType.GetProperty("_Contenitore");
			
					// verifico che questa proprietà esista.
					if(myPropInfo!=null)
						this.ViewState.Add("mioContenitore",myPropInfo.GetValue(Context.Handler,null));

					#endregion
		
				}
				else
				{
					btnSChiudi.Visible=false;
				}

				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				Session.Remove("CheckedListMP");
			}		
		}

		#region FunzioniPrivate
		
		public void LinkWR(Object sender, EventArgs e)
		{
			_myColl.AddControl(this.Page.Controls, ParentType.Page);
			string s_url = "Completamento_MP_WRList.aspx";							
			Server.Transfer(s_url);				
		}
		private void BindControls()
		{
			CaricaCombiAnni();
			BindServizi("");			
		}
		private void CaricaCombiAnni()
		{
			string anno_corrente = DateTime.Now.Year.ToString();
			for (int i = 1950; i <= 2051; i++)
			{ 	
				ListItem _L1 = new ListItem();
				ListItem _L2 = new ListItem();
			    _L1.Text=i.ToString();
				_L1.Value=i.ToString();
				_L2.Text=i.ToString();
				_L2.Value=i.ToString();
				cmbsAnnoA.Items.Add(_L1);
				cmbsAnnoDa.Items.Add(_L2);
			}

			cmbsAnnoA.SelectedValue=anno_corrente;
			cmbsAnnoDa.SelectedValue=anno_corrente;
		}

		private void BindAddetti(string idbl)
		{
			int id_ditta=0;
			if (cmbsDitta.SelectedValue!="")
			{
				id_ditta=Int32.Parse(cmbsDitta.SelectedValue);
			}			
			// Carico Gli Addetti			
			Addetti1.Set_BL_ID_DITTA_ID(idbl,id_ditta);
		}

		private void CaricaDitte()
		{	
			int id_bl=0;
			string bl_id= RicercaModulo1.TxtCodice.Text;
			// Carico Le Ditte
			if (bl_id !="")
			{				
				// Mi recupero l'idbl
				DataSet _MyDsDittaBl;
				Classi.Function _Fun = new TheSite.Classi.Function();
				_MyDsDittaBl= _Fun.GetIdBL(bl_id);								
				DataRow _DrBl = _MyDsDittaBl.Tables[0].Rows[0];
				id_bl= Int32.Parse(_DrBl[0].ToString());			
				BindDitte(id_bl);
			}
			else
			{
				id_bl=0;
				BindDitte(id_bl);
			}
		}

		private void BindServizi(string CodEdificio)
		{	
			CaricaDitte();
			BindAddetti(CodEdificio);

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
				this.cmbsServizio.DataSource =_MyDs.Tables[0];
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

		private void BindDitte(int idbl)
		{	
			cmbsDitta.Items.Clear();			
			
			Classi.ClassiAnagrafiche.Ditte _Ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
			// Attraverso l'IDBL mi ricavo l'ID della Ditta
			int idditta=0;
			if(idbl>0)
			{
				DataSet _MyDsDittaBl;
				_MyDsDittaBl=_Ditte.GetDittaBl(idbl);			
				DataRow _DrBl = _MyDsDittaBl.Tables[0].Rows[0];
				idditta= Int32.Parse(_DrBl["id_ditta"].ToString());			
			}
			else
			{
				idditta=0;
			}			
		
			DataSet _MyDs;
			_MyDs = _Ditte.GetDitteFornitoriRuoli(idditta);

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsDitta.DataSource = _MyDs.Tables[0];
				this.cmbsDitta.DataTextField = "DESCRIZIONE";
				this.cmbsDitta.DataValueField = "id";
				this.cmbsDitta.DataBind();
			}
			
			else
			{
				string s_Messagggio = "- Nessuna Ditta  -";
				this.cmbsDitta.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		private void BindAddettiDitta(string bl_id,int ditta_id)
		{	
			this.cmbsAddettoMod.Items.Clear();	
			this.cmbsAddettoCompl.Items.Clear();								
			
			Classi.ManOrdinaria.Richiesta  _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
			DataSet _MyDs;

			_MyDs = _Richiesta.GetAddetti("",bl_id,ditta_id);
			

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsAddettoMod.DataSource = _MyDs.Tables[0];
				this.cmbsAddettoMod.DataTextField = "NOMINATIVO";
				this.cmbsAddettoMod.DataValueField = "ID";				
				this.cmbsAddettoMod.DataBind();
				//--------------------------------------------------//
				this.cmbsAddettoCompl.DataSource = _MyDs.Tables[0];
				this.cmbsAddettoCompl.DataTextField = "NOMINATIVO";
				this.cmbsAddettoCompl.DataValueField = "ID";				
				this.cmbsAddettoCompl.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Addetto  -";
				this.cmbsAddettoMod.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, ""));
				this.cmbsAddettoCompl.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, ""));
			}
		
		}
		
		private void Ricerca()
		{	
			txtsRichiesta.DBDefaultValue="0";
			cmbsDitta.DBDefaultValue="0";
			cmbsServizio.DBDefaultValue="0";
			
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();
			
			
			// Tipo Manutenzione
			S_Controls.Collections.S_Object s_TipoManutenzione = new S_Object();

			s_TipoManutenzione.ParameterName = "p_TipoManutenzione";
			s_TipoManutenzione.DbType = CustomDBType.Integer;
			s_TipoManutenzione.Direction = ParameterDirection.Input;
			s_TipoManutenzione.Index = 0;
			s_TipoManutenzione.Size=4;
			s_TipoManutenzione.Value=Classi.TipoManutenzioneType.ManutenzioneProgrammata;						
			CollezioneControlli.Add(s_TipoManutenzione);				

			// Data Da						
			int giornoDA = 1;
			int meseDA = Int16.Parse(cmbsMeseDa.SelectedValue);			
			int annoDA = Int16.Parse(cmbsAnnoDa.SelectedValue);			
			string dataDA = giornoDA + "/" + meseDA + "/" + annoDA;

			S_Controls.Collections.S_Object s_AnnoDa = new S_Object();

			s_AnnoDa.ParameterName = "p_AnnoDa";
			s_AnnoDa.DbType = CustomDBType.VarChar;
			s_AnnoDa.Direction = ParameterDirection.Input;
			s_AnnoDa.Index = 1;
			s_AnnoDa.Size=10;
			s_AnnoDa.Value=dataDA;
			CollezioneControlli.Add(s_AnnoDa);					

			// Data A						
			
			int giornoA = DateTime.DaysInMonth(Int16.Parse(cmbsAnnoA.SelectedValue),Int16.Parse(cmbsMeseA.SelectedValue));			
			int meseA = Int16.Parse(cmbsMeseA.SelectedValue);			
			int annoA = Int16.Parse(cmbsAnnoA.SelectedValue);	
			string dataA = giornoA + "/" + meseA + "/" + annoA;


			S_Controls.Collections.S_Object s_AnnoA = new S_Object();

			s_AnnoA.ParameterName = "p_AnnoA";
			s_AnnoA.DbType = CustomDBType.VarChar;
			s_AnnoA.Direction = ParameterDirection.Input;
			s_AnnoA.Index = 2;
			s_AnnoA.Size=10;
			s_AnnoA.Value=dataA;
			CollezioneControlli.Add(s_AnnoA);				
			
			// Ditta						
			int id_ditta=0;
			if(cmbsDitta.SelectedValue!="")
				id_ditta=Int32.Parse(cmbsDitta.SelectedValue);
			
			S_Controls.Collections.S_Object s_Ditta = new S_Object();

			s_Ditta.ParameterName = "p_Ditta";
			s_Ditta.DbType = CustomDBType.Integer;
			s_Ditta.Direction = ParameterDirection.Input;
			s_Ditta.Index = 3;
			s_Ditta.Size=4;
			s_Ditta.Value=id_ditta;
			CollezioneControlli.Add(s_Ditta);				

			// Servizio						
			int id_servizio=0;
			if(cmbsServizio.SelectedValue!="")
				id_servizio=Int32.Parse(cmbsServizio.SelectedValue);
			
			S_Controls.Collections.S_Object s_Servizio = new S_Object();

			s_Servizio.ParameterName = "p_Servizio";
			s_Servizio.DbType = CustomDBType.Integer;
			s_Servizio.Direction = ParameterDirection.Input;
			s_Servizio.Index = 4;
			s_Servizio.Size=4;
			s_Servizio.Value=id_servizio;
			CollezioneControlli.Add(s_Servizio);

			// WO_ID						
			int id_wo=0;
			if(txtsRichiesta.Text.Trim()!="")
				id_wo=Int32.Parse(txtsRichiesta.Text.Trim());
			
			S_Controls.Collections.S_Object s_WO_ID = new S_Object();

			s_WO_ID.ParameterName = "p_Wo_Id";
			s_WO_ID.DbType = CustomDBType.Integer;
			s_WO_ID.Direction = ParameterDirection.Input;
			s_WO_ID.Index = 5;
			s_WO_ID.Size=4;
			s_WO_ID.Value=id_wo;
			CollezioneControlli.Add(s_WO_ID);

			// BL_ID						
			
			S_Controls.Collections.S_Object s_BL = new S_Object();

			s_BL.ParameterName = "p_Id_Bl";
			s_BL.DbType = CustomDBType.VarChar;
			s_BL.Direction = ParameterDirection.Input;
			s_BL.Index = 6;
			s_BL.Size=20;
			s_BL.Value=RicercaModulo1.TxtCodice.Text.Trim();
			CollezioneControlli.Add(s_BL);

			// Addetto

			S_Controls.Collections.S_Object s_Addetto = new S_Object();

			s_Addetto.ParameterName = "p_Nome_Completo";
			s_Addetto.DbType = CustomDBType.VarChar;
			s_Addetto.Direction = ParameterDirection.Input;
			s_Addetto.Index = 7;
			s_Addetto.Size=4;
			s_Addetto.Value=Addetti1.NomeCompleto;
			CollezioneControlli.Add(s_Addetto);

			Classi.ManProgrammata.Completamento _Compl = new TheSite.Classi.ManProgrammata.Completamento();
						

			DataSet _MyDs = _Compl.GetData(CollezioneControlli).Copy();

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();
			if (_MyDs.Tables[0].Rows.Count>0)
			{
				DatapanelCompleta.Visible=true;
				//Imposto le combo degli addetti
				DataRow _DR = _MyDs.Tables[0].Rows[0];
				cmbsAddettoCompl.SelectedValue=_DR["id_addetto"].ToString();
				cmbsAddettoMod.SelectedValue=_DR["id_addetto"].ToString();
			}
			else
				DatapanelCompleta.Visible=false;
		}
 
		private void Ricerca(int wo_id)
		{	
			//PanelRicerca.Collapsed=true;
			DatapanelCompleta.Collapsed=false;
			
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();
			
			Classi.ManProgrammata.Completamento _Compl = new TheSite.Classi.ManProgrammata.Completamento();						

			DataSet _MyDs = _Compl.GetSingleData(wo_id).Copy();

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();
			
			if (_MyDs.Tables[0].Rows.Count>0)
			{
				DataRow _DR = _MyDs.Tables[0].Rows[0];
				
				//Imposto il Codice WO
				txtsRichiesta.Text = _DR["ID"].ToString();
				//Imposta la Ditta
				if(_DR["idditta"]!=null)
					cmbsDitta.SelectedValue = _DR["idditta"].ToString();				
				BindAddettiDitta(RicercaModulo1.BlId,Int32.Parse(cmbsDitta.SelectedValue));
				//Imposto il Codice Edificio
				RicercaModulo1.TxtCodice.Text=_DR["Edificio"].ToString();
				RicercaModulo1.Ricarica();
				//Imposto L'addetto
				Addetti1.NomeCompleto=_DR["Addetto"].ToString();
				//Carico la lista degli addetti
				BindAddetti(_DR["Edificio"].ToString());
				//Imposto le Combo degli Anni
				DateTime _Data=DateTime.Parse(_DR["DataPianificata"].ToString());
				cmbsAnnoA.SelectedValue=_Data.Year.ToString();
				cmbsAnnoDa.SelectedValue=_Data.Year.ToString();
				cmbsMeseA.SelectedValue=_Data.Month.ToString().PadLeft(2,Convert.ToChar("0"));
				cmbsMeseDa.SelectedValue=_Data.Month.ToString().PadLeft(2,Convert.ToChar("0"));
				//Imposto le combo degli addetti
				cmbsAddettoCompl.SelectedValue=_DR["id_addetto"].ToString();
				cmbsAddettoMod.SelectedValue=_DR["id_addetto"].ToString();
				DatapanelCompleta.Visible=true;				
			}
			else
				DatapanelCompleta.Visible=false;
		}


		private void MemorizzaCheck()
		{	
			Hashtable _HS = new Hashtable();
			foreach(DataGridItem o_Litem in this.DataGridRicerca.Items)
			{	
				int id = Int32.Parse(o_Litem.Cells[0].Text);
				if(Session["CheckedListMP"]!=null)
					_HS=(Hashtable) Session["CheckedListMP"];
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel");											
				if(_HS.ContainsKey(id))
					_HS.Remove(id);								
				_HS.Add(id,cb.Checked);
				Session.Remove("CheckedListMP");
				Session.Add("CheckedListMP",_HS);
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
			this.btnsRicerca.Click += new System.EventHandler(this.btnsRicerca_Click);
			this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.btnsCompletaOdl.Click += new System.EventHandler(this.btnsCompletaOdl_Click);
			this.btnsModificaODL.Click += new System.EventHandler(this.btnsModificaODL_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmbsDitta_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindAddetti(RicercaModulo1.TxtCodice.Text);			
		}

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			Session.Remove("CheckedListMP");
			DataGridRicerca.CurrentPageIndex=0;			
			BindAddettiDitta(RicercaModulo1.BlId,Int32.Parse(cmbsDitta.SelectedValue));
			Ricerca();
		}


		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{			
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{	
				//Formatto La data
				string _CampoData = e.Item.Cells[9].Text.Trim();
				if (_CampoData.Length > 0) 
				{					
					DateTime _Data = Convert.ToDateTime(e.Item.Cells[9].Text.Trim());
					string mese =  Classi.Function.ImpostaMese(_Data.Month,false);
					string anno = _Data.Year.ToString();
					e.Item.Cells[9].Text=mese + " - " + anno;
					e.Item.Cells[9].ToolTip=_CampoData;

				}
				//Visualizzo il tooltip delle WR legate alla WO
				Classi.Function _Fun = new TheSite.Classi.Function();
				int wo_id = Int16.Parse(e.Item.Cells[0].Text);
				DataSet _MyDsWr = _Fun.GetWRfromWO(wo_id);
				int tot_record = _MyDsWr.Tables[0].Rows.Count;
				if (tot_record>0)
				{					
					string mes_tooltip="Riferimento a RDL n°:";
					string wr_id="";
					int n=0;
					while (tot_record>n) 
					{
						wr_id = _MyDsWr.Tables[0].Rows[n]["wr_id"].ToString();						
						mes_tooltip += "\n" + wr_id;  						
						n++;
					}					
					e.Item.Cells[2].ToolTip=mes_tooltip;
				}			
				

				//RICECCO
				if(Session["CheckedListMP"]!=null)
				{	
					Hashtable _HS=(Hashtable) Session["CheckedListMP"];
					if(_HS.ContainsKey(wo_id))
					{						
						System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) e.Item.Cells[1].FindControl("ChkSel");																					
						cb.Checked=System.Boolean.Parse(_HS[wo_id].ToString());						
					}
				}
			}
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			MemorizzaCheck();
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;	
			Ricerca();				
		}


		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
		
			if (e.CommandName=="Dettaglio")
			{	
				_myColl.AddControl(this.Page.Controls, ParentType.Page);
				string s_url = e.CommandArgument.ToString()+"&FunID="+FunId;							
				Server.Transfer(s_url);				
			}

		}

		private void btnSChiudi_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("SfogliaOdlRdl.aspx?FunID="+FunId); 		
		}

		private void btnsCompletaOdl_Click(object sender, System.EventArgs e)
		{	
			MemorizzaCheck();
			int tot=0;
			Hashtable _HS = (Hashtable)Session["CheckedListMP"];
			IDictionaryEnumerator myEnumerator = _HS.GetEnumerator();																
			while (myEnumerator.MoveNext())
			{
				if ((bool)myEnumerator.Value)
				{
					tot++;	
				}
			}

			if (tot==0)
			{
				Classi.SiteJavaScript.msgBox(this.Page,"Nessuna RDL Selezionata.");
			}
			else
			{
				Classi.SiteJavaScript.WindowOpen(this.Page,0,"Completa_WO.aspx?addetto=" + cmbsAddettoCompl.SelectedValue+ "&data=" + CalendarPicker1.Datazione.Text ,800,600,"dettaglio");			
			}


		}

		private void btnsModificaODL_Click(object sender, System.EventArgs e)
		{
			MemorizzaCheck();
			int tot=0;
			Hashtable _HS = (Hashtable)Session["CheckedListMP"];
			IDictionaryEnumerator myEnumerator = _HS.GetEnumerator();																
			while (myEnumerator.MoveNext())
			{
				if ((bool)myEnumerator.Value)
				{
					tot++;	
				}
			}

			if (tot==0)
			{
				Classi.SiteJavaScript.msgBox(this.Page,"Nessuna RDL Selezionata.");
			}
			else
			{
				Classi.SiteJavaScript.WindowOpen(this.Page,0,"Aggiona_WO.aspx?addetto=" + cmbsAddettoMod.SelectedValue ,800,600,"dettaglio");
				//Classi.SiteJavaScript.WindowModeless(this.Page,0,"Aggiona_WO.aspx?addetto=" + cmbsAddettoMod.SelectedValue ,800,500);							
			}
 
		}

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("CompletamentoMP.aspx?FunID=" + ViewState["FunId"]);
		}

	}
}
