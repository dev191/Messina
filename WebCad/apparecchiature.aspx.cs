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
using ApplicationDataLayer.DBType;
using WebCad.Classi.AnagrafeImpianti;

namespace WebCad
{
	/// <summary>
	/// Descrizione di riepilogo per apparecchiature.
	/// </summary>
	public class apparecchiature : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid MyDataGrid1;
		private string descrizione="";
		private int idReparto=0; 
		private int idCategoria=0; 
		private int idDestUso=0;
		private string stringaRm="";
		private string stringaStd="";
		protected string elementiTrovati="0";
		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{
				BindApparecchiature();
			}
		}
		
		private void BindApparecchiature()
		{
			int idPiano=Convert.ToInt32(Request.QueryString["idpiano"]);
			int idEdificio=Convert.ToInt32(Request.QueryString["idbl"]);
			int IdServizio = Convert.ToInt32(Request.QueryString["IdServizio"]);

			if (Request.QueryString["descrizione"]!=null)
				descrizione=Request.QueryString["descrizione"].Trim();

			if (Request.QueryString["idReparto"]!="")
				idReparto=Convert.ToInt32(Request.QueryString["idReparto"]);
			else
				idReparto=0;

			if (Request.QueryString["idCategoria"]!="")
				idCategoria=Convert.ToInt32(Request.QueryString["idCategoria"]);
			else 
				idCategoria=0;

			if (Request.QueryString["idDestUso"]!="")
				idDestUso=Convert.ToInt32(Request.QueryString["idDestUso"]);
			else
				idDestUso=0;

			if (Request.QueryString["stanzeSel"]!=null)
			{
				stringaRm = Request.QueryString["stanzeSel"];
			}
			if (Request.QueryString["stdSel"]!=null)
			{
				stringaStd = Request.QueryString["stdSel"];
			}

			WebCad.WiewCad.Apparecchiature _apparecchiature=new WebCad.WiewCad.Apparecchiature();

			S_ControlsCollection pippoCollezioneControlli = new S_ControlsCollection();
			S_Object bl_id = new S_Object();
			bl_id.ParameterName = "p_bl_id";
			bl_id.DbType = CustomDBType.Integer;
			bl_id.Direction = ParameterDirection.Input;
			bl_id.Value=idEdificio;
			bl_id.Index = pippoCollezioneControlli.Count + 1;
			pippoCollezioneControlli.Add(bl_id);

			S_Object fl_id = new S_Object();
			fl_id.ParameterName = "p_fl_id";
			fl_id.DbType = CustomDBType.Integer;
			fl_id.Direction = ParameterDirection.Input;
			fl_id.Value=idPiano;
			fl_id.Index = pippoCollezioneControlli.Count + 1;
			pippoCollezioneControlli.Add(fl_id);

			S_Object pIdServizio = new S_Object();
			pIdServizio.ParameterName = "pIdServizio";
			pIdServizio.DbType = CustomDBType.Integer;
			pIdServizio.Direction = ParameterDirection.Input;
			pIdServizio.Value=IdServizio;
			pIdServizio.Index = pippoCollezioneControlli.Count + 1;
			pippoCollezioneControlli.Add(pIdServizio);

			S_Object pdescrizione = new S_Object();
			pdescrizione.ParameterName = "p_descr";
			pdescrizione.DbType = CustomDBType.VarChar;
			pdescrizione.Size=100;
			pdescrizione.Direction = ParameterDirection.Input;
			pdescrizione.Value=descrizione;
			pdescrizione.Index = pippoCollezioneControlli.Count + 1;
			pippoCollezioneControlli.Add(pdescrizione);
                                     
			S_Object p_cat_id = new S_Object();
			p_cat_id.ParameterName = "p_cat_id";
			p_cat_id.DbType = CustomDBType.Integer;
			p_cat_id.Direction = ParameterDirection.Input;
			p_cat_id.Value=idCategoria;
			p_cat_id.Index = pippoCollezioneControlli.Count + 1;
			pippoCollezioneControlli.Add(p_cat_id);

			S_Object p_reparto_id = new S_Object();
			p_reparto_id.ParameterName = "p_reparto_id";
			p_reparto_id.DbType = CustomDBType.Integer;
			p_reparto_id.Direction = ParameterDirection.Input;
			p_reparto_id.Value=idReparto;
			p_reparto_id.Index = pippoCollezioneControlli.Count + 1;
			pippoCollezioneControlli.Add(p_reparto_id);

			S_Object p_dest_uso_id = new S_Object();
			p_dest_uso_id.ParameterName = "p_dest_uso_id";
			p_dest_uso_id.DbType = CustomDBType.Integer;
			p_dest_uso_id.Direction = ParameterDirection.Input;
			p_dest_uso_id.Value=idDestUso;
			p_dest_uso_id.Index = pippoCollezioneControlli.Count + 1;
			pippoCollezioneControlli.Add(p_dest_uso_id);

			S_Object p_str_stanze = new S_Object();
			p_str_stanze.ParameterName = "p_str_stanze";
			p_str_stanze.DbType = CustomDBType.VarChar;
			p_str_stanze.Size=500;
			p_str_stanze.Direction = ParameterDirection.Input;
			p_str_stanze.Value=stringaRm;
			p_str_stanze.Index = pippoCollezioneControlli.Count + 1;
			pippoCollezioneControlli.Add(p_str_stanze);

			S_Object p_str_std = new S_Object();
			p_str_std.ParameterName = "p_str_std";
			p_str_std.DbType = CustomDBType.VarChar;
			p_str_std.Size=500;
			p_str_std.Direction = ParameterDirection.Input;
			p_str_std.Value=stringaStd;
			p_str_std.Index = pippoCollezioneControlli.Count + 1;
			pippoCollezioneControlli.Add(p_str_std);

			DataSet ds= _apparecchiature.GetData(pippoCollezioneControlli);
			MyDataGrid1.DataSource=ds;
			elementiTrovati=Convert.ToString(ds.Tables[0].Rows.Count);
			MyDataGrid1.DataBind();
		}

		private void MyDataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || 
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				HtmlAnchor link=(HtmlAnchor)e.Item.FindControl("hrefset");
				DataRowView dv=(DataRowView)e.Item.DataItem;

				link.Attributes.Add("onclick","Valorizza('" + dv["id"] + "','" + dv["descrizione"]  + "')");
			}
		}

		private void MyDataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			MyDataGrid1.CurrentPageIndex=e.NewPageIndex;
			BindApparecchiature();
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
