namespace GIC.Report.UserControl
{
	using System;
	using System.Collections;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using S_Controls;
	using S_Controls.Collections;
	using ApplicationDataLayer;
	using TheSite.GIC.App_Code.DataSetDef;
	using ApplicationDataLayer.DBType;


	/// <summary>
	///		Descrizione di riepilogo per VisSelCampi.
	/// </summary>
	public class VisSelCampi : App_Code.BaseControl
	{
		protected TheSite.GIC.App_Code.DataSetDef.DataSetReport dataSetReport1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden SelectedItems;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtHTitolo;
		protected string TuttiClientId;
		protected System.Web.UI.WebControls.Table TableTuttiCampi;
		protected System.Web.UI.WebControls.Table TableCampiSel;
		protected System.Web.UI.WebControls.TextBox TextTitolo;
		protected System.Web.UI.WebControls.TextBox TextDescrizione;
		protected System.Web.UI.WebControls.Button BtnSalva;
		protected System.Web.UI.WebControls.Button BtnAnnulla;
		protected System.Web.UI.WebControls.Button ButtonVisualizza;
		protected System.Web.UI.WebControls.Button BtnExcel;
		protected System.Web.UI.WebControls.TextBox TxtOwner;
		protected System.Web.UI.WebControls.Button BtnCopia;
		protected string SelezClientId;

		public int IdQuery
		{
			set
			{
				ViewState["idQuer"]=value;
				Ricarica();
				SetButnVis();
				//Response.Write("Schema Numero:" + Convert.ToString(ViewState["idQuer"]));
			}
			get{
				return Convert.ToInt32(ViewState["idQuer"]);
			}
		}

