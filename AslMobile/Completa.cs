// Decompiled with JetBrains decompiler
// Type: TheSite.AslMobile.Completa
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Data.OracleClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using TheSite.AslMobile.Class;

namespace TheSite.AslMobile
{
  public class Completa : MobilePage
  {
    protected DeviceSpecific DeviceSpecific3;
    protected System.Web.UI.MobileControls.Panel Panel3;
    protected DeviceSpecific DeviceSpecific1;
    protected System.Web.UI.MobileControls.Panel Panel1;
    protected Form Form2;
    protected System.Web.UI.MobileControls.Panel Panel4;
    protected DeviceSpecific DeviceSpecific4;
    protected System.Web.UI.MobileControls.Calendar Calendar1;
    protected Form Form1;
    protected Form Form3;
    protected Form Form4;
    protected System.Web.UI.MobileControls.Label lbltipodata;
    protected Link Link8;
    private int itemId = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      if (!this.IsPostBack)
      {
        this.Panel4.Controls[0].Controls[0].FindControl("tableconferma").Visible = false;
        if (this.Request.QueryString["ItemID"] != null)
          this.itemId = int.Parse(this.Request.QueryString["ItemID"].ToString());
        this.SetValue((Control) this.Panel4, "lblDataStart", DateTime.Now.ToShortDateString());
        this.SetValue((Control) this.Panel4, "lblDataEnd", DateTime.Now.ToShortDateString());
        this.BindStatoLavoro("");
        this.LoadDati();
        this.ActiveForm = this.Form3;
      }
      ((System.Web.UI.MobileControls.Calendar) this.Form4.Controls[0].FindControl("Calendar1")).SelectedDates.Clear();
    }

    protected void OnSalva(object sender, EventArgs e) => this.Controlli(false);

    private void Controlli(bool ControllaCapit)
    {
      System.Web.UI.WebControls.RequiredFieldValidator control1 = (System.Web.UI.WebControls.RequiredFieldValidator) this.Panel4.Controls[0].FindControl("RequiredFieldValidator5");
      control1.Validate();
      System.Web.UI.WebControls.RequiredFieldValidator control2 = (System.Web.UI.WebControls.RequiredFieldValidator) this.Panel4.Controls[0].FindControl("RequiredFieldValidator6");
      control2.Validate();
      System.Web.UI.WebControls.RequiredFieldValidator control3 = (System.Web.UI.WebControls.RequiredFieldValidator) this.Panel4.Controls[0].FindControl("RequiredFieldValidator7");
      control3.Validate();
      System.Web.UI.WebControls.RequiredFieldValidator control4 = (System.Web.UI.WebControls.RequiredFieldValidator) this.Panel4.Controls[0].FindControl("RequiredFieldValidator8");
      control4.Validate();
      if (!control1.IsValid || !control2.IsValid || (!control3.IsValid || !control4.IsValid))
        return;
      int hour1 = this.GetValue((Control) this.Panel4, "txtOraStart") == "" ? 0 : int.Parse(this.GetValue((Control) this.Panel4, "txtOraStart"));
      int minute1 = this.GetValue((Control) this.Panel4, "txtMinutiStart") == "" ? 0 : int.Parse(this.GetValue((Control) this.Panel4, "txtMinutiStart"));
      int hour2 = this.GetValue((Control) this.Panel4, "txtOraEnd") == "" ? 0 : int.Parse(this.GetValue((Control) this.Panel4, "txtOraEnd"));
      int minute2 = this.GetValue((Control) this.Panel4, "txtMinutiEnd") == "" ? 0 : int.Parse(this.GetValue((Control) this.Panel4, "txtMinutiEnd"));
      string[] strArray1 = this.GetValue((Control) this.Panel4, "lblDataStart").Split(Convert.ToChar("/"));
      string[] strArray2 = this.GetValue((Control) this.Panel4, "lblDataEnd").Split(Convert.ToChar("/"));
      if (new DateTime(int.Parse(strArray1[2]), int.Parse(strArray1[1]), int.Parse(strArray1[0]), hour1, minute1, 0) > new DateTime(int.Parse(strArray2[2]), int.Parse(strArray2[1]), int.Parse(strArray2[0]), hour2, minute2, 0))
      {
        this.SetValue((Control) this.Panel4, "lblError", "La data di inizio lavori non può essere maggiore della data di fine lavori.");
      }
      else
      {
        string s = ((HtmlInputControl) this.Panel4.Controls[0].FindControl("Hiddetempointervento")).Value;
        if (s != "")
        {
          string[] strArray3 = this.GetValue((Control) this.Panel3, "lblDataRichiesta").Split(Convert.ToChar("/"));
          string[] strArray4 = this.GetValue((Control) this.Panel3, "lblOraRichiesta").Split(Convert.ToChar("."));
          int num = int.Parse(s);
          DateTime dateTime1 = new DateTime(int.Parse(strArray3[2]), int.Parse(strArray3[1]), int.Parse(strArray3[0]), int.Parse(strArray4[0]), int.Parse(strArray4[1]), 0);
          DateTime dateTime2 = new DateTime(int.Parse(strArray1[2]), int.Parse(strArray1[1]), int.Parse(strArray1[0]), hour1, minute1, 0);
          if (dateTime2.Subtract(dateTime1).TotalHours > (double) num && !ControllaCapit)
          {
            this.Panel4.Controls[0].Controls[0].FindControl("tableconferma").Visible = true;
            this.Panel4.Controls[0].Controls[0].FindControl("tableSalva").Visible = false;
            return;
          }
          string[] strArray5 = this.GetValue((Control) this.Panel1, "ldldatap").Split(Convert.ToChar("/"));
          string str = this.GetValue((Control) this.Panel1, "lblorap");
          string[] strArray6;
          if (str.IndexOf(".") > 0)
            strArray6 = str.Split(Convert.ToChar("."));
          else
            strArray6 = str.Split(Convert.ToChar(":"));
          if (new DateTime(int.Parse(strArray5[2]), int.Parse(strArray5[1]), int.Parse(strArray5[0]), int.Parse(strArray6[0]), int.Parse(strArray6[1]), 0) > dateTime2)
          {
            this.SetValue((Control) this.Panel4, "lblError", "La Data Inizio Lavori  è minore della Data richiesta Lavoro!");
            return;
          }
        }
        this.UpdateRichiesta();
      }
    }

