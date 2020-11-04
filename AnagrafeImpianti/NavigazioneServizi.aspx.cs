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
using Microsoft.Web.UI.WebControls;
using ApplicationDataLayer.DBType;

namespace TheSite.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per NavigazioneDocumenti.
	/// </summary>
	public class NavigazioneServizi : System.Web.UI.Page
	{
		protected S_Controls.S_ComboBox cmbsApparecchiatura;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected S_Controls.S_ListBox S_ListEdifici;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected S_Controls.S_Button S_btMostra;
		protected System.Web.UI.HtmlControls.HtmlInputHidden edifici;
		protected System.Web.UI.HtmlControls.HtmlInputHidden edificidescription;
		protected Csy.WebControls.DataPanel DataPanel1;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected WebControls.PageTitle PageTitle1;
		protected Microsoft.Web.UI.WebControls.TreeView TreeCtrl;
		protected System.Web.UI.HtmlControls.HtmlGenericControl doctrevew;

		protected System.Web.UI.WebControls.Panel Panel1;
		protected S_Controls.S_Label lblComuneDescrizione;
		protected S_Controls.S_Label lblComune;
		protected S_Controls.S_TextBox S_txtnomefile;
		protected S_Controls.S_TextBox S_txtdescrizione;
		protected S_Controls.S_ComboBox S_CbCategoria;
		protected S_Controls.S_ComboBox S_CmbTipologia;
		protected S_Controls.S_Button S_btRicerca;
		

		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected S_Controls.S_Button btReset;
		
		public static string HelpLink = string.Empty;
		protected S_Controls.S_Label lblFrazione;
		protected S_Controls.S_Label lblFrazioneDescrizione;
		protected S_Controls.S_ComboBox S_ComboBox1;
		public static int FunId = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
//			RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);

			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsApparecchiatura.ClientID + "').disabled = true;");
			this.cmbsServizio.Attributes.Add("onchange", sbValid.ToString());

			S_ListEdifici.Attributes.Add("title","Premere il tasto canc per eliminare un elemento dalla lista.");  
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			SetProperty();
			if (!IsPostBack)
			{
				if(Request.QueryString["FunId"]!=null)
                   ViewState["FunId"]=Request.QueryString["FunId"]; 

				
				Panel1.Visible=false;
				BindServizio("0");
				BindApparecchiatura();
				if (Request.QueryString["idcomune"]!=null)
					IdComune=int.Parse(Request.QueryString["idcomune"]);

				if (Request.QueryString["idfrazione"]!=null)
					IdFrazione=int.Parse(Request.QueryString["idfrazione"]);


				LoadComune();
								
			}
			
			RicercaModulo1.multisele="y&id_comune=" + IdComune.ToString() + "&id_frazione=" + IdFrazione.ToString();
			RicercaModulo1.visualizzadettagli=false;
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
			if (IdComune==0) return;
			Classi.AnagrafeImpianti.ServiziEdifici _ServiziEdifici= new Classi.AnagrafeImpianti.ServiziEdifici(Context.User.Identity.Name);
			DataSet Ds= _ServiziEdifici.GetComuneFrazione(this.IdComune,this.IdFrazione);
			if (Ds.Tables[0].Rows.Count >0)
			{
				lblComuneDescrizione.Visible =true;
				lblComune.Visible =true;
				lblComune.Text=Ds.Tables[0].Rows[0]["descrizionec"].ToString();
				if(Ds.Tables[0].Rows[0]["descrizionef"]!=DBNull.Value && this.IdFrazione>0)
				{
					lblFrazioneDescrizione.Visible =true;
					lblFrazione.Visible =true;
					lblFrazione.Text=Ds.Tables[0].Rows[0]["descrizionef"].ToString();
				}
			}
			else
			{
				lblComuneDescrizione.Visible =false;
				lblComune.Visible =false;
				lblComune.Text="";

				lblFrazioneDescrizione.Visible =false;
				lblFrazione.Visible =false;
                lblFrazione.Text ="";
			}
 
		}
		private void SetProperty()
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];

			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
				

			S_ListEdifici.Attributes.Add("onkeydown","deleteitem(this,event);"); 
		

			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();

			sbValid.Append("if (typeof(errorlist) == 'function') { ");

			sbValid.Append("if (errorlist('" + S_ListEdifici.ClientID  + "') == false) { return false; }} ");
			sbValid.Append("if (errorlist('" + S_ListEdifici.ClientID  + "') == false) { return false; } ");
			sbValid.Append("this.value = 'Attendere ...';");

			sbValid.Append("this.disabled = true;");

			sbValid.Append("document.getElementById('" + S_btMostra.ClientID + "').disabled = true;");

			sbValid.Append(this.Page.GetPostBackEventReference(this.S_btMostra));
			sbValid.Append(";");
			this.S_btMostra.Attributes.Add("onclick", sbValid.ToString());

			
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
			this.S_btMostra.Click += new System.EventHandler(this.S_btMostra_Click);
			this.btReset.Click += new System.EventHandler(this.btReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	

		private void S_btMostra_Click(object sender, System.EventArgs e)
		{
	        LoadList();
			BindingEdifici(edifici.Value);
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
			s_bl_id.DbType =CustomDBType.VarChar;
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
			s_p_Servizio.Value = (cmbsServizio.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsServizio.SelectedValue);
			///Aggiungo i parametri alla collection
			_SCollection.Add(s_p_Servizio);


			S_Controls.Collections.S_Object s_p_idapparecchiatura = new S_Controls.Collections.S_Object();
			s_p_idapparecchiatura.ParameterName = "p_idapparecchiatura";
			s_p_idapparecchiatura.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_idapparecchiatura.Direction = ParameterDirection.Input;
			s_p_idapparecchiatura.Index = 2;
			s_p_idapparecchiatura.Value = (cmbsApparecchiatura.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsApparecchiatura.SelectedValue);
			_SCollection.Add(s_p_idapparecchiatura);

			Classi.AnagrafeImpianti.ServiziEdifici _ServiziEdifici= new Classi.AnagrafeImpianti.ServiziEdifici(Context.User.Identity.Name);
  
			DataSet Ds=_ServiziEdifici.GetData(_SCollection);

			if (Ds.Tables[0].Rows.Count>0)
			{
				PopolaTreeview(Ds);
				Panel1.Visible=true;
			}
			else
			{
				Panel1.Visible=false;
			}

		}

		private void PopolaTreeview(DataSet Ds)
		{
			//imposto lo style alla treeview
			SetStyleTreeVieew();
			foreach (DataRow Dr in Ds.Tables[0].Rows)
			{
				TreeNode nox =new TreeNode();
				nox.Type = "edificio";
				nox.Text =string.Format("({0}) {1}", Dr["BL_ID"],Dr["DENOMINAZIONE"]);
				nox.NavigateUrl ="";
				nox.Target = "";
				TreeCtrl.Nodes.Add(nox);
			
				//Recupero i tutti i dati dell'edificio.
				DataRowCollection DrCollection=DatiEdificio(Int32.Parse(Dr["ID"].ToString()));
				//Ciclo per i servizzi
				string servizio=string.Empty;
				string apparecchiatura=string.Empty;
				TreeNodeCollection nodePadre=null;
			

				foreach (DataRow DrDettagli in DrCollection)
				{
					if (DrDettagli["servizi_id"].ToString()==cmbsServizio.SelectedValue || cmbsServizio.SelectedIndex==0)
					{
						if(servizio!=DrDettagli["descrizione"].ToString())
						{
							apparecchiatura="";
							nodePadre=null;						
							servizio=DrDettagli["descrizione"].ToString();						
							nodePadre=AddNodesServizi(DrDettagli,NodeCollection());							
						}
//						if (DrDettagli["eqstdid"].ToString()==cmbsApparecchiatura.SelectedValue || cmbsApparecchiatura.SelectedIndex==0)
//						{
//							if (DrDettagli["description"]!=System.DBNull.Value)
//							{
//								if(apparecchiatura!=DrDettagli["description"].ToString())
//								{
//									nodeFiglio=null;
//									apparecchiatura=DrDettagli["description"].ToString();
//									nodeFiglio=AddTipoApparecchiatura(DrDettagli,nodePadre[nodePadre.Count -1].Nodes);
//								}							
//							}
//							AddApparecchiatura(DrDettagli,nodeFiglio[nodeFiglio.Count -1].Nodes);
//						}
						
					}
				}//Fine Ciclo Servizi per edificio

			}//Fine Ciclo Edifici

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
		private void BindServizio(string CodEdificio)
		{
			int idprog = 0;
			if(Request.QueryString["VarApp"]!=null)
				idprog = Convert.ToInt32(Request.QueryString["VarApp"].ToString());
//			if (CodEdificio!="0" && CodEdificio!="" )
//			{
				this.cmbsServizio.Items.Clear();		
				S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

				Classi.ClassiDettaglio.Servizi  _Servizio = new TheSite.Classi.ClassiDettaglio.Servizi(Context.User.Identity.Name);

				DataSet _MyDs = _Servizio.GetServiziPerProg(idprog,0);
		

				if (_MyDs.Tables[0].Rows.Count > 0)
				{
					this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
						_MyDs.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "");
					this.cmbsServizio.DataTextField = "DESCRIZIONE";
					this.cmbsServizio.DataValueField = "IDSERVIZIO";
					this.cmbsServizio.DataBind();
				}
				else
				{
					string s_Messagggio = "- Nessun Servizio -";
					this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
				}
//			}
//			else
//			{
//				string s_Messagggio = "- Nessun Servizio -";
//				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
//			}
		}


		
		private void BindApparecchiatura()
		{
			if (cmbsServizio.SelectedValue!="")
			{
				this.cmbsApparecchiatura.Items.Clear();
		
				Classi.AnagrafeImpianti.Apparecchiature  _Apparecchiature = new TheSite.Classi.AnagrafeImpianti.Apparecchiature(Context.User.Identity.Name);
			
				DataSet _MyDs;

				if (!IsPostBack)
				{
					_MyDs = _Apparecchiature.GetData();
				}
				else
				{
					S_ControlsCollection _SColl = new S_ControlsCollection();

					S_Controls.Collections.S_Object s_BlId = new S_Object();
					s_BlId.ParameterName = "p_Bl_Id";
					s_BlId.DbType = CustomDBType.VarChar;
					s_BlId.Direction = ParameterDirection.Input;
					s_BlId.Size =50;
					s_BlId.Index = 0;
					s_BlId.Value = "";
					_SColl.Add(s_BlId);
			
					S_Controls.Collections.S_Object s_Servizio = new S_Object();
					s_Servizio.ParameterName = "p_Servizio";
					s_Servizio.DbType = CustomDBType.Integer;
					s_Servizio.Direction = ParameterDirection.Input;
					s_Servizio.Index = 1;
					s_Servizio.Value = (cmbsServizio.SelectedValue=="")? 0:Int32.Parse(cmbsServizio.SelectedValue);
					_SColl.Add(s_Servizio);

					_MyDs = _Apparecchiature.GetData(_SColl).Copy();
                 
				}
  
				if (_MyDs.Tables[0].Rows.Count > 0)
				{
					this.cmbsApparecchiatura.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
						_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Standard -", "");
					this.cmbsApparecchiatura.DataTextField = "DESCRIZIONE";
					this.cmbsApparecchiatura.DataValueField = "ID";
					this.cmbsApparecchiatura.DataBind();
				}
				else
				{
					string s_Messagggio = "- Nessuno Standard -";
					this.cmbsApparecchiatura.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
				}
			}
			else
			{
				string s_Messagggio = "- Nessuno Standard -";
				this.cmbsApparecchiatura.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		private void cmbsServizio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			LoadList();
			BindApparecchiatura();
		}

		private void btReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("NavigazioneServizi.aspx?FunId=" + ViewState["FunId"]);
		}

		
	}
}
