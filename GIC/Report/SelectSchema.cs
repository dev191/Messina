// Decompiled with JetBrains decompiler
// Type: TheSite.GIC.Report.SelectSchema
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.GIC.Classi;
using TheSite.WebControls;

namespace TheSite.GIC.Report
{
  public class SelectSchema : Page
  {
    protected DataGrid DatagridVista;
    protected string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];
    protected Panel pnlShowInfo;
    protected DataGrid DatagridGlossario;
    protected LinkButton lnkChiudi;
    protected Label lblDettaglioVista;
    protected PageTitle PageTitle1;
    protected GridTitle Gridtitle2;
    protected GridTitleServer GridTitleServer1;
    protected HtmlInputHidden txtNomeVista;
    protected HtmlInputHidden txtIdVista;
    public static int FunId = 0;

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      this.PageTitle1.Title = siteModule.ModuleTitle;
      SelectSchema.FunId = siteModule.ModuleId;
      ((Control) this.Gridtitle2.hplsNuovo).Visible = false;
      this.GridTitleServer1.hplsNuovo.Visible = this.Context.User.IsInRole("amministratori");
      if (this.IsPostBack)
        return;
      this.Carica();
    }

    private void Carica()
    {
      DataTable dataTable = this.DataViste();
      this.DatagridVista.DataSource = (object) dataTable;
      this.DatagridVista.DataBind();
      this.GridTitleServer1.NumeroRecords = dataTable.Rows.Count.ToString();
    }

    private DataTable DataViste()
    {
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("io_cursor");
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject).set_Index(1);
      controlsCollection.Add(sObject);
      return oracleDataLayer.ExecuteProcedure((object) controlsCollection, "IL_PACK_INTERROGAZIONI.GetSchemaViste").Tables[0];
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.DatagridVista.ItemDataBound += new DataGridItemEventHandler(this.ItemDataBound_ItemDataBound);
      this.lnkChiudi.Click += new EventHandler(this.lnkChiudi_Click);
      this.GridTitleServer1.hplsNuovo.Click += new EventHandler(this.Nuovo_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    protected void imgBtnVisualizza_Click(object sender, CommandEventArgs e)
    {
      string[] strArray = Convert.ToString(e.CommandArgument).Split(Convert.ToChar("-"));
      int int32 = Convert.ToInt32(strArray[0].ToString());
      string str = strArray[1].ToString();
      Hashtable hashtable = new Hashtable();
      hashtable.Add((object) "IdVista", (object) int32);
      hashtable.Add((object) "NomeVista", (object) str);
      this.Session.Remove("ParametriSelectSchema");
      this.Session.Add("ParametriSelectSchema", (object) hashtable);
      this.Server.Transfer("DefaultReport.aspx");
    }

    protected void imgBtnDettaglioGlossario_Click(object sender, CommandEventArgs e)
    {
      string[] strArray = Convert.ToString(e.CommandArgument).Split(Convert.ToChar("-"));
      int int32 = Convert.ToInt32(strArray[0].ToString());
      string str = strArray[1].ToString();
      if (int32 == Convert.ToInt32(this.txtIdVista.Value))
        this.pnlShowInfo.Visible = !this.pnlShowInfo.Visible;
      else
        this.pnlShowInfo.Visible = true;
      this.txtNomeVista.Value = str;
      this.txtIdVista.Value = int32.ToString();
      this.lblDettaglioVista.Text = " Dettaglio dei campi della vista " + str;
      DataTable dataTable = this.DataGlossario(int32);
      this.DatagridGlossario.DataSource = (object) dataTable;
      this.DatagridGlossario.DataBind();
      this.Gridtitle2.NumeroRecords = dataTable.Rows.Count.ToString();
    }

    private DataTable DataGlossario(int IdVista)
    {
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pIdVista");
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Size(32);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) IdVista);
      controlsCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("io_cursor");
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 8);
      ((ParameterObject) sObject2).set_Index(1);
      controlsCollection.Add(sObject2);
      return oracleDataLayer.ExecuteProcedure((object) controlsCollection, "IL_PACK_INTERROGAZIONI.GetDettaglioGlossario").Tables[0];
    }

    private void lnkChiudi_Click(object sender, EventArgs e) => this.pnlShowInfo.Visible = false;

    protected void Nuovo_Click(object sender, EventArgs e) => this.Server.Transfer("NuovoSchema.aspx");

    protected void imgBtnElimina_Click(object sender, CommandEventArgs e)
    {
      string[] strArray = Convert.ToString(e.CommandArgument).Split(Convert.ToChar("-"));
      this.Server.Transfer("EliminaVista.aspx?IdVista=" + (object) Convert.ToInt32(strArray[0].ToString()) + "&NomeVista=" + strArray[1].ToString() + "&Descrizione=" + strArray[2].ToString());
    }

    protected void btnAquisisci_Click(object sender, CommandEventArgs e)
    {
      string[] strArray = Convert.ToString(e.CommandArgument).Split(Convert.ToChar("-"));
      int int32 = Convert.ToInt32(strArray[0].ToString());
      this.StartParsingVista(strArray[1].ToString(), int32);
      this.Carica();
    }

    private void StartParsingVista(string NomeVista, int IdVista) => new ParsingViste().MakeParsing(NomeVista, IdVista);

    private void ItemDataBound_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
        return;
      Button control1 = (Button) e.Item.FindControl("btnAquisisci");
      ImageButton control2 = (ImageButton) e.Item.FindControl("imgBtnVisualizza");
      ImageButton control3 = (ImageButton) e.Item.FindControl("imgBtnDettaglioGlossario");
      ImageButton control4 = (ImageButton) e.Item.FindControl("imgBtnElimina");
      if (this.Context.User.IsInRole("amministratori"))
      {
        control1.Attributes.Add("onclick", "return confirm('Si vuole procedere?')");
        if (Convert.ToInt32(e.Item.Cells[4].Text) == 0)
        {
          control1.Text = "Acquisisci la vista";
          control2.Visible = false;
          control3.Visible = false;
        }
        else
        {
          control1.Text = "Vista già acquisita";
          control1.Enabled = false;
          control2.Visible = true;
          control3.Visible = true;
        }
      }
      else
      {
        control3.Visible = false;
        control4.Visible = false;
        control1.Visible = false;
      }
    }
  }
}
