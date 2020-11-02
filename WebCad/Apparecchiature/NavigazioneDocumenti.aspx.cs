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
using S_Controls.Collections;
using WebCad.Apparecchiature; 
using System.Reflection;

namespace WebCad.Apparecchiature
{
	/// <summary>
	/// Descrizione di riepilogo per NavigazioneDocumenti.
	/// </summary>
	public class NavigazioneDocumenti : System.Web.UI.Page
	{
		protected S_Controls.S_Button S_btRicerca;
		protected S_Controls.S_Button S_btReset;
		protected Csy.WebControls.DataPanel DataPanel1;
		protected S_Controls.S_ComboBox S_CmbTipologia;
		protected S_Controls.S_ComboBox S_CbCategoria;
		protected S_Controls.S_TextBox S_txtnomefile;
		protected S_Controls.S_TextBox S_txtdescrizione;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected WebControls.RicercaModulo  RicercaModulo1;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1; 
		public static int FunId = 0;
		protected S_Controls.S_ComboBox cmbsPiano;
		public static string HelpLink = string.Empty;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];

			//Da rimettereFunId = _SiteModule.ModuleId;
			//Da rimettere HelpLink = _SiteModule.HelpLink;
			//Da rimettere this.PageTitle1.Title = _SiteModule.ModuleTitle;
			// Inserire qui il codice utente necessario per inizializzare la pagina.

			RicercaModulo1.DelegateIDBLEdificio1 +=new  WebControls.DelegateIDBLEdificio(this.BindPiano);
			if(!IsPostBack)
			{
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];


