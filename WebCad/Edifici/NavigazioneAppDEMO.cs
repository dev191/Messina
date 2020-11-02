// Decompiled with JetBrains decompiler
// Type: WebCad.Edifici.NavigazioneAppDEMO
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebCad.Classi;
using WebCad.MyCollection;
using WebCad.WebControls;

namespace WebCad.Edifici
{
  public class NavigazioneAppDEMO : Page
  {
    protected DataGrid MyDataGrid1;
    protected GridTitle GridTitle1;
    protected PageTitle PageTitle1;
    public static int FunId = 0;
    public static string HelpLink = string.Empty;
    public int s_stanza;
    public int s_bl_id;
    public int s_piani;
    public string TitoloPiano;
    public string TitoloStanza;
    private DataRoom _fp;
    private clMyCollection _myColl = new clMyCollection();
    private S_ControlsCollection _SCollection = new S_ControlsCollection();
    protected Button BntIndietro;
    private WebCad.Classi.AnagrafeImpianti.DataRoom _DataRoom = new WebCad.Classi.AnagrafeImpianti.DataRoom();

    public clMyCollection _Contenitore => this.ViewState["mioContenitore"] != null ? (clMyCollection) this.ViewState["mioContenitore"] : new clMyCollection();

    private void Page_Load(object sender, EventArgs e)
    {
      SiteModule siteModule = (SiteModule) HttpContext.Current.Items[(object) "SiteModule"];
      this.s_bl_id = int.Parse(this.Request["var_bl_id"]);
      this.s_piani = int.Parse(this.Request["var_piani"]);
      if (this.Request["var_stanza"] == null || this.Request["var_stanza"] == "" || this.Request["var_stanza"] == string.Empty)
      {
        this.s_stanza = 0;
        this.TitoloPiano = this.Request["TitoloPiano"].ToString();
        this.PageTitle1.Title = "Apparecchiature del Piano " + this.TitoloPiano;
      }
      else
      {
        this.s_stanza = int.Parse(this.Request["var_stanza"]);
        this.TitoloStanza = this.Request["TitoloStanza"].ToString();
        this.PageTitle1.Title = "Apparecchiature della Stanza " + this.TitoloStanza;
      }
      if (!this.IsPostBack)
      {
        this.Execute();
        this.GridTitle1.Visible = false;
        if (this.Context.Handler is DataRoom)
        {
          this._fp = (DataRoom) this.Context.Handler;
          this.ViewState.Add("mioContenitore", (object) this._fp._Contenitore);
        }
      }
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.MyDataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged);
      this.BntIndietro.Click += new EventHandler(this.BntIndietro_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void setvisiblecontrol(bool Visibile)
    {
      this.GridTitle1.VisibleRecord = Visibile;
      ((Control) this.GridTitle1.hplsNuovo).Visible = false;
      this.MyDataGrid1.Visible = Visibile;
    }

    private void Execute()
    {
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_Id_bl");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(50);
      ((ParameterObject) sObject1).set_Index(0);
      ((ParameterObject) sObject1).set_Value((object) this.s_bl_id);
      this._SCollection.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_piani");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(20);
      ((ParameterObject) sObject2).set_Index(1);
      ((ParameterObject) sObject2).set_Value((object) this.s_piani);
      this._SCollection.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_stanza");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Size(20);
      ((ParameterObject) sObject3).set_Index(2);
      ((ParameterObject) sObject3).set_Value((object) this.s_stanza);
      this._SCollection.Add(sObject3);
      DataSet dataSet = this._DataRoom.RicercaApparecchiaturaPerStanza(this._SCollection);
      this.GridTitle1.Visible = true;
      if (dataSet.Tables[0].Rows.Count > 0)
      {
        this.setvisiblecontrol(true);
        this.GridTitle1.DescriptionTitle = "";
        this.GridTitle1.NumeroRecords = dataSet.Tables[0].Rows.Count.ToString();
        this.MyDataGrid1.DataSource = (object) dataSet.Tables[0];
        this.MyDataGrid1.DataBind();
      }
      else
      {
        this.GridTitle1.DescriptionTitle = "Nessun dato trovato.";
        this.setvisiblecontrol(false);
        this.GridTitle1.Visible = true;
      }
    }

    private void MyDataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      this.MyDataGrid1.CurrentPageIndex = e.NewPageIndex;
      this.Execute();
    }

    private void BntIndietro_Click(object sender, EventArgs e) => this.Server.Transfer("DataRoom.aspx?FunId=" + (object) NavigazioneAppDEMO.FunId);
  }
}
