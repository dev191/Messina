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
using StampaRapportiPdf.Classi;

namespace TheSite.Gestione
{	
	/// <summary>
	/// Descrizione di riepilogo per EditPmp
	/// </summary>
	public class EditPmp : System.Web.UI.Page    // System.Web.UI.Page
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
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvcognome;
		
		protected S_Controls.S_TextBox txtsdescrizione;
		protected S_Controls.S_TextBox txtsunitshour;
		protected S_Controls.S_ComboBox cmbseq_std;
		protected S_Controls.S_ComboBox cmbspmp;
		protected S_Controls.S_ComboBox cmbstr;
		protected S_Controls.S_TextBox txtspmp_id;
		protected String s_Pmp_id ="";
		protected String s_Pmp_id1 ="";
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.RangeValidator RFVeqstd;
		protected System.Web.UI.WebControls.RangeValidator RfvPmpFreq;
		protected System.Web.UI.WebControls.RangeValidator Rfvtr;
		protected System.Web.UI.WebControls.RangeValidator Rangevalidator1;
		protected System.Web.UI.WebControls.RangeValidator RfvServ;
		protected System.Web.UI.WebControls.DropDownList cmbsServ;
		TheSite.Gestione.Pmp _fp;
	
	
		private void Page_Load(object sender, System.EventArgs e)
		{					
			
			check_caselle_testo();
			
			FunId = Int32.Parse(Request["FunId"]);			
			
			if (Request["ItemId"] != null) 
			{
				itemId = Int32.Parse(Request["ItemId"]);				
			}

			//Disabilito le combo prima del postback
			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbspmp.ClientID + "').disabled = true;");
			sbValid.Append("document.getElementById('" + this.cmbseq_std.ClientID + "').disabled = true;");
			this.cmbsServ.Attributes.Add("onchange", sbValid.ToString());

			sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbspmp.ClientID + "').disabled = true;");
			sbValid.Append("document.getElementById('" + this.cmbsServ.ClientID + "').disabled = true;");
			this.cmbseq_std.Attributes.Add("onchange", sbValid.ToString());

			sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsServ.ClientID + "').disabled = true;");
			sbValid.Append("document.getElementById('" + this.cmbseq_std.ClientID + "').disabled = true;");
			this.cmbspmp.Attributes.Add("onchange", sbValid.ToString());


			if (!Page.IsPostBack )
			{
				BindServizio();
				//BindSpecStd();//BindTr();
				BindPmPFrequenza();				
				if (itemId != 0) 
				{
					DataSet _MyDs = new DataSet();
					Classi.ClassiAnagrafiche.Pmp _Pmp = new TheSite.Classi.ClassiAnagrafiche.Pmp();
					_MyDs = _Pmp.GetSingleData(itemId); 
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						this.txtsdescrizione.Text= _Dr["DES"].ToString();
					
						if (_Dr["UH"] != DBNull.Value)
							this.txtsunitshour.Text = _Dr["UH"].ToString();
						
						if (_Dr["servizi_id"] !=DBNull.Value)
							this.cmbsServ.SelectedValue = _Dr["servizi_id"].ToString();
						BindEqstd(int.Parse(this.cmbsServ.SelectedValue));

						if (_Dr["eq_std"] != DBNull.Value)
							this.cmbseq_std.SelectedValue = _Dr["eq_std"].ToString();
						BindSpecStd(int.Parse(this.cmbsServ.SelectedValue));
						if (_Dr["freq"] != DBNull.Value)
							this.cmbspmp.SelectedValue= _Dr["freq"].ToString();
												
						if (_Dr["tr"] != DBNull.Value)
						{
							BindSpecStd();
							this.cmbstr.SelectedValue = _Dr["tr"].ToString();
						}														
						if (_Dr["pmp_id"] != DBNull.Value)
							this.txtspmp_id.Text = _Dr["pmp_id"].ToString();
					
						this.lblOperazione.Text = "Modifica Procedura di Manutenzione: " + _Dr["pmp_id"].ToString();
						this.lblFirstAndLast.Visible = true;						
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");	
						lblFirstAndLast.Text = _Pmp.GetFirstAndLastUser(_Dr);
					}
				}
				else
				{
					this.lblOperazione.Text = "Inserimento Procedura di Manutenzione";
					BindEqstd(0);
					BindSpecStd();
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;
				
				}				
				
				if (Request["TipoOper"] == "read")
				{
					AbilitaControlli(false);
					this.lblOperazione.Text = "Visualizzazione Procedura di Manutenzione: " + this.txtspmp_id.Text;

				}
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.Pmp) 
				{
					_fp = (TheSite.Gestione.Pmp) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
				}	
			}
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

		private void check_caselle_testo()
		{
			this.txtsdescrizione.Attributes.Add("onkeypress","Verifica(this.value,250)");
			this.txtsunitshour.Attributes.Add("onkeypress","Verifica1(this.value,10)");			
			this.txtsunitshour.Attributes.Add("onpaste","return false;");			
		}
		
		private void AbilitaControlli(bool enabled)
		{
			this.txtsdescrizione.Enabled = enabled;
			this.txtsunitshour.Enabled = enabled;
			this.txtspmp_id.Enabled = enabled;
			this.cmbstr.Enabled = enabled;
			this.cmbseq_std.Enabled = enabled;
			this.cmbspmp .Enabled = enabled;
			this.cmbsServ.Enabled = enabled;
			this.btnsSalva.Enabled = enabled;
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
			this.cmbsServ.SelectedIndexChanged += new System.EventHandler(this.cmbsServ_SelectedIndexChanged);
			this.cmbseq_std.SelectedIndexChanged += new System.EventHandler(this.cmbseq_std_SelectedIndexChanged);
			this.cmbspmp.SelectedIndexChanged += new System.EventHandler(this.cmbspmp_SelectedIndexChanged);
			
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
				
				Classi.ClassiAnagrafiche.Pmp  _Pmp = new TheSite.Classi.ClassiAnagrafiche.Pmp();
				
				this.txtsdescrizione.DBDefaultValue = DBNull.Value;
				this.txtsunitshour.DBDefaultValue = "0";
				this.txtspmp_id.DBDefaultValue = DBNull.Value;
				this.cmbseq_std.DBDefaultValue = "-1";
				this.cmbspmp.DBDefaultValue = -1;
				this.cmbstr .DBDefaultValue = "-1";
			
				int i_RowsAffected = 0;

				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

				_SCollection.AddItems(this.PanelEdit.Controls);
			
				i_RowsAffected = _Pmp.Delete(_SCollection, itemId);

				if ( i_RowsAffected == -1 )					
					Server.Transfer("Pmp.aspx");
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
			}	
		}

		private void btnsSalva_Click(object sender, System.EventArgs e)
		{	
			this.txtsdescrizione.DBDefaultValue = DBNull.Value;
			this.txtsunitshour.DBDefaultValue = "0";
			this.txtspmp_id.DBDefaultValue = DBNull.Value;
			this.cmbseq_std.DBDefaultValue = "-1";
			this.cmbspmp.DBDefaultValue = "-1";
			this.cmbstr .DBDefaultValue = "-1";
			
				
			
			this.txtsdescrizione.Text=this.txtsdescrizione.Text.Trim();
			this.txtsunitshour.Text= this.txtsunitshour.Text.Trim();	
			
			int i_RowsAffected = 0;
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			_SCollection.AddItems(this.PanelEdit.Controls);
	
			try
			{
				if (itemId == 0)
				{			
					Classi.ClassiAnagrafiche.Pmp _Pmp = new TheSite.Classi.ClassiAnagrafiche.Pmp();
					i_RowsAffected = _Pmp.Add(_SCollection);
				}
				else
				{
					Classi.ClassiAnagrafiche.Pmp  _Pmp = new TheSite.Classi.ClassiAnagrafiche.Pmp();
					i_RowsAffected = _Pmp.Update(_SCollection,itemId);
				}
		
				if (i_RowsAffected==-11)
				{
					Classi.SiteJavaScript.msgBox(this.Page,"Attenzione il Piano di Manutenzione Programmata creato è già presente.");
				}
				else				
				{
					Server.Transfer("Pmp.aspx");
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
			Server.Transfer("Pmp.aspx");
		}

		private void BindSpecStd()
		{
			
			//cambio il valore della combo delle specializzazioni 
			this.cmbstr.Items.Clear();
			  
			Classi.ClassiAnagrafiche.Pmp _Pmp = new TheSite.Classi.ClassiAnagrafiche.Pmp();
				
			DataSet _MyDs = _Pmp.GetAllTr().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{				
				this.cmbstr.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione","id", "- Selezionare una Specializzazione -", "0");
				this.cmbstr.DataTextField = "descrizione";
				this.cmbstr.DataValueField = "id";
				this.cmbstr.DataBind();
			}	
			else
			{
				string s_Messagggio = "- Nessuna Specializzazione  -";
				this.cmbstr.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
			}		
		}

		private void BindSpecStd(int id_serv)
		{
			//cambio il valore della combo delle specializzazioni in base al servizio passato
			this.cmbstr.Items.Clear();
			  
			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_servizio_id";
			s_Id.DbType = CustomDBType.Integer;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = 0;
			s_Id.Value = id_serv;
			_SColl.Add(s_Id);

			Classi.ClassiAnagrafiche.Pmp _Pmp = new TheSite.Classi.ClassiAnagrafiche.Pmp();

			DataSet _MyDs = _Pmp.GetSpecData(_SColl).Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{				
				this.cmbstr.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione","id", "- Selezionare una Specializzazione -", "0");
				this.cmbstr.DataTextField = "descrizione";
				this.cmbstr.DataValueField = "id";
				this.cmbstr.DataBind();
			}	
			else
			{
				string s_Messagggio = "- Nessuna Specializzazione  -";
				this.cmbstr.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
			}
		}
			
	    private void BindServizio()
		{
			
			this.cmbsServ .Items.Clear();
		
			Classi.ClassiDettaglio.Servizi _Servizi = new TheSite.Classi.ClassiDettaglio.Servizi();
				
			DataSet _MyDs = _Servizi.GetServizi().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{				
				this.cmbsServ.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "serv","id", "- Selezionare un Servizio -", "0");
				this.cmbsServ.DataTextField = "serv";
				this.cmbsServ.DataValueField = "id";
				this.cmbsServ.DataBind();
//				BindEqstd();
//				BindSpecServizi();

			}			
		}
		private void BindEqstd(int id_serv)
		{
			
			this.cmbseq_std.Items.Clear();
		
			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_servizio_id";
			s_Id.DbType = CustomDBType.Integer;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = 0;
			s_Id.Value = id_serv;
			_SColl.Add(s_Id);

			TheSite.Classi.ClassiAnagrafiche.Eqstd _Eqstd = new TheSite.Classi.ClassiAnagrafiche.Eqstd();						
			DataSet _MyDs = _Eqstd.GetSingleServ(_SColl).Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbseq_std.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "eq_std", "id", "- Selezionare uno Standard -", "0");
				this.cmbseq_std.DataTextField = "eq_std";
				this.cmbseq_std.DataValueField = "id";
				this.cmbseq_std.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Standard  -";
				this.cmbseq_std.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
						
			}
		}

