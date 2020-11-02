// Decompiled with JetBrains decompiler
// Type: TheSite.Gestione.EditRepAddetti1
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
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;

namespace TheSite.Gestione
{
  public class EditRepAddetti1 : Page
  {
    protected MessagePanel PanelMess;
    protected Panel PanelEdit;
    private int itemId = 0;
    protected S_Button btnsSalva;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected ValidationSummary vlsEdit;
    protected Label lblOperazione;
    private int FunId = 0;
    protected S_ComboBox cmbsadd;
    protected TextBox txtsorain;
    protected TextBox txtsorainmin;
    protected TextBox txtsoraout;
    protected TextBox txtsoraoutmin;
    protected RangeValidator RVraddetto;
    protected ListBox ListBoxLeft;
    protected ListBox ListboxRight;
    protected Button btnAssocia;
    protected Button btnElimina;
    protected ListBox ListBoxRight;
    private DataSet _DsListboxL;
    private DataSet _DsListboxR;
    protected RangeValidator RangeValidator1;
    private RepAddetti _fp;

    private void Page_Load(object sender, EventArgs e)
    {
      ((WebControl) this.btnsSalva).Attributes.Add("onclick", "Valorizza('1');");
      this.btnAnnulla.Attributes.Add("onclick", "Valorizza('0');");
      this.txtsorain.Attributes.Add("onkeypress", "SoloNumeri();");
      this.txtsorain.Attributes.Add("onpaste", "return false;");
      this.txtsorain.Attributes.Add("onblur", "Formatta('" + this.txtsorain.ClientID + "');");
      this.txtsorain.Attributes.Add("maxlength", "2");
      this.txtsorainmin.Attributes.Add("onkeypress", "SoloNumeri();");
      this.txtsorainmin.Attributes.Add("onpaste", "return false;");
      this.txtsorainmin.Attributes.Add("onblur", "Formatta('" + this.txtsorainmin.ClientID + "');");
      this.txtsorainmin.Attributes.Add("maxlength", "2");
      this.txtsoraout.Attributes.Add("onkeypress", "SoloNumeri();");
      this.txtsoraout.Attributes.Add("onpaste", "return false;");
      this.txtsoraout.Attributes.Add("onblur", "Formatta('" + this.txtsoraout.ClientID + "');");
      this.txtsoraout.Attributes.Add("maxlength", "2");
      this.txtsoraoutmin.Attributes.Add("onkeypress", "SoloNumeri();");
      this.txtsoraoutmin.Attributes.Add("onpaste", "return false;");
      this.txtsoraoutmin.Attributes.Add("onblur", "Formatta('" + this.txtsoraoutmin.ClientID + "');");
      this.txtsoraoutmin.Attributes.Add("maxlength", "2");
      this.FunId = int.Parse(this.Request["FunId"]);
      if (this.Request["ItemId"] != null)
        this.itemId = int.Parse(this.Request["ItemId"]);
      if (!this.Page.IsPostBack)
      {
        this.BindAddetti();
        this.AggiornaListbox();
        if (this.itemId == 0)
        {
          this.lblOperazione.Text = "Inserimento Reperibilita' Addetto";
          this.txtsorain.Text = "00";
          this.txtsorainmin.Text = "00";
          this.txtsoraout.Text = "00";
          this.txtsoraoutmin.Text = "00";
          this.lblFirstAndLast.Visible = false;
          this.AbilitaControlli(true);
        }
        else
        {
          DataSet dataSet = new DataSet();
          DataSet singleAddrep = new TheSite.Classi.ClassiAnagrafiche.Addetti().GetSingleAddrep(this.itemId);
          if (singleAddrep.Tables[0].Rows.Count == 1)
          {
            DataRow row = singleAddrep.Tables[0].Rows[0];
            if (row["addettoid"] != DBNull.Value)
              ((ListControl) this.cmbsadd).SelectedValue = row["addettoid"].ToString();
            if (row["orain"] != DBNull.Value)
              this.txtsorain.Text = row["orain"].ToString().Split(Convert.ToChar(":"))[0];
            this.txtsorainmin.Text = row["orain"].ToString().Split(Convert.ToChar(":"))[1];
            if (row["oraout"] != DBNull.Value)
              this.txtsoraout.Text = row["oraout"].ToString().Split(Convert.ToChar(":"))[0];
            this.txtsoraoutmin.Text = row["oraout"].ToString().Split(Convert.ToChar(":"))[1];
            this.lblFirstAndLast.Visible = true;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Creato da ");
            if (row["FIRST"] != DBNull.Value)
              stringBuilder.Append(row["FIRST"].ToString());
            stringBuilder.Append(" il ");
            if (row["FIRSTMODIFIED"] != DBNull.Value)
              stringBuilder.Append(row["FIRSTMODIFIED"].ToString());
            this.lblFirstAndLast.Text = stringBuilder.ToString();
          }
          if (this.Request["TipoOper"] == "read")
          {
            this.AbilitaControlli(false);
            this.lblOperazione.Text = "Visualizzazione Reperibilita' Addetto: " + (object) ((ListControl) this.cmbsadd).SelectedItem;
          }
        }
      }
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
      if (!(this.Context.Handler is RepAddetti))
        return;
      this._fp = (RepAddetti) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void BindAddetti()
    {
      ((ListControl) this.cmbsadd).Items.Clear();
      DataSet dataSet = new TheSite.Classi.ClassiAnagrafiche.Addetti().GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsadd).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "nominativo", "id", "- Selezionare un Addetto -", "-1");
      ((ListControl) this.cmbsadd).DataTextField = "nominativo";
      ((ListControl) this.cmbsadd).DataValueField = "id";
      ((Control) this.cmbsadd).DataBind();
    }