		public string SelectedItemsValue
		{
			set{SelectedItems.Value=value;}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{			
			TuttiClientId=TableTuttiCampi.ClientID;
			SelezClientId=TableCampiSel.ClientID;			
		}

		private void SetButnVis()
		{
			if(Convert.ToInt32(ViewState["idQuer"])==0)
			{
				//ButtonVisualizza.Visible=false;
				TextDescrizione.Text="";
				TextTitolo.Text="";
				TxtOwner.Text="";
			} 
			else 
			{
				ButtonVisualizza.Visible=true;
				GetDatiSchema();
			}
			ButtonVisualizza.Attributes.Add("onclick","return CheckSelC();");
			BtnExcel.Attributes.Add("onclick","return CheckSelC();");
			BtnSalva.Attributes.Add("onclick","return CheckSelC();");
		}

		private void GetDatiSchema()
		{
			S_ControlsCollection param = new S_ControlsCollection();

			S_Controls.Collections.S_Object DirParam;
			DirParam=new S_Object();
			DirParam.ParameterName="pIdSchema";
			DirParam.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			DirParam.Index=0;
			DirParam.Value = IdQuery;
			param.Add(DirParam);
			
			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "putente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = 1;
			s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;
			param.Add (s_IdIn);

			S_Object io_cursor = new S_Object();
			io_cursor.ParameterName = "io_cursor";
			io_cursor.Direction=ParameterDirection.Output;
			io_cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
			io_cursor.Index=2;
			param.Add(io_cursor);

			paramFederico=param;
			CurrentProcedure="IL_PACK_INTERROGAZIONI.IL_SpSelectSchema";

			DataTable dt = base.GetData();

			TextTitolo.Text=Convert.ToString(dt.Rows[0].ItemArray[0]);
			txtHTitolo.Value=Convert.ToString(dt.Rows[0].ItemArray[0]);
			TextDescrizione.Text=Convert.ToString(dt.Rows[0].ItemArray[1]);
			TxtOwner.Text=Convert.ToString(dt.Rows[0].ItemArray[2]);

			if(Context.User.Identity.Name.ToUpper()==TxtOwner.Text.ToUpper() || Context.User.IsInRole("amministratori"))
			{
				BtnSalva.Visible=true;
			}
			else
			{
				BtnSalva.Visible=false;
			}
		}

		public void Ricarica()
		{
			TuttiClientId=TableTuttiCampi.ClientID;
			SelezClientId=TableCampiSel.ClientID;

			TableCampiSel.Rows.Clear();
			
			BindTuttiCampi();
			BindCampiSel();
			
		}

		private void BindTuttiCampi()
		{
			SelectedItemsValue="";
			TableTuttiCampi.Rows.Clear();
			dataSetReport1.TuttiCampi.Clear();
			DataTable dt = GetTuttiCampi();
			foreach (DataRow dr in dt.Rows)
			{
				dataSetReport1.TuttiCampi.ImportRow(dr);
			}
			dt.Dispose();
			
			TableRow tr = new TableRow();
			TableCell td = new TableCell();
			td.Text="Doppio Click per aggiungere";
			td.CssClass = "TableHeaderCampi2";
			td.Attributes.Add("ondblclick","SelectItem(this.parentNode,'li')");
			tr.Cells.Add(td);
			TableTuttiCampi.Rows.Add(tr);
			int contar=0;

			foreach(DataSetReport.TuttiCampiRow riga in dataSetReport1.TuttiCampi)
			{
				
				contar++;

				
				tr = new TableRow();
				td = new TableCell();
				
				if (contar % 2 == 0)
				{
					tr.CssClass="TableRowTuttiCampi";
				}
				else 
				{
					tr.CssClass="TableRowTuttiCampiAlt";
				}
				td.CssClass="TableCellTuttiCampi";
				td.Text=Convert.ToString(riga.Alias);
				tr.Attributes.Add("desc",Convert.ToString(riga.NomeTabella) + " - " +Convert.ToString(riga.Alias));				
				//tr.Attributes.Add("title",Convert.ToString(riga.NomeTabella) + " - " +Convert.ToString(riga.NomeCampo));
				tr.Attributes.Add("title",Convert.ToString(riga.NomeCampo));
				tr.Attributes.Add("idItem",Convert.ToString(riga.IdGlossario));
				//tr.Attributes.Add("ondblclick","SelectItem(this,'li')");
				td.Attributes.Add("ondblclick","SelectItem(this.parentNode,'li')");
				td.Width=Unit.Pixel(250);
				tr.Attributes.Add("tipol",Convert.ToString(riga.Tipologia));
				tr.Attributes.Add("tipod",Convert.ToString(riga.TipoDato));
				tr.Cells.Add(td);
				TableTuttiCampi.Rows.Add(tr);

				//Cella info Ordinamento
				td = new TableCell();
				td.Text=GetImageVuota();
				tr.Attributes.Add("ord","NESSUNO");
				td.CssClass="TableCellInfoCampi";
				tr.Cells.Add(td);

				//Cella info Filtro
				td = new TableCell();
				td.Text=GetImageVuota();
				td.CssClass="TableCellInfoCampi";
				tr.Attributes.Add("filtro","");
				tr.Cells.Add(td);

				//Cella info Aggregazione
				td = new TableCell();
				td.Text=GetImageVuota();
				tr.Attributes.Add("aggr","NESSUNO");
				td.CssClass="TableCellInfoCampi";
				tr.Cells.Add(td);

				//Cella info Nascosto
				td = new TableCell();
				td.Text=GetImageVuota();
				tr.Attributes.Add("nascosto","False");
				td.CssClass="TableCellInfoCampi";
				tr.Cells.Add(td);

				//cella su
				td = new TableCell();
				HtmlImage modItem = new HtmlImage();
				modItem.Src="..\\..\\imgFunz\\freccia_su_4.gif";
				modItem.Attributes.Add("class","ButtonCampi");
				modItem.Attributes.Add("onclick","InversioneCampi(this,'su')");
				td.Controls.Add(modItem);
				td.CssClass="TableCellInfoCampi";
				tr.Cells.Add(td);



				//cella giu
				td = new TableCell();
				modItem = new HtmlImage();
				modItem.Src="..\\..\\imgFunz\\freccia_giu_4.gif";
				modItem.Attributes.Add("class","ButtonCampi");
				modItem.Attributes.Add("onclick","InversioneCampi(this,'giu')");
				td.Controls.Add(modItem);
				td.CssClass="TableCellInfoCampi";
				tr.Cells.Add(td);

				//Cella pulsante
				td = new TableCell();
				HtmlInputButton modItem2 = new HtmlInputButton();
				modItem2.Value="modifica";
				modItem2.Attributes.Add("class","ButtonCampi");
				modItem2.Attributes.Add("onclick","OpenWindow("+ Convert.ToInt32(this.IdQuery) +","+ riga.IdGlossario +",document.getElementById('" + TuttiClientId + "').tBodies[0],this);");
				td.Controls.Add(modItem2);
				td.CssClass="TableCellInfoCampi";
				tr.Cells.Add(td);
			}
			TableTuttiCampi.Height=Unit.Pixel(20);

		}

		private DataTable GetTuttiCampi()
		{
			int cntPar = 0;
			S_ControlsCollection CollezioneParametri = new S_ControlsCollection();

			S_Object pIdQuery=new S_Object();
			pIdQuery.ParameterName = "pIdQuery";
			pIdQuery.DbType = CustomDBType.Integer;
			pIdQuery.Direction = ParameterDirection.Input;
			pIdQuery.Size = 32;
			pIdQuery.Index=cntPar++;
			pIdQuery.Value = IdQuery;
			CollezioneParametri.Add(pIdQuery);

			S_Object  pSelect=new S_Object();
			pSelect.ParameterName = "pSelected";
			pSelect.DbType = CustomDBType.Integer;
			pSelect.Direction = ParameterDirection.Input;
			//pIdQuery.Size = 32;
			pSelect.Index=cntPar++;
			pSelect.Value = 0;
			CollezioneParametri.Add(pSelect);

			S_Object pSortExpression=new S_Object();
			pSortExpression.ParameterName = "pSortExpression";
			pSortExpression.DbType = CustomDBType.VarChar;
			pSortExpression.Direction = ParameterDirection.Input;
			pSortExpression.Size = 100;
			pSortExpression.Value =  Convert.ToString(ViewState["campoDiOrdinamento"])=="" ? " il_glossario.Tabella || ' - ' || il_glossario.Alias " : Convert.ToString(ViewState["campoDiOrdinamento"]) ;
			pSortExpression.Index=cntPar++;
			CollezioneParametri.Add(pSortExpression);

			Hashtable _HS=(Hashtable) Session["ParametriSelectSchema"];
			int IdVista = Convert.ToInt32(_HS["IdVista"]);
			S_Object pIdVista=new S_Object();
			pIdVista.ParameterName = "pIdVista";
			pIdVista.DbType = CustomDBType.Integer;
			pIdVista.Direction = ParameterDirection.Input;
			pIdVista.Size = 32;
			pIdVista.Value =  IdVista;
			pIdVista.Index=cntPar++;
			CollezioneParametri.Add(pIdVista);

			S_Object  io_cursor = new S_Object();
			io_cursor.ParameterName = "io_cursor";
			io_cursor.DbType = CustomDBType.Cursor;
			io_cursor.Direction=ParameterDirection.Output;
			io_cursor.Index=cntPar++;
			CollezioneParametri.Add(io_cursor);

			paramFederico=CollezioneParametri;
			CurrentProcedure="IL_PACK_INTERROGAZIONI.IL_SpSelectGlossario";

			return base.GetData();
		}

		private DataTable GetCampiQuery()
		{
			int cntPar = 0;
			S_ControlsCollection param = new S_ControlsCollection();

			S_Object pIdQuery=new S_Object();
			pIdQuery.ParameterName = "pIdQuery";
			pIdQuery.Direction = ParameterDirection.Input;
			pIdQuery.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			pIdQuery.Value = IdQuery;
			pIdQuery.Size = 32;
			pIdQuery.Index=cntPar++;
			param.Add(pIdQuery);

			S_Object pSelect=new S_Object();
			pSelect.ParameterName = "pSelected";
			pSelect.Direction = ParameterDirection.Input;
			pSelect.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			pSelect.Value = 1;
			pSelect.Size = 32;
			pSelect.Index=cntPar++;
			param.Add(pSelect);
			
			S_Object pSortExpression=new S_Object();
			pSortExpression.ParameterName = "pSortExpression";
			pSortExpression.Direction = ParameterDirection.Input;
			pSortExpression.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			pSortExpression.Size = 100;
			pSortExpression.Index=cntPar++;
			pSortExpression.Value = Convert.ToString(ViewState["campoDiOrdinamento"])=="" ? " dbo.IL_SCHEMA_DETTAGLIO.Posizione " : Convert.ToString(ViewState["campoDiOrdinamento"]) ;
			param.Add(pSortExpression);

			Hashtable _HS=(Hashtable) Session["ParametriSelectSchema"];
			int IdVista = Convert.ToInt32(_HS["IdVista"]);
			S_Object pIdVista=new S_Object();
			pIdVista.ParameterName = "pIdVista";
			pIdVista.DbType = CustomDBType.Integer;
			pIdVista.Direction = ParameterDirection.Input;
			pIdVista.Size = 32;
			pIdVista.Value =  IdVista;
			pIdVista.Index=cntPar++;
			param.Add(pIdVista);

			S_Object io_cursor = new S_Object();
			io_cursor.ParameterName = "io_cursor";
			io_cursor.Direction=ParameterDirection.Output;
			io_cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
			io_cursor.Index=cntPar++;
			param.Add(io_cursor);

			paramFederico=param;
			CurrentProcedure="IL_PACK_INTERROGAZIONI.IL_SpSelectGlossario";

			return base.GetData();
		}

		private DataTable GetFiltriCampo(int IdCampo)
		{
			S_ControlsCollection param = new S_ControlsCollection();

			S_Object  pIdQuery;
			pIdQuery=new S_Object();
			pIdQuery.ParameterName = "pIdQuery";
			pIdQuery.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			pIdQuery.Value = IdQuery;
			pIdQuery.Size=32;
			pIdQuery.Direction=ParameterDirection.Input;
			pIdQuery.Index=0;
			param.Add(pIdQuery);

			S_Object  pIdCampo;
			pIdCampo=new S_Object();
			pIdCampo.ParameterName = "pIdCampo";
			pIdCampo.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			pIdCampo.Value = IdCampo;
			pIdQuery.Size=32;
			pIdCampo.Direction=ParameterDirection.Input;
			pIdCampo.Index=1;
			param.Add(pIdCampo);

			S_Object  pSortExpression;			
			pSortExpression=new S_Object();
			pSortExpression.ParameterName = "pSortExpression";
			pSortExpression.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			pSortExpression.Size = 100;
			pSortExpression.Index=2;
			pSortExpression.Direction=ParameterDirection.Input;
			pSortExpression.Value = Convert.ToString(ViewState["campoDiOrdinamento"])=="" ? "NULL" : Convert.ToString(ViewState["campoDiOrdinamento"]) ;
			param.Add(pSortExpression);

			S_Object  io_cursor;
			io_cursor = new S_Object();
			io_cursor.ParameterName = "io_cursor";
			io_cursor.Index=3;
			io_cursor.Direction=ParameterDirection.Output;
			io_cursor.DbType = ApplicationDataLayer.DBType.CustomDBType.Cursor;
			param.Add(io_cursor);

			paramFederico=param;
			CurrentProcedure="IL_PACK_INTERROGAZIONI.IL_SpSelectFiltri";

			return base.GetData();
		}

		private string NormalizzaFiltri(int IdCampo)
		{
			DataTable dt = this.GetFiltriCampo(IdCampo);
			string result=string.Empty;
			foreach (DataRow dr in dt.Rows)
			{
				if (result!=String.Empty)
					result+="$";
				result+=""+Convert.ToString(dr["IdCriteri"])+"&"+
						""+Convert.ToString(dr["operatore"])+"&"+
						""+Convert.ToString(dr["Valore1"])+"&"+
						""+Convert.ToString(dr["Valore2"]);

			}
			return result;
		}

		private void BindCampiSel()
		{
			TableCampiSel.Rows.Clear();
			dataSetReport1.Campi.Clear();
			DataTable dt = GetCampiQuery();
			foreach (DataRow dr in dt.Rows)
			{
				dataSetReport1.Campi.ImportRow(dr);
			}
			dt.Dispose();

			TableRow tr = new TableRow();
			TableCell td = new TableCell();


			td.Text="Doppio Click per togliere";
			td.CssClass = "TableHeaderCampi2";
			td.Attributes.Add("ondblclick","SelectItem(this.parentNode,'qui')");
			tr.Cells.Add(td);
			TableCampiSel.Rows.Add(tr);
			int indice=1;
			foreach(DataSetReport.CampiRow riga in dataSetReport1.Campi)
			{
				tr = new TableRow();
				td = new TableCell();

				if (indice % 2 == 0)
				{
					tr.CssClass="TableRowCampiSel";
				}
				else 
				{
					tr.CssClass="TableRowCampiSelAlt";
				}

				td.Text=riga.Alias;
				tr.Attributes.Add("desc",Convert.ToString(riga.NomeTabella) + " - " +Convert.ToString(riga.Alias));
				//tr.Attributes.Add("desc",Convert.ToString(riga.Alias));
				//tr.Attributes.Add("title",Convert.ToString(riga.NomeTabella) + " - " +Convert.ToString(riga.NomeCampo));
				tr.Attributes.Add("title",Convert.ToString(riga.NomeCampo));
				td.CssClass="TableCellCampiSel";
				td.Width=Unit.Pixel(250);
				tr.Attributes.Add("idItem",Convert.ToString(riga.IdGlossario));
				//tr.Attributes.Add("ondblclick","SelectItem(this,'qui')");
				td.Attributes.Add("ondblclick","SelectItem(this.parentNode,'qui')");
				tr.Attributes.Add("tipol",Convert.ToString(riga.Tipologia));
				tr.Attributes.Add("tipod",Convert.ToString(riga.TipoDato));
				tr.Cells.Add(td);

				//Cella info Ordinamento
				td = new TableCell();
				td.Text=GetImageOrdinamento(riga.Ordinamento);
				tr.Attributes.Add("ord",riga.Ordinamento);
				td.CssClass="TableCellInfoCampi";
				tr.Cells.Add(td);

				string filtriNorm = string.Empty;
				//Cella info Filtro
				td = new TableCell();
				td.CssClass="TableCellInfoCampi";
				filtriNorm = NormalizzaFiltri(riga.IdGlossario);
				tr.Attributes.Add("filtro",filtriNorm);
				td.Text=GetImageFiltro(filtriNorm);
				tr.Cells.Add(td);

				//Cella info Aggregazione
				td = new TableCell();
				td.Text=GetImageAggregazione(riga.Aggregazione);
				tr.Attributes.Add("aggr",riga.Aggregazione);
				td.CssClass="TableCellInfoCampi";
				tr.Cells.Add(td);

				//Cella info Nascosto
				td = new TableCell();
				td.Text=GetImageNascosto(riga.Nascosto);
				tr.Attributes.Add("nascosto",riga.Nascosto?"1":"0");
				td.CssClass="TableCellInfoCampi";
				tr.Cells.Add(td);

				//cella su
				td = new TableCell();
				HtmlImage modItem = new HtmlImage();
				modItem.Src="..\\..\\imgFunz\\freccia_su_4.gif";
				modItem.Attributes.Add("class","ButtonCampi");
				modItem.Attributes.Add("onclick","InversioneCampi(this,'su')");
				td.Controls.Add(modItem);
				td.CssClass="TableCellInfoCampi";
				tr.Cells.Add(td);



				//cella giu
				td = new TableCell();
				modItem = new HtmlImage();
				modItem.Src="..\\..\\imgFunz\\freccia_giu_4.gif";
				modItem.Attributes.Add("class","ButtonCampi");
				modItem.Attributes.Add("onclick","InversioneCampi(this,'giu')");
				td.Controls.Add(modItem);
				td.CssClass="TableCellInfoCampi";
				tr.Cells.Add(td);



				//Cella pulsante
				td = new TableCell();
				HtmlInputButton modItem2 = new HtmlInputButton();
				modItem2.Value="modifica";
				modItem2.Attributes.Add("class","ButtonCampi");
				modItem2.Attributes.Add("onclick","OpenWindow("+ Convert.ToInt32(this.IdQuery)+","+ riga.IdGlossario +",document.getElementById('" + TuttiClientId + "').tBodies[0],this);");
				td.Controls.Add(modItem2);
				td.CssClass="TableCellInfoCampi";
				tr.Cells.Add(td);

				TableCampiSel.Rows.Add(tr);
				if (this.SelectedItems.Value!="")
				{
					this.SelectedItems.Value+="?";
				}
					
				this.SelectedItems.Value+=Convert.ToString(riga.IdGlossario);
				this.SelectedItems.Value+="#";
				this.SelectedItems.Value+=Convert.ToString(riga.NomeTabella) + " - " +Convert.ToString(riga.Alias);
				this.SelectedItems.Value+="#";
				this.SelectedItems.Value+=Convert.ToString(riga.Ordinamento);
				this.SelectedItems.Value+="#";
				this.SelectedItems.Value+=filtriNorm;
				this.SelectedItems.Value+="#";
				this.SelectedItems.Value+=Convert.ToString(!riga.Nascosto);
				this.SelectedItems.Value+="#";
				this.SelectedItems.Value+=Convert.ToString(riga.Aggregazione);
				this.SelectedItems.Value+="#";
				this.SelectedItems.Value+=Convert.ToString(indice++);
				this.SelectedItems.Value+="#";
				this.SelectedItems.Value+=Convert.ToString(riga.Tipologia);
				this.SelectedItems.Value+="#";
				this.SelectedItems.Value+=Convert.ToString(riga.TipoDato);

				
			}
			TableCampiSel.Height=Unit.Pixel(20);

		}
		protected string GetImageOrdinamento(string ordinamento)
		{
			if (ordinamento == "ASC")
				return @"<img src='..\Image\ico-crescente.gif' border='0'>";
			if (ordinamento == "DESC")
				return @"<img src='..\Image\ico-decrescente.gif' border='0'>";
			return @"<img src='..\Image\ico-vuota.gif' border='0'>";
		}

		protected string GetImageFiltro(string filtro)
		{
			if (filtro != string.Empty)
				return @"<img src='..\Image\ico-filtro.gif' border='0'>";
			return @"<img src='..\Image\ico-vuota.gif' border='0'>";
		}

		protected string GetImageAggregazione(string aggr)
		{
			if (aggr != "NESSUNO")
				return @"<img src='..\Image\ico-fx.gif' border='0'>";
			return @"<img src='..\Image\ico-vuota.gif' border='0'>";
		}

		protected string GetImageNascosto(bool nascosto)
		{
			if (!nascosto)
				return @"<img src='..\Image\ico-selezione.gif' border='0'>";
			return @"<img src='..\Image\ico-vuota.gif' border='0'>";
		}

		protected string GetImageVuota()
		{
			return @"<img src='..\Image\ico-vuota.gif' border='0'>";
		}




		#region Codice generato da Progettazione Web Form
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: questa chiamata è richiesta da Progettazione Web Form ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
			this.dataSetReport1 = new TheSite.GIC.App_Code.DataSetDef.DataSetReport();
			((System.ComponentModel.ISupportInitialize)(this.dataSetReport1)).BeginInit();
			// 
			// dataSetReport1
			// 
			this.dataSetReport1.DataSetName = "DataSetReport";
			this.dataSetReport1.Locale = new System.Globalization.CultureInfo("en-US");
			this.BtnSalva.Click += new System.EventHandler(this.BtnSalva_Click);
			this.BtnAnnulla.Click += new System.EventHandler(this.BtnAnnulla_Click);
			this.ButtonVisualizza.Click += new System.EventHandler(this.ButtonVisualizza_Click);
			this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
			this.BtnCopia.Click += new System.EventHandler(this.BtnCopia_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataSetReport1)).EndInit();

		}
		#endregion

