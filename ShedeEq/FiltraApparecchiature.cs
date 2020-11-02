// Decompiled with JetBrains decompiler
// Type: TheSite.ShedeEq.FiltraApparecchiature
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using Microsoft.Web.UI.WebControls;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ClassiDettaglio;
using TheSite.WebControls;

namespace TheSite.ShedeEq
{
  public class FiltraApparecchiature : Page
  {
    protected DataGrid MyDataGrid1;
    protected S_ComboBox cmbsServizio;
    protected S_ComboBox cmbsApparecchiatura;
    protected S_Button S_btMostra;
    protected GridTitle GridTitle1;
    protected CodiceApparecchiature CodiceApparecchiature1;
    protected RicercaModulo RicercaModulo1;
    protected DataPanel PanelRicerca;
    protected PageTitle PageTitle1;
    protected HtmlInputHidden hiddenblid;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    private clMyCollection _myColl = new clMyCollection();
    protected TabStrip TabStrip1;
    protected S_ComboBox cmbsPiano;
    protected Button btnSelezionaTutto;
    protected Button btnDeselezionaTutto;
    protected Button btnGeneraReportHtml;
    protected Button btnGeneraReportPdf;
    protected Button btnReset;
    protected Button btnConfermaSelezione;
    protected Label lblElementiSelezionati;
    protected Label LblRangeException;
    public VisualizzaSchedaHtml fp;
    protected UserStanzeRic UserStanze1;
    private int MaxRecord = 500;
    protected RequiredFieldValidator rfvEdificio;
    protected ValidationSummary vlsEdit;
    private VisualizzaSchedaHtml _fp = (VisualizzaSchedaHtml) null;

    public clMyCollection _Contenitore => this._myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      FiltraApparecchiature.FunId = siteModule.ModuleId;
      FiltraApparecchiature.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      this.RicercaModulo1.DelegateIDBLEdificio1 += new DelegateIDBLEdificio(this.BindPiano);
      this.RicercaModulo1.DelegateCodiceEdificio1 += new DelegateCodiceEdificio(this.BindServizio);
      this.CodiceApparecchiature1.NameComboApparecchiature = "cmbsApparecchiatura";
      this.CodiceApparecchiature1.NameComboServizio = "cmbsServizio";
      this.CodiceApparecchiature1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.UserStanze1.NameComboPiano = "cmbsPiano";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("document.getElementById('" + ((Control) this.cmbsApparecchiatura).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsServizio).Attributes.Add("onchange", stringBuilder.ToString());
      if (!this.IsPostBack)
      {
        this.rfvEdificio.ControlToValidate = this.RicercaModulo1.ID + ":" + ((Control) this.RicercaModulo1.TxtCodice).ID;
        if (this.Request.QueryString["FunId"] != null)
          this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
        this.BindServizio("0");
        this.BindTuttiPiani();
        this.BindStanza();
        this.BindApparecchiatura();
        this.setvisiblecontrol(false);
        this.GridTitle1.Visible = false;
        if (this.Context.Handler is VisualizzaSchedaHtml)
        {
          this._fp = (VisualizzaSchedaHtml) this.Context.Handler;
          if (this._fp != null)
          {
            this._myColl = this._fp._Contenitore;
            this._myColl.SetValues(this.Page.Controls);
            this.EnableBottoniConferma(this.Execute(true));
          }
        }
      }
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
    }

    private void BindServizio(string CodEdificio)
    {
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
        this.BindApparecchiatura();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", string.Empty));
    }

