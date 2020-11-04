using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using MyCollection;
using System.Reflection;

namespace TheSite.AnagrafeImpianti
{
	/// <summary>
	/// Descrizione di riepilogo per SfogliaRdl.
	/// </summary>
	public class RichiesteApparecchiatura : System.Web.UI.Page
	{
		protected S_Controls.S_TextBox txtsRichiesta;
		protected S_Controls.S_Button btnsRicerca;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_TextBox txtsOrdine;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.GridTitle GridTitle1;	
		protected WebControls.PageTitle PageTitle1;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;
		protected WebControls.Addetti Addetti1;
		

		public static int FunId = 0;
		protected S_Controls.S_ComboBox cmbsStatus;
		protected S_Controls.S_Button cmdExcel;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;			
		public static string HelpLink = string.Empty;
	
		MyCollection.clMyCollection _myColl = new MyCollection.clMyCollection();
		protected S_Controls.S_Label S_lblcodicecomponente;
		protected S_Controls.S_Label S_lblstdapparecchiature;
		protected S_Controls.S_Label S_lblcodiceedificio;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected Microsoft.Web.UI.WebControls.TabStrip TabStrip1;
		protected S_Controls.S_Label S_lbledificio;

		public MyCollection.clMyCollection _Contenitore
		{
			get 
			{
				if(this.ViewState["mioContenitore"]!=null)
					return (MyCollection.clMyCollection)this.ViewState["mioContenitore"];
				else
					return new MyCollection.clMyCollection();
			}
		}	

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			txtsRichiesta.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtsRichiesta.Attributes.Add("onpaste","return nonpaste();");
			txtsOrdine.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtsOrdine.Attributes.Add("onpaste","return nonpaste();");

			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;					

			if(!Page.IsPostBack)
			{
				
				#region Recupero la proprieta di ricerca
				// Recupero il tipo dall'oggetto context.
				Type myType=Context.Handler.GetType();       
				// recupero il PropertyInfo object passando il nome della proprietà da recuperare.
				PropertyInfo myPropInfo = myType.GetProperty("_Contenitore");
			
				// verifico che questa proprietà esista.
				if(myPropInfo!=null)
					this.ViewState.Add("mioContenitore",myPropInfo.GetValue(Context.Handler,null));

				//				this.ViewState.Add("mioContenitore",this.GetProperty(Context.Handler,"_Contenitore",new clMyCollection()));
				#endregion
				
				if (Context.Items["eq_id"]!=null)
					this.eq_id =(string)Context.Items["eq_id"];

				if (Context.Items["eq_id_char"]!=null)
					this.eq_id_char =(string)Context.Items["eq_id_char"];

				if (Request.QueryString["eq_id"]!=null)
				{
					this.eq_id =(string)Request.QueryString["eq_id"];				
				}
								
				// Carico i Dati dell'Apparecchiatura
				CaricaScheda();
				// Valorizzo l'Edificio per l'Addetto
				Addetti1.Set_BL_ID(S_lblcodiceedificio.Text);
				
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];
			