		private void BtnSalva_Click(object sender, System.EventArgs e)
		{
			Salva(true);
		}

		private int NewIdQuery = 0;
		

		private void Salva(bool salva)
		{
			
			char sepCampi='?';
			char sepDati='#';
			char sepFiltri='$';
			char sepElemFiltro='&';

			//se IdQuery è zero ho solo nuovi elementi, altrimenti sto modificando

			string valori = SelectedItems.Value;
			
			string[] Query= valori.Split(sepCampi);

			string titolo=TextTitolo.Text;
			string descrizione=TextDescrizione.Text;

			InsertUpdateSchema(titolo, descrizione,salva);

			DeleteDettaglio();
			DeleteCriteri();

			//funzione che salva nella tabella  IL_SCHEMA_INTERROGAZIONE 
			//se il campo è gia presente lo modifico, altrimenti ne viene aggiunto uno nuovo
			int pos=0;

			if (valori.Trim()!="") 
			{
				foreach (string campo in Query)
				{
				
					string[] elamsCampo= campo.Split(sepDati);
					string idGlossario=elamsCampo[0];
					string ordinamento=elamsCampo[2];
					string strFiltri=elamsCampo[3];
					string nascosto=elamsCampo[4];
					string aggragazione=elamsCampo[5];

					if (nascosto=="0") nascosto="true";
					if (nascosto=="1") nascosto="false";
				
					//funzione che salva nella tabella [IL_SCHEMA_DETTAGLIO]

					InsertDettaglio(Convert.ToInt32(idGlossario), ordinamento,aggragazione,Convert.ToBoolean(nascosto),pos++);
							
					//estraggo i dati sui filtri
					if(strFiltri!=string.Empty)
					{
						string[] filtri = strFiltri.Split(sepFiltri);
						foreach (string filtro in filtri)
						{
							if(filtro != string.Empty)
							{
								string[] defFiltro = filtro.Split(sepElemFiltro);
								string idCriterio = defFiltro[0]; //se 0 è un nuovo filtro, altrimenti è >0
								string operatore = defFiltro[1]; 
								string valore1 = defFiltro[2]; 
								string valore2 = defFiltro[3]; 
								//funzione che salva nella tabella IL_SCHEMA_CRITERI
								InsertCriteri(Convert.ToInt32(idGlossario),operatore,valore1,valore2);					
							}
						}
					}
				}
			}
			IdQuery=NewIdQuery;
			((DefaultReport)Page).RicaricaLista();
		}

