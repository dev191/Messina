// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.Buildings
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class Buildings : Page
  {
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    protected PageTitle PageTitle1;
    private clMyCollection _myColl = new clMyCollection();
    protected S_TextBox txtsBL_ID;
    protected S_TextBox txtsName;
    protected S_TextBox txtsIndirizzo;
    protected S_TextBox txtsReferente;
    protected S_TextBox txtsComune;
    protected S_Button btnsRicerca;
    protected DataPanel PanelRicerca;
    protected S_Button BtnReset;
    protected Button btnEsporta;
    protected Button Button1;
    protected Label lbMessage;
    protected S_ComboBox CmbProgetto;
    private EditBuilding _fp;

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Gestione/EditBuilding.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId;
      ((Control) this.GridTitle1.hplsNuovo).Visible = siteModule.IsEditable;
      this.DataGridRicerca.Columns[1].Visible = true;
      this.DataGridRicerca.Columns[2].Visible = siteModule.IsEditable;
      Buildings.FunId = siteModule.ModuleId;
      Buildings.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      ((WebControl) this.txtsBL_ID).Attributes.Add("onpaste", "return false;");
      if (this.Page.IsPostBack)
        return;
      this.BindProgetti();
      if (!(this.Context.Handler is EditBuilding))
        return;
      this._fp = (EditBuilding) this.Context.Handler;
      if (this._fp == null)
        return;
      this._myColl = this._fp._Contenitore;
      this._myColl.SetValues(this.Page.Controls);
      this.Ricerca();
    }

    private void BindProgetti()
    {
      ((ListControl) this.CmbProgetto).Items.Clear();
      DataSet data = new Progetti().GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.CmbProgetto).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "descrizione", "id_progetto", "- Selezionare un Progetto -", "0");
        ((ListControl) this.CmbProgetto).DataTextField = "descrizione";
        ((ListControl) this.CmbProgetto).DataValueField = "id_progetto";
        ((Control) this.CmbProgetto).DataBind();
      }
      else
        ((ListControl) this.CmbProgetto).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Progetto  -", "-1"));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.Button1.Click += new EventHandler(this.Button1_Click);
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.btnEsporta.Click += new EventHandler(this.btnEsporta_Click);
      ((Button) this.BtnReset).Click += new EventHandler(this.BtnReset_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound_1);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.Ricerca();
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      TheSite.Classi.ClassiAnagrafiche.Ditte ditte = new TheSite.Classi.ClassiAnagrafiche.Ditte();
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      if (e.Item.Cells[5].Text.Trim() == "()")
        e.Item.Cells[5].Text = "";
      int idditta = int.Parse(e.Item.Cells[0].Text);
      DataSet dataSet = ditte.GetServiziDitta(idditta).Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      string str1 = "";
      foreach (DataRow row in (InternalDataCollectionBase) dataSet.Tables[0].Rows)
        str1 = str1 + row["Descrizione"] + "\r";
      string str2 = str1.Substring(0, str1.Length - 1);
      e.Item.ToolTip = str2;
    }

    private DataSet GetDataBuilding()
    {
      TheSite.Classi.ClassiAnagrafiche.Buildings buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
      this.txtsBL_ID.set_DBDefaultValue((object) "%");
      this.txtsName.set_DBDefaultValue((object) "%");
      this.txtsIndirizzo.set_DBDefaultValue((object) "%");
      this.txtsReferente.set_DBDefaultValue((object) "%");
      this.txtsComune.set_DBDefaultValue((object) "%");
      ((TextBox) this.txtsBL_ID).Text = ((TextBox) this.txtsBL_ID).Text.Trim();
      ((TextBox) this.txtsName).Text = ((TextBox) this.txtsName).Text.Trim();
      ((TextBox) this.txtsIndirizzo).Text = ((TextBox) this.txtsIndirizzo).Text.Trim();
      ((TextBox) this.txtsReferente).Text = ((TextBox) this.txtsReferente).Text.Trim();
      ((TextBox) this.txtsComune).Text = ((TextBox) this.txtsComune).Text.Trim();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) ((Control) this.PanelRicerca).Controls);
      return buildings.GetData(CollezioneControlli).Copy();
    }

    private void Ricerca()
    {
      DataSet dataBuilding = this.GetDataBuilding();
      this.DataGridRicerca.DataSource = (object) dataBuilding.Tables[0];
      if (dataBuilding.Tables[0].Rows.Count == 0)
      {
        this.DataGridRicerca.CurrentPageIndex = 0;
      }
      else
      {
        int num = 0;
        if (dataBuilding.Tables[0].Rows.Count % this.DataGridRicerca.PageSize > 0)
          ++num;
        if (this.DataGridRicerca.PageCount != Convert.ToInt32(dataBuilding.Tables[0].Rows.Count / this.DataGridRicerca.PageSize + num))
          this.DataGridRicerca.CurrentPageIndex = 0;
      }
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataBuilding.Tables[0].Rows.Count.ToString();
    }

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString());
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }

    private void DataGridRicerca_ItemDataBound_1(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[1].FindControl("ImgBtnDettaglio")).Attributes.Add("title", "Visualizza");
      ((WebControl) e.Item.Cells[1].FindControl("ImgBtnEdit")).Attributes.Add("title", "Modifica");
    }

    private void BtnReset_Click(object sender, EventArgs e) => this.Response.Redirect("Buildings.aspx?FunId=" + (object) Buildings.FunId);

    private void btnEsporta_Click(object sender, EventArgs e)
    {
      DataSet dataBuilding = this.GetDataBuilding();
      Export export = new Export();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = dataBuilding.Tables[0].Copy();
      if (dataTable2.Rows.Count != 0)
      {
        export.ExportDetails(dataTable2, (Export.ExportFormat) 2, "exp.xls");
      }
      else
      {
        string script = "<script language=JavaScript>alert('Nessun elemento da esportare');" + "<" + "/" + "script>";
        if (this.IsClientScriptBlockRegistered("clientScriptexp"))
          return;
        this.RegisterStartupScript("clientScriptexp", script);
      }
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      if (new TheSite.Classi.ClassiAnagrafiche.Buildings().UpdateAllFl() == 0)
      {
        this.lbMessage.Text = "ERRORE nel calcolo delle superfici.";
        this.lbMessage.ForeColor = Color.Red;
      }
      else
        this.lbMessage.Text = "Calcolo delle superfici eseguito con SUCCESSO.";
    }
  }
}
