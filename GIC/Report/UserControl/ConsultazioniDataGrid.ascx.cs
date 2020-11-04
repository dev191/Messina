namespace GIC.Report.UserControl
{
	using System;
	using System.Collections;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for ConsultazioniDataGrid.
	/// </summary>
	public class ConsultazioniDataGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid DataGridQuery;
		protected System.Web.UI.WebControls.TextBox txtQuery;
		private int IdQ; 
		private void Page_Load(object sender, System.EventArgs e)
		{
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Imposta l'id della query
		/// </summary>
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
		public void DysplayGrid()
		{
			Hashtable _HS=(Hashtable) Session["ParametriSelectSchema"];
			string VISTA = Convert.ToString(_HS["NomeVista"]);
			int IdVista = Convert.ToInt32(_HS["IdVista"]);
			VISTA = " " + VISTA + " ";
			TheSite.GIC.App_Code.Consultazioni.interogazioni DQ = new TheSite.GIC.App_Code.Consultazioni.interogazioni();
			DQ.VISTA = VISTA;
			DQ.IdVista= IdVista;
			DataGridQuery.DataSource = DQ.GetData(IdQ); 
			DataGridQuery.DataBind();
		}
		
	}
	
}