    private void AggiornaListbox()
    {
      this._DsListboxL = new DataSet();
      this._DsListboxR = new DataSet();
      this.CreaTabelle();
      Reperibilita reperibilita = new Reperibilita();
      DataView dataView1 = new DataView(reperibilita.GetAlldays().Tables[0]);
      if (dataView1.Count > 0)
      {
        foreach (DataRowView dataRowView in dataView1)
        {
          DataRow row = this._DsListboxL.Tables["Giorni"].NewRow();
          row["Id"] = (object) dataRowView["Id"].ToString();
          row["giorno"] = (object) dataRowView["giorno"].ToString();
          this._DsListboxL.Tables["Giorni"].Rows.Add(row);
        }
      }
      this.Session.Add("Gior", (object) this._DsListboxL.Tables[0]);
      this.ListBoxLeft.DataSource = (object) this._DsListboxL.Tables["Giorni"];
      this.ListBoxLeft.DataValueField = "Id";
      this.ListBoxLeft.DataTextField = "giorno";
      this.ListBoxLeft.DataBind();
      this.ListBoxLeft.SelectedIndex = 0;
      if (this.itemId > 0)
        this.ListBoxLeft.Enabled = true;
      else
        this.ListBoxLeft.Enabled = false;
      if (this.itemId > 0)
      {
        DataView dataView2 = new DataView(reperibilita.GetAlldays().Tables[0]);
        if (dataView2.Count > 0)
        {
          foreach (DataRowView dataRowView in dataView2)
          {
            DataRow row = this._DsListboxR.Tables["GiorniAssociati"].NewRow();
            row["giorno_A"] = (object) dataRowView["giorno_A"].ToString();
            row["id_A"] = (object) dataRowView["id_A"].ToString();
            row["operazione"] = (object) dataRowView["operazione"].ToString();
            this._DsListboxR.Tables["GiorniAssociati"].Rows.Add(row);
          }
        }
      }
      this.Session.Add("GiorAss", (object) this._DsListboxR.Tables[0]);
      this.ListBoxRight.DataSource = (object) this._DsListboxR.Tables["GiorniAssociati"];
      this.ListBoxRight.DataValueField = "id_A";
      this.ListBoxRight.DataTextField = "giorno_A";
      this.ListBoxRight.DataTextField = "operazione";
      this.ListBoxRight.DataBind();
      this.ListBoxRight.SelectedIndex = 0;
    }

