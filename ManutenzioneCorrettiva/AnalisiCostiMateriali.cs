// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorrettiva.AnalisiCostiMateriali
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorrettiva
{
  public class AnalisiCostiMateriali : Page
  {
    protected DataPanel PanelRicerca;
    protected S_ComboBox cmbsMateriale;
    protected S_TextBox txtRdl;
    protected S_Button btnsRicerca;
    protected CalendarPicker CalendarPicker1;
    protected DataGrid DataGridRicerca;
    protected CalendarPicker CalendarPicker2;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    protected S_ComboBox cmbsStato;
    protected LinkButton lkbNuovo;
    protected Label lblRecord;
    protected HtmlInputHidden wr_id;
    protected S_Button BtnReset;
    protected ValidationSummary ValidationSummary1;
    protected S_Button ExpPdf;
    private AnalisiCostiMateriali _AnalisiCostiMateriali;
    public string dascmat = "";
    public string prezzo = "";
    public string id = "";
    protected S_Button s_cmdanagmat;
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      AnalisiCostiMateriali.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = "ANALISI COSTI MATERIALI";
      ((WebControl) this.btnsRicerca).Attributes.Add("onclick", "return validateRange();");
      ((WebControl) this.ExpPdf).Attributes.Add("onclick", "OpenPopUp();");
      this.txtRdl.set_DBDefaultValue((object) -1);
      this.DataGridRicerca.Visible = false;
      AnalisiCostiMateriali.FunId = siteModule.ModuleId;
      ((WebControl) this.s_cmdanagmat).Attributes.Add("onclick", "apriAnagMat(" + (object) AnalisiCostiMateriali.FunId + ");");
      if (this.IsPostBack)
        return;
      this.BindMateriali();
    }

    private void BindMateriali()
    {
      TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali analisiCostiMateriali = new TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali();
      ((ListControl) this.cmbsMateriale).Items.Clear();
      DataSet dataSet = analisiCostiMateriali.GetData().Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsMateriale).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "id", "- Selezionare Materiale -", "-1");
        ((ListControl) this.cmbsMateriale).DataTextField = "descrizione";
        ((ListControl) this.cmbsMateriale).DataValueField = "id";
        ((Control) this.cmbsMateriale).DataBind();
      }
      else
        ((ListControl) this.cmbsMateriale).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Materiale-", string.Empty));
    }

    protected DataTable GetMateriali() => new TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali().GetData().Copy().Tables[0];

    protected int GetIndex(string item)
    {
      if (item.Length <= 0)
        return 0;
      DataSet dataSet = new TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali().GetData().Copy();
      int num = 0;
      foreach (DataRow row in (InternalDataCollectionBase) dataSet.Tables[0].Rows)
      {
        if (row[1].ToString().Trim() == item.Trim())
          return num;
        ++num;
      }
      return 0;
    }

    protected string FormattaDecimali(object numero, object cifre)
    {
      if (numero == DBNull.Value)
        return "";
      NumberFormatInfo numberFormat = new CultureInfo("it-IT", false).NumberFormat;
      numberFormat.NumberDecimalDigits = Convert.ToInt32(cifre);
      return Convert.ToDecimal(numero).ToString("N", (IFormatProvider) numberFormat);
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsRicerca).Click += new EventHandler(this.btnsRicerca_Click);
      ((Button) this.BtnReset).Click += new EventHandler(this.BtnReset_Click);
      this.lkbNuovo.Click += new EventHandler(this.lkbNuovo_Click);
      this.DataGridRicerca.ItemCreated += new DataGridItemEventHandler(this.DataGridRicerca_ItemCreated);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      this.DataGridRicerca.CancelCommand += new DataGridCommandEventHandler(this.DataGridRicerca_CancelCommand);
      this.DataGridRicerca.EditCommand += new DataGridCommandEventHandler(this.DataGridRicerca_EditCommand);
      this.DataGridRicerca.UpdateCommand += new DataGridCommandEventHandler(this.DataGridRicerca_UpdateCommand);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      ((Button) this.s_cmdanagmat).Click += new EventHandler(this.s_cmdanagmat_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnsRicerca_Click(object sender, EventArgs e) => this.Ricerca();

    private void Ricerca()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_wrid");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) (((TextBox) this.txtRdl).Text == string.Empty ? 0 : int.Parse(((TextBox) this.txtRdl).Text)));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_id_materiale");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(50);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) Convert.ToInt32(((ListControl) this.cmbsMateriale).SelectedValue.ToString().Split(';')[0]));
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_dataaggiornamentoDal");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(50);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject3).set_Value((object) ((TextBox) this.CalendarPicker1.Datazione).Text);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_dataaggiornamentoAl");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(50);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject4).set_Value((object) ((TextBox) this.CalendarPicker2.Datazione).Text);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_stato");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Size(50);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject5).set_Value((object) Convert.ToInt32(((ListControl) this.cmbsStato).SelectedValue));
      CollezioneControlli.Add(sObject5);
      DataSet data = new TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali().GetData(CollezioneControlli);
      if (data.Tables[0].Rows.Count >= 0)
      {
        this.DataGridRicerca.Visible = true;
        this.lblRecord.Text = "";
        DataTable table = data.Tables[0];
        string str1 = string.Empty;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        for (; num1 <= table.Rows.Count - 1; ++num1)
        {
          string str2 = table.Rows[num1]["ID_MATERIALE"].ToString();
          if (num1 == 0)
            str1 = table.Rows[num1]["ID_MATERIALE"].ToString();
          if (str2 != str1)
          {
            str1 = str2;
            DataRow row = table.NewRow();
            row["Descrizione"] = (object) "Materiale";
            row["prezzo_unitario"] = (object) num2;
            row["totale"] = (object) num3;
            row["quantita"] = (object) (num2 + num3);
            row["id"] = (object) -1;
            table.Rows.InsertAt(row, num1);
            num2 = 0;
            num3 = 0;
            ++num1;
          }
          if (Convert.ToInt32(table.Rows[num1]["quantita"]) > 0)
            num2 += Convert.ToInt32(table.Rows[num1]["quantita"]);
          else
            num3 += Convert.ToInt32(table.Rows[num1]["quantita"]);
        }
        if (table.Rows.Count > 0)
        {
          DataRow row = table.NewRow();
          row["Descrizione"] = (object) "Materiale";
          row["prezzo_unitario"] = (object) num2;
          row["totale"] = (object) num3;
          row["quantita"] = (object) (num2 + num3);
          row["id"] = (object) -1;
          table.Rows.InsertAt(row, num1);
        }
        this.DataGridRicerca.DataSource = (object) table;
        this.lblRecord.Text = data.Tables[0].Rows.Count == 0 ? "0" : data.Tables[0].Rows.Count.ToString();
        this.DataGridRicerca.DataBind();
      }
      else
      {
        this.lblRecord.Text = "Nessun dato trovato.";
        this.DataGridRicerca.Visible = false;
      }
      this.DataGridRicerca.ShowFooter = false;
    }

    private void DataGridRicerca_EditCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridRicerca.EditItemIndex = e.Item.ItemIndex;
      int.Parse(this.DataGridRicerca.DataKeys[e.Item.ItemIndex].ToString());
      this.Ricerca();
    }

    private void DataGridRicerca_CancelCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridRicerca.EditItemIndex = -1;
      this.Ricerca();
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Footer)
      {
        TextBox control1 = (TextBox) e.Item.FindControl("txtprezzoInsert");
        TextBox control2 = (TextBox) e.Item.FindControl("TxtDescMat");
        TextBox control3 = (TextBox) e.Item.FindControl("txtprezzoInsert");
        TextBox control4 = (TextBox) e.Item.FindControl("txtquantitaInset");
        TextBox control5 = (TextBox) e.Item.FindControl("txttotaleInsert");
        DropDownList control6 = (DropDownList) e.Item.FindControl("cmbMaterialiInsert");
        TextBox control7 = (TextBox) e.Item.FindControl("IdMateriale");
        this.dascmat = control2.ClientID;
        this.prezzo = control3.ClientID;
        this.id = control7.ClientID;
        string str1 = "cmbSelezione('" + control6.ClientID + "','" + control1.ClientID + "','" + control4.ClientID + "','" + control5.ClientID + "');";
        control6.Attributes.Add("onchange", str1);
        string str2 = "calcolaPrezzoTotale('" + control1.ClientID + "','" + control4.ClientID + "','" + control5.ClientID + "');";
        control4.Attributes.Add("onkeyup", str2);
        string[] strArray = control6.SelectedValue.Split(';');
        control1.Attributes.Add("value", strArray[1].ToString());
        control4.Attributes.Add("onkeypress", "ControllaCaratteri();");
      }
      if (e.Item.ItemType == ListItemType.EditItem)
      {
        TextBox control1 = (TextBox) e.Item.FindControl("txtprezzoEdit");
        TextBox control2 = (TextBox) e.Item.FindControl("txtunitaEdit");
        TextBox control3 = (TextBox) e.Item.FindControl("txtquantitaEdit");
        TextBox control4 = (TextBox) e.Item.FindControl("txttotaleEdit");
        DropDownList control5 = (DropDownList) e.Item.FindControl("cmbMaterialiEdit");
        string str1 = "cmbSelezione('" + control5.ClientID + "','" + control1.ClientID + "','" + control3.ClientID + "','" + control4.ClientID + "');";
        control5.Attributes.Add("onchange", str1);
        string str2 = "calcolaPrezzoTotale('" + control1.ClientID + "','" + control3.ClientID + "','" + control4.ClientID + "');";
        control3.Attributes.Add("onkeyup", str2);
        control3.Attributes.Add("onkeypress", "ControllaCaratteri();");
      }
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      DataRowView dataItem = (DataRowView) e.Item.DataItem;
      if (!(((Label) e.Item.FindControl("lblDescrizione")).Text == "Materiale"))
        return;
      string str = "<b>&nbsp;&nbsp;&nbsp;Entrata:&nbsp;</b>" + dataItem["prezzo_unitario"].ToString() + "<b>&nbsp;&nbsp;&nbsp;Uscita:&nbsp;</b>" + dataItem["totale"].ToString() + "&nbsp;&nbsp;&nbsp;<b>Saldo:&nbsp;</b>" + dataItem["quantita"].ToString();
      e.Item.Cells.RemoveAt(6);
      e.Item.Cells.RemoveAt(5);
      e.Item.Cells.RemoveAt(4);
      e.Item.Cells.RemoveAt(3);
      e.Item.Cells.RemoveAt(2);
      e.Item.Cells.RemoveAt(1);
      e.Item.Cells[0].ColumnSpan = 7;
      e.Item.Cells[0].Text = str;
    }

    private void DataGridRicerca_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
      DropDownList control1 = (DropDownList) e.Item.FindControl("cmbMaterialiEdit");
      TextBox control2 = (TextBox) e.Item.FindControl("txtprezzoEdit");
      TextBox control3 = (TextBox) e.Item.FindControl("txtquantitaEdit");
      TextBox control4 = (TextBox) e.Item.FindControl("txttotaleEdit");
      DataRowView dataItem = (DataRowView) e.Item.DataItem;
      int int32 = Convert.ToInt32(((TextBox) e.Item.FindControl("IdMateriale")).Text);
      double prezzoUnitario = Convert.ToDouble(control2.Text);
      int quantita = !(control3.Text != "") ? 0 : Convert.ToInt32(control3.Text);
      double prezzoTotale = Convert.ToDouble(control4.Text);
      this.EseguiDataBaseMateriale(int.Parse(this.DataGridRicerca.DataKeys[e.Item.ItemIndex].ToString()), ExecuteType.Update, int32, prezzoUnitario, quantita, prezzoTotale);
      this.DataGridRicerca.EditItemIndex = -1;
      this.Ricerca();
    }

    private int EseguiDataBaseMateriale(
      int id,
      ExecuteType Operazione,
      int idMateriale,
      double prezzoUnitario,
      int quantita,
      double prezzoTotale)
    {
      TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali analisiCostiMateriali = new TheSite.Classi.ManCorrettiva.AnalisiCostiMateriali();
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
      ((ParameterObject) sObject3).set_ParameterName("p_IdMateriale");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      S_Object sObject4 = sObject3;
      int num4 = num3;
      int num5 = num4 + 1;
      ((ParameterObject) sObject4).set_Index(num4);
      ((ParameterObject) sObject3).set_Value((object) idMateriale);
      CollezioneControlli.Add(sObject3);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_PrezzoUnitario");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      S_Object sObject6 = sObject5;
      int num6 = num5;
      int num7 = num6 + 1;
      ((ParameterObject) sObject6).set_Index(num6);
      ((ParameterObject) sObject5).set_Value((object) prezzoUnitario);
      CollezioneControlli.Add(sObject5);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_Quantita");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      S_Object sObject8 = sObject7;
      int num8 = num7;
      int num9 = num8 + 1;
      ((ParameterObject) sObject8).set_Index(num8);
      ((ParameterObject) sObject7).set_Value((object) Math.Abs(quantita));
      CollezioneControlli.Add(sObject7);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_Totale");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 4);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      S_Object sObject10 = sObject9;
      int num10 = num9;
      int num11 = num10 + 1;
      ((ParameterObject) sObject10).set_Index(num10);
      ((ParameterObject) sObject9).set_Value((object) Math.Abs(prezzoTotale));
      CollezioneControlli.Add(sObject9);
      return !(Operazione.ToString().ToUpper() == "INSERT") ? (!(Operazione.ToString().ToUpper() == "UPDATE") ? analisiCostiMateriali.Delete(CollezioneControlli, id) : analisiCostiMateriali.Update(CollezioneControlli, id)) : analisiCostiMateriali.Add(CollezioneControlli);
    }

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      switch (((ImageButton) e.CommandSource).CommandName)
      {
        case "Insert":
          DropDownList control1 = (DropDownList) e.Item.FindControl("cmbMaterialiInsert");
          TextBox control2 = (TextBox) e.Item.FindControl("txtprezzoInsert");
          TextBox control3 = (TextBox) e.Item.FindControl("txtquantitaInset");
          TextBox control4 = (TextBox) e.Item.FindControl("txttotaleInsert");
          this.EseguiDataBaseMateriale(0, ExecuteType.Insert, Convert.ToInt32(((TextBox) e.Item.FindControl("IdMateriale")).Text), Convert.ToDouble(control2.Text), !(control3.Text != "") ? 0 : Convert.ToInt32(control3.Text), Convert.ToDouble(control4.Text));
          this.DataGridRicerca.EditItemIndex = -1;
          this.Ricerca();
          break;
        case "Delete":
          this.EseguiDataBaseMateriale(int.Parse(this.DataGridRicerca.DataKeys[e.Item.ItemIndex].ToString()), ExecuteType.Delete, 0, 0.0, 0, 0.0);
          this.DataGridRicerca.EditItemIndex = -1;
          this.Ricerca();
          break;
      }
    }

    private void lkbNuovo_Click(object sender, EventArgs e)
    {
      this.DataGridRicerca.EditItemIndex = -1;
      this.Ricerca();
      this.DataGridRicerca.Visible = true;
      this.DataGridRicerca.ShowFooter = true;
    }

    private void BtnReset_Click(object sender, EventArgs e) => this.Response.Redirect("AnalisiCostiMateriali.aspx");

    private void DataGridRicerca_ItemCreated(object sender, DataGridItemEventArgs e) => ((WebControl) e.Item.FindControl("imbDelete"))?.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");

    private void s_cmdanagmat_Click(object sender, EventArgs e)
    {
    }
  }
}
