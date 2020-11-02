using System;
using System.Data;
using System.Data.OracleClient; 
using System.Web.UI.WebControls;

namespace TheSite.AslMobile.Class
{
	/// <summary>
	/// Descrizione di riepilogo per ClassUrgenza.
	/// </summary>
	public class ClassUrgenza: Abstract
	{
		public ClassUrgenza()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
		public void setDropDownList(DropDownList Urgenza)
		{
			Urgenza.Items.Clear();

			DataSet Ds=	this.GetListaUrgenza();
			
			Urgenza.DataSource = Ds;
			Urgenza.DataTextField = "PRIORITY";
			Urgenza.DataValueField = "ID";
			Urgenza.DataBind();
			Urgenza.SelectedValue = "4";

		}
		public void setDropDownListDefault(DropDownList Urgenza)
		{
			Urgenza.Items.Clear();

			DataSet Ds=	this.GetListaUrgenza();
			
			Urgenza.DataSource = this.ItemBlankDataSource(Ds.Tables[0],"PRIORITY", "ID", "- Selezionare una Urgenza -", "");;
			Urgenza.DataTextField = "PRIORITY";
			Urgenza.DataValueField = "ID";
			Urgenza.DataBind();
//			Urgenza.SelectedValue = "0";

		}

		private DataSet GetListaUrgenza()
		{
			OracleParameterCollection Coll= new OracleParameterCollection();

			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);
			

			DataSet _MyDs= base.GetData(Coll,"PACK_PRIORITY.SP_GETALLPRIORITY");

			return _MyDs;
		}
	}
}
