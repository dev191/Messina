// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneCorretiva.RapportoTecnicoIntervento
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheSite.Classi.ManOrdinaria;
using TheSite.WebControls;

namespace TheSite.ManutenzioneCorretiva
{
  public class RapportoTecnicoIntervento : Page
  {
    protected S_Label S_lblbuonolavoro;
    protected Repeater repeater1;
    protected S_Label S_Lblditta;
    protected PageTitle PageTitle1;
    protected HtmlTableRow TRAnnotazioniVal;
    protected HtmlTableRow TRAnnotazioniNoVal;
    public string WO_Id = string.Empty;
    public string image = "../Images/3.jpg";
    public string descprog = "";
    public string evaluta;

    private void Page_Load(object sender, EventArgs e)
    {
      this.PageTitle1.VisibleLogut = false;
      if (this.IsPostBack || this.Request.QueryString["WO_Id"] == null)
        return;
      this.WO_Id = this.Request.QueryString["WO_Id"];
      this.Execute();
    }

    private void Execute()
    {
      DataSet singleData = new RichiestaIntervento(this.Context.User.Identity.Name).GetSingleData(int.Parse(this.WO_Id));
      if (singleData.Tables[0].Rows[0]["id_progetto"].ToString() == "1")
      {
        this.image = "../Images/Martino_logo.gif";
        this.descprog = "Martino";
      }
      else
      {
        this.image = "../Images/papardo_logo.gif";
        this.descprog = "Papardo";
      }
      this.repeater1.DataSource = (object) singleData;
      this.repeater1.DataBind();
    }

    public string EvalBool(object obj, bool val) => obj == null || obj == DBNull.Value || obj.ToString() == "" ? (!val ? "visibility: none" : "visibility: hidden") : (val ? "visibility: none" : "visibility: hidden");

    public string EvalField(object obj, int Line) => obj == null || obj == DBNull.Value ? string.Empty.PadLeft(Line, Convert.ToChar("_")) : obj.ToString();

    public string Chk(string Sodd, string val)
    {
      string str = "";
      if (Sodd == val)
        str = "checked ";
      return str;
    }

    public string GetStringData(object Data, string Tipo)
    {
      string str = "";
      if (Tipo == nameof (Data))
      {
        if (Data.ToString() != "")
          str = DateTime.Parse(Data.ToString()).ToShortDateString();
      }
      else if (Data.ToString() != "")
        str = DateTime.Parse(Data.ToString()).ToShortTimeString();
      return str;
    }

    public string FormateDate(object obj) => obj == null || obj == DBNull.Value || obj.ToString() == "" ? "_____/_____/_____" : DateTime.Parse(obj.ToString()).ToShortDateString();

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.repeater1.ItemCommand += new RepeaterCommandEventHandler(this.repeater1_ItemCommand);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
    }
  }
}
