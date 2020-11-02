// Decompiled with JetBrains decompiler
// Type: TheSite.ReportGestioneSpazi.ReportGestioneSpazi
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using Microsoft.Web.UI.WebControls;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.Classi.AnalisiStatistiche;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.WebControls;

namespace TheSite.ReportGestioneSpazi
{
  public class ReportGestioneSpazi : Page
  {
    protected S_Button S_BtnSubmit;
    protected Button btnReportPdf;
    protected Panel PanelPannelloRicerca;
    protected string VarDataInit;
    protected string VarDataEnd;
    protected string urlRpt;
    protected S_OptionButton S_Reparti;
    protected S_OptionButton S_Categorie;
    protected S_OptionButton S_Destinazione;
    protected S_OptionButton S_Misure;
    protected S_ComboBox cmbsPiano;
    protected S_ComboBox cmbsCategoria;
    protected S_TextBox s_txtDestinazione;
    protected S_TextBox s_txtReparto;
    protected S_ComboBox cmbsConfronto;
    protected S_TextBox s_txtMq;
    protected S_ListBox S_ListEdifici;
    protected HtmlInputHidden edifici;
    protected HtmlInputHidden edificidescription;
    protected DataPanel DataPanel1;
    protected int status;
    protected RicercaModulo RicercaModulo1;
    protected UserStanze UserStanze1;
    protected TreeView TreeCtrl;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    public string descUso1 = "";
    public string descRep = "";
    public string Usoid1 = string.Empty;
    protected HtmlInputButton Reset1;
    public string id = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      StringBuilder stringBuilder = new StringBuilder();
      ((WebControl) this.S_ListEdifici).Attributes.Add("title", "Premere il tasto canc per eliminare un elemento dalla lista.");
      this.SetProperty();
      if (!this.IsPostBack)
      {
        ((ListControl) this.S_ListEdifici).Items.Clear();
        if (this.Request.QueryString["FunId"] != null)
          this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
        this.BindTuttiPiani();
        this.BindTutteCategorie();
        if (this.Request.QueryString["idcomune"] != null)
          this.IdComune = int.Parse(this.Request.QueryString["idcomune"]);
        if (this.Request.QueryString["idfrazione"] != null)
          this.IdFrazione = int.Parse(this.Request.QueryString["idfrazione"]);
        this.LoadComune();
      }
      this.RicercaModulo1.multisele = "y&id_comune=" + this.IdComune.ToString() + "&id_frazione=" + this.IdFrazione.ToString();
      this.RicercaModulo1.visualizzadettagli = false;
      this.UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
      this.UserStanze1.NameComboPiano = "cmbsPiano";
      this.descRep = ((Control) this.s_txtReparto).ClientID;
      this.descUso1 = ((Control) this.s_txtDestinazione).ClientID;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.S_BtnSubmit).Click += new EventHandler(this.S_BtnSubmit_Click);
      this.btnReportPdf.Click += new EventHandler(this.btnReportPdf_Click);
      this.Reset1.ServerClick += new EventHandler(this.Reset1_ServerClick);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void ScriptReportPdf(string strQuery) => this.Page.RegisterStartupScript("funz", "<script language=\"javascript\">\n" + ("ApriPopUp(\"" + strQuery + "\")") + "</script>\n");

    private void S_BtnSubmit_Click(object sender, EventArgs e)
    {
      this.LoadList();
      this.DisplayReport();
    }

    private string queryString()
    {
      GenetoreQryStr genetoreQryStr = new GenetoreQryStr();
      string str = "";
      bool flag = true;
      foreach (ListItem listItem in ((ListControl) this.S_ListEdifici).Items)
      {
        if (flag)
        {
          if (listItem.Text != "")
          {
            str = str + "'" + listItem.Text.Replace("(", "").Replace(")", "").Split(' ')[0] + "'";
            flag = false;
          }
        }
        else
          str = str + ",'" + listItem.Text.Replace("(", "").Replace(")", "").Split(' ')[0] + "'";
      }
      genetoreQryStr.Add((object) str, "stringaEdifici");
      genetoreQryStr.Add((object) ((TextBox) this.s_txtReparto).Text, "stringaReparto");
      genetoreQryStr.Add((object) ((TextBox) this.s_txtDestinazione).Text, "stringaDestinazione");
      genetoreQryStr.Add((object) ((ListControl) this.cmbsCategoria).SelectedValue, "idCategoria");
      genetoreQryStr.Add((object) ((ListControl) this.cmbsCategoria).SelectedItem.Text, "stringaCategoria");
      genetoreQryStr.Add((object) this.UserStanze1.DescStanza, "stringaStanza");
      genetoreQryStr.Add((object) this.UserStanze1.IdStanza, "stanza");
      genetoreQryStr.Add((object) ((ListControl) this.cmbsPiano).SelectedValue, "piano");
      genetoreQryStr.Add((object) ((ListControl) this.cmbsPiano).SelectedItem.Text, "lblpiano");
      genetoreQryStr.Add((object) ((ListControl) this.cmbsConfronto).SelectedValue, "operatoreMq");
      genetoreQryStr.Add((object) ((TextBox) this.s_txtMq).Text, "ValoreMq");
      genetoreQryStr.Add((object) ((CheckBox) this.S_Categorie).Checked, "S_Categorie");
      genetoreQryStr.Add((object) ((CheckBox) this.S_Destinazione).Checked, "S_Destinazione");
      genetoreQryStr.Add((object) ((CheckBox) this.S_Reparti).Checked, "S_Reparti");
      genetoreQryStr.Add((object) ((CheckBox) this.S_Misure).Checked, "S_Misure");
      return genetoreQryStr.TotQueryString().ToString();
    }

