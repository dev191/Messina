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
	/// Descrizione di riepilogo per EditLivelli.
	/// </summary>
	public class EditLivelli : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected S_Controls.S_TextBox txtsCodice;
		protected S_Controls.S_TextBox txtsDescrizione;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		protected S_Controls.S_Button btnsSalva;
		protected S_Controls.S_Button btnsElimina;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvCodice;

		int itemId = 0;
		int FunId = 0;
		TheSite.Gestione.Livelli _fp;
		DataSet _MyDs = new DataSet();
		S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
		protected System.Web.UI.WebControls.RangeValidator RVPrezzo2;
		protected System.Web.UI.WebControls.CompareValidator CVPrezzo1;
		protected System.Web.UI.WebControls.CompareValidator CVPrezzo2;
		protected System.Web.UI.WebControls.TextBox txtsPrezzo;
		protected System.Web.UI.WebControls.TextBox txtsPrezzoDecimali;
		Classi.ClassiAnagrafiche.Livelli _Livelli = new TheSite.Classi.ClassiAnagrafiche.Livelli();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			FunId = Int32.Parse(Request["FunId"]);			
			
			if (Request["ItemId"] != null) 
				itemId = Int32.Parse(Request["ItemId"]);				
			
			if (!Page.IsPostBack )
			{			
				if (itemId != 0) 
				{
					_MyDs = _Livelli.GetSingleData(itemId); 
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						
						this.txtsCodice.Text= (string) _Dr["codicelivello"];					
												
						if (_Dr["descrizionelivello"] != DBNull.Value)
							this.txtsDescrizione.Text= _Dr["descrizionelivello"].ToString();
											
						if (_Dr["prezzounitario"] != DBNull.Value)
						{
							txtsPrezzo.Text =  Classi.Function.GetTypeNumber(_Dr["prezzounitario"],Classi.NumberType.Intero).ToString();				
							txtsPrezzoDecimali.Text =  Classi.Function.GetTypeNumber(_Dr["prezzounitario"],Classi.NumberType.Decimale).ToString();
						}	
						
						this.lblOperazione.Text = "Modifica Livello: " + this.txtsCodice.Text;
						this.lblFirstAndLast.Visible = true;			
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");	
						lblFirstAndLast.Text = _Livelli.GetFirstAndLastUser(_Dr);
					}
				}
				else
				{
					txtsPrezzo.Text="0";
					txtsPrezzoDecimali.Text="00";
					this.lblOperazione.Text = "Inserimento Livello";
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;
				}				
				if (Request["TipoOper"] == "read")	
				{
					AbilitaControlli(false);
					this.lblOperazione.Text = "Visualizzazione Livello: " + this.txtsCodice.Text;
				}
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Livelli) 
				{
					_fp = (TheSite.Gestione.Livelli) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
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
			this.txtsDescrizione.Enabled = enabled;
			this.txtsPrezzo.Enabled = enabled;
			this.txtsPrezzoDecimali.Enabled = enabled;
			this.btnsSalva.Enabled=enabled;
			this.btnsElimina.Enabled=enabled;
		}

		private void btnsElimina_Click(object sender, System.EventArgs e)
		{
			try
			{				
				this.txtsCodice.DBDefaultValue = DBNull.Value;
				this.txtsDescrizione.DBDefaultValue = DBNull.Value;
				int i_RowsAffected = 0;

						   
				_SCollection.AddItems(this.PanelEdit.Controls);	
							
				//Prezzo
				S_Controls.Collections.S_Object s_Prezzo = new S_Object();
				s_Prezzo.ParameterName = "p_Prezzo";
				s_Prezzo.DbType = CustomDBType.Double;
				s_Prezzo.Direction = ParameterDirection.Input;
				s_Prezzo.Index = 3;
				s_Prezzo.Value = Double.Parse(txtsPrezzo.Text + "," + txtsPrezzoDecimali.Text);
				_SCollection.Add(s_Prezzo);

				i_RowsAffected = _Livelli.Delete(_SCollection, itemId);

				switch (i_RowsAffected)
				{
					case-1:
						Server.Transfer("Livelli.aspx");
						break;
					case-5:
						PanelMess.ShowError("Impossibile eliminare in quanto ci sono Addetti assocciati", true);
						break;
					case-7:
						PanelMess.ShowError("Impossibile eliminare in quanto ci sono percentuali assocciate", true);
						break;
				}
					
				
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}	
		}

		private void btnsSalva_Click(object sender, System.EventArgs e)
		{
			this.txtsCodice.DBDefaultValue = DBNull.Value;
			this.txtsDescrizione.DBDefaultValue = DBNull.Value;

			this.txtsCodice.Text = this.txtsCodice.Text.Trim();
			this.txtsDescrizione.Text = this.txtsDescrizione.Text.Trim();

			_SCollection.AddItems(this.PanelEdit.Controls);	
							
			//Prezzo
			S_Controls.Collections.S_Object s_Prezzo = new S_Object();
			s_Prezzo.ParameterName = "p_Prezzo";
			s_Prezzo.DbType = CustomDBType.Double;
			s_Prezzo.Direction = ParameterDirection.Input;
			s_Prezzo.Index = 3;
			s_Prezzo.Value = Double.Parse(txtsPrezzo.Text + "," + txtsPrezzoDecimali.Text);
			_SCollection.Add(s_Prezzo);

			int i_RowsAffected = 0;
			try
			{
				if (itemId == 0)
					i_RowsAffected = _Livelli.Add(_SCollection);  
				else
					i_RowsAffected =  _Livelli.Update(_SCollection,itemId);
				
				if ( i_RowsAffected > 0 && i_RowsAffected!=-11)
					Server.Transfer("Livelli.aspx");					
				else
					Classi.SiteJavaScript.msgBox(this.Page,"Il Livello  é stato già inserito");
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}	


		}

		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Livelli.aspx");
		}
	}
}
