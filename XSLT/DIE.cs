// Decompiled with JetBrains decompiler
// Type: TheSite.XSLT.DIE
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace TheSite.XSLT
{
  public class DIE
  {
    private OracleDataLayer _OraDl;
    private string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];
    private int wr_id = 0;
    private string DataCreate = "";

    public DIE(int wr_id, string DataCreate)
    {
      this.wr_id = wr_id;
      this.DataCreate = DataCreate;
      this._OraDl = new OracleDataLayer(this.s_ConnStr);
    }

    public string[] GenerateDIE()
    {
      DataRow row = this.GetDataDIE().Rows[0];
      string str1 = row["codedi"].ToString();
      row["sga"].ToString();
      XmlTextWriter xmlTextWriter1 = new XmlTextWriter((Stream) new MemoryStream(), (Encoding) null);
      xmlTextWriter1.WriteStartElement("data");
      string str2 = row["codedi"].ToString() + "_" + DateTime.Parse(row["dataRichiesta"].ToString()).ToString("yy") + "_" + this.FormatNumber(row["sga_count"].ToString());
      xmlTextWriter1.WriteElementString("CODICE", str2);
      xmlTextWriter1.WriteElementString("SEDE", row["codedi"].ToString());
      xmlTextWriter1.WriteElementString("PIANO", row["piano"].ToString().Replace("°", "\\'b0"));
      xmlTextWriter1.WriteElementString("DATA", row["date_requested"].ToString());
      xmlTextWriter1.WriteElementString("NOMEEDIFICIO", row["edificio"].ToString());
      xmlTextWriter1.WriteElementString("AMBIENTE", row["ambiente"].ToString());
      xmlTextWriter1.WriteElementString("SERVIZIO", row["servizio_id"].ToString());
      xmlTextWriter1.WriteElementString("DESCPROB", row["descrizioneprob"].ToString());
      xmlTextWriter1.WriteElementString("ID_SEG", row["id_sga_seguito"].ToString());
      switch (row["id_sga_seguito"].ToString())
      {
        case "3":
          xmlTextWriter1.WriteElementString("ORDINEDEL", row["die_del"].ToString());
          xmlTextWriter1.WriteElementString("ORDINENUM", row["die_numero"].ToString());
          break;
        case "4":
          xmlTextWriter1.WriteElementString("MANDIFFDEL", row["die_del"].ToString());
          break;
        case "2":
          xmlTextWriter1.WriteElementString("MANPROGDEL", row["die_del"].ToString());
          break;
      }
      xmlTextWriter1.WriteElementString("DIETIPINT", row["die_tipo_intervento"].ToString());
      xmlTextWriter1.WriteElementString("N_REG", row["die_registro"].ToString());
      xmlTextWriter1.WriteElementString("MESE", this.GetMese(row["die_mese"].ToString()));
      xmlTextWriter1.WriteElementString("GG_APERTURA", row["date_requested"].ToString());
      xmlTextWriter1.WriteElementString("GG_INTMA", row["date_start"].ToString());
      xmlTextWriter1.WriteElementString("GG_CHIUSURA", row["date_end"].ToString());
      xmlTextWriter1.WriteElementString("NOMEDITTA", row["ditta"].ToString());
      xmlTextWriter1.WriteElementString("TECNICOESECUTORE", row["addetto"].ToString());
      xmlTextWriter1.WriteElementString("TELEFONO", row["telefono"].ToString());
      xmlTextWriter1.WriteElementString("EMAIL", row["email"].ToString());
      xmlTextWriter1.WriteElementString("VAL_ECONOMICA", "");
      xmlTextWriter1.WriteElementString("TIP_MAN", row["tipomanutenzione_id"].ToString());
      xmlTextWriter1.WriteElementString("COSTO_MAT", row["TM"].ToString());
      xmlTextWriter1.WriteElementString("COSTO_PERS", row["TA"].ToString());
      double num = double.Parse(row["TM"].ToString()) + double.Parse(row["TA"].ToString());
      xmlTextWriter1.WriteElementString("COSTO_TOT", num.ToString());
      xmlTextWriter1.WriteElementString("DICHIARA1", row["die_dichiara1"].ToString());
      xmlTextWriter1.WriteElementString("DICHIARA2", row["die_dichiara2"].ToString());
      int[] CarattariPerRiga1 = new int[2]{ 108, 108 };
      string[] strArray1 = this.DividiParole(row["comments"].ToString(), CarattariPerRiga1);
      xmlTextWriter1.WriteElementString("DICHIARA", strArray1[0]);
      xmlTextWriter1.WriteElementString("DICHIARA_1", strArray1[1]);
      int[] CarattariPerRiga2 = new int[2]{ 103, 78 };
      string[] strArray2 = this.DividiParole(row["die_note"].ToString(), CarattariPerRiga2);
      xmlTextWriter1.WriteElementString("DICHIARA_NOTE1", strArray2[0]);
      xmlTextWriter1.WriteElementString("DICHIARA_NOTE2", strArray2[1]);
      xmlTextWriter1.WriteElementString("NOME_MA", row["nomimativo"].ToString());
      xmlTextWriter1.WriteElementString("TEL_MA", row["tel"].ToString());
      xmlTextWriter1.WriteElementString("FAX_MA", row["fax"].ToString());
      xmlTextWriter1.WriteElementString("MOBILE_MA", row["mobile"].ToString());
      xmlTextWriter1.WriteElementString("MAIL_MA", row["email_ma"].ToString());
      xmlTextWriter1.WriteElementString("NOME_SM", row["sm_nome"].ToString());
      xmlTextWriter1.WriteElementString("FIRMA_SM", row["sm_firma"].ToString());
      xmlTextWriter1.WriteElementString("DATA_SM", row["sm_data"].ToString());
      xmlTextWriter1.WriteElementString("NOME_FM", row["fm_nome"].ToString());
      xmlTextWriter1.WriteElementString("FIRMA_FM", row["fm_firma"].ToString());
      xmlTextWriter1.WriteElementString("DATA_FM", row["fm_data"].ToString());
      xmlTextWriter1.WriteEndElement();
      xmlTextWriter1.Flush();
      Stream baseStream = xmlTextWriter1.BaseStream;
      baseStream.Position = 0L;
      XPathDocument xpathDocument = new XPathDocument(baseStream);
      string url = HttpContext.Current.Server.MapPath("..\\XSLT\\" + (!(row["id_progetto"].ToString() == "2") ? "XSLTDIE.xslt" : "XSLTDIEVod.xslt"));
      XslTransform xslTransform = new XslTransform();
      xslTransform.Load(url);
      XsltArgumentList xsltArgumentList = new XsltArgumentList();
      string str3 = Path.Combine(HttpContext.Current.Server.MapPath("..\\Doc_DB"), row["codedi"].ToString());
      if (!Directory.Exists(str3))
        Directory.CreateDirectory(str3);
      string path1 = Path.Combine(str3, this.wr_id.ToString());
      if (!Directory.Exists(path1))
        Directory.CreateDirectory(path1);
      string[] strArray3 = new string[10]
      {
        path1,
        "\\DIE ",
        str1,
        " ",
        this.FormatNumber(row["sga_count"].ToString()),
        "-",
        null,
        null,
        null,
        null
      };
      string[] strArray4 = strArray3;
      DateTime dateTime = DateTime.Parse(row["dataRichiesta"].ToString());
      string str4 = dateTime.ToString("yy");
      strArray4[6] = str4;
      strArray3[7] = " ";
      strArray3[8] = this.DataCreate;
      strArray3[9] = ".rtf";
      string str5 = string.Concat(strArray3);
      XmlTextWriter xmlTextWriter2 = new XmlTextWriter(str5, (Encoding) null);
      xslTransform.Transform((IXPathNavigable) xpathDocument, (XsltArgumentList) null, (XmlWriter) xmlTextWriter2, (XmlResolver) null);
      xmlTextWriter2.Flush();
      xmlTextWriter2.Close();
      baseStream.Close();
      string[] strArray5 = new string[8]
      {
        path1,
        "\\DIE ",
        str1,
        " ",
        this.FormatNumber(row["sga_count"].ToString()),
        "-",
        null,
        null
      };
      string[] strArray6 = strArray5;
      dateTime = DateTime.Parse(row["dataRichiesta"].ToString());
      string str6 = dateTime.ToString("yy");
      strArray6[6] = str6;
      strArray5[7] = ".rtf";
      string str7 = string.Concat(strArray5);
      if (File.Exists(str7))
        File.Delete(str7);
      File.Copy(str5, str7, true);
      string path2 = Path.GetDirectoryName(str7) + "\\" + Path.GetFileNameWithoutExtension(str7) + ".zip";
      if (File.Exists(path2))
        File.Delete(path2);
      ZipOutputStream zipOutputStream = new ZipOutputStream((Stream) File.Create(path2));
      zipOutputStream.SetLevel(5);
      FileStream fileStream = File.OpenRead(str7);
      byte[] buffer = new byte[fileStream.Length];
      fileStream.Read(buffer, 0, buffer.Length);
      ZipEntry zipEntry = new ZipEntry(Path.GetFileName(str7));
      zipOutputStream.PutNextEntry(zipEntry);
      ((Stream) zipOutputStream).Write(buffer, 0, buffer.Length);
      ((DeflaterOutputStream) zipOutputStream).Finish();
      ((Stream) zipOutputStream).Close();
      return new string[2]{ path2, str5 };
    }

    private DataTable GetDataDIE()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_wr_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) controlsCollection).Count);
      ((ParameterObject) sObject1).set_Value((object) this.wr_id);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) controlsCollection).Count);
      controlsCollection.Add(sObject2);
      string str = "PACK_MANCORRETIVA.SP_GETDATIDIE";
      return this._OraDl.GetRows((object) controlsCollection, str).Tables[0];
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

    private string GetMese(string mese)
    {
      if (mese == "1")
        return "GENNAIO";
      if (mese == "2")
        return "FEBBRAIO";
      if (mese == "3")
        return "MARZO";
      if (mese == "4")
        return "APRILE";
      if (mese == "5")
        return "MAGGIO";
      if (mese == "6")
        return "GIUGNO";
      if (mese == "7")
        return "LUGLIO";
      if (mese == "8")
        return "AGOSTO";
      if (mese == "9")
        return "SETTEMBRE";
      if (mese == "10")
        return "OTTOBRE";
      if (mese == "11")
        return "NOVEMBRE";
      return mese == "12" ? "DICEMBRE" : "";
    }
  }
}
