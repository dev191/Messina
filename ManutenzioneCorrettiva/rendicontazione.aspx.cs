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
using System.Configuration;
using LibConsCont;
using System.IO;
using ICSharpCode;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;

namespace TheSite.ManutenzioneCorrettiva
{
	/// <summary>
	/// Descrizione di riepilogo per rendicontazione.
	/// </summary>
	public class rendicontazione : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DrEdifici;
		protected System.Web.UI.WebControls.DropDownList DropMese;
		protected System.Web.UI.WebControls.Label lblAnno;
		protected System.Web.UI.WebControls.DropDownList DropAnno;
		protected System.Web.UI.WebControls.Button BtGenera;
		protected System.Web.UI.WebControls.Button BtSalva;
		protected System.Web.UI.WebControls.Label lblMessage;
		
		protected System.Web.UI.WebControls.DropDownList DrTrimestre;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				LoadCombo();
			}
			// Inserire qui il codice utente necessario per inizializzare la pagina.
		}

		private void LoadCombo()
		{
			TheSite.Classi.ManProgrammata.InvioDocPmP  _inviodoc = new TheSite.Classi.ManProgrammata.InvioDocPmP();
			DataSet Ds=_inviodoc.GetEdifici(Context.User.Identity.Name);
			DrEdifici.DataSource=Ds.Tables[0];
			DrEdifici.DataTextField ="Denominazione";
			DrEdifici.DataValueField="idedif"; 
			DrEdifici.DataBind();

			for(int i=2008;i<=2028;i++)
				DropAnno.Items.Add(new ListItem(i.ToString(),i.ToString()));  

		//	DrTipoDocumenti.Attributes.Add("onclick","setvis()");
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
			this.BtGenera.Click += new System.EventHandler(this.BtGenera_Click);
			this.BtSalva.Click += new System.EventHandler(this.BtSalva_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void BtGenera_Click(object sender, System.EventArgs e)
		{
			

			lblMessage.Text ="";
			int Anno; 
			Anno = int.Parse(DropAnno.SelectedValue); 
			int Trimestre; 
            Trimestre=int.Parse(DrTrimestre.SelectedValue);
		
			int pIdEdificio; 
			string ConnessioneDb = ConfigurationSettings.AppSettings["ConnectionString"]; 
			 
			// istanzio la calasse che genera il report 
			LibConsCont.LbConsExcel app = new LibConsCont.LbConsExcel(); 
    
			//LibConsCont.RegistrazioneFile RegFile = new LibConsCont.RegistrazioneFile(); 
			
			try 
			{ 
        
				// imposto la stringa di connessione alla classe 
				app.StrCon = ConnessioneDb; 
				//RegFile.ConnessioneDb = ConnessioneDb; 
				// imposto la la directory dei file di output 
				app.PathFileoutput = Server.MapPath("../Doc_DB/TempFile"); 
				app.PathMasterReport = Server.MapPath("../MasterExcel"); 
				if(!Directory.Exists(Server.MapPath("../Doc_DB/TempFile")))
					Directory.CreateDirectory(Server.MapPath("../Doc_DB/TempFile"));
 
				string[] dirs=Directory.GetDirectories(Server.MapPath("../Doc_DB/TempFile"));
				try
				{
					foreach(string dir in dirs)
					{
						Directory.Delete(dir,true);
					}
				}
				finally
				{
					
				}
				int IdProgetto; 
				int IdBl; 
				string CodiceEdificio; 
				string CodiceDoc; 
				string[] Arr=DrEdifici.SelectedValue.Split('-');
                string[] Arr1=DrEdifici.Items[DrEdifici.SelectedIndex].Text.Split(' ');
                
					IdProgetto = Convert.ToInt32(Arr[1].Trim()); 
					IdBl = Convert.ToInt32(Arr[0].Trim()); 
					pIdEdificio = IdBl; 
					CodiceEdificio = Arr1[0].Trim(); 

					//Inserisce i dati nei fogli xls e li salvo 
					app.GenerateReport(IdProgetto, IdBl, CodiceEdificio, Anno, Trimestre); 
					//app.GenerateReport(IdProgetto, IdBl, CodiceEdificio, Anno, Trimestre); 
					//resistro i file creati su tabella otacle 
					CodiceDoc = "0" + Trimestre.ToString() + "/" + Convert.ToString(Anno).Substring(2); 
					//string User=Context.User.Identity.Name;    
					//RegFile.InsertOnDb(app.NomeFileSalvato, User, "XLS", CodiceDoc, IdBl, app.NumeroVesioneFile, ""); 
					//Zip il file e spedisco la mail 
					ZippaFileOutput(app.NomeFileSalvato, app.NomeFileCompleto, app.PercorsoFileUscitaTotale);  
				
			} 
			catch (Exception ex) 
			{ 
 
				lblMessage.Text ="Errore nell'Invio " + ex.Message; 
			} 
			finally 
			{ 
				
				app = null; 
				GC.Collect(); 
			} 
          
		}

		private void ZippaFileOutput(string NomeFile, string NomeFileCompleto, string pathDir) 
		{ 
			string tempFile=NomeFileCompleto;
			string assolutoFileZip; 
			assolutoFileZip = NomeFileCompleto.Remove(NomeFileCompleto.Length - 3, 3) + "zip"; 
			FastZip makeZipFile = new FastZip(); 
			makeZipFile.CreateZip(assolutoFileZip, pathDir, true, NomeFile); 
		  
//			if (File.Exists(tempFile)) 
//			{ 
//				File.Delete(tempFile); 
//			} 
            FileInfo f=new FileInfo(assolutoFileZip);

			Response.Clear();
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Buffer = true;
			Response.ContentType = "application/zip";
			Response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(assolutoFileZip));
			Response.AddHeader("Content-Length", f.Length.ToString());
			Response.AddHeader("Last-Modified: " , f.LastWriteTimeUtc.ToString());

			//Response.ContentType = "application/octet-stream"
			 
			Response.WriteFile(assolutoFileZip);
			Response.Flush();
			
			Response.Close();
			
		} 

		private void BtSalva_Click(object sender, System.EventArgs e)
		{
			lblMessage.Text ="";
			int Anno; 
			Anno = int.Parse(DropAnno.SelectedValue); 
			int Trimestre; 
			Trimestre=int.Parse(DrTrimestre.SelectedValue);
		
			int pIdEdificio; 
			string ConnessioneDb = ConfigurationSettings.AppSettings["ConnectionString"]; 
			 
			// istanzio la calasse che genera il report 
			LibConsCont.LbConsExcel app = new LibConsCont.LbConsExcel(); 
    
			LibConsCont.RegistrazioneFile RegFile = new LibConsCont.RegistrazioneFile(); 
		   
			try 
			{ 
        
				// imposto la stringa di connessione alla classe 
				app.StrCon = ConnessioneDb; 
				RegFile.ConnessioneDb = ConnessioneDb; 
				// imposto la la directory dei file di output 
				app.PathFileoutput = Server.MapPath("../Doc_DB"); 
				app.PathMasterReport = Server.MapPath("../MasterExcel"); 
				
				

				int IdProgetto; 
				int IdBl; 
				string CodiceEdificio; 
				string CodiceDoc; 
				string[] Arr=DrEdifici.SelectedValue.Split('-');
				string[] Arr1=DrEdifici.Items[DrEdifici.SelectedIndex].Text.Split(' ');
                
				IdProgetto = Convert.ToInt32(Arr[1].Trim()); 
				IdBl = Convert.ToInt32(Arr[0].Trim()); 
				pIdEdificio = IdBl; 
				CodiceEdificio = Arr1[0].Trim(); 

				//Inserisce i dati nei fogli xls e li salvo 
				app.GenerateReport(IdProgetto, IdBl, CodiceEdificio, Anno, Trimestre); 
				//resistro i file creati su tabella otacle 
				CodiceDoc = "0" + Trimestre.ToString() + "/" + Convert.ToString(Anno).Substring(2); 
				string User=Context.User.Identity.Name;    
				RegFile.InsertOnDbByWeb(app.NomeFileSalvato, User, "XLS", CodiceDoc, IdBl, app.NumeroVesioneFile, ""); 
				//Zip il file e spedisco la mail 
				ZippaFileOutput2(app.NomeFileSalvato, app.NomeFileCompleto, app.PercorsoFileUscitaTotale);  
				
			} 
			catch (Exception ex) 
			{ 
 
				lblMessage.Text ="Errore nell'Invio " + ex.Message; 
			} 
			finally 
			{ 
				
				app = null; 
				GC.Collect(); 
			} 
		}
		private void ZippaFileOutput2(string NomeFile, string NomeFileCompleto, string pathDir) 
		{ 
			string assolutoFileZip; 
			assolutoFileZip = NomeFileCompleto.Remove(NomeFileCompleto.Length - 3, 3) + "zip"; 
			FastZip makeZipFile = new FastZip(); 
			makeZipFile.CreateZip(assolutoFileZip, pathDir, true, NomeFile); 
			Response.Clear();
			Response.ContentType = "application/zip";
			Response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFileName(assolutoFileZip));
			Response.WriteFile(assolutoFileZip);
			Response.Flush();
			Response.Close();
		} 
	}
}
