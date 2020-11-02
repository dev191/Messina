// Decompiled with JetBrains decompiler
// Type: WebCad.WebControls.CodiceStdApparecchiatura
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebCad.WebControls
{
  public class CodiceStdApparecchiatura : UserControl
  {
    protected S_TextBox S_txtcodStdapparecchiatura;
    protected HtmlInputHidden hidCodStd;

    private void Page_Load(object sender, EventArgs e) => this.ShowFrame2(1);

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    private void ShowFrame2(int NumDirectory)
    {
      string str = "";
      for (int index = 0; index < NumDirectory; ++index)
        str += "../";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<script language=\"javascript\">\n");
      stringBuilder.Append("function ShowFrame2(sender,e){\n");
      stringBuilder.Append("var ctrl = document.getElementById(\"PopupApp\").style;\n");
      stringBuilder.Append("x = e.clientX;\n");
      stringBuilder.Append("y = e.clientY;\n");
      stringBuilder.Append("ctrl.left = 50;\n");
      stringBuilder.Append("ctrl.top = y+30;\n");
      stringBuilder.Append("if (ctrl.display =='none') ctrl.display='block';\n");
      stringBuilder.Append("ctrl2= document.getElementById(\"" + ((Control) this.S_txtcodStdapparecchiatura).ClientID + "\").value;\n");
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
      if (this.NameComboServizio != "")
      {
        DropDownList control = (DropDownList) this.Page.FindControl(this.NameComboServizio);
        if (control != null)
        {
          stringBuilder.Append("var val1=\"&servizioid=\";\n");
          stringBuilder.Append("var ctrl5= document.getElementById(\"" + control.ClientID + "\");\n");
          stringBuilder.Append("if (ctrl5!=\"undefined\" && ctrl5!=null){\n");
          stringBuilder.Append("    if (ctrl5.selectedIndex!=-1) val1+=ctrl5.options[ctrl5.selectedIndex].value;\n");
          stringBuilder.Append("}\n");
          stringBuilder.Append("ctrl2+=val1;\n");
        }
      }
      stringBuilder.Append("var idUsercontrol=\"&idUsercontrol=\" + \"" + this.ClientID + "\";\n");
      stringBuilder.Append("document.getElementById(\"docapp\").src=\"" + str + "CommonPage/ListaStdApparecchiature.aspx?codapp=\" + ctrl2 + idUsercontrol;\n");
      stringBuilder.Append("}\n");
      stringBuilder.Append("</script>\n");
      this.Page.RegisterStartupScript("startsc", stringBuilder.ToString());
    }

    public string NameUserControlRicercaModulo
    {
      get => this.ViewState["s_NameUserControlRicercaModulo"] == null ? string.Empty : (string) this.ViewState["s_NameUserControlRicercaModulo"];
      set => this.ViewState["s_NameUserControlRicercaModulo"] = (object) value;
    }

    public string NameComboServizio
    {
      get => this.ViewState["s_NameComboServizio"] == null ? string.Empty : (string) this.ViewState["s_NameComboServizio"];
      set => this.ViewState["s_NameComboServizio"] = (object) value;
    }

    public string CodiceStd
    {
      get => ((TextBox) this.S_txtcodStdapparecchiatura).Text.Length > 0 ? ((TextBox) this.S_txtcodStdapparecchiatura).Text : string.Empty;
      set => ((TextBox) this.S_txtcodStdapparecchiatura).Text = value;
    }

    public HtmlInputHidden CodiceHidden => this.hidCodStd;

    public S_TextBox s_CodiceStdApparecchiatura => this.S_txtcodStdapparecchiatura;
  }
}
