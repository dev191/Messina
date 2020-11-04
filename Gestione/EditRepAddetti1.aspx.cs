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
using System.Text;


namespace TheSite.Gestione
{	
	/// <summary>
	/// Descrizione di riepilogo per EditRepAddetti1
	/// </summary>
	public class EditRepAddetti1 : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.TextBox txtsorain;
		protected System.Web.UI.WebControls.TextBox txtsorainmin;
		protected System.Web.UI.WebControls.TextBox txtsoraout;
		protected System.Web.UI.WebControls.TextBox txtsoraoutmin;
		protected System.Web.UI.WebControls.RangeValidator RVraddetto;
		protected System.Web.UI.WebControls.ListBox ListBoxLeft;
		protected System.Web.UI.WebControls.ListBox ListboxRight;
		protected System.Web.UI.WebControls.Button btnAssocia;
		protected System.Web.UI.WebControls.Button btnElimina;
		protected System.Web.UI.WebControls.ListBox ListBoxRight;
		private DataSet _DsListboxL;		
		private DataSet _DsListboxR;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		
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
				AggiornaListbox();
				if 	(itemId == 0)
				{
					this.lblOperazione.Text = "Inserimento Reperibilita' Addetto";
					this.txtsorain.Text="00";
					this.txtsorainmin.Text="00";
					this.txtsoraout.Text="00";
					this.txtsoraoutmin.Text="00";
					this.lblFirstAndLast.Visible = false;
					AbilitaControlli(true);
					
					
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

		private void AggiornaListbox()
		{
			_DsListboxL=new DataSet();
			_DsListboxR=new DataSet();
			CreaTabelle();
		
			//giorni settimana//
			Classi.ClassiAnagrafiche.Reperibilita _Rep = new TheSite.Classi.ClassiAnagrafiche.Reperibilita();
			DataView _DvTr = new DataView(_Rep.GetAlldays().Tables[0]);
			if (_DvTr.Count >0)
			{
				foreach (DataRowView _DvrTr in _DvTr)
				{
					DataRow _DrTr = _DsListboxL.Tables["Giorni"].NewRow();
					_DrTr["Id"] = _DvrTr["Id"].ToString();
					_DrTr["giorno"] = _DvrTr["giorno"].ToString();						
					_DsListboxL.Tables["Giorni"].Rows.Add(_DrTr);
				}
			}
			
			Session.Add("Gior",_DsListboxL.Tables[0]);
			this.ListBoxLeft.DataSource =_DsListboxL.Tables["Giorni"];
			this.ListBoxLeft.DataValueField = "Id";
			this.ListBoxLeft.DataTextField = "giorno";
			this.ListBoxLeft.DataBind();
			this.ListBoxLeft.SelectedIndex = 0;
			if (itemId >0)
			{
				this.ListBoxLeft.Enabled=true;
			}
			else
			{
				this.ListBoxLeft.Enabled=false;
			
			}
			//Giorni Associati
			
			
			if (itemId >0)
			{
				DataView _DvTrAdd = new DataView(_Rep.GetAlldays().Tables[0]);
				if (_DvTrAdd.Count >0)
				{
					foreach (DataRowView _DrvTrAdd in _DvTrAdd)
					{
						DataRow _DrTrAdd = _DsListboxR.Tables["GiorniAssociati"].NewRow();
						_DrTrAdd["giorno_A"] = _DrvTrAdd["giorno_A"].ToString();
						_DrTrAdd["id_A"] = _DrvTrAdd["id_A"].ToString();
						_DrTrAdd["operazione"] = _DrvTrAdd["operazione"].ToString();
						_DsListboxR.Tables["GiorniAssociati"].Rows.Add(_DrTrAdd);
					}
				
				
				}
			}
						
			Session.Add("GiorAss",_DsListboxR.Tables[0]);	
			this.ListBoxRight.DataSource =_DsListboxR.Tables["GiorniAssociati"];
			this.ListBoxRight.DataValueField = "id_A";
			this.ListBoxRight.DataTextField = "giorno_A";
			this.ListBoxRight.DataTextField = "operazione";
			this.ListBoxRight.DataBind();
			this.ListBoxRight.SelectedIndex = 0;
		}
		private void CreaTabelle()
		{
			DataTable _DtSpec = new DataTable("Giorni");
			 
			DataColumn  _DcIdSp = new DataColumn("Id");
			_DcIdSp.DataType = System.Type.GetType("System.Int32");
			_DcIdSp.Unique = true;
			_DcIdSp.AllowDBNull = false;
			_DtSpec.Columns.Add(_DcIdSp);
			
			DataColumn _DcDescSp = new DataColumn("giorno");
			_DcDescSp.DataType = System.Type.GetType("System.String");
			_DcDescSp.Unique = false;
			_DcDescSp.AllowDBNull = false;
			_DtSpec.Columns.Add(_DcDescSp);


			DataTable _DtSpec1 = new DataTable("GiorniAssociati");
			 
			DataColumn  _DcIdSp1 = new DataColumn("Id_A");
			_DcIdSp1.DataType = System.Type.GetType("System.Int32");
			_DcIdSp1.Unique = true;
			_DcIdSp1.AllowDBNull = false;
			_DtSpec1.Columns.Add(_DcIdSp1);
			
			DataColumn _DcDescSp1 = new DataColumn("giorno_A");
			_DcDescSp1.DataType = System.Type.GetType("System.String");
			_DcDescSp1.Unique = false;
			_DcDescSp1.AllowDBNull = false;
			_DtSpec1.Columns.Add(_DcDescSp1);

			DataColumn _DcOperaz1 = new DataColumn("operazione");
			_DcOperaz1.DataType = System.Type.GetType("System.String");
			_DcOperaz1.Unique = false;
			_DcOperaz1.AllowDBNull = false;
			_DtSpec1.Columns.Add(_DcOperaz1);

			_DsListboxL.Tables.Add(_DtSpec);
			_DsListboxR.Tables.Add(_DtSpec1);

		}

		private void AbilitaControlli(bool enabled)
		{
			this.txtsorain.Enabled = enabled;
			this.txtsoraout.Enabled = enabled;
			this.cmbsadd.Enabled = enabled;			
			this.txtsorainmin.Enabled = enabled;
			this.txtsoraoutmin.Enabled = enabled;
			this.btnsSalva.Enabled = enabled;
			this.ListBoxRight.Enabled=enabled;
			this.ListBoxLeft.Enabled=enabled;
		
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
			this.btnAssocia.Click += new System.EventHandler(this.btnAssocia_Click);
			this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
			this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("RepAddetti.aspx");
		}

	
		private void btnsSalva_Click(object sender, System.EventArgs e)
		{	
			if (this.ListBoxRight.Items.Count >= 0)
			{
				DataTable o_Dt = (DataTable) Session["GiorniAssociati"];
				DataView o_Dv = new DataView(o_Dt);
                    					
				foreach(ListItem o_Litem in this.ListBoxRight.Items)
				{
					o_Dv.RowFilter = "Id_A = " + o_Litem.Value.ToString();
						
					if ( o_Dv.Count == 0 )
					{
						DataRow o_Dr = o_Dt.NewRow();
						o_Dr["Id_A"] = o_Litem.Value.ToString();
						o_Dr["giorno_A"] = o_Litem.Text.ToString();
						o_Dr["Operazione"] = "I";
						o_Dt.Rows.Add(o_Dr);
					}
					else if ( o_Dv.Count == 1)
					{
						o_Dv[0]["Operazione"] = DBNull.Value;
					}						
				}
				this.UpdateREP_Addetti(o_Dt); 
				Session.Remove("GiorniAssociati");
			}
			else
			{
				Classi.SiteJavaScript.msgBox(this.Page,"Non è stato selezionato alcun giorno");
			}
	

		
		
		}
		private void UpdateREP_Addetti(DataTable UpdateDataTable)
		{
			foreach (DataRow dr in UpdateDataTable.Rows)
			{
				if (dr["Operazione"] != DBNull.Value)
				{
					Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
					try
					{
						S_Controls.Collections.S_ControlsCollection _SColl = new S_Controls.Collections.S_ControlsCollection();

						this.cmbsadd.DBDefaultValue ="-1";
						this.txtsoraout.Text=this.txtsoraout.Text.Trim();
						this.txtsorain.Text= this.txtsorain.Text.Trim();

//						if (checkdate(itemId)==false)
//						{
//							Classi.SiteJavaScript.msgBox(this.Page,"Gli orari di inizio o fine turno del giorno prescelto coincidono con orari già esistenti");
//						}
						
							string s_operazione="";
							int i_RowsAffected = 0;							

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

							S_Controls.Collections.S_Object s_id_giorno = new S_Controls.Collections.S_Object();
							s_id_giorno.ParameterName = "p_giorno_id";
							s_id_giorno.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
							s_id_giorno.Direction = ParameterDirection.Input;
							s_id_giorno.Index = 1;
							s_id_giorno.Value = Convert.ToInt32(dr["id"].ToString());							

							
			
							_SColl.AddItems(this.PanelEdit.Controls);
							_SColl.Add(s_id_giorno);
							_SColl.Add(s_orain);
							_SColl.Add(s_oraout);
							try
							{
								if (itemId == 0)
								{			
									s_operazione="Insert";
									Classi.ClassiAnagrafiche.Addetti _Add = new TheSite.Classi.ClassiAnagrafiche.Addetti();
									i_RowsAffected = _Add.ExecuteUpdateAddRep1(_SColl,s_operazione,itemId);
								}
								if (i_RowsAffected ==-100)
									Classi.SiteJavaScript.msgBox(this.Page,"Gli orari di inizio o fine turno del giorno prescelto coincidono con orari già esistenti");
									}
							catch (Exception ex)
							{				
								string s_Err =  ex.Message.ToString().ToUpper();
								PanelMess.ShowError(s_Err, true);
							}
						}
						
						
					
					catch (Exception ex)
					{
						string s_Err =  ex.Message.ToString().ToUpper();
						PanelMess.ShowError(s_Err, true);
						//throw ex;
					}
				}
			}
		}

		private void btnAssocia_Click(object sender, System.EventArgs e)
		{
		 Addiziona();
		}

		private void btnElimina_Click(object sender, System.EventArgs e)
		{
		Sottrai();
		}
		private void Addiziona()
		{
			string s_strSelection;
			string s_strSelectionValue;
			if (ListBoxLeft.SelectedItem != null)
			{
				s_strSelection = ListBoxLeft.SelectedItem.Text;
				s_strSelectionValue = ListBoxLeft.SelectedItem.Value;

				if (ListBoxRight.Items.FindByValue(s_strSelectionValue)== null )
				{
					ListItem o_Li = new ListItem(s_strSelection, s_strSelectionValue);
					ListBoxRight.Items.Add(o_Li);
					ListBoxRight.SelectedIndex = 0;
					ListBoxLeft.Items.Remove(o_Li);
				}

			}
		}
		private void Sottrai()
		{
			string s_strSelection;
			string s_strSelectionValue;
			if (ListBoxRight.SelectedItem != null)
			{
				s_strSelection = ListBoxRight.SelectedItem.Text;
				s_strSelectionValue = ListBoxRight.SelectedItem.Value;
				if (ListBoxLeft.Items.FindByValue(s_strSelectionValue)== null )
				{
					ListItem o_Li = new ListItem(s_strSelection, s_strSelectionValue);
					ListBoxLeft.Items.Add(o_Li);
					ListBoxLeft.SelectedIndex = 0;
					ListBoxRight.Items.Remove(o_Li);
				}
				
			}
		
		
		}

	}
}
	
	
		
		

		


	

	
		

	
