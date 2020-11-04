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
using TheSite.Classi;
using ApplicationDataLayer.DBType;
 
namespace TheSite
{
	/// <summary>
	/// Descrizione di riepilogo per ListaEdifici.
	/// </summary>
	public class ListaRDL: System.Web.UI.Page
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
			scriptarray += "<";
			scriptarray += "/";
			scriptarray += "script>";
			if(!Page.IsClientScriptBlockRegistered("array1"))
				Page.RegisterClientScriptBlock("array1", scriptarray);



			if (!Page.IsPostBack)
			{
				/// Recupero i Valori dalla Query string passati per la ricerca
				/// Imposto le Porprietà
				
//				if (Request.QueryString["idModi"]!=null)
//					this.idModi = string.Empty;
//				
//				if(Request.QueryString["TipoMan"]!=null)
//					this.TipoMan =	Request.QueryString["TipoMan"]; 
//				else
//					this.TipoMan =string.Empty; 

				// Id RDL
				if(Request.QueryString["idcod"]!=null)
					this.idcod =	Request.QueryString["idcod"]; 
				else
					this.idcod =string.Empty; 
				
				//Mi ha premuto
				if(Request.QueryString["pulsante"]!=null)
					this.pulsante =	Request.QueryString["pulsante"]; 
				else
					this.pulsante =string.Empty; 
				
				//Data DA
				if(Request.QueryString["idric"]!=null)
					this.idric =	Request.QueryString["idric"]; 
				else
					this.idric =string.Empty; 
				//Data A
				if(Request.QueryString["idricA"]!=null)
					this.idricA =	Request.QueryString["idricA"]; 
				else
					this.idricA =string.Empty; 
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

				if(Request.QueryString["oper"]!=null)
					this.opera = Request.QueryString["oper"]; 
				else
					this.opera =string.Empty;

				Execute(true);
			} 

			String scriptString = "<script language=JavaScript> var idmodulo='" + this.idmodulo +"'"; 
			scriptString += "<";
			scriptString += "/";
			scriptString += "script>";

			if(!this.IsClientScriptBlockRegistered("clientScript"))
				this.RegisterClientScriptBlock("clientScript", scriptString);
    
		}

		#region Proprietà Private

