using System;
using System.Web.UI.WebControls;

namespace GIC.App_Code.Datagrid
{
	/// <summary>
	/// Descrizione di riepilogo per DatagridControl.
	/// </summary>
	public interface DatagridControl
	{
		DataGrid Dt
		{
			get;
			set;
		}

		int numeroPagina
		{
			get;
		}

		string campoDiOrdinamento
		{
			get;
		}

		int recordPerPagina
		{
			get;
		}

		void InitDataGrid();
		void SetColums ();
		void EditCommand(object source, DataGridCommandEventArgs e);
		void UpdateCommand(object source, DataGridCommandEventArgs e, string[] ControlParamNamel, string COntrolForIdName, string StoredProcedure,  App_Code.Businnes.DataManager dataManager);
		void CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e);
		void ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e, string[] ControlParamName, string ControlForIdName, string StoredProcedure, string command,  App_Code.Businnes.DataManager dataManager);
		void DataBound();

		#region controllo datagrid
		void CambiaPaginaDataGrid(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e);
		void OrdinaDataGrid(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e);
		void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e, string valore);
		#endregion

	}
}
