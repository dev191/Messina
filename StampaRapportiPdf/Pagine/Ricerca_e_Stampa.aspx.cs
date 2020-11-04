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
using StampaRapportiPdf.WebControls;
using StampaRapportiPdf.Classi;
using S_Controls.Collections;
using S_Controls;
using ApplicationDataLayer.DBType;
using TheSite.StampaRapportiPDF.Reports;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using RptPdf = TheSite.StampaRapportiPDF.Schemixsd;


namespace StampaRapportiPdf.Pagine
{
	/// <summary>
	/// Descrizione di riepilogo per Ricerca_e_Stampa.
	/// </summary>
	public class Ricerca_e_Stampa : System.Web.UI.Page
	{
		#region Definizione oggetti e variabili globali
		protected Csy.WebControls.DataPanel DataPanelRicerca;
		protected WebControls.CalendarPicker cldpkDaAssegnazione;
		protected WebControls.CalendarPicker cldpkAAssegnazione;
		protected  WebControls.CalendarPicker cldpkDaCompletamento; 
		protected  WebControls.CalendarPicker cldpkACompletamento;                           
		protected S_Controls.S_ComboBox S_ComboBox2;
		protected S_Controls.S_Label S_lblComune;
		protected S_Controls.S_Label S_lblEdificio;
		protected S_Controls.S_Label S_lblDitta;
		protected S_Controls.S_Label S_lblCategoria;
		protected S_Controls.S_ComboBox S_cmbComune;
		protected S_Controls.S_ComboBox S_cmbEdificio;
		protected S_Controls.S_ComboBox S_cmbDitta;
		protected S_Controls.S_ComboBox S_cmbCategoria;
		protected S_Controls.S_Label S_lblAddetto;
		protected S_Controls.S_ComboBox S_cmbAddetto;
		protected PageTitle PgTlStampaPdf;
		
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected S_Controls.S_OptionButton S_optSolNonComp;
		protected S_Controls.S_OptionButton S_optSolComp;
		protected S_Controls.S_Label S_lblDataCompletamento;
		protected S_Controls.S_Button S_btnRicerca;
		protected S_Controls.S_Button S_btnDownLoad;
		protected S_Controls.S_Button S_btnReset;
		protected S_Controls.S_Label S_lblDataAssegnazione;
		protected S_Controls.S_Label S_lblDa1;
		protected S_Controls.S_Label S_lblA1;
		protected S_Controls.S_Label S_lblDa2;
		protected S_Controls.S_Label S_lblA2;
		protected S_Controls.S_OptionButton S_optRptCorto;
		protected S_Controls.S_OptionButton S_optLungo;
		protected GridTitle gridtleDataGridRicerca;
		protected S_Controls.S_Button S_btnStampa;
		protected System.Web.UI.WebControls.Label lblMessaggio;
		protected System.Web.UI.WebControls.CompareValidator cmpVldDaAssegnazione;
		protected System.Web.UI.WebControls.CompareValidator cmpVldAAssegnazione;
		protected System.Web.UI.WebControls.CompareValidator cmpVldDaCompletamento;
		protected System.Web.UI.WebControls.CompareValidator cmpVldACompletamento;
		protected S_Controls.S_Button S_btnConfermaSel;
		protected S_Controls.S_Button S_btnSelezionaTutto;
		protected S_Controls.S_Button S_btnDeselezioneTutto;
		protected System.Web.UI.WebControls.Label lblElementiSelezionati;
		protected S_Controls.S_OptionButton S_optDataComp;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		public static string HelpLink = string.Empty;

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
			this.S_btnRicerca.Click += new System.EventHandler(this.S_btnRicerca_Click);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.S_btnConfermaSel.Click += new System.EventHandler(this.S_btnConfermaSel_Click);
			this.S_btnSelezionaTutto.Click += new System.EventHandler(this.S_btnSelezionaTutto_Click);
			this.S_btnDeselezioneTutto.Click += new System.EventHandler(this.S_btnDeselezioneTutto_Click);
			this.S_btnStampa.Click += new System.EventHandler(this.S_btnStampa_Click);
			this.S_btnDownLoad.Click += new System.EventHandler(this.S_btnDownLoad_Click);
			this.S_btnReset.Click += new System.EventHandler(this.S_btnReset_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			TheSite.Classi.SiteModule _SiteModule = (TheSite.Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			HelpLink = _SiteModule.HelpLink;
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			PgTlStampaPdf.MainTitle  = "Ricerca e Stampa Rapporti";
			S_optDataComp.Attributes.Add("onclick","AbilitaDataUlteriore();");
			S_optSolComp.Attributes.Add("onclick","DisabilitaDataUlteriore();");
			S_optSolNonComp.Attributes.Add("onclick","DisabilitaDataUlteriore();");
			gridtleDataGridRicerca.hplsNuovo.Visible=false;
			cmpVldAAssegnazione.ControlToValidate = cldpkAAssegnazione.ID +":"+ cldpkAAssegnazione.Datazione.ID;
			cmpVldAAssegnazione.ControlToCompare  = cldpkDaAssegnazione.ID + ":" + cldpkDaAssegnazione.Datazione.ID;
			cmpVldDaAssegnazione.ControlToValidate = cldpkDaAssegnazione.ID + ":" + cldpkDaAssegnazione.Datazione.ID;
			cmpVldDaAssegnazione.ControlToCompare  = cldpkAAssegnazione.ID + ":" + cldpkAAssegnazione.Datazione.ID;
			cmpVldACompletamento.ControlToValidate = cldpkACompletamento.ID + ":" + cldpkACompletamento.Datazione.ID;
			cmpVldACompletamento.ControlToCompare  = cldpkDaCompletamento.ID + ":" + cldpkDaCompletamento.Datazione.ID;
			cmpVldDaCompletamento.ControlToValidate = cldpkDaCompletamento.ID + ":" +cldpkDaCompletamento.Datazione.ID;
			cmpVldDaCompletamento.ControlToCompare  = cldpkACompletamento.ID + ":" + cldpkACompletamento.Datazione.ID;
			
			if(!IsPostBack)
			{
				riempiCombo("RapportiPdf.bind_edifici",S_cmbEdificio,"System.String");
				riempiCombo("RapportiPdf.bind_comune",S_cmbComune,"System.Int32");
				riempiCombo("RapportiPdf.bind_Addetto",S_cmbAddetto,"System.Int32");
				riempiCombo("RapportiPdf.bind_ditta",S_cmbDitta,"System.Int32");
				riempiCombo("RapportiPdf.bind_categoria",S_cmbCategoria,"System.Int32");

				cldpkAAssegnazione.Datazione.Text=	System.DateTime.Today.ToString().Substring(0,10);
				cldpkDaAssegnazione.Datazione.Text= "01/01/" + System.DateTime.Today.ToString().Substring(6,4);

			}
		}

		#region Codice Legato alla valorizzazione dei controlli nella form
		private int tipologiaReport()
		{
			int tRpt=1001;
			if(S_optRptCorto.Checked==true) 
			{
				tRpt = 0;
			}
			else if(S_optLungo.Checked == true)
			{
				tRpt = 1;
			}
			return tRpt;
		}
		private int tipoComletamento()
		{
			int tip;
			if(S_optSolNonComp.Checked == true)
			{
				tip = 0;
			}
			else if(S_optSolComp.Checked == true)
			{
				tip=1;
			}
			else if(S_optDataComp.Checked == true)
			{
				tip =2;
			}
			else
			{
				throw new Exception();
			}
			return tip;
		}

		private void riempiCombo(string storedProcedure,S_ComboBox cbx, string tipo)
		{
			DataSet ds;
			ds = BindCmb(storedProcedure);
			//ds = BindCmb("RapportiPdf.bind_edifici");
			DataTable dt = new DataTable();
			
			DataColumn dcTesto = colonna("testo","System.String");
			DataColumn dcValore = colonna("valore", tipo);
			dt.Columns.Add(dcTesto);
			dt.Columns.Add(dcValore);
			DataRow drFirst = dt.NewRow();
			drFirst[0]="";
			switch(tipo)
			{
				case "System.String":
					drFirst[1]="";
					break;
				case "System.Int32":
					drFirst[1] = 0;
					break;
				default:
					drFirst[1]="";
					break;
			}
			dt.Rows.Add(drFirst);
			for(int i = 0; i <= ds.Tables[0].Rows.Count -1; i++)
			{
				DataRow dr = dt.NewRow();
				dr[0]=  ds.Tables[0].Rows[i][0];
				dr[1] = ds.Tables[0].Rows[i][1];
				dt.Rows.Add(dr);
			}
			DataView dv = new DataView(dt);
			cbx.DataTextField = "Testo";
			cbx.DataValueField = "Valore";
			cbx.DataSource = dv;
			cbx.DataBind();
		}
		private DataSet BindCmb(string StoredProcedure)
		{
			AgganciaDatalayer io_db  = new AgganciaDatalayer();
			S_Controls.Collections.S_ControlsCollection clDatiRicerca = new S_ControlsCollection();


			S_Controls.Collections.S_Object Cursor = new S_Object();
			Cursor.ParameterName = "RSCursor";
			Cursor.DbType =  CustomDBType.Cursor;
			Cursor.Direction = ParameterDirection.Output;
			Cursor.Index = clDatiRicerca.Count + 1;
			clDatiRicerca.Add(Cursor);

			io_db.NameProcedureDb =StoredProcedure;
			DataSet dsDatiRicerca = new DataSet();
			dsDatiRicerca = io_db.GetData(clDatiRicerca).Copy();
			return dsDatiRicerca;
		}
		
		private DataColumn colonna(string nome,string tipo)
		{
			DataColumn dc = new DataColumn(nome);
			dc.DataType = System.Type.GetType(tipo);
			return dc;
		}

		#endregion
		private void S_btnRicerca_Click(object sender, System.EventArgs e)
		{
			
			//abilitaControlli(true);
			avvioRicerca();
		}
		private void abilitaControlli(bool abilitato)
		{
			S_btnStampa.Enabled= abilitato;
		}
		#region codice legato alla ricerca e riempimento datagrid
		private void avvioRicerca()
		{
			Session.Remove("DatiList");
			EnableControl(false);
			//DataPanelRicerca.Collapsed=true;
			DataGridRicerca.CurrentPageIndex = 0;
			lblMessaggio.Text = "";
			lblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
			ricerca();
		}

		private void ricerca()
		{
			RptPdf.DatasetReport ds;
			ds = riempiDatasetRicerca();
			gridtleDataGridRicerca.NumeroRecords = Convert.ToString(ds.Tables["Data_Report_Ricerca"].Rows.Count );
			DataGridRicerca.DataSource = ds.Tables["Data_Report_Ricerca"];
			DataGridRicerca.DataBind();
		}

		private TheSite.StampaRapportiPDF.Schemixsd.DatasetReport riempiDatasetRicerca()
		{
			AgganciaDatalayer io_db  = new AgganciaDatalayer();
			S_ControlsCollection clDatiRicerca = new S_ControlsCollection();

			
			S_Object cntrEdificio = new S_Object();
			cntrEdificio.ParameterName = "Pedificio";
			cntrEdificio.DbType = CustomDBType.VarChar;
			cntrEdificio.Direction = ParameterDirection.Input;
			cntrEdificio.Size = 8;
			cntrEdificio.Index = 0;
			cntrEdificio.Value = S_cmbEdificio.SelectedItem.Value;
			clDatiRicerca.Add(cntrEdificio);

			S_Object cntrAddetto = new S_Object();
			cntrAddetto.ParameterName = "Paddetto";
			cntrAddetto.DbType = CustomDBType.Integer;
			cntrAddetto.Direction = ParameterDirection.Input;
			cntrAddetto.Size = 255;
			cntrAddetto.Index=1;
			cntrAddetto.Value = S_cmbAddetto.SelectedItem.Value;
			clDatiRicerca.Add(cntrAddetto);

			S_Object cntrlComune = new S_Object();
			cntrlComune.ParameterName = "Pcomune";
			cntrlComune.DbType= CustomDBType.Integer;
			cntrlComune.Direction = ParameterDirection.Input;
			cntrlComune.Size = 128;
			cntrlComune.Index = 2;
			cntrlComune.Value = S_cmbComune.SelectedItem.Value;
			clDatiRicerca.Add(cntrlComune);

			S_Object cntrlDitta = new S_Object();
			cntrlDitta.ParameterName = "Pditta";
			cntrlDitta.DbType = CustomDBType.Integer;
			cntrlDitta.Direction = ParameterDirection.Input;
			cntrlDitta.Size=64;
			cntrlDitta.Index=3;
			cntrlDitta.Value = S_cmbDitta.SelectedItem.Value;
			clDatiRicerca.Add(cntrlDitta);

			S_Object cntrCategoria = new S_Object();
			cntrCategoria.ParameterName = "Pcategoria";
			cntrCategoria.DbType = CustomDBType.Integer;
			cntrCategoria.Direction = ParameterDirection.Input;
			cntrCategoria.Size=128;
			cntrAddetto.Index=4;
			cntrCategoria.Value = S_cmbCategoria.SelectedItem.Value;
			clDatiRicerca.Add(cntrCategoria);

			S_Object cntrAA = new S_Object();
			cntrAA.ParameterName ="Paa";
			cntrAA.DbType = CustomDBType.VarChar;
			cntrAA.Direction = ParameterDirection.Input;
			cntrAA.Size = 10;
			cntrAA.Index = 5;
			cntrAA.Value = cldpkDaAssegnazione.Datazione.Text;
			clDatiRicerca.Add(cntrAA);

			S_Object cntrBB = new S_Object();
			cntrBB.ParameterName ="Pbb";
			cntrBB.DbType = CustomDBType.VarChar;
			cntrBB.Direction = ParameterDirection.Input;
			cntrBB.Size = 10;
			cntrBB.Index= 6;
			cntrBB.Value = cldpkAAssegnazione.Datazione.Text;
			clDatiRicerca.Add(cntrBB);

			S_Object cntrTipoCompletamento = new S_Object();
			cntrTipoCompletamento.ParameterName = "PtipoCompletamento";
			cntrTipoCompletamento.DbType = CustomDBType.Integer;
			cntrTipoCompletamento.Direction = ParameterDirection.Input;
			cntrTipoCompletamento.Size=10;
			cntrTipoCompletamento.Index = 7;
			cntrTipoCompletamento.Value = tipoComletamento();
			clDatiRicerca.Add(cntrTipoCompletamento);

			S_Object cntrDataCompletamentoInit = new S_Object();
			cntrDataCompletamentoInit.ParameterName = "PdataCompletamentoInit";
			cntrDataCompletamentoInit.DbType = CustomDBType.VarChar;
			cntrDataCompletamentoInit.Direction = ParameterDirection.Input;
			cntrDataCompletamentoInit.Size = 10;
			cntrDataCompletamentoInit.Index=8;
			cntrDataCompletamentoInit.Value = cldpkDaCompletamento.Datazione.Text;
			clDatiRicerca.Add(cntrDataCompletamentoInit);

			S_Object  cntrDataCompletamentoEnd = new S_Object();
			cntrDataCompletamentoEnd.ParameterName = "PdataCompletamentoEnd";
			cntrDataCompletamentoEnd.DbType = CustomDBType.VarChar;
			cntrDataCompletamentoEnd.Direction = ParameterDirection.Input;
			cntrDataCompletamentoEnd.Size = 10;
			cntrDataCompletamentoEnd.Index=8;
			cntrDataCompletamentoEnd.Value = cldpkACompletamento.Datazione.Text;
			clDatiRicerca.Add(cntrDataCompletamentoEnd);

			S_Object Cursor = new S_Object();
			Cursor.ParameterName = "RSCursor";
			Cursor.DbType =  CustomDBType.Cursor;
			Cursor.Direction = ParameterDirection.Output;
			Cursor.Index = clDatiRicerca.Count + 1;
			clDatiRicerca.Add(Cursor);

			
			io_db.NameProcedureDb = "rapportipdf.get_data_ricerca_report";
			DataSet dsDatiRicerca = io_db.GetData(clDatiRicerca).Copy();

			RptPdf.DatasetReport DsTipizzato = new  RptPdf.DatasetReport();
			int i=0;
			for(i=0; i<=dsDatiRicerca.Tables[0].Rows.Count-1;i++)
			{ 
				DsTipizzato.Tables["Data_Report_Ricerca"].ImportRow(dsDatiRicerca.Tables[0].Rows[i]);
			}

			if(i==0)
			{
			 	
			}
			return DsTipizzato;

		}

		private void DataGridRicerca_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
			ricerca();
			GetControlli();	
		}
		#endregion
		private void S_btnReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Ricerca_e_Stampa.aspx");
		}

