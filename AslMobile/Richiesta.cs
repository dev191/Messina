// Decompiled with JetBrains decompiler
// Type: TheSite.AslMobile.Richiesta
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Data.OracleClient;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using TheSite.AslMobile.Class;

namespace TheSite.AslMobile
{
  public class Richiesta : MobilePage
  {
    protected DeviceSpecific DeviceSpecific1;
    protected System.Web.UI.MobileControls.Panel Panel2;
    protected Form Form2;
    protected Form Form3;
    protected DeviceSpecific DeviceSpecific2;
    protected System.Web.UI.MobileControls.Panel Panel1;
    protected Form Form1;
    protected DeviceSpecific DeviceSpecific3;
    protected System.Web.UI.MobileControls.Panel Panel3;
    protected DataGrid DataGrid1;
    protected DeviceSpecific Devicespecific2;
    protected DataGrid DataGrid2;
    protected Form Form4;
    protected System.Web.UI.MobileControls.Panel Panel4;
    protected DeviceSpecific DeviceSpecific4;
    protected DataGrid DataGrid3;
    protected Form Form5;
    protected System.Web.UI.MobileControls.Panel Panel5;
    protected DeviceSpecific DeviceSpecific5;
    private string userName;

    private int sel_linkButton
    {
      get => this.ViewState[nameof (sel_linkButton)] != null ? (int) this.ViewState[nameof (sel_linkButton)] : -1;
      set => this.ViewState.Add(nameof (sel_linkButton), (object) value);
    }

    private void Page_Load(object sender, EventArgs e)
    {
    }

    protected void OnRichiesteNonEmesse(object sender, EventArgs e)
    {
      this.sel_linkButton = 1;
      this.DataGrid3.CurrentPageIndex = 0;
      if (!this.RicercaNonEmesse())
        return;
      this.ActiveForm = this.Form4;
    }

    protected void OnRichiesteEmesse(object sender, EventArgs e)
    {
      this.sel_linkButton = 2;
      this.DataGrid3.CurrentPageIndex = 0;
      if (!this.RicercaApprovate())
        return;
      this.ActiveForm = this.Form4;
    }

    protected void consulta_Click(object sender, CommandEventArgs e)
    {
      int num = int.Parse((string) e.CommandArgument);
      ClassRDL classRdl = new ClassRDL("");
      DataSet singleRdl = classRdl.GetSingleRdl(num);
      if (singleRdl.Tables[0].Rows.Count <= 0)
        return;
      DataRow row1 = singleRdl.Tables[0].Rows[0];
      int.Parse(row1["id_bl"].ToString());
      ((CreazioneRichiesta1) this.Panel5.Controls[0].Controls[0].FindControl("CreazioneRichiesta1")).SetData(row1);
      CreazioneRichiesta2 control1 = (CreazioneRichiesta2) this.Panel5.Controls[0].Controls[0].FindControl("CreazioneRichiesta2");
      CreazioneRichiesta3 control2 = (CreazioneRichiesta3) this.Panel5.Controls[0].Controls[0].FindControl("CreazioneRichiesta3");
      DataSet statusRdl = classRdl.GetStatusRdl(num);
      if (statusRdl.Tables[0].Rows.Count > 0)
      {
        DataRow row2 = statusRdl.Tables[0].Rows[0];
        control1.SetData(row1, row2);
      }
      else
        control1.SetData(row1, (DataRow) null);
      if (short.Parse(row1["idstatus"].ToString()) == (short) 4)
        control2.SetData(row1);
      else
        control2.Visible = false;
      this.ActiveForm = this.Form5;
    }

    private bool RicercaNonEmesse()
    {
      DataSet rdlNonEmesse = new ClassRichiesta(this.userName).GetRDLNonEmesse(((TextControl) this.Panel3.Controls[0].FindControl("lblCodEdiF2")).Text);
      if (rdlNonEmesse.Tables[0].Rows.Count <= 0)
        return false;
      this.DataGrid3.DataSource = (object) rdlNonEmesse.Tables[0];
      this.DataGrid3.DataBind();
      return true;
    }

    private bool RicercaApprovate()
    {
      DataSet rdlApprovate = new ClassRichiesta(this.userName).GetRDLApprovate(((TextControl) this.Panel3.Controls[0].FindControl("lblCodEdiF2")).Text);
      if (rdlApprovate.Tables[0].Rows.Count <= 0)
        return false;
      this.DataGrid3.DataSource = (object) rdlApprovate.Tables[0];
      this.DataGrid3.DataBind();
      return true;
    }

