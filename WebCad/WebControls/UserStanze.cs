// Decompiled with JetBrains decompiler
// Type: WebCad.WebControls.UserStanze
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCad.WebControls
{
  public class UserStanze : UserControl
  {
    protected TextBox TxtIdStanza;
    protected S_TextBox s_txtDescStanza;

    private void Page_Load(object sender, EventArgs e) => this.ShowFramest(1);

    private void ShowFramest(int NumDirectory)
    {
      string str = "";
      for (int index = 0; index < NumDirectory; ++index)
        str += "../";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<script language=\"javascript\">\n");
      stringBuilder.Append("function ShowFramest(sender,e){\n");
      stringBuilder.Append("var ctrl = document.getElementById(\"PopupAppst\").style;\n");
      stringBuilder.Append("x = e.clientX;\n");
      stringBuilder.Append("y = e.clientY;\n");
      stringBuilder.Append("ctrl.left = 50;\n");
      stringBuilder.Append("ctrl.top = y+30;\n");
      stringBuilder.Append("if (ctrl.display =='none') ctrl.display='block';\n");
      stringBuilder.Append("ctrl2= document.getElementById(\"" + ((Control) this.s_txtDescStanza).ClientID + "\").value;\n");
      if (this.NameUserControlRicercaModulo != "")
      {
        RicercaModulo control = (RicercaModulo) this.Page.FindControl(this.NameUserControlRicercaModulo);
        if (control != null)
        {
          stringBuilder.Append("var ctrl3=\"&blid=\" + document.getElementById(\"" + ((Control) control.TxtCodice).ClientID + "\").value;\n");
          stringBuilder.Append("var ctrl4=\"&campus=\" + document.getElementById(\"" + ((Control) control.TxtRicerca).ClientID + "\").value;\n");
          stringBuilder.Append("ctrl2+= ctrl3 + ctrl4;\n");
        }
      }
      if (this.NameLblId != "")
      {
        S_Label control = (S_Label) this.Page.FindControl(this.NameLblId);
        if (control != null)
        {
          stringBuilder.Append("var ctrl3=\"&blid=\" +  document.getElementById(\"" + ((Control) control).ClientID + "\").innerText;\n");
          stringBuilder.Append("var ctrl4=\"&campus=\" + document.getElementById(\"" + ((Control) control).ClientID + "\").innerText;\n");
          stringBuilder.Append("ctrl2+= ctrl3 + ctrl4;\n");
        }
      }
      if (this.NameComboPiano != "")
      {
        DropDownList control = (DropDownList) this.Page.FindControl(this.NameComboPiano);
        if (control != null)
        {
          stringBuilder.Append("var val3=\"&piano=\";\n");
          stringBuilder.Append("var ctrl7= document.getElementById(\"" + control.ClientID + "\");\n");
          stringBuilder.Append("if (ctrl7!=\"undefined\" && ctrl7!=null){\n");
          stringBuilder.Append("    if (ctrl7.selectedIndex!=-1) val3+=ctrl7.options[ctrl7.selectedIndex].value;\n");
          stringBuilder.Append("}\n");
          stringBuilder.Append("ctrl2+=val3;\n");
        }
      }
      stringBuilder.Append("var idUsercontrol1=\"&idUsercontrol1=\" + \"" + this.ClientID + "\";\n");
      stringBuilder.Append("document.getElementById(\"docstanza\").src=\"" + str + "CommonPage/ListaStanze.aspx?codstanza=\" + ctrl2 + idUsercontrol1;\n");
      stringBuilder.Append("}\n");
      stringBuilder.Append("</script>\n");
      this.Page.RegisterStartupScript("startst", stringBuilder.ToString());
    }

    public string NameUserControlRicercaModulo
    {
      get => this.ViewState["s_NameUserControlRicercaModulo"] == null ? string.Empty : (string) this.ViewState["s_NameUserControlRicercaModulo"];
      set => this.ViewState["s_NameUserControlRicercaModulo"] = (object) value;
    }

    public string NameComboPiano
    {
      get => this.ViewState["s_NameComboPiano"] == null ? string.Empty : (string) this.ViewState["s_NameComboPiano"];
      set => this.ViewState["s_NameComboPiano"] = (object) value;
    }

    public string DescStanza
    {
      get => ((TextBox) this.s_txtDescStanza).Text.Length > 0 ? ((TextBox) this.s_txtDescStanza).Text : string.Empty;
      set => ((TextBox) this.s_txtDescStanza).Text = value;
    }

    public string IdStanza
    {
      get => this.TxtIdStanza.Text.Length > 0 ? this.TxtIdStanza.Text : string.Empty;
      set => this.TxtIdStanza.Text = value;
    }

    public TextBox s_TxtIdStanza => this.TxtIdStanza;

    public TextBox s_TxtDescStanza => (TextBox) this.s_txtDescStanza;

    public string NameLblId
    {
      get => this.ViewState["s_NomeLblID"] == null ? string.Empty : (string) this.ViewState["s_NomeLblID"];
      set => this.ViewState["s_NomeLblID"] = (object) value;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
