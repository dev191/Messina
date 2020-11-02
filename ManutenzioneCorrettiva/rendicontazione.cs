// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorrettiva.rendicontazione
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ICSharpCode.SharpZipLib.Zip;
using LibConsCont;
using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi.ManProgrammata;

namespace TheSite.ManutenzioneCorrettiva
{
  public class rendicontazione : Page
  {
    protected DropDownList DrEdifici;
    protected DropDownList DropMese;
    protected Label lblAnno;
    protected DropDownList DropAnno;
    protected Button BtGenera;
    protected Button BtSalva;
    protected Label lblMessage;
    protected DropDownList DrTrimestre;

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
      this.DrEdifici.DataValueField = "idedif";
      this.DrEdifici.DataBind();
      for (int index = 2008; index <= 2028; ++index)
        this.DropAnno.Items.Add(new ListItem(index.ToString(), index.ToString()));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.BtGenera.Click += new EventHandler(this.BtGenera_Click);
      this.BtSalva.Click += new EventHandler(this.BtSalva_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void BtGenera_Click(object sender, EventArgs e)
    {
      this.lblMessage.Text = "";
      int num1 = int.Parse(this.DropAnno.SelectedValue);
      int num2 = int.Parse(this.DrTrimestre.SelectedValue);
      string appSetting = ConfigurationSettings.AppSettings["ConnectionString"];
      LbConsExcel lbConsExcel = new LbConsExcel();
      try
      {
        lbConsExcel.set_StrCon(appSetting);
        lbConsExcel.set_PathFileoutput(this.Server.MapPath("../Doc_DB/TempFile"));
        lbConsExcel.set_PathMasterReport(this.Server.MapPath("../MasterExcel"));
        if (!Directory.Exists(this.Server.MapPath("../Doc_DB/TempFile")))
          Directory.CreateDirectory(this.Server.MapPath("../Doc_DB/TempFile"));
        foreach (string directory in Directory.GetDirectories(this.Server.MapPath("../Doc_DB/TempFile")))
          Directory.Delete(directory, true);
        string[] strArray1 = this.DrEdifici.SelectedValue.Split('-');
        string[] strArray2 = this.DrEdifici.Items[this.DrEdifici.SelectedIndex].Text.Split(' ');
        int int32_1 = Convert.ToInt32(strArray1[1].Trim());
        int int32_2 = Convert.ToInt32(strArray1[0].Trim());
        string str1 = strArray2[0].Trim();
        lbConsExcel.GenerateReport(int32_1, int32_2, str1, num1, num2);
        string str2 = "0" + num2.ToString() + "/" + Convert.ToString(num1).Substring(2);
        this.ZippaFileOutput(lbConsExcel.get_NomeFileSalvato(), lbConsExcel.get_NomeFileCompleto(), lbConsExcel.get_PercorsoFileUscitaTotale());
      }
      catch (Exception ex)
      {
        this.lblMessage.Text = "Errore nell'Invio " + ex.Message;
      }
      finally
      {
        GC.Collect();
      }
    }

    private void ZippaFileOutput(string NomeFile, string NomeFileCompleto, string pathDir)
    {
      string str = NomeFileCompleto.Remove(NomeFileCompleto.Length - 3, 3) + "zip";
      new FastZip().CreateZip(str, pathDir, true, NomeFile);
      FileInfo fileInfo = new FileInfo(str);
      this.Response.Clear();
      this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
      this.Response.Buffer = true;
      this.Response.ContentType = "application/zip";
      this.Response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(str));
      this.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
      this.Response.AddHeader("Last-Modified: ", fileInfo.LastWriteTimeUtc.ToString());
      this.Response.WriteFile(str);
      this.Response.Flush();
      this.Response.Close();
    }

    private void BtSalva_Click(object sender, EventArgs e)
    {
      this.lblMessage.Text = "";
      int num1 = int.Parse(this.DropAnno.SelectedValue);
      int num2 = int.Parse(this.DrTrimestre.SelectedValue);
      string appSetting = ConfigurationSettings.AppSettings["ConnectionString"];
      LbConsExcel lbConsExcel = new LbConsExcel();
      RegistrazioneFile registrazioneFile = new RegistrazioneFile();
      try
      {
        lbConsExcel.set_StrCon(appSetting);
        registrazioneFile.set_ConnessioneDb(appSetting);
        lbConsExcel.set_PathFileoutput(this.Server.MapPath("../Doc_DB"));
        lbConsExcel.set_PathMasterReport(this.Server.MapPath("../MasterExcel"));
        string[] strArray1 = this.DrEdifici.SelectedValue.Split('-');
        string[] strArray2 = this.DrEdifici.Items[this.DrEdifici.SelectedIndex].Text.Split(' ');
        int int32_1 = Convert.ToInt32(strArray1[1].Trim());
        int int32_2 = Convert.ToInt32(strArray1[0].Trim());
        string str1 = strArray2[0].Trim();
        lbConsExcel.GenerateReport(int32_1, int32_2, str1, num1, num2);
        string str2 = "0" + num2.ToString() + "/" + Convert.ToString(num1).Substring(2);
        string name = this.Context.User.Identity.Name;
        registrazioneFile.InsertOnDbByWeb(lbConsExcel.get_NomeFileSalvato(), name, "XLS", str2, int32_2, lbConsExcel.get_NumeroVesioneFile(), "");
        this.ZippaFileOutput2(lbConsExcel.get_NomeFileSalvato(), lbConsExcel.get_NomeFileCompleto(), lbConsExcel.get_PercorsoFileUscitaTotale());
      }
      catch (Exception ex)
      {
        this.lblMessage.Text = "Errore nell'Invio " + ex.Message;
      }
      finally
      {
        GC.Collect();
      }
    }

    private void ZippaFileOutput2(string NomeFile, string NomeFileCompleto, string pathDir)
    {
      string str = NomeFileCompleto.Remove(NomeFileCompleto.Length - 3, 3) + "zip";
      new FastZip().CreateZip(str, pathDir, true, NomeFile);
      this.Response.Clear();
      this.Response.ContentType = "application/zip";
      this.Response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFileName(str));
      this.Response.WriteFile(str);
      this.Response.Flush();
      this.Response.Close();
    }
  }
}
