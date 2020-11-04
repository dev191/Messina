using System;
using System.Data;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;


namespace GIC.App_Code.Businnes
{
	/// <summary>
	/// Descrizione di riepilogo per Query.
	/// </summary>
	public class Query: DataManager
	{
		
		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
		ApplicationDataLayer.OracleDataLayer _OraDl;


		public Query()
		{	
			_OraDl = new OracleDataLayer(s_ConnStr);
		}

		public DataSet GetAllData()
		{
			DataSet dt = null;
			return dt;

		}

		public DataRow GetSingleData(int id)
		{
			DataRow dr = null;
			return dr;
		}

		public int InsertData(S_ControlsCollection param)
		{
			return 0;
		}

		public int UpdateData(S_ControlsCollection param)
		{
			return 0;
		}

		public int DeleteData(S_ControlsCollection param)
		{
			return 0;
		}

		public int Execute(S_ControlsCollection param, string StoredProcedure)
		{
			return 0;
		}

	}
}

