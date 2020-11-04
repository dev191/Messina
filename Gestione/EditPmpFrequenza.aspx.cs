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
using MyCollection;


namespace TheSite.Gestione
{	
	/// <summary>
	/// Descrizione di riepilogo per EditPmpFrequenza
	/// </summary>
	public class EditPmpFrequenza : System.Web.UI.Page
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
		protected S_Controls.S_TextBox txtsfrequenza;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvfrequenza;
		protected System.Web.UI.WebControls.RequiredFieldValidator rvffrequenza_des;
		protected S_Controls.S_TextBox txtsfrequenza_des;
		protected S_Controls.S_ComboBox cmbsTipoCadenza;
		protected S_Controls.S_ComboBox cmbsGiorni;
		protected S_Controls.S_ComboBox cmbsMesi;
		protected S_Controls.S_ComboBox cmbsAnni;
		protected S_Controls.S_ComboBox cmbsCalcola;
		protected System.Web.UI.WebControls.Repeater rpserv;
		protected System.Web.UI.HtmlControls.HtmlTableRow r1;
		protected System.Web.UI.HtmlControls.HtmlTableRow r2;
		protected System.Web.UI.HtmlControls.HtmlTableRow r3;
		protected System.Web.UI.HtmlControls.HtmlTableCell r4;
		PmpFrequenza _fp;
	
		
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
					Classi.ClassiAnagrafiche.PmpFrequenza _PmpFrequenza = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza();
					_MyDs = _PmpFrequenza.GetSingleData(itemId); 
						
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						this.txtsfrequenza.Text= (string) _Dr["FREQUENZA"];

						if (_Dr["FREQUENZA_DES"] != DBNull.Value)
							this.txtsfrequenza_des.Text = (string) _Dr["FREQUENZA_DES"];
									
						if (_Dr["mese_std"] != DBNull.Value)
							this.cmbsTipoCadenza.SelectedValue = _Dr["mese_std"].ToString();						
															
						if (_Dr["N_GIORNI"] != DBNull.Value)
							this.cmbsGiorni.SelectedValue =  _Dr["N_GIORNI"].ToString();

						if (_Dr["N_MESI"] != DBNull.Value)
							this.cmbsMesi.SelectedValue = (string) _Dr["N_MESI"].ToString();
									
						if (_Dr["N_ANNI"] != DBNull.Value)
							this.cmbsAnni.SelectedValue = (string) _Dr["N_ANNI"].ToString();

						if (_Dr["CALCOLA"] != DBNull.Value)
							this.cmbsCalcola.SelectedValue = (string) _Dr["CALCOLA"].ToString();
															
						this.lblOperazione.Text = "Modifica Frequenza: " + this.txtsfrequenza.Text;
						this.lblFirstAndLast.Visible = true;						
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");				
						//						Classi.ClassiAnagrafiche.TipoManutenzione  _TipoManutenzione = new TheSite.Classi.ClassiAnagrafiche.TipoManutenzione();
						lblFirstAndLast.Text = _PmpFrequenza.GetFirstAndLastUser(_Dr);

