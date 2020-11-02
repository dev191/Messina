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
using StampaRapportiPdf;
using StampaRapportiPdf.Schemixsd;
using S_Controls.Collections;
using S_Controls;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using StampaRapportiPdf.Classi;
using StampaRapportiPdf.WebControls;
using System.IO;
using System.Text;


namespace StampaRapportiPdf.Pagine
{
	/// <summary>
	/// Descrizione di riepilogo per Pagina_Download.
	/// </summary>
	public class Pagina_Download : System.Web.UI.Page    // System.Web.UI.Page
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
		protected System.Web.UI.WebControls.Label LABEL22;
		protected System.Web.UI.WebControls.Label LABEL23;
		protected System.Web.UI.WebControls.Label LABEL24;
		protected System.Web.UI.WebControls.Label LABEL25;
		protected System.Web.UI.WebControls.Label LABEL26;
		protected System.Web.UI.WebControls.Label LABEL27;
		protected System.Web.UI.WebControls.Label LABEL28;
		protected System.Web.UI.WebControls.Label LABEL29;
		protected System.Web.UI.WebControls.Label LABEL30;
		protected System.Web.UI.WebControls.Label LABEL31;
		protected System.Web.UI.WebControls.Label LABEL32;
		protected System.Web.UI.WebControls.Label lblIntestazione;
		protected System.Web.UI.WebControls.Label lblDataDiCreazione;
		protected System.Web.UI.WebControls.Label lblTipologiaReport;
		protected System.Web.UI.WebControls.Label lblEdificio;
		protected System.Web.UI.WebControls.Label lblComune;
		protected System.Web.UI.WebControls.Label lblIntervalloOdl;
		protected System.Web.UI.WebControls.Label lblDitta;
		protected System.Web.UI.WebControls.Label lblCategoria;
		protected System.Web.UI.WebControls.Label lblAddetto;
		protected System.Web.UI.WebControls.Label lblDimensioneFilePdf;
		protected System.Web.UI.WebControls.Label lblDataAssegnazioneIniziale;
		protected System.Web.UI.WebControls.Label lblDataAssegnazioneFinale;
		protected System.Web.UI.WebControls.Label lblDataCompletamentoIniziale;
		protected System.Web.UI.WebControls.Label lblDataCompletamentoFinale;
		protected System.Web.UI.WebControls.Label lblC11;
		protected System.Web.UI.WebControls.Label lblSoloNonCompletate;
		protected System.Web.UI.WebControls.Label lblSoloCompletate;
		protected System.Web.UI.WebControls.Label lblDimensioneFileZip;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblSoloCompletateConFiltro;
		protected S_Controls.S_Button S_btnEliminaTiitiFile;
		protected GridTitle GridTitleDownLoad;
	    public static string HelpLink = string.Empty;

		private void Page_Load(object sender, System.EventArgs e)
		{
			TheSite.Classi.SiteModule _SiteModule = (TheSite.Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			HelpLink = _SiteModule.HelpLink;
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			pgtlDownoloadStampe.MainTitle = "Download Stampe Rapporti";
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
			DatasetReport ds;
			ds = riempiDatasetDownload();
			GridTitleDownLoad.NumeroRecords = Convert.ToString(ds.Tables["DownloadFile"].Rows.Count );
			DataGridRicerca.DataSource = ds.Tables["DownloadFile"];
			DataGridRicerca.DataBind();
		}
		private DatasetReport riempiDatasetDownload()
		{
			AgganciaDatalayer io_db  = new AgganciaDatalayer();
			S_ControlsCollection clDatiRicerca = new S_ControlsCollection();


			S_Object Cursor = new S_Object();
			Cursor.ParameterName = "RSCursor";
			Cursor.DbType =  CustomDBType.Cursor;
			Cursor.Direction = ParameterDirection.Output;
			Cursor.Index = 0;
			clDatiRicerca.Add(Cursor);

			
			io_db.NameProcedureDb = "rapportipdf.get_Download_Reports";
			DataSet dsDatiRicerca = io_db.GetData(clDatiRicerca).Copy();

			DatasetReport DsTipizzato = new DatasetReport();
			int i=0;
			for(i=0; i<=dsDatiRicerca.Tables[0].Rows.Count-1;i++)
			{ 
				DsTipizzato.Tables["DownloadFile"].ImportRow(dsDatiRicerca.Tables[0].Rows[i]);
			}

			if(i==0)
			{
			 	
			}
			return DsTipizzato;

		}
		private void S_btnRicerca_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Ricerca_e_stampa.aspx");
		}
		private void DataGridRicerca_PageIndexChanged(object sender, DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
			ricerca();
		}

