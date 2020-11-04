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

namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per Ditte.
	/// </summary>
	public class Fornitori : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		public static int FunId = 0;
		public static string HelpLink = string.Empty;
		MyCollection.clMyCollection _myColl = new clMyCollection();
		protected S_Controls.S_TextBox txtsIndirizzo;
		protected S_Controls.S_TextBox txtsComune;
		protected S_Controls.S_TextBox txtsEmail;
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;
		protected S_Controls.S_TextBox txtsFornitore;
		protected S_Controls.S_TextBox txtsTelefono;
		protected S_Controls.S_Button BtnReset;
		EditFornitori _fp;
	
		private void Page_Load(object sender, System.EventArgs e)
		{			
						
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.GridTitle1.hplsNuovo.NavigateUrl = "../Gestione/EditFornitori.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
			this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;	

			this.DataGridRicerca.Columns[1].Visible = true;
			this.DataGridRicerca.Columns[2].Visible = _SiteModule.IsEditable;				
						
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;			
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if (!Page.IsPostBack)
			{	
//				if (Request.Params["Ricarica"] == "yes")
					
				if(Context.Handler is TheSite.Gestione.EditFornitori) 
				{									
					_fp = (TheSite.Gestione.EditFornitori) Context.Handler;
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
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged_1);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
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
	
		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			Ricerca();
		}

//		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
//		{			
//			Classi.ClassiAnagrafiche.Ditte _Ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
//			if((e.Item.ItemType == ListItemType.Item) ||
//				(e.Item.ItemType == ListItemType.AlternatingItem))
//			{					
//				if (e.Item.Cells[5].Text.Trim() == "()")
//					e.Item.Cells[5].Text="";        									
//				// Reperisco i Servizi Associati e li associo al ToolTip
//				int id = Int32.Parse(e.Item.Cells[0].Text);
//				DataSet _MyDs = _Ditte.GetServiziDitta(id).Copy();
//							
//				if (_MyDs.Tables[0].Rows.Count>0)
//				{
//					string str_ToolTip=""; 	
//					foreach(DataRow Dr in _MyDs.Tables[0].Rows)				
//					{
//						str_ToolTip+=   Dr["Descrizione"] + "\r";
//					}
//					str_ToolTip=str_ToolTip.Substring(0,str_ToolTip.Length-1);
//					e.Item.ToolTip=str_ToolTip;		
//				}
//			}
//			
//		}
		private void Ricerca()
		{
			Classi.ClassiAnagrafiche.Fornitori _Fornitori = new TheSite.Classi.ClassiAnagrafiche.Fornitori();
			
			this.txtsComune.DBDefaultValue = "%";
			this.txtsFornitore.DBDefaultValue = "%";
			this.txtsEmail.DBDefaultValue = "%";
			this.txtsTelefono.DBDefaultValue = "%";
			this.txtsIndirizzo.DBDefaultValue = "%";	
			
			
			this.txtsComune.Text=this.txtsComune.Text.Trim();
			this.txtsFornitore.Text=this.txtsFornitore.Text.Trim();
			this.txtsEmail.Text=this.txtsEmail.Text.Trim();
			this.txtsTelefono.Text=this.txtsTelefono.Text.Trim();
			this.txtsIndirizzo.Text=this.txtsIndirizzo.Text.Trim();

			S_ControlsCollection _SCollection = new S_ControlsCollection();
			_SCollection.AddItems(this.PanelRicerca.Controls);
			DataSet _MyDs = _Fornitori.GetData(_SCollection).Copy();
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

	

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Dettaglio")
			{	
				_myColl.AddControl(this.Page.Controls, ParentType.Page);
				string s_url = e.CommandArgument.ToString();							
				Server.Transfer(s_url);				
			}
		}

		private void DataGridRicerca_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{		
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			Ricerca();
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

				//Formatto La data
				string _Comune = e.Item.Cells[5].Text.Trim();
				if (_Comune=="()") 
				{	
					e.Item.Cells[5].Text="";

				}								
			}
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
				Response.Redirect("Fornitori.aspx?FunId=" + FunId);
		}

		


		
	}
}
