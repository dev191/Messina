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
	/// Descrizione di riepilogo per Rapportino.
	/// </summary>
	public class Rapportino : System.Web.UI.Page
	{
		protected S_Controls.S_ComboBox cmbsAnno;
		protected S_Controls.S_ComboBox cmbMeseDa;
		protected S_Controls.S_ComboBox cmbMeseA;
		protected S_Controls.S_ComboBox cmbsComune;
		protected S_Controls.S_ComboBox cmbsEdificio;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_ComboBox cmbsAddetti;
		protected S_Controls.S_Button btnsRicerca;
		protected System.Web.UI.WebControls.TextBox txtTotSelezionati;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected S_Controls.S_Button btnsSelezionaTutti;
		protected S_Controls.S_Button btnsDeSelezionaTutti;
		protected S_Controls.S_Button btnsConfermaSelezioni;
		protected System.Web.UI.WebControls.Label LblElementiSelezionati;
		protected System.Web.UI.WebControls.Panel PanelCrea;

		protected WebControls.GridTitle GridTitle1;	
		public static string HelpLink = string.Empty;
		protected S_Controls.S_TextBox txtsOrdine;
		protected S_Controls.S_Button btnsStampa;
		protected System.Web.UI.WebControls.RadioButton StampaCorta;
		protected System.Web.UI.WebControls.RadioButton StampaLunga;
		protected System.Web.UI.WebControls.Button cmdReset;		
		protected WebControls.PageTitle PageTitle1;
		protected System.Web.UI.WebControls.RadioButton StampaDettaglioLocaliCorta;
		protected System.Web.UI.WebControls.RadioButton StampaDetaglioLocali;
		protected System.Web.UI.WebControls.RadioButton StampaDetaglioLocaliLung2Pa;
		protected WebControls.BottomMenu BottomMenu1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			txtsOrdine.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtsOrdine.Attributes.Add("onpaste","return nonpaste();");
			//Imposto le funzioni client per non effettuare il PostBack
			this.btnsRicerca.Attributes.Add("onclick","Valorizza('0')");
			this.btnsConfermaSelezioni.Attributes.Add("onclick","Valorizza('0')");
			this.btnsSelezionaTutti.Attributes.Add("onclick","Valorizza('0')");
			this.btnsDeSelezionaTutti.Attributes.Add("onclick","Valorizza('0')");
			this.btnsStampa.Attributes.Add("onclick","Valorizza('1')");

			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = "Stampa Rapportino Tecnico di Intervento";

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
			sbValid.Append("document.getElementById('" + btnsStampa.ClientID + "').disabled = true;");
			sbValid.Append(this.Page.GetPostBackEventReference(this.btnsStampa));
			sbValid.Append(";");
			this.btnsStampa.Attributes.Add("onclick", sbValid.ToString());

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
				if(Request.QueryString["FunId"]!=null)
				{		
					this.BottomMenu1.Visible = false;
					ViewState["FunId"]=Request.QueryString["FunId"];
				}

				CaricaCombiAnni();
				CaricaComboMesi();
				BindControls();														
				LblElementiSelezionati.Text="Elementi Selezionati - 0 -";
				EnableControl(false);
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
			TheSite.Classi.ManProgrammata.Rapportino _Rapportino=new TheSite.Classi.ManProgrammata.Rapportino();
			DataTable Dt= _Rapportino.GetMonth(Convert.ToInt32(cmbsAnno.SelectedValue)); 
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

			Classi.ManProgrammata.Rapportino   _Rapportino = new TheSite.Classi.ManProgrammata.Rapportino();

			DataSet _MyDs;
			_MyDs = _Rapportino.GetComuni(Convert.ToInt32 (cmbsAnno.SelectedValue),cmbMeseDa.SelectedValue, cmbMeseA.SelectedValue);
			
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

			Classi.ManProgrammata.Rapportino _Rapportino = new TheSite.Classi.ManProgrammata.Rapportino();

			DataSet _MyDs;
			_MyDs = _Rapportino.GetEdifici(Convert.ToInt32(cmbsAnno.SelectedValue),Convert.ToInt32(cmbsComune.SelectedValue),
				cmbMeseDa.SelectedValue, cmbMeseA.SelectedValue,Context.User.Identity.Name);
			
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

			Classi.ManProgrammata.Rapportino  _Rapportino = new TheSite.Classi.ManProgrammata.Rapportino();

			DataSet _MyDs;
			int idedificio=int.Parse(Codici[0]) ;

										
			_MyDs = _Rapportino.GetServizi( Convert.ToInt32(cmbsAnno.SelectedValue),Convert.ToInt32(cmbsComune.SelectedValue),
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

			Classi.ManProgrammata.Rapportino  _Rapportino = new TheSite.Classi.ManProgrammata.Rapportino();

			DataSet _MyDs;
			int idedificio=int.Parse(Codici[0]) ;

										
			_MyDs = _Rapportino.GetAddetti( Convert.ToInt32(cmbsAnno.SelectedValue),Convert.ToInt32(cmbsComune.SelectedValue),
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
		private void Ricerca(bool reset)
		{	
			
			//Session.Remove("DataSet");

			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();
			
			cmbsComune.DBDefaultValue="0";
			cmbsEdificio.DBDefaultValue="0";
			cmbsServizio.DBDefaultValue="0";
			
			CollezioneControlli = GetData();

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


			Classi.ManProgrammata.Rapportino  _Rapportino = new TheSite.Classi.ManProgrammata.Rapportino();

			DataSet _MyDs = _Rapportino.GetData(CollezioneControlli).Copy();

			if (reset)
			{
				CollezioneControlli.Clear();
				CollezioneControlli = GetData();

				int _totalRecords = _Rapportino.getCount(CollezioneControlli);
				this.GridTitle1.NumeroRecords=_totalRecords.ToString(); 
			}

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
					


			// this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();
			this.DataGridRicerca.VirtualItemCount =int.Parse(this.GridTitle1.NumeroRecords);
			this.DataGridRicerca.DataBind();	
		}

		// Paolo
		private S_ControlsCollection GetData()
		{
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();		

			//WO
			int WO=0;
			if(txtsOrdine.Text!="")
				WO = Int16.Parse(txtsOrdine.Text);	
			
			S_Controls.Collections.S_Object s_p_wo_id = new S_Object();
			s_p_wo_id.ParameterName = "p_wo_id";
			s_p_wo_id.DbType = CustomDBType.Integer;
			s_p_wo_id.Direction = ParameterDirection.Input;
			s_p_wo_id.Index = 1;
			s_p_wo_id.Value=WO;
			CollezioneControlli.Add(s_p_wo_id);

			// Data 											
			int annoA = Int16.Parse(cmbsAnno.SelectedValue);	
			
			S_Controls.Collections.S_Object s_AnnoA = new S_Object();
			s_AnnoA.ParameterName = "p_anno";
			s_AnnoA.DbType = CustomDBType.Integer;
			s_AnnoA.Direction = ParameterDirection.Input;
			s_AnnoA.Index = 1;
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
			s_Mese1.Value=Convert.ToInt32( cmbMeseDa.SelectedValue);
			CollezioneControlli.Add(s_Mese1);

			// Mese A										
			S_Controls.Collections.S_Object s_Mese2 = new S_Object();
			s_Mese2.ParameterName = "Mese2";
			s_Mese2.DbType = CustomDBType.VarChar;
			s_Mese2.Direction = ParameterDirection.Input;
			s_Mese2.Index = 7;
			s_Mese2.Size=10;
			s_Mese2.Value=Convert.ToInt32( cmbMeseA.SelectedValue);
			CollezioneControlli.Add(s_Mese2);

			return CollezioneControlli;

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
					_HS.Add(indice, indice);		
				}
			}			
			
			Session.Remove("DatiList");
			Session.Add("DatiList",_HS);			
			LblElementiSelezionati.Text="Elementi Selezionati - " + _HS.Count.ToString() + " -";
			if(_HS.Count>0)
				EnableControl(true);
			else
		        EnableControl(false);

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
					_HS.Add(indice, indice);		
				}
			}			
			
			Session.Remove("DatiList");
			Session.Add("DatiList",_HS);			
			LblElementiSelezionati.Text="Elementi Selezionati - " + _HS.Count.ToString() + " -";
			if(_HS.Count>0)
				EnableControl(true);
			else
				EnableControl(false);

			txtTotSelezionati.Text=_HS.Count.ToString();			
		}

		private void SelezionaTutti(bool val)
		{	
			if(!val)
			{
				Session.Remove("CheckedList");
				Session.Remove("DatiList");
				LblElementiSelezionati.Text="Elementi Selezionati - 0 -";
				EnableControl(false);
				txtTotSelezionati.Text="0";
			}
			else
			{				
				SetControlli();										
			}
			

			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();
			cmbsComune.DBDefaultValue="0";
			cmbsEdificio.DBDefaultValue="0";
			cmbsServizio.DBDefaultValue="0";
			CollezioneControlli = GetData();

			Classi.ManProgrammata.Rapportino  _Rapportino = new TheSite.Classi.ManProgrammata.Rapportino();
			DataSet ds = _Rapportino.GetDataSel(CollezioneControlli);
			
			DataGridRicerca.AllowCustomPaging =false;
			DataGridRicerca.CurrentPageIndex=0;
			
		
			for(int Pagine = 0;Pagine<=DataGridRicerca.PageCount;Pagine++)
			{
									
				this.DataGridRicerca.DataSource =ds.Tables[0];
				this.DataGridRicerca.DataBind();	
				DataGridRicerca.CurrentPageIndex=Pagine;	
				SetDati(val);
												
				if(val)
				{	
					SetControlli();				
				}
			}
			DataGridRicerca.AllowCustomPaging =true;
			DataGridRicerca.CurrentPageIndex=0;
			Ricerca(true);	
			GetControlli();						
		}

		private void Resetta()
		{
			// Resetto tutti i valori ed entro nella Modifica
			DataGridRicerca.CurrentPageIndex=0;			
			LblElementiSelezionati.Text="Elementi Selezionati - 0 -";
			EnableControl(false);
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
			this.btnsStampa.Click += new System.EventHandler(this.btnsCrea_Click);
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
				try
				{		
					string value=null;
					Hashtable _HS = (Hashtable)Session["DatiList"];
					IDictionaryEnumerator myEnumerator = _HS.GetEnumerator();								
					while (myEnumerator.MoveNext())	
					{
					  value+=myEnumerator.Value + ",";
					}
					
					value = value.Remove(value.Length-1,1);
					
					if(StampaCorta.Checked==true) 
					{
						Response.Redirect("DisplayRapportino.aspx?Display=S&ODL=" + value); 
					}
					else if(StampaLunga.Checked ==true)
					{
						Response.Redirect("DisplayRapportino.aspx?Display=L&ODL=" + value); 
					}
					else if(StampaDetaglioLocali.Checked == true)
					{
						Response.Redirect("DisplayRapportino.aspx?Display=DL&ODL=" + value); 
					}
					else if(StampaDettaglioLocaliCorta.Checked == true)
					{
						Response.Redirect("DisplayRapportino.aspx?Display=DC&ODL=" + value);
					}
					else if(StampaDetaglioLocaliLung2Pa.Checked == true)
					{
						Response.Redirect("DisplayRapportino.aspx?Display=DL2P&ODL=" + value);
					}
					else
					{
						Exception ex = new Exception();
						throw  ex;
					}

				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message); 
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

		private void EnableControl(bool enable)
		{
			btnsStampa.Enabled =enable;
			StampaCorta.Enabled =enable;
			StampaLunga.Enabled =enable;
			StampaDetaglioLocali.Enabled = enable;
			StampaDettaglioLocaliCorta.Enabled = enable;
			StampaDetaglioLocaliLung2Pa.Enabled = enable;

		}

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			if (ViewState["FunId"] != null)
			{
				Response.Redirect("Rapportino.aspx?FunID=" + ViewState["FunId"]);
			}
			else
			{
				Response.Redirect("Rapportino.aspx");
			}
		}

	
	}
	
}
