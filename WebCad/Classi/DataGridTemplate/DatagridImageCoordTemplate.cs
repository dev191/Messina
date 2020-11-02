namespace WebCad.UserControl
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	/// <summary>
	/// Descrizione di riepilogo per DatagridImageCoordTemplate.
	/// </summary>
	public class DatagridImageCoordTemplate: ITemplate
	{
		ListItemType templateType;
		string columnName;
		string columnName1;
		string columnName2;
		string columnName3;
		string columnName4;

		//se è un un immagine
		string srcImage;
		string commandImage;
		string tooltip;

		//se deve essere attiva
		string checkField;
		int valueCheck=0;

		public DatagridImageCoordTemplate(ListItemType type, 
			string testoColonna,
			string colname1, 
			string colname2, 
			string colname3, 
			string colname4, 
			string src, 
			string command)
		{
			templateType = type;
			columnName=testoColonna;
			columnName1 = colname1;
			columnName2 = colname2;
			columnName3 = colname3;
			columnName4 = colname4;
			SetCaratteristicheImmagini(src,command);
			tooltip="";
			checkField="";
		}
		public DatagridImageCoordTemplate(ListItemType type, 
			string testoColonna,
			string colname1, 
			string colname2, 
			string colname3, 
			string colname4,
			string src, 
			string command, 
			string tooltip)
		{
			templateType = type;
			columnName=testoColonna;
			columnName1 = colname1;
			columnName2 = colname2;
			columnName3 = colname3;
			columnName4 = colname4;
			SetCaratteristicheImmagini(src,command);
			this.tooltip=tooltip;
			this.checkField="";
		}

		public DatagridImageCoordTemplate(ListItemType type, 
			string testoColonna,
			string colname1, 
			string colname2, 
			string colname3, 
			string colname4,
			string src, 
			string command, 
			string tooltip, 
			string checkField, 
			int checkValue)
		{
			templateType = type;
			columnName=testoColonna;
			columnName1 = colname1;
			columnName2 = colname2;
			columnName3 = colname3;
			columnName4 = colname4;
			SetCaratteristicheImmagini(src,command);
			this.tooltip=tooltip;
			this.checkField=checkField;
			this.valueCheck=checkValue;
		}
   
		public void SetCaratteristicheImmagini(string src, string command)
		{
			this.srcImage=src;
			this.commandImage=command;
			tooltip="";
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
				l.Attributes.Add("onClick",commandImage.Split('$')[0] +
					((DataRowView) container.DataItem)[columnName1].ToString().Replace(",",".")+ ", " +
					((DataRowView) container.DataItem)[columnName2].ToString().Replace(",",".")+ ", " +
					((DataRowView) container.DataItem)[columnName3].ToString().Replace(",",".")+ ", " +
					((DataRowView) container.DataItem)[columnName4].ToString().Replace(",",".")+ " " +
					commandImage.Split('$')[1]);
			} else 
				l.Disabled=true;
		}

	}
}
