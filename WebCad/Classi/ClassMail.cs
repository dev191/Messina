using System;
using System.IO;
using System.Web.Mail;
using System.Xml;
using System.Xml.Xsl;  
using System.Xml.XPath;
using System.Text;
using System.Web;
 
namespace WebCad.Classi
{
	/// <summary>
	/// Descrizione di riepilogo per ClassMail.
	/// </summary>
	
	public class ClassMail
	{
		public enum TipoMail
		{
			MailCreazioneRichiesta=0,
			MailEmissioneRichiesta=1
		}

		#region Campi Privati
		private MailMessage msg;
		private string name;
		private string surname;
		private string idrichiesta;
		private string descrizione;
		private string codedi;
		private string responsabile;
		#endregion

		#region Proprietà pubbliche
		public string Name
		{
			get{return name;}
			set{name=value;}
		}
		public string Surname
		{
			get{return surname;}
			set{surname=value;}
		}
		public string Idrichiesta
		{
			get{return idrichiesta;}
			set{idrichiesta=value;}
		}
		public string Decription
		{
			get{return descrizione;}
			set{descrizione=value;}
		}
		public string CodiceEdificio
		{
			get{return codedi;}
			set{codedi=value;}
		}
		public string Responsabile
		{
			get{return responsabile;}
			set{responsabile=value;}
		}
		#endregion

		public ClassMail(MailMessage Messaggio, string Name, string Surmane, string IDRichiesta)
		{
			msg=Messaggio;
			//imposto le normali proprietà
			msg.BodyFormat=MailFormat.Html;
			name=Name;
			surname=Surmane;
			idrichiesta=IDRichiesta;
		}
		public ClassMail(string Name, string Surmane, string IDRichiesta)
		{
			msg=new MailMessage();
			//imposto le normali proprietà
			msg.BodyFormat=MailFormat.Html;
			name=Name;
			surname=Surmane;
			idrichiesta=IDRichiesta;
		}
		
		public ClassMail()
		{
			msg=new MailMessage();
		}
		public MailMessage Messaggio
		{
			get {return msg;}
			set{msg=value;}
		}

	
		public void SendMail(TipoMail tipomail)
		{
			MemoryStream stream=new MemoryStream();
			//creo l'oggetto xml
			XmlTextWriter writer=new XmlTextWriter(stream,Encoding.UTF8);
			writer.WriteStartElement("data");
			writer.WriteElementString("name", this.name);
			writer.WriteElementString("surname",this.surname);
			writer.WriteElementString("idrichiesta",this.idrichiesta);
			writer.WriteElementString("descrizione",this.descrizione);
			writer.WriteElementString("codedi",this.codedi);
			writer.WriteElementString("responsabile",this.responsabile);
			
			writer.WriteEndElement();
			writer.Flush();
			stream.Position=0;
			//carico l'xmldocument
			XPathDocument xmlDoc=new XPathDocument(stream);
			//la stringa che conterrà il body
			StringBuilder message=new StringBuilder();
			//carico il file xslt
			XslTransform xmlEngine=new XslTransform();
			if(tipomail==TipoMail.MailCreazioneRichiesta)
				xmlEngine.Load(HttpContext.Current.Server.MapPath("..\\emailcreazione.xslt"));
			else if(tipomail==TipoMail.MailEmissioneRichiesta)
				xmlEngine.Load(HttpContext.Current.Server.MapPath("..\\email.xslt"));

			//effettuo la trasformazione
			xmlEngine.Transform(xmlDoc,null,new StringWriter(message),null);
			msg.Body=HttpContext.Current.Server.HtmlDecode(message.ToString());
			stream.Close();
			
			//Parte riservata all'autenticazione sul server di posta
			//			msg.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserver") = "www.csy.it";
			//			msg.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 25;
			////			sendusing 1 Send message using the local SMTP service pickup directory. 
			////			sendusing 2 Send the message using the network (SMTP over the network).  
			//			msg.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2;
			////			smtpauthenticate 0 Do not authenticate. 
			////			smtpauthenticate 1 Use basic (clear-text) authentication. The configuration sendusername/sendpassword or postusername/postpassword fields are used to specify credentials. 
			////			smtpauthenticate 2 Use NTLM authentication (Secure Password Authentication in Microsoft® Outlook® Express). The current process security context is used to authenticate with the service. 
			//			msg.Fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1;
			//			msg.Fields("http://schemas.microsoft.com/cdo/configuration/sendusername") = "username"; 
			//			msg.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "password";
			//SmtpMail.SmtpServer="www.prm-ater-gescal.it.compsys"; 
			SmtpMail.SmtpServer=System.Configuration.ConfigurationSettings.AppSettings["SmtpServer"].ToString(); 
			//invio l'email
			SmtpMail.Send(msg);
			//			Response.Write("messaggio inviato");
		}
	}

}
