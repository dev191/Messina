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
	/// Descrizione di riepilogo per UnitaMisura.
	/// </summary>
	public class UnitaMisura : System.Web.UI.Page
		{	
			protected Csy.WebControls.DataPanel PanelRicerca;		
			protected S_Controls.S_Button btnsRicerca;		
			protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
			protected WebControls.GridTitle GridTitle1;	
			protected WebControls.PageTitle PageTitle1;
			public static int FunId=0;
		
			public static string HelpLink = string.Empty;
			TheSite.Gestione.EditMisura _fp;

			protected S_Controls.S_TextBox txtDescMisura;
			protected S_Controls.S_TextBox txtCodMisura;
			protected S_Controls.S_Button btnReset;
		



			MyCollection.clMyCollection _myColl = new clMyCollection();
			private void Ricerca()
			{
				Classi.ClassiAnagrafiche.UnitaMisura _UnitaMisura = new Classi.ClassiAnagrafiche.UnitaMisura();
				this.txtDescMisura.DBDefaultValue="";
				this.txtCodMisura.DBDefaultValue = "";

				S_ControlsCollection _SCollection = new S_ControlsCollection();
				_SCollection.AddItems(this.PanelRicerca.Controls);

				
				DataSet _MyDs = _UnitaMisura.GetData(_SCollection).Copy();

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
				this.GridTitle1.hplsNuovo.NavigateUrl = "../Gestione/EditMisura.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
				this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;
				this.DataGridRicerca.Columns[1].Visible = true;
				this.DataGridRicerca.Columns[2].Visible = _SiteModule.IsEditable;	

				FunId = _SiteModule.ModuleId;
				HelpLink = _SiteModule.HelpLink;
				this.PageTitle1.Title = _SiteModule.ModuleTitle;
						
				FunId = _SiteModule.ModuleId;
				HelpLink = _SiteModule.HelpLink;
				this.PageTitle1.Title = _SiteModule.ModuleTitle;			
				// Inserire qui il codice utente necessario per inizializzare la pagina.
			
			
				if (!Page.IsPostBack)
				{
					if(Context.Handler is TheSite.Gestione.EditMisura) 
					{	
						_fp = (TheSite.Gestione.EditMisura) Context.Handler;
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
				Response.Redirect("UnitaMisura.aspx?FunId=" + FunId);
			}

			private void DataGridRicerca_SelectedIndexChanged(object sender, System.EventArgs e)
			{
		
			}
	

		}
	}

