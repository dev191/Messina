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

namespace AslMobile
{
	/// <summary>
	/// Descrizione di riepilogo per Completamento_MP_WRList.
	/// </summary>
	public class Completamento_MP_WRList : System.Web.UI.MobileControls.MobilePage
	{
		protected System.Web.UI.MobileControls.Panel Panel1;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific1;
		protected System.Web.UI.MobileControls.Form Form1;
		private		string		userName;
		protected System.Web.UI.MobileControls.Form Form2;
		protected System.Web.UI.MobileControls.Panel pnlDettagli;
		protected System.Web.UI.MobileControls.DeviceSpecific DeviceSpecific2;
		private		DataGrid	 DataGridRicerca;
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
		private string rdl_id
		{
			get
			{
				if(ViewState["rdl_id"]!=null)
					return (string)ViewState["rdl_id"];
				else
					return string.Empty;
			}
			set
			{
				ViewState.Add("rdl_id",value);
			}
		}
		private int sel_grid
		{
			get
			{
				if(ViewState["sel_grid"]!=null)
					return (int)ViewState["sel_grid"];
				else
					return -1;
			}
			set
			{
				ViewState.Add("sel_grid",value);
			}
		}



		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if (!Page.IsPostBack)
			{
				if(Request.QueryString["wo_id"]!=null)
					this.wo_id=Request.QueryString["wo_id"];
				if(Context.Items["wo_id"]!=null)
					this.wo_id=(string)Context.Items["wo_id"];
				this.Ricerca(Int32.Parse(this.wo_id));
			}
		}
		


		private void UpdateWr()
		{
			OracleParameterCollection Coll= new OracleParameterCollection();
			TheSite.AslMobile.Class.ClassCompletaOrdine  _Completa = new TheSite.AslMobile.Class.ClassCompletaOrdine();

	
			OracleParameter p_wo_id = new OracleParameter();
			p_wo_id.ParameterName = "p_wo_id";
			p_wo_id.OracleType = OracleType.Int32;
			p_wo_id.Direction = ParameterDirection.Input;
			p_wo_id.Value = wo_id;																	
			Coll.Add(p_wo_id);

			OracleParameter p_wr_id = new OracleParameter();
			p_wr_id.ParameterName = "p_wr_id";
			p_wr_id.OracleType = OracleType.Int32;
			p_wr_id.Direction = ParameterDirection.Input;
			p_wr_id.Value = rdl_id;																	
			Coll.Add(p_wr_id);

			OracleParameter p_data = new OracleParameter();
			p_data.ParameterName = "p_data";
			p_data.OracleType = OracleType.DateTime;
			p_data.Direction = ParameterDirection.Input;
			p_data.Value = Convert.ToDateTime(this.GetValue(pnlDettagli,"lblCalendario")).ToString("d");																	
			Coll.Add(p_data);
				
			OracleParameter p_stato = new OracleParameter();
			p_stato.ParameterName = "p_stato";
			p_stato.OracleType = OracleType.Int32;
			p_stato.Direction = ParameterDirection.Input;
			
			int stato = Convert.ToInt32(((RadioButtonList)pnlDettagli.Controls[0].Controls[0].FindControl("RadioButtonList1")).SelectedItem.Value.ToString());
			if( stato == 15)//sospesa
			{
				p_stato.Value = 1; 	
			}
			else//chiusa
			{
				p_stato.Value = 0; 	
			}										
			Coll.Add(p_stato);

			OracleParameter p_motivo = new OracleParameter();
			p_motivo.ParameterName = "p_motivo";
			p_motivo.OracleType = OracleType.VarChar;
			p_motivo.Direction = ParameterDirection.Input;
			p_motivo.Size=4000; 
			p_motivo.Value = this.GetValue(pnlDettagli,"TextBox2"); 																
			Coll.Add(p_motivo);

			DataSet DsTemp=_Completa.AggiornaWr(Coll);	
/*				
					if (DsTemp.Tables[0].Rows.Count>0)
					{
						
						if(Dt.Rows.Count==0)  
							Dt=DsTemp.Tables[0].Clone();
						Dt.ImportRow(DsTemp.Tables[0].Rows[0]);  
                
					}
	*/										
				
		
//			return Dt;	
		}



		protected void Index_Changed(Object sender, EventArgs e) 
		{
		
			string value = ((RadioButtonList)pnlDettagli.Controls[0].Controls[0].FindControl("RadioButtonList1")).SelectedItem.Value;
			switch((TheSite.AslMobile.Class.StateType)Int16.Parse(value))
			{
				case TheSite.AslMobile.Class.StateType.AttivitaCompletata:																										
					((System.Web.UI.WebControls.TextBox)pnlDettagli.Controls[0].FindControl("TextBox2")).Enabled=false;
					break;
				case TheSite.AslMobile.Class.StateType.EmessaInLavorazione:																	
					((System.Web.UI.WebControls.TextBox)pnlDettagli.Controls[0].FindControl("TextBox2")).Enabled=false;
					break;
				case TheSite.AslMobile.Class.StateType.RichiestaSospesa:											
					((System.Web.UI.WebControls.TextBox)pnlDettagli.Controls[0].FindControl("TextBox2")).Enabled=true;
					break;
			}
		}

