// Decompiled with JetBrains decompiler
// Type: TheSite.AslMobile.CompletamentoMP
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Collections;
using System.Data;
using System.Data.OracleClient;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using TheSite.AslMobile.Class;

namespace TheSite.AslMobile
{
  public class CompletamentoMP : MobilePage
  {
    protected System.Web.UI.MobileControls.Panel pnlRicerca;
    protected DeviceSpecific DeviceSpecific1;
    protected Form Form1;
    private DropDownList p_cmbsServizio;
    private DropDownList p_cmbsDitta;
    private DataGrid p_GridEdifici;
    private DataGrid p_GridAddetti;
    protected Form Form2;
    protected System.Web.UI.MobileControls.Panel pnlSelezione;
    protected DeviceSpecific DeviceSpecific2;
    protected Form Form3;
    protected System.Web.UI.MobileControls.Panel pnlRisultati;
    protected DeviceSpecific DeviceSpecific3;
    protected DeviceSpecific DeviceSpecific4;
    protected System.Web.UI.MobileControls.Panel Panel1;
    protected Form Form4;
    protected Link Link1;
    protected Link Link2;
    protected Form Form5;
    protected System.Web.UI.MobileControls.Panel Panel2;
    protected DeviceSpecific DeviceSpecific5;
    private string userName;
    private Repeater RepeaterMaster;
    private int operazione;

    private DataGrid p_GridRisultati
    {
      get => this.ViewState[nameof (p_GridRisultati)] != null ? (DataGrid) this.ViewState[nameof (p_GridRisultati)] : (DataGrid) null;
      set => this.ViewState.Add(nameof (p_GridRisultati), (object) value);
    }

    private Hashtable _HS
    {
      get => this.ViewState[nameof (_HS)] != null ? (Hashtable) this.ViewState[nameof (_HS)] : (Hashtable) null;
      set => this.ViewState.Add(nameof (_HS), (object) value);
    }

    private string txtDitta
    {
      get => this.ViewState[nameof (txtDitta)] != null ? (string) this.ViewState[nameof (txtDitta)] : string.Empty;
      set => this.ViewState.Add(nameof (txtDitta), (object) value);
    }

    private string txtEdificio
    {
      get => this.ViewState[nameof (txtEdificio)] != null ? (string) this.ViewState[nameof (txtEdificio)] : string.Empty;
      set => this.ViewState.Add(nameof (txtEdificio), (object) value);
    }

    private string dataDA
    {
      get => this.ViewState[nameof (dataDA)] != null ? (string) this.ViewState[nameof (dataDA)] : string.Empty;
      set => this.ViewState.Add(nameof (dataDA), (object) value);
    }

    private string dataA
    {
      get => this.ViewState[nameof (dataA)] != null ? (string) this.ViewState[nameof (dataA)] : string.Empty;
      set => this.ViewState.Add(nameof (dataA), (object) value);
    }

    private int id_ditta
    {
      get => this.ViewState[nameof (id_ditta)] != null ? (int) this.ViewState[nameof (id_ditta)] : 0;
      set => this.ViewState.Add(nameof (id_ditta), (object) value);
    }

    private int id_servizio
    {
      get => this.ViewState[nameof (id_servizio)] != null ? (int) this.ViewState[nameof (id_servizio)] : 0;
      set => this.ViewState.Add(nameof (id_servizio), (object) value);
    }

    private void Page_Load(object sender, EventArgs e)
    {
      CompletamentoUserControl control = (CompletamentoUserControl) this.pnlRisultati.Controls[0].Controls[0].FindControl("Completamento1");
      control.txtDitta = this.txtDitta;
      control.txtEdificio = this.txtEdificio;
      control.txtNomeCompleto = this.GetValue((Control) this.pnlRicerca, "txtAddetto");
      control.p_GridRisultati = this.p_GridRisultati;
      control._HS = this._HS;
      control.myDelegate += new MyDelegate(this.MyActive);
    }

    private void MyActive(Hashtable HS, int operazione)
    {
      this.operazione = operazione;
      this.RepeaterMaster.DataSource = (object) HS;
      this.RepeaterMaster.DataBind();
      this.ActiveForm = this.Form5;
    }

