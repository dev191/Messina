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

namespace WebCad.RedirectPages
{
	/// <summary>
	/// Summary description for Redirect_Eq_DocumentiAllegati.
	/// </summary>
	public class Redirect_Eq_DocumentiAllegati : System.Web.UI.Page    // System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			string id_eq = Request["id_eq"]; 
			string eq_id = Request["eq_id"];
			Response.Redirect("../../AnagrafeImpianti/Eq_DocumentiAllegati.aspx?id_eq=" + id_eq + "&eq_id=" + eq_id + "&FromWebCad=true");
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
