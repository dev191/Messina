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
	public class Buildings : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;
		public static int FunId = 0;
		public static string HelpLink = string.Empty;
		protected WebControls.PageTitle PageTitle1;

		MyCollection.clMyCollection _myColl = new clMyCollection();
		protected S_Controls.S_TextBox txtsBL_ID;
		protected S_Controls.S_TextBox txtsName;
		protected S_Controls.S_TextBox txtsIndirizzo;
		protected S_Controls.S_TextBox txtsReferente;
		protected S_Controls.S_TextBox txtsComune;
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_Button BtnReset;
		protected System.Web.UI.WebControls.Button btnEsporta;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label lbMessage;
		protected S_Controls.S_ComboBox CmbProgetto;
		EditBuilding _fp;

		public MyCollection.clMyCollection _Contenitore
		{
			get 
			{
				return _myColl;
			}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{			
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.GridTitle1.hplsNuovo.NavigateUrl = "../Gestione/EditBuilding.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
			this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;	

			this.DataGridRicerca.Columns[1].Visible = true;
			this.DataGridRicerca.Columns[2].Visible = _SiteModule.IsEditable;				
						
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;

			this.PageTitle1.Title = _SiteModule.ModuleTitle;	
//			txtsBL_ID.Attributes.Add("onkeypress","SoloNumeri();");
			txtsBL_ID.Attributes.Add("onpaste","return false;");

			if (!Page.IsPostBack)
			{	
				BindProgetti();

				if(Context.Handler is TheSite.Gestione.EditBuilding) 
				{									
					_fp = (TheSite.Gestione.EditBuilding) Context.Handler;
					if (_fp!=null)
					{
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);
						Ricerca();
					}
				}	
			}
		}
		private void BindProgetti()
		{
			
			this.CmbProgetto.Items.Clear();
		
			TheSite.Classi.Progetti _Prog = new TheSite.Classi.Progetti();
						
			DataSet _MyDs = _Prog.GetData();			
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				CmbProgetto.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "id_progetto", "- Selezionare un Progetto -", "0");				
				this.CmbProgetto.DataTextField ="descrizione";
				this.CmbProgetto.DataValueField  ="id_progetto";
				this.CmbProgetto.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Progetto  -";
				this.CmbProgetto.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
						
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.btnsRicerca.Click += new System.EventHandler(this.btnsRicerca_Click);
			this.btnEsporta.Click += new System.EventHandler(this.btnEsporta_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound_1);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			DataGridRicerca.CurrentPageIndex=0;
			Ricerca();
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{			
			Classi.ClassiAnagrafiche.Ditte _Ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{					
				if (e.Item.Cells[5].Text.Trim() == "()")
					e.Item.Cells[5].Text="";        									
				// Reperisco i Servizi Associati e li associo al ToolTip
				int id = Int32.Parse(e.Item.Cells[0].Text);
				DataSet _MyDs = _Ditte.GetServiziDitta(id).Copy();
							
				if (_MyDs.Tables[0].Rows.Count>0)
				{
					string str_ToolTip=""; 	
					foreach(DataRow Dr in _MyDs.Tables[0].Rows)				
					{
						str_ToolTip+=   Dr["Descrizione"] + "\r";
					}
					str_ToolTip=str_ToolTip.Substring(0,str_ToolTip.Length-1);
					e.Item.ToolTip=str_ToolTip;		
				}
			}
			
		}
		private DataSet GetDataBuilding()
		{
			Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();

			this.txtsBL_ID.DBDefaultValue="%";
			this.txtsName.DBDefaultValue="%";
			this.txtsIndirizzo.DBDefaultValue = "%";	
			this.txtsReferente.DBDefaultValue = "%";
			this.txtsComune.DBDefaultValue = "%";
			
			this.txtsBL_ID.Text=this.txtsBL_ID.Text.Trim();
			this.txtsName.Text=this.txtsName.Text.Trim();
			this.txtsIndirizzo.Text=this.txtsIndirizzo.Text.Trim();
			this.txtsReferente.Text=this.txtsReferente.Text.Trim();
			this.txtsComune.Text=this.txtsComune.Text.Trim();

			S_ControlsCollection _SCollection = new S_ControlsCollection();
			_SCollection.AddItems(this.PanelRicerca.Controls);
			DataSet _MyDs = _Buildings.GetData(_SCollection).Copy();
			return  _MyDs;
		}
		private void Ricerca()
		{

			DataSet _MyDs = GetDataBuilding();
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
				if (DataGridRicerca.PageCount != Convert.ToInt32((_MyDs.Tables[0].Rows.Count / DataGridRicerca.PageSize) + Pagina))
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

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			Ricerca();

		}

		private void DataGridRicerca_ItemDataBound_1(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{					
				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("ImgBtnDettaglio");
				_img1.Attributes.Add("title","Visualizza");

				ImageButton _img2 = (ImageButton) e.Item.Cells[1].FindControl("ImgBtnEdit");
				_img2.Attributes.Add("title","Modifica");
			
			}
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Buildings.aspx?FunId=" + FunId);
		}

		private void btnEsporta_Click(object sender, System.EventArgs e)
		{
			DataSet ds = GetDataBuilding();
			Csy.WebControls.Export 	_objExport = new Csy.WebControls.Export();
			DataTable _dt = new DataTable();			
			_dt = ds.Tables[0].Copy();	
			if (_dt.Rows.Count != 0)
			{
				_objExport.ExportDetails(_dt, Csy.WebControls.Export.ExportFormat.Excel, "exp.xls" ); 		
			}
			else
			{
				String scriptString = "<script language=JavaScript>alert('Nessun elemento da esportare');";
				scriptString += "<";
				scriptString += "/";
				scriptString += "script>";

				if(!this.IsClientScriptBlockRegistered("clientScriptexp"))
					this.RegisterStartupScript ("clientScriptexp", scriptString);
			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Classi.ClassiAnagrafiche.Buildings clBl =new TheSite.Classi.ClassiAnagrafiche.Buildings();
			int cc = clBl.UpdateAllFl();
			if (cc==0)
			{
				lbMessage.Text="ERRORE nel calcolo delle superfici.";
				lbMessage.ForeColor=Color.Red;
			} 
			else 
			{
				lbMessage.Text="Calcolo delle superfici eseguito con SUCCESSO.";
			}
		}

	}
}