		private void InsertUpdateSchema(string titolo, string descrizione,bool salva)
		{
			ApplicationDataLayer.OracleDataLayer _OraDl;
			_OraDl = new OracleDataLayer(s_ConnStr);
			
			S_ControlsCollection param=new S_ControlsCollection();

			S_Object pIdSchema;
			pIdSchema= new S_Object();
			pIdSchema.ParameterName="pIdSchema";
			pIdSchema.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			pIdSchema.Direction=ParameterDirection.Input;
			if (salva)
				pIdSchema.Value=IdQuery;
			else
				pIdSchema.Value=0;
			pIdSchema.Index=0;
			param.Add (pIdSchema);

			
			S_Object pDenominazione;
			pDenominazione= new S_Object();
			pDenominazione.ParameterName="pDenominazione";
			pDenominazione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			pDenominazione.Direction=ParameterDirection.Input;
			pDenominazione.Size=100;
			pDenominazione.Index=1;
			if (salva)
				pDenominazione.Value=titolo;
			else
				if (txtHTitolo.Value==titolo)// Se sto copiando controllo se è stato cambiato il titolo
					pDenominazione.Value=" copia di " + titolo;
				else
					pDenominazione.Value=titolo;

			param.Add (pDenominazione);
			
			S_Object pDescrizione;
			pDescrizione= new S_Object();
			pDescrizione.ParameterName="pDescrizione";
			pDescrizione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			pDescrizione.Direction=ParameterDirection.Input;
			pDescrizione.Value=descrizione;
			pDescrizione.Size=1000;
			pDescrizione.Index=2;
			param.Add (pDescrizione);



			Hashtable _HS=(Hashtable) Session["ParametriSelectSchema"];
			int IdVista = Convert.ToInt32(_HS["IdVista"]);
			S_Object pIdVista = new S_Object();
			pIdVista.ParameterName="pIdVista";
			pIdVista.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			pIdVista.Direction=ParameterDirection.Input;
			pIdVista.Value=IdVista;
			pIdVista.Size=32;
			pIdVista.Index=3;
			param.Add(pIdVista);

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "putente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = 4;
			s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;
			param.Add (s_IdIn);

			S_Object pId;
			pId= new S_Object();
			pId.ParameterName="pId";
			pId.DbType = CustomDBType.Integer;
			pId.Direction=ParameterDirection.Output;
			pId.Size=32;
			pId.Index=5;
			param.Add (pId);
						
			//_OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.IL_SpInsertUpdateSchema");
			int	i_Result = _OraDl.GetRowsAffected(param, "IL_PACK_INTERROGAZIONI.IL_SpInsertUpdateSchema");
			IdQuery=i_Result;

			NewIdQuery = i_Result;//Convert.ToInt32(pId.Value);

		}

