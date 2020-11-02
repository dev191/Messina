// Decompiled with JetBrains decompiler
// Type: TheSite.Admin.RuoliEdificiServizi
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ClassiDettaglio;

namespace TheSite.Admin
{
  public class RuoliEdificiServizi : Page
  {
    protected Label lblOperazione;
    protected MessagePanel PanelMess;
    protected S_TextBox txtsCodice;
    protected S_TextBox txtsCampus;
    protected S_ComboBox cmbsProvincia;
    protected S_ComboBox cmbsComune;
    protected S_ComboBox cmbsServizi;
    protected Button BtnFiltra;
    protected S_ComboBox cmbsDitta;
    protected S_Button btnsSalva;
    protected Button btnAnnulla;
    protected Panel PanelEdit;
    private int itemId = 0;
    protected TreeView TreeCtrl;
    protected Label LblEdifici;
    protected Label LblRuolo;
    protected RadioButtonList OptFiltro;
    protected CheckBox ChkSelezionaLeft;
    private string descrizione = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.Request.Params["ItemId"] != null)
        this.itemId = int.Parse(this.Request.Params["ItemId"]);
      if (this.Request.Params["descr"] != null)
        this.descrizione = this.Request.Params["descr"];
      if (this.Page.IsPostBack)
        return;
      this.LblRuolo.Text = this.descrizione;
      this.BindProvince();
      this.BindDitte();
      this.BindServizi();
      if (((ListControl) this.cmbsProvincia).SelectedIndex >= 1)
        this.BindComuni();
      this.lblOperazione.Text = "Associazione Ruoli Edifici Servizi";
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
    }

    private void CaricaAlbero()
    {
      this.txtsCampus.set_DBDefaultValue((object) "%");
      this.txtsCodice.set_DBDefaultValue((object) "%");
      this.cmbsProvincia.set_DBDefaultValue((object) "0");
      this.cmbsComune.set_DBDefaultValue((object) "0");
      this.cmbsServizi.set_DBDefaultValue((object) "0");
      this.cmbsDitta.set_DBDefaultValue((object) "0");
      ((TextBox) this.txtsCampus).Text = ((TextBox) this.txtsCampus).Text.Trim();
      ((TextBox) this.txtsCodice).Text = ((TextBox) this.txtsCodice).Text.Trim();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      Edificio edificio = new Edificio(this.Context.User.Identity.Name);
      DataSet Ds = (DataSet) null;
      if (this.OptFiltro.Items[0].Selected)
        Ds = edificio.GetRuoliEdifici(CollezioneControlli, this.itemId, "Tutti");
      if (this.OptFiltro.Items[1].Selected)
        Ds = edificio.GetRuoliEdifici(CollezioneControlli, this.itemId, "Associati");
      if (this.OptFiltro.Items[2].Selected)
        Ds = edificio.GetRuoliEdifici(CollezioneControlli, this.itemId, "NonAssociati");
      if (Ds.Tables[0].Rows.Count > 0)
      {
        ((Control) this.TreeCtrl).Visible = true;
        this.ChkSelezionaLeft.Visible = true;
        this.PopolaTreeview(Ds);
      }
      else
      {
        ((Control) this.TreeCtrl).Visible = false;
        this.ChkSelezionaLeft.Visible = false;
      }
      this.LblEdifici.Text = Ds.Tables[0].Rows.Count.ToString();
      this.ImpostaCheck();
    }

    private void BindServizi()
    {
      DataSet dataSet = new Servizi(HttpContext.Current.User.Identity.Name).GetData().Copy();
      ((ListControl) this.cmbsServizi).Items.Clear();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsServizi).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "idservizio", "- Selezionare un Servizio -", "");
      ((ListControl) this.cmbsServizi).DataTextField = "descrizione";
      ((ListControl) this.cmbsServizi).DataValueField = "idservizio";
      ((Control) this.cmbsServizi).DataBind();
    }

    private void BindDitte()
    {
      DataSet dataSet = new Ditte().GetData().Copy();
      ((ListControl) this.cmbsDitta).Items.Clear();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsDitta).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "id", "- Selezionare una Ditta -", "");
      ((ListControl) this.cmbsDitta).DataTextField = "descrizione";
      ((ListControl) this.cmbsDitta).DataValueField = "id";
      ((Control) this.cmbsDitta).DataBind();
    }

    private void ImpostaProvinciaDefault(string provincia, string comune)
    {
      ((ListControl) this.cmbsProvincia).SelectedValue = ((ListControl) this.cmbsProvincia).Items.FindByText(provincia).Value;
      this.BindComuni();
      ((ListControl) this.cmbsComune).SelectedValue = ((ListControl) this.cmbsComune).Items.FindByText(comune).Value;
    }

    private void BindProvince()
    {
      ((ListControl) this.cmbsProvincia).Items.Clear();
      DataSet dataSet = new ProvinceComuni().GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsProvincia).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione_breve", "provincia_id", "- Selezionare una Provincia -", "");
      ((ListControl) this.cmbsProvincia).DataTextField = "descrizione_breve";
      ((ListControl) this.cmbsProvincia).DataValueField = "provincia_id";
      ((Control) this.cmbsProvincia).DataBind();
    }

    private void ImpostaCheck()
    {
      this.ChkSelezionaLeft.Checked = false;
      this.ChkSelezionaLeft.Text = "Seleziona Tutti";
    }

    private void BindComuni()
    {
      ((ListControl) this.cmbsComune).Items.Clear();
      ProvinceComuni provinceComuni = new ProvinceComuni();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_provincia_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) ((ListControl) this.cmbsProvincia).SelectedValue);
      CollezioneControlli.Add(sObject);
      DataSet dataSet = provinceComuni.GetComune(CollezioneControlli).Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsComune).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "comune_id", "- Selezionare un Comune -", "");
      ((ListControl) this.cmbsComune).DataTextField = "descrizione";
      ((ListControl) this.cmbsComune).DataValueField = "comune_id";
      ((Control) this.cmbsComune).DataBind();
    }

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
    }

    private void PopolaTreeview(DataSet Ds)
    {
      this.SetStyleTreeVieew();
      foreach (DataRow row in (InternalDataCollectionBase) Ds.Tables[0].Rows)
      {
        TreeNode treeNode = new TreeNode();
        treeNode.set_Type("edificio");
        treeNode.set_Expanded(true);
        string str = row["DESCRIZIONE"].ToString();
        treeNode.set_Text(str);
        ((TreeBase) treeNode).set_Target(row["ID"].ToString());
        this.TreeCtrl.get_Nodes().Add(treeNode);
        foreach (DataRow Dr in (InternalDataCollectionBase) this.DatiEdificio(int.Parse(row["ID"].ToString())))
          this.AddNodesServizi(((TreeBase) treeNode).get_Target(), Dr, this.NodeCollection());
      }
    }

    private TreeNodeCollection AddNodesServizi(
      string id_bl,
      DataRow Dr,
      TreeNodeCollection nodes)
    {
      TreeNode treeNode = new TreeNode();
      treeNode.set_Type("servizio");
      treeNode.set_Text(Dr["DESCRIZIONE"].ToString());
      ((TreeBase) treeNode).set_Target(Dr["ID"].ToString());
      ((TreeBase) treeNode).set_CheckBox(true);
      bool flag = new Edificio(this.Context.User.Identity.Name).ControllaRuoloBlServizi(this.itemId, int.Parse(id_bl), int.Parse(((TreeBase) treeNode).get_Target()));
      treeNode.set_Checked(flag);
      nodes.Add(treeNode);
      return nodes;
    }

    private DataRowCollection DatiEdificio(int bl_id)
    {
      int servizio_id = 0;
      if (((ListControl) this.cmbsServizi).SelectedValue != "")
        servizio_id = int.Parse(((ListControl) this.cmbsServizi).SelectedValue);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      return new Servizi().GetServiziEdifici(bl_id, servizio_id).Tables[0].Rows;
    }

    private TreeNodeCollection NodeCollection() => this.TreeCtrl.get_Nodes().get_Item(((CollectionBase) this.TreeCtrl.get_Nodes()).Count - 1).get_Nodes();

    private void ControllaCheck(string Operazione)
    {
      foreach (TreeNode node in (CollectionBase) this.TreeCtrl.get_Nodes())
      {
        if (((CollectionBase) node.get_Nodes()).Count > 0)
        {
          switch (Operazione)
          {
            case "Seleziona":
              this.ImpostaNodi(node, node.get_Nodes(), true);
              continue;
            case "Deseleziona":
              this.ImpostaNodi(node, node.get_Nodes(), false);
              continue;
            case "Salva":
              this.Salva(node, node.get_Nodes());
              continue;
            default:
              continue;
          }
        }
      }
    }

    private void ImpostaNodi(TreeNode nodopadre, TreeNodeCollection nodi, bool val)
    {
      foreach (TreeNode nodus in (CollectionBase) nodi)
        nodus.set_Checked(val);
    }

    private void Salva(TreeNode nodopadre, TreeNodeCollection nodi)
    {
      int bl_id = int.Parse(((TreeBase) nodopadre).get_Target());
      nodopadre.get_Text();
      this.EliminaAssociazioni(bl_id);
      foreach (TreeNode nodus in (CollectionBase) nodi)
      {
        if (nodus.get_Checked())
        {
          int num = int.Parse(((TreeBase) nodus).get_Target());
          nodus.get_Text();
          Edificio edificio = new Edificio(this.Context.User.Identity.Name);
          S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
          S_Object sObject1 = new S_Object();
          ((ParameterObject) sObject1).set_ParameterName("p_Ruolo_Id");
          ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject1).set_Index(0);
          ((ParameterObject) sObject1).set_Value((object) this.itemId);
          S_Object sObject2 = new S_Object();
          ((ParameterObject) sObject2).set_ParameterName("p_Edificio_Id");
          ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject2).set_Index(1);
          ((ParameterObject) sObject2).set_Value((object) bl_id);
          S_Object sObject3 = new S_Object();
          ((ParameterObject) sObject3).set_ParameterName("p_Servizio_Id");
          ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject3).set_Index(2);
          ((ParameterObject) sObject3).set_Value((object) num);
          S_Object sObject4 = new S_Object();
          ((ParameterObject) sObject4).set_ParameterName("p_Operazione");
          ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
          ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject4).set_Index(3);
          ((ParameterObject) sObject4).set_Value((object) "Insert");
          S_Object sObject5 = new S_Object();
          ((ParameterObject) sObject5).set_ParameterName("p_IdOut");
          ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject5).set_Direction(ParameterDirection.Output);
          ((ParameterObject) sObject5).set_Index(4);
          CollezioneControlli.Add(sObject1);
          CollezioneControlli.Add(sObject2);
          CollezioneControlli.Add(sObject3);
          CollezioneControlli.Add(sObject4);
          CollezioneControlli.Add(sObject5);
          edificio.UpdateRuoliEdificiServizi(CollezioneControlli);
        }
      }
    }

    private void EliminaAssociazioni(int bl_id)
    {
      Edificio edificio = new Edificio(this.Context.User.Identity.Name);
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Ruolo_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) this.itemId);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Edificio_Id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) bl_id);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_Servizio_Id");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) 0);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_Operazione");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) "Delete");
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_IdOut");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject5).set_Index(4);
      CollezioneControlli.Add(sObject1);
      CollezioneControlli.Add(sObject2);
      CollezioneControlli.Add(sObject3);
      CollezioneControlli.Add(sObject4);
      CollezioneControlli.Add(sObject5);
      edificio.UpdateRuoliEdificiServizi(CollezioneControlli);
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.ChkSelezionaLeft.CheckedChanged += new EventHandler(this.ChkSelezionaLeft_CheckedChanged);
      ((ListControl) this.cmbsProvincia).SelectedIndexChanged += new EventHandler(this.cmbsProvincia_SelectedIndexChanged);
      this.OptFiltro.SelectedIndexChanged += new EventHandler(this.OptFiltro_SelectedIndexChanged);
      this.BtnFiltra.Click += new EventHandler(this.BtnFiltra_Click);
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void cmbsProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (((ListControl) this.cmbsProvincia).SelectedIndex > 0)
        this.BindComuni();
      else
        ((ListControl) this.cmbsComune).Items.Clear();
    }

    private void BtnFiltra_Click(object sender, EventArgs e) => this.CaricaAlbero();

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Response.Redirect((string) this.ViewState["UrlReferrer"]);

    private void ChkSelezionaLeft_CheckedChanged(object sender, EventArgs e)
    {
      if (this.ChkSelezionaLeft.Checked)
      {
        this.ControllaCheck("Seleziona");
        this.ChkSelezionaLeft.Text = "Deseleziona Tutti";
      }
      else
      {
        this.ControllaCheck("Deseleziona");
        this.ChkSelezionaLeft.Text = "Seleziona Tutti";
      }
    }

    private void btnsSalva_Click(object sender, EventArgs e) => this.ControllaCheck("Salva");

    private void OptFiltro_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
  }
}
