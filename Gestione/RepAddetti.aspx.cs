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
	/// Descrizione di riepilogo per RepAddetti.
	/// </summary>
	public class RepAddetti : System.Web.UI.Page    // System.Web.UI.Page
	{	
		protected Csy.WebControls.DataPanel PanelRicerca;		
		protected S_Controls.S_Button btnsRicerca;		
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;	
		protected WebControls.PageTitle PageTitle1;
		public static int FunId=0;
		public static string HelpLink = string.Empty;
		TheSite.Gestione.EditRepAddetti _fp;
		protected S_Controls.S_TextBox txtsadd;
		protected S_Controls.S_TextBox txtsditta;
		protected S_Controls.S_ComboBox cmbsGiorno;
		protected S_Controls.S_Button BtnReset;
		clMyCollection _myColl = new clMyCollection();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.GridTitle1.hplsNuovo.NavigateUrl = "../Gestione/EditRepAddetti.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
			this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;
			this.DataGridRicerca.Columns[1].Visible = _SiteModule.IsEditable;				
			if (!Page.IsPostBack)
			{	
				BindGiorni();

				if(Context.Handler is TheSite.Gestione.EditRepAddetti) 
				{	
					_fp = (TheSite.Gestione.EditRepAddetti) Context.Handler;
					if (_fp!=null)
					{
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);
						Ricerca();
					}
				}
			}
					
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
		}

		public clMyCollection _Contenitore
		{
			get 
			{
				return _myColl;
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
			this.DataGridRicerca.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemCreated);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_DeleteCommand);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Ricerca()
		{
			Classi.ClassiAnagrafiche.Addetti _Addetti= new Classi.ClassiAnagrafiche.Addetti();
			this.txtsadd.DBDefaultValue = "%";
			this.txtsditta.DBDefaultValue="%";
			this.cmbsGiorno.DBDefaultValue="0";
			

			S_ControlsCollection _SCollection = new S_ControlsCollection();
			_SCollection.AddItems(this.PanelRicerca.Controls);
			DataSet _MyDs = _Addetti.GetDataAddRep(_SCollection).Copy();

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
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();
		}
		
		private void BindGiorni()
		{			
			this.cmbsGiorno .Items.Clear();
			Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
				
			DataSet _MyDs = _Addetti.GetDays().Copy();
			  
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsGiorno.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "giorno", "id", "- Selezionare un Giorno -", "0");
				this.cmbsGiorno.DataTextField = "giorno";
				this.cmbsGiorno.DataValueField = "id";
				this.cmbsGiorno.DataBind();
				
			}			
		}
		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			Ricerca();		
		}

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
			DataGridRicerca.CurrentPageIndex=e.NewPageIndex;
			Ricerca();
		}
		
		private void DataGridRicerca_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			
			int itemId=Int16.Parse(e.CommandArgument.ToString());

			try
			{					
				Classi.ClassiAnagrafiche.Addetti _Addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
			
				int i_RowsAffected = 0;

				S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

				S_Controls.Collections.S_Object s_addetto_id = new S_Object();
				s_addetto_id.ParameterName = "p_addetto_id";
				s_addetto_id.DbType = CustomDBType.Integer;
				s_addetto_id.Direction = ParameterDirection.Input;
				s_addetto_id.Index = 0;
				s_addetto_id.Value =0;

				S_Controls.Collections.S_Object s_giorno_id = new S_Object();
				s_giorno_id.ParameterName = "p_giorno_id";
				s_giorno_id.DbType = CustomDBType.Integer;
				s_giorno_id.Direction = ParameterDirection.Input;
				s_giorno_id.Index = 1;
				s_giorno_id.Value =0;


				S_Controls.Collections.S_Object s_orain = new S_Object();
				s_orain.ParameterName = "p_orain";
				s_orain.DbType = CustomDBType.VarChar;
				s_orain.Direction = ParameterDirection.Input;
				s_orain.Index = 2;
				s_orain.Value ="%";
			
			
				S_Controls.Collections.S_Object s_oraout = new S_Object();
				s_oraout.ParameterName = "p_oraout";
				s_oraout.DbType = CustomDBType.VarChar;
				s_oraout.Direction = ParameterDirection.Input;
				s_oraout.Index = 3;
				s_oraout.Value ="%";;
				    
					
				_SCollection.Add(s_addetto_id);
				_SCollection.Add(s_giorno_id);
				_SCollection.Add(s_orain);
				_SCollection.Add(s_oraout);

		
				string s_operazione="Delete";
				
				i_RowsAffected = _Addetti.ExecuteUpdateAddRep(_SCollection,s_operazione,itemId);

				if ( i_RowsAffected == -1 )					
					//Server.Transfer("RepAddetti.aspx");
				    Ricerca();
			}
			catch (Exception ex)
			{				
				string s_Err =  ex.Message.ToString().ToUpper();
				//PanelMess.ShowError(s_Err, true);
					
			}

		
		}

		private void DataGridRicerca_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			 System.Web.UI.WebControls.ImageButton  _img = (System.Web.UI.WebControls.ImageButton) (e.Item.FindControl("Imagebutton1"));								
			if(_img!=null)
			{	_img.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");	
				
			}
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
				Response.Redirect("RepAddetti.aspx?FunId=" + FunId);
		}

	}
}
