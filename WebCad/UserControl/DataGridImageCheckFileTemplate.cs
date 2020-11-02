// Decompiled with JetBrains decompiler
// Type: WebCad.UserControl.DataGridImageCheckFileTemplate
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebCad.UserControl
{
  public class DataGridImageCheckFileTemplate : ITemplate
  {
    private ListItemType templateType;
    private string columnName;
    private string srcImage;
    private string commandImage;
    private string tooltip;
    private string path;
    private string estensioneFile;
    private string fileName = "";

    public DataGridImageCheckFileTemplate(
      ListItemType type,
      string colname,
      string src,
      string command,
      string path)
    {
      this.templateType = type;
      this.columnName = colname;
      this.path = path;
      this.estensioneFile = "";
      this.SetCaratteristicheImmagini(src, command);
      this.tooltip = "";
    }

    public DataGridImageCheckFileTemplate(
      ListItemType type,
      string colname,
      string src,
      string command,
      string tooltip,
      string path)
    {
      this.templateType = type;
      this.columnName = colname;
      this.path = path;
      this.estensioneFile = "";
      this.SetCaratteristicheImmagini(src, command);
      this.tooltip = tooltip;
    }

    public DataGridImageCheckFileTemplate(
      ListItemType type,
      string colname,
      string src,
      string command,
      string tooltip,
      string path,
      string estensioneFile)
    {
      this.templateType = type;
      this.columnName = colname;
      this.path = path;
      this.estensioneFile = estensioneFile;
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
      if (this.CheckFile(((DataRowView) namingContainer.DataItem)[this.columnName].ToString()))
        htmlImage.Attributes.Add("onClick", this.commandImage.Split('$')[0] + "'" + this.fileName + "','" + this.fileName + this.estensioneFile + "','true','" + ((DataRowView) namingContainer.DataItem)["idservizio"].ToString() + "','" + ((DataRowView) namingContainer.DataItem)["servizio"].ToString() + "'" + this.commandImage.Split('$')[1]);
      else
        htmlImage.Attributes.Add("onClick", this.commandImage.Split('$')[0] + "'" + this.fileName + "','','false','" + ((DataRowView) namingContainer.DataItem)["idservizio"].ToString() + "','" + ((DataRowView) namingContainer.DataItem)["servizio"].ToString() + "'" + this.commandImage.Split('$')[1]);
    }

    private bool CheckFile(string filename)
    {
      this.fileName = filename;
      return File.Exists(this.path + this.fileName + this.estensioneFile);
    }
  }
}
