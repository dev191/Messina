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
	/// Descrizione di riepilogo per Rcompleta.
	/// </summary>
	public class Rcompleta : System.Web.UI.MobileControls.MobilePage
	{
		protected System.Web.UI.MobileControls.Form Form1;
		protected System.Web.UI.MobileControls.Form Form2;
		protected System.Web.UI.MobileControls.Panel Panel1;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific1;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific2;
		protected System.Web.UI.MobileControls.Form Form3;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific3;
		protected System.Web.UI.MobileControls.Panel pnlGestioneComp;
		protected System.Web.UI.MobileControls.Panel PnlRicerca;
		protected System.Web.UI.MobileControls.Calendar Calendar1;

		private		string		userName;
		private		int			p_intPriority;
		private		int			p_intServizio;
		private		int			p_intGruppo;
		protected	DataGrid	GridEdifici;
		protected	DataGrid	GridRichiedente;
		protected	DataGrid	GridRicerca;
		private		DropDownList p_cmbsGruppo;
		private 	DropDownList p_cmbsServizio;
		protected System.Web.UI.MobileControls.Form Form4;
		protected System.Web.UI.MobileControls.Panel Panel2;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific4;
		private 	DropDownList p_cmbsPriority;


		private void Page_Load(object sender, System.EventArgs e)
		{
			System.Web.UI.MobileControls.Calendar cal = (System.Web.UI.MobileControls.Calendar)Panel2.Controls[0].FindControl("Calendar1");
			cal.SelectedDates.Clear();

//			if(!IsPostBack)
			//				((System.Web.UI.WebControls.TextBox)pnlGestioneComp.Controls[0].Controls[0].FindControl("lblDataCreazione")).Text=System.DateTime.Now.ToShortDateString();
					
		}
		private void execute()
		{
			string codedi=((System.Web.UI.MobileControls.TextBox)pnlGestioneComp.Controls[0].FindControl("txtCodiceEdificio")).Text;
			Class.ClassEdifici _Edifici=new Class.ClassEdifici(Context.User.Identity.Name);
			DataSet Ds=	_Edifici.GetListaEdifici(codedi);
			if (Ds.Tables[0].Rows.Count >0)
			{
				GridEdifici.DataSource=Ds.Tables[0];
				GridEdifici.DataBind();
			}
		}
		protected void executeRichiedente()
		{			
			
			string richiede=((System.Web.UI.MobileControls.TextBox)pnlGestioneComp.Controls[0].FindControl("txtRichiedente")).Text;
			Class.ClassRichiedenti  _Richiedenti=new Class.ClassRichiedenti(userName);
			_Richiedenti.setBinding(GridRichiedente,richiede);
		}	

		protected void Operatore_Click(Object sender , CommandEventArgs e)
		{
			((System.Web.UI.MobileControls.TextBox)pnlGestioneComp.Controls[0].FindControl("txtRichiedente")).Text=(string)e.CommandArgument; 
			this.ActiveForm = Form1;
		}		
				
		protected void OnBack(object sender, System.EventArgs e)
		{
			this.ActiveForm = Form1;
		}
		protected void OnRicerca(object sender, System.EventArgs e)
		{
			System.Web.UI.MobileControls.RegularExpressionValidator RqOrdine=(System.Web.UI.MobileControls.RegularExpressionValidator)pnlGestioneComp.Controls[0].FindControl("ValidatorOrdine");
			System.Web.UI.MobileControls.RegularExpressionValidator RqRichiesta=(System.Web.UI.MobileControls.RegularExpressionValidator)pnlGestioneComp.Controls[0].FindControl("ValidatorRichiesta");

			this.p_intPriority = (p_cmbsPriority.SelectedValue=="")?0:Int32.Parse(p_cmbsPriority.SelectedValue);
			this.p_intServizio = (p_cmbsServizio.SelectedValue=="")? 0:Int32.Parse(p_cmbsServizio.SelectedValue);
			this.p_intGruppo = (p_cmbsGruppo.SelectedValue=="")?0:Int32.Parse(p_cmbsGruppo.SelectedValue);

			if (RqOrdine.IsValid && RqRichiesta.IsValid)
			{
				this.GridRicerca.CurrentPageIndex=0;
				if(this.Ricerca())
				{
					((System.Web.UI.MobileControls.Label)PnlRicerca.Controls[0].FindControl("lblDscrizioneRicerca")).Text="Richieste da completare";
					this.ActiveForm = Form3;
				}
			}
		}
		protected void OnRicercaEdifici(object sender, System.EventArgs e)
		{
			((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblDescrizione")).Text="Ricerca Edifici";
			
			this.GridEdifici.CurrentPageIndex=0;
			this.GridEdifici.Visible=true;
			this.GridRichiedente.Visible=false;
			execute();
			this.ActiveForm = Form2;
			//			DataGrid1.CurrentPageIndex=0;
		}
		protected void OnRicercaRichiedente(object sender, System.EventArgs e)
		{
			((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblDescrizione")).Text="Ricerca Richiedenti";
			this.GridEdifici.CurrentPageIndex=0;
			this.GridEdifici.Visible=false;
			this.GridRichiedente.Visible=true;
			executeRichiedente();
			this.ActiveForm = Form2;
			//			DataGrid1.CurrentPageIndex=0;
		}
		
		protected void OnDataSelect(object sender, System.EventArgs e)
		{
			this.ActiveForm = Form4;
		}
		protected void Calendar_SelectionChangedDataStart(Object sender, EventArgs e)
		{
			((System.Web.UI.WebControls.TextBox)pnlGestioneComp.Controls[0].FindControl("txtDataCreazione")).Text = ((System.Web.UI.MobileControls.Calendar)(sender)).SelectedDate.ToShortDateString();
			ActiveForm = Form1;
		}

		protected void MyDataGrid1_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			GridEdifici.CurrentPageIndex=e.NewPageIndex;
			execute();
		}	
	
		protected void DataGridRicerca_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			this.GridRicerca.CurrentPageIndex=e.NewPageIndex;
			this.Ricerca();

		}	
		protected void DataGridRichiedenti_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			this.GridRichiedente.CurrentPageIndex=e.NewPageIndex;
			executeRichiedente();
		}	
		protected void imageButton_Click(Object sender , CommandEventArgs e)
		{
			if((string)e.CommandArgument!="")
			{
				this.BindServizio((string)e.CommandArgument);
			}
			((System.Web.UI.MobileControls.TextBox)pnlGestioneComp.Controls[0].Controls[0].FindControl("txtCodiceEdificio")).Text=(string)e.CommandArgument; 
			this.ActiveForm = Form1;
		    
		}
		protected void imageButtonEdit_Click(Object sender , CommandEventArgs e)
		{
			this.RedirectToMobilePage("Completa.aspx?ItemId=" + (string)e.CommandArgument);
		}

		private void BindServizio(string CodEdificio)
		{
			Class.ClassServizi _Servizi=new Class.ClassServizi(this.userName);
			_Servizi.setDropDownList(p_cmbsServizio,CodEdificio);
		}	

		/**
			Setta le comboBox delle Priorità e del Gruppo
		*/
		private void BindControls()
		{
			//Setta la comboBox del Gruppo
			Class.ClassGruppo _Gruppo=new Class.ClassGruppo();
			_Gruppo.setDropDownList(p_cmbsGruppo);

			//setta la comboBox delle Priorità
			Class.ClassUrgenza _Urgenza=new Class.ClassUrgenza();
			_Urgenza.setDropDownListDefault(p_cmbsPriority);
		}

		private bool Ricerca()
		{
			bool visible=false;

			OracleParameterCollection Coll= new OracleParameterCollection();

			OracleParameter s_p_operatore = new OracleParameter();
			s_p_operatore.ParameterName = "p_operatore";
			s_p_operatore.OracleType = OracleType.VarChar;
			s_p_operatore.Direction = ParameterDirection.Input;
			s_p_operatore.Value ="";
			s_p_operatore.Size=250; 
			Coll.Add(s_p_operatore);


			OracleParameter s_p_servizio_id = new OracleParameter();
			s_p_servizio_id.ParameterName = "p_servizio_id";
			s_p_servizio_id.OracleType = OracleType.Int32;
			s_p_servizio_id.Direction = ParameterDirection.Input;
			s_p_servizio_id.Value =this.p_intServizio;
			Coll.Add(s_p_servizio_id);
            
			OracleParameter s_p_campus = new OracleParameter();
			s_p_campus.ParameterName = "p_campus";
			s_p_campus.OracleType = OracleType.VarChar;
			s_p_campus.Direction = ParameterDirection.Input;
			s_p_campus.Value ="";
			s_p_campus.Size=250; 
			Coll.Add(s_p_campus);

			OracleParameter s_p_bl_id = new OracleParameter();
			s_p_bl_id.ParameterName = "p_bl_id";
			s_p_bl_id.OracleType = OracleType.VarChar;
			s_p_bl_id.Direction = ParameterDirection.Input;
			s_p_bl_id.Value =((System.Web.UI.MobileControls.TextBox)pnlGestioneComp.Controls[0].Controls[0].FindControl("txtCodiceEdificio")).Text;
			s_p_bl_id.Size=250; 
			Coll.Add(s_p_bl_id);

			OracleParameter s_p_wr_id = new OracleParameter();
			s_p_wr_id.ParameterName = "p_wr_id";
			s_p_wr_id.OracleType = OracleType.Int32;
			s_p_wr_id.Direction = ParameterDirection.Input;
			s_p_wr_id.Value = (((System.Web.UI.MobileControls.TextBox)pnlGestioneComp.Controls[0].Controls[0].FindControl("txtRichiesta")).Text=="")?0:Int32.Parse(((System.Web.UI.MobileControls.TextBox)pnlGestioneComp.Controls[0].Controls[0].FindControl("txtRichiesta")).Text);
			Coll.Add(s_p_wr_id);

			OracleParameter s_p_wo_id = new OracleParameter();
			s_p_wo_id.ParameterName = "p_wo_id";
			s_p_wo_id.OracleType = OracleType.Int32;
			s_p_wo_id.Direction = ParameterDirection.Input;
			s_p_wo_id.Value =(((System.Web.UI.MobileControls.TextBox)pnlGestioneComp.Controls[0].Controls[0].FindControl("txtOrdineLavoro")).Text=="")?0:Int32.Parse(((System.Web.UI.MobileControls.TextBox)pnlGestioneComp.Controls[0].Controls[0].FindControl("txtOrdineLavoro")).Text);
			Coll.Add(s_p_wo_id);

			OracleParameter s_p_gruppo = new OracleParameter();
			s_p_gruppo.ParameterName = "p_gruppo";
			s_p_gruppo.OracleType = OracleType.Int32;
			s_p_gruppo.Direction = ParameterDirection.Input;
			s_p_gruppo.Value = this.p_intGruppo;
			Coll.Add(s_p_gruppo);

			OracleParameter s_p_richiedente = new OracleParameter();
			s_p_richiedente.ParameterName = "p_richiedente";
			s_p_richiedente.OracleType = OracleType.VarChar;
			s_p_richiedente.Direction = ParameterDirection.Input;
			s_p_richiedente.Size=35;
			s_p_richiedente.Value =((System.Web.UI.MobileControls.TextBox)pnlGestioneComp.Controls[0].FindControl("txtRichiedente")).Text;  
			Coll.Add(s_p_richiedente);

			OracleParameter s_p_descrizione = new OracleParameter();
			s_p_descrizione.ParameterName = "p_descrizione";
			s_p_descrizione.OracleType = OracleType.VarChar;
			s_p_descrizione.Direction = ParameterDirection.Input;
			s_p_descrizione.Size=2000;
			s_p_descrizione.Value =((System.Web.UI.MobileControls.TextBox)pnlGestioneComp.Controls[0].Controls[0].FindControl("txtDescrizione")).Text;  
			Coll.Add(s_p_descrizione);

			OracleParameter s_p_urgenza = new OracleParameter();
			s_p_urgenza.ParameterName = "p_urgenza";
			s_p_urgenza.OracleType = OracleType.Int32 ;
			s_p_urgenza.Direction = ParameterDirection.Input;
			s_p_urgenza.Value =  this.p_intPriority;
			Coll.Add(s_p_urgenza);

			OracleParameter s_p_ditta = new OracleParameter();
			s_p_ditta.ParameterName = "p_ditta";
			s_p_ditta.OracleType = OracleType.Int32;
			s_p_ditta.Direction = ParameterDirection.Input;
			s_p_ditta.Value =0;  
			Coll.Add(s_p_ditta);

			OracleParameter s_p_dates = new OracleParameter();
			s_p_dates.ParameterName = "p_dates";
			s_p_dates.OracleType = OracleType.VarChar;
			s_p_dates.Direction = ParameterDirection.Input;
			s_p_dates.Size=10;
			s_p_dates.Value =((System.Web.UI.WebControls.TextBox)pnlGestioneComp.Controls[0].Controls[0].FindControl("txtDataCreazione")).Text;  
			Coll.Add(s_p_dates);
			
			OracleParameter s_p_datee = new OracleParameter();
			s_p_datee.ParameterName = "p_datee";
			s_p_datee.OracleType = OracleType.VarChar;
			s_p_datee.Direction = ParameterDirection.Input;
			s_p_datee.Size=10;
			s_p_datee.Value ="";  
			Coll.Add(s_p_datee);

			OracleParameter s_p_addetto = new OracleParameter();
			s_p_addetto.ParameterName = "p_addetto";
			s_p_addetto.OracleType = OracleType.VarChar;
			s_p_addetto.Direction = ParameterDirection.Input;
			s_p_addetto.Size=250;
			s_p_addetto.Value ="";  
			Coll.Add(s_p_addetto);

			Class.ClassRicerca _GestioneRdl= new Class.ClassRicerca(Context.User.Identity.Name);
			DataSet Ds=_GestioneRdl.Ricerca(Coll);


			if(Ds.Tables[0].Rows.Count>0)
			{
				//GridRicerca.NumeroRecords= Ds.Tables[0].Rows.Count.ToString(); 
				GridRicerca.DataSource=Ds;
				GridRicerca.DataBind(); 
				visible=true;
			}

			return visible;
		}
		protected string ValutaStringa(Object obj)
		{
			if (obj!=DBNull.Value && obj.ToString()!="")
			{
				if (obj.ToString().Length >50) 
					return obj.ToString().Substring(0, obj.ToString().IndexOf(" ",20));
				else 
					return obj.ToString();
			}
			else
			{
				return string.Empty; 
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
			//Crea evento per il DataGrid degli edifici
			this.GridEdifici=(DataGrid)Panel1.Controls[0].FindControl("DataGridEdifici");
			this.GridEdifici.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged_1);

			//Crea evento per il DataGrid del Richiedente
			this.GridRichiedente=(DataGrid)Panel1.Controls[0].FindControl("DataGridRichiedente");
			this.GridRichiedente.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRichiedenti_PageIndexChanged_1);
			
			//Crea evento per il DataGrid della Ricerca
			this.GridRicerca=(DataGrid)PnlRicerca.Controls[0].FindControl("DataGridRicerca");
			this.GridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged_1);

			//prelevo la comboBox del gruppo
			this.p_cmbsGruppo=(DropDownList)pnlGestioneComp.Controls[0].Controls[0].FindControl("cmbsGruppo");
			//prelevo la comboBox dei Servizi
			this.p_cmbsServizio=(DropDownList)pnlGestioneComp.Controls[0].Controls[0].FindControl("cmbsServizio");
			//prelevo la comboBox delle priorità
			this.p_cmbsPriority=(DropDownList)pnlGestioneComp.Controls[0].Controls[0].FindControl("cmbsPriority");


			this.BindControls();

			this.userName = Context.User.Identity.Name;
			this.BindServizio("");
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
