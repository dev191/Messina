// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.RptRtf.SGARTF
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace TheSite.Classi.RptRtf
{
  public class SGARTF
  {
    private string TagImpiantiElettrici;
    private string Tagantincendio;
    private string Tagclimatizzazione;
    private string Tagfrigoriferi;
    private string Tagidricosanitari;
    private string TagConduzione;
    private string TagManProg;
    private string TagOdl;
    private string TagNonDifferibile;
    private string TagRichiestaSopralluogo;
    private string TagManConduzione;
    private string TagManMiglior;
    private string TagCompCanSi;
    private string TagCompCanNo;
    private string TagBoCompMisura;
    private string TagBoCompForfait;
    private string TagNumeroSga;
    private string TagContratto;
    private string TagImpresa;
    private string TagBlSede;
    private string TagDataRtf;
    private string TagBlCampus;
    private string TagPianoDec;
    private string TagAmbienteBl;
    private string TagDataIn;
    private string TagOraIn;
    private string TagNdie;
    private string TagDataDelDifferibile;
    private string TagNum;
    private string TagDataDelSopralluogo;
    private string TagDataEffetSopralluogo;
    private string TagDaLav;
    private string TagDescGuastoAnomaliaR1;
    private string TagDescGuastoAnomaliaR2;
    private string TagCausaPresGuastAnR1;
    private string TagCausaPresGuastAnR2;
    private string TagPrestazImpStrR1;
    private string TagPrestazImpStrR2;
    private string TagSolPropR1;
    private string TagSolPropR2;
    private string TagDataPrevInLav;
    private string TagDurPrevLav;
    private string TagCompMisura;
    private string TagIvaMisura;
    private string TagCompForfait;
    private string TagIvaForfait;
    private string TagModPagamento;
    private string TagNomeFileAllegatiR1;
    private string TagNomeFileAllegatiR2;
    private string TagNoteProgettoR1;
    private string TagNoteProgettoR2;
    private string TagNomeResp;
    private string TagTelefonoResp;
    private string TagFaxResp;
    private string TagMobileResp;
    private string TagMailResp;
    private string TagFirmaResp;
    private string TagNomeVisSm;
    private string TagFirmaVisSm;
    private string TagDataVisSm;
    private string TagNomeVisFm;
    private string TagFirmVIsFm;
    private string TagDataVisFm;
    private string _FileXlst;
    private string TagIdProgetto;
    private string Tagservizio;
    private string DataCreate = "";
    private int WrId = 0;

    public bool antincendio
    {
      set
      {
        if (value)
          this.Tagantincendio = "1";
        else
          this.Tagantincendio = "0";
      }
    }

    public bool ImpiantiElettrici
    {
      set
      {
        if (value)
          this.TagImpiantiElettrici = "1";
        else
          this.TagImpiantiElettrici = "0";
      }
    }

    public bool climatizzazione
    {
      set
      {
        if (value)
          this.Tagclimatizzazione = "1";
        else
          this.Tagclimatizzazione = "0";
      }
    }

    public bool frigoriferi
    {
      set
      {
        if (value)
          this.Tagfrigoriferi = "1";
        else
          this.Tagfrigoriferi = "0";
      }
    }

    public bool idricosanitari
    {
      set
      {
        if (value)
          this.Tagidricosanitari = "1";
        else
          this.Tagidricosanitari = "0";
      }
    }

    public bool Conduzione
    {
      set
      {
        if (value)
          this.TagConduzione = "1";
        else
          this.TagConduzione = "0";
      }
    }

    public string servizio
    {
      set => this.Tagservizio = value;
    }

    public bool ManProg
    {
      set
      {
        if (value)
          this.TagManProg = "1";
        else
          this.TagManProg = "0";
      }
    }

    public bool Odl
    {
      set
      {
        if (value)
          this.TagOdl = "1";
        else
          this.TagOdl = "0";
      }
    }

    public bool NonDifferibile
    {
      set
      {
        if (value)
          this.TagNonDifferibile = "1";
        else
          this.TagNonDifferibile = "0";
      }
    }

    public bool RichiestaSopralluogo
    {
      set
      {
        if (value)
          this.TagRichiestaSopralluogo = "1";
        else
          this.TagRichiestaSopralluogo = "0";
      }
    }

    public bool ManConduzione
    {
      set
      {
        if (value)
          this.TagManConduzione = "1";
        else
          this.TagManConduzione = "0";
      }
    }

    public bool ManMiglior
    {
      set
      {
        if (value)
          this.TagManMiglior = "1";
        else
          this.TagManMiglior = "0";
      }
    }

    public bool CompCanSi
    {
      set
      {
        if (value)
          this.TagCompCanSi = "1";
        else
          this.TagCompCanSi = "0";
      }
    }

    public bool CompCanNo
    {
      set
      {
        if (value)
          this.TagCompCanNo = "1";
        else
          this.TagCompCanNo = "0";
      }
    }

    public bool BoCompMisura
    {
      set
      {
        if (value)
          this.TagBoCompMisura = "1";
        else
          this.TagBoCompMisura = "0";
      }
    }

    public bool BoCompForfait
    {
      set
      {
        if (value)
          this.TagBoCompForfait = "1";
        else
          this.TagBoCompForfait = "0";
      }
    }

    public string NumeroSga
    {
      set => this.TagNumeroSga = value;
    }

    public string Contratto
    {
      set => this.TagContratto = value;
    }

    public string Impresa
    {
      set => this.TagImpresa = value;
    }

    public string BlSede
    {
      set => this.TagBlSede = value;
    }

    public string DataRtf
    {
      set => this.TagDataRtf = value;
    }

    public string BlCampus
    {
      set => this.TagBlCampus = value;
    }

    public string PianoDec
    {
      set => this.TagPianoDec = value;
    }

    public string AmbienteBl
    {
      set => this.TagAmbienteBl = value;
    }

    public string DataIn
    {
      set => this.TagDataIn = value;
    }

    public string OraIn
    {
      set => this.TagOraIn = value;
    }

    public string Ndie
    {
      set => this.TagNdie = value;
    }

    public string DataDelDifferibile
    {
      set => this.TagDataDelDifferibile = value;
    }

    public string Num
    {
      set => this.TagNum = value;
    }

    public string DataDelSopralluogo
    {
      set => this.TagDataDelSopralluogo = value;
    }

    public string DataEffetSopralluogo
    {
      set => this.TagDataEffetSopralluogo = value;
    }

    public string DaLav
    {
      set => this.TagDaLav = value;
    }

    public string DescGuastoAnomaliaR1
    {
      set => this.TagDescGuastoAnomaliaR1 = value;
    }

    public string DescGuastoAnomaliaR2
    {
      set => this.TagDescGuastoAnomaliaR2 = value;
    }

    public string CausaPresGuastAnR1
    {
      set => this.TagCausaPresGuastAnR1 = value;
    }

    public string CausaPresGuastAnR2
    {
      set => this.TagCausaPresGuastAnR2 = value;
    }

    public string PrestazImpStrR1
    {
      set => this.TagPrestazImpStrR1 = value;
    }

    public string PrestazImpStrR2
    {
      set => this.TagPrestazImpStrR2 = value;
    }

    public string SolPropR1
    {
      set => this.TagSolPropR1 = value;
    }

    public string SolPropR2
    {
      set => this.TagSolPropR2 = value;
    }

    public string DataPrevInLav
    {
      set => this.TagDataPrevInLav = value;
    }

    public string DurPrevLav
    {
      set => this.TagDurPrevLav = value;
    }

    public string CompMisura
    {
      set => this.TagCompMisura = value;
    }

    public string IvaMisura
    {
      set => this.TagIvaMisura = value;
    }

    public string CompForfait
    {
      set => this.TagCompForfait = value;
    }

    public string IvaForfait
    {
      set => this.TagIvaForfait = value;
    }

    public string ModPagamento
    {
      set => this.TagModPagamento = value;
    }

    public string NomeFileAllegatiR1
    {
      set => this.TagNomeFileAllegatiR1 = value;
    }

    public string NomeFileAllegatiR2
    {
      set => this.TagNomeFileAllegatiR2 = value;
    }

    public string NoteProgettoR1
    {
      set => this.TagNoteProgettoR1 = value;
    }

    public string NoteProgettoR2
    {
      set => this.TagNoteProgettoR2 = value;
    }

    public string NomeResp
    {
      set => this.TagNomeResp = value;
    }

    public string TelefonoResp
    {
      set => this.TagTelefonoResp = value;
    }

    public string FaxResp
    {
      set => this.TagFaxResp = value;
    }

    public string MobileResp
    {
      set => this.TagMobileResp = value;
    }

    public string MailResp
    {
      set => this.TagMailResp = value;
    }

    public string FirmaResp
    {
      set => this.TagFirmaResp = value;
    }

    public string NomeVisSm
    {
      set => this.TagNomeVisSm = value;
    }

    public string FirmaVisSm
    {
      set => this.TagFirmaVisSm = value;
    }

    public string DataVisSm
    {
      set => this.TagDataVisSm = value;
    }

    public string NomeVisFm
    {
      set => this.TagNomeVisFm = value;
    }

    public string FirmVIsFm
    {
      set => this.TagFirmVIsFm = value;
    }

    public string DataVisFm
    {
      set => this.TagDataVisFm = value;
    }

    public string FileXlst
    {
      set => this._FileXlst = value;
    }

    public string IdProgetto
    {
      set => this.TagIdProgetto = value;
      get => this.TagIdProgetto;
    }

    public string[] GeneraRtf(int WrId, string DataCreate)
    {
      this.WrId = WrId;
      this.DataCreate = DataCreate;
      DataTable datiRtfSgaRtf = new DatiRtf().GetDatiRtfSgaRtf(this.WrId);
      this.NumeroSga = Convert.ToString(datiRtfSgaRtf.Rows[0]["NumeroSga"]);
      if (datiRtfSgaRtf.Rows[0]["id_progetto"].ToString() == "1")
      {
        this.Contratto = "";
        this.Impresa = "Cofely Italia s.p.a - Servizi Energia Calore Srl";
      }
      else
      {
        this.Contratto = "";
        this.Impresa = "Cofely Italia s.p.a - Servizi Energia Calore Srl";
      }
      this.BlSede = Convert.ToString(datiRtfSgaRtf.Rows[0]["BlSede"]);
      this.DataRtf = Convert.ToString(datiRtfSgaRtf.Rows[0]["DataRtf"]);
      this.BlCampus = Convert.ToString(datiRtfSgaRtf.Rows[0]["BlCampus"]);
      this.PianoDec = Convert.ToString(datiRtfSgaRtf.Rows[0]["PianoDec"]).Replace("°", "\\'b0");
      this.AmbienteBl = Convert.ToString(datiRtfSgaRtf.Rows[0]["AmbienteBl"]);
      this.servizio = datiRtfSgaRtf.Rows[0]["servizio_id"].ToString();
      this.DataIn = Convert.ToString(datiRtfSgaRtf.Rows[0]["DataIn"]);
      this.OraIn = Convert.ToString(datiRtfSgaRtf.Rows[0]["OraIn"]);
      this.ManProg = Convert.ToInt32(datiRtfSgaRtf.Rows[0]["ManProg"]) == 1;
      this.Odl = Convert.ToInt32(datiRtfSgaRtf.Rows[0]["Odl"]) == 1;
      this.NonDifferibile = Convert.ToInt32(datiRtfSgaRtf.Rows[0]["NonDifferibile"]) == 1;
      this.Ndie = Convert.ToString(datiRtfSgaRtf.Rows[0]["Ndie"]);
      this.DataDelDifferibile = Convert.ToString(datiRtfSgaRtf.Rows[0]["DataDelDifferibile"]);
      this.RichiestaSopralluogo = Convert.ToInt32(datiRtfSgaRtf.Rows[0]["RichiestaSopralluogo"]) == 1;
      this.Num = Convert.ToString(datiRtfSgaRtf.Rows[0]["Num"]);
      this.DataDelSopralluogo = Convert.ToString(datiRtfSgaRtf.Rows[0]["DataDelSopralluogo"]);
      this.DataEffetSopralluogo = Convert.ToString(datiRtfSgaRtf.Rows[0]["DataEffetSopralluogo"]);
      this.DaLav = Convert.ToString(datiRtfSgaRtf.Rows[0]["DaLav"]);
      this.ManConduzione = Convert.ToInt32(datiRtfSgaRtf.Rows[0]["ManConduzione"]) == 1;
      this.ManMiglior = Convert.ToInt32(datiRtfSgaRtf.Rows[0]["ManMiglior"]) == 1;
      int[] CarattariPerRiga = new int[2]{ 117, 117 };
      string[] strArray1 = this.DividiParole(Convert.ToString(datiRtfSgaRtf.Rows[0]["DescGuastoAnomalia"]), CarattariPerRiga);
      this.DescGuastoAnomaliaR1 = strArray1[0];
      this.DescGuastoAnomaliaR2 = strArray1[1];
      string[] strArray2 = this.DividiParole(Convert.ToString(datiRtfSgaRtf.Rows[0]["CausaPresGuastAn"]), CarattariPerRiga);
      this.CausaPresGuastAnR1 = strArray2[0];
      this.CausaPresGuastAnR2 = strArray2[1];
      string[] strArray3 = this.DividiParole(Convert.ToString(datiRtfSgaRtf.Rows[0]["PrestazImpStr"]), CarattariPerRiga);
      this.PrestazImpStrR1 = strArray3[0];
      this.PrestazImpStrR2 = strArray3[1];
      string[] strArray4 = this.DividiParole(Convert.ToString(datiRtfSgaRtf.Rows[0]["SolProp"]), CarattariPerRiga);
      this.SolPropR1 = strArray4[0];
      this.SolPropR2 = strArray4[1];
      this.DataPrevInLav = Convert.ToString(datiRtfSgaRtf.Rows[0]["DataPrevInLav"]);
      this.DurPrevLav = Convert.ToString(datiRtfSgaRtf.Rows[0]["DurPrevLav"]) + " gg";
      this.CompCanSi = Convert.ToInt32(datiRtfSgaRtf.Rows[0]["CompCanSi"]) == 1;
      this.CompCanNo = Convert.ToInt32(datiRtfSgaRtf.Rows[0]["CompCanNo"]) == 1;
      this.BoCompMisura = Convert.ToInt32(datiRtfSgaRtf.Rows[0]["BoCompMisura"]) == 1;
      this.CompMisura = Convert.ToString(datiRtfSgaRtf.Rows[0]["CompMisura"]);
      this.IvaMisura = Convert.ToString(datiRtfSgaRtf.Rows[0]["IvaMisura"]);
      this.BoCompForfait = Convert.ToInt32(datiRtfSgaRtf.Rows[0]["BoCompForfait"]) == 1;
      this.CompForfait = Convert.ToString(datiRtfSgaRtf.Rows[0]["CompForfait"]);
      this.IvaForfait = Convert.ToString(datiRtfSgaRtf.Rows[0]["CompForfait"]);
      this.ModPagamento = Convert.ToString(datiRtfSgaRtf.Rows[0]["ModPagamento"]);
      string[] strArray5 = this.DividiParole(Convert.ToString(datiRtfSgaRtf.Rows[0]["NomeFileAllegati"]), CarattariPerRiga);
      this.NomeFileAllegatiR1 = strArray5[0];
      this.NomeFileAllegatiR2 = strArray5[1];
      string[] strArray6 = this.DividiParole(Convert.ToString(datiRtfSgaRtf.Rows[0]["NoteProgetto"]), CarattariPerRiga);
      this.NoteProgettoR1 = strArray6[0];
      this.NoteProgettoR2 = strArray6[1];
      this.NomeResp = Convert.ToString(datiRtfSgaRtf.Rows[0]["NomeResp"]);
      this.TelefonoResp = Convert.ToString(datiRtfSgaRtf.Rows[0]["TelefonoResp"]);
      this.FaxResp = Convert.ToString(datiRtfSgaRtf.Rows[0]["FaxResp"]);
      this.MobileResp = Convert.ToString(datiRtfSgaRtf.Rows[0]["MobileResp"]);
      this.MailResp = Convert.ToString(datiRtfSgaRtf.Rows[0]["MailResp"]);
      this.NomeVisSm = Convert.ToString(datiRtfSgaRtf.Rows[0]["NomeVisSm"]);
      this.DataVisSm = Convert.ToString(datiRtfSgaRtf.Rows[0]["DataVisSm"]);
      this.NomeVisFm = Convert.ToString(datiRtfSgaRtf.Rows[0]["NomeVisFm"]);
      this.DataVisFm = Convert.ToString(datiRtfSgaRtf.Rows[0]["DataVisFm"]);
      return this.ProcessaTutto(datiRtfSgaRtf.Rows[0]["sga_count"].ToString());
    }

    private string[] ProcessaTutto(string sga_count)
    {
      string str1 = Path.Combine(HttpContext.Current.Server.MapPath("..\\Doc_DB"), this.TagBlSede);
      if (!Directory.Exists(str1))
        Directory.CreateDirectory(str1);
      string path1 = Path.Combine(str1, this.WrId.ToString());
      if (!Directory.Exists(path1))
        Directory.CreateDirectory(path1);
      string str2 = path1 + "\\SGA " + this.TagBlSede + " " + this.FormatNumber(sga_count) + "-" + DateTime.Parse(this.TagDataRtf).ToString("yy") + " " + this.DataCreate + ".rtf";
      if (File.Exists(str2))
        File.Delete(str2);
      using (StreamWriter text = File.CreateText(str2))
      {
        text.Write(this.EseguiTrasformazione(this._FileXlst));
        text.Close();
      }
      string str3 = path1 + "\\SGA " + this.TagBlSede + " " + this.FormatNumber(sga_count) + "-" + DateTime.Parse(this.TagDataRtf).ToString("yy") + ".rtf";
      if (File.Exists(str3))
        File.Delete(str3);
      File.Copy(str2, str3, true);
      string path2 = Path.GetDirectoryName(str3) + "\\" + Path.GetFileNameWithoutExtension(str3) + ".zip";
      if (File.Exists(path2))
        File.Delete(path2);
      ZipOutputStream zipOutputStream = new ZipOutputStream((Stream) File.Create(path2));
      zipOutputStream.SetLevel(5);
      FileStream fileStream = File.OpenRead(str3);
      byte[] buffer = new byte[fileStream.Length];
      fileStream.Read(buffer, 0, buffer.Length);
      ZipEntry zipEntry = new ZipEntry(Path.GetFileName(str3));
      zipOutputStream.PutNextEntry(zipEntry);
      ((Stream) zipOutputStream).Write(buffer, 0, buffer.Length);
      ((DeflaterOutputStream) zipOutputStream).Finish();
      ((Stream) zipOutputStream).Close();
      fileStream.Close();
      return new string[2]{ path2, str2 };
    }

    public string EseguiTrasformazione(string PathTrs)
    {
      MemoryStream memoryStream = new MemoryStream();
      XmlTextWriter xmlTextWriter = new XmlTextWriter((Stream) memoryStream, Encoding.Unicode);
      xmlTextWriter.WriteStartElement("data");
      xmlTextWriter.WriteElementString("climatizzazione", this.Tagclimatizzazione);
      xmlTextWriter.WriteElementString("frigoriferi", this.Tagfrigoriferi);
      xmlTextWriter.WriteElementString("idricosanitari", this.Tagidricosanitari);
      xmlTextWriter.WriteElementString("ImpiantiElettrici", this.TagImpiantiElettrici);
      xmlTextWriter.WriteElementString("antincendio", this.Tagantincendio);
      xmlTextWriter.WriteElementString("Conduzione", this.TagConduzione);
      xmlTextWriter.WriteElementString("ManProg", this.TagManProg);
      xmlTextWriter.WriteElementString("Odl", this.TagOdl);
      xmlTextWriter.WriteElementString("NonDifferibile", this.TagNonDifferibile);
      xmlTextWriter.WriteElementString("RichiestaSopralluogo", this.TagRichiestaSopralluogo);
      xmlTextWriter.WriteElementString("ManConduzione", this.TagManConduzione);
      xmlTextWriter.WriteElementString("ManMiglior", this.TagManMiglior);
      xmlTextWriter.WriteElementString("CompCanSi", this.TagCompCanSi);
      xmlTextWriter.WriteElementString("CompCanNo", this.TagCompCanNo);
      xmlTextWriter.WriteElementString("BoCompMisura", this.TagBoCompMisura);
      xmlTextWriter.WriteElementString("BoCompForfait", this.TagBoCompForfait);
      xmlTextWriter.WriteElementString("SERVIZIO", this.Tagservizio);
      xmlTextWriter.WriteElementString("NumeroSga", this.TagNumeroSga);
      xmlTextWriter.WriteElementString("Contratto", this.TagContratto);
      xmlTextWriter.WriteElementString("Impresa", this.TagImpresa);
      xmlTextWriter.WriteElementString("BlSede", this.TagBlSede);
      xmlTextWriter.WriteElementString("DataRtf", this.TagDataRtf);
      xmlTextWriter.WriteElementString("BlCampus", this.TagBlCampus);
      xmlTextWriter.WriteElementString("PianoDec", this.TagPianoDec);
      xmlTextWriter.WriteElementString("AmbienteBl", this.TagAmbienteBl);
      xmlTextWriter.WriteElementString("DataIn", this.TagDataIn);
      xmlTextWriter.WriteElementString("OraIn", this.TagOraIn);
      xmlTextWriter.WriteElementString("Ndie", this.TagNdie);
      xmlTextWriter.WriteElementString("DataDelDifferibile", this.TagDataDelDifferibile);
      xmlTextWriter.WriteElementString("Num", this.TagNum);
      xmlTextWriter.WriteElementString("DataDelSopralluogo", this.TagDataDelSopralluogo);
      xmlTextWriter.WriteElementString("DataEffetSopralluogo", this.TagDataEffetSopralluogo);
      xmlTextWriter.WriteElementString("DaLav", this.TagDaLav);
      xmlTextWriter.WriteElementString("DescGuastoAnomaliaR1", this.TagDescGuastoAnomaliaR1);
      xmlTextWriter.WriteElementString("DescGuastoAnomaliaR2", this.TagDescGuastoAnomaliaR2);
      xmlTextWriter.WriteElementString("CausaPresGuastAnR1", this.TagCausaPresGuastAnR1);
      xmlTextWriter.WriteElementString("CausaPresGuastAnR2", this.TagCausaPresGuastAnR2);
      xmlTextWriter.WriteElementString("PrestazImpStrR1", this.TagPrestazImpStrR1);
      xmlTextWriter.WriteElementString("PrestazImpStrR2", this.TagPrestazImpStrR2);
      xmlTextWriter.WriteElementString("SolPropR1", this.TagSolPropR1);
      xmlTextWriter.WriteElementString("SolPropR2", this.TagSolPropR2);
      xmlTextWriter.WriteElementString("DataPrevInLav", this.TagDataPrevInLav);
      xmlTextWriter.WriteElementString("DurPrevLav", this.TagDurPrevLav);
      xmlTextWriter.WriteElementString("CompMisura", this.TagCompMisura);
      xmlTextWriter.WriteElementString("IvaMisura", this.TagIvaMisura);
      xmlTextWriter.WriteElementString("CompForfait", this.TagCompForfait);
      xmlTextWriter.WriteElementString("IvaForfait", this.TagIvaForfait);
      xmlTextWriter.WriteElementString("ModPagamento", this.TagModPagamento);
      xmlTextWriter.WriteElementString("NomeFileAllegatiR1", this.TagNomeFileAllegatiR1);
      xmlTextWriter.WriteElementString("NomeFileAllegatiR2", this.TagNomeFileAllegatiR2);
      xmlTextWriter.WriteElementString("NoteProgettoR1", this.TagNoteProgettoR1);
      xmlTextWriter.WriteElementString("NoteProgettoR2", this.TagNoteProgettoR2);
      xmlTextWriter.WriteElementString("NomeResp", this.TagNomeResp);
      xmlTextWriter.WriteElementString("TelefonoResp", this.TagTelefonoResp);
      xmlTextWriter.WriteElementString("FaxResp", this.TagFaxResp);
      xmlTextWriter.WriteElementString("MobileResp", this.TagMobileResp);
      xmlTextWriter.WriteElementString("MailResp", this.TagMailResp);
      xmlTextWriter.WriteElementString("FirmaResp", this.TagFirmaResp);
      xmlTextWriter.WriteElementString("NomeVisSm", this.TagNomeVisSm);
      xmlTextWriter.WriteElementString("FirmaVisSm", this.TagFirmaVisSm);
      xmlTextWriter.WriteElementString("DataVisSm", this.TagDataVisSm);
      xmlTextWriter.WriteElementString("NomeVisFm", this.TagNomeVisFm);
      xmlTextWriter.WriteElementString("FirmVIsFm", this.TagFirmVIsFm);
      xmlTextWriter.WriteElementString("DataVisFm", this.TagDataVisFm);
      xmlTextWriter.WriteEndElement();
      xmlTextWriter.Flush();
      memoryStream.Position = 0L;
      XPathDocument xpathDocument = new XPathDocument((Stream) memoryStream);
      StringBuilder sb = new StringBuilder();
      XslTransform xslTransform = new XslTransform();
      xslTransform.Load(PathTrs);
      xslTransform.Transform((IXPathNavigable) xpathDocument, (XsltArgumentList) null, (TextWriter) new StringWriter(sb), (XmlResolver) null);
      return sb.ToString().Trim();
    }

    private string[] DividiParole(string Value, int[] CarattariPerRiga)
    {
      string[] strArray = new string[CarattariPerRiga.Length];
      int startIndex = 0;
      for (int index = 0; index < CarattariPerRiga.Length; ++index)
      {
        int num1 = CarattariPerRiga[index];
        int num2 = Value.Length - 1 <= num1 ? Value.Length : CarattariPerRiga[index];
        strArray[index] = Value.Substring(startIndex, num2);
        Value = Value.Substring(num2);
      }
      return strArray;
    }

    private string[] DividiInRIghe(string RigaDaDividere, int[] CarattariPerRiga)
    {
      string[] strArray = new string[CarattariPerRiga.Length];
      int num1 = 0;
      int startIndex1 = 0;
      int num2 = 0;
      int num3 = 0;
      int startIndex2 = 0;
      if (RigaDaDividere != string.Empty)
      {
        for (int index = 0; index < strArray.Length; ++index)
        {
          num2 += CarattariPerRiga[index];
          while (num1 < num2)
          {
            if (num1 != -1)
            {
              num1 = RigaDaDividere.IndexOf(" ", startIndex1);
              ++startIndex1;
            }
            else
            {
              num1 = RigaDaDividere.Length;
              break;
            }
          }
          int length = num1 - startIndex2;
          strArray[index] = RigaDaDividere.Substring(startIndex2, length);
          startIndex2 = num1;
          num3 += CarattariPerRiga[index];
        }
      }
      else
      {
        for (int index = 0; index < strArray.Length; ++index)
          strArray[index] = string.Empty;
      }
      return strArray;
    }

    private string FormatNumber(string numero)
    {
      if (numero.Length == 0)
        return "";
      if (numero.Length == 1)
        return "000" + numero;
      if (numero.Length == 2)
        return "00" + numero;
      if (numero.Length == 3)
        return "0" + numero;
      return numero.Length == 4 ? numero : "";
    }
  }
}
