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

namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per PmpFrequenza.
	/// </summary>
	public class EditRichiedenti_tipo : System.Web.UI.Page
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
		protected S_Controls.S_TextBox txtsnote;
		protected System.Web.UI.WebControls.RequiredFieldValidator rvfdescrizione;
		public static string HelpLink = string.Empty;
		TheSite.Gestione.Richiedenti_tipo _fp;


		
		private void Page_Load(object sender, System.EventArgs e)
		{
			FunId = Int32.Parse(Request["FunId"]);			
			
			if (Request["ItemId"] != null) 
			{
				itemId = Int32.Parse(Request["ItemId"]);				
			}
			if (!Page.IsPostBack )
			{					
				if (itemId != 0) 
				{
					DataSet _MyDs = new DataSet();
					Classi.ClassiAnagrafiche.Richiedenti_tipo _Richiedenti_tipo = new TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo();
					_MyDs = _Richiedenti_tipo.GetSingleData(itemId); 
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
//						this.txtsdescrizione .Text= (string) _Dr["DESCRIZIONE"];

						if (_Dr["DESCRIZIONE"] != DBNull.Value)
							this.txtsdescrizione .Text = (string) _Dr["DESCRIZIONE"];
						
						if (_Dr["NOTE"] != DBNull.Value)
							this.txtsnote .Text = _Dr["NOTE"].ToString();						
					
													
						this.lblOperazione.Text = "Modifica Tipo Richiedente";
						this.lblFirstAndLast.Visible = true;						
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?');");				
						//Classi.ClassiAnagrafiche.TipoManutenzione  _TipoManutenzione = new TheSite.Classi.ClassiAnagrafiche.TipoManutenzione();
						lblFirstAndLast.Text = _Richiedenti_tipo .GetFirstAndLastUser(_Dr);

					}
				}
				else
				{
					this.lblOperazione.Text = "Inserimento Tipo Richiedente";
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;					
				}				
				if (Request["TipoOper"] == "read")				
					AbilitaControlli(false);
				    ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Richiedenti_tipo)
				{
						_fp = (TheSite.Gestione.Richiedenti_tipo) Context.Handler;
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
			this.txtsnote.Enabled = enabled;			
			this.btnsSalva.Enabled=enabled;
			this.btnsElimina.Enabled=enabled;			
			this.lblOperazione.Text = "Visualizzazione Tipo Richiedente";
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
			this.txtsnote.DBDefaultValue = DBNull.Value;
		
			this.txtsdescrizione.Text=this.txtsdescrizione.Text.Trim();
			this.txtsnote.Text= this.txtsnote.Text.Trim();			

			int i_RowsAffected = 0;
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			_SCollection.AddItems(this.PanelEdit.Controls);

			try
			{
				if (itemId == 0)
				{			
					Classi.ClassiAnagrafiche.Richiedenti_tipo _Richiedenti_tipo = new TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo();
					i_RowsAffected = _Richiedenti_tipo.Add(_SCollection);					
				}
				else
				{
					Classi.ClassiAnagrafiche.Richiedenti_tipo _Richiedenti_tipo= new TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo();
					i_RowsAffected = _Richiedenti_tipo.Update(_SCollection,itemId);
				}
				
				if(i_RowsAffected==-11)
				{
					Classi.SiteJavaScript.msgBox(this.Page,"Tipo Richiedente già inserito nel DataBase.");
				}

				if ( i_RowsAffected > 0 )
				{
					Server.Transfer("Richiedenti_tipo.aspx");
				}
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
				this.txtsdescrizione.DBDefaultValue = DBNull.Value;
				this.txtsnote.DBDefaultValue = DBNull.Value;							
				int i_RowsAffected = 0;
				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
				_SCollection.AddItems(this.PanelEdit.Controls);			
				Classi.ClassiAnagrafiche.Richiedenti_tipo _Richiedenti_tipo = new TheSite.Classi.ClassiAnagrafiche.Richiedenti_tipo();
				i_RowsAffected = _Richiedenti_tipo.Delete(_SCollection,itemId);
				if ( i_RowsAffected == -1 )
					Server.Transfer("Richiedenti_tipo.aspx");					
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
			Server.Transfer("Richiedenti_tipo.aspx");
				
		}
	}
}	
	
	
	
	

		
		
		

