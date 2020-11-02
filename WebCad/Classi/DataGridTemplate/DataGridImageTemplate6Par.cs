using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebCad.UserControl 
{
	/// <summary>
	//calsse per binding una funzione claient a 6 parametri ad field della datagrid
	/// </summary>
	public class DataGridImageTemplate6Par : ITemplate
	{
		ListItemType templateType;
		string columnName;
		string columnName1;
		string columnName2;
		string columnName3;
		string columnName4;
		string columnName5;
		string columnName6;
		//se è un un immagine
		string srcImage;
		string commandImage;
		string tooltip;

		public DataGridImageTemplate6Par(ListItemType type, 
			string testoColonna,
			string colname1, 
			string colname2, 
			string colname3, 
			string colname4, 
			string colname5, 
			string colname6, 
			string src, 
			string command)
		{
			templateType = type;
			columnName=testoColonna;
			columnName1 = colname1;
			columnName2 = colname2;
			columnName3 = colname3;
			columnName4 = colname4;
			columnName5 = colname5;
			columnName6 = colname6;
			SetCaratteristicheImmagini(src,command);
			tooltip="";
		}

	
		public DataGridImageTemplate6Par(ListItemType type, 
			string testoColonna,
			string colname1, 
			string colname2, 
			string colname3, 
			string colname4,
			string colname5, 
			string colname6,
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
			columnName5 = colname5;
			columnName6 = colname6;
			SetCaratteristicheImmagini(src,command);
			this.tooltip=tooltip;
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
			HtmlImage l = (HtmlImage) sender;
			DataGridItem container = (DataGridItem) l.NamingContainer;
			l.Src=srcImage;
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
				((DataRowView) container.DataItem)[columnName5].ToString().Replace(",",".")+ " " +
				((DataRowView) container.DataItem)[columnName6].ToString().Replace(",",".")+ " " +
				commandImage.Split('$')[1]);
		}

	}
}
