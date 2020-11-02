namespace TheSite.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descrizione di riepilogo per CollapseDiv.
	/// </summary>
	public class CollapseDiv : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.ImageButton imgSu;
		protected System.Web.UI.WebControls.ImageButton imgGiu;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divCollapse;

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			String scriptString = "<script language=JavaScript> function EspandiRitrai() {";			
			scriptString += "var ctrl=document.getElementById(\"" + divCollapse.ClientID +"\").style;\n";
			scriptString +="ctrl.display = (ctrl.display == 'none')?'block':'none';\n";
			scriptString += "}<";
			scriptString += "/";
			scriptString += "script>";
        
			if(!Page.IsStartupScriptRegistered("Startup"))
				Page.RegisterStartupScript("Startup", scriptString);  
			if(!this.Page.IsPostBack)
			{
				imgSu.Attributes.Add("onClick","EspandiRitrai");
				imgGiu.Attributes.Add("onClick","EspandiRitrai");
				imgGiu.Visible=false;
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
			this.imgSu.Click += new System.Web.UI.ImageClickEventHandler(this.imgSu_Click);
			this.imgGiu.Click += new System.Web.UI.ImageClickEventHandler(this.imgGiu_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void imgSu_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			System.Web.UI.Control div  = Page.FindControl("divCollapse");
			divCollapse.Style.Add("display", "block");
			imgGiu.Visible=true;
			imgSu.Visible=false;
		}

		private void imgGiu_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			System.Web.UI.Control div  = Page.FindControl("divCollapse");
			divCollapse.Style.Add("display", "none");
			imgSu.Visible=true;
			imgGiu.Visible=false;
		}

		
	}
}
