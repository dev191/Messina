// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorrettiva.DettDestinatariInvio
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
using System.Web.UI.WebControls;
using TheSite.Classi.ManCorrettiva;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorrettiva
{
  public class DettDestinatariInvio : Page
  {
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    private Traccia_doc Traccia_doc = new Traccia_doc();
    private int wr_id;
    private int bl_id;
    private string Tipo_doc = "";

    private void Page_Load(object sender, EventArgs e)
    {
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      if (this.Request.QueryString["Wr_id"] != "")
        this.wr_id = Convert.ToInt32(this.Request.QueryString["Wr_id"].ToString());
      if (this.Request.QueryString["tipo_doc"] != "")
        this.Tipo_doc = this.Request.QueryString["tipo_doc"].ToString();
      if (this.Request.QueryString["bl_id"] != "")
        this.bl_id = Convert.ToInt32(this.Request.QueryString["bl_id"].ToString());
      this.Ricerca();
    }

    private void Ricerca()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_TIPO_DOC");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Value((object) this.Tipo_doc);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_ID_WR");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Value((object) this.wr_id);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_ID_BL");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Value((object) this.bl_id);
      CollezioneControlli.Add(sObject3);
      DataSet dataSet = this.Traccia_doc.GetDestinatariInvio(CollezioneControlli).Copy();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
