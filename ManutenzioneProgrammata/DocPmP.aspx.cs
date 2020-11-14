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
using System.Text;
using System.IO;
using System.Web.Mail;
using System.Configuration;
using ICSharpCode;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
using S_Controls.Collections;
using ApplicationDataLayer.DBType;
using MyCollection;
using ExcelPMP;
   
namespace TheSite
{
	/// <summary>
	/// Descrizione di riepilogo per DocPmP.
	/// </summary>
	public class DocPmP : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button BtInvia;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DropDownList DrTipoDocumenti;
		protected System.Web.UI.WebControls.TextBox TxtAnnotazioni;
		protected System.Web.UI.WebControls.Label lblMese;
		protected System.Web.UI.WebControls.Label lblAnno;
		protected System.Web.UI.WebControls.DropDownList DropMese;
		protected System.Web.UI.WebControls.DropDownList DropAnno;
		protected System.Web.UI.HtmlControls.HtmlInputFile UploadFile;
		protected System.Web.UI.WebControls.DropDownList DrEdifici;
		int Result;
		TheSite.Classi.ManProgrammata.InvioDocPmP  _inviodoc = new TheSite.Classi.ManProgrammata.InvioDocPmP();

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if (!IsPostBack)
				LoadCombo();
		}
		
		private void LoadCombo()
		{
			TheSite.Classi.ManProgrammata.InvioDocPmP  _inviodoc = new TheSite.Classi.ManProgrammata.InvioDocPmP();
			DataSet Ds=_inviodoc.GetEdifici(Context.User.Identity.Name);
			DrEdifici.DataSource=Ds.Tables[0];
			DrEdifici.DataTextField ="Denominazione";
			DrEdifici.DataValueField="id"; 
			DrEdifici.DataBind();

			for(int i=2008;i<=2020;i++)
				DropAnno.Items.Add(new ListItem(i.ToString(),i.ToString()));  

			DrTipoDocumenti.Attributes.Add("onclick","setvis()");
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
			this.BtInvia.Click += new System.EventHandler(this.BtInvia_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SalvaInvio()
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();		

			S_Controls.Collections.S_Object s_p_ID = new S_Object();
			s_p_ID.ParameterName = "p_Id";
			s_p_ID.DbType = CustomDBType.Integer;
			s_p_ID.Direction = ParameterDirection.Input;
			s_p_ID.Index =_SCollection.Count;
			s_p_ID.Value=DBNull.Value;			
			_SCollection.Add(s_p_ID);

			S_Controls.Collections.S_Object s_p_BL_ID = new S_Object();
			s_p_BL_ID.ParameterName = "p_bl_Id";
			s_p_BL_ID.DbType = CustomDBType.Integer;
			s_p_BL_ID.Direction = ParameterDirection.Input;
			s_p_BL_ID.Index =_SCollection.Count;
			s_p_BL_ID.Value=Convert.ToInt32(DrEdifici.SelectedValue);			
			_SCollection.Add(s_p_BL_ID);

			S_Controls.Collections.S_Object s_p_NOME_DOC = new S_Object();
			s_p_NOME_DOC.ParameterName = "p_NOME_DOC";
			s_p_NOME_DOC.DbType = CustomDBType.VarChar;
			s_p_NOME_DOC.Direction = ParameterDirection.Input;
			s_p_NOME_DOC.Size=225;
			s_p_NOME_DOC.Index = _SCollection.Count;
			s_p_NOME_DOC.Value=System.IO.Path.GetFileName(UploadFile.PostedFile.FileName);			
			_SCollection.Add(s_p_NOME_DOC);
             
			S_Controls.Collections.S_Object s_p_ID_STATO = new S_Object();
			s_p_ID_STATO.ParameterName = "p_ID_STATO";
			s_p_ID_STATO.DbType = CustomDBType.Integer;
			s_p_ID_STATO.Direction = ParameterDirection.Input;
			s_p_ID_STATO.Index =_SCollection.Count;

			if(DrTipoDocumenti.SelectedValue=="1")
				s_p_ID_STATO.Value="1";	
			if(DrTipoDocumenti.SelectedValue=="2")
				s_p_ID_STATO.Value="3";
			if(DrTipoDocumenti.SelectedValue=="3")
				s_p_ID_STATO.Value="1";
			if(DrTipoDocumenti.SelectedValue=="4")
				s_p_ID_STATO.Value="5";
			if(DrTipoDocumenti.SelectedValue=="5")
				s_p_ID_STATO.Value="3";
				
			_SCollection.Add(s_p_ID_STATO);

			S_Controls.Collections.S_Object s_p_DATA_INVIO = new S_Object();
			s_p_DATA_INVIO.ParameterName = "p_DATA_INVIO";
			s_p_DATA_INVIO.DbType = CustomDBType.VarChar;
			s_p_DATA_INVIO.Direction = ParameterDirection.Input;
			s_p_DATA_INVIO.Size=225;
			s_p_DATA_INVIO.Index = _SCollection.Count;
			s_p_DATA_INVIO.Value= System.DateTime.Now.ToShortDateString();			
			_SCollection.Add(s_p_DATA_INVIO);

			S_Controls.Collections.S_Object s_p_DATA_INSERIMENTo = new S_Object();
			s_p_DATA_INSERIMENTo.ParameterName = "p_DATA_INSERIMENTo";
			s_p_DATA_INSERIMENTo.DbType = CustomDBType.VarChar;
			s_p_DATA_INSERIMENTo.Direction = ParameterDirection.Input;
			s_p_DATA_INSERIMENTo.Size=225;
			s_p_DATA_INSERIMENTo.Index = _SCollection.Count;
			s_p_DATA_INSERIMENTo.Value=  System.DateTime.Now.ToShortDateString();		
			_SCollection.Add(s_p_DATA_INSERIMENTo);

			S_Controls.Collections.S_Object s_p_anno = new S_Object();
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.Integer;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Size=225;
			s_p_anno.Index = _SCollection.Count;
			s_p_anno.Value=  DropAnno.SelectedValue;		
			_SCollection.Add(s_p_anno);

			S_Controls.Collections.S_Object s_p_note = new S_Object();
			s_p_note.ParameterName = "p_note1";
			s_p_note.DbType = CustomDBType.VarChar;
			s_p_note.Direction = ParameterDirection.Input;
			s_p_note.Size=225;
			s_p_note.Index = _SCollection.Count;
			s_p_note.Value=  TxtAnnotazioni.Text.Trim();		
			_SCollection.Add(s_p_note);

			if (DrTipoDocumenti.SelectedValue=="2" || DrTipoDocumenti.SelectedValue=="1")
				Result=_inviodoc.SaveAnni(_SCollection);
			else
			{
				S_Controls.Collections.S_Object s_p_mese = new S_Object();
				s_p_mese.ParameterName = "p_mese";
				s_p_mese.DbType = CustomDBType.Integer;
				s_p_mese.Direction = ParameterDirection.Input;
				s_p_mese.Size=225;
				s_p_mese.Index = _SCollection.Count;
				s_p_mese.Value=  DropMese.SelectedValue;		
				_SCollection.Add(s_p_mese);

				Result=_inviodoc.SaveMesi(_SCollection);
			}
		}
		/// <summary>
		/// Questa routine risalva i  nuovi file riemessi con il piano mensile eseguito
		/// </summary>
		private void SalvaEseguito(string FileExcel, string FileA8)
		{
//			for(int i=0;i<=1;i++)
//			{
				S_ControlsCollection _SCollection = new S_ControlsCollection();		

				S_Controls.Collections.S_Object s_p_ID = new S_Object();
				s_p_ID.ParameterName = "p_Id";
				s_p_ID.DbType = CustomDBType.Integer;
				s_p_ID.Direction = ParameterDirection.Input;
				s_p_ID.Index =_SCollection.Count;
				s_p_ID.Value=DBNull.Value;			
				_SCollection.Add(s_p_ID);

				S_Controls.Collections.S_Object s_p_BL_ID = new S_Object();
				s_p_BL_ID.ParameterName = "p_bl_Id";
				s_p_BL_ID.DbType = CustomDBType.Integer;
				s_p_BL_ID.Direction = ParameterDirection.Input;
				s_p_BL_ID.Index =_SCollection.Count;
				s_p_BL_ID.Value=Convert.ToInt32(DrEdifici.SelectedValue);			
				_SCollection.Add(s_p_BL_ID);

				S_Controls.Collections.S_Object s_p_NOME_DOC = new S_Object();
				s_p_NOME_DOC.ParameterName = "p_NOME_DOC";
				s_p_NOME_DOC.DbType = CustomDBType.VarChar;
				s_p_NOME_DOC.Direction = ParameterDirection.Input;
				s_p_NOME_DOC.Size=225;
				s_p_NOME_DOC.Index = _SCollection.Count;
				//if(i==0)
					s_p_NOME_DOC.Value=System.IO.Path.GetFileName(FileExcel);	
//				else
//					s_p_NOME_DOC.Value=System.IO.Path.GetFileName(FileA8);
				_SCollection.Add(s_p_NOME_DOC);
             
				S_Controls.Collections.S_Object s_p_ID_STATO = new S_Object();
				s_p_ID_STATO.ParameterName = "p_ID_STATO";
				s_p_ID_STATO.DbType = CustomDBType.Integer;
				s_p_ID_STATO.Direction = ParameterDirection.Input;
				s_p_ID_STATO.Index =_SCollection.Count;
				s_p_ID_STATO.Value="5";
				_SCollection.Add(s_p_ID_STATO);

				S_Controls.Collections.S_Object s_p_DATA_INVIO = new S_Object();
				s_p_DATA_INVIO.ParameterName = "p_DATA_INVIO";
				s_p_DATA_INVIO.DbType = CustomDBType.VarChar;
				s_p_DATA_INVIO.Direction = ParameterDirection.Input;
				s_p_DATA_INVIO.Size=225;
				s_p_DATA_INVIO.Index = _SCollection.Count;
				s_p_DATA_INVIO.Value= System.DateTime.Now.ToShortDateString();			
				_SCollection.Add(s_p_DATA_INVIO);

				S_Controls.Collections.S_Object s_p_DATA_INSERIMENTo = new S_Object();
				s_p_DATA_INSERIMENTo.ParameterName = "p_DATA_INSERIMENTo";
				s_p_DATA_INSERIMENTo.DbType = CustomDBType.VarChar;
				s_p_DATA_INSERIMENTo.Direction = ParameterDirection.Input;
				s_p_DATA_INSERIMENTo.Size=225;
				s_p_DATA_INSERIMENTo.Index = _SCollection.Count;
				s_p_DATA_INSERIMENTo.Value=  System.DateTime.Now.ToShortDateString();		
				_SCollection.Add(s_p_DATA_INSERIMENTo);

				S_Controls.Collections.S_Object s_p_anno = new S_Object();
				s_p_anno.ParameterName = "p_anno";
				s_p_anno.DbType = CustomDBType.Integer;
				s_p_anno.Direction = ParameterDirection.Input;
				s_p_anno.Size=225;
				s_p_anno.Index = _SCollection.Count;
				s_p_anno.Value=  DropAnno.SelectedValue;		
				_SCollection.Add(s_p_anno);

				S_Controls.Collections.S_Object s_p_note = new S_Object();
				s_p_note.ParameterName = "p_note1";
				s_p_note.DbType = CustomDBType.VarChar;
				s_p_note.Direction = ParameterDirection.Input;
				s_p_note.Size=225;
				s_p_note.Index = _SCollection.Count;
				s_p_note.Value=  TxtAnnotazioni.Text.Trim();		
				_SCollection.Add(s_p_note);

				S_Controls.Collections.S_Object s_p_mese = new S_Object();
				s_p_mese.ParameterName = "p_mese";
				s_p_mese.DbType = CustomDBType.Integer;
				s_p_mese.Direction = ParameterDirection.Input;
				s_p_mese.Size=225;
				s_p_mese.Index = _SCollection.Count;
				s_p_mese.Value=  DropMese.SelectedValue;		
				_SCollection.Add(s_p_mese);
               // if(i==0)
					Result=_inviodoc.SaveMesi(_SCollection);
//				else
//					_inviodoc.SaveMesi(_SCollection);
//			}
	
		}
		private void SalvaA8( string FileA8)
		{
		
				S_ControlsCollection _SCollection = new S_ControlsCollection();		

				S_Controls.Collections.S_Object s_p_ID = new S_Object();
				s_p_ID.ParameterName = "p_Id";
				s_p_ID.DbType = CustomDBType.Integer;
				s_p_ID.Direction = ParameterDirection.Input;
				s_p_ID.Index =_SCollection.Count;
				s_p_ID.Value=DBNull.Value;			
				_SCollection.Add(s_p_ID);

				S_Controls.Collections.S_Object s_p_BL_ID = new S_Object();
				s_p_BL_ID.ParameterName = "p_bl_Id";
				s_p_BL_ID.DbType = CustomDBType.Integer;
				s_p_BL_ID.Direction = ParameterDirection.Input;
				s_p_BL_ID.Index =_SCollection.Count;
				s_p_BL_ID.Value=Convert.ToInt32(DrEdifici.SelectedValue);			
				_SCollection.Add(s_p_BL_ID);

				S_Controls.Collections.S_Object s_p_NOME_DOC = new S_Object();
				s_p_NOME_DOC.ParameterName = "p_NOME_DOC";
				s_p_NOME_DOC.DbType = CustomDBType.VarChar;
				s_p_NOME_DOC.Direction = ParameterDirection.Input;
				s_p_NOME_DOC.Size=225;
				s_p_NOME_DOC.Index = _SCollection.Count;
		
				s_p_NOME_DOC.Value=System.IO.Path.GetFileName(FileA8);
				_SCollection.Add(s_p_NOME_DOC);
             
				S_Controls.Collections.S_Object s_p_ID_STATO = new S_Object();
				s_p_ID_STATO.ParameterName = "p_ID_STATO";
				s_p_ID_STATO.DbType = CustomDBType.Integer;
				s_p_ID_STATO.Direction = ParameterDirection.Input;
				s_p_ID_STATO.Index =_SCollection.Count;

				if(DrTipoDocumenti.SelectedValue=="1")
					s_p_ID_STATO.Value="1";	
				if(DrTipoDocumenti.SelectedValue=="2")
					s_p_ID_STATO.Value="3";
				if(DrTipoDocumenti.SelectedValue=="3")
					s_p_ID_STATO.Value="1";
				if(DrTipoDocumenti.SelectedValue=="4")
					s_p_ID_STATO.Value="5";
				if(DrTipoDocumenti.SelectedValue=="5")
					s_p_ID_STATO.Value="3";

				_SCollection.Add(s_p_ID_STATO);

				S_Controls.Collections.S_Object s_p_DATA_INVIO = new S_Object();
				s_p_DATA_INVIO.ParameterName = "p_DATA_INVIO";
				s_p_DATA_INVIO.DbType = CustomDBType.VarChar;
				s_p_DATA_INVIO.Direction = ParameterDirection.Input;
				s_p_DATA_INVIO.Size=225;
				s_p_DATA_INVIO.Index = _SCollection.Count;
				s_p_DATA_INVIO.Value= System.DateTime.Now.ToShortDateString();			
				_SCollection.Add(s_p_DATA_INVIO);

				S_Controls.Collections.S_Object s_p_DATA_INSERIMENTo = new S_Object();
				s_p_DATA_INSERIMENTo.ParameterName = "p_DATA_INSERIMENTo";
				s_p_DATA_INSERIMENTo.DbType = CustomDBType.VarChar;
				s_p_DATA_INSERIMENTo.Direction = ParameterDirection.Input;
				s_p_DATA_INSERIMENTo.Size=225;
				s_p_DATA_INSERIMENTo.Index = _SCollection.Count;
				s_p_DATA_INSERIMENTo.Value=  System.DateTime.Now.ToShortDateString();		
				_SCollection.Add(s_p_DATA_INSERIMENTo);

				S_Controls.Collections.S_Object s_p_anno = new S_Object();
				s_p_anno.ParameterName = "p_anno";
				s_p_anno.DbType = CustomDBType.Integer;
				s_p_anno.Direction = ParameterDirection.Input;
				s_p_anno.Size=225;
				s_p_anno.Index = _SCollection.Count;
				s_p_anno.Value=  DropAnno.SelectedValue;		
				_SCollection.Add(s_p_anno);

				S_Controls.Collections.S_Object s_p_note = new S_Object();
				s_p_note.ParameterName = "p_note1";
				s_p_note.DbType = CustomDBType.VarChar;
				s_p_note.Direction = ParameterDirection.Input;
				s_p_note.Size=225;
				s_p_note.Index = _SCollection.Count;
				s_p_note.Value=  TxtAnnotazioni.Text.Trim();		
				_SCollection.Add(s_p_note);

				S_Controls.Collections.S_Object s_p_mese = new S_Object();
				s_p_mese.ParameterName = "p_mese";
				s_p_mese.DbType = CustomDBType.Integer;
				s_p_mese.Direction = ParameterDirection.Input;
				s_p_mese.Size=225;
				s_p_mese.Index = _SCollection.Count;
				s_p_mese.Value=  DropMese.SelectedValue;		
				_SCollection.Add(s_p_mese);

				_inviodoc.SaveMesi(_SCollection);
	
		}
		/// <summary>
		/// Aggiorna il Piano di manutenzione Mensile
		/// </summary>
		private void UpdatePMP(string FileName,PMPExcel.UpdateType updatetype)
		{
			string ConnectionStr =System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
			PMPExcel.PMPExcel exc=new PMPExcel.PMPExcel(FileName,updatetype,Context.User.Identity.Name,ConnectionStr);
			try
			{
				StringBuilder sb = exc.ReadDocument();
				lblMessage.Text=sb.ToString().Replace("\n","</br>");
			}
			catch(Exception x)
			{
				lblMessage.Text=x.Message;
			}
			finally 
			{
				if (exc != null)
					((IDisposable)exc).Dispose();

			}
		}
		private void BtInvia_Click(object sender, System.EventArgs e)
		{
			lblMessage.Text="";
			SendDoc();
		}

		/// <summary>
		/// Controlla la validità del documento inviato al server
		/// </summary>
		/// <returns></returns>
		private bool IsValidDocMensile()
		{
			lblMessage.Text="";
			//Recupero il nome del file
			string FileName =System.IO.Path.GetFileName(UploadFile.PostedFile.FileName);
			//Verifico che il file inviato sia un file excel
			if(Path.GetExtension(FileName) !=".xls")
			{
				lblMessage.Text="Il File selezionato non è un file Excel!";
				return true;
			}
			//Splitto il nome del file per ricavare il codice edifio mese anno
			string[] arrstr=FileName.Split('_');
			//Controllo la lunghezza dell'array
			if(arrstr.Length<4)
			{
				lblMessage.Text="Il File selezionato non è un file Valido per l'invio il formato deve essere: PMX_xls_NOMEEDIFICIO_MESE_ANNO_VERSIONE.xls!";
				return true;
			}
			//Recuper il nome del
			string BL_ID=arrstr[2];
			string Month =GetMese(arrstr[3]);
			string Year;
			
			if(arrstr[4].Length==2)
				Year="20" + arrstr[4];
			else
				Year= arrstr[4];
			//Recupero il codice edificio dalla combo
			string[] CodEdi=DrEdifici.Items[DrEdifici.SelectedIndex].Text.Split(' ');
			if(CodEdi[0].Trim()!=BL_ID)
			{
				lblMessage.Text="Il Nome del File selezionato contiene un Edificio corrisponde all'edificio selezionato!";
				return true;
			}
			if(DropMese.SelectedValue!=Convert.ToInt32(Month).ToString())
			{
				lblMessage.Text="Il Nome del File selezionato contiene un Mese corrisponde a quello selezionato!";
				return true;
			}
			if(DropAnno.SelectedValue!=Year)
			{
				lblMessage.Text="Il Nome del File selezionato contiene un Anno non corrisponde a quello selezionato!";
				return true;
			}

			int result=0;
			string username=Context.User.Identity.Name; 
			int Id_Bl=Convert.ToInt32(DrEdifici.SelectedValue);
			//Verifico che il piano Proposto Inviato non sia stato già accettato o eseguito 
			//(Deve stare come proposto)
			if(DrTipoDocumenti.SelectedValue=="3")//PIANO PROPOSTO
			{
				result=_inviodoc.IsValidStatus(Id_Bl,Convert.ToInt32(Month),Convert.ToInt32(Year),3,username);
				if(result==-1)
				{
					lblMessage.Text="Il Programma non può essere aggiornato in Proposto perchè è già eseguito in precedenza o non stato accettato!";
					return true;
				}
			}
			
			//Verifico che il Piano Eseguito Inviato stia con stato Accettato (quindi non proposto) 
			//e che non stia con stato come già eseguito
			if(DrTipoDocumenti.SelectedValue=="4")//PIANO ESEGUITO
			{
				if(arrstr[0].ToUpper()!="PME")
				{
					lblMessage.Text="Il Programma inviato come Eseguito perchè è il nome del file non inizia con PME!";
					return true;
				}

				result=_inviodoc.IsValidStatus(Id_Bl,Convert.ToInt32(Month),Convert.ToInt32(Year),4,username);
				if(result==-1)
				{
					lblMessage.Text="Il Programma non può essere aggiornato in Eseguito perchè è già eseguito in precedenza o non stato accettato!";
					return true;
				}
			}

			//Verifico che il piano Accettato Inviato stia con stato proposto e non stia già con stato 
			//accettato o eseguito
			if(DrTipoDocumenti.SelectedValue=="5")//PIANO ACCETTATO
			{
				result=_inviodoc.IsValidStatus(Id_Bl,Convert.ToInt32(Month),Convert.ToInt32(Year),5,username);
				if(result==-1)
				{
					lblMessage.Text="Il Programma non può essere aggiornato in Accetto perchè è già eseguito in precedenza o non stato accettato!";
					return true;
				}
			}

			return false;
		}

		private void SendDoc()
		{
			string PathDir=Server.MapPath("../Doc_DB");
			if (UploadFile.PostedFile!=null && UploadFile.PostedFile.FileName!="") 
			{
				PathDir=PathDir + @"\Manutenzione Programmata";//Manutenzione Programmata
				if(!Directory.Exists(PathDir))
					Directory.CreateDirectory(PathDir);

				string PathDirAnnuale=PathDir + @"\PAM" + DropAnno.SelectedValue;//Cartella del Piano annuale

				if(!Directory.Exists(PathDirAnnuale))
					Directory.CreateDirectory(PathDirAnnuale);

				string PathDirMensile=PathDir + @"\PMP" + DropAnno.SelectedValue;//Cartella de Piano Mensile
				if(!Directory.Exists(PathDirMensile))
					Directory.CreateDirectory(PathDirMensile);

				string DestPath="";
				string[] CodEdi=DrEdifici.Items[DrEdifici.SelectedIndex].Text.Split(' ');
				if(DrTipoDocumenti.SelectedValue=="3" || DrTipoDocumenti.SelectedValue=="4" || DrTipoDocumenti.SelectedValue=="5")//Piano mensile
				{
					
					PathDirMensile =PathDirMensile + @"\" + CodEdi[0].Trim();//Cartella de Piano Mensile
					if(!Directory.Exists(PathDirMensile))
						Directory.CreateDirectory(PathDirMensile);
					DestPath=PathDirMensile;
				}
				else//Piano Annuale
				{
					DestPath=PathDirAnnuale;
				}
				string FileName=DestPath + @"\" + System.IO.Path.GetFileName(UploadFile.PostedFile.FileName);
				
				//Salvo il file nella directory
				if (File.Exists(FileName))
				{
					//File.Delete(FileName);
					lblMessage.Text="Impossibile Salvare il file inviato. Il file già esiste, rinominare il file o selezionare un file diverso.";
					return;
				}


				//Controlla che il file inviato corrisponda all'edificio selezionato.
				if(IsValidDocMensile()==true)
					return;

				UploadFile.PostedFile.SaveAs(FileName);

				SalvaInvio();
				//Salvo le modifiche al piano mensile
				if(DrTipoDocumenti.SelectedValue=="3") UpdatePMP(FileName,PMPExcel.UpdateType.Proposto);
				if(DrTipoDocumenti.SelectedValue=="4") UpdatePMP(FileName,PMPExcel.UpdateType.Eseguito);	
				if(DrTipoDocumenti.SelectedValue=="5") UpdatePMP(FileName,PMPExcel.UpdateType.Accettato);
			
				SendMail(FileName);
		
			}
		}


		private void SendMail(string FileName)
		{
			string[] CodEdi=DrEdifici.Items[DrEdifici.SelectedIndex].Text.Split(' ');
			int Id_progetto=_inviodoc.GetIdProgetto(CodEdi[0].Trim());
			string FileZip ="";
			//Se il piano è eseguito ricreo il file A8 ed XSL
			if(DrTipoDocumenti.SelectedValue=="4") 
			{
				
				
				string ConnectionStr =System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
				string Master=Server.MapPath("../MasterExcel");
				string Out=Path.GetDirectoryName(FileName);
				string FileExcel="";
				string FileExcelA8="";
				//CREAZIONE DEL FILE EXCEL PME
				ExcelWritePMP   exc=new ExcelWritePMP(Master,Out,ConnectionStr);
				try
				{
					FileExcel=exc.WriteFilePMP(CodEdi[0].Trim(),Convert.ToInt32(DropMese.SelectedValue),Convert.ToInt32(DropAnno.SelectedValue));
			
				}
				finally 
				{
					if (exc != null)
						((IDisposable)exc).Dispose();

				}
//				if(Id_progetto==1)
//				{
//					MP_RPT_XLS.MPRPT rpt=new MP_RPT_XLS.MPRPT();
//					try
//					{
//						rpt.Anno =Convert.ToInt32(DropAnno.SelectedValue);
//						rpt.CodSede =CodEdi[0].Trim();
//						rpt.Mese =Convert.ToInt32(DropMese.SelectedValue);
//						rpt.PathFileOutPut = Out;
//						rpt.StrDataDdb =ConnectionStr;
//						rpt.GeneraRptXlsMp(Master,CodEdi[0].Trim(),
//							Convert.ToInt32(DropMese.SelectedValue),Convert.ToInt32(DropAnno.SelectedValue));
//
//						FileExcelA8=rpt.NomeFileCompleto;
//						
//					}
//					finally 
//					{
//						if (rpt != null)
//							((IDisposable)rpt).Dispose();
//
//					}
//				
//				}

				FileZip = Path.GetDirectoryName(FileExcel) + @"\" + Path.GetFileNameWithoutExtension(FileExcel) + ".zip";
		
				if (File.Exists(FileZip))
					File.Delete(FileZip);

				ZipOutputStream s = new ZipOutputStream(File.Create(FileZip)); 
				s.SetLevel(5); // 0 - store only to 9 - means best compression 
				FileStream fs = File.OpenRead(FileExcel); 
				byte[] buffer = new byte[fs.Length]; 
				fs.Read(buffer, 0, buffer.Length); 
				ZipEntry entry = new ZipEntry(Path.GetFileName(FileExcel)); 
				s.PutNextEntry(entry); 
				s.Write(buffer, 0, buffer.Length); 


//				if(File.Exists(FileExcelA8))
//				{
//					fs = File.OpenRead(FileExcelA8); 
//					buffer = new byte[fs.Length]; 
//					fs.Read(buffer, 0, buffer.Length); 
//					entry = new ZipEntry(Path.GetFileName(FileExcelA8)); 
//					s.PutNextEntry(entry); 
//					s.Write(buffer, 0, buffer.Length); 
//				}

				s.Finish(); 
				s.Close(); 
				fs.Close();
				FileExcelA8="";
				SalvaEseguito(FileExcel,FileExcelA8);
			}
			else
			{


//				string FileExcelA8="";
//				if(Id_progetto==1)
//				{
//					string ConnectionStr =System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
//					string Master=Server.MapPath("../MasterExcel");
//					string Out=Path.GetDirectoryName(FileName);
//
//					MP_RPT_XLS.MPRPT rpt=new MP_RPT_XLS.MPRPT();
//					try
//					{
//						rpt.Anno =Convert.ToInt32(DropAnno.SelectedValue);
//						rpt.CodSede =CodEdi[0].Trim();
//						rpt.Mese =Convert.ToInt32(DropMese.SelectedValue);
//						rpt.PathFileOutPut = Out;
//						rpt.StrDataDdb =ConnectionStr;
//						rpt.GeneraRptXlsMp(Master,CodEdi[0].Trim(),
//							Convert.ToInt32(DropMese.SelectedValue),Convert.ToInt32(DropAnno.SelectedValue));
//
//						FileExcelA8=rpt.NomeFileCompleto;
//					//	SalvaA8(FileExcelA8);
//					}
//					finally 
//					{
//						if (rpt != null)
//							((IDisposable)rpt).Dispose();
//
//					}
//				}

				FileZip = Path.GetDirectoryName(FileName) + @"\" + Path.GetFileNameWithoutExtension(FileName) + ".zip";
		
				if (File.Exists(FileZip))
					File.Delete(FileZip);

				ZipOutputStream s = new ZipOutputStream(File.Create(FileZip)); 
				s.SetLevel(5); // 0 - store only to 9 - means best compression 
				FileStream fs = File.OpenRead(FileName); 
				byte[] buffer = new byte[fs.Length]; 
				fs.Read(buffer, 0, buffer.Length); 
				ZipEntry entry = new ZipEntry(Path.GetFileName(FileName)); 
				s.PutNextEntry(entry); 
				s.Write(buffer, 0, buffer.Length); 

//				if(File.Exists(FileExcelA8))
//				{
//					fs = File.OpenRead(FileExcelA8); 
//					buffer = new byte[fs.Length]; 
//					fs.Read(buffer, 0, buffer.Length); 
//					entry = new ZipEntry(Path.GetFileName(FileExcelA8)); 
//					s.PutNextEntry(entry); 
//					s.Write(buffer, 0, buffer.Length); 
//				}

				s.Finish(); 
				s.Close(); 
				fs.Close();
	
			}
			DataSet _Ds;
			if(DrTipoDocumenti.SelectedValue=="4")
			  _Ds= _inviodoc.GetDestinatari(int.Parse(DrEdifici.SelectedValue),true);
			else
			  _Ds= _inviodoc.GetDestinatari(int.Parse(DrEdifici.SelectedValue),false);

			DataColumn dc = new DataColumn("IsExecute",System.Type.GetType("System.Int32"));
			dc.DefaultValue =0;
			DataTable dt=_Ds.Tables[0];
			dt.Columns.Add(dc);

			bool flag_mail=false;
			string MailUser=_inviodoc.GetMailByUser(); 
			foreach(DataRow riga in  dt.Rows)
			{
				if(MailUser.Trim().ToLower()==riga["email"].ToString().Trim().ToLower())
				{
					flag_mail=true;
					riga["IsExecute"]=1;
					break;
				}
			}
			
			if(flag_mail==false && MailUser!="")
			{
				DataRow riga=dt.NewRow();
				riga["email"]=MailUser;
				riga["IsExecute"]=1;
				dt.Rows.Add(riga);
			}
			dt.AcceptChanges();
			
			int Count=0;
			string Dest="";

			foreach(DataRow riga in dt.Rows)
			{

//				MailMessage mailMessage = new MailMessage();
//				mailMessage.BodyFormat = MailFormat.Html;
//				mailMessage.BodyEncoding=System.Text.Encoding.UTF8; 
//				mailMessage.From = ConfigurationSettings.AppSettings["MailFrom"].ToString();
//				mailMessage.To = riga["email"].ToString();
//				mailMessage.Cc ="ssys@cft-sir.it";  
 

				Count++;
				if(riga["id_utente"].ToString()!="")
				{
					Dest=riga["email"].ToString();
				}
				else
				{
					Dest+=riga["email"].ToString() + "; ";
					if (Count!=dt.Rows.Count) continue;
				}


				MailMessage mailMessage= new MailMessage();
				mailMessage.BodyFormat = MailFormat.Html;
				mailMessage.BodyEncoding=System.Text.Encoding.UTF8; 
				mailMessage.From = ConfigurationSettings.AppSettings["MailFrom"].ToString();
				mailMessage.To =Dest;
				mailMessage.Cc="ssys@cft-sir.it";
				Dest="";


				string Body="";
				//Se è un piano Mensile
				if (DrTipoDocumenti.SelectedValue=="3" || DrTipoDocumenti.SelectedValue=="4" || DrTipoDocumenti.SelectedValue=="5")
				{
					
					string Lk="";
					string Lk1="";

					if (DrTipoDocumenti.SelectedValue=="3") //Proposto
					{
						string tipo="";
						if(riga["id_utente"].ToString()!="")
						{
							tipo="&t=m&e=" + DrEdifici.SelectedValue;
							Lk="<DIV>&nbsp;</DIV><DIV>&nbsp;</DIV><DIV><A href=\"http://www.cft-sir.it/MEHV/default.aspx?u=" +  riga["id_utente"].ToString() + tipo + "&s=3&id=" + Result.ToString() + "\">Programma Accettato </A></DIV>";
							Lk+="<DIV>&nbsp;</DIV><DIV><A href=\"http://www.cft-sir.it/MEHV/default.aspx?u=" +  riga["id_utente"].ToString() + tipo + "&s=4&id=" + Result.ToString() + "\">Programma Accettato con Riserva</A></DIV>";
							Lk+="<DIV>&nbsp;</DIV><DIV><A href=\"http://www.cft-sir.it/MEHV/default.aspx?u=" +  riga["id_utente"].ToString() + tipo + "&s=2&id=" + Result.ToString()+ "\">Programma Rifiutato</A></DIV><DIV>&nbsp;</DIV>";
						
							//						Lk="<DIV>&nbsp;</DIV><DIV>&nbsp;</DIV><DIV><A href=\"http://192.168.143.180/MEHV/default.aspx?u=" +  riga["id_utente"].ToString() + tipo + "&s=3&id=" + Result.ToString() + "\">Programma Acettato </A></DIV>";
							//						Lk+="<DIV>&nbsp;</DIV><DIV><A href=\"http://192.168.143.180/MEHV/default.aspx?u=" +  riga["id_utente"].ToString() + tipo + "&s=4&id=" + Result.ToString() + "\">Programma Acettato con Riserva</A></DIV>";
							//						Lk+="<DIV>&nbsp;</DIV><DIV><A href=\"http://192.168.143.180/MEHV/default.aspx?u=" +  riga["id_utente"].ToString() + tipo + "&s=2&id=" + Result.ToString()+ "\">Programma Rifiutato</A></DIV><DIV>&nbsp;</DIV>";

							Lk1="<DIV>Sono predisposti i seguenti link per <STRONG>Approvare</STRONG>,&nbsp;<STRONG>Approvare con promessa di aggiustamento</STRONG>&nbsp;o&nbsp;<STRONG>Respingere</STRONG> il programma di manutenzione.</DIV>";
						}
					}
					string CodiceEdi=DrEdifici.Items[DrEdifici.SelectedIndex].Text.Substring(0,DrEdifici.Items[DrEdifici.SelectedIndex].Text.IndexOf("-")-1);
					mailMessage.Subject =  string.Format(DrTipoDocumenti.Items[DrTipoDocumenti.SelectedIndex].Text + " mese " + DropMese.Items[DropMese.SelectedIndex].Text + " " + DropAnno.Items[DropAnno.SelectedIndex].Text.Substring(2) + " Sede: " + CodiceEdi + " Data invio: {0} Ora: {1}",DateTime.Now.ToLongDateString(),DateTime.Now.ToLongTimeString());
					
					string Destinatari="";
					foreach(DataRow riga2 in  dt.Rows)
						Destinatari+=riga2["email"].ToString() + "; ";


					Body="<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">";
					Body+="<HTML><HEAD><META http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\">";
					Body+="<BODY bgColor=#ffffff><DIV>Altri destinatari: " +Destinatari + "</DIV>";
					Body+="<DIV>E' stato inserito un nuovo documento del " + DrTipoDocumenti.Items[DrTipoDocumenti.SelectedIndex].Text + " relativo alla sede " + DrEdifici.Items[DrEdifici.SelectedIndex].Text;
					Body+="	del mese di " + DropMese.Items[DropMese.SelectedIndex].Text + " " + DropAnno.Items[DropAnno.SelectedIndex].Text +"</DIV>";
					Body+="<DIV>con le seguenti annotazioni:</DIV><DIV>" + TxtAnnotazioni.Text + "</DIV>";
					Body+=Lk1;
					Body+=Lk;
					Body+="<DIV>&nbsp;</DIV>";

					
					if(riga["IsExecute"].ToString()=="1")
					{
						Body+="</br>Rapporto del File inviato:</br>";
						Body+=lblMessage.Text;
					}
					Body+="<DIV>SIR Cofathec Servizi S.p.a.</DIV><DIV>&nbsp;</DIV></BODY></HTML>";

					mailMessage.Body = Body;

					//mailMessage.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 1;
					mailMessage.Fields["http://schemas.microsoft.com/cdo/configuration/sendusername"] = ConfigurationSettings.AppSettings["usersmtp"].ToString(); 
					mailMessage.Fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"] = ConfigurationSettings.AppSettings["pwdsmtp"].ToString();

					MailAttachment attach = new MailAttachment(FileZip);
					mailMessage.Attachments.Add(attach);
					SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["SmtpServer2"].ToString();
					SmtpMail.Send(mailMessage);
				}
				else//Piano annuale
				{

					string Lk="";
					string Lk1="";
					if (DrTipoDocumenti.SelectedValue=="1") //Proposto
					{
						string tipo="";
						if(riga["id_utente"].ToString()!="")
						{
							tipo="&t=a&e=" + DrEdifici.SelectedValue;
							Lk="<DIV>&nbsp;</DIV><DIV><A href=\"http://www.cft-sir.it/MEHV/default.aspx?u=" +  riga["id_utente"].ToString() + tipo + "&s=3&id=" + Result.ToString() + "\">Piano Accettato </A></DIV>";
							Lk+="<DIV>&nbsp;</DIV><DIV><A href=\"http://www.cft-sir.it/MEHV/default.aspx?u=" +  riga["id_utente"].ToString() + tipo + "&s=4&id=" + Result.ToString() + "\">Piano Accettato con Riserva</A></DIV>";
							Lk+="<DIV>&nbsp;</DIV><DIV><A href=\"http://www.cft-sir.it/MEHV/default.aspx?u=" +  riga["id_utente"].ToString() + tipo + "&s=2&id=" + Result.ToString()+ "\">Piano Rifiutato</A></DIV><DIV>&nbsp;</DIV>";
						
							Lk1="<DIV>Sono predisposti i seguenti link per <STRONG>Approvare</STRONG>,&nbsp;<STRONG>Approvare con promessa di aggiustamento</STRONG>&nbsp;o&nbsp;<STRONG>Respingere</STRONG> il piano di manutenzione Annuale.</DIV>";
						}
					}
					

					string CodiceEdi=DrEdifici.Items[DrEdifici.SelectedIndex].Text.Substring(1,DrEdifici.Items[DrEdifici.SelectedIndex].Text.IndexOf("-")-1);
					mailMessage.Subject =  string.Format(DrTipoDocumenti.Items[DrTipoDocumenti.SelectedIndex].Text +  " anno " + DropAnno.Items[DropAnno.SelectedIndex].Text.Substring(2) + " Sede: " + CodiceEdi + " Data invio: {0} Ora: {1}",DateTime.Now.ToLongDateString(),DateTime.Now.ToLongTimeString());
					
					string Destinatari="";
					foreach(DataRow riga2 in  dt.Rows)
						Destinatari+=riga2["email"].ToString() + "; ";
					Body="<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">";
					Body+="<HTML><HEAD><META http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\">";
					Body+="<BODY bgColor=#ffffff><DIV>Altri destinatari: " +Destinatari + "</DIV>";
					Body+="<DIV>E' stato inserito un nuovo documento del " + DrTipoDocumenti.Items[DrTipoDocumenti.SelectedIndex].Text + " relativo alla sede " + DrEdifici.Items[DrEdifici.SelectedIndex].Text;
					Body+="	" + DropAnno.Items[DropAnno.SelectedIndex].Text +"</DIV>";
					Body+="<DIV>con le seguenti annotazioni:</DIV><DIV>" + TxtAnnotazioni.Text + "</DIV>";
					Body+=Lk1;
					Body+=Lk;
					Body+="<DIV>&nbsp;</DIV>";

					
					if(riga["IsExecute"].ToString()=="1")
					{
						Body+="</br>Rapporto del File inviato:</br>";
						Body+=lblMessage.Text;
					}
					Body+="<DIV>SIR Cofathec Servizi S.p.a.</DIV><DIV>&nbsp;</DIV></BODY></HTML>";

					mailMessage.Body = Body;
					MailAttachment attach = new MailAttachment(FileZip);
					mailMessage.Attachments.Add(attach);

					//mailMessage.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 1;
					mailMessage.Fields["http://schemas.microsoft.com/cdo/configuration/sendusername"] = ConfigurationSettings.AppSettings["usersmtp"].ToString(); 
					mailMessage.Fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"] = ConfigurationSettings.AppSettings["pwdsmtp"].ToString();

					SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["SmtpServer2"].ToString();
					SmtpMail.Send(mailMessage);

				}
			}//Ciclo for

		}
	
		private string GetMese(string mese)
		{
			if(mese.ToUpper()=="GEN") return "01";
			if(mese.ToUpper()=="FEB") return "02";
			if(mese.ToUpper()=="MAR") return "03";
			if(mese.ToUpper()=="APR") return "04";
			if(mese.ToUpper()=="MAG") return "05";
			if(mese.ToUpper()=="GIU") return "06";
			if(mese.ToUpper()=="LUG") return "07";
			if(mese.ToUpper()=="AGO") return "08";
			if(mese.ToUpper()=="SET") return "09";
			if(mese.ToUpper()=="OTT") return "10";
			if(mese.ToUpper()=="NOV") return "11";
			if(mese.ToUpper()=="DIC") return "12";

			if(mese.ToUpper()=="GENNAIO") return "01";
			if(mese.ToUpper()=="FEBBRAIO") return "02";
			if(mese.ToUpper()=="MARZO") return "03";
			if(mese.ToUpper()=="APRILE") return "04";
			if(mese.ToUpper()=="MAGGIO") return "05";
			if(mese.ToUpper()=="GIUGNO") return "06";
			if(mese.ToUpper()=="LUGLIO") return "07";
			if(mese.ToUpper()=="AGOSTO") return "08";
			if(mese.ToUpper()=="SETTEMBRE") return "09";
			if(mese.ToUpper()=="OTTOBRE") return "10";
			if(mese.ToUpper()=="NOVEMBRE") return "11";
			if(mese.ToUpper()=="DICEMBRE") return "12";

			return "";
		}
	}
	
}