//		private void BindTr()
//		{
//			
//			this.cmbstr.Items.Clear();
//		
//			Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
//				
//			DataSet _MyDs = _Addetti.GetDataTR().Copy();
//			  
//			if (_MyDs.Tables[0].Rows.Count > 0)
//			{				
//				this.cmbstr.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
//					_MyDs.Tables[0], "descrizione","id", "- Selezionare una Specializzazione -", "0");
//				this.cmbstr.DataTextField = "descrizione";
//				this.cmbstr.DataValueField = "id";
//				this.cmbstr.DataBind();
//			}			
//		}

		private void BindPmPFrequenza()
		{
			
			this.cmbspmp.Items.Clear();
		
			Classi.ClassiAnagrafiche.PmpFrequenza _PmpFrequenza = new TheSite.Classi.ClassiAnagrafiche.PmpFrequenza();
				
			DataSet _MyDs = _PmpFrequenza.GetData().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{				
				this.cmbspmp.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "fqdes","id", "- Selezionare una Frequenza -", "0");
				this.cmbspmp.DataTextField = "fqdes";
				this.cmbspmp.DataValueField = "id";
				this.cmbspmp.DataBind();
			}			
		}

		private void cmbseq_std_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbsServ.SelectedIndex==0)
			{
				DataSet _MyDs;
				Classi.ClassiAnagrafiche.Pmp _Pmp = new TheSite.Classi.ClassiAnagrafiche.Pmp();

				int id_std = int.Parse(cmbseq_std.SelectedValue);
				_MyDs = _Pmp.GetStdData(id_std);
				DataRow _Dr = _MyDs.Tables[0].Rows[0];

				int id_serv = int.Parse(_Dr["id"].ToString());

				BindSpecStd(id_serv);
			}		
			
			if (cmbseq_std.SelectedValue!="0")
			txtspmp_id.Text=generacodice(Int32.Parse(cmbseq_std.SelectedValue),Int32.Parse(cmbspmp.SelectedValue));
