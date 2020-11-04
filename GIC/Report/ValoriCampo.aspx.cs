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
using System.Data.SqlClient;

namespace GIC.Report
{
	/// <summary>
	/// Descrizione di riepilogo per ValoriCampo.
	/// </summary>
	public class ValoriCampo : App_Code.BasePage
	{

		private string NomeTabella;
		protected System.Web.UI.WebControls.DataGrid MyDataGrid1;
		private string NomeCampo, Valore, Tipo;
		protected int elementiTrovati;

		private void Page_Load(object sender, System.EventArgs e)
		{
			NomeTabella = Request.QueryString["tabella"];
			NomeCampo = Request.QueryString["campo"];
			Valore = Request.QueryString["valore"];
			Tipo = Request.QueryString["tipo"];
			BindDt();
		}

		private void BindDt()
		{
			ApplicationDataLayer.OracleDataLayer _OraDl;
			_OraDl = new OracleDataLayer(s_ConnStr);
			
			S_ControlsCollection CollezioneParametri=new S_ControlsCollection();


//			S_Object pTabella=new S_Object();
//			pTabella.ParameterName = "pTabella";
//			pTabella.DbType = CustomDBType.VarChar;
//			pTabella.Direction = ParameterDirection.Input;
//			pTabella.Size = 100;
//			pTabella.Value = NomeTabella;
//			pTabella.Index=0;
//			CollezioneParametri.Add(pTabella);


			S_Object pCampo=new S_Object();
			pCampo.ParameterName = "pCampo";
			pCampo.DbType = CustomDBType.VarChar;
			pCampo.Direction = ParameterDirection.Input;
			pCampo.Size = 100;
			pCampo.Value = NomeCampo;
			pCampo.Index=1;
			CollezioneParametri.Add(pCampo);

			S_Object pVal=new S_Object();
			pVal.ParameterName = "pVal";
			pVal.DbType = CustomDBType.VarChar;
			pVal.Direction = ParameterDirection.Input;
			pVal.Size = 100;
			pVal.Value = Valore;
			pVal.Index=2;
			CollezioneParametri.Add(pVal);

			S_Object pTipo=new S_Object();
			pTipo.ParameterName = "pTipo";
			pTipo.DbType = CustomDBType.VarChar;
			pTipo.Direction = ParameterDirection.Input;
			pTipo.Size = 100;
			pTipo.Value = Tipo;
			pTipo.Index=3;
			CollezioneParametri.Add(pTipo);

			Hashtable _HS=(Hashtable) Session["ParametriSelectSchema"];
			string NomeVista = Convert.ToString(_HS["NomeVista"]);

			S_Object pNomeVista=new S_Object();
			pNomeVista.ParameterName = "pNomeVista";
			pNomeVista.DbType = CustomDBType.VarChar;
			pNomeVista.Direction = ParameterDirection.Input;
			pNomeVista.Size = 100;
			pNomeVista.Value = NomeVista;
			pNomeVista.Index=4;
			CollezioneParametri.Add(pNomeVista);

			S_Object s_IdIn=new S_Object();
			s_IdIn.ParameterName = "putente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = 5;
			s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;
			CollezioneParametri.Add (s_IdIn);

			S_Object io_cursor = new S_Object();
			io_cursor.ParameterName = "io_cursor";
			io_cursor.Direction=ParameterDirection.Output;
			io_cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
			io_cursor.Index=6;
			CollezioneParametri.Add(io_cursor);
		
			DataTable dt=new DataTable();
			//Recupero i dati dal DataBase	
			
			dt=_OraDl.GetRows(CollezioneParametri, "IL_PACK_INTERROGAZIONI.IL_SpSelectValCampo").Copy().Tables[0];

			MyDataGrid1.DataSource=dt;
			MyDataGrid1.DataBind();

			elementiTrovati=dt.Rows.Count;
		}


		private void MyDataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || 
				(e.Item.ItemType == ListItemType.AlternatingItem))
				{
					HtmlAnchor link=(HtmlAnchor)e.Item.FindControl("hrefset");
					DataRowView dv=(DataRowView)e.Item.DataItem;

					link.Attributes.Add("onclick","Valorizza('" + dv["valore"] + "')");
				}
		}

		private void MyDataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			MyDataGrid1.CurrentPageIndex=e.NewPageIndex;
			BindDt();
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
			this.MyDataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged);
			this.MyDataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.MyDataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