				CompareValidator1.ControlToValidate = CalendarPicker2.ID + ":" + CalendarPicker2.Datazione.ID;
				CompareValidator1.ControlToCompare =  CalendarPicker1.ID + ":" + CalendarPicker1.Datazione.ID;
				DataGridRicerca.Visible = false;				
				GridTitle1.hplsNuovo.Visible = false;
				GridTitle1.Visible =false;				
				BindStatus();
				Ricerca(0);			
			}			
		}

		private void BindStatus()
		{
			this.cmbsStatus.Items.Clear();
		
			Classi.ManOrdinaria.Richiesta  _Richiesta= new Classi.ManOrdinaria.Richiesta();
						
			DataSet Ds = _Richiesta.GetStatus();
		
			if (Ds.Tables[0].Rows.Count > 0)
			{
				this.cmbsStatus.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					Ds.Tables[0], "DESCRIZIONE", "ID", "- Selezionare uno Stato -", "");
				this.cmbsStatus.DataTextField = "DESCRIZIONE";
				this.cmbsStatus.DataValueField = "ID";
				this.cmbsStatus.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Stato -";
				this.cmbsStatus.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
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
			this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
			this.TabStrip1.SelectedIndexChange += new System.EventHandler(this.TabStrip1_SelectedIndexChange);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region proprietà

		private string eq_id
		{
			get 
			{
				if(ViewState["s_eq_id"]==null)
					 return string.Empty;
				 else
					 return (String) ViewState["s_eq_id"];
			}
			set 
			{
				if (value==null)
					ViewState["s_eq_id"] = string.Empty;
				else
					ViewState["s_eq_id"] = value;
			}
		}

		private string eq_id_char
		{
			get 
			{
				if(ViewState["s_eq_id_char"]==null)
					return string.Empty;
				else
					return (String) ViewState["s_eq_id_char"];
			}
			set 
			{
				if (value==null)
					ViewState["s_eq_id_char"] = string.Empty;
				else
					ViewState["s_eq_id_char"] = value;
			}
		}
			

		
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{			
			Query();
		}

		#region Funzioni Private
			
		private void Query()
		{
			if (TabStrip1.SelectedIndex==0)
				Ricerca(0);
			if (TabStrip1.SelectedIndex==1)
				Ricerca(Classi.TipoManutenzioneType.ManutenzionesuRichiesta);
			if (TabStrip1.SelectedIndex==2)
				Ricerca(Classi.TipoManutenzioneType.ManutenzioneProgrammata);
			if (TabStrip1.SelectedIndex==3)
				Ricerca(Classi.TipoManutenzioneType.ManutenzioneStraordinaria);				
		}

		private void Ricerca(Classi.TipoManutenzioneType t)
		{
			Classi.AnagrafeImpianti.Apparecchiature _Richiesta = new TheSite.Classi.AnagrafeImpianti.Apparecchiature();
			S_ControlsCollection _SCollection = new S_ControlsCollection();					
						
			S_Controls.Collections.S_Object s_p_Wr_Id = new S_Controls.Collections.S_Object();
			s_p_Wr_Id.ParameterName = "p_Wr_Id";
			s_p_Wr_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wr_Id.Direction = ParameterDirection.Input;
			s_p_Wr_Id.Index = 2;
			s_p_Wr_Id.Size=50;
			s_p_Wr_Id.Value = (this.txtsRichiesta.Text=="")?0:Int32.Parse(this.txtsRichiesta.Text);		
			_SCollection.Add(s_p_Wr_Id);

			S_Controls.Collections.S_Object s_p_Addetto = new S_Controls.Collections.S_Object();
			s_p_Addetto.ParameterName = "p_Addetto";
			s_p_Addetto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Addetto.Direction = ParameterDirection.Input;
			s_p_Addetto.Index = 3;
			s_p_Addetto.Size=50;
			s_p_Addetto.Value = this.Addetti1.NomeCompleto;			
			_SCollection.Add(s_p_Addetto);

			S_Controls.Collections.S_Object s_p_DataDa = new S_Controls.Collections.S_Object();
			s_p_DataDa.ParameterName = "p_DataDa";
			s_p_DataDa.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataDa.Direction = ParameterDirection.Input;
			s_p_DataDa.Index = 4;
			s_p_DataDa.Size= 10;
			s_p_DataDa.Value = (CalendarPicker1.Datazione.Text =="")? "":CalendarPicker1.Datazione.Text;  			
			_SCollection.Add(s_p_DataDa);

			S_Controls.Collections.S_Object s_p_DataA = new S_Controls.Collections.S_Object();
			s_p_DataA.ParameterName = "p_DataA";
			s_p_DataA.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataA.Direction = ParameterDirection.Input;
			s_p_DataA.Index = 5;
			s_p_DataA.Size= 10;
			s_p_DataA.Value = (CalendarPicker2.Datazione.Text =="")? "":CalendarPicker2.Datazione.Text;  			
			_SCollection.Add(s_p_DataA);

			S_Controls.Collections.S_Object s_p_Wo_Id = new S_Controls.Collections.S_Object();
			s_p_Wo_Id.ParameterName = "p_Wo_Id";
			s_p_Wo_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wo_Id.Direction = ParameterDirection.Input;
			s_p_Wo_Id.Index = 6;
			s_p_Wo_Id.Size=50;
			s_p_Wo_Id.Value = (this.txtsOrdine.Text=="")?0:Int32.Parse(this.txtsOrdine.Text);		
			_SCollection.Add(s_p_Wo_Id);
						
			S_Controls.Collections.S_Object s_p_Status = new S_Controls.Collections.S_Object();
			s_p_Status.ParameterName = "p_Status";
			s_p_Status.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Status.Direction = ParameterDirection.Input;
			s_p_Status.Index = 8;
			s_p_Status.Value = (cmbsStatus.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsStatus.SelectedValue);			
			_SCollection.Add(s_p_Status);

			S_Controls.Collections.S_Object s_p_eq = new S_Controls.Collections.S_Object();
			s_p_eq.ParameterName = "p_eq";
			s_p_eq.DbType = CustomDBType.Integer;
			s_p_eq.Direction = ParameterDirection.Input;
			s_p_eq.Index = 9;
			s_p_eq.Value = this.eq_id;			
			s_p_eq.Size = 50;
			_SCollection.Add(s_p_eq);

			S_Controls.Collections.S_Object s_TipoManutenzione = new S_Controls.Collections.S_Object();
			s_TipoManutenzione.ParameterName = "p_TipoManutenzione";
			s_TipoManutenzione.DbType = CustomDBType.Integer;
			s_TipoManutenzione.Direction = ParameterDirection.Input;
			s_TipoManutenzione.Index = 10;
			s_TipoManutenzione.Size=4;
			s_TipoManutenzione.Value=t;						
			_SCollection.Add(s_TipoManutenzione);			
			
			DataSet _MyDs = _Richiesta.GetSfogliaRDLEQ(_SCollection,DataGridRicerca.PageSize,DataGridRicerca.CurrentPageIndex).Copy();		
			
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];

			DataGridRicerca.Visible = true;
			GridTitle1.Visible =true;
			if (_MyDs.Tables[0].Rows.Count == 0 )
			{
				DataGridRicerca.CurrentPageIndex=0;
				GridTitle1.DescriptionTitle="Nessun dato trovato."; 
			}
			else
			{
				GridTitle1.DescriptionTitle=""; 
				int Pagina = 0;
				if ((_MyDs.Tables[0].Rows.Count % DataGridRicerca.PageSize) >0)
				{
					Pagina ++;
				}
				if (DataGridRicerca.PageCount != Convert.ToInt16((_MyDs.Tables[0].Rows.Count / DataGridRicerca.PageSize) + Pagina))
				{					
					DataGridRicerca.CurrentPageIndex=0;					
				}
			}
			
			this.DataGridRicerca.DataBind();
			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();			

			//long tot = CalcolaTot();
			//ImpostaPagine(tot);
			
		}

		private long CalcolaTot()
		{
			Classi.AnagrafeImpianti.Apparecchiature _Richiesta = new TheSite.Classi.AnagrafeImpianti.Apparecchiature();
			S_ControlsCollection _SCollection = new S_ControlsCollection();					
						
			S_Controls.Collections.S_Object s_p_Wr_Id = new S_Controls.Collections.S_Object();
			s_p_Wr_Id.ParameterName = "p_Wr_Id";
			s_p_Wr_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wr_Id.Direction = ParameterDirection.Input;
			s_p_Wr_Id.Index = 2;
			s_p_Wr_Id.Size=50;
			s_p_Wr_Id.Value = (this.txtsRichiesta.Text=="")?0:Int32.Parse(this.txtsRichiesta.Text);		
			_SCollection.Add(s_p_Wr_Id);

			S_Controls.Collections.S_Object s_p_Addetto = new S_Controls.Collections.S_Object();
			s_p_Addetto.ParameterName = "p_Addetto";
			s_p_Addetto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Addetto.Direction = ParameterDirection.Input;
			s_p_Addetto.Index = 3;
			s_p_Addetto.Size=50;
			s_p_Addetto.Value = this.Addetti1.NomeCompleto;			
			_SCollection.Add(s_p_Addetto);

			S_Controls.Collections.S_Object s_p_DataDa = new S_Controls.Collections.S_Object();
			s_p_DataDa.ParameterName = "p_DataDa";
			s_p_DataDa.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataDa.Direction = ParameterDirection.Input;
			s_p_DataDa.Index = 4;
			s_p_DataDa.Size= 10;
			s_p_DataDa.Value = (CalendarPicker1.Datazione.Text =="")? "":CalendarPicker1.Datazione.Text;  			
			_SCollection.Add(s_p_DataDa);

			S_Controls.Collections.S_Object s_p_DataA = new S_Controls.Collections.S_Object();
			s_p_DataA.ParameterName = "p_DataA";
			s_p_DataA.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataA.Direction = ParameterDirection.Input;
			s_p_DataA.Index = 5;
			s_p_DataA.Size= 10;
			s_p_DataA.Value = (CalendarPicker2.Datazione.Text =="")? "":CalendarPicker2.Datazione.Text;  			
			_SCollection.Add(s_p_DataA);

			S_Controls.Collections.S_Object s_p_Wo_Id = new S_Controls.Collections.S_Object();
			s_p_Wo_Id.ParameterName = "p_Wo_Id";
			s_p_Wo_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wo_Id.Direction = ParameterDirection.Input;
			s_p_Wo_Id.Index = 6;
			s_p_Wo_Id.Size=50;
			s_p_Wo_Id.Value = (this.txtsOrdine.Text=="")?0:Int32.Parse(this.txtsOrdine.Text);		
			_SCollection.Add(s_p_Wo_Id);
						
			S_Controls.Collections.S_Object s_p_Status = new S_Controls.Collections.S_Object();
			s_p_Status.ParameterName = "p_Status";
			s_p_Status.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Status.Direction = ParameterDirection.Input;
			s_p_Status.Index = 8;
			s_p_Status.Value = (cmbsStatus.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsStatus.SelectedValue);			
			_SCollection.Add(s_p_Status);
			
			DataSet _MyDsTot = _Richiesta.GetTotRDLEQ(_SCollection,DataGridRicerca.PageSize,DataGridRicerca.CurrentPageIndex).Copy();		
			DataRow _DR = _MyDsTot.Tables[0].Rows[0];
			return long.Parse(_DR[0].ToString());
		}

		private void cmdExcel_Click(object sender, System.EventArgs e)
		{
			Csy.WebControls.Export 	_objExport = new Csy.WebControls.Export();
			DataTable _dt = new DataTable();			

			if (TabStrip1.SelectedIndex==0)
				_dt =GetWordExcel(0).Tables[0].Copy();
			if (TabStrip1.SelectedIndex==1)
				_dt = GetWordExcel(Classi.TipoManutenzioneType.ManutenzionesuRichiesta).Tables[0].Copy();
			if (TabStrip1.SelectedIndex==2)
				_dt = GetWordExcel(Classi.TipoManutenzioneType.ManutenzioneProgrammata).Tables[0].Copy();
			if (TabStrip1.SelectedIndex==3)
				_dt = GetWordExcel(Classi.TipoManutenzioneType.ManutenzioneStraordinaria).Tables[0].Copy();				
			
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
		
		

		public DataSet GetWordExcel(Classi.TipoManutenzioneType t)
		{
			Classi.AnagrafeImpianti.Apparecchiature  _Richiesta = new TheSite.Classi.AnagrafeImpianti.Apparecchiature();
			S_ControlsCollection _SCollection = new S_ControlsCollection();			

			S_Controls.Collections.S_Object s_p_Wr_Id = new S_Controls.Collections.S_Object();
			s_p_Wr_Id.ParameterName = "p_Wr_Id";
			s_p_Wr_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wr_Id.Direction = ParameterDirection.Input;
			s_p_Wr_Id.Index = 2;
			s_p_Wr_Id.Size=50;
			s_p_Wr_Id.Value = (this.txtsRichiesta.Text=="")?0:Int32.Parse(this.txtsRichiesta.Text);		
			_SCollection.Add(s_p_Wr_Id);

			S_Controls.Collections.S_Object s_p_Addetto = new S_Controls.Collections.S_Object();
			s_p_Addetto.ParameterName = "p_Addetto";
			s_p_Addetto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Addetto.Direction = ParameterDirection.Input;
			s_p_Addetto.Index = 3;
			s_p_Addetto.Size=50;
			s_p_Addetto.Value = this.Addetti1.NomeCompleto;			
			_SCollection.Add(s_p_Addetto);

			S_Controls.Collections.S_Object s_p_DataDa = new S_Controls.Collections.S_Object();
			s_p_DataDa.ParameterName = "p_DataDa";
			s_p_DataDa.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataDa.Direction = ParameterDirection.Input;
			s_p_DataDa.Index = 4;
			s_p_DataDa.Size= 10;
			s_p_DataDa.Value = (CalendarPicker1.Datazione.Text =="")? "":CalendarPicker1.Datazione.Text;  			
			_SCollection.Add(s_p_DataDa);

			S_Controls.Collections.S_Object s_p_DataA = new S_Controls.Collections.S_Object();
			s_p_DataA.ParameterName = "p_DataA";
			s_p_DataA.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DataA.Direction = ParameterDirection.Input;
			s_p_DataA.Index = 5;
			s_p_DataA.Size= 10;
			s_p_DataA.Value = (CalendarPicker2.Datazione.Text =="")? "":CalendarPicker2.Datazione.Text;  			
			_SCollection.Add(s_p_DataA);

			S_Controls.Collections.S_Object s_p_Wo_Id = new S_Controls.Collections.S_Object();
			s_p_Wo_Id.ParameterName = "p_Wo_Id";
			s_p_Wo_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Wo_Id.Direction = ParameterDirection.Input;
			s_p_Wo_Id.Index = 6;
			s_p_Wo_Id.Size=50;
			s_p_Wo_Id.Value = (this.txtsOrdine.Text=="")?0:Int32.Parse(this.txtsOrdine.Text);		
			_SCollection.Add(s_p_Wo_Id);
						
			S_Controls.Collections.S_Object s_p_Status = new S_Controls.Collections.S_Object();
			s_p_Status.ParameterName = "p_Status";
			s_p_Status.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Status.Direction = ParameterDirection.Input;
			s_p_Status.Index = 8;
			s_p_Status.Value = (cmbsStatus.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsStatus.SelectedValue);			
			_SCollection.Add(s_p_Status);			

			
			S_Controls.Collections.S_Object s_p_eq = new S_Controls.Collections.S_Object();
			s_p_eq.ParameterName = "p_eq";
			s_p_eq.DbType = CustomDBType.Integer;
			s_p_eq.Direction = ParameterDirection.Input;
			s_p_eq.Index = 9;
			s_p_eq.Value = this.eq_id;			
			s_p_eq.Size = 50;
			_SCollection.Add(s_p_eq);

			S_Controls.Collections.S_Object s_TipoManutenzione = new S_Controls.Collections.S_Object();
			s_TipoManutenzione.ParameterName = "p_TipoManutenzione";
			s_TipoManutenzione.DbType = CustomDBType.Integer;
			s_TipoManutenzione.Direction = ParameterDirection.Input;
			s_TipoManutenzione.Index = 10;
			s_TipoManutenzione.Size=4;
			s_TipoManutenzione.Value=t;						
			_SCollection.Add(s_TipoManutenzione);			
		
			return  _Richiesta.GetSfogliaRDLEQ(_SCollection).Copy();		
		}
		
		private void CaricaScheda()
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new  S_Controls.Collections.S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_p_eq_std = new S_Controls.Collections.S_Object();
			s_p_eq_std.ParameterName = "p_eq_std";
			s_p_eq_std.DbType = CustomDBType.VarChar;
			s_p_eq_std.Direction = ParameterDirection.Input;
			s_p_eq_std.Index = 0;
			s_p_eq_std.Value = this.eq_id_char;			
			s_p_eq_std.Size = 50;
			CollezioneControlli.Add(s_p_eq_std);

			Classi.ClassiDettaglio.SchedaApparecchiatura  _SchedaApparecchiatura =new Classi.ClassiDettaglio.SchedaApparecchiatura(""); 

			DataSet Ds = _SchedaApparecchiatura.GetData(CollezioneControlli);
			if (Ds.Tables[0].Rows.Count>0)
			{
				S_lblcodicecomponente.Text=Ds.Tables[0].Rows[0]["var_eq_eq_id"].ToString();
				S_lblstdapparecchiature.Text=Ds.Tables[0].Rows[0]["var_eqstd_description"].ToString();
				S_lblcodiceedificio.Text=Ds.Tables[0].Rows[0]["var_eq_bl_id"].ToString();
				S_lbledificio.Text=Ds.Tables[0].Rows[0]["var_bl_name"].ToString();
			}
			else
			{
				S_lblcodicecomponente.Text="";
				S_lblstdapparecchiature.Text="";
				S_lblcodiceedificio.Text="";
				S_lbledificio.Text="";			
			}
		}


		private void ImpostaPagine(long totRecord)
		{
			
		}
		#endregion

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			Query();
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{ 
				string descrizione="";
				string appodescrizione=e.Item.Cells[7].Text.Trim();
				
				if (e.Item.Cells[7].Text.Trim().Length > 20) 
				{
					descrizione=e.Item.Cells[7].Text.Trim().Substring(0,17) + "..."; 					
					e.Item.Cells[7].Text=descrizione;
					e.Item.Cells[7].ToolTip=appodescrizione;
				} 
			}
		}			

		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("NavigazioneApparecchiature.aspx");
		}
		private void TabStrip1_SelectedIndexChange(object sender, System.EventArgs e)
		{			
			Query();
		}
	}
}
