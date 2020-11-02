// Decompiled with JetBrains decompiler
// Type: TheSite.AnagrafeImpianti.NavigazioneCertificati
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
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.AnagrafeImpianti;
using TheSite.WebControls;

namespace TheSite.AnagrafeImpianti
{
  public class NavigazioneCertificati : Page
  {
    protected DataPanel DataPanel1;
    protected S_Button S_btReset;
    protected S_Button S_btRicerca;
    protected S_ComboBox S_CbAnno;
    protected S_ComboBox S_CbTipo;
    protected PageTitle PageTitle1;
    protected RicercaModulo RicercaModulo1;
    protected GridTitle GridTitle1;
    protected DataGrid DataGrid1;
    protected S_TextBox S_Txtnomefile;
    protected S_TextBox S_Txtdescrizione;
    protected HtmlTable tablevvf;
    protected HtmlTable tableispesel;
    protected Matricole Matricole1;
    protected Fascicolo Fascicolo1;
    protected CalendarPicker CalendarPicker1;
    protected CalendarPicker CalendarPicker2;
    public static int FunId = 0;
    protected CheckBox chscollaudo;
    protected S_Object S_Checkcollaudo = new S_Object();
    public static string HelpLink = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      NavigazioneCertificati.FunId = siteModule.ModuleId;
      NavigazioneCertificati.HelpLink = siteModule.HelpLink;
      this.PageTitle1.Title = siteModule.ModuleTitle;
      if (!this.IsPostBack)
      {
        if (this.Request.QueryString["FunId"] != null)
          this.ViewState["FunId"] = (object) this.Request.QueryString["FunId"];
        this.BindingComboAnno();
        this.setvisible(false);
        this.GridTitle1.Visible = false;
      }
      this.RicercaModulo1.TxtCodice.set_DBParameterName("P_bl_id");
      this.RicercaModulo1.TxtCodice.set_DBIndex(0);
      this.RicercaModulo1.TxtCodice.set_DBDataType((CustomDBType) 2);
      this.RicercaModulo1.TxtCodice.set_DBDirection(ParameterDirection.Input);
      this.RicercaModulo1.TxtCodice.set_DBSize(8);
      this.RicercaModulo1.TxtCodice.set_DBDefaultValue((object) "");
      this.RicercaModulo1.TxtRicerca.set_DBParameterName("P_campus");
      this.RicercaModulo1.TxtRicerca.set_DBIndex(1);
      this.RicercaModulo1.TxtRicerca.set_DBDirection(ParameterDirection.Input);
      this.RicercaModulo1.TxtRicerca.set_DBDataType((CustomDBType) 2);
      this.RicercaModulo1.TxtRicerca.set_DBSize(128);
      this.RicercaModulo1.TxtRicerca.set_DBDefaultValue((object) "");
      this.Matricole1.Matricola.set_DBParameterName("P_matricola");
      this.Matricole1.Matricola.set_DBIndex(5);
      this.Matricole1.Matricola.set_DBDirection(ParameterDirection.Input);
      this.Matricole1.Matricola.set_DBDataType((CustomDBType) 2);
      this.Matricole1.Matricola.set_DBSize(20);
      this.Matricole1.Matricola.set_DBDefaultValue((object) "");
      this.CalendarPicker1.Datazione.set_DBParameterName("P_datav");
      this.CalendarPicker1.Datazione.set_DBIndex(6);
      this.CalendarPicker1.Datazione.set_DBDirection(ParameterDirection.Input);
      this.CalendarPicker1.Datazione.set_DBDataType((CustomDBType) 2);
      this.CalendarPicker1.Datazione.set_DBSize(20);
      this.CalendarPicker1.Datazione.set_DBDefaultValue((object) "");
      this.CalendarPicker2.Datazione.set_DBParameterName("P_dataf");
      this.CalendarPicker2.Datazione.set_DBIndex(9);
      this.CalendarPicker2.Datazione.set_DBDirection(ParameterDirection.Input);
      this.CalendarPicker2.Datazione.set_DBDataType((CustomDBType) 2);
      this.CalendarPicker2.Datazione.set_DBSize(20);
      this.CalendarPicker2.Datazione.set_DBDefaultValue((object) "");
      ((ParameterObject) this.S_Checkcollaudo).set_ParameterName("P_check");
      ((ParameterObject) this.S_Checkcollaudo).set_DbType((CustomDBType) 1);
      ((ParameterObject) this.S_Checkcollaudo).set_Direction(ParameterDirection.Input);
      ((ParameterObject) this.S_Checkcollaudo).set_Size(10);
      ((ParameterObject) this.S_Checkcollaudo).set_Index(10);
      ((ParameterObject) this.S_Checkcollaudo).set_Value((object) DBNull.Value);
      this.Fascicolo1.TxtFascicolo.set_DBParameterName("P_fascicolo");
      this.Fascicolo1.TxtFascicolo.set_DBIndex(8);
      this.Fascicolo1.TxtFascicolo.set_DBDirection(ParameterDirection.Input);
      this.Fascicolo1.TxtFascicolo.set_DBDataType((CustomDBType) 2);
      this.Fascicolo1.TxtFascicolo.set_DBSize(20);
      this.Fascicolo1.TxtFascicolo.set_DBDefaultValue((object) "");
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      ((WebControl) this.S_CbTipo).Attributes.Add("OnChange", "expandcollapse(this);");
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("if (typeof(selezionedata) == 'function') { ");
      stringBuilder.Append("if (selezionedata('" + ((Control) this.S_CbAnno).ClientID + "') == false) { return false; }} ");
      stringBuilder.Append("this.value = 'Attendere ...';");
      stringBuilder.Append("this.disabled = true;");
      stringBuilder.Append("document.getElementById('" + ((Control) this.S_btRicerca).ClientID + "').disabled = true;");
      stringBuilder.Append(this.Page.GetPostBackEventReference((Control) this.S_btRicerca));
      stringBuilder.Append(";");
      ((WebControl) this.S_btRicerca).Attributes.Add("onclick", stringBuilder.ToString());
    }

