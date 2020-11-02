// Decompiled with JetBrains decompiler
// Type: TheSite.AnagrafeImpianti.ServiceDettail
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.WebControls;

namespace TheSite.AnagrafeImpianti
{
  public class ServiceDettail : Page
  {
    protected PageTitle PageTitle1;
    protected DataPanel DataPanelDatiGenerali;
    protected DataPanel DataPanelDocImage;
    protected DataPanel PanelElaboratiTecnici;
    protected Repeater Repeaterricfotografica;
    protected Repeater RepeaterDatigerali;
    protected Repeater RepeaterDiagnosiEnergetica;
    protected Repeater RepeaterElaboratiTecnici;
    protected Repeater RepeaterCertificazioni;
    protected Repeater RepeaterApparecchiature;
    protected HtmlInputButton BtnPopUp;
    private int _bl_id;
    private int _servizio_id;
    private string _servizio = string.Empty;
    private string _tipologia;

    private void Page_Load(object sender, EventArgs e)
    {
      this.PageTitle1.VisibleLogut = false;
      if (this.IsPostBack || this.Request.QueryString["bl_id"] == null || this.Request.QueryString["servizio_id"] == null)
        return;
      this.bl_id = int.Parse(this.Request.QueryString["bl_id"]);
      this.servizio_id = int.Parse(this.Request.QueryString["servizio_id"]);
      this.BtnPopUp.Attributes.Add("onclick", "OpenPopUp('" + (this.bl_id.ToString() + "&servizio_id=" + (object) this.servizio_id + "&chiamante=me") + "');");
      if (this.Request.QueryString["chiamante"] != null)
        this.BtnPopUp.Attributes.Add("style", "DISPLAY: none");
      this.DatiGenerali();
      this.DiagnosiEnergetica();
      this.RicognizioneFotografica();
      this.ElaboratiTecnici();
      this.Certificazioni();
      this.Apparecchiature();
    }

    public int bl_id
    {
      get => this._bl_id;
      set => this._bl_id = value;
    }

    public int servizio_id
    {
      get => this._servizio_id;
      set => this._servizio_id = value;
    }

    private void DatiGenerali()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      this.RepeaterDatigerali.DataSource = (object) new SeviceDettail(this.Context.User.Identity.Name).GetSingleData(this.bl_id);
      this.RepeaterDatigerali.DataBind();
    }

