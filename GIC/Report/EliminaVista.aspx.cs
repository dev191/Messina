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
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;

namespace TheSite.GIC.Report
{
	/// <summary>
	/// Summary description for EliminaVista.
	/// </summary>
	public class EliminaVista : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected System.Web.UI.WebControls.Label lblNomeVista;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvCodMat;
		protected System.Web.UI.WebControls.TextBox txtNomeVista;
		protected System.Web.UI.WebControls.Label lblDescrtizione;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDescrizione;
		protected System.Web.UI.WebControls.TextBox txtDescrizione;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		protected System.Web.UI.WebControls.Button btnElimina;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
		protected int IdVista;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			IdVista = Convert.ToInt32(Request.QueryString["IdVista"].ToString());
			if(!IsPostBack)
			{
				btnElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");		
				txtNomeVista.Text = Request.QueryString["NomeVista"].ToString();
				txtDescrizione.Text = Request.QueryString["Descrizione"].ToString(); 
				
			}
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
			this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnElimina_Click(object sender, System.EventArgs e)
		{
			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			S_ControlsCollection param=new S_ControlsCollection();
			S_Object pid = new S_Object();
			pid.ParameterName = "pid";
			pid.Direction=ParameterDirection.Input;
			pid.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			pid.Size = 32;
			pid.Index=0;
			pid.Value = IdVista;
			param.Add(pid);
			int  RE = _OraDl.GetRowsAffected(param,"IL_PACK_INTERROGAZIONI.EliminaVista");	
			Server.Transfer("SelectSchema.aspx");
		}

		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("SelectSchema.aspx");
		}
	}
}
