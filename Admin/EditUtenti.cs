// Decompiled with JetBrains decompiler
// Type: TheSite.Admin.EditUtenti
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using Csy.WebControls;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;

namespace TheSite.Admin
{
  public class EditUtenti : Page
  {
    protected S_TextBox txtsUserName;
    protected S_TextBox txtsCognome;
    protected S_TextBox txtsNome;
    protected S_TextBox txtsEmail;
    protected S_TextBox txtsTelefono;
    protected Panel PanelEdit;
    protected Label lblOperazione;
    protected Button btnAnnulla;
    protected S_Button btnsSalva;
    protected S_Button btnsElimina;
    protected Label lblFirstAndLast;
    protected S_TextBox txtsPassword;
    protected RequiredFieldValidator rfvUserName;
    protected TextBox txtConfermaPassword;
    protected CompareValidator cpvPassword;
    protected ValidationSummary vlsEdit;
    protected ListBox ListBoxLeft;
    protected ListBox ListBoxRight;
    protected Button btnAssocia;
    protected Button btnElimina;
    private int itemId = 0;
    private int FunId = 0;
    protected MessagePanel PanelMess;
    protected RegularExpressionValidator rgeEmail;
    protected S_ComboBox CmbProgetto;
    private DataSet _DsListBox;

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request.Params["FunId"]);
      if (this.Request.Params["ItemId"] != null)
        this.itemId = int.Parse(this.Request.Params["ItemId"]);
      if (this.Page.IsPostBack)
        return;
      if (this.itemId != 0)
      {
        Utente utente = new Utente();
        DataSet dataSet = utente.GetSingleData(this.itemId).Copy();
        if (dataSet.Tables[0].Rows.Count == 1)
        {
          DataRow row = dataSet.Tables[0].Rows[0];
          ((TextBox) this.txtsUserName).Text = (string) row["USERNAME"];
          if (row["COGNOME"] != DBNull.Value)
            ((TextBox) this.txtsCognome).Text = (string) row["COGNOME"];
          if (row["NOME"] != DBNull.Value)
            ((TextBox) this.txtsNome).Text = (string) row["NOME"];
          if (row["EMAIL"] != DBNull.Value)
            ((TextBox) this.txtsEmail).Text = (string) row["EMAIL"];
          if (row["TELEFONO"] != DBNull.Value)
            ((TextBox) this.txtsTelefono).Text = (string) row["TELEFONO"];
          this.lblFirstAndLast.Text = utente.GetFirstAndLastUser(row);
          if (row["id_progetto"] != DBNull.Value)
            this.BindProgetti(int.Parse(row["id_progetto"].ToString()));
          else
            this.BindProgetti(0);
          this.AggiornaListBox();
          this.lblOperazione.Text = "Modifica";
          this.lblFirstAndLast.Visible = true;
          this.ListBoxLeft.Enabled = true;
          this.ListBoxRight.Enabled = true;
          this.btnAssocia.Enabled = true;
          this.btnElimina.Enabled = true;
          ((Control) this.btnsElimina).Visible = true;
          ((WebControl) this.btnsElimina).Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
        }
      }
      else
      {
        this.lblOperazione.Text = "Nuovo";
        this.lblFirstAndLast.Visible = false;
        ((Control) this.btnsElimina).Visible = false;
        ((TextBox) this.txtsPassword).Text = "PASSWORD";
        this.txtConfermaPassword.Text = ((TextBox) this.txtsPassword).Text;
        this.BindProgetti(0);
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
    }

