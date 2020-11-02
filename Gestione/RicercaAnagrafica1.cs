// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.RicercaAnagrafica1
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class RicercaAnagrafica1 : UserControl
  {
    protected S_TextBox txtsDescrizione;
    protected S_Button btnsRicerca;
    protected DataPanel PanelRicerca;
    protected S_TextBox txtsNote;
    protected DataGrid DataGridRicerca;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    protected S_TextBox txtsCodice;
    public static string pag = string.Empty;
    public static string s_pagdir;
    public static string Codice = string.Empty;
    protected S_Button btnReset;
    private clMyCollection _myColl;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((Control) this.GridTitle1.hplsNuovo).Visible = siteModule.IsEditable;
      this.DataGridRicerca.Columns[1].Visible = true;
      this.DataGridRicerca.Columns[2].Visible = siteModule.IsEditable;
      RicercaAnagrafica1.FunId = siteModule.ModuleId;
      this.ViewState["FunId"] = (object) int.Parse(RicercaAnagrafica1.FunId.ToString());
      RicercaAnagrafica1.HelpLink = siteModule.HelpLink;
      switch (this.Pagina)
      {
        case PageType.Servizi:
          RicercaAnagrafica1.s_pagdir = "Servizi";
          ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Gestione/EditAnagrafica.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId + "&Pagina=Servizi";
          RicercaAnagrafica1.Codice = "Codice Servizio";
          break;
        case PageType.TipologiaDitta:
          RicercaAnagrafica1.s_pagdir = "TipologiaDitta";
          ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Gestione/EditAnagrafica.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId + "&Pagina=TipologiaDitta";
          RicercaAnagrafica1.Codice = "Codice Tipologia Ditta";
          break;
        case PageType.TipoManutenzione:
          RicercaAnagrafica1.s_pagdir = "TipoManutenzione";
          ((HyperLink) this.GridTitle1.hplsNuovo).NavigateUrl = "../Gestione/EditAnagrafica.aspx?ItemID=0&FunId=" + (object) siteModule.ModuleId + "&Pagina=TipoManutenzione";
          RicercaAnagrafica1.Codice = "Codice Tipo Manutenzione";
          break;
      }
      RicercaAnagrafica1.pag += "?ItemID=";
      this.PageTitle1.Title = siteModule.ModuleTitle;
      if (this.Page.IsPostBack || !(this.Request.Params["Ricarica"] == "yes"))
        return;
      this.Ricerca();
    }

    public PageType Pagina
    {
      get => (PageType) this.ViewState["paget"];
      set => this.ViewState["paget"] = (object) value;
    }

    public clMyCollection Coll
    {
      get => this._myColl;
      set => this._myColl = value;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      ((Button) this.btnReset).Click += new EventHandler(this.btnReset_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e) => this.Ricerca();

    public void Ricerca1(S_ControlsCollection _SCollection)
    {
      DataSet dataSet = new DataSet();
      switch (this.Pagina)
      {
        case PageType.Servizi:
          dataSet = new TheSite.Classi.ClassiDettaglio.Servizi().GetServiziAnagrafica(_SCollection).Copy();
          break;
        case PageType.TipologiaDitta:
          dataSet = new TheSite.Classi.ClassiAnagrafiche.TipologiaDitta().GetData(_SCollection).Copy();
          break;
        case PageType.TipoManutenzione:
          dataSet = new TheSite.Classi.ClassiAnagrafiche.TipoManutenzione().GetData(_SCollection);
          break;
      }
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      if (dataSet.Tables[0].Rows.Count == 0)
      {
        this.DataGridRicerca.CurrentPageIndex = 0;
      }
      else
      {
        int num = 0;
        if (dataSet.Tables[0].Rows.Count % this.DataGridRicerca.PageSize > 0)
          ++num;
        if (this.DataGridRicerca.PageCount != (int) Convert.ToInt16(dataSet.Tables[0].Rows.Count / this.DataGridRicerca.PageSize + num))
          this.DataGridRicerca.CurrentPageIndex = 0;
      }
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
    }

    public void Ricerca()
    {
      this.txtsDescrizione.set_DBDefaultValue((object) "%");
      this.txtsNote.set_DBDefaultValue((object) "%");
      this.txtsCodice.set_DBDefaultValue((object) "%");
      ((TextBox) this.txtsDescrizione).Text = ((TextBox) this.txtsDescrizione).Text.Trim();
      ((TextBox) this.txtsNote).Text = ((TextBox) this.txtsNote).Text.Trim();
      ((TextBox) this.txtsCodice).Text = ((TextBox) this.txtsCodice).Text.Trim();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) ((Control) this.PanelRicerca).Controls);
      DataSet dataSet = new DataSet();
      switch (this.Pagina)
      {
        case PageType.Servizi:
          dataSet = new TheSite.Classi.ClassiDettaglio.Servizi().GetServiziAnagrafica(CollezioneControlli).Copy();
          break;
        case PageType.TipologiaDitta:
          dataSet = new TheSite.Classi.ClassiAnagrafiche.TipologiaDitta().GetData(CollezioneControlli).Copy();
          break;
        case PageType.TipoManutenzione:
          dataSet = new TheSite.Classi.ClassiAnagrafiche.TipoManutenzione().GetData(CollezioneControlli);
          break;
      }
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      if (dataSet.Tables[0].Rows.Count == 0)
      {
        this.DataGridRicerca.CurrentPageIndex = 0;
      }
      else
      {
        int num = 0;
        if (dataSet.Tables[0].Rows.Count % this.DataGridRicerca.PageSize > 0)
          ++num;
        if (this.DataGridRicerca.PageCount != (int) Convert.ToInt16(dataSet.Tables[0].Rows.Count / this.DataGridRicerca.PageSize + num))
          this.DataGridRicerca.CurrentPageIndex = 0;
      }
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Header)
      {
        switch (this.Pagina)
        {
          case PageType.Servizi:
            e.Item.Cells[4].Text = "Codice Servizio";
            break;
          case PageType.TipologiaDitta:
            e.Item.Cells[4].Text = "Codice Tipologia Ditta";
            break;
          case PageType.TipoManutenzione:
            e.Item.Cells[4].Text = "Codice Tipo Manutenzione";
            break;
        }
      }
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton1")).Attributes.Add("title", "Visualizza");
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton2")).Attributes.Add("title", "Modifica");
      if (e.Item.Cells[3].Text.Trim().Length > 50)
      {
        string str = e.Item.Cells[3].Text.Trim().Substring(0, 49) + "...";
        e.Item.Cells[3].ToolTip = e.Item.Cells[3].Text;
        e.Item.Cells[3].Text = str;
      }
      if (e.Item.Cells[4].Text.Trim().Length <= 68)
        return;
      string str1 = e.Item.Cells[4].Text.Trim().Substring(0, 68) + "...";
      e.Item.Cells[4].ToolTip = e.Item.Cells[4].Text;
      e.Item.Cells[4].Text = str1;
    }

    public void imageButton_Click(object sender, CommandEventArgs e)
    {
      this.Context.Items.Add((object) "ItemId", e.CommandArgument);
      this.Context.Items.Add((object) "FunId=", (object) this.ViewState["FunId"].ToString());
      this.Context.Items.Add((object) "TipoOper", (object) "read");
      this.Context.Items.Add((object) "Pagina", (object) RicercaAnagrafica1.s_pagdir);
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer("EditAnagrafica.aspx");
    }

    public void imageButton_Click1(object sender, CommandEventArgs e)
    {
      this.Context.Items.Add((object) "ItemId", e.CommandArgument);
      this.Context.Items.Add((object) "FunId=", (object) this.ViewState["FunId"].ToString());
      this.Context.Items.Add((object) "TipoOper", (object) "write");
      this.Context.Items.Add((object) "Pagina", (object) RicercaAnagrafica1.s_pagdir);
      this._myColl.AddControl(this.Page.Controls, ParentType.Page);
      this.Server.Transfer("EditAnagrafica.aspx");
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      switch (this.Pagina)
      {
        case PageType.Servizi:
          this.Response.Redirect("servizi.aspx?FunId=" + this.ViewState["FunId"]);
          break;
        case PageType.TipologiaDitta:
          this.Response.Redirect("TipologiaDitta.aspx?FunId=" + this.ViewState["FunId"]);
          break;
        case PageType.TipoManutenzione:
          this.Response.Redirect("TipoManutenzione.aspx?FunId=" + this.ViewState["FunId"]);
          break;
      }
    }
  }
}
