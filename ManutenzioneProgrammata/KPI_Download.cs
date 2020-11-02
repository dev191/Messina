// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.KPI_Download
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
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
using TheSite.Classi.SoddCliente;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class KPI_Download : Page
  {
    protected DropDownList DrEdifici;
    protected Label lblAnno;
    protected DropDownList DropAnno;
    protected Label lblMese;
    protected DropDownList DropMese;
    protected Button cmdReset;
    protected S_Button btnsRicerca;
    protected DataGrid DataGridRicerca;
    protected TextBox txtNomeDoc;
    protected Label lblMessage;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    private KPI _kpi = new KPI();
    protected DropDownList DropTipoDoc;
    public string HelpLink = "";

    private void Page_Load(object sender, EventArgs e)
    {
      this.HelpLink = ((SiteModule) HttpContext.Current.Items[(object) "SiteModule"]).HelpLink;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      if (!this.IsPostBack)
        this.LoadCombo();
      this.DropTipoDoc.Attributes.Add("onchange", "setvis();");
    }

    private void LoadCombo()
    {
      this.DrEdifici.DataSource = (object) this._kpi.GetEdifici(this.Context.User.Identity.Name).Tables[0];
      this.DrEdifici.DataTextField = "Denominazione";
      this.DrEdifici.DataValueField = "id";
      this.DrEdifici.DataBind();
      this.DrEdifici.Items.Add(new ListItem("- Seleziona Edificio -", "0")
      {
        Selected = true
      });
      for (int index = 2008; index <= 2020; ++index)
        this.DropAnno.Items.Add(new ListItem(index.ToString(), index.ToString()));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
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
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_nome_file");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) this.txtNomeDoc.Text);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_id_bl");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) this.DrEdifici.SelectedValue);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_anno");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) this.DropAnno.SelectedValue);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_mese");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Value((object) this.DropMese.SelectedValue);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_tipodoc");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Value((object) this.DropTipoDoc.SelectedValue);
      CollezioneControlli.Add(sObject5);
      DataSet data = this._kpi.GetData(CollezioneControlli);
      this.DataGridRicerca.DataSource = (object) data.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = data.Tables[0].Rows.Count.ToString();
    }

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Download"))
        return;
      string str;
      if (this.DropTipoDoc.SelectedValue == "1")
      {
        str = Path.Combine(Path.Combine(this.Server.MapPath("../Doc_DB"), "KPI\\KPI Vod\\KPI Proposti"), Path.GetFileNameWithoutExtension(e.CommandArgument.ToString()) + ".zip");
        this.Response.Clear();
        this.Response.ContentType = "application/zip";
        this.Response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFileName(str));
      }
      else
      {
        str = Path.Combine(Path.Combine(this.Server.MapPath("../Doc_DB"), "KPI\\KPI Vod\\KPI Eseguiti"), e.CommandArgument.ToString());
        this.Response.Clear();
        this.Response.ContentType = "application/xls";
        this.Response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFileNameWithoutExtension(str) + ".xls");
      }
      this.Response.WriteFile(str);
      this.Response.End();
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      try
      {
        this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
        this.Ricerca();
      }
      catch (HttpException ex)
      {
        Console.WriteLine(ex.Message);
        this.DataGridRicerca.CurrentPageIndex = 0;
        this.Ricerca();
      }
    }
  }
}
