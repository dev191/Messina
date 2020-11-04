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
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using TheSite.Classi.ClassiDettaglio;
using MyCollection; 

namespace TheSite.Admin
{
	/// <summary>
	/// Descrizione di riepilogo per Funzioni.
	/// </summary>
	public class Funzioni : System.Web.UI.Page
	{
		protected S_Controls.S_TextBox txtsDescrizione;
		protected S_Controls.S_TextBox txtsCodice;
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;	
		protected WebControls.PageTitle PageTitle1;

		public static int FunId = 0;
		public static string HelpLink = string.Empty;	
	
		TheSite.Admin.EditFunzioni _fp;
		MyCollection.clMyCollection _myColl = new MyCollection.clMyCollection();
		
		public MyCollection.clMyCollection _Contenitore
		{
			get {return _myColl;}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.GridTitle1.hplsNuovo.NavigateUrl = "../Admin/EditFunzioni.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
			this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;	

			this.DataGridRicerca.Columns[1].Visible = _SiteModule.IsEditable;				
						
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			
			
			
			if (!IsPostBack) 
			{
				if(Context.Handler is TheSite.Admin.EditFunzioni)
				{
					_fp = (TheSite.Admin.EditFunzioni)Context.Handler;

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			Ricerca();
		}

		private void Ricerca()
		{
			Classi.Funzione _Funzione = new TheSite.Classi.Funzione();

			this.txtsDescrizione.DBDefaultValue = "%";
			this.txtsCodice.DBDefaultValue = "%";
							
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			_SCollection.AddItems(this.PanelRicerca.Controls);

			DataSet _MyDs = _Funzione.GetData(_SCollection).Copy();

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();
			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();		
		
		}
	}
}