		private void DeleteDettaglio()
		{
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

			_OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.IL_SpDeleteDettaglio");

		}


		private void InsertDettaglio(int IdGlossario, string Ordinamento, string Funzione, bool Visibile, int Posizione)
		{
			ApplicationDataLayer.OracleDataLayer _OraDl;
			_OraDl = new OracleDataLayer(s_ConnStr);
			
			S_ControlsCollection param=new S_ControlsCollection();

			S_Object pIdSchema;
			pIdSchema= new S_Object();
			pIdSchema.ParameterName="pIdSchema";
			pIdSchema.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			pIdSchema.Size=32;
			pIdSchema.Direction=ParameterDirection.Input;
			pIdSchema.Value=IdQuery==0?NewIdQuery:IdQuery;
			pIdSchema.Index=0;
			param.Add (pIdSchema);
			
			S_Object pIdGlossario;
			pIdGlossario= new S_Object();
			pIdGlossario.ParameterName="pIdGlossario";
			pIdGlossario.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			pIdGlossario.Size=32;
			pIdGlossario.Direction=ParameterDirection.Input;
			pIdGlossario.Value=IdGlossario;
			pIdGlossario.Index=1;
			param.Add (pIdGlossario);
			
			S_Object pOrdinamento;
			pOrdinamento= new S_Object();
			pOrdinamento.ParameterName="pOrdinamento";
			pOrdinamento.Size=32;
			pOrdinamento.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			pOrdinamento.Direction=ParameterDirection.Input;
			pOrdinamento.Value=Ordinamento;
			pOrdinamento.Index=2;
			param.Add (pOrdinamento);
			
			S_Object pFunzione;
			pFunzione= new S_Object();
			pFunzione.ParameterName="pFunzione";
			pFunzione.Size=32;
			pFunzione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			pFunzione.Direction=ParameterDirection.Input;
			pFunzione.Value=Funzione;
			pFunzione.Index=3;
			param.Add (pFunzione);

			S_Object pVisibile;
			pVisibile= new S_Object();
			pVisibile.ParameterName="pVisibile";
			pVisibile.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			pVisibile.Size=32;
			pVisibile.Direction=ParameterDirection.Input;
			pVisibile.Value=Visibile?0:1;
			pVisibile.Index=4;
			param.Add (pVisibile);

			S_Object pPosizione;
			pPosizione= new S_Object();
			pPosizione.ParameterName="pPosizione";
			pPosizione.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			pPosizione.Size=32;
			pPosizione.Direction=ParameterDirection.Input;
			pPosizione.Value=Posizione;
			pPosizione.Index=5;
			param.Add (pPosizione);

			_OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.IL_SpInsertDettaglio");


		}
		

