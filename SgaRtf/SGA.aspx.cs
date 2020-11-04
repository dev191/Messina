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
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace TheSite.SgaRtf
{

	public class SGA : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnGenera;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox txtWrId;
		protected System.Web.UI.WebControls.Label lblWrID;
		public string Str1 ;

		private void Page_Load(object sender, System.EventArgs e)
		{
			//OpenFileRtf();
//			Response.Clear();
//			Response.AddHeader("contect-dispotion","attachment;filename=sga.rtf");
//			Response.ContentType = "application/octet-sream";
//		//	Response.ContentType = "application/rtf";
//			Response.Write(Str1);
			
		}	
//		private void OpenFileRtf()
//		{
//			string path = @"C:\Inetpub\wwwroot\H3G\SgaRtf\SGA_PALERMO_101113_Filtri UTA.rtf";
//			// Delete the file if it exists.
//			if (!File.Exists(path)) 
//			{
//				// Create the file.
//				using (FileStream fs = File.Create(path)) 
//				{
//					Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
//
//					// Add some information to the file.
//					fs.Write(info, 0, info.Length);
//				}
//			}
//
//			// Open the stream and read it back.
//			using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None)) 
//			{
//				byte[] b = new byte[fs.Length];
//				UTF8Encoding temp = new UTF8Encoding(true);
//
////				while (fs.Read(b,0,b.Length) > 0) 
////				{
////					Console.WriteLine(temp.GetString(b));
////				}
//				fs.Read(b,0,Convert.ToInt32(fs.Length));
//				Str1 =  temp.GetString(b);
//
//			}
//		}





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
			
			this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnGenera_Click(object sender, System.EventArgs e)
		{
			

//			MemoryStream stream=new MemoryStream();
//			//creo l'oggetto xml
//
//			XmlTextWriter writer=new XmlTextWriter(stream,Encoding.Default);
//			writer.WriteStartElement("data");
//			writer.WriteElementString("ctr01","1");
//			//writer.WriteElementString("surname",txtSurname.Value);
//			writer.WriteEndElement();
//			writer.Flush();
//
//			stream.Position=0;
//			//carico l'xmldocument
//			
//			XPathDocument xmlDoc=new XPathDocument(stream);
//			//la stringa che conterrà il body
//
//			StringBuilder docRdf=new StringBuilder();
//			//carico il file xslt
//
//			XslTransform xmlEngine=new XslTransform();
//			xmlEngine.Load(@"C:\Inetpub\wwwroot\H3G\SgaRtf\XSLT\XSLsgaRpt01.xslt");
//			//effettuo la trasformazione
//
//			xmlEngine.Transform(xmlDoc,null,new StringWriter(docRdf),null);
			//string PathSgaXlst = Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings["FileXlstRtfSga"]);
			string formatdate=DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString() +DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() +DateTime.Now.Year.ToString();	
			string fileName = System.Configuration.ConfigurationSettings.AppSettings["FileXlstRtfSga"];
			string PathSgaXlst = Server.MapPath(Request.ApplicationPath + fileName);
			TheSite.Classi.RptRtf.SGARTF trs = new TheSite.Classi.RptRtf.SGARTF();
			trs.FileXlst = PathSgaXlst;
			trs.GeneraRtf(Convert.ToInt32(txtWrId.Text),formatdate);

			
//			trs.OpereCivili=true;
//			trs.ImpiantiMeccanici=true;
//			trs.ImpiantiElettrici=true;
//			trs.Conduzione=true;
//			trs.ManProg=true;
//			trs.Odl=true;
//			trs.NonDifferibile=true;
//			trs.RichiestaSopralluogo=true;
//			trs.ManCorrDiff=true;
//			trs.ManMiglior=true;
//			trs.CompCanSi=true;
//			trs.CompCanNo=true;
//			trs.BoCompForfait=true;
//			trs.BoCompMisura=true;
			

//			trs.DataIn = "Da/ta/in";
//			trs.OraIn ="Or:ra";
//			trs.Ndie = "Ndie";
//			trs.DataDelDifferibile = "Da/di/ff";
//			trs.Num = "Num";
//			trs.DataDelSopralluogo = "Da/so/pr";
//			trs.DataEffetSopralluogo="Da/ef/pr";
//			trs.DaLav = "DaLav";
//			trs.DescGuastoAnomaliaR1 = "Descrizione Guasto Anomalia prima riga";
////			trs.DescGuastoAnomaliaR2 = "Descrizione Guasto Anomalia seconda riga";
//			trs.CausaPresGuastAnR1= "Causa Guasto Anomalia prima riga";
//			trs.CausaPresGuastAnR2 = "Causa Guasto Anomalia seconda riga";
//			trs.PrestazImpStrR1 = "effetto del guast/anomalia sulle prestazioni prima riga";
//			trs.PrestazImpStrR2 ="effetto del guast/anomalia sulle prestazioni seconda riga";
//			trs.SolPropR1 = "Soluzione proposta prima riga";
//			trs.SolPropR2 = "Soluzione proposta seconda riga";
//			trs.DataPrevInLav= "da/pr/op";
//			trs.DurPrevLav ="dlv";
//			trs.CompMisura = "Misura";
//			trs.IvaMisura= "IVAM";
//			trs.CompForfait="Forfait";
//			trs.IvaForfait="IVAF";
//			trs.ModPagamento="Modalita pagam";
//			trs.NomeFileAllegatiR1="Allegati prima riga";
//			trs.NomeFileAllegatiR2="Allegati seconda riga";
//			trs.NoteProgettoR1="Note progetto prima riga";
//			trs.NoteProgettoR2="Note progetto seconda riga";
//			trs.NomeResp="Nome Responsabile";
//			trs.TelefonoResp="tel Resp";
//			trs.FaxResp ="fax resp";
//			trs.MobileResp ="mob resp";
//			trs.FirmaResp ="Firam Responsabile";
//			trs.NomeVisSm ="Nom Vis Sm";
//			trs.FirmaVisSm ="Firma VIS SM";
//			trs.DataVisSm ="vi/sf/mm";
//			trs.NomeVisFm= "Nome Vis Fm";
//			trs.FirmVIsFm ="Fiema Vs Fm";
//			trs.DataVisFm = "vi/sf/mm";



//			if (File.Exists(@"C:\Inetpub\wwwroot\H3G\Doc_DB\Sga01.rtf")) 
//			{
//				File.Delete(@"C:\Inetpub\wwwroot\H3G\Doc_DB\Sga01.rtf");
//				
//			}
//			using (StreamWriter sw = File.CreateText(@"C:\Inetpub\wwwroot\H3G\Doc_DB\Sga01.rtf"))
//			{
//				sw.Write(trs.EseguiTrasformazione(PathSgaXlst));
//				sw.Close();
//			}
//		   using (StreamWriter simg = File.CreateText(@"C:\H3G_Svil\Rtf\MasterRtfSGA\immagine.txt"))
//			{
//				StringBuilder bimg=new StringBuilder();
//				byte[] b = GetPhoto(@"C:\H3G_Svil\Rtf\MasterRtfSGA\img\Immagine02.bmp");
//				for(int i=0; i<b.Length;i++)
//				{
//
//					bimg.Append( Convert.ToString(b[i],16));
//				}
//				
//				simg.Write(bimg.ToString());
//				simg.Close();
//			}
				
		}
//		private  byte[] GetPhoto(string fileName)
//		{
//			//string filePath = Server.MapPath(Request.ApplicationPath + ConfigurationSettings.AppSettings["ImmaginiEq"] + fileName );
//			if(File.Exists(fileName))//filePath))
//			{
//				FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
//				BinaryReader br = new BinaryReader(fs);
//				byte[] photo = br.ReadBytes((int)fs.Length);
//				br.Close();
//				fs.Close();
//				return photo;
//			}
//			else
//			{
//				return null;
//			}
//		}


	}
}
