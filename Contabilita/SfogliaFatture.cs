// Decompiled with JetBrains decompiler
// Type: TheSite.Contabilita.SfogliaFatture
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.Contabilita
{
  public class SfogliaFatture : Page
  {
    protected DataPanel PanelRicerca;
    protected DataGrid DataGridRicerca;
    protected CalendarPicker CalendarPicker1;
    protected CalendarPicker CalendarPicker2;
    protected CalendarPicker CalendarPicker3;
    protected CalendarPicker CalendarPicker4;
    protected CalendarPicker CalendarPicker5;
    protected CalendarPicker CalendarPicker6;
    protected CalendarPicker CalendarPicker7;
    protected CalendarPicker CalendarPicker8;
    private DataSet _MyDs = new DataSet();
    private InserimentoFattura _fp;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    private clMyCollection _myColl = new clMyCollection();
    protected GridTitle GridTitle1;
    protected S_ComboBox cmbsServizio;
    protected DropDownList cmbAnnoDa;
    protected DropDownList cmbDaMese;
    protected PageTitle PageTitle1;
    protected S_TextBox S_TxtNumFattura;
    private TheSite.Classi.Fatturazione.Contabilita _Contabilita = new TheSite.Classi.Fatturazione.Contabilita();
    private string s_PeriodoDa = "";
    protected S_TextBox S_TxtImponibileDec;
    protected S_TextBox S_TxtImponibile;
    protected S_ListBox S_ListRDL;
    protected RicercaRDL RicercaRDL1;
    protected HtmlInputHidden rdl;
    protected HtmlTable TableOrdinaria;
    protected HtmlTable TableStrardinaria;
    protected Button BtnReset;
    protected S_Button btnsRicerca;
    private string strArrRdl = "";

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.BtnReset.Click += new EventHandler(this.BtnReset_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    public clMyCollection _Contenitore => this._myColl;

    private void visualizzatab()
    {
      if (((ListControl) this.cmbsServizio).SelectedValue == "1")
      {
        this.TableOrdinaria.Attributes.Add("Style", "DISPLAY:block");
        this.TableStrardinaria.Attributes.Add("Style", "DISPLAY:none");
      }
      if (((ListControl) this.cmbsServizio).SelectedValue == "3")
      {
        this.TableOrdinaria.Attributes.Add("Style", "DISPLAY:none");
        this.TableStrardinaria.Attributes.Add("Style", "DISPLAY:block");
      }
      if (!(((ListControl) this.cmbsServizio).SelectedValue == ""))
        return;
      this.TableOrdinaria.Attributes.Add("Style", "DISPLAY:none");
      this.TableStrardinaria.Attributes.Add("Style", "DISPLAY:none");
    }

    private void Page_Load(object sender, EventArgs e)
    {
      this.visualizzatab();
      ((WebControl) this.S_ListRDL).Attributes.Add("onkeydown", "deleteitem(this,event);");
      this.RicercaRDL1.multisele = "y";
      this.RicercaRDL1.operazione = "Cerca";
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Contabilita/InserimentoFattura.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId;
      ((Control) this.GridTitle1.hplsNuovo).Visible = siteModule.IsEditable;
      this.DataGridRicerca.Columns[1].Visible = true;
      this.DataGridRicerca.Columns[2].Visible = siteModule.IsEditable;
      SfogliaFatture.FunId = siteModule.ModuleId;
      SfogliaFatture.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      if (this.Page.IsPostBack)
        return;
      this.CaricaTipoServizio();
      ((WebControl) this.S_TxtImponibile).Attributes.Add("onkeypress", "if (valutanumeri(event) == false) { return false; }");
      ((WebControl) this.S_TxtImponibile).Attributes.Add("onpaste", "return false;");
      ((WebControl) this.S_TxtImponibile).Attributes.Add("onblur", "imposta_int(this.id);");
      ((WebControl) this.cmbsServizio).Attributes.Add("onChange", "visualizzadettservizio(this);");
      this.cmbAnnoDa.Attributes.Add("onChange", "abilita();");
      if (!(this.Context.Handler is InserimentoFattura))
        return;
      this._fp = (InserimentoFattura) this.Context.Handler;
      if (this._fp == null)
        return;
      this._myColl = this._fp._Contenitore;
      this._myColl.SetValues(this.Page.Controls);
      this.Ricerca();
    }

    private void CaricaTipoServizio()
    {
      ((ListControl) this.cmbsServizio).Items.Clear();
      DataSet dataSet = this._Contabilita.GetTipoServizio().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "tipomanutenzione_id", "- Selezionare un Servizio -", "0");
      ((ListControl) this.cmbsServizio).DataTextField = "descrizione";
      ((ListControl) this.cmbsServizio).DataValueField = "tipomanutenzione_id";
      ((Control) this.cmbsServizio).DataBind();
    }

    private void Ricerca()
    {
      string str = ((TextBox) this.S_TxtImponibile).Text + "," + ((TextBox) this.S_TxtImponibileDec).Text;
      if (str == "0,00")
        str = "0";
      this.s_PeriodoDa = !(((ListControl) this.cmbsServizio).SelectedValue == "1") || !(this.cmbAnnoDa.SelectedValue != "0000") || !(this.cmbDaMese.SelectedValue != "00") ? "0" : this.cmbAnnoDa.SelectedValue + this.cmbDaMese.SelectedValue;
      if (((ListControl) this.cmbsServizio).SelectedValue == "3")
      {
        this.strArrRdl = this.rdl.Value;
        this.strArrRdl = !(this.strArrRdl != "") ? "0" : this.strArrRdl.Substring(0, this.strArrRdl.Length - 1);
      }
      else
        this.strArrRdl = "0";
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      ((ParameterObject) sObject1).set_ParameterName("p_DATA_FATTURAA");
      ((ParameterObject) sObject1).set_Size(10);
      ((ParameterObject) sObject1).set_Index(0);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.CalendarPicker5.Datazione).Text);
      ((ParameterObject) sObject2).set_ParameterName("p_DATA_FATTURADA");
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Index(1);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Value((object) ((TextBox) this.S_TxtNumFattura).Text);
      ((ParameterObject) sObject3).set_ParameterName("p_NUMEROFATTURA");
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Index(2);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Value((object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      ((ParameterObject) sObject4).set_ParameterName("p_DATA_SCADENZA_PAGAMENTODA");
      ((ParameterObject) sObject4).set_Size(10);
      ((ParameterObject) sObject4).set_Index(3);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Value((object) ((TextBox) this.CalendarPicker6.Datazione).Text);
      ((ParameterObject) sObject5).set_ParameterName("p_DATA_SCADENZA_PAGAMENTOA");
      ((ParameterObject) sObject5).set_Size(10);
      ((ParameterObject) sObject5).set_Index(4);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Value((object) int.Parse(((ListControl) this.cmbsServizio).SelectedValue));
      ((ParameterObject) sObject6).set_ParameterName("p_TIPOMANUTENZIONE_ID");
      ((ParameterObject) sObject6).set_Index(5);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Value((object) this.s_PeriodoDa);
      ((ParameterObject) sObject7).set_ParameterName("p_PERIODO_INIZIO_FATTURA");
      ((ParameterObject) sObject7).set_Index(6);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Value((object) str);
      ((ParameterObject) sObject8).set_ParameterName("p_IMPONIBILE");
      ((ParameterObject) sObject8).set_Index(7);
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Value((object) ((TextBox) this.CalendarPicker3.Datazione).Text);
      ((ParameterObject) sObject9).set_ParameterName("p_DATA_APPROVAZIONEDA");
      ((ParameterObject) sObject9).set_Size(10);
      ((ParameterObject) sObject9).set_Index(8);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Value((object) ((TextBox) this.CalendarPicker7.Datazione).Text);
      ((ParameterObject) sObject10).set_ParameterName("p_DATA_APPROVAZIONEA");
      ((ParameterObject) sObject10).set_Size(10);
      ((ParameterObject) sObject10).set_Index(9);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Value((object) ((TextBox) this.CalendarPicker4.Datazione).Text);
      ((ParameterObject) sObject11).set_Size(10);
      ((ParameterObject) sObject11).set_ParameterName("p_DATA_PAGAMENTODA");
      ((ParameterObject) sObject11).set_Index(10);
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Value((object) ((TextBox) this.CalendarPicker4.Datazione).Text);
      ((ParameterObject) sObject12).set_Size(10);
      ((ParameterObject) sObject12).set_ParameterName("p_DATA_PAGAMENTOA");
      ((ParameterObject) sObject12).set_Index(11);
      CollezioneControlli.Add(sObject12);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_Arr_RDL");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject13).set_Index(12);
      ((ParameterObject) sObject13).set_Value((object) this.strArrRdl);
      CollezioneControlli.Add(sObject13);
      DataSet dataSet = this._Contabilita.GetData(CollezioneControlli).Copy();
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

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.Ricerca();
      this.strArrRdl = "";
      this.rdl.Value = "";
    }

    private void BtnReset_Click(object sender, EventArgs e) => this.Response.Redirect("SfogliaFatture.aspx?FunId=" + (object) SfogliaFatture.FunId);

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
      string str1 = "";
      string str2 = "";
      ArrayList itmTooltip = new ArrayList();
      itmTooltip.Add((object) str2);
      itmTooltip.Add((object) str1);
      if (e.Item.Cells[11].Text.Trim().Length > 0)
      {
        TheSite.Classi.Function.Tronca(e.Item.Cells[11].Text, 10, itmTooltip, e.Item.Cells[11].Text.Trim().Length);
        e.Item.Cells[11].ToolTip = itmTooltip[0].ToString();
        e.Item.Cells[11].Text = itmTooltip[1].ToString();
      }
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton3")).Attributes.Add("title", "Visualizza");
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton2")).Attributes.Add("title", "Modifica");
      if (e.Item.Cells[14].Text == "1")
      {
        string text1 = e.Item.Cells[7].Text;
        string text2 = e.Item.Cells[8].Text;
        if (text1 != "0" && text2 != "0")
          e.Item.Cells[7].Text = "Dal " + text1.Substring(0, 4) + "/" + text1.Substring(4, 2) + " Al " + text2.Substring(0, 4) + "/" + text2.Substring(4, 2);
        e.Item.Cells[8].Text = " ";
        e.Item.Cells[9].Text = " ";
      }
      else
        e.Item.Cells[7].Text = "";
      if (e.Item.Cells[14].Text == "3")
      {
        string str3 = "";
        this._MyDs = this._Contabilita.GetSingleRdlFatt(Convert.ToInt32(e.Item.Cells[0].Text));
        int count = this._MyDs.Tables[0].Rows.Count;
        if (count > 0)
        {
          for (int index = 0; index < count; ++index)
          {
            DataRow row = this._MyDs.Tables[0].Rows[index];
            str3 = str3 + row["wr_id"] + ";";
          }
          str3 = str3.Substring(0, str3.Length - 1);
        }
        e.Item.Cells[9].Text = str3;
      }
      else
        e.Item.Cells[9].Text = " ";
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }
  }
}
