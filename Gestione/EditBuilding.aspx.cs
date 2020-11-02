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
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using StampaRapportiPdf.Classi;

namespace TheSite.Gestione
{
	/// <summary>
	/// Summary description for EditBuilding.
	/// </summary>
	public class EditBuilding : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected S_Controls.S_TextBox S_TextBox1;
		protected S_Controls.S_TextBox S_TEXTBOX2;
		Buildings _fp;

		int itemId = 0;
		string TipoOper = "";
		public static int FunId = 0;
		public static int TabId = 0;
		private DataSet _DsListBox;
		private DataSet _DsListBoxD;
		protected System.Web.UI.WebControls.Panel PanelEditServizi;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvCAP;
		protected System.Web.UI.WebControls.DataGrid DataGridServizi;
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected Microsoft.Web.UI.WebControls.TabStrip TabStrip1;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvBL_ID;
		protected S_Controls.S_TextBox txtsBL_ID;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvName;
		protected S_Controls.S_TextBox txtsNome;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvIndirizzo;
		protected S_Controls.S_TextBox txtsIndirizzo;
		protected S_Controls.S_TextBox txtsIndirizzo2;
		protected System.Web.UI.WebControls.RangeValidator rvProvincia;
		protected S_Controls.S_ComboBox cmbsProvincia;
		protected System.Web.UI.WebControls.RangeValidator rvComune;
		protected S_Controls.S_ComboBox cmbsComune;
		protected System.Web.UI.WebControls.RegularExpressionValidator revZIP;
		protected S_Controls.S_TextBox TxtsCAP;
		protected System.Web.UI.WebControls.RangeValidator rvDitta;
		protected S_Controls.S_ComboBox cmbsDitta;
		protected S_Controls.S_TextBox txtsCommenti;
		protected System.Web.UI.WebControls.Panel PanelEditAnag;
		protected System.Web.UI.WebControls.TextBox txtsLeftMail;
		protected System.Web.UI.WebControls.Button btnAssociaE;
		protected System.Web.UI.WebControls.Button btnEliminaE;
		protected System.Web.UI.WebControls.ListBox ListboxRightE;
		protected System.Web.UI.WebControls.Panel PanelEditMail;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPiani;
		protected System.Web.UI.WebControls.Button btnAssociaP;
		protected System.Web.UI.WebControls.Button btnEliminaP;
		protected System.Web.UI.WebControls.Panel PanelEditPiani;
		protected S_Controls.S_Button btnsSalva;
		protected S_Controls.S_Button btnsElimina;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected System.Web.UI.WebControls.RegularExpressionValidator REVEmail;
		protected System.Web.UI.WebControls.DataGrid DataGridEsegui;
		protected System.Web.UI.WebControls.Label lblRecord;
		protected System.Web.UI.WebControls.LinkButton lkbNuovo;
		protected System.Web.UI.WebControls.Panel PanelEditStanze;
		protected S_Controls.S_ComboBox cmbsUso;
		protected System.Web.UI.WebControls.RangeValidator rvUso;
		protected System.Web.UI.WebControls.LinkButton nuovoPiano;
		protected System.Web.UI.WebControls.Label LabelPiano;
		protected System.Web.UI.WebControls.DataGrid DataGridPiani;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenPianiStanze;
		public string descRep="";
		public string descRep1="";
		public string id="";
		public string id1="";
		public string descUso="";
		public string descUso1="";
		public string Usoid="";
		public string Usoid1="";
		protected System.Web.UI.WebControls.Button ButtonRefreshMq;
		protected System.Web.UI.WebControls.ListBox ListBoxLeftP;
		protected System.Web.UI.WebControls.ListBox ListBoxRightP;		
		
		Classi.ClassiAnagrafiche.Stanze _RM = new TheSite.Classi.ClassiAnagrafiche.Stanze();

