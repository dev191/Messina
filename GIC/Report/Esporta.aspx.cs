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
using GIC.Report.UserControl;

namespace TheSite.GIC.Report
{
	/// <summary>
	/// Descrizione di riepilogo per Esporta.
	/// </summary>
	public class Esporta : System.Web.UI.Page
	{
		private int IdQ; 

		private void Page_Load(object sender, System.EventArgs e)
		{
			IdQuery=Convert.ToInt32(Request.QueryString["idquery"]);
			Esport();
		}

		public int IdQuery
		{
			get
			{
				return IdQ;
			}
			set
			{
				IdQ = value;
			}
		}
		public void Esport()
		{
			Hashtable _HS=(Hashtable) Session["ParametriSelectSchema"];
			string VISTA = Convert.ToString(_HS["NomeVista"]);
			int IdVista = Convert.ToInt32(_HS["IdVista"]);
			VISTA = " " + VISTA + " ";
			TheSite.GIC.App_Code.Consultazioni.interogazioni DQ = new TheSite.GIC.App_Code.Consultazioni.interogazioni();
			DQ.VISTA = VISTA;
			DQ.IdVista= IdVista;
			DataSet Dt = DQ.GetData(IdQ); 

			Csy.WebControls.Export 	_objExport = new Csy.WebControls.Export();
			DataTable _dt = new DataTable();			
			_dt = Dt.Tables[0].Copy();	
			if (_dt.Rows.Count != 0)
			{
				_objExport.ExportDetails(_dt, Csy.WebControls.Export.ExportFormat.Excel, "exp.xls" ); 		
			}
			else
			{
				String scriptString = "<script language=JavaScript>alert('Nessun elemento da esportare');";
				scriptString += "/";
				scriptString += "script>";

				if(!this.IsClientScriptBlockRegistered("clientScriptexp"))
					this.RegisterStartupScript ("clientScriptexp", scriptString);
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
