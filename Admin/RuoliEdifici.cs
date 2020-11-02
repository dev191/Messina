// Decompiled with JetBrains decompiler
// Type: TheSite.Admin.RuoliEdifici
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ClassiAnagrafiche;
using TheSite.Classi.ClassiDettaglio;

namespace TheSite.Admin
{
  public class RuoliEdifici : Page
  {
    protected Label lblOperazione;
    protected MessagePanel PanelMess;
    protected S_ComboBox cmbsProvincia;
    protected S_ComboBox cmbsComune;
    protected Panel PanelEdit;
    protected Button btnAssociaF;
    protected Button btnEliminaF;
    protected ListBox ListBoxRightF;
    protected S_Button btnsSalva;
    protected Button btnAnnulla;
    protected CheckBoxList ListBoxLeftF;
    protected Label lblFirstAndLast;
    public static string HelpLink = string.Empty;
    private int itemId = 0;
    protected Button BtnFiltra;
    protected S_ComboBox cmbsDitta;
    protected S_ComboBox cmbsServizi;
    protected S_TextBox txtsCampus;
    protected S_TextBox txtsCodice;
    protected CheckBox ChkSelezionaLeft;
    protected CheckBox ChkSelezionaTuttiRigth;
    protected Label LblEdifici;
    protected Label LblEdificiAssociati;
    protected Label LblRuolo;
    private int FunId = 0;
    protected Label LblTitolo;
    protected Button btnAssociaServizi;
    private string descrizione = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      this.FunId = int.Parse(this.Request.Params["FunId"]);
      if (this.Request.Params["ItemId"] != null)
        this.itemId = int.Parse(this.Request.Params["ItemId"]);
      if (this.Request.Params["descr"] != null)
        this.descrizione = this.Request.Params["descr"];
      if (this.Page.IsPostBack)
        return;
      this.LblRuolo.Text = this.descrizione;
      this.CaricaListaRight();
      this.BindProvince();
      this.BindDitte();
      this.BindServizi();
      this.ImpostaCheck();
      if (((ListControl) this.cmbsProvincia).SelectedIndex >= 1)
        this.BindComuni();
      this.lblOperazione.Text = "Associazione Ruoli Edifici";
      this.lblFirstAndLast.Visible = false;
      this.ViewState["UrlReferrer"] = (object) this.Request.UrlReferrer.ToString();
    }

