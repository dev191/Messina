using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using S_Controls;
using S_Controls.Collections;
using MyCollection;
using ApplicationDataLayer.DBType;

namespace TheSite.SoddisfazioneCliente
{
	/// <summary>
	/// Descrizione di riepilogo per IndicePrestazione.
	/// </summary>
	public class IndicePrestazione : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cmbsAnno;
		protected System.Web.UI.WebControls.DropDownList cmbQuadrimestre;
		protected S_Controls.S_ComboBox cmbsIndice;
		protected System.Web.UI.WebControls.Panel PanelServizio;
		protected S_Controls.S_Button btnsRicerca;
		protected S_Controls.S_Button cmdExcel;
		protected S_Controls.S_Button btnReset;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_ComboBox cmbsPriorita;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1; 
		public static int FunId = 0;
		public static string HelpLink = string.Empty;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.

			this.GridTitle1.hplsNuovo.Visible =false;
			string _mypage="./SoddisfazioneCliente/IndicePrestazione.aspx";			
			Classi.SiteModule _SiteModule = new TheSite.Classi.SiteModule(_mypage);
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;

			if(!IsPostBack)
			{
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];
				BindAnno();
			}

		}
		void BindAnno()
		{
			Int32 i_anno = DateTime.Now.Year;
			Int16 i_index= 0;
			for (int counter = i_anno - 10;counter<= i_anno ; counter++)
			{
				cmbsAnno.Items.Add(counter.ToString());				
				if (i_anno == counter)
				{
					cmbsAnno.Items[i_index].Selected = true;
				}
				i_index ++;
			}
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
			this.btnsRicerca.Click += new System.EventHandler(this.btnsRicerca_Click);
			this.cmdExcel.Click += new System.EventHandler(this.cmdExcel_Click);
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			this.DataGridRicerca.CurrentPageIndex=0;
			BindData();
		}
		private void BindData()
		{
			DataSet _MyDs=GetData();
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();		
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();
			GridTitle1.Visible=true;
		}

		private DataSet GetData()
		{
			Classi.GiudizioCliente.Giudizio _ReportGiudizio = new Classi.GiudizioCliente.Giudizio();
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

	
			S_Controls.Collections.S_Object s_p_datada = new S_Controls.Collections.S_Object();
			s_p_datada.ParameterName = "p_anno";
			s_p_datada.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_datada.Direction = ParameterDirection.Input;
			s_p_datada.Index = 1;
			s_p_datada.Value =cmbsAnno.SelectedValue;		
			CollezioneControlli.Add(s_p_datada);
		

			S_Controls.Collections.S_Object s_p_dataa = new S_Controls.Collections.S_Object();
			s_p_dataa.ParameterName = "p_quadrimestre";
			s_p_dataa.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_dataa.Direction = ParameterDirection.Input;
			s_p_dataa.Index = 2;
			s_p_dataa.Value =cmbQuadrimestre.SelectedValue;	
			CollezioneControlli.Add(s_p_dataa);


			S_Controls.Collections.S_Object s_p_p_livello = new S_Controls.Collections.S_Object();
			s_p_p_livello.ParameterName = "p_priorita";
			s_p_p_livello.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_p_livello.Direction = ParameterDirection.Input;
			s_p_p_livello.Index = 4;
			s_p_p_livello.Value=0;//cmbsPriorita.SelectedValue;

			CollezioneControlli.Add(s_p_p_livello);

			S_Controls.Collections.S_Object s_p_Tipogiudizio = new S_Controls.Collections.S_Object();
			s_p_Tipogiudizio.ParameterName = "p_indice";
			s_p_Tipogiudizio.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Tipogiudizio.Direction = ParameterDirection.Input;
			s_p_Tipogiudizio.Index = CollezioneControlli.Count+1;
			s_p_Tipogiudizio.Value=cmbsIndice.SelectedValue;

			CollezioneControlli.Add(s_p_Tipogiudizio);


			DataSet _MyDs = _ReportGiudizio.GetIndicePriorita(CollezioneControlli).Copy();
			return _MyDs;
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType== ListItemType.Item || e.Item.ItemType== ListItemType.AlternatingItem)
			{
				DataRowView riga=(DataRowView)e.Item.DataItem;
				double val=double.Parse(riga["ip"].ToString());
				if(val==1)
					e.Item.Cells[4].BackColor =System.Drawing.Color.FromName("#66D71C");
				else if(val<1 && val>=0.80)
					e.Item.Cells[4].BackColor =System.Drawing.Color.FromName("#FCFC81");
				else if(val<0.80 && val>0.60)
					e.Item.Cells[4].BackColor =System.Drawing.Color.FromName("#FF3131"); 
				else if(val<0.60)
					e.Item.Cells[4].BackColor =System.Drawing.Color.FromName("#BB0000");  

                  e.Item.Cells[1].Text +="° Quadrimestre"; 
					
			}
		}
		private void cmdExcel_Click(object sender, System.EventArgs e)
		{
			Csy.WebControls.Export 	_objExport = new Csy.WebControls.Export();
			DataTable _dt = new DataTable();			
			
			_dt = GetData().Tables[0].Copy();	
			if (_dt.Rows.Count != 0)
			{
				_objExport.ExportDetails(_dt, Csy.WebControls.Export.ExportFormat.Excel, "exp.xls" ); 		
			}
			else
			{
				String scriptString = "<script language=JavaScript>alert('Nessun elemento da esportare');";
				scriptString += "<";
				scriptString += "/";
				scriptString += "script>";

				if(!this.IsClientScriptBlockRegistered("clientScriptexp"))
					this.RegisterStartupScript ("clientScriptexp", scriptString);
			}
			
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			try
			{
				this.DataGridRicerca.CurrentPageIndex=e.NewPageIndex;
				BindData();
			}
			catch(System.Web.HttpException ex)
			{
				Console.WriteLine(ex.Message);
				this.DataGridRicerca.CurrentPageIndex=0;
				BindData();
			}
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IndicePrestazione.aspx?FunId=" + FunId);
		}
	}
}
