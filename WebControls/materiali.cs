// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.materiali
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ManCorrettiva;

namespace TheSite.WebControls
{
  public class materiali : UserControl
  {
    protected DataGrid DataGridEsegui;
    protected Label lblRecord;
    protected LinkButton lkbNuovo;
    protected Label lblTot;
    private int _wrId;
    private double tot;
    private Decimal valoreColonna;

    private void Page_Load(object sender, EventArgs e)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<script language=\"javascript\">\n");
      stringBuilder.Append("Segnalibro();");
      stringBuilder.Append("</script>");
      this.Page.RegisterStartupScript("loc", stringBuilder.ToString());
      if (this.Page.IsPostBack)
        return;
      DataSet dataSet = new ClManCorrettiva().GetListaMateriali(this._wrId).Copy();
      this.DataGridEsegui.DataSource = (object) this.AggiungiColonnaTotProgressivo(dataSet.Tables[0]);
      this.DataGridEsegui.DataBind();
      this.lblRecord.Text = dataSet.Tables[0].Rows.Count.ToString();
      this.ValorizzaTot();
    }

    private void ValorizzaTot()
    {
      DataSet dataSet = new ClManCorrettiva().TotManodopera(Convert.ToInt32(this._wrId));
      if (dataSet.Tables[0].Rows.Count > 0)
        this.tot = Convert.ToDouble(dataSet.Tables[0].Rows[0]["totmateriale"]);
      this.lblTot.Text = Convert.ToString(this.tot);
    }

    private DataTable AggiungiColonnaTotProgressivo(DataTable tb)
    {
      tb.Columns.Add(new DataColumn("Totale_Progressivo")
      {
        DataType = Type.GetType("System.String")
      });
      if (tb.Rows.Count > 0)
      {
        tb.Rows[0][7] = (object) this.FormattaDecimali(tb.Rows[0][5], (object) 2);
        for (int index = 1; index < tb.Rows.Count; ++index)
        {
          this.valoreColonna = Convert.ToDecimal(tb.Rows[index - 1][7]) + Convert.ToDecimal(tb.Rows[index][5]);
          tb.Rows[index][7] = (object) this.FormattaDecimali((object) this.valoreColonna, (object) 2);
        }
      }
      return tb;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.lkbNuovo.Click += new EventHandler(this.lkbNuovo_Click);
      this.DataGridEsegui.ItemCommand += new DataGridCommandEventHandler(this.DataGridEsegui_ItemCommand);
      this.DataGridEsegui.CancelCommand += new DataGridCommandEventHandler(this.DataGridEsegui_CancelCommand);
      this.DataGridEsegui.EditCommand += new DataGridCommandEventHandler(this.DataGridEsegui_EditCommand);
      this.DataGridEsegui.UpdateCommand += new DataGridCommandEventHandler(this.DataGridEsegui_UpdateCommand);
      this.DataGridEsegui.ItemDataBound += new DataGridItemEventHandler(this.DataGridEsegui_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void DataGridEsegui_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.EditItemIndex = -1;
      this.BindGrid();
    }

    private void DataGridEsegui_EditCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.EditItemIndex = e.Item.ItemIndex;
      this.BindGrid();
    }

    private void DataGridEsegui_CancelCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.EditItemIndex = -1;
      this.BindGrid();
    }

    private void DataGridEsegui_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      switch (((ImageButton) e.CommandSource).CommandName)
      {
        case "Insert":
          DropDownList control1 = (DropDownList) e.Item.FindControl("cmbMaterialiInsert");
          TextBox control2 = (TextBox) e.Item.FindControl("txtprezzoInsert");
          TextBox control3 = (TextBox) e.Item.FindControl("txtquantitaInset");
          TextBox control4 = (TextBox) e.Item.FindControl("txttotaleInsert");
          this.EseguiDataBaseMateriale(0, ExecuteType.Insert, Convert.ToInt32(control1.SelectedValue.Split(';')[0]), Convert.ToDouble(control2.Text), !(control3.Text != "") ? 0 : Convert.ToInt32(control3.Text), Convert.ToDouble(control4.Text));
          this.DataGridEsegui.EditItemIndex = -1;
          this.BindGrid();
          break;
        case "Delete":
          this.EseguiDataBaseMateriale(int.Parse(this.DataGridEsegui.DataKeys[e.Item.ItemIndex].ToString()), ExecuteType.Delete, 0, 0.0, 0, 0.0);
          this.DataGridEsegui.EditItemIndex = -1;
          this.BindGrid();
          break;
      }
    }

    private void lkbNuovo_Click(object sender, EventArgs e)
    {
      this.DataGridEsegui.EditItemIndex = -1;
      this.BindGrid();
      this.DataGridEsegui.ShowFooter = true;
    }

    private void BindGrid()
    {
      DataSet dataSet = new ClManCorrettiva().GetListaMateriali(this._wrId).Copy();
      this.DataGridEsegui.DataSource = (object) this.AggiungiColonnaTotProgressivo(dataSet.Tables[0]);
      this.DataGridEsegui.DataBind();
      this.lblRecord.Text = dataSet.Tables[0].Rows.Count.ToString();
      this.DataGridEsegui.ShowFooter = false;
      this.ValorizzaTot();
    }

    protected DataTable GetMateriali() => new ClManCorrettiva().getBindComboMateriali().Copy().Tables[0];

    protected int GetIndex(string item)
    {
      if (item.Length <= 0)
        return 0;
      DataSet dataSet = new ClManCorrettiva().getBindComboMateriali().Copy();
      int num = 0;
      foreach (DataRow row in (InternalDataCollectionBase) dataSet.Tables[0].Rows)
      {
        if (row[1].ToString().Trim() == item.Trim())
          return num;
        ++num;
      }
      return 0;
    }

    private int EseguiDataBaseMateriale(
      int id,
      ExecuteType Operazione,
      int idMateriale,
      double prezzoUnitario,
      int quantita,
      double prezzoTotale)
    {
      ClManCorrettiva clManCorrettiva = new ClManCorrettiva();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      int num1 = 0;
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_ID");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      S_Object sObject2 = sObject1;
      int num2 = num1;
      int num3 = num2 + 1;
      ((ParameterObject) sObject2).set_Index(num2);
      ((ParameterObject) sObject1).set_Value((object) id);
      CollezioneControlli.Add(sObject1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_WrId");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      S_Object sObject4 = sObject3;
      int num4 = num3;
      int num5 = num4 + 1;
      ((ParameterObject) sObject4).set_Index(num4);
      ((ParameterObject) sObject3).set_Value((object) this._wrId);
      CollezioneControlli.Add(sObject3);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_IdMateriale");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      S_Object sObject6 = sObject5;
      int num6 = num5;
      int num7 = num6 + 1;
      ((ParameterObject) sObject6).set_Index(num6);
      ((ParameterObject) sObject5).set_Value((object) idMateriale);
      CollezioneControlli.Add(sObject5);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_PrezzoUnitario");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      S_Object sObject8 = sObject7;
      int num8 = num7;
      int num9 = num8 + 1;
      ((ParameterObject) sObject8).set_Index(num8);
      ((ParameterObject) sObject7).set_Value((object) prezzoUnitario);
      CollezioneControlli.Add(sObject7);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_Quantita");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      S_Object sObject10 = sObject9;
      int num10 = num9;
      int num11 = num10 + 1;
      ((ParameterObject) sObject10).set_Index(num10);
      ((ParameterObject) sObject9).set_Value((object) quantita);
      CollezioneControlli.Add(sObject9);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_Totale");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      S_Object sObject12 = sObject11;
      int num12 = num11;
      int num13 = num12 + 1;
      ((ParameterObject) sObject12).set_Index(num12);
      ((ParameterObject) sObject11).set_Value((object) prezzoTotale);
      CollezioneControlli.Add(sObject11);
      return clManCorrettiva.ExecuteMateriali(CollezioneControlli, Operazione);
    }

    private void DataGridEsegui_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Footer)
      {
        TextBox control1 = (TextBox) e.Item.FindControl("txtprezzoInsert");
        TextBox control2 = (TextBox) e.Item.FindControl("txtunitaInsert");
        TextBox control3 = (TextBox) e.Item.FindControl("txtquantitaInset");
        TextBox control4 = (TextBox) e.Item.FindControl("txttotaleInsert");
        DropDownList control5 = (DropDownList) e.Item.FindControl("cmbMaterialiInsert");
        ((UserMateriali) e.Item.FindControl("UserMateriali1In")).wrIdIn = this._wrId.ToString();
      }
      if (e.Item.ItemType == ListItemType.EditItem)
      {
        TextBox control1 = (TextBox) e.Item.FindControl("txtprezzoEdit");
        TextBox control2 = (TextBox) e.Item.FindControl("txtunitaEdit");
        TextBox control3 = (TextBox) e.Item.FindControl("txtquantitaEdit");
        TextBox control4 = (TextBox) e.Item.FindControl("txttotaleEdit");
        DropDownList control5 = (DropDownList) e.Item.FindControl("cmbMaterialiEdit");
        UserMateriali control6 = (UserMateriali) e.Item.FindControl("UserMateriali1");
        int id = int.Parse(this.DataGridEsegui.DataKeys[e.Item.ItemIndex].ToString());
        control6.idMat = Convert.ToString(id);
        control6.wrId = this._wrId.ToString();
        DataSet dataSet = new ClManCorrettiva().getMaterialiId(id).Copy();
        control6.DescrizioneMateriali = dataSet.Tables[0].Rows[0]["descr"].ToString();
        control6.PrezzoUnitario = dataSet.Tables[0].Rows[0]["prezzo_unitario"].ToString();
        control6.UnitMisura = dataSet.Tables[0].Rows[0]["unita"].ToString();
        control6.Quantita = dataSet.Tables[0].Rows[0]["quantita"].ToString();
        control6.Totale = dataSet.Tables[0].Rows[0]["totale"].ToString();
        control6.Materiale = dataSet.Tables[0].Rows[0]["materiale"].ToString();
      }
      int itemType = (int) e.Item.ItemType;
    }

    public int wrId
    {
      get => this._wrId;
      set => this._wrId = value;
    }

    public void AggiornaDati() => this.BindGrid();

    protected string FormattaDecimali(object numero, object cifre)
    {
      NumberFormatInfo numberFormat = new CultureInfo("it-IT", false).NumberFormat;
      numberFormat.NumberDecimalDigits = Convert.ToInt32(cifre);
      return Convert.ToDecimal(numero).ToString("N", (IFormatProvider) numberFormat);
    }
  }
}