    protected void OnRicerca(object sender, EventArgs e)
    {
      this.dataDA = 1.ToString() + "/" + (object) (int) short.Parse(this.GetValue(this.pnlRicerca.Controls[0], "cmbsMeseDa")) + "/" + (object) (int) short.Parse(this.GetValue(this.pnlRicerca.Controls[0], "cmbsAnnoDa"));
      this.dataA = DateTime.DaysInMonth((int) short.Parse(this.GetValue(this.pnlRicerca.Controls[0], "cmbsAnnoA")), (int) short.Parse(this.GetValue(this.pnlRicerca.Controls[0], "cmbsMeseA"))).ToString() + "/" + (object) (int) short.Parse(this.GetValue(this.pnlRicerca.Controls[0], "cmbsMeseA")) + "/" + (object) (int) short.Parse(this.GetValue(this.pnlRicerca.Controls[0], "cmbsAnnoA"));
      this.id_ditta = 0;
      if (this.p_cmbsDitta.SelectedValue != "")
        this.id_ditta = int.Parse(this.p_cmbsDitta.SelectedValue);
      this.id_servizio = 0;
      if (this.p_cmbsServizio.SelectedValue != "")
        this.id_servizio = int.Parse(this.p_cmbsServizio.SelectedValue);
      if (this._HS != null)
        this._HS.Clear();
      if (!this.Ricerca())
        return;
      this.txtEdificio = this.GetValue((Control) this.pnlRicerca, "txtCodEdificio");
      this.txtDitta = this.p_cmbsDitta.SelectedValue;
      CompletamentoUserControl control = (CompletamentoUserControl) this.pnlRisultati.Controls[0].Controls[0].FindControl("Completamento1");
      control.txtDitta = this.txtDitta;
      control.txtEdificio = this.txtEdificio;
      control.txtNomeCompleto = this.GetValue((Control) this.pnlRicerca, "txtAddetto");
      control.p_GridRisultati = this.p_GridRisultati;
      control.load();
      this.ActiveForm = this.Form3;
    }

    protected void Risultati_Click(object sender, CommandEventArgs e) => this.Server.Transfer(e.CommandArgument.ToString());

    protected void OnRicercaEdifici(object sender, EventArgs e)
    {
      this.saveForm();
      this.p_GridAddetti.Visible = false;
      this.p_GridEdifici.Visible = true;
      this.p_GridEdifici.CurrentPageIndex = 0;
      this.execute();
      this.ActiveForm = this.Form2;
    }

    protected void DataGridEdifici_PageIndexChanged_1(object source, DataGridPageChangedEventArgs e)
    {
      this.p_GridEdifici.CurrentPageIndex = e.NewPageIndex;
      this.execute();
    }

    protected void OnAnnulla(object sender, EventArgs e)
    {
      this.restoreForm();
      this.ActiveForm = this.Form1;
    }

    protected void OnRicercaAddetti(object sender, EventArgs e)
    {
      this.saveForm();
      this.p_GridAddetti.Visible = true;
      this.p_GridEdifici.Visible = false;
      this.p_GridAddetti.CurrentPageIndex = 0;
      if (!this.RicercaAddetti())
        return;
      this.ActiveForm = this.Form2;
    }

    protected void DataGridAddetti_PageIndexChanged_1(object source, DataGridPageChangedEventArgs e)
    {
      this.p_GridAddetti.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }

    protected void DataGridRisultati_PageIndexChanged_1(
      object source,
      DataGridPageChangedEventArgs e)
    {
      this.MemorizzaCheck();
      this.p_GridRisultati.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }

    private void MemorizzaCheck()
    {
      if (this._HS == null)
        this._HS = new Hashtable();
      foreach (DataGridItem dataGridItem in this.p_GridRisultati.Items)
      {
        int num = int.Parse(dataGridItem.Cells[0].Text);
        CheckBox control = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
        if (this._HS.ContainsKey((object) num))
          this._HS.Remove((object) num);
        if (control.Checked)
          this._HS.Add((object) num, (object) control.Checked);
      }
    }

    protected void imageButton_Click(object sender, CommandEventArgs e)
    {
      this.SetValue((Control) this.pnlRicerca, "txtCodEdificio", (string) e.CommandArgument);
      this.CaricaDitte();
      this.BindServizio((string) e.CommandArgument);
      this.restoreForm();
      this.ActiveForm = this.Form1;
    }

    protected void Addetto_Click(object sender, CommandEventArgs e)
    {
      this.restoreForm();
      this.SetValue((Control) this.pnlRicerca, "txtAddetto", (string) e.CommandArgument);
      this.ActiveForm = this.Form1;
    }

