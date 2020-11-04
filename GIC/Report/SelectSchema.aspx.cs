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
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using System.Configuration;
namespace TheSite.GIC.Report
{
	/// <summary>
	/// Summary description for SelectSchema.
	/// </summary>
	public class SelectSchema : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DatagridVista;
		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
		protected System.Web.UI.WebControls.Panel pnlShowInfo;
		protected System.Web.UI.WebControls.DataGrid DatagridGlossario;
		protected System.Web.UI.WebControls.LinkButton lnkChiudi;
		protected System.Web.UI.WebControls.Label lblDettaglioVista;
		protected TheSite.WebControls.PageTitle PageTitle1;
		protected TheSite.WebControls.GridTitle Gridtitle2;
		protected TheSite.WebControls.GridTitleServer GridTitleServer1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNomeVista;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtIdVista;
		public static int FunId=0;
		private void Page_Load(object sender, System.EventArgs e)
		{
			TheSite.Classi.SiteModule  _SiteModule = (TheSite.Classi.SiteModule ) HttpContext.Current.Items["SiteModule"];
			PageTitle1.Title= _SiteModule.ModuleTitle;
			FunId = _SiteModule.ModuleId;
			Gridtitle2.hplsNuovo.Visible=false;
			
			// MDG Rendo visibile solo all'amministratore il link Nuovo
			GridTitleServer1.hplsNuovo.Visible=Context.User.IsInRole("amministratori");

			//ImgBtnElimina.Attributes.Add("onclick()","Verifica();");
			//GridTitle1.hplsNuovo.NavigateUrl = "../GIC/Report/NuovoSchema.aspx?FunId=" + _SiteModule.ModuleId;
			if (!IsPostBack)
			{
				Carica();
			}
		}
		private void Carica()
		{
			DataTable dt = DataViste();
			DatagridVista.DataSource = dt;
			DatagridVista.DataBind();
			GridTitleServer1.NumeroRecords =dt.Rows.Count.ToString();
		}
		private DataTable DataViste()
		{
			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			S_ControlsCollection param=new S_ControlsCollection();

			S_Object io_cursor = new S_Object();
			io_cursor.ParameterName = "io_cursor";
			io_cursor.Direction=ParameterDirection.Output;
			io_cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
			io_cursor.Index=1;
			param.Add(io_cursor);

			DataSet ds = _OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.GetSchemaViste");
			return ds.Tables[0];
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.DatagridVista.ItemDataBound  += new System.Web.UI.WebControls.DataGridItemEventHandler(this.ItemDataBound_ItemDataBound);
			this.lnkChiudi.Click += new System.EventHandler(this.lnkChiudi_Click);
			this.GridTitleServer1.hplsNuovo.Click += new System.EventHandler(this.Nuovo_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		protected void imgBtnVisualizza_Click(object sender, CommandEventArgs e)
		{
			string[] arrDatagridIthem  =  Convert.ToString(e.CommandArgument).Split(Convert.ToChar("-"));
			int IdVista = Convert.ToInt32(arrDatagridIthem[0].ToString());
			string NomeVista = arrDatagridIthem[1].ToString();
			
			Hashtable _HS = new Hashtable();
			_HS.Add("IdVista",IdVista);
			_HS.Add("NomeVista",NomeVista);
			Session.Remove("ParametriSelectSchema");
			Session.Add("ParametriSelectSchema",_HS);	
			Server.Transfer("DefaultReport.aspx");

		}
		protected void imgBtnDettaglioGlossario_Click(object sender,CommandEventArgs e)
		{
			string[] arrDatagridIthem  =  Convert.ToString(e.CommandArgument).Split(Convert.ToChar("-"));
			int IdVista = Convert.ToInt32(arrDatagridIthem[0].ToString());
			string NomeVista = arrDatagridIthem[1].ToString();
			
			if(IdVista == Convert.ToInt32(txtIdVista.Value) )
			{
				this.pnlShowInfo.Visible = !this.pnlShowInfo.Visible;
			}
			else
			{
				this.pnlShowInfo.Visible = true;
			}
			txtNomeVista.Value = NomeVista;
			txtIdVista.Value = IdVista.ToString();
			lblDettaglioVista.Text = " Dettaglio dei campi della vista " + NomeVista;
			DataTable dt = DataGlossario(IdVista);
			DatagridGlossario.DataSource = dt;
			DatagridGlossario.DataBind();
			Gridtitle2.NumeroRecords = dt.Rows.Count.ToString();
		}

		private DataTable DataGlossario(int IdVista)
		{
			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			S_ControlsCollection param=new S_ControlsCollection();

			S_Object pIdVista = new S_Object();
			pIdVista.ParameterName = "pIdVista";
			pIdVista.Direction=ParameterDirection.Input;
			pIdVista.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			pIdVista.Size = 32;
			pIdVista.Index=0;
			pIdVista.Value = IdVista;
			param.Add(pIdVista);

			S_Object io_cursor = new S_Object();
			io_cursor.ParameterName = "io_cursor";
			io_cursor.Direction=ParameterDirection.Output;
			io_cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
			io_cursor.Index=1;
			param.Add(io_cursor);

			DataSet ds = _OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.GetDettaglioGlossario");
			return ds.Tables[0];

		}
		private void lnkChiudi_Click(object sender, System.EventArgs e)
		{
			this.pnlShowInfo.Visible = false;
		}
		protected void Nuovo_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("NuovoSchema.aspx");
		}
		protected void imgBtnElimina_Click(object sender,CommandEventArgs e)
		{
			string[] arrDatagridIthem  =  Convert.ToString(e.CommandArgument).Split(Convert.ToChar("-"));
			int IdVista = Convert.ToInt32(arrDatagridIthem[0].ToString());
			string NomeVista = arrDatagridIthem[1].ToString();
			string Descrizione = arrDatagridIthem[2].ToString();

			Server.Transfer("EliminaVista.aspx?IdVista=" +IdVista + "&NomeVista=" + NomeVista + "&Descrizione=" + Descrizione);

//			Carica();

		}
		protected void btnAquisisci_Click(object sender,CommandEventArgs e)
		{
			string[] arrDatagridIthem  =  Convert.ToString(e.CommandArgument).Split(Convert.ToChar("-"));
			int IdVista = Convert.ToInt32(arrDatagridIthem[0].ToString());
			string NomeVista = arrDatagridIthem[1].ToString();
			StartParsingVista(NomeVista,IdVista);
			Carica();
		}

		private void StartParsingVista(string NomeVista,int IdVista)
		{
			TheSite.GIC.Classi.ParsingViste MakeParse = new TheSite.GIC.Classi.ParsingViste();
			//int Out= MakeParse.MakeParsing(NomeVista,IdVista);
			int Out= MakeParse.MakeParsing(NomeVista,IdVista);
		}
		
		private void ItemDataBound_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
					
			Button btnAquisisci;
			ImageButton imgBtnVisualizza;
			ImageButton imgBtnDettaglioGlossario;
			ImageButton imgBtnElimina;

			if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				btnAquisisci = (Button) e.Item.FindControl("btnAquisisci");
				imgBtnVisualizza = (ImageButton) e.Item.FindControl("imgBtnVisualizza");
				imgBtnDettaglioGlossario = (ImageButton) e.Item.FindControl("imgBtnDettaglioGlossario");
				imgBtnElimina = (ImageButton) e.Item.FindControl("imgBtnElimina");
								
				if (Context.User.IsInRole("amministratori"))
				{
					btnAquisisci.Attributes.Add("onclick", "return confirm('Si vuole procedere?')");	
					int acquisita = Convert.ToInt32(e.Item.Cells[4].Text);
					if(acquisita == 0)
					{
						btnAquisisci.Text = "Acquisisci la vista";
						imgBtnVisualizza.Visible = false;
						imgBtnDettaglioGlossario.Visible = false;

					}
					else
					{
						btnAquisisci.Text = "Vista già acquisita";
						btnAquisisci.Enabled = false;
						imgBtnVisualizza.Visible = true;
						imgBtnDettaglioGlossario.Visible = true;
					}
				}
				else
				{
					//MDG Imposto la visibilità dei pulsanti solo al ruolo amministratore
					imgBtnDettaglioGlossario.Visible=false;		
					imgBtnElimina.Visible=false;	
					btnAquisisci.Visible=false;
				}

	
			}
			

		}
	}
}
