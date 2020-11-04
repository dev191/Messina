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
using MyCollection;

namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per Ditte.
	/// </summary>
	public class Enti : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		public static int FunId = 0;
		public static string HelpLink = string.Empty;
		MyCollection.clMyCollection _myColl = new clMyCollection();
		protected S_Controls.S_TextBox txtsIndirizzo;
		protected S_Controls.S_TextBox txtsComune;
		protected S_Controls.S_TextBox txtsTelefono;
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;
		protected S_Controls.S_ComboBox cmbsDescrizione;
		protected S_Controls.S_TextBox txtsPartitaIva;
		protected S_Controls.S_TextBox txtsProvincia;
		protected S_Controls.S_TextBox txtsRagioneSociale;
		protected S_Controls.S_TextBox txtsEmail;
		protected S_Controls.S_TextBox txtsReferente;
		protected S_Controls.S_TextBox txtsTelefonoRef;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;
		protected S_Controls.S_TextBox txtsCap;
		protected System.Web.UI.WebControls.Button btnReset;
		EditEnti _fp;
	
		private void Page_Load(object sender, System.EventArgs e)
		{			
						
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.GridTitle1.hplsNuovo.NavigateUrl = "../Gestione/EditEnti.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
			this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;	

			this.DataGridRicerca.Columns[1].Visible = true;
			this.DataGridRicerca.Columns[2].Visible = _SiteModule.IsEditable;				
						
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;			
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			
			if (!Page.IsPostBack)
			{	
				BindEnte();	
				if(Context.Handler is TheSite.Gestione.EditEnti) 
				{									
					_fp = (TheSite.Gestione.EditEnti) Context.Handler;
					if (_fp!=null)
					{
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);
						Ricerca();
					}
					
				}		

			}
		}

		private void BindEnte()
		{
			TheSite.Classi.ClassiAnagrafiche.Enti _Enti = new TheSite.Classi.ClassiAnagrafiche.Enti();
			this.cmbsDescrizione.Items.Clear();
			DataSet _myDS = _Enti.GetData().Copy();
			if(_myDS.Tables[0].Rows.Count > 0)
			{
				this.cmbsDescrizione.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(_myDS.Tables[0],"testo","valore", "- Selezionare Ente -", "");
				this.cmbsDescrizione.DataTextField = "testo";
				this.cmbsDescrizione.DataValueField = "valore";
				this.cmbsDescrizione.DataBind();
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
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged_1);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound_1);
			this.btnsRicerca.Click += new System.EventHandler(this.btnsRicerca_Click);
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		public MyCollection.clMyCollection _Contenitore
		{
			get 
			{
				return _myColl;
			}
		}
	
		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{	
			Ricerca();
		}

		private void Ricerca()
		{
			//Classi.ClassiAnagrafiche.Ditte _Ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
			TheSite.Classi.ClassiAnagrafiche.Enti _Enti = new TheSite.Classi.ClassiAnagrafiche.Enti();

			this.txtsProvincia.DBDefaultValue = "%";
			this.txtsComune.DBDefaultValue = "%";
			this.txtsReferente.DBDefaultValue = "%";
			this.txtsEmail.DBDefaultValue = "%";
			this.txtsTelefono.DBDefaultValue = "%";
			this.txtsIndirizzo.DBDefaultValue = "%";	
			this.txtsRagioneSociale.DBDefaultValue = "%";
			this.txtsPartitaIva.DBDefaultValue = "%";
			

			S_ControlsCollection _SCollection = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_Descrizione = new S_Controls.Collections.S_Object();
			s_p_Descrizione.ParameterName = "pDescrizione";
			s_p_Descrizione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Descrizione.Direction = ParameterDirection.Input;
			s_p_Descrizione.Index = 0;
			s_p_Descrizione.Size = 255;
			s_p_Descrizione.Value = this.cmbsDescrizione.SelectedValue.ToString();
			_SCollection.Add(s_p_Descrizione);
			
			S_Controls.Collections.S_Object s_pProvincia = new S_Controls.Collections.S_Object();
			s_pProvincia.ParameterName = "pProvincia";
			s_pProvincia.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_pProvincia.Direction = ParameterDirection.Input;
			s_pProvincia.Size = 255;
			s_pProvincia.Index = 1;
			s_pProvincia.Value = this.txtsProvincia.Text.Trim();	
			_SCollection.Add(s_pProvincia);
			
			S_Controls.Collections.S_Object s_pComune = new S_Controls.Collections.S_Object();
			s_pComune.ParameterName = "pComune";
			s_pComune.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_pComune.Direction = ParameterDirection.Input;
			s_pComune.Index = 2;
			s_pComune.Size = 255;
			s_pComune.Value = this.txtsComune.Text.Trim();	
			_SCollection.Add(s_pComune);
			
			S_Controls.Collections.S_Object s_pIndirizzo = new S_Controls.Collections.S_Object();
			s_pIndirizzo.ParameterName = "pIndirizzo";
			s_pIndirizzo.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_pIndirizzo.Direction = ParameterDirection.Input;
			s_pIndirizzo.Index = 3;
			s_pIndirizzo.Size = 255;
			s_pIndirizzo.Value = this.txtsIndirizzo.Text.Trim();		
			_SCollection.Add(s_pIndirizzo);

			S_Controls.Collections.S_Object s_pRagioneSociale = new S_Controls.Collections.S_Object();
			s_pRagioneSociale.ParameterName = "pRagioneSociale";
			s_pRagioneSociale.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_pRagioneSociale.Direction = ParameterDirection.Input;
			s_pRagioneSociale.Index = 4;
			s_pRagioneSociale.Size = 255;
			s_pRagioneSociale.Value = this.txtsRagioneSociale.Text.Trim();	
			_SCollection.Add(s_pRagioneSociale);

			S_Controls.Collections.S_Object s_pPiva = new S_Controls.Collections.S_Object();
			s_pPiva.ParameterName = "pPiva";
			s_pPiva.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_pPiva.Direction = ParameterDirection.Input;
			s_pPiva.Index = 5;
			s_pPiva.Size = 255;
			s_pPiva.Value = this.txtsPartitaIva.Text.Trim();
			_SCollection.Add(s_pPiva);

			S_Controls.Collections.S_Object s_pTelefono = new S_Controls.Collections.S_Object();
			s_pTelefono.ParameterName = "pTelefono";
			s_pTelefono.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_pTelefono.Direction = ParameterDirection.Input;
			s_pTelefono.Index = 6;
			s_pTelefono.Size = 255;
			s_pTelefono.Value = this.txtsTelefono.Text.Trim();
			_SCollection.Add(s_pTelefono);
			
			S_Controls.Collections.S_Object s_pEmail = new S_Controls.Collections.S_Object();
			s_pEmail.ParameterName = "pEmail";
			s_pEmail.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_pEmail.Direction = ParameterDirection.Input;
			s_pEmail.Index = 7;
			s_pEmail.Size = 255;
			s_pEmail.Value = this.txtsEmail.Text.Trim();
			_SCollection.Add(s_pEmail);

			S_Controls.Collections.S_Object s_pReferente = new S_Controls.Collections.S_Object();
			s_pReferente.ParameterName = "pReferente";
			s_pReferente.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_pReferente.Direction = ParameterDirection.Input;
			s_pReferente.Index = 8;
			s_pReferente.Size = 255;
			s_pReferente.Value = this.txtsReferente.Text.Trim();
			_SCollection.Add(s_pReferente);

			S_Controls.Collections.S_Object s_pTelefonoReferente = new S_Controls.Collections.S_Object();
			s_pTelefonoReferente.ParameterName = "pTelefonoReferente";
			s_pTelefonoReferente.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_pTelefonoReferente.Direction = ParameterDirection.Input;
			s_pTelefonoReferente.Index = 9;
			s_pTelefonoReferente.Size = 255;
			s_pTelefonoReferente.Value = this.txtsTelefonoRef.Text.Trim();
			_SCollection.Add(s_pTelefonoReferente);


			S_Controls.Collections.S_Object s_pDataInizioContratto  = new S_Controls.Collections.S_Object();
			s_pDataInizioContratto.ParameterName = "PDataInizioContratto";
			s_pDataInizioContratto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_pDataInizioContratto.Direction = ParameterDirection.Input;
			s_pDataInizioContratto.Index = 10;
			s_pDataInizioContratto.Size = 255;
			s_pDataInizioContratto.Value = CalendarPicker1.Datazione.Text;  			
			_SCollection.Add(s_pDataInizioContratto);

			S_Controls.Collections.S_Object s_pDataFineContratto = new S_Controls.Collections.S_Object();
			s_pDataFineContratto.ParameterName = "pDataFineContratto";
			s_pDataFineContratto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_pDataFineContratto.Direction = ParameterDirection.Input;
			s_pDataFineContratto.Index = 11;
			s_pDataFineContratto.Size=255;
			s_pDataFineContratto.Value = CalendarPicker2.Datazione.Text;  			
			_SCollection.Add(s_pDataFineContratto);

			S_Controls.Collections.S_Object s_pCap  = new S_Controls.Collections.S_Object();
			s_pCap.ParameterName = "pCap";
			s_pCap.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_pCap.Direction = ParameterDirection.Input;
			s_pCap.Index = 12;
			s_pCap.Size=255;
			s_pCap.Value = this.txtsCap.Text.Trim();
			_SCollection.Add(s_pCap);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "io_cursor";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 13;
			_SCollection.Add(s_Cursor);

			DataSet _MyDs = _Enti.GetData(_SCollection).Copy();
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

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
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

		private void DataGridRicerca_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{		
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			Ricerca();
		}

		private void DataGridRicerca_ItemDataBound_1(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{	
				if(e.Item.Cells[10].Text.Length > 10)
					e.Item.Cells[10].Text = e.Item.Cells[10].Text.Substring(0,10);
				if(e.Item.Cells[11].Text.Length > 10)
					e.Item.Cells[11].Text = e.Item.Cells[11].Text.Substring(0,10);
			}
		
		}



		private void btnReset_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Enti.aspx");
		}
	}
}
