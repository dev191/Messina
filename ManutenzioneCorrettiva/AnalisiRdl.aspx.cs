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
using ApplicationDataLayer.DBType;
using StampaRapportiPdf.Classi;

namespace TheSite.ManutenzioneCorretiva
{
	/// <summary>
	/// Descrizione di riepilogo per AnalisiRdl.
	/// </summary>
	public class AnalisiRdl : System.Web.UI.Page    // System.Web.UI.Page
	{	
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;
		public static int FunId = 0;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;
		public static string HelpLink = string.Empty;
		clMyCollection _myColl = new clMyCollection();
		protected S_Controls.S_ComboBox cmbsid_status;
		protected S_Controls.S_TextBox txtswo_id;
		protected S_Controls.S_TextBox txtswr_id;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected S_Controls.S_Button btnExcel;
		protected S_Controls.S_Button btReset;
		AnalisiRdlStorico  _fp;
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
			this.btReset.Click += new System.EventHandler(this.btReset_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged_1);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		public clMyCollection _Contenitore
		{
			get 
			{
				return _myColl;
			}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			//this.DataGridRicerca.Columns[1].Visible = _SiteModule.IsEditable;		
				
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			this.GridTitle1.hplsNuovo.Visible = false;
			
			check_caselle_testo();
			
			//Creazione dei primi Parametri 
			
			RicercaModulo1.TxtCodice.DBParameterName="p_bl_id"; 
			RicercaModulo1.TxtCodice.DBIndex =5; 
			RicercaModulo1.TxtCodice.DBDataType=CustomDBType.VarChar; 
			RicercaModulo1.TxtCodice.DBDirection= ParameterDirection.Input; 
			RicercaModulo1.TxtCodice.DBSize=50; 
			RicercaModulo1.TxtCodice.DBDefaultValue=""; 	
			
			RicercaModulo1.TxtRicerca.DBParameterName="p_campus"; 
			RicercaModulo1.TxtRicerca.DBIndex =6; 
			RicercaModulo1.TxtRicerca.DBDataType=CustomDBType.VarChar; 
			RicercaModulo1.TxtRicerca.DBDirection= ParameterDirection.Input; 
			RicercaModulo1.TxtRicerca.DBSize=255; 
			RicercaModulo1.TxtRicerca.DBDefaultValue=""; 

			CalendarPicker1.Datazione.DBParameterName="p_init"; 
			CalendarPicker1.Datazione.DBIndex =0; 
			CalendarPicker1.Datazione.DBDataType=CustomDBType.VarChar; 
			CalendarPicker1.Datazione.DBDirection= ParameterDirection.Input; 
			CalendarPicker1.Datazione.DBSize=10; 
			CalendarPicker1.Datazione.DBDefaultValue=""; 

			CalendarPicker2.Datazione.DBParameterName="p_fine"; 
			CalendarPicker2.Datazione.DBIndex =1; 
			CalendarPicker2.Datazione.DBDataType=CustomDBType.VarChar; 
			CalendarPicker2.Datazione.DBDirection= ParameterDirection.Input; 
			CalendarPicker2.Datazione.DBSize=10; 
			CalendarPicker2.Datazione.DBDefaultValue=""; 
			//btnsRicerca.Attributes.Add("onclick","controllo();");		
			CompareValidator1.ControlToValidate = CalendarPicker2.ID + ":" + CalendarPicker2.Datazione.ID;
			CompareValidator1.ControlToCompare =  CalendarPicker1.ID + ":" + CalendarPicker1.Datazione.ID;
		
			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("this.value = 'Attendere ...';");
			sbValid.Append("this.disabled = true;");
			sbValid.Append("document.getElementById('" + btnsRicerca.ClientID + "').disabled = true;");
			sbValid.Append(this.Page.GetPostBackEventReference(this.btnsRicerca));
			sbValid.Append(";");
			this.btnsRicerca.Attributes.Add("onclick", sbValid.ToString());


			if (!Page.IsPostBack)
			{
				this.GridTitle1.Visible =false;

				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"]; 

				BindWR_status();				
				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();

		
					if(Context.Handler is TheSite.ManutenzioneCorretiva.AnalisiRdlStorico) 
					{									
					  _fp = (TheSite.ManutenzioneCorretiva.AnalisiRdlStorico) Context.Handler;
							if (_fp!=null)
							{
								_myColl=_fp._Contenitore;
								_myColl.SetValues(this.Page.Controls);
								Ricerca();
							}					
					}		

				}
							
			}
		
		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			Ricerca();
//			btnExcel.Visible=true;
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			Ricerca();
		}

