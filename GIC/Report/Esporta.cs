// Decompiled with JetBrains decompiler
// Type: TheSite.GIC.Report.Esporta
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using Csy.WebControls;
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using TheSite.GIC.App_Code.Consultazioni;

namespace TheSite.GIC.Report
{
  public class Esporta : Page
  {
    private int IdQ;

    private void Page_Load(object sender, EventArgs e)
    {
      this.IdQuery = Convert.ToInt32(this.Request.QueryString["idquery"]);
      this.Esport();
    }

    public int IdQuery
    {
      get => this.IdQ;
      set => this.IdQ = value;
    }

    public void Esport()
    {
      Hashtable hashtable = (Hashtable) this.Session["ParametriSelectSchema"];
      string str1 = Convert.ToString(hashtable[(object) "NomeVista"]);
      int int32 = Convert.ToInt32(hashtable[(object) "IdVista"]);
      string str2 = " " + str1 + " ";
      DataSet data = new interogazioni()
      {
        VISTA = str2,
        IdVista = int32
      }.GetData(this.IdQ);
      Export export = new Export();
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = data.Tables[0].Copy();
      if (dataTable2.Rows.Count != 0)
      {
        export.ExportDetails(dataTable2, (Export.ExportFormat) 2, "exp.xls");
      }
      else
      {
        string script = "<script language=JavaScript>alert('Nessun elemento da esportare');" + "/" + "script>";
        if (this.IsClientScriptBlockRegistered("clientScriptexp"))
          return;
        this.RegisterStartupScript("clientScriptexp", script);
      }
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
