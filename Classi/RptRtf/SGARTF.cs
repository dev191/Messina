using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Data;
using System.Data.OracleClient;
using ICSharpCode;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;

namespace TheSite.Classi.RptRtf
{
	/// <summary>
	/// Esegue la trasformazione di un documento Rtf usando le proprieta della classe come impot dei dati.
	/// </summary>
	public class SGARTF
	{
		// campi per i check
		private	string TagImpiantiElettrici,Tagantincendio,Tagclimatizzazione,Tagfrigoriferi,Tagidricosanitari,TagConduzione,TagManProg, TagOdl,TagNonDifferibile;
		private	string TagRichiestaSopralluogo,TagManConduzione,TagManMiglior,TagCompCanSi,TagCompCanNo,TagBoCompMisura,TagBoCompForfait;
		// campi per i testi
		private string TagNumeroSga,TagContratto,TagImpresa,TagBlSede,TagDataRtf,TagBlCampus,TagPianoDec,TagAmbienteBl,TagDataIn,TagOraIn;
		private string TagNdie,TagDataDelDifferibile,TagNum,TagDataDelSopralluogo,TagDataEffetSopralluogo,TagDaLav,TagDescGuastoAnomaliaR1;
		private string TagDescGuastoAnomaliaR2,TagCausaPresGuastAnR1,TagCausaPresGuastAnR2,TagPrestazImpStrR1,TagPrestazImpStrR2;
		private string TagSolPropR1,TagSolPropR2,TagDataPrevInLav,TagDurPrevLav,TagCompMisura,TagIvaMisura,TagCompForfait,TagIvaForfait;
		private string TagModPagamento,TagNomeFileAllegatiR1,TagNomeFileAllegatiR2,TagNoteProgettoR1,TagNoteProgettoR2,TagNomeResp;
		private string TagTelefonoResp,TagFaxResp, TagMobileResp,TagMailResp,TagFirmaResp,TagNomeVisSm,TagFirmaVisSm;
		private string TagDataVisSm,TagNomeVisFm,TagFirmVIsFm,TagDataVisFm,_FileXlst,TagIdProgetto,Tagservizio;

		public SGARTF()
		{
		}
		#region Proprieta Pubblica
		// Proprieta' legate ai check
		public bool antincendio
		{
			set
			{
				if(value)
				{
					Tagantincendio="1";
				}
				else
				{
					Tagantincendio="0";
				}
			}
		}
		public bool ImpiantiElettrici
		{
			set
			{
				if(value)
				{
					TagImpiantiElettrici="1";
				}
				else
				{
					TagImpiantiElettrici="0";
				}
			}
		}
		public bool climatizzazione
		{
			set
			{
				if(value)
				{
					Tagclimatizzazione="1";
				}
				else
				{
					Tagclimatizzazione="0";
				}
			}
		}
		public bool frigoriferi
		{
			set
			{
				if(value)
				{
					Tagfrigoriferi="1";
				}
				else
				{
					Tagfrigoriferi="0";
				}
			}
		}
		public bool idricosanitari
		{
			
			set
			{
				if(value)
				{
					Tagidricosanitari="1";
				}
				else
				{
					Tagidricosanitari="0";
				}
			}
		}
		public bool Conduzione
		{
			set
			{
				if(value)
				{
					TagConduzione="1";
				}
				else
				{
					TagConduzione="0";
				}
			}
		}
		public string servizio
		{
			set
			{
				Tagservizio=value;
			}
		}
		
		public bool ManProg
		{
			set
			{
				if(value)
				{
					TagManProg="1";
				}
				else
				{
					TagManProg="0";
				}
			}
		}
		public bool Odl
		{
			
			set
			{
				if(value)
				{
					TagOdl="1";
				}
				else
				{
					TagOdl="0";
				}
			}
		}
		public bool NonDifferibile
		{
			set
			{
				if(value)
				{
					TagNonDifferibile="1";
				}
				else
				{
					TagNonDifferibile="0";
				}
			}
		}

