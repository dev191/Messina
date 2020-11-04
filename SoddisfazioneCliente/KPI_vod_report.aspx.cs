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
using System.IO;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;

namespace TheSite.SoddisfazioneCliente
{
	/// <summary>
	/// Summary description for KPI_vod_report.
	/// </summary>
	public class KPI_vod_report : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblAnno;
		protected System.Web.UI.WebControls.Button BtGenera;
		protected System.Web.UI.WebControls.Button BtSalva;
		protected System.Web.UI.WebControls.DropDownList DropMeseFine;
		protected System.Web.UI.WebControls.DropDownList DropMeseIni;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList DropAnno;
		protected System.Web.UI.WebControls.Label lblMessage;
	
		private void Page_Load(object sender, System.EventArgs e)
			{
				if(!IsPostBack)
				{
					BtGenera.Attributes.Add("onClick","checkMesi();return false;");
					LoadCombo();
					//BtSalva.Visible =false;
				}
				// Inserire qui il codice utente necessario per inizializzare la pagina.
			}

		private void LoadCombo()
		{
			TheSite.Classi.ManProgrammata.InvioDocPmP  _inviodoc = new TheSite.Classi.ManProgrammata.InvioDocPmP();
			for(int i=2008;i<=2028;i++)
				DropAnno.Items.Add(new ListItem(i.ToString(),i.ToString()));  
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
			this.BtGenera.Click += new System.EventHandler(this.BtGenera_Click);
			this.BtSalva.Click += new System.EventHandler(this.BtSalva_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BtGenera_Click(object sender, System.EventArgs e)
		{
			BtSalva.Visible=true;
			string ConnectionStr =System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
			KPIVod.KPIVod kpi=new KPIVod.KPIVod(ConnectionStr);
			string FileMaster =Path.Combine(Server.MapPath("../MasterExcel"), "KPI_Vodafone.xls");
			string PathOut=Path.Combine(Server.MapPath("../Doc_Db"),@"KPI\KPI Vod\KPI Eseguiti");
			string Fname =kpi.WriteReport(FileMaster,PathOut,Convert.ToInt32(DropMeseIni.SelectedValue),Convert.ToInt32(DropMeseFine.SelectedValue),Convert.ToInt32(DropAnno.SelectedValue)); 
			Response.ClearContent();
			Response.ClearHeaders();
			Response.ContentType = "application/vnd.ms-excel";
			Response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFileName(Fname));
			Response.WriteFile(Fname);
			Response.Flush();
			Response.Close();
			if(File.Exists(Fname)) File.Delete(Fname);
			

		}

		private void BtSalva_Click(object sender, System.EventArgs e)
		{
			// chiama dll
			string ConnectionStr =System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
			KPIVod.KPIVod kpi=new KPIVod.KPIVod(ConnectionStr);
			string FileMaster =Path.Combine(Server.MapPath("../MasterExcel"), "KPI_Vodafone.xls");
			string PathOut=Path.Combine(Server.MapPath("../Doc_Db"),@"KPI\KPI Vod\KPI Eseguiti");
			string file=kpi.WriteReport(FileMaster,PathOut,Convert.ToInt32(DropMeseIni.SelectedValue),Convert.ToInt32(DropMeseFine.SelectedValue),Convert.ToInt32(DropAnno.SelectedValue)); 
		   
			TheSite.Classi.SoddCliente.KPI _kpi = new TheSite.Classi.SoddCliente.KPI();

			S_Controls.Collections.S_ControlsCollection control = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "P_NOMEFILE";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = control.Count;
			p.Size=50;
			p.Value=Path.GetFileName(file);						
			control.Add(p);

			p = new S_Object();
			p.ParameterName = "P_USERNAME";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = control.Count;
			p.Size=10;
			p.Value=Context.User.Identity.Name;    						
			control.Add(p);

			p = new S_Object();
			p.ParameterName = "P_DATESTART";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = control.Count;
			p.Size=10;
			p.Value=DropMeseIni.SelectedValue + "/" + DropAnno.SelectedValue;    						
			control.Add(p);

			p = new S_Object();
			p.ParameterName = "P_DATEEND";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = control.Count;
			p.Size=10;
			p.Value=DropMeseFine.SelectedValue + "/" + DropAnno.SelectedValue;    						
			control.Add(p);

			_kpi.SaveReportVod(control); 

			string scriptString = "<script language=JavaScript>alert('Il file è stato salvato correttamente.');</script>";
		
			if(!this.IsClientScriptBlockRegistered("clientScriptexp"))
				this.RegisterStartupScript ("clientScriptexp", scriptString);

 
		}
	}
}
