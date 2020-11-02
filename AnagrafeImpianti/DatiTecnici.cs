// Decompiled with JetBrains decompiler
// Type: TheSite.AnagrafeImpianti.DatiTecnici
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.WebControls;

namespace TheSite.AnagrafeImpianti
{
  public class DatiTecnici : Page
  {
    protected Panel PanelNuovoDatoTecnico;
    protected DataGrid DataGrid1;
    protected Button btRitorna;
    protected Button btsalvaTipologia;
    protected RequiredFieldValidator RequiredFieldValidator1;
    protected TextBox txtDescrizioneTipologia;
    protected RequiredFieldValidator RequiredFieldValidator2;
    protected S_ComboBox cmbsApparecchiatura;
    protected GridTitle GridTitle1;
    protected Button btNuovo;
    protected PageTitle PageTitle1;

    private void Page_Load(object sender, EventArgs e)
    {
      this.PageTitle1.VisibleLogut = false;
      if (!this.IsPostBack)
      {
        if (this.Context.Items[(object) "EQ_ID"] != null)
          this.EQ_ID = (string) this.Context.Items[(object) "EQ_ID"];
        if (this.Context.Items[(object) "ID_APPARECCHIATURA"] != null)
          this.ID_APPARECCHIATURA = (string) this.Context.Items[(object) "ID_APPARECCHIATURA"];
        if (this.Context.Items[(object) "IDEQ"] != null)
          this.EQ_ID = (string) this.Context.Items[(object) "IDEQ"];
        this.BindApparecchiature();
        this.btsalvaTipologia.CommandArgument = "Add";
      }
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.PageTitle1.Title = "Descrizione del Dato Tecnico";
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((ListControl) this.cmbsApparecchiatura).SelectedIndexChanged += new EventHandler(this.cmbsApparecchiatura_SelectedIndexChanged);
      this.btNuovo.Click += new EventHandler(this.btNuovo_Click);
      this.btsalvaTipologia.Click += new EventHandler(this.btsalvaTipologia_Click);
      this.btRitorna.Click += new EventHandler(this.btRitorna_Click);
      this.DataGrid1.ItemCommand += new DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void BindApparecchiature()
    {
      ((ListControl) this.cmbsApparecchiatura).Items.Clear();
      DataSet dataSet = new Apparecchiature(this.Context.User.Identity.Name).GetData().Copy();
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        ((BaseDataBoundControl) this.cmbsApparecchiatura).DataSource = (object) GestoreDropDownList.ItemBlankDataSource(dataSet.Tables[0], "DESCRIZIONE", "ID", "- Selezionare una Apparecchiatura -", "");
        ((ListControl) this.cmbsApparecchiatura).DataTextField = "DESCRIZIONE";
        ((ListControl) this.cmbsApparecchiatura).DataValueField = "ID";
        ((Control) this.cmbsApparecchiatura).DataBind();
        if (this.ID_APPARECCHIATURA != "0")
          ((ListControl) this.cmbsApparecchiatura).SelectedValue = this.ID_APPARECCHIATURA;
        this.BindingGrid();
      }
      else
        ((ListControl) this.cmbsApparecchiatura).Items.Add(GestoreDropDownList.ItemMessaggio("- Nessuna Apparecchiatura -", string.Empty));
    }

    private void btsalvaTipologia_Click(object sender, EventArgs e)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      if (this.btsalvaTipologia.CommandArgument == "Add")
        ((ParameterObject) sObject1).set_Value((object) int.Parse(((ListControl) this.cmbsApparecchiatura).SelectedValue));
      else
        ((ParameterObject) sObject1).set_Value((object) int.Parse(this.DataGrid1.DataKeys[this.DataGrid1.SelectedIndex].ToString()));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_descrizione");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) this.txtDescrizioneTipologia.Text);
      ((ParameterObject) sObject2).set_Size(50);
      CollezioneControlli.Add(sObject2);
      TheSite.Classi.ClassiDettaglio.DatiTecnici datiTecnici = new TheSite.Classi.ClassiDettaglio.DatiTecnici(this.Context.User.Identity.Name);
      if (this.btsalvaTipologia.CommandArgument == "Add")
      {
        datiTecnici.Add(CollezioneControlli);
        ((WebControl) this.cmbsApparecchiatura).Enabled = true;
      }
      else
      {
        ((WebControl) this.cmbsApparecchiatura).Enabled = false;
        datiTecnici.Update(CollezioneControlli, int.Parse(((ListControl) this.cmbsApparecchiatura).SelectedValue));
      }
      this.BindingGrid();
    }

    private void btRitorna_Click(object sender, EventArgs e)
    {
      this.Context.Items.Add((object) "ID_APPARECCHIATURA", (object) this.ID_APPARECCHIATURA);
      this.Context.Items.Add((object) "EQ_ID", (object) this.EQ_ID);
      this.Context.Items.Add((object) "IDEQ", (object) this.IDEQ);
      this.Server.Transfer("ListaDatiApparecchiatura.aspx");
    }

    private void cmbsApparecchiatura_SelectedIndexChanged(object sender, EventArgs e) => this.BindingGrid();

    private void BindingGrid()
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_id");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) (((ListControl) this.cmbsApparecchiatura).SelectedValue == "" ? int.Parse(this.ID_APPARECCHIATURA) : int.Parse(((ListControl) this.cmbsApparecchiatura).SelectedValue)));
      CollezioneControlli.Add(sObject);
      DataSet data = new TheSite.Classi.ClassiDettaglio.DatiTecnici(this.Context.User.Identity.Name).GetData(CollezioneControlli);
      if (data.Tables[0].Rows.Count > 0)
        this.GridTitle1.NumeroRecords = data.Tables[0].Rows.Count.ToString();
      this.DataGrid1.DataSource = (object) data;
      this.DataGrid1.DataBind();
    }

    private void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Pager || e.Item.ItemType == ListItemType.Header)
        return;
      if (((Button) e.CommandSource).Text == "Modifica")
      {
        this.txtDescrizioneTipologia.Text = e.Item.Cells[3].Text;
        ((ListControl) this.cmbsApparecchiatura).SelectedValue = e.Item.Cells[2].Text;
        ((WebControl) this.cmbsApparecchiatura).Enabled = false;
      }
      this.btsalvaTipologia.CommandArgument = "Edit";
    }

    private void btNuovo_Click(object sender, EventArgs e)
    {
      ((WebControl) this.cmbsApparecchiatura).Enabled = true;
      this.txtDescrizioneTipologia.Text = "";
      this.btsalvaTipologia.CommandArgument = "Add";
    }

    private string EQ_ID
    {
      get => this.ViewState[nameof (EQ_ID)] != null ? (string) this.ViewState[nameof (EQ_ID)] : string.Empty;
      set => this.ViewState[nameof (EQ_ID)] = (object) value;
    }

    private string IDEQ
    {
      get => this.ViewState[nameof (IDEQ)] != null ? (string) this.ViewState[nameof (IDEQ)] : string.Empty;
      set => this.ViewState[nameof (IDEQ)] = (object) value;
    }

    private string ID_APPARECCHIATURA
    {
      get => this.ViewState[nameof (ID_APPARECCHIATURA)] != null ? (string) this.ViewState[nameof (ID_APPARECCHIATURA)] : string.Empty;
      set => this.ViewState[nameof (ID_APPARECCHIATURA)] = (object) value;
    }
  }
}
