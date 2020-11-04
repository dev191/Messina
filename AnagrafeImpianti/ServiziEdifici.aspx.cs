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
	/// Descrizione di riepilogo per ServiziEdifici.
	/// </summary>
	public class ServiziEdifici : System.Web.UI.Page
	{
		protected Microsoft.Web.UI.WebControls.TreeView TreeCtrl;
		protected System.Web.UI.HtmlControls.HtmlGenericControl doc;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if (!IsPostBack)
			{
				if (Context.Items["edifici"]!=null) 
				{
					string Itevalue=(string)Context.Items["edifici"];
					BindingEdifici(Itevalue);
				}
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
           
			Classi.AnagrafeImpianti.ServiziEdifici _ServiziEdifici= new Classi.AnagrafeImpianti.ServiziEdifici(Context.User.Identity.Name);
  
			DataSet Ds=_ServiziEdifici.GetData(_SCollection);
			if (Ds.Tables[0].Rows.Count>0)PopolaTreeview(Ds);

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
				TreeNodeCollection nodeFiglio=null;

				foreach (DataRow DrDettagli in DrCollection)
				{
					if(servizio!=DrDettagli["descrizione"].ToString())
					{
						apparecchiatura="";
						nodePadre=null;
						nodeFiglio=null;
						servizio=DrDettagli["descrizione"].ToString();
						nodePadre=AddNodesServizi(DrDettagli,NodeCollection());
					}
					if (DrDettagli["family_description"]!=System.DBNull.Value)
					{
						if(apparecchiatura!=DrDettagli["family_description"].ToString())
						{
							nodeFiglio=null;
							apparecchiatura=DrDettagli["family_description"].ToString();
							nodeFiglio=AddTipoApparecchiatura(DrDettagli,nodePadre[nodePadre.Count -1].Nodes);
						}
						AddApparecchiatura(DrDettagli,nodeFiglio[nodeFiglio.Count -1].Nodes);
					}
				}//Fine Ciclo Servizi per edifio

			}//Fine Ciclo Edifici

		}

		private TreeNodeCollection AddNodesServizi(DataRow Dr, TreeNodeCollection nodes)
		{
		 nodes.Add(Node(Dr["DESCRIZIONE"].ToString(),"servizio" ,"",false));
		 return nodes;
		}

		private TreeNodeCollection AddTipoApparecchiatura(DataRow Dr, TreeNodeCollection nodes)
		{
			string descrizione=Dr["eq_std"].ToString() + " " + Dr["family_description"].ToString();
			nodes.Add(Node(descrizione,"apparecchaiture" ,"",false));
			return nodes;
		}

		private void AddApparecchiatura(DataRow Dr, TreeNodeCollection nodes)
		{
			string descrizione=Dr["eq_std"].ToString() + " " + Dr["EQ_ID"].ToString();
			nodes.Add(Node(descrizione,"apparecchiatura" ,Dr["EQ_ID"].ToString(),true));
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
        /// <param name="text"></param>
        /// <param name="type"></param>
        /// <param name="values"></param>
        /// <param name="setnav"></param>
        /// <returns></returns>
		private TreeNode Node(string text, string type, string values,bool setnav)
		{
			TreeNode n =new TreeNode();
			n.Type = type;
			n.Text = text;
			string nav  = "SchedaApparecchiatura.aspx?eq_id=" + values;
			if(setnav==false)
			{
				n.NavigateUrl = "";
				n.Target = "";
			}
			else
			{
				n.NavigateUrl = nav;
				n.Target = "doc";
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
		TreeCtrl.Style.Add("SCROLLBAR-3DLIGHT-COLOR", "darkgray");
		TreeCtrl.Style.Add("SCROLLBAR-ARROW-COLOR", "darkgray");
		TreeCtrl.Style.Add("CROLLBAR-TRACK-COLOR", "#666666");
		TreeCtrl.Style.Add("SCROLLBAR-BASE-COLOR", "#666666");
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
