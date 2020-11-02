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
using System.IO;
using StampaRapportiPdf.Classi;

namespace TheSite.Gestione
{
	/// <summary>
	/// Descrizione di riepilogo per DescrizioneDoc_Dwf.
	/// </summary>
	public class DescrizioneDoc_Dwf : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected S_Controls.S_Label S_Lblcodedificio;
		protected S_Controls.S_ComboBox cmbsCategoriaGenerale;
		protected S_Controls.S_ComboBox cmbsCategoria;
		protected System.Web.UI.HtmlControls.HtmlTable TableVVf;
		protected S_Controls.S_TextBox txtNFascicoloVVF;
		protected S_Controls.S_CheckBox checkCollaudoVVF;
		protected S_Controls.S_ComboBox cmbsTipoFile;
		protected S_Controls.S_ComboBox cmbsTipologiaDocumento;
		protected S_Controls.S_TextBox txtISPESL;
		protected S_Controls.S_ComboBox S_CbAnno;
		protected System.Web.UI.HtmlControls.HtmlTable TableISPESL;
		protected S_Controls.S_Button btNuovo;
		protected S_Controls.S_Button btSalva;
		protected S_Controls.S_Button btBack;
		protected S_Controls.S_Label S_LblCodiceDoc;
		protected WebControls.CalendarPicker CalendarPicker1VVF;
        protected WebControls.CalendarPicker CalendarPicker2VVF;
		protected WebControls.CalendarPicker CalendarPicker3VVF;