		public bool RichiestaSopralluogo
		{			
			set
			{
				if(value)
				{
					TagRichiestaSopralluogo="1";
				}
				else
				{
					TagRichiestaSopralluogo="0";
				}
			}
		}
		public bool ManConduzione
		{
			set
			{
				if(value)
				{
					TagManConduzione="1";
				}
				else
				{
					TagManConduzione="0";
				}
			}
		}
		public bool ManMiglior
		{	
			set
			{
				if(value)
				{
					TagManMiglior="1";
				}
				else
				{
					TagManMiglior="0";
				}
			}
		}
		public bool CompCanSi
		{	
			set
			{
				if(value)
				{
					TagCompCanSi="1";
				}
				else
				{
					TagCompCanSi="0";
				}
			}
		}
		public bool CompCanNo
		{
			set
			{
				if(value)
				{
					TagCompCanNo="1";
				}
				else
				{
					TagCompCanNo="0";
				}
			}
		}
		public bool BoCompMisura
		{
			set
			{
				if(value)
				{
					TagBoCompMisura="1";
				}
				else
				{
					TagBoCompMisura="0";
				}
			}

		}

		public bool BoCompForfait
		{
			set
			{
				if(value)
				{
					TagBoCompForfait="1";
				}
				else
				{
					TagBoCompForfait="0";
				}
			}
		}							

