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
	public class EditEqstd : System.Web.UI.Page
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
		protected S_Controls.S_TextBox txtseq_std;
		protected S_Controls.S_TextBox txtsdescrizione;
		protected S_Controls.S_ComboBox cmbservizio;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvEqstd;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		TheSite.Gestione.Eqstd _fp;
	
	
	
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
					Classi.ClassiAnagrafiche.Eqstd _Eqstd = new TheSite.Classi.ClassiAnagrafiche.Eqstd();
					_MyDs = _Eqstd.GetSingleData(itemId); 
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						
						this.txtseq_std.Text= (string) _Dr["EQ_STD"];					
						
						if (_Dr["DESCRIZIONE"] != DBNull.Value)
							this.txtsdescrizione.Text = (string) _Dr["DESCRIZIONE"].ToString();
						
						if (_Dr["SERVIZIO_ID"] != DBNull.Value)
							this.cmbservizio.SelectedValue= _Dr["SERVIZIO_ID"].ToString();
				
						
						this.lblOperazione.Text = "Modifica Standard Apparecchiatura: " + this.txtsdescrizione.Text;
						this.lblFirstAndLast.Visible = true;						
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");	
						lblFirstAndLast.Text = _Eqstd.GetFirstAndLastUser(_Dr);

					}
					
				}
				else
				{
					this.lblOperazione.Text = "Inserimento Standard Apparecchiatura";
					//BindServizi();
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;
				
				}				
				if (Request["TipoOper"] == "read")	
				{
					AbilitaControlli(false);
					this.lblOperazione.Text = "Visualizzazione Standard Apparecchiatura: " + this.txtsdescrizione.Text;
				}
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Eqstd) 
				{
					_fp = (TheSite.Gestione.Eqstd) Context.Handler;
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
	
		private void BindServizi()
		{			
			this.cmbservizio.Items.Clear();
		
			Classi.ClassiDettaglio.Servizi _Servizi = new TheSite.Classi.ClassiDettaglio.Servizi(HttpContext.Current.User.Identity.Name); 	
			DataSet _MyDs = _Servizi.GetData().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{				
				this.cmbservizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE","IDSERVIZIO", "- Selezionare un Servizio -", "0");
				this.cmbservizio.DataTextField = "DESCRIZIONE";
				this.cmbservizio.DataValueField = "IDSERVIZIO";
				this.cmbservizio.DataBind();
			}			
				
		}			
		
		private void AbilitaControlli(bool enabled)
		{
			this.txtseq_std.Enabled = enabled;
			this.txtsdescrizione.Enabled = enabled;		
			this.cmbservizio.Enabled = enabled;
		
			this.btnsSalva.Enabled=enabled;
			this.btnsElimina.Enabled = enabled;
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
		private void btnsElimina_Click(object sender, System.EventArgs e)
		{
			try
			{
				Classi.ClassiAnagrafiche.Eqstd _Eqstd = new TheSite.Classi.ClassiAnagrafiche.Eqstd();
								
				this.txtseq_std.DBDefaultValue = DBNull.Value;
				this.txtsdescrizione.DBDefaultValue = DBNull.Value;
				this.cmbservizio.DBDefaultValue = "-1";
			
				int i_RowsAffected = 0;

				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			   
				_SCollection.AddItems(this.PanelEdit.Controls);			

				
				i_RowsAffected = _Eqstd.Delete(_SCollection, itemId);

				if ( i_RowsAffected == -1 )					
					Server.Transfer("Eqstd.aspx");
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}	
		}

		private void btnsSalva_Click(object sender, System.EventArgs e)
		{	
			
			this.txtseq_std.DBDefaultValue = DBNull.Value;
			this.txtsdescrizione.DBDefaultValue = DBNull.Value;
			this.cmbservizio.DBDefaultValue = "-1";
					
			this.txtseq_std.Text=this.txtseq_std.Text.Trim();			
			this.txtsdescrizione.Text= this.txtsdescrizione.Text.Trim();
			
			int i_RowsAffected = 0;
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			_SCollection.AddItems(this.PanelEdit.Controls);
			
			try
			{
				if (itemId == 0)
				{			
					Classi.ClassiAnagrafiche.Eqstd _Eqstd = new TheSite.Classi.ClassiAnagrafiche.Eqstd();
					i_RowsAffected = _Eqstd.Add(_SCollection);
				}
				else
				{
					Classi.ClassiAnagrafiche.Eqstd _Eqstd = new TheSite.Classi.ClassiAnagrafiche.Eqstd();
					i_RowsAffected =  _Eqstd.Update(_SCollection,itemId);
				}

				if (i_RowsAffected==-11)
				{
					Classi.SiteJavaScript.msgBox(this.Page,"Lo Standard Apparecchiatura é stato già inserito");				
					
				}
				else
				{
					Server.Transfer("Eqstd.aspx");					
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
			Server.Transfer("Eqstd.aspx");
		}
		
		
	}
	
	}
	
		


		

		

	
