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
using System.Text;
using System.IO;
using System.Web.Mail;
using System.Configuration;
using ICSharpCode;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
using S_Controls.Collections;
using ApplicationDataLayer.DBType;
using MyCollection;

namespace TheSite.ManutenzioneProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per KPIVod.
	/// </summary>
	public class KPIVod_Upload : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button BtInvia;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.HtmlControls.HtmlInputFile UploadFile;
	    public string HelpLink="";

		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			HelpLink = _SiteModule.HelpLink;
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			UploadFile.Attributes.Add("onchange", "return checkFileExtension(this);");
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
			this.BtInvia.Click += new System.EventHandler(this.BtInvia_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BtInvia_Click(object sender, System.EventArgs e)
		{
			SendDoc();
		}
		private void SendDoc()
		{
		
			if (UploadFile.PostedFile!=null && UploadFile.PostedFile.FileName!="") 
			{
				string PathOut=Path.Combine(Server.MapPath("../Doc_Db"),@"KPI\KPI Vod\KPI Eseguiti");
				if(!Directory.Exists(PathOut)) 
					Directory.CreateDirectory(PathOut);

				string FileName=Path.Combine(PathOut,Path.GetFileName(UploadFile.PostedFile.FileName));

				UploadFile.PostedFile.SaveAs(FileName);
				
				string ConnectionStr =System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
				KPIVod.KPIVod kpi=new KPIVod.KPIVod(FileName,Context.User.Identity.Name,ConnectionStr);
               // lblMessage.Text= kpi.ReadDocument().ToString(); 
				kpi.ReadDocument();
				string scriptString = "<script language=JavaScript>alert('Il file è stato elaborato correttamente.');</script>";
		
				if(!this.IsClientScriptBlockRegistered("clientScriptexp"))
					this.RegisterStartupScript ("clientScriptexp", scriptString);


			}
		}
	}
}
