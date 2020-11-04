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
using TheSite.Classi.ClassiDettaglio;

namespace TheSite.CommonPage
{
	/// <summary>
	/// Descrizione di riepilogo per ListaStdApparecchiature.
	/// </summary>
	public class ListaStdApparecchiature : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.DataGrid MyDataGrid1;
		protected System.Web.UI.WebControls.HyperLink HyperLinkChiudi2;
		protected WebControls.GridTitle GridTitle1; 

		#region Proprietà
	
		private string idUsercontrol
		{
			get {return (String) ViewState["s_idUsercontrol"];}
			set {ViewState["s_idUsercontrol"] = value;}
		}
		private string codStd
		{
			get {return (String) ViewState["s_codStd"];}
			set {ViewState["s_codStd"] = value;}
		}
		private string blid
		{
			get {return (String) ViewState["s_blid"];}
			set {ViewState["s_blid"] = value;}
		}
		private string campus
		{
			get {return (String) ViewState["s_campus"];}
			set {ViewState["s_campus"] = value;}
		}
		private string servizioid
		{
			get {return (String) ViewState["s_servizioid"];}
			set {ViewState["s_servizioid"] = value;}
		}

		#endregion


		private void Page_Load(object sender, System.EventArgs e)
		{
			GridTitle1.hplsNuovo.Visible=false;
			if (!IsPostBack)
			{
				if(Request.QueryString["idUsercontrol"]!=null)
					this.idUsercontrol =Request.QueryString["idUsercontrol"]; 
				else
					this.idUsercontrol =string.Empty; 

				if(Request.QueryString["codstd"]!=null)
					this.codStd =Request.QueryString["codstd"]; 
				else
					this.codStd =string.Empty;
 
				if(Request.QueryString["blid"]!=null)
					this.blid =Request.QueryString["blid"]; 
				else
					this.blid =string.Empty;

				if(Request.QueryString["campus"]!=null)
					this.campus =Request.QueryString["campus"]; 
				else
					this.campus =string.Empty;

				if(Request.QueryString["servizioid"]!=null)
					this.servizioid =Request.QueryString["servizioid"]; 
				else
					this.servizioid =string.Empty;

				Execute();
			}

			String scriptString = "<script language=JavaScript> var idUsercontrol='" + this.idUsercontrol +"'";
			scriptString += "<";
			scriptString += "/";
			scriptString += "script>";

			if(!this.IsClientScriptBlockRegistered("clientScript"))
				this.RegisterClientScriptBlock("clientScript", scriptString);

		}

		private void Execute()
		{
			///Istanzio un nuovo oggetto Collection per aggiungere i parametri
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			///creo i parametri
		
			S_Controls.Collections.S_Object s_p_Bl_Id = new S_Controls.Collections.S_Object();
			s_p_Bl_Id.ParameterName = "p_Bl_Id";
			s_p_Bl_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Bl_Id.Direction = ParameterDirection.Input;
			s_p_Bl_Id.Size =50;
			s_p_Bl_Id.Index = _SCollection.Count;
			if (this.blid== null||this.blid == string.Empty)
				s_p_Bl_Id.Value= DBNull.Value;
			else
				s_p_Bl_Id.Value = this.blid;
			_SCollection.Add(s_p_Bl_Id);

			S_Controls.Collections.S_Object s_p_campus = new S_Controls.Collections.S_Object();
			s_p_campus.ParameterName = "p_campus";
			s_p_campus.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_campus.Direction = ParameterDirection.Input;
			s_p_campus.Index = _SCollection.Count;
			s_p_campus.Size=50;
			if (this.campus== null||this.campus == string.Empty)
				s_p_campus.Value= DBNull.Value;
			else
			s_p_campus.Value = this.campus;
			_SCollection.Add(s_p_campus);

			S_Controls.Collections.S_Object s_p_Servizio = new S_Controls.Collections.S_Object();
			s_p_Servizio.ParameterName = "p_Servizio";
			s_p_Servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Servizio.Direction = ParameterDirection.Input;
			s_p_Servizio.Index = _SCollection.Count;
//			///Non filtro piu per servizio.	
//			s_p_Servizio.Value = (this.servizioid ==string.Empty)? -1:Int32.Parse(this.servizioid);
			s_p_Servizio.Value=-1;
			_SCollection.Add(s_p_Servizio);

			S_Controls.Collections.S_Object s_p_eqstdid = new S_Controls.Collections.S_Object();
			s_p_eqstdid.ParameterName = "p_eqstdid";
			s_p_eqstdid.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_eqstdid.Direction = ParameterDirection.Input;
			s_p_eqstdid.Size =8;
			s_p_eqstdid.Index = _SCollection.Count;
			if (this.codStd == null||this.codStd == string.Empty)
				s_p_eqstdid.Value= DBNull.Value;
			else
				s_p_eqstdid.Value = this.codStd;
			_SCollection.Add(s_p_eqstdid);

			///Istanzio la Classe per eseguire la Strore Procedure
			Classi.AnagrafeImpianti.Apparecchiature  _Apparecchiature =new TheSite.Classi.AnagrafeImpianti.Apparecchiature(Context.User.Identity.Name);
			
			DataSet Ds=_Apparecchiature.RicercaStd(_SCollection);

			GridTitle1.NumeroRecords=(Ds.Tables[0].Rows.Count)==0? "0":Ds.Tables[0].Rows.Count.ToString();
			MyDataGrid1.DataSource= Ds;
			MyDataGrid1.DataBind(); 
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
			this.MyDataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged);
			this.MyDataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.MyDataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void MyDataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			MyDataGrid1.CurrentPageIndex=e.NewPageIndex;
			Execute();
		}

		private void MyDataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || 
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				((HtmlAnchor)e.Item.FindControl("hrefset")).HRef="javascript:Popola('" + HttpUtility.HtmlDecode(e.Item.Cells[1].Text).Replace("\"","\\\"") + "','" + e.Item.Cells[3].Text + "');";
			}
		}
	}
}
