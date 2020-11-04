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
	/// Descrizione di riepilogo per EditMateriale.
	/// </summary>

		public class EditMateriale : System.Web.UI.Page
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
			protected S_Controls.S_TextBox txtCodMateriale;
			protected S_Controls.S_TextBox txtDescMateriale;
			//protected S_Controls.S_TextBox txtPrezzoIntero;
			protected System.Web.UI.WebControls.TextBox txtPrezzoIntero;
			protected System.Web.UI.WebControls.TextBox txtPrezzoDecimale;
			//protected S_Controls.S_TextBox txtPrezzoDecimale;
			protected S_Controls.S_ComboBox cmbUnita;
			protected System.Web.UI.WebControls.RequiredFieldValidator rfvCodMat;
			protected System.Web.UI.WebControls.RequiredFieldValidator rfvDescrizione;
			protected System.Web.UI.WebControls.RequiredFieldValidator rfvUnita;
			protected System.Web.UI.WebControls.RegularExpressionValidator regIntero;
			protected System.Web.UI.WebControls.RegularExpressionValidator regDecimale;
			TheSite.Gestione.ListaMateriali _fp;
	
	
	
			private void Page_Load(object sender, System.EventArgs e)
			{		
	
				FunId = Int32.Parse(Request["FunId"]);			
			
			
				if (Request["ItemId"] != null) 
				{
					itemId = Int32.Parse(Request["ItemId"]);				
				}
				if (!Page.IsPostBack )
				{
					BindUnita();
							
					if (itemId != 0) 
					{
						DataSet _MyDs = new DataSet();
						Classi.ClassiAnagrafiche.ListaMateriali _ListaMateriali = new TheSite.Classi.ClassiAnagrafiche.ListaMateriali();
						_MyDs = _ListaMateriali.GetSingleData(itemId); 
					
						if (_MyDs.Tables[0].Rows.Count == 1)
						{					
							DataRow _Dr = _MyDs.Tables[0].Rows[0];
						
							this.txtCodMateriale.Text= (string) _Dr["mcodice"];					
						
							if (_Dr["mdescrizione"] != DBNull.Value)
								this.txtDescMateriale.Text = (string) _Dr["mdescrizione"].ToString();
						
							if (_Dr["unitaid"] != DBNull.Value)
								this.cmbUnita.SelectedValue= _Dr["unitaid"].ToString();

							if (_Dr["mprezzo"] != DBNull.Value)
							{
								txtPrezzoIntero.Text =  Classi.Function.GetTypeNumber(_Dr["mprezzo"],Classi.NumberType.Intero).ToString();				
								txtPrezzoDecimale.Text =  Classi.Function.GetTypeNumber(_Dr["mprezzo"],Classi.NumberType.Decimale).ToString();
							}
						
							this.lblOperazione.Text = "Modifica Materiale: " + this.txtCodMateriale.Text;
							this.lblFirstAndLast.Visible = true;						
							this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");	
							lblFirstAndLast.Text = _ListaMateriali.GetFirstAndLastUser(_Dr);

						}
					
					}
					else
					{
						this.lblOperazione.Text = "Inserimento Materiale";
						//BindUnita();
						this.lblFirstAndLast.Visible = false;
						this.btnsElimina.Visible = false;
				
					}				
					if (Request["TipoOper"] == "read")	
					{
						AbilitaControlli(false);
						this.lblOperazione.Text = "Visualizzazione Materiale: " + this.txtCodMateriale.Text;
					}
					ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
					if(Context.Handler is TheSite.Gestione.ListaMateriali) 
					{
						_fp = (TheSite.Gestione.ListaMateriali) Context.Handler;
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
	

			
			private void BindUnita()
			{
			
				this.cmbUnita.Items.Clear();
		
				Classi.ClassiDettaglio.UnitaMisura _UnitaMisura = new TheSite.Classi.ClassiDettaglio.UnitaMisura(HttpContext.Current.User.Identity.Name); 	
				DataSet _MyDs = _UnitaMisura.GetData().Copy();
			  
				if (_MyDs.Tables[0].Rows.Count > 0)
				{				
					this.cmbUnita.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
						_MyDs.Tables[0], "DESCRIZIONE_COD","IDUNITA", "- Selezionare Unità di Misura -", "0");
					this.cmbUnita.DataTextField = "DESCRIZIONE_COD";
					this.cmbUnita.DataValueField = "IDUNITA";
					this.cmbUnita.DataBind();
				}			
	
			}
		
			private void AbilitaControlli(bool enabled)
			{
				this.txtCodMateriale.Enabled = enabled;
				this.txtDescMateriale.Enabled = enabled;
				txtPrezzoIntero.Enabled = enabled;
				txtPrezzoDecimale.Enabled = enabled;
				this.cmbUnita.Enabled = enabled;
		
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
					Classi.ClassiAnagrafiche.ListaMateriali _ListaMateriali = new TheSite.Classi.ClassiAnagrafiche.ListaMateriali();
								
					this.txtCodMateriale.DBDefaultValue = DBNull.Value;
					this.txtDescMateriale.DBDefaultValue = DBNull.Value;
					this.cmbUnita.DBDefaultValue = "-1";
					
					this.txtCodMateriale.Text=this.txtCodMateriale.Text.Trim();	
					this.txtDescMateriale.Text= this.txtDescMateriale.Text.Trim();
					this.cmbUnita.DBDefaultValue = "-1";
			
					int i_RowsAffected = 0;

					S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
					//Prezzo
					S_Controls.Collections.S_Object s_prezzo = new S_Object();
					s_prezzo.ParameterName = "p_prezzo";
					s_prezzo.DbType = CustomDBType.Double;
					s_prezzo.Direction = ParameterDirection.Input;
					s_prezzo.Index = 3 ;
					s_prezzo.Value = Double.Parse(txtPrezzoIntero.Text.Trim() + "," + txtPrezzoDecimale.Text.Trim());
					_SCollection.Add(s_prezzo);

				
					_SCollection.AddItems(this.PanelEdit.Controls);
					
					i_RowsAffected = _ListaMateriali.Delete(_SCollection, itemId);

					if ( i_RowsAffected == -1 )					
						Server.Transfer("ListaMateriali.aspx?FunId =" + FunId);
				}
				catch (Exception ex)
				{				
					string s_Err =  ex.Message.ToString().ToUpper();
					PanelMess.ShowError(s_Err, true);
				}	
			}

			private void btnsSalva_Click(object sender, System.EventArgs e)
			{	
			
				this.txtCodMateriale.DBDefaultValue = DBNull.Value;
				this.txtDescMateriale.DBDefaultValue = DBNull.Value;
				this.cmbUnita.DBDefaultValue = "-1";
					
				this.txtCodMateriale.Text=this.txtCodMateriale.Text.Trim();	
				this.txtDescMateriale.Text= this.txtDescMateriale.Text.Trim();
				this.cmbUnita.DBDefaultValue = "-1";
			
				int i_RowsAffected = 0;
				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
				//Prezzo
				S_Controls.Collections.S_Object s_prezzo = new S_Object();
				s_prezzo.ParameterName = "p_prezzo";
				s_prezzo.DbType = CustomDBType.Double;
				s_prezzo.Direction = ParameterDirection.Input;
				s_prezzo.Index = 3 ;
				s_prezzo.Value = Double.Parse(txtPrezzoIntero.Text.Trim() + "," + txtPrezzoDecimale.Text.Trim());
				_SCollection.Add(s_prezzo);

				
				_SCollection.AddItems(this.PanelEdit.Controls);
			
				try
				{
					if (itemId == 0)
					{			
						Classi.ClassiAnagrafiche.ListaMateriali _ListaMateriali = new TheSite.Classi.ClassiAnagrafiche.ListaMateriali();
						i_RowsAffected = _ListaMateriali.Add(_SCollection);
					}
					else
					{
						Classi.ClassiAnagrafiche.ListaMateriali _ListaMateriali = new TheSite.Classi.ClassiAnagrafiche.ListaMateriali();
						i_RowsAffected =  _ListaMateriali.Update(_SCollection,itemId);
					}

					if (i_RowsAffected==-11)
					{
						Classi.SiteJavaScript.msgBox(this.Page,"Materiale con stesso codice é stato già inserito");				
					
					}
					else
					{
						Server.Transfer("ListaMateriali.aspx?FunId =" + FunId);					
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
				Server.Transfer("ListaMateriali.aspx");
			}
		
		
		}
	
	}
	
		


		

		

	
