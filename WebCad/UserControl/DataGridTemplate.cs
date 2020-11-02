// Decompiled with JetBrains decompiler
// Type: WebCad.UserControl.DataGridTemplate
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCad.UserControl
{
  public class DataGridTemplate : ITemplate
  {
    private ListItemType templateType;
    private string columnName;
    private string checkField;
    private int valueCheck = 0;

    public DataGridTemplate(ListItemType type, string colname)
    {
      this.templateType = type;
      this.columnName = colname;
      this.checkField = "";
    }

    public DataGridTemplate(ListItemType type, string colname, string checkField, int checkValue)
    {
      this.templateType = type;
      this.columnName = colname;
      this.checkField = checkField;
      this.valueCheck = checkValue;
    }

    public void InstantiateIn(Control container)
    {
      Label label = new Label();
      switch (this.templateType)
      {
        case ListItemType.Header:
          label.Text = "<B>" + this.columnName + "</B>";
          container.Controls.Add((Control) label);
          break;
        case ListItemType.Footer:
          label.Text = "<I>" + this.columnName + "</I>";
          container.Controls.Add((Control) label);
          break;
        case ListItemType.Item:
          label.DataBinding += new EventHandler(this.BindDataLiteral);
          container.Controls.Add((Control) label);
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
      Label label = (Label) sender;
      DataGridItem namingContainer = (DataGridItem) label.NamingContainer;
      label.Text = ((DataRowView) namingContainer.DataItem)[this.columnName].ToString();
      if (!(this.checkField != "") || Convert.ToInt32(((DataRowView) namingContainer.DataItem)[this.checkField].ToString()) != this.valueCheck)
        return;
      label.ForeColor = Color.Silver;
    }
  }
}
