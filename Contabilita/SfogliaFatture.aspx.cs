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
using MyCollection;


namespace TheSite.Contabilita
{
	/// <summary>
	/// Descrizione di riepilogo per SfogliaFatture.
	/// </summary>
	public class SfogliaFatture : System.Web.UI.Page
	{
		protected Csy.WebControls.DataPanel PanelRicerca;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected WebControls.CalendarPicker CalendarPicker1;
		protected WebControls.CalendarPicker CalendarPicker2;
		protected WebControls.CalendarPicker CalendarPicker3;
		protected WebControls.CalendarPicker CalendarPicker4;
		protected WebControls.CalendarPicker CalendarPicker5;
		protected WebControls.CalendarPicker CalendarPicker6;
		protected WebControls.CalendarPicker CalendarPicker7;
		protected WebControls.CalendarPicker CalendarPicker8;
		DataSet _MyDs = new DataSet();
		InserimentoFattura _fp;
		public static int FunId = 0;
		public static string HelpLink = string.Empty;
		MyCollection.clMyCollection _myColl = new clMyCollection();
		protected WebControls.GridTitle GridTitle1;
		protected S_Controls.S_ComboBox cmbsServizio;
		protected System.Web.UI.WebControls.DropDownList cmbAnnoDa;
		protected System.Web.UI.WebControls.DropDownList cmbDaMese;
		protected WebControls.PageTitle PageTitle1;
		protected S_Controls.S_TextBox S_TxtNumFattura;
		Classi.Fatturazione.Contabilita _Contabilita = new TheSite.Classi.Fatturazione.Contabilita();
		string s_PeriodoDa="";
		protected S_Controls.S_TextBox S_TxtImponibileDec;
		protected S_Controls.S_TextBox S_TxtImponibile;
		protected S_Controls.S_ListBox S_ListRDL;
		protected WebControls.RicercaRDL RicercaRDL1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden rdl;
		protected System.Web.UI.HtmlControls.HtmlTable TableOrdinaria;
		protected System.Web.UI.HtmlControls.HtmlTable TableStrardinaria;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected S_Controls.S_Button btnsRicerca;
		string strArrRdl="";
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
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		public MyCollection.clMyCollection _Contenitore
		{
			get 
			{
				return _myColl;
			}
		}


