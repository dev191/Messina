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
	/// Descrizione di riepilogo per ListLink.
	/// </summary>
	public class ListLink : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Repeater RepeaterLink;
		private string idLink=string.Empty;
		Servizi _Servizi=new Servizi();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
//		    if(Request.QueryString["text"]!=null && Request.QueryString["value"]!=null)
//				BindCombo();
			//bl=" + sender +"&corpo=" + sender2 + "&stanza=" + sender3 + "&eq=" + sender4
			if(Request.QueryString["bl"]!=null && Request.QueryString["corpo"]!=null && Request.QueryString["stanza"]!=null && Request.QueryString["eq"]!=null)
				 BindLinkEq();

			if(Request.QueryString["bl"]!=null && Request.QueryString["corpo"]!=null && Request.QueryString["stanza"]!=null && Request.QueryString["eq"]==null)
				BindLinkStanza();

			if(Request.QueryString["bl"]!=null && Request.QueryString["corpo"]!=null && Request.QueryString["stanza"]==null && Request.QueryString["eq"]==null)
				BindLinkCorpo();

			if(Request.QueryString["bl"]!=null && Request.QueryString["corpo"]==null && Request.QueryString["stanza"]==null && Request.QueryString["eq"]==null)
				BindLinkBl();
		}

		private void BindLinkEq()
		{
			int bl=int.Parse(Request.QueryString["bl"]);
			int corpo=1;
			int stanza=int.Parse(Request.QueryString["stanza"]);
			int eq=int.Parse(Request.QueryString["eq"]);
			DataSet ds= _Servizi.GetEQ(bl,corpo,stanza,eq);;
			RepeaterLink.DataSource=ds.Tables[0];
			RepeaterLink.DataBind();
		
		}

		private void BindLinkStanza()
		{
			int bl=int.Parse(Request.QueryString["bl"]);
			int corpo=1;
			int stanza=int.Parse(Request.QueryString["stanza"]);
			DataSet ds= _Servizi.GetRM(bl,corpo,stanza);;
			RepeaterLink.DataSource=ds.Tables[0];
			RepeaterLink.DataBind();
		}
		private void BindLinkCorpo()
		{
		
		}
		private void BindLinkBl()
		{
			int bl=int.Parse(Request.QueryString["bl"]);
			DataSet ds= _Servizi.GetBL(bl);;
			RepeaterLink.DataSource=ds.Tables[0];
			RepeaterLink.DataBind();
		}
//		private void BindCombo()
//		{
//			if(Session["item"]!=null)
//				foreach(ListItem ite in (ListItemCollection)Session["item"])
//				  ListBoxLink.Items.Add(ite);
//
//
//			ListBoxLink.Items.Add(new ListItem(Request.QueryString["text"],Request.QueryString["value"]));
//			ListItemCollection col= ListBoxLink.Items;
//			if(Session["item"]!=null)
//				Session.Remove("item");
//            Session.Add("item",col);
//		}
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
			RepeaterLink.ItemDataBound += new RepeaterItemEventHandler(RepeaterLink_ItemDataBound);
		}
		#endregion

		private void RepeaterLink_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
			{
			   DataRowView view=(DataRowView)e.Item.DataItem;
			   HtmlAnchor ancor= e.Item.FindControl("link") as HtmlAnchor;
			   ancor.HRef="#";
			   ancor.Attributes.Add("onclick","ApriEq('" + view["link"].ToString() +"');");
			   ancor.InnerText=view["descrizione"].ToString();
			}
		}
	}
}
