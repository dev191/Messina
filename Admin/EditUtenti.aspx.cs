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

namespace TheSite.Admin
{
	/// <summary>
	/// Descrizione di riepilogo per EditUtenti.
	/// </summary>
	public class EditUtenti : System.Web.UI.Page
	{
		protected S_Controls.S_TextBox txtsUserName;
		protected S_Controls.S_TextBox txtsCognome;
		protected S_Controls.S_TextBox txtsNome;
		protected S_Controls.S_TextBox txtsEmail;
		protected S_Controls.S_TextBox txtsTelefono;
		protected System.Web.UI.WebControls.Panel PanelEdit;		
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected S_Controls.S_Button btnsSalva;
		protected S_Controls.S_Button btnsElimina;		
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected S_Controls.S_TextBox txtsPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvUserName;
		protected System.Web.UI.WebControls.TextBox txtConfermaPassword;
		protected System.Web.UI.WebControls.CompareValidator cpvPassword;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected System.Web.UI.WebControls.ListBox ListBoxLeft;
		protected System.Web.UI.WebControls.ListBox ListBoxRight;
		protected System.Web.UI.WebControls.Button btnAssocia;
		protected System.Web.UI.WebControls.Button btnElimina;

		int itemId = 0;
		int FunId = 0;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected System.Web.UI.WebControls.RegularExpressionValidator rgeEmail;
		protected S_Controls.S_ComboBox CmbProgetto;
		private DataSet _DsListBox;
	
		private void Page_Load(object sender, System.EventArgs e)
		{

			FunId = Int32.Parse(Request.Params["FunId"]);

//			// Verify that the current user has access to edit this module
//			if (PortalSecurity.HasEditPermissions(moduleId) == false) 
//			{
//				Response.Redirect("~/Admin/EditAccessDenied.aspx");
//			}

			if (Request.Params["ItemId"] != null) 
			{
				itemId = Int32.Parse(Request.Params["ItemId"]);
			}


			if (!Page.IsPostBack )
			{
				if (itemId != 0) 
				{
					Classi.Utente _Utente = new TheSite.Classi.Utente();

					DataSet _MyDs = _Utente.GetSingleData(itemId).Copy();
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						this.txtsUserName.Text = (string) _Dr["USERNAME"];
						if (_Dr["COGNOME"] != DBNull.Value)
							this.txtsCognome.Text = (string) _Dr["COGNOME"];
						if (_Dr["NOME"] != DBNull.Value)
							this.txtsNome.Text = (string) _Dr["NOME"];
						if (_Dr["EMAIL"] != DBNull.Value)
							this.txtsEmail.Text = (string) _Dr["EMAIL"];

						if (_Dr["TELEFONO"] != DBNull.Value)
							this.txtsTelefono.Text = (string) _Dr["TELEFONO"];

						this.lblFirstAndLast.Text = _Utente.GetFirstAndLastUser(_Dr);

						if (_Dr["id_progetto"] != DBNull.Value)
							 BindProgetti(int.Parse(_Dr["id_progetto"].ToString()));
                        else
							BindProgetti(0);

						this.AggiornaListBox();
//						this.txtsPassword.Enabled=false;
//						this.txtConfermaPassword.Enabled=false;

						this.lblOperazione.Text = "Modifica";
						this.lblFirstAndLast.Visible = true;
						this.ListBoxLeft.Enabled = true;
						this.ListBoxRight.Enabled = true;
						this.btnAssocia.Enabled = true;
						this.btnElimina.Enabled = true;
						this.btnsElimina.Visible = true;
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
					  
					}					
				}
				else
				{
					this.lblOperazione.Text = "Nuovo";
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;
					this.txtsPassword.Text = "PASSWORD";
					this.txtConfermaPassword.Text = txtsPassword.Text;
					BindProgetti(0);
				}
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
			}
		}
		private void BindProgetti(int progetto)
		{
			
			this.CmbProgetto.Items.Clear();
		
			TheSite.Classi.Progetti _Prog = new TheSite.Classi.Progetti();
						
			DataSet _MyDs = _Prog.GetData();			
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.CmbProgetto.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "id_progetto", "- Selezionare un Progetto -", "0");				
				this.CmbProgetto.DataTextField ="descrizione";
				this.CmbProgetto.DataValueField  ="id_progetto";
				this.CmbProgetto.DataBind();

