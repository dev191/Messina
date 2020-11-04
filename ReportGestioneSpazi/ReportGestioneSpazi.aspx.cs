using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using TheSite.AnalisiStatistiche;
using TheSite.Classi.AnalisiStatistiche;
using S_Controls.Collections;

namespace TheSite.ReportGestioneSpazi
{
	/// <summary>
	/// Descrizione di riepilogo per ReportGestioneSpazi.
	/// </summary>
	public class ReportGestioneSpazi : System.Web.UI.Page
	{
		protected S_Controls.S_Button S_BtnSubmit;
		protected System.Web.UI.WebControls.Button btnReportPdf;
		protected System.Web.UI.WebControls.Panel PanelPannelloRicerca;

		protected string VarDataInit,VarDataEnd,urlRpt;
		protected S_Controls.S_OptionButton S_Reparti;
		protected S_Controls.S_OptionButton S_Categorie;
		protected S_Controls.S_OptionButton S_Destinazione;
		protected S_Controls.S_OptionButton S_Misure;
		protected S_Controls.S_ComboBox cmbsPiano;
		protected S_Controls.S_ComboBox cmbsCategoria;
		protected S_Controls.S_TextBox s_txtDestinazione;
		protected S_Controls.S_TextBox s_txtReparto;
		protected S_Controls.S_ComboBox cmbsConfronto;
		protected S_Controls.S_TextBox s_txtMq;
		protected S_Controls.S_ListBox S_ListEdifici;
		protected System.Web.UI.HtmlControls.HtmlInputHidden edifici;
		protected System.Web.UI.HtmlControls.HtmlInputHidden edificidescription;
		protected Csy.WebControls.DataPanel DataPanel1;
		protected int status; 
		private enum ValidateDate {notPostBack,PostBack};

		protected WebControls.RicercaModulo RicercaModulo1;
		protected WebControls.UserStanze UserStanze1;
		protected Microsoft.Web.UI.WebControls.TreeView TreeCtrl;
		protected WebControls.PageTitle PageTitle1;
		public static int FunId = 0;
		public static string HelpLink = string.Empty;
		public string descUso1="";
		public string descRep="";
		public string Usoid1=String.Empty;
		protected System.Web.UI.HtmlControls.HtmlInputButton Reset1;
		public string id=String.Empty;


