// Decompiled with JetBrains decompiler
// Type: TheSite.AslMobile.CompletamentoUserControl
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using TheSite.AslMobile.Class;

namespace TheSite.AslMobile
{
  public abstract class CompletamentoUserControl : MobileUserControl
  {
    protected System.Web.UI.MobileControls.Panel Panel1;
    protected DeviceSpecific DeviceSpecific1;
    public string txtEdificio;
    public string txtDitta;
    protected System.Web.UI.MobileControls.Panel Panel2;
    protected DeviceSpecific DeviceSpecific2;
    public string txtNomeCompleto;
    public DataGrid p_GridRisultati;
    public MyDelegate myDelegate;
    public DropDownList pcmbsAddetti1;
    public DropDownList pcmbsAddetti0;
    public string date;

    public Hashtable _HS
    {
      get => this.ViewState[nameof (_HS)] != null ? (Hashtable) this.ViewState[nameof (_HS)] : (Hashtable) null;
      set => this.ViewState.Add(nameof (_HS), (object) value);
    }

    private void Page_Load(object sender, EventArgs e)
    {
      this.Panel1.Controls[0].FindControl("RegularExpressionValidator1").Visible = true;
      ((System.Web.UI.MobileControls.Calendar) this.Panel2.Controls[0].FindControl("Calendar1")).SelectedDates.Clear();
    }

    public void load()
    {
      string NomeCompleto = "";
      string txtDitta = this.txtDitta;
      string txtEdificio = this.txtEdificio;
      string codEdificio = txtEdificio == "" ? "%" : txtEdificio;
      DropDownList control1 = (DropDownList) this.Panel1.Controls[0].Controls[0].FindControl("cmbsAddetti0");
      DropDownList control2 = (DropDownList) this.Panel1.Controls[0].Controls[0].FindControl("cmbsAddetti1");
      DataSet addetti = new ClassRichiesta(this.Context.User.Identity.Name).GetAddetti(NomeCompleto, codEdificio, txtDitta);
      if (addetti.Tables[0].Rows.Count <= 0)
        return;
      control1.DataSource = (object) addetti.Tables[0];
      control1.DataTextField = "NOMINATIVO";
      control1.DataValueField = "ID";
      control1.DataBind();
      control2.DataSource = (object) addetti.Tables[0];
      control2.DataTextField = "NOMINATIVO";
      control2.DataValueField = "ID";
      control2.DataBind();
    }

    protected void Calendar_Click(object sender, EventArgs e)
    {
      this.Panel1.Visible = false;
      this.Panel2.Visible = true;
    }

    protected void ModificaODL_Click(object sender, EventArgs e)
    {
      this.pcmbsAddetti0 = (DropDownList) this.Panel1.Controls[0].Controls[0].FindControl("cmbsAddetti0");
      this.Panel1.Visible = true;
      this.Panel2.Visible = false;
      this.Panel1.Controls[0].FindControl("RegularExpressionValidator1").Visible = false;
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
      this.myDelegate(this._HS, 1);
    }

    protected void CompletaODL_Click(object sender, EventArgs e)
    {
      this.pcmbsAddetti1 = (DropDownList) this.Panel1.Controls[0].Controls[0].FindControl("cmbsAddetti1");
      this.date = this.GetValue((Control) this.Panel1, "txtData");
      System.Web.UI.MobileControls.RegularExpressionValidator control1 = (System.Web.UI.MobileControls.RegularExpressionValidator) this.Panel1.Controls[0].FindControl("RegularExpressionValidator1");
      control1.Visible = true;
      if (!control1.IsValid)
        return;
      this.Panel1.Visible = true;
      this.Panel2.Visible = false;
      this.GetValue((Control) this.Panel1, "txtData");
      if (this._HS == null)
        this._HS = new Hashtable();
      foreach (DataGridItem dataGridItem in this.p_GridRisultati.Items)
      {
        int num = int.Parse(dataGridItem.Cells[0].Text);
        CheckBox control2 = (CheckBox) dataGridItem.Cells[1].FindControl("ChkSel");
        if (this._HS.ContainsKey((object) num))
          this._HS.Remove((object) num);
        if (control2.Checked)
          this._HS.Add((object) num, (object) control2.Checked);
      }
      this.myDelegate(this._HS, 2);
    }

    protected void OnChiudi(object sender, EventArgs e)
    {
      this.Panel1.Visible = true;
      this.Panel2.Visible = false;
    }

    protected void Calendar_SelectionChangedDataStart(object sender, EventArgs e)
    {
      this.SetValue((Control) this.Panel1, "txtData", ((System.Web.UI.MobileControls.Calendar) sender).SelectedDate.ToShortDateString());
      this.Panel1.Visible = true;
      this.Panel2.Visible = false;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.Panel1.Visible = true;
      this.Panel2.Visible = false;
      ((WebControl) this.Panel1.Controls[0].FindControl("txtData")).Enabled = false;
      this.Load += new EventHandler(this.Page_Load);
    }

    private void SetValue(Control Ctrl, string NameField, string value)
    {
      Control control = Ctrl.Controls[0].FindControl(NameField);
      value = value.Replace("\n", " ");
      value = value.Replace("\r", "");
      if (control is System.Web.UI.MobileControls.Label)
        ((TextControl) Ctrl.Controls[0].FindControl(NameField)).Text = value;
      if (control is System.Web.UI.MobileControls.TextBox)
        ((TextControl) Ctrl.Controls[0].FindControl(NameField)).Text = value;
      if (!(control is System.Web.UI.WebControls.TextBox))
        return;
      ((System.Web.UI.WebControls.TextBox) Ctrl.Controls[0].FindControl(NameField)).Text = value;
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
