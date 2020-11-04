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
using TheSite.Classi.ManCorrettiva;
using System.Globalization;

namespace TheSite.CommonPage
{
	/// <summary>
	/// Descrizione di riepilogo per RicercaMateriali.
	/// </summary>
	public class RicercaMateriali : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		string Desc="";
		public string NomeTxtDesc="";
		public string NomeTxtPrezzo="";
		public string NomeTxtIdMat="";
		public Int32 j=0;
		

//		private string idmodulo
//		{
//			get {return (String) ViewState["s_idmodulo"];}
//			set {ViewState["s_idmodulo"] = value;}
//		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if (!Page.IsPostBack)
			{
					if(Request.QueryString["IdTxt"]!=null)
					this.NomeTxtDesc =	Request.QueryString["IdTxt"]; 
				else
					this.NomeTxtDesc =string.Empty;

				if(Request.QueryString["IdPrezzo"]!=null)
					this.NomeTxtPrezzo =Request.QueryString["IdPrezzo"]; 
				else
					this.NomeTxtPrezzo =string.Empty;

				if(Request.QueryString["IdMat"]!=null)
					this.NomeTxtIdMat =Request.QueryString["IdMat"]; 
				else
					this.NomeTxtIdMat =string.Empty;
				

				if(Request.QueryString["desc"]!=null)
					this.Desc =	Request.QueryString["desc"]; 
				else
					this.Desc =string.Empty;

				Cerca(Desc);
			}
			// Inserire qui il codice utente necessario per inizializzare la pagina.
		}

		private void Cerca(string Descr)
		{
			ClManCorrettiva ioDati = new ClManCorrettiva();
			DataSet DsMateriali = ioDati.getMateriali(Descr).Copy();
			DataGrid1.DataSource=DsMateriali;
			DataGrid1.DataBind();
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
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex=e.NewPageIndex;
			Cerca(Desc);
		}

		
		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			if((e.Item.ItemType == ListItemType.Item) || 
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				string funzioneJsCmbValue = "Popola2('"	+ e.Item.Cells[1].Text + "','"+e.Item.Cells[2].Text.Split(';')[2]+"','"	+ e.Item.Cells[3].Text + "');";
			//	cmbMateriali.Attributes.Add("onchange",funzioneJsCmbValue);
				
				((HtmlAnchor)e.Item.FindControl("hrefset")).HRef="javascript:Popola2('"	+ e.Item.Cells[1].Text + "','"+e.Item.Cells[2].Text.Split(';')[2]+"','"	+ e.Item.Cells[3].Text + "');";
  
				e.Item.Cells[4].Text=e.Item.Cells[2].Text.Split(';')[1]+" / "+e.Item.Cells[2].Text.Split(';')[2]+" €";
			}
		}
	}
}