		protected void OnSalva(object sender, System.EventArgs e)
		{
			this.UpdateWr();
			this.Ricerca(Int32.Parse(this.wo_id));
			this.ActiveForm = Form1;
		}
		protected void OnAnnulla(object sender, System.EventArgs e)
		{
			this.ActiveForm = Form1;
		}
		protected void OnCalendario(object sender, System.EventArgs e)
		{

			TheSite.AslMobile.CalendarioUserControl cal = (TheSite.AslMobile.CalendarioUserControl)pnlDettagli.Controls[0].Controls[0].FindControl("Calendario1"); 
			cal.EnbledCal();
			//this.ActiveForm = Form1;
		}
		private void Ricerca(int wo_id)
		{				
			//-- Valorizzo i Dati della WO
			OracleParameterCollection Coll= new OracleParameterCollection();
						
			// WO_ID
			OracleParameter s_WO_ID = new OracleParameter();

			s_WO_ID.ParameterName = "p_WO_ID";
			s_WO_ID.OracleType = OracleType.Int32;
			s_WO_ID.Direction = ParameterDirection.Input;
			s_WO_ID.Size=4;			
			s_WO_ID.Value=wo_id;			
			Coll.Add(s_WO_ID);			

			TheSite.AslMobile.Class.ClassManProgrammata _Compl = new TheSite.AslMobile.Class.ClassManProgrammata(userName);						
			
			DataSet _MyDs = _Compl.GetDatiWO(Coll).Copy();			
			DataRow _Dr = _MyDs.Tables[0].Rows[0]; 
			// Wo_ID
			this.SetValue(Panel1,"lblOrdineLavoro",_Dr["wo_id"].ToString());
			// Edificio
			this.SetValue(Panel1,"lblEdificio",_Dr["Edificio"].ToString());				
			// Indirizzo
			this.SetValue(Panel1,"lblIndirizzo",_Dr["Indirizzo"].ToString());				
			// Data Emissione ODL
			if(_Dr["DataEmissione"].ToString()!="")
					this.SetValue(Panel1,"lblODL",DateTime.Parse(_Dr["DataEmissione"].ToString()).ToLongDateString());				
						// DataPianificata			
			string _CampoData = _Dr["DataPianificata"].ToString();
			if (_CampoData.Length > 0) 
			{					
				DateTime _Data = Convert.ToDateTime(_CampoData);
				string mese =  TheSite.Classi.Function.ImpostaMese(_Data.Month,false);
				string anno = _Data.Year.ToString();
				this.SetValue(Panel1,"lblDataPianificata",mese + " - " + anno);				
			}			
			/*
						// Localita
						if(_Dr["Localita"].ToString().Trim()!="()")
							LblLocalita.Text=_Dr["Localita"].ToString();				
						// Addetto
						LblAddetto.Text=_Dr["Addetto"].ToString();			
						*/
			
			//-- Visualizzo i Dati delle WR legate alla WO		

			DataSet _MyDsWR = _Compl.GetDatiWR(Coll).Copy();
									
			this.DataGridRicerca.DataSource = _MyDsWR.Tables[0];
			this.DataGridRicerca.DataBind();
			
			//			this.GridTitle1.NumeroRecords = _MyDsWR.Tables[0].Rows.Count.ToString();
			/*
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
			*/
		}

		protected void DataGridRicerca_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			///Imposto la Nuova Pagina
			this.DataGridRicerca.CurrentPageIndex=e.NewPageIndex;
			this.Ricerca(Int32.Parse(this.wo_id));
		}	
		protected void DataGridRicerca_ItemDataBound_1(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				string funz=String.Empty;
				
					int Stato = Int16.Parse(e.Item.Cells[9].Text);
				
					switch((TheSite.AslMobile.Class.StateType)Stato)
					{
					
						case TheSite.AslMobile.Class.StateType.AttivitaCompletata:																										
							//Imposto l'Option					
							((System.Web.UI.WebControls.ImageButton)e.Item.Cells[0].FindControl("Imagebutton1")).ImageUrl="./images/rosso.gif";
							break;
						case TheSite.AslMobile.Class.StateType.EmessaInLavorazione:																	
							//Imposto l'Option
							((ImageButton)e.Item.Cells[0].FindControl("Imagebutton1")).ImageUrl="./images/giallo.gif";
							
							break;
						case TheSite.AslMobile.Class.StateType.RichiestaSospesa:											
							//Imposto l'Option
						
							break;	
					}	
			}

			///Imposto la Nuova Pagina
			//			this.DataGridRicerca.CurrentPageIndex=e.NewPageIndex;
			//			this.Ricerca(Int32.Parse(this.wo_id));
		}	
		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if ((e.Item.ItemType == ListItemType.Pager) ||	(e.Item.ItemType == ListItemType.Header)) 
				return;
			
			this.sel_grid=e.Item.ItemIndex;