				CmbProgetto.SelectedValue =progetto.ToString();
			}
			else
			{
				string s_Messagggio = "- Nessun Progetto  -";
				this.CmbProgetto.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
						
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
			this.btnAssocia.Click += new System.EventHandler(this.btnAssocia_Click);
			this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
			this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
			this.btnsElimina.Click += new System.EventHandler(this.btnsElimina_Click);
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAnnulla_Click(object sender, System.EventArgs e)
		{
			 Response.Redirect((String) ViewState["UrlReferrer"]);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnsSalva_Click(object sender, System.EventArgs e)
		{
			Classi.Sicurezza _Sicurezza = new Classi.Sicurezza();

			this.txtsCognome.DBDefaultValue = DBNull.Value;
			this.txtsNome.DBDefaultValue = DBNull.Value;
			this.txtsEmail.DBDefaultValue = DBNull.Value;
			this.txtsTelefono.DBDefaultValue = DBNull.Value;
			this.txtsPassword.DBDefaultValue = " ";

//			if (itemId == 0)
//			  this.txtsPassword.Text = _Sicurezza.EncryptSHA1(this.txtsPassword.Text);
			if (itemId == 0)
				this.txtsPassword.Text = _Sicurezza.EncryptMD5(this.txtsPassword.Text);
			else
				if(this.txtsPassword.Text!="")
				  this.txtsPassword.Text = _Sicurezza.EncryptMD5(this.txtsPassword.Text);

			int i_RowsAffected = 0;

			Classi.Utente _Utente = new TheSite.Classi.Utente();

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			_SCollection.AddItems(this.PanelEdit.Controls);

			try
			{
				if (itemId == 0)
					i_RowsAffected = _Utente.Add(_SCollection);
				else
					i_RowsAffected = _Utente.Update(_SCollection, itemId);
			
				if ( i_RowsAffected > 0 )
				{
					if (this.ListBoxRight.Items.Count > 0)
					{
						DataTable o_Dt = (DataTable) Session["UtentiRuoli"];
						DataView o_Dv = new DataView(o_Dt);
                    					
						foreach(ListItem o_Litem in this.ListBoxRight.Items)
						{
							o_Dv.RowFilter = "Id = " + o_Litem.Value.ToString();
						
							if ( o_Dv.Count == 0 )
							{
								DataRow o_Dr = o_Dt.NewRow();
								o_Dr["Id"] = o_Litem.Value.ToString();
								o_Dr["Ruolo"] = o_Litem.Text.ToString();
								o_Dr["IdUtente"] = i_RowsAffected;
								o_Dr["Operazione"] = "I";
								o_Dt.Rows.Add(o_Dr);
							}
							else if ( o_Dv.Count == 1)
							{
								o_Dv[0]["Operazione"] = DBNull.Value;
							}						
						}
						this.UpdateRuoli(o_Dt); 
						Session.Remove("UtentiRuoli");
					}
					Response.Redirect((String) ViewState["UrlReferrer"]);
				}
			}
			catch (Exception ex)
			{
				string s_Err = "Errore: ";
				if (ex.Message.Substring(0,8) == "ORA-00001")
					s_Err += " nome utente già presente";
				else
					s_Err += " aggiornamento non riuscito";
				PanelMess.ShowError(s_Err, true);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnsElimina_Click(object sender, System.EventArgs e)
		{
			this.txtsCognome.DBDefaultValue = DBNull.Value;
			this.txtsNome.DBDefaultValue = DBNull.Value;
			this.txtsEmail.DBDefaultValue = DBNull.Value;
			this.txtsTelefono.DBDefaultValue = DBNull.Value;
			this.txtsPassword.DBDefaultValue = " ";			
			
			int i_RowsAffected = 0;

			Classi.Utente _Utente = new TheSite.Classi.Utente();

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			_SCollection.AddItems(this.PanelEdit.Controls);

			try
			{
				i_RowsAffected = _Utente.Delete(_SCollection, itemId);

				if ( i_RowsAffected == -1 )
					Response.Redirect((String) ViewState["UrlReferrer"]);
			}
			catch 
			{
				string s_Err = "Errore: cancellazione non riuscita";
				PanelMess.ShowError(s_Err, true);
			}

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAssocia_Click(object sender, System.EventArgs e)
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnElimina_Click(object sender, System.EventArgs e)
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

		/// <summary>
		/// Popola le listbox dei ruoli
		/// </summary>
		private void AggiornaListBox()
		{
			_DsListBox = new DataSet();

			this.CreaTabelle();	
			
			if (itemId > 0)
			{
				Classi.Utente _Utente = new TheSite.Classi.Utente();
	
				DataView o_Dv = new DataView(_Utente.GetRuoli(itemId).Tables[0]);
				if (o_Dv.Count > 0)
				{
					foreach (DataRowView o_Drv in o_Dv)
					{
						DataRow o_Dr = _DsListBox.Tables["UtentiRuoli"].NewRow();
						o_Dr["Id"] = o_Drv["RUOLO_ID"].ToString();
						o_Dr["Ruolo"] = o_Drv["DESCRIZIONE"].ToString();
						o_Dr["IdUtente"] = o_Drv["UTENTE_ID"].ToString();
						_DsListBox.Tables["UtentiRuoli"].Rows.Add(o_Dr);
					}
				}
			}
			Session.Add("UtentiRuoli", _DsListBox.Tables["UtentiRuoli"]);
			
			this.ListBoxRight.DataSource = _DsListBox.Tables["UtentiRuoli"];
			this.ListBoxRight.DataValueField = "Id";
			this.ListBoxRight.DataTextField = "Ruolo";
			this.ListBoxRight.DataBind();
			this.ListBoxRight.SelectedIndex = 0;
						
			Classi.Ruolo _Ruolo = new TheSite.Classi.Ruolo();

			DataView o_DvRuoli = new DataView(_Ruolo.GetData().Tables[0]);
			if (o_DvRuoli.Count > 0)
			{
				foreach (DataRowView o_DrvR in o_DvRuoli)
				{
					if (ListBoxRight.Items.FindByValue(o_DrvR["ID"].ToString()) == null)
					{
						DataRow o_DrR = _DsListBox.Tables["Ruoli"].NewRow();
						o_DrR["Id"] = o_DrvR["ID"].ToString();
						o_DrR["Ruolo"] = o_DrvR["DESCRIZIONE"].ToString();
						_DsListBox.Tables["Ruoli"].Rows.Add(o_DrR);
					}
				}
			}
			
			this.ListBoxLeft.DataSource = _DsListBox.Tables["Ruoli"];
			this.ListBoxLeft.DataValueField = "Id";
			this.ListBoxLeft.DataTextField = "Ruolo";
			this.ListBoxLeft.DataBind();
			this.ListBoxLeft.SelectedIndex = 0;
		}

		/// <summary>
		/// Aggiorna i ruoli associati all'utente. 
		/// </summary>
		/// <param name="UpdateDataTable"></param>
		private void UpdateRuoli(DataTable UpdateDataTable)
		{
			foreach (DataRow dr in UpdateDataTable.Rows)
			{
				if (dr["Operazione"] != DBNull.Value)
				{
					Classi.Utente _Utente = new TheSite.Classi.Utente();
					try
					{
						S_Controls.Collections.S_ControlsCollection _SColl = new S_Controls.Collections.S_ControlsCollection();

						S_Controls.Collections.S_Object s_UtenteId = new S_Controls.Collections.S_Object();
						s_UtenteId.ParameterName = "p_Utente_Id";
						s_UtenteId.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
						s_UtenteId.Direction = ParameterDirection.Input;
						s_UtenteId.Index = 0;
						s_UtenteId.Value = Convert.ToInt32(dr["IdUtente"].ToString());

						S_Controls.Collections.S_Object s_RuoloId = new S_Controls.Collections.S_Object();
						s_RuoloId.ParameterName = "p_Ruolo_Id";
						s_RuoloId.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
						s_RuoloId.Direction = ParameterDirection.Input;
						s_RuoloId.Index = 1;
						s_RuoloId.Value = Convert.ToInt32(dr["Id"].ToString());		

						_SColl.Add(s_UtenteId);
						_SColl.Add(s_RuoloId);


						Classi.ExecuteType Operazione;

						if (dr["Operazione"].ToString() == "I" )
							Operazione = Classi.ExecuteType.Insert;
						else 
							Operazione = Classi.ExecuteType.Delete;

						_Utente.UpdateRuoli(_SColl, Operazione);

					}
					catch 
					{
						string s_Err = "Errore: aggiornamento non riuscito";
						PanelMess.ShowError(s_Err, true);
					}
				}
			}
		}

		/// <summary>
		/// Crea Tabelle Temporanee per popolamento Liste Ruoli
		/// </summary>
		private void CreaTabelle()
		{
			DataTable o_DtRuoli = new DataTable("Ruoli");
			
			DataColumn o_DcIdRuolo = new DataColumn("Id");
			o_DcIdRuolo.DataType = System.Type.GetType("System.Int32");
			o_DcIdRuolo.Unique = true;
			o_DcIdRuolo.AllowDBNull = false;
			o_DtRuoli.Columns.Add(o_DcIdRuolo);

			DataColumn o_DcRuolo = new DataColumn("Ruolo");
			o_DcRuolo.DataType = System.Type.GetType("System.String");
			o_DcRuolo.Unique = false;
			o_DcRuolo.AllowDBNull = false;
			o_DtRuoli.Columns.Add(o_DcRuolo);

			DataTable o_DtUtentiRuoli = new DataTable("UtentiRuoli");
			
			DataColumn o_DcIdRuoloAss = new DataColumn("Id");
			o_DcIdRuoloAss.DataType = System.Type.GetType("System.Int32");
			o_DcIdRuoloAss.Unique = true;
			o_DcIdRuoloAss.AllowDBNull = false;
			o_DtUtentiRuoli.Columns.Add(o_DcIdRuoloAss);

			DataColumn o_DcIdUtente = new DataColumn("IdUtente");
			o_DcIdUtente.DataType = System.Type.GetType("System.Int32");
			o_DcIdUtente.Unique = false;
			o_DcIdUtente.AllowDBNull = false;
			o_DtUtentiRuoli.Columns.Add(o_DcIdUtente);

			DataColumn o_DcDescrRuolo = new DataColumn("Ruolo");
			o_DcDescrRuolo.DataType = System.Type.GetType("System.String");
			o_DcDescrRuolo.Unique = false;
			o_DcDescrRuolo.AllowDBNull = false;
			o_DtUtentiRuoli.Columns.Add(o_DcDescrRuolo);

			DataColumn o_DcOperazione = new DataColumn("Operazione");
			o_DcOperazione.DataType = System.Type.GetType("System.String");
			o_DcOperazione.Unique = false;
			o_DcOperazione.AllowDBNull = true;
			o_DcOperazione.DefaultValue = "D";
			o_DtUtentiRuoli.Columns.Add(o_DcOperazione);

			_DsListBox.Tables.Add(o_DtRuoli);
			_DsListBox.Tables.Add(o_DtUtentiRuoli);
		}		
	}
}