    private void InserisciAssociazioni()
    {
      DataTable dataTable = (DataTable) this.Session["Edifici"];
      try
      {
        foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        {
          bool flag = false;
          string str = "";
          int num = 0;
          if (row.RowState == DataRowState.Deleted)
          {
            str = "Delete";
            flag = true;
            num = Convert.ToInt32(row["id", DataRowVersion.Original].ToString());
          }
          if (row.RowState == DataRowState.Added)
          {
            str = "Insert";
            flag = true;
            num = Convert.ToInt32(row["id", DataRowVersion.Default].ToString());
          }
          if (flag)
          {
            Edificio edificio = new Edificio(this.Context.User.Identity.Name);
            S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
            S_Object sObject1 = new S_Object();
            ((ParameterObject) sObject1).set_ParameterName("p_Ruolo_Id");
            ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject1).set_Index(0);
            ((ParameterObject) sObject1).set_Value((object) this.itemId);
            S_Object sObject2 = new S_Object();
            ((ParameterObject) sObject2).set_ParameterName("p_Edificio_Id");
            ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject2).set_Index(1);
            ((ParameterObject) sObject2).set_Value((object) num);
            S_Object sObject3 = new S_Object();
            ((ParameterObject) sObject3).set_ParameterName("p_Operazione");
            ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
            ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
            ((ParameterObject) sObject3).set_Index(2);
            ((ParameterObject) sObject3).set_Value((object) str);
            S_Object sObject4 = new S_Object();
            ((ParameterObject) sObject4).set_ParameterName("p_IdOut");
            ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
            ((ParameterObject) sObject4).set_Direction(ParameterDirection.Output);
            ((ParameterObject) sObject4).set_Index(3);
            CollezioneControlli.Add(sObject1);
            CollezioneControlli.Add(sObject2);
            CollezioneControlli.Add(sObject3);
            CollezioneControlli.Add(sObject4);
            edificio.UpdateRuoliEdifici(CollezioneControlli);
          }
        }
      }
      catch (Exception ex)
      {
        this.PanelMess.ShowError(ex.Message.ToString().ToUpper(), true);
      }
    }

    private void CaricaListaRight()
    {
      DataSet ruoliEdifici = new Edificio(this.Context.User.Identity.Name).GetRuoliEdifici(this.itemId);
      ruoliEdifici.Tables[0].Columns["id"].Unique = true;
      ruoliEdifici.Tables[0].PrimaryKey = new DataColumn[1]
      {
        ruoliEdifici.Tables[0].Columns["id"]
      };
      this.Session.Add("Edifici", (object) ruoliEdifici.Tables[0]);
      if (ruoliEdifici.Tables[0].Rows.Count > 0)
      {
        DataView dataView = new DataView(ruoliEdifici.Tables[0]);
        this.ListBoxRightF.DataTextField = "descrizione";
        this.ListBoxRightF.DataValueField = "id";
        this.ListBoxRightF.DataSource = (object) dataView;
        this.ListBoxRightF.DataBind();
      }
      this.LblEdificiAssociati.Text = ruoliEdifici.Tables[0].Rows.Count.ToString();
    }

    private void CaricaListaLeft()
    {
      this.txtsCampus.set_DBDefaultValue((object) "%");
      this.txtsCodice.set_DBDefaultValue((object) "%");
      this.cmbsProvincia.set_DBDefaultValue((object) "0");
      this.cmbsComune.set_DBDefaultValue((object) "0");
      this.cmbsServizi.set_DBDefaultValue((object) "0");
      this.cmbsDitta.set_DBDefaultValue((object) "0");
      ((TextBox) this.txtsCampus).Text = ((TextBox) this.txtsCampus).Text.Trim();
      ((TextBox) this.txtsCodice).Text = ((TextBox) this.txtsCodice).Text.Trim();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      CollezioneControlli.AddItems((object) this.PanelEdit.Controls);
      DataSet dataSet = new Edificio(this.Context.User.Identity.Name).GetListaEdifici(CollezioneControlli, this.itemId).Copy();
      if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
      {
        DataView dataView = new DataView(dataSet.Tables[0]);
        this.ListBoxLeftF.DataTextField = "descrizione";
        this.ListBoxLeftF.DataValueField = "id";
        this.ListBoxLeftF.DataSource = (object) dataView;
        this.ListBoxLeftF.DataBind();
      }
      this.ImpostaEventoCheckClient();
      this.LblEdifici.Text = dataSet.Tables[0].Rows.Count.ToString();
      this.ImpostaCheck();
    }

    private void BindServizi()
    {
      DataSet dataSet = new Servizi(HttpContext.Current.User.Identity.Name).GetData().Copy();
      ((ListControl) this.cmbsServizi).Items.Clear();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsServizi).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "idservizio", "- Selezionare un Servizio -", "");
      ((ListControl) this.cmbsServizi).DataTextField = "descrizione";
      ((ListControl) this.cmbsServizi).DataValueField = "idservizio";
      ((Control) this.cmbsServizi).DataBind();
    }

    private void BindDitte()
    {
      DataSet dataSet = new Ditte().GetData().Copy();
      ((ListControl) this.cmbsDitta).Items.Clear();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsDitta).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "id", "- Selezionare una Ditta -", "");
      ((ListControl) this.cmbsDitta).DataTextField = "descrizione";
      ((ListControl) this.cmbsDitta).DataValueField = "id";
      ((Control) this.cmbsDitta).DataBind();
    }

    private void ImpostaProvinciaDefault(string provincia, string comune)
    {
      ((ListControl) this.cmbsProvincia).SelectedValue = ((ListControl) this.cmbsProvincia).Items.FindByText(provincia).Value;
      this.BindComuni();
      ((ListControl) this.cmbsComune).SelectedValue = ((ListControl) this.cmbsComune).Items.FindByText(comune).Value;
    }

    private void BindProvince()
    {
      ((ListControl) this.cmbsProvincia).Items.Clear();
      DataSet dataSet = new ProvinceComuni().GetData().Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsProvincia).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione_breve", "provincia_id", "- Selezionare una Provincia -", "");
      ((ListControl) this.cmbsProvincia).DataTextField = "descrizione_breve";
      ((ListControl) this.cmbsProvincia).DataValueField = "provincia_id";
      ((Control) this.cmbsProvincia).DataBind();
    }

    private void Disassocia()
    {
      DataTable table = new DataTable("Edifici");
      DataColumn column1 = new DataColumn("id", Type.GetType("System.String"));
      DataColumn column2 = new DataColumn("descrizione", Type.GetType("System.String"));
      table.Columns.Add(column1);
      table.Columns.Add(column2);
      DataTable dataTable = (DataTable) this.Session["Edifici"];
      foreach (ListItem listItem in this.ListBoxRightF.Items)
      {
        if (listItem.Selected)
        {
          DataRow row = table.NewRow();
          row["id"] = (object) listItem.Value;
          row["descrizione"] = (object) listItem.Text;
          table.Rows.Add(row);
          table.AcceptChanges();
          string filterExpression = "id=" + listItem.Value;
          dataTable.Select(filterExpression)[0].Delete();
        }
      }
      this.Session.Remove("Edifici");
      this.Session.Add("Edifici", (object) dataTable);
      foreach (DataRow row in (InternalDataCollectionBase) table.Rows)
      {
        string str = row["id"].ToString();
        this.ListBoxRightF.Items.Remove(new ListItem(row["descrizione"].ToString(), str));
      }
      foreach (ListItem listItem in this.ListBoxLeftF.Items)
      {
        DataRow row = table.NewRow();
        row["id"] = (object) listItem.Value;
        row["descrizione"] = (object) listItem.Text;
        table.Rows.Add(row);
        table.AcceptChanges();
      }
      DataView dataView = new DataView(table);
      dataView.Sort = "descrizione ASC";
      this.ListBoxLeftF.DataTextField = "descrizione";
      this.ListBoxLeftF.DataValueField = "id";
      this.ListBoxLeftF.DataSource = (object) dataView;
      this.ListBoxLeftF.DataBind();
    }

    private void Associa()
    {
      int count = this.ListBoxLeftF.Items.Count;
      ArrayList arrayList = new ArrayList();
      DataTable dataTable = (DataTable) this.Session["Edifici"];
      foreach (ListItem listItem1 in this.ListBoxLeftF.Items)
      {
        if (listItem1.Selected)
        {
          string text = listItem1.Text;
          string str = listItem1.Value;
          ListItem listItem2 = new ListItem(text, str);
          this.ListBoxRightF.Items.Add(listItem2);
          this.ListBoxRightF.SelectedIndex = 0;
          listItem1.Selected = false;
          arrayList.Add((object) listItem2);
          DataRow row = dataTable.NewRow();
          row["Id"] = (object) str;
          row["Descrizione"] = (object) text;
          dataTable.Rows.Add(row);
        }
        this.Session.Remove("Edifici");
        this.Session.Add("Edifici", (object) dataTable);
      }
      for (int index = 0; index < arrayList.Count; ++index)
        this.ListBoxLeftF.Items.Remove((ListItem) arrayList[index]);
    }

    private void ImpostaCheck()
    {
      this.ChkSelezionaLeft.Checked = false;
      this.ChkSelezionaLeft.Text = "Seleziona Tutti";
      this.ChkSelezionaTuttiRigth.Checked = false;
      this.ChkSelezionaTuttiRigth.Text = "Seleziona Tutti";
      if (this.ListBoxLeftF.Items.Count > 0)
        this.ChkSelezionaLeft.Visible = true;
      else
        this.ChkSelezionaLeft.Visible = false;
      if (this.ListBoxRightF.Items.Count > 0)
        this.ChkSelezionaTuttiRigth.Visible = true;
      else
        this.ChkSelezionaTuttiRigth.Visible = false;
      Label lblEdifici = this.LblEdifici;
      int count = this.ListBoxLeftF.Items.Count;
      string str1 = count.ToString();
      lblEdifici.Text = str1;
      Label edificiAssociati = this.LblEdificiAssociati;
      count = this.ListBoxRightF.Items.Count;
      string str2 = count.ToString();
      edificiAssociati.Text = str2;
    }

    private void BindComuni()
    {
      ((ListControl) this.cmbsComune).Items.Clear();
      ProvinceComuni provinceComuni = new ProvinceComuni();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_provincia_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) ((ListControl) this.cmbsProvincia).SelectedValue);
      CollezioneControlli.Add(sObject);
      DataSet dataSet = provinceComuni.GetComune(CollezioneControlli).Copy();
      if (dataSet.Tables[0].Rows.Count <= 0)
        return;
      ((BaseDataBoundControl) this.cmbsComune).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "descrizione", "comune_id", "- Selezionare un Comune -", "");
      ((ListControl) this.cmbsComune).DataTextField = "descrizione";
      ((ListControl) this.cmbsComune).DataValueField = "comune_id";
      ((Control) this.cmbsComune).DataBind();
    }

    private void ImpostaEventoCheckClient()
    {
      foreach (ListItem listItem in this.ListBoxLeftF.Items)
        listItem.Attributes.Add("onclick", "javascript:alert('ciao')");
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsProvincia).SelectedIndexChanged += new EventHandler(this.cmbsProvincia_SelectedIndexChanged);
      this.BtnFiltra.Click += new EventHandler(this.BtnFiltra_Click);
      this.btnAssociaF.Click += new EventHandler(this.btnAssociaF_Click);
      this.btnEliminaF.Click += new EventHandler(this.btnEliminaF_Click);
      this.ChkSelezionaLeft.CheckedChanged += new EventHandler(this.ChkSelezionaLeft_CheckedChanged);
      this.ChkSelezionaTuttiRigth.CheckedChanged += new EventHandler(this.ChkSelezionaTuttiRigth_CheckedChanged);
      ((Button) this.btnsSalva).Click += new EventHandler(this.btnsSalva_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.btnAssociaServizi.Click += new EventHandler(this.btnAssociaServizi_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void cmbsProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (((ListControl) this.cmbsProvincia).SelectedIndex > 0)
        this.BindComuni();
      else
        ((ListControl) this.cmbsComune).Items.Clear();
    }

    private void BtnFiltra_Click(object sender, EventArgs e)
    {
      this.ListBoxLeftF.Items.Clear();
      this.CaricaListaLeft();
    }

    private void btnAssociaF_Click(object sender, EventArgs e)
    {
      this.Associa();
      this.ImpostaCheck();
    }

    private void btnEliminaF_Click(object sender, EventArgs e)
    {
      this.Disassocia();
      this.ImpostaCheck();
    }

    private void ChkSelezionaLeft_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.ChkSelezionaLeft.Checked)
      {
        foreach (ListItem listItem in this.ListBoxLeftF.Items)
          listItem.Selected = false;
        this.ChkSelezionaLeft.Text = "Seleziona Tutti";
      }
      else
      {
        foreach (ListItem listItem in this.ListBoxLeftF.Items)
        {
          listItem.Selected = true;
          this.ChkSelezionaLeft.Text = "Deseleziona Tutti";
        }
      }
    }

    private void ChkSelezionaTuttiRigth_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.ChkSelezionaTuttiRigth.Checked)
      {
        foreach (ListItem listItem in this.ListBoxRightF.Items)
          listItem.Selected = false;
        this.ChkSelezionaTuttiRigth.Text = "Seleziona Tutti";
      }
      else
      {
        foreach (ListItem listItem in this.ListBoxRightF.Items)
        {
          listItem.Selected = true;
          this.ChkSelezionaTuttiRigth.Text = "Deseleziona Tutti";
        }
      }
    }

    private void btnsSalva_Click(object sender, EventArgs e)
    {
      this.InserisciAssociazioni();
      this.Session.Remove("Edifici");
      this.CaricaListaLeft();
      this.CaricaListaRight();
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Response.Redirect("Ruoli.aspx?FunId=" + (object) this.FunId);

    private void btnAssociaServizi_Click(object sender, EventArgs e) => this.Response.Redirect("RuoliEdificiServizi.aspx?itemId=" + (object) this.itemId + "&descr=" + this.LblRuolo.Text);
  }
}
