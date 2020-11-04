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
using System.Web.UI.HtmlControls;
using System.Reflection; 

namespace TheSite.ManutenzioneProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per DettPianoAnnuale.
	/// </summary>
	public class DettPianoAnnuale : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected string ANNO = "";
		protected System.Web.UI.WebControls.Label lblpmp;
		protected System.Web.UI.WebControls.TextBox txtAnno;
		protected System.Web.UI.WebControls.TextBox txtID_BL;
		protected System.Web.UI.WebControls.TextBox txtServizio;
		protected System.Web.UI.WebControls.Button cmdIndietro;
		protected System.Web.UI.WebControls.LinkButton lkbInfo;
		protected System.Web.UI.WebControls.LinkButton lnkChiudi;
		protected System.Web.UI.WebControls.Repeater rptFrequenze;
		protected System.Web.UI.WebControls.Panel pnlShowInfo;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1; 
	    public string DirectoryUp=null;
		public static int FunId = 0;
		string DescServ="";

		public MyCollection.clMyCollection _Contenitore
		{
			get 
			{
				if(this.ViewState["mioContenitore"]!=null)
					return (MyCollection.clMyCollection)this.ViewState["mioContenitore"];
				else
					return new MyCollection.clMyCollection();
			}
		}
		private string e_Page 

		{ 
			get 
			{
				if ( ViewState["e_Page"]!=null) 
					return (string)ViewState["e_Page"]; 
				else 
					return ""; 
			} 

			set{ViewState["e_Page"]=value;}

		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			FunId = _SiteModule.ModuleId;
			if(!Page.IsPostBack)
			{
				GridTitle1.hplsNuovo.Visible = false;
				txtAnno.Text = Request.QueryString["anno"]; //Request.Params["anno"];
				txtID_BL.Text = Request.QueryString["ID_BL"];
				txtServizio.Text = Request.QueryString["servizio"];
				DescServ= Request.QueryString["descservizio"];
				this.e_Page=Request.QueryString["p"];
				if (this.e_Page=="ottimizza")
				{
					DirectoryUp="../";
					PageTitle1.Title="OTTIMIZZA IL PIANO"; 
				
				}
				lblpmp.Text= "Piano Manutenzione Programmata Anno: " + txtAnno.Text +" "+ DescServ;
				GetDataGrid();


		
				#region Recupero la proprieta di ricerca
				// Recupero il tipo dall'oggetto context.
				Type myType=Context.Handler.GetType();       
				// recupero il PropertyInfo object passando il nome della proprietà da recuperare.
				PropertyInfo myPropInfo = myType.GetProperty("_Contenitore");
			
				// verifico che questa proprietà esista.
				if(myPropInfo!=null)
					this.ViewState.Add("mioContenitore",myPropInfo.GetValue(Context.Handler,null));

				//				this.ViewState.Add("mioContenitore",this.GetProperty(Context.Handler,"_Contenitore",new clMyCollection()));
				#endregion
			}
		}
		private void GetDataGrid()
		{
			Classi.ManProgrammata.Planner _Planner = new TheSite.Classi.ManProgrammata.Planner();						
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_ID_BL = new S_Object();
			s_ID_BL.ParameterName = "p_id_Bl";
			s_ID_BL.DbType = CustomDBType.Integer;
			s_ID_BL.Direction = ParameterDirection.Input;
			s_ID_BL.Index = 0;
			s_ID_BL.Value = txtID_BL.Text ;			
			s_ID_BL.Size = 50;

			_SCollection.Add(s_ID_BL);

			S_Controls.Collections.S_Object s_Anno = new S_Object();
			s_Anno.ParameterName = "p_Anno";
			s_Anno.DbType = CustomDBType.Integer;
			s_Anno.Direction = ParameterDirection.Input;
			s_Anno.Index = 1;
			s_Anno.Value = txtAnno.Text ;			
			s_Anno.Size = 4;

			_SCollection.Add(s_Anno);

			S_Controls.Collections.S_Object s_Servizio = new S_Object();
			s_Servizio.ParameterName = "p_ID_Servizio";
			s_Servizio.DbType = CustomDBType.Integer;
			s_Servizio.Direction = ParameterDirection.Input;
			s_Servizio.Index = 2;
			s_Servizio.Value = txtServizio.Text ;			
			s_Servizio.Size = 50;

			_SCollection.Add(s_Servizio);

			DataSet _MyDs = _Planner.GetDataDett(_SCollection).Copy();

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();
			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();	
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
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.cmdIndietro.Click += new System.EventHandler(this.cmdIndietro_Click);
			this.lkbInfo.Click += new System.EventHandler(this.lkbInfo_Click);
			this.lnkChiudi.Click += new System.EventHandler(this.lnkChiudi_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;	
			GetDataGrid();
		}
		public string Colora(int Mese)	
		{				
			string s_colore = "";
			if (Mese == 0)
			{
				s_colore="ffffff";
			}
			else if (Mese == 1)
			{
				s_colore="808080";
			}
			else if (Mese == 2)
			{
				s_colore="00ff00";
			}
			else if (Mese == 3)	
			{
				s_colore="008000";
			}
			else if (Mese == 4)
			{
				s_colore="0000ff";
			}
			else if (Mese == 5)	
			{
				s_colore="000080";
			}
			else if (Mese == 6)
			{
				s_colore="c00000";
			}		
			else
			{
				s_colore="800000";				
			}
			return s_colore;		
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{ 
				
				HtmlAnchor lCol=(HtmlAnchor)e.Item.Controls[1].Controls[1];	
				if(this.e_Page=="ottimizza")
			        lCol.HRef="javascript:UpdateDettaglio('" + e.Item.Cells[0].Text  + "','" + e.Item.Cells[2].Text + "','" + txtAnno.Text + "','" + txtID_BL.Text + "','"  + e.Item.Cells[17].Text + "')";
				else
					lCol.HRef="javascript:Dettaglio('" + e.Item.Cells[0].Text  + "','" + e.Item.Cells[2].Text + "','" + txtAnno.Text + "')";
			
				string descrizione="";
				string note="";
				
				if (e.Item.Cells[2].Text.Trim().Length > 20) 
				{
					descrizione=e.Item.Cells[2].Text.Trim().Substring(0,18) + "..."; 
					e.Item.Cells[2].ToolTip=e.Item.Cells[2].Text;
					e.Item.Cells[2].Text=descrizione;
				} 
				
				if (e.Item.Cells[3].Text.Trim().Length >20) 
				{
					note=e.Item.Cells[3].Text.Trim().Substring(0,18) + "..."; 
					e.Item.Cells[3].ToolTip=e.Item.Cells[3].Text;
					e.Item.Cells[3].Text=note;
				} 

				if (e.Item.Cells[4].Text.Trim().Length > 10) 
				{
					note=e.Item.Cells[4].Text.Trim().Substring(0,10) + "..."; 
					e.Item.Cells[4].ToolTip=e.Item.Cells[4].Text;
					e.Item.Cells[4].Text=note.ToUpper();
				} 
				for (int index=5; index<=16; index++)
				{
					int i_red = 0;
					int i_green = 0;
					int i_blue = 0;
					string s_colore= Colora(Convert.ToInt16(e.Item.Cells[index].Text));
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

		private void cmdIndietro_Click(object sender, System.EventArgs e)
		{
			if(this.e_Page=="ottimizza")
			   Server.Transfer("Schedula/OttimizzaPiano.aspx"); 
			else
				Server.Transfer("PianoAnnuale.aspx?FunId=" + FunId ); 
		}
	}
}
