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
using S_Controls.Collections;
using TheSite.AnagrafeImpianti; 
using Microsoft.Web.UI.WebControls;
using ApplicationDataLayer.DBType;


namespace TheSite.GestioneSpazi
{
	/// <summary>
	/// Descrizione di riepilogo per RicercaSpazi.
	/// </summary>
	public class RicercaSpazi : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected S_Controls.S_ListBox S_ListEdifici;
		protected S_Controls.S_Button S_btMostra;
		protected System.Web.UI.HtmlControls.HtmlInputHidden edifici;
		protected System.Web.UI.HtmlControls.HtmlInputHidden edificidescription;
		protected Csy.WebControls.DataPanel DataPanel1;
		protected WebControls.PageTitle PageTitle1;
		protected Microsoft.Web.UI.WebControls.TreeView TreeCtrl;

		protected System.Web.UI.WebControls.Panel Panel1;
		protected S_Controls.S_Label lblComuneDescrizione;
		protected S_Controls.S_Label lblComune;
		protected S_Controls.S_TextBox S_txtnomefile;
		protected S_Controls.S_TextBox S_txtdescrizione;
		protected S_Controls.S_ComboBox S_CbCategoria;
		protected S_Controls.S_ComboBox S_CmbTipologia;
		protected S_Controls.S_Button S_btRicerca;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected S_Controls.S_Button btReset;
		protected WebControls.UserStanze UserStanze1;

		public static string HelpLink = string.Empty;
		protected S_Controls.S_Label lblFrazione;
		protected S_Controls.S_Label lblFrazioneDescrizione;
		protected S_Controls.S_ComboBox S_ComboBox1;
		protected S_Controls.S_ComboBox cmbsPiano;
		protected S_Controls.S_ComboBox cmbsCategoria;
		public string descRep="";
		public string id=String.Empty;
		public string descUso1="";
		public string Usoid1=String.Empty;
		public string sql_select= String.Empty;
		public string sql_where= String.Empty;
		public string sql_group= String.Empty;
		public string sql= String.Empty;
		public string sqlCount = String.Empty;
		protected S_Controls.S_TextBox s_txtReparto;
		protected S_Controls.S_TextBox s_txtDestinazione;
		protected S_Controls.S_ComboBox cmbsConfronto;
		protected S_Controls.S_TextBox s_txtMq;
		protected System.Web.UI.WebControls.DataGrid DtgRicercaSpazi;
		protected WebControls.GridTitle GridTitle1;
		public static int FunId = 0;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkReparto;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkDestinazione;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkCategoria;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkPiano;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkEdificio;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkStanze;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chk_attiva;
		int startIndex = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
					

			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			S_ListEdifici.Attributes.Add("title","Premere il tasto canc per eliminare un elemento dalla lista.");  
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			SetProperty();
			if (!IsPostBack)
			{
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"]; 

				
				Panel1.Visible=false;
				BindTuttiPiani();
				BindTutteCategorie();
				GridTitle1.hplsNuovo.Visible=false;
				if (Request.QueryString["idcomune"]!=null)
					IdComune=int.Parse(Request.QueryString["idcomune"]);

				if (Request.QueryString["idfrazione"]!=null)
					IdFrazione=int.Parse(Request.QueryString["idfrazione"]);


				LoadComune();
								
			}
			
			RicercaModulo1.multisele="y&id_comune=" + IdComune.ToString() + "&id_frazione=" + IdFrazione.ToString();
			RicercaModulo1.visualizzadettagli=false;
			RicercaModulo1.ClasseTab = "tblSearch100DettaglioInv";
			UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
			UserStanze1.NameComboPiano="cmbsPiano";

