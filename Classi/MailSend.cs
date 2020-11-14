using System;
using System.IO;
using System.Collections;
using System.Web.Mail;
using System.Data;
using System.Data.OracleClient;
using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using S_Controls.Collections;
using ApplicationDataLayer.DBType;
using System.Configuration;

 
public enum DocType
{
	SGA,
	DIE,
	XLS
}

namespace TheSite.Classi
{
	/// <summary>
	/// Descrizione di riepilogo per MailSend.
	/// </summary>
	/// 
	public class MailSend
	{
		Classi.ManCorrettiva.ClManCorrettiva _ClManCorrettiva =new TheSite.Classi.ManCorrettiva.ClManCorrettiva();
		ApplicationDataLayer.OracleDataLayer _OraDl;
		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
		public MailSend()
		{
			_OraDl = new OracleDataLayer(s_ConnStr);
		}

		public void SendMail(string filename,int wr_id,DocType TipoDoc)
		{
			string FileName=filename;
			string maillist="";
			
			//Recupero i dati della RDL
				DataSet _Ds=  _ClManCorrettiva.GetSingleRdlNew(wr_id);
				DataRow riga=_Ds.Tables[0].Rows[0];
				//Recupero l'id dell'edificio
				int bl_id=int.Parse(riga["ID_BL"].ToString());
				int servizio_id=int.Parse(riga["servizio_id"].ToString());
				//Recupero i destinatari legati all'edificio
				ArrayList li= GetDestinatari(bl_id,servizio_id,TipoDoc);
			
			
			foreach(string mail in li)
			{		
				maillist+=mail +";";
			}
				MailMessage mailMessage = new MailMessage ();  
				mailMessage.From = ConfigurationSettings.AppSettings["MailFrom"].ToString();
				mailMessage.To = maillist;
				//mailMessage.Cc ="alessandro.giuli@cofathec.it";
				mailMessage.Subject = string.Format("Documento: {0} Data invio: {1} Ora: {2} ({3})",Path.GetFileName(FileName),DateTime.Now.ToLongDateString(),DateTime.Now.ToLongTimeString(),wr_id);
				mailMessage.Body = "";
				mailMessage.BodyFormat = MailFormat.Html;
				// Andrea
				MailAttachment attach = new MailAttachment(FileName);
			
				mailMessage.Attachments.Add(attach);
			//mailMessage.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 1;
			mailMessage.Fields["http://schemas.microsoft.com/cdo/configuration/sendusername"] = ConfigurationSettings.AppSettings["usersmtp"].ToString(); 
			mailMessage.Fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"] = ConfigurationSettings.AppSettings["pwdsmtp"].ToString();

			SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["SmtpServer2"].ToString();
				SmtpMail.Send(mailMessage);

		}
		public void SendMailXls(string filename,DocType TipoDoc, int id_bl)
		{
			string FileName=filename;
			string maillist="";		
		
			//Recupero i destinatari legati all'edificio
			ArrayList li= GetDestinatariXls(id_bl);
			
			foreach(string mail in li)
			{		
				maillist+=mail +";";
			}
			MailMessage mailMessage = new MailMessage ();  
			mailMessage.From = ConfigurationSettings.AppSettings["MailFrom"].ToString();
			mailMessage.To = maillist;
			mailMessage.Cc ="alessandro.giuli@cofely-gdfsuez.com";
			mailMessage.Subject = string.Format("Documento: {0} Data invio: {1} Ora: {2}",Path.GetFileName(FileName),DateTime.Now.ToLongDateString(),DateTime.Now.ToLongTimeString());
			mailMessage.Body = "";
			mailMessage.BodyFormat = MailFormat.Html;

			MailAttachment attach = new MailAttachment(FileName);
			
			mailMessage.Attachments.Add(attach);
			//mailMessage.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 1;
			mailMessage.Fields["http://schemas.microsoft.com/cdo/configuration/sendusername"] = ConfigurationSettings.AppSettings["usersmtp"].ToString(); 
			mailMessage.Fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"] = ConfigurationSettings.AppSettings["pwdsmtp"].ToString();

			SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["SmtpServer2"].ToString();
			SmtpMail.Send(mailMessage);

		}
			/// <summary>
			/// Recupera le mail dei destinatari Xls
			///</summary>
		
		private ArrayList GetDestinatariXls(int bl_id)
		{
			
			S_ControlsCollection _SColl = new S_ControlsCollection();
		
			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_bl_id";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Value = bl_id;
			_SColl.Add(p);

			p = new S_Object();
			p.ParameterName = "IO_CURSOR";
			p.DbType = CustomDBType.Cursor;
			p.Direction = ParameterDirection.Output;
			p.Index = _SColl.Count;
			_SColl.Add(p);

			string s_StrSql = "PACK_DETINATARIINVIO.SP_GETDESTINATARIXLS";
			 
			DataSet _Ds =  _OraDl.GetRows(_SColl, s_StrSql);

			ArrayList li =new ArrayList();
			foreach(DataRow riga in  _Ds.Tables[0].Rows)
				li.Add(riga["mail"].ToString());
			
			return li;
		}
	
		/// <summary>
		/// Recupera le mail dei destinatari
		/// </summary>
		/// <param name="TipoDoc">Destinatari legati a quel tipo di documento</param>
		/// <param name="bl_id">Recupera i destinatari legati a quell'edificio</param>
		/// <returns></returns>
		private ArrayList GetDestinatari(int bl_id,int servizio_id,DocType TipoDoc)
		{
			
			S_ControlsCollection _SColl = new S_ControlsCollection();
		
			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_bl_id";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Value = bl_id;
			_SColl.Add(p);

			p = new S_Object();
			p.ParameterName = "p_servizio_id";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Value = servizio_id;
			_SColl.Add(p);

			p = new S_Object();
			p.ParameterName = "p_tipo_doc";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Value = TipoDoc.ToString();
			p.Size=250;
			_SColl.Add(p);

			p = new S_Object();
			p.ParameterName = "IO_CURSOR";
			p.DbType = CustomDBType.Cursor;
			p.Direction = ParameterDirection.Output;
			p.Index = _SColl.Count;
			_SColl.Add(p);

			string s_StrSql = "PACK_DETINATARIINVIO.SP_GETDESTINATARI";
			 
			DataSet _Ds =  _OraDl.GetRows(_SColl, s_StrSql);

			ArrayList li =new ArrayList();
			foreach(DataRow riga in  _Ds.Tables[0].Rows)
				li.Add(riga["mail"].ToString());
			
			return li;
		}
	
	}
}
