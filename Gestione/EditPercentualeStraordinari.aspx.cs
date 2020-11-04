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
	/// Descrizione di riepilogo per EditPercentualeStraordinari.
	/// </summary>
	public class EditPercentualeStraordinari : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected S_Controls.S_TextBox txtsCodice;
		protected S_Controls.S_TextBox txtsPercentuale;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		protected S_Controls.S_Button btnsSalva;
		protected S_Controls.S_Button btnsElimina;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected System.Web.UI.WebControls.RequiredFieldValidator RFVLivello;
		protected S_Controls.S_ComboBox cmbsLivello;

		int itemId = 0;
		int FunId = 0;
		TheSite.Gestione.PercentualiStraordinari _fp;
		DataSet _MyDs = new DataSet();
		S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvCodice;
		protected System.Web.UI.WebControls.CompareValidator CVPercentuale;
		protected System.Web.UI.WebControls.RangeValidator RVPercentuale;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPercentuale;
		Classi.ClassiAnagrafiche.PercentualiStraordinari _PercentualiStraordinari = new TheSite.Classi.ClassiAnagrafiche.PercentualiStraordinari();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			FunId = Int32.Parse(Request["FunId"]);			
			
			if (Request["ItemId"] != null) 
				itemId = Int32.Parse(Request["ItemId"]);
			
			if (!Page.IsPostBack )
            {	
				BindLivello();
				if (itemId != 0) 
				{
					_MyDs = _PercentualiStraordinari.GetSingleData(itemId); 
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						
						if (_Dr["codicestraordinario"] != DBNull.Value)
							this.txtsCodice.Text= (string) _Dr["codicestraordinario"];					
												
						if (_Dr["percentuale"] != DBNull.Value)
							this.txtsPercentuale.Text= _Dr["percentuale"].ToString();
											
						if (_Dr["livelli_id"] != DBNull.Value)
						{
							this.cmbsLivello.SelectedValue= _Dr["livelli_id"].ToString();
						}	
						
						this.lblOperazione.Text = "Modifica Percentuale Straordinari: " + this.txtsCodice.Text;
						this.lblFirstAndLast.Visible = true;			
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");	
						lblFirstAndLast.Text = _PercentualiStraordinari.GetFirstAndLastUser(_Dr);
					}
				}
				else
				{
					this.lblOperazione.Text = "Inserimento Percentuale Straordinari";
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;
				}				
				if (Request["TipoOper"] == "read")	
				{
					AbilitaControlli(false);
					this.lblOperazione.Text = "Visualizzazione Percentuale Straordinari: " + this.txtsCodice.Text;
				}
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.PercentualiStraordinari) 
				{
					_fp = (TheSite.Gestione.PercentualiStraordinari) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
				}	
			}
		}

		private void BindLivello()
		{
			Classi.ClassiAnagrafiche.Livelli _Livelli= new TheSite.Classi.ClassiAnagrafiche.Livelli();
			this.cmbsLivello .Items.Clear();
			_MyDs = _Livelli.GetData().Copy();
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsLivello.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "codicelivello", "id", "- Selezionare un Livello -","-1");
				this.cmbsLivello.DataTextField = "codicelivello";
				this.cmbsLivello.DataValueField = "id";
				this.cmbsLivello.DataBind();
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
			this.txtsCodice.Enabled = enabled;
			this.txtsPercentuale.Enabled = enabled;
			this.cmbsLivello.Enabled=enabled;
			this.btnsSalva.Enabled=enabled;
			this.btnsElimina.Enabled=enabled;
		}

		private void btnsSalva_Click(object sender, System.EventArgs e)
		{
			this.txtsCodice.DBDefaultValue = DBNull.Value;
			this.txtsPercentuale.DBDefaultValue = 0;
			//this.cmbsLivello.DBDefaultValue= 0;

			this.txtsCodice.Text = this.txtsCodice.Text.Trim();
			this.txtsPercentuale.Text = this.txtsPercentuale.Text.Trim();

			_SCollection.AddItems(this.PanelEdit.Controls);	
							
			int i_RowsAffected = 0;
			try
			{
				if (itemId == 0)
					i_RowsAffected = _PercentualiStraordinari.Add(_SCollection);  
				else
					i_RowsAffected =  _PercentualiStraordinari.Update(_SCollection,itemId);
				
				if ( i_RowsAffected > 0 && i_RowsAffected!=-11)
					Server.Transfer("PercentualiStraordinari.aspx");					
				else
					Classi.SiteJavaScript.msgBox(this.Page,"La _Percentuale  é stato già inserita");
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
				this.txtsPercentuale.DBDefaultValue = DBNull.Value;
				this.cmbsLivello.DBDefaultValue=0;
				int i_RowsAffected = 0;

						   
				_SCollection.AddItems(this.PanelEdit.Controls);	
			
				i_RowsAffected = _PercentualiStraordinari.Delete(_SCollection, itemId);

				if ( i_RowsAffected == -1 )					
					Server.Transfer("PercentualiStraordinari.aspx");
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}	
		}

		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("PercentualiStraordinari.aspx");
		}

	}
}
