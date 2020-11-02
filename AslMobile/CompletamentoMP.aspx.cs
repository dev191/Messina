using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Mobile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient; 

namespace TheSite.AslMobile
{
	/// <summary>
	/// Descrizione di riepilogo per CompletamentoMP.
	/// </summary>
	public class CompletamentoMP : System.Web.UI.MobileControls.MobilePage
	{
		protected System.Web.UI.MobileControls.Panel pnlRicerca;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific1;
		protected System.Web.UI.MobileControls.Form Form1;

		private 	DropDownList p_cmbsServizio;
		private 	DropDownList p_cmbsDitta;
		private		DataGrid	 p_GridEdifici;
		private		DataGrid	 p_GridAddetti;
		private		DataGrid	 p_GridRisultati
		{
			get
			{
				if(ViewState["p_GridRisultati"]!=null)
					return (DataGrid)ViewState["p_GridRisultati"];
				else
					return null;
			}
			set
			{
				ViewState.Add("p_GridRisultati",value);
			}
		}
		private Hashtable _HS
		{
			get
			{
				if(ViewState["_HS"]!=null)
					return (Hashtable)ViewState["_HS"];
				else
					return null;
			}
			set
			{
				ViewState.Add("_HS",value);
			}
		}

		protected System.Web.UI.MobileControls.Form Form2;
		protected System.Web.UI.MobileControls.Panel pnlSelezione;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific2;
		protected System.Web.UI.MobileControls.Form Form3;
		protected System.Web.UI.MobileControls.Panel pnlRisultati;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific3;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific4;
		protected System.Web.UI.MobileControls.Panel Panel1;
		protected System.Web.UI.MobileControls.Form Form4;
		protected System.Web.UI.MobileControls.Link Link1;
		protected System.Web.UI.MobileControls.Link Link2;
		protected System.Web.UI.MobileControls.Form Form5;
		protected System.Web.UI.MobileControls.Panel Panel2;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific5;
		private		string		userName;
		private string txtDitta
		{
			get
			{
				if(ViewState["txtDitta"]!=null)
					return (string)ViewState["txtDitta"];
				else
					return string.Empty;
			}
			set
			{
				ViewState.Add("txtDitta",value);
			}
		}
		private string txtEdificio
		{
			get
			{
				if(ViewState["txtEdificio"]!=null)
					return (string)ViewState["txtEdificio"];
				else
					return string.Empty;
			}
			set
			{
				ViewState.Add("txtEdificio",value);
			}
		}

		private string dataDA
		{
			get
			{
				if(ViewState["dataDA"]!=null)
					return (string)ViewState["dataDA"];
				else
					return string.Empty;
			}
			set
			{
				ViewState.Add("dataDA",value);
			}
		}
		private string dataA
		{
			get
			{
				if(ViewState["dataA"]!=null)
					return (string)ViewState["dataA"];
				else
					return string.Empty;
			}
			set
			{
				ViewState.Add("dataA",value);
			}
		}

		private int id_ditta
		{
			get
			{
				if(ViewState["id_ditta"]!=null)
					return (int)ViewState["id_ditta"];
				else
					return 0;
			}
			set
			{
				ViewState.Add("id_ditta",value);
			}
		}
		private int id_servizio
		{
			get
			{
				if(ViewState["id_servizio"]!=null)
					return (int)ViewState["id_servizio"];
				else
					return 0;
			}
			set
			{
				ViewState.Add("id_servizio",value);
			}
		}

		private	   Repeater	 RepeaterMaster;
		private int operazione;