    private void BindApparecchiatura()
    {
      if (((ListControl) this.cmbsServizio).SelectedValue != "" || ((TextBox) this.RicercaModulo1.TxtCodice).Text != "")
      {
        ((ListControl) this.cmbsApparecchiatura).Items.Clear();
        Apparecchiature apparecchiature = new Apparecchiature(this.Context.User.Identity.Name);
        DataSet dataSet;
        if (!this.IsPostBack)
        {
          dataSet = apparecchiature.GetData().Copy();
        }
        else
        {
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
          ((ParameterObject) sObject2).set_ParameterName("p_Servizio");
          ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject2).set_Index(1);
          ((ParameterObject) sObject2).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
          CollezioneControlli.Add(sObject2);
          dataSet = apparecchiature.GetData(CollezioneControlli).Copy();
        }
        if (dataSet.Tables[0].Rows.Count > 0)
        {
          ((BaseDataBoundControl) this.cmbsApparecchiatura).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Standard -", "");
          ((ListControl) this.cmbsApparecchiatura).DataTextField = "DESCRIZIONE";
          ((ListControl) this.cmbsApparecchiatura).DataValueField = "ID";
          ((Control) this.cmbsApparecchiatura).DataBind();
        }
        else
          ((ListControl) this.cmbsApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Standard -", string.Empty));
      }
      else
        ((ListControl) this.cmbsApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Standard -", string.Empty));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsServizio).SelectedIndexChanged += new EventHandler(this.cmbsServizio_SelectedIndexChanged);
      ((Button) this.S_btMostra).Click += new EventHandler(this.S_btMostra_Click);
      this.MyDataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged);
      this.MyDataGrid1.ItemDataBound += new DataGridItemEventHandler(this.MyDataGrid1_ItemDataBound);
      this.btnConfermaSelezione.Click += new EventHandler(this.btnConfermaSelezione_Click);
      this.btnSelezionaTutto.Click += new EventHandler(this.btnSelezionaTutto_Click);
      this.btnDeselezionaTutto.Click += new EventHandler(this.btnDeselezionaTutto_Click);
      this.btnGeneraReportHtml.Click += new EventHandler(this.btnGeneraReportHtml_Click);
      this.btnGeneraReportPdf.Click += new EventHandler(this.btnGeneraReportPdf_Click);
      this.btnReset.Click += new EventHandler(this.btnReset_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void cmbsServizio_SelectedIndexChanged(object sender, EventArgs e) => this.BindApparecchiatura();

    private void setvisiblecontrol(bool Visibile)
    {
      this.GridTitle1.VisibleRecord = Visibile;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
    }

    private void S_btMostra_Click(object sender, EventArgs e)
    {
      this.MyDataGrid1.CurrentPageIndex = 0;
      bool enable = this.Execute(true);
      this.EnableControl(false);
      this.Session.Remove("CheckedList");
      this.Session.Remove("DatiList");
      this.lblElementiSelezionati.Text = "";
      this.EnableBottoniConferma(enable);
    }

    private void EnableBottoniConferma(bool enable)
    {
      this.btnConfermaSelezione.Enabled = enable;
      this.btnDeselezionaTutto.Enabled = enable;
      this.btnSelezionaTutto.Enabled = enable;
      if (!enable)
      {
        if (this.MyDataGrid1.Items.Count > 0)
          this.LblRangeException.Text = "Sono permessi solo " + this.MaxRecord.ToString() + " record alla volta. Ti consigliamo di aumentare i filtri di selezione come ad sempio scegliendo un edificio, un piano, una stanza, un servizio dalla maschera di selezione";
        else
          this.LblRangeException.Text = "";
      }
      else
        this.LblRangeException.Text = "";
    }

    private bool Execute(bool reset)
    {
      Apparecchiature apparecchiature = new Apparecchiature(this.Context.User.Identity.Name);
      S_ControlsCollection CollezioneControlli1 = this.riempiDatasetRicerca();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pageindex");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli1).Count + 1);
      ((ParameterObject) sObject1).set_Value((object) (this.MyDataGrid1.CurrentPageIndex + 1));
      CollezioneControlli1.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pagesize");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli1).Count + 1);
      ((ParameterObject) sObject2).set_Value((object) this.MyDataGrid1.PageSize);
      CollezioneControlli1.Add(sObject2);
      DataSet dataSet = apparecchiature.RicercaApparecchiatura(CollezioneControlli1).Copy();
      this.GridTitle1.Visible = true;
      if (reset)
      {
        S_ControlsCollection CollezioneControlli2 = this.riempiDatasetRicerca();
        this.GridTitle1.NumeroRecords = apparecchiature.RicercaApparecchiaturaCount(CollezioneControlli2).ToString();
      }
      this.MyDataGrid1.DataSource = (object) dataSet.Tables[0];
      this.MyDataGrid1.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.MyDataGrid1.DataBind();
      bool flag;
      if (int.Parse(this.GridTitle1.NumeroRecords) > 0 && int.Parse(this.GridTitle1.NumeroRecords) < this.MaxRecord + 1)
      {
        this.setvisiblecontrol(true);
        this.GridTitle1.DescriptionTitle = "";
        flag = true;
      }
      else if (int.Parse(this.GridTitle1.NumeroRecords) > this.MaxRecord)
      {
        this.setvisiblecontrol(true);
        flag = false;
      }
      else
      {
        this.setvisiblecontrol(false);
        flag = false;
      }
      return flag;
    }

    private S_ControlsCollection riempiDatasetRicerca()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) ((TextBox) this.RicercaModulo1.TxtCodice).Text);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_campus");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) ((TextBox) this.RicercaModulo1.TxtRicerca).Text);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_Servizio");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_eqstdid");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(8);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) (((ListControl) this.cmbsApparecchiatura).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsApparecchiatura).SelectedValue)));
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_eq_id");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size(8);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Size(50);
      ((ParameterObject) sObject5).set_Value((object) this.CodiceApparecchiature1.CodiceApparecchiatura);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_dismesso");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Size(8);
      ((ParameterObject) sObject6).set_Value((object) DismissioneType.NO);
      controlsCollection.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_idpiano");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(10);
      ((ParameterObject) sObject7).set_Index(6);
      ((ParameterObject) sObject7).set_Value((object) (((ListControl) this.cmbsPiano).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsPiano).SelectedValue)));
      controlsCollection.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_idstanza");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Size(10);
      ((ParameterObject) sObject8).set_Index(7);
      ((ParameterObject) sObject8).set_Value((object) this.UserStanze1.DescStanza);
      controlsCollection.Add(sObject8);
      return controlsCollection;
    }

    private void MyDataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.MyDataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.Execute(false);
      this.GetControlli();
    }

    private void MyDataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem || !(e.Item.Cells[6].Text.Trim().ToUpper() == "DISMESSA"))
        return;
      e.Item.ForeColor = Color.Tomato;
      e.Item.ToolTip = "Apparecchiatura Dismessa";
    }

    private void BindPiano(string CodEdificio)
    {
      ((ListControl) this.cmbsPiano).Items.Clear();
      if (CodEdificio == "")
        CodEdificio = "0";
      DataSet pianiBuilding = new Buildings().GetPianiBuilding(int.Parse(CodEdificio));
      if (pianiBuilding.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsPiano).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(pianiBuilding.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "");
        ((ListControl) this.cmbsPiano).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsPiano).DataValueField = "ID";
        ((Control) this.cmbsPiano).DataBind();
      }
      else
        ((ListControl) this.cmbsPiano).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", string.Empty));
      ((WebControl) this.cmbsPiano).Enabled = true;
    }

    private void BindStanza()
    {
    }

    private void BindTuttiPiani()
    {
      ((ListControl) this.cmbsPiano).Items.Clear();
      DataSet allPiani = new Buildings().GetAllPiani();
      if (allPiani.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsPiano).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(allPiani.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "");
        ((ListControl) this.cmbsPiano).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsPiano).DataValueField = "ID";
        ((Control) this.cmbsPiano).DataBind();
      }
      else
        ((ListControl) this.cmbsPiano).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Piano -", string.Empty));
    }

    private void btnReset_Click(object sender, EventArgs e) => this.Server.Transfer("FiltraApparecchiature.aspx");

    private void btnConfermaSelezione_Click(object sender, EventArgs e)
    {
      this.SetDati();
      this.SetControlli();
    }

    private void SetDati()
    {
      Hashtable hashtable = new Hashtable();
      if (this.Session["DatiList"] != null)
        hashtable = (Hashtable) this.Session["DatiList"];
      foreach (DataGridItem dataGridItem in this.MyDataGrid1.Items)
      {
        int num = int.Parse(dataGridItem.Cells[1].Text);
        CheckBox control = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
        if (hashtable.ContainsKey((object) num))
          hashtable.Remove((object) num);
        if (control.Checked)
          hashtable.Add((object) num, (object) num);
      }
      this.Session.Remove("DatiList");
      this.Session.Add("DatiList", (object) hashtable);
      this.lblElementiSelezionati.Text = "Elementi Selezionati - " + hashtable.Count.ToString() + " -";
      if (hashtable.Count > 0)
      {
        this.EnableControl(true);
      }
      else
      {
        this.Session.Remove("DatiList");
        this.EnableControl(false);
      }
    }

    private void EnableControl(bool enable)
    {
      this.btnGeneraReportHtml.Enabled = enable;
      this.btnGeneraReportPdf.Enabled = enable;
    }

    private void SetControlli()
    {
      clMyDataGridCollection dataGridCollection = new clMyDataGridCollection();
      Hashtable _HS = new Hashtable();
      if (this.Session["CheckedList"] != null)
        _HS = (Hashtable) this.Session["CheckedList"];
      Hashtable hashtable = dataGridCollection.SetControl(this.MyDataGrid1, _HS, this.MyDataGrid1.CurrentPageIndex);
      this.Session.Remove("CheckedList");
      this.Session.Add("CheckedList", (object) hashtable);
    }

    private string IDBL
    {
      get => this.hiddenblid.Value;
      set => this.hiddenblid.Value = value;
    }

    private void SelezionaTutti(bool val)
    {
      DataSet dataSet1 = new DataSet();
      if (!val)
      {
        this.Session.Remove("CheckedList");
        this.Session.Remove("DatiList");
        this.lblElementiSelezionati.Text = "Elementi Selezionati - 0 -";
        this.EnableControl(false);
      }
      else
        this.SetControlli();
      DataSet dataSet2 = new Apparecchiature(this.Context.User.Identity.Name).RicercaAppar(this.riempiDatasetRicerca()).Copy();
      for (int index = 0; index <= this.MyDataGrid1.PageCount; ++index)
      {
        this.MyDataGrid1.DataSource = (object) dataSet2.Tables[0];
        this.MyDataGrid1.DataBind();
        this.MyDataGrid1.CurrentPageIndex = index;
        this.SetDati(val);
        if (val)
          this.SetControlli();
      }
      this.MyDataGrid1.CurrentPageIndex = 0;
      this.Execute(true);
      this.GetControlli();
    }

    private void SetDati(bool val)
    {
      Hashtable hashtable = new Hashtable();
      if (this.Session["DatiList"] != null)
        hashtable = (Hashtable) this.Session["DatiList"];
      foreach (DataGridItem dataGridItem in this.MyDataGrid1.Items)
      {
        int num = int.Parse(dataGridItem.Cells[1].Text);
        CheckBox control = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
        control.Checked = val;
        if (hashtable.ContainsKey((object) num))
          hashtable.Remove((object) num);
        if (control.Checked)
          hashtable.Add((object) num, (object) num);
      }
      this.Session.Remove("DatiList");
      this.Session.Add("DatiList", (object) hashtable);
      this.lblElementiSelezionati.Text = "Elementi Selezionati - " + hashtable.Count.ToString() + " -";
      if (hashtable.Count > 0)
      {
        this.EnableControl(true);
      }
      else
      {
        this.Session.Remove("DatiList");
        this.EnableControl(false);
      }
    }

    private void GetControlli()
    {
      clMyDataGridCollection dataGridCollection = new clMyDataGridCollection();
      if (this.Session["CheckedList"] == null)
        return;
      dataGridCollection.GetControl(this.MyDataGrid1, (Hashtable) this.Session["CheckedList"], this.MyDataGrid1.CurrentPageIndex);
    }

    private void btnSelezionaTutto_Click(object sender, EventArgs e) => this.SelezionaTutti(true);

    private void btnDeselezionaTutto_Click(object sender, EventArgs e) => this.SelezionaTutti(false);

    private void btnGeneraReportHtml_Click(object sender, EventArgs e)
    {
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer("VisualizzaSchedaHtml.aspx");
    }

    private void btnGeneraReportPdf_Click(object sender, EventArgs e) => this.Server.Transfer("VisulizzaSchedaEqPdf.aspx");
  }
}
