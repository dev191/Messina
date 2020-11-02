// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.ClassMail
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System.Configuration;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mail;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace TheSite.Classi
{
  public class ClassMail
  {
    private MailMessage msg;
    private string name;
    private string surname;
    private string idrichiesta;
    private string descrizione;
    private string codedi;
    private string responsabile;

    public string Name
    {
      get => this.name;
      set => this.name = value;
    }

    public string Surname
    {
      get => this.surname;
      set => this.surname = value;
    }

    public string Idrichiesta
    {
      get => this.idrichiesta;
      set => this.idrichiesta = value;
    }

    public string Decription
    {
      get => this.descrizione;
      set => this.descrizione = value;
    }

    public string CodiceEdificio
    {
      get => this.codedi;
      set => this.codedi = value;
    }

    public string Responsabile
    {
      get => this.responsabile;
      set => this.responsabile = value;
    }

    public ClassMail(MailMessage Messaggio, string Name, string Surmane, string IDRichiesta)
    {
      this.msg = Messaggio;
      this.msg.BodyFormat = MailFormat.Html;
      this.name = Name;
      this.surname = Surmane;
      this.idrichiesta = IDRichiesta;
    }

    public ClassMail(string Name, string Surmane, string IDRichiesta)
    {
      this.msg = new MailMessage();
      this.msg.BodyFormat = MailFormat.Html;
      this.name = Name;
      this.surname = Surmane;
      this.idrichiesta = IDRichiesta;
    }

    public ClassMail() => this.msg = new MailMessage();

    public MailMessage Messaggio
    {
      get => this.msg;
      set => this.msg = value;
    }

    public void SendMail(ClassMail.TipoMail tipomail)
    {
      MemoryStream memoryStream = new MemoryStream();
      XmlTextWriter xmlTextWriter = new XmlTextWriter((Stream) memoryStream, Encoding.UTF8);
      xmlTextWriter.WriteStartElement("data");
      xmlTextWriter.WriteElementString("name", this.name);
      xmlTextWriter.WriteElementString("surname", this.surname);
      xmlTextWriter.WriteElementString("idrichiesta", this.idrichiesta);
      xmlTextWriter.WriteElementString("descrizione", this.descrizione);
      xmlTextWriter.WriteElementString("codedi", this.codedi);
      xmlTextWriter.WriteElementString("responsabile", this.responsabile);
      xmlTextWriter.WriteEndElement();
      xmlTextWriter.Flush();
      memoryStream.Position = 0L;
      XPathDocument xpathDocument = new XPathDocument((Stream) memoryStream);
      StringBuilder sb = new StringBuilder();
      XslTransform xslTransform = new XslTransform();
      switch (tipomail)
      {
        case ClassMail.TipoMail.MailCreazioneRichiesta:
          xslTransform.Load(HttpContext.Current.Server.MapPath("..\\emailcreazione.xslt"));
          break;
        case ClassMail.TipoMail.MailEmissioneRichiesta:
          xslTransform.Load(HttpContext.Current.Server.MapPath("..\\email.xslt"));
          break;
      }
      xslTransform.Transform((IXPathNavigable) xpathDocument, (XsltArgumentList) null, (TextWriter) new StringWriter(sb), (XmlResolver) null);
      this.msg.Body = HttpContext.Current.Server.HtmlDecode(sb.ToString());
      memoryStream.Close();
      this.msg.Fields[(object) "http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = (object) 1;
      this.msg.Fields[(object) "http://schemas.microsoft.com/cdo/configuration/sendusername"] = (object) ConfigurationSettings.AppSettings["usersmtp"].ToString();
      this.msg.Fields[(object) "http://schemas.microsoft.com/cdo/configuration/sendpassword"] = (object) ConfigurationSettings.AppSettings["pwdsmtp"].ToString();
      SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["SmtpServer2"].ToString();
      SmtpMail.Send(this.msg);
    }

    public enum TipoMail
    {
      MailCreazioneRichiesta,
      MailEmissioneRichiesta,
    }
  }
}
