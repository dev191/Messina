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
	/// Descrizione di riepilogo per PmpFrequenza.
	/// </summary>
	public class PmpFrequenza : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected S_Controls.S_TextBox txtsFrequenza_des;
		protected S_Controls.S_TextBox txtsFrequenza;	
		protected Csy.WebControls.DataPanel PanelRicerca;		
		protected S_Controls.S_Button btnsRicerca;		
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;	
		protected WebControls.PageTitle PageTitle1;
		public static int FunId=0;
		public static string HelpLink = string.Empty;
		clMyCollection _myColl = new clMyCollection();
		protected S_Controls.S_Button BtnReset;
		EditPmpFrequenza _fp;
	

		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.GridTitle1.hplsNuovo.NavigateUrl = "../Gestione/EditPmpFrequenza.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
			this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;	

			this.DataGridRicerca.Columns[1].Visible = _SiteModule.IsEditable;				
						
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
		
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			
			if (!Page.IsPostBack)
			{					
				if(Context.Handler is TheSite.Gestione.EditPmpFrequenza) 
				{									
					_fp = (TheSite.Gestione.EditPmpFrequenza) Context.Handler;
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

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Dettaglio")
			{	
				_myColl.AddControl(this.Page.Controls, ParentType.Page);
				string s_url = e.CommandArgument.ToString();							
				Server.Transfer(s_url);		
			}
		}

		private void Ricerca()
		{
			
			Classi.ClassiAnagrafiche.PmpFrequenza _PmpFrequenza= new Classi.ClassiAnagrafiche.PmpFrequenza();
			this.txtsFrequenza.DBDefaultValue ="%";
			this.txtsFrequenza_des.DBDefaultValue="%";
			S_ControlsCollection _SCollection = new S_ControlsCollection();
			_SCollection.AddItems(this.PanelRicerca.Controls);
			DataSet _MyDs = _PmpFrequenza.GetData(_SCollection).Copy();

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

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{	
				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton3");
				_img1.Attributes.Add("title","Visualizza");

				ImageButton _img2 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton1");
				_img2.Attributes.Add("title","Modifica");


				// PAOLO 24/02/06: scambio la dicitura Fisso e Periodico considerando che:
				// se il campo FIXED ha ZERO (FALSE) il record è PERIODICO

					if(e.Item.Cells[4].Text=="0")
						e.Item.Cells[4].Text="Periodico";
					else
						e.Item.Cells[4].Text="Fisso";

					if(e.Item.Cells[8].Text=="0")
						e.Item.Cells[8].Text="NO";
					else
						e.Item.Cells[8].Text="SI";	
				
			}
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
				Response.Redirect("PmpFrequenza.aspx?FunId=" + FunId);
		}
	}
}
