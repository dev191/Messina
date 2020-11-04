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
using MyCollection;
using ApplicationDataLayer.DBType;

namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per Eqstd
	/// </summary>
	public class ListaMateriali : System.Web.UI.Page
	{	
		protected Csy.WebControls.DataPanel PanelRicerca;		
		protected S_Controls.S_Button btnsRicerca;		
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;	
		protected WebControls.PageTitle PageTitle1;
		public static int FunId=0;
		
		public static string HelpLink = string.Empty;
		TheSite.Gestione.EditMateriale _fp;
		protected S_Controls.S_TextBox txtCodMateriale;
		protected S_Controls.S_TextBox txtDescMateriale;
		protected S_Controls.S_ComboBox cmbUnita;
		protected S_Controls.S_Button btnReset;
		



		MyCollection.clMyCollection _myColl = new clMyCollection();
		private void Ricerca()
		{
			Classi.ClassiAnagrafiche.ListaMateriali _ListaMateriali = new Classi.ClassiAnagrafiche.ListaMateriali();
			this.txtCodMateriale.DBDefaultValue = "";
			this.txtDescMateriale.DBDefaultValue="";
			this.cmbUnita.DBDefaultValue="0";

			S_ControlsCollection _SCollection = new S_ControlsCollection();
			_SCollection.AddItems(this.PanelRicerca.Controls);

			DataSet _MyDs = _ListaMateriali.GetData(_SCollection).Copy();

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();		
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();
		}
		
		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
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

		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.GridTitle1.hplsNuovo.NavigateUrl = "../Gestione/EditMateriale.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
			this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;
			this.DataGridRicerca.Columns[1].Visible = true;
			this.DataGridRicerca.Columns[2].Visible = _SiteModule.IsEditable;	

			
			if(Request.QueryString["FunId"]!=null)
				FunId=Convert.ToInt32(Request.QueryString["FunId"]);
			else
				FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
						
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;			
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			
			
			if (!Page.IsPostBack)
			{
				BindUnita();
				if(Context.Handler is TheSite.Gestione.EditMateriale) 
				{	
					_fp = (TheSite.Gestione.EditMateriale) Context.Handler;
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
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.DataGridRicerca.SelectedIndexChanged += new System.EventHandler(this.DataGridRicerca_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		public MyCollection.clMyCollection _Contenitore
		{
			get 
			{
				return _myColl;
			}
		}
		private void BindUnita()
		{
			
			this.cmbUnita.Items.Clear();
		
			Classi.ClassiDettaglio.UnitaMisura _UnitaMisura = new TheSite.Classi.ClassiDettaglio.UnitaMisura(HttpContext.Current.User.Identity.Name); 	
			DataSet _MyDs = _UnitaMisura.GetData().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{				
				this.cmbUnita.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE_COD","IDUNITA", "- Selezionare Unità di Misura -", "0");
				this.cmbUnita.DataTextField = "DESCRIZIONE_COD";
				this.cmbUnita.DataValueField = "IDUNITA";
				this.cmbUnita.DataBind();
			}			
	
		}

		
		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			Ricerca();
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{					
				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("imgVisualizza");
				_img1.Attributes.Add("title","Visualizza");

				ImageButton _img2 = (ImageButton) e.Item.Cells[1].FindControl("imgModifica");
				_img2.Attributes.Add("title","Modifica");

			}
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ListaMateriali.aspx?FunId=" + FunId);
		}

		private void DataGridRicerca_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	

	}
}

