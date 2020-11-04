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
using TheSite.Classi;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using MyCollection;

namespace TheSite
{
	/// <summary>
	/// Descrizione di riepilogo per ListaEdifici.
	/// </summary>
	public class ListaEdifici : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.HyperLink HyperLinkChiudi2;
		protected System.Web.UI.WebControls.DataGrid MyDataGrid1;
		protected WebControls.GridTitle GridTitle1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			GridTitle1.hplsNuovo.Visible=false;

			String scriptarray = "<script language='JavaScript'>\n";
			scriptarray+="var a = new Array(" + MyDataGrid1.PageSize + ");\n";
			scriptarray+="var b = new Array(" + MyDataGrid1.PageSize + ");\n";
			scriptarray+="var c = new Array(" + MyDataGrid1.PageSize + ");\n";
			scriptarray+="var d = new Array(" + MyDataGrid1.PageSize + ");\n";
			scriptarray+="var e = new Array(" + MyDataGrid1.PageSize + ");\n";
			scriptarray+="var f = new Array(" + MyDataGrid1.PageSize + ");\n";
			scriptarray+="var g = new Array(" + MyDataGrid1.PageSize + ");\n";
			scriptarray+="var h = new Array(" + MyDataGrid1.PageSize + ");\n";
			scriptarray+="var i = new Array(" + MyDataGrid1.PageSize + ");\n";
			scriptarray+="var l = new Array(" + MyDataGrid1.PageSize + ");\n";
			scriptarray+="var m = new Array(" + MyDataGrid1.PageSize + ");\n";
			scriptarray += "<";
			scriptarray += "/";
			scriptarray += "script>";
			if(!Page.IsClientScriptBlockRegistered("array1"))
				Page.RegisterClientScriptBlock("array1", scriptarray);



			if (!Page.IsPostBack)
			{
				/// Recupero i Valori dalla Query string passati per la ricerca
				/// Imposto le Porprietà
				if(Request.QueryString["idcod"]!=null)
					this.idcod =	Request.QueryString["idcod"]; 
				else
					this.idcod =string.Empty; 

				if(Request.QueryString["idric"]!=null)
					this.idric =	Request.QueryString["idric"]; 
				else
					this.idric =string.Empty; 

				if(Request.QueryString["VarApp"]!=null)
					this.prj =	Request.QueryString["VarApp"]; 
				else
					this.prj =string.Empty;
				
				///Eseguo il Binding sulla Griglia
				///
				if(Request.QueryString["idmodulo"]!=null)
					this.idmodulo =	Request.QueryString["idmodulo"]; 
				else
					this.idmodulo =string.Empty;
 
				if(Request.QueryString["ms"]!=null)
					this.multiselect =	Request.QueryString["ms"]; 
				else
					this.multiselect =string.Empty;

				if(Request.QueryString["id_comune"]!=null)
					this.id_comune =	Request.QueryString["id_comune"]; 
				else
					this.id_comune =string.Empty;

				if(Request.QueryString["id_comune"]!=null)
					this.id_frazione =	Request.QueryString["id_frazione"]; 
				else
					this.id_frazione =string.Empty;

				Execute(true);
			} 

			String scriptString = "<script language=JavaScript> var idmodulo='" + this.idmodulo +"'";
			scriptString += "<";
			scriptString += "/";
			scriptString += "script>";

			if(!this.IsClientScriptBlockRegistered("clientScript"))
				this.RegisterClientScriptBlock("clientScript", scriptString);
			GridTitle1.DescriptionTitle="Lista Edifici";
    
		}

		#region Proprietà Private
		
		private string idmodulo
		{
			get {return (String) ViewState["s_idmodulo"];}
			set {ViewState["s_idmodulo"] = value;}
		}

		private string idcod
		{
			get {return (String) ViewState["s_Idcod"];}
			set {ViewState["s_Idcod"] = value;}
		}

		private string idric
		{
			get {return (String) ViewState["s_Idric"];}
			set {ViewState["s_Idric"] = value;}
		}
