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
	/// Descrizione di riepilogo per KPI_Download.
	/// </summary>
	public class KPI_Download : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DrEdifici;
		protected System.Web.UI.WebControls.Label lblAnno;
		protected System.Web.UI.WebControls.DropDownList DropAnno;
		protected System.Web.UI.WebControls.Label lblMese;
		protected System.Web.UI.WebControls.DropDownList DropMese;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected S_Controls.S_Button btnsRicerca;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected System.Web.UI.WebControls.TextBox txtNomeDoc;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1; 
	    TheSite.Classi.SoddCliente.KPI   _kpi = new TheSite.Classi.SoddCliente.KPI();
		protected System.Web.UI.WebControls.DropDownList DropTipoDoc;
		public string HelpLink="";
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			HelpLink = _SiteModule.HelpLink;
            GridTitle1.hplsNuovo.Visible=false; 
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if (!IsPostBack)
				LoadCombo();

			DropTipoDoc.Attributes.Add("onchange","setvis();");
   
		}
		private void LoadCombo()
		{
			
			DataSet Ds=_kpi.GetEdifici(Context.User.Identity.Name);
			DrEdifici.DataSource=Ds.Tables[0];
			DrEdifici.DataTextField ="Denominazione";
			DrEdifici.DataValueField="id"; 
			DrEdifici.DataBind();
			ListItem ite=new ListItem("- Seleziona Edificio -", "0");
			ite.Selected =true;
			DrEdifici.Items.Add(ite);  

			for(int i=2008;i<=2020;i++)
				DropAnno.Items.Add(new ListItem(i.ToString(),i.ToString()));  
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
			this.btnsRicerca.Click += new System.EventHandler(this.btnsRicerca_Click);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			DataGridRicerca.CurrentPageIndex =0;
			Ricerca();
		}
		private void Ricerca()
		{
			S_Controls.Collections.S_ControlsCollection control = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_nome_file";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = control.Count;
			p.Size=50;
			p.Value=txtNomeDoc.Text;						
			control.Add(p);

			p = new S_Object();
			p.ParameterName = "p_id_bl";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = control.Count;
			p.Value=DrEdifici.SelectedValue;						
			control.Add(p);

			p = new S_Object();
			p.ParameterName = "p_anno";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = control.Count;
			p.Value=DropAnno.SelectedValue;						
			control.Add(p);

			p = new S_Object();
			p.ParameterName = "p_mese";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = control.Count;
			p.Value=DropMese.SelectedValue;						
			control.Add(p);

			p = new S_Object();
			p.ParameterName = "p_tipodoc";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = control.Count;
			p.Value=DropTipoDoc.SelectedValue;						
			control.Add(p);


			DataSet ds=_kpi.GetData(control);

			this.DataGridRicerca.DataSource = ds.Tables[0];
			this.DataGridRicerca.DataBind();
			GridTitle1.NumeroRecords =ds.Tables[0].Rows.Count.ToString();
			
		}

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Download")
			{
				string filename="";
				if (DropTipoDoc.SelectedValue =="1")
				{
					filename=Path.Combine(Server.MapPath("../Doc_DB"),@"KPI\KPI Vod\KPI Proposti");
					filename=Path.Combine(filename,Path.GetFileNameWithoutExtension(e.CommandArgument.ToString()) +".zip");
			
					Response.Clear();
					Response.ContentType = "application/zip";
					Response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFileName(filename));
				}
				else
				{
					filename=Path.Combine(Server.MapPath("../Doc_DB"),@"KPI\KPI Vod\KPI Eseguiti");
					filename=Path.Combine(filename,e.CommandArgument.ToString());
					Response.Clear();
					Response.ContentType = "application/xls";
					Response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFileNameWithoutExtension(filename) +".xls");
				}
				

				
				Response.WriteFile(filename);
				Response.End();
			}
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			try
			{
				this.DataGridRicerca.CurrentPageIndex=e.NewPageIndex;
				Ricerca();
			}
			catch(System.Web.HttpException ex)
			{
				Console.WriteLine(ex.Message);
				this.DataGridRicerca.CurrentPageIndex=0;
				Ricerca();
			}
		}
	}
}