    protected void OnRicerca(object sender, EventArgs e)
    {
      this.DataGrid1.CurrentPageIndex = 0;
      this.execute();
    }

    protected void MyDataGrid1_PageIndexChanged_1(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.execute();
    }

    protected void imageButton_Click(object sender, CommandEventArgs e)
    {
      ((TextControl) this.Form2.Controls[0].Controls[0].FindControl("lblCodEdiF2")).Text = (string) e.CommandArgument;
      string text = ((TextControl) this.Panel3.Controls[0].FindControl("lblCodEdiF2")).Text;
      ClassRichiesta classRichiesta = new ClassRichiesta(this.userName);
      ((LinkButton) this.Form2.Controls[0].Controls[0].FindControl("LinkButton1")).Text = "Richieste non Emesse : " + classRichiesta.GetNumeroNonEmesse(text);
      ((LinkButton) this.Form2.Controls[0].Controls[0].FindControl("LinkButton2")).Text = "Richieste Approvate : " + classRichiesta.GetNumeroApprovate(text);
      this.ActiveForm = this.Form2;
    }

    private void LoadCombo()
    {
      this.BindServizio(((TextControl) this.Panel1.Controls[0].Controls[0].FindControl("lblcodedi")).Text);
      this.BindApparecchiature("", "");
      this.BindCodApparecchiature("", "", "");
      this.BindControls();
    }

    protected void Selection_SelectedIndexServizi(object sender, EventArgs e)
    {
      DropDownList control = (DropDownList) this.Panel1.Controls[0].Controls[0].FindControl("cmbsServizio");
      this.BindApparecchiature(((TextControl) this.Panel1.Controls[0].Controls[0].FindControl("lblcodedi")).Text, control.SelectedValue);
      this.BindCodApparecchiature("", "", "");
    }

    protected void Selection_SelectedIndexApparecchiature(object sender, EventArgs e)
    {
      DropDownList control1 = (DropDownList) this.Panel1.Controls[0].Controls[0].FindControl("cmbsServizio");
      DropDownList control2 = (DropDownList) this.Panel1.Controls[0].Controls[0].FindControl("cmbsApp");
      this.BindCodApparecchiature(((TextControl) this.Panel1.Controls[0].Controls[0].FindControl("lblcodedi")).Text, control1.SelectedValue, control2.SelectedValue);
    }

    private void BindCodApparecchiature(
      string CodEdificio,
      string codServizio,
      string Apparecchiatura)
    {
      new ClassApparecchiatura(this.userName).setDropListCodApparecchiatura((DropDownList) this.Panel1.Controls[0].Controls[0].FindControl("cmbsAppare"), CodEdificio, codServizio, Apparecchiatura);
    }

    private void BindApparecchiature(string CodEdificio, string codServizio) => new ClassApparecchiatura(this.userName).setDropDownListApparecchiature((DropDownList) this.Panel1.Controls[0].Controls[0].FindControl("cmbsApp"), CodEdificio, codServizio);

    private void BindServizio(string CodEdificio) => new ClassServizi(this.userName).setDropDownList((DropDownList) this.Panel1.Controls[0].Controls[0].FindControl("cmbsServizio"), CodEdificio);

    private void BindControls()
    {
      new ClassGruppo().setDropDownList((DropDownList) this.Panel1.Controls[0].Controls[0].FindControl("cmbsGruppo"));
      new ClassUrgenza().setDropDownList((DropDownList) this.Panel1.Controls[0].Controls[0].FindControl("cmbsPriority"));
    }

    private void execute()
    {
      DataSet listaEdifici = new ClassEdifici(this.Context.User.Identity.Name).GetListaEdifici(((TextControl) this.Panel2.Controls[0].FindControl("txtCodice")).Text);
      if (listaEdifici.Tables[0].Rows.Count <= 0)
        return;
      this.DataGrid1.DataSource = (object) listaEdifici.Tables[0];
      this.DataGrid1.DataBind();
    }