//		private string idModi
//		{
//			get {return (String) ViewState["idModi"];}
//			set {ViewState["idModi"] = value;}
//		}
//		
		private string idmodulo
		{
			get {return (String) ViewState["s_idmodulo"];}
			set {ViewState["s_idmodulo"] = value;}
		}

		private string pulsante
		{
			get {return (String) ViewState["pulsante"];}
			set {ViewState["pulsante"] = value;}
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
		
		private string idricA
		{
			get {return (String) ViewState["s_IdricA"];}
			set {ViewState["s_IdricA"] = value;}
		}

		private string opera
		{
			get {return (String) ViewState["s_opera"];}
			set {ViewState["s_opera"] = value;}
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

		private string TipoMan
		{
			get {return (String) ViewState["TipoMan"];}
			set {ViewState["TipoMan"] = value;}
		}
		# endregion
		/// <summary>
		/// Istanzia i parametri necessari per eseguire la strore procedure
		/// Esegue la store procedure ed effettua il binding sul datagrid
		/// </summary>
		/// <returns></returns>
		private void Execute(bool reset)
		{
						///Istanzio la Classe per eseguire la Strore Procedure
			Classi.ManOrdinaria.GestioneRdl _GestioneRdl = new Classi.ManOrdinaria.GestioneRdl(HttpContext.Current.User.Identity.Name);
			///Eseguo il Binding sulla Griglia.
			///Istanzio un nuovo oggetto Collection per aggiungere i parametri
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			///creo i parametri					
			
			DataSet Ds=null;
			if (this.pulsante=="idric") // RICERCO PER data
			{
				


				_SCollection=GetData1();	

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


		
				Ds =_GestioneRdl.GetRDL2(_SCollection);
				
				if (reset==true)
				{
					_SCollection.Clear();
					_SCollection=GetData1();

					int _totalRecords = _GestioneRdl.GetRDL2Count(_SCollection);
					this.GridTitle1.NumeroRecords=_totalRecords.ToString();
				}

			}
			else
			{														
				
				_SCollection=GetData();			

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

				Ds =_GestioneRdl.GetRDL1(_SCollection);

				if (reset==true)
				{
					_SCollection.Clear();
					_SCollection=GetData();
					int _totalRecords = _GestioneRdl.GetRDL1Count(_SCollection);
					this.GridTitle1.NumeroRecords=_totalRecords.ToString();
				}
			}

			MyDataGrid1.DataSource= Ds;



	//		GridTitle1.NumeroRecords=(Ds.Tables[0].Rows.Count)==0? "0":Ds.Tables[0].Rows.Count.ToString();
    		this.MyDataGrid1.VirtualItemCount =int.Parse(this.GridTitle1.NumeroRecords);

			MyDataGrid1.DataBind(); 

			GridTitle1.DescriptionTitle="Lista delle RDL";
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

		// Paolo
		private S_ControlsCollection GetData()
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();		

			S_Controls.Collections.S_Object s_p_wr_id = new S_Controls.Collections.S_Object();
			s_p_wr_id.ParameterName = "p_wr_id";
			s_p_wr_id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_wr_id.Direction = ParameterDirection.Input;
			s_p_wr_id.Size =8;
			s_p_wr_id.Index = 0;
			s_p_wr_id.Value = this.idcod;	
			_SCollection.Add(s_p_wr_id);

			return _SCollection;

		}

		private S_ControlsCollection GetData1()
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();		

			S_Controls.Collections.S_Object s_p_wr_id = new S_Controls.Collections.S_Object();
			s_p_wr_id.ParameterName = "p_wr_id";
			s_p_wr_id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_wr_id.Direction = ParameterDirection.Input;
			s_p_wr_id.Size =8;
			s_p_wr_id.Index = 0;
			s_p_wr_id.Value = this.idcod;	
			_SCollection.Add(s_p_wr_id);

			S_Controls.Collections.S_Object s_p_datain = new S_Controls.Collections.S_Object();
			s_p_datain.ParameterName = "p_datain";
			s_p_datain.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_datain.Direction = ParameterDirection.Input;
			s_p_datain.Size =10;
			s_p_datain.Index =1;
			s_p_datain.Value = this.idric;	
			_SCollection.Add(s_p_datain);

			S_Controls.Collections.S_Object s_p_dataout = new S_Controls.Collections.S_Object();
			s_p_dataout.ParameterName = "p_dataout";
			s_p_dataout.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_dataout.Direction = ParameterDirection.Input;
			s_p_dataout.Size =10;
			s_p_dataout.Index =2;
			s_p_dataout.Value = this.idricA;	
			_SCollection.Add(s_p_dataout);

			return _SCollection;

		}


		// Fine Paolo
		private void MyDataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		if((e.Item.ItemType == ListItemType.Item) || 
				(e.Item.ItemType == ListItemType.AlternatingItem))
		{

				string arrayvariable = "<script language='JavaScript'>\n";
				arrayvariable+="a[" + j.ToString() + "] =\"" + HttpUtility.HtmlDecode(e.Item.Cells[1].Text).Replace("\"","\\\"") +"\";\n";
				arrayvariable +="<";
				arrayvariable += "/";
				arrayvariable += "script>";
				
				this.RegisterStartupScript("scriptarray" + j.ToString(),arrayvariable); 
				if (this.multiselect=="y") 
				{
					
					if (this.opera!="Cerca")
					{
						if (e.Item.Cells[2].Text=="0")
						{
							e.Item.FindControl("hrefset").Visible=true;
							e.Item.FindControl("hrefset1").Visible=false;
							e.Item.Cells[0].ToolTip="";
							((HtmlAnchor)e.Item.FindControl("hrefset")).HRef="javascript:Popola1(" + j + ");";
						}
						else
						{
							e.Item.FindControl("hrefset1").Visible=true;
							e.Item.Cells[0].ToolTip="RdL già fatturata";
							e.Item.FindControl("hrefset").Visible=false;
						}
					}
					else
					{	
						e.Item.FindControl("hrefset1").Visible=false;
						((HtmlAnchor)e.Item.FindControl("hrefset")).HRef="javascript:Popola1(" + j + ");";
					}
				}
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