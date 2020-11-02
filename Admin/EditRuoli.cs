// Decompiled with JetBrains decompiler
// Type: TheSite.Admin.EditRuoli
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
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;

namespace TheSite.Admin
{
  public class EditRuoli : Page
  {
    protected Label lblOperazione;
    protected Panel PanelEdit;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Button btnAnnulla;
    protected S_TextBox txtsDescrizione;
    protected S_TextBox txtsNote;
    protected Label lblFirstAndLast;
    protected DataGrid DataGridEsegui;
    protected Label lblMessage;
    protected Label lblRecord;
    protected LinkButton lkbNuovo;
    private int FunId = 0;
    protected RequiredFieldValidator rfvDescrizione;
    protected ValidationSummary vlsEdit;
    protected S_ComboBox cmbsDitta;
    protected MessagePanel PanelMess;
    protected S_ComboBox cmbCopiaruolo;
    protected S_Button btnCopiaRuolo;
    private int itemId = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request.Params["FunId"]);
      if (this.Request.Params["ItemId"] != null)
        this.itemId = int.Parse(this.Request.Params["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      if (this.itemId != 0)
      {
        Ruolo ruolo = new Ruolo();
        DataSet dataSet1 = ruolo.GetSingleData(this.itemId).Copy();
        if (dataSet1.Tables[0].Rows.Count == 1)
        {
          DataRow row = dataSet1.Tables[0].Rows[0];
          ((TextBox) this.txtsDescrizione).Text = (string) row["DESCRIZIONE"];
          if (row["NOTE"] != DBNull.Value)
            ((TextBox) this.txtsNote).Text = (string) row["NOTE"];
          this.BindControls();
          if (row["DITTA_ID"] != DBNull.Value)
            ((ListControl) this.cmbsDitta).SelectedValue = row["DITTA_ID"].ToString();
          this.lblFirstAndLast.Text = ruolo.GetFirstAndLastUser(row);
          DataSet dataSet2 = ruolo.GetFunzioni(this.itemId).Copy();
          this.DataGridEsegui.DataSource = (object) dataSet2.Tables[0];
          this.DataGridEsegui.DataBind();
          this.lblRecord.Text = dataSet2.Tables[0].Rows.Count.ToString();
          this.DataGridEsegui.Columns[1].Visible = true;
          this.DataGridEsegui.Columns[2].Visible = false;
          this.DataGridEsegui.Columns[3].Visible = false;
          this.lblOperazione.Text = "Modifica";
          this.lblFirstAndLast.Visible = true;
          ((Control) this.btnsElimina).Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
          this.BindRuoli();
          ((Control) this.cmbCopiaruolo).Visible = true;
          ((Control) this.btnCopiaRuolo).Visible = true;
        }
      }
      else
      {
        this.lblOperazione.Text = "Nuovo";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
        this.BindControls();
        ((Control) this.cmbCopiaruolo).Visible = false;
        ((Control) this.btnCopiaRuolo).Visible = false;
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      ((Button) this.btnsElimina).Click += new EventHandler(this.btnsElimina_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.lkbNuovo.Click += new EventHandler(this.lkbNuovo_Click);
      this.DataGridEsegui.ItemCommand += new DataGridCommandEventHandler(this.DataGridEsegui_ItemCommand);
      this.DataGridEsegui.CancelCommand += new DataGridCommandEventHandler(this.DataGridEsegui_CancelCommand);
      this.DataGridEsegui.EditCommand += new DataGridCommandEventHandler(this.DataGridEsegui_EditCommand);
      this.DataGridEsegui.UpdateCommand += new DataGridCommandEventHandler(this.DataGridEsegui_UpdateCommand);
      ((Button) this.btnCopiaRuolo).Click += new EventHandler(this.btnCopiaRuolo_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Response.Redirect((string) this.ViewState["UrlReferrer"]);

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      this.txtsNote.set_DBDefaultValue((object) DBNull.Value);
      Ruolo ruolo = new Ruolo();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        if ((this.itemId != 0 ? ruolo.Update(CollezioneControlli, this.itemId) : ruolo.Add(CollezioneControlli)) <= 0)
          return;
        this.Response.Redirect((string) this.ViewState["UrlReferrer"]);
      }
      catch (Exception ex)
      {
        string str = "Errore: ";
        this.PanelMess.ShowError(!(ex.Message.Substring(0, 8) == "ORA-00001") ? str + "aggiornamento non riuscito" : str + "denominazione ruolo già presente", true);
      }
    }

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      this.txtsDescrizione.set_DBDefaultValue((object) DBNull.Value);
      this.txtsNote.set_DBDefaultValue((object) DBNull.Value);
      Ruolo ruolo = new Ruolo();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        if (ruolo.Delete(CollezioneControlli, this.itemId) != -1)
          return;
        this.Response.Redirect((string) this.ViewState["UrlReferrer"]);
      }
      catch
      {
        this.PanelMess.ShowError("Errore: cancellazione non riuscita", true);
      }
    }

    private void DataGridEsegui_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
      S_ComboBox control1 = (S_ComboBox) e.Item.FindControl("ddlFunzione");
      S_CheckBox control2 = (S_CheckBox) e.Item.FindControl("ckbLetturaEdit");
      S_CheckBox control3 = (S_CheckBox) e.Item.FindControl("ckbInserimentoEdit");
      S_CheckBox control4 = (S_CheckBox) e.Item.FindControl("ckbModificaEdit");
      S_CheckBox control5 = (S_CheckBox) e.Item.FindControl("ckbCancellazioneEdit");
      int id = int.Parse(this.DataGridEsegui.DataKeys[e.Item.ItemIndex].ToString());
      try
      {
        if (this.ExecuteRuoliFunzioni(id, ExecuteType.Update, control1, control2, control3, control4, control5) > 0)
        {
          this.lblMessage.Text = "Associazione Ruolo - Modifica Eseguita correttamente";
          this.lblMessage.CssClass = "";
          this.DataGridEsegui.EditItemIndex = -1;
          this.BindGrid();
          this.DataGridEsegui.Columns[1].Visible = true;
          this.DataGridEsegui.Columns[2].Visible = false;
          this.DataGridEsegui.Columns[3].Visible = false;
        }
        else
        {
          this.lblMessage.Text = "Associazione Ruolo - Modifica non eseguita";
          this.lblMessage.CssClass = "LabelErrore";
          this.DataGridEsegui.Columns[1].Visible = false;
          this.DataGridEsegui.Columns[2].Visible = true;
          this.DataGridEsegui.Columns[3].Visible = false;
        }
      }
      catch
      {
        this.PanelMess.ShowError("Errore: Associazione Ruolo non riuscita", true);
      }
    }

