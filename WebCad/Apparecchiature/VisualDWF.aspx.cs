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
using ApplicationDataLayer.DBType;
 
namespace WebCad.Apparecchiature
{
	/// <summary>
	/// Descrizione di riepilogo per VisualDWF.
	/// </summary>
	public class VisualDWF : System.Web.UI.Page
	{
		protected Csy.WebControls.DataPanel DataPanel1;
		protected System.Web.UI.WebControls.Repeater Repeater1;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected WebControls.PageTitle PageTitle1; 
		private string _filname;
		private string _vvf=string.Empty;
		private string _ispesl=string.Empty;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			//DA rimettere Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			//DA rimettere this.PageTitle1.Title = _SiteModule.ModuleTitle;
            this.PageTitle1.VisibleLogut=false;
 
			if(!IsPostBack)
			{
				if (Request.QueryString["var_afm_dwgs_dwg_name"]!=null)
				{
				  this.vvf =(Request.QueryString["var_vvf"]==null)?string.Empty:(string)Request.QueryString["var_vvf"];
				  this.ispesl =(Request.QueryString["var_ispesl"]==null)?string.Empty:(string)Request.QueryString["var_ispesl"];
				  this.filname =(string)Request.QueryString["var_afm_dwgs_dwg_name"];
				  Execute();
				}
				if (Context.Items["var_afm_dwgs_dwg_name"]!=null)
				{
					this.vvf =(Context.Items["var_vvf"]==null)?string.Empty:(string)Context.Items["var_vvf"];
					this.ispesl =(Context.Items["var_ispesl"]==null)?string.Empty:(string)Context.Items["var_ispesl"];
					this.filname =(string)Context.Items["var_afm_dwgs_dwg_name"];
					Execute();
				}
			}
		}
		/// <summary>
		/// Proprietà Imposta e visualizza il nome del file.
		/// </summary>
		private string filname
		{
				get {return _filname;}
				set {_filname=value;}
		}
		private string ispesl
		{
			get {return _ispesl;}
			set {_ispesl=value;}
		}
		private string vvf
		{
			get {return _vvf;}
			set {_vvf=value;}
		}
		/// <summary>
		/// Recupera le informazioni relative al documento
		/// </summary>
		private void Execute()
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new  S_Controls.Collections.S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_p_filname = new S_Controls.Collections.S_Object();
			s_p_filname.ParameterName = "p_filname";
			s_p_filname.DbType = CustomDBType.VarChar;
			s_p_filname.Direction = ParameterDirection.Input;
			s_p_filname.Index = 0;
			s_p_filname.Value = this.filname;			
			s_p_filname.Size = 50;
			CollezioneControlli.Add(s_p_filname);

			Classi.AnagrafeImpianti.DocDWF  _DocDWF =new Classi.AnagrafeImpianti.DocDWF(); 

			DataSet Ds = _DocDWF.GetData(CollezioneControlli);

			Repeater1.DataSource=Ds;
			Repeater1.DataBind();
 
            if (Ds.Tables[0].Rows.Count>0)   
               GetFile(Ds.Tables[0].Rows[0]["var_percorso_root"].ToString(),Ds.Tables[0].Rows[0]["var_percorso_child"].ToString());
		}

		private void GetFile(string PathRoot,string PathChild)
		{
			string PathFileName="";
			PathRoot=PathRoot.Replace(" ","_");
			PathChild=PathChild.Replace(" ","_").Replace("/","_");
			
			PathFileName="../Doc_DB/" + PathRoot + "/" + PathChild + "/" + this.filname ; 
			string tipo=string.Empty;
			if (this.filname.ToUpper().EndsWith("DWF"))
			{
				tipo="codebase=\"http://www.autodesk.com/global/expressviewer/installer/ExpressViewerSetup_ITA.cab\""; 
				Literal1.Text="<embed src=\"" + PathFileName + "\" height=\"100%\" width=\"100%\" " + tipo + "></embed>";
			}
			else if (this.filname.ToUpper().EndsWith("PDF"))
			{
				tipo="type=\"application/pdf\"";
				Literal1.Text="<embed src=\"" + PathFileName + "\" height=\"100%\" width=\"100%\" " + tipo + "></embed>";
			}
			else
			{
				Literal1.Text="<img src=\"" + PathFileName + "\" border=\"0\">";
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
			this.Repeater1.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.Repeater1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
			{
				DataRowView Dr =(DataRowView)e.Item.DataItem;
				string StringHtml=string.Empty;
				if(this.vvf!= string.Empty)
				{
				StringHtml+="<td><b>Numero Fascicolo: </b>" + Dr["var_afm_dwgs_n_fascicolo_vvf"] + "</td>\n";
			    StringHtml+="<td><b>Data Parere Favorevole: </b>" + Dr["var_afm_dwgs_data_p_fav"] + "</td>\n";
					if(Convert.ToInt32(Dr["var_afm_dwgs_collaudo"].ToString()) ==1)
					{
						StringHtml+="<td><b>Collaudo: </b>SI</td>";
					}
						else
					{
						StringHtml+="<td><b>Collaudo: </b>NO</td>";
					}
				}

				if(this.ispesl!= string.Empty)
				{
					StringHtml+="<td><b>Numero Matricola: </b>" + Dr["var_afm_dwgs_matricola_ispesl"] + "</td>\n";
					StringHtml+="<td><b>Data Prima Verifica: </b>" + Dr["var_afm_dwgs_data_p_ver"] + "</td>\n";
					StringHtml+="<td><b>Anno Scadenza: </b>" + Dr["var_afm_dwgs_anno_scadenza"] + "</td>\n";
				}
                 ((Literal)e.Item.FindControl("lite")).Text= StringHtml;
			}

		}
	}
}