		private void Page_Load(object sender, System.EventArgs e)
		{

			CompletamentoUserControl user = (CompletamentoUserControl)pnlRisultati.Controls[0].Controls[0].FindControl("Completamento1");
			user.txtDitta = this.txtDitta;
			user.txtEdificio = this.txtEdificio;
			user.txtNomeCompleto = this.GetValue(pnlRicerca,"txtAddetto");
			user.p_GridRisultati = this.p_GridRisultati;
			//			if(this._HS==null)
			//			{
			//				this._HS = new Hashtable();
			//			}
			user._HS = this._HS;
			user.myDelegate +=new AslMobile.MyDelegate(this.MyActive);

			// Inserire qui il codice utente necessario per inizializzare la pagina.
		}
		private void MyActive(Hashtable HS,int operazione)
		{
			this.operazione = operazione;
			RepeaterMaster.DataSource =HS;
			RepeaterMaster.DataBind(); 

			this.ActiveForm=Form5;
		}
		protected void OnRicerca(object sender, System.EventArgs e)
		{

			// Data Da						
			int giornoDA = 1;
			int meseDA = Int16.Parse(this.GetValue(pnlRicerca.Controls[0],"cmbsMeseDa"));
			int annoDA = Int16.Parse(this.GetValue(pnlRicerca.Controls[0],"cmbsAnnoDa"));			
			this.dataDA = giornoDA + "/" + meseDA + "/" + annoDA;

			int giornoA = DateTime.DaysInMonth(Int16.Parse(this.GetValue(pnlRicerca.Controls[0],"cmbsAnnoA")),Int16.Parse(this.GetValue(pnlRicerca.Controls[0],"cmbsMeseA")));			
			int meseA = Int16.Parse(this.GetValue(pnlRicerca.Controls[0],"cmbsMeseA"));			
			int annoA = Int16.Parse(this.GetValue(pnlRicerca.Controls[0],"cmbsAnnoA"));	
			this.dataA = giornoA + "/" + meseA + "/" + annoA;

			this.id_ditta=0;
			if(p_cmbsDitta.SelectedValue!="")
				this.id_ditta=Int32.Parse(p_cmbsDitta.SelectedValue);

			this.id_servizio=0;
			if(p_cmbsServizio.SelectedValue!="")
				this.id_servizio=Int32.Parse(p_cmbsServizio.SelectedValue);

			if(this._HS!=null)
			{
				this._HS.Clear();
			}
			if(this.Ricerca())
			{
				this.txtEdificio = this.GetValue(pnlRicerca,"txtCodEdificio");
				this.txtDitta = p_cmbsDitta.SelectedValue;

				CompletamentoUserControl user = (CompletamentoUserControl)pnlRisultati.Controls[0].Controls[0].FindControl("Completamento1");
				user.txtDitta = this.txtDitta;
				user.txtEdificio = this.txtEdificio;
				user.txtNomeCompleto = this.GetValue(pnlRicerca,"txtAddetto");
				user.p_GridRisultati = this.p_GridRisultati;
				user.load();
				this.ActiveForm = Form3;
			}
		}

		protected void Risultati_Click(Object sender , CommandEventArgs e)
		{
			string s_url = e.CommandArgument.ToString();//+"&FunID="+FunId;							
			Server.Transfer(s_url);
		}		

		protected void OnRicercaEdifici(object sender, System.EventArgs e)
		{
			this.saveForm();
			this.p_GridAddetti.Visible=false;
			this.p_GridEdifici.Visible=true;

			this.p_GridEdifici.CurrentPageIndex=0;
			this.execute();
			this.ActiveForm = Form2;
		}
		protected void DataGridEdifici_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			this.p_GridEdifici.CurrentPageIndex=e.NewPageIndex;
			this.execute();
		}	
		protected void OnAnnulla(object sender, System.EventArgs e)
		{
			this.restoreForm();
			this.ActiveForm = Form1;
		}

		protected void OnRicercaAddetti(object sender, System.EventArgs e)
		{
			this.saveForm();
			this.p_GridAddetti.Visible=true;
			this.p_GridEdifici.Visible=false;
			this.p_GridAddetti.CurrentPageIndex=0;
			if (this.RicercaAddetti())
			{
				this.ActiveForm = Form2;
			}
		}

