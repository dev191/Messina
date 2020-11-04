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
using MyCollection;

namespace TheSite.ManutenzioneProgrammata.Schedula
{
	/// <summary>
	/// Descrizione di riepilogo per OttimizzaPianoSalva.
	/// </summary>
	public class OttimizzaPianoSalva : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblpmp;
		protected System.Web.UI.WebControls.TextBox txtAnno;
		protected System.Web.UI.WebControls.TextBox txtEQ;
		protected System.Web.UI.WebControls.TextBox txtId_bl;
		protected System.Web.UI.WebControls.TextBox txtbl_id;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected S_Controls.S_Button btSalva;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;
		private DataSet _MyDs = new DataSet();
		private DataTable DtAddetti;
		protected System.Web.UI.WebControls.TextBox txtfiglia;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.WebControls.TextBox txtOldDD;
		protected System.Web.UI.WebControls.TextBox txtOldMM;
		protected System.Web.UI.WebControls.TextBox txtOldAddetto;
		protected WebControls.UserMeseGiorno mmgg;

		
		
	
		private void Page_Load(object sender, System.EventArgs e)
		{	
			txtfiglia.Text = "0";
			Hidden1.Value = "0";
			if(!Page.IsPostBack)
			{
				PageTitle1.VisibleLogut = false;
				GridTitle1.hplsNuovo.Visible = false;
				txtAnno.Text = Request.Params["anno"]; 
				txtEQ.Text = Request.Params["EQ_ID"];				
				txtId_bl.Text = Request.Params["id_bl"];
				txtbl_id.Text = Request.Params["bl_id"];

				Session.Remove("DatiListP");
				PageTitle1.Title="OTTIMIZZA IL PIANO";
  
				lblpmp.Text= "Piano Manutenzione Programmata Apparecchiatura: " + txtEQ.Text + " - Anno: " + txtAnno.Text;
				
				DtAddetti=BindAddettiDitta(txtbl_id.Text,"");

				GetDataGrid();				
			}
		}
		private void GetDataGrid()
		{
			Classi.ManProgrammata.Planner _Planner = new TheSite.Classi.ManProgrammata.Planner();			
			S_ControlsCollection _SCollection = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_EQ_ID = new S_Object();
			s_EQ_ID.ParameterName = "p_EQ_ID";
			s_EQ_ID.DbType = CustomDBType.VarChar;
			s_EQ_ID.Direction = ParameterDirection.Input;
			s_EQ_ID.Index = 0;
			s_EQ_ID.Value = txtEQ.Text ;			
			s_EQ_ID.Size = 50;

			_SCollection.Add(s_EQ_ID);

			S_Controls.Collections.S_Object s_Anno = new S_Object();
			s_Anno.ParameterName = "p_Anno";
			s_Anno.DbType = CustomDBType.Integer;
			s_Anno.Direction = ParameterDirection.Input;
			s_Anno.Index = 1;
			s_Anno.Value = txtAnno.Text ;			
			s_Anno.Size = 4;

			_SCollection.Add(s_Anno);		

			_MyDs = _Planner.GetPassiPianoDett(_SCollection).Copy();
			
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();
			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();	
		}

