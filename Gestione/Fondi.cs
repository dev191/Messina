// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.Fondi
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class Fondi : Page
  {
    protected S_Button btnsRicerca;
    protected DataPanel PanelRicerca;
    protected DataGrid DataGridRicerca;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    private clMyCollection _myColl = new clMyCollection();
    private EditFondi _fp;
    protected TextBox txtCodiceFondo;
    protected S_Button BtnReset;
    protected DropDownList DrMeseini;
    protected DropDownList DrAnnoIni;
    protected DropDownList DrMesefine;
    protected DropDownList DrAnnofine;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Gestione/EditFondi.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId;
      ((Control) this.GridTitle1.hplsNuovo).Visible = siteModule.IsEditable;
      this.DataGridRicerca.Columns[1].Visible = true;
      this.DataGridRicerca.Columns[2].Visible = siteModule.IsEditable;
      Fondi.FunId = siteModule.ModuleId;
      Fondi.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      if (this.Page.IsPostBack)
        return;
      this.LoadMese();
      this.LoadAnno();
      if (!(this.Context.Handler is EditFondi))
        return;
      this._fp = (EditFondi) this.Context.Handler;
      if (this._fp == null)
        return;
      this._myColl = this._fp._Contenitore;
      this._myColl.SetValues(this.Page.Controls);
      this.Ricerca();
    }

    private void LoadMese()
    {
      this.DrMesefine.Items.Add(new ListItem("- Nessun Mese -", "0"));
      this.DrMeseini.Items.Add(new ListItem("- Nessun Mese -", "0"));
      ArrayList arrayList = new ArrayList();
      arrayList.Add((object) new ListItem("Gennaio", "1"));
      arrayList.Add((object) new ListItem("Febbraio", "2"));
      arrayList.Add((object) new ListItem("Marzo", "3"));
      arrayList.Add((object) new ListItem("Aprile", "4"));
      arrayList.Add((object) new ListItem("Maggio", "5"));
      arrayList.Add((object) new ListItem("Giugno", "6"));
      arrayList.Add((object) new ListItem("Luglio", "7"));
      arrayList.Add((object) new ListItem("Agosto", "8"));
      arrayList.Add((object) new ListItem("Settembre", "9"));
      arrayList.Add((object) new ListItem("Ottobre", "10"));
      arrayList.Add((object) new ListItem("Novembre", "11"));
      arrayList.Add((object) new ListItem("Dicembre", "12"));
      for (int index = 0; index <= arrayList.Count - 1; ++index)
      {
        this.DrMesefine.Items.Add((ListItem) arrayList[index]);
        this.DrMeseini.Items.Add((ListItem) arrayList[index]);
      }
    }

    private void LoadAnno()
    {
      this.DrAnnofine.Items.Add(new ListItem("- Nessun Anno -", "0"));
      this.DrAnnoIni.Items.Add(new ListItem("- Nessun Anno -", "0"));
      for (int index = 2000; index <= DateTime.Now.Year + 20; ++index)
      {
        this.DrAnnofine.Items.Add(new ListItem(index.ToString(), index.ToString()));
        this.DrAnnoIni.Items.Add(new ListItem(index.ToString(), index.ToString()));
      }
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      ((Button) this.BtnReset).Click += new EventHandler(this.BtnReset_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    public clMyCollection _Contenitore => this._myColl;

    private void btnsRicerca_Click(object sender, EventArgs e) => this.Ricerca();

    private void Ricerca()
    {
      TheSite.Classi.ClassiAnagrafiche.Fondi fondi = new TheSite.Classi.ClassiAnagrafiche.Fondi();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_meseini");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(10);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (this.DrMeseini.SelectedValue == "0")
        ((ParameterObject) sObject1).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject1).set_Value((object) this.DrMeseini.SelectedValue);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_mesefine");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (this.DrMesefine.SelectedValue == "0")
        ((ParameterObject) sObject2).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject2).set_Value((object) this.DrMesefine.SelectedValue);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_annoini");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (this.DrAnnoIni.SelectedValue == "0")
        ((ParameterObject) sObject3).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject3).set_Value((object) this.DrAnnoIni.SelectedValue);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_annofine");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(10);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (this.DrAnnofine.SelectedValue == "0")
        ((ParameterObject) sObject4).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject4).set_Value((object) this.DrAnnofine.SelectedValue);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_codicefondo");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Size(100);
      if (this.txtCodiceFondo.Text == "")
        ((ParameterObject) sObject5).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject5).set_Value((object) this.txtCodiceFondo.Text);
      CollezioneControlli.Add(sObject5);
      DataSet dataSet = fondi.GetData(CollezioneControlli).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      if (dataSet.Tables[0].Rows.Count == 0)
      {
        this.DataGridRicerca.CurrentPageIndex = 0;
      }
      else
      {
        int num = 0;
        if (dataSet.Tables[0].Rows.Count % this.DataGridRicerca.PageSize > 0)
          ++num;
        if (this.DataGridRicerca.PageCount != (int) Convert.ToInt16(dataSet.Tables[0].Rows.Count / this.DataGridRicerca.PageSize + num))
          this.DataGridRicerca.CurrentPageIndex = 0;
      }
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Dettaglio"))
        return;
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer(e.CommandArgument.ToString());
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton3")).Attributes.Add("title", "Visualizza");
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton2")).Attributes.Add("title", "Modifica");
      e.Item.Cells[4].ToolTip = e.Item.Cells[8].Text;
    }

    private void BtnReset_Click(object sender, EventArgs e) => this.Response.Redirect("Fondi.aspx?FunId=" + (object) Fondi.FunId);
  }
}