		private void Page_Load(object sender, System.EventArgs e)
		{
			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			

			S_ListEdifici.Attributes.Add("title","Premere il tasto canc per eliminare un elemento dalla lista.");  
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			SetProperty();
			if (!IsPostBack)
			{
				S_ListEdifici.Items.Clear();
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"]; 

				
				//BindServizio("");
				BindTuttiPiani();
				BindTutteCategorie();

				//BindApparecchiatura();
				if (Request.QueryString["idcomune"]!=null)
					IdComune=int.Parse(Request.QueryString["idcomune"]);

				if (Request.QueryString["idfrazione"]!=null)
					IdFrazione=int.Parse(Request.QueryString["idfrazione"]);


				LoadComune();
								
			}
			
			RicercaModulo1.multisele="y&id_comune=" + IdComune.ToString() + "&id_frazione=" + IdFrazione.ToString();
			RicercaModulo1.visualizzadettagli=false;
			UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
			UserStanze1.NameComboPiano="cmbsPiano";
			descRep=s_txtReparto.ClientID;
			descUso1=s_txtDestinazione.ClientID;
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
			this.S_BtnSubmit.Click += new System.EventHandler(this.S_BtnSubmit_Click);
			this.btnReportPdf.Click += new System.EventHandler(this.btnReportPdf_Click);
			this.Reset1.ServerClick += new System.EventHandler(this.Reset1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ScriptReportPdf(string strQuery)
		{
			//string pagina="RapportoTecnicoInterventoPdf.aspx?WO_Id=" + wo_id.ToString();
			string s_TestataScript = "<script language=\"javascript\">\n";
			string funz="ApriPopUp(\""+ strQuery +"\")";
			string s_CodaScript = "</script>\n";
			string funzione=s_TestataScript + funz + s_CodaScript;
			this.Page.RegisterStartupScript("funz",funzione);
			
		}
		
		private void S_BtnSubmit_Click(object sender, System.EventArgs e)
		{
			LoadList();
			DisplayReport();
		}
		private string queryString()
		{
			GenetoreQryStr _obj_QueryStr = new GenetoreQryStr();
			string stringaEdifici="";
			bool first=true;
			foreach (ListItem ls in S_ListEdifici.Items)
			{ 
				if (first)
				{
					if(ls.Text!="")
					{
						stringaEdifici += "'"+(ls.Text.Replace("(","").Replace(")","")).Split(' ')[0]+"'";
						first=false;
					}
				} 
				else 
				{
					stringaEdifici += ","+"'"+(ls.Text.Replace("(","").Replace(")","")).Split(' ')[0]+"'";
				}
			}
			_obj_QueryStr.Add(stringaEdifici,"stringaEdifici");
			_obj_QueryStr.Add(s_txtReparto.Text,"stringaReparto");
			_obj_QueryStr.Add(s_txtDestinazione.Text,"stringaDestinazione");
			_obj_QueryStr.Add(cmbsCategoria.SelectedValue,"idCategoria");
			_obj_QueryStr.Add(cmbsCategoria.SelectedItem.Text,"stringaCategoria");
			_obj_QueryStr.Add(UserStanze1.DescStanza,"stringaStanza");
			_obj_QueryStr.Add(UserStanze1.IdStanza,"stanza");
			_obj_QueryStr.Add(cmbsPiano.SelectedValue,"piano");
			_obj_QueryStr.Add(cmbsPiano.SelectedItem.Text,"lblpiano");

			_obj_QueryStr.Add(cmbsConfronto.SelectedValue,"operatoreMq");
			_obj_QueryStr.Add(s_txtMq.Text,"ValoreMq");

			_obj_QueryStr.Add(S_Categorie.Checked,"S_Categorie");
			_obj_QueryStr.Add(S_Destinazione.Checked,"S_Destinazione");
			_obj_QueryStr.Add(S_Reparti.Checked,"S_Reparti");
			_obj_QueryStr.Add(S_Misure.Checked,"S_Misure");
			return _obj_QueryStr.TotQueryString().ToString();
		}

		private void DisplayReport()
		{				
			urlRpt = "DisplayReportSpazi.aspx" + queryString() + "tipoDocumento=HTML";	
			Server.Transfer(urlRpt);
		}

		private void btnReportPdf_Click(object sender, System.EventArgs e)
		{
			LoadList();
			string qryStr = queryString();
			ScriptReportPdf( "DisplayReportSpazi.aspx" + qryStr + "tipoDocumento=PDF");
		}

		public int IdComune
		{
			get
			{
				if(ViewState["IdComune"]!=null)
					return (int)ViewState["IdComune"];
				else
					return 0;
			}
			set
			{ViewState.Add("IdComune",value);}
		}

		public int IdFrazione
		{
			get
			{
				if(ViewState["IdFrazione"]!=null)
					return (int)ViewState["IdFrazione"];
				else
					return 0;
			}
			set
			{ViewState.Add("IdFrazione",value);}
		}
		
		private void LoadComune()
		{
			//			if (IdComune==0) return;
			//			Classi.AnagrafeImpianti.ServiziEdifici _ServiziEdifici= new Classi.AnagrafeImpianti.ServiziEdifici(Context.User.Identity.Name);
			//			DataSet Ds= _ServiziEdifici.GetComuneFrazione(this.IdComune,this.IdFrazione);
			//			if (Ds.Tables[0].Rows.Count >0)
			//			{
			//				lblComuneDescrizione.Visible =true;
			//				lblComune.Visible =true;
			//				lblComune.Text=Ds.Tables[0].Rows[0]["descrizionec"].ToString();
			//				if(Ds.Tables[0].Rows[0]["descrizionef"]!=DBNull.Value && this.IdFrazione>0)
			//				{
			//					lblFrazioneDescrizione.Visible =true;
			//					lblFrazione.Visible =true;
			//					lblFrazione.Text=Ds.Tables[0].Rows[0]["descrizionef"].ToString();
			//				}
			//			}
			//			else
			//			{
			//				lblComuneDescrizione.Visible =false;
			//				lblComune.Visible =false;
			//				lblComune.Text="";
			//
			//				lblFrazioneDescrizione.Visible =false;
			//				lblFrazione.Visible =false;
			//				lblFrazione.Text ="";
			//			}
 
		}
		private void SetProperty()
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];

			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = "Report e Grafici delle Superfici";
				

			S_ListEdifici.Attributes.Add("onkeydown","deleteitem(this,event);"); 
			S_ListEdifici.Attributes.Add("onDblClick","deleteitem2(this,event);"); 
		

			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();

			sbValid.Append("if (typeof(errorlist) == 'function') { ");

			sbValid.Append("if (errorlist('" + S_ListEdifici.ClientID  + "') == false) { return false; }} ");
			sbValid.Append("if (errorlist('" + S_ListEdifici.ClientID  + "') == false) { return false; } ");
			sbValid.Append("this.value = 'Attendere ...';");

			sbValid.Append("this.disabled = true;");

			//			sbValid.Append("document.getElementById('" + S_btMostra.ClientID + "').disabled = true;");
			//
			//			sbValid.Append(this.Page.GetPostBackEventReference(this.S_btMostra));
			//			sbValid.Append(";");
			//			this.S_btMostra.Attributes.Add("onclick", sbValid.ToString());

			
		}
	
		


