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
//using StampaRapportiPdf;
//using StampaRapportiPdf.Schemixsd;
using S_Controls.Collections;
using S_Controls;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
//using StampaRapportiPdf.Classi;
//using StampaRapportiPdf.WebControls;
using System.IO;
using System.Text;
//using TheSite.Classi;
using TheSite.Classi.CostiGesioneCumulativi;



namespace TheSite.CostiGesioneCumulativi
{
	/// <summary>
	/// Descrizione di riepilogo per Pagina_Download_Cumulativi.
	/// </summary>
	public class Pagina_Download_Cumulativi : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected S_Controls.S_Button S_btnRicerca;
		protected WebControls.PageTitle pgtlDownoloadStampe;
		protected System.Web.UI.WebControls.Label lblId;
		protected System.Web.UI.WebControls.LinkButton lnkChiudi;
		protected System.Web.UI.WebControls.Panel pnlShowInfo;
		protected System.Web.UI.WebControls.Label LABEL18;
		protected System.Web.UI.WebControls.Label LABEL19;
		protected System.Web.UI.WebControls.Label LABEL20;
		protected System.Web.UI.WebControls.Label LABEL21;
		protected System.Web.UI.WebControls.Label LABEL24;
		protected System.Web.UI.WebControls.Label LABEL25;
		protected System.Web.UI.WebControls.Label LABEL26;
		protected System.Web.UI.WebControls.Label LABEL27;
		protected System.Web.UI.WebControls.Label LABEL28;
		protected System.Web.UI.WebControls.Label lblIntestazione;
		protected System.Web.UI.WebControls.Label lblDataDiCreazione;
		protected System.Web.UI.WebControls.Label lblEdificio;
		protected System.Web.UI.WebControls.Label lblComune;
		protected System.Web.UI.WebControls.Label lblAddetto;
		protected System.Web.UI.WebControls.Label lblDimensioneFilePdf;
		protected System.Web.UI.WebControls.Label lblC11;
		protected System.Web.UI.WebControls.Label lblDimensioneFileZip;
		protected System.Web.UI.WebControls.Label Label1;
		protected S_Controls.S_Button S_btnEliminaTiitiFile;
		protected WebControls.GridTitle GridTitleDownLoad;
		protected System.Web.UI.WebControls.Label LABEL22;
		protected System.Web.UI.WebControls.Label lblDitta;
		protected System.Web.UI.WebControls.Label lblRichiestaLavoro;
		protected System.Web.UI.WebControls.Label lblIntervalloRdl;
		protected System.Web.UI.WebControls.Label lblOdl;
		protected System.Web.UI.WebControls.Label lblUrgenza;
		protected System.Web.UI.WebControls.Label lblStatoRichiesta;
		protected System.Web.UI.WebControls.Label LABEL23;
		protected System.Web.UI.WebControls.Label lblDataDa;
		protected System.Web.UI.WebControls.Label LABEL2;
		protected System.Web.UI.WebControls.Label lblDataA;
		protected System.Web.UI.WebControls.Label LABEL3;
		protected System.Web.UI.WebControls.Label LABEL4;
		protected System.Web.UI.WebControls.Label LABEL5;
		protected System.Web.UI.WebControls.Label lblRichiedenti;
		protected System.Web.UI.WebControls.Label lblGruppo;
		protected System.Web.UI.WebControls.Label lblServizio;
		protected System.Web.UI.WebControls.Label LABEL6;
		protected System.Web.UI.WebControls.Label lblTipoManutenzione;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label lblDataPrevistaInizio;
		protected System.Web.UI.WebControls.Label lblDataPrevistaFine;
		public static string HelpLink = string.Empty;
		CostiGesioneCumulativi.AnalisiCostiOperativiDiGestioneCumulativo _fp;


		public clMyCollection _Contenitore
		{
			get 
			{
				if(this.ViewState["mioContenitore"]!=null)
					return (clMyCollection)this.ViewState["mioContenitore"];
				else
					return new clMyCollection();
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				if(Context.Handler is CostiGesioneCumulativi.AnalisiCostiOperativiDiGestioneCumulativo)
				{
					_fp = (CostiGesioneCumulativi.AnalisiCostiOperativiDiGestioneCumulativo) Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore);				
				}
			}

