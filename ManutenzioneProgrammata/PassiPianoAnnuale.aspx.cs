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

namespace TheSite.ManutenzioneProgrammata
{
	/// <summary>
	/// Descrizione di riepilogo per PassiPianoAnnuale.
	/// </summary>
	public class PassiPianoAnnuale : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblpmp;
		protected System.Web.UI.WebControls.TextBox txtAnno;
		protected System.Web.UI.WebControls.DataGrid DataGridRicerca;
		protected System.Web.UI.WebControls.TextBox txtEQ;
		protected WebControls.GridTitle GridTitle1;
		protected WebControls.PageTitle PageTitle1;
		protected S_Controls.S_Button btSalva;
		protected System.Web.UI.WebControls.TextBox txtId_bl;
		protected System.Web.UI.WebControls.TextBox txtbl_id;
		private DataSet _MyDs = new DataSet();
        private DataTable DtAddetti;

		private string e_Page 

		{ 
			get 
			{
				if ( ViewState["e_Page"]!=null) 
					return (string)ViewState["e_Page"]; 
				else 
					return ""; 
			} 
			set{ViewState["e_Page"]=value;}

		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				PageTitle1.VisibleLogut = false;
				GridTitle1.hplsNuovo.Visible = false;
				txtAnno.Text = Request.Params["anno"]; 
				txtEQ.Text = Request.Params["EQ_ID"];
				this.e_Page=Request.QueryString["p"];
				txtId_bl.Text = Request.Params["id_bl"];
				txtbl_id.Text = Request.Params["bl_id"];

				Session.Remove("DatiListP");
				if(this.e_Page!="ottimizza")
					btSalva.Visible=false;
				else
					PageTitle1.Title="OTTIMIZZA IL PIANO";
  
				lblpmp.Text= "Piano Manutenzione Programmata Apparecchiatura: " + txtEQ.Text + " - Anno: " + txtAnno.Text;
				
				DtAddetti=BindAddettiDitta(txtbl_id.Text,"");

				GetDataGrid();				
			}
		}

		private void GetDataGrid()
		{
			Classi.ManProgrammata.Planner _Planner = new TheSite.Classi.ManProgrammata.Planner();	
			Classi.ManProgrammata.ProcAndSteps _ProcAndSteps = new TheSite.Classi.ManProgrammata.ProcAndSteps();			
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
			if(this.e_Page!="ottimizza")
			{
				_MyDs.Tables.Add(_ProcAndSteps.GetIstruzioni().Tables["ISTRUZIONI"].Copy());
				DataGridRicerca.Columns[6].Visible=false;  
			}
			else
			{
			   DataGridRicerca.Columns[4].Visible=false;  
			}
			this.DataGridRicerca.DataSource = _MyDs.Tables[0];
			this.DataGridRicerca.DataBind();
			
			this.GridTitle1.NumeroRecords = _MyDs.Tables[0].Rows.Count.ToString();	
		}

		private DataTable BindAddettiDitta(string bl_id,string nomecompleto)
		{	
			Classi.ManOrdinaria.Richiesta  _Richiesta = new TheSite.Classi.ManOrdinaria.Richiesta();
			DataSet _MyDs;
			_MyDs = _Richiesta.GetAddetti(nomecompleto,bl_id);
            return _MyDs.Tables[0];
//			if (_MyDs.Tables[0].Rows.Count > 0)
//			{
//				this.cmbsAddettoMod.DataSource = _MyDs.Tables[0];
//				this.cmbsAddettoMod.DataTextField = "NOMINATIVO";
//				this.cmbsAddettoMod.DataValueField = "ID";				
//				this.cmbsAddettoMod.DataBind();				
//			}
//			else
//			{
//				string s_Messagggio = "- Nessun Addetto  -";
//				this.cmbsAddettoMod.Items.Add(Classi.GestoreDropDownList.ItemMessaggio(s_Messagggio, ""));				
//			}
		
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
			this.DataGridRicerca.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGridRicerca_PageIndexChanged);
			this.DataGridRicerca.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGridRicerca_ItemDataBound);
			this.btSalva.Click += new System.EventHandler(this.btSalva_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGridRicerca_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem)
			{				
				DataRowView drv = (DataRowView)(e.Item.DataItem);

				if(this.e_Page=="ottimizza")
				{
					SetControl(true,drv,e);
					DropDownList dropd= (DropDownList)e.Item.Cells[6].Controls[1]; 
					foreach (DataRow Dr in DtAddetti.Rows)
					  dropd.Items.Add(new ListItem(Dr["nome"].ToString() + " " + Dr["cognome"].ToString(),  Dr["ID"].ToString()));  

					  dropd.SelectedValue = drv.Row["ADDETTO_ID"].ToString();
					
                
				}
				else
				{
				
					SetControl(false,drv,e);
					e.Item.Cells[3].Text= Convert.ToDateTime(drv.Row["DATA"].ToString()).ToShortDateString(); //Convert.ToDateTime(drv.Row["DATA"].ToString()).ToString("MMM").ToUpper() + " - " + Convert.ToDateTime(drv.Row["DATA"].ToString()).Year.ToString();
					DataGrid dtgIstruzioni = new DataGrid();
  				
					dtgIstruzioni.CssClass="DataGrid";
					dtgIstruzioni.BorderWidth = (Unit)0;				
					dtgIstruzioni.GridLines = GridLines.Vertical;
					dtgIstruzioni.BorderColor = Color.FromName("Gray");

  
					dtgIstruzioni.AlternatingItemStyle.CssClass = "DataGridAlternatingItemStyle";  
					dtgIstruzioni.ItemStyle.CssClass = "DataGridItemStyle";	
					dtgIstruzioni.ItemStyle.VerticalAlign= VerticalAlign.Top;
					dtgIstruzioni.Width = Unit.Percentage(100);
				  			
					dtgIstruzioni.AutoGenerateColumns = false;
					dtgIstruzioni.ShowHeader = false;
			
					BoundColumn bc = new BoundColumn();		
					bc.DataField = "ISTRUZIONI";
					bc.ItemStyle.Wrap = true;				
					dtgIstruzioni.Columns.Add(bc);
  			  			
					DataView dvIstruzioni = _MyDs.Tables[1].DefaultView;
					dvIstruzioni.RowFilter = "ID='" + e.Item.Cells[0].Text + "'";
  				
					dtgIstruzioni.DataSource = dvIstruzioni;
					dtgIstruzioni.DataBind();
					dtgIstruzioni.Visible =true;
					e.Item.Cells[4].Controls.Add(dtgIstruzioni);
				}

				
			}

		}
		private void SetControl(bool visiblecontrol,DataRowView drv,System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			WebControls.UserMeseGiorno _UMG = (WebControls.UserMeseGiorno) e.Item.Cells[3].FindControl("UserMeseGiorno1");		
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
		private void DataGridRicerca_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			//Salvo i dati
			if(this.e_Page=="ottimizza")
			{
				SaveDati(DataGridRicerca);
				DtAddetti=BindAddettiDitta(txtbl_id.Text,"");
			}
			DataGridRicerca.CurrentPageIndex = e.NewPageIndex;	
			GetDataGrid();
			if(this.e_Page=="ottimizza")
			  GetDati(DataGridRicerca); 
		}

		private void SaveDati(DataGrid Ctrl)
		{			
			
			Hashtable _HS=null;
			
			if(Session["DatiListP"]!=null)
				_HS=(Hashtable) Session["DatiListP"];				
			else
				_HS = new Hashtable();

						
			foreach(DataGridItem o_Litem in Ctrl.Items)
			{
				
				string id= o_Litem.Cells[5].Text;																					

				if(_HS.ContainsKey(id))
					_HS.Remove(id);												
												
				if(this.e_Page=="ottimizza")
				{
					DettailList _campi = new DettailList();
					WebControls.UserMeseGiorno _UMG = (WebControls.UserMeseGiorno)o_Litem.Cells[3].FindControl("UserMeseGiorno1");

					_campi.id=id;
					_campi.Mese = _UMG.cmbMesi.SelectedValue;
					_campi.Giorno=_UMG.cmbGiorni.SelectedValue;	
					_HS.Add(_campi.id,_campi);		
				}
				
		
			}	//end for
		
			Session.Remove("DatiListP");
			Session.Add("DatiListP",_HS);
		}

		private void GetDati(DataGrid Ctrl)
		{			
			
			Hashtable _HS=null;
			
			if(Session["DatiListP"]!=null)
				_HS=(Hashtable) Session["DatiListP"];				
			else
				return;
		
			foreach(DataGridItem o_Litem in Ctrl.Items)
			{
				
				string id = o_Litem.Cells[5].Text;																					
				
				if(_HS.ContainsKey(id))
				{
					DettailList _campi = (DettailList)_HS[id];
					WebControls.UserMeseGiorno _UMG = (WebControls.UserMeseGiorno) o_Litem.Cells[3].FindControl("UserMeseGiorno1");	
                    
					_UMG.cmbMesi.SelectedValue=_campi.Mese;
					
					//Richiamo la funzione che imposta i giorni del mese in esame
					ImpostaGiorni(_campi.Mese,_UMG.cmbGiorni);					
					
					_UMG.cmbGiorni.SelectedValue=_campi.Giorno;
				}
				
			}	//end for
		
		}

		private void btSalva_Click(object sender, System.EventArgs e)
		{
			//Salvo i dati
			SaveDati(DataGridRicerca);

		}
	}

	public class DettailList
	{
		public string id=null;
		public string Giorno=null;
		public string Mese=null;
	}
}