    protected void OnSalva(object sender, EventArgs e)
    {
      System.Web.UI.MobileControls.RegularExpressionValidator control = (System.Web.UI.MobileControls.RegularExpressionValidator) this.Panel1.Controls[0].FindControl("RqTelefono");
      control.Validate();
      if (!control.IsValid)
        return;
      int num = this.NuovaRichiesta();
      if (num == 0)
        return;
      this.RedirectToMobilePage("VisualRdl.aspx?ItemId=" + num.ToString());
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.DataGrid1 = (DataGrid) this.Panel2.Controls[0].FindControl("MyDataGrid1");
      this.DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged_1);
      this.DataGrid2 = (DataGrid) this.Panel3.Controls[0].FindControl("MyDataGrid2");
      this.DataGrid2.PageIndexChanged += new DataGridPageChangedEventHandler(this.MyDataGrid2_PageIndexChanged_1);
      this.userName = this.Context.User.Identity.Name;
      this.DataGrid3 = (DataGrid) this.Panel4.Controls[0].FindControl("MyDataGrid3");
      this.DataGrid3.PageIndexChanged += new DataGridPageChangedEventHandler(this.MyDataGrid3_PageIndexChanged_1);
      DropDownList control1 = (DropDownList) this.Panel1.Controls[0].Controls[0].FindControl("cmbsServizio");
      control1.SelectedIndexChanged += new EventHandler(this.Selection_SelectedIndexServizi);
      control1.AutoPostBack = true;
      DropDownList control2 = (DropDownList) this.Panel1.Controls[0].Controls[0].FindControl("cmbsApp");
      control2.SelectedIndexChanged += new EventHandler(this.Selection_SelectedIndexApparecchiature);
      control2.AutoPostBack = true;
      this.Load += new EventHandler(this.Page_Load);
    }

    protected void MyDataGrid3_PageIndexChanged_1(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGrid3.CurrentPageIndex = e.NewPageIndex;
      switch (this.sel_linkButton)
      {
        case 1:
          this.RicercaNonEmesse();
          break;
        case 2:
          this.RicercaApprovate();
          break;
      }
    }

    protected void MyDataGrid2_PageIndexChanged_1(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGrid2.CurrentPageIndex = e.NewPageIndex;
      this.executeRichiedente();
    }

    protected void OnOperatore(object sender, EventArgs e)
    {
      if (this.IsValid)
      {
        string text1 = ((TextControl) this.Panel3.Controls[0].FindControl("txtRichiedente")).Text;
        string text2 = ((TextControl) this.Panel3.Controls[0].FindControl("lblCodEdiF2")).Text;
        this.ActiveForm = this.Form3;
        ((TextControl) this.Panel1.Controls[0].FindControl("lblcodedi")).Text = text2;
        ((TextControl) this.Panel1.Controls[0].FindControl("lblRichiedenteF3")).Text = text1;
        ((TextControl) this.Panel1.Controls[0].FindControl("lblDataRichiesta")).Text = DateTime.Now.ToShortDateString();
        ((TextControl) this.Panel1.Controls[0].FindControl("lblOraRichiesta")).Text = DateTime.Now.ToShortTimeString();
        this.LoadCombo();
      }
      else
        this.Panel3.Controls[0].FindControl("RequiredFieldValidator1").Visible = true;
    }

    protected void OnRicercaOperatore(object sender, EventArgs e)
    {
      this.DataGrid2.Visible = true;
      this.DataGrid2.CurrentPageIndex = 0;
      this.executeRichiedente();
    }

    protected void executeRichiedente() => new ClassRichiedenti(this.userName).setBinding(this.DataGrid2, ((TextControl) this.Panel3.Controls[0].FindControl("txtRichiedente")).Text);

    protected void Operatore_Click(object sender, CommandEventArgs e)
    {
      ((TextControl) this.Panel3.Controls[0].FindControl("txtRichiedente")).Text = (string) e.CommandArgument;
      this.DataGrid2.Visible = false;
    }

