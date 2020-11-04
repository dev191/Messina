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

namespace TheSite.CommonPage
{
	/// <summary>
	/// Descrizione di riepilogo per ListaStanze.
	/// </summary>
	public class ListaStanzeRic : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.DataGrid MyDataGrid1;
		protected System.Web.UI.WebControls.HyperLink HyperLinkChiudi2;
		protected WebControls.GridTitle GridTitle1; 
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			GridTitle1.hplsNuovo.Visible=false;
			/// Imposto le Porprietà
			if (!IsPostBack)
			{
				if(Request.QueryString["idUsercontrol1"]!=null)
					this.idUsercontrol1 =Request.QueryString["idUsercontrol1"]; 
				else
					this.idUsercontrol1 =string.Empty; 

				if(Request.QueryString["blid"]!=null)
					this.blid =Request.QueryString["blid"]; 
				else
					this.blid =string.Empty;

				if(Request.QueryString["codstanza"]!=null)
					this.codstanza =Request.QueryString["codstanza"]; 
				else
					this.codstanza =string.Empty;

				if(Request.QueryString["piano"]!=null)
				{
					if( Request.QueryString["piano"].IndexOf(' ') == -1)
						this.piano =Request.QueryString["piano"]; 
					else
						this.piano=Request.QueryString["piano"].Split(Convert.ToChar(" "))[0];
				}
				else
					this.piano =string.Empty;
				Execute(true);
			}

			String scriptString = "<script language=JavaScript> var idUsercontrol1='" + this.idUsercontrol1 +"'";
			scriptString += "<";
			scriptString += "/";
			scriptString += "script>";

			if(!this.IsClientScriptBlockRegistered("clientScriptst"))
				this.RegisterClientScriptBlock("clientScriptst", scriptString);
	
		}

		private void Execute(bool reset)
		{
			///Istanzio un nuovo oggetto Collection per aggiungere i parametri
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			///creo i parametri


			_SCollection = getParam();

			// nuovi parametri paginazione

			S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
			s_p_pageindex.ParameterName = "pageindex";
			s_p_pageindex.DbType = CustomDBType.Integer;
			s_p_pageindex.Direction = ParameterDirection.Input;
			s_p_pageindex.Index = 16;
			s_p_pageindex.Value=MyDataGrid1.CurrentPageIndex +1;			
			_SCollection.Add(s_p_pageindex);

			S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
			s_p_pagesize.ParameterName = "pagesize";
			s_p_pagesize.DbType = CustomDBType.Integer;
			s_p_pagesize.Direction = ParameterDirection.Input;
			s_p_pagesize.Index = 17;
			s_p_pagesize.Value= MyDataGrid1.PageSize;			
			_SCollection.Add(s_p_pagesize);

			///Istanzio la Classe per eseguire la Strore Procedure
			Classi.AnagrafeImpianti.Apparecchiature  _Apparecchiature =new Classi.AnagrafeImpianti.Apparecchiature(Context.User.Identity.Name);
			
			///Eseguo il Binding sulla Griglia.
			DataSet Ds=_Apparecchiature.RicercaDescStanze(_SCollection);

			// GridTitle1.NumeroRecords=(Ds.Tables[0].Rows.Count)==0? "0":Ds.Tables[0].Rows.Count.ToString();
			MyDataGrid1.DataSource= Ds;

			if (reset)
			{
				_SCollection.Clear();
				_SCollection=getParam();
				int _totalRecords = _Apparecchiature.RicercaStanzeDescCount(_SCollection);
				this.GridTitle1.NumeroRecords=_totalRecords.ToString();
			}

			this.MyDataGrid1.VirtualItemCount =int.Parse(this.GridTitle1.NumeroRecords);

			MyDataGrid1.DataBind(); 



		}


		public S_ControlsCollection getParam(){

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_Bl_Id = new S_Controls.Collections.S_Object();
			s_p_Bl_Id.ParameterName = "p_Id_bl";
			s_p_Bl_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Bl_Id.Direction = ParameterDirection.Input;
			s_p_Bl_Id.Size =50;
			s_p_Bl_Id.Index = _SCollection.Count;
			s_p_Bl_Id.Value =this.blid;
			_SCollection.Add(s_p_Bl_Id);

			S_Controls.Collections.S_Object s_p_piano = new S_Controls.Collections.S_Object();
			s_p_piano.ParameterName = "p_piani";
			s_p_piano.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_piano.Direction = ParameterDirection.Input;			
			s_p_piano.Index = _SCollection.Count;
			s_p_piano.Value = (this.piano=="")?0:int.Parse(this.piano);
			_SCollection.Add(s_p_piano);

			S_Controls.Collections.S_Object s_p_stanza = new S_Controls.Collections.S_Object();
			s_p_stanza.ParameterName = "p_stanza";
			s_p_stanza.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_stanza.Direction = ParameterDirection.Input;
			s_p_stanza.Size =50;
			s_p_stanza.Index = _SCollection.Count;
			s_p_stanza.Value = this.codstanza;
			_SCollection.Add(s_p_stanza);

			return _SCollection;
		}

		#region Proprietà
	
		private string idUsercontrol1
		{
			get {return (String) ViewState["s_idUsercontrol"];}
			set {ViewState["s_idUsercontrol"] = value;}
		}
		private string codstanza
		{
			get {return (String) ViewState["s_codstanza"];}
			set {ViewState["s_codstanza"] = value;}
		}
		private string blid
		{
			get {return (String) ViewState["s_blid"];}
			set {ViewState["s_blid"] = value;}
		}
		private string campus
		{
			get {return (String) ViewState["s_campus"];}
			set {ViewState["s_campus"] = value;}
		}
		private string piano
		{
			get {return (String) ViewState["s_piano"];}
			set {ViewState["s_piano"] = value;}
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
				((HtmlAnchor)e.Item.FindControl("hrefset")).HRef="javascript:Popolast('" + HttpUtility.HtmlDecode(e.Item.Cells[1].Text).Replace("\"","\\\"") + "','" + e.Item.Cells[4].Text + "');";
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
			this.MyDataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.MyDataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