		//routine che gestisce il transfer dei valori da AnalisiRdl a AnalisiRdlStorico
		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Dettaglio")
			{	
				_myColl.AddControl(this.Page.Controls, ParentType.Page);
				string s_url = e.CommandArgument.ToString();							
				Server.Transfer(s_url);				
			}
		}

		private void DataGridRicerca_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{		
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			Ricerca();
		}

		#region FunzioniPrivate
		private void BindWR_status()
		{
			Classi.ManOrdinaria.Richiesta _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
			//Carico il combo cmbsid_status
			this.cmbsid_status.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
				_Richiesta.GetStatusAnalisi().Tables[0], "DESCRIZIONE", "ID", "-Selezionare uno Stato-", "0");
			this.cmbsid_status.DataTextField = "DESCRIZIONE";
			this.cmbsid_status.DataValueField = "ID";
			this.cmbsid_status.DataBind();	

		}

		private void Ricerca()
		{
			//Classi.ManOrdinaria.Richiesta _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
			Classi.ManCorrettiva.ClManCorrettiva _Richiesta = new TheSite.Classi.ManCorrettiva.ClManCorrettiva();	
			this.txtswo_id.DBDefaultValue = 0;
			this.txtswr_id .DBDefaultValue = 0;
			this.cmbsid_status.DBDefaultValue =0;							
			S_ControlsCollection _SCollection = new S_ControlsCollection();
			_SCollection.AddItems(PanelRicerca.Controls);
			DataSet _MyDs = _Richiesta.GetAnalisiRDL(_SCollection,Context.User.Identity.Name).Copy();
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			DataGridRicerca.Visible = true;
			this.GridTitle1.Visible =true;
			if (_MyDs.Tables[0].Rows.Count == 0 )
			{
				DataGridRicerca.CurrentPageIndex=0;
				GridTitle1.DescriptionTitle="Nessun dato trovato."; 
			}
			else
			{
				GridTitle1.DescriptionTitle=""; 
				int Pagina = 0;
				if ((_MyDs.Tables[0].Rows.Count % DataGridRicerca.PageSize) >0)
				{
					Pagina ++;
				}
				if (DataGridRicerca.PageCount != Convert.ToInt16((_MyDs.Tables[0].Rows.Count / DataGridRicerca.PageSize) + Pagina))
					//if (DataGridRicerca.PageCount != DataGridRicerca.CurrentPageIndex)				
				{					
					DataGridRicerca.CurrentPageIndex=0;					
				}
			}
			
			this.DataGridRicerca.DataBind();
			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();	
			
		}
		
		private void check_caselle_testo()
		{
			this.txtswr_id.Attributes.Add("onkeypress","Verifica(this.value)");
			this.txtswo_id.Attributes.Add("onkeypress","Verifica(this.value)");
			txtswr_id.Attributes.Add("onpaste","return nonpaste();");
			txtswo_id.Attributes.Add("onpaste","return nonpaste();");
			//this.CalendarPicker1.Datazione.Attributes.Add("onbtnsRicerca_Click","Imposta(this.value)");	
		}

		#endregion

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			Csy.WebControls.Export 	_objExport = new Csy.WebControls.Export();
			DataTable _dt = new DataTable();			
			_dt = GetWordExcel().Tables[0].Copy();	
			if (_dt.Rows.Count != 0)
			{
				_objExport.ExportDetails(_dt, Csy.WebControls.Export.ExportFormat.Excel, "exp.xls" ); 		
			}
			else
			{
				String scriptString = "<script language=JavaScript>alert('Nessun elemento da esportare');";
				scriptString += "<";
				scriptString += "/";
				scriptString += "script>";

				if(!this.IsClientScriptBlockRegistered("clientScriptexp"))
					this.RegisterStartupScript ("clientScriptexp", scriptString);
			}
		}

		private void btReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AnalisiRdl.aspx?FunId=" + ViewState["FunId"]);
		}

		public DataSet GetWordExcel()
		{
			Classi.ManOrdinaria.Richiesta _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();

			this.txtswo_id.DBDefaultValue = 0;
			this.txtswr_id .DBDefaultValue = 0;
			this.cmbsid_status.DBDefaultValue =0;							
			S_ControlsCollection _SCollection = new S_ControlsCollection();
			_SCollection.AddItems(PanelRicerca.Controls);
			return _Richiesta.GetAnalisiRDL(_SCollection,Context.User.Identity.Name).Copy();
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("lnkDett");
				_img1.Attributes.Add("title","Visualizza Storico Richiesta di Lavoro");		
								
			}
		}

	}
}


	

		

		