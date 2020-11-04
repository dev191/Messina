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
using ApplicationDataLayer.DBType;
using MyCollection;

namespace TheSite.ManutenzioneProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per Completamento_MP_WRList.
	/// </summary>
	public class Completamento_MP_WRList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected S_Controls.S_Button btnsCompletaOdl;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label LblODL;
		protected System.Web.UI.WebControls.Label LblLocalita;
		protected System.Web.UI.WebControls.Label LblCodEdificio;
		protected System.Web.UI.WebControls.Label LblIndirizzo;
		protected System.Web.UI.WebControls.Label LblDataEmissione;
		protected System.Web.UI.WebControls.Label LblDataPianificata;
		protected System.Web.UI.WebControls.Label LblAddetto;
		protected Csy.WebControls.DataPanel DatapanelCompleta;

		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;
		protected WebControls.UserOption Option1;

		public static string HelpLink = string.Empty;
		protected System.Web.UI.WebControls.Button BtnChiudi;
		protected WebControls.CalendarPicker CalendarPicker1;
		public static int FunId = 0;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenreload;
		protected System.Web.UI.WebControls.Button hidRef;			
		
		CompletamentoMP _fp;
	
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
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
		
			this.btnsCompletaOdl.Visible = _SiteModule.IsEditable;															
			
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;
			this.GridTitle1.hplsNuovo.Visible = false;
			
			String scriptString = "<script language=JavaScript>var dettaglio;\n";
			scriptString += "function chiudi() {\n";			
			scriptString += "if (dettaglio!=null)";
			scriptString += "if (document.Form1.hidRicerca.value=='0'){";
			scriptString += " dettaglio.close();}";
			scriptString += " else{";
			scriptString += "document.Form1.hidRicerca.value='1';}}<";
			scriptString += "/";
			scriptString += "script>";


			if(!this.IsClientScriptBlockRegistered("clientScript"))
				this.RegisterClientScriptBlock("clientScript", scriptString);

			System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
			sbValid.Append("if (typeof(ControllaData) == 'function') { ");
			sbValid.Append("if (ControllaData() == false) { return false; }} ");
			sbValid.Append(this.Page.GetPostBackEventReference(this.btnsCompletaOdl));
			sbValid.Append(";");
			this.btnsCompletaOdl.Attributes.Add("onclick", sbValid.ToString());

			if (!Page.IsPostBack)
			{				
				Session.Remove("DatiListMP");

				if(Context.Handler is TheSite.ManutenzioneProgrammata.CompletamentoMP) 
				{
					_fp = (TheSite.ManutenzioneProgrammata.CompletamentoMP)Context.Handler;
					this.ViewState.Add("mioContenitore",_fp._Contenitore); 
				}	
				if(Context.Handler is TheSite.ManutenzioneProgrammata.SfogliaRdlOdl_MP) 
				{
					SfogliaRdlOdl_MP _fp2 = (TheSite.ManutenzioneProgrammata.SfogliaRdlOdl_MP)Context.Handler;
					this.ViewState.Add("mioContenitore",_fp2._Contenitore); 
					this.ViewState.Add("paginardl","paginardl");
					
				}

				ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
				if(Request.QueryString["wo_id"]!=null)
					this.wo_id=Request.QueryString["wo_id"];
				if(Context.Items["wo_id"]!=null)
					this.wo_id=(string)Context.Items["wo_id"];

				Ricerca(Int32.Parse(this.wo_id));
				
			}
			else
			{
				if(hiddenreload.Value=="1")
				{
				  Ricerca(Int32.Parse(this.wo_id));
				}
			}

		}
		private string wo_id
		{
			get
			{
			 if(ViewState["wo_id"]!=null)
				 return (string)ViewState["wo_id"];
			 else
				 return string.Empty;
			}
			set
			{
			 ViewState.Add("wo_id",value);
			}
		}

		#region FunzioniPrivate
		private void Ricerca(int wo_id)
		{				
			//-- Valorizzo i Dati della WO
			hiddenreload.Value="";
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();
						
			// WO_ID
			S_Controls.Collections.S_Object s_WO_ID = new S_Object();

			s_WO_ID.ParameterName = "p_WO_ID";
			s_WO_ID.DbType = CustomDBType.Integer;
			s_WO_ID.Direction = ParameterDirection.Input;
			s_WO_ID.Index = 0;
			s_WO_ID.Size=4;			
			s_WO_ID.Value=wo_id;			
			CollezioneControlli.Add(s_WO_ID);						

			Classi.ManProgrammata.Completamento _Compl = new TheSite.Classi.ManProgrammata.Completamento();
						

			DataSet _MyDs = _Compl.GetDatiWO(CollezioneControlli).Copy();			
			DataRow _Dr = _MyDs.Tables[0].Rows[0]; 
			// Wo_ID
			LblODL.Text=_Dr["wo_id"].ToString();				
			// Localita
			if(_Dr["Localita"].ToString().Trim()!="()")
				LblLocalita.Text=_Dr["Localita"].ToString();				
			// Edificio
			LblCodEdificio.Text=_Dr["Edificio"].ToString();				
			// Indirizzo
			LblIndirizzo.Text=_Dr["Indirizzo"].ToString();				
			// Data Emissione ODL
			if(_Dr["DataEmissione"].ToString()!="")
				LblDataEmissione.Text=DateTime.Parse(_Dr["DataEmissione"].ToString()).ToLongDateString();				
			// DataPianificata			
			string _CampoData = _Dr["DataPianificata"].ToString();
			if (_CampoData.Length > 0) 
			{					
				DateTime _Data = Convert.ToDateTime(_CampoData);
				string mese =  Classi.Function.ImpostaMese(_Data.Month,false);
				string anno = _Data.Year.ToString();
				LblDataPianificata.Text= mese + " - " + anno;				
				LblDataPianificata.ToolTip=_CampoData;	
			}			
			// Addetto
			LblAddetto.Text=_Dr["Addetto"].ToString();			
			
			
			//-- Visualizzo i Dati delle WR legate alla WO		

			DataSet _MyDsWR = _Compl.GetDatiWR(CollezioneControlli).Copy();			
									
			this.DataGridRicerca.DataSource = _MyDsWR.Tables[0];
			this.DataGridRicerca.DataBind();			
			this.GridTitle1.NumeroRecords = _MyDsWR.Tables[0].Rows.Count.ToString();
			
			if (_MyDsWR.Tables[0].Rows.Count>0)
			{
				DatapanelCompleta.Visible=true;
				DataGridRicerca.Visible=true;
			}
			else
			{
				DatapanelCompleta.Visible=false;
				DataGridRicerca.Visible=false;
			}
		}
		#endregion

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
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.btnsCompletaOdl.Click += new System.EventHandler(this.btnsCompletaOdl_Click);
			this.BtnChiudi.Click += new System.EventHandler(this.BtnChiudi_Click);
			this.hidRef.Click += new System.EventHandler(this.hidRef_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				string funz=String.Empty;
				int Stato = Int16.Parse(e.Item.Cells[10].Text);
				WebControls.UserOption Opt;
				switch((Classi.StateType)Stato)
				{
					
					case Classi.StateType.AttivitaCompletata:																										
						//Imposto l'Option
						Opt =  (WebControls.UserOption) e.Item.Cells[9].FindControl("UserOption1");																					
						Opt.OptChiusaSospesa.Items[0].Selected=true;
						Opt.OptChiusaSospesa.Enabled=false;						
						//Imposta la casella di Testo
						Opt.TxtMotivoSospensione.Enabled=false;
						if(e.Item.Cells[8].Text!="&nbsp;")
							Opt.TxtMotivoSospensione.Text=e.Item.Cells[8].Text;						
						//Imposto la checkbox
						System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) e.Item.Cells[2].FindControl("ChkSel");																					
						cb.Checked=true;						
						cb.Enabled=false;
						break;
					case Classi.StateType.EmessaInLavorazione:																	
						//Imposto l'Option
						Opt =  (WebControls.UserOption) e.Item.Cells[9].FindControl("UserOption1");																					
						Opt.OptChiusaSospesa.Items[0].Selected=true;						
						//Imposto il richiamo alla funzione CLIENT						
						funz = "Disabilita('" + Opt.OptChiusaSospesa.ClientID +  "','" + Opt.TxtMotivoSospensione.ClientID + "')";						
						Opt.OptChiusaSospesa.Attributes.Add("onclick",funz);																								
						//Imposta la casella di Testo						
						Opt.TxtMotivoSospensione.Enabled=false;
						if(e.Item.Cells[8].Text!="&nbsp;")
							Opt.TxtMotivoSospensione.Text=e.Item.Cells[8].Text;						
						break;
					case Classi.StateType.RichiestaSospesa:											
						//Imposto l'Option
						Opt =  (WebControls.UserOption) e.Item.Cells[9].FindControl("UserOption1");																					
						Opt.OptChiusaSospesa.Items[1].Selected=true;						
						//Imposto il richiamo alla funzione CLIENT						
						funz = "Disabilita('" + Opt.OptChiusaSospesa.ClientID +  "','" + Opt.TxtMotivoSospensione.ClientID + "')";						
						Opt.OptChiusaSospesa.Attributes.Add("onclick",funz);
						Opt.TxtMotivoSospensione.Enabled=true;	
						System.Web.UI.WebControls.CheckBox cb2 = (System.Web.UI.WebControls.CheckBox) e.Item.Cells[2].FindControl("ChkSel");																					
						cb2.Checked=true;												
						//Imposta la casella di Testo						
						if(e.Item.Cells[8].Text!="&nbsp;")
							Opt.TxtMotivoSospensione.Text=e.Item.Cells[8].Text;						
						break;	
				}	
				
			}
		}

		private void BtnChiudi_Click(object sender, System.EventArgs e)
		{
			if (ViewState["paginardl"]==null)
				Server.Transfer("CompletamentoMP.aspx?FunId="+FunId);
			else
			{
				Context.Items.Add("wo_id",this.wo_id);   
				Server.Transfer("SfogliaRdlOdl_MP.aspx?FunId="+FunId); 
			}
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
		  //Salvo i dati
		  SaveDati(DataGridRicerca);
		  ///Imposto la Nuova Pagina
		  DataGridRicerca.CurrentPageIndex=e.NewPageIndex;
		  Ricerca(Int32.Parse(this.wo_id));
          //Recupero i dati
          GetDati(DataGridRicerca); 
		}

		private void btnsCompletaOdl_Click(object sender, System.EventArgs e)
		{
			//,width='800',height='600'
			//window.returnValue =
			string feature="menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no',align='center'";
			String scriptString = "<script language=JavaScript>";
			scriptString += "window.returnValue =window.showModalDialog(\"Completa_WO.aspx?wo=" + LblODL.Text + "&data=" + CalendarPicker1.Datazione.Text + "\", \"dial\",\"" + feature + "\")\n";
		    scriptString +="document.getElementById('hiddenreload').value='1';\n";
			scriptString +="__doPostBack('','');\n";
			
			scriptString += "<";
			scriptString += "/";
			scriptString += "script>";
        
		

			//Salvo i dati
			SaveDati(DataGridRicerca);
			Hashtable _HS=null;
			if(Session["DatiListMP"]!=null)
				_HS=(Hashtable) Session["DatiListMP"];				
			else
				_HS = new Hashtable();

			if (_HS.Count==0)
				Classi.SiteJavaScript.msgBox(this.Page,"Nessuna RDL Selezionata.");
			else
				Classi.SiteJavaScript.WindowOpen(this.Page,0,"Completa_WO.aspx?wo=" + LblODL.Text + "&data=" + CalendarPicker1.Datazione.Text ,800,600,"dettaglio");

				//if(!this.IsStartupScriptRegistered("Startupmodal"))
				//	this.RegisterStartupScript("Startupmodal", scriptString);
				//Classi.SiteJavaScript.WindowOpen(this.Page,0,"Completa_WO.aspx?wo=" + LblODL.Text + "&data=" + CalendarPicker1.Datazione.Text ,800,600,"dettaglio");
 
			
		}

		private void SaveDati(DataGrid Ctrl)
		{			
			
			Hashtable _HS=null;
			
			if(Session["DatiListMP"]!=null)
				_HS=(Hashtable) Session["DatiListMP"];				
		    else
				_HS = new Hashtable();

						
			foreach(DataGridItem o_Litem in Ctrl.Items)
			{
				
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[2].Controls[1];																					
	            System.Web.UI.WebControls.HyperLink link=( System.Web.UI.WebControls.HyperLink)	o_Litem.Cells[3].Controls[0];

				if(_HS.ContainsKey(link.Text))
					_HS.Remove(link.Text);												
												
				if(cb.Checked && cb.Enabled==true)
				{
					WRList _campi = new WRList();
					WebControls.UserOption Opt =  (WebControls.UserOption) o_Litem.Cells[9].FindControl("UserOption1");

					_campi.id=link.Text;
					_campi.stato =Opt.OptChiusaSospesa.Items[0].Selected;
                    _campi.descrizione =Opt.TxtMotivoSospensione.Text;  
					_HS.Add(_campi.id,_campi);		
				}
				
		
			}	//end for
		
			Session.Remove("DatiListMP");
            Session.Add( "DatiListMP",_HS);
		}

		private void GetDati(DataGrid Ctrl)
		{			
			
			Hashtable _HS=null;
			
			if(Session["DatiListMP"]!=null)
				_HS=(Hashtable) Session["DatiListMP"];				
			else
				return;
		
			foreach(DataGridItem o_Litem in Ctrl.Items)
			{
				
				System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox) o_Litem.Cells[2].Controls[1];																					
				System.Web.UI.WebControls.HyperLink link=( System.Web.UI.WebControls.HyperLink)	o_Litem.Cells[3].Controls[0];
				
					if(_HS.ContainsKey(link.Text))
					{
						cb.Checked=true; 
						WRList _campi = (WRList)_HS[link.Text];
						WebControls.UserOption Opt =  (WebControls.UserOption) o_Litem.Cells[9].FindControl("UserOption1");
						if(_campi.stato==false)
						{
							Opt.OptChiusaSospesa.Items[0].Selected=false;
							Opt.OptChiusaSospesa.Items[1].Selected=true;
							Opt.TxtMotivoSospensione.Enabled=true;
						}
						else
						{
							Opt.OptChiusaSospesa.Items[0].Selected=true;
							Opt.OptChiusaSospesa.Items[1].Selected=false;
						}

						Opt.TxtMotivoSospensione.Text=_campi.descrizione;  
					}
	
				
			}	//end for
		
		}

		private void hidRef_Click(object sender, System.EventArgs e)
		{
			Ricerca(Convert.ToInt32(this.wo_id));
		}

		
	}

	public class WRList
	{
	 public string id=null;
	 public bool stato=false;
     public string descrizione=null;
	}
}
