// Decompiled with JetBrains decompiler
// Type: TheSite.AslMobile.Rcompleta
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
  public class Rcompleta : MobilePage
  {
    protected Form Form1;
    protected Form Form2;
    protected System.Web.UI.MobileControls.Panel Panel1;
    protected DeviceSpecific DeviceSpecific1;
    protected DeviceSpecific DeviceSpecific2;
    protected Form Form3;
    protected DeviceSpecific DeviceSpecific3;
    protected System.Web.UI.MobileControls.Panel pnlGestioneComp;
    protected System.Web.UI.MobileControls.Panel PnlRicerca;
    protected System.Web.UI.MobileControls.Calendar Calendar1;
    private string userName;
    private int p_intPriority;
    private int p_intServizio;
    private int p_intGruppo;
    protected DataGrid GridEdifici;
    protected DataGrid GridRichiedente;
    protected DataGrid GridRicerca;
    private DropDownList p_cmbsGruppo;
    private DropDownList p_cmbsServizio;
    protected Form Form4;
    protected System.Web.UI.MobileControls.Panel Panel2;
    protected DeviceSpecific DeviceSpecific4;
    private DropDownList p_cmbsPriority;

    private void Page_Load(object sender, EventArgs e) => ((System.Web.UI.MobileControls.Calendar) this.Panel2.Controls[0].FindControl("Calendar1")).SelectedDates.Clear();

    private void execute()
    {
      DataSet listaEdifici = new ClassEdifici(this.Context.User.Identity.Name).GetListaEdifici(((TextControl) this.pnlGestioneComp.Controls[0].FindControl("txtCodiceEdificio")).Text);
      if (listaEdifici.Tables[0].Rows.Count <= 0)
        return;
      this.GridEdifici.DataSource = (object) listaEdifici.Tables[0];
      this.GridEdifici.DataBind();
    }

    protected void executeRichiedente() => new ClassRichiedenti(this.userName).setBinding(this.GridRichiedente, ((TextControl) this.pnlGestioneComp.Controls[0].FindControl("txtRichiedente")).Text);

    protected void Operatore_Click(object sender, CommandEventArgs e)
    {
      ((TextControl) this.pnlGestioneComp.Controls[0].FindControl("txtRichiedente")).Text = (string) e.CommandArgument;
      this.ActiveForm = this.Form1;
    }

    protected void OnBack(object sender, EventArgs e) => this.ActiveForm = this.Form1;

    protected void OnRicerca(object sender, EventArgs e)
    {
      System.Web.UI.MobileControls.RegularExpressionValidator control1 = (System.Web.UI.MobileControls.RegularExpressionValidator) this.pnlGestioneComp.Controls[0].FindControl("ValidatorOrdine");
      System.Web.UI.MobileControls.RegularExpressionValidator control2 = (System.Web.UI.MobileControls.RegularExpressionValidator) this.pnlGestioneComp.Controls[0].FindControl("ValidatorRichiesta");
      this.p_intPriority = this.p_cmbsPriority.SelectedValue == "" ? 0 : int.Parse(this.p_cmbsPriority.SelectedValue);
      this.p_intServizio = this.p_cmbsServizio.SelectedValue == "" ? 0 : int.Parse(this.p_cmbsServizio.SelectedValue);
      this.p_intGruppo = this.p_cmbsGruppo.SelectedValue == "" ? 0 : int.Parse(this.p_cmbsGruppo.SelectedValue);
      if (!control1.IsValid || !control2.IsValid)
        return;
      this.GridRicerca.CurrentPageIndex = 0;
      if (!this.Ricerca())
        return;
      ((TextControl) this.PnlRicerca.Controls[0].FindControl("lblDscrizioneRicerca")).Text = "Richieste da completare";
      this.ActiveForm = this.Form3;
    }

    protected void OnRicercaEdifici(object sender, EventArgs e)
    {
      ((TextControl) this.Panel1.Controls[0].FindControl("lblDescrizione")).Text = "Ricerca Edifici";
      this.GridEdifici.CurrentPageIndex = 0;
      this.GridEdifici.Visible = true;
      this.GridRichiedente.Visible = false;
      this.execute();
      this.ActiveForm = this.Form2;
    }

    protected void OnRicercaRichiedente(object sender, EventArgs e)
    {
      ((TextControl) this.Panel1.Controls[0].FindControl("lblDescrizione")).Text = "Ricerca Richiedenti";
      this.GridEdifici.CurrentPageIndex = 0;
      this.GridEdifici.Visible = false;
      this.GridRichiedente.Visible = true;
      this.executeRichiedente();
      this.ActiveForm = this.Form2;
    }

    protected void OnDataSelect(object sender, EventArgs e) => this.ActiveForm = this.Form4;

    protected void Calendar_SelectionChangedDataStart(object sender, EventArgs e)
    {
      ((System.Web.UI.WebControls.TextBox) this.pnlGestioneComp.Controls[0].FindControl("txtDataCreazione")).Text = ((System.Web.UI.MobileControls.Calendar) sender).SelectedDate.ToShortDateString();
      this.ActiveForm = this.Form1;
    }

    protected void MyDataGrid1_PageIndexChanged_1(object source, DataGridPageChangedEventArgs e)
    {
      this.GridEdifici.CurrentPageIndex = e.NewPageIndex;
      this.execute();
    }

    protected void DataGridRicerca_PageIndexChanged_1(object source, DataGridPageChangedEventArgs e)
    {
      this.GridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca();
    }

    protected void DataGridRichiedenti_PageIndexChanged_1(
      object source,
      DataGridPageChangedEventArgs e)
    {
      this.GridRichiedente.CurrentPageIndex = e.NewPageIndex;
      this.executeRichiedente();
    }

    protected void imageButton_Click(object sender, CommandEventArgs e)
    {
      if ((string) e.CommandArgument != "")
        this.BindServizio((string) e.CommandArgument);
      ((TextControl) this.pnlGestioneComp.Controls[0].Controls[0].FindControl("txtCodiceEdificio")).Text = (string) e.CommandArgument;
      this.ActiveForm = this.Form1;
    }

    protected void imageButtonEdit_Click(object sender, CommandEventArgs e) => this.RedirectToMobilePage("Completa.aspx?ItemId=" + (string) e.CommandArgument);

    private void BindServizio(string CodEdificio) => new ClassServizi(this.userName).setDropDownList(this.p_cmbsServizio, CodEdificio);

    private void BindControls()
    {
      new ClassGruppo().setDropDownList(this.p_cmbsGruppo);
      new ClassUrgenza().setDropDownListDefault(this.p_cmbsPriority);
    }

    private bool Ricerca()
    {
      bool flag = false;
      DataSet dataSet = new ClassRicerca(this.Context.User.Identity.Name).Ricerca(new OracleParameterCollection()
      {
        new OracleParameter()
        {
          ParameterName = "p_operatore",
          OracleType = OracleType.VarChar,
          Direction = ParameterDirection.Input,
          Value = (object) "",
          Size = 250
        },
        new OracleParameter()
        {
          ParameterName = "p_servizio_id",
          OracleType = OracleType.Int32,
          Direction = ParameterDirection.Input,
          Value = (object) this.p_intServizio
        },
        new OracleParameter()
        {
          ParameterName = "p_campus",
          OracleType = OracleType.VarChar,
          Direction = ParameterDirection.Input,
          Value = (object) "",
          Size = 250
        },
        new OracleParameter()
        {
          ParameterName = "p_bl_id",
          OracleType = OracleType.VarChar,
          Direction = ParameterDirection.Input,
          Value = (object) ((TextControl) this.pnlGestioneComp.Controls[0].Controls[0].FindControl("txtCodiceEdificio")).Text,
          Size = 250
        },
        new OracleParameter()
        {
          ParameterName = "p_wr_id",
          OracleType = OracleType.Int32,
          Direction = ParameterDirection.Input,
          Value = (object) (((TextControl) this.pnlGestioneComp.Controls[0].Controls[0].FindControl("txtRichiesta")).Text == "" ? 0 : int.Parse(((TextControl) this.pnlGestioneComp.Controls[0].Controls[0].FindControl("txtRichiesta")).Text))
        },
        new OracleParameter()
        {
          ParameterName = "p_wo_id",
          OracleType = OracleType.Int32,
          Direction = ParameterDirection.Input,
          Value = (object) (((TextControl) this.pnlGestioneComp.Controls[0].Controls[0].FindControl("txtOrdineLavoro")).Text == "" ? 0 : int.Parse(((TextControl) this.pnlGestioneComp.Controls[0].Controls[0].FindControl("txtOrdineLavoro")).Text))
        },
        new OracleParameter()
        {
          ParameterName = "p_gruppo",
          OracleType = OracleType.Int32,
          Direction = ParameterDirection.Input,
          Value = (object) this.p_intGruppo
        },
        new OracleParameter()
        {
          ParameterName = "p_richiedente",
          OracleType = OracleType.VarChar,
          Direction = ParameterDirection.Input,
          Size = 35,
          Value = (object) ((TextControl) this.pnlGestioneComp.Controls[0].FindControl("txtRichiedente")).Text
        },
        new OracleParameter()
        {
          ParameterName = "p_descrizione",
          OracleType = OracleType.VarChar,
          Direction = ParameterDirection.Input,
          Size = 2000,
          Value = (object) ((TextControl) this.pnlGestioneComp.Controls[0].Controls[0].FindControl("txtDescrizione")).Text
        },
        new OracleParameter()
        {
          ParameterName = "p_urgenza",
          OracleType = OracleType.Int32,
          Direction = ParameterDirection.Input,
          Value = (object) this.p_intPriority
        },
        new OracleParameter()
        {
          ParameterName = "p_ditta",
          OracleType = OracleType.Int32,
          Direction = ParameterDirection.Input,
          Value = (object) 0
        },
        new OracleParameter()
        {
          ParameterName = "p_dates",
          OracleType = OracleType.VarChar,
          Direction = ParameterDirection.Input,
          Size = 10,
          Value = (object) ((System.Web.UI.WebControls.TextBox) this.pnlGestioneComp.Controls[0].Controls[0].FindControl("txtDataCreazione")).Text
        },
        new OracleParameter()
        {
          ParameterName = "p_datee",
          OracleType = OracleType.VarChar,
          Direction = ParameterDirection.Input,
          Size = 10,
          Value = (object) ""
        },
        new OracleParameter()
        {
          ParameterName = "p_addetto",
          OracleType = OracleType.VarChar,
          Direction = ParameterDirection.Input,
          Size = 250,
          Value = (object) ""
        }
      });
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        this.GridRicerca.DataSource = (object) dataSet;
        this.GridRicerca.DataBind();
        flag = true;
      }
      return flag;
    }

    protected string ValutaStringa(object obj)
    {
      if (obj == DBNull.Value || !(obj.ToString() != ""))
        return string.Empty;
      return obj.ToString().Length > 50 ? obj.ToString().Substring(0, obj.ToString().IndexOf(" ", 20)) : obj.ToString();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.GridEdifici = (DataGrid) this.Panel1.Controls[0].FindControl("DataGridEdifici");
      this.GridEdifici.PageIndexChanged += new DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged_1);
      this.GridRichiedente = (DataGrid) this.Panel1.Controls[0].FindControl("DataGridRichiedente");
      this.GridRichiedente.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRichiedenti_PageIndexChanged_1);
      this.GridRicerca = (DataGrid) this.PnlRicerca.Controls[0].FindControl("DataGridRicerca");
      this.GridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged_1);
      this.p_cmbsGruppo = (DropDownList) this.pnlGestioneComp.Controls[0].Controls[0].FindControl("cmbsGruppo");
      this.p_cmbsServizio = (DropDownList) this.pnlGestioneComp.Controls[0].Controls[0].FindControl("cmbsServizio");
      this.p_cmbsPriority = (DropDownList) this.pnlGestioneComp.Controls[0].Controls[0].FindControl("cmbsPriority");
      this.BindControls();
      this.userName = this.Context.User.Identity.Name;
      this.BindServizio("");
      this.Load += new EventHandler(this.Page_Load);
    }
  }
}
