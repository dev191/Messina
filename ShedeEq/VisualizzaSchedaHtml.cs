// Decompiled with JetBrains decompiler
// Type: TheSite.ShedeEq.VisualizzaSchedaHtml
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using MyCollection;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi.SchedeEq;
using TheSite.SchemiXSD;

namespace TheSite.ShedeEq
{
  public class VisualizzaSchedaHtml : Page
  {
    protected CrystalReportViewer CryVwSchedaEq;
    protected ReportDocument crReportDocument;
    public FiltraApparecchiature fp;
    protected Button btnIndietro;
    private clMyCollection _myColl = new clMyCollection();
    protected DataGrid DataGrid1;
    private FiltraApparecchiature _fp;

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      bool FromWebCad = false;
      if (this.Request["FromWebCad"] != null)
        FromWebCad = true;
      if (!this.IsPostBack)
      {
        if (this.Context.Handler is FiltraApparecchiature)
        {
          this._fp = (FiltraApparecchiature) this.Context.Handler;
          this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
        }
        if (FromWebCad)
          this.btnIndietro.Visible = false;
      }
      this.ImpostaRpt(FromWebCad);
    }

    private void ImpostaRpt(bool FromWebCad)
    {
      string empty = string.Empty;
      NewDataSet dsTipizzato = new DatiShcedeEq(!FromWebCad ? this.recuperaEqId() : this.Request["id_eq"]).GetDsTipizzato();
      if (dsTipizzato.Tables["TblGenerale"].Rows.Count > 0)
      {
        foreach (DataRow row in (InternalDataCollectionBase) dsTipizzato.Tables["TblGenerale"].Rows)
          row["EQ_IMMAGINI_IMMAGINE"] = row["EQ_IMAGE_EQ_ASSY"] == DBNull.Value ? (object) this.GetPhoto("ImmagineNonDisponibile.jpg") : (!this.ControllaFoto(row["EQ_IMAGE_EQ_ASSY"].ToString()) ? (object) this.GetPhoto("ImmagineNonDisponibile.jpg") : (object) this.GetPhoto(row["EQ_IMAGE_EQ_ASSY"].ToString()));
      }
      this.crReportDocument.Load(this.Server.MapPath(this.Request.ApplicationPath + ConfigurationSettings.AppSettings["SourceReports"]) + "RptChedeEq_V9.rpt");
      this.crReportDocument.SetDataSource((object) dsTipizzato);
      ((CrystalReportViewerBase) this.CryVwSchedaEq).set_ReportSource((object) this.crReportDocument);
    }

    private bool ControllaFoto(string NomePhoto) => File.Exists(this.Server.MapPath("../EQImages/" + NomePhoto));

    private byte[] GetPhoto(string fileName)
    {
      string path = this.Server.MapPath(this.Request.ApplicationPath + ConfigurationSettings.AppSettings["ImmaginiEq"] + fileName);
      if (!File.Exists(path))
        return (byte[]) null;
      FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
      BinaryReader binaryReader = new BinaryReader((Stream) fileStream);
      byte[] numArray = binaryReader.ReadBytes((int) fileStream.Length);
      binaryReader.Close();
      fileStream.Close();
      return numArray;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      this.crReportDocument = new ReportDocument();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.btnIndietro.Click += new EventHandler(this.btnIndietro_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private string recuperaEqId()
    {
      string str = string.Empty;
      if (this.Session["DatiList"] != null)
      {
        IDictionaryEnumerator enumerator = ((Hashtable) this.Session["DatiList"]).GetEnumerator();
        while (enumerator.MoveNext())
          str = str + enumerator.Value + ",";
        str = str.Remove(str.Length - 1, 1);
      }
      else
      {
        this.Response.Write("Sessione Vuota");
        this.Response.End();
      }
      return str;
    }

    private void btnIndietro_Click(object sender, EventArgs e) => this.Server.Transfer("FiltraApparecchiature.aspx");
  }
}
