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
using StampaRapportiPdf.Classi;

namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per EditServizi.
	/// </summary>
	public class EditServizi : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvSettore;
		protected S_Controls.S_ComboBox cmbsSettore;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvCodice;
		protected S_Controls.S_TextBox txtsCodice;
		protected S_Controls.S_TextBox txtsDescrizione;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPercentuale;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		protected S_Controls.S_Button btnsSalva;
		protected S_Controls.S_Button btnsElimina;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected S_Controls.S_TextBox txtsNote;

		int itemId = 0;
		int FunId = 0;
		TheSite.Gestione.Servizi _fp;
		DataSet _MyDs = new DataSet();
		S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
		Classi.ClassiDettaglio.Servizi _Servizi = new Classi.ClassiDettaglio.Servizi();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			FunId = Int32.Parse(Request["FunId"]);			
			
			if (Request["ItemId"] != null) 
				itemId = Int32.Parse(Request["ItemId"]);
			
			if (!Page.IsPostBack )
			{	
				BindSettore();
				if (itemId != 0) 
				{
					_MyDs = _Servizi.GetSingleData(itemId); 
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						
						if (_Dr["descrizione"] != DBNull.Value)
							this.txtsDescrizione.Text= (string) _Dr["descrizione"];					
												
						if (_Dr["note"] != DBNull.Value)
							this.txtsNote.Text= _Dr["note"].ToString();

						if (_Dr["codice"] != DBNull.Value)
							this.txtsCodice.Text= _Dr["codice"].ToString();
											
						if (_Dr["settore_id"] != DBNull.Value)
							this.cmbsSettore.SelectedValue= _Dr["settore_id"].ToString();
						
						this.lblOperazione.Text = "Modifica Servizio: " + this.txtsCodice.Text;
						this.lblFirstAndLast.Visible = true;			
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");	
						lblFirstAndLast.Text = _Servizi.GetFirstAndLastUser(_Dr);
					}
				}
				else
				{
					this.lblOperazione.Text = "Inserimento Servizi";
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;
				}				
				if (Request["TipoOper"] == "read")	
				{
					AbilitaControlli(false);
					this.lblOperazione.Text = "Visualizzazione Servizio: " + this.txtsCodice.Text;
				}
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Servizi) 
				{
					_fp = (TheSite.Gestione.Servizi) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
				}	
			}
		}
		private void BindSettore()
		{
			Classi.ClassiAnagrafiche.Settori _Settori =  new TheSite.Classi.ClassiAnagrafiche.Settori();
			this.cmbsSettore .Items.Clear();
			DataSet  _MyDs =_Settori.GetData().Copy();
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsSettore.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "settore", "idsettore", "- Selezionare un Settore -","-1");
				this.cmbsSettore.DataTextField = "settore";
				this.cmbsSettore.DataValueField = "idsettore";
				this.cmbsSettore.DataBind();
			}
		}

		private void AbilitaControlli(bool enabled)
		{
			this.txtsCodice.Enabled = enabled;
			this.txtsDescrizione.Enabled = enabled;
			this.txtsNote.Enabled = enabled;
			this.cmbsSettore.Enabled=enabled;
			this.btnsSalva.Enabled=enabled;
			this.btnsElimina.Enabled=enabled;
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
			this.txtsCodice.DBDefaultValue = DBNull.Value;
			this.txtsDescrizione.DBDefaultValue =  DBNull.Value;
			this.txtsNote.DBDefaultValue =  DBNull.Value;
			this.cmbsSettore.DBDefaultValue= -1;

			this.txtsCodice.Text = this.txtsCodice.Text.Trim();
			this.txtsDescrizione.Text = this.txtsDescrizione.Text.Trim();
			this.txtsNote.Text = this.txtsNote.Text.Trim();

			_SCollection.AddItems(this.PanelEdit.Controls);	
							
			int i_RowsAffected = 0;
			try
			{
				if (itemId == 0)
					i_RowsAffected = _Servizi.Add(_SCollection);  
				else
					i_RowsAffected =  _Servizi.Update(_SCollection,itemId);
				
				if ( i_RowsAffected > 0 && i_RowsAffected!=-11)
					Server.Transfer("Servizi.aspx");					
				else
					Classi.SiteJavaScript.msgBox(this.Page,"Il servizio  é stato già inserita");
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}	

		}

		private void btnsElimina_Click(object sender, System.EventArgs e)
		{
			try
			{				
				this.txtsCodice.DBDefaultValue = DBNull.Value;
				this.txtsDescrizione.DBDefaultValue = DBNull.Value;
				this.txtsNote.DBDefaultValue = DBNull.Value;
				this.cmbsSettore.DBDefaultValue=-1;
				int i_RowsAffected = 0;

						   
				_SCollection.AddItems(this.PanelEdit.Controls);	
			
				i_RowsAffected = _Servizi.Delete(_SCollection, itemId);

				if ( i_RowsAffected == -1 )					
					Server.Transfer("Servizi.aspx");
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}	
		}

		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Servizi.aspx");
		}
	}
}
