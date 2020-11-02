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
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using ApplicationDataLayer.Collections;
using S_Controls.Collections;
using System.Reflection;
using StampaRapportiPdf.Classi;

namespace TheSite.Gestione
{

	/// <summary>
	/// Descrizione di riepilogo per DescrizioneApparecchiatura.
	/// </summary>
	public class DescrizioneApparecchiatura : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected S_Controls.S_ComboBox cmbsCondizione;
		protected S_Controls.S_ComboBox cmbsUDM;
		protected System.Web.UI.WebControls.CheckBox ChkInsertMan;
		protected System.Web.UI.WebControls.CheckBox Contatore;
		protected S_Controls.S_TextBox S_Txtmodello;
		protected S_Controls.S_TextBox S_Txttipo;
		protected S_Controls.S_TextBox S_Txtqta;
		protected S_Controls.S_TextBox S_TxtRif;
		protected S_Controls.S_TextBox S_TxtqtaMatInt;
		protected S_Controls.S_TextBox S_TxtqtaMatDec;
		protected S_Controls.S_ComboBox cmbsvenditore;
		protected S_Controls.S_ComboBox cmbEnteErogante;
		protected S_Controls.S_ComboBox cmbsApparecchiatura;
		protected S_Controls.S_Button S_BtInvia;
		protected S_Controls.S_Button S_btannulla;
		protected S_Controls.S_Button BtnNuovo;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RQApparecchiatura;
		protected System.Web.UI.WebControls.RequiredFieldValidator RQCondizione;
		protected S_Controls.S_ComboBox cmbsPiano;
		protected System.Web.UI.HtmlControls.HtmlInputFile Uploader;
		protected System.Web.UI.HtmlControls.HtmlInputFile Upload;

		protected S_Controls.S_Label S_Lblerror;
		protected System.Web.UI.HtmlControls.HtmlInputButton S_BtDatiTecnici;
		protected S_Controls.S_Label S_Lblcodedificio;
		protected S_Controls.S_Label lblCodApparecchiatura;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden_codiceservizio;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden_idservizio;
		protected S_Controls.S_Label lblServizioDescription;
		protected S_Controls.S_ComboBox cmbsMacro;
		protected WebControls.PageTitle PageTitle1;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected S_Controls.S_Label lblFirstAndLast;
		protected WebControls.CalendarPicker CalendarPicker2;  
        public string Imagename=string.Empty;
		public static int FunId = 0;
		protected S_Controls.S_CheckBox ChekDismesso;
		protected S_Controls.S_ComboBox cmbsUnita;
		public static string HelpLink = string.Empty;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Panel PanelEditAnag;
		protected Microsoft.Web.UI.WebControls.TabStrip TabStrip1;
		protected System.Web.UI.WebControls.LinkButton lkbNuovo;
		protected System.Web.UI.WebControls.Label lblRecord;
		protected System.Web.UI.WebControls.DataGrid DataGridEsegui;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenEq;
		protected System.Web.UI.WebControls.Panel PanelEditDocumenti;
		protected String[] appo;
		protected Csy.WebControls.MessagePanel PanelMess;
		public static int TabId = 0;
		protected WebControls.UserStanze UserStanze1;
		protected System.Web.UI.WebControls.TextBox  txtApparechiatura;
		protected System.Web.UI.WebControls.RadioButtonList RBLInserimento;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton Radio1;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton opt1;


		#region proprieta collection
		public clMyCollection _Contenitore
		{
			get 
			{
				if(this.ViewState["mioContenitore"]!=null)
					return (clMyCollection)this.ViewState["mioContenitore"];
				else
					return new clMyCollection();
			}
		}
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			TabStrip1.Attributes.Add("onclick","Abilita(this.selectedIndex);");
			TabId = TabStrip1.SelectedIndex;

			UserStanze1.NameUserControlRicercaModulo = "RicercaModulo1";
			UserStanze1.NameComboPiano="cmbsPiano";
			UserStanze1.NameLblId="S_Lblcodedificio";