		// proprieta legate ai controlli testo e testo libero
		public string NumeroSga
		{
			set{TagNumeroSga=value;}
		}
		public string Contratto
		{
			set{TagContratto=value;}
		}
		public string Impresa
		{
			set{TagImpresa=value;}
		}
		public string BlSede
		{
			set{TagBlSede =value;}
		}
		public string  DataRtf
		{
			set{TagDataRtf =value;}
		}
		public string BlCampus
		{
			set{TagBlCampus =value;}
		}
		public string PianoDec
		{
			set{TagPianoDec =value;}
		}
		public string AmbienteBl
		{
			set{TagAmbienteBl =value;}
		}
		public string DataIn
		{
			set{TagDataIn =value;}
		}
		public string OraIn
		{
			set{TagOraIn =value;}
		}
		public string Ndie
		{
			set{TagNdie =value;}
		}
		public string DataDelDifferibile
		{
			set{TagDataDelDifferibile =value;}
		}
		public string Num
		{
			set{TagNum =value;}
		}
		public string DataDelSopralluogo
		{
			set{TagDataDelSopralluogo =value;}
		}
		public string DataEffetSopralluogo
		{
			set{TagDataEffetSopralluogo =value;}
		}
		public string DaLav
		{
			set{TagDaLav =value;}
		}
		public string DescGuastoAnomaliaR1
		{
			set{TagDescGuastoAnomaliaR1 =value;}
		}
		public string DescGuastoAnomaliaR2
		{
			set{TagDescGuastoAnomaliaR2 =value;}
		}
		public string CausaPresGuastAnR1
		{
			set{TagCausaPresGuastAnR1 =value;}
		}
		public string CausaPresGuastAnR2
		{
			set{ TagCausaPresGuastAnR2=value;}
		}
		public string PrestazImpStrR1
		{
			set{TagPrestazImpStrR1 =value;}
		}
		public string PrestazImpStrR2
		{
			set{TagPrestazImpStrR2 =value;}
		}
		public string SolPropR1
		{
			set{TagSolPropR1 =value;}
		}
		public string SolPropR2
		{
			set{TagSolPropR2 =value;}
		}
		public string DataPrevInLav
		{
			set{TagDataPrevInLav =value;}
		} 
		public string DurPrevLav
		{
			set{TagDurPrevLav =value;}
		}
		public string  CompMisura
		{
			set{TagCompMisura =value;}
		}
		public string IvaMisura
		{
			set{TagIvaMisura =value;}
		}
		public string CompForfait
		{
			set{TagCompForfait =value;}
		}
		public string IvaForfait
		{
			set{TagIvaForfait =value;}
		}
		public string ModPagamento
		{
			set{TagModPagamento =value;}
		}
		public string NomeFileAllegatiR1
		{
			set{TagNomeFileAllegatiR1 =value;}
		}
		public string NomeFileAllegatiR2
		{
			set{ TagNomeFileAllegatiR2 =value;}
		}
		public string  NoteProgettoR1
		{
			set{TagNoteProgettoR1 =value;}
		}
		public string NoteProgettoR2
		{
			set{TagNoteProgettoR2 =value;}
		}
		public string NomeResp
		{
			set{TagNomeResp =value;}
		}
		public string TelefonoResp
		{
			set{TagTelefonoResp =value;}
		}
		public string FaxResp
		{
			set{TagFaxResp =value;}
		}
		public string MobileResp
		{
			set{TagMobileResp =value;}
		}
		public string MailResp
		{
			set{TagMailResp =value;}
		}
		public string FirmaResp
		{
			set{TagFirmaResp =value;}
		}
		public string NomeVisSm
		{
			set{TagNomeVisSm =value;}
		}
		public string FirmaVisSm
		{
			set{TagFirmaVisSm =value;}
		}
		public string DataVisSm
		{
			set{TagDataVisSm =value;}
		}
		public string NomeVisFm
		{
			set{TagNomeVisFm =value;}
		}
		public string FirmVIsFm
		{
			set{TagFirmVIsFm =value;}
		}
		public string DataVisFm
		{
			set{TagDataVisFm =value;}
		}
		public string FileXlst
		{
			set{_FileXlst =value;}
		} 
		public string IdProgetto
		{
			set{TagIdProgetto=value;}
			get{return TagIdProgetto;}
		}
		# endregion
		string DataCreate="";
		int WrId=0;
		public string[]  GeneraRtf(int WrId, string DataCreate)
		{
			this.WrId=WrId;
			this.DataCreate=DataCreate;

			DatiRtf DRtf= new DatiRtf();
			DataTable dt = DRtf.GetDatiRtfSgaRtf(this.WrId);
			//DataView dv = dt.;
			this.NumeroSga = Convert.ToString(dt.Rows[0]["NumeroSga"]);
			if(dt.Rows[0]["id_progetto"].ToString()=="1")
			{
				this.Contratto = "";
				this.Impresa = "Cofely Italia s.p.a - Servizi Energia Calore Srl";
			}
			else
			{
				this.Contratto = "";
				this.Impresa = "Cofely Italia s.p.a - Servizi Energia Calore Srl";
			}
			
			this.BlSede = Convert.ToString(dt.Rows[0]["BlSede"]);
			this.DataRtf = Convert.ToString(dt.Rows[0]["DataRtf"]);
			this.BlCampus = Convert.ToString(dt.Rows[0]["BlCampus"]);
			this.PianoDec = Convert.ToString(dt.Rows[0]["PianoDec"]).Replace("°","\\'b0");
			this.AmbienteBl =Convert.ToString(dt.Rows[0]["AmbienteBl"]);
			//servizi
//			this.ImpiantiElettrici = (Convert.ToInt32(dt.Rows[0]["ImpiantiElettrici"])==1) ? true:false;
//			this.antincendio = (Convert.ToInt32(dt.Rows[0]["antincendio"])==1) ? true:false;
//			this.climatizzazione = (Convert.ToInt32(dt.Rows[0]["climatizzazione"])==1) ? true:false;
//			this.frigoriferi= (Convert.ToInt32(dt.Rows[0]["frigoriferi"])==1) ? true:false;
//			this.idricosanitari = (Convert.ToInt32(dt.Rows[0]["idricosanitari"])==1) ? true:false;
//			this.Conduzione = (Convert.ToInt32(dt.Rows[0]["Conduzione"])==1) ? true:false;
			
			this.servizio=dt.Rows[0]["servizio_id"].ToString();
			this.DataIn = Convert.ToString(dt.Rows[0]["DataIn"]);
			this.OraIn = Convert.ToString(dt.Rows[0]["OraIn"]);
			this.ManProg= (Convert.ToInt32(dt.Rows[0]["ManProg"])==1) ? true:false;
			this.Odl = (Convert.ToInt32(dt.Rows[0]["Odl"])==1) ? true:false;
			this.NonDifferibile = (Convert.ToInt32(dt.Rows[0]["NonDifferibile"])==1) ? true:false;
			this.Ndie = Convert.ToString(dt.Rows[0]["Ndie"]);
			this.DataDelDifferibile = Convert.ToString(dt.Rows[0]["DataDelDifferibile"]);
			this.RichiestaSopralluogo = (Convert.ToInt32(dt.Rows[0]["RichiestaSopralluogo"])==1) ? true:false;
			this.Num = Convert.ToString(dt.Rows[0]["Num"]);
			this.DataDelSopralluogo = Convert.ToString(dt.Rows[0]["DataDelSopralluogo"]);
			this.DataEffetSopralluogo = Convert.ToString(dt.Rows[0]["DataEffetSopralluogo"]);
			this.DaLav = Convert.ToString(dt.Rows[0]["DaLav"]);
			this.ManConduzione = (Convert.ToInt32(dt.Rows[0]["ManConduzione"])==1) ? true:false;
			this.ManMiglior = (Convert.ToInt32(dt.Rows[0]["ManMiglior"])==1) ? true:false;
			int[] CaratteriPerRiga = new int[] {117,117};
			string [] TmpRighe = DividiParole(Convert.ToString(dt.Rows[0]["DescGuastoAnomalia"]),CaratteriPerRiga);
			this.DescGuastoAnomaliaR1= TmpRighe[0];
			this.DescGuastoAnomaliaR2=TmpRighe[1];
			TmpRighe = DividiParole(Convert.ToString(dt.Rows[0]["CausaPresGuastAn"]),CaratteriPerRiga);
			this.CausaPresGuastAnR1 = TmpRighe[0];
			this.CausaPresGuastAnR2 = TmpRighe[1];
			TmpRighe =  DividiParole(Convert.ToString(dt.Rows[0]["PrestazImpStr"]),CaratteriPerRiga);
			this.PrestazImpStrR1 =TmpRighe[0];
			this.PrestazImpStrR2 = TmpRighe[1];
			TmpRighe = DividiParole(Convert.ToString(dt.Rows[0]["SolProp"]),CaratteriPerRiga);
			this.SolPropR1 = TmpRighe[0];
			this.SolPropR2 = TmpRighe[1];
			this.DataPrevInLav = Convert.ToString(dt.Rows[0]["DataPrevInLav"]);
			this.DurPrevLav = Convert.ToString(dt.Rows[0]["DurPrevLav"]) + " gg";
			this.CompCanSi = (Convert.ToInt32(dt.Rows[0]["CompCanSi"])==1) ? true:false;
			this.CompCanNo = (Convert.ToInt32(dt.Rows[0]["CompCanNo"])==1) ? true:false;
			this.BoCompMisura = (Convert.ToInt32(dt.Rows[0]["BoCompMisura"])==1) ? true:false;
			this.CompMisura = Convert.ToString(dt.Rows[0]["CompMisura"]);
			this.IvaMisura = Convert.ToString(dt.Rows[0]["IvaMisura"]);
			this.BoCompForfait = (Convert.ToInt32(dt.Rows[0]["BoCompForfait"])==1) ? true:false;
			this.CompForfait = Convert.ToString(dt.Rows[0]["CompForfait"]);
			this.IvaForfait = Convert.ToString(dt.Rows[0]["CompForfait"]);
			this.ModPagamento = Convert.ToString(dt.Rows[0]["ModPagamento"]);
			// Allegati
			TmpRighe = DividiParole(Convert.ToString(dt.Rows[0]["NomeFileAllegati"]),CaratteriPerRiga);
			this.NomeFileAllegatiR1 = TmpRighe[0];
			this.NomeFileAllegatiR2 = TmpRighe[1];
			TmpRighe = DividiParole(Convert.ToString(dt.Rows[0]["NoteProgetto"]),CaratteriPerRiga);
			this.NoteProgettoR1 = TmpRighe[0];
			this.NoteProgettoR2 = TmpRighe[1];
			this.NomeResp =  Convert.ToString(dt.Rows[0]["NomeResp"]);
			this.TelefonoResp = Convert.ToString(dt.Rows[0]["TelefonoResp"]);
			this.FaxResp = Convert.ToString(dt.Rows[0]["FaxResp"]);
			this.MobileResp = Convert.ToString(dt.Rows[0]["MobileResp"]);
			this.MailResp = Convert.ToString(dt.Rows[0]["MailResp"]);
			this.NomeVisSm = Convert.ToString(dt.Rows[0]["NomeVisSm"]);
			this.DataVisSm = Convert.ToString(dt.Rows[0]["DataVisSm"]);
			this.NomeVisFm = Convert.ToString(dt.Rows[0]["NomeVisFm"]);
			this.DataVisFm = Convert.ToString(dt.Rows[0]["DataVisFm"]);

			return ProcessaTutto(dt.Rows[0]["sga_count"].ToString());

		}

