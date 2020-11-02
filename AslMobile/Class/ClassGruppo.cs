using System;
using System.Data;
using System.Data.OracleClient;
using ApplicationDataLayer; 
using System.Web.UI.WebControls;

namespace TheSite.AslMobile.Class
{
	/// <summary>
	/// Descrizione di riepilogo per ClassGruppo.
	/// </summary>
	public class ClassGruppo: Abstract
	{
		public ClassGruppo()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
		public void setDropDownList(DropDownList Gruppo)
		{
			Gruppo.Items.Clear();

			DataSet Ds=	this.GetListaGruppo();
			
			Gruppo.DataSource = this.ItemBlankDataSource(Ds.Tables[0],"DESCRIZIONE", "ID", "", "0");
			Gruppo.DataTextField = "DESCRIZIONE";
			Gruppo.DataValueField = "ID";
			Gruppo.DataBind();
		}
		private DataSet GetListaGruppo()
		{
			OracleParameterCollection Coll= new OracleParameterCollection();

			
			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);
			
			DataSet _MyDs= base.GetData(Coll,"PACK_RICHIEDENTI_TIPO.SP_GETALLRICHIEDENTI_TIPO");

			return _MyDs;
		}
	}
}