    protected void cmdC_OnItemCommand(object sender, CommandEventArgs e)
    {
      if (e.CommandArgument.ToString() == "salva")
        this.Controlli(true);
      this.Panel4.Controls[0].Controls[0].FindControl("tableconferma").Visible = false;
      this.Panel4.Controls[0].Controls[0].FindControl("tableSalva").Visible = true;
    }

    protected void Calendar_SelectionChangedDataStart(object sender, EventArgs e)
    {
      if (((TextControl) this.Form4.Controls[0].FindControl("lbltipodata")).Text == "Data di inizio Lavori")
        ((TextControl) this.Panel4.Controls[0].FindControl("lblDataStart")).Text = this.Calendar1.SelectedDate.ToShortDateString();
      else
        ((TextControl) this.Panel4.Controls[0].FindControl("lblDataEnd")).Text = this.Calendar1.SelectedDate.ToShortDateString();
      this.ActiveForm = this.Form3;
    }

    protected void cmd_OnItemCommand(object sender, CommandEventArgs e)
    {
      if (e.CommandArgument.ToString() == "S")
        ((TextControl) this.Form4.Controls[0].FindControl("lbltipodata")).Text = "Data di inizio Lavori";
      else
        ((TextControl) this.Form4.Controls[0].FindControl("lbltipodata")).Text = "Data di fine Lavori";
      this.ActiveForm = this.Form4;
    }

    private void BindStatoLavoro(string idstato)
    {
      DropDownList control = (DropDownList) this.Panel4.Controls[0].Controls[0].FindControl("cmbsstatolavoro");
      control.Items.Clear();
      ClassRDL classRdl = new ClassRDL("");
      DataSet statoLavoro = classRdl.GetStatoLavoro();
      if (statoLavoro.Tables[0].Rows.Count > 0)
      {
        control.DataSource = (object) classRdl.ItemBlankDataSource(statoLavoro.Tables[0], "descrizione", "id", "- Selezionare lo Stato di Lavoro  -", "");
        control.DataTextField = "descrizione";
        control.DataValueField = "id";
        control.DataBind();
        if (idstato != "" && idstato != "3")
        {
          foreach (ListItem listItem in control.Items)
          {
            if (listItem.Value == "3")
              control.Items.Remove(listItem);
          }
        }
        if (idstato == "3" || idstato == "4")
          control.Enabled = false;
        control.SelectedValue = idstato;
      }
      else
      {
        string text = "- Nessuno Stato di Lavoro  -";
        control.Items.Add(new ListItem(text, string.Empty));
      }
    }

