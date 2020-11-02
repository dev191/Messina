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
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using ApplicationDataLayer.Collections;
using S_Controls.Collections;
using System.IO;

namespace TheSite.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per EditPrestazioniEnergetiche.
	/// </summary>
	public class EditPrestazioniEnergetiche : System.Web.UI.Page    // System.Web.UI.Page
	{
		#region Dichiarazioni
		protected S_Controls.S_ComboBox cmbsTipPres;
		protected S_Controls.S_TextBox s_txtDesc;
		protected S_Controls.S_TextBox s_txtID;
		protected S_Controls.S_Button btSalva;
		protected S_Controls.S_Button btnElimina;
		protected Csy.WebControls.DataPanel DataPanel1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenblid;
		protected S_Controls.S_Button BtnAnnulla;
		public static string HelpLink = string.Empty;
		public static int FunId = 0;
		protected WebControls.RicercaModulo RicercaModulo1;
		int itemId = 0;
		MyCollection.clMyCollection _myColl = new clMyCollection();
		TheSite.AnagrafeImpianti.PrestazioniEnergetiche _fp;
		protected System.Web.UI.WebControls.RequiredFieldValidator RFVTipoPrest;
		protected System.Web.UI.WebControls.RequiredFieldValidator RFVDescrizione;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		Classi.AnagrafeImpianti.PrestazioniEnergetiche _Prestazioni = new TheSite.Classi.AnagrafeImpianti.PrestazioniEnergetiche(); 
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
		#endregion

		#region pageload
		private void Page_Load(object sender, System.EventArgs e)
		{
			RequiredFieldValidator1.ControlToValidate= RicercaModulo1.ID + ":" + RicercaModulo1.TxtCodice.ID;
			FunId = Int32.Parse(Request["FunId"]);		
			
			if (Request["ItemId"] != null) 
			{
				itemId = Int32.Parse(Request["ItemId"]);				
			}

			if (!Page.IsPostBack )
			{
				BindTipoPrestazione();	
		
				if (itemId != 0) 
				{
					this.btnElimina.Visible = true;
					this.btSalva.Text="Modifica";
					DataSet _MyDs = new DataSet();
					_MyDs = _Prestazioni.GetSingleData(itemId); 
				
					if (_MyDs.Tables[0].Rows.Count == 1)
					{					
						DataRow _Dr = _MyDs.Tables[0].Rows[0];

						if (_Dr["desctipo"] != DBNull.Value)
						{
							BindTipoPrestazione();	
							this.cmbsTipPres.SelectedValue = _Dr["desctipo"].ToString();
						}
						if (_Dr["descrizione"] != DBNull.Value)
							this.s_txtDesc.Text = _Dr["descrizione"].ToString();

						if (_Dr["bl_id"] != DBNull.Value)
						{
							RicercaModulo1.TxtCodice.Text=_Dr["bl_id"].ToString();
							RicercaModulo1.Ricarica();
						}
						this.btnElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");	
					
					}
				}

				else
				{
					
					this.btnElimina.Visible = false;
					this.btSalva.Text="Salva";
				
				}				
				if (Request["TipoOper"] == "read")	
				{
					AbilitaControlli(false);
					
				}

				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Context.Handler is TheSite.AnagrafeImpianti.PrestazioniEnergetiche) 
				{
					_fp = (TheSite.AnagrafeImpianti.PrestazioniEnergetiche) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
				}	
			}
		}
		#endregion

		
		private void AbilitaControlli(bool enabled)
		{
			this.s_txtDesc.Enabled = enabled;
			this.cmbsTipPres.Enabled = enabled;
			btnElimina.Enabled=enabled;
			btSalva.Enabled=enabled;
			
		}
	

		#region Carica Combo
		private void BindTipoPrestazione()
		{
			this.cmbsTipPres.Items.Clear();	
			
			DataSet	_MyDs = _Prestazioni.GetAllTipo();

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsTipPres.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Tipo -", "0");
				this.cmbsTipPres.DataTextField = "DESCRIZIONE";
				this.cmbsTipPres.DataValueField = "ID";
				this.cmbsTipPres.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Piano -";
				this.cmbsTipPres.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "0"));
			}
			this.cmbsTipPres.Enabled=true;
		}
		#endregion
		
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
			this.btSalva.Click += new System.EventHandler(this.btSalva_Click);
			this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
			this.BtnAnnulla.Click += new System.EventHandler(this.BtnAnnulla_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region eventi _click
		private void btnElimina_Click(object sender, System.EventArgs e)
		{
			Execute("elimina");
		}

		private void btSalva_Click(object sender, System.EventArgs e)
		{
			if (itemId==0)
				Execute("insert");
			else
				Execute("modifica");
		}
		private void BtnAnnulla_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("PrestazioniEnergetiche.aspx?FunId=" + FunId);	
		}

		#endregion

		#region execute
		private void Execute(string opera)
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_ID_PRESTAZIONI_ENERGETICHE = new S_Controls.Collections.S_Object();
			s_p_ID_PRESTAZIONI_ENERGETICHE.ParameterName = "p_ID_PRESTAZIONI_ENERGETICHE";
			s_p_ID_PRESTAZIONI_ENERGETICHE.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_ID_PRESTAZIONI_ENERGETICHE.Direction = ParameterDirection.Input;
			s_p_ID_PRESTAZIONI_ENERGETICHE.Index = 0;
			s_p_ID_PRESTAZIONI_ENERGETICHE.Size = 10;
			s_p_ID_PRESTAZIONI_ENERGETICHE.Value = itemId;
			_SCollection.Add(s_p_ID_PRESTAZIONI_ENERGETICHE);

			
			S_Controls.Collections.S_Object s_p_ID_PRESTAZIONI_TIPO = new S_Controls.Collections.S_Object();
			s_p_ID_PRESTAZIONI_TIPO.ParameterName = "p_ID_PRESTAZIONI_TIPO";
			s_p_ID_PRESTAZIONI_TIPO.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_ID_PRESTAZIONI_TIPO.Direction = ParameterDirection.Input;
			s_p_ID_PRESTAZIONI_TIPO.Index = 1;
			s_p_ID_PRESTAZIONI_TIPO.Size = 10;
			s_p_ID_PRESTAZIONI_TIPO.Value = cmbsTipPres.SelectedValue;
			_SCollection.Add(s_p_ID_PRESTAZIONI_TIPO);

			S_Controls.Collections.S_Object s_p_ID_BL = new S_Controls.Collections.S_Object();
			s_p_ID_BL.ParameterName = "p_ID_BL";
			s_p_ID_BL.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_ID_BL.Direction = ParameterDirection.Input;
			s_p_ID_BL.Index = 2;
			s_p_ID_BL.Size = 10;

			if (RicercaModulo1.Idbl=="")
				s_p_ID_BL.Value = 0;
			else
				s_p_ID_BL.Value = RicercaModulo1.Idbl;

			_SCollection.Add(s_p_ID_BL);

			S_Controls.Collections.S_Object s_P_DESCRIZIONE = new S_Controls.Collections.S_Object();
			s_P_DESCRIZIONE.ParameterName = "P_DESCRIZIONE";
			s_P_DESCRIZIONE.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_P_DESCRIZIONE.Direction = ParameterDirection.Input;
			s_P_DESCRIZIONE.Index = 3;
			s_P_DESCRIZIONE.Size = 255;
			s_P_DESCRIZIONE.Value = s_txtDesc.Text;
			_SCollection.Add(s_P_DESCRIZIONE);
		
			int i_RowsAffected = 0;
				
			try
			{
				if (opera == "insert")
				{			
					i_RowsAffected = _Prestazioni.Add(_SCollection);
					if ( i_RowsAffected > 0 && i_RowsAffected!=-11)
					{
						Server.Transfer("PrestazioniEnergetiche.aspx?FunId=" + FunId);			
					}
				}
				else if (opera == "modifica")
				{				
					i_RowsAffected =  _Prestazioni.Update(_SCollection,itemId);
					if ( i_RowsAffected > 0 && i_RowsAffected!=-11)
					{
						Server.Transfer("PrestazioniEnergetiche.aspx?FunId=" + FunId);			
					}
				}
				else if (opera =="elimina")
				{
					i_RowsAffected = _Prestazioni.Delete(_SCollection, itemId);
					if ( i_RowsAffected == -1 )					
						Server.Transfer("PrestazioniEnergetiche.aspx?FunId=" + FunId);
				}
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
			//	PanelMess.ShowError(s_Err, true);
			}	
		}
	}
#endregion

}
	