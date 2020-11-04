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
using S_Controls.Collections;
using System.IO;
using System.Globalization;


namespace TheSite.ManutenzioneCorretiva
{
	/// <summary>
	/// Descrizione di riepilogo per VisualizzaRdl1.
	/// </summary>
	public class VisualizzaRdl1 : System.Web.UI.Page
	{
		protected WebControls.PageTitle PageTitle1;

		int FunId = 0;
		protected System.Web.UI.WebControls.Label lblOperatore;
		protected System.Web.UI.WebControls.Label lblData;
		protected System.Web.UI.WebControls.Label lblOra;
		protected System.Web.UI.WebControls.Label lblRichiedente;
		protected System.Web.UI.WebControls.Label lblGruppo;
		protected System.Web.UI.WebControls.Label lblTelefono;
		protected System.Web.UI.WebControls.Label lblNota;
		protected System.Web.UI.WebControls.Label lblCodiceEdificio;
		protected System.Web.UI.WebControls.Label lblIndirizzo;
		protected System.Web.UI.WebControls.Label lblComune;
		protected System.Web.UI.WebControls.Label lblDenominazione;
		protected System.Web.UI.WebControls.Label lblDitta;
		protected System.Web.UI.WebControls.Label lblServizio;
		protected System.Web.UI.WebControls.Label lblUrgenza;
		protected System.Web.UI.WebControls.Label lblDescrizione;
		protected System.Web.UI.WebControls.Label lblEqStd;
		protected System.Web.UI.WebControls.Label lblEqId;
		protected S_Controls.S_Button btnsNuova;
		protected S_Controls.S_Button cmdApprova;
		protected System.Web.UI.WebControls.TextBox txtWrHidden;
		protected System.Web.UI.WebControls.Label lblteleric;
		protected System.Web.UI.WebControls.Label lblemailric;
		protected System.Web.UI.WebControls.Label lblstanzaric;
		protected System.Web.UI.WebControls.Label lblpianoed;
		protected System.Web.UI.WebControls.Label lblstanzaed;
		protected System.Web.UI.WebControls.Label lblTelefonoDitta;
		protected S_Controls.S_Button btnModificaRDL;
		protected System.Web.UI.WebControls.Label LblEffetto;
		protected System.Web.UI.WebControls.Label LblAnomalia;
		protected System.Web.UI.WebControls.Label LblIdASeguito;
		protected System.Web.UI.WebControls.Label lblAseguito1;
		protected System.Web.UI.WebControls.Label lblAseguito2;
		protected System.Web.UI.WebControls.Label lblAseguito3;
		protected System.Web.UI.WebControls.Label lblAseguito4;
		
