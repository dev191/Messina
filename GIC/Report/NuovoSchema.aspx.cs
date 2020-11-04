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
using ApplicationDataLayer.DBType;

namespace TheSite.GIC.Report
{
	/// <summary>
	/// Summary description for NuovoSchema.
	/// </summary>
	public class NuovoSchema : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvCodMat;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDescrizione;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox txtNomeVista;
		protected System.Web.UI.WebControls.Label lblDescrtizione;
		protected System.Web.UI.WebControls.TextBox txtDescrizione;
		protected System.Web.UI.WebControls.Label lblNomeVista;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			SalvaVista();
			Server.Transfer("SelectSchema.aspx");
		}
		private void SalvaVista()
		{
			int cntP =0;
			OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			S_ControlsCollection param=new S_ControlsCollection();

			S_Object pNomeVista = new S_Object();
			pNomeVista.ParameterName = "pNomeVista";
			pNomeVista.Direction=ParameterDirection.Input;
			pNomeVista.DbType = CustomDBType.VarChar;
			pNomeVista.Size = 64;
			pNomeVista.Index=cntP++;
			pNomeVista.Value = txtNomeVista.Text;
			param.Add(pNomeVista);

			S_Object pDescrizione = new S_Object();
			pDescrizione.ParameterName = "pDescrizione";
			pDescrizione.Direction=ParameterDirection.Input;
			pDescrizione.DbType = CustomDBType.VarChar;
			pDescrizione.Size = 256;
			pDescrizione.Index=cntP++;
			pDescrizione.Value = txtDescrizione.Text;
			param.Add(pDescrizione);


			S_Object pOut = new S_Object();
			pOut.ParameterName = "pOut";
			pOut.Direction=ParameterDirection.Output;
			pOut.DbType = CustomDBType.Integer;
			pOut.Size = 32;
			pOut.Index=cntP++;
			param.Add(pOut);


			int Id = _OraDl.GetRowsAffected(param,"IL_PACK_INTERROGAZIONI.SalvaVista");

		}

		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("SelectSchema.aspx");
		}
	}
}