    protected void Selection_SelectedIndexLavoro(object sender, EventArgs e)
    {
      DropDownList control = (DropDownList) this.Panel4.Controls[0].Controls[0].FindControl("cmbsstatolavoro");
      switch (control.SelectedValue == "" ? 0 : int.Parse(control.SelectedValue))
      {
        case 8:
        case 11:
        case 12:
        case 13:
        case 14:
          this.Panel4.Controls[0].Controls[0].FindControl("TableSospesaLavoro").Visible = true;
          break;
        default:
          this.Panel4.Controls[0].Controls[0].FindControl("TableSospesaLavoro").Visible = false;
          break;
      }
    }

    private void UpdateRichiesta()
    {
      ClassRDL classRdl = new ClassRDL("");
      OracleParameterCollection CollezioneControlli = new OracleParameterCollection();
      CollezioneControlli.Add(new OracleParameter()
      {
        ParameterName = "p_id_status",
        OracleType = OracleType.Int32,
        Direction = ParameterDirection.Input,
        Value = (object) this.GetValue((Control) this.Panel4, "cmbsstatolavoro")
      });
      OracleParameter oracleParameter1 = new OracleParameter();
      oracleParameter1.ParameterName = "p_date_start";
      oracleParameter1.OracleType = OracleType.VarChar;
      oracleParameter1.Direction = ParameterDirection.Input;
      oracleParameter1.Size = 30;
      string str1 = string.Empty;
      string str2 = this.GetValue((Control) this.Panel4, "lblDataStart");
      if (str2 != "")
      {
        string str3 = (this.GetValue((Control) this.Panel4, "txtOraStart") == "" ? "00" : this.GetValue((Control) this.Panel4, "txtOraStart")) + ":" + (this.GetValue((Control) this.Panel4, "txtMinutiStart") == "" ? "00" : this.GetValue((Control) this.Panel4, "txtMinutiStart")) + ":00";
        str1 = str2 + " " + str3;
      }
      oracleParameter1.Value = (object) str1;
      CollezioneControlli.Add(oracleParameter1);
      OracleParameter oracleParameter2 = new OracleParameter();
      oracleParameter2.ParameterName = "p_date_end";
      oracleParameter2.OracleType = OracleType.VarChar;
      oracleParameter2.Direction = ParameterDirection.Input;
      oracleParameter2.Size = 30;
      string str4 = string.Empty;
      string str5 = this.GetValue((Control) this.Panel4, "lblDataEnd");
      if (str5 != "")
      {
        string str3 = (this.GetValue((Control) this.Panel4, "txtOraEnd") == "" ? "00" : this.GetValue((Control) this.Panel4, "txtOraEnd")) + ":" + (this.GetValue((Control) this.Panel4, "txtMinutiEnd") == "" ? "00" : this.GetValue((Control) this.Panel4, "txtMinutiEnd")) + ":00";
        str4 = str5 + " " + str3;
      }
      oracleParameter2.Value = (object) str4;
      CollezioneControlli.Add(oracleParameter2);
      CollezioneControlli.Add(new OracleParameter()
      {
        ParameterName = "p_comments",
        OracleType = OracleType.VarChar,
        Direction = ParameterDirection.Input,
        Size = 4000,
        Value = (object) this.GetValue((Control) this.Panel4, "txtAnnotazioni")
      });
      CollezioneControlli.Add(new OracleParameter()
      {
        ParameterName = "p_sospesa",
        OracleType = OracleType.VarChar,
        Direction = ParameterDirection.Input,
        Size = 2000,
        Value = (object) this.GetValue((Control) this.Panel4, "txtSospesa")
      });
      CreazioneRichiesta1 control = (CreazioneRichiesta1) this.Panel3.Controls[0].Controls[0].FindControl("CreazioneRichiesta1");
      string rdl = control.Rdl;
      int itemId = int.Parse(control.Rdl);
      classRdl.Update(CollezioneControlli, itemId);
      this.RedirectToMobilePage("RCompleta.aspx");
    }

