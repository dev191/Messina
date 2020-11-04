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
using System.Xml;
using System.IO;

namespace TheSite
{
	/// <summary>
	/// Descrizione di riepilogo per LeftFrame.
	/// </summary>
	public class LeftFrame : System.Web.UI.Page
	{
		protected arTreeMenu.TreeMenu TreeMenu1 ;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox TxtOraServer;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox TxtMinutiServer;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox TxtSecondiServer;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox TxtMSecondiServer;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox TxtOra2;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox TxtMinuti2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox TxtSecondi2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox TxtMSecondi2;
		private Classi.SiteMenu _Menu;	

		private void Page_Load(object sender, System.EventArgs e)
		{			
			XmlDocument _XmlDoc = new XmlDocument();

			_Menu = new TheSite.Classi.SiteMenu();
			string url="";
			if(Request.QueryString["VarApp"]!=null)
				url="&VarApp=" + Request.QueryString["VarApp"];

			StringWriter _SWriter =  _Menu.GetMenu(url);

			_XmlDoc.LoadXml(_SWriter.ToString());
			
			TreeMenu1.DataSource = _XmlDoc;
			TreeMenu1.DataBind();


			if(Request.QueryString["VarApp"]!=null)
			{
				System.Text.StringBuilder _StrBld = new System.Text.StringBuilder();
				_StrBld.Append("<script language=\"javascript\">\n");
				if (Context.User.IsInRole("callcenter"))
					_StrBld.Append("change('_ctl0Item000')");	
				else
					_StrBld.Append("change('_ctl0Item001')");
				_StrBld.Append("</script>");
				Page.RegisterStartupScript("loc",_StrBld.ToString());
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
	}
}