    private void DiagnosiEnergetica()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      this.RepeaterDiagnosiEnergetica.DataSource = (object) new SeviceDettail(this.Context.User.Identity.Name).GetDiagnosiEnergetica(this.bl_id);
      this.RepeaterDiagnosiEnergetica.DataBind();
    }

    private void RicognizioneFotografica()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      this.Repeaterricfotografica.DataSource = (object) new SeviceDettail(this.Context.User.Identity.Name).GetRicognizioneFotografica(this.bl_id);
      this.Repeaterricfotografica.DataBind();
    }

    private void ElaboratiTecnici()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      this.RepeaterElaboratiTecnici.DataSource = (object) new SeviceDettail(this.Context.User.Identity.Name).GetElaboratiTecnici(this.bl_id, this.servizio_id);
      this.RepeaterElaboratiTecnici.DataBind();
    }

    private void Certificazioni()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      this.RepeaterCertificazioni.DataSource = (object) new SeviceDettail(this.Context.User.Identity.Name).GetCertificazioni(this.bl_id);
      this.RepeaterCertificazioni.DataBind();
    }

    private void Apparecchiature()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      this.RepeaterApparecchiature.DataSource = (object) new SeviceDettail(this.Context.User.Identity.Name).GetApparecchiature(this.bl_id, this.servizio_id);
      this.RepeaterApparecchiature.DataBind();
    }

    public string TitleService(string servizio)
    {
      if (!(this._servizio != servizio))
        return string.Empty;
      this._servizio = servizio;
      return this._servizio;
    }

    protected string TipoFile(object f1, object f2, object f3)
    {
      if (f1 != null && f1 != DBNull.Value)
        return f1.ToString();
      if (f2 != null && f2 != DBNull.Value)
        return f2.ToString();
      return f3 != null && f3 != DBNull.Value ? f3.ToString() : "";
    }

    protected void RepeaterElaboratiTecnici_ItemDataBound(object Sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      if (DataBinder.Eval(e.Item.DataItem, "var_file_pdf") != DBNull.Value && DataBinder.Eval(e.Item.DataItem, "var_file_pdf").ToString() != "")
      {
        HtmlAnchor htmlAnchor = new HtmlAnchor();
        htmlAnchor.HRef = "javascript:opendoc('var_afm_dwgs_dwg_name=" + DataBinder.Eval(e.Item.DataItem, "var_file_name") + ".pdf');";
        htmlAnchor.InnerText = DataBinder.Eval(e.Item.DataItem, "var_file_name").ToString();
        e.Item.FindControl("placercontrols").Controls.Add((Control) htmlAnchor);
      }
      else
      {
        PlaceHolder control = (PlaceHolder) e.Item.FindControl("placercontrols");
        control.Controls.Add((Control) new Literal()
        {
          Text = DataBinder.Eval(e.Item.DataItem, "var_file_name").ToString()
        });
        if (DataBinder.Eval(e.Item.DataItem, "var_file_dwf") != DBNull.Value && DataBinder.Eval(e.Item.DataItem, "var_file_dwf").ToString() != "")
        {
          HtmlImage htmlImage = new HtmlImage();
          htmlImage.Src = "../Images/dwf.jpg";
          htmlImage.Border = 0;
          htmlImage.Alt = "Visualizza Schema";
          HtmlAnchor htmlAnchor = new HtmlAnchor();
          htmlAnchor.HRef = "javascript:opendoc('var_afm_dwgs_dwg_name=" + DataBinder.Eval(e.Item.DataItem, "var_file_name") + ".dwf');";
          htmlAnchor.Controls.Add((Control) htmlImage);
          control.Controls.Add((Control) htmlAnchor);
        }
        if (DataBinder.Eval(e.Item.DataItem, "var_file_jpg") == DBNull.Value || !(DataBinder.Eval(e.Item.DataItem, "var_file_jpg").ToString() != ""))
          return;
        HtmlImage htmlImage1 = new HtmlImage();
        htmlImage1.Src = "../Images/img.gif";
        htmlImage1.Border = 0;
        htmlImage1.Alt = "Visualizza Immagine";
        HtmlAnchor htmlAnchor1 = new HtmlAnchor();
        htmlAnchor1.HRef = "javascript:opendoc('var_afm_dwgs_dwg_name=" + DataBinder.Eval(e.Item.DataItem, "var_file_name") + ".jpg');";
        htmlAnchor1.Controls.Add((Control) htmlImage1);
        control.Controls.Add((Control) htmlAnchor1);
      }
    }

    protected void RepeaterCertificazioni_ItemDataBound(object Sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      DataRowView dataItem = (DataRowView) e.Item.DataItem;
      TableRow tableRow = new TableRow();
      TableCell tableCell1 = new TableCell();
      TableCell tableCell2 = new TableCell();
      TableCell tableCell3 = new TableCell();
      TableCell tableCell4 = new TableCell();
      if (dataItem["ext"].ToString().ToUpper() == "PDF")
      {
        HtmlAnchor htmlAnchor = new HtmlAnchor();
        htmlAnchor.HRef = "javascript:opendoc('var_afm_dwgs_dwg_name=" + dataItem["var_nome_doc"] + "');";
        htmlAnchor.InnerText = dataItem["var_nome_doc"].ToString();
        tableCell1.Text = dataItem["var_servizio"].ToString();
        tableCell2.Controls.Add((Control) htmlAnchor);
        tableCell3.Text = "";
        tableCell4.Text = dataItem["var_descrizione"].ToString();
        tableRow.Controls.Add((Control) tableCell1);
        tableRow.Controls.Add((Control) tableCell2);
        tableRow.Controls.Add((Control) tableCell3);
        tableRow.Controls.Add((Control) tableCell4);
        e.Item.Controls.Add((Control) tableRow);
      }
      else
      {
        if (!(this._tipologia != dataItem["var_tipologia"].ToString()))
          return;
        this._tipologia = dataItem["var_tipologia"].ToString();
        HtmlImage htmlImage = new HtmlImage();
        htmlImage.Src = "../Images/ico_info.gif";
        htmlImage.Border = 0;
        htmlImage.Alt = "Visualizza Immagine";
        HtmlAnchor htmlAnchor = new HtmlAnchor();
        htmlAnchor.HRef = "javascript:opendoc1('bl_id=" + this.bl_id.ToString() + "&doc_id_servizio=" + dataItem["var_id_servizio"].ToString() + "&categoria=" + dataItem["var_categoria"].ToString() + "');";
        htmlAnchor.Controls.Add((Control) htmlImage);
        tableCell1.Text = dataItem["var_servizio"].ToString();
        tableCell2.Attributes.Add("align", "center");
        tableCell2.Controls.Add((Control) htmlAnchor);
        tableCell3.Text = "Raccolta Fotografica " + dataItem["var_tipologia"].ToString();
        tableCell4.Text = dataItem["var_descrizione"].ToString();
        tableRow.Controls.Add((Control) tableCell1);
        tableRow.Controls.Add((Control) tableCell2);
        tableRow.Controls.Add((Control) tableCell3);
        tableRow.Controls.Add((Control) tableCell4);
        e.Item.Controls.Add((Control) tableRow);
      }
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.Load += new EventHandler(this.Page_Load);
      this.RepeaterElaboratiTecnici.ItemDataBound += new RepeaterItemEventHandler(this.RepeaterElaboratiTecnici_ItemDataBound);
      this.RepeaterCertificazioni.ItemDataBound += new RepeaterItemEventHandler(this.RepeaterCertificazioni_ItemDataBound);
    }
  }
}
