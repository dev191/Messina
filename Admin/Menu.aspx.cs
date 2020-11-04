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
	/// Descrizione di riepilogo per Menu.
	/// </summary>
	public class Menu : System.Web.UI.Page
	{
		
		protected S_Controls.S_TextBox txtsDescrizione;
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected S_Controls.S_TextBox txtsCssClass;		
		protected WebControls.GridTitle GridTitle1;
		protected S_Controls.S_ComboBox cmbsMenuPadre;
		protected S_Controls.S_ComboBox cmbsFunzione;	
		protected WebControls.PageTitle PageTitle1;

		public static int FunId = 0;
		public static string HelpLink = string.Empty;
		private DataGridItem _PrevItem = null;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.GridTitle1.hplsNuovo.NavigateUrl = "../Admin/EditMenu.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
			this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;	

			this.DataGridRicerca.Columns[1].Visible = _SiteModule.IsEditable;				
						
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			if (!Page.IsPostBack)
				this.BindControls();
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
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			Classi.Menu _Menu = new TheSite.Classi.Menu();

			this.txtsDescrizione.DBDefaultValue = "%";
			this.txtsCssClass.DBDefaultValue = "%";			
                							
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			_SCollection.AddItems(this.PanelRicerca.Controls);

			DataSet _MyDs = _Menu.GetData(_SCollection).Copy();

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();
			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();		
		}

		private void BindControls()
		{
			Classi.Funzione _Funzioni = new TheSite.Classi.Funzione();

			this.cmbsFunzione.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
				_Funzioni.GetData().Tables[0], "DESCRIZIONE", "ID", "", "0");
			this.cmbsFunzione.DataTextField = "DESCRIZIONE";
			this.cmbsFunzione.DataValueField = "ID";
			this.cmbsFunzione.DataBind();

			Classi.Menu _Menu = new TheSite.Classi.Menu();
			this.cmbsMenuPadre.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
				_Menu.GetDataMenuPadre().Tables[0], "DESCRIZIONE", "ID", "", "-1");
			this.cmbsMenuPadre.DataTextField = "DESCRIZIONE";
			this.cmbsMenuPadre.DataValueField = "ID";
			this.cmbsMenuPadre.DataBind();

		}

		private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			DataGridItem _CurrItem = e.Item;

			if (_CurrItem.ItemType == ListItemType.Item || _CurrItem.ItemType == ListItemType.AlternatingItem)
			{
				if (_PrevItem != null)
				{
					if (_PrevItem.Cells[2].Text == _CurrItem.Cells[4].Text)
					{
						_CurrItem.Font.Italic = true;
						_CurrItem.Font.Size = FontUnit.Smaller;
						_CurrItem.Cells[2].Text = "<font color=#ff6600><LI type=square>&nbsp;</LI></font>" + _CurrItem.Cells[2].Text;
					}
					else
						_PrevItem = _CurrItem;
				}
				else
					_PrevItem = _CurrItem;
			}
		}
	}
}
