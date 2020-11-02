// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.KPIVod_Upload
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;

namespace TheSite.ManutenzioneProgrammata
{
  public class KPIVod_Upload : Page
  {
    protected Button BtInvia;
    protected Label lblMessage;
    protected HtmlInputFile UploadFile;
    public string HelpLink = "";

    private void Page_Load(object sender, EventArgs e)
    {
      this.HelpLink = ((SiteModule) HttpContext.Current.Items[(object) "SiteModule"]).HelpLink;
      this.UploadFile.Attributes.Add("onchange", "return checkFileExtension(this);");
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

    private void BtInvia_Click(object sender, EventArgs e) => this.SendDoc();

    private void SendDoc()
    {
      if (this.UploadFile.PostedFile == null || !(this.UploadFile.PostedFile.FileName != ""))
        return;
      string str = Path.Combine(this.Server.MapPath("../Doc_Db"), "KPI\\KPI Vod\\KPI Eseguiti");
      if (!Directory.Exists(str))
        Directory.CreateDirectory(str);
      string filename = Path.Combine(str, Path.GetFileName(this.UploadFile.PostedFile.FileName));
      this.UploadFile.PostedFile.SaveAs(filename);
      string appSetting = ConfigurationSettings.AppSettings["ConnectionString"];
      new KPIVod.KPIVod(filename, this.Context.User.Identity.Name, appSetting).ReadDocument();
      string script = "<script language=JavaScript>alert('Il file è stato elaborato correttamente.');</script>";
      if (this.IsClientScriptBlockRegistered("clientScriptexp"))
        return;
      this.RegisterStartupScript("clientScriptexp", script);
    }
  }
}