    private void DataGridEsegui_EditCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.EditItemIndex = e.Item.ItemIndex;
      this.BindGrid();
      this.DataGridEsegui.Columns[1].Visible = false;
      this.DataGridEsegui.Columns[2].Visible = true;
      this.DataGridEsegui.Columns[3].Visible = false;
    }

    private void DataGridEsegui_CancelCommand(object source, DataGridCommandEventArgs e)
    {
      this.DataGridEsegui.EditItemIndex = -1;
      this.BindGrid();
      this.DataGridEsegui.Columns[1].Visible = true;
      this.DataGridEsegui.Columns[2].Visible = false;
      this.DataGridEsegui.Columns[3].Visible = false;
    }

    private void DataGridEsegui_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      switch (((ImageButton) e.CommandSource).CommandName)
      {
        case "Insert":
          int num = this.ExecuteRuoliFunzioni(0, ExecuteType.Insert, (S_ComboBox) e.Item.FindControl("ddlFunzioneNew"), (S_CheckBox) e.Item.FindControl("ckbLetturaNew"), (S_CheckBox) e.Item.FindControl("ckbInserimentoNew"), (S_CheckBox) e.Item.FindControl("ckbModificaNew"), (S_CheckBox) e.Item.FindControl("ckbCancellazioneNew"));
          try
          {
            if (num > 0)
            {
              this.lblMessage.Text = "Associazione Ruolo - Inserimento eseguito correttamente";
              this.lblMessage.CssClass = "";
              this.DataGridEsegui.EditItemIndex = -1;
              this.BindGrid();
              this.DataGridEsegui.Columns[1].Visible = true;
              this.DataGridEsegui.Columns[2].Visible = false;
              this.DataGridEsegui.Columns[3].Visible = false;
              break;
            }
            this.lblMessage.Text = "Associazione Ruolo - Inserimento non eseguito";
            this.lblMessage.CssClass = "LabelErrore";
            this.DataGridEsegui.Columns[1].Visible = false;
            this.DataGridEsegui.Columns[2].Visible = false;
            this.DataGridEsegui.Columns[3].Visible = true;
            break;
          }
          catch
          {
            this.PanelMess.ShowError("Errore: Inserimento Associazione Ruolo non riuscita", true);
            break;
          }
        case "Delete":
          S_ComboBox control1 = (S_ComboBox) e.Item.FindControl("ddlFunzioneNew");
          S_CheckBox control2 = (S_CheckBox) e.Item.FindControl("ckbLetturaNew");
          S_CheckBox control3 = (S_CheckBox) e.Item.FindControl("ckbInserimentoNew");
          S_CheckBox control4 = (S_CheckBox) e.Item.FindControl("ckbModificaNew");
          S_CheckBox control5 = (S_CheckBox) e.Item.FindControl("ckbCancellazioneNew");
          int id = int.Parse(this.DataGridEsegui.DataKeys[e.Item.ItemIndex].ToString());
          try
          {
            if (this.ExecuteRuoliFunzioni(id, ExecuteType.Delete, control1, control2, control3, control4, control5) == -1)
            {
              this.lblMessage.Text = "Associazione Ruolo - Cancellazione eseguita correttamente";
              this.lblMessage.CssClass = "";
              this.DataGridEsegui.EditItemIndex = -1;
              this.BindGrid();
            }
            else
            {
              this.lblMessage.Text = "Associazione Ruolo - Cancellazione non eseguita";
              this.lblMessage.CssClass = "LabelErrore";
            }
          }
          catch
          {
            this.PanelMess.ShowError("Errore: Cancellazione Associazione Ruolo non riuscita", true);
          }
          this.DataGridEsegui.Columns[1].Visible = true;
          this.DataGridEsegui.Columns[2].Visible = false;
          this.DataGridEsegui.Columns[3].Visible = false;
          break;
      }
    }

    private void lkbNuovo_Click(object sender, EventArgs e)
    {
      this.DataGridEsegui.ShowFooter = true;
      this.DataGridEsegui.Columns[1].Visible = false;
      this.DataGridEsegui.Columns[2].Visible = false;
      this.DataGridEsegui.Columns[3].Visible = true;
    }

    private void BindGrid()
    {
      DataSet dataSet = new Ruolo().GetFunzioni(this.itemId).Copy();
      this.DataGridEsegui.DataSource = (object) dataSet.Tables[0];
      this.DataGridEsegui.DataBind();
      this.lblRecord.Text = dataSet.Tables[0].Rows.Count.ToString();
      this.DataGridEsegui.ShowFooter = false;
    }

    protected DataTable GetFunzioni() => new Funzione().GetData().Copy().Tables[0];

    protected int GetIndex(string item) => item.Length > 0 ? int.Parse(item) : 0;

    private int ExecuteRuoliFunzioni(
      int id,
      ExecuteType Operazione,
      S_ComboBox cmbFunzioni,
      S_CheckBox ckbLettura,
      S_CheckBox ckbInserimento,
      S_CheckBox ckbModifica,
      S_CheckBox ckbCancellazione)
    {
      Ruolo ruolo = new Ruolo();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Funzione_Ruoli_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) id);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Funzione_Id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      if (cmbFunzioni != null)
        ((ParameterObject) sObject2).set_Value((object) ((ListControl) cmbFunzioni).SelectedValue);
      else
        ((ParameterObject) sObject2).set_Value((object) DBNull.Value);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_Ruolo_Id");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) this.itemId);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_Lettura");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Index(3);
      if (ckbLettura != null)
        ((ParameterObject) sObject4).set_Value((object) (Convert.ToInt32(((CheckBox) ckbLettura).Checked) * -1));
      else
        ((ParameterObject) sObject4).set_Value((object) DBNull.Value);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_Inserimento");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Index(4);
      if (ckbLettura != null)
        ((ParameterObject) sObject5).set_Value((object) (Convert.ToInt32(((CheckBox) ckbInserimento).Checked) * -1));
      else
        ((ParameterObject) sObject5).set_Value((object) DBNull.Value);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_Modifica");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Index(5);
      if (ckbLettura != null)
        ((ParameterObject) sObject6).set_Value((object) (Convert.ToInt32(((CheckBox) ckbModifica).Checked) * -1));
      else
        ((ParameterObject) sObject6).set_Value((object) DBNull.Value);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_Cancellazione");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Index(6);
      if (ckbLettura != null)
        ((ParameterObject) sObject7).set_Value((object) (Convert.ToInt32(((CheckBox) ckbCancellazione).Checked) * -1));
      else
        ((ParameterObject) sObject7).set_Value((object) DBNull.Value);
      CollezioneControlli.Add(sObject1);
      CollezioneControlli.Add(sObject2);
      CollezioneControlli.Add(sObject3);
      CollezioneControlli.Add(sObject4);
      CollezioneControlli.Add(sObject5);
      CollezioneControlli.Add(sObject6);
      CollezioneControlli.Add(sObject7);
      try
      {
        return ruolo.UpdateFunzioni(CollezioneControlli, Operazione);
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
        return 0;
      }
    }

    private void BindControls()
    {
      ((BaseDataBoundControl) this.cmbsDitta).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(new Ditte().GetData().Tables[0], "DESCRIZIONE", "ID", "", "0");
      ((ListControl) this.cmbsDitta).DataTextField = "DESCRIZIONE";
      ((ListControl) this.cmbsDitta).DataValueField = "ID";
      ((Control) this.cmbsDitta).DataBind();
    }

    private void BindRuoli()
    {
      ((BaseDataBoundControl) this.cmbCopiaruolo).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(new Ruolo().GetRuoliTranneMe(this.itemId).Tables[0], "DESCRIZIONE", "ID", "--Copia da Ruolo--", "0");
      ((ListControl) this.cmbCopiaruolo).DataTextField = "DESCRIZIONE";
      ((ListControl) this.cmbCopiaruolo).DataValueField = "ID";
      ((Control) this.cmbCopiaruolo).DataBind();
    }

    private void btnCopiaRuolo_Click(object sender, EventArgs e)
    {
      Ruolo ruolo = new Ruolo();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_ruolo_Id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(8);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject1).set_Value((object) this.itemId);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_ruolo_da_copiare");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(8);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count);
      ((ParameterObject) sObject2).set_Value((object) Convert.ToInt32(((ListControl) this.cmbCopiaruolo).SelectedValue));
      CollezioneControlli.Add(sObject2);
      ruolo.CopiaFunzioni(CollezioneControlli);
      this.BindGrid();
    }
  }
}
