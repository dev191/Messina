using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;


namespace TheSite.ManutenzioneProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per ProcedurePassi.
	/// </summary>
	public class ProcedurePassi : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_Button btnsRicerca;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected WebControls.UserPmp UserPmp1;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;
		

		public static int FunId = 0;
		protected Csy.WebControls.DataPanel DataPanel1;
		protected S_Controls.S_ComboBox cmdsStdApparecchiatura;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_ComboBox cmbsSpecializzazione;
		protected System.Web.UI.WebControls.Button cmdReset;
		
		public static string HelpLink = string.Empty;	
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];

			//this.RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);
			
			this.UserPmp1.DelegateCodicePMP1 +=new WebControls.DelegateCodicePMP(this.BindSpecializzazione);
			
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			
			string funzione = "Pulisci('" + UserPmp1.Descrizione.ClientID + "','" + UserPmp1.Codice.ClientID + "','" + UserPmp1.CodiceNum.ClientID +"');";			
			this.cmbsServizio.Attributes.Add("onchange",funzione);
			this.cmdsStdApparecchiatura.Attributes.Add("onchange",funzione);
			
//			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
//			sbValid.Append("document.getElementById('" + this.cmdsStdApparecchiatura.ClientID + "').disabled = true;");
//			this.cmbsServizio.Attributes.Add("onchange", sbValid.ToString());

			if(!Page.IsPostBack)
			{	
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];
				BindServizio();
				GridTitle1.hplsNuovo.Visible = false;
				BindApparecchiatura();
				BindSpecializzazione(0);
			}
		}

		private void BindServizio()
		{
				this.cmbsServizio.Items.Clear();		

				Classi.ClassiDettaglio.Servizi  _Servizio = new TheSite.Classi.ClassiDettaglio.Servizi(Context.User.Identity.Name);		

				DataSet _MyDs = _Servizio.GetData();

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
			
			this.cmdsStdApparecchiatura.Items.Clear();
		
			Classi.AnagrafeImpianti.Apparecchiature  _Apparecchiature = new TheSite.Classi.AnagrafeImpianti.Apparecchiature(Context.User.Identity.Name);				
			
			DataSet _MyDs;

			_MyDs = _Apparecchiature.GetData().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmdsStdApparecchiatura.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare una Apparecchiatura -", "");
				this.cmdsStdApparecchiatura.DataTextField = "DESCRIZIONE";
				this.cmdsStdApparecchiatura.DataValueField = "ID";
				this.cmdsStdApparecchiatura.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Apparecchiatura -";
				this.cmdsStdApparecchiatura.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		private void BindSpecializzazione(int pmp_id)
		{
			
			this.cmbsSpecializzazione.Items.Clear();
			
			int eqstd_id=0;
			int servizio_id=0;
			
			if (cmbsServizio.SelectedValue!="")
				servizio_id=Int32.Parse(cmbsServizio.SelectedValue);
			if (cmdsStdApparecchiatura.SelectedValue!="")
				eqstd_id=Int32.Parse(cmdsStdApparecchiatura.SelectedValue);
			
			Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
			DataSet _MyDs;
			
//			if(pmp_id==0)
//			{
//				_MyDs = _Addetti.GetAllSpecializzazioni().Copy(); 
//			}
//			else
//			{
//				_MyDs = _Addetti.GetSpecializzazionePMP(pmp_id,eqstd_id,servizio_id);
//			}
			_MyDs = _Addetti.GetSpecializzazionePMP(pmp_id,eqstd_id,servizio_id);
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsSpecializzazione.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Tutte le Specializzazioni -", "");
				this.cmbsSpecializzazione.DataTextField = "DESCRIZIONE";
				this.cmbsSpecializzazione.DataValueField = "ID";
				this.cmbsSpecializzazione.DataBind();
				if(pmp_id>0)				
					this.cmbsSpecializzazione.SelectedIndex=1;
			}
			else
			{
				string s_Messagggio = "- Nessuna Specializzazione -";
				this.cmbsSpecializzazione.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		private void BindApparecchiatura(string ServizioID)
		{
			
			this.cmdsStdApparecchiatura.Items.Clear();
		
			Classi.AnagrafeImpianti.Apparecchiature  _Apparecchiature = new TheSite.Classi.AnagrafeImpianti.Apparecchiature(Context.User.Identity.Name);
			
			DataSet _MyDs;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_BlId = new S_Object();
			s_BlId.ParameterName = "p_Bl_Id";
			s_BlId.DbType = CustomDBType.VarChar;
			s_BlId.Direction = ParameterDirection.Input;
			s_BlId.Size =50;
			s_BlId.Index = 0;
			s_BlId.Value = string.Empty;
			_SColl.Add(s_BlId);
		
			S_Controls.Collections.S_Object s_Servizio = new S_Object();
			s_Servizio.ParameterName = "p_Servizio";
			s_Servizio.DbType = CustomDBType.Integer;
			s_Servizio.Direction = ParameterDirection.Input;
			s_Servizio.Index = 1;
			s_Servizio.Value = (cmbsServizio.SelectedValue=="")? 0:Int32.Parse(cmbsServizio.SelectedValue);
			_SColl.Add(s_Servizio);

			_MyDs = _Apparecchiature.GetData(_SColl).Copy();
           
  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmdsStdApparecchiatura.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare una Apparecchiatura -", "");
				this.cmdsStdApparecchiatura.DataTextField = "DESCRIZIONE";
				this.cmdsStdApparecchiatura.DataValueField = "ID";
				this.cmdsStdApparecchiatura.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Apparecchiatura -";
				this.cmdsStdApparecchiatura.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
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
			this.cmbsServizio.SelectedIndexChanged += new System.EventHandler(this.cmbsServizio_SelectedIndexChanged);
			this.cmdsStdApparecchiatura.SelectedIndexChanged += new System.EventHandler(this.cmdsStdApparecchiatura_SelectedIndexChanged);
			this.btnsRicerca.Click += new System.EventHandler(this.btnsRicerca_Click);
			this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			DataGridRicerca.CurrentPageIndex=0;
			Ricerca();
		}

		private void Ricerca()
		{

			Classi.ManProgrammata.ProcAndSteps _ProcAndSteps = new TheSite.Classi.ManProgrammata.ProcAndSteps(Context.User.Identity.Name);						
	     	
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			int idservizio=0;
			int ideqstd=0;
			int idtr=0;
			if (cmbsServizio.SelectedValue!="")
				idservizio=Int32.Parse(cmbsServizio.SelectedValue);
			if (cmdsStdApparecchiatura.SelectedValue!="")
				ideqstd=Int32.Parse(cmdsStdApparecchiatura.SelectedValue);
			if (cmbsSpecializzazione.SelectedValue!="")
				idtr=Int32.Parse(cmbsSpecializzazione.SelectedValue);			
			
						
			S_Controls.Collections.S_Object s_Servizio_id = new S_Object();
			s_Servizio_id.ParameterName = "p_Servizio_id";
			s_Servizio_id.DbType = CustomDBType.Integer;
			s_Servizio_id.Direction = ParameterDirection.Input;
			s_Servizio_id.Index = 0;
			s_Servizio_id.Value = idservizio;			
			s_Servizio_id.Size = 50;
			CollezioneControlli.Add(s_Servizio_id);

			S_Controls.Collections.S_Object s_EqStd_id = new S_Object();
			s_EqStd_id.ParameterName = "p_EqStd_id";
			s_EqStd_id.DbType = CustomDBType.Integer;
			s_EqStd_id.Direction = ParameterDirection.Input;
			s_EqStd_id.Index = 1;
			s_EqStd_id.Value = ideqstd;			
			s_EqStd_id.Size = 50;
			CollezioneControlli.Add(s_EqStd_id);

			S_Controls.Collections.S_Object s_TR_id = new S_Object();
			s_TR_id.ParameterName = "p_TR_id";
			s_TR_id.DbType = CustomDBType.Integer;
			s_TR_id.Direction = ParameterDirection.Input;
			s_TR_id.Index = 2;
			s_TR_id.Value = idtr;			
			s_TR_id.Size = 50;	
			CollezioneControlli.Add(s_TR_id);

			S_Controls.Collections.S_Object s_PMP_id = new S_Object();
			s_PMP_id.ParameterName = "p_PMP_id";
			s_PMP_id.DbType = CustomDBType.Integer;
			s_PMP_id.Direction = ParameterDirection.Input;
			s_PMP_id.Index = 3;
			s_PMP_id.Value = this.UserPmp1.CodiceNum.Value;			
			s_PMP_id.Size = 50;
			CollezioneControlli.Add(s_PMP_id);
			
			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Index = 4;
			s_UserName.Value = this.User.Identity.Name;			
			s_UserName.Size = 50;
			CollezioneControlli.Add(s_UserName);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 5;		
			CollezioneControlli.Add(s_Cursor);

			DataSet _MyDs = _ProcAndSteps.GetData(CollezioneControlli).Copy();

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();
			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();			
		}

		private void cmbsServizio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbsServizio.SelectedIndex == 0)
			{
				BindApparecchiatura();
			}
			else
			{
				BindApparecchiatura(cmbsServizio.SelectedValue);
			}
			BindSpecializzazione(0);
		}

		private void cmdsStdApparecchiatura_SelectedIndexChanged(object sender, System.EventArgs e)
		{
				BindSpecializzazione(0);
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;	
			Ricerca();			
		}

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ProcedurePassi.aspx?FunID=" + ViewState["FunId"]);
		}

		
	}
}
