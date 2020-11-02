// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.ProcedurePassi
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.Classi.ClassiDettaglio;
using TheSite.Classi.ManProgrammata;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class ProcedurePassi : Page
  {
    protected DataPanel PanelRicerca;
    protected S_Button btnsRicerca;
    protected DataGrid DataGridRicerca;
    protected RicercaModulo RicercaModulo1;
    protected UserPmp UserPmp1;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    protected DataPanel DataPanel1;
    protected S_ComboBox cmdsStdApparecchiatura;
    protected S_ComboBox cmbsServizio;
    protected S_ComboBox cmbsSpecializzazione;
    protected Button cmdReset;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      this.UserPmp1.DelegateCodicePMP1 += new DelegateCodicePMP(this.BindSpecializzazione);
      ProcedurePassi.FunId = siteModule.ModuleId;
      ProcedurePassi.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      string str = "Pulisci('" + ((Control) this.UserPmp1.Descrizione).ClientID + "','" + ((Control) this.UserPmp1.Codice).ClientID + "','" + this.UserPmp1.CodiceNum.ClientID + "');";
      ((WebControl) this.cmbsServizio).Attributes.Add("onchange", str);
      ((WebControl) this.cmdsStdApparecchiatura).Attributes.Add("onchange", str);
      if (this.Page.IsPostBack)
        return;
      if (this.Request.QueryString["FunId"] != null)
        this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
      this.BindServizio();
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.BindApparecchiatura();
      this.BindSpecializzazione(0);
    }

    private void BindServizio()
    {
      ((ListControl) this.cmbsServizio).Items.Clear();
      DataSet data1 = new Servizi(this.Context.User.Identity.Name).GetData1();
      if (data1.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data1.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", string.Empty));
    }

    private void BindApparecchiatura()
    {
      ((ListControl) this.cmdsStdApparecchiatura).Items.Clear();
      DataSet dataSet = new Apparecchiature(this.Context.User.Identity.Name).GetData().Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmdsStdApparecchiatura).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE", "ID", "- Selezionare una Apparecchiatura -", "");
        ((ListControl) this.cmdsStdApparecchiatura).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmdsStdApparecchiatura).DataValueField = "ID";
        ((Control) this.cmdsStdApparecchiatura).DataBind();
      }
      else
        ((ListControl) this.cmdsStdApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Apparecchiatura -", string.Empty));
    }

    private void BindSpecializzazione(int pmp_id)
    {
      ((ListControl) this.cmbsSpecializzazione).Items.Clear();
      int eqstd_id = 0;
      int servizio_id = 0;
      if (((ListControl) this.cmbsServizio).SelectedValue != "")
        servizio_id = int.Parse(((ListControl) this.cmbsServizio).SelectedValue);
      if (((ListControl) this.cmdsStdApparecchiatura).SelectedValue != "")
        eqstd_id = int.Parse(((ListControl) this.cmdsStdApparecchiatura).SelectedValue);
      TheSite.Classi.ClassiAnagrafiche.Addetti addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
      DataSet dataSet = pmp_id != 0 ? addetti.GetSpecializzazionePMP(pmp_id, eqstd_id, servizio_id) : addetti.GetAllSpecializzazioni().Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsSpecializzazione).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE", "ID", "- Tutte le Specializzazioni -", "");
        ((ListControl) this.cmbsSpecializzazione).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsSpecializzazione).DataValueField = "ID";
        ((Control) this.cmbsSpecializzazione).DataBind();
        if (pmp_id <= 0)
          return;
        ((ListControl) this.cmbsSpecializzazione).SelectedIndex = 1;
      }
      else
        ((ListControl) this.cmbsSpecializzazione).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Specializzazione -", string.Empty));
    }

    private void BindApparecchiatura(string ServizioID)
    {
      ((ListControl) this.cmdsStdApparecchiatura).Items.Clear();
      Apparecchiature apparecchiature = new Apparecchiature(this.Context.User.Identity.Name);
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) string.Empty);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Servizio");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == "" ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      CollezioneControlli.Add(sObject2);
      DataSet dataSet = apparecchiature.GetData(CollezioneControlli).Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmdsStdApparecchiatura).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE", "ID", "- Selezionare una Apparecchiatura -", "");
        ((ListControl) this.cmdsStdApparecchiatura).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmdsStdApparecchiatura).DataValueField = "ID";
        ((Control) this.cmdsStdApparecchiatura).DataBind();
      }
      else
        ((ListControl) this.cmdsStdApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Apparecchiatura -", string.Empty));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsServizio).SelectedIndexChanged += new EventHandler(this.cmbsServizio_SelectedIndexChanged);
      ((ListControl) this.cmdsStdApparecchiatura).SelectedIndexChanged += new EventHandler(this.cmdsStdApparecchiatura_SelectedIndexChanged);
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.cmdReset.Click += new EventHandler(this.cmdReset_Click);
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = 0;
      this.Ricerca(true);
    }

    private void Ricerca(bool reset)
    {
      ProcAndSteps procAndSteps = new ProcAndSteps(this.Context.User.Identity.Name);
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      if (((ListControl) this.cmbsServizio).SelectedValue != "")
        num1 = int.Parse(((ListControl) this.cmbsServizio).SelectedValue);
      if (((ListControl) this.cmdsStdApparecchiatura).SelectedValue != "")
        num2 = int.Parse(((ListControl) this.cmdsStdApparecchiatura).SelectedValue);
      if (((ListControl) this.cmbsSpecializzazione).SelectedValue != "")
        num3 = int.Parse(((ListControl) this.cmbsSpecializzazione).SelectedValue);
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Servizio_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) num1);
      ((ParameterObject) sObject1).set_Size(50);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_EqStd_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) num2);
      ((ParameterObject) sObject2).set_Size(50);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_TR_id");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) num3);
      ((ParameterObject) sObject3).set_Size(50);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_PMP_id");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) this.UserPmp1.CodiceNum.Value);
      ((ParameterObject) sObject4).set_Size(50);
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
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_UserName");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(4);
      ((ParameterObject) sObject7).set_Value((object) this.User.Identity.Name);
      ((ParameterObject) sObject7).set_Size(50);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("IO_CURSOR");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject8).set_Index(5);
      CollezioneControlli.Add(sObject8);
      DataSet dataSet = procAndSteps.GetData(CollezioneControlli).Copy();
      if (reset)
      {
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 4);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 3);
        this.GridTitle1.NumeroRecords = procAndSteps.GetDataCount(CollezioneControlli).ToString();
      }
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.DataGridRicerca.DataBind();
    }

    private void cmbsServizio_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (((ListControl) this.cmbsServizio).SelectedIndex == 0)
        this.BindApparecchiatura();
      else
        this.BindApparecchiatura(((ListControl) this.cmbsServizio).SelectedValue);
      this.BindSpecializzazione(0);
    }

    private void cmdsStdApparecchiatura_SelectedIndexChanged(object sender, EventArgs e) => this.BindSpecializzazione(0);

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca(false);
    }

    private void cmdReset_Click(object sender, EventArgs e) => this.Response.Redirect("ProcedurePassi.aspx?FunID=" + this.ViewState["FunId"]);

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      string str1 = "";
      string str2 = "";
      ArrayList itmTooltip = new ArrayList();
      itmTooltip.Add((object) str2);
      itmTooltip.Add((object) str1);
      string[] strArray = e.Item.Cells[5].Text.Split(' ');
      int numcarvisual = strArray.Length < 7 ? e.Item.Cells[5].Text.Length : strArray[0].Length + strArray[1].Length + strArray[2].Length + strArray[3].Length + strArray[4].Length + strArray[5].Length + strArray[6].Length + 6;
      if (e.Item.Cells[5].Text.Trim().Length <= 0)
        return;
      TheSite.Classi.Function.Tronca(e.Item.Cells[5].Text, numcarvisual, itmTooltip, e.Item.Cells[5].Text.Trim().Length);
      e.Item.Cells[5].ToolTip = itmTooltip[0].ToString();
      e.Item.Cells[5].Text = itmTooltip[1].ToString();
    }
  }
}
