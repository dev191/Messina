using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using GIC.App_Code;


namespace GIC.Report
{
	/// <summary>
	/// Descrizione di riepilogo per ModificaCampo.
	/// </summary>
	public class ModificaCampo : BasePage
	{
		protected System.Web.UI.WebControls.ListBox ListBox1;
		protected System.Web.UI.HtmlControls.HtmlSelect operatore;
		protected System.Web.UI.HtmlControls.HtmlInputText valore1;
		protected System.Web.UI.HtmlControls.HtmlInputText valore2;
		protected System.Web.UI.HtmlControls.HtmlSelect LstCampi;
		protected string IdQuery;
		protected string IdCampo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			IdQuery=Request.QueryString["idquery"];
			IdCampo=Request.QueryString["idcampo"];		
			ListBox1.Attributes.Add("ondblclick","eliminaFiltro(this);");
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
