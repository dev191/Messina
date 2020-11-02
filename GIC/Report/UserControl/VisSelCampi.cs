// Decompiled with JetBrains decompiler
// Type: GIC.Report.UserControl.VisSelCampi
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using GIC.App_Code;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.GIC.App_Code.Consultazioni;
using TheSite.GIC.App_Code.DataSetDef;

namespace GIC.Report.UserControl
{
  public class VisSelCampi : BaseControl
  {
    protected DataSetReport dataSetReport1;
    protected HtmlInputHidden SelectedItems;
    protected HtmlInputHidden txtHTitolo;
    protected string TuttiClientId;
    protected Table TableTuttiCampi;
    protected Table TableCampiSel;
    protected TextBox TextTitolo;
    protected TextBox TextDescrizione;
    protected Button BtnSalva;
    protected Button BtnAnnulla;
    protected Button ButtonVisualizza;
    protected Button BtnExcel;
    protected TextBox TxtOwner;
    protected Button BtnCopia;
    protected string SelezClientId;
    private int NewIdQuery = 0;

    public int IdQuery
    {
      set
      {
        this.ViewState["idQuer"] = (object) value;
        this.Ricarica();
        this.SetButnVis();
      }
      get => Convert.ToInt32(this.ViewState["idQuer"]);
    }

    public string SelectedItemsValue
    {
      set => this.SelectedItems.Value = value;
    }

    private void Page_Load(object sender, EventArgs e)
    {
      this.TuttiClientId = this.TableTuttiCampi.ClientID;
      this.SelezClientId = this.TableCampiSel.ClientID;
    }

    private void SetButnVis()
    {
      if (Convert.ToInt32(this.ViewState["idQuer"]) == 0)
      {
        this.TextDescrizione.Text = "";
        this.TextTitolo.Text = "";
        this.TxtOwner.Text = "";
      }
      else
      {
        this.ButtonVisualizza.Visible = true;
        this.GetDatiSchema();
      }
      this.ButtonVisualizza.Attributes.Add("onclick", "return CheckSelC();");
      this.BtnExcel.Attributes.Add("onclick", "return CheckSelC();");
      this.BtnSalva.Attributes.Add("onclick", "return CheckSelC();");
    }

