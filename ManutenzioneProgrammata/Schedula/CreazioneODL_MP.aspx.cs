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
	/// Descrizione di riepilogo per CreazioneODL_MP.
	/// </summary>
	public class CreazioneODL_MP : System.Web.UI.Page
	{
		protected S_Controls.S_ComboBox cmbsAnno;
		protected S_Controls.S_ComboBox cmbsEdificio;
		protected S_Controls.S_ComboBox cmbsComune;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_Button btnsRicerca;
		protected System.Web.UI.WebControls.TextBox txtTotSelezionati;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected S_Controls.S_Button btnsCrea;
		protected S_Controls.S_Button btnsSelezionaTutti;
		protected S_Controls.S_Button btnsDeSelezionaTutti;
		protected S_Controls.S_Button btnsConfermaSelezioni;
		protected System.Web.UI.WebControls.Label LblElementiSelezionati;
		protected S_Controls.S_ComboBox cmbMeseDa;
		protected S_Controls.S_ComboBox cmbMeseA;
		protected System.Web.UI.WebControls.Panel PanelCrea;

		protected WebControls.GridTitle GridTitle1;	
		public static string HelpLink = string.Empty;
		protected S_Controls.S_ComboBox cmbsAddetti;
		protected System.Web.UI.WebControls.Button cmdReset;
        protected WebControls.PageTitle PageTitle1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			
			//Imposto le funzioni client per non effettuare il PostBack
			this.btnsRicerca.Attributes.Add("onclick","Valorizza('0')");
			this.btnsConfermaSelezioni.Attributes.Add("onclick","Valorizza('0')");
			this.btnsSelezionaTutti.Attributes.Add("onclick","Valorizza('0')");
			this.btnsDeSelezionaTutti.Attributes.Add("onclick","Valorizza('0')");
			this.btnsCrea.Attributes.Add("onclick","Valorizza('1')");

			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = "Emetti Ordini di Lavoro";
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
				CaricaComboMesi();
				BindControls();														
				LblElementiSelezionati.Text="Elementi Selezionati - 0 -";
				txtTotSelezionati.Text="0";					
				Session.Remove("CheckedList");
				Session.Remove("DatiList");
				Session.Remove("DataSet");			
			}		
		}
		private void CaricaCombiAnni()
		{

			
			string anno_corrente = DateTime.Now.Year.ToString();
			cmbsAnno.SelectedValue=anno_corrente;
		}
		private void CaricaComboMesi()
		{
			TheSite.Classi.ManProgrammata.CreaRDL _CreaRDL=new TheSite.Classi.ManProgrammata.CreaRDL();
			DataTable Dt= _CreaRDL.GetMonth(Convert.ToInt32(cmbsAnno.SelectedValue)); 
			cmbMeseDa.DataSource= Dt;
            cmbMeseDa.DataTextField="mesedes";
			cmbMeseDa.DataValueField="mesenum";
			cmbMeseDa.DataBind(); 

			if(cmbMeseDa.Items.Count>0)
			{
				cmbMeseDa.SelectedIndex = 0; 
			}
			else
			{
				string s_Messagggio = "- Nessun Mese -";
				this.cmbMeseDa.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0"));
			}

			cmbMeseA.DataSource= Dt;
			cmbMeseA.DataTextField="mesedes";
			cmbMeseA.DataValueField="mesenum";
			cmbMeseA.DataBind(); 

			if(cmbMeseA.Items.Count>0)
			{
				cmbMeseA.SelectedIndex =cmbMeseA.Items.Count -1; 
			}
			else
			{
				string s_Messagggio = "- Nessun Mese -";
				this.cmbMeseA.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0"));
			}
            
	
		}
		private void BindControls()
		{
			BindComuni();
			BindEdifici();
			BindServizi();
			BindAddetti();
		}
		private void BindComuni()
		{	
			this.cmbsComune.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ManProgrammata.CreaRDL  _creaRDL = new TheSite.Classi.ManProgrammata.CreaRDL();

			DataSet _MyDs;
			_MyDs = _creaRDL.GetComuni(Convert.ToInt32 (cmbsAnno.SelectedValue),cmbMeseDa.SelectedValue, cmbMeseA.SelectedValue);
			
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

		private void BindEdifici()
		{	
			this.cmbsEdificio.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ManProgrammata.CreaRDL _creaRDL = new TheSite.Classi.ManProgrammata.CreaRDL();

			DataSet _MyDs;
			_MyDs = _creaRDL.GetEdifici(Convert.ToInt32(cmbsAnno.SelectedValue),Convert.ToInt32(cmbsComune.SelectedValue),
										cmbMeseDa.SelectedValue, cmbMeseA.SelectedValue);
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{	
				this.cmbsEdificio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "EDIFICIO", "IDCOMPOSITO", "-- Selezionare un Edificio --", "0;0");
				this.cmbsEdificio.DataTextField = "EDIFICIO";
				this.cmbsEdificio.DataValueField = "IDCOMPOSITO";
				this.cmbsEdificio.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Edificio -";
				this.cmbsEdificio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0;0"));
			}

		}

		private void BindServizi()
		{	
			string[] Codici=cmbsEdificio.SelectedValue.Split(Convert.ToChar(";"));

			this.cmbsServizio.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ManProgrammata.CreaRDL  _creaRDL = new TheSite.Classi.ManProgrammata.CreaRDL();

			DataSet _MyDs;
			int idedificio=int.Parse(Codici[0]) ;

										
			_MyDs = _creaRDL.GetServizi( Convert.ToInt32(cmbsAnno.SelectedValue),Convert.ToInt32(cmbsComune.SelectedValue),
										Convert.ToInt32(Codici[0]),cmbMeseDa.SelectedValue, cmbMeseA.SelectedValue);
			
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

		private void BindAddetti()
		{	
			string[] Codici=cmbsEdificio.SelectedValue.Split(Convert.ToChar(";"));

			this.cmbsAddetti.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ManProgrammata.CreaRDL  _creaRDL = new TheSite.Classi.ManProgrammata.CreaRDL();

			DataSet _MyDs;
			int idedificio=int.Parse(Codici[0]) ;

										
			_MyDs = _creaRDL.GetAddetti( Convert.ToInt32(cmbsAnno.SelectedValue),Convert.ToInt32(cmbsComune.SelectedValue),
				Convert.ToInt32(Codici[0]), Convert.ToInt32(cmbsServizio.SelectedValue),  cmbMeseDa.SelectedValue, cmbMeseA.SelectedValue);
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{	
				this.cmbsAddetti.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "Addetto", "IDAddetto", "-- Selezionare un Addetto --", "0");
				this.cmbsAddetti.DataTextField = "Addetto";
				this.cmbsAddetti.DataValueField = "IDAddetto";
				this.cmbsAddetti.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Addetto -";
				this.cmbsAddetti.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0"));
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
			string[] Codici=cmbsEdificio.SelectedValue.Split(Convert.ToChar(";"));
			int id_edificio = Convert.ToInt32(Codici[0]);
			
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
			
			// Addetto						
			int id_addetto=0;
			if(cmbsAddetti.SelectedValue!="0")
				id_addetto=Int32.Parse(cmbsAddetti.SelectedValue);
			
			S_Controls.Collections.S_Object s_p_addetto = new S_Object();
			s_p_addetto.ParameterName = "p_addetto";
			s_p_addetto.DbType = CustomDBType.Integer;
			s_p_addetto.Direction = ParameterDirection.Input;
			s_p_addetto.Index = 5;
			s_p_addetto.Size=10;
			s_p_addetto.Value=id_addetto;
			CollezioneControlli.Add(s_p_addetto);

			// Mese Da						
			S_Controls.Collections.S_Object s_Mese1 = new S_Object();
			s_Mese1.ParameterName = "Mese1";
			s_Mese1.DbType = CustomDBType.VarChar;
			s_Mese1.Direction = ParameterDirection.Input;
			s_Mese1.Index = 6;
			s_Mese1.Size=10;
			s_Mese1.Value=cmbMeseDa.SelectedValue;
			CollezioneControlli.Add(s_Mese1);

			// Mese A										
			S_Controls.Collections.S_Object s_Mese2 = new S_Object();
			s_Mese2.ParameterName = "Mese2";
			s_Mese2.DbType = CustomDBType.VarChar;
			s_Mese2.Direction = ParameterDirection.Input;
			s_Mese2.Index = 7;
			s_Mese2.Size=10;
			s_Mese2.Value=cmbMeseA.SelectedValue;
			CollezioneControlli.Add(s_Mese2);

			return CollezioneControlli;
		
		}


		private void Ricerca(bool reset)
		{	
			
//			Session.Remove("DataSet");

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

			Classi.ManProgrammata.CreaRDL  _creaRDL = new TheSite.Classi.ManProgrammata.CreaRDL();
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
								
				indice = Int32.Parse(o_Litem.Cells[0].Text);									
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel");																									
			
				if(_HS.ContainsKey(indice))
					_HS.Remove(indice);												
							
				if(cb.Checked)
				{
					OrdineLavoro ordine=new OrdineLavoro();
                    ordine.bl_id =Convert.ToInt32(o_Litem.Cells[2].Text);
					ordine.id_servizio =Convert.ToInt32(o_Litem.Cells[5].Text);
					ordine.addetto_id =Convert.ToInt32(o_Litem.Cells[7].Text);
                    ordine.id=indice;
					_HS.Add(indice, ordine);		
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
				indice = Int32.Parse(o_Litem.Cells[0].Text);									
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel");																									
				cb.Checked=val;
				if(_HS.ContainsKey(indice))
					_HS.Remove(indice);												
							
				if(cb.Checked)
				{
					OrdineLavoro ordine=new OrdineLavoro();
					ordine.bl_id =Convert.ToInt32(o_Litem.Cells[2].Text);
					ordine.id_servizio =Convert.ToInt32(o_Litem.Cells[5].Text);
					ordine.addetto_id =Convert.ToInt32(o_Litem.Cells[7].Text);
					ordine.id=indice;
					_HS.Add(indice, ordine);		
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
			Classi.ManProgrammata.CreaRDL  _creaRDL = new TheSite.Classi.ManProgrammata.CreaRDL();
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
			this.cmbsComune.SelectedIndexChanged += new System.EventHandler(this.cmbsComune_SelectedIndexChanged);
			this.cmbsEdificio.SelectedIndexChanged += new System.EventHandler(this.cmbsEdificio_SelectedIndexChanged);
			this.cmbsServizio.SelectedIndexChanged += new System.EventHandler(this.cmbsServizio_SelectedIndexChanged);
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
			if(Session["DatiList"]!=null)
			{
				Classi.ManProgrammata.CreaRDL  _creaRDL = new TheSite.Classi.ManProgrammata.CreaRDL();

				try
				{		
					
					_creaRDL.beginTransaction();

					int TotUpdate=0;
 
					Hashtable _HS = (Hashtable)Session["DatiList"];
					
					if (_HS.Count==0)
					{
					 Classi.SiteJavaScript.msgBox(this.Page,"Nessun Edificio selezionato.");
                     return;
					}

					IDictionaryEnumerator myEnumerator = _HS.GetEnumerator();								
					while (myEnumerator.MoveNext())	
					{
						OrdineLavoro Ord =(OrdineLavoro)myEnumerator.Value;

						S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();
			
						S_Controls.Collections.S_Object s_i_Edificio = new S_Object();
						s_i_Edificio.ParameterName = "i_Edificio";
						s_i_Edificio.DbType = CustomDBType.Integer;
						s_i_Edificio.Direction = ParameterDirection.Input;
						s_i_Edificio.Index = 0;
						s_i_Edificio.Value=Ord.bl_id;
						CollezioneControlli.Add(s_i_Edificio);

						S_Controls.Collections.S_Object s_i_Category = new S_Object();
						s_i_Category.ParameterName = "i_Category";
						s_i_Category.DbType = CustomDBType.Integer;
						s_i_Category.Direction = ParameterDirection.Input;
						s_i_Category.Index =1;
						s_i_Category.Value=Ord.id_servizio;
						CollezioneControlli.Add(s_i_Category);

						S_Controls.Collections.S_Object s_i_ANNO = new S_Object();
						s_i_ANNO.ParameterName = "i_ANNO";
						s_i_ANNO.DbType = CustomDBType.Integer;
						s_i_ANNO.Direction = ParameterDirection.Input;
						s_i_ANNO.Index =2;
						s_i_ANNO.Value=Convert.ToInt32(cmbsAnno.SelectedValue);
						CollezioneControlli.Add(s_i_ANNO);

						S_Controls.Collections.S_Object s_i_MESE1 = new S_Object();
						s_i_MESE1.ParameterName = "i_MESE1";
						s_i_MESE1.DbType = CustomDBType.VarChar;
						s_i_MESE1.Direction = ParameterDirection.Input;
						s_i_MESE1.Index =3;
						s_i_MESE1.Size=10; 
						s_i_MESE1.Value=cmbMeseDa.SelectedValue;
						CollezioneControlli.Add(s_i_MESE1);

						S_Controls.Collections.S_Object s_i_MESE2 = new S_Object();
						s_i_MESE2.ParameterName = "i_MESE2";
						s_i_MESE2.DbType = CustomDBType.VarChar;
						s_i_MESE2.Direction = ParameterDirection.Input;
						s_i_MESE2.Index =4;
						s_i_MESE2.Size=10; 
						s_i_MESE2.Value=cmbMeseA.SelectedValue;
						CollezioneControlli.Add(s_i_MESE2);				
	
						S_Controls.Collections.S_Object s_ADDETTO = new S_Object();
						s_ADDETTO.ParameterName = "i_ADDETTO";
						s_ADDETTO.DbType = CustomDBType.Integer;
						s_ADDETTO.Direction = ParameterDirection.Input;
						s_ADDETTO.Index =5;
						s_ADDETTO.Value=Ord.addetto_id;
						CollezioneControlli.Add(s_ADDETTO);

						int result=_creaRDL.Add(CollezioneControlli); 
                        TotUpdate+=result;

					}

					_creaRDL.commitTransaction();
					//Rimuovo la sessione
					Session.Remove("CheckedList");
					Session.Remove("DatiList");
					Session.Remove("DataSet");	
                    //Rifaccio la ricerca
					DataGridRicerca.CurrentPageIndex=0;						
					Resetta();
					Ricerca(true);

					Classi.SiteJavaScript.msgBox(this.Page,string.Format("SONO STATI INSERITI N. {0} Ordini di Lavoro.",TotUpdate));
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message); 
					_creaRDL.rollbackTransaction(); 
					string mes=String.Empty;
					Classi.SiteJavaScript.msgBox(this.Page, "Si è verificato un errore durante la creazione degli Ordini di Lavoro.");
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
			BindEdifici();
			BindServizi();
			BindAddetti();
		}

		private void cmbsAnno_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Paolo
			CaricaComboMesi();
			BindControls();
		}

		private void cmbsEdificio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindServizi();
			BindAddetti();
		}

		private void cmbsServizio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		 BindAddetti();
		}

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("CreazioneODL_MP.aspx");
		}



	}
	public class OrdineLavoro
	{
      public int id=0;
	  public int id_servizio=0;
      public int bl_id=0;
      public int addetto_id=0;
	}
}
