using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;

namespace TheSite.SoddisfazioneCliente
{
	/// <summary>
	/// Descrizione di riepilogo per KPI.
	/// </summary>
	public class KPI : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DrPriorita;
		protected System.Web.UI.WebControls.DropDownList DropAnno;
		protected S_Controls.S_Button btnsRicerca;
		protected S_Controls.S_Button btnReset;
		protected System.Web.UI.WebControls.Repeater Repeater1;
		protected System.Web.UI.WebControls.DropDownList DrMese;
		protected System.Web.UI.WebControls.Repeater Repeater2;
		protected System.Web.UI.WebControls.Repeater Repeater3;
		protected WebControls.RicercaModulo RicercaModulo1;
		protected System.Web.UI.HtmlControls.HtmlTable tblFuoriSLA;
		protected System.Web.UI.HtmlControls.HtmlTable tblTotAtt;
		protected System.Web.UI.HtmlControls.HtmlTable TabXLS;
		protected System.Web.UI.WebControls.Repeater RepeaterREI;
		protected System.Web.UI.WebControls.Repeater RepeaterXls;
		protected System.Web.UI.HtmlControls.HtmlTable TabREI;
		protected System.Web.UI.HtmlControls.HtmlTable tblPianiMens ;

	//VAriabili per popolare il footer del Repeater1
		public string TPriorita="";
		public int Twr_pres;
		public int Twr_no_pres;
		public int  Twr_tot;
		public int  TfuoriSLA;
		public double  Trisultato;
		public string TPriorita1="";
		public int Twr_pres1;
		public int Twr_no_pres1;
		public int  Twr_tot1;
		public int  TfuoriSLA1;
		public double  Trisultato1;
		public string TPriorita2="";
		public int Twr_pres2;
		public int Twr_no_pres2;
		public int  Twr_tot2;
		public int  TfuoriSLA2;
		public double  Trisultato2;

