// Decompiled with JetBrains decompiler
// Type: WebCad.WebControls.DataGridRicercaCad
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebCad.UserControl;
using WebCad.WiewCad;

namespace WebCad.WebControls
{
  public class DataGridRicercaCad : System.Web.UI.UserControl
  {
    protected DataSet dataSet1;
    protected DataGrid DataGrid1 = new DataGrid();
    protected Label LabelElementiTrovati;
    protected DropDownList DropDownList1;
    protected PlaceHolder PlaceHolder1;
    public int numeroPagina = 0;
    public int recordPerPagina;
    public int tipo;
    protected Label LabelResp;
    protected HtmlGenericControl divdatagrid;
    public int totaleRecord;
    protected string nomeScript = "";

    private void Page_Load(object sender, EventArgs e)
    {
      if (!(this.Page is IDataGridDinamico))
        throw new ApplicationException("FEDERICO DISSE: Chi usa il datagrid dinamico deve implementare IDataGridDinamico");
      this.nomeScript = this.Request.ServerVariables["SCRIPT_NAME"];
      if (this.Request.QueryString["clear"] != null)
      {
        ParametriRicerca parametriRicerca = (ParametriRicerca) this.Session["parametri"];
        parametriRicerca.eqIds = string.Empty;
        parametriRicerca.rmIds = string.Empty;
        parametriRicerca.stdEqIds = string.Empty;
        this.Session["parametri"] = (object) parametriRicerca;
        this.Visible = false;
      }
      else if (this.Session["parametri"] != null)
      {
        this.setTemplate(((ParametriRicerca) this.Session["parametri"]).tipoDataSet);
        this.dataSet1 = ((bottomFrame) this.Page).Popola((ParametriRicerca) this.Session["parametri"]);
        this.SetDataSet(this.dataSet1, ((ParametriRicerca) this.Session["parametri"]).tipoDataSet);
        this.Visible = true;
      }
      else
        this.Visible = false;
    }

