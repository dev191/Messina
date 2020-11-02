// Decompiled with JetBrains decompiler
// Type: WebCad.WebControls.CodiceApparecchiature
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebCad.Classi;

namespace WebCad.WebControls
{
  public class CodiceApparecchiature : UserControl
  {
    protected HtmlInputHidden hidCodEq;
    protected S_TextBox S_txtcodapparecchiatura;

    private void Page_Load(object sender, EventArgs e)
    {
      if (((TextBox) this.S_txtcodapparecchiatura).Text == "")
        this.hidCodEq.Value = "";
      this.ShowFrame2(1);
    }

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
      stringBuilder.Append("ctrl2= document.getElementById(\"" + ((Control) this.S_txtcodapparecchiatura).ClientID + "\").value;\n");
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
      if (this.NameComboApparecchiature != "")
      {
        DropDownList control = (DropDownList) this.Page.FindControl(this.NameComboApparecchiature);
        if (control != null)
        {
          stringBuilder.Append("var val2=\"&appaid=\";\n");
          stringBuilder.Append("var ctrl6= document.getElementById(\"" + control.ClientID + "\");\n");
          stringBuilder.Append("if (ctrl6!=\"undefined\" && ctrl6!=null){\n");
          stringBuilder.Append("    if (ctrl6.selectedIndex!=-1) val2+=ctrl6.options[ctrl6.selectedIndex].value;\n");
          stringBuilder.Append("}\n");
          stringBuilder.Append("ctrl2+=val2;\n");
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
      if (this.NameComboStanza != "")
      {
        DropDownList control = (DropDownList) this.Page.FindControl(this.NameComboStanza);
        if (control != null)
        {
          stringBuilder.Append("var val4=\"&stanza=\";\n");
          stringBuilder.Append("var ctrl8= document.getElementById(\"" + control.ClientID + "\");\n");
          stringBuilder.Append("if (ctrl8!=\"undefined\" && ctrl8!=null){\n");
          stringBuilder.Append("    if (ctrl8.selectedIndex!=-1) val4+=ctrl8.options[ctrl8.selectedIndex].value;\n");
          stringBuilder.Append("}\n");
          stringBuilder.Append("ctrl2+=val4;\n");
        }
      }
      stringBuilder.Append("ctrl2+='&dismissione=" + (object) this.Dismissione + "';\n");
      stringBuilder.Append("var idUsercontrol=\"&idUsercontrol=\" + \"" + this.ClientID + "\";\n");
      stringBuilder.Append("document.getElementById(\"docapp\").src=\"" + str + "CommonPage/ListaApparecchiature.aspx?codapp=\" + ctrl2 + idUsercontrol;\n");
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

    public string NameComboApparecchiature
    {
      get => this.ViewState["s_NameComboApparecchiature"] == null ? string.Empty : (string) this.ViewState["s_NameComboApparecchiature"];
      set => this.ViewState["s_NameComboApparecchiature"] = (object) value;
    }

    public string NameComboStanza
    {
      get => this.ViewState["s_NameComboStanza"] == null ? string.Empty : (string) this.ViewState["s_NameComboStanza"];
      set => this.ViewState["s_NameComboStanza"] = (object) value;
    }

    public string NameComboPiano
    {
      get => this.ViewState["s_NameComboPiano"] == null ? string.Empty : (string) this.ViewState["s_NameComboPiano"];
      set => this.ViewState["s_NameComboPiano"] = (object) value;
    }

    public string CodiceApparecchiatura
    {
      get => ((TextBox) this.S_txtcodapparecchiatura).Text.Length > 0 ? ((TextBox) this.S_txtcodapparecchiatura).Text : string.Empty;
      set => ((TextBox) this.S_txtcodapparecchiatura).Text = value;
    }

    public DismissioneType Dismissione
    {
      get => this.ViewState[nameof (Dismissione)] != null ? (DismissioneType) this.ViewState[nameof (Dismissione)] : DismissioneType.NO;
      set => this.ViewState.Add(nameof (Dismissione), (object) value);
    }

    public HtmlInputHidden CodiceHidden => this.hidCodEq;

    public S_TextBox s_CodiceApparecchiatura => this.S_txtcodapparecchiatura;

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