//		id del  Progetto
		private string prj
		{
			get {return (String) ViewState["VarApp"];}
			set {ViewState["VarApp"] = value;}
		}
		private string multiselect
		{
			get {return (String) ViewState["s_multiselect"];}
			set {ViewState["s_multiselect"] = value;}
		}
		private string id_comune
		{
			get {return (String) ViewState["s_id_comune"];}
			set {ViewState["s_id_comune"] = value;}
		}
		private string id_frazione
		{
			get {return (String) ViewState["s_id_frazione"];}
			set {ViewState["s_id_frazione"] = value;}
		}
		# endregion
		/// <summary>
		/// Istanzia i parametri necessari per eseguire la strore procedure
		/// Esegue la store procedure ed effettua il binding sul datagrid
		/// </summary>
		/// <returns></returns>
		private void Execute(bool reset)
		{
			///Istanzio un nuovo oggetto Collection per aggiungere i parametri
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			///creo i parametri
			///			
			
			S_Controls.Collections.S_Object s_bl_id = new S_Controls.Collections.S_Object();
			s_bl_id.ParameterName = "p_Bl_Id";
			s_bl_id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_bl_id.Direction = ParameterDirection.Input;
			s_bl_id.Size =_SCollection.Count;
			s_bl_id.Index = 0;
			s_bl_id.Size=10;
			s_bl_id.Value = this.idcod;
			_SCollection.Add(s_bl_id);
	
			S_Controls.Collections.S_Object s_p_id_comune = new S_Controls.Collections.S_Object();
			s_p_id_comune.ParameterName = "p_id_comune";
			s_p_id_comune.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_id_comune.Direction = ParameterDirection.Input;
			s_p_id_comune.Index = _SCollection.Count;
			s_p_id_comune.Value = (this.id_comune=="")?0:int.Parse(this.id_comune);
			
			_SCollection.Add(s_p_id_comune);
	
			S_Controls.Collections.S_Object s_p_id_frazione = new S_Controls.Collections.S_Object();
			s_p_id_frazione.ParameterName = "p_id_frazione";
			s_p_id_frazione.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_id_frazione.Direction = ParameterDirection.Input;
			s_p_id_frazione.Index = _SCollection.Count;
			s_p_id_frazione.Value = (this.id_frazione=="")?0:int.Parse(this.id_frazione);
			
			_SCollection.Add(s_p_id_frazione);
		

			S_Controls.Collections.S_Object s_User = new S_Controls.Collections.S_Object();
			s_User.ParameterName = "p_Username";
			s_User.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_User.Direction = ParameterDirection.Input;
			s_User.Size=50; 
			s_User.Index = _SCollection.Count;
			s_User.Value = Context.User.Identity.Name;
			_SCollection.Add(s_User);
			
			S_Controls.Collections.S_Object s_campus = new S_Controls.Collections.S_Object();
			s_campus.ParameterName = "p_campus";
			s_campus.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_campus.Direction = ParameterDirection.Input;
			s_campus.Size=128;
			s_campus.Index = _SCollection.Count;
			s_campus.Value = this.idric;
			_SCollection.Add(s_campus);
			///Aggiungo i parametri alla collection
			

			S_Controls.Collections.S_Object s_pr = new S_Controls.Collections.S_Object();
			s_pr.ParameterName = "p_progetto";
			s_pr.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_pr.Direction = ParameterDirection.Input;
			s_pr.Index = _SCollection.Count;
			s_pr.Value = (this.prj=="")?0:int.Parse(this.prj);
			_SCollection.Add(s_pr);

			///Istanzio la Classe per eseguire la Strore Procedure
			Navigazione _Navigazione =new Navigazione();
			///Eseguo il Binding sulla Griglia.
			Double _totalPages = 1;
		
			if (reset)
			{
				
				int _totalRecords = _Navigazione.GetCount(_SCollection);
				this.GridTitle1.NumeroRecords=_totalRecords.ToString();
				if ((_totalRecords % MyDataGrid1.PageSize) == 0)
					_totalPages = _totalRecords / MyDataGrid1.PageSize;
				else
					_totalPages = (_totalRecords / MyDataGrid1.PageSize)+1;
				_SCollection.RemoveAt(_SCollection.Count-1); 
			}
			else
			{
				_totalPages = Double.Parse (this.GridTitle1.NumeroRecords);
			}

			
			S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
			s_p_pageindex.ParameterName = "pageindex";
			s_p_pageindex.DbType = CustomDBType.Integer;
			s_p_pageindex.Direction = ParameterDirection.Input;
			s_p_pageindex.Index = _SCollection.Count;
			s_p_pageindex.Value=MyDataGrid1.CurrentPageIndex +1;			
			_SCollection.Add(s_p_pageindex);

			S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
			s_p_pagesize.ParameterName = "pagesize";
			s_p_pagesize.DbType = CustomDBType.Integer;
			s_p_pagesize.Direction = ParameterDirection.Input;
			s_p_pagesize.Index = _SCollection.Count;
			s_p_pagesize.Value= MyDataGrid1.PageSize;			
			_SCollection.Add(s_p_pagesize);

            DataSet Ds = _Navigazione.GetData(_SCollection);
			MyDataGrid1.DataSource= Ds;
			this.MyDataGrid1.VirtualItemCount =int.Parse(this.GridTitle1.NumeroRecords);
			MyDataGrid1.DataBind(); 

			GridTitle1.DescriptionTitle="Lista degli Edifici";
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
			this.MyDataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged_1);
			this.MyDataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.MyDataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public Int32 j=0;
		private void MyDataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || 
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{

				string arrayvariable = "<script language='JavaScript'>\n";
				arrayvariable+="a[" + j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[1].Text).Replace("\"","\\\"") +"\";\n";
				arrayvariable+="b[" + j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[2].Text).Replace("\"","\\\"") +"\";\n";
				arrayvariable+="c[" + j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[3].Text).Replace("\"","\\\"") +"\";\n";
				arrayvariable+="d[" + j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[4].Text).Replace("\"","\\\"") +"\";\n";
				arrayvariable+="e[" + j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[5].Text).Replace("\"","\\\"") +"\";\n";
				arrayvariable+="f[" + j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[6].Text).Replace("\"","\\\"") +"\";\n";
				arrayvariable+="g[" + j.ToString() + "] =\"" + e.Item.Cells[7].Text.Replace("&nsp;"," ") +"\";\n";
				arrayvariable+="h[" + j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[8].Text.Replace("&nsp;"," ")) +"\";\n";
				arrayvariable+="i[" + j.ToString() + "] =\"" +  HttpUtility.HtmlDecode(e.Item.Cells[9].Text).Replace("\"","\\\"") +"\";\n";
				arrayvariable+="l[" + j.ToString() + "] =\"" +  HttpUtility.HtmlDecode(e.Item.Cells[10].Text).Replace("\"","\\\"") +"\";\n";
				arrayvariable+="m[" + j.ToString() + "] =\"" +  HttpUtility.HtmlDecode(e.Item.Cells[11].Text).Replace("\"","\\\"") +"\";\n";
				arrayvariable +="<";
				arrayvariable += "/";
				arrayvariable += "script>";

				this.RegisterStartupScript("scriptarray" + j.ToString(),arrayvariable); 
                if (this.multiselect=="y") 
				 ((HtmlAnchor)e.Item.FindControl("hrefset")).HRef="javascript:Popola1(" + j + ");";
				else
				((HtmlAnchor)e.Item.FindControl("hrefset")).HRef="javascript:Popola2(" + j + ");";
  
				j++;
			}
		}

		private void MyDataGrid1_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			MyDataGrid1.CurrentPageIndex=e.NewPageIndex;
			Execute(false);
		}	
	}
		
	}