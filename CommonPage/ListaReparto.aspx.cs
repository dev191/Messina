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
	/// Descrizione di riepilogo per ListaReparto.
	/// </summary>
	public class ListaReparto : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		string Desc="";
		public string NomeTxtDesc="";
		public string NomeTxtIdMat="";
		public string chiamante="";

		Classi.ClassiAnagrafiche.Stanze ioDati = new TheSite.Classi.ClassiAnagrafiche.Stanze();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			
			String scriptarray = "<script language='JavaScript'>\n";
			scriptarray+="var a = new Array(" + DataGrid1.PageSize + ");\n";
			scriptarray+="var b = new Array(" + DataGrid1.PageSize + ");\n";
			scriptarray+="var c = new Array(" + DataGrid1.PageSize + ");\n";
			scriptarray += "<";
			scriptarray += "/";
			scriptarray += "script>";
			if(!Page.IsClientScriptBlockRegistered("arrayRep"))
				Page.RegisterClientScriptBlock("arrayRep", scriptarray);

			if(Request.QueryString["IdTxt"]!=null)
				this.NomeTxtDesc =	Request.QueryString["IdTxt"]; 
			else
				this.NomeTxtDesc =string.Empty;
				
			if(Request.QueryString["IdMat"]!=null)
				this.NomeTxtIdMat =Request.QueryString["IdMat"]; 
			else
				this.NomeTxtIdMat =string.Empty;				

			if(Request.QueryString["desc"]!=null)
				this.Desc =	Request.QueryString["desc"]; 
			else
				this.Desc =string.Empty;

			if(Request.QueryString["chiamante"]!=null)
				this.chiamante =	Request.QueryString["chiamante"]; 
			else
				this.chiamante =string.Empty;

			if (!Page.IsPostBack)
			{	
				Cerca(Desc);
			}

			String scriptString = "<script language=JavaScript> var idmoduloRep='" + this.idmodulo +"'";
			scriptString += "<";
			scriptString += "/";
			scriptString += "script>";

			if(!this.IsClientScriptBlockRegistered("clientScriptRep"))
				this.RegisterClientScriptBlock("clientScriptRep", scriptString);
			
			
			// Inserire qui il codice utente necessario per inizializzare la pagina.
		}

		#region Proprietà Private
		
		private string idmodulo
		{
			get {return (String) ViewState["s_idmodulo"];}
			set {ViewState["s_idmodulo"] = value;}
		}
		#endregion
		private void Cerca(string Descr)
		{
			
			DataSet DsMateriali;
			if (chiamante == "Spazi")
			{
				DsMateriali = ioDati.GetRepartoMura(Descr).Copy();	
			}
			else
			{
				DsMateriali = ioDati.GetAllReparto(Descr).Copy();
			}
			
			DataGrid1.DataSource=DsMateriali;
			DataGrid1.DataBind();
		}

		
	

		public Int32 j=0;
		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
			{
				string funzioneJsCmbValue = "PopolaRep('"	+ e.Item.Cells[1].Text + "','"+e.Item.Cells[2].Text+"');";
				((HtmlAnchor)e.Item.FindControl("hrefset")).HRef="javascript:PopolaRep('"	+ e.Item.Cells[1].Text + "','"+e.Item.Cells[2].Text+"');";
			}
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex=e.NewPageIndex;
			Cerca(Desc);
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
	}
}
