using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace  WebCad.UserControl
{		

	/// <summary>
	/// Descrizione di riepilogo per DataGridImageTemplate2Par.
	/// </summary>
	public class DataGridImageTemplate2Par: ITemplate
	{
		ListItemType templateType;
		string columnName1;
		string columnName2;
		//se è un un immagine
		string srcImage;
		string commandImage;
		string tooltip;

		public DataGridImageTemplate2Par(ListItemType type, string colname1, string colname2, string src, string command, string tooltip)
		{
			templateType = type;
			columnName1 = colname1;
			columnName2 = colname2;
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
					lc.Text = "<B>" + columnName1 + "</B>";
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
					lc.Text = "<I>" + columnName1 + "</I>";
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
			if (commandImage.Split('$').Length==2)
			{
				l.Attributes.Add("onClick",commandImage.Split('$')[0] + "'" +
					((DataRowView) container.DataItem)[columnName1].ToString()+"','"+
					((DataRowView) container.DataItem)[columnName2].ToString()+"'"+ 
					commandImage.Split('$')[1]);
			} 
			else
			{
				l.Attributes.Add("onClick",commandImage);
			}
		}

	}
}
