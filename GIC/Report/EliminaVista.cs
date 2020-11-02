// Decompiled with JetBrains decompiler
// Type: TheSite.GIC.Report.EliminaVista
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheSite.GIC.Report
{
  public class EliminaVista : Page
  {
    protected Label lblOperazione;
    protected Label lblNomeVista;
    protected RequiredFieldValidator rfvCodMat;
    protected TextBox txtNomeVista;
    protected Label lblDescrtizione;
    protected RequiredFieldValidator rfvDescrizione;
    protected TextBox txtDescrizione;
    protected Panel PanelEdit;
    protected Button btnElimina;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected ValidationSummary vlsEdit;
    protected string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];
    protected int IdVista;

    private void Page_Load(object sender, EventArgs e)
    {
      this.IdVista = Convert.ToInt32(this.Request.QueryString["IdVista"].ToString());
      if (this.IsPostBack)
        return;
      this.btnElimina.Attributes.Add("onclick", "return confirm('Si vuole effettuare la cancellazione?')");
      this.txtNomeVista.Text = this.Request.QueryString["NomeVista"].ToString();
      this.txtDescrizione.Text = this.Request.QueryString["Descrizione"].ToString();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.btnElimina.Click += new EventHandler(this.btnElimina_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void btnElimina_Click(object sender, EventArgs e)
    {
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("pid");
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject).set_Size(32);
      ((ParameterObject) sObject).set_Index(0);
      ((ParameterObject) sObject).set_Value((object) this.IdVista);
      controlsCollection.Add(sObject);
      oracleDataLayer.GetRowsAffected((object) controlsCollection, "IL_PACK_INTERROGAZIONI.EliminaVista");
      this.Server.Transfer("SelectSchema.aspx");
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("SelectSchema.aspx");
  }
}
