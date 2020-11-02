// Decompiled with JetBrains decompiler
// Type: GIC.Report.UserControl.ConsultazioniDataGrid
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Collections;
using System.Web.UI.WebControls;
using TheSite.GIC.App_Code.Consultazioni;

namespace GIC.Report.UserControl
{
  public class ConsultazioniDataGrid : System.Web.UI.UserControl
  {
    protected DataGrid DataGridQuery;
    protected TextBox txtQuery;
    private int IdQ;

    private void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    public int IdQuery
    {
      get => this.IdQ;
      set => this.IdQ = value;
    }

    public void DysplayGrid()
    {
      Hashtable hashtable = (Hashtable) this.Session["ParametriSelectSchema"];
      string str1 = Convert.ToString(hashtable[(object) "NomeVista"]);
      int int32 = Convert.ToInt32(hashtable[(object) "IdVista"]);
      string str2 = " " + str1 + " ";
      this.DataGridQuery.DataSource = (object) new interogazioni()
      {
        VISTA = str2,
        IdVista = int32
      }.GetData(this.IdQ);
      this.DataGridQuery.DataBind();
    }
  }
}
