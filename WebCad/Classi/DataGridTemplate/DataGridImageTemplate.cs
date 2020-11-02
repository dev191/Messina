namespace WebCad.UserControl
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	public class DataGridImageTemplate : ITemplate
	{		
		ListItemType templateType;
		string columnName;

		//se è un un immagine
		string srcImage;
		string commandImage;
		string tooltip;

		//se deve essere attiva
		string checkField;
		int valueCheck=0;

		public DataGridImageTemplate(ListItemType type, string colname, string src, string command)
		{
			templateType = type;
			columnName = colname;
			SetCaratteristicheImmagini(src,command);
			tooltip="";
			checkField="";
		}
		public DataGridImageTemplate(ListItemType type, string colname, string src, string command, string tooltip)
		{
			templateType = type;
			columnName = colname;
			SetCaratteristicheImmagini(src,command);
			this.tooltip=tooltip;
			checkField="";
		}
   
		public void SetCaratteristicheImmagini(string src, string command)
		{
			this.srcImage=src;
			this.commandImage=command;
			tooltip="";
		}

		public DataGridImageTemplate(ListItemType type, 
			string colname, 
			string src, 
			string command, 
			string tooltip, 
			string checkField, 
			int checkValue)
		{
			templateType = type;
			columnName = colname;
			SetCaratteristicheImmagini(src,command);
			this.tooltip=tooltip;
			this.checkField=checkField;
			this.checkField=checkField;
			this.valueCheck=checkValue;
		}

		//metodo dell interfaccia
		public void InstantiateIn(Control container)
		{
			Literal lc = new Literal();
			switch(templateType)
			{
				case ListItemType.Header:
					lc.Text = "<B>" + columnName + "</B>";
					container.Controls.Add(lc);
					break;
				case ListItemType.Item:
					HtmlImage ib = new HtmlImage();
					ib.DataBinding += new EventHandler(this.BindDataLiteral);
					container.Controls.Add(ib);
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
			bool enable=true;
			HtmlImage l = (HtmlImage) sender;
			DataGridItem container = (DataGridItem) l.NamingContainer;
			l.Src=srcImage;

			if (checkField!="")
			{
				if (Convert.ToInt32(((DataRowView) container.DataItem)[checkField].ToString())==valueCheck)
					enable=false;
			}

			if (enable)
			{
				if (tooltip!="")
				{
					l.Attributes.Add("title",tooltip);
				}
				l.Style.Add("cursor","hand");
				if (commandImage.Split('$').Length==2)
				{
					l.Attributes.Add("onClick",commandImage.Split('$')[0] +((DataRowView) container.DataItem)[columnName].ToString()+ commandImage.Split('$')[1]);
				} 
				else
				{
					l.Attributes.Add("onClick",commandImage);
				}
			}
			else 
				l.Disabled=true;
		}
	}
}