//			s_Pmp_id = cmbseq_std.SelectedItem.Text.Substring(0,8) + "_" + cmbspmp.SelectedItem.Text.Split(Convert.ToChar("-"))[0];
//			txtspmp_id.Text=s_Pmp_id;
		}

		private void cmbspmp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			txtspmp_id.Text=generacodice(Int32.Parse(cmbseq_std.SelectedValue),Int32.Parse(cmbspmp.SelectedValue));
			//s_Pmp_id1 = cmbseq_std.SelectedItem.Text.Substring(0,8)+ "_" + cmbspmp.SelectedItem.Text.Split(Convert.ToChar("-"))[0];
//			txtspmp_id.Text=s_Pmp_id1;		
		}

		private void cmbsServ_SelectedIndexChanged(object sender, System.EventArgs e)
		{
				BindEqstd(int.Parse(cmbsServ.SelectedValue));
				BindSpecStd(int.Parse(cmbsServ.SelectedValue));
		}

		private string generacodice(int id_eqstd, int id_freq)
		{
		S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_p_id_eqstd = new S_Object();
			s_p_id_eqstd.ParameterName = "p_id_eqstd";
			s_p_id_eqstd.DbType = CustomDBType.Integer;
			s_p_id_eqstd.Direction = ParameterDirection.Input;
			s_p_id_eqstd.Value=id_eqstd;
			s_p_id_eqstd.Size=10;
			s_p_id_eqstd.Index = 0;
			_SCollection.Add(s_p_id_eqstd);


			S_Controls.Collections.S_Object s_p_id_freq = new S_Object();
			s_p_id_freq.ParameterName = "p_id_freq";
			s_p_id_freq.DbType = CustomDBType.Integer;
			s_p_id_freq.Direction = ParameterDirection.Input;
			s_p_id_freq.Value=id_freq;
			s_p_id_freq.Size=10;
			s_p_id_freq.Index = 1;
			_SCollection.Add(s_p_id_freq);

			Classi.ClassiAnagrafiche.Pmp _Pmp = new TheSite.Classi.ClassiAnagrafiche.Pmp();
			return _Pmp.GetCodicepmp(_SCollection);
		
		}

	
	}
} 
		

		


	

	
		

	