		private string[]  ProcessaTutto(string sga_count)
		{
		   
			string PathSGA=System.Web.HttpContext.Current.Server.MapPath(@"..\Doc_DB");  
			PathSGA=Path.Combine(PathSGA,TagBlSede);
			
			if (!Directory.Exists(PathSGA))
				Directory.CreateDirectory(PathSGA);

			PathSGA=Path.Combine(PathSGA,this.WrId.ToString());

			if (!Directory.Exists(PathSGA))
				Directory.CreateDirectory(PathSGA);

			string FileName=PathSGA + @"\SGA " + TagBlSede + " " + FormatNumber(sga_count) + "-" + System.DateTime.Parse(TagDataRtf).ToString("yy") +" " + DataCreate +".rtf";

			if (File.Exists(FileName)) 
				File.Delete(FileName);		

			using (StreamWriter sw = File.CreateText(FileName))
			{
				sw.Write(EseguiTrasformazione(_FileXlst));
				sw.Close();
			}


			string FileNameDIELast=PathSGA + @"\SGA " + this.TagBlSede + " " + FormatNumber(sga_count) + "-" + System.DateTime.Parse(TagDataRtf).ToString("yy") +".rtf";
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
			fs.Close();
			string[] doc = new string[2] {FileZip, FileName};

			return doc;
		}
		public string EseguiTrasformazione(string PathTrs)
		{

			
			MemoryStream stream=new MemoryStream();
			//creo l'oggetto xml
 
			XmlTextWriter writer=new XmlTextWriter(stream,Encoding.Unicode);
			writer.WriteStartElement("data");
			//scrive i tag xml che andranno  ad impostare le check del foglio rtf
			writer.WriteElementString("climatizzazione",Tagclimatizzazione);
			writer.WriteElementString("frigoriferi",Tagfrigoriferi);
			writer.WriteElementString("idricosanitari",Tagidricosanitari);
			writer.WriteElementString("ImpiantiElettrici",TagImpiantiElettrici);			
			writer.WriteElementString("antincendio",Tagantincendio);
			writer.WriteElementString("Conduzione",TagConduzione);
			writer.WriteElementString("ManProg",TagManProg);
			writer.WriteElementString("Odl",TagOdl);
			writer.WriteElementString("NonDifferibile",TagNonDifferibile);
			writer.WriteElementString("RichiestaSopralluogo",TagRichiestaSopralluogo);
			writer.WriteElementString("ManConduzione",TagManConduzione);
			writer.WriteElementString("ManMiglior",TagManMiglior);
			writer.WriteElementString("CompCanSi",TagCompCanSi);
			writer.WriteElementString("CompCanNo",TagCompCanNo);
			writer.WriteElementString("BoCompMisura",TagBoCompMisura);
			writer.WriteElementString("BoCompForfait",TagBoCompForfait);
			
			writer.WriteElementString("SERVIZIO",Tagservizio);
			
			//scrive i tag xml che andranno  ad impostare i testi del foglio rtf
			writer.WriteElementString("NumeroSga",TagNumeroSga);
			writer.WriteElementString("Contratto",TagContratto);
			writer.WriteElementString("Impresa",TagImpresa);
			writer.WriteElementString("BlSede",TagBlSede);
			writer.WriteElementString("DataRtf",TagDataRtf);
			writer.WriteElementString("BlCampus",TagBlCampus);
			writer.WriteElementString("PianoDec",TagPianoDec);
			writer.WriteElementString("AmbienteBl",TagAmbienteBl);
			writer.WriteElementString("DataIn",TagDataIn);
			writer.WriteElementString("OraIn",TagOraIn);
			writer.WriteElementString("Ndie",TagNdie);
			writer.WriteElementString("DataDelDifferibile",TagDataDelDifferibile);
			writer.WriteElementString("Num",TagNum);
			writer.WriteElementString("DataDelSopralluogo",TagDataDelSopralluogo);
			writer.WriteElementString("DataEffetSopralluogo",TagDataEffetSopralluogo);
			writer.WriteElementString("DaLav",TagDaLav);
			writer.WriteElementString("DescGuastoAnomaliaR1",TagDescGuastoAnomaliaR1);
			writer.WriteElementString("DescGuastoAnomaliaR2",TagDescGuastoAnomaliaR2);
			writer.WriteElementString("CausaPresGuastAnR1",TagCausaPresGuastAnR1);
			writer.WriteElementString("CausaPresGuastAnR2",TagCausaPresGuastAnR2);					
			writer.WriteElementString("PrestazImpStrR1",TagPrestazImpStrR1);
			writer.WriteElementString("PrestazImpStrR2",TagPrestazImpStrR2);
			writer.WriteElementString("SolPropR1",TagSolPropR1);
			writer.WriteElementString("SolPropR2",TagSolPropR2);
			writer.WriteElementString("DataPrevInLav",TagDataPrevInLav);
			writer.WriteElementString("DurPrevLav",TagDurPrevLav);
			writer.WriteElementString("CompMisura",TagCompMisura);
			writer.WriteElementString("IvaMisura",TagIvaMisura);
			writer.WriteElementString("CompForfait",TagCompForfait);
			writer.WriteElementString("IvaForfait",TagIvaForfait);
			writer.WriteElementString("ModPagamento",TagModPagamento);
			writer.WriteElementString("NomeFileAllegatiR1",TagNomeFileAllegatiR1);
			writer.WriteElementString("NomeFileAllegatiR2",TagNomeFileAllegatiR2);
			writer.WriteElementString("NoteProgettoR1",TagNoteProgettoR1);
			writer.WriteElementString("NoteProgettoR2",TagNoteProgettoR2);
			writer.WriteElementString("NomeResp",TagNomeResp);
			writer.WriteElementString("TelefonoResp",TagTelefonoResp);
			writer.WriteElementString("FaxResp",TagFaxResp);
			writer.WriteElementString("MobileResp",TagMobileResp);
			writer.WriteElementString("MailResp",TagMailResp);
			writer.WriteElementString("FirmaResp",TagFirmaResp);
			writer.WriteElementString("NomeVisSm",TagNomeVisSm);
			writer.WriteElementString("FirmaVisSm",TagFirmaVisSm);
			writer.WriteElementString("DataVisSm",TagDataVisSm);
			writer.WriteElementString("NomeVisFm",TagNomeVisFm);
			writer.WriteElementString("FirmVIsFm",TagFirmVIsFm);
			writer.WriteElementString("DataVisFm",TagDataVisFm);
												
	
			//writer.WriteElementString("surname",txtSurname.Value);
			writer.WriteEndElement();
			writer.Flush();

			stream.Position=0;
			//carico l'xmldocument
			
			XPathDocument xmlDoc=new XPathDocument(stream);
			//la stringa che conterrà il body

			StringBuilder docRdf=new StringBuilder();
			//carico il file xslt

			XslTransform xmlEngine=new XslTransform();
			xmlEngine.Load(PathTrs);
			//effettuo la trasformazione

			xmlEngine.Transform(xmlDoc,null,new StringWriter(docRdf),null);
			return docRdf.ToString().Trim();
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
		private string FormatNumber(string numero)
		{
			if (numero.Length==0) return "";
			if (numero.Length==1) return "000" + numero;
			if (numero.Length==2) return "00" + numero;
			if (numero.Length==3) return "0" + numero;
			if (numero.Length==4) return  numero;
			return "";
		}
	}
}

