// Decompiled with JetBrains decompiler
// Type: TheSite.AnagrafeImpianti.NavigazioneServizi
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
using TheSite.Classi.ClassiDettaglio;
using TheSite.WebControls;

namespace TheSite.AnagrafeImpianti
{
  public class NavigazioneServizi : Page
  {
    protected S_ComboBox cmbsApparecchiatura;
    protected HtmlForm Form1;
    protected S_ListBox S_ListEdifici;
    protected S_ComboBox cmbsServizio;
    protected S_Button S_btMostra;
    protected HtmlInputHidden edifici;
    protected HtmlInputHidden edificidescription;
    protected DataPanel DataPanel1;
    protected RicercaModulo RicercaModulo1;
    protected PageTitle PageTitle1;
    protected TreeView TreeCtrl;
    protected HtmlGenericControl doctrevew;
    protected Panel Panel1;
    protected S_Label lblComuneDescrizione;
    protected S_Label lblComune;
    protected S_TextBox S_txtnomefile;
    protected S_TextBox S_txtdescrizione;
    protected S_ComboBox S_CbCategoria;
    protected S_ComboBox S_CmbTipologia;
    protected S_Button S_btRicerca;
    protected DataGrid DataGrid1;
    protected S_Button btReset;
    public static string HelpLink = string.Empty;
    protected S_Label lblFrazione;
    protected S_Label lblFrazioneDescrizione;
    protected S_ComboBox S_ComboBox1;
    public static int FunId = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("document.getElementById('" + ((Control) this.cmbsApparecchiatura).ClientID + "').disabled = true;");
      ((WebControl) this.cmbsServizio).Attributes.Add("onchange", stringBuilder.ToString());
      ((WebControl) this.S_ListEdifici).Attributes.Add("title", "Premere il tasto canc per eliminare un elemento dalla lista.");
      this.SetProperty();
      if (!this.IsPostBack)
      {
        if (this.Request.QueryString["FunId"] != null)
          this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
        this.Panel1.Visible = false;
        this.BindServizio("0");
        this.BindApparecchiatura();
        if (this.Request.QueryString["idcomune"] != null)
          this.IdComune = int.Parse(this.Request.QueryString["idcomune"]);
        if (this.Request.QueryString["idfrazione"] != null)
          this.IdFrazione = int.Parse(this.Request.QueryString["idfrazione"]);
        this.LoadComune();
      }
      this.RicercaModulo1.multisele = "y&id_comune=" + this.IdComune.ToString() + "&id_frazione=" + this.IdFrazione.ToString();
      this.RicercaModulo1.visualizzadettagli = false;
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
      if (this.IdComune == 0)
        return;
      DataSet comuneFrazione = new TheSite.Classi.AnagrafeImpianti.ServiziEdifici(this.Context.User.Identity.Name).GetComuneFrazione(this.IdComune, this.IdFrazione);
      if (comuneFrazione.Tables[0].Rows.Count > 0)
      {
        ((Control) this.lblComuneDescrizione).Visible = true;
        ((Control) this.lblComune).Visible = true;
        ((Label) this.lblComune).Text = comuneFrazione.Tables[0].Rows[0]["descrizionec"].ToString();
        if (comuneFrazione.Tables[0].Rows[0]["descrizionef"] == DBNull.Value || this.IdFrazione <= 0)
          return;
        ((Control) this.lblFrazioneDescrizione).Visible = true;
        ((Control) this.lblFrazione).Visible = true;
        ((Label) this.lblFrazione).Text = comuneFrazione.Tables[0].Rows[0]["descrizionef"].ToString();
      }
      else
      {
        ((Control) this.lblComuneDescrizione).Visible = false;
        ((Control) this.lblComune).Visible = false;
        ((Label) this.lblComune).Text = "";
        ((Control) this.lblFrazioneDescrizione).Visible = false;
        ((Control) this.lblFrazione).Visible = false;
        ((Label) this.lblFrazione).Text = "";
      }
    }

