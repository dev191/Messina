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
using StampaRapportiPdf.Classi;

namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per Fondi.
	/// </summary>
	public class Fondi : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		public static int FunId = 0;
		public static string HelpLink = string.Empty;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;
		clMyCollection _myColl = new clMyCollection();

		EditFondi _fp;
		protected S_Controls.S_ComboBox cmbsAnno;
		protected S_Controls.S_Button BtnReset;
		protected S_Controls.S_ComboBox cmbsTipoIntervento;		
		
		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.GridTitle1.hplsNuovo.NavigateUrl = "../Gestione/EditFondi.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
			this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;	

			this.DataGridRicerca.Columns[1].Visible = true;
			this.DataGridRicerca.Columns[2].Visible = _SiteModule.IsEditable;				
						
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;			
		
			if (!Page.IsPostBack)
			{
				CaricaCombo();
				if(Context.Handler is TheSite.Gestione.EditFondi) 
				{									
					_fp = (TheSite.Gestione.EditFondi) Context.Handler;
					if (_fp!=null)
					{
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);
						Ricerca();
					}					
				}		

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
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public clMyCollection _Contenitore
		{
			get 
			{
				return _myColl;
			}
		}


		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			Ricerca();
		}
		
		#region FunzioniPrivate
		private void CaricaCombo()
		{
			//Carico il Combo degli Anni
			
			ListItem _L1 = new ListItem();				
			_L1.Text="- Tutti -";
			_L1.Value="0";				
			cmbsAnno.Items.Add(_L1);

			string anno_corrente = DateTime.Now.Year.ToString();
			for (int i = 1950; i <= 2051; i++)
			{ 	
				ListItem _L2 = new ListItem();				
				_L2.Text=i.ToString();
				_L2.Value=i.ToString();				
				cmbsAnno.Items.Add(_L2);
			}

			cmbsAnno.SelectedValue="0";		

			//Caricol il combo Del Tipo Intervento
			cmbsTipoIntervento.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ClassiAnagrafiche.TipoIntervento  _TipoIntervento = new TheSite.Classi.ClassiAnagrafiche.TipoIntervento();

			DataSet _MyDs;
			_MyDs = _TipoIntervento.GetData();
			

			if (_MyDs.Tables[0].Rows.Count > 0)
			{	
				this.cmbsTipoIntervento.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione_breve", "id", "- Tutti -", "0");
				this.cmbsTipoIntervento.DataTextField = "descrizione_breve";
				this.cmbsTipoIntervento.DataValueField = "id";
				this.cmbsTipoIntervento.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Tipo Intervento -";
				this.cmbsTipoIntervento.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}

		}

		private void Ricerca()
		{
			Classi.ClassiAnagrafiche.Fondi _Fondi = new TheSite.Classi.ClassiAnagrafiche.Fondi();
		
			S_ControlsCollection _SCollection = new S_ControlsCollection();
			_SCollection.AddItems(this.PanelRicerca.Controls);
			DataSet _MyDs = _Fondi.GetData(_SCollection).Copy();
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			if (_MyDs.Tables[0].Rows.Count == 0 )
			{
				DataGridRicerca.CurrentPageIndex=0;
			}
			else
			{
				int Pagina = 0;
				if ((_MyDs.Tables[0].Rows.Count % DataGridRicerca.PageSize) >0)
				{
					Pagina ++;
				}
				if (DataGridRicerca.PageCount != Convert.ToInt16((_MyDs.Tables[0].Rows.Count / DataGridRicerca.PageSize) + Pagina))
				{					
					DataGridRicerca.CurrentPageIndex=0;					
				}
			}

			this.DataGridRicerca.DataBind();					
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();
		}
		#endregion

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			Ricerca();
		}

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Dettaglio")
			{	
				_myColl.AddControl(this.Page.Controls, ParentType.Page);
				string s_url = e.CommandArgument.ToString();							
				Server.Transfer(s_url);				
			}
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{	
				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton3");
				_img1.Attributes.Add("title","Visualizza");

				ImageButton _img2 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton2");
				_img2.Attributes.Add("title","Modifica");

				e.Item.Cells[4].ToolTip=e.Item.Cells[8].Text;
				
			}
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
				Response.Redirect("Fondi.aspx?FunId=" + FunId);
		}
		
	}
}
