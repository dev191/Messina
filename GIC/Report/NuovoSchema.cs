// Decompiled with JetBrains decompiler
// Type: TheSite.GIC.Report.NuovoSchema
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
  public class NuovoSchema : Page
  {
    protected Label lblOperazione;
    protected RequiredFieldValidator rfvCodMat;
    protected RequiredFieldValidator rfvDescrizione;
    protected Panel PanelEdit;
    protected Button btnAnnulla;
    protected Label lblFirstAndLast;
    protected Button Button1;
    protected TextBox txtNomeVista;
    protected Label lblDescrtizione;
    protected TextBox txtDescrizione;
    protected Label lblNomeVista;
    protected ValidationSummary vlsEdit;
    protected string s_ConnStr = ConfigurationSettings.AppSettings["ConnectionString"];

    private void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.Button1.Click += new EventHandler(this.Button1_Click);
      this.btnAnnulla.Click += new EventHandler(this.btnAnnulla_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      this.SalvaVista();
      this.Server.Transfer("SelectSchema.aspx");
    }

    private void SalvaVista()
    {
      int num1 = 0;
      OracleDataLayer oracleDataLayer = new OracleDataLayer(this.s_ConnStr);
      S_ControlsCollection controlsCollection = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("pNomeVista");
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Size(64);
      S_Object sObject2 = sObject1;
      int num2 = num1;
      int num3 = num2 + 1;
      ((ParameterObject) sObject2).set_Index(num2);
      ((ParameterObject) sObject1).set_Value((object) this.txtNomeVista.Text);
      controlsCollection.Add(sObject1);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("pDescrizione");
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Size(256);
      S_Object sObject4 = sObject3;
      int num4 = num3;
      int num5 = num4 + 1;
      ((ParameterObject) sObject4).set_Index(num4);
      ((ParameterObject) sObject3).set_Value((object) this.txtDescrizione.Text);
      controlsCollection.Add(sObject3);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("pOut");
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Output);
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Size(32);
      S_Object sObject6 = sObject5;
      int num6 = num5;
      int num7 = num6 + 1;
      ((ParameterObject) sObject6).set_Index(num6);
      controlsCollection.Add(sObject5);
      oracleDataLayer.GetRowsAffected((object) controlsCollection, "IL_PACK_INTERROGAZIONI.SalvaVista");
    }

    private void btnAnnulla_Click(object sender, EventArgs e) => this.Server.Transfer("SelectSchema.aspx");
  }
}
