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
	/// Descrizione di riepilogo per EditMenu.
	/// </summary>
	public class EditMenu : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected Csy.WebControls.MessagePanel PanelMess;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDescrizione;
		protected S_Controls.S_TextBox txtsDescrizione;
		protected S_Controls.S_ComboBox cmbsFunzione;
		protected S_Controls.S_ComboBox cmbsMenuPadre;
		protected S_Controls.S_TextBox txtsCssClass;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		protected S_Controls.S_Button btnsSalva;
		protected S_Controls.S_Button btnsElimina;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected S_Controls.S_TextBox txtsToolTip;
		protected S_Controls.S_TextBox txtsImage;
		protected S_Controls.S_TextBox txtsTarget;
		protected S_Controls.S_TextBox txtsViewOrder;
		protected S_Controls.S_CheckBox ckbsValido;
		protected System.Web.UI.WebControls.RegularExpressionValidator rgeViewOrder;
		protected System.Web.UI.WebControls.CompareValidator cmvFunzione;
		protected System.Web.UI.WebControls.LinkButton lkbInfo;
		protected System.Web.UI.WebControls.Panel pnlShowInfo;
		protected System.Web.UI.WebControls.LinkButton lnkChiudi;
		protected System.Web.UI.WebControls.DataList dtlInfo;

		int FunId = 0;		
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
					Classi.Menu _Menu = new TheSite.Classi.Menu();					

					DataSet _MyDs = _Menu.GetSingleData(itemId).Copy();
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{
						this.BindControls();

						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						this.txtsDescrizione.Text = (string) _Dr["DESCRIZIONE"];
						if (_Dr["CSSCLASS"] != DBNull.Value)
							this.txtsCssClass.Text = (string) _Dr["CSSCLASS"];
						if (_Dr["TOOLTIP"] != DBNull.Value)
							this.txtsToolTip.Text = (string) _Dr["TOOLTIP"];	
						if (_Dr["IMAGE"] != DBNull.Value)
							this.txtsImage.Text = (string) _Dr["IMAGE"];
						if (_Dr["TARGET"] != DBNull.Value)
							this.txtsTarget.Text = (string) _Dr["TARGET"];
						if (_Dr["VIEWORDER"] != DBNull.Value)
							this.txtsViewOrder.Text = _Dr["VIEWORDER"].ToString();

						if(_Dr["FUNZIONE_ID"] != DBNull.Value)
							this.cmbsFunzione.SelectedValue = _Dr["FUNZIONE_ID"].ToString();

						if(_Dr["MENU_PADRE_ID"] != DBNull.Value)
							this.cmbsMenuPadre.SelectedValue = _Dr["MENU_PADRE_ID"].ToString();
						
						if(_Dr["ENABLE"] != DBNull.Value)
							this.ckbsValido.Checked = Convert.ToBoolean((decimal) _Dr["ENABLE"]);

						this.lblFirstAndLast.Text = _Menu.GetFirstAndLastUser(_Dr);
						this.lblOperazione.Text = "Modifica";
						this.lblFirstAndLast.Visible = true;
						this.btnsElimina.Visible = true;
						this.btnsElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");

					}									
				}
				else
				{
					this.lblOperazione.Text = "Nuovo";
					this.lblFirstAndLast.Visible = false;
					this.btnsElimina.Visible = false;
					this.BindControls();
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
		
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{    
			this.lkbInfo.Click += new System.EventHandler(this.lkbInfo_Click);
			this.lnkChiudi.Click += new System.EventHandler(this.lnkChiudi_Click);
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
		private void btnsSalva_Click(object sender, System.EventArgs e)
		{
			this.txtsCssClass.DBDefaultValue = DBNull.Value;
			this.txtsToolTip.DBDefaultValue = DBNull.Value;
			this.txtsImage.DBDefaultValue = DBNull.Value;
			this.txtsTarget.DBDefaultValue = DBNull.Value;
			this.txtsViewOrder.DBDefaultValue = DBNull.Value;
			this.ckbsValido.DBDefaultValue = "-1";
			int i_RowsAffected = 0;

			Classi.Menu _Menu = new TheSite.Classi.Menu();

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			_SCollection.AddItems(this.PanelEdit.Controls);

			try
			{
				if (itemId == 0)
					i_RowsAffected = _Menu.Add(_SCollection);
				else
					i_RowsAffected = _Menu.Update(_SCollection, itemId);

				if ( i_RowsAffected > 0 )
					Response.Redirect((String) ViewState["UrlReferrer"]);
			}
			catch (Exception ex)
			{
				string s_Err = "Errore: ";
				if (ex.Message.Substring(0,8) == "ORA-00001")
					s_Err += "menu già presente";
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
			this.txtsCssClass.DBDefaultValue = DBNull.Value;
			this.txtsToolTip.DBDefaultValue = DBNull.Value;
			this.txtsImage.DBDefaultValue = DBNull.Value;
			this.txtsTarget.DBDefaultValue = DBNull.Value;
			this.txtsViewOrder.DBDefaultValue = DBNull.Value;
			this.ckbsValido.DBDefaultValue = "-1";
			int i_RowsAffected = 0;

			Classi.Menu _Menu = new TheSite.Classi.Menu();

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			_SCollection.AddItems(this.PanelEdit.Controls);

			try
			{
				i_RowsAffected = _Menu.Delete(_SCollection, itemId);

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
		private void lkbInfo_Click(object sender, System.EventArgs e)
		{

			Classi.Menu _Menu = new TheSite.Classi.Menu();
			int i_ParentId = Int16.Parse(cmbsMenuPadre.SelectedValue);
			this.pnlShowInfo.Visible = true;
			this.dtlInfo.DataSource = _Menu.GetInfoOrder(i_ParentId).Tables[0];
			this.dtlInfo.DataBind();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lnkChiudi_Click(object sender, System.EventArgs e)
		{
			this.pnlShowInfo.Visible = false;
		}

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
		private void BindControls()
		{
			Classi.Funzione _Funzioni = new TheSite.Classi.Funzione();

			this.cmbsFunzione.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
				_Funzioni.GetData().Tables[0], "DESCRIZIONE", "ID", "-- SELEZIONARE --", "0");
			this.cmbsFunzione.DataTextField = "DESCRIZIONE";
			this.cmbsFunzione.DataValueField = "ID";
			this.cmbsFunzione.DataBind();

			Classi.Menu _Menu = new TheSite.Classi.Menu();
			DataTable _Dt = _Menu.GetData().Tables[0].Copy();
			DataView _Dv = new DataView(_Dt);

			if (itemId != 0) 
			{	
				_Dv.RowFilter = "ID <> " + itemId;
			}
			
			this.cmbsMenuPadre.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(_Dv
				, "DESCRIZIONE", "ID", "", "0");
			this.cmbsMenuPadre.DataTextField = "DESCRIZIONE";
			this.cmbsMenuPadre.DataValueField = "ID";
			this.cmbsMenuPadre.DataBind();

		}		
		
	}
}
