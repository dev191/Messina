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
	/// Descrizione di riepilogo per EditFunzioni.
	/// </summary>
	public class EditFunzioni : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOperazione;
		protected System.Web.UI.WebControls.Panel PanelEdit;
		protected S_Controls.S_Button btnsSalva;
		protected S_Controls.S_Button btnsElimina;
		protected System.Web.UI.WebControls.Button btnAnnulla;
		protected S_Controls.S_TextBox txtsCodice;
		protected S_Controls.S_TextBox txtsDescrizione;
		protected System.Web.UI.WebControls.Label lblFirstAndLast;

		int FunId = 0;
		protected System.Web.UI.WebControls.ValidationSummary vlsEdit;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDescrizione;
		protected S_Controls.S_TextBox txtsLink;
		protected S_Controls.S_TextBox txtsLinkHelp;
		protected Csy.WebControls.MessagePanel PanelMess;
		int itemId = 0;

		TheSite.Admin.Funzioni _fp;
		MyCollection.clMyCollection _myColl = new MyCollection.clMyCollection();
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
				if(Context.Handler is TheSite.Admin.Funzioni) 
				{
					_fp = (TheSite.Admin.Funzioni) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
				}	

				if (itemId != 0) 
				{
					Classi.Funzione _Funzione = new TheSite.Classi.Funzione();					

					DataSet _MyDs = _Funzione.GetSingleData(itemId).Copy();
					
					if (_MyDs.Tables[0].Rows.Count == 1)
					{
						DataRow _Dr = _MyDs.Tables[0].Rows[0];
						this.txtsDescrizione.Text = (string) _Dr["DESCRIZIONE"];
						if (_Dr["CODICE"] != DBNull.Value)
							this.txtsCodice.Text = (string) _Dr["CODICE"];
						if (_Dr["LINK"] != DBNull.Value)
							this.txtsLink.Text = (string) _Dr["LINK"];	
						if (_Dr["LINK_HELP"] != DBNull.Value)
							this.txtsLinkHelp.Text = (string) _Dr["LINK_HELP"];	

						this.lblFirstAndLast.Text = _Funzione.GetFirstAndLastUser(_Dr);
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
			Server.Transfer("Funzioni.aspx?FunId="+FunId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnsSalva_Click(object sender, System.EventArgs e)
		{
			this.txtsCodice.DBDefaultValue = DBNull.Value;
			this.txtsLink.DBDefaultValue = DBNull.Value;
			this.txtsLinkHelp.DBDefaultValue = DBNull.Value;
			int i_RowsAffected = 0;

			Classi.Funzione _Funzione = new TheSite.Classi.Funzione();

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			_SCollection.AddItems(this.PanelEdit.Controls);

			try
			{
				if (itemId == 0)
					i_RowsAffected = _Funzione.Add(_SCollection);
				else
					i_RowsAffected = _Funzione.Update(_SCollection, itemId);

				if ( i_RowsAffected > 0 )
					Response.Redirect((String) ViewState["UrlReferrer"]);
			}
			catch 
			{
				string s_Err = "Errore: aggiornamento non riuscito";
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
			this.txtsCodice.DBDefaultValue = DBNull.Value;
			this.txtsLinkHelp.DBDefaultValue = DBNull.Value;
			this.txtsLink.DBDefaultValue = DBNull.Value;
			int i_RowsAffected = 0;

			Classi.Funzione _Funzione = new TheSite.Classi.Funzione();

			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			_SCollection.AddItems(this.PanelEdit.Controls);

			try
			{
				i_RowsAffected = _Funzione.Delete(_SCollection, itemId);

				if ( i_RowsAffected == -1 )
					Response.Redirect((String) ViewState["UrlReferrer"]);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				string s_Err = "Errore: cancellazione non riuscita";
				PanelMess.ShowError(s_Err, true);
			}
		}
	}
}
