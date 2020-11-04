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

namespace TheSite.ManutenzioneCorretiva
{
	/// <summary>
	/// Descrizione di riepilogo per AccorpaRdl.
	/// </summary>
	public class AccorpaRdl : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton RicAccorpante;
		protected System.Web.UI.WebControls.LinkButton RicAccorpate;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected S_Controls.S_TextBox txtRdl;

		protected WebControls.PageTitle PageTitle1;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.Addetti Addetti1;
		protected WebControls.Richiedenti Richiedenti1;
		public static int FunId = 0;
		protected S_Controls.S_Label lblDescription;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenVisible;
		protected System.Web.UI.WebControls.LinkButton VisualAccorpate;
		protected Csy.WebControls.DataPanel DataPanel1;
		protected S_Controls.S_TextBox txtsRichiesta;
		protected S_Controls.S_TextBox txtsOrdine;
		protected S_Controls.S_ComboBox cmbsStatus;
		protected S_Controls.S_ComboBox cmbsUrgenza;
		protected S_Controls.S_TextBox txtDescrizione;
		protected S_Controls.S_ComboBox cmbsGruppo;
		protected S_Controls.S_Button btnsRicerca;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected S_Controls.S_Button btAccorpa;
		protected System.Web.UI.HtmlControls.HtmlTable TableAccorpa;
		protected S_Controls.S_Label lblStato;
		protected S_Controls.S_Button btReset;
		protected S_Controls.S_Label lblPadreAccorpante;
		public static string HelpLink = string.Empty;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			txtRdl.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtRdl.Attributes.Add("onpaste","return nonpaste();");
			txtsRichiesta.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtsRichiesta.Attributes.Add("onpaste","return nonpaste();");
			txtsOrdine.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtsOrdine.Attributes.Add("onpaste","return nonpaste();");

			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];

			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			//Associazione del delegato a una funzione quando viene selezionato un edificio
			RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{ 
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"]; 

				if (Context.Items["ric"]!=null)
                    HiddenVisible.Value =(string)Context.Items["ric"];

				if (Request.QueryString["ric"]!=null)
					HiddenVisible.Value =Request.QueryString["ric"];

				if (Context.Items["rdl"]!=null)
					txtRdl.Text =(string)Context.Items["rdl"];
				
				DataPanel1.Visible =false;
				CompareValidator1.ControlToValidate = CalendarPicker2.ID + ":" + CalendarPicker2.Datazione.ID;
				CompareValidator1.ControlToCompare =  CalendarPicker1.ID + ":" + CalendarPicker1.Datazione.ID;
				DataGridRicerca.Visible = false;
				GridTitle1.Visible =false;
				GridTitle1.hplsNuovo.Visible = false;
				TableAccorpa.Visible =false;
				BindServizio("");
				BindGruppo();
				BindUrgenza();
				BindStatus();

				Session.Remove("CheckedList");
			}

			

			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("if (typeof(validaContenuto) == 'function') { ");
			sbValid.Append("if (validaContenuto() == false) { return false; }} ");
			sbValid.Append(this.Page.GetPostBackEventReference(this.RicAccorpate));
			sbValid.Append(";");
			this.RicAccorpate.Attributes.Add("onclick", sbValid.ToString());

			GridTitle1.hplsNuovo.Visible=false;
            GridTitle1.NumeroRecords="";
 
			SetVisible();
			

		}
	
		private void SetVisible()
		{

			if(HiddenVisible.Value =="1")
			{
				lblDescription.Text ="Visualizza Accorpate";
				cmbsStatus.Visible =false;
				lblStato.Visible =false;
			}
			else if(HiddenVisible.Value =="2")
				lblDescription.Text ="Criteri ricerca RdL Accorpante";
			else if(HiddenVisible.Value =="3")
				lblDescription.Text ="Criteri ricerca Accorpate";
           
			if(HiddenVisible.Value =="1" || HiddenVisible.Value =="2" || HiddenVisible.Value =="3")
			{
				DataPanel1.Visible =true;
//				DataGridRicerca.Visible=false;
//				GridTitle1.Visible =false;
			}
		}

		private void BindStatus()
		{
			this.cmbsStatus.Items.Clear();
		
			Classi.ManOrdinaria.Richiesta  _Richiesta= new Classi.ManOrdinaria.Richiesta();
			DataSet Ds = new DataSet();
			if (HiddenVisible.Value == "3")
			{
				Ds = _Richiesta.GetStatus();
			}
			else
			{
				Ds = _Richiesta.GetStatusAccorpa();
			}
			
		
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
	
		private void BindServizio(string CodEdificio)
		{
			Addetti1.Set_BL_ID(CodEdificio);

			DataGridRicerca.Visible = false;
			this.cmbsServizio.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			Classi.ClassiDettaglio.Servizi  _Servizio = new TheSite.Classi.ClassiDettaglio.Servizi(Context.User.Identity.Name);

			DataSet _MyDs;

			if (CodEdificio!="")
			{
				S_Controls.Collections.S_Object s_Bl_Id = new S_Object();
				s_Bl_Id.ParameterName = "p_Bl_Id";
				s_Bl_Id.DbType = CustomDBType.VarChar;
				s_Bl_Id.Direction = ParameterDirection.Input;
				s_Bl_Id.Index = 0;
				s_Bl_Id.Value =	CodEdificio;
				s_Bl_Id.Size = 8;

				
				S_Controls.Collections.S_Object s_ID_Servizio = new S_Object();
				s_ID_Servizio.ParameterName = "p_ID_Servizio";
				s_ID_Servizio.DbType = CustomDBType.Integer;
				s_ID_Servizio.Direction = ParameterDirection.Input;
				s_ID_Servizio.Index = 1;
				s_ID_Servizio.Value = 0;

				CollezioneControlli.Add(s_Bl_Id);				
				CollezioneControlli.Add(s_ID_Servizio);

				_MyDs = _Servizio.GetData(CollezioneControlli);
			}
			else
			{
				_MyDs = _Servizio.GetData();
			}

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "0");
				this.cmbsServizio.DataTextField = "DESCRIZIONE";
				this.cmbsServizio.DataValueField = "IDSERVIZIO";
				this.cmbsServizio.DataBind();
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio("Non Definito", "-1"));
			}
			else
			{
				string s_Messaggio = "Non Definito";
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messaggio, "-1"));
			}
		}
		private void BindGruppo()
		{
			this.cmbsGruppo.Items.Clear();
		
			Classi.ManOrdinaria.GestioneRdl _GestioneRdl= new Classi.ManOrdinaria.GestioneRdl(Context.User.Identity.Name);
			
			
			DataSet Ds = _GestioneRdl.GetGuppo();
		
			if (Ds.Tables[0].Rows.Count > 0)
			{
				this.cmbsGruppo.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					Ds.Tables[0], "descrizione", "richiedenti_tipo_id", "- Selezionare un Gruppo -", "");
				this.cmbsGruppo.DataTextField = "descrizione";
				this.cmbsGruppo.DataValueField = "richiedenti_tipo_id";
				this.cmbsGruppo.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Gruppo -";
				this.cmbsGruppo.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		private void BindUrgenza()
		{
			this.cmbsUrgenza.Items.Clear();
		
			Classi.ManOrdinaria.GestioneRdl _GestioneRdl= new Classi.ManOrdinaria.GestioneRdl(Context.User.Identity.Name);
			
			
			DataSet Ds = _GestioneRdl.GetUrgenza();
		
			if (Ds.Tables[0].Rows.Count > 0)
			{
				this.cmbsUrgenza.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					Ds.Tables[0], "descrizione", "id_priority", "- Selezionare una Urgenza -", "");
				this.cmbsUrgenza.DataTextField = "descrizione";
				this.cmbsUrgenza.DataValueField = "id_priority";
				this.cmbsUrgenza.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Urgenza -";
				this.cmbsUrgenza.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
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
			this.VisualAccorpate.Click += new System.EventHandler(this.VisualAccorpate_Click);
			this.RicAccorpante.Click += new System.EventHandler(this.RicAccorpante_Click);
			this.RicAccorpate.Click += new System.EventHandler(this.RicAccorpate_Click);
			this.btnsRicerca.Click += new System.EventHandler(this.btnsRicerca_Click);
			this.btReset.Click += new System.EventHandler(this.btReset_Click);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.btAccorpa.Click += new System.EventHandler(this.btAccorpa_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void RicAccorpate_Click(object sender, System.EventArgs e)
		{
			Context.Items["ric"]="3";
			Context.Items["rdl"]=txtRdl.Text;
			Server.Transfer("AccorpaRdl.aspx"); 
		}

		private void RicAccorpante_Click(object sender, System.EventArgs e)
		{
			Context.Items["ric"]="2";
			Server.Transfer("AccorpaRdl.aspx"); 
		}

		private void VisualAccorpate_Click(object sender, System.EventArgs e)
		{
			Context.Items["ric"]="1";
			Server.Transfer("AccorpaRdl.aspx");
		}

		private void RicercaAccorpante()
		{
		 Classi.ManProgrammata.AccorpaRdl _AccorpaRdl = new TheSite.Classi.ManProgrammata.AccorpaRdl(this.Context.User.Identity.Name);
		 S_ControlsCollection _SCollection = CreaCriteri();
		 DataSet Ds= _AccorpaRdl.Accorpante(_SCollection); 
		 BindRicerche(Ds);
		}

		private void RicercaAccorpate()
		{
		 Classi.ManProgrammata.AccorpaRdl  _AccorpaRdl = new TheSite.Classi.ManProgrammata.AccorpaRdl(this.Context.User.Identity.Name);
		 S_ControlsCollection _SCollection = CreaCriteri();
		 DataSet Ds= _AccorpaRdl.Accorpate(_SCollection); 
		 BindRicerche(Ds);
			
		}
		private void VisualizzaAccorpate()
		{
			Classi.ManProgrammata.AccorpaRdl  _AccorpaRdl = new TheSite.Classi.ManProgrammata.AccorpaRdl(this.Context.User.Identity.Name);
			S_ControlsCollection _SCollection = CreaCriteri();
			DataSet Ds= _AccorpaRdl.VisualizzaAccorpate(_SCollection); 
			BindRicerche(Ds);
		}
		private void BindRicerche(DataSet Ds)
		{
			if (Ds.Tables[0].Rows.Count >0)
			{
				GridTitle1.Visible =true;
				DataGridRicerca.Visible=true; 

				if(HiddenVisible.Value=="1")
					this.DataGridRicerca.Columns[6].HeaderText="Accorpante";
				else
					this.DataGridRicerca.Columns[6].HeaderText="Stato";

				DataGridRicerca.DataSource =Ds.Tables[0];
				this.DataGridRicerca.DataBind();
				this.GridTitle1.NumeroRecords = Ds.Tables[0].Rows.Count.ToString();
				if(HiddenVisible.Value=="3")
				{
					TableAccorpa.Visible =true;
					this.DataGridRicerca.Columns[0].Visible =true; 
					lblPadreAccorpante.Text=txtRdl.Text; 
				}
				else
				{
					this.DataGridRicerca.Columns[0].Visible =false;
					TableAccorpa.Visible =false;
				}
			}
			else
			{
				GridTitle1.Visible =false;
				DataGridRicerca.Visible=false; 
				TableAccorpa.Visible =false;
			}
		}

		private S_ControlsCollection CreaCriteri()
		{
		
									
			S_ControlsCollection _SCollection = new S_ControlsCollection();	
	
			S_Controls.Collections.S_Object s_p_Bl_Id = new S_Controls.Collections.S_Object();
			s_p_Bl_Id.ParameterName = "p_Bl_Id";
			s_p_Bl_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Bl_Id.Direction = ParameterDirection.Input;
			s_p_Bl_Id.Size =50;
			s_p_Bl_Id.Index = 0;
			s_p_Bl_Id.Value = RicercaModulo1.TxtCodice.Text;
			_SCollection.Add(s_p_Bl_Id);

			S_Controls.Collections.S_Object s_p_campus = new S_Controls.Collections.S_Object();
			s_p_campus.ParameterName = "p_campus";
			s_p_campus.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_campus.Direction = ParameterDirection.Input;
			s_p_campus.Index = 1;
			s_p_campus.Size=50;
			s_p_campus.Value = RicercaModulo1.TxtRicerca.Text;			
			_SCollection.Add(s_p_campus);

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
			
			S_Controls.Collections.S_Object s_p_Servizio = new S_Controls.Collections.S_Object();
			s_p_Servizio.ParameterName = "p_ID_Servizio";
			s_p_Servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Servizio.Direction = ParameterDirection.Input;
			s_p_Servizio.Index = 7;
			s_p_Servizio.Value = (cmbsServizio.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsServizio.SelectedValue);			
			_SCollection.Add(s_p_Servizio);

			S_Controls.Collections.S_Object s_p_Status = new S_Controls.Collections.S_Object();
			s_p_Status.ParameterName = "p_Status";
			s_p_Status.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Status.Direction = ParameterDirection.Input;
			s_p_Status.Index = 8;
			if(HiddenVisible.Value=="1")
			  s_p_Status.Value = 3;			
			else
			  s_p_Status.Value = (cmbsStatus.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsStatus.SelectedValue);
			_SCollection.Add(s_p_Status);

			S_Controls.Collections.S_Object s_p_Richiedente = new S_Controls.Collections.S_Object();
			s_p_Richiedente.ParameterName = "p_Richiedente";
			s_p_Richiedente.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Richiedente.Direction = ParameterDirection.Input;
			s_p_Richiedente.Index = 9;
			s_p_Richiedente.Size=50;
			s_p_Richiedente.Value = this.Richiedenti1.NomeCompleto;			
			_SCollection.Add(s_p_Richiedente);

			S_Controls.Collections.S_Object s_p_Priority = new S_Controls.Collections.S_Object();
			s_p_Priority.ParameterName = "p_Priority";
			s_p_Priority.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Priority.Direction = ParameterDirection.Input;
			s_p_Priority.Index = 10;
			s_p_Priority.Value = (cmbsUrgenza.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsUrgenza.SelectedValue);			
			_SCollection.Add(s_p_Priority);

			S_Controls.Collections.S_Object s_p_Descrizione = new S_Controls.Collections.S_Object();
			s_p_Descrizione.ParameterName = "p_Descrizione";
			s_p_Descrizione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_Descrizione.Direction = ParameterDirection.Input;
			s_p_Descrizione.Index = 11;
			s_p_Descrizione.Size= 255;
			s_p_Descrizione.Value = txtDescrizione.Text;			
			_SCollection.Add(s_p_Descrizione);

			S_Controls.Collections.S_Object s_p_Gruppo = new S_Controls.Collections.S_Object();
			s_p_Gruppo.ParameterName = "p_Gruppo";
			s_p_Gruppo.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Gruppo.Direction = ParameterDirection.Input;
			s_p_Gruppo.Index = 12;
			s_p_Gruppo.Value = (cmbsGruppo.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsGruppo.SelectedValue);			
			_SCollection.Add(s_p_Gruppo);
 
			if(HiddenVisible.Value=="3")
			{
				S_Controls.Collections.S_Object s_p_RDL_PADRE = new S_Controls.Collections.S_Object();
				s_p_RDL_PADRE.ParameterName = "p_RDL_PADRE";
				s_p_RDL_PADRE.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
				s_p_RDL_PADRE.Direction = ParameterDirection.Input;
				s_p_RDL_PADRE.Index = 13;
				s_p_RDL_PADRE.Size=50;
				s_p_RDL_PADRE.Value = (this.txtRdl.Text=="")?0:Int32.Parse(this.txtRdl.Text);		
				_SCollection.Add(s_p_RDL_PADRE);
			}

			return _SCollection;
		}
		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem)
			{
                DataRowView drv = (DataRowView)(e.Item.DataItem);
				Label  LaA=new Label();
				Label  La;
				switch (HiddenVisible.Value)
				{
					case "1": //Accorpante
						La=new Label();
						La.Text=drv["WO"].ToString(); 
						e.Item.Cells[1].Controls.Add(La);
						LaA.Text=drv["Accorpante"].ToString(); 
						e.Item.Cells[6].Controls.Add(LaA);    
						break;
					case "2": //Accorpante
						HyperLink L=new HyperLink();
						L.NavigateUrl="javascript:seleziona('" + drv["WR"].ToString() + "');";
						L.Text=drv["WO"].ToString(); 
				        e.Item.Cells[1].Controls.Add(L); 						
						LaA.Text=drv["Status"].ToString(); 
						e.Item.Cells[6].Controls.Add(LaA); 
						break;
					default:
						La=new Label();
						La.Text=drv["WO"].ToString(); 
						e.Item.Cells[1].Controls.Add(La);
						LaA.Text=drv["Status"].ToString(); 
						e.Item.Cells[6].Controls.Add(LaA); 
						break;
				}

				//RICECCO
				if(Session["CheckedList"]!=null)
				{	
					Hashtable _HS=(Hashtable) Session["CheckedList"];
					int id=Int32.Parse(drv["WR"].ToString());   
					if(_HS.ContainsKey(id))
					{						
						System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) e.Item.Cells[0].FindControl("ckaccorpate");																					
						
						cb.Checked=System.Boolean.Parse(_HS[id].ToString());						
					}
				}
			}

		}


		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			Session.Remove("CheckedList");
			DataGridRicerca.CurrentPageIndex =0;
			switch (HiddenVisible.Value)
			{
				case "2": //Accorpante
					RicercaAccorpante();
					break;
				case "3": //Accorpate
					RicercaAccorpate();
					break;
				default:
					VisualizzaAccorpate();
					break;
			}
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			switch (HiddenVisible.Value)
			{
				case "2": //Accorpante
					DataGridRicerca.CurrentPageIndex =e.NewPageIndex; 
					RicercaAccorpante();
					break;
				case "3": //Accorpate
					MemorizzaCheck();
					DataGridRicerca.CurrentPageIndex =e.NewPageIndex; 
					RicercaAccorpate();
					break;
				default:
					DataGridRicerca.CurrentPageIndex =e.NewPageIndex; 
					VisualizzaAccorpate();
					break;
			}
		}

		/// <summary>
		/// Salva il contenuto dei valori ceccati
		/// </summary>
		private void MemorizzaCheck()
		{	
			Hashtable _HS = new Hashtable();
			foreach(DataGridItem o_Litem in this.DataGridRicerca.Items)
			{	
				int id = Int32.Parse(o_Litem.Cells[3].Text);
				if(Session["CheckedList"]!=null)
					_HS=(Hashtable) Session["CheckedList"];
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[0].FindControl("ckaccorpate");											
				if(_HS.ContainsKey(id))
					_HS.Remove(id);								
				_HS.Add(id,cb.Checked);
				Session.Remove("CheckedList");
				Session.Add("CheckedList",_HS);
			}
		}

		private void btAccorpa_Click(object sender, System.EventArgs e)
		{
		  MemorizzaCheck();
			if(Session["CheckedList"]!=null)
			{
				Hashtable _HS=(Hashtable) Session["CheckedList"];
				IDictionaryEnumerator myEnumerator = _HS.GetEnumerator();
				

				Classi.ManProgrammata.AccorpaRdl    _AccorpaRdl = new TheSite.Classi.ManProgrammata.AccorpaRdl(this.Context.User.Identity.Name);
                _AccorpaRdl.beginTransaction();
				
				try
				{
					while ( myEnumerator.MoveNext())
					{
						if (Convert.ToBoolean(myEnumerator.Value)==false)
							continue;

						S_ControlsCollection CollezioneControlli = new S_ControlsCollection();	

						S_Controls.Collections.S_Object s_p_wr_padre = new S_Object();
						s_p_wr_padre.ParameterName = "p_wr_padre";
						s_p_wr_padre.DbType = CustomDBType.Integer;
						s_p_wr_padre.Direction = ParameterDirection.Input;
						s_p_wr_padre.Index = 0;
						s_p_wr_padre.Value = int.Parse(lblPadreAccorpante.Text);		
		                CollezioneControlli.Add(s_p_wr_padre);	
			
						S_Controls.Collections.S_Object s_p_wr_figlia = new S_Object();
						s_p_wr_figlia.ParameterName = "p_wr_figlia";
						s_p_wr_figlia.DbType = CustomDBType.Integer;
						s_p_wr_figlia.Direction = ParameterDirection.Input;
						s_p_wr_figlia.Index = 1;
						s_p_wr_figlia.Value = Convert.ToInt32(myEnumerator.Key);		
						CollezioneControlli.Add(s_p_wr_figlia);

						S_Controls.Collections.S_Object s_p_utente = new S_Object();
						s_p_utente.ParameterName = "p_utente";
						s_p_utente.DbType = CustomDBType.VarChar;
						s_p_utente.Direction = ParameterDirection.Input;
						s_p_utente.Index = 2;
						s_p_utente.Size=50; 
						s_p_utente.Value = Context.User.Identity.Name;		
						CollezioneControlli.Add(s_p_utente);
						
						_AccorpaRdl.Add(CollezioneControlli);
					}

					_AccorpaRdl.commitTransaction();

					Session.Remove("CheckedList");
					DataGridRicerca.CurrentPageIndex =0;
			        RicercaAccorpate();

				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message); 
//					_AccorpaRdl.rollbackTransaction(); 
				}
				

			}
		}

		private void btReset_Click(object sender, System.EventArgs e)
		{
			string redir=string.Empty;
			switch (HiddenVisible.Value)
			{
				case "1":
					redir="1";
					break;
				case "2":
					redir="2";
					break;
//				case "3":
//					Context.Items["ric"]="3";
//					break;
			}
			
		 Response.Redirect("AccorpaRdl.aspx?FunId=" + ViewState["FunId"]); 
		}
	}
}