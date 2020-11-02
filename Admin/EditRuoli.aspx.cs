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

namespace TheSite.Admin
{
	/// <summary>
	/// Descrizione di riepilogo per EditRuoli.
	/// </summary>
	public class EditRuoli : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		protected S_Controls.S_Button btnsSalva;
		protected S_Controls.S_Button btnsElimina;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected S_Controls.S_TextBox txtsDescrizione;
		protected S_Controls.S_TextBox txtsNote;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.DataGrid DataGridEsegui;
		protected System.Web.UI.WebControls.Label lblMessage;		
		protected System.Web.UI.WebControls.Label lblRecord;
		protected System.Web.UI.WebControls.LinkButton lkbNuovo;
		

		int FunId = 0;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDescrizione;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected S_Controls.S_ComboBox cmbsDitta;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected S_Controls.S_ComboBox cmbCopiaruolo;
		protected S_Controls.S_Button btnCopiaRuolo;
		int itemId = 0;
		
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
					Classi.Ruolo _Ruolo = new TheSite.Classi.Ruolo();					

					DataSet _MyDs = _Ruolo.GetSingleData(itemId).Copy();
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						this.txtsDescrizione.Text = (string) _Dr["DESCRIZIONE"];
						if (_Dr["NOTE"] != DBNull.Value)
							this.txtsNote.Text = (string) _Dr["NOTE"];	
					
						this.BindControls();
						if (_Dr["DITTA_ID"] != DBNull.Value)
							this.cmbsDitta.SelectedValue = _Dr["DITTA_ID"].ToString();
						this.lblFirstAndLast.Text = _Ruolo.GetFirstAndLastUser(_Dr);

						DataSet _MyDsFunzioni = _Ruolo.GetFunzioni(itemId).Copy();
						this.DataGridEsegui.DataSource = _MyDsFunzioni.Tables[0];
						this.DataGridEsegui.DataBind();

						this.lblRecord.Text = _MyDsFunzioni.Tables[0].Rows.Count.ToString();	
						this.DataGridEsegui.Columns[1].Visible = true;
						this.DataGridEsegui.Columns[2].Visible = false;
						this.DataGridEsegui.Columns[3].Visible = false;

						this.lblOperazione.Text = "Modifica";
						this.lblFirstAndLast.Visible = true;
						this.btnsElimina.Visible = true;
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");

						BindRuoli();
						cmbCopiaruolo.Visible=true;
						btnCopiaRuolo.Visible=true;
                       }									
				}
				else
				{
					this.lblOperazione.Text = "Nuovo";
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;
					this.BindControls();
					cmbCopiaruolo.Visible=false;
					btnCopiaRuolo.Visible=false;
				}
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
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
		
