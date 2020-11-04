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
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using TheSite.Classi.ClassiDettaglio;
using MyCollection; 
namespace TheSite.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per NavigazioneAppDEMO.
	/// </summary>
	public class NavigazioneAppDEMO : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid MyDataGrid1;
		protected WebControls.GridTitle GridTitle1; 
		protected WebControls.PageTitle PageTitle1;

		public static int FunId = 0;				
		public static string HelpLink = string.Empty;
		public int s_stanza;
		public int s_bl_id;
		public int s_piani;
		public string TitoloPiano;
		public string TitoloStanza;
		TheSite.AnagrafeImpianti.DataRoom _fp;
		MyCollection.clMyCollection _myColl = new MyCollection.clMyCollection();
		S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
		protected System.Web.UI.WebControls.Button BntIndietro;
		Classi.AnagrafeImpianti.DataRoom _DataRoom = new TheSite.Classi.AnagrafeImpianti.DataRoom();

		public MyCollection.clMyCollection _Contenitore
		{ 
			get 
			{
				if(this.ViewState["mioContenitore"]!=null)
					return (MyCollection.clMyCollection)this.ViewState["mioContenitore"];
				else
					return new MyCollection.clMyCollection();
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];

			FunId = int.Parse(Request["FunId"]);
			HelpLink = _SiteModule.HelpLink;
			s_bl_id = (int) int.Parse(Request["var_bl_id"]);
			s_piani = (int) int.Parse(Request["var_piani"]);

			
			if (Request["var_stanza"]== null || Request["var_stanza"]=="" ||Request["var_stanza"]==string.Empty)
			{
				s_stanza=0;
				TitoloPiano = Request["TitoloPiano"].ToString();
				PageTitle1.Title = "Apparecchiature del Piano " + TitoloPiano;
			}
			else
			{
				s_stanza= (int) int.Parse(Request["var_stanza"]);
				TitoloStanza = Request["TitoloStanza"].ToString();
				PageTitle1.Title = "Apparecchiature della Stanza " + TitoloStanza;
			}				
			

			if (!IsPostBack) 
			{	
				Execute();
				GridTitle1.Visible = true;
								
				if(Context.Handler is TheSite.AnagrafeImpianti.DataRoom) 
				{
					_fp = (TheSite.AnagrafeImpianti.DataRoom) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
				}	

			}
			
			GridTitle1.hplsNuovo.Visible=false;

			///DataRoom.aspx?id_edificio_cad=201&id_piano_cad=1&FromWebCad=true
			if (Request.QueryString["FromWebCad"]!=null || Request.QueryString["FromWebCad"].ToString()!=String.Empty)
			{
				if(Request.QueryString["WebCadIndietro"]!=null)
				{
					BntIndietro.Visible=true;
				}
				PageTitle1.VisibleLogut = false;
			}
			else
			{
				PageTitle1.VisibleLogut=true;
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
			this.MyDataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged);
			this.BntIndietro.Click += new System.EventHandler(this.BntIndietro_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void setvisiblecontrol(bool Visibile)
		{
			GridTitle1.VisibleRecord=Visibile;
			GridTitle1.hplsNuovo.Visible =false;
			MyDataGrid1.Visible = Visibile;
		}

		private void Execute()
		{
			S_Controls.Collections.S_Object s_p_bl_id = new S_Controls.Collections.S_Object();
			s_p_bl_id.ParameterName = "p_Id_bl";
			s_p_bl_id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_bl_id.Direction = ParameterDirection.Input;
			s_p_bl_id.Size =50;
			s_p_bl_id.Index = 0;
			s_p_bl_id.Value = s_bl_id;
			_SCollection.Add(s_p_bl_id);

			S_Controls.Collections.S_Object s_p_piani = new S_Controls.Collections.S_Object();
			s_p_piani.ParameterName = "p_piani";
			s_p_piani.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_piani.Direction = ParameterDirection.Input;
			s_p_piani.Size=20;
			s_p_piani.Index = 1;
			s_p_piani.Value = s_piani;
			_SCollection.Add(s_p_piani);

			S_Controls.Collections.S_Object s_p_stanza = new S_Controls.Collections.S_Object();
			s_p_stanza.ParameterName = "p_stanza";
			s_p_stanza.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_stanza.Direction = ParameterDirection.Input;
			s_p_stanza.Size=20;
			s_p_stanza.Index = 2;
			s_p_stanza.Value = s_stanza;
			_SCollection.Add(s_p_stanza);

			DataSet Ds=_DataRoom.RicercaApparecchiaturaPerStanza(_SCollection);
			
			GridTitle1.Visible = true;
			if (Ds.Tables[0].Rows.Count > 0) 
			{
				setvisiblecontrol(true);
				GridTitle1.DescriptionTitle="";
				GridTitle1.NumeroRecords =Ds.Tables[0].Rows.Count.ToString();
				MyDataGrid1.DataSource= Ds.Tables[0];
				MyDataGrid1.DataBind();
			}
			else
			{
				GridTitle1.DescriptionTitle="Nessun dato trovato.";
				setvisiblecontrol(false);
				GridTitle1.Visible=true;
			}
		}

		private void MyDataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			MyDataGrid1.CurrentPageIndex=e.NewPageIndex;
			Execute();
		}

		private void BntIndietro_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("DataRoom.aspx?FunId="+FunId+"&FromWebCad="+Request["FromWebCad"]);
		}

	}
}
