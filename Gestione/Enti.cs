// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.Enti
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
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class Enti : Page
  {
    protected DataGrid DataGridRicerca;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    private clMyCollection _myColl = new clMyCollection();
    protected S_TextBox txtsIndirizzo;
    protected S_TextBox txtsComune;
    protected S_TextBox txtsTelefono;
    protected S_Button btnsRicerca;
    protected DataPanel PanelRicerca;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    protected S_ComboBox cmbsDescrizione;
    protected S_TextBox txtsPartitaIva;
    protected S_TextBox txtsProvincia;
    protected S_TextBox txtsRagioneSociale;
    protected S_TextBox txtsEmail;
    protected S_TextBox txtsReferente;
    protected S_TextBox txtsTelefonoRef;
    protected CalendarPicker CalendarPicker1;
    protected CalendarPicker CalendarPicker2;
    protected S_TextBox txtsCap;
    protected Button btnReset;
    private EditEnti _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Gestione/EditEnti.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId;
      ((Control) this.GridTitle1.hplsNuovo).Visible = siteModule.IsEditable;
      this.DataGridRicerca.Columns[1].Visible = true;
      this.DataGridRicerca.Columns[2].Visible = siteModule.IsEditable;
      Enti.FunId = siteModule.ModuleId;
      Enti.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      if (this.Page.IsPostBack)
        return;
      this.BindEnte();
      if (!(this.Context.Handler is EditEnti))
        return;
      this._fp = (EditEnti) this.Context.Handler;
      if (this._fp == null)
        return;
      this._myColl = this._fp._Contenitore;
      this._myColl.SetValues(this.Page.Controls);
      this.Ricerca();
    }

    private void BindEnte()
    {
      TheSite.Classi.ClassiAnagrafiche.Enti enti = new TheSite.Classi.ClassiAnagrafiche.Enti();
      ((ListControl) this.cmbsDescrizione).Items.Clear();
      DataSet dataSet = enti.GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsDescrizione).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "testo", "valore", "- Selezionare Ente -", "");
      ((ListControl) this.cmbsDescrizione).DataTextField = "testo";
      ((ListControl) this.cmbsDescrizione).DataValueField = "valore";
      ((Control) this.cmbsDescrizione).DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged_1);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound_1);
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.btnReset.Click += new EventHandler(this.btnReset_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    public clMyCollection _Contenitore => this._myColl;

    private void btnsRicerca_Click(object sender, EventArgs e) => this.Ricerca();

    private void Ricerca()
    {
      TheSite.Classi.ClassiAnagrafiche.Enti enti = new TheSite.Classi.ClassiAnagrafiche.Enti();
      this.txtsProvincia.set_DBDefaultValue((object) "%");
      this.txtsComune.set_DBDefaultValue((object) "%");
      this.txtsReferente.set_DBDefaultValue((object) "%");
      this.txtsEmail.set_DBDefaultValue((object) "%");
      this.txtsTelefono.set_DBDefaultValue((object) "%");
      this.txtsIndirizzo.set_DBDefaultValue((object) "%");
      this.txtsRagioneSociale.set_DBDefaultValue((object) "%");
      this.txtsPartitaIva.set_DBDefaultValue((object) "%");
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pDescrizione");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject1).set_Value((object) ((ListControl) this.cmbsDescrizione).SelectedValue.ToString());
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pProvincia");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.txtsProvincia).Text.Trim());
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pComune");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject3).set_Value((object) ((TextBox) this.txtsComune).Text.Trim());
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("pIndirizzo");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject4).set_Value((object) ((TextBox) this.txtsIndirizzo).Text.Trim());
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("pRagioneSociale");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject5).set_Value((object) ((TextBox) this.txtsRagioneSociale).Text.Trim());
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("pPiva");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject6).set_Value((object) ((TextBox) this.txtsPartitaIva).Text.Trim());
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("pTelefono");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject7).set_Value((object) ((TextBox) this.txtsTelefono).Text.Trim());
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("pEmail");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Index(7);
      ((ParameterObject) sObject8).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject8).set_Value((object) ((TextBox) this.txtsEmail).Text.Trim());
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("pReferente");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Index(8);
      ((ParameterObject) sObject9).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject9).set_Value((object) ((TextBox) this.txtsReferente).Text.Trim());
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("pTelefonoReferente");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Index(9);
      ((ParameterObject) sObject10).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject10).set_Value((object) ((TextBox) this.txtsTelefonoRef).Text.Trim());
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("PDataInizioContratto");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Index(10);
      ((ParameterObject) sObject11).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject11).set_Value((object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("pDataFineContratto");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Index(11);
      ((ParameterObject) sObject12).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject12).set_Value((object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("pCap");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(12);
      ((ParameterObject) sObject13).set_Size((int) byte.MaxValue);
      ((ParameterObject) sObject13).set_Value((object) ((TextBox) this.txtsCap).Text.Trim());
      CollezioneControlli.Add(sObject13);
      S_Object sObject14 = new S_Object();
      ((ParameterObject) sObject14).set_ParameterName("io_cursor");
      ((ParameterObject) sObject14).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject14).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject14).set_Index(13);
      CollezioneControlli.Add(sObject14);
      DataSet dataSet = enti.GetData(CollezioneControlli).Copy();
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

    private void DataGridRicerca_PageIndexChanged_1(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }

    private void DataGridRicerca_ItemDataBound_1(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      if (e.Item.Cells[10].Text.Length > 10)
        e.Item.Cells[10].Text = e.Item.Cells[10].Text.Substring(0, 10);
      if (e.Item.Cells[11].Text.Length <= 10)
        return;
      e.Item.Cells[11].Text = e.Item.Cells[11].Text.Substring(0, 10);
    }

    private void btnReset_Click(object sender, EventArgs e) => this.Server.Transfer("Enti.aspx");
  }
}
