using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;

namespace GIC.App_Code.Datagrid
{
	/// <summary>
	/// 
	/// </summary>
	public class StandardDTControl : GIC.App_Code.Datagrid.DatagridControl
	{

		private DataGrid CurrDt;
		private System.Web.UI.StateBag ViewState;


		public System.Web.UI.StateBag ViewStatePar
		{
			set{ViewState=value;}
		}

		public StandardDTControl(DataGrid Dt)
		{
			this.Dt=Dt;
		}

		public int numeroPagina
		{
			get{return Convert.ToInt32(ViewState["numeroPagina"]);}
		}

		public string campoDiOrdinamento
		{
			get{return Convert.ToString(ViewState["campoDiOrdinamento"]);}
		}

		public int recordPerPagina
		{
			get{return Convert.ToInt32(ViewState["recordPerPagina"]);}
		}

		#region Medodi di DataGridControl
		public DataGrid Dt
		{
			get{return CurrDt;}
			set{CurrDt = value;}
		}

		public void InitDataGrid()
		{
			Dt.Columns[2].Visible = false;
			Dt.Columns[3].Visible = false;
		}

		public void SetColums()
		{
			if(Dt.Columns[0].Visible == true)
			{
				Dt.Columns[0].Visible = false;
				Dt.Columns[1].Visible = false;
				Dt.Columns[2].Visible = true;
				Dt.Columns[3].Visible = true;
			} 
			else 
			{
				Dt.Columns[0].Visible = true;
				Dt.Columns[1].Visible = true;
				Dt.Columns[2].Visible = false;
				Dt.Columns[3].Visible = false;
			}
		}

		public void EditCommand(object source, DataGridCommandEventArgs e)
		{
			this.Dt.EditItemIndex = (int) e.Item.ItemIndex;
			this.SetColums();
		}

		public void UpdateCommand(object source, DataGridCommandEventArgs e, string[] ControlParamName, string ControlForIdName, string StoredProcedure,  App_Code.Businnes.DataManager dataManager)
		{
//			int id = int.Parse(Dt.DataKeys[(int)e.Item.ItemIndex].ToString());
//			int Result =0;
//			Object controllo;
//
//
//			S_ControlsCollection param=new S_ControlsCollection();
//
//			try
//			{
//				if (e.CommandName=="Update")
//				{
//					foreach (string par in ControlParamName)
//					{
//						controllo = ((Object) e.Item.FindControl(par)); 
//						if (controllo is S_Controls.S_TextBox)
//							param.Add((S_TextBox)controllo);
//						else if (controllo is S_Controls.S_ListBox)
//							param.Add((S_ListBox)controllo);
//						else if (controllo is S_Controls.S_ComboBox)
//							param.Add((S_ComboBox)controllo);
//					}
//
//					SqlParameter para;
//
//					para=new SqlParameter(ControlForIdName,SqlDbType.Int);
//					para.Direction=ParameterDirection.Input;
//					para.Value=id;
//					param.Add (para);
//
//					
//					Result = dataManager.UpdateData(param);
//				
//				
//					if (Result > 0)
//					{
//						this.Dt.EditItemIndex = -1;
//						this.SetColums();
//					}
//					else
//					{
//						throw new ApplicationException("la stored procedure ha restituito valore 0");
//					}
//				}
//			}
//			catch(SqlException ex)
//			{
//					throw (ex);//Scateno nuovamente l'errore perchè è sconosciuto
//			}
//
//			finally
//			{
//				;
//			}
		}

		public void CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.Dt.EditItemIndex = -1;
			this.SetColums();
			
		}

		public void DataBound()
		{
		}

		public void ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e, string[] ControlParamName, string ControlForIdName, string StoredProcedure, string command, App_Code.Businnes.DataManager dataManager)
		{
//			switch(e.CommandName)
//			{
//				case "Delete":
//					int id = int.Parse(Dt.DataKeys[(int)e.Item.ItemIndex].ToString());
//
//					SqlDalCollectionParameter param=new SqlDalCollectionParameter();
//
//					SqlParameter para;
//					para=new SqlParameter(ControlForIdName,SqlDbType.Int);
//					para.Direction=ParameterDirection.Input;
//					para.Value=id;
//					param.Add (para);
//
//					dataManager.DeleteData(param);
//					break;
//
//				default:
//					// Do nothing.
//					break;
//			}
		}
		#endregion

		#region controllo datagrid

		public void CambiaPaginaDataGrid(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			ViewState["numeroPagina"]=e.NewPageIndex;
		}

		public void OrdinaDataGrid(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			string verso="";
			if (Convert.ToString(ViewState["verso"])=="" || Convert.ToString(ViewState["verso"])=="DESC")
			{
				verso="ASC";
				ViewState["verso"]=verso;
			} 
			else 
				if (Convert.ToString(ViewState["verso"])=="ASC")
			{
				verso="DESC";
				ViewState["verso"]=verso;
			}
			ViewState["campoDiOrdinamento"]=e.SortExpression + " " + verso;
		}

		public void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e, string valore)
		{
			ViewState["recordPerPagina"]=Convert.ToInt32(valore);
		}
		#endregion

	}
}