		private void S_btnDownLoad_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Pagina_Download.aspx");
		}


		
		private void S_btnConfermaSel_Click(object sender, System.EventArgs e)
		{
			lblMessaggio.Text = "";
			SetDati();
			SetControlli();	
		}
		private void SetDati()
		{			
			
			Hashtable _HS = new Hashtable();
			int indice = 0;
			
			if(Session["DatiList"]!=null)
			{
				_HS=(Hashtable) Session["DatiList"];				
			}

						
			foreach(DataGridItem o_Litem in DataGridRicerca.Items)
			{
								
				indice = Int32.Parse(o_Litem.Cells[1].Text);									
				System.Web.UI.WebControls.CheckBox cb = 
					(System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel")
					;																									
			
				if(_HS.ContainsKey(indice))
					_HS.Remove(indice);												
							
				if(cb.Checked)
				{
					_HS.Add(indice, indice);		
				}
			}			
			
			Session.Remove("DatiList");
			Session.Add("DatiList",_HS);			
			 lblElementiSelezionati.Text="Elementi Selezionati - " + _HS.Count.ToString() + " -";
			if(_HS.Count>0)
				EnableControl(true);
		 else
				EnableControl(false);

			//			txtTotSelezionati.Text=_HS.Count.ToString();
		}
		private void EnableControl(bool enable)
		{
			S_btnStampa.Enabled =enable;
//			S_optLungo.Enabled = enable;
//			S_optRptCorto.Enabled = enable;
			
		}

		private void SetControlli()
		{			
			clMyDataGridCollection _cl = new clMyDataGridCollection();
			
			Hashtable _HS = new Hashtable();
			if(Session["CheckedList"]!=null)
			{
				_HS=(Hashtable) Session["CheckedList"];				
			}
			_HS=_cl.SetControl(DataGridRicerca,_HS,DataGridRicerca.CurrentPageIndex);
			Session.Remove("CheckedList");
			Session.Add("CheckedList",_HS);	
		}

		private void GetControlli()
		{	
			clMyDataGridCollection _cl = new clMyDataGridCollection();
			if(Session["CheckedList"]!=null)
			{	
				_cl.GetControl(DataGridRicerca,(Hashtable) Session["CheckedList"],DataGridRicerca.CurrentPageIndex);
			}
		}
		private void S_btnStampa_Click(object sender, System.EventArgs e)
		{

	
//			string strOdl=null;
//			int indice = 0;
//			int nOdl = 0;
//				foreach(DataGridItem o_Litem in DataGridRicerca.Items)
//				{	
//					indice = Int32.Parse(o_Litem.Cells[1].Text);									
//					System.Web.UI.WebControls.CheckBox cb = 
//						(System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel")
//						;																																				
//							
//					if(cb.Checked)
//					{
//						strOdl += indice.ToString() + ",";
//						nOdl++;
//					}
//				}
//		
//				if(nOdl == 0)
//				{
//					
//					throw new Exception();
//				}
//				strOdl = strOdl.Remove(strOdl.Length-1,1);
				string strOdl = recuperaSesOdl();
				string [] arOdl = strOdl.Split(',');
				int nOdl = arOdl.Length;
				int idFile= insertDb(nOdl);
				int [] idNormTbl = insertNormTblDb(arOdl,idFile);
				stampaRpt(nOdl,idFile);
				int upIdFile = updateDb(nOdl,idFile);
				if (upIdFile != idFile)
				{
					throw new Exception();
				}
				avvioRicerca();
				lblMessaggio.Text = "Il file " + creaNomeFile(nOdl,idFile) + ".pdf"+ " e' stato  creato correttamente";
		}
		private string recuperaSesOdl()
		{
			string strOdl=String.Empty;
			Hashtable _HS = (Hashtable)Session["DatiList"];
			IDictionaryEnumerator myEnumerator = _HS.GetEnumerator();								
			while (myEnumerator.MoveNext())	
			{
				strOdl += myEnumerator.Value + ",";
			}
					
			strOdl = strOdl.Remove(strOdl.Length-1,1);
			Session.Remove("DatiList");
			return strOdl;
		}
		private int insertDb(int nOdl)
		{
			AgganciaDatalayer io_db  = new AgganciaDatalayer();
			S_ControlsCollection clDatiUpDb = new S_ControlsCollection();
			int pIndex=0;
			string tipRpt = null;
			switch(tipologiaReport())
			{
				case 0:
					tipRpt ="Report corto"; 
					break;
				case 1:
					tipRpt ="Report lungo";
					break;
				default:
					throw new Exception();
					//break;
			}
			string comune    = S_cmbComune.SelectedItem.Text;
			string edificio  = S_cmbEdificio.SelectedItem.Text;
			string ditta     = S_cmbDitta.SelectedItem.Text;
			string categoria = S_cmbCategoria.SelectedItem.Text;
			string addetto   = S_cmbAddetto.SelectedItem.Text;
			string quantitaOdl = "N. " + nOdl.ToString() + " Odl";
			if(comune == string.Empty)
			{
				comune="Tutti";
			}
			if(edificio == string.Empty)
			{
				edificio = "Tutti";
			}
			if(ditta == string.Empty)
			{
				ditta = "Tutte";
			}
			if(categoria == string.Empty)
			{
				categoria = "Tutte";
			}
			if(addetto == string.Empty)
			{
				addetto = "Tutti";
			}
		

			S_Object pNomeFile = new S_Object();
			pNomeFile.ParameterName = "p_NOME_FILE";
			pNomeFile.DbType = CustomDBType.VarChar;
			pNomeFile.Direction = ParameterDirection.Input;
			pNomeFile.Size = 128;
			pNomeFile.Index = pIndex;
			pNomeFile.Value =DBNull.Value;
			clDatiUpDb.Add(pNomeFile);

			S_Object pDataAssegnazioneIn = new S_Object();
			pDataAssegnazioneIn.ParameterName = "P_DATA_ASSEGNAZIONE_INIT";
			pDataAssegnazioneIn.DbType = CustomDBType.VarChar;
			pDataAssegnazioneIn.Direction = ParameterDirection.Input;
			pDataAssegnazioneIn.Size = 10;
			pDataAssegnazioneIn.Index =  pIndex++;
			pDataAssegnazioneIn.Value = cldpkDaAssegnazione.Datazione.Text;
			clDatiUpDb.Add(pDataAssegnazioneIn);

			S_Object pDataAssegnazioneEnd = new S_Object();
			pDataAssegnazioneEnd.ParameterName = "P_DATA_ASSEGNAZIONE_END";
			pDataAssegnazioneEnd.DbType = CustomDBType.VarChar;
			pDataAssegnazioneEnd.Direction = ParameterDirection.Input;
			pDataAssegnazioneEnd.Size = 10;
			pDataAssegnazioneEnd.Index = pIndex++;
			pDataAssegnazioneEnd.Value = cldpkAAssegnazione.Datazione.Text;
			clDatiUpDb.Add(pDataAssegnazioneEnd);
			
			S_Object pDataCompletamentoIn = new S_Object();
			pDataCompletamentoIn.ParameterName = "P_DATA_COMPLETAMENTO_INIT";
			pDataCompletamentoIn.DbType = CustomDBType.VarChar;
			pDataCompletamentoIn.Direction = ParameterDirection.Input;
			pDataCompletamentoIn.Size = 10;
			pDataCompletamentoIn.Index = pIndex++;
			pDataCompletamentoIn.Value = cldpkDaCompletamento.Datazione.Text;
			clDatiUpDb.Add(pDataCompletamentoIn);

			S_Object pDataCompletamentoEnd = new S_Object();
			pDataCompletamentoEnd.ParameterName = "P_DATA_COMPLETAMENTO_END";
			pDataCompletamentoEnd.DbType = CustomDBType.VarChar;
			pDataCompletamentoEnd.Direction = ParameterDirection.Input;
			pDataCompletamentoEnd.Size = 10;
			pDataCompletamentoEnd.Index = pIndex++;
			pDataCompletamentoEnd.Value = cldpkACompletamento.Datazione.Text;
			clDatiUpDb.Add(pDataCompletamentoEnd);

			       S_Object pComune = new S_Object();
			                                        pComune.ParameterName = "P_COMUNE";
			pComune.DbType = CustomDBType.VarChar;
			pComune.Direction = ParameterDirection.Input;
			pComune.Size = 64;
			pComune.Index = pIndex++;
			pComune.Value = comune;//S_cmbComune.SelectedItem.Text;
			clDatiUpDb.Add(pComune);

			S_Object pEdificio = new S_Object();
			pEdificio.ParameterName = "P_EDIFICIO";
			pEdificio.DbType = CustomDBType.VarChar;
			pEdificio.Direction = ParameterDirection.Input;
			pEdificio.Size = 255;
			pEdificio.Index = pIndex++;
			pEdificio.Value = edificio; //S_cmbEdificio.SelectedItem.Text;
			clDatiUpDb.Add(pEdificio);

			S_Object  pDitta = new S_Object();
			pDitta.ParameterName = "P_DITTA";
			pDitta.DbType = CustomDBType.VarChar;
			pDitta.Direction = ParameterDirection.Input;
			pDitta.Size = 32;
			pDitta.Index = pIndex++;
			pDitta.Value = ditta; //S_cmbDitta.SelectedItem.Text;
			clDatiUpDb.Add(pDitta);

			S_Object pCategoria = new S_Object();
			pCategoria.ParameterName = "P_CATEGORIA";
			pCategoria.DbType = CustomDBType.VarChar;
			pCategoria.Direction = ParameterDirection.Input;
			pCategoria.Size = 32;
			pCategoria.Index = pIndex++;
			pCategoria.Value =  categoria;//S_cmbCategoria.SelectedItem.Text;
			clDatiUpDb.Add(pCategoria);

			S_Object pAddetto = new S_Object();
			pAddetto.ParameterName = "P_ADDETTO";
			pAddetto.DbType = CustomDBType.VarChar;
			pAddetto.Direction = ParameterDirection.Input;
			pAddetto.Size = 128;
			pAddetto.Index = pIndex++;
			pAddetto.Value = addetto; //S_cmbAddetto.SelectedItem.Text;
			clDatiUpDb.Add(pAddetto);

			S_Object pSoloNonCompletate = new S_Object();
			pSoloNonCompletate.ParameterName = "P_SOLO_NON_COMPLETATE";
			pSoloNonCompletate.DbType = CustomDBType.VarChar;
			pSoloNonCompletate.Direction = ParameterDirection.Input;
			pSoloNonCompletate.Size = 8;
			pSoloNonCompletate.Index = pIndex++;
			pSoloNonCompletate.Value = S_optSolNonComp.Checked.ToString();
			clDatiUpDb.Add(pSoloNonCompletate);

			S_Object pSoloCompletate = new S_Object();
			pSoloCompletate.ParameterName = "P_SOLO_COMPLETATE";
			pSoloCompletate.DbType = CustomDBType.VarChar;
			pSoloCompletate.Direction = ParameterDirection.Input;
			pSoloCompletate.Size = 8;
			pSoloCompletate.Index = pIndex++;
			pSoloCompletate.Value = S_optSolComp.Checked.ToString();
			clDatiUpDb.Add(pSoloCompletate);

			S_Object pDataDiCompletamento = new S_Object();
			pDataDiCompletamento.ParameterName ="P_DATA_DI_COMPLETAMENTO";
			pDataDiCompletamento.DbType = CustomDBType.VarChar;
			pDataDiCompletamento.Direction = ParameterDirection.Input;
			pDataDiCompletamento.Size = 8;
			pDataDiCompletamento.Index = pIndex++;
			pDataDiCompletamento.Value =  S_optDataComp.Checked.ToString();
			clDatiUpDb.Add(pDataDiCompletamento);

			S_Object pDimensioneFile = new S_Object();
			pDimensioneFile.ParameterName = "P_DIMENSIONE_FILE";
			pDimensioneFile.DbType = CustomDBType.Integer;
			pDimensioneFile.Direction = ParameterDirection.Input;
			pDimensioneFile.Size = 32;
			pDimensioneFile.Index = pIndex++;
			pDimensioneFile.Value =DBNull.Value;
			clDatiUpDb.Add(pDimensioneFile);

			S_Object pDimensioneFileZip = new S_Object();
			pDimensioneFileZip.ParameterName = "P_DIMENSIONE_FILE_ZIP";
			pDimensioneFileZip.DbType = CustomDBType.Integer;
			pDimensioneFileZip.Direction = ParameterDirection.Input;
			pDimensioneFileZip.Size = 32;
			pDimensioneFileZip.Index = pIndex++;
			pDimensioneFileZip.Value =DBNull.Value;
			clDatiUpDb.Add(pDimensioneFileZip);

			S_Object pOdlSelezionati = new S_Object();
			pOdlSelezionati.ParameterName = "P_INTERVALLO_ODL_SELEZIONATI";
			pOdlSelezionati.DbType = CustomDBType.VarChar;
			pOdlSelezionati.Direction = ParameterDirection.Input;
			pOdlSelezionati.Size = 256;
			pOdlSelezionati.Index = pIndex++;
			pOdlSelezionati.Value = quantitaOdl; // strOdl.Replace(",","-");
			clDatiUpDb.Add(pOdlSelezionati);

			S_Object pTipologiaReport = new S_Object();
			pTipologiaReport.ParameterName = "P_TIPOLOGIA_REPORT";
			pTipologiaReport.DbType = CustomDBType.VarChar;
			pTipologiaReport.Direction = ParameterDirection.Input;
			pTipologiaReport.Size = 16;
			pTipologiaReport.Index = pIndex++;
			pTipologiaReport.Value = tipRpt;
            clDatiUpDb.Add(pTipologiaReport);

			S_Object pDimensionePdfZip  = new S_Object();
			pDimensionePdfZip.ParameterName = "p_DIMENSIONEFILE_PDF_ZIP";
			pDimensionePdfZip.DbType = CustomDBType.VarChar;
			pDimensionePdfZip.Direction = ParameterDirection.Input;
			pDimensionePdfZip.Size = 128;
			pDimensionePdfZip.Index = pIndex++;
			pDimensionePdfZip.Value = DBNull.Value;
			clDatiUpDb.Add(pDimensionePdfZip);

			S_Object pCompletate = new S_Object();
			pCompletate.ParameterName = "p_COMPLETATE";
			pCompletate.DbType = CustomDBType.VarChar;
			pCompletate.Direction = ParameterDirection.Input;
			pCompletate.Size = 128;
			pCompletate.Index = pIndex++;
			pCompletate.Value = DBNull.Value;//completate;
			clDatiUpDb.Add(pCompletate);

			S_Object pDataAssInOut = new S_Object();
			pDataAssInOut.ParameterName = "P_Data_ass_in_out";
			pDataAssInOut.DbType = CustomDBType.VarChar;
			pDataAssInOut.Direction = ParameterDirection.Input;
			pDataAssInOut.Size = 30;
			pDataAssInOut.Index = pIndex++;
			pDataAssInOut.Value = DBNull.Value;// dataAssInOut;
			clDatiUpDb.Add(pDataAssInOut);

			
			io_db.NameProcedureDb = "RapportiPdf.inserisciTabellaDwn";
			int result = io_db.Add(clDatiUpDb);
			return result;
		
		}

		private int[] insertNormTblDb(string [] arOdl,int idFile)
		{
		
			int n = arOdl.Length;
			//Array arResult =Array.CreateInstance( Type.GetType("System.Int32"), 5 );
			int[] arResult = new int[n];
			arResult.Initialize();
			for(int i =0; i<arOdl.Length ; i++)
			{
				AgganciaDatalayer io_db  = new AgganciaDatalayer();
				S_ControlsCollection clDatiUpDb = new S_ControlsCollection();
				int pIndex=0;

				S_Object pIddFile = new S_Object();
				pIddFile.ParameterName = "p_idFile";
				pIddFile.DbType = CustomDBType.Integer;
				pIddFile.Direction = ParameterDirection.Input;
				pIddFile.Size = 16;
				pIddFile.Index = pIndex++;
				pIddFile.Value = idFile;
				clDatiUpDb.Add(pIddFile);

				S_Object pOdl = new S_Object();
				pOdl.ParameterName = "p_Odl";
				pOdl.DbType = CustomDBType.Integer;
				pOdl.Direction = ParameterDirection.Input;
				pOdl.Size = 16;
				pOdl.Index = pIndex++;
				pOdl.Value = arOdl[i];
				clDatiUpDb.Add(pOdl);
				io_db.NameProcedureDb="RapportiPdf.inserisciTblNorm";
				int result = io_db.Add(clDatiUpDb);
				arResult[i] = result;
			}
			return arResult;
		}
		private int updateDb(int nOdl,int idFile)
		{
			string dimensionePdfZip = dimensioneFile(nOdl,idFile,".pdf").ToString()+
										"/" +
										dimensioneFile(nOdl,idFile,".zip").ToString();
			string completate = string.Empty;;
			if(S_optDataComp.Checked )
			{
				completate= "Si con date";
			}
			if(S_optSolComp.Checked )
			{
				completate = "Si";
			}
			if(S_optSolNonComp.Checked )
			{
				completate = "No";
			}
			string dataAssInOut =  cldpkDaAssegnazione.Datazione.Text + 
				" - " + cldpkAAssegnazione.Datazione.Text
				;
			int pIndex =0;
			AgganciaDatalayer io_db  = new AgganciaDatalayer();
			S_ControlsCollection clDatiUpDb = new S_ControlsCollection();

			S_Object pNomeFile = new S_Object();
			pNomeFile.ParameterName = "p_NOME_FILE";
			pNomeFile.DbType = CustomDBType.VarChar;
			pNomeFile.Direction = ParameterDirection.Input;
			pNomeFile.Size = 128;
			pNomeFile.Index = pIndex;
			pNomeFile.Value = creaNomeFile(nOdl,idFile);
			clDatiUpDb.Add(pNomeFile);

			S_Object pDataAssegnazioneIn = new S_Object();
			pDataAssegnazioneIn.ParameterName = "P_DATA_ASSEGNAZIONE_INIT";
			pDataAssegnazioneIn.DbType = CustomDBType.VarChar;
			pDataAssegnazioneIn.Direction = ParameterDirection.Input;
			pDataAssegnazioneIn.Size = 10;
			pDataAssegnazioneIn.Index =  pIndex++;
			pDataAssegnazioneIn.Value = DBNull.Value;
			clDatiUpDb.Add(pDataAssegnazioneIn);

			S_Object pDataAssegnazioneEnd = new S_Object();
			pDataAssegnazioneEnd.ParameterName = "P_DATA_ASSEGNAZIONE_END";
			pDataAssegnazioneEnd.DbType = CustomDBType.VarChar;
			pDataAssegnazioneEnd.Direction = ParameterDirection.Input;
			pDataAssegnazioneEnd.Size = 10;
			pDataAssegnazioneEnd.Index = pIndex++;
			pDataAssegnazioneEnd.Value = DBNull.Value;
			clDatiUpDb.Add(pDataAssegnazioneEnd);
			
			S_Object pDataCompletamentoIn = new S_Object();
			pDataCompletamentoIn.ParameterName = "P_DATA_COMPLETAMENTO_INIT";
			pDataCompletamentoIn.DbType = CustomDBType.VarChar;
			pDataCompletamentoIn.Direction = ParameterDirection.Input;
			pDataCompletamentoIn.Size = 10;
			pDataCompletamentoIn.Index = pIndex++;
			pDataCompletamentoIn.Value = DBNull.Value;
			clDatiUpDb.Add(pDataCompletamentoIn);

			S_Object pDataCompletamentoEnd = new S_Object();
			pDataCompletamentoEnd.ParameterName = "P_DATA_COMPLETAMENTO_END";
			pDataCompletamentoEnd.DbType = CustomDBType.VarChar;
			pDataCompletamentoEnd.Direction = ParameterDirection.Input;
			pDataCompletamentoEnd.Size = 10;
			pDataCompletamentoEnd.Index = pIndex++;
			pDataCompletamentoEnd.Value = DBNull.Value;
			clDatiUpDb.Add(pDataCompletamentoEnd);

			S_Object pComune = new S_Object();
			pComune.ParameterName = "P_COMUNE";
			pComune.DbType = CustomDBType.VarChar;
			pComune.Direction = ParameterDirection.Input;
			pComune.Size = 64;
			pComune.Index = pIndex++;
			pComune.Value = DBNull.Value;
			clDatiUpDb.Add(pComune);

			S_Object pEdificio = new S_Object();
			pEdificio.ParameterName = "P_EDIFICIO";
			pEdificio.DbType = CustomDBType.VarChar;
			pEdificio.Direction = ParameterDirection.Input;
			pEdificio.Size = 255;
			pEdificio.Index = pIndex++;
			pEdificio.Value = DBNull.Value;
			clDatiUpDb.Add(pEdificio);

			S_Object  pDitta = new S_Object();
			pDitta.ParameterName = "P_DITTA";
			pDitta.DbType = CustomDBType.VarChar;
			pDitta.Direction = ParameterDirection.Input;
			pDitta.Size = 32;
			pDitta.Index = pIndex++;
			pDitta.Value = DBNull.Value;
			clDatiUpDb.Add(pDitta);

			S_Object pCategoria = new S_Object();
			pCategoria.ParameterName = "P_CATEGORIA";
			pCategoria.DbType = CustomDBType.VarChar;
			pCategoria.Direction = ParameterDirection.Input;
			pCategoria.Size = 32;
			pCategoria.Index = pIndex++;
			pCategoria.Value = DBNull.Value;
			clDatiUpDb.Add(pCategoria);

			S_Object pAddetto = new S_Object();
			pAddetto.ParameterName = "P_ADDETTO";
			pAddetto.DbType = CustomDBType.VarChar;
			pAddetto.Direction = ParameterDirection.Input;
			pAddetto.Size = 128;
			pAddetto.Index = pIndex++;
			pAddetto.Value = DBNull.Value;
			clDatiUpDb.Add(pAddetto);

			S_Object pSoloNonCompletate = new S_Object();
			pSoloNonCompletate.ParameterName = "P_SOLO_NON_COMPLETATE";
			pSoloNonCompletate.DbType = CustomDBType.VarChar;
			pSoloNonCompletate.Direction = ParameterDirection.Input;
			pSoloNonCompletate.Size = 8;
			pSoloNonCompletate.Index = pIndex++;
			pSoloNonCompletate.Value = DBNull.Value;
			clDatiUpDb.Add(pSoloNonCompletate);

			S_Object pSoloCompletate = new S_Object();
			pSoloCompletate.ParameterName = "P_SOLO_COMPLETATE";
			pSoloCompletate.DbType = CustomDBType.VarChar;
			pSoloCompletate.Direction = ParameterDirection.Input;
			pSoloCompletate.Size = 8;
			pSoloCompletate.Index = pIndex++;
			pSoloCompletate.Value = DBNull.Value;
			clDatiUpDb.Add(pSoloCompletate);

			S_Object pDataDiCompletamento = new S_Object();
			pDataDiCompletamento.ParameterName ="P_DATA_DI_COMPLETAMENTO";
			pDataDiCompletamento.DbType = CustomDBType.VarChar;
			pDataDiCompletamento.Direction = ParameterDirection.Input;
			pDataDiCompletamento.Size = 8;
			pDataDiCompletamento.Index = pIndex++;
			pDataDiCompletamento.Value =  DBNull.Value;
			clDatiUpDb.Add(pDataDiCompletamento);

			S_Object pDimensioneFile = new S_Object();
			pDimensioneFile.ParameterName = "P_DIMENSIONE_FILE";
			pDimensioneFile.DbType = CustomDBType.Integer;
			pDimensioneFile.Direction = ParameterDirection.Input;
			pDimensioneFile.Size = 32;
			pDimensioneFile.Index = pIndex++;
			pDimensioneFile.Value =dimensioneFile(nOdl,idFile,".pdf");
			clDatiUpDb.Add(pDimensioneFile);

			S_Object pDimensioneFileZip = new S_Object();
			pDimensioneFileZip.ParameterName = "P_DIMENSIONE_FILE_ZIP";
			pDimensioneFileZip.DbType = CustomDBType.Integer;
			pDimensioneFileZip.Direction = ParameterDirection.Input;
			pDimensioneFileZip.Size = 32;
			pDimensioneFileZip.Index = pIndex++;
			pDimensioneFileZip.Value =dimensioneFile(nOdl,idFile,".zip");
			clDatiUpDb.Add(pDimensioneFileZip);


			S_Object pOdlSelezionati = new S_Object();
			pOdlSelezionati.ParameterName = "P_INTERVALLO_ODL_SELEZIONATI";
			pOdlSelezionati.DbType = CustomDBType.VarChar;
			pOdlSelezionati.Direction = ParameterDirection.Input;
			pOdlSelezionati.Size = 256;
			pOdlSelezionati.Index = pIndex++;
			pOdlSelezionati.Value = DBNull.Value;
			clDatiUpDb.Add(pOdlSelezionati);

			S_Object pTipologiaReport = new S_Object();
			pTipologiaReport.ParameterName = "P_TIPOLOGIA_REPORT";
			pTipologiaReport.DbType = CustomDBType.VarChar;
			pTipologiaReport.Direction = ParameterDirection.Input;
			pTipologiaReport.Size = 16;
			pTipologiaReport.Index = pIndex++;
			pTipologiaReport.Value = DBNull.Value;
			clDatiUpDb.Add(pTipologiaReport);

			S_Object pDimensionePdfZip  = new S_Object();
			pDimensionePdfZip.ParameterName = "p_DIMENSIONEFILE_PDF_ZIP";
			pDimensionePdfZip.DbType = CustomDBType.VarChar;
			pDimensionePdfZip.Direction = ParameterDirection.Input;
			pDimensionePdfZip.Size = 128;
			pDimensionePdfZip.Index = pIndex++;
			pDimensionePdfZip.Value = dimensionePdfZip;
			clDatiUpDb.Add(pDimensionePdfZip);

			S_Object pCompletate = new S_Object();
			pCompletate.ParameterName = "p_COMPLETATE";
			pCompletate.DbType = CustomDBType.VarChar;
			pCompletate.Direction = ParameterDirection.Input;
			pCompletate.Size = 128;
			pCompletate.Index = pIndex++;
			pCompletate.Value = completate;
			clDatiUpDb.Add(pCompletate);

			S_Object pDataAssInOut = new S_Object();
			pDataAssInOut.ParameterName = "P_Data_ass_in_out";
			pDataAssInOut.DbType = CustomDBType.VarChar;
			pDataAssInOut.Direction = ParameterDirection.Input;
			pDataAssInOut.Size = 30;
			pDataAssInOut.Index = pIndex++;
			pDataAssInOut.Value = dataAssInOut;
			clDatiUpDb.Add(pDataAssInOut);

			io_db.NameProcedureDb = "RapportiPdf.inserisciTabellaDwn";
			int result = io_db.Update(clDatiUpDb,idFile);
			return result;

		}
		private long dimensioneFile(int nOdl,int idFile, string estensioneFile)
		{
			string percosoAssolutoFile = null;
			string[] DirectoryName = ((string[])( System.Configuration.ConfigurationSettings.AppSettings.GetValues("DirectoryStampa")));
			percosoAssolutoFile = Server.MapPath(DirectoryName[0])+ creaNomeFile(nOdl,idFile)+ estensioneFile;
			FileInfo fi = new FileInfo(percosoAssolutoFile);
			long size = fi.Length;
		    return size; 
		}
		private void stampaRpt(int nOdl,int idFile)
		{
			RptPdf.DatasetReport ds;
			ds = riempiDatasetStampa(idFile);
			stampaPdf(ds,nOdl,idFile);
			creaZip(nOdl,idFile);
		}
		private void stampaPdf(TheSite.StampaRapportiPDF.Schemixsd.DatasetReport ds,int nOdl,int idFile)
		{
			MP_Rapporti_C_MP_long_r6 rptLong = new MP_Rapporti_C_MP_long_r6();
			MP_Rapporti_C_MP_r6 rptShort = new MP_Rapporti_C_MP_r6();
			string[] DirectoryName = ((string[])( System.Configuration.ConfigurationSettings.AppSettings.GetValues("DirectoryStampa")));
			StampaSuDisco StampaPdf = new StampaSuDisco(Server.MapPath(DirectoryName[0]));

			string nomeFile= creaNomeFile(nOdl,idFile);
			switch(tipologiaReport())
			{
				case 0:
					rptShort.SetDataSource(ds);
					StampaPdf.StampaPdf(rptShort,nomeFile);
					break;
				case 1:
					rptLong.SetDataSource(ds);
					StampaPdf.StampaPdf(rptLong,nomeFile);
					break;
				default:
					throw new Exception();
					//break;
			}
			
			
		}
		private void creaZip(int nOdl,int idFile)
		{
			string[] DirectoryName = ((string[])( System.Configuration.ConfigurationSettings.AppSettings.GetValues("DirectoryStampa")));
			string baseFile = creaNomeFile(nOdl,idFile);
			string filePdf = baseFile + ".pdf";
			string assolutoFileZip = Server.MapPath(DirectoryName[0]) + baseFile + ".zip";
			FastZip makeZipFile = new FastZip();
			makeZipFile.CreateZip(assolutoFileZip,Server.MapPath(DirectoryName[0]),true,filePdf);
		}

		private string creaNomeFile(int nOdl, int idFile)
		{
			string strFile = null;
			strFile = "id_" + idFile.ToString();
			strFile += "-nOdl_"+ nOdl.ToString();
			if(S_cmbEdificio.SelectedItem.Text != "")
			{
				strFile += "-" 
					+ S_cmbEdificio.SelectedItem.Value.ToString().Trim().Replace(" ","_");
			}			
			if(S_optDataComp.Checked)
			{
				strFile += "-con_data_cmp_assgn";
			}
			else if(S_optSolComp.Checked)
			{
				strFile +="-Solo_Cmplt";
			}
			else if(S_optSolNonComp.Checked)
			{
				strFile += "-Solo_non_cmplt";
			}
			else 
			{
				throw new Exception();
			}
			if(S_optLungo.Checked)
			{
				strFile += "-rpt_lng";
			}
			else if(S_optRptCorto.Checked)
			{
				strFile += "-rpt_crt";
			}
			else 
			{
				throw new Exception();
			}
			return strFile;
		}

		private TheSite.StampaRapportiPDF.Schemixsd.DatasetReport riempiDatasetStampa(int idFile)
		{
			AgganciaDatalayer io_db  = new AgganciaDatalayer();
			S_Controls.Collections.S_ControlsCollection clDatiStampa = new S_Controls.Collections.S_ControlsCollection();

			S_Object pOdl = new S_Object();
			pOdl.ParameterName = "PNormId";
			pOdl.DbType = CustomDBType.Integer;
			pOdl.Direction = ParameterDirection.Input;
			pOdl.Size = 255;
			pOdl.Index = 0;
			pOdl.Value = idFile;
			clDatiStampa.Add(pOdl);

			S_Object Cursor = new S_Object();
			Cursor.ParameterName = "RSCursor";
			Cursor.DbType =  CustomDBType.Cursor;
			Cursor.Direction = ParameterDirection.Output;
			Cursor.Index = clDatiStampa.Count + 1;
			clDatiStampa.Add(Cursor);

			io_db.NameProcedureDb = "RapportiPdf.get_data_reports";
			DataSet dsDatiStampa = io_db.GetData(clDatiStampa).Copy();

			RptPdf.DatasetReport DsTipizzato = new RptPdf.DatasetReport();
			int i=0;

			for(i=0; i<=dsDatiStampa.Tables[0].Rows.Count-1;i++)
			{ 
				DsTipizzato.Tables["MP_REPORT_LONG"].ImportRow(dsDatiStampa.Tables[0].Rows[i]);
			}
			if(i==0)
			{
				throw new Exception("* Non ci sono Rdl nell'intervallo temporale che hai selezionato, cambia intervallo e riprova.");
			}
			return DsTipizzato;
		}

		private void S_btnSelezionaTutto_Click(object sender, System.EventArgs e)
		{
			SelezionaTutti(true);
		}

		private void S_btnDeselezioneTutto_Click(object sender, System.EventArgs e)
		{
			SelezionaTutti(false);
		}
		private void SelezionaTutti(bool val)
		{	
			RptPdf.DatasetReport ds;
			ds = riempiDatasetRicerca();
			if(!val)
			{
				Session.Remove("CheckedList");
				Session.Remove("DatiList");
				lblElementiSelezionati.Text="Elementi Selezionati - 0 -";
				EnableControl(false);
				//txtTotSelezionati.Text="0";
			}
			else
			{				
				SetControlli();										
			}
			
			for(int Pagine = 0;Pagine<=DataGridRicerca.PageCount;Pagine++)
			{
	
		
				DataGridRicerca.DataSource= ds.Tables["Data_Report_Ricerca"];//Session["DataSet"];
				DataGridRicerca.DataBind();
				DataGridRicerca.CurrentPageIndex=Pagine;									
							
				SetDati(val);
				
				if(val)
				{	
					SetControlli();				
				}
			}

			DataGridRicerca.CurrentPageIndex=0;
			DataGridRicerca.DataSource= ds.Tables["Data_Report_Ricerca"];;
			DataGridRicerca.DataBind();			
			GetControlli();						
		}
		private void SetDati(bool val)
		{	
			Hashtable _HS = new Hashtable();
			int indice = 0;
		
			if(Session["DatiList"]!=null)
			{
				_HS=(Hashtable) Session["DatiList"];				
			}

					
			foreach(DataGridItem o_Litem in DataGridRicerca.Items)
			{								
				indice = Int32.Parse(o_Litem.Cells[1].Text);									
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel");																									
				cb.Checked=val;
				if(_HS.ContainsKey(indice))
					_HS.Remove(indice);												
							
				if(cb.Checked)
				{
					_HS.Add(indice, indice);		
				}
			}			
			
			Session.Remove("DatiList");
			Session.Add("DatiList",_HS);			
			lblElementiSelezionati.Text="Elementi Selezionati - " + _HS.Count.ToString() + " -";
			if(_HS.Count>0)
				EnableControl(true);
			else
				EnableControl(false);

			//txtTotSelezionati.Text=_HS.Count.ToString();			
		}
	}

}
