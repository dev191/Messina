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
	/// Descrizione di riepilogo per CreaPianoMP.
	/// </summary>
	public class CreaOttimizzaRDL_MP : System.Web.UI.Page
	{
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected WebControls.GridTitle GridTitle1;	

		public static string HelpLink = string.Empty;
		//protected S_Controls.S_ComboBox cmbsAddettoCompl;
		//protected S_Controls.S_Button btnsCompletaOdl;
		//protected S_Controls.S_ComboBox cmbsAddettoMod;
		//protected S_Controls.S_Button btnsModificaODL;
		//protected S_Controls.S_Button btnSChiudi;
		//protected Csy.WebControls.DataPanel DatapanelCompleta;
		protected S_Controls.S_Button btnsCrea;
		protected S_Controls.S_Button btnsSelezionaTutti;
		protected S_Controls.S_Button btnsDeSelezionaTutti;
		protected S_Controls.S_Button btnsConfermaSelezioni;
		protected System.Web.UI.WebControls.Label LblElementiSelezionati;
		protected System.Web.UI.WebControls.TextBox txtTotSelezionati;
		protected WebControls.PageTitle PageTitle1;
		protected S_Controls.S_ComboBox cmbsEdificio;
		protected S_Controls.S_ComboBox cmbsComune;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected S_Controls.S_ComboBox cmbsAnno;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected System.Web.UI.WebControls.Panel PanelCrea;	
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			//RicercaModulo1.DelegateCodiceEdificio1 = new TheSite.WebControls.DelegateCodiceEdificio(this.BindServizi);
			
			//Imposto le funzioni client per non effettuare il PostBack
			this.btnsRicerca.Attributes.Add("onclick","Valorizza('0')");
			this.btnsConfermaSelezioni.Attributes.Add("onclick","Valorizza('0')");
			this.btnsSelezionaTutti.Attributes.Add("onclick","Valorizza('0')");
			this.btnsDeSelezionaTutti.Attributes.Add("onclick","Valorizza('0')");
			this.btnsCrea.Attributes.Add("onclick","Valorizza('1')");

			//FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = "Emetti Richieste di Lavoro";
			this.GridTitle1.hplsNuovo.Visible = false;

			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();			
			sbValid.Append("this.value = 'Attendere ...';");
			sbValid.Append("this.disabled = true;");
			sbValid.Append("document.getElementById('" + btnsRicerca.ClientID + "').disabled = true;");
			sbValid.Append(this.Page.GetPostBackEventReference(this.btnsRicerca));
			sbValid.Append(";");
			this.btnsRicerca.Attributes.Add("onclick", sbValid.ToString());

			sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsComune.ClientID + "').disabled = true;");
			this.cmbsAnno.Attributes.Add("onchange", sbValid.ToString());

			sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsEdificio.ClientID + "').disabled = true;");
			this.cmbsComune.Attributes.Add("onchange", sbValid.ToString());

			sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsServizio.ClientID + "').disabled = true;");
			this.cmbsEdificio.Attributes.Add("onchange", sbValid.ToString());

			new System.Text.StringBuilder();			
			sbValid.Append("this.value = 'Attendere ...';");
			sbValid.Append("this.disabled = true;");
			sbValid.Append("document.getElementById('" + btnsCrea.ClientID + "').disabled = true;");
			sbValid.Append(this.Page.GetPostBackEventReference(this.btnsCrea));
			sbValid.Append(";");
			this.btnsCrea.Attributes.Add("onclick", sbValid.ToString());

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

			if (!Page.IsPostBack)
			{	
				CaricaCombiAnni();
				BindControls();														
				LblElementiSelezionati.Text="Elementi Selezionati - 0 -";
				txtTotSelezionati.Text="0";				
				//BindControls();		
				Session.Remove("CheckedList");
				Session.Remove("DatiList");
				Session.Remove("DataSet");			
			}		
		}

		#region Funzioni Private

		private void CaricaCombiAnni()
		{
			string anno_corrente = DateTime.Now.Year.ToString();
//			for (int i = 1999; i <= 2099; i++)
//			{ 	
//				ListItem _L1 = new ListItem();
//				ListItem _L2 = new ListItem();
//				_L1.Text=i.ToString();
//				_L1.Value=i.ToString();
//				_L2.Text=i.ToString();
//				_L2.Value=i.ToString();
//				cmbsAnnoA.Items.Add(_L1);				
//			}
		
			cmbsAnno.SelectedValue=anno_corrente;
		}
		
		private void BindControls()
		{
			//BindServizi("");
			BindComuni(int.Parse(cmbsAnno.SelectedValue));
			BindEdifici(int.Parse(cmbsAnno.SelectedValue),0);
			BindServizi(int.Parse(cmbsAnno.SelectedValue),0,0);
		}
	
		private void BindComuni(int anno)
		{	
			this.cmbsComune.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ManProgrammata.CreaOttimizzaRDL_MP  _creaRDL = new TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP();

			DataSet _MyDs;
			_MyDs = _creaRDL.GetComuni(anno);
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{	
				this.cmbsComune.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "COMUNE", "IDCOMUNE", "-- Selezionare un Comune --", "0");
				this.cmbsComune.DataTextField = "COMUNE";
				this.cmbsComune.DataValueField = "IDCOMUNE";
				this.cmbsComune.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Comune -";
				this.cmbsComune.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0"));
			}
		}

		private void BindEdifici(int anno, int id_comune)
		{	
			this.cmbsEdificio.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ManProgrammata.CreaOttimizzaRDL_MP  _creaRDL = new TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP();

			DataSet _MyDs;
			_MyDs = _creaRDL.GetEdifici(anno,id_comune);
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{	
				this.cmbsEdificio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "EDIFICIO", "IDEDIFICIO", "-- Selezionare un Edificio --", "0");
				this.cmbsEdificio.DataTextField = "EDIFICIO";
				this.cmbsEdificio.DataValueField = "IDEDIFICIO";
				this.cmbsEdificio.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Edificio -";
				this.cmbsEdificio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0"));
			}

		}

		private void BindServizi(int anno, int id_comune, int id_edificio)
		{	
			this.cmbsServizio.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ManProgrammata.CreaOttimizzaRDL_MP  _creaRDL = new TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP();

			DataSet _MyDs;
			_MyDs = _creaRDL.GetServizi(anno, id_comune, id_edificio);
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{	
				this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "SERVIZIO", "IDSERVIZIO", "-- Selezionare un Servizio --", "0");
				this.cmbsServizio.DataTextField = "SERVIZIO";
				this.cmbsServizio.DataValueField = "IDSERVIZIO";
				this.cmbsServizio.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Servizio -";
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0"));
			}

		}
		private S_Controls.Collections.S_ControlsCollection GetControl()
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();
			
			cmbsComune.DBDefaultValue="0";
			cmbsEdificio.DBDefaultValue="0";
			cmbsServizio.DBDefaultValue="0";			

			// Data 											
			int annoA = Int16.Parse(cmbsAnno.SelectedValue);	
			
			S_Controls.Collections.S_Object s_AnnoA = new S_Object();
			s_AnnoA.ParameterName = "p_anno";
			s_AnnoA.DbType = CustomDBType.Integer;
			s_AnnoA.Direction = ParameterDirection.Input;
			s_AnnoA.Index = 1;
			s_AnnoA.Size=10;
			s_AnnoA.Value=annoA;
			CollezioneControlli.Add(s_AnnoA);

			// Comune
			int id_comune = 0;
			if(cmbsComune.SelectedValue!="0")
				id_comune=Int32.Parse(cmbsComune.SelectedValue);
			
			S_Controls.Collections.S_Object s_comune = new S_Object();
			s_comune.ParameterName = "p_comune";
			s_comune.DbType = CustomDBType.Integer;
			s_comune.Direction = ParameterDirection.Input;
			s_comune.Index = 2;
			s_comune.Size=10;
			s_comune.Value=id_comune;
			CollezioneControlli.Add(s_comune);				

			// Edificio
			int id_edificio = 0;
			if(cmbsEdificio.SelectedValue!="0")
				id_edificio=Int32.Parse(cmbsEdificio.SelectedValue);
			
			S_Controls.Collections.S_Object s_edif = new S_Object();
			s_edif.ParameterName = "p_edificio";
			s_edif.DbType = CustomDBType.Integer;
			s_edif.Direction = ParameterDirection.Input;
			s_edif.Index = 3;
			s_edif.Size=10;
			s_edif.Value=id_edificio;
			CollezioneControlli.Add(s_edif);	

			// Servizio						
			int id_servizio=0;
			if(cmbsServizio.SelectedValue!="0")
				id_servizio=Int32.Parse(cmbsServizio.SelectedValue);
			
			S_Controls.Collections.S_Object s_Servizio = new S_Object();

			s_Servizio.ParameterName = "p_servizio";
			s_Servizio.DbType = CustomDBType.Integer;
			s_Servizio.Direction = ParameterDirection.Input;
			s_Servizio.Index = 4;
			s_Servizio.Size=10;
			s_Servizio.Value=id_servizio;
			CollezioneControlli.Add(s_Servizio);

			return CollezioneControlli;
		}
		private void Ricerca(bool reset)
		{	
			
			//Session.Remove("DataSet");

		    S_Controls.Collections.S_ControlsCollection CollezioneControlli =GetControl();

			S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
			s_p_pageindex.ParameterName = "pageindex";
			s_p_pageindex.DbType = CustomDBType.Integer;
			s_p_pageindex.Direction = ParameterDirection.Input;
			s_p_pageindex.Index = 16;
			s_p_pageindex.Value=DataGridRicerca.CurrentPageIndex +1;			
			CollezioneControlli.Add(s_p_pageindex);

			S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
			s_p_pagesize.ParameterName = "pagesize";
			s_p_pagesize.DbType = CustomDBType.Integer;
			s_p_pagesize.Direction = ParameterDirection.Input;
			s_p_pagesize.Index = 17;
			s_p_pagesize.Value= DataGridRicerca.PageSize;			
			CollezioneControlli.Add(s_p_pagesize);

			Classi.ManProgrammata.CreaOttimizzaRDL_MP  _creaRDL = new TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP();

			DataSet _MyDs = _creaRDL.GetDataPaging(CollezioneControlli).Copy();

			if (reset==true)
			{

				CollezioneControlli =GetControl();	
				int _totalRecords = _creaRDL.GetDataCount(CollezioneControlli);
				this.GridTitle1.NumeroRecords=_totalRecords.ToString();
			}

			DataGridRicerca.Visible =true;
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.VirtualItemCount =int.Parse(this.GridTitle1.NumeroRecords);
			this.DataGridRicerca.DataBind();
			
			if (int.Parse(this.GridTitle1.NumeroRecords)>0)		
				PanelCrea.Visible=true;											
			else
				PanelCrea.Visible=false;
		}

		private void GetControlli()
		{	
			Classi.clMyDataGridCollection _cl = new TheSite.Classi.clMyDataGridCollection();
			if(Session["CheckedList"]!=null)
			{	
				_cl.GetControl(DataGridRicerca,(Hashtable) Session["CheckedList"],DataGridRicerca.CurrentPageIndex);
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

		private void SetDati()
		{			
			
			Hashtable _HS = new Hashtable();
			int indice = 0;
			
			if(Session["DatiList"]!=null)
			{
				_HS=(Hashtable) Session["DatiList"];				
			}

						
			foreach(DataGridItem o_Litem in DataGridRicerca.Items)
			{
				//DataGridField _campi = new DataGridField();
		
				//_campi.idbl=Int32.Parse(o_Litem.Cells[0].Text);									
				indice = Int32.Parse(o_Litem.Cells[0].Text);									
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel");																									
			
				if(_HS.ContainsKey(indice))
					_HS.Remove(indice);												
							
				if(cb.Checked)
				{
//					_campi.idditta=Int32.Parse(o_Litem.Cells[2].Text);
//					_campi.idservizio=Int32.Parse(o_Litem.Cells[3].Text);
//					_campi.mesegiorno=o_Litem.Cells[11].Text;
//					_campi.idaddetto=Int32.Parse(o_Litem.Cells[4].Text);	
					_HS.Add(indice, indice);		
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
			int indice = 0;
		
			if(Session["DatiList"]!=null)
			{
				_HS=(Hashtable) Session["DatiList"];				
			}

					
			foreach(DataGridItem o_Litem in DataGridRicerca.Items)
			{
				//DataGridField _campi = new DataGridField();
		
				//_campi.idbl=Int32.Parse(o_Litem.Cells[0].Text);									
				indice = Int32.Parse(o_Litem.Cells[0].Text);									
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel");																									
				cb.Checked=val;
				if(_HS.ContainsKey(indice))
					_HS.Remove(indice);												
							
				if(cb.Checked)
				{
//					_campi.idditta=Int32.Parse(o_Litem.Cells[2].Text);
//					_campi.idservizio=Int32.Parse(o_Litem.Cells[3].Text);
//					_campi.mesegiorno=o_Litem.Cells[11].Text;
//					_campi.idaddetto=Int32.Parse(o_Litem.Cells[4].Text);	
					_HS.Add(indice, indice);		
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
			
			S_Controls.Collections.S_ControlsCollection CollezioneControlli =GetControl();

			Classi.ManProgrammata.CreaOttimizzaRDL_MP  _creaRDL = new TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP();

			DataSet _MyDs = _creaRDL.GetData(CollezioneControlli).Copy();

			for(int Pagine = 0;Pagine<=DataGridRicerca.PageCount;Pagine++)
			{
	
				DataGridRicerca.DataSource=_MyDs.Tables[0];
				DataGridRicerca.DataBind();
				DataGridRicerca.CurrentPageIndex=Pagine;									
							
				SetDati(val);
				
				if(val)
				{	
					SetControlli();				
				}
			}

			DataGridRicerca.CurrentPageIndex=0;
			Ricerca(true);		
			GetControlli();						
		}

		private void Resetta()
		{
			// Resetto tutti i valori ed entro nella Modifica
			DataGridRicerca.CurrentPageIndex=0;			
			LblElementiSelezionati.Text="Elementi Selezionati - 0 -";
			txtTotSelezionati.Text="0";
			Session.Remove("CheckedList");
			Session.Remove("DatiList");			
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
			this.cmbsAnno.SelectedIndexChanged += new System.EventHandler(this.cmbsAnno_SelectedIndexChanged);
			this.cmbsEdificio.SelectedIndexChanged += new System.EventHandler(this.cmbsEdificio_SelectedIndexChanged);
			this.cmbsComune.SelectedIndexChanged += new System.EventHandler(this.cmbsComune_SelectedIndexChanged);
			this.btnsRicerca.Click += new System.EventHandler(this.btnsRicerca_Click);
			this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.btnsCrea.Click += new System.EventHandler(this.btnsCrea_Click);
			this.btnsSelezionaTutti.Click += new System.EventHandler(this.btnsSelezionaTutti_Click);
			this.btnsDeSelezionaTutti.Click += new System.EventHandler(this.btnsDeSelezionaTutti_Click);
			this.btnsConfermaSelezioni.Click += new System.EventHandler(this.btnsConfermaSelezioni_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

//		private void cmbsDitta_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			BindAddetti(RicercaModulo1.TxtCodice.Text);
//		}

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			DataGridRicerca.CurrentPageIndex=0;						
			Resetta();
			Ricerca(true);
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;	
			Ricerca(false);
			GetControlli();			
		}

		private void btnsConfermaSelezioni_Click(object sender, System.EventArgs e)
		{
			SetDati();
			SetControlli();		
		}		

		private void btnsSelezionaTutti_Click(object sender, System.EventArgs e)
		{
			SelezionaTutti(true);
		}

		private void btnsDeSelezionaTutti_Click(object sender, System.EventArgs e)
		{
			SelezionaTutti(false);
		}

		private void btnsCrea_Click(object sender, System.EventArgs e)
		{
			Classi.ManProgrammata.CreaOttimizzaRDL_MP _CRDL = new TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP();
			if(Session["DatiList"]!=null)
			{
				_CRDL.beginTransaction();
				
				try
				{					
					Hashtable _HS = (Hashtable)Session["DatiList"];
					IDictionaryEnumerator myEnumerator = _HS.GetEnumerator();								
					string mesegiorno=String.Empty;					
					int TotUpdate=0;

					while (myEnumerator.MoveNext())
					{
												
						S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();
						
						int _indice = (int) myEnumerator.Value;					

						S_Controls.Collections.S_Object s_Indice = new S_Object();
						s_Indice.ParameterName = "i_Indice";
						s_Indice.DbType = CustomDBType.Integer;
						s_Indice.Direction = ParameterDirection.Input;
						s_Indice.Index = 0;					
						s_Indice.Value = _indice;																	
						CollezioneControlli.Add(s_Indice);		
				
						S_Controls.Collections.S_Object s_UserName = new S_Object();
						s_UserName.ParameterName = "p_UserName";
						s_UserName.DbType = CustomDBType.VarChar;
						s_UserName.Direction = ParameterDirection.Input;
						s_UserName.Index = 1;					
						s_UserName.Value = System.Web.HttpContext.Current.User.Identity.Name;		
						s_UserName.Size = 50;									
						CollezioneControlli.Add(s_UserName);							
							
						int _result=_CRDL.Add(CollezioneControlli); 
						TotUpdate+=_result;
						
					}
					_CRDL.commitTransaction();
					DataGridRicerca.CurrentPageIndex=0;		
					Resetta();					
					Ricerca(true);										
				
				//Visualizzo il messaggio
					Classi.SiteJavaScript.msgBox(this.Page,string.Format("SONO STATI INSERITI N. {0} Richieste di Lavoro.",TotUpdate));

				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message); 
					_CRDL.rollbackTransaction(); 
					string mes=String.Empty;
					Classi.SiteJavaScript.msgBox(this.Page, "Si è verificato un errore durante la creazione delle Richieste di Lavoro.");
				}
			}
			else
			{
				Classi.SiteJavaScript.msgBox(this.Page,"Nessun Edificio selezionato.");
			}
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{	
				//Formatto il Campo DATE START (DATA INI)
				string _CampoData = e.Item.Cells[10].Text.Trim();
				if (_CampoData.Length > 0) 
				{					
					string gg = _CampoData.Substring(2,2); 
					int mm = Int16.Parse(_CampoData.Substring(0,2));					
					string mese =  Classi.Function.ImpostaMese(mm,false);					
					e.Item.Cells[10].Text= gg + " - " + mese ;
					e.Item.Cells[10].ToolTip= gg + " - " + Classi.Function.ImpostaMese(mm,true);
				}
			}
		}

		private void cmbsComune_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindEdifici(int.Parse(cmbsAnno.SelectedValue),int.Parse(cmbsComune.SelectedValue));
			BindServizi(int.Parse(cmbsAnno.SelectedValue),int.Parse(cmbsComune.SelectedValue),0);
		}

		private void cmbsAnno_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindControls();
		}

		private void cmbsEdificio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindServizi(int.Parse(cmbsAnno.SelectedValue),int.Parse(cmbsComune.SelectedValue),int.Parse(cmbsEdificio.SelectedValue));
		}

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("CreaOttimizzaRDL_MP.aspx");
		}

	}
}
