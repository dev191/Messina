namespace WebCad.UserControl
{
	using System;
	using System.IO;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	public class DataGridImageCheckFileTemplate : ITemplate
	{		
		ListItemType templateType;
		string columnName;

		//se è un un immagine
		string srcImage;
		string commandImage;
		string tooltip;
		string path;
		string estensioneFile;
		string fileName="";


		public DataGridImageCheckFileTemplate(ListItemType type, string colname, string src, string command, string path)
		{
			templateType = type;
			columnName = colname;
			this.path=path;
			this.estensioneFile="";
			SetCaratteristicheImmagini(src,command);
			tooltip="";
		}

		public DataGridImageCheckFileTemplate(ListItemType type, string colname, string src, string command, string tooltip, string path)
		{
			templateType = type;
			columnName = colname;
			this.path=path;
			this.estensioneFile="";
			SetCaratteristicheImmagini(src,command);
			this.tooltip=tooltip;
		}

		public DataGridImageCheckFileTemplate(ListItemType type, string colname, string src, string command, string tooltip, string path, string estensioneFile)
		{
			templateType = type;
			columnName = colname;
			this.path=path;
			this.estensioneFile=estensioneFile;
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
			
			bool ilFileEsiste = CheckFile(((DataRowView) container.DataItem)[columnName].ToString());

			if (ilFileEsiste)
				l.Attributes.Add("onClick",commandImage.Split('$')[0] + "'" + this.fileName + "','" + this.fileName +this.estensioneFile +"','true'"+",'"+((DataRowView) container.DataItem)["idservizio"].ToString()+ "','" + ((DataRowView) container.DataItem)["servizio"].ToString()+ "'" + commandImage.Split('$')[1]);
			else
				l.Attributes.Add("onClick",commandImage.Split('$')[0] +"'" + this.fileName + "',''"+",'false'"+",'"+((DataRowView) container.DataItem)["idservizio"].ToString()+ "','" + ((DataRowView) container.DataItem)["servizio"].ToString()+ "'" + commandImage.Split('$')[1]);
		}

		private bool CheckFile(string filename)
		{
			this.fileName=filename;
			string fullPath=  this.path + fileName + this.estensioneFile ;
			return File.Exists(fullPath);
		}
	}
}
