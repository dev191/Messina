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
	/// Descrizione di riepilogo per Ruoli.
	/// </summary>
	public class Ruoli : System.Web.UI.Page
	{
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_Button btnsRicerca;
		protected S_Controls.S_TextBox txtsDescrizione;
		protected S_Controls.S_TextBox txtsNote;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;

		public static int FunId = 0;
		protected S_Controls.S_ComboBox cmbsDitta;
		public static string HelpLink = string.Empty;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.GridTitle1.hplsNuovo.NavigateUrl = "../Admin/EditRuoli.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
			this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;	

			this.DataGridRicerca.Columns[1].Visible = _SiteModule.IsEditable;				
			this.DataGridRicerca.Columns[2].Visible = _SiteModule.IsEditable;				
						
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
			Classi.Ruolo _Ruolo = new TheSite.Classi.Ruolo();

			this.txtsDescrizione.DBDefaultValue = "%";
			this.txtsNote.DBDefaultValue = "%";			
                							
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			_SCollection.AddItems(this.PanelRicerca.Controls);

			DataSet _MyDs = _Ruolo.GetData(_SCollection).Copy();

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();
			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();		
		}

		private void BindControls()
		{
			Classi.ClassiAnagrafiche.Ditte _Ditta = new TheSite.Classi.ClassiAnagrafiche.Ditte();
			
			this.cmbsDitta.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
				_Ditta.GetData().Tables[0], "DESCRIZIONE", "ID", "", "0");
			this.cmbsDitta.DataTextField = "DESCRIZIONE";
			this.cmbsDitta.DataValueField = "ID";
			this.cmbsDitta.DataBind();

		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				HyperLink _lnk1 = (HyperLink) e.Item.Cells[2].FindControl("Hyperlink1");
				_lnk1.Attributes.Add("title","Modifica Ruolo");		
				
				HyperLink _lnk2 = (HyperLink) e.Item.Cells[1].FindControl("Hyperlink2");
				_lnk2.Attributes.Add("title","Associazione Ruolo Edifici");		
			}
		}

	}
}