    private void LoadDati()
    {
      ClassRDL classRdl = new ClassRDL("");
      DataSet singleRdl = classRdl.GetSingleRdl(this.itemId);
      if (singleRdl.Tables[0].Rows.Count <= 0)
        return;
      DataRow row1 = singleRdl.Tables[0].Rows[0];
      int.Parse(row1["id_bl"].ToString());
      if (row1["data_sla"] != DBNull.Value)
        ((HtmlInputControl) this.Panel4.Controls[0].FindControl("Hiddetempointervento")).Value = row1["data_sla"].ToString();
      else
        ((HtmlInputControl) this.Panel4.Controls[0].FindControl("Hiddetempointervento")).Value = "";
      ((CreazioneRichiesta1) this.Panel3.Controls[0].Controls[0].FindControl("CreazioneRichiesta1")).SetData(row1);
      CreazioneRichiesta2 control = (CreazioneRichiesta2) this.Panel1.Controls[0].Controls[0].FindControl("CreazioneRichiesta2");
      DataSet statusRdl = classRdl.GetStatusRdl(this.itemId);
      if (statusRdl.Tables[0].Rows.Count > 0)
      {
        DataRow row2 = statusRdl.Tables[0].Rows[0];
        control.SetData(row1, row2);
      }
      else
        control.SetData(row1, (DataRow) null);
      this.CompletamentoOrdine(row1);
    }

    private void CompletamentoOrdine(DataRow _Dr)
    {
      if (_Dr["idstatus"] != DBNull.Value)
      {
        if (int.Parse(_Dr["idstatus"].ToString()) == 8 || int.Parse(_Dr["idstatus"].ToString()) == 11 || (int.Parse(_Dr["idstatus"].ToString()) == 12 || int.Parse(_Dr["idstatus"].ToString()) == 13) || int.Parse(_Dr["idstatus"].ToString()) == 14)
          this.Panel4.Controls[0].Controls[0].FindControl("TableSospesaLavoro").Visible = true;
        else
          this.Panel4.Controls[0].Controls[0].FindControl("TableSospesaLavoro").Visible = false;
        this.BindStatoLavoro(_Dr["idstatus"].ToString());
      }
      else
      {
        this.BindStatoLavoro("");
        this.Panel4.Controls[0].Controls[0].FindControl("TableSospesaLavoro").Visible = false;
      }
      if (_Dr["notesospesa"] != DBNull.Value)
        this.SetValue((Control) this.Panel4, "txtSospesa", _Dr["notesospesa"].ToString());
      if (_Dr["date_start"] != DBNull.Value)
        this.SetValue((Control) this.Panel4, "lblDataStart", DateTime.Parse(_Dr["date_start"].ToString()).ToShortDateString());
      if (_Dr["date_end"] != DBNull.Value)
        this.SetValue((Control) this.Panel4, "lblDataEnd", DateTime.Parse(_Dr["date_end"].ToString()).ToShortDateString());
      if (_Dr["date_start"] != DBNull.Value)
      {
        DateTime dateTime = DateTime.Parse(_Dr["date_start"].ToString());
        this.SetValue((Control) this.Panel4, "txtOraStart", dateTime.Hour.ToString().PadLeft(2, Convert.ToChar("0")));
        this.SetValue((Control) this.Panel4, "txtMinutiStart", dateTime.Minute.ToString().PadLeft(2, Convert.ToChar("0")));
      }
      if (_Dr["date_end"] != DBNull.Value)
      {
        DateTime dateTime = DateTime.Parse(_Dr["date_end"].ToString());
        this.SetValue((Control) this.Panel4, "txtOraEnd", dateTime.Hour.ToString().PadLeft(2, Convert.ToChar("0")));
        this.SetValue((Control) this.Panel4, "txtMinutiEnd", dateTime.Minute.ToString().PadLeft(2, Convert.ToChar("0")));
      }
      if (_Dr["comments"] == DBNull.Value)
        return;
      this.SetValue((Control) this.Panel4, "txtAnnotazioni", _Dr["comments"].ToString());
    }

    private void SetValue(Control Ctrl, string NameField, string value)
    {
      Control control = Ctrl.Controls[0].FindControl(NameField);
      if (control is System.Web.UI.MobileControls.Label)
        ((TextControl) Ctrl.Controls[0].FindControl(NameField)).Text = value;
      if (control is System.Web.UI.MobileControls.TextBox)
        ((TextControl) Ctrl.Controls[0].FindControl(NameField)).Text = value;
      if (control is System.Web.UI.WebControls.TextBox)
        ((System.Web.UI.WebControls.TextBox) Ctrl.Controls[0].FindControl(NameField)).Text = value;
      if (!(control is DropDownList))
        return;
      ((ListControl) Ctrl.Controls[0].FindControl(NameField)).SelectedValue = value;
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

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      DropDownList control = (DropDownList) this.Panel4.Controls[0].Controls[0].FindControl("cmbsstatolavoro");
      control.SelectedIndexChanged += new EventHandler(this.Selection_SelectedIndexLavoro);
      control.AutoPostBack = true;
      this.Load += new EventHandler(this.Page_Load);
    }
  }
}