    private void DisplayReport()
    {
      this.urlRpt = "DisplayReportSpazi.aspx" + this.queryString() + "tipoDocumento=HTML";
      this.Server.Transfer(this.urlRpt);
    }

    private void btnReportPdf_Click(object sender, EventArgs e)
    {
      this.LoadList();
      this.ScriptReportPdf("DisplayReportSpazi.aspx" + this.queryString() + "tipoDocumento=PDF");
    }

    public int IdComune
    {
      get => this.ViewState[nameof (IdComune)] != null ? (int) this.ViewState[nameof (IdComune)] : 0;
      set => this.ViewState.Add(nameof (IdComune), (object) value);
    }

    public int IdFrazione
    {
      get => this.ViewState[nameof (IdFrazione)] != null ? (int) this.ViewState[nameof (IdFrazione)] : 0;
      set => this.ViewState.Add(nameof (IdFrazione), (object) value);
    }

    private void LoadComune()
    {
    }

    private void SetProperty()
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      TheSite.ReportGestioneSpazi.ReportGestioneSpazi.FunId = siteModule.ModuleId;
      TheSite.ReportGestioneSpazi.ReportGestioneSpazi.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = "Report e Grafici delle Superfici";
      ((WebControl) this.S_ListEdifici).Attributes.Add("onkeydown", "deleteitem(this,event);");
      ((WebControl) this.S_ListEdifici).Attributes.Add("onDblClick", "deleteitem2(this,event);");
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("if (typeof(errorlist) == 'function') { ");
      stringBuilder.Append("if (errorlist('" + ((Control) this.S_ListEdifici).ClientID + "') == false) { return false; }} ");
      stringBuilder.Append("if (errorlist('" + ((Control) this.S_ListEdifici).ClientID + "') == false) { return false; } ");
      stringBuilder.Append("this.value = 'Attendere ...';");
      stringBuilder.Append("this.disabled = true;");
    }

    private void LoadList()
    {
      Console.WriteLine(this.edifici.Value);
      string[] strArray1 = this.edificidescription.Value.Split('$');
      string[] strArray2 = this.edifici.Value.Split(',');
      ((ListControl) this.S_ListEdifici).Items.Clear();
      int index = 0;
      foreach (string str in strArray2)
      {
        ((ListControl) this.S_ListEdifici).Items.Add(new ListItem(strArray1[index], str));
        ++index;
      }
    }

    private void BindingEdifici(string BlId)
    {
      BlId = "'" + BlId.Replace(",", "','") + "'";
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(4000);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) BlId);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_servizio_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_idapparecchiatura");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) "");
      CollezioneControlli.Add(sObject3);
      new ServiziEdifici(this.Context.User.Identity.Name).GetData(CollezioneControlli);
    }

    private TreeNodeCollection AddNodesServizi(
      DataRow Dr,
      TreeNodeCollection nodes)
    {
      string values = Dr["ID"].ToString() + "&servizio_id=" + Dr["servizi_id"].ToString();
      nodes.Add(this.Node(Dr["DESCRIZIONE"].ToString(), "servizio", values, true, true));
      return nodes;
    }

    private TreeNodeCollection AddTipoApparecchiatura(
      DataRow Dr,
      TreeNodeCollection nodes)
    {
      string text = Dr["eq_std"].ToString() + " " + Dr["family_description"].ToString();
      nodes.Add(this.Node(text, "apparecchaiture", "", false, false));
      return nodes;
    }

    private void AddApparecchiatura(DataRow Dr, TreeNodeCollection nodes)
    {
      string text = Dr["eq_std"].ToString() + " " + Dr["EQ_ID"].ToString();
      nodes.Add(this.Node(text, "apparecchiatura", Dr["EQ_ID"].ToString(), true, false));
    }

    private DataRowCollection DatiEdificio(int bl_id)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      return new ServiziEdifici(this.Context.User.Identity.Name).GetSingleData(bl_id).Tables[0].Rows;
    }

    private TreeNode Node(
      string text,
      string type,
      string values,
      bool setnav,
      bool servizio)
    {
      TreeNode treeNode = new TreeNode();
      treeNode.set_Type(type);
      treeNode.set_Text(text);
      string empty = string.Empty;
      if (!setnav)
      {
        treeNode.set_NavigateUrl("");
        ((TreeBase) treeNode).set_Target("");
      }
      else
      {
        string str = !servizio ? "SchedaApparecchiatura.aspx?eq_id=" + values : "ServiceDettail.aspx?bl_id=" + values;
        treeNode.set_NavigateUrl(str);
        ((TreeBase) treeNode).set_Target("doctrevew");
      }
      return treeNode;
    }

    private TreeNodeCollection NodeCollection() => this.TreeCtrl.get_Nodes().get_Item(((CollectionBase) this.TreeCtrl.get_Nodes()).Count - 1).get_Nodes();

    private void SetStyleTreeVieew()
    {
      ((CollectionBase) this.TreeCtrl.get_Nodes()).Clear();
      ((WebControl) this.TreeCtrl).Style.Add("SCROLLBAR-3DLIGHT-COLOR", "darkgray");
      ((WebControl) this.TreeCtrl).Style.Add("SCROLLBAR-ARROW-COLOR", "darkgray");
      ((WebControl) this.TreeCtrl).Style.Add("CROLLBAR-TRACK-COLOR", "lightslategray");
      ((WebControl) this.TreeCtrl).Style.Add("SCROLLBAR-BASE-COLOR", "lightslategray");
      ((WebControl) this.TreeCtrl).Style.Add("HEIGHT", "95%");
      string str = "../images/treeimages/";
      TreeNodeType treeNodeType1 = new TreeNodeType();
      treeNodeType1.set_Type("edifici");
      ((TreeBase) treeNodeType1).set_ImageUrl(str + "gnome-fs-home.gif");
      ((TreeBase) treeNodeType1).set_ExpandedImageUrl(str + "gnome-fs-home.gif");
      this.TreeCtrl.get_TreeNodeTypes().Add(treeNodeType1);
      TreeNodeType treeNodeType2 = new TreeNodeType();
      treeNodeType2.set_Type("edificio");
      ((TreeBase) treeNodeType2).set_ImageUrl(str + "gnome-fs-home.gif");
      ((TreeBase) treeNodeType2).set_ExpandedImageUrl(str + "gnome-fs-home.gif");
      this.TreeCtrl.get_TreeNodeTypes().Add(treeNodeType2);
      TreeNodeType treeNodeType3 = new TreeNodeType();
      treeNodeType3.set_Type("servizio");
      ((TreeBase) treeNodeType3).set_ImageUrl(str + "gnome-mime-text-x-sh.gif");
      ((TreeBase) treeNodeType3).set_ExpandedImageUrl(str + "gnome-mime-text-x-sh.gif");
      this.TreeCtrl.get_TreeNodeTypes().Add(treeNodeType3);
      TreeNodeType treeNodeType4 = new TreeNodeType();
      treeNodeType4.set_Type("apparecchaiture");
      ((TreeBase) treeNodeType4).set_ImageUrl(str + "gnome-desktop-config.gif");
      ((TreeBase) treeNodeType4).set_ExpandedImageUrl(str + "gnome-desktop-config.gif");
      this.TreeCtrl.get_TreeNodeTypes().Add(treeNodeType4);
      TreeNodeType treeNodeType5 = new TreeNodeType();
      treeNodeType5.set_Type("apparecchiatura");
      ((TreeBase) treeNodeType5).set_ImageUrl(str + "gnome-desktop-config.gif");
      ((TreeBase) treeNodeType5).set_ExpandedImageUrl(str + "gnome-desktop-config.gif");
      this.TreeCtrl.get_TreeNodeTypes().Add(treeNodeType5);
    }

    private void cmbsServizio_SelectedIndexChanged(object sender, EventArgs e) => this.LoadList();

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

    private void BindTutteCategorie()
    {
      ((ListControl) this.cmbsCategoria).Items.Clear();
      DataSet data = new Categorie().GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsCategoria).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "CATEGORIA", "ID", "- Selezionare la Categoria -", "");
        ((ListControl) this.cmbsCategoria).DataTextField = "CATEGORIA";
        ((ListControl) this.cmbsCategoria).DataValueField = "ID";
        ((Control) this.cmbsCategoria).DataBind();
      }
      else
        ((ListControl) this.cmbsCategoria).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Categoria -", string.Empty));
    }

    private void Reset1_ServerClick(object sender, EventArgs e) => this.Response.Redirect("ReportGestioneSpazi.aspx?FunId=" + this.ViewState["FunId"]);

    private enum ValidateDate
    {
      notPostBack,
      PostBack,
    }
  }
}
