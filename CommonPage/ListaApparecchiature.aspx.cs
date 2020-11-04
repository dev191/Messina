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
using TheSite.Classi.ClassiDettaglio;
using S_Controls.Collections;
using ApplicationDataLayer.DBType;
using MyCollection;

namespace TheSite.CommonPage
{
	/// <summary>
	/// Descrizione di riepilogo per ListaApparecchiature.
	/// </summary>
	public class ListaApparecchiature : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HyperLinkChiudi2;
		protected System.Web.UI.WebControls.DataGrid MyDataGrid1;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
	    protected WebControls.GridTitle GridTitle1; 
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			// Imposto il link nuovo visibile a false
			GridTitle1.hplsNuovo.Visible=false;
			/// Imposto le Porprietà
			if (!IsPostBack)
			{
				if(Request.QueryString["idUsercontrol"]!=null)
					this.idUsercontrol =Request.QueryString["idUsercontrol"]; 
				else
					this.idUsercontrol =string.Empty; 

				if(Request.QueryString["codapp"]!=null)
					this.codapp =Request.QueryString["codapp"]; 
				else
					this.codapp =string.Empty;
 
				if(Request.QueryString["blid"]!=null)
					this.blid =Request.QueryString["blid"]; 
				else
					this.blid =string.Empty;
			
				if(Request.QueryString["lettura"]!=null)
					this.lettura =Request.QueryString["lettura"]; 
				else
					this.lettura =string.Empty;

				if(Request.QueryString["campus"]!=null)
					this.campus =Request.QueryString["campus"]; 
				else
					this.campus =string.Empty;

				if(Request.QueryString["servizioid"]!=null)
					this.servizioid =Request.QueryString["servizioid"]; 
				else
					this.servizioid =string.Empty;

				if(Request.QueryString["appaid"]!=null)
					this.appaid =Request.QueryString["appaid"]; 
				else
					this.appaid =string.Empty;

				if(Request.QueryString["piano"]!=null)
					this.piano =Request.QueryString["piano"]; 
				else
					this.piano =string.Empty;

				if(Request.QueryString["stanza"]!=null)
					this.stanza =Request.QueryString["stanza"]; 
				else
					this.stanza =string.Empty;
				
				this.dismissione =Request.QueryString["dismissione"];

				Execute(true);
			}

			String scriptString = "<script language=JavaScript> var idUsercontrol='" + this.idUsercontrol +"'";
			scriptString += "<";
			scriptString += "/";
			scriptString += "script>";

			if(!this.IsClientScriptBlockRegistered("clientScript"))
				this.RegisterClientScriptBlock("clientScript", scriptString);
			
		}

#region Proprietà
	
		private string idUsercontrol
		{
			get {return (String) ViewState["s_idUsercontrol"];}
			set {ViewState["s_idUsercontrol"] = value;}
		}
		private string codapp
		{
			get {return (String) ViewState["s_codapp"];}
			set {ViewState["s_codapp"] = value;}
		}
		private string blid
		{
			get {return (String) ViewState["s_blid"];}
			set {ViewState["s_blid"] = value;}
		}

			private string lettura
			{
				get {return (String) ViewState["lettura"];}
				set {ViewState["lettura"] = value;}
			}
		private string campus
		{
			get {return (String) ViewState["s_campus"];}
			set {ViewState["s_campus"] = value;}
		}
		private string servizioid
		{
			get {return (String) ViewState["s_servizioid"];}
			set {ViewState["s_servizioid"] = value;}
		}
		private string appaid
		{
			get {return (String) ViewState["s_appaid"];}
			set {ViewState["s_appaid"] = value;}
		}
		private string dismissione
		{
			get {return (String) ViewState["s_dismissione"];}
			set {ViewState["s_dismissione"] = value;}
		}
		private string piano
		{
			get {return (String) ViewState["s_piano"];}
			set {ViewState["s_piano"] = value;}
		}
		private string stanza
		{
			get {return (String) ViewState["s_stanza"];}
			set {ViewState["s_stanza"] = value;}
		}
