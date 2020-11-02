// Decompiled with JetBrains decompiler
// Type: WebCad.UserControl.DataGridImageTemplate
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebCad.UserControl
{
  public class DataGridImageTemplate : ITemplate
  {
    private ListItemType templateType;
    private string columnName;
    private string srcImage;
    private string commandImage;
    private string tooltip;
    private string checkField;
    private int valueCheck = 0;

    public DataGridImageTemplate(ListItemType type, string colname, string src, string command)
    {
      this.templateType = type;
      this.columnName = colname;
      this.SetCaratteristicheImmagini(src, command);
      this.tooltip = "";
      this.checkField = "";
    }

    public DataGridImageTemplate(
      ListItemType type,
      string colname,
      string src,
      string command,
      string tooltip)
    {
      this.templateType = type;
      this.columnName = colname;
      this.SetCaratteristicheImmagini(src, command);
      this.tooltip = tooltip;
      this.checkField = "";
    }

    public void SetCaratteristicheImmagini(string src, string command)
    {
      this.srcImage = src;
      this.commandImage = command;
      this.tooltip = "";
    }

    public DataGridImageTemplate(
      ListItemType type,
      string colname,
      string src,
      string command,
      string tooltip,
      string checkField,
      int checkValue)
    {
      this.templateType = type;
      this.columnName = colname;
      this.SetCaratteristicheImmagini(src, command);
      this.tooltip = tooltip;
      this.checkField = checkField;
      this.checkField = checkField;
      this.valueCheck = checkValue;
    }

    public void InstantiateIn(Control container)
    {
      Literal literal = new Literal();
      switch (this.templateType)
      {
        case ListItemType.Header:
          literal.Text = "<B>" + this.columnName + "</B>";
          container.Controls.Add((Control) literal);
          break;
        case ListItemType.Footer:
          literal.Text = "<I>" + this.columnName + "</I>";
          container.Controls.Add((Control) literal);
          break;
        case ListItemType.Item:
          HtmlImage htmlImage = new HtmlImage();
          htmlImage.DataBinding += new EventHandler(this.BindDataLiteral);
          container.Controls.Add((Control) htmlImage);
          break;
        case ListItemType.EditItem:
          container.Controls.Add((Control) new TextBox()
          {
            Text = ""
          });
          break;
      }
    }

    private void BindDataLiteral(object sender, EventArgs e)
    {
      bool flag = true;
      HtmlImage htmlImage = (HtmlImage) sender;
      DataGridItem namingContainer = (DataGridItem) htmlImage.NamingContainer;
      htmlImage.Src = this.srcImage;
      if (this.checkField != "" && Convert.ToInt32(((DataRowView) namingContainer.DataItem)[this.checkField].ToString()) == this.valueCheck)
        flag = false;
      if (flag)
      {
        if (this.tooltip != "")
          htmlImage.Attributes.Add("title", this.tooltip);
        htmlImage.Style.Add("cursor", "hand");
        if (this.commandImage.Split('$').Length == 2)
          htmlImage.Attributes.Add("onClick", this.commandImage.Split('$')[0] + ((DataRowView) namingContainer.DataItem)[this.columnName].ToString() + this.commandImage.Split('$')[1]);
        else
          htmlImage.Attributes.Add("onClick", this.commandImage);
      }
      else
        htmlImage.Disabled = true;
    }
  }
}
