// Decompiled with JetBrains decompiler
// Type: WebCad.UserControl.DataGridImageTemplate5Par
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
  public class DataGridImageTemplate5Par
  {
    private ListItemType templateType;
    private string columnName;
    private string columnName1;
    private string columnName2;
    private string columnName3;
    private string columnName4;
    private string columnName5;
    private string srcImage;
    private string commandImage;
    private string tooltip;

    public DataGridImageTemplate5Par(
      ListItemType type,
      string testoColonna,
      string colname1,
      string colname2,
      string colname3,
      string colname4,
      string colname5,
      string src,
      string command)
    {
      this.templateType = type;
      this.columnName = testoColonna;
      this.columnName1 = colname1;
      this.columnName2 = colname2;
      this.columnName3 = colname3;
      this.columnName4 = colname4;
      this.columnName5 = colname5;
      this.SetCaratteristicheImmagini(src, command);
      this.tooltip = "";
    }

    public DataGridImageTemplate5Par(
      ListItemType type,
      string testoColonna,
      string colname1,
      string colname2,
      string colname3,
      string colname4,
      string colname5,
      string src,
      string command,
      string tooltip)
    {
      this.templateType = type;
      this.columnName = testoColonna;
      this.columnName1 = colname1;
      this.columnName2 = colname2;
      this.columnName3 = colname3;
      this.columnName4 = colname4;
      this.columnName5 = colname5;
      this.SetCaratteristicheImmagini(src, command);
      this.tooltip = tooltip;
    }

    public void SetCaratteristicheImmagini(string src, string command)
    {
      this.srcImage = src;
      this.commandImage = command;
      this.tooltip = "";
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
      HtmlImage htmlImage = (HtmlImage) sender;
      DataGridItem namingContainer = (DataGridItem) htmlImage.NamingContainer;
      htmlImage.Src = this.srcImage;
      if (this.tooltip != "")
        htmlImage.Attributes.Add("title", this.tooltip);
      htmlImage.Style.Add("cursor", "hand");
      htmlImage.Attributes.Add("onClick", this.commandImage.Split('$')[0] + ((DataRowView) namingContainer.DataItem)[this.columnName1].ToString().Replace(",", ".") + ", " + ((DataRowView) namingContainer.DataItem)[this.columnName2].ToString().Replace(",", ".") + ", " + ((DataRowView) namingContainer.DataItem)[this.columnName3].ToString().Replace(",", ".") + ", " + ((DataRowView) namingContainer.DataItem)[this.columnName4].ToString().Replace(",", ".") + " " + ((DataRowView) namingContainer.DataItem)[this.columnName5].ToString().Replace(",", ".") + " " + this.commandImage.Split('$')[1]);
    }
  }
}
