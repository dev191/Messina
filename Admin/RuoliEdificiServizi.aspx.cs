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
using Microsoft.Web.UI.WebControls;
//  set di migrazione
using TreeNodeCollection = Microsoft.Web.UI.WebControls.TreeNodeCollection;
using TreeNode = Microsoft.Web.UI.WebControls.TreeNode;

namespace TheSite.Admin
{
	/// <summary>
	/// Descrizione di riepilogo per RuoliEdificiServizi.
	/// </summary>
	public class RuoliEdificiServizi : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected S_Controls.S_TextBox txtsCodice;
		protected S_Controls.S_TextBox txtsCampus;
		protected S_Controls.S_ComboBox cmbsProvincia;
		protected S_Controls.S_ComboBox cmbsComune;
		protected S_Controls.S_ComboBox cmbsServizi;
		protected System.Web.UI.WebControls.Button BtnFiltra;
		protected S_Controls.S_ComboBox cmbsDitta;
		protected S_Controls.S_Button btnsSalva;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Panel PanelEdit;

		int itemId = 0;		

		protected Microsoft.Web.UI.WebControls.TreeView TreeCtrl;
		protected System.Web.UI.WebControls.Label LblEdifici;
		protected System.Web.UI.WebControls.Label LblRuolo;
		protected System.Web.UI.WebControls.RadioButtonList OptFiltro;
		protected System.Web.UI.WebControls.CheckBox ChkSelezionaLeft;		
		string descrizione = String.Empty;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if (Request.Params["ItemId"] != null) 
			{
				itemId = Int32.Parse(Request.Params["ItemId"]);				
			}
			if (Request.Params["descr"] != null) 
			{
				descrizione = Request.Params["descr"];				
			}

