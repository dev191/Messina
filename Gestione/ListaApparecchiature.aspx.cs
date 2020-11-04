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
	/// Descrizione di riepilogo per ListaApparecchiature.
	/// </summary>
	public class ListaApparecchiature : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	    protected WebControls.RicercaModulo RicercaModulo1;
		protected WebControls.PageTitle PageTitle1;
        protected WebControls.GridTitleServer GridTitleServer1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenblid;
   
		MyCollection.clMyCollection _myColl = new MyCollection.clMyCollection();
		protected Csy.WebControls.DataPanel DataPanel1;
		protected S_Controls.S_Button btRicerca;
		protected S_Controls.S_Button brreset;
		DescrizioneApparecchiatura  _fp=null;
		public MyCollection.clMyCollection _Contenitore
		{
			get {return _myColl;}
		}
		
		public static int FunId = 0;
		protected S_Controls.S_ComboBox cmbsPiano;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected System.Web.UI.WebControls.RequiredFieldValidator RQServizio;
		protected S_Controls.S_ComboBox cmbsApparecchiatura;
		protected WebControls.CodiceApparecchiature CodiceApparecchiature1;
		protected WebControls.UserStanze UserStanze1;

		public static string HelpLink = string.Empty;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.GridTitleServer1.hplsNuovo.Visible = _SiteModule.IsEditable;	

			this.DataGrid1.Columns[0].Visible = _SiteModule.IsEditable;
			this.DataGrid1.Columns[1].Visible = _SiteModule.IsEditable;				
						
			if(Request.QueryString["FunId"]!= null)
				FunId=Convert.ToInt32(Request.QueryString["FunId"]);
			else
				FunId = _SiteModule.ModuleId;

			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;

			// Inserire qui il codice utente necessario per inizializzare la pagina.
			RicercaModulo1.DelegateIDBLEdificio1  +=new  WebControls.DelegateIDBLEdificio(this.BindBl);
			RicercaModulo1.DelegateIDBLEdificio1  +=new  WebControls.DelegateIDBLEdificio(this.BindPiano);	
			RicercaModulo1.DelegateIDBLEdificio1 += new WebControls.DelegateIDBLEdificio(this.BindApparecchiatura);
			//RicercaModulo1.DelegateIDBLEdificio1  +=new  WebControls.DelegateIDBLEdificio(this.BindStanza);
			CodiceApparecchiature1.NameComboApparecchiature ="cmbsApparecchiatura";
			/// Imposto il nome della combo Servizio
			CodiceApparecchiature1.NameComboServizio ="cmbsServizio";
			/// Imposto il nome dell'user control RicercaModulo
			CodiceApparecchiature1.NameUserControlRicercaModulo  ="RicercaModulo1";
			

			UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
			UserStanze1.NameComboPiano="cmbsPiano";

            GridTitleServer1.NuovoRec1  +=new  WebControls.NuovoRec(this.btNuovo);

			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("if (typeof(seledificio) == 'function') { ");
			sbValid.Append("if (seledificio() == false) { return false; }} ");
			sbValid.Append("this.value = 'Attendere ...';");
			sbValid.Append("this.disabled = true;");
			sbValid.Append("document.getElementById('" + btRicerca.ClientID + "').disabled = true;");
			sbValid.Append(this.Page.GetPostBackEventReference(this.btRicerca));
			sbValid.Append(";");
			this.btRicerca.Attributes.Add("onclick", sbValid.ToString());



			if (!IsPostBack)
			{
				GridTitleServer1.hplsNuovo.Visible =false; 
				cmbsServizio.Enabled =false;
				cmbsPiano.Enabled =false;
				//cmbsStanza.Enabled=false;
				cmbsApparecchiatura.Enabled=false;
				CodiceApparecchiature1.Visible=false;
				
				GridTitleServer1.NumeroRecords ="";

				if(Context.Handler is TheSite.Gestione.DescrizioneApparecchiatura)
				{
					_fp = (TheSite.Gestione.DescrizioneApparecchiatura)Context.Handler;
					if (_fp!=null) 
					{						
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);
						GridTitleServer1.hplsNuovo.Visible =true;
						BindServizio(this.IDBL);
						BindApparecchiatura(cmbsServizio.SelectedValue);
						BindPiano(this.IDBL);
					//	BindStanza();
						execute();
					}
				}
			}
	
		}
		private void btNuovo(string sender)
		{   
			if (cmbsServizio.SelectedIndex==0 || cmbsServizio.SelectedIndex==-1) return;
			_myColl.AddControl(this.Page.Controls, ParentType.Page);
			Context.Items.Add("CODEDI",RicercaModulo1.BlId);
			Context.Items.Add("IDBL",this.IDBL);
			//Descrizione del servizio
			Context.Items.Add("SDESCRIZIONE",cmbsServizio.Items[cmbsServizio.SelectedIndex].Text);
			//codice del servizio
			//MARIANNA
			//Context.Items.Add("SCODICE",cmbsServizio.SelectedValue.Split(Convert.ToChar(" "))[1]);
			//id del servizio
			Context.Items.Add("SID",cmbsServizio.SelectedValue);
			Server.Transfer("DescrizioneApparecchiatura.aspx"); 
		}
		public void imageButton_Click(Object sender , CommandEventArgs e)
		{  
			
			_myColl.AddControl(this.Page.Controls, ParentType.Page);
			Context.Items.Add("CODEDI",RicercaModulo1.BlId);			
			Context.Items.Add("IDBL",this.IDBL);
			
			string[] splitarg = e.CommandArgument.ToString().Split(Convert.ToChar(","));
			Context.Items.Add("IDEQ",(string)splitarg[0]);
			Context.Items.Add("DISMESSO",(string)splitarg[1]);
			
			Server.Transfer("DescrizioneApparecchiatura.aspx");
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
			if (idbl!="")
				this.IDBL=idbl;
			else
			{
				String scriptString = "<script language=JavaScript>alert('Selezionare un Edificio!');";
				scriptString += "<";
				scriptString += "/";
				scriptString += "script>";

				if(!this.IsStartupScriptRegistered("clientScriptedificio"))
					this.RegisterStartupScript ("clientScriptedificio", scriptString);
				this.IDBL="";
				cmbsServizio.Items.Clear();
				cmbsServizio.Enabled =false;
				cmbsPiano.Enabled =false;
			//	cmbsStanza.Enabled=false;
				cmbsApparecchiatura.Enabled=false;
				CodiceApparecchiature1.Visible=false;
				return;
			}
			cmbsServizio.Enabled =true;
			cmbsPiano.Enabled =true;
		//	cmbsStanza.Enabled =true;
			cmbsApparecchiatura.Enabled=true;
			CodiceApparecchiature1.Visible=true;
			BindServizio(this.IDBL);
			BindPiano(this.IDBL);
	//		BindStanza();
			execute();
		}
		private void execute()
		{
			TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura  _DatiApparecchiatura = new TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura(Context.User.Identity.Name);
			int idbl=0;
            if (this.IDBL!="")
               idbl=  int.Parse(this.IDBL);

			if(cmbsServizio.SelectedIndex ==0) 
			{
				RQServizio.Visible =true;
				return;
			}

            int idservizio=  int.Parse(cmbsServizio.SelectedValue.Split(Convert.ToChar(" "))[0]);
			int idpiano =  int.Parse(cmbsPiano.SelectedValue.Split(Convert.ToChar(" "))[0]);
			string stanza;
			int idstapp;
			int idcodapp;
			
			
			if (CodiceApparecchiature1.CodiceHidden.Value=="")
			{
              idcodapp=-1;
			}
			else
			{
              idcodapp=int.Parse(CodiceApparecchiature1.CodiceHidden.Value);
			}

				stanza = UserStanze1.DescStanza;
			
			 
			if (cmbsApparecchiatura.SelectedValue=="")
			{
				idstapp=-1;
			}
			else
			{
                idstapp = int.Parse(cmbsApparecchiatura.SelectedValue);
			}
			 
			DataSet	_MyDs = _DatiApparecchiatura.GetApparecchiature(idbl,idservizio,idpiano,stanza,idstapp, idcodapp);
			
			if (_MyDs.Tables[0].Rows.Count >0)
			{
				DataGrid1.Visible =true;
				DataGrid1.DataSource = _MyDs.Tables[0];
				DataGrid1.DataBind(); 
			}
			else
			{
				DataGrid1.Visible =false;
			}
			if (this.IDBL!="")
			 GridTitleServer1.NumeroRecords =string.Format("Apparecchiature legate all'edificio: {0}",  _MyDs.Tables[0].Rows.Count.ToString());
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
			this.cmbsServizio.SelectedIndexChanged += new System.EventHandler(this.cmbsServizio_SelectedIndexChanged);
			this.cmbsApparecchiatura.SelectedIndexChanged += new System.EventHandler(this.cmbsApparecchiatura_SelectedIndexChanged);
			this.btRicerca.Click += new System.EventHandler(this.btRicerca_Click);
			this.brreset.Click += new System.EventHandler(this.brreset_Click);
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

		private void DeleteItem(string id)
		{
			Console.WriteLine(id); 
			if (id=="") return;
			
			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id = new S_Object();
			s_p_id.ParameterName = "p_id";
			s_p_id.DbType = CustomDBType.Integer ;
			s_p_id.Direction = ParameterDirection.Input;
			s_p_id.Index =0;
			s_p_id.Value = int.Parse(id);
			_SColl.Add(s_p_id);
			try
			{
				TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura  _DatiApparecchiatura = new TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura(Context.User.Identity.Name);
				DataSet Ds=_DatiApparecchiatura.GetApparecchiatura(int.Parse(id));
                if (Ds.Tables[0].Rows.Count>0)
                   deleteFile(Ds.Tables[0].Rows[0]);

				_DatiApparecchiatura.Delete(_SColl, 0);
				DataGrid1.CurrentPageIndex=0;
				execute();
			}
			catch(Exception ex)
			{
			   Console.WriteLine(ex.Message);  
			   this.Page.RegisterStartupScript("messaggio","<script language'javascript'>alert(\"Impossibile cancellare l'apparecchiatura perchè è utilizzata in altre tabelle\");</script>"); 
			}
		}
		//Elimina anche il File;
		private void deleteFile(DataRow Dr)
		{
			try
			{
			
			string destDir =Server.MapPath("../EQImages");
			string folderParent=System.IO.Path.Combine(destDir, Dr["image_eq_assy"].ToString());
			if (File.Exists(folderParent)==true)  
				File.Delete(folderParent); 
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);  
				this.Page.RegisterStartupScript("messaggio","<script language'javascript'>alert(\"Impossibile cancellare il file immagine probabilmente in uso.\");</script>"); 
			}
		}
		private void DataGrid1_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType== ListItemType.Item) || (e.Item.ItemType==ListItemType.AlternatingItem) ||
				(e.Item.ItemType==ListItemType.EditItem))
			{
				TableCell myTableCell;
				myTableCell = e.Item.Cells[1];
				ImageButton myDeleteButton=(ImageButton)myTableCell.Controls[1];
				myDeleteButton.Attributes.Add("onclick","return confirm(\"Sei sicuro di Cancellare l'apparecchiatura?\");");
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
		/// <summary>
		/// Popola i servizzi legati all'edificio
		/// </summary>
		/// <param name="CodEdificio"></param>
		private void BindServizio(string CodEdificio)
		{
			cmbsServizio.Enabled =true;
			cmbsApparecchiatura.Enabled=true;
			CodiceApparecchiature1.Visible=true;
			this.cmbsServizio.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura  _DatiApparecchiatura = new TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura(Context.User.Identity.Name);

			DataSet	_MyDs = _DatiApparecchiatura.GetAllServiziEdifici(int.Parse(CodEdificio));

//			Classi.ClassiDettaglio.Servizi  _Servizi= new TheSite.Classi.ClassiDettaglio.Servizi();
//			DataSet _MyDs;							
//			int servizio_id=0;
//			_MyDs = _Servizi.GetServiziEdifici(int.Parse(CodEdificio),servizio_id);


			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare un Servizio -", "");
				this.cmbsServizio.DataTextField = "DESCRIZIONE";
				this.cmbsServizio.DataValueField = "ID";
				this.cmbsServizio.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Servizio -";
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		
		}
		
		private void BindPiano(string CodEdificio)
		{	
			//this.cmbsStanza.Enabled=false;

			this.cmbsPiano.Items.Clear();
		
			if (CodEdificio=="")
				CodEdificio="0";
			Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
			
			DataSet	_MyDs = _Buildings.GetPianiBuilding(int.Parse(CodEdificio));

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsPiano.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "-1");
				this.cmbsPiano.DataTextField = "DESCRIZIONE";
				this.cmbsPiano.DataValueField = "ID";
				this.cmbsPiano.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Piano -";
				this.cmbsPiano.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
			}
			this.cmbsPiano.Enabled=true;
			
		//	this.cmbsStanza.Enabled=true;
			
		}