		protected void imgBtnVisualizza_Click(Object sender , CommandEventArgs e)
		{
			Context.Items.Add("nome_file",(string)e.CommandArgument);
			Server.Transfer("VisualDWF.aspx");
		}
		protected void imgBtnElimina_Click(object sender, CommandEventArgs e)
		{
			string[] arrDatagridIthem  =  Convert.ToString(e.CommandArgument).Split(Convert.ToChar(","));
			int idFile = Convert.ToInt32(arrDatagridIthem[0].ToString());
			string nomeFile = arrDatagridIthem[1].ToString();

			int idFileDlete = deleteDb(idFile);
			deleteTblNorm(idFile);
			if(idFile != idFileDlete)
			{
				throw new Exception();
			}
			 elininaFile(nomeFile);
			 caricaDataGridRicerca();
			
		}
		private void deleteTblNorm(int idFile)
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
			pOdl.Value = DBNull.Value;
			clDatiUpDb.Add(pOdl);
			io_db.NameProcedureDb="RapportiPdf.inserisciTblNorm";
			int result = io_db.Delete(clDatiUpDb,0);

		}
		private int deleteDb(int idFile)
		{
			int pIndex =0;
			AgganciaDatalayer io_db  = new AgganciaDatalayer();
			S_ControlsCollection clDatiUpDb = new S_ControlsCollection();

			S_Object pNomeFile = new S_Object();
			pNomeFile.ParameterName = "p_NOME_FILE";
			pNomeFile.DbType = CustomDBType.VarChar;
			pNomeFile.Direction = ParameterDirection.Input;
			pNomeFile.Size = 128;
			pNomeFile.Index = pIndex;
			pNomeFile.Value = DBNull.Value;
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
			pDimensionePdfZip.Value = DBNull.Value;
			clDatiUpDb.Add(pDimensionePdfZip);

			S_Object pCompletate = new S_Object();
			pCompletate.ParameterName = "p_COMPLETATE";
			pCompletate.DbType = CustomDBType.VarChar;
			pCompletate.Direction = ParameterDirection.Input;
			pCompletate.Size = 128;
			pCompletate.Index = pIndex++;
			pCompletate.Value = DBNull.Value;
			clDatiUpDb.Add(pCompletate);

			S_Object pDataAssInOut = new S_Object();
			pDataAssInOut.ParameterName = "P_Data_ass_in_out";
			pDataAssInOut.DbType = CustomDBType.VarChar;
			pDataAssInOut.Direction = ParameterDirection.Input;
			pDataAssInOut.Size = 30;
			pDataAssInOut.Index = pIndex++;
			pDataAssInOut.Value = DBNull.Value;
			clDatiUpDb.Add(pDataAssInOut);

			io_db.NameProcedureDb = "RapportiPdf.inserisciTabellaDwn";
			int result = io_db.Delete(clDatiUpDb,idFile);
			return result;
		}
		private void elininaFile(string nomefile)
		{
			string percosoAssolutoFilePdf = string.Empty;
			string percosoAssolutoFileZip = string.Empty;
			string[] DirectoryName = ((string[])( System.Configuration.ConfigurationSettings.AppSettings.GetValues("DirectoryStampa")));
			percosoAssolutoFilePdf = Server.MapPath(DirectoryName[0])+ nomefile +  ".pdf";
			percosoAssolutoFileZip = Server.MapPath(DirectoryName[0])+ nomefile +  ".zip";
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
		protected void imgBtnDownLoad_Click(object sender, CommandEventArgs e)
		{
			string nomeFileZip ="../stampe/" + (string)e.CommandArgument + ".zip";
			Response.Redirect(nomeFileZip);

		}
		protected void lnkDett_Click(object sender, CommandEventArgs e)
		{
			string id = (string)e.CommandArgument;
			DatasetReport ds;
			DataSet dsOdl;
			ds = riempiDatasetDettaglio(id);
			riempiSchedaDettaglio(ds);
			dsOdl = riempiDatasetDettaglioOdl(id);
			riempiSchedaDettaglioOdl(dsOdl);
			this.pnlShowInfo.Visible = true;
		}
		private DataSet riempiDatasetDettaglioOdl(string id)
		{
			AgganciaDatalayer io_db  = new AgganciaDatalayer();
			S_ControlsCollection clDatiRicerca = new S_ControlsCollection();
			int index=0;

			S_Object Pid = new S_Object();
			Pid.ParameterName = "Pid";
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
			io_db.NameProcedureDb = "rapportipdf.RecuperaOdl";
			DataSet dsDatiRicerca = io_db.GetData(clDatiRicerca).Copy();
			return dsDatiRicerca;
		}
		private void riempiSchedaDettaglioOdl(DataSet dsOdl)
		{
			string tmpOdl = string.Empty;
			StringBuilder sb = new StringBuilder();
			for(int i =0; i<=dsOdl.Tables[0].Rows.Count -1; i++)
			{
				sb.Append(dsOdl.Tables[0].Rows[i][0].ToString());
				sb.Append("-");
			}
			tmpOdl = sb.ToString();
			string resultOdl = tmpOdl.Remove(tmpOdl.Length-1,1);
			lblIntervalloOdl.Text = resultOdl;
		}
		private DatasetReport riempiDatasetDettaglio(string id)
		{
			AgganciaDatalayer io_db  = new AgganciaDatalayer();
			S_ControlsCollection clDatiRicerca = new S_ControlsCollection();
			int index=0;

			S_Object Pid = new S_Object();
			Pid.ParameterName = "Pid";
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

			
			io_db.NameProcedureDb = "rapportipdf.RecuperaDettagli";
			DataSet dsDatiRicerca = io_db.GetData(clDatiRicerca).Copy();

			DatasetReport DsTipizzato = new DatasetReport();
			int i=0;
			for(i=0; i<=dsDatiRicerca.Tables[0].Rows.Count-1;i++)
			{ 
				DsTipizzato.Tables["DownloadFile"].ImportRow(dsDatiRicerca.Tables[0].Rows[i]);
			}

			if(i==0)
			{
			 	
			}
			return DsTipizzato;
		}
		private void riempiSchedaDettaglio(DatasetReport ds)
		{
			lblDataDiCreazione.Text           = ds.Tables["DownloadFile"].Rows[0]["data_created"].ToString();
			lblTipologiaReport.Text           = ds.Tables["DownloadFile"].Rows[0]["tipologia_report"].ToString();
			lblEdificio.Text                  = ds.Tables["DownloadFile"].Rows[0]["edificio"].ToString();
			lblComune.Text                    = ds.Tables["DownloadFile"].Rows[0]["comune"].ToString();
			lblDitta.Text                     = ds.Tables["DownloadFile"].Rows[0]["ditta"].ToString();
			lblCategoria.Text                 = ds.Tables["DownloadFile"].Rows[0]["categoria"].ToString();
			lblAddetto.Text                   = ds.Tables["DownloadFile"].Rows[0]["addetto"].ToString();
			lblSoloNonCompletate.Text         = ds.Tables["DownloadFile"].Rows[0]["solo_non_completate"].ToString();
			lblSoloCompletate.Text            = ds.Tables["DownloadFile"].Rows[0]["solo_completate"].ToString();
			lblSoloCompletateConFiltro.Text    = ds.Tables["DownloadFile"].Rows[0]["data_di_completamento"].ToString();
			lblDimensioneFilePdf.Text         = ds.Tables["DownloadFile"].Rows[0]["dimensione_file"].ToString();
			lblDimensioneFileZip.Text         = ds.Tables["DownloadFile"].Rows[0]["dimensione_file_zip"].ToString();
			lblDataAssegnazioneIniziale.Text  = ds.Tables["DownloadFile"].Rows[0]["data_assegnazione_init"].ToString();
			lblDataAssegnazioneFinale.Text    = ds.Tables["DownloadFile"].Rows[0]["data_assegnazione_end"].ToString();
			lblDataCompletamentoIniziale.Text = ds.Tables["DownloadFile"].Rows[0]["data_completamento_init"].ToString();
			lblDataCompletamentoFinale.Text   = ds.Tables["DownloadFile"].Rows[0]["data_completamento_end"].ToString();
		}
		private void lnkChiudi_Click(object sender, System.EventArgs e)
		{
			this.pnlShowInfo.Visible = false;
		}

		private void S_btnEliminaTiitiFile_Click(object sender, System.EventArgs e)
		{
			eliminaTuutiFile();
			eliminaRecordDb();
			Response.Redirect("Ricerca_e_Stampa.aspx");
		}
		private void eliminaTuutiFile()
		{
			string[] DirectoryName = ((string[])( System.Configuration.ConfigurationSettings.AppSettings.GetValues("DirectoryStampa")));
			DirectoryInfo di = new DirectoryInfo(Server.MapPath(DirectoryName[0]));
			foreach(FileInfo f in di.GetFiles())
			{
				f.Attributes = System.IO.FileAttributes.Normal;
				f.Delete();
				
			}
		}
		private void eliminaRecordDb()
		{
			AgganciaDatalayer io_db  = new AgganciaDatalayer();
			S_ControlsCollection clDatiUpDb = new S_ControlsCollection();
		
			S_Object pFinto = new S_Object();
			pFinto.ParameterName = "p_finto";
			pFinto.DbType = CustomDBType.VarChar;
			pFinto.Direction = ParameterDirection.Input;
			pFinto.Size = 16;
			pFinto.Index = 0;
			pFinto.Value = DBNull.Value;
			clDatiUpDb.Add(pFinto);
			io_db.NameProcedureDb="RapportiPdf.svutaTbelleAppoggio";
			int result = io_db.Delete(clDatiUpDb,0);

		}
	}
}