		private void DeleteCriteri()
		{
			ApplicationDataLayer.OracleDataLayer _OraDl;
			_OraDl = new OracleDataLayer(s_ConnStr);
			
			S_ControlsCollection param=new S_ControlsCollection();

			S_Object pIdSchema;
			pIdSchema = new S_Object();
			pIdSchema.ParameterName="pIdSchema";
			pIdSchema.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			pIdSchema.Direction=ParameterDirection.Input;
			pIdSchema.Value=IdQuery;
			pIdSchema.Size=32;
			pIdSchema.Index=5;
			param.Add (pIdSchema);
			
			S_Object DirParam;
			DirParam = new S_Object();
			DirParam.ParameterName="pId";
			DirParam.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			DirParam.Direction=ParameterDirection.Output;
			DirParam.Value=DBNull.Value;
			DirParam.Size=32;
			DirParam.Index=1;
			param.Add (DirParam);

			_OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.IL_SpDeleteFiltri");


		}

		private void InsertCriteri(int idGlossario, string operatore, string val1, string val2)
		{
			ApplicationDataLayer.OracleDataLayer _OraDl;
			_OraDl = new OracleDataLayer(s_ConnStr);

			
			S_ControlsCollection param=new S_ControlsCollection();

			S_Object pIdSchema;
			pIdSchema = new S_Object();
			pIdSchema.ParameterName="pIdSchema";
			pIdSchema.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			pIdSchema.Direction=ParameterDirection.Input;
			pIdSchema.Value=IdQuery==0?NewIdQuery:IdQuery;
			pIdSchema.Index=0;
			pIdSchema.Size=32;
			param.Add (pIdSchema);

			S_Object pIdGlossario;
			pIdGlossario=new S_Object();
			pIdGlossario.ParameterName="pIdGlossario";
			pIdGlossario.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			pIdGlossario.Direction=ParameterDirection.Input;
			pIdGlossario.Value=idGlossario;
			pIdGlossario.Index=1;
			pIdGlossario.Size=32;
			param.Add (pIdGlossario);

			S_Object pOperatore;
			pOperatore=new S_Object();
			pOperatore.ParameterName="pOperatore";
			pOperatore.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			pOperatore.Direction=ParameterDirection.Input;
			pOperatore.Value=operatore;
			pOperatore.Index=2;
			pOperatore.Size=32;
			param.Add (pOperatore);

			S_Object pValore1;
			pValore1=new S_Object();
			pValore1.ParameterName="pValore1";
			pValore1.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			pValore1.Direction=ParameterDirection.Input;
			pValore1.Value=val1;
			pValore1.Index=3;
			pValore1.Size=32;
			param.Add (pValore1);

			S_Object pValore2;
			pValore2=new S_Object();
			pValore2.ParameterName="pValore2";
			pValore2.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			pValore2.Direction=ParameterDirection.Input;
			pValore2.Value=val2;
			pValore2.Index=4;
			pValore2.Size=32;
			param.Add (pValore2);

			S_Object DirParam;
			DirParam=new S_Object();
			DirParam.ParameterName="pId";
			DirParam.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DirParam.Direction=ParameterDirection.Output;
			DirParam.Value=DBNull.Value;
			DirParam.Index=5;
			DirParam.Size=32;
			param.Add (DirParam);

			_OraDl.ExecuteProcedure(param,"IL_PACK_INTERROGAZIONI.IL_SpInsertFiltro");

		}