		protected S_Controls.S_Label S_Lblerror;
		protected System.Web.UI.HtmlControls.HtmlInputFile Uploader;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected WebControls.CalendarPicker CalendarPicker4ISPESL;
		protected WebControls.CalendarPicker CalendarPicker5ISPESL;
		protected WebControls.CalendarPicker CalendarPicker6ISPESL;
		protected S_Controls.S_Label S_LblFileName;
		protected S_Controls.S_Label lblFirstAndLast;
		protected S_Controls.S_CheckBox CheckRinomina;
		protected S_Controls.S_TextBox txtNumeroPagina;
		protected WebControls.PageTitle PageTitle1; 
		private int Dimension=0;
		public static int FunId = 0;
		protected S_Controls.S_TextBox txtsdescrizione;
		protected S_Controls.S_ComboBox  cmbsServizio;
		protected S_Controls.S_ComboBox cmbsPiano;
		protected S_Controls.S_TextBox s_txtDescPrimaVer;
		protected S_Controls.S_TextBox s_txtDescSuccVer;
		protected S_Controls.S_TextBox s_txtDescScadenza;
		public static string HelpLink = string.Empty;

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
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];		
						
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;

			txtNumeroPagina.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
			txtNumeroPagina.Attributes.Add("onpaste","return nonpaste();");
            CheckRinomina.Attributes.Add("onclick","abilita(this);");  
            
			//Disabilito le combo prima del postback
			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsCategoria.ClientID + "').disabled = true;");
			sbValid.Append("document.getElementById('" + this.cmbsTipologiaDocumento.ClientID + "').disabled = true;");
			this.cmbsCategoriaGenerale.Attributes.Add("onchange", sbValid.ToString());

			sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsCategoria.ClientID + "').disabled = true;");
			sbValid.Append("document.getElementById('" + this.cmbsCategoriaGenerale.ClientID + "').disabled = true;");
			this.cmbsTipologiaDocumento.Attributes.Add("onchange", sbValid.ToString());

			sbValid = new System.Text.StringBuilder();
			sbValid.Append("document.getElementById('" + this.cmbsCategoriaGenerale.ClientID + "').disabled = true;");
			sbValid.Append("document.getElementById('" + this.cmbsTipologiaDocumento.ClientID + "').disabled = true;");
			this.cmbsCategoria.Attributes.Add("onchange", sbValid.ToString());

			if(!IsPostBack)
			{
				txtNumeroPagina.Attributes.Add("disabled","");
				#region Recupero la proprieta di ricerca
				// Recupero il tipo dall'oggetto context.
				Type myType=Context.Handler.GetType();       
				// recupero il PropertyInfo object passando il nome della proprietà da recuperare.
				PropertyInfo myPropInfo = myType.GetProperty("_Contenitore");
				// verifico che questa proprietà esista.
				if(myPropInfo!=null)
					this.ViewState.Add("mioContenitore",myPropInfo.GetValue(Context.Handler,null));
				#endregion
                btNuovo.Enabled =false;
				btNuovo.CommandArgument="";
 
				TableVVf.Visible =false;
                TableISPESL.Visible =false;

				if (Context.Items["CODEDI"]!=null)
					this.S_Lblcodedificio.Text=(string)Context.Items["CODEDI"];
				//Ritorna l'ID del BL 
				if (Context.Items["IDBL"]!=null)
					this.BL_ID=(string)Context.Items["IDBL"];
				    
				//	ritorna iD del Documento in caso di modifica
				if (Context.Items["IDDOC"]!=null)
					this.IDDOC=(string)Context.Items["IDDOC"]; 
			    
				if (Context.Items["FILE"]!=null)
					this.S_LblCodiceDoc.Text=(string)Context.Items["FILE"]; 
			  BindPiano(this.BL_ID);
			  BindServizio(this.BL_ID);
              BindTipoDocumento();
			  BindCategorieGenerali();
			  BindingComboAnno();
              if(this.IDDOC!="")
				  GetData();
			}
		}

		#region Proprietà
		private string BL_ID
		{
			get
			{
					if(ViewState["BL_ID"]!=null)
				 return (string)ViewState["BL_ID"];
			 else
				 return string.Empty;
			}
			set
			{
				ViewState.Add("BL_ID",value);
			}
		}
		private string IDDOC
		{
			get
			{
				if(ViewState["IDDOC"]!=null)
					return (string)ViewState["IDDOC"];
				else
					return string.Empty;
			}
			set
			{
				ViewState.Add("IDDOC",value);
			}
		}
		private string MAX
		{
			get
			{
				if(ViewState["MAX"]!=null)
					return (string)ViewState["MAX"];
				else
					return string.Empty;
			}
			set
			{
				ViewState.Add("MAX",value);
			}
		}
		#endregion

		private void GetData()
		{
			TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF  _AnagrafeDocDWF = new TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF(Context.User.Identity.Name);

			if (int.Parse(this.IDDOC)==0) return;

			DataSet	_Ds = _AnagrafeDocDWF.GetSingleData(int.Parse(this.BL_ID),int.Parse(this.IDDOC));
			if (_Ds.Tables[0].Rows.Count>0)
			{
				DataRow Dr=_Ds.Tables[0].Rows[0];
				if(Dr["anno_scadenza"]!=DBNull.Value) 
					S_CbAnno.SelectedValue =Dr["anno_scadenza"].ToString();
				
				if(Dr["pianoid"]!=DBNull.Value) 
					//cmbsPiano.SelectedValue =Dr["pianodesc"].ToString();
				{
					//cmbsPiano.SelectedItem.Text =Dr["pianodesc"].ToString();
					cmbsPiano.SelectedValue =Dr["pianoid"].ToString();
				}
//				else
//				{
//					cmbsPiano.SelectedValue = "-1";
//				}

				if(Dr["idservizio"]!=DBNull.Value) 
					cmbsServizio.SelectedValue =Dr["idservizio"].ToString();
			
				if(Dr["documento_id"]!=DBNull.Value) 
					cmbsTipoFile.SelectedValue =Dr["documento_id"].ToString();

				if(Dr["descrizionegenerale"]!=DBNull.Value)
				{
					cmbsCategoriaGenerale.SelectedValue =Dr["descrizionegenerale"].ToString();
                    BindCategorie(int.Parse(cmbsCategoriaGenerale.SelectedValue));
				}
				if(Dr["categoria"]!=DBNull.Value) 
				{
					cmbsCategoria.SelectedValue =Dr["categoria"].ToString();
					int cat=int.Parse(this.cmbsCategoria.SelectedValue.Split(Convert.ToChar(","))[0]);  
					BindTipologiaDoc(cat);
					//modifica
					SetVisibleTable(cmbsCategoria.SelectedValue);
				}
				if(Dr["tipologia"]!=DBNull.Value) 
				{
					cmbsTipologiaDocumento.SelectedValue =Dr["tipologia"].ToString();
					//modifica
					//SetVisibleTable(cmbsTipologiaDocumento.SelectedValue);

					int tip=int.Parse(this.cmbsTipologiaDocumento.SelectedValue.Split(Convert.ToChar(","))[0]);  
					//BindDescrizione(tip);
				}
				if(Dr["descrizione1"]!=DBNull.Value) 
					txtsdescrizione.Text =Dr["descrizione1"].ToString();

				if(Dr["n_fascicolo_vvf"]!=DBNull.Value) 
					txtNFascicoloVVF.Text  =Dr["n_fascicolo_vvf"].ToString();

				if(Dr["data_rilascio_cpi"]!=DBNull.Value) 
					CalendarPicker1VVF.Datazione.Text =System.DateTime.Parse(Dr["data_rilascio_cpi"].ToString()).ToShortDateString();
				
				if(Dr["data_scadenza_cpi"]!=DBNull.Value) 
                    CalendarPicker2VVF.Datazione.Text =System.DateTime.Parse(Dr["data_scadenza_cpi"].ToString()).ToShortDateString();
 
				if(Dr["data_parere_favorevole"]!=DBNull.Value) 
					CalendarPicker3VVF.Datazione.Text =System.DateTime.Parse(Dr["data_parere_favorevole"].ToString()).ToShortDateString(); 

				if(Dr["collaudo"]!=DBNull.Value) 
					checkCollaudoVVF.Checked =(Dr["collaudo"].ToString()=="0")?false:true;

				if(Dr["matricola_ispesl"]!=DBNull.Value) 
					txtISPESL.Text  =Dr["matricola_ispesl"].ToString();
				
				if(Dr["data_prima_verifica"]!=DBNull.Value) 
				    CalendarPicker4ISPESL.Datazione.Text =System.DateTime.Parse(Dr["data_prima_verifica"].ToString()).ToShortDateString(); 
				
				if(Dr["NOMEDWF"]!=DBNull.Value) 
				  this.S_LblFileName.Text=Dr["NOMEDWF"].ToString();

				if(Dr["CODICEDWF"]!=DBNull.Value) 
					this.S_LblCodiceDoc.Text=Dr["CODICEDWF"].ToString();
				
				if(Dr["pagine_documento"]!=DBNull.Value) 
					this.MAX=Dr["pagine_documento"].ToString();
				
				if(Dr["DESCRIZIONE_PRIMA_VERIFICA"]!=DBNull.Value)
					s_txtDescPrimaVer.Text=Dr["DESCRIZIONE_PRIMA_VERIFICA"].ToString();

				if(Dr["DATA_SUCCESSIVA_VERIFICA"]!=DBNull.Value)
					CalendarPicker5ISPESL.Datazione.Text=System.DateTime.Parse(Dr["DATA_SUCCESSIVA_VERIFICA"].ToString()).ToShortDateString(); 

				if(Dr["DESCRIZIONE_SUCC_VERIFICA"]!=DBNull.Value)
					s_txtDescSuccVer.Text=Dr["DESCRIZIONE_SUCC_VERIFICA"].ToString();

				if(Dr["DATA_SCADENZA"]!=DBNull.Value)
					CalendarPicker6ISPESL.Datazione.Text=System.DateTime.Parse(Dr["DATA_SCADENZA"].ToString()).ToShortDateString(); 

				if(Dr["DESCRIZIONE_DATA_SCADENZA"]!=DBNull.Value)
					s_txtDescScadenza.Text=Dr["DESCRIZIONE_DATA_SCADENZA"].ToString();
                
				lblFirstAndLast.Text = _AnagrafeDocDWF.GetFirstAndLastUser(Dr);
				
				DisableControl(false,Page); 

				//se i nomi sono uguali devo abilitare il check per la rinomina
				if(Dr["NOMEDWF"]!=DBNull.Value  && Dr["CODICEDWF"]!=DBNull.Value)
					if(Dr["NOMEDWF"].ToString()==Dr["CODICEDWF"].ToString())
					   CheckRinomina.Checked =true;

				System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
//				if( this.Validators.Count > 0 )
//				{
				sbValid.Append("if (typeof(Page_ClientValidate) == 'function') { ");
				sbValid.Append("if (Page_ClientValidate() == false) { return false; } ");
//				} 

                sbValid.Append("if (confirm('Sei sicuro di sostituire il file?') == false) { return false; }} ");
				sbValid.Append("this.value = 'Attendere ...';");
				sbValid.Append("this.disabled = true;");
				sbValid.Append("document.getElementById('" + btSalva.ClientID + "').disabled = true;");
				sbValid.Append(this.Page.GetPostBackEventReference(this.btSalva));
				sbValid.Append(";");
				this.btSalva.Attributes.Add("onclick", sbValid.ToString());

				btSalva.Enabled =true;
				btNuovo.Enabled=true;
				btBack.Enabled =true;
				RequiredFieldValidator5.Enabled =true;
				 
			}
		}

		private void BindingComboAnno()
		{
			DateTime d1 = DateTime.Now;
			S_CbAnno.Items.Add(new ListItem("",""));
			for (int i = 1970; i <= (d1.Year +15) ; i++)
				S_CbAnno.Items.Add(new ListItem(i.ToString(),i.ToString()));    
		   
		}
		/// <summary>
		/// Popola i servizzi legati all'edificio
		/// </summary>
		/// <param name="CodEdificio"></param>
		private void BindServizio(string CodEdificio)
		{
			this.cmbsServizio.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura  _DatiApparecchiatura = new TheSite.Classi.AnagrafeImpianti.DatiApparecchiatura(Context.User.Identity.Name);

			DataSet	_MyDs = _DatiApparecchiatura.GetServiziEdifici(int.Parse(this.BL_ID));

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare un Servizio -", "");
				this.cmbsServizio.DataTextField = "DESCRIZIONE";
				this.cmbsServizio.DataValueField = "ID";
				this.cmbsServizio.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Servizio -";
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		
		}

		private void BindPiano(string CodEdificio)
		{
		this.cmbsPiano.Items.Clear();
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			Classi.ClassiAnagrafiche.Buildings _Buildings = new TheSite.Classi.ClassiAnagrafiche.Buildings();

			DataSet	_MyDs = _Buildings.GetPianiBuilding(int.Parse(this.BL_ID));

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsPiano.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare il Piano -", "-1");
				this.cmbsPiano.DataTextField = "DESCRIZIONE";
				this.cmbsPiano.DataValueField = "ID";
				this.cmbsPiano.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Piano -";
				this.cmbsPiano.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
			//this.cmbsPiano.Enabled=true;
		}



		private void BindTipoDocumento()
		{
			this.cmbsTipoFile.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF  _AnagrafeDocDWF = new TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF(Context.User.Identity.Name);

			DataSet	_Ds = _AnagrafeDocDWF.GetTipologiaFile();

			if (_Ds.Tables[0].Rows.Count > 0)
			{
				this.cmbsTipoFile.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_Ds.Tables[0], "DESCRIZIONE", "ID", "- Selezionare la Tipologia del File -", "");
				this.cmbsTipoFile.DataTextField = "DESCRIZIONE";
				this.cmbsTipoFile.DataValueField = "ID";
				this.cmbsTipoFile.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessuna Tipologia del File -";
				this.cmbsTipoFile.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		
		}
		private void BindCategorieGenerali()
		{
			this.cmbsCategoriaGenerale.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF  _AnagrafeDocDWF = new TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF(Context.User.Identity.Name);

			DataSet	_MyDs = _AnagrafeDocDWF.GetCategoriaGenerali();

			if (_MyDs.Tables[0].Rows.Count > 0)
			{

//				this.cmbsCategoriaGenerale.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
//					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare la Categoria Generale -", "");
				this.cmbsCategoriaGenerale.DataSource = _MyDs.Tables[0];
				this.cmbsCategoriaGenerale.DataTextField = "DESCRIZIONE";
				this.cmbsCategoriaGenerale.DataValueField = "ID";
				this.cmbsCategoriaGenerale.DataBind();
                BindCategorie(int.Parse(cmbsCategoriaGenerale.SelectedValue)); 
			}
			else
			{
				string s_Messagggio = "- Nessuna Categoria Generale -";
				this.cmbsCategoriaGenerale.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		
		}

		private void BindCategorie(int idCategoriaGenerale)
		{
			this.cmbsCategoria.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF  _AnagrafeDocDWF = new TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF(Context.User.Identity.Name);

			DataSet	_MyDs = _AnagrafeDocDWF.GetCategoria(idCategoriaGenerale);

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsCategoria.DataSource = _MyDs.Tables[0];
//				this.cmbsCategoria.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
//					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare la Categoria Generale -", "");
				this.cmbsCategoria.DataTextField = "DESCRIZIONE";
				this.cmbsCategoria.DataValueField = "ID";
				this.cmbsCategoria.DataBind();
				int cat=int.Parse(this.cmbsCategoria.SelectedValue.Split(Convert.ToChar(","))[0]);  
                BindTipologiaDoc(cat);
				//modifica
				SetVisibleTable(cmbsCategoria.SelectedValue);
			}
			else
			{
				string s_Messagggio = "- Nessuna Categoria Generale -";
				this.cmbsCategoria.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		
		}

		private void BindTipologiaDoc(int idCategoria)
		{
			this.cmbsTipologiaDocumento.Items.Clear();		
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();

			TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF  _AnagrafeDocDWF = new TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF(Context.User.Identity.Name);

			DataSet	_MyDs = _AnagrafeDocDWF.GetTipologiaDoc(idCategoria);

			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsTipologiaDocumento.DataSource = _MyDs.Tables[0];
//				this.cmbsTipologiaDocumento.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
//					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare la Tipologia del Documento -", "");
				this.cmbsTipologiaDocumento.DataTextField = "DESCRIZIONE";
				this.cmbsTipologiaDocumento.DataValueField = "ID";
				this.cmbsTipologiaDocumento.DataBind();
		
				int tip=int.Parse(this.cmbsTipologiaDocumento.SelectedValue.Split(Convert.ToChar(","))[0]);
				SetVisibleTable(idCategoria.ToString());
				//BindDescrizione(tip);
			}
			else
			{
				string s_Messagggio = "- Nessuna Tipologia del Documento -";
				this.cmbsTipologiaDocumento.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
			}
		
		}
		//modifica
