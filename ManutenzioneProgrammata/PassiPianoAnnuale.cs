// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.PassiPianoAnnuale
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi.ManOrdinaria;
using TheSite.Classi.ManProgrammata;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class PassiPianoAnnuale : Page
  {
    protected Label lblpmp;
    protected TextBox txtAnno;
    protected DataGrid DataGridRicerca;
    protected TextBox txtEQ;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    protected S_Button btSalva;
    protected TextBox txtId_bl;
    protected TextBox txtbl_id;
    private DataSet _MyDs = new DataSet();
    private DataTable DtAddetti;

    private string e_Page
    {
      get => this.ViewState[nameof (e_Page)] != null ? (string) this.ViewState[nameof (e_Page)] : "";
      set => this.ViewState[nameof (e_Page)] = (object) value;
    }

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.Page.IsPostBack)
        return;
      this.PageTitle1.VisibleLogut = false;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.txtAnno.Text = this.Request.Params["anno"];
      this.txtEQ.Text = this.Request.Params["EQ_ID"];
      this.e_Page = this.Request.QueryString["p"];
      this.txtId_bl.Text = this.Request.Params["id_bl"];
      this.txtbl_id.Text = this.Request.Params["bl_id"];
      this.Session.Remove("DatiListP");
      if (this.e_Page != "ottimizza")
        ((Control) this.btSalva).Visible = false;
      else
        this.PageTitle1.Title = "OTTIMIZZA IL PIANO";
      this.lblpmp.Text = "Piano Manutenzione Programmata Apparecchiatura: " + this.txtEQ.Text + " - Anno: " + this.txtAnno.Text;
      this.DtAddetti = this.BindAddettiDitta(this.txtbl_id.Text, "");
      this.GetDataGrid();
    }

    private void GetDataGrid()
    {
      Planner planner = new Planner();
      ProcAndSteps procAndSteps = new ProcAndSteps();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_EQ_ID");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) this.txtEQ.Text);
      ((ParameterObject) sObject1).set_Size(50);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_Anno");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) this.txtAnno.Text);
      ((ParameterObject) sObject2).set_Size(4);
      CollezioneControlli.Add(sObject2);
      this._MyDs = planner.GetPassiPianoDett(CollezioneControlli).Copy();
      if (this.e_Page != "ottimizza")
      {
        this._MyDs.Tables.Add(procAndSteps.GetIstruzioni().Tables["ISTRUZIONI"].Copy());
        this.DataGridRicerca.Columns[6].Visible = false;
      }
      else
        this.DataGridRicerca.Columns[4].Visible = false;
      this.DataGridRicerca.DataSource = (object) this._MyDs.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = this._MyDs.Tables[0].Rows.Count.ToString();
    }

    private DataTable BindAddettiDitta(string bl_id, string nomecompleto) => new Richiesta().GetAddetti(nomecompleto, bl_id).Tables[0];

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      ((Button) this.btSalva).Click += new EventHandler(this.btSalva_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      DataRowView dataItem = (DataRowView) e.Item.DataItem;
      if (this.e_Page == "ottimizza")
      {
        this.SetControl(true, dataItem, e);
        DropDownList control = (DropDownList) e.Item.Cells[6].Controls[1];
        foreach (DataRow row in (InternalDataCollectionBase) this.DtAddetti.Rows)
          control.Items.Add(new ListItem(row["nome"].ToString() + " " + row["cognome"].ToString(), row["ID"].ToString()));
        control.SelectedValue = dataItem.Row["ADDETTO_ID"].ToString();
      }
      else
      {
        this.SetControl(false, dataItem, e);
        e.Item.Cells[3].Text = Convert.ToDateTime(dataItem.Row["DATA"].ToString()).ToShortDateString();
        DataGrid dataGrid = new DataGrid();
        dataGrid.CssClass = "DataGrid";
        dataGrid.BorderWidth = (Unit) 0;
        dataGrid.GridLines = GridLines.Vertical;
        dataGrid.BorderColor = Color.FromName("Gray");
        dataGrid.AlternatingItemStyle.CssClass = "DataGridAlternatingItemStyle";
        dataGrid.ItemStyle.CssClass = "DataGridItemStyle";
        dataGrid.ItemStyle.VerticalAlign = VerticalAlign.Top;
        dataGrid.Width = Unit.Percentage(100.0);
        dataGrid.AutoGenerateColumns = false;
        dataGrid.ShowHeader = false;
        BoundColumn boundColumn = new BoundColumn();
        boundColumn.DataField = "ISTRUZIONI";
        boundColumn.ItemStyle.Wrap = true;
        dataGrid.Columns.Add((DataGridColumn) boundColumn);
        DataView defaultView = this._MyDs.Tables[1].DefaultView;
        defaultView.RowFilter = "ID='" + e.Item.Cells[0].Text + "'";
        dataGrid.DataSource = (object) defaultView;
        dataGrid.DataBind();
        dataGrid.Visible = true;
        e.Item.Cells[4].Controls.Add((Control) dataGrid);
      }
    }

    private void SetControl(bool visiblecontrol, DataRowView drv, DataGridItemEventArgs e)
    {
      UserMeseGiorno control = (UserMeseGiorno) e.Item.Cells[3].FindControl("UserMeseGiorno1");
      if (!visiblecontrol)
      {
        control.Visible = false;
      }
      else
      {
        string str1 = "ImpostaGiorni(this.value,'" + ((Control) control.cmbGiorni).ClientID + "')";
        ((WebControl) control.cmbMesi).Attributes.Add("onchange", str1);
        if (drv.Row["DATA"].ToString() != "")
        {
          DateTime dateTime = Convert.ToDateTime(drv.Row["DATA"].ToString());
          int num = dateTime.Month;
          string mese = num.ToString();
          num = dateTime.Day;
          string str2 = num.ToString();
          ((ListControl) control.cmbMesi).SelectedValue = mese;
          this.ImpostaGiorni(mese, control.cmbGiorni);
          ((ListControl) control.cmbGiorni).SelectedValue = str2;
        }
        else
          this.ImpostaGiorni(((ListControl) control.cmbMesi).SelectedValue, control.cmbGiorni);
      }
    }

    private void ImpostaGiorni(string mese, S_ComboBox Giorni)
    {
      int num;
      switch (mese)
      {
        case "4":
        case "6":
        case "9":
        case "11":
          num = 30;
          break;
        case "2":
          num = 28;
          break;
        default:
          num = 31;
          break;
      }
      ((ListControl) Giorni).Items.Clear();
      for (int index = 1; index <= num; ++index)
      {
        ListItem listItem = new ListItem(index.ToString(), index.ToString());
        ((ListControl) Giorni).Items.Add(listItem);
      }
    }

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      if (this.e_Page == "ottimizza")
      {
        this.SaveDati(this.DataGridRicerca);
        this.DtAddetti = this.BindAddettiDitta(this.txtbl_id.Text, "");
      }
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.GetDataGrid();
      if (!(this.e_Page == "ottimizza"))
        return;
      this.GetDati(this.DataGridRicerca);
    }

    private void SaveDati(DataGrid Ctrl)
    {
      Hashtable hashtable = this.Session["DatiListP"] == null ? new Hashtable() : (Hashtable) this.Session["DatiListP"];
      foreach (DataGridItem dataGridItem in Ctrl.Items)
      {
        string text = dataGridItem.Cells[5].Text;
        if (hashtable.ContainsKey((object) text))
          hashtable.Remove((object) text);
        if (this.e_Page == "ottimizza")
        {
          DettailList dettailList = new DettailList();
          UserMeseGiorno control = (UserMeseGiorno) dataGridItem.Cells[3].FindControl("UserMeseGiorno1");
          dettailList.id = text;
          dettailList.Mese = ((ListControl) control.cmbMesi).SelectedValue;
          dettailList.Giorno = ((ListControl) control.cmbGiorni).SelectedValue;
          hashtable.Add((object) dettailList.id, (object) dettailList);
        }
      }
      this.Session.Remove("DatiListP");
      this.Session.Add("DatiListP", (object) hashtable);
    }

    private void GetDati(DataGrid Ctrl)
    {
      if (this.Session["DatiListP"] == null)
        return;
      Hashtable hashtable = (Hashtable) this.Session["DatiListP"];
      foreach (DataGridItem dataGridItem in Ctrl.Items)
      {
        string text = dataGridItem.Cells[5].Text;
        if (hashtable.ContainsKey((object) text))
        {
          DettailList dettailList = (DettailList) hashtable[(object) text];
          UserMeseGiorno control = (UserMeseGiorno) dataGridItem.Cells[3].FindControl("UserMeseGiorno1");
          ((ListControl) control.cmbMesi).SelectedValue = dettailList.Mese;
          this.ImpostaGiorni(dettailList.Mese, control.cmbGiorni);
          ((ListControl) control.cmbGiorni).SelectedValue = dettailList.Giorno;
        }
      }
    }

    private void btSalva_Click(object sender, EventArgs e) => this.SaveDati(this.DataGridRicerca);
  }
}