		private void ButtonVisualizza_Click(object sender, System.EventArgs e)
		{
			Salva(true);
			this.Visible=true;
			Page.RegisterStartupScript("pippo","<script language='javascript'>OpenVisualizzazione();</script>");
		
		}

		private void BtnAnnulla_Click(object sender, System.EventArgs e)
		{
			((DefaultReport)Page).RicaricaLista();
			Ricarica();
		}

		private void BtnExcel_Click(object sender, System.EventArgs e)
		{
			
			Salva(true);
			Esport();			
//			Page.RegisterStartupScript("pippo","<script language='javascript'>OpenEsportazione();</script>");
			
		}
		private void Esport()
		{
			Hashtable _HS=(Hashtable) Session["ParametriSelectSchema"];
			string VISTA = Convert.ToString(_HS["NomeVista"]);
			int IdVista = Convert.ToInt32(_HS["IdVista"]);
			VISTA = " " + VISTA + " ";
			TheSite.GIC.App_Code.Consultazioni.interogazioni  DQ = new TheSite.GIC.App_Code.Consultazioni.interogazioni();
			DQ.VISTA = VISTA;
			DQ.IdVista= IdVista;
			DataSet Dt = DQ.GetData(IdQuery); 

			Csy.WebControls.Export 	_objExport = new Csy.WebControls.Export();
			DataTable _dt = new DataTable();			
			_dt = Dt.Tables[0].Copy();	
			if (_dt.Rows.Count != 0)
			{
				_objExport.ExportDetails(_dt, Csy.WebControls.Export.ExportFormat.Excel, "exp.xls" ); 		
			}
			else
			{
				String scriptString = "<script language=JavaScript>alert('Nessun elemento da esportare');";
				scriptString += "/";
				scriptString += "script>";
			
			}
		}

		private void BtnCopia_Click(object sender, System.EventArgs e)
		{
			Salva(false);
		}
	}
}
