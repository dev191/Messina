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


namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per EditTipoIntervento.
	/// </summary>
	public class EditTipoIntervento : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected Csy.WebControls.MessagePanel PanelMess;		
		protected System.Web.UI.WebControls.Panel PanelEdit;
		protected S_Controls.S_Button btnsSalva;
		protected S_Controls.S_Button btnsElimina;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvEqstd;
		protected S_Controls.S_TextBox txtsdescrizionebreve;
		protected S_Controls.S_TextBox txtsdescrizione;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		int itemId = 0;
		int FunId = 0;		
		TipoIntervento _fp;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			FunId = Int32.Parse(Request["FunId"]);			

			if (Request["itemId"] != null) 
			{
				itemId = Int32.Parse(Request["itemId"]);				
			}

			if (!Page.IsPostBack )
			{					
				if (itemId != 0) 
				{					
					Classi.ClassiAnagrafiche.TipoIntervento _TipoIntervento = new TheSite.Classi.ClassiAnagrafiche.TipoIntervento();
				
					DataSet _MyDs = _TipoIntervento.GetSingleData(itemId).Copy();									
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						this.txtsdescrizionebreve.Text= (string) _Dr["descrizione_breve"];
						if (_Dr["Descrizione"] != DBNull.Value)
							this.txtsdescrizione.Text = (string) _Dr["descrizione"];					
						
						lblFirstAndLast.Text=_TipoIntervento.GetFirstAndLastUser(_Dr);

						this.lblOperazione.Text = "Modifica Tipo Intervento: " + this.txtsdescrizionebreve.Text;
						this.lblFirstAndLast.Visible = true;												
						this.btnsElimina.Visible = true;
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
					
					}		
				}
				else
				{
					this.lblOperazione.Text = "Inserimento Tipo Intervento";
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;					
				}
				
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.TipoIntervento) 
				{
					_fp = (TheSite.Gestione.TipoIntervento) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
				}	
				
				if (Request["TipoOper"] == "read")
				{
					txtsdescrizione.Enabled=false;
					txtsdescrizionebreve.Enabled=false;
					btnsElimina.Enabled=false;
					btnsSalva.Enabled=false;
				}
				else
				{
					txtsdescrizione.Enabled=true;
					txtsdescrizionebreve.Enabled=true;
					btnsElimina.Enabled=true;
					btnsSalva.Enabled=true;
				}

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
			Classi.ClassiAnagrafiche.TipoIntervento _TipoIntervento = new TheSite.Classi.ClassiAnagrafiche.TipoIntervento();				
			
			this.txtsdescrizionebreve.DBDefaultValue = DBNull.Value;
			this.txtsdescrizionebreve.Text=this.txtsdescrizionebreve.Text.Trim().Replace("'","`");
			this.txtsdescrizione.DBDefaultValue = DBNull.Value;
			this.txtsdescrizione.Text=this.txtsdescrizione.Text.Trim().Replace("'","`");
			int i_RowsAffected = 0;

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			_SCollection.AddItems(this.PanelEdit.Controls);

			try
			{
				if (itemId == 0)
					i_RowsAffected = _TipoIntervento.Add(_SCollection);
				else
					i_RowsAffected = _TipoIntervento.Update(_SCollection, itemId);							
					
				if (i_RowsAffected==-11)
				{
					Classi.SiteJavaScript.msgBox(this.Page,"Il tipo Intervento immesso é stato già inserito");									
				}
				else
				{
					Server.Transfer("TipoIntervento.aspx");				
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
			Server.Transfer("TipoIntervento.aspx");
		}

		private void btnsElimina_Click(object sender, System.EventArgs e)
		{
			Classi.ClassiAnagrafiche.TipoIntervento _TipoIntervento = new TheSite.Classi.ClassiAnagrafiche.TipoIntervento();				
			
			this.txtsdescrizionebreve.DBDefaultValue = DBNull.Value;
			this.txtsdescrizionebreve.Text=this.txtsdescrizionebreve.Text.Trim();
			this.txtsdescrizione.DBDefaultValue = DBNull.Value;
			this.txtsdescrizione.Text=this.txtsdescrizione.Text.Trim();
			int i_RowsAffected = 0;

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			_SCollection.AddItems(this.PanelEdit.Controls);

			try
			{
				
				i_RowsAffected = _TipoIntervento.Delete(_SCollection, itemId);												
				Server.Transfer("TipoIntervento.aspx");				
			}

			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
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
	}
}
