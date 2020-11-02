// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.SfogliaRdlOdl_MP
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using MyCollection;
using System;
using System.Data;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi.ManProgrammata;
using TheSite.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class SfogliaRdlOdl_MP : Page
  {
    protected DataGrid DataGrid1;
    protected DataGrid DataGrid2;
    protected Button btIndietro;
    protected GridTitle GridTitle1;

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      PropertyInfo property = this.Context.Handler.GetType().GetProperty("_Contenitore");
      if (property != null)
        this.ViewState.Add("mioContenitore", property.GetValue((object) this.Context.Handler, (object[]) null));
      if (this.Context.Items[(object) "wo_id"] == null)
        return;
      this.wo_id = (string) this.Context.Items[(object) "wo_id"];
      this.executeDatiGenerali();
      this.execute();
    }

    private string wo_id
    {
      get => this.ViewState[nameof (wo_id)] != null ? (string) this.ViewState[nameof (wo_id)] : string.Empty;
      set => this.ViewState.Add(nameof (wo_id), (object) value);
    }

    private void executeDatiGenerali()
    {
      DataSet singleRdl = new SfogliaRdlOdl(this.Context.User.Identity.Name).GetSingleRdl(int.Parse(this.wo_id));
      if (singleRdl.Tables[0].Rows.Count > 0)
      {
        this.DataGrid1.DataSource = (object) singleRdl.Tables[0];
        this.DataGrid1.DataBind();
        this.DataGrid1.Visible = true;
      }
      else
        this.DataGrid1.Visible = false;
    }

    private void execute()
    {
      DataSet dettailSingleRdl = new SfogliaRdlOdl(this.Context.User.Identity.Name).GetDettailSingleRdl(int.Parse(this.wo_id));
      if (dettailSingleRdl.Tables[0].Rows.Count > 0)
      {
        this.GridTitle1.Visible = true;
        ((Control) this.GridTitle1.hplsNuovo).Visible = false;
        this.GridTitle1.NumeroRecords = dettailSingleRdl.Tables[0].Rows.Count.ToString();
        this.DataGrid2.DataSource = (object) dettailSingleRdl.Tables[0];
        this.DataGrid2.DataBind();
        this.DataGrid2.Visible = true;
      }
      else
      {
        this.GridTitle1.Visible = false;
        this.DataGrid2.Visible = false;
      }
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.DataGrid2.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGrid2_PageIndexChanged);
      this.btIndietro.Click += new EventHandler(this.btIndietro_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void DataGrid2_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.DataGrid2.CurrentPageIndex = e.NewPageIndex;
      this.execute();
    }

    private void btIndietro_Click(object sender, EventArgs e) => this.Server.Transfer("SfogliaOdlRdl.aspx");

    public void lk_Command(object sender, CommandEventArgs e)
    {
      this.Context.Items.Add((object) "wo_id", e.CommandArgument);
      this.Server.Transfer("Completamento_MP_WRList.aspx");
    }
  }
}
