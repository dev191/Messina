// Decompiled with JetBrains decompiler
// Type: WebCad.apparecchiature
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebCad.WiewCad;

namespace WebCad
{
  public class apparecchiature : Page
  {
    protected DataGrid MyDataGrid1;
    private string descrizione = "";
    private int idReparto = 0;
    private int idCategoria = 0;
    private int idDestUso = 0;
    private string stringaRm = "";
    private string stringaStd = "";
    protected string elementiTrovati = "0";

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      this.BindApparecchiature();
    }

    private void BindApparecchiature()
    {
      int int32_1 = Convert.ToInt32(this.Request.QueryString["idpiano"]);
      int int32_2 = Convert.ToInt32(this.Request.QueryString["idbl"]);
      int int32_3 = Convert.ToInt32(this.Request.QueryString["IdServizio"]);
      if (this.Request.QueryString["descrizione"] != null)
        this.descrizione = this.Request.QueryString["descrizione"].Trim();
      this.idReparto = !(this.Request.QueryString["idReparto"] != "") ? 0 : Convert.ToInt32(this.Request.QueryString["idReparto"]);
      this.idCategoria = !(this.Request.QueryString["idCategoria"] != "") ? 0 : Convert.ToInt32(this.Request.QueryString["idCategoria"]);
      this.idDestUso = !(this.Request.QueryString["idDestUso"] != "") ? 0 : Convert.ToInt32(this.Request.QueryString["idDestUso"]);
      if (this.Request.QueryString["stanzeSel"] != null)
        this.stringaRm = this.Request.QueryString["stanzeSel"];
      if (this.Request.QueryString["stdSel"] != null)
        this.stringaStd = this.Request.QueryString["stdSel"];
      Apparecchiature apparecchiature = new Apparecchiature();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Value((object) int32_2);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_fl_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Value((object) int32_1);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pIdServizio");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Value((object) int32_3);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_descr");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Size(100);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Value((object) this.descrizione);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_cat_id");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Value((object) this.idCategoria);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_reparto_id");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Value((object) this.idReparto);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_dest_uso_id");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Value((object) this.idDestUso);
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_str_stanze");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Size(500);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Value((object) this.stringaRm);
      ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_str_std");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Size(500);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Value((object) this.stringaStd);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject9);
      DataSet data = apparecchiature.GetData(CollezioneControlli);
      this.MyDataGrid1.DataSource = (object) data;
      this.elementiTrovati = Convert.ToString(data.Tables[0].Rows.Count);
      this.MyDataGrid1.DataBind();
    }

    private void MyDataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      HtmlAnchor control = (HtmlAnchor) e.Item.FindControl("hrefset");
      DataRowView dataItem = (DataRowView) e.Item.DataItem;
      control.Attributes.Add("onclick", "Valorizza('" + dataItem["id"] + "','" + dataItem["descrizione"] + "')");
    }

    private void MyDataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.MyDataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.BindApparecchiature();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.MyDataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged);
      this.MyDataGrid1.ItemDataBound += new DataGridItemEventHandler(this.MyDataGrid1_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }
  }
}