		private void LoadList()
		{
			Console.WriteLine(edifici.Value);  
			string[] Ite =edificidescription.Value.Split(new char[] {'$'});
			string[] Itevalue =edifici.Value.Split(new char[] {','});
			S_ListEdifici.Items.Clear(); 
			Int32 j=0;
			foreach (string itestr in Itevalue)
			{
				
				S_ListEdifici.Items.Add(new ListItem(Ite[j],itestr )); 
				j+=1;
			}
		}
		private void BindingEdifici(string BlId)
		{
			BlId="'" + BlId.Replace(",","','") + "'";

			///Istanzio un nuovo oggetto Collection per aggiungere i parametri
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			///creo i parametri		
			
			S_Controls.Collections.S_Object s_bl_id = new S_Controls.Collections.S_Object();
			s_bl_id.ParameterName = "p_Bl_Id";
			s_bl_id.DbType =ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_bl_id.Direction = ParameterDirection.Input;
			s_bl_id.Size =4000;
			s_bl_id.Index = 0;
			s_bl_id.Value = BlId;
			_SCollection.Add(s_bl_id);
           

			S_Controls.Collections.S_Object s_p_Servizio = new S_Controls.Collections.S_Object();
			s_p_Servizio.ParameterName = "p_servizio_id";
			s_p_Servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Servizio.Direction = ParameterDirection.Input;
			s_p_Servizio.Index = 1;
			//s_p_Servizio.Value = (cmbsServizio.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsServizio.SelectedValue);
			///Aggiungo i parametri alla collection
			_SCollection.Add(s_p_Servizio);


			S_Controls.Collections.S_Object s_p_idapparecchiatura = new S_Controls.Collections.S_Object();
			s_p_idapparecchiatura.ParameterName = "p_idapparecchiatura";
			s_p_idapparecchiatura.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_idapparecchiatura.Direction = ParameterDirection.Input;
			s_p_idapparecchiatura.Index = 2;
			s_p_idapparecchiatura.Value ="" ;
			_SCollection.Add(s_p_idapparecchiatura);

			Classi.AnagrafeImpianti.ServiziEdifici _ServiziEdifici= new Classi.AnagrafeImpianti.ServiziEdifici(Context.User.Identity.Name);
  
			DataSet Ds=_ServiziEdifici.GetData(_SCollection);

		}

		

		private TreeNodeCollection AddNodesServizi(DataRow Dr, TreeNodeCollection nodes)
		{
			string descrizione=Dr["ID"].ToString() + "&servizio_id=" + Dr["servizi_id"].ToString();
			nodes.Add(Node(Dr["DESCRIZIONE"].ToString() ,"servizio" ,descrizione,true,true));
			return nodes;
		}

		private TreeNodeCollection AddTipoApparecchiatura(DataRow Dr, TreeNodeCollection nodes)
		{
			string descrizione=Dr["eq_std"].ToString() + " " + Dr["family_description"].ToString();
			nodes.Add(Node(descrizione,"apparecchaiture" ,"",false,false));
			return nodes;
		}

		private void AddApparecchiatura(DataRow Dr, TreeNodeCollection nodes)
		{
			string descrizione=Dr["eq_std"].ToString() + " " + Dr["EQ_ID"].ToString();
			nodes.Add(Node(descrizione,"apparecchiatura" ,Dr["EQ_ID"].ToString(),true,false));
		}

		/// <summary>
		/// Recupero i servizzi legati ad un edificio
		/// </summary>
		/// <returns></returns>
		private DataRowCollection DatiEdificio(Int32 bl_id)
		{
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.AnagrafeImpianti.ServiziEdifici  _ServiziEdifici = new Classi.AnagrafeImpianti.ServiziEdifici(Context.User.Identity.Name);

			DataSet Ds;				
			Ds = _ServiziEdifici.GetSingleData(bl_id);
			return Ds.Tables[0].Rows; 
		}

