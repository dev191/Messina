namespace WebCad.WebControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Configuration;
	using WebCad.WiewCad;
	using WebCad;
	using UserControl;


	/// <summary>
	///		Descrizione di riepilogo per DataGridRicerca.
	/// </summary>
	/// 

	public class DataGridRicercaCad : System.Web.UI.UserControl
	{
		protected System.Data.DataSet dataSet1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1 = new DataGrid();
		protected System.Web.UI.WebControls.Label LabelElementiTrovati;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.PlaceHolder PlaceHolder1;
		public int numeroPagina=0;
		public int recordPerPagina;
		public int tipo;
		protected System.Web.UI.WebControls.Label LabelResp;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divdatagrid;
		public int totaleRecord;
		protected string nomeScript="";

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Page is IDataGridDinamico)
			{
				nomeScript=Request.ServerVariables["SCRIPT_NAME"];
				if (Request.QueryString["clear"]!=null)
				{
					WebCad.ParametriRicerca parametri = (WebCad.ParametriRicerca)Session["parametri"];
					parametri.eqIds=string.Empty;
					parametri.rmIds=string.Empty;
					parametri.stdEqIds=string.Empty;
					Session["parametri"]=parametri;
					this.Visible=false;
				}
				else 
				{
					if (Session["parametri"]!=null)
					{
						setTemplate(((WebCad.ParametriRicerca)Session["parametri"]).tipoDataSet);
						bottomFrame pg = (bottomFrame)Page;
				
						dataSet1 = pg.Popola((WebCad.ParametriRicerca)Session["parametri"]);
						SetDataSet(dataSet1, ((WebCad.ParametriRicerca)Session["parametri"]).tipoDataSet);
						this.Visible=true;
					} 
					else 
					{
						this.Visible=false;
					}
				}
			} 
			else 
			{
				throw new ApplicationException("FEDERICO DISSE: Chi usa il datagrid dinamico deve implementare IDataGridDinamico");
			}
		}

		# region DatagridTemplate
		public void setTemplate(int tipo)
		{
			DataGrid1.ID="DataGrid1";//Grid Settings
			DataGrid1.AutoGenerateColumns=false;
			DataGrid1.EnableViewState=true;
			DataGrid1.AllowPaging=true;
			DataGrid1.ShowFooter=false;
			DataGrid1.ShowHeader=true;
			DataGrid1.PagerStyle.Mode = PagerMode.NumericPages;
			DataGrid1.AllowSorting=true;
			DataGrid1.Width= Unit.Percentage(100);
			DataGrid1.AlternatingItemStyle.CssClass="DataGridAlternatingItemStyle";
			DataGrid1.ItemStyle.CssClass="DataGridItemStyle";
			DataGrid1.HeaderStyle.CssClass="DataGridHeaderStyle";
			DataGrid1.AllowSorting=true;
			string PhatFileDwf = Request.MapPath(Request.ApplicationPath + ConfigurationSettings.AppSettings["DirectoryCad"]);

			if (tipo==(int)TipoDatagrid.SelezionePlanimetria)
			{
				TemplateColumn tc0 = new TemplateColumn();
				tc0.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "");
				tc0.ItemTemplate = new 
					DataGridImageCheckFileTemplate(ListItemType.Item, "Nome_File", "../images/Search16x16_bianca.JPG","SetDwf ($)","Seleziona DWG",PhatFileDwf,".dwf");
				tc0.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "");
				tc0.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "");
				DataGrid1.Columns.Add(tc0);

				TemplateColumn tc1 = new TemplateColumn();
				tc1.SortExpression="Edificio";
				tc1.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "Edificio");
				tc1.ItemTemplate = new 
					DataGridTemplate(ListItemType.Item, "Edificio");
				tc1.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "Edificio");
				tc1.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "Edificio");
				DataGrid1.Columns.Add(tc1);


				TemplateColumn tc2 = new TemplateColumn();
				tc2.SortExpression="Piano";
				tc2.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "Piano");
				tc2.ItemTemplate = new 
					DataGridTemplate(ListItemType.Item, "Piano");
				tc2.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "Piano");
				tc2.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "Piano");
				DataGrid1.Columns.Add(tc2);


				TemplateColumn tc3 = new TemplateColumn();
				tc3.SortExpression="Nome_File";
				tc3.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "Nome File");
				tc3.ItemTemplate = new 
					DataGridTemplate(ListItemType.Item, "Nome_File");
				tc3.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "Nome File");
				tc3.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "Nome File");
				DataGrid1.Columns.Add(tc3);

				TemplateColumn tc4 = new TemplateColumn();
				tc4.SortExpression="Servizio";
				//tc4.HeaderText="Servizio";
				tc4.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "Servizio");
				tc4.ItemTemplate = new 
					DataGridTemplate(ListItemType.Item, "Servizio");
				tc4.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "");
				tc4.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "");
				DataGrid1.Columns.Add(tc4);
			}

			if (tipo==(int)TipoDatagrid.NavigazioneSpazi)
			{
				//visualizzazione della stanza
				TemplateColumn tc0 = new TemplateColumn();
				tc0.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "");
				tc0.ItemTemplate = new 
					DataGridImageTemplate(ListItemType.Item, 
					"layer", 
					"../images/Search16x16_bianca.JPG",
					"vbscript:EvidenziaLayer('$')",
					"evidenzia la stanza","idc",0);
				tc0.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "");
				tc0.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "");
				DataGrid1.Columns.Add(tc0);

				//Ricerca DataRoom
				TemplateColumn tc01 = new TemplateColumn();
				tc01.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "");
				tc01.ItemTemplate = new 
					DataGridImageTemplate(ListItemType.Item, 
					"id_rm", 
					"../images/DataRoom.jpg",
					"javascript:openRicercaDataRoom(" + ((WebCad.ParametriRicerca)Session["parametri"]).blId  + "," + ((WebCad.ParametriRicerca)Session["parametri"]).flId + ")",
					"Ricerca DataRoom");
				tc01.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "");
				tc01.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "");
				DataGrid1.Columns.Add(tc01);

				

				//zoomsullastanza
				TemplateColumn tc03 = new TemplateColumn();
				tc03.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "");
				tc03.ItemTemplate = new 
					DatagridImageCoordTemplate(ListItemType.Item, "id_rm", "z1x", "z1y","z2x", "z2y","../images/eye.gif",
					"vbscript:ZoomOfObject $ ","zoom sulla stanza","idc",0);
				tc03.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "");
				tc03.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "");
				DataGrid1.Columns.Add(tc03);

				//dataroom OpenDataRoom
				TemplateColumn tc02 = new TemplateColumn();
				tc02.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "");
				tc02.ItemTemplate = new 
					DataGridImageTemplate2Par(ListItemType.Item, 
					"id_rm",
					"stanza",
					"../images/Stanza.gif",
					"javascript:OpenDataRoom($)",
					"dataroom");
				tc02.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "");
				tc02.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "");
				DataGrid1.Columns.Add(tc02);

				TemplateColumn tc1 = new TemplateColumn();
				tc1.SortExpression="rm_id";
				tc1.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "Stanza");
				tc1.ItemTemplate = new 
					DataGridTemplate(ListItemType.Item, "rm_id","idc",0);
				tc1.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "rm_id");
				tc1.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "Stanza");
				DataGrid1.Columns.Add(tc1);


				TemplateColumn tc2 = new TemplateColumn();
				tc2.SortExpression="Stanza";
				tc2.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "Stanza");
				tc2.ItemTemplate = new 
					DataGridTemplate(ListItemType.Item, "Stanza","idc",0);
				tc2.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "Stanza");
				tc2.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "Stanza");
				DataGrid1.Columns.Add(tc2);


				TemplateColumn tc3 = new TemplateColumn();
				tc3.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "Dest. Uso");
				tc3.ItemTemplate = new 
					DataGridTemplate(ListItemType.Item, "DestUso","idc",0);
				tc3.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "DestUso");
				tc3.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "DestUso");
				DataGrid1.Columns.Add(tc3);

				TemplateColumn tc4 = new TemplateColumn();
				tc4.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "Reparto");
				tc4.ItemTemplate = new 
					DataGridTemplate(ListItemType.Item, "Reparto","idc",0);
				tc4.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "Reparto");
				tc4.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "Reparto");
				DataGrid1.Columns.Add(tc4);

				TemplateColumn tc5 = new TemplateColumn();
				tc5.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "Categoria");
				tc5.ItemTemplate = new 
					DataGridTemplate(ListItemType.Item, "Categoria","idc",0);
				tc5.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "Categoria");
				tc5.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "Categoria");
				DataGrid1.Columns.Add(tc5);

				TemplateColumn tc6 = new TemplateColumn();
				tc6.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "Mq");
				tc6.ItemTemplate = new 
					DataGridTemplate(ListItemType.Item, "Area","idc",0);
				tc6.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "Ara");
				tc6.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "Area");
				DataGrid1.Columns.Add(tc6);
			}

			if (tipo==(int)TipoDatagrid.NavigazioneApparati)
			{
				//visualizzazione del dettaglio dell'apparecchiatura //Search16x16_bianca.JPG
				TemplateColumn tc0 = new TemplateColumn();
				tc0.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "");
				tc0.ItemTemplate = new 
					DataGridImageTemplate(ListItemType.Item, "eq_id", "../images/treeimages/gnome-desktop-config.gif","javascript:OpenApparecchiatura('$')","visualizzazione del dettaglio dell'apparecchiatura");
				tc0.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "");
				tc0.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "");
				DataGrid1.Columns.Add(tc0);

				//Visualizzazione Documenti Allegati
				TemplateColumn tc01 = new TemplateColumn();
				tc01.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "");
				tc01.ItemTemplate = new 
					DataGridImageTemplate2Par(ListItemType.Item, "id_eq","eq_id", "../images/attach.png","javascript:OpenDocumentiEq($)","Documenti associati");
				tc01.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "");
				tc01.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "");
				DataGrid1.Columns.Add(tc01);

				//documenti associati all'apparecchiatura
				TemplateColumn tc03 = new TemplateColumn();
				tc03.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "");
				tc03.ItemTemplate = new 
					DataGridImageTemplate(ListItemType.Item, 
					"id_eq",  
					"../images/SchedeEq.jpg",
					"javascript:OpenSchedaEq('$')",
					"Scheda di esercizio");	
				tc03.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "");
				tc03.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "");
				DataGrid1.Columns.Add(tc03);

				//zoomsullastanza
				TemplateColumn tc04 = new TemplateColumn();
				tc04.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "");
				tc04.ItemTemplate = new 
					DatagridImageCoordTemplate(ListItemType.Item, "id_rm", "z1x", "z1y","z2x", "z2y", "../images/eye.gif","vbscript:ZoomOfObject $ ","zoom sulla apparecchiatura","idc",0);
				tc04.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "");
				tc04.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "");
				DataGrid1.Columns.Add(tc04);

				TemplateColumn tc1 = new TemplateColumn();
				tc1.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "Codice");
				tc1.ItemTemplate = new 
					DataGridTemplate(ListItemType.Item, "eq_id","idc",0);
				tc1.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "eq_id");
				tc1.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "Codice");
				DataGrid1.Columns.Add(tc1);


				TemplateColumn tc2 = new TemplateColumn();
				tc2.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "Standard Eq");
				tc2.ItemTemplate = new 
					DataGridTemplate(ListItemType.Item, "standardeq","idc",0);
				tc2.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "standardeq");
				tc2.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "Standard Eq");
				DataGrid1.Columns.Add(tc2);


				TemplateColumn tc3 = new TemplateColumn();
				tc3.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "Servizio");
				tc3.ItemTemplate = new 
					DataGridTemplate(ListItemType.Item, "servizio","idc",0);
				tc3.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "servizio");
				tc3.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "Servizio");
				DataGrid1.Columns.Add(tc3);

				TemplateColumn tc4 = new TemplateColumn();
				tc4.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "Reparto");
				tc4.ItemTemplate = new 
					DataGridTemplate(ListItemType.Item, "reparto","idc",0);
				tc4.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "reparto");
				tc4.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "Reparto");
				DataGrid1.Columns.Add(tc4);

				TemplateColumn tc5 = new TemplateColumn();
				tc5.HeaderTemplate = new 
					DataGridTemplate(ListItemType.Header, "Stanza");
				tc5.ItemTemplate = new 
					DataGridTemplate(ListItemType.Item, "stanza","idc",0);
				tc5.EditItemTemplate = new 
					DataGridTemplate(ListItemType.EditItem, "stanza");
				tc5.FooterTemplate = new 
					DataGridTemplate(ListItemType.Footer, "Stanza");
				DataGrid1.Columns.Add(tc5);
			}

			PlaceHolder1.Controls.Add(DataGrid1);			
		}

		#endregion

		private void FillGrid(DataSet ds)
		{
			DataGrid1.DataSource=dataSet1.Tables[0];
			DataGrid1.DataBind();			
		}

		public int GetTipo()
		{
			return Convert.ToInt32(ViewState["tipo"]);
		}

		private void SetDataSet(DataSet ds, int tipo)
		{

			dataSet1=ds;
			string xml = ds.GetXml();	
			this.tipo=tipo;
			ViewState["tipo"]=tipo;
			if (this.dataSet1.Tables[0].Rows.Count==0)
			{
				divdatagrid.Visible=false;
			} 
			else 
			{
				divdatagrid.Visible=true;
			}
			if (dataSet1!=null)
			{
				FillGrid(dataSet1);
				LabelElementiTrovati.Text=Convert.ToString(dataSet1.Tables[0].Rows.Count);
				DataGrid1.PageSize=Convert.ToInt32(DropDownList1.SelectedValue);
				totaleRecord=this.dataSet1.Tables[0].Rows.Count;
			}
			if (this.DataGrid1.Items.Count==0)
			{
				LabelResp.Text="Non ci sono dati per i parametri selezionati";
				LabelResp.Visible=true;
			} 
			else 
			{
				LabelResp.Visible=false;
			}

		}

		#region Codice generato da Progettazione Web Form
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: questa chiamata è richiesta da Progettazione Web Form ASP.NET.
			//
			//this.DataGrid1.ItemDataBound += new DataGridItemEventHandler(DataGrid1_ItemDataBound);
			this.DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.CambiaPaginaDataGrid);
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
			this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public int GetNumeroPagina()
		{
			return Convert.ToInt32(ViewState["numeroPagina"]);
		}

		public int GetRecordPerPagina()
		{
			if(Convert.ToInt32(ViewState["recordPerPagina"])>0)
				return Convert.ToInt32(ViewState["recordPerPagina"]);
			else return 10;
		}

		protected void CambiaPaginaDataGrid(object source, DataGridPageChangedEventArgs e)
		{
			numeroPagina=e.NewPageIndex;
			ViewState["numeroPagina"]=numeroPagina;
			DataGrid1.CurrentPageIndex=numeroPagina;
			SetDataSet(dataSet1, ((WebCad.ParametriRicerca)Session["parametri"]).tipoDataSet);
		}

		protected void OrdinaDataGrid(object source, DataGridSortCommandEventArgs e)
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
			ViewState["campoDiOrdinamento"]=e.SortExpression;
			SetDataSet(dataSet1, ((WebCad.ParametriRicerca)Session["parametri"]).tipoDataSet);
		}

		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			recordPerPagina=Convert.ToInt32(DropDownList1.SelectedValue);
			ViewState["recordPerPagina"]=recordPerPagina;
			DataGrid1.PageSize=recordPerPagina;
			DataGrid1.CurrentPageIndex=0;
			SetDataSet(dataSet1, ((WebCad.ParametriRicerca)Session["parametri"]).tipoDataSet);
		}

	}
}
