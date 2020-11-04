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


namespace TheSite.Admin
{
	/// <summary>
	/// Descrizione di riepilogo per Utenti.
	/// </summary>
	public class Utenti1 : System.Web.UI.Page
	{
		protected S_Controls.S_TextBox txtsUserName;
		protected S_Controls.S_TextBox txtsCognome;
		//protected S_Controls.S_TextBox txtsNome;
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected System.Web.UI.HtmlControls.HtmlTable tblSearch75;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;		
		public static int FunId = 0;
		protected S_Controls.S_ComboBox CmbProgetto;
		protected S_Controls.S_ComboBox CmbRuolo;
		public static string HelpLink = string.Empty;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
		this.GridTitle1.hplsNuovo.NavigateUrl = "../Admin/EditUtenti.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
			this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;	

			this.DataGridRicerca.Columns[1].Visible = _SiteModule.IsEditable;				
						
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			if(!IsPostBack)
				//BindProgetti(0);
			{BindProgetti1();
				BindRuolo();}

		}
//		private void BindProgetti(int progetto)
//		{
//			
//			this.CmbProgetto.Items.Clear();
//		
//			TheSite.Classi.Progetti _Prog = new TheSite.Classi.Progetti();
//						
//			DataSet _MyDs = _Prog.GetData();			
//			
//			if (_MyDs.Tables[0].Rows.Count > 0)
//			{
//				this.CmbProgetto.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
//					_MyDs.Tables[0],"descrizione","descrizione", "- Selezionare un Progetto -","");				
//				this.CmbProgetto.DataTextField ="descrizione";
//				this.CmbProgetto.DataValueField  ="descrizione";
//				this.CmbProgetto.DataBind();
//
//				CmbProgetto.SelectedValue =progetto.ToString();
//			}
//			else
//			{
//				string s_Messagggio = "- Nessun Progetto  -";
//				this.CmbProgetto.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
//						
//			}			
//		}


		private void BindProgetti1()
		{
			
			this.CmbProgetto.Items.Clear();
		
			TheSite.Classi.Progetti _Prog = new TheSite.Classi.Progetti();
						
			DataSet _MyDs = _Prog.GetData();			
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.CmbProgetto.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0],"descrizione","id_progetto", "Selezionare un Progetto","0");				
				this.CmbProgetto.DataTextField ="descrizione";
				this.CmbProgetto.DataValueField  ="id_progetto";
				this.CmbProgetto.DataBind();

				//CmbProgetto.SelectedValue =progetto.ToString();
			}
			else
			{
				string s_Messagggio = "- Nessun Progetto  -";
				this.CmbProgetto.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0"));
						
			}			
		}


		private void BindRuolo()
		{
			
			this.CmbRuolo.Items.Clear();
		
			TheSite.Classi.Ruolo _Ruolo = new TheSite.Classi.Ruolo();
						
			DataSet _MyDs = _Ruolo.GetData();			
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				
				this.CmbRuolo.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0],"descrizione","id", "Selezionare Ruolo","0");				
				this.CmbRuolo.DataTextField ="descrizione";
				this.CmbRuolo.DataValueField  ="id";
				this.CmbRuolo.DataBind();
//				
//				this.cmbsSettore.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
//					_MyDs.Tables[0], "settore", "idsettore", "- Selezionare un Settore -","-1");
//				this.cmbsSettore.DataTextField = "settore";
//				this.cmbsSettore.DataValueField = "idsettore";
//				this.cmbsSettore.DataBind();

			}
			else
			{
				string s_Messagggio = "- Nessun Ruolo  -";
				this.CmbRuolo.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0"));
						
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			Classi.Utente _Utente = new TheSite.Classi.Utente();

			this.txtsUserName.DBDefaultValue = "";
			this.txtsCognome.DBDefaultValue = "";
			this.CmbProgetto.DBDefaultValue=0;
			this.CmbRuolo.DBDefaultValue=0;
			//this.txtsNome.DBDefaultValue = "%";
			//this.txtsEmail.DBDefaultValue = "%";
			//this.txtsTelefono.DBDefaultValue = "%";
				
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			_SCollection.AddItems(this.PanelRicerca.Controls);

			DataSet _MyDs = _Utente.GetData1(_SCollection).Copy();

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();
			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();			
			
		}
	}
}
