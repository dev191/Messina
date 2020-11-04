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

namespace TheSite.ManutenzioneProgrammata.Schedula
{
	/// <summary>
	/// Descrizione di riepilogo per OttimizzaPiano.
	/// </summary>
	public class OttimizzaPiano : System.Web.UI.Page
	{
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_ComboBox cmbsAnno;
		protected S_Controls.S_ComboBox cmbsEdificio;
		protected S_Controls.S_ComboBox cmbsComune;
		protected S_Controls.S_Button btnsRicerca;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
	    protected WebControls.PageTitle PageTitle1;
		protected WebControls.GridTitle GridTitle1;	
		public static string HelpLink = string.Empty;

		MyCollection.clMyCollection _myColl = new clMyCollection();
		protected System.Web.UI.WebControls.Button cmdReset;
		protected S_Controls.S_ComboBox cmbsServizio;
		OttimizzaPianoEQ _fp;

		public MyCollection.clMyCollection _Contenitore
		{
			get 
			{
				return _myColl;
			}
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			//FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = "Ottimizza il Piano della Manutenzione Programmata";
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

			if(!IsPostBack)
			{
				CaricaCombiAnni();
				BindControls();	

				if(Context.Handler is TheSite.ManutenzioneProgrammata.Schedula.OttimizzaPianoEQ)
				{
					_fp = (TheSite.ManutenzioneProgrammata.Schedula.OttimizzaPianoEQ)Context.Handler;
					if (_fp!=null) 
					{
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);								
						Ricerca(true);
					}
				}			
			
			}
		}
		private void CaricaCombiAnni()
		{
			string anno_corrente = DateTime.Now.Year.ToString();
			cmbsAnno.SelectedValue=anno_corrente;
		}
		private void BindControls()
		{
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
			
		}
		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			DataGridRicerca.CurrentPageIndex=0;						
			Ricerca(true);
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;	
			Ricerca(false);		
		}
		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Dettaglio")
			{				
				_myColl.AddControl(this.Page.Controls,ParentType.Page );
				string s_url = e.CommandArgument.ToString();			
				Server.Transfer(s_url);				
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
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("OttimizzaPiano.aspx");
		}

	
	}
}
