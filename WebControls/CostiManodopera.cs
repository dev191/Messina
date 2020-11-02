// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.CostiManodopera
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ManCorrettiva;

namespace TheSite.WebControls
{
  public class CostiManodopera : UserControl
  {
    protected DataGrid DataGridEsegui;
    protected Label lblRecord;
    protected LinkButton lkbNuovo;
    private int _wrId;
    protected Label lblTot1;
    private double totale;
    private double tot;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.Request.QueryString["ItemId"] != null)
        this._wrId = Convert.ToInt32(this.Request.QueryString["ItemId"]);
      if (this.Request["WR_ID"] != null)
        this._wrId = Convert.ToInt32(this.Request["WR_ID"]);
      DataSet dataSet1 = new ClManCorrettiva().TotManodopera(Convert.ToInt32(this.wrId));
      if (dataSet1.Tables[0].Rows.Count > 0)
        this.tot = Convert.ToDouble(dataSet1.Tables[0].Rows[0]["totaddetto"]);
      this.lblTot1.Text = Convert.ToString(this.tot);
      if (this.Page.IsPostBack)
        return;
      DataSet dataSet2 = new ClManCorrettiva().GetListaManodopera(this._wrId).Copy();
      DataTable dataTable = this.AggiungiColonnaTotProgressivo(dataSet2.Tables[0]);
      DataRow row = dataTable.NewRow();
      row["ID"] = (object) 0;
      row["IdAddetto"] = (object) 0;
      row["IdAddettoWR"] = (object) 0;
      row["CognomeNome"] = (object) DBNull.Value;
      row["Livello"] = (object) "<b>TOTALE</b>";
      row["PrezzoUnitario"] = (object) DBNull.Value;
      row["OreLavorate"] = (object) DBNull.Value;
      row["Totale"] = (object) 0;
      row["DescrizioneIntervento"] = (object) DBNull.Value;
      dataTable.Rows.Add(row);
      this.lblRecord.Text = dataSet2.Tables[0].Rows.Count.ToString();
      this.DataGridEsegui.DataSource = (object) dataTable;
      this.DataGridEsegui.DataBind();
    }

    private DataTable AggiungiColonnaTotProgressivo(DataTable tb) => tb;

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
      Label control1 = (Label) e.Item.FindControl("lblIdAddettoEdit");
      Label control2 = (Label) e.Item.FindControl("lblIdAddettoWREdit");
      DropDownList control3 = (DropDownList) e.Item.FindControl("cmbAddettoEdit");
      TextBox control4 = (TextBox) e.Item.FindControl("txtDescInterventoEdit");
      TextBox control5 = (TextBox) e.Item.FindControl("txtPrezzoUnitarioEdit");
      TextBox control6 = (TextBox) e.Item.FindControl("txtOreLavorateEdit");
      TextBox control7 = (TextBox) e.Item.FindControl("TexTotaleEdit");
      string text = control4.Text;
      int int32 = Convert.ToInt32(control3.SelectedValue.Split(';')[0]);
      double prezzoUnitario = Convert.ToDouble(control5.Text);
      int oreLavorate = !(control6.Text != "") ? 0 : Convert.ToInt32(control6.Text);
      double prezzoTotale = Convert.ToDouble(control7.Text);
      this.EseguiDataBaseManodopera(int.Parse(this.DataGridEsegui.DataKeys[e.Item.ItemIndex].ToString()), ExecuteType.Update, text, int32, prezzoUnitario, oreLavorate, prezzoTotale);
      this.DataGridEsegui.EditItemIndex = -1;
      this.BindGrid();
      if (!(control1.Text == control2.Text))
        return;
      e.Item.Style["background-color"] = "green";
    }

    private void DataGridEsegui_EditCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.EditItemIndex = e.Item.ItemIndex;
      this.BindGrid();
    }

    public bool GetStato(string IdAddettoVal, string IdAddettoWRVal) => !(IdAddettoVal == IdAddettoWRVal);

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
          Label control1 = (Label) e.Item.FindControl("lblIdAddettoInsert");
          Label control2 = (Label) e.Item.FindControl("lblIdAddettoWRInsert");
          DropDownList control3 = (DropDownList) e.Item.FindControl("cmbAddettoInsert");
          TextBox control4 = (TextBox) e.Item.FindControl("txtDescInterventoInsert");
          TextBox control5 = (TextBox) e.Item.FindControl("txtPrezzoUnitarioInsert");
          TextBox control6 = (TextBox) e.Item.FindControl("txtOreLavorateInsert");
          TextBox control7 = (TextBox) e.Item.FindControl("TexTotaleInsert");
          this.EseguiDataBaseManodopera(0, ExecuteType.Insert, control4.Text, Convert.ToInt32(control3.SelectedValue.Split(';')[0]), Convert.ToDouble(control5.Text), !(control6.Text != "") ? 0 : Convert.ToInt32(control6.Text), Convert.ToDouble(control7.Text));
          this.DataGridEsegui.EditItemIndex = -1;
          if (control1.Text == control2.Text)
            e.Item.Style["background-color"] = "#ffcc33";
          this.lblRecord.Text = (Convert.ToInt32(this.lblRecord.Text) + 1).ToString();
          this.BindGrid();
          break;
        case "Delete":
          this.EseguiDataBaseManodopera(int.Parse(this.DataGridEsegui.DataKeys[e.Item.ItemIndex].ToString()), ExecuteType.Delete, string.Empty, 0, 0.0, 0, 0.0);
          this.DataGridEsegui.EditItemIndex = -1;
          this.lblRecord.Text = (Convert.ToInt32(this.lblRecord.Text) - 1).ToString();
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
      DataSet dataSet = new ClManCorrettiva().GetListaManodopera(this._wrId).Copy();
      DataTable dataTable = this.AggiungiColonnaTotProgressivo(dataSet.Tables[0]);
      DataRow row = dataTable.NewRow();
      row["ID"] = (object) 0;
      row["IdAddetto"] = (object) 0;
      row["IdAddettoWR"] = (object) 0;
      row["CognomeNome"] = (object) DBNull.Value;
      row["Livello"] = (object) "<b>TOTALE</b>";
      row["PrezzoUnitario"] = (object) DBNull.Value;
      row["OreLavorate"] = (object) DBNull.Value;
      row["Totale"] = (object) 0;
      row["DescrizioneIntervento"] = (object) DBNull.Value;
      dataTable.Rows.Add(row);
      this.DataGridEsegui.DataSource = (object) dataTable;
      this.DataGridEsegui.DataBind();
      this.lblRecord.Text = dataSet.Tables[0].Rows.Count.ToString();
      this.DataGridEsegui.ShowFooter = false;
    }

    protected DataTable GetManodopera() => new ClManCorrettiva().getBindComboManodopera().Copy().Tables[0];

    protected int GetIndex(string item)
    {
      if (item.Length <= 0)
        return 0;
      DataSet dataSet = new ClManCorrettiva().getBindComboManodopera().Copy();
      int num = 0;
      foreach (DataRow row in (InternalDataCollectionBase) dataSet.Tables[0].Rows)
      {
        if (row[1].ToString().Trim() == item.Trim())
          return num;
        ++num;
      }
      return 0;
    }

    private int EseguiDataBaseManodopera(
      int id,
      ExecuteType Operazione,
      string descrizioneIntervento,
      int idManodopera,
      double prezzoUnitario,
      int oreLavorate,
      double prezzoTotale)
    {
      ClManCorrettiva clManCorrettiva = new ClManCorrettiva();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      int num1 = 0;
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id");
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
      ((ParameterObject) sObject5).set_ParameterName("p_descrizione_Interv");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      S_Object sObject6 = sObject5;
      int num6 = num5;
      int num7 = num6 + 1;
      ((ParameterObject) sObject6).set_Index(num6);
      if (descrizioneIntervento == string.Empty)
        ((ParameterObject) sObject5).set_Value((object) DBNull.Value);
      else
        ((ParameterObject) sObject5).set_Value((object) descrizioneIntervento);
      CollezioneControlli.Add(sObject5);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_IdAddetto");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      S_Object sObject8 = sObject7;
      int num8 = num7;
      int num9 = num8 + 1;
      ((ParameterObject) sObject8).set_Index(num8);
      ((ParameterObject) sObject7).set_Value((object) idManodopera);
      CollezioneControlli.Add(sObject7);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_PrezzoUnitario");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      S_Object sObject10 = sObject9;
      int num10 = num9;
      int num11 = num10 + 1;
      ((ParameterObject) sObject10).set_Index(num10);
      ((ParameterObject) sObject9).set_Value((object) prezzoUnitario);
      CollezioneControlli.Add(sObject9);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_Ore_lavorate");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      S_Object sObject12 = sObject11;
      int num12 = num11;
      int num13 = num12 + 1;
      ((ParameterObject) sObject12).set_Index(num12);
      ((ParameterObject) sObject11).set_Value((object) oreLavorate);
      CollezioneControlli.Add(sObject11);
      S_Object sObject13 = new S_Object();
      ((ParameterObject) sObject13).set_ParameterName("p_Totale");
      ((ParameterObject) sObject13).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject13).set_Direction(ParameterDirection.Input);
      S_Object sObject14 = sObject13;
      int num14 = num13;
      int num15 = num14 + 1;
      ((ParameterObject) sObject14).set_Index(num14);
      ((ParameterObject) sObject13).set_Value((object) prezzoTotale);
      CollezioneControlli.Add(sObject13);
      int num16 = clManCorrettiva.ExecuteManodopera(CollezioneControlli, Operazione);
      DataSet dataSet = new ClManCorrettiva().TotManodopera(Convert.ToInt32(this._wrId));
      if (dataSet.Tables[0].Rows.Count > 0)
        this.tot = Convert.ToDouble(dataSet.Tables[0].Rows[0]["totaddetto"]);
      this.lblTot1.Text = Convert.ToString(this.tot);
      return num16;
    }

    private void DataGridEsegui_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      Label control1 = (Label) e.Item.FindControl("lblTotale");
      ImageButton control2 = (ImageButton) e.Item.FindControl("imbEdit");
      if (control1 != null)
      {
        this.totale += Convert.ToDouble(control1.Text);
        if (e.Item.ItemIndex == Convert.ToInt32(this.lblRecord.Text) - 1)
        {
          control1.Text = this.FormattaDecimali((object) this.totale, (object) 2);
          control2.Visible = false;
          for (int index = 0; index <= 9; ++index)
          {
            if (index != 6)
              e.Item.Cells[index].BorderStyle = BorderStyle.None;
          }
        }
      }
      if (e.Item.ItemType == ListItemType.Footer)
      {
        Label control3 = (Label) e.Item.FindControl("lblIdAddettoInsert");
        Label control4 = (Label) e.Item.FindControl("lblIdAddettoWRInsert");
        DropDownList control5 = (DropDownList) e.Item.FindControl("cmbAddettoInsert");
        TextBox control6 = (TextBox) e.Item.FindControl("txtLivelloInsert");
        TextBox control7 = (TextBox) e.Item.FindControl("txtPrezzoUnitarioInsert");
        TextBox control8 = (TextBox) e.Item.FindControl("txtOreLavorateInsert");
        TextBox control9 = (TextBox) e.Item.FindControl("TexTotaleInsert");
        string str1 = "cmbSelezione('" + control5.ClientID + "','" + control6.ClientID + "','" + control7.ClientID + "','" + control8.ClientID + "','" + control9.ClientID + "');";
        control5.Attributes.Add("onchange", str1);
        string str2 = "calcolaPrezzoTotale('" + control7.ClientID + "','" + control8.ClientID + "','" + control9.ClientID + "');";
        control8.Attributes.Add("onkeyup", str2);
        string[] strArray = control5.SelectedValue.Split(';');
        control7.Attributes.Add("value", strArray[2].ToString());
        control6.Attributes.Add("value", strArray[1].ToString());
        control8.Attributes.Add("onkeypress", "ControllaCaratteri();");
        if (control3.Text == control4.Text)
          e.Item.Style["background-color"] = "#ffcc33";
        this.totale += (double) Convert.ToInt32(control9.Text);
      }
      if (e.Item.ItemType == ListItemType.EditItem)
      {
        Label control3 = (Label) e.Item.FindControl("lblIdAddettoEdit");
        Label control4 = (Label) e.Item.FindControl("lblIdAddettoWREdit");
        DropDownList control5 = (DropDownList) e.Item.FindControl("cmbAddettoEdit");
        TextBox control6 = (TextBox) e.Item.FindControl("txtLivelloEdit");
        TextBox control7 = (TextBox) e.Item.FindControl("txtPrezzoUnitarioEdit");
        TextBox control8 = (TextBox) e.Item.FindControl("txtOreLavorateEdit");
        TextBox control9 = (TextBox) e.Item.FindControl("TexTotaleEdit");
        string str1 = "cmbSelezione('" + control5.ClientID + "','" + control6.ClientID + "','" + control7.ClientID + "','" + control8.ClientID + "','" + control9.ClientID + "');";
        control5.Attributes.Add("onchange", str1);
        string str2 = "calcolaPrezzoTotale('" + control7.ClientID + "','" + control8.ClientID + "','" + control9.ClientID + "');";
        control8.Attributes.Add("onkeyup", str2);
        control8.Attributes.Add("onkeypress", "ControllaCaratteri();");
        if (control3.Text == control4.Text)
          e.Item.Style["background-color"] = "#ffcc33";
      }
      if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item || !(((Label) e.Item.FindControl("lblIdAddetto")).Text == ((Label) e.Item.FindControl("lblIdAddettoWR")).Text))
        return;
      e.Item.Cells[3].Style["border-bottom-color"] = "red";
      e.Item.Cells[3].Style["border-bottom-width"] = "2px";
      e.Item.Cells[3].Style["border-bottom-style"] = "solid";
      e.Item.Cells[3].Style["border-top-color"] = "red";
      e.Item.Cells[3].Style["border-top-width"] = "2px";
      e.Item.Cells[3].Style["border-top-style"] = "solid";
      e.Item.Cells[3].Style["border-left-color"] = "red";
      e.Item.Cells[3].Style["border-left-width"] = "2px";
      e.Item.Cells[3].Style["border-left-style"] = "solid";
      for (int index = 4; index < 9; ++index)
      {
        e.Item.Cells[index].Style["border-bottom-color"] = "red";
        e.Item.Cells[index].Style["border-bottom-width"] = "2px";
        e.Item.Cells[index].Style["border-bottom-style"] = "solid";
        e.Item.Cells[index].Style["border-top-color"] = "red";
        e.Item.Cells[index].Style["border-top-width"] = "2px";
        e.Item.Cells[index].Style["border-top-style"] = "solid";
      }
      e.Item.Cells[9].Style["border-bottom-color"] = "red";
      e.Item.Cells[9].Style["border-bottom-width"] = "2px";
      e.Item.Cells[9].Style["border-bottom-style"] = "solid";
      e.Item.Cells[9].Style["border-top-color"] = "red";
      e.Item.Cells[9].Style["border-top-width"] = "2px";
      e.Item.Cells[9].Style["border-top-style"] = "solid";
      e.Item.Cells[9].Style["border-right-color"] = "red";
      e.Item.Cells[9].Style["border-right-width"] = "2px";
      e.Item.Cells[9].Style["border-right-style"] = "solid";
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
      return numero != DBNull.Value ? Convert.ToDecimal(numero).ToString("N", (IFormatProvider) numberFormat) : string.Empty;
    }
  }
}