    private void SetProperty()
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      NavigazioneServizi.FunId = siteModule.ModuleId;
      NavigazioneServizi.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      ((WebControl) this.S_ListEdifici).Attributes.Add("onkeydown", "deleteitem(this,event);");
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("if (typeof(errorlist) == 'function') { ");
      stringBuilder.Append("if (errorlist('" + ((Control) this.S_ListEdifici).ClientID + "') == false) { return false; }} ");
      stringBuilder.Append("if (errorlist('" + ((Control) this.S_ListEdifici).ClientID + "') == false) { return false; } ");
      stringBuilder.Append("this.value = 'Attendere ...';");
      stringBuilder.Append("this.disabled = true;");
      stringBuilder.Append("document.getElementById('" + ((Control) this.S_btMostra).ClientID + "').disabled = true;");
      stringBuilder.Append(this.Page.GetPostBackEventReference((Control) this.S_btMostra));
      stringBuilder.Append(";");
      ((WebControl) this.S_btMostra).Attributes.Add("onclick", stringBuilder.ToString());
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
      ((Button) this.btReset).Click += new EventHandler(this.btReset_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void S_btMostra_Click(object sender, EventArgs e)
    {
      this.LoadList();
      this.BindingEdifici(this.edifici.Value);
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
      ((ParameterObject) sObject2).set_Value((object) (((ListControl) this.cmbsServizio).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsServizio).SelectedValue)));
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_idapparecchiatura");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) (((ListControl) this.cmbsApparecchiatura).SelectedValue == string.Empty ? 0 : int.Parse(((ListControl) this.cmbsApparecchiatura).SelectedValue)));
      CollezioneControlli.Add(sObject3);
      DataSet data = new TheSite.Classi.AnagrafeImpianti.ServiziEdifici(this.Context.User.Identity.Name).GetData(CollezioneControlli);
      if (data.Tables[0].Rows.Count > 0)
      {
        this.PopolaTreeview(data);
        this.Panel1.Visible = true;
      }
      else
        this.Panel1.Visible = false;
    }

    private void PopolaTreeview(DataSet Ds)
    {
      this.SetStyleTreeVieew();
      foreach (DataRow row in (InternalDataCollectionBase) Ds.Tables[0].Rows)
      {
        TreeNode treeNode = new TreeNode();
        treeNode.set_Type("edificio");
        treeNode.set_Text(string.Format("({0}) {1}", row["BL_ID"], row["DENOMINAZIONE"]));
        treeNode.set_NavigateUrl("");
        ((TreeBase) treeNode).set_Target("");
        this.TreeCtrl.get_Nodes().Add(treeNode);
        DataRowCollection dataRowCollection = this.DatiEdificio(int.Parse(row["ID"].ToString()));
        string empty1 = string.Empty;
        string empty2 = string.Empty;
        foreach (DataRow Dr in (InternalDataCollectionBase) dataRowCollection)
        {
          if ((Dr["servizi_id"].ToString() == ((ListControl) this.cmbsServizio).SelectedValue || ((ListControl) this.cmbsServizio).SelectedIndex == 0) && empty1 != Dr["descrizione"].ToString())
          {
            empty1 = Dr["descrizione"].ToString();
            this.AddNodesServizi(Dr, this.NodeCollection());
          }
        }
      }
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
      return new TheSite.Classi.AnagrafeImpianti.ServiziEdifici(this.Context.User.Identity.Name).GetSingleData(bl_id).Tables[0].Rows;
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

    private void BindServizio(string CodEdificio)
    {
      int idprog = 0;
      if (this.Request.QueryString["VarApp"] != null)
        idprog = Convert.ToInt32(this.Request.QueryString["VarApp"].ToString());
      ((ListControl) this.cmbsServizio).Items.Clear();
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet serviziPerProg = new Servizi(this.Context.User.Identity.Name).GetServiziPerProg(idprog, 0);
      if (serviziPerProg.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsServizio).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(serviziPerProg.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "");
        ((ListControl) this.cmbsServizio).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsServizio).DataValueField = "IDSERVIZIO";
        ((Control) this.cmbsServizio).DataBind();
      }
      else
        ((ListControl) this.cmbsServizio).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Servizio -", string.Empty));
    }

    private void BindApparecchiatura()
    {
      if (((ListControl) this.cmbsServizio).SelectedValue != "")
      {
        ((ListControl) this.cmbsApparecchiatura).Items.Clear();
        Apparecchiature apparecchiature = new Apparecchiature(this.Context.User.Identity.Name);
        DataSet dataSet;
        if (!this.IsPostBack)
        {
          dataSet = apparecchiature.GetData();
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
          ((ParameterObject) sObject1).set_Value((object) "");
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
          ((ListControl) this.cmbsApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuno Standard -", string.Empty));
      }
      else
        ((ListControl) this.cmbsApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuno Standard -", string.Empty));
    }

    private void cmbsServizio_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.LoadList();
      this.BindApparecchiatura();
    }

    private void btReset_Click(object sender, EventArgs e) => this.Response.Redirect("NavigazioneServizi.aspx?FunId=" + this.ViewState["FunId"]);
  }
}
