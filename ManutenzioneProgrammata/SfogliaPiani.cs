// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.SfogliaPiani
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
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
using TheSite.Classi.ManProgrammata;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class SfogliaPiani : Page
  {
    protected DataPanel PanelRicerca;
    protected S_Button btnsRicerca;
    protected Button cmdReset;
    protected ValidationSummary ValidationSummary1;
    protected DropDownList cmbStato;
    protected DropDownList cmbsTipoDocumenti;
    protected TextBox txtDescrizione;
    protected DataGrid DataGridRicerca;
    protected CalendarPicker CalendarPicker1;
    protected CalendarPicker CalendarPicker2;
    protected RicercaModulo RicercaModulo1;
    protected GridTitle GridTitle1;
    protected DropDownList DropAnno;
    private RecuperoDocPmp _RecuproDocPmp = new RecuperoDocPmp();
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      SfogliaPiani.HelpLink = ((SiteModule) HttpContext.Current.Items[(object) "SiteModule"]).HelpLink;
      this.BindStato();
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.cmdReset.Click += new EventHandler(this.cmdReset_Click);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.RicercaPiani();
    }

    private void RicercaPiani()
    {
      this.DataGridRicerca.Visible = true;
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_BL_ID");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (this.RicercaModulo1.Idbl == "")
        ((ParameterObject) sObject1).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject1).set_Value((object) this.RicercaModulo1.Idbl);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_NOME_DOC");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(225);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (this.txtDescrizione.Text == "")
        ((ParameterObject) sObject2).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject2).set_Value((object) this.txtDescrizione.Text);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_ID_STATO");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (this.cmbStato.SelectedIndex == 0)
        ((ParameterObject) sObject3).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject3).set_Value((object) Convert.ToInt32(this.cmbStato.SelectedIndex));
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_DATA_INVIO");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(225);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (((TextBox) this.CalendarPicker1.Datazione).Text == "")
        ((ParameterObject) sObject4).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject4).set_Value((object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_DATA_INSERIMENTo");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size(225);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      if (((TextBox) this.CalendarPicker2.Datazione).Text == "")
        ((ParameterObject) sObject5).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject5).set_Value((object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_anno");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Size(225);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject6).set_Value((object) Convert.ToInt32(this.DropAnno.SelectedValue));
      CollezioneControlli.Add(sObject6);
      DataSet piani = this._RecuproDocPmp.GetPiani(CollezioneControlli, this.cmbsTipoDocumenti.SelectedValue);
      if (piani.Tables[0].Rows.Count == 0)
      {
        this.DataGridRicerca.CurrentPageIndex = 0;
        this.GridTitle1.DescriptionTitle = "Nessun dato trovato.";
      }
      else
      {
        this.GridTitle1.DescriptionTitle = "";
        this.GridTitle1.NumeroRecords = piani.Tables[0].Rows.Count.ToString();
      }
      this.DataGridRicerca.DataSource = (object) piani.Tables[0];
      this.DataGridRicerca.DataBind();
    }

    private void BindStato()
    {
      this.DropAnno.Items.Clear();
      for (int index = 2008; index <= 2020; ++index)
        this.DropAnno.Items.Add(new ListItem(index.ToString(), index.ToString()));
      this.cmbStato.Items.Clear();
      DataSet allStato = this._RecuproDocPmp.GetAllStato();
      if (allStato.Tables[0].Rows.Count > 0)
      {
        this.cmbStato.DataSource = (object) GestoreDropDownList.ItemBlankDataSource(allStato.Tables[0], "descrizione", "id", "- Selezionare uno Stato -", "");
        this.cmbStato.DataTextField = "descrizione";
        this.cmbStato.DataValueField = "id";
        this.cmbStato.DataBind();
      }
      else
        this.cmbStato.Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Gruppo -", string.Empty));
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.RicercaPiani();
    }

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (!(e.CommandName == "Download"))
        return;
      string str1 = this.Server.MapPath("../Doc_DB") + "\\Manutenzione Programmata";
      string str2 = str1 + "\\PAM" + this.DropAnno.SelectedValue;
      string str3 = str1 + "\\PMP" + this.DropAnno.SelectedValue;
      string str4;
      if (this.cmbsTipoDocumenti.SelectedValue == "2")
        str4 = str3 + "\\" + e.CommandArgument.ToString().Split(',')[1];
      else
        str4 = str2;
      string str5 = str4 + "\\" + e.CommandArgument.ToString().Split(',')[0];
      this.Response.Clear();
      this.Response.ContentType = "application/xls";
      this.Response.AddHeader("content-disposition", "inline; filename=" + Path.GetFileName(str5));
      this.Response.WriteFile(str5);
    }

    private void cmdReset_Click(object sender, EventArgs e)
    {
      string str = "";
      if (this.Request.QueryString["FunId"] != null)
        str = "FunId=" + this.Request.QueryString["FunId"];
      if (this.Request["VarApp"] != null)
        str = str + "&VarApp=" + this.Request["VarApp"];
      this.Server.Transfer("SfogliaPiani.aspx?" + str);
    }
  }
}
