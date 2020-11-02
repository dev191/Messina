// Decompiled with JetBrains decompiler
// Type: AslMobile.Completamento_MP_WRList
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Data.OracleClient;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using TheSite.AslMobile;
using TheSite.AslMobile.Class;

namespace AslMobile
{
  public class Completamento_MP_WRList : MobilePage
  {
    protected System.Web.UI.MobileControls.Panel Panel1;
    protected DeviceSpecific DeviceSpecific1;
    protected Form Form1;
    private string userName;
    protected Form Form2;
    protected System.Web.UI.MobileControls.Panel pnlDettagli;
    protected DeviceSpecific DeviceSpecific2;
    private DataGrid DataGridRicerca;

    private string wo_id
    {
      get => this.ViewState[nameof (wo_id)] != null ? (string) this.ViewState[nameof (wo_id)] : string.Empty;
      set => this.ViewState.Add(nameof (wo_id), (object) value);
    }

    private string rdl_id
    {
      get => this.ViewState[nameof (rdl_id)] != null ? (string) this.ViewState[nameof (rdl_id)] : string.Empty;
      set => this.ViewState.Add(nameof (rdl_id), (object) value);
    }

    private int sel_grid
    {
      get => this.ViewState[nameof (sel_grid)] != null ? (int) this.ViewState[nameof (sel_grid)] : -1;
      set => this.ViewState.Add(nameof (sel_grid), (object) value);
    }

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.Page.IsPostBack)
        return;
      if (this.Request.QueryString["wo_id"] != null)
        this.wo_id = this.Request.QueryString["wo_id"];
      if (this.Context.Items[(object) "wo_id"] != null)
        this.wo_id = (string) this.Context.Items[(object) "wo_id"];
      this.Ricerca(int.Parse(this.wo_id));
    }

    private void UpdateWr()
    {
      OracleParameterCollection Coll = new OracleParameterCollection();
      ClassCompletaOrdine classCompletaOrdine = new ClassCompletaOrdine();
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_wo_id",
        OracleType = OracleType.Int32,
        Direction = ParameterDirection.Input,
        Value = (object) this.wo_id
      });
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_wr_id",
        OracleType = OracleType.Int32,
        Direction = ParameterDirection.Input,
        Value = (object) this.rdl_id
      });
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_data",
        OracleType = OracleType.DateTime,
        Direction = ParameterDirection.Input,
        Value = (object) Convert.ToDateTime(this.GetValue((Control) this.pnlDettagli, "lblCalendario")).ToString("d")
      });
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_stato",
        OracleType = OracleType.Int32,
        Direction = ParameterDirection.Input,
        Value = Convert.ToInt32(((ListControl) this.pnlDettagli.Controls[0].Controls[0].FindControl("RadioButtonList1")).SelectedItem.Value.ToString()) != 15 ? (object) 0 : (object) 1
      });
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_motivo",
        OracleType = OracleType.VarChar,
        Direction = ParameterDirection.Input,
        Size = 4000,
        Value = (object) this.GetValue((Control) this.pnlDettagli, "TextBox2")
      });
      classCompletaOrdine.AggiornaWr(Coll);
    }

    protected void Index_Changed(object sender, EventArgs e)
    {
      switch ((TheSite.AslMobile.Class.StateType) short.Parse(((ListControl) this.pnlDettagli.Controls[0].Controls[0].FindControl("RadioButtonList1")).SelectedItem.Value))
      {
        case TheSite.AslMobile.Class.StateType.AttivitaCompletata:
          ((WebControl) this.pnlDettagli.Controls[0].FindControl("TextBox2")).Enabled = false;
          break;
        case TheSite.AslMobile.Class.StateType.EmessaInLavorazione:
          ((WebControl) this.pnlDettagli.Controls[0].FindControl("TextBox2")).Enabled = false;
          break;
        case TheSite.AslMobile.Class.StateType.RichiestaSospesa:
          ((WebControl) this.pnlDettagli.Controls[0].FindControl("TextBox2")).Enabled = true;
          break;
      }
    }

    protected void OnSalva(object sender, EventArgs e)
    {
      this.UpdateWr();
      this.Ricerca(int.Parse(this.wo_id));
      this.ActiveForm = this.Form1;
    }

    protected void OnAnnulla(object sender, EventArgs e) => this.ActiveForm = this.Form1;

    protected void OnCalendario(object sender, EventArgs e) => ((CalendarioUserControl) this.pnlDettagli.Controls[0].Controls[0].FindControl("Calendario1")).EnbledCal();

    private void Ricerca(int wo_id)
    {
      OracleParameterCollection Coll = new OracleParameterCollection();
      Coll.Add(new OracleParameter()
      {
        ParameterName = "p_WO_ID",
        OracleType = OracleType.Int32,
        Direction = ParameterDirection.Input,
        Size = 4,
        Value = (object) wo_id
      });
      ClassManProgrammata classManProgrammata = new ClassManProgrammata(this.userName);
      DataRow row = classManProgrammata.GetDatiWO(Coll).Copy().Tables[0].Rows[0];
      this.SetValue((Control) this.Panel1, "lblOrdineLavoro", row[nameof (wo_id)].ToString());
      this.SetValue((Control) this.Panel1, "lblEdificio", row["Edificio"].ToString());
      this.SetValue((Control) this.Panel1, "lblIndirizzo", row["Indirizzo"].ToString());
      if (row["DataEmissione"].ToString() != "")
        this.SetValue((Control) this.Panel1, "lblODL", DateTime.Parse(row["DataEmissione"].ToString()).ToLongDateString());
      string str = row["DataPianificata"].ToString();
      if (str.Length > 0)
      {
        DateTime dateTime = Convert.ToDateTime(str);
        this.SetValue((Control) this.Panel1, "lblDataPianificata", TheSite.Classi.Function.ImpostaMese(dateTime.Month, false) + " - " + dateTime.Year.ToString());
      }
      this.DataGridRicerca.DataSource = (object) classManProgrammata.GetDatiWR(Coll).Copy().Tables[0];
      this.DataGridRicerca.DataBind();
    }

    protected void DataGridRicerca_PageIndexChanged_1(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.Ricerca(int.Parse(this.wo_id));
    }

    protected void DataGridRicerca_ItemDataBound_1(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      string empty = string.Empty;
      switch ((TheSite.AslMobile.Class.StateType) short.Parse(e.Item.Cells[9].Text))
      {
        case TheSite.AslMobile.Class.StateType.AttivitaCompletata:
          ((System.Web.UI.WebControls.Image) e.Item.Cells[0].FindControl("Imagebutton1")).ImageUrl = "./images/rosso.gif";
          break;
        case TheSite.AslMobile.Class.StateType.EmessaInLavorazione:
          ((System.Web.UI.WebControls.Image) e.Item.Cells[0].FindControl("Imagebutton1")).ImageUrl = "./images/giallo.gif";
          break;
      }
    }

    private void DataGridRicerca_ItemCommand(object source, DataGridCommandEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Pager || e.Item.ItemType == ListItemType.Header)
        return;
      this.sel_grid = e.Item.ItemIndex;
    }

    protected void RDL_Click(object sender, CommandEventArgs e)
    {
      string[] strArray = ((string) e.CommandArgument).Split(":".ToCharArray(), 3);
      this.rdl_id = strArray[0];
      int num = (int) short.Parse(strArray[1]);
      ((TextControl) this.pnlDettagli.Controls[0].FindControl("lblCalendario")).Text = DateTime.Now.ToShortDateString();
      switch ((TheSite.AslMobile.Class.StateType) num)
      {
        case TheSite.AslMobile.Class.StateType.AttivitaCompletata:
          RadioButtonList control1 = (RadioButtonList) this.pnlDettagli.Controls[0].Controls[0].FindControl("RadioButtonList1");
          control1.Items[0].Selected = true;
          control1.Items[1].Selected = false;
          control1.Enabled = false;
          if (strArray[2] != "&nbsp;")
            this.SetValue((Control) this.pnlDettagli, "TextBox2", strArray[2]);
          ((WebControl) this.pnlDettagli.Controls[0].FindControl("TextBox2")).Enabled = false;
          break;
        case TheSite.AslMobile.Class.StateType.EmessaInLavorazione:
          RadioButtonList control2 = (RadioButtonList) this.pnlDettagli.Controls[0].Controls[0].FindControl("RadioButtonList1");
          control2.Items[0].Selected = true;
          control2.Items[1].Selected = false;
          control2.Enabled = true;
          if (strArray[2] != "&nbsp;")
            this.SetValue((Control) this.pnlDettagli, "TextBox2", strArray[2]);
          ((WebControl) this.pnlDettagli.Controls[0].FindControl("TextBox2")).Enabled = false;
          break;
        case TheSite.AslMobile.Class.StateType.RichiestaSospesa:
          RadioButtonList control3 = (RadioButtonList) this.pnlDettagli.Controls[0].Controls[0].FindControl("RadioButtonList1");
          control3.Items[1].Selected = true;
          control3.Items[0].Selected = false;
          control3.Enabled = true;
          if (strArray[2] != "&nbsp;")
          {
            this.SetValue((Control) this.pnlDettagli, "TextBox2", strArray[2]);
            break;
          }
          break;
      }
      this.ActiveForm = this.Form2;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.userName = this.Context.User.Identity.Name;
      this.DataGridRicerca = (DataGrid) this.Panel1.Controls[0].FindControl("DataGridRicerca1");
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged_1);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound_1);
      this.DataGridRicerca.ItemCommand += new DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
      ((CalendarioUserControl) this.pnlDettagli.Controls[0].Controls[0].FindControl("Calendario1")).setLabel((System.Web.UI.MobileControls.Label) this.pnlDettagli.Controls[0].FindControl("lblCalendario"));
      this.Load += new EventHandler(this.Page_Load);
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
