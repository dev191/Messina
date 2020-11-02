// Decompiled with JetBrains decompiler
// Type: TheSite.AnagrafeImpianti.ServiziEdifici
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Microsoft.Web.UI.WebControls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TheSite.AnagrafeImpianti
{
  public class ServiziEdifici : Page
  {
    protected TreeView TreeCtrl;
    protected HtmlGenericControl doc;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack || this.Context.Items[(object) "edifici"] == null)
        return;
      this.BindingEdifici((string) this.Context.Items[(object) "edifici"]);
    }

    private void BindingEdifici(string BlId)
    {
      BlId = "'" + BlId.Replace(",", "','") + "'";
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_Bl_Id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Size(4000);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) BlId);
      CollezioneControlli.Add(sObject);
      DataSet data = new TheSite.Classi.AnagrafeImpianti.ServiziEdifici(this.Context.User.Identity.Name).GetData(CollezioneControlli);
      if (data.Tables[0].Rows.Count <= 0)
        return;
      this.PopolaTreeview(data);
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
        string empty = string.Empty;
        string str = string.Empty;
        TreeNodeCollection treeNodeCollection1 = (TreeNodeCollection) null;
        TreeNodeCollection treeNodeCollection2 = (TreeNodeCollection) null;
        foreach (DataRow Dr in (InternalDataCollectionBase) dataRowCollection)
        {
          if (empty != Dr["descrizione"].ToString())
          {
            str = "";
            treeNodeCollection2 = (TreeNodeCollection) null;
            empty = Dr["descrizione"].ToString();
            treeNodeCollection1 = this.AddNodesServizi(Dr, this.NodeCollection());
          }
          if (Dr["family_description"] != DBNull.Value)
          {
            if (str != Dr["family_description"].ToString())
            {
              str = Dr["family_description"].ToString();
              treeNodeCollection2 = this.AddTipoApparecchiatura(Dr, treeNodeCollection1.get_Item(((CollectionBase) treeNodeCollection1).Count - 1).get_Nodes());
            }
            this.AddApparecchiatura(Dr, treeNodeCollection2.get_Item(((CollectionBase) treeNodeCollection2).Count - 1).get_Nodes());
          }
        }
      }
    }

    private TreeNodeCollection AddNodesServizi(
      DataRow Dr,
      TreeNodeCollection nodes)
    {
      nodes.Add(this.Node(Dr["DESCRIZIONE"].ToString(), "servizio", "", false));
      return nodes;
    }

    private TreeNodeCollection AddTipoApparecchiatura(
      DataRow Dr,
      TreeNodeCollection nodes)
    {
      string text = Dr["eq_std"].ToString() + " " + Dr["family_description"].ToString();
      nodes.Add(this.Node(text, "apparecchaiture", "", false));
      return nodes;
    }

    private void AddApparecchiatura(DataRow Dr, TreeNodeCollection nodes)
    {
      string text = Dr["eq_std"].ToString() + " " + Dr["EQ_ID"].ToString();
      nodes.Add(this.Node(text, "apparecchiatura", Dr["EQ_ID"].ToString(), true));
    }

    private DataRowCollection DatiEdificio(int bl_id)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      return new TheSite.Classi.AnagrafeImpianti.ServiziEdifici(this.Context.User.Identity.Name).GetSingleData(bl_id).Tables[0].Rows;
    }

    private TreeNode Node(string text, string type, string values, bool setnav)
    {
      TreeNode treeNode = new TreeNode();
      treeNode.set_Type(type);
      treeNode.set_Text(text);
      string str = "SchedaApparecchiatura.aspx?eq_id=" + values;
      if (!setnav)
      {
        treeNode.set_NavigateUrl("");
        ((TreeBase) treeNode).set_Target("");
      }
      else
      {
        treeNode.set_NavigateUrl(str);
        ((TreeBase) treeNode).set_Target("doc");
      }
      return treeNode;
    }

    private TreeNodeCollection NodeCollection() => this.TreeCtrl.get_Nodes().get_Item(((CollectionBase) this.TreeCtrl.get_Nodes()).Count - 1).get_Nodes();

    private void SetStyleTreeVieew()
    {
      ((WebControl) this.TreeCtrl).Style.Add("SCROLLBAR-3DLIGHT-COLOR", "darkgray");
      ((WebControl) this.TreeCtrl).Style.Add("SCROLLBAR-ARROW-COLOR", "darkgray");
      ((WebControl) this.TreeCtrl).Style.Add("CROLLBAR-TRACK-COLOR", "#666666");
      ((WebControl) this.TreeCtrl).Style.Add("SCROLLBAR-BASE-COLOR", "#666666");
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

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
