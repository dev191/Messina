// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.Schedula.OttimizzaPianoEQ
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using MyCollection;
using S_Controls.Collections;
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ManProgrammata;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata.Schedula
{
  public class OttimizzaPianoEQ : Page
  {
    protected Label lblpmp;
    protected TextBox txtAnno;
    protected TextBox txtID_BL;
    protected TextBox txtServizio;
    protected DataGrid DataGridRicerca;
    protected Button cmdIndietro;
    protected LinkButton lkbInfo;
    protected LinkButton lnkChiudi;
    protected Repeater rptFrequenze;
    protected Panel pnlShowInfo;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    private clMyCollection _myColl = new clMyCollection();
    private OttimizzaPiano _fp;

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private string e_Page
    {
      get => this.ViewState[nameof (e_Page)] != null ? (string) this.ViewState[nameof (e_Page)] : "";
      set => this.ViewState[nameof (e_Page)] = (object) value;
    }

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      if (this.Page.IsPostBack)
        return;
      this.txtAnno.Text = this.Request.QueryString["anno"];
      this.txtID_BL.Text = this.Request.QueryString["ID_BL"];
      this.txtServizio.Text = this.Request.QueryString["servizio"];
      this.e_Page = this.Request.QueryString["p"];
      this.lblpmp.Text = "Piano Manutenzione Programmata Anno: " + this.txtAnno.Text;
      this.GetDataGrid();
      if (!(this.Context.Handler is OttimizzaPiano))
        return;
      this._fp = (OttimizzaPiano) this.Context.Handler;
      this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.DataGridRicerca.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
      this.DataGridRicerca.ItemDataBound += new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
      this.cmdIndietro.Click += new EventHandler(this.cmdIndietro_Click);
      this.lkbInfo.Click += new EventHandler(this.lkbInfo_Click);
      this.lnkChiudi.Click += new EventHandler(this.lnkChiudi_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void GetDataGrid()
    {
      Planner planner = new Planner();
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_id_Bl");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) this.txtID_BL.Text);
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
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_ID_Servizio");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) this.txtServizio.Text);
      ((ParameterObject) sObject3).set_Size(50);
      CollezioneControlli.Add(sObject3);
      DataSet dataSet = planner.GetDataDett(CollezioneControlli).Copy();
      this.DataGridRicerca.DataSource = (object) dataSet.Tables[0];
      this.DataGridRicerca.DataBind();
      this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
    }

    private void lkbInfo_Click(object sender, EventArgs e)
    {
      Planner planner = new Planner();
      this.pnlShowInfo.Visible = true;
      this.rptFrequenze.DataSource = (object) planner.GetFrequenze();
      this.rptFrequenze.DataBind();
    }

    private void lnkChiudi_Click(object sender, EventArgs e) => this.pnlShowInfo.Visible = false;

    private void cmdIndietro_Click(object sender, EventArgs e) => this.Server.Transfer("OttimizzaPiano.aspx");

    private void DataGridRicerca_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGridRicerca.CurrentPageIndex = e.NewPageIndex;
      this.GetDataGrid();
    }

    public string Colora(int Mese)
    {
      string str;
      switch (Mese)
      {
        case 0:
          str = "ffffff";
          break;
        case 1:
          str = "808080";
          break;
        case 2:
          str = "00ff00";
          break;
        case 3:
          str = "008000";
          break;
        case 4:
          str = "0000ff";
          break;
        case 5:
          str = "000080";
          break;
        case 6:
          str = "c00000";
          break;
        default:
          str = "800000";
          break;
      }
      return str;
    }

    private void DataGridRicerca_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      ((HtmlAnchor) e.Item.Controls[1].Controls[1]).HRef = "javascript:UpdateDettaglio('" + e.Item.Cells[0].Text + "','" + e.Item.Cells[2].Text + "','" + this.txtAnno.Text + "','" + this.txtID_BL.Text + "','" + e.Item.Cells[17].Text + "')";
      if (e.Item.Cells[2].Text.Trim().Length > 20)
      {
        string str = e.Item.Cells[2].Text.Trim().Substring(0, 18) + "...";
        e.Item.Cells[2].ToolTip = e.Item.Cells[2].Text;
        e.Item.Cells[2].Text = str;
      }
      if (e.Item.Cells[3].Text.Trim().Length > 20)
      {
        string str = e.Item.Cells[3].Text.Trim().Substring(0, 18) + "...";
        e.Item.Cells[3].ToolTip = e.Item.Cells[3].Text;
        e.Item.Cells[3].Text = str;
      }
      if (e.Item.Cells[4].Text.Trim().Length > 10)
      {
        string str = e.Item.Cells[4].Text.Trim().Substring(0, 10) + "...";
        e.Item.Cells[4].ToolTip = e.Item.Cells[4].Text;
        e.Item.Cells[4].Text = str.ToUpper();
      }
      for (int index = 5; index <= 16; ++index)
      {
        string str = this.Colora((int) Convert.ToInt16(e.Item.Cells[index].Text));
        int int16_1 = (int) Convert.ToInt16(str.Substring(0, 2), 16);
        int int16_2 = (int) Convert.ToInt16(str.Substring(2, 2), 16);
        int int16_3 = (int) Convert.ToInt16(str.Substring(4, 2), 16);
        e.Item.Cells[index].BackColor = Color.FromArgb(int16_1, int16_2, int16_3);
        e.Item.Cells[index].BorderColor = Color.Black;
        e.Item.Cells[index].BorderWidth = (Unit) 1;
        e.Item.Cells[index].ForeColor = Color.Black;
      }
    }
  }
}
