using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data;
using GIC.App_Code.Datagrid;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
 
namespace GIC.App_Code
{
	/// <summary>
	/// Descrizione di riepilogo per BasePage.
	/// </summary>
	public class BaseControl : System.Web.UI.UserControl
	{

		protected System.Web.UI.WebControls.Label LabelMessage;


		protected string ListaControlli
		{
			get
			{
				string ControlIdList = string.Empty;
				foreach (object oct in this.Controls)
				{
					if (oct is S_TextBox)
					{
						S_TextBox  ct = (S_TextBox)oct;
						if (ControlIdList == string.Empty)
							ControlIdList+=ct.ClientID;
						else
							ControlIdList+=";"+ct.ClientID;
					}

					if (oct is S_ListBox)
					{
						S_ListBox  ct = (S_ListBox)oct;
						if (ControlIdList == string.Empty)
							ControlIdList+=ct.ClientID;
						else
							ControlIdList+=";"+ct.ClientID;
					}

					if (oct is Button)
					{
						Button  ct = (Button)oct;
						if (ControlIdList == string.Empty)
							ControlIdList+=ct.ClientID;
						else
							ControlIdList+=";"+ct.ClientID;
					}

					if (oct is HtmlInputButton)
					{
						HtmlInputButton  ct = (HtmlInputButton)oct;
						if (ControlIdList == string.Empty)
							ControlIdList+=ct.ClientID;
						else
							ControlIdList+=";"+ct.ClientID;
					}
				}
				return ControlIdList;
			}
		}




		public object GetViewState(string key)
		{
			return ViewState[key];
		}

		public BaseControl()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
		/// <summary>
		/// Messaggio che indica che il record è gia presenete e non può essere duplicato
		/// </summary>
		protected void MessageDuplicate()
		{
			string Message="Attenzione! Impossibile inserire la chiave è duplicata.";
			string Alert="<script language='javascript'>alert('" + Message + "');</script>";
			Page.RegisterStartupScript("duplicata", Alert);
		}
		/// <summary>
		/// Messaggio che indica che il record ha dei record correlati in un altra tabella
		/// </summary>
		protected void MessageBox(string message)
		{
			string Alert="<script language='javascript'>alert(\"" + message + "\");</script>";
			Page.RegisterStartupScript("existRecord", Alert);
		}
		/// <summary>
		/// Crea un link nella cella di intestazione per l'ordinamneto delle colonne
		/// </summary>
		/// <param name="cella">Cella in cui è presente l'intestazione</param>
		/// <param name="IndexColumn">Indice del campo da ordinare</param>
		protected void CreateLink(TableCell cella,string IndexColumn,string Title)
		{
			string Header=cella.Text; 
			HtmlAnchor link=new HtmlAnchor();
			link.HRef ="#";
			link.Attributes.Add("onclick",Page.GetPostBackClientHyperlink(Page, "sort:" + IndexColumn +""));
			link.InnerText=Header; 
			link.Title=Title;
			cella.Controls.Add(link);
		}
		protected void CreateLink(TableCell cella,string IndexColumn)
		{
			CreateLink(cella,IndexColumn,"");
		}
		/// <summary>
		/// Property utilizzata per memorizzare la colonna per l'ordinamento
		/// </summary>
		protected string SortColumn
		{
			get{return Convert.ToString(ViewState["campoDiOrdinamento"]);}
			set{
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
				ViewState["campoDiOrdinamento"]=value + " " + verso;
			}
		}

		public BaseControl GetMe()
		{
			return this;
		}

		/// <summary>
		/// Metodo per aggiungere un elemnto di Default ad un Controllo DropDownList o ListBox
		/// </summary>
		/// <param name="ctrl">Controllo DropDownList o ListBox</param>
		/// <param name="text">Testo da visualizzare</param>
		/// <param name="Value">Valore nascosto</param>
		protected void AddDefaultItem(System.Web.UI.WebControls.WebControl ctrl, string text, string Value)
		{
			if (ctrl is S_Controls.S_ComboBox ||  ctrl is  DropDownList )
				((DropDownList)ctrl).Items.Insert(0,new ListItem(text,Value)); 
			if (ctrl is S_Controls.S_ListBox ||  ctrl is  ListBox )
				((ListBox)ctrl).Items.Insert(0,new ListItem(text,Value));

		}

		/// <summary>
		/// Recupera la data dell'ultimo aggiornamento
		/// </summary>


		
		#region controllo datagrid

		public int numeroPagina=0;
		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];	
		protected DatagridControl ControlloDatagrid;
		protected DropDownList DropDownListNR;
		protected DataGrid DataGridDati;
		//string[] controlli = null;

		protected int recordPerPagina
		{
			get{ return Convert.ToInt32(ViewState["recordPerPagina"]);}
			set{ViewState["recordPerPagina"]=value;}
		}


		protected S_ControlsCollection paramFederico
		{
			get{return (S_ControlsCollection)Session["ParamFederico"];}
			set{Session["ParamFederico"]=value;}
		}

		protected string CurrentProcedure
		{
			get{ return Convert.ToString(ViewState["CurrentProcedure"]);}
			set{ViewState["CurrentProcedure"]=value;}
		}


		protected virtual void BindDataGrid()
		{
			DataGridDati.CurrentPageIndex=numeroPagina;
			DataGridDati.PageSize=Convert.ToInt32(DropDownListNR.SelectedValue);
			DataGridDati.DataSource=this.GetData();
			DataGridDati.DataBind();
		}



		protected DataTable GetData()
		{
			ApplicationDataLayer.OracleDataLayer _OraDl;
			_OraDl = new OracleDataLayer(s_ConnStr);

			DataSet _Ds=new DataSet();
			//Recupero i dati dal DataBase	
			
			try
			{
				_Ds = _OraDl.GetRows(paramFederico, CurrentProcedure).Copy();			

				//this.Id = itemId;
				return _Ds.Tables[0];	
			} 
			catch  (Exception ex)
			{
				if (LabelMessage != null)
				{
					LabelMessage.Text=ex.Message;
				} 
				else 
				{
					throw ex;
				}
				return new DataTable();
			}

			
		}

		protected void CambiaPaginaDataGrid(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			numeroPagina=e.NewPageIndex;
			BindDataGrid();	
		}

		protected void OrdinaDataGrid(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
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

			foreach (S_Controls.Collections.S_Object Param in paramFederico)
			{
				if (Param.ParameterName=="@SortExpression")
				{
					Param.Value = Convert.ToString(ViewState["campoDiOrdinamento"])=="" ? "NULL" : Convert.ToString(ViewState["campoDiOrdinamento"]) ;
					break;
				}
			}

			BindDataGrid();	
		}

		protected void DropDownListNR_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			recordPerPagina=Convert.ToInt32(DropDownListNR.SelectedValue);
			BindDataGrid();	
		}




		#endregion
	}


}