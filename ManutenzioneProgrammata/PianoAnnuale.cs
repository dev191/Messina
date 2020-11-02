// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.PianoAnnuale
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManProgrammata;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class PianoAnnuale : Page
  {
    protected S_ComboBox cmbsServizio;
    protected DataGrid DataGridRicerca;
    protected S_ComboBox cmbsAnno;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    protected RicercaModulo RicercaModulo1;
    public static int FunId = 0;
    protected DataPanel PanelRicerca;
    protected S_Button btnsRicerca;
    protected LinkButton lkbInfo;
    protected LinkButton lnkChiudi;
    protected Panel pnlShowInfo;
    protected Repeater rptFrequenze;
    public static string HelpLink = string.Empty;
    private clMyCollection _myColl = new clMyCollection();
    protected Panel PagePanel;
    protected Button cmdReset;
    private DettPianoAnnuale _fp;

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      PianoAnnuale.FunId = siteModule.ModuleId;
      PianoAnnuale.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindServizio);
      if (this.Page.IsPostBack)
        return;
      if (this.Request.QueryString["FunId"] != null)
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      try
      {
        this.DataGridRicerca.Visible = false;
        this.BindAnno();
        ((Control) this.GridTitle1.hplsNuovo).Visible = false;
        this.BindServizio("");
        if (!(this.Context.Handler is DettPianoAnnuale))
          return;
        this._fp = (DettPianoAnnuale) this.Context.Handler;
        if (this._fp == null)
          return;
        this._myColl = this._fp._Contenitore;
        this._myColl.SetValues(this.Page.Controls);
        this.RicercaModulo1.Ricarica();
        this.Ricerca(true);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private void BindAnno()
    {
      int year = DateTime.Now.Year;
      short num = 0;
      for (int index = year - 10; index <= year + 10; ++index)
      {
        ((ListControl) this.cmbsAnno).Items.Add(index.ToString());
        if (year == index)
          ((ListControl) this.cmbsAnno).Items[(int) num].Selected = true;
        ++num;
      }
    }

    private void BindServizio(string CodEdificio)
    {
      this.DataGridRicerca.Visible = false;
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      Servizi servizi = new Servizi(this.Context.User.Identity.Name);
      DataSet data;
      if (CodEdificio != "")
      {
        S_Object sObject1 = new S_Object();
        ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
        ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
        ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject1).set_Index(0);
        ((ParameterObject) sObject1).set_Value((object) CodEdificio);
        ((ParameterObject) sObject1).set_Size(8);
        S_Object sObject2 = new S_Object();
        ((ParameterObject) sObject2).set_ParameterName("p_ID_Servizio");
        ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
        ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
        ((ParameterObject) sObject2).set_Index(1);
        ((ParameterObject) sObject2).set_Value((object) 0);
        CollezioneControlli.Add(sObject1);
        CollezioneControlli.Add(sObject2);
        data = servizi.GetData(CollezioneControlli);
      }
      else
        data = servizi.GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", string.Empty));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsAnno).SelectedIndexChanged += new EventHandler(this.cmbsAnno_SelectedIndexChanged);
      ((ListControl) this.cmbsServizio).SelectedIndexChanged += new EventHandler(this.cmbsServizio_SelectedIndexChanged);
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.cmdReset.Click += new EventHandler(this.cmdReset_Click);
      this.lkbInfo.Click += new EventHandler(this.lkbInfo_Click);
      this.lnkChiudi.Click += new EventHandler(this.lnkChiudi_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.Ricerca(true);
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      if (e.Item.Cells[3].Text.Trim().Length > 20)
      {
        string str = e.Item.Cells[3].Text.Trim().Substring(0, 18) + "...";
        e.Item.Cells[3].ToolTip = e.Item.Cells[3].Text;
        e.Item.Cells[3].Text = str;
      }
      if (e.Item.Cells[4].Text.Trim().Length > 20)
      {
        string str = e.Item.Cells[4].Text.Trim().Substring(0, 18) + "...";
        e.Item.Cells[4].ToolTip = e.Item.Cells[4].Text;
        e.Item.Cells[4].Text = str;
      }
      if (e.Item.Cells[5].Text.Trim().Length > 10)
      {
        string str = e.Item.Cells[5].Text.Trim().Substring(0, 10) + "...";
        e.Item.Cells[5].ToolTip = e.Item.Cells[5].Text;
        e.Item.Cells[5].Text = str.ToUpper();
      }
      for (int index = 6; index <= 17; ++index)
      {
        string str = this.Colora(Convert.ToInt32(e.Item.Cells[index].Text));
        int int16_1 = (int) Convert.ToInt16(str.Substring(0, 2), 16);
        int int16_2 = (int) Convert.ToInt16(str.Substring(2, 2), 16);
        int int16_3 = (int) Convert.ToInt16(str.Substring(4, 2), 16);
        e.Item.Cells[index].BackColor = Color.FromArgb(int16_1, int16_2, int16_3);
        e.Item.Cells[index].BorderColor = Color.Black;
        e.Item.Cells[index].BorderWidth = (Unit) 1;
        e.Item.Cells[index].ForeColor = Color.Black;
      }
    }

    public string Colora(int Mese) => Mese >= 10 ? (Mese >= 20 ? (Mese >= 30 ? (Mese >= 40 ? (Mese >= 50 ? (Mese >= 60 ? (Mese >= 70 ? "800000" : "c00000") : "000080") : "0000ff") : "008000") : "00ff00") : "808080") : "ffffff";

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca(false);
    }

    private void Ricerca(bool reset)
    {
      Planner planner = new Planner(this.Context.User.Identity.Name);
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_campus");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(2);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.RicercaModulo1.TxtRicerca).Text);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_Anno");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(3);
      ((ParameterObject) sObject3).set_Size(4);
      ((ParameterObject) sObject3).set_Value((object) ((ListControl) this.cmbsAnno).SelectedItem.ToString());
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_ID_Servizio");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("pageindex");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(16);
      ((ParameterObject) sObject5).set_Value((object) (this.DataGridRicerca.CurrentPageIndex + 1));
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("pagesize");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(17);
      ((ParameterObject) sObject6).set_Value((object) this.DataGridRicerca.PageSize);
      CollezioneControlli.Add(sObject6);
      DataSet dataSet = planner.GetData(CollezioneControlli).Copy();
      if (reset)
      {
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 1);
        this.GridTitle1.NumeroRecords = planner.GetDataCount(CollezioneControlli).ToString();
      }
      this.DataGridRicerca.Visible = true;
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.DataGridRicerca.DataBind();
    }

    private void lkbInfo_Click(object sender, EventArgs e)
    {
      Planner planner = new Planner();
      this.pnlShowInfo.Visible = true;
      this.rptFrequenze.DataSource = (object) planner.GetFrequenze();
      this.rptFrequenze.DataBind();
    }

    private void lnkChiudi_Click(object sender, EventArgs e) => this.pnlShowInfo.Visible = false;

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString());
    }

    private void cmbsAnno_SelectedIndexChanged(object sender, EventArgs e) => this.DataGridRicerca.Visible = false;

    private void cmbsServizio_SelectedIndexChanged(object sender, EventArgs e) => this.DataGridRicerca.Visible = false;

    private void cmdReset_Click(object sender, EventArgs e) => this.Response.Redirect("PianoAnnuale.aspx?FunID=" + this.ViewState["FunId"]);
  }
}
