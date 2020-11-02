// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorretiva.VisualPdf
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorretiva
{
  public class VisualPdf : Page
  {
    protected Literal Literal1;
    protected PageTitle PageTitle1;

    private void Page_Load(object sender, EventArgs e)
    {
      this.PageTitle1.VisibleLogut = false;
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["mittente"] == null)
        this.BindPdf();
      else
        this.BindAllegati();
    }

    private void BindPdf()
    {
      if (this.Request.QueryString["wr_id"] == null || this.Request.QueryString["path"] == null || this.Request.QueryString["name"] == null)
        return;
      string empty = string.Empty;
      string str1 = "";
      string fileName = "../Doc_DB/Correttiva/" + this.Request.QueryString["wr_id"] + "/" + this.Request.QueryString["path"] + "/" + this.Request.QueryString["name"];
      FileInfo fileInfo = new FileInfo(fileName);
      if (fileInfo.Extension.ToUpper() == ".PDF")
      {
        string str2 = "type=\"application/pdf\"";
        Literal literal1 = this.Literal1;
        string[] strArray = new string[5]
        {
          "<embed src=\"",
          fileName,
          "\" height=\"100%\" width=\"100%\" ",
          str2,
          "></embed>"
        };
        string str3;
        str1 = str3 = string.Concat(strArray);
        literal1.Text = str3;
      }
      if (!(fileInfo.Extension.ToUpper() == ".DOC"))
        return;
      this.Literal1.Text = "<script language=\"JavaScript\">location.href=\"" + fileName + "\";</script>";
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    private void BindAllegati()
    {
      string fileName = "../EQAllegati/" + this.Request.QueryString["name"];
      string str1 = string.Empty;
      FileInfo fileInfo = new FileInfo(fileName);
      if (fileInfo.Extension.ToUpper() == ".PDF")
      {
        string str2 = "type=\"application/pdf\"";
        this.Literal1.Text = "<embed src=\"" + fileName + "\" height=\"100%\" width=\"100%\" " + str2 + "></embed>";
      }
      if (!(fileInfo.Extension.ToUpper() == ".JPG") && !(fileInfo.Extension == ".JPEG") && !(fileInfo.Extension == ".GIF"))
        return;
      str1 = "type=\"image/jpg\"";
      this.Literal1.Text = "<img src='" + fileName + "'>";
    }
  }
}