		public clMyCollection _Contenitore
		{ 
			get 
			{
				if(this.ViewState["mioContenitore"]!=null)
					return (clMyCollection)this.ViewState["mioContenitore"];
				else
					return new clMyCollection();
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			//aggiungo la funzione javascript per la navigazione tra i tab
			TabStrip1.Attributes.Add("onclick","Abilita(this.selectedIndex);");

			//txtsBL_ID.Attributes.Add("onkeypress","SoloNumeri();");
			txtsBL_ID.Attributes.Add("onpaste","return false;");
			
			TabId = TabStrip1.SelectedIndex;

			//ID delRecord
			if (Request["ItemId"] != null) 
			{
				itemId = Int32.Parse(Request["ItemId"].ToString());				
			}
			//codice funzione
			if (Request["FunId"] != null) 
			{
				FunId = Int32.Parse(Request["FunId"].ToString());	
			}
			//tipo operazione
			if (Request["TipoOper"] != null) 
			{
				TipoOper = Request["TipoOper"].ToString();	
			}

			if (!Page.IsPostBack)
			{
				//btnsSalva.Attributes.Add("onclick","javascript:SelezionaListBox();");
				this.DataGridEsegui.Columns[1].Visible = true;
				this.DataGridEsegui.Columns[2].Visible = false;
				this.DataGridEsegui.Columns[3].Visible = false;
				this.BindGrid();

				///DATA GRID DEI PIANI
				this.DataGridPiani.Columns[1].Visible = true;
				this.DataGridPiani.Columns[2].Visible = false;
				this.DataGridPiani.Columns[3].Visible = false;
				this.BindGridPiani();


				BindProvince();							
				ImpostaProvinciaDefault("BA","BARI");//Carica Anche i Comuni				
				BindUsi();
				BindDitte();
				if (itemId != 0) 
				{					
					Classi.ClassiAnagrafiche.Buildings  _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
				
					DataSet _MyDs = _Buildings.GetSingleData(itemId).Copy();

					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						if (_Dr["BL_ID"] != DBNull.Value)
							this.txtsBL_ID.Text = (string) _Dr["BL_ID"];

						if (_Dr["NAME"] != DBNull.Value)
							this.txtsNome.Text = (string) _Dr["NAME"];

						if (_Dr["INDIRIZZO1"] != DBNull.Value)
							this.txtsIndirizzo.Text = (string) _Dr["INDIRIZZO1"];

						if (_Dr["INDIRIZZO2"] != DBNull.Value)
							this.txtsIndirizzo2.Text = (string) _Dr["INDIRIZZO2"];

						if (_Dr["PROVINCIA_ID"] != DBNull.Value)
							this.cmbsProvincia.SelectedValue= _Dr["PROVINCIA_ID"].ToString();

						BindComuni();
						if (_Dr["COMUNE_ID"] != DBNull.Value)
							this.cmbsComune.SelectedValue= _Dr["COMUNE_ID"].ToString();

						if (_Dr["ZIP"] != DBNull.Value)
							this.TxtsCAP.Text = (string) _Dr["ZIP"];						

						if (_Dr["BL_USE_ID"] != DBNull.Value)
							this.cmbsUso.SelectedValue= _Dr["BL_USE_ID"].ToString();

						if (_Dr["DITTA_ID"] != DBNull.Value)
							this.cmbsDitta.SelectedValue= _Dr["DITTA_ID"].ToString();

						if (_Dr["COMMENTS"] != DBNull.Value)
							this.txtsCommenti.Text = (string) _Dr["COMMENTS"];
						
						ListboxRightE.Items.Clear();
						if (_Dr["OPTION2"] != DBNull.Value)
						{
							string[] arr_Mail = _Dr["OPTION2"].ToString().Split(";".ToCharArray());
							for (int i=0; i < arr_Mail.Length; i++)
							{
								if (arr_Mail[i] != "")
									ListboxRightE.Items.Add(arr_Mail[i]);
							}
						}

						lblFirstAndLast.Text=_Buildings.GetFirstAndLastUser(_Dr);
						this.txtsBL_ID.Enabled = false;
						this.lblOperazione.Text = "Modifica Edificio: " + this.txtsBL_ID.Text;
						this.lblFirstAndLast.Visible = true;
						this.btnsElimina.Visible = true;
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
						
					}
				}
				else
				{
					this.txtsBL_ID.Enabled = true;
					this.lblOperazione.Text = "Inserimento Edificio";
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;
				}

				AggiornaListBox();
				//if (Context.Items["TipoOper"].ToString() == "read")				
				if (TipoOper == "read")
				{
					AbilitaControlli(false);
					this.lblOperazione.Text = "Visualizzazione Edificio: " + this.txtsBL_ID.Text;
				}
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Buildings) 
				{
					_fp = (TheSite.Gestione.Buildings) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
				}	
//				if (ListBoxRightP.Items.Count>0)
					TabStrip1.Items[4].Enabled= true;
//				else
//					TabStrip1.Items[4].Enabled= false;	
				
			} 
			btnsSalva.Enabled=true;
			
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.cmbsProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbsProvincia_SelectedIndexChanged);
			this.DataGridServizi.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridServizi_ItemDataBound);
			this.btnAssociaE.Click += new System.EventHandler(this.btnAssociaE_Click);
			this.btnEliminaE.Click += new System.EventHandler(this.btnEliminaE_Click);
			this.nuovoPiano.Click += new System.EventHandler(this.nuovoPiano_Click);
			this.DataGridPiani.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridPiani_ItemCommand);
			this.DataGridPiani.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridPiani_CancelCommand);
			this.DataGridPiani.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridPiani_EditCommand);
			this.DataGridPiani.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridPiani_UpdateCommand_1);
			this.DataGridPiani.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridPiani_ItemDataBound);
			this.ButtonRefreshMq.Click += new System.EventHandler(this.ButtonRefreshMq_Click);
			this.lkbNuovo.Click += new System.EventHandler(this.lkbNuovo_Click);
			this.DataGridEsegui.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_ItemCommand);
			this.DataGridEsegui.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_CancelCommand);
			this.DataGridEsegui.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_EditCommand);
			this.DataGridEsegui.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_UpdateCommand_1);
			this.DataGridEsegui.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridEsegui_ItemDataBound);
			this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
			this.btnsElimina.Click += new System.EventHandler(this.btnsElimina_Click);
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region FunzioniInterne

		private void AggiornaListBox()
		{
			_DsListBox = new DataSet();
			_DsListBoxD = new DataSet();

			this.CreaTabelle();				

			//-- Carico la griglia per i SERVIZI
//			if (itemId > 0)
//			{				
				Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
				DataView o_Dv = new DataView(_Buildings.GetServiziBuilding(itemId).Tables[0]);				
				DataGridServizi.DataSource = o_Dv;
				DataGridServizi.DataBind();
				if (o_Dv.Count > 0)
				{

//					foreach (DataRowView o_Drv in o_Dv)
//					{
//						DataRow o_Dr = _DsListBox.Tables["ServiziBuilding"].NewRow();
//						o_Dr["Id"] = o_Drv["IDSERVIZIO"].ToString();
//						o_Dr["Servizio"] = o_Drv["DESCRIZIONE"].ToString();
//						//o_Dr["IdUtente"] = "1"; //TODO Non Serve
//						_DsListBox.Tables["ServiziBuilding"].Rows.Add(o_Dr);
//					}
//				}

			}
//			Session.Add("ServiziBuilding", _DsListBox.Tables["ServiziBuilding"]);
//			
//			this.ListBoxRight.DataSource = _DsListBox.Tables["ServiziBuilding"];
//			this.ListBoxRight.DataValueField = "Id";
//			this.ListBoxRight.DataTextField = "Servizio";
//			this.ListBoxRight.DataBind();
//			this.ListBoxRight.SelectedIndex = 0;
//
//			//Lista di Sinistra dalla tabella "SERVIZI"
//			Classi.ClassiDettaglio.Servizi _Servizi = new TheSite.Classi.ClassiDettaglio.Servizi(HttpContext.Current.User.Identity.Name); 	
//			DataView o_DvServizi = new DataView(_Servizi.GetData().Tables[0]);
//			if (o_DvServizi.Count > 0)
//			{
//				foreach (DataRowView o_DrvR in o_DvServizi)
//				{
//					if (ListBoxRight.Items.FindByValue(o_DrvR["IDSERVIZIO"].ToString()) == null)
//					{
//						DataRow o_DrR = _DsListBox.Tables["Servizi"].NewRow();
//						o_DrR["Id"] = o_DrvR["IDSERVIZIO"].ToString();
//						o_DrR["Servizio"] = o_DrvR["DESCRIZIONE"].ToString();
//						_DsListBox.Tables["Servizi"].Rows.Add(o_DrR);
//					}
//				}
//			}
//			
//			this.ListBoxLeft.DataSource = _DsListBox.Tables["Servizi"];
//			this.ListBoxLeft.DataValueField = "Id";
//			this.ListBoxLeft.DataTextField = "Servizio";
//			this.ListBoxLeft.DataBind();
//			this.ListBoxLeft.SelectedIndex = 0;

			//-- Carico la lista per i PIANI
			//Lista di destra dalla tabella di associazione tra BL e PIANI cioè "FL"
			if (itemId > 0)
			{				
				Classi.ClassiAnagrafiche.Buildings _DitteBuildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
				DataView o_DvP = new DataView(_DitteBuildings.GetPianiBuilding(itemId).Tables[0]);				
				if (o_DvP.Count > 0)
				{
					foreach (DataRowView o_DrvF in o_DvP)
					{
						DataRow o_DrF = _DsListBoxD.Tables["PianiBuildings"].NewRow();
						o_DrF["ID"] = o_DrvF["ID"].ToString();
						o_DrF["DESCRIZIONE"] = o_DrvF["DESCRIZIONE"].ToString();
						_DsListBoxD.Tables["PianiBuildings"].Rows.Add(o_DrF);
					}
				}
			}

			Session.Add("PianiBuildings", _DsListBoxD.Tables["PianiBuildings"]);
			
//			this.ListBoxRightP.DataSource = _DsListBoxD.Tables["PianiBuildings"];
//			this.ListBoxRightP.DataValueField = "ID";
//			this.ListBoxRightP.DataTextField = "DESCRIZIONE";
//			this.ListBoxRightP.DataBind();
//			this.ListBoxRightP.SelectedIndex = 0;

			//Lista di sinistra dalla tabella "PIANI"
			Classi.ClassiAnagrafiche.Buildings _Piani = new TheSite.Classi.ClassiAnagrafiche.Buildings();
			DataView o_DvPiani = new DataView(_Piani.GetAllPiani().Tables[0]);

//			if (o_DvPiani.Count > 0)
//			{
//				foreach (DataRowView o_DrvRFor in o_DvPiani)
//				{
//					if (ListBoxRightP.Items.FindByValue(o_DrvRFor["ID"].ToString()) == null)
//					{
//						DataRow o_DrRFor = _DsListBoxD.Tables["Piani"].NewRow();
//						o_DrRFor["ID"] = o_DrvRFor["ID"].ToString();
//						o_DrRFor["Descrizione"] = o_DrvRFor["Descrizione"].ToString();
//						_DsListBoxD.Tables["Piani"].Rows.Add(o_DrRFor);
//					}
//				}
//			}
			
//			this.ListBoxLeftP.DataSource = _DsListBoxD.Tables["Piani"];
//			this.ListBoxLeftP.DataValueField = "ID";
//			this.ListBoxLeftP.DataTextField = "Descrizione";
//			this.ListBoxLeftP.DataBind();
//			this.ListBoxLeftP.SelectedIndex = 0;
		}	

		private void CreaTabelle()
		{
//			// -- Servizi
//			DataTable o_DtServizi = new DataTable("Servizi");
//			
//			// ID
//			DataColumn o_DcIdServizio = new DataColumn("Id");
//			o_DcIdServizio.DataType = System.Type.GetType("System.Int32");
//			o_DcIdServizio.Unique = true;
//			o_DcIdServizio.AllowDBNull = false;
//			o_DtServizi.Columns.Add(o_DcIdServizio);
//
//			// Descrizione
//			DataColumn o_DcServizio = new DataColumn("Servizio");
//			o_DcServizio.DataType = System.Type.GetType("System.String");
//			o_DcServizio.Unique = false;
//			o_DcServizio.AllowDBNull = false;
//			o_DtServizi.Columns.Add(o_DcServizio);
//
//			// -- Servizi associati a Edifici(BL)
//			DataTable o_DtServiziBuilding = new DataTable("ServiziBuilding");
//			
//			// ID
//			DataColumn o_DcIdServizioAss = new DataColumn("Id");
//			o_DcIdServizioAss.DataType = System.Type.GetType("System.Int32");
//			o_DcIdServizioAss.Unique = true;
//			o_DcIdServizioAss.AllowDBNull = false;
//			o_DtServiziBuilding.Columns.Add(o_DcIdServizioAss);
//			
////			DataColumn o_DcIdUtente = new DataColumn("IdUtente");
////			o_DcIdUtente.DataType = System.Type.GetType("System.Int32");
////			o_DcIdUtente.Unique = false;
////			o_DcIdUtente.AllowDBNull = false;
////			o_DtServiziBuilding.Columns.Add(o_DcIdUtente);
//			
//			// Descrizione
//			DataColumn o_DcDescrServizio = new DataColumn("Servizio");
//			o_DcDescrServizio.DataType = System.Type.GetType("System.String");
//			o_DcDescrServizio.Unique = false;
//			o_DcDescrServizio.AllowDBNull = false;
//			o_DtServiziBuilding.Columns.Add(o_DcDescrServizio);
//			
//			// Operazione
//			DataColumn o_DcOperazione = new DataColumn("Operazione");
//			o_DcOperazione.DataType = System.Type.GetType("System.String");
//			o_DcOperazione.Unique = false;
//			o_DcOperazione.AllowDBNull = true;
//			o_DcOperazione.DefaultValue = "D";
//			o_DtServiziBuilding.Columns.Add(o_DcOperazione);
//			
//			//Metto le tables nel dataset
//			_DsListBox.Tables.Add(o_DtServizi);
//			_DsListBox.Tables.Add(o_DtServiziBuilding);

			// -- Ditte Master
			DataTable o_DtDitteMaster = new DataTable("DitteMaster");
			
			// ID
			DataColumn o_DcIdDittaMaster = new DataColumn("IdD");
			o_DcIdDittaMaster.DataType = System.Type.GetType("System.Int32");
			o_DcIdDittaMaster.Unique = true;
			o_DcIdDittaMaster.AllowDBNull = false;
			o_DtDitteMaster.Columns.Add(o_DcIdDittaMaster);

			// Descrizione 
			DataColumn o_DcDittaMaster = new DataColumn("DittaMaster");
			o_DcDittaMaster.DataType = System.Type.GetType("System.String");
			o_DcDittaMaster.Unique = false;
			o_DcDittaMaster.AllowDBNull = false;
			o_DtDitteMaster.Columns.Add(o_DcDittaMaster);
			
			// -- Ditte Associate a Edifici(BL)
			DataTable o_DtDittaBL = new DataTable("DitteBuildings");
			
			// ID
			DataColumn o_DcIdDittaBL = new DataColumn("IdD");
			o_DcIdDittaBL.DataType = System.Type.GetType("System.Int32");
			o_DcIdDittaBL.Unique = true;
			o_DcIdDittaBL.AllowDBNull = false;
			o_DtDittaBL.Columns.Add(o_DcIdDittaBL);

			// Descrizione
			DataColumn o_DcDittaBL = new DataColumn("DESCRIZIONE");
			o_DcDittaBL.DataType = System.Type.GetType("System.String");
			o_DcDittaBL.Unique = false;
			o_DcDittaBL.AllowDBNull = false;
			o_DtDittaBL.Columns.Add(o_DcDittaBL);

			// Operazione
			DataColumn o_DcOperazioneD = new DataColumn("Operazione");
			o_DcOperazioneD.DataType = System.Type.GetType("System.String");
			o_DcOperazioneD.Unique = false;
			o_DcOperazioneD.AllowDBNull = true;
			o_DcOperazioneD.DefaultValue = "D";
			o_DtDittaBL.Columns.Add(o_DcOperazioneD);
			//Metto le tables nel dataset
			_DsListBoxD.Tables.Add(o_DtDitteMaster);
			_DsListBoxD.Tables.Add(o_DtDittaBL);

			// -- PIANI
			DataTable o_DtPiani = new DataTable("Piani");

			// ID
			DataColumn o_DcIdPiano = new DataColumn("ID");
			o_DcIdPiano.DataType = System.Type.GetType("System.Int32");
			o_DcIdPiano.Unique = true;
			o_DcIdPiano.AllowDBNull = false;
			o_DtPiani.Columns.Add(o_DcIdPiano);

			// Descrizione
			DataColumn o_DcPiano = new DataColumn("Descrizione");
			o_DcPiano.DataType = System.Type.GetType("System.String");
			o_DcPiano.Unique = false;
			o_DcPiano.AllowDBNull = false;
			o_DtPiani.Columns.Add(o_DcPiano);

			// -- Piani Associati a Edifici(BL)
			DataTable o_DtPianoBL = new DataTable("PianiBuildings");
			
			// ID
			DataColumn o_DcIdPianoBL = new DataColumn("ID");
			o_DcIdPianoBL.DataType = System.Type.GetType("System.Int32");
			o_DcIdPianoBL.Unique = true;
			o_DcIdPianoBL.AllowDBNull = false;
			o_DtPianoBL.Columns.Add(o_DcIdPianoBL);

			// Descrizione
			DataColumn o_DcPianoBL = new DataColumn("DESCRIZIONE");
			o_DcPianoBL.DataType = System.Type.GetType("System.String");
			o_DcPianoBL.Unique = false;
			o_DcPianoBL.AllowDBNull = false;
			o_DtPianoBL.Columns.Add(o_DcPianoBL);

			//Metto le tables nel dataset
			_DsListBoxD.Tables.Add(o_DtPiani);
			_DsListBoxD.Tables.Add(o_DtPianoBL);
		}
		
		private void BindProvince()
		{
			
			this.cmbsProvincia.Items.Clear();
		
			Classi.ProvinceComuni _ProvCom = new TheSite.Classi.ProvinceComuni();
				
			DataSet _MyDs = _ProvCom.GetData().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				//this.cmbsProvincia.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
				//_MyDs.Tables[0], "descrizione_breve", "provincia_id", "- Selezionare una Provincia -", "0");
				this.cmbsProvincia.DataSource=_MyDs;
				this.cmbsProvincia.DataTextField = "descrizione_breve";
				this.cmbsProvincia.DataValueField = "provincia_id";
				this.cmbsProvincia.DataBind();
			}			
		}

		private void BindDitte()
		{
			
			this.cmbsDitta.Items.Clear();
		
			Classi.ClassiAnagrafiche.Ditte _DitteMaster = new TheSite.Classi.ClassiAnagrafiche.Ditte();
				
			DataSet _MyDs = _DitteMaster.GetDitteMaster().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsDitta.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "idD", "- Selezionare una Ditta -", "0");
				this.cmbsDitta.DataTextField = "descrizione";
				this.cmbsDitta.DataValueField = "idD";
				this.cmbsDitta.DataBind();
			}			
		}

		private void BindUsi()
		{
			
			this.cmbsUso.Items.Clear();
		
			Classi.ClassiAnagrafiche.Buildings _Usi = new TheSite.Classi.ClassiAnagrafiche.Buildings();
				
			DataSet _MyDs = _Usi.GetAllUsi().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsUso.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "BL_USE_ID", "- Selezionare un Uso -", "0");
				this.cmbsUso.DataTextField = "descrizione";
				this.cmbsUso.DataValueField = "BL_USE_ID";
				this.cmbsUso.DataBind();
			}			
		}
		

		private void AbilitaControlli(bool enabled)
		{
			this.txtsBL_ID.Enabled = enabled;
			this.txtsNome.Enabled = enabled;
			this.txtsIndirizzo.Enabled = enabled;
			this.txtsIndirizzo2.Enabled = enabled;
			this.cmbsProvincia.Enabled=enabled;
			this.cmbsComune.Enabled=enabled;
			this.cmbsUso.Enabled=enabled;
			this.cmbsDitta.Enabled=enabled;
			this.TxtsCAP.Enabled = enabled;
			this.txtsCommenti.Enabled = enabled;

			this.btnsElimina.Enabled=enabled;
			this.btnsSalva.Enabled=enabled;

			// Lista Servizi
			DataGridServizi.Enabled = enabled;

			// Lista E-Mail
			this.btnAssociaE.Enabled=enabled;
			this.btnEliminaE.Enabled=enabled;
			this.txtsLeftMail.Enabled=enabled;
			this.ListboxRightE.Enabled=enabled;

			// Lista Piani
			this.DataGridPiani.Enabled=enabled;
			this.ButtonRefreshMq.Enabled=enabled;
//			this.btnAssociaP.Enabled=enabled;
//			this.btnEliminaP.Enabled=enabled;
//			this.ListBoxLeftP.Enabled=enabled;
//			this.ListBoxRightP.Enabled=enabled;

			//Lista
			this.DataGridEsegui.Enabled=enabled;

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
				//this.cmbsComune.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
				//	_MyDs.Tables[0], "descrizione", "comune_id", "- Selezionare un Comune -", "0");				
				this.cmbsComune.DataSource=_MyDs;
				this.cmbsComune.DataTextField = "descrizione";
				this.cmbsComune.DataValueField = "comune_id";
				
				this.cmbsComune.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Comune  -";
				this.cmbsComune.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
						
			}			
		}

		
		
		#endregion
		private void ImpostaProvinciaDefault(string provincia,string comune)
		{
			ListItem crItemp = cmbsProvincia.Items.FindByText(provincia);			
			cmbsProvincia.SelectedValue= crItemp.Value;			
			BindComuni();
			ListItem crItemc = cmbsComune.Items.FindByText(comune);			
			cmbsComune.SelectedValue=crItemc.Value;			
		}

		private void cmbsProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindComuni();
		}

