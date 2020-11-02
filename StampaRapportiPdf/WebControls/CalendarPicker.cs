// Decompiled with JetBrains decompiler
// Type: StampaRapportiPdf.WebControls.CalendarPicker
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using S_Controls;
using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace StampaRapportiPdf.WebControls
{
  public class CalendarPicker : UserControl
  {
    protected Label lbl_Date;
    protected HtmlInputButton btCalendar;
    protected S_TextBox S_TxtDatecalendar;
    protected Image imgCalendar;

    private void Page_Load(object sender, EventArgs e)
    {
      this.btCalendar.Attributes.Add("onclick", "javascript:return popUpCalendar(" + ((Control) this.S_TxtDatecalendar).ClientID + "," + this.getClientID() + ", 'dd/mm/yyyy', '__doPostBack(\\'" + this.getClientID() + "\\')')");
      StringBuilder stringBuilder = new StringBuilder();
      ((WebControl) this.S_TxtDatecalendar).Attributes.Add("readonly", "");
      ((WebControl) this.S_TxtDatecalendar).Attributes.Add("onkeydown", "deletedate(this,event);");
      stringBuilder.Append("<script language=JavaScript>\n");
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

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    public S_TextBox Datazione => this.S_TxtDatecalendar;

    public string getClientID() => ((Control) this.S_TxtDatecalendar).ClientID;

    public HtmlInputButton ButtonCalendar => this.btCalendar;

    public string CalendarDate
    {
      get => ((TextBox) this.S_TxtDatecalendar).Text;
      set => ((TextBox) this.S_TxtDatecalendar).Text = value;
    }

    public string Text
    {
      get => this.lbl_Date.Text;
      set => this.lbl_Date.Text = value;
    }

    public void CreateValidator(string message, ValidatorDisplay dispaly)
    {
      RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
      requiredFieldValidator.ControlToValidate = ((Control) this.S_TxtDatecalendar).ID;
      requiredFieldValidator.ErrorMessage = message;
      requiredFieldValidator.Display = dispaly;
      this.Controls.Add((Control) requiredFieldValidator);
    }
  }
}
