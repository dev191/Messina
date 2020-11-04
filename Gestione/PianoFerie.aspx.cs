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
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using S_Controls;
using S_Controls.Collections;

namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per EditRuoli.
	/// </summary>
	public class PianoFerie : System.Web.UI.Page
	{
		protected S_Controls.S_TextBox txtsNome;
		protected S_Controls.S_TextBox txtsCognome;
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.CalendarPicker InizioFerie;
		protected WebControls.CalendarPicker FineFerie;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;
		public static int FunId = 0;
		protected S_Controls.S_ComboBox TipoPermesso;
		protected S_Controls.S_Button btreset;
		public static string HelpLink = string.Empty;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
	

			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			this.GridTitle1.hplsNuovo.Visible = false;

			if(!IsPostBack)
			{
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];

				GridTitle1.Visible = false;
				CompareValidator1.ControlToValidate = FineFerie.ID + ":" + FineFerie.Datazione.ID;
				CompareValidator1.ControlToCompare =  InizioFerie.ID + ":" + InizioFerie.Datazione.ID;

				BindControls();				
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
			}
		}

		public DataSet loadMotivoAssenza()
		{
			Classi.ClassiAnagrafiche.Motivo_assenza _Motivo_assenza = new TheSite.Classi.ClassiAnagrafiche.Motivo_assenza();
			DataSet _MyDs = _Motivo_assenza.GetAllData().Copy();
			return _MyDs;
		}
		private void BindControls()
		{
			DataSet _MyDs=loadMotivoAssenza();
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.TipoPermesso.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "id", "- Selezionare il Permesso -", "0");
				this.TipoPermesso.DataTextField = "descrizione";
				this.TipoPermesso.DataValueField = "id";
				this.TipoPermesso.DataBind();
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
			this.btreset.Click += new System.EventHandler(this.btreset_Click);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Effetua la ricerca
		/// </summary>
		private void Ricerca()
		{
		  //Creazione dei parametri per la Ricerca.
          
			S_ControlsCollection _SCollection = new S_ControlsCollection();
//			  p_nome in varchar2,
//            p_cognome in varchar2,
//            p_dataInizio in varchar2,
//            p_dataFine in varchar2,
//            p_idMotivo in number,

			S_Controls.Collections.S_Object p_nome = new S_Object();
			p_nome.ParameterName = "p_nome";
			p_nome.DbType = CustomDBType.VarChar;
			p_nome.Direction = ParameterDirection.Input;
			p_nome.Index = 0;
			p_nome.Size =50;
			p_nome.Value = txtsNome.Text;
			_SCollection.Add(p_nome);
 
			S_Controls.Collections.S_Object p_cognome = new S_Object();
			p_cognome.ParameterName = "p_cognome";
			p_cognome.DbType = CustomDBType.VarChar;
			p_cognome.Direction = ParameterDirection.Input;
			p_cognome.Index = 1;
			p_cognome.Size =50;
			p_cognome.Value = txtsCognome.Text;
			_SCollection.Add(p_cognome);

			S_Controls.Collections.S_Object p_dataInizio = new S_Object();
			p_dataInizio.ParameterName = "p_dataInizio";
			p_dataInizio.DbType = CustomDBType.VarChar;
			p_dataInizio.Direction = ParameterDirection.Input;
			p_dataInizio.Index = 2;
			p_dataInizio.Size =10;
			p_dataInizio.Value = (InizioFerie.Datazione.Text =="")? "":InizioFerie.Datazione.Text; 
			_SCollection.Add(p_dataInizio);

			S_Controls.Collections.S_Object p_dataFine = new S_Object();
			p_dataFine.ParameterName = "p_dataFine";
			p_dataFine.DbType = CustomDBType.VarChar;
			p_dataFine.Direction = ParameterDirection.Input;
			p_dataFine.Index = 3;
			p_dataFine.Size =50;
			p_dataFine.Value = (FineFerie.Datazione.Text =="")? "":FineFerie.Datazione.Text;
			_SCollection.Add(p_dataFine);

			S_Controls.Collections.S_Object p_idMotivo = new S_Object();
			p_idMotivo.ParameterName = "p_idMotivo";
			p_idMotivo.DbType = CustomDBType.Integer;
			p_idMotivo.Direction = ParameterDirection.Input;
			p_idMotivo.Index = 4;
			p_idMotivo.Value = int.Parse(TipoPermesso.SelectedValue);
			_SCollection.Add(p_idMotivo);
            //creazione della classe per il recupero dei dati
			Classi.ClassiAnagrafiche.PianoFerie _PianoFerie = new TheSite.Classi.ClassiAnagrafiche.PianoFerie();
			DataSet _MyDsPianoFerie = _PianoFerie.GetData(_SCollection);
			//Binding con la griglia
			this.DataGridRicerca.DataSource = _MyDsPianoFerie.Tables[0];
			this.DataGridRicerca.DataBind();
			this.GridTitle1.Visible=true; 
			this.GridTitle1.NumeroRecords=_MyDsPianoFerie.Tables[0].Rows.Count.ToString();  
		}
		
		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
          DataGridRicerca.CurrentPageIndex=0; 
		  Ricerca();
		}

		private void btreset_Click(object sender, System.EventArgs e)
		{
				Response.Redirect("PianoFerie.aspx?FunId=" + ViewState["FunId"].ToString());
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex=e.NewPageIndex; 
			Ricerca();
		}

	}
}