    private void CreaTabelle()
    {
      DataTable table1 = new DataTable("Giorni");
      table1.Columns.Add(new DataColumn("Id")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = true,
        AllowDBNull = false
      });
      table1.Columns.Add(new DataColumn("giorno")
      {
        DataType = Type.GetType("System.String"),
        Unique = false,
        AllowDBNull = false
      });
      DataTable table2 = new DataTable("GiorniAssociati");
      table2.Columns.Add(new DataColumn("Id_A")
      {
        DataType = Type.GetType("System.Int32"),
        Unique = true,
        AllowDBNull = false
      });
      table2.Columns.Add(new DataColumn("giorno_A")
      {
        DataType = Type.GetType("System.String"),
        Unique = false,
        AllowDBNull = false
      });
      table2.Columns.Add(new DataColumn("operazione")
      {
        DataType = Type.GetType("System.String"),
        Unique = false,
        AllowDBNull = false
      });
      this._DsListboxL.Tables.Add(table1);
      this._DsListboxR.Tables.Add(table2);
    }

    private void AbilitaControlli(bool enabled)
    {
      this.txtsorain.Enabled = enabled;
      this.txtsoraout.Enabled = enabled;
      ((WebControl) this.cmbsadd).Enabled = enabled;
      this.txtsorainmin.Enabled = enabled;
      this.txtsoraoutmin.Enabled = enabled;
      ((WebControl) this.btnsSalva).Enabled = enabled;
      this.ListBoxRight.Enabled = enabled;
      this.ListBoxLeft.Enabled = enabled;
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
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("RepAddetti.aspx");

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      if (this.ListBoxRight.Items.Count >= 0)
      {
        DataTable dataTable = (DataTable) this.Session["GiorniAssociati"];
        DataView dataView = new DataView(dataTable);
        foreach (ListItem listItem in this.ListBoxRight.Items)
        {
          dataView.RowFilter = "Id_A = " + listItem.Value.ToString();
          if (dataView.Count == 0)
          {
            DataRow row = dataTable.NewRow();
            row["Id_A"] = (object) listItem.Value.ToString();
            row["giorno_A"] = (object) listItem.Text.ToString();
            row["Operazione"] = (object) "I";
            dataTable.Rows.Add(row);
          }
          else if (dataView.Count == 1)
            dataView[0]["Operazione"] = (object) DBNull.Value;
        }
        this.UpdateREP_Addetti(dataTable);
        this.Session.Remove("GiorniAssociati");
      }
      else
        SiteJavaScript.msgBox(this.Page, "Non è stato selezionato alcun giorno");
    }

    private void UpdateREP_Addetti(DataTable UpdateDataTable)
    {
      foreach (DataRow row in (InternalDataCollectionBase) UpdateDataTable.Rows)
      {
        if (row["Operazione"] != DBNull.Value)
        {
          TheSite.Classi.ClassiAnagrafiche.Addetti addetti = new TheSite.Classi.ClassiAnagrafiche.Addetti();
          try
          {
            S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
            this.cmbsadd.set_DBDefaultValue((object) "-1");
            this.txtsoraout.Text = this.txtsoraout.Text.Trim();
            this.txtsorain.Text = this.txtsorain.Text.Trim();
            int num = 0;
            S_Object sObject1 = new S_Object();
            ((ParameterObject) sObject1).set_ParameterName("p_orain");
            ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
            ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject1).set_Index(2);
            ((ParameterObject) sObject1).set_Value((object) (this.txtsorain.Text + ":" + this.txtsorainmin.Text));
            S_Object sObject2 = new S_Object();
            ((ParameterObject) sObject2).set_ParameterName("p_oraout");
            ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
            ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject2).set_Index(3);
            ((ParameterObject) sObject2).set_Value((object) (this.txtsoraout.Text + ":" + this.txtsoraoutmin.Text));
            S_Object sObject3 = new S_Object();
            ((ParameterObject) sObject3).set_ParameterName("p_giorno_id");
            ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject3).set_Index(1);
            ((ParameterObject) sObject3).set_Value((object) Convert.ToInt32(row["id"].ToString()));
            CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
            CollezioneControlli.Add(sObject3);
            CollezioneControlli.Add(sObject1);
            CollezioneControlli.Add(sObject2);
            try
            {
              if (this.itemId == 0)
              {
                string Operazione = "Insert";
                num = new TheSite.Classi.ClassiAnagrafiche.Addetti().ExecuteUpdateAddRep1(CollezioneControlli, Operazione, this.itemId);
              }
              if (num == -100)
                SiteJavaScript.msgBox(this.Page, "Gli orari di inizio o fine turno del giorno prescelto coincidono con orari già esistenti");
            }
            catch (Exception ex)
            {
              this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
            }
          }
          catch (Exception ex)
          {
            this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
          }
        }
      }
    }

    private void btnAssocia_Click(object sender, EventArgs e) => this.Addiziona();

    private void btnElimina_Click(object sender, EventArgs e) => this.Sottrai();

    private void Addiziona()
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

    private void Sottrai()
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
  }
}
