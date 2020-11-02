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

namespace WebCad
{
	/// <summary>
	/// Descrizione di riepilogo per Stanze.
	/// </summary>
	public class Stanze : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid MyDataGrid1;
		public string idbl=string.Empty;
		public string idpiano=string.Empty;
		protected string elementiTrovati="0";	

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.idbl=Request.QueryString["idbl"];
			this.idpiano=Request.QueryString["idpiano"];
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
				BindStanze();
		}
		
		private void BindStanze()
		{
			if(Request.QueryString["idbl"]!=null)
			{
				Servizi _Servizi=new Servizi();
				string idPiano=Request.QueryString["idpiano"];
				string idEdificio=Request.QueryString["idbl"];
				string descrizione=Request.QueryString["descrizione"].Trim();
				DataSet ds= _Servizi.GetStanzeBuilding(int.Parse(idEdificio),int.Parse(idPiano),descrizione);
				MyDataGrid1.DataSource=ds;
				elementiTrovati=Convert.ToString(ds.Tables[0].Rows.Count);
				MyDataGrid1.DataBind();
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
			this.MyDataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged);
			this.MyDataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.MyDataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void MyDataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || 
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
			  HtmlAnchor link=(HtmlAnchor)e.Item.FindControl("hrefset");
				DataRowView dv=(DataRowView)e.Item.DataItem;

			  link.Attributes.Add("onclick","Valorizza('" + dv["id"] + "','" + dv["descrizione"]  + "')");
			}
		}

		private void MyDataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			MyDataGrid1.CurrentPageIndex=e.NewPageIndex;
			BindStanze();
		}
	}
}
