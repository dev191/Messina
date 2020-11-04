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
using TheSite.GIC.App_Code.DataSetDef;
using ApplicationDataLayer.DBType;

namespace TheSite.GIC.Report
{
	/// <summary>
	/// Descrizione di riepilogo per AssociaUtenti.
	/// </summary>
	public class AssociaUtenti : System.Web.UI.Page
	{
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_TextBox txtsUserName;
		protected S_Controls.S_ComboBox CmbProgetto;
		protected S_Controls.S_TextBox txtsCognome;
		protected S_Controls.S_TextBox txtsNome;
		protected S_Controls.S_TextBox txtsEmail;
		protected S_Controls.S_TextBox txtsTelefono;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
	
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;
		
		public static int FunId = 0;
		protected S_Controls.S_Button btnsSalva;
		
		public static string HelpLink = string.Empty;
		protected S_Controls.S_Button btnsIndietro;
		private string idSchema;
		private string Schema;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			TheSite.Classi.SiteModule _SiteModule = (TheSite.Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.GridTitle1.hplsNuovo.NavigateUrl = "../Admin/EditUtenti.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
			this.GridTitle1.hplsNuovo.Visible = false;			
			this.DataGridRicerca.Columns[1].Visible = _SiteModule.IsEditable;				
			idSchema=Request.QueryString["id"];
			Schema=Request.QueryString["schema"];
			
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle + " allo Schema: " + Schema;
			if(!IsPostBack)
			{
				BindProgetti(0);
				this.btnsSalva.Visible=false;
				Ricerca();
			}
		}
		private void BindProgetti(int progetto)
		{
			
			this.CmbProgetto.Items.Clear();
		
			TheSite.Classi.Progetti _Prog = new TheSite.Classi.Progetti();
						
			DataSet _MyDs = _Prog.GetData();			
			
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.CmbProgetto.DataSource = TheSite.Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "id_progetto", "- Selezionare un Progetto -", "0");				
				this.CmbProgetto.DataTextField ="descrizione";
				this.CmbProgetto.DataValueField  ="id_progetto";
				this.CmbProgetto.DataBind();

				CmbProgetto.SelectedValue =progetto.ToString();
			}
			else
			{
				string s_Messagggio = "- Nessun Progetto  -";
				this.CmbProgetto.Items.Add(TheSite.Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, "-1"));
						
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
			this.btnsRicerca.Click += new System.EventHandler(this.btnsRicerca_Click);
			this.btnsIndietro.Click += new System.EventHandler(this.btnsIndietro_Click);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.btnsSalva.Click += new System.EventHandler(this.btnsSalva_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			Ricerca();
		}

		private void Ricerca()
		{
			TheSite.GIC.Classi.ParsingViste _Utente = new TheSite.GIC.Classi.ParsingViste();

			this.txtsUserName.DBDefaultValue = "%";
			this.txtsCognome.DBDefaultValue = "%";
			this.txtsNome.DBDefaultValue = "%";
			this.txtsEmail.DBDefaultValue = "%";
			this.txtsTelefono.DBDefaultValue = "%";
				
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			_SCollection.AddItems(this.PanelRicerca.Controls);

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_idSchema";
			s_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = _SCollection.Count + 1;
			s_Id.Value = idSchema;
			
			_SCollection.Add(s_Id);

			DataSet _MyDs = _Utente.GetDataUtenti(_SCollection).Copy();

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();
			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();
			
			if(_MyDs.Tables[0].Rows.Count>0)
				this.btnsSalva.Visible=true;
			else
				this.btnsSalva.Visible=false;
		}

		private void btnsSalva_Click(object sender, System.EventArgs e)
		{
			bool isChecked;
			string Username;
			
			// Richiamo la Funzione che elimina tutte le associazioni
			// corrispondenti ai criteri di ricerca

			TheSite.GIC.Classi.ParsingViste _Utente = new TheSite.GIC.Classi.ParsingViste();

			this.txtsUserName.DBDefaultValue = "%";
			this.txtsCognome.DBDefaultValue = "%";
			this.txtsNome.DBDefaultValue = "%";
			this.txtsEmail.DBDefaultValue = "%";
			this.txtsTelefono.DBDefaultValue = "%";
				
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			_SCollection.AddItems(this.PanelRicerca.Controls);

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_idSchema";
			s_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = _SCollection.Count + 1;
			s_Id.Value = idSchema;
			
			_SCollection.Add(s_Id);			

			_Utente.DeleteSchemaUtenti(_SCollection);
			
			
			foreach(DataGridItem o_Litem in DataGridRicerca.Items)
			{				
				System.Web.UI.WebControls.CheckBox chk = (CheckBox) o_Litem.FindControl("ChkSel");
				isChecked=chk.Checked;
				Username=o_Litem.Cells[2].Text;
				if(isChecked)
				{
					Salva(Username);			
				}						
			}
		}

		private void Salva(string Username)
		{
			TheSite.GIC.Classi.ParsingViste _Gic = new TheSite.GIC.Classi.ParsingViste();			
			_Gic.InsertSchemaUtenti(Username,Int32.Parse(idSchema));
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if( e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem )
			{				
				System.Web.UI.WebControls.CheckBox chk = (CheckBox) e.Item.Cells[0].FindControl("ChkSel");
				
				if (DataBinder.Eval(e.Item.DataItem, "IDSCHEMA")!=System.DBNull.Value) 
				{					
					chk.Checked=true;
				}
				else
				{
					chk.Checked=false;				
				}
			}
		}

		private void btnsIndietro_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("DefaultReport.aspx");
		}
	}
}