    private int NuovaRichiesta()
    {
      ClassRichiesta classRichiesta = new ClassRichiesta(this.userName);
      OracleParameterCollection Coll = new OracleParameterCollection();
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_Bl_Id",
        OracleType = OracleType.VarChar,
        Direction = ParameterDirection.Input,
        Size = 8,
        Value = (object) ((TextControl) this.Panel1.Controls[0].FindControl("lblcodedi")).Text
      });
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_Em_Id",
        OracleType = OracleType.VarChar,
        Direction = ParameterDirection.Input,
        Size = 50,
        Value = (object) ((TextControl) this.Panel1.Controls[0].FindControl("lblRichiedenteF3")).Text
      });
      OracleParameter oracleParameter1 = new OracleParameter();
      oracleParameter1.ParameterName = "p_Gruppo";
      oracleParameter1.OracleType = OracleType.VarChar;
      oracleParameter1.Direction = ParameterDirection.Input;
      DropDownList control1 = (DropDownList) this.Panel1.Controls[0].FindControl("cmbsGruppo");
      oracleParameter1.Value = control1.SelectedValue == string.Empty ? (object) "0" : (object) control1.SelectedValue;
      Coll.Add(oracleParameter1);
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_Phone",
        OracleType = OracleType.VarChar,
        Direction = ParameterDirection.Input,
        Size = 50,
        Value = (object) ((TextControl) this.Panel1.Controls[0].FindControl("txtsTelefonoRichiedente")).Text
      });
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_Nota_Ric",
        OracleType = OracleType.VarChar,
        Direction = ParameterDirection.Input,
        Size = 2000,
        Value = (object) ((TextControl) this.Panel1.Controls[0].FindControl("txtsNota")).Text
      });
      OracleParameter oracleParameter2 = new OracleParameter();
      oracleParameter2.ParameterName = "p_Priority";
      oracleParameter2.OracleType = OracleType.Int32;
      oracleParameter2.Direction = ParameterDirection.Input;
      DropDownList control2 = (DropDownList) this.Panel1.Controls[0].FindControl("cmbsPriority");
      oracleParameter2.Value = (object) (control2.SelectedValue == string.Empty ? 0 : Convert.ToInt32(control2.SelectedValue));
      Coll.Add(oracleParameter2);
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_Description",
        OracleType = OracleType.VarChar,
        Direction = ParameterDirection.Input,
        Size = 2000,
        Value = (object) ((System.Web.UI.WebControls.TextBox) this.Panel1.Controls[0].FindControl("txtsProblema")).Text
      });
      OracleParameter oracleParameter3 = new OracleParameter();
      oracleParameter3.ParameterName = "p_Servizio_Id";
      oracleParameter3.OracleType = OracleType.Int32;
      oracleParameter3.Direction = ParameterDirection.Input;
      DropDownList control3 = (DropDownList) this.Panel1.Controls[0].FindControl("cmbsServizio");
      oracleParameter3.Value = (object) (control3.SelectedValue == string.Empty ? 0 : Convert.ToInt32(control3.SelectedValue));
      Coll.Add(oracleParameter3);
      OracleParameter oracleParameter4 = new OracleParameter();
      oracleParameter4.ParameterName = "p_Eq_Id";
      oracleParameter4.OracleType = OracleType.Int32;
      oracleParameter4.Direction = ParameterDirection.InputOutput;
      DropDownList control4 = (DropDownList) this.Panel1.Controls[0].FindControl("cmbsAppare");
      oracleParameter4.Value = (object) (control4.SelectedValue == string.Empty ? 0 : Convert.ToInt32(control4.SelectedValue));
      Coll.Add(oracleParameter4);
      OracleParameter oracleParameter5 = new OracleParameter();
      oracleParameter5.ParameterName = "p_Eqstd_Id";
      oracleParameter5.OracleType = OracleType.Int32;
      oracleParameter5.Direction = ParameterDirection.Input;
      DropDownList control5 = (DropDownList) this.Panel1.Controls[0].FindControl("cmbsApp");
      oracleParameter5.Value = (object) (control5.SelectedValue == string.Empty ? 0 : Convert.ToInt32(control5.SelectedValue));
      Coll.Add(oracleParameter5);
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_Date_Requested",
        OracleType = OracleType.VarChar,
        Direction = ParameterDirection.Input,
        Size = 10,
        Value = (object) ((TextControl) this.Panel1.Controls[0].FindControl("lblDataRichiesta")).Text
      });
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_Time_Requested",
        OracleType = OracleType.VarChar,
        Direction = ParameterDirection.Input,
        Size = 10,
        Value = (object) ((TextControl) this.Panel1.Controls[0].FindControl("lblOraRichiesta")).Text
      });
      try
      {
        return classRichiesta.Crea(Coll);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return 0;
      }
    }
  }
}