			// Inserire qui il codice utente necessario per inizializzare la pagina.;
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];		
						
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;

			S_Lblerror.Text="";
			S_BtDatiTecnici.Disabled =true;

			Uploader.Accept="image/*";

			System.Text.StringBuilder sbValidApprova = new System.Text.StringBuilder();
            sbValidApprova.Append("return tipoInserimento(); if (typeof(ControllaData) == 'function' && typeof(Page_ClientValidate) == 'function') { ");
			sbValidApprova.Append("if (ControllaData() == false || Page_ClientValidate() == false) { return false; }} ");
			sbValidApprova.Append(this.Page.GetPostBackEventReference(this.S_BtInvia));
			sbValidApprova.Append(";");
			S_BtInvia.Attributes.Add("onclick",sbValidApprova.ToString());
			Contatore.Attributes.Add("onclick","AbilitaCmbsUM();");
				
			S_TxtqtaMatInt.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			S_TxtqtaMatInt.Attributes.Add("onpaste","return false;");
			

			S_TxtqtaMatDec.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			S_TxtqtaMatDec.Attributes.Add("onpaste","return false;");
			cmbsPiano.Attributes.Add("onchange","clearRoom();");
			 
	//	RBLInserimento.Attributes.Add("onclick","Nascondi();");
	//	RBLInserimento.Items[1].Attributes.Add("onclick","Nascondi();");
	//		S_BtInvia.Attributes.Add("onclick","tipoInserimento();");

			if(!IsPostBack)
			{
				
				#region Recupero la proprieta di ricerca
				// Recupero il tipo dall'oggetto context.
				Type myType=Context.Handler.GetType();       
				// recupero il PropertyInfo object passando il nome della proprietà da recuperare.
				PropertyInfo myPropInfo = myType.GetProperty("_Contenitore");
				// verifico che questa proprietà esista.
				if(myPropInfo!=null)
					this.ViewState.Add("mioContenitore",myPropInfo.GetValue(Context.Handler,null));
				#endregion
			
				if (Context.Items["CODEDI"]!=null)
					this.S_Lblcodedificio.Text=(string)Context.Items["CODEDI"];
			  //Ritorna l'ID del BL 
				if (Context.Items["IDBL"]!=null)
					this.BL_ID=(string)Context.Items["IDBL"];

	
				//	ritorna IDEQ in caso di modifica
				if (Context.Items["IDEQ"]!=null && Context.Items["IDEQ"].ToString()!="")
				{
					this.IDEQ=(string)Context.Items["IDEQ"]; 
					BindGrid();
					if (Context.Items["DISMESSO"].ToString()=="DISMESSA")
						ChekDismesso.Checked=true;
				}
				else
				{
					TabStrip1.Items[1].Enabled=false;
					
				}
                 //Descrizione del servizio
				if (Context.Items["SDESCRIZIONE"]!=null && Context.Items["SDESCRIZIONE"].ToString()!="")
					lblServizioDescription.Text =(string)Context.Items["SDESCRIZIONE"];
				//codice del servizio
				//MARIANNA
			//	if (Context.Items["SCODICE"]!=null)
			//		Hidden_codiceservizio.Value =(string)Context.Items["SCODICE"];
				//id del servizio
				if (Context.Items["SID"]!=null && Context.Items["SID"].ToString()!="")
					Hidden_idservizio.Value  =(string)Context.Items["SID"];

				
				if(S_Txtqta.Text=="")
				{
					S_Txtqta.Text="1";
				}
				if(S_TxtqtaMatInt.Text=="")
				{
					S_TxtqtaMatInt.Text="0";
				}
				if(S_TxtqtaMatDec.Text=="")
				{
					S_TxtqtaMatDec.Text="00";
				}
				BindCondition(0);
				BindVenditore(0);
//				BindServizio(this.BL_ID);
				BindUnitaMisura();
				BindApparecchiatura();
				BindPiano(int.Parse(this.BL_ID));
				BindMacroComponente();
				BindUM();
				BindEnteErogante();
				GetData();
			}
		}

		private void GetData()
		{
		  if (this.IDEQ=="") 
		  {S_ControlsCollection _SColl = new S_ControlsCollection();
			 S_Controls.Collections.S_Object s_p_Servizio = new S_Object();
			s_p_Servizio.ParameterName = "p_Servizio";
			s_p_Servizio.DbType = CustomDBType.Integer ;
			s_p_Servizio.Direction = ParameterDirection.Input;
			s_p_Servizio.Index =0;
			s_p_Servizio.Value = Hidden_idservizio.Value;
				
			  S_Controls.Collections.S_Object s_p_id_bl = new S_Object();
			  s_p_id_bl.ParameterName = "p_id_bl";
			  s_p_id_bl.DbType = CustomDBType.Integer ;
			  s_p_id_bl.Direction = ParameterDirection.Input;
			  s_p_id_bl.Index =1;
			  s_p_id_bl.Value = this.BL_ID;
			  
			  
			  _SColl.Add(s_p_Servizio);
			  _SColl.Add(s_p_id_bl);

			  TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura _DatiApparecchiatura1 = new TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura(Context.User.Identity.Name);
				DataSet	_Ds1 =_DatiApparecchiatura1.GetDateServiziEdifici(_SColl);
					if(_Ds1.Tables[0].Rows.Count >0)
					{
						DataRow _Dr1=_Ds1.Tables[0].Rows[0];
						//Data di Inizio Validità
						if (_Dr1["date_start"]!=DBNull.Value)
							CalendarPicker1.Datazione.Text =System.DateTime.Parse(_Dr1["date_start"].ToString()).ToShortDateString();

//						//Data di Fine Validità
						if (_Dr1["date_end"]!=DBNull.Value)
							CalendarPicker2.Datazione.Text=System.DateTime.Parse(_Dr1["date_end"].ToString()).ToShortDateString();
					
					}
		  
		  return;}

			  
			  
		  	BindGrid();
			TabStrip1.Items[1].Enabled=true;
			TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura  _DatiApparecchiatura = new TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura(Context.User.Identity.Name);
			
			DataSet	_Ds = _DatiApparecchiatura.GetApparecchiatura(int.Parse(this.IDEQ));
			if(_Ds.Tables[0].Rows.Count >0)
			{
				
				S_BtDatiTecnici.Disabled =false;

				DataRow Dr=_Ds.Tables[0].Rows[0];
    
				if (Dr["IDSERVIZIO"]!=DBNull.Value)
				{
					Hidden_codiceservizio.Value =Dr["IDSERVIZIO"].ToString().Split(Convert.ToChar(" "))[1];
					Hidden_idservizio.Value =Dr["IDSERVIZIO"].ToString().Split(Convert.ToChar(" "))[0];
				}
				
				if (Dr["DESCRIZIONESERVIZIO"]!=DBNull.Value)
				    lblServizioDescription.Text =Dr["DESCRIZIONESERVIZIO"].ToString();

                BindApparecchiatura();

			    if (Dr["eq_stdid"]!=DBNull.Value)
					cmbsApparecchiatura.SelectedValue=Dr["eq_stdid"].ToString();
  
				if (Dr["IDP"]!=DBNull.Value)
					cmbsPiano.SelectedValue=Dr["IDP"].ToString(); 
				
				appo= cmbsPiano.SelectedValue.Split(' ');
				int i = int.Parse(appo[0]);
			
				if(Dr["stanza"]!=DBNull.Value)
					UserStanze1.DescStanza=Dr["stanza"].ToString();

				if (Dr["IDS"]!=DBNull.Value)
					UserStanze1.IdStanza=Dr["IDS"].ToString();

				if (Dr["quantita"]!=DBNull.Value)
					S_Txtqta.Text=Dr["quantita"].ToString();
				//*****************//
//				if (Dr["IDUNITAMISURA"]!=DBNull.Value)
//				{
//					cmbsUnita.SelectedValue=Dr["IDUNITAMISURA"].ToString();
//				}

				if (Dr["NUMEROUNITA"]!=DBNull.Value)
				{
					this.S_TxtqtaMatInt.Text=Classi.Function.GetTypeNumber(Dr["NUMEROUNITA"],Classi.NumberType.Intero).ToString(); 
					this.S_TxtqtaMatDec.Text=Classi.Function.GetTypeNumber(Dr["NUMEROUNITA"],Classi.NumberType.Decimale).ToString(); 
				}
				//********************//

				if (Dr["id_condition"]!=DBNull.Value && Dr["id_condition"].ToString()!="0")
					cmbsCondizione.SelectedValue=Dr["id_condition"].ToString();
 
				if (Dr["id_vn"]!=DBNull.Value && Dr["id_vn"].ToString()!="0")
					cmbsvenditore.SelectedValue=Dr["id_vn"].ToString();

                //Macro componente
				if (Dr["subcomponent_of"]!=DBNull.Value)
					cmbsMacro.SelectedValue=Dr["subcomponent_of"].ToString();
				
				//Data di Inizio Validità
				if (Dr["date_start_validate"]!=DBNull.Value)
					CalendarPicker1.Datazione.Text =System.DateTime.Parse(Dr["date_start_validate"].ToString()).ToShortDateString();

				//Data di Fine Validità
				if (Dr["date_end_validate"]!=DBNull.Value)
					CalendarPicker2.Datazione.Text=System.DateTime.Parse(Dr["date_end_validate"].ToString()).ToShortDateString();

				if (Dr["modello"]!=DBNull.Value)
					S_Txtmodello.Text=Dr["modello"].ToString();

				if (Dr["tipo"]!=DBNull.Value)
					S_Txttipo.Text=Dr["tipo"].ToString();
		

				if (Dr["rifPlanimetria"]!=DBNull.Value)
				S_TxtRif.Text=Dr["rifPlanimetria"].ToString();

				if (Dr["EQ_ID"]!=DBNull.Value)
					this.EQ_ID=Dr["EQ_ID"].ToString();

				if (Dr["contatore"]!=DBNull.Value)
				{
					if(Dr["contatore"].ToString()=="1")
					{
						Contatore.Checked=true;
						cmbsUDM.Enabled=true;
						
//						if(Dr["UMD"]!=DBNull.Value)
//							cmbsUDM.SelectedValue=Dr["UMD"].ToString();

						
					}
					else
					{
						Contatore.Checked=false;
						cmbsUDM.Enabled=false;
					}
				}

//				if(Dr["EnteErogante"]!= DBNull.Value)
//					cmbEnteErogante.SelectedValue= Dr["EnteErogante"].ToString();

				
				string query="IDEQ=" + this.IDEQ + "&EQ_ID=" + this.EQ_ID; 
                S_BtDatiTecnici.Attributes.Add("onclick","opendoc('" + query + "');");  

				if (Dr["image_eq_assy"]!=DBNull.Value)
				{
					this.ImageName=Dr["image_eq_assy"].ToString();
					Imagename="eq_image=" + Dr["image_eq_assy"].ToString();
				}
				lblFirstAndLast.Text = _DatiApparecchiatura.GetFirstAndLastUser(Dr);

				lblCodApparecchiatura.Text=string.Format(" Codice Apparecchatura: {0}", Dr["EQ_ID"]); 

				txtApparechiatura.Text =Dr["EQ_ID"].ToString();
				txtApparechiatura.Enabled=false;
				}

		}



		#region Proprietà
		private string BL_ID
		{
			get
			{if(ViewState["BL_ID"]!=null)
			   return (string)ViewState["BL_ID"];
             else
				 return string.Empty;
			}
			set
			{
			 ViewState.Add("BL_ID",value);
			}
		}
		private string EQ_ID
		{
			get
			{
					if(ViewState["EQ_ID"]!=null)
				 return (string)ViewState["EQ_ID"];
			 else
				 return string.Empty;
			}
			set
			{
				ViewState.Add("EQ_ID",value);
			}
		}
		private string IDEQ
		{
			get
			{
					if(ViewState["IDEQ"]!=null)
				 return (string)ViewState["IDEQ"];
			 else
				 return string.Empty;
			}
			set
			{
				ViewState.Add("IDEQ",value);
			}
		}
		private string ImageName
		{
			get
			{
				if(ViewState["ImageName"]!=null)
					return (string)ViewState["ImageName"];
				else
					return string.Empty;
			}
			set
			{
				ViewState.Add("ImageName",value);
			}
		}
		#endregion


		
		private void BindMacroComponente()
		{
		  this.cmbsMacro.Items.Clear();
          TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura  _DatiApparecchiatura  = new TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura(Context.User.Identity.Name);
          DataSet _MyDs=_DatiApparecchiatura.GetMacroComponenti();
			cmbsMacro.DataSource =Classi.GestoreDropDownList.ItemBlankDataSource(
				_MyDs.Tables[0], "macrocomponente", "macrocomponente", "- Selezionare il Macrocomponente -", "");
          cmbsMacro.DataTextField  ="macrocomponente";
          cmbsMacro.DataValueField="macrocomponente";
		  cmbsMacro.DataBind(); 
		}
		/// <summary>
		/// Popola la combo degli standar delle apparecchiature
		/// </summary>
	
		private void BindApparecchiatura()
		{
			
			this.cmbsApparecchiatura.Items.Clear();
		
			TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura  _DatiApparecchiatura  = new TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura(Context.User.Identity.Name);
			
			DataSet _MyDs;

				S_ControlsCollection _SColl = new S_ControlsCollection();

				S_Controls.Collections.S_Object s_BlId = new S_Object();
				s_BlId.ParameterName = "p_Bl_Id";
				s_BlId.DbType = CustomDBType.Integer ;
				s_BlId.Direction = ParameterDirection.Input;
				s_BlId.Index = 0;
				s_BlId.Value = int.Parse(this.BL_ID);
				_SColl.Add(s_BlId);
			
				S_Controls.Collections.S_Object s_Servizio = new S_Object();
				s_Servizio.ParameterName = "p_Servizio";
				s_Servizio.DbType = CustomDBType.Integer;
				s_Servizio.Direction = ParameterDirection.Input;
				s_Servizio.Index = 1;
			    int servId=0;
                if (Hidden_idservizio.Value!="")
                    servId=int.Parse(Hidden_idservizio.Value);
				s_Servizio.Value = servId;
				_SColl.Add(s_Servizio);

				_MyDs = _DatiApparecchiatura.GetStdApparechiature(_SColl).Copy();
                 
 
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsApparecchiatura.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "COD", "ID", "- Selezionare uno Standard -", "");
				this.cmbsApparecchiatura.DataTextField = "COD";
				this.cmbsApparecchiatura.DataValueField = "ID";
				this.cmbsApparecchiatura.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Standard -";
				this.cmbsApparecchiatura.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}


		private void BindUnitaMisura()
		{
		  	
			this.cmbsUnita.Items.Clear();
		
			//TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura  _DatiApparecchiatura = new TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura(Context.User.Identity.Name);
			TheSite.Classi.ClassiAnagrafiche.UnitaMisura _UnitaMisura = new TheSite.Classi.ClassiAnagrafiche.UnitaMisura();

			DataSet	_MyDs = _UnitaMisura.GetUnita();

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsUnita.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "ucodice", "idunita", "- Selezionare Unità di Misura -", "0");
				this.cmbsUnita.DataTextField = "ucodice";
				this.cmbsUnita.DataValueField = "idunita";
				this.cmbsUnita.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Unità di Misura -";
				this.cmbsUnita.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}
		private void BindUM()
		{
		  	
			this.cmbsUDM.Items.Clear();
		
			//TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura  _DatiApparecchiatura = new TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura(Context.User.Identity.Name);
			TheSite.Classi.ClassiAnagrafiche.UnitaMisura _UnitaMisura = new TheSite.Classi.ClassiAnagrafiche.UnitaMisura();

			DataSet	_MyDs = _UnitaMisura.GetUnita();

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsUDM.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "ucodice", "idunita", "- Selezionare Unità di Misura -", "0");
				this.cmbsUDM.DataTextField = "ucodice";
				this.cmbsUDM.DataValueField = "idunita";
				this.cmbsUDM.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Unità di Misura -";
				this.cmbsUDM.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}
		/// <summary>
		/// Recupera le condizioni di stato di usura di una apparecchiatura
		/// </summary>
		/// <param name="condition">se viene passato l'argomento maggiore di 0 viene selezionata la combo</param>
		private void BindCondition(int condition)
		{
		  	
			this.cmbsCondizione.Items.Clear();
		
			TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura  _DatiApparecchiatura = new TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura(Context.User.Identity.Name);
			
			DataSet	_MyDs = _DatiApparecchiatura.GetCondizione(condition);

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsCondizione.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare lo Stato -", "");
				this.cmbsCondizione.DataTextField = "DESCRIZIONE";
				this.cmbsCondizione.DataValueField = "ID";
				this.cmbsCondizione.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Stato-";
				this.cmbsCondizione.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		private void BindPiano(int idpiano)
		{
		  	
			this.cmbsPiano.Items.Clear();
		
			TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura  _DatiApparecchiatura = new TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura(Context.User.Identity.Name);
			
			DataSet	_MyDs = _DatiApparecchiatura.GetPiani(idpiano);

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsPiano.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "IDP", "- Selezionare il Piano -", "");
				this.cmbsPiano.DataTextField = "DESCRIZIONE";
				this.cmbsPiano.DataValueField = "IDP";
				this.cmbsPiano.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Piano -";
				this.cmbsPiano.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

		private void BindVenditore(int venditoreid)
		{
		  	
			this.cmbsvenditore.Items.Clear();
		
			TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura  _DatiApparecchiatura = new TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura(Context.User.Identity.Name);
			
			DataSet	_MyDs = _DatiApparecchiatura.GetVenditore(venditoreid);

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsvenditore.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare un Venditore -", "");
				this.cmbsvenditore.DataTextField = "DESCRIZIONE";
				this.cmbsvenditore.DataValueField = "ID";
				this.cmbsvenditore.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Venditore -";
				this.cmbsvenditore.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

//MODIFICHE MARIANNA
		private void BindEnteErogante()
		{
		  	
			TheSite.Classi.ClassiAnagrafiche.Enti _Enti = new TheSite.Classi.ClassiAnagrafiche.Enti();
			this.cmbEnteErogante.Items.Clear();
			DataSet _myDS = _Enti.GetData().Copy();
			if(_myDS.Tables[0].Rows.Count > 0)
			{
				this.cmbEnteErogante.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_myDS.Tables[0],"testo","id", "- Selezionare Ente -", "0");
				this.cmbEnteErogante.DataTextField = "testo";
				this.cmbEnteErogante.DataValueField = "id";
				this.cmbEnteErogante.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Ente Erogante-";
				this.cmbEnteErogante.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		}

//FINE
//		private void BindStanze(int idpiano)
//		{
//		  	
//			this.cmbsstanza.Items.Clear();
//		
//			TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura  _DatiApparecchiatura = new TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura(Context.User.Identity.Name);
//			
//			DataSet	_MyDs = _DatiApparecchiatura.GetStanze(int.Parse(this.BL_ID),idpiano);
//
//			if (_MyDs.Tables[0].Rows.Count > 0)
//			{
//				this.cmbsstanza.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
//					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare la Stanza -", "");
//				this.cmbsstanza.DataTextField = "DESCRIZIONE";
//				this.cmbsstanza.DataValueField = "ID";
//				this.cmbsstanza.DataBind();
//           	}
//			else
//			{
//				string s_Messagggio = "- Nessuna Stanza -";
//				this.cmbsstanza.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
//			}
//		}

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
			this.lkbNuovo.Click += new System.EventHandler(this.lkbNuovo_Click);
			this.S_BtInvia.Click += new System.EventHandler(this.S_BtInvia_Click);
			this.S_btannulla.Click += new System.EventHandler(this.S_btannulla_Click);
			this.BtnNuovo.Click += new System.EventHandler(this.BtnNuovo_Click);
			this.DataGridEsegui.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_ItemCommand);
			this.DataGridEsegui.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_CancelCommand);
			this.DataGridEsegui.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_EditCommand);
			this.DataGridEsegui.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridEsegui_UpdateCommand);
			this.DataGridEsegui.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridEsegui_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void cmbsServizio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		 BindApparecchiatura();
		}

		private void S_btannulla_Click(object sender, System.EventArgs e)
		{
		 Server.Transfer("ListaApparecchiature.aspx");  
		}


		private void S_BtInvia_Click(object sender, System.EventArgs e)
		{
			TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura  _DatiApparecchiatura = new TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura(Context.User.Identity.Name);
			int totapp=0;
			DataSet _Ds; 
			if (this.IDEQ=="") 
			{	string d=cmbsPiano.SelectedValue.Split(Convert.ToChar(" "))[1];
				_Ds= _DatiApparecchiatura.GetCountApparecchiature(int.Parse(this.BL_ID),int.Parse(this.cmbsApparecchiatura.SelectedValue.Split(Convert.ToChar(" "))[0]),cmbsPiano.SelectedValue.Split(Convert.ToChar(" "))[1]);
				if(_Ds.Tables[0].Rows.Count>0)
					if(_Ds.Tables[0].Rows[0][0]!=DBNull.Value)
					totapp= int.Parse( _Ds.Tables[0].Rows[0][0].ToString());
			  
				totapp+=1;
			}
			else
			{
				//marianna
				if( EQ_ID.IndexOf('_') != -1)
					totapp=int.Parse(this.EQ_ID.Substring(this.EQ_ID.LastIndexOf("_")+1) ); 
			}
			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id = new S_Object();
			s_p_id.ParameterName = "p_id";
			s_p_id.DbType = CustomDBType.Integer ;
			s_p_id.Direction = ParameterDirection.Input;
			s_p_id.Index =_SColl.Count;
			s_p_id.Value = (this.IDEQ=="")?0:int.Parse(this.IDEQ);
			_SColl.Add(s_p_id);

			S_Controls.Collections.S_Object s_p_eq_id = new S_Object();
			s_p_eq_id.ParameterName = "p_eq_id";
			s_p_eq_id.DbType = CustomDBType.VarChar ;
			s_p_eq_id.Direction = ParameterDirection.Input;
			s_p_eq_id.Index =_SColl.Count;
			s_p_eq_id.Size =50;
			string codice_edifico="";
			if(Radio1.Checked==true)
			{
				codice_edifico=txtApparechiatura.Text;
			}
			else
			{
				codice_edifico=S_Lblcodedificio.Text.Replace(".","_"); 
				codice_edifico+= "_" + cmbsPiano.SelectedValue.Split(Convert.ToChar(" "))[1];
				codice_edifico+= "_" + cmbsApparecchiatura.SelectedValue.Split(Convert.ToChar(" "))[1];
				codice_edifico+="_" + totapp.ToString().PadLeft(2,Convert.ToChar("0"));   
			}
			s_p_eq_id.Value = codice_edifico;
			_SColl.Add(s_p_eq_id);

			S_Controls.Collections.S_Object s_p_bl_id = new S_Object();
			s_p_bl_id.ParameterName = "p_bl_id";
			s_p_bl_id.DbType = CustomDBType.VarChar ;
			s_p_bl_id.Direction = ParameterDirection.Input;
			s_p_bl_id.Index =_SColl.Count;
			s_p_bl_id.Size =8;
			s_p_bl_id.Value = this.S_Lblcodedificio.Text;
			_SColl.Add(s_p_bl_id);
			
			S_Controls.Collections.S_Object s_p_qta = new S_Object();
			s_p_qta.ParameterName = "p_qta";
			s_p_qta.DbType = CustomDBType.VarChar ;
			s_p_qta.Direction = ParameterDirection.Input;
			s_p_qta.Index =_SColl.Count;
			s_p_qta.Size =32;
			s_p_qta.Value = (S_Txtqta.Text=="")?1:Convert.ToInt32(S_Txtqta.Text);
			_SColl.Add(s_p_qta);


			S_Controls.Collections.S_Object s_p_condition = new S_Object();
			s_p_condition.ParameterName = "p_condition";
			s_p_condition.DbType = CustomDBType.VarChar ;
			s_p_condition.Direction = ParameterDirection.Input;
			s_p_condition.Index =_SColl.Count ;
			s_p_condition.Size =12;
			s_p_condition.Value = (cmbsCondizione.SelectedIndex==0)?"":this.cmbsCondizione.Items[cmbsCondizione.SelectedIndex].Text;
			_SColl.Add(s_p_condition);

			S_Controls.Collections.S_Object s_p_eqstd = new S_Object();
			s_p_eqstd.ParameterName = "p_eqstd";
			s_p_eqstd.DbType = CustomDBType.VarChar ;
			s_p_eqstd.Direction = ParameterDirection.Input;
			s_p_eqstd.Index =_SColl.Count ;
			s_p_eqstd.Size =16;
			s_p_eqstd.Value = cmbsApparecchiatura.SelectedValue.Split(Convert.ToChar(" "))[1];
			_SColl.Add(s_p_eqstd);

			S_Controls.Collections.S_Object s_p_fl_id = new S_Object();
			s_p_fl_id.ParameterName = "p_fl_id";
			s_p_fl_id.DbType = CustomDBType.VarChar ;
			s_p_fl_id.Direction = ParameterDirection.Input;
			s_p_fl_id.Index =_SColl.Count;
			s_p_fl_id.Size =4;
			s_p_fl_id.Value = cmbsPiano.SelectedValue.Split(Convert.ToChar(" "))[1];
			_SColl.Add(s_p_fl_id);

			S_Controls.Collections.S_Object s_p_Rm_id = new S_Object();
			s_p_Rm_id.ParameterName = "p_rm_id";
			s_p_Rm_id.DbType = CustomDBType.Integer ;
			s_p_Rm_id.Direction = ParameterDirection.Input;
			s_p_Rm_id.Index =_SColl.Count;
			s_p_Rm_id.Size =4;
			if (UserStanze1.IdStanza=="")
			{
			s_p_Rm_id.Value =System.DBNull.Value;
			}		
			else
			{
			s_p_Rm_id.Value = int.Parse(UserStanze1.IdStanza);
			}
			_SColl.Add(s_p_Rm_id);

			S_Controls.Collections.S_Object s_p_image_eq_assy = new S_Object();
			s_p_image_eq_assy.ParameterName = "p_image_eq_assy";
			s_p_image_eq_assy.DbType = CustomDBType.VarChar;
			s_p_image_eq_assy.Direction = ParameterDirection.Input;
			s_p_image_eq_assy.Index =_SColl.Count;
			s_p_image_eq_assy.Size =64;
			s_p_image_eq_assy.Value = valutafile(codice_edifico);
			_SColl.Add(s_p_image_eq_assy);

			S_Controls.Collections.S_Object s_p_option1 = new S_Object();
			s_p_option1.ParameterName = "p_option1";
			s_p_option1.DbType = CustomDBType.VarChar ;
			s_p_option1.Direction = ParameterDirection.Input;
			s_p_option1.Index =_SColl.Count;
			s_p_option1.Size =32;
			s_p_option1.Value = S_Txtmodello.Text;
			_SColl.Add(s_p_option1);

			S_Controls.Collections.S_Object s_p_option2 = new S_Object();
			s_p_option2.ParameterName = "p_option2";
			s_p_option2.DbType = CustomDBType.VarChar ;
			s_p_option2.Direction = ParameterDirection.Input;
			s_p_option2.Index =_SColl.Count;
			s_p_option2.Size =50;
			s_p_option2.Value = S_Txttipo.Text;
			_SColl.Add(s_p_option2);


			S_Controls.Collections.S_Object s_p_vn_id = new S_Object();
			s_p_vn_id.ParameterName = "p_vn_id";
			s_p_vn_id.DbType = CustomDBType.VarChar ;
			s_p_vn_id.Direction = ParameterDirection.Input;
			s_p_vn_id.Index =_SColl.Count;
			s_p_vn_id.Size =30;
			s_p_vn_id.Value = (cmbsvenditore.SelectedIndex==0)?"":cmbsvenditore.Items[cmbsvenditore.SelectedIndex].Text;
			_SColl.Add(s_p_vn_id);

			S_Controls.Collections.S_Object s_p_eqstd_id = new S_Object();
			s_p_eqstd_id.ParameterName = "p_eqstd_id";
			s_p_eqstd_id.DbType = CustomDBType.Integer;
			s_p_eqstd_id.Direction = ParameterDirection.Input;
			s_p_eqstd_id.Index =_SColl.Count;
			s_p_eqstd_id.Value =int.Parse(cmbsApparecchiatura.SelectedValue.Split(Convert.ToChar(" "))[0]);
			_SColl.Add(s_p_eqstd_id);


			S_Controls.Collections.S_Object s_p_id_bl = new S_Object();
			s_p_id_bl.ParameterName = "p_id_bl";
			s_p_id_bl.DbType = CustomDBType.Integer;
			s_p_id_bl.Direction = ParameterDirection.Input;
			s_p_id_bl.Index =_SColl.Count;
			s_p_id_bl.Value =int.Parse(this.BL_ID);
			_SColl.Add(s_p_id_bl);

			S_Controls.Collections.S_Object s_p_id_fl = new S_Object();
			s_p_id_fl.ParameterName = "p_id_fl";
			s_p_id_fl.DbType = CustomDBType.Integer;
			s_p_id_fl.Direction = ParameterDirection.Input;
			s_p_id_fl.Index =_SColl.Count;
			s_p_id_fl.Value =int.Parse(cmbsPiano.SelectedValue.Split(Convert.ToChar(" "))[0]);
			_SColl.Add(s_p_id_fl);

			S_Controls.Collections.S_Object s_p_id_condition = new S_Object();
			s_p_id_condition.ParameterName = "p_id_condition";
			s_p_id_condition.DbType = CustomDBType.VarChar;
			s_p_id_condition.Direction = ParameterDirection.Input;
			s_p_id_condition.Size=200; 
			s_p_id_condition.Index =_SColl.Count;
			s_p_id_condition.Value =(this.cmbsCondizione.SelectedValue=="")?"":this.cmbsCondizione.SelectedValue;
			_SColl.Add(s_p_id_condition);


			S_Controls.Collections.S_Object s_p_id_vn = new S_Object();
			s_p_id_vn.ParameterName = "p_id_vn";
			s_p_id_vn.DbType = CustomDBType.Integer;
			s_p_id_vn.Direction = ParameterDirection.Input;
			s_p_id_vn.Index =_SColl.Count;
			s_p_id_vn.Value =(this.cmbsvenditore.SelectedValue=="")?0:int.Parse(this.cmbsvenditore.SelectedValue);
			_SColl.Add(s_p_id_vn);

             //Max contatore delle immagini 
			S_Controls.Collections.S_Object s_p_max = new S_Object();
			s_p_max.ParameterName = "p_max";
			s_p_max.DbType = CustomDBType.Integer;
			s_p_max.Direction = ParameterDirection.Input;
			s_p_max.Index =_SColl.Count;
			s_p_max.Value =totapp;
			_SColl.Add(s_p_max);

			S_Controls.Collections.S_Object s_p_subcomponent_of = new S_Object();
			s_p_subcomponent_of.ParameterName = "p_subcomponent_of";
			s_p_subcomponent_of.DbType = CustomDBType.VarChar ;
			s_p_subcomponent_of.Direction = ParameterDirection.Input;
			s_p_subcomponent_of.Index =_SColl.Count;
			s_p_subcomponent_of.Size =12;
			s_p_subcomponent_of.Value =(cmbsMacro.SelectedIndex==0)?"":cmbsMacro.SelectedValue;;
			_SColl.Add(s_p_subcomponent_of);
			
			S_Controls.Collections.S_Object s_p_date_start_validate = new S_Object();
			s_p_date_start_validate.ParameterName = "p_date_start_validate";
			s_p_date_start_validate.DbType = CustomDBType.VarChar ;
			s_p_date_start_validate.Direction = ParameterDirection.Input;
			s_p_date_start_validate.Index =_SColl.Count;
			s_p_date_start_validate.Size =15;
			s_p_date_start_validate.Value = CalendarPicker1.Datazione.Text;
			_SColl.Add(s_p_date_start_validate);

			S_Controls.Collections.S_Object s_p_date_end_validate = new S_Object();
			s_p_date_end_validate.ParameterName = "p_date_end_validate";
			s_p_date_end_validate.DbType = CustomDBType.VarChar ;
			s_p_date_end_validate.Direction = ParameterDirection.Input;
			s_p_date_end_validate.Index =_SColl.Count;
			s_p_date_end_validate.Size =15;
			s_p_date_end_validate.Value = CalendarPicker2.Datazione.Text;
			_SColl.Add(s_p_date_end_validate);

			
			S_Controls.Collections.S_Object p_dismesso = new S_Object();
			p_dismesso.ParameterName = "p_dismesso";
			p_dismesso.DbType = CustomDBType.VarChar ;
			p_dismesso.Direction = ParameterDirection.Input;
			p_dismesso.Index =_SColl.Count;
			p_dismesso.Value =(ChekDismesso.Checked==true)?"1":"0";
			_SColl.Add(p_dismesso);

			S_Controls.Collections.S_Object s_p_rif= new S_Object();
			s_p_rif.ParameterName = "p_rif";
			s_p_rif.DbType = CustomDBType.VarChar ;
			s_p_rif.Direction = ParameterDirection.Input;
			s_p_rif.Index =_SColl.Count;
			s_p_rif.Size =16;
			s_p_rif.Value = S_TxtRif.Text;
			_SColl.Add(s_p_rif);
			
			//**********************//
			S_Controls.Collections.S_Object s_p_idunita= new S_Object();
			s_p_idunita.ParameterName = "p_idunita";
			s_p_idunita.DbType = CustomDBType.Integer;
			s_p_idunita.Direction = ParameterDirection.Input;
			s_p_idunita.Index =_SColl.Count;
			s_p_idunita.Size =23;
			s_p_idunita.Value = Convert.ToInt32(cmbsUnita.SelectedValue);
			_SColl.Add(s_p_idunita);
			
			string primo="";
			string secondo="";
			string completo="";
			
			primo = (S_TxtqtaMatInt.Text=="")?"0":(S_TxtqtaMatInt.Text);
			secondo = (S_TxtqtaMatDec.Text=="")?"00":(S_TxtqtaMatDec.Text);
			completo = primo + "," + secondo;

			S_Controls.Collections.S_Object s_p_numerounita= new S_Object();
			s_p_numerounita.ParameterName = "p_numerounita";
			s_p_numerounita.DbType = CustomDBType.Float;
			s_p_numerounita.Direction = ParameterDirection.Input;
			s_p_numerounita.Index =_SColl.Count;
			s_p_numerounita.Size =23;
			s_p_numerounita.Value = Convert.ToDecimal(completo) ;
			_SColl.Add(s_p_numerounita);

			int contatore=0;
			if (Contatore.Checked==true)
				contatore=1;
			S_Controls.Collections.S_Object s_p_contatore= new S_Object();
			s_p_contatore.ParameterName = "p_contatore";
			s_p_contatore.DbType = CustomDBType.Float;
			s_p_contatore.Direction = ParameterDirection.Input;
			s_p_contatore.Index =_SColl.Count;
			s_p_contatore.Size =23;
			s_p_contatore.Value = contatore ;
			_SColl.Add(s_p_contatore);

		
		


//			S_Controls.Collections.S_Object s_p_um_id= new S_Object();
//			s_p_um_id.ParameterName = "p_um_id";
//			s_p_um_id.DbType = CustomDBType.Float;
//			s_p_um_id.Direction = ParameterDirection.Input;
//			s_p_um_id.Index =_SColl.Count;
//			s_p_um_id.Size =23;
//			s_p_um_id.Value =Convert.ToInt32(cmbsUDM.SelectedValue) ;
//			_SColl.Add(s_p_um_id);
//
//			
//			S_Controls.Collections.S_Object s_p_id_ente_erogante= new S_Object();
//			s_p_id_ente_erogante.ParameterName = "p_id_ente_erogante";
//			s_p_id_ente_erogante.DbType = CustomDBType.Integer;
//			s_p_id_ente_erogante.Direction = ParameterDirection.Input;
//			s_p_id_ente_erogante.Index =_SColl.Count;
//			s_p_id_ente_erogante.Size =23;
//			s_p_id_ente_erogante.Value =Convert.ToInt32(cmbEnteErogante.SelectedValue) ;
//			_SColl.Add(s_p_id_ente_erogante);

			//*******************//
			
			try
			{
				int result=0;
				if (this.IDEQ=="")
				{
					result=_DatiApparecchiatura.Add(_SColl); //insert
				}
				else
				{
					result=_DatiApparecchiatura.Update(_SColl,int.Parse(this.IDEQ));//update
				}
				this.IDEQ=result.ToString();
				PostFile(codice_edifico);
				S_BtDatiTecnici.Disabled =false;
				GetData();
//				Server.Transfer("DescrizioneApparecchiatura.aspx?FunId=" +  FunId.ToString() + "&IDEQ=" + IDEQ.ToString() +  "&BL_ID= " + BL_ID.ToString() + "&CODEDI=" + S_Lblcodedificio.Text);

			}
			catch (Exception ex)
			{
			  S_Lblerror.Text=ex.Message;
			}
		}
		private string valutafile(string filename)
		{
			if (Uploader.PostedFile!=null && Uploader.PostedFile.FileName!="") 
			{
				if (Uploader.PostedFile.ContentType=="image/pjpeg" || Uploader.PostedFile.ContentType=="image/bmp" || Uploader.PostedFile.ContentType=="image/gif")
				{
				
					string fileExtension= System.IO.Path.GetExtension(Uploader.PostedFile.FileName);
					return filename + fileExtension;
				}
				else
				{
					return this.ImageName;
				}
			}
			else
			{
			 return this.ImageName;
			}
		}
		
		private void PostFile(string fileName)
		{
			  
			if (Uploader.PostedFile!=null && Uploader.PostedFile.FileName!="") 
			{
				try
				{
					if (Uploader.PostedFile.ContentType=="image/pjpeg" || Uploader.PostedFile.ContentType=="image/bmp" || Uploader.PostedFile.ContentType=="image/gif")
					{
						string destDir =Server.MapPath("../EQImages");
						string fileExtension= System.IO.Path.GetExtension(Uploader.PostedFile.FileName);
						
						string destPath  = System.IO.Path.Combine(destDir, fileName + fileExtension);
						Uploader.PostedFile.SaveAs(destPath);
					}
					else
					{
						S_Lblerror.Text="File selezionato non valido!";
					}
				}
				catch (Exception ex)
				{
				  S_Lblerror.Text=string.Format("Errore nell'invio dell'immagine: {0}",ex.Message); 
				  Console.WriteLine(ex.Message);  
				}
			}
		}
		
		

		private void DataGridEsegui_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.DataGridEsegui.EditItemIndex = -1;
			this.BindGrid();
			this.DataGridEsegui.Columns[1].Visible = true;
			this.DataGridEsegui.Columns[2].Visible = false;
			this.DataGridEsegui.Columns[3].Visible = false;	
		}

		private void DataGridEsegui_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.DataGridEsegui.EditItemIndex = (int) e.Item.ItemIndex;
			this.BindGrid();
			this.DataGridEsegui.Columns[1].Visible = false;
			this.DataGridEsegui.Columns[2].Visible = true;
			this.DataGridEsegui.Columns[3].Visible = false;
		}

		private void DataGridEsegui_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			S_Controls.S_TextBox ddldescrizioneNew; 
			HtmlInputFile Upload;
			HyperLink Hlink;

			Classi.ClassiAnagrafiche.AllegatiEQ  _AllegatiEQ  = new TheSite.Classi.ClassiAnagrafiche.AllegatiEQ ();
			int i_Result=0;
			ddldescrizioneNew = ((S_Controls.S_TextBox) e.Item.FindControl("ddldescrizioneNew")); 
			Upload = ((HtmlInputFile) e.Item.FindControl("Upload"));
   
			switch(((ImageButton)e.CommandSource).CommandName)
			{
				
				case "Insert":
					
					if (ddldescrizioneNew.Text!= string.Empty && Upload.PostedFile!=null && Upload.PostedFile.FileName!="" )
					{
						if (Upload.PostedFile.ContentType=="image/pjpeg" || Upload.PostedFile.ContentType=="image/jpg" ||Upload.PostedFile.ContentType=="application/pdf" )
						{
							System.IO.FileInfo _FileInfo  = new System.IO.FileInfo(Upload.PostedFile.FileName);; 

							try
							{
								string destDir =Server.MapPath("../EQAllegati");
								string fileExtension= System.IO.Path.GetExtension(Upload.PostedFile.FileName);
									
								string destPath  = System.IO.Path.Combine(destDir, _FileInfo.Name);
								Upload.PostedFile.SaveAs(destPath);
							}
							catch (Exception ex)
							{
								S_Lblerror.Text=string.Format("Errore nell'invio del file: {0}",ex.Message); 
								Console.WriteLine(ex.Message);  
							}
						
				
							i_Result = _AllegatiEQ.Add(ControlsAllegati(ddldescrizioneNew.Text, _FileInfo.Name));   
						}
						else
							PanelMess.ShowError("Scelta del formato di file non valido");
						}
					else
						PanelMess.ShowError("Obbligatori descrizione e scelta del file");
					try
					{
						if (i_Result > 0)
						{
							this.DataGridEsegui.EditItemIndex = -1;
							this.BindGrid();
							this.DataGridEsegui.Columns[1].Visible = true;
							this.DataGridEsegui.Columns[2].Visible = false;
							this.DataGridEsegui.Columns[3].Visible = false;
						}
						else
						{
							
							this.DataGridEsegui.Columns[1].Visible = false;
							this.DataGridEsegui.Columns[2].Visible = false;
							this.DataGridEsegui.Columns[3].Visible = true;
						}
					}
					catch (Exception ex) 
					{
						Console.WriteLine(ex.Message);  
						string s_Err = "Errore: Inserimento dell'allegato non riuscita";
						PanelMess.ShowError(s_Err, true);
					}
					break;
				case "Delete":
								
					int id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());
					
					///Verifica se è presente il file nel server!
					Hlink = ((HyperLink) e.Item.FindControl("hlink"));
					string path= System.Configuration.ConfigurationSettings.AppSettings["PathDocAllegatiEQ"];						
					path += "/"+ Hlink.Text;					
					
					if (System.IO.File.Exists(Server.MapPath(path)))
					{
						System.IO.File.Delete(Server.MapPath(path));
						try
						{
							i_Result = _AllegatiEQ.Delete(ControlsAllegati((DBNull.Value).ToString(), (DBNull.Value).ToString()),id);  
			
							if (i_Result==-1)
							{
								this.DataGridEsegui.EditItemIndex = -1;
								this.BindGrid();
								
							}
						}
						catch (Exception ex) 
						{
							Console.WriteLine(ex.Message); 
							string s_Err = "Errore: Cancellazione dell'allegato non riuscito";
							PanelMess.ShowError(s_Err, true);
						}
					}
					else
						PanelMess.ShowMessage("Nessun file presente nel server");

					this.DataGridEsegui.Columns[1].Visible = true;
					this.DataGridEsegui.Columns[2].Visible = false;
					this.DataGridEsegui.Columns[3].Visible = false;
					break;
				
			
				default:
					// Do nothing.
					break;

			}
		}

		private void DataGridEsegui_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
				
			int id = int.Parse(DataGridEsegui.DataKeys[(int)e.Item.ItemIndex].ToString());
	
			S_Controls.S_TextBox ddldescrizione;
			Classi.ClassiAnagrafiche.AllegatiEQ  _AllegatiEQ  = new TheSite.Classi.ClassiAnagrafiche.AllegatiEQ ();
			ddldescrizione = ((S_Controls.S_TextBox) e.Item.FindControl("ddldescrizione")); 
			Upload = ((HtmlInputFile) e.Item.FindControl("Upload"));	
			int i_Result=0;
			
			try
			{
				i_Result = _AllegatiEQ.Update(ControlsAllegati(ddldescrizione.Text,(DBNull.Value).ToString()),id);   
			
				if (i_Result > 0)
				{
					this.DataGridEsegui.EditItemIndex = -1;
					this.BindGrid();
					this.DataGridEsegui.Columns[1].Visible = true;
					this.DataGridEsegui.Columns[2].Visible = false;
					this.DataGridEsegui.Columns[3].Visible = false;
				}
				else
				{
					this.DataGridEsegui.Columns[1].Visible = false;
					this.DataGridEsegui.Columns[2].Visible = true;
					this.DataGridEsegui.Columns[3].Visible = false;
				}
			}
			catch(Exception ex) 
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void DataGridEsegui_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType== ListItemType.Item) || (e.Item.ItemType==ListItemType.AlternatingItem) ||
				(e.Item.ItemType==ListItemType.EditItem))
			{
				DataRowView Dr =(DataRowView)e.Item.DataItem;
			
				ImageButton bt=(ImageButton)e.Item.Controls[1].Controls[3];
				bt.CausesValidation =false;
				bt.Attributes.Add("onclick","return confirm(\"Eliminare il documento: " + Dr["descrizione"].ToString() + " dell'apparecchiatura : " + Dr["DescrizioneApparecchiatura"].ToString() + "?\")");
           	}
		}
		private S_Controls.Collections.S_ControlsCollection ControlsAllegati(string Descrizione, string nomefile)
		{
			int i_MaxParametri = 0;
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			i_MaxParametri = 0;

			//Descrizione dell'allegato
			S_Controls.Collections.S_Object s_Descrizione = new S_Object();
			s_Descrizione.ParameterName = "p_descrizione";
			s_Descrizione.DbType = CustomDBType.VarChar;
			s_Descrizione.Direction = ParameterDirection.Input;
			s_Descrizione.Size = 50; 
			s_Descrizione.Index = i_MaxParametri;
			s_Descrizione.Value = Descrizione;		
			_SCollection.Add(s_Descrizione); 
			i_MaxParametri ++;

			//Nome del file allegato
			S_Controls.Collections.S_Object s_NomeFile = new S_Object();
			s_NomeFile.ParameterName = "p_nomefile";
			s_NomeFile.DbType = CustomDBType.VarChar;
			s_NomeFile.Direction = ParameterDirection.Input;
			s_NomeFile.Size = 50; 
			s_NomeFile.Index = i_MaxParametri;
			s_NomeFile.Value = nomefile;		
			_SCollection.Add(s_NomeFile); 
			i_MaxParametri ++;

			//id dell'apparecchiatura
			S_Controls.Collections.S_Object s_Apparecchiatura = new S_Object();
			s_Apparecchiatura.ParameterName = "p_eq";
			s_Apparecchiatura.DbType = CustomDBType.Integer;
			s_Apparecchiatura.Direction = ParameterDirection.Input;
			s_Apparecchiatura.Size = 10; 
			s_Apparecchiatura.Index = i_MaxParametri;
			s_Apparecchiatura.Value = int.Parse(IDEQ);		
			_SCollection.Add(s_Apparecchiatura);
			i_MaxParametri ++;
            
			return _SCollection;
		}

		private void BindGrid()
		{
			
			Classi.ClassiAnagrafiche.AllegatiEQ _AllegatiEQ = new TheSite.Classi.ClassiAnagrafiche.AllegatiEQ ();
			DataSet _MyDs;
			S_Controls.Collections.S_ControlsCollection _SCollection = new S_Controls.Collections.S_ControlsCollection();

			S_Controls.Collections.S_Object s_Apparecchiatura = new S_Object();
			s_Apparecchiatura.ParameterName = "p_eq";
			s_Apparecchiatura.DbType = CustomDBType.Integer;
			s_Apparecchiatura.Direction = ParameterDirection.Input;
			s_Apparecchiatura.Size = 10; 
			s_Apparecchiatura.Index = 0;
			s_Apparecchiatura.Value = int.Parse(IDEQ);		
			_SCollection.Add(s_Apparecchiatura);
		
			_MyDs= _AllegatiEQ.GetData(_SCollection).Copy();

			this.DataGridEsegui.DataSource = _MyDs.Tables[0];
			this.DataGridEsegui.DataBind();

			this.lblRecord.Text = _MyDs.Tables[0].Rows.Count.ToString();	
			this.DataGridEsegui.ShowFooter = false;
		}

		private void lkbNuovo_Click(object sender, System.EventArgs e)
		{
			this.DataGridEsegui.ShowFooter = true;
			this.DataGridEsegui.Columns[1].Visible = false;
			this.DataGridEsegui.Columns[2].Visible = false;
			this.DataGridEsegui.Columns[3].Visible = true;
		}

		
		private void BtnNuovo_Click(object sender, System.EventArgs e)
		{
			cmbsApparecchiatura.SelectedValue="";
			cmbsCondizione.SelectedValue="";
			cmbsPiano.SelectedValue="";
			cmbsMacro.SelectedValue="- Selezionare il Macrocomponente -";
			cmbsUnita.SelectedValue="0";
			ChekDismesso.Checked=false;
			cmbsvenditore.SelectedValue="";
			S_Txtmodello.Text="";
			S_Txtqta.Text="";
			S_TxtqtaMatDec.Text="00";
			S_TxtqtaMatInt.Text="0";
			S_TxtRif.Text="";
			S_Txttipo.Text="";;
			
			IDEQ="";
			Context.Items.Add("CODEDI",S_Lblcodedificio.Text);
			Context.Items.Add("IDBL",BL_ID);
			Context.Items.Add("IDEQ",IDEQ);
			Context.Items.Add("SDESCRIZIONE",lblServizioDescription.Text);
			Context.Items.Add("SID",Hidden_idservizio.Value);
			string Dism="";
			Context.Items.Add("DISMESSO", Dism);			
			string url="DescrizioneApparecchiatura.aspx?FunId=" + FunId;
			Server.Transfer(url);
		}

				
	}
}