		private void visualizzatab()
		{		
			if (cmbsServizio.SelectedValue=="1")
			{
				TableOrdinaria.Attributes.Add("Style","DISPLAY:block");
				TableStrardinaria.Attributes.Add("Style","DISPLAY:none");
			}

			if (cmbsServizio.SelectedValue=="3")
			{
				TableOrdinaria.Attributes.Add("Style","DISPLAY:none");
				TableStrardinaria.Attributes.Add("Style","DISPLAY:block");
			}
			if (cmbsServizio.SelectedValue=="")
			{
				TableOrdinaria.Attributes.Add("Style","DISPLAY:none");
				TableStrardinaria.Attributes.Add("Style","DISPLAY:none");
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			visualizzatab();
			S_ListRDL.Attributes.Add("onkeydown","deleteitem(this,event);"); 
			RicercaRDL1.multisele="y";
			RicercaRDL1.operazione="Cerca";
			
			
			Classi.SiteModule _SiteModule = (Classi.SiteModule) HttpContext.Current.Items["SiteModule"];
			this.GridTitle1.hplsNuovo.NavigateUrl = "../Contabilita/InserimentoFattura.aspx?ItemID=0&FunId=" + _SiteModule.ModuleId;
			this.GridTitle1.hplsNuovo.Visible = _SiteModule.IsEditable;	

			this.DataGridRicerca.Columns[1].Visible = true;
			this.DataGridRicerca.Columns[2].Visible = _SiteModule.IsEditable;				
						
			FunId = _SiteModule.ModuleId;
			HelpLink = _SiteModule.HelpLink;
			this.PageTitle1.Title = _SiteModule.ModuleTitle;			
			
			if (!Page.IsPostBack)
			{
				CaricaTipoServizio();
				S_TxtImponibile.Attributes.Add("onkeypress","if (valutanumeri(event) == false) { return false; }");
				S_TxtImponibile.Attributes.Add("onpaste","return false;");
				S_TxtImponibile.Attributes.Add("onblur","imposta_int(this.id);");
				cmbsServizio.Attributes.Add("onChange","visualizzadettservizio(this);");
				cmbAnnoDa.Attributes.Add("onChange","abilita();");

				if(Context.Handler is TheSite.Contabilita.InserimentoFattura) 
				{									
					_fp = (TheSite.Contabilita.InserimentoFattura) Context.Handler;
					if (_fp!=null)
					{
						_myColl=_fp._Contenitore;
						_myColl.SetValues(this.Page.Controls);
						Ricerca();
					}
					
				}		

			}
		}

		
		private void CaricaTipoServizio()
		{
			this.cmbsServizio .Items.Clear();
			DataSet  _MyDs =_Contabilita.GetTipoServizio().Copy();
			if (_MyDs.Tables[0].Rows.Count > 0)
			{
				this.cmbsServizio.DataSource = Classi.GestoreDropDownList.ItemBlankDataSource(
					_MyDs.Tables[0], "descrizione", "tipomanutenzione_id", "- Selezionare un Servizio -","0");
				this.cmbsServizio.DataTextField = "descrizione";
				this.cmbsServizio.DataValueField = "tipomanutenzione_id";
				this.cmbsServizio.DataBind();
			}
		
		}
		private void Ricerca()
		{
			string s_Imponibile= S_TxtImponibile.Text +","+ S_TxtImponibileDec.Text;
			if (s_Imponibile == "0,00")
				s_Imponibile="0";
			
			
			if (cmbsServizio.SelectedValue=="1" && cmbAnnoDa.SelectedValue!="0000" && cmbDaMese.SelectedValue!="00")
			{
                s_PeriodoDa=cmbAnnoDa.SelectedValue + cmbDaMese.SelectedValue;
			}
			else
			{
				s_PeriodoDa="0";
			}

			if (cmbsServizio.SelectedValue=="3")
			{
				strArrRdl=rdl.Value;
				if (strArrRdl!="")
				strArrRdl=strArrRdl.Substring(0,strArrRdl.Length-1);
				else
				strArrRdl="0";
			}
			else
				strArrRdl="0";
			
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();	

			S_Controls.Collections.S_Object  DataFattura= new S_Object();
			DataFattura.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DataFattura.Direction = ParameterDirection.Input;
			DataFattura.Value =CalendarPicker1.Datazione.Text;
			DataFattura.ParameterName = "p_DATA_FATTURAA";
			DataFattura.Size=10;
			DataFattura.Index= 0;
			CollezioneControlli.Add(DataFattura);

			S_Controls.Collections.S_Object  DataFatturada= new S_Object();
			DataFatturada.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DataFatturada.Direction = ParameterDirection.Input;
			DataFatturada.Value =CalendarPicker5.Datazione.Text;
			DataFatturada.ParameterName = "p_DATA_FATTURADA";
			DataFatturada.Size=10;
			DataFatturada.Index= 1;
			CollezioneControlli.Add(DataFatturada);


			S_Controls.Collections.S_Object  NumFattura= new S_Object();
			NumFattura.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			NumFattura.Direction = ParameterDirection.Input;
			NumFattura.Value = S_TxtNumFattura.Text;
			NumFattura.ParameterName = "p_NUMEROFATTURA";
			NumFattura.Size=50;
			NumFattura.Index= 2;
			CollezioneControlli.Add(NumFattura);

			

			S_Controls.Collections.S_Object  DataScadPagam= new S_Object();
			DataScadPagam.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DataScadPagam.Direction = ParameterDirection.Input;
			DataScadPagam.Value =CalendarPicker2.Datazione.Text;
			DataScadPagam.ParameterName = "p_DATA_SCADENZA_PAGAMENTODA";
			DataScadPagam.Size=10;
			DataScadPagam.Index= 3;
			CollezioneControlli.Add(DataScadPagam);

			S_Controls.Collections.S_Object  DataScadPagama= new S_Object();
			DataScadPagama.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DataScadPagama.Direction = ParameterDirection.Input;
			DataScadPagama.Value =CalendarPicker6.Datazione.Text;
			DataScadPagama.ParameterName = "p_DATA_SCADENZA_PAGAMENTOA";
			DataScadPagama.Size=10;
			DataScadPagama.Index= 4;
			CollezioneControlli.Add(DataScadPagama);

			S_Controls.Collections.S_Object  TipoManutenzione_id= new S_Object();
			TipoManutenzione_id.DbType = ApplicationDataLayer.DBType.CustomDBType.Integer;
			TipoManutenzione_id.Direction = ParameterDirection.Input;
			TipoManutenzione_id.Value = Int32.Parse(cmbsServizio.SelectedValue);
			TipoManutenzione_id.ParameterName = "p_TIPOMANUTENZIONE_ID";
			TipoManutenzione_id.Index= 5;
			CollezioneControlli.Add(TipoManutenzione_id);

			S_Controls.Collections.S_Object  PeriodoInizio= new S_Object();
			PeriodoInizio.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			PeriodoInizio.Direction = ParameterDirection.Input;
			PeriodoInizio.Value = s_PeriodoDa;
			PeriodoInizio.ParameterName = "p_PERIODO_INIZIO_FATTURA";
			PeriodoInizio.Index= 6;
			CollezioneControlli.Add(PeriodoInizio);

			S_Controls.Collections.S_Object  Imponibile= new S_Object();
			Imponibile.DbType = ApplicationDataLayer.DBType.CustomDBType.Double;
			Imponibile.Direction = ParameterDirection.Input;
			Imponibile.Value = s_Imponibile;
			Imponibile.ParameterName = "p_IMPONIBILE";
			Imponibile.Index= 7;
			CollezioneControlli.Add(Imponibile);

			S_Controls.Collections.S_Object  DataApprovazione= new S_Object();
			DataApprovazione.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DataApprovazione.Direction = ParameterDirection.Input;
			DataApprovazione.Value =CalendarPicker3.Datazione.Text;
			DataApprovazione.ParameterName = "p_DATA_APPROVAZIONEDA";
			DataApprovazione.Size=10;
			DataApprovazione.Index= 8;
			CollezioneControlli.Add(DataApprovazione);

			S_Controls.Collections.S_Object  DataApprovazionea= new S_Object();
			DataApprovazionea.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DataApprovazionea.Direction = ParameterDirection.Input;
			DataApprovazionea.Value =CalendarPicker7.Datazione.Text;
			DataApprovazionea.ParameterName = "p_DATA_APPROVAZIONEA";
			DataApprovazionea.Size=10;
			DataApprovazionea.Index= 9;
			CollezioneControlli.Add(DataApprovazionea);

			S_Controls.Collections.S_Object  DataPagam= new S_Object();
			DataPagam.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DataPagam.Direction = ParameterDirection.Input;
			DataPagam.Value = CalendarPicker4.Datazione.Text;
			DataPagam.Size=10;
			DataPagam.ParameterName = "p_DATA_PAGAMENTODA";
			DataPagam.Index= 10;
			CollezioneControlli.Add(DataPagam);

			S_Controls.Collections.S_Object  DataPagama= new S_Object();
			DataPagama.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			DataPagama.Direction = ParameterDirection.Input;
			DataPagama.Value = CalendarPicker4.Datazione.Text;
			DataPagama.Size=10;
			DataPagama.ParameterName = "p_DATA_PAGAMENTOA";
			DataPagama.Index= 11;
			CollezioneControlli.Add(DataPagama);

								
			S_Controls.Collections.S_Object s_ArrRDL = new S_Object();
			s_ArrRDL.ParameterName = "p_Arr_RDL";
			s_ArrRDL.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_ArrRDL.Direction = ParameterDirection.Input;
			s_ArrRDL.Index = 12;
			s_ArrRDL.Value = strArrRdl;					
			CollezioneControlli.Add(s_ArrRDL);

			//DataSet _MyDs = _Contabilita.GetData().Copy();

			DataSet _MyDs = _Contabilita.GetData(CollezioneControlli).Copy();
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			if (_MyDs.Tables[0].Rows.Count == 0 )
				DataGridRicerca.CurrentPageIndex=0;
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
			}
			this.DataGridRicerca.DataBind();					
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();

		}

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			Ricerca();
			strArrRdl="";
			rdl.Value="";
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("SfogliaFatture.aspx?FunId=" + FunId);
		}

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Dettaglio")
			{	
				_myColl.AddControl(this.Page.Controls, ParentType.Page);
				string s_url = e.CommandArgument.ToString();							
				Server.Transfer(s_url);				
			}
		}

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{	
				
				//aggiunta per tooltip
				string descrizione="";
				string tooltip = "";
				System.Collections.ArrayList itmTooltip = new ArrayList();
				itmTooltip.Add(tooltip);
				itmTooltip.Add(descrizione);

				if (e.Item.Cells[11].Text.Trim().Length > 0) 
				{
					Classi.Function.Tronca(e.Item.Cells[11].Text,10,itmTooltip,e.Item.Cells[11].Text.Trim().Length);
					e.Item.Cells[11].ToolTip=itmTooltip[0].ToString();
					e.Item.Cells[11].Text=itmTooltip[1].ToString();		
				} 


				ImageButton _img1 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton3");
				_img1.Attributes.Add("title","Visualizza");

				ImageButton _img2 = (ImageButton) e.Item.Cells[1].FindControl("Imagebutton2");
				_img2.Attributes.Add("title","Modifica");

				if (e.Item.Cells[14].Text=="1")	
				{
					string str=e.Item.Cells[7].Text;
					string str1 =e.Item.Cells[8].Text;
					if (str!="0" && str1!="0")
						e.Item.Cells[7].Text ="Dal "+str.Substring(0,4)+"/"+str.Substring(4,2)+" Al "+ str1.Substring(0,4)+"/"+str1.Substring(4,2);
					e.Item.Cells[8].Text=" ";
					e.Item.Cells[9].Text=" ";
				}
				else
					e.Item.Cells[7].Text="";
			
				if (e.Item.Cells[14].Text=="3")
				{
					string rdl="";
					int ietmId = Convert.ToInt32(e.Item.Cells[0].Text);
					_MyDs = _Contabilita.GetSingleRdlFatt(ietmId); 
					int conta =_MyDs.Tables[0].Rows.Count;
					if (conta > 0)
					{
						for(int i=0 ; i < conta; i++)
						{
							DataRow _Dr = _MyDs.Tables[0].Rows[i];
							rdl = rdl +_Dr["wr_id"]+";";
						
						}
						rdl=rdl.Substring(0,rdl.Length-1);
					}
					e.Item.Cells[9].Text=rdl;
				}
				else
					e.Item.Cells[9].Text=" ";
			}
		}

		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;			
			Ricerca();
		}

		
		
	
	
	}
}

	