			TheSite.Classi.SiteModule _SiteModule = (TheSite.Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			HelpLink = _SiteModule.HelpLink;
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			pgtlDownoloadStampe.MainTitle = "Download Rapporto Interventi Cumulativo".ToUpper();
			GridTitleDownLoad.hplsNuovo.Visible= false;
			caricaDataGridRicerca();
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
			this.S_btnRicerca.Click += new System.EventHandler(this.S_btnRicerca_Click);
			this.S_btnEliminaTiitiFile.Click += new System.EventHandler(this.S_btnEliminaTiitiFile_Click);
			this.lnkChiudi.Click += new System.EventHandler(this.lnkChiudi_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void caricaDataGridRicerca()
		{
			
	
			//DataGridRicerca.CurrentPageIndex = 0;
			if(DataGridRicerca.Items.Count == 1  && DataGridRicerca.CurrentPageIndex !=0)
			{
				DataGridRicerca.CurrentPageIndex--;
			}
			else if(DataGridRicerca.Items.Count ==1)
			{
				DataGridRicerca.CurrentPageIndex = 0;
			}
			
			ricerca();
		}
		private void ricerca()
		{
			DataSet ds;
			ds = riempiDatasetDownload();
			GridTitleDownLoad.NumeroRecords = Convert.ToString(ds.Tables[0].Rows.Count );
			DataGridRicerca.DataSource = ds.Tables[0];
			DataGridRicerca.DataBind();
		}
		private DataSet riempiDatasetDownload()
		{
			AgganciaDatalayer io_db  = new AgganciaDatalayer();
			S_ControlsCollection clDatiRicerca = new S_ControlsCollection();


			S_Object Cursor = new S_Object();
			Cursor.ParameterName = "RSCursor";
			Cursor.DbType =  CustomDBType.Cursor;
			Cursor.Direction = ParameterDirection.Output;
			Cursor.Index = 0;
			clDatiRicerca.Add(Cursor);

			
			io_db.NameProcedureDb = "pack_CostiGestioneCumulativi.get_Download_Reports_An_Co_Op";
			DataSet dsDatiRicerca = io_db.GetData(clDatiRicerca).Copy();

			//			DatasetReport DsTipizzato = new DatasetReport();
			//			int i=0;
			//			for(i=0; i<=dsDatiRicerca.Tables[0].Rows.Count-1;i++)
			//			{ 
			//				DsTipizzato.Tables["DownloadFile"].ImportRow(dsDatiRicerca.Tables[0].Rows[i]);
			//			}
			//
			//			if(i==0)
			//			{
			//			 	
			//			}
			return dsDatiRicerca;

		}
		private void S_btnRicerca_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("AnalisiCostiOperativiDiGestioneCumulativo.aspx");
		}
		private void DataGridRicerca_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
			ricerca();
		}

		protected void imgBtnVisualizza_Click(Object sender , CommandEventArgs e)
		{
			Context.Items.Add("nome_file",(string)e.CommandArgument);
			Server.Transfer("VisualizzaRapportoTecnicoInterventoCumulativo.aspx");
		}
		protected void imgBtnElimina_Click(object sender, CommandEventArgs e)
		{
			string[] arrDatagridIthem  =  Convert.ToString(e.CommandArgument).Split(Convert.ToChar(","));
			int idFile = Convert.ToInt32(arrDatagridIthem[0].ToString());
			string nomeFile = arrDatagridIthem[1].ToString();

			int idFileDlete = deleteDb(idFile);
			//deleteTblNorm(idFile);
			if(idFile != idFileDlete)
			{
				throw new Exception();
			}
			elininaFile(nomeFile);
			caricaDataGridRicerca();
			
		}