		protected void DataGridAddetti_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			this.p_GridAddetti.CurrentPageIndex=e.NewPageIndex;
			this.Ricerca();
		}	
		protected void DataGridRisultati_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.MemorizzaCheck();
			///Imposto la Nuova Pagina
			this.p_GridRisultati.CurrentPageIndex=e.NewPageIndex;
			this.Ricerca();
		}	
		private void MemorizzaCheck()
		{	
			if(this._HS==null)
			{
				this._HS = new Hashtable();
			}

			foreach(DataGridItem o_Litem in this.p_GridRisultati.Items)
			{	
				int id = Int32.Parse(o_Litem.Cells[0].Text);
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[1].FindControl("ChkSel");

				if(_HS.ContainsKey(id))
				{
					_HS.Remove(id);
				}
				if(	cb.Checked)			
					_HS.Add(id,cb.Checked);
			}
		}		

		protected void imageButton_Click(Object sender , CommandEventArgs e)
		{
			this.SetValue(pnlRicerca,"txtCodEdificio",(string)e.CommandArgument);
			this.CaricaDitte();
			this.BindServizio((string)e.CommandArgument);
			this.restoreForm();
			this.ActiveForm = Form1;		    
		}

		protected void Addetto_Click(Object sender , CommandEventArgs e)
		{
			this.restoreForm();
			this.SetValue(pnlRicerca,"txtAddetto",(string)e.CommandArgument);
			this.ActiveForm = Form1;
		}		


		private DataSet AggiornaWo(int itemId)
		{
			OracleParameterCollection Coll= new OracleParameterCollection();
			Class.ClassCompletaOrdine  _Completa = new Class.ClassCompletaOrdine();
			CompletamentoUserControl user = (CompletamentoUserControl)pnlRisultati.Controls[0].Controls[0].FindControl("Completamento1");

			DropDownList pcmbsAddetti0 = user.pcmbsAddetti0;
			
			int wo_id =  itemId;	
			OracleParameter p_wo_id = new OracleParameter();
			p_wo_id.ParameterName = "p_wo_id";
			p_wo_id.OracleType = OracleType.Int32;
			p_wo_id.Direction = ParameterDirection.Input;
			p_wo_id.Value = wo_id;																	
			Coll.Add(p_wo_id);

			OracleParameter p_addetto_id = new OracleParameter();
			p_addetto_id.ParameterName = "p_addetto_id";
			p_addetto_id.OracleType = OracleType.Int32;
			p_addetto_id.Direction = ParameterDirection.Input;
			p_addetto_id.Value = pcmbsAddetti0.SelectedValue;																	
			Coll.Add(p_addetto_id);
				
			DataSet Ds=_Completa.AggiornaWO(Coll);	
									
			return Ds;			
		}
		private DataSet UpdateWo(int itemId)
		{
			OracleParameterCollection Coll= new OracleParameterCollection();
			Class.ClassCompletaOrdine  _Completa = new Class.ClassCompletaOrdine();
			CompletamentoUserControl user = (CompletamentoUserControl)pnlRisultati.Controls[0].Controls[0].FindControl("Completamento1");

			DropDownList pcmbsAddetti1 = user.pcmbsAddetti1;

			int wo_id =  itemId;	
					
			OracleParameter p_wo_id = new OracleParameter();
			p_wo_id.ParameterName = "p_wo_id";
			p_wo_id.OracleType = OracleType.Int32;
			p_wo_id.Direction = ParameterDirection.Input;
			p_wo_id.Value = wo_id;																	
			Coll.Add(p_wo_id);

			OracleParameter p_addetto_id = new OracleParameter();
			p_addetto_id.ParameterName = "p_addetto_id";
			p_addetto_id.OracleType = OracleType.Int32;
			p_addetto_id.Direction = ParameterDirection.Input;
			p_addetto_id.Value = pcmbsAddetti1.SelectedValue;																	
			Coll.Add(p_addetto_id);

			OracleParameter p_data = new OracleParameter();
			p_data.ParameterName = "p_data";
			p_data.OracleType = OracleType.DateTime;
			p_data.Direction = ParameterDirection.Input;
			p_data.Value = Convert.ToDateTime(user.date);																	
			Coll.Add(p_data);
				
			DataSet Ds=_Completa.CompletaWO(Coll);	
			return Ds;			
		}
		

		protected void DataGridRepeaterMaster_ItemDataBound_1(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || 
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				Repeater RepeaterDett= (Repeater)e.Item.FindControl("RepeaterDettail");
				int item=Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Key").ToString());
				DataSet Ds;
				if(this.operazione==2)
					Ds=UpdateWo(item);
				else
					Ds=AggiornaWo(item);
				RepeaterDett.DataSource =Ds.Tables[0];
				RepeaterDett.DataBind(); 

			}
		}	


		#region Metodi private
		private bool Ricerca()
		{	
			OracleParameterCollection Coll= new OracleParameterCollection();
			
			// Tipo Manutenzione
			OracleParameter s_TipoManutenzione = new OracleParameter();

			s_TipoManutenzione.ParameterName = "p_TipoManutenzione";
			s_TipoManutenzione.OracleType = OracleType.Int32;
			s_TipoManutenzione.Direction = ParameterDirection.Input;
			s_TipoManutenzione.Size=4;
			s_TipoManutenzione.Value=Class.TipoManutenzioneType.ManutenzioneProgrammata;						
			Coll.Add(s_TipoManutenzione);				

			// Data Da
			OracleParameter s_AnnoDa = new OracleParameter();

			s_AnnoDa.ParameterName = "p_AnnoDa";
			s_AnnoDa.OracleType = OracleType.VarChar;
			s_AnnoDa.Direction = ParameterDirection.Input;
			s_AnnoDa.Size=10;
			s_AnnoDa.Value=dataDA;
			Coll.Add(s_AnnoDa);					

															// Data A						

			OracleParameter s_AnnoA = new OracleParameter();

			s_AnnoA.ParameterName = "p_AnnoA";
			s_AnnoA.OracleType = OracleType.VarChar;
			s_AnnoA.Direction = ParameterDirection.Input;
			s_AnnoA.Size=10;
			s_AnnoA.Value=dataA;
			Coll.Add(s_AnnoA);				
			
			// Ditta	
			OracleParameter s_Ditta = new OracleParameter();

			s_Ditta.ParameterName = "p_Ditta";
			s_Ditta.OracleType = OracleType.Int32;
			s_Ditta.Direction = ParameterDirection.Input;
			s_Ditta.Size=4;
			s_Ditta.Value=this.id_ditta;
			Coll.Add(s_Ditta);				

			// Servizio						
			OracleParameter s_Servizio = new OracleParameter();

			s_Servizio.ParameterName = "p_Servizio";
			s_Servizio.OracleType = OracleType.Int32;
			s_Servizio.Direction = ParameterDirection.Input;
			s_Servizio.Size=4;
			s_Servizio.Value=id_servizio;
			Coll.Add(s_Servizio);

			// WO_ID						
			int id_wo=0;
			string txtOrdineLavoro = this.GetValue(pnlRicerca,"txtOrdineLavoro");
			if(txtOrdineLavoro.Trim()!="")
				id_wo=Int32.Parse(txtOrdineLavoro.Trim());
			
			OracleParameter s_WO_ID = new OracleParameter();

			s_WO_ID.ParameterName = "p_Wo_Id";
			s_WO_ID.OracleType = OracleType.Int32;
			s_WO_ID.Direction = ParameterDirection.Input;
			s_WO_ID.Size=4;
			s_WO_ID.Value=id_wo;
			Coll.Add(s_WO_ID);

			// BL_ID						
			
			OracleParameter s_BL = new OracleParameter();

			s_BL.ParameterName = "p_Id_Bl";
			s_BL.OracleType = OracleType.VarChar;
			s_BL.Direction = ParameterDirection.Input;
			s_BL.Size=20;
			s_BL.Value = this.GetValue(pnlRicerca,"txtCodEdificio");
			Coll.Add(s_BL);

			// Addetto

			OracleParameter s_Addetto = new OracleParameter();

			s_Addetto.ParameterName = "p_Nome_Completo";
			s_Addetto.OracleType = OracleType.VarChar;
			s_Addetto.Direction = ParameterDirection.Input;
			s_Addetto.Size=4;
			s_Addetto.Value= this.GetValue(pnlRicerca,"txtAddetto");
			Coll.Add(s_Addetto);

			Class.ClassManProgrammata _Compl = new Class.ClassManProgrammata(userName);
						

			DataSet _MyDs = _Compl.Ricerca(Coll);

			if(_MyDs.Tables[0].Rows.Count>0)
			{
				this.p_GridRisultati.DataSource = _MyDs.Tables[0];
				this.p_GridRisultati.DataBind();
				return true;
			}
			return false;


			//this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();
			/*
			if (_MyDs.Tables[0].Rows.Count>0)
			{
				DatapanelCompleta.Visible=true;
				//Imposto le combo degli addetti
				DataRow _DR = _MyDs.Tables[0].Rows[0];
				cmbsAddettoCompl.SelectedValue=_DR["id_addetto"].ToString();
				cmbsAddettoMod.SelectedValue=_DR["id_addetto"].ToString();
			}
			else
				DatapanelCompleta.Visible=false;
			*/
		}

		private void execute()
		{
			string codedi = this.GetValue(pnlRicerca,"txtCodEdificio");
			Class.ClassEdifici _Edifici=new Class.ClassEdifici(Context.User.Identity.Name);
			DataSet Ds=	_Edifici.GetListaEdifici(codedi);
			if (Ds.Tables[0].Rows.Count >0)
			{
				this.p_GridEdifici.DataSource=Ds.Tables[0];
				this.p_GridEdifici.DataBind();
			}
		}

		private bool RicercaAddetti()
		{
//			string NomeCompleto = ((System.Web.UI.MobileControls.TextBox)pnlRicerca.Controls[0].FindControl("txtAddetto")).Text;
			string NomeCompleto = this.GetValue(pnlRicerca,"txtAddetto");
			string codDitta = p_cmbsDitta.SelectedValue;
//			string cod = ((System.Web.UI.MobileControls.TextBox)pnlRicerca.Controls[0].FindControl("txtCodEdificio")).Text;
			string cod = this.GetValue(pnlRicerca,"txtCodEdificio");
			string codEdificio=(cod=="")?"%":cod;

			Class.ClassRichiesta  _Richiesta = new Class.ClassRichiesta(userName);
			DataSet Ds=_Richiesta.GetAddetti(NomeCompleto, codEdificio, codDitta);
			if (Ds.Tables[0].Rows.Count >0)
			{
				this.p_GridAddetti.DataSource = Ds.Tables[0];
				this.p_GridAddetti.DataBind();
				return true;
			}
			return false;
		}
		private void CaricaCombiAnni()
		{
			DropDownList p_cmbsAnnoDa=(DropDownList)pnlRicerca.Controls[0].Controls[0].FindControl("cmbsAnnoDa");
			DropDownList p_cmbsAnnoA=(DropDownList)pnlRicerca.Controls[0].Controls[0].FindControl("cmbsAnnoA");
			string anno_corrente = DateTime.Now.Year.ToString();
			for (int i = 1950; i <= 2051; i++)
			{ 	
				ListItem _L1 = new ListItem();
				ListItem _L2 = new ListItem();
				_L1.Text=i.ToString();
				_L1.Value=i.ToString();
				_L2.Text=i.ToString();
				_L2.Value=i.ToString();
				p_cmbsAnnoA.Items.Add(_L1);
				p_cmbsAnnoDa.Items.Add(_L2);
			}

			p_cmbsAnnoDa.SelectedValue=anno_corrente;
			p_cmbsAnnoA.SelectedValue=anno_corrente;
		}

		private void BindServizio(string CodEdificio)
		{
			AslMobile.Class.ClassServizi _Servizi=new AslMobile.Class.ClassServizi(this.userName);
			_Servizi.setDropDownList(p_cmbsServizio,CodEdificio);
			this.CaricaDitte();
		}	
		private void CaricaDitte()
		{	
			int id_bl=0;
			
//			string bl_id= ((System.Web.UI.MobileControls.TextBox)pnlRicerca.Controls[0].FindControl("txtCodEdificio")).Text;
			string bl_id= this.GetValue(pnlRicerca,"txtCodEdificio");
			// Carico Le Ditte
			if (bl_id !="")
			{				
				// Mi recupero l'idbl
				DataSet _MyDsDittaBl;
				Class.ClassFunction _Fun = new Class.ClassFunction();
				_MyDsDittaBl= _Fun.GetIdBL(bl_id);								
				DataRow _DrBl = _MyDsDittaBl.Tables[0].Rows[0];
				id_bl= Int32.Parse(_DrBl[0].ToString());			
				BindDitte(id_bl);
			}
			else
			{
				id_bl=0;
				BindDitte(id_bl);
			}
		}
		private void BindDitte(int idbl)
		{	
			this.p_cmbsDitta.Items.Clear();			
			
			Class.ClassDitta _Ditte = new Class.ClassDitta(this.userName);
			// Attraverso l'IDBL mi ricavo l'ID della Ditta
			int idditta=0;
			if(idbl>0)
			{
				DataSet _MyDsDittaBl;
				_MyDsDittaBl=_Ditte.GetDittaBl(idbl);			
				DataRow _DrBl = _MyDsDittaBl.Tables[0].Rows[0];
				idditta= Int32.Parse(_DrBl["id_ditta"].ToString());			
			}
			else
			{
				idditta=0;
			}			
		
			DataSet _MyDs;
			_MyDs = _Ditte.GetDitteFornitoriRuoli(idditta);

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.p_cmbsDitta.DataSource = _MyDs.Tables[0];
				this.p_cmbsDitta.DataTextField = "DESCRIZIONE";
				this.p_cmbsDitta.DataValueField = "id";
				this.p_cmbsDitta.DataBind();
			}
			
			else
			{
				string s_Messagggio = "- Nessuna Ditta  -";
				this.p_cmbsDitta.Items.Add(new ListItem(s_Messagggio, String.Empty));
			}
		}
		private void saveForm()
		{
			DropDownList p_cmbsMeseDa=(DropDownList)pnlRicerca.Controls[0].Controls[0].FindControl("cmbsMeseDa");
			DropDownList p_cmbsAnnoDa=(DropDownList)pnlRicerca.Controls[0].Controls[0].FindControl("cmbsAnnoDa");
			DropDownList p_cmbsMeseA=(DropDownList)pnlRicerca.Controls[0].Controls[0].FindControl("cmbsMeseA");
			DropDownList p_cmbsAnnoA=(DropDownList)pnlRicerca.Controls[0].Controls[0].FindControl("cmbsAnnoA");

			AslMobile.Class.ClassSession FormSession = new AslMobile.Class.ClassSession();
			FormSession.ditta = Int32.Parse(this.p_cmbsDitta.SelectedValue);
			FormSession.servizio = Int32.Parse(this.p_cmbsServizio.SelectedValue);
			FormSession.daAnno= Int32.Parse(p_cmbsAnnoDa.SelectedValue);
			FormSession.daMese= Int32.Parse(p_cmbsMeseDa.SelectedValue);
			FormSession.aAnno= Int32.Parse(p_cmbsAnnoA.SelectedValue);
			FormSession.aMese= Int32.Parse(p_cmbsMeseA.SelectedValue);

			Session.Add("form",FormSession);
		}

		private void restoreForm()
		{
			DropDownList p_cmbsMeseDa=(DropDownList)pnlRicerca.Controls[0].Controls[0].FindControl("cmbsMeseDa");
			DropDownList p_cmbsAnnoDa=(DropDownList)pnlRicerca.Controls[0].Controls[0].FindControl("cmbsAnnoDa");
			DropDownList p_cmbsMeseA=(DropDownList)pnlRicerca.Controls[0].Controls[0].FindControl("cmbsMeseA");
			DropDownList p_cmbsAnnoA=(DropDownList)pnlRicerca.Controls[0].Controls[0].FindControl("cmbsAnnoA");

			AslMobile.Class.ClassSession FormSession =(AslMobile.Class.ClassSession) Session["form"];
			try
			{
				this.p_cmbsDitta.SelectedValue = Convert.ToString(FormSession.ditta);
			}
			
			
			catch(ArgumentOutOfRangeException arg){
				Console.Write(arg.Message);
			}
			try
			{
			
				
				this.p_cmbsServizio.SelectedValue = Convert.ToString(FormSession.servizio);
			}
			catch(ArgumentOutOfRangeException arg){
				Console.Write(arg.Message);
			}
			p_cmbsAnnoDa.SelectedValue = Convert.ToString(FormSession.daAnno);
			p_cmbsMeseDa.SelectedIndex = FormSession.daMese-1;
			p_cmbsAnnoA.SelectedValue = Convert.ToString(FormSession.aAnno);
			p_cmbsMeseA.SelectedIndex = FormSession.aMese-1;
			Session.Remove("form");
		}

	
		#endregion
		protected void DataGridRisultati_ItemDataBound_1(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				if(this._HS != null)
				{
					if(_HS.ContainsKey(Int32.Parse(e.Item.Cells[0].Text)))
					{
						System.Web.UI.WebControls.CheckBox cb =(System.Web.UI.WebControls.CheckBox) e.Item.Cells[1].FindControl("ChkSel");
						cb.Checked=true;
					}

				}
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
			this.userName=Context.User.Identity.Name;
			this.p_cmbsServizio = (DropDownList)pnlRicerca.Controls[0].Controls[0].FindControl("cmbsServizio");

			this.p_cmbsDitta = (DropDownList)pnlRicerca.Controls[0].Controls[0].FindControl("cmbsDitta");
			this.BindServizio("");
			this.CaricaCombiAnni();

			this.p_GridEdifici = (DataGrid)pnlSelezione.Controls[0].FindControl("DataGridEdifici");
			this.p_GridEdifici.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridEdifici_PageIndexChanged_1);

			this.p_GridAddetti = (DataGrid)pnlSelezione.Controls[0].FindControl("DataGridAddetti");
			this.p_GridAddetti.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridAddetti_PageIndexChanged_1);

			this.p_GridRisultati = (DataGrid)pnlRisultati.Controls[0].FindControl("DatagridRisultati");
			this.p_GridRisultati.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRisultati_PageIndexChanged_1);
			this.p_GridRisultati.ItemDataBound +=new DataGridItemEventHandler(this.DataGridRisultati_ItemDataBound_1);

			this.RepeaterMaster = (Repeater)Panel2.Controls[0].FindControl("RepeaterMaster");
			this.RepeaterMaster.ItemDataBound +=new RepeaterItemEventHandler(this.DataGridRepeaterMaster_ItemDataBound_1);
			

