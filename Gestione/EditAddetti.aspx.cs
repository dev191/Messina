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
using MyCollection;
using StampaRapportiPdf.Classi;

namespace TheSite.Gestione
{	
	/// <summary>
	/// Descrizione di riepilogo per EditAddetti
	/// </summary>
	public class EditAddetti : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected Csy.WebControls.MessagePanel PanelMess;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		int itemId = 0;
		protected S_Controls.S_Button btnsSalva;
		protected S_Controls.S_Button btnsElimina;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected System.Web.UI.WebControls.Label lblOperazione;
		int FunId = 0;
		protected S_Controls.S_TextBox txtscognome;
		protected S_Controls.S_TextBox txtsnome;
		protected S_Controls.S_TextBox txtsindirizzo;
		protected S_Controls.S_TextBox txtstelefono;
		protected S_Controls.S_ComboBox cmbsprov_nasc;
		protected S_Controls.S_ComboBox cmbscom_nasc;
		protected S_Controls.S_ComboBox cmbsprov_res;
		protected S_Controls.S_ComboBox cmbscom_res;
		protected S_Controls.S_ComboBox cmbsditta_id;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvcognome;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvnome;
		protected TheSite.WebControls.CalendarPicker CalendarPicker1;
		protected System.Web.UI.WebControls.ListBox ListBoxLeft;
		protected System.Web.UI.WebControls.Button btnAssocia;
		protected System.Web.UI.WebControls.Button btnElimina;
		protected System.Web.UI.WebControls.ListBox ListBoxRight;
		private DataSet _DsListboxL;		
		private DataSet _DsListboxR;
		protected S_Controls.S_TextBox txtscellulare;
		protected S_Controls.S_ComboBox cmbspriorita;
		protected S_Controls.S_TextBox txtszona;
		protected System.Web.UI.WebControls.RangeValidator RVcmbsditta;
		protected S_Controls.S_ComboBox cmbsLivello;
		TheSite.Gestione.Addetti _fp;
	
	
		private void Page_Load(object sender, System.EventArgs e)
		{					
			CalendarPicker1.Datazione.DBParameterName="p_data_nascita";
			CalendarPicker1.Datazione.DBDirection= ParameterDirection.Input;
			CalendarPicker1.Datazione.DBDataType= CustomDBType.VarChar;
			CalendarPicker1.Datazione.DBIndex=2;
			CalendarPicker1.Datazione.DBSize=8;
			CalendarPicker1.Datazione.DBDefaultValue="";
			check_caselle_testo();
			
			
			FunId = Int32.Parse(Request["FunId"]);			
			
			
			if (Request["ItemId"] != null) 
			{
				itemId = Int32.Parse(Request["ItemId"]);				
			}
			if (!Page.IsPostBack )
			{
				BindPriorita();
				BindProvince();
				BindProvince1();
				BindDitte();
				BindLivello();
				if (itemId != 0) 
				{
					DataSet _MyDs = new DataSet();
					Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
					_MyDs = _Addetti.GetSingleData(itemId); 
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						this.txtscognome.Text= (string) _Dr["COGNOME"];
					
						if (_Dr["NOME"] != DBNull.Value)
							this.txtsnome.Text = (string) _Dr["NOME"];
										
						if (_Dr["DATA_NASCITA"] != DBNull.Value)
							this.CalendarPicker1.Datazione.Text =System.DateTime.Parse( _Dr["DATA_NASCITA"].ToString()).ToShortDateString();						
																	
						if (_Dr["PROV_NASC_ID"] != DBNull.Value)
							this.cmbsprov_nasc .SelectedValue= _Dr["PROV_NASC_ID"].ToString();
					
						BindComuni();								
						
												
						if (_Dr["PROV_RES_ID"] != DBNull.Value)
							this.cmbsprov_res.SelectedValue= _Dr["PROV_RES_ID"].ToString();
							BindComuni1();
												
						if (_Dr["COM_NASC_ID"] != DBNull.Value)
							this.cmbscom_nasc.SelectedValue = _Dr["COM_NASC_ID"].ToString();
											
						if (_Dr["COM_RES_ID"] != DBNull.Value)
							this.cmbscom_res .SelectedValue = _Dr["COM_RES_ID"].ToString();
														
						if (_Dr["INDIRIZZO"] != DBNull.Value)
							this.txtsindirizzo.Text = (string) _Dr["INDIRIZZO"].ToString();

						if (_Dr["TELEFONO"] != DBNull.Value)
							this.txtstelefono.Text = (string) _Dr["TELEFONO"].ToString();
						
						if (_Dr["CELLULARE"] != DBNull.Value)
							this.txtscellulare.Text = (string) _Dr["CELLULARE"].ToString();
						
						if (_Dr["DITTA_ID"] != DBNull.Value)
							this.cmbsditta_id.SelectedValue = _Dr["DITTA_ID"].ToString();
						
						if(_Dr["PRIORITA"] != DBNull.Value)
							this.cmbspriorita.SelectedValue= _Dr["PRIORITA"].ToString();

						if(_Dr["ZONA"] != DBNull.Value)
							this.txtszona.Text= (string) _Dr["ZONA"].ToString();

						if(_Dr["livello"] != DBNull.Value)
							this.cmbsLivello.SelectedValue=  _Dr["livello"].ToString();

						this.lblOperazione.Text = "Modifica Addetto: " + this.txtscognome.Text + " " + this.txtsnome.Text;
						this.lblFirstAndLast.Visible = true;						
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");	
						lblFirstAndLast.Text = _Addetti.GetFirstAndLastUser(_Dr);

					}
					
				}
				else
				{
					this.lblOperazione.Text = "Inserimento Addetto";
					BindComuni();
					BindComuni1();
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;
				
				}				
				AggiornaListbox();
				if (Request["TipoOper"] == "read")
				{
					AbilitaControlli(false);
					this.lblOperazione.Text = "Visualizzazione Addetto: " + this.txtscognome.Text + " " + this.txtsnome.Text;
				}
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Addetti) 
				{
					_fp = (TheSite.Gestione.Addetti) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
				}	
			}
		}

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

		private void check_caselle_testo()
		{
			this.txtscognome.Attributes.Add("onkeypress","Verifica(this.value,50)");
			this.txtsnome.Attributes.Add("onkeypress","Verifica(this.value,50)");
			this.txtszona.Attributes.Add("onkeypress","Verifica(this.value,50)");
				
		}
		
		private void BindPriorita()
		{
			int k=0;
			string s_v="1";	
		while(k<4)
			{
			cmbspriorita.Items.Insert(k,s_v);
			k++;
			s_v= (k+1).ToString();
			}
		}

		
		private void BindProvince()
		{			
			this.cmbsprov_nasc .Items.Clear();
			Classi.ProvinceComuni _ProvCom = new TheSite.Classi.ProvinceComuni();
				
			DataSet _MyDs = _ProvCom.GetData().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsprov_nasc.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione_breve", "provincia_id", "- Selezionare una Provincia -", "-1");
				this.cmbsprov_nasc.DataTextField = "descrizione_breve";
				this.cmbsprov_nasc.DataValueField = "provincia_id";
				this.cmbsprov_nasc.DataBind();
				
			}			
		}

		private void BindProvince1()
		{			
			this.cmbsprov_res .Items.Clear();
			Classi.ProvinceComuni _ProvCom = new TheSite.Classi.ProvinceComuni();
			DataSet _MyDs = _ProvCom.GetData().Copy();
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsprov_res.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione_breve", "provincia_id", "- Selezionare una Provincia -","-1");
				this.cmbsprov_res.DataTextField = "descrizione_breve";
				this.cmbsprov_res.DataValueField = "provincia_id";
				this.cmbsprov_res.DataBind();
				
			}			
		}

		private void BindComuni()
		{	
			this.cmbscom_nasc.Items.Clear();
			Classi.ProvinceComuni _ProvCom = new TheSite.Classi.ProvinceComuni();
			S_ControlsCollection _SColl = new S_ControlsCollection();
			S_Controls.Collections.S_Object s_Provid = new S_Object();			
			s_Provid.ParameterName = "p_provincia_id";
			s_Provid.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer; 
			s_Provid.Direction = ParameterDirection.Input;			
			s_Provid.Index = 0;
			s_Provid.Value = cmbsprov_nasc.SelectedValue;
			_SColl.Add(s_Provid);
						
			DataSet _MyDs = _ProvCom.GetComune(_SColl).Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0) 
			{
				this.cmbscom_nasc.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "comune_id", "- Selezionare un Comune -", "-1");
				this.cmbscom_nasc.DataTextField = "descrizione";
				this.cmbscom_nasc.DataValueField = "comune_id";
				this.cmbscom_nasc.DataBind();					
			}
			else
			{
				string s_Messagggio = "- Nessun Comune  -";
				this.cmbscom_nasc.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
						
			}
			
			
		}

		private void BindComuni1()
		{
			
			this.cmbscom_res.Items.Clear();
			Classi.ProvinceComuni _ProvCom = new TheSite.Classi.ProvinceComuni();
			S_ControlsCollection _SColl = new S_ControlsCollection();
			S_Controls.Collections.S_Object s_Provid = new S_Object();			
			s_Provid.ParameterName = "p_provincia_id";
			s_Provid.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer; 
			s_Provid.Direction = ParameterDirection.Input;			
			s_Provid.Index = 0;
			s_Provid.Value = cmbsprov_res.SelectedValue;
			
			_SColl.Add(s_Provid);
						
			DataSet _MyDs = _ProvCom.GetComune(_SColl).Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbscom_res.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "comune_id", "- Selezionare un Comune -", "-1");
				this.cmbscom_res.DataTextField = "descrizione";
				this.cmbscom_res.DataValueField = "comune_id";
				this.cmbscom_res.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Comune  -";
				this.cmbscom_res.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
			}
		}

		private void BindDitte()
		{
			
			this.cmbsditta_id.Items.Clear();
		
			Classi.ClassiAnagrafiche.Ditte _Ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
				
			DataSet _MyDs = _Ditte.GetData().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{				
				this.cmbsditta_id.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione","id", "- Selezionare una Ditta -", "-1");
				this.cmbsditta_id.DataTextField = "descrizione";
				this.cmbsditta_id.DataValueField = "id";
				this.cmbsditta_id.DataBind();
			}			
		}

		private void AbilitaControlli(bool enabled)
		{
			this.txtscognome.Enabled = enabled;
			this.txtsnome.Enabled = enabled;
			this.CalendarPicker1.Datazione.Enabled =enabled;
			this.txtsindirizzo.Enabled = enabled;
			this.txtstelefono.Enabled = enabled;
			this.txtscellulare.Enabled = enabled;
			this.txtszona.Enabled = enabled;
			this.cmbsprov_nasc.Enabled = enabled;
			this.cmbscom_nasc.Enabled = enabled;
			this.cmbsprov_res.Enabled = enabled;
			this.cmbscom_res.Enabled = enabled;
			this.cmbsditta_id.Enabled = enabled;
			this.cmbspriorita.Enabled = enabled;
			this.cmbsLivello.Enabled= enabled;
			this.btnsSalva.Enabled = enabled;
			this.ListBoxLeft.Enabled = enabled;
			this.ListBoxRight.Enabled = enabled;
			this.btnsElimina.Enabled = enabled;
			this.btnAssocia.Enabled=enabled;
			this.btnElimina.Enabled=enabled;

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
			this.cmbsprov_nasc.SelectedIndexChanged += new System.EventHandler(this.cmbsprov_nasc_SelectedIndexChanged);
			this.cmbsprov_res.SelectedIndexChanged += new System.EventHandler(this.cmbsprov_res_SelectedIndexChanged);
			this.btnAssocia.Click += new System.EventHandler(this.btnAssocia_Click);
			this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
			this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
			this.btnsElimina.Click += new System.EventHandler(this.btnsElimina_Click);
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		private void BindLivello()
		{
			Classi.ClassiAnagrafiche.Livelli _Livelli= new TheSite.Classi.ClassiAnagrafiche.Livelli();
			this.cmbsLivello .Items.Clear();
			DataSet _MyDs = _Livelli.GetData().Copy();
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsLivello.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "codicelivello", "id", "- Selezionare un Livello -","-1");
				this.cmbsLivello.DataTextField = "codicelivello";
				this.cmbsLivello.DataValueField = "id";
				this.cmbsLivello.DataBind();
			}
		}

		private void AggiornaListbox()
		{
			_DsListboxL=new DataSet();
			_DsListboxR=new DataSet();
			CreaTabelle();
			
			
			//Specializzazioni


				Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
				DataView _DvTr = new DataView(_Addetti.GetTRADD(itemId).Tables[0]);
				if (_DvTr.Count >0)
				{
					foreach (DataRowView _DvrTr in _DvTr)
					{
						DataRow _DrTr = _DsListboxL.Tables["Specializzazioni"].NewRow();
						_DrTr["Id"] = _DvrTr["Id"].ToString();
						_DrTr["descrizione"] = _DvrTr["descrizione"].ToString();						
						_DsListboxL.Tables["Specializzazioni"].Rows.Add(_DrTr);
					}
				}
			
			Session.Add("Spec",_DsListboxL.Tables[0]);
			this.ListBoxLeft.DataSource =_DsListboxL.Tables["Specializzazioni"];
			this.ListBoxLeft.DataValueField = "Id";
			this.ListBoxLeft.DataTextField = "Descrizione";
			this.ListBoxLeft.DataBind();
			this.ListBoxLeft.SelectedIndex = 0;
			if (itemId >0)
			{
				this.ListBoxLeft.Enabled=true;
			}
		    else
			{
			this.ListBoxLeft.Enabled=false;
			
			}
			//Specializzazioni Addetto
			
			
			if (itemId >0)
			{
				DataView _DvTrAdd = new DataView(_Addetti.GetTRAddetto(itemId).Tables[0]);
				if (_DvTrAdd.Count >0)
				{
					foreach (DataRowView _DrvTrAdd in _DvTrAdd)
					{
						DataRow _DrTrAdd = _DsListboxR.Tables["SpecAddetto"].NewRow();
						_DrTrAdd["descrizione"] = _DrvTrAdd["description"].ToString();
						_DrTrAdd["id_tr"] = _DrvTrAdd["id_tr"].ToString();
						_DsListboxR.Tables["SpecAddetto"].Rows.Add(_DrTrAdd);
					}
				
				
				}
			}
						
			Session.Add("SpecAdd",_DsListboxR.Tables[0]);	
			this.ListBoxRight.DataSource =_DsListboxR.Tables["SpecAddetto"];
			this.ListBoxRight.DataValueField = "id_tr";
			this.ListBoxRight.DataTextField = "descrizione";
			this.ListBoxRight.DataBind();
			this.ListBoxRight.SelectedIndex = 0;
			
			
			}
			
	
		private void CreaTabelle()
		{	//Specializzazioni
			DataTable _DtSpec = new DataTable("Specializzazioni");
			 
			DataColumn  _DcIdSp = new DataColumn("Id");
			_DcIdSp.DataType = System.Type.GetType("System.Int32");
			_DcIdSp.Unique = true;
			_DcIdSp.AllowDBNull = false;
			_DtSpec.Columns.Add(_DcIdSp);
			
			DataColumn _DcDescSp = new DataColumn("descrizione");
			_DcDescSp.DataType = System.Type.GetType("System.String");
			_DcDescSp.Unique = false;
			_DcDescSp.AllowDBNull = false;
			_DtSpec.Columns.Add(_DcDescSp);
            
			//Specializzazioni-Addetto
			DataTable _DtSpecAddetto = new DataTable("SpecAddetto");
			
			DataColumn _DcId_trSpAd = new DataColumn("id_tr");
			_DcId_trSpAd.DataType = System.Type.GetType("System.Int32");
			_DcId_trSpAd.Unique = false;
			_DcId_trSpAd.AllowDBNull = false;
			_DtSpecAddetto.Columns.Add(_DcId_trSpAd);
			
			DataColumn _DcDescSpAd = new DataColumn("descrizione");
			_DcDescSpAd.DataType = System.Type.GetType("System.String");
			_DcDescSpAd.Unique = false;
			_DcDescSpAd.AllowDBNull = false;
			_DtSpecAddetto.Columns.Add(_DcDescSpAd);

			
			DataColumn _DcOperazione = new DataColumn("Operazione");
			_DcOperazione.DataType = System.Type.GetType("System.String");
			_DcOperazione.Unique = false;
			_DcOperazione.AllowDBNull = true;
			_DcOperazione.DefaultValue = "D";
			_DtSpecAddetto.Columns.Add(_DcOperazione);

			_DsListboxL.Tables.Add(_DtSpec);
			_DsListboxR.Tables.Add(_DtSpecAddetto);
		
		}
	
		private void btnsElimina_Click(object sender, System.EventArgs e)
		{
			try
			{	// chiamata a routine che elimina tutte le tr associate all'addetto_id
				EliminaTRAddetto();
				
				Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
				
				this.txtscognome.DBDefaultValue = DBNull.Value;
				this.txtsnome.DBDefaultValue = DBNull.Value;
				this.txtsindirizzo.DBDefaultValue = DBNull.Value;
				this.txtstelefono.DBDefaultValue = DBNull.Value;
				this.txtscellulare.DBDefaultValue = DBNull.Value;
				this.txtszona.DBDefaultValue = DBNull.Value;
				this.CalendarPicker1.Datazione.DBDefaultValue=DBNull.Value;
				this.cmbsprov_nasc.DBDefaultValue = "-1";
				this.cmbscom_nasc.DBDefaultValue = "-1";
				this.cmbsprov_res.DBDefaultValue = "-1";
				this.cmbscom_res.DBDefaultValue = "-1";
				this.cmbspriorita.DBDefaultValue = "1";

				this.cmbsLivello.DBDefaultValue="-1";

				int i_RowsAffected = 0;

				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			   
				_SCollection.AddItems(this.PanelEdit.Controls);
			

				
				i_RowsAffected = _Addetti.Delete(_SCollection, itemId);

				if ( i_RowsAffected == -1 )					
					Server.Transfer("Addetti.aspx");
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}	
		}

		private void btnsSalva_Click(object sender, System.EventArgs e)
		{	
			this.txtscognome.DBDefaultValue = DBNull.Value;
			this.txtsnome.DBDefaultValue = DBNull.Value;
			this.txtsindirizzo.DBDefaultValue = DBNull.Value;
			this.txtstelefono.DBDefaultValue = DBNull.Value;
			this.txtscellulare.DBDefaultValue = DBNull.Value;
			this.txtszona.DBDefaultValue = DBNull.Value;
			this.CalendarPicker1.Datazione.DBDefaultValue=DBNull.Value;
			this.cmbsprov_nasc.DBDefaultValue =DBNull.Value;
			this.cmbscom_nasc.DBDefaultValue = "-1";
			this.cmbsprov_res.DBDefaultValue = DBNull.Value;
			this.cmbscom_res.DBDefaultValue = "-1";
			this.cmbsditta_id.DBDefaultValue = DBNull.Value;
			this.cmbspriorita.DBDefaultValue=1;

			this.cmbsLivello.DBDefaultValue="-1";

				
			
			this.txtscognome.Text=this.txtscognome.Text.Trim();
			this.txtsnome.Text= this.txtsnome.Text.Trim();	
			this.txtstelefono.Text= this.txtstelefono.Text.Trim();
			this.txtscellulare.Text= this.txtscellulare.Text.Trim();
			this.txtsindirizzo.Text=this.txtsindirizzo.Text.Trim();
			this.txtszona.Text = this.txtszona.Text.Trim();
		

			int i_RowsAffected = 0;
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			_SCollection.AddItems(this.PanelEdit.Controls);
	
			try
			{
				if (itemId == 0)
				{			
					Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
					i_RowsAffected = _Addetti.Add(_SCollection);
				}
				else
				{
					Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
					i_RowsAffected = _Addetti.Update(_SCollection,itemId);
				}

				if ( i_RowsAffected > 0 )
				{
					if (this.ListBoxRight.Items.Count >= 0)
					{
						DataTable o_Dt = (DataTable) Session["SpecAdd"];
						DataView o_Dv = new DataView(o_Dt);
                    					
						foreach(ListItem o_Litem in this.ListBoxRight.Items)
						{
							o_Dv.RowFilter = "id_tr = " + o_Litem.Value.ToString();
						
							if ( o_Dv.Count == 0 )
							{
								DataRow o_Dr = o_Dt.NewRow();
								o_Dr["id_tr"] = o_Litem.Value.ToString();
								o_Dr["descrizione"] = o_Litem.Text.ToString();
								o_Dr["Operazione"] = "I";
								o_Dt.Rows.Add(o_Dr);
							}
							else if ( o_Dv.Count == 1)
							{
								o_Dv[0]["Operazione"] = DBNull.Value;
							}						
						}
						this.UpdateTR_Addetti(o_Dt); 
						Session.Remove("SpecAdd");
					}	
					
					
					
					if (itemId==0)
					Response.Redirect("EditAddetti.aspx?ItemId=" + i_RowsAffected +"&FunId=" + FunId);
					else						
					Server.Transfer("Addetti.aspx");				
				}
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}	
		}

		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Addetti.aspx");
		}

		private void cmbsprov_nasc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			if (cmbsprov_nasc.SelectedIndex>0)
				BindComuni();	
			else
			{
				this.cmbscom_nasc .Items.Clear();}
		}

		private void cmbsprov_res_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbsprov_res.SelectedIndex >0)
				BindComuni1();
			else
			{
				this.cmbscom_res .Items.Clear();}
		}

		private void btnAssocia_Click(object sender, System.EventArgs e)
		{
			    Addiziona();
		
			}

		private void btnElimina_Click(object sender, System.EventArgs e)
		{
			Sottrai();
		}
		private void Addiziona()
		{
			string s_strSelection;
			string s_strSelectionValue;
			if (ListBoxLeft.SelectedItem != null)
			{
				s_strSelection = ListBoxLeft.SelectedItem.Text;
				s_strSelectionValue = ListBoxLeft.SelectedItem.Value;

				if (ListBoxRight.Items.FindByValue(s_strSelectionValue)== null )
				{
					ListItem o_Li = new ListItem(s_strSelection, s_strSelectionValue);
					ListBoxRight.Items.Add(o_Li);
					ListBoxRight.SelectedIndex = 0;
					ListBoxLeft.Items.Remove(o_Li);
				}

			}
			}
		private void Sottrai()
			{
				string s_strSelection;
				string s_strSelectionValue;
				if (ListBoxRight.SelectedItem != null)
				{
					s_strSelection = ListBoxRight.SelectedItem.Text;
					s_strSelectionValue = ListBoxRight.SelectedItem.Value;
					if (ListBoxLeft.Items.FindByValue(s_strSelectionValue)== null )
					{
						ListItem o_Li = new ListItem(s_strSelection, s_strSelectionValue);
						ListBoxLeft.Items.Add(o_Li);
						ListBoxLeft.SelectedIndex = 0;
						ListBoxRight.Items.Remove(o_Li);
					}
				
				}
		
		
			}

		private void EliminaTRAddetto()
		{
			S_Controls.Collections.S_Object s_id_tr= new S_Object();
			s_id_tr.ParameterName = "p_id_tr";
			s_id_tr.DbType = CustomDBType.Integer;
			s_id_tr.Direction = ParameterDirection.Input;
			s_id_tr.Index = 0;
			s_id_tr.Value = 0;

			S_Controls.Collections.S_Object s_addetto_id= new S_Object();
			s_addetto_id.ParameterName = "p_addetto_id";
			s_addetto_id.DbType = CustomDBType.Integer;
			s_addetto_id.Direction = ParameterDirection.Input;
			s_addetto_id.Index = 1;
			s_addetto_id.Value = itemId;
				
				
			string S_Operazione="Delall";
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			_SCollection.Add(s_id_tr);
			_SCollection.Add(s_addetto_id);
			TheSite.Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
			_Addetti.ExecuteUpdatePMPAdd_TR(_SCollection,S_Operazione);
		}
		
		private void UpdateTR_Addetti(DataTable UpdateDataTable)
		{
			foreach (DataRow dr in UpdateDataTable.Rows)
			{
				if (dr["Operazione"] != DBNull.Value)
				{
					Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
					try
					{
						S_Controls.Collections.S_ControlsCollection _SColl = new S_Controls.Collections.S_ControlsCollection();

						S_Controls.Collections.S_Object s_id_tr = new S_Controls.Collections.S_Object();
						s_id_tr.ParameterName = "p_Id_tr";
						s_id_tr.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
						s_id_tr.Direction = ParameterDirection.Input;
						s_id_tr.Index = 0;
						s_id_tr.Value = Convert.ToInt32(dr["id_tr"].ToString());

						S_Controls.Collections.S_Object s_addetto_id = new S_Controls.Collections.S_Object();
						s_addetto_id.ParameterName = "p_addetto_Id";
						s_addetto_id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
						s_addetto_id.Direction = ParameterDirection.Input;
						s_addetto_id.Index = 1;
						s_addetto_id.Value = itemId ;		

						_SColl.Add(s_id_tr);
						_SColl.Add(s_addetto_id);


						if (dr["Operazione"].ToString() == "I" )
							_Addetti.ExecuteUpdatePMPAdd_TR(_SColl,"Insert");
						else 
							_Addetti.ExecuteUpdatePMPAdd_TR(_SColl,"Delete");
						
						
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
			}
		}
	}
		
} 
		

		


	

	
		

	
