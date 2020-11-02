// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.Associazione_EQ_PMS
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheSite.Classi;
using TheSite.Classi.ManProgrammata;

namespace TheSite.ManutenzioneProgrammata
{
  public class Associazione_EQ_PMS : Page
  {
    protected S_Button cmdAssocia;
    public string TotEQ = "";
    public string p_totEQSTDinEQ = "";
    public string p_totEQinPMS = "";
    public string p_totEQnoPMS = "";
    public string p_totEQSTDinPMP = "";
    public string p_totEQSTDEQinPMP = "";
    public string p_totEQSTD = "";

    private void Page_Load(object sender, EventArgs e)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("this.value = 'Attendere ...';");
      stringBuilder.Append("this.disabled = true;");
      stringBuilder.Append("document.getElementById('" + ((Control) this.cmdAssocia).ClientID + "').disabled = true;");
      stringBuilder.Append(this.Page.GetPostBackEventReference((Control) this.cmdAssocia));
      stringBuilder.Append(";");
      ((WebControl) this.cmdAssocia).Attributes.Add("onclick", stringBuilder.ToString());
      if (this.Page.IsPostBack)
        return;
      this.Conta();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      ((Button) this.cmdAssocia).Click += new EventHandler(this.cmdAssocia_Click);
      this.Load += new EventHandler(this.Page_Load);
    }

    private void cmdAssocia_Click(object sender, EventArgs e)
    {
      SiteJavaScript.msgBox(this.Page, string.Format("ASSOCIAZIONI GENERATE PER APPARECCHIATURE NEL PIANO DI MANUTENZIONE STANDARD N. {0} ", (object) new AssEQ_PMS().Associa()));
      this.Conta();
    }

    private void Conta()
    {
      string[] strArray = new string[7];
      string[] valueParametri = new AssEQ_PMS().GetValueParametri();
      this.TotEQ = valueParametri[0].ToString();
      this.p_totEQSTDinEQ = valueParametri[1].ToString();
      this.p_totEQinPMS = valueParametri[2].ToString();
      this.p_totEQnoPMS = valueParametri[3].ToString();
      this.p_totEQSTDinPMP = valueParametri[4].ToString();
      this.p_totEQSTDEQinPMP = valueParametri[5].ToString();
      this.p_totEQSTD = valueParametri[6].ToString();
    }
  }
}
