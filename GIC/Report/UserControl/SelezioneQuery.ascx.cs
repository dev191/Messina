namespace GIC.Report.UserControl
{
	using System;
	using System.Collections;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using App_Code.Datagrid;
	using S_Controls;
	using S_Controls.Collections;
	using ApplicationDataLayer;

	/// <summary>
	///		Descrizione di riepilogo per SelezioneQuery.
	/// </summary>
	public class SelezioneQuery : App_Code.BaseControl
	{
		protected S_Controls.S_TextBox TextBox1;
		protected System.Web.UI.WebControls.Button TxtSuchen;
		protected System.Web.UI.WebControls.Button BtnNeu;
		protected TheSite.GIC.App_Code.DataSetDef.DataSetReport dataSetReport1;
		protected System.Web.UI.WebControls.DataGrid DataGridQuery;
		protected System.Web.UI.HtmlControls.HtmlTable TableQuery;
		protected new  System.Web.UI.WebControls.Label LabelMessage ;
		protected S_Controls.S_TextBox TextBox2; 
		protected int IdVista;
		protected System.Web.UI.WebControls.Button BtnIndietro;
		protected string NomeVista;

		private void Page_Load(object sender, System.EventArgs e)
		{
			ControlloDatagrid=new QueryDTControl(DataGridQuery);
			base.LabelMessage=this.LabelMessage;
			if(!IsPostBack)
			{
				BindDataGrid();
				
			}
			//Hashtable _HS=(Hashtable) Session["ParametriSelectSchema"];
			//IdVista = Convert.ToInt32(_HS["IdVista"]);
			//NomeVista = Convert.ToString(_HS["NomeVista"]);
		}

		public void Ricarica()
		{
			BindDataGrid();
		}

		protected override void BindDataGrid()
		{			
			SetParamQuery();
			base.DataGridDati=this.DataGridQuery;
			if (!IsPostBack)
				ControlloDatagrid.InitDataGrid();
			
			DataGridDati.CurrentPageIndex=numeroPagina;
			DataTable ldt = this.GetData();
			foreach (DataRow dr in ldt.Rows)
			{
				dataSetReport1.Query.ImportRow(dr);
			}

			DataGridDati.DataBind();
		}

		private void SetParamQuery()
		{
			S_ControlsCollection param = new S_ControlsCollection();

			S_Controls.Collections.S_Object DirParam;
			DirParam = new S_Object();
			DirParam.ParameterName = "pIdQuery";
			DirParam.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DirParam.Value = DBNull.Value;
			param.Add(DirParam);

//			param.Add(TextBox1);
//			param.Add(TextBox2);

			DirParam = new S_Object();
			DirParam.ParameterName = "pDenominazione";
			DirParam.Size=100;
			DirParam.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DirParam.Value = TextBox1.Text;
			param.Add(DirParam);

			DirParam = new S_Object();
			DirParam.ParameterName = "pDescrizione";
			DirParam.Size=500;
			DirParam.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DirParam.Value = TextBox2.Text;
			param.Add(DirParam);
			
			DirParam = new S_Object();
			DirParam.ParameterName = "pSortExpression";
			DirParam.Size=100;
			DirParam.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DirParam.Value = Convert.ToString(ViewState["campoDiOrdinamento"])=="" ? "NULL" : Convert.ToString(ViewState["campoDiOrdinamento"]) ;
			param.Add(DirParam);

			Hashtable _HS=(Hashtable) Session["ParametriSelectSchema"];
			IdVista = Convert.ToInt32(_HS["IdVista"]);
			S_Object pIdVista = new S_Object();
			pIdVista.ParameterName = "pIdVista";
			pIdVista.Size = 32;
			//pIdVista.Direction = ParameterDirection.Input;
			pIdVista.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			pIdVista.Value = IdVista;
			param.Add(pIdVista);
			
			DirParam = new S_Object();
			DirParam.ParameterName = "putente";
			DirParam.Size=100;
			DirParam.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DirParam.Value = System.Web.HttpContext.Current.User.Identity.Name;
			param.Add(DirParam);

//			DirParam = new S_Object();
//			DirParam.ParameterName = "putente";
//			DirParam.DbType = CustomDBType.VarChar;
//			DirParam.Direction = ParameterDirection.Input;		
//			DirParam.Value = System.Web.HttpContext.Current.User.Identity.Name;
//			param.Add (DirParam);

			DirParam = new S_Object();
			DirParam.ParameterName = "io_cursor";
			DirParam.Direction=ParameterDirection.Output;
			DirParam.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
			DirParam.Value = DBNull.Value;
			param.Add(DirParam);

			paramFederico=param;
			CurrentProcedure="IL_PACK_INTERROGAZIONI.IL_SpSelectQuery";
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
			this.dataSetReport1 = new TheSite.GIC.App_Code.DataSetDef.DataSetReport();
			((System.ComponentModel.ISupportInitialize)(this.dataSetReport1)).BeginInit();
			this.TxtSuchen.Click += new System.EventHandler(this.TxtSuchen_Click);
			this.BtnNeu.Click += new System.EventHandler(this.BtnNeu_Click);
			this.BtnIndietro.Click += new System.EventHandler(this.BtnIndietro_Click);
			this.DataGridQuery.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridUtenti_ItemCommand);
			this.DataGridQuery.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridUtenti_ItemDataBound);
			// 
			// dataSetReport1
			// 
			this.dataSetReport1.DataSetName = "DataSetReport";
			this.dataSetReport1.Locale = new System.Globalization.CultureInfo("en-US");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataSetReport1)).EndInit();

		}
		#endregion

		private void TxtSuchen_Click(object sender, System.EventArgs e)
		{
			((DefaultReport)Page).VisCampiVisible=false;
			((DefaultReport)Page).IdQuery=0;
			BindDataGrid();	
		
		}

		private void DataGridUtenti_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Delete")
			{
				string[] controlli=null;
				ControlloDatagrid.ItemCommand(source,e,controlli,"@IdSchema","SpDeleteSchema",e.CommandName, new App_Code.Businnes.Query());	
			
				this.BindDataGrid();
				((DefaultReport)Page).VisCampiVisible=false;
				((DefaultReport)Page).IdQuery=0;
			}

			if (e.CommandName=="Edit")
			{
				//_myColl.AddControl(this.Page.Controls,ParentType.Page );
				
				
				string[] splitarg = e.CommandArgument.ToString().Split(Convert.ToChar(","));
				string id=(string)splitarg[0];
				string schema=(string)splitarg[1];
				string s_url = "AssociaUtenti.aspx?id="+Convert.ToInt32(id)+"&schema="+schema;				
				Response.Redirect(s_url);			
			}

		}


		private void DataGridUtenti_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				ImageButton lbt = (ImageButton)e.Item.FindControl("ImageDelete");				
				ImageButton lup = (ImageButton)e.Item.FindControl("ImageUpdate");
				Label lblUsername = (Label)e.Item.FindControl("LabelUsername");

				lup.Visible=Context.User.IsInRole("amministratori");
				
				if(Context.User.Identity.Name.ToUpper()==lblUsername.Text.ToUpper() || Context.User.IsInRole("amministratori"))
				{	
					lbt.Visible=true;
					lbt.Attributes.Add("onclick","return ConfermaEliminazione('selezionato')");								
				}
				else
				{	
					lbt.Visible=false;					
				}
			}
		}		
		

		protected void lbt_Click(object sender, EventArgs e)
		{	
			//((DefaultReport)Page).VisSelCampi1SelectedItemsValue="";
			((DefaultReport)Page).VisCampiVisible=true;
			((DefaultReport)Page).IdQuery=Convert.ToInt32(((LinkButton)sender).CommandArgument);
			
		}

	
		private void BtnNeu_Click(object sender, System.EventArgs e)
		{
			((DefaultReport)Page).VisCampiVisible=true;
			((DefaultReport)Page).IdQuery=0;		
		}

		private void BtnIndietro_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("SelectSchema.aspx");
		}

	}
}