//		this.DataGridEsegui.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_CancelCommand);
//		this.DataGridEsegui.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_EditCommand);
//		this.DataGridEsegui.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_UpdateCommand);
//		this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
//		this.btnsElimina.Click += new System.EventHandler(this.btnsElimina_Click);
//		this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
//		this.Load += new System.EventHandler(this.Page_Load);
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
			this.btnsElimina.Click += new System.EventHandler(this.btnsElimina_Click);
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			this.lkbNuovo.Click += new System.EventHandler(this.lkbNuovo_Click);
			this.DataGridEsegui.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_ItemCommand);
			this.DataGridEsegui.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_CancelCommand);
			this.DataGridEsegui.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_EditCommand);
			this.DataGridEsegui.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_UpdateCommand);
			this.btnCopiaRuolo.Click += new System.EventHandler(this.btnCopiaRuolo_Click);
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
			this.txtsNote.DBDefaultValue = DBNull.Value;
			int i_RowsAffected = 0;

			Classi.Ruolo _Ruolo = new TheSite.Classi.Ruolo();

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			_SCollection.AddItems(this.PanelEdit.Controls);

			try
			{
				if (itemId == 0)
					i_RowsAffected = _Ruolo.Add(_SCollection);
				else
					i_RowsAffected = _Ruolo.Update(_SCollection, itemId);

				if ( i_RowsAffected > 0 )
					Response.Redirect((String) ViewState["UrlReferrer"]);
			}
			catch (Exception ex)
			{
				string s_Err = "Errore: ";
				if (ex.Message.Substring(0,8) == "ORA-00001")
					s_Err += "denominazione ruolo già presente";
				else
					s_Err += "aggiornamento non riuscito";
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
			this.txtsDescrizione.DBDefaultValue = DBNull.Value;
			this.txtsNote.DBDefaultValue = DBNull.Value;
			int i_RowsAffected = 0;

			Classi.Ruolo _Ruolo = new TheSite.Classi.Ruolo();

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			_SCollection.AddItems(this.PanelEdit.Controls);

			try
			{
				i_RowsAffected = _Ruolo.Delete(_SCollection, itemId);

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
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void DataGridEsegui_UpdateCommand(object source, DataGridCommandEventArgs e)
		{
			S_Controls.S_ComboBox cmbFunzioni = ((S_Controls.S_ComboBox) e.Item.FindControl("ddlFunzione"));
			S_Controls.S_CheckBox ckbLettura = ((S_Controls.S_CheckBox) e.Item.FindControl("ckbLetturaEdit"));
			S_Controls.S_CheckBox ckbInserimento = ((S_Controls.S_CheckBox) e.Item.FindControl("ckbInserimentoEdit"));
			S_Controls.S_CheckBox ckbModifica = ((S_Controls.S_CheckBox) e.Item.FindControl("ckbModificaEdit"));
			S_Controls.S_CheckBox ckbCancellazione = ((S_Controls.S_CheckBox) e.Item.FindControl("ckbCancellazioneEdit"));

			int id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());			
			try
			{
				int i_Result = this.ExecuteRuoliFunzioni(id, Classi.ExecuteType.Update,
					cmbFunzioni, ckbLettura, ckbInserimento, ckbModifica, ckbCancellazione);
			
				if (i_Result > 0)
				{
					this.lblMessage.Text = "Associazione Ruolo - Modifica Eseguita correttamente";
					lblMessage.CssClass = "";
					this.DataGridEsegui.EditItemIndex = -1;
					this.BindGrid();
					this.DataGridEsegui.Columns[1].Visible = true;
					this.DataGridEsegui.Columns[2].Visible = false;
					this.DataGridEsegui.Columns[3].Visible = false;
				}
				else
				{
					lblMessage.Text = "Associazione Ruolo - Modifica non eseguita";
					lblMessage.CssClass = "LabelErrore";
					this.DataGridEsegui.Columns[1].Visible = false;
					this.DataGridEsegui.Columns[2].Visible = true;
					this.DataGridEsegui.Columns[3].Visible = false;
				}
			}
			catch 
			{
				string s_Err = "Errore: Associazione Ruolo non riuscita";
				PanelMess.ShowError(s_Err, true);
			}
		}		

		/// <summary>
		/// 
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void DataGridEsegui_EditCommand(object source, DataGridCommandEventArgs e)
		{		
			this.DataGridEsegui.EditItemIndex = (int) e.Item.ItemIndex;
			this.BindGrid();
			this.DataGridEsegui.Columns[1].Visible = false;
			this.DataGridEsegui.Columns[2].Visible = true;
			this.DataGridEsegui.Columns[3].Visible = false;
		}

		private void DataGridEsegui_CancelCommand(object source, DataGridCommandEventArgs e)
		{			
			this.DataGridEsegui.EditItemIndex = -1;
			this.BindGrid();
			this.DataGridEsegui.Columns[1].Visible = true;
			this.DataGridEsegui.Columns[2].Visible = false;
			this.DataGridEsegui.Columns[3].Visible = false;
		}		

		/// <summary>
		/// 
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void DataGridEsegui_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			S_Controls.S_ComboBox cmbFunzioni;
			S_Controls.S_CheckBox ckbLettura;
			S_Controls.S_CheckBox ckbInserimento;
			S_Controls.S_CheckBox ckbModifica;
			S_Controls.S_CheckBox ckbCancellazione;

			switch(((ImageButton)e.CommandSource).CommandName)
			{

				case "Insert":
					cmbFunzioni = ((S_Controls.S_ComboBox) e.Item.FindControl("ddlFunzioneNew"));
					ckbLettura = ((S_Controls.S_CheckBox) e.Item.FindControl("ckbLetturaNew"));
					ckbInserimento = ((S_Controls.S_CheckBox) e.Item.FindControl("ckbInserimentoNew"));
					ckbModifica = ((S_Controls.S_CheckBox) e.Item.FindControl("ckbModificaNew"));
					ckbCancellazione = ((S_Controls.S_CheckBox) e.Item.FindControl("ckbCancellazioneNew"));

					int i_Result = this.ExecuteRuoliFunzioni(0, Classi.ExecuteType.Insert,
						cmbFunzioni, ckbLettura, ckbInserimento, ckbModifica, ckbCancellazione);
			
					try
					{
						if (i_Result > 0)
						{
							this.lblMessage.Text = "Associazione Ruolo - Inserimento eseguito correttamente";
							lblMessage.CssClass = "";
							this.DataGridEsegui.EditItemIndex = -1;
							this.BindGrid();
							this.DataGridEsegui.Columns[1].Visible = true;
							this.DataGridEsegui.Columns[2].Visible = false;
							this.DataGridEsegui.Columns[3].Visible = false;
						}
						else
						{
							lblMessage.Text = "Associazione Ruolo - Inserimento non eseguito";
							lblMessage.CssClass = "LabelErrore";
							this.DataGridEsegui.Columns[1].Visible = false;
							this.DataGridEsegui.Columns[2].Visible = false;
							this.DataGridEsegui.Columns[3].Visible = true;
						}
					}
					catch 
					{
						string s_Err = "Errore: Inserimento Associazione Ruolo non riuscita";
						PanelMess.ShowError(s_Err, true);
					}
					break;
				case "Delete":
					cmbFunzioni = ((S_Controls.S_ComboBox) e.Item.FindControl("ddlFunzioneNew"));
					ckbLettura = ((S_Controls.S_CheckBox) e.Item.FindControl("ckbLetturaNew"));
					ckbInserimento = ((S_Controls.S_CheckBox) e.Item.FindControl("ckbInserimentoNew"));
					ckbModifica = ((S_Controls.S_CheckBox) e.Item.FindControl("ckbModificaNew"));
					ckbCancellazione = ((S_Controls.S_CheckBox) e.Item.FindControl("ckbCancellazioneNew"));

					int id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());	
					try
					{
						int i_ResultDel = this.ExecuteRuoliFunzioni(id, Classi.ExecuteType.Delete,
							cmbFunzioni, ckbLettura, ckbInserimento, ckbModifica, ckbCancellazione);
			
						if (i_ResultDel == -1)
						{
							this.lblMessage.Text = "Associazione Ruolo - Cancellazione eseguita correttamente";
							lblMessage.CssClass = "";
							this.DataGridEsegui.EditItemIndex = -1;
							this.BindGrid();
						}
						else
						{
							lblMessage.Text = "Associazione Ruolo - Cancellazione non eseguita";
							lblMessage.CssClass = "LabelErrore";						
						}
					}
					catch 
					{
						string s_Err = "Errore: Cancellazione Associazione Ruolo non riuscita";
						PanelMess.ShowError(s_Err, true);
					}

					this.DataGridEsegui.Columns[1].Visible = true;
					this.DataGridEsegui.Columns[2].Visible = false;
					this.DataGridEsegui.Columns[3].Visible = false;
					break;
				default:
					// Do nothing.
					break;

			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lkbNuovo_Click(object sender, System.EventArgs e)
		{
			this.DataGridEsegui.ShowFooter = true;
			this.DataGridEsegui.Columns[1].Visible = false;
			this.DataGridEsegui.Columns[2].Visible = false;
			this.DataGridEsegui.Columns[3].Visible = true;

		}

		/// <summary>
		/// 
		/// </summary>
		private void BindGrid()
		{
			Classi.Ruolo _Ruolo = new TheSite.Classi.Ruolo();

			DataSet _MyDs = _Ruolo.GetFunzioni(itemId).Copy();

			this.DataGridEsegui.DataSource = _MyDs.Tables[0];
			this.DataGridEsegui.DataBind();

			this.lblRecord.Text = _MyDs.Tables[0].Rows.Count.ToString();	
			this.DataGridEsegui.ShowFooter = false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected DataTable GetFunzioni()
		{
			Classi.Funzione _Funzione = new TheSite.Classi.Funzione();
			
			DataSet _MyDs = _Funzione.GetData().Copy();
			return _MyDs.Tables[0];
		}	
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		protected int GetIndex(string item)
		{
			if (item.Length > 0 )
				return int.Parse(item);
			else
				return 0;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="Operazione"></param>
		/// <param name="cmbFunzioni"></param>
		/// <param name="ckbLettura"></param>
		/// <param name="ckbInserimento"></param>
		/// <param name="ckbModifica"></param>
		/// <param name="ckbCancellazione"></param>
		/// <returns></returns>
		private int ExecuteRuoliFunzioni(int id, Classi.ExecuteType Operazione, S_Controls.S_ComboBox cmbFunzioni, 
			S_Controls.S_CheckBox ckbLettura, S_Controls.S_CheckBox ckbInserimento,
			S_Controls.S_CheckBox ckbModifica, S_Controls.S_CheckBox ckbCancellazione)
		{
			int i_Result = 0;

			Classi.Ruolo _Ruolo = new TheSite.Classi.Ruolo();

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
						
			S_Controls.Collections.S_Object s_Id = new S_Controls.Collections.S_Object();
			s_Id.ParameterName = "p_Funzione_Ruoli_Id";
			s_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = 0;
			s_Id.Value = id;

			S_Controls.Collections.S_Object s_FunzioneId = new S_Controls.Collections.S_Object();
			s_FunzioneId.ParameterName = "p_Funzione_Id";
			s_FunzioneId.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_FunzioneId.Direction = ParameterDirection.Input;
			s_FunzioneId.Index = 1;
			if (cmbFunzioni != null)
				s_FunzioneId.Value = cmbFunzioni.SelectedValue;
			else
				s_FunzioneId.Value = DBNull.Value;

			S_Controls.Collections.S_Object s_RuoloId = new S_Controls.Collections.S_Object();
			s_RuoloId.ParameterName = "p_Ruolo_Id";
			s_RuoloId.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_RuoloId.Direction = ParameterDirection.Input;
			s_RuoloId.Index = 2;
			s_RuoloId.Value = itemId;;

			S_Controls.Collections.S_Object s_Lettura = new S_Controls.Collections.S_Object();
			s_Lettura.ParameterName = "p_Lettura";
			s_Lettura.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_Lettura.Direction = ParameterDirection.Input;
			s_Lettura.Index = 3;
			if (ckbLettura != null)
				s_Lettura.Value = Convert.ToInt32(ckbLettura.Checked) * (-1);
			else
				s_Lettura.Value = DBNull.Value;
			
			S_Controls.Collections.S_Object s_Inserimento = new S_Controls.Collections.S_Object();
			s_Inserimento.ParameterName = "p_Inserimento";
			s_Inserimento.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_Inserimento.Direction = ParameterDirection.Input;
			s_Inserimento.Index = 4;
			if (ckbLettura != null)
				s_Inserimento.Value = Convert.ToInt32(ckbInserimento.Checked) * (-1);
			else
				s_Inserimento.Value = DBNull.Value;
			

			S_Controls.Collections.S_Object s_Modifica = new S_Controls.Collections.S_Object();
			s_Modifica.ParameterName = "p_Modifica";
			s_Modifica.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_Modifica.Direction = ParameterDirection.Input;
			s_Modifica.Index = 5;
			if (ckbLettura != null)
				s_Modifica.Value = Convert.ToInt32(ckbModifica.Checked) * (-1);
			else
				s_Modifica.Value = DBNull.Value;			

			S_Controls.Collections.S_Object s_Cancellazione = new S_Controls.Collections.S_Object();
			s_Cancellazione.ParameterName = "p_Cancellazione";
			s_Cancellazione.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_Cancellazione.Direction = ParameterDirection.Input;
			s_Cancellazione.Index = 6;
			if (ckbLettura != null)
				s_Cancellazione.Value = Convert.ToInt32(ckbCancellazione.Checked) * (-1);
			else
				s_Cancellazione.Value = DBNull.Value;
			
			_SCollection.Add(s_Id);
			_SCollection.Add(s_FunzioneId);
			_SCollection.Add(s_RuoloId);
			_SCollection.Add(s_Lettura);
			_SCollection.Add(s_Inserimento);
			_SCollection.Add(s_Modifica);
			_SCollection.Add(s_Cancellazione);

			try
			{
				i_Result = _Ruolo.UpdateFunzioni(_SCollection, Operazione);				
			}
			catch(Exception ex)
			{
				string s_Err =  ex.Message.ToString().ToUpper();
				PanelMess.ShowError(s_Err, true);
				i_Result = 0;
			}

			return i_Result;
		}
		
		private void BindControls()
		{
			Classi.ClassiAnagrafiche.Ditte _Ditta = new TheSite.Classi.ClassiAnagrafiche.Ditte();
			
			this.cmbsDitta.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
				_Ditta.GetData().Tables[0], "DESCRIZIONE", "ID", "", "0");
			this.cmbsDitta.DataTextField = "DESCRIZIONE";
			this.cmbsDitta.DataValueField = "ID";
			this.cmbsDitta.DataBind();

		}

		private void BindRuoli()
		{
			Classi.Ruolo _Ruolo= new TheSite.Classi.Ruolo();
			
			this.cmbCopiaruolo.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
				_Ruolo.GetRuoliTranneMe(itemId).Tables[0], "DESCRIZIONE", "ID", "--Copia da Ruolo--", "0");
			this.cmbCopiaruolo.DataTextField = "DESCRIZIONE";
			this.cmbCopiaruolo.DataValueField = "ID";
			this.cmbCopiaruolo.DataBind();

		}

		private void btnCopiaRuolo_Click(object sender, System.EventArgs e)
		{
			Classi.Ruolo _Ruolo= new TheSite.Classi.Ruolo();
					
			S_Controls.Collections.S_ControlsCollection _SColl = new  S_Controls.Collections.S_ControlsCollection();
			

			S_Controls.Collections.S_Object s_p_ruolo_Id= new S_Object();
			s_p_ruolo_Id.ParameterName = "p_ruolo_Id";
			s_p_ruolo_Id.DbType = CustomDBType.Integer;
			s_p_ruolo_Id.Direction = ParameterDirection.Input;
			s_p_ruolo_Id.Size = 8;
			s_p_ruolo_Id.Index = _SColl.Count;
			s_p_ruolo_Id.Value = itemId;
			_SColl.Add(s_p_ruolo_Id);

			S_Controls.Collections.S_Object s_p_ruolo_da_copiare= new S_Object();
			s_p_ruolo_da_copiare.ParameterName = "p_ruolo_da_copiare";
			s_p_ruolo_da_copiare.DbType = CustomDBType.Integer;
			s_p_ruolo_da_copiare.Direction = ParameterDirection.Input;
			s_p_ruolo_da_copiare.Size = 8;
			s_p_ruolo_da_copiare.Index = _SColl.Count;
			s_p_ruolo_da_copiare.Value =Convert.ToInt32(cmbCopiaruolo.SelectedValue);
			_SColl.Add(s_p_ruolo_da_copiare);

			int rows = _Ruolo.CopiaFunzioni(_SColl);

			BindGrid();
		}
	}
}