	 //
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{
				LoadAnno();
				clearRep();
			}
		}
		private void clearRep()
		{
			this.tblTotAtt.Visible = false;
			this.tblFuoriSLA.Visible = false;
			this.tblPianiMens.Visible = false;
			TabREI.Visible=false;
			TabXLS.Visible=false;
		}
		private void LoadAnno()
		{
			for(int i=2008;i<=2020;i++)
				DropAnno.Items.Add(new ListItem(i.ToString(),i.ToString()));  
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnsRicerca_Click(object sender, System.EventArgs e)
		{
			RicercaFuoriSLA();
			RicercaPiani();
			ContaAttivita();
			RicercaREI();
			RicercaXLS();

		}

		
		private void RicercaFuoriSLA()
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new  S_Controls.Collections.S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_p_priorita = new S_Controls.Collections.S_Object();
			s_p_priorita.ParameterName = "p_priorita";
			s_p_priorita.DbType = CustomDBType.Integer;
			s_p_priorita.Direction = ParameterDirection.Input;
			s_p_priorita.Index = CollezioneControlli.Count;
			s_p_priorita.Value = Convert.ToInt32(DrPriorita.SelectedValue);		
			CollezioneControlli.Add(s_p_priorita);

			S_Controls.Collections.S_Object s_p_mese = new S_Controls.Collections.S_Object();
			s_p_mese.ParameterName = "p_mese";
			s_p_mese.DbType = CustomDBType.VarChar;
			s_p_mese.Size=2;
			s_p_mese.Direction = ParameterDirection.Input;
			s_p_mese.Index = CollezioneControlli.Count;
			s_p_mese.Value =  DrMese.SelectedValue;		
			CollezioneControlli.Add(s_p_mese);

			S_Controls.Collections.S_Object s_p_anno = new S_Controls.Collections.S_Object();
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.VarChar;
			s_p_anno.Size=4;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Index = CollezioneControlli.Count;
			s_p_anno.Value =  DropAnno.SelectedValue;		
			CollezioneControlli.Add(s_p_anno);
			
			S_Controls.Collections.S_Object s_p_idbl = new S_Controls.Collections.S_Object();
			s_p_idbl.ParameterName = "p_idbl";
			s_p_idbl.DbType = CustomDBType.VarChar;
			s_p_idbl.Size=4;
			s_p_idbl.Direction = ParameterDirection.Input;
			s_p_idbl.Index = CollezioneControlli.Count;
			s_p_idbl.Value =  RicercaModulo1.BlId;	
			CollezioneControlli.Add(s_p_idbl);

			Classi.SoddCliente.Soddisfato _Kpi = new TheSite.Classi.SoddCliente.Soddisfato();
			DataSet Ds = _Kpi.GetKPI(CollezioneControlli);

		// calcolo totali per priorità
			DataTable _Dt=Ds.Tables[0];
			foreach(DataRow riga in _Dt.Rows)
			{
				switch (riga["priorita"].ToString())
				{
					case "Emergenza (2 ore)":
					TPriorita="Tot "+ riga["priorita"].ToString();
					Twr_pres=Twr_pres+ Convert.ToInt32(riga["wr_pres"]);
					Twr_no_pres=Twr_no_pres+ Convert.ToInt32(riga["wr_no_pres"]);
					Twr_tot=Twr_tot+ Convert.ToInt32(riga["wr_tot"]);
					TfuoriSLA=TfuoriSLA+ Convert.ToInt32(riga["fuoriSLA"]);
					//Trisultato=Trisultato;
						break;
					case "Critico (4 ore)":
						TPriorita1="Tot "+ riga["priorita"].ToString();
						Twr_pres1=Twr_pres1 +Convert.ToInt32(riga["wr_pres"]);
						Twr_no_pres1=Twr_no_pres1 +Convert.ToInt32(riga["wr_no_pres"]);
						Twr_tot1=Twr_tot1 +Convert.ToInt32(riga["wr_tot"]);
						TfuoriSLA1=TfuoriSLA1 +Convert.ToInt32(riga["fuoriSLA"]);
						break;
					case "Urgente (10 ore)":
						TPriorita2="Tot "+ riga["priorita"].ToString();
						Twr_pres2=Twr_pres2 +Convert.ToInt32(riga["wr_pres"]);
						Twr_no_pres2=Twr_no_pres2 +Convert.ToInt32(riga["wr_no_pres"]);
						Twr_tot2=Twr_tot2 +Convert.ToInt32(riga["wr_tot"]);
						TfuoriSLA2=TfuoriSLA2 +Convert.ToInt32(riga["fuoriSLA"]);
						break;
					default:
						break;
				}
			}
			if (TfuoriSLA!=0)
				Trisultato= Math.Round(1-(Convert.ToDouble(TfuoriSLA)/Convert.ToDouble(Twr_tot)),1)*100;
			else
				Trisultato=100;
			
			if (TfuoriSLA1!=0)
			Trisultato1= Math.Round(1-(Convert.ToDouble(TfuoriSLA1)/Convert.ToDouble(Twr_tot1)),1)*100;
			else
				Trisultato1=100;

			if (TfuoriSLA2!=0)	
				Trisultato2= Math.Round(1-(Convert.ToDouble(TfuoriSLA2)/Convert.ToDouble(Twr_tot2)),1)*100;
			else
				Trisultato2=100;

			if (Ds.Tables[0].Rows.Count != 0)
			{
				Repeater1.DataSource=Ds;
				Repeater1.DataBind(); 
				this.tblFuoriSLA.Visible = true;
			}

		}
		private void RicercaPiani()
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new  S_Controls.Collections.S_ControlsCollection();
			


			S_Controls.Collections.S_Object s_p_mese = new S_Controls.Collections.S_Object();
			s_p_mese.ParameterName = "p_mese";
			s_p_mese.DbType = CustomDBType.VarChar;
			s_p_mese.Size=2;
			s_p_mese.Direction = ParameterDirection.Input;
			s_p_mese.Index = CollezioneControlli.Count;
			s_p_mese.Value =  DrMese.SelectedValue;		
			CollezioneControlli.Add(s_p_mese);

			S_Controls.Collections.S_Object s_p_anno = new S_Controls.Collections.S_Object();
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.VarChar;
			s_p_anno.Size=4;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Index = CollezioneControlli.Count;
			s_p_anno.Value =  DropAnno.SelectedValue;		
			CollezioneControlli.Add(s_p_anno);
			
			S_Controls.Collections.S_Object s_p_idbl = new S_Controls.Collections.S_Object();
			s_p_idbl.ParameterName = "p_idbl";
			s_p_idbl.DbType = CustomDBType.VarChar;
			s_p_idbl.Size=4;
			s_p_idbl.Direction = ParameterDirection.Input;
			s_p_idbl.Index = CollezioneControlli.Count;
			s_p_idbl.Value =  RicercaModulo1.BlId;	
			CollezioneControlli.Add(s_p_idbl);

			Classi.SoddCliente.Soddisfato _Kpi = new TheSite.Classi.SoddCliente.Soddisfato();
			DataSet Ds = _Kpi.GetPianiMensili(CollezioneControlli);

			if (Ds.Tables[0].Rows.Count != 0)
			{
				Repeater2.DataSource=Ds;
				Repeater2.DataBind(); 
				this.tblPianiMens.Visible = true;
			}
		}

		private void RicercaREI()
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new  S_Controls.Collections.S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_p_mese = new S_Controls.Collections.S_Object();
			s_p_mese.ParameterName = "p_mese";
			s_p_mese.DbType = CustomDBType.VarChar;
			s_p_mese.Size=2;
			s_p_mese.Direction = ParameterDirection.Input;
			s_p_mese.Index = CollezioneControlli.Count;
			s_p_mese.Value =  DrMese.SelectedValue;		
			CollezioneControlli.Add(s_p_mese);

			S_Controls.Collections.S_Object s_p_anno = new S_Controls.Collections.S_Object();
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.VarChar;
			s_p_anno.Size=4;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Index = CollezioneControlli.Count;
			s_p_anno.Value =  DropAnno.SelectedValue;		
			CollezioneControlli.Add(s_p_anno);
			
			S_Controls.Collections.S_Object s_p_idbl = new S_Controls.Collections.S_Object();
			s_p_idbl.ParameterName = "p_idbl";
			s_p_idbl.DbType = CustomDBType.VarChar;
			s_p_idbl.Size=4;
			s_p_idbl.Direction = ParameterDirection.Input;
			s_p_idbl.Index = CollezioneControlli.Count;
			s_p_idbl.Value =  RicercaModulo1.BlId;	
			CollezioneControlli.Add(s_p_idbl);

			Classi.SoddCliente.Soddisfato _Kpi = new TheSite.Classi.SoddCliente.Soddisfato();
			DataSet Ds = _Kpi.GetREI(CollezioneControlli);

			if (Ds.Tables[0].Rows.Count != 0)
			{
				RepeaterREI.DataSource=Ds;
				RepeaterREI.DataBind(); 	
				TabREI.Visible=true;
			}
		}

		private void RicercaXLS()
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new  S_Controls.Collections.S_ControlsCollection();
			

			S_Controls.Collections.S_Object s_p_mese = new S_Controls.Collections.S_Object();
			s_p_mese.ParameterName = "p_mese";
			s_p_mese.DbType = CustomDBType.VarChar;
			s_p_mese.Size=2;
			s_p_mese.Direction = ParameterDirection.Input;
			s_p_mese.Index = CollezioneControlli.Count;
			s_p_mese.Value =  DrMese.SelectedValue;		
			CollezioneControlli.Add(s_p_mese);

			S_Controls.Collections.S_Object s_p_anno = new S_Controls.Collections.S_Object();
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.VarChar;
			s_p_anno.Size=4;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Index = CollezioneControlli.Count;
			s_p_anno.Value =  DropAnno.SelectedValue;		
			CollezioneControlli.Add(s_p_anno);
			
			S_Controls.Collections.S_Object s_p_idbl = new S_Controls.Collections.S_Object();
			s_p_idbl.ParameterName = "p_idbl";
			s_p_idbl.DbType = CustomDBType.VarChar;
			s_p_idbl.Size=4;
			s_p_idbl.Direction = ParameterDirection.Input;
			s_p_idbl.Index = CollezioneControlli.Count;
			s_p_idbl.Value =  RicercaModulo1.BlId;	
			CollezioneControlli.Add(s_p_idbl);

			Classi.SoddCliente.Soddisfato _Kpi = new TheSite.Classi.SoddCliente.Soddisfato();
			DataSet Ds = _Kpi.GetXls(CollezioneControlli);

			if (Ds.Tables[0].Rows.Count != 0)
			{
				RepeaterXls.DataSource=Ds;
				RepeaterXls.DataBind(); 
				this.TabXLS.Visible = true;
			}
		}

		public double RisultatoKPI(object TotWrSla,object TotWr)
		{
			double TotWrSla1 = Convert.ToDouble(TotWrSla);
			double TotWr1 = Convert.ToDouble(TotWr);
			double Ris;
			Ris=  Math.Round((1-TotWrSla1/TotWr1),1)*100;
			return Ris;
		}

		public double Risultato(object PP1,object PPOL1,object PE1,object PEOL1)
		{
			double PP = Convert.ToDouble(PP1);
			double PPOL = Convert.ToDouble(PPOL1);
			double PE = Convert.ToDouble(PE1);
			double PEOL = Convert.ToDouble(PEOL1);

			double Ris;
			Ris=  Math.Round((1-(PPOL+PEOL)/(PP+PE))*100,1);
			return Ris;
		}

		public double RisSlittamento(object PP1,object PPOL1)
		{
			
			double PP = Convert.ToDouble(PP1);
			double PPOL = Convert.ToDouble(PPOL1);
			double Ris=0;
			if (PP==0)
				Ris=100;
			else
				Ris= Math.Round(((PP/PPOL)*100),1);
			return Ris;
		}
		public double RisSlittamentoEnto10(object TotAtt,object neiTempi, object nei10g)
		{
			double TA = Convert.ToDouble(TotAtt);
			double NT = Convert.ToDouble(neiTempi);
			double N10 = Convert.ToDouble(nei10g);
			double Ris=0;
			if (TA==0)
				Ris	= 100;
			else if (NT!=0)
			{
				if((TA/NT>=98) && (N10/TA<=2) && (TA-N10==0))
					Ris	= Math.Round((NT/TA),1);
			}
			else
				Ris=0;

			return Ris;
		}

		public double RisRei(object TotRei,object TotSla)
		{
			double totrei=Convert.ToDouble(TotRei);
			double totsla=Convert.ToDouble(TotSla);
			double Ris=0;
			if (totrei==0)
				Ris=100;
			else if(totsla!=0)
				Ris= Math.Round((1-(totrei/totsla))*100,1);
			else
				Ris=0;
			return Ris;
		}
		private void ContaAttivita()
		{
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new  S_Controls.Collections.S_ControlsCollection();
			


			S_Controls.Collections.S_Object s_p_mese = new S_Controls.Collections.S_Object();
			s_p_mese.ParameterName = "p_mese";
			s_p_mese.DbType = CustomDBType.VarChar;
			s_p_mese.Size=2;
			s_p_mese.Direction = ParameterDirection.Input;
			s_p_mese.Index = CollezioneControlli.Count;
			s_p_mese.Value =  DrMese.SelectedValue;		
			CollezioneControlli.Add(s_p_mese);

			S_Controls.Collections.S_Object s_p_anno = new S_Controls.Collections.S_Object();
			s_p_anno.ParameterName = "p_anno";
			s_p_anno.DbType = CustomDBType.VarChar;
			s_p_anno.Size=4;
			s_p_anno.Direction = ParameterDirection.Input;
			s_p_anno.Index = CollezioneControlli.Count;
			s_p_anno.Value =  DropAnno.SelectedValue;		
			CollezioneControlli.Add(s_p_anno);
			
			S_Controls.Collections.S_Object s_p_idbl = new S_Controls.Collections.S_Object();
			s_p_idbl.ParameterName = "p_idbl";
			s_p_idbl.DbType = CustomDBType.VarChar;
			s_p_idbl.Size=4;
			s_p_idbl.Direction = ParameterDirection.Input;
			s_p_idbl.Index = CollezioneControlli.Count;
			s_p_idbl.Value =  RicercaModulo1.BlId;	
			CollezioneControlli.Add(s_p_idbl);

			Classi.SoddCliente.Soddisfato _Kpi = new TheSite.Classi.SoddCliente.Soddisfato();
			DataSet Ds = _Kpi.numAttivita(CollezioneControlli);

//			if (Ds.Tables[0].Rows.Count != 0)
//			{

//				DataTable dt=Ds.Tables[0];
//				DataTable dt2 =new DataTable();
//				
//				DataColumn totAtt = new DataColumn("totAtt");
//				dt2.Columns.Add(totAtt);
//				DataColumn neiTempi = new DataColumn("neiTempi");
//				dt2.Columns.Add(neiTempi);
//				DataColumn nei100gg = new DataColumn("nei100gg");
//				dt2.Columns.Add(nei100gg);
//
//				DataRow riga = dt2.NewRow();
//
//				riga["totAtt"] = dt.Rows[2][0];
//				riga["neiTempi"]= dt.Rows[1][0];
//				riga["nei100gg"] = dt.Rows[0][0];
//
//				dt2.Rows.Add(riga);
				

				Repeater3.DataSource=Ds;
				Repeater3.DataBind(); 
				this.tblTotAtt.Visible = true;
//			}

		}

		
	}
}
