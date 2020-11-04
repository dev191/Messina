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
	/// Descrizione di riepilogo per ListaMateriali.
	/// </summary>
	public class ListaMateriali : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		string Desc="";
		int id;
		
		
		
		private void Page_Load(object sender, System.EventArgs e)
		{

			
			String scriptarray = "<script language='JavaScript'>\n";
			scriptarray+="var a = new Array(" + DataGrid1.PageSize + ");\n";
			scriptarray+="var b = new Array(" + DataGrid1.PageSize + ");\n";
			scriptarray+="var c = new Array(" + DataGrid1.PageSize + ");\n";
			scriptarray += "<";
			scriptarray += "/";
			scriptarray += "script>";
			if(!Page.IsClientScriptBlockRegistered("array1"))
				Page.RegisterClientScriptBlock("array1", scriptarray);

			if (!Page.IsPostBack)
			{				
				if(Request.QueryString["idmodulo"]!=null)
					this.idmodulo =	Request.QueryString["idmodulo"]; 
				else
					this.idmodulo =string.Empty;

				if(Request.QueryString["idric"]!=null)
					Desc=Request.QueryString["idric"].ToString();	
		
					
				Cerca(Desc);
			}

			String scriptString = "<script language=JavaScript> var idmodulo='" + this.idmodulo +"'";
			scriptString += "<";
			scriptString += "/";
			scriptString += "script>";

			if(!this.IsClientScriptBlockRegistered("clientScript"))
				this.RegisterClientScriptBlock("clientScript", scriptString);
			
			
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

		public Int32 j=0;
		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || 
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				
				string arrayvariable = "<script language='JavaScript'>\n";
				arrayvariable+="a[" + j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[3].Text).Replace("\"","\\\"") +"\";\n";
				arrayvariable+="b[" + j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[1].Text).Replace("\"","\\\"") +"\";\n";
				arrayvariable+="c[" + j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[2].Text).Replace("\"","\\\"") +"\";\n";
				arrayvariable +="<";
				arrayvariable += "/";
				arrayvariable += "script>";

				this.RegisterStartupScript("scriptarray" + j.ToString(),arrayvariable); 
				
					((HtmlAnchor)e.Item.FindControl("hrefset")).HRef="javascript:Popola2(" + j + ");";
  
				j++;

				e.Item.Cells[4].Text=e.Item.Cells[2].Text.Split(';')[1]+" / "+e.Item.Cells[2].Text.Split(';')[2]+" €";
			}
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex=e.NewPageIndex;
			Cerca(Desc);
		}
	}
}
