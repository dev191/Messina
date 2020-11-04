using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;

namespace GIC.App_Code.Datagrid
{
	/// <summary>
	/// Descrizione di riepilogo per QueryDTControl.
	/// </summary>
	public class QueryDTControl: GIC.App_Code.Datagrid.DatagridControl
	{

		private DataGrid CurrDt;
		private System.Web.UI.StateBag ViewState;
		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];	


		public System.Web.UI.StateBag ViewStatePar
		{
			set{ViewState=value;}
		}

		public QueryDTControl(DataGrid Dt)
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
			//Dt.Columns[3].Visible = false;

		}

		public void SetColums()
		{
//			if(Dt.Columns[3].Visible == true)
//			{
//				Dt.Columns[3].Visible = false;
//			} 
//			else 
//			{
//				Dt.Columns[3].Visible = true;
//			}
		}

		public void EditCommand(object source, DataGridCommandEventArgs e)
		{
			this.Dt.EditItemIndex = (int) e.Item.ItemIndex;
			this.SetColums();
		}

		public void UpdateCommand(object source, DataGridCommandEventArgs e, string[] ControlParamName, string ControlForIdName, string StoredProcedure,  App_Code.Businnes.DataManager dataManager)
		{
			this.Dt.EditItemIndex = -1;
			this.SetColums();
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
			switch(e.CommandName)
			{
				case "Delete":
					int IdQuery = int.Parse(Dt.DataKeys[(int)e.Item.ItemIndex].ToString());
					ApplicationDataLayer.OracleDataLayer _OraDl;
					_OraDl = new OracleDataLayer(s_ConnStr);
			
					S_ControlsCollection param=new S_ControlsCollection();

					S_Object IdSchema;
					IdSchema= new S_Object();
					IdSchema.ParameterName="pIdSchema";
					IdSchema.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
					IdSchema.Direction=ParameterDirection.Input;
					IdSchema.Value=IdQuery;
					IdSchema.Index=0;
					param.Add (IdSchema);

					S_Object DirParam;
					DirParam= new S_Object();
					DirParam.ParameterName="pId";
					DirParam.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
					DirParam.Direction=ParameterDirection.Output;
					DirParam.Value=DBNull.Value;
					DirParam.Index=1;
					param.Add (DirParam);

					_OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.IL_SpDeleteSchema");
					break;
				default:
					// Do nothing.
					break;
			}
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

