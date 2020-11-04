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
	/// Descrizione di riepilogo per EditMisura.
	/// </summary>
	public class EditMisura : System.Web.UI.Page
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
			protected S_Controls.S_TextBox txtCodMisura;
			protected S_Controls.S_TextBox txtDescMisura;

			protected System.Web.UI.WebControls.RequiredFieldValidator rfvCodMisura;
			protected System.Web.UI.WebControls.RequiredFieldValidator rfvDescMisura;
			TheSite.Gestione.UnitaMisura _fp;
	
	
	
			private void Page_Load(object sender, System.EventArgs e)
			{		
	
				FunId = Int32.Parse(Request["FunId"]);			
			
			
				if (Request["ItemId"] != null) 
				{
					itemId = Int32.Parse(Request["ItemId"]);				
				}
				if (!Page.IsPostBack )
				{
					//BindUnita();
							
					if (itemId != 0) 
					{
						DataSet _MyDs = new DataSet();
						Classi.ClassiAnagrafiche.UnitaMisura _UnitaMisura = new TheSite.Classi.ClassiAnagrafiche.UnitaMisura();
						_MyDs = _UnitaMisura.GetSingleData(itemId); 
					
						if (_MyDs.Tables[0].Rows.Count == 1)
						{					
							DataRow _Dr = _MyDs.Tables[0].Rows[0];
						
							this.txtCodMisura.Text= (string) _Dr["ucodice"];					
						
							if (_Dr["udescrizione"] != DBNull.Value)
								this.txtDescMisura.Text = (string) _Dr["udescrizione"].ToString();
						
							this.lblOperazione.Text = "Modifica Unità di Misura: " + this.txtCodMisura.Text;
							this.lblFirstAndLast.Visible = true;						
							this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");	
							lblFirstAndLast.Text = _UnitaMisura.GetFirstAndLastUser(_Dr);

						}
					
					}
					else
					{
						this.lblOperazione.Text = "Inserimento Unità di Misura";
						this.lblFirstAndLast.Visible = false;
						this.btnsElimina.Visible = false;
				
					}				
					if (Request["TipoOper"] == "read")	
					{
						AbilitaControlli(false);
						this.lblOperazione.Text = "Visualizzazione Unità di Misura: " + this.txtCodMisura.Text;
					}
					ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
					if(Context.Handler is TheSite.Gestione.UnitaMisura) 
					{
						_fp = (TheSite.Gestione.UnitaMisura) Context.Handler;
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
	

			
	
			private void AbilitaControlli(bool enabled)
			{
				this.txtCodMisura.Enabled = enabled;
				this.txtDescMisura.Enabled = enabled;		
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
					Classi.ClassiAnagrafiche.UnitaMisura _UnitaMisura = new TheSite.Classi.ClassiAnagrafiche.UnitaMisura();
								
					this.txtCodMisura.DBDefaultValue = DBNull.Value;
					this.txtDescMisura.DBDefaultValue = DBNull.Value;
				
					this.txtCodMisura.Text=this.txtCodMisura.Text.Trim();	
					this.txtDescMisura.Text= this.txtDescMisura.Text.Trim();		
					int i_RowsAffected = 0;

					S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
					
					_SCollection.AddItems(this.PanelEdit.Controls);
					
					i_RowsAffected = _UnitaMisura.Delete(_SCollection, itemId);

					switch (i_RowsAffected)
					{
						case -1:
						Server.Transfer("UnitaMisura.aspx?FunId =" + FunId);
						break;
						case -5:
						PanelMess.ShowMessage("Impossibile eliminare l'unita di misura in quanto legata ad un materiale");
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

			private void btnsSalva_Click(object sender, System.EventArgs e)
			{	
			
				this.txtCodMisura.DBDefaultValue = DBNull.Value;
				this.txtDescMisura.DBDefaultValue = DBNull.Value;					
				this.txtCodMisura.Text=this.txtCodMisura.Text.Trim();	
				this.txtDescMisura.Text= this.txtDescMisura.Text.Trim();
			
				int i_RowsAffected = 0;
				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
					
				_SCollection.AddItems(this.PanelEdit.Controls);
			
				try
				{
					if (itemId == 0)
					{			
						Classi.ClassiAnagrafiche.UnitaMisura _UnitaMisura = new TheSite.Classi.ClassiAnagrafiche.UnitaMisura();
						i_RowsAffected = _UnitaMisura.Add(_SCollection);
					}
					else
					{
						Classi.ClassiAnagrafiche.UnitaMisura _UnitaMisura = new TheSite.Classi.ClassiAnagrafiche.UnitaMisura();
						i_RowsAffected =  _UnitaMisura.Update(_SCollection,itemId);
					}

					if (i_RowsAffected==-11)
					{
						Classi.SiteJavaScript.msgBox(this.Page,"L'unità di misura con stesso codice é già stata inserita");				
					
					}
					else
					{
						Server.Transfer("UnitaMisura.aspx?FunId =" + FunId);					
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
				Server.Transfer("UnitaMisura.aspx");
			}
		
		
		}
	
	}
	
		


		

		

	