#endregion
		private S_Controls.Collections.S_ControlsCollection GetControl()
		{
			///Istanzio un nuovo oggetto Collection per aggiungere i parametri
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			///creo i parametri
		
			S_Controls.Collections.S_Object s_p_Bl_Id = new S_Controls.Collections.S_Object();
			s_p_Bl_Id.ParameterName = "p_Bl_Id";
			s_p_Bl_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Bl_Id.Direction = ParameterDirection.Input;
			s_p_Bl_Id.Size =50;
			s_p_Bl_Id.Index = _SCollection.Count;
			s_p_Bl_Id.Value = this.blid;
			_SCollection.Add(s_p_Bl_Id);

			S_Controls.Collections.S_Object s_p_campus = new S_Controls.Collections.S_Object();
			s_p_campus.ParameterName = "p_campus";
			s_p_campus.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_campus.Direction = ParameterDirection.Input;
			s_p_campus.Index = _SCollection.Count;
			s_p_campus.Size=50;
			s_p_campus.Value = this.campus;
			///Aggiungo i parametri alla collection
			_SCollection.Add(s_p_campus);

			S_Controls.Collections.S_Object s_p_Servizio = new S_Controls.Collections.S_Object();
			s_p_Servizio.ParameterName = "p_Servizio";
			s_p_Servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Servizio.Direction = ParameterDirection.Input;
			s_p_Servizio.Index = _SCollection.Count;
			s_p_Servizio.Value = (this.servizioid ==string.Empty)? 0:Int32.Parse(this.servizioid);
			///Aggiungo i parametri alla collection
			_SCollection.Add(s_p_Servizio);

			S_Controls.Collections.S_Object s_p_eqstdid = new S_Controls.Collections.S_Object();
			s_p_eqstdid.ParameterName = "p_eqstdid";
			s_p_eqstdid.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_eqstdid.Direction = ParameterDirection.Input;
			s_p_eqstdid.Size =8;
			s_p_eqstdid.Index = _SCollection.Count;
			s_p_eqstdid.Value = (this.appaid ==string.Empty)? 0:Int32.Parse(this.appaid);
			_SCollection.Add(s_p_eqstdid);

			S_Controls.Collections.S_Object s_p_eq_id = new S_Controls.Collections.S_Object();
			s_p_eq_id.ParameterName = "p_eq_id";
			s_p_eq_id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_eq_id.Direction = ParameterDirection.Input;			
			s_p_eq_id.Index = _SCollection.Count;
			s_p_eq_id.Size =50;
			s_p_eq_id.Value = this.codapp;
			_SCollection.Add(s_p_eq_id);

			S_Controls.Collections.S_Object s_p_piano = new S_Controls.Collections.S_Object();
			s_p_piano.ParameterName = "p_piano";
			s_p_piano.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_piano.Direction = ParameterDirection.Input;			
			s_p_piano.Index = _SCollection.Count;
			s_p_piano.Value = (this.piano=="")?0:int.Parse(this.piano);
			_SCollection.Add(s_p_piano);


			S_Controls.Collections.S_Object s_p_stanza = new S_Controls.Collections.S_Object();
			s_p_stanza.ParameterName = "p_stanza";
			s_p_stanza.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_stanza.Direction = ParameterDirection.Input;			
			s_p_stanza.Index = _SCollection.Count;
			s_p_stanza.Value = (this.stanza=="")?0:int.Parse(this.stanza);
			_SCollection.Add(s_p_stanza);
			return _SCollection;
		}
		private void Execute(bool reset)
		{
			S_Controls.Collections.S_ControlsCollection _SCollection =GetControl();
			S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
			s_p_pageindex.ParameterName = "pageindex";
			s_p_pageindex.DbType = CustomDBType.Integer;
			s_p_pageindex.Direction = ParameterDirection.Input;
			s_p_pageindex.Index = _SCollection.Count +1;
			s_p_pageindex.Value=MyDataGrid1.CurrentPageIndex+1;			
			_SCollection.Add(s_p_pageindex);

			S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
			s_p_pagesize.ParameterName = "pagesize";
			s_p_pagesize.DbType = CustomDBType.Integer;
			s_p_pagesize.Direction = ParameterDirection.Input;
			s_p_pagesize.Index = _SCollection.Count +1;
			s_p_pagesize.Value= MyDataGrid1.PageSize;			
			_SCollection.Add(s_p_pagesize);
			

			DataSet Ds;
			if(lettura=="")
			{
				Classi.AnagrafeImpianti.Apparecchiature  _Apparecchiature =new Classi.AnagrafeImpianti.Apparecchiature(Context.User.Identity.Name);
				Ds=_Apparecchiature.RicercaApparecchiaturaPS(_SCollection);

				if (reset==true)
				{
					_SCollection  =GetControl();
					int _totalRecords = _Apparecchiature.RicercaApparecchiaturaPSCount(_SCollection);
					this.GridTitle1.NumeroRecords=_totalRecords.ToString();
				}
			}
			else
			{
				
				Classi.ClassiAnagrafiche.LetturaContatori  _ApparecchiatureConLett =new Classi.ClassiAnagrafiche.LetturaContatori(Context.User.Identity.Name);
				Ds=_ApparecchiatureConLett.RicercaApparecchiaturaPSPaging(_SCollection);

				if (reset==true)
				{
					_SCollection  =GetControl();
					int _totalRecords = _ApparecchiatureConLett.RicercaApparecchiaturaPSCount(_SCollection);
					this.GridTitle1.NumeroRecords=_totalRecords.ToString();
				}
			}

			
			MyDataGrid1.DataSource =Ds.Tables[0];
			this.MyDataGrid1.VirtualItemCount =int.Parse(this.GridTitle1.NumeroRecords);
			this.MyDataGrid1.DataBind();

 
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

		private void MyDataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			MyDataGrid1.CurrentPageIndex=e.NewPageIndex;
			Execute(false);
		}

		private void MyDataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || 
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				((HtmlAnchor)e.Item.FindControl("hrefset")).HRef="javascript:Popola('" + HttpUtility.HtmlDecode(e.Item.Cells[1].Text).Replace("\"","\\\"") + "','"+ e.Item.Cells[4].Text +  "','" + e.Item.Cells[3].Text + "');";
			}
		}
	}
}
