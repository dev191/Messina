// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.Completa_WO
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
using TheSite.Classi.ManProgrammata;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class Completa_WO : Page
  {
    protected Repeater RepeaterMaster;
    protected PageTitle PageTitle1;
    private int addetto_id = 0;
    private string Data = (string) null;
    private string Wo = (string) null;

    private void Page_Load(object sender, EventArgs e)
    {
      this.Response.Expires = -1;
      this.Response.Cache.SetNoStore();
      this.PageTitle1.VisibleLogut = false;
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["addetto"] != null)
      {
        this.addetto_id = Convert.ToInt32(this.Request.QueryString["addetto"]);
        this.Data = this.Request.QueryString["data"];
        this.BindingMaster();
      }
      else
      {
        this.Wo = this.Request.QueryString["wo"];
        this.Data = this.Request.QueryString["data"];
        this.BindingMasterSingle();
      }
      this.Page.RegisterStartupScript("agg", "<script language=\"javascript\">\n" + "opener.refreshgriglia();" + "</script>\n");
    }

    private void BindingMaster()
    {
      if (this.Session["CheckedListMP"] == null)
        return;
      this.RepeaterMaster.DataSource = (object) this.RemoveHash((Hashtable) this.Session["CheckedListMP"]);
      this.RepeaterMaster.DataBind();
    }

    private void BindingMasterSingle()
    {
      if (this.Wo == null)
        return;
      this.RepeaterMaster.DataSource = (object) new Hashtable()
      {
        {
          (object) this.Request.QueryString["wo"],
          (object) true
        }
      };
      this.RepeaterMaster.DataBind();
    }

    private Hashtable RemoveHash(Hashtable myList)
    {
      Hashtable hashtable = new Hashtable();
      IDictionaryEnumerator enumerator = myList.GetEnumerator();
      while (enumerator.MoveNext())
      {
        if ((bool) enumerator.Value)
          hashtable.Add(enumerator.Key, enumerator.Value);
      }
      return hashtable;
    }

    private DataSet UpdateWo(int itemId)
    {
      CompletaOrdine completaOrdine = new CompletaOrdine();
      int num = itemId;
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_wo_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) num);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_addetto_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) this.addetto_id);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_data");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 5);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) Convert.ToDateTime(this.Data).ToString("d"));
      CollezioneControlli.Add(sObject3);
      return completaOrdine.CompletaWO(CollezioneControlli);
    }

    private DataTable UpdateWr()
    {
      DataTable dataTable = new DataTable();
      if (this.Session["DatiListMP"] != null)
      {
        CompletaOrdine completaOrdine = new CompletaOrdine();
        IDictionaryEnumerator enumerator = ((Hashtable) this.Session["DatiListMP"]).GetEnumerator();
        while (enumerator.MoveNext())
        {
          WRList wrList = (WRList) enumerator.Value;
          S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
          S_Object sObject1 = new S_Object();
          ((ParameterObject) sObject1).set_ParameterName("p_wo_id");
          ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject1).set_Index(0);
          ((ParameterObject) sObject1).set_Value((object) this.Wo);
          CollezioneControlli.Add(sObject1);
          S_Object sObject2 = new S_Object();
          ((ParameterObject) sObject2).set_ParameterName("p_wr_id");
          ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject2).set_Index(1);
          ((ParameterObject) sObject2).set_Value((object) wrList.id);
          CollezioneControlli.Add(sObject2);
          S_Object sObject3 = new S_Object();
          ((ParameterObject) sObject3).set_ParameterName("p_data");
          ((ParameterObject) sObject3).set_DbType((CustomDBType) 5);
          ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject3).set_Index(2);
          ((ParameterObject) sObject3).set_Value((object) Convert.ToDateTime(this.Data).ToString("d"));
          CollezioneControlli.Add(sObject3);
          S_Object sObject4 = new S_Object();
          ((ParameterObject) sObject4).set_ParameterName("p_stato");
          ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject4).set_Index(3);
          if (!wrList.stato)
            ((ParameterObject) sObject4).set_Value((object) 1);
          else
            ((ParameterObject) sObject4).set_Value((object) 0);
          CollezioneControlli.Add(sObject4);
          S_Object sObject5 = new S_Object();
          ((ParameterObject) sObject5).set_ParameterName("p_motivo");
          ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
          ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject5).set_Size(4000);
          ((ParameterObject) sObject5).set_Index(4);
          ((ParameterObject) sObject5).set_Value((object) wrList.descrizione);
          CollezioneControlli.Add(sObject5);
          DataSet dataSet = completaOrdine.AggiornaWr(CollezioneControlli);
          if (dataSet.Tables[0].Rows.Count > 0)
          {
            if (dataTable.Rows.Count == 0)
              dataTable = dataSet.Tables[0].Clone();
            dataTable.ImportRow(dataSet.Tables[0].Rows[0]);
          }
        }
      }
      return dataTable;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.RepeaterMaster.ItemDataBound += new RepeaterItemEventHandler(this.RepeaterMaster_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void RepeaterMaster_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      Repeater control = (Repeater) e.Item.FindControl("RepeaterDettail");
      int int32 = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Key").ToString());
      DataTable dataTable = this.Wo != null ? this.UpdateWr() : this.UpdateWo(int32).Tables[0];
      control.DataSource = (object) dataTable;
      control.DataBind();
    }
  }
}
