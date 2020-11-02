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
using S_Controls.Collections;
using TheSite.AnagrafeImpianti; 
using ApplicationDataLayer.DBType;

namespace TheSite.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per ServiceDettail.
	/// </summary>
	public class ServiceDettail : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected WebControls.PageTitle PageTitle1;
		protected Csy.WebControls.DataPanel DataPanelDatiGenerali;
		protected Csy.WebControls.DataPanel DataPanelDocImage;
		protected Csy.WebControls.DataPanel PanelElaboratiTecnici;
		protected Csy.WebControls.DataPanel  DataPanelPrestazioniEnergetiche;
		protected System.Web.UI.WebControls.Repeater Repeaterricfotografica;
		protected System.Web.UI.WebControls.Repeater RepeaterDatigerali;
		protected System.Web.UI.WebControls.Repeater RepeaterDiagnosiEnergetica;
		protected System.Web.UI.WebControls.Repeater RepeaterElaboratiTecnici;
		protected System.Web.UI.WebControls.Repeater RepeaterCertificazioni;
		protected System.Web.UI.WebControls.Repeater RepeaterApparecchiature;
		protected System.Web.UI.HtmlControls.HtmlInputButton BtnPopUp;
		protected System.Web.UI.WebControls.Repeater RepeaterPrestazioni;
		
		private Int32 _bl_id;
		private Int32 _servizio_id;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			PageTitle1.VisibleLogut=false;
			if (!IsPostBack)
			{
				if ((Request.QueryString["bl_id"]!=null) && (Request.QueryString["servizio_id"]!=null))
				{
					bl_id=Int32.Parse(Request.QueryString["bl_id"]);
					servizio_id=Int32.Parse(Request.QueryString["servizio_id"]);
					string parametri=bl_id+"&servizio_id="+servizio_id+"&chiamante=me";
					BtnPopUp.Attributes.Add("onclick","OpenPopUp('" + parametri + "');");
					if (Request.QueryString["chiamante"]!=null)
						BtnPopUp.Attributes.Add("style","DISPLAY: none");
					DatiGenerali();
					DiagnosiEnergetica();
					RicognizioneFotografica();
					ElaboratiTecnici();
					Certificazioni();
					Apparecchiature();
					PrestazioniEnergetiche();
				}

			}
		}

		public int bl_id
		{
			get {return _bl_id;}
			set{_bl_id=value;}
		}

		
		public int servizio_id
		{
			get {return _servizio_id;}
			set{_servizio_id=value;}
		}
		/// <summary>
		/// Recupero i dati generali dell'edificio.
		/// </summary>
		private void DatiGenerali()
		{
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.AnagrafeImpianti.SeviceDettail  _SeviceDettail = new Classi.AnagrafeImpianti.SeviceDettail(Context.User.Identity.Name);

			DataSet Ds;				
			Ds = _SeviceDettail.GetSingleData(bl_id);
			RepeaterDatigerali.DataSource =Ds;
			RepeaterDatigerali.DataBind();
		}
		private void PrestazioniEnergetiche()
		{
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.AnagrafeImpianti.SeviceDettail  _SeviceDettail = new Classi.AnagrafeImpianti.SeviceDettail(Context.User.Identity.Name);

			DataSet Ds;				
			Ds = _SeviceDettail.PerestazioniEdificio(bl_id);
			RepeaterPrestazioni.DataSource =Ds;
			RepeaterPrestazioni.DataBind();
		}

        /// <summary>
        /// Recupero i documenti e le immagini alle DiagnosiEnergetica all'edificio
        /// </summary>
		private void DiagnosiEnergetica()
		{
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.AnagrafeImpianti.SeviceDettail  _SeviceDettail = new Classi.AnagrafeImpianti.SeviceDettail(Context.User.Identity.Name);

			DataSet Ds;				
			Ds = _SeviceDettail.GetDiagnosiEnergetica(bl_id);
			RepeaterDiagnosiEnergetica.DataSource =Ds;
			RepeaterDiagnosiEnergetica.DataBind();
		}
		/// <summary>
		/// Recupero i documenti e le immagini relative alla ricognizione Fotografica legate all'edificio
		/// </summary>
		private void RicognizioneFotografica()
		{
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.AnagrafeImpianti.SeviceDettail  _SeviceDettail = new Classi.AnagrafeImpianti.SeviceDettail(Context.User.Identity.Name);

			DataSet Ds;				
			Ds = _SeviceDettail.GetRicognizioneFotografica(bl_id);
			Repeaterricfotografica.DataSource =Ds;
			Repeaterricfotografica.DataBind();
		}

		/// <summary>
		/// Elaborati Tecnici
		/// </summary>
		private void ElaboratiTecnici()
		{
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.AnagrafeImpianti.SeviceDettail  _SeviceDettail = new Classi.AnagrafeImpianti.SeviceDettail(Context.User.Identity.Name);

			DataSet Ds;				
			Ds = _SeviceDettail.GetElaboratiTecnici(bl_id);
			RepeaterElaboratiTecnici.DataSource =Ds;
			RepeaterElaboratiTecnici.DataBind();
		}
		/// <summary>
		/// Certificazioni
		/// </summary>
		private void Certificazioni()
		{
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.AnagrafeImpianti.SeviceDettail  _SeviceDettail = new Classi.AnagrafeImpianti.SeviceDettail(Context.User.Identity.Name);

			DataSet Ds;				
			Ds = _SeviceDettail.GetCertificazioni(bl_id);
			RepeaterCertificazioni.DataSource =Ds;
			RepeaterCertificazioni.DataBind();
		}
		/// <summary>
		/// Apparecchiature
		/// </summary>
		private void Apparecchiature()
		{
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.AnagrafeImpianti.SeviceDettail  _SeviceDettail = new Classi.AnagrafeImpianti.SeviceDettail(Context.User.Identity.Name);

			DataSet Ds;				
			Ds = _SeviceDettail.GetApparecchiature(this.bl_id,this.servizio_id);
			RepeaterApparecchiature.DataSource =Ds;
			RepeaterApparecchiature.DataBind();
		}
		#region Proprietà
		private string _servizio=string.Empty;
		public string TitleService(string servizio)
		{
			if (_servizio!=servizio)
			{
				_servizio=servizio;
				return _servizio;
			}
			else
			{
				return string.Empty; 
			}
		}
		#endregion

		/// <summary>
		/// Evento ItemDataBound del repeater RepeaterElaboratiTecnici per ElaboratiTecnici
		/// </summary>
		/// <param name="Sender"></param>
		/// <param name="e"></param>
		protected void RepeaterElaboratiTecnici_ItemDataBound(Object Sender, RepeaterItemEventArgs e) 
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
			{
                 
				if ((DataBinder.Eval(e.Item.DataItem, "var_file_pdf")!=System.DBNull.Value) 
					&& (DataBinder.Eval(e.Item.DataItem, "var_file_pdf").ToString()!=""))
				{
					HtmlAnchor href= new HtmlAnchor();
					string script="javascript:opendoc('var_afm_dwgs_dwg_name=" + DataBinder.Eval(e.Item.DataItem, "var_file_name") +  ".pdf');";
					href.HRef=script;
					href.InnerText =DataBinder.Eval(e.Item.DataItem, "var_file_name").ToString();
					((PlaceHolder)e.Item.FindControl("placercontrols")).Controls.Add(href);     
				}
				else
				{
					PlaceHolder Place=(PlaceHolder)e.Item.FindControl("placercontrols");
					Literal lite=new Literal();
					lite.Text=DataBinder.Eval(e.Item.DataItem, "var_file_name").ToString();
					Place.Controls.Add(lite);
  
					if ((DataBinder.Eval(e.Item.DataItem, "var_file_dwf")!=System.DBNull.Value) 
						&& (DataBinder.Eval(e.Item.DataItem, "var_file_dwf").ToString()!=""))
						{
							HtmlImage img=new HtmlImage(); 
							img.Src="../Images/ico_info.gif";
							img.Border=0; 
							img.Alt="Visualizza Schema";
		 
							HtmlAnchor href= new HtmlAnchor();
							string script="javascript:opendoc('var_afm_dwgs_dwg_name=" +  DataBinder.Eval(e.Item.DataItem, "var_file_name") + ".dwf');";
							href.HRef=script;

		                    href.Controls.Add(img); 
							Place.Controls.Add(href);
						}

						if ((DataBinder.Eval(e.Item.DataItem, "var_file_jpg")!=System.DBNull.Value) 
							&& (DataBinder.Eval(e.Item.DataItem, "var_file_jpg").ToString()!=""))
						{
							HtmlImage img=new HtmlImage(); 
							img.Src="../Images/ico_info.gif";
							img.Border=0; 
							img.Alt="Visualizza Immagine";

							HtmlAnchor href= new HtmlAnchor();
							string script="javascript:opendoc('var_afm_dwgs_dwg_name=" +  DataBinder.Eval(e.Item.DataItem, "var_file_name") + ".jpg');";
							href.HRef=script;

							href.Controls.Add(img); 
							Place.Controls.Add(href); 
						}

				}//end if
				
			}//end if

		}
		/// <summary>
		/// Elaborazione delle Certificazioni
		/// </summary>
		/// <param name="Sender"></param>
		/// <param name="e"></param>
		protected void RepeaterCertificazioni_ItemDataBound(Object Sender, RepeaterItemEventArgs e) 
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
			{
				DataRowView Dr =(DataRowView)e.Item.DataItem;

				TableRow Riga=new TableRow();
				TableCell Cella1=new TableCell(); 
				TableCell Cella2=new TableCell();
				TableCell Cella3=new TableCell();
				TableCell Cella4=new TableCell();

				if (Dr["ext"].ToString().ToUpper()=="PDF" )
				{
					HtmlAnchor href= new HtmlAnchor();
					string script="javascript:opendoc('var_afm_dwgs_dwg_name=" +  Dr["var_nome_doc"] + "');";
					href.HRef=script;
					href.InnerText =Dr["var_nome_doc"].ToString();

                    Cella1.Text= Dr["var_servizio"].ToString();
					Cella2.Controls.Add(href); 
					Cella3.Text= Dr["var_afm_dwgs_tipo"].ToString(); 
					Cella4.Text= Dr["var_descrizione"].ToString();
                    Riga.Controls.Add(Cella1);
					Riga.Controls.Add(Cella2);
					Riga.Controls.Add(Cella3);
					Riga.Controls.Add(Cella4);
					e.Item.Controls.Add(Riga);   
				}
				else
				{
					if (_tipologia != Dr["var_tipologia"].ToString()) 
					{

						_tipologia=Dr["var_tipologia"].ToString();

						HtmlImage img=new HtmlImage(); 
						img.Src="../Images/ico_info.gif";
						img.Border=0; 
						img.Alt="Visualizza Immagine";
						
						HtmlAnchor href= new HtmlAnchor();
						string script="javascript:opendoc1('bl_id=" + this.bl_id.ToString() +  "&doc_id_servizio=" + Dr["var_id_servizio"].ToString() + "&categoria=" + Dr["var_categoria"].ToString() + "');";
						href.HRef=script;
						href.Controls.Add(img); 

						Cella1.Text= Dr["var_servizio"].ToString();
						Cella2.Attributes.Add("align","center");  
						Cella2.Controls.Add(href); 
						Cella3.Text= "Raccolta Fotografica " + Dr["var_tipologia"].ToString(); 
						Cella4.Text= Dr["var_descrizione"].ToString();
						Riga.Controls.Add(Cella1);
						Riga.Controls.Add(Cella2);
						Riga.Controls.Add(Cella3);
						Riga.Controls.Add(Cella4);
						e.Item.Controls.Add(Riga);  
					}

				}
			}
		}
		/// <summary>
		/// Variabile di appogio per l'item Data Bound delle Certificazioni
		/// </summary>
		private string _tipologia;

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
			this.RepeaterElaboratiTecnici.ItemDataBound  += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.RepeaterElaboratiTecnici_ItemDataBound);
		    this.RepeaterCertificazioni.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.RepeaterCertificazioni_ItemDataBound);
		}
		#endregion
	}
}