    private void BindProgetti(int progetto)
    {
      ((ListControl) this.CmbProgetto).Items.Clear();
      DataSet data = new Progetti().GetData();
      if (data.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.CmbProgetto).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(data.Tables[0], "descrizione", "id_progetto", "- Selezionare un Progetto -", "0");
        ((ListControl) this.CmbProgetto).DataTextField = "descrizione";
        ((ListControl) this.CmbProgetto).DataValueField = "id_progetto";
        ((Control) this.CmbProgetto).DataBind();
        ((ListControl) this.CmbProgetto).SelectedValue = progetto.ToString();
      }
      else
        ((ListControl) this.CmbProgetto).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessun Progetto  -", "-1"));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.btnAssocia.Click += new EventHandler(this.btnAssocia_Click);
      this.btnElimina.Click += new EventHandler(this.btnElimina_Click);
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      ((Button) this.btnsElimina).Click += new EventHandler(this.btnsElimina_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Response.Redirect((string) this.ViewState["UrlReferrer"]);

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      Sicurezza sicurezza = new Sicurezza();
      this.txtsCognome.set_DBDefaultValue((object) DBNull.Value);
      this.txtsNome.set_DBDefaultValue((object) DBNull.Value);
      this.txtsEmail.set_DBDefaultValue((object) DBNull.Value);
      this.txtsTelefono.set_DBDefaultValue((object) DBNull.Value);
      this.txtsPassword.set_DBDefaultValue((object) " ");
      if (this.itemId == 0)
        ((TextBox) this.txtsPassword).Text = sicurezza.EncryptMD5(((TextBox) this.txtsPassword).Text);
      else if (((TextBox) this.txtsPassword).Text != "")
        ((TextBox) this.txtsPassword).Text = sicurezza.EncryptMD5(((TextBox) this.txtsPassword).Text);
      Utente utente = new Utente();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        int num = this.itemId != 0 ? utente.Update(CollezioneControlli, this.itemId) : utente.Add(CollezioneControlli);
        if (num <= 0)
          return;
        if (this.ListBoxRight.Items.Count > 0)
        {
          DataTable dataTable = (DataTable) this.Session["UtentiRuoli"];
          DataView dataView = new DataView(dataTable);
          foreach (ListItem listItem in this.ListBoxRight.Items)
          {
            dataView.RowFilter = "Id = " + listItem.Value.ToString();
            if (dataView.Count == 0)
            {
              DataRow row = dataTable.NewRow();
              row["Id"] = (object) listItem.Value.ToString();
              row["Ruolo"] = (object) listItem.Text.ToString();
              row["IdUtente"] = (object) num;
              row["Operazione"] = (object) "I";
              dataTable.Rows.Add(row);
            }
            else if (dataView.Count == 1)
              dataView[0]["Operazione"] = (object) DBNull.Value;
          }
          this.UpdateRuoli(dataTable);
          this.Session.Remove("UtentiRuoli");
        }
        this.Response.Redirect((string) this.ViewState["UrlReferrer"]);
      }
      catch (Exception ex)
      {
        string str = "Errore: ";
        this.PanelMess.ShowError(!(ex.Message.Substring(0, 8) == "ORA-00001") ? str + " aggiornamento non riuscito" : str + " nome utente già presente", true);
      }
    }

    private void btnsElimina_Click(object sender, EventArgs e)
    {
      this.txtsCognome.set_DBDefaultValue((object) DBNull.Value);
      this.txtsNome.set_DBDefaultValue((object) DBNull.Value);
      this.txtsEmail.set_DBDefaultValue((object) DBNull.Value);
      this.txtsTelefono.set_DBDefaultValue((object) DBNull.Value);
      this.txtsPassword.set_DBDefaultValue((object) " ");
      Utente utente = new Utente();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      try
      {
        if (utente.Delete(CollezioneControlli, this.itemId) != -1)
          return;
        this.Response.Redirect((string) this.ViewState["UrlReferrer"]);
      }
      catch
      {
        this.PanelMess.ShowError("Errore: cancellazione non riuscita", true);
      }
    }

    private void btnAssocia_Click(object sender, EventArgs e)
    {
      if (this.ListBoxLeft.SelectedItem == null)
        return;
      string text = this.ListBoxLeft.SelectedItem.Text;
      string str = this.ListBoxLeft.SelectedItem.Value;
      if (this.ListBoxRight.Items.FindByValue(str) != null)
        return;
      ListItem listItem = new ListItem(text, str);
      this.ListBoxRight.Items.Add(listItem);
      this.ListBoxRight.SelectedIndex = 0;
      this.ListBoxLeft.Items.Remove(listItem);
    }

    private void btnElimina_Click(object sender, EventArgs e)
    {
      if (this.ListBoxRight.SelectedItem == null)
        return;
      string text = this.ListBoxRight.SelectedItem.Text;
      string str = this.ListBoxRight.SelectedItem.Value;
      if (this.ListBoxLeft.Items.FindByValue(str) != null)
        return;
      ListItem listItem = new ListItem(text, str);
      this.ListBoxLeft.Items.Add(listItem);
      this.ListBoxLeft.SelectedIndex = 0;
      this.ListBoxRight.Items.Remove(listItem);
    }

    private void AggiornaListBox()
    {
      this._DsListBox = new DataSet();
      this.CreaTabelle();
      if (this.itemId > 0)
      {
        DataView dataView = new DataView(new Utente().GetRuoli(this.itemId).Tables[0]);
        if (dataView.Count > 0)
        {
          foreach (DataRowView dataRowView in dataView)
          {
            DataRow row = this._DsListBox.Tables["UtentiRuoli"].NewRow();
            row["Id"] = (object) dataRowView["RUOLO_ID"].ToString();
            row["Ruolo"] = (object) dataRowView["DESCRIZIONE"].ToString();
            row["IdUtente"] = (object) dataRowView["UTENTE_ID"].ToString();
            this._DsListBox.Tables["UtentiRuoli"].Rows.Add(row);
          }
        }
      }
      this.Session.Add("UtentiRuoli", (object) this._DsListBox.Tables["UtentiRuoli"]);
      this.ListBoxRight.DataSource = (object) this._DsListBox.Tables["UtentiRuoli"];
      this.ListBoxRight.DataValueField = "Id";
      this.ListBoxRight.DataTextField = "Ruolo";
      this.ListBoxRight.DataBind();
      this.ListBoxRight.SelectedIndex = 0;
      DataView dataView1 = new DataView(new Ruolo().GetData().Tables[0]);
      if (dataView1.Count > 0)
      {
        foreach (DataRowView dataRowView in dataView1)
        {
          if (this.ListBoxRight.Items.FindByValue(dataRowView["ID"].ToString()) == null)
          {
            DataRow row = this._DsListBox.Tables["Ruoli"].NewRow();
            row["Id"] = (object) dataRowView["ID"].ToString();
            row["Ruolo"] = (object) dataRowView["DESCRIZIONE"].ToString();
            this._DsListBox.Tables["Ruoli"].Rows.Add(row);
          }
        }
      }
      this.ListBoxLeft.DataSource = (object) this._DsListBox.Tables["Ruoli"];
      this.ListBoxLeft.DataValueField = "Id";
      this.ListBoxLeft.DataTextField = "Ruolo";
      this.ListBoxLeft.DataBind();
      this.ListBoxLeft.SelectedIndex = 0;
    }

    private void UpdateRuoli(DataTable UpdateDataTable)
    {
      foreach (DataRow row in (InternalDataCollectionBase) UpdateDataTable.Rows)
      {
        if (row["Operazione"] != DBNull.Value)
        {
          Utente utente = new Utente();
          try
          {
            S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
            S_Object sObject1 = new S_Object();
            ((ParameterObject) sObject1).set_ParameterName("p_Utente_Id");
            ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject1).set_Index(0);
            ((ParameterObject) sObject1).set_Value((object) Convert.ToInt32(row["IdUtente"].ToString()));
            S_Object sObject2 = new S_Object();
            ((ParameterObject) sObject2).set_ParameterName("p_Ruolo_Id");
            ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject2).set_Index(1);
            ((ParameterObject) sObject2).set_Value((object) Convert.ToInt32(row["Id"].ToString()));
            CollezioneControlli.Add(sObject1);
            CollezioneControlli.Add(sObject2);
            ExecuteType Operazione = !(row["Operazione"].ToString() == "I") ? ExecuteType.Delete : ExecuteType.Insert;
            utente.UpdateRuoli(CollezioneControlli, Operazione);
          }
          catch
          {
            this.PanelMess.ShowError("Errore: aggiornamento non riuscito", true);
          }
        }
      }
    }

    private void CreaTabelle()
    {
      DataTable table1 = new DataTable("Ruoli");
      table1.Columns.Add(new DataColumn("Id")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = true,
        AllowDBNull = false
      });
      table1.Columns.Add(new DataColumn("Ruolo")
      {
        DataType = Type.GetType("System.String"),
        Unique = false,
        AllowDBNull = false
      });
      DataTable table2 = new DataTable("UtentiRuoli");
      table2.Columns.Add(new DataColumn("Id")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = true,
        AllowDBNull = false
      });
      table2.Columns.Add(new DataColumn("IdUtente")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = false,
        AllowDBNull = false
      });
      table2.Columns.Add(new DataColumn("Ruolo")
      {
        DataType = Type.GetType("System.String"),
        Unique = false,
        AllowDBNull = false
      });
      table2.Columns.Add(new DataColumn("Operazione")
      {
        DataType = Type.GetType("System.String"),
        Unique = false,
        AllowDBNull = true,
        DefaultValue = (object) "D"
      });
      this._DsListBox.Tables.Add(table1);
      this._DsListBox.Tables.Add(table2);
    }
  }
}
