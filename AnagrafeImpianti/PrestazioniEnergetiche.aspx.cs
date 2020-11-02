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
	/// Descrizione di riepilogo per PrestazioniEnergetiche.
	/// </summary>
	public class PrestazioniEnergetiche : System.Web.UI.Page    // System.Web.UI.Page
	{
		#region dichiarazioni
		protected S_Controls.S_Button btRicerca;
		protected S_Controls.S_Button brreset;
		protected S_Controls.S_ComboBox cmbsTipPres;
		protected S_Controls.S_TextBox s_txtDesc;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenblid;
		protected WebControls.PageTitle PageTitle1;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected WebControls.GridTitle GridTitle1; 
		public static int FunId = 0;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected Csy.WebControls.DataPanel DataPanel1;
		protected S_Controls.S_TextBox s_txtID;
		public static string HelpLink = string.Empty;
		MyCollection.clMyCollection _myColl = new clMyCollection();
		Classi.AnagrafeImpianti.PrestazioniEnergetiche _Prestazioni = new TheSite.Classi.AnagrafeImpianti.PrestazioniEnergetiche(); 
		EditPrestazioniEnergetiche _fp;
		#endregion

		public MyCollection.clMyCollection _Contenitore
		{
			get 
			{
				return _myColl;
			}
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];

			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;			
			this.GridTitle1.hplsNuovo.NavigateUrl = "../AnagrafeImpianti/EditPrestazioniEnergetiche.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
			this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;	
	
			if (!IsPostBack) 
			{
				BindTipoPrestazione();
				
				
				if(Context.Handler is TheSite.AnagrafeImpianti.EditPrestazioniEnergetiche) 
				{									
					_fp = (TheSite.AnagrafeImpianti.EditPrestazioniEnergetiche) Context.Handler;
					if (_fp!=null)
					{
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);
						Ricerca();
					}					
				}		
			}
			// Inserire qui il codice utente necessario per inizializzare la pagina.
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
			this.btRicerca.Click += new System.EventHandler(this.btRicerca_Click);
			this.brreset.Click += new System.EventHandler(this.brreset_Click);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Eventi _click
		private void btRicerca_Click(object sender, System.EventArgs e)
		{
				Ricerca();
		}

		private void brreset_Click(object sender, System.EventArgs e)
		{
				Response.Redirect("PrestazioniEnergetiche.aspx?FunId=" + FunId);
		}
		#endregion

		#region Ricerca
		private void Ricerca()
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_ID_PRESTAZIONI_ENERGETICHE = new S_Controls.Collections.S_Object();
			s_p_ID_PRESTAZIONI_ENERGETICHE.ParameterName = "p_ID_PRESTAZIONI_ENERGETICHE";
			s_p_ID_PRESTAZIONI_ENERGETICHE.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_ID_PRESTAZIONI_ENERGETICHE.Direction = ParameterDirection.Input;
			s_p_ID_PRESTAZIONI_ENERGETICHE.Index = 0;
			s_p_ID_PRESTAZIONI_ENERGETICHE.Size = 10;
			s_p_ID_PRESTAZIONI_ENERGETICHE.Value = 0;
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

			DataSet _MyDs = _Prestazioni.GetData(_SCollection).Copy();
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];

			if (_MyDs.Tables[0].Rows.Count == 0 )
			{
				DataGridRicerca.CurrentPageIndex=0;
			}
			else
			{
				int Pagina = 0;
				if ((_MyDs.Tables[0].Rows.Count % DataGridRicerca.PageSize) >0)
				{
					Pagina ++;
				}
				if (DataGridRicerca.PageCount != Convert.ToInt16((_MyDs.Tables[0].Rows.Count / DataGridRicerca.PageSize) + Pagina))
				{					
					DataGridRicerca.CurrentPageIndex=0;					
				}
			}

			this.DataGridRicerca.DataBind();					
			this.GridTitle1.NumeroRecords=_MyDs.Tables[0].Rows.Count.ToString();
		}
		#endregion

		#region Event iDataGrid
		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Dettaglio")
			{	
				_myColl.AddControl(this.Page.Controls, ParentType.Page);
				string s_url = e.CommandArgument.ToString();							
				Server.Transfer(s_url);				
			}
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{		
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			Ricerca();
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{	
				
				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton3");
				_img1.Attributes.Add("title","Visualizza");

				ImageButton _img2 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton2");
				_img2.Attributes.Add("title","Modifica");
				
			}
		}
		
		#endregion
	}
}
