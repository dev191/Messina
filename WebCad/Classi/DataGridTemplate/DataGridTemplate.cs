namespace WebCad.UserControl
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;


	public class DataGridTemplate : ITemplate
	{

		ListItemType templateType;
		string columnName;
		string checkField;
		int valueCheck=0;


		public DataGridTemplate(ListItemType type, string colname)
		{
			templateType = type;
			columnName = colname;
			this.checkField = "";
		}
   
		public DataGridTemplate(ListItemType type, string colname, string checkField, int checkValue)
		{
			templateType = type;
			columnName = colname;
			this.checkField = checkField;
			valueCheck=checkValue;
		}

		//metodo dell interfaccia
		public void InstantiateIn(Control container)
		{
			Label lc = new Label();
			switch(templateType)
			{
				case ListItemType.Header:
					lc.Text = "<B>" + columnName + "</B>";
					container.Controls.Add(lc);
					break;
				case ListItemType.Item:
					lc.DataBinding += new EventHandler(this.BindDataLiteral);
					container.Controls.Add(lc);	
					break;
				case ListItemType.EditItem:
					TextBox tb = new TextBox();
					tb.Text = "";
					container.Controls.Add(tb);
					break;
				case ListItemType.Footer:
					lc.Text = "<I>" + columnName + "</I>";
					container.Controls.Add(lc);
					break;
			}

		}

		private void BindDataLiteral(object sender, EventArgs e)
		{
			Label l = (Label) sender;
			DataGridItem container = (DataGridItem) l.NamingContainer;
			l.Text = ((DataRowView) container.DataItem)[columnName].ToString();

			if (this.checkField!="")
			{
				if (Convert.ToInt32(((DataRowView) container.DataItem)[checkField].ToString())==valueCheck)
				{
					l.ForeColor=Color.Silver;
				}

			}
		}
	}
}
