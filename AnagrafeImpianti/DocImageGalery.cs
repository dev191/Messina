// Decompiled with JetBrains decompiler
// Type: TheSite.AnagrafeImpianti.DocImageGalery
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.WebControls;

namespace TheSite.AnagrafeImpianti
{
  public class DocImageGalery : Page
  {
    protected DataList DataListImage;
    protected PageTitle PageTitle1;
    private int bl_id;
    private int doc_id_servizio;
    private string categoria;
    private int idtip;

    private void Page_Load(object sender, EventArgs e)
    {
      if (!this.IsPostBack && this.Request.QueryString["bl_id"] != null && (this.Request.QueryString["doc_id_servizio"] != null && this.Request.QueryString["categoria"] != null))
      {
        if (this.Request.QueryString["idtip"] != null)
          this.idtip = int.Parse(this.Request.QueryString["idtip"]);
        this.bl_id = int.Parse(this.Request.QueryString["bl_id"]);
        this.doc_id_servizio = int.Parse(this.Request.QueryString["doc_id_servizio"]);
        this.categoria = this.Request.QueryString["categoria"];
        this.Execute();
      }
      this.PageTitle1.VisibleLogut = false;
    }

    private void Execute()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) this.bl_id);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_doc_id_servizio");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) this.doc_id_servizio);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_categoria");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) this.categoria);
      ((ParameterObject) sObject3).set_Size(50);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_tipologia");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Value((object) this.idtip);
      CollezioneControlli.Add(sObject4);
      this.DataListImage.DataSource = (object) new DocDWF().GetDocImage(CollezioneControlli);
      this.DataListImage.DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.DataListImage.ItemDataBound += new DataListItemEventHandler(this.DataListImage_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void DataListImage_ItemDataBound(object sender, DataListItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      DataRowView dataItem = (DataRowView) e.Item.DataItem;
      string upper = dataItem["var_nomedwf"].ToString().ToUpper();
      if (upper.EndsWith("PDF"))
        return;
      string s = dataItem["var_percorso_root"].ToString().Replace(" ", "_").Replace("/", "_") + "/" + dataItem["var_percorso_child"].ToString().Replace(" ", "_").Replace("/", "_");
      ((HtmlImage) e.Item.FindControl("imgdoc")).Src = "PageImage.aspx?eq_image=" + upper + "&urlimage=" + this.Server.UrlDecode(s) + "&p=y";
      ((HtmlAnchor) e.Item.FindControl("imagefull")).HRef = "FullImage.aspx?eq_image=" + upper + "&urlimage=" + this.Server.UrlDecode(s) + "&p=n";
    }
  }
}
