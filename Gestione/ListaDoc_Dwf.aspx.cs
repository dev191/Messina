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
using MyCollection; 
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using ApplicationDataLayer.Collections;
using S_Controls.Collections;
using System.IO;

 
namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per DescrizioneDoc_Dwf.
	/// </summary>
	public class ListaDoc_Dwf : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;

		MyCollection.clMyCollection _myColl = new MyCollection.clMyCollection();
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenblid;
		protected Csy.WebControls.DataPanel DataPanel1;
		protected WebControls.RicercaModulo RicercaModulo1;
        protected WebControls.GridTitleServer GridTitleServer1;
		protected S_Controls.S_Button btRicerca;
		protected S_Controls.S_Button btReset;
		protected S_Controls.S_Label lblError;
		protected WebControls.PageTitle PageTitle1;
		DescrizioneDoc_Dwf  _fp=null;
		public MyCollection.clMyCollection _Contenitore
		{
			get {return _myColl;}
		}

		public static int FunId = 0;
		public static string HelpLink = string.Empty;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.GridTitleServer1.hplsNuovo.Visible = _SiteModule.IsEditable;	

			this.DataGrid1.Columns[0].Visible = _SiteModule.IsEditable;
			this.DataGrid1.Columns[1].Visible = _SiteModule.IsEditable;				
						
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;


			RicercaModulo1.DelegateIDBLEdificio1  +=new  WebControls.DelegateIDBLEdificio(this.BindBl);
			GridTitleServer1.NuovoRec1  +=new  WebControls.NuovoRec(this.btNuovo);

			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("this.value = 'Attendere ...';");
			sbValid.Append("this.disabled = true;");
			sbValid.Append("document.getElementById('" + btRicerca.ClientID + "').disabled = true;");
			sbValid.Append(this.Page.GetPostBackEventReference(this.btRicerca));
			sbValid.Append(";");
			this.btRicerca.Attributes.Add("onclick", sbValid.ToString());

			GridTitleServer1.hplsNuovo.Visible =false; 

			if (!IsPostBack)
			{
				
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];

				GridTitleServer1.NumeroRecords ="";

				if(Context.Handler is TheSite.Gestione.DescrizioneDoc_Dwf)
				{
					_fp = (TheSite.Gestione.DescrizioneDoc_Dwf)Context.Handler;
					if (_fp!=null) 
					{						
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);
						GridTitleServer1.hplsNuovo.Visible =true;
						execute();
					}
				}
			}
		}

		private void btNuovo(string sender)
		{   
			_myColl.AddControl(this.Page.Controls, ParentType.Page);
			Context.Items.Add("CODEDI",RicercaModulo1.BlId);
			Context.Items.Add("IDBL",this.IDBL);
			Server.Transfer("DescrizioneDoc_Dwf.aspx"); 
		}
		public void imageButton_Click(Object sender , CommandEventArgs e)
		{  
			string Id=((string)e.CommandArgument).Split(Convert.ToChar(","))[0];
			string FILE=((string)e.CommandArgument).Split(Convert.ToChar(","))[1];
			_myColl.AddControl(this.Page.Controls, ParentType.Page);
			Context.Items.Add("CODEDI",RicercaModulo1.BlId);
			Context.Items.Add("IDDOC",Id);
			Context.Items.Add("IDBL",this.IDBL);
			Context.Items.Add("FILE",FILE);    
	
			Server.Transfer("DescrizioneDoc_Dwf.aspx");
		}
		private string IDBL
		{
			get{return hiddenblid.Value;}
			set{hiddenblid.Value =value;}
		}
		private void BindBl(string idbl)
		{   
			
			DataGrid1.CurrentPageIndex=0;
			GridTitleServer1.hplsNuovo.Visible =true;  
			this.IDBL=idbl;
			execute();
		}

		private void execute()
		{
			lblError.Text="";
			TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF  _AnagrafeDocDWF = new TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF(Context.User.Identity.Name);
			int idbl=0;
			if (this.IDBL!="")
				idbl=  int.Parse(this.IDBL);

			DataSet	_Ds = _AnagrafeDocDWF.GetSingleData(idbl);
			if (_Ds.Tables[0].Rows.Count >0)
			{
				DataGrid1.Visible =true;
				DataGrid1.DataSource = _Ds.Tables[0];
				DataGrid1.DataBind(); 
			}
			else
			{
				DataGrid1.Visible =false;
			}
			if (this.IDBL!="")
				GridTitleServer1.NumeroRecords =string.Format("Documenti legati all'edificio: {0}",  _Ds.Tables[0].Rows.Count.ToString());
			else
				GridTitleServer1.hplsNuovo.Visible =false;
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
			this.btRicerca.Click += new System.EventHandler(this.btRicerca_Click);
			this.btReset.Click += new System.EventHandler(this.btReset_Click);
			this.DataGrid1.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemCreated);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			DataGrid1.CurrentPageIndex=e.NewPageIndex;
			execute();
		}
		
		public string valutastringa(Object obj)
		{
			if (obj!=DBNull.Value && obj.ToString()!="")
			{
				if (obj.ToString().Length >50) 
				  return obj.ToString().Substring(0, obj.ToString().IndexOf(" ",30));
				else 
                 return obj.ToString();
			}
			else
			{
			 return string.Empty; 
			}
		}
		public string valutatooltip(Object obj)
		{
			if (obj!=DBNull.Value && obj.ToString()!="")
                return obj.ToString().Replace("'","`");
			else
                return string.Empty;
		}

		private void DeleteItem(string id)
		{
		 Console.WriteLine(id); 
		 lblError.Text="";
		 if (id=="") return;
			
			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id = new S_Object();
			s_p_id.ParameterName = "p_id_doc_dwf";
			s_p_id.DbType = CustomDBType.Integer ;
			s_p_id.Direction = ParameterDirection.Input;
			s_p_id.Index =0;
			s_p_id.Value = int.Parse(id);
			_SColl.Add(s_p_id);

			TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF  _AnagrafeDocDWF = new TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF(Context.User.Identity.Name);
			
			try
			{
			
				//Recupero il percoro del file da eliminare.
				DataSet Ds= _AnagrafeDocDWF.PathFileDoc(int.Parse(id));
				if (Ds.Tables[0].Rows.Count>0)   
					deleteFile(Ds.Tables[0].Rows[0]);

				_AnagrafeDocDWF.Delete(_SColl, 0);
				DataGrid1.CurrentPageIndex=0;
				execute();
			}
			catch (Exception ex)
			{
               lblError.Text=ex.Message; 
			}
		}
        //Elimina anche il File;
		private void deleteFile(DataRow Dr)
		{
		 string destDir =Server.MapPath("../Doc_DB");
		 string parent=Dr["Parent"].ToString().Replace(" ","_").Replace("/","_"); 
         string child=Dr["Child"].ToString().Replace(" ","_").Replace("/","_"); 

		 string folderParent=System.IO.Path.Combine(destDir, parent);
		 folderParent=System.IO.Path.Combine(folderParent, child);
		 folderParent=System.IO.Path.Combine(folderParent, Dr["filename"].ToString());
         if (File.Exists(folderParent)==true)  
			 File.Delete(folderParent); 
		}

		private void DataGrid1_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType== ListItemType.Item) || (e.Item.ItemType==ListItemType.AlternatingItem) ||
				(e.Item.ItemType==ListItemType.EditItem))
			{
				TableCell myTableCell;
				myTableCell = e.Item.Cells[1];
				ImageButton myDeleteButton=(ImageButton)myTableCell.Controls[1];
				myDeleteButton.Attributes.Add("onclick","return confirm('Sei sicuro di Cancellare il Documento?');");
			}
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if ((e.Item.ItemType == ListItemType.Pager) ||
				(e.Item.ItemType == ListItemType.Header)) return;

			ImageButton btn  = (ImageButton)e.CommandSource;

			if (btn.CommandName  == "Delete")
			{
				DeleteItem(btn.CommandArgument);
			}
		}

		private void btReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ListaDoc_Dwf.aspx?FunId=" + ViewState["FunId"]); 
		}

		private void btRicerca_Click(object sender, System.EventArgs e)
		{
			if (this.IDBL=="")
			{
				String scriptString = "<script language=JavaScript>alert('Selezionare un Edificio!');";
				scriptString += "<";
				scriptString += "/";
				scriptString += "script>";

				if(!this.IsStartupScriptRegistered("clientScriptedificio"))
					this.RegisterStartupScript ("clientScriptedificio", scriptString);
				return;
			}
			DataGrid1.CurrentPageIndex=0;
			GridTitleServer1.hplsNuovo.Visible =true;  
			execute();
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{					
				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton1");
				_img1.Attributes.Add("title","Modifica");

				ImageButton _img2 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton2");
				_img2.Attributes.Add("title","Elimina");
				
			}
		}



		

		
	}
}
