﻿// Decompiled with JetBrains decompiler
// Type: WebCad.UserControl.DataGridImageTemplate2Par
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
  public class DataGridImageTemplate2Par : ITemplate
  {
    private ListItemType templateType;
    private string columnName1;
    private string columnName2;
    private string srcImage;
    private string commandImage;
    private string tooltip;

    public DataGridImageTemplate2Par(
      ListItemType type,
      string colname1,
      string colname2,
      string src,
      string command,
      string tooltip)
    {
      this.templateType = type;
      this.columnName1 = colname1;
      this.columnName2 = colname2;
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
          literal.Text = "<B>" + this.columnName1 + "</B>";
          container.Controls.Add((Control) literal);
          break;
        case ListItemType.Footer:
          literal.Text = "<I>" + this.columnName1 + "</I>";
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
      if (this.commandImage.Split('$').Length == 2)
        htmlImage.Attributes.Add("onClick", this.commandImage.Split('$')[0] + "'" + ((DataRowView) namingContainer.DataItem)[this.columnName1].ToString() + "','" + ((DataRowView) namingContainer.DataItem)[this.columnName2].ToString() + "'" + this.commandImage.Split('$')[1]);
      else
        htmlImage.Attributes.Add("onClick", this.commandImage);
    }
  }
}
