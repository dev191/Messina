// Decompiled with JetBrains decompiler
// Type: WebCad.WebControls.WebUserControlTreeView
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Microsoft.Web.UI.WebControls;
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebCad.WiewCad;

namespace WebCad.WebControls
{
  public class WebUserControlTreeView : UserControl
  {
    private Edifici _edifici;
    protected TreeView TreeCtrl;

    private void Page_Load(object sender, EventArgs e)
    {
    }

    public string GetClientId() => ((Control) this.TreeCtrl).ClientID;

    public string getSelectedEdificio() => this.TreeCtrl.get_Nodes().get_Item(int.Parse(this.TreeCtrl.get_SelectedNodeIndex())).get_NodeData().Split(';')[0];

    public string getSelectedPiano() => this.TreeCtrl.get_Nodes().get_Item(int.Parse(this.TreeCtrl.get_SelectedNodeIndex())).get_Nodes().get_Item(int.Parse(this.TreeCtrl.get_SelectedNodeIndex())).get_NodeData().Split(';')[1];

    public void BindData(DataSet Ds)
    {
      int count = Ds.Tables[0].Rows.Count;
      this.riempiAlber(Ds);
    }

    private void riempiAlber(DataSet Ds)
    {
      if (this._edifici == null)
        this._edifici = new Edifici();
      this.SetStyleTreeVieew();
      DataRowCollection rows = Ds.Tables[0].Rows;
      int num1 = 0;
      foreach (DataRow dataRow1 in (InternalDataCollectionBase) rows)
      {
        TreeNode treeNode1 = new TreeNode();
        treeNode1.set_Type("edifici");
        treeNode1.set_Text(string.Format("({0}) {1}", dataRow1["ID_BL"], dataRow1["EDIFICIO"]));
        treeNode1.set_NodeData(dataRow1["ID_BL"].ToString());
        treeNode1.set_NavigateUrl("");
        ((TreeBase) treeNode1).set_Target("");
        this.TreeCtrl.get_Nodes().Add(treeNode1);
        foreach (DataRow dataRow2 in (InternalDataCollectionBase) this.DatiEdificio(int.Parse(dataRow1["ID_BL"].ToString())))
        {
          int num2 = 0;
          TreeNode treeNode2 = new TreeNode();
          treeNode2.set_Type("piano");
          ((BaseChildNode) treeNode2).set_ID(dataRow1["ID_BL"].ToString() + "_" + dataRow2["ID_PIANI"]);
          treeNode2.set_NodeData(dataRow1["ID_BL"].ToString() + ";" + dataRow2["ID_PIANI"]);
          treeNode2.set_Text(string.Format("({0}) {1}", dataRow2["ID_PIANI"], dataRow2["DESCRIZIONE_PIANI"]));
          treeNode2.set_NavigateUrl("vbscript:SetPianoStanza(" + dataRow1["ID_BL"] + ",\"" + dataRow1["EDIFICIO"] + "\"," + dataRow2["ID_PIANI"] + ",\"" + dataRow2["DESCRIZIONE_PIANI"] + "\",\"" + ((BaseChildNode) treeNode2).get_ID() + "\")");
          ((TreeBase) treeNode2).set_Target("");
          this.TreeCtrl.get_Nodes().get_Item(num1).get_Nodes().Add(treeNode2);
          int num3 = num2 + 1;
        }
        ++num1;
      }
    }

    public void SelezionaNodo(string idBl, string idFl)
    {
      foreach (TreeNode node1 in (CollectionBase) this.TreeCtrl.get_Nodes())
      {
        if (node1.get_NodeData() == idBl)
        {
          node1.set_Expanded(true);
          foreach (TreeNode node2 in (CollectionBase) node1.get_Nodes())
          {
            if (node2.get_NodeData().Split(';').Length == 2)
            {
              if (node2.get_NodeData().Split(';')[1] == idFl)
                ((TreeBase) node2).get_DefaultStyle().Add("background", "#ff0000");
            }
          }
        }
      }
    }

    private DataRowCollection ListaEdificiDistinct()
    {
      this._edifici = new Edifici();
      return this._edifici.GetData().Tables[0].Rows;
    }

    private DataRowCollection DatiEdificio(int bl_id) => this._edifici.GetSingleData(bl_id).Tables[0].Rows;

    private void SetStyleTreeVieew()
    {
      ((CollectionBase) this.TreeCtrl.get_Nodes()).Clear();
      ((WebControl) this.TreeCtrl).Style.Add("SCROLLBAR-3DLIGHT-COLOR", "darkgray");
      ((WebControl) this.TreeCtrl).Style.Add("SCROLLBAR-ARROW-COLOR", "darkgray");
      ((WebControl) this.TreeCtrl).Style.Add("CROLLBAR-TRACK-COLOR", "lightslategray");
      ((WebControl) this.TreeCtrl).Style.Add("SCROLLBAR-BASE-COLOR", "lightslategray");
      ((WebControl) this.TreeCtrl).Style.Add("HEIGHT", "95%");
      string str = "images/treeimages/";
      TreeNodeType treeNodeType1 = new TreeNodeType();
      treeNodeType1.set_Type("edifici");
      ((TreeBase) treeNodeType1).set_ImageUrl(str + "gnome-fs-home.gif");
      ((TreeBase) treeNodeType1).set_ExpandedImageUrl(str + "gnome-fs-home.gif");
      this.TreeCtrl.get_TreeNodeTypes().Add(treeNodeType1);
      TreeNodeType treeNodeType2 = new TreeNodeType();
      treeNodeType2.set_Type("piano");
      ((TreeBase) treeNodeType2).set_ImageUrl(str + "gnome-mime-text-x-sh.gif");
      ((TreeBase) treeNodeType2).set_ExpandedImageUrl(str + "gnome-mime-text-x-sh.gif");
      ((TreeBase) treeNodeType2).get_HoverStyle().Add("background", "#ff0000");
      this.TreeCtrl.get_TreeNodeTypes().Add(treeNodeType2);
    }

    private void TreeCtrl_SelectedIndexChange(object senter, TreeViewSelectEventArgs e)
    {
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
