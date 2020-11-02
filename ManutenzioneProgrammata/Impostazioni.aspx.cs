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
	/// Descrizione di riepilogo per Impostazioni.
	/// </summary>
	/// 
	

	public class Impostazioni : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected S_Controls.S_ComboBox cmbsMeseA;
		protected S_Controls.S_ComboBox cmbsAnnoA;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_ComboBox cmbsDitta;
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.RicercaModulo RicercaModulo1;		
		protected WebControls.UserMeseGiorno UserMeseGiorno1;		
		protected WebControls.UserMeseGiorno UserMeseGiorno2;		
		protected WebControls.GridTitle GridTitle1;
		public static string HelpLink = string.Empty;
		protected WebControls.PageTitle PageTitle1;
		protected S_Controls.S_ComboBox cmbsAddettoMod;
		protected S_Controls.S_Button btnsSalva;
		protected System.Web.UI.WebControls.Panel PanelAddetto;
		protected S_Controls.S_ComboBox cmbsTutti;
		protected S_Controls.S_Button btnsSelezionaTutti;
		protected S_Controls.S_Button btnsConfermaSelezioni;
		protected System.Web.UI.WebControls.CheckBox chkAbilitaData;
		protected System.Web.UI.WebControls.Label LblElementiSelezionati;
		protected System.Web.UI.WebControls.TextBox txtTotSelezionati;
		protected S_Controls.S_Button btnsDeSelezionaTutti;
		protected System.Web.UI.WebControls.Button cmdReset;
		public static int FunId = 0;	

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			//Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			//FunId = _SiteModule.ModuleId;
			HelpLink = ""; //_SiteModule.HelpLink;
			this.PageTitle1.Title = "Impostazioni Iniziali"; // _SiteModule.ModuleTitle;
			this.GridTitle1.hplsNuovo.Visible = false;
					
			//Imposto la funzione client per caricare i giorno a tutti i combi del mese
			string funz = "ImpostaGiorni(this.value,'" + UserMeseGiorno2.cmbGiorni.ClientID + "')";			
			UserMeseGiorno2.cmbMesi.Attributes.Add("onchange",funz);
										
			//Imposto la funzione client per abilitare le combo della data
			funz="AbilitaData(this.name,'" + UserMeseGiorno2.cmbMesi.ClientID +"','"+UserMeseGiorno2.cmbGiorni.ClientID+"')";
			chkAbilitaData.Attributes.Add("onclick",funz);
			
			RicercaModulo1.DelegateCodiceEdificio1 = new TheSite.WebControls.DelegateCodiceEdificio(this.BindServizi);

			//Abilito o disabilito le combo della Data riferondomi al Check
			UserMeseGiorno2.cmbMesi.Enabled=chkAbilitaData.Checked;
			UserMeseGiorno2.cmbGiorni.Enabled=chkAbilitaData.Checked;

			//Imposto le funzioni client per non effettuare il PostBack
			this.btnsRicerca.Attributes.Add("onclick","Valorizza('0')");
			this.btnsConfermaSelezioni.Attributes.Add("onclick","Valorizza('0')");
			this.btnsSelezionaTutti.Attributes.Add("onclick","Valorizza('0')");
			this.btnsDeSelezionaTutti.Attributes.Add("onclick","Valorizza('0')");
			this.btnsSalva.Attributes.Add("onclick","Valorizza('1')");

			/*
			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			//sbValid.Append("if (typeof(seledificio) == 'function') { ");
			//sbValid.Append("if (seledificio() == false) { return false; }} ");
			sbValid.Append("this.value = 'Attendere ...';");
			sbValid.Append("this.disabled = true;");
			sbValid.Append("document.getElementById('" + btnsRicerca.ClientID + "').disabled = true;");
			sbValid.Append(this.Page.GetPostBackEventReference(this.btnsRicerca));
			sbValid.Append(";");
			this.btnsRicerca.Attributes.Add("onclick", sbValid.ToString());

			new System.Text.StringBuilder();			
			sbValid.Append("this.value = 'Attendere ...';");
			sbValid.Append("this.disabled = true;");
			sbValid.Append("document.getElementById('" + btnsSalva.ClientID + "').disabled = true;");
			sbValid.Append(this.Page.GetPostBackEventReference(this.btnsSalva));
			sbValid.Append(";");
			this.btnsSalva.Attributes.Add("onclick", sbValid.ToString());

			new System.Text.StringBuilder();			
			sbValid.Append("this.value = 'Attendere ...';");
			sbValid.Append("this.disabled = true;");
			sbValid.Append("document.getElementById('" + btnsConfermaSelezioni.ClientID + "').disabled = true;");
			sbValid.Append(this.Page.GetPostBackEventReference(this.btnsConfermaSelezioni));
			sbValid.Append(";");
			this.btnsConfermaSelezioni.Attributes.Add("onclick", sbValid.ToString());

			new System.Text.StringBuilder();			
			sbValid.Append("this.value = 'Attendere ...';");
			sbValid.Append("this.disabled = true;");
			sbValid.Append("document.getElementById('" + btnsSelezionaTutti.ClientID + "').disabled = true;");
			sbValid.Append(this.Page.GetPostBackEventReference(this.btnsSelezionaTutti));
			sbValid.Append(";");
			this.btnsSelezionaTutti.Attributes.Add("onclick", sbValid.ToString());

			new System.Text.StringBuilder();			
			sbValid.Append("this.value = 'Attendere ...';");
			sbValid.Append("this.disabled = true;");
			sbValid.Append("document.getElementById('" + btnsDeSelezionaTutti.ClientID + "').disabled = true;");
			sbValid.Append(this.Page.GetPostBackEventReference(this.btnsDeSelezionaTutti));
			sbValid.Append(";");
			this.btnsDeSelezionaTutti.Attributes.Add("onclick", sbValid.ToString());
			
			*/

			if (!Page.IsPostBack)
			{
				//Richiamo la funzione che imposta i giorni del mese in esame
				ImpostaGiorni(UserMeseGiorno2.cmbMesi.SelectedValue,UserMeseGiorno2.cmbGiorni);		
				
				
				LblElementiSelezionati.Text="Elementi Selezionati - 0 -";
				txtTotSelezionati.Text="0";
				
				BindControls();										
				
				Session.Remove("CheckedList");
				Session.Remove("DatiList");
				Session.Remove("DataSet");
			}			
		}
		#region  FunzioniPrivate
		private void ImpostaGiorni(string mese, S_Controls.S_ComboBox Giorni)
		{
			int maxgiorni=0;
			switch (mese)
			{		
				case "4":	//Aprile		
				case "6":	//Giugno		
				case "9":	//Settembre		
				case "11":	//Novembre		
					maxgiorni=30;
					break;
				case "2":		
					maxgiorni=28; //Febbraio	
					break;
				default:		
					maxgiorni=31;
					break;
			}
			
			Giorni.Items.Clear();
			

			for(int i=1;i<=maxgiorni;i++)
			{	
				ListItem _L = new ListItem(i.ToString(),i.ToString());
				Giorni.Items.Add(_L);
			}

		}

		private void BindControls()
		{	
			BindServizi("");	
		}

		private void BindServizi(string CodEdificio)
		{	
			CaricaDitte();			

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
				if(_MyDsDittaBl.Tables[0].Rows.Count>0)
				{
					DataRow _DrBl = _MyDsDittaBl.Tables[0].Rows[0];
					id_bl= Int32.Parse(_DrBl[0].ToString());			
					BindDitte(id_bl);					
				}
			}
			else
			{
				id_bl=0;
				BindDitte(id_bl);
			}
		}

		private void Ricerca()
		{	
			Session.Remove("DataSet");
			
			//DataGridRicerca
			cmbsDitta.DBDefaultValue="0";
			cmbsServizio.DBDefaultValue="0";
			
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();
			
			// Ditta						
			int id_ditta=0;
			if(cmbsDitta.SelectedValue!="")
				id_ditta=Int32.Parse(cmbsDitta.SelectedValue);
			
			S_Controls.Collections.S_Object s_Ditta = new S_Object();

			s_Ditta.ParameterName = "p_id_ditta";
			s_Ditta.DbType = CustomDBType.Integer;
			s_Ditta.Direction = ParameterDirection.Input;
			s_Ditta.Index = 0;
			s_Ditta.Size=4;
			s_Ditta.Value=id_ditta;
			CollezioneControlli.Add(s_Ditta);				

			// Servizio						
			int id_servizio=0;
			if(cmbsServizio.SelectedValue!="")
				id_servizio=Int32.Parse(cmbsServizio.SelectedValue);
			
			S_Controls.Collections.S_Object s_Servizio = new S_Object();

			s_Servizio.ParameterName = "p_id_servizio";
			s_Servizio.DbType = CustomDBType.Integer;
			s_Servizio.Direction = ParameterDirection.Input;
			s_Servizio.Index = 1;
			s_Servizio.Size=4;
			s_Servizio.Value=id_servizio;
			CollezioneControlli.Add(s_Servizio);

			// BL_ID						
			
			S_Controls.Collections.S_Object s_BL = new S_Object();

			s_BL.ParameterName = "p_cod_edificio";
			s_BL.DbType = CustomDBType.VarChar;
			s_BL.Direction = ParameterDirection.Input;
			s_BL.Index = 2;
			s_BL.Size=20;
			s_BL.Value=RicercaModulo1.TxtCodice.Text.Trim();
			CollezioneControlli.Add(s_BL);				
		
			// TIPOLOGIA
			
			S_Controls.Collections.S_Object s_Tipologia = new S_Object();

			s_Tipologia.ParameterName = "p_Tipologia";
			s_Tipologia.DbType = CustomDBType.Integer;
			s_Tipologia.Direction = ParameterDirection.Input;
			s_Tipologia.Index = 3;
			s_Tipologia.Size=20;
			s_Tipologia.Value=cmbsTutti.SelectedValue;
			CollezioneControlli.Add(s_Tipologia);						

			Classi.ManProgrammata.Impostazioni _Imp = new TheSite.Classi.ManProgrammata.Impostazioni();
				
			
			DataSet _MyDs = _Imp.GetImpostazioniDefault(CollezioneControlli).Copy();

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();
			
			if (_MyDs.Tables[0].Rows.Count>0)
			{	
				PanelAddetto.Visible=true;											
				Session.Add("DataSet",_MyDs.Tables[0]);
			}	
			else
			{
				PanelAddetto.Visible=false;					
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
				DataGridRicerca.CurrentPageIndex=0;		
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

			Classi.ManOrdinaria.Richiesta  _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
			DataSet _MyDs;

			_MyDs = _Richiesta.GetAddetti("",bl_id,ditta_id);
			

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsAddettoMod.DataSource = _MyDs.Tables[0];
				this.cmbsAddettoMod.DataTextField = "NOMINATIVO";
				this.cmbsAddettoMod.DataValueField = "ID";				
				this.cmbsAddettoMod.DataBind();				
			}
			else
			{
				string s_Messagggio = "- Nessun Addetto  -";
				this.cmbsAddettoMod.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, ""));				
			}
		
		}

		private void SetControlli()
		{			
			Classi.clMyDataGridCollection _cl = new TheSite.Classi.clMyDataGridCollection();
			
			Hashtable _HS = new Hashtable();
			if(Session["CheckedList"]!=null)
			{
				_HS=(Hashtable) Session["CheckedList"];				
			}
			_HS=_cl.SetControl(DataGridRicerca,_HS,DataGridRicerca.CurrentPageIndex);
			Session.Remove("CheckedList");
			Session.Add("CheckedList",_HS);	
		}
		
		private void GetControlli()
		{	
			Classi.clMyDataGridCollection _cl = new TheSite.Classi.clMyDataGridCollection();
			if(Session["CheckedList"]!=null)
			{	
				_cl.GetControl(DataGridRicerca,(Hashtable) Session["CheckedList"],DataGridRicerca.CurrentPageIndex);
			}
		}

		private void SetDati()
		{			
			
			Hashtable _HS = new Hashtable();
			
			if(Session["DatiList"]!=null)
			{
				_HS=(Hashtable) Session["DatiList"];				
			}

						
			foreach(DataGridItem o_Litem in DataGridRicerca.Items)
			{
				DataGridField _campi = new DataGridField();
			
				_campi.idbl=Int32.Parse(o_Litem.Cells[2].Text);				

				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel");																					
	
				if(_HS.ContainsKey(_campi.idbl))
					_HS.Remove(_campi.idbl);												
								
				System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label) o_Litem.Cells[7].FindControl("LblAddetto");																											
				
				if(cb.Checked)
				{
					_campi.idditta=Int32.Parse(o_Litem.Cells[3].Text);
					_campi.idservizio=Int32.Parse(o_Litem.Cells[5].Text);
			
					WebControls.UserMeseGiorno _UMG = (WebControls.UserMeseGiorno) o_Litem.Cells[9].FindControl("UserMeseGiorno1");		
					
					//Imposto tutti i combo delle date del datagrid con la data impostata
					if(chkAbilitaData.Checked)
					{
						_UMG.cmbMesi.SelectedValue=UserMeseGiorno2.cmbMesi.SelectedValue;
						ImpostaGiorni(_UMG.cmbMesi.SelectedValue,_UMG.cmbGiorni);
						_UMG.cmbGiorni.SelectedValue=UserMeseGiorno2.cmbGiorni.SelectedValue;
					}

					lbl.Text=cmbsAddettoMod.SelectedItem.Text;

					_campi.mesegiorno=_UMG.cmbMesi.SelectedValue.PadLeft(2,Convert.ToChar("0")) + _UMG.cmbGiorni.SelectedValue.PadLeft(2,Convert.ToChar("0"));
					_campi.idaddetto=Int32.Parse(cmbsAddettoMod.SelectedValue);
					_HS.Add(_campi.idbl,_campi);		
				}
				
				else
				{
					//Re-Imposto il valore di Default
					lbl.Text=o_Litem.Cells[10].Text;	
				}
			}			
			
			Session.Remove("DatiList");
			Session.Add("DatiList",_HS);			
			LblElementiSelezionati.Text="Elementi Selezionati - " + _HS.Count.ToString() + " -";
			txtTotSelezionati.Text=_HS.Count.ToString();
		}

		private void SetDati(bool val)
		{	
			Hashtable _HS = new Hashtable();
		
			if(Session["DatiList"]!=null)
			{
				_HS=(Hashtable) Session["DatiList"];				
			}

					
			foreach(DataGridItem o_Litem in DataGridRicerca.Items)
			{
				DataGridField _campi = new DataGridField();
		
				_campi.idbl=Int32.Parse(o_Litem.Cells[2].Text);									
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel");																									
				cb.Checked=val;
				if(_HS.ContainsKey(_campi.idbl))
					_HS.Remove(_campi.idbl);												
							
				if(cb.Checked)
				{
					_campi.idditta=Int32.Parse(o_Litem.Cells[3].Text);
					_campi.idservizio=Int32.Parse(o_Litem.Cells[5].Text);
		
					WebControls.UserMeseGiorno _UMG = (WebControls.UserMeseGiorno) o_Litem.Cells[9].FindControl("UserMeseGiorno1");		
				
					//Imposto tutti i combo delle date del datagrid con la data impostata
					if(chkAbilitaData.Checked)
					{
						_UMG.cmbMesi.SelectedValue=UserMeseGiorno2.cmbMesi.SelectedValue;
						ImpostaGiorni(_UMG.cmbMesi.SelectedValue,_UMG.cmbGiorni);
						_UMG.cmbGiorni.SelectedValue=UserMeseGiorno2.cmbGiorni.SelectedValue;
					}

					System.Web.UI.WebControls.Label lbl = (System.Web.UI.WebControls.Label) o_Litem.Cells[7].FindControl("LblAddetto");																											
					lbl.Text=cmbsAddettoMod.SelectedItem.Text;

					_campi.mesegiorno=_UMG.cmbMesi.SelectedValue.PadLeft(2,Convert.ToChar("0")) + _UMG.cmbGiorni.SelectedValue.PadLeft(2,Convert.ToChar("0"));
					_campi.idaddetto=Int32.Parse(cmbsAddettoMod.SelectedValue);	
					_HS.Add(_campi.idbl,_campi);		
				}
			}			
			
			Session.Remove("DatiList");
			Session.Add("DatiList",_HS);			
			LblElementiSelezionati.Text="Elementi Selezionati - " + _HS.Count.ToString() + " -";
			txtTotSelezionati.Text=_HS.Count.ToString();			
		}

		private void SelezionaTutti(bool val)
		{	
			if(!val)
			{
				Session.Remove("CheckedList");
				Session.Remove("DatiList");
				LblElementiSelezionati.Text="Elementi Selezionati - 0 -";
				txtTotSelezionati.Text="0";
			}
			else
			{				
				SetControlli();										
			}
			
			for(int Pagine = 0;Pagine<=DataGridRicerca.PageCount;Pagine++)
			{
	
				DataGridRicerca.DataSource=Session["DataSet"];
				DataGridRicerca.DataBind();
				DataGridRicerca.CurrentPageIndex=Pagine;									
							
				SetDati(val);
				
				if(val)
				{	
					SetControlli();				
				}
			}

			DataGridRicerca.CurrentPageIndex=0;
			DataGridRicerca.DataSource=Session["DataSet"];
			DataGridRicerca.DataBind();			
			GetControlli();						

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
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.btnsConfermaSelezioni.Click += new System.EventHandler(this.btnsConfermaSelezioni_Click);
			this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
			this.btnsSelezionaTutti.Click += new System.EventHandler(this.btnsSelezionaTutti_Click);
			this.btnsDeSelezionaTutti.Click += new System.EventHandler(this.btnsDeSelezionaTutti_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{			
			BindAddettiDitta("",Int32.Parse(cmbsDitta.SelectedValue));
			Resetta();
			Ricerca();
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{	
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;	
			Ricerca();
			GetControlli();		
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{	
				 
				//Imposto la funzione client per caricare i giorno a tutti i combi del mese
				WebControls.UserMeseGiorno _UMG = (WebControls.UserMeseGiorno) e.Item.Cells[9].FindControl("UserMeseGiorno1");		
				string funz = "ImpostaGiorni(this.value,'" + _UMG.cmbGiorni.ClientID + "')";			
				_UMG.cmbMesi.Attributes.Add("onchange",funz);
				
				// Controllo se sono già stati impostati il giorno ed il mese
				string mese_girono=e.Item.Cells[8].Text;
				if(HttpUtility.HtmlDecode(mese_girono).Trim() != "")
				{
					string mese =mese_girono.Substring(0,2);
					string giorno=mese_girono.Substring(2,2);	
					
					mese = Int16.Parse(mese).ToString();
					giorno = Int16.Parse(giorno).ToString();

					_UMG.cmbMesi.SelectedValue=mese;
					
					//Richiamo la funzione che imposta i giorni del mese in esame
					ImpostaGiorni(mese,_UMG.cmbGiorni);					
					
					_UMG.cmbGiorni.SelectedValue=giorno;	
				}
				else
				{
					ImpostaGiorni(_UMG.cmbMesi.SelectedValue,_UMG.cmbGiorni);					
				}

				// Controllo se sono già stato impostato l'addetto
				string addetto = e.Item.Cells[10].Text;
				if(HttpUtility.HtmlDecode(addetto).Trim() != "")
				{
					Label lbladdetto = (Label) e.Item.Cells[7].FindControl("LblAddetto");
					lbladdetto.Text=addetto;
				}
			}
		}

		private void btnsSalva_Click(object sender, System.EventArgs e)
		{	
			Classi.ManProgrammata.Impostazioni _Imp = new TheSite.Classi.ManProgrammata.Impostazioni();
			if(Session["DatiList"]!=null)
			{
				_Imp.beginTransaction();
				
				try
				{					
					Hashtable _HS = (Hashtable)Session["DatiList"];
					IDictionaryEnumerator myEnumerator = _HS.GetEnumerator();								
					string mesegiorno=String.Empty;
					if(chkAbilitaData.Checked)					
						mesegiorno=UserMeseGiorno2.cmbMesi.SelectedValue.PadLeft(2,Convert.ToChar("0")) + UserMeseGiorno2.cmbGiorni.SelectedValue.PadLeft(2,Convert.ToChar("0"));	
					
					while (myEnumerator.MoveNext())
					{
												
						S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();
						
						DataGridField _campi = (DataGridField) myEnumerator.Value;					
						
						// IDBL
						S_Controls.Collections.S_Object s_Idbl = new S_Object();
						s_Idbl.ParameterName = "p_idbl";
						s_Idbl.DbType = CustomDBType.Integer;
						s_Idbl.Direction = ParameterDirection.Input;
						s_Idbl.Index = 0;
						s_Idbl.Value = _campi.idbl;
						CollezioneControlli.Add(s_Idbl);
						// IDDITTA
						S_Controls.Collections.S_Object s_Idditta = new S_Object();
						s_Idditta.ParameterName = "p_idditta";
						s_Idditta.DbType = CustomDBType.Integer;
						s_Idditta.Direction = ParameterDirection.Input;
						s_Idditta.Index = 1;
						s_Idditta.Value = _campi.idditta;
						CollezioneControlli.Add(s_Idditta);
						// IDSERVIZIO
						S_Controls.Collections.S_Object s_IdServizio = new S_Object();
						s_IdServizio.ParameterName = "p_idservizio";
						s_IdServizio.DbType = CustomDBType.Integer;
						s_IdServizio.Direction = ParameterDirection.Input;
						s_IdServizio.Index = 2;
						s_IdServizio.Value = _campi.idservizio;
						CollezioneControlli.Add(s_IdServizio);
						// IDADDETTO
						S_Controls.Collections.S_Object s_IdAddetto = new S_Object();
						s_IdAddetto.ParameterName = "p_idaddetto";
						s_IdAddetto.DbType = CustomDBType.Integer;
						s_IdAddetto.Direction = ParameterDirection.Input;
						s_IdAddetto.Index = 3;						
						s_IdAddetto.Value = _campi.idaddetto;
						CollezioneControlli.Add(s_IdAddetto);
						// DATA
						S_Controls.Collections.S_Object s_Data = new S_Object();
						s_Data.ParameterName = "p_data";
						s_Data.DbType = CustomDBType.VarChar;
						s_Data.Direction = ParameterDirection.Input;
						s_Data.Index = 4;					
						s_Data.Value = _campi.mesegiorno;																	
						CollezioneControlli.Add(s_Data);
						
						if (cmbsTutti.SelectedValue=="1")
							_Imp.Add(CollezioneControlli);
						else
							_Imp.Update(CollezioneControlli,_campi.idbl);
					}
					_Imp.commitTransaction();
					
					// Visualizzo la stringa del messaggio di conferma AGGIORNAMENTO nel DB
					string mes="";
					string tot=txtTotSelezionati.Text;
					if (cmbsTutti.SelectedValue=="2")
						mes="Sono stati modificati " + tot + " Edifici nel Piano di Manutenzione";	
					else
						mes="Sono stati inseriti " + tot + " Edifici nel Piano di Manutenzione";	
					
					Resetta();					
					Ricerca();										
					
					//Visualizzo il messaggio
					Classi.SiteJavaScript.msgBox(this.Page,mes);

				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message); 
					_Imp.rollbackTransaction(); 
				}
			}
			else
			{
				//Classi.SiteJavaScript.msgBox(this.Page,"Nessun Edificio selezionato.");
			}
		}

		private void btnsConfermaSelezioni_Click(object sender, System.EventArgs e)
		{
			SetDati();
			SetControlli();			
		}
		private void Resetta()
		{
			// Resetto tutti i valori ed entro nella Modifica
			DataGridRicerca.CurrentPageIndex=0;			
			LblElementiSelezionati.Text="Elementi Selezionati - 0 -";
			txtTotSelezionati.Text="0";
			Session.Remove("CheckedList");
			Session.Remove("DatiList");
			chkAbilitaData.Checked=false;
			UserMeseGiorno2.cmbGiorni.SelectedValue="1";
			UserMeseGiorno2.cmbMesi.SelectedValue="1";
			UserMeseGiorno2.cmbGiorni.Enabled=false;
			UserMeseGiorno2.cmbMesi.Enabled=false;
		}

		private void btnsSelezionaTutti_Click(object sender, System.EventArgs e)
		{
			SelezionaTutti(true);
		}

		private void btnsDeSelezionaTutti_Click(object sender, System.EventArgs e)
		{
			SelezionaTutti(false);
		}

		
		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Impostazioni.aspx?FunId="+FunId);
		}
		
	}
	public class DataGridField
	{				
		public int idbl;
		public int idditta;
		public int idservizio;
		public int idaddetto;
		public string mesegiorno;
	}
	// contenitore dati per il file "ManCorrettiva/SfogliaRdlComplete"
	public class DGridRdlComplete
	{
		public int WrId;
		public int OdlId;
		public string impianto;
		public string addetto;
		public string stato;
		public string tipoInt;
		public string impStimato;
		public string impConsuntivo;

	}
}
