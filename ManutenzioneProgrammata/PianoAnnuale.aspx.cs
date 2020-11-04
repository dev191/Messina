using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using MyCollection;

namespace TheSite.ManutenzioneProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per PianoAnnuale.
	/// </summary>
	public class PianoAnnuale : System.Web.UI.Page
	{
		protected S_Controls.S_ComboBox cmbsServizio;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected S_Controls.S_ComboBox cmbsAnno;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;
		protected WebControls.RicercaModulo RicercaModulo1;

		public static int FunId = 0;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_Button btnsRicerca;
		protected System.Web.UI.WebControls.LinkButton lkbInfo;
		protected System.Web.UI.WebControls.LinkButton lnkChiudi;
		protected System.Web.UI.WebControls.Panel pnlShowInfo;
		protected System.Web.UI.WebControls.Repeater rptFrequenze;
		public static string HelpLink = string.Empty;

		MyCollection.clMyCollection _myColl = new clMyCollection();
		protected System.Web.UI.WebControls.Panel PagePanel;
		protected System.Web.UI.WebControls.Button cmdReset;
		DettPianoAnnuale _fp;

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
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;

			RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);

			if(!Page.IsPostBack)
			{				
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];
				try
				{
					
					DataGridRicerca.Visible = false;
					BindAnno();
					GridTitle1.hplsNuovo.Visible = false;
					BindServizio("");

					if(Context.Handler is TheSite.ManutenzioneProgrammata.DettPianoAnnuale)
					{
						_fp = (TheSite.ManutenzioneProgrammata.DettPianoAnnuale)Context.Handler;
						if (_fp!=null) 
						{
							_myColl=_fp._Contenitore;
							_myColl.SetValues(this.Page.Controls);		
							//_myColl.SetValues(this.RicercaModulo1);
							RicercaModulo1.Ricarica();
							Ricerca(true);
						}
					}					
				} 
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message); 
				}
			}
		}

		void BindAnno()
		{
			Int32 i_anno = DateTime.Now.Year;
			Int16 i_index= 0;
			for (int counter = i_anno - 10; counter <= i_anno + 10; counter++)
			{
				cmbsAnno.Items.Add(counter.ToString());				
				if (i_anno == counter)
				{
					cmbsAnno.Items[i_index].Selected = true;
				}
				i_index ++;
			}


		}

		private void BindServizio(string CodEdificio)
		{
			
			DataGridRicerca.Visible = false;
			this.cmbsServizio.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ClassiDettaglio.Servizi  _Servizio = new TheSite.Classi.ClassiDettaglio.Servizi(Context.User.Identity.Name);

			DataSet _MyDs;

			if (CodEdificio!="")
			{
				S_Controls.Collections.S_Object s_Bl_Id = new S_Object();
				s_Bl_Id.ParameterName = "p_Bl_Id";
				s_Bl_Id.DbType = CustomDBType.VarChar;
				s_Bl_Id.Direction = ParameterDirection.Input;
				s_Bl_Id.Index = 0;
				s_Bl_Id.Value =	CodEdificio;
				s_Bl_Id.Size = 8;

				
				S_Controls.Collections.S_Object s_ID_Servizio = new S_Object();
				s_ID_Servizio.ParameterName = "p_ID_Servizio";
				s_ID_Servizio.DbType = CustomDBType.Integer;
				s_ID_Servizio.Direction = ParameterDirection.Input;
				s_ID_Servizio.Index = 1;
				s_ID_Servizio.Value = 0;

				CollezioneControlli.Add(s_Bl_Id);				
				CollezioneControlli.Add(s_ID_Servizio);

				_MyDs = _Servizio.GetData(CollezioneControlli);
			}
			else
			{
				_MyDs = _Servizio.GetData();
			}

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "");
				this.cmbsServizio.DataTextField = "DESCRIZIONE";
				this.cmbsServizio.DataValueField = "IDSERVIZIO";
				this.cmbsServizio.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Servizio -";
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
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
			this.cmbsAnno.SelectedIndexChanged += new System.EventHandler(this.cmbsAnno_SelectedIndexChanged);
			this.cmbsServizio.SelectedIndexChanged += new System.EventHandler(this.cmbsServizio_SelectedIndexChanged);
			this.btnsRicerca.Click += new System.EventHandler(this.btnsRicerca_Click);
			this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
			this.lkbInfo.Click += new System.EventHandler(this.lkbInfo_Click);
			this.lnkChiudi.Click += new System.EventHandler(this.lnkChiudi_Click);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{	
			DataGridRicerca.CurrentPageIndex =0;
			Ricerca(true);
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{ 
				string descrizione="";
				string note="";
				
				if (e.Item.Cells[3].Text.Trim().Length > 20) 
				{
					descrizione=e.Item.Cells[3].Text.Trim().Substring(0,18) + "..."; 
					e.Item.Cells[3].ToolTip=e.Item.Cells[3].Text;
					e.Item.Cells[3].Text=descrizione;
				} 
				
				if (e.Item.Cells[4].Text.Trim().Length >20) 
				{
					note=e.Item.Cells[4].Text.Trim().Substring(0,18) + "..."; 
					e.Item.Cells[4].ToolTip=e.Item.Cells[4].Text;
					e.Item.Cells[4].Text=note;
				} 

				if (e.Item.Cells[5].Text.Trim().Length > 10) 
				{
					note=e.Item.Cells[5].Text.Trim().Substring(0,10) + "..."; 
					e.Item.Cells[5].ToolTip=e.Item.Cells[5].Text;
					e.Item.Cells[5].Text=note.ToUpper();
				} 
				for (int index=6; index<=17; index++)
				{
					int i_red = 0;
					int i_green = 0;
					int i_blue = 0;
					string s_colore= Colora(Convert.ToInt32(e.Item.Cells[index].Text));
					i_red = Convert.ToInt16(s_colore.Substring(0,2),16);
					i_green = Convert.ToInt16(s_colore.Substring(2,2),16);
					i_blue = Convert.ToInt16(s_colore.Substring(4,2),16);				
					e.Item.Cells[index].BackColor= System.Drawing.Color.FromArgb(i_red,i_green,i_blue);
					e.Item.Cells[index].BorderColor=System.Drawing.Color.Black ;
					e.Item.Cells[index].BorderWidth=1;
					e.Item.Cells[index].ForeColor=System.Drawing.Color.Black;
				}
			}
		}

		public string Colora(int Mese)	
		{				
			string s_colore = "";
			if (Mese < 10)
			{
				s_colore="ffffff";
			}
			else if (Mese < 20)
			{
				s_colore="808080";
			}
			else if (Mese < 30)
			{
				s_colore="00ff00";
			}
			else if (Mese < 40)	
			{
				s_colore="008000";
			}
			else if (Mese < 50)
			{
				s_colore="0000ff";
			}
			else if (Mese < 60)	
			{
				s_colore="000080";
			}
			else if (Mese < 70)
			{
				s_colore="c00000";
			}
			else
			{
					s_colore="800000";				
			}
			return s_colore;		
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			Ricerca(false);

		}		
		private void Ricerca(bool reset)
		{
			Classi.ManProgrammata.Planner _Planner = new TheSite.Classi.ManProgrammata.Planner(Context.User.Identity.Name);						
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_Bl_Id = new S_Controls.Collections.S_Object();
			s_p_Bl_Id.ParameterName = "p_Bl_Id";
			s_p_Bl_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Bl_Id.Direction = ParameterDirection.Input;
			s_p_Bl_Id.Size =50;
			s_p_Bl_Id.Index = 0;
			s_p_Bl_Id.Value = RicercaModulo1.TxtCodice.Text;
			_SCollection.Add(s_p_Bl_Id);

			S_Controls.Collections.S_Object s_p_campus = new S_Controls.Collections.S_Object();
			s_p_campus.ParameterName = "p_campus";
			s_p_campus.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_campus.Direction = ParameterDirection.Input;
			s_p_campus.Index = 2;
			s_p_campus.Size=50;
			s_p_campus.Value = RicercaModulo1.TxtRicerca.Text;			
			_SCollection.Add(s_p_campus);

			S_Controls.Collections.S_Object s_p_anno = new S_Controls.Collections.S_Object();
			s_p_anno.ParameterName = "p_Anno";
			s_p_anno.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Index = 3;
			s_p_anno.Size=4;
			s_p_anno.Value = cmbsAnno.SelectedItem.ToString();			
			_SCollection.Add(s_p_anno);


			S_Controls.Collections.S_Object s_p_Servizio = new S_Controls.Collections.S_Object();
			s_p_Servizio.ParameterName = "p_ID_Servizio";
			s_p_Servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Servizio.Direction = ParameterDirection.Input;
			s_p_Servizio.Index = 3;
			s_p_Servizio.Value = (cmbsServizio.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsServizio.SelectedValue);			
			_SCollection.Add(s_p_Servizio);
		
			S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
			s_p_pageindex.ParameterName = "pageindex";
			s_p_pageindex.DbType = CustomDBType.Integer;
			s_p_pageindex.Direction = ParameterDirection.Input;
			s_p_pageindex.Index = 16;
			s_p_pageindex.Value=DataGridRicerca.CurrentPageIndex +1;			
			_SCollection.Add(s_p_pageindex);

			S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
			s_p_pagesize.ParameterName = "pagesize";
			s_p_pagesize.DbType = CustomDBType.Integer;
			s_p_pagesize.Direction = ParameterDirection.Input;
			s_p_pagesize.Index = 17;
			s_p_pagesize.Value= DataGridRicerca.PageSize;			
			_SCollection.Add(s_p_pagesize);

			DataSet _MyDs = _Planner.GetData(_SCollection).Copy();

			if (reset==true)
			{

				_SCollection.RemoveAt(_SCollection.Count -1); 
				_SCollection.RemoveAt(_SCollection.Count -1);
				_SCollection.RemoveAt(_SCollection.Count -1); 
				_SCollection.RemoveAt(_SCollection.Count -1);
				int _totalRecords = _Planner.GetDataCount(_SCollection);
				this.GridTitle1.NumeroRecords=_totalRecords.ToString();
			}

			DataGridRicerca.Visible =true;
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.VirtualItemCount =int.Parse(this.GridTitle1.NumeroRecords);
			this.DataGridRicerca.DataBind();	
		}

		private void lkbInfo_Click(object sender, System.EventArgs e)
		{
			Classi.ManProgrammata.Planner _Planner = new TheSite.Classi.ManProgrammata.Planner();
			this.pnlShowInfo.Visible = true;
			rptFrequenze.DataSource = _Planner.GetFrequenze();
			rptFrequenze.DataBind();
		}

		private void lnkChiudi_Click(object sender, System.EventArgs e)
		{
			this.pnlShowInfo.Visible = false;
		}

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Dettaglio")
			{
				//_myColl.AddControl(RicercaModulo1.Controls, ParentType.WebControl);
				//_myColl.AddControl(PagePanel.Controls, ParentType.Page);
				_myColl.AddControl(this.Page.Controls,ParentType.Page );
				string s_url = e.CommandArgument.ToString();							
				Server.Transfer(s_url);				
			}
		}

		private void cmbsAnno_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataGridRicerca.Visible = false;
		}

		private void cmbsServizio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataGridRicerca.Visible = false;
		}

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("PianoAnnuale.aspx?FunID=" + ViewState["FunId"]);
		}
	}
}
