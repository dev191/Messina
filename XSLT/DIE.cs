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
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Text;
using ICSharpCode;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
namespace TheSite.XSLT
{
	/// <summary>
	/// Descrizione di riepilogo per DIE.
	/// </summary>
	public class DIE
	{
		ApplicationDataLayer.OracleDataLayer _OraDl;
		string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
		int wr_id=0;
		string DataCreate="";
		public DIE(int wr_id, string DataCreate)
		{
			this.wr_id=wr_id;
			this.DataCreate=DataCreate;
			_OraDl = new OracleDataLayer(s_ConnStr);
		}

		
		public string[] GenerateDIE()
		{
			DataTable DieTb=GetDataDIE();
			DataRow Riga=DieTb.Rows[0];
			string CodEdi=Riga["codedi"].ToString();
			string CodiceSGA=Riga["sga"].ToString();
			Stream stream = new MemoryStream();
			//creo l'oggetto xml
 
			XmlTextWriter writer=new XmlTextWriter(stream,null);
			//writer.Formatting = Formatting.Indented;
			writer.WriteStartElement("data");
			
//			writer.WriteElementString("CODICE",Riga["sga"].ToString().Trim());
			string SGA=Riga["codedi"].ToString()+"_"+System.DateTime.Parse(Riga["dataRichiesta"].ToString()).ToString("yy") + "_"+ FormatNumber(Riga["sga_count"].ToString());
			writer.WriteElementString("CODICE",SGA);
			writer.WriteElementString("SEDE",Riga["codedi"].ToString());
			writer.WriteElementString("PIANO",Riga["piano"].ToString().Replace("°","\\'b0"));
			writer.WriteElementString("DATA",Riga["date_requested"].ToString());
			writer.WriteElementString("NOMEEDIFICIO",Riga["edificio"].ToString());
			writer.WriteElementString("AMBIENTE",Riga["ambiente"].ToString());
		    writer.WriteElementString("SERVIZIO",Riga["servizio_id"].ToString());

			writer.WriteElementString("DESCPROB",Riga["descrizioneprob"].ToString());
			writer.WriteElementString("ID_SEG",Riga["id_sga_seguito"].ToString());
			
			switch(Riga["id_sga_seguito"].ToString())
			{
				case"3":
					writer.WriteElementString("ORDINEDEL",Riga["die_del"].ToString());
					writer.WriteElementString("ORDINENUM",Riga["die_numero"].ToString());
				break;
				case"4":
					writer.WriteElementString("MANDIFFDEL",Riga["die_del"].ToString());
					break;
				case"2":
					writer.WriteElementString("MANPROGDEL",Riga["die_del"].ToString());
					break;
			}
			
			
			writer.WriteElementString("DIETIPINT",Riga["die_tipo_intervento"].ToString());
			writer.WriteElementString("N_REG",Riga["die_registro"].ToString());
			writer.WriteElementString("MESE",GetMese(Riga["die_mese"].ToString()));
			writer.WriteElementString("GG_APERTURA",Riga["date_requested"].ToString());
			writer.WriteElementString("GG_INTMA",Riga["date_start"].ToString());
			writer.WriteElementString("GG_CHIUSURA",Riga["date_end"].ToString());
			writer.WriteElementString("NOMEDITTA",Riga["ditta"].ToString());
			writer.WriteElementString("TECNICOESECUTORE",Riga["addetto"].ToString());
			writer.WriteElementString("TELEFONO",Riga["telefono"].ToString());
			writer.WriteElementString("EMAIL",Riga["email"].ToString());
			writer.WriteElementString("VAL_ECONOMICA","");
			writer.WriteElementString("TIP_MAN",Riga["tipomanutenzione_id"].ToString());
			writer.WriteElementString("COSTO_MAT",Riga["TM"].ToString());
			writer.WriteElementString("COSTO_PERS",Riga["TA"].ToString());
			double tot=double.Parse(Riga["TM"].ToString()) + double.Parse(Riga["TA"].ToString());
			writer.WriteElementString("COSTO_TOT",tot.ToString());
			writer.WriteElementString("DICHIARA1",Riga["die_dichiara1"].ToString());
			writer.WriteElementString("DICHIARA2",Riga["die_dichiara2"].ToString());

			int[] CaratteriPerDichiara = new int[] {108,108};
//			string [] TmpRighe = DividiInRIghe(Riga["comments"].ToString(),CaratteriPerDichiara);
			string [] TmpRighe = DividiParole(Riga["comments"].ToString(),CaratteriPerDichiara);
			
			writer.WriteElementString("DICHIARA",TmpRighe[0]);
			writer.WriteElementString("DICHIARA_1",TmpRighe[1]);

			int[] CaratteriPerNote = new int[] {103,78};
			string [] TmpRighe1 = DividiParole(Riga["die_note"].ToString(),CaratteriPerNote);
			writer.WriteElementString("DICHIARA_NOTE1",TmpRighe1[0]);
			writer.WriteElementString("DICHIARA_NOTE2",TmpRighe1[1]);
			
			writer.WriteElementString("NOME_MA",Riga["nomimativo"].ToString());
			writer.WriteElementString("TEL_MA",Riga["tel"].ToString());
			writer.WriteElementString("FAX_MA",Riga["fax"].ToString());
			writer.WriteElementString("MOBILE_MA",Riga["mobile"].ToString());
			writer.WriteElementString("MAIL_MA",Riga["email_ma"].ToString());

			writer.WriteElementString("NOME_SM",Riga["sm_nome"].ToString());
			writer.WriteElementString("FIRMA_SM",Riga["sm_firma"].ToString());
			writer.WriteElementString("DATA_SM",Riga["sm_data"].ToString());
			writer.WriteElementString("NOME_FM",Riga["fm_nome"].ToString());
			writer.WriteElementString("FIRMA_FM",Riga["fm_firma"].ToString());
			writer.WriteElementString("DATA_FM",Riga["fm_data"].ToString());

			writer.WriteEndElement();

           
			writer.Flush();
			stream = writer.BaseStream;
			stream.Position=0;
		
			
			XPathDocument xmlDoc=new XPathDocument(stream);
			string XstName="";
			if(Riga["id_progetto"].ToString()=="2")//Vodafone
				XstName="XSLTDIEVod.xslt";
		    else
				XstName="XSLTDIE.xslt";
			//carico il file xslt
			string XsltFilePath=System.Web.HttpContext.Current.Server.MapPath(@"..\XSLT\" + XstName); 
			XslTransform xslt = new XslTransform();        
			xslt.Load(XsltFilePath);  
			XsltArgumentList args = new XsltArgumentList();

			string PathDIE=System.Web.HttpContext.Current.Server.MapPath(@"..\Doc_DB");  
			
			PathDIE=Path.Combine(PathDIE,Riga["codedi"].ToString());
			if (!Directory.Exists(PathDIE))
				Directory.CreateDirectory(PathDIE);

			PathDIE=Path.Combine(PathDIE,this.wr_id.ToString());
			if (!Directory.Exists(PathDIE))
				Directory.CreateDirectory(PathDIE);

			string FileName=PathDIE + @"\DIE " + CodEdi + " " + FormatNumber(Riga["sga_count"].ToString()) + "-" + System.DateTime.Parse(Riga["dataRichiesta"].ToString()).ToString("yy") +" " + DataCreate +".rtf";

			XmlTextWriter wr = new XmlTextWriter(FileName, null);
			xslt.Transform(xmlDoc, null, wr,null);
			wr.Flush();
			wr.Close();

			stream.Close();
			
			string FileNameDIELast=PathDIE + @"\DIE " + CodEdi + " " + FormatNumber(Riga["sga_count"].ToString()) + "-" +System.DateTime.Parse(Riga["dataRichiesta"].ToString()).ToString("yy") +".rtf";
			if (File.Exists(FileNameDIELast))
				File.Delete(FileNameDIELast);

			File.Copy(FileName,FileNameDIELast,true);

				
			string FileZip = Path.GetDirectoryName(FileNameDIELast) + @"\" + Path.GetFileNameWithoutExtension(FileNameDIELast) + ".zip";
		
			if (File.Exists(FileZip))
				File.Delete(FileZip);

			ZipOutputStream s = new ZipOutputStream(File.Create(FileZip)); 
			s.SetLevel(5); // 0 - store only to 9 - means best compression 
			FileStream fs = File.OpenRead(FileNameDIELast); 
			byte[] buffer = new byte[fs.Length]; 
			fs.Read(buffer, 0, buffer.Length); 
			ZipEntry entry = new ZipEntry(Path.GetFileName(FileNameDIELast)); 
			s.PutNextEntry(entry); 
			s.Write(buffer, 0, buffer.Length); 
			s.Finish(); 
			s.Close(); 


			string[] doc = new string[2] {FileZip, FileName};

		   return doc;
		}


		private DataTable GetDataDIE()
		{
			S_ControlsCollection _SColl = new S_ControlsCollection();
		
			S_Controls.Collections.S_Object p = new S_Object();
			p.ParameterName = "p_wr_id";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Value = this.wr_id;
			_SColl.Add(p);

			p = new S_Object();
			p.ParameterName = "IO_CURSOR";
			p.DbType = CustomDBType.Cursor;
			p.Direction = ParameterDirection.Output;
			p.Index = _SColl.Count;
			_SColl.Add(p);

			string s_StrSql = "PACK_MANCORRETIVA.SP_GETDATIDIE";
			 
			DataSet _Ds =  _OraDl.GetRows(_SColl, s_StrSql);
			return _Ds.Tables[0];
		}
		private string FormatNumber(string numero)
		{
			if (numero.Length==0) return "";
			if (numero.Length==1) return "000" + numero;
			if (numero.Length==2) return "00" + numero;
			if (numero.Length==3) return "0" + numero;
			if (numero.Length==4) return  numero;
			return "";
		}
		private string [] DividiParole(string Value, int [] CarattariPerRiga)
		{
			string[] Righe = new string[CarattariPerRiga.Length];
			int start=0;
			
			int i=0;
			while (i<CarattariPerRiga.Length)
			{

				
				int end=CarattariPerRiga[i];
				int tempEnd=Value.Length-1;
				if(tempEnd>end)
					end=CarattariPerRiga[i];
				else
					end=Value.Length;

				Righe[i]=Value.Substring(start,end);
				Value=Value.Substring(end);
				i++;
			}
			return Righe;
		}

		private string[]  DividiInRIghe(string RigaDaDividere, int[] CarattariPerRiga)
		{
				string[] Righe = new string[CarattariPerRiga.Length];
				//			string[] Parole = RigaDaDividere.Split(Convert.ToChar(" "));
				//			int cnt=0;
				//			foreach (string Parola in Parole)
				//			{
				//				if(Parola.Length <= CarattariPerRiga[]
				//			}
				//			
				//			return Righe;
				int IndiceRiga=0;
				int Lugehezza=0;
				int i=0;
				int sup=0;
				int inf =0;
				int j=0;
				if(RigaDaDividere != String.Empty)
				{
					for (int cntRiga=0; cntRiga<Righe.Length; cntRiga++)
					{
						sup += CarattariPerRiga[cntRiga];
						while(IndiceRiga<sup)
						{
							if(IndiceRiga != -1)
							{
								IndiceRiga = RigaDaDividere.IndexOf(" ",i);
								i++;
							}
							else
							{
								IndiceRiga= RigaDaDividere.Length;
								break;
							}
						}
						Lugehezza = IndiceRiga-j;
						Righe[cntRiga]= RigaDaDividere.Substring(j,Lugehezza);
						j=IndiceRiga;
						inf += CarattariPerRiga[cntRiga];
					}
				}
				else
				{
					for (int k =0; k<Righe.Length; k++)
					{
						Righe[k]=string.Empty;
					}
				}
				return Righe;
			}


	

		private string GetMese(string mese)
		{
			if(mese=="1") return "GENNAIO";
			if(mese=="2") return "FEBBRAIO";
			if(mese=="3") return "MARZO";
			if(mese=="4") return "APRILE";
			if(mese=="5") return "MAGGIO";
			if(mese=="6") return "GIUGNO";
			if(mese=="7") return "LUGLIO";
			if(mese=="8") return "AGOSTO";
			if(mese=="9") return "SETTEMBRE";
			if(mese=="10") return "OTTOBRE";
			if(mese=="11") return "NOVEMBRE";
			if(mese=="12") return "DICEMBRE";
			return "";
		}
	}
}