		#region Metodi per eliminazione record dal db e file dal filesystem
		private int deleteDb(int idFile)
		{
			int pIndex =0;
			AgganciaDatalayer io_db  = new AgganciaDatalayer();
			S_ControlsCollection clDatiUpDb = new S_ControlsCollection();

			S_Object pNomeFile = new S_Object();
			pNomeFile.ParameterName = "p_NOME_FILE";
			pNomeFile.DbType = CustomDBType.VarChar;
			pNomeFile.Direction = ParameterDirection.Input;
			pNomeFile.Index = pIndex++;
			pNomeFile.Value =DBNull.Value;;
			clDatiUpDb.Add(pNomeFile);

			S_Object pStringaRdl = new S_Object();
			pStringaRdl.ParameterName = "P_STRINGARDL";
			pStringaRdl.DbType = CustomDBType.VarChar;
			pStringaRdl.Direction = ParameterDirection.Input;
			pStringaRdl.Index = pIndex++;
			pStringaRdl.Value = DBNull.Value;;
			clDatiUpDb.Add(pStringaRdl);
		

			S_Object pDataCreated = new S_Object();
			pDataCreated.ParameterName = "P_DATA_CREATED";
			pDataCreated.DbType = CustomDBType.VarChar;
			pDataCreated.Direction = ParameterDirection.Input;
			pDataCreated.Index = pIndex++;
			pDataCreated.Value =DBNull.Value;;
			clDatiUpDb.Add(pDataCreated);

			S_Object pDataAssegnazioneIn = new S_Object();
			pDataAssegnazioneIn.ParameterName = "P_DATA_ASSEGNAZIONE_INIT";
			pDataAssegnazioneIn.DbType = CustomDBType.VarChar;
			pDataAssegnazioneIn.Direction = ParameterDirection.Input;
			pDataAssegnazioneIn.Index =  pIndex++;
			pDataAssegnazioneIn.Value = DBNull.Value;////DBNull.Value;
			clDatiUpDb.Add(pDataAssegnazioneIn);

			S_Object pDataAssegnazioneEnd = new S_Object();
			pDataAssegnazioneEnd.ParameterName = "P_DATA_ASSEGNAZIONE_END";
			pDataAssegnazioneEnd.DbType = CustomDBType.VarChar;
			pDataAssegnazioneEnd.Direction = ParameterDirection.Input;
			pDataAssegnazioneEnd.Index = pIndex++;
			pDataAssegnazioneEnd.Value =  DBNull.Value;////DBNull.Value;
			clDatiUpDb.Add(pDataAssegnazioneEnd);
			
			S_Object pDataCompletamentoIn = new S_Object();
			pDataCompletamentoIn.ParameterName = "P_DATA_COMPLETAMENTO_INIT";
			pDataCompletamentoIn.DbType = CustomDBType.VarChar;
			pDataCompletamentoIn.Direction = ParameterDirection.Input;
			pDataCompletamentoIn.Index = pIndex++;
			pDataCompletamentoIn.Value =  DBNull.Value;////DBNull.Value;
			clDatiUpDb.Add(pDataCompletamentoIn);

			S_Object pDataCompletamentoEnd = new S_Object();
			pDataCompletamentoEnd.ParameterName = "P_DATA_COMPLETAMENTO_END";
			pDataCompletamentoEnd.DbType = CustomDBType.VarChar;
			pDataCompletamentoEnd.Direction = ParameterDirection.Input;
			pDataCompletamentoEnd.Index = pIndex++;
			pDataCompletamentoEnd.Value =  DBNull.Value;////DBNull.Value;
			clDatiUpDb.Add(pDataCompletamentoEnd);

			S_Object pEdificio = new S_Object();
			pEdificio.ParameterName = "P_EDIFICIO";
			pEdificio.DbType = CustomDBType.VarChar;
			pEdificio.Direction = ParameterDirection.Input;
			pEdificio.Size=8;
			pEdificio.Index = pIndex++;
			pEdificio.Value =  DBNull.Value;;//S_cmbComune.SelectedItem.Text;
			clDatiUpDb.Add(pEdificio);

			S_Object pRichiestaLavoro = new S_Object();
			pRichiestaLavoro.ParameterName = "P_RICHIESTA_DI_LAVORO";
			pRichiestaLavoro.DbType = CustomDBType.Integer;
			pRichiestaLavoro.Direction = ParameterDirection.Input;
			pRichiestaLavoro.Index = pIndex++;
			pRichiestaLavoro.Value =  DBNull.Value;//txtsRichiesta.Text; //S_cmbEdificio.SelectedItem.Text;
			clDatiUpDb.Add(pRichiestaLavoro);

			S_Object  pAddetto = new S_Object();
			pAddetto.ParameterName = "P_ADDETTO";
			pAddetto.DbType = CustomDBType.VarChar;
			pAddetto.Direction = ParameterDirection.Input;
			pAddetto.Index = pIndex++;
			pAddetto.Value =  DBNull.Value;//Addetti1.NomeCompleto; //S_cmbDitta.SelectedItem.Text;
			clDatiUpDb.Add(pAddetto);

			S_Object pDataDa = new S_Object();
			pDataDa.ParameterName = "P_DATA_DA";
			pDataDa.DbType = CustomDBType.VarChar;
			pDataDa.Size=64;
			pDataDa.Direction = ParameterDirection.Input;
			pDataDa.Index = pIndex++;
			pDataDa.Value =   DBNull.Value;;//S_cmbCategoria.SelectedItem.Text;
			clDatiUpDb.Add(pDataDa);

			S_Object pDataA = new S_Object();
			pDataA.ParameterName = "P_DATA_A";
			pDataA.DbType = CustomDBType.VarChar;
			pDataA.Size=64;
			pDataA.Direction = ParameterDirection.Input;
			pDataA.Index = pIndex++;
			pDataA.Value =  DBNull.Value;; //S_cmbAddetto.SelectedItem.Text;
			clDatiUpDb.Add(pDataA);

			S_Object pOrdineDiLavoro = new S_Object();
			pOrdineDiLavoro.ParameterName = "P_ORDINE_LAVORO";
			pOrdineDiLavoro.DbType = CustomDBType.VarChar;
			pOrdineDiLavoro.Direction = ParameterDirection.Input;
			pOrdineDiLavoro.Size=256;
			pOrdineDiLavoro.Index = pIndex++;
			pOrdineDiLavoro.Value = DBNull.Value;
			clDatiUpDb.Add(pOrdineDiLavoro);

			S_Object pStatoRichiesta = new S_Object();
			pStatoRichiesta.ParameterName = "P_STATO_RICHIESTA";
			pStatoRichiesta.DbType = CustomDBType.VarChar;
			pStatoRichiesta.Size=256;
			pStatoRichiesta.Direction = ParameterDirection.Input;
			pStatoRichiesta.Index = pIndex++;
			pStatoRichiesta.Value =  DBNull.Value;;
			clDatiUpDb.Add(pStatoRichiesta);

			S_Object pServizioId = new S_Object();
			pServizioId.ParameterName ="P_SERVIZIO_ID";
			pServizioId.DbType = CustomDBType.VarChar;
			pServizioId.Size=256;
			pServizioId.Direction = ParameterDirection.Input;
			pServizioId.Index = pIndex++;
			pServizioId.Value =  DBNull.Value;
			clDatiUpDb.Add(pServizioId);

			S_Object pRichiedentiTipoId = new S_Object();
			pRichiedentiTipoId.ParameterName = "P_RICHIEDENTI_TIPO_ID";
			pRichiedentiTipoId.DbType = CustomDBType.VarChar;
			pRichiedentiTipoId.Direction = ParameterDirection.Input;
			pRichiedentiTipoId.Size=256;
			pRichiedentiTipoId.Index = pIndex++;
			pRichiedentiTipoId.Value = DBNull.Value;;
			clDatiUpDb.Add(pRichiedentiTipoId);

			S_Object pEm_Id = new S_Object();
			pEm_Id.ParameterName = "P_EM_ID";
			pEm_Id.DbType = CustomDBType.VarChar;
			pEm_Id.Size=256;
			pEm_Id.Direction = ParameterDirection.Input;
			pEm_Id.Index = pIndex++;
			pEm_Id.Value = DBNull.Value;;//Richiedenti1.txtRichiedente;
			clDatiUpDb.Add(pEm_Id);

			S_Object pIdPriority = new S_Object();
			pIdPriority.ParameterName = "P_ID_PRIORITY";
			pIdPriority.DbType = CustomDBType.VarChar;
			pIdPriority.Size=256;
			pIdPriority.Direction = ParameterDirection.Input;
			pIdPriority.Index = pIndex++;
			pIdPriority.Value =  DBNull.Value; // strOdl.Replace(",","-");
			clDatiUpDb.Add(pIdPriority);

			S_Object pDescrizione = new S_Object();
			pDescrizione.ParameterName = "P_DESCRIZIONE";
			pDescrizione.DbType = CustomDBType.VarChar;
			pDescrizione.Size=256;
			pDescrizione.Direction = ParameterDirection.Input;
			pDescrizione.Index = pIndex++;
			pDescrizione.Value =  DBNull.Value;
			clDatiUpDb.Add(pDescrizione);

			S_Object pTipoManutenzioneId = new S_Object();
			pTipoManutenzioneId.ParameterName = "P_TIPOMANUTENZIONE_ID";
			pTipoManutenzioneId.DbType = CustomDBType.VarChar;
			pDescrizione.Size=256;
			pTipoManutenzioneId.Direction = ParameterDirection.Input;
			pTipoManutenzioneId.Index = pIndex++;
			pTipoManutenzioneId.Value = DBNull.Value;;
			clDatiUpDb.Add(pTipoManutenzioneId);
			
			S_Object pDimensioneFile  = new S_Object();
			pDimensioneFile.ParameterName = "P_DIMENSIONE_FILE";
			pDimensioneFile.DbType = CustomDBType.Integer;
			pDimensioneFile.Direction = ParameterDirection.Input;
			pDimensioneFile.Index = pIndex++;
			pDimensioneFile.Value = 0;
			clDatiUpDb.Add(pDimensioneFile);

			
			S_Object pDimensioneZip  = new S_Object();
			pDimensioneZip.ParameterName = "P_DIMENSIONE_FILE_ZIP";
			pDimensioneZip.DbType = CustomDBType.Integer;
			pDimensioneZip.Direction = ParameterDirection.Input;
			pDimensioneZip.Index = pIndex++;
			pDimensioneZip.Value = 0;
			clDatiUpDb.Add(pDimensioneZip);

			S_Object pTipologiaReport  = new S_Object();
			pTipologiaReport.ParameterName = "P_TIPOLOGIA_REPORT";
			pTipologiaReport.DbType = CustomDBType.VarChar;
			pTipologiaReport.Direction = ParameterDirection.Input;
			pTipologiaReport.Index = pIndex++;
			pTipologiaReport.Value = DBNull.Value;
			clDatiUpDb.Add(pTipologiaReport);

			S_Object pDimensionePdfZip  = new S_Object();
			pDimensionePdfZip.ParameterName = "p_DIMENSIONEFILE_PDF_ZIP";
			pDimensionePdfZip.DbType = CustomDBType.Integer;
			pDimensionePdfZip.Direction = ParameterDirection.Input;
			pDimensionePdfZip.Index = pIndex++;
			pDimensionePdfZip.Value = 0;
			clDatiUpDb.Add(pDimensionePdfZip);

			
			io_db.NameProcedureDb = "pack_CostiGestioneCumulativi.UpdAnalisiCostiOperativi";
			int result = io_db.Delete(clDatiUpDb,idFile);
			return result;
		}
		private void elininaFile(string nomefile)
		{
			string percosoAssolutoFilePdf = string.Empty;
			string percosoAssolutoFileZip = string.Empty;
			string DirectoryName =  System.Configuration.ConfigurationSettings.AppSettings["DirectoryStampaCostoGestione"];
			percosoAssolutoFilePdf = Server.MapPath(DirectoryName)+ nomefile +  ".pdf";
			percosoAssolutoFileZip = Server.MapPath(DirectoryName)+ nomefile +  ".zip";
			FileInfo fiPdf = new FileInfo(percosoAssolutoFilePdf);
			FileInfo fiZip = new FileInfo(percosoAssolutoFileZip);
			if(fiPdf.Exists)
			{
				fiPdf.Delete();
			}
			else
			{
				throw new IOException();
			}
			if(fiZip.Exists)
			{
				fiZip.Delete();
			}
			else
			{
				throw new IOException();
			}
			
		}