			if (!Page.IsPostBack )
			{	
				//InizializzaControlliClient();
				
				LblRuolo.Text=descrizione;
				//CaricaListaRight();
				BindProvince();	
				BindDitte();	
				BindServizi();
				//ImpostaCheck();
				if (cmbsProvincia.SelectedIndex >= 1)
					BindComuni();
			
				this.lblOperazione.Text = "Associazione Ruoli Edifici Servizi";
								
				//ImpostaProvinciaDefault("CT","- Selezionare un Comune -");
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
			}
		}

		#region FunzioniPrivate
		
		private void CaricaAlbero()
		{		
			this.txtsCampus.DBDefaultValue = "%";
			this.txtsCodice.DBDefaultValue = "%";
			
			this.cmbsProvincia.DBDefaultValue="0";
			this.cmbsComune.DBDefaultValue="0";
			this.cmbsServizi.DBDefaultValue="0";
			this.cmbsDitta.DBDefaultValue="0";
			
			this.txtsCampus.Text=this.txtsCampus.Text.Trim();
			this.txtsCodice.Text=this.txtsCodice.Text.Trim();

			S_ControlsCollection _SCollection = new S_ControlsCollection();		
			_SCollection.AddItems(this.PanelEdit.Controls);
									
			Classi.ClassiDettaglio.Edificio _Edificio = new TheSite.Classi.ClassiDettaglio.Edificio(Context.User.Identity.Name);
			DataSet _MyDs=null;
			
			if (OptFiltro.Items[0].Selected)
			{
				_MyDs = _Edificio.GetRuoliEdifici(_SCollection,itemId,"Tutti");
			}
			if (OptFiltro.Items[1].Selected)
			{
				_MyDs = _Edificio.GetRuoliEdifici(_SCollection,itemId,"Associati");
			}
			if (OptFiltro.Items[2].Selected)
			{
				_MyDs = _Edificio.GetRuoliEdifici(_SCollection,itemId,"NonAssociati");
			}


			if (_MyDs.Tables[0].Rows.Count > 0) 
			{
				TreeCtrl.Visible=true;
				ChkSelezionaLeft.Visible=true;
				PopolaTreeview(_MyDs);	
			}
			else
			{
				TreeCtrl.Visible=false;
				ChkSelezionaLeft.Visible=false;
			}
			string totrecord = _MyDs.Tables[0].Rows.Count.ToString();
			LblEdifici.Text=totrecord;
			ImpostaCheck();
		}
		private void BindServizi()
		{
			Classi.ClassiDettaglio.Servizi _Servizi = new TheSite.Classi.ClassiDettaglio.Servizi(HttpContext.Current.User.Identity.Name);
			
			DataSet _MyDs = _Servizi.GetData().Copy();									
				
			this.cmbsServizi.Items.Clear();
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsServizi.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "idservizio", "- Selezionare un Servizio -", "");
				this.cmbsServizi.DataTextField = "descrizione";
				this.cmbsServizi.DataValueField = "idservizio";
				this.cmbsServizi.DataBind();
			}
		}
		private void BindDitte()
		{
			Classi.ClassiAnagrafiche.Ditte _Ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
			
			DataSet _MyDs = _Ditte.GetData().Copy();									
				
			this.cmbsDitta.Items.Clear();
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsDitta.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "id", "- Selezionare una Ditta -", "");
				this.cmbsDitta.DataTextField = "descrizione";
				this.cmbsDitta.DataValueField = "id";
				this.cmbsDitta.DataBind();
			}			

		}	
		private void ImpostaProvinciaDefault(string provincia,string comune)
		{
			ListItem crItemp = cmbsProvincia.Items.FindByText(provincia);			
			cmbsProvincia.SelectedValue= crItemp.Value;			
			BindComuni();
			ListItem crItemc = cmbsComune.Items.FindByText(comune);			
			cmbsComune.SelectedValue=crItemc.Value;
		}
		private void BindProvince()
		{
			
			this.cmbsProvincia.Items.Clear();
		
			Classi.ProvinceComuni _ProvCom = new TheSite.Classi.ProvinceComuni();
				
			DataSet _MyDs = _ProvCom.GetData().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsProvincia.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione_breve", "provincia_id", "- Selezionare una Provincia -", "");
				this.cmbsProvincia.DataTextField = "descrizione_breve";
				this.cmbsProvincia.DataValueField = "provincia_id";
				this.cmbsProvincia.DataBind();
			}			
		}
		
		private void ImpostaCheck()
		{
			ChkSelezionaLeft.Checked=false;
			ChkSelezionaLeft.Text="Seleziona Tutti";
		}
		private void BindComuni()
		{
			
			this.cmbsComune.Items.Clear();
		
			Classi.ProvinceComuni _ProvCom = new TheSite.Classi.ProvinceComuni();
			
			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Provid = new S_Object();			
			s_Provid.ParameterName = "p_provincia_id";
			s_Provid.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer; 
			s_Provid.Direction = ParameterDirection.Input;			
			s_Provid.Index = 0;
			s_Provid.Value = cmbsProvincia.SelectedValue;
			
			_SColl.Add(s_Provid);
						
			DataSet _MyDs = _ProvCom.GetComune(_SColl).Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsComune.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "comune_id", "- Selezionare un Comune -", "");
				this.cmbsComune.DataTextField = "descrizione";
				this.cmbsComune.DataValueField = "comune_id";
				this.cmbsComune.DataBind();
			}	
		}

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
		}

		private void PopolaTreeview(DataSet Ds)
		{
			//imposto lo style alla treeview
			SetStyleTreeVieew();
			foreach (DataRow Dr in Ds.Tables[0].Rows)
			{
				TreeNode nox =new TreeNode();
				nox.Type = "edificio";
				nox.Expanded=true;				
				string descrizione = "";
				descrizione=Dr["DESCRIZIONE"].ToString();
				nox.Text = descrizione;				
				nox.Target = Dr["ID"].ToString();
				TreeCtrl.Nodes.Add(nox);			
				//Recupero i tutti i dati dell'edificio.
				DataRowCollection DrCollection=DatiEdificio(Int32.Parse(Dr["ID"].ToString()));
				//Ciclo per i servizi				
				TreeNodeCollection nodePadre=null;
				foreach (DataRow DrDettagli in DrCollection)
				{	
					nodePadre=AddNodesServizi(nox.Target,DrDettagli,NodeCollection());					
				}
				//Fine Ciclo Servizi per edifio
			}
			//Fine Ciclo Edifici

		}
		
		private TreeNodeCollection AddNodesServizi(string id_bl,DataRow Dr, TreeNodeCollection nodes)
		{	
			TreeNode n =new TreeNode();
			n.Type = "servizio";			
			n.Text = Dr["DESCRIZIONE"].ToString();
			n.Target=Dr["ID"].ToString(); // Uso la proprietà Target per memorizzare l'ID
			n.CheckBox=true;						
			//controllo se il servizio in esame è già associato al ruolo per quel BL
			Classi.ClassiDettaglio.Edificio _Edificio = new TheSite.Classi.ClassiDettaglio.Edificio(Context.User.Identity.Name);
			bool stato = _Edificio.ControllaRuoloBlServizi(itemId,Int32.Parse(id_bl),Int32.Parse(n.Target));
			n.Checked=stato;
			nodes.Add(n);
			return nodes;
		}

		private DataRowCollection DatiEdificio(Int32 bl_id)
		{
			int servizio_id=0;
			if (cmbsServizi.SelectedValue!="")
				servizio_id=Int32.Parse(cmbsServizi.SelectedValue);			
			
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			Classi.ClassiDettaglio.Servizi  _Servizi= new TheSite.Classi.ClassiDettaglio.Servizi();
			DataSet Ds;							
			Ds = _Servizi.GetServiziEdifici(bl_id,servizio_id);
			return Ds.Tables[0].Rows; 
		}
		
		private TreeNodeCollection NodeCollection()
		{
			return TreeCtrl.Nodes[TreeCtrl.Nodes.Count - 1].Nodes;
		}

		private void ControllaCheck(string Operazione)
		{
			foreach(TreeNode nodo in TreeCtrl.Nodes)
			{
				if (nodo.Nodes.Count>0)
				{
					switch(Operazione)
					{
						case "Seleziona":										
							ImpostaNodi(nodo,nodo.Nodes,true);
							break;
						case "Deseleziona":	
							ImpostaNodi(nodo,nodo.Nodes,false);
							break;
						case "Salva":
							Salva(nodo,nodo.Nodes);
							break;	
					}
				}
			}
		}

		private void ImpostaNodi(TreeNode nodopadre, TreeNodeCollection nodi,bool val)
		{
			//nodopadre = BL | nodofiglio=servizio
			foreach(TreeNode nodofiglio in nodi)
			{
				nodofiglio.Checked=val;
			}
		}

		private void Salva(TreeNode nodopadre, TreeNodeCollection nodi)
		{			
			int bl_id = Int32.Parse(nodopadre.Target);
			string bl_descrizione = nodopadre.Text;

			EliminaAssociazioni(bl_id);
			//nodopadre = BL | nodofiglio=servizio
			foreach(TreeNode nodofiglio in nodi)
			{
				if (nodofiglio.Checked==true)
				{
					
					int servizio_id =  Int32.Parse(nodofiglio.Target);
					string servizio_descrizione=nodofiglio.Text;

					Classi.ClassiDettaglio.Edificio _Edificio = new TheSite.Classi.ClassiDettaglio.Edificio(Context.User.Identity.Name);
				
					S_Controls.Collections.S_ControlsCollection _SColl = new S_Controls.Collections.S_ControlsCollection();

					S_Controls.Collections.S_Object s_Ruolo = new S_Controls.Collections.S_Object();
					s_Ruolo.ParameterName = "p_Ruolo_Id";
					s_Ruolo.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
					s_Ruolo.Direction = ParameterDirection.Input;
					s_Ruolo.Index = 0;
					s_Ruolo.Value = itemId;

					S_Controls.Collections.S_Object s_Edificio_Id = new S_Controls.Collections.S_Object();
					s_Edificio_Id.ParameterName = "p_Edificio_Id";
					s_Edificio_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
					s_Edificio_Id.Direction = ParameterDirection.Input;
					s_Edificio_Id.Index = 1;
					s_Edificio_Id.Value = bl_id;		
				
					S_Controls.Collections.S_Object s_Servizio_Id = new S_Controls.Collections.S_Object();
					s_Servizio_Id.ParameterName = "p_Servizio_Id";
					s_Servizio_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
					s_Servizio_Id.Direction = ParameterDirection.Input;
					s_Servizio_Id.Index = 2;
					s_Servizio_Id.Value = servizio_id;		

					S_Controls.Collections.S_Object s_Operazione = new S_Object();
					s_Operazione.ParameterName = "p_Operazione";
					s_Operazione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
					s_Operazione.Direction = ParameterDirection.Input;
					s_Operazione.Index=3;				
					s_Operazione.Value = "Insert";					
				
					S_Controls.Collections.S_Object s_IdOut = new S_Object();
					s_IdOut.ParameterName = "p_IdOut";
					s_IdOut.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
					s_IdOut.Direction = ParameterDirection.Output;
					s_IdOut.Index = 4;

					_SColl.Add(s_Ruolo);
					_SColl.Add(s_Edificio_Id);
					_SColl.Add(s_Servizio_Id);
					_SColl.Add(s_Operazione);
					_SColl.Add(s_IdOut);				
										
					_Edificio.UpdateRuoliEdificiServizi(_SColl);
					

				}
			}
		}
		private void EliminaAssociazioni(int bl_id)
		{
			Classi.ClassiDettaglio.Edificio _Edificio = new TheSite.Classi.ClassiDettaglio.Edificio(Context.User.Identity.Name);
				
			S_Controls.Collections.S_ControlsCollection _SColl = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object s_Ruolo = new S_Controls.Collections.S_Object();
			s_Ruolo.ParameterName = "p_Ruolo_Id";
			s_Ruolo.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_Ruolo.Direction = ParameterDirection.Input;
			s_Ruolo.Index = 0;
			s_Ruolo.Value = itemId;

			S_Controls.Collections.S_Object s_Edificio_Id = new S_Controls.Collections.S_Object();
			s_Edificio_Id.ParameterName = "p_Edificio_Id";
			s_Edificio_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_Edificio_Id.Direction = ParameterDirection.Input;
			s_Edificio_Id.Index = 1;
			s_Edificio_Id.Value = bl_id;		
				
			S_Controls.Collections.S_Object s_Servizio_Id = new S_Controls.Collections.S_Object();
			s_Servizio_Id.ParameterName = "p_Servizio_Id";
			s_Servizio_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_Servizio_Id.Direction = ParameterDirection.Input;
			s_Servizio_Id.Index = 2;
			s_Servizio_Id.Value = 0;		

			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_Operazione";
			s_Operazione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_Operazione.Direction = ParameterDirection.Input;
			s_Operazione.Index=3;				
			s_Operazione.Value = "Delete";					
				
			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = 4;

			_SColl.Add(s_Ruolo);
			_SColl.Add(s_Edificio_Id);
			_SColl.Add(s_Servizio_Id);
			_SColl.Add(s_Operazione);
			_SColl.Add(s_IdOut);				
										
			_Edificio.UpdateRuoliEdificiServizi(_SColl);
		}
		
		#endregion

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
			this.ChkSelezionaLeft.CheckedChanged += new System.EventHandler(this.ChkSelezionaLeft_CheckedChanged);
			this.cmbsProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbsProvincia_SelectedIndexChanged);
			this.OptFiltro.SelectedIndexChanged += new System.EventHandler(this.OptFiltro_SelectedIndexChanged);
			this.BtnFiltra.Click += new System.EventHandler(this.BtnFiltra_Click);
			this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmbsProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbsProvincia.SelectedIndex>0)
				BindComuni();
			else
				this.cmbsComune.Items.Clear();
		}

		private void BtnFiltra_Click(object sender, System.EventArgs e)
		{
			CaricaAlbero();			
		}

		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			Response.Redirect((String) ViewState["UrlReferrer"]);			
		}

		private void ChkSelezionaLeft_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ChkSelezionaLeft.Checked==true)
			{
				ControllaCheck("Seleziona");
				ChkSelezionaLeft.Text="Deseleziona Tutti";
			}
			else
			{
				ControllaCheck("Deseleziona");
				ChkSelezionaLeft.Text="Seleziona Tutti";
			}
		}

		private void btnsSalva_Click(object sender, System.EventArgs e)
		{
			ControllaCheck("Salva");
		}

		private void OptFiltro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}
	}
}