//		private void BindDescrizione(int idTipologiaDoc)
//		{
//			this.cmbsDescrizione.Items.Clear();		
//			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
//
//			TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF  _AnagrafeDocDWF = new TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF(Context.User.Identity.Name);
//
//			DataSet	_MyDs = _AnagrafeDocDWF.GetDescrizione(idTipologiaDoc);
//
//			if (_MyDs.Tables[0].Rows.Count > 0)
//			{
////				this.cmbsTipologiaDocumento.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
////					_MyDs.Tables[0], "DESCRIZIONE", "ID", "- Selezionare la Descrizione -", "");
//				this.cmbsDescrizione.DataSource = _MyDs.Tables[0];
//				this.cmbsDescrizione.DataTextField = "DESCRIZIONE";
//				this.cmbsDescrizione.DataValueField = "ID";
//				this.cmbsDescrizione.DataBind();
//			}
//			else
//			{
//				string s_Messagggio = "- Nessuna Descrizione -";
//				this.cmbsDescrizione.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
//			}
//		
//		}

		private void execute()
		{
			string nomedwf=string.Empty;
			 TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF  _AnagrafeDocDWF = new TheSite.Classi.AnagrafeImpianti.AnagrafeDocDWF(Context.User.Identity.Name);
			//Codifica del File
			//(BL_ID)_(servizio)_(abb_tip)_(abb_ctg)_(numero di pagina) R0_.(estenzione)
			nomedwf+=this.S_Lblcodedificio.Text.Replace(".","_");
            nomedwf+="_" + cmbsServizio.SelectedValue.Split(Convert.ToChar(" "))[1];
            nomedwf+="_" + this.cmbsTipologiaDocumento.SelectedValue.Split(Convert.ToChar(","))[1];
			nomedwf+="_" + this.cmbsCategoria.SelectedValue.Split(Convert.ToChar(","))[1]; 
			nomedwf+="_";
			int maxpage=0;
			string nomefile=string.Empty;
            string exte=string.Empty; 
            string deleteFile=string.Empty;

            if (txtNumeroPagina.Text=="")
				txtNumeroPagina.Text="1";



			//Si tratta di un inserimento
			if (this.S_LblCodiceDoc.Text=="")
			{
				maxpage=int.Parse(txtNumeroPagina.Text);

				nomedwf+=txtNumeroPagina.Text + "_R0";
				exte= System.IO.Path.GetExtension(Uploader.PostedFile.FileName);
                nomedwf+= exte;
				if(CheckRinomina.Checked==true)
				{
					if (this.ExistFile(nomedwf)==true)
					{
						S_Lblerror.Text="Il file è gia presente impossibile inserire. Inserire un numero di pagina diverso."; 
						return;
					} 
				}
				else
				{
					if(this.ExistFile("")==true)
					{
						S_Lblerror.Text="Il file è gia presente impossibile inserire. Rinominare il File."; 
						return;
					}
				}
			}
			else//si tratta di una modifica
			{
				//Se è stata selezionata un'altra immagine recupero l'estenziona
				//altrimenti mantengo la stessa immagine  ma recupero l'estenzione
				if(IsSelectFile()==true)
				{
					exte= System.IO.Path.GetExtension(Uploader.PostedFile.FileName);
					nomedwf+=txtNumeroPagina.Text + "_R0" + exte;
					maxpage=int.Parse(txtNumeroPagina.Text);

					//se il nome del file da postare e diverso da quello già postato verifico
					//che il nome non esista già
					if (CheckRinomina.Checked==false && S_LblFileName.Text!=System.IO.Path.GetFileName(Uploader.PostedFile.FileName))
					{
						if(this.ExistFile("")==true)
						{
							S_Lblerror.Text="Il file è gia presente impossibile inserire. Rinominare il File."; 
							return;
						}
						//imposto a true per l'eliminazione del file in qunato
						deleteFile=S_LblFileName.Text;
					}
					else if(CheckRinomina.Checked==true && System.IO.Path.GetExtension(S_LblFileName.Text)!=nomedwf)
					{
                              deleteFile=S_LblFileName.Text;
					}
				}
				else
				{
					exte=System.IO.Path.GetExtension(this.S_LblCodiceDoc.Text);
					nomedwf+=this.MAX + "_R0" + exte;
					maxpage=int.Parse(this.MAX);
				}
			}

	

			//Posto il file eventuale selezionato
			if(CheckRinomina.Checked==true)
			   nomefile=PostFile(nomedwf);
			else
              nomefile=PostFile("");

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_p_id = new S_Object();
			s_p_id.ParameterName = "p_id_doc_dwf";
			s_p_id.DbType = CustomDBType.Integer ;
			s_p_id.Direction = ParameterDirection.Input;
			s_p_id.Index =0;
			s_p_id.Value = (this.IDDOC=="")?0:int.Parse(this.IDDOC);
			_SColl.Add(s_p_id);


			S_Controls.Collections.S_Object s_p_nomedwf = new S_Object();
			s_p_nomedwf.ParameterName = "p_nomedwf";
			s_p_nomedwf.DbType = CustomDBType.VarChar;
			s_p_nomedwf.Direction = ParameterDirection.Input;
			s_p_nomedwf.Index =1;
			s_p_nomedwf.Size =50;
			s_p_nomedwf.Value = nomefile;
			_SColl.Add(s_p_nomedwf);

			//fascicolo
			S_Controls.Collections.S_Object s_p_nfascicolo = new S_Object();
			s_p_nfascicolo.ParameterName = "p_nfascicolo";
			s_p_nfascicolo.DbType = CustomDBType.VarChar;
			s_p_nfascicolo.Direction = ParameterDirection.Input;
			s_p_nfascicolo.Index =2;
			s_p_nfascicolo.Size =20;
			s_p_nfascicolo.Value = txtNFascicoloVVF.Text;
			_SColl.Add(s_p_nfascicolo);

			//Data rilascio cpi
			S_Controls.Collections.S_Object s_p_datarilascio_cpi = new S_Object();
			s_p_datarilascio_cpi.ParameterName = "p_datarilascio_cpi";
			s_p_datarilascio_cpi.DbType = CustomDBType.VarChar;
			s_p_datarilascio_cpi.Direction = ParameterDirection.Input;
			s_p_datarilascio_cpi.Index =3;
			s_p_datarilascio_cpi.Size =15;
			s_p_datarilascio_cpi.Value = CalendarPicker1VVF.Datazione.Text;
			_SColl.Add(s_p_datarilascio_cpi);

			//Data scadenza cpi
			S_Controls.Collections.S_Object s_p_datascadenza_cpi = new S_Object();
			s_p_datascadenza_cpi.ParameterName = "p_datascadenza_cpi";
			s_p_datascadenza_cpi.DbType = CustomDBType.VarChar;
			s_p_datascadenza_cpi.Direction = ParameterDirection.Input;
			s_p_datascadenza_cpi.Index =4;
			s_p_datascadenza_cpi.Size =15;
			s_p_datascadenza_cpi.Value = CalendarPicker2VVF.Datazione.Text;
			_SColl.Add(s_p_datascadenza_cpi);

			//Data parere cpi
			S_Controls.Collections.S_Object s_p_dataparere_cpi = new S_Object();
			s_p_dataparere_cpi.ParameterName = "p_dataparere_cpi";
			s_p_dataparere_cpi.DbType = CustomDBType.VarChar;
			s_p_dataparere_cpi.Direction = ParameterDirection.Input;
			s_p_dataparere_cpi.Index =5;
			s_p_dataparere_cpi.Size =15;
			s_p_dataparere_cpi.Value = CalendarPicker3VVF.Datazione.Text;
			_SColl.Add(s_p_dataparere_cpi);

			//Collaudo
			S_Controls.Collections.S_Object s_p_collaudo = new S_Object();
			s_p_collaudo.ParameterName = "p_collaudo";
			s_p_collaudo.DbType = CustomDBType.Integer;
			s_p_collaudo.Direction = ParameterDirection.Input;
			s_p_collaudo.Index =6;
			s_p_collaudo.Value =(checkCollaudoVVF.Checked==true)?1:0;
			_SColl.Add(s_p_collaudo);

			//Matricola
			S_Controls.Collections.S_Object s_p_matricola = new S_Object();
			s_p_matricola.ParameterName = "p_matricola";
			s_p_matricola.DbType = CustomDBType.VarChar;
			s_p_matricola.Direction = ParameterDirection.Input;
			s_p_matricola.Index =7;
			s_p_matricola.Size =20;
			s_p_matricola.Value =txtISPESL.Text;  
			_SColl.Add(s_p_matricola);

			//data prima verifica
			S_Controls.Collections.S_Object s_p_dataprimaverifica = new S_Object();
			s_p_dataprimaverifica.ParameterName = "p_dataprimaverifica";
			s_p_dataprimaverifica.DbType = CustomDBType.VarChar;
			s_p_dataprimaverifica.Direction = ParameterDirection.Input;
			s_p_dataprimaverifica.Index =8;
			s_p_dataprimaverifica.Size =15;
			s_p_dataprimaverifica.Value =CalendarPicker4ISPESL.Datazione.Text;  
			_SColl.Add(s_p_dataprimaverifica);

			//anno
			S_Controls.Collections.S_Object s_p_anno = new S_Object();
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.VarChar;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Index =9;
			s_p_anno.Size =4;
			s_p_anno.Value =S_CbAnno.Items[S_CbAnno.SelectedIndex].Value;  
			_SColl.Add(s_p_anno);

            //DDR
			S_Controls.Collections.S_Object s_p_ddr_id = new S_Object();
			s_p_ddr_id.ParameterName = "p_ddr_id";
			s_p_ddr_id.DbType = CustomDBType.Integer;
			s_p_ddr_id.Direction = ParameterDirection.Input;
			s_p_ddr_id.Index =10;
			s_p_ddr_id.Value =cmbsCategoriaGenerale.SelectedValue;  
			_SColl.Add(s_p_ddr_id);

			//descrizione 
			S_Controls.Collections.S_Object s_p_descrizione = new S_Object();
			s_p_descrizione.ParameterName = "p_descrizione";
			s_p_descrizione.DbType = CustomDBType.VarChar;
			s_p_descrizione.Size=255;
			s_p_descrizione.Direction = ParameterDirection.Input;
			s_p_descrizione.Index =11;
			s_p_descrizione.Value =txtsdescrizione.Text;  
			_SColl.Add(s_p_descrizione);

			//tipologia del file 
			S_Controls.Collections.S_Object s_p_documento_id = new S_Object();
			s_p_documento_id.ParameterName = "p_documento_id";
			s_p_documento_id.DbType = CustomDBType.Integer;
			s_p_documento_id.Direction = ParameterDirection.Input;
			s_p_documento_id.Index =12;
			s_p_documento_id.Value =cmbsTipoFile.SelectedValue;  
			_SColl.Add(s_p_documento_id);

			// ID BL
			S_Controls.Collections.S_Object s_p_id_bl = new S_Object();
			s_p_id_bl.ParameterName = "p_id_bl";
			s_p_id_bl.DbType = CustomDBType.Integer;
			s_p_id_bl.Direction = ParameterDirection.Input;
			s_p_id_bl.Index =13;
			s_p_id_bl.Value =int.Parse(this.BL_ID);  
			_SColl.Add(s_p_id_bl);

			// BL CODICE
			S_Controls.Collections.S_Object s_bl_id = new S_Object();
			s_bl_id.ParameterName = "p_bl_id";
			s_bl_id.DbType = CustomDBType.VarChar;
			s_bl_id.Direction = ParameterDirection.Input;
			s_bl_id.Size =8;
			s_bl_id.Index =14;
			s_bl_id.Value =this.S_Lblcodedificio.Text;  
			_SColl.Add(s_bl_id);
			
			//**************** NEW ******************************//
			//ID PIANO
			S_Controls.Collections.S_Object s_p_piano_id = new S_Object();
			s_p_piano_id.ParameterName = "p_piano_id";
			s_p_piano_id.DbType = CustomDBType.Integer;
			s_p_piano_id.Direction = ParameterDirection.Input;
			s_p_piano_id.Index =15;
			s_p_piano_id.Value = Convert.ToInt32(cmbsPiano.SelectedValue.ToString());
			_SColl.Add(s_p_piano_id);
			//************** END NEW *******************************//
			//Servizio 
			S_Controls.Collections.S_Object s_p_servizio_id = new S_Object();
			s_p_servizio_id.ParameterName = "p_servizio_id";
			s_p_servizio_id.DbType = CustomDBType.Integer;
			s_p_servizio_id.Direction = ParameterDirection.Input;
			s_p_servizio_id.Index =16;
			s_p_servizio_id.Value =int.Parse(cmbsServizio.SelectedValue.Split(Convert.ToChar(" "))[0]);  
			_SColl.Add(s_p_servizio_id);

			//id delle tipologie 
			S_Controls.Collections.S_Object s_p_iddocdwf_tipologie = new S_Object();
			s_p_iddocdwf_tipologie.ParameterName = "p_iddocdwf_tipologie";
			s_p_iddocdwf_tipologie.DbType = CustomDBType.Integer;
			s_p_iddocdwf_tipologie.Direction = ParameterDirection.Input;
			s_p_iddocdwf_tipologie.Index =17;
			s_p_iddocdwf_tipologie.Value =int.Parse(cmbsTipologiaDocumento.SelectedValue.Split(Convert.ToChar(","))[0]);  
			_SColl.Add(s_p_iddocdwf_tipologie);

			//id categorie 
			S_Controls.Collections.S_Object s_p_iddocdwf_categorie = new S_Object();
			s_p_iddocdwf_categorie.ParameterName = "p_iddocdwf_categorie";
			s_p_iddocdwf_categorie.DbType = CustomDBType.Integer;
			s_p_iddocdwf_categorie.Direction = ParameterDirection.Input;
			s_p_iddocdwf_categorie.Index =18;
			s_p_iddocdwf_categorie.Value =int.Parse(cmbsCategoria.SelectedValue.Split(Convert.ToChar(","))[0]);  
			_SColl.Add(s_p_iddocdwf_categorie);

			//Max dei file nell'edificio
			S_Controls.Collections.S_Object s_p_paginedocumento = new S_Object();
			s_p_paginedocumento.ParameterName = "p_paginedocumento";
			s_p_paginedocumento.DbType = CustomDBType.Integer;
			s_p_paginedocumento.Direction = ParameterDirection.Input;
			s_p_paginedocumento.Index =19;
			s_p_paginedocumento.Value =maxpage;  
			_SColl.Add(s_p_paginedocumento);

			//Codice del File
			S_Controls.Collections.S_Object s_p_codicedwf = new S_Object();
			s_p_codicedwf.ParameterName = "p_codicedwf";
			s_p_codicedwf.DbType = CustomDBType.VarChar;
			s_p_codicedwf.Direction = ParameterDirection.Input;
			s_p_codicedwf.Index =20;
			s_p_codicedwf.Size =50;
			s_p_codicedwf.Value = nomedwf;
			_SColl.Add(s_p_codicedwf);

			//Dimensioni del File
			S_Controls.Collections.S_Object s_p_dimensionefile = new S_Object();
			s_p_dimensionefile.ParameterName = "p_dimensionefile";
			s_p_dimensionefile.DbType = CustomDBType.Integer;
			s_p_dimensionefile.Direction = ParameterDirection.Input;
			s_p_dimensionefile.Index =21;
			s_p_dimensionefile.Value =this.Dimension;  
			_SColl.Add(s_p_dimensionefile);
			
			//Marianna 22/08/2005 modifiche ISPEL//

			//Descrizione prima verifica
			S_Controls.Collections.S_Object s_p_descrizione_prima_verifica = new S_Object();
			s_p_descrizione_prima_verifica.ParameterName = "p_descrizione_prima_verifica";
			s_p_descrizione_prima_verifica.DbType = CustomDBType.VarChar;
			s_p_descrizione_prima_verifica.Direction = ParameterDirection.Input;
			s_p_descrizione_prima_verifica.Index =21;
			s_p_descrizione_prima_verifica.Size =255;
			s_p_descrizione_prima_verifica.Value = s_txtDescPrimaVer.Text;
			_SColl.Add(s_p_descrizione_prima_verifica);

			//Data successiva verifica
			S_Controls.Collections.S_Object s_p_data_successiva_verifica = new S_Object();
			s_p_data_successiva_verifica.ParameterName = "p_data_successiva_verifica";
			s_p_data_successiva_verifica.DbType = CustomDBType.VarChar;
			s_p_data_successiva_verifica.Direction = ParameterDirection.Input;
			s_p_data_successiva_verifica.Index =22;
			s_p_data_successiva_verifica.Size =50;
			s_p_data_successiva_verifica.Value = CalendarPicker5ISPESL.Datazione.Text;
			_SColl.Add(s_p_data_successiva_verifica);

			//Descrizione successiva verifica
			S_Controls.Collections.S_Object s_p_descrizione_succ_verifica = new S_Object();
			s_p_descrizione_succ_verifica.ParameterName = "p_descrizione_succ_verifica";
			s_p_descrizione_succ_verifica.DbType = CustomDBType.VarChar;
			s_p_descrizione_succ_verifica.Direction = ParameterDirection.Input;
			s_p_descrizione_succ_verifica.Index =23;
			s_p_descrizione_succ_verifica.Size =255;
			s_p_descrizione_succ_verifica.Value = s_txtDescSuccVer.Text;
			_SColl.Add(s_p_descrizione_succ_verifica);

			//Data scadenza
			S_Controls.Collections.S_Object s_p_data_scadenza= new S_Object();
			s_p_data_scadenza.ParameterName = "p_data_scadenza";
			s_p_data_scadenza.DbType = CustomDBType.VarChar;
			s_p_data_scadenza.Direction = ParameterDirection.Input;
			s_p_data_scadenza.Index =24;
			s_p_data_scadenza.Size =50;
			s_p_data_scadenza.Value = CalendarPicker6ISPESL.Datazione.Text;
			_SColl.Add(s_p_data_scadenza);

			//Descrizione Data scadenza
			S_Controls.Collections.S_Object s_p_descrizione_data_scadenza= new S_Object();
			s_p_descrizione_data_scadenza.ParameterName = "p_descrizione_data_scadenza";
			s_p_descrizione_data_scadenza.DbType = CustomDBType.VarChar;
			s_p_descrizione_data_scadenza.Direction = ParameterDirection.Input;
			s_p_descrizione_data_scadenza.Index =26;
			s_p_descrizione_data_scadenza.Size =255;
			s_p_descrizione_data_scadenza.Value = s_txtDescScadenza.Text;
			_SColl.Add(s_p_descrizione_data_scadenza);

			//fine//

			try
			{
				
				int result=0;
				if (this.IDDOC=="")//Inserimento
				{
				result=_AnagrafeDocDWF.Add(_SColl); //insert
				}
				else//Update
				{
				result=_AnagrafeDocDWF.Update(_SColl,int.Parse(this.IDDOC));//update
				}

				this.IDDOC =result.ToString();

				if (deleteFile!=string.Empty)
                    DeleteFile(deleteFile);

				GetData();

			}
			catch (Exception ex)
			{
				S_Lblerror.Text=ex.Message;
			}

		}
		private void DeleteFile(string FileName)
		{
			string destDir =Server.MapPath("../Doc_DB");
			//Creazione del percorso dove il file va inserito
			string folderParent=cmbsCategoria.Items[cmbsCategoria.SelectedIndex].Text.Replace(" ","_").Replace("/","_");
			string folderChild=cmbsTipologiaDocumento.Items[cmbsTipologiaDocumento.SelectedIndex].Text.Replace(" ","_").Replace("/","_");
						
			folderParent=System.IO.Path.Combine(destDir, folderParent);
			folderChild=System.IO.Path.Combine(folderParent, folderChild);
	        string destPath  = System.IO.Path.Combine(folderChild, FileName);
			if (File.Exists(destPath)==true)
                File.Delete(destPath); 

		}
		private string PostFile(string RenameFile)
		{
			  
			if (Uploader.PostedFile!=null && Uploader.PostedFile.FileName!="") 
			{
				try
				{
					string fileName= System.IO.Path.GetFileName(Uploader.PostedFile.FileName);

					string destDir =Server.MapPath("../Doc_DB");
					//Creazione del percorso dove il file va inserito
					string folderParent=cmbsCategoria.Items[cmbsCategoria.SelectedIndex].Text.Replace(" ","_").Replace("/","_");
					string folderChild=cmbsTipologiaDocumento.Items[cmbsTipologiaDocumento.SelectedIndex].Text.Replace(" ","_").Replace("/","_");
						
					folderParent=System.IO.Path.Combine(destDir, folderParent);
					if (!Directory.Exists(folderParent))
						Directory.CreateDirectory(folderParent);

					folderChild=System.IO.Path.Combine(folderParent, folderChild);
					if (!Directory.Exists(folderChild))
						Directory.CreateDirectory(folderChild);	

					string destPath  = System.IO.Path.Combine(folderChild, fileName);
					this.Dimension=Uploader.PostedFile.ContentLength;
					
					if (RenameFile=="")
						destPath  = System.IO.Path.Combine(folderChild, fileName);
					else
					{
						destPath  = System.IO.Path.Combine(folderChild, RenameFile);
						fileName= RenameFile; 
					}
					Uploader.PostedFile.SaveAs(destPath);				
					return fileName;
				}
				catch (Exception ex)
				{
					S_Lblerror.Text=string.Format("Errore nell'invio del File: {0}",ex.Message); 
					Console.WriteLine(ex.Message);
					return "";
				}
			}else 
				return "";

		}
		/// <summary>
		/// Indica che il file che si sta cercando di inviare già esiste.
		/// </summary>
		/// <returns></returns>
		private bool ExistFile(string RenameFileName)
		{
			if (Uploader.PostedFile!=null && Uploader.PostedFile.FileName!="") 
			{
				
					string fileName= System.IO.Path.GetFileName(Uploader.PostedFile.FileName);

					string destDir =Server.MapPath("../Doc_DB");
					//Creazione del percorso dove il file va inserito
					string folderParent=cmbsCategoria.Items[cmbsCategoria.SelectedIndex].Text.Replace(" ","_").Replace("/","_");
					string folderChild=cmbsTipologiaDocumento.Items[cmbsTipologiaDocumento.SelectedIndex].Text.Replace(" ","_").Replace("/","_");
						
					folderParent=System.IO.Path.Combine(destDir, folderParent);
					if (!Directory.Exists(folderParent))
						Directory.CreateDirectory(folderParent);

					folderChild=System.IO.Path.Combine(folderParent, folderChild);
					if (!Directory.Exists(folderChild))
						Directory.CreateDirectory(folderChild);	

					string destPath  =string.Empty; 
				     //
                    if (RenameFileName=="")
					  destPath  = System.IO.Path.Combine(folderChild, fileName);
				    else
                       destPath  = System.IO.Path.Combine(folderChild, RenameFileName);

					return File.Exists(destPath);  
	
			}else
				return false;
		}
		/// <summary>
		/// Indica che è stato selezionato un file
		/// </summary>
		/// <returns></returns>
		private bool IsSelectFile()
		{
		   if (Uploader.PostedFile!=null && Uploader.PostedFile.FileName!="")
			return true;
           else
			return false;
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
			this.cmbsCategoriaGenerale.SelectedIndexChanged += new System.EventHandler(this.cmbsCategoriaGenerale_SelectedIndexChanged);
			this.cmbsCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbsCategoria_SelectedIndexChanged);
			this.cmbsTipologiaDocumento.SelectedIndexChanged += new System.EventHandler(this.cmbsTipologiaDocumento_SelectedIndexChanged);
			this.btNuovo.Click += new System.EventHandler(this.btNuovo_Click);
			this.btSalva.Click += new System.EventHandler(this.btSalva_Click);
			this.btBack.Click += new System.EventHandler(this.btBack_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btSalva_Click(object sender, System.EventArgs e)
		{
		    S_Lblerror.Text="";
			execute();
		}

		private void btNuovo_Click(object sender, System.EventArgs e)
		{
			DisableControl(true,Page); 
			S_Lblerror.Text="";
			this.IDDOC="";
			this.MAX="";
			this.S_LblCodiceDoc.Text="";
			this.S_LblFileName.Text="";
			btSalva.Enabled =true;
			btNuovo.Enabled=false;
			btBack.Enabled =true;
			RequiredFieldValidator5.Enabled =true;
		}

		private void cmbsTipologiaDocumento_SelectedIndexChanged(object sender, System.EventArgs e)
		{	//modifica
			//SetVisibleTable(this.cmbsTipologiaDocumento.SelectedValue);
			int tip=int.Parse(this.cmbsTipologiaDocumento.SelectedValue.Split(Convert.ToChar(","))[0]);  
			//BindDescrizione(tip);
		}

		private void cmbsCategoriaGenerale_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			 BindCategorie(int.Parse(cmbsCategoriaGenerale.SelectedValue)); 
		}

		private void cmbsCategoria_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int cat=int.Parse(this.cmbsCategoria.SelectedValue.Split(Convert.ToChar(","))[0]);  
			BindTipologiaDoc(cat);
		}
		private void SetVisibleTable(string value)
		{
			TableVVf.Visible =false;
			TableISPESL.Visible =false;

			if(value.Split(Convert.ToChar(","))[0] =="8" || value=="8")//VVF
			{
				TableVVf.Visible =true;
				txtISPESL.Text="";
				CalendarPicker4ISPESL.Datazione.Text="";
				S_CbAnno.SelectedIndex =0;

				CalendarPicker1VVF.CreateValidator("Inserire la Data Rilascio CPI",System.Web.UI.WebControls.ValidatorDisplay.None);     
			    CalendarPicker2VVF.CreateValidator("Inserire la Data Scadenza CPI",System.Web.UI.WebControls.ValidatorDisplay.None);
				CalendarPicker3VVF.CreateValidator("Inserire la Data Parere Favorevole",System.Web.UI.WebControls.ValidatorDisplay.None);
			}
			if(value.Split(Convert.ToChar(","))[0] =="6" || value=="6")//ISPELS
			{
				TableISPESL.Visible =true;
				txtNFascicoloVVF.Text="";
				checkCollaudoVVF.Checked =false;
                CalendarPicker1VVF.Datazione.Text="";
				CalendarPicker2VVF.Datazione.Text=""; 
				CalendarPicker3VVF.Datazione.Text="";

				CalendarPicker4ISPESL.CreateValidator("Inserire la Data Prima Verifica",System.Web.UI.WebControls.ValidatorDisplay.None);
			}
		}
		private void btBack_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ListaDoc_Dwf.aspx");  
		}
		
		private void DisableControl(bool disable,Control Contrl)
		{
			foreach(Control Ctrl in Contrl.Controls)
			{
				 if(Ctrl is TextBox)
					 ((TextBox)Ctrl).Enabled= disable;

				if(Ctrl is CheckBox)
					((CheckBox)Ctrl).Enabled= disable;

				if(Ctrl is DropDownList)
					((DropDownList)Ctrl).Enabled= disable;
	
				if(Ctrl is Button)
					((Button)Ctrl).Enabled= disable;

				if (Ctrl.Controls.Count>0) DisableControl(disable,Ctrl);
			}
	
		}
	}
}