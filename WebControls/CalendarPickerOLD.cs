// Decompiled with JetBrains decompiler
// Type: TheSite.WebControls.CalendarPickerOLD
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TheSite.WebControls
{
  public class CalendarPickerOLD : UserControl
  {
    protected S_TextBox S_TxtDatecalendar;
    protected HtmlGenericControl Popupdata;
    protected HtmlGenericControl docdata;
    public string idModuloCale = string.Empty;
    public string namediv = string.Empty;
    protected HtmlInputButton btCalendar;
    public string nameframe = string.Empty;
    public string namebutton = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      this.idModuloCale = this.ClientID;
      this.namediv = this.Popupdata.ClientID;
      this.nameframe = this.docdata.ClientID;
      this.namebutton = this.btCalendar.ClientID;
      ((WebControl) this.S_TxtDatecalendar).Attributes.Add("onkeydown", "deletedate(this,event);");
      ((WebControl) this.S_TxtDatecalendar).Attributes.Add("readonly", "");
      this.btCalendar.Attributes.Add("onclick", "ShowCalendar('" + this.idModuloCale + "',event,'" + this.namediv + "','" + this.nameframe + "','" + this.namebutton + "');");
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<script language=JavaScript>\n");
      stringBuilder.Append("function ShowCalendar(sender,e,namediv,nameframe,namebutton){\n");
      stringBuilder.Append("var crtl=document.getElementById(namediv).style;\n");
      stringBuilder.Append("var x = e.clientX;\n");
      stringBuilder.Append("var y = e.clientY;\n");
      stringBuilder.Append("crtl.left = x-20;\n");
      stringBuilder.Append("crtl.top = y+10;\n");
      stringBuilder.Append("crtl.display = (crtl.display == 'none')?'block':'none';\n");
      stringBuilder.Append("document.getElementById(nameframe).src='../CommonPage/PageCalendar.aspx?idmodulocal=' + sender + '&namediv=' + namediv;\n");
      stringBuilder.Append("}\n");
      stringBuilder.Append("function deletedate(sender,e){\n");
      stringBuilder.Append("if ((event.keyCode==46) && (window.confirm('Eliminare la data?'))){\n");
      stringBuilder.Append("sender.value=\"\";\n");
      stringBuilder.Append("\t}\n");
      stringBuilder.Append("}\n");
      stringBuilder.Append("</script>");
      if (this.Page.IsStartupScriptRegistered("PopupCalendarStartup"))
        return;
      this.Page.RegisterStartupScript("PopupCalendarStartup", stringBuilder.ToString());
    }

    public S_TextBox Datazione => this.S_TxtDatecalendar;

    public HtmlInputButton ButtonCalendar => this.btCalendar;

    public void CreateValidator(string message, ValidatorDisplay dispaly)
    {
      RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
      requiredFieldValidator.ControlToValidate = ((Control) this.S_TxtDatecalendar).ID;
      requiredFieldValidator.ErrorMessage = message;
      requiredFieldValidator.Display = dispaly;
      this.Controls.Add((Control) requiredFieldValidator);
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