    public void setTemplate(int tipo)
    {
      this.DataGrid1.ID = "DataGrid1";
      this.DataGrid1.AutoGenerateColumns = false;
      this.DataGrid1.EnableViewState = true;
      this.DataGrid1.AllowPaging = true;
      this.DataGrid1.ShowFooter = false;
      this.DataGrid1.ShowHeader = true;
      this.DataGrid1.PagerStyle.Mode = PagerMode.NumericPages;
      this.DataGrid1.AllowSorting = true;
      this.DataGrid1.Width = Unit.Percentage(100.0);
      this.DataGrid1.AlternatingItemStyle.CssClass = "DataGridAlternatingItemStyle";
      this.DataGrid1.ItemStyle.CssClass = "DataGridItemStyle";
      this.DataGrid1.HeaderStyle.CssClass = "DataGridHeaderStyle";
      this.DataGrid1.AllowSorting = true;
      string path = this.Request.MapPath(this.Request.ApplicationPath + ConfigurationSettings.AppSettings["DirectoryCad"]);
      if (tipo == 1)
      {
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, ""),
          ItemTemplate = (ITemplate) new DataGridImageCheckFileTemplate(ListItemType.Item, "Nome_File", "../images/Search16x16_bianca.JPG", "SetDwf ($)", "Seleziona DWG", path, ".dwf"),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, ""),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "")
        });
        TemplateColumn templateColumn1 = new TemplateColumn();
        templateColumn1.SortExpression = "Edificio";
        templateColumn1.HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, "Edificio");
        templateColumn1.ItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.Item, "Edificio");
        templateColumn1.EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, "Edificio");
        templateColumn1.FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "Edificio");
        this.DataGrid1.Columns.Add((DataGridColumn) templateColumn1);
        TemplateColumn templateColumn2 = new TemplateColumn();
        templateColumn2.SortExpression = "Piano";
        templateColumn2.HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, "Piano");
        templateColumn2.ItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.Item, "Piano");
        templateColumn2.EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, "Piano");
        templateColumn2.FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "Piano");
        this.DataGrid1.Columns.Add((DataGridColumn) templateColumn2);
        TemplateColumn templateColumn3 = new TemplateColumn();
        templateColumn3.SortExpression = "Nome_File";
        templateColumn3.HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, "Nome File");
        templateColumn3.ItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.Item, "Nome_File");
        templateColumn3.EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, "Nome File");
        templateColumn3.FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "Nome File");
        this.DataGrid1.Columns.Add((DataGridColumn) templateColumn3);
        TemplateColumn templateColumn4 = new TemplateColumn();
        templateColumn4.SortExpression = "Servizio";
        templateColumn4.HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, "Servizio");
        templateColumn4.ItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.Item, "Servizio");
        templateColumn4.EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, "");
        templateColumn4.FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "");
        this.DataGrid1.Columns.Add((DataGridColumn) templateColumn4);
      }
      if (tipo == 2)
      {
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, ""),
          ItemTemplate = (ITemplate) new DataGridImageTemplate(ListItemType.Item, "layer", "../images/Search16x16_bianca.JPG", "vbscript:EvidenziaLayer('$')", "evidenzia la stanza", "idc", 0),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, ""),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "")
        });
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, ""),
          ItemTemplate = (ITemplate) new DataGridImageTemplate(ListItemType.Item, "id_rm", "../images/DataRoom.jpg", "javascript:openRicercaDataRoom(" + (object) ((ParametriRicerca) this.Session["parametri"]).blId + "," + (object) ((ParametriRicerca) this.Session["parametri"]).flId + ")", "Ricerca DataRoom"),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, ""),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "")
        });
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, ""),
          ItemTemplate = (ITemplate) new DatagridImageCoordTemplate(ListItemType.Item, "id_rm", "z1x", "z1y", "z2x", "z2y", "../images/eye.gif", "vbscript:ZoomOfObject $ ", "zoom sulla stanza", "idc", 0),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, ""),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "")
        });
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, ""),
          ItemTemplate = (ITemplate) new DataGridImageTemplate2Par(ListItemType.Item, "id_rm", "stanza", "../images/Stanza.gif", "javascript:OpenDataRoom($)", "dataroom"),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, ""),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "")
        });
        TemplateColumn templateColumn1 = new TemplateColumn();
        templateColumn1.SortExpression = "rm_id";
        templateColumn1.HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, "Stanza");
        templateColumn1.ItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.Item, "rm_id", "idc", 0);
        templateColumn1.EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, "rm_id");
        templateColumn1.FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "Stanza");
        this.DataGrid1.Columns.Add((DataGridColumn) templateColumn1);
        TemplateColumn templateColumn2 = new TemplateColumn();
        templateColumn2.SortExpression = "Stanza";
        templateColumn2.HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, "Stanza");
        templateColumn2.ItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.Item, "Stanza", "idc", 0);
        templateColumn2.EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, "Stanza");
        templateColumn2.FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "Stanza");
        this.DataGrid1.Columns.Add((DataGridColumn) templateColumn2);
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, "Dest. Uso"),
          ItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.Item, "DestUso", "idc", 0),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, "DestUso"),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "DestUso")
        });
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, "Reparto"),
          ItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.Item, "Reparto", "idc", 0),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, "Reparto"),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "Reparto")
        });
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, "Categoria"),
          ItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.Item, "Categoria", "idc", 0),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, "Categoria"),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "Categoria")
        });
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, "Mq"),
          ItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.Item, "Area", "idc", 0),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, "Ara"),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "Area")
        });
      }
      if (tipo == 3)
      {
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, ""),
          ItemTemplate = (ITemplate) new DataGridImageTemplate(ListItemType.Item, "eq_id", "../images/treeimages/gnome-desktop-config.gif", "javascript:OpenApparecchiatura('$')", "visualizzazione del dettaglio dell'apparecchiatura"),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, ""),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "")
        });
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, ""),
          ItemTemplate = (ITemplate) new DataGridImageTemplate2Par(ListItemType.Item, "id_eq", "eq_id", "../images/attach.png", "javascript:OpenDocumentiEq($)", "Documenti associati"),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, ""),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "")
        });
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, ""),
          ItemTemplate = (ITemplate) new DataGridImageTemplate(ListItemType.Item, "id_eq", "../images/SchedeEq.jpg", "javascript:OpenSchedaEq('$')", "Scheda di esercizio"),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, ""),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "")
        });
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, ""),
          ItemTemplate = (ITemplate) new DatagridImageCoordTemplate(ListItemType.Item, "id_rm", "z1x", "z1y", "z2x", "z2y", "../images/eye.gif", "vbscript:ZoomOfObject $ ", "zoom sulla apparecchiatura", "idc", 0),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, ""),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "")
        });
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, "Codice"),
          ItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.Item, "eq_id", "idc", 0),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, "eq_id"),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "Codice")
        });
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, "Standard Eq"),
          ItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.Item, "standardeq", "idc", 0),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, "standardeq"),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "Standard Eq")
        });
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, "Servizio"),
          ItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.Item, "servizio", "idc", 0),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, "servizio"),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "Servizio")
        });
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, "Reparto"),
          ItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.Item, "reparto", "idc", 0),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, "reparto"),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "Reparto")
        });
        this.DataGrid1.Columns.Add((DataGridColumn) new TemplateColumn()
        {
          HeaderTemplate = (ITemplate) new DataGridTemplate(ListItemType.Header, "Stanza"),
          ItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.Item, "stanza", "idc", 0),
          EditItemTemplate = (ITemplate) new DataGridTemplate(ListItemType.EditItem, "stanza"),
          FooterTemplate = (ITemplate) new DataGridTemplate(ListItemType.Footer, "Stanza")
        });
      }
      this.PlaceHolder1.Controls.Add((Control) this.DataGrid1);
    }

    private void FillGrid(DataSet ds)
    {
      this.DataGrid1.DataSource = (object) this.dataSet1.Tables[0];
      this.DataGrid1.DataBind();
    }

    public int GetTipo() => Convert.ToInt32(this.ViewState["tipo"]);

    private void SetDataSet(DataSet ds, int tipo)
    {
      this.dataSet1 = ds;
      ds.GetXml();
      this.tipo = tipo;
      this.ViewState[nameof (tipo)] = (object) tipo;
      if (this.dataSet1.Tables[0].Rows.Count == 0)
        this.divdatagrid.Visible = false;
      else
        this.divdatagrid.Visible = true;
      if (this.dataSet1 != null)
      {
        this.FillGrid(this.dataSet1);
        this.LabelElementiTrovati.Text = Convert.ToString(this.dataSet1.Tables[0].Rows.Count);
        this.DataGrid1.PageSize = Convert.ToInt32(this.DropDownList1.SelectedValue);
        this.totaleRecord = this.dataSet1.Tables[0].Rows.Count;
      }
      if (this.DataGrid1.Items.Count == 0)
      {
        this.LabelResp.Text = "Non ci sono dati per i parametri selezionati";
        this.LabelResp.Visible = true;
      }
      else
        this.LabelResp.Visible = false;
    }

    protected override void OnInit(EventArgs e)
    {
      this.DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.CambiaPaginaDataGrid);
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.DropDownList1.SelectedIndexChanged += new EventHandler(this.DropDownList1_SelectedIndexChanged);
      this.Load += new EventHandler(this.Page_Load);
    }

    public int GetNumeroPagina() => Convert.ToInt32(this.ViewState["numeroPagina"]);

    public int GetRecordPerPagina() => Convert.ToInt32(this.ViewState["recordPerPagina"]) > 0 ? Convert.ToInt32(this.ViewState["recordPerPagina"]) : 10;

    protected void CambiaPaginaDataGrid(object source, DataGridPageChangedEventArgs e)
    {
      this.numeroPagina = e.NewPageIndex;
      this.ViewState["numeroPagina"] = (object) this.numeroPagina;
      this.DataGrid1.CurrentPageIndex = this.numeroPagina;
      this.SetDataSet(this.dataSet1, ((ParametriRicerca) this.Session["parametri"]).tipoDataSet);
    }

    protected void OrdinaDataGrid(object source, DataGridSortCommandEventArgs e)
    {
      if (Convert.ToString(this.ViewState["verso"]) == "" || Convert.ToString(this.ViewState["verso"]) == "DESC")
        this.ViewState["verso"] = (object) "ASC";
      else if (Convert.ToString(this.ViewState["verso"]) == "ASC")
        this.ViewState["verso"] = (object) "DESC";
      this.ViewState["campoDiOrdinamento"] = (object) e.SortExpression;
      this.SetDataSet(this.dataSet1, ((ParametriRicerca) this.Session["parametri"]).tipoDataSet);
    }

    private void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.recordPerPagina = Convert.ToInt32(this.DropDownList1.SelectedValue);
      this.ViewState["recordPerPagina"] = (object) this.recordPerPagina;
      this.DataGrid1.PageSize = this.recordPerPagina;
      this.DataGrid1.CurrentPageIndex = 0;
      this.SetDataSet(this.dataSet1, ((ParametriRicerca) this.Session["parametri"]).tipoDataSet);
    }
  }
}
