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

namespace HelpApplication
{
	/// <summary>
	/// Descrizione di riepilogo per LeftFrame.
	/// </summary>
	public class LeftFrame : System.Web.UI.Page
	{
		protected arTreeMenu.TreeMenu TreeMenu1 ;
		private HelpApplication.SiteMenu _Menu;	

		private void Page_Load(object sender, System.EventArgs e)
		{			
		
			
			string menuselect=string.Empty;
//			if(Context.Application["CurrentExpand"]!=null)
//				menuselect= (string)Context.Application["CurrentExpand"];
			if( Request.QueryString["page"]!=null)
                menuselect= Request.QueryString["page"];
			_Menu = new HelpApplication.SiteMenu(menuselect,Context);
		//	XmlDocument _XmlDoc = _Menu.GetMenu("");
//			_XmlDoc.Save(@"C:\Inetpub\wwwroot\ProgettiCompsys\Ater\bra.xml");
			TreeMenu1.DataSource =_Menu.GetMenu("") ;
			TreeMenu1.DataBind();
		 	
	

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