//		private void BindStanza()
//		{
//		  
//			this.cmbsStanza.Items.Clear();
//		
//			TheSite.Classi.ManOrdinaria.Richiesta  _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
//			int bl_id=(RicercaModulo1.Idbl=="")?0:int.Parse(RicercaModulo1.Idbl);
//			int Piano=(cmbsPiano.SelectedValue=="")?0:int.Parse(cmbsPiano.SelectedValue); 
//			DataSet	_MyDs = _Richiesta.GetStanze(bl_id,Piano);
//
//			if (_MyDs.Tables[0].Rows.Count > 0)
//			{
//				this.cmbsStanza.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
//					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare la Stanza -", "-1");
//				this.cmbsStanza.DataTextField = "DESCRIZIONE";
//				this.cmbsStanza.DataValueField = "ID";
//				this.cmbsStanza.DataBind();
//			}
//			else
//			{
//				string s_Messagggio = "- Nessuna Stanza -";
//				this.cmbsStanza.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
//			}
//			//this.cmbsStanza.Enabled=true;
//			
//		}

		private void btRicerca_Click(object sender, System.EventArgs e)
		{
			if (this.IDBL=="")
			{
				DataGrid1.CurrentPageIndex=0;
				DataGrid1.Visible =false;
				GridTitleServer1.hplsNuovo.Visible =true;  
				GridTitleServer1.NumeroRecords="";
				return;
			}
			DataGrid1.CurrentPageIndex=0;
			DataGrid1.Visible =false;
			GridTitleServer1.hplsNuovo.Visible =true;  
			execute();
		}

		private void brreset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ListaApparecchiature.aspx?FunId="+FunId);
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
				
				if(e.Item.Cells[7].Text.Trim().ToUpper()=="DISMESSA")
				{
					e.Item.ForeColor=System.Drawing.Color.Tomato;			
					e.Item.ToolTip="Apparecchiatura Dismessa";
				}
			}
		}

		
		private void cmbsServizio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		  this.BindApparecchiatura(this.RicercaModulo1.BlId);
		}

		private void BindApparecchiatura(string CodEdificio)
		{
			
			this.cmbsApparecchiatura.Items.Clear();		
			Classi.AnagrafeImpianti.Apparecchiature  _Apparecchiature = new TheSite.Classi.AnagrafeImpianti.Apparecchiature(Context.User.Identity.Name);
			
			DataSet _MyDs;

			if (CodEdificio != string.Empty && cmbsServizio.SelectedValue != "0")
			{
				S_ControlsCollection _SColl = new S_ControlsCollection();

				S_Controls.Collections.S_Object s_BlId = new S_Object();
				s_BlId.ParameterName = "p_Bl_Id";
				s_BlId.DbType = CustomDBType.VarChar;
				s_BlId.Direction = ParameterDirection.Input;
				s_BlId.Size = 50;
				s_BlId.Index = 0;
				s_BlId.Value = RicercaModulo1.TxtCodice.Text;
				_SColl.Add(s_BlId);
			
				S_Controls.Collections.S_Object s_Servizio = new S_Object();
				s_Servizio.ParameterName = "p_Servizio";
				s_Servizio.DbType = CustomDBType.Integer;
				s_Servizio.Direction = ParameterDirection.Input;
				s_Servizio.Index = 1;
				string[]codice =  cmbsServizio.SelectedValue.Split(Convert.ToChar(" "));
                
				s_Servizio.Value = (cmbsServizio.SelectedValue == "")? 0:Int32.Parse(codice[0]);
				_SColl.Add(s_Servizio);

				_MyDs = _Apparecchiature.GetDataServizi(_SColl).Copy(); 
			
  
				if (_MyDs.Tables[0].Rows.Count > 0)
				{
					this.cmbsApparecchiatura.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
						_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Standard -", "-1");
					this.cmbsApparecchiatura.DataTextField = "DESCRIZIONE";
					this.cmbsApparecchiatura.DataValueField = "ID";
					this.cmbsApparecchiatura.DataBind();
				}
				else
				{
					string s_Messagggio = "- Nessuno Standard -";
					this.cmbsApparecchiatura.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0"));
				}
				
				cmbsApparecchiatura.Enabled=true;
				CodiceApparecchiature1.Visible=true;
			}
			else
			{
				string s_Messagggio = "- Nessuno Standard -";
				this.cmbsApparecchiatura.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0"));

			}
		}

		private void cmbsApparecchiatura_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.CodiceApparecchiature1.CodiceApparecchiatura="";
		}

	
	}
}