    private DataSet AggiornaWo(int itemId)
    {
      OracleParameterCollection Coll = new OracleParameterCollection();
      ClassCompletaOrdine classCompletaOrdine = new ClassCompletaOrdine();
      DropDownList pcmbsAddetti0 = ((CompletamentoUserControl) this.pnlRisultati.Controls[0].Controls[0].FindControl("Completamento1")).pcmbsAddetti0;
      int num = itemId;
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_wo_id",
        OracleType = OracleType.Int32,
        Direction = ParameterDirection.Input,
        Value = (object) num
      });
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_addetto_id",
        OracleType = OracleType.Int32,
        Direction = ParameterDirection.Input,
        Value = (object) pcmbsAddetti0.SelectedValue
      });
      return classCompletaOrdine.AggiornaWO(Coll);
    }

    private DataSet UpdateWo(int itemId)
    {
      OracleParameterCollection Coll = new OracleParameterCollection();
      ClassCompletaOrdine classCompletaOrdine = new ClassCompletaOrdine();
      CompletamentoUserControl control = (CompletamentoUserControl) this.pnlRisultati.Controls[0].Controls[0].FindControl("Completamento1");
      DropDownList pcmbsAddetti1 = control.pcmbsAddetti1;
      int num = itemId;
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_wo_id",
        OracleType = OracleType.Int32,
        Direction = ParameterDirection.Input,
        Value = (object) num
      });
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_addetto_id",
        OracleType = OracleType.Int32,
        Direction = ParameterDirection.Input,
        Value = (object) pcmbsAddetti1.SelectedValue
      });
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_data",
        OracleType = OracleType.DateTime,
        Direction = ParameterDirection.Input,
        Value = (object) Convert.ToDateTime(control.date)
      });
      return classCompletaOrdine.CompletaWO(Coll);
    }

    protected void DataGridRepeaterMaster_ItemDataBound_1(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      Repeater control = (Repeater) e.Item.FindControl("RepeaterDettail");
      int int32 = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Key").ToString());
      DataSet dataSet = this.operazione != 2 ? this.AggiornaWo(int32) : this.UpdateWo(int32);
      control.DataSource = (object) dataSet.Tables[0];
      control.DataBind();
    }

    private bool Ricerca()
    {
      OracleParameterCollection Coll = new OracleParameterCollection();
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_TipoManutenzione",
        OracleType = OracleType.Int32,
        Direction = ParameterDirection.Input,
        Size = 4,
        Value = (object) TipoManutenzioneType.ManutenzioneProgrammata
      });
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_AnnoDa",
        OracleType = OracleType.VarChar,
        Direction = ParameterDirection.Input,
        Size = 10,
        Value = (object) this.dataDA
      });
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_AnnoA",
        OracleType = OracleType.VarChar,
        Direction = ParameterDirection.Input,
        Size = 10,
        Value = (object) this.dataA
      });
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_Ditta",
        OracleType = OracleType.Int32,
        Direction = ParameterDirection.Input,
        Size = 4,
        Value = (object) this.id_ditta
      });
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_Servizio",
        OracleType = OracleType.Int32,
        Direction = ParameterDirection.Input,
        Size = 4,
        Value = (object) this.id_servizio
      });
      int num = 0;
      string str = this.GetValue((Control) this.pnlRicerca, "txtOrdineLavoro");
      if (str.Trim() != "")
        num = int.Parse(str.Trim());
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_Wo_Id",
        OracleType = OracleType.Int32,
        Direction = ParameterDirection.Input,
        Size = 4,
        Value = (object) num
      });
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_Id_Bl",
        OracleType = OracleType.VarChar,
        Direction = ParameterDirection.Input,
        Size = 20,
        Value = (object) this.GetValue((Control) this.pnlRicerca, "txtCodEdificio")
      });
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_Nome_Completo",
        OracleType = OracleType.VarChar,
        Direction = ParameterDirection.Input,
        Size = 4,
        Value = (object) this.GetValue((Control) this.pnlRicerca, "txtAddetto")
      });
      DataSet dataSet = new ClassManProgrammata(this.userName).Ricerca(Coll);
      if (dataSet.Tables[0].Rows.Count <= 0)
        return false;
      this.p_GridRisultati.DataSource = (object) dataSet.Tables[0];
      this.p_GridRisultati.DataBind();
      return true;
    }

    private void execute()
    {
      DataSet listaEdifici = new ClassEdifici(this.Context.User.Identity.Name).GetListaEdifici(this.GetValue((Control) this.pnlRicerca, "txtCodEdificio"));
      if (listaEdifici.Tables[0].Rows.Count <= 0)
        return;
      this.p_GridEdifici.DataSource = (object) listaEdifici.Tables[0];
      this.p_GridEdifici.DataBind();
    }

    private bool RicercaAddetti()
    {
      string NomeCompleto = this.GetValue((Control) this.pnlRicerca, "txtAddetto");
      string selectedValue = this.p_cmbsDitta.SelectedValue;
      string str = this.GetValue((Control) this.pnlRicerca, "txtCodEdificio");
      string codEdificio = str == "" ? "%" : str;
      DataSet addetti = new ClassRichiesta(this.userName).GetAddetti(NomeCompleto, codEdificio, selectedValue);
      if (addetti.Tables[0].Rows.Count <= 0)
        return false;
      this.p_GridAddetti.DataSource = (object) addetti.Tables[0];
      this.p_GridAddetti.DataBind();
      return true;
    }

    private void CaricaCombiAnni()
    {
      DropDownList control1 = (DropDownList) this.pnlRicerca.Controls[0].Controls[0].FindControl("cmbsAnnoDa");
      DropDownList control2 = (DropDownList) this.pnlRicerca.Controls[0].Controls[0].FindControl("cmbsAnnoA");
      string str = DateTime.Now.Year.ToString();
      for (int index = 1950; index <= 2051; ++index)
      {
        ListItem listItem1 = new ListItem();
        ListItem listItem2 = new ListItem();
        listItem1.Text = index.ToString();
        listItem1.Value = index.ToString();
        listItem2.Text = index.ToString();
        listItem2.Value = index.ToString();
        control2.Items.Add(listItem1);
        control1.Items.Add(listItem2);
      }
      control1.SelectedValue = str;
      control2.SelectedValue = str;
    }

    private void BindServizio(string CodEdificio)
    {
      new ClassServizi(this.userName).setDropDownList(this.p_cmbsServizio, CodEdificio);
      this.CaricaDitte();
    }

    private void CaricaDitte()
    {
      string bl_id = this.GetValue((Control) this.pnlRicerca, "txtCodEdificio");
      if (bl_id != "")
        this.BindDitte(int.Parse(new ClassFunction().GetIdBL(bl_id).Tables[0].Rows[0][0].ToString()));
      else
        this.BindDitte(0);
    }

    private void BindDitte(int idbl)
    {
      this.p_cmbsDitta.Items.Clear();
      ClassDitta classDitta = new ClassDitta(this.userName);
      int idditta = idbl <= 0 ? 0 : int.Parse(classDitta.GetDittaBl(idbl).Tables[0].Rows[0]["id_ditta"].ToString());
      DataSet ditteFornitoriRuoli = classDitta.GetDitteFornitoriRuoli(idditta);
      if (ditteFornitoriRuoli.Tables[0].Rows.Count > 0)
      {
        this.p_cmbsDitta.DataSource = (object) ditteFornitoriRuoli.Tables[0];
        this.p_cmbsDitta.DataTextField = "DESCRIZIONE";
        this.p_cmbsDitta.DataValueField = "id";
        this.p_cmbsDitta.DataBind();
      }
      else
        this.p_cmbsDitta.Items.Add(new ListItem("- Nessuna Ditta  -", string.Empty));
    }

    private void saveForm()
    {
      DropDownList control1 = (DropDownList) this.pnlRicerca.Controls[0].Controls[0].FindControl("cmbsMeseDa");
      DropDownList control2 = (DropDownList) this.pnlRicerca.Controls[0].Controls[0].FindControl("cmbsAnnoDa");
      DropDownList control3 = (DropDownList) this.pnlRicerca.Controls[0].Controls[0].FindControl("cmbsMeseA");
      DropDownList control4 = (DropDownList) this.pnlRicerca.Controls[0].Controls[0].FindControl("cmbsAnnoA");
      this.Session.Add("form", (object) new ClassSession()
      {
        ditta = int.Parse(this.p_cmbsDitta.SelectedValue),
        servizio = int.Parse(this.p_cmbsServizio.SelectedValue),
        daAnno = int.Parse(control2.SelectedValue),
        daMese = int.Parse(control1.SelectedValue),
        aAnno = int.Parse(control4.SelectedValue),
        aMese = int.Parse(control3.SelectedValue)
      });
    }

    private void restoreForm()
    {
      DropDownList control1 = (DropDownList) this.pnlRicerca.Controls[0].Controls[0].FindControl("cmbsMeseDa");
      DropDownList control2 = (DropDownList) this.pnlRicerca.Controls[0].Controls[0].FindControl("cmbsAnnoDa");
      DropDownList control3 = (DropDownList) this.pnlRicerca.Controls[0].Controls[0].FindControl("cmbsMeseA");
      DropDownList control4 = (DropDownList) this.pnlRicerca.Controls[0].Controls[0].FindControl("cmbsAnnoA");
      ClassSession classSession = (ClassSession) this.Session["form"];
      try
      {
        this.p_cmbsDitta.SelectedValue = Convert.ToString(classSession.ditta);
      }
      catch (ArgumentOutOfRangeException ex)
      {
        Console.Write(ex.Message);
      }
      try
      {
        this.p_cmbsServizio.SelectedValue = Convert.ToString(classSession.servizio);
      }
      catch (ArgumentOutOfRangeException ex)
      {
        Console.Write(ex.Message);
      }
      control2.SelectedValue = Convert.ToString(classSession.daAnno);
      control1.SelectedIndex = classSession.daMese - 1;
      control4.SelectedValue = Convert.ToString(classSession.aAnno);
      control3.SelectedIndex = classSession.aMese - 1;
      this.Session.Remove("form");
    }

    protected void DataGridRisultati_ItemDataBound_1(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem || (this._HS == null || !this._HS.ContainsKey((object) int.Parse(e.Item.Cells[0].Text))))
        return;
      ((CheckBox) e.Item.Cells[1].FindControl("ChkSel")).Checked = true;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.userName = this.Context.User.Identity.Name;
      this.p_cmbsServizio = (DropDownList) this.pnlRicerca.Controls[0].Controls[0].FindControl("cmbsServizio");
      this.p_cmbsDitta = (DropDownList) this.pnlRicerca.Controls[0].Controls[0].FindControl("cmbsDitta");
      this.BindServizio("");
      this.CaricaCombiAnni();
      this.p_GridEdifici = (DataGrid) this.pnlSelezione.Controls[0].FindControl("DataGridEdifici");
      this.p_GridEdifici.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridEdifici_PageIndexChanged_1);
      this.p_GridAddetti = (DataGrid) this.pnlSelezione.Controls[0].FindControl("DataGridAddetti");
      this.p_GridAddetti.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridAddetti_PageIndexChanged_1);
      this.p_GridRisultati = (DataGrid) this.pnlRisultati.Controls[0].FindControl("DatagridRisultati");
      this.p_GridRisultati.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRisultati_PageIndexChanged_1);
      this.p_GridRisultati.ItemDataBound += new DataGridItemEventHandler(this.DataGridRisultati_ItemDataBound_1);
      this.RepeaterMaster = (Repeater) this.Panel2.Controls[0].FindControl("RepeaterMaster");
      this.RepeaterMaster.ItemDataBound += new RepeaterItemEventHandler(this.DataGridRepeaterMaster_ItemDataBound_1);
      this.Load += new EventHandler(this.Page_Load);
    }

    protected void Indietro(object sender, EventArgs e)
    {
      DropDownList control1 = (DropDownList) this.Panel1.Controls[0].Controls[0].FindControl("cmbsAddetti0");
      DropDownList control2 = (DropDownList) this.Panel1.Controls[0].Controls[0].FindControl("cmbsAddetti1");
      ClassSession classSession = (ClassSession) this.Session["form"];
      try
      {
        control1.SelectedValue = Convert.ToString(classSession.addetto0);
        control2.SelectedValue = Convert.ToString(classSession.addetto1);
      }
      catch (ArgumentOutOfRangeException ex)
      {
        Console.WriteLine(ex.Message);
      }
      this.Session.Remove("form");
      this.ActiveForm = this.Form4;
    }

    private void SetValue(Control Ctrl, string NameField, string value)
    {
      Control control = Ctrl.Controls[0].FindControl(NameField);
      value = value.Replace("\n", " ");
      value = value.Replace("\r", "");
      if (control is System.Web.UI.MobileControls.Label)
        ((TextControl) Ctrl.Controls[0].FindControl(NameField)).Text = value;
      if (!(control is System.Web.UI.MobileControls.TextBox))
        return;
      ((TextControl) Ctrl.Controls[0].FindControl(NameField)).Text = value;
    }

    private string GetValue(Control Ctrl, string NameField)
    {
      switch (Ctrl.Controls[0].FindControl(NameField))
      {
        case System.Web.UI.MobileControls.Label _:
          return ((TextControl) Ctrl.Controls[0].FindControl(NameField)).Text;
        case System.Web.UI.MobileControls.TextBox _:
          return ((TextControl) Ctrl.Controls[0].FindControl(NameField)).Text;
        case System.Web.UI.WebControls.TextBox _:
          return ((System.Web.UI.WebControls.TextBox) Ctrl.Controls[0].FindControl(NameField)).Text;
        case DropDownList _:
          return ((ListControl) Ctrl.Controls[0].FindControl(NameField)).SelectedValue;
        default:
          return "";
      }
    }
  }
}