			descRep=s_txtReparto.ClientID;
			descUso1=s_txtDestinazione.ClientID;
		}

		public int IdComune
		{
			get
			{
				if(ViewState["IdComune"]!=null)
					return (int)ViewState["IdComune"];
				else
					return 0;
			}
			set
			{ViewState.Add("IdComune",value);}
		}

		public int IdFrazione
		{
			get
			{
				if(ViewState["IdFrazione"]!=null)
					return (int)ViewState["IdFrazione"];
				else
					return 0;
			}
			set
			{ViewState.Add("IdFrazione",value);}
		}
		
		private void LoadComune()
		{
			if (IdComune==0) return;
			Classi.AnagrafeImpianti.ServiziEdifici _ServiziEdifici= new Classi.AnagrafeImpianti.ServiziEdifici(Context.User.Identity.Name);
			DataSet Ds= _ServiziEdifici.GetComuneFrazione(this.IdComune,this.IdFrazione);
			if (Ds.Tables[0].Rows.Count >0)
			{
				lblComuneDescrizione.Visible =true;
				lblComune.Visible =true;
				lblComune.Text=Ds.Tables[0].Rows[0]["descrizionec"].ToString();
				if(Ds.Tables[0].Rows[0]["descrizionef"]!=DBNull.Value && this.IdFrazione>0)
				{
					lblFrazioneDescrizione.Visible =true;
					lblFrazione.Visible =true;
					lblFrazione.Text=Ds.Tables[0].Rows[0]["descrizionef"].ToString();
				}
			}
			else
			{
				lblComuneDescrizione.Visible =false;
				lblComune.Visible =false;
				lblComune.Text="";

				lblFrazioneDescrizione.Visible =false;
				lblFrazione.Visible =false;
				lblFrazione.Text ="";
			}
 
		}
		private void SetProperty()
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];

			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
				

			S_ListEdifici.Attributes.Add("onkeydown","deleteitem(this,event);"); 
		

			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
            
			// sbValid.Append("if (errorlist('" + S_ListEdifici.ClientID  + "') == false)  return false;  ");
			// sbValid.Append("this.value = 'Attendere ...';");

			sbValid.Append("this.disabled = true;");

			sbValid.Append("document.getElementById('" + S_btMostra.ClientID + "').disabled = true;");
            
			sbValid.Append(this.Page.GetPostBackEventReference(this.S_btMostra));
			sbValid.Append(";");
			this.S_btMostra.Attributes.Add("onclick", sbValid.ToString());

			
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
			this.cmbsPiano.SelectedIndexChanged += new System.EventHandler(this.cmbsServizio_SelectedIndexChanged);
			this.S_btMostra.Click += new System.EventHandler(this.S_btMostra_Click);
			this.btReset.Click += new System.EventHandler(this.btReset_Click);
			this.DtgRicercaSpazi.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DtgRicercaSpazi_PageIndexChanged);
			this.DtgRicercaSpazi.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DtgRicercaSpazi_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void S_btMostra_Click(object sender, System.EventArgs e)
		{
			DtgRicercaSpazi.CurrentPageIndex =0; 
			LoadList();
			BindingEdifici(edifici.Value,true);
		}

		private void LoadList()
		{
			Console.WriteLine(edifici.Value);  
			string[] Ite =edificidescription.Value.Split(new char[] {'$'});
			string[] Itevalue =edifici.Value.Split(new char[] {','});
			S_ListEdifici.Items.Clear(); 
			Int32 j=0;
            
			if (Itevalue[0].ToString()!="")
			{
				foreach (string itestr in Itevalue)
				{
					S_ListEdifici.Items.Add(new ListItem(Ite[j],itestr )); 
					j+=1;
				}
			}
			
		}
		private void BindingEdifici(string BlId, bool reset)
		{
			if (BlId != "")
				BlId="'" + BlId.Replace(",","','") + "'";

			// da qui
      
			if (chkEdificio.Checked == true)
			{
				sql_select += " BL.BL_ID || ' - '  ||  BL.ADDRESS1 as EDIFICIO" ;
				sql_group += " BL.BL_ID || ' - '  ||  BL.ADDRESS1";
			}

			if (chkPiano.Checked == true)
			{
				if (sql_select!="")
					sql_select += ",";
				if (sql_group!="")
					sql_group += ",";

				sql_select += " PIANI.DESCRIZIONE as PIANO ";
				sql_group += " PIANI.DESCRIZIONE ";
			}

			if (chkStanze.Checked == true)
			{
				if (sql_select!="")
					sql_select += ",";
				if (sql_group!="")
					sql_group += ",";

				sql_select += "RM.RM_ID || '-'  || RM.DESCRIZIONE as STANZA ";
				sql_group += " RM.RM_ID,RM.DESCRIZIONE ";
			}

			if (chkCategoria.Checked == true)
			{
				if (sql_select!="")
					sql_select += ",";
				if (sql_group!="")
					sql_group += ",";

				sql_select += "RM_CAT.CODICE_CATEGORIA || '-'  || RM_CAT.DESCRIZIONE  as CATEGORIA ";
				sql_group += " RM_CAT.CODICE_CATEGORIA, RM_CAT.DESCRIZIONE ";
			}

			if (chkDestinazione.Checked == true)
			{
				if (sql_select!="")
					sql_select += ",";
				if (sql_group!="")
					sql_group += ",";

				sql_select += " RM_DEST_USO.DESCRIZIONE as DESTINAZIONE ";
				sql_group += " RM_DEST_USO.DESCRIZIONE ";
			}
 
			if (chkReparto.Checked == true)
			{
				if (sql_select!="")
					sql_select += ",";
				if (sql_group!="")
					sql_group += ",";

				sql_select += " RM_REPARTO.DESCRIZIONE as REPARTO ";
				sql_group += " RM_REPARTO.DESCRIZIONE ";
			}

			// a  qui 

			if ( BlId != "")
			{
				if (sql_where != "")
					sql_where += " AND";
				sql_where += " UPPER(BL.BL_ID) in (" + BlId.ToUpper() + ") ";
			}

			if (cmbsPiano.SelectedValue != String.Empty)
			{
				if (sql_where != "")
					sql_where += " AND";
				sql_where += " ID_PIANI =" + cmbsPiano.SelectedValue.ToString() ;
			}

			if (UserStanze1.DescStanza.ToString() !="")
			{
				if (sql_where != "")
					sql_where += " AND";
				sql_where += " UPPER(RM.RM_ID ||'-'|| RM.DESCRIZIONE) like '%" + UserStanze1.DescStanza.ToUpper() + "%'" ;
			}

			if (cmbsCategoria.SelectedValue != String.Empty)
			{
				if (sql_where != "")
					sql_where += " AND";
				sql_where += " RM_CAT.ID_RM_CAT=" + cmbsCategoria.SelectedValue.ToString() ;
			}

			if (s_txtReparto.Text != String.Empty)
			{
				if (sql_where != "")
					sql_where += " AND";
				sql_where += " UPPER(RM_REPARTO.DESCRIZIONE) like '%" + s_txtReparto.Text.ToUpper() + "%'" ;
			}
			
			if (s_txtDestinazione.Text !=String.Empty)
			{
				if (sql_where != "")
					sql_where += " AND";
				sql_where += " UPPER(RM_DEST_USO.DESCRIZIONE) like '%" + s_txtDestinazione.Text.ToUpper() + "%'" ;
			}
			
			if (cmbsConfronto.SelectedValue != String.Empty & s_txtMq.Text!= String.Empty)
			{
				if (sql_where != "")
					sql_where += " AND";
				//s_txtMq.Text.Replace(",",".");
				sql_where += " RM.AREA " + cmbsConfronto.SelectedValue + " " + s_txtMq.Text.Replace(",",".");
			}

			if (sql_where != "")
				sql_where = " WHERE " + sql_where; 
			///select finale da passare alla store procedure
			if (sql_select!="")
				sql_select += ", ";
			sql="SELECT " + sql_select + " SUM(RM.AREA) as VALORE_INT FROM BL JOIN FL ON (FL.Id_Bl = BL.Id) " + 
				"JOIN RM USING (id_piani, id_bl) JOIN PIANI ON (id_piani = PIANI.id) " +
				"left JOIN RM_REPARTO ON (RM.ID_RM_REPARTO = RM_REPARTO.ID_RM_REPARTO) " +
				"left JOIN RM_DEST_USO ON (RM.ID_RM_DEST_USO = RM_DEST_USO.ID_RM_DEST_USO) " +
				" left JOIN RM_CAT ON (RM.ID_RM_CAT = RM_CAT.ID_RM_CAT) " + sql_where  ;
			if (sql_group!="")
				sql += " GROUP BY " + sql_group ; 

//			sqlCount = "SELECT count(distinct RM.RM_ID)  FROM BL JOIN FL ON (FL.Id_Bl = BL.Id) " + 
//				"JOIN RM USING (id_piani, id_bl) JOIN PIANI ON (id_piani = PIANI.id) " +
//				"left JOIN RM_REPARTO ON (RM.ID_RM_REPARTO = RM_REPARTO.ID_RM_REPARTO) " +
//				"left JOIN RM_DEST_USO ON (RM.ID_RM_DEST_USO = RM_DEST_USO.ID_RM_DEST_USO) " +
//				" left JOIN RM_CAT ON (RM.ID_RM_CAT = RM_CAT.ID_RM_CAT) " + sql_where   ;

			//			///Istanzio un nuovo oggetto Collection per aggiungere i parametri
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();
			//			///creo i parametri		
			///edifici
			S_Controls.Collections.S_Object s_sql = new S_Controls.Collections.S_Object();
			s_sql.ParameterName = "p_sql";
			s_sql.DbType =CustomDBType.VarChar;
			s_sql.Direction = ParameterDirection.Input;
			s_sql.Size =4000;
			s_sql.Index = 0;
			s_sql.Value = sql;
			_SCollection.Add(s_sql);	

			// nuovi parametri paginazione

			S_Controls.Collections.S_Object s_p_pageindex = new S_Object();
			s_p_pageindex.ParameterName = "pageindex";
			s_p_pageindex.DbType = CustomDBType.Integer;
			s_p_pageindex.Direction = ParameterDirection.Input;
			s_p_pageindex.Index = 16;
			s_p_pageindex.Value=DtgRicercaSpazi.CurrentPageIndex +1;			
			_SCollection.Add(s_p_pageindex);

			S_Controls.Collections.S_Object s_p_pagesize = new S_Object();
			s_p_pagesize.ParameterName = "pagesize";
			s_p_pagesize.DbType = CustomDBType.Integer;
			s_p_pagesize.Direction = ParameterDirection.Input;
			s_p_pagesize.Index = 17;
			s_p_pagesize.Value= DtgRicercaSpazi.PageSize;			
			_SCollection.Add(s_p_pagesize);

			Classi.AnagrafeImpianti.ServiziEdifici _ServiziEdifici= new Classi.AnagrafeImpianti.ServiziEdifici(Context.User.Identity.Name);
  
			DataSet Ds=_ServiziEdifici.GetRicerca(_SCollection);

			if (reset )
			{
				_SCollection.Clear();

				///edifici
				S_Controls.Collections.S_Object s_sqlCount = new S_Controls.Collections.S_Object();
				s_sqlCount.ParameterName = "p_sql";
				s_sqlCount.DbType =CustomDBType.VarChar;
				s_sqlCount.Direction = ParameterDirection.Input;
				s_sqlCount.Size =4000;
				s_sqlCount.Index = 0;
				s_sqlCount.Value = sql;
				_SCollection.Add(s_sqlCount);	


				int _totalRecords = _ServiziEdifici.GetRicercaCount(_SCollection);
				this.GridTitle1.NumeroRecords=_totalRecords.ToString();

			}

			this.DtgRicercaSpazi.VirtualItemCount =int.Parse(this.GridTitle1.NumeroRecords);


			if (Ds.Tables[0].Rows.Count==0)
				Panel1.Visible=false;
//			{
//				int Pagina = 0;
//				if ((Ds.Tables[0].Rows.Count % DtgRicercaSpazi.PageSize) >0)
//				{
//					Pagina ++;
//				}
//				if (DtgRicercaSpazi.PageCount != Convert.ToInt16((Ds.Tables[0].Rows.Count / DtgRicercaSpazi.PageSize) + Pagina))
//				{					
//					DtgRicercaSpazi.CurrentPageIndex=0;					
//				}
		

			 
//			}
//			else
//			{
//				Panel1.Visible=false;
//			}
			Panel1.Visible=true;

			DtgRicercaSpazi.Visible=true;

			int conta =0;
			
			if (chkEdificio.Checked == false)
			{
				
				DtgRicercaSpazi.Columns.RemoveAt(0);
				conta +=1;
			}
			if (chkPiano.Checked == false)
			{
				 
				DtgRicercaSpazi.Columns.RemoveAt(1 - conta);
				conta +=1;
			}
			if (chkStanze.Checked == false)
			{
				
				DtgRicercaSpazi.Columns.RemoveAt(2 - conta);
				conta +=1;
			}
			if (chkCategoria.Checked == false)
			{
				
				DtgRicercaSpazi.Columns.RemoveAt(3 - conta);
				conta +=1;
			}
			if (chkDestinazione.Checked == false)
			{
				
				DtgRicercaSpazi.Columns.RemoveAt(4 - conta);
				conta +=1;

			}
			if (chkReparto.Checked == false)
			{
				
				DtgRicercaSpazi.Columns.RemoveAt(5 - conta);
				conta +=1;
			}
			if (chkEdificio.Checked == false && chkPiano.Checked == false && chkStanze.Checked == false && chkCategoria.Checked == false && chkDestinazione.Checked == false && chkReparto.Checked == false)
			{
				
				DtgRicercaSpazi.Columns.RemoveAt(6 - conta);
				//creo colonna vuota
				BoundColumn cl8=new BoundColumn();
				cl8.DataField="";
				cl8.HeaderText="";
				DtgRicercaSpazi.Columns.Add(cl8);

			}

			CalcolaTotali(Ds.Tables[0]);
			this.DtgRicercaSpazi.DataSource = Ds.Tables[0];
			
			DtgRicercaSpazi.DataBind();
		
			GridTitle1.DescriptionTitle="";
//			GridTitle1.NumeroRecords = Ds.Tables[0].Rows.Count.ToString();

		}

		private DataRowCollection DatiEdificio(Int32 bl_id)
		{
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.AnagrafeImpianti.ServiziEdifici  _ServiziEdifici = new Classi.AnagrafeImpianti.ServiziEdifici(Context.User.Identity.Name);

			DataSet Ds;				
			Ds = _ServiziEdifici.GetSingleData(bl_id);
			return Ds.Tables[0].Rows; 
		}

		private void cmbsServizio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			LoadList();
			//BindApparecchiatura();
		}

		private void btReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("RicercaSpazi.aspx?FunId=" + ViewState["FunId"]);
		}
		private void BindTuttiPiani()
		{
			this.cmbsPiano.Items.Clear();
		
			TheSite.Classi.ClassiAnagrafiche.Buildings  _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();
			
			DataSet	_MyDs = _Buildings.GetAllPiani();

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsPiano.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "");
				this.cmbsPiano.DataTextField = "DESCRIZIONE";
				this.cmbsPiano.DataValueField = "ID";
				this.cmbsPiano.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Piano -";
				this.cmbsPiano.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}
		
		private void BindTutteCategorie()
		{
			this.cmbsCategoria.Items.Clear();
		
			TheSite.Classi.ClassiAnagrafiche.Categorie  _Categorie = new TheSite.Classi.ClassiAnagrafiche.Categorie();
			
			DataSet	_MyDs = _Categorie.GetData();

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsCategoria.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "CATEGORIA", "ID", "- Selezionare la Categoria -", "");
				this.cmbsCategoria.DataTextField = "CATEGORIA";
				this.cmbsCategoria.DataValueField = "ID";
				this.cmbsCategoria.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Categoria -";
				this.cmbsCategoria.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		double totale=0;
		private void DtgRicercaSpazi_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{ 

			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				int colonna=DtgRicercaSpazi.Columns.Count;
				//e.Item.Cells[0].ColumnSpan=2; 
				if (colonna==1)
				{
					e.Item.Cells[colonna-1].Text ="<b>TOTALE GENERALE</b>" + "<b>&nbsp;&nbsp;&nbsp;"+ totale.ToString("#,##0.00") +"</b>";
					//e.Item.Cells[0].Text ="<b>"+ totale.ToString("C") +"</b>";
				}
				else
				{
					e.Item.Cells[0].Text= "<b>TOTALE GENERALE</b>";
					e.Item.Cells[colonna - 1].HorizontalAlign =HorizontalAlign.Right; 
					e.Item.Cells[colonna - 1].Text ="<b>"+ totale.ToString("#,##0.00") +"</b>";
				}
				
				
				//+ totpreventivo.ToString("C") +
				//e.Item.Cells[0].HorizontalAlign =HorizontalAlign.Right; 
				
				// + totconsuntivo.ToString("C")+
				//				e.Item.Cells[11].Visible=false;
				//				e.Item.Cells[12].Visible=false;

			}
		}

		private void CalcolaTotali(DataTable dt)
		{
			foreach(DataRow dr in dt.Rows)
			{
				if (dr["VALORE_INT"]!=DBNull.Value)
					totale+=double.Parse(dr["VALORE_INT"].ToString());
				
			}
		}


		public void DtgRicercaSpazi_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DtgRicercaSpazi.CurrentPageIndex= e.NewPageIndex;
			startIndex=DtgRicercaSpazi.CurrentPageIndex * DtgRicercaSpazi.PageSize;
			LoadList();
			BindingEdifici(edifici.Value, false);
		}

	}
}
