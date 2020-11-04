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
using StampaRapportiPdf.Classi;

namespace TheSite.ManutenzioneProgrammata.Schedula
{
	/// <summary>
	/// Descrizione di riepilogo per CopiaPianoEsistente.
	/// </summary>
	public class CopiaPianoEsistente : System.Web.UI.Page    // System.Web.UI.Page
	{
		protected S_Controls.S_ComboBox cmbsServizio;
		protected WebControls.PageTitle PageTitle1;
		protected WebControls.RicercaModulo RicercaModulo1;

		public static int FunId = 0;
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected S_Controls.S_Button btnsRicerca;
		public static string HelpLink = string.Empty;

		clMyCollection _myColl = new clMyCollection();
		protected System.Web.UI.WebControls.Panel PagePanel;
		protected System.Web.UI.WebControls.Button cmdReset;
		protected System.Web.UI.WebControls.LinkButton lkbInfo;
		protected System.Web.UI.WebControls.LinkButton lnkChiudi;
		protected System.Web.UI.WebControls.Repeater rptFrequenze;
		protected System.Web.UI.WebControls.Panel pnlShowInfo;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected S_Controls.S_ComboBox cmbsAnnoDa;
		protected S_Controls.S_ComboBox cmbsAnnoA;
		protected WebControls.GridTitle GridTitle1;
		protected System.Web.UI.WebControls.Panel panelCopia;
		protected S_Controls.S_Button btnsCopiaPiano;
		protected S_Controls.S_ComboBox cmbsAnnoCopiato;
		protected S_Controls.S_ComboBox cmbsAnnoRiferimento;
		protected System.Web.UI.WebControls.Label lblNessunPiano;
		DettPianoAnnuale _fp;