//			CompletamentoUserControl user = (CompletamentoUserControl)pnlRisultati.Controls[0].Controls[0].FindControl("Completamento1");
//			user.txtDitta = this.txtDitta;
//			user.txtEdificio = this.txtEdificio;
//			user.txtNomeCompleto = this.GetValue(pnlRicerca,"txtAddetto");
//			user.p_GridRisultati = this.p_GridRisultati;
//			if(this._HS==null)
//			{
//				this._HS = new Hashtable();
//			}
//			user._HS = this._HS;


			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion			

		protected void Indietro(object sender, System.EventArgs e)
		{
			DropDownList pcmbsAddetti0 = (DropDownList)Panel1.Controls[0].Controls[0].FindControl("cmbsAddetti0");
			DropDownList pcmbsAddetti1 = (DropDownList)Panel1.Controls[0].Controls[0].FindControl("cmbsAddetti1");

			AslMobile.Class.ClassSession FormSession =(AslMobile.Class.ClassSession) Session["form"];
			try
			{
				pcmbsAddetti0.SelectedValue = Convert.ToString(FormSession.addetto0);				
				pcmbsAddetti1.SelectedValue = Convert.ToString(FormSession.addetto1);
			}catch(ArgumentOutOfRangeException arg)
			{
			 Console.WriteLine(arg.Message);  
			}

			Session.Remove("form");

			ActiveForm = Form4;		
		}

		private void SetValue(Control Ctrl,string NameField, string value)
		{
			
			Control Ct=Ctrl.Controls[0].FindControl(NameField);
			value=value.Replace("\n"," ");
			value=value.Replace("\r",""); 
			if (Ct is System.Web.UI.MobileControls.Label)
				((System.Web.UI.MobileControls.Label)Ctrl.Controls[0].FindControl(NameField)).Text=value;

			if (Ct is System.Web.UI.MobileControls.TextBox)
				((System.Web.UI.MobileControls.TextBox)Ctrl.Controls[0].FindControl(NameField)).Text=value;
		}

		private string GetValue(Control Ctrl,string NameField)
		{
			Control Ct=Ctrl.Controls[0].FindControl(NameField);

			if (Ct is System.Web.UI.MobileControls.Label)
				return ((System.Web.UI.MobileControls.Label)Ctrl.Controls[0].FindControl(NameField)).Text;

			if (Ct is System.Web.UI.MobileControls.TextBox)
				return ((System.Web.UI.MobileControls.TextBox)Ctrl.Controls[0].FindControl(NameField)).Text;

			if (Ct is System.Web.UI.WebControls.TextBox)
				return ((System.Web.UI.WebControls.TextBox)Ctrl.Controls[0].FindControl(NameField)).Text;

			if (Ct is DropDownList)
				return ((DropDownList)Ctrl.Controls[0].FindControl(NameField)).SelectedValue;

			return "";
		}


	}
}