		/// <summary>
		/// Crea un Nodo per la Treeview
		/// </summary>
		/// <param name="text">Testo che si visualizza nella Treeview</param>
		/// <param name="type">Imposto il Tipo di nodo da creare(il tipo di nodo è definito nella funzione SetStyleTreeVieew)</param>
		/// <param name="values">uno o più parametri da passare in query string</param>
		/// <param name="setnav">Indica se true di impostare il Navige url del nodo</param>
		/// <param name="servizio">Indica se true che si tratta di un servizio false di una apparecchiatura</param>
		/// <returns></returns>
		/// 
		private TreeNode Node(string text, string type, string values,bool setnav,bool servizio)
		{
			TreeNode n =new TreeNode();
			n.Type = type;
			n.Text = text;
			string nav  =string.Empty;

			if(setnav==false)
			{
				n.NavigateUrl = "";
				n.Target = "";
			}
			else
			{
				if(servizio==true)
					nav  ="ServiceDettail.aspx?bl_id=" + values;
				else
					nav  ="SchedaApparecchiatura.aspx?eq_id=" + values;              
				n.NavigateUrl = nav;
				n.Target = "doctrevew";
			}
			return n;
		}//Node

		/// <summary>
		/// Restituisce la collection dei nodi
		/// </summary>
		/// <returns></returns>
		private TreeNodeCollection NodeCollection()
		{
			return TreeCtrl.Nodes[TreeCtrl.Nodes.Count - 1].Nodes;
		}

		/// <summary>
		/// Imposto lo style e le immagini che deve caricare la treeview
		/// </summary>
		private void SetStyleTreeVieew()
		{
			TreeCtrl.Nodes.Clear();

			TreeCtrl.Style.Add("SCROLLBAR-3DLIGHT-COLOR", "darkgray");
			TreeCtrl.Style.Add("SCROLLBAR-ARROW-COLOR", "darkgray");
			TreeCtrl.Style.Add("CROLLBAR-TRACK-COLOR", "lightslategray");
			TreeCtrl.Style.Add("SCROLLBAR-BASE-COLOR", "lightslategray");
			TreeCtrl.Style.Add("HEIGHT", "95%");

			String imgurl  = "../images/treeimages/";

			TreeNodeType type= new TreeNodeType();
			type.Type = "edifici";
			type.ImageUrl = imgurl + "gnome-fs-home.gif";
			type.ExpandedImageUrl = imgurl + "gnome-fs-home.gif";

			TreeCtrl.TreeNodeTypes.Add(type);

			type = new TreeNodeType();
			type.Type = "edificio";
			type.ImageUrl = imgurl + "gnome-fs-home.gif";
			type.ExpandedImageUrl = imgurl + "gnome-fs-home.gif";
			TreeCtrl.TreeNodeTypes.Add(type);

			type = new TreeNodeType();
			type.Type = "servizio";
			type.ImageUrl = imgurl + "gnome-mime-text-x-sh.gif";
			type.ExpandedImageUrl = imgurl + "gnome-mime-text-x-sh.gif";
			TreeCtrl.TreeNodeTypes.Add(type);

			type = new TreeNodeType();
			type.Type = "apparecchaiture";
			type.ImageUrl = imgurl + "gnome-desktop-config.gif";
			type.ExpandedImageUrl = imgurl + "gnome-desktop-config.gif";
			TreeCtrl.TreeNodeTypes.Add(type);

			type = new TreeNodeType();
			type.Type = "apparecchiatura";
			type.ImageUrl = imgurl + "gnome-desktop-config.gif";
			type.ExpandedImageUrl = imgurl + "gnome-desktop-config.gif";
			TreeCtrl.TreeNodeTypes.Add(type);

			

		}
		

		
		

		private void cmbsServizio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			LoadList();
			//BindApparecchiatura();
		}

		private void BindTuttiPiani()
		{
			this.cmbsPiano.Items.Clear();
		
			TheSite.Classi.ClassiAnagrafiche.Buildings  _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
			
			DataSet	_MyDs = _Buildings.GetAllPiani();

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsPiano.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "");
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
		
		private void BindTutteCategorie()
		{
			this.cmbsCategoria.Items.Clear();
		
			TheSite.Classi.ClassiAnagrafiche.Categorie  _Categorie = new TheSite.Classi.ClassiAnagrafiche.Categorie();
			
			DataSet	_MyDs = _Categorie.GetData();

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsCategoria.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "CATEGORIA", "ID", "- Selezionare la Categoria -", "");
				this.cmbsCategoria.DataTextField = "CATEGORIA";
				this.cmbsCategoria.DataValueField = "ID";
				this.cmbsCategoria.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Categoria -";
				this.cmbsCategoria.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		private void Reset1_ServerClick(object sender, System.EventArgs e)
		{
			Response.Redirect("ReportGestioneSpazi.aspx?FunId=" + ViewState["FunId"]);
		}
	}
}
