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
using ApplicationDataLayer.DBType;
  
namespace TheSite.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per DocImageGalery.
	/// </summary>
	public class DocImageGalery : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataList DataListImage;
		protected WebControls.PageTitle PageTitle1;
 
	    private int bl_id;
		private int doc_id_servizio;
		private string categoria;
        private int idtip;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{
				if ((Request.QueryString["bl_id"]!=null) && (Request.QueryString["doc_id_servizio"]!=null) && (Request.QueryString["categoria"]!=null))
				{
				  if (Request.QueryString["idtip"]!=null)
				   this.idtip=int.Parse(Request.QueryString["idtip"]);

				  this.bl_id=int.Parse(Request.QueryString["bl_id"]);
				  this.doc_id_servizio=int.Parse(Request.QueryString["doc_id_servizio"]); 
				  this.categoria=(string)Request.QueryString["categoria"];
				  Execute();
				}
			}
			PageTitle1.VisibleLogut =false;
		}

		private void Execute()
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new  S_Controls.Collections.S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_p_bl_id = new S_Controls.Collections.S_Object();
			s_p_bl_id.ParameterName = "p_bl_id";
			s_p_bl_id.DbType = CustomDBType.Integer;
			s_p_bl_id.Direction = ParameterDirection.Input;
			s_p_bl_id.Index = 0;
			s_p_bl_id.Value = this.bl_id;			
			CollezioneControlli.Add(s_p_bl_id);

			S_Controls.Collections.S_Object s_p_doc_id_servizio = new S_Controls.Collections.S_Object();
			s_p_doc_id_servizio.ParameterName = "p_doc_id_servizio";
			s_p_doc_id_servizio.DbType = CustomDBType.Integer;
			s_p_doc_id_servizio.Direction = ParameterDirection.Input;
			s_p_doc_id_servizio.Index = 1;
			s_p_doc_id_servizio.Value = this.doc_id_servizio;			
			CollezioneControlli.Add(s_p_doc_id_servizio);

			S_Controls.Collections.S_Object s_p_categoria = new S_Controls.Collections.S_Object();
			s_p_categoria.ParameterName = "p_categoria";
			s_p_categoria.DbType = CustomDBType.VarChar;
			s_p_categoria.Direction = ParameterDirection.Input;
			s_p_categoria.Index = 2;
			s_p_categoria.Value = this.categoria;			
			s_p_categoria.Size = 50;
			CollezioneControlli.Add(s_p_categoria);

			S_Controls.Collections.S_Object s_p_tipologia = new S_Controls.Collections.S_Object();
			s_p_tipologia.ParameterName = "p_tipologia";
			s_p_tipologia.DbType = CustomDBType.Integer;
			s_p_tipologia.Direction = ParameterDirection.Input;
			s_p_tipologia.Index = 3;
			s_p_tipologia.Value = this.idtip;			
			CollezioneControlli.Add(s_p_tipologia);


			Classi.AnagrafeImpianti.DocDWF  _DocDWF =new Classi.AnagrafeImpianti.DocDWF(); 

			DataSet Ds = _DocDWF.GetDocImage(CollezioneControlli);
            
			DataListImage.DataSource=Ds;
			DataListImage.DataBind();

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
			this.DataListImage.ItemDataBound += new System.Web.UI.WebControls.DataListItemEventHandler(this.DataListImage_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataListImage_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem)
			{
				DataRowView Dr=(DataRowView)e.Item.DataItem;
                string filename= Dr["var_nomedwf"].ToString();
				filename=filename.ToUpper();
				if (!filename.EndsWith("PDF"))
				{
					string Path= Dr["var_percorso_root"].ToString().Replace(" ","_").Replace("/","_");
                    Path+="/" + Dr["var_percorso_child"].ToString().Replace(" ","_").Replace("/","_"); 
					HtmlImage img= (HtmlImage)e.Item.FindControl("imgdoc"); 
					 //PageImage.aspx?<%=Imagename%>&amp;p=y
					img.Src="PageImage.aspx?eq_image=" + filename + "&urlimage=" + Server.UrlDecode(Path) + "&p=y";
                    ((HtmlAnchor)e.Item.FindControl("imagefull")).HRef="FullImage.aspx?eq_image=" + filename + "&urlimage=" + Server.UrlDecode(Path) + "&p=n";
				
				}
			}

		}

	}
}
