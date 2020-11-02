// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorrettiva.SfogliDoc
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ManCorrettiva;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorrettiva
{
  public class SfogliDoc : Page
  {
    protected DataPanel PanelRicerca;
    protected S_ComboBox cmbsTipoDoc;
    protected S_Button btnsRicerca;
    protected Button cmdReset;
    protected S_TextBox TxtWr_id;
    protected S_TextBox TxtCodice;
    protected S_TextBox TxtNomeDoc;
    protected S_TextBox txtUtente;
    protected DataGrid DataGridRicerca;
    protected RicercaModulo RicercaModulo1;
    protected CalendarPicker CalendarPicker1;
    protected GridTitle GridTitle1;
    private Traccia_doc Traccia_doc = new Traccia_doc();
    public static string HelpLink = string.Empty;
    public SiteModule _SiteModule;
    public static int FunId = 0;
    protected PageTitle PageTitle1;
    private CompletaRdl _fp = (CompletaRdl) null;
    private clMyCollection _myColl = new clMyCollection();

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      this._SiteModule = new SiteModule("./ManutenzioneCorrettiva/SfogliaDoc.aspx");
      SfogliDoc.FunId = this._SiteModule.ModuleId;
      SfogliDoc.HelpLink = this._SiteModule.HelpLink;
      this.PageTitle1.Title = "SFOGLIA TRACCIA DOCUMENTI";
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      if (!(this.Context.Handler is CompletaRdl))
        return;
      this._fp = (CompletaRdl) this.Context.Handler;
      if (this._fp == null)
        return;
      this._myColl = this._fp._Contenitore;
      this._myColl.SetValues(this.Page.Controls);
      this.Ricerca();
    }

    public DataSet Destinatari(int id_bl, int id_servizio, string tipo_doc) => this.Traccia_doc.GetDestinatari(id_bl, id_servizio, tipo_doc);

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.cmdReset.Click += new EventHandler(this.cmdReset_Click);
      this.DataGridRicerca.ItemCreated += new DataGridItemEventHandler(this.DataGridRicerca_ItemCreated);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.Ricerca();
    }

    private void Ricerca()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      int count1 = ((CollectionBase) CollezioneControlli).Count;
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_NOME_DOC");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(count1);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.TxtNomeDoc).Text);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_DATA_INVIO");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(count1);
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Value(((TextBox) this.CalendarPicker1.Datazione).Text == "" ? (object) "" : (object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_USERS");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(count1);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Value((object) ((TextBox) this.txtUtente).Text);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_TIPO_DOC");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(count1);
      if (((ListControl) this.cmbsTipoDoc).SelectedValue.ToUpper() == "TUTTI")
        ((ParameterObject) sObject4).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject4).set_Value((object) ((ListControl) this.cmbsTipoDoc).SelectedValue);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_CODICE");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(count1);
      ((ParameterObject) sObject5).set_Size(50);
      ((ParameterObject) sObject5).set_Value((object) ((TextBox) this.TxtCodice).Text);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_ID_WR");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(count1);
      ((ParameterObject) sObject6).set_Size(50);
      ((ParameterObject) sObject6).set_Value((object) (((TextBox) this.TxtWr_id).Text == "" ? 0 : int.Parse(((TextBox) this.TxtWr_id).Text)));
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_ID_BL");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(50);
      ((ParameterObject) sObject7).set_Index(count1);
      ((ParameterObject) sObject7).set_Value((object) (this.RicercaModulo1._txthidbl.Value == "" ? 0 : int.Parse(this.RicercaModulo1._txthidbl.Value)));
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_progetto");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(count1);
      ((ParameterObject) sObject8).set_Size(10);
      string s = "";
      if (this.Request["VarApp"] != null)
        s = this.Request["VarApp"];
      if (s == "")
        ((ParameterObject) sObject8).set_Value((object) 0);
      else
        ((ParameterObject) sObject8).set_Value((object) int.Parse(s));
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_username");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(count1);
      ((ParameterObject) sObject9).set_Size(30);
      ((ParameterObject) sObject9).set_Value((object) HttpContext.Current.User.Identity.Name);
      CollezioneControlli.Add(sObject9);
      int count2 = this.Traccia_doc.GetCount(CollezioneControlli);
      this.GridTitle1.NumeroRecords = count2.ToString();
      if (count2 % this.DataGridRicerca.PageSize == 0)
      {
        int num1 = count2 / this.DataGridRicerca.PageSize;
      }
      else
      {
        int num2 = count2 / this.DataGridRicerca.PageSize;
      }
      this.DataGridRicerca.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      if (int.Parse(this.GridTitle1.NumeroRecords) == 0)
      {
        this.DataGridRicerca.CurrentPageIndex = 0;
        this.GridTitle1.DescriptionTitle = "Nessun dato trovato.";
      }
      else
        this.GridTitle1.DescriptionTitle = "";
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("pageindex");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(count1);
      ((ParameterObject) sObject10).set_Value((object) (this.DataGridRicerca.CurrentPageIndex + 1));
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("pagesize");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(count1);
      ((ParameterObject) sObject11).set_Value((object) this.DataGridRicerca.PageSize);
      CollezioneControlli.Add(sObject11);
      this.DataGridRicerca.DataSource = (object) this.Traccia_doc.GetSfoglia(CollezioneControlli).Copy().Tables[0];
      this.DataGridRicerca.DataBind();
    }

    private void cmdReset_Click(object sender, EventArgs e)
    {
      string str = "";
      if (this.Request["VarApp"] != null)
        str = "&VarApp=" + this.Request["VarApp"];
      this.Response.Redirect("SfogliaDoc.aspx?Fun=" + this.ViewState["FunId"] + str);
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (e.CommandName == "Download")
      {
        string str1;
        if (e.Item.Cells[7].Text == "SGA" || e.Item.Cells[7].Text == "DIE")
        {
          string[] strArray1 = e.CommandArgument.ToString().Split(',');
          string[] strArray2 = strArray1[1].Split(' ');
          string str2 = this.Server.MapPath("../Doc_DB") + "\\" + strArray2[1] + "\\" + strArray1[0] + "\\" + strArray1[1];
          string[] strArray3 = Path.GetFileName(str2).Split(' ');
          str1 = this.Server.MapPath("../Doc_DB") + "\\" + strArray3[1] + "\\" + strArray1[0] + "\\" + strArray3[0] + " " + strArray3[1] + " " + strArray3[2] + ".rtf";
          this.Response.Clear();
          this.Response.ContentType = "application/rtf";
          if (File.Exists(str1))
            File.Delete(str1);
          File.Copy(str2, str1);
        }
        else
        {
          str1 = (this.Server.MapPath("../Doc_DB") + "\\" + e.Item.Cells[3].Text.Trim() + "\\" + e.Item.Cells[6].Text.Trim()).Replace(".xls", ".zip");
          this.Response.Clear();
          this.Response.ContentType = "application/zip";
        }
        this.Response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFileName(str1));
        this.Response.WriteFile(str1);
        this.Response.End();
      }
      if (!(e.CommandName == "Invio"))
        return;
      string[] strArray4;
      string str3;
      if (e.Item.Cells[7].Text == "SGA" || e.Item.Cells[7].Text == "DIE")
      {
        strArray4 = e.CommandArgument.ToString().Split(',');
        string[] strArray1 = strArray4[1].Split(' ');
        string str1 = this.Server.MapPath("../Doc_DB") + "\\" + strArray1[1] + "\\" + strArray4[0] + "\\" + strArray4[1];
        string[] strArray2 = Path.GetFileName(str1).Split(' ');
        str3 = this.Server.MapPath("../Doc_DB") + "\\" + strArray2[1] + "\\" + strArray4[0] + "\\" + strArray2[0] + " " + strArray2[1] + " " + strArray2[2] + ".rtf";
        if (File.Exists(str3))
          File.Delete(str3);
        File.Copy(str1, str3);
      }
      else
      {
        strArray4 = e.CommandArgument.ToString().Split(',');
        str3 = this.Server.MapPath("../Doc_DB") + "\\" + e.Item.Cells[3].Text.Trim() + "\\" + e.Item.Cells[6].Text.Trim();
      }
      MailSend mailSend = new MailSend();
      DocType TipoDoc = !(e.Item.Cells[7].Text == "SGA") ? (!(e.Item.Cells[7].Text == "DIE") ? DocType.XLS : DocType.DIE) : DocType.SGA;
      string str4;
      if (TipoDoc == DocType.XLS)
      {
        str4 = str3;
      }
      else
      {
        str4 = Path.GetDirectoryName(str3) + "\\" + Path.GetFileNameWithoutExtension(str3) + ".zip";
        if (File.Exists(str4))
          File.Delete(str4);
        ZipOutputStream zipOutputStream = new ZipOutputStream((Stream) File.Create(str4));
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
      }
      if (e.Item.Cells[7].Text == "SGA" || e.Item.Cells[7].Text == "DIE")
        mailSend.SendMail(str4, int.Parse(strArray4[0]), TipoDoc);
      else
        mailSend.SendMailXls(str4, TipoDoc, Convert.ToInt32(e.Item.Cells[10].Text));
    }

    private void DataGridRicerca_ItemCreated(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.FindControl("btSend")).Attributes.Add("onclick", "return confirm('Reinvio del documento selezionato?');");
      ((Image) e.Item.FindControl("btScarica")).ImageUrl = "../images/w.gif";
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      if (e.Item.Cells[7].Text == "SGA" || e.Item.Cells[7].Text == "DIE")
      {
        string[] strArray = e.Item.Cells[6].Text.Split(' ');
        e.Item.Cells[6].Text = strArray[0] + " " + strArray[1] + " " + strArray[2] + ".rtf";
      }
      if (!(e.Item.Cells[7].Text == "XLS"))
        return;
      ((Image) e.Item.FindControl("btScarica")).ImageUrl = "../images/Excel.gif";
    }
  }
}