    private void GetDatiSchema()
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pIdSchema");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) this.IdQuery);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("putente");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) HttpContext.Current.User.Identity.Name);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("io_cursor");
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject3).set_Index(2);
      controlsCollection.Add(sObject3);
      this.paramFederico = controlsCollection;
      this.CurrentProcedure = "IL_PACK_INTERROGAZIONI.IL_SpSelectSchema";
      DataTable data = this.GetData();
      this.TextTitolo.Text = Convert.ToString(data.Rows[0].ItemArray[0]);
      this.txtHTitolo.Value = Convert.ToString(data.Rows[0].ItemArray[0]);
      this.TextDescrizione.Text = Convert.ToString(data.Rows[0].ItemArray[1]);
      this.TxtOwner.Text = Convert.ToString(data.Rows[0].ItemArray[2]);
      if (this.Context.User.Identity.Name.ToUpper() == this.TxtOwner.Text.ToUpper() || this.Context.User.IsInRole("amministratori"))
        this.BtnSalva.Visible = true;
      else
        this.BtnSalva.Visible = false;
    }

    public void Ricarica()
    {
      this.TuttiClientId = this.TableTuttiCampi.ClientID;
      this.SelezClientId = this.TableCampiSel.ClientID;
      this.TableCampiSel.Rows.Clear();
      this.BindTuttiCampi();
      this.BindCampiSel();
    }

    private void BindTuttiCampi()
    {
      this.SelectedItemsValue = "";
      this.TableTuttiCampi.Rows.Clear();
      this.dataSetReport1.TuttiCampi.Clear();
      DataTable tuttiCampi = this.GetTuttiCampi();
      foreach (DataRow row in (InternalDataCollectionBase) tuttiCampi.Rows)
        this.dataSetReport1.TuttiCampi.ImportRow(row);
      tuttiCampi.Dispose();
      TableRow row1 = new TableRow();
      TableCell cell1 = new TableCell();
      cell1.Text = "Doppio Click per aggiungere";
      cell1.CssClass = "TableHeaderCampi2";
      cell1.Attributes.Add("ondblclick", "SelectItem(this.parentNode,'li')");
      row1.Cells.Add(cell1);
      this.TableTuttiCampi.Rows.Add(row1);
      int num = 0;
      foreach (DataSetReport.TuttiCampiRow tuttiCampiRow in this.dataSetReport1.TuttiCampi)
      {
        ++num;
        TableRow row2 = new TableRow();
        TableCell cell2 = new TableCell();
        if (num % 2 == 0)
          row2.CssClass = "TableRowTuttiCampi";
        else
          row2.CssClass = "TableRowTuttiCampiAlt";
        cell2.CssClass = "TableCellTuttiCampi";
        cell2.Text = Convert.ToString(tuttiCampiRow.Alias);
        row2.Attributes.Add("desc", Convert.ToString(tuttiCampiRow.NomeTabella) + " - " + Convert.ToString(tuttiCampiRow.Alias));
        row2.Attributes.Add("title", Convert.ToString(tuttiCampiRow.NomeCampo));
        row2.Attributes.Add("idItem", Convert.ToString(tuttiCampiRow.IdGlossario));
        cell2.Attributes.Add("ondblclick", "SelectItem(this.parentNode,'li')");
        cell2.Width = Unit.Pixel(250);
        row2.Attributes.Add("tipol", Convert.ToString(tuttiCampiRow.Tipologia));
        row2.Attributes.Add("tipod", Convert.ToString(tuttiCampiRow.TipoDato));
        row2.Cells.Add(cell2);
        this.TableTuttiCampi.Rows.Add(row2);
        TableCell cell3 = new TableCell();
        cell3.Text = this.GetImageVuota();
        row2.Attributes.Add("ord", "NESSUNO");
        cell3.CssClass = "TableCellInfoCampi";
        row2.Cells.Add(cell3);
        TableCell cell4 = new TableCell();
        cell4.Text = this.GetImageVuota();
        cell4.CssClass = "TableCellInfoCampi";
        row2.Attributes.Add("filtro", "");
        row2.Cells.Add(cell4);
        TableCell cell5 = new TableCell();
        cell5.Text = this.GetImageVuota();
        row2.Attributes.Add("aggr", "NESSUNO");
        cell5.CssClass = "TableCellInfoCampi";
        row2.Cells.Add(cell5);
        TableCell cell6 = new TableCell();
        cell6.Text = this.GetImageVuota();
        row2.Attributes.Add("nascosto", "False");
        cell6.CssClass = "TableCellInfoCampi";
        row2.Cells.Add(cell6);
        TableCell cell7 = new TableCell();
        HtmlImage htmlImage1 = new HtmlImage();
        htmlImage1.Src = "..\\..\\imgFunz\\freccia_su_4.gif";
        htmlImage1.Attributes.Add("class", "ButtonCampi");
        htmlImage1.Attributes.Add("onclick", "InversioneCampi(this,'su')");
        cell7.Controls.Add((Control) htmlImage1);
        cell7.CssClass = "TableCellInfoCampi";
        row2.Cells.Add(cell7);
        TableCell cell8 = new TableCell();
        HtmlImage htmlImage2 = new HtmlImage();
        htmlImage2.Src = "..\\..\\imgFunz\\freccia_giu_4.gif";
        htmlImage2.Attributes.Add("class", "ButtonCampi");
        htmlImage2.Attributes.Add("onclick", "InversioneCampi(this,'giu')");
        cell8.Controls.Add((Control) htmlImage2);
        cell8.CssClass = "TableCellInfoCampi";
        row2.Cells.Add(cell8);
        TableCell cell9 = new TableCell();
        HtmlInputButton htmlInputButton = new HtmlInputButton();
        htmlInputButton.Value = "modifica";
        htmlInputButton.Attributes.Add("class", "ButtonCampi");
        htmlInputButton.Attributes.Add("onclick", "OpenWindow(" + (object) Convert.ToInt32(this.IdQuery) + "," + (object) tuttiCampiRow.IdGlossario + ",document.getElementById('" + this.TuttiClientId + "').tBodies[0],this);");
        cell9.Controls.Add((Control) htmlInputButton);
        cell9.CssClass = "TableCellInfoCampi";
        row2.Cells.Add(cell9);
      }
      this.TableTuttiCampi.Height = Unit.Pixel(20);
    }

    private DataTable GetTuttiCampi()
    {
      int num1 = 0;
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pIdQuery");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(32);
      S_Object sObject2 = sObject1;
      int num2 = num1;
      int num3 = num2 + 1;
      ((ParameterObject) sObject2).set_Index(num2);
      ((ParameterObject) sObject1).set_Value((object) this.IdQuery);
      controlsCollection.Add(sObject1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pSelected");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      S_Object sObject4 = sObject3;
      int num4 = num3;
      int num5 = num4 + 1;
      ((ParameterObject) sObject4).set_Index(num4);
      ((ParameterObject) sObject3).set_Value((object) 0);
      controlsCollection.Add(sObject3);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("pSortExpression");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size(100);
      ((ParameterObject) sObject5).set_Value(Convert.ToString(this.ViewState["campoDiOrdinamento"]) == "" ? (object) " il_glossario.Tabella || ' - ' || il_glossario.Alias " : (object) Convert.ToString(this.ViewState["campoDiOrdinamento"]));
      S_Object sObject6 = sObject5;
      int num6 = num5;
      int num7 = num6 + 1;
      ((ParameterObject) sObject6).set_Index(num6);
      controlsCollection.Add(sObject5);
      int int32 = Convert.ToInt32(((Hashtable) this.Session["ParametriSelectSchema"])[(object) "IdVista"]);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("pIdVista");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(32);
      ((ParameterObject) sObject7).set_Value((object) int32);
      S_Object sObject8 = sObject7;
      int num8 = num7;
      int num9 = num8 + 1;
      ((ParameterObject) sObject8).set_Index(num8);
      controlsCollection.Add(sObject7);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("io_cursor");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Output);
      S_Object sObject10 = sObject9;
      int num10 = num9;
      int num11 = num10 + 1;
      ((ParameterObject) sObject10).set_Index(num10);
      controlsCollection.Add(sObject9);
      this.paramFederico = controlsCollection;
      this.CurrentProcedure = "IL_PACK_INTERROGAZIONI.IL_SpSelectGlossario";
      return this.GetData();
    }

    private DataTable GetCampiQuery()
    {
      int num1 = 0;
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pIdQuery");
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Value((object) this.IdQuery);
      ((ParameterObject) sObject1).set_Size(32);
      S_Object sObject2 = sObject1;
      int num2 = num1;
      int num3 = num2 + 1;
      ((ParameterObject) sObject2).set_Index(num2);
      controlsCollection.Add(sObject1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pSelected");
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Value((object) 1);
      ((ParameterObject) sObject3).set_Size(32);
      S_Object sObject4 = sObject3;
      int num4 = num3;
      int num5 = num4 + 1;
      ((ParameterObject) sObject4).set_Index(num4);
      controlsCollection.Add(sObject3);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("pSortExpression");
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Size(100);
      S_Object sObject6 = sObject5;
      int num6 = num5;
      int num7 = num6 + 1;
      ((ParameterObject) sObject6).set_Index(num6);
      ((ParameterObject) sObject5).set_Value(Convert.ToString(this.ViewState["campoDiOrdinamento"]) == "" ? (object) " dbo.IL_SCHEMA_DETTAGLIO.Posizione " : (object) Convert.ToString(this.ViewState["campoDiOrdinamento"]));
      controlsCollection.Add(sObject5);
      int int32 = Convert.ToInt32(((Hashtable) this.Session["ParametriSelectSchema"])[(object) "IdVista"]);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("pIdVista");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(32);
      ((ParameterObject) sObject7).set_Value((object) int32);
      S_Object sObject8 = sObject7;
      int num8 = num7;
      int num9 = num8 + 1;
      ((ParameterObject) sObject8).set_Index(num8);
      controlsCollection.Add(sObject7);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("io_cursor");
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 8);
      S_Object sObject10 = sObject9;
      int num10 = num9;
      int num11 = num10 + 1;
      ((ParameterObject) sObject10).set_Index(num10);
      controlsCollection.Add(sObject9);
      this.paramFederico = controlsCollection;
      this.CurrentProcedure = "IL_PACK_INTERROGAZIONI.IL_SpSelectGlossario";
      return this.GetData();
    }

    private DataTable GetFiltriCampo(int IdCampo)
    {
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pIdQuery");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Value((object) this.IdQuery);
      ((ParameterObject) sObject1).set_Size(32);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pIdCampo");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Value((object) IdCampo);
      ((ParameterObject) sObject1).set_Size(32);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pSortExpression");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Size(100);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Value(Convert.ToString(this.ViewState["campoDiOrdinamento"]) == "" ? (object) "NULL" : (object) Convert.ToString(this.ViewState["campoDiOrdinamento"]));
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("io_cursor");
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 8);
      controlsCollection.Add(sObject4);
      this.paramFederico = controlsCollection;
      this.CurrentProcedure = "IL_PACK_INTERROGAZIONI.IL_SpSelectFiltri";
      return this.GetData();
    }

    private string NormalizzaFiltri(int IdCampo)
    {
      DataTable filtriCampo = this.GetFiltriCampo(IdCampo);
      string str = string.Empty;
      foreach (DataRow row in (InternalDataCollectionBase) filtriCampo.Rows)
      {
        if (str != string.Empty)
          str += "$";
        str = str + "" + Convert.ToString(row["IdCriteri"]) + "&" + Convert.ToString(row["operatore"]) + "&" + Convert.ToString(row["Valore1"]) + "&" + Convert.ToString(row["Valore2"]);
      }
      return str;
    }

    private void BindCampiSel()
    {
      this.TableCampiSel.Rows.Clear();
      this.dataSetReport1.Campi.Clear();
      DataTable campiQuery = this.GetCampiQuery();
      foreach (DataRow row in (InternalDataCollectionBase) campiQuery.Rows)
        this.dataSetReport1.Campi.ImportRow(row);
      campiQuery.Dispose();
      TableRow row1 = new TableRow();
      TableCell cell1 = new TableCell();
      cell1.Text = "Doppio Click per togliere";
      cell1.CssClass = "TableHeaderCampi2";
      cell1.Attributes.Add("ondblclick", "SelectItem(this.parentNode,'qui')");
      row1.Cells.Add(cell1);
      this.TableCampiSel.Rows.Add(row1);
      int num = 1;
      foreach (DataSetReport.CampiRow campiRow in this.dataSetReport1.Campi)
      {
        TableRow row2 = new TableRow();
        TableCell cell2 = new TableCell();
        if (num % 2 == 0)
          row2.CssClass = "TableRowCampiSel";
        else
          row2.CssClass = "TableRowCampiSelAlt";
        cell2.Text = campiRow.Alias;
        row2.Attributes.Add("desc", Convert.ToString(campiRow.NomeTabella) + " - " + Convert.ToString(campiRow.Alias));
        row2.Attributes.Add("title", Convert.ToString(campiRow.NomeCampo));
        cell2.CssClass = "TableCellCampiSel";
        cell2.Width = Unit.Pixel(250);
        row2.Attributes.Add("idItem", Convert.ToString(campiRow.IdGlossario));
        cell2.Attributes.Add("ondblclick", "SelectItem(this.parentNode,'qui')");
        row2.Attributes.Add("tipol", Convert.ToString(campiRow.Tipologia));
        row2.Attributes.Add("tipod", Convert.ToString(campiRow.TipoDato));
        row2.Cells.Add(cell2);
        TableCell cell3 = new TableCell();
        cell3.Text = this.GetImageOrdinamento(campiRow.Ordinamento);
        row2.Attributes.Add("ord", campiRow.Ordinamento);
        cell3.CssClass = "TableCellInfoCampi";
        row2.Cells.Add(cell3);
        string empty = string.Empty;
        TableCell cell4 = new TableCell();
        cell4.CssClass = "TableCellInfoCampi";
        string filtro = this.NormalizzaFiltri(campiRow.IdGlossario);
        row2.Attributes.Add("filtro", filtro);
        cell4.Text = this.GetImageFiltro(filtro);
        row2.Cells.Add(cell4);
        TableCell cell5 = new TableCell();
        cell5.Text = this.GetImageAggregazione(campiRow.Aggregazione);
        row2.Attributes.Add("aggr", campiRow.Aggregazione);
        cell5.CssClass = "TableCellInfoCampi";
        row2.Cells.Add(cell5);
        TableCell cell6 = new TableCell();
        cell6.Text = this.GetImageNascosto(campiRow.Nascosto);
        row2.Attributes.Add("nascosto", campiRow.Nascosto ? "1" : "0");
        cell6.CssClass = "TableCellInfoCampi";
        row2.Cells.Add(cell6);
        TableCell cell7 = new TableCell();
        HtmlImage htmlImage1 = new HtmlImage();
        htmlImage1.Src = "..\\..\\imgFunz\\freccia_su_4.gif";
        htmlImage1.Attributes.Add("class", "ButtonCampi");
        htmlImage1.Attributes.Add("onclick", "InversioneCampi(this,'su')");
        cell7.Controls.Add((Control) htmlImage1);
        cell7.CssClass = "TableCellInfoCampi";
        row2.Cells.Add(cell7);
        TableCell cell8 = new TableCell();
        HtmlImage htmlImage2 = new HtmlImage();
        htmlImage2.Src = "..\\..\\imgFunz\\freccia_giu_4.gif";
        htmlImage2.Attributes.Add("class", "ButtonCampi");
        htmlImage2.Attributes.Add("onclick", "InversioneCampi(this,'giu')");
        cell8.Controls.Add((Control) htmlImage2);
        cell8.CssClass = "TableCellInfoCampi";
        row2.Cells.Add(cell8);
        TableCell cell9 = new TableCell();
        HtmlInputButton htmlInputButton = new HtmlInputButton();
        htmlInputButton.Value = "modifica";
        htmlInputButton.Attributes.Add("class", "ButtonCampi");
        htmlInputButton.Attributes.Add("onclick", "OpenWindow(" + (object) Convert.ToInt32(this.IdQuery) + "," + (object) campiRow.IdGlossario + ",document.getElementById('" + this.TuttiClientId + "').tBodies[0],this);");
        cell9.Controls.Add((Control) htmlInputButton);
        cell9.CssClass = "TableCellInfoCampi";
        row2.Cells.Add(cell9);
        this.TableCampiSel.Rows.Add(row2);
        if (this.SelectedItems.Value != "")
          this.SelectedItems.Value += "?";
        this.SelectedItems.Value += Convert.ToString(campiRow.IdGlossario);
        this.SelectedItems.Value += "#";
        HtmlInputHidden selectedItems = this.SelectedItems;
        selectedItems.Value = selectedItems.Value + Convert.ToString(campiRow.NomeTabella) + " - " + Convert.ToString(campiRow.Alias);
        this.SelectedItems.Value += "#";
        this.SelectedItems.Value += Convert.ToString(campiRow.Ordinamento);
        this.SelectedItems.Value += "#";
        this.SelectedItems.Value += filtro;
        this.SelectedItems.Value += "#";
        this.SelectedItems.Value += Convert.ToString(!campiRow.Nascosto);
        this.SelectedItems.Value += "#";
        this.SelectedItems.Value += Convert.ToString(campiRow.Aggregazione);
        this.SelectedItems.Value += "#";
        this.SelectedItems.Value += Convert.ToString(num++);
        this.SelectedItems.Value += "#";
        this.SelectedItems.Value += Convert.ToString(campiRow.Tipologia);
        this.SelectedItems.Value += "#";
        this.SelectedItems.Value += Convert.ToString(campiRow.TipoDato);
      }
      this.TableCampiSel.Height = Unit.Pixel(20);
    }

    protected string GetImageOrdinamento(string ordinamento)
    {
      if (ordinamento == "ASC")
        return "<img src='..\\Image\\ico-crescente.gif' border='0'>";
      return ordinamento == "DESC" ? "<img src='..\\Image\\ico-decrescente.gif' border='0'>" : "<img src='..\\Image\\ico-vuota.gif' border='0'>";
    }

    protected string GetImageFiltro(string filtro) => filtro != string.Empty ? "<img src='..\\Image\\ico-filtro.gif' border='0'>" : "<img src='..\\Image\\ico-vuota.gif' border='0'>";

    protected string GetImageAggregazione(string aggr) => aggr != "NESSUNO" ? "<img src='..\\Image\\ico-fx.gif' border='0'>" : "<img src='..\\Image\\ico-vuota.gif' border='0'>";

    protected string GetImageNascosto(bool nascosto) => !nascosto ? "<img src='..\\Image\\ico-selezione.gif' border='0'>" : "<img src='..\\Image\\ico-vuota.gif' border='0'>";

    protected string GetImageVuota() => "<img src='..\\Image\\ico-vuota.gif' border='0'>";

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.dataSetReport1 = new DataSetReport();
      this.dataSetReport1.BeginInit();
      this.dataSetReport1.DataSetName = "DataSetReport";
      this.dataSetReport1.Locale = new CultureInfo("en-US");
      this.BtnSalva.Click += new EventHandler(this.BtnSalva_Click);
      this.BtnAnnulla.Click += new EventHandler(this.BtnAnnulla_Click);
      this.ButtonVisualizza.Click += new EventHandler(this.ButtonVisualizza_Click);
      this.BtnExcel.Click += new EventHandler(this.BtnExcel_Click);
      this.BtnCopia.Click += new EventHandler(this.BtnCopia_Click);
      this.Load += new EventHandler(this.Page_Load);
      this.dataSetReport1.EndInit();
    }

    private void BtnSalva_Click(object sender, EventArgs e) => this.Salva(true);

    private void Salva(bool salva)
    {
      char ch1 = '?';
      char ch2 = '#';
      char ch3 = '$';
      char ch4 = '&';
      string str1 = this.SelectedItems.Value;
      string[] strArray1 = str1.Split(ch1);
      this.InsertUpdateSchema(this.TextTitolo.Text, this.TextDescrizione.Text, salva);
      this.DeleteDettaglio();
      this.DeleteCriteri();
      int num = 0;
      if (str1.Trim() != "")
      {
        foreach (string str2 in strArray1)
        {
          char[] chArray1 = new char[1]{ ch2 };
          string[] strArray2 = str2.Split(chArray1);
          string str3 = strArray2[0];
          string Ordinamento = strArray2[2];
          string str4 = strArray2[3];
          string str5 = strArray2[4];
          string Funzione = strArray2[5];
          if (str5 == "0")
            str5 = "true";
          if (str5 == "1")
            str5 = "false";
          this.InsertDettaglio(Convert.ToInt32(str3), Ordinamento, Funzione, Convert.ToBoolean(str5), num++);
          if (str4 != string.Empty)
          {
            string str6 = str4;
            char[] chArray2 = new char[1]{ ch3 };
            foreach (string str7 in str6.Split(chArray2))
            {
              if (str7 != string.Empty)
              {
                string[] strArray3 = str7.Split(ch4);
                string str8 = strArray3[0];
                string operatore = strArray3[1];
                string val1 = strArray3[2];
                string val2 = strArray3[3];
                this.InsertCriteri(Convert.ToInt32(str3), operatore, val1, val2);
              }
            }
          }
        }
      }
      this.IdQuery = this.NewIdQuery;
      ((DefaultReport) this.Page).RicaricaLista();
    }

    private void InsertUpdateSchema(string titolo, string descrizione, bool salva)
    {
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pIdSchema");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      if (salva)
        ((ParameterObject) sObject1).set_Value((object) this.IdQuery);
      else
        ((ParameterObject) sObject1).set_Value((object) 0);
      ((ParameterObject) sObject1).set_Index(0);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pDenominazione");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(100);
      ((ParameterObject) sObject2).set_Index(1);
      if (salva)
        ((ParameterObject) sObject2).set_Value((object) titolo);
      else if (this.txtHTitolo.Value == titolo)
        ((ParameterObject) sObject2).set_Value((object) (" copia di " + titolo));
      else
        ((ParameterObject) sObject2).set_Value((object) titolo);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pDescrizione");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Value((object) descrizione);
      ((ParameterObject) sObject3).set_Size(1000);
      ((ParameterObject) sObject3).set_Index(2);
      controlsCollection.Add(sObject3);
      int int32 = Convert.ToInt32(((Hashtable) this.Session["ParametriSelectSchema"])[(object) "IdVista"]);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("pIdVista");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Value((object) int32);
      ((ParameterObject) sObject4).set_Size(32);
      ((ParameterObject) sObject4).set_Index(3);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("putente");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Value((object) HttpContext.Current.User.Identity.Name);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("pId");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject6).set_Size(32);
      ((ParameterObject) sObject6).set_Index(5);
      controlsCollection.Add(sObject6);
      int rowsAffected = oracleDataLayer.GetRowsAffected((object) controlsCollection, "IL_PACK_INTERROGAZIONI.IL_SpInsertUpdateSchema");
      this.IdQuery = rowsAffected;
      this.NewIdQuery = rowsAffected;
    }

    private void DeleteDettaglio()
    {
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pIdSchema");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Value((object) this.IdQuery);
      ((ParameterObject) sObject1).set_Index(0);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pId");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Value((object) DBNull.Value);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      oracleDataLayer.ExecuteProcedure((object) controlsCollection, "IL_PACK_INTERROGAZIONI.IL_SpDeleteDettaglio");
    }

    private void InsertDettaglio(
      int IdGlossario,
      string Ordinamento,
      string Funzione,
      bool Visibile,
      int Posizione)
    {
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pIdSchema");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Size(32);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Value((object) (this.IdQuery == 0 ? this.NewIdQuery : this.IdQuery));
      ((ParameterObject) sObject1).set_Index(0);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pIdGlossario");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Size(32);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Value((object) IdGlossario);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pOrdinamento");
      ((ParameterObject) sObject3).set_Size(32);
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Value((object) Ordinamento);
      ((ParameterObject) sObject3).set_Index(2);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("pFunzione");
      ((ParameterObject) sObject4).set_Size(32);
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Value((object) Funzione);
      ((ParameterObject) sObject4).set_Index(3);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("pVisibile");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Size(32);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Value((object) (Visibile ? 0 : 1));
      ((ParameterObject) sObject5).set_Index(4);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("pPosizione");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Size(32);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Value((object) Posizione);
      ((ParameterObject) sObject6).set_Index(5);
      controlsCollection.Add(sObject6);
      oracleDataLayer.ExecuteProcedure((object) controlsCollection, "IL_PACK_INTERROGAZIONI.IL_SpInsertDettaglio");
    }

    private void DeleteCriteri()
    {
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pIdSchema");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Value((object) this.IdQuery);
      ((ParameterObject) sObject1).set_Size(32);
      ((ParameterObject) sObject1).set_Index(5);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pId");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_Value((object) DBNull.Value);
      ((ParameterObject) sObject2).set_Size(32);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      oracleDataLayer.ExecuteProcedure((object) controlsCollection, "IL_PACK_INTERROGAZIONI.IL_SpDeleteFiltri");
    }

    private void InsertCriteri(int idGlossario, string operatore, string val1, string val2)
    {
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pIdSchema");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Value((object) (this.IdQuery == 0 ? this.NewIdQuery : this.IdQuery));
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Size(32);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pIdGlossario");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Value((object) idGlossario);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Size(32);
      controlsCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pOperatore");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Value((object) operatore);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Size(32);
      controlsCollection.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("pValore1");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Value((object) val1);
      ((ParameterObject) sObject4).set_Index(3);
      ((ParameterObject) sObject4).set_Size(32);
      controlsCollection.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("pValore2");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Value((object) val2);
      ((ParameterObject) sObject5).set_Index(4);
      ((ParameterObject) sObject5).set_Size(32);
      controlsCollection.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("pId");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject6).set_Value((object) DBNull.Value);
      ((ParameterObject) sObject6).set_Index(5);
      ((ParameterObject) sObject6).set_Size(32);
      controlsCollection.Add(sObject6);
      oracleDataLayer.ExecuteProcedure((object) controlsCollection, "IL_PACK_INTERROGAZIONI.IL_SpInsertFiltro");
    }

    private void ButtonVisualizza_Click(object sender, EventArgs e)
    {
      this.Salva(true);
      this.Visible = true;
      this.Page.RegisterStartupScript("pippo", "<script language='javascript'>OpenVisualizzazione();</script>");
    }

    private void BtnAnnulla_Click(object sender, EventArgs e)
    {
      ((DefaultReport) this.Page).RicaricaLista();
      this.Ricarica();
    }

    private void BtnExcel_Click(object sender, EventArgs e)
    {
      this.Salva(true);
      this.Esport();
    }

    private void Esport()
    {
      Hashtable hashtable = (Hashtable) this.Session["ParametriSelectSchema"];
      string str1 = Convert.ToString(hashtable[(object) "NomeVista"]);
      int int32 = Convert.ToInt32(hashtable[(object) "IdVista"]);
      string str2 = " " + str1 + " ";
      DataSet data = new interogazioni()
      {
        VISTA = str2,
        IdVista = int32
      }.GetData(this.IdQuery);
      Export export = new Export();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = data.Tables[0].Copy();
      if (dataTable2.Rows.Count != 0)
      {
        export.ExportDetails(dataTable2, (Export.ExportFormat) 2, "exp.xls");
      }
      else
      {
        string str3 = "<script language=JavaScript>alert('Nessun elemento da esportare');" + "/" + "script>";
      }
    }

    private void BtnCopia_Click(object sender, EventArgs e) => this.Salva(false);
  }
}
