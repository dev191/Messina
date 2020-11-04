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
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using ApplicationDataLayer.Collections;
  
namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per Fondi.
	/// </summary>
	public class Fondi : System.Web.UI.Page
	{
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		public static int FunId = 0;
		public static string HelpLink = string.Empty;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;
		MyCollection.clMyCollection _myColl = new clMyCollection();

		EditFondi _fp;
		protected System.Web.UI.WebControls.TextBox txtCodiceFondo;
		protected S_Controls.S_Button BtnReset;		
		protected System.Web.UI.WebControls.DropDownList DrMeseini;
		protected System.Web.UI.WebControls.DropDownList DrAnnoIni;
		protected System.Web.UI.WebControls.DropDownList DrMesefine;
		protected System.Web.UI.WebControls.DropDownList DrAnnofine;
		
	
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
				LoadMese();
				LoadAnno();

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

		private void LoadMese()
		{
			DrMesefine.Items.Add(new ListItem("- Nessun Mese -","0"));
			DrMeseini.Items.Add(new ListItem("- Nessun Mese -","0"));
			ArrayList ar=new ArrayList();
			ar.Add(new ListItem("Gennaio","1")); 
			ar.Add(new ListItem("Febbraio","2")); 
			ar.Add(new ListItem("Marzo","3")); 
			ar.Add(new ListItem("Aprile","4")); 
			ar.Add(new ListItem("Maggio","5")); 
			ar.Add(new ListItem("Giugno","6")); 
			ar.Add(new ListItem("Luglio","7")); 
			ar.Add(new ListItem("Agosto","8")); 
			ar.Add(new ListItem("Settembre","9")); 
			ar.Add(new ListItem("Ottobre","10")); 
			ar.Add(new ListItem("Novembre","11")); 
			ar.Add(new ListItem("Dicembre","12")); 
			for(int i=0;i<=ar.Count-1;i++)
			{
				DrMesefine.Items.Add((ListItem)ar[i]);
				DrMeseini.Items.Add((ListItem)ar[i]);
			}
		}
		private void LoadAnno()
		{
			DrAnnofine.Items.Add(new ListItem("- Nessun Anno -","0"));
			DrAnnoIni.Items.Add(new ListItem("- Nessun Anno -","0"));

			for (int i=2000; i<= DateTime.Now.Year +20; i++)
			{
				DrAnnofine.Items.Add(new ListItem(i.ToString(),i.ToString()));
				DrAnnoIni.Items.Add(new ListItem(i.ToString(),i.ToString()));
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
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
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
		
		#region FunzioniPrivate

		private void Ricerca()
		{
			Classi.ClassiAnagrafiche.Fondi _Fondi = new TheSite.Classi.ClassiAnagrafiche.Fondi();
		
			S_ControlsCollection _SCollection = new S_ControlsCollection();
		
			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_meseini";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Size=10;
			p.Index = _SCollection.Count;
			if(DrMeseini.SelectedValue=="0")
				p.Value=DBNull.Value; 
			else
				p.Value=DrMeseini.SelectedValue;   
			_SCollection.Add(p);

			p = new S_Object();
			p.ParameterName = "p_mesefine";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Size=10;
			p.Index = _SCollection.Count;
			if(DrMesefine.SelectedValue=="0")
				p.Value=DBNull.Value; 
			else
				p.Value=DrMesefine.SelectedValue;  
			_SCollection.Add(p);

			p = new S_Object();
			p.ParameterName = "p_annoini";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Size=10;
			p.Index = _SCollection.Count;
			if(DrAnnoIni.SelectedValue=="0")
				p.Value=DBNull.Value;
			else
                p.Value=DrAnnoIni.SelectedValue;   
			_SCollection.Add(p);

			p = new S_Object();
			p.ParameterName = "p_annofine";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Size=10;
			p.Index = _SCollection.Count;
			if(DrAnnofine.SelectedValue=="0")
				p.Value=DBNull.Value;
			else
				p.Value=DrAnnofine.SelectedValue; 
			_SCollection.Add(p);

			p = new S_Object();
			p.ParameterName = "p_codicefondo";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = _SCollection.Count;
			p.Size=100;
			if(txtCodiceFondo.Text=="") 
				p.Value = DBNull.Value;
			else
				p.Value=txtCodiceFondo.Text;  
			_SCollection.Add(p);

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
