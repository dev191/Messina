using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Web;
using System.Web.Mobile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OracleClient;
  
namespace TheSite.AslMobile
{
	/// <summary>
	/// Descrizione di riepilogo per Richiesta.
	/// </summary>
	public class Richiesta : System.Web.UI.MobileControls.MobilePage
	{
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific1;
		protected System.Web.UI.MobileControls.Panel Panel2;
		protected System.Web.UI.MobileControls.Form Form2;
		protected System.Web.UI.MobileControls.Form Form3;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific2;
		protected System.Web.UI.MobileControls.Panel Panel1;
		protected System.Web.UI.MobileControls.Form Form1;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific3;
		protected System.Web.UI.MobileControls.Panel Panel3;
		protected DataGrid DataGrid1;
		protected System.Web.UI.MobileControls.DeviceSpecific Devicespecific2;
		protected DataGrid DataGrid2;
		protected System.Web.UI.MobileControls.Form Form4;
		protected System.Web.UI.MobileControls.Panel Panel4;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific4;
		protected DataGrid DataGrid3;
		protected System.Web.UI.MobileControls.Form Form5;
		protected System.Web.UI.MobileControls.Panel Panel5;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific5;
		private string userName;
		private int sel_linkButton
		{
			get
			{
				if(ViewState["sel_linkButton"]!=null)
					return (int)ViewState["sel_linkButton"];
				else
					return -1;
			}
			set
			{
				ViewState.Add("sel_linkButton",value);
			}
		}


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			
		}
		protected void OnRichiesteNonEmesse(object sender, System.EventArgs e)
		{
			this.sel_linkButton = 1;
			DataGrid3.CurrentPageIndex=0;
			if(this.RicercaNonEmesse())
				this.ActiveForm = Form4;
		}
		protected void OnRichiesteEmesse(object sender, System.EventArgs e)
		{
			this.sel_linkButton = 2;
			DataGrid3.CurrentPageIndex=0;
			if(this.RicercaApprovate())
				this.ActiveForm = Form4;
		}


		protected void consulta_Click(Object sender , CommandEventArgs e)
		{

			int itemId = Int32.Parse((string)e.CommandArgument); 

			Class.ClassRDL _RDL = new AslMobile.Class.ClassRDL("");
			DataSet _MyDs = _RDL.GetSingleRdl(itemId);
			if (_MyDs.Tables[0].Rows.Count>0)
			{
				DataRow _Dr = _MyDs.Tables[0].Rows[0];				
				int bl_id=Int32.Parse(_Dr["id_bl"].ToString());
/*								 
			//Tempo di intervento'
			f (_Dr["data_sla"] != DBNull.Value)
						((System.Web.UI.HtmlControls.HtmlInputHidden)Panel4.Controls[0].FindControl("Hiddetempointervento")).Value=_Dr["data_sla"].ToString();
						lse
									((System.Web.UI.HtmlControls.HtmlInputHidden)Panel4.Controls[0].FindControl("Hiddetempointervento")).Value="";
*/
				//STATO DELLA RDL
				CreazioneRichiesta1 Cre1=(CreazioneRichiesta1)Panel5.Controls[0].Controls[0].FindControl("CreazioneRichiesta1"); 
				Cre1.SetData(_Dr);
				CreazioneRichiesta2 Cre2=(CreazioneRichiesta2)Panel5.Controls[0].Controls[0].FindControl("CreazioneRichiesta2"); 
				CreazioneRichiesta3 Cre3=(CreazioneRichiesta3)Panel5.Controls[0].Controls[0].FindControl("CreazioneRichiesta3"); 
				
				DataSet _MyDsStato= _RDL.GetStatusRdl(itemId);
				if (_MyDsStato.Tables[0].Rows.Count>0)
				{
					DataRow _DrStato = _MyDsStato.Tables[0].Rows[0];
					Cre2.SetData(_Dr,_DrStato);
				}
				else
					Cre2.SetData(_Dr,null);

				switch((TheSite.AslMobile.Class.StateType)Int16.Parse(_Dr["idstatus"].ToString()))
				{
					case TheSite.AslMobile.Class.StateType.AttivitaCompletata:
						Cre3.SetData(_Dr);
						break;
					default:
						Cre3.Visible=false;
						break;
				}


				this.ActiveForm = Form5;
			}
			
			//				CompletamentoOrdine(_Dr);


			
		    
		}

	
		bool RicercaNonEmesse()
		{
			string codedi=((System.Web.UI.MobileControls.Label)Panel3.Controls[0].FindControl("lblCodEdiF2")).Text;
			//if (this.RicercaModulo1.BlId == "") return;
			Class.ClassRichiesta  _Richiesta = new Class.ClassRichiesta(userName);
			DataSet _MyDs = _Richiesta.GetRDLNonEmesse(codedi);
			if(_MyDs.Tables[0].Rows.Count >0 )
			{
				DataGrid3.DataSource =  _MyDs.Tables[0];
				DataGrid3.DataBind();
				return true;
			}
			return false;
		}
		bool RicercaApprovate()
		{
			
			string codedi=((System.Web.UI.MobileControls.Label)Panel3.Controls[0].FindControl("lblCodEdiF2")).Text;
			//if (this.RicercaModulo1.BlId == "") return;
			Class.ClassRichiesta  _Richiesta = new Class.ClassRichiesta(userName);

			DataSet _MyDs = _Richiesta.GetRDLApprovate(codedi);
			if(_MyDs.Tables[0].Rows.Count >0 )
			{
				DataGrid3.DataSource =  _MyDs.Tables[0];
				DataGrid3.DataBind();
				return true;
			}
			return false;			
		}