		protected System.Web.UI.WebControls.CheckBox ChkConduzione;
		protected System.Web.UI.WebControls.Label TxtOraAseguito;
		protected System.Web.UI.WebControls.Panel Conduzione;
		protected System.Web.UI.WebControls.Label CmbASeguito;
		protected System.Web.UI.WebControls.Label TxtASeguito1;
		protected System.Web.UI.WebControls.CheckBox ChkSopralluogo;
		protected System.Web.UI.WebControls.Label TxtSopralluogo;
		protected System.Web.UI.WebControls.Panel Sopralluogo;
		protected System.Web.UI.WebControls.Label TxtASeguito4;
		protected System.Web.UI.WebControls.Label CPConduzioneData;
		protected System.Web.UI.WebControls.Label CPAseguito;
		protected System.Web.UI.WebControls.Label CPSopralluogoDie;
		protected System.Web.UI.WebControls.Label CPSopralluogoData;
		protected System.Web.UI.WebControls.Button BtSalvaSGA;
		int itemId = 0;
		Classi.ManCorrettiva.ClManCorrettiva _ClManCorrettiva;
		string HSga;
		protected System.Web.UI.WebControls.Label LblSga;
		protected System.Web.UI.WebControls.Label LblInvioSga;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidprog;
		protected System.Web.UI.WebControls.Label lblTipoIntervento;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HidTipInter;
		int id_bl=0;
		private void Page_Load(object sender, System.EventArgs e)
		{
			//Istanzio la classe 
			_ClManCorrettiva=new TheSite.Classi.ManCorrettiva.ClManCorrettiva(Context.User.Identity.Name);
			
			FunId = Int32.Parse(Request.Params["FunId"]);
			
			if (Request.QueryString["chiamante"]=="Materiali")
			{
				btnModificaRDL.Visible=false;
				btnsNuova.Visible=false;
				cmdApprova.Visible=false;
				PageTitle1.VisibleLogut=false;
			}
			if (Request.Params["ItemId"] != null)
			{
				itemId = Int32.Parse(Request.Params["ItemId"]);
				PageTitle1.Title = "Richiesta di Lavoro N° " + itemId ;
				txtWrHidden.Text= itemId.ToString();
						
				if (Context.User.IsInRole("callcenter")|| Context.User.IsInRole("TecnicoPapardo") )
				{
					BtSalvaSGA.Visible=false;
					cmdApprova.Visible=false;
					
				}
		


				Classi.ManOrdinaria.Richiesta _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();					

				DataSet _MyDs = _Richiesta.GetSingleData(itemId).Copy();
				if (_MyDs.Tables[0].Rows.Count == 1)
				{
					DataRow _Dr = _MyDs.Tables[0].Rows[0];
					DateTime d_DateRequested = (DateTime) _Dr["DATE_REQUESTED"];
					this.lblData.Text = d_DateRequested.ToShortDateString();
					DateTime d_TimeRequested = (DateTime) _Dr["TIME_REQUESTED"];
					this.lblOra.Text = d_TimeRequested.ToShortTimeString();
					this.lblCodiceEdificio.Text = _Dr["BL_ID"].ToString();
					
					if (_Dr["sga"] != DBNull.Value)
						this.LblSga.Text =_Dr["sga"].ToString();
					//recupero data di invio sga
					DataSet DsData = _ClManCorrettiva.GetDataInvioSga(itemId,DocType.SGA);
				
					if (DsData.Tables[0].Rows.Count == 1)
					{
						DataRow _DrData = DsData.Tables[0].Rows[0];
						LblInvioSga.Text=_DrData["data_invio"].ToString();
					}
					if (_Dr["id_bl"] != DBNull.Value)
						this.id_bl =Convert.ToInt32(_Dr["id_bl"].ToString());
					
					if (_Dr["id_progetto"] != DBNull.Value)
						this.hidprog.Value =_Dr["id_progetto"].ToString();
					
					if (_Dr["DENOMINAZIONE"] != DBNull.Value)
						this.lblDenominazione.Text = _Dr["DENOMINAZIONE"].ToString();
					if (_Dr["PIANO"] != DBNull.Value)
						this.lblpianoed.Text =  _Dr["PIANO"].ToString();
					if (_Dr["STANZA"] != DBNull.Value)
						this.lblstanzaed.Text = _Dr["STANZA"].ToString();
					
					if (_Dr["INDIRIZZO"] != DBNull.Value)
						this.lblIndirizzo.Text = _Dr["INDIRIZZO"].ToString();
					if (_Dr["COMUNE"] != DBNull.Value)
						this.lblComune.Text = _Dr["COMUNE"].ToString();
					if (_Dr["descrizione_ditta"] != DBNull.Value)
						this.lblDitta.Text =  _Dr["descrizione_ditta"].ToString();
					if (_Dr["TELEFONO_DITTA"] != DBNull.Value)
						this.lblTelefonoDitta.Text =  _Dr["TELEFONO_DITTA"].ToString();

					if (_Dr["USERNAME"] != DBNull.Value)
						this.lblOperatore.Text = _Dr["USERNAME"].ToString();
					if (_Dr["REQUESTOR"] != DBNull.Value)
						this.lblRichiedente.Text =  _Dr["REQUESTOR"].ToString();
				
					if (_Dr["telefonoric"] != DBNull.Value)
						this.lblteleric.Text = _Dr["telefonoric"].ToString();
					if (_Dr["emailric"] != DBNull.Value)
						this.lblemailric.Text = _Dr["emailric"].ToString();
					if (_Dr["stanzaric"] != DBNull.Value)
						this.lblstanzaric.Text = _Dr["stanzaric"].ToString();
					
					if (_Dr["PHONE"] != DBNull.Value)
						this.lblTelefono.Text =  _Dr["PHONE"].ToString();
					if (_Dr["DESCRIZIONERICHIEDENTI"] != DBNull.Value)
						this.lblGruppo.Text = _Dr["DESCRIZIONERICHIEDENTI"].ToString();
				
					string s_Nota = string.Empty;
					if (_Dr["NOTA_RIC"] != DBNull.Value)
						s_Nota = _Dr["NOTA_RIC"].ToString();

					this.lblNota.Text = s_Nota.Replace("\n", "<br>");
					
					string s_Descrizione = string.Empty;
					if (_Dr["DESCRIPTION"] != DBNull.Value)
						s_Descrizione =  _Dr["DESCRIPTION"].ToString();

					this.lblDescrizione.Text = s_Descrizione.Replace("\n", "<br>");
					
					if (_Dr["PRIORITY"] != DBNull.Value)
						this.lblUrgenza.Text =  _Dr["PRIORITY"].ToString();
					if (_Dr["DESCRIZIONESERVIZI"] != DBNull.Value)
						this.lblServizio.Text = _Dr["DESCRIZIONESERVIZI"].ToString();	
				
					string s_Eqstd = string.Empty;
					if (_Dr["EQ_STD"] != DBNull.Value)
						s_Eqstd =  _Dr["EQ_STD"].ToString();
					if (_Dr["DESCRIZIONEEQSTD"] != DBNull.Value)
						s_Eqstd += " " + _Dr["DESCRIZIONEEQSTD"].ToString();
					this.lblEqStd.Text = s_Eqstd;
					
					if (_Dr["EQ_ID"] != DBNull.Value)
						this.lblEqId.Text = _Dr["EQ_ID"].ToString();

					//aggiunta SGA
					if (_Dr["sga_anomalia"] != DBNull.Value)
						this.LblAnomalia.Text = _Dr["sga_anomalia"].ToString();

					if (_Dr["sga_effetto"] != DBNull.Value)
						this.LblEffetto.Text = _Dr["sga_effetto"].ToString();

					if (_Dr["conduzione"] != DBNull.Value)
						ChkConduzione.Checked=(_Dr["conduzione"].ToString()=="1")?true:false;

					if (_Dr["data_conduzione"] != DBNull.Value)
						CPConduzioneData.Text=_Dr["data_conduzione"].ToString();

					if (_Dr["ora_conduzione"] != DBNull.Value)
					{
						TxtOraAseguito.Text=_Dr["ora_conduzione"].ToString();
					}

					if (_Dr["sga_seguito"] != DBNull.Value)
					{
						CmbASeguito.Text=_Dr["sga_seguito"].ToString();
					}
					if (_Dr["DescTipoIntervento"] != DBNull.Value)
					{
						lblTipoIntervento.Text=_Dr["tipomanut"].ToString();
					}
					HidTipInter.Value=_Dr["tipointervento_id"].ToString();
					if (_Dr["tipointervento_id"].ToString() =="83")
					{
							BtSalvaSGA.Text="Salva/Invia DIE";
					}


					if (_Dr["die_numero"] != DBNull.Value)
						TxtASeguito1.Text=_Dr["die_numero"].ToString();

					if (_Dr["die_del"] != DBNull.Value)
						CPAseguito.Text=_Dr["die_del"].ToString();

					if (_Dr["sopralluogo"] != DBNull.Value)
						ChkSopralluogo.Checked=(_Dr["sopralluogo"].ToString()=="1")?true:false;

					if (_Dr["sopralluogo_n"] != DBNull.Value)
						TxtSopralluogo.Text=_Dr["sopralluogo_n"].ToString();

					if (_Dr["sopralluogo_del"] != DBNull.Value)
						CPSopralluogoDie.Text=_Dr["sopralluogo_del"].ToString();

					if (_Dr["sopralluogo_data"] != DBNull.Value)
						CPSopralluogoData.Text=_Dr["sopralluogo_data"].ToString();

					if (_Dr["sopralluogo_da"] != DBNull.Value)
						TxtASeguito4.Text=_Dr["sopralluogo_da"].ToString();
//
//					if (_Dr["sga_aseguito1"] != DBNull.Value && _Dr["id_sga_seguito"]!= DBNull.Value)
//					{
//						switch(_Dr["id_sga_seguito"].ToString())
//						{
//							case "1":
//								this.lblAseguito1.Text ="IN DATA: " +  _Dr["sga_aseguito1"].ToString();
//								lblAseguito3.Visible=false;
//								lblAseguito4.Visible=false;
//							break;
//							case "4":
//								this.lblAseguito1.Text ="DIE N°: " +  _Dr["sga_aseguito1"].ToString();
//								lblAseguito3.Visible=false;
//								lblAseguito4.Visible=false;
//							break;
//							case "5":
//								this.lblAseguito1.Text ="N°: " +  _Dr["sga_aseguito1"].ToString();
//								lblAseguito3.Visible=true;
//								lblAseguito4.Visible=true;
//							break;
//						}			
//					}		
//
//					if (_Dr["sga_aseguito2"] != DBNull.Value && _Dr["id_sga_seguito"]!= DBNull.Value)
//					{
//						switch(_Dr["id_sga_seguito"].ToString())
//						{
//							case "1":
//								this.lblAseguito2.Text ="ORA: " +  _Dr["sga_aseguito2"].ToString();
//								break;
//							case "4": case "5":
//								this.lblAseguito2.Text ="DEL°: " +  _Dr["sga_aseguito2"].ToString();
//								break;
//								default:
//								break;
//						}			
//					}		
//
//					if (_Dr["sga_aseguito3"] != DBNull.Value)
//						this.lblAseguito3.Text = "Sopralluogo effettuato in data   "+_Dr["sga_aseguito3"].ToString();
//
//					
//					if (_Dr["sga_aseguito4"] != DBNull.Value)
//						this.lblAseguito4.Text = "DA  "+_Dr["sga_aseguito4"].ToString();

				}					
			}
			else
				PageTitle1.Title = "Inserimento Richiesta di Lavoro - Impossibile visualizzare la Richiesta";
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
			this.btnsNuova.Click += new System.EventHandler(this.btnsNuova_Click);
			this.cmdApprova.Click += new System.EventHandler(this.cmdApprova_Click);
			this.btnModificaRDL.Click += new System.EventHandler(this.btnModificaRDL_Click);
			this.BtSalvaSGA.Click += new System.EventHandler(this.BtSalvaSGA_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsNuova_Click(object sender, System.EventArgs e)
		{
			string VarApp="";
			if (Request["VarApp"]!=null)
			{
				VarApp="&VarApp=" + Request["VarApp"];
			}
			Response.Redirect("CreazioneSGA1.aspx?FunId=" + FunId + VarApp);
		}

		private void cmdApprova_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("CompletaRdl.aspx?wr_id=" + txtWrHidden.Text);	
		}

		private void btnModificaRDL_Click(object sender, System.EventArgs e)
		{
			string VarApp="";
			if (Request["VarApp"]!=null)
			{
				VarApp="&VarApp=" + Request["VarApp"];
			}
			Response.Redirect("CreazioneSGA1.aspx?ItemId=" + txtWrHidden.Text + VarApp);			
		}

		private void BtSalvaSGA_Click(object sender, System.EventArgs e)
		{
			//CreaCodSGA();
			
			if (HidTipInter.Value=="83")
				inviaDie();
			else
				inviaSGA();
		}
		
	
		private void CreaCodSGA()
		{
			int num=0;
			num = _ClManCorrettiva.CreaNumeroSGA(Convert.ToInt32(txtWrHidden.Text));
			HSga=lblCodiceEdificio.Text+"_"+num+"_"+System.DateTime.Parse(lblData.Text).ToString("yy");
			LblSga.Text=HSga.ToString();
		
		}

		private void inviaSGA()
		{
			HSga=LblSga.Text;
			string formatdate=DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString() +DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() +DateTime.Now.Year.ToString();	
			string fileName="";
			if (hidprog.Value=="2") // vodafone
				fileName = @"\XSLT\XSLsgaRptVod04.xslt";
			else
				fileName = @"\XSLT\XSLsgaRpt04.xslt";
			string PathSgaXlst = Server.MapPath(Request.ApplicationPath + fileName);
			TheSite.Classi.RptRtf.SGARTF trs = new TheSite.Classi.RptRtf.SGARTF();
			trs.FileXlst = PathSgaXlst;
			int wr_id = Convert.ToInt32(this.txtWrHidden.Text);
			string[] Files=trs.GeneraRtf(wr_id,formatdate);
			TheSite.Classi.MailSend mail=new TheSite.Classi.MailSend();
			SaveInvio(Files[1],DocType.SGA);
			mail.SendMail(Files[0],wr_id,DocType.SGA);
			//recupero data di invio sga
			DataSet DsData = _ClManCorrettiva.GetDataInvioSga(itemId,DocType.SGA);
				
			if (DsData.Tables[0].Rows.Count == 1)
			{
				DataRow _DrData = DsData.Tables[0].Rows[0];
				LblInvioSga.Text=_DrData["data_invio"].ToString();
			}
			//
		}
		private void inviaDie()
		{
			HSga=LblSga.Text;
			int wr_id = Convert.ToInt32(this.txtWrHidden.Text);
			string formatdate=DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString() +DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() +DateTime.Now.Year.ToString();	
			TheSite.XSLT.DIE die =new TheSite.XSLT.DIE(wr_id,formatdate);
			string[] Files=die.GenerateDIE();

			TheSite.Classi.MailSend mail=new TheSite.Classi.MailSend();
			mail.SendMail(Files[0],wr_id,DocType.DIE);

			SaveInvio(Files[1],DocType.DIE);
			
		}
		private void SaveInvio(string FileName,DocType TipoDoc)
		{
			S_ControlsCollection _SColl =new S_ControlsCollection();
	

			S_Object p = new S_Object();
			p.ParameterName = "p_id";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Value =0;
			_SColl.Add(p);

			p = new S_Object();
			p.ParameterName = "p_NOME_DOC";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Size=255;
			p.Value =Path.GetFileName(FileName);
			_SColl.Add(p);

			p = new S_Object();
			p.ParameterName = "p_DATA_INVIO";
			p.DbType = CustomDBType.Date;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Size=15;
			p.Value =DateTime.Now;
			_SColl.Add(p);
                                        
			p = new S_Object();
			p.ParameterName = "p_USERS";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Size=255;
			p.Value =Context.User.Identity.Name;
			_SColl.Add(p);

			p = new S_Object();
			p.ParameterName = "p_TIPO_DOC";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Size=32;
			p.Value =TipoDoc.ToString();
			_SColl.Add(p);

			p = new S_Object();
			p.ParameterName = "p_CODICE";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Size=255;
			p.Value =this.HSga.ToString();
			_SColl.Add(p);
 
			p = new S_Object();
			p.ParameterName = "p_ID_WR";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Value =this.txtWrHidden.Text;
			_SColl.Add(p);

			p = new S_Object();
			p.ParameterName = "p_ID_BL";
			p.DbType = CustomDBType.Integer;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Value =this.id_bl;
			_SColl.Add(p);
            
			p = new S_Object();
			p.ParameterName = "p_CODICE_BL";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Size=255;
			p.Value =lblCodiceEdificio.Text;
			_SColl.Add(p);

			p = new S_Object();
			p.ParameterName = "p_Operazione";
			p.DbType = CustomDBType.VarChar;
			p.Direction = ParameterDirection.Input;
			p.Index = _SColl.Count;
			p.Size=255;
			p.Value ="Insert";
			_SColl.Add(p);

			int result= _ClManCorrettiva.ExecuteTracciaDoc(_SColl); 
		}
	}
}
