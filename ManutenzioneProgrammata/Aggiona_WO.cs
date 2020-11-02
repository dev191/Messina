// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.Aggiona_WO
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
  public class Aggiona_WO : Page
  {
    protected Repeater RepeaterMaster;
    protected PageTitle PageTitle1;
    private int addetto_id = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      this.PageTitle1.VisibleLogut = false;
      if (this.IsPostBack || this.Request.QueryString["addetto"] == null)
        return;
      this.addetto_id = Convert.ToInt32(this.Request.QueryString["addetto"]);
      this.BindingMaster();
    }

    private void BindingMaster()
    {
      if (this.Session["CheckedListMP"] == null)
        return;
      this.RepeaterMaster.DataSource = (object) this.RemoveHash((Hashtable) this.Session["CheckedListMP"]);
      this.RepeaterMaster.DataBind();
      this.Page.RegisterStartupScript("agg", "<script language=\"javascript\">\n" + "opener.refreshgriglia();" + "</script>\n");
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
      return completaOrdine.AggiornaWO(CollezioneControlli);
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
      DataSet dataSet = this.UpdateWo(Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Key").ToString()));
      control.DataSource = (object) dataSet.Tables[0];
      control.DataBind();
    }
  }
}
