using System;
using System.Data;
using S_Controls.Collections;


namespace GIC.App_Code.Businnes
{
	/// <summary>
	/// Descrizione di riepilogo per DataManager.
	/// </summary>
	public interface DataManager
	{
		DataSet GetAllData();
		DataRow GetSingleData(int id);
		int InsertData(S_ControlsCollection param);
		int UpdateData(S_ControlsCollection param);
		int DeleteData(S_ControlsCollection param);
		int Execute(S_ControlsCollection param, string StoredProcedure);

	}
}
