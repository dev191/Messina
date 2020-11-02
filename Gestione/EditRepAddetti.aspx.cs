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
using System.Text;
using StampaRapportiPdf.Classi;

namespace TheSite.Gestione
{	
	/// <summary>
	/// Descrizione di riepilogo per EditRepAddetti
	/// </summary>
	public class EditRepAddetti : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected Csy.WebControls.MessagePanel PanelMess;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		int itemId = 0;
		protected S_Controls.S_Button btnsSalva;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected System.Web.UI.WebControls.Label lblOperazione;
		int FunId = 0;
		protected S_Controls.S_ComboBox cmbsadd;
		protected S_Controls.S_ComboBox cmbsgiorno;
		protected System.Web.UI.WebControls.TextBox txtsorain;
		protected System.Web.UI.WebControls.TextBox txtsorainmin;
		protected System.Web.UI.WebControls.TextBox txtsoraout;
		protected System.Web.UI.WebControls.TextBox txtsoraoutmin;
		protected System.Web.UI.WebControls.RangeValidator RVraddetto;
		protected System.Web.UI.WebControls.RangeValidator RVrgiorno;
		
		TheSite.Gestione.RepAddetti _fp;
	
	
		private void Page_Load(object sender, System.EventArgs e)
		{					
			
			//Funzioni Client

			
			this.btnsSalva.Attributes.Add("onclick","Valorizza('1');");
			this.btnAnnulla.Attributes.Add("onclick","Valorizza('0');");

			txtsorain.Attributes.Add("onkeypress","SoloNumeri();");
			txtsorain.Attributes.Add("onpaste","return false;");
			string s_funz= "Formatta('" + txtsorain.ClientID + "');";
			txtsorain.Attributes.Add("onblur",s_funz);
			txtsorain.Attributes.Add("maxlength","2");			

			txtsorainmin.Attributes.Add("onkeypress","SoloNumeri();");
			txtsorainmin.Attributes.Add("onpaste","return false;");
			s_funz= "Formatta('" + txtsorainmin.ClientID + "');";
			txtsorainmin.Attributes.Add("onblur",s_funz);
			txtsorainmin.Attributes.Add("maxlength","2");

			txtsoraout.Attributes.Add("onkeypress","SoloNumeri();");
			txtsoraout.Attributes.Add("onpaste","return false;");
			s_funz= "Formatta('" + txtsoraout.ClientID + "');";
			txtsoraout.Attributes.Add("onblur",s_funz);
			txtsoraout.Attributes.Add("maxlength","2");

			txtsoraoutmin.Attributes.Add("onkeypress","SoloNumeri();");
			txtsoraoutmin.Attributes.Add("onpaste","return false;");
			s_funz= "Formatta('" + txtsoraoutmin.ClientID + "');";
			txtsoraoutmin.Attributes.Add("onblur",s_funz);
			txtsoraoutmin.Attributes.Add("maxlength","2");		

			
			FunId = Int32.Parse(Request["FunId"]);			
			
			
			if (Request["ItemId"] != null) 
			{
				itemId = Int32.Parse(Request["ItemId"]);				
			}
			if (!Page.IsPostBack )
			{

				BindAddetti();
				BindGiorni();
				if 	(itemId == 0)
				{
					this.lblOperazione.Text = "Inserimento Reperibilita' Addetto";
					this.txtsorain.Text="00";
					this.txtsorainmin.Text="00";
					this.txtsoraout.Text="00";
					this.txtsoraoutmin.Text="00";
					this.lblFirstAndLast.Visible = false;
					
					
				}		
				else 
				{
					DataSet _MyDs = new DataSet();
					Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
					_MyDs = _Addetti.GetSingleAddrep(itemId); 
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
														
						if (_Dr["addettoid"] != DBNull.Value)
							this.cmbsadd .SelectedValue= _Dr["addettoid"].ToString();
														
						if (_Dr["giornoid"] != DBNull.Value)
							this.cmbsgiorno.SelectedValue= _Dr["giornoid"].ToString();
						 												
						if (_Dr["orain"] != DBNull.Value)
							this.txtsorain.Text= _Dr["orain"].ToString().Split(Convert.ToChar(":"))[0];
						this.txtsorainmin.Text=_Dr["orain"].ToString().Split(Convert.ToChar(":"))[1];
											
						if (_Dr["oraout"] != DBNull.Value)
							this.txtsoraout.Text = _Dr["oraout"].ToString().Split(Convert.ToChar(":"))[0];
						this.txtsoraoutmin.Text=_Dr["oraout"].ToString().Split(Convert.ToChar(":"))[1];

						this.lblFirstAndLast.Visible = true;						
											
						System.Text.StringBuilder _StrBldFirst = new System.Text.StringBuilder();
					  
						_StrBldFirst.Append("Creato da ");
						if (_Dr["FIRST"] != DBNull.Value)
							_StrBldFirst.Append(_Dr["FIRST"].ToString());

						_StrBldFirst.Append(" il ");
						if (_Dr["FIRSTMODIFIED"] != DBNull.Value)
							_StrBldFirst.Append(_Dr["FIRSTMODIFIED"].ToString());
						
						lblFirstAndLast.Text =_StrBldFirst.ToString();
					}
				if (Request["TipoOper"] == "read")
				{
					AbilitaControlli(false);
						this.lblOperazione.Text = "Visualizzazione Reperibilita' Addetto: " + this.cmbsadd.SelectedItem;
				}				
				}	
			
				}
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.Gestione.RepAddetti) 
				{
					_fp = (TheSite.Gestione.RepAddetti) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
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

		
		private void BindGiorni()
		{			
			this.cmbsgiorno .Items.Clear();
			Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
				
			DataSet _MyDs = _Addetti.GetDays().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsgiorno.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "giorno", "id", "- Selezionare un Giorno -", "-1");
				this.cmbsgiorno.DataTextField = "giorno";
				this.cmbsgiorno.DataValueField = "id";
				this.cmbsgiorno.DataBind();
				
			}			
		}

		private void BindAddetti()
		{			
			this.cmbsadd .Items.Clear();
			Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
			DataSet _MyDs = _Addetti.GetData().Copy();
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsadd.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "nominativo", "id", "- Selezionare un Addetto -","-1");
				this.cmbsadd.DataTextField = "nominativo";
				this.cmbsadd.DataValueField = "id";
				this.cmbsadd.DataBind();
				
			}			
		}

		private void AbilitaControlli(bool enabled)
		{
			this.txtsorain.Enabled = enabled;
			this.txtsoraout.Enabled = enabled;
			this.cmbsadd.Enabled = enabled;
			this.cmbsgiorno.Enabled = enabled;
			this.txtsorainmin.Enabled = enabled;
			this.txtsoraoutmin.Enabled = enabled;
			this.btnsSalva.Enabled = enabled;
		
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
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
		private void btnsSalva_Click(object sender, System.EventArgs e)
		{	
			
			this.cmbsadd.DBDefaultValue ="-1";
			this.cmbsgiorno.DBDefaultValue = "-1";
		
			this.txtsoraout.Text=this.txtsoraout.Text.Trim();
			this.txtsorain.Text= this.txtsorain.Text.Trim();
			if (checkdate(itemId)==false)
			{
				Classi.SiteJavaScript.msgBox(this.Page,"Gli orari di inizio o fine turno del giorno prescelto coincidono con orari già esistenti");
			}
			else
			{
				string s_operazione="";
				int i_RowsAffected = 0;
				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

				S_Controls.Collections.S_Object s_orain = new S_Object();
				s_orain.ParameterName = "p_orain";
				s_orain.DbType = CustomDBType.VarChar;
				s_orain.Direction = ParameterDirection.Input;
				s_orain.Index = 2;
				s_orain.Value =txtsorain.Text+ ":" + txtsorainmin.Text;
			
			
				S_Controls.Collections.S_Object s_oraout = new S_Object();
				s_oraout.ParameterName = "p_oraout";
				s_oraout.DbType = CustomDBType.VarChar;
				s_oraout.Direction = ParameterDirection.Input;
				s_oraout.Index = 3;
				s_oraout.Value =txtsoraout.Text+ ":" + txtsoraoutmin.Text;
			
				_SCollection.AddItems(this.PanelEdit.Controls);
				_SCollection.Add(s_orain);
				_SCollection.Add(s_oraout);
				try
				{
					if (itemId == 0)
					{			
						s_operazione="Insert";
						Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
						i_RowsAffected = _Addetti.ExecuteUpdateAddRep(_SCollection,s_operazione,itemId);
					}
					else
					{
						s_operazione="Update";
						Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
						i_RowsAffected = _Addetti.ExecuteUpdateAddRep(_SCollection,s_operazione,itemId);
					}
								
					if 	(i_RowsAffected>0)
						Server.Transfer("RepAddetti.aspx");				
				
				}
				catch (Exception ex)
				{				
					string s_Err =  ex.Message.ToString().ToUpper();
					PanelMess.ShowError(s_Err, true);
				}
			}
		}
	
		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("RepAddetti.aspx");
		}

		private bool checkdate(int itemId)
		{
			bool b_return=true;
			int i_Datain= Int16.Parse(txtsorain.Text+ txtsorainmin.Text);
			int i_Dataout = Int16.Parse(txtsoraout.Text+ txtsoraoutmin.Text);
			
			
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_addetto_id = new S_Object();
			s_addetto_id.ParameterName = "p_addetto_id";
			s_addetto_id.DbType = CustomDBType.Integer;
			s_addetto_id.Direction = ParameterDirection.Input;
			s_addetto_id.Index = 0;
			s_addetto_id.Value =cmbsadd.SelectedValue;
			
			
			S_Controls.Collections.S_Object s_giorno_id = new S_Object();
			s_giorno_id.ParameterName = "p_giorno_id";
			s_giorno_id.DbType = CustomDBType.Integer;
			s_giorno_id.Direction = ParameterDirection.Input;
			s_giorno_id.Index = 1;
			s_giorno_id.Value =cmbsgiorno.SelectedValue;

			
			_SCollection.Add(s_addetto_id);
			_SCollection.Add(s_giorno_id);
			

			Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
			DataSet _Ds=_Addetti.GetDateRep(_SCollection);
			DataTable _Dt=_Ds.Tables[0];
			foreach  (DataRow _Dr in _Dt.Rows)
			{
				if(i_Datain>=Int16.Parse(_Dr["datain"].ToString()) && i_Datain<=Int16.Parse(_Dr["dataout"].ToString()))
				{
					b_return= false;
					break;
				}

				if(i_Dataout>=Int16.Parse(_Dr["datain"].ToString()) && i_Dataout<=Int16.Parse(_Dr["dataout"].ToString()))
				{
					b_return= false;
					break;
				}
			}
			
			return b_return;
			
		}
	
	}
		
} 	
		
		

		


	

	
		

	
