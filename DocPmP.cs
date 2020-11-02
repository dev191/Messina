// Decompiled with JetBrains decompiler
// Type: TheSite.DocPmP
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using ExcelPMP;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using PMPExcel;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi.ManProgrammata;

namespace TheSite
{
  public class DocPmP : Page
  {
    protected Button BtInvia;
    protected Label lblMessage;
    protected DropDownList DrTipoDocumenti;
    protected TextBox TxtAnnotazioni;
    protected Label lblMese;
    protected Label lblAnno;
    protected DropDownList DropMese;
    protected DropDownList DropAnno;
    protected HtmlInputFile UploadFile;
    protected DropDownList DrEdifici;
    private int Result;
    private InvioDocPmP _inviodoc = new InvioDocPmP();

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      this.LoadCombo();
    }

    private void LoadCombo()
    {
      this.DrEdifici.DataSource = (object) new InvioDocPmP().GetEdifici(this.Context.User.Identity.Name).Tables[0];
      this.DrEdifici.DataTextField = "Denominazione";
      this.DrEdifici.DataValueField = "id";
      this.DrEdifici.DataBind();
      for (int index = 2008; index <= 2020; ++index)
        this.DropAnno.Items.Add(new ListItem(index.ToString(), index.ToString()));
      this.DrTipoDocumenti.Attributes.Add("onclick", "setvis()");
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.BtInvia.Click += new EventHandler(this.BtInvia_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void SalvaInvio()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_bl_Id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) Convert.ToInt32(this.DrEdifici.SelectedValue));
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_NOME_DOC");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(225);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) Path.GetFileName(this.UploadFile.PostedFile.FileName));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_ID_STATO");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (this.DrTipoDocumenti.SelectedValue == "1")
        ((ParameterObject) sObject4).set_Value((object) "1");
      if (this.DrTipoDocumenti.SelectedValue == "2")
        ((ParameterObject) sObject4).set_Value((object) "3");
      if (this.DrTipoDocumenti.SelectedValue == "3")
        ((ParameterObject) sObject4).set_Value((object) "1");
      if (this.DrTipoDocumenti.SelectedValue == "4")
        ((ParameterObject) sObject4).set_Value((object) "5");
      if (this.DrTipoDocumenti.SelectedValue == "5")
        ((ParameterObject) sObject4).set_Value((object) "3");
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_DATA_INVIO");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size(225);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      S_Object sObject6 = sObject5;
      DateTime now = DateTime.Now;
      string shortDateString1 = now.ToShortDateString();
      ((ParameterObject) sObject6).set_Value((object) shortDateString1);
      CollezioneControlli.Add(sObject5);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_DATA_INSERIMENTo");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(225);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
      S_Object sObject8 = sObject7;
      now = DateTime.Now;
      string shortDateString2 = now.ToShortDateString();
      ((ParameterObject) sObject8).set_Value((object) shortDateString2);
      CollezioneControlli.Add(sObject7);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_anno");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Size(225);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject9).set_Value((object) this.DropAnno.SelectedValue);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_note1");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Size(225);
      ((ParameterObject) sObject10).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject10).set_Value((object) this.TxtAnnotazioni.Text.Trim());
      CollezioneControlli.Add(sObject10);
      if (this.DrTipoDocumenti.SelectedValue == "2" || this.DrTipoDocumenti.SelectedValue == "1")
      {
        this.Result = this._inviodoc.SaveAnni(CollezioneControlli);
      }
      else
      {
        S_Object sObject11 = new S_Object();
        ((ParameterObject) sObject11).set_ParameterName("p_mese");
        ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject11).set_Size(225);
        ((ParameterObject) sObject11).set_Index(((CollectionBase) CollezioneControlli).Count);
        ((ParameterObject) sObject11).set_Value((object) this.DropMese.SelectedValue);
        CollezioneControlli.Add(sObject11);
        this.Result = this._inviodoc.SaveMesi(CollezioneControlli);
      }
    }

    private void SalvaEseguito(string FileExcel, string FileA8)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_bl_Id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) Convert.ToInt32(this.DrEdifici.SelectedValue));
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_NOME_DOC");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(225);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) Path.GetFileName(FileExcel));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_ID_STATO");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Value((object) "5");
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_DATA_INVIO");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size(225);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Value((object) DateTime.Now.ToShortDateString());
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_DATA_INSERIMENTo");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Size(225);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject6).set_Value((object) DateTime.Now.ToShortDateString());
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_anno");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(225);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject7).set_Value((object) this.DropAnno.SelectedValue);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_note1");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Size(225);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject8).set_Value((object) this.TxtAnnotazioni.Text.Trim());
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_mese");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Size(225);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject9).set_Value((object) this.DropMese.SelectedValue);
      CollezioneControlli.Add(sObject9);
      this.Result = this._inviodoc.SaveMesi(CollezioneControlli);
    }

    private void SalvaA8(string FileA8)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_bl_Id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) Convert.ToInt32(this.DrEdifici.SelectedValue));
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_NOME_DOC");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(225);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) Path.GetFileName(FileA8));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_ID_STATO");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (this.DrTipoDocumenti.SelectedValue == "1")
        ((ParameterObject) sObject4).set_Value((object) "1");
      if (this.DrTipoDocumenti.SelectedValue == "2")
        ((ParameterObject) sObject4).set_Value((object) "3");
      if (this.DrTipoDocumenti.SelectedValue == "3")
        ((ParameterObject) sObject4).set_Value((object) "1");
      if (this.DrTipoDocumenti.SelectedValue == "4")
        ((ParameterObject) sObject4).set_Value((object) "5");
      if (this.DrTipoDocumenti.SelectedValue == "5")
        ((ParameterObject) sObject4).set_Value((object) "3");
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_DATA_INVIO");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size(225);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      S_Object sObject6 = sObject5;
      DateTime now = DateTime.Now;
      string shortDateString1 = now.ToShortDateString();
      ((ParameterObject) sObject6).set_Value((object) shortDateString1);
      CollezioneControlli.Add(sObject5);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_DATA_INSERIMENTo");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(225);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count);
      S_Object sObject8 = sObject7;
      now = DateTime.Now;
      string shortDateString2 = now.ToShortDateString();
      ((ParameterObject) sObject8).set_Value((object) shortDateString2);
      CollezioneControlli.Add(sObject7);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_anno");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Size(225);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject9).set_Value((object) this.DropAnno.SelectedValue);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_note1");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Size(225);
      ((ParameterObject) sObject10).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject10).set_Value((object) this.TxtAnnotazioni.Text.Trim());
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_mese");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Size(225);
      ((ParameterObject) sObject11).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject11).set_Value((object) this.DropMese.SelectedValue);
      CollezioneControlli.Add(sObject11);
      this._inviodoc.SaveMesi(CollezioneControlli);
    }

    private void UpdatePMP(string FileName, UpdateType updatetype)
    {
      string appSetting = ConfigurationSettings.AppSettings["ConnectionString"];
      using (PMPExcel.PMPExcel pmpExcel = new PMPExcel.PMPExcel(FileName, updatetype, this.Context.User.Identity.Name, appSetting))
      {
        try
        {
          this.lblMessage.Text = pmpExcel.ReadDocument().ToString().Replace("\n", "</br>");
        }
        catch (Exception ex)
        {
          this.lblMessage.Text = ex.Message;
        }
      }
    }

    private void BtInvia_Click(object sender, EventArgs e)
    {
      this.lblMessage.Text = "";
      this.SendDoc();
    }

    private bool IsValidDocMensile()
    {
      this.lblMessage.Text = "";
      string fileName = Path.GetFileName(this.UploadFile.PostedFile.FileName);
      if (Path.GetExtension(fileName) != ".xls")
      {
        this.lblMessage.Text = "Il File selezionato non è un file Excel!";
        return true;
      }
      string[] strArray = fileName.Split('_');
      if (strArray.Length < 4)
      {
        this.lblMessage.Text = "Il File selezionato non è un file Valido per l'invio il formato deve essere: PMX_xls_NOMEEDIFICIO_MESE_ANNO_VERSIONE.xls!";
        return true;
      }
      string str1 = strArray[2];
      string mese = this.GetMese(strArray[3]);
      string str2 = strArray[4].Length != 2 ? strArray[4] : "20" + strArray[4];
      if (this.DrEdifici.Items[this.DrEdifici.SelectedIndex].Text.Split(' ')[0].Trim() != str1)
      {
        this.lblMessage.Text = "Il Nome del File selezionato contiene un Edificio corrisponde all'edificio selezionato!";
        return true;
      }
      if (this.DropMese.SelectedValue != Convert.ToInt32(mese).ToString())
      {
        this.lblMessage.Text = "Il Nome del File selezionato contiene un Mese corrisponde a quello selezionato!";
        return true;
      }
      if (this.DropAnno.SelectedValue != str2)
      {
        this.lblMessage.Text = "Il Nome del File selezionato contiene un Anno non corrisponde a quello selezionato!";
        return true;
      }
      string name = this.Context.User.Identity.Name;
      int int32 = Convert.ToInt32(this.DrEdifici.SelectedValue);
      if (this.DrTipoDocumenti.SelectedValue == "3" && this._inviodoc.IsValidStatus(int32, Convert.ToInt32(mese), Convert.ToInt32(str2), 3, name) == -1)
      {
        this.lblMessage.Text = "Il Programma non può essere aggiornato in Proposto perchè è già eseguito in precedenza o non stato accettato!";
        return true;
      }
      if (this.DrTipoDocumenti.SelectedValue == "4")
      {
        if (strArray[0].ToUpper() != "PME")
        {
          this.lblMessage.Text = "Il Programma inviato come Eseguito perchè è il nome del file non inizia con PME!";
          return true;
        }
        if (this._inviodoc.IsValidStatus(int32, Convert.ToInt32(mese), Convert.ToInt32(str2), 4, name) == -1)
        {
          this.lblMessage.Text = "Il Programma non può essere aggiornato in Eseguito perchè è già eseguito in precedenza o non stato accettato!";
          return true;
        }
      }
      if (!(this.DrTipoDocumenti.SelectedValue == "5") || this._inviodoc.IsValidStatus(int32, Convert.ToInt32(mese), Convert.ToInt32(str2), 5, name) != -1)
        return false;
      this.lblMessage.Text = "Il Programma non può essere aggiornato in Accetto perchè è già eseguito in precedenza o non stato accettato!";
      return true;
    }

    private void SendDoc()
    {
      string str1 = this.Server.MapPath("../Doc_DB");
      if (this.UploadFile.PostedFile == null || !(this.UploadFile.PostedFile.FileName != ""))
        return;
      string path1 = str1 + "\\Manutenzione Programmata";
      if (!Directory.Exists(path1))
        Directory.CreateDirectory(path1);
      string path2 = path1 + "\\PAM" + this.DropAnno.SelectedValue;
      if (!Directory.Exists(path2))
        Directory.CreateDirectory(path2);
      string path3 = path1 + "\\PMP" + this.DropAnno.SelectedValue;
      if (!Directory.Exists(path3))
        Directory.CreateDirectory(path3);
      string[] strArray = this.DrEdifici.Items[this.DrEdifici.SelectedIndex].Text.Split(' ');
      string str2;
      if (this.DrTipoDocumenti.SelectedValue == "3" || this.DrTipoDocumenti.SelectedValue == "4" || this.DrTipoDocumenti.SelectedValue == "5")
      {
        string path4 = path3 + "\\" + strArray[0].Trim();
        if (!Directory.Exists(path4))
          Directory.CreateDirectory(path4);
        str2 = path4;
      }
      else
        str2 = path2;
      string str3 = str2 + "\\" + Path.GetFileName(this.UploadFile.PostedFile.FileName);
      if (File.Exists(str3))
      {
        this.lblMessage.Text = "Impossibile Salvare il file inviato. Il file già esiste, rinominare il file o selezionare un file diverso.";
      }
      else
      {
        if (this.IsValidDocMensile())
          return;
        this.UploadFile.PostedFile.SaveAs(str3);
        this.SalvaInvio();
        if (this.DrTipoDocumenti.SelectedValue == "3")
          this.UpdatePMP(str3, (UpdateType) 0);
        if (this.DrTipoDocumenti.SelectedValue == "4")
          this.UpdatePMP(str3, (UpdateType) 2);
        if (this.DrTipoDocumenti.SelectedValue == "5")
          this.UpdatePMP(str3, (UpdateType) 1);
        this.SendMail(str3);
      }
    }

    private void SendMail(string FileName)
    {
      string[] strArray = this.DrEdifici.Items[this.DrEdifici.SelectedIndex].Text.Split(' ');
      this._inviodoc.GetIdProgetto(strArray[0].Trim());
      string str1;
      if (this.DrTipoDocumenti.SelectedValue == "4")
      {
        string appSetting = ConfigurationSettings.AppSettings["ConnectionString"];
        string str2 = this.Server.MapPath("../MasterExcel");
        string directoryName = Path.GetDirectoryName(FileName);
        string str3 = "";
        using (ExcelWritePMP excelWritePmp = new ExcelWritePMP(str2, directoryName, appSetting))
          str3 = excelWritePmp.WriteFilePMP(strArray[0].Trim(), Convert.ToInt32(this.DropMese.SelectedValue), Convert.ToInt32(this.DropAnno.SelectedValue));
        str1 = Path.GetDirectoryName(str3) + "\\" + Path.GetFileNameWithoutExtension(str3) + ".zip";
        if (File.Exists(str1))
          File.Delete(str1);
        ZipOutputStream zipOutputStream = new ZipOutputStream((Stream) File.Create(str1));
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
        string FileA8 = "";
        this.SalvaEseguito(str3, FileA8);
      }
      else
      {
        str1 = Path.GetDirectoryName(FileName) + "\\" + Path.GetFileNameWithoutExtension(FileName) + ".zip";
        if (File.Exists(str1))
          File.Delete(str1);
        ZipOutputStream zipOutputStream = new ZipOutputStream((Stream) File.Create(str1));
        zipOutputStream.SetLevel(5);
        FileStream fileStream = File.OpenRead(FileName);
        byte[] buffer = new byte[fileStream.Length];
        fileStream.Read(buffer, 0, buffer.Length);
        ZipEntry zipEntry = new ZipEntry(Path.GetFileName(FileName));
        zipOutputStream.PutNextEntry(zipEntry);
        ((Stream) zipOutputStream).Write(buffer, 0, buffer.Length);
        ((DeflaterOutputStream) zipOutputStream).Finish();
        ((Stream) zipOutputStream).Close();
        fileStream.Close();
      }
      DataSet dataSet = !(this.DrTipoDocumenti.SelectedValue == "4") ? this._inviodoc.GetDestinatari(int.Parse(this.DrEdifici.SelectedValue), false) : this._inviodoc.GetDestinatari(int.Parse(this.DrEdifici.SelectedValue), true);
      DataColumn column = new DataColumn("IsExecute", Type.GetType("System.Int32"));
      column.DefaultValue = (object) 0;
      DataTable table = dataSet.Tables[0];
      table.Columns.Add(column);
      bool flag = false;
      string mailByUser = this._inviodoc.GetMailByUser();
      foreach (DataRow row in (InternalDataCollectionBase) table.Rows)
      {
        if (mailByUser.Trim().ToLower() == row["email"].ToString().Trim().ToLower())
        {
          flag = true;
          row["IsExecute"] = (object) 1;
          break;
        }
      }
      if (!flag && mailByUser != "")
      {
        DataRow row = table.NewRow();
        row["email"] = (object) mailByUser;
        row["IsExecute"] = (object) 1;
        table.Rows.Add(row);
      }
      table.AcceptChanges();
      int num = 0;
      string str4 = "";
      foreach (DataRow row1 in (InternalDataCollectionBase) table.Rows)
      {
        ++num;
        if (row1["id_utente"].ToString() != "")
        {
          str4 = row1["email"].ToString();
        }
        else
        {
          str4 = str4 + row1["email"].ToString() + "; ";
          if (num != table.Rows.Count)
            continue;
        }
        MailMessage message = new MailMessage();
        message.BodyFormat = MailFormat.Html;
        message.BodyEncoding = Encoding.UTF8;
        message.From = ConfigurationSettings.AppSettings["MailFrom"].ToString();
        message.To = str4;
        message.Cc = "ssys@cft-sir.it";
        str4 = "";
        if (this.DrTipoDocumenti.SelectedValue == "3" || this.DrTipoDocumenti.SelectedValue == "4" || this.DrTipoDocumenti.SelectedValue == "5")
        {
          string str2 = "";
          string str3 = "";
          if (this.DrTipoDocumenti.SelectedValue == "3")
          {
            if (row1["id_utente"].ToString() != "")
            {
              string str5 = "&t=m&e=" + this.DrEdifici.SelectedValue;
              str2 = "<DIV>&nbsp;</DIV><DIV>&nbsp;</DIV><DIV><A href=\"http://www.cft-sir.it/MEHV/default.aspx?u=" + row1["id_utente"].ToString() + str5 + "&s=3&id=" + this.Result.ToString() + "\">Programma Accettato </A></DIV>" + "<DIV>&nbsp;</DIV><DIV><A href=\"http://www.cft-sir.it/MEHV/default.aspx?u=" + row1["id_utente"].ToString() + str5 + "&s=4&id=" + this.Result.ToString() + "\">Programma Accettato con Riserva</A></DIV>" + "<DIV>&nbsp;</DIV><DIV><A href=\"http://www.cft-sir.it/MEHV/default.aspx?u=" + row1["id_utente"].ToString() + str5 + "&s=2&id=" + this.Result.ToString() + "\">Programma Rifiutato</A></DIV><DIV>&nbsp;</DIV>";
              str3 = "<DIV>Sono predisposti i seguenti link per <STRONG>Approvare</STRONG>,&nbsp;<STRONG>Approvare con promessa di aggiustamento</STRONG>&nbsp;o&nbsp;<STRONG>Respingere</STRONG> il programma di manutenzione.</DIV>";
            }
          }
          string str6 = this.DrEdifici.Items[this.DrEdifici.SelectedIndex].Text.Substring(0, this.DrEdifici.Items[this.DrEdifici.SelectedIndex].Text.IndexOf("-") - 1);
          MailMessage mailMessage = message;
          string format = this.DrTipoDocumenti.Items[this.DrTipoDocumenti.SelectedIndex].Text + " mese " + this.DropMese.Items[this.DropMese.SelectedIndex].Text + " " + this.DropAnno.Items[this.DropAnno.SelectedIndex].Text.Substring(2) + " Sede: " + str6 + " Data invio: {0} Ora: {1}";
          DateTime now = DateTime.Now;
          string longDateString = now.ToLongDateString();
          now = DateTime.Now;
          string longTimeString = now.ToLongTimeString();
          string str7 = string.Format(format, (object) longDateString, (object) longTimeString);
          mailMessage.Subject = str7;
          string str8 = "";
          foreach (DataRow row2 in (InternalDataCollectionBase) table.Rows)
            str8 = str8 + row2["email"].ToString() + "; ";
          string str9 = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">" + "<HTML><HEAD><META http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\">" + "<BODY bgColor=#ffffff><DIV>Altri destinatari: " + str8 + "</DIV>" + "<DIV>E' stato inserito un nuovo documento del " + this.DrTipoDocumenti.Items[this.DrTipoDocumenti.SelectedIndex].Text + " relativo alla sede " + this.DrEdifici.Items[this.DrEdifici.SelectedIndex].Text + "\tdel mese di " + this.DropMese.Items[this.DropMese.SelectedIndex].Text + " " + this.DropAnno.Items[this.DropAnno.SelectedIndex].Text + "</DIV>" + "<DIV>con le seguenti annotazioni:</DIV><DIV>" + this.TxtAnnotazioni.Text + "</DIV>" + str3 + str2 + "<DIV>&nbsp;</DIV>";
          if (row1["IsExecute"].ToString() == "1")
            str9 = str9 + "</br>Rapporto del File inviato:</br>" + this.lblMessage.Text;
          string str10 = str9 + "<DIV>SIR Cofathec Servizi S.p.a.</DIV><DIV>&nbsp;</DIV></BODY></HTML>";
          message.Body = str10;
          message.Fields[(object) "http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = (object) 1;
          message.Fields[(object) "http://schemas.microsoft.com/cdo/configuration/sendusername"] = (object) ConfigurationSettings.AppSettings["usersmtp"].ToString();
          message.Fields[(object) "http://schemas.microsoft.com/cdo/configuration/sendpassword"] = (object) ConfigurationSettings.AppSettings["pwdsmtp"].ToString();
          MailAttachment mailAttachment = new MailAttachment(str1);
          message.Attachments.Add((object) mailAttachment);
          SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["SmtpServer2"].ToString();
          SmtpMail.Send(message);
        }
        else
        {
          string str2 = "";
          string str3 = "";
          if (this.DrTipoDocumenti.SelectedValue == "1")
          {
            if (row1["id_utente"].ToString() != "")
            {
              string str5 = "&t=a&e=" + this.DrEdifici.SelectedValue;
              str2 = "<DIV>&nbsp;</DIV><DIV><A href=\"http://www.cft-sir.it/MEHV/default.aspx?u=" + row1["id_utente"].ToString() + str5 + "&s=3&id=" + this.Result.ToString() + "\">Piano Accettato </A></DIV>" + "<DIV>&nbsp;</DIV><DIV><A href=\"http://www.cft-sir.it/MEHV/default.aspx?u=" + row1["id_utente"].ToString() + str5 + "&s=4&id=" + this.Result.ToString() + "\">Piano Accettato con Riserva</A></DIV>" + "<DIV>&nbsp;</DIV><DIV><A href=\"http://www.cft-sir.it/MEHV/default.aspx?u=" + row1["id_utente"].ToString() + str5 + "&s=2&id=" + this.Result.ToString() + "\">Piano Rifiutato</A></DIV><DIV>&nbsp;</DIV>";
              str3 = "<DIV>Sono predisposti i seguenti link per <STRONG>Approvare</STRONG>,&nbsp;<STRONG>Approvare con promessa di aggiustamento</STRONG>&nbsp;o&nbsp;<STRONG>Respingere</STRONG> il piano di manutenzione Annuale.</DIV>";
            }
          }
          string str6 = this.DrEdifici.Items[this.DrEdifici.SelectedIndex].Text.Substring(1, this.DrEdifici.Items[this.DrEdifici.SelectedIndex].Text.IndexOf("-") - 1);
          message.Subject = string.Format(this.DrTipoDocumenti.Items[this.DrTipoDocumenti.SelectedIndex].Text + " anno " + this.DropAnno.Items[this.DropAnno.SelectedIndex].Text.Substring(2) + " Sede: " + str6 + " Data invio: {0} Ora: {1}", (object) DateTime.Now.ToLongDateString(), (object) DateTime.Now.ToLongTimeString());
          string str7 = "";
          foreach (DataRow row2 in (InternalDataCollectionBase) table.Rows)
            str7 = str7 + row2["email"].ToString() + "; ";
          string str8 = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">" + "<HTML><HEAD><META http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\">" + "<BODY bgColor=#ffffff><DIV>Altri destinatari: " + str7 + "</DIV>" + "<DIV>E' stato inserito un nuovo documento del " + this.DrTipoDocumenti.Items[this.DrTipoDocumenti.SelectedIndex].Text + " relativo alla sede " + this.DrEdifici.Items[this.DrEdifici.SelectedIndex].Text + "\t" + this.DropAnno.Items[this.DropAnno.SelectedIndex].Text + "</DIV>" + "<DIV>con le seguenti annotazioni:</DIV><DIV>" + this.TxtAnnotazioni.Text + "</DIV>" + str3 + str2 + "<DIV>&nbsp;</DIV>";
          if (row1["IsExecute"].ToString() == "1")
            str8 = str8 + "</br>Rapporto del File inviato:</br>" + this.lblMessage.Text;
          string str9 = str8 + "<DIV>SIR Cofathec Servizi S.p.a.</DIV><DIV>&nbsp;</DIV></BODY></HTML>";
          message.Body = str9;
          MailAttachment mailAttachment = new MailAttachment(str1);
          message.Attachments.Add((object) mailAttachment);
          message.Fields[(object) "http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = (object) 1;
          message.Fields[(object) "http://schemas.microsoft.com/cdo/configuration/sendusername"] = (object) ConfigurationSettings.AppSettings["usersmtp"].ToString();
          message.Fields[(object) "http://schemas.microsoft.com/cdo/configuration/sendpassword"] = (object) ConfigurationSettings.AppSettings["pwdsmtp"].ToString();
          SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["SmtpServer2"].ToString();
          SmtpMail.Send(message);
        }
      }
    }

    private string GetMese(string mese)
    {
      if (mese.ToUpper() == "GEN")
        return "01";
      if (mese.ToUpper() == "FEB")
        return "02";
      if (mese.ToUpper() == "MAR")
        return "03";
      if (mese.ToUpper() == "APR")
        return "04";
      if (mese.ToUpper() == "MAG")
        return "05";
      if (mese.ToUpper() == "GIU")
        return "06";
      if (mese.ToUpper() == "LUG")
        return "07";
      if (mese.ToUpper() == "AGO")
        return "08";
      if (mese.ToUpper() == "SET")
        return "09";
      if (mese.ToUpper() == "OTT")
        return "10";
      if (mese.ToUpper() == "NOV")
        return "11";
      if (mese.ToUpper() == "DIC")
        return "12";
      if (mese.ToUpper() == "GENNAIO")
        return "01";
      if (mese.ToUpper() == "FEBBRAIO")
        return "02";
      if (mese.ToUpper() == "MARZO")
        return "03";
      if (mese.ToUpper() == "APRILE")
        return "04";
      if (mese.ToUpper() == "MAGGIO")
        return "05";
      if (mese.ToUpper() == "GIUGNO")
        return "06";
      if (mese.ToUpper() == "LUGLIO")
        return "07";
      if (mese.ToUpper() == "AGOSTO")
        return "08";
      if (mese.ToUpper() == "SETTEMBRE")
        return "09";
      if (mese.ToUpper() == "OTTOBRE")
        return "10";
      if (mese.ToUpper() == "NOVEMBRE")
        return "11";
      return mese.ToUpper() == "DICEMBRE" ? "12" : "";
    }
  }
}
