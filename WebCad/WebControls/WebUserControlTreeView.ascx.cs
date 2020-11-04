namespace WebCad.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using S_Controls.Collections;
	using Microsoft.Web.UI.WebControls;
	using ApplicationDataLayer.DBType;
	using WebCad.WiewCad;
	using WebCad.Classi.ClassiAnagrafiche;
	//  set di migrazione
	using TreeNodeCollection = Microsoft.Web.UI.WebControls.TreeNodeCollection;
	using TreeNode = Microsoft.Web.UI.WebControls.TreeNode;

	/// <summary>
	///		Descrizione di riepilogo per WebUserControlTreeView.
	/// </summary>
	/// 
	public delegate void SelezioneDelegate(int idBl, int idFl);
	public class WebUserControlTreeView : System.Web.UI.UserControl
	{
		//public event SelezioneDelegate Selezione;
		private Edifici _edifici;
		protected Microsoft.Web.UI.WebControls.TreeView TreeCtrl;

		private void Page_Load(object sender, System.EventArgs e)
		{
			
		}

		public string GetClientId()
		{
			return TreeCtrl.ClientID;

		}

		public string getSelectedEdificio()
		{
			return TreeCtrl.Nodes[int.Parse(TreeCtrl.SelectedNodeIndex)].NodeData.Split(';')[0];
		}

		public string getSelectedPiano()
		{
			string val = TreeCtrl.Nodes[int.Parse(TreeCtrl.SelectedNodeIndex)].Nodes[int.Parse(TreeCtrl.SelectedNodeIndex)].NodeData;
			return val.Split(';')[1];
		}

		public void BindData(DataSet Ds)
		{
			int righe = Ds.Tables[0].Rows.Count;
			riempiAlber(Ds);
		}

		private void riempiAlber(DataSet Ds)
		{
			if (_edifici==null)
				_edifici = new Edifici();
			//imposto lo style alla treeview
			SetStyleTreeVieew();
			//DataRowCollection drcEdifici =ListaEdificiDistinct();
			DataRowCollection drcEdifici = Ds.Tables[0].Rows;
			int index=0;
			foreach (DataRow DrEdifizio in drcEdifici)
			{
				TreeNode nox =new TreeNode();
				nox.Type = "edifici";
				nox.Text =string.Format("({0}) {1}", DrEdifizio["ID_BL"],DrEdifizio["EDIFICIO"]);
				nox.NodeData=DrEdifizio["ID_BL"].ToString();
				nox.NavigateUrl ="";
				nox.Target = "";
				TreeCtrl.Nodes.Add(nox);
			
				//Recupero i tutti i dati dell'edificio.
				DataRowCollection drcPiani=DatiEdificio(Int32.Parse(DrEdifizio["ID_BL"].ToString()));
				//Ciclo per i piani

				foreach (DataRow DrPiano in drcPiani)
				{
					int subIndex=0;
					TreeNode subNox =new TreeNode();

					subNox.Type = "piano";
					subNox.ID=DrEdifizio["ID_BL"]+"_"+DrPiano["ID_PIANI"];
					subNox.NodeData=DrEdifizio["ID_BL"]+";"+DrPiano["ID_PIANI"];
					subNox.Text =string.Format("({0}) {1}", DrPiano["ID_PIANI"],DrPiano["DESCRIZIONE_PIANI"]);
					subNox.NavigateUrl ="vbscript:SetPianoStanza("+
						DrEdifizio["ID_BL"]+",\""+
						DrEdifizio["EDIFICIO"]+"\","+
						DrPiano["ID_PIANI"]+",\""+
						DrPiano["DESCRIZIONE_PIANI"]+"\",\""+
						subNox.ID +"\")";
					subNox.Target = "";
					TreeCtrl.Nodes[index].Nodes.Add(subNox);
					subIndex++;
				}//Fine Ciclo Servizi per piani
			index++;
			}//Fine Ciclo Edifici

		}

		/// <summary>
		/// Seleziona un nodo dell'albero
		/// </summary>
		/// <returns></returns>
		public void SelezionaNodo(string idBl, string idFl)
		{
			foreach(TreeNode trn in TreeCtrl.Nodes)
			{
				if (trn.NodeData==idBl)
				{
					trn.Expanded=true;
					foreach(TreeNode strn in trn.Nodes)
					{
						if(strn.NodeData.Split(';').Length==2)
							if (strn.NodeData.Split(';')[1]==idFl)
								strn.DefaultStyle.Add("background","#ff0000");
					}
				}
			}
		}

		/// <summary>
		/// Recupero i servizzi legati ad un edificio
		/// </summary>
		/// <returns></returns>
		private DataRowCollection ListaEdificiDistinct()
		{
			_edifici = new Edifici();
			return _edifici.GetData().Tables[0].Rows;
		}

		/// <summary>
		/// Recupero i servizzi legati ad un edificio
		/// </summary>
		/// <returns></returns>
		private DataRowCollection DatiEdificio(int bl_id)
		{
			return _edifici.GetSingleData(bl_id).Tables[0].Rows;
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

			String imgurl  = "images/treeimages/";

			TreeNodeType type= new TreeNodeType();
			type.Type = "edifici";
			type.ImageUrl = imgurl + "gnome-fs-home.gif";
			type.ExpandedImageUrl = imgurl + "gnome-fs-home.gif";
			TreeCtrl.TreeNodeTypes.Add(type);

			type = new TreeNodeType();
			type.Type = "piano";
			type.ImageUrl = imgurl + "gnome-mime-text-x-sh.gif";
			type.ExpandedImageUrl = imgurl + "gnome-mime-text-x-sh.gif";
			type.HoverStyle.Add("background","#ff0000");
			TreeCtrl.TreeNodeTypes.Add(type);

		}

		private void TreeCtrl_SelectedIndexChange(object senter, TreeViewSelectEventArgs e)
		{
			;
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