				BindPiano(string.Empty);
				LoadTipo();
				LoadCategoria();
				GridTitle1.Visible=false;
			}
			//Creazione dei primi Parametri
			RicercaModulo1.TxtCodice.DBParameterName="p_bl_id";
			RicercaModulo1.TxtCodice.DBIndex =0;
			RicercaModulo1.TxtCodice.DBDataType=CustomDBType.VarChar;
			RicercaModulo1.TxtCodice.DBDirection= ParameterDirection.Input;
			RicercaModulo1.TxtCodice.DBSize=8;
			RicercaModulo1.TxtCodice.DBDefaultValue=""; 

			RicercaModulo1.TxtRicerca.DBParameterName="p_campus";
			RicercaModulo1.TxtRicerca.DBIndex =1;
			RicercaModulo1.TxtRicerca.DBDirection= ParameterDirection.Input;
			RicercaModulo1.TxtRicerca.DBDataType=CustomDBType.VarChar; 
			RicercaModulo1.TxtRicerca.DBSize=128; 
			RicercaModulo1.TxtRicerca.DBDefaultValue=""; 


			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();

			sbValid.Append("this.value = 'Attendere ...';");

			sbValid.Append("this.disabled = true;");

			sbValid.Append("document.getElementById('" + S_btRicerca.ClientID + "').disabled = true;");

			sbValid.Append(this.Page.GetPostBackEventReference(this.S_btRicerca));
			sbValid.Append(";");
			this.S_btRicerca.Attributes.Add("onclick", sbValid.ToString());

			//dal WebCad
			if (Request.QueryString["bl_id"]!=null)
			{
				BindPianoStr(Request.QueryString["bl_id"]);
				cmbsPiano.SelectedValue=Request.QueryString["fl_id"];
				RicercaModulo1.TxtCodice.Text=Request.QueryString["bl_id"];
				DataPanel1.Collapsed=true;
				S_btRicerca_Click(this, new EventArgs());
			}

		}
	
		
        /// <summary>
        /// Recupera le tipologie e carica la combo
        /// </summary>
		private void LoadTipo()
		{
			Classi.AnagrafeImpianti.AnagrafeServizi   _AnagrafeServizi = new Classi.AnagrafeImpianti.AnagrafeServizi(Context.User.Identity.Name);
		    DataSet _Ds=_AnagrafeServizi.GetTipologie();
			if (_Ds.Tables[0].Rows.Count > 0)
			{
				this.S_CmbTipologia.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_Ds.Tables[0], "valTipo", "documento_id", "- Selezionare una Tipologia -", "");
				this.S_CmbTipologia.DataTextField = "valTipo";
				this.S_CmbTipologia.DataValueField = "documento_id";
				this.S_CmbTipologia.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Tipologia -";
				this.S_CmbTipologia.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
 
		}
		/// <summary>
		/// Recupera le categorie e Carica a combo
		/// </summary>
		/// 
		private void BindPiano(string CodEdificio)
		{
			this.cmbsPiano.Items.Clear();
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			WebCad.Classi.ClassiAnagrafiche.Buildings _Buildings = new WebCad.Classi.ClassiAnagrafiche.Buildings();

			
			if (CodEdificio!= string.Empty)
			{
				DataSet	_MyDs = _Buildings.GetPianiBuilding(Convert.ToInt32(CodEdificio));
				if (_MyDs.Tables[0].Rows.Count > 0)
				{
					this.cmbsPiano.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
						_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "0");
					this.cmbsPiano.DataTextField = "DESCRIZIONE";
					this.cmbsPiano.DataValueField = "ID";
					this.cmbsPiano.DataBind();
				}
				else
				{
					string s_Messagggio = "- Nessun Piano -";
					this.cmbsPiano.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
				}
			}
			else
			{
				string s_Messagggio = "- Nessun Piano -";
				this.cmbsPiano.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
			//this.cmbsPiano.Enabled=true;
		}

		/// <summary>
		/// Recupera le categorie e Carica a combo
		/// </summary>
		/// 
		private void BindPianoStr(string CodEdificio)
		{
			this.cmbsPiano.Items.Clear();
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			Classi.ClassiAnagrafiche.Buildings _Buildings = new WebCad.Classi.ClassiAnagrafiche.Buildings();

			
			if (CodEdificio!= string.Empty)
			{
				DataSet	_MyDs = _Buildings.GetPianiBuilding(CodEdificio);
				if (_MyDs.Tables[0].Rows.Count > 0)
				{
					this.cmbsPiano.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
						_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "0");
					this.cmbsPiano.DataTextField = "DESCRIZIONE";
					this.cmbsPiano.DataValueField = "ID";
					this.cmbsPiano.DataBind();
				}
				else
				{
					string s_Messagggio = "- Nessun Piano -";
					this.cmbsPiano.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
				}
			}
			else
			{
				string s_Messagggio = "- Nessun Piano -";
				this.cmbsPiano.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
			//this.cmbsPiano.Enabled=true;
		}


		private void LoadCategoria()
		{
			Classi.AnagrafeImpianti.AnagrafeServizi   _AnagrafeServizi = new Classi.AnagrafeImpianti.AnagrafeServizi(Context.User.Identity.Name);
			DataSet _Ds=_AnagrafeServizi.GetCategorie();
			if (_Ds.Tables[0].Rows.Count > 0)
			{
				this.S_CbCategoria.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_Ds.Tables[0], "valTipo", "id_categoria", "- Selezionare una Categoria -", "");
				this.S_CbCategoria.DataTextField = "valTipo";
				this.S_CbCategoria.DataValueField = "id_categoria";
				this.S_CbCategoria.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Categoria -";
				this.S_CbCategoria.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
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
			this.cmbsPiano.SelectedIndexChanged += new System.EventHandler(this.cmbsPiano_SelectedIndexChanged);
			this.S_btRicerca.Click += new System.EventHandler(this.S_btRicerca_Click);
			this.S_btReset.Click += new System.EventHandler(this.S_btReset_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void S_btReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("NavigazioneDocumenti.aspx?FunId=" + ViewState["FunId"]);
		}

		private void S_btRicerca_Click(object sender, System.EventArgs e)
		{
		 DataGrid1.CurrentPageIndex = 0;
		 Execute();
		}
		/// <summary>
		/// Esegue la queri di ricerca
		/// </summary>
		private void Execute()
		{	
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			//*****************************************
			S_Controls.Collections.S_Object s_p_Bl_Id = new S_Controls.Collections.S_Object();
			s_p_Bl_Id.ParameterName = "p_Bl_Id";
			s_p_Bl_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Bl_Id.Direction = ParameterDirection.Input;
			s_p_Bl_Id.Size =8;
			s_p_Bl_Id.Index = 0;
			s_p_Bl_Id.Value = RicercaModulo1.TxtCodice.Text;
			_SCollection.Add(s_p_Bl_Id);

			S_Controls.Collections.S_Object s_p_campus = new S_Controls.Collections.S_Object();
			s_p_campus.ParameterName = "p_campus";
			s_p_campus.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_campus.Direction = ParameterDirection.Input;
			s_p_campus.Index = 1;
			s_p_campus.Size=50;
			s_p_campus.Value = RicercaModulo1.TxtRicerca.Text;
			_SCollection.Add(s_p_campus);
			
			S_Controls.Collections.S_Object s_p_piano_id  = new S_Controls.Collections.S_Object();
			s_p_piano_id.ParameterName = "p_piano_id";
			s_p_piano_id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_piano_id.Direction = ParameterDirection.Input;
			s_p_piano_id.Size =8;
			s_p_piano_id.Index = 2;
			s_p_piano_id.Value = (cmbsPiano.SelectedValue==string.Empty)? 0:Int32.Parse(cmbsPiano.SelectedValue);
			_SCollection.Add(s_p_piano_id);


			S_Controls.Collections.S_Object s_p_nomefile = new S_Controls.Collections.S_Object();
			s_p_nomefile.ParameterName = "p_nomefile";
			s_p_nomefile.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_nomefile.Direction = ParameterDirection.Input;
			s_p_nomefile.Index = 3;
			s_p_nomefile.Size = 50;
			s_p_nomefile.Value = S_txtnomefile.Text;
			_SCollection.Add(s_p_nomefile);

			S_Controls.Collections.S_Object s_p_desc_file = new S_Controls.Collections.S_Object();
			s_p_desc_file.ParameterName = "p_desc_file";
			s_p_desc_file.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_desc_file.Direction = ParameterDirection.Input;
			s_p_desc_file.Size = 255;
			s_p_desc_file.Index = 4;
			s_p_desc_file.Value = S_txtdescrizione.Text;
			_SCollection.Add(s_p_desc_file);

			S_Controls.Collections.S_Object s_p_categoria  = new S_Controls.Collections.S_Object();
			s_p_categoria.ParameterName = "p_categoria";
			s_p_categoria.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_categoria.Direction = ParameterDirection.Input;
			s_p_categoria.Size =8;
			s_p_categoria.Index = 5;
			s_p_categoria.Value = (S_CbCategoria.SelectedValue==string.Empty)? 0:Int32.Parse(S_CbCategoria.SelectedValue);
			_SCollection.Add(s_p_categoria);
			
			S_Controls.Collections.S_Object s_p_tipo  = new S_Controls.Collections.S_Object();
			s_p_tipo.ParameterName = "p_tipo";
			s_p_tipo.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_tipo.Direction = ParameterDirection.Input;
			s_p_tipo.Size =8;
			s_p_tipo.Index = 6;
			s_p_tipo.Value = (S_CmbTipologia.SelectedValue==string.Empty)? 0:Int32.Parse(S_CmbTipologia.SelectedValue);
			_SCollection.Add(s_p_tipo);		
			
			//********************************************


			Classi.AnagrafeImpianti.AnagrafeServizi  _AnagrafeServizi = new Classi.AnagrafeImpianti.AnagrafeServizi(Context.User.Identity.Name);

			DataSet _MyDs = _AnagrafeServizi.GetData(_SCollection);

            GridTitle1.Visible=true;  
			DataGrid1.DataSource =_MyDs;
			
			if (_MyDs.Tables[0].Rows.Count >0)
			{
				int Pagina = 0;
				if ((_MyDs.Tables[0].Rows.Count % DataGrid1.PageSize) >0)
				{
					Pagina ++;
				}
				if (DataGrid1.PageCount != Convert.ToInt16((_MyDs.Tables[0].Rows.Count / DataGrid1.PageSize) + Pagina))
				{					
					DataGrid1.CurrentPageIndex=0;
				}
			}
			else
			{
				
				DataGrid1.CurrentPageIndex=0;
				GridTitle1.DescriptionTitle="Nessun dato trovato.";
				setvisible(false);
			}

			DataGrid1.DataBind();
			setvisible(true);
			GridTitle1.DescriptionTitle="";
			GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();
		}

		private void setvisible(bool visible)
		{
			GridTitle1.VisibleRecord=visible;
			GridTitle1.hplsNuovo.Visible =false;
			DataGrid1.Visible =visible;
		}

		private void SetDefaultValueControl(Control Ctrls)
		{
//			foreach (Control Ctrl in Ctrls.Controls)
//			{
//				if (Ctrl.Controls.Count >0) SetDefaultValueControl(Ctrl);
//				if((Ctrl is S_Controls.S_CheckBox) || (Ctrl is S_Controls.S_ComboBox) 
//					|| (Ctrl is S_Controls.S_HyperLink) || (Ctrl is S_Controls.S_Label) || (Ctrl is S_Controls.S_ListBox) 
//					|| (Ctrl is S_Controls.S_OptionButton) || (Ctrl is S_Controls.S_TextBox)) 
//				{
//					Type MyType = Ctrl.GetType();
//					PropertyInfo Mypropertyinfo = MyType.GetProperty("DBDefaultValue");
//					Mypropertyinfo.SetValue(Ctrl, "", null);
//					Console.WriteLine(MyType.Name);  
//				}
//			}
			S_txtnomefile.DBDefaultValue ="";
			S_txtdescrizione.DBDefaultValue=""; 
			S_CbCategoria.DBDefaultValue=0;
			S_CmbTipologia.DBDefaultValue=0; 
		}

		public void imageButton_Click(Object sender , CommandEventArgs e)
		{
			Context.Items.Add("var_afm_dwgs_dwg_name",(string)e.CommandArgument);
			Server.Transfer("VisualDWF.aspx");
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			DataGrid1.CurrentPageIndex=e.NewPageIndex;
			Execute();
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton1");
				_img1.Attributes.Add("title","Visualizza Documento");		
								
			}
		}

		private void cmbsPiano_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}



	}
}