    private void BindingComboAnno()
    {
      DateTime now = DateTime.Now;
      ((ListControl) this.S_CbAnno).Items.Add(new ListItem("", ""));
      for (int index = 1970; index <= now.Year + 15; ++index)
        ((ListControl) this.S_CbAnno).Items.Add(new ListItem(index.ToString(), index.ToString()));
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.S_btRicerca).Click += new EventHandler(this.S_btRicerca_Click);
      ((Button) this.S_btReset).Click += new EventHandler(this.S_btReset_Click);
      this.DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
      this.DataGrid1.ItemDataBound += new DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void S_btRicerca_Click(object sender, EventArgs e) => this.Execute(true);

    private void Execute(bool reset)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      Certificati certificati = new Certificati(this.Context.User.Identity.Name);
      this.SetDefaultValueControl((Control) this.DataPanel1);
      if (((ListControl) this.S_CbTipo).SelectedValue != "6")
      {
        ((TextBox) this.Matricole1.Matricola).Text = "";
        ((TextBox) this.CalendarPicker1.Datazione).Text = "";
        ((ListControl) this.S_CbAnno).SelectedIndex = 0;
      }
      if (((ListControl) this.S_CbTipo).SelectedValue != "8")
      {
        ((TextBox) this.Fascicolo1.TxtFascicolo).Text = "";
        ((TextBox) this.CalendarPicker2.Datazione).Text = "";
      }
      if (((ListControl) this.S_CbTipo).SelectedValue == "6")
      {
        this.tablevvf.Style.Add("display", "none");
        this.tablevvf.Style.Add("visibility", "hidden");
        this.tableispesel.Style.Add("display", "block");
        this.tableispesel.Style.Add("visibility", "visible");
        this.DataGrid1.Columns[5].Visible = true;
        this.DataGrid1.Columns[6].Visible = false;
        this.DataGrid1.Columns[7].Visible = false;
        this.DataGrid1.Columns[8].Visible = false;
        this.DataGrid1.Columns[9].Visible = true;
        this.DataGrid1.Columns[10].Visible = true;
        this.DataGrid1.Columns[11].Visible = true;
      }
      if (((ListControl) this.S_CbTipo).SelectedValue == "8")
      {
        if (!this.chscollaudo.Visible)
          ((ParameterObject) this.S_Checkcollaudo).set_Value((object) DBNull.Value);
        else if (this.chscollaudo.Checked)
          ((ParameterObject) this.S_Checkcollaudo).set_Value((object) 1);
        else
          ((ParameterObject) this.S_Checkcollaudo).set_Value((object) 0);
        this.tableispesel.Style.Add("display", "none");
        this.tableispesel.Style.Add("visibility", "hidden");
        this.tablevvf.Style.Add("display", "block");
        this.tablevvf.Style.Add("visibility", "visible");
        this.DataGrid1.Columns[5].Visible = true;
        this.DataGrid1.Columns[6].Visible = true;
        this.DataGrid1.Columns[7].Visible = true;
        this.DataGrid1.Columns[8].Visible = true;
        this.DataGrid1.Columns[9].Visible = false;
        this.DataGrid1.Columns[10].Visible = false;
        this.DataGrid1.Columns[11].Visible = false;
      }
      if (((ListControl) this.S_CbTipo).SelectedValue != "8" && ((ListControl) this.S_CbTipo).SelectedValue != "6")
      {
        this.tablevvf.Style.Add("display", "none");
        this.tablevvf.Style.Add("visibility", "hidden");
        this.tableispesel.Style.Add("display", "none");
        this.tableispesel.Style.Add("visibility", "hidden");
        this.DataGrid1.Columns[5].Visible = true;
        this.DataGrid1.Columns[6].Visible = false;
        this.DataGrid1.Columns[7].Visible = false;
        this.DataGrid1.Columns[8].Visible = false;
        this.DataGrid1.Columns[9].Visible = false;
        this.DataGrid1.Columns[10].Visible = false;
        this.DataGrid1.Columns[11].Visible = false;
      }
      CollezioneControlli.AddItems((object) ((Control) this.DataPanel1).Controls);
      CollezioneControlli.Add(this.S_Checkcollaudo);
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pageindex");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(16);
      ((ParameterObject) sObject1).set_Value((object) (this.DataGrid1.CurrentPageIndex + 1));
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("pagesize");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(17);
      ((ParameterObject) sObject2).set_Value((object) this.DataGrid1.PageSize);
      CollezioneControlli.Add(sObject2);
      DataSet data = certificati.GetData(CollezioneControlli);
      if (reset)
      {
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 3);
        ((CollectionBase) CollezioneControlli).RemoveAt(((CollectionBase) CollezioneControlli).Count - 3);
        this.GridTitle1.NumeroRecords = certificati.GetDataCount(CollezioneControlli).ToString();
      }
      this.DataGrid1.VirtualItemCount = int.Parse(this.GridTitle1.NumeroRecords);
      this.DataGrid1.DataSource = (object) data.Tables[0];
      this.DataGrid1.DataBind();
      if (int.Parse(this.GridTitle1.NumeroRecords) > 0)
      {
        this.setvisible(true);
        this.GridTitle1.Visible = true;
        this.GridTitle1.DescriptionTitle = "";
      }
      else
      {
        this.GridTitle1.Visible = true;
        this.GridTitle1.DescriptionTitle = "Nessun dato trovato.";
        this.setvisible(false);
      }
      this.chscollaudo.Visible = true;
    }

    private void SetDefaultValueControl(Control Ctrls)
    {
      foreach (Control control in Ctrls.Controls)
      {
        if (control.Controls.Count > 0)
          this.SetDefaultValueControl(control);
        switch (control)
        {
          case S_CheckBox _:
          case S_ComboBox _:
          case S_HyperLink _:
          case S_Label _:
          case S_ListBox _:
          case S_OptionButton _:
          case S_TextBox _:
            Type type = control.GetType();
            type.GetProperty("DBDefaultValue").SetValue((object) control, (object) "", (object[]) null);
            Console.WriteLine(type.Name);
            continue;
          default:
            continue;
        }
      }
    }

    private void setvisible(bool visible)
    {
      this.GridTitle1.VisibleRecord = visible;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.DataGrid1.Visible = visible;
      this.chscollaudo.Visible = false;
    }

    private void S_btReset_Click(object sender, EventArgs e) => this.Response.Redirect("NavigazioneCertificati.aspx?FunId=" + this.ViewState["FunId"]);

    private void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.Execute(false);
    }

    private void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((WebControl) e.Item.Cells[1].FindControl("Imagebutton1")).Attributes.Add("title", "Visualizza Certificato");
      if (e.Item.Cells[8].Text == "0" || e.Item.Cells[8].Text == "")
        e.Item.Cells[8].Text = "No";
      else
        e.Item.Cells[8].Text = "Si";
    }

    public void imageButton_Click(object sender, CommandEventArgs e)
    {
      this.Context.Items.Add((object) "var_afm_dwgs_dwg_name", (object) (string) e.CommandArgument);
      this.Server.Transfer("VisualDWF.aspx");
    }
  }
}
