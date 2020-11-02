// Decompiled with JetBrains decompiler
// Type: TheSite.AnagrafeImpianti.ListaApparecchiatureServ
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls.Collections;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi.AnagrafeImpianti;

namespace TheSite.AnagrafeImpianti
{
  public class ListaApparecchiatureServ : Page
  {
    protected DataGrid DtgListaApparecchiature;
    private int bl_id;
    private int servizio_id;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.Request.QueryString["bl_id"] != null)
        this.bl_id = Convert.ToInt32(this.Request.QueryString["bl_id"]);
      if (this.Request.QueryString["servizio_id"] != null)
        this.servizio_id = Convert.ToInt32(this.Request.QueryString["servizio_id"]);
      this.Apparecchiature();
    }

    private void Apparecchiature()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      DataSet apparecchiature = new SeviceDettail(this.Context.User.Identity.Name).GetApparecchiature(this.bl_id, this.servizio_id);
      this.DtgListaApparecchiature.DataSource = (object) apparecchiature.Tables[0];
      if (apparecchiature.Tables[0].Rows.Count == 0)
      {
        this.DtgListaApparecchiature.CurrentPageIndex = 0;
      }
      else
      {
        int num = 0;
        if (apparecchiature.Tables[0].Rows.Count % this.DtgListaApparecchiature.PageSize > 0)
          ++num;
        if (this.DtgListaApparecchiature.PageCount != (int) Convert.ToInt16(apparecchiature.Tables[0].Rows.Count / this.DtgListaApparecchiature.PageSize + num))
          this.DtgListaApparecchiature.CurrentPageIndex = 0;
      }
      this.DtgListaApparecchiature.DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.DtgListaApparecchiature.PageIndexChanged += new DataGridPageChangedEventHandler(this.DtgListaApparecchiature_PageIndexChanged);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void DtgListaApparecchiature_PageIndexChanged(
      object source,
      DataGridPageChangedEventArgs e)
    {
      this.DtgListaApparecchiature.CurrentPageIndex = e.NewPageIndex;
      this.Apparecchiature();
    }
  }
}
