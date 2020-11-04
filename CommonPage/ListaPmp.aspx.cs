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

namespace TheSite.CommonPage
{
	/// <summary>
	/// Descrizione di riepilogo per ListaPmp.
	/// </summary>
	public class ListaPmp : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected WebControls.GridTitle GridTitle1; 

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{
				// Id
				if(Request.QueryString["idric"]!=null)
					this.idric = Request.QueryString["idric"]; 
				else
					this.idric =string.Empty; 
				// Idmodulo
				if(Request.QueryString["idmodulo"]!=null)
					this.idmodulo =	Request.QueryString["idmodulo"]; 
				else
					this.idmodulo =string.Empty;
				// id Standard Apparecchiatura
				if(Request.QueryString["ideqstd"]!=null && Request.QueryString["ideqstd"].Trim() !="")
					this.idEqStd = Int32.Parse(Request.QueryString["ideqstd"]); 
				else
					this.idEqStd =0;								
				// id Servizio
				if(Request.QueryString["idservizio"]!=null && Request.QueryString["idservizio"].Trim() !="")
					this.idServizio = Int32.Parse(Request.QueryString["idservizio"]); 
				else
					this.idServizio=0;								
				Execute();
			}
			String scriptString = "<script language=JavaScript> var idmodulo='" + this.idmodulo +"'";
			scriptString += "<";
			scriptString += "/";
			scriptString += "script>";

			if(!this.IsClientScriptBlockRegistered("clientScriptmatricola"))
				this.RegisterClientScriptBlock("clientScriptmatricola", scriptString);

			GridTitle1.hplsNuovo.Visible=false;

		}

			
		private string idmodulo
		{
			get {return (String) ViewState["s_idmodulo"];}
			set {ViewState["s_idmodulo"] = value;}
		}

		private string idric
		{
			get {return (String) ViewState["s_Idric"];}
			set {ViewState["s_Idric"] = value;}
		}

		private int idEqStd
		{
			get {return (int) ViewState["s_idEqStd"];}
			set {ViewState["s_idEqStd"] = value;}
		}

		private int idServizio
		{
			get {return (int) ViewState["s_idServizio"];}
			set {ViewState["s_idServizio"] = value;}
		}

		private void Execute()
		{
			Classi.ManProgrammata.ProcAndSteps _PMP = new TheSite.Classi.ManProgrammata.ProcAndSteps();

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();			
			S_Controls.Collections.S_Object s_pmp_id = new S_Controls.Collections.S_Object();
			s_pmp_id.ParameterName = "p_Id";
			s_pmp_id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_pmp_id.Direction = ParameterDirection.Input;
			s_pmp_id.Size =8;
			s_pmp_id.Index = 0;
			s_pmp_id.Value = this.idric;
			_SCollection.Add(s_pmp_id);
			
			S_Controls.Collections.S_Object s_eqstd_id = new S_Controls.Collections.S_Object();
			s_eqstd_id.ParameterName = "p_idEqst";
			s_eqstd_id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_eqstd_id.Direction = ParameterDirection.Input;
			s_eqstd_id.Size =8;
			s_eqstd_id.Index = 1;
			s_eqstd_id.Value = this.idEqStd;
			_SCollection.Add(s_eqstd_id);

			S_Controls.Collections.S_Object s_servizio_id = new S_Controls.Collections.S_Object();
			s_servizio_id.ParameterName = "p_idServizio";
			s_servizio_id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_servizio_id.Direction = ParameterDirection.Input;
			s_servizio_id.Size =8;
			s_servizio_id.Index = 2;
			s_servizio_id.Value = this.idServizio;
			_SCollection.Add(s_servizio_id);

			DataSet _MyDs = _PMP.GetAllPMP(_SCollection).Copy();  
			DataGrid1.DataSource= _MyDs;
			GridTitle1.NumeroRecords=(_MyDs.Tables[0].Rows.Count)==0? "0":_MyDs.Tables[0].Rows.Count.ToString();
			DataGrid1.DataBind();
		}
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			DataGrid1.CurrentPageIndex=e.NewPageIndex;
			Execute();
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
		}
		#endregion
	}
}
