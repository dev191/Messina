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

namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per PmpFrequenza.
	/// </summary>
	public class EditRichiedenti : System.Web.UI.Page
	{
		protected S_Controls.S_TextBox txtsFrequenza_des;
		protected S_Controls.S_TextBox txtsFrequenza;	
		protected Csy.WebControls.DataPanel PanelRicerca;		
		protected S_Controls.S_Button btnsRicerca;		
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;	
		protected WebControls.PageTitle PageTitle1;
		int itemId = 0;
		public static int FunId=0;
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		protected S_Controls.S_Button btnsSalva;
		protected S_Controls.S_Button btnsElimina;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected System.Web.UI.WebControls.RequiredFieldValidator rvfdescrizione;
		public static string HelpLink = string.Empty;
		protected S_Controls.S_TextBox txtsNome;
		protected S_Controls.S_TextBox txtsCognome;
		protected S_Controls.S_ComboBox cmbsGruppo;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected S_Controls.S_TextBox txtstelefono;
		protected S_Controls.S_TextBox txtsemail;
		protected S_Controls.S_TextBox txtsstanza;
		protected System.Web.UI.WebControls.RegularExpressionValidator REVtxtsemail;
		protected System.Web.UI.WebControls.RequiredFieldValidator rvfnome;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvcognome;
		protected S_Controls.S_ComboBox CmbProgetto;
		TheSite.Gestione.Richiedenti _fp;


		
		private void Page_Load(object sender, System.EventArgs e)
		{
			FunId = Int32.Parse(Request["FunId"]);			
			
			string id_tipo = "";
			if (Request["ItemId"] != null) 
			{
				itemId = Int32.Parse(Request["ItemId"]);				
			}
			if (!Page.IsPostBack )
			{				
				BindProgetti();	
				if (itemId != 0) 
				{

					DataSet _MyDs = new DataSet();
					Classi.ClassiAnagrafiche.Richiedenti _Richiedenti = new TheSite.Classi.ClassiAnagrafiche.Richiedenti();
					_MyDs = _Richiedenti.GetSingleData(itemId); 
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
//						this.txtsdescrizione .Text= (string) _Dr["DESCRIZIONE"];

						if (_Dr["cognome"] != DBNull.Value)
							this.txtsCognome.Text = (string) _Dr["cognome"];
						
						if (_Dr["nome"] != DBNull.Value)
							this.txtsNome.Text = _Dr["nome"].ToString();						
					
						if (_Dr["phone"] != DBNull.Value)
							this.txtstelefono.Text = _Dr["phone"].ToString();	
						
						if (_Dr["email"] != DBNull.Value)
							this.txtsemail.Text = _Dr["email"].ToString();
	
						if (_Dr["stanza"] != DBNull.Value)
							this.txtsstanza.Text = _Dr["stanza"].ToString();	

						if (_Dr["progetto"] != DBNull.Value)
							this.CmbProgetto.SelectedValue= _Dr["progetto"].ToString();	

						this.lblOperazione.Text = "Modifica Richiedente";
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?');");				
						//Classi.ClassiAnagrafiche.TipoManutenzione  _TipoManutenzione = new GStazioni.Classi.ClassiAnagrafiche.TipoManutenzione();

						id_tipo = _Dr["id_tipo"].ToString();

					}

				}
				else
				{
					this.lblOperazione.Text = "Inserimento Richiedente";
					this.btnsElimina.Visible = false;					
				}				
				if (Request["TipoOper"] == "read")				
					AbilitaControlli(false);


				this.getAllGruppo(id_tipo);

				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Richiedenti)
				{
					_fp = (TheSite.Gestione.Richiedenti) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); }
				}
			
			}

		private void getAllGruppo(string id_tipo)
		{
			this.cmbsGruppo.Items.Clear();
			Classi.ClassiAnagrafiche.Richiedenti_tipo _Richiedenti = new TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo();
				
			DataSet _MyDs = _Richiedenti.GetAllData().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{				
				this.cmbsGruppo.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
				_MyDs.Tables[0], "descrizione","id", "- Selezionare una Gruppo -", "");
				this.cmbsGruppo.DataTextField = "descrizione";
				this.cmbsGruppo.DataValueField = "id";
				if(id_tipo!="")
					this.cmbsGruppo.SelectedValue=id_tipo;
				this.cmbsGruppo.DataBind();
			}			


		}

		private void BindProgetti()
		{
			
			this.CmbProgetto.Items.Clear();
		
			TheSite.Classi.Progetti _Prog = new TheSite.Classi.Progetti();
						
			DataSet _MyDs = _Prog.GetData();			
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				CmbProgetto.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "id_progetto", "- Selezionare un Progetto -", "0");				
				this.CmbProgetto.DataTextField ="descrizione";
				this.CmbProgetto.DataValueField  ="id_progetto";
				this.CmbProgetto.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Progetto  -";
				this.CmbProgetto.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
						
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
		private void AbilitaControlli(bool enabled)
		{
			CmbProgetto.Enabled= enabled;
			this.txtsCognome.Enabled = enabled;
			this.txtsNome.Enabled = enabled;			
			this.btnsSalva.Enabled=enabled;
			this.btnsElimina.Enabled=enabled;			
			this.cmbsGruppo.Enabled=enabled;
			this.txtstelefono.Enabled=enabled;
			this.txtsemail.Enabled=enabled;
			this.txtsstanza.Enabled=enabled;
			this.lblOperazione.Text = "Visualizzazione Richiedente";
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
			this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
			this.btnsElimina.Click += new System.EventHandler(this.btnsElimina_Click);
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsSalva_Click(object sender, System.EventArgs e)
		{	
			Classi.ClassiAnagrafiche.Richiedenti _Richiedenti_0= new Classi.ClassiAnagrafiche.Richiedenti();
			this.txtsNome.DBDefaultValue ="%";
			this.txtsCognome.DBDefaultValue="%";
			this.CmbProgetto.DBDefaultValue=DBNull.Value;
			S_ControlsCollection _SCollection_0 = new S_ControlsCollection();
		
			S_Controls.Collections.S_Object s_p_nome= new S_Object();
			s_p_nome.ParameterName = "p_nome";
			s_p_nome.DbType=CustomDBType.VarChar;
			s_p_nome.Direction = ParameterDirection.Input;
			s_p_nome.Index = 0;
			s_p_nome.Value = txtsNome.Text;

			_SCollection_0.Add(s_p_nome);
			
			S_Controls.Collections.S_Object s_p_cognome= new S_Object();
			s_p_cognome.ParameterName = "p_cognome";
			s_p_cognome.DbType=CustomDBType.VarChar;
			s_p_cognome.Direction = ParameterDirection.Input;
			s_p_cognome.Index = 1;
			s_p_cognome.Value = txtsCognome.Text;						
			
			_SCollection_0.Add(s_p_cognome);

			S_Controls.Collections.S_Object s_p_idGruppo= new S_Object();
			s_p_idGruppo.ParameterName = "p_idGruppo";
			s_p_idGruppo.DbType=CustomDBType.Integer;
			s_p_idGruppo.Direction = ParameterDirection.Input;
			s_p_idGruppo.Index = 2;
			s_p_idGruppo.Value = cmbsGruppo.SelectedValue;						
			
			_SCollection_0.Add(s_p_idGruppo);

			S_Controls.Collections.S_Object s_p_idProgetto= new S_Object();
			s_p_idProgetto.ParameterName = "p_progetto";
			s_p_idProgetto.DbType=CustomDBType.Integer;
			s_p_idProgetto.Direction = ParameterDirection.Input;
			s_p_idProgetto.Index = 3;
			s_p_idProgetto.Value = CmbProgetto.SelectedValue;						
			
			_SCollection_0.Add(s_p_idProgetto);


			DataSet _MyDs = _Richiedenti_0.CheckData(_SCollection_0).Copy();

		if (_MyDs.Tables[0].Rows.Count == 0 || itemId != 0 )
			{
				this.txtsCognome.DBDefaultValue = DBNull.Value;
				this.txtsNome.DBDefaultValue = DBNull.Value;
				if (CmbProgetto.SelectedValue == "0")
				//this.txtsCognome.Text=this.txtsCognome.Text.Trim();
				//this.txtsNome.Text= this.txtsNome.Text.Trim();			
				this.cmbsGruppo.DBDefaultValue=DBNull.Value;
				this.txtstelefono.DBDefaultValue=DBNull.Value;
				this.txtsemail.DBDefaultValue=DBNull.Value;
				this.txtsstanza.DBDefaultValue=DBNull.Value;

				int i_RowsAffected = 0;
				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
				_SCollection.AddItems(this.PanelEdit.Controls);

			S_Controls.Collections.S_Object s_p_idProgetto1= new S_Object();
			s_p_idProgetto1.ParameterName = "p_progetto";
			s_p_idProgetto1.DbType=CustomDBType.Integer;
			s_p_idProgetto1.Direction = ParameterDirection.Input;
			s_p_idProgetto1.Index = 3;
			if (CmbProgetto.SelectedValue == "0")
				s_p_idProgetto1.Value=DBNull.Value;
			else
				s_p_idProgetto1.Value = CmbProgetto.SelectedValue;						
			
			_SCollection.Add(s_p_idProgetto1);


				try
				{
					if (itemId == 0)
					{	
						Classi.ClassiAnagrafiche.Richiedenti _Richiedenti = new TheSite.Classi.ClassiAnagrafiche.Richiedenti();
						i_RowsAffected = _Richiedenti.Add(_SCollection);
					}
					else
					{
						Classi.ClassiAnagrafiche.Richiedenti _Richiedenti= new TheSite.Classi.ClassiAnagrafiche.Richiedenti();
						i_RowsAffected = _Richiedenti.Update(_SCollection,itemId);
					}

					if ( i_RowsAffected > 0 )
					{
						Server.Transfer("Richiedenti.aspx");
					}
				}
				catch (Exception ex)
				{				
					string s_Err =  ex.Message.ToString().ToUpper();
					PanelMess.ShowError(s_Err, true);
				}			
			}
			else
			{
				PanelMess.ShowError("Richiedente esistente", true);
			}
		}

		private void btnsElimina_Click(object sender, System.EventArgs e)
		{
			try
			{	
				this.txtsCognome.DBDefaultValue = DBNull.Value;
				this.txtsNome.DBDefaultValue = DBNull.Value;
				this.txtstelefono.DBDefaultValue=DBNull.Value;
				this.txtsemail.DBDefaultValue=DBNull.Value;
				this.txtsstanza.DBDefaultValue=DBNull.Value;
				this.cmbsGruppo.DBDefaultValue=DBNull.Value;
				int i_RowsAffected = 0;
				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
				_SCollection.AddItems(this.PanelEdit.Controls);		
				S_Controls.Collections.S_Object s_p_idProgetto1= new S_Object();
				s_p_idProgetto1.ParameterName = "p_progetto";
				s_p_idProgetto1.DbType=CustomDBType.Integer;
				s_p_idProgetto1.Direction = ParameterDirection.Input;
				s_p_idProgetto1.Index = 3;
				if (CmbProgetto.SelectedValue == "0")
					s_p_idProgetto1.Value=DBNull.Value;
				else
					s_p_idProgetto1.Value = CmbProgetto.SelectedValue;						
			
				_SCollection.Add(s_p_idProgetto1);

				Classi.ClassiAnagrafiche.Richiedenti _Richiedenti = new TheSite.Classi.ClassiAnagrafiche.Richiedenti();
				i_RowsAffected = _Richiedenti.Delete(_SCollection,itemId);
				if ( i_RowsAffected == -1 )
					Server.Transfer("Richiedenti.aspx");					
			}
			catch (Exception ex)
			{			
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}
		}

		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
//			Response.Redirect((String) ViewState["UrlReferrer"]);
			Server.Transfer("Richiedenti.aspx");
				
		}
	}
}	
