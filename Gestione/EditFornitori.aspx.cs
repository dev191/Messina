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
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using S_Controls;




namespace TheSite.Gestione
{	
	/// <summary>
	/// Descrizione di riepilogo per EditAddetti
	/// </summary>
	public class EditFornitori : System.Web.UI.Page
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
		protected S_Controls.S_TextBox txtsindirizzo;
		protected S_Controls.S_TextBox txtstelefono;
		protected S_Controls.S_ComboBox cmbsprov_res;
		protected S_Controls.S_ComboBox cmbscom_res;
		protected S_Controls.S_TextBox txtsFornitore;
		protected S_Controls.S_TextBox txtsfax;
		protected S_Controls.S_TextBox txtsemail;
		protected S_Controls.S_TextBox txtspiva;
		protected S_Controls.S_TextBox txtscap;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvFornitore;
		protected System.Web.UI.WebControls.RegularExpressionValidator REVtxtsemail;
		TheSite.Gestione.Fornitori _fp;
	
	
	
		private void Page_Load(object sender, System.EventArgs e)
		{		
	
			FunId = Int32.Parse(Request["FunId"]);			
			
			
			if (Request["ItemId"] != null) 
			{
				itemId = Int32.Parse(Request["ItemId"]);				
			}

			if (!Page.IsPostBack )
			{
				BindProvince1();
							
				if (itemId != 0) 
				{
					DataSet _MyDs = new DataSet();
					Classi.ClassiAnagrafiche.Fornitori _Fornitori = new TheSite.Classi.ClassiAnagrafiche.Fornitori();
					_MyDs = _Fornitori.GetSingleData(itemId); 
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						
						this.txtsFornitore.Text= (string) _Dr["FORNITORE"];					
						
												
						if (_Dr["PROVINCIA_ID"] != DBNull.Value)
							this.cmbsprov_res.SelectedValue= _Dr["PROVINCIA_ID"].ToString();
							BindComuni1();
						
						if (_Dr["COMUNE_ID"] != DBNull.Value)
							this.cmbscom_res .SelectedValue = _Dr["COMUNE_ID"].ToString();
														
						if (_Dr["INDIRIZZO"] != DBNull.Value)
							this.txtsindirizzo.Text = (string) _Dr["INDIRIZZO"].ToString();

						if (_Dr["TELEFONO"] != DBNull.Value)
							this.txtstelefono.Text = (string) _Dr["TELEFONO"].ToString();
						
						if (_Dr["FAX"] != DBNull.Value)
							this.txtsfax.Text = (string) _Dr["FAX"].ToString();
						
						if (_Dr["CAP"] != DBNull.Value)
							this.txtscap.Text = (string) _Dr["CAP"].ToString();

						if (_Dr["IVA"] != DBNull.Value)
							this.txtspiva.Text= (string)_Dr["IVA"].ToString();
						
						if (_Dr["EMAIL"] != DBNull.Value)
							this.txtsemail.Text =(string) _Dr["EMAIL"].ToString();
						
						this.lblOperazione.Text = "Modifica Fornitore: " + this.txtsFornitore.Text;
						this.lblFirstAndLast.Visible = true;			
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");	
						lblFirstAndLast.Text = _Fornitori.GetFirstAndLastUser(_Dr);

					}
					
				}
				else
				{
					this.lblOperazione.Text = "Inserimento Fornitore";
					
					BindComuni1();
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;
				
				}				
				if (Request["TipoOper"] == "read")	
				{
					AbilitaControlli(false);
					this.lblOperazione.Text = "Visualizzazione Fornitore: " + this.txtsFornitore.Text;
				}
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Fornitori) 
				{
					_fp = (TheSite.Gestione.Fornitori) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
				}	
			}
			}

		public MyCollection.clMyCollection _Contenitore
		{ 
			get 
			{
				if(this.ViewState["mioContenitore"]!=null)
					return (MyCollection.clMyCollection)this.ViewState["mioContenitore"];
				else
					return new MyCollection.clMyCollection();
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

		private void AbilitaControlli(bool enabled)
		{
				this.txtsFornitore.Enabled = enabled;
				this.txtsindirizzo.Enabled = enabled;
				this.txtstelefono.Enabled = enabled;
				this.cmbsprov_res.Enabled = enabled;
				this.cmbscom_res.Enabled=enabled;
				this.txtspiva.Enabled = enabled;
				this.txtsfax.Enabled = enabled;
				this.txtsemail.Enabled = enabled;
				this.txtscap.Enabled = enabled;
				this.btnsSalva.Enabled=enabled;
				this.btnsElimina.Enabled=enabled;
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
			this.cmbsprov_res.SelectedIndexChanged += new System.EventHandler(this.cmbsprov_res_SelectedIndexChanged);
			this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
			this.btnsElimina.Click += new System.EventHandler(this.btnsElimina_Click);
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void btnsElimina_Click(object sender, System.EventArgs e)
		{
			try
			{
				Classi.ClassiAnagrafiche.Fornitori _Fornitori = new TheSite.Classi.ClassiAnagrafiche.Fornitori();
								
				this.txtsFornitore.DBDefaultValue = DBNull.Value;
				this.txtsindirizzo.DBDefaultValue = DBNull.Value;
				this.txtstelefono.DBDefaultValue = DBNull.Value;
				this.txtspiva.DBDefaultValue = DBNull.Value;
				this.txtsfax.DBDefaultValue = DBNull.Value;
				this.txtscap.DBDefaultValue = DBNull.Value;
				this.txtsemail.DBDefaultValue = DBNull.Value;
				this.cmbsprov_res.DBDefaultValue = "-1";
				this.cmbscom_res.DBDefaultValue = "-1";

				int i_RowsAffected = 0;

				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			   
				_SCollection.AddItems(this.PanelEdit.Controls);	
				string city = this.cmbscom_res.SelectedItem.Text;
				//city
				S_Controls.Collections.S_Object s_Idcity = new S_Object();
				s_Idcity.ParameterName = "p_city";
				s_Idcity.DbType = CustomDBType.VarChar;
				s_Idcity.Direction = ParameterDirection.Input;
				s_Idcity.Index = 9;
				s_Idcity.Size = 30;
				s_Idcity.Value = city;
				_SCollection.Add(s_Idcity);


				
				i_RowsAffected = _Fornitori.Delete(_SCollection, itemId);

				if ( i_RowsAffected == -1 )					
					Server.Transfer("Fornitori.aspx");
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}	
		}

		private void btnsSalva_Click(object sender, System.EventArgs e)
		{	
			
			this.txtsFornitore.DBDefaultValue = DBNull.Value;
			this.txtsindirizzo.DBDefaultValue = DBNull.Value;
			this.txtstelefono.DBDefaultValue = DBNull.Value;
			this.txtspiva.DBDefaultValue = DBNull.Value;
			this.txtsfax.DBDefaultValue = DBNull.Value;
			this.txtscap.DBDefaultValue = DBNull.Value;
			this.txtsemail.DBDefaultValue = DBNull.Value;
			this.cmbsprov_res.DBDefaultValue = "-1";
			this.cmbscom_res.DBDefaultValue = "-1";
			
			this.txtsFornitore.Text=this.txtsFornitore.Text.Trim();			
			this.txtstelefono.Text= this.txtstelefono.Text.Trim();
			this.txtsindirizzo.Text=this.txtsindirizzo.Text.Trim();
			this.txtspiva.Text = this.txtspiva.Text.Trim();
			this.txtsfax.Text = this.txtsfax.Text.Trim();
			this.txtscap.Text = this.txtscap.Text.Trim();
			this.txtsemail.Text = this.txtsemail.Text.Trim();
				
					
			string city = this.cmbscom_res.SelectedItem.Text;
			//city
			S_Controls.Collections.S_Object s_Idcity = new S_Object();
			s_Idcity.ParameterName = "p_city";
			s_Idcity.DbType = CustomDBType.VarChar;
			s_Idcity.Direction = ParameterDirection.Input;
			s_Idcity.Index = 9;
			s_Idcity.Size = 30;
			s_Idcity.Value = city;
	
            	
		
			
			int i_RowsAffected = 0;
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			_SCollection.AddItems(this.PanelEdit.Controls);
			_SCollection.Add (s_Idcity);
		
			try
			{
				if (itemId == 0)
				{			
					Classi.ClassiAnagrafiche.Fornitori _Fornitori = new TheSite.Classi.ClassiAnagrafiche.Fornitori();
					i_RowsAffected = _Fornitori.Add(_SCollection);
				}
				else
				{
					Classi.ClassiAnagrafiche.Fornitori _Fornitori = new TheSite.Classi.ClassiAnagrafiche.Fornitori();
					i_RowsAffected =  _Fornitori.Update(_SCollection,itemId);
				}

				if ( i_RowsAffected > 0 && i_RowsAffected!=-11)
				{
					Server.Transfer("Fornitori.aspx");					
				}
				else
				{
					Classi.SiteJavaScript.msgBox(this.Page,"Il Fornitore é stato già inserito");
				
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
			Server.Transfer("Fornitori.aspx");
		}
		
		private void cmbsprov_res_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbsprov_res.SelectedIndex >0)
				BindComuni1();
			else
			{
				this.cmbscom_res .Items.Clear();}
		}
	}
} 
		

		

	
