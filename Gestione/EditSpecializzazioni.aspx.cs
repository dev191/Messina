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
	public class EditSpecializzazioni : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected S_Controls.S_TextBox txtsdescrizione;
		protected System.Web.UI.WebControls.RequiredFieldValidator rvfdescrizione;
		public static string HelpLink = string.Empty;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvServizio;
		protected S_Controls.S_ComboBox cmbsServizio;
		TheSite.Gestione.Specializzazioni _fp;


		
		private void Page_Load(object sender, System.EventArgs e)
		{
			FunId = Int32.Parse(Request["FunId"]);			
			
			if (Request["ItemId"] != null) 
			{
				itemId = Int32.Parse(Request["ItemId"]);				
			}
			if (!Page.IsPostBack )
			{					
				BindServizi();
				if (itemId != 0) 
				{
					DataSet _MyDs = new DataSet();
					Classi.ClassiAnagrafiche.Addetti _Addetti= new TheSite.Classi.ClassiAnagrafiche.Addetti();
					_MyDs = _Addetti.GetSingleDataTR(itemId); 
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						this.txtsdescrizione .Text= (string) _Dr["DESCRIZIONE"];
						if (_Dr["servizi_id"] != DBNull.Value)
							this.cmbsServizio.SelectedValue= _Dr["servizi_id"].ToString();
												
						this.lblOperazione.Text = "Modifica Specializzazione";
						this.lblFirstAndLast.Visible = true;						
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?');");				

						lblFirstAndLast.Text = _Addetti .GetFirstAndLastUser(_Dr);
					}
				}
				else
				{
					this.lblOperazione.Text = "Inserimento Specializzazione";
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;					
				}				
				if (Request["TipoOper"] == "read")				
					AbilitaControlli(false);
				    ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Specializzazioni)
				{
						_fp = (TheSite.Gestione.Specializzazioni) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); }
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
			this.txtsdescrizione.Enabled = enabled;
			this.cmbsServizio.Enabled = enabled;		
			this.btnsSalva.Enabled=enabled;
			this.btnsElimina.Enabled = enabled;
			this.lblOperazione.Text = "Visualizzazione Specializzazione";
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
			this.txtsdescrizione.DBDefaultValue = DBNull.Value;
			this.cmbsServizio.DBDefaultValue=0;

			this.txtsdescrizione.Text=this.txtsdescrizione.Text.Trim();

			string tr_id = this.txtsdescrizione.Text;
			//city
			S_Controls.Collections.S_Object s_Idtr_id = new S_Object();
			s_Idtr_id.ParameterName = "p_tr_id";
			s_Idtr_id.DbType = CustomDBType.VarChar;
			s_Idtr_id.Direction = ParameterDirection.Input;
			s_Idtr_id.Index = 1;
			s_Idtr_id.Size = 50;
			s_Idtr_id.Value = tr_id;
			
			int i_RowsAffected = 0;
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			_SCollection.AddItems(this.PanelEdit.Controls);
			_SCollection.Add(s_Idtr_id);

			try
			{
				if (itemId == 0)
				{			
					Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
					i_RowsAffected = _Addetti.ExecuteUpdateTR(_SCollection,"Insert",itemId);
				}
				else
				{
					Classi.ClassiAnagrafiche.Addetti _Addetti= new TheSite.Classi.ClassiAnagrafiche.Addetti();
					i_RowsAffected = _Addetti.ExecuteUpdateTR(_SCollection,"Update",itemId);
				}

				if ( i_RowsAffected > 0 && i_RowsAffected!=-11)
				{
					Server.Transfer("Specializzazioni.aspx");					
				}
				else
				{
					Classi.SiteJavaScript.msgBox(this.Page,"La Specializzazione é stata già inserita");
				
				}
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}			
		}

		private void BindServizi()
		{
			
			this.cmbsServizio.Items.Clear();
		
			Classi.ClassiDettaglio.Servizi _Servizi = new TheSite.Classi.ClassiDettaglio.Servizi();
				
			DataSet _MyDs = _Servizi.GetServizi().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "id", "- Selezionare un Servizio -", "");
				this.cmbsServizio.DataTextField = "descrizione";
				this.cmbsServizio.DataValueField = "id";
				this.cmbsServizio.DataBind();
			}			
		}

		private void btnsElimina_Click(object sender, System.EventArgs e)
		{
			try
			{	
				this.txtsdescrizione.DBDefaultValue = DBNull.Value;
				string tr_id = this.txtsdescrizione.Text;
				//city
				S_Controls.Collections.S_Object s_Idtr_id = new S_Object();
				s_Idtr_id.ParameterName = "p_tr_id";
				s_Idtr_id.DbType = CustomDBType.VarChar;
				s_Idtr_id.Direction = ParameterDirection.Input;
				s_Idtr_id.Index = 1;
				s_Idtr_id.Size = 50;
				s_Idtr_id.Value = tr_id;						
				int i_RowsAffected = 0;
				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
				_SCollection.AddItems(this.PanelEdit.Controls);
				_SCollection.Add(s_Idtr_id);
				Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
				i_RowsAffected = _Addetti.ExecuteUpdateTR(_SCollection,"Delete",itemId);
				switch (i_RowsAffected)
				{
					case -1:
						Server.Transfer("Specializzazioni.aspx");
						break;
					case -5:
						PanelMess.ShowMessage("Impossibile eliminare in quanto legata ad un addetto");
						break;
					case -6:
						PanelMess.ShowMessage("Impossibile eliminare in quanto legata ad una Procedure di Manutenzione Programmata");
						break;
					default:
						PanelMess.ShowMessage("Impossibile eliminare");
						break;
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
//			Response.Redirect((String) ViewState["UrlReferrer"]);
			Server.Transfer("Specializzazioni.aspx");
				
		}
	}
}	
	
	
	
	

		
		
		

