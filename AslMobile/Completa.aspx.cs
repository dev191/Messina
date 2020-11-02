using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Web;
using System.Web.Mobile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace TheSite.AslMobile
{
	/// <summary>
	/// Descrizione di riepilogo per Completa.
	/// </summary>
	public class Completa : System.Web.UI.MobileControls.MobilePage
	{
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific3;
		protected System.Web.UI.MobileControls.Panel Panel3;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific1;
		protected System.Web.UI.MobileControls.Panel Panel1;
		protected System.Web.UI.MobileControls.Form Form2;
		protected System.Web.UI.MobileControls.Panel Panel4;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific4;
		protected System.Web.UI.MobileControls.Calendar Calendar1;


		protected System.Web.UI.MobileControls.Form Form1;
		protected System.Web.UI.MobileControls.Form Form3;
		protected System.Web.UI.MobileControls.Form Form4;
		protected System.Web.UI.MobileControls.Label lbltipodata;
		protected System.Web.UI.MobileControls.Link Link8;
		private int itemId=0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{
				((System.Web.UI.HtmlControls.HtmlTable)Panel4.Controls[0].Controls[0].FindControl("tableconferma")).Visible=false;

				if (Request.QueryString["ItemID"]!=null)
					itemId= Int32.Parse(Request.QueryString["ItemID"].ToString());

				SetValue(Panel4,"lblDataStart",System.DateTime.Now.ToShortDateString());
				SetValue(Panel4,"lblDataEnd",System.DateTime.Now.ToShortDateString());
			
	
				this.BindStatoLavoro("");
				LoadDati();

				ActiveForm = Form3;
			}
			System.Web.UI.MobileControls.Calendar cal = (System.Web.UI.MobileControls.Calendar)Form4.Controls[0].FindControl("Calendar1");

			cal.SelectedDates.Clear();

		}
		protected void OnSalva(object sender, System.EventArgs e)
		{
          Controlli(false);
		}
		private void Controlli(bool ControllaCapit)
		{

			System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5=(System.Web.UI.WebControls.RequiredFieldValidator)Panel4.Controls[0].FindControl("RequiredFieldValidator5");
			RequiredFieldValidator5.Validate(); 
			System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator6=(System.Web.UI.WebControls.RequiredFieldValidator)Panel4.Controls[0].FindControl("RequiredFieldValidator6");
			RequiredFieldValidator6.Validate(); 
			System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator7=(System.Web.UI.WebControls.RequiredFieldValidator)Panel4.Controls[0].FindControl("RequiredFieldValidator7");
			RequiredFieldValidator7.Validate(); 
			System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator8=(System.Web.UI.WebControls.RequiredFieldValidator)Panel4.Controls[0].FindControl("RequiredFieldValidator8");
			RequiredFieldValidator8.Validate(); 

			if(RequiredFieldValidator5.IsValid && RequiredFieldValidator6.IsValid && RequiredFieldValidator7.IsValid && RequiredFieldValidator8.IsValid)
			{
				
				int OraInizio=(GetValue(Panel4,"txtOraStart")=="")?0:int.Parse(GetValue(Panel4,"txtOraStart"));	
				int MinutiInizio=(GetValue(Panel4,"txtMinutiStart")=="")?0:int.Parse(GetValue(Panel4,"txtMinutiStart"));	
				int OraFine=(GetValue(Panel4,"txtOraEnd")=="")?0:int.Parse(GetValue(Panel4,"txtOraEnd"));
				int MinutiFine=(GetValue(Panel4,"txtMinutiEnd")=="")?0:int.Parse(GetValue(Panel4,"txtMinutiEnd"));
				string[] dts=GetValue(Panel4,"lblDataStart").Split(Convert.ToChar("/"));
				string[] dte=GetValue(Panel4,"lblDataEnd").Split(Convert.ToChar("/"));
//				string DateS=dts[2] + dts[1] + dts[0] + OraInizio.ToString() + MinutiInizio.ToString();
//				string DateE=dte[2] + dte[1] + dte[0] + OraFine.ToString() + MinutiFine.ToString();

				
//				if (DateS.CompareTo(DateE)>0)
//				{
//					SetValue(Panel4,"lblError","La data di inizio lavori non può essere maggiore della data di fine lavori.");
//					return;
//				}
				System.DateTime DateS=new System.DateTime(int.Parse(dts[2]),int.Parse(dts[1]),int.Parse(dts[0]),OraInizio, MinutiInizio,0);
				System.DateTime DateE=new System.DateTime(int.Parse(dte[2]),int.Parse(dte[1]),int.Parse(dte[0]),OraFine, MinutiFine,0);
				if (DateS>DateE)
				{
					SetValue(Panel4,"lblError","La data di inizio lavori non può essere maggiore della data di fine lavori.");
					return;
				}

				string capitolato=((System.Web.UI.HtmlControls.HtmlInputHidden)Panel4.Controls[0].FindControl("Hiddetempointervento")).Value;
 
				
				if(capitolato!="")
				{
					string[] dtp=GetValue(Panel3,"lblDataRichiesta").Split(Convert.ToChar("/"));
					string[] orap=GetValue(Panel3,"lblOraRichiesta").Split(Convert.ToChar("."));
					int Capitolato=int.Parse(capitolato);
					System.DateTime DTRichiesta=new System.DateTime(int.Parse(dtp[2]),int.Parse(dtp[1]),int.Parse(dtp[0]),int.Parse(orap[0]), int.Parse(orap[1]),0);
					System.DateTime DTinizioLavori= new System.DateTime(int.Parse(dts[2]), int.Parse(dts[1]),int.Parse(dts[0]),OraInizio,MinutiInizio,0);

					System.TimeSpan diff1 =DTinizioLavori.Subtract(DTRichiesta);

					if (diff1.TotalHours > Capitolato && ControllaCapit==false)
					{
						//						SetValue(Panel4,"lblError","Data non conforme al capitolato. Continuare?");
						((System.Web.UI.HtmlControls.HtmlTable)Panel4.Controls[0].Controls[0].FindControl("tableconferma")).Visible=true;
						((System.Web.UI.HtmlControls.HtmlTable)Panel4.Controls[0].Controls[0].FindControl("tableSalva")).Visible=false;
						return;
					}	
					else
					{
						string[] dtpia=GetValue(Panel1,"ldldatap").Split(Convert.ToChar("/"));
						string OraP=GetValue(Panel1,"lblorap");
						string[] orapia;
                        if(OraP.IndexOf(".")>0)
						  orapia=OraP.Split(Convert.ToChar("."));
						else
						  orapia=OraP.Split(Convert.ToChar(":"));

						System.DateTime DPianificata= new System.DateTime(int.Parse(dtpia[2]), int.Parse(dtpia[1]),int.Parse(dtpia[0]),int.Parse(orapia[0]),int.Parse(orapia[1]),0);
						if (DPianificata>DTinizioLavori)
						{
							SetValue(Panel4,"lblError","La Data Inizio Lavori  è minore della Data richiesta Lavoro!");	
							return;					
						}			
					}	
				}
				
				UpdateRichiesta();
			
			}	
		}

		protected void cmdC_OnItemCommand(object sender, CommandEventArgs e)
		{		
			if(e.CommandArgument.ToString()=="salva")
			{
				Controlli(true);
			}
			((System.Web.UI.HtmlControls.HtmlTable)Panel4.Controls[0].Controls[0].FindControl("tableconferma")).Visible=false;
			((System.Web.UI.HtmlControls.HtmlTable)Panel4.Controls[0].Controls[0].FindControl("tableSalva")).Visible=true;
		}

		protected void Calendar_SelectionChangedDataStart(Object sender, EventArgs e)
		{
			if(((System.Web.UI.MobileControls.Label)Form4.Controls[0].FindControl("lbltipodata")).Text=="Data di inizio Lavori")
			 ((System.Web.UI.MobileControls.Label)Panel4.Controls[0].FindControl("lblDataStart")).Text = Calendar1.SelectedDate.ToShortDateString();
			else
			((System.Web.UI.MobileControls.Label)Panel4.Controls[0].FindControl("lblDataEnd")).Text = Calendar1.SelectedDate.ToShortDateString();

			ActiveForm = Form3;
		}


		protected void cmd_OnItemCommand(object sender, CommandEventArgs e)
		{		
			if(e.CommandArgument.ToString()=="S")
			 ((System.Web.UI.MobileControls.Label)Form4.Controls[0].FindControl("lbltipodata")).Text="Data di inizio Lavori"; 
			else
			((System.Web.UI.MobileControls.Label)Form4.Controls[0].FindControl("lbltipodata")).Text="Data di fine Lavori"; 

			this.ActiveForm = Form4;
		}

		private void BindStatoLavoro(string idstato)
		{
			DropDownList cmbsstatolavoro = (DropDownList)Panel4.Controls[0].Controls[0].FindControl("cmbsstatolavoro");
			cmbsstatolavoro.Items.Clear();		
		
			Class.ClassRDL _AggiornamentoRdl =new Class.ClassRDL("");

			DataSet _MyDs = _AggiornamentoRdl.GetStatoLavoro();

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				cmbsstatolavoro.DataSource = _AggiornamentoRdl.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "id", "- Selezionare lo Stato di Lavoro  -", "");
				cmbsstatolavoro.DataTextField = "descrizione";
				cmbsstatolavoro.DataValueField = "id";
				cmbsstatolavoro.DataBind();

				if(idstato!="")
					if(idstato!="3")
						foreach (ListItem ite in cmbsstatolavoro.Items)
						{
							if(ite.Value=="3")
								cmbsstatolavoro.Items.Remove(ite);
						}
                             
                        
				if(idstato=="3" || idstato=="4")//accorpata e completata
				{
					//							S_Btinvia.Enabled =false;
					cmbsstatolavoro.Enabled =false;
				}

				cmbsstatolavoro.SelectedValue =idstato;

				//this.cmbsstatolavoro.Attributes.Add("OnChange","SetWorkType(this.value);"); 
			}
			else
			{
				string s_Messaggio = "- Nessuno Stato di Lavoro  -";
				cmbsstatolavoro.Items.Add(new ListItem(s_Messaggio,String.Empty));
			}
			
		}
	
	protected void Selection_SelectedIndexLavoro(object sender, System.EventArgs e)
		{
			DropDownList cmbsstatolavoro = (DropDownList)Panel4.Controls[0].Controls[0].FindControl("cmbsstatolavoro");
			int scelta = (cmbsstatolavoro.SelectedValue=="")?0:Int32.Parse(cmbsstatolavoro.SelectedValue);
			switch(scelta)
			{
				case 11: //Emessa ma sospesa per Inaccessibilità				
				case 12: //Emessa ma sospesa per approvviggiovamento				
				case 14: //Emessa ma sospesa dal committente			
				case 8: //Emessa ma sospesa 
				case 13:
					((System.Web.UI.HtmlControls.HtmlTable)Panel4.Controls[0].Controls[0].FindControl("TableSospesaLavoro")).Visible=true;
					break;
				default:
					((System.Web.UI.HtmlControls.HtmlTable)Panel4.Controls[0].Controls[0].FindControl("TableSospesaLavoro")).Visible=false;
					break;
			}
		}

		private void UpdateRichiesta()
		{
			Class.ClassRDL _RDL = new AslMobile.Class.ClassRDL("");

			OracleParameterCollection CollezioneControlli=new OracleParameterCollection();
			
			//ok
			OracleParameter  s_p_id_status = new OracleParameter();
			s_p_id_status.ParameterName = "p_id_status";
			s_p_id_status.OracleType =OracleType.Int32;
			s_p_id_status.Direction = ParameterDirection.Input;
			s_p_id_status.Value =GetValue(Panel4,"cmbsstatolavoro");
			CollezioneControlli.Add(s_p_id_status);

			//ok
			OracleParameter s_p_date_start =new OracleParameter();
			s_p_date_start.ParameterName = "p_date_start";
			s_p_date_start.OracleType = OracleType.VarChar;
			s_p_date_start.Direction = ParameterDirection.Input;
			s_p_date_start.Size =30;
			//Data Inizio	
			string data_inizio=string.Empty; 
			string date_start=GetValue(Panel4,"lblDataStart");
			if(date_start!="")
			{ 
				string ora_Inizio=((GetValue(Panel4,"txtOraStart")=="")?"00":GetValue(Panel4,"txtOraStart")) + ":" + ((GetValue(Panel4,"txtMinutiStart")=="")?"00":GetValue(Panel4,"txtMinutiStart")) + ":00";
				data_inizio = date_start + " " + ora_Inizio;  
			}

			s_p_date_start.Value =data_inizio;
			CollezioneControlli.Add(s_p_date_start);
			
			//ok
			OracleParameter s_p_date_end = new OracleParameter();
			s_p_date_end.ParameterName = "p_date_end";
			s_p_date_end.OracleType=OracleType.VarChar;
			s_p_date_end.Direction = ParameterDirection.Input;
			s_p_date_end.Size =30;
			//Data Inizio	GetValue(Panel4,"txtsOreFine")
			string data_fine=string.Empty; 
			string date_end=GetValue(Panel4,"lblDataEnd");;
			if(date_end!="")
			{ 
				string ora_fine=((GetValue(Panel4,"txtOraEnd")=="")?"00":GetValue(Panel4,"txtOraEnd")) + ":" + ((GetValue(Panel4,"txtMinutiEnd")=="")?"00":GetValue(Panel4,"txtMinutiEnd")) + ":00";
				data_fine = date_end + " " + ora_fine;  
			}

			s_p_date_end.Value =data_fine;
			CollezioneControlli.Add(s_p_date_end);
			//ok
			OracleParameter s_p_comments = new OracleParameter();
			s_p_comments.ParameterName = "p_comments";
			s_p_comments.OracleType = OracleType.VarChar;
			s_p_comments.Direction = ParameterDirection.Input;
			s_p_comments.Size =4000;
			s_p_comments.Value =GetValue(Panel4,"txtAnnotazioni");
			CollezioneControlli.Add(s_p_comments);

			//ok
			OracleParameter s_p_sospesa = new OracleParameter();
			s_p_sospesa.ParameterName = "p_sospesa";
			s_p_sospesa.OracleType = OracleType.VarChar;
			s_p_sospesa.Direction = ParameterDirection.Input;
			s_p_sospesa.Size =2000;
			s_p_sospesa.Value =GetValue(Panel4,"txtSospesa");
			CollezioneControlli.Add(s_p_sospesa);
            
			int Wr=0;
			CreazioneRichiesta1 Cre1=(CreazioneRichiesta1)Panel3.Controls[0].Controls[0].FindControl("CreazioneRichiesta1");
			string Rdl=Cre1.Rdl;
			Wr =int.Parse(Cre1.Rdl);
			_RDL.Update(CollezioneControlli,Wr);

			this.RedirectToMobilePage("RCompleta.aspx");


		}
		private void LoadDati()
		{
	
			Class.ClassRDL _RDL = new AslMobile.Class.ClassRDL("");
			DataSet _MyDs = _RDL.GetSingleRdl(itemId);
			if (_MyDs.Tables[0].Rows.Count>0)
			{
				DataRow _Dr = _MyDs.Tables[0].Rows[0];				
				int bl_id=Int32.Parse(_Dr["id_bl"].ToString());
				 


				//Tempo di intervento'
				if (_Dr["data_sla"] != DBNull.Value)
					((System.Web.UI.HtmlControls.HtmlInputHidden)Panel4.Controls[0].FindControl("Hiddetempointervento")).Value=_Dr["data_sla"].ToString();
				else
					((System.Web.UI.HtmlControls.HtmlInputHidden)Panel4.Controls[0].FindControl("Hiddetempointervento")).Value="";

				//STATO DELLA RDL
				CreazioneRichiesta1 Cre1=(CreazioneRichiesta1)Panel3.Controls[0].Controls[0].FindControl("CreazioneRichiesta1"); 
				Cre1.SetData(_Dr);
				CreazioneRichiesta2 Cre2=(CreazioneRichiesta2)Panel1.Controls[0].Controls[0].FindControl("CreazioneRichiesta2"); 
				
				DataSet _MyDsStato= _RDL.GetStatusRdl(itemId);
				if (_MyDsStato.Tables[0].Rows.Count>0)
				{
					DataRow _DrStato = _MyDsStato.Tables[0].Rows[0];
					Cre2.SetData(_Dr,_DrStato);
				}
				else
				   Cre2.SetData(_Dr,null);


				CompletamentoOrdine(_Dr);

			}
		}

		private void CompletamentoOrdine(DataRow _Dr)
		{
			//in base allo status visualizzo la riga html
			if (_Dr["idstatus"] != DBNull.Value)
			{
				if  (int.Parse( _Dr["idstatus"].ToString())==8 || int.Parse( _Dr["idstatus"].ToString())==11 || int.Parse( _Dr["idstatus"].ToString())==12
					|| int.Parse( _Dr["idstatus"].ToString())==13 || int.Parse( _Dr["idstatus"].ToString())==14)
					((System.Web.UI.HtmlControls.HtmlTable)Panel4.Controls[0].Controls[0].FindControl("TableSospesaLavoro")).Visible=true;
				else
					((System.Web.UI.HtmlControls.HtmlTable)Panel4.Controls[0].Controls[0].FindControl("TableSospesaLavoro")).Visible=false;
				//Carico la combo
				BindStatoLavoro(_Dr["idstatus"].ToString());
			}
			else
			{
				//Carico la combo 
				BindStatoLavoro("");
				//				this.trnote.Attributes.Add("style","display:none");
				((System.Web.UI.HtmlControls.HtmlTable)Panel4.Controls[0].Controls[0].FindControl("TableSospesaLavoro")).Visible=false;
			}

			//nota Sospesa
			if (_Dr["notesospesa"] != DBNull.Value)
				SetValue(Panel4,"txtSospesa",_Dr["notesospesa"].ToString());

		
			if (_Dr["date_start"]!=DBNull.Value)
				SetValue(Panel4,"lblDataStart",System.DateTime.Parse(_Dr["date_start"].ToString()).ToShortDateString());
	
			if (_Dr["date_end"]!=DBNull.Value)
				SetValue(Panel4,"lblDataEnd",System.DateTime.Parse(_Dr["date_end"].ToString()).ToShortDateString());
				

			if (_Dr["date_start"]!=DBNull.Value)
			{
				System.DateTime OraIni= System.DateTime.Parse(_Dr["date_start"].ToString());
				SetValue(Panel4,"txtOraStart",OraIni.Hour.ToString().PadLeft(2,Convert.ToChar("0")));
				SetValue(Panel4,"txtMinutiStart",OraIni.Minute.ToString().PadLeft(2,Convert.ToChar("0")));
			}
			if (_Dr["date_end"]!=DBNull.Value)
			{
				System.DateTime OraFine= System.DateTime.Parse(_Dr["date_end"].ToString());      
				SetValue(Panel4,"txtOraEnd",OraFine.Hour.ToString().PadLeft(2,Convert.ToChar("0"))) ;
				SetValue(Panel4,"txtMinutiEnd",OraFine.Minute.ToString().PadLeft(2,Convert.ToChar("0")));
			}
			if (_Dr["comments"] != DBNull.Value)
				SetValue(Panel4,"txtAnnotazioni",_Dr["comments"].ToString());
			

		}
				
		private void SetValue(Control Ctrl,string NameField, string value)
		{
			
		     Control Ct=Ctrl.Controls[0].FindControl(NameField);
//			value=value.Replace("\n"," ");
//			value=value.Replace("\r",""); 
			if (Ct is System.Web.UI.MobileControls.Label)
				((System.Web.UI.MobileControls.Label)Ctrl.Controls[0].FindControl(NameField)).Text=value;

			if (Ct is System.Web.UI.MobileControls.TextBox)
				((System.Web.UI.MobileControls.TextBox)Ctrl.Controls[0].FindControl(NameField)).Text=value;

			if (Ct is System.Web.UI.WebControls.TextBox)
				((System.Web.UI.WebControls.TextBox)Ctrl.Controls[0].FindControl(NameField)).Text=value;

			if (Ct is DropDownList)
				((DropDownList)Ctrl.Controls[0].FindControl(NameField)).SelectedValue=value;
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
			DropDownList cmbsstatolavoro = (DropDownList)Panel4.Controls[0].Controls[0].FindControl("cmbsstatolavoro");
			cmbsstatolavoro.SelectedIndexChanged+=new EventHandler(this.Selection_SelectedIndexLavoro);
			cmbsstatolavoro.AutoPostBack=true;
			//			
//			((System.Web.UI.HtmlControls.HtmlTable)Panel4.Controls[0].Controls[0].FindControl("TableOraStart")).Visible=false;
//			((System.Web.UI.HtmlControls.HtmlTable)Panel4.Controls[0].Controls[0].FindControl("TableOraEnd")).Visible=false;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
