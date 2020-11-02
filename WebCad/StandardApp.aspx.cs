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
	/// Descrizione di riepilogo per StandardApp.
	/// </summary>
	public class StandardApp : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid MyDataGrid1;
		protected string elementiTrovati="0";
		public string idbl=string.Empty;
		public string idpiano=string.Empty;
		public string idservizio = String.Empty;


		private void Page_Load(object sender, System.EventArgs e)
		{
			this.idbl=Request.QueryString["idbl"];
			this.idpiano=Request.QueryString["idpiano"];
			this.idservizio = Request.QueryString["IdServizio"];
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
				BindEqstd();
		}
		private void BindEqstd()
		{
			if(Request.QueryString["idbl"]!=null)
			{
				Servizi _Servizi=new Servizi();
				DataSet ds= _Servizi.GetAllEQSTD(
					Convert.ToInt32(Request.QueryString["idbl"]),
					Convert.ToInt32(Request.QueryString["idpiano"]),
					Convert.ToInt32(Request.QueryString["IdServizio"]),
					Request.QueryString["descrizione"].Trim());
				MyDataGrid1.DataSource=ds;
				elementiTrovati=Convert.ToString(ds.Tables[0].Rows.Count);
				MyDataGrid1.DataBind();
			}
		}
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
			BindEqstd();
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
			this.MyDataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged);
			this.MyDataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.MyDataGrid1_ItemDataBound);
		}
		#endregion
	}
}