//		private void btnAssocia_Click(object sender, System.EventArgs e)
//		{
//			//ASSOCIA SERVIZI
//			string s_strSelection;
//			string s_strSelectionValue;
//			if (ListBoxLeft.SelectedItem != null)
//			{
//				s_strSelection = ListBoxLeft.SelectedItem.Text;
//				s_strSelectionValue = ListBoxLeft.SelectedItem.Value;
//				if (ListBoxRight.Items.FindByValue(s_strSelectionValue)== null )
//				{
//					ListItem o_Li = new ListItem(s_strSelection, s_strSelectionValue);
//					ListBoxRight.Items.Add(o_Li);
//					ListBoxRight.SelectedIndex = 0;
//					ListBoxLeft.Items.Remove(o_Li);
//				}
//			}
//		}
//
//		private void btnElimina_Click(object sender, System.EventArgs e)
//		{
//			//ELIMINA SERVIZI
//			string s_strSelection;
//			string s_strSelectionValue;
//			if (ListBoxRight.SelectedItem != null)
//			{
//				s_strSelection = ListBoxRight.SelectedItem.Text;
//				s_strSelectionValue = ListBoxRight.SelectedItem.Value;
//				if (ListBoxLeft.Items.FindByValue(s_strSelectionValue)== null )
//				{
//					ListItem o_Li = new ListItem(s_strSelection, s_strSelectionValue);
//					ListBoxLeft.Items.Add(o_Li);
//					ListBoxLeft.SelectedIndex = 0;
//					ListBoxRight.Items.Remove(o_Li);
//				}
//			}
//		}

		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			//Response.Redirect("Buildings.aspx?FunID="+ FunId +"&Ricarica=yes");
			Server.Transfer("Buildings.aspx");
		}

		private void btnsElimina_Click(object sender, System.EventArgs e)
		{
			try
			{	
				this.txtsBL_ID.DBDefaultValue = DBNull.Value;
				this.txtsNome.DBDefaultValue = DBNull.Value;
				this.txtsIndirizzo.DBDefaultValue = DBNull.Value;
				this.txtsIndirizzo2.DBDefaultValue = DBNull.Value;
				this.cmbsProvincia.DBDefaultValue = 0;
				this.cmbsComune.DBDefaultValue = 0;
				this.TxtsCAP.DBDefaultValue = DBNull.Value;
				this.cmbsUso.DBDefaultValue = 0;
				this.cmbsDitta.DBDefaultValue = 0;
				this.txtsCommenti.DBDefaultValue = DBNull.Value;
				
				int i_RowsAffected = 0;
				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
				_SCollection.AddItems(this.PanelEditAnag.Controls);			
				Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
				
//				//Aggiungo un parametro che contiene tutti i Servizi
//				S_Controls.Collections.S_Object s_ArrServizi = new S_Object();
//				s_ArrServizi.ParameterName = "p_Arr_Servizi";
//				s_ArrServizi.DbType = CustomDBType.VarChar;
//				s_ArrServizi.Direction = ParameterDirection.Input;
//				s_ArrServizi.Index = _SCollection.Count + 1;
//				s_ArrServizi.Value = DBNull.Value;
//				
//				_SCollection.Add(s_ArrServizi);

				//Aggiungo un parametro che contiene tutti i Piani
//				S_Controls.Collections.S_Object s_ArrPiani = new S_Object();
//				s_ArrPiani.ParameterName = "p_Arr_Piani";
//				s_ArrPiani.DbType = CustomDBType.VarChar;
//				s_ArrPiani.Direction = ParameterDirection.Input;
//				s_ArrPiani.Index = _SCollection.Count + 1;
//				s_ArrPiani.Value = DBNull.Value;
//				
//				_SCollection.Add(s_ArrPiani);

				//Aggiungo un parametro che contiene le e-mail
				S_Controls.Collections.S_Object s_Mail = new S_Object();
				s_Mail.ParameterName = "p_MAIL";
				s_Mail.DbType = CustomDBType.VarChar;
				s_Mail.Direction = ParameterDirection.Input;
				s_Mail.Index = _SCollection.Count + 1;
				s_Mail.Value = DBNull.Value;
				
				_SCollection.Add(s_Mail);


				i_RowsAffected = _Buildings.Delete(_SCollection, itemId);
				if ( i_RowsAffected == -1 )
					Server.Transfer("Buildings.aspx");	
			}
			catch (Exception ex)
			{			
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}
		}

		private void btnAssociaE_Click(object sender, System.EventArgs e)
		{
			//ASSOCIA E-MAIL
			string s_strSelectionValue;
			if (txtsLeftMail.Text.Trim() != "")
			{
				s_strSelectionValue = txtsLeftMail.Text.Trim();
				if (ListboxRightE.Items.FindByValue(s_strSelectionValue)== null )
				{
					ListItem o_Li = new ListItem(s_strSelectionValue);
					ListboxRightE.Items.Add(o_Li);
					ListboxRightE.SelectedIndex = 0;
					txtsLeftMail.Text = "";
				}
			}
		}

		private void btnEliminaE_Click(object sender, System.EventArgs e)
		{
			//ELIMINA E-MAIL
			string s_strSelection;
			string s_strSelectionValue;
			if (ListboxRightE.SelectedItem != null)
			{
				s_strSelection = ListboxRightE.SelectedItem.Text;
				s_strSelectionValue = ListboxRightE.SelectedItem.Value;
				ListItem o_Li = new ListItem(s_strSelection, s_strSelectionValue);
				ListboxRightE.Items.Remove(o_Li);

			}
		
		}

		private void btnAssociaP_Click(object sender, System.EventArgs e)
		{
//			//ASSOCIA PIANI
//			string s_strSelection;
//			string s_strSelectionValue;
//			if (ListBoxLeftP.SelectedItem != null)
//			{
//				s_strSelection = ListBoxLeftP.SelectedItem.Text;
//				s_strSelectionValue = ListBoxLeftP.SelectedItem.Value;
//				if (ListBoxRightP.Items.FindByValue(s_strSelectionValue)== null )
//				{
//					ListItem o_Li = new ListItem(s_strSelection, s_strSelectionValue);
//					ListBoxRightP.Items.Add(o_Li);
//					ListBoxRightP.SelectedIndex = 0;
//					ListBoxLeftP.Items.Remove(o_Li);
//				}
//			}
		}

		private void btnEliminaP_Click(object sender, System.EventArgs e)
		{
//			Classi.ClassiAnagrafiche.Buildings _Buildings = new Classi.ClassiAnagrafiche.Buildings();
//			int Result=_Buildings.PianiApparecchiatura(int.Parse(ListBoxRightP.SelectedItem.Value),itemId);
//			if (Result >0)
//			{
//				System.Text.StringBuilder strb= new System.Text.StringBuilder();
//				strb.Append("<script language=\"javascript\">");
//				strb.Append("Messaggio();");
//				strb.Append("</script>");
//				
//				Page.RegisterStartupScript("chi",strb.ToString());
//				return;
//			}
			
//			int ResultPS = _Buildings.PianiStanze(int.Parse(ListBoxRightP.SelectedItem.Value),itemId);
//			if (ResultPS >0)
//			{
//				System.Text.StringBuilder strb= new System.Text.StringBuilder();
//				strb.Append("<script language=\"javascript\">");
//				strb.Append("MessaggioPiani();");
//				strb.Append("</script>");
//				
//				Page.RegisterStartupScript("msg",strb.ToString());
//				return;
//			}			 
			
			//ELIMINA PIANI
//			string s_strSelection;
//			string s_strSelectionValue;
//			if (ListBoxRightP.SelectedItem != null)
//			{
//			s_strSelection = ListBoxRightP.SelectedItem.Text;
//			s_strSelectionValue = ListBoxRightP.SelectedItem.Value;
//				if (ListBoxLeftP.Items.FindByValue(s_strSelectionValue)== null )
//				{
//					ListItem o_Li = new ListItem(s_strSelection, s_strSelectionValue);
//					ListBoxLeftP.Items.Add(o_Li);
//					ListBoxLeftP.SelectedIndex = 0;
//					ListBoxRightP.Items.Remove(o_Li);
//				}
//			}
			
		}

		private void btnsSalva_Click(object sender, System.EventArgs e)
		{
			
			string msg = "";
			if (ControllaDate(ref msg))
			{
				//string strArrPiani = "";
				string strMail = "";

				Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();

				this.txtsBL_ID.DBDefaultValue = DBNull.Value;
				this.txtsNome.DBDefaultValue = DBNull.Value;
				this.txtsIndirizzo.DBDefaultValue = DBNull.Value;
				this.txtsIndirizzo2.DBDefaultValue = DBNull.Value;
				this.cmbsProvincia.DBDefaultValue=0;
				this.cmbsComune.DBDefaultValue=0;
				this.TxtsCAP.DBDefaultValue = DBNull.Value;
				this.cmbsUso.DBDefaultValue=0;
				this.cmbsDitta.DBDefaultValue=0;
				this.txtsCommenti.DBDefaultValue = DBNull.Value;

				this.txtsBL_ID.DBDefaultValue = this.txtsBL_ID.Text.Trim();
				this.txtsNome.DBDefaultValue = this.txtsNome.Text.Trim();
				this.txtsIndirizzo.DBDefaultValue = this.txtsIndirizzo.Text.Trim();
				this.txtsIndirizzo2.DBDefaultValue = this.txtsIndirizzo2.Text.Trim();
				this.TxtsCAP.DBDefaultValue = this.TxtsCAP.Text.Trim();
				this.txtsCommenti.DBDefaultValue = this.txtsCommenti.Text.Trim();

				int i_RowsAffected = 0;

				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

				_SCollection.AddItems(this.PanelEditAnag.Controls);
				
				//Aggiungo un parametro che contiene tutti i Piani
//				if (this.ListBoxRightP.Items.Count >= 0)
//				{
//					foreach(ListItem o_Litem in this.ListBoxRightP.Items)
//					{
//						strArrPiani = strArrPiani + o_Litem.Value.ToString() + ";";
//					}
//				}	
//				S_Controls.Collections.S_Object s_ArrPiani = new S_Object();
//				s_ArrPiani.ParameterName = "p_Arr_Piani";
//				s_ArrPiani.DbType = CustomDBType.VarChar;
//				s_ArrPiani.Direction = ParameterDirection.Input;
//				s_ArrPiani.Index = _SCollection.Count + 1;
//				s_ArrPiani.Value = DBNull.Value;
					
//				_SCollection.Add(s_ArrPiani);

				//Aggiungo un parametro che contiene le e-mail
				if (this.ListboxRightE.Items.Count >= 0)
				{
					foreach(ListItem o_Litem in this.ListboxRightE.Items)
					{
						strMail = strMail + o_Litem.Text.ToString() + ";";
					}
					if (strMail.Length != 0)
						strMail = strMail.Substring(0,strMail.Length-1);
				}	
				S_Controls.Collections.S_Object s_Mail = new S_Object();
				s_Mail.ParameterName = "p_MAIL";
				s_Mail.DbType = CustomDBType.VarChar;
				s_Mail.Direction = ParameterDirection.Input;
				s_Mail.Index = _SCollection.Count + 1;
				s_Mail.Size = 255;
				s_Mail.Value = strMail;
					
				_SCollection.Add(s_Mail);

				//inizio il salvataggio
				try
				{
					//inizio la transazione
					_Buildings.beginTransaction();

					//Salvo o modifico il palazzo
					if (itemId == 0)
					{
						i_RowsAffected = _Buildings.Add(_SCollection);
						itemId = i_RowsAffected;
					}
					else
						i_RowsAffected = _Buildings.Update(_SCollection, itemId);	
					
					if ( i_RowsAffected > 0 && i_RowsAffected!=-11)
					{
						//elimino e reinserisco i servizi
						WebControls.CalendarPicker cbDataDa;
						WebControls.CalendarPicker cbDataA;
						S_Controls.S_CheckBox chkAssoc;
						int id_Servizio;
						int i_Result;

						//cancello i servizi
						_SCollection = new S_ControlsCollection();
						i_Result = _Buildings.DeleteServizi(_SCollection, itemId);
						//ciclo slla griglia che contiene i servizi
						for (int i=0; i<=DataGridServizi.Items.Count-1;i++) 
						{
							chkAssoc = (S_Controls.S_CheckBox) this.DataGridServizi.Items[i].Cells[0].FindControl("chks_Associato");
							if (chkAssoc.Checked == true)
							{
								cbDataDa = (WebControls.CalendarPicker) this.DataGridServizi.Items[i].Cells[3].FindControl("CalPckDataDa");
								cbDataA = (WebControls.CalendarPicker) this.DataGridServizi.Items[i].Cells[4].FindControl("CalPckDataA");
								id_Servizio = int.Parse(this.DataGridServizi.Items[i].Cells[0].Text);
								//chiamo una funzione che inserisce i servizi
								_SCollection = this.ControlsServizi(cbDataDa.Datazione.Text, cbDataA.Datazione.Text, id_Servizio);
								i_Result = _Buildings.AddServizi(_SCollection, i_RowsAffected);
							}
						}
							
						//Committo la transazione
						_Buildings.commitTransaction();

						//Server.Transfer("Buildings.aspx");
						Server.Transfer("EditBuilding.aspx?FunId=" +  FunId.ToString() + "&itemId=" + itemId.ToString() + "&TipoOper=write");
						
					}
					else
					{
						//rollbecco la transazione
						_Buildings.rollbackTransaction();
						Classi.SiteJavaScript.msgBox(this.Page,"L'edificio é stato già inserito.");
					}

				}
				catch (Exception ex)
				{
					//rollbecco la transazione
					_Buildings.rollbackTransaction();
					string s_Err =  ex.Message.ToString().ToUpper();
					PanelMess.ShowError(s_Err, true);
				}
				finally
				{
					btnsSalva.Enabled=true;
				}
			}
			else
			{
				PanelMess.ShowError(msg, true);
			}
		
			
		}

		private bool ControllaDate(ref string msg)
		{
			WebControls.CalendarPicker cbDataDa;
			WebControls.CalendarPicker cbDataA;
			S_Controls.S_CheckBox chkAssoc;
			int cont = 0;

			for (int i=0; i<=DataGridServizi.Items.Count-1;i++) 
			{
				chkAssoc = (S_Controls.S_CheckBox) this.DataGridServizi.Items[i].Cells[0].FindControl("chks_Associato");
				if (chkAssoc.Checked == true)
				{
					cbDataDa = (WebControls.CalendarPicker) this.DataGridServizi.Items[i].Cells[3].FindControl("CalPckDataDa");
					cbDataA = (WebControls.CalendarPicker) this.DataGridServizi.Items[i].Cells[3].FindControl("CalPckDataA");
					if (cbDataDa.Datazione.Text.Trim() != "" && cbDataA.Datazione.Text.Trim() != "")
					{
						if (System.DateTime.Parse(cbDataDa.Datazione.Text) > System.DateTime.Parse(cbDataA.Datazione.Text))
						{
							msg = "La data inizio servizio non può essere maggiore della data di fine servizio.";
							return false;
						}
						else
						{
							cont = cont + 1;
						}
					}
					else
					{
						msg = "Valorizzare le date di inizio e fine servizio per i servizi associati.";
						return false;
					}
				}
			}
			if (cont == 0)
			{
				msg = "Occorre selezionare almeno un servizio.";
				return false;
			}
			else
			{
				msg = "";
				return true;
			}
		}

		private S_Controls.Collections.S_ControlsCollection ControlsServizi(string DataDa, string DataA, int id_Servizio)
		{
			int i_MaxParametri = 0;
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			i_MaxParametri = 0;

			//id servizio
			S_Controls.Collections.S_Object s_Serv = new S_Object();
			s_Serv.ParameterName = "p_ID_Servizio";
			s_Serv.DbType = CustomDBType.Integer;
			s_Serv.Direction = ParameterDirection.Input;
			s_Serv.Size = 10; 
			s_Serv.Index = i_MaxParametri;
			s_Serv.Value = id_Servizio;		

			i_MaxParametri ++;

			//data da
			S_Controls.Collections.S_Object s_DataDa = new S_Object();
			s_DataDa.ParameterName = "p_dataDa";
			s_DataDa.DbType = CustomDBType.Date;
			s_DataDa.Direction = ParameterDirection.Input;
			s_DataDa.Size = 10; 
			s_DataDa.Index = i_MaxParametri;
			s_DataDa.Value = DataDa;		

			i_MaxParametri ++;

			//data a
			S_Controls.Collections.S_Object s_DataA = new S_Object();
			s_DataA.ParameterName = "p_dataA";
			s_DataA.DbType = CustomDBType.Date;
			s_DataA.Direction = ParameterDirection.Input;
			s_DataA.Size = 10; 
			s_DataA.Index = i_MaxParametri;
			s_DataA.Value = DataA;		

			_SCollection.Add(s_Serv);
			_SCollection.Add(s_DataDa);
			_SCollection.Add(s_DataA);

			return _SCollection;
		
		}

		private void DataGridServizi_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{	

				WebControls.CalendarPicker cbDataDa = (WebControls.CalendarPicker) e.Item.Cells[3].FindControl("CalPckDataDa");
				WebControls.CalendarPicker cbDataA = (WebControls.CalendarPicker) e.Item.Cells[4].FindControl("CalPckDataA");
				//System.Web.UI.WebControls.CompareValidator cv = (System.Web.UI.WebControls.CompareValidator) e.Item.Cells[3].FindControl("cvDateServizi");

				if (cbDataDa!=null)
				cbDataDa.Datazione.Text = DataBinder.Eval(e.Item.DataItem, "date_start").ToString();
				if (cbDataA!=null)
				cbDataA.Datazione.Text = DataBinder.Eval(e.Item.DataItem, "date_end").ToString();
				//cv.ControlToValidate = cbDataDa.Datazione.ClientID;
				//cv.ControlToCompare=cbDataA.Datazione.ClientID;
			}


		}

		
		public DataTable GetPianiEdificio()
		{
			Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
			return _Buildings.GetPianiBuilding(itemId).Tables[0];
		}

		protected int GetIndex(string item)
		{
			if (item.Length > 0 )
				return int.Parse(item);
			else
				return 0;
		}

		protected string Decimale(string item, string tipo)
		{
			
			if (tipo=="Int")
				return Classi.Function.GetTypeNumber(item,Classi.NumberType.Intero); 
			else
               return Classi.Function.GetTypeNumber(item, Classi.NumberType.Decimale); 
					
		}
		private void lkbNuovo_Click(object sender, System.EventArgs e)
		{
			BindGrid();
			this.DataGridEsegui.ShowFooter = true;			
			this.DataGridEsegui.Columns[1].Visible = false;
			this.DataGridEsegui.Columns[2].Visible = false;
			this.DataGridEsegui.Columns[3].Visible = true;
		}

		private S_Controls.Collections.S_ControlsCollection ControlsStanze(int Piano, string Stanza, string DescrizioneStanza, Double Mq, int id_rm_cat, int id_rm_reparto,int id_rm_dest_uso)
		{
			
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			//id dell'edicio
			S_Controls.Collections.S_Object s_Edificio = new S_Object();
			s_Edificio.ParameterName = "p_BL_ID";
			s_Edificio.DbType = CustomDBType.Integer;
			s_Edificio.Direction = ParameterDirection.Input;
			s_Edificio.Size = 10; 
			s_Edificio.Index = _SCollection.Count;
			s_Edificio.Value = itemId;		
			_SCollection.Add(s_Edificio);
			
			//id del piano
			S_Controls.Collections.S_Object s_Piano = new S_Object();
			s_Piano.ParameterName = "p_piani";
			s_Piano.DbType = CustomDBType.Integer;
			s_Piano.Direction = ParameterDirection.Input;
			s_Piano.Size = 10; 
			s_Piano.Index = _SCollection.Count;
			s_Piano.Value = Piano;		
			_SCollection.Add(s_Piano); 
			

			//Descrizione della Stanza
			S_Controls.Collections.S_Object s_Stanza = new S_Object();
			s_Stanza.ParameterName = "p_descrizione";
			s_Stanza.DbType = CustomDBType.VarChar;
			s_Stanza.Direction = ParameterDirection.Input;
			s_Stanza.Size = 50; 
			s_Stanza.Index = _SCollection.Count;
			s_Stanza.Value = Stanza;		
			_SCollection.Add(s_Stanza); 
			

			///Descrizione estesa della stanza
			S_Controls.Collections.S_Object s_DescStanza = new S_Object();
			s_DescStanza.ParameterName = "p_descstanza";
			s_DescStanza.DbType = CustomDBType.VarChar;
			s_DescStanza.Direction = ParameterDirection.Input;
			s_DescStanza.Size = 255; 
			s_DescStanza.Index = _SCollection.Count;
			s_DescStanza.Value = DescrizioneStanza;		
			_SCollection.Add(s_DescStanza); 
			
			//id della categoria
			S_Controls.Collections.S_Object s_p_id_rm_cat = new S_Object();
			s_p_id_rm_cat.ParameterName = "p_id_rm_cat";
			s_p_id_rm_cat.DbType = CustomDBType.Integer;
			s_p_id_rm_cat.Direction = ParameterDirection.Input;
			s_p_id_rm_cat.Size = 10; 
			s_p_id_rm_cat.Index = _SCollection.Count;
			s_p_id_rm_cat.Value = id_rm_cat;		
			_SCollection.Add(s_p_id_rm_cat); 

			//id del reparto
			S_Controls.Collections.S_Object s_p_id_rm_reparto = new S_Object();
			s_p_id_rm_reparto.ParameterName = "p_id_rm_reparto";
			s_p_id_rm_reparto.DbType = CustomDBType.Integer;
			s_p_id_rm_reparto.Direction = ParameterDirection.Input;
			s_p_id_rm_reparto.Size = 10; 
			s_p_id_rm_reparto.Index = _SCollection.Count;
			s_p_id_rm_reparto.Value = id_rm_reparto;		
			_SCollection.Add(s_p_id_rm_reparto); 

			//id della destinazione d'uso
			S_Controls.Collections.S_Object s_p_id_rm_dest_uso = new S_Object();
			s_p_id_rm_dest_uso.ParameterName = "p_id_rm_dest_uso";
			s_p_id_rm_dest_uso.DbType = CustomDBType.Integer;
			s_p_id_rm_dest_uso.Direction = ParameterDirection.Input;
			s_p_id_rm_dest_uso.Size = 10; 
			s_p_id_rm_dest_uso.Index = _SCollection.Count;
			s_p_id_rm_dest_uso.Value = id_rm_dest_uso;		
			_SCollection.Add(s_p_id_rm_dest_uso);

			//mq netti
			S_Controls.Collections.S_Object s_p_mq = new S_Object();
			s_p_mq.ParameterName = "p_mq";
			s_p_mq.DbType = CustomDBType.Double;
			s_p_mq.Direction = ParameterDirection.Input;
			s_p_mq.Size = 10; 
			s_p_mq.Index = _SCollection.Count;
			s_p_mq.Value = Mq;		
			_SCollection.Add(s_p_mq);

			return _SCollection;
		}

		private void BindGridPiani()
		{
			HiddenPianiStanze.Value="";

			Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
			DataSet _MyDs;
	
			_MyDs= _Buildings.GetPianiBuilding(itemId).Copy();

			this.DataGridPiani.DataSource = _MyDs.Tables[0];
			this.DataGridPiani.DataBind();

			this.LabelPiano.Text = _MyDs.Tables[0].Rows.Count.ToString();	
			this.DataGridPiani.ShowFooter = false;
		}

		protected DataTable GetAllPiani()
		{
			HiddenPianiStanze.Value="";

			Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
			DataSet _MyDs;
	
			_MyDs= _Buildings.GetAllPiani();
			return _MyDs.Tables[0];			
		}

		protected DataTable GetAllPianiNonAssociati()
		{
			HiddenPianiStanze.Value="";

			Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
			DataSet _MyDs;
	
			_MyDs= _Buildings.GetAllPianiNonAssociati(itemId);
			return _MyDs.Tables[0];			
		}

		private void BindGrid()
		{
			HiddenPianiStanze.Value="";

			Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
			DataSet _MyDs;
	
			_MyDs= _Buildings.GetStanzeBuilding(itemId).Copy();

			this.DataGridEsegui.DataSource = _MyDs.Tables[0];
			this.DataGridEsegui.DataBind();

			this.lblRecord.Text = _MyDs.Tables[0].Rows.Count.ToString();	
			this.DataGridEsegui.ShowFooter = false;
		}

		private void DataGridEsegui_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			S_Controls.S_ComboBox cmbPiani;
			S_Controls.S_TextBox ddlstanzaNew; 
			S_Controls.S_TextBox ddldescrizionenew;

			S_Controls.S_ComboBox cmbCatN;
			S_Controls.S_TextBox TxtMqN;
			S_Controls.S_TextBox TxtMqNDec;
			TextBox TxtRepN;
			TextBox TxtUsoN;
			Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
			int i_Result=0;
   
			switch(((ImageButton)e.CommandSource).CommandName)
			{
				case "Insert":
					cmbPiani = ((S_Controls.S_ComboBox) e.Item.FindControl("ddlpianoNew"));
					ddlstanzaNew = ((S_Controls.S_TextBox) e.Item.FindControl("ddlstanzaNew")); 
					ddldescrizionenew = ((S_Controls.S_TextBox) e.Item.FindControl("ddldescrizionenew")); 
				
					TxtMqN = ((S_Controls.S_TextBox) e.Item.FindControl("TxtMqNew")); 
					TxtMqNDec = ((S_Controls.S_TextBox) e.Item.FindControl("TxtMqNewDec")); 
					cmbCatN = ((S_Controls.S_ComboBox) e.Item.FindControl("CmbCatNew"));
					TxtRepN = ((TextBox) e.Item.FindControl("IdRepartoNew")); 
					TxtUsoN = ((TextBox) e.Item.FindControl("IdUsoNew")); 
					string Mq=TxtMqN.Text+","+TxtMqNDec.Text;
					
					TxtMqN.Attributes.Add("onKeyPress","SoloNumeri();");
					TxtMqNDec.Attributes.Add("onKeyPress","SoloNumeri();");

					if (ddlstanzaNew.Text!= string.Empty)
						i_Result = _RM.AddStanze(ControlsStanze(int.Parse(cmbPiani.SelectedValue), ddlstanzaNew.Text,ddldescrizionenew.Text, Convert.ToDouble(Mq),int.Parse(cmbCatN.SelectedValue),int.Parse(TxtRepN.Text),int.Parse(TxtUsoN.Text)));   
					else
						PanelMess.ShowError("Inserire una stanza");
					try
					{
						if (i_Result > 0)
						{
							this.DataGridEsegui.EditItemIndex = -1;
							this.BindGrid();
							this.DataGridEsegui.Columns[1].Visible = true;
							this.DataGridEsegui.Columns[2].Visible = false;
							this.DataGridEsegui.Columns[3].Visible = false;
						}
						else
						{
							
							this.DataGridEsegui.Columns[1].Visible = false;
							this.DataGridEsegui.Columns[2].Visible = false;
							this.DataGridEsegui.Columns[3].Visible = true;
						}
					}
					catch (Exception ex) 
					{
						Console.WriteLine(ex.Message);  
						string s_Err = "Errore: Inserimento della stanza non riuscita";
						PanelMess.ShowError(s_Err, true);
					}
					break;
				case "Delete":
					cmbPiani = ((S_Controls.S_ComboBox) e.Item.FindControl("ddlpianoNew"));
					ddlstanzaNew = ((S_Controls.S_TextBox) e.Item.FindControl("ddlstanzaNew")); 
					ddldescrizionenew = ((S_Controls.S_TextBox) e.Item.FindControl("ddldescrizionenew")); 
		
					int id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());
					 

					try
					{
						i_Result = _RM.DeleteStanze(ControlsStanze(0, (DBNull.Value).ToString(),(DBNull.Value).ToString(),0,0,0,0),id);  
			
						if (i_Result >0)
						{
						
							this.DataGridEsegui.EditItemIndex = -1;
							this.BindGrid();
						}
					}
					catch (Exception ex) 
					{
						Console.WriteLine(ex.Message); 
						string s_Err = "Errore: Cancellazione della stanza non riuscita " + ex.ToString();
						PanelMess.ShowError(s_Err, true);
					}

					this.DataGridEsegui.Columns[1].Visible = true;
					this.DataGridEsegui.Columns[2].Visible = false;
					this.DataGridEsegui.Columns[3].Visible = false;
					break;
				
			
				default:
					// Do nothing.
					break;

			}
		}

		private void DataGridPiani_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			S_Controls.S_ComboBox cmbPianiAdd;
			S_Controls.S_TextBox pianoMqLordiAdd;
			S_Controls.S_TextBox pianoMqNettiAdd;
			S_Controls.S_TextBox pianoMqMuraAdd;
			Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
			int i_Result=0;

			Classi.ClassiAnagrafiche.Buildings classeEdifici = new Classi.ClassiAnagrafiche.Buildings();
   
			switch(((ImageButton)e.CommandSource).CommandName)
			{
				case "Insert":
					//btnsSalva.Enabled=false;
					cmbPianiAdd = ((S_Controls.S_ComboBox) e.Item.FindControl("cmbPianiAdd"));
					pianoMqNettiAdd = ((S_Controls.S_TextBox) e.Item.FindControl("pianoMqNettiAdd")); 
					pianoMqLordiAdd = ((S_Controls.S_TextBox) e.Item.FindControl("pianoMqLordiAdd"));
					pianoMqMuraAdd = ((S_Controls.S_TextBox) e.Item.FindControl("pianoMqMuraAdd"));

					if (pianoMqLordiAdd.Text=="")
						pianoMqLordiAdd.Text="0";

					pianoMqLordiAdd.Attributes.Add("onKeyPress","SoloNumeriVirgola();");

					pianoMqMuraAdd.Text = Convert.ToString(Convert.ToDecimal(pianoMqLordiAdd.Text)-Convert.ToDecimal(pianoMqNettiAdd.Text));

					string idPiano=cmbPianiAdd.SelectedValue;
					
					if (cmbPianiAdd.SelectedValue!= string.Empty)
						i_Result = classeEdifici.ExecutePianiBuilding("insert", Convert.ToInt64(itemId),Convert.ToInt64(idPiano), Convert.ToDecimal(pianoMqLordiAdd.Text), Convert.ToDecimal(pianoMqNettiAdd.Text), Convert.ToDecimal(pianoMqMuraAdd.Text));
					else
						PanelMess.ShowError("Inserire un Piano");
					try
					{
						if (i_Result > 0)
						{
							this.DataGridPiani.EditItemIndex = -1;
							this.BindGridPiani();
							this.DataGridPiani.Columns[1].Visible = true;
							this.DataGridPiani.Columns[2].Visible = false;
							this.DataGridPiani.Columns[3].Visible = false;
						}
						else
						{
							
							this.DataGridPiani.Columns[1].Visible = false;
							this.DataGridPiani.Columns[2].Visible = false;
							this.DataGridPiani.Columns[3].Visible = true;
						}
					}
					catch (Exception ex) 
					{
						Console.WriteLine(ex.Message);  
						string s_Err = "Errore: Inserimento del piano non riuscita";
						PanelMess.ShowError(s_Err, true);
					}
					finally
					{
						btnsSalva.Enabled=true;
					}
					break;

				case "Delete":

					idPiano=e.Item.Cells[0].Text;
					//int id = int.Parse(DataGridPiani.DataKeys[(int)e.Item.ItemIndex].ToString());
					
					try
					{
						i_Result = _Buildings.DeletePianiBuilding(Convert.ToInt64(itemId),Convert.ToInt64(idPiano));
						if (i_Result >0)
						{
						
							this.DataGridPiani.EditItemIndex = -1;
							this.BindGridPiani();
						}
					}
					catch (Exception ex) 
					{
						Console.WriteLine(ex.Message); 
						string s_Err = "Errore: Cancellazione del piano non riuscita";
						PanelMess.ShowError(s_Err, true);
					}

					this.DataGridPiani.Columns[1].Visible = true;
					this.DataGridPiani.Columns[2].Visible = false;
					this.DataGridPiani.Columns[3].Visible = false;
					break;
				
			
				default:
					// Do nothing.
					break;

			}
		}


		private void DataGridEsegui_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.DataGridEsegui.EditItemIndex = -1;
			this.BindGrid();
			this.DataGridEsegui.Columns[1].Visible = true;
			this.DataGridEsegui.Columns[2].Visible = false;
			this.DataGridEsegui.Columns[3].Visible = false;	
		}

		private void DataGridPiani_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.DataGridPiani.EditItemIndex = -1;
			this.BindGridPiani();
			this.DataGridPiani.Columns[1].Visible = true;
			this.DataGridPiani.Columns[2].Visible = false;
			this.DataGridPiani.Columns[3].Visible = false;	
		}

		private void DataGridEsegui_EditCommand(object source, DataGridCommandEventArgs e)
		{		
			this.DataGridEsegui.EditItemIndex = (int) e.Item.ItemIndex;
			this.BindGrid();
			this.DataGridEsegui.Columns[1].Visible = false;
			this.DataGridEsegui.Columns[2].Visible = true;
			this.DataGridEsegui.Columns[3].Visible = false;
		}

		private void DataGridPiani_EditCommand(object source, DataGridCommandEventArgs e)
		{
			this.DataGridPiani.EditItemIndex = (int) e.Item.ItemIndex;
			this.BindGridPiani();
			this.DataGridPiani.Columns[1].Visible = false;
			this.DataGridPiani.Columns[2].Visible = true;
			this.DataGridPiani.Columns[3].Visible = false;
			//btnsSalva.Enabled=false;
		}
		private void DataGridEsegui_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{		

			if(e.Item.ItemType== ListItemType.Footer)
			{	
				//parametri per ricerca reparti
				TextBox TxtRep;
				TextBox IdReparto;
				TxtRep = (TextBox) e.Item.FindControl("TxtRepNew");
				IdReparto=(TextBox) e.Item.FindControl("IdRepartoNew");
				descRep=TxtRep.ClientID;
				id=IdReparto.ClientID;

				//parametri per ricerca destinazioni uso
				TextBox TxtUso;
				TextBox IdUso;
				TxtUso = (TextBox) e.Item.FindControl("TxtUsoNew");
				IdUso=(TextBox) e.Item.FindControl("IdUsoNew");
				descUso=TxtUso.ClientID;
				Usoid=IdUso.ClientID;

				ImageButton ImgUpd;
				ImgUpd= (ImageButton)  e.Item.FindControl("Imagebutton1");

				S_Controls.S_ComboBox CmbCat;
                CmbCat = (S_Controls.S_ComboBox) e.Item.FindControl("CmbCatNew");

		
				string funzioneControllaDati = "return ControllaDati('" 
					+  CmbCat.ClientID + "','" 
					+ TxtRep.ClientID + "','" 
				    + TxtUso.ClientID + "');";
				ImgUpd.Attributes.Add("onclick",  funzioneControllaDati);
			}

			if (e.Item.ItemType == ListItemType.EditItem)
			{
				//parametri per ricerca reparti
				TextBox TxtRep1;
				TextBox IdReparto1;
				TxtRep1 = (TextBox) e.Item.FindControl("TxtRep");
				IdReparto1=(TextBox) e.Item.FindControl("IdReparto");
				descRep1=TxtRep1.ClientID;
				id1=IdReparto1.ClientID;

				//parametri per ricerca destinazioni uso
				TextBox TxtUso1;
				TextBox IdUso1;
				TxtUso1 = (TextBox) e.Item.FindControl("TxtUso");
				IdUso1=(TextBox) e.Item.FindControl("IdUso");
				descUso1=TxtUso1.ClientID;
				Usoid1=IdUso1.ClientID;

				ImageButton ImgUpd1;
				ImgUpd1= (ImageButton) e.Item.FindControl("imbUpdate");

				S_Controls.S_ComboBox CmbCat1;
				CmbCat1 = (S_Controls.S_ComboBox) e.Item.FindControl("CmbCat");

				string funzioneControllaDati = "return ControllaDati('" 
					+  CmbCat1.ClientID + "','" 
					+ TxtRep1.ClientID + "','" 
					+ TxtUso1.ClientID + "');";
				ImgUpd1.Attributes.Add("onclick",  funzioneControllaDati);
			}

			if ((e.Item.ItemType== ListItemType.Item) || (e.Item.ItemType==ListItemType.AlternatingItem) ||
				(e.Item.ItemType==ListItemType.EditItem))
			{
				

				DataRowView Dr =(DataRowView)e.Item.DataItem;
				string id1=Dr["Piani"].ToString();
				if (HiddenPianiStanze.Value=="")
					HiddenPianiStanze.Value=id1;
				else
					HiddenPianiStanze.Value+="," + id1;

				//				//Verifico che la stanza non abbia apparecchiature associate.
				Classi.ClassiAnagrafiche.Buildings _Buildings = new Classi.ClassiAnagrafiche.Buildings();
				int Result=_Buildings.StanzaApparecchiatura(int.Parse(Dr["id"].ToString()),itemId);
				//				int Result=0;
				ImageButton bt=(ImageButton)e.Item.Controls[1].Controls[3];
				bt.CausesValidation =false;
				if (Result==0)//non ha apparecchiature collegate solo messaggio con il confirm
					bt.Attributes.Add("onclick","return confirm(\"Eliminare la Stanza: " + Dr["descrizione"].ToString() + " nel Piano: " + Dr["DescrizionePiano"].ToString() + "?\")");
				else//Ha apparecchiature collegate non deve fare il Post
				{
					bt.Attributes.Add("onclick","alert(\"La Stanza: " + Dr["descrizione"].ToString() + " nel Piano: " + Dr["DescrizionePiano"].ToString() + " non può essere eliminata perchè associata ad una apparecchiatura.\");return false;");
					if(e.Item.Controls[4].Controls[1] is S_Controls.S_ComboBox)
						((S_Controls.S_ComboBox) e.Item.Controls[4].Controls[1]).Enabled =false;
				}
                
			}
		}

		private void DataGridPiani_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			btnsSalva.Enabled=true;
			if ((e.Item.ItemType== ListItemType.Item) || (e.Item.ItemType==ListItemType.AlternatingItem)) 
			{
				if(e.Item.Controls[7].Controls[1] is System.Web.UI.WebControls.Label)
				{
					string valore;
					valore=((Label) e.Item.Controls[7].Controls[1]).Text;
					if(Convert.ToDecimal(((Label) e.Item.Controls[7].Controls[1]).Text)<0)
						((Label) e.Item.Controls[7].Controls[1]).ForeColor=Color.Red;
				}
			}
			if ((e.Item.ItemType== ListItemType.Item) || (e.Item.ItemType==ListItemType.AlternatingItem) ||
				(e.Item.ItemType==ListItemType.EditItem))
			{	
				if(e.Item.Controls[4].Controls[1] is S_Controls.S_ComboBox)
					((S_Controls.S_ComboBox) e.Item.Controls[4].Controls[1]).Enabled =false;	
				if(e.Item.Controls[6].Controls[1] is S_Controls.S_TextBox)
					((S_Controls.S_TextBox) e.Item.Controls[6].Controls[1]).Enabled =false;
				if(e.Item.Controls[7].Controls[1] is S_Controls.S_TextBox)
					((S_Controls.S_TextBox) e.Item.Controls[7].Controls[1]).Enabled =false;
				//btnsSalva.Enabled=false;

				DataRowView Dr =(DataRowView)e.Item.DataItem;

				string id1=Dr["DESCRIZIONE"].ToString();
				if (HiddenPianiStanze.Value=="")
					HiddenPianiStanze.Value=id1;
				else
					HiddenPianiStanze.Value+="," + id1;

				//				//Verifico che il piano non abbia stanze associate.
				Classi.ClassiAnagrafiche.Buildings _Buildings = new Classi.ClassiAnagrafiche.Buildings();
				int Result = _Buildings.GetNumeroStanzeBuilding(itemId);
				ImageButton bt=(ImageButton)e.Item.Controls[1].Controls[3];
				bt.CausesValidation =false;
				if (Result==0)//non ha stanze collegate solo messaggio con il confirm
					bt.Attributes.Add("onclick","return confirm(\"Eliminare il Piano: " + Dr["DESCRIZIONE"].ToString() + "?\")");
				else//Ha stanze collegate non deve fare il Post
				{
					bt.Attributes.Add("onclick","alert(\"Il piano: " + Dr["DESCRIZIONE"].ToString() + " non può essere eliminato perchè associato a uno o più piani.\");return false;");
					if(e.Item.Controls[4].Controls[1] is S_Controls.S_ComboBox)
						((S_Controls.S_ComboBox) e.Item.Controls[4].Controls[1]).Enabled =false;
				}
			}

			if ((e.Item.ItemType== ListItemType.Footer) ||
				(e.Item.ItemType==ListItemType.EditItem))
			{	
				if(e.Item.Controls[6].Controls[1] is S_Controls.S_TextBox)
				{ 
					((S_Controls.S_TextBox) e.Item.Controls[6].Controls[1]).Enabled =false;
					if (((S_Controls.S_TextBox) e.Item.Controls[6].Controls[1]).Text =="")
						((S_Controls.S_TextBox) e.Item.Controls[6].Controls[1]).Text ="0";
				}
				if(e.Item.Controls[7].Controls[1] is S_Controls.S_TextBox)
				{
					((S_Controls.S_TextBox) e.Item.Controls[7].Controls[1]).Enabled =false;
					if (((S_Controls.S_TextBox) e.Item.Controls[7].Controls[1]).Text =="")
						((S_Controls.S_TextBox) e.Item.Controls[7].Controls[1]).Text ="0";
				}
				//btnsSalva.Enabled=false;
			}
		}

		private void DataGridEsegui_UpdateCommand_1(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//marianna qui
			int id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());
			 
			S_Controls.S_TextBox TxtMq = ((S_Controls.S_TextBox) e.Item.FindControl("TxtMq")); 
			S_Controls.S_TextBox TxtMqDec = ((S_Controls.S_TextBox) e.Item.FindControl("TxtMqDec")); 
			S_Controls.S_ComboBox cmbCat = ((S_Controls.S_ComboBox) e.Item.FindControl("CmbCat"));
			TextBox TxtRep = ((TextBox) e.Item.FindControl("IdReparto")); 
			TextBox TxtUso = ((TextBox) e.Item.FindControl("IdUso"));

			S_Controls.S_ComboBox cmbPiani = ((S_Controls.S_ComboBox) e.Item.FindControl("ddlpiano"));
			S_Controls.S_TextBox ddlstanza = ((S_Controls.S_TextBox) e.Item.FindControl("ddlstanza")); 
			S_Controls.S_TextBox ddldescrizione = ((S_Controls.S_TextBox) e.Item.FindControl("ddldescrizione")); 
			int i_Result=0;
			string  Mq=TxtMq.Text+","+TxtMqDec.Text;

			TxtMq.Attributes.Add("onKeyPress","SoloNumeri();");
			TxtMqDec.Attributes.Add("onKeyPress","SoloNumeri();");

			try
			{
				i_Result = _RM.UpdateStanze(ControlsStanze(int.Parse(cmbPiani.SelectedValue), 
					ddlstanza.Text,ddldescrizione.Text,Convert.ToDouble(Mq), 
					int.Parse(cmbCat.SelectedValue),int.Parse(TxtRep.Text),
					int.Parse(TxtUso.Text)),
					id);   
			
				if (i_Result > 0)
				{
					//this.PanelMessFunzioni.ShowMessage("Modifica della stanza effettuata con successo.", true); 
					this.DataGridEsegui.EditItemIndex = -1;
					this.BindGrid();
					this.DataGridEsegui.Columns[1].Visible = true;
					this.DataGridEsegui.Columns[2].Visible = false;
					this.DataGridEsegui.Columns[3].Visible = false;
				}
				else
				{
					//this.PanelMessFunzioni.ShowError("Modifica non eseguita", true);
					this.DataGridEsegui.Columns[1].Visible = false;
					this.DataGridEsegui.Columns[2].Visible = true;
					this.DataGridEsegui.Columns[3].Visible = false;
				}
			}
			catch(Exception ex) 
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void DataGridPiani_UpdateCommand_1(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int id = int.Parse(DataGridPiani.DataKeys[(int)e.Item.ItemIndex].ToString());
	
			S_Controls.S_ComboBox cmbPianiMod;
			S_Controls.S_TextBox pianoMqLordiMod;
			S_Controls.S_TextBox pianoMqNettiMod;
			S_Controls.S_TextBox pianoMqMuraMod;
			Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();

			int i_Result=0;
			
			try
			{

				cmbPianiMod = ((S_Controls.S_ComboBox) e.Item.FindControl("cmbPianiMod"));
				
				pianoMqNettiMod = ((S_Controls.S_TextBox) e.Item.FindControl("pianoMqNettiMod")); 
				pianoMqLordiMod = ((S_Controls.S_TextBox) e.Item.FindControl("pianoMqLordiMod"));
				pianoMqMuraMod = ((S_Controls.S_TextBox) e.Item.FindControl("pianoMqMuraMod"));

				if (pianoMqLordiMod.Text=="")
					pianoMqLordiMod.Text="0";

				pianoMqLordiMod.Attributes.Add("onKeyPress","SoloNumeriVirgola();");
				
				pianoMqMuraMod.Text = Convert.ToString(Convert.ToDecimal(pianoMqLordiMod.Text)-Convert.ToDecimal(pianoMqNettiMod.Text));

				string idPiano=cmbPianiMod.SelectedValue;
				i_Result = _Buildings.ExecutePianiBuilding("update", Convert.ToInt64(itemId), Convert.ToInt64(idPiano), Convert.ToDecimal(pianoMqLordiMod.Text), Convert.ToDecimal(pianoMqNettiMod.Text), Convert.ToDecimal(pianoMqMuraMod.Text));
			
				if (i_Result > 0)
				{
					//this.PanelMessFunzioni.ShowMessage("Modifica della stanza effettuata con successo.", true);
					this.DataGridPiani.EditItemIndex = -1;
					this.BindGridPiani();
					this.DataGridPiani.Columns[1].Visible = true;
					this.DataGridPiani.Columns[2].Visible = false;
					this.DataGridPiani.Columns[3].Visible = false;
				}
				else
				{
					//this.PanelMessFunzioni.ShowError("Modifica non eseguita", true);
					this.DataGridPiani.Columns[1].Visible = false;
					this.DataGridPiani.Columns[2].Visible = true;
					this.DataGridPiani.Columns[3].Visible = false;
				}
			}
			catch(Exception ex) 
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				btnsSalva.Enabled=true; 
			}
		}

		private void nuovoPiano_Click(object sender, System.EventArgs e)
		{
			this.DataGridPiani.ShowFooter = true;
			this.DataGridPiani.Columns[1].Visible = false;
			this.DataGridPiani.Columns[2].Visible = false;
			this.DataGridPiani.Columns[3].Visible = true;
		}

		private void ButtonRefreshMq_Click(object sender, System.EventArgs e)
		{
			Classi.ClassiAnagrafiche.Buildings clBl =new TheSite.Classi.ClassiAnagrafiche.Buildings();
			clBl.UpdateFl(itemId);
			this.DataGridPiani.EditItemIndex = -1;
			this.BindGridPiani();
			this.DataGridPiani.Columns[1].Visible = true;
			this.DataGridPiani.Columns[2].Visible = false;
			this.DataGridPiani.Columns[3].Visible = false;	
		}	
	
		//Carica cmb categoria RM
		public DataTable BindRmCat()
		{
			DataSet ds = _RM.GetAllCategoria();
			DataTable dt=ds.Tables[0];
			DataRow shRow =dt.NewRow(); 
			shRow["Id"] = 0; 
			shRow["DESCRIZIONE"] = "-- Scegliere una Categoria--"; 
			dt.Rows.InsertAt(shRow, 0);
			return dt;
		}
	}
}