		protected void OnRicerca(object sender, System.EventArgs e)
		{
			DataGrid1.CurrentPageIndex=0;
			execute();
		}

		protected void MyDataGrid1_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			DataGrid1.CurrentPageIndex=e.NewPageIndex;
			execute();
		}	

		protected void imageButton_Click(Object sender , CommandEventArgs e)
		{
			((System.Web.UI.MobileControls.Label)Form2.Controls[0].Controls[0].FindControl("lblCodEdiF2")).Text=(string)e.CommandArgument; 
			string codedi=((System.Web.UI.MobileControls.Label)Panel3.Controls[0].FindControl("lblCodEdiF2")).Text;
			//if (this.RicercaModulo1.BlId == "") return;
			Class.ClassRichiesta  _Richiesta = new Class.ClassRichiesta(userName);
			((System.Web.UI.WebControls.LinkButton)Form2.Controls[0].Controls[0].FindControl("LinkButton1")).Text = "Richieste non Emesse : " + _Richiesta.GetNumeroNonEmesse(codedi) ;
			((System.Web.UI.WebControls.LinkButton)Form2.Controls[0].Controls[0].FindControl("LinkButton2")).Text = "Richieste Approvate : " + _Richiesta.GetNumeroApprovate(codedi) ;

			this.ActiveForm = Form2;
		    
		}
		private void LoadCombo()
		{
			this.BindServizio(((System.Web.UI.MobileControls.Label)Panel1.Controls[0].Controls[0].FindControl("lblcodedi")).Text);
			this.BindApparecchiature("","");
			this.BindCodApparecchiature("","","");
			this.BindControls();
		}
		protected void Selection_SelectedIndexServizi(object sender, System.EventArgs e)
		{
			DropDownList Servizi=(DropDownList) Panel1.Controls[0].Controls[0].FindControl("cmbsServizio");
			this.BindApparecchiature(((System.Web.UI.MobileControls.Label)Panel1.Controls[0].Controls[0].FindControl("lblcodedi")).Text,Servizi.SelectedValue);
			this.BindCodApparecchiature("","","");
		}
		protected void Selection_SelectedIndexApparecchiature(object sender, System.EventArgs e)
		{
			DropDownList _Servizi=(DropDownList) Panel1.Controls[0].Controls[0].FindControl("cmbsServizio");
			DropDownList _Apparecchiature=(DropDownList) Panel1.Controls[0].Controls[0].FindControl("cmbsApp");
			this.BindCodApparecchiature(((System.Web.UI.MobileControls.Label)Panel1.Controls[0].Controls[0].FindControl("lblcodedi")).Text,_Servizi.SelectedValue,_Apparecchiature.SelectedValue);
			//			this.BindApparecchiature(((System.Web.UI.MobileControls.Label)Panel1.Controls[0].Controls[0].FindControl("lblcodedi")).Text,Servizi.SelectedValue);
		}
		private void BindCodApparecchiature(string CodEdificio,string codServizio,string Apparecchiatura)
		{
			
			DropDownList dr=(DropDownList) Panel1.Controls[0].Controls[0].FindControl("cmbsAppare");
			Class.ClassApparecchiatura _Apparecchiature=new Class.ClassApparecchiatura(this.userName);
			_Apparecchiature.setDropListCodApparecchiatura(dr,CodEdificio,codServizio,Apparecchiatura);
		}	

		private void BindApparecchiature(string CodEdificio,string codServizio)
		{
			DropDownList dr=(DropDownList) Panel1.Controls[0].Controls[0].FindControl("cmbsApp");
			Class.ClassApparecchiatura _Apparecchiature=new Class.ClassApparecchiatura(this.userName);
			_Apparecchiature.setDropDownListApparecchiature(dr,CodEdificio,codServizio);
		}	

		private void BindServizio(string CodEdificio)
		{
			DropDownList dr=(DropDownList) Panel1.Controls[0].Controls[0].FindControl("cmbsServizio");
			Class.ClassServizi _Servizi=new Class.ClassServizi(this.userName);
			_Servizi.setDropDownList(dr,CodEdificio);
		}	
		private void BindControls()
		{
			DropDownList cmbsGruppo=(DropDownList) Panel1.Controls[0].Controls[0].FindControl("cmbsGruppo");
			Class.ClassGruppo _Gruppo=new Class.ClassGruppo();
			_Gruppo.setDropDownList(cmbsGruppo);

			DropDownList cmbsUrgenza=(DropDownList) Panel1.Controls[0].Controls[0].FindControl("cmbsPriority");
			Class.ClassUrgenza _Apparecchiature=new Class.ClassUrgenza();
			_Apparecchiature.setDropDownList(cmbsUrgenza);
		}
		private void execute()
		{
			string codedi=((System.Web.UI.MobileControls.TextBox)Panel2.Controls[0].FindControl("txtCodice")).Text;
			Class.ClassEdifici _Edifici=new Class.ClassEdifici(Context.User.Identity.Name);
			DataSet Ds=	_Edifici.GetListaEdifici(codedi);
			if (Ds.Tables[0].Rows.Count >0)
			{
				DataGrid1.DataSource=Ds.Tables[0];
				DataGrid1.DataBind();
			}
		}

		protected void OnSalva(object sender, System.EventArgs e)
		{
			System.Web.UI.MobileControls.RegularExpressionValidator  RqTelefono=(System.Web.UI.MobileControls.RegularExpressionValidator)Panel1.Controls[0].FindControl("RqTelefono");
			RqTelefono.Validate();
			if(RqTelefono.IsValid)
			{
				int result=NuovaRichiesta();
				if(result!=0)
					this.RedirectToMobilePage("VisualRdl.aspx?ItemId=" + result.ToString());
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
            DataGrid1=(DataGrid)Panel2.Controls[0].FindControl("MyDataGrid1");
			DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.MyDataGrid1_PageIndexChanged_1);
			 
			DataGrid2=(DataGrid)Panel3.Controls[0].FindControl("MyDataGrid2");
			this.DataGrid2.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.MyDataGrid2_PageIndexChanged_1);	
			userName = Context.User.Identity.Name;
 
			this.DataGrid3=(DataGrid)Panel4.Controls[0].FindControl("MyDataGrid3");
			this.DataGrid3.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.MyDataGrid3_PageIndexChanged_1);	

			DropDownList _Servizi=(DropDownList) Panel1.Controls[0].Controls[0].FindControl("cmbsServizio");
			_Servizi.SelectedIndexChanged+=new EventHandler(this.Selection_SelectedIndexServizi);
			_Servizi.AutoPostBack=true;


			DropDownList _Apparecchiature=(DropDownList) Panel1.Controls[0].Controls[0].FindControl("cmbsApp");
			_Apparecchiature.SelectedIndexChanged+=new EventHandler(this.Selection_SelectedIndexApparecchiature);
			_Apparecchiature.AutoPostBack=true;

			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
		protected void MyDataGrid3_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			DataGrid3.CurrentPageIndex=e.NewPageIndex;
			switch(this.sel_linkButton)
			{
				case 1:
					this.RicercaNonEmesse();
					break;
				case 2:
					this.RicercaApprovate();
					break;
			}
			//			executeRichiedente();
		}	
		protected void MyDataGrid2_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			DataGrid2.CurrentPageIndex=e.NewPageIndex;
			executeRichiedente();
		}	
		protected void OnOperatore(object sender, System.EventArgs e)
		{
			if (IsValid)
			{
				string codice=((System.Web.UI.MobileControls.TextBox)Panel3.Controls[0].FindControl("txtRichiedente")).Text;
				string operatore=((System.Web.UI.MobileControls.Label)Panel3.Controls[0].FindControl("lblCodEdiF2")).Text;
			
				this.ActiveForm = Form3;
				((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblcodedi")).Text=operatore;
				((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblRichiedenteF3")).Text=codice; 
				((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblDataRichiesta")).Text = DateTime.Now.ToShortDateString();
				((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblOraRichiesta")).Text = DateTime.Now.ToShortTimeString();  
				LoadCombo();
			}
			else
			{
				System.Web.UI.MobileControls.RequiredFieldValidator Rq=(System.Web.UI.MobileControls.RequiredFieldValidator)Panel3.Controls[0].FindControl("RequiredFieldValidator1");
			    Rq.Visible=true; 
			}

			
		}
		
		protected void OnRicercaOperatore(object sender, System.EventArgs e)
		{
			this.DataGrid2.Visible=true;
           DataGrid2.CurrentPageIndex=0;
		   executeRichiedente();
		}
		protected void executeRichiedente(){			
			
			string richiede=((System.Web.UI.MobileControls.TextBox)Panel3.Controls[0].FindControl("txtRichiedente")).Text;
			Class.ClassRichiedenti  _Richiedenti=new Class.ClassRichiedenti(userName);
			_Richiedenti.setBinding(DataGrid2,richiede);
		}		
		protected void Operatore_Click(Object sender , CommandEventArgs e)
		{
			((System.Web.UI.MobileControls.TextBox)Panel3.Controls[0].FindControl("txtRichiedente")).Text=(string)e.CommandArgument;
			this.DataGrid2.Visible=false;
		}
		private int NuovaRichiesta()
		{
			int i_WrId = 0;
			
			Class.ClassRichiesta  _Richiesta=new Class.ClassRichiesta(userName);
			
			OracleParameterCollection _SColl= new OracleParameterCollection();

			OracleParameter s_BlId = new OracleParameter();
			s_BlId.ParameterName = "p_Bl_Id";
			s_BlId.OracleType =OracleType.VarChar;
			s_BlId.Direction = ParameterDirection.Input;
			s_BlId.Size = 8;
			s_BlId.Value = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblcodedi")).Text;
			_SColl.Add(s_BlId);

			OracleParameter s_p_Richiedente = new OracleParameter();
			s_p_Richiedente.ParameterName = "p_Em_Id";
			s_p_Richiedente.OracleType =OracleType.VarChar;
			s_p_Richiedente.Direction = ParameterDirection.Input;
			s_p_Richiedente.Size=50;
			s_p_Richiedente.Value = ((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblRichiedenteF3")).Text;			
			_SColl.Add(s_p_Richiedente);

			OracleParameter s_p_Gruppo = new OracleParameter();
			s_p_Gruppo.ParameterName = "p_Gruppo";
			s_p_Gruppo.OracleType =OracleType.VarChar;
			s_p_Gruppo.Direction = ParameterDirection.Input;
            DropDownList cmbsGruppo=(DropDownList)Panel1.Controls[0].FindControl("cmbsGruppo");
			s_p_Gruppo.Value = (cmbsGruppo.SelectedValue ==string.Empty)? "0":cmbsGruppo.SelectedValue;	
			_SColl.Add(s_p_Gruppo);

			OracleParameter s_p_Phone = new OracleParameter();
			s_p_Phone.ParameterName = "p_Phone";
			s_p_Phone.OracleType =OracleType.VarChar;
			s_p_Phone.Direction = ParameterDirection.Input;
			s_p_Phone.Size= 50;
			s_p_Phone.Value =((System.Web.UI.MobileControls.TextBox)Panel1.Controls[0].FindControl("txtsTelefonoRichiedente")).Text ;			
			_SColl.Add(s_p_Phone);

			OracleParameter s_p_Nota_Ric = new OracleParameter();
			s_p_Nota_Ric.ParameterName = "p_Nota_Ric";
			s_p_Nota_Ric.OracleType =OracleType.VarChar;
			s_p_Nota_Ric.Direction = ParameterDirection.Input;
			s_p_Nota_Ric.Size= 2000;
			s_p_Nota_Ric.Value =((System.Web.UI.MobileControls.TextBox)Panel1.Controls[0].FindControl("txtsNota")).Text;			
			_SColl.Add(s_p_Nota_Ric);

			OracleParameter s_Priority = new OracleParameter();
			s_Priority.ParameterName="p_Priority";
			s_Priority.OracleType =OracleType.Int32;
			s_Priority.Direction = ParameterDirection.Input;
			DropDownList cmbsPriority=(DropDownList)Panel1.Controls[0].FindControl("cmbsPriority");
			s_Priority.Value = (cmbsPriority.SelectedValue ==string.Empty)? 0:Convert.ToInt32(cmbsPriority.SelectedValue);	
			_SColl.Add(s_Priority);	

			OracleParameter p_Description = new OracleParameter();
			p_Description.ParameterName = "p_Description";
			p_Description.OracleType =OracleType.VarChar;
			p_Description.Direction = ParameterDirection.Input;
			p_Description.Size= 2000;
			p_Description.Value =((System.Web.UI.WebControls.TextBox)Panel1.Controls[0].FindControl("txtsProblema")).Text;			
			_SColl.Add(p_Description);


			OracleParameter s_Servizio = new OracleParameter();
			s_Servizio.ParameterName="p_Servizio_Id";
			s_Servizio.OracleType =OracleType.Int32;
			s_Servizio.Direction = ParameterDirection.Input;
			DropDownList cmbsServizio=(DropDownList)Panel1.Controls[0].FindControl("cmbsServizio");
			s_Servizio.Value = (cmbsServizio.SelectedValue ==string.Empty)? 0:Convert.ToInt32(cmbsServizio.SelectedValue);	
			_SColl.Add(s_Servizio);		
			
			OracleParameter s_EqId = new OracleParameter();
			s_EqId.ParameterName = "p_Eq_Id";
			s_EqId.OracleType =OracleType.Int32;
			s_EqId.Direction = ParameterDirection.InputOutput;
			DropDownList cmbsAppare=(DropDownList)Panel1.Controls[0].FindControl("cmbsAppare");
			s_EqId.Value = (cmbsAppare.SelectedValue ==string.Empty)? 0: Convert.ToInt32(cmbsAppare.SelectedValue);
			_SColl.Add(s_EqId);


			OracleParameter p_Eqstd_Id = new OracleParameter();
			p_Eqstd_Id.ParameterName = "p_Eqstd_Id";
			p_Eqstd_Id.OracleType =OracleType.Int32;
			p_Eqstd_Id.Direction = ParameterDirection.Input;
			DropDownList cmbsApp=(DropDownList)Panel1.Controls[0].FindControl("cmbsApp");
			p_Eqstd_Id.Value = (cmbsApp.SelectedValue ==string.Empty)? 0: Convert.ToInt32(cmbsApp.SelectedValue);
			_SColl.Add(p_Eqstd_Id);


			OracleParameter p_Date_Requested = new OracleParameter();
			p_Date_Requested.ParameterName = "p_Date_Requested";
			p_Date_Requested.OracleType =OracleType.VarChar;
			p_Date_Requested.Direction = ParameterDirection.Input;
			p_Date_Requested.Size= 10;
			p_Date_Requested.Value =((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblDataRichiesta")).Text;			
			_SColl.Add(p_Date_Requested);

			OracleParameter p_Time_Requested = new OracleParameter();
			p_Time_Requested.ParameterName = "p_Time_Requested";
			p_Time_Requested.OracleType =OracleType.VarChar;
			p_Time_Requested.Direction = ParameterDirection.Input;
			p_Time_Requested.Size= 10;
			p_Time_Requested.Value =((System.Web.UI.MobileControls.Label)Panel1.Controls[0].FindControl("lblOraRichiesta")).Text;			
			_SColl.Add(p_Time_Requested);

			try
			{
				
				i_WrId = _Richiesta.Crea(_SColl);
			}
			catch (Exception ex)
			{
              Console.WriteLine(ex.Message);
			  return 0;
			}
			return i_WrId;
		}
		
	}
}
