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
using ApplicationDataLayer.DBType;
using MyCollection;

namespace TheSite.ManutenzioneCorretiva
{
	/// <summary>
	/// Descrizione di riepilogo per AnalisiRdlStorico.
	/// </summary>
	public class AnalisiRdlStorico : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;

		public static int FunId = 0;
		public static string HelpLink = string.Empty;

		MyCollection.clMyCollection _myColl = new clMyCollection();
		//protected System.Web.UI.WebControls.Button btnsChiudi;
		protected System.Web.UI.WebControls.Button btnsExcel;		
		AnalisiRdl _fp;	
	
		
		
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

		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];

			this.DataGridRicerca.Columns[1].Visible = _SiteModule.IsEditable;				
						
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			this.GridTitle1.hplsNuovo.Visible = false;	
			//btnsChiudi.Attributes.Add("onclick","javascript:history.back();");
		           
			carica_record();
			
			if (!Page.IsPostBack)
			{			
//				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
		

				if(Context.Handler is TheSite.ManutenzioneCorretiva.AnalisiRdl) 
				{
					_fp = (TheSite.ManutenzioneCorretiva.AnalisiRdl) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
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
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.btnsExcel.Click += new System.EventHandler(this.btnsExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region funzioni private
		private void carica_record()
		{				
			PageTitle1.Title+=": " + Request.QueryString["wr_id"];
			
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_wr_id";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = 1;
			s_IdIn.Size=10;
			s_IdIn.Value = Request.QueryString["wr_id"];
			_SCollection.Add(s_IdIn);
			
			Classi.ManOrdinaria.Richiesta _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
			
			DataSet _MyDs = _Richiesta.GetHWR(_SCollection,Context.User.Identity.Name).Copy();
			
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];

			//			DataGridRicerca.Visible = true;

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
					//if (DataGridRicerca.PageCount != DataGridRicerca.CurrentPageIndex)				
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
			carica_record();
		}

		private void DataGridRicerca_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{		
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			carica_record();
		}

		private void btnsExcel_Click(object sender, System.EventArgs e)
		{
			Csy.WebControls.Export 	_objExport = new Csy.WebControls.Export();
			DataTable _dt = new DataTable();			
			_dt = GetWordExcel().Tables[0].Copy();	
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

		public DataSet GetWordExcel()
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_wr_id";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = 1;
			s_IdIn.Size=10;
			s_IdIn.Value = Request.QueryString["wr_id"];
			_SCollection.Add(s_IdIn);
			
			Classi.ManOrdinaria.Richiesta _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
			
			DataSet _MyDs = _Richiesta.GetHWR(_SCollection,Context.User.Identity.Name).Copy();


			return  _MyDs;		
		}
		
	}
	
}

	