		public clMyCollection _Contenitore
		{
			get 
			{
				return _myColl;
			}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;

			RicercaModulo1.DelegateCodiceEdificio1 +=new  WebControls.DelegateCodiceEdificio(this.BindServizio);

			if(!Page.IsPostBack)
			{				
				if(Request.QueryString["FunId"]!=null)
					ViewState["FunId"]=Request.QueryString["FunId"];
				try
				{
					
					DataGridRicerca.Visible = false;
					BindAnno();
					GridTitle1.hplsNuovo.Visible = false;
					BindServizio("");

					if(Context.Handler is TheSite.ManutenzioneProgrammata.DettPianoAnnuale)
					{
						_fp = (TheSite.ManutenzioneProgrammata.DettPianoAnnuale)Context.Handler;
						if (_fp!=null) 
						{
							_myColl=_fp._Contenitore;
							_myColl.SetValues(this.Page.Controls);		
							//_myColl.SetValues(this.RicercaModulo1);
							RicercaModulo1.Ricarica();
							Ricerca();
						}
					}					
				} 
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message); 
				}
			}
		}
		#region Paolo: 02/02/2007
		//   Paolo: Carica solo gli anni per cui è presente un piano di manutenzione già schedulato
		#endregion
		void BindAnno()
		{
			 DataSet _Ds;

			Classi.ManProgrammata.Planner _planner = new TheSite.Classi.ManProgrammata.Planner();

			_Ds = _planner.getAnniSchedulati();
			if  (_Ds.Tables[0].Rows.Count > 0 )
			{
				foreach (DataRow dr in _Ds.Tables[0].Rows)  
				{
					cmbsAnnoDa.Items.Add( dr[0].ToString());
					cmbsAnnoA.Items.Add(dr[0].ToString()) ;
					cmbsAnnoCopiato.Items.Add(dr[0].ToString());
				}     
				cmbsAnnoRiferimento.SelectedIndex = cmbsAnnoRiferimento.Items.Count -1;

				// il combo dell'anno che si vuole generare dev'essere popolato con gli anni a venire dall'anno in corso
				int annoCorrente = DateTime.Now.Year ; 
				int i;
				bool presente;
				for (i=annoCorrente; i <=annoCorrente + 10; i++)
				{
					// prova
					presente = false;
					foreach (DataRow dr in _Ds.Tables[0].Rows)  
					{
						if (i==  Convert.ToInt16(dr[0]))  
						{  
							presente = true;
							break;
						}
					}
					if (!presente)
						cmbsAnnoRiferimento.Items.Add(i.ToString());   
					
				}
			}
			else{
				lblNessunPiano.Visible=true;
				btnsRicerca.Enabled = false;
				panelCopia.Visible = false;
				cmbsAnnoA.Enabled = false;
				cmbsAnnoDa.Enabled = false;
				cmbsServizio.Enabled = false;
			}
		}

		private void BindServizio(string CodEdificio)
		{
			
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
					_MyDs.Tables[0], "DESCRIZIONE", "IDSERVIZIO", "- Selezionare un Servizio -", "");
				this.cmbsServizio.DataTextField = "DESCRIZIONE";
				this.cmbsServizio.DataValueField = "IDSERVIZIO";
				this.cmbsServizio.DataBind();
			}
			else
			{
				string s_Messagggio = "- Nessun Servizio -";
				this.cmbsServizio.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, String.Empty));
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
			this.btnsCopiaPiano.Click += new System.EventHandler(this.btnsCopiaPiano_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{			
			Ricerca();
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{ 
				string descrizione="";
				string note="";
				
				if (e.Item.Cells[3].Text.Trim().Length > 20) 
				{
					descrizione=e.Item.Cells[3].Text.Trim().Substring(0,18) + "..."; 
					e.Item.Cells[3].ToolTip=e.Item.Cells[3].Text;
					e.Item.Cells[3].Text=descrizione;
				} 
				
				if (e.Item.Cells[4].Text.Trim().Length >20) 
				{
					note=e.Item.Cells[4].Text.Trim().Substring(0,18) + "..."; 
					e.Item.Cells[4].ToolTip=e.Item.Cells[4].Text;
					e.Item.Cells[4].Text=note;
				} 

				if (e.Item.Cells[5].Text.Trim().Length > 10) 
				{
					note=e.Item.Cells[5].Text.Trim().Substring(0,10) + "..."; 
					e.Item.Cells[5].ToolTip=e.Item.Cells[5].Text;
					e.Item.Cells[5].Text=note.ToUpper();
				} 
				for (int index=6; index<=17; index++)
				{
					int i_red = 0;
					int i_green = 0;
					int i_blue = 0;
					string s_colore= Colora(Convert.ToInt16(e.Item.Cells[index].Text));
					i_red = Convert.ToInt16(s_colore.Substring(0,2),16);
					i_green = Convert.ToInt16(s_colore.Substring(2,2),16);
					i_blue = Convert.ToInt16(s_colore.Substring(4,2),16);				
					e.Item.Cells[index].BackColor= System.Drawing.Color.FromArgb(i_red,i_green,i_blue);
					e.Item.Cells[index].BorderColor=System.Drawing.Color.Black ;
					e.Item.Cells[index].BorderWidth=1;
					e.Item.Cells[index].ForeColor=System.Drawing.Color.Black;
				}
			}
		}

		public string Colora(int Mese)	
		{				
			string s_colore = "";
			if (Mese < 10)
			{
				s_colore="ffffff";
			}
			else if (Mese < 20)
			{
				s_colore="808080";
			}
			else if (Mese < 30)
			{
				s_colore="00ff00";
			}
			else if (Mese < 40)	
			{
				s_colore="008000";
			}
			else if (Mese < 50)
			{
				s_colore="0000ff";
			}
			else if (Mese < 60)	
			{
				s_colore="000080";
			}
			else if (Mese < 70)
			{
				s_colore="c00000";
			}
			else
			{
				s_colore="800000";				
			}
			return s_colore;		
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			Ricerca();

		}		
		private void Ricerca()
		{
			Classi.ManProgrammata.Planner _Planner = new TheSite.Classi.ManProgrammata.Planner(Context.User.Identity.Name);						
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_Bl_Id = new S_Controls.Collections.S_Object();
			s_p_Bl_Id.ParameterName = "annoDa";
			s_p_Bl_Id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Bl_Id.Direction = ParameterDirection.Input;
			s_p_Bl_Id.Size =4;
			s_p_Bl_Id.Index = 0;
			s_p_Bl_Id.Value = cmbsAnnoDa.SelectedValue;
			_SCollection.Add(s_p_Bl_Id);

			S_Controls.Collections.S_Object s_p_campus = new S_Controls.Collections.S_Object();
			s_p_campus.ParameterName = "annoA";
			s_p_campus.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_campus.Direction = ParameterDirection.Input;
			s_p_campus.Index = 1;
			s_p_campus.Size=4;
			s_p_campus.Value = cmbsAnnoA.SelectedValue;		
			_SCollection.Add(s_p_campus);


			S_Controls.Collections.S_Object s_p_Servizio = new S_Controls.Collections.S_Object();
			s_p_Servizio.ParameterName = "p_ID_Servizio";
			s_p_Servizio.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			s_p_Servizio.Direction = ParameterDirection.Input;
			s_p_Servizio.Index = 2;
			s_p_Servizio.Value = (cmbsServizio.SelectedValue ==string.Empty)? 0:Int32.Parse(cmbsServizio.SelectedValue);			
			_SCollection.Add(s_p_Servizio);
		
			DataSet _MyDs = _Planner.GetDataTutti(_SCollection).Copy();

			this.DataGridRicerca.DataSource = _MyDs.Tables[0];

			DataGridRicerca.Visible = true;

			if (_MyDs.Tables[0].Rows.Count == 0 )
			{
				DataGridRicerca.CurrentPageIndex=0;
			}
			else
			{
				int Pagina = 0;
				if ((_MyDs.Tables[0].Rows.Count % DataGridRicerca.PageSize) >0)
				{
					Pagina ++;
				}
				if (DataGridRicerca.PageCount != Convert.ToInt16((_MyDs.Tables[0].Rows.Count / DataGridRicerca.PageSize) + Pagina))
				{					
					DataGridRicerca.CurrentPageIndex=0;					
				}
				panelCopia.Visible= true  ;
			}
			
			this.DataGridRicerca.DataBind();
			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();	
		}

		private void lkbInfo_Click(object sender, System.EventArgs e)
		{
			Classi.ManProgrammata.Planner _Planner = new TheSite.Classi.ManProgrammata.Planner();
			this.pnlShowInfo.Visible = true;
			rptFrequenze.DataSource = _Planner.GetFrequenze();
			rptFrequenze.DataBind();
		}

		private void lnkChiudi_Click(object sender, System.EventArgs e)
		{
			this.pnlShowInfo.Visible = false;
		}

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Dettaglio")
			{
				//_myColl.AddControl(RicercaModulo1.Controls, ParentType.WebControl);
				//_myColl.AddControl(PagePanel.Controls, ParentType.Page);
				_myColl.AddControl(this.Page.Controls,ParentType.Page );
				string s_url = e.CommandArgument.ToString();							
				Server.Transfer(s_url);				
			}
		}



		private void cmdReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("PianoAnnuale.aspx?FunID=" + ViewState["FunId"]);
		}

		#region Paolo: 28/01/2007
		
		// procedura che permette di copiare il piano di manutenzione programmata di un anno
		// precedentemente schedulato

		# endregion
		private void btnsCopiaPiano_Click(object sender, System.EventArgs e)
		{
			S_ControlsCollection collezione = new S_ControlsCollection();

			// annoRiferimento

			S_Object pAnnoRifer = new S_Object();
			pAnnoRifer.ParameterName = "p_annoRif";
			pAnnoRifer.DbType = CustomDBType.VarChar;
			pAnnoRifer.Direction = ParameterDirection.Input;
			pAnnoRifer.Size=8;
			pAnnoRifer.Value= cmbsAnnoRiferimento.SelectedValue  ;
			pAnnoRifer.Index = 0 ; 
			collezione.Add(pAnnoRifer);

			// annoCopiato

			S_Object pAnnoCopiato = new S_Object();
			pAnnoCopiato.ParameterName = "p_annoCopiato";
			pAnnoCopiato.DbType = CustomDBType.VarChar;
			pAnnoCopiato.Direction = ParameterDirection.Input;
			pAnnoCopiato.Size=8;
			pAnnoCopiato.Value= cmbsAnnoCopiato.SelectedValue  ;
			pAnnoCopiato.Index = 1 ; 
			collezione.Add(pAnnoCopiato);

			// sono "obbligato" a istanziare un dataSet perchè l'oracleDataLayer non ha un metodo che torna un int utilizzabile!!!
			// (vergogna!! ;o)
			DataSet esito = new DataSet();  
			
			Classi.ManProgrammata.CreaOttimizzaRDL_MP _creaRDL = new TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP();

			esito = _creaRDL.copiaPiano(collezione);

			int codEsito = Convert.ToInt16(esito.Tables[0].Rows[0][0]);
			string messaggio;
			switch (codEsito)
			{
				case 0:
					messaggio = "Il piano di manutenzione programmata è stato correttamente copiato !!";
					break;
				case 1:
					messaggio = "Procedura di manutenzione già schedulata!!";
					break;
				case 2:
					messaggio = "ATTENZIONE: Per almeno un servizio è stato inserito un addetto generico!!";
					break;
				case 3:
					messaggio = "E' stato rilevato un servio o apparato fuori periodo di validità appalto!!";
					break;
				case 6:
					messaggio = "ATTENZIONE: Per almeno un servizio non sono state rilevate frequenze fisse!!";
					break;
				default :
					messaggio= "Si è verificato un errore nel tentativo di copiare il piano di manutenzione programmata";
				break;
			}

			TheSite.Classi.SiteJavaScript.msgBox(this.Page, messaggio);

		}


	}
}