		private DataTable BindAddettiDitta(string bl_id,string nomecompleto)
		{	
			Classi.ManOrdinaria.Richiesta  _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
			DataSet _MyDs;
			_MyDs = _Richiesta.GetAddetti(nomecompleto,bl_id,0);
			return _MyDs.Tables[0];
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
			this.DataGridRicerca.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGridRicerca_ItemCommand);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem)
			{				
				DataRowView drv = (DataRowView)(e.Item.DataItem);
				
				SetControl(true,drv,e);
				WebControls.UserMeseGiorno _UMG = (WebControls.UserMeseGiorno) e.Item.Cells[5].FindControl("UserMeseGiorno1");		
				_UMG.cmbGiorni.Enabled = false;
				_UMG.cmbMesi.Enabled = false;
				DropDownList dropd= (DropDownList)e.Item.Cells[7].Controls[1]; 
				foreach (DataRow Dr in DtAddetti.Rows)
					dropd.Items.Add(new ListItem(Dr["nome"].ToString() + " " + Dr["cognome"].ToString(),  Dr["ID"].ToString()));  

				dropd.SelectedValue = drv.Row["ADDETTO_ID"].ToString();
						
			}
		}

		private void SetControl(bool visiblecontrol,DataRowView drv,System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			WebControls.UserMeseGiorno _UMG = (WebControls.UserMeseGiorno) e.Item.Cells[5].FindControl("UserMeseGiorno1");		
			if (visiblecontrol==false)
			{
				_UMG.Visible=false;
				return;
			}

			string funz = "ImpostaGiorni(this.value,'" + _UMG.cmbGiorni.ClientID + "')";			
			_UMG.cmbMesi.Attributes.Add("onchange",funz);
				
			// Controllo se sono già stati impostati il giorno ed il mese
			
			if(drv.Row["DATA"].ToString() != "")
			{
				DateTime  mese_girono=Convert.ToDateTime ( drv.Row["DATA"].ToString());
				
					
				string mese = mese_girono.Month.ToString();
				string giorno =mese_girono.Day.ToString()  ;

				_UMG.cmbMesi.SelectedValue=mese;
					
				//Richiamo la funzione che imposta i giorni del mese in esame
				ImpostaGiorni(mese,_UMG.cmbGiorni);					
					
				_UMG.cmbGiorni.SelectedValue=giorno;	
			}
			else
			{
				ImpostaGiorni(_UMG.cmbMesi.SelectedValue,_UMG.cmbGiorni);					
			}
		}
		private void ImpostaGiorni(string mese, S_Controls.S_ComboBox Giorni)
		{
			int maxgiorni=0;
			switch (mese)
			{		
				case "4":	//Aprile		
				case "6":	//Giugno		
				case "9":	//Settembre		
				case "11":	//Novembre		
					maxgiorni=30;
					break;
				case "2":		
					maxgiorni=28; //Febbraio	
					break;
				default:		
					maxgiorni=31;
					break;
			}
			
			Giorni.Items.Clear();
			

			for(int i=1;i<=maxgiorni;i++)
			{	
				ListItem _L = new ListItem(i.ToString(),i.ToString());
				Giorni.Items.Add(_L);
			}

		}

		private void DataGridRicerca_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Dettaglio")
			{				
				foreach (DataGridItem cella in DataGridRicerca.Items)
				{					
					ImageButton a =(ImageButton) cella.Cells[0].Controls[0].FindControl("lnkDett");
					a.Visible = false;

					DataGridRicerca.Columns[1].Visible = true;
					ImageButton lnkAnn =(ImageButton) cella.Cells[1].Controls[0].FindControl("lnkAnn");
					lnkAnn.Visible = false;

					WebControls.UserMeseGiorno _UMG = (WebControls.UserMeseGiorno) e.Item.Cells[5].FindControl("UserMeseGiorno1");		
					_UMG.cmbGiorni.Enabled = true;
					_UMG.cmbMesi.Enabled = true;
					txtOldDD.Text = _UMG.cmbGiorni.SelectedValue;
					txtOldMM.Text = _UMG.cmbMesi.SelectedValue;				
				}
								
				ImageButton buttannulla =(ImageButton) e.Item.Cells[0].Controls[0].FindControl("lnkAnn");
				buttannulla.Visible=true;
				buttannulla.ImageUrl="../../images/annulla.gif";

				ImageButton butt =(ImageButton) e.Item.Cells[0].Controls[0].FindControl("lnkDett");
				butt.Visible=true;
				butt.ImageUrl="../../images/salva.gif";
				butt.CommandName="Aggiorna";

				DropDownList ddl = (DropDownList) e.Item.Cells[7].Controls[0].FindControl("cmdAddetto");
				ddl.Enabled=true;
				txtOldAddetto.Text = ddl.SelectedValue;
			}
			else if (e.CommandName=="Aggiorna")
			{			
				foreach (DataGridItem cella in DataGridRicerca.Items)
				{
					ImageButton a =(ImageButton) cella.Cells[0].Controls[0].FindControl("lnkDett");
					a.Visible = true;
					WebControls.UserMeseGiorno _UMG = (WebControls.UserMeseGiorno) e.Item.Cells[5].FindControl("UserMeseGiorno1");		
					_UMG.cmbGiorni.Enabled = false;
					_UMG.cmbMesi.Enabled = false;
				}
				
				DataGridRicerca.Columns[1].Visible = false;

				DropDownList ddl = (DropDownList) e.Item.Cells[7].Controls[0].FindControl("cmdAddetto");
				ddl.Enabled=false;

				ImageButton butt =(ImageButton) e.Item.Cells[0].Controls[0].FindControl("lnkDett");
				butt.ImageUrl="../../images/edit.gif";
				butt.CommandName="Dettaglio";

				WebControls.UserMeseGiorno _UMG_UP = (WebControls.UserMeseGiorno) e.Item.Cells[5].FindControl("UserMeseGiorno1");		
			
				string pmsd = e.Item.Cells[6].Text;
				string addetto = ddl.SelectedValue;
				string data = _UMG_UP.cmbGiorni.SelectedValue + "/" + _UMG_UP.cmbMesi.SelectedValue + "/" + txtAnno.Text;
				string edificio = txtId_bl.Text;
				string anno = txtAnno.Text;
				string apparecchiatura = txtEQ.Text;	
		
				txtOldDD.Text = "";
				txtOldMM.Text = "";
				txtOldAddetto.Text = "";

				int esito = Ottimizza(pmsd, addetto, data, edificio, anno, apparecchiatura);
			}

			else
			{
				foreach (DataGridItem cella in DataGridRicerca.Items)
				{
					ImageButton a =(ImageButton) cella.Cells[0].Controls[0].FindControl("lnkDett");
					a.Visible = true;
					WebControls.UserMeseGiorno _UMG = (WebControls.UserMeseGiorno) e.Item.Cells[5].FindControl("UserMeseGiorno1");		
					_UMG.cmbGiorni.Enabled = false;
					_UMG.cmbMesi.Enabled = false;
					_UMG.cmbMesi.SelectedValue = txtOldMM.Text;
					_UMG.cmbGiorni.SelectedValue = txtOldDD.Text;
				}
				
				DataGridRicerca.Columns[1].Visible = false;

				DropDownList ddl = (DropDownList) e.Item.Cells[7].Controls[0].FindControl("cmdAddetto");
				ddl.Enabled=false;

				ddl.SelectedValue = txtOldAddetto.Text;

				ImageButton butt =(ImageButton) e.Item.Cells[0].Controls[0].FindControl("lnkDett");
				butt.ImageUrl="../../images/edit.gif";
				butt.CommandName="Dettaglio";
			}

		}

		private int Ottimizza(string pmsd, string addetto, string data, string edificio, string anno, string apparecchiatura)
		{
			Classi.ManProgrammata.CreaOttimizzaRDL_MP  _Ott = new TheSite.Classi.ManProgrammata.CreaOttimizzaRDL_MP();
			try
			{
				_Ott.beginTransaction();
				S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_Controls.Collections.S_ControlsCollection();				
			
				S_Controls.Collections.S_Object s_anno = new S_Object();
				s_anno.ParameterName = "p_anno";
				s_anno.DbType = CustomDBType.Integer;
				s_anno.Direction = ParameterDirection.Input;
				s_anno.Index = 0;
				s_anno.Value= Convert.ToInt32(anno);
				CollezioneControlli.Add(s_anno);

				S_Controls.Collections.S_Object s_data = new S_Object();
				s_data.ParameterName = "p_data";
				s_data.DbType = CustomDBType.VarChar;
				s_data.Direction = ParameterDirection.Input;
				s_data.Index = 1;
				s_data.Value= data;
				CollezioneControlli.Add(s_data);

				S_Controls.Collections.S_Object s_addetto = new S_Object();
				s_addetto.ParameterName = "p_addetto";
				s_addetto.DbType = CustomDBType.Integer;
				s_addetto.Direction = ParameterDirection.Input;
				s_addetto.Index = 2;
				s_addetto.Value= Convert.ToInt32(addetto);
				CollezioneControlli.Add(s_addetto);

				S_Controls.Collections.S_Object s_edificio = new S_Object();
				s_edificio.ParameterName = "p_edificio";
				s_edificio.DbType = CustomDBType.Integer;
				s_edificio.Direction = ParameterDirection.Input;
				s_edificio.Index = 3;
				s_edificio.Value= Convert.ToInt32(edificio);
				CollezioneControlli.Add(s_edificio);

				S_Controls.Collections.S_Object s_eq = new S_Object();
				s_eq.ParameterName = "p_eq";
				s_eq.DbType = CustomDBType.VarChar;
				s_eq.Direction = ParameterDirection.Input;
				s_eq.Index = 4;
				s_eq.Value= apparecchiatura;
				CollezioneControlli.Add(s_eq);

				S_Controls.Collections.S_Object s_pmsd = new S_Object();
				s_pmsd.ParameterName = "p_pmsd";
				s_pmsd.DbType = CustomDBType.Integer;
				s_pmsd.Direction = ParameterDirection.Input;
				s_pmsd.Index = 5;
				s_pmsd.Value= Convert.ToInt32(pmsd);
				CollezioneControlli.Add(s_pmsd);

				int esito = _Ott.Update(CollezioneControlli,0);
				// in esito carico il servizio
				_Ott.commitTransaction();

				string mes=String.Empty;
				Classi.SiteJavaScript.msgBox(this.Page, "Aggiornamento effettuato con successo.");	
				string wi = "OttimizzaPianoEQ.aspx?ID_BL=" + edificio + "&anno=" + anno + "&servizio=" + esito + "&p=ottimizza";
				// imposto il campo nascosto a 1 così da non far chiudere la finestra dal chiamate
				txtfiglia.Text = "1";
				Hidden1.Value = "1";
				Classi.SiteJavaScript.OpenerReload(this.Page,wi);

			}
			catch (Exception ex)
			{
				_Ott.rollbackTransaction();
				Console.WriteLine(ex.Message); 
				string mes=String.Empty;
				Classi.SiteJavaScript.msgBox(this.Page, "Si è verificato un errore durante l'aggiornamento del Piano di Lavoro.");				
			}
			return 0;
		}

		

		
	}
}