						LoadServizi(_Dr["mese_std"].ToString(),_Dr["FREQUENZA"].ToString());

						

					}
				}
				else
				{
					
					LoadServizi("0","0");

					this.lblOperazione.Text = "Inserimento Frequenza";
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;					
				}				
				if (Request["TipoOper"] == "read")
				{
					AbilitaControlli(false);
					this.lblOperazione.Text = "Visualizzazione Frequenza: " + this.txtsfrequenza.Text;
				}
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.PmpFrequenza) 
				{
					_fp = (TheSite.Gestione.PmpFrequenza) Context.Handler;
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
			this.txtsfrequenza.Enabled = enabled;
			this.txtsfrequenza_des.Enabled = enabled;
			this.cmbsTipoCadenza.Enabled = enabled;
			this.cmbsGiorni.Enabled = enabled;
			this.cmbsMesi.Enabled = enabled;
			this.cmbsAnni.Enabled = enabled;
			this.cmbsCalcola.Enabled = enabled;
			this.btnsElimina.Enabled=enabled;
			this.btnsSalva.Enabled=enabled;
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
			int i_RowsAffected = 0;
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			_SCollection.AddItems(this.PanelEdit.Controls);

			try
			{
				if (itemId == 0)
				{			
					Classi.ClassiAnagrafiche.PmpFrequenza _PmpFrequenza = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza();
					i_RowsAffected = _PmpFrequenza.Add(_SCollection);
					_PmpFrequenza.DeleteFreqStag(i_RowsAffected);
					if(cmbsTipoCadenza.SelectedValue=="1")
						SaveStag(i_RowsAffected);
					
				}
				else
				{
					Classi.ClassiAnagrafiche.PmpFrequenza _PmpFrequenza = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza();
					i_RowsAffected = _PmpFrequenza.Update(_SCollection,itemId);
					_PmpFrequenza.DeleteFreqStag(i_RowsAffected);
					if(cmbsTipoCadenza.SelectedValue =="1")
						SaveStag(i_RowsAffected);
				}

				if ( i_RowsAffected == -11)
				{
					Classi.SiteJavaScript.msgBox(this.Page,"Tipo Frequenza già presente.");
				}
				else
				{
					//Response.Redirect((String) ViewState["UrlReferrer"]);	
					Server.Transfer("PmpFrequenza.aspx");	
				}
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}			
		}

		private void SaveStag(int Freq)
		{
			
			
			foreach (RepeaterItem item in rpserv.Items)
			{
				string id_servizio=((HtmlInputHidden)item.FindControl("idser")).Value;
				string Mese=((DropDownList)item.FindControl("drmese")).SelectedValue;
				if(Mese=="0")	continue;
				Classi.ClassiAnagrafiche.PmpFrequenza _PmpFrequenza = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza();
				 _PmpFrequenza.InsertFreqStag(Freq,txtsfrequenza.Text,int.Parse(Mese),int.Parse(id_servizio));  
			}
		}

		private void btnsElimina_Click(object sender, System.EventArgs e)
		{
			try
			{	
				int i_RowsAffected = 0;
				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
				_SCollection.AddItems(this.PanelEdit.Controls);			
				Classi.ClassiAnagrafiche.PmpFrequenza _PmpFrequenza = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza();
				_PmpFrequenza.DeleteFreqStag(itemId);
				i_RowsAffected = _PmpFrequenza.Delete(_SCollection,itemId);
				if ( i_RowsAffected == -1 )
					//Response.Redirect((String) ViewState["UrlReferrer"]);	
					Server.Transfer("PmpFrequenza.aspx");	
			}
			catch (Exception ex)
			{			
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}
		}

		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			//Response.Redirect((String) ViewState["UrlReferrer"]);
			Server.Transfer("PmpFrequenza.aspx");	
		}

		private void LoadServizi(string cadenza,string frequenza)
		{
		    TheSite.Classi.ClassiDettaglio.Servizi s =new TheSite.Classi.ClassiDettaglio.Servizi();
			DataSet ds=s.GetServizi();
 			rpserv.DataSource=ds.Tables[0];
			rpserv.DataBind(); 

			cmbsTipoCadenza.Attributes.Add("onclick","SetVisible();");
			Page.RegisterStartupScript("visib","<script language='javascript'>SetVisible();</script>"); 
						
				Classi.ClassiAnagrafiche.PmpFrequenza _PmpFrequenza= new Classi.ClassiAnagrafiche.PmpFrequenza();
				ds=_PmpFrequenza.GetDataStag(frequenza); 
				//rpserv.Visible =true;
				foreach (RepeaterItem item in rpserv.Items)
				{
					HtmlInputHidden ids=(HtmlInputHidden)item.FindControl("idser");
					
					foreach(DataRow riga in ds.Tables[0].Rows)
					{
						if(riga["servizi_id"].ToString()==ids.Value)
						{
							DropDownList cmb=(DropDownList)item.FindControl("drmese");
							cmb.SelectedValue =riga["idmese"].ToString();
							break;
						}
					}
				}

						
		

		}
		
	}
	
}
	
	

