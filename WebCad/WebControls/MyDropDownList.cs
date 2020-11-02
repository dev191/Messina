// Decompiled with JetBrains decompiler
// Type: WebCad.WebControls.MyDropDownList
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCad.WebControls
{
  public class MyDropDownList : UserControl
  {
    protected DropDownList DropDownList1;
    protected Label Label1;

    private void Page_Load(object sender, EventArgs e)
    {
    }

    public void SetDataSet(string nomeCampoDati, DataSet ds) => this.SetDataSet(nomeCampoDati, nomeCampoDati, "", ds);

    public void SetDataSet(string nomeCampoDati, string valoreCampoDati, DataSet ds) => this.SetDataSet(nomeCampoDati, valoreCampoDati, "", ds);

    public void SetDataSet(string nomeCampoDati, string valoreCampoDati, string primo, DataSet ds)
    {
      ds.GetXml();
      this.DropDownList1.DataTextField = nomeCampoDati;
      this.DropDownList1.DataValueField = valoreCampoDati;
      this.DropDownList1.DataSource = (object) ds;
      this.DropDownList1.DataBind();
      if (primo != "")
        this.DropDownList1.Items.Insert(0, new ListItem(primo, ""));
      if (this.DropDownList1.Items.Count <= 0)
        return;
      this.DropDownList1.SelectedIndex = 0;
    }

    public bool isPopolated() => this.DropDownList1.Items.Count != 0;

    public void SetLabel(string testo) => this.Label1.Text = testo;

    public string getTesto() => this.DropDownList1.SelectedValue;

    public string getClientID() => this.DropDownList1.ClientID;

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