/*
			Button btn  = (Button)e.CommandSource;

			if (btn.Text == "Modifica")
			{
		
				txtDescrizioneTipologia.Text = e.Item.Cells[3].Text;
				cmbsApparecchiatura.SelectedValue=e.Item.Cells[2].Text;
				cmbsApparecchiatura.Enabled =false;
			}

			btsalvaTipologia.CommandArgument = "Edit";
*/	
		}
		protected void RDL_Click(Object sender , CommandEventArgs e)
		{
//			DataGridRicerca.SelectedItem 
			
			string argument=(string)e.CommandArgument;
			string delimStr = ":";
			char [] delimiter = delimStr.ToCharArray();
			string[] parameter = argument.Split(delimiter,3);
			this.rdl_id = parameter[0];
			int Stato = Int16.Parse(parameter[1]);
			RadioButtonList Opt;
			((System.Web.UI.MobileControls.Label)pnlDettagli.Controls[0].FindControl("lblCalendario")).Text = DateTime.Now.ToShortDateString();

			switch((TheSite.AslMobile.Class.StateType)Stato)
			{
					
				case TheSite.AslMobile.Class.StateType.AttivitaCompletata:																										
					//Imposto l'Option
					Opt = (RadioButtonList)pnlDettagli.Controls[0].Controls[0].FindControl("RadioButtonList1");
					Opt.Items[0].Selected=true;
					Opt.Items[1].Selected=false;
					Opt.Enabled=false;						
										
					if(parameter[2]!="&nbsp;")
						this.SetValue(pnlDettagli,"TextBox2",parameter[2]);
//						((System.Web.UI.WebControls.TextBox)pnlDettagli.Controls[0].FindControl("TextBox2")).Text=parameter[2];
					
					((System.Web.UI.WebControls.TextBox)pnlDettagli.Controls[0].FindControl("TextBox2")).Enabled=false;
					break;
				case TheSite.AslMobile.Class.StateType.EmessaInLavorazione:																	
					//Imposto l'Option
					Opt = (RadioButtonList)pnlDettagli.Controls[0].Controls[0].FindControl("RadioButtonList1");
					Opt.Items[0].Selected=true;
					Opt.Items[1].Selected=false;
					Opt.Enabled=true;						

					if(parameter[2]!="&nbsp;")
						this.SetValue(pnlDettagli,"TextBox2",parameter[2]);
					//						((System.Web.UI.WebControls.TextBox)pnlDettagli.Controls[0].FindControl("TextBox2")).Text=parameter[2];
					
					((System.Web.UI.WebControls.TextBox)pnlDettagli.Controls[0].FindControl("TextBox2")).Enabled=false;
					break;

				case TheSite.AslMobile.Class.StateType.RichiestaSospesa:											
					//Imposto l'Option
					Opt = (RadioButtonList)pnlDettagli.Controls[0].Controls[0].FindControl("RadioButtonList1");
					Opt.Items[1].Selected=true;	
					Opt.Items[0].Selected=false;
					Opt.Enabled=true;						
					
					if(parameter[2]!="&nbsp;")
						this.SetValue(pnlDettagli,"TextBox2",parameter[2]);
					//	((System.Web.UI.MobileControls.TextBox)pnlDettagli.Controls[0].FindControl("TextBox1")).Text=parameter[2];
					break;	
			}	
			this.ActiveForm = Form2;
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
			this.DataGridRicerca = (DataGrid)Panel1.Controls[0].FindControl("DataGridRicerca1");
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged_1);
			this.DataGridRicerca.ItemDataBound +=new DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound_1);
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);

//			RadioButtonList radio =(RadioButtonList) pnlDettagli.Controls[0].FindControl("RadioButtonList1");
//			radio.SelectedIndexChanged +=

				//new System.Web.UI.WebControls.DataGridItemEventHandler

			TheSite.AslMobile.CalendarioUserControl cal = (TheSite.AslMobile.CalendarioUserControl)pnlDettagli.Controls[0].Controls[0].FindControl("Calendario1"); 
			cal.setLabel((System.Web.UI.MobileControls.Label)pnlDettagli.Controls[0].FindControl("lblCalendario"));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
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