		#endregion


		protected void imgBtnDownLoad_Click(object sender, CommandEventArgs e)
		{
			string nomeFileZip = System.Configuration.ConfigurationSettings.AppSettings["DirectoryStampaCostoGestione"] + (string)e.CommandArgument + ".zip";
			Response.Redirect(nomeFileZip);

		}


		//Metodi per la visualizzazione dei dettagli di un report
		protected void lnkDett_Click(object sender, CommandEventArgs e)
		{
			string id = (string)e.CommandArgument;
			DataSet ds;
	
			ds = riempiDatasetDettaglio(id);
			riempiSchedaDettaglio(ds);
			//			dsOdl = riempiDatasetDettaglioOdl(id);
			//			riempiSchedaDettaglioOdl(ds);
			this.pnlShowInfo.Visible = true;
		}
		//		private DataSet riempiDatasetDettaglioOdl(string id)
		//		{
		//			AgganciaDatalayer io_db  = new AgganciaDatalayer();
		//			S_ControlsCollection clDatiRicerca = new S_ControlsCollection();
		//			int index=0;
		//
		//			S_Object Pid = new S_Object();
		//			Pid.ParameterName = "Pid";
		//			Pid.DbType =  CustomDBType.Integer;
		//			Pid.Direction = ParameterDirection.Input;
		//			Pid.Index = index++;
		//			Pid.Value = Convert.ToInt32(id);
		//			clDatiRicerca.Add(Pid);
		//
		//			S_Object Cursor = new S_Object();
		//			Cursor.ParameterName = "RSCursor";
		//			Cursor.DbType =  CustomDBType.Cursor;
		//			Cursor.Direction = ParameterDirection.Output;
		//			Cursor.Index = index++;
		//			clDatiRicerca.Add(Cursor);
		//			io_db.NameProcedureDb = "rapportipdf.RecuperaOdl";
		//			DataSet dsDatiRicerca = io_db.GetData(clDatiRicerca).Copy();
		//			return dsDatiRicerca;
		//		}
		//		private void riempiSchedaDettaglioOdl(DataSet dsOdl)
		//		{
		//			string tmpOdl = string.Empty;
		//			StringBuilder sb = new StringBuilder();
		//			for(int i =0; i<=dsOdl.Tables[0].Rows.Count -1; i++)
		//			{
		//				sb.Append(dsOdl.Tables[0].Rows[i][0].ToString());
		//				sb.Append("-");
		//			}
		//			tmpOdl = sb.ToString();
		//			string resultOdl = tmpOdl.Remove(tmpOdl.Length-1,1);
		//			lblIntervalloOdl.Text = resultOdl;
		//		}
		private DataSet riempiDatasetDettaglio(string id)
		{
			AgganciaDatalayer io_db  = new AgganciaDatalayer();
			S_ControlsCollection clDatiRicerca = new S_ControlsCollection();
			int index=0;

			S_Object Pid = new S_Object();
			Pid.ParameterName = "P_id";
			Pid.DbType =  CustomDBType.Integer;
			Pid.Direction = ParameterDirection.Input;
			Pid.Index = index++;
			Pid.Value = Convert.ToInt32(id);
			clDatiRicerca.Add(Pid);

			S_Object Cursor = new S_Object();
			Cursor.ParameterName = "RSCursor";
			Cursor.DbType =  CustomDBType.Cursor;
			Cursor.Direction = ParameterDirection.Output;
			Cursor.Index = index++;
			clDatiRicerca.Add(Cursor);

			
			io_db.NameProcedureDb = "pack_CostiGestioneCumulativi.get_Dettaglio_Report_An_Co_Op";
			DataSet dsDatiRicerca = io_db.GetData(clDatiRicerca).Copy();

			//			DataSet Ds = new DataSet();
			//			int i=0;
			//			for(i=0; i<=dsDatiRicerca.Tables[0].Rows.Count-1;i++)
			//			{ 
			//				DsTipizzato.Tables["DownloadFile"].ImportRow(dsDatiRicerca.Tables[0].Rows[i]);
			//			}

			//			if(i==0)
			//			{
			//			 	
			//			}
			return dsDatiRicerca;
		}
		private void riempiSchedaDettaglio(DataSet ds)
		{
			AgganciaDatalayer io_db  = new AgganciaDatalayer();
			lblDataDiCreazione.Text           = ds.Tables[0].Rows[0]["data_created"].ToString();
			lblRichiestaLavoro.Text			  = ds.Tables[0].Rows[0]["RICHIESTA_DI_LAVORO"].ToString();
			lblEdificio.Text                  = ds.Tables[0].Rows[0]["CODICE_EDIFICIO"].ToString();
			if (lblEdificio.Text!="tutti")
			{
				DataSet dsBuilding = io_db.GetEdificio(lblEdificio.Text);
				lblComune.Text                    = dsBuilding.Tables[0].Rows[0]["desccomune"].ToString();
				lblDitta.Text                     = dsBuilding.Tables[0].Rows[0]["referente"].ToString();
			}
			else
			{
				DataSet dsBuilding = io_db.GetEdificio(lblEdificio.Text);
				lblComune.Text                    = "tutti";
				lblDitta.Text                     = "tutte";
			}
			//			lblCategoria.Text                 = ds.Tables[0].Rows[0]["categoria"].ToString();
			lblOdl.Text						  = ds.Tables[0].Rows[0]["ORDINE_LAVORO"].ToString();
			lblIntervalloRdl.Text			  = ds.Tables[0].Rows[0]["STRINGARDL"].ToString();
			lblGruppo.Text                    = ds.Tables[0].Rows[0]["richidenti_tipo_id"].ToString();
			lblRichiedenti.Text				  = ds.Tables[0].Rows[0]["EM_ID"].ToString();
			lblServizio.Text				  = ds.Tables[0].Rows[0]["SERVIZIO_ID"].ToString();
			lblTipoManutenzione.Text		  = ds.Tables[0].Rows[0]["TIPOMANUTENZIONE_ID"].ToString();
			lblAddetto.Text                   = ds.Tables[0].Rows[0]["ADDETTO_ID"].ToString();
			lblUrgenza.Text					  = ds.Tables[0].Rows[0]["ID_PRIORITY"].ToString();
			lblStatoRichiesta.Text            = ds.Tables[0].Rows[0]["STATO_RICHIESTA"].ToString();
			lblDataDa.Text					  = ds.Tables[0].Rows[0]["DATA_DA"].ToString();
			lblDataA.Text					  = ds.Tables[0].Rows[0]["DATA_A"].ToString();
			lblDimensioneFilePdf.Text         = ds.Tables[0].Rows[0]["dimensione_file"].ToString();
			lblDimensioneFileZip.Text         = ds.Tables[0].Rows[0]["dimensione_file_zip"].ToString();
			lblDataPrevistaInizio.Text		  = ds.Tables[0].Rows[0]["data_assegnazione_init"].ToString();
			lblDataPrevistaFine.Text		  = ds.Tables[0].Rows[0]["data_assegnazione_end"].ToString();
			//			lblDataCompletamentoIniziale.Text = ds.Tables["DownloadFile"].Rows[0]["data_completamento_init"].ToString();
			//			lblDataCompletamentoFinale.Text   = ds.Tables["DownloadFile"].Rows[0]["data_completamento_end"].ToString();
		}



		private void lnkChiudi_Click(object sender, System.EventArgs e)
		{
			this.pnlShowInfo.Visible = false;
		}

		private void S_btnEliminaTiitiFile_Click(object sender, System.EventArgs e)
		{
			eliminaTuutiFile();
			eliminaRecordDb();
			Server.Transfer("AnalisiCostiOperativiDiGestioneCumulativo.aspx");
		}
		private void eliminaTuutiFile()
		{
			string DirectoryName = System.Configuration.ConfigurationSettings.AppSettings["DirectoryStampaCostoGestione"];
			DirectoryInfo di = new DirectoryInfo(Server.MapPath(DirectoryName));
			foreach(FileInfo f in di.GetFiles())
			{
				f.Attributes = System.IO.FileAttributes.Normal;
				f.Delete();
				
			}
		}
		private void eliminaRecordDb()
		{
			AgganciaDatalayer io_db  = new AgganciaDatalayer();			
			io_db.NameProcedureDb="pack_CostiGestioneCumulativi.del_Download_Reports_An_Co_Op";
			int result = io_db.Delete();

		}

		
	}
}
