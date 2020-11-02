// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.PmpS
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using MyCollection;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.WebControls;

namespace TheSite.Gestione
{
  public class PmpS : Page
  {
    protected Label lblOperazione;
    protected Label lblFirstAndLast;
    protected DataGrid DataGridEsegui;
    protected Label lblRecord;
    protected LinkButton lkbNuovo;
    private Pmp _fp;
    private int FunId = 0;
    protected MessagePanel PanelMess;
    protected S_Button btnsSalvaTutto;
    protected Label lblMessaggi;
    protected PageTitle PageTitle1;
    protected Button btnAnnulla;
    protected Button btnsAnnulla;
    protected Label Label1;
    protected DataGrid DataGridDettaglio;
    private int itemId = 0;

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      this.lblMessaggi.Text = "";
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      this.DataGridDettaglio.DataSource = (object) new TheSite.Classi.ClassiAnagrafiche.Pmp().GetSingleData(this.itemId).Copy().Tables[0];
      this.DataGridDettaglio.DataBind();
      DataSet dataSet = new TheSite.Classi.PmpS().GetSingleData(this.itemId).Copy();
      this.DataGridEsegui.DataSource = (object) new DataView(dataSet.Tables[0])
      {
        Sort = "PASSO ASC"
      };
      this.DataGridEsegui.DataBind();
      this.Session.Add(nameof (PmpS), (object) dataSet.Tables[0]);
      this.lblRecord.Text = dataSet.Tables[0].Rows.Count.ToString();
      this.DataGridEsegui.Columns[1].Visible = true;
      this.DataGridEsegui.Columns[2].Visible = false;
      this.DataGridEsegui.Columns[3].Visible = false;
      this.lblOperazione.Text = "";
      this.PageTitle1.Title = "Passi per Procedura di Manutenzione Programmata ";
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is Pmp))
        return;
      this._fp = (Pmp) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.lkbNuovo.Click += new EventHandler(this.lkbNuovo_Click);
      this.DataGridEsegui.ItemCreated += new DataGridItemEventHandler(this.DataGridEsegui_ItemCreated);
      this.DataGridEsegui.ItemCommand += new DataGridCommandEventHandler(this.DataGridEsegui_ItemCommand);
      this.DataGridEsegui.CancelCommand += new DataGridCommandEventHandler(this.DataGridEsegui_CancelCommand);
      this.DataGridEsegui.EditCommand += new DataGridCommandEventHandler(this.DataGridEsegui_EditCommand);
      this.DataGridEsegui.UpdateCommand += new DataGridCommandEventHandler(this.DataGridEsegui_UpdateCommand);
      this.DataGridEsegui.DeleteCommand += new DataGridCommandEventHandler(this.DataGridEsegui_DeleteCommand);
      this.DataGridEsegui.ItemDataBound += new DataGridItemEventHandler(this.DataGridEsegui_ItemDataBound);
      this.DataGridEsegui.SelectedIndexChanged += new EventHandler(this.DataGridEsegui_SelectedIndexChanged);
      ((Button) this.btnsSalvaTutto).Click += new EventHandler(this.btnsSalvaTutto_Click);
      this.btnsAnnulla.Click += new EventHandler(this.btnsAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Response.Redirect((string) this.ViewState["UrlReferrer"]);

    private void DataGridEsegui_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
      S_TextBox control1 = (S_TextBox) e.Item.FindControl("txts_IstruzioniEdit");
      S_TextBox control2 = (S_TextBox) e.Item.FindControl("txts_TempoEdit");
      if (((TextBox) control1).Text.Trim() != "" && ((TextBox) control2).Text.Trim() != "")
      {
        int num = int.Parse(this.DataGridEsegui.DataKeys[e.Item.ItemIndex].ToString());
        DataTable dataTable = (DataTable) this.Session[nameof (PmpS)];
        string filterExpression = "PASSO=" + num.ToString();
        DataRow[] dataRowArray = dataTable.Select(filterExpression);
        dataRowArray[0]["ISTRUZIONE"] = (object) ((TextBox) control1).Text.Trim();
        dataRowArray[0]["TEMPO"] = (object) ((TextBox) control2).Text.Trim();
        this.Session.Remove(nameof (PmpS));
        this.Session.Add(nameof (PmpS), (object) dataTable);
        dataTable.AcceptChanges();
        this.DataGridEsegui.EditItemIndex = -1;
        this.BindGrid();
        this.DataGridEsegui.Columns[1].Visible = true;
        this.DataGridEsegui.Columns[2].Visible = false;
        this.DataGridEsegui.Columns[3].Visible = false;
        this.DataGridEsegui.Columns[4].Visible = true;
        ((WebControl) this.btnsSalvaTutto).Enabled = true;
      }
      else
        this.lblMessaggi.Text = "E' necessario valorizzare entrambi i campi!";
    }

    private void DataGridEsegui_EditCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.EditItemIndex = e.Item.ItemIndex;
      this.BindGrid();
      S_TextBox control = (S_TextBox) this.DataGridEsegui.Items[(int) short.Parse(e.Item.ItemIndex.ToString())].Cells[7].FindControl("txts_TempoEdit");
      if (control != null)
      {
        ((WebControl) control).Attributes.Add("onkeypress", "SoloNumeri();");
        ((WebControl) control).Attributes.Add("onpaste", "return false;");
      }
      this.DataGridEsegui.Columns[1].Visible = false;
      this.DataGridEsegui.Columns[2].Visible = true;
      this.DataGridEsegui.Columns[3].Visible = false;
      this.DataGridEsegui.Columns[4].Visible = false;
      ((WebControl) this.btnsSalvaTutto).Enabled = false;
    }

    private void DataGridEsegui_CancelCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.EditItemIndex = -1;
      this.BindGrid();
      this.DataGridEsegui.Columns[1].Visible = true;
      this.DataGridEsegui.Columns[2].Visible = false;
      this.DataGridEsegui.Columns[3].Visible = false;
      this.DataGridEsegui.Columns[4].Visible = true;
      ((WebControl) this.btnsSalvaTutto).Enabled = true;
    }

    private void DataGridEsegui_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      switch (((ImageButton) e.CommandSource).CommandName)
      {
        case "Insert":
          S_TextBox control1 = (S_TextBox) e.Item.FindControl("txts_IstruzioniNew");
          S_TextBox control2 = (S_TextBox) e.Item.FindControl("txts_TempoNew");
          if (((TextBox) control1).Text.Trim() != "" && ((TextBox) control2).Text.Trim() != "")
          {
            DataTable dataTable = (DataTable) this.Session[nameof (PmpS)];
            DataRow row = dataTable.NewRow();
            row["PASSO"] = (object) (this.DataGridEsegui.Items.Count + 1);
            row["ISTRUZIONE"] = (object) ((TextBox) control1).Text.Trim();
            row["TEMPO"] = (object) ((TextBox) control2).Text.Trim();
            dataTable.Rows.Add(row);
            dataTable.AcceptChanges();
            this.Session.Remove(nameof (PmpS));
            this.Session.Add(nameof (PmpS), (object) dataTable);
            this.DataGridEsegui.EditItemIndex = -1;
            this.BindGrid();
            this.DataGridEsegui.Columns[1].Visible = true;
            this.DataGridEsegui.Columns[2].Visible = false;
            this.DataGridEsegui.Columns[3].Visible = false;
            this.DataGridEsegui.Columns[4].Visible = true;
            ((WebControl) this.btnsSalvaTutto).Enabled = true;
            break;
          }
          this.lblMessaggi.Text = "E' necessario valorizzare entrambi i campi!";
          break;
        case "Su":
          int num1 = int.Parse(this.DataGridEsegui.DataKeys[e.Item.ItemIndex].ToString());
          if (num1 == 1)
            break;
          DataTable dataTable1 = (DataTable) this.Session[nameof (PmpS)];
          string filterExpression1 = "PASSO=" + num1.ToString();
          string filterExpression2 = "PASSO=" + (num1 - 1).ToString();
          DataRow[] dataRowArray1 = dataTable1.Select(filterExpression1);
          DataRow[] dataRowArray2 = dataTable1.Select(filterExpression2);
          dataRowArray1[0]["PASSO"] = (object) (num1 - 1);
          dataRowArray2[0]["PASSO"] = (object) num1;
          dataTable1.AcceptChanges();
          this.Session.Remove(nameof (PmpS));
          this.Session.Add(nameof (PmpS), (object) dataTable1);
          this.DataGridEsegui.EditItemIndex = -1;
          this.BindGrid();
          break;
        case "Giu":
          int num2 = int.Parse(this.DataGridEsegui.DataKeys[e.Item.ItemIndex].ToString());
          if (num2 == this.DataGridEsegui.Items.Count)
            break;
          DataTable dataTable2 = (DataTable) this.Session[nameof (PmpS)];
          string filterExpression3 = "PASSO=" + num2.ToString();
          string filterExpression4 = "PASSO=" + (num2 + 1).ToString();
          DataRow[] dataRowArray3 = dataTable2.Select(filterExpression3);
          DataRow[] dataRowArray4 = dataTable2.Select(filterExpression4);
          dataRowArray3[0]["PASSO"] = (object) (num2 + 1);
          dataRowArray4[0]["PASSO"] = (object) num2;
          dataTable2.AcceptChanges();
          this.Session.Remove(nameof (PmpS));
          this.Session.Add(nameof (PmpS), (object) dataTable2);
          this.DataGridEsegui.EditItemIndex = -1;
          this.BindGrid();
          break;
      }
    }

    private void lkbNuovo_Click(object sender, EventArgs e)
    {
      this.BindGrid();
      this.DataGridEsegui.ShowFooter = true;
      this.DataGridEsegui.Columns[1].Visible = false;
      this.DataGridEsegui.Columns[2].Visible = false;
      this.DataGridEsegui.Columns[3].Visible = true;
      this.DataGridEsegui.Columns[4].Visible = false;
      ((WebControl) this.btnsSalvaTutto).Enabled = false;
    }

    private void BindGrid()
    {
      TheSite.Classi.PmpS pmpS = new TheSite.Classi.PmpS();
      DataTable table = (DataTable) this.Session[nameof (PmpS)];
      this.DataGridEsegui.DataSource = (object) new DataView(table)
      {
        Sort = "PASSO ASC"
      };
      this.DataGridEsegui.DataBind();
      this.lblRecord.Text = table.Rows.Count.ToString();
      this.DataGridEsegui.ShowFooter = false;
    }

    private int cancellaTutto(TheSite.Classi.PmpS _PmpS)
    {
      int num1 = 0;
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Istruzioni");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(4000);
      ((ParameterObject) sObject1).set_Index(num1);
      ((ParameterObject) sObject1).set_Value((object) "");
      int num2 = num1 + 1;
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Tempo");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(10);
      ((ParameterObject) sObject2).set_Index(num2);
      ((ParameterObject) sObject2).set_Value((object) 0);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_seq_id");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(10);
      ((ParameterObject) sObject3).set_Index(num2);
      ((ParameterObject) sObject3).set_Value((object) 0);
      CollezioneControlli.Add(sObject1);
      CollezioneControlli.Add(sObject2);
      CollezioneControlli.Add(sObject3);
      return _PmpS.Delete(CollezioneControlli, this.itemId);
    }

    protected int GetIndex(string item) => item.Length > 0 ? int.Parse(item) : 0;

    private int ExecuteAllUpdate()
    {
      int num1 = 0;
      TheSite.Classi.PmpS _PmpS = new TheSite.Classi.PmpS();
      DataTable dataTable = (DataTable) this.Session[nameof (PmpS)];
      _PmpS.beginTransaction();
      try
      {
        this.cancellaTutto(_PmpS);
        for (int index = 0; index < dataTable.Rows.Count; ++index)
        {
          int num2 = 0;
          DataRow row = dataTable.Rows[index];
          S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
          S_Object sObject1 = new S_Object();
          ((ParameterObject) sObject1).set_ParameterName("p_Istruzioni");
          ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
          ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject1).set_Size(4000);
          ((ParameterObject) sObject1).set_Index(num2);
          ((ParameterObject) sObject1).set_Value(row["ISTRUZIONE"]);
          int num3 = num2 + 1;
          S_Object sObject2 = new S_Object();
          ((ParameterObject) sObject2).set_ParameterName("p_Tempo");
          ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject2).set_Size(10);
          ((ParameterObject) sObject2).set_Index(num3);
          ((ParameterObject) sObject2).set_Value(row["TEMPO"]);
          S_Object sObject3 = new S_Object();
          ((ParameterObject) sObject3).set_ParameterName("p_seq_id");
          ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
          ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
          ((ParameterObject) sObject3).set_Size(10);
          ((ParameterObject) sObject3).set_Index(num3);
          ((ParameterObject) sObject3).set_Value(row["PASSO"]);
          CollezioneControlli.Add(sObject1);
          CollezioneControlli.Add(sObject2);
          CollezioneControlli.Add(sObject3);
          num1 = _PmpS.Update(CollezioneControlli, this.itemId);
        }
        _PmpS.commitTransaction();
      }
      catch
      {
        _PmpS.rollbackTransaction();
        return 0;
      }
      return num1;
    }

    private void DataGridEsegui_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
      int num = int.Parse(this.DataGridEsegui.DataKeys[e.Item.ItemIndex].ToString());
      DataTable dataTable = (DataTable) this.Session[nameof (PmpS)];
      string filterExpression = "PASSO=" + num.ToString();
      dataTable.Select(filterExpression)[0].Delete();
      dataTable.AcceptChanges();
      this.Session.Remove(nameof (PmpS));
      this.Session.Add(nameof (PmpS), (object) dataTable);
      this.DataGridEsegui.EditItemIndex = -1;
      this.BindGrid();
      this.DataGridEsegui.Columns[1].Visible = true;
      this.DataGridEsegui.Columns[2].Visible = false;
      this.DataGridEsegui.Columns[3].Visible = false;
      this.DataGridEsegui.Columns[4].Visible = true;
      ((WebControl) this.btnsSalvaTutto).Enabled = true;
    }

    private void btnsSalvaTutto_Click(object sender, EventArgs e)
    {
      this.ExecuteAllUpdate();
      this.Server.Transfer("Pmp.aspx");
    }

    private void DataGridEsegui_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
    }

    private void DataGridEsegui_ItemCreated(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Footer)
        return;
      S_TextBox control = (S_TextBox) e.Item.Cells[7].FindControl("txts_TempoNew");
      if (control == null)
        return;
      ((WebControl) control).Attributes.Add("onkeypress", "SoloNumeri();");
      ((WebControl) control).Attributes.Add("onpaste", "return false;");
    }

    private void btnsAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("Pmp.aspx");

    private void DataGridEsegui_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
  }
}